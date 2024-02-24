﻿Imports System.IO
Imports System.Text
Imports System.Math
Imports Npgsql
Imports System.Data
Imports System.DateTime
Public Class Frm_BuscaPlano

    Private linhaAtual As Integer = -1
    Dim conexao As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Dim cl_BD As New Cl_bdMetrosys

    ' Variaveis Auxiliares:
    Dim vLocal, vConta, vSubconta, vDescricao, vDescricao2, vTipo As String


    Private Sub Frm_BuscaPlano_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Exibe_Planodecontas()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_buscaplano.CellContentClick
        ' variaveis locais  recebe valores do grid
        linhaAtual = Convert.ToInt32(e.RowIndex.ToString())
        vLocal = Me.dtg_buscaplano.CurrentRow.Cells(1).Value.ToString()
        vConta = Me.dtg_buscaplano.CurrentRow.Cells(2).Value.ToString()
        vSubconta = Me.dtg_buscaplano.CurrentRow.Cells(3).Value.ToString()
        vDescricao = Me.dtg_buscaplano.CurrentRow.Cells(5).Value.ToString()
        vDescricao2 = Me.dtg_buscaplano.CurrentRow.Cells(6).Value.ToString()
        vTipo = Me.dtg_buscaplano.CurrentRow.Cells(4).Value.ToString()

        'Construtores e controles do Formulario de origem, recebe valores das variaveis locais
        Frm_DespLancamento.LancaDespRef.txt_conta.Text = vConta.ToString
        Frm_DespLancamento.LancaDespRef.lbl_descricao.Text = vDescricao.ToString

        Frm_DespLancamento.LancaDespRef.msk_subconta.Text = vSubconta.ToString
        Frm_DespLancamento.LancaDespRef.txt_descricao2.Text = vDescricao2.ToString

        If vTipo = "P" Then
            Frm_DespLancamento.LancaDespRef.lbl_tipoplanc.Text = "Pagamento"
        ElseIf vTipo = "R" Then
            Frm_DespLancamento.LancaDespRef.lbl_tipoplanc.Text = "Recebimento"
        End If
        Me.Close()
    End Sub
    Private Sub Exibe_Planodecontas()
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim comm As NpgsqlCommand

        Sqlcomm.Append("Select ds_id AS ""ID"",ds_local AS ""Local"", ds_grupo AS ""Conta"" ,ds_subgrupo AS ""SubConta"",ds_tipo AS ""TP"",") '5
        Sqlcomm.Append("ds_descricao AS ""Descricao"", ds_descricao2 AS ""Descricao2"" From " & MdlEmpresaUsu._esqEstab & ".desp001 where ds_tipo='P' or ds_tipo='R' order by ")
        Sqlcomm.Append("ds_grupo, ds_subgrupo ASC, ds_tipo DESC")

        comm = New NpgsqlCommand(Sqlcomm.ToString, conexao)
        comm.CommandText = Sqlcomm.ToString

        Dim daPlanoC As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conexao)
        Dim dsPLanoC As DataSet = New DataSet()

        Try

            daPlanoC.Fill(dsPLanoC, MdlEmpresaUsu._esqEstab & ".desp001")
            conexao.Open()

            Me.dtg_buscaplano.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.dtg_buscaplano.DataSource = dsPLanoC.Tables(MdlEmpresaUsu._esqEstab & ".desp001").DefaultView
            Me.dtg_buscaplano.AllowUserToResizeColumns = False
            Me.dtg_buscaplano.AllowUserToResizeRows = False
            Me.dtg_buscaplano.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
            'Me.dtg_buscaplano.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            Me.dtg_buscaplano.Columns(0).Visible = False ' ID
            Me.dtg_buscaplano.Columns(0).Width = 20

            Me.dtg_buscaplano.Columns(1).Visible = False ' Local
            Me.dtg_buscaplano.Columns(1).Width = 20

            Me.dtg_buscaplano.Columns(2).Visible = False ' Conta
            ' Me.dtg_buscaplano.Columns(2).DefaultCellStyle.Format = "999.999.999-99"
            Me.dtg_buscaplano.Columns(2).Width = 40

            Me.dtg_buscaplano.Columns(3).Visible = True ' SubConta
            Me.dtg_buscaplano.Columns(3).Width = 57
            Me.dtg_buscaplano.Columns(3).DefaultCellStyle.Format = "999.9999"

            Me.dtg_buscaplano.Columns(4).Width = 25    ' TP

            Me.dtg_buscaplano.Columns(5).Visible = False ' Descrição
            Me.dtg_buscaplano.Columns(5).Width = 250

            Me.dtg_buscaplano.Columns(6).Visible = True ' Descrição2
            Me.dtg_buscaplano.Columns(6).Width = 210

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

    Private Sub dtg_buscaplano_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_buscaplano.CellContentDoubleClick
        ' variaveis locais  recebe valores do grid
        linhaAtual = Convert.ToInt32(e.RowIndex.ToString())
        vLocal = Me.dtg_buscaplano.CurrentRow.Cells(1).Value.ToString()
        vConta = Me.dtg_buscaplano.CurrentRow.Cells(2).Value.ToString()
        vSubconta = Me.dtg_buscaplano.CurrentRow.Cells(3).Value.ToString()
        vDescricao = Me.dtg_buscaplano.CurrentRow.Cells(5).Value.ToString()
        vDescricao2 = Me.dtg_buscaplano.CurrentRow.Cells(6).Value.ToString()
        vTipo = Me.dtg_buscaplano.CurrentRow.Cells(4).Value.ToString()

        'Construtores e controles do Formulario de origem, recebe valores das variaveis locais
        Frm_DespLancamento.LancaDespRef.txt_conta.Text = vConta.ToString
        Frm_DespLancamento.LancaDespRef.lbl_descricao.Text = vDescricao.ToString

        Frm_DespLancamento.LancaDespRef.msk_subconta.Text = vSubconta.ToString
        Frm_DespLancamento.LancaDespRef.txt_descricao2.Text = vDescricao2.ToString

        If vTipo = "P" Then
            Frm_DespLancamento.LancaDespRef.lbl_tipoplanc.Text = "Pagamento"
        ElseIf vTipo = "R" Then
            Frm_DespLancamento.LancaDespRef.lbl_tipoplanc.Text = "Recebimento"
        End If

        Me.Close()
    End Sub

    Private Sub dtg_buscaplano_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtg_buscaplano.KeyDown

        If e.KeyCode = Keys.Enter Then

            ' variaveis locais  recebe valores do grid
            linhaAtual = Convert.ToInt32(Me.dtg_buscaplano.CurrentRow.Index)
            vLocal = Me.dtg_buscaplano.CurrentRow.Cells(1).Value.ToString()
            vConta = Me.dtg_buscaplano.CurrentRow.Cells(2).Value.ToString()
            vSubconta = Me.dtg_buscaplano.CurrentRow.Cells(3).Value.ToString()
            vDescricao = Me.dtg_buscaplano.CurrentRow.Cells(5).Value.ToString()
            vDescricao2 = Me.dtg_buscaplano.CurrentRow.Cells(6).Value.ToString()
            vTipo = Me.dtg_buscaplano.CurrentRow.Cells(4).Value.ToString()

            'Construtores e controles do Formulario de origem, recebe valores das variaveis locais
            Frm_DespLancamento.LancaDespRef.txt_conta.Text = vConta.ToString
            Frm_DespLancamento.LancaDespRef.lbl_descricao.Text = vDescricao.ToString

            Frm_DespLancamento.LancaDespRef.msk_subconta.Text = vSubconta.ToString
            Frm_DespLancamento.LancaDespRef.txt_descricao2.Text = vDescricao2.ToString

            If vTipo = "P" Then
                Frm_DespLancamento.LancaDespRef.lbl_tipoplanc.Text = "Pagamento"
            ElseIf vTipo = "R" Then
                Frm_DespLancamento.LancaDespRef.lbl_tipoplanc.Text = "Recebimento"
            End If
            Me.Close()

        End If


    End Sub
End Class