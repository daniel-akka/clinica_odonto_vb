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

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                executaF5()
            Case Keys.F3

                Try
                    SetaValoresGrid(dtg_planodecontas.CurrentRow.Index)
                Catch ex As Exception
                End Try

        End Select

    End Sub

    Sub executaF5()
        Exibe_Planodecontas()
        lbl_mensagem.Text = ""
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

                    If cbo_tipo.SelectedIndex = 0 Then

                        cl_BD.crud_PlanoConta_Despesa("I", "0" & Mid(cbo_local.SelectedItem, 1, 2), txt_conta.Text, msk_subconta.Text, Mid(cbo_tipo.SelectedItem, 1, 1), _
                                            txt_descricao.Text, 0.0, 0, txt_descricao2.Text, transacao, conexao)

                    Else

                        txt_conta.Text = Mid(msk_subconta.Text, 1, 3)
                        cl_BD.crud_PlanoConta_Despesa("I", "0" & Mid(cbo_local.SelectedItem, 1, 2), txt_conta.Text, msk_subconta.Text, Mid(cbo_tipo.SelectedItem, 1, 1), _
                                            txt_descricao.Text, 0.0, 0, txt_descricao2.Text, transacao, conexao)

                    End If
                    
                    conexao.Close()
                    Me.lbl_mensagem.Text = "Registro Incluido com Sucesso !"
                    limpa_plano()
                    executaF5()

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
        lbl_NomeSys.Text = Application.ProductName
        cbo_local = _clFunc.PreenchComboLoja2Dig(cbo_local, MdlConexaoBD.conectionPadrao)
        cbo_local.SelectedIndex = 0
        limpa_plano()
        Exibe_Planodecontas()
    End Sub

    Private Sub limpa_plano()
        'cbo_local.SelectedIndex = -1
        cbo_tipo.SelectedIndex = -1
        Me.msk_subconta.Text = ""
        Me.txt_descricao2.Text = ""
        Me.txt_conta.Text = ""
        Me.txt_descricao.Text = ""
        Me.txt_conta.Enabled = False : Me.txt_descricao.Enabled = False
        Me.msk_subconta.Enabled = False : Me.txt_descricao2.Enabled = False
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

                    If Mid(cbo_tipo.SelectedItem, 1, 1).Equals("G") Then
                        cl_BD.crud_PlanoConta_Despesa("A", "0" & Mid(cbo_local.SelectedItem, 1, 2), txt_conta.Text, "", Mid(cbo_tipo.SelectedItem, 1, 1), _
                                   txt_descricao.Text, 0.0, vds_id, "", transacao, conex)
                    Else
                        cl_BD.crud_PlanoConta_Despesa("A", "0" & Mid(cbo_local.SelectedItem, 1, 2), Mid(msk_subconta.Text, 1, 3), msk_subconta.Text, Mid(cbo_tipo.SelectedItem, 1, 1), _
                                   txt_descricao.Text, 0.0, vds_id, txt_descricao2.Text, transacao, conex)
                    End If
                    

                    conex.Close()
                    Me.lbl_mensagem.Text = "Registro Alterado com Sucesso !"
                    limpa_plano()
                    executaF5()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                End Try

            End If
        End If
    End Sub

    Sub SetaValoresGrid(ByVal index As Integer)

        Dim vtipo As String
        Dim mLocal As String = Mid(dtg_planodecontas.CurrentRow.Cells(1).Value.ToString, 2)

        linhaAtual = Convert.ToInt32(index)
        vds_id = Me.dtg_planodecontas.CurrentRow.Cells(0).Value.ToString()
        If MessageBox.Show("Deseja Alterar Registro ? ", " Alteração ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.cbo_local.SelectedIndex = _clFunc.trazIndexComboBox(mLocal, mLocal.Length, cbo_local)
            vtipo = Me.dtg_planodecontas.CurrentRow.Cells(4).Value.ToString()
            Select Case vtipo
                Case "G"
                    cbo_tipo.SelectedIndex = 0
                    Me.txt_conta.Text = Me.dtg_planodecontas.CurrentRow.Cells(2).Value.ToString()
                    Me.txt_descricao.Text = Me.dtg_planodecontas.CurrentRow.Cells(5).Value.ToString()
                    Return
                Case "P"
                    cbo_tipo.SelectedIndex = 1
                Case "R"
                    cbo_tipo.SelectedIndex = 2
            End Select

            Me.msk_subconta.Text = Me.dtg_planodecontas.CurrentRow.Cells(3).Value.ToString()
            Me.txt_descricao2.Text = Me.dtg_planodecontas.CurrentRow.Cells(6).Value.ToString()
        End If

    End Sub

    Private Sub Exibe_Planodecontas()
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim comm As NpgsqlCommand
        Dim local As String = "0" & Mid(cbo_local.SelectedItem, 1, 2)


        Sqlcomm.Append("Select ds_id AS ""ID"", ds_local AS ""Local"", ds_grupo AS ""Conta"" , ds_subgrupo AS ""SubConta"", ds_tipo AS ")
        Sqlcomm.Append("""TP"", ds_descricao AS ""Descricao"", ds_descricao2 AS ""Descricao2"" From loja1.desp001 ")
        Sqlcomm.Append("WHERE ds_local = '" & local & "' AND ds_subgrupo = '' ")
        Sqlcomm.Append("UNION ")
        Sqlcomm.Append("Select ds_id AS ""ID"", ds_local AS ""Local"", ds_grupo AS ""Conta"" , ds_subgrupo AS ""SubConta"", ds_tipo AS ")
        Sqlcomm.Append("""TP"", ds_descricao AS ""Descricao"", ds_descricao2 AS ""Descricao2"" From loja1.desp001 ")
        Sqlcomm.Append("WHERE ds_local = '" & local & "' AND ds_subgrupo <> '' ")
        Sqlcomm.Append("ORDER BY ""Conta"", ""SubConta"" ASC, ""TP"" DESC")

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
            'Me.dtg_planodecontas.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
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

        Try
            If dtg_planodecontas.CurrentRow.IsNewRow = False Then

                vds_id = dtg_planodecontas.CurrentRow.Cells(0).Value

                If MessageBox.Show("Deseja Exluir Conta ?", " Exclusão ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    cl_BD.crud_ExcPlanodeContas(vds_id, MdlConexaoBD.conectionPadrao)
                    lbl_mensagem.Text = "Registro Excluido c/ Sucesso !"
                    txt_pesquisa.Focus()
                    executaF5()
                End If

            Else
                MessageBox.Show("Favor Selecionar Uma linha, para Exclusão ", " Seleção ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txt_pesquisa.Focus()
            End If
        Catch ex As Exception
        End Try
        

    End Sub

    Private Sub cbo_tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tipo.SelectedIndexChanged

        Select Case cbo_tipo.SelectedIndex
            Case 0
                Me.msk_subconta.Enabled = False
                Me.txt_descricao2.Enabled = False
                Me.txt_conta.Enabled = True
                Me.txt_descricao.Enabled = True
            Case 1, 2
                Me.msk_subconta.Enabled = True
                Me.txt_descricao2.Enabled = True
                Me.txt_conta.Enabled = False
                Me.txt_descricao.Enabled = False
            Case Else
                Me.msk_subconta.Enabled = False
                Me.txt_descricao2.Enabled = False
                Me.txt_conta.Enabled = False
                Me.txt_descricao.Enabled = False
        End Select
       
        Me.lbl_mensagem.Text = ""

    End Sub

    Private Sub cbo_local_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbo_local.SelectedValueChanged

        Try
            If cbo_local.SelectedIndex > -1 Then
                executaF5()
            End If
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub dtg_planodecontas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_planodecontas.CellDoubleClick
        SetaValoresGrid(e.RowIndex)
    End Sub

End Class