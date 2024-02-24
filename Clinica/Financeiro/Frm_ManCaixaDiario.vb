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

    Dim _clFuncoes As New ClFuncoes
    Dim _CX As New Cl_CaixaDiario
    Dim _CxDAO As New Cl_CaixaDiarioDAO
    Dim _CxOrca As New Cl_CxOrcamento
    Dim _CxOrcaDAO As New Cl_CxOrcamentoDAO
    Dim _Dentista As New Cl_Doutor
    Dim _DentistaDAO As New Cl_DoutorDAO
    Dim _Geno As New Cl_Geno

    Private Sub btn_lancar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lancar.Click

        Dim LancaCX As New Frm_LancamentosCaixa
        LancaCX.btn_alterar.Enabled = False
        LancaCX.ShowDialog()
        ExecuteF5()

    End Sub

    Private Sub Frm_ManCaixaDiario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                ExecuteF5()
        End Select
    End Sub

    Private Sub Frm_ManCaixaDiario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName


        _clFuncoes.trazGenoSelecionado(MdlEmpresaUsu._codigo, _Geno)
        _DentistaDAO.PreenchComboDoutoresPesq(_Geno, cbo_dentistas, MdlConexaoBD.conectionPadrao)
        cbo_dentistas.SelectedIndex = 0
        cbo_tipo.SelectedIndex = 0
        If MdlUsuarioLogando._codcaixa.Equals("") = False Then

            'If _clFuncoes.CX_AbertoNoDia(MdlUsuarioLogando._codcaixa, Date.Now, MdlConexaoBD.conectionPadrao) = False Then
            '    MsgBox("Atenção! Caixa ainda NÂO foi ABERTO HOJE! """ & Date.Now & """ ", MsgBoxStyle.Exclamation)
            'End If
        End If

        If MdlUsuarioLogando._usuarioPrivilegio Then
            btn_divisoria.Enabled = True
        End If
       
        preecheDtg_caixa()
    End Sub

    Sub ExecuteF5()
        preecheDtg_caixa()
    End Sub

    Function TrazConsultaLancamentos() As String
        Dim Sqlcomm As StringBuilder = New StringBuilder

        Sqlcomm.Append("SELECT cx_id, cx_tipo AS ""Tipo"", cx_data AS ""Emissao"", cx_descricao AS ""Descricao"", cx_valor AS ""Valor "", cx_usu AS ""Usuario"", ") '5
        Sqlcomm.Append("cx_status AS ""Stat"", cx_usuarioalt, cx_doutor, false AS ""Orc"", cx_protetico AS ""Prot."", cx_nomecli ")
        Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario LEFT OUTER JOIN cadp001 cad ON cad.p_cod = cx_codcli WHERE cx_loja= '" & MdlEmpresaUsu._codigo & "' ")


        If cbo_dentistas.SelectedIndex > 0 Then
            Sqlcomm.Append(" AND cx_doutor = '" & cbo_dentistas.SelectedItem.ToString & "' ")
        End If

        If cbo_tipo.SelectedIndex > 0 Then
            Sqlcomm.Append(" AND cx_tipo = '" & Mid(cbo_tipo.SelectedItem.ToString, 1, 1) & "' ")
        End If

        If IsDate(dtp_inicial.Text) AndAlso IsDate(dtp_final.Text) Then
            Sqlcomm.Append(" AND cx_data BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "' ")
        End If

        Sqlcomm.Append("ORDER BY cx_data DESC LIMIT 10000")


        Return Sqlcomm.ToString
    End Function

    Function TrazConsultaOrcamentos() As String
        Dim Sqlcomm As StringBuilder = New StringBuilder

        Sqlcomm.Append("SELECT oc_id, 'O' AS ""Tipo"", oc_data AS ""Emissao"", oc_descricao AS ""Descricao"", oc_valor AS ""Valor "", oc_usu AS ""Usuario"", ") '5
        Sqlcomm.Append("oc_status AS ""Stat"", oc_usuarioalt, oc_doutor, true AS ""Orc"", '' AS ""Prot."", oc_nomecli ")
        Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".cxorcamento LEFT OUTER JOIN cadp001 cad ON cad.p_cod = oc_codcli WHERE oc_loja= '" & MdlEmpresaUsu._codigo & "' ")


        If cbo_dentistas.SelectedIndex > 0 Then
            Sqlcomm.Append(" AND oc_doutor = '" & cbo_dentistas.SelectedItem.ToString & "' ")
        End If

        If IsDate(dtp_inicial.Text) AndAlso IsDate(dtp_final.Text) Then
            Sqlcomm.Append(" AND oc_data BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "' ")
        End If

        Sqlcomm.Append("ORDER BY oc_data DESC LIMIT 10000")


        Return Sqlcomm.ToString
    End Function

    Function TrazConsultaLanca_Orca() As String
        Dim Sqlcomm As StringBuilder = New StringBuilder

        Sqlcomm.Append("SELECT cx_id, cx_tipo AS ""Tipo"", cx_data AS ""Emissao"", cx_descricao AS ""Descricao"", cx_valor AS ""Valor "", cx_usu AS ""Usuario"", ") '5
        Sqlcomm.Append("cx_status AS ""Stat"", cx_usuarioalt, cx_doutor, false AS ""Orc"", cx_protetico AS ""Prot."", cx_nomecli ")
        Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario LEFT OUTER JOIN cadp001 cad ON cad.p_cod = cx_codcli WHERE cx_loja= '" & MdlEmpresaUsu._codigo & "' ")

        If cbo_dentistas.SelectedIndex > 0 Then
            Sqlcomm.Append(" AND cx_doutor = '" & cbo_dentistas.SelectedItem.ToString & "' ")
        End If

        If cbo_tipo.SelectedIndex > 0 Then
            Sqlcomm.Append(" AND cx_tipo = '" & Mid(cbo_tipo.SelectedItem.ToString, 1, 1) & "' ")
        End If

        If IsDate(dtp_inicial.Text) AndAlso IsDate(dtp_final.Text) Then
            Sqlcomm.Append(" AND cx_data BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "' ")
        End If

        Sqlcomm.Append("UNION ")

        Sqlcomm.Append("SELECT oc_id, 'O' AS ""Tipo"", oc_data AS ""Emissao"", oc_descricao AS ""Descricao"", oc_valor AS ""Valor "", oc_usu AS ""Usuario"", ") '5
        Sqlcomm.Append("oc_status AS ""Stat"", oc_usuarioalt, oc_doutor, true AS ""Orc"", '' AS ""Prot."", oc_nomecli ")
        Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".cxorcamento LEFT OUTER JOIN cadp001 cad ON cad.p_cod = oc_codcli WHERE oc_loja= '" & MdlEmpresaUsu._codigo & "' ")

        If cbo_dentistas.SelectedIndex > 0 Then
            Sqlcomm.Append(" AND oc_doutor = '" & cbo_dentistas.SelectedItem.ToString & "' ")
        End If

        If IsDate(dtp_inicial.Text) AndAlso IsDate(dtp_final.Text) Then
            Sqlcomm.Append(" AND oc_data BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "' ")
        End If


        Sqlcomm.Append("ORDER BY ""Emissao"" DESC LIMIT 10000")


        Return Sqlcomm.ToString
    End Function

    Private Sub preecheDtg_caixa()

        chk_marcarTodos.Checked = False
        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim consulta As String

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão:: " & ex.Message)
        End Try

        If chk_lanca_orca.Checked Then
            consulta = TrazConsultaLanca_Orca()
        Else

            If chk_orcamento.Checked Then
                consulta = TrazConsultaOrcamentos()
            Else
                consulta = TrazConsultaLancamentos()
            End If
        End If

        comm = New NpgsqlCommand(consulta, conn)
        dr = comm.ExecuteReader

        Try
            dtg_caixamov.Rows.Clear() : dtg_caixamov.Refresh()
            Dim usuario As String = ""
            Dim dentist As String = ""
            While dr.Read

                usuario = dr(5).ToString
                If dr(6).ToString.Equals("A") Then usuario = dr(7).ToString
                'dentist = dr(8).ToString
                'If dr(1).ToString.Equals("D") And (dr(10).ToString.Equals("") = False) Then
                '    dentist = dr(10).ToString
                'End If
                Dim mlinha As String() = {dr(0), False, dr(1).ToString, Format(Convert.ChangeType(dr(2), GetType(Date)), "dd/MM/yyyy"), dr(3).ToString, Format(dr(4), "###,##0.00"), _
                                          dr(8).ToString, usuario, dr(6).ToString, dr(9), dr(11).ToString}
                dtg_caixamov.Rows.Add(mlinha)
            End While
            dtg_caixamov.Refresh()

            txt_qtde.Text = dtg_caixamov.Rows.Count
            somaTotais()
            conn.Close()
            conn = Nothing
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
        ExecuteF5()

    End Sub

    Private Sub btn_pesquisa_Click(sender As Object, e As EventArgs) Handles btn_pesquisa.Click
        ExecuteF5()
    End Sub

    Private Sub btn_editar_Click(sender As Object, e As EventArgs) Handles btn_editar.Click

        Try

            If dtg_caixamov.CurrentRow.IsNewRow = False Then

                If dtg_caixamov.CurrentRow.Cells(9).Value Then

                    Dim LancaCxOrca As New Frm_LancaCxOrc
                    LancaCxOrca._idLancamento = dtg_caixamov.CurrentRow.Cells(0).Value
                    LancaCxOrca.btn_incluir.Enabled = False
                    LancaCxOrca.ShowDialog()
                    ExecuteF5()

                Else

                    Select Case Trim(dtg_caixamov.CurrentRow.Cells(2).Value)
                        Case "R", "P", "RA"

                            Dim LancaCX As New Frm_LancamentosCaixa
                            LancaCX._idLancamento = dtg_caixamov.CurrentRow.Cells(0).Value
                            LancaCX.btn_incluir.Enabled = False
                            LancaCX.ShowDialog()
                            ExecuteF5()

                    End Select
                End If 
            End If
        Catch ex As Exception
        End Try
        

    End Sub

    Private Sub btn_divisoria_Click(sender As Object, e As EventArgs) Handles btn_divisoria.Click

        Try

            If existMarcado() Then


                Dim LancaCxDiv As New Frm_LancamentoCaixaDiv
                LancaCxDiv._Dentista = _Dentista
                LancaCxDiv.valorMarcados = CDbl(txt_totMarcados.Text)
                LancaCxDiv.ShowDialog()
                ExecuteF5()

            Else

                If dtg_caixamov.CurrentRow.IsNewRow = False Then

                    Select Case dtg_caixamov.CurrentRow.Cells(2).Value
                        Case "R"

                            Dim LancaCxDiv As New Frm_LancamentoCaixaDiv
                            LancaCxDiv._idLancamento = dtg_caixamov.CurrentRow.Cells(0).Value
                            LancaCxDiv.ShowDialog()
                            ExecuteF5()

                    End Select

                End If

            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub dtg_caixamov_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_caixamov.CellClick

        Try
            If e.ColumnIndex = 1 Then

                If Me.dtg_caixamov.CurrentRow.Cells(1).Value Then
                    Me.dtg_caixamov.CurrentRow.Cells(1).Value = False
                Else
                    Me.dtg_caixamov.CurrentRow.Cells(1).Value = True
                End If

            End If
            somaTotaisMarcados()
        Catch ex As Exception
        End Try
        

    End Sub

    Sub ExecuteDel()

        Try
            If dtg_caixamov.CurrentRow.IsNewRow = False Then

                If MessageBox.Show("Deseja Realmente Deletar esse Registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


                    If dtg_caixamov.CurrentRow.Cells(2).Value.ToString.Equals("O") Then
                        _CxOrca.oc_id = dtg_caixamov.CurrentRow.Cells(0).Value
                        _CxOrcaDAO.delCX_Diario(_CxOrca, _Geno, MdlConexaoBD.conectionPadrao)
                    Else
                        _CX.cx_id = dtg_caixamov.CurrentRow.Cells(0).Value
                        _CxDAO.delCX_Diario(_CX, _Geno, MdlConexaoBD.conectionPadrao)
                    End If
                    
                    ExecuteF5()
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dtg_caixamov_KeyDown(sender As Object, e As KeyEventArgs) Handles dtg_caixamov.KeyDown

        If e.KeyCode = Keys.Delete Then
            ExecuteDel()
        End If

    End Sub

    Private Sub somaTotais()

        Dim msomaTotais As Double = 0.0
        For Each row As DataGridViewRow In Me.dtg_caixamov.Rows

            If row.IsNewRow = False Then

                Try
                    If Trim(row.Cells(2).Value.ToString).Equals("RA") Then Continue For
                    msomaTotais += row.Cells(5).Value
                Catch ex As Exception
                End Try
            End If


        Next

        txt_total.Text = "0,00"
        If msomaTotais > 0 Then
            Me.txt_total.Text = Format(msomaTotais, "###,##0.00")
        End If

    End Sub

    Private Sub somaTotaisMarcados()

        Dim msomaTotais As Double = 0.0
        For Each row As DataGridViewRow In Me.dtg_caixamov.Rows

            If row.IsNewRow = False Then

                Try
                    If row.Cells(1).Value Then msomaTotais += row.Cells(5).Value
                Catch ex As Exception
                End Try
            End If


        Next

        txt_totMarcados.Text = "0,00"
        If msomaTotais > 0 Then
            Me.txt_totMarcados.Text = Format(msomaTotais, "###,##0.00")
        End If

    End Sub

    Private Sub dtg_caixamov_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtg_caixamov.RowsAdded

        'If dtg_documentos.Rows(e.RowIndex).Cells(15).Value Then
        '    dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Underline)
        'End If

        Select Case Trim(dtg_caixamov.Rows(e.RowIndex).Cells(2).Value.ToString)
            Case "P"
                dtg_caixamov.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Case "D"
                dtg_caixamov.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.MediumBlue
            Case "R"
                dtg_caixamov.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Green
        End Select

    End Sub

    Function existMarcado() As Boolean

        For Each row As DataGridViewRow In dtg_caixamov.Rows
            If row.IsNewRow = False Then
                If row.Cells(1).Value Then Return True
            End If
        Next

        Return False
    End Function

    Private Sub chk_marcarTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chk_marcarTodos.CheckedChanged


        If chk_marcarTodos.Checked Then

            For Each row As DataGridViewRow In dtg_caixamov.Rows
                If row.IsNewRow = False Then
                    row.Cells(1).Value = True
                End If
            Next
        Else

            For Each row As DataGridViewRow In dtg_caixamov.Rows
                If row.IsNewRow = False Then
                    row.Cells(1).Value = False
                End If
            Next
        End If

        somaTotaisMarcados()

    End Sub

    Private Sub cbo_dentistas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_dentistas.SelectedIndexChanged

        Try
            If cbo_dentistas.SelectedIndex > 0 Then
                _DentistaDAO.trazDoutorLojaNome(cbo_dentistas.SelectedItem.ToString, _Geno, _Dentista)
            Else
                _Dentista.zeraValores()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_deletar_Click(sender As Object, e As EventArgs) Handles btn_deletar.Click
        ExecuteDel()
    End Sub

    Private Sub btn_orcamento_Click(sender As Object, e As EventArgs) Handles btn_orcamento.Click

        Dim LancaCxOrc As New Frm_LancaCxOrc
        LancaCxOrc.btn_alterar.Enabled = False
        LancaCxOrc.ShowDialog()
        ExecuteF5()

    End Sub

    Private Sub chk_lanca_orca_CheckedChanged(sender As Object, e As EventArgs) Handles chk_lanca_orca.CheckedChanged

        If chk_lanca_orca.Checked Then
            chk_orcamento.Checked = False : chk_orcamento.Enabled = False
        Else
            chk_orcamento.Checked = False : chk_orcamento.Enabled = True
        End If

        ExecuteF5()

    End Sub

    Private Sub chk_orcamento_CheckedChanged(sender As Object, e As EventArgs) Handles chk_orcamento.CheckedChanged
        ExecuteF5()
    End Sub

    Private Sub btn_convertOrca_Click(sender As Object, e As EventArgs) Handles btn_convertOrca.Click

        Try

            If dtg_caixamov.CurrentRow.IsNewRow = False Then

                If dtg_caixamov.CurrentRow.Cells(9).Value Then



                    Dim LancaCX As New Frm_LancamentoConvertOrca
                    LancaCX._idLancamento = dtg_caixamov.CurrentRow.Cells(0).Value
                    LancaCX.btn_incluir.Enabled = True
                    LancaCX.ShowDialog()
                    ExecuteF5()

                End If
            End If
        Catch ex As Exception
        End Try

    End Sub
End Class