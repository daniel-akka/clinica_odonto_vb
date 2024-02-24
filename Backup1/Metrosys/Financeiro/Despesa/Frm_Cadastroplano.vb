Imports System.IO
Imports System.Text
Imports System.Math
Imports Npgsql
Imports System.Data
Imports System.DateTime
Public Class Frm_Cadastroplano

    Private linhaAtual As Integer = -1
    Dim transacao As NpgsqlTransaction
    Dim agora As Date = Now
    Dim vds_id As Integer
    Dim Xnumeros, cl_BD As New Cl_bdMetrosys
    Dim conexao As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

    Private Sub Frm_Cadastroplano_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
        If (e.KeyCode = Keys.F5) Then
            Exibe_Planodecontas()
            lbl_mensagem.Text = ""
        End If
    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click
        If cbo_local.SelectedIndex = -1 Or cbo_tipo.SelectedIndex = -1 Then
            MessageBox.Show("Favor Selecione um Local ou tipo de Conta", " Local/Tipo de Conta ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbo_local.Focus()
        Else

            Try
                conexao.Open()

                ' If txt_conta.Text <> "" And txt_conta.Text <> Mid(msk_subconta.Text, 1, 3) Then
                If MessageBox.Show("Registra nova conta ?", "Nova Conta ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txt_conta.Text = Mid(msk_subconta.Text, 1, 3)
                    cl_BD.crud_PlanoConta_Despesa("I", Mid(cbo_local.SelectedItem, 1, 3), txt_conta.Text, msk_subconta.Text, Mid(cbo_tipo.SelectedItem, 1, 1), _
                                        txt_descricao.Text, 0.0, 0, txt_descricao2.Text, transacao, conexao)
                    conexao.Close()
                    Me.lbl_mensagem.Text = "Registro Incluido com Sucesso !"
                    limpa_plano()

                End If
                conexao.Close()
                Me.cbo_local.Focus()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Frm_Cadastroplano_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Cadastroplano_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Exibe_Planodecontas()
    End Sub

    Private Sub cbo_tipo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tipo.Leave
        If cbo_tipo.SelectedIndex = 0 Then
            Me.msk_subconta.Enabled = False
            Me.txt_descricao2.Enabled = False
            Me.txt_conta.Enabled = True
            Me.txt_descricao.Enabled = True
        End If
        If cbo_tipo.SelectedIndex = 1 Or cbo_tipo.SelectedIndex = 2 Then
            Me.msk_subconta.Enabled = True
            Me.txt_descricao2.Enabled = True
            Me.txt_conta.Enabled = False
            Me.txt_descricao.Enabled = False
        End If
        Me.lbl_mensagem.Text = ""
    End Sub

    Private Sub dtg_planodecontas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_planodecontas.CellContentClick
        linhaAtual = Convert.ToInt32(e.RowIndex.ToString())
        Vds_id = Me.dtg_planodecontas.CurrentRow.Cells(0).Value.ToString()
    End Sub

    Private Sub limpa_plano()
        'cbo_local.SelectedIndex = -1
        cbo_tipo.SelectedIndex = -1
        Me.msk_subconta.Text = ""
        Me.txt_descricao2.Text = ""
        Me.txt_conta.Text = ""
        Me.txt_descricao.Text = ""
    End Sub


    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click
        If linhaAtual = -1 Then
            MessageBox.Show("Selecione uma Conta ou Subconta p/ Alterar ", " Conta ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_pesquisa.Focus()
        Else
            If cbo_tipo.SelectedIndex = -1 Then
                MessageBox.Show("Selecione Tipo de Conta", "Tipo Conta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cbo_tipo.Focus()
            End If

            If cbo_tipo.SelectedIndex = 1 Or cbo_tipo.SelectedIndex = 2 Then
                If msk_subconta.Text = "" Or txt_descricao2.Text = "" Then
                    MessageBox.Show("Preencha SubConta/Descricao2", "Campos em Branco", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.msk_subconta.Focus()
                End If
            End If
            If MessageBox.Show("Confirma Alteração ?", " Alteração ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim conex As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Try
                    conex.Open()
                    cl_BD.crud_PlanoConta_Despesa("A", Mid(cbo_local.SelectedItem, 1, 3), txt_conta.Text, msk_subconta.Text, Mid(cbo_tipo.SelectedItem, 1, 1), _
                                   txt_descricao.Text, 0.0, vds_id, txt_descricao2.Text, transacao, conex)

                    conex.Close()
                    Me.lbl_mensagem.Text = "Registro Alterado com Sucesso !"
                    limpa_plano()
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                End Try
               
            End If
        End If
    End Sub

    Private Sub dtg_planodecontas_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_planodecontas.CellContentDoubleClick
        Dim vtipo As String
        linhaAtual = Convert.ToInt32(e.RowIndex.ToString())
        vds_id = Me.dtg_planodecontas.CurrentRow.Cells(0).Value.ToString()
        If MessageBox.Show("Deseja Alterar Registro ? ", " Alteração ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.cbo_local.SelectedIndex = 0
            vtipo = Me.dtg_planodecontas.CurrentRow.Cells(4).Value.ToString()
            Select Case vtipo
                Case "G"
                    cbo_tipo.SelectedIndex = 0
                Case "P"
                    cbo_tipo.SelectedIndex = 1
                Case "R"
                    cbo_tipo.SelectedIndex = 2
            End Select
            Me.txt_conta.Text = Me.dtg_planodecontas.CurrentRow.Cells(2).Value.ToString()
            Me.msk_subconta.Text = Me.dtg_planodecontas.CurrentRow.Cells(3).Value.ToString()
            Me.txt_descricao.Text = Me.dtg_planodecontas.CurrentRow.Cells(5).Value.ToString()
            Me.txt_descricao2.Text = Me.dtg_planodecontas.CurrentRow.Cells(6).Value.ToString()
        End If

    End Sub

    Private Sub Exibe_Planodecontas()
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim comm As NpgsqlCommand
        
        Sqlcomm.Append("Select ds_id AS ""ID"",ds_local AS ""Local"", ds_grupo AS ""Conta"" ,ds_subgrupo AS ""SubConta"",ds_tipo AS ""TP"",") '5
        Sqlcomm.Append("ds_descricao AS ""Descricao"", ds_descricao2 AS ""Descricao2"" From " & MdlEmpresaUsu._esqEstab & ".desp001 order by ")
        Sqlcomm.Append("ds_grupo, ds_subgrupo ASC, ds_tipo DESC")

        comm = New NpgsqlCommand(Sqlcomm.ToString, conexao)
        comm.CommandText = Sqlcomm.ToString

        Dim daPlanoC As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conexao)
        Dim dsPLanoC As DataSet = New DataSet()

        Try

            daPlanoC.Fill(dsPLanoC, MdlEmpresaUsu._esqEstab & ".desp001")
            conexao.Open()

            Me.dtg_planodecontas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.dtg_planodecontas.DataSource = dsPLanoC.Tables(MdlEmpresaUsu._esqEstab & ".desp001").DefaultView
            Me.dtg_planodecontas.AllowUserToResizeColumns = False
            Me.dtg_planodecontas.AllowUserToResizeRows = False
            Me.dtg_planodecontas.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
            'Me.dtg_planodecontas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            Me.dtg_planodecontas.Columns(0).Visible = False ' ID
            Me.dtg_planodecontas.Columns(0).Width = 20

            Me.dtg_planodecontas.Columns(1).Visible = False ' Local
            Me.dtg_planodecontas.Columns(1).Width = 20

            Me.dtg_planodecontas.Columns(2).Visible = True ' Conta
            ' Me.dtg_planodecontas.Columns(2).DefaultCellStyle.Format = "999.999.999-99"
            Me.dtg_planodecontas.Columns(2).Width = 40

            Me.dtg_planodecontas.Columns(3).Visible = True ' SubConta
            Me.dtg_planodecontas.Columns(3).Width = 57
            Me.dtg_planodecontas.Columns(3).DefaultCellStyle.Format = "999.9999"

            Me.dtg_planodecontas.Columns(4).Width = 25    ' TP

            Me.dtg_planodecontas.Columns(5).Visible = True ' Descrição
            Me.dtg_planodecontas.Columns(5).Width = 250

            Me.dtg_planodecontas.Columns(6).Visible = True ' Descrição2
            Me.dtg_planodecontas.Columns(6).Width = 210

            conexao.ClearPool()
            conexao.Close()
            ' conexao = Nothing
            'daPlanoC = Nothing : dsPLanoC = Nothing : 
            Sqlcomm = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click
        If linhaAtual = -1 Then
            MessageBox.Show("Favor Selecionar Uma linha, para Exclusão ", " Seleção ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_pesquisa.Focus()
        Else
            If MessageBox.Show("Deseja Exluir Conta ?", " Exclusão ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cl_BD.crud_ExcPlanodeContas(vds_id, conexao)
                lbl_mensagem.Text = "Registro Excluido c/ Sucesso !"
                txt_pesquisa.Focus()
            End If
        End If

    End Sub
End Class