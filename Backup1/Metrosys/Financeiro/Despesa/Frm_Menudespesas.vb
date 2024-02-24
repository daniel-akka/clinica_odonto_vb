Public Class Frm_Menudespesas

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Frm_Menudespesas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

   
    Private Sub btn_cadplano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cadplano.Click
        Dim Cadplano As New Frm_Cadastroplano
        Cadplano.ShowDialog()
    End Sub

    Private Sub btn_lancamentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lancamentos.Click
        Dim MenuLanca As New Frm_MenuLancamentos
        MenuLanca.ShowDialog()
    End Sub

    Private Sub btn_relatorios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_relatorios.Click

        Dim frm_relatDespesas As New Frm_RelatorioDesp
        frm_relatDespesas.ShowDialog()
        frm_relatDespesas.Dispose()

    End Sub

End Class