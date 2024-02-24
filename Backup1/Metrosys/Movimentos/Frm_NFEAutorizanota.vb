Imports System.Drawing.Printing
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Data.DataColumnCollection
Imports System.ComponentModel
Imports System.Data.DataRow
Imports System.Xml
Imports System.Math
Imports System.Xml.Xsl
Imports System.DateTime
Imports GenoNFeXml
Imports System.Threading
Imports Npgsql

Public Class Frm_NFEAutorizanota

    Dim cl_BD As New Cl_bdMetrosys
    Dim _clFuncoes As New ClFuncoes
    Dim cl_NFe As New GeraXml
    Dim agora As Date = Now
    Dim vnt_dtemis As Date
    Private Arqxml As String = "\wged\tmp\NFE001.txt"
    Private ArqTemp As String = "\wged\tmp\NFE002.txt"
    Private xmlPath As String = "\wged\tmp\MyData.xml"
    Protected conexao As String = MdlConexaoBD.conectionPadrao
    Dim _BuscaForn As New Frm_buscaFornecedor
    Dim _formBusca As Boolean = False
    Dim mNFe_Cfop As String
    Dim CodEstab As String = ""
    Public mbUf, mbCNPJ, mbInscr, mCodPart, mNomePart, mEnderecoPart, mCidadePart As String
    Public mCepPart, mFonePart As String
    Public _mPesquisaForn As Boolean = False 'Serve para configura os campos CodFornec e NomeFornec
    Public mChaveNFe As String = ""
    Public Shared _frmREf As New Frm_NFEAutorizanota
    Private _frmGeraNFe As New Frm_GeraNotasFiscais

    Dim fsxml As FileStream
    Dim s As StreamWriter
    Public vnt_pag As String
    Dim mcfop As String = "", mtipoPag As String = ""


    Dim mAmb, mcontf, mSeqNFe As String
    Dim mExisteNota1pp As Boolean = False
    Dim mNumNota1ppExist As String = "", mCodPartNota1ppExist As String = ""


    'Objetos...
    Dim cliTranportador As New Cl_Cadp001
    Dim geno001 As New Cl_Geno
    Dim genp001 As New Cl_Genp001
    'Private nfeSaida As New Cl_NFeSaida
    Dim nota1pp As New Cl_Nota1pp
    Dim nota2cc As New Cl_Nota2cc
    Dim nota4dd As New Cl_Nota4dd
    Dim nota5tt As New Cl_Nota5tt
    Dim nota6hh As New Cl_Nota6hh


    'Tratamento para gerar chave NFe
    Dim codUf As String, AnoMes As String, cgc As String, modelo As String
    Dim serie As String, numeroNfe As String, cont As String, seqNfe As String, seqNFeInt As Int64, digito As Int16
    Dim chaveSemDigitoFinal As String, chaveNFe, anoMesPath As String


    'Tratamento de Retorno do xml...
    Dim xmlArquivo As New StringBuilder
    Dim strXmlRetorno As String = "", strArqErroRetorno As String = "", strXmlLoteRecebido As String = "", strXmlProcRec As String = ""
    Dim numLotRetorno As String = "", strXmlStatus As String = "", strXmlMotivo As String = "", strXmlProcRecAux As String = ""
    Dim strXmlProtocolo As String = ""
    Dim strXmlRec As String = "", strXmlHora As String = ""
    Dim strAux1 As String = "", strAux2 As String = ""
    Dim xposinicio, xposfim, xposdif, xposAux As Integer


    'Resumo da Saida...
    Dim resn4dd01 As New Cl_ResN4dd01
    Dim resn4dd02 As New Cl_ResN4dd02
    Dim resn4dd03 As New Cl_ResN4dd03
    Dim dtgItensResumo As New DataGridView
    'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
    'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14

    Private Sub incluiRegistroNFe(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim oCmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim SqlNcm As String = ""
        Dim conexaoConsultas As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim conexaoNcm As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim drNcm As NpgsqlDataReader
        Dim commNcm As NpgsqlCommand
        Dim cfv, grupo As Integer
        Try
            conexaoConsultas.Open()
            conexaoNcm.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão para DataReader:: " & ex.Message, MsgBoxStyle.Critical) : Return
        End Try

        Dim mSomaPesoBruto, mSomaPesoLiquido, mSomaIsentos, mSomatprod, mSomaaliss, mSomavliss, mSomavlser, mAlqInterna, mAlqExterna As Double
        Dim mSomabasec, mSomaicms, mSomabsub, mSomaicsub, mSomatpro2, mSomafrete, mSomasegu, mSomaoutros, mSomatgeral As Double
        Dim mSomadesc, mSomaipi, vnc_alqDesconto, vnc_prtotAux, vnc_vlPis, vnc_vlCofins As Double



        'INICIO Atribuindo valores ao Nota1pp...
        nota1pp.pTipo_nt = "P"
        nota1pp.pNt_tipo = "S"
        nota1pp.pNt_nume = mNumNota1ppExist
        If mExisteNota1pp = False Then
            nota1pp.pNt_nume = _clFuncoes.trazVlrColunaGenp001("G00" & CodEstab, "gp_sai", conexao.ConnectionString)
            Dim gp_sai As String = CInt(nota1pp.pNt_nume) + 1
            gp_sai = String.Format("{0:D9}", CInt(gp_sai))
            cl_BD.altGp_SaiGenp001(gp_sai, "G00" & CodEstab, conexao, transacao)
            gp_sai = Nothing
        End If
        resn4dd01.r4_numero = nota1pp.pNt_nume
        resn4dd02.r4_numero = nota1pp.pNt_nume
        resn4dd03.r4_numero = nota1pp.pNt_nume

        nota1pp.pNt_serie = _clFuncoes.trazVlrColunaGenp001("G00" & CodEstab, "gp_serie", conexao.ConnectionString)
        nota1pp.pNt_natur = Mid(Me.cbo_nfeCfop.SelectedItem, 9, 40)
        nota1pp.pNt_cfop = Mid(Me.cbo_nfeCfop.SelectedItem, 1, 5)
        nota1pp.pNt_geno = "G00" & CodEstab
        If mExisteNota1pp Then
            trazFornecedor(mCodPartNota1ppExist)
        End If
        nota1pp.pNt_codig = mCodPart
        nota1pp.pNt_dtemis = Date.Now
        nota1pp.pNt_dtsai = dtp_dtSaida.Value
        nota1pp.pNt_emiss = False
        nota1pp.pNt_cnpj = mbCNPJ
        nota1pp.pNt_insc = mbInscr
        nota1pp.pNt_uf = mbUf
        nota1pp.pNt_orca = Me.txt_pedido.Text

        'Incluindo Nota1pp...
        If mExisteNota1pp = False Then cl_BD.incNota1pp(nota1pp, conexao, transacao)
        nota1pp.pNt_id = cl_BD.trazIdNota1pp(conexao, nota1pp.pNt_nume)
        'FIM Atribuindo valores ao Nota1pp...


        Dim cfopRegistro As String = ""
        nota5tt.pT_qtde = 0
        dtgItensResumo.Rows.Clear() : dtgItensResumo.Refresh()
        'INICIO Tratamento do Nota2cc...
        Sqlcomm.Append("SELECT no_codpr, e.e_produt, e.e_clf, e.e_cst, no_und, no_qtde, no_prunit, no_prtot, ") '7
        Sqlcomm.Append("no_alqicm, no_vlicms, no_vlsub, no_alqsub, no_baseicm, no_basesub, no_pesobruto, no_pesoliquido, ") '15
        Sqlcomm.Append("e.e_ncm, no_alqdesc, e.e_cfv, e.e_grupo, al.alq_interna, al.alq_externa, e.e_cstipi, e.e_produt2, ") '23
        Sqlcomm.Append("e.e_produt3, e.e_reduz, e.e_pauta, no_pruvenda  FROM " & geno001.pEsquemaestab & ".orca2cc, ")
        Sqlcomm.Append(geno001.pEsquemavinc & ".est0001 e LEFT JOIN aliquotas al ON al.alq_tipo = e.e_tipo WHERE no_codpr = ")
        Sqlcomm.Append("e.e_codig AND no_orca = '" & nota1pp.pNt_orca & "'")
        oCmd = New NpgsqlCommand(Sqlcomm.ToString, conexaoConsultas)
        dr = oCmd.ExecuteReader

        'Atribuindo valores ao Nota2cc...
        nota2cc.pNc_tipo = "S"
        nota2cc.pNc_numer = nota1pp.pNt_nume
        nota2cc.pNc_dtemis = nota1pp.pNt_dtemis
        nota2cc.pNc_cdport = nota1pp.pNt_codig
        nota2cc.pNc_ntid = nota1pp.pNt_id
        nota2cc.pNc_indtot = 1
        nota2cc.pNc_seqitem = 0

        While dr.Read


            nota2cc.pNc_codpr = dr(0).ToString
            nota2cc.pNc_produt = dr(23).ToString 'descrição para NFe
            If Trim(nota2cc.pNc_produt).Equals("") Then ' Se a descrição para NFe estiver em branco

                nota2cc.pNc_produt = dr(24).ToString 'descrição para Automóvel
                If Trim(nota2cc.pNc_produt).Equals("") Then ' Se a descrição para Automóvel estiver em branco
                    nota2cc.pNc_produt = dr(1).ToString

                End If
            End If
            nota2cc.pNc_cf = dr(2)
            nota2cc.pNc_cst = Format(dr(3), "00")
            cfv = dr(18)
            grupo = dr(19)
            mAlqInterna = dr(20)
            mAlqExterna = dr(21)
            nota2cc.pNc_und = dr(4).ToString
            nota2cc.pNc_qtde = dr(5)

            If chk_pauta.Checked Then 'Se tiver marcado para usar PAUTA..
                nota2cc.pNc_prunit = dr(26) 'e_pauta

                'Tratamento da PAUTA....
                If nota2cc.pNc_prunit <= 0 Then
                    MsgBox("Produto """ & nota2cc.pNc_codpr & " - " & Mid(nota2cc.pNc_produt, 1, 15) & """ com PAUTA <= ZERO! Por Favor alterar no cadastro do Produto", MsgBoxStyle.Exclamation)
                    transacao.Rollback() : Return
                End If
                'END PAUTA......
            Else

                nota2cc.pNc_prunit = dr(6) 'no_prunit
                If genp001.descontonfe = False Then nota2cc.pNc_prunit = dr(27) 'no_pruvenda
            End If

            nota2cc.pNc_prtot = Round(nota2cc.pNc_qtde * nota2cc.pNc_prunit, 2) 'dr(7)
            nota2cc.pNc_alqicm = dr(8)
            nota2cc.pNc_alqipi = genp001.pTxipi
            nota2cc.pNc_vlipi = 0.0
            nota2cc.pNc_vlicm = dr(9)
            nota2cc.pNc_unipi = 0.0
            nota2cc.pNc_vlsubs = dr(10)
            nota2cc.pNc_alqsub = dr(11)
            nota2cc.pNc_cfop = Mid(nota1pp.pNt_cfop, 1, 1) & Mid(nota1pp.pNt_cfop, 3, 3)
            nota2cc.pNc_bcalc = dr(12)
            nota2cc.pNc_basesub = dr(13)
            nota2cc.pNc_frete = 0.0
            nota2cc.pNc_segur = 0.0

            vnc_alqDesconto = dr(17)
            nota2cc.pNc_vldesc = 0.0
            If vnc_alqDesconto > 0 Then nota2cc.pNc_vldesc = Round((nota2cc.pNc_prtot * vnc_alqDesconto) / 100, 2)
            If genp001.descontonfe = False Then vnc_alqDesconto = 0.0 : nota2cc.pNc_vldesc = 0.0

            nota2cc.pNc_isento = 0.0
            If cfv = 4 Then nota2cc.pNc_isento = nota2cc.pNc_prtot
            nota2cc.pNc_csosn = ""
            nota2cc.pNc_vltrib = 0.0
            nota2cc.pNc_descpac = 0.0

            nota2cc.pNc_alqreduz = dr(25)
            nota2cc.pNc_reduz = 0.0
            If nota2cc.pNc_alqreduz > 0 Then nota2cc.pNc_reduz = Round((nota2cc.pNc_prtot * nota2cc.pNc_alqreduz) / 100, 2)

            vnc_vlPis = 0.0
            vnc_vlCofins = 0.0


            'Tratamento do NCM....
            nota2cc.pNc_ncm = dr(16).ToString
            If nota2cc.pNc_ncm.Length <> 8 Then
                MsgBox("Produto """ & nota2cc.pNc_codpr & """ corrigir NCM!  Por Favor alterar no cadastro do Produto", MsgBoxStyle.Exclamation)
                transacao.Rollback() : Return
            End If
            'END NCM......

            Select Case geno001.pCrt
                Case "1" '1 - Simples Nacional: 
                    'Podem ser usados:
                    '101 - Tributado
                    '102 - Tributado Sem Credito; 
                    '103 - Isenção dentro da faixa; 
                    '300 - Imune; 
                    '400 - Não Tributado pelo Simples:
                    '201 - Tributado c/ Permissão de Crédito
                    '202 - Tributado sem P. Credito, mas c/ cobrança por Subtituição
                    '203 - Isenção por faixa de receita e com cobrança de Substituição
                    '500 - ICMS Cobrado anteriormente por Subst. / Antecipação
                    '900 - Outras Tributações

                    nota2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, nota1pp.pNt_cfop, 0)
                    If cfv = 1 Or cfv = 4 Then 'CSOSN 102
                        ' /Icms12 - Produto Trib. p/ Simples Nacional s/ Permissao de Credito **
                        nota2cc.pNc_csosn = "102"
                        nota2cc.pNc_alqicm = 0
                        nota2cc.pNc_vlicm = 0 : nota2cc.pNc_unipi = 0
                        nota2cc.pNc_vlsubs = 0 : nota2cc.pNc_alqsub = 0
                        nota2cc.pNc_bcalc = 0 : nota2cc.pNc_basesub = 0
                    End If

                    If cfv = 3 Then 'CSOSN 500 Produto com substitui‡Æo
                        nota2cc.pNc_csosn = "500"
                        nota2cc.pNc_alqicm = 0
                        nota2cc.pNc_vlicm = 0 : nota2cc.pNc_unipi = 0
                        nota2cc.pNc_vlsubs = 0 : nota2cc.pNc_alqsub = 0
                        nota2cc.pNc_bcalc = 0 : nota2cc.pNc_basesub = 0
                    End If



                Case "2" '1 - Simples Nacional com Retenção
                    nota2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, nota1pp.pNt_cfop, 0)
                    Select Case cfv
                        Case 1
                            nota2cc.pNc_csosn = "202"
                            nota2cc.pNc_vlsubs = 0 : nota2cc.pNc_alqsub = 0
                            nota2cc.pNc_basesub = 0
                        Case 3 'Produto com substitui‡Æo
                            nota2cc.pNc_csosn = "500"
                        Case 4
                            nota2cc.pNc_csosn = "102"
                    End Select

                Case "3" '3 - Regime Normal

                    If cfv = 3 Then
                        nota2cc.pNc_alqicm = 0.0 : nota2cc.pNc_vlicm = 0.0
                        nota6hh.pC_compl5 = "(*) ICMS PAGO ANTEC CONF.DECR. N.6551/85 E 9483/97"
                        nota2cc.pNc_produt = RTrim(nota2cc.pNc_produt) & " (*)"
                        nota4dd.pN4_outras = nota4dd.pN4_outras + Round((nota2cc.pNc_qtde * nota2cc.pNc_prunit), 2)
                    End If

                    If nota1pp.pNt_cfop.Substring(0, 1).Equals("5") Then
                        nota2cc.pNc_alqicm = mAlqInterna
                    ElseIf nota1pp.pNt_cfop.Substring(0, 1).Equals("6") Then
                        nota2cc.pNc_alqicm = mAlqExterna
                    End If

                    nota2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, nota1pp.pNt_cfop, 0)

            End Select
            nota2cc.pNc_desc = dr(17)


            'Calculando Tributos......................................................................
            'ICMS
            If nota2cc.pNc_alqicm <= 0 Then
                nota2cc.pNc_vlicm = 0
            Else

                Select Case nota2cc.pNc_cst
                    Case "20"
                        nota2cc.pNc_bcalc = Round((nota2cc.pNc_prtot * nota2cc.pNc_alqreduz) / 100, 2)
                        nota2cc.pNc_bcalc = Round(nota2cc.pNc_prtot - nota2cc.pNc_bcalc, 2)
                        nota2cc.pNc_vlicm = Round((nota2cc.pNc_bcalc * nota2cc.pNc_alqicm) / 100, 2)

                    Case Else
                        nota2cc.pNc_bcalc = Round((nota2cc.pNc_prtot - nota2cc.pNc_vldesc), 2)
                        nota2cc.pNc_vlicm = Round((nota2cc.pNc_bcalc * nota2cc.pNc_alqicm) / 100, 2)

                End Select

            End If

            'IPI
            If nota2cc.pNc_alqipi <= 0 Then
                nota2cc.pNc_vlipi = 0
            End If


            'ICMS/IPI
            If (nota2cc.pNc_alqicm <= 0) AndAlso (nota2cc.pNc_alqipi <= 0) Then
                nota2cc.pNc_bcalc = 0.0
            End If


            Select Case nota2cc.pNc_cst
                Case "01", "02", "03"
                    vnc_vlPis = 0.0
                    vnc_vlCofins = 0.0
                Case Else

            End Select

            nota2cc.pNc_cstipi = dr(22).ToString

            'Tratamento do PIS/COFINS ............
            cfopRegistro = nota2cc.pNc_cfop.Substring(nota2cc.pNc_cfop.Length - 3, 3)
            SqlNcm = "SELECT ncm_pissaid, ncm_cofinssaid FROM estncm WHERE ncm_ncm = '" & nota2cc.pNc_ncm & "' " & _
            "AND ncm_cfop LIKE '%" & cfopRegistro & "%' LIMIT 1"
            commNcm = New NpgsqlCommand(SqlNcm, conexaoNcm)
            drNcm = commNcm.ExecuteReader
            While drNcm.Read
                nota2cc.pNc_cstpis = drNcm(0).ToString
                nota2cc.pNc_cstcofins = drNcm(1).ToString
            End While
            drNcm.Close() : commNcm.CommandText = "" : conexaoNcm.ClearPool()

            Select Case nota2cc.pNc_cstpis
                Case "49"
                    Select Case cfopRegistro
                        Case "904" 'Remesssa...
                        Case Else
                            nota2cc.pNc_cstpis = "01"
                    End Select

            End Select
            Select Case nota2cc.pNc_cstcofins
                Case "49"
                    Select Case cfopRegistro
                        Case "904" 'Remesssa...
                        Case Else
                            nota2cc.pNc_cstcofins = "01"
                    End Select
            End Select


            vnc_prtotAux = Round(((nota2cc.pNc_prtot - nota2cc.pNc_vldesc) - nota2cc.pNc_reduz), 2)

            Select Case geno001.pCrt
                Case "1", "2"
                Case "3" 'Regime Normal

                    If geno001.pPis > 0 Then

                        Try
                            If CInt(nota2cc.pNc_cstpis) < 5 Then vnc_vlPis = Round((vnc_prtotAux * geno001.pPis) / 100, 2)
                        Catch ex As Exception
                        End Try

                    End If

                    If geno001.pCofins > 0 Then

                        Try
                            If CInt(nota2cc.pNc_cstcofins) < 5 Then vnc_vlCofins = Round((vnc_prtotAux * geno001.pCofins) / 100, 2)
                        Catch ex As Exception
                        End Try

                    End If

            End Select




            nota2cc.pNc_vltrib = cl_NFe.LeidaTransprencia(vnc_prtotAux, geno001.pPis, geno001.pCofins, geno001.pCsll, geno001.pIRenda, _
                                                          geno001.pSn, nota2cc.pNc_vlicm, nota2cc.pNc_vlipi, nota2cc.pNc_cfop)

            'Soma Totais........................................................
            nota4dd.pN4_pesobruto += dr(14)
            nota4dd.pN4_pesoliquido += dr(15)
            nota4dd.pN4_tgeral += Round((nota2cc.pNc_prtot - nota2cc.pNc_vldesc), 2)
            nota4dd.pN4_aliss = 0
            nota4dd.pN4_vliss = 0
            nota4dd.pN4_vlser = 0
            nota4dd.pN4_basec += nota2cc.pNc_bcalc
            nota4dd.pN4_bsub += nota2cc.pNc_basesub
            nota4dd.pN4_desc += nota2cc.pNc_vldesc
            nota4dd.pN4_frete += nota2cc.pNc_frete
            nota4dd.pN4_icms += nota2cc.pNc_vlicm
            nota4dd.pN4_icsub += nota2cc.pNc_vlsubs
            nota4dd.pN4_ipi += nota2cc.pNc_vlipi
            nota4dd.pN4_isento += nota2cc.pNc_isento
            nota4dd.pN4_outros += nota2cc.pNc_voutro
            nota4dd.pN4_outras += nota2cc.pNc_descpac
            nota4dd.pN4_segu += nota2cc.pNc_segur
            nota4dd.pN4_tprod += (nota2cc.pNc_qtde * nota2cc.pNc_prunit)
            nota4dd.pN4_vlpis += vnc_vlPis
            nota4dd.pN4_vlcofins += vnc_vlCofins
            nota4dd.pN4_totaltrib += nota2cc.pNc_vltrib

            nota2cc.pNc_seqitem += 1
            nota5tt.pT_qtde += CInt(nota2cc.pNc_qtde)
            If mExisteNota1pp = False Then
                cl_BD.incNota2cc(nota2cc, conexao, transacao)
                cl_BD.subtraiQtdFiscProdEstloja(nota2cc.pNc_codpr, CodEstab, nota2cc.pNc_qtde, conexao, transacao)

                'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
                'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
                dtgItensResumo.Rows.Add(nota1pp.pNt_nume, nota2cc.pNc_cfop, nota2cc.pNc_cst, Round(nota2cc.pNc_alqicm, 2), _
                                        Round((nota2cc.pNc_prunit * nota2cc.pNc_qtde), 2), Round(nota2cc.pNc_vldesc, 2), _
                                        Round(nota2cc.pNc_frete, 2), Round(nota2cc.pNc_segur, 2), Round(nota2cc.pNc_descpac, 2), _
                                        Round(nota2cc.pNc_bcalc, 2), Round(nota2cc.pNc_vlicm, 2), Round(nota2cc.pNc_isento, 2), _
                                        Round(nota2cc.pNc_voutro, 2), Round(nota2cc.pNc_vlipi, 2), Round(nota2cc.pNc_prtot, 2))
            End If
            nota2cc.zeraValoresNFe01()

        End While
        dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length)
        'FIM do tratamento do Nota2cc...

        'Tratamentos <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        Select Case geno001.pCrt
            Case "1" '1 - Simples Nacional

                nota6hh.pC_compl4 = "DOCTO EMITIDO P/ ME OU EPP OPTANTE PELO SIMPLES NACIONAL"
                nota6hh.pC_compl5 = "NAO GERA CREDITO FISCAL DE ICMS"
            Case "2" '2 - Simples Nacional - Excesso RB

                nota6hh.pC_compl4 = "DOCTO EMITIDO P/ ME OU EPP OPTANTE PELO SIMPLES NACIONAL"
                nota6hh.pC_compl5 = "NAO GERA CREDITO FISCAL DE ICMS"

        End Select


        'Tratamento do NOTA4DD...
        nota4dd.pN4_numer = nota1pp.pNt_nume
        nota4dd.pN4_tipo = "S"
        nota4dd.pN4_idn1pp = nota1pp.pNt_id
        nota4dd.pN4_tprod = Round(nota4dd.pN4_tprod, 2)
        nota4dd.pN4_aliss = Round(nota4dd.pN4_aliss, 2)
        nota4dd.pN4_vliss = Round(nota4dd.pN4_vliss, 2)
        nota4dd.pN4_vlser = Round(nota4dd.pN4_vlser, 2)
        nota4dd.pN4_basec = Round(nota4dd.pN4_basec, 2)
        nota4dd.pN4_icms = Round(nota4dd.pN4_icms, 2)
        nota4dd.pN4_bsub = Round(nota4dd.pN4_bsub, 2)
        nota4dd.pN4_icsub = Round(nota4dd.pN4_icsub, 2)
        nota4dd.pN4_tpro2 = Round(nota4dd.pN4_tprod, 2)
        nota4dd.pN4_frete = Round(nota4dd.pN4_frete, 2)
        nota4dd.pN4_segu = Round(nota4dd.pN4_segu, 2)
        nota4dd.pN4_outros = Round(nota4dd.pN4_outros, 2)
        nota4dd.pN4_outras = Round(nota4dd.pN4_outras, 2)
        nota4dd.pN4_ipi = Round(nota4dd.pN4_ipi, 2)
        nota4dd.pN4_tgeral = Round(nota4dd.pN4_tgeral, 2)
        nota4dd.pN4_pgto = vnt_pag
        nota4dd.pN4_peso = Round(nota4dd.pN4_peso, 2)
        nota4dd.pN4_pesobruto = Round(nota4dd.pN4_pesobruto, 2)
        nota4dd.pN4_pesoliquido = Round(nota4dd.pN4_pesoliquido, 2)
        nota4dd.pN4_outras = Round(nota4dd.pN4_outras, 2)
        nota4dd.pN4_isento = Round(nota4dd.pN4_isento, 2)
        nota4dd.pN4_desc = Round(nota4dd.pN4_desc, 2)
        nota4dd.pN4_vlpis = Round(nota4dd.pN4_vlpis, 2)
        nota4dd.pN4_vlcofins = Round(nota4dd.pN4_vlcofins, 2)
        If nota4dd.pN4_vlpis > 0 Then nota4dd.pN4_pis = genp001.pPis
        If nota4dd.pN4_vlcofins > 0 Then nota4dd.pN4_cofins = genp001.pConfin
        nota4dd.pN4_totaltrib = Round(nota4dd.pN4_totaltrib, 2)

        If mExisteNota1pp = False Then cl_BD.incNota4dd(nota4dd, conexao, transacao)


        'Tratamento do Nota6hh...
        nota6hh.pC_tipo = nota1pp.pNt_tipo
        nota6hh.pC_numer = nota1pp.pNt_nume
        nota6hh.pC_idn1pp = nota1pp.pNt_id

        If mExisteNota1pp = False Then cl_BD.incNota6hh(nota6hh, conexao, transacao)


        'Tratamento do Nota5tt...
        cliTranportador.zeraValores()
        nota5tt.pT_numer = nota1pp.pNt_nume
        nota5tt.pT_id1pp = nota1pp.pNt_id
        nota5tt.pT_placa = ""
        nota5tt.pT_pesob = Round(nota4dd.pN4_pesobruto, 3)
        nota5tt.pT_pesol = Round(nota4dd.pN4_pesoliquido, 3)

        Select Case Me.cbo_transportador.SelectedIndex
            Case 0
                nota5tt.pT_tpfret = 0
                nota5tt.pT_placa = Me.cbo_placa.SelectedItem.ToString
                nota5tt.pT_marca = "Diversos"
                nota5tt.pT_espec = "Volumes"

                Sqlcomm.Append("SELECT aut_placa, aut_descricao, aut_fornecedor, c.p_uf, c.p_portad, c.p_cpf, c.p_cgc, c.p_end, ") '7
                Sqlcomm.Append("c.p_mun, c.p_coduf, c.p_insc FROM cadautomovel JOIN ")
                Sqlcomm.Append("cadp001 c ON c.p_cod = aut_fornecedor WHERE aut_placa LIKE '" & nota5tt.pT_placa & "'")
                oCmd = New NpgsqlCommand(Sqlcomm.ToString, conexaoConsultas)
                dr = oCmd.ExecuteReader

                While dr.Read

                    nota5tt.pT_codp = dr(2).ToString
                    nota5tt.pT_uf = dr(3).ToString
                    cliTranportador.pCod = dr(2).ToString
                    cliTranportador.pUf = dr(3).ToString
                    cliTranportador.pPortad = dr(4).ToString
                    cliTranportador.pCpf = dr(5).ToString
                    cliTranportador.pCgc = dr(6).ToString
                    cliTranportador.pEnder = dr(7).ToString
                    cliTranportador.pMun = dr(8).ToString
                    cliTranportador.pCoduf = dr(3).ToString
                    cliTranportador.pInsc = dr(10).ToString

                End While
                dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length)

                nota5tt.pT_placa = nota5tt.pT_placa.Replace("-", "")
            Case 1
                nota5tt.pT_codp = "999999"
                nota5tt.pT_tpfret = 1
                nota5tt.pT_placa = Me.txt_placa.Text
            Case 2
                nota5tt.pT_codp = "999999"
                nota5tt.pT_tpfret = 2
                nota5tt.pT_placa = Me.txt_placa.Text
            Case 3
                nota5tt.pT_codp = "999999"
                nota5tt.pT_tpfret = 9
        End Select

        If mExisteNota1pp = False Then cl_BD.incNota5tt(nota5tt, conexao, transacao)


        'INCIO do armazenamento dos Resumos...
        If mExisteNota1pp Then

            _clFuncoes.incResumAlqSaida(True, dtgItensResumo, resn4dd01, geno001, cl_BD, conexao, transacao)
            _clFuncoes.incResumCfopAlqSaida(True, dtgItensResumo, resn4dd02, geno001, cl_BD, conexao, transacao)
            _clFuncoes.incResumCstCfopAlqSaida(True, dtgItensResumo, resn4dd03, geno001, cl_BD, conexao, transacao)

        Else

            _clFuncoes.incResumAlqSaida(False, dtgItensResumo, resn4dd01, geno001, cl_BD, conexao, transacao)
            _clFuncoes.incResumCfopAlqSaida(False, dtgItensResumo, resn4dd02, geno001, cl_BD, conexao, transacao)
            _clFuncoes.incResumCstCfopAlqSaida(False, dtgItensResumo, resn4dd03, geno001, cl_BD, conexao, transacao)

        End If
        'FIM do armazenamento dos Resumos

        Try
            conexaoConsultas.Close() : conexaoConsultas = Nothing
            conexaoNcm.Close() : conexaoNcm = Nothing
        Catch ex As Exception
        End Try

    End Sub

    Private Sub incluiRegistroNFeCorrigindo(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim oCmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim SqlNcm As String = ""
        Dim conexaoConsultas As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim conexaoNcm As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim drNcm As NpgsqlDataReader
        Dim commNcm As NpgsqlCommand
        Dim cfv, grupo As Integer
        Try
            conexaoConsultas.Open()
            conexaoNcm.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão para DataReader:: " & ex.Message, MsgBoxStyle.Critical) : Return
        End Try

        Dim mSomaPesoBruto, mSomaPesoLiquido, mSomaIsentos, mSomatprod, mSomaaliss, mSomavliss, mSomavlser, mAlqInterna, mAlqExterna As Double
        Dim mSomabasec, mSomaicms, mSomabsub, mSomaicsub, mSomatpro2, mSomafrete, mSomasegu, mSomaoutros, mSomatgeral As Double
        Dim mSomadesc, mSomaipi, vnc_alqDesconto, vnc_prtotAux, vnc_vlPis, vnc_vlCofins As Double



        'INICIO Atribuindo valores ao Nota1pp...
        nota1pp.pTipo_nt = "P"
        nota1pp.pNt_tipo = "S"
        nota1pp.pNt_nume = lbl_numeroNota1pp.Text
        nota1pp.pNt_serie = _clFuncoes.trazVlrColunaGenp001("G00" & CodEstab, "gp_serie", conexao.ConnectionString)
        nota1pp.pNt_natur = Mid(Me.cbo_nfeCfop.SelectedItem, 9, 40)
        nota1pp.pNt_cfop = Mid(Me.cbo_nfeCfop.SelectedItem, 1, 5)
        nota1pp.pNt_geno = "G00" & CodEstab
        If mExisteNota1pp Then
            trazFornecedor(mCodPartNota1ppExist)
        End If

        resn4dd01.r4_numero = nota1pp.pNt_nume
        resn4dd02.r4_numero = nota1pp.pNt_nume
        resn4dd03.r4_numero = nota1pp.pNt_nume

        nota1pp.pNt_codig = mCodPart
        nota1pp.pNt_dtemis = Date.Now
        nota1pp.pNt_dtsai = dtp_dtSaida.Value
        nota1pp.pNt_emiss = False
        nota1pp.pNt_cnpj = mbCNPJ
        nota1pp.pNt_insc = mbInscr
        nota1pp.pNt_uf = mbUf
        nota1pp.pNt_orca = Me.txt_pedido.Text

        'Incluindo Nota1pp...
        If mExisteNota1pp = False Then cl_BD.incNota1pp(nota1pp, conexao, transacao)
        nota1pp.pNt_id = cl_BD.trazIdNota1pp(conexao, nota1pp.pNt_nume)
        'FIM Atribuindo valores ao Nota1pp...


        Dim cfopRegistro As String = ""
        nota5tt.pT_qtde = 0
        dtgItensResumo.Rows.Clear() : dtgItensResumo.Refresh()
        'INICIO do Tratamento do Nota2cc...
        Sqlcomm.Append("SELECT no_codpr, e.e_produt, e.e_clf, e.e_cst, no_und, no_qtde, no_prunit, no_prtot, ") '7
        Sqlcomm.Append("no_alqicm, no_vlicms, no_vlsub, no_alqsub, no_baseicm, no_basesub, no_pesobruto, no_pesoliquido, ") '15
        Sqlcomm.Append("e.e_ncm, no_alqdesc, e.e_cfv, e.e_grupo, al.alq_interna, al.alq_externa, e.e_cstipi, e.e_produt2, ") '23
        Sqlcomm.Append("e.e_produt3, e.e_reduz, e.e_pauta, no_pruvenda FROM " & geno001.pEsquemaestab & ".orca2cc, ")
        Sqlcomm.Append(geno001.pEsquemavinc & ".est0001 e LEFT JOIN aliquotas al ON al.alq_tipo = e.e_tipo WHERE no_codpr = ")
        Sqlcomm.Append("e.e_codig AND no_orca = '" & nota1pp.pNt_orca & "'")
        oCmd = New NpgsqlCommand(Sqlcomm.ToString, conexaoConsultas)
        dr = oCmd.ExecuteReader

        'Atribuindo valores ao Nota2cc...
        nota2cc.pNc_tipo = "S"
        nota2cc.pNc_numer = nota1pp.pNt_nume
        nota2cc.pNc_dtemis = nota1pp.pNt_dtemis
        nota2cc.pNc_cdport = nota1pp.pNt_codig
        nota2cc.pNc_ntid = nota1pp.pNt_id
        nota2cc.pNc_indtot = 1
        nota2cc.pNc_seqitem = 0

        While dr.Read


            nota2cc.pNc_codpr = dr(0).ToString
            If nota2cc.pNc_codpr.Equals("00079") Then
                nota2cc.pNc_codpr = nota2cc.pNc_codpr
            End If
            nota2cc.pNc_produt = dr(23).ToString 'descrição para NFe
            If Trim(nota2cc.pNc_produt).Equals("") Then ' Se a descrição para NFe estiver em branco

                nota2cc.pNc_produt = dr(24).ToString 'descrição para Automóvel
                If Trim(nota2cc.pNc_produt).Equals("") Then ' Se a descrição para Automóvel estiver em branco
                    nota2cc.pNc_produt = dr(1).ToString

                End If
            End If
            nota2cc.pNc_cf = dr(2)
            nota2cc.pNc_cst = Format(dr(3), "00")
            cfv = dr(18)
            grupo = dr(19)
            mAlqInterna = dr(20)
            mAlqExterna = dr(21)
            nota2cc.pNc_und = dr(4).ToString
            nota2cc.pNc_qtde = dr(5)

            If chk_pauta.Checked Then 'Se tiver marcado para usar PAUTA..
                nota2cc.pNc_prunit = dr(26) 'e_pauta

                'Tratamento da PAUTA....
                If nota2cc.pNc_prunit <= 0 Then
                    MsgBox("Produto """ & nota2cc.pNc_codpr & " - " & Mid(nota2cc.pNc_produt, 1, 15) & """ com PAUTA <= ZERO! Por Favor alterar no cadastro do Produto", MsgBoxStyle.Exclamation)
                    transacao.Rollback() : Return
                End If
                'END PAUTA......
            Else

                nota2cc.pNc_prunit = dr(6) 'no_prunit
                If genp001.descontonfe = False Then nota2cc.pNc_prunit = dr(27) 'no_pruvenda
            End If

            nota2cc.pNc_prtot = Round(nota2cc.pNc_qtde * nota2cc.pNc_prunit, 2) 'dr(7)
            nota2cc.pNc_alqicm = dr(8)
            nota2cc.pNc_alqipi = genp001.pTxipi
            nota2cc.pNc_vlipi = 0.0
            nota2cc.pNc_vlicm = dr(9)
            nota2cc.pNc_unipi = 0.0
            nota2cc.pNc_vlsubs = dr(10)
            nota2cc.pNc_alqsub = dr(11)
            nota2cc.pNc_cfop = Mid(nota1pp.pNt_cfop, 1, 1) & Mid(nota1pp.pNt_cfop, 3, 3)
            nota2cc.pNc_bcalc = dr(12)
            nota2cc.pNc_basesub = dr(13)
            nota2cc.pNc_frete = 0.0
            nota2cc.pNc_segur = 0.0

            vnc_alqDesconto = dr(17)
            nota2cc.pNc_vldesc = 0.0
            If vnc_alqDesconto > 0 Then nota2cc.pNc_vldesc = Round((nota2cc.pNc_prtot * vnc_alqDesconto) / 100, 2)
            If genp001.descontonfe = False Then vnc_alqDesconto = 0.0 : nota2cc.pNc_vldesc = 0.0

            nota2cc.pNc_isento = 0.0
            If cfv = 4 Then nota2cc.pNc_isento = nota2cc.pNc_prtot
            nota2cc.pNc_csosn = ""
            nota2cc.pNc_vltrib = 0.0
            nota2cc.pNc_descpac = 0.0

            nota2cc.pNc_alqreduz = dr(25)
            nota2cc.pNc_reduz = 0.0
            If nota2cc.pNc_alqreduz > 0 Then nota2cc.pNc_reduz = Round((nota2cc.pNc_prtot * nota2cc.pNc_alqreduz) / 100, 2)

            vnc_vlPis = 0.0
            vnc_vlCofins = 0.0

            'Tratamento do NCM....
            nota2cc.pNc_ncm = dr(16).ToString
            If nota2cc.pNc_ncm.Length <> 8 Then
                MsgBox("Produto """ & nota2cc.pNc_codpr & """ corrigir NCM!  Por Favor alterar no cadastro do Produto", MsgBoxStyle.Exclamation)
                transacao.Rollback() : Return
            End If
            'END NCM......

            Select Case geno001.pCrt
                Case "1" '1 - Simples Nacional: 
                    'Podem ser usados:
                    '101 - Tributado
                    '102 - Tributado Sem Credito; 
                    '103 - Isenção dentro da faixa; 
                    '300 - Imune; 
                    '400 - Não Tributado pelo Simples:
                    '201 - Tributado c/ Permissão de Crédito
                    '202 - Tributado sem P. Credito, mas c/ cobrança por Subtituição
                    '203 - Isenção por faixa de receita e com cobrança de Substituição
                    '500 - ICMS Cobrado anteriormente por Subst. / Antecipação
                    '900 - Outras Tributações

                    nota2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, nota1pp.pNt_cfop, 0)
                    If cfv = 1 Or cfv = 4 Then 'CSOSN 102
                        ' /Icms12 - Produto Trib. p/ Simples Nacional s/ Permissao de Credito **
                        nota2cc.pNc_csosn = "102"
                        nota2cc.pNc_alqicm = 0
                        nota2cc.pNc_vlicm = 0 : nota2cc.pNc_unipi = 0
                        nota2cc.pNc_vlsubs = 0 : nota2cc.pNc_alqsub = 0
                        nota2cc.pNc_bcalc = 0 : nota2cc.pNc_basesub = 0
                    End If

                    If cfv = 3 Then 'CSOSN 500 Produto com substitui‡Æo
                        nota2cc.pNc_csosn = "500"
                        nota2cc.pNc_alqicm = 0
                        nota2cc.pNc_vlicm = 0 : nota2cc.pNc_unipi = 0
                        nota2cc.pNc_vlsubs = 0 : nota2cc.pNc_alqsub = 0
                        nota2cc.pNc_bcalc = 0 : nota2cc.pNc_basesub = 0
                    End If



                Case "2" '1 - Simples Nacional com Retenção
                    nota2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, nota1pp.pNt_cfop, 0)
                    Select Case cfv
                        Case 1
                            nota2cc.pNc_csosn = "202"
                            nota2cc.pNc_vlsubs = 0 : nota2cc.pNc_alqsub = 0
                            nota2cc.pNc_basesub = 0
                        Case 3 'Produto com substitui‡Æo
                            nota2cc.pNc_csosn = "500"
                        Case 4
                            nota2cc.pNc_csosn = "102"
                    End Select

                Case "3" '3 - Regime Normal

                    If cfv = 3 Then
                        nota2cc.pNc_alqicm = 0.0 : nota2cc.pNc_vlicm = 0.0
                        nota6hh.pC_compl5 = "(*) ICMS PAGO ANTEC CONF.DECR. N.6551/85 E 9483/97"
                        nota2cc.pNc_produt = RTrim(nota2cc.pNc_produt) & " (*)"
                        nota4dd.pN4_outras = nota4dd.pN4_outras + Round((nota2cc.pNc_qtde * nota2cc.pNc_prunit), 2)
                    End If

                    If nota1pp.pNt_cfop.Substring(0, 1).Equals("5") Then
                        nota2cc.pNc_alqicm = mAlqInterna
                    ElseIf nota1pp.pNt_cfop.Substring(0, 1).Equals("6") Then
                        nota2cc.pNc_alqicm = mAlqExterna
                    End If

                    nota2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, nota1pp.pNt_cfop, 0)

            End Select
            nota2cc.pNc_desc = dr(17)


            'Calculando Tributos......................................................................
            'ICMS
            If nota2cc.pNc_alqicm <= 0 Then
                nota2cc.pNc_vlicm = 0
            Else

                Select Case nota2cc.pNc_cst
                    Case "20"
                        nota2cc.pNc_bcalc = Round((nota2cc.pNc_prtot * nota2cc.pNc_alqreduz) / 100, 2)
                        nota2cc.pNc_bcalc = Round(nota2cc.pNc_prtot - nota2cc.pNc_bcalc, 2)
                        nota2cc.pNc_vlicm = Round((nota2cc.pNc_bcalc * nota2cc.pNc_alqicm) / 100, 2)

                    Case Else
                        nota2cc.pNc_bcalc = Round((nota2cc.pNc_prtot - nota2cc.pNc_vldesc), 2)
                        nota2cc.pNc_vlicm = Round((nota2cc.pNc_bcalc * nota2cc.pNc_alqicm) / 100, 2)

                End Select

            End If

            'IPI
            If nota2cc.pNc_alqipi <= 0 Then
                nota2cc.pNc_vlipi = 0
            End If


            'ICMS/IPI
            If (nota2cc.pNc_alqicm <= 0) AndAlso (nota2cc.pNc_alqipi <= 0) Then
                nota2cc.pNc_bcalc = 0.0
            End If


            Select Case nota2cc.pNc_cst
                Case "01", "02", "03"
                    vnc_vlPis = 0.0
                    vnc_vlCofins = 0.0
                Case Else

            End Select

            nota2cc.pNc_cstipi = dr(22).ToString

            'Tratamento do PIS/COFINS ............
            cfopRegistro = nota2cc.pNc_cfop.Substring(nota2cc.pNc_cfop.Length - 3, 3)
            SqlNcm = "SELECT ncm_pissaid, ncm_cofinssaid FROM estncm WHERE ncm_ncm = '" & nota2cc.pNc_ncm & "' " & _
            "AND ncm_cfop LIKE '%" & cfopRegistro & "%' LIMIT 1"
            commNcm = New NpgsqlCommand(SqlNcm, conexaoNcm)
            drNcm = commNcm.ExecuteReader
            While drNcm.Read
                nota2cc.pNc_cstpis = drNcm(0).ToString
                nota2cc.pNc_cstcofins = drNcm(1).ToString
            End While
            drNcm.Close() : commNcm.CommandText = "" : conexaoNcm.ClearPool()

            Select Case nota2cc.pNc_cstpis
                Case "49"
                    Select Case cfopRegistro
                        Case "904" 'Remesssa...
                        Case Else
                            nota2cc.pNc_cstpis = "01"
                    End Select

            End Select
            Select Case nota2cc.pNc_cstcofins
                Case "49"
                    Select Case cfopRegistro
                        Case "904" 'Remesssa...
                        Case Else
                            nota2cc.pNc_cstcofins = "01"
                    End Select
            End Select


            vnc_prtotAux = Round(((nota2cc.pNc_prtot - nota2cc.pNc_vldesc) - nota2cc.pNc_reduz), 2)


            Select Case geno001.pCrt
                Case "1", "2"
                Case "3" 'Regime Normal

                    If geno001.pPis > 0 Then

                        Try
                            If CInt(nota2cc.pNc_cstpis) < 5 Then vnc_vlPis = Round((vnc_prtotAux * geno001.pPis) / 100, 2)
                        Catch ex As Exception
                        End Try

                    End If

                    If geno001.pCofins > 0 Then

                        Try
                            If CInt(nota2cc.pNc_cstcofins) < 5 Then vnc_vlCofins = Round((vnc_prtotAux * geno001.pCofins) / 100, 2)
                        Catch ex As Exception
                        End Try

                    End If

            End Select


            nota2cc.pNc_vltrib = cl_NFe.LeidaTransprencia(vnc_prtotAux, geno001.pPis, geno001.pCofins, geno001.pCsll, geno001.pIRenda, _
                                                          geno001.pSn, nota2cc.pNc_vlicm, nota2cc.pNc_vlipi, nota2cc.pNc_cfop)

            'Soma Totais........................................................
            nota4dd.pN4_pesobruto += dr(14)
            nota4dd.pN4_pesoliquido += dr(15)
            nota4dd.pN4_tgeral += Round((nota2cc.pNc_prtot - nota2cc.pNc_vldesc), 2)
            nota4dd.pN4_aliss = 0
            nota4dd.pN4_vliss = 0
            nota4dd.pN4_vlser = 0
            nota4dd.pN4_basec += nota2cc.pNc_bcalc
            nota4dd.pN4_bsub += nota2cc.pNc_basesub
            nota4dd.pN4_desc += nota2cc.pNc_vldesc
            nota4dd.pN4_frete += nota2cc.pNc_frete
            nota4dd.pN4_icms += nota2cc.pNc_vlicm
            nota4dd.pN4_icsub += nota2cc.pNc_vlsubs
            nota4dd.pN4_ipi += nota2cc.pNc_vlipi
            nota4dd.pN4_isento += nota2cc.pNc_isento
            nota4dd.pN4_outros += nota2cc.pNc_voutro
            nota4dd.pN4_outras += nota2cc.pNc_descpac
            nota4dd.pN4_segu += nota2cc.pNc_segur
            nota4dd.pN4_tprod += (nota2cc.pNc_qtde * nota2cc.pNc_prunit)
            nota4dd.pN4_vlpis += vnc_vlPis
            nota4dd.pN4_vlcofins += vnc_vlCofins
            nota4dd.pN4_totaltrib += nota2cc.pNc_vltrib

            nota2cc.pNc_seqitem += 1
            nota5tt.pT_qtde += CInt(nota2cc.pNc_qtde)
            If mExisteNota1pp = False Then

                cl_BD.incNota2cc(nota2cc, conexao, transacao)
                cl_BD.subtraiQtdFiscProdEstloja(nota2cc.pNc_codpr, CodEstab, nota2cc.pNc_qtde, conexao, transacao)


                'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
                'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
                dtgItensResumo.Rows.Add(nota1pp.pNt_nume, nota2cc.pNc_cfop, nota2cc.pNc_cst, Round(nota2cc.pNc_alqicm, 2), _
                                        Round((nota2cc.pNc_prunit * nota2cc.pNc_qtde), 2), Round(nota2cc.pNc_vldesc, 2), _
                                        Round(nota2cc.pNc_frete, 2), Round(nota2cc.pNc_segur, 2), Round(nota2cc.pNc_descpac, 2), _
                                        Round(nota2cc.pNc_bcalc, 2), Round(nota2cc.pNc_vlicm, 2), Round(nota2cc.pNc_isento, 2), _
                                        Round(nota2cc.pNc_voutro, 2), Round(nota2cc.pNc_vlipi, 2), Round(nota2cc.pNc_prtot, 2))

            End If
            nota2cc.zeraValoresNFe01()

        End While
        dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length)
        'FIM do Tratamento do Nota2cc...


        'Tratamentos <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        Select Case geno001.pCrt
            Case "1" '1 - Simples Nacional

                nota6hh.pC_compl4 = "DOCTO EMITIDO P/ ME OU EPP OPTANTE PELO SIMPLES NACIONAL"
                nota6hh.pC_compl5 = "NAO GERA CREDITO FISCAL DE ICMS"
            Case "2" '2 - Simples Nacional - Excesso RB

                nota6hh.pC_compl4 = "DOCTO EMITIDO P/ ME OU EPP OPTANTE PELO SIMPLES NACIONAL"
                nota6hh.pC_compl5 = "NAO GERA CREDITO FISCAL DE ICMS"

        End Select


        'Tratamento do NOTA4DD...
        nota4dd.pN4_numer = nota1pp.pNt_nume
        nota4dd.pN4_tipo = "S"
        nota4dd.pN4_idn1pp = nota1pp.pNt_id
        nota4dd.pN4_tprod = Round(nota4dd.pN4_tprod, 2)
        nota4dd.pN4_aliss = Round(nota4dd.pN4_aliss, 2)
        nota4dd.pN4_vliss = Round(nota4dd.pN4_vliss, 2)
        nota4dd.pN4_vlser = Round(nota4dd.pN4_vlser, 2)
        nota4dd.pN4_basec = Round(nota4dd.pN4_basec, 2)
        nota4dd.pN4_icms = Round(nota4dd.pN4_icms, 2)
        nota4dd.pN4_bsub = Round(nota4dd.pN4_bsub, 2)
        nota4dd.pN4_icsub = Round(nota4dd.pN4_icsub, 2)
        nota4dd.pN4_tpro2 = Round(nota4dd.pN4_tprod, 2)
        nota4dd.pN4_frete = Round(nota4dd.pN4_frete, 2)
        nota4dd.pN4_segu = Round(nota4dd.pN4_segu, 2)
        nota4dd.pN4_outros = Round(nota4dd.pN4_outros, 2)
        nota4dd.pN4_outras = Round(nota4dd.pN4_outras, 2)
        nota4dd.pN4_ipi = Round(nota4dd.pN4_ipi, 2)
        nota4dd.pN4_tgeral = Round(nota4dd.pN4_tgeral, 2)
        nota4dd.pN4_pgto = vnt_pag
        nota4dd.pN4_peso = Round(nota4dd.pN4_peso, 2)
        nota4dd.pN4_pesobruto = Round(nota4dd.pN4_pesobruto, 2)
        nota4dd.pN4_pesoliquido = Round(nota4dd.pN4_pesoliquido, 2)
        nota4dd.pN4_outras = Round(nota4dd.pN4_outras, 2)
        nota4dd.pN4_isento = Round(nota4dd.pN4_isento, 2)
        nota4dd.pN4_desc = Round(nota4dd.pN4_desc, 2)
        nota4dd.pN4_vlpis = Round(nota4dd.pN4_vlpis, 2)
        nota4dd.pN4_vlcofins = Round(nota4dd.pN4_vlcofins, 2)
        If nota4dd.pN4_vlpis > 0 Then nota4dd.pN4_pis = genp001.pPis
        If nota4dd.pN4_vlcofins > 0 Then nota4dd.pN4_cofins = genp001.pConfin
        nota4dd.pN4_totaltrib = Round(nota4dd.pN4_totaltrib, 2)

        If mExisteNota1pp = False Then cl_BD.incNota4dd(nota4dd, conexao, transacao)


        'Tratamento do Nota6hh...
        nota6hh.pC_tipo = nota1pp.pNt_tipo
        nota6hh.pC_numer = nota1pp.pNt_nume
        nota6hh.pC_idn1pp = nota1pp.pNt_id

        If mExisteNota1pp = False Then cl_BD.incNota6hh(nota6hh, conexao, transacao)


        'Tratamento do Nota5tt...
        cliTranportador.zeraValores()
        nota5tt.pT_numer = nota1pp.pNt_nume
        nota5tt.pT_id1pp = nota1pp.pNt_id
        nota5tt.pT_placa = ""
        nota5tt.pT_pesob = Round(nota4dd.pN4_pesobruto, 3)
        nota5tt.pT_pesol = Round(nota4dd.pN4_pesoliquido, 3)

        Select Case Me.cbo_transportador.SelectedIndex
            Case 0
                nota5tt.pT_tpfret = 0
                nota5tt.pT_placa = Me.cbo_placa.SelectedItem.ToString
                nota5tt.pT_marca = "Diversos"
                nota5tt.pT_espec = "Volumes"

                Sqlcomm.Append("SELECT aut_placa, aut_descricao, aut_fornecedor, c.p_uf, c.p_portad, c.p_cpf, c.p_cgc, c.p_end, ") '7
                Sqlcomm.Append("c.p_mun, c.p_coduf, c.p_insc FROM cadautomovel JOIN ")
                Sqlcomm.Append("cadp001 c ON c.p_cod = aut_fornecedor WHERE aut_placa LIKE '" & nota5tt.pT_placa & "'")
                oCmd = New NpgsqlCommand(Sqlcomm.ToString, conexaoConsultas)
                dr = oCmd.ExecuteReader

                While dr.Read

                    nota5tt.pT_codp = dr(2).ToString
                    nota5tt.pT_uf = dr(3).ToString
                    cliTranportador.pCod = dr(2).ToString
                    cliTranportador.pUf = dr(3).ToString
                    cliTranportador.pPortad = dr(4).ToString
                    cliTranportador.pCpf = dr(5).ToString
                    cliTranportador.pCgc = dr(6).ToString
                    cliTranportador.pEnder = dr(7).ToString
                    cliTranportador.pMun = dr(8).ToString
                    cliTranportador.pCoduf = dr(3).ToString
                    cliTranportador.pInsc = dr(10).ToString

                End While
                dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length)

                nota5tt.pT_placa = nota5tt.pT_placa.Replace("-", "")

            Case 1
                nota5tt.pT_codp = "999999"
                nota5tt.pT_tpfret = 1
                nota5tt.pT_placa = Me.txt_placa.Text.Replace("-", "")
            Case 2
                nota5tt.pT_codp = "999999"
                nota5tt.pT_tpfret = 2
                nota5tt.pT_placa = Me.txt_placa.Text.Replace("-", "")
            Case 3
                nota5tt.pT_codp = "999999"
                nota5tt.pT_tpfret = 9
        End Select

        If mExisteNota1pp = False Then cl_BD.incNota5tt(nota5tt, conexao, transacao)


        'INCIO do armazenamento dos Resumos...
        If mExisteNota1pp Then

            _clFuncoes.incResumAlqSaida(True, dtgItensResumo, resn4dd01, geno001, cl_BD, conexao, transacao)
            _clFuncoes.incResumCfopAlqSaida(True, dtgItensResumo, resn4dd02, geno001, cl_BD, conexao, transacao)
            _clFuncoes.incResumCstCfopAlqSaida(True, dtgItensResumo, resn4dd03, geno001, cl_BD, conexao, transacao)

        Else

            _clFuncoes.incResumAlqSaida(False, dtgItensResumo, resn4dd01, geno001, cl_BD, conexao, transacao)
            _clFuncoes.incResumCfopAlqSaida(False, dtgItensResumo, resn4dd02, geno001, cl_BD, conexao, transacao)
            _clFuncoes.incResumCstCfopAlqSaida(False, dtgItensResumo, resn4dd03, geno001, cl_BD, conexao, transacao)

        End If
        'FIM do armazenamento dos Resumos


        Try
            conexaoConsultas.Close() : conexaoConsultas = Nothing
            conexaoNcm.Close() : conexaoNcm = Nothing
        Catch ex As Exception
        End Try

    End Sub

    Private Function incluirDadosNFe() As Boolean

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim Ok As Boolean = True

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try

        Try
            transacao = conexao.BeginTransaction

            incluiRegistroNFe(conexao, transacao)

            transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
            'MsgBox("Registro Efetuado c/ Sucesso", MsgBoxStyle.Exclamation, "METROSYS")


        Catch ex As NpgsqlException

            transacao.Rollback()
            MsgBox(ex.Message.ToString)
            Ok = False
        Catch ex As Exception

            Try
                transacao.Rollback()
            Catch ex2 As Exception
            End Try
            Ok = False
        Finally
            conexao = Nothing : transacao = Nothing

        End Try

        Return Ok
    End Function

    Private Function incluirDadosNFeCorrigindo() As Boolean

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim Ok As Boolean = True

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try

        Try
            transacao = conexao.BeginTransaction

            deletaValoresTabela(conexao, transacao)
            mExisteNota1pp = False
            incluiRegistroNFeCorrigindo(conexao, transacao)

            transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
            'MsgBox("Registro Efetuado c/ Sucesso", MsgBoxStyle.Exclamation, "METROSYS")


        Catch ex As NpgsqlException

            transacao.Rollback()
            MsgBox(ex.Message.ToString)
            Ok = False
        Catch ex As Exception

            Try
                transacao.Rollback()
            Catch ex2 As Exception
            End Try
            Ok = False
        Finally
            conexao = Nothing : transacao = Nothing

        End Try

        Return Ok
    End Function

    Private Sub zeraValores()
        nota1pp.zeraValores()
        nota2cc.zeraValores()
        nota4dd.zeraValores()
        nota5tt.zeraValores()
        nota6hh.zeraValores()
        mExisteNota1pp = False : mNumNota1ppExist = ""
    End Sub

    Private Function verificaInformacoes() As Boolean

        lbl_mensagem.Text = ""
        If cbo_estabelecimento.SelectedIndex < 0 Then lbl_mensagem.Text = "Selecione uma Loja! Por favor!" : cbo_estabelecimento.Focus() : Return False
        If Trim(txt_pedido.Text).Equals("") Then lbl_mensagem.Text = "Informe um Pedido! Por favor!" : txt_pedido.Focus() : Return False
        If Trim(txt_codPart.Text).Equals("") OrElse txt_nomePart.Text.Equals("") Then
            lbl_mensagem.Text = "Informe um Cliente! Por favor!" : txt_codPart.Focus() : Return False
        End If
        If cbo_nfeCfop.SelectedIndex < 0 Then lbl_mensagem.Text = "Selecione um CFOP p/ Nota! Por favor!" : cbo_nfeCfop.Focus() : Return False

        Return True
    End Function

    Private Sub btn_nfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nfe.Click

        If verificaInformacoes() = False Then Return

        Try
            s.BaseStream.Seek(0, SeekOrigin.End)
        Catch ex As Exception
        End Try

        mcfop = Mid(cbo_nfeCfop.SelectedItem, 7, 59)
        vnt_pag = _clFuncoes.trazCodPagamentoNFe(mtipoPag, mcfop)


        If lbl_numeroNota1pp.Text.Equals("") Then

            'Inclue os dados da NFe no banco de dados
            If incluirDadosNFe() Then

                If MessageBox.Show("Confirme Gerar Nota Fiscal", "Gerar NFe ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    gerandoNFe()

                Else
                    MessageBox.Show("Nota Fiscal Não Gerada !", "Finalização", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    fsxml.Close()
                    Me.Close()
                End If

            Else
                Me.Close()
            End If


        Else 'Gerando o Danfe com Correção...


            'Inclue os dados da NFe no banco de dados
            If incluirDadosNFeCorrigindo() Then

                If MessageBox.Show("Confirme Gerar Nota Fiscal", "Gerar NFe ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    gerandoNFe()

                Else
                    MessageBox.Show("Nota Fiscal Não Gerada !", "Finalização", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    fsxml.Close()
                    Me.Close()
                End If

            Else
                Me.Close()
            End If


        End If


    End Sub

    Private Function deletaValoresTabela(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        nota1pp.pNt_nume = lbl_numeroNota1pp.Text
        nota2cc.pNc_numer = lbl_numeroNota1pp.Text
        nota4dd.pN4_numer = lbl_numeroNota1pp.Text
        nota5tt.pT_numer = lbl_numeroNota1pp.Text
        nota6hh.pC_numer = lbl_numeroNota1pp.Text
        resn4dd01.r4_numero = lbl_numeroNota1pp.Text
        resn4dd02.r4_numero = lbl_numeroNota1pp.Text
        resn4dd03.r4_numero = lbl_numeroNota1pp.Text

        cl_BD.delNota6hh(nota6hh, geno001, conexao, transacao)
        cl_BD.delNota5tt(nota5tt, geno001, conexao, transacao)
        cl_BD.delNota2cc(nota2cc, geno001, conexao, transacao)
        cl_BD.delNota4dd(nota4dd, geno001, conexao, transacao)
        cl_BD.delResSaidaALQ(resn4dd01, geno001, conexao, transacao)
        cl_BD.delResSaidaCfopALQ(resn4dd02, geno001, conexao, transacao)
        cl_BD.delResSaidaCstCfopALQ(resn4dd03, geno001, conexao, transacao)
        cl_BD.delNota1pp(nota1pp, geno001, conexao, transacao)


    End Function

    Private Sub gerandoNFe()


        Dim oConUp As New NpgsqlConnection(conexao)
        'Dim oCmdUp As NpgsqlCommand

        Dim oConn As New NpgsqlConnection(conexao)
        Dim oCmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim daCont As New NpgsqlDataAdapter
        Dim Mconsulta As Boolean = False
        Dim Sqlcomm As StringBuilder = New StringBuilder


        codUf = geno001.pCoduf
        AnoMes = Format(nota1pp.pNt_dtemis, "yyMM")
        anoMesPath = Format(nota1pp.pNt_dtemis, "yyyyMM")
        _frmGeraNFe.frmGeraNFeRef.AnoMes = AnoMes
        _frmGeraNFe.frmGeraNFeRef.anoMesPath = anoMesPath
        cgc = geno001.pCgc
        modelo = "55"
        serie = genp001.pSerie
        numeroNfe = nota1pp.pNt_nume
        cont = genp001.pContf

        If lbl_numeroNota1pp.Text.Equals("") Then
            chaveNFe = _clFuncoes.trazVlrColunaNota1pp(nota1pp.pNt_nume, geno001.pEsquemaestab, "nt_chave", MdlConexaoBD.conectionPadrao)
        Else
            chaveNFe = mChaveNFe
        End If

        If chaveNFe.Equals("") Then
            seqNFeInt = Convert.ToInt64(_clFuncoes.trazVlrColunaGenp001(geno001.pCodig, "gp_seqnfe", MdlConexaoBD.conectionPadrao))
            seqNfe = String.Format("{0:D8}", seqNFeInt)
            seqNFeInt += 1
            cl_BD.altGp_SeqNFeGenp001(String.Format("{0:D9}", seqNFeInt), geno001.pCodig, MdlConexaoBD.conectionPadrao)
        End If


        'Tratamento da Chave da NFe.............
        If Trim(chaveNFe).Equals("") Then 'Se o nota1pp não tiver com chave

            chaveSemDigitoFinal = cl_NFe.Cria_ChaveNFeSemDigitoFinal(codUf, AnoMes, cgc, modelo, serie, numeroNfe, cont, seqNfe)
            digito = cl_NFe.Digito_ChaveNFe(chaveSemDigitoFinal)
            chaveNFe = cl_NFe.Cria_ChaveNFe(codUf, AnoMes, cgc, modelo, serie, numeroNfe, cont, seqNfe, digito)
            cl_BD.altChaveNota1pp(nota1pp.pNt_nume, chaveNFe, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)

        Else 'Se já tiver chave no nota1pp...
            cl_BD.altChaveNota1pp(nota1pp.pNt_nume, chaveNFe, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
            chaveSemDigitoFinal = Mid(chaveNFe, 1, 43)
            seqNfe = Mid(chaveNFe, 36, 8)
            digito = CInt(Mid(chaveNFe, 44, 1))
        End If

        _frmGeraNFe.frmGeraNFeRef.chaveNFe = chaveNFe


        '   * *  Inicio de Criação de XML  ***
        Try

            ' Cabeçalho Padrão do Xml
            cl_NFe.Cria_xml(s)

            ' Chave da NFe
            cl_NFe.Abre_xml_infNFe(chaveNFe, s)

            ' Elementos do grupo B
            ' Identificação da Nota Fiscal eletrônica 
            ' vnt_dtemis = Date.Now

            cl_NFe.xmlGrupo_B(geno001.pCoduf, seqNfe, Trim(Mid(cbo_nfeCfop.SelectedItem, 8, 59)), nota4dd.pN4_pgto, "55", CInt(genp001.pSerie), nota1pp.pNt_nume, _
                            nota1pp.pNt_dtemis, nota1pp.pNt_dtsai, "1", geno001.pMun, "1", genp001.pContf, digito, genp001.pAmb, "1", "0", _
                            Mid(Application.ProductVersion, 1, 20), s)
            ' Encerramento do Cabeçalho do Atributo Inicial


            ' '* Inicia Tag's do Grupo C -  Emitente da NFe '**
            ' Elementos do grupo C
            cl_NFe.xmlGrupo_C(geno001.pCgc, geno001.pGeno, geno001.pEnder, geno001.pBair, geno001.pMun, geno001.pCid, geno001.pUf, _
                              geno001.pCep, geno001.pFone, geno001.pInsc, geno001.pCrt, s)

            ' '* Inicia Tag's do Grupo E -  Destinatario da NFe '**
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
                If genp001.pAmb.Equals("2") Then ' Se estiver e ambiente de HOMOLOGAÇÃO
                    mNomePart = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
                End If
                cl_NFe.xmlGrupo_E(vp_carac, vp_cgc, vp_cpf, mNomePart, vp_end, vp_bairro, vp_mun, vp_cid, vp_uf, vp_cep, _
                            vp_fone, vp_insc, vp_suframa, vp_email, s)

                conPort.Close()
                conPort.Dispose()
            Catch ex As NpgsqlException
                MsgBox(ex.Message.ToString)
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

            '''''''''''''''''''***
            ' Acoplando itens do pedido a Nfe - Nota2cc

            Dim conItens As New Npgsql.NpgsqlConnection(conexao)
            Dim SqlcomItens As StringBuilder = New StringBuilder
            Dim DrItens As NpgsqlDataReader

            Dim vnc_tipo, vnc_numer, vnc_codpr, vnc_produt, vnc_produt2, vnc_cf, vnc_cst, vnc_und, vnc_ncm, vnc_csosn As String
            Dim vnc_cdbarra, vnc_cfop, vnc_cdport, vnc_cstipi, vnc_cstpis, vnc_cstcofins As String
            Dim vnc_qtde, vnc_prunit, vnc_prtot, vnc_alqicm, vnc_alqipi, vnc_vlipi, vnc_vltrib As Double
            Dim vnc_vlicm, vnc_dtemis, vnc_unipi, vnc_vlsubs, vnc_descpac, vnc_reduz, vnc_alqreduz, vnc_vlpis, vnc_vlcofins As Double
            Dim vnc_bcalc, vnc_basesub, vnc_frete, vnc_segur, vnc_vldesc, vnc_isento, vnc_icmsub, vnc_prtotAux As Double
            Dim vnc_seqitem, vnc_indtot, vnc_origem As Integer

            Try
                conItens.Open()
                SqlcomItens.Append("SELECT n1.nt_orca, n1.nt_nume, n2.nc_codpr, n2.nc_produt, n2.nc_cf, n2.nc_cst, E.e_und, n2.nc_qtde, ") '7
                SqlcomItens.Append("n2.nc_prunit, n2.nc_prtot, n2.nc_alqicm, n2.nc_vlicm, n2.nc_bcalc, n2.nc_alqipi, n2.nc_vlipi, ") '14
                SqlcomItens.Append("n2.nc_unipi, n2.nc_vlsubs, n2.nc_basesub, n2.nc_cfop, n2.nc_frete, n2.nc_segur, n2.nc_vldesc, ") '21
                SqlcomItens.Append("nc_isento, E.e_produt2, n2.nc_ncm, n2.nc_csosn, n2.nc_alqsub, E.e_cdbarra, n2.nc_indtot, ") '28
                SqlcomItens.Append("n2.nc_seqitem, n2.nc_descpac, nc_reduz, nc_alqreduz, E.e_produt2, E.e_produt3, E.e_origem, ") '35
                SqlcomItens.Append("n2.nc_vltrib, n2.nc_cstpis, n2.nc_cstcofins, n2.nc_cstipi ") '39
                SqlcomItens.Append("FROM " & geno001.pEsquemaestab & ".nota1pp n1, " & geno001.pEsquemaestab & ".nota2cc n2 ")
                SqlcomItens.Append("LEFT JOIN " & geno001.pEsquemavinc & ".est0001 E ON E.e_codig = n2.nc_codpr WHERE n1.nt_nume = '")
                SqlcomItens.Append(nota1pp.pNt_nume & "' AND n2.nc_numer = n1.nt_nume ORDER BY n2.nc_seqitem ASC")
                'Dim daItens As NpgsqlDataAdapter = New NpgsqlDataAdapter(SqlcomItens.ToString, conItens)
                'Dim dstens As DataSet = New DataSet()

                Dim cmdItens As NpgsqlCommand = New NpgsqlCommand(SqlcomItens.ToString, conItens)
                'cmdItens.CommandText = SqlcomItens.ToString
                ' Criar datatable para leitura dos dados
                'Dim dtItens As DataTable = New DataTable


                'dtItens.Load(cmdItens.ExecuteReader())    ' Carrega o datatable para memoria
                DrItens = cmdItens.ExecuteReader          ' Executa leitura do commando
                While DrItens.Read()                   ' Ler Registros Selecionado no Paramentro
                    vnc_tipo = "S"
                    vnc_numer = DrItens(1).ToString
                    vnc_codpr = DrItens(2).ToString

                    vnc_produt = DrItens(3).ToString 'produt
                    If Trim(DrItens(33).ToString).Equals("") = False Then 'Se produt2 não está em branco
                        vnc_produt = DrItens(33).ToString
                    End If
                    If Trim(DrItens(34).ToString).Equals("") = False Then 'Se produt3 não está em branco - VEÍCULO
                        vnc_produt = DrItens(3).ToString & DrItens(34).ToString
                    End If
                    vnc_produt = Trim(vnc_produt)

                    vnc_cf = DrItens(4).ToString
                    vnc_cst = DrItens(5).ToString
                    vnc_und = DrItens(6).ToString
                    vnc_qtde = Round(DrItens(7), 6)
                    vnc_prunit = Round(DrItens(8), 4)
                    vnc_prtot = Round(DrItens(9), 2)  '(DrItens(8) * vnc_qtde)
                    vnc_alqicm = Round(DrItens(10), 2)
                    vnc_vlicm = Round(DrItens(11), 2)
                    vnc_bcalc = Round(DrItens(12), 2)
                    vnc_alqipi = Round(DrItens(13), 2)
                    vnc_vlipi = Round(DrItens(14), 2)
                    vnc_dtemis = DateValue(Now).ToOADate()
                    vnc_cdport = nota1pp.pNt_codig
                    vnc_unipi = Round(DrItens(15), 2)
                    vnc_vlsubs = Round(DrItens(16), 2)
                    vnc_basesub = Round(DrItens(17), 2)
                    vnc_cfop = DrItens(18)
                    vnc_frete = Round(DrItens(19), 2)
                    vnc_segur = Round(DrItens(20), 2)
                    vnc_vldesc = Round(DrItens(21), 2)
                    vnc_isento = Round(DrItens(22), 2)
                    vnc_produt2 = DrItens(23).ToString
                    vnc_ncm = DrItens(24).ToString
                    vnc_csosn = DrItens(25).ToString
                    vnc_icmsub = Round(DrItens(26), 2)
                    vnc_cdbarra = DrItens(27).ToString
                    If vnc_cdbarra.Length < 7 Then vnc_cdbarra = ""
                    vnc_indtot = DrItens(28)
                    vnc_seqitem = DrItens(29)
                    vnc_descpac = Round(DrItens(30), 2)
                    vnc_reduz = Round(DrItens(31), 2)
                    vnc_alqreduz = Round(DrItens(32), 2)
                    vnc_origem = DrItens(35)
                    vnc_vltrib = DrItens(36)
                    vnc_cstpis = DrItens(37).ToString
                    vnc_cstcofins = DrItens(38).ToString
                    vnc_cstipi = DrItens(39).ToString
                    vnc_prtotAux = Round((vnc_prtot - vnc_vldesc) - vnc_reduz, 2)
                    vnc_vlpis = 0.0
                    If genp001.pPis > 0 Then
                        If CInt(vnc_cstpis) < 5 Then vnc_vlpis = Round((vnc_prtotAux * genp001.pPis) / 100, 2)
                    End If

                    vnc_vlcofins = 0.0
                    If genp001.pConfin > 0 Then
                        If CInt(vnc_cstcofins) < 5 Then vnc_vlcofins = Round((vnc_prtotAux * genp001.pConfin) / 100, 2)
                    End If


                    cl_NFe.xmlGrupo_L(vnc_seqitem, vnc_codpr, vnc_produt, vnc_ncm, vnc_cfop, vnc_cst, vnc_origem, vnc_csosn, _
                                      vnc_und, vnc_qtde, vnc_prunit, vnc_prtot, vnc_vldesc, vnc_bcalc, vnc_basesub, _
                                      vnc_icmsub, vnc_vlsubs, vnc_alqicm, vnc_vlicm, vnc_alqipi, vnc_vlipi, vnc_frete, _
                                      vnc_vldesc, vnc_indtot, vnc_cdbarra, vnc_descpac, vnc_reduz, geno001.pCrt, vnc_vltrib, _
                                      vnc_cstpis, vnc_cstcofins, genp001.pPis, genp001.pConfin, vnc_vlpis, vnc_vlcofins, vnc_segur, s)
                End While

                conItens.Close()
            Catch ex As NpgsqlException
                MsgBox(ex.Message.ToString) : Return
            Catch ex As Exception
                MsgBox(ex.Message.ToString) : Return
            End Try

            ''''''''''''''''''''
            ' '* Inicia Tag's do Grupo L -  Produtos da Nfe '**


            ' Valores Totais da NFe Tag W ' - Nota4dd
            cl_NFe.xmlGrupo_W(nota4dd.pN4_basec, nota4dd.pN4_icms, nota4dd.pN4_bsub, nota4dd.pN4_icsub, nota4dd.pN4_tprod, _
                              nota4dd.pN4_frete, nota4dd.pN4_segu, nota4dd.pN4_desc, nota4dd.pN4_ipi, nota4dd.pN4_vlpis, _
                              nota4dd.pN4_vlcofins, nota4dd.pN4_outros, nota4dd.pN4_tgeral, nota4dd.pN4_totaltrib, s)

            ' '* Inicia Tag's do Grupo X -  Transportador da Nfe '**  - Nota5tt
            Dim vt_codp, codfret, mp_cpf, mp_cgc, mp_ie, mp_insc, mp_portad, mp_end, mp_cid As String
            Dim mp_uf, vt_placa, vt_antt, vt_uf, vt_marca, vt_espec As String
            vt_codp = "" : codfret = "" : mp_cpf = "" : mp_cgc = "" : mp_ie = "" : mp_insc = "" : mp_portad = ""
            mp_end = "" : mp_cid = "" : mp_uf = "" : vt_placa = "" : vt_antt = "" : vt_uf = "" : vt_marca = "" : vt_espec = ""
            Dim vt_pesol As Double = 0.0
            Dim vt_pesob As Double = 0.0
            Dim vt_qtde As Integer


            vt_codp = nota5tt.pT_codp
            codfret = nota5tt.pT_tpfret
            vt_marca = nota5tt.pT_marca
            vt_espec = nota5tt.pT_espec
            vt_placa = nota5tt.pT_placa
            vt_antt = nota5tt.pT_antt
            vt_uf = nota5tt.pT_uf
            vt_qtde = nota5tt.pT_qtde
            vt_pesol = nota5tt.pT_pesol
            vt_pesob = nota5tt.pT_pesob
            mp_cpf = cliTranportador.pCpf
            mp_cgc = cliTranportador.pCgc
            mp_insc = cliTranportador.pInsc
            mp_portad = cliTranportador.pPortad
            mp_end = cliTranportador.pEnder
            mp_uf = cliTranportador.pCoduf
            mp_cid = cliTranportador.pMun

            cl_NFe.xmlGrupo_X(vt_codp, codfret, mp_cpf, mp_cgc, mp_insc, mp_portad, mp_end, mp_cid, mp_uf, vt_placa, _
                        vt_antt, vt_uf, vt_qtde, vt_espec, vt_marca, vt_pesol, vt_pesob, s)

            ' '* Inicia Tag's do Grupo Z -  Informações Complementares da Nfe '** - Nota6hh
            cl_NFe.xmlGrupo_Z(nota6hh.pC_compl1, nota6hh.pC_compl2, nota6hh.pC_compl3, nota6hh.pC_compl4, nota6hh.pC_compl5, _
                              nota6hh.pC_compl6, nota6hh.pC_compl7, nota6hh.pC_compl8, nota6hh.pC_compl9, s)


            cl_NFe.Fecha_xml_infNFe(s)
            cl_NFe.Fecha_xml(s)

            s.Close()
            fsxml.Close()


            Try
                _frmGeraNFe.frmGeraNFeRef.clickGerar = True
                _frmGeraNFe.frmGeraNFeRef.genp001 = genp001

                xmlArquivo.Remove(0, xmlArquivo.ToString.Length)
                xmlArquivo.Append(_clFuncoes.LerArquivoSalvo(ArqTemp))
                cl_BD.altXmlNota1pp(nota1pp.pNt_nume, xmlArquivo, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)

                xmlPath = genp001.pathEnvioXML & "\" & chaveNFe & "-nfe.xml"
                File.Copy(ArqTemp, xmlPath, True)
            Catch ex As Exception
                MsgBox("ERRO ao copiar o XML para """ & xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
            End Try

            buscaArquivosXML()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)

        End Try

    End Sub

    Private Function buscaArquivosXML() As Boolean

        Me.lbl_mensagem.Text = "Iniciando Validação da NFe..."
        Me.Refresh()
        System.Threading.Thread.Sleep(2000)
        strXmlRetorno = _clFuncoes.lerXmlRetorno(chaveNFe, genp001)


        If strXmlRetorno.Equals("") Then 'Se retornou nada...
            System.Threading.Thread.Sleep(500)
            strArqErroRetorno = _clFuncoes.lerArqErroRetorno(chaveNFe, genp001)
            Me.rtb_mensagem.Text = strArqErroRetorno
            Me.Refresh() : Me.btn_nfe.Enabled = False
            If strArqErroRetorno.Equals("") Then Me.Close()
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
                Me.btn_nfe.Enabled = False
                Return False
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
                            Me.Refresh() : Me.btn_nfe.Enabled = False

                        End Try

                    Catch ex As Exception
                        MsgBox("ERRO ao Arquivo de Recibo processado :: " & ex.Message, MsgBoxStyle.Exclamation)
                        Me.btn_nfe.Enabled = False
                        Return False
                    End Try

                    _frmGeraNFe.frmGeraNFeRef.mProtocolo = strXmlProtocolo

                    cl_BD.altWebrecNota1pp(nota1pp.pNt_nume, strXmlRec, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altHrwebNota1pp(nota1pp.pNt_nume, strXmlHora, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altLoteNota1pp(nota1pp.pNt_nume, numLotRetorno, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altProtoNota1pp(nota1pp.pNt_nume, strXmlProtocolo, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    If strXmlStatus.Equals("100") Then
                        cl_BD.altStatusNota1pp(nota1pp.pNt_nume, strXmlStatus, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    ElseIf strXmlStatus.Equals("110") Then
                        cl_BD.altStatusNota1pp(nota1pp.pNt_nume, strXmlStatus, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                        cl_BD.altTipoNt_Nota1pp(nota1pp.pNt_nume, "D", geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    End If
                    Me.lbl_mensagem.Text = strXmlStatus & " - " & strXmlMotivo
                    Me.Refresh()

                    System.Threading.Thread.Sleep(1000) '1 segundo...
                    xmlArquivo.Remove(0, xmlArquivo.ToString.Length)
                    xmlArquivo.Append(_clFuncoes.lerXmlEnviado(anoMesPath, chaveNFe, genp001))
                    cl_BD.altXmlNota1pp(nota1pp.pNt_nume, xmlArquivo, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)


                    If btn_nfe.Enabled Then MessageBox.Show("Nota Gerada c/ Sucessso !", "Finalização", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    cl_BD.altSituacaoPedido_Orca1(Me.txt_pedido.Text, 5, MdlConexaoBD.conectionPadrao)
                    Me.Close()
                Catch ex As Exception
                    MsgBox("ERRO ao Ler Lote Recebido """ & xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
                    Return False
                End Try


            Else

                strXmlLoteRecebido = _clFuncoes.lerXmlLoteRecebidoErro(numLotRetorno, genp001)
                rtb_mensagem.Text = strXmlLoteRecebido
                Me.Refresh() : Me.btn_nfe.Enabled = False
                If strXmlLoteRecebido.Equals("") Then Me.Close()
            End If

        End If

        Return True
    End Function

    Private Sub LerRetornoXMl()
        strXmlRetorno = _clFuncoes.lerXmlRetorno(chaveNFe, genp001)
    End Sub

    Private Sub trazGenoSelecionado()

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
            sqlGeno.Append("FROM geno001 WHERE g_codig = 'G00" & CodEstab & "'") '24

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

    Private Sub trazGenpSelecionado()

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
            sqlGenp.Append("gp_retornoxml, gp_enviadoxml, gp_pauta, gp_descontonfe  FROM genp001 WHERE gp_geno = @gp_geno")

            cmdGenp = New NpgsqlCommand(sqlGenp.ToString, conection)
            cmdGenp.Parameters.Add("@gp_geno", "G00" & CodEstab)
            drGenp = cmdGenp.ExecuteReader


            While drGenp.Read

                geno001.zeraValores()
                genp001.pGeno = "G00" & CodEstab
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
                genp001.pauta = drGenp(44)
                genp001.descontonfe = drGenp(45)



                chk_pauta.Checked = genp001.pauta

            End While


            drGenp.Close() : conection.ClearPool() : conection.Close()
        Catch ex As Exception

            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
            geno001.zeraValores()

        End Try

        cmdGenp.CommandText = "" : sqlGenp.Remove(0, sqlGenp.ToString.Length)
        conection = Nothing : cmdGenp = Nothing : drGenp = Nothing : sqlGenp = Nothing




    End Sub

    Private Sub Frm_NFEAutorizanota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        Me.dtp_dtSaida.Text = DateValue(agora)
        Me.cbo_tiponfe.SelectedIndex = 0
        Me.cbo_transportador.SelectedIndex = 0
        vnt_dtemis = DateValue(agora)
        Me.cbo_estabelecimento = _clFuncoes.PreenchComboLoja(Me.cbo_estabelecimento, MdlConexaoBD.conectionPadrao)
        Me.cbo_estabelecimento.SelectedIndex = 0
        Dim mUfEstabelecimento As String = MdlEmpresaUsu._uf
        Me.chk_pauta.Checked = MdlEmpresaUsu.genp001.pauta
        Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopSaidas(mUfEstabelecimento, mUfEstabelecimento, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
        Me.cbo_placa = _clFuncoes.PreenchComboPlacaVeicNFe(Me.cbo_placa, MdlConexaoBD.conectionPadrao)

        'INICIO do Tratamento do DataGridView

        'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
        'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
        dtgItensResumo.Columns.Add("r4_numero", "r4_numero") : dtgItensResumo.Columns.Add("r4_cfop", "r4_cfop")
        dtgItensResumo.Columns.Add("r4_cst", "r4_cst") : dtgItensResumo.Columns.Add("r4_aliq", "r4_aliq")
        dtgItensResumo.Columns.Add("r4_tprod", "r4_tprod") : dtgItensResumo.Columns.Add("r4_tdesc", "r4_tdesc")
        dtgItensResumo.Columns.Add("r4_tfrete", "r4_tfrete") : dtgItensResumo.Columns.Add("r4_tseguro", "r4_tseguro")
        dtgItensResumo.Columns.Add("r4_toutrasdesp", "r4_toutrasdesp") : dtgItensResumo.Columns.Add("r4_bcalc", "r4_bcalc")
        dtgItensResumo.Columns.Add("r4_icms", "r4_icms") : dtgItensResumo.Columns.Add("r4_isento", "r4_isento")
        dtgItensResumo.Columns.Add("r4_outras", "r4_outras") : dtgItensResumo.Columns.Add("r4_ipi", "r4_ipi")
        dtgItensResumo.Columns.Add("r4_tgeral", "r4_tgeral")

        'FIM do Tratamento do DataGridView

        Try
            fsxml = New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
            s = New StreamWriter(fsxml)
        Catch ex As Exception

        End Try



        '**********
        If lbl_numeroNota1pp.Text.Equals("") = False Then

            CodEstab = MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2)
            cbo_estabelecimento.SelectedIndex = _clFuncoes.trazIndexCboLoja(CodEstab, cbo_estabelecimento)
            cbo_estabelecimento.Enabled = False

            cboEstabLeave() : cboEstabLostFocus()

        End If

    End Sub

    Private Sub Frm_NFEAutorizanota_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            fsxml.Close()
            Me.Close()
        End If
    End Sub

    Private Sub cbo_estabelecimento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.Leave

        cboEstabLeave()

    End Sub

    Private Sub cboEstabLeave()

        trazGenpSelecionado()

        If genp001.pAmb = "1" Then
            Me.lbl_ambiente.Text = "Produção"
        End If
        If genp001.pAmb = "2" Then
            Me.lbl_ambiente.Text = "Homologação"
        End If
        If genp001.pContf = "1" Then
            Me.lbl_tipoemissao.Text = "Normal"
        End If
        If genp001.pContf = "3" Then
            Me.lbl_tipoemissao.Text = "Contingência(SCAN)"
        End If
        If genp001.pContf = "4" Then
            Me.lbl_tipoemissao.Text = "Contigência DPEC"
        End If

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

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then


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

                    ''preenche CBO CFOP...
                    'If Not mbUf.Equals("") Then
                    '    Me.cbo_nfeCfop = PreenchComboCFOP(mbUf, Me.cbo_nfeCfop)
                    'End If
                    Try

                        'preenche CBO CFOP...
                        If Not mbUf.Equals("") Then

                            Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopSaidas(geno001.pUf, mbUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                        End If

                        Me.cbo_nfeCfop.Text = "" : Me.cbo_nfeCfop.SelectedIndex = -1
                    Catch ex As Exception
                    End Try


                    'Me.cbo_nfcfop.SelectedIndex = -1
                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()

                Catch ex As Exception

                End Try

            Else  ' Consulta pelo codigo do cliente...


                If trazFornecedor(Me.txt_codPart.Text) Then

                    'preenche CBO CFOP...
                    If Not mbUf.Equals("") Then
                        Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopSaidas(geno001.pUf, mbUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                    End If


                    Dim lShouldReturn As Boolean
                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing

                Else


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
                            Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopSaidas(geno001.pUf, mbUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                        End If

                        'Me.cbo_nfcfop.SelectedIndex = -1
                        Me.txt_nomePart.Focus()
                        Me.txt_nomePart.SelectAll()

                    Catch ex As Exception

                    End Try
                End If

            End If
        End If


    End Sub

    Private Function trazFornecedor(ByVal codFornec As String) As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        Dim pesquisa As String = codFornec.ToUpper

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try
            SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc, p_uf, p_end, p_cid, p_cep, ") ' 8
            SqlParticipante.Append("p_fone, p_consumo, p_isento FROM cadp001 WHERE p_cod = '" & pesquisa & "' ORDER BY p_portad ASC")
            CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDGENOV)
            drParticipante = CmdParticipante.ExecuteReader

            If drParticipante.HasRows = False Then
                Return False

            Else

                While drParticipante.Read

                    mCodPart = drParticipante(0).ToString
                    mNomePart = drParticipante(1).ToString
                    mbCNPJ = drParticipante(2).ToString
                    If Trim(mbCNPJ).Equals("") Then mbCNPJ = drParticipante(3).ToString
                    mbInscr = drParticipante(4).ToString
                    mbUf = drParticipante(5).ToString
                    mEnderecoPart = drParticipante(6).ToString
                    mCidadePart = drParticipante(7).ToString
                    mCepPart = drParticipante(8).ToString
                    mFonePart = drParticipante(9).ToString

                End While
                drParticipante.Close()
                Me.txt_nomePart.Text = mNomePart


            End If

        Catch ex As Exception
        End Try

        CmdParticipante.CommandText = "" : SqlParticipante.Remove(0, SqlParticipante.ToString.Length)
        CmdParticipante = Nothing : SqlParticipante = Nothing : drParticipante = Nothing
        oConnBDGENOV.ClearPool() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing



        Return True
    End Function

    Private Sub Frm_NFEAutorizanota_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            s.Dispose()
            File.Delete(ArqTemp)
        Catch ex As Exception
        End Try
    End Sub

    Private Function PreenchComboCFOP(ByVal ufFornec As String, ByVal cboCFOP As Object) As ComboBox
        Dim oConnCFOP As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
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
            UF = geno001.pUf
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
                If mbUf = geno001.pUf Then
                    If Mid(mNFe_Cfop, 1, 1) <> "5" Then
                        MessageBox.Show("CFOP Invalido p/ Dentro do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        cboCFOP.Focus()
                        Return False

                    End If
                End If
                If mbUf <> geno001.pUf Then
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

    Private Sub btn_nfe_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nfe.Leave

    End Sub

    Private Sub cbo_estabelecimento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.LostFocus

        cboEstabLostFocus()

    End Sub

    Private Sub cboEstabLostFocus()

        trazGenoSelecionado()
        lbl_emitente.Text = geno001.pGeno

    End Sub

    Private Sub cbo_tiponfe_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tiponfe.Leave
        If cbo_tiponfe.SelectedIndex = 0 Then
            Me.txt_pedido.MaxLength = 8
        End If
    End Sub

    Private Sub txt_codPart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codPart.TextChanged

    End Sub

    Private Sub txt_pedido_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pedido.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_pedido_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pedido.Leave

        Try
            If Trim(txt_pedido.Text).Equals("") Then
                MsgBox("Preencha o Numero de Pedido, por favor", MsgBoxStyle.Exclamation) : Me.txt_pedido.Text = "" : Return
            End If
            Me.txt_pedido.Text = String.Format("{0:D8}", CInt(Me.txt_pedido.Text))
            If _clFuncoes.existNumPedido(Me.txt_pedido.Text, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao) = False Then
                MsgBox("Numero de Pedido não Existe", MsgBoxStyle.Exclamation) : Me.txt_pedido.Text = "" : Return
            End If

            Select Case _clFuncoes.trazSituacaoPedido(Me.txt_pedido.Text, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                Case 6
                    MsgBox("Pedido está Cancelado! Escolha outro Pedido", MsgBoxStyle.Exclamation) : Me.txt_pedido.Text = "" : Return
                    'Case 5
                    '    MsgBox("Já foi tirado uma ""Nota Fiscal"" para este pedido! Escolha outro Pedido", MsgBoxStyle.Exclamation) : Me.txt_pedido.Text = "" : Return
                    'Case 4
                    '    MsgBox("Já foi tirado um ""Cupom Fiscal"" para este pedido! Escolha outro Pedido", MsgBoxStyle.Exclamation) : Me.txt_pedido.Text = "" : Return
            End Select

            mtipoPag = _clFuncoes.trazValorColunaOrca1pp(Me.txt_pedido.Text, "nt_tipo2", geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)

            mExisteNota1pp = _clFuncoes.existPedidoNota1pp(Me.txt_pedido.Text, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
            If mExisteNota1pp Then
                mNumNota1ppExist = _clFuncoes.trazNumNota1ppPorPedido(Me.txt_pedido.Text, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                mCodPartNota1ppExist = _clFuncoes.trazCodPartNota1ppPorPedido(Me.txt_pedido.Text, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
            End If


            Me.lbl_totalNota.Text = Format(_clFuncoes.trazTotPedidoOrca4dd(Me.txt_pedido.Text, MdlConexaoBD.conectionPadrao), "###,##0.00")
            Me.lbl_qtdeItens.Text = Format(_clFuncoes.trazCountItensOrca2cc(Me.txt_pedido.Text, MdlConexaoBD.conectionPadrao), "###,###.##")

            If Me.txt_pedido.Text.Equals(nota1pp.pNt_orca) = False Then
                zeraValores()
            End If
        Catch ex As Exception
            Me.txt_pedido.Text = String.Format("{0:D8}", 0)
        End Try

    End Sub

    Private Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged

        Try
            CodEstab = Mid(cbo_estabelecimento.SelectedItem, 1, 2)
        Catch ex As Exception
            CodEstab = ""
        End Try
    End Sub

    Private Sub cbo_nfeCfop_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_nfeCfop.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then e.Handled = True : SendKeys.Send("{TAB}")
    End Sub

    Private Sub cbo_nfeCfop_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_nfeCfop.Leave

        mNFe_Cfop = ""
        If cbo_nfeCfop.SelectedIndex >= 0 Then mNFe_Cfop = cbo_nfeCfop.Text.Substring(0, 5)
        Try

            If Not mbUf.Equals("") Then

                If mbUf = geno001.pUf Then
                    If Mid(mNFe_Cfop, 1, 1) <> "5" Then

                        MessageBox.Show("CFOP Invalido p/ Dentro do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        Me.cbo_nfeCfop.Focus() : Me.cbo_nfeCfop.SelectedIndex = -1 : Me.cbo_nfeCfop.SelectAll() : Return

                    End If
                End If


                If mbUf <> geno001.pUf Then
                    If Mid(mNFe_Cfop, 1, 1) = "5" Then

                        MessageBox.Show("CFOP Invalido p/ Fora do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        Me.cbo_nfeCfop.Focus() : Me.cbo_nfeCfop.SelectedIndex = -1 : Me.cbo_nfeCfop.SelectAll() : Return

                    End If
                End If
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbo_transportador_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_transportador.SelectedIndexChanged

        Select Case Me.cbo_transportador.SelectedIndex
            Case 0 'Emitente
                Me.txt_placa.Text = "" : Me.txt_placa.Visible = False
                Me.cbo_placa.SelectedIndex = -1 : Me.cbo_placa.Visible = True
            Case 1, 2 'Destinatário ou Terceiro
                Me.txt_placa.Text = "" : Me.txt_placa.Visible = True
                Me.cbo_placa.SelectedIndex = -1 : Me.cbo_placa.Visible = False
            Case 3
                Me.txt_placa.Text = "" : Me.txt_placa.Visible = False
                Me.cbo_placa.SelectedIndex = -1 : Me.cbo_placa.Visible = False
        End Select
    End Sub
End Class