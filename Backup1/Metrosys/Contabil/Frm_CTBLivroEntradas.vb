Public Class Frm_CTBLivroEntradas

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Frm_CTBLivroEntradas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

   
    Private Sub btn_gerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gerar.Click

    End Sub
End Class