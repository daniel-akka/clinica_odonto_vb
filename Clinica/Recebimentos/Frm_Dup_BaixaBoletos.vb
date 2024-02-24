Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.DateTime
Imports System.Math
Imports Npgsql
Public Class Frm_Dup_BaixaBoletos

    Dim agora As Date = Now
    Private Sub btn_processa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_processa.Click

        If cbo_banco.SelectedIndex = -1 Then
            MessageBox.Show("Selecione um banco !", "Baixa Boletos ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_banco.Focus()
        ElseIf txt_arquivo.Text = "" Then
            MessageBox.Show("Informe Local do Arquivo de Retorno !", "Baixa Boletos ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_arquivo.Focus()
        End If

    End Sub

    Private Sub Frm_Dup_BaixaBoletos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Close()
    End Sub

    Private Sub Frm_Dup_BaixaBoletos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Dup_BaixaBoletos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        msk_data.Text = agora
    End Sub
End Class