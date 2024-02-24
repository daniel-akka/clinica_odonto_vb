Imports System.IO
Imports System.Math
Imports Npgsql
Imports System.Text
Imports System.Data
Imports System.DateTime

Public Class Frm_LancaCX_DivD

    Dim transacao As NpgsqlTransaction
    Dim agora As Date = Now
    Dim Xnumeros, XMov As New Cl_bdMetrosys
    Dim dataAtual As DateTime = DateTime.Now
    Dim mTipo As String = ""
    Dim mTipoCT As String = ""
    Dim _indexCboLanc As Int16
    Dim _clFuncoes As New ClFuncoes
    Public _idLancamento As Int64 = 0
    Dim _valorDivisoria As Double = 0

    Dim _CaixaDiario As New Cl_CaixaDiario
    Dim _CaixaDiarioDAO As New Cl_CaixaDiarioDAO
    Dim _Geno As New Cl_Geno
    Dim _Cliente As New Cl_Cadp001
    Dim _Doutor As New Cl_Doutor
    Dim _DoutorDAO As New Cl_DoutorDAO
    Dim _DescricaoDAO As New Cl_DescrDespRecDAO
    Dim _Protetico As New Cl_Doutor
    Dim _ProteticoDAO As New Cl_DoutorDAO
    Public _TpAtendimento As New Cl_TpAtendimento


    Dim _BuscaForn As New Frm_ClienteFornResp
    Public Shared _frmREf As New Frm_LancaCX_DivD
    Public incluiuDiv As Boolean = False
    Public incluiuDesp As Boolean = False
    Public valorDupl As Double = 0.0
    Public idDuplic As String = ""
    Public codCliente As String = ""
    Public nomeCliente As String = ""

    Private Sub Frm_LancaCX_DivD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Frm_LancaCX_DivD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_LancaCX_DivD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        ConfiguraCboTipoLanca()
        _clFuncoes.trazGenoSelecionado(MdlEmpresaUsu._codigo, _Geno)
        cbo_doutores = _DoutorDAO.PreenchComboDoutoresPesq(_Geno, cbo_doutores, MdlConexaoBD.conectionPadrao)
        cbo_protetico = _ProteticoDAO.PreenchComboProtetico(_Geno, cbo_protetico, MdlConexaoBD.conectionPadrao)
        cbo_tpAtendimento = _TpAtendimento.DAO.PreenchComboTpAtendimento(cbo_tpAtendimento, MdlConexaoBD.conectionPadrao)

        Me.txt_total.Text = "0,00"
        cbo_tipo.SelectedIndex = 0
        cbo_tipoPag.SelectedIndex = 0
        txt_numDuplicata.Text = idDuplic

        Try
            cbo_protetico.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Try
            cbo_tpAtendimento.SelectedIndex = 0
        Catch ex As Exception
        End Try


        If valorDupl > 0 Then
            Me.txt_valorDupl.Text = Format(valorDupl, "###,##0.00")

            'Divisória:
            mTipo = "D"
            Me.txt_grupoCT.Text = "888"
            Me.txt_codPart.Text = codCliente
            Me.txt_nomePart.Text = nomeCliente
            Me.txt_valor.Text = Format(valorDupl, "###,##0.00")
            cbo_tipoPag.SelectedIndex = 1
            CaulculaTotal()

            'Desp. Cartão:
            cbo_tipoCT.SelectedIndex = 0
            cbo_tipoPagCT.SelectedIndex = 0

            _valorDivisoria = CDbl(txt_total.Text)
            txt_valorCT.Text = Format(Round(valorDupl, 2), "###,##0.00") 'Format(Round(valorDupl - _valorDivisoria, 2), "###,##0.00")


            Me.txt_grupoCT.Text = "001"
            mTipoCT = "P"
            cbo_descricaoCT = _DescricaoDAO.PreenchComboDescricoesPorTIPO("D", cbo_descricaoCT, MdlConexaoBD.conectionPadrao)
            _indexCboLanc = cbo_tipoCT.SelectedIndex

            cbo_descricaoCT.Text = "DESP. CARTÃO [ Dupl. " & idDuplic.ToString.PadLeft(8, "0") & " ] - ZERAR "
            CaulculaTotalCT()
        Else
            TrazLancamento()
            CaulculaTotal()
        End If

        Me.txt_total.Focus() : Me.txt_total.SelectAll()
        SetaDescricao()

    End Sub

    Sub ConfiguraCboTipoLanca()

        cbo_tipo.AutoCompleteCustomSource.Clear()
        cbo_tipo.Items.Clear() : cbo_tipo.Refresh()
        cbo_tipo.AutoCompleteCustomSource.Add("Divisoria")
        cbo_tipo.Items.Add("Divisoria")
        cbo_tipo.Refresh()

    End Sub

    Sub TrazLancamento()


        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearAllPools() : conection = Nothing : Return

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT cx_tipo, cx_data, cx_grupo, cx_descricao, cx_valor, cx_doutor, cx_codcli, cx_comissdoutor FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario ")
            sql.Append("WHERE cx_id = @cx_id")
            cmd = New NpgsqlCommand(sql.ToString, conection)
            cmd.Parameters.Add("@cx_id", _idLancamento)
            dr = cmd.ExecuteReader

            While dr.Read

                cbo_tipo.SelectedIndex = 0
                msk_data.Value = dr(1)
                txt_grupo.Text = "888"
                cbo_descricao.Text = dr(3).ToString
                txt_valor.Text = Format(dr(4), "###,##0.00")
                txt_comiss.Text = Format(dr(7), "###,##0.00")

                If dr(5).ToString.Equals("") = False Then
                    _DoutorDAO.trazDoutorLojaNome(dr(5).ToString, _Geno, _Doutor)
                    cbo_doutores.SelectedIndex = _clFuncoes.trazIndexComboBox(_Doutor.Nome, _Doutor.Nome.Length, cbo_doutores)
                End If

                If dr(6).ToString.Equals("") = False Then
                    _clFuncoes.trazCadp001(dr(6).ToString, _Cliente)
                    txt_codPart.Text = _Cliente.pCod : txt_nomePart.Text = _Cliente.pPortad
                End If

            End While
            dr.Close()

        Catch ex As Exception
            MsgBox("Erro ao trazer Lançamento:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Me.Close()

        End Try

        cmd.CommandText = "" : sql.Remove(0, sql.ToString.Length) : conection.Close()
        cmd = Nothing : sql = Nothing : conection = Nothing

    End Sub

    Private Sub txt_valor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total.KeyPress, txt_comiss.KeyPress, txt_valor.KeyPress, txt_valorCT.KeyPress, txt_totalCT.KeyPress

        'permite só numeros com virgula:
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub cbo_tipo_GotFocus(sender As Object, e As EventArgs) Handles cbo_tipo.GotFocus
        If cbo_tipo.DroppedDown = False Then cbo_tipo.DroppedDown = True
    End Sub

    Private Sub cbo_tipoCT_GotFocus(sender As Object, e As EventArgs) Handles cbo_tipoCT.GotFocus
        If cbo_tipoCT.DroppedDown = False Then cbo_tipoCT.DroppedDown = True
    End Sub

    Private Sub txt_grupo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_grupo.KeyPress, txt_grupoCT.KeyPress

        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Function ValidaValores() As Boolean

        Try

            If cbo_tipo.SelectedIndex = -1 Then
                MessageBox.Show("Favor Selecione um Tipo de Lancamento !", "  Tipo Lançamento ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cbo_tipo.Focus()
            End If

            If CDbl(txt_total.Text) <= 0 Then
                lbl_mensagem.Text = "Valor Total DEVE ser Maior que ZERO !"
                Return False
            End If
        Catch ex As Exception
            lbl_mensagem.Text = "ERRO:: " & ex.Message
            Return False
        End Try

        Return True
    End Function

    Function ValidaValoresCT() As Boolean

        Try

            If cbo_tipoCT.SelectedIndex = -1 Then
                MessageBox.Show("Favor Selecione um Tipo de Lancamento !", "  Tipo Lançamento ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cbo_tipoCT.Focus()
            End If

            If CDbl(txt_totalCT.Text) <= 0 Then
                lbl_mensagem.Text = "Valor Total do Cartão DEVE ser Maior que ZERO !"
                Return False
            End If
        Catch ex As Exception
            lbl_mensagem.Text = "ERRO:: " & ex.Message
            Return False
        End Try

        Return True
    End Function

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        If (chk_divisoria.Checked = False) AndAlso (chk_despCartao.Checked = False) Then Return
        If chk_divisoria.Checked Then
            If ValidaValores() = False Then Return
        End If

        If chk_despCartao.Checked Then
            If ValidaValoresCT() = False Then Return
        End If

        _clFuncoes.trazCadp001Full(Me.txt_codPart.Text, _Cliente)

        Dim mInc As Boolean = False
        Dim mCaixa As String = MdlUsuarioLogando._codcaixa
        If mCaixa.Equals("") Then mCaixa = "001"

        If cbo_tipo.SelectedIndex = -1 Then
            MessageBox.Show("Favor Selecione um Tipo de Lancamento !", "  Tipo Lançamento ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_tipo.Focus()
        Else
            Try
                dataAtual = DateTime.Now
                Dim Hora As String
                Hora = Format(dataAtual, "HH:mm")

                Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

                _CaixaDiario.cx_hora = Hora
                _CaixaDiario.cx_status = "N"
                _CaixaDiario.cx_loja = _Geno.pCodig
                _CaixaDiario.cx_caixa = MdlUsuarioLogando._codcaixa
                If _CaixaDiario.cx_caixa.Equals("") Then _CaixaDiario.cx_caixa = "001"
                If idDuplic.Equals("") = False Then
                    _CaixaDiario.cx_idduplreceb = idDuplic
                End If
                _CaixaDiario.cx_usu = MdlUsuarioLogando._usuarioLogin


                If chk_divisoria.Checked AndAlso chk_despCartao.Checked Then

                    'Divisória:
                    _CaixaDiario.cx_tipo = mTipo
                    _CaixaDiario.cx_data = msk_data.Value
                    _CaixaDiario.cx_grupo = txt_grupo.Text
                    _CaixaDiario.cx_descricao = cbo_descricao.Text
                    _CaixaDiario.cx_valor = CDbl(txt_total.Text)
                    _CaixaDiario.cx_comissdoutor = CDbl(txt_comiss.Text)
                    _CaixaDiario.cx_iddoutor = _Doutor.Id
                    _CaixaDiario.cx_doutor = _Doutor.Nome
                    _CaixaDiario.cx_driniciais = _Doutor.Iniciais
                    _CaixaDiario.cx_protetico = _Protetico.Nome
                    If _Protetico.Nome.Equals("") = False Then
                        _CaixaDiario.cx_doutor = _Protetico.Nome : _CaixaDiario.cx_iddoutor = _Protetico.Id
                        _CaixaDiario.cx_driniciais = _Protetico.Iniciais
                        _CaixaDiario.cx_doutor_old = _Doutor.Nome
                    End If
                    _CaixaDiario.cx_codcli = _Cliente.pCod
                    _CaixaDiario.cx_nomecli = _Cliente.pPortad
                    _CaixaDiario.cx_tipopag = cbo_tipoPag.SelectedItem.ToString
                    _CaixaDiario.cx_tpatend_id = _TpAtendimento.tpa_id
                    _CaixaDiario.cx_tpatend = _TpAtendimento.tpa_atendimento

                    _CaixaDiarioDAO.IncCX_Diario(_CaixaDiario, _Geno, conexao)


                    'Desp. Cartão:
                    _CaixaDiario.cx_tipo = mTipoCT
                    _CaixaDiario.cx_data = dtp_dataCT.Value
                    _CaixaDiario.cx_grupo = txt_grupoCT.Text
                    _CaixaDiario.cx_descricao = cbo_descricaoCT.Text
                    _CaixaDiario.cx_valor = CDbl(txt_totalCT.Text)
                    _CaixaDiario.cx_comissdoutor = 0
                    _CaixaDiario.cx_iddoutor = _Doutor.Id
                    _CaixaDiario.cx_doutor = _Doutor.Nome
                    _CaixaDiario.cx_tpatend_id = _TpAtendimento.tpa_id
                    _CaixaDiario.cx_tpatend = _TpAtendimento.tpa_atendimento
                    _CaixaDiario.cx_codcli = ""
                    _CaixaDiario.cx_nomecli = ""
                    _CaixaDiario.cx_tipopag = cbo_TipoPagCT.SelectedItem.ToString
                    

                    _CaixaDiarioDAO.IncCX_Diario(_CaixaDiario, _Geno, conexao)


                    Try
                        If conexao.State = ConnectionState.Open Then conexao.Close()
                    Catch ex As Exception
                    End Try

                    limpa_lancamento()
                    MsgBox("Registros Incluidos com Sucesso ! ")
                    mInc = True
                    If Me.valorDupl > 0 Then Me.incluiuDiv = True : Me.incluiuDesp = True
                    Me.Close()

                End If


                If mInc Then Return
                If chk_divisoria.Checked Then

                    'Divisória:
                    _CaixaDiario.cx_tipo = mTipo
                    _CaixaDiario.cx_data = msk_data.Value
                    _CaixaDiario.cx_grupo = txt_grupo.Text
                    _CaixaDiario.cx_descricao = cbo_descricao.Text
                    _CaixaDiario.cx_valor = CDbl(txt_total.Text)
                    _CaixaDiario.cx_comissdoutor = CDbl(txt_comiss.Text)
                    _CaixaDiario.cx_iddoutor = _Doutor.Id
                    _CaixaDiario.cx_doutor = _Doutor.Nome
                    _CaixaDiario.cx_driniciais = _Doutor.Iniciais
                    _CaixaDiario.cx_protetico = _Protetico.Nome
                    If _Protetico.Nome.Equals("") = False Then
                        _CaixaDiario.cx_doutor = _Protetico.Nome : _CaixaDiario.cx_iddoutor = _Protetico.Id
                        _CaixaDiario.cx_driniciais = _Protetico.Iniciais
                        _CaixaDiario.cx_doutor_old = _Doutor.Nome
                    End If
                    _CaixaDiario.cx_codcli = _Cliente.pCod
                    _CaixaDiario.cx_nomecli = _Cliente.pPortad
                    _CaixaDiario.cx_tipopag = cbo_tipoPag.SelectedItem.ToString
                    _CaixaDiario.cx_tpatend_id = _TpAtendimento.tpa_id
                    _CaixaDiario.cx_tpatend = _TpAtendimento.tpa_atendimento

                    _CaixaDiarioDAO.IncCX_Diario(_CaixaDiario, _Geno, conexao)

                    Try
                        If conexao.State = ConnectionState.Open Then conexao.Close()
                    Catch ex As Exception
                    End Try

                    limpa_lancamento()
                    MsgBox("Registro Incluido com Sucesso ! ")
                    If Me.valorDupl > 0 Then Me.incluiuDiv = True
                    Me.Close()
                End If


                If chk_despCartao.Checked Then

                    'Desp. Cartão:
                    _CaixaDiario.cx_tipo = mTipoCT
                    _CaixaDiario.cx_data = dtp_dataCT.Value
                    _CaixaDiario.cx_grupo = txt_grupoCT.Text
                    _CaixaDiario.cx_descricao = cbo_descricaoCT.Text
                    _CaixaDiario.cx_valor = CDbl(txt_totalCT.Text)
                    _CaixaDiario.cx_comissdoutor = 0
                    _CaixaDiario.cx_iddoutor = _Doutor.Id
                    _CaixaDiario.cx_doutor = _Doutor.Nome
                    _CaixaDiario.cx_tpatend_id = _TpAtendimento.tpa_id
                    _CaixaDiario.cx_tpatend = _TpAtendimento.tpa_atendimento
                    _CaixaDiario.cx_codcli = ""
                    _CaixaDiario.cx_nomecli = ""
                    _CaixaDiario.cx_tipopag = cbo_TipoPagCT.SelectedItem.ToString

                    _CaixaDiarioDAO.IncCX_Diario(_CaixaDiario, _Geno, conexao)

                    Try
                        If conexao.State = ConnectionState.Open Then conexao.Close()
                    Catch ex As Exception
                    End Try

                    limpa_lancamento()
                    MsgBox("Registro Incluido com Sucesso ! ")
                    If Me.valorDupl > 0 Then Me.incluiuDesp = True
                    Me.Close()
                End If


            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If

    End Sub

    Sub ZeraValores()

        Try
            cbo_tipo.SelectedIndex = _indexCboLanc
        Catch ex As Exception
        End Try

        Me.msk_data.Value = Date.Now
        Me.txt_total.Text = "0,00"
        txt_codPart.Text = "" : txt_nomePart.Text = ""
        cbo_descricao.Text = ""
        _Cliente.zeraValores()

    End Sub

    Private Sub limpa_lancamento()
        Try
            cbo_tipo.SelectedIndex = -1
        Catch ex As Exception
        End Try
        msk_data.Text = DateValue(Now)
        txt_grupo.Text = ""
        txt_total.Text = "0,00"
        cbo_descricao.Text = ""
    End Sub

    Private Sub txt_valor_Leave(sender As Object, e As EventArgs) Handles txt_valor.Leave

        lbl_mensagem.Text = ""
        If Me.txt_valor.Text.Equals("") Then Me.txt_valor.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valor.Text) Then
            If CDec(Me.txt_valor.Text) <= 0 Then
                lbl_mensagem.Text = "Valor deve ser maior que ZERO !"
                Return

            End If
            Me.txt_valor.Text = Format(CDec(Me.txt_valor.Text), "###,##0.00")

        End If
        CaulculaTotal()

    End Sub

    Private Sub txt_valorCT_Leave(sender As Object, e As EventArgs) Handles txt_valorCT.Leave

        lbl_mensagem.Text = ""
        If Me.txt_valorCT.Text.Equals("") Then Me.txt_valorCT.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valorCT.Text) Then
            If CDec(Me.txt_valorCT.Text) <= 0 Then
                lbl_mensagem.Text = "Valor deve ser maior que ZERO !"
                Return

            End If
            Me.txt_valorCT.Text = Format(CDec(Me.txt_valorCT.Text), "###,##0.00")

        End If
        CaulculaTotalCT()

    End Sub

    Private Sub txt_comiss_Leave(sender As Object, e As EventArgs) Handles txt_comiss.Leave

        lbl_mensagem.Text = ""
        If Me.txt_comiss.Text.Equals("") Then Me.txt_comiss.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_comiss.Text) Then
            If CDec(Me.txt_comiss.Text) <= 0 Then
                lbl_mensagem.Text = "Comissão deve ser maior que ZERO !"
                Return

            End If
            Me.txt_comiss.Text = Format(CDec(Me.txt_comiss.Text), "###,##0.00")

        End If
        CaulculaTotal()

    End Sub

    Sub DesHabilitaCamposRecebimento()
        Try
            cbo_doutores.SelectedIndex = -1
        Catch ex As Exception
        End Try

        cbo_doutores.Enabled = False
        txt_comiss.Text = "0,00" : txt_comiss.ReadOnly = True
        txt_codPart.Text = "" : txt_codPart.Enabled = False
        txt_nomePart.Text = "" : txt_nomePart.Enabled = False
    End Sub

    Sub HabilitaCamposRecebimento()

        Try
            cbo_doutores.SelectedIndex = 0
        Catch ex As Exception
        End Try

        cbo_doutores.Enabled = True
        txt_comiss.Text = "0,00" : txt_comiss.ReadOnly = True
        txt_codPart.Text = "" : txt_codPart.Enabled = True
        txt_nomePart.Text = "" : txt_nomePart.Enabled = True
    End Sub

    Sub HabilitaCamposRecebimentoDivi()

        Try
            cbo_doutores.SelectedIndex = 0
        Catch ex As Exception
        End Try

        cbo_doutores.Enabled = True

        txt_comiss.Text = "0,00" : txt_comiss.ReadOnly = False
        txt_codPart.Text = "" : txt_codPart.Enabled = True
        txt_nomePart.Text = "" : txt_nomePart.Enabled = True
    End Sub

    Sub CaulculaTotal()

        Try
            If IsNumeric(txt_comiss.Text) Then

                If CDbl(txt_comiss.Text) > 0 Then
                    txt_total.Text = Format(Round((CDbl(txt_valor.Text) * CDbl(txt_comiss.Text) / 100), 2), "###,##0.00")
                Else
                    txt_total.Text = txt_valor.Text
                End If
            Else
                txt_total.Text = txt_valor.Text
            End If
        Catch ex As Exception
            txt_total.Text = txt_valor.Text
        End Try

    End Sub

    Sub CaulculaTotalCT()

        Try
            txt_totalCT.Text = txt_valorCT.Text
        Catch ex As Exception
            txt_totalCT.Text = txt_valorCT.Text
        End Try

    End Sub

    Private Sub cbo_tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tipo.SelectedIndexChanged

        lbl_mensagem.Text = ""
        Try

            Select Case cbo_tipo.SelectedIndex
                Case 0
                    Me.txt_grupo.Text = "888"
                    mTipo = "D"
                    HabilitaCamposRecebimentoDivi()
                    limpaCboDescricao()

            End Select

            _indexCboLanc = cbo_tipo.SelectedIndex
        Catch ex As Exception
        End Try


    End Sub

    Sub limpaCboDescricao()

        Try
            cbo_descricao.AutoCompleteCustomSource.Clear()
            cbo_descricao.Items.Clear()
            cbo_descricao.Refresh()
        Catch ex As Exception
        End Try


    End Sub

    Private Sub txt_codPart_KeyDownExtracted()

        _frmREf = Me
        _BuscaForn.set_frmRef(Me)
        _BuscaForn.ShowDialog(Me)
        If Me.txt_codPart.Text.Equals("") Then Me.txt_nomePart.Focus() : txt_nomePart.Text = "" : _Cliente.zeraValores() : Return

        Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()

        _clFuncoes.trazCadp001(Me.txt_codPart.Text, _Cliente)
    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then


            If Me.txt_codpart.Text.Equals("") Then


                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    txt_codPart_KeyDownExtracted()

                Catch ex As Exception
                End Try

            Else  ' Consulta pelo codigo do cliente...


                If (Me.txt_codpart.TextLength > 5) AndAlso (e.KeyCode = Keys.Enter) Then 'Se retornar nada

                    If _clFuncoes.trazCadp001(Me.txt_codPart.Text, _cliente) Then

                        txt_nomePart.Text = "" : _Cliente.zeraValores()
                        Dim lShouldReturn As Boolean
                        Me.txt_nomePart.Focus()
                        Me.txt_nomePart.SelectAll()
                        If lShouldReturn Then Return
                        lShouldReturn = Nothing

                    Else


                        'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                        Try
                            txt_codPart_KeyDownExtracted()

                        Catch ex As Exception
                        End Try

                    End If
                End If

            End If
        End If



    End Sub

    Private Sub cbo_doutores_GotFocus(sender As Object, e As EventArgs) Handles cbo_doutores.GotFocus
        If cbo_doutores.DroppedDown = False Then cbo_doutores.DroppedDown = True
    End Sub

    Sub SetaDescricao()
        Try
            cbo_descricao.Text += "CARTÃO  [ " & txt_comiss.Text & "% de " & txt_valor.Text & " ]" & "  Dupl. " & idDuplic.ToString.PadLeft(8, "0")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbo_doutores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_doutores.SelectedIndexChanged

        Try
            If cbo_doutores.SelectedIndex > 0 Then

                _DoutorDAO.trazDoutorLojaNome(cbo_doutores.SelectedItem.ToString, _Geno, _Doutor)
                txt_comiss.Text = Format(_Doutor.Comissao, "##0.00") : CaulculaTotal()
            Else
                _Doutor.zeraValores()
            End If
        Catch ex As Exception
            _Doutor.zeraValores()
        End Try

    End Sub

    Private Sub cbo_descricao_GotFocus(sender As Object, e As EventArgs) Handles cbo_descricao.GotFocus

        Try
            If cbo_descricao.Text.Equals("") Then
                If (cbo_descricao.DroppedDown = False) AndAlso (cbo_descricao.Items.Count > 0) Then cbo_descricao.DroppedDown = True
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbo_descricaoCT_GotFocus(sender As Object, e As EventArgs) Handles cbo_descricaoCT.GotFocus

        Try
            If cbo_descricaoCT.Text.Equals("") Then
                If (cbo_descricaoCT.DroppedDown = False) AndAlso (cbo_descricaoCT.Items.Count > 0) Then cbo_descricaoCT.DroppedDown = True
            End If
        Catch ex As Exception
        End Try

    End Sub
   
    Private Sub chk_divisoria_CheckedChanged(sender As Object, e As EventArgs) Handles chk_divisoria.CheckedChanged

        If chk_divisoria.Checked Then
            grb_lancamentos.Enabled = True
        Else
            grb_lancamentos.Enabled = False
        End If

    End Sub

    Private Sub chk_despCartao_CheckedChanged(sender As Object, e As EventArgs) Handles chk_despCartao.CheckedChanged

        If chk_despCartao.Checked Then
            grb_lancaDespCartao.Enabled = True
        Else
            grb_lancaDespCartao.Enabled = False
        End If

    End Sub

    Private Sub cbo_protetico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_protetico.SelectedIndexChanged

        Try
            If cbo_protetico.SelectedIndex > 0 Then
                _ProteticoDAO.trazDoutorLojaNome(cbo_protetico.SelectedItem.ToString, _Geno, _Protetico)
                lbl_comiss.SetBounds(384, 202, 61, 17)
                txt_comiss.SetBounds(451, 199, 55, 23)
                txt_comiss.Text = Format(_Protetico.Comissao, "##0.00") : CaulculaTotal()
            Else
                lbl_comiss.SetBounds(384, 172, 61, 17)
                txt_comiss.SetBounds(451, 169, 55, 23)
                _Protetico.zeraValores()
            End If
        Catch ex As Exception
            lbl_comiss.SetBounds(384, 172, 61, 17)
            txt_comiss.SetBounds(451, 169, 55, 23)
            _Protetico.zeraValores()
        End Try

    End Sub

    Private Sub cbo_protetico_GotFocus(sender As Object, e As EventArgs) Handles cbo_protetico.GotFocus
        If cbo_protetico.DroppedDown = False Then cbo_protetico.DroppedDown = True
    End Sub

    Private Sub cbo_tpAtendimento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tpAtendimento.SelectedIndexChanged

        Try
            If cbo_tpAtendimento.SelectedIndex > -1 Then
                _TpAtendimento.DAO.trazTpAtendimentoDescr(cbo_tpAtendimento.SelectedItem.ToString, _TpAtendimento)
            Else
                _TpAtendimento.ZeraValores()
            End If
        Catch ex As Exception
        End Try

    End Sub

End Class