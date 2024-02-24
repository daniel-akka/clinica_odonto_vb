Public Class Frm_MenuMovRelatorios

    Private Sub btn_relTpAtendimento_Click(sender As Object, e As EventArgs) Handles btn_relTpAtendimento.Click
        Dim mFrmTpAtend As New Frm_RelMovTpAtendimento
        mFrmTpAtend.Show()
    End Sub

    Private Sub Frm_MenuMovRelatorios_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub Frm_MenuMovRelatorios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_NomeSys.Text = Application.ProductName
    End Sub
End Class