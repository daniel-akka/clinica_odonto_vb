Imports Npgsql
Imports System.IO
Imports GenoNFeXml
Imports System.Math
Imports System.Text
Imports System.Data
Imports System.DateTime
Imports System.Threading

Public Class Frm_NFeOutrasEdicaoManifesto

    Dim mNFe_Cfop As String
    Public mbUf, mbCNPJ, mbInscr, mCodPart, mNomePart, mEnderecoPart, mCidadePart, mCepPart, mFonePart As String
    Public _mPesquisaForn As Boolean = False 'Serve para configura os campos CodFornec e NomeFornec
    Dim _mContErroCST As Int16 = 0
    Public isLote As Boolean = False
    Public tentarNovamente As Boolean = False

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
    Public Shared _frmREf As New Frm_NFeOutrasEdicaoManifesto
    Private buscaCliente As New Frm_buscaFornecedor
    Private buscaProduto As New Frm_buscaProdNFe


    'INICIO da Criação de Variáveis...
    'Gerais:
    Public _edicaoNFe As Boolean = True, _numNFePublic As String = "", _chaveNFePublic As String = ""
    Dim _trazendoValores As Boolean = True
    Dim _prodEditando As Boolean = False
    Dim _codProdEditando As String = ""
    Dim _qtdeAnteriorProd As Double
    Dim _indexProdEditando As Integer = 0

    'Totais:
    Dim _totProduto, _totBcalculo, _totICMS, _totBSubs, _totIcmsSubs, _totIPI, _totFrete, _totSeguro As Double
    Dim _totDespAcess, _totDesconto, _totGeral As Double


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

    Private Sub Frm_NFeOutrasEdicao_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try
            _clXml.sw.Close()
        Catch ex As Exception
        End Try

        Try
            _clXml.sw.Dispose() : _clXml.fsxml.Dispose()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        End Try

    End Sub

    'FIM da Criação de Variáveis

    Private Sub Frm_NFeOutrasEdicao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        zeraValoresGeral()

        btn_inclui.Enabled = _edicaoNFe
        btn_exclui.Enabled = _edicaoNFe
        btn_finaliza.Enabled = _edicaoNFe

        Me.cbo_placa = _clFuncoes.PreenchComboPlacaVeicNFe(Me.cbo_placa, MdlConexaoBD.conectionPadrao)

        chk_pauta.Checked = MdlEmpresaUsu.genp001.pauta

        'INICIO do Tratamento do DataGridView Resumo

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

        'FIM do Tratamento do DataGridView Resumo


        Try
            _clXml.fsxml = New FileStream(_clXml.ArqTemp, FileMode.Create, FileAccess.ReadWrite)
            _clXml.sw = New StreamWriter(_clXml.fsxml)
        Catch ex As Exception
            MsgBox("ERRO ao Criar Arquivo Temporário """ & _clXml.ArqTemp & """::" & ex.Message, MsgBoxStyle.Critical)
            Me.Close()
        End Try


        If _numNFePublic.Equals("") = False Then

            _prodEditando = True
            trazValoresNFe()
        End If


    End Sub

    Private Sub trazValoresNFe()


        Dim mConexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mSql As New StringBuilder
        Dim mCmd As NpgsqlCommand
        Dim mDr As NpgsqlDataReader
        Dim mCodEstab As String = Mid(MdlEmpresaUsu._codigo, MdlEmpresaUsu._codigo.Length - 1, 2)

        'Variaveis Registro:
        Dim mtipo, mcodCliente, mnomeCliente, mCfop, mtipoFrete, mPlaca, mcompl1, mcompl2 As String
        Dim mDataSaida As Date

        'Variaveis ITEMs:
        Dim mTotalGeraLItem As String = "0,00"

        Try
            mConexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão " & ex.Message, MsgBoxStyle.Exclamation)
            Return
        End Try



        'INICIO dos Tratamentos para o Registro...
        cbo_estabelecimento.SelectedIndex = _clFuncoes.trazIndexCboLoja2dig(mCodEstab, cbo_estabelecimento)
        cboEstabLeave()
        cbo_estabelecimento.Enabled = False

        mSql.Append("SELECT nt_tipo, nt_dtsai, nt_codig, p_portad, nt_cfop, t_tpfret, t_placa, c_compl1, c_compl2 FROM " & geno001.pEsquemaestab)
        mSql.Append(".nota5tt, " & geno001.pEsquemaestab & ".nota6hh, " & geno001.pEsquemaestab & ".nota1pp LEFT JOIN cadp001 ON p_cod = nt_codig ")
        mSql.Append("WHERE nt_nume = t_numer AND nt_nume = c_numer AND nt_nume = '" & _numNFePublic & "'")

        mCmd = New NpgsqlCommand(mSql.ToString, mConexao)
        mDr = mCmd.ExecuteReader
        While mDr.Read

            mtipo = mDr(0).ToString
            mDataSaida = mDr(1)
            mcodCliente = mDr(2).ToString
            mnomeCliente = mDr(3).ToString
            mCfop = mDr(4).ToString
            mtipoFrete = mDr(5).ToString
            mPlaca = mDr(6).ToString
            mcompl1 = mDr(7).ToString
            mcompl2 = mDr(8).ToString

        End While
        mDr.Close() : mSql.Remove(0, mSql.ToString.Length)

        cbo_tiponfe.SelectedIndex = 0
        If mtipo.Equals("E") Then cbo_tiponfe.SelectedIndex = 1
        cboTipoNFeLeave() : cbo_tiponfe.Enabled = False


        dtp_dtSaida.Value = mDataSaida

        Me.txt_codPart.Text = mcodCliente : Me.txt_codPart.Refresh()
        Me.txt_nomePart.Text = mnomeCliente
        trazPartKeyDown()

        cbo_nfeCfop.SelectedIndex = _clFuncoes.trazIndexComboBox(mCfop, 5, cbo_nfeCfop)
        cboCfopLeaveAux()


        Select Case mtipoFrete
            Case "0" 'Emitente
                Me.cbo_transportador.SelectedIndex = 0
                cbo_placa.SelectedIndex = _clFuncoes.trazIndexComboBox(mPlaca, mPlaca.Length, cbo_placa)
            Case "1" 'Destinatário 
                Me.cbo_transportador.SelectedIndex = 1
                txt_placa.Text = mPlaca
            Case "2" 'Terceiro
                Me.cbo_transportador.SelectedIndex = 2
                txt_placa.Text = mPlaca
            Case "9"
                Me.cbo_transportador.SelectedIndex = 3
        End Select

        txt_complemento1.Text = mcompl1
        txt_complemento2.Text = mcompl2
        'FIM dos Tratamentos para o Registro...



        'INICIO dos tratamentos pra os ITEMS...
        mSql.Append("SELECT nc_numer, nc_codpr, nc_produt, nc_und, nc_qtde, nc_pruvenda, nc_prunit, nc_prtot, ") '7
        mSql.Append("nc_cfop, nc_vldesc, nc_frete, nc_segur, nc_descpac, nc_bcalc, nc_alqicm, nc_vlicm, nc_basesub, ") '16
        mSql.Append("nc_alqsub, nc_vlsubs, nc_alqipi, nc_vlipi, nc_cf, nc_cst, nc_isento, nc_csosn, nc_vltrib, ") '25
        mSql.Append("nc_ncm, nc_desc, nc_voutro, nc_reduz, nc_alqreduz, nc_cstpis, nc_cstcofins, nc_cstipi, e_produt2, ") '34
        mSql.Append("e_produt3, e_pesobruto, e_pesoliq FROM ")
        mSql.Append(geno001.pEsquemaestab & ".nota2cc LEFT JOIN " & geno001.pEsquemavinc & ".est0001 ON e_codig = nc_codpr ")
        mSql.Append("WHERE nc_numer = '" & _numNFePublic & "'")

        mCmd = New NpgsqlCommand(mSql.ToString, mConexao)
        mDr = mCmd.ExecuteReader
        While mDr.Read

            _NFeS.pNt2cc.pNc_numer = mDr(0).ToString
            _NFeS.pNt2cc.pNc_codpr = mDr(1).ToString
            _NFeS.pNt2cc.pNc_produt = mDr(2).ToString
            _NFeS.pNt2cc.pNc_und = mDr(3).ToString
            _NFeS.pNt2cc.pNc_qtde = mDr(4)
            _NFeS.pNt2cc.pNc_pruvenda = mDr(5)
            _NFeS.pNt2cc.pNc_prunit = mDr(6)
            _NFeS.pNt2cc.pNc_prtot = mDr(7)
            _NFeS.pNt2cc.pNc_cfop = mDr(8).ToString
            _NFeS.pNt2cc.pNc_vldesc = mDr(9)
            _NFeS.pNt2cc.pNc_frete = mDr(10)
            _NFeS.pNt2cc.pNc_segur = mDr(11)
            _NFeS.pNt2cc.pNc_descpac = mDr(12)
            _NFeS.pNt2cc.pNc_bcalc = mDr(13)
            _NFeS.pNt2cc.pNc_alqicm = mDr(14)
            _NFeS.pNt2cc.pNc_vlicm = mDr(15)
            _NFeS.pNt2cc.pNc_basesub = mDr(16)
            _NFeS.pNt2cc.pNc_alqsub = mDr(17)
            _NFeS.pNt2cc.pNc_vlsubs = mDr(18)
            _NFeS.pNt2cc.pNc_alqipi = mDr(19)
            _NFeS.pNt2cc.pNc_vlipi = mDr(20)
            _NFeS.pNt2cc.pNc_cf = mDr(21).ToString
            _NFeS.pNt2cc.pNc_cst = mDr(22).ToString
            _NFeS.pNt2cc.pNc_isento = mDr(23)
            _NFeS.pNt2cc.pNc_csosn = mDr(24).ToString
            _NFeS.pNt2cc.pNc_vltrib = mDr(25)
            _NFeS.pNt2cc.pNc_ncm = mDr(26).ToString
            _NFeS.pNt2cc.pNc_desc = mDr(27)
            _NFeS.pNt2cc.pNc_voutro = mDr(28)
            _NFeS.pNt2cc.pNc_reduz = mDr(29)
            _NFeS.pNt2cc.pNc_alqreduz = mDr(30)
            _NFeS.pNt2cc.pNc_cstpis = mDr(31).ToString
            _NFeS.pNt2cc.pNc_cstcofins = mDr(32).ToString
            _NFeS.pNt2cc.pNc_cstipi = mDr(33).ToString
            produto.pProdut2 = mDr(34).ToString
            produto.pProdut3 = mDr(35).ToString
            produto.pPesobruto = mDr(36)
            produto.pPesoliq = mDr(37)
            If _NFeS.pNt2cc.pNc_pruvenda = 0 Then _NFeS.pNt2cc.pNc_pruvenda = Round((_NFeS.pNt2cc.pNc_prtot + _NFeS.pNt2cc.pNc_vldesc) / _NFeS.pNt2cc.pNc_qtde, 3)

            mTotalGeraLItem = Format(Round((_NFeS.pNt2cc.pNc_prtot + _NFeS.pNt2cc.pNc_frete + _NFeS.pNt2cc.pNc_segur + _
                                       _NFeS.pNt2cc.pNc_descpac + _NFeS.pNt2cc.pNc_vlsubs + _NFeS.pNt2cc.pNc_vlipi), 2), "#,###,##0.00")

            dtg_itensNFe.Rows.Add(_NFeS.pNt2cc.pNc_codpr, _NFeS.pNt2cc.pNc_produt, _NFeS.pNt2cc.pNc_und, Format(_NFeS.pNt2cc.pNc_qtde, "###,##0.00"), _
                                  Format(_NFeS.pNt2cc.pNc_pruvenda, "###,##0.000"), Format(_NFeS.pNt2cc.pNc_prunit, "###,##0.000"), _
                                  Format(_NFeS.pNt2cc.pNc_prtot, "###,##0.00"), _NFeS.pNt2cc.pNc_cfop, Format(_NFeS.pNt2cc.pNc_vldesc, "###,##0.00"), _
                                  Format(_NFeS.pNt2cc.pNc_frete, "###,##0.00"), Format(_NFeS.pNt2cc.pNc_segur, "###,##0.00"), _
                                  Format(_NFeS.pNt2cc.pNc_descpac, "###,##0.00"), Format(_NFeS.pNt2cc.pNc_bcalc, "###,##0.00"), _
                                  Format(_NFeS.pNt2cc.pNc_alqicm, "###,##0.00"), Format(_NFeS.pNt2cc.pNc_vlicm, "###,##0.00"), _
                                  Format(_NFeS.pNt2cc.pNc_basesub, "###,##0.00"), Format(_NFeS.pNt2cc.pNc_alqsub, "###,##0.00"), _
                                  Format(_NFeS.pNt2cc.pNc_vlsubs, "###,##0.00"), Format(_NFeS.pNt2cc.pNc_alqipi, "###,##0.00"), _
                                  Format(_NFeS.pNt2cc.pNc_vlipi, "###,##0.00"), _NFeS.pNt2cc.pNc_cf, _NFeS.pNt2cc.pNc_cst, _NFeS.pNt2cc.pNc_isento, _
                                  _NFeS.pNt2cc.pNc_csosn, _NFeS.pNt2cc.pNc_vltrib, _NFeS.pNt2cc.pNc_ncm, _NFeS.pNt2cc.pNc_desc, _NFeS.pNt2cc.pNc_voutro, _
                                  _NFeS.pNt2cc.pNc_reduz, _NFeS.pNt2cc.pNc_alqreduz, _NFeS.pNt2cc.pNc_cstpis, _NFeS.pNt2cc.pNc_cstcofins, _
                                  _NFeS.pNt2cc.pNc_cstipi, produto.pProdut2, produto.pProdut3, produto.pPesobruto, produto.pPesoliq, mTotalGeraLItem)

        End While
        mDr.Close() : mSql.Remove(0, mSql.ToString.Length)
        dtg_itensNFe.Refresh()

        'FIM dos tratamentos pra os ITEMS...


        'INICIO do tratamento da NFe Referenciada...
        mSql.Append("SELECT refid, refnumero, reftipo, refchave, refcoduf, refaamm, refcnpj, refmod, refserie, refecf, refcoo, nt1pp, ") '11
        mSql.Append("(SELECT count(*) FROM " & geno001.pEsquemaestab & ".notaref WHERE nt1pp = '" & _numNFePublic & "') ") '12
        mSql.Append("FROM " & geno001.pEsquemaestab & ".notaref WHERE nt1pp = '" & _numNFePublic & "'")

        mCmd = New NpgsqlCommand(mSql.ToString, mConexao)
        mDr = mCmd.ExecuteReader
        Dim mClNotaRef(1) As GenoNFeXml.Cl_notaref
        Dim mExist As Boolean = False, mcont As Integer = 0
        While mDr.Read

            If mExist = False Then ReDim Preserve mClNotaRef(mDr(12) - 1) : mExist = True

            mClNotaRef(mcont) = New GenoNFeXml.Cl_notaref(mDr(0), mDr(1).ToString, mDr(2).ToString, mDr(3).ToString, mDr(4).ToString, _
                                                          mDr(5).ToString, mDr(6).ToString, mDr(7).ToString, mDr(8).ToString, mDr(9).ToString, _
                                                          mDr(10).ToString, mDr(11).ToString)
            mcont += 1
        End While
        If mExist Then _NFeS.notaref = mClNotaRef
        mDr.Close() : mSql.Remove(0, mSql.ToString.Length)
        'FIM do tratamento da NFe Referenciada...

        _trazendoValores = False

        mConexao.Close() : mConexao = Nothing
    End Sub


    Private Sub Frm_NFeOutrasEdicao_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If _clXml.formBusca = False Then

            If e.KeyChar = Convert.ToChar(13) Then
                e.Handled = True
                SendKeys.Send("{TAB}")

            End If
        End If


    End Sub

    Private Sub Frm_NFeOutrasEdicao_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

    Private Sub cbo_estabelecimento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.GotFocus
        If cbo_estabelecimento.DroppedDown = False Then cbo_estabelecimento.DroppedDown = True
    End Sub

    Private Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged

        Try
            _clXml.codLoja = ""
            _clXml.codLoja = cbo_estabelecimento.SelectedItem.ToString.Substring(0, 2)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbo_estabelecimento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.Leave

        cboEstabLeave()
    End Sub

    Private Sub cboEstabLeave()

        lbl_mensagem.Text = ""
        If _clXml.codLoja.Equals("") Then

            lbl_mensagem.Text = "Selecione uma Loja Por Favor !"
            cbo_estabelecimento.Focus()
            _clXml.codLoja = MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2)
            cbo_estabelecimento.SelectedIndex = _clFuncoes.trazIndexCboLoja2dig(_clXml.codLoja, cbo_estabelecimento)
            Return

        Else
            _clFuncoes.trazGenoSelecionado("G00" & _clXml.codLoja, geno001)
            _clFuncoes.trazGenpSelecionado("G00" & _clXml.codLoja, genp001)
        End If


        Select Case genp001.pAmb
            Case "1"
                Me.lbl_ambiente.Text = "Produção"
            Case "2"
                Me.lbl_ambiente.Text = "Homologação"
        End Select

        Select Case genp001.pContf
            Case "1"
                Me.lbl_tipoemissao.Text = "Normal"
            Case "3"
                Me.lbl_tipoemissao.Text = "Contingência(SCAN)"
            Case "4"
                Me.lbl_tipoemissao.Text = "Contigência DPEC"
        End Select

    End Sub

    Private Sub cbo_tiponfe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tiponfe.GotFocus
        If cbo_tiponfe.DroppedDown = False Then cbo_tiponfe.DroppedDown = True
    End Sub

    Private Sub cbo_tiponfe_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tiponfe.Leave

        cboTipoNFeLeave()

    End Sub

    Private Sub cboTipoNFeLeave()

        lbl_mensagem.Text = ""
        If cbo_tiponfe.SelectedIndex < 0 Then

            lbl_mensagem.Text = "Selecione o Tipo da NFe Por Favor !"
            cbo_tiponfe.Focus() : cbo_tiponfe.SelectedIndex = 0

        Else
            _clXml.tipoNFe = Mid(cbo_tiponfe.SelectedItem.ToString, 1, 1)
        End If

    End Sub

#Region "   *** Funções e Procedimentos Auxiliares ***   "

    Private Sub enviaTecla(ByVal tecla As String)
        SendKeys.Send("{" & tecla & "}")
    End Sub

    Sub zeraValoresGeral()

        txt_alqicms.Text = "0,00"
        txt_alqipi.Text = "0,00"
        txt_alqsubs.Text = "0,00"
        txt_basecalc.Text = "0,00"
        txt_basesubs.Text = "0,00"
        txt_cfop.Text = ""
        txt_codProd.Text = ""
        txt_codPart.Text = ""
        txt_desconto.Text = "0,00"
        txt_despacessoria.Text = "0,00"
        txt_frete.Text = "0,00"
        txt_nomePart.Text = ""
        txt_nomeProd.Text = ""
        txt_qtde.Text = "0,000"
        txt_total.Text = "0,00"
        txt_vlicms.Text = "0,00"
        txt_vlipi.Text = "0,00"
        txt_vlsubs.Text = "0,00"
        txt_seguro.Text = "0,00"
        txt_vlunitario.Text = "0,0000"
        txt_pruvenda.Text = "0,0000"

        cbo_estabelecimento = _clFuncoes.PreenchComboLoja2Dig(cbo_estabelecimento, MdlConexaoBD.conectionPadrao)
        _clXml.codLoja = MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2)
        cbo_estabelecimento.SelectedIndex = _clFuncoes.trazIndexCboLoja2dig(_clXml.codLoja, cbo_estabelecimento)

    End Sub

    Sub zeraValoresItems()

        txt_alqicms.Text = "0,00"
        txt_alqipi.Text = "0,00"
        txt_alqsubs.Text = "0,00"
        txt_basecalc.Text = "0,00"
        txt_basesubs.Text = "0,00"
        txt_cfop.Text = ""
        txt_codProd.Text = ""
        txt_desconto.Text = "0,00"
        txt_despacessoria.Text = "0,00"
        txt_frete.Text = "0,00"
        txt_seguro.Text = "0,00"
        txt_nomeProd.Text = ""
        txt_qtde.Text = "0,000"
        txt_total.Text = "0,00"
        txt_vlicms.Text = "0,00"
        txt_vlipi.Text = "0,00"
        txt_vlsubs.Text = "0,00"
        txt_seguro.Text = "0,00"
        txt_vlunitario.Text = "0,0000"
        txt_pruvenda.Text = "0,0000"
        lbl_qtdFiscal.Text = "0"

    End Sub

    Private Sub buscaCFOP()

        _clXml.cfopRef = Me.txt_cfop.Text
        Dim buscaCfop As New Frm_CfopResp
        buscaCfop.set_frmRef(Me)
        buscaCfop.ShowDialog()
        Me.txt_cfop.Text = _clXml.cfopRef.Replace(".", "")

    End Sub

    Private Sub alteraVlUnit_PcoTotal()

        Dim valorTotal As Double = 0.0
        Dim valorUnit As Double = 0.0
        valorTotal = Round(((CDec(Me.txt_pruvenda.Text) * CDec(Me.txt_qtde.Text)) - CDec(txt_desconto.Text)), 2)
        valorUnit = Round(valorTotal / CDec(txt_qtde.Text), 4)

        Try
            Me.txt_vlunitario.Text = Format(valorUnit, "###,##0.0000")
        Catch ex As Exception
            Me.txt_vlunitario.Text = Format(0.0, "###,##0.0000")
        End Try

        Try
            Me.txt_total.Text = Format(Round(CDec(Me.txt_vlunitario.Text) * CDec(Me.txt_qtde.Text), 4), "###,##0.00")
        Catch ex As Exception
            Me.txt_total.Text = Format(0.0, "###,##0.00")
        End Try

    End Sub

    Private Function validaIcmsNormal() As Boolean


        'INICIO da validação do ICMS NORMAL
        If (CDec(txt_basecalc.Text) > 0) Then

            If (CDec(txt_alqicms.Text) <= 0) Then
                lbl_mensagem.Text = "A Aliquota do ICMS NORMAL devem ser maior que ZERO para Base de Calculo com Valor !"
                txt_alqicms.Focus() : txt_alqicms.SelectAll() : Return False
            End If

            If (CDec(txt_vlicms.Text) <= 0) Then
                lbl_mensagem.Text = "O Valor do ICMS NORMAL devem ser maior que ZERO para Base de Calculo com Valor !"
                txt_vlicms.Focus() : txt_vlicms.SelectAll() : Return False
            End If
        End If


        If (CDec(txt_alqicms.Text) > 0) Then

            If (CDec(txt_basecalc.Text) <= 0) Then
                lbl_mensagem.Text = "A Base de Calculo do ICMS NORMAL devem ser maior que ZERO para Aliquota com Valor !"
                txt_basecalc.Focus() : txt_basecalc.SelectAll() : Return False
            End If

            If (CDec(txt_vlicms.Text) <= 0) Then
                lbl_mensagem.Text = "O Valor do ICMS NORMAL devem ser maior que ZERO para Aliquota com Valor !"
                txt_vlicms.Focus() : txt_vlicms.SelectAll() : Return False
            End If
        End If


        If (CDec(txt_vlicms.Text) > 0) Then

            If (CDec(txt_alqicms.Text) <= 0) Then
                lbl_mensagem.Text = "A Aliquota do ICMS NORMAL devem ser maior que ZERO para Valor ICMS com Valor !"
                txt_alqicms.Focus() : txt_alqicms.SelectAll() : Return False
            End If

            If (CDec(txt_basecalc.Text) <= 0) Then
                lbl_mensagem.Text = "A Base de Calculo do ICMS NORMAL devem ser maior que ZERO para Valor ICMS com Valor !"
                txt_basecalc.Focus() : txt_basecalc.SelectAll() : Return False
            End If
        End If
        'FIM da Validação do ICMS NORMAL


        Return True
    End Function

    Private Function validaIcmsNormalZERADOS_CST(ByVal cst As String) As Boolean

        'INICIO da validação do ICMS NORMAL
        If (CDec(txt_basecalc.Text) <= 0) Then
            lbl_mensagem.Text = "A Base de Calculo do ICMS NORMAL devem ser maior que ZERO para produto com CST " & cst & " !"
            txt_basecalc.Focus() : txt_basecalc.SelectAll() : Return False
        End If

        If (CDec(txt_alqicms.Text) <= 0) Then
            lbl_mensagem.Text = "A Aliquota do ICMS NORMAL devem ser maior que ZERO para produto com CST " & cst & " !"
            txt_alqicms.Focus() : txt_alqicms.SelectAll() : Return False
        End If

        If (CDec(txt_vlicms.Text) <= 0) Then
            lbl_mensagem.Text = "O Valor do ICMS NORMAL devem ser maior que ZERO para produto com CST " & cst & " !"
            txt_vlicms.Focus() : txt_vlicms.SelectAll() : Return False
        End If
        'FIM da Validação do ICMS NORMAL

        Return True
    End Function

    Private Function validaIcmsNormalVALORES_CST(ByVal cst As String) As Boolean

        'INICIO da Validação do ICMS NORMAL
        If (CDec(txt_basecalc.Text) > 0) Then
            lbl_mensagem.Text = "Os valores de ICMS NORMAL devem ser ZERADOS para produto com CST " & cst & " !"
            txt_basecalc.Focus() : txt_basecalc.SelectAll() : Return False
        End If

        If (CDec(txt_alqicms.Text) > 0) Then
            lbl_mensagem.Text = "Os valores de ICMS NORMAL devem ser ZERADOS para produto com CST " & cst & " !"
            txt_alqicms.Focus() : txt_alqicms.SelectAll() : Return False
        End If

        If (CDec(txt_vlicms.Text) > 0) Then
            lbl_mensagem.Text = "Os valores de ICMS NORMAL devem ser ZERADOS para produto com CST " & cst & " !"
            txt_vlicms.Focus() : txt_vlicms.SelectAll() : Return False
        End If
        'FIM da Validação do ICMS NORMAL

        Return True
    End Function

    Private Function validaIcmsSubstitutoZERADOS_CST(ByVal cst As String) As Boolean

        'INICIO da validação do ICMS SUBSTITUTO
        If (CDec(txt_basesubs.Text) <= 0) Then
            lbl_mensagem.Text = "Os valores de ICMS SUBSTITUTO devem ser Maior que ZERO para produto com CST " & cst & " !"
            txt_basesubs.Focus() : txt_basesubs.SelectAll() : Return False
        End If

        If (CDec(txt_alqsubs.Text) <= 0) Then
            lbl_mensagem.Text = "Os valores de ICMS SUBSTITUTO devem ser Maior que ZERO para produto com CST " & cst & " !"
            txt_alqsubs.Focus() : txt_alqsubs.SelectAll() : Return False
        End If

        If (CDec(txt_vlsubs.Text) <= 0) Then
            lbl_mensagem.Text = "Os valores de ICMS SUBSTITUTO devem ser Maior que ZERO para produto com CST " & cst & " !"
            txt_vlsubs.Focus() : txt_vlsubs.SelectAll() : Return False
        End If
        'FIM da Validação do ICMS SUBSTITUTO


        Return True
    End Function

    Private Function validaIcmsSubstitutoVALORES_CST(ByVal cst As String) As Boolean

        'INICIO da validação do ICMS SUBSTITUTO
        If (CDec(txt_basesubs.Text) > 0) Then
            lbl_mensagem.Text = "Os valores de ICMS SUBSTITUTO devem ser ZERADOS para produto com CST """ & cst & """ !"
            txt_basesubs.Focus() : txt_basesubs.SelectAll() : Return False
        End If

        If (CDec(txt_alqsubs.Text) > 0) Then
            lbl_mensagem.Text = "Os valores de ICMS SUBSTITUTO devem ser ZERADOS para produto com CST """ & cst & """ !"
            txt_alqsubs.Focus() : txt_alqsubs.SelectAll() : Return False
        End If

        If (CDec(txt_vlsubs.Text) > 0) Then
            lbl_mensagem.Text = "Os valores de ICMS SUBSTITUTO devem ser ZERADOS para produto com CST """ & cst & """ !"
            txt_vlsubs.Focus() : txt_vlsubs.SelectAll() : Return False
        End If
        'FIM da validação do ICMS SUBSTITUTO

        Return True
    End Function

    Private Function validaCamposItem() As Boolean

        lbl_mensagem.Text = ""

        If existeItemGrid(txt_codProd.Text) And _prodEditando = False Then
            lbl_mensagem.Text = "Esse Produto Já foi Adicionado !" : Return False
        End If


        'SITUAÇÃO CST:
        '00 - Trib. Integral
        '10 - Trib. Icms/Subst.
        '20 - Com Redução
        '30 - Isenta /Não Trib.
        '40 - Isenta
        '41 - Não Tributada
        '51 - Diferimento
        '60 - ICMS Substituto
        '70 - Redução e Icms p/ Subst.
        '90 - Outros

        Select Case _clXml._cst
            Case "30", "40", "41", "60" '          ! Não informar os ICMS(Normal e Substituto) !

                If validaIcmsNormalVALORES_CST("30, 40, 41 ou 60") = False Then Return False

                If validaIcmsSubstitutoVALORES_CST("30, 40, 41 ou 60") = False Then Return False


                Select Case Mid(_clXml._cfop, 2, 3) 'CFOP da NOta
                    Case "152" 'Transferencia pra deposito fechado

                        If (Mid(txt_cfop.Text, 2, 3) <> "409") AndAlso (_clXml._cst = "60") Then
                            lbl_mensagem.Text = "O CFOP deve ser terminar em 409 para produto com CST ""60"" !"
                            txt_cfop.Focus() : txt_cfop.SelectAll() : Return False
                        End If
                    Case "905", "906" 'Remessa pra deposito fechado

                        If (Mid(txt_cfop.Text, 2, 3) <> "905") AndAlso (Mid(txt_cfop.Text, 2, 3) <> "906") Then
                            lbl_mensagem.Text = "O CFOP deve ser terminar em ""905, 906"" para produto com CST ""60"" !"
                            txt_cfop.Focus() : txt_cfop.SelectAll() : Return False
                        End If
                    Case "202", "201"

                    Case Else

                        If (Mid(txt_cfop.Text, 2, 3) <> "403") AndAlso (Mid(txt_cfop.Text, 2, 3) <> "404") AndAlso _
                            (Mid(txt_cfop.Text, 2, 3) <> "405") Then
                            lbl_mensagem.Text = "O CFOP deve ser terminar em ""403, 404, 405"" para produto com CST ""30, 40, 41 ou 60"" !"
                            txt_cfop.Focus() : txt_cfop.SelectAll() : Return False
                        End If

                End Select



            Case "00" '          ! Não Informar o ICMS SUBSTITUTO !

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

                        If CDec(Me.txt_basecalc.Text) > 0 Then
                            If validaIcmsNormalZERADOS_CST("00") = False Then Return False
                            If validaIcmsSubstitutoVALORES_CST("00") = False Then Return False
                        End If


                    Case "2" '1 - Simples Nacional com Retenção

                        If CDec(Me.txt_basecalc.Text) > 0 Then
                            If validaIcmsNormalZERADOS_CST("00") = False Then Return False
                            If validaIcmsSubstitutoVALORES_CST("00") = False Then Return False
                        End If

                    Case "3" '3 - Regime Normal

                        If validaIcmsNormalZERADOS_CST("00") = False Then Return False
                        If validaIcmsSubstitutoVALORES_CST("00") = False Then Return False

                End Select






                Select Case Mid(_clXml._cfop, 2, 3) 'CFOP da NOta
                    Case "152" 'Transferencia pra deposito fechado

                        If (Mid(txt_cfop.Text, 2, 3) <> "152") Then
                            lbl_mensagem.Text = "O CFOP deve ser terminar em 152 para produto com CST ""60"" !"
                            txt_cfop.Focus() : txt_cfop.SelectAll() : Return False
                        End If
                    Case "905", "906" 'Remessa pra deposito fechado

                        If (Mid(txt_cfop.Text, 2, 3) <> "905") AndAlso (Mid(txt_cfop.Text, 2, 3) <> "906") Then
                            lbl_mensagem.Text = "O CFOP deve ser terminar em ""905, 906"" para produto com CST ""60"" !"
                            txt_cfop.Focus() : txt_cfop.SelectAll() : Return False
                        End If

                End Select

            Case "10" '          ! Pode ou Não informar o ICMS NORMAL !

                If validaIcmsSubstitutoZERADOS_CST("10") = False Then Return False

                If validaIcmsNormal() = False Then Return False



        End Select



        'INICIO da validação do IPI
        If CDec(txt_vlipi.Text) > 0 Then

            If CDec(txt_alqipi.Text) <= 0 Then
                lbl_mensagem.Text = "Aliquota do IPI deve ser Maior que ZERO quando o Valor do IPI for Maior que ZERO !"
                txt_alqipi.Focus() : txt_alqipi.SelectAll() : Return False
            End If
        Else

            If CDec(txt_alqipi.Text) > 0 Then
                lbl_mensagem.Text = "Aliquota do IPI deve ser ZERO quando o Valor do IPI for ZERO !"
                txt_alqipi.Focus() : txt_alqipi.SelectAll() : Return False
            End If
        End If
        'FIM da Validação do IPI


        'Para Simples o "CSOSN = 900" se tiver preenchido os valores de ICMS NORMAL e ICMS SUBSTITUTO
        'SENÃO irá seguir o padrão do FrmAutoriza NF-e...


        Return True
    End Function

    Private Function existeItemGrid(ByVal codItem As String) As Boolean

        For Each row As DataGridViewRow In dtg_itensNFe.Rows

            If row.IsNewRow = False Then

                If row.Cells(0).Value.ToString.Equals(codItem) Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Private Sub addItemGrid()


        lbl_mensagem.Text = ""
        Dim conexaoNcm As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conexaoNcm.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão para DataReader:: " & ex.Message, MsgBoxStyle.Critical) : Return
        End Try

        Try

            _NFeS.pNt1pp.pNt_cfop = Mid(Me.cbo_nfeCfop.SelectedItem, 1, 5)
            'variaveis conexão:
            Dim SqlNcm As String = ""
            Dim drNcm As NpgsqlDataReader
            Dim commNcm As NpgsqlCommand

            'Variaveis _NFeS.pNt2cc:
            Dim cfv, grupo As Integer
            Dim cfopRegistroItem As String
            Dim mTotalGeraLItem As String
            Dim valorTotal, alqDesc, qtdeFiscalAtual, vnc_vlPis, vnc_vlCofins, vnc_prtotAux As Double
            _NFeS.pNt2cc.zeraValores()

            _NFeS.pNt2cc.pNc_codpr = Me.txt_codProd.Text
            _NFeS.pNt2cc.pNc_produt = Me.txt_nomeProd.Text
            _NFeS.pNt2cc.pNc_cfop = Me.txt_cfop.Text
            _NFeS.pNt2cc.pNc_qtde = Me.txt_qtde.Text
            _NFeS.pNt2cc.pNc_pruvenda = Me.txt_pruvenda.Text
            _NFeS.pNt2cc.pNc_vldesc = Me.txt_desconto.Text
            _NFeS.pNt2cc.pNc_prunit = Me.txt_vlunitario.Text
            _NFeS.pNt2cc.pNc_prtot = Me.txt_total.Text
            _NFeS.pNt2cc.pNc_frete = Me.txt_frete.Text
            _NFeS.pNt2cc.pNc_segur = Me.txt_seguro.Text
            _NFeS.pNt2cc.pNc_descpac = Me.txt_despacessoria.Text
            _NFeS.pNt2cc.pNc_bcalc = Me.txt_basecalc.Text
            _NFeS.pNt2cc.pNc_alqicm = Me.txt_alqicms.Text
            _NFeS.pNt2cc.pNc_vlicm = Me.txt_vlicms.Text
            _NFeS.pNt2cc.pNc_basesub = Me.txt_basesubs.Text
            _NFeS.pNt2cc.pNc_alqsub = Me.txt_alqsubs.Text
            _NFeS.pNt2cc.pNc_vlsubs = Me.txt_vlsubs.Text
            _NFeS.pNt2cc.pNc_alqipi = Me.txt_alqipi.Text
            _NFeS.pNt2cc.pNc_vlipi = Me.txt_vlipi.Text

            valorTotal = Round(CDec(Me.txt_total.Text) + CDec(Me.txt_desconto.Text), 2)
            Try
                alqDesc = Round((CDec(Me.txt_desconto.Text) * 100) / valorTotal, 2)
            Catch ex As Exception
                alqDesc = 0.0
            End Try
            _NFeS.pNt2cc.pNc_desc = alqDesc


            _NFeS.pNt2cc.pNc_cf = produto.pClf
            _NFeS.pNt2cc.pNc_cst = _clXml._cst 'Format(produto.pCst, "00")
            cfv = produto.pCfv
            grupo = produto.pGrupo
            _NFeS.pNt2cc.pNc_und = produto.pUnd
            _NFeS.pNt2cc.pNc_isento = 0.0
            If cfv = 4 Then _NFeS.pNt2cc.pNc_isento = _NFeS.pNt2cc.pNc_prtot
            _NFeS.pNt2cc.pNc_csosn = ""
            _NFeS.pNt2cc.pNc_vltrib = 0.0

            _NFeS.pNt2cc.pNc_alqreduz = produto.pReduz
            _NFeS.pNt2cc.pNc_reduz = 0.0
            If _NFeS.pNt2cc.pNc_alqreduz > 0 Then _NFeS.pNt2cc.pNc_reduz = Round((_NFeS.pNt2cc.pNc_prtot * _NFeS.pNt2cc.pNc_alqreduz) / 100, 2)


            'Tratamento do NCM....
            _NFeS.pNt2cc.pNc_ncm = produto.pNcm
            If _NFeS.pNt2cc.pNc_ncm.Length <> 8 Then
                MsgBox("Produto """ & _NFeS.pNt2cc.pNc_codpr & """ corrigir NCM!  Por Favor alterar no cadastro do Produto", MsgBoxStyle.Exclamation)
                Return
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

                    '_NFeS.pNt2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, _NFeS.pNt1pp.pNt_cfop, 0)
                    If _NFeS.pNt2cc.pNc_bcalc > 0 Then
                        _NFeS.pNt2cc.pNc_csosn = "101"
                    Else

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
                    End If


                    If (_NFeS.pNt2cc.pNc_vlsubs > 0) OrElse (_NFeS.pNt2cc.pNc_vlipi > 0) Then
                        _NFeS.pNt2cc.pNc_csosn = "900"
                    End If



                Case "2" '1 - Simples Nacional com Retenção
                    '_NFeS.pNt2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, _NFeS.pNt1pp.pNt_cfop, 0)
                    Select Case cfv
                        Case 1
                            _NFeS.pNt2cc.pNc_csosn = "202"
                            _NFeS.pNt2cc.pNc_vlsubs = 0 : _NFeS.pNt2cc.pNc_alqsub = 0
                            _NFeS.pNt2cc.pNc_basesub = 0
                        Case 3 'Produto com substituição
                            _NFeS.pNt2cc.pNc_csosn = "500"
                        Case 4
                            _NFeS.pNt2cc.pNc_csosn = "102"
                    End Select

                    If (_NFeS.pNt2cc.pNc_vlsubs > 0) OrElse (_NFeS.pNt2cc.pNc_vlipi > 0) Then
                        _NFeS.pNt2cc.pNc_csosn = "900"
                    End If

                Case "3" '3 - Regime Normal

                    If cfv = 3 Then
                        _NFeS.pNt2cc.pNc_alqicm = 0.0 : _NFeS.pNt2cc.pNc_vlicm = 0.0
                        _NFeS.pNt6hh.pC_compl5 = "(*) ICMS PAGO ANTEC CONF.DECR. N.6551/85 E 9483/97"
                        _NFeS.pNt2cc.pNc_produt = RTrim(_NFeS.pNt2cc.pNc_produt) & " (*)"
                        _NFeS.pNt4dd.pN4_outras = _NFeS.pNt4dd.pN4_outras + Round((_NFeS.pNt2cc.pNc_qtde * _NFeS.pNt2cc.pNc_prunit), 2)
                    End If

                    If _NFeS.pNt1pp.pNt_cfop.Substring(0, 1).Equals("5") Then
                        _NFeS.pNt2cc.pNc_alqicm = _clXml.alqInterna
                    ElseIf _NFeS.pNt1pp.pNt_cfop.Substring(0, 1).Equals("6") Then
                        _NFeS.pNt2cc.pNc_alqicm = _clXml.alqExterna
                    End If

                    '_NFeS.pNt2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, _NFeS.pNt1pp.pNt_cfop, 0)

            End Select


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

            _NFeS.pNt2cc.pNc_cstipi = produto.pCstIpi

            'Tratamento do PIS/COFINS ............
            cfopRegistroItem = _NFeS.pNt2cc.pNc_cfop.Substring(_NFeS.pNt2cc.pNc_cfop.Length - 3, 3)
            SqlNcm = "SELECT ncm_pissaid, ncm_cofinssaid FROM estncm WHERE ncm_ncm = '" & _NFeS.pNt2cc.pNc_ncm & "' " & _
            "AND ncm_cfop LIKE '%" & cfopRegistroItem & "%' LIMIT 1"
            commNcm = New NpgsqlCommand(SqlNcm, conexaoNcm)
            drNcm = commNcm.ExecuteReader
            If drNcm.HasRows = False Then
                MsgBox("Produto """ & _NFeS.pNt2cc.pNc_codpr & """ não tem configurações para PIS/COFINS!  Por Favor alterar no cadastro do Produto", MsgBoxStyle.Exclamation)
                Return
            End If

            While drNcm.Read
                _NFeS.pNt2cc.pNc_cstpis = drNcm(0).ToString
                _NFeS.pNt2cc.pNc_cstcofins = drNcm(1).ToString
            End While
            drNcm.Close() : commNcm.CommandText = ""

            'Select Case _NFeS.pNt2cc.pNc_cstpis
            '    Case "49"
            '        Select Case cfopRegistroItem
            '            Case "904" 'Remesssa...
            '            Case Else
            '                _NFeS.pNt2cc.pNc_cstpis = "01"
            '        End Select

            'End Select
            'Select Case _NFeS.pNt2cc.pNc_cstcofins
            '    Case "49"
            '        Select Case cfopRegistroItem
            '            Case "904" 'Remesssa...
            '            Case Else
            '                _NFeS.pNt2cc.pNc_cstcofins = "01"
            '        End Select
            'End Select


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




            _NFeS.pNt2cc.pNc_vltrib = _clXml.clNFe.LeidaTransprencia(vnc_prtotAux, geno001.pPis, geno001.pCofins, geno001.pCsll, geno001.pIRenda, _
                                                          geno001.pSn, _NFeS.pNt2cc.pNc_vlicm, _NFeS.pNt2cc.pNc_vlipi, _NFeS.pNt2cc.pNc_cfop)


            mTotalGeraLItem = Format(Round((_NFeS.pNt2cc.pNc_prtot + _NFeS.pNt2cc.pNc_frete + _NFeS.pNt2cc.pNc_segur + _
                                       _NFeS.pNt2cc.pNc_descpac + _NFeS.pNt2cc.pNc_vlsubs + _NFeS.pNt2cc.pNc_vlipi), 2), "#,###,##0.00")

            'dtg_itensNFe colunas:
            'Me.txt_alqicms.Text, Me.txt_vlicms.Text, Me.txt_basesubs.Text, Me.txt_alqsubs.Text, Me.txt_vlsubs.Text, Me.txt_alqipi.Text,  - 18
            'Me.txt_vlipi.Text, nc_cf, nc_cst, nc_isento, nc_csosn, nc_vltrib, nc_ncm, nc_desc, nc_voutro, nc_reduz, nc_alqreduz,  - 29
            'nc_cstpis, nc_cstcofins, nc_cstipi, descrNFe, descrAuto, pesoBruto, pesoLiquido, mTotalGeraLItem   - 35

            produto.pPesobruto = Round(produto.pPesobruto * CDbl(Me.txt_qtde.Text), 2)
            produto.pPesoliq = Round(produto.pPesoliq * CDbl(Me.txt_qtde.Text), 2)

            If _prodEditando Then



                'Atualiza a quantidade do Estoque do produto requerido para o Pedido...
                If CDbl(txt_qtde.Text) <> _qtdeAnteriorProd Then

                    Dim mNovaQtde As Double = 0.0
                    If CDbl(txt_qtde.Text) < _qtdeAnteriorProd Then
                        mNovaQtde = _qtdeAnteriorProd - CDbl(txt_qtde.Text)

                    ElseIf CDbl(txt_qtde.Text) > _qtdeAnteriorProd Then
                        mNovaQtde = CDbl(txt_qtde.Text) - _qtdeAnteriorProd
                    End If


                    'Subtraindo QtdFiscal Atual.....
                    qtdeFiscalAtual = _clFuncoes.trazQtdFiscEstloja01(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, MdlConexaoBD.conectionPadrao)
                    Select Case _clXml.tipoNFe
                        Case "E" 'Entrada
                            _clBD.somaQtdFiscProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, mNovaQtde, MdlConexaoBD.conectionPadrao)
                            _clBD.somaQtdeProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, mNovaQtde, MdlConexaoBD.conectionPadrao)

                        Case "S" 'Saida

                            If qtdeFiscalAtual < _NFeS.pNt2cc.pNc_qtde Then

                                If genp001.sldfiscalnegativo Then
                                    _clBD.subtraiQtdFiscProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, mNovaQtde, MdlConexaoBD.conectionPadrao)
                                    _clBD.subtraiQtdeProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, mNovaQtde, MdlConexaoBD.conectionPadrao)
                                Else

                                    lbl_mensagem.Text = "Qtde. Fiscal Atual Insuficiente! Empresa não pode ficar com Saldo Fiscal Negativo !"
                                    Me.txt_qtde.Focus() : Me.txt_qtde.SelectAll()
                                    Return
                                End If
                            Else
                                _clBD.subtraiQtdFiscProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, mNovaQtde, MdlConexaoBD.conectionPadrao)
                                _clBD.subtraiQtdeProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, mNovaQtde, MdlConexaoBD.conectionPadrao)
                            End If

                    End Select

                End If


                Dim mlinha As String() = {_NFeS.pNt2cc.pNc_codpr, _NFeS.pNt2cc.pNc_produt, produto.pUnd, Me.txt_qtde.Text, Me.txt_pruvenda.Text, _
                                  Me.txt_vlunitario.Text, Me.txt_total.Text, _NFeS.pNt2cc.pNc_cfop, Me.txt_desconto.Text, _
                                  Me.txt_frete.Text, Me.txt_seguro.Text, Me.txt_despacessoria.Text, Me.txt_basecalc.Text, Me.txt_alqicms.Text, _
                                  Me.txt_vlicms.Text, Me.txt_basesubs.Text, Me.txt_alqsubs.Text, Me.txt_vlsubs.Text, _
                                  Me.txt_alqipi.Text, Me.txt_vlipi.Text, _NFeS.pNt2cc.pNc_cf, _NFeS.pNt2cc.pNc_cst, _NFeS.pNt2cc.pNc_isento, _
                                  _NFeS.pNt2cc.pNc_csosn, _NFeS.pNt2cc.pNc_vltrib, _NFeS.pNt2cc.pNc_ncm, _NFeS.pNt2cc.pNc_desc, _NFeS.pNt2cc.pNc_voutro, _
                                  _NFeS.pNt2cc.pNc_reduz, _NFeS.pNt2cc.pNc_alqreduz, _NFeS.pNt2cc.pNc_cstpis, _NFeS.pNt2cc.pNc_cstcofins, _
                                  _NFeS.pNt2cc.pNc_cstipi, produto.pProdut2, produto.pProdut3, Format(produto.pPesobruto, "###,##0.00"), _
                                  Format(produto.pPesoliq, "###,##0.00"), mTotalGeraLItem}

                'Adicionando Linha
                Me.dtg_itensNFe.Rows(_indexProdEditando).SetValues(mlinha)
                Me.dtg_itensNFe.Refresh()

            Else


                'Subtraindo QtdFiscal Atual.....
                qtdeFiscalAtual = _clFuncoes.trazQtdFiscEstloja01(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, MdlConexaoBD.conectionPadrao)
                Select Case _clXml.tipoNFe
                    Case "E" 'Entrada
                        _clBD.somaQtdFiscProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, _NFeS.pNt2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)
                        _clBD.somaQtdeProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, _NFeS.pNt2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)

                    Case "S" 'Saida

                        If qtdeFiscalAtual < _NFeS.pNt2cc.pNc_qtde Then

                            If genp001.sldfiscalnegativo Then
                                _clBD.subtraiQtdFiscProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, _NFeS.pNt2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)
                                _clBD.subtraiQtdeProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, _NFeS.pNt2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)
                            Else

                                lbl_mensagem.Text = "Qtde. Fiscal Atual Insuficiente! Empresa não pode ficar com Saldo Fiscal Negativo !"
                                Me.txt_qtde.Focus() : Me.txt_qtde.SelectAll()
                                Return
                            End If
                        Else
                            _clBD.subtraiQtdFiscProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, _NFeS.pNt2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)
                            _clBD.subtraiQtdeProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, _NFeS.pNt2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)
                        End If

                End Select


                dtg_itensNFe.Rows.Add(_NFeS.pNt2cc.pNc_codpr, _NFeS.pNt2cc.pNc_produt, produto.pUnd, Me.txt_qtde.Text, Me.txt_pruvenda.Text, _
                                  Me.txt_vlunitario.Text, Me.txt_total.Text, _NFeS.pNt2cc.pNc_cfop, Me.txt_desconto.Text, _
                                  Me.txt_frete.Text, Me.txt_seguro.Text, Me.txt_despacessoria.Text, Me.txt_basecalc.Text, Me.txt_alqicms.Text, _
                                  Me.txt_vlicms.Text, Me.txt_basesubs.Text, Me.txt_alqsubs.Text, Me.txt_vlsubs.Text, _
                                  Me.txt_alqipi.Text, Me.txt_vlipi.Text, _NFeS.pNt2cc.pNc_cf, _NFeS.pNt2cc.pNc_cst, _NFeS.pNt2cc.pNc_isento, _
                                  _NFeS.pNt2cc.pNc_csosn, _NFeS.pNt2cc.pNc_vltrib, _NFeS.pNt2cc.pNc_ncm, _NFeS.pNt2cc.pNc_desc, _NFeS.pNt2cc.pNc_voutro, _
                                  _NFeS.pNt2cc.pNc_reduz, _NFeS.pNt2cc.pNc_alqreduz, _NFeS.pNt2cc.pNc_cstpis, _NFeS.pNt2cc.pNc_cstcofins, _
                                  _NFeS.pNt2cc.pNc_cstipi, produto.pProdut2, produto.pProdut3, Format(produto.pPesobruto, "###,##0.00"), _
                                  Format(produto.pPesoliq, "###,##0.00"), mTotalGeraLItem)

            End If


            dtg_itensNFe.Refresh()


            zeraValoresItems()
            Me.txt_codProd.Focus()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally

            If conexaoNcm.State = ConnectionState.Open Then
                conexaoNcm.Close()
            End If
        End Try


    End Sub

    Private Function somaVlrTotalItensGrid() As Double

        Dim mVlrTotaLItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrTotaLItens += row.Cells(6).Value

        Next

        mVlrTotaLItens = Round(mVlrTotaLItens, 2)
        Return mVlrTotaLItens
    End Function

    Private Function somaVlrTotalGeralItensGrid() As Double

        Dim mVlrTotalGeraLItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrTotalGeraLItens += row.Cells(37).Value

        Next

        Return mVlrTotalGeraLItens
    End Function

    Private Function somaVlrFreteItensGrid() As Double

        Dim mVlrFreteItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrFreteItens += row.Cells(9).Value

        Next

        mVlrFreteItens = Round(mVlrFreteItens, 2)
        Return mVlrFreteItens
    End Function

    Private Function somaVlrSeguroItensGrid() As Double

        Dim mVlrSeguroItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrSeguroItens += row.Cells(10).Value

        Next

        mVlrSeguroItens = Round(mVlrSeguroItens, 2)
        Return mVlrSeguroItens
    End Function

    Private Function somaVlrDesAcessItensGrid() As Double

        Dim mVlrDesAcessItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrDesAcessItens += row.Cells(10).Value

        Next

        mVlrDesAcessItens = Round(mVlrDesAcessItens, 2)
        Return mVlrDesAcessItens
    End Function

    Private Function somaVlrBaseSubsItensGrid() As Double

        Dim mVlrBaseSubsItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrBaseSubsItens += row.Cells(15).Value

        Next

        mVlrBaseSubsItens = Round(mVlrBaseSubsItens, 2)
        Return mVlrBaseSubsItens
    End Function

    Private Function somaVlrSubsItensGrid() As Double

        Dim mVlrSubsItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrSubsItens += row.Cells(16).Value

        Next

        mVlrSubsItens = Round(mVlrSubsItens, 2)
        Return mVlrSubsItens
    End Function

    Private Function somaVlrIcmsItensGrid() As Double

        Dim mVlrIcmsItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrIcmsItens += row.Cells(14).Value

        Next

        mVlrIcmsItens = Round(mVlrIcmsItens, 2)
        Return mVlrIcmsItens
    End Function

    Private Function somaVlrBaseIcmsItensGrid() As Double

        Dim mVlrBaseIcmsItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrBaseIcmsItens += row.Cells(12).Value

        Next

        mVlrBaseIcmsItens = Round(mVlrBaseIcmsItens, 2)
        Return mVlrBaseIcmsItens
    End Function

    Private Function somaVlrIpiItensGrid() As Double

        Dim mVlrIpiItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrIpiItens += row.Cells(19).Value

        Next

        mVlrIpiItens = Round(mVlrIpiItens, 2)
        Return mVlrIpiItens
    End Function

    Private Function somaVlrDescontoItensGrid() As Double

        Dim mVlrDescontoItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrDescontoItens += row.Cells(8).Value

        Next

        mVlrDescontoItens = Round(mVlrDescontoItens, 2)
        Return mVlrDescontoItens
    End Function

    Private Sub atualizaVlTotalNFe()

        Dim prtotGeral As Double
        prtotGeral = somaVlrTotalGeralItensGrid()

        Me.lbl_totalNota.Text = Format(prtotGeral, "###,##0.00")


        _totProduto = somaVlrTotalItensGrid() : txt_totProdutos.Text = Format(_totProduto, "###,##0.00")
        _totBcalculo = somaVlrBaseIcmsItensGrid() : txt_totBCalc.Text = Format(_totBcalculo, "###,##0.00")
        _totICMS = somaVlrIcmsItensGrid() : txt_totIcms.Text = Format(_totICMS, "###,##0.00")
        _totBSubs = somaVlrBaseSubsItensGrid() : txt_totBCalcSubs.Text = Format(_totBSubs, "###,##0.00")
        _totIcmsSubs = somaVlrSubsItensGrid() : txt_totIcmsSubs.Text = Format(_totIcmsSubs, "###,##0.00")
        _totIPI = somaVlrIpiItensGrid() : txt_totIPI.Text = Format(_totIPI, "###,##0.00")
        _totFrete = somaVlrFreteItensGrid() : txt_totFrete.Text = Format(_totFrete, "###,##0.00")
        _totSeguro = somaVlrSeguroItensGrid() : txt_totSeguro.Text = Format(_totSeguro, "###,##0.00")
        _totDespAcess = somaVlrDesAcessItensGrid() : txt_totDespAcess.Text = Format(_totDespAcess, "###,##0.00")
        _totDesconto = somaVlrDescontoItensGrid() : txt_totDesconto.Text = Format(_totDesconto, "###,##0.00")
        _totGeral = somaVlrTotalGeralItensGrid() : txt_totNFe.Text = Format(_totGeral, "###,##0.00")

    End Sub

    Public Sub trazAliquotasBD(ByVal codIten As String, ByRef produto As Cl_Est0001)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao abrir conexão p/ buscar Aliquota:: " & ex.Message, MsgBoxStyle.Exclamation) : Return
        End Try


        Try
            SqlProduto.Append("SELECT al.alq_interna, al.alq_externa FROM aliquotas al WHERE al.alq_tipo = " & produto.pTipo)
            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConn)
            drProduto = CmdProduto.ExecuteReader

            If drProduto.HasRows = False Then Return
            While drProduto.Read

                _clXml.alqInterna = drProduto(0)
                _clXml.alqExterna = drProduto(1)

            End While
            drProduto.Close() : drProduto = Nothing

        Catch ex As Exception
            MsgBox("Tabela de Aliquotas ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return

        End Try

        CmdProduto.CommandText = "" : SqlProduto.Remove(0, SqlProduto.ToString.Length)
        oConn.Close()
        CmdProduto = Nothing : SqlProduto = Nothing : oConn = Nothing


    End Sub

    Private Sub deletaItemGrid()

        If dtg_itensNFe.CurrentRow.IsNewRow = False Then

            If MessageBox.Show("Deseja realmente Excluir este Item ?", "Deletar Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
            Windows.Forms.DialogResult.Yes Then


                Dim mCodProd As String = Me.dtg_itensNFe.CurrentRow.Cells(0).Value.ToString
                Dim qtdeFiscalGrid As Double = Me.dtg_itensNFe.CurrentRow.Cells(3).Value
                Select Case _clXml.tipoNFe
                    Case "E" 'Entrada
                        _clBD.subtraiQtdFiscProdEstloja(mCodProd, _clXml.codLoja, qtdeFiscalGrid, MdlConexaoBD.conectionPadrao)
                        _clBD.subtraiQtdeProdEstloja(mCodProd, _clXml.codLoja, qtdeFiscalGrid, MdlConexaoBD.conectionPadrao)
                    Case "S" 'Saida

                        _clBD.somaQtdFiscProdEstloja(mCodProd, _clXml.codLoja, qtdeFiscalGrid, MdlConexaoBD.conectionPadrao)
                        _clBD.somaQtdeProdEstloja(_NFeS.pNt2cc.pNc_codpr, _clXml.codLoja, _NFeS.pNt2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)

                End Select

                dtg_itensNFe.Rows.Remove(dtg_itensNFe.CurrentRow)
                dtg_itensNFe.Refresh()

                Me.txt_codProd.Focus() : Me.txt_codProd.SelectAll()
            End If
        End If

    End Sub

    Private Function verificaRegistro() As Boolean

        lbl_mensagem.Text = ""

        If cbo_estabelecimento.SelectedIndex < 0 Then

            lbl_mensagem.Text = "Selecione uma Empresa !"
            cbo_estabelecimento.Focus() : Return False
        End If

        If cbo_tiponfe.SelectedIndex < 0 Then

            lbl_mensagem.Text = "Selecione uma Tipo de NFe !"
            cbo_tiponfe.Focus() : Return False
        End If

        If IsDate(dtp_dtSaida.Value) = False Then

            lbl_mensagem.Text = "Informe uma Data de Saída !"
            dtp_dtSaida.Focus() : Return False
        End If

        If cadp001.pCod.Equals("") Then

            lbl_mensagem.Text = "Informe um Cliente !"
            txt_nomePart.Text = "" : txt_nomePart.Focus() : Return False
        End If

        If cbo_nfeCfop.SelectedIndex < 0 Then

            lbl_mensagem.Text = "Selecione um CFOP de Registro !"
            cbo_nfeCfop.Focus() : Return False
        End If

        Return True
    End Function

    Private Function sugereCFOP_cst(ByVal cfop As String, ByVal cst As String) As String

        Dim mCfop As String = cfop

        If cst.Equals("60") Then

            Select Case Mid(cfop, 1, 1)
                Case "5"
                    mCfop = "5405"
                Case "6"
                    mCfop = "6404"
                Case "1"
                    mCfop = "1403"
                Case "2"
                    mCfop = "2403"
            End Select
        End If

        Return mCfop
    End Function

#End Region

#Region "   *** Tratamento da NF-e ***   "

    Private Function gravaNFe() As Boolean

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

            If _numNFePublic.Equals("") = False Then
                deletaValoresTabela(conexao, transacao)
            End If
            incluiRegistroNFe(conexao, transacao, Ok)

            transacao.Commit() : conexao.ClearAllPools() : conexao.Close()

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

    Private Sub incluiRegistroNFe(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, ByRef ok As Boolean)

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
            MsgBox("ERRO ao Abrir Conexão para :: " & ex.Message, MsgBoxStyle.Critical) : Return
        End Try

        Dim mSomaPesoBruto, mSomaPesoLiquido, mSomaIsentos, mSomatprod, mSomaaliss, mSomavliss, mSomavlser, mAlqInterna, mAlqExterna As Double
        Dim mSomabasec, mSomaicms, mSomabsub, mSomaicsub, mSomatpro2, mSomafrete, mSomasegu, mSomaoutros, mSomatgeral As Double
        Dim mSomadesc, mSomaipi, vnc_alqDesconto, vnc_prtotAux, vnc_vlPis, vnc_vlCofins As Double
        Dim mprtotAux, vnc_reduz As Double


        'INICIO Atribuindo valores ao _NFeS.pNt1pp...
        _NFeS.pNt1pp.pTipo_nt = "P"
        _NFeS.pNt1pp.pNt_tipo = _clXml.tipoNFe
        _NFeS.pNt1pp.pNt_nume = _numNFePublic
        If _numNFePublic.Equals("") Then
            _NFeS.pNt1pp.pNt_nume = _clFuncoes.trazVlrColunaGenp001("G00" & _clXml.codLoja, "gp_sai", conexao.ConnectionString)
            Dim gp_sai As String = CInt(_NFeS.pNt1pp.pNt_nume) + 1
            gp_sai = String.Format("{0:D9}", CInt(gp_sai))
            _clBD.altGp_SaiGenp001(gp_sai, "G00" & _clXml.codLoja, conexao, transacao)
            gp_sai = Nothing
        End If

        _NFeS.pRes01.r4_numero = _NFeS.pNt1pp.pNt_nume
        _NFeS.pRes02.r4_numero = _NFeS.pNt1pp.pNt_nume
        _NFeS.pRes03.r4_numero = _NFeS.pNt1pp.pNt_nume

        _NFeS.pNt1pp.pNt_serie = _clFuncoes.trazVlrColunaGenp001("G00" & _clXml.codLoja, "gp_serie", conexao.ConnectionString)
        _NFeS.pNt1pp.pNt_natur = Mid(Me.cbo_nfeCfop.SelectedItem, 9, 40)
        _NFeS.pNt1pp.pNt_cfop = Mid(Me.cbo_nfeCfop.SelectedItem, 1, 5)
        _NFeS.pNt1pp.pNt_geno = "G00" & _clXml.codLoja
        _NFeS.pNt1pp.pNt_codig = cadp001.pCod
        _NFeS.pNt1pp.pNt_dtemis = Date.Now
        _NFeS.pNt1pp.pNt_dtsai = dtp_dtSaida.Value
        If _NFeS.pNt1pp.pNt_dtsai < _NFeS.pNt1pp.pNt_dtemis Then _NFeS.pNt1pp.pNt_dtemis = _NFeS.pNt1pp.pNt_dtsai
        _NFeS.pNt1pp.pNt_emiss = False
        _NFeS.pNt1pp.pNt_cnpj = cadp001.pCgc
        _NFeS.pNt1pp.pNt_insc = cadp001.pInsc
        If cadp001.pCgc.Equals("") Then
            _NFeS.pNt1pp.pNt_cnpj = cadp001.pCpf
        End If
        _NFeS.pNt1pp.pNt_uf = cadp001.pUf
        _NFeS.pNt1pp.pNt_orca = ""

        TratamentoIndDest()
        TratamentoIndOper()
        TratamentoIndFinal()
        TratamentoIndPres()
        TratamentoFinNFe()

        'Incluindo _NFeS.pNt1pp...
        _clBD.incNota1pp(_NFeS.pNt1pp, geno001, conexao, transacao)
        _NFeS.pNt1pp.pNt_id = _clBD.trazIdNota1pp(conexao, _NFeS.pNt1pp.pNt_nume)
        'FIM Atribuindo valores ao _NFeS.pNt1pp...
        geno001.pPis = Round(geno001.pPis, 2)
        geno001.pCofins = Round(geno001.pCofins, 2)


        _NFeS.pNt5tt.pT_qtde = 0
        _NFeS.dtgItensResumo.Rows.Clear() : _NFeS.dtgItensResumo.Refresh()
        _NFeS.pNt2cc.zeraValores()
        'INICIO Tratamento do _NFeS.pNt2cc...
        'dtg_itensNFe colunas:
        '_NFeS.pNt2cc.pNc_codpr, _NFeS.pNt2cc.pNc_produt, produto.pUnd, Me.txt_qtde.Text, Me.txt_pruvenda.Text, Me.txt_vlunitario.Text,  - 5
        'Me.txt_total.Text, _NFeS.pNt2cc.pNc_cfop, Me.txt_desconto.Text, Me.txt_frete.Text, Me.txt_seguro.Text, Me.txt_despacessoria.Text, Me.txt_basecalc.Text,  - 12
        'Me.txt_alqicms.Text, Me.txt_vlicms.Text, Me.txt_basesubs.Text, Me.txt_alqsubs.Text, Me.txt_vlsubs.Text, Me.txt_alqipi.Text,  - 18
        'Me.txt_vlipi.Text, nc_cf, nc_cst, nc_isento, nc_csosn, nc_vltrib, nc_ncm, nc_desc, nc_voutro, nc_reduz, nc_alqreduz,  - 29
        'nc_cstpis, nc_cstcofins, nc_cstipi, descrNFe, descrAuto, pesoBruto, pesoLiquido, mprtotgeral   - 37


        'Atribuindo valores padrão ao _NFeS.pNt2cc...
        _NFeS.pNt2cc.pNc_tipo = _clXml.tipoNFe
        _NFeS.pNt2cc.pNc_numer = _NFeS.pNt1pp.pNt_nume
        _NFeS.pNt2cc.pNc_dtemis = _NFeS.pNt1pp.pNt_dtemis
        _NFeS.pNt2cc.pNc_cdport = _NFeS.pNt1pp.pNt_codig
        _NFeS.pNt2cc.pNc_ntid = _NFeS.pNt1pp.pNt_id
        _NFeS.pNt2cc.pNc_indtot = 1
        _NFeS.pNt2cc.pNc_seqitem = 0


        For Each row As DataGridViewRow In dtg_itensNFe.Rows

            If row.IsNewRow = False Then


                _NFeS.pNt2cc.pNc_codpr = row.Cells(0).Value.ToString
                _NFeS.pNt2cc.pNc_und = row.Cells(2).Value.ToString
                _NFeS.pNt2cc.pNc_qtde = row.Cells(3).Value.ToString
                _NFeS.pNt2cc.pNc_pruvenda = row.Cells(4).Value
                _NFeS.pNt2cc.pNc_prunit = row.Cells(5).Value
                _NFeS.pNt2cc.pNc_prtot = row.Cells(6).Value
                _NFeS.pNt2cc.pNc_cfop = row.Cells(7).Value
                _NFeS.pNt2cc.pNc_vldesc = row.Cells(8).Value
                _NFeS.pNt2cc.pNc_frete = row.Cells(9).Value
                _NFeS.pNt2cc.pNc_segur = row.Cells(10).Value
                _NFeS.pNt2cc.pNc_descpac = row.Cells(11).Value
                _NFeS.pNt2cc.pNc_bcalc = row.Cells(12).Value
                _NFeS.pNt2cc.pNc_alqicm = row.Cells(13).Value
                _NFeS.pNt2cc.pNc_vlicm = row.Cells(14).Value
                _NFeS.pNt2cc.pNc_basesub = row.Cells(15).Value
                _NFeS.pNt2cc.pNc_alqsub = row.Cells(16).Value
                _NFeS.pNt2cc.pNc_vlsubs = row.Cells(17).Value
                _NFeS.pNt2cc.pNc_alqipi = row.Cells(18).Value
                _NFeS.pNt2cc.pNc_vlipi = row.Cells(19).Value

                _NFeS.pNt2cc.pNc_produt = row.Cells(33).Value.ToString
                If Trim(_NFeS.pNt2cc.pNc_produt).Equals("") Then ' Se a descrição para NFe estiver em branco

                    _NFeS.pNt2cc.pNc_produt = row.Cells(34).Value.ToString 'descrição para Automóvel
                    If Trim(_NFeS.pNt2cc.pNc_produt).Equals("") Then ' Se a descrição para Automóvel estiver em branco
                        _NFeS.pNt2cc.pNc_produt = row.Cells(1).Value.ToString

                    End If
                End If
                _NFeS.pNt2cc.pNc_cf = row.Cells(20).Value.ToString
                _NFeS.pNt2cc.pNc_cst = row.Cells(21).Value.ToString
                _NFeS.pNt2cc.pNc_isento = row.Cells(22).Value
                _NFeS.pNt2cc.pNc_csosn = row.Cells(23).Value.ToString
                _NFeS.pNt2cc.pNc_vltrib = row.Cells(24).Value
                _NFeS.pNt2cc.pNc_ncm = row.Cells(25).Value.ToString
                _NFeS.pNt2cc.pNc_desc = row.Cells(26).Value
                _NFeS.pNt2cc.pNc_voutro = row.Cells(27).Value
                _NFeS.pNt2cc.pNc_reduz = Round(row.Cells(28).Value, 2)
                _NFeS.pNt2cc.pNc_alqreduz = row.Cells(29).Value
                _NFeS.pNt2cc.pNc_cstpis = row.Cells(30).Value.ToString
                _NFeS.pNt2cc.pNc_cstcofins = row.Cells(31).Value.ToString
                _NFeS.pNt2cc.pNc_cstipi = row.Cells(32).Value.ToString

                vnc_prtotAux = Round(_NFeS.pNt2cc.pNc_prtot - _NFeS.pNt2cc.pNc_reduz, 2)
                vnc_vlPis = 0.0
                vnc_vlCofins = 0.0

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



                'Soma Totais........................................................
                Dim mpesoAux As Double = row.Cells(35).Value
                _NFeS.pNt4dd.pN4_pesobruto += Round(mpesoAux, 2) ' * _NFeS.pNt2cc.pNc_qtde
                mpesoAux = row.Cells(36).Value
                _NFeS.pNt4dd.pN4_pesoliquido += Round(mpesoAux, 2) ' * _NFeS.pNt2cc.pNc_qtde
                mpesoAux = Nothing
                _NFeS.pNt4dd.pN4_tgeral += Round(_NFeS.pNt2cc.pNc_prtot + _NFeS.pNt2cc.pNc_frete + _NFeS.pNt2cc.pNc_segur + _
                                            _NFeS.pNt2cc.pNc_descpac + _NFeS.pNt2cc.pNc_vlsubs + _NFeS.pNt2cc.pNc_vlipi, 2)
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
                _NFeS.pNt4dd.pN4_outros += _NFeS.pNt2cc.pNc_descpac '_NFeS.pNt2cc.pNc_voutro
                _NFeS.pNt4dd.pN4_outras += 0.0
                _NFeS.pNt4dd.pN4_segu += _NFeS.pNt2cc.pNc_segur
                _NFeS.pNt4dd.pN4_tprod += Round(_NFeS.pNt2cc.pNc_pruvenda * _NFeS.pNt2cc.pNc_qtde, 2)
                _NFeS.pNt4dd.pN4_vlpis += Round(vnc_vlPis, 2)
                _NFeS.pNt4dd.pN4_vlcofins += Round(vnc_vlCofins, 2)
                _NFeS.pNt4dd.pN4_totaltrib += _NFeS.pNt2cc.pNc_vltrib

                _NFeS.pNt2cc.pNc_seqitem += 1
                _NFeS.pNt5tt.pT_qtde += CInt(_NFeS.pNt2cc.pNc_qtde)
                _clBD.incNota2cc(_NFeS.pNt2cc, geno001, conexao, transacao)

                'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
                'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
                _NFeS.dtgItensResumo.Rows.Add(_NFeS.pNt1pp.pNt_nume, _NFeS.pNt2cc.pNc_cfop, _NFeS.pNt2cc.pNc_cst, Round(_NFeS.pNt2cc.pNc_alqicm, 2), _
                                        Round((_NFeS.pNt2cc.pNc_prunit * _NFeS.pNt2cc.pNc_qtde), 2), Round(_NFeS.pNt2cc.pNc_vldesc, 2), _
                                        Round(_NFeS.pNt2cc.pNc_frete, 2), Round(_NFeS.pNt2cc.pNc_segur, 2), Round(_NFeS.pNt2cc.pNc_descpac, 2), _
                                        Round(_NFeS.pNt2cc.pNc_bcalc, 2), Round(_NFeS.pNt2cc.pNc_vlicm, 2), Round(_NFeS.pNt2cc.pNc_isento, 2), _
                                        Round(_NFeS.pNt2cc.pNc_voutro, 2), Round(_NFeS.pNt2cc.pNc_vlipi, 2), Round(_NFeS.pNt2cc.pNc_prtot, 2))
                _NFeS.pNt2cc.zeraValoresNFe01()

            End If
        Next



        'Tratamento do _NFeS.pNt4dd...
        _NFeS.pNt4dd.pN4_numer = _NFeS.pNt1pp.pNt_nume
        _NFeS.pNt4dd.pN4_tipo = _clXml.tipoNFe
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
        _NFeS.pNt4dd.pN4_isento = Round(_NFeS.pNt4dd.pN4_isento, 2)
        _NFeS.pNt4dd.pN4_desc = Round(_NFeS.pNt4dd.pN4_desc, 2)
        _NFeS.pNt4dd.pN4_vlpis = Round(_NFeS.pNt4dd.pN4_vlpis, 2)
        _NFeS.pNt4dd.pN4_vlcofins = Round(_NFeS.pNt4dd.pN4_vlcofins, 2)
        _NFeS.pNt4dd.pN4_totaltrib = Round(_NFeS.pNt4dd.pN4_totaltrib, 2)

        _clBD.incNota4dd(_NFeS.pNt4dd, geno001, conexao, transacao)


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
        _clBD.incNota6hh(_NFeS.pNt6hh, geno001, conexao, transacao)


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

        _clBD.incNota5tt(_NFeS.pNt5tt, geno001, conexao, transacao)


        'INCIO do armazenamento dos Resumos...
        _clFuncoes.incResumAlqSaida(False, _NFeS.dtgItensResumo, _NFeS.pRes01, geno001, _clBD, conexao, transacao)
        _clFuncoes.incResumCfopAlqSaida(False, _NFeS.dtgItensResumo, _NFeS.pRes02, geno001, _clBD, conexao, transacao)
        _clFuncoes.incResumCstCfopAlqSaida(False, _NFeS.dtgItensResumo, _NFeS.pRes03, geno001, _clBD, conexao, transacao)
        'FIM do armazenamento dos Resumos

        'INICIO do armazenamento das Notas referenciadas
        Try
            For i As Integer = 0 To _NFeS.notaref.Length - 1
                _NFeS.notaref(i).nt1pp = _NFeS.pNt1pp.pNt_nume
                _clBD.incNotaref(_NFeS.notaref(i), geno001, conexao, transacao)
            Next
        Catch ex As Exception
        End Try
        'FIM do armazenamento das Notas referenciadas

        Try
            conexaoConsultas.Close() : conexaoConsultas = Nothing
            conexaoNcm.Close() : conexaoNcm = Nothing
        Catch ex As Exception
        End Try

    End Sub

    Private Function deletaValoresTabela(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        _NFeS.pNt1pp.pNt_nume = _numNFePublic
        _NFeS.pNt2cc.pNc_numer = _numNFePublic
        _NFeS.pNt4dd.pN4_numer = _numNFePublic
        _NFeS.pNt5tt.pT_numer = _numNFePublic
        _NFeS.pNt6hh.pC_numer = _numNFePublic
        _NFeS.pRes01.r4_numero = _numNFePublic
        _NFeS.pRes02.r4_numero = _numNFePublic
        _NFeS.pRes03.r4_numero = _numNFePublic

        _clBD.delNota6hh(_NFeS.pNt6hh, geno001, conexao, transacao)
        _clBD.delNota5tt(_NFeS.pNt5tt, geno001, conexao, transacao)
        _clBD.delNota2cc(_NFeS.pNt2cc, geno001, conexao, transacao)
        _clBD.delNota4dd(_NFeS.pNt4dd, geno001, conexao, transacao)
        _clBD.delResSaidaALQ(_NFeS.pRes01, geno001, conexao, transacao)
        _clBD.delResSaidaCfopALQ(_NFeS.pRes02, geno001, conexao, transacao)
        _clBD.delResSaidaCstCfopALQ(_NFeS.pRes03, geno001, conexao, transacao)
        _clBD.delNota1pp(_NFeS.pNt1pp, geno001, conexao, transacao)
        _clBD.delNotaref(_numNFePublic, geno001, conexao, transacao)


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
        _clXml.cgc = geno001.pCgc
        _clXml.modelo = "55"
        _clXml.serie = genp001.pSerie
        _clXml.numeroNfe = _NFeS.pNt1pp.pNt_nume
        _clXml.cont = genp001.pContf


        _clXml.chaveNFe = _clFuncoes.trazVlrColunaNota1pp(_NFeS.pNt1pp.pNt_nume, geno001.pEsquemaestab, "nt_chave", MdlConexaoBD.conectionPadrao)

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


        '   * *  Inicio de Criação de XML  ***
        Try

            ' Cabeçalho Padrão do Xml
            _clXml.clNFe.Cria_xml(_clXml.sw)

            ' Chave da NFe
            _clXml.clNFe.Abre_xml_infNFe(_clXml.chaveNFe, _clXml.sw)

            ' Elementos do grupo B
            ' Identificação da Nota Fiscal eletrônica 
            ' vnt_dtemis = Date.Now
            If _clXml.tipoNFe.Equals("E") Then _clXml.tpNF = 0
            If _clXml.tipoNFe.Equals("S") Then _clXml.tpNF = 1

            _clXml.clNFe.xmlGrupo_B(geno001.pCoduf, _clXml.seqNfe, Trim(Mid(cbo_nfeCfop.SelectedItem, 8, 59)), _NFeS.pNt4dd.pN4_pgto, "55", CInt(genp001.pSerie), _NFeS.pNt1pp.pNt_nume, _
                            _NFeS.pNt1pp.pNt_dtemis, _NFeS.pNt1pp.pNt_dtsai, _clXml.tpNF, geno001.pMun, "1", genp001.pContf, _clXml.digito, genp001.pAmb, _NFeS.pNt1pp.pNt_finNFe, "0", _
                            Mid(Application.ProductVersion, 1, 20), _NFeS.pNt1pp.pNt_indOper, _NFeS.pNt1pp.pNt_indFinal, _NFeS.pNt1pp.pNt_indPres, _
                            _NFeS.pNt1pp.pNt_refModDoc, _NFeS.notaref, _clXml.sw)
            ' Encerramento do Cabeçalho do Atributo Inicial


            ' '* Inicia Tag's do Grupo C -  Emitente da NFe '**
            ' Elementos do grupo C
            _clXml.clNFe.xmlGrupo_C(geno001.pCgc, geno001.pGeno, geno001.pEnder, geno001.pBair, geno001.pMun, geno001.pCid, geno001.pUf, _
                              geno001.pCep, geno001.pFone, geno001.pInsc, geno001.pCrt, _clXml.sw)

            ' '* Inicio do Grupo E -  Destinatario da NFe '**
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
            Dim mprtotAux, mprUnitVendAux As Double

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

                Dim cmdItens As NpgsqlCommand = New NpgsqlCommand(SqlcomItens.ToString, conItens)
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

                    mprtotAux = Round((vnc_prtot + vnc_vldesc), 2) 'vnc_prtot vem com desconto; Na NF-e precisa ir sem o desconto
                    mprUnitVendAux = Round((mprtotAux / vnc_qtde), 4) 'vnc_prunit valor unitário com desconto; Na NF-e precisa ir sem o desconto

                    vnc_prtotAux = Round(mprtotAux - vnc_reduz, 2)
                    vnc_vlpis = 0.0
                    If genp001.pPis > 0 Then
                        If CInt(vnc_cstpis) < 5 Then vnc_vlpis = Round((vnc_prtotAux * genp001.pPis) / 100, 2)
                    End If

                    vnc_vlcofins = 0.0
                    If genp001.pConfin > 0 Then
                        If CInt(vnc_cstcofins) < 5 Then vnc_vlcofins = Round((vnc_prtotAux * genp001.pConfin) / 100, 2)
                    End If


                    _clXml.clNFe.xmlGrupo_L(vnc_seqitem, vnc_codpr, vnc_produt, vnc_ncm, vnc_cfop, vnc_cst, vnc_origem, vnc_csosn, _
                                      vnc_und, vnc_qtde, mprUnitVendAux, mprtotAux, vnc_vldesc, vnc_bcalc, vnc_basesub, _
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
                
                _clXml.xmlArquivo.Remove(0, _clXml.xmlArquivo.ToString.Length)
                _clXml.xmlArquivo.Append(_clFuncoes.LerArquivoSalvo(_clXml.ArqTemp))
                _clBD.altXmlNota1pp(_NFeS.pNt1pp.pNt_nume, _clXml.xmlArquivo, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                _clXml.xmlNomeArquivo = _clXml.chaveNFe & "-nfe.xml"
                _clXml.xmlPath = genp001.pathEnvioXML & "\" & _clXml.xmlNomeArquivo
                File.Copy(_clXml.ArqTemp, _clXml.xmlPath, True)
            Catch ex As Exception
                MsgBox("ERRO ao copiar o XML para """ & _clXml.xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
            End Try



            'frmManifestCargaNFe._frmREf.tentarNovamente = False
            'frmManifestCargaNFe._frmREf.errorNFeLote = False
            'If InicioValidacaoXMLs() = False Then

            '    frmManifestCargaNFe._frmREf.errorNFeLote = True
            '    If MessageBox.Show("Deseja Corrigir Novamente?", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        frmManifestCargaNFe._frmREf.tentarNovamente = True : Me.Close()
            '    End If
            'End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)

        End Try

    End Sub

    Private Function InicioValidacaoXMLs() As Boolean

        Me.lbl_mensagem.Text = "Iniciando Validação do Lote..."
        Me.Refresh()
        System.Threading.Thread.Sleep(2000)
        _clXml.strXmlRetorno = _clFuncoes.lerXmlLoteRetornoErro(_clXml.xmlNomeArquivo, genp001)


        If _clXml.strXmlRetorno.Equals("") = False Then 'Se retornou Algum ERRO:

            System.Threading.Thread.Sleep(500)

            _clBD.altNota1ppLoteErro(_NFeS.pNt1pp.pNt_nume, True, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
            _clBD.altNota1ppStrLote(_NFeS.pNt1pp.pNt_nume, _clXml.strXmlRetorno, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
            frmMsgRtbox.rtb_mensagem.Text = _clXml.strXmlRetorno
            frmMsgRtbox.ShowDialog() : Me.Refresh() : Return False
        End If

        Return True
    End Function

#End Region

    Private Sub txt_codPart_KeyDownExtracted()

        _mPesquisaForn = False
        _clXml.formBusca = True : _frmREf = Me
        buscaCliente.set_frmRef(Me)
        buscaCliente.ShowDialog(Me)
        _clXml.formBusca = False
        If Me.txt_codPart.Text.Equals("") Then
            Me.txt_codPart.Focus()
        Else
            _clFuncoes.trazCadp001(Me.txt_codPart.Text, cadp001)
            _clFuncoes.trazCadp001(Me.txt_codPart.Text, mCliente)
        End If
        Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()

    End Sub

    Private Sub trazPartKeyDown()

        If Me.txt_codPart.Text.Equals("") Then


            'Aqui tenta chamar o Formulario de Busca do Fornecedor...
            Try
                txt_codPart_KeyDownExtracted()

                'preenche CBO CFOP...
                If Not cadp001.pUf.Equals("") Then

                    Select Case _clXml.tipoNFe
                        Case "S" ' Se for uma Nota de Saída
                            Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopSaidas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                        Case "E" ' Se for uma Nota de Entrada
                            Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopEntradas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                    End Select

                End If
                Me.cbo_nfeCfop.Text = "" : Me.cbo_nfeCfop.SelectedIndex = -1

            Catch ex As Exception
            End Try

        Else  ' Consulta pelo codigo do cliente...


            If _clFuncoes.trazCadp001(Me.txt_codPart.Text, cadp001) Then

                _clFuncoes.trazCadp001(Me.txt_codPart.Text, mCliente)
                Dim lShouldReturn As Boolean
                Me.txt_nomePart.Focus()
                Me.txt_nomePart.SelectAll()
                If lShouldReturn Then Return
                lShouldReturn = Nothing
                Me.txt_codPart.Text = cadp001.pCod : Me.txt_nomePart.Text = cadp001.pPortad

                'preenche CBO CFOP...
                If Not cadp001.pUf.Equals("") Then

                    Select Case _clXml.tipoNFe
                        Case "S" ' Se for uma Nota de Saída
                            Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopSaidas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                        Case "E" ' Se for uma Nota de Entrada
                            Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopEntradas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                    End Select

                End If
                Me.cbo_nfeCfop.Text = "" : Me.cbo_nfeCfop.SelectedIndex = -1

            Else


                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    txt_codPart_KeyDownExtracted()

                    'preenche CBO CFOP...
                    If Not cadp001.pUf.Equals("") Then

                        Select Case _clXml.tipoNFe
                            Case "S" ' Se for uma Nota de Saída
                                Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopSaidas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                            Case "E" ' Se for uma Nota de Entrada
                                Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopEntradas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                        End Select

                    End If
                    Me.cbo_nfeCfop.Text = "" : Me.cbo_nfeCfop.SelectedIndex = -1

                Catch ex As Exception
                End Try

            End If
        End If


    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown


        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

            trazPartKeyDown()
        End If

        _clXml.formBusca = False


    End Sub

    Private Sub cbo_nfeCfop_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_nfeCfop.GotFocus
        If cbo_nfeCfop.DroppedDown = False Then cbo_nfeCfop.DroppedDown = True
    End Sub

    Private Sub cbo_nfeCfop_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_nfeCfop.Leave

        cboCfopLeave()

    End Sub

    Private Sub cboCfopLeave()

        lbl_mensagem.Text = ""
        If cbo_nfeCfop.SelectedIndex < 0 Then
            lbl_mensagem.Text = "Selecione um CFOP Por Favor !"
            cbo_nfeCfop.Focus()

        Else
            _clXml.digCFOP = Mid(cbo_nfeCfop.SelectedItem.ToString, 1, 1)
            _clXml._cfop = Mid(cbo_nfeCfop.SelectedItem.ToString, 1, 5).Replace(".", "")
        End If


        If cbo_nfeCfop.SelectedIndex >= 0 Then mNFe_Cfop = cbo_nfeCfop.Text.Substring(0, 5)
        Try

            If Not cadp001.pUf.Equals("") Then

                If cadp001.pUf = geno001.pUf Then
                    If Mid(mNFe_Cfop, 1, 1) <> "5" AndAlso Mid(mNFe_Cfop, 1, 1) <> "1" Then

                        MessageBox.Show("CFOP Invalido p/ Dentro do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        Me.cbo_nfeCfop.Focus() : Me.cbo_nfeCfop.SelectedIndex = -1 : Me.cbo_nfeCfop.SelectAll() : Return

                    End If
                End If


                If cadp001.pUf <> geno001.pUf Then
                    If Mid(mNFe_Cfop, 1, 1) = "5" AndAlso Mid(mNFe_Cfop, 1, 1) = "1" Then

                        MessageBox.Show("CFOP Invalido p/ Fora do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        Me.cbo_nfeCfop.Focus() : Me.cbo_nfeCfop.SelectedIndex = -1 : Me.cbo_nfeCfop.SelectAll() : Return

                    End If
                End If
            End If

            Select Case mNFe_Cfop.Substring(mNFe_Cfop.Length - 3, 3)
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

    Private Sub cboCfopLeaveAux()

        lbl_mensagem.Text = ""
        If cbo_nfeCfop.SelectedIndex < 0 Then
            lbl_mensagem.Text = "Selecione um CFOP Por Favor !"
            cbo_nfeCfop.Focus()

        Else
            _clXml.digCFOP = Mid(cbo_nfeCfop.SelectedItem.ToString, 1, 1)
            _clXml._cfop = Mid(cbo_nfeCfop.SelectedItem.ToString, 1, 5).Replace(".", "")
        End If


        If cbo_nfeCfop.SelectedIndex >= 0 Then mNFe_Cfop = cbo_nfeCfop.Text.Substring(0, 5)
        Try

            If Not cadp001.pUf.Equals("") Then

                If cadp001.pUf = geno001.pUf Then
                    If Mid(mNFe_Cfop, 1, 1) <> "5" AndAlso Mid(mNFe_Cfop, 1, 1) <> "1" Then

                        MessageBox.Show("CFOP Invalido p/ Dentro do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        Me.cbo_nfeCfop.Focus() : Me.cbo_nfeCfop.SelectedIndex = -1 : Me.cbo_nfeCfop.SelectAll() : Return

                    End If
                End If


                If cadp001.pUf <> geno001.pUf Then
                    If Mid(mNFe_Cfop, 1, 1) = "5" AndAlso Mid(mNFe_Cfop, 1, 1) = "1" Then

                        MessageBox.Show("CFOP Invalido p/ Fora do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        Me.cbo_nfeCfop.Focus() : Me.cbo_nfeCfop.SelectedIndex = -1 : Me.cbo_nfeCfop.SelectAll() : Return

                    End If
                End If
            End If

        Catch ex As Exception
        End Try


    End Sub

    Private Sub txt_codProd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codProd.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_codProd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codProd.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then


            If Me.txt_codProd.Text.Equals("") Then

                _prodEditando = False : _codProdEditando = "" : zeraValoresItems()

                'Aqui tenta chamar a Busca do Produto...
                Try
                    _frmREf = Me
                    buscaProduto.set_frmRef(Me)
                    buscaProduto.set_Geno001Ref(geno001)
                    buscaProduto.ShowDialog(Me)
                    _clXml.formBusca = False

                    If txt_nomeProd.Equals("") = False Then
                        _clFuncoes.trazProdutoBD(Me.txt_codProd.Text, produto, geno001)
                    End If

                    If MdlEmpresaUsu._codProd Then

                        Me.txt_codProd.Text = produto.pCodig
                    Else
                        Me.txt_codProd.Text = produto.pCdbarra
                    End If


                    Me.txt_nomeProd.Text = produto.pProdut
                    Me.lbl_qtdFiscal.Text = produto.pQtdfisc
                    Me.txt_pruvenda.Text = Format(produto.pPvenda, "###,##0.0000")
                    Me.txt_vlunitario.Text = Format(produto.pPvenda, "###,##0.0000")
                    If chk_pauta.Checked Then

                        If produto.pPauta > 0 Then
                            Me.txt_pruvenda.Text = Format(produto.pPauta, "###,##0.0000")
                            Me.txt_vlunitario.Text = Format(produto.pPauta, "###,##0.0000")
                        End If
                    End If
                    Me.txt_cfop.Text = _clXml._cfop

                    txt_codProd.Text = produto.pCodig
                    If Me.txt_codProd.Text.Equals("") Then

                        Me.txt_codProd.Focus()
                    Else
                        Me.txt_nomeProd.Focus()
                    End If

                    extractedCodProdKeyDown()

                Catch ex As Exception
                End Try

            Else

                If _codProdEditando.Equals(Me.txt_codProd.Text) = False Then
                    _prodEditando = False : _codProdEditando = "" : zeraValoresItems()
                End If

                txt_codProdKeyDown()

            End If
        End If

    End Sub

    Private Sub txt_codProdKeyDown()

        lbl_mensagem.Text = ""

        If _clFuncoes.trazProdutoBD(Me.txt_codProd.Text, produto, geno001) = False Then


            'Aqui tenta chamar a Busca do Produto...
            Try
                _frmREf = Me
                buscaProduto.set_frmRef(Me)
                buscaProduto.set_Geno001Ref(geno001)
                buscaProduto.ShowDialog(Me)
                _clXml.formBusca = False

                If txt_nomeProd.Equals("") = False Then
                    _clFuncoes.trazProdutoBD(Me.txt_codProd.Text, produto, geno001)
                End If

                If MdlEmpresaUsu._codProd Then

                    Me.txt_codProd.Text = produto.pCodig
                Else
                    Me.txt_codProd.Text = produto.pCdbarra
                End If


                Me.txt_nomeProd.Text = produto.pProdut
                Me.lbl_qtdFiscal.Text = produto.pQtdfisc
                Me.txt_pruvenda.Text = Format(produto.pPvenda, "###,##0.0000")
                Me.txt_vlunitario.Text = Format(produto.pPvenda, "###,##0.0000")
                If chk_pauta.Checked Then

                    If produto.pPauta > 0 Then
                        Me.txt_pruvenda.Text = Format(produto.pPauta, "###,##0.0000")
                        Me.txt_vlunitario.Text = Format(produto.pPauta, "###,##0.0000")
                    End If
                End If
                Me.txt_cfop.Text = _clXml._cfop

                txt_codProd.Text = produto.pCodig
                If Me.txt_codProd.Text.Equals("") Then

                    Me.txt_codProd.Focus()
                Else
                    Me.txt_nomeProd.Focus()
                End If

                extractedCodProdKeyDown()

            Catch ex As Exception
            End Try

        Else

            If MdlEmpresaUsu._codProd Then

                Me.txt_codProd.Text = produto.pCodig
            Else
                Me.txt_codProd.Text = produto.pCdbarra
            End If


            Me.txt_nomeProd.Text = produto.pProdut
            Me.lbl_qtdFiscal.Text = produto.pQtdfisc
            Me.txt_pruvenda.Text = Format(produto.pPvenda, "###,##0.0000")
            Me.txt_vlunitario.Text = Format(produto.pPvenda, "###,##0.0000")
            If chk_pauta.Checked Then

                If produto.pPauta > 0 Then
                    Me.txt_pruvenda.Text = Format(produto.pPauta, "###,##0.0000")
                    Me.txt_vlunitario.Text = Format(produto.pPauta, "###,##0.0000")
                End If
            End If
            Me.txt_cfop.Text = _clXml._cfop

            txt_codProd.Text = produto.pCodig
            If Me.txt_codProd.Text.Equals("") Then

                Me.txt_codProd.Focus()
            Else
                Me.txt_nomeProd.Focus()
            End If

            extractedCodProdKeyDown()

        End If


    End Sub

    Private Sub extractedCodProdKeyDown()

        trazAliquotasBD(produto.pCodig, produto)


        Select Case geno001.pCrt
            Case "1"
            Case "2" 'Simples - Retenção

                If cadp001.pUf.Equals(geno001.pUf) Then
                    txt_alqicms.Text = Format(_clXml.alqInterna, "###,##0.00")
                Else
                    txt_alqicms.Text = Format(_clXml.alqExterna, "###,##0.00")
                End If

            Case "3" 'Regime Normal

                If cadp001.pUf.Equals(geno001.pUf) Then
                    txt_alqicms.Text = Format(_clXml.alqInterna, "###,##0.00")
                Else
                    txt_alqicms.Text = Format(_clXml.alqExterna, "###,##0.00")
                End If

        End Select

        txt_alqipi.Text = Format(produto.pIpi, "###,##0.00")

        cbo_cst.SelectedIndex = _clFuncoes.trazIndexCboCST(produto.pCst, cbo_cst)
        _clXml._cst = Format(produto.pCst, "00")
        Select Case geno001.pAtivEmpresa
            Case 0 'Regime Normal:

                If cadp001.pCarac.Equals("F") Then 'Se for pessoa física:
                    If produto.pCst = 0 Then

                        produto.pCst = 10
                        cbo_cst.SelectedIndex = _clFuncoes.trazIndexCboCST(produto.pCst, cbo_cst)
                        _clXml._cst = Format(produto.pCst, "00")

                    End If
                End If


        End Select


        If _clXml.tipoNFe.Equals("S") Then
            txt_cfop.Text = _clFuncoes.tratamentoCfopItemSaidas(_clXml._cfop, _clXml._cst)
        End If
        If _clXml.tipoNFe.Equals("E") Then
            txt_cfop.Text = _clFuncoes.tratamentoCfopItemSaidas(_clXml._cfop, _clXml._cst)
        End If


        If existeItemGrid(produto.pCodig) And _prodEditando = False Then
            lbl_mensagem.Text = "Esse Produto Já foi Adicionado !" : Return
        End If

        If produto.pNcm.Length <> 8 Then
            lbl_mensagem.Text = "Produto com NCM Incorreto !" : Return
        End If

    End Sub

    Private Sub txt_cfop_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cfop.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_cfop_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cfop.Leave

        lbl_mensagem.Text = ""
        If Trim(Me.txt_cfop.Text).Equals("") Then
            lbl_mensagem.Text = "Preencha o CFOP Por Favor !"
            txt_cfop.Focus() : txt_cfop.SelectAll() : Return
        Else

            If Trim(Me.txt_cfop.Text).Length <> 4 Then
                lbl_mensagem.Text = "CFOP Inválido !"
                txt_cfop.Focus() : txt_cfop.SelectAll() : Return
            Else

                If Mid(txt_cfop.Text, 1, 1).Equals(_clXml.digCFOP) = False Then

                    lbl_mensagem.Text = "Primeiro _clXml.digito do CFOP deve começar com """ & _clXml.digCFOP & """ !"
                    txt_cfop.Focus() : txt_cfop.SelectAll() : Return
                End If

                If _clFuncoes.existCFOP_Tabela(Me.txt_cfop.Text, MdlConexaoBD.conectionPadrao) = False Then

                    lbl_mensagem.Text = "CFOP Não Existe Na Tabela Padrão de CFOPs !"

                    buscaCFOP()
                    txt_cfop.Focus() : txt_cfop.SelectAll() : Return
                End If

            End If
        End If

    End Sub

    Private Sub txt_vlicms_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_vlicms.GotFocus

        Try
            txt_vlicms.Text = Format(Round(((CDec(txt_basecalc.Text) * CDec(txt_alqicms.Text)) / 100), 2), "###,##0.00")
        Catch ex As Exception
            txt_vlicms.Text = Format(0.0, "###,##0.00")
        End Try

    End Sub

    Private Sub txt_Valores_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_vlunitario.KeyPress, txt_vlsubs.KeyPress, txt_vlipi.KeyPress, txt_vlicms.KeyPress, txt_total.KeyPress, txt_qtde.KeyPress, txt_pruvenda.KeyPress, txt_frete.KeyPress, txt_despacessoria.KeyPress, txt_desconto.KeyPress, txt_basesubs.KeyPress, txt_basecalc.KeyPress, txt_alqsubs.KeyPress, txt_alqipi.KeyPress, txt_alqicms.KeyPress, txt_seguro.KeyPress
        'permite só numeros virgula
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_qtde_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtde.Leave

        lbl_mensagem.Text = ""
        If Me.txt_qtde.Text.Equals("") Then Me.txt_qtde.Text = Format(0.0, "###,##0.000")
        If IsNumeric(Me.txt_qtde.Text) Then
            If CDec(Me.txt_qtde.Text) <= 0 Then
                lbl_mensagem.Text = "Quantidade deve ser maior que ZERO !"
                txt_qtde.Focus() : txt_qtde.SelectAll() : Return

            End If
            Me.txt_qtde.Text = Format(CDec(Me.txt_qtde.Text), "###,##0.000")
            alteraVlUnit_PcoTotal()

        Else
            lbl_mensagem.Text = "Quantidade não é Numerico !"
            txt_qtde.Focus() : txt_qtde.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_pruvenda_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pruvenda.Leave

        lbl_mensagem.Text = ""
        If Me.txt_pruvenda.Text.Equals("") Then Me.txt_pruvenda.Text = Format(0.0, "###,##0.0000")
        If IsNumeric(Me.txt_pruvenda.Text) Then
            If CDec(Me.txt_pruvenda.Text) <= 0 Then
                lbl_mensagem.Text = "Preço de Venda deve ser maior que ZERO !"
                txt_qtde.Focus() : txt_qtde.SelectAll() : Return

            End If
            Me.txt_pruvenda.Text = Format(CDec(Me.txt_pruvenda.Text), "###,##0.0000")
            alteraVlUnit_PcoTotal()

        Else
            lbl_mensagem.Text = "Preço de Venda não é Numerico !"
            txt_qtde.Focus() : txt_qtde.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_desconto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_desconto.Leave

        lbl_mensagem.Text = ""
        If Me.txt_desconto.Text.Equals("") Then Me.txt_desconto.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_desconto.Text) Then
            If CDec(Me.txt_desconto.Text) < 0 Then
                lbl_mensagem.Text = "Desconto deve ser Maior ou Igual a ZERO !"
                txt_desconto.Focus() : txt_desconto.SelectAll() : Return

            End If
            Me.txt_desconto.Text = Format(CDec(Me.txt_desconto.Text), "###,##0.00")
            alteraVlUnit_PcoTotal()

        Else
            lbl_mensagem.Text = "Desconto não é Numerico !"
            txt_desconto.Focus() : txt_desconto.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_vlunitario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_vlunitario.GotFocus

        Dim valorTotal As Double = 0.0
        Dim valorUnit As Double = 0.0
        valorTotal = Round(((CDec(Me.txt_pruvenda.Text) * CDec(Me.txt_qtde.Text)) - CDec(txt_desconto.Text)), 2)
        valorUnit = Round(valorTotal / CDec(txt_qtde.Text), 4)

        Try
            Me.txt_vlunitario.Text = Format(valorUnit, "###,##0.0000")
        Catch ex As Exception
            Me.txt_vlunitario.Text = Format(0.0, "###,##0.0000")
        End Try


    End Sub

    Private Sub txt_vlunitario_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlunitario.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlunitario.Text.Equals("") Then Me.txt_vlunitario.Text = Format(0.0, "###,##0.0000")
        If IsNumeric(Me.txt_vlunitario.Text) Then
            If CDec(Me.txt_vlunitario.Text) <= 0 Then
                lbl_mensagem.Text = "Valor Unitário deve ser maior que ZERO !"
                txt_vlunitario.Focus() : txt_vlunitario.SelectAll() : Return

            End If
            Me.txt_vlunitario.Text = Format(CDec(Me.txt_vlunitario.Text), "###,##0.0000")
        Else
            lbl_mensagem.Text = "Valor Unitário não é Numerico !"
            txt_vlunitario.Focus() : txt_vlunitario.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_total_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total.GotFocus

        Try
            Me.txt_total.Text = Format(Round(CDec(Me.txt_vlunitario.Text) * CDec(Me.txt_qtde.Text), 4), "###,##0.00")
        Catch ex As Exception
            Me.txt_total.Text = Format(0.0, "###,##0.00")
        End Try

    End Sub

    Private Sub txt_total_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total.Leave

        lbl_mensagem.Text = ""
        If Me.txt_total.Text.Equals("") Then Me.txt_total.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_total.Text) Then
            If CDec(Me.txt_total.Text) <= 0 Then
                lbl_mensagem.Text = "Total R$ deve ser maior que ZERO !"
                txt_total.Focus() : txt_total.SelectAll() : Return

            End If
            Me.txt_total.Text = Format(CDec(Me.txt_total.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Total R$ não é Numerico !"
            txt_total.Focus() : txt_total.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_frete_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_frete.Leave, txt_seguro.Leave

        lbl_mensagem.Text = ""
        If Me.txt_frete.Text.Equals("") Then Me.txt_frete.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_frete.Text) Then
            If CDec(Me.txt_frete.Text) < 0 Then
                lbl_mensagem.Text = "Frete deve ser Maior ou Igual a ZERO !"
                txt_frete.Focus() : txt_frete.SelectAll() : Return

            End If
            Me.txt_frete.Text = Format(CDec(Me.txt_frete.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Frete não é Numerico !"
            txt_frete.Focus() : txt_frete.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_seguro_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_seguro.Leave

        lbl_mensagem.Text = ""
        If Me.txt_seguro.Text.Equals("") Then Me.txt_seguro.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_seguro.Text) Then
            If CDec(Me.txt_seguro.Text) < 0 Then
                lbl_mensagem.Text = "Seguro deve ser Maior ou Igual a ZERO !"
                txt_seguro.Focus() : txt_seguro.SelectAll() : Return

            End If
            Me.txt_seguro.Text = Format(CDec(Me.txt_seguro.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Seguro não é Numerico !"
            txt_seguro.Focus() : txt_seguro.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_despacessoria_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_despacessoria.Leave

        lbl_mensagem.Text = ""
        If Me.txt_despacessoria.Text.Equals("") Then Me.txt_despacessoria.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_despacessoria.Text) Then
            If CDec(Me.txt_despacessoria.Text) < 0 Then
                lbl_mensagem.Text = "Despesa Acessória deve ser Maior ou Igual a ZERO !"
                txt_despacessoria.Focus() : txt_despacessoria.SelectAll() : Return

            End If
            Me.txt_despacessoria.Text = Format(CDec(Me.txt_despacessoria.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Despesa Acessória não é Numerico !"
            txt_despacessoria.Focus() : txt_despacessoria.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_basecalc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_basecalc.GotFocus

        Try
            If _clXml._cst.Equals("00") Then 'txt_cfop.Text.Substring(txt_cfop.Text.Length - 3, 3).Equals("102")

                Select Case geno001.pCrt
                    Case "1"
                    Case "2" 'Simples - Retenção
                        txt_basecalc.Text = Format(Round(CDec(txt_total.Text) + CDec(txt_frete.Text) + CDec(txt_seguro.Text) + CDec(txt_despacessoria.Text), 2), "###,##0.00")
                    Case "3" 'Regime Normal
                        txt_basecalc.Text = Format(Round(CDec(txt_total.Text) + CDec(txt_frete.Text) + CDec(txt_seguro.Text) + CDec(txt_despacessoria.Text), 2), "###,##0.00")
                End Select

            End If
        Catch ex As Exception
        End Try


    End Sub

    Private Sub txt_basecalc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_basecalc.Leave

        lbl_mensagem.Text = ""
        If Me.txt_basecalc.Text.Equals("") Then Me.txt_basecalc.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_basecalc.Text) Then

            If CDec(Me.txt_basecalc.Text) < 0 Then
                lbl_mensagem.Text = "Base de Calculo ICMS ser Maior ou Igual a ZERO !"
                txt_basecalc.Focus() : txt_basecalc.SelectAll() : Return

            End If
            Me.txt_basecalc.Text = Format(CDec(Me.txt_basecalc.Text), "###,##0.00")

            Try

                If CDec(Me.txt_basecalc.Text) > 0 Then
                    txt_vlicms.Text = Format(Round(((CDec(txt_basecalc.Text) * CDec(txt_alqicms.Text)) / 100), 2), "###,##0.00")
                End If
            Catch ex As Exception
                txt_vlicms.Text = Format(0.0, "###,##0.00")
            End Try

        Else
            lbl_mensagem.Text = "Base de Calculo ICMS não é Numerico !"
            txt_basecalc.Focus() : txt_basecalc.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_alqicms_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqicms.Leave

        lbl_mensagem.Text = ""
        If Me.txt_alqicms.Text.Equals("") Then Me.txt_alqicms.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_alqicms.Text) Then
            If CDec(Me.txt_alqicms.Text) < 0 Then
                lbl_mensagem.Text = "Aliquota do ICMS ser Maior ou Igual a ZERO !"
                txt_alqicms.Focus() : txt_alqicms.SelectAll() : Return

            End If
            Me.txt_alqicms.Text = Format(CDec(Me.txt_alqicms.Text), "###,##0.00")

            Try
                txt_vlicms.Text = Format(Round(((CDec(txt_basecalc.Text) * CDec(txt_alqicms.Text)) / 100), 2), "###,##0.00")
            Catch ex As Exception
                txt_vlicms.Text = Format(0.0, "###,##0.00")
            End Try

        Else
            lbl_mensagem.Text = "Aliquota do ICMS não é Numerico !"
            txt_alqicms.Focus() : txt_alqicms.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_vlicms_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlicms.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlicms.Text.Equals("") Then Me.txt_vlicms.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vlicms.Text) Then
            If CDec(Me.txt_vlicms.Text) < 0 Then
                lbl_mensagem.Text = "Valor do ICMS ser Maior ou Igual a ZERO !"
                txt_vlicms.Focus() : txt_vlicms.SelectAll() : Return

            End If
            Me.txt_vlicms.Text = Format(CDec(Me.txt_vlicms.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Valor do ICMS não é Numerico !"
            txt_vlicms.Focus() : txt_vlicms.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_basesubs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_basesubs.Leave

        lbl_mensagem.Text = ""
        If Me.txt_basesubs.Text.Equals("") Then Me.txt_basesubs.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_basesubs.Text) Then
            If CDec(Me.txt_basesubs.Text) < 0 Then
                lbl_mensagem.Text = "B. Calculo do Icms Substituto ser Maior ou Igual a ZERO !"
                txt_basesubs.Focus() : txt_basesubs.SelectAll() : Return

            End If
            Me.txt_basesubs.Text = Format(CDec(Me.txt_basesubs.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "B. Calculo do Icms Substituto não é Numerico !"
            txt_basesubs.Focus() : txt_basesubs.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_alqsubs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqsubs.Leave

        lbl_mensagem.Text = ""
        If Me.txt_alqsubs.Text.Equals("") Then Me.txt_alqsubs.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_alqsubs.Text) Then
            If CDec(Me.txt_alqsubs.Text) < 0 Then
                lbl_mensagem.Text = "Aliquota do Icms Substituto ser Maior ou Igual a ZERO !"
                txt_alqsubs.Focus() : txt_alqsubs.SelectAll() : Return

            End If
            Me.txt_alqsubs.Text = Format(CDec(Me.txt_alqsubs.Text), "###,##0.00")

            Try
                txt_vlsubs.Text = Format(Round(((CDec(txt_basesubs.Text) * CDec(txt_alqsubs.Text)) / 100), 2), "###,##0.00")
            Catch ex As Exception
                txt_vlsubs.Text = Format(0.0, "###,##0.00")
            End Try

        Else
            lbl_mensagem.Text = "Aliquota do Icms Substituto não é Numerico !"
            txt_alqsubs.Focus() : txt_alqsubs.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_vlsubs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlsubs.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlsubs.Text.Equals("") Then Me.txt_vlsubs.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vlsubs.Text) Then
            If CDec(Me.txt_vlsubs.Text) < 0 Then
                lbl_mensagem.Text = "Valor do Icms Substituto ser Maior ou Igual a ZERO !"
                txt_vlsubs.Focus() : txt_vlsubs.SelectAll() : Return

            End If
            Me.txt_vlsubs.Text = Format(CDec(Me.txt_vlsubs.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Valor do Icms Substituto não é Numerico !"
            txt_vlsubs.Focus() : txt_vlsubs.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_alqipi_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqipi.Leave

        lbl_mensagem.Text = ""
        If Me.txt_alqipi.Text.Equals("") Then Me.txt_alqipi.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_alqipi.Text) Then
            If CDec(Me.txt_alqipi.Text) < 0 Then
                lbl_mensagem.Text = "Aliquota do IPI ser Maior ou Igual a ZERO !"
                txt_alqipi.Focus() : txt_alqipi.SelectAll() : Return

            End If
            Me.txt_alqipi.Text = Format(CDec(Me.txt_alqipi.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Aliquota do IPI não é Numerico !"
            txt_alqipi.Focus() : txt_alqipi.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_vlipi_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlipi.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlipi.Text.Equals("") Then Me.txt_vlipi.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vlipi.Text) Then
            If CDec(Me.txt_vlipi.Text) < 0 Then
                lbl_mensagem.Text = "Valor do IPI ser Maior ou Igual a ZERO !"
                txt_vlipi.Focus() : txt_vlipi.SelectAll() : Return

            End If
            Me.txt_vlipi.Text = Format(CDec(Me.txt_vlipi.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Valor do IPI não é Numerico !"
            txt_vlipi.Focus() : txt_vlipi.SelectAll() : Return
        End If

    End Sub

    Private Sub btn_inclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inclui.Click

        If validaCamposItem() OrElse _mContErroCST > 1 Then
            lbl_mensagem.Text = "" : _mContErroCST = 0
            addItemGrid()
        Else
            _mContErroCST += 1
        End If

    End Sub

    Private Sub btn_exclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exclui.Click
        deletaItemGrid()
    End Sub

    Private Sub dtg_itensNFe_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dtg_itensNFe.RowsAdded

        atualizaVlTotalNFe()
        lbl_qtdeItens.Text = dtg_itensNFe.Rows.Count
    End Sub

    Private Sub dtg_itensNFe_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dtg_itensNFe.RowsRemoved
        atualizaVlTotalNFe()
        lbl_qtdeItens.Text = dtg_itensNFe.Rows.Count
    End Sub

    Private Sub dtg_itensNFe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtg_itensNFe.KeyDown
        If e.KeyCode = Keys.Delete Then deletaItemGrid()
    End Sub

    Private Sub btn_finaliza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finaliza.Click

        lbl_mensagem.Text = ""
        If verificaRegistro() Then

            If (dtg_itensNFe.Rows.Count > 0) Then


                If MessageBox.Show("Deseja Continuar ?", "Gravar NF-e", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
                    Windows.Forms.DialogResult.Yes Then

                    If gravaNFe() Then 'Aqui Tenta Persistir os Dados da NF-e

                        If MessageBox.Show("Deseja Gerar a NF-e agora ?", "Gerar NF-e", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
                        Windows.Forms.DialogResult.Yes Then

                            'Gerando a NF-e...
                            gerandoNFe()
                        End If
                    End If
                End If


            Else
                lbl_mensagem.Text = "Informe pelo menos um Produto !"
            End If
        End If


    End Sub

    Private Sub cbo_transportador_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_transportador.GotFocus
        If Not (Me.cbo_transportador.DroppedDown) Then Me.cbo_transportador.DroppedDown = True
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

    Private Sub cbo_placa_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_placa.GotFocus
        If Not (Me.cbo_placa.DroppedDown) Then Me.cbo_placa.DroppedDown = True
    End Sub

    Private Sub cbo_cst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_cst.GotFocus
        If cbo_cst.DroppedDown = False Then cbo_cst.DroppedDown = True
    End Sub

    Private Sub cbo_cst_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_cst.Leave

        Try
            _clXml._cst = Mid(cbo_cst.SelectedItem.ToString, 1, 2)
        Catch ex As Exception
            MsgBox("Erro CST:: " & ex.Message, MsgBoxStyle.Exclamation)
            cbo_cst.Focus() : Return
        End Try


        If _clXml.tipoNFe.Equals("S") Then
            txt_cfop.Text = _clFuncoes.tratamentoCfopItemSaidas(_clXml._cfop, _clXml._cst)
        End If
        If _clXml.tipoNFe.Equals("E") Then
            txt_cfop.Text = _clFuncoes.tratamentoCfopItemEntradas(_clXml._cfop, _clXml._cst)
        End If


    End Sub

    Private Sub btn_proximaAba01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proximaAba01.Click
        tbc_nfeOutras.SelectTab(1)
    End Sub

    Private Sub dtg_itensNFe_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_itensNFe.SelectionChanged

        'Edição dos Itens aqui!!!
        trazValoresItensGrid()
        _indexProdEditando = Me.dtg_itensNFe.CurrentRow.Index

    End Sub

    Private Sub trazValoresItensGrid()

        Try

            If dtg_itensNFe.CurrentRow.IsNewRow = False Then

                Me.txt_codProd.Text = Me.dtg_itensNFe.CurrentRow.Cells(0).Value.ToString
                _prodEditando = True
                _codProdEditando = Me.txt_codProd.Text
                txt_codProdKeyDown()
                cbo_cst.SelectedIndex = _clFuncoes.trazIndexComboBox(dtg_itensNFe.CurrentRow.Cells(21).Value.ToString, 2, cbo_cst)
                txt_cfop.Text = dtg_itensNFe.CurrentRow.Cells(7).Value.ToString
                txt_qtde.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(3).Value), "###,##0.00")
                txt_pruvenda.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(4).Value), "###,##0.000")
                txt_desconto.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(8).Value), "###,##0.00")
                txt_vlunitario.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(5).Value), "###,##0.000")
                txt_total.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(6).Value), "###,##0.00")
                txt_frete.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(9).Value), "###,##0.00")
                txt_seguro.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(10).Value), "###,##0.00")
                txt_despacessoria.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(11).Value), "###,##0.00")
                txt_basecalc.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(12).Value), "###,##0.00")
                txt_alqicms.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(13).Value), "###,##0.00")
                txt_vlicms.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(14).Value), "###,##0.00")
                txt_basesubs.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(15).Value), "###,##0.00")
                txt_alqsubs.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(16).Value), "###,##0.00")
                txt_vlsubs.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(17).Value), "###,##0.00")
                txt_alqipi.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(18).Value), "###,##0.00")
                txt_vlipi.Text = Format(CDbl(dtg_itensNFe.CurrentRow.Cells(19).Value), "###,##0.00")

                _qtdeAnteriorProd = CDbl(txt_qtde.Text)
            End If


        Catch ex As Exception
        End Try

    End Sub

    Private Sub txt_basesubs_GotFocus(sender As Object, e As EventArgs) Handles txt_basesubs.GotFocus
        Try
            If CDbl(txt_basesubs.Text) = 0 Then

                Select Case _clXml._cst
                    Case "10" 'Substituto
                        Me.txt_basesubs.Text = Format(CDec(Me.txt_total.Text), "###,##0.00")
                        Me.txt_alqsubs.Text = Format(genp001.pAlqsub, "###,##0.00")
                End Select
            End If
            Me.txt_basesubs.Text = Format(CDec(Me.txt_basesubs.Text), "###,##0.00")
        Catch ex As Exception
            Me.txt_basesubs.Text = Format(0, "###,##0.00")
        End Try
    End Sub

    Private Sub txt_alqsubs_GotFocus(sender As Object, e As EventArgs) Handles txt_alqsubs.GotFocus

        Try
            If CDbl(txt_alqsubs.Text) = 0 Then

                Select Case _clXml._cst
                    Case "10" 'Substituto
                        Me.txt_alqsubs.Text = Format(genp001.pAlqsub, "###,##0.00")
                End Select
            End If
            Me.txt_alqsubs.Text = Format(CDec(Me.txt_alqsubs.Text), "###,##0.00")
        Catch ex As Exception
            Me.txt_alqsubs.Text = Format(0, "###,##0.00")
        End Try

    End Sub

End Class