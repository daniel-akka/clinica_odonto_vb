Public Class Frm_MenuVendedores

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click
        Dim CadVend As New Frm_Cadvendedores
        CadVend.btn_alterar.Enabled = False
        CadVend.Show()
    End Sub

    Private Sub Frm_MenuVendedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_MenuVendedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click
        Dim CadVend As New Frm_Cadvendedores
        CadVend.btn_incluir.Enabled = False
        CadVend.Show()
    End Sub
End Class