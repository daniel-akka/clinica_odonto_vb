Imports System
Imports Npgsql
Imports System.Data
Imports System.Text
Imports System.Math

Public Class Frm_ManPagamentos

    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes
    Private _clBD As New Cl_bdMetrosys
    Public _geno001 As New Cl_Geno
    Public Shared Frm_ManPagamentos As New Frm_ManPagamentos
    Public Shared Frm_ManDuplicadas As New Frm_Dup_ManDuplicatas

    'Pagamento de Duplicata
    Public lojaDuplic As String = ""
    Public numDuplicata As String = ""
    Public valorDuplicata As Double = 0.0
    Public IdPagamento As Int64 = 0

    'Pagamento Duplicatas Marcadas
    Dim mJuros, mDesconto, mvalor, msubtotal, mtotalgeral, mTaxa As Double
    Dim mDias, mCarencia As Integer
    Dim mSit As String = "N"

    'Variáveis Gerais:
    Dim mPesqPortador As Boolean = False
    Public _loja00 As String = ""
    Dim _diasVencidos As Integer = 0
    Dim _diasAvencer As Integer = 0
    Dim _sitDoc As String = "N"

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        Dim RecebRegistro As New Frm_CadPagamento
        RecebRegistro._Incluindo = True
        RecebRegistro.ShowDialog()
        RecebRegistro = Nothing
        consultaBD()

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
        Try


            IdPagamento = 0
            If dtg_documentos.CurrentRow.IsNewRow Then
                lbl_mensagem.Text = "Por favor Selecione um Documento !"
            Else

                Select Case dtg_documentos.CurrentRow.Cells(4).Value.ToString
                    Case "L"
                        lbl_mensagem.Text = "Duplicata já foi PAGA !"
                    Case "D"
                        lbl_mensagem.Text = "Duplicata foi DEVOLVIDA !"
                    Case "E"
                        lbl_mensagem.Text = "Duplicata foi ESTORNADA !"
                    Case "N"
                        Try
                            lojaDuplic = dtg_documentos.CurrentRow.Cells(1).Value.ToString
                            numDuplicata = dtg_documentos.CurrentRow.Cells(6).Value.ToString
                            valorDuplicata = dtg_documentos.CurrentRow.Cells(9).Value
                            IdPagamento = dtg_documentos.CurrentRow.Cells(13).Value

                            Dim BaixaInd As New Frm_PagamentoIndividual
                            BaixaInd.formManDuplicRecebimento = Me
                            BaixaInd.ShowDialog()
                            BaixaInd.Dispose()
                            consultaBD()

                        Catch ex As Exception
                            MsgBox("ERRO:: " & ex.Message)
                        Finally
                            zeraValoresPagamento()
                        End Try

                End Select


            End If

        Catch ex As Exception
        End Try

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

    Private Sub btn_baixaMarcados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_baixaMarcados.Click

        Try
            If CDec(txt_somaMarcados.Text) > 0 Then

                If MessageBox.Show("Deseja realmente Baixar todo os Marcados?", "Baixa Total de Documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                = Windows.Forms.DialogResult.Yes Then



                    IdPagamento = 0
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
                IdPagamento = row.Cells(13).Value
                mSit = row.Cells(4).Value.ToString
                If row.Cells(0).Value Then

                    trazValoresDocumentoPagamento(numDoc, IdPagamento)
                    Baixa_dupIndividual_Total(IdPagamento, numDoc, "T", Date.Now, mJuros, mDesconto, mvalor, _
                                    msubtotal, conexao, transacao)
                End If
            End If
        Next

    End Sub

    Private Sub Baixa_dupIndividual_Total(ByVal id As Int64, ByVal Ndupl As String, ByVal TipoPgto As String, ByVal DTPaga As Date, ByVal Juros As Double, _
                      ByVal Desconto As Double, ByVal ValorPago As Double, ByVal ValorDup As Double, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim oCmd As NpgsqlCommand
        Dim Mconsulta As Boolean = False

        Dim strSQL As New StringBuilder
        Try
            strSQL.Append("UPDATE fatp001 SET ")
            strSQL.Append("d_dtpaga = @d_dtpaga, d_juros = @d_juros, d_desc = @d_desc, d_sit = @d_sit, d_sitanterior = @d_sitanterior ")
            strSQL.Append("WHERE d_id=" & id & "")
            'strSQL.Append("WHERE d_duplic='" & Ndupl.ToString & "' AND d_geno='" & _geno001.pCodig & "'")

            oCmd = New NpgsqlCommand(strSQL.ToString, conexao)
            oCmd.Transaction = transacao
            'Juros = 0.0 : Desconto = 0.0
            ValorPago = Round((Juros - Desconto) + ValorDup, 2)
            If ValorPago > ValorDup Then
                Juros = Round(ValorPago - ValorDup, 2)
            ElseIf ValorPago <= ValorDup Then
                Juros = 0.0 : Desconto = 0.0
            End If

            oCmd.Parameters.Add("@d_dtpaga", Convert.ChangeType(DTPaga, GetType(Date)))
            oCmd.Parameters.Add("@d_juros", Juros)
            oCmd.Parameters.Add("@d_desc", Desconto)
            oCmd.Parameters.Add("@d_sit", "L")
            oCmd.Parameters.Add("@d_sitanterior", mSit)

            oCmd.CommandText = strSQL.ToString
            oCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try


    End Sub

    Private Sub trazValoresDocumentoPagamento(ByVal documento As String, ByVal id As Int64)

       
            Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim Sqlcomm As StringBuilder = New StringBuilder
            Dim DrDup As NpgsqlDataReader

        Sqlcomm.Append("SELECT F.d_geno,F.d_duplic,F.d_valor,F.d_portad,C.p_portad,C.p_cod ,F.d_vencto,F.d_tipo,F.d_emiss FROM ")
        Sqlcomm.Append("fatp001 F LEFT JOIN Cadp001 C ON C.p_cod = F.d_portad  WHERE F.d_id=" & id & " ") '5
        'Sqlcomm.Append("fatp001 F LEFT JOIN Cadp001 C ON C.p_cod = F.d_portad  WHERE F.d_geno='" & _geno001.pCodig & "' AND ") '5
        'Sqlcomm.Append("F.d_duplic='" & documento & "'")

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


    End Sub

    Private Sub Frm_ManPagamentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                If cbo_loja.SelectedIndex < _valorZERO Then
                    MsgBox("SELECIONE UMA LOJA", MsgBoxStyle.Exclamation)

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

        lbl_NomeSys.Text = Application.ProductName
        Me.cbo_loja = _clFuncoes.PreenchComboLoja2Dig(cbo_loja, MdlConexaoBD.conectionPadrao)
        Me.cbo_loja.SelectedIndex = _clFuncoes.trazIndexCboLoja2dig(MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2), cbo_loja)
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

    Sub consultaTratamentoPortad(ByRef cmd As NpgsqlCommand)

        If mPesqPortador Then

            If Trim(txt_portador.Text).Equals("") = False Then cmd.Parameters.Add("@portad", Trim(Me.txt_portador.Text.ToUpper) & "%")
        End If

    End Sub

    Private Sub consultaBD()


        lbl_mensagem.Text = ""
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
        Dim mdtPagamento As String = ""
        Dim mJuros As String = 0

        Try
            sqlDupl.Append("SELECT d_geno AS ""LOJA"", cad.p_portad AS ""PORTADOR"", d_tipo AS ""TIPO"", ") '2
            sqlDupl.Append("d_sit AS ""SIT"", d_banco AS ""BANCO"", d_duplic AS ""DOCUMENTO"", ") '5
            sqlDupl.Append("d_emiss AS ""EMISSAO"", d_vencto AS ""VENCTO"", d_valor AS ""VALOR"", ") '8
            sqlDupl.Append("d_juros AS ""JUROS"", 'dias' AS ""DIAS"", d_dtpaga AS ""Data Pag."", d_id, d_hist AS ""HISTORICO"" ") '13
            sqlDupl.Append("FROM fatp001 LEFT JOIN cadp001 cad ON d_portad = cad.p_cod ")
            sqlDupl.Append("WHERE d_geno = '" & _geno001.pCodig & "' ")

            'Tratamento do período de Incio e Fim...
            If Me.cbo_tipo.SelectedIndex <> 5 Then
                If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                    sqlDupl.Append("AND d_emiss BETWEEN '" & Me.Msk_inicio.Text & "' ")
                    sqlDupl.Append("AND '" & Me.msk_fim.Text & "' ")

                End If
            End If

            'Tratamento do Nome Portador:
            If mPesqPortador Then

                If Trim(txt_portador.Text).Equals("") = False Then sqlDupl.Append("AND upper(cad.p_portad) LIKE @portad ")
            End If

            'Tratamento do Tipo da Duplicata...
            Select Case Me.cbo_tipo.SelectedIndex
                Case 0 'Vencidas
                    sqlDupl.Append("AND d_vencto < @d_vencto ORDER BY d_duplic ASC, d_dtpaga DESC LIMIT 5000")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@d_vencto", Convert.ChangeType(Date.Now, GetType(Date)))
                    consultaTratamentoPortad(cmdDupl)

                Case 1 'Quitadas
                    sqlDupl.Append("AND UPPER(d_sit) = @d_sit ORDER BY d_duplic ASC, d_dtpaga DESC LIMIT 5000")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@d_sit", "L")
                    consultaTratamentoPortad(cmdDupl)

                Case 2 'Devolvidas
                    sqlDupl.Append("AND UPPER(d_sit) = @d_sit ORDER BY d_duplic ASC, d_dtpaga DESC LIMIT 5000")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@d_sit", "D")
                    consultaTratamentoPortad(cmdDupl)

                Case 3 'Estornadas
                    sqlDupl.Append("AND UPPER(d_sit) = @d_sit ORDER BY d_duplic ASC, d_dtpaga DESC LIMIT 5000")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@d_sit", "E")
                    consultaTratamentoPortad(cmdDupl)

                Case 4 'Em Aberto
                    sqlDupl.Append("AND UPPER(d_sit) = @d_sit ORDER BY d_duplic ASC, d_dtpaga DESC LIMIT 5000")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@d_sit", "N")
                    consultaTratamentoPortad(cmdDupl)

                Case 5 'Documento
                    sqlDupl.Append("AND CAST((CAST(SUBSTR(d_duplic, 1, (LENGTH(d_duplic) - 1)) AS INTEGER)) ")
                    sqlDupl.Append("AS TEXT) LIKE @d_duplic ORDER BY d_duplic ASC, d_dtpaga DESC LIMIT 5000")

                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@d_duplic", Me.txt_documento.Text & "%")
                    consultaTratamentoPortad(cmdDupl)

                Case Else
                    sqlDupl.Append("ORDER BY d_duplic ASC, d_dtpaga DESC LIMIT 5000")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    consultaTratamentoPortad(cmdDupl)

            End Select


            drDupl = cmdDupl.ExecuteReader
            Me.dtg_documentos.Rows.Clear() : Me.dtg_documentos.Refresh()
            _diasVencidos = 0 : _sitDoc = "N"

            While drDupl.Read

                Try
                    mdtEmiss = Format(Convert.ChangeType(drDupl(6), GetType(Date)), "dd/MM/yyyy")
                Catch ex As Exception
                    mdtEmiss = ""
                End Try

                mdias = _valorZERO
                Try
                    mdtVencto = Format(Convert.ChangeType(drDupl(7), GetType(Date)), "dd/MM/yyyy")

                    If Convert.ChangeType(mdtVencto, GetType(Date)) < Date.Now Then

                        mdias = Date.Now.Subtract(Convert.ChangeType(mdtVencto, GetType(Date))).Days

                    End If

                Catch ex As Exception
                    mdtVencto = ""
                End Try
                _diasVencidos = mdias

                Try
                    _diasAvencer = 0
                    If Convert.ChangeType(mdtVencto, GetType(Date)) > Date.Now Then

                        _diasAvencer = Convert.ChangeType(mdtVencto, GetType(Date)).Subtract(Date.Now).Days
                    End If

                Catch ex As Exception
                End Try


                Try
                    mValor = Format(drDupl(8), "###,##0.00")
                Catch ex As Exception
                    mValor = _valorZERO
                End Try

                If IsDate(drDupl(11)) Then
                    mdtPagamento = Format(Convert.ChangeType(drDupl(11), GetType(Date)), "dd/MM/yyyy")
                Else
                    mdtPagamento = ""
                End If

                Try
                    mJuros = Format(drDupl(9), "###,##0.00")
                Catch ex As Exception
                    mJuros = _valorZERO
                End Try

                _sitDoc = drDupl(3).ToString

                dtg_documentos.Rows.Add(False, drDupl(0).ToString, drDupl(1).ToString, drDupl(2).ToString, _
                                        drDupl(3).ToString, drDupl(4).ToString, drDupl(5).ToString, _
                                        mdtEmiss, mdtVencto, mValor, mJuros, mdias, mdtPagamento, drDupl(12), drDupl(13).ToString)

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

    Sub SomaTotais()

        Dim mSoma As Double = 0.0
        For Each row As DataGridViewRow In dtg_documentos.Rows
            If row.IsNewRow = False Then
                mSoma = dtg_documentos.Rows(row.Index).Cells(9).Value
            End If
        Next

        txt_totais.Text = Format(mSoma, "###,##0.00")
    End Sub

    Private Sub cbo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tipo.SelectedIndexChanged

        If cbo_loja.SelectedIndex < _valorZERO Then

            MsgBox("SELECIONE UMA LOJA", MsgBoxStyle.Exclamation)

        Else
            consultaBD()

        End If


    End Sub

    Private Sub txt_documento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_documento.TextChanged

        If cbo_loja.SelectedIndex < _valorZERO Then

            MsgBox("SELECIONE UMA LOJA", MsgBoxStyle.Exclamation)

        Else
            consultaBD()

        End If



    End Sub

    Private Sub cbo_loja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_loja.SelectedIndexChanged

        _loja00 = Me.cbo_loja.SelectedItem.ToString.Substring(0, 2)
        _clFuncoes.trazGenoSelecionado("G00" & _loja00, _geno001)
    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        Try

            lbl_mensagem.Text = "" : IdPagamento = 0
            If dtg_documentos.CurrentRow.IsNewRow = False Then

                If dtg_documentos.CurrentRow.Cells(4).Value.ToString.Equals("N") Then

                    IdPagamento = dtg_documentos.CurrentRow.Cells(13).Value
                    Dim PagamentoRegistro As New Frm_CadPagamento
                    PagamentoRegistro._idPagamento = IdPagamento
                    PagamentoRegistro._Incluindo = False
                    PagamentoRegistro.ShowDialog()
                    PagamentoRegistro = Nothing
                    consultaBD()

                Else
                    lbl_mensagem.Text = "Alteração somente para parcelas em situação NORMAL !"
                End If

                

            Else
                lbl_mensagem.Text = "Selecione um documento para Alterar !"
            End If
        Catch ex As Exception
        End Try


    End Sub

    Private Sub txt_portador_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_portador.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            mPesqPortador = True : consultaBD() : mPesqPortador = False
        End If

    End Sub

    Private Sub dtg_documentos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtg_documentos.RowsAdded


        Select Case _sitDoc
            Case "L"
                dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.MediumBlue
            Case "D"
                dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Green
            Case "E"
                dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.MediumOrchid
            Case "N"

                If _diasAvencer < 6 Then dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Maroon
                If _diasVencidos > 0 Then dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red


        End Select


    End Sub

    Private Sub dtg_documentos_KeyDown(sender As Object, e As KeyEventArgs) Handles dtg_documentos.KeyDown

        Try

            If e.KeyCode <> Keys.Delete Then Return
            If dtg_documentos.CurrentRow.IsNewRow = False Then

                If MessageBox.Show("Deseja Realmente Deletar esse Registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                    Dim mId As Int64 = dtg_documentos.CurrentRow.Cells(13).Value
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
                        DeletaDupl(mId, conexao, transacao)
                        transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                        MsgBox("Registro Deletado com Sucesso!")
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
                    End Try

                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub DeletaDupl(ByVal id As Int64, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim oCmd As NpgsqlCommand
        Dim Mconsulta As Boolean = False

        Dim strSQL As New StringBuilder
        Try
            strSQL.Append("DELETE FROM fatp001 WHERE d_id = " & id)
            oCmd = New NpgsqlCommand(strSQL.ToString, conexao)
            oCmd.Transaction = transacao
            oCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try


    End Sub


End Class