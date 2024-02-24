Imports System.IO
Imports System.Math
Imports Npgsql
Imports System.Data
Imports System.DateTime

Public Class Frm_LancamentosCaixa
    Dim transacao As NpgsqlTransaction
    Dim agora As Date = Now
    Dim Xnumeros, XMov As New Cl_bdMetrosys
    Dim dataAtual As DateTime = DateTime.Now
    Dim mTipo As String

    Private Sub Frm_LancamentosCaixa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Frm_LancamentosCaixa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_LancamentosCaixa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.msk_data.Text = DateValue(agora)
        Me.txt_valor.Text = "0,00"
    End Sub

    Private Sub txt_valor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valor.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(Xnumeros.SoNumerov(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbo_tipo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo.Leave
        If cbo_tipo.SelectedIndex = 0 Then
            Me.txt_grupo.Text = "001"
            Me.txt_descricao.Text = "PAGO "
            mTipo = "P"
        Else
            Me.txt_grupo.Text = "500"
            Me.txt_descricao.Text = "RECEBIDO "
            mTipo = "R"
        End If
        lbl_mensagem.Text = ""
    End Sub

    Private Sub txt_grupo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_grupo.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(Xnumeros.SoNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click
        Dim mCaixa As String = "001"
        If cbo_tipo.SelectedIndex = -1 Then
            MessageBox.Show("Favor Selecione um Tipo de Lancamento !", "  Tipo Lançamento ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_tipo.Focus()
        Else
            Try
                Dim Hora As String
                Hora = Format(dataAtual, "HH:mm")

                Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                XMov.incCaixa_lancamento(0, mTipo, Me.msk_data.Text, txt_grupo.Text, txt_descricao.Text, txt_valor.Text, MdlUsuarioLogando._usuarioLogin, "N", _
                                          MdlEmpresaUsu._codigo, mCaixa, Hora, conexao, transacao)
                limpa_lancamento()
                lbl_mensagem.Text = "Registro Incluido com Sucesso ! "
                Me.msk_data.Text = DateValue(agora)
                Me.txt_valor.Text = "0,00"
                cbo_tipo.Focus()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
    End Sub
    Private Sub limpa_lancamento()
        cbo_tipo.SelectedIndex = -1
        msk_data.Text = DateValue(Now)
        txt_grupo.Text = ""
        txt_valor.Text = ""
        txt_descricao.Text = ""
    End Sub
End Class