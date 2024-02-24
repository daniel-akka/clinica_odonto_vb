Public Class Frm_MenuPagamentos

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click
        Dim RegPagamento As New Frm_CadPagamento
        RegPagamento.ShowDialog()
    End Sub

    Private Sub Frm_MenuPagamentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

  
    Private Sub Frm_MenuPagamentos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

    End Sub
End Class