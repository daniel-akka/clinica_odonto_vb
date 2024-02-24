Imports System
Imports System.Data
Imports System.Text
Imports Npgsql
Imports System.Math

Public Class Frm_Dup_ManDuplicatas

    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes
    Private _clBD As New Cl_bdMetrosys
    Public _loja00 As String = ""
    Public Shared Frm_ManDuplicadas As New Frm_Dup_ManDuplicatas

    'Pagamento de Duplicata
    Public lojaDuplic As String = ""
    Public numDuplicata As String = ""
    Public valorDuplicata As Double = 0.0

    'Pagamento Duplicatas Marcadas
    Dim mJuros, mDesconto, mvalor, msubtotal, mtotalgeral, mTaxa As Double
    Dim mDias, mCarencia As Integer


    Private Sub Frm_Dup_ManDuplicatas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

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

    Private Sub Frm_Dup_ManDuplicatas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub Frm_Dup_ManDuplicatas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'thMarcados = New Thread(AddressOf somaMarcados)
        Me.cbo_loja = _clFuncoes.PreenchComboLoja(cbo_loja, MdlConexaoBD.conectionPadrao)
        Me.cbo_loja.SelectedIndex = _valorZERO
        consultaBD()

    End Sub

    Private Sub btn_outros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_outros.Click

        If Me.cbo_loja.SelectedIndex < _valorZERO Then

            MessageBox.Show("Selecione uma Loja ", "Seleção de Loja", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_loja.Focus()

        Else

            Dim OutrosDuplic As New Frm_Dup_OutrosMovimentos
            Frm_ManDuplicadas = Me : OutrosDuplic.ShowDialog()

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
        Dim mdtPagamento As String
        Dim mValor As String = _valorZERO

        Try
            sqlDupl.Append("SELECT f_geno AS ""LOJA"", cad.p_portad AS ""PORTADOR"", f_tipo AS ""TIPO"", ") '2
            sqlDupl.Append("f_sit AS ""SIT"", f_banco AS ""BANCO"", f_duplic AS ""DOCUMENTO"", ") '5
            sqlDupl.Append("f_emiss AS ""EMISSAO"", f_vencto AS ""VENCTO"", f_valor AS ""VALOR"", ") '8
            sqlDupl.Append("f_juros AS ""JUROS"", 'dias' AS ""Dias Atrazo"", f_dtpaga AS ""Dt. Pagamento"" ") '11
            sqlDupl.Append("FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 LEFT JOIN cadp001 cad ON f_portad = cad.p_cod ")
            sqlDupl.Append("WHERE f_geno = 'G00" & _loja00 & "' ")

            'Tratamento do período de Incio e Fim...
            If Me.cbo_tipo.SelectedIndex <> 5 Then
                If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                    sqlDupl.Append("AND f_emiss BETWEEN '" & Me.Msk_inicio.Text & "' ")
                    sqlDupl.Append("AND '" & Me.msk_fim.Text & "' ")

                End If
            End If


            'Tratamento do Tipo da Duplicata...
            Select Case Me.cbo_tipo.SelectedIndex
                Case 0 'Vencidas
                    sqlDupl.Append("AND f_vencto < @f_vencto ")
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC")

                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@f_vencto", Date.Now)

                Case 1 'Quitadas
                    sqlDupl.Append("AND UPPER(f_sit) = @f_sit ")
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC")

                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@f_sit", "L")

                Case 2 'Devolvidas
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)

                Case 3 'Estornadas
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)

                Case 4 'Em Aberto
                    sqlDupl.Append("AND UPPER(f_sit) = @f_sit ")
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC")

                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@f_sit", "N")

                Case 5 'Documento
                    sqlDupl.Append("AND CAST((CAST(SUBSTR(f_duplic, 1, (LENGTH(f_duplic) - 1)) AS INTEGER)) ")
                    sqlDupl.Append("AS TEXT) LIKE @f_duplic ")
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC")

                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@f_duplic", Me.txt_documento.Text & "%")

                Case Else
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC")
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

                Try
                    mdtPagamento = Format(CDate(drDupl(11)), "dd/MM/yyyy")
                Catch ex As Exception
                    mdtPagamento = ""
                End Try


                dtg_documentos.Rows.Add(False, drDupl(0).ToString, drDupl(1).ToString, drDupl(2).ToString, _
                                        drDupl(3).ToString, drDupl(4).ToString, drDupl(5).ToString, _
                                        mdtEmiss, mdtVencto, mValor, drDupl(9).ToString, mdias, _
                                        mdtPagamento)

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

    Private Sub cbo_loja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_loja.SelectedIndexChanged
        _loja00 = cbo_loja.SelectedItem.ToString.Substring(0, 2)
    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click
        Dim RecebRegistro As New Frm_CadRecebimentos
        RecebRegistro.ShowDialog()
    End Sub

    Private Sub zeraValoresPagamento()
        lojaDuplic = "" : numDuplicata = "" : valorDuplicata = 0.0
    End Sub

    Private Sub zeraValoresPagMarcados()
        mJuros = 0.0 : mDesconto = 0.0 : mvalor = 0.0 : msubtotal = 0.0
        mtotalgeral = 0.0 : mTaxa = 0.0 : mDias = 0 : mCarencia = 0
    End Sub

    Private Sub btn_pagamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pagamento.Click

        lbl_mensagem.Text = ""
        If dtg_documentos.CurrentRow.IsNewRow Then
            lbl_mensagem.Text = "Por favor Selecione um Documento !"
        Else

            If dtg_documentos.CurrentRow.Cells(3).Value.ToString.Equals("L") Then

                lbl_mensagem.Text = "Duplicata já foi PAGA !"
            Else

                Try
                    lojaDuplic = dtg_documentos.CurrentRow.Cells(1).Value.ToString
                    lojaDuplic = lojaDuplic.Substring(lojaDuplic.Length - 2, 2)
                    numDuplicata = dtg_documentos.CurrentRow.Cells(6).Value.ToString
                    valorDuplicata = dtg_documentos.CurrentRow.Cells(9).Value

                    Dim BaixaInd As New Frm_Dup_BaixaIndividual
                    BaixaInd.formManDuplicRecebimento = Me
                    BaixaInd.ShowDialog()
                    BaixaInd.Dispose()
                    consultaBD()

                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message)
                Finally
                    zeraValoresPagamento()
                End Try

            End If


        End If

    End Sub

    Private Sub dtg_documentos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_documentos.CellClick

        If e.ColumnIndex = 0 Then

            If Me.dtg_documentos.CurrentRow.Cells(4).Value.ToString.Equals("N") Then

                If Me.dtg_documentos.CurrentRow.Cells(0).Value Then
                    Me.dtg_documentos.CurrentRow.Cells(0).Value = False
                Else
                    Me.dtg_documentos.CurrentRow.Cells(0).Value = True
                End If

                somaMarcados()
            End If

        End If

    End Sub

    Private Sub somaMarcados()

        Dim msomaMarcados As Double = 0.0
        For Each row As DataGridViewRow In Me.dtg_documentos.Rows

            If row.IsNewRow = False Then

                If row.Cells(0).Value Then

                    Try
                        msomaMarcados += row.Cells(9).Value
                    Catch ex As Exception
                    End Try
                End If

            End If


        Next

        txt_somaMarcados.Text = ""
        If msomaMarcados > 0 Then
            Me.txt_somaMarcados.Text = Format(msomaMarcados, "###,##0.00")
        End If

    End Sub

    Private Sub txt_documento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_documento.KeyDown

        If e.KeyCode = Keys.Enter Then

            If cbo_loja.SelectedIndex < _valorZERO Then

                MsgBox("SLECIONE UMA LOJA", MsgBoxStyle.Exclamation)

            Else
                consultaBD()

            End If

        End If

    End Sub

    Private Sub btn_baixaMarcados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_baixaMarcados.Click

        Try
            If CDec(txt_somaMarcados.Text) > 0 Then

                If MessageBox.Show("Deseja realmente Baixar todo os Marcados?", "Baixa Total de Documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                = Windows.Forms.DialogResult.Yes Then




                    Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Dim transacao As NpgsqlTransaction

                    Try
                        conexao.Open()
                    Catch ex As Exception
                        MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
                        Return

                    End Try

                    Try
                        transacao = conexao.BeginTransaction
                        baixaTotalDocumentos(conexao, transacao)
                        transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                        MsgBox("Baixa de Documentos Efetuadas com Sucesso !", MsgBoxStyle.Exclamation, "METROSYS")

                        consultaBD()
                    Catch ex As NpgsqlException

                        transacao.Rollback()
                        MsgBox(ex.Message.ToString)
                    Catch ex As Exception


                        Try
                            transacao.Rollback()
                        Catch ex2 As Exception
                            MsgBox(ex2.Message.ToString)
                        End Try

                        MsgBox(ex.Message.ToString)
                    Finally
                        conexao = Nothing : transacao = Nothing
                        zeraValoresPagMarcados()
                    End Try


                    

                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub baixaTotalDocumentos(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim numDoc As String = ""
        For Each row As DataGridViewRow In Me.dtg_documentos.Rows

            If row.IsNewRow = False Then

                numDoc = row.Cells(6).Value.ToString
                If row.Cells(0).Value Then

                    trazValoresDocumento(numDoc)
                    Baixa_dupIndividual_Total(numDoc, "T", Date.Now, mJuros, mDesconto, mvalor, _
                                    msubtotal, conexao, transacao)
                End If
            End If
        Next

    End Sub

    Private Sub Baixa_dupIndividual_Total(ByVal Ndupl As String, ByVal TipoPgto As String, ByVal DTPaga As Date, ByVal Juros As Double, _
                      ByVal Desconto As Double, ByVal ValorPago As Double, ByVal ValorDup As Double, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim oCmd As NpgsqlCommand
        Dim Mconsulta As Boolean = False

        Dim strSQL As New StringBuilder
        Try
            strSQL.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".fatd001 SET ")
            strSQL.Append("f_dtpaga = @f_dtpaga, f_juros = @f_juros, f_desc = @f_desc, f_sit = @f_sit ")
            strSQL.Append("WHERE f_duplic='" & Ndupl.ToString & "' and f_geno='G00" & cbo_loja.SelectedItem.ToString.Substring(0, 2) & "'")

            oCmd = New NpgsqlCommand(strSQL.ToString, conexao)
            oCmd.Transaction = transacao
            'Juros = 0.0 : Desconto = 0.0
            ValorPago = Round((Juros - Desconto) + ValorDup, 2)
            If ValorPago > ValorDup Then
                Juros = Round(ValorPago - ValorDup, 2)
            ElseIf ValorPago <= ValorDup Then
                Juros = 0.0 : Desconto = 0.0
            End If

            oCmd.Parameters.Add("@f_dtpaga", DTPaga)
            oCmd.Parameters.Add("@f_juros", Juros)
            oCmd.Parameters.Add("@f_desc", Desconto)
            oCmd.Parameters.Add("@f_sit", "L")

            oCmd.CommandText = strSQL.ToString
            oCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try


    End Sub

    Private Sub trazValoresDocumento(ByVal documento As String)

        If txt_documento.Text <> "" Then

            Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim Sqlcomm As StringBuilder = New StringBuilder
            Dim DrDup As NpgsqlDataReader

            Sqlcomm.Append("Select F.f_geno,F.f_duplic,F.f_valor,F.f_portad,C.p_portad,C.p_cod ,F.f_vencto,F.f_tipo,F.f_emiss from " & MdlEmpresaUsu._esqEstab & ".fatd001 F LEFT JOIN Cadp001 C ON C.p_cod = F.f_portad  where ") '5
            Sqlcomm.Append("F.f_duplic='" & documento & "' and F.f_portad=C.p_cod and F.f_geno='G00" & cbo_loja.SelectedItem.ToString.Substring(0, 2) & "'")
            Dim daDup As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
            Dim dsDup As DataSet = New DataSet()

            Dim cmd As NpgsqlCommand = New NpgsqlCommand(Sqlcomm.ToString, conn)
            cmd.CommandText = Sqlcomm.ToString
            Dim dtDup As DataTable = New DataTable
            Dim mVencto As Date
            Dim mdif, mJurosdia As Double

            Try
                conn.Open()
                dtDup.Load(cmd.ExecuteReader())    ' Carrega o datatable para memoria
                DrDup = cmd.ExecuteReader          ' Executa leitura do commando

                While (DrDup.Read())
                    msubtotal = DrDup(2)
                    mtotalgeral = DrDup(2)  ' SOMA COM JUROS
                    mVencto = DrDup(6)
                    mDias = DateDiff(DateInterval.Day, DateValue(mVencto), Now) ' Calcula a diferença em dias entre data atual e Vencimento
                    If mDias <= 5 Then mDias = 0
                    mdif = (Convert.ToInt64(msubtotal * mTaxa))    ' Calcula Valor de Juros Ao Mês
                    Try
                        mJurosdia = (Convert.ToInt64(mdif / 30)) / 100                            ' Calcula Vlr. Juros ao Dia
                    Catch ex As Exception
                        mJurosdia = 0.0
                    End Try

                    mJuros = (mJurosdia * mDias)                        ' Calcular Total de Juros Acumulados
                End While
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If

    End Sub

    Private Sub cbo_loja_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_loja.Leave

        If cbo_loja.SelectedIndex = -1 Then

            MessageBox.Show("Selecione Loja !", "Loja ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.cbo_loja.Focus()
        Else

            Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim Sqlcomm As StringBuilder = New StringBuilder
            Dim DrCont As NpgsqlDataReader

            Sqlcomm.Append("SELECT gp_geno, gp_txcob, gp_carencia FROM genp001 where gp_geno='G00" & Mid(cbo_loja.SelectedItem, 1, 2) & "'") '5
            Dim daCont As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
            Dim dsContp As DataSet = New DataSet()

            Dim cmd As NpgsqlCommand = New NpgsqlCommand(Sqlcomm.ToString, conn)
            cmd.CommandText = Sqlcomm.ToString
            Dim dtCont As DataTable = New DataTable

            Try
                conn.Open()
                dtCont.Load(cmd.ExecuteReader())   ' Carrega o datatable para memoria
                DrCont = cmd.ExecuteReader          ' Executa leitura do commando
                While (DrCont.Read())
                    mTaxa = CDbl(DrCont(1))
                    mCarencia = Convert.ToInt32(DrCont(2))

                End While
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If


    End Sub

End Class