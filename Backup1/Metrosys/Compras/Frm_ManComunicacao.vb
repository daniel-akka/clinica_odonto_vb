Public Class Frm_ManComunicacao

   
    Private Sub btn_inclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inclui.Click
        Dim ServFone As New Frm_ServicosComunicacao
        ServFone.Show()
    End Sub

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click
        Me.Close()
    End Sub

    Private Sub Frm_ManComunicacao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_ManComunicacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_altera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_altera.Click
        Dim ServAltFone As New Frm_ServicosComunica_alt
        ServAltFone.Show()
    End Sub
End Class