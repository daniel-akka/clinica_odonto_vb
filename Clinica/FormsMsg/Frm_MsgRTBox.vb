Public Class Frm_MsgRTBox

    Private Sub rtb_mensagem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rtb_mensagem.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub


End Class