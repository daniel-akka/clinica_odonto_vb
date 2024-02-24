Public Class Frm_Dup_BaixaGeral

    Private Sub Frm_Dup_BaixaGeral_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Close()
    End Sub

    Private Sub Frm_Dup_BaixaGeral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Dup_BaixaGeral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cbo_loja.SelectedIndex = -1 Then
            MessageBox.Show("Selecione uma Loja !", "Baixa Geral ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_loja.Focus()
        ElseIf Not IsDate(Msk_inicio.Text) Then
            MessageBox.Show("Digite Periodo Inicial !", "Baixa Geral ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Msk_inicio.Focus()
        ElseIf Not IsDate(msk_fim.Text) Then
            MessageBox.Show("Digite Periodo Final !", "Baixa Geral ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.msk_fim.Focus()
        End If
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        If cbo_loja.SelectedIndex = -1 Then
            MessageBox.Show("Selecione uma Loja !", "Baixa Geral ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_loja.Focus()
        ElseIf Not IsDate(Msk_inicio.Text) Then
            MessageBox.Show("Digite Periodo Inicial !", "Baixa Geral ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Msk_inicio.Focus()
        ElseIf Not IsDate(msk_fim.Text) Then
            MessageBox.Show("Digite Periodo Final !", "Baixa Geral ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.msk_fim.Focus()
        End If
    End Sub
End Class