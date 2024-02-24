Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Data.DataColumnCollection
Imports System.Data.DataRow
Imports Npgsql
'
Imports System.Drawing.Printing

Public Class Frm_CFOPEntradasSaidas

    'Variável para armazenar o PATH do arquivo executável
    Private strAppPath As String
    'Variável para armazenar o número da página atual
    Private PaginaAtual As Integer = 1

    Protected Const conexao As String = _
    "Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDGENOV"


    Private Sub Frm_CFOPEntradas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_CFOPEntradas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_CFOPEntradas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim conn As New Npgsql.NpgsqlConnection(conexao)
        Dim Sqlcomm As StringBuilder = New StringBuilder

        Sqlcomm.Append("SELECT r_cdfis, r_natureza FROM cadnatu where r_cdfis < " & "'" & "5" & "'") 'order by r_cdfis
        Dim daCfop As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
        Dim dsCfop As DataSet = New DataSet()
        ' Me.dtg_CFOPEntradas.Visible = False

        Try
            ' configurajanelaProdPesq()
            daCfop.Fill(dsCfop, "cadnatu")
            conn.Open()
            ' adicionando colunas

            Me.dtg_CFOPEntradas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.dtg_CFOPEntradas.DataSource = dsCfop.Tables("cadnatu").DefaultView
            Me.dtg_CFOPEntradas.AllowUserToResizeColumns = False
            Me.dtg_CFOPEntradas.AllowUserToResizeRows = False
            Me.dtg_CFOPEntradas.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
            Me.dtg_CFOPEntradas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            ' Me.DtGdVw_manprodutos.DataSource = dt

            conn.Close()
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub btn_VisualizaRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_VisualizaRel.Click
        ' Inicio do processo
        'Dim strCnString As String
        'Dim strDatabasePath As String
        'Dim cnNorthwind As OleDb.OleDbConnection
        'Dim objPrintPreview As PrintPreviewDialog
        'Dim objOpenFileDialog As OpenFileDialog

        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        ' Fim de processo
        Dim conn As New Npgsql.NpgsqlConnection(conexao)
        Dim Sqlcomm As StringBuilder = New StringBuilder

        Sqlcomm.Append("SELECT r_cdfis, r_natureza FROM cadnatu where r_cdfis < '6.0' order by r_cdfis ")
        Dim daCfop As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
        Dim dsCfop As DataSet = New DataSet()
        Dim cmd As NpgsqlCommand = New NpgsqlCommand(Sqlcomm.ToString, conn)
        cmd.CommandText = Sqlcomm.ToString

        Dim dtCfop As DataTable = New DataTable
        Dim drCfop As NpgsqlDataReader

        Try

            conn.Open()
            dtCfop.Load(cmd.ExecuteReader())    ' Carrega o datatable para memoria
            drCfop = cmd.ExecuteReader          ' Executa leitura do commando
            While (drCfop.Read())               ' Ler Registros Selecionado no Paramentro

            End While
            conn.Close()
            drCfop.Close()

        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try


    End Sub
End Class