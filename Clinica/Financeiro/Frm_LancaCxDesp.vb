Imports System.Math
Imports Npgsql
Imports System.Text
Imports System.Data
Imports System.DateTime

Public Class Frm_LancaCxDesp

    Dim transacao As NpgsqlTransaction
    Dim agora As Date = Now
    Dim Xnumeros, XMov As New Cl_bdMetrosys
    Dim dataAtual As DateTime = DateTime.Now
    Dim mTipo As String
    Dim _indexCboLanc As Int16
    Dim _clFuncoes As New ClFuncoes
    Dim _valorDivisoria As Double = 0.0
    Public _idLancamento As Int64 = 0

    Dim _CaixaDiario As New Cl_CaixaDiario
    Dim _CaixaDiarioDAO As New Cl_CaixaDiarioDAO
    Dim _Geno As New Cl_Geno
    Dim _Cliente As New Cl_Cadp001
    Dim _Doutor As New Cl_Doutor
    Dim _DoutorDAO As New Cl_DoutorDAO
    Dim _DescricaoDAO As New Cl_DescrDespRecDAO

    Dim _BuscaForn As New Frm_ClienteFornResp
    Public Shared _frmREf As New Frm_LancaCxDesp

    Public valorDupl As Double = 0
    Public incluiu As Boolean = False
    Public idDuplicata As String = ""

    Private Sub FrmLancaCxDesp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

    Private Sub FrmLancaCxDesp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmLancaCxDesp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        ConfiguraCboTipoLanca()
        _clFuncoes.trazGenoSelecionado(MdlEmpresaUsu._codigo, _Geno)

        Me.txt_total.Text = "0,00"
        cbo_tipo.SelectedIndex = 0
        cbo_tipoPag.SelectedIndex = 0

        _valorDivisoria = _CaixaDiarioDAO.trazValorCX_DiarioDuplic(idDuplicata, _Geno)
        txt_valor.Text = Format(Round(valorDupl - _valorDivisoria, 2), "###,##0.00")


        Me.txt_grupo.Text = "001"
        mTipo = "P"
        cbo_descricao = _DescricaoDAO.PreenchComboDescricoesPorTIPO("D", cbo_descricao, MdlConexaoBD.conectionPadrao)
        _indexCboLanc = cbo_tipo.SelectedIndex

        cbo_descricao.Text = "DESP. CARTÃO [ Dupl. " & idDuplicata.ToString.PadLeft(8, "0") & " ] - ZERAR"
        CaulculaTotal()
        Me.txt_total.Focus() : Me.txt_total.SelectAll()

    End Sub

    Sub ConfiguraCboTipoLanca()

        cbo_tipo.AutoCompleteCustomSource.Clear()
        cbo_tipo.Items.Clear() : cbo_tipo.Refresh()

        cbo_tipo.AutoCompleteCustomSource.Add("Pagamento")
        cbo_tipo.Items.Add("Pagamento")
        cbo_tipo.Refresh()


    End Sub

    Private Sub txt_valor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total.KeyPress, txt_valor.KeyPress

        'permite só numeros com virgula:
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub cbo_tipo_GotFocus(sender As Object, e As EventArgs) Handles cbo_tipo.GotFocus
        If cbo_tipo.DroppedDown = False Then cbo_tipo.DroppedDown = True
    End Sub

    Private Sub txt_grupo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_grupo.KeyPress

        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Function ValidaValores() As Boolean

        Try
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

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        If ValidaValores() = False Then Return
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

                _CaixaDiario.cx_tipo = mTipo
                _CaixaDiario.cx_hora = Hora
                _CaixaDiario.cx_status = "N"
                _CaixaDiario.cx_data = msk_data.Value
                _CaixaDiario.cx_grupo = txt_grupo.Text
                _CaixaDiario.cx_descricao = cbo_descricao.Text
                _CaixaDiario.cx_valor = CDbl(txt_total.Text)
                _CaixaDiario.cx_usu = MdlUsuarioLogando._usuarioLogin
                _CaixaDiario.cx_loja = _Geno.pCodig
                _CaixaDiario.cx_caixa = MdlUsuarioLogando._codcaixa
                If _CaixaDiario.cx_caixa.Equals("") Then _CaixaDiario.cx_caixa = "001"
                _CaixaDiario.cx_tipopag = cbo_tipoPag.SelectedItem.ToString

                _CaixaDiarioDAO.IncCX_Diario(_CaixaDiario, _Geno, conexao)

                Try
                    If conexao.State = ConnectionState.Open Then conexao.Close()
                Catch ex As Exception
                End Try

                limpa_lancamento()
                MsgBox("Registro Incluido com Sucesso ! ")
                If valorDupl > 0 Then Me.incluiu = True : Me.Close()
                Me.Close()
                ZeraValores()
                cbo_tipo.Focus()
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

    Sub CaulculaTotal()

        Try
            txt_total.Text = txt_valor.Text
        Catch ex As Exception
            txt_total.Text = txt_valor.Text
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

    Private Sub cbo_descricao_GotFocus(sender As Object, e As EventArgs) Handles cbo_descricao.GotFocus

        Try
            If cbo_descricao.Text.Equals("") Then
                If (cbo_descricao.DroppedDown = False) AndAlso (cbo_descricao.Items.Count > 0) Then cbo_descricao.DroppedDown = True
            End If
        Catch ex As Exception
        End Try

    End Sub

End Class