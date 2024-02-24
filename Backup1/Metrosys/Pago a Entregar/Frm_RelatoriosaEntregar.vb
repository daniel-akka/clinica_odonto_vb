Public Class Frm_RelatoriosaEntregar

    Private Sub Frm_RelatoriosaEntregar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Close()
    End Sub

    Private Sub Frm_RelatoriosaEntregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_RelatoriosaEntregar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cbo_relatorios_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_relatorios.Leave
        Dim Nivel As Integer
        Nivel = cbo_relatorios.SelectedIndex
        Select Case Nivel
            Case 0 : Me.txt_codPart.Enabled = False
                Me.txt_nomePart.Enabled = False
                Me.msk_periodo1.Enabled = False
                Me.msk_periodo2.Enabled = False

            Case 1 : Me.txt_codPart.Enabled = False
                Me.txt_nomePart.Enabled = False
                Me.txt_requisicao.Enabled = False

            Case 2 : Me.txt_codPart.Enabled = False
                Me.msk_periodo1.Enabled = True
                Me.msk_periodo2.Enabled = True
                Me.txt_requisicao.Enabled = False

            Case 3 : Me.txt_codPart.Enabled = False
                Me.txt_nomePart.Enabled = False
                Me.msk_periodo1.Enabled = False
                Me.msk_periodo2.Enabled = False
                Me.txt_requisicao.Enabled = False

            Case 4 : Me.msk_periodo1.Enabled = False
                Me.msk_periodo2.Enabled = False
                Me.txt_requisicao.Enabled = False
                Me.txt_codPart.Enabled = True
                Me.txt_nomePart.Enabled = True


        End Select
    End Sub

End Class