Imports System.Drawing.Printing
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Data.DataColumnCollection
Imports System.Data.DataRow
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Math
Imports Npgsql
Public Class Frm_ManCaixaDiario

    Private Sub btn_lancar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lancar.Click
        Dim LancaCX As New Frm_LancamentosCaixa
        LancaCX.btn_alterar.Enabled = False
        LancaCX.ShowDialog()
    End Sub

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click
        Me.Close()
    End Sub

    Private Sub Frm_ManCaixaDiario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Frm_ManCaixaDiario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        preecheDtg_caixa()
    End Sub
    Private Sub preecheDtg_caixa()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Sqlcomm As StringBuilder = New StringBuilder

        'verifica se usuário tem privilégio...

        Sqlcomm.Append("SELECT  cx_tipo AS ""Tipo"", cx_data AS ""Emissao "", cx_descricao AS ""Descricao"", cx_valor AS ""Valor "", cx_usu AS ""Usuario"", ") '12
        Sqlcomm.Append("cx_status AS ""Stat"" FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario where cx_loja= '" & MdlEmpresaUsu._codigo & "' order by cx_data ")
        'Sqlcomm.Append("desc limit 34")

        Dim daPed As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
        Dim dsPed As DataSet = New DataSet()

        Try
            'configurajanelaProdPesq()
            daPed.Fill(dsPed, MdlEmpresaUsu._esqEstab & ".caixadiario")
            conn.Open()

            Me.dtg_caixamov.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.dtg_caixamov.DataSource = dsPed.Tables(MdlEmpresaUsu._esqEstab & ".caixadiario").DefaultView
            Me.dtg_caixamov.AllowUserToResizeColumns = False
            Me.dtg_caixamov.AllowUserToResizeRows = False
            Me.dtg_caixamov.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
            Me.dtg_caixamov.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            'Me.dtg_caixamov.Columns(0).Visible = False
            'Me.dtg_caixamov.Columns(11).Visible = False
            'Me.dtg_caixamov.Columns(12).Visible = False
            Me.dtg_caixamov.Columns(3).DefaultCellStyle.Format = "###,##0.00"
            Me.dtg_caixamov.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            conn.ClearPool() : conn.Close()
            conn = Nothing : daPed = Nothing : dsPed = Nothing : Sqlcomm = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Private Sub btn_fechamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_fechamento.Click

        If MdlUsuarioLogando._codcaixa.Equals("") Then MsgBox("Usuário Logado não possue um CAIXA", MsgBoxStyle.Exclamation) : Return
        Dim frmAbreFecha As New Frm_AberturaFechamento
        frmAbreFecha.ShowDialog()

    End Sub
End Class