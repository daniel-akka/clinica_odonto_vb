Imports System
Imports System.Data
Imports System.Text
Imports Npgsql
Imports System.Math

Public Class Frm_Dup_ManDuplicatas

    'Objetos e Variáveis:
    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes
    Private _clBD As New Cl_bdMetrosys
    Private _geno001 As New Cl_Geno
    Public _loja00 As String = ""
    Public Shared Frm_ManDuplicadas As New Frm_Dup_ManDuplicatas
    Dim _diasVencidos As Integer = 0
    Dim _sitDoc As String = "N"
    Dim _clDoutorDAO As New Cl_DoutorDAO

    'Pagamento de Duplicata
    Public lojaDuplic As String = ""
    Public numDuplicata As String = ""
    Public valorDuplicata As Double = 0.0
    Public _idRecebimento As Int64 = 0

    'Pagamento Duplicatas Marcadas
    Dim mJuros, mDesconto, mvalor, msubtotal, mtotalgeral, mTaxa As Double
    Dim mDias, mCarencia As Integer
    Dim mPesqPortador As Boolean = False


    Private Sub Frm_Dup_ManDuplicatas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

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

    Private Sub Frm_Dup_ManDuplicatas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub Frm_Dup_ManDuplicatas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'thMarcados = New Thread(AddressOf somaMarcados)
        lbl_NomeSys.Text = Application.ProductName
        Me.cbo_loja = _clFuncoes.PreenchComboLoja2Dig(cbo_loja, MdlConexaoBD.conectionPadrao)
        Me.cbo_loja.SelectedIndex = _clFuncoes.trazIndexCboLoja2dig(MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2), cbo_loja)
        cbo_doutores = _clDoutorDAO.PreenchComboDoutoresPesq(_geno001, cbo_doutores, MdlConexaoBD.conectionPadrao)

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
        Dim mdtPagamento As String
        Dim mValor As String = _valorZERO
        Dim mJuros As String = 0
        txt_somaMarcados.Text = ""

        Try
            sqlDupl.Append("SELECT f_geno AS ""LOJA"", cad.p_portad AS ""PORTADOR"", f_tipo AS ""TIPO"", ") '2
            sqlDupl.Append("f_sit AS ""SIT"", f_banco AS ""BANCO"", f_duplic AS ""DOCUMENTO"", ") '5
            sqlDupl.Append("f_emiss AS ""EMISSAO"", f_vencto AS ""VENCTO"", f_valor AS ""VALOR"", ") '8
            sqlDupl.Append("f_juros AS ""JUROS"", 'dias' AS ""Dias Atrazo"", f_dtpaga AS ""Dt. Pagamento"", f_idx, f_hist, f_divisoria, f_despesa, f_nfat, ") '16
            sqlDupl.Append("cad.p_cod, f_doutor FROM " & _geno001.pEsquemaestab & ".fatd001 LEFT JOIN cadp001 cad ON f_portad = cad.p_cod ")
            sqlDupl.Append("WHERE f_geno = '" & _geno001.pCodig & "' ")

            'Tratamento do Dentista:
            If Me.cbo_doutores.SelectedIndex > 0 Then
                sqlDupl.Append("AND f_doutor LIKE '%" & Me.cbo_doutores.SelectedItem.ToString & "%' ")
            End If

            'Tratamento do período de Incio e Fim:
            If rdb_emiss.Checked Then

                If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                    sqlDupl.Append("AND f_emiss BETWEEN '" & Me.Msk_inicio.Text & "' ")
                    sqlDupl.Append("AND '" & Me.msk_fim.Text & "' ")

                End If
            ElseIf rdb_pagamento.Checked Then

                If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                    sqlDupl.Append("AND f_dtpaga BETWEEN '" & Me.Msk_inicio.Text & "' ")
                    sqlDupl.Append("AND '" & Me.msk_fim.Text & "' ")

                End If

            ElseIf rdb_vencimento.Checked Then

                If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                    sqlDupl.Append("AND f_vencto BETWEEN '" & Me.Msk_inicio.Text & "' ")
                    sqlDupl.Append("AND '" & Me.msk_fim.Text & "' ")

                End If
            End If



            'Tratamento do Nome Portador:
            If mPesqPortador Then

                If Trim(txt_portador.Text).Equals("") = False Then sqlDupl.Append("AND upper(cad.p_portad) LIKE @portad ")
            End If

            'Tratamento do Tipo da Duplicata:
            Select Case Me.cbo_tipo.SelectedIndex
                Case 0 'Vencidas
                    sqlDupl.Append("AND f_vencto < @f_vencto ")
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC LIMIT 500")

                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@f_vencto", Convert.ChangeType(Date.Now, GetType(Date)))
                    consultaTratamentoPortad(cmdDupl)

                Case 1 'Quitadas
                    sqlDupl.Append("AND UPPER(f_sit) = @f_sit ")
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC LIMIT 500")

                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@f_sit", "L")
                    consultaTratamentoPortad(cmdDupl)

                Case 2 'Devolvidas
                    sqlDupl.Append("AND UPPER(f_sit) = @f_sit ")
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC LIMIT 500")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@f_sit", "D")
                    consultaTratamentoPortad(cmdDupl)

                Case 3 'Estornadas
                    sqlDupl.Append("AND UPPER(f_sit) = @f_sit ")
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC LIMIT 500")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@f_sit", "E")
                    consultaTratamentoPortad(cmdDupl)

                Case 4 'Em Aberto
                    sqlDupl.Append("AND UPPER(f_sit) = @f_sit ")
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC LIMIT 500")

                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@f_sit", "N")
                    consultaTratamentoPortad(cmdDupl)

                Case 5 'Documento
                    sqlDupl.Append("AND CAST((CAST(SUBSTR(f_duplic, 1, (LENGTH(f_duplic) - 1)) AS INTEGER)) ")
                    sqlDupl.Append("AS TEXT) LIKE @f_duplic ")
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC LIMIT 500")

                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@f_duplic", Me.txt_documento.Text & "%")
                    consultaTratamentoPortad(cmdDupl)

                Case Else
                    sqlDupl.Append("ORDER BY f_duplic, f_emiss ASC LIMIT 500")
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
                                        drDupl(3).ToString, drDupl(18).ToString, drDupl(5).ToString, _
                                        mdtEmiss, mValor, mdtVencto, mJuros, mdias, mdtPagamento, drDupl(12), _
                                        drDupl(13).ToString, drDupl(14), drDupl(15), drDupl(16).ToString, drDupl(17).ToString, drDupl(4).ToString)

            End While

            drDupl.Close()
            Me.dtg_documentos.Refresh()
            somaValor()
            somaMarcados()
            lbl_registros.Text = Me.dtg_documentos.Rows.Count
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

            MsgBox("SELECIONE UMA LOJA", MsgBoxStyle.Exclamation)

        Else
            consultaBD()

        End If


    End Sub

    Private Sub cbo_loja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_loja.SelectedIndexChanged
        _loja00 = cbo_loja.SelectedItem.ToString.Substring(0, 2)
        _clFuncoes.trazGenoSelecionado("G00" & _loja00, _geno001)
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

        lbl_mensagem.Text = "" : _idRecebimento = 0
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
                        valorDuplicata = dtg_documentos.CurrentRow.Cells(8).Value
                        _idRecebimento = dtg_documentos.CurrentRow.Cells(13).Value

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

            End Select


        End If

    End Sub

    Private Sub dtg_documentos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_documentos.CellClick

        If e.ColumnIndex = 0 Then

            If Me.dtg_documentos.CurrentRow.Cells(0).Value Then
                Me.dtg_documentos.CurrentRow.Cells(0).Value = False
            Else
                Me.dtg_documentos.CurrentRow.Cells(0).Value = True
            End If

            somaMarcados()
        End If

    End Sub


    Private Sub somaValor()

        Dim msomaValores As Double = 0.0
        For Each row As DataGridViewRow In Me.dtg_documentos.Rows

            If row.IsNewRow = False Then

                Try
                    msomaValores += row.Cells(8).Value
                Catch ex As Exception
                End Try
            End If


        Next

        txt_somaMarcados.Text = ""
        If msomaValores > 0 Then
            Me.txt_totais.Text = Format(msomaValores, "###,##0.00")
        End If

    End Sub

    Private Sub somaMarcados()

        Dim msomaMarcados As Double = 0.0
        For Each row As DataGridViewRow In Me.dtg_documentos.Rows

            If row.IsNewRow = False Then

                If row.Cells(0).Value Then

                    Try
                        msomaMarcados += row.Cells(8).Value
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

                MsgBox("SELECIONE UMA LOJA", MsgBoxStyle.Exclamation)

            Else
                consultaBD()

            End If

        End If

    End Sub

    Function ExistPago() As Boolean

        For Each row As DataGridViewRow In dtg_documentos.Rows

            If row.IsNewRow = False Then
                If row.Cells(0).Value AndAlso row.Cells(4).Value.ToString.Equals("L") Then Return True
            End If
        Next
        Return False
    End Function

    Private Sub btn_baixaMarcados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_baixaMarcados.Click

        Try
            Dim msg As String = "Deseja realmente Baixar todo os Marcados?"
            If ExistPago() Then
                msg = "Algum(s) ou Todos os Selecionado já foram Baixados! Deseja Continuar?"
            End If


            lbl_mensagem.Text = "" : _idRecebimento = 0
            If CDec(txt_somaMarcados.Text) > 0 Then

                If MessageBox.Show(msg, "Baixa Total de Documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
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
                _idRecebimento = row.Cells(13).Value
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
            strSQL.Append("f_dtpaga = @f_dtpaga, f_juros = @f_juros, f_desc = @f_desc, f_sit = @f_sit WHERE ")
            If _idRecebimento > 0 Then
                strSQL.Append("f_idx=" & _idRecebimento & "")
            Else
                strSQL.Append("f_duplic='" & Ndupl.ToString & "' and f_geno='G00" & cbo_loja.SelectedItem.ToString.Substring(0, 2) & "'")
            End If


            oCmd = New NpgsqlCommand(strSQL.ToString, conexao)
            oCmd.Transaction = transacao
            'Juros = 0.0 : Desconto = 0.0
            ValorPago = Round((Juros - Desconto) + ValorDup, 2)
            If ValorPago > ValorDup Then
                Juros = Round(ValorPago - ValorDup, 2)
            ElseIf ValorPago <= ValorDup Then
                Juros = 0.0 : Desconto = 0.0
            End If

            oCmd.Parameters.Add("@f_dtpaga", Convert.ChangeType(DTPaga, GetType(Date)))
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


        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim DrDup As NpgsqlDataReader

        Sqlcomm.Append("SELECT F.f_geno,F.f_duplic,F.f_valor,F.f_portad,C.p_portad,C.p_cod ,F.f_vencto,F.f_tipo,F.f_emiss FROM ")
        Sqlcomm.Append(MdlEmpresaUsu._esqEstab & ".fatd001 F LEFT JOIN Cadp001 C ON C.p_cod = F.f_portad  WHERE ") '5
        If _idRecebimento > 0 Then
            Sqlcomm.Append("F.f_idx=" & _idRecebimento & "")
        Else
            Sqlcomm.Append("F.f_duplic='" & documento & "' AND F.f_portad=C.p_cod AND F.f_geno='G00" & cbo_loja.SelectedItem.ToString.Substring(0, 2) & "'")
        End If


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

    Private Sub cbo_loja_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_loja.Leave

        If cbo_loja.SelectedIndex = -1 Then

            MessageBox.Show("Selecione Loja !", "Loja ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.cbo_loja.Focus()
        Else

            Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim Sqlcomm As StringBuilder = New StringBuilder
            Dim DrCont As NpgsqlDataReader

            Sqlcomm.Append("SELECT gp_geno, gp_txcob, gp_carencia FROM genp001 WHERE gp_geno='G00" & Mid(cbo_loja.SelectedItem, 1, 2) & "'") '5
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

    Private Sub txt_portador_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_portador.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            mPesqPortador = True : consultaBD() : mPesqPortador = False
        End If

    End Sub

    Private Sub dtg_documentos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtg_documentos.RowsAdded

        If dtg_documentos.Rows(e.RowIndex).Cells(15).Value Then
            dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Underline)
        End If

        Select Case _sitDoc
            Case "L"
                dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.MediumBlue
            Case "D"
                dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Green
            Case "E"
                dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.MediumOrchid
            Case "N"
                If _diasVencidos > 0 Then dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End Select


    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click

        Try

            lbl_mensagem.Text = "" : _idRecebimento = 0
            If dtg_documentos.CurrentRow.IsNewRow = False Then

                _idRecebimento = dtg_documentos.CurrentRow.Cells(13).Value
                Dim RecebRegistro As New Frm_CadRecebimentos
                RecebRegistro._idRecebimento = _idRecebimento
                RecebRegistro._Incluindo = False
                RecebRegistro.ShowDialog()
                RecebRegistro = Nothing

            Else
                lbl_mensagem.Text = "Selecione um documento para Alterar !"
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_divisoria_Click(sender As Object, e As EventArgs) Handles btn_divisoria.Click

        Dim sim As Boolean = True
        Dim vlMarcados As Double = 0.0
        If dtg_documentos.CurrentRow.Cells(4).Value.ToString.Equals("L") = False Then
            MsgBox("Duplicata ainda não foi Quitada!") : Return
        End If


        Try
            vlMarcados = CDbl(txt_somaMarcados.Text)
            If vlMarcados > 0 Then sim = False
        Catch ex As Exception
        End Try


        If sim Then
            If dtg_documentos.CurrentRow.Cells(15).Value AndAlso dtg_documentos.CurrentRow.Cells(16).Value Then

                If MessageBox.Show("Duplicata já foi DIVIDIDA e LANÇADA C/ DESPESA! Deseja continuar assim mesmo?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.No Then
                    Return
                End If
                sim = False
            End If
        End If


        If sim Then
            If dtg_documentos.CurrentRow.Cells(15).Value Then

                If MessageBox.Show("Duplicata já foi DIVIDIDA! Deseja continuar assim mesmo?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.No Then
                    Return
                End If
                sim = False
            End If
        End If


        If sim Then
            If dtg_documentos.CurrentRow.Cells(16).Value Then

                If MessageBox.Show("Duplicata já foi LANÇADA C/ DESPESA! Deseja continuar assim mesmo?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.No Then
                    Return
                End If
                sim = False
            End If
        End If


        'Dim LancaCxDiv As New Frm_LancamentoCaixaDiv
        Dim LancaCxDivD As New Frm_LancaCX_DivD
        _idRecebimento = dtg_documentos.CurrentRow.Cells(13).Value
        If vlMarcados > 0 Then
            LancaCxDivD.valorDupl = vlMarcados
        Else
            LancaCxDivD.codCliente = dtg_documentos.CurrentRow.Cells(18).Value.ToString
            LancaCxDivD.nomeCliente = dtg_documentos.CurrentRow.Cells(2).Value.ToString
            LancaCxDivD.idDuplic = dtg_documentos.CurrentRow.Cells(6).Value.ToString
            LancaCxDivD.valorDupl = dtg_documentos.CurrentRow.Cells(8).Value
        End If
        
        LancaCxDivD.ShowDialog()


        If vlMarcados > 0 Then consultaBD() : Return
        If LancaCxDivD.incluiuDiv OrElse LancaCxDivD.incluiuDesp Then 'Se tiver incluido Div ou Desp:


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
                If LancaCxDivD.incluiuDiv Then AltDivisoriaDupl(conexao, transacao)
                If LancaCxDivD.incluiuDesp Then AltDespesaDupl(conexao, transacao)
                transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
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

        End If 'FIM do incluido Div ou Desp:



    End Sub

    Private Sub AltDivisoriaDupl(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim oCmd As NpgsqlCommand
        Dim Mconsulta As Boolean = False

        Dim strSQL As New StringBuilder
        Try
            strSQL.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".fatd001 SET ")
            strSQL.Append("f_divisoria = @f_divisoria WHERE ")
            If _idRecebimento > 0 Then
                strSQL.Append("f_idx=" & _idRecebimento & "")
            End If


            oCmd = New NpgsqlCommand(strSQL.ToString, conexao)
            oCmd.Transaction = transacao
            oCmd.Parameters.Add("@f_divisoria", True)

            oCmd.CommandText = strSQL.ToString
            oCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try


    End Sub

    Private Sub btn_lancarDespesa_Click(sender As Object, e As EventArgs) Handles btn_lancarDespesa.Click


        If dtg_documentos.CurrentRow.Cells(4).Value.ToString.Equals("L") = False Then
            MsgBox("Duplicata ainda não foi Quitada!") : Return
        End If

        If dtg_documentos.CurrentRow.Cells(16).Value Then

            If MessageBox.Show("Duplicata já foi LANÇADA! Deseja continuar assim mesmo?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                = Windows.Forms.DialogResult.No Then
                Return
            End If

        End If

        Dim LancaCxDiv As New Frm_LancaCxDesp
        _idRecebimento = dtg_documentos.CurrentRow.Cells(13).Value
        LancaCxDiv.idDuplicata = dtg_documentos.CurrentRow.Cells(6).Value.ToString
        LancaCxDiv.valorDupl = dtg_documentos.CurrentRow.Cells(8).Value
        LancaCxDiv.ShowDialog()

        If LancaCxDiv.incluiu Then 'Se tiver incluido:


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
                AltDespesaDupl(conexao, transacao)
                transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
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



    End Sub

    Private Sub AltDespesaDupl(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim oCmd As NpgsqlCommand
        Dim Mconsulta As Boolean = False

        Dim strSQL As New StringBuilder
        Try
            strSQL.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".fatd001 SET ")
            strSQL.Append("f_despesa = @f_despesa WHERE ")
            If _idRecebimento > 0 Then
                strSQL.Append("f_idx=" & _idRecebimento & "")
            End If


            oCmd = New NpgsqlCommand(strSQL.ToString, conexao)
            oCmd.Transaction = transacao
            oCmd.Parameters.Add("@f_despesa", True)

            oCmd.CommandText = strSQL.ToString
            oCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try


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
            strSQL.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 WHERE f_idx = " & id)
            oCmd = New NpgsqlCommand(strSQL.ToString, conexao)
            oCmd.Transaction = transacao
            oCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try


    End Sub

    Private Sub cbo_doutores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_doutores.SelectedIndexChanged

        Try
            consultaBD()
        Catch ex As Exception
        End Try

    End Sub
End Class