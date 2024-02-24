Public Class Frm_OutrosPagamentos

    Private Sub Frm_OutrosPagamentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Close()
    End Sub

    Private Sub btn_baixaindividual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_baixaindividual.Click
        Dim BaixaInd As New Frm_PagamentoIndividual
        BaixaInd.ShowDialog()
    End Sub

    Private Sub btn_devolucao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_devolucao.Click
        Dim DevEstorno As New Frm_Dup_DevolveEstornaPaga
        DevEstorno.ShowDialog()
    End Sub

    Private Sub btn_baixaboleto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_baixaboleto.Click
        Dim BxBoletos As New Frm_Dup_BaixaBoletos
        BxBoletos.ShowDialog()
    End Sub

    Private Sub btn_baixageral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_baixageral.Click
        Dim BxGeral As New Frm_Dup_BaixaGeral
        BxGeral.ShowDialog()
    End Sub

    Private Sub btn_posicao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_posicao.Click
        Dim PosicaoPort As New Frm_PosicaoPortadorPaga
        PosicaoPort.ShowDialog()
    End Sub
End Class