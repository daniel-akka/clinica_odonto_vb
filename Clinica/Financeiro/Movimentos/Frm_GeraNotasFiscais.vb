Imports System.Drawing.Printing
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Data.DataColumnCollection
Imports System.Data.DataRow
Imports System.Xml
Imports System.Xml.Xsl
Imports Npgsql
Public Class Frm_GeraNotasFiscais
    
    Dim mMxml As New GenoNFeXml
    Private Sub Frm_GeraNotasFiscais_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub btn_nfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nfe.Click
        Dim NFeAutoriza As New Frm_NFEAutorizanota
        NFeAutoriza.Show()
        NFeAutoriza = Nothing

    End Sub

    Private Sub btn_outrasnfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_outrasnfe.Click
        Dim NFeMapas As New Frm_NFEGeraMapa
        NFeMapas.ShowDialog()
    End Sub
End Class