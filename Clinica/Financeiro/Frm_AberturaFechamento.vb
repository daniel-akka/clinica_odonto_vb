Imports System.IO
Imports System.Math
Imports Npgsql
Imports System.Text
Imports System.Data
Imports System.DateTime

Public Class Frm_AberturaFechamento

    Dim transacao As NpgsqlTransaction
    Dim agora As Date = Now
    Dim dataAtual As DateTime = DateTime.Now
    Dim dataMovimento As Date = Date.Now
    Dim Xnumeros, XMov As New Cl_bdMetrosys
    Dim mSaldoDoDia As Double
    Dim _mConsulta As String
    Dim _clFuncoes As New ClFuncoes
    Dim mTipo As String

    Private Sub Frm_AberturaFechamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Frm_AberturaFechamento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Frm_AberturaFechamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_NomeSys.Text = Application.ProductName
        Me.cbo_tipo.SelectedIndex = 0
        Me.txt_valor.Text = "0,00"

    End Sub

    Private Sub txt_valor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valor.KeyPress
        'permite só numeros com virgula:
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub limpa_lancamento()
        cbo_tipo.SelectedIndex = 0
        msk_data.Text = Date.Now
        txt_grupo.Text = ""
        txt_valor.Text = ""
        txt_descricao.Text = ""
    End Sub

    Private Function validaCxAberturaFechamento() As Boolean

        lbl_mensagem.Text = ""

        Select Case cbo_tipo.SelectedIndex
            Case 0
                If _clFuncoes.CX_AbertoNoDia(MdlUsuarioLogando._codcaixa, msk_data.Value, MdlConexaoBD.conectionPadrao) Then
                    lbl_mensagem.Text = "Caixa já foi Aberto nessa Data """ & msk_data.Text & """ !"
                    Return False
                End If
            Case 1
                If _clFuncoes.CX_FechadoNoDia(MdlUsuarioLogando._codcaixa, msk_data.Value, MdlConexaoBD.conectionPadrao) Then
                    lbl_mensagem.Text = "Caixa já foi Fechado nessa Data """ & msk_data.Text & """ !"
                    Return False
                End If

        End Select


        Return True
    End Function

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        Dim mCaixa As String = MdlUsuarioLogando._codcaixa
        If validaCxAberturaFechamento() = False Then Return

        If cbo_tipo.SelectedIndex < 0 Then
            MessageBox.Show("Favor Selecione um Tipo de Lancamento !", "  Tipo Lançamento ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_tipo.Focus()
        Else
            Try
                Dim codcxa As String
                codcxa = MdlUsuarioLogando._codcaixa
                Dim xConex As String = MdlConexaoBD.conectionPadrao
                Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                If XMov.Caixa_fechado(Me.msk_data.Value, mTipo, Mid(_local, 3, 3), mCaixa, xConex) = True Then
                    MessageBox.Show("Lancamento já efetuado !", "  Duplicidade de Lançamento ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.msk_data.Focus()
                Else
                    Dim Hora As String
                    Hora = Format(dataAtual, "HH:mm")

                    XMov.incCaixa_lancamento(0, mTipo, Me.msk_data.Value, txt_grupo.Text, txt_descricao.Text, txt_valor.Text, MdlUsuarioLogando._usuarioLogin, "N", _
                                              MdlEmpresaUsu._codigo, mCaixa, Hora, conexao, transacao)

                    MsgBox("Registro Incluido com Sucesso ! ") : Me.Close()
                End If
                cbo_tipo.Focus()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If

    End Sub

  
    Private Sub txt_valor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_valor.Leave

        lbl_mensagem.Text = ""
        If Me.txt_valor.Text.Equals("") Then Me.txt_valor.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valor.Text) Then
            If CDec(Me.txt_valor.Text) <= 0 Then
                lbl_mensagem.Text = "Valor do Lançamento DEVE ser maior que ZERO !"
                Return

            End If
            Me.txt_valor.Text = Format(CDec(Me.txt_valor.Text), "###,##0.00")

        End If

    End Sub

    Private Sub msk_data_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

        lbl_mensagem.Text = ""
        If validaCxAberturaFechamento() = False Then Return

        If IsDate(Me.msk_data.Text) = False Then
            lbl_mensagem.Text = "Informe uma Data Válida Por Favor !" : Return
        End If

        Try
            dataMovimento = Me.msk_data.Value
        Catch ex As Exception
            dataMovimento = Nothing
        End Try

        If cbo_tipo.SelectedIndex = 0 Then
            Me.txt_valor.Text = Format(_clFuncoes.trazVlrUltimoFechamentoCX(dataMovimento, MdlConexaoBD.conectionPadrao), "###,##0.00")
        Else
            Me.txt_valor.Text = Format(_clFuncoes.sldDoDia(dataMovimento), "###,##0.00")
        End If

    End Sub

    Private Sub cbo_tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tipo.SelectedIndexChanged

        lbl_mensagem.Text = ""
        Me.txt_grupo.Text = "500"
        If validaCxAberturaFechamento() = False Then Return

        Try
            dataMovimento = Me.msk_data.Value
        Catch ex As Exception
            dataMovimento = Nothing
        End Try

        If cbo_tipo.SelectedIndex = 0 Then
            Me.txt_descricao.Text = "SALDO DE ABERTURA DO DIA"
            mTipo = "A"
            Me.txt_valor.Text = Format(_clFuncoes.trazVlrUltimoFechamentoCX(dataMovimento, MdlConexaoBD.conectionPadrao), "###,##0.00")
        Else

            Me.txt_descricao.Text = "FECHAMENTO DO CAIXA DO DIA"
            mTipo = "S"
            Me.txt_valor.Text = Format(_clFuncoes.sldDoDia(dataMovimento), "###,##0.00")
        End If

        If Me.cbo_tipo.SelectedIndex < 0 Then
            lbl_mensagem.Text = "Selecione um Tipo !"
            Me.cbo_tipo.Focus()
        End If

    End Sub

End Class