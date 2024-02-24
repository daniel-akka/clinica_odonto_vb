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

Public Class Frm_LancadosManualR

    Dim _Geno As New Cl_Geno
    Dim _cliente As New Cl_Cadp001
    Dim _clFuncoes As New ClFuncoes
    Dim _clDoutorDAO As New Cl_DoutorDAO
    Dim _clCX_DiarioR As New Cl_CaixaDiarioR
    Dim _TpAtendimento As New Cl_TpAtendimento

    Dim _BuscaForn As New Frm_ClienteFornResp
    Public Shared _frmREf As New Frm_LancadosManualR

    Private Sub Frm_LancadosManualR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                ExecuteF5()
            Case Keys.F6
                ExecutaF6()
        End Select

    End Sub

    Private Sub Frm_LancadosManualR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        _clFuncoes.trazGenoSelecionado(MdlEmpresaUsu._codigo, _Geno)

        cbo_doutores = _clDoutorDAO.PreenchComboDoutoresPesq(_Geno, cbo_doutores, MdlConexaoBD.conectionPadrao)
        cbo_tpAtendimento = _TpAtendimento.DAO.PreenchComboTpAtendementoPesq(cbo_tpAtendimento, MdlConexaoBD.conectionPadrao)

        ExecuteF5()
    End Sub

    Private Sub txt_codPart_KeyDownExtracted()

        _frmREf = Me
        _BuscaForn.set_frmRef(Me)
        _BuscaForn.ShowDialog(Me)
        If Me.txt_codPart.Text.Equals("") Then Me.txt_nomePart.Focus() : txt_nomePart.Text = "" : _cliente.zeraValores() : Return

        Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()

        _clFuncoes.trazCadp001(Me.txt_codPart.Text, _cliente)
    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then


            If Me.txt_codpart.Text.Equals("") Then


                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    txt_codPart_KeyDownExtracted()

                Catch ex As Exception
                End Try

            Else  ' Consulta pelo codigo do cliente...


                If (Me.txt_codpart.TextLength > 5) AndAlso (e.KeyCode = Keys.Enter) Then 'Se retornar nada

                    If _clFuncoes.trazCadp001(Me.txt_codPart.Text, _cliente) Then

                        Dim lShouldReturn As Boolean
                        Me.txt_nomePart.Focus()
                        Me.txt_nomePart.SelectAll()
                        If lShouldReturn Then Return
                        lShouldReturn = Nothing

                    Else


                        'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                        Try
                            txt_codPart_KeyDownExtracted()

                        Catch ex As Exception
                        End Try

                    End If
                End If

            End If
        End If



    End Sub


    Sub ExecuteF5()
        preecheDtg_caixa()
        somaTotais()
    End Sub

    Function trazConsulta() As String

        Dim consulta As String = ""

        consulta = "SELECT cx_id, cx_tipo AS ""Tipo"", cx_data AS ""Emissao "", cx_descricao AS ""Descricao"", cx_valor AS ""Valor "", "
        consulta += "cx_codcli, cx_nomecli, cx_doutor, cx_status AS ""Stat"", cx_usu AS ""Usuario"" "
        consulta += "FROM " & _Geno.pEsquemaestab & ".caixadiario WHERE cx_loja= '" & _Geno.pCodig & "' "

        If MdlUsuarioLogando._codcaixa.Equals("") = False Then consulta += "AND cx_caixa = '" & MdlUsuarioLogando._codcaixa & "' "

        Try
            If cbo_doutores.SelectedIndex > 0 Then
                consulta += "AND cx_doutor = '" & cbo_doutores.SelectedItem.ToString & "' "
            End If
        Catch ex As Exception
        End Try

        Try
            If cbo_tipo.SelectedIndex > 0 Then
                consulta += "AND cx_tipo = '" & Mid(cbo_tipo.SelectedItem.ToString, 1, 1) & "' "
            End If
        Catch ex As Exception
        End Try

        Try
            If cbo_tipoPag.SelectedIndex > 0 Then
                consulta += "AND cx_tipopag = '" & cbo_tipoPag.SelectedItem.ToString & "' "
            End If
        Catch ex As Exception
        End Try

        Try
            If cbo_tpAtendimento.SelectedIndex > 0 Then
                consulta += "AND cx_tpatend_id = " & _TpAtendimento.tpa_id & " "
            End If
        Catch ex As Exception
        End Try

        If Me.txt_codPart.Text.Equals("") = False Then
            consulta += "AND cx_codcli = '" & _cliente.pCod & "' "
        End If

        If IsDate(dtp_inicial.Text) AndAlso IsDate(dtp_final.Text) Then
            consulta += "AND cx_data BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "' "
        End If
        consulta += "ORDER BY cx_data DESC"



        Return consulta
    End Function

    Function trazConsultaRelatorio() As String

        Dim consulta As String = ""

        consulta = "SELECT cx_tipo, cx_nomecli, cx_doutor, cx_descricao, cx_valor, Count(cx_tipo) "
        consulta += "FROM " & _Geno.pEsquemaestab & ".caixadiario "
        consulta += "GROUP BY cx_tipo, cx_nomecli, cx_doutor, cx_descricao, cx_valor, cx_data, cx_loja, cx_caixa, cx_tipopag "
        consulta += "HAVING cx_loja= '" & _Geno.pCodig & "' "

        If MdlUsuarioLogando._codcaixa.Equals("") = False Then consulta += "AND cx_caixa = '" & MdlUsuarioLogando._codcaixa & "' "

        Try
            If cbo_doutores.SelectedIndex > 0 Then
                consulta += "AND cx_doutor = '" & cbo_doutores.SelectedItem.ToString & "' "
            End If
        Catch ex As Exception
        End Try

        Try
            If cbo_tipo.SelectedIndex > 0 Then
                consulta += "AND cx_tipo = '" & Mid(cbo_tipo.SelectedItem.ToString, 1, 1) & "' "
            End If
        Catch ex As Exception
        End Try

        Try
            If cbo_tipoPag.SelectedIndex > 0 Then
                consulta += "AND cx_tipopag = '" & cbo_tipoPag.SelectedItem.ToString & "' "
            End If
        Catch ex As Exception
        End Try

        Try
            If cbo_tpAtendimento.SelectedIndex > 0 Then
                consulta += "AND cx_tpatend_id = " & _TpAtendimento.tpa_id & " "
            End If
        Catch ex As Exception
        End Try

        If Me.txt_codPart.Text.Equals("") = False Then
            consulta += "AND cx_codcli = '" & _cliente.pCod & "' "
        End If

        If IsDate(dtp_inicial.Text) AndAlso IsDate(dtp_final.Text) Then
            consulta += "AND cx_data BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "' "
        End If
        consulta += "ORDER BY cx_data DESC"



        Return consulta
    End Function

    Sub ExecutaF6()

        _clCX_DiarioR._Geno = _Geno
        Dim strConsulta As String = trazConsultaRelatorio()
        _clCX_DiarioR._dataInicial = dtp_inicial.Text
        _clCX_DiarioR._dataFinal = dtp_final.Text
        _clCX_DiarioR.ExecutaF6(strConsulta)

    End Sub

    Private Sub preecheDtg_caixa()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão:: " & ex.Message)
        End Try

        Dim strConsulta As String = trazConsulta()
        comm = New NpgsqlCommand(strConsulta, conn)
        dr = comm.ExecuteReader

        Try
            dtg_caixamov.Rows.Clear() : dtg_caixamov.Refresh()
            While dr.Read

                Dim mlinha As String() = {dr(0), dr(1).ToString, Format(Convert.ChangeType(dr(2), GetType(Date)), "dd/MM/yyyy"), dr(3).ToString, Format(dr(4), "###,##0.00"), _
                                          dr(5).ToString, dr(6).ToString, dr(7).ToString, dr(8).ToString, dr(9).ToString}
                dtg_caixamov.Rows.Add(mlinha)
            End While
            dtg_caixamov.Refresh()

            conn.Close()
            conn = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Private Sub btn_pesquisa_Click(sender As Object, e As EventArgs) Handles btn_pesquisa.Click
        ExecuteF5()
    End Sub

    Private Sub btn_Relatorio_Click(sender As Object, e As EventArgs) Handles btn_Relatorio.Click
        ExecutaF6()
    End Sub

    Private Sub somaTotais()

        Dim msomaTotais As Double = 0.0
        For Each row As DataGridViewRow In Me.dtg_caixamov.Rows

            If row.IsNewRow = False Then

                Try
                    msomaTotais += row.Cells(4).Value
                Catch ex As Exception
                End Try
            End If


        Next

        txt_totais.Text = "0,00"
        If msomaTotais > 0 Then
            Me.txt_totais.Text = Format(msomaTotais, "###,##0.00")
        End If

    End Sub

    Private Sub cbo_tpAtendimento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tpAtendimento.SelectedIndexChanged

        Try
            If cbo_tpAtendimento.SelectedIndex > 0 Then
                _TpAtendimento.DAO.trazTpAtendimentoDescr(cbo_tpAtendimento.SelectedItem.ToString, _TpAtendimento)
            Else
                _TpAtendimento.ZeraValores()
            End If
        Catch ex As Exception
        End Try

    End Sub

End Class