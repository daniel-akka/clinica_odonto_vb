Public Class Frm_LoginGeral

    Private _loginOK As Boolean = False
    Public _formRequest As New Object


    Public Sub set_frmRef(ByRef frmRef As Form)
        _formRequest = frmRef
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If txt_senha.Text.Equals(".Geral.7") Then _formRequest._frmRef._privilegio = True
        txt_senha.Text = "" : Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        _formRequest._frmRef._privilegio = False
        Me.Close()
    End Sub

    Private Sub Frm_LogGeral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _formRequest._frmRef._privilegio = False
    End Sub

    Private Sub Frm_LogGeral_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

End Class
