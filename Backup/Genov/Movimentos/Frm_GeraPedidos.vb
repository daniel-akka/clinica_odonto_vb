Public Class Frm_GeraPedidos

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click
        Me.Close()
    End Sub

    Private Sub Frm_GeraPedidos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
        If (e.KeyCode = Keys.F2) Then
            ' Venda no Pedido 
            Dim Formped As New Frm_Pedido
            Formped.Show()
        End If
        If (e.KeyCode = Keys.F3) Then
            ' Altera Pedido 
        End If
        If (e.KeyCode = Keys.F4) Then
            ' Exclui Pedido 
        End If
    End Sub

    Private Sub btn_novo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btn_novo.KeyDown
        Me.Close()
    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click
        Dim Formped As New Frm_Pedido
        Formped.Show()
    End Sub
End Class