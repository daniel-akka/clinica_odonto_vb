Public Class Frm_Usuarios

    Private Sub btn_usuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_usuario.Click
        Dim formUsu As New Frm_UsuariosManutenção
        formUsu.Show()
    End Sub

    Private Sub Frm_Usuarios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub btn_acesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_acesso.Click
        Dim FormLBAcesso As New Frm_UsuariosAcessos
        FormLBAcesso.Show()
    End Sub
End Class