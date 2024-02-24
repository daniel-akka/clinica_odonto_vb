Public Class Frm_MenuCX_Diario

    Private Sub Frm_MenuCX_Diario_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub btn_manutencao_Click(sender As Object, e As EventArgs) Handles btn_manutencao.Click

        Dim frmMan As New Frm_ManCaixaDiario
        frmMan.Show()

    End Sub

    Private Sub btn_relatorios_Click(sender As Object, e As EventArgs) Handles btn_relatorios.Click

        Dim frmRelatorios As New Frm_LancadosManualR
        frmRelatorios.Show()

    End Sub

    Private Sub Frm_MenuCX_Diario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_NomeSys.Text = Application.ProductName
    End Sub

End Class