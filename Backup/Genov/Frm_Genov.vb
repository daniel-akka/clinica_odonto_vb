Imports system.Windows.Forms
Imports System.IO
Imports Genov

Public Class Frm_CadGeno

    Private Sub ClientesFornTranspToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesFornTranspToolStripMenuItem.Click
        Dim fmenucad As New Frm_Cadastro
        fmenucad.Show()
    End Sub

    Private Sub Frm_Genov_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            If MessageBox.Show("Saida do Sistema", "Genov", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Frm_Genov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CadastroToolStripMenuItem.Checked = True
    End Sub

    Private Sub SairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click
        If MessageBox.Show("Saida do Sistema", "Genov", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub PedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidosToolStripMenuItem.Click
        Dim formPedido As New Frm_GeraPedidos
        formPedido.Show()
    End Sub

    Private Sub UsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuarioToolStripMenuItem.Click
        Dim forRegUsu As New Frm_Usuarios
        forRegUsu.Show()
    End Sub

    Private Sub GenovToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenovToolStripMenuItem.Click
        Dim RegGeno As New Frm_Gcadgeno1
        RegGeno.Show()
    End Sub

    Private Sub LivroDeEntradasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LivroDeEntradasToolStripMenuItem.Click
        Dim LivroEnt As New Frm_CTBLivroEntradas
        LivroEnt.Show()
    End Sub

    Private Sub LivroDeSaidasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LivroDeSaidasToolStripMenuItem.Click
        Dim LivroSai As New Frm_CTBLivrodeSaidas
        LivroSai.Show()
    End Sub
End Class
