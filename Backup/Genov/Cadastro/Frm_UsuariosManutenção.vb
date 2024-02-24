Imports System
Imports System.IO

Public Class Frm_UsuariosManutenção

    Private Sub Frm_UsuariosManutenção_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub txt_nome_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_nome.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Me.txt_identificacao.Focus()
        End If
    End Sub

    Private Sub txt_identificacao_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_identificacao.KeyDown
        If (e.KeyCode = Keys.Down) Then
            Me.txt_nome.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.msk_dtnascimento.Focus()
        End If
    End Sub

    Private Sub msk_txtsenha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_txtsenha.KeyDown
        If (e.KeyCode = Keys.Down) Then
            Me.msk_dtnascimento.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.txt_nivel.Focus()
        End If
    End Sub

    Private Sub msk_dtnascimento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_dtnascimento.KeyDown
        If (e.KeyCode = Keys.Down) Then
            Me.txt_identificacao.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.msk_txtsenha.Focus()
        End If
    End Sub

    Private Sub txt_nivel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_nivel.KeyDown
        If (e.KeyCode = Keys.Down) Then
            Me.msk_txtsenha.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.chk_administrador.Focus()
        End If
    End Sub
End Class