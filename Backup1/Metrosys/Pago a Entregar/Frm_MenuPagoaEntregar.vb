Imports Npgsql
Imports System.Text

Public Class Frm_MenuPagoaEntregar

    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes, _clBD As New Cl_bdMetrosys


    Private Sub btn_relatorios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_relatorios.Click
        Dim RelEntrega As New Frm_RelatoriosaEntregar
        RelEntrega.ShowDialog()
    End Sub

    Private Sub Frm_MenuPagoaEntregar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                executaF5()

        End Select


    End Sub

    Private Sub executaF5()

        preecheDtgPagoaEntregar()

    End Sub

    Private Sub Frm_MenuPagoaEntregar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        executaF5()

    End Sub

    Private Sub preecheDtgPagoaEntregar()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Sqlcomm As StringBuilder = New StringBuilder

        'If MdlUsuarioLogando._usuarioPrivilegio Then 'verifica se usuário tem privilégio...

        '    Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa ") '12
        '    Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_vend = '" & MdlUsuarioLogando._codvendedor & "' AND n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca order by n1.nt_dtemis ")
        'End If

        Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", to_char(n1.nt_dtemis, 'dd/MM/yyyy') AS ""Emissão"",(n1.nt_codig || ' - ' || cad.p_portad) AS ""Cliente"", n1.nt_emiss AS ""OK"" ") '12
        Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_codig=cad.p_cod AND n4.n4_nume=n1.nt_orca AND n1.nt_tiposelecao = 1 ")
        Sqlcomm.Append("AND n1.nt_dtemis BETWEEN '" & Me.dtp_inicial.Text & "' AND '" & Me.dtp_final.Text & "' ORDER BY n1.nt_dtemis DESC")

        Dim daPed As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
        Dim dsPed As DataSet = New DataSet()

        Try
            'configurajanelaProdPesq()
            daPed.Fill(dsPed, "Orca1pp")
            conn.Open()

            Me.dtg_PagoaEntregar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.dtg_PagoaEntregar.DataSource = dsPed.Tables("Orca1pp").DefaultView
            'Me.dtg_PagoaEntregar.DefaultCellStyle.Font = New Font(Font.
            Me.dtg_PagoaEntregar.Columns(0).Visible = False
            Me.dtg_PagoaEntregar.Columns(1).Visible = False
            Me.dtg_PagoaEntregar.Columns(2).Width = 70
            Me.dtg_PagoaEntregar.Columns(3).Width = 70
            Me.dtg_PagoaEntregar.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.dtg_PagoaEntregar.Columns(4).Width = 311
            Me.dtg_PagoaEntregar.Columns(5).Width = 30
            Me.dtg_PagoaEntregar.AllowUserToResizeColumns = False
            Me.dtg_PagoaEntregar.AllowUserToResizeRows = False
            Me.dtg_PagoaEntregar.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
            'Me.dtg_PagoaEntregar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells 'Aumenta as o tamanho das colunas de acordo com os dados a seremn mostrados

            Me.dtg_PagoaEntregar.Refresh()
            'Me.dtg_PagoaEntregar.Columns(8).DefaultCellStyle.Format = "###,##0.00"

            conn.ClearPool() : conn.Close()
            conn = Nothing : daPed = Nothing : dsPed = Nothing : Sqlcomm = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Private Sub btn_processo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_processo.Click
        Dim Mproces As New Frm_ProcessaMov
        Mproces.ShowDialog()
        Mproces = Nothing
        executaF5()
    End Sub

    Private Sub btn_baixa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_baixa.Click
        Dim BaixaREc As New Frm_baixarrequisicao
        BaixaREc.ShowDialog()
        BaixaREc = Nothing
    End Sub

    Private Sub dtp_inicial_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_inicial.ValueChanged, dtp_final.ValueChanged

        executaF5()

    End Sub

    Private Sub btn_requisicoes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_requisicoes.Click

        Dim frm_requisicoes As New Frm_viewRequisicao
        frm_requisicoes.Show()
        frm_requisicoes = Nothing
    End Sub

    
    Private Sub btn_saldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_saldo.Click

        Dim frm_SaldoConta As New Frm_viewSaldoConta
        frm_SaldoConta.Show()
        frm_SaldoConta = Nothing
    End Sub
End Class