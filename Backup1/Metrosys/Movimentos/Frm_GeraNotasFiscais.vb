﻿Imports System.Drawing.Printing
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Data.DataColumnCollection
Imports System.Data.DataRow
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Threading
Imports Npgsql
Imports GenoNFeXml

Public Class Frm_GeraNotasFiscais

    Public nota1pp As New Cl_Nota1pp
    Public nota2cc As New Cl_Nota2cc
    Public nota4dd As New Cl_Nota4dd
    Public nota6hh As New Cl_Nota6hh
    Public nota5tt As New Cl_Nota5tt

    Public geno001 As New Cl_Geno
    Public genp001 As New Cl_Genp001
    Dim clNFe As New GeraXml
    Dim _clFuncoes As New ClFuncoes
    Dim cl_BD As New Cl_bdMetrosys

    'Forms...
    Dim frmBuscaNome As New Frm_NomeResp
    Dim frmBuscaCnpjCpf As New Frm_CnpjCpfResp
    Dim frmBuscaNumeroNFe As New Frm_numeroNFeResp
    Dim frmBuscaDataPeriodo As New Frm_DataPeriodoResp
    Dim frmMsgRtbox As New Frm_MsgRTBox
    Dim frmCancelamento As Frm_CancelamentoNFe
    Dim formCCe As Frm_NFeCartaCorrecao
    Public Shared frmGeraNFeRef As New Frm_GeraNotasFiscais
    Public Shared _frmREf As New Frm_GeraNotasFiscais

    Public mProtocolo, chaveNFe, mCaminhoRetorno, mCaminhoEviados, AnoMes As String, clickGerar As Boolean = False
    Public mxml As New StringBuilder
    Dim threadNFe As New Generic.List(Of Thread)
    Dim indexContThread As Integer = 0

    'Variaveis de Referencia
    Public nomeRef, cnpjCpfRef, numeroNFeRef As String
    Public dataInicialRef, dataFinalRef As Date

    'Tratamento de Retorno do xml...
    Public xmlArquivo As New StringBuilder
    Public strXmlRetorno As String = "", strArqErroRetorno As String = "", strXmlLoteRecebido As String = "", strXmlProcRec As String = ""
    Public numLotRetorno As String = "", strXmlStatus As String = "", strXmlMotivo As String = "", strXmlProcRecAux As String = ""
    Public strXmlProtocolo As String = "", anoMesPath As String = ""
    Public strXmlRec As String = "", strXmlHora As String = ""
    Public strAux1 As String = "", strAux2 As String = ""
    Public xposinicio, xposfim, xposdif, xposAux As Integer

    Public seqNfe As String = ""

    'XML 
    Private Arqxml As String = "\wged\NFE001.txt"
    Private ArqTemp As String = "\wged\NFE002.txt"
    Private xmlPath As String = "\wged\MyData.xml"
    Private xmlPathImprimir As String = "\wged\imprimeNFe.xml"
    Dim fsxml As FileStream
    Dim s As StreamWriter

    Public Delegate Sub delegando()

    Private Sub Frm_GeraNotasFiscais_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()
            Case Keys.F1
                vizualizaNFe()
            Case Keys.F5
                executaF5()
            Case Keys.F7
                executaF7()
            Case Keys.F10
                executaF10()
            Case Keys.P
                Me.tsb_opcoes.ShowDropDown()
        End Select

    End Sub

    Private Sub vizualizaNFe()

        If dtg_nfe.CurrentRow.IsNewRow Then
            MsgBox("Selecione uma Linha Por Favor !") : Return

        Else

            zeraValoresNota()
            nota1pp.pNt_nume = dtg_nfe.CurrentRow.Cells(1).Value.ToString
            nota1pp.pNt_chave = dtg_nfe.CurrentRow.Cells(5).Value.ToString
            nota1pp.pNt_orca = dtg_nfe.CurrentRow.Cells(8).Value.ToString
            nota1pp.pNt_dtemis = dtg_nfe.CurrentRow.Cells(2).Value.ToString
            anoMesPath = Format(nota1pp.pNt_dtemis, "yyyyMM")
            chaveNFe = nota1pp.pNt_chave
            mProtocolo = ""

            chaveNFe = "" : mProtocolo = "" : mxml.Remove(0, mxml.ToString.Length)
            clickGerar = False


            frmGeraNFeRef = Me
            Dim NFeEdicao As New Frm_NFeOutrasEdicao
            NFeEdicao._edicaoNFe = False
            NFeEdicao._numNFePublic = nota1pp.pNt_nume
            NFeEdicao._chaveNFePublic = nota1pp.pNt_chave
            NFeEdicao.ShowDialog()
            NFeEdicao = Nothing

        End If

    End Sub

    Private Sub btn_nfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nfe.Click

        chaveNFe = "" : mProtocolo = "" : mxml.Remove(0, mxml.ToString.Length)
        clickGerar = False


        frmGeraNFeRef = Me
        Dim NFeAutoriza As New Frm_NFEAutorizanota
        NFeAutoriza.lbl_numeroNota1pp.Text = ""
        NFeAutoriza.ShowDialog()
        NFeAutoriza = Nothing
        executaF5()

        If mProtocolo.Equals("") AndAlso clickGerar Then

            threadNFe.Add(New System.Threading.Thread(AddressOf buscaArquivosGerados))
            threadNFe(indexContThread).Name = "threadxml" & indexContThread
            threadNFe(indexContThread).IsBackground = True
            threadNFe(indexContThread).Start(indexContThread)
            indexContThread += 1

        End If

    End Sub

    Private Sub buscaArquivosGerados(ByVal indiceThread As Integer)

        'Me.lbl_mensagem.Text = "Iniciando Busca dos Arquivos XML..."
        'Me.Refresh()
        strXmlRetorno = ""
        System.Threading.Thread.Sleep(1000)
        strXmlRetorno = _clFuncoes.lerXmlRetorno(chaveNFe, genp001)


        If strXmlRetorno.Equals("") = False Then 'Se retornou nada...

            'Me.lbl_mensagem.Text = "Lendo Lote Recebido..."
            'Me.Refresh()
            'Tratamento do lote recebido...
            strAux1 = "<NumeroLoteGerado>"
            strAux2 = "</NumeroLoteGerado>"
            xposinicio = strXmlRetorno.IndexOf("<NumeroLoteGerado>") : xposfim = strXmlRetorno.IndexOf("</NumeroLoteGerado>")
            xposdif = (xposfim - xposinicio) - strAux1.Length
            Try
                numLotRetorno = CInt(Mid(strXmlRetorno, xposinicio + strAux2.Length, xposdif))
                numLotRetorno = String.Format("{0:D15}", CInt(numLotRetorno))
            Catch ex As Exception
            End Try

            System.Threading.Thread.Sleep(500)
            strXmlLoteRecebido = _clFuncoes.lerXmlLoteRecebido(numLotRetorno, genp001)

            If strXmlLoteRecebido.Equals("") = False Then ' se ele vinher alguma coisa


                strAux1 = "<cStat>"
                strAux2 = "</cStat>"
                xposinicio = strXmlLoteRecebido.IndexOf("<cStat>") : xposfim = strXmlLoteRecebido.IndexOf("</cStat>")
                xposdif = (xposfim - xposinicio) - strAux1.Length
                Try
                    strXmlStatus = Mid(strXmlLoteRecebido, xposinicio + strAux2.Length, xposdif)

                    strAux1 = "<xMotivo>"
                    strAux2 = "</xMotivo>"
                    xposinicio = strXmlLoteRecebido.IndexOf("<xMotivo>") : xposfim = strXmlLoteRecebido.IndexOf("</xMotivo>")
                    xposdif = (xposfim - xposinicio) - strAux1.Length
                    strXmlMotivo = Mid(strXmlLoteRecebido, xposinicio + strAux2.Length, xposdif)

                    strAux1 = "<nRec>"
                    strAux2 = "</nRec>"
                    xposinicio = strXmlLoteRecebido.IndexOf("<nRec>") : xposfim = strXmlLoteRecebido.IndexOf("</nRec>")
                    xposdif = (xposfim - xposinicio) - strAux1.Length
                    strXmlRec = Mid(strXmlLoteRecebido, xposinicio + strAux2.Length, xposdif)

                    Try

                        'Me.lbl_mensagem.Text = "Lendo Recibo Processado..."
                        'Me.Refresh()
                        'Lendo o Arquivo de Recibo processado...
                        System.Threading.Thread.Sleep(500) '1 segundo...
                        strXmlProcRec = _clFuncoes.lerXmlProRec(strXmlRec, genp001)
                        xposAux = strXmlProcRec.IndexOf("</cStat>") + 10
                        strXmlProcRecAux = strXmlProcRec.Substring(xposAux)
                        strAux1 = "<cStat>"
                        strAux2 = "</cStat>"
                        xposinicio = strXmlProcRecAux.IndexOf("<cStat>") : xposfim = strXmlProcRecAux.IndexOf("</cStat>")
                        xposdif = (xposfim - xposinicio) - strAux1.Length
                        strXmlStatus = Mid(strXmlProcRecAux, xposinicio + strAux2.Length, xposdif)


                        strAux1 = "<dhRecbto>"
                        strAux2 = "</dhRecbto>"
                        xposinicio = strXmlProcRec.IndexOf("<dhRecbto>") : xposfim = strXmlProcRec.IndexOf("</dhRecbto>")
                        xposdif = (xposfim - xposinicio) - strAux1.Length
                        strXmlHora = Mid(strXmlProcRec, xposinicio + strAux2.Length, xposdif)

                        strAux1 = "<nProt>"
                        strAux2 = "</nProt>"
                        xposinicio = strXmlProcRec.IndexOf("<nProt>") : xposfim = strXmlProcRec.IndexOf("</nProt>")
                        xposdif = (xposfim - xposinicio) - strAux1.Length
                        strXmlProtocolo = Mid(strXmlProcRec, xposinicio + strAux2.Length, xposdif)
                    Catch ex As Exception
                    End Try

                    'Me.lbl_mensagem.Text = "Gravando Protocolo..."
                    'Me.Refresh()

                    cl_BD.altWebrecNota1pp(nota1pp.pNt_nume, strXmlRec, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altHrwebNota1pp(nota1pp.pNt_nume, strXmlHora, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altLoteNota1pp(nota1pp.pNt_nume, numLotRetorno, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altProtoNota1pp(nota1pp.pNt_nume, strXmlProtocolo, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    If strXmlStatus.Equals("100") Then
                        cl_BD.altStatusNota1pp(nota1pp.pNt_nume, strXmlStatus, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    End If

                    System.Threading.Thread.Sleep(500) '1 segundo...
                    xmlArquivo.Remove(0, xmlArquivo.ToString.Length)
                    xmlArquivo.Append(_clFuncoes.lerXmlEnviado(anoMesPath, chaveNFe, genp001))
                    cl_BD.altXmlNota1pp(nota1pp.pNt_nume, xmlArquivo, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)

                    Dim d As New delegando(AddressOf executaF5)
                    Me.Invoke(d)
                Catch ex As Exception
                    MsgBox("Erro: " & ex.Message)
                End Try


            Else

                'Me.lbl_mensagem.Text = "Erro no Lote Recebido... "
                'Me.Refresh()
                strXmlLoteRecebido = _clFuncoes.lerXmlLoteRecebidoErro(numLotRetorno, genp001)

            End If

        End If


        Try
            'Destroi a Thread
            If threadNFe(indiceThread).IsAlive Then threadNFe(indiceThread).Abort()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub executaF5()
        lbl_mensagem.Text = ""
        preecheDtgNFe()
    End Sub

    Private Function existThreadExecutando() As Boolean
        Dim exist As Boolean = False

        For index As Integer = 0 To indexContThread

            Try
                'Destroi a Thread
                If threadNFe(index).IsAlive Then exist = True : Exit For
            Catch ex As Exception
            End Try
        Next

        Return exist
    End Function

    Private Sub executaF7()


        If dtg_nfe.CurrentRow.IsNewRow Then MsgBox("Selecione um Registro para Atualizar o Protocolo, Por Favor!") : Return
        nota1pp.pNt_nume = Me.dtg_nfe.CurrentRow.Cells(1).Value.ToString
        chaveNFe = Me.dtg_nfe.CurrentRow.Cells(5).Value.ToString
        mProtocolo = Me.dtg_nfe.CurrentRow.Cells(6).Value.ToString

        If mProtocolo.Equals("") Then

            trazGenp001()
            threadNFe.Add(New System.Threading.Thread(AddressOf buscaArquivosGerados))
            threadNFe(indexContThread).Name = "threadxml" & indexContThread
            threadNFe(indexContThread).IsBackground = True
            threadNFe(indexContThread).Start(indexContThread)
            indexContThread += 1

        End If


    End Sub

    Private Sub executaF10()

        If verificaAutoriza() Then

            nota1pp.pNt_nume = dtg_nfe.CurrentRow.Cells(1).Value.ToString
            nota1pp.pNt_dtemis = dtg_nfe.CurrentRow.Cells(2).Value.ToString
            nota1pp.pNt_chave = dtg_nfe.CurrentRow.Cells(5).Value.ToString
            nota1pp.pNt_proto = dtg_nfe.CurrentRow.Cells(6).Value.ToString
            chaveNFe = nota1pp.pNt_chave

            If trazXmlDoBancoOK(nota1pp.pNt_nume) Then

                trazGeno001()
                trazGenp001()

                Try
                    anoMesPath = Format(nota1pp.pNt_dtemis, "yyyyMM")
                    fsxml = New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
                    s = New StreamWriter(fsxml)
                    s.WriteLine(mxml.ToString)
                    s.Close()
                    fsxml.Close()

                    
                    Try
                        xmlPath = MdlEmpresaUsu.genp001.pathEnvioXML & "\" & nota1pp.pNt_chave & "-nfe.xml"
                        File.Copy(ArqTemp, xmlPath, True)
                        System.Threading.Thread.Sleep(1000)
                        buscaArquivosXML()
                    Catch ex As Exception
                    End Try

                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message)
                    fsxml = Nothing : s = Nothing
                End Try
            End If
            

        End If

    End Sub

    Private Sub btn_nfeMapa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nfeMapa.Click

        Dim NFeMapas As New Frm_NFEGeraMapa
        NFeMapas.ShowDialog()

    End Sub

    Private Sub Frm_GeraNotasFiscais_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        preecheDtgNFe()

    End Sub

    Private Sub preecheDtgNFe()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim cmd As NpgsqlCommand
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao abrir conexão:: " & ex.Message) : Return
        End Try

        Try

            Sqlcomm.Append("SELECT n1.nt_id, n1.tipo_nt, n1.nt_nume AS ""Numero"", n1.nt_dtemis AS ""Emissão"", n1.nt_codig AS ""Codigo"", cad.p_portad AS ""Cliente"", ") '5
            Sqlcomm.Append("cad.p_cid AS ""Cidade"", cad.p_uf AS ""UF"", n1.nt_cnpj, n1.nt_chave, n1.nt_proto, n1.nt_seqcce, n1.nt_orca ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".nota1pp n1, cadp001 cad WHERE n1.nt_codig = cad.p_cod AND n1.nt_dtemis = CURRENT_DATE ORDER BY n1.nt_nume DESC, n1.nt_dtemis ASC")
            'Sqlcomm.Append("desc limit 34")

            cmd = New NpgsqlCommand(Sqlcomm.ToString, conn)
            dr = cmd.ExecuteReader

            Me.dtg_nfe.Rows.Clear() : Me.dtg_nfe.Refresh()
            While dr.Read

                dtg_nfe.Rows.Add(dr(1).ToString, dr(2).ToString, Format(CDate(dr(3)), "dd/MM/yyyy"), _
                                     dr(8).ToString, dr(5).ToString, dr(9).ToString, dr(10).ToString, dr(11), dr(12).ToString) '8
            End While
            dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length) : cmd.CommandText = "" : conn.ClearAllPools()
            conn.Close() : dr = Nothing : Sqlcomm = Nothing : cmd = Nothing : conn = Nothing
            Me.dtg_nfe.Refresh()
        Catch ex As Exception
            MsgBox("ERRO na consulta:: " & ex.Message) : Return
        End Try


    End Sub

    Private Sub preecheDtgNFeBusca(ByVal tipoBusca As String)

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim cmd As NpgsqlCommand
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao abrir conexão:: " & ex.Message) : Return
        End Try

        Try

            Sqlcomm.Append("SELECT n1.nt_id, n1.tipo_nt, n1.nt_nume AS ""Numero"", n1.nt_dtemis AS ""Emissão"", n1.nt_codig AS ""Codigo"", cad.p_portad AS ""Cliente"", ") '5
            Sqlcomm.Append("cad.p_cid AS ""Cidade"", cad.p_uf AS ""UF"", n1.nt_cnpj, n1.nt_chave, n1.nt_proto, n1.nt_seqcce, n1.nt_orca ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".nota1pp n1, cadp001 cad WHERE n1.nt_codig = cad.p_cod ")

            Select Case tipoBusca
                Case "nome"
                    Sqlcomm.Append("AND cad.p_portad LIKE @p_portad ")
                    Sqlcomm.Append("ORDER BY n1.nt_nume DESC, n1.nt_dtemis ASC")
                Case "numero"
                    Sqlcomm.Append("AND n1.nt_nume = @nt_nume ")
                    Sqlcomm.Append("ORDER BY n1.nt_nume DESC, n1.nt_dtemis ASC")
                Case "cnpjcpf"
                    Sqlcomm.Append("AND cad.p_cgc = @p_cnpjcpf OR cad.p_cpf = @p_cnpjcpf ")
                    Sqlcomm.Append("ORDER BY n1.nt_nume DESC, n1.nt_dtemis ASC")
                Case "data"
                    Sqlcomm.Append("AND n1.nt_dtemis BETWEEN @dtinical AND @dtfinal ")
                    Sqlcomm.Append("ORDER BY n1.nt_dtemis ASC")
            End Select

            'Sqlcomm.Append("desc limit 34")

            cmd = New NpgsqlCommand(Sqlcomm.ToString, conn)

            Select Case tipoBusca
                Case "nome"
                    cmd.Parameters.Add("@p_portad", nomeRef & "%")
                Case "numero"
                    cmd.Parameters.Add("@nt_nume", numeroNFeRef)
                Case "cnpjcpf"
                    cmd.Parameters.Add("@p_cnpjcpf", cnpjCpfRef)
                Case "data"
                    cmd.Parameters.Add("@dtinical", dataInicialRef)
                    cmd.Parameters.Add("@dtfinal", dataFinalRef)
            End Select

            dr = cmd.ExecuteReader

            Me.dtg_nfe.Rows.Clear() : Me.dtg_nfe.Refresh()
            While dr.Read

                dtg_nfe.Rows.Add(dr(1).ToString, dr(2).ToString, Format(CDate(dr(3)), "dd/MM/yyyy"), _
                                     dr(8).ToString, dr(5).ToString, dr(9).ToString, dr(10).ToString, dr(11), dr(12).ToString) '8
            End While
            dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length) : cmd.CommandText = "" : conn.ClearAllPools()
            conn.Close() : dr = Nothing : Sqlcomm = Nothing : cmd = Nothing : conn = Nothing
            Me.dtg_nfe.Refresh()
        Catch ex As Exception
            MsgBox("ERRO na consulta:: " & ex.Message) : Return
        End Try


    End Sub

    Private Function validaNFeCancelamento() As Boolean

        lbl_mensagem.Text = ""
        If Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("C") Then
            MsgBox("Tipo ""C"" - Nota Já Foi Cancelada !") : Return False
        ElseIf Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("D") Then
            MsgBox("Tipo ""D"" - Nota Denegada não pode ser Cancelada !") : Return False
        ElseIf Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("I") Then
            MsgBox("Tipo ""I"" - Nota Inutilizada não pode ser Cancelada !") : Return False
        End If

        Return True
    End Function

    Private Function validaNFeCCe() As Boolean

        lbl_mensagem.Text = ""
        If Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("C") Then
            MsgBox("Tipo ""C"" - Nota Cancelada não pode se Corrigida !") : Return False
        ElseIf Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("D") Then
            MsgBox("Tipo ""D"" - Nota Denegada não pode ser Corrigida !") : Return False
        ElseIf Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("I") Then
            MsgBox("Tipo ""I"" - Nota Inutilizada não pode ser Corrigida !") : Return False
        End If

        Return True
    End Function

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        lbl_mensagem.Text = ""
        If Me.dtg_nfe.CurrentRow.IsNewRow = False Then

            If validaNFeCancelamento() Then

                Try

                    trazGenp001()
                    trazGeno001()
                    Dim seqNFeInt As Int64 = 0
                    nota1pp.pNt_nume = Me.dtg_nfe.CurrentRow.Cells(1).Value.ToString
                    nota1pp.pNt_chave = Me.dtg_nfe.CurrentRow.Cells(5).Value.ToString
                    nota1pp.pNt_proto = Me.dtg_nfe.CurrentRow.Cells(6).Value.ToString

                    seqNFeInt = Convert.ToInt64(_clFuncoes.trazVlrColunaGenp001(genp001.pGeno, "gp_seqnfe", MdlConexaoBD.conectionPadrao))
                    seqNfe = String.Format("{0:D15}", seqNFeInt)
                    seqNFeInt += 1
                    cl_BD.altGp_SeqNFeGenp001(String.Format("{0:D9}", seqNFeInt), geno001.pCodig, MdlConexaoBD.conectionPadrao)

                    frmCancelamento = New Frm_CancelamentoNFe
                    frmCancelamento.setFrmGeraNotasFiscais(Me)
                    frmCancelamento.ShowDialog()
                    executaF5()
                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
                End Try

            End If

        Else
            MsgBox("Selecione uma NFe para Cancelar")
        End If

    End Sub

    Private Sub trazGeno001()

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearAllPools() : conection = Nothing : Return

        End Try

        Dim cmdGeno As New NpgsqlCommand
        Dim sqlGeno As New StringBuilder
        Dim drGeno As NpgsqlDataReader


        Try


            sqlGeno.Append("SELECT g_codig, g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, ") '7
            sqlGeno.Append("g_insc, g_fone, g_fax, g_mun, g_coduf, g_email, g_razaosocial, ") '14
            sqlGeno.Append("g_loja, g_cnae, g_crt, g_vinculo, g_esquemaestab, g_esquemavinc, g_retencao, ") '21
            sqlGeno.Append("g_pis, g_cofins, g_csll, g_irenda, g_sn ") '26
            sqlGeno.Append("FROM geno001 WHERE g_codig = '" & MdlEmpresaUsu._codigo & "'") '24

            cmdGeno = New NpgsqlCommand(sqlGeno.ToString, conection)
            drGeno = cmdGeno.ExecuteReader

            While drGeno.Read

                geno001.pCodig = drGeno(0).ToString : geno001.pGeno = drGeno(1).ToString
                geno001.pEnder = drGeno(2).ToString : geno001.pCid = drGeno(3).ToString
                geno001.pUf = drGeno(4).ToString : geno001.pCep = drGeno(5).ToString
                geno001.pBair = drGeno(6).ToString : geno001.pCgc = drGeno(7).ToString
                geno001.pInsc = drGeno(8).ToString : geno001.pFone = drGeno(9).ToString
                geno001.pFax = drGeno(10).ToString : geno001.pMun = drGeno(11).ToString
                geno001.pCoduf = drGeno(12).ToString : geno001.pEmail = drGeno(13).ToString
                geno001.pRazaosocial = drGeno(14).ToString : geno001.pRetencao = drGeno(21)
                geno001.pMun = drGeno(11).ToString : geno001.pCnae = drGeno(16).ToString
                geno001.pCrt = drGeno(17).ToString : geno001.pVinculo = drGeno(18).ToString
                geno001.pEsquemaestab = drGeno(19).ToString : geno001.pEsquemavinc = drGeno(20).ToString
                geno001.pPis = drGeno(22) : geno001.pCofins = drGeno(23)
                geno001.pCsll = drGeno(24) : geno001.pIRenda = drGeno(25)
                geno001.pSn = drGeno(26)

            End While

            drGeno.Close() : conection.ClearPool() : conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        cmdGeno.CommandText = "" : sqlGeno.Remove(0, sqlGeno.ToString.Length)
        conection = Nothing : cmdGeno = Nothing : drGeno = Nothing : sqlGeno = Nothing




    End Sub

    Private Sub trazGenp001()

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearAllPools() : conection = Nothing : Return

        End Try

        Dim cmdGenp As New NpgsqlCommand
        Dim sqlGenp As New StringBuilder
        Dim drGenp As NpgsqlDataReader


        Try

            sqlGenp.Append("SELECT gp_requis, gp_sai, gp_fat, gp_data, gp_icms, gp_icmse, gp_alqiss, ") '6
            sqlGenp.Append("gp_serv, gp_orca, gp_palm, gp_txreduz, gp_icmred, gp_txcob, gp_txipi, ") '13
            sqlGenp.Append("gp_txga, gp_txesvei, gp_serie, gp_contf, gp_amb, gp_prazo, gp_seqnfe, ") '20
            sqlGenp.Append("gp_mensag, gp_pis, gp_confin, gp_alqsub, gp_carencia, gp_codprod, ") '26
            sqlGenp.Append("gp_codrequis, gp_codmapa, gp_numpedidomp, gp_mapapedido, gp_canc_pedauto, ") '31
            sqlGenp.Append("gp_grade, gp_codreqproc, gp_tipocondpagto, gp_cpfvalidar, gp_tptransfentrada, ") '36
            sqlGenp.Append("gp_tptransfsaida, gp_comisavista, gp_comisaprazo, gp_envioxml, gp_lotxml, ") '41
            sqlGenp.Append("gp_retornoxml, gp_enviadoxml  FROM genp001 WHERE gp_geno = @gp_geno")

            cmdGenp = New NpgsqlCommand(sqlGenp.ToString, conection)
            cmdGenp.Parameters.Add("@gp_geno", MdlEmpresaUsu._codigo)
            drGenp = cmdGenp.ExecuteReader


            While drGenp.Read

                geno001.zeraValores()
                genp001.pGeno = MdlEmpresaUsu._codigo
                genp001.pRequis = drGenp(0).ToString : genp001.pSai = drGenp(1).ToString
                genp001.pFat = drGenp(2).ToString
                Try
                    genp001.pData = CDate(drGenp(3).ToString)
                Catch ex As Exception
                    genp001.pData = Nothing
                End Try
                genp001.pIcms = drGenp(4).ToString : genp001.pIcmse = drGenp(5).ToString
                genp001.pAlqiss = drGenp(6).ToString : genp001.pServ = drGenp(7).ToString
                genp001.pOrca = drGenp(8).ToString : genp001.pPalm = drGenp(9).ToString
                genp001.pTxreduz = drGenp(10).ToString : genp001.pIcmred = drGenp(11).ToString
                genp001.pTxcob = drGenp(12).ToString : genp001.pTxipi = drGenp(13).ToString
                genp001.pTxga = drGenp(14).ToString : genp001.pTxesvei = drGenp(15).ToString
                genp001.pSerie = drGenp(16).ToString : genp001.pContf = drGenp(17).ToString
                genp001.pAmb = drGenp(18).ToString : genp001.pPrazo = drGenp(19).ToString
                genp001.pSeqnfe = drGenp(20).ToString : genp001.pMensag = drGenp(21).ToString
                genp001.pPis = drGenp(22).ToString : genp001.pConfin = drGenp(23).ToString
                genp001.pAlqsub = drGenp(24).ToString : genp001.pCarencia = drGenp(25).ToString
                genp001.pCodprod = drGenp(26).ToString : genp001.pCodrequis = drGenp(27).ToString
                genp001.pCodmapa = drGenp(28).ToString : genp001.pNumpedidomp = drGenp(29).ToString
                genp001.pMapapedido = drGenp(30).ToString : genp001.pCanc_pedauto = drGenp(31).ToString
                genp001.pTipocondpagto = drGenp(34).ToString : genp001.pConfirmCPF = drGenp(35)
                genp001.pTptransfentrada = drGenp(36).ToString : genp001.pTptransfsaida = drGenp(37).ToString
                genp001.pComisavista = drGenp(38) : genp001.pComisaprazo = drGenp(39)

                genp001.pathEnvioXML = drGenp(40).ToString
                genp001.pathLotXML = drGenp(41).ToString
                genp001.pathRetornoXML = drGenp(42).ToString
                genp001.pathEnviadoXML = drGenp(43).ToString

            End While


            drGenp.Close() : conection.ClearPool() : conection.Close()
        Catch ex As Exception

            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
            geno001.zeraValores()

        End Try

        cmdGenp.CommandText = "" : sqlGenp.Remove(0, sqlGenp.ToString.Length)
        conection = Nothing : cmdGenp = Nothing : drGenp = Nothing : sqlGenp = Nothing




    End Sub

    Private Sub Frm_GeraNotasFiscais_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        For index As Integer = 0 To indexContThread

            Try
                'Destroi a Thread
                If threadNFe(index).IsAlive Then threadNFe(index).Abort()
            Catch ex As Exception
            End Try
        Next

    End Sub

    Private Sub btn_nfeOutras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nfeOutras.Click

        Dim nfeOutras As New Frm_NFEOutras
        nfeOutras.ShowDialog()
        nfeOutras.Dispose()

        executaF5()

    End Sub

    Private Sub btn_cce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cce.Click


        lbl_mensagem.Text = ""
        If Me.dtg_nfe.CurrentRow.IsNewRow = False Then

            If validaNFeCCe() Then

                Try

                    trazGenp001()
                    trazGeno001()
                    Dim seqNFeInt As Int64 = 0
                    nota1pp.pNt_nume = Me.dtg_nfe.CurrentRow.Cells(1).Value.ToString
                    nota1pp.pNt_chave = Me.dtg_nfe.CurrentRow.Cells(5).Value.ToString
                    nota1pp.pNt_proto = Me.dtg_nfe.CurrentRow.Cells(6).Value.ToString
                    nota1pp.pNt_seqCCe = Me.dtg_nfe.CurrentRow.Cells(7).Value

                    seqNFeInt = Convert.ToInt64(_clFuncoes.trazVlrColunaGenp001(genp001.pGeno, "gp_seqnfe", MdlConexaoBD.conectionPadrao))
                    seqNfe = String.Format("{0:D15}", seqNFeInt)
                    seqNFeInt += 1
                    cl_BD.altGp_SeqNFeGenp001(String.Format("{0:D9}", seqNFeInt), geno001.pCodig, MdlConexaoBD.conectionPadrao)

                    formCCe = New Frm_NFeCartaCorrecao
                    formCCe.setFrmGeraNotasFiscais(Me)
                    formCCe.ShowDialog()
                    formCCe.Dispose()

                    executaF5()
                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
                End Try

            End If

        Else
            MsgBox("Selecione uma NFe para Carta de Correção !")
        End If

        

    End Sub

    Private Function validaGeraDanfe() As Boolean

        lbl_mensagem.Text = ""
        If dtg_nfe.CurrentRow.IsNewRow Then

            MsgBox("Selecione uma Linha Por Favor !") : Return False

        Else

            If Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("C") Then
                MsgBox("Tipo ""C"" - Nota Cancelada não pode ser Gerado o Danfe !") : Return False
            ElseIf Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("D") Then
                MsgBox("Tipo ""D"" - Nota Denegada não pode ser Gerado o Danfe !") : Return False
            ElseIf Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("I") Then
                MsgBox("Tipo ""I"" - Nota Inutilizada não pode ser Gerado o Danfe !") : Return False
            ElseIf Me.dtg_nfe.CurrentRow.Cells(6).Value.ToString.Equals("") = False Then
                MsgBox("Nota já foi gerada com sucesso clicke em ""Imprimir"" !") : Return False
            End If

        End If
        

        Return True
    End Function

    Private Sub btn_geraDanfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_geraDanfe.Click

        'FUNÇÂO:
        'Aqui tem Autorizar novamente a NFe com o XML do Banco de Dados
        If validaGeraDanfe() Then

            zeraValoresNota()
            nota1pp.pNt_nume = dtg_nfe.CurrentRow.Cells(1).Value.ToString
            nota1pp.pNt_chave = dtg_nfe.CurrentRow.Cells(5).Value.ToString
            nota1pp.pNt_orca = dtg_nfe.CurrentRow.Cells(8).Value.ToString
            nota1pp.pNt_dtemis = dtg_nfe.CurrentRow.Cells(2).Value.ToString
            anoMesPath = Format(nota1pp.pNt_dtemis, "yyyyMM")
            chaveNFe = nota1pp.pNt_chave
            mProtocolo = ""


            If nota1pp.pNt_chave.Equals("") = False Then

                If trazXmlDoBancoOK(nota1pp.pNt_nume) AndAlso (mxml.ToString.Equals("") = False) Then

                    trazGeno001()
                    trazGenp001()

                    Try
                        fsxml = New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
                        s = New StreamWriter(fsxml)

                        s.WriteLine(mxml.ToString)
                        s.Close()
                        fsxml.Close()

                        Try
                            xmlPath = genp001.pathEnvioXML & "\" & nota1pp.pNt_chave & "-nfe.xml"
                            File.Copy(ArqTemp, xmlPath, True)
                        Catch ex As Exception
                            MsgBox("ERRO ao copiar o XML para """ & xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
                        End Try

                        buscaArquivosXML()
                        executaF5()


                        If mProtocolo.Equals("") Then

                            threadNFe.Add(New System.Threading.Thread(AddressOf buscaArquivosGerados))
                            threadNFe(indexContThread).Name = "threadxml" & indexContThread
                            threadNFe(indexContThread).IsBackground = True
                            threadNFe(indexContThread).Start(indexContThread)
                            indexContThread += 1

                        End If

                    Catch ex As Exception
                        lbl_mensagem.Text = "ERRO:: " & ex.Message
                        Me.Refresh()
                        fsxml = Nothing : s = Nothing
                    End Try


                End If

            End If
            
        End If

    End Sub

    Private Sub zeraValoresNota()

        nota1pp.zeraValores()
        nota2cc.zeraValores()
        nota4dd.zeraValores()
        nota5tt.zeraValores()
        nota6hh.zeraValores()

    End Sub

    Public Function trazXmlDoBancoOK(ByVal numeroNFe As String) As Boolean

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearAllPools() : conection = Nothing : Return False

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader


        Try


            sql.Append("SELECT nt_xml FROM " & MdlEmpresaUsu._esqEstab & ".nota1pp WHERE nt_nume = '" & numeroNFe & "'")

            cmd = New NpgsqlCommand(sql.ToString, conection)
            dr = cmd.ExecuteReader
            mxml.Remove(0, mxml.ToString.Length)

            While dr.Read

                mxml.Append(dr(0).ToString)

            End While

            dr.Close() : conection.ClearPool() : conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        cmd.CommandText = "" : sql.Remove(0, sql.ToString.Length)
        conection = Nothing : cmd = Nothing : dr = Nothing : sql = Nothing



        Return True
    End Function

    Private Sub buscaArquivosXML()


        Me.lbl_mensagem.Text = "Iniciando Validação da NFe..."
        Me.Refresh()
        System.Threading.Thread.Sleep(2000)
        strXmlRetorno = _clFuncoes.lerXmlRetorno(chaveNFe, genp001)


        If strXmlRetorno.Equals("") Then 'Se retornou nada...
            System.Threading.Thread.Sleep(500)
            strArqErroRetorno = ""
            strArqErroRetorno = _clFuncoes.lerArqErroRetorno(chaveNFe, genp001)

            If strArqErroRetorno.Equals("") Then


            End If
            frmMsgRtbox.rtb_mensagem.Text = strArqErroRetorno
            frmMsgRtbox.ShowDialog()
        Else


            'Tratamento do lote recebido...
            strAux1 = "<NumeroLoteGerado>"
            strAux2 = "</NumeroLoteGerado>"
            xposinicio = strXmlRetorno.IndexOf("<NumeroLoteGerado>") : xposfim = strXmlRetorno.IndexOf("</NumeroLoteGerado>")
            xposdif = (xposfim - xposinicio) - strAux1.Length
            Try
                numLotRetorno = CInt(Mid(strXmlRetorno, xposinicio + strAux2.Length, xposdif))
                numLotRetorno = String.Format("{0:D15}", CInt(numLotRetorno))
            Catch ex As Exception
                MsgBox("ERRO ao Ler Xml Retorno """ & xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
                Return
            End Try


            Me.lbl_mensagem.Text = "Lendo o Lote de Recibo... !"
            Me.Refresh()
            System.Threading.Thread.Sleep(1000)
            strXmlLoteRecebido = _clFuncoes.lerXmlLoteRecebido(numLotRetorno, genp001)

            If strXmlLoteRecebido.Equals("") = False Then ' se ele vinher alguma coisa


                strAux1 = "<cStat>"
                strAux2 = "</cStat>"
                xposinicio = strXmlLoteRecebido.IndexOf("<cStat>") : xposfim = strXmlLoteRecebido.IndexOf("</cStat>")
                xposdif = (xposfim - xposinicio) - strAux1.Length
                Try
                    strXmlStatus = Mid(strXmlLoteRecebido, xposinicio + strAux2.Length, xposdif)

                    strAux1 = "<xMotivo>"
                    strAux2 = "</xMotivo>"
                    xposinicio = strXmlLoteRecebido.IndexOf("<xMotivo>") : xposfim = strXmlLoteRecebido.IndexOf("</xMotivo>")
                    xposdif = (xposfim - xposinicio) - strAux1.Length
                    strXmlMotivo = Mid(strXmlLoteRecebido, xposinicio + strAux2.Length, xposdif)

                    Me.lbl_mensagem.Text = strXmlStatus & " - " & strXmlMotivo & " !"
                    Me.Refresh()


                    strAux1 = "<nRec>"
                    strAux2 = "</nRec>"
                    xposinicio = strXmlLoteRecebido.IndexOf("<nRec>") : xposfim = strXmlLoteRecebido.IndexOf("</nRec>")
                    xposdif = (xposfim - xposinicio) - strAux1.Length
                    strXmlRec = Mid(strXmlLoteRecebido, xposinicio + strAux2.Length, xposdif)

                    Try

                        'Lendo o Arquivo de Recibo processado...
                        Me.lbl_mensagem.Text = "'Lendo o Arquivo de Recibo processado... !"
                        Me.Refresh()

                        System.Threading.Thread.Sleep(1000) '1 segundo...
                        strXmlProcRec = _clFuncoes.lerXmlProRec(strXmlRec, genp001)
                        xposAux = strXmlProcRec.IndexOf("</cStat>") + 10
                        strXmlProcRecAux = strXmlProcRec.Substring(xposAux)
                        strAux1 = "<cStat>"
                        strAux2 = "</cStat>"
                        xposinicio = strXmlProcRecAux.IndexOf("<cStat>") : xposfim = strXmlProcRecAux.IndexOf("</cStat>")
                        xposdif = (xposfim - xposinicio) - strAux1.Length
                        strXmlStatus = Mid(strXmlProcRecAux, xposinicio + strAux2.Length, xposdif)


                        strAux1 = "<dhRecbto>"
                        strAux2 = "</dhRecbto>"
                        xposinicio = strXmlProcRec.IndexOf("<dhRecbto>") : xposfim = strXmlProcRec.IndexOf("</dhRecbto>")
                        xposdif = (xposfim - xposinicio) - strAux1.Length
                        strXmlHora = Mid(strXmlProcRec, xposinicio + strAux2.Length, xposdif)

                        Try
                            strAux1 = "<nProt>"
                            strAux2 = "</nProt>"
                            xposinicio = strXmlProcRec.IndexOf("<nProt>") : xposfim = strXmlProcRec.IndexOf("</nProt>")
                            xposdif = (xposfim - xposinicio) - strAux1.Length
                            strXmlProtocolo = Mid(strXmlProcRec, xposinicio + strAux2.Length, xposdif)
                        Catch ex As Exception

                            xposAux = strXmlProcRec.IndexOf("</xMotivo>") + 10
                            strXmlProcRecAux = strXmlProcRec.Substring(xposAux)
                            strAux1 = "<xMotivo>"
                            strAux2 = "</xMotivo>"
                            xposinicio = strXmlProcRecAux.IndexOf("<xMotivo>") : xposfim = strXmlProcRecAux.IndexOf("</xMotivo>")
                            xposdif = (xposfim - xposinicio) - strAux1.Length
                            strXmlMotivo = Mid(strXmlProcRecAux, xposinicio + strAux2.Length, xposdif)
                            Me.lbl_mensagem.Text = strXmlStatus & " - " & strXmlMotivo
                            Me.Refresh()

                        End Try
                        
                    Catch ex As Exception
                        MsgBox("ERRO ao Arquivo de Recibo processado :: " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try

                    mProtocolo = strXmlProtocolo

                    cl_BD.altWebrecNota1pp(nota1pp.pNt_nume, strXmlRec, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altHrwebNota1pp(nota1pp.pNt_nume, strXmlHora, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altLoteNota1pp(nota1pp.pNt_nume, numLotRetorno, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altProtoNota1pp(nota1pp.pNt_nume, strXmlProtocolo, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    If strXmlStatus.Equals("100") Then
                        cl_BD.altStatusNota1pp(nota1pp.pNt_nume, strXmlStatus, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    ElseIf strXmlStatus.Equals("110") Then
                        cl_BD.altStatusNota1pp(nota1pp.pNt_nume, strXmlStatus, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                        cl_BD.altTipoNt_Nota1pp(nota1pp.pNt_nume, "D", MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    End If
                    Me.lbl_mensagem.Text = strXmlStatus & " - " & strXmlMotivo
                    Me.Refresh()

                    System.Threading.Thread.Sleep(1000) '1 segundo...
                    xmlArquivo.Remove(0, xmlArquivo.ToString.Length)
                    xmlArquivo.Append(_clFuncoes.lerXmlEnviado(anoMesPath, chaveNFe, genp001))
                    cl_BD.altXmlNota1pp(nota1pp.pNt_nume, xmlArquivo, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altSituacaoPedido_Orca1(nota1pp.pNt_orca, 5, MdlConexaoBD.conectionPadrao)

                    If strXmlStatus.Equals("100") = True Then
                        MessageBox.Show("Nota Gerada c/ Sucessso !", "Finalização", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.lbl_mensagem.Text = ""
                    End If

                Catch ex As Exception
                    MsgBox("ERRO ao Ler Lote Recebido """ & xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
                    Return
                End Try
               

            Else

                strXmlLoteRecebido = _clFuncoes.lerXmlLoteRecebidoErro(numLotRetorno, genp001)
                frmMsgRtbox.rtb_mensagem.Text = strXmlLoteRecebido
                frmMsgRtbox.ShowDialog()
            End If

        End If


    End Sub

    Private Function verificaImprimir() As Boolean

        lbl_mensagem.Text = ""
        If dtg_nfe.CurrentRow.IsNewRow Then

            MsgBox("Selecione uma Linha Por Favor !") : Return False

        Else

            If Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("C") Then
                MsgBox("Tipo ""C"" - Nota Cancelada!") : Return True
            ElseIf Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("I") Then
                MsgBox("Tipo ""I"" - Nota Inutilizada não pode ser Gerado o Danfe !") : Return False
            End If

        End If


        Return True

    End Function

    Private Function verificaAutoriza() As Boolean

        lbl_mensagem.Text = ""
        If dtg_nfe.CurrentRow.IsNewRow Then

            MsgBox("Selecione uma Linha Por Favor !") : Return False

        Else

            If Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("C") Then
                MsgBox("Tipo ""C"" - Nota Cancelada!") : Return True
            ElseIf Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("I") Then
                MsgBox("Tipo ""I"" - Nota Inutilizada não pode ser Autorizada !") : Return False
            ElseIf Me.dtg_nfe.CurrentRow.Cells(0).Value.ToString.Equals("D") Then
                MsgBox("Tipo ""I"" - Nota Denegada não pode ser Autorizada !") : Return False
            End If

        End If


        Return True

    End Function

    Private Sub btn_imprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprime.Click

        If verificaImprimir() Then

            nota1pp.pNt_nume = dtg_nfe.CurrentRow.Cells(1).Value.ToString
            nota1pp.pNt_dtemis = dtg_nfe.CurrentRow.Cells(2).Value.ToString
            nota1pp.pNt_chave = dtg_nfe.CurrentRow.Cells(5).Value.ToString
            nota1pp.pNt_proto = dtg_nfe.CurrentRow.Cells(6).Value.ToString

            Try
                xmlArquivo.Remove(0, xmlArquivo.ToString.Length)
                anoMesPath = Format(nota1pp.pNt_dtemis, "yyyyMM")
                xmlArquivo.Append(_clFuncoes.lerXmlEnviado(anoMesPath, nota1pp.pNt_chave, MdlEmpresaUsu.genp001))

                fsxml = New FileStream(xmlPathImprimir, FileMode.Create, FileAccess.ReadWrite)
                s = New StreamWriter(fsxml)
                s.WriteLine(xmlArquivo.ToString)
                s.Close()
                fsxml.Close()

                Try
                    Shell("\MetroNFe\UniNFe\unidanfe.exe a=""" & xmlPathImprimir & """", AppWinStyle.Hide, True)

                    If xmlArquivo.ToString.Length > 0 Then
                        cl_BD.altXmlNota1pp(nota1pp.pNt_nume, xmlArquivo, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    End If

                Catch ex As Exception
                End Try

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                fsxml = Nothing : s = Nothing
            End Try

        End If

    End Sub

    Private Sub opt_nome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_nome.Click

        _frmREf = Me
        frmBuscaNome.set_frmRef(Me)
        frmBuscaNome.ShowDialog()
        preecheDtgNFeBusca("nome")

    End Sub

    Private Sub opt_CnpjCpf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_CnpjCpf.Click

        _frmREf = Me
        frmBuscaCnpjCpf.set_frmRef(Me)
        frmBuscaCnpjCpf.ShowDialog()
        preecheDtgNFeBusca("cnpjcpf")

    End Sub

    Private Sub opt_data_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_data.Click

        _frmREf = Me
        frmBuscaDataPeriodo.set_frmRef(Me)
        frmBuscaDataPeriodo.ShowDialog()
        preecheDtgNFeBusca("data")

    End Sub

    Private Sub opt_numero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_numero.Click

        _frmREf = Me
        frmBuscaNumeroNFe.set_frmRef(Me)
        frmBuscaNumeroNFe.ShowDialog()
        preecheDtgNFeBusca("numero")

    End Sub

    Private Sub btn_corrigeNFe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_corrigeNFe.Click


        If validaGeraDanfe() Then

            zeraValoresNota()
            nota1pp.pNt_nume = dtg_nfe.CurrentRow.Cells(1).Value.ToString
            nota1pp.pNt_chave = dtg_nfe.CurrentRow.Cells(5).Value.ToString
            nota1pp.pNt_orca = dtg_nfe.CurrentRow.Cells(8).Value.ToString
            nota1pp.pNt_dtemis = dtg_nfe.CurrentRow.Cells(2).Value.ToString
            anoMesPath = Format(nota1pp.pNt_dtemis, "yyyyMM")
            chaveNFe = nota1pp.pNt_chave
            mProtocolo = ""

            chaveNFe = "" : mProtocolo = "" : mxml.Remove(0, mxml.ToString.Length)
            clickGerar = False


            frmGeraNFeRef = Me
            Dim NFeAutoriza As New Frm_NFEAutorizanota
            NFeAutoriza.lbl_numeroNota1pp.Text = nota1pp.pNt_nume
            NFeAutoriza.mChaveNFe = nota1pp.pNt_chave
            NFeAutoriza.ShowDialog()
            NFeAutoriza = Nothing
            executaF5()

            If mProtocolo.Equals("") AndAlso clickGerar Then

                threadNFe.Add(New System.Threading.Thread(AddressOf buscaArquivosGerados))
                threadNFe(indexContThread).Name = "threadxml" & indexContThread
                threadNFe(indexContThread).IsBackground = True
                threadNFe(indexContThread).Start(indexContThread)
                indexContThread += 1

            End If

        End If


    End Sub

    Private Sub btn_corrigeOutrasNFe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_corrigeOutrasNFe.Click

        If validaGeraDanfe() Then

            zeraValoresNota()
            nota1pp.pNt_nume = dtg_nfe.CurrentRow.Cells(1).Value.ToString
            nota1pp.pNt_chave = dtg_nfe.CurrentRow.Cells(5).Value.ToString
            nota1pp.pNt_orca = dtg_nfe.CurrentRow.Cells(8).Value.ToString
            nota1pp.pNt_dtemis = dtg_nfe.CurrentRow.Cells(2).Value.ToString
            anoMesPath = Format(nota1pp.pNt_dtemis, "yyyyMM")
            chaveNFe = nota1pp.pNt_chave
            mProtocolo = ""

            chaveNFe = "" : mProtocolo = "" : mxml.Remove(0, mxml.ToString.Length)
            clickGerar = False


            frmGeraNFeRef = Me
            Dim NFeEdicao As New Frm_NFeOutrasEdicao
            NFeEdicao._edicaoNFe = True
            NFeEdicao._numNFePublic = nota1pp.pNt_nume
            NFeEdicao._chaveNFePublic = nota1pp.pNt_chave
            NFeEdicao.ShowDialog()
            NFeEdicao = Nothing
            executaF5()

        End If

    End Sub
End Class