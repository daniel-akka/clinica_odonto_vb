Public Class Frm_Dup_OutrosMovimentos

    Private Sub Frm_Dup_OutrosMovimentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Close()
    End Sub

    Private Sub Frm_Dup_OutrosMovimentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_baixaindividual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_baixaindividual.Click
        Dim BaixaInd As New Frm_Dup_BaixaIndividual
        BaixaInd.ShowDialog()
    End Sub

    Private Sub btn_devolucao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_devolucao.Click
        Dim DevEstorno As New Frm_Dup_DevolveEstornaRece
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
        Dim PosicaoPort As New Frm_Dup_PosicaoPortadorRece
        PosicaoPort.ShowDialog()
    End Sub
End Class