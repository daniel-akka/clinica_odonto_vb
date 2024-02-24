Imports System.IO
Imports System.Text
Imports System.Math
Imports Npgsql
Imports System.Data
Imports System.Drawing.Point
Imports System.DateTime

Public Class Frm_MenuLancamentos
    Private linhaAtual As Integer = -1
    Dim conex As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Dim cl_BD As New Cl_bdMetrosys
    ' Variaveis Auxiliar:
    Dim vConta, vSubconta, vDescricao2, vHistorico, vTipo As String
    Dim vDataMov As Date
    Dim vValor As Double
    Dim Vid As Integer

    Private Sub Frm_MenuLancamentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                executaF5()
        End Select

    End Sub

    Private Sub Frm_MenuLancamentos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_MenuLancamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rdb_historico.Checked = True
        Me.msk_inicio.Visible = False
        Me.msk_final.Visible = False
        Me.lbl_intervalo.Visible = False
        exibe_LancamentosAtuais()
    End Sub

    Private Sub executaF5()

        If rdb_historico.Checked Then
            exibe_LancamentosHistorico(txt_pesquisa.Text)
        ElseIf rdb_periodo.Checked Then
            exibe_LancamentosPeriodo(DateValue(msk_inicio.Text), DateValue(msk_final.Text))
        Else
            exibe_LancamentosAtuais()
        End If

    End Sub

    Private Sub exibe_LancamentosAtuais()
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim comm As NpgsqlCommand

        Sqlcomm.Append("Select Lc.dm_id AS ""ID"",Lc.dm_firma AS ""Local"", Lc.dm_grupo AS ""Conta"" ,Lc.dm_subgrupo AS ""SubConta"",Lc.dm_tipo AS ""TP"",") '4
        Sqlcomm.Append("Lc.dm_data AS ""Data"",Pl.ds_descricao2 AS ""Descricao"",Lc.dm_historico AS ""Historico"", Lc.dm_valor AS ""Valor R$"" From " & MdlEmpresaUsu._esqEstab & ".despm002 Lc," & MdlEmpresaUsu._esqEstab & ".desp001 ")
        Sqlcomm.Append("Pl where Lc.dm_subgrupo=Pl.ds_subgrupo order by Lc.dm_id desc limit 20")

        comm = New NpgsqlCommand(Sqlcomm.ToString, conex)
        comm.CommandText = Sqlcomm.ToString

        Dim daPlanoC As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conex)
        Dim dsPLanoC As DataSet = New DataSet()

        Try

            daPlanoC.Fill(dsPLanoC, MdlEmpresaUsu._esqEstab & ".despm002")
            conex.Open()

            Me.dtg_lancamentos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.dtg_lancamentos.DataSource = dsPLanoC.Tables(MdlEmpresaUsu._esqEstab & ".despm002").DefaultView
            Me.dtg_lancamentos.AllowUserToResizeColumns = False
            Me.dtg_lancamentos.AllowUserToResizeRows = False
            Me.dtg_lancamentos.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
            'Me.dtg_lancamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            Me.dtg_lancamentos.Columns(0).Visible = False ' ID
            Me.dtg_lancamentos.Columns(0).Width = 20

            Me.dtg_lancamentos.Columns(1).Visible = False ' Local
            Me.dtg_lancamentos.Columns(1).Width = 20

            Me.dtg_lancamentos.Columns(2).Visible = False ' Conta
            ' Me.dtg_lancamentos.Columns(2).DefaultCellStyle.Format = "999.999.999-99"
            Me.dtg_lancamentos.Columns(2).Width = 40

            Me.dtg_lancamentos.Columns(3).Visible = True  ' SubConta
            Me.dtg_lancamentos.Columns(3).DefaultCellStyle.Format = String.Format("###.####", (dtg_lancamentos.Columns(3).ToString))
            Me.dtg_lancamentos.Columns(3).Width = 58

            Me.dtg_lancamentos.Columns(4).Width = 25      ' TP

            Me.dtg_lancamentos.Columns(5).Visible = True  ' Data Movimento
            Me.dtg_lancamentos.Columns(5).Width = 67
            Me.dtg_lancamentos.Columns(5).DefaultCellStyle.Format = "dd/MM/yyyy"

            Me.dtg_lancamentos.Columns(6).Visible = True ' Descrição
            Me.dtg_lancamentos.Columns(6).Width = 230

            Me.dtg_lancamentos.Columns(7).Visible = True ' Historico
            Me.dtg_lancamentos.Columns(7).Width = 205

            Me.dtg_lancamentos.Columns(8).Visible = True ' Valor
            Me.dtg_lancamentos.Columns(8).Width = 80
            Me.dtg_lancamentos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dtg_lancamentos.Columns(8).DefaultCellStyle.Format = "#,###,##0.00"

            conex.ClearPool()
            conex.Close()
            ' conexao = Nothing
            'daPlanoC = Nothing : dsPLanoC = Nothing : 
            Sqlcomm = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub exibe_LancamentosPeriodo(ByVal DataInicio As Date, ByVal DataFinal As Date)
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim comm As NpgsqlCommand

        Sqlcomm.Append("Select Lc.dm_id AS ""ID"",Lc.dm_firma AS ""Local"", Lc.dm_grupo AS ""Conta"" ,Lc.dm_subgrupo AS ""SubConta"",Lc.dm_tipo AS ""TP"",") '4
        Sqlcomm.Append("Lc.dm_data AS ""Data"",Pl.ds_descricao2 AS ""Descricao"",Lc.dm_historico AS ""Historico"", Lc.dm_valor AS ""Valor R$"" From " & MdlEmpresaUsu._esqEstab & ".despm002 Lc," & MdlEmpresaUsu._esqEstab & ".desp001 ")
        Sqlcomm.Append("Pl where Lc.dm_subgrupo=Pl.ds_subgrupo and Lc.dm_data between '" & DataInicio & "' and '" & DataFinal & "' order by Lc.dm_id asc")

        comm = New NpgsqlCommand(Sqlcomm.ToString, conex)
        comm.CommandText = Sqlcomm.ToString

        Dim daPlanoC As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conex)
        Dim dsPLanoC As DataSet = New DataSet()

        Try

            daPlanoC.Fill(dsPLanoC, MdlEmpresaUsu._esqEstab & ".despm002")
            conex.Open()

            Me.dtg_lancamentos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.dtg_lancamentos.DataSource = dsPLanoC.Tables(MdlEmpresaUsu._esqEstab & ".despm002").DefaultView
            Me.dtg_lancamentos.AllowUserToResizeColumns = False
            Me.dtg_lancamentos.AllowUserToResizeRows = False
            Me.dtg_lancamentos.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
            'Me.dtg_lancamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            Me.dtg_lancamentos.Columns(0).Visible = False ' ID
            Me.dtg_lancamentos.Columns(0).Width = 20

            Me.dtg_lancamentos.Columns(1).Visible = False ' Local
            Me.dtg_lancamentos.Columns(1).Width = 20

            Me.dtg_lancamentos.Columns(2).Visible = False ' Conta
            ' Me.dtg_lancamentos.Columns(2).DefaultCellStyle.Format = "999.999.999-99"
            Me.dtg_lancamentos.Columns(2).Width = 40

            Me.dtg_lancamentos.Columns(3).Visible = True  ' SubConta
            Me.dtg_lancamentos.Columns(3).DefaultCellStyle.Format = String.Format("###.####", (dtg_lancamentos.Columns(3).ToString))
            Me.dtg_lancamentos.Columns(3).Width = 58

            Me.dtg_lancamentos.Columns(4).Width = 25      ' TP

            Me.dtg_lancamentos.Columns(5).Visible = True  ' Data Movimento
            Me.dtg_lancamentos.Columns(5).Width = 67
            Me.dtg_lancamentos.Columns(5).DefaultCellStyle.Format = "dd/MM/yyyy"

            Me.dtg_lancamentos.Columns(6).Visible = True ' Descrição
            Me.dtg_lancamentos.Columns(6).Width = 230

            Me.dtg_lancamentos.Columns(7).Visible = True ' Historico
            Me.dtg_lancamentos.Columns(7).Width = 205

            Me.dtg_lancamentos.Columns(8).Visible = True ' Valor
            Me.dtg_lancamentos.Columns(8).Width = 80
            Me.dtg_lancamentos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dtg_lancamentos.Columns(8).DefaultCellStyle.Format = "#,###,##0.00"

            conex.ClearPool()
            conex.Close()
            ' conexao = Nothing
            'daPlanoC = Nothing : dsPLanoC = Nothing : 
            Sqlcomm = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub exibe_LancamentosHistorico(ByVal mHistorico As String)
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim comm As NpgsqlCommand

        Sqlcomm.Append("Select Lc.dm_id AS ""ID"",Lc.dm_firma AS ""Local"", Lc.dm_grupo AS ""Conta"" ,Lc.dm_subgrupo AS ""SubConta"",Lc.dm_tipo AS ""TP"",") '4
        Sqlcomm.Append("Lc.dm_data AS ""Data"",Pl.ds_descricao2 AS ""Descricao"",Lc.dm_historico AS ""Historico"", Lc.dm_valor AS ""Valor R$"" From " & MdlEmpresaUsu._esqEstab & ".despm002 Lc," & MdlEmpresaUsu._esqEstab & ".desp001 ")
        Sqlcomm.Append("Pl where Lc.dm_subgrupo=Pl.ds_subgrupo and Upper(Lc.dm_historico) like '%" & mHistorico & "%' order by Lc.dm_data ")

        comm = New NpgsqlCommand(Sqlcomm.ToString, conex)
        comm.CommandText = Sqlcomm.ToString

        Dim daPlanoC As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conex)
        Dim dsPLanoC As DataSet = New DataSet()

        Try

            daPlanoC.Fill(dsPLanoC, MdlEmpresaUsu._esqEstab & ".despm002")
            conex.Open()

            Me.dtg_lancamentos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.dtg_lancamentos.DataSource = dsPLanoC.Tables(MdlEmpresaUsu._esqEstab & ".despm002").DefaultView
            Me.dtg_lancamentos.AllowUserToResizeColumns = False
            Me.dtg_lancamentos.AllowUserToResizeRows = False
            Me.dtg_lancamentos.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
            'Me.dtg_lancamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            Me.dtg_lancamentos.Columns(0).Visible = False ' ID
            Me.dtg_lancamentos.Columns(0).Width = 20

            Me.dtg_lancamentos.Columns(1).Visible = False ' Local
            Me.dtg_lancamentos.Columns(1).Width = 20

            Me.dtg_lancamentos.Columns(2).Visible = False ' Conta
            ' Me.dtg_lancamentos.Columns(2).DefaultCellStyle.Format = "999.999.999-99"
            Me.dtg_lancamentos.Columns(2).Width = 40

            Me.dtg_lancamentos.Columns(3).Visible = True  ' SubConta
            Me.dtg_lancamentos.Columns(3).DefaultCellStyle.Format = String.Format("###.####", (dtg_lancamentos.Columns(3).ToString))
            Me.dtg_lancamentos.Columns(3).Width = 58

            Me.dtg_lancamentos.Columns(4).Width = 25      ' TP

            Me.dtg_lancamentos.Columns(5).Visible = True  ' Data Movimento
            Me.dtg_lancamentos.Columns(5).Width = 67
            Me.dtg_lancamentos.Columns(5).DefaultCellStyle.Format = "dd/MM/yyyy"

            Me.dtg_lancamentos.Columns(6).Visible = True ' Descrição
            Me.dtg_lancamentos.Columns(6).Width = 230

            Me.dtg_lancamentos.Columns(7).Visible = True ' Historico
            Me.dtg_lancamentos.Columns(7).Width = 205

            Me.dtg_lancamentos.Columns(8).Visible = True ' Valor
            Me.dtg_lancamentos.Columns(8).Width = 80
            Me.dtg_lancamentos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dtg_lancamentos.Columns(8).DefaultCellStyle.Format = "#,###,##0.00"

            conex.ClearPool()
            conex.Close()
            ' conexao = Nothing
            'daPlanoC = Nothing : dsPLanoC = Nothing : 
            Sqlcomm = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click
        If linhaAtual = -1 Then
            MessageBox.Show("Favor Selecionar Uma linha, para alteração ", " Seleção ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_pesquisa.Focus()
        Else

            Dim LancDesp As New Frm_DespLancamento
            LancDesp.cbo_loja.SelectedIndex = 0
            LancDesp.txt_conta.Text = vConta
            LancDesp.msk_subconta.Text = vSubconta
            LancDesp.msk_data.Text = vDataMov
            LancDesp.txt_descricao2.Text = vDescricao2
            LancDesp.txt_historico.Text = vHistorico
            LancDesp.txt_valor.Text = vValor
            LancDesp.txt_valor2.Text = vValor
            LancDesp.MIdLanc = Vid
            If vTipo = "P" Then
                LancDesp.lbl_tipoplanc.Text = "Pagamento"
            Else
                LancDesp.lbl_tipoplanc.Text = "Recebimento"
            End If
            LancDesp.btn_incluir.Enabled = False
            LancDesp.btn_alterar.Enabled = True

            LancDesp.ShowDialog()
            executaF5()

        End If


    End Sub

    Private Sub dtg_lancamentos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_lancamentos.CellContentClick

    End Sub

    Private Sub dtg_lancamentos_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_lancamentos.CellContentDoubleClick
        linhaAtual = Convert.ToInt32(e.RowIndex.ToString())
        Vid = Me.dtg_lancamentos.CurrentRow.Cells(0).Value.ToString()
        vConta = Me.dtg_lancamentos.CurrentRow.Cells(2).Value.ToString()
        vSubconta = Me.dtg_lancamentos.CurrentRow.Cells(3).Value.ToString()
        vTipo = Me.dtg_lancamentos.CurrentRow.Cells(4).Value.ToString()
        vDataMov = Me.dtg_lancamentos.CurrentRow.Cells(5).Value.ToString()
        vDescricao2 = Me.dtg_lancamentos.CurrentRow.Cells(6).Value.ToString()
        vHistorico = Me.dtg_lancamentos.CurrentRow.Cells(7).Value.ToString()
        vValor = Me.dtg_lancamentos.CurrentRow.Cells(8).Value.ToString()
        Beep()
    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click
        Dim LancDesp As New Frm_DespLancamento
        LancDesp.btn_incluir.Enabled = True
        LancDesp.btn_alterar.Enabled = False

        LancDesp.ShowDialog()
        executaF5()

    End Sub

    Private Sub btn_pesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pesquisa.Click

        If rdb_periodo.Checked = True Then
            exibe_LancamentosPeriodo(DateValue(msk_inicio.Text), DateValue(msk_final.Text))
        Else
            exibe_LancamentosHistorico(txt_pesquisa.Text)
        End If

    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click
        If linhaAtual = -1 Then
            MessageBox.Show("Favor Selecionar Uma linha, para Exclusão ", " Seleção ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_pesquisa.Focus()
        Else
            If MessageBox.Show("Deseja Exluir Lancamento ?", " Exclusão ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cl_BD.crud_ExcDespLancamentos(Vid, conex)
                lbl_mensagem.Text = "Registro Excluido c/ Sucesso !"
                txt_pesquisa.Focus()
            End If
        End If

    End Sub

    Private Sub rdb_periodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_periodo.CheckedChanged

        Me.msk_inicio.Visible = True
        Me.msk_final.Visible = True
        Me.txt_pesquisa.Visible = False
        Me.lbl_intervalo.Visible = True
        Me.msk_inicio.Focus()
        If rdb_periodo.Checked Then

            btn_pesquisa.SetBounds(261, 15, 28, 27)
        End If

    End Sub

    Private Sub rdb_historico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_historico.CheckedChanged
        Me.msk_inicio.Visible = False
        Me.msk_final.Visible = False
        Me.txt_pesquisa.Visible = True
        Me.lbl_intervalo.Visible = False
        Me.txt_pesquisa.Focus()

        If rdb_historico.Checked Then

            btn_pesquisa.SetBounds(392, 16, 28, 27)
        End If
    End Sub

End Class