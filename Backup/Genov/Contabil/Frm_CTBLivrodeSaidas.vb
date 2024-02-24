Public Class Frm_CTBLivrodeSaidas

    Private Sub Frm_CTBLivrodeSaidas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

End Class