Public Class Frm_MenuPedidoCompras

    Private Sub Frm_MenuPedidoCompras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If (e.KeyCode = Keys.Escape) Then

            Me.Close()
        End If
    End Sub

    Private Sub Frm_MenuPedidoCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_inclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inclui.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class