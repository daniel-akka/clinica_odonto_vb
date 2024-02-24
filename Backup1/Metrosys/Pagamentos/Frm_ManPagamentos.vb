Imports System
Imports Npgsql
Imports System.Data
Imports System.Text

Public Class Frm_ManPagamentos

    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes
    Private _clBD As New Cl_bdMetrosys
    Public _loja00 As String = ""
    Public Shared Frm_ManPagamentos As New Frm_ManPagamentos
    Public Shared Frm_ManDuplicadas As New Frm_Dup_ManDuplicatas

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        Dim RecebRegistro As New Frm_CadPagamento
        RecebRegistro._Incluindo = True
        RecebRegistro.ShowDialog()
        RecebRegistro = Nothing

    End Sub

    Private Sub Frm_ManPagamentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                If cbo_loja.SelectedIndex < _valorZERO Then
                    MsgBox("SLECIONE UMA LOJA", MsgBoxStyle.Exclamation)

                Else
                    consultaBD()

                End If

        End Select



    End Sub

    Private Sub Frm_ManPagamentos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub Frm_ManPagamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cbo_loja = _clFuncoes.PreenchComboLoja(cbo_loja, MdlConexaoBD.conectionPadrao)
        Me.cbo_loja.SelectedIndex = _valorZERO
        consultaBD()

    End Sub

    Private Sub btn_outros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_outros.Click

        If Me.cbo_loja.SelectedIndex < _valorZERO Then

            MessageBox.Show("Selecione uma Loja ", "Seleção de Loja", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_loja.Focus()

        Else

            Dim OutrosPagamentos As New Frm_OutrosPagamentos
            Frm_ManPagamentos = Me : OutrosPagamentos.ShowDialog()

        End If



    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click

        consultaBD()

    End Sub

    Private Sub consultaBD()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlDupl As New StringBuilder
        Dim cmdDupl As NpgsqlCommand
        Dim drDupl As NpgsqlDataReader
        Dim mdtEmiss As String, mdtVencto As String, mdias As Integer = _valorZERO
        Dim mValor As String = _valorZERO

        Try
            sqlDupl.Append("SELECT d_geno AS ""LOJA"", cad.p_portad AS ""PORTADOR"", d_tipo AS ""TIPO"", ") '2
            sqlDupl.Append("d_sit AS ""SIT"", d_banco AS ""BANCO"", d_duplic AS ""DOCUMENTO"", ") '5
            sqlDupl.Append("d_emiss AS ""EMISSAO"", d_vencto AS ""VENCTO"", d_valor AS ""VALOR"", ") '8
            sqlDupl.Append("d_juros AS ""JUROS"", 'dias' AS ""DIAS"" ") '10
            sqlDupl.Append("FROM fatp001 LEFT JOIN cadp001 cad ON d_portad = cad.p_cod ")
            sqlDupl.Append("WHERE d_geno = 'G00" & _loja00 & "' ")

            'Tratamento do período de Incio e Fim...
            If Me.cbo_tipo.SelectedIndex <> 5 Then
                If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                    sqlDupl.Append("AND d_emiss BETWEEN '" & Me.Msk_inicio.Text & "' ")
                    sqlDupl.Append("AND '" & Me.msk_fim.Text & "' ")

                End If
            End If


            'Tratamento do Tipo da Duplicata...
            Select Case Me.cbo_tipo.SelectedIndex
                Case 0 'Vencidas
                    sqlDupl.Append("AND d_vencto < @d_vencto ")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@d_vencto", Date.Now)

                Case 1 'Quitadas
                    sqlDupl.Append("AND UPPER(d_sit) = @d_sit ")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@d_sit", "L")

                Case 2 'Devolvidas
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)

                Case 3 'Estornadas
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)

                Case 4 'Em Aberto
                    sqlDupl.Append("AND UPPER(d_sit) = @d_sit ")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@d_sit", "N")

                Case 5 'Documento
                    sqlDupl.Append("AND CAST((CAST(SUBSTR(d_duplic, 1, (LENGTH(d_duplic) - 1)) AS INTEGER)) ")
                    sqlDupl.Append("AS TEXT) LIKE @d_duplic")

                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@d_duplic", Me.txt_documento.Text & "%")

                Case Else
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)

            End Select


            drDupl = cmdDupl.ExecuteReader
            Me.dtg_documentos.Rows.Clear() : Me.dtg_documentos.Refresh()

            While drDupl.Read

                Try
                    mdtEmiss = Format(CDate(drDupl(6)), "dd/MM/yyyy")
                Catch ex As Exception
                    mdtEmiss = ""
                End Try

                mdias = _valorZERO
                Try
                    mdtVencto = Format(CDate(drDupl(7)), "dd/MM/yyyy")

                    If CDate(mdtVencto) < Date.Now Then

                        mdias = Date.Now.Subtract(CDate(mdtVencto)).Days

                    End If

                Catch ex As Exception
                    mdtVencto = ""
                End Try

                Try
                    mValor = Format(drDupl(8), "###,##0.00")
                Catch ex As Exception
                    mValor = _valorZERO
                End Try


                dtg_documentos.Rows.Add(drDupl(0).ToString, drDupl(1).ToString, drDupl(2).ToString, _
                                        drDupl(3).ToString, drDupl(4).ToString, drDupl(5).ToString, _
                                        mdtEmiss, mdtVencto, mValor, _
                                        drDupl(9).ToString, mdias)

            End While

            drDupl.Close()
            Me.dtg_documentos.Refresh()
            'lbl_registros.Text = Me.dtg_documentos.Rows.Count
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)

        End Try

        sqlDupl.Remove(_valorZERO, sqlDupl.ToString.Length)

        'LIMPA OBJETOS DA MEMORIA...
        mdtEmiss = Nothing : mdtVencto = Nothing : mdias = Nothing : mValor = Nothing
        cmdDupl = Nothing : sqlDupl = Nothing : oConnBDMETROSYS.Close() : oConnBDMETROSYS = Nothing



    End Sub

    Private Sub cbo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tipo.SelectedIndexChanged

        If cbo_loja.SelectedIndex < _valorZERO Then

            MsgBox("SLECIONE UMA LOJA", MsgBoxStyle.Exclamation)

        Else
            consultaBD()

        End If


    End Sub

    Private Sub txt_documento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_documento.TextChanged

        If cbo_loja.SelectedIndex < _valorZERO Then

            MsgBox("SLECIONE UMA LOJA", MsgBoxStyle.Exclamation)

        Else
            consultaBD()

        End If



    End Sub

    Private Sub cbo_loja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_loja.SelectedIndexChanged

        _loja00 = Me.cbo_loja.SelectedItem.ToString.Substring(0, 2)
    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        Dim RecebRegistro As New Frm_CadPagamento
        RecebRegistro._Incluindo = False
        RecebRegistro.ShowDialog()
        RecebRegistro = Nothing

    End Sub
End Class