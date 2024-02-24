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

    Dim vnt_dtemis As Date
    Public mbUf, mbCNPJ, mbInscr, mCodPart, mNomePart, mEnderecoPart, mCidadePart As String
    Public mCepPart, mFonePart As String

    Public _mPesquisaForn As Boolean = False 'Serve para configura os campos CodFornec e NomeFornec
    Public mChaveNFe As String = ""
    Private _loja As String = Mid(MdlEmpresaUsu._codigo, MdlEmpresaUsu._codigo.Length - 1, 2)
    Dim CodEstab As String = ""
    Dim mAmb, mcontf, mSeqNFe As String
    Dim mExisteNota1pp As Boolean = False
    Dim mNumNota1ppExist As String = "", mCodPartNota1ppExist As String = ""


    'Inicio da Criação dos Objetos...
    Private _NFeS As New Cl_NFeSaida
    Private _NFeTrat As New Cl_TratamentoNFe
    Private _clXml As New Cl_TratamentoXML
    Private geno001 As New Cl_Geno
    Private genp001 As New Cl_Genp001
    Private cadp001 As New Cl_Cadp001, mCliente As New Cl_Cadp001
    Private produto As New Cl_Est0001
    Private _clFuncoes As New ClFuncoes
    Private _clBD As New Cl_bdMetrosys

    Dim frmMsgRtbox As New Frm_MsgRTBox
    Public Shared _frmREf As New Frm_NFEAutorizanota
    Private buscaCliente As New Frm_buscaFornecedor
    Private _BuscaForn As New Frm_buscaFornecedor
    Private buscaProduto As New Frm_buscaProdNFe
    Private _frmGeraNFe As New Frm_GeraNotasFiscais
    'Fim da Criação dos Objetos


#Region "** Procedimento de Tratamentos Repetitivos  ** "

    Private Sub TratamentoIndOper()

        'Tratamento do IndOper:
        Select Case _clXml.digCFOP
            Case "1", "5"
                _NFeS.pNt1pp.pNt_indOper = 1
            Case "2", "6"
                _NFeS.pNt1pp.pNt_indOper = 2
            Case "3", "7"
                _NFeS.pNt1pp.pNt_indOper = 3
        End Select

    End Sub

    Private Sub TratamentoIndFinal()

        'Tratamento do IndOper:
        _NFeS.pNt1pp.pNt_indFinal = 0
        Select Case geno001.pAtivEmpresa
            Case 0, 2 '0 - Atacado; '2 - Industria
                _NFeS.pNt1pp.pNt_indFinal = 0
                If mCliente.pIsento Then
                    _NFeS.pNt1pp.pNt_indFinal = 1
                ElseIf mCliente.pConsumo.Equals("S") Then
                    _NFeS.pNt1pp.pNt_indFinal = 1
                End If

            Case 1 '1 - Varejo
                _NFeS.pNt1pp.pNt_indFinal = 1
        End Select

    End Sub

    Private Sub TratamentoIndDest()


        'Tratamento do IndDest:
        _NFeS.pNt1pp.pNt_indDest = 9
        Select Case geno001.pAtivEmpresa
            Case 0, 2 '0 - Atacado; '2 - Industria
                _NFeS.pNt1pp.pNt_indDest = 1
                If mCliente.pCarac.Equals("F") Then _NFeS.pNt1pp.pNt_indDest = 9
                If mCliente.pIsento Then _NFeS.pNt1pp.pNt_indDest = 2

            Case 1 '1 - Varejo
                If mCliente.pCarac.Equals("J") Then _NFeS.pNt1pp.pNt_indDest = 1
                If mCliente.pCarac.Equals("F") Then _NFeS.pNt1pp.pNt_indDest = 9
                If mCliente.pIsento Then _NFeS.pNt1pp.pNt_indDest = 2

        End Select

    End Sub

    Private Sub TratamentoIndPres()

        'Tratamento do IndDest:
        _NFeS.pNt1pp.pNt_indPres = 9
        Select Case geno001.pAtivEmpresa
            Case 0, 2 '0 - Atacado; '2 - Industria
                If mCliente.pCarac.Equals("F") Then _NFeS.pNt1pp.pNt_indPres = 1

            Case 1 '1 - Varejo
                _NFeS.pNt1pp.pNt_indPres = 1

        End Select

    End Sub

    Private Sub TratamentoFinNFe()
        '1-Normal,2-Complementar,3-Ajuste,4-Devolucao-Retorno
        _NFeS.pNt1pp.pNt_finNFe = 1
        Select Case _NFeS.pNt1pp.pNt_cfop.Substring(_NFeS.pNt1pp.pNt_cfop.Length - 3, 3).ToString
            Case "202", "209"
                _NFeS.pNt1pp.pNt_finNFe = 4
        End Select

    End Sub

#End Region

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



        'INICIO Atribuindo valores ao _NFeS.pNt1pp...
        _NFeS.pNt1pp.pTipo_nt = "P"
        _NFeS.pNt1pp.pNt_tipo = "S"
        _NFeS.pNt1pp.pNt_nume = mNumNota1ppExist
        If mExisteNota1pp = False Then
            _NFeS.pNt1pp.pNt_nume = _clFuncoes.trazVlrColunaGenp001("G00" & CodEstab, "gp_sai", conexao.ConnectionString)
            Dim gp_sai As String = CInt(_NFeS.pNt1pp.pNt_nume) + 1
            gp_sai = String.Format("{0:D9}", CInt(gp_sai))
            _clBD.altGp_SaiGenp001(gp_sai, "G00" & CodEstab, conexao, transacao)
            gp_sai = Nothing
        End If
        _NFeS.pRes01.r4_numero = _NFeS.pNt1pp.pNt_nume
        _NFeS.pRes02.r4_numero = _NFeS.pNt1pp.pNt_nume
        _NFeS.pRes03.r4_numero = _NFeS.pNt1pp.pNt_nume

        _NFeS.pNt1pp.pNt_serie = _clFuncoes.trazVlrColunaGenp001("G00" & CodEstab, "gp_serie", conexao.ConnectionString)
        _NFeS.pNt1pp.pNt_natur = Mid(Me.cbo_nfeCfop.SelectedItem, 9, 40)
        _NFeS.pNt1pp.pNt_cfop = Mid(Me.cbo_nfeCfop.SelectedItem, 1, 5)
        _NFeS.pNt1pp.pNt_geno = "G00" & CodEstab
        If mExisteNota1pp Then
            trazFornecedor(mCodPartNota1ppExist)
        End If
        _NFeS.pNt1pp.pNt_codig = mCodPart
        _NFeS.pNt1pp.pNt_dtemis = Date.Now
        _NFeS.pNt1pp.pNt_dtsai = dtp_dtSaida.Value
        If _NFeS.pNt1pp.pNt_dtsai < _NFeS.pNt1pp.pNt_dtemis Then _NFeS.pNt1pp.pNt_dtemis = _NFeS.pNt1pp.pNt_dtsai
        _NFeS.pNt1pp.pNt_emiss = False
        _NFeS.pNt1pp.pNt_cnpj = mbCNPJ
        _NFeS.pNt1pp.pNt_insc = mbInscr
        _NFeS.pNt1pp.pNt_uf = mbUf
        _NFeS.pNt1pp.pNt_orca = Me.txt_pedido.Text

        TratamentoIndFinal()
        TratamentoIndOper()
        TratamentoIndDest()
        TratamentoIndPres()
        TratamentoFinNFe()

        'Incluindo _NFeS.pNt1pp...
        If mExisteNota1pp = False Then _clBD.incNota1pp(_NFeS.pNt1pp, geno001, conexao, transacao)
        _NFeS.pNt1pp.pNt_id = _clBD.trazIdNota1pp(conexao, _NFeS.pNt1pp.pNt_nume)
        'FIM Atribuindo valores ao _NFeS.pNt1pp...
        geno001.pPis = Round(geno001.pPis, 2)
        geno001.pCofins = Round(geno001.pCofins, 2)


        Dim cfopRegistro As String = ""
        _NFeS.pNt5tt.pT_qtde = 0
        _NFeS.dtgItensResumo.Rows.Clear() : _NFeS.dtgItensResumo.Refresh()
        'INICIO Tratamento do _NFeS.pNt2cc...
        Sqlcomm.Append("SELECT no_codpr, e.e_produt, e.e_clf, e.e_cst, no_und, no_qtde, no_prunit, no_prtot, ") '7
        Sqlcomm.Append("no_alqicm, no_vlicms, no_vlsub, no_alqsub, no_baseicm, no_basesub, no_pesobruto, no_pesoliquido, ") '15
        Sqlcomm.Append("e.e_ncm, no_alqdesc, e.e_cfv, e.e_grupo, al.alq_interna, al.alq_externa, e.e_cstipi, e.e_produt2, ") '23
        Sqlcomm.Append("e.e_produt3, e.e_reduz, e.e_pauta, no_pruvenda  FROM " & geno001.pEsquemaestab & ".orca2cc, ")
        Sqlcomm.Append(geno001.pEsquemavinc & ".est0001 e LEFT JOIN aliquotas al ON al.alq_tipo = e.e_tipo WHERE no_codpr = ")
        Sqlcomm.Append("e.e_codig AND no_orca = '" & _NFeS.pNt1pp.pNt_orca & "'")
        oCmd = New NpgsqlCommand(Sqlcomm.ToString, conexaoConsultas)
        dr = oCmd.ExecuteReader

        'Atribuindo valores ao _NFeS.pNt2cc...
        _NFeS.pNt2cc.pNc_tipo = "S"
        _NFeS.pNt2cc.pNc_numer = _NFeS.pNt1pp.pNt_nume
        _NFeS.pNt2cc.pNc_dtemis = _NFeS.pNt1pp.pNt_dtemis
        _NFeS.pNt2cc.pNc_cdport = _NFeS.pNt1pp.pNt_codig
        _NFeS.pNt2cc.pNc_ntid = _NFeS.pNt1pp.pNt_id
        _NFeS.pNt2cc.pNc_indtot = 1
        _NFeS.pNt2cc.pNc_seqitem = 0

        While dr.Read


            _NFeS.pNt2cc.pNc_codpr = dr(0).ToString
            '!!! Teste...
            'If _NFeS.pNt2cc.pNc_codpr.Equals("00032") OrElse _NFeS.pNt2cc.pNc_codpr.Equals("00032") Then _NFeS.pNt2cc.pNc_codpr = _NFeS.pNt2cc.pNc_codpr
            _NFeS.pNt2cc.pNc_produt = dr(23).ToString 'descrição para NFe
            If Trim(_NFeS.pNt2cc.pNc_produt).Equals("") Then ' Se a descrição para NFe estiver em branco

                _NFeS.pNt2cc.pNc_produt = dr(24).ToString 'descrição para Automóvel
                If Trim(_NFeS.pNt2cc.pNc_produt).Equals("") Then ' Se a descrição para Automóvel estiver em branco
                    _NFeS.pNt2cc.pNc_produt = dr(1).ToString

                End If
            End If
            _NFeS.pNt2cc.pNc_cf = dr(2)
            _NFeS.pNt2cc.pNc_cst = Format(dr(3), "00")
            cfv = dr(18)
            grupo = dr(19)
            mAlqInterna = dr(20)
            mAlqExterna = dr(21)
            _NFeS.pNt2cc.pNc_und = dr(4).ToString
            _NFeS.pNt2cc.pNc_qtde = dr(5)

            If chk_pauta.Checked Then 'Se tiver marcado para usar PAUTA..
                _NFeS.pNt2cc.pNc_prunit = dr(26) 'e_pauta

                'Tratamento da PAUTA....
                If _NFeS.pNt2cc.pNc_prunit <= 0 Then
                    MsgBox("Produto """ & _NFeS.pNt2cc.pNc_codpr & " - " & Mid(_NFeS.pNt2cc.pNc_produt, 1, 15) & """ com PAUTA <= ZERO! Por Favor alterar no cadastro do Produto", MsgBoxStyle.Exclamation)
                    transacao.Rollback() : Return
                End If
                'END PAUTA......
            Else

                _NFeS.pNt2cc.pNc_prunit = dr(6) 'no_prunit
                If genp001.descontonfe = False Then _NFeS.pNt2cc.pNc_prunit = dr(27) 'no_pruvenda
            End If

            _NFeS.pNt2cc.pNc_prtot = Round(_NFeS.pNt2cc.pNc_qtde * _NFeS.pNt2cc.pNc_prunit, 2) 'dr(7)
            _NFeS.pNt2cc.pNc_alqicm = dr(8)
            _NFeS.pNt2cc.pNc_alqipi = genp001.pTxipi
            _NFeS.pNt2cc.pNc_vlipi = 0.0
            _NFeS.pNt2cc.pNc_vlicm = dr(9)
            _NFeS.pNt2cc.pNc_unipi = 0.0
            _NFeS.pNt2cc.pNc_vlsubs = dr(10)
            _NFeS.pNt2cc.pNc_alqsub = dr(11)
            _NFeS.pNt2cc.pNc_cfop = Mid(_NFeS.pNt1pp.pNt_cfop, 1, 1) & Mid(_NFeS.pNt1pp.pNt_cfop, 3, 3)
            _NFeS.pNt2cc.pNc_bcalc = dr(12)
            _NFeS.pNt2cc.pNc_basesub = dr(13)
            _NFeS.pNt2cc.pNc_frete = 0.0
            _NFeS.pNt2cc.pNc_segur = 0.0

            vnc_alqDesconto = dr(17)
            _NFeS.pNt2cc.pNc_vldesc = 0.0
            If vnc_alqDesconto > 0 Then _NFeS.pNt2cc.pNc_vldesc = Round((_NFeS.pNt2cc.pNc_prtot * vnc_alqDesconto) / 100, 2)
            If genp001.descontonfe = False Then vnc_alqDesconto = 0.0 : _NFeS.pNt2cc.pNc_vldesc = 0.0

            _NFeS.pNt2cc.pNc_isento = 0.0
            If cfv = 4 Then _NFeS.pNt2cc.pNc_isento = _NFeS.pNt2cc.pNc_prtot
            _NFeS.pNt2cc.pNc_csosn = ""
            _NFeS.pNt2cc.pNc_vltrib = 0.0
            _NFeS.pNt2cc.pNc_descpac = 0.0

            _NFeS.pNt2cc.pNc_alqreduz = dr(25)
            _NFeS.pNt2cc.pNc_reduz = 0.0
            If _NFeS.pNt2cc.pNc_alqreduz > 0 Then _NFeS.pNt2cc.pNc_reduz = Round((_NFeS.pNt2cc.pNc_prtot * _NFeS.pNt2cc.pNc_alqreduz) / 100, 2)

            vnc_vlPis = 0.0
            vnc_vlCofins = 0.0


            'Tratamento do NCM....
            _NFeS.pNt2cc.pNc_ncm = dr(16).ToString
            If _NFeS.pNt2cc.pNc_ncm.Length <> 8 Then
                MsgBox("Produto """ & _NFeS.pNt2cc.pNc_codpr & """ corrigir NCM!  Por Favor alterar no cadastro do Produto", MsgBoxStyle.Exclamation)
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

                    _NFeS.pNt2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, _NFeS.pNt1pp.pNt_cfop, 0)
                    If cfv = 1 Or cfv = 4 Then 'CSOSN 102
                        ' /Icms12 - Produto Trib. p/ Simples Nacional s/ Permissao de Credito **
                        _NFeS.pNt2cc.pNc_csosn = "102"
                        _NFeS.pNt2cc.pNc_alqicm = 0
                        _NFeS.pNt2cc.pNc_vlicm = 0 : _NFeS.pNt2cc.pNc_unipi = 0
                        _NFeS.pNt2cc.pNc_vlsubs = 0 : _NFeS.pNt2cc.pNc_alqsub = 0
                        _NFeS.pNt2cc.pNc_bcalc = 0 : _NFeS.pNt2cc.pNc_basesub = 0
                    End If

                    If cfv = 3 Then 'CSOSN 500 Produto com substitui‡Æo
                        _NFeS.pNt2cc.pNc_csosn = "500"
                        _NFeS.pNt2cc.pNc_alqicm = 0
                        _NFeS.pNt2cc.pNc_vlicm = 0 : _NFeS.pNt2cc.pNc_unipi = 0
                        _NFeS.pNt2cc.pNc_vlsubs = 0 : _NFeS.pNt2cc.pNc_alqsub = 0
                        _NFeS.pNt2cc.pNc_bcalc = 0 : _NFeS.pNt2cc.pNc_basesub = 0
                    End If



                Case "2" '1 - Simples Nacional com Retenção
                    _NFeS.pNt2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, _NFeS.pNt1pp.pNt_cfop, 0)
                    Select Case cfv
                        Case 1
                            _NFeS.pNt2cc.pNc_csosn = "202"
                            _NFeS.pNt2cc.pNc_vlsubs = 0 : _NFeS.pNt2cc.pNc_alqsub = 0
                            _NFeS.pNt2cc.pNc_basesub = 0
                        Case 3 'Produto com substitui‡Æo
                            _NFeS.pNt2cc.pNc_csosn = "500"
                        Case 4
                            _NFeS.pNt2cc.pNc_csosn = "102"
                    End Select

                Case "3" '3 - Regime Normal

                    If cfv = 3 Then
                        _NFeS.pNt2cc.pNc_alqicm = 0.0 : _NFeS.pNt2cc.pNc_vlicm = 0.0
                        _NFeS.pNt6hh.pC_compl5 = "(*) ICMS PAGO ANTEC CONF.DECR. N.6551/85 E 9483/97"
                        _NFeS.pNt2cc.pNc_produt = RTrim(_NFeS.pNt2cc.pNc_produt) & " (*)"
                        _NFeS.pNt4dd.pN4_outras = _NFeS.pNt4dd.pN4_outras + Round((_NFeS.pNt2cc.pNc_qtde * _NFeS.pNt2cc.pNc_prunit), 2)
                    End If

                    If _NFeS.pNt1pp.pNt_cfop.Substring(0, 1).Equals("5") Then
                        _NFeS.pNt2cc.pNc_alqicm = mAlqInterna
                    ElseIf _NFeS.pNt1pp.pNt_cfop.Substring(0, 1).Equals("6") Then
                        _NFeS.pNt2cc.pNc_alqicm = mAlqExterna
                    End If

                    _NFeS.pNt2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, _NFeS.pNt1pp.pNt_cfop, 0)

            End Select
            _NFeS.pNt2cc.pNc_desc = dr(17)


            'Calculando Tributos......................................................................
            'ICMS
            If _NFeS.pNt2cc.pNc_alqicm <= 0 Then
                _NFeS.pNt2cc.pNc_vlicm = 0
            Else

                Select Case _NFeS.pNt2cc.pNc_cst
                    Case "20"
                        _NFeS.pNt2cc.pNc_bcalc = Round((_NFeS.pNt2cc.pNc_prtot * _NFeS.pNt2cc.pNc_alqreduz) / 100, 2)
                        _NFeS.pNt2cc.pNc_bcalc = Round(_NFeS.pNt2cc.pNc_prtot - _NFeS.pNt2cc.pNc_bcalc, 2)
                        _NFeS.pNt2cc.pNc_vlicm = Round((_NFeS.pNt2cc.pNc_bcalc * _NFeS.pNt2cc.pNc_alqicm) / 100, 2)

                    Case Else
                        _NFeS.pNt2cc.pNc_bcalc = Round((_NFeS.pNt2cc.pNc_prtot - _NFeS.pNt2cc.pNc_vldesc), 2)
                        _NFeS.pNt2cc.pNc_vlicm = Round((_NFeS.pNt2cc.pNc_bcalc * _NFeS.pNt2cc.pNc_alqicm) / 100, 2)

                End Select

            End If

            'IPI
            If _NFeS.pNt2cc.pNc_alqipi <= 0 Then
                _NFeS.pNt2cc.pNc_vlipi = 0
            End If


            'ICMS/IPI
            If (_NFeS.pNt2cc.pNc_alqicm <= 0) AndAlso (_NFeS.pNt2cc.pNc_alqipi <= 0) Then
                _NFeS.pNt2cc.pNc_bcalc = 0.0
            End If


            Select Case _NFeS.pNt2cc.pNc_cst
                Case "01", "02", "03"
                    vnc_vlPis = 0.0
                    vnc_vlCofins = 0.0
                Case Else

            End Select

            _NFeS.pNt2cc.pNc_cstipi = dr(22).ToString

            'Tratamento do PIS/COFINS ............
            cfopRegistro = _NFeS.pNt2cc.pNc_cfop.Substring(_NFeS.pNt2cc.pNc_cfop.Length - 3, 3)
            SqlNcm = "SELECT ncm_pissaid, ncm_cofinssaid FROM estncm WHERE ncm_ncm = '" & _NFeS.pNt2cc.pNc_ncm & "' " & _
            "AND ncm_cfop LIKE '%" & cfopRegistro & "%' LIMIT 1"
            commNcm = New NpgsqlCommand(SqlNcm, conexaoNcm)
            drNcm = commNcm.ExecuteReader
            While drNcm.Read
                _NFeS.pNt2cc.pNc_cstpis = drNcm(0).ToString
                _NFeS.pNt2cc.pNc_cstcofins = drNcm(1).ToString
            End While
            drNcm.Close() : commNcm.CommandText = ""

            Select Case _NFeS.pNt2cc.pNc_cstpis
                Case "49"
                    Select Case cfopRegistro
                        Case "904" 'Remesssa...
                        Case Else
                            _NFeS.pNt2cc.pNc_cstpis = "01"
                    End Select

            End Select
            Select Case _NFeS.pNt2cc.pNc_cstcofins
                Case "49"
                    Select Case cfopRegistro
                        Case "904" 'Remesssa...
                        Case Else
                            _NFeS.pNt2cc.pNc_cstcofins = "01"
                    End Select
            End Select


            vnc_prtotAux = Round(((_NFeS.pNt2cc.pNc_prtot - _NFeS.pNt2cc.pNc_vldesc) - _NFeS.pNt2cc.pNc_reduz), 2)

            Select Case geno001.pCrt
                Case "1", "2"
                Case "3" 'Regime Normal

                    If genp001.pPis > 0 Then

                        Try
                            If CInt(_NFeS.pNt2cc.pNc_cstpis) < 5 Then vnc_vlPis = Round((vnc_prtotAux * genp001.pPis) / 100, 2)
                        Catch ex As Exception
                        End Try

                    End If

                    If genp001.pConfin > 0 Then

                        Try
                            If CInt(_NFeS.pNt2cc.pNc_cstcofins) < 5 Then vnc_vlCofins = Round((vnc_prtotAux * genp001.pConfin) / 100, 2)
                        Catch ex As Exception
                        End Try

                    End If

            End Select

            ' vnc_vlPis = Round(vnc_vlPis, 2) : vnc_vlCofins = Round(vnc_vlCofins, 2)


            _NFeS.pNt2cc.pNc_vltrib = _clXml.clNFe.LeidaTransprencia(vnc_prtotAux, geno001.pPis, geno001.pCofins, geno001.pCsll, geno001.pIRenda, _
                                                          geno001.pSn, _NFeS.pNt2cc.pNc_vlicm, _NFeS.pNt2cc.pNc_vlipi, _NFeS.pNt2cc.pNc_cfop)

            'Soma Totais........................................................
            _NFeS.pNt4dd.pN4_pesobruto += Round(dr(14), 2) ' * _NFeS.pNt2cc.pNc_qtde
            _NFeS.pNt4dd.pN4_pesoliquido += Round(dr(15), 2) ' * _NFeS.pNt2cc.pNc_qtde
            _NFeS.pNt4dd.pN4_tgeral += Round((_NFeS.pNt2cc.pNc_prtot - _NFeS.pNt2cc.pNc_vldesc), 2)
            _NFeS.pNt4dd.pN4_aliss = 0
            _NFeS.pNt4dd.pN4_vliss = 0
            _NFeS.pNt4dd.pN4_vlser = 0
            _NFeS.pNt4dd.pN4_basec += _NFeS.pNt2cc.pNc_bcalc
            _NFeS.pNt4dd.pN4_bsub += _NFeS.pNt2cc.pNc_basesub
            _NFeS.pNt4dd.pN4_desc += _NFeS.pNt2cc.pNc_vldesc
            _NFeS.pNt4dd.pN4_frete += _NFeS.pNt2cc.pNc_frete
            _NFeS.pNt4dd.pN4_icms += _NFeS.pNt2cc.pNc_vlicm
            _NFeS.pNt4dd.pN4_icsub += _NFeS.pNt2cc.pNc_vlsubs
            _NFeS.pNt4dd.pN4_ipi += _NFeS.pNt2cc.pNc_vlipi
            _NFeS.pNt4dd.pN4_isento += _NFeS.pNt2cc.pNc_isento
            _NFeS.pNt4dd.pN4_outros += _NFeS.pNt2cc.pNc_voutro
            _NFeS.pNt4dd.pN4_outras += _NFeS.pNt2cc.pNc_descpac
            _NFeS.pNt4dd.pN4_segu += _NFeS.pNt2cc.pNc_segur
            _NFeS.pNt4dd.pN4_tprod += (_NFeS.pNt2cc.pNc_qtde * _NFeS.pNt2cc.pNc_prunit)
            _NFeS.pNt4dd.pN4_vlpis += vnc_vlPis
            _NFeS.pNt4dd.pN4_vlcofins += Round(vnc_vlCofins, 2)
            _NFeS.pNt4dd.pN4_totaltrib += Round(_NFeS.pNt2cc.pNc_vltrib, 2)

            _NFeS.pNt2cc.pNc_seqitem += 1
            _NFeS.pNt5tt.pT_qtde += CInt(_NFeS.pNt2cc.pNc_qtde)
            If mExisteNota1pp = False Then
                _clBD.incNota2cc(_NFeS.pNt2cc, geno001, conexao, transacao)
                _clBD.subtraiQtdFiscProdEstloja(_NFeS.pNt2cc.pNc_codpr, CodEstab, _NFeS.pNt2cc.pNc_qtde, conexao, transacao)

                'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
                'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
                _NFeS.dtgItensResumo.Rows.Add(_NFeS.pNt1pp.pNt_nume, _NFeS.pNt2cc.pNc_cfop, _NFeS.pNt2cc.pNc_cst, Round(_NFeS.pNt2cc.pNc_alqicm, 2), _
                                        Round((_NFeS.pNt2cc.pNc_prunit * _NFeS.pNt2cc.pNc_qtde), 2), Round(_NFeS.pNt2cc.pNc_vldesc, 2), _
                                        Round(_NFeS.pNt2cc.pNc_frete, 2), Round(_NFeS.pNt2cc.pNc_segur, 2), Round(_NFeS.pNt2cc.pNc_descpac, 2), _
                                        Round(_NFeS.pNt2cc.pNc_bcalc, 2), Round(_NFeS.pNt2cc.pNc_vlicm, 2), Round(_NFeS.pNt2cc.pNc_isento, 2), _
                                        Round(_NFeS.pNt2cc.pNc_voutro, 2), Round(_NFeS.pNt2cc.pNc_vlipi, 2), Round(_NFeS.pNt2cc.pNc_prtot, 2))
            End If
            _NFeS.pNt2cc.zeraValoresNFe01()

        End While
        dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length)
        'FIM do tratamento do _NFeS.pNt2cc...


        'Tratamento do _NFeS.pNt4dd...
        _NFeS.pNt4dd.pN4_numer = _NFeS.pNt1pp.pNt_nume
        _NFeS.pNt4dd.pN4_tipo = "S"
        _NFeS.pNt4dd.pN4_idn1pp = _NFeS.pNt1pp.pNt_id
        _NFeS.pNt4dd.pN4_tprod = Round(_NFeS.pNt4dd.pN4_tprod, 2)
        _NFeS.pNt4dd.pN4_aliss = Round(_NFeS.pNt4dd.pN4_aliss, 2)
        _NFeS.pNt4dd.pN4_vliss = Round(_NFeS.pNt4dd.pN4_vliss, 2)
        _NFeS.pNt4dd.pN4_vlser = Round(_NFeS.pNt4dd.pN4_vlser, 2)
        _NFeS.pNt4dd.pN4_basec = Round(_NFeS.pNt4dd.pN4_basec, 2)
        _NFeS.pNt4dd.pN4_icms = Round(_NFeS.pNt4dd.pN4_icms, 2)
        _NFeS.pNt4dd.pN4_bsub = Round(_NFeS.pNt4dd.pN4_bsub, 2)
        _NFeS.pNt4dd.pN4_icsub = Round(_NFeS.pNt4dd.pN4_icsub, 2)
        _NFeS.pNt4dd.pN4_tpro2 = Round(_NFeS.pNt4dd.pN4_tprod, 2)
        _NFeS.pNt4dd.pN4_frete = Round(_NFeS.pNt4dd.pN4_frete, 2)
        _NFeS.pNt4dd.pN4_segu = Round(_NFeS.pNt4dd.pN4_segu, 2)
        _NFeS.pNt4dd.pN4_outros = Round(_NFeS.pNt4dd.pN4_outros, 2)
        _NFeS.pNt4dd.pN4_outras = Round(_NFeS.pNt4dd.pN4_outras, 2)
        _NFeS.pNt4dd.pN4_ipi = Round(_NFeS.pNt4dd.pN4_ipi, 2)
        _NFeS.pNt4dd.pN4_tgeral = Round(_NFeS.pNt4dd.pN4_tgeral, 2)
        _NFeS.pNt4dd.pN4_pgto = _NFeTrat.vnt_pag
        _NFeS.pNt4dd.pN4_peso = Round(_NFeS.pNt4dd.pN4_peso, 2)
        _NFeS.pNt4dd.pN4_pesobruto = Round(_NFeS.pNt4dd.pN4_pesobruto, 2)
        _NFeS.pNt4dd.pN4_pesoliquido = Round(_NFeS.pNt4dd.pN4_pesoliquido, 2)
        _NFeS.pNt4dd.pN4_outras = Round(_NFeS.pNt4dd.pN4_outras, 2)
        _NFeS.pNt4dd.pN4_isento = Round(_NFeS.pNt4dd.pN4_isento, 2)
        _NFeS.pNt4dd.pN4_desc = Round(_NFeS.pNt4dd.pN4_desc, 2)
        _NFeS.pNt4dd.pN4_vlpis = Round(_NFeS.pNt4dd.pN4_vlpis, 2)
        _NFeS.pNt4dd.pN4_vlcofins = Round(_NFeS.pNt4dd.pN4_vlcofins, 2)
        _NFeS.pNt4dd.pN4_totaltrib = Round(_NFeS.pNt4dd.pN4_totaltrib, 2)

        _NFeS.pNt4dd.pN4_totaltrib = Round(_NFeS.pNt4dd.pN4_totaltrib, 2)

        If mExisteNota1pp = False Then _clBD.incNota4dd(_NFeS.pNt4dd, geno001, conexao, transacao)


        'Tratamento do _NFeS.pNt6hh...
        _NFeS.pNt6hh.pC_tipo = _NFeS.pNt1pp.pNt_tipo
        _NFeS.pNt6hh.pC_numer = _NFeS.pNt1pp.pNt_nume
        _NFeS.pNt6hh.pC_idn1pp = _NFeS.pNt1pp.pNt_id
        If Trim(txt_complemento1.Text).Equals("") = False Then _NFeS.pNt6hh.pC_compl1 = Trim(txt_complemento1.Text)
        If Trim(txt_complemento2.Text).Equals("") = False Then _NFeS.pNt6hh.pC_compl2 = Trim(txt_complemento2.Text)
        _NFeS.pNt6hh.pC_compl6 = "Valor Aprox. dos Tributos R$ " & Format(_NFeS.pNt4dd.pN4_totaltrib, "###,##0.00") & "(" & _
            Format(Round((_NFeS.pNt4dd.pN4_totaltrib / _NFeS.pNt4dd.pN4_tgeral) * 100, 2), "###,##0.00") & "%)"
        'Tratamentos <<<<<<<<<<<<<<<<<<<<
        Select Case geno001.pCrt
            Case "1" '1 - Simples Nacional

                _NFeS.pNt6hh.pC_compl4 = "DOCTO EMITIDO P/ ME OU EPP OPTANTE PELO SIMPLES NACIONAL"
                _NFeS.pNt6hh.pC_compl5 = "NAO GERA CREDITO FISCAL DE ICMS"
            Case "2" '2 - Simples Nacional - Excesso RB

                _NFeS.pNt6hh.pC_compl4 = "DOCTO EMITIDO P/ ME OU EPP OPTANTE PELO SIMPLES NACIONAL"
                _NFeS.pNt6hh.pC_compl5 = "NAO GERA CREDITO FISCAL DE ICMS"

        End Select

        If mExisteNota1pp = False Then _clBD.incNota6hh(_NFeS.pNt6hh, geno001, conexao, transacao)


        'Tratamento do _NFeS.pNt5tt...
        _NFeS.cliTranportador.zeraValores()
        _NFeS.pNt5tt.pT_numer = _NFeS.pNt1pp.pNt_nume
        _NFeS.pNt5tt.pT_id1pp = _NFeS.pNt1pp.pNt_id
        _NFeS.pNt5tt.pT_placa = ""
        _NFeS.pNt5tt.pT_pesob = Round(_NFeS.pNt4dd.pN4_pesobruto, 3)
        _NFeS.pNt5tt.pT_pesol = Round(_NFeS.pNt4dd.pN4_pesoliquido, 3)

        Select Case Me.cbo_transportador.SelectedIndex
            Case 0
                _NFeS.pNt5tt.pT_tpfret = 0
                _NFeS.pNt5tt.pT_placa = Me.cbo_placa.SelectedItem.ToString
                _NFeS.pNt5tt.pT_marca = "Diversos"
                _NFeS.pNt5tt.pT_espec = "Volumes"

                Sqlcomm.Append("SELECT aut_placa, aut_descricao, aut_fornecedor, c.p_uf, c.p_portad, c.p_cpf, c.p_cgc, c.p_end, ") '7
                Sqlcomm.Append("c.p_mun, c.p_coduf, c.p_insc FROM cadautomovel JOIN ")
                Sqlcomm.Append("cadp001 c ON c.p_cod = aut_fornecedor WHERE aut_placa LIKE '" & _NFeS.pNt5tt.pT_placa & "'")
                oCmd = New NpgsqlCommand(Sqlcomm.ToString, conexaoConsultas)
                dr = oCmd.ExecuteReader

                While dr.Read

                    _NFeS.pNt5tt.pT_codp = dr(2).ToString
                    _NFeS.pNt5tt.pT_uf = dr(3).ToString
                    _NFeS.cliTranportador.pCod = dr(2).ToString
                    _NFeS.cliTranportador.pUf = dr(3).ToString
                    _NFeS.cliTranportador.pPortad = dr(4).ToString
                    _NFeS.cliTranportador.pCpf = dr(5).ToString
                    _NFeS.cliTranportador.pCgc = dr(6).ToString
                    _NFeS.cliTranportador.pEnder = dr(7).ToString
                    _NFeS.cliTranportador.pMun = dr(8).ToString
                    _NFeS.cliTranportador.pCoduf = dr(3).ToString
                    _NFeS.cliTranportador.pInsc = dr(10).ToString

                End While
                dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length)

                _NFeS.pNt5tt.pT_placa = _NFeS.pNt5tt.pT_placa.Replace("-", "")
            Case 1
                _NFeS.pNt5tt.pT_codp = "999999"
                _NFeS.pNt5tt.pT_tpfret = 1
                _NFeS.pNt5tt.pT_placa = Me.txt_placa.Text
            Case 2
                _NFeS.pNt5tt.pT_codp = "999999"
                _NFeS.pNt5tt.pT_tpfret = 2
                _NFeS.pNt5tt.pT_placa = Me.txt_placa.Text
            Case 3
                _NFeS.pNt5tt.pT_codp = "999999"
                _NFeS.pNt5tt.pT_tpfret = 9
        End Select

        If mExisteNota1pp = False Then _clBD.incNota5tt(_NFeS.pNt5tt, geno001, conexao, transacao)


        'INCIO do armazenamento dos Resumos...
        If mExisteNota1pp Then

            _clFuncoes.incResumAlqSaida(True, _NFeS.dtgItensResumo, _NFeS.pRes01, geno001, _clBD, conexao, transacao)
            _clFuncoes.incResumCfopAlqSaida(True, _NFeS.dtgItensResumo, _NFeS.pRes02, geno001, _clBD, conexao, transacao)
            _clFuncoes.incResumCstCfopAlqSaida(True, _NFeS.dtgItensResumo, _NFeS.pRes03, geno001, _clBD, conexao, transacao)

        Else

            _clFuncoes.incResumAlqSaida(False, _NFeS.dtgItensResumo, _NFeS.pRes01, geno001, _clBD, conexao, transacao)
            _clFuncoes.incResumCfopAlqSaida(False, _NFeS.dtgItensResumo, _NFeS.pRes02, geno001, _clBD, conexao, transacao)
            _clFuncoes.incResumCstCfopAlqSaida(False, _NFeS.dtgItensResumo, _NFeS.pRes03, geno001, _clBD, conexao, transacao)

        End If
        'FIM do armazenamento dos Resumos

        'INICIO do armazenamento das Notas referenciadas
        If mExisteNota1pp = False Then

            Try

                For i As Integer = 0 To _NFeS.notaref.Length - 1
                    _NFeS.notaref(i).nt1pp = _NFeS.pNt1pp.pNt_nume
                    _clBD.incNotaref(_NFeS.notaref(i), geno001, conexao, transacao)
                Next
            Catch ex As Exception
            End Try

        End If
        'FIM do armazenamento das Notas referenciadas

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



        'INICIO Atribuindo valores ao _NFeS.pNt1pp...
        _NFeS.pNt1pp.pTipo_nt = "P"
        _NFeS.pNt1pp.pNt_tipo = "S"
        _NFeS.pNt1pp.pNt_nume = lbl_numeroNota1pp.Text
        _NFeS.pNt1pp.pNt_serie = _clFuncoes.trazVlrColunaGenp001("G00" & CodEstab, "gp_serie", conexao.ConnectionString)
        _NFeS.pNt1pp.pNt_natur = Mid(Me.cbo_nfeCfop.SelectedItem, 9, 40)
        _NFeS.pNt1pp.pNt_cfop = Mid(Me.cbo_nfeCfop.SelectedItem, 1, 5)
        _NFeS.pNt1pp.pNt_geno = "G00" & CodEstab
        If mExisteNota1pp Then
            trazFornecedor(mCodPartNota1ppExist)
        End If

        _NFeS.pRes01.r4_numero = _NFeS.pNt1pp.pNt_nume
        _NFeS.pRes02.r4_numero = _NFeS.pNt1pp.pNt_nume
        _NFeS.pRes03.r4_numero = _NFeS.pNt1pp.pNt_nume

        _NFeS.pNt1pp.pNt_codig = mCodPart
        _NFeS.pNt1pp.pNt_dtemis = Date.Now
        _NFeS.pNt1pp.pNt_dtsai = dtp_dtSaida.Value
        If _NFeS.pNt1pp.pNt_dtsai < _NFeS.pNt1pp.pNt_dtemis Then _NFeS.pNt1pp.pNt_dtemis = _NFeS.pNt1pp.pNt_dtsai
        _NFeS.pNt1pp.pNt_emiss = False
        _NFeS.pNt1pp.pNt_cnpj = mbCNPJ
        _NFeS.pNt1pp.pNt_insc = mbInscr
        _NFeS.pNt1pp.pNt_uf = mbUf
        _NFeS.pNt1pp.pNt_orca = Me.txt_pedido.Text

        TratamentoIndFinal()
        TratamentoIndOper()
        TratamentoIndDest()
        TratamentoIndPres()
        TratamentoFinNFe()

        'Incluindo _NFeS.pNt1pp...
        If mExisteNota1pp = False Then _clBD.incNota1pp(_NFeS.pNt1pp, geno001, conexao, transacao)
        _NFeS.pNt1pp.pNt_id = _clBD.trazIdNota1pp(conexao, _NFeS.pNt1pp.pNt_nume)
        'FIM Atribuindo valores ao _NFeS.pNt1pp...
        geno001.pPis = Round(geno001.pPis, 2)
        geno001.pCofins = Round(geno001.pCofins, 2)



        Dim cfopRegistro As String = ""
        _NFeS.pNt5tt.pT_qtde = 0
        _NFeS.dtgItensResumo.Rows.Clear() : _NFeS.dtgItensResumo.Refresh()
        'INICIO do Tratamento do _NFeS.pNt2cc...
        Sqlcomm.Append("SELECT no_codpr, e.e_produt, e.e_clf, e.e_cst, no_und, no_qtde, no_prunit, no_prtot, ") '7
        Sqlcomm.Append("no_alqicm, no_vlicms, no_vlsub, no_alqsub, no_baseicm, no_basesub, no_pesobruto, no_pesoliquido, ") '15
        Sqlcomm.Append("e.e_ncm, no_alqdesc, e.e_cfv, e.e_grupo, al.alq_interna, al.alq_externa, e.e_cstipi, e.e_produt2, ") '23
        Sqlcomm.Append("e.e_produt3, e.e_reduz, e.e_pauta, no_pruvenda FROM " & geno001.pEsquemaestab & ".orca2cc, ")
        Sqlcomm.Append(geno001.pEsquemavinc & ".est0001 e LEFT JOIN aliquotas al ON al.alq_tipo = e.e_tipo WHERE no_codpr = ")
        Sqlcomm.Append("e.e_codig AND no_orca = '" & _NFeS.pNt1pp.pNt_orca & "'")
        oCmd = New NpgsqlCommand(Sqlcomm.ToString, conexaoConsultas)
        dr = oCmd.ExecuteReader

        'Atribuindo valores ao _NFeS.pNt2cc...
        _NFeS.pNt2cc.pNc_tipo = "S"
        _NFeS.pNt2cc.pNc_numer = _NFeS.pNt1pp.pNt_nume
        _NFeS.pNt2cc.pNc_dtemis = _NFeS.pNt1pp.pNt_dtemis
        _NFeS.pNt2cc.pNc_cdport = _NFeS.pNt1pp.pNt_codig
        _NFeS.pNt2cc.pNc_ntid = _NFeS.pNt1pp.pNt_id
        _NFeS.pNt2cc.pNc_indtot = 1
        _NFeS.pNt2cc.pNc_seqitem = 0

        While dr.Read


            _NFeS.pNt2cc.pNc_codpr = dr(0).ToString
            If _NFeS.pNt2cc.pNc_codpr.Equals("00079") Then
                _NFeS.pNt2cc.pNc_codpr = _NFeS.pNt2cc.pNc_codpr
            End If
            _NFeS.pNt2cc.pNc_produt = dr(23).ToString 'descrição para NFe
            If Trim(_NFeS.pNt2cc.pNc_produt).Equals("") Then ' Se a descrição para NFe estiver em branco

                _NFeS.pNt2cc.pNc_produt = dr(24).ToString 'descrição para Automóvel
                If Trim(_NFeS.pNt2cc.pNc_produt).Equals("") Then ' Se a descrição para Automóvel estiver em branco
                    _NFeS.pNt2cc.pNc_produt = dr(1).ToString

                End If
            End If
            _NFeS.pNt2cc.pNc_cf = dr(2)
            _NFeS.pNt2cc.pNc_cst = Format(dr(3), "00")
            cfv = dr(18)
            grupo = dr(19)
            mAlqInterna = dr(20)
            mAlqExterna = dr(21)
            _NFeS.pNt2cc.pNc_und = dr(4).ToString
            _NFeS.pNt2cc.pNc_qtde = dr(5)

            If chk_pauta.Checked Then 'Se tiver marcado para usar PAUTA..
                _NFeS.pNt2cc.pNc_prunit = dr(26) 'e_pauta

                'Tratamento da PAUTA....
                If _NFeS.pNt2cc.pNc_prunit <= 0 Then
                    MsgBox("Produto """ & _NFeS.pNt2cc.pNc_codpr & " - " & Mid(_NFeS.pNt2cc.pNc_produt, 1, 15) & """ com PAUTA <= ZERO! Por Favor alterar no cadastro do Produto", MsgBoxStyle.Exclamation)
                    transacao.Rollback() : Return
                End If
                'END PAUTA......
            Else

                _NFeS.pNt2cc.pNc_prunit = dr(6) 'no_prunit
                If genp001.descontonfe = False Then _NFeS.pNt2cc.pNc_prunit = dr(27) 'no_pruvenda
            End If

            _NFeS.pNt2cc.pNc_prtot = Round(_NFeS.pNt2cc.pNc_qtde * _NFeS.pNt2cc.pNc_prunit, 2) 'dr(7)
            _NFeS.pNt2cc.pNc_alqicm = dr(8)
            _NFeS.pNt2cc.pNc_alqipi = genp001.pTxipi
            _NFeS.pNt2cc.pNc_vlipi = 0.0
            _NFeS.pNt2cc.pNc_vlicm = dr(9)
            _NFeS.pNt2cc.pNc_unipi = 0.0
            _NFeS.pNt2cc.pNc_vlsubs = dr(10)
            _NFeS.pNt2cc.pNc_alqsub = dr(11)
            _NFeS.pNt2cc.pNc_cfop = Mid(_NFeS.pNt1pp.pNt_cfop, 1, 1) & Mid(_NFeS.pNt1pp.pNt_cfop, 3, 3)
            _NFeS.pNt2cc.pNc_bcalc = dr(12)
            _NFeS.pNt2cc.pNc_basesub = dr(13)
            _NFeS.pNt2cc.pNc_frete = 0.0
            _NFeS.pNt2cc.pNc_segur = 0.0

            vnc_alqDesconto = dr(17)
            _NFeS.pNt2cc.pNc_vldesc = 0.0
            If vnc_alqDesconto > 0 Then _NFeS.pNt2cc.pNc_vldesc = Round((_NFeS.pNt2cc.pNc_prtot * vnc_alqDesconto) / 100, 2)
            If genp001.descontonfe = False Then vnc_alqDesconto = 0.0 : _NFeS.pNt2cc.pNc_vldesc = 0.0

            _NFeS.pNt2cc.pNc_isento = 0.0
            If cfv = 4 Then _NFeS.pNt2cc.pNc_isento = _NFeS.pNt2cc.pNc_prtot
            _NFeS.pNt2cc.pNc_csosn = ""
            _NFeS.pNt2cc.pNc_vltrib = 0.0
            _NFeS.pNt2cc.pNc_descpac = 0.0

            _NFeS.pNt2cc.pNc_alqreduz = dr(25)
            _NFeS.pNt2cc.pNc_reduz = 0.0
            If _NFeS.pNt2cc.pNc_alqreduz > 0 Then _NFeS.pNt2cc.pNc_reduz = Round((_NFeS.pNt2cc.pNc_prtot * _NFeS.pNt2cc.pNc_alqreduz) / 100, 2)

            vnc_vlPis = 0.0
            vnc_vlCofins = 0.0

            'Tratamento do NCM....
            _NFeS.pNt2cc.pNc_ncm = dr(16).ToString
            If _NFeS.pNt2cc.pNc_ncm.Length <> 8 Then
                MsgBox("Produto """ & _NFeS.pNt2cc.pNc_codpr & """ corrigir NCM!  Por Favor alterar no cadastro do Produto", MsgBoxStyle.Exclamation)
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

                    _NFeS.pNt2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, _NFeS.pNt1pp.pNt_cfop, 0)
                    If cfv = 1 Or cfv = 4 Then 'CSOSN 102
                        ' /Icms12 - Produto Trib. p/ Simples Nacional s/ Permissao de Credito **
                        _NFeS.pNt2cc.pNc_csosn = "102"
                        _NFeS.pNt2cc.pNc_alqicm = 0
                        _NFeS.pNt2cc.pNc_vlicm = 0 : _NFeS.pNt2cc.pNc_unipi = 0
                        _NFeS.pNt2cc.pNc_vlsubs = 0 : _NFeS.pNt2cc.pNc_alqsub = 0
                        _NFeS.pNt2cc.pNc_bcalc = 0 : _NFeS.pNt2cc.pNc_basesub = 0
                    End If

                    If cfv = 3 Then 'CSOSN 500 Produto com substitui‡Æo
                        _NFeS.pNt2cc.pNc_csosn = "500"
                        _NFeS.pNt2cc.pNc_alqicm = 0
                        _NFeS.pNt2cc.pNc_vlicm = 0 : _NFeS.pNt2cc.pNc_unipi = 0
                        _NFeS.pNt2cc.pNc_vlsubs = 0 : _NFeS.pNt2cc.pNc_alqsub = 0
                        _NFeS.pNt2cc.pNc_bcalc = 0 : _NFeS.pNt2cc.pNc_basesub = 0
                    End If



                Case "2" '1 - Simples Nacional com Retenção
                    _NFeS.pNt2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, _NFeS.pNt1pp.pNt_cfop, 0)
                    Select Case cfv
                        Case 1
                            _NFeS.pNt2cc.pNc_csosn = "202"
                            _NFeS.pNt2cc.pNc_vlsubs = 0 : _NFeS.pNt2cc.pNc_alqsub = 0
                            _NFeS.pNt2cc.pNc_basesub = 0
                        Case 3 'Produto com substitui‡Æo
                            _NFeS.pNt2cc.pNc_csosn = "500"
                        Case 4
                            _NFeS.pNt2cc.pNc_csosn = "102"
                    End Select

                Case "3" '3 - Regime Normal

                    If cfv = 3 Then
                        _NFeS.pNt2cc.pNc_alqicm = 0.0 : _NFeS.pNt2cc.pNc_vlicm = 0.0
                        _NFeS.pNt6hh.pC_compl5 = "(*) ICMS PAGO ANTEC CONF.DECR. N.6551/85 E 9483/97"
                        _NFeS.pNt2cc.pNc_produt = RTrim(_NFeS.pNt2cc.pNc_produt) & " (*)"
                        _NFeS.pNt4dd.pN4_outras = _NFeS.pNt4dd.pN4_outras + Round((_NFeS.pNt2cc.pNc_qtde * _NFeS.pNt2cc.pNc_prunit), 2)
                    End If

                    If _NFeS.pNt1pp.pNt_cfop.Substring(0, 1).Equals("5") Then
                        _NFeS.pNt2cc.pNc_alqicm = mAlqInterna
                    ElseIf _NFeS.pNt1pp.pNt_cfop.Substring(0, 1).Equals("6") Then
                        _NFeS.pNt2cc.pNc_alqicm = mAlqExterna
                    End If

                    _NFeS.pNt2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, _NFeS.pNt1pp.pNt_cfop, 0)

            End Select
            _NFeS.pNt2cc.pNc_desc = dr(17)


            'Calculando Tributos......................................................................
            'ICMS
            If _NFeS.pNt2cc.pNc_alqicm <= 0 Then
                _NFeS.pNt2cc.pNc_vlicm = 0
            Else

                Select Case _NFeS.pNt2cc.pNc_cst
                    Case "20"
                        _NFeS.pNt2cc.pNc_bcalc = Round((_NFeS.pNt2cc.pNc_prtot * _NFeS.pNt2cc.pNc_alqreduz) / 100, 2)
                        _NFeS.pNt2cc.pNc_bcalc = Round(_NFeS.pNt2cc.pNc_prtot - _NFeS.pNt2cc.pNc_bcalc, 2)
                        _NFeS.pNt2cc.pNc_vlicm = Round((_NFeS.pNt2cc.pNc_bcalc * _NFeS.pNt2cc.pNc_alqicm) / 100, 2)

                    Case Else
                        _NFeS.pNt2cc.pNc_bcalc = Round((_NFeS.pNt2cc.pNc_prtot - _NFeS.pNt2cc.pNc_vldesc), 2)
                        _NFeS.pNt2cc.pNc_vlicm = Round((_NFeS.pNt2cc.pNc_bcalc * _NFeS.pNt2cc.pNc_alqicm) / 100, 2)

                End Select

            End If

            'IPI
            If _NFeS.pNt2cc.pNc_alqipi <= 0 Then
                _NFeS.pNt2cc.pNc_vlipi = 0
            End If


            'ICMS/IPI
            If (_NFeS.pNt2cc.pNc_alqicm <= 0) AndAlso (_NFeS.pNt2cc.pNc_alqipi <= 0) Then
                _NFeS.pNt2cc.pNc_bcalc = 0.0
            End If


            Select Case _NFeS.pNt2cc.pNc_cst
                Case "01", "02", "03"
                    vnc_vlPis = 0.0
                    vnc_vlCofins = 0.0
                Case Else

            End Select

            _NFeS.pNt2cc.pNc_cstipi = dr(22).ToString

            '!!! Teste...
            'If _NFeS.pNt2cc.pNc_codpr.Equals("00032") OrElse _NFeS.pNt2cc.pNc_codpr.Equals("00375") Then _NFeS.pNt2cc.pNc_codpr = _NFeS.pNt2cc.pNc_codpr
            'Tratamento do PIS/COFINS ............
            cfopRegistro = _NFeS.pNt2cc.pNc_cfop.Substring(_NFeS.pNt2cc.pNc_cfop.Length - 3, 3)
            SqlNcm = "SELECT ncm_pissaid, ncm_cofinssaid FROM estncm WHERE ncm_ncm = '" & _NFeS.pNt2cc.pNc_ncm & "' " & _
            "AND ncm_cfop LIKE '%" & cfopRegistro & "%' LIMIT 1"
            commNcm = New NpgsqlCommand(SqlNcm, conexaoNcm)
            drNcm = commNcm.ExecuteReader
            While drNcm.Read
                _NFeS.pNt2cc.pNc_cstpis = drNcm(0).ToString
                _NFeS.pNt2cc.pNc_cstcofins = drNcm(1).ToString
            End While
            drNcm.Close() : commNcm.CommandText = ""

            Select Case _NFeS.pNt2cc.pNc_cstpis
                Case "49"
                    Select Case cfopRegistro
                        Case "904" 'Remesssa...
                        Case Else
                            _NFeS.pNt2cc.pNc_cstpis = "01"
                    End Select

            End Select
            Select Case _NFeS.pNt2cc.pNc_cstcofins
                Case "49"
                    Select Case cfopRegistro
                        Case "904" 'Remesssa...
                        Case Else
                            _NFeS.pNt2cc.pNc_cstcofins = "01"
                    End Select
            End Select


            vnc_prtotAux = Round(((_NFeS.pNt2cc.pNc_prtot - _NFeS.pNt2cc.pNc_vldesc) - _NFeS.pNt2cc.pNc_reduz), 2)


            Select Case geno001.pCrt
                Case "1", "2"
                Case "3" 'Regime Normal

                    If genp001.pPis > 0 Then

                        Try
                            If CInt(_NFeS.pNt2cc.pNc_cstpis) < 5 Then vnc_vlPis = Round((vnc_prtotAux * genp001.pPis) / 100, 2)
                        Catch ex As Exception
                        End Try

                    End If

                    If genp001.pConfin > 0 Then

                        Try
                            If CInt(_NFeS.pNt2cc.pNc_cstcofins) < 5 Then vnc_vlCofins = Round((vnc_prtotAux * genp001.pConfin) / 100, 2)
                        Catch ex As Exception
                        End Try

                    End If

            End Select

            ' vnc_vlPis = Round(vnc_vlPis, 2) : vnc_vlCofins = Round(vnc_vlCofins, 2)

            _NFeS.pNt2cc.pNc_vltrib = _clXml.clNFe.LeidaTransprencia(vnc_prtotAux, geno001.pPis, geno001.pCofins, geno001.pCsll, geno001.pIRenda, _
                                                          geno001.pSn, _NFeS.pNt2cc.pNc_vlicm, _NFeS.pNt2cc.pNc_vlipi, _NFeS.pNt2cc.pNc_cfop)

            'Soma Totais........................................................
            _NFeS.pNt4dd.pN4_pesobruto += Round(dr(14) * _NFeS.pNt2cc.pNc_qtde, 2)
            _NFeS.pNt4dd.pN4_pesoliquido += Round(dr(15) * _NFeS.pNt2cc.pNc_qtde, 2)
            _NFeS.pNt4dd.pN4_tgeral += Round((_NFeS.pNt2cc.pNc_prtot - _NFeS.pNt2cc.pNc_vldesc), 2)
            _NFeS.pNt4dd.pN4_aliss = 0
            _NFeS.pNt4dd.pN4_vliss = 0
            _NFeS.pNt4dd.pN4_vlser = 0
            _NFeS.pNt4dd.pN4_basec += _NFeS.pNt2cc.pNc_bcalc
            _NFeS.pNt4dd.pN4_bsub += _NFeS.pNt2cc.pNc_basesub
            _NFeS.pNt4dd.pN4_desc += _NFeS.pNt2cc.pNc_vldesc
            _NFeS.pNt4dd.pN4_frete += _NFeS.pNt2cc.pNc_frete
            _NFeS.pNt4dd.pN4_icms += _NFeS.pNt2cc.pNc_vlicm
            _NFeS.pNt4dd.pN4_icsub += _NFeS.pNt2cc.pNc_vlsubs
            _NFeS.pNt4dd.pN4_ipi += _NFeS.pNt2cc.pNc_vlipi
            _NFeS.pNt4dd.pN4_isento += _NFeS.pNt2cc.pNc_isento
            _NFeS.pNt4dd.pN4_outros += _NFeS.pNt2cc.pNc_voutro
            _NFeS.pNt4dd.pN4_outras += _NFeS.pNt2cc.pNc_descpac
            _NFeS.pNt4dd.pN4_segu += _NFeS.pNt2cc.pNc_segur
            _NFeS.pNt4dd.pN4_tprod += (_NFeS.pNt2cc.pNc_qtde * _NFeS.pNt2cc.pNc_prunit)
            _NFeS.pNt4dd.pN4_vlpis += Round(vnc_vlPis, 2)
            _NFeS.pNt4dd.pN4_vlcofins += Round(vnc_vlCofins, 2)
            _NFeS.pNt4dd.pN4_totaltrib += _NFeS.pNt2cc.pNc_vltrib

            _NFeS.pNt2cc.pNc_seqitem += 1
            _NFeS.pNt5tt.pT_qtde += CInt(_NFeS.pNt2cc.pNc_qtde)
            If mExisteNota1pp = False Then

                _clBD.incNota2cc(_NFeS.pNt2cc, geno001, conexao, transacao)
                _clBD.subtraiQtdFiscProdEstloja(_NFeS.pNt2cc.pNc_codpr, CodEstab, _NFeS.pNt2cc.pNc_qtde, conexao, transacao)


                'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
                'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
                _NFeS.dtgItensResumo.Rows.Add(_NFeS.pNt1pp.pNt_nume, _NFeS.pNt2cc.pNc_cfop, _NFeS.pNt2cc.pNc_cst, Round(_NFeS.pNt2cc.pNc_alqicm, 2), _
                                        Round((_NFeS.pNt2cc.pNc_prunit * _NFeS.pNt2cc.pNc_qtde), 2), Round(_NFeS.pNt2cc.pNc_vldesc, 2), _
                                        Round(_NFeS.pNt2cc.pNc_frete, 2), Round(_NFeS.pNt2cc.pNc_segur, 2), Round(_NFeS.pNt2cc.pNc_descpac, 2), _
                                        Round(_NFeS.pNt2cc.pNc_bcalc, 2), Round(_NFeS.pNt2cc.pNc_vlicm, 2), Round(_NFeS.pNt2cc.pNc_isento, 2), _
                                        Round(_NFeS.pNt2cc.pNc_voutro, 2), Round(_NFeS.pNt2cc.pNc_vlipi, 2), Round(_NFeS.pNt2cc.pNc_prtot, 2))

            End If
            _NFeS.pNt2cc.zeraValoresNFe01()

        End While
        dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length)
        'FIM do Tratamento do _NFeS.pNt2cc...


        'Tratamento do _NFeS.pNt4dd...
        _NFeS.pNt4dd.pN4_numer = _NFeS.pNt1pp.pNt_nume
        _NFeS.pNt4dd.pN4_tipo = "S"
        _NFeS.pNt4dd.pN4_idn1pp = _NFeS.pNt1pp.pNt_id
        _NFeS.pNt4dd.pN4_tprod = Round(_NFeS.pNt4dd.pN4_tprod, 2)
        _NFeS.pNt4dd.pN4_aliss = Round(_NFeS.pNt4dd.pN4_aliss, 2)
        _NFeS.pNt4dd.pN4_vliss = Round(_NFeS.pNt4dd.pN4_vliss, 2)
        _NFeS.pNt4dd.pN4_vlser = Round(_NFeS.pNt4dd.pN4_vlser, 2)
        _NFeS.pNt4dd.pN4_basec = Round(_NFeS.pNt4dd.pN4_basec, 2)
        _NFeS.pNt4dd.pN4_icms = Round(_NFeS.pNt4dd.pN4_icms, 2)
        _NFeS.pNt4dd.pN4_bsub = Round(_NFeS.pNt4dd.pN4_bsub, 2)
        _NFeS.pNt4dd.pN4_icsub = Round(_NFeS.pNt4dd.pN4_icsub, 2)
        _NFeS.pNt4dd.pN4_tpro2 = Round(_NFeS.pNt4dd.pN4_tprod, 2)
        _NFeS.pNt4dd.pN4_frete = Round(_NFeS.pNt4dd.pN4_frete, 2)
        _NFeS.pNt4dd.pN4_segu = Round(_NFeS.pNt4dd.pN4_segu, 2)
        _NFeS.pNt4dd.pN4_outros = Round(_NFeS.pNt4dd.pN4_outros, 2)
        _NFeS.pNt4dd.pN4_outras = Round(_NFeS.pNt4dd.pN4_outras, 2)
        _NFeS.pNt4dd.pN4_ipi = Round(_NFeS.pNt4dd.pN4_ipi, 2)
        _NFeS.pNt4dd.pN4_tgeral = Round(_NFeS.pNt4dd.pN4_tgeral, 2)
        _NFeS.pNt4dd.pN4_pgto = _NFeTrat.vnt_pag
        _NFeS.pNt4dd.pN4_peso = Round(_NFeS.pNt4dd.pN4_peso, 2)
        _NFeS.pNt4dd.pN4_pesobruto = Round(_NFeS.pNt4dd.pN4_pesobruto, 2)
        _NFeS.pNt4dd.pN4_pesoliquido = Round(_NFeS.pNt4dd.pN4_pesoliquido, 2)
        _NFeS.pNt4dd.pN4_outras = Round(_NFeS.pNt4dd.pN4_outras, 2)
        _NFeS.pNt4dd.pN4_isento = Round(_NFeS.pNt4dd.pN4_isento, 2)
        _NFeS.pNt4dd.pN4_desc = Round(_NFeS.pNt4dd.pN4_desc, 2)
        _NFeS.pNt4dd.pN4_vlpis = Round(_NFeS.pNt4dd.pN4_vlpis, 2)
        _NFeS.pNt4dd.pN4_vlcofins = Round(_NFeS.pNt4dd.pN4_vlcofins, 2)
        _NFeS.pNt4dd.pN4_totaltrib = Round(_NFeS.pNt4dd.pN4_totaltrib, 2)
        Select Case geno001.pCrt
            Case "1" 'Simples Nacional
                If _NFeS.pNt4dd.pN4_vlpis > 0 Then _NFeS.pNt4dd.pN4_pis = genp001.pPis
                If _NFeS.pNt4dd.pN4_vlcofins > 0 Then _NFeS.pNt4dd.pN4_cofins = genp001.pConfin
        End Select
        _NFeS.pNt4dd.pN4_totaltrib = Round(_NFeS.pNt4dd.pN4_totaltrib, 2)

        If mExisteNota1pp = False Then _clBD.incNota4dd(_NFeS.pNt4dd, geno001, conexao, transacao)


        'Tratamento do _NFeS.pNt6hh...
        _NFeS.pNt6hh.pC_tipo = _NFeS.pNt1pp.pNt_tipo
        _NFeS.pNt6hh.pC_numer = _NFeS.pNt1pp.pNt_nume
        _NFeS.pNt6hh.pC_idn1pp = _NFeS.pNt1pp.pNt_id
        If Trim(txt_complemento1.Text).Equals("") = False Then _NFeS.pNt6hh.pC_compl1 = Trim(txt_complemento1.Text)
        If Trim(txt_complemento2.Text).Equals("") = False Then _NFeS.pNt6hh.pC_compl2 = Trim(txt_complemento2.Text)
        _NFeS.pNt6hh.pC_compl6 = "Valor Aprox. dos Tributos R$ " & Format(_NFeS.pNt4dd.pN4_totaltrib, "###,##0.00") & "(" & _
            Format(Round((_NFeS.pNt4dd.pN4_totaltrib / _NFeS.pNt4dd.pN4_tgeral) * 100, 2), "###,##0.00") & "%)"
        'Tratamentos <<<<<<<<<<<<<<<<<<<<<
        Select Case geno001.pCrt
            Case "1" '1 - Simples Nacional

                _NFeS.pNt6hh.pC_compl4 = "DOCTO EMITIDO P/ ME OU EPP OPTANTE PELO SIMPLES NACIONAL"
                _NFeS.pNt6hh.pC_compl5 = "NAO GERA CREDITO FISCAL DE ICMS"
            Case "2" '2 - Simples Nacional - Excesso RB

                _NFeS.pNt6hh.pC_compl4 = "DOCTO EMITIDO P/ ME OU EPP OPTANTE PELO SIMPLES NACIONAL"
                _NFeS.pNt6hh.pC_compl5 = "NAO GERA CREDITO FISCAL DE ICMS"

        End Select
        If mExisteNota1pp = False Then _clBD.incNota6hh(_NFeS.pNt6hh, geno001, conexao, transacao)


        'Tratamento do _NFeS.pNt5tt...
        _NFeS.cliTranportador.zeraValores()
        _NFeS.pNt5tt.pT_numer = _NFeS.pNt1pp.pNt_nume
        _NFeS.pNt5tt.pT_id1pp = _NFeS.pNt1pp.pNt_id
        _NFeS.pNt5tt.pT_placa = ""
        _NFeS.pNt5tt.pT_pesob = Round(_NFeS.pNt4dd.pN4_pesobruto, 3)
        _NFeS.pNt5tt.pT_pesol = Round(_NFeS.pNt4dd.pN4_pesoliquido, 3)

        Select Case Me.cbo_transportador.SelectedIndex
            Case 0
                _NFeS.pNt5tt.pT_tpfret = 0
                _NFeS.pNt5tt.pT_placa = Me.cbo_placa.SelectedItem.ToString
                _NFeS.pNt5tt.pT_marca = "Diversos"
                _NFeS.pNt5tt.pT_espec = "Volumes"

                Sqlcomm.Append("SELECT aut_placa, aut_descricao, aut_fornecedor, c.p_uf, c.p_portad, c.p_cpf, c.p_cgc, c.p_end, ") '7
                Sqlcomm.Append("c.p_mun, c.p_coduf, c.p_insc FROM cadautomovel JOIN ")
                Sqlcomm.Append("cadp001 c ON c.p_cod = aut_fornecedor WHERE aut_placa LIKE '" & _NFeS.pNt5tt.pT_placa & "'")
                oCmd = New NpgsqlCommand(Sqlcomm.ToString, conexaoConsultas)
                dr = oCmd.ExecuteReader

                While dr.Read

                    _NFeS.pNt5tt.pT_codp = dr(2).ToString
                    _NFeS.pNt5tt.pT_uf = dr(3).ToString
                    _NFeS.cliTranportador.pCod = dr(2).ToString
                    _NFeS.cliTranportador.pUf = dr(3).ToString
                    _NFeS.cliTranportador.pPortad = dr(4).ToString
                    _NFeS.cliTranportador.pCpf = dr(5).ToString
                    _NFeS.cliTranportador.pCgc = dr(6).ToString
                    _NFeS.cliTranportador.pEnder = dr(7).ToString
                    _NFeS.cliTranportador.pMun = dr(8).ToString
                    _NFeS.cliTranportador.pCoduf = dr(3).ToString
                    _NFeS.cliTranportador.pInsc = dr(10).ToString

                End While
                dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length)

                _NFeS.pNt5tt.pT_placa = _NFeS.pNt5tt.pT_placa.Replace("-", "")

            Case 1
                _NFeS.pNt5tt.pT_codp = "999999"
                _NFeS.pNt5tt.pT_tpfret = 1
                _NFeS.pNt5tt.pT_placa = Me.txt_placa.Text.Replace("-", "")
            Case 2
                _NFeS.pNt5tt.pT_codp = "999999"
                _NFeS.pNt5tt.pT_tpfret = 2
                _NFeS.pNt5tt.pT_placa = Me.txt_placa.Text.Replace("-", "")
            Case 3
                _NFeS.pNt5tt.pT_codp = "999999"
                _NFeS.pNt5tt.pT_tpfret = 9
        End Select

        If mExisteNota1pp = False Then _clBD.incNota5tt(_NFeS.pNt5tt, geno001, conexao, transacao)


        'INCIO do armazenamento dos Resumos...
        If mExisteNota1pp Then

            _clFuncoes.incResumAlqSaida(True, _NFeS.dtgItensResumo, _NFeS.pRes01, geno001, _clBD, conexao, transacao)
            _clFuncoes.incResumCfopAlqSaida(True, _NFeS.dtgItensResumo, _NFeS.pRes02, geno001, _clBD, conexao, transacao)
            _clFuncoes.incResumCstCfopAlqSaida(True, _NFeS.dtgItensResumo, _NFeS.pRes03, geno001, _clBD, conexao, transacao)

        Else

            _clFuncoes.incResumAlqSaida(False, _NFeS.dtgItensResumo, _NFeS.pRes01, geno001, _clBD, conexao, transacao)
            _clFuncoes.incResumCfopAlqSaida(False, _NFeS.dtgItensResumo, _NFeS.pRes02, geno001, _clBD, conexao, transacao)
            _clFuncoes.incResumCstCfopAlqSaida(False, _NFeS.dtgItensResumo, _NFeS.pRes03, geno001, _clBD, conexao, transacao)

        End If
        'FIM do armazenamento dos Resumos

        'INICIO do armazenamento das Notas referenciadas
        If mExisteNota1pp = False Then

            Try
                For i As Integer = 0 To _NFeS.notaref.Length - 1
                    _NFeS.notaref(i).nt1pp = _NFeS.pNt1pp.pNt_nume
                    _clBD.incNotaref(_NFeS.notaref(i), geno001, conexao, transacao)
                Next
            Catch ex As Exception
            End Try

        End If
        'FIM do armazenamento das Notas referenciadas

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
        _NFeS.pNt1pp.zeraValores()
        _NFeS.pNt2cc.zeraValores()
        _NFeS.pNt4dd.zeraValores()
        _NFeS.pNt5tt.zeraValores()
        _NFeS.pNt6hh.zeraValores()
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
        Select Case cbo_nfeCfop.SelectedItem.Substring(0, 5)
            Case "5.202", "5.906", "5.907", "6.202", "6.906", "6.907" 'Devolução ou Retorno
                If _NFeS.pNt1pp.pNt_refChave.Equals("") Then
                    MsgBox("NFe de Devolução DEVE ter todos os campos de Referência Preenchidos!", MsgBoxStyle.Exclamation)
                    Return False
                End If
        End Select


        Return True
    End Function

    Private Sub btn_nfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nfe.Click

        If verificaInformacoes() = False Then Return

        Try
            _clXml.sw.BaseStream.Seek(0, SeekOrigin.End)
        Catch ex As Exception
        End Try

        _clXml.mcfop = Mid(cbo_nfeCfop.SelectedItem, 7, 59)
        _NFeTrat.vnt_pag = _clFuncoes.trazCodPagamentoNFe(_clXml.mtipoPag, _clXml.mcfop)


        If lbl_numeroNota1pp.Text.Equals("") Then

            'Inclue os dados da NFe no banco de dados
            If incluirDadosNFe() Then

                If MessageBox.Show("Confirme Gerar Nota Fiscal", "Gerar NFe ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    gerandoNFe()

                Else
                    MessageBox.Show("Nota Fiscal Não Gerada !", "Finalização", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _clXml.fsxml.Close()
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
                    _clXml.fsxml.Close()
                    Me.Close()
                End If

            Else
                Me.Close()
            End If


        End If


    End Sub

    Private Function deletaValoresTabela(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        _NFeS.pNt1pp.pNt_nume = lbl_numeroNota1pp.Text
        _NFeS.pNt2cc.pNc_numer = lbl_numeroNota1pp.Text
        _NFeS.pNt4dd.pN4_numer = lbl_numeroNota1pp.Text
        _NFeS.pNt5tt.pT_numer = lbl_numeroNota1pp.Text
        _NFeS.pNt6hh.pC_numer = lbl_numeroNota1pp.Text
        _NFeS.pRes01.r4_numero = lbl_numeroNota1pp.Text
        _NFeS.pRes02.r4_numero = lbl_numeroNota1pp.Text
        _NFeS.pRes03.r4_numero = lbl_numeroNota1pp.Text

        _clBD.delNota6hh(_NFeS.pNt6hh, geno001, conexao, transacao)
        _clBD.delNota5tt(_NFeS.pNt5tt, geno001, conexao, transacao)
        _clBD.delNota2cc(_NFeS.pNt2cc, geno001, conexao, transacao)
        _clBD.delNota4dd(_NFeS.pNt4dd, geno001, conexao, transacao)
        _clBD.delResSaidaALQ(_NFeS.pRes01, geno001, conexao, transacao)
        _clBD.delResSaidaCfopALQ(_NFeS.pRes02, geno001, conexao, transacao)
        _clBD.delResSaidaCstCfopALQ(_NFeS.pRes03, geno001, conexao, transacao)
        _clBD.delNota1pp(_NFeS.pNt1pp, geno001, conexao, transacao)
        _clBD.delNotaref(lbl_numeroNota1pp.Text, geno001, conexao, transacao)


    End Function

    Private Sub gerandoNFe()


        Dim oConUp As New NpgsqlConnection(_clXml.conexao)
        'Dim oCmdUp As NpgsqlCommand

        Dim oConn As New NpgsqlConnection(_clXml.conexao)
        Dim oCmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim daCont As New NpgsqlDataAdapter
        Dim Mconsulta As Boolean = False
        Dim Sqlcomm As StringBuilder = New StringBuilder


        _clXml.codUf = geno001.pCoduf
        _clXml.AnoMes = Format(_NFeS.pNt1pp.pNt_dtemis, "yyMM")
        _clXml.anoMesPath = Format(_NFeS.pNt1pp.pNt_dtemis, "yyyyMM")
        _frmGeraNFe.frmGeraNFeRef.AnoMes = _clXml.AnoMes
        _frmGeraNFe.frmGeraNFeRef.anoMesPath = _clXml.anoMesPath
        _clXml.cgc = geno001.pCgc
        _clXml.modelo = "55"
        _clXml.serie = genp001.pSerie
        _clXml.numeroNfe = _NFeS.pNt1pp.pNt_nume
        _clXml.cont = genp001.pContf

        If lbl_numeroNota1pp.Text.Equals("") Then
            _clXml.chaveNFe = _clFuncoes.trazVlrColunaNota1pp(_NFeS.pNt1pp.pNt_nume, geno001.pEsquemaestab, "nt_chave", MdlConexaoBD.conectionPadrao)
        Else
            _clXml.chaveNFe = mChaveNFe
        End If

        If _clXml.chaveNFe.Equals("") Then
            _clXml.seqNFeInt = Convert.ToInt64(_clFuncoes.trazVlrColunaGenp001(geno001.pCodig, "gp_seqnfe", MdlConexaoBD.conectionPadrao))
            _clXml.seqNfe = String.Format("{0:D8}", _clXml.seqNFeInt)
            _clXml.seqNFeInt += 1
            _clBD.altGp_SeqNFeGenp001(String.Format("{0:D9}", _clXml.seqNFeInt), geno001.pCodig, MdlConexaoBD.conectionPadrao)
        End If


        'Tratamento da Chave da NFe.............
        If Trim(_clXml.chaveNFe).Equals("") Then 'Se o _NFeS.pNt1pp não tiver com chave

            _clXml.chaveSemDigitoFinal = _clXml.clNFe.Cria_ChaveNFeSemDigitoFinal(_clXml.codUf, _clXml.AnoMes, _clXml.cgc, _clXml.modelo, _clXml.serie, _clXml.numeroNfe, _clXml.cont, _clXml.seqNfe)
            _clXml.digito = _clXml.clNFe.Digito_ChaveNFe(_clXml.chaveSemDigitoFinal)
            _clXml.chaveNFe = _clXml.clNFe.Cria_ChaveNFe(_clXml.codUf, _clXml.AnoMes, _clXml.cgc, _clXml.modelo, _clXml.serie, _clXml.numeroNfe, _clXml.cont, _clXml.seqNfe, _clXml.digito)
            _clBD.altChaveNota1pp(_NFeS.pNt1pp.pNt_nume, _clXml.chaveNFe, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)

        Else 'Se já tiver chave no _NFeS.pNt1pp...
            _clBD.altChaveNota1pp(_NFeS.pNt1pp.pNt_nume, _clXml.chaveNFe, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
            _clXml.chaveSemDigitoFinal = Mid(_clXml.chaveNFe, 1, 43)
            _clXml.seqNfe = Mid(_clXml.chaveNFe, 36, 8)
            _clXml.digito = CInt(Mid(_clXml.chaveNFe, 44, 1))
        End If

        _frmGeraNFe.frmGeraNFeRef.chaveNFe = _clXml.chaveNFe


        '   * *  Inicio de Criação de XML  ***
        Try

            ' Cabeçalho Padrão do Xml
            _clXml.clNFe.Cria_xml(_clXml.sw)

            ' Chave da NFe
            _clXml.clNFe.Abre_xml_infNFe(_clXml.chaveNFe, _clXml.sw)

            ' Elementos do grupo B
            ' Identificação da Nota Fiscal eletrônica 
            ' vnt_dtemis = Date.Now

            _clXml.clNFe.xmlGrupo_B(geno001.pCoduf, _clXml.seqNfe, Trim(Mid(cbo_nfeCfop.SelectedItem, 8, 59)), _NFeS.pNt4dd.pN4_pgto, "55", CInt(genp001.pSerie), _NFeS.pNt1pp.pNt_nume, _
                            _NFeS.pNt1pp.pNt_dtemis, _NFeS.pNt1pp.pNt_dtsai, "1", geno001.pMun, "1", genp001.pContf, _clXml.digito, genp001.pAmb, _NFeS.pNt1pp.pNt_finNFe, "0", _
                            Mid(Application.ProductVersion, 1, 20), _NFeS.pNt1pp.pNt_indOper, _NFeS.pNt1pp.pNt_indFinal, _NFeS.pNt1pp.pNt_indPres, _
                            _NFeS.pNt1pp.pNt_refModDoc, _NFeS.notaref, _clXml.sw)
            ' Encerramento do Cabeçalho do Atributo Inicial


            ' '* Inicia Tag's do Grupo C -  Emitente da NFe '**
            ' Elementos do grupo C
            _clXml.clNFe.xmlGrupo_C(geno001.pCgc, geno001.pGeno, geno001.pEnder, geno001.pBair, geno001.pMun, geno001.pCid, geno001.pUf, _
                              geno001.pCep, geno001.pFone, geno001.pInsc, geno001.pCrt, _clXml.sw)

            ' '* Inicia Tag's do Grupo E -  Destinatario da NFe '**
            ' Elementos do grupo E
             Dim vp_suframa As String

            vp_suframa = ""
            If genp001.pAmb.Equals("2") Then ' Se estiver e ambiente de HOMOLOGAÇÃO
                cadp001.pPortad = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
            End If
            If Trim(cadp001.pBairro).Equals("") Then
                cadp001.pBairro = "CENTRO"
            End If

            _clXml.clNFe.xmlGrupo_E(cadp001.pCarac, cadp001.pCgc, cadp001.pCpf, cadp001.pPortad, cadp001.pEnder, cadp001.pBairro, cadp001.pMun, _
                              cadp001.pCid, cadp001.pUf, cadp001.pCep, cadp001.pFone, cadp001.pInsc, vp_suframa, cadp001.pEmail, _NFeS.pNt1pp.pNt_indDest, _clXml.sw)
            'Fim do Grupo E ******



            '''''''''''''''''''***
            ' Acoplando itens do pedido a Nfe - _NFeS.pNt2cc

            Dim conItens As New Npgsql.NpgsqlConnection(_clXml.conexao)
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
                SqlcomItens.Append(_NFeS.pNt1pp.pNt_nume & "' AND n2.nc_numer = n1.nt_nume ORDER BY n2.nc_seqitem ASC")
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
                    '!!! Teste...
                    'If vnc_codpr.Equals("00032") OrElse vnc_codpr.Equals("00375") Then vnc_codpr = vnc_codpr
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
                    vnc_cdport = _NFeS.pNt1pp.pNt_codig
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

                    vnc_vlpis = Round(vnc_vlpis, 2) : vnc_vlcofins = Round(vnc_vlcofins, 2)


                    _clXml.clNFe.xmlGrupo_L(vnc_seqitem, vnc_codpr, vnc_produt, vnc_ncm, vnc_cfop, vnc_cst, vnc_origem, vnc_csosn, _
                                      vnc_und, vnc_qtde, vnc_prunit, vnc_prtot, vnc_vldesc, vnc_bcalc, vnc_basesub, _
                                      vnc_icmsub, vnc_vlsubs, vnc_alqicm, vnc_vlicm, vnc_alqipi, vnc_vlipi, vnc_frete, _
                                      vnc_vldesc, vnc_indtot, vnc_cdbarra, vnc_descpac, vnc_reduz, geno001.pCrt, vnc_vltrib, _
                                      vnc_cstpis, vnc_cstcofins, genp001.pPis, genp001.pConfin, vnc_vlpis, vnc_vlcofins, vnc_segur, _clXml.sw)
                End While

                conItens.Close()
            Catch ex As NpgsqlException
                MsgBox(ex.Message.ToString) : Return
            Catch ex As Exception
                MsgBox(ex.Message.ToString) : Return
            End Try

            ''''''''''''''''''''
            ' '* Inicia Tag's do Grupo L -  Produtos da Nfe '**


            ' Valores Totais da NFe Tag W ' - _NFeS.pNt4dd
            _clXml.clNFe.xmlGrupo_W(_NFeS.pNt4dd.pN4_basec, _NFeS.pNt4dd.pN4_icms, _NFeS.pNt4dd.pN4_bsub, _NFeS.pNt4dd.pN4_icsub, _NFeS.pNt4dd.pN4_tprod, _
                              _NFeS.pNt4dd.pN4_frete, _NFeS.pNt4dd.pN4_segu, _NFeS.pNt4dd.pN4_desc, _NFeS.pNt4dd.pN4_ipi, _NFeS.pNt4dd.pN4_vlpis, _
                              _NFeS.pNt4dd.pN4_vlcofins, _NFeS.pNt4dd.pN4_outros, _NFeS.pNt4dd.pN4_tgeral, _NFeS.pNt4dd.pN4_totaltrib, _NFeS.pNt4dd.pN4_icmsdeson, _clXml.sw)

            ' '* Inicia Tag's do Grupo X -  Transportador da Nfe '**  - _NFeS.pNt5tt
            Dim vt_codp, codfret, mp_cpf, mp_cgc, mp_ie, mp_insc, mp_portad, mp_end, mp_cid As String
            Dim mp_uf, vt_placa, vt_antt, vt_uf, vt_marca, vt_espec As String
            vt_codp = "" : codfret = "" : mp_cpf = "" : mp_cgc = "" : mp_ie = "" : mp_insc = "" : mp_portad = ""
            mp_end = "" : mp_cid = "" : mp_uf = "" : vt_placa = "" : vt_antt = "" : vt_uf = "" : vt_marca = "" : vt_espec = ""
            Dim vt_pesol As Double = 0.0
            Dim vt_pesob As Double = 0.0
            Dim vt_qtde As Integer


            vt_codp = _NFeS.pNt5tt.pT_codp
            codfret = _NFeS.pNt5tt.pT_tpfret
            vt_marca = _NFeS.pNt5tt.pT_marca
            vt_espec = _NFeS.pNt5tt.pT_espec
            vt_placa = _NFeS.pNt5tt.pT_placa
            vt_antt = _NFeS.pNt5tt.pT_antt
            vt_uf = _NFeS.pNt5tt.pT_uf
            vt_qtde = _NFeS.pNt5tt.pT_qtde
            vt_pesol = _NFeS.pNt5tt.pT_pesol
            vt_pesob = _NFeS.pNt5tt.pT_pesob
            mp_cpf = _NFeS.cliTranportador.pCpf
            mp_cgc = _NFeS.cliTranportador.pCgc
            mp_insc = _NFeS.cliTranportador.pInsc
            mp_portad = _NFeS.cliTranportador.pPortad
            mp_end = _NFeS.cliTranportador.pEnder
            mp_uf = _NFeS.cliTranportador.pCoduf
            mp_cid = _NFeS.cliTranportador.pMun

            _clXml.clNFe.xmlGrupo_X(vt_codp, codfret, mp_cpf, mp_cgc, mp_insc, mp_portad, mp_end, mp_cid, mp_uf, vt_placa, _
                        vt_antt, vt_uf, vt_qtde, vt_espec, vt_marca, vt_pesol, vt_pesob, _clXml.sw)

            ' '* Inicia Tag's do Grupo Z -  Informações Complementares da Nfe '** - _NFeS.pNt6hh
            _clXml.clNFe.xmlGrupo_Z(_NFeS.pNt6hh.pC_compl1, _NFeS.pNt6hh.pC_compl2, _NFeS.pNt6hh.pC_compl3, _NFeS.pNt6hh.pC_compl4, _NFeS.pNt6hh.pC_compl5, _
                              _NFeS.pNt6hh.pC_compl6, _NFeS.pNt6hh.pC_compl7, _NFeS.pNt6hh.pC_compl8, _NFeS.pNt6hh.pC_compl9, _clXml.sw)


            _clXml.clNFe.Fecha_xml_infNFe(_clXml.sw)
            _clXml.clNFe.Fecha_xml(_clXml.sw)

            _clXml.sw.Close()
            _clXml.fsxml.Close()


            Try
                _frmGeraNFe.frmGeraNFeRef.clickGerar = True
                _frmGeraNFe.frmGeraNFeRef.genp001 = genp001

                _clXml.xmlArquivo.Remove(0, _clXml.xmlArquivo.ToString.Length)
                _clXml.xmlArquivo.Append(_clFuncoes.LerArquivoSalvo(_clXml.ArqTemp))
                _clBD.altXmlNota1pp(_NFeS.pNt1pp.pNt_nume, _clXml.xmlArquivo, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)

                _clXml.xmlPath = genp001.pathEnvioXML & "\" & _clXml.chaveNFe & "-nfe.xml"
                File.Copy(_clXml.ArqTemp, _clXml.xmlPath, True)
            Catch ex As Exception
                MsgBox("ERRO ao copiar o XML para """ & _clXml.xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
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
        _clXml.strXmlRetorno = _clFuncoes.lerXmlRetorno(_clXml.chaveNFe, genp001)


        If _clXml.strXmlRetorno.Equals("") Then 'Se retornou nada...
            System.Threading.Thread.Sleep(500)
            _clXml.strArqErroRetorno = _clFuncoes.lerArqErroRetorno(_clXml.chaveNFe, genp001)
            Me.rtb_mensagem.Text = _clXml.strArqErroRetorno
            Me.Refresh() : Me.btn_nfe.Enabled = False
            If _clXml.strArqErroRetorno.Equals("") Then Me.Close()
        Else


            'Tratamento do lote recebido...
            _clXml.strAux1 = "<NumeroLoteGerado>"
            _clXml.strAux2 = "</NumeroLoteGerado>"
            _clXml.xposinicio = _clXml.strXmlRetorno.IndexOf("<NumeroLoteGerado>") : _clXml.xposfim = _clXml.strXmlRetorno.IndexOf("</NumeroLoteGerado>")
            _clXml.xposdif = (_clXml.xposfim - _clXml.xposinicio) - _clXml.strAux1.Length
            Try
                _clXml.numLotRetorno = CInt(Mid(_clXml.strXmlRetorno, _clXml.xposinicio + _clXml.strAux2.Length, _clXml.xposdif))
                _clXml.numLotRetorno = String.Format("{0:D15}", CInt(_clXml.numLotRetorno))
            Catch ex As Exception
                MsgBox("ERRO ao Ler Xml Retorno """ & _clXml.xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
                Me.btn_nfe.Enabled = False
                Return False
            End Try

            Me.lbl_mensagem.Text = "Lendo o Lote de Recibo... !"
            Me.Refresh()
            System.Threading.Thread.Sleep(1000)
            _clXml.strXmlLoteRecebido = _clFuncoes.lerXmlLoteRecebido(_clXml.numLotRetorno, genp001)

            If _clXml.strXmlLoteRecebido.Equals("") = False Then ' se ele vinher alguma coisa


                _clXml.strAux1 = "<cStat>"
                _clXml.strAux2 = "</cStat>"
                _clXml.xposinicio = _clXml.strXmlLoteRecebido.IndexOf("<cStat>") : _clXml.xposfim = _clXml.strXmlLoteRecebido.IndexOf("</cStat>")
                _clXml.xposdif = (_clXml.xposfim - _clXml.xposinicio) - _clXml.strAux1.Length
                Try
                    _clXml.strXmlStatus = Mid(_clXml.strXmlLoteRecebido, _clXml.xposinicio + _clXml.strAux2.Length, _clXml.xposdif)

                    _clXml.strAux1 = "<xMotivo>"
                    _clXml.strAux2 = "</xMotivo>"
                    _clXml.xposinicio = _clXml.strXmlLoteRecebido.IndexOf("<xMotivo>") : _clXml.xposfim = _clXml.strXmlLoteRecebido.IndexOf("</xMotivo>")
                    _clXml.xposdif = (_clXml.xposfim - _clXml.xposinicio) - _clXml.strAux1.Length
                    _clXml.strXmlMotivo = Mid(_clXml.strXmlLoteRecebido, _clXml.xposinicio + _clXml.strAux2.Length, _clXml.xposdif)

                    Me.lbl_mensagem.Text = _clXml.strXmlStatus & " - " & _clXml.strXmlMotivo & " !"
                    Me.Refresh()


                    _clXml.strAux1 = "<nRec>"
                    _clXml.strAux2 = "</nRec>"
                    _clXml.xposinicio = _clXml.strXmlLoteRecebido.IndexOf("<nRec>") : _clXml.xposfim = _clXml.strXmlLoteRecebido.IndexOf("</nRec>")
                    _clXml.xposdif = (_clXml.xposfim - _clXml.xposinicio) - _clXml.strAux1.Length
                    _clXml.strXmlRec = Mid(_clXml.strXmlLoteRecebido, _clXml.xposinicio + _clXml.strAux2.Length, _clXml.xposdif)

                    Try

                        'Lendo o Arquivo de Recibo processado...
                        Me.lbl_mensagem.Text = "'Lendo o Arquivo de Recibo processado... !"
                        Me.Refresh()

                        System.Threading.Thread.Sleep(1000) '1 segundo...
                        _clXml.strXmlProcRec = _clFuncoes.lerXmlProRec(_clXml.strXmlRec, genp001)

                        _clXml.xposAux = _clXml.strXmlProcRec.IndexOf("</cStat>") + 10
                        _clXml.strXmlProcRecAux = _clXml.strXmlProcRec.Substring(_clXml.xposAux)
                        _clXml.strAux1 = "<cStat>"
                        _clXml.strAux2 = "</cStat>"
                        _clXml.xposinicio = _clXml.strXmlProcRecAux.IndexOf("<cStat>") : _clXml.xposfim = _clXml.strXmlProcRecAux.IndexOf("</cStat>")
                        _clXml.xposdif = (_clXml.xposfim - _clXml.xposinicio) - _clXml.strAux1.Length
                        _clXml.strXmlStatus = Mid(_clXml.strXmlProcRecAux, _clXml.xposinicio + _clXml.strAux2.Length, _clXml.xposdif)


                        _clXml.strAux1 = "<dhRecbto>"
                        _clXml.strAux2 = "</dhRecbto>"
                        _clXml.xposinicio = _clXml.strXmlProcRec.IndexOf("<dhRecbto>") : _clXml.xposfim = _clXml.strXmlProcRec.IndexOf("</dhRecbto>")
                        _clXml.xposdif = (_clXml.xposfim - _clXml.xposinicio) - _clXml.strAux1.Length
                        _clXml.strXmlHora = Mid(_clXml.strXmlProcRec, _clXml.xposinicio + _clXml.strAux2.Length, _clXml.xposdif)

                        Try

                            _clXml.strAux1 = "<nProt>"
                            _clXml.strAux2 = "</nProt>"
                            _clXml.xposinicio = _clXml.strXmlProcRec.IndexOf("<nProt>") : _clXml.xposfim = _clXml.strXmlProcRec.IndexOf("</nProt>")
                            _clXml.xposdif = (_clXml.xposfim - _clXml.xposinicio) - _clXml.strAux1.Length
                            _clXml.strXmlProtocolo = Mid(_clXml.strXmlProcRec, _clXml.xposinicio + _clXml.strAux2.Length, _clXml.xposdif)
                        Catch ex As Exception

                            _clXml.xposAux = _clXml.strXmlProcRec.IndexOf("</xMotivo>") + 10
                            _clXml.strXmlProcRecAux = _clXml.strXmlProcRec.Substring(_clXml.xposAux)
                            _clXml.strAux1 = "<xMotivo>"
                            _clXml.strAux2 = "</xMotivo>"
                            _clXml.xposinicio = _clXml.strXmlProcRecAux.IndexOf("<xMotivo>") : _clXml.xposfim = _clXml.strXmlProcRecAux.IndexOf("</xMotivo>")
                            _clXml.xposdif = (_clXml.xposfim - _clXml.xposinicio) - _clXml.strAux1.Length
                            _clXml.strXmlMotivo = Mid(_clXml.strXmlProcRecAux, _clXml.xposinicio + _clXml.strAux2.Length, _clXml.xposdif)
                            Me.lbl_mensagem.Text = _clXml.strXmlStatus & " - " & _clXml.strXmlMotivo
                            Me.Refresh() : Me.btn_nfe.Enabled = False

                        End Try

                    Catch ex As Exception
                        MsgBox("ERRO ao Arquivo de Recibo processado :: " & ex.Message, MsgBoxStyle.Exclamation)
                        Me.btn_nfe.Enabled = False
                        Return False
                    End Try

                    _frmGeraNFe.frmGeraNFeRef.mProtocolo = _clXml.strXmlProtocolo

                    _clBD.altWebrecNota1pp(_NFeS.pNt1pp.pNt_nume, _clXml.strXmlRec, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    _clBD.altHrwebNota1pp(_NFeS.pNt1pp.pNt_nume, _clXml.strXmlHora, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    _clBD.altLoteNota1pp(_NFeS.pNt1pp.pNt_nume, _clXml.numLotRetorno, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    _clBD.altProtoNota1pp(_NFeS.pNt1pp.pNt_nume, _clXml.strXmlProtocolo, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    If _clXml.strXmlStatus.Equals("100") Then
                        _clBD.altStatusNota1pp(_NFeS.pNt1pp.pNt_nume, _clXml.strXmlStatus, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    ElseIf _clXml.strXmlStatus.Equals("110") Then
                        _clBD.altStatusNota1pp(_NFeS.pNt1pp.pNt_nume, _clXml.strXmlStatus, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                        _clBD.altTipoNt_Nota1pp(_NFeS.pNt1pp.pNt_nume, "D", geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    End If
                    Me.lbl_mensagem.Text = _clXml.strXmlStatus & " - " & _clXml.strXmlMotivo
                    Me.Refresh()

                    System.Threading.Thread.Sleep(1000) '1 segundo...
                    _clXml.xmlArquivo.Remove(0, _clXml.xmlArquivo.ToString.Length)
                    _clXml.xmlArquivo.Append(_clFuncoes.lerXmlEnviado(_clXml.anoMesPath, _clXml.chaveNFe, genp001))
                    _clBD.altXmlNota1pp(_NFeS.pNt1pp.pNt_nume, _clXml.xmlArquivo, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)


                    If btn_nfe.Enabled Then MessageBox.Show("Nota Gerada c/ Sucessso !", "Finalização", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    _clBD.altSituacaoPedido_Orca1(Me.txt_pedido.Text, 5, MdlConexaoBD.conectionPadrao)
                    Me.Close()
                Catch ex As Exception
                    MsgBox("ERRO ao Ler Lote Recebido """ & _clXml.xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
                    Return False
                End Try


            Else

                _clXml.strXmlLoteRecebido = _clFuncoes.lerXmlIdLoteErro(_clXml.numLotRetorno, genp001)
                rtb_mensagem.Text = _clXml.strXmlLoteRecebido
                Me.Refresh() : Me.btn_nfe.Enabled = False
                If _clXml.strXmlLoteRecebido.Equals("") Then Me.Close()
            End If

        End If

        Return True
    End Function

    Private Sub LerRetornoXMl()
        _clXml.strXmlRetorno = _clFuncoes.lerXmlRetorno(_clXml.chaveNFe, genp001)
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

                genp001.pGeno = "G00" & CodEstab
                genp001.pRequis = drGenp(0).ToString : genp001.pSai = drGenp(1).ToString
                genp001.pFat = drGenp(2).ToString
                Try
                    genp001.pData = Convert.ChangeType(drGenp(3), GetType(Date))
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


            drGenp.Close() : conection.Close()
        Catch ex As Exception

            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
            geno001.zeraValores()

        End Try

        cmdGenp.CommandText = "" : sqlGenp.Remove(0, sqlGenp.ToString.Length)
        conection = Nothing : cmdGenp = Nothing : drGenp = Nothing : sqlGenp = Nothing




    End Sub

    Private Sub Frm_NFEAutorizanota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dtp_dtSaida.Text = DateValue(_clXml.agora)
        Me.cbo_tiponfe.SelectedIndex = 0
        Me.cbo_transportador.SelectedIndex = 0
        vnt_dtemis = DateValue(_clXml.agora)

        Me.cbo_estabelecimento = _clFuncoes.PreenchComboLoja2Dig(Me.cbo_estabelecimento, MdlConexaoBD.conectionPadrao)
        Me.cbo_estabelecimento.SelectedIndex = 0
        If cbo_estabelecimento.Items.Count > 1 Then Me.cbo_estabelecimento.SelectedIndex = _clFuncoes.trazIndexCboLoja2dig(_loja, cbo_estabelecimento)

        Dim mUfEstabelecimento As String = MdlEmpresaUsu._uf
        Me.chk_pauta.Checked = MdlEmpresaUsu.genp001.pauta
        Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopSaidas(mUfEstabelecimento, mUfEstabelecimento, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
        Me.cbo_placa = _clFuncoes.PreenchComboPlacaVeicNFe(Me.cbo_placa, MdlConexaoBD.conectionPadrao)

        'INICIO do Tratamento do DataGridView

        'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
        'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
        _NFeS.dtgItensResumo.Columns.Add("r4_numero", "r4_numero") : _NFeS.dtgItensResumo.Columns.Add("r4_cfop", "r4_cfop")
        _NFeS.dtgItensResumo.Columns.Add("r4_cst", "r4_cst") : _NFeS.dtgItensResumo.Columns.Add("r4_aliq", "r4_aliq")
        _NFeS.dtgItensResumo.Columns.Add("r4_tprod", "r4_tprod") : _NFeS.dtgItensResumo.Columns.Add("r4_tdesc", "r4_tdesc")
        _NFeS.dtgItensResumo.Columns.Add("r4_tfrete", "r4_tfrete") : _NFeS.dtgItensResumo.Columns.Add("r4_tseguro", "r4_tseguro")
        _NFeS.dtgItensResumo.Columns.Add("r4_toutrasdesp", "r4_toutrasdesp") : _NFeS.dtgItensResumo.Columns.Add("r4_bcalc", "r4_bcalc")
        _NFeS.dtgItensResumo.Columns.Add("r4_icms", "r4_icms") : _NFeS.dtgItensResumo.Columns.Add("r4_isento", "r4_isento")
        _NFeS.dtgItensResumo.Columns.Add("r4_outras", "r4_outras") : _NFeS.dtgItensResumo.Columns.Add("r4_ipi", "r4_ipi")
        _NFeS.dtgItensResumo.Columns.Add("r4_tgeral", "r4_tgeral")

        'FIM do Tratamento do DataGridView

        Try
            _clXml.fsxml = New FileStream(_clXml.ArqTemp, FileMode.Create, FileAccess.ReadWrite)
            _clXml.sw = New StreamWriter(_clXml.fsxml)
        Catch ex As Exception
            MsgBox("ERRO ao Criar Arquivo Temporário """ & _clXml.ArqTemp & """::" & ex.Message, MsgBoxStyle.Critical)
            Me.Close()
        End Try



        '**********
        If lbl_numeroNota1pp.Text.Equals("") = False Then

            CodEstab = MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2)
            cbo_estabelecimento.SelectedIndex = _clFuncoes.trazIndexCboLoja2dig(CodEstab, cbo_estabelecimento)
            cbo_estabelecimento.Enabled = False

            cboEstabLeave() : cboEstabLostFocus()

        End If

    End Sub

    Private Sub Frm_NFEAutorizanota_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            _clXml.fsxml.Close()
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

        If _clXml.formBusca = False Then
            If e.KeyChar = Convert.ToChar(13) Then
                e.Handled = True
                SendKeys.Send("{TAB}")

            End If
        End If

    End Sub

    Sub txt_codpart_keydownExtracted()

        If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus()
        _clFuncoes.trazCadp001(Me.txt_codPart.Text, cadp001) : _clFuncoes.trazCadp001(Me.txt_codPart.Text, mCliente)

        Try

            'preenche CBO CFOP...
            If Not cadp001.pUf.Equals("") Then
                Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopSaidas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
            End If

            Me.cbo_nfeCfop.Text = "" : Me.cbo_nfeCfop.SelectedIndex = -1
        Catch ex As Exception
        End Try

        Me.txt_nomePart.Focus()
        Me.txt_nomePart.SelectAll()

    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then


            If Me.txt_codPart.Text.Equals("") Then

                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    _clXml.formBusca = True
                    _mPesquisaForn = False
                    _frmREf = Me
                    _BuscaForn.set_frmRef(Me)
                    _BuscaForn.ShowDialog(Me)
                    _clXml.formBusca = False

                    txt_codpart_keydownExtracted()

                Catch ex As Exception
                End Try

            Else  ' Consulta pelo codigo do cliente...


                If trazFornecedor(Me.txt_codPart.Text) Then

                    txt_codpart_keydownExtracted()

                Else


                    'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                    Try
                        _clXml.formBusca = True
                        _mPesquisaForn = False
                        _frmREf = Me
                        _BuscaForn.set_frmRef(Me)
                        _BuscaForn.ShowDialog(Me)
                        _clXml.formBusca = False

                        txt_codpart_keydownExtracted()

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
            SqlParticipante.Append("p_fone, p_consumo, p_isento, p_carac FROM cadp001 WHERE p_cod = '" & pesquisa & "' ORDER BY p_portad ASC") '12
            CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDGENOV)
            drParticipante = CmdParticipante.ExecuteReader

            If drParticipante.HasRows = False Then

                MsgBox("Cliente não existe na Tabela!", MsgBoxStyle.Exclamation) : Me.txt_codPart.Text = ""
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
                    mCliente.pConsumo = drParticipante(10).ToString
                    mCliente.pIsento = drParticipante(11)
                    mCliente.pCarac = drParticipante(12).ToString

                End While
                drParticipante.Close()
                Me.txt_nomePart.Text = mNomePart


            End If

        Catch ex As Exception
        End Try

        CmdParticipante.CommandText = "" : SqlParticipante.Remove(0, SqlParticipante.ToString.Length)
        CmdParticipante = Nothing : SqlParticipante = Nothing : drParticipante = Nothing
        oConnBDGENOV.Close() : oConnBDGENOV = Nothing



        Return True
    End Function

    Private Sub Frm_NFEAutorizanota_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            _clXml.sw.Dispose()
            File.Delete(_clXml.ArqTemp)
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

    Public Function trazIndexCfop(ByVal mcfop As String, ByVal mCboCFOP As Object) As Integer
        Dim index As Integer
        For index = 0 To mCboCFOP.Items.Count - 1
            If _clXml.mcfop.Equals(mCboCFOP.Items.Item(index).ToString.Substring(0, 5)) Then
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

        _clXml.mNFe_Cfop = Mid(cboCFOP.SelectedItem, 1, 5)
        Try
            If Not mbUf.Equals("") Then
                If mbUf = geno001.pUf Then
                    If Mid(_clXml.mNFe_Cfop, 1, 1) <> "5" Then
                        MessageBox.Show("CFOP Invalido p/ Dentro do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        cboCFOP.Focus()
                        Return False

                    End If
                End If
                If mbUf <> geno001.pUf Then
                    If Mid(_clXml.mNFe_Cfop, 1, 1) = "5" Then
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

        _clFunc.trazGenoSelecionado("G00" & CodEstab, geno001)

    End Sub

    Private Sub cbo_tiponfe_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tiponfe.Leave
        If cbo_tiponfe.SelectedIndex = 0 Then
            Me.txt_pedido.MaxLength = 8
        End If
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

            _clXml.mtipoPag = _clFuncoes.trazValorColunaOrca1pp(Me.txt_pedido.Text, "nt_tipo2", geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)

            mExisteNota1pp = _clFuncoes.existPedidoNota1pp(Me.txt_pedido.Text, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
            If mExisteNota1pp Then
                mNumNota1ppExist = _clFuncoes.trazNumNota1ppPorPedido(Me.txt_pedido.Text, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                mCodPartNota1ppExist = _clFuncoes.trazCodPartNota1ppPorPedido(Me.txt_pedido.Text, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
            End If


            Me.lbl_totalNota.Text = Format(_clFuncoes.trazTotPedidoOrca4dd(Me.txt_pedido.Text, MdlConexaoBD.conectionPadrao), "###,##0.00")
            Me.lbl_qtdeItens.Text = Format(_clFuncoes.trazCountItensOrca2cc(Me.txt_pedido.Text, MdlConexaoBD.conectionPadrao), "###,###.##")

            If Me.txt_pedido.Text.Equals(_NFeS.pNt1pp.pNt_orca) = False Then
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

        _clXml.mNFe_Cfop = ""
        If cbo_nfeCfop.SelectedIndex >= 0 Then
            _clXml.mNFe_Cfop = cbo_nfeCfop.Text.Substring(0, 5)
            _clXml.digCFOP = Mid(cbo_nfeCfop.SelectedItem.ToString, 1, 1)
        End If

        Try

            If Not cadp001.pUf.Equals("") Then

                If cadp001.pUf = geno001.pUf Then
                    If Mid(_clXml.mNFe_Cfop, 1, 1) <> "5" Then

                        MessageBox.Show("CFOP Invalido p/ Dentro do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        Me.cbo_nfeCfop.Focus() : Me.cbo_nfeCfop.SelectedIndex = -1 : Me.cbo_nfeCfop.SelectAll() : Return

                    End If
                End If


                If cadp001.pUf <> geno001.pUf Then
                    If Mid(_clXml.mNFe_Cfop, 1, 1) = "5" Then

                        MessageBox.Show("CFOP Invalido p/ Fora do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        Me.cbo_nfeCfop.Focus() : Me.cbo_nfeCfop.SelectedIndex = -1 : Me.cbo_nfeCfop.SelectAll() : Return

                    End If
                End If
            End If

            Select Case _clXml.mNFe_Cfop.Substring(_clXml.mNFe_Cfop.Length - 3, 3)
                Case "202", "209"

                    _frmREf = Me
                    Dim mFrm_NFeRef As New Frm_NFeReferenciadaResp
                    mFrm_NFeRef.setNota1pp(_NFeS.pNt1pp)
                    mFrm_NFeRef.setFrmRef(Me)
                    mFrm_NFeRef.ShowDialog()
                    mFrm_NFeRef = Nothing

            End Select

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