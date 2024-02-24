Public Class Frm_UsuariosAcessos

    Private Sub btn_exclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_inclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim formUsuman As New Frm_UsuariosManutenção
        formUsuman.Show()
    End Sub

    Private Sub Frm_UsuariosAcessos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click
        Me.Close()
    End Sub

    Private Sub Frm_UsuariosAcessos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txt_pesquisa.Focus()
    End Sub
End Class