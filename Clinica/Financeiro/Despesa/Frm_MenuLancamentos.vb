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

    Dim _Loja As String = ""


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
        lbl_NomeSys.Text = Application.ProductName

        cbo_empresa = _clFunc.PreenchComboLoja2Dig(cbo_empresa, MdlConexaoBD.conectionPadrao)
        cbo_empresa.SelectedIndex = _clFunc.trazIndexComboBox(Mid(MdlEmpresaUsu._codigo, MdlEmpresaUsu._codigo.Length - 1), 2, cbo_empresa)
        cbo_grupo = _clFunc.PreenchComboGrupoContas(cbo_grupo, MdlConexaoBD.conectionPadrao, MdlEmpresaUsu._esqEstab)
        cbo_grupo.SelectedIndex = 0
        cbo_tipo.SelectedIndex = 0
        Me.rdb_historico.Checked = True
        Me.msk_inicio.Visible = False
        Me.msk_final.Visible = False
        Me.lbl_intervalo.Visible = False
    End Sub

    Private Sub executaF5()

        If rdb_historico.Checked OrElse rdb_periodo.Checked Then
            exibe_LancamentosHistoricoPeriodo()
        Else
            exibe_LancamentosAtuais()
        End If

    End Sub

    Sub SomaTotais()

        Dim mSoma As Double = 0.0

        For Each row As DataGridViewRow In dtg_lancamentos.Rows

            If row.IsNewRow = False Then
                mSoma += row.Cells(8).Value
            End If
        Next

        txt_somaTotais.Text = Format(mSoma, "###,##0.00")
    End Sub

    Private Sub exibe_LancamentosAtuais()
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim comm As NpgsqlCommand

        Sqlcomm.Append("Select Lc.dm_id AS ""ID"",Lc.dm_firma AS ""Local"", Lc.dm_grupo AS ""Conta"" ,Lc.dm_subgrupo AS ""SubConta"",Lc.dm_tipo AS ""TP"",") '4
        Sqlcomm.Append("Lc.dm_data AS ""Data"",Pl.ds_descricao2 AS ""Descricao"",Lc.dm_historico AS ""Historico"", Lc.dm_valor AS ""Valor R$"" From " & MdlEmpresaUsu._esqEstab & ".despm002 Lc JOIN " & MdlEmpresaUsu._esqEstab & ".desp001 Pl ")
        Sqlcomm.Append("ON Pl.ds_local = Lc.dm_firma ")
        Sqlcomm.Append("WHERE Pl.ds_local = '0" & _Loja & "' AND Lc.dm_subgrupo=Pl.ds_subgrupo order by Lc.dm_id desc limit 20")

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
            'Me.dtg_lancamentos.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
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
            Me.dtg_lancamentos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dtg_lancamentos.Columns(3).Width = 65

            Me.dtg_lancamentos.Columns(4).Width = 25      ' TP
            Me.dtg_lancamentos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.dtg_lancamentos.Columns(5).Visible = True  ' Data Movimento
            Me.dtg_lancamentos.Columns(5).Width = 90
            Me.dtg_lancamentos.Columns(5).DefaultCellStyle.Format = "dd/MM/yyyy"
            Me.dtg_lancamentos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.dtg_lancamentos.Columns(6).Visible = True ' Descrição
            Me.dtg_lancamentos.Columns(6).Width = 223

            Me.dtg_lancamentos.Columns(7).Visible = True ' Historico
            Me.dtg_lancamentos.Columns(7).Width = 247

            Me.dtg_lancamentos.Columns(8).Visible = True ' Valor
            Me.dtg_lancamentos.Columns(8).Width = 80
            Me.dtg_lancamentos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dtg_lancamentos.Columns(8).DefaultCellStyle.Format = "#,###,##0.00"


            conex.Close()

            dtg_lancamentos.Refresh()
            txt_qtdeRegistros.Text = dtg_lancamentos.Rows.Count
            SomaTotais()
            ' conexao = Nothing
            'daPlanoC = Nothing : dsPLanoC = Nothing : 
            Sqlcomm = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub exibe_LancamentosHistoricoPeriodo()
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim comm As NpgsqlCommand

        Sqlcomm.Append("Select Lc.dm_id AS ""ID"",Lc.dm_firma AS ""Local"", Lc.dm_grupo AS ""Conta"" ,Lc.dm_subgrupo AS ""SubConta"",Lc.dm_tipo AS ""TP"",") '4
        Sqlcomm.Append("Lc.dm_data AS ""Data"",Pl.ds_descricao2 AS ""Descricao"",Lc.dm_historico AS ""Historico"", Lc.dm_valor AS ""Valor R$"" From " & MdlEmpresaUsu._esqEstab & ".despm002 Lc JOIN " & MdlEmpresaUsu._esqEstab & ".desp001 Pl ")
        Sqlcomm.Append("ON Pl.ds_local = Lc.dm_firma ")
        Sqlcomm.Append("WHERE Pl.ds_local = '0" & _Loja & "' AND Lc.dm_subgrupo=Pl.ds_subgrupo ")

        If cbo_tipo.SelectedIndex > 0 Then
            Sqlcomm.Append("AND Lc.dm_tipo = '" & cbo_tipo.SelectedItem & "' ")
        End If

        If cbo_grupo.SelectedIndex > 0 Then
            Sqlcomm.Append("AND Lc.dm_grupo = '" & Mid(cbo_grupo.SelectedItem, 1, 3) & "' ")
        End If

        If rdb_historico.Checked Then
            Sqlcomm.Append("AND Upper(Lc.dm_historico) like '%" & txt_pesquisa.Text & "%' ORDER BY Lc.dm_data ")
        Else

            If IsDate(msk_inicio.Text) AndAlso IsDate(msk_inicio.Text) Then
                Sqlcomm.Append("AND Lc.dm_data BETWEEN '" & msk_inicio.Text & "' AND '" & msk_final.Text & "' ORDER BY Lc.dm_data ")
            Else
                If IsDate(msk_inicio.Text) = False Then lbl_mensagem.Text = "Data está incorreta!" : msk_inicio.Focus() : Return
                If IsDate(msk_final.Text) = False Then lbl_mensagem.Text = "Data está incorreta!" : msk_final.Focus() : Return
            End If

        End If


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
            'Me.dtg_lancamentos.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
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
            Me.dtg_lancamentos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dtg_lancamentos.Columns(3).Width = 65

            Me.dtg_lancamentos.Columns(4).Width = 25      ' TP
            Me.dtg_lancamentos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.dtg_lancamentos.Columns(5).Visible = True  ' Data Movimento
            Me.dtg_lancamentos.Columns(5).Width = 90
            Me.dtg_lancamentos.Columns(5).DefaultCellStyle.Format = "dd/MM/yyyy"
            Me.dtg_lancamentos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Me.dtg_lancamentos.Columns(6).Visible = True ' Descrição
            Me.dtg_lancamentos.Columns(6).Width = 223

            Me.dtg_lancamentos.Columns(7).Visible = True ' Historico
            Me.dtg_lancamentos.Columns(7).Width = 247

            Me.dtg_lancamentos.Columns(8).Visible = True ' Valor
            Me.dtg_lancamentos.Columns(8).Width = 80
            Me.dtg_lancamentos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dtg_lancamentos.Columns(8).DefaultCellStyle.Format = "#,###,##0.00"

            conex.Close()

            dtg_lancamentos.Refresh()
            txt_qtdeRegistros.Text = dtg_lancamentos.Rows.Count
            SomaTotais()
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

        Try
            linhaAtual = dtg_lancamentos.CurrentRow.Index
        Catch ex As Exception
            linhaAtual = -1
        End Try

        If linhaAtual = -1 Then
            MessageBox.Show("Favor Selecionar Uma linha, para alteração ", " Seleção ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_pesquisa.Focus()
        Else

            Dim LancDesp As New Frm_DespLancamento
            LancDesp.LocalEmp = _Loja
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

    Private Sub dtg_lancamentos_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_lancamentos.CellContentDoubleClick
        linhaAtual = Convert.ToInt32(e.RowIndex)
        Vid = Me.dtg_lancamentos.CurrentRow.Cells(0).Value.ToString()
        vConta = Me.dtg_lancamentos.CurrentRow.Cells(2).Value.ToString()
        vSubconta = Me.dtg_lancamentos.CurrentRow.Cells(3).Value.ToString()
        vTipo = Me.dtg_lancamentos.CurrentRow.Cells(4).Value.ToString()
        vDataMov = Me.dtg_lancamentos.CurrentRow.Cells(5).Value.ToString()
        vDescricao2 = Me.dtg_lancamentos.CurrentRow.Cells(6).Value.ToString()
        vHistorico = Me.dtg_lancamentos.CurrentRow.Cells(7).Value.ToString()
        vValor = Me.dtg_lancamentos.CurrentRow.Cells(8).Value.ToString()

    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click
        Dim LancDesp As New Frm_DespLancamento
        LancDesp.LocalEmp = _Loja
        LancDesp.btn_incluir.Enabled = True
        LancDesp.btn_alterar.Enabled = False

        LancDesp.ShowDialog()
        executaF5()

    End Sub

    Private Sub btn_pesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pesquisa.Click

        If rdb_periodo.Checked = True Then
            exibe_LancamentosHistoricoPeriodo()
        Else
            exibe_LancamentosHistoricoPeriodo()
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
                executaF5()
                txt_pesquisa.Focus()
            End If
        End If

    End Sub

    Private Sub rdb_periodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_periodo.CheckedChanged, rdb_historico.CheckedChanged

        If rdb_historico.Checked Then
            Me.msk_inicio.Visible = False
            Me.msk_final.Visible = False
            Me.txt_pesquisa.Visible = True
            Me.lbl_intervalo.Visible = False
            Me.txt_pesquisa.Focus()

            btn_pesquisa.SetBounds(425, 16, 28, 27)
        Else

            Me.msk_inicio.Visible = True
            Me.msk_final.Visible = True
            Me.txt_pesquisa.Visible = False
            Me.lbl_intervalo.Visible = True
            Me.msk_inicio.Focus()
            btn_pesquisa.SetBounds(270, 15, 28, 27)

        End If
       

    End Sub

    Private Sub dtg_lancamentos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_lancamentos.CellClick

        linhaAtual = Convert.ToInt32(e.RowIndex)
        Vid = Me.dtg_lancamentos.CurrentRow.Cells(0).Value.ToString()
        vConta = Me.dtg_lancamentos.CurrentRow.Cells(2).Value.ToString()
        vSubconta = Me.dtg_lancamentos.CurrentRow.Cells(3).Value.ToString()
        vTipo = Me.dtg_lancamentos.CurrentRow.Cells(4).Value.ToString()
        vDataMov = Me.dtg_lancamentos.CurrentRow.Cells(5).Value.ToString()
        vDescricao2 = Me.dtg_lancamentos.CurrentRow.Cells(6).Value.ToString()
        vHistorico = Me.dtg_lancamentos.CurrentRow.Cells(7).Value.ToString()
        vValor = Me.dtg_lancamentos.CurrentRow.Cells(8).Value.ToString()

    End Sub

    Private Sub cbo_tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tipo.SelectedIndexChanged

        Try
           executaF5()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbo_grupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_grupo.SelectedIndexChanged

        Try
           executaF5()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbo_empresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_empresa.SelectedIndexChanged

        Try
            If cbo_empresa.SelectedIndex >= 0 Then
                _Loja = Mid(cbo_empresa.SelectedItem.ToString, 1, 2)
                executaF5()
            End If
        Catch ex As Exception
        End Try

    End Sub
End Class