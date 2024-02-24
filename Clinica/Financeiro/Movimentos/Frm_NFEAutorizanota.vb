Imports System.Drawing.Printing
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Data.DataColumnCollection
Imports System.Data.DataRow
Imports System.Xml
Imports System.Xml.Xsl
Imports System.DateTime
Imports Npgsql
Public Class Frm_NFEAutorizanota
    Dim cl_BD As New Cl_bdMetrosys
    Dim cl_funcoes As New Funcoes
    Dim agora As Date = Now
    Dim vnt_dtemis As Date
    Private Arqxml As String = "\wged\NFE001.txt"
    Private ArqTemp As String = "\wged\NFE002.txt"
    Private xmlPath As String = "\wged\MyData.xml"
    Protected conexao As String = ModuloConexaoBD.conectionPadrao
    '_
    '   "Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDGENOV"
    Dim _BuscaForn As New Frm_buscaFornecedor
    Dim _formBusca As Boolean = False
    Dim mNFe_Cfop As String
    Public mbUf, mbCNPJ, mCodPart, mNomePart, mEnderecoPart, mCidadePart As String
    Public mCepPart, mFonePart As String
    Public _mPesquisaForn As Boolean = False 'Serve para configura os campos CodFornec e NomeFornec
    Public Shared _frmREf As New Frm_NFEAutorizanota

    Dim fsxml As FileStream
    Dim s As StreamWriter
    Dim mMxml As New GenoNFeXml
    Public vg_geno, vg_ender, vg_cid, vg_uf, vg_cep, vg_bairro, vg_cnpj, vg_insc As String
    Public vg_fone, vg_fax, vg_codmun, vg_coduf, vg_email, vg_crt As String

    Dim CodEstab, mAmb, mcontf, mSeqNFe As String


    Private Sub btn_nfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nfe.Click
        s.BaseStream.Seek(0, SeekOrigin.End)

        If MessageBox.Show("Confirme Gerar Nota Fiscal ", "Gerar NFe ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim oConUp As New NpgsqlConnection(conexao)
            'Dim oCmdUp As NpgsqlCommand

            Dim oConn As New NpgsqlConnection(conexao)
            Dim oCmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader
            Dim daCont As New NpgsqlDataAdapter
            Dim Mconsulta As Boolean = False
            ' Estabelecimento Selecionado
            CodEstab = String.Format("{0:D2}", cbo_estabelecimento.SelectedIndex + 1)

            Dim Sqlcomm As StringBuilder = New StringBuilder
            Sqlcomm.Append("SELECT gp_requis, gp_sai, gp_fat, gp_data, gp_icms,") ' 4
            Sqlcomm.Append("gp_icmse, gp_serv,gp_orca, gp_txreduz, gp_icmred,") '9
            Sqlcomm.Append("gp_txcob, gp_txesvei, gp_mensag , gp_serie, gp_amb, ") '14
            Sqlcomm.Append("gp_contf, gp_seqnfe, gp_pis, gp_confin FROM genp0" & CodEstab.ToString) '18
            daCont = New NpgsqlDataAdapter(Sqlcomm.ToString, oConn)
            oCmd = New NpgsqlCommand(Sqlcomm.ToString, oConn)
            Dim dt As DataTable = New DataTable
            Dim dsCont As DataSet = New DataSet
            Dim mReq, mNum, mFatu, mOrca, vgp_sai As String
            mNum = "" : mFatu = "" : mOrca = "" : vgp_sai = ""
            Dim mgp_req, mgp_num As Integer
            Dim mgp_fatu, mgp_orca As Integer
            mgp_fatu = "" : mgp_orca = ""
            Dim vgp_seqnfe, vgp_serie, mgp_numero As String
            vgp_seqnfe = "" : mgp_numero = "" : vgp_serie = ""
            Dim vgp_pis, vgp_confin As Double

            Try
                daCont.Fill(dsCont, "Genp0" & CodEstab.ToString)
                oConn.Open()
                dt.Load(oCmd.ExecuteReader())
                dr = (oCmd.ExecuteReader())
                While dr.Read()
                    mReq = dr(0).ToString
                    vgp_sai = dr(1).ToString
                    mAmb = dr(14)
                    mcontf = dr(15) ' Tipo de Emissão (Normal ou Contigencia )
                    mgp_req = Convert.ToInt32(mReq)
                    mgp_num = dr(1)
                    vgp_seqnfe = dr(16)
                    vgp_serie = dr(13)
                    vgp_pis = dr(17)
                    vgp_confin = dr(18)

                End While
            Catch ex As NpgsqlException
                MsgBox(ex.Message.ToString)
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

         
            '   * *  Inicio de Criação de XML  ***
            Try

                ' Cabeçalho Padrão do Xml
                s.Write("<?xml version=""")
                s.Write("1.0""")
                s.Write(" encoding=""")
                s.Write("UTF-8""")
                s.WriteLine("?>")

                'Cabeçalho do Atributo
                s.Write("<NFe xmlns=""")
                s.Write("http://www.portalfiscal.inf.br/nfe""")
                s.WriteLine(">")

                ' Elementos do grupo B
                ' Identificação da Nota Fiscal eletrônica 
                xmlGrupo_B(vg_coduf, vgp_seqnfe, Mid(cbo_nfeCfop.SelectedItem, 7, 59), "0", "55", vgp_serie, mgp_num, _
                                vnt_dtemis, DateValue(msk_dtsaida.Text), "1", vg_codmun, "1", mcontf, "8", mAmb, "1", "0", "6")


                ' Encerramento do Cabeçalho do Atributo Inicial

                ' ***** Inicia Tag's do Grupo C -  Emitente da NFe ******
                ' Elementos do grupo C
                xmlGrupo_C(vg_cnpj, vg_geno, vg_ender, vg_bairro, vg_codmun, vg_cid, vg_uf, vg_cep, _
                            vg_fax, vg_insc, vg_crt)

                ' ***** Inicia Tag's do Grupo E -  Destinatario da NFe ******
                ' Elementos do grupo E

                Dim conPort As New Npgsql.NpgsqlConnection(conexao)
                Dim SqlcomPort As StringBuilder = New StringBuilder
                Dim DrPort As NpgsqlDataReader

                SqlcomPort.Append("SELECT p_carac, p_cpf, p_cgc, p_insc,p_end,p_bairro,p_cid, p_uf, ") '7
                SqlcomPort.Append("p_cep, p_fone,p_mun, p_coduf,p_email FROM cadp001 where p_cod ='" & mCodPart.ToString.ToUpper & "'")
                Dim daPort As NpgsqlDataAdapter = New NpgsqlDataAdapter(SqlcomPort.ToString, conPort)
                Dim dsPort As DataSet = New DataSet()

                Dim cmdPort As NpgsqlCommand = New NpgsqlCommand(Sqlcomm.ToString, conPort)
                cmdPort.CommandText = SqlcomPort.ToString
                ' Criar datatable para leitura dos dados
                Dim dtPort As DataTable = New DataTable
                Dim vp_carac, vp_cpf, vp_cgc, vp_insc, vp_end, vp_bairro, vp_cid, vp_uf As String
                Dim vp_cep, vp_fone, vp_mun, vp_coduf, vp_email, vp_suframa As String
                vp_carac = "" : vp_cpf = "" : vp_cgc = "" : vp_insc = "" : vp_end = "" : vp_bairro = "" : vp_cid = ""
                vp_uf = "" : vp_cep = "" : vp_fone = "" : vp_mun = "" : vp_coduf = "" : vp_email = "" : vp_suframa = ""


                Try

                    conPort.Open()
                    dtPort.Load(cmdPort.ExecuteReader())    ' Carrega o datatable para memoria
                    DrPort = cmdPort.ExecuteReader          ' Executa leitura do commando
                    While (DrPort.Read())                   ' Ler Registros Selecionado no Paramentro
                        vp_carac = DrPort(0)
                        vp_cpf = DrPort(1)
                        vp_cgc = DrPort(2)
                        vp_insc = DrPort(3)
                        vp_end = DrPort(4)
                        vp_bairro = DrPort(5)
                        vp_cid = DrPort(6)
                        vp_uf = DrPort(7)
                        vp_cep = DrPort(8)
                        vp_fone = DrPort(9)
                        vp_mun = DrPort(10)
                        vp_coduf = DrPort(11)
                        vp_email = DrPort(12).ToString
                    End While
                    vp_suframa = ""
                    xmlGrupo_E(vp_carac, vp_cgc, vp_cpf, mNomePart, vp_end, vp_bairro, vp_mun, vp_cid, vp_uf, vp_cep, _
                                vp_fone, vp_insc, vp_suframa, vp_email)

                    conPort.Close()
                    conPort.Dispose()
                Catch ex As NpgsqlException
                    MsgBox(ex.Message.ToString)
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                End Try

                '***************************************************************************
                ' Acoplando itens do pedido a Nfe - Nota2cc

                Dim conItens As New Npgsql.NpgsqlConnection(conexao)
                Dim SqlcomItens As StringBuilder = New StringBuilder
                Dim DrItens As NpgsqlDataReader

                Dim vnc_tipo, vnc_numer, vnc_codpr, vnc_produt, vnc_cf, vnc_cst, vnc_und As String
                Dim vnc_qtde, vnc_prunit, vnc_prtot, vnc_alqicm, vnc_alqipi, vnc_vlipi As Double
                Dim vnc_vlicm, vnc_dtemis, vnc_cdport, vnc_unipi, vnc_vlsubs, vnc_cfop As Double
                Dim vnc_bcalc, vnc_basesub, vnc_frete, vnc_segur, vnc_vldesc, vnc_isento As Double

                Try
                    'SELECT O1.nt_orca , O1.nt_tipo2, O2.no_codpr, E.e_produt, E.e_und, O2.no_qtde, O2.no_prunit, 
                    'E.e_clf, E.e_cst,E.e_cfv from orca1pp O1, orca2cc O2, est0001 E where O1.nt_orca='11070654' 
                    'AND O2.no_orca='11070654' AND E.e_codig=O2.no_codpr

                    SqlcomItens.Append("SELECT no_orca, no_codpr, no_produt, no_und, no_qtde, no_prunit, no_prtot,") '6
                    SqlcomItens.Append("no_alqicm, no_dtemis,  where no_orca='" & RTrim(Me.txt_pedido.Text.ToString) & "'")
                    Dim daItens As NpgsqlDataAdapter = New NpgsqlDataAdapter(SqlcomItens.ToString, conItens)
                    Dim dstens As DataSet = New DataSet()

                    Dim cmdItens As NpgsqlCommand = New NpgsqlCommand(Sqlcomm.ToString, conItens)
                    cmdItens.CommandText = SqlcomItens.ToString
                    ' Criar datatable para leitura dos dados
                    Dim dtItens As DataTable = New DataTable


                    conItens.Open()
                    dtItens.Load(cmdItens.ExecuteReader())    ' Carrega o datatable para memoria
                    DrItens = cmdItens.ExecuteReader          ' Executa leitura do commando
                    While (DrItens.Read())                   ' Ler Registros Selecionado no Paramentro
                        vnc_tipo = "S"
                        vnc_numer = vgp_sai
                        vnc_codpr = DrItens(1)
                        vnc_produt = DrItens(2)
                        vnc_cf = DrItens(1)
                        vnc_cst = DrItens(1)
                        vnc_und = DrItens(3)
                        vnc_qtde = DrItens(4)
                        vnc_prunit = DrItens(5)
                        vnc_prtot = (DrItens(4) * DrItens(5))
                        vnc_alqicm = DrItens(1)
                        vnc_alqipi = DrItens(1)
                        vnc_vlipi = DrItens(1)
                        vnc_vlicm = DrItens(1)
                        vnc_dtemis = DateValue(Now).ToOADate()
                        vnc_cdport = Me.txt_codPart.Text
                        vnc_unipi = DrItens(1)
                        vnc_vlsubs = DrItens(1)
                        vnc_cfop = DrItens(1)
                        vnc_bcalc = DrItens(1)
                        vnc_basesub = DrItens(1)
                        vnc_frete = DrItens(1)
                        vnc_segur = DrItens(1)
                        vnc_vldesc = DrItens(1)
                        vnc_isento = DrItens(1)

                    End While

                    conItens.Close()
                Catch ex As NpgsqlException
                    MsgBox(ex.Message.ToString)
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                End Try

                '****************************************************************************
                ' ***** Inicia Tag's do Grupo L -  Produtos da Nfe ******

                '     **** Valores Totais da NFe Tag W ****
                ' xmlGrupo_W()

                ' ***** Inicia Tag's do Grupo X -  Transportador da Nfe ******
                Dim vt_codp, modfret, mp_cpf, mp_cgc, mp_ie, mp_insc, mp_portad, mp_end, mp_cid As String
                Dim mp_uf, vt_placa, vt_antt, vt_uf, vt_marca, vt_espec As String
                vt_codp = "" : modfret = "" : mp_cpf = "" : mp_cgc = "" : mp_ie = "" : mp_insc = "" : mp_portad = ""
                mp_end = "" : mp_cid = "" : mp_uf = "" : vt_placa = "" : vt_antt = "" : vt_uf = "" : vt_marca = "" : vt_espec = ""
                Dim vt_pesol As Double = 0.0
                Dim vt_pesob As Double = 0.0
                Dim vt_qtde As Integer
                modfret = "0"
                vt_marca = "DIVERSOS"
                vt_espec = "VOLUMES"
                If cbo_transportador.SelectedIndex = 0 Then
                    vt_codp = "999999"
                End If
                If cbo_placa.SelectedIndex = -1 Then
                    vt_placa = "".ToString
                Else
                    vt_placa = cbo_placa.SelectedValue
                End If
                xmlGrupo_X(vt_codp, modfret, mp_cpf, mp_cgc, mp_ie, mp_insc, mp_portad, mp_end, mp_cid, mp_uf, vt_placa, _
                            vt_antt, vt_uf, vt_qtde, vt_espec, vt_marca, vt_pesol, vt_pesob)

                ' ***** Inicia Tag's do Grupo Z -  Informações Complementares da Nfe ******
                ' xmlGrupo_Z
                s.WriteLine("</NFe>")

                s.Close()
                fsxml.Close()
                File.Copy(ArqTemp, xmlPath, True)

                MessageBox.Show("Nota Gerada c/ Sucessso !", "Finalização", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        Else
            MessageBox.Show("Nota Fiscal Não Gerada !", "Finalização", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            fsxml.Close()
            Me.Close()
        End If

    End Sub

    Public Function xmlGrupo_B(ByVal codUf As String, ByVal SeqNFe As String, ByVal Natureza As String, ByVal Pagam As String, ByVal Modelo As String, _
                          ByVal Serie As String, ByVal Numero As String, ByVal Emissao As Date, ByVal DtSaidas As Date, ByVal TipoNf As String, _
                          ByVal CodMun As String, ByVal TPImpressao As String, ByVal TPEmis As String, ByVal DigNFe As String, ByVal Amb As String, _
                          ByVal Finali As String, ByVal ProcEmis As String, ByVal Versao As String) As Boolean

        Dim _emissao, _DtSaidas As String
        _emissao = mMxml.DataInvertidaNFe(CStr(Emissao))
        _DtSaidas = mMxml.DataInvertidaNFe(CStr(DtSaidas))


        s.WriteLine("<ide>")
        s.WriteLine("<cUF>" & codUf & "</cUF>")
        s.WriteLine("<cNF>" & SeqNFe & "</cNF>")
        s.WriteLine("<natOp>" & RTrim(Natureza) & "</natOp>")
        s.WriteLine("<indPag>0</indPag>")
        s.WriteLine("<mod>55</mod>")
        s.WriteLine("<serie>" & LTrim(Serie) & "</serie>")
        s.WriteLine("<nNF>" & LTrim(Numero) & "</nNF>")
        s.WriteLine("<dEmi>" & _emissao & "</dEmi>")
        s.WriteLine("<dSaiEnt>" & _DtSaidas & "</dSaiEnt>")
        s.WriteLine("<tpNF>" & TipoNf & "</tpNF>")
        s.WriteLine("<cMunFG>" & CodMun & "</cMunFG>")
        s.WriteLine("<tpImp>" & TPImpressao & "</tpImp>")
        s.WriteLine("<tpEmis>" & TPEmis & "</tpEmis>")
        s.WriteLine("<cDV>" & DigNFe & "</cDV>")
        s.WriteLine("<tpAmb>" & Amb & "</tpAmb>")
        s.WriteLine("<finNFe>" & Finali & "</finNFe>")
        s.WriteLine("<procEmi>" & ProcEmis & "</procEmi>")
        s.WriteLine("<verProc>" & Versao & "</verProc>")
        s.WriteLine("</ide>")

        Return True

    End Function

    Public Function xmlGrupo_C(ByVal vg_cgc As String, ByVal vg_geno As String, ByVal vg_ender As String, ByVal vg_bair As String, ByVal vg_mun As String, _
                               ByVal vg_cid As String, ByVal vg_uf As String, ByVal vg_cep As String, ByVal vg_fax As String, ByVal vg_insc As String, _
                               ByVal vg_crt As String) As Boolean
        Try
            s.WriteLine("<emit>")
            s.WriteLine("<CNPJ>" & vg_cgc & "</CNPJ>")
            s.WriteLine("<xNome>" & RTrim(vg_geno) & "</xNome>")
            s.WriteLine("<xFant>" & RTrim(vg_geno) & "</xFant>")
            s.WriteLine("<enderEmit>")
            s.WriteLine("<xLgr>" & RTrim(vg_ender) & "</xLgr>")
            s.WriteLine("<nro>.</nro>")
            s.WriteLine("<xBairro>" & RTrim(vg_bair) & "</xBairro>")
            s.WriteLine("<cMun>" & RTrim(vg_mun) & " </cMun>")
            s.WriteLine("<xMun>" & RTrim(vg_cid) & "</xMun>")
            s.WriteLine("<UF>" & vg_uf & "</UF>")
            s.WriteLine("<CEP>" & vg_cep & "</CEP>")
            s.WriteLine("<cPais>1058</cPais>")
            s.WriteLine("<xPais>BRASIL</xPais>")
            s.WriteLine("<fone>" & vg_fax & "</fone>")
            s.WriteLine("</enderEmit>")
            s.WriteLine("<IE>" & RTrim(vg_insc) & "</IE>")
            s.WriteLine("<CRT>" & vg_crt & "</CRT>")
            s.WriteLine("</emit>")

            Return True

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    ' Identificação do Destinatário da Nota Fiscal eletrônica 
    Public Function xmlGrupo_E(ByVal vp_carac As String, ByVal vp_cgc As String, ByVal vp_cpf As String, ByVal vp_portad As String, ByVal vp_end As String, _
                               ByVal vp_bairro As String, ByVal vp_mun As String, ByVal vp_cid As String, ByVal vp_uf As String, ByVal vp_cep As String, ByVal vp_fone As String, _
                               ByVal vp_insc As String, ByVal vp_suframa As String, ByVal vp_email As String) As Boolean

        'obs: Tratar bairro,cpf,telefone

        Try
            s.WriteLine("<dest>")
            If vp_carac = "J" Then
                s.WriteLine("<CNPJ>" & RTrim(vp_cgc) & "</CNPJ>")
            Else
                s.WriteLine("<CPF>" & RTrim(vp_cpf) & "</CPF>")
            End If
            s.WriteLine("<xNome>" & RTrim(vp_portad) & "</xNome>")
            s.WriteLine("<enderDest>")
            s.WriteLine("<xLgr>" & RTrim(vp_end) & "</xLgr>")
            s.WriteLine("<nro>.</nro>")
            s.WriteLine("<xBairro>" & RTrim(vp_bairro) & "</xBairro>")
            s.WriteLine("<cMun>" & vp_mun & "</cMun>")
            s.WriteLine("<xMun>" & RTrim(vp_cid) & "</xMun>")
            s.WriteLine("<UF>" & vp_uf & "</UF>")
            s.WriteLine("<CEP>" & vp_cep & "</CEP>")
            s.WriteLine("<cPais>1058</cPais>")
            s.WriteLine("<xPais>BRASIL</xPais>")
            '************
            If vp_fone <> "" And Len(vp_fone) = 10 Then
                s.WriteLine("<fone>" & Mid(vp_fone, 1, 10) & "</fone>")
            End If
            s.WriteLine("</enderDest>")
            If vp_insc <> "" Then
                s.WriteLine("<IE>" & RTrim(vp_insc) & "</IE>")
            End If
            If vp_suframa <> "" Then
                s.WriteLine("<ISUF>" & vp_suframa & "</ISUF>")
            End If
            If vp_email <> "" Then
                s.WriteLine("<email>" & vp_email & "</email>")
            End If
            s.WriteLine("</dest>")

            Return True

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    ' Dados do Local de Entrega
    Public Function xmlGrupo_G(ByVal vp_carac As String, ByVal vp_cgc As String, ByVal vp_cpf As String, ByVal vp_end As String, _
                               ByVal vp_bairro As String, ByVal vp_mun As String, ByVal vp_cid As String, ByVal vp_uf As String) As Boolean

        'obs: Tratar bairro,cpf,telefone

        Try
            s.WriteLine("<entrega>")
            If vp_carac = "J" Then
                s.WriteLine("<CNPJ>" & RTrim(vp_cgc) & "</CNPJ>")
            Else
                s.WriteLine("<CPF>" & RTrim(vp_cpf) & "</CPF>")
            End If
            s.WriteLine("<xLgr>" & RTrim(vp_end) & "</xLgr>")
            s.WriteLine("<nro>.</nro>")
            s.WriteLine("<xBairro>" & RTrim(vp_bairro) & "</xBairro>")
            s.WriteLine("<cMun>" & vp_mun & "</cMun>")
            s.WriteLine("<xMun>" & RTrim(vp_cid) & "</xMun>")
            s.WriteLine("<UF>" & vp_uf & "</UF>")
            s.WriteLine("</entrega>")

            Return True

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Public Function xmlGrupo_L(ByVal tSeq As Integer, ByVal vnc_codpr As String, ByVal vnc_produt As String, ByVal vnc_produt2 As String, _
                               ByVal vnc_ncm As String, ByVal vnc_cfop As String, ByVal vnc_cst As String, ByVal vnc_CSOSN As String, _
                               ByVal vnc_und As String, ByVal vnc_qtde As Double, ByVal vnc_prunit As Double, ByVal vnc_prtot As Double, _
                               ByVal vnc_desc As Double, ByVal vnc_bcalc As Double, ByVal vnc_basesub As Double, ByVal vnc_vlsubs As Double, _
                               ByVal vnc_alqicm As Double, ByVal vnc_vlicm As Double, ByVal vnc_alqipi As Double, ByVal vnc_vlipi As Double, _
                               ByVal vnc_frete As Double, ByVal vnc_vldesc As Double, ByVal vnc_indtot As Integer, ByVal vnc_cdbarra As String, _
                               ByVal vnc_despac As Double, ByVal vnc_reduz As Double)

        Dim xseq As String
        xseq = RTrim(Str(tSeq))
        s.WriteLine("<det nItem=" & LTrim(xseq) & ">")
        s.WriteLine("<prod>")
        s.WriteLine("<cProd>" & RTrim(vnc_codpr) & "</cProd>")
        s.WriteLine("<cEAN/>")
        If Len(vnc_produt2) = 0 Then
            s.WriteLine("<xProd>" & RTrim(vnc_produt) & "</xProd>")
        Else
            s.WriteLine("<xProd>" & RTrim(vnc_produt) + RTrim(vnc_produt2) & " </xProd>")
        End If
        s.WriteLine("<NCM>" & RTrim(vnc_ncm) & "</NCM>")
        s.WriteLine("<CFOP>" & vnc_cfop & "</CFOP>")
        s.WriteLine("<uCom>" + RTrim(vnc_und) & "</uCom>")
        s.WriteLine("<qCom>" + LTrim(Str(vnc_qtde)) & "</qCom>")
        s.WriteLine("<vUnCom>" & LTrim(Str(vnc_prunit)) & "</vUnCom>")
        s.WriteLine("<vProd>" + LTrim(Str(vnc_prtot)) & "</vProd>")
        If vnc_cdbarra <> "" Then
            s.WriteLine("<cEANTrib>" & vnc_cdbarra & "</cEANTrib>")
            s.WriteLine("<uTrib>" + RTrim(vnc_und) & "</uTrib>")
        End If
        s.WriteLine("<qTrib>" & LTrim(Str(vnc_qtde)) & "</qTrib>")
        If vnc_alqicm = 0.0 Then
            s.WriteLine("<qTrib>0.0000</qTrib>")
        End If
        s.WriteLine("<vUnTrib>" & LTrim(Str(vnc_prunit)) & "</vUnTrib>")
        If vnc_frete > 0 Then
            s.WriteLine("<vFrete>" & LTrim(Str(vnc_frete)) & "</vFrete>")
        End If
        If vnc_desc > 0 Then
            s.WriteLine("<vDesc>" & LTrim(Str(vnc_desc)) & "</vDesc>")
        End If
        If vnc_despac > 0 Then
            s.WriteLine("<vOutro>" & vnc_despac & "/<vOutro>")
        End If
        s.WriteLine("<indTot>" & LTrim(Str(vnc_indtot)) & "</indTot>")
        s.WriteLine("</prod>")

        'If vnc_alqicm >= 1.00 .and. vp_carac =  'J'


        'Produtos Tributados Integralmente
        If vnc_cst = "00" Then

        End If

        ' Tributada e com cobrança do ICMS por substituição tributária
        If vnc_cst = "10" And vnc_vlsubs > 0 Then
            _grupo_L10(vnc_prtot, vnc_bcalc, vnc_alqicm, vnc_vlicm, vnc_basesub, vnc_vlsubs)
        End If

        ' Com redução de base de cálculo 
        If vnc_cst = "20" Then

        End If

        ' Isenta 
        If vnc_cst = "40" Then

        End If

        ' Não tributada 
        If vnc_cst = "41" Then

        End If

        ' ICMS cobrado anteriormente por substituição(tributária)
        If vnc_cst = "60" Then

        End If

        '  Com redução de base de cálculo e cobrança do ICMS por substituição tributária ICMS por 
        '  substituição(tributária)
        If vnc_cst = "70" Then

        End If
        ' Outros
        If vnc_cst = "90" Then

        End If
        Return True
    End Function

    ' Informa Duplicatas no Danfe
    Public Function _grupo_Fat(ByVal Ndup As String, ByVal NVencto As Date, ByVal NValor As Double) As Boolean
        s.WriteLine("<cobr>")
        s.WriteLine("<dup>")
        s.WriteLine("<nDup>" & RTrim(Ndup) & "</nDup>")
        s.WriteLine("<dVenc>" & NVencto & "</dVenc>")
        s.WriteLine("<vDup>" & NValor & "</vDup>")
        s.WriteLine("</dup> ")
        s.WriteLine("</cobr>")
    End Function

#Region "  *  * Rotina de Classificação CST do ICms s/ Produto (Empresa Normal) *  *  "

    Private Function _grupo_L00(ByVal vnc_bcalc As Double, ByVal vnc_alqicm As Double, ByVal vnc_vlicm As Double) As Boolean
        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMS00>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CST>00</CST>")
        s.WriteLine("<modBC>0</modBC>")
        s.WriteLine("<vBC>" & LTrim(Str(vnc_bcalc)) & "</vBC>")
        s.WriteLine("<pICMS>" & LTrim(Str(vnc_alqicm)) & "</pICMS>")
        s.WriteLine("<vICMS>" & LTrim(Str(vnc_vlicm)) & "</vICMS>")
        s.WriteLine("</ICMS00>")
        s.WriteLine("</ICMS>")

        Return True
    End Function

    Private Function _grupo_L10(ByVal vnc_prtot As Double, ByVal vnc_bcalc As Double, ByVal vnc_alqicm As Double, ByVal vnc_vlicm As Double, ByVal vnc_basesub As Double, _
                               ByVal vnc_vlsubs As Double) As Boolean

        Dim mtot As Double

        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMS10>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CST>10</CST>")
        s.WriteLine("<modBC>0</modBC>")
        s.WriteLine("<vBC>" & LTrim(Str(vnc_bcalc)) & "</vBC>")
        s.WriteLine("<pICMS>" & LTrim(Str(vnc_alqicm)) & "</pICMS>")
        s.WriteLine("<vICMS>" & LTrim(Str(vnc_vlicm)) & "</vICMS>")
        mtot = vnc_prtot
        s.WriteLine("<modBCST>0</modBCST>")
        s.WriteLine("<vBCST>" & LTrim(Str(vnc_basesub)) & "</vBCST>")
        s.WriteLine("<pICMSST>0.00</pICMSST>")
        s.WriteLine("<vICMSST>" & LTrim(Str(vnc_vlsubs)) & "</vICMSST>")
        s.WriteLine("</ICMS10>")
        s.WriteLine("</ICMS>")

        Return True
    End Function

    Private Function _grupo_L20(ByVal vnc_reduz As Double, ByVal vnc_bcalc As Double, ByVal vnc_alqicm As Double, _
                                ByVal vnc_vlicm As Double) As Boolean
        '   **** Icms00 - Reducao na Base de Cálculo ****
        'Tributação pelo ICMS - Com redução de base de cálculo
        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMS20>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CST>20</CST>")
        s.WriteLine("<modBC>3</modBC>")
        s.WriteLine("<pRedBC>" & LTrim(Str(vnc_reduz)) & "</pRedBC>")
        s.WriteLine("<vBC>" & LTrim(Str(vnc_bcalc)) & "</vBC>")
        s.WriteLine("<pICMS>" & LTrim(Str(vnc_alqicm)) & "</pICMS>")
        s.WriteLine("<vICMS>" & LTrim(Str(vnc_vlicm)) & "</vICMS>")
        s.WriteLine("</ICMS20>")
        s.WriteLine("</ICMS>")

        Return True
    End Function

    Private Function _grupo_L40() As Boolean
        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMS40>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CST>40</CST>")
        s.WriteLine("</ICMS40>")
        s.WriteLine("</ICMS>")

        Return True
    End Function

    Private Function _grupo_L41() As Boolean
        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMS41>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CST>41</CST>")
        s.WriteLine("</ICMS41>")
        s.WriteLine("</ICMS>")

        Return True
    End Function

    Private Function _grupo_L60(ByVal vnc_bcalc As Double) As Boolean
        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMS60>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CST>60</CST>")
        s.WriteLine("<vBCSTRet>" + LTrim(Str(vnc_bcalc)) & "</vBCSTRet>")
        s.WriteLine("<vICMSSTRet>0.00</vICMSSTRet>")
        s.WriteLine("</ICMS60>")
        s.WriteLine("</ICMS>")
        Return True
    End Function

    Private Function _grupo_L70() As Boolean
        ' Com redução de base de cálculo e cobrança de ICMS por substituição tributária
        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMS70>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CST>70</CST>")
        s.WriteLine("<modBC>3</modBC>")
        s.WriteLine("<pRedBC>10.00</pRedBC>")
        s.WriteLine("<vBC>90.00</vBC>")
        s.WriteLine("<pICMS>18.00</pICMS>")
        s.WriteLine("<vICMS>16.20</vICMS>")
        s.WriteLine("<modBCST>4</modBCST>")
        s.WriteLine("<pMVAST>100.00</pMVAST>")
        s.WriteLine("<pRedBCST>10.00<pRedBCST>")
        s.WriteLine("<vBCST>162.00</vBCST>")
        s.WriteLine("<pICMSST>18.00</pICMSST>")
        s.WriteLine("<vICMSST>12.96</vICMSST>")
        s.WriteLine("</ICMS70>")
        s.WriteLine("</ICMS>")
        Return True
    End Function

    Private Function _grupo_L90(ByVal vnc_reduz As Double, ByVal vnc_bcalc As Double, ByVal vnc_alqicm As Double, ByVal vnc_vlicm As Double, _
                                ByVal vnc_basesub As Double, ByVal vnc_vlsubs As Double) As Boolean
        ' Outras
        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMS90>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CST>90</CST>")
        s.WriteLine("<modBC>3</modBC>")
        If vnc_reduz <> 0 Then
            s.WriteLine("<pRedBC>" & vnc_reduz & "</pRedBC>") ' opcional
        End If
        s.WriteLine("<vBC>" & vnc_bcalc & "</vBC>")
        s.WriteLine("<pICMS>" & vnc_alqicm & "</pICMS>")
        s.WriteLine("<vICMS>" & vnc_vlicm & "</vICMS>")
        s.WriteLine("<modBCST>0</modBCST>")
        's.WriteLine("<pMVAST>100.00</pMVAST>") ' opcional
        If vnc_reduz <> 0 Then
            s.WriteLine("<pRedBCST>" & vnc_reduz & "<pRedBCST>") 'opcional
        End If
        s.WriteLine("<vBCST>" & vnc_basesub & "</vBCST>")
        s.WriteLine("<pICMSST>" & vnc_alqicm & "</pICMSST>")
        s.WriteLine("<vICMSST>" & vnc_vlsubs & "</vICMSST>")
        s.WriteLine("</ICMS90>")
        s.WriteLine("</ICMS>")

        Return True
    End Function

#End Region

#Region "  *  * Rotina de Classificação CST do ICms s/ Produto (Empresa Simples Nacional) *  *  "

    Private Function _grupo_LS102() As Boolean
        '  **** /Icms102 - Produto Trib. p/ Simples Nacional s/ Permissao de Credito
        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMSSN102>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CSOSN>102</CSOSN>")
        s.WriteLine("</ICMSSN102>")
        s.WriteLine("</ICMS>")
        Return True
    End Function

    Private Function _grupo_LS103() As Boolean
        ' Isenção do ICMS  no Simples Nacional para faixa de receita(bruta)
        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMSSN103>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CSOSN>103</CSOSN>")
        s.WriteLine("</ICMSSN103>")
        s.WriteLine("</ICMS>")
        Return True
    End Function

    Private Function _grupo_LS202(ByVal vnc_basesub As Double, ByVal vnc_vlsubs As Double) As Boolean
        '    **** /Icms202 - Produto c/ Tributação c/ Cobranca de Subs Tribut.  ****
        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMSSN202>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CSOSN>202</CSOSN>")
        s.WriteLine("<modBCST>0</modBCST>")
        s.WriteLine("<vBCST>" & LTrim(Str(vnc_basesub)) & "</vBCST>")
        s.WriteLine("<pICMSST>3.40</pICMSST>")
        s.WriteLine("<vICMSST>" & LTrim(Str(vnc_vlsubs)) & "</vICMSST>")
        s.WriteLine("</ICMSSN202>")
        s.WriteLine("</ICMS>")

        Return True
    End Function

    Private Function _grupo_LS400() As Boolean
        ' Não tributada pelo Simples(Nacional)
        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMSSN400>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CSOSN>400</CSOSN>")
        s.WriteLine("</ICMSSN400>")
        s.WriteLine("</ICMS>")
        Return True
    End Function

    Private Function _grupo_LS500(ByVal vnc_bcalc As Double) As Boolean
        '    **** Icms60 - Substituição Tributaria    ****
        s.WriteLine("<imposto>")
        s.WriteLine("<ICMS>")
        s.WriteLine("<ICMSSN500>")
        s.WriteLine("<orig>0</orig>")
        s.WriteLine("<CSOSN>500</CSOSN>")
        s.WriteLine("<vBCSTRet>" & LTrim(Str(vnc_bcalc)) & "</vBCSTRet>")
        s.WriteLine("<vICMSSTRet>0.00</vICMSSTRet>")
        s.WriteLine("</ICMSSN500>")
        s.WriteLine("</ICMS>")
        Return True
    End Function
#End Region

#Region "  *  *  Rotina de IPI - Produtos Industrializados  *  *  "

    Private Function _grupo_IPI(ByVal vnc_bcalc As Double, ByVal vnc_alqipi As Double, ByVal vnc_vlipi As Double) As Boolean
        '   **** IPI - Imposto Sobre Produtos Industrializados ****  
        Dim mbcIpi As Double = 0.0
        mbcIpi = vnc_bcalc
        If vnc_vlipi = 0.0 Then
            mbcIpi = 0.0
        End If
        s.WriteLine("<IPI>")
        s.WriteLine("<cEnq>999</cEnq>")
        s.WriteLine("<IPITrib>")
        s.WriteLine("<CST>50</CST>")
        s.WriteLine("<vBC>" & LTrim(Str(mbcIpi)) & "</vBC>")
        's.WriteLine("<vBC>" & LTrim(Str(0.0)) & "</vBC>")
        s.WriteLine("<pIPI>" & LTrim(Str(vnc_alqipi)) & "</pIPI>")
        s.WriteLine("<vIPI>" & LTrim(Str(vnc_vlipi)) & "</vIPI>")
        s.WriteLine("</IPITrib>")
        s.WriteLine("</IPI>")

        Return True
    End Function

#End Region

#Region " * *  Rotina do PIs e Cofins Tributados/Nao Tributados   *  *  "


    Private Function _grupo_LPC_Trib(ByVal vnc_cstpis As String, ByVal vnc_cstconf As String, ByVal vnc_bcalc As Double, ByVal vgp_pis As Double, _
                                     ByVal vgp_cofin As Double, ByVal vnc_vlpis As Double, ByVal vnc_vlconf As Double) As Boolean
        '        **** PIS - Pis Sobre Faturamento ****
        s.WriteLine("<PIS>")
        s.WriteLine("<PISAliq>")
        s.WriteLine("<CST>" & vnc_cstpis & "</CST>")
        s.WriteLine("<vBC>" & LTrim(Str(vnc_bcalc)) & "</vBC>")
        s.WriteLine("<pPIS>" & LTrim(Str(vgp_pis)) & "</pPIS>")
        s.WriteLine("<vPIS>" & Trim(Str(vnc_vlpis)) & "</vPIS>")
        s.WriteLine("</PISAliq>")
        s.WriteLine("</PIS>")

        '     **** CONFINS - COFINS Sobre Faturamento ****
        s.WriteLine("<COFINS>")
        s.WriteLine("<COFINSAliq>")
        s.WriteLine("<CST>" & vnc_cstconf & "</CST>")
        s.WriteLine("<vBC>" & LTrim(Str(vnc_bcalc)) & "</vBC>")
        s.WriteLine("<pCOFINS>" & LTrim(Str(vgp_cofin)) & "</pCOFINS>")
        s.WriteLine("<vCOFINS>" & LTrim(Str(vnc_vlconf)) & "</vCOFINS>")
        s.WriteLine("</COFINSAliq>")
        s.WriteLine("</COFINS>")
        s.WriteLine("</imposto>")
        s.WriteLine("</det>")

        Return True
    End Function

    Private Function _grupo_LPC_isento(ByVal vnc_cstpis As String, ByVal vnc_cstconf As String) As Boolean
        ' **** PIS - Pis Sobre Faturamento ****
        s.WriteLine("<PIS>")
        s.WriteLine("<PISNT>")
        s.WriteLine("<CST>" & vnc_cstpis & "</CST>")
        s.WriteLine("</PISNT>")
        s.WriteLine("</PIS>")
        '**** CONFINS - COFINS Sobre Faturamento ****
        s.WriteLine("<COFINS>")
        s.WriteLine("<COFINSNT>")
        s.WriteLine("<CST>" & vnc_cstconf & "</CST>")
        s.WriteLine("</COFINSNT>")
        s.WriteLine("</COFINS>")
        s.WriteLine("</imposto>")
        s.WriteLine("</det>")

        Return True
    End Function

#End Region

    Private Function xmlGrupo_W(ByVal vn4_basec As Double, ByVal vn4_icms As Double, ByVal vn4_bsub As Double, ByVal vn4_icsub As Double, _
                                ByVal vn4_tprod As Double, ByVal vn4_frete As Double, ByVal vn4_segu As Double, ByVal vn4_desc As Double, _
                                ByVal vn4_ipi As Double, ByVal vn4_pis As Double, ByVal vn4_cofin As Double, ByVal vn4_outros As Double, _
                                ByVal vn4_tgeral As Double) As Boolean

        '     **** Valores Totais da NFe Tag W ****
        s.WriteLine("<total>")
        s.WriteLine("<ICMSTot>")
        s.WriteLine("<vBC>" & LTrim(Str(vn4_basec)) & "</vBC>")
        s.WriteLine("<vICMS>" & LTrim(Str(vn4_icms)) & "</vICMS>")
        s.WriteLine("<vBCST>" & LTrim(Str(vn4_bsub)) & "</vBCST>")
        s.WriteLine("<vST>" & LTrim(Str(vn4_icsub)) & "</vST>")
        s.WriteLine("<vProd>" & LTrim(Str(vn4_tprod)) & "</vProd>")
        s.WriteLine("<vFrete>" & LTrim(Str(vn4_frete)) & "</vFrete>")
        s.WriteLine("<vSeg>" & LTrim(Str(vn4_segu)) & "</vSeg>")
        s.WriteLine("<vDesc>" & LTrim(Str(vn4_desc)) & "</vDesc>")  '&& vn4_desc
        s.WriteLine("<vII>0</vII>")
        s.WriteLine("<vIPI>" & LTrim(Str(vn4_ipi)) & "</vIPI>")
        s.WriteLine("<vPIS>" & LTrim(Str(vn4_pis)) & "</vPIS>")
        s.WriteLine("<vCOFINS>" & LTrim(Str(vn4_cofin)) & "</vCOFINS>")
        s.WriteLine("<vOutro>" & LTrim(Str(vn4_outros)) & "</vOutro>")
        s.WriteLine("<vNF>" & LTrim(Str(vn4_tgeral)) & "</vNF>")
        s.WriteLine("</ICMSTot>")
        s.WriteLine("</total>")

        Return True
    End Function

    Private Function xmlGrupo_X(ByVal vt_codp As String, ByVal modfret As String, ByVal mp_cpf As String, ByVal mp_cgc As String, ByVal mp_ie As String, _
                                ByVal mp_insc As String, ByVal mp_portad As String, ByVal mp_end As String, ByVal mp_cid As String, ByVal mp_uf As String, _
                                ByVal vt_placa As String, ByVal vt_antt As String, ByVal vt_uf As String, ByVal vt_qtde As Integer, ByVal vt_espec As String, _
                                ByVal vt_marca As String, ByVal vt_pesol As Double, ByVal vt_pesob As Double) As Boolean

        s.WriteLine("<transp>")
        s.WriteLine("<modFrete>" & RTrim(modfret) & "</modFrete>")
        If vt_codp <> "999999" Then
            If mp_cgc <> "" Then
                s.WriteLine("<CNPJ>" & RTrim(mp_cgc) & "</CNPJ>")
            End If
            If mp_cpf <> "" Then
                s.WriteLine("<CPF>" & RTrim(mp_cpf) & "</CPF>")
            End If
            s.WriteLine("<transporta>")
            If mp_insc <> "" Then
                s.WriteLine("<IE>" & RTrim(mp_ie) & "</IE>") ' Opcional
            End If
            s.WriteLine("<xNome>" & RTrim(mp_portad) & "</xNome>")
            s.WriteLine("<xEnder>" & RTrim(mp_end) & "</xEnder>")
            s.WriteLine("<xMun>" & RTrim(mp_cid) & "</xMun>")
            s.WriteLine("<UF>" & LTrim(mp_uf) & "</UF>")
            s.WriteLine("</transporta>")
            s.WriteLine("<veicTransp>")
            s.WriteLine("<placa>" & RTrim(vt_placa) & "</placa>")
            If vt_antt <> "" Then
                s.WriteLine("<RNTC>" & RTrim(vt_antt) & "</RNTC>")  ' Opcional
            End If
            s.WriteLine("<UF>" & RTrim(vt_uf) & "</UF>")
            s.WriteLine("</veicTransp>")
            s.WriteLine("<vol>")
            s.WriteLine("<qVol>" & LTrim(Str(vt_qtde)) & "</qVol>")
            s.WriteLine("<esp>" & RTrim(vt_espec) & "</esp>")
            s.WriteLine("<marca>" & RTrim(vt_marca) & "</marca>")
            s.WriteLine("<pesoL>" & LTrim(Str(vt_pesol)) & "</pesoL>")
            s.WriteLine("<pesoB>" & LTrim(Str(vt_pesob)) & "</pesoB>")
            s.WriteLine("</vol>")
            s.WriteLine("</transp>")
        Else
            s.WriteLine("<vol>")
            s.WriteLine("<qVol>" & LTrim(Str(vt_qtde)) & "</qVol>")
            s.WriteLine("<esp>" & RTrim(vt_espec) & "</esp>")
            If vt_marca <> "" Then
                s.WriteLine("<marca>" & RTrim(vt_marca) & "</marca>")
            End If
            s.WriteLine("<pesoL>" & LTrim(Str(vt_pesol)) & "</pesoL>")
            s.WriteLine("<pesoB>" & LTrim(Str(vt_pesob)) & "</pesoB>")
            s.WriteLine("</vol>")
            s.WriteLine("</transp>")
        End If
        Return True
    End Function

    Private Function xmlGrupo_Z(ByVal vc_compl1 As String, ByVal vc_compl2 As String, ByVal vc_compl3 As String, ByVal vc_compl4 As String, _
                                ByVal vc_compl5 As String, ByVal vc_compl6 As String, ByVal vc_compl8 As String) As Boolean

        s.WriteLine("<infAdic>")
        s.WriteLine("<infCpl>" & RTrim(vc_compl1) & RTrim(vc_compl2) & RTrim(vc_compl3))
        s.WriteLine(RTrim(vc_compl4) & RTrim(vc_compl5) & ";" & RTrim(vc_compl6) & RTrim(vc_compl8) & "</infCpl>")
        s.WriteLine("</infAdic>")

        Return True
    End Function

    Private Sub Frm_NFEAutorizanota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.msk_dtsaida.Text = DateValue(agora)
        Me.cbo_tiponfe.SelectedIndex = 0
        Me.cbo_transportador.SelectedIndex = 0
        vnt_dtemis = DateValue(agora)
        Try
            fsxml = New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
            s = New StreamWriter(fsxml)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Frm_NFEAutorizanota_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            fsxml.Close()
            Me.Close()
        End If
    End Sub

    Private Sub cbo_estabelecimento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.Leave
        Dim oConn As New NpgsqlConnection(conexao)
        Dim oCmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim daCont As New NpgsqlDataAdapter
        Dim Mconsulta As Boolean = False
        ' Estabelecimento Selecionado
        CodEstab = String.Format("{0:D2}", cbo_estabelecimento.SelectedIndex + 1)

        Dim Sqlcomm As StringBuilder = New StringBuilder
        Sqlcomm.Append("SELECT gp_requis, gp_sai, gp_fat, gp_data, gp_icms,") ' 4
        Sqlcomm.Append("gp_icmse, gp_serv,gp_orca, gp_txreduz, gp_icmred,") '9
        Sqlcomm.Append("gp_txcob, gp_txesvei, gp_mensag , gp_serie, gp_amb, gp_contf FROM genp0" & CodEstab.ToString) '15

        daCont = New NpgsqlDataAdapter(Sqlcomm.ToString, oConn)
        oCmd = New NpgsqlCommand(Sqlcomm.ToString, oConn)
        Dim dt As DataTable = New DataTable
        Dim dsCont As DataSet = New DataSet
        Dim mReq, mNum, mFatu, mOrca As String
        mNum = "" : mFatu = "" : mOrca = ""
        Dim mgp_req As Integer
        Dim mgp_num, mgp_fatu, mgp_orca As Integer
        mgp_num = 0 : mgp_fatu = 0 : mgp_orca = 0

        Try
            daCont.Fill(dsCont, "Genp0" & CodEstab.ToString)
            oConn.Open()
            dt.Load(oCmd.ExecuteReader())
            dr = (oCmd.ExecuteReader())
            While dr.Read()
                mReq = dr(0).ToString
                mAmb = dr(14)
                mcontf = dr(15) ' Tipo de Emissão (Normal ou Contigencia )
                mgp_req = Convert.ToInt32(mReq)

            End While
            If mAmb = "1" Then
                Me.lbl_ambiente.Text = "Produção"
            End If
            If mAmb = "2" Then
                Me.lbl_ambiente.Text = "Homologação"
            End If
            If mcontf = "1" Then
                Me.lbl_tipoemissao.Text = "Normal"
            End If
            If mcontf = "3" Then
                Me.lbl_tipoemissao.Text = "Contingência(SCAN)"
            End If
            If mcontf = "4" Then
                Me.lbl_tipoemissao.Text = "Contigência DPEC"
            End If
            oConn.Close()
        Catch ex As NpgsqlException
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try

    End Sub

    Private Sub Frm_NFEAutorizanota_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If _formBusca = False Then
            If e.KeyChar = Convert.ToChar(13) Then
                e.Handled = True
                SendKeys.Send("{TAB}")

            End If
        End If

    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            If Me.txt_codPart.Text.Equals("") Then


                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    _formBusca = True
                    _mPesquisaForn = False
                    _frmREf = Me
                    _BuscaForn.set_frmRef(Me)
                    _BuscaForn.ShowDialog(Me)
                    _formBusca = False
                    If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus()

                    'preenche CBO CFOP...
                    If Not mbUf.Equals("") Then
                        Me.cbo_nfeCfop = PreenchComboCFOP(mbUf, Me.cbo_nfeCfop)
                    End If

                    'Me.cbo_nfcfop.SelectedIndex = -1
                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()

                Catch ex As Exception

                End Try


            End If
        End If
    End Sub

    Private Sub Frm_NFEAutorizanota_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            s.Dispose()
            File.Delete(ArqTemp)
        Catch ex As Exception
        End Try
    End Sub

    Private Function PreenchComboCFOP(ByVal ufFornec As String, ByVal cboCFOP As Object) As ComboBox
        Dim oConnCFOP As NpgsqlConnection = New NpgsqlConnection(cl_BD.conectionPadrao)
        Dim _erro As Boolean = False
        Dim _msgErro As String = ""

        Try
            oConnCFOP.Open()
        Catch ex As Exception
            _erro = True
            _msgErro = "Banco de Dados Inexistente!"
        End Try

        If oConnCFOP.State = ConnectionState.Open Then
            Dim CmdCFOP As New NpgsqlCommand
            Dim SqlCmdCFOP As New StringBuilder
            Dim drCFOP As NpgsqlDataReader
            Dim UF As String  '= "PI" 'essa UF deve ser a da Empresa Adquirente do GENOV
            UF = vg_uf
            Try
                If ufFornec.Equals(UF) Then
                    SqlCmdCFOP.Append("SELECT r_cdfis, r_natureza FROM cadnatu WHERE SUBSTR(r_cdfis, 1, 1) = '5' ORDER BY r_cdfis")
                    CmdCFOP = New NpgsqlCommand(SqlCmdCFOP.ToString, oConnCFOP)
                    drCFOP = CmdCFOP.ExecuteReader
                Else
                    SqlCmdCFOP.Append("SELECT r_cdfis, r_natureza FROM cadnatu WHERE SUBSTR(r_cdfis, 1, 1) = '6' ORDER BY r_cdfis")
                    CmdCFOP = New NpgsqlCommand(SqlCmdCFOP.ToString, oConnCFOP)
                    drCFOP = CmdCFOP.ExecuteReader
                End If

                If drCFOP.HasRows = True Then
                    Dim CFOP As New ArrayList

                    cboCFOP.AutoCompleteCustomSource.Clear()
                    cboCFOP.Items.Clear()
                    cboCFOP.Refresh()
                    While drCFOP.Read
                        CFOP.Add(drCFOP(0).ToString)
                        cboCFOP.AutoCompleteCustomSource.Add(drCFOP(0).ToString & " - " & drCFOP(1).ToString)
                        cboCFOP.Items.Add(drCFOP(0).ToString & " - " & drCFOP(1).ToString)

                    End While

                    cboCFOP.SelectedIndex = -1
                End If

            Catch ex As Exception
                _erro = True
                _msgErro = "Tabela de CFOP Inexistente!"
            End Try

            oConnCFOP.Close()
            CmdCFOP = Nothing
            SqlCmdCFOP = Nothing
            drCFOP = Nothing
        End If

        oConnCFOP = Nothing
        If _erro = True Then
            MsgBox(_msgErro, MsgBoxStyle.Exclamation)
        End If

        Return cboCFOP

    End Function

    Public Function trazIndexCfop(ByVal mCFOP As String, ByVal mCboCFOP As Object) As Integer
        Dim index As Integer
        For index = 0 To mCboCFOP.Items.Count - 1
            If mCFOP.Equals(mCboCFOP.Items.Item(index).ToString.Substring(0, 5)) Then
                Exit For
            End If
        Next

        Return index

    End Function

    Private Sub cbo_nfeCfop_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_nfeCfop.GotFocus
        If Not (Me.cbo_nfeCfop.DroppedDown) Then Me.cbo_nfeCfop.DroppedDown = True
    End Sub

    Private Sub cbo_nfeCfop_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_nfeCfop.KeyDown
        If Me.cbo_nfeCfop.SelectedIndex >= 0 AndAlso e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            If Me.verifCfop(Me.cbo_nfeCfop) Then
                If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
            End If
        ElseIf e.KeyCode = Keys.Down AndAlso Not (Me.cbo_nfeCfop.DroppedDown) Then
            Me.cbo_nfeCfop.DroppedDown = True
        ElseIf (Me.cbo_nfeCfop.DroppedDown) AndAlso e.KeyCode <> Keys.Down AndAlso e.KeyCode <> Keys.Up Then
            Me.cbo_nfeCfop.DroppedDown = False
        End If
    End Sub

    Private Function verifCfop(ByVal cboCFOP As ComboBox) As Boolean

        mNFe_Cfop = Mid(cboCFOP.SelectedItem, 1, 5)
        Try
            If Not mbUf.Equals("") Then
                If mbUf = "PI" Then
                    If Mid(mNFe_Cfop, 1, 1) <> "5" Then
                        MessageBox.Show("CFOP Invalido p/ Dentro do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        cboCFOP.Focus()
                        Return False

                    End If
                End If
                If mbUf <> "PI" Then
                    If Mid(mNFe_Cfop, 1, 1) = "5" Then
                        MessageBox.Show("CFOP Invalido p/ Fora do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        cboCFOP.Focus()
                        Return False

                    End If
                End If
            End If

        Catch ex As Exception
            Return True
        End Try

        Return True
    End Function

    Private Sub cbo_estabelecimento_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.GotFocus
        If Not (Me.cbo_estabelecimento.DroppedDown) Then Me.cbo_estabelecimento.DroppedDown = True
    End Sub

    Private Sub cbo_tiponfe_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tiponfe.GotFocus
        If Not (Me.cbo_tiponfe.DroppedDown) Then Me.cbo_tiponfe.DroppedDown = True
    End Sub

    Private Sub cbo_placa_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_placa.GotFocus
        If Not (Me.cbo_placa.DroppedDown) Then Me.cbo_placa.DroppedDown = True
    End Sub

    Private Sub cbo_transportador_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_transportador.GotFocus
        If Not (Me.cbo_transportador.DroppedDown) Then Me.cbo_transportador.DroppedDown = True
    End Sub

    Private Sub msk_dtsaida_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtsaida.GotFocus
        Me.msk_dtsaida.SelectAll()
    End Sub

    Private Sub btn_nfe_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nfe.Leave

    End Sub

    Private Sub cbo_estabelecimento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.LostFocus
        Dim conn As New Npgsql.NpgsqlConnection(conexao)
        ' instanciando as consultas
        Dim Sqlcom As StringBuilder = New StringBuilder
        Dim comm As NpgsqlCommand = New NpgsqlCommand
        Dim DaGeno As NpgsqlDataAdapter = New NpgsqlDataAdapter(comm)

        CodEstab = String.Format("{0:D2}", cbo_estabelecimento.SelectedIndex + 1)

        Sqlcom.Append("SELECT g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, ") '6
        Sqlcom.Append("g_insc, g_fone, g_fax, g_mun, g_coduf, g_email FROM geno001 ") ' 12
        Sqlcom.Append("where g_codig=" & "'G00" & CodEstab.ToString & "'")

        comm = New NpgsqlCommand(Sqlcom.ToString, conn)
        comm.CommandText = Sqlcom.ToString
        Dim DrGeno As NpgsqlDataReader
        Dim DtGeno As DataTable = New DataTable

        Try
            conn.Open()
            DtGeno.Load(comm.ExecuteReader())
            DrGeno = comm.ExecuteReader()
            While (DrGeno.Read())
                vg_geno = DrGeno(0)
                vg_ender = DrGeno(1)
                vg_cid = DrGeno(2)
                vg_uf = DrGeno(3)
                vg_cep = DrGeno(4)
                vg_bairro = DrGeno(5)
                vg_cnpj = DrGeno(6)
                vg_insc = DrGeno(7)
                vg_fone = DrGeno(8)
                vg_fax = DrGeno(9)
                vg_codmun = DrGeno(10)
                vg_coduf = DrGeno(11)

            End While
            vg_crt = "3"  ' Empresa Nomal=3 , Empresa optante pelo simples =1
            lbl_emitente.Text = vg_geno
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_tiponfe_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tiponfe.Leave
        If cbo_tiponfe.SelectedIndex = 0 Then
            Me.txt_pedido.MaxLength = 8
        End If
    End Sub

    Private Sub txt_codPart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codPart.TextChanged

    End Sub

    Private Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged

    End Sub
End Class