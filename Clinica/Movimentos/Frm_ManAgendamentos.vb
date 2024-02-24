Imports System
Imports System.Data
Imports System.Text
Imports Npgsql
Imports System.Math
Imports System.Linq

Public Class Frm_ManAgendamentos

    'Objetos e Variáveis:
    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes
    Private _clBD As New Cl_bdMetrosys
    Private _geno001 As New Cl_Geno
    Private _cliente As New Cl_Cadp001
    Private _agend1 As New Cl_Agendamento1
    Private _agendDAO As New Cl_AgendamentosDAO
    Dim _clDoutorDAO As New Cl_DoutorDAO
    Private _AgendRelatorio As New Cl_AgendamentosR
    Public _loja00 As String = ""
    Public Shared Frm_ManAgendamentos As New Frm_ManAgendamentos
    Dim _diasVencimento As Integer = 0
    Dim _sitDoc As String = "N"
    Dim _agendRealizado As Boolean = False
    Dim _agendCancelado As Boolean = False
    Dim _turnoC As String = "Manhã"

    'Pagamento de Duplicata
    Public lojaDuplic As String = ""
    Public numDuplicata As String = ""
    Public valorDuplicata As Double = 0.0
    Public _idRecebimento As Int64 = 0
    Public _numAgendamento As Int64 = 0

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

            Case Keys.F6
                'ExecutaF6()
            Case Keys.F11
                ExecutaF11()
        End Select



    End Sub

    Sub ExecutaF6()

        Try

            If dtg_documentos.CurrentRow.IsNewRow = False Then

                _agend1.a_id = dtg_documentos.CurrentRow.Cells(1).Value
                _cliente.pCod = dtg_documentos.CurrentRow.Cells(3).Value.ToString
                _clFuncoes.trazCadp001(_cliente.pCod, _cliente)
                _agendDAO.trazAgendamento1(_agend1.a_id, _geno001, _agend1)

                _AgendRelatorio._Geno = _geno001
                _AgendRelatorio._Cliente = _cliente
                _AgendRelatorio._Agend1 = _agend1

                _AgendRelatorio.executaF6()

            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub NomeTurno(turno As String)

        Select Case turno
            Case "M"
                Me._turnoC = "Manhã"
            Case "T"
                Me._turnoC = "Tarde"
            Case "N"
                Me._turnoC = "Noite"
        End Select
    End Sub

    Sub ExecutaF11()

        Try

            If dtg_documentos.Rows.Count > 0 Then


                Dim mConsulta As String = TrazSQL_Consulta()

                _AgendRelatorio._Geno = _geno001
                _AgendRelatorio.ExecutaF11(mConsulta, Msk_inicio.Text, msk_fim.Text)

            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Frm_Dup_ManDuplicatas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub Frm_Dup_ManDuplicatas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        'thMarcados = New Thread(AddressOf somaMarcados)
        Me.cbo_loja = _clFuncoes.PreenchComboLoja2Dig(cbo_loja, MdlConexaoBD.conectionPadrao)
        Me.cbo_loja.SelectedIndex = _clFuncoes.trazIndexCboLoja2dig(MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2), cbo_loja)
        cbo_dentistas = _clDoutorDAO.PreenchComboDoutoresPesq(_geno001, cbo_dentistas, MdlConexaoBD.conectionPadrao)

        consultaBD()

    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click

        consultaBD()

    End Sub

    Sub consultaTratamentoPortad(ByRef cmd As NpgsqlCommand)

        If mPesqPortador Then

            If Trim(txt_portador.Text).Equals("") = False Then cmd.Parameters.Add("@portad", Trim(Me.txt_portador.Text.ToUpper) & "%")
        End If

    End Sub

    Function TrazSQL_Consulta() As String

        Dim sql As String = ""
        Dim dtEmiss As Boolean = False

        sql = "SELECT a_id, cad.p_portad, a_doutor, a_dtagend, a_valor, a_cancelado, Count(a_id), a_dtemis, a_status "
        sql += "FROM " & _geno001.pEsquemaestab & ".tb_agend1, cadp001 cad "
        sql += "GROUP BY a_id, cad.p_portad, a_doutor, a_dtagend, a_valor, a_cancelado, a_codig, cad.p_cod, a_dtemis, a_status "
        sql += "HAVING a_codig = cad.p_cod "


        'Tratamento do período de Incio e Fim:
        If Me.cbo_tipo.SelectedIndex <> 5 Then
            If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                sql += "AND a_dtemis BETWEEN '" & Me.Msk_inicio.Text & "' "
                sql += "AND '" & Me.msk_fim.Text & "' "

            End If
        End If

        'Tratamento do Nome Portador:
        If Trim(txt_portador.Text).Equals("") = False Then sql += "AND upper(cad.p_portad) LIKE '" & txt_portador.Text & "%'"

        'Tratamento do Tipo da Duplicata:
        Select Case Me.cbo_tipo.SelectedIndex
            Case 0 'Em ABERTO
                sql += "AND a_status = false "
                sql += "ORDER BY a_id, a_dtemis ASC LIMIT 500"

            Case 1 'Realizadas
                sql += "AND a_status = true "
                sql += "ORDER BY a_id, a_dtemis ASC LIMIT 500"

            Case 2 'Vencidas
                sql += "AND a_dtagend < '" & Format(Date.Now, "dd/MM/yyyy") & "' ORDER BY a_id, a_dtemis ASC LIMIT 500"

            Case Else
                sql += "ORDER BY a_id, a_dtemis ASC LIMIT 500"

        End Select


        Return sql
    End Function

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
        Dim mdtPagamento, mdtVenctoAux As String
        Dim mValor As String = _valorZERO
        Dim mJuros As String = 0
        Dim mWhere As Boolean = False

        Try

            sqlDupl.Append("SELECT a_id, a_status, cad.p_portad, a_codig, a_dtemis, a_dtagend, a_iddoutor, a_doutor, ") '7
            sqlDupl.Append("a_valor, a_cancelado, a_financeiro, cad.p_ficha, a_turno, a_info, a_paciente FROM " & _geno001.pEsquemaestab & ".tb_agend1 LEFT OUTER JOIN ")
            sqlDupl.Append("cadp001 cad ON a_codig = cad.p_cod ")

            'Tratamento do período de Incio e Fim:
            If Me.cbo_tipo.SelectedIndex <> 5 Then
                If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                    sqlDupl.Append("WHERE a_dtagend BETWEEN '" & Me.Msk_inicio.Text & "' ")
                    sqlDupl.Append("AND '" & Me.msk_fim.Text & "' ")
                    mWhere = True
                End If
            End If

            'Tratamento dos Dentistas:
            If cbo_dentistas.SelectedIndex > 0 Then

                If mWhere Then
                    sqlDupl.Append("AND upper(a_doutor) LIKE '" & cbo_dentistas.SelectedItem.ToString.ToUpper & "' ")
                Else
                    sqlDupl.Append("WHERE upper(a_doutor) LIKE '" & cbo_dentistas.SelectedItem.ToString.ToUpper & "' ")
                    mWhere = True
                End If
            End If

            'Tratamento doS TURNOS:
            If cbo_turno.SelectedIndex > 0 Then

                If mWhere Then
                    sqlDupl.Append("AND upper(a_turno) LIKE '" & Mid(cbo_turno.SelectedItem.ToString, 1, 1).ToUpper & "' ")
                Else
                    sqlDupl.Append("WHERE upper(a_turno) LIKE '" & Mid(cbo_turno.SelectedItem.ToString, 1, 1).ToUpper & "' ")
                    mWhere = True
                End If
            End If

            'Tratamento do Nome Portador:
            If mPesqPortador Then

                If mWhere Then
                    If Trim(txt_portador.Text).Equals("") = False Then sqlDupl.Append("AND upper(cad.p_portad) LIKE @portad ")
                Else
                    If Trim(txt_portador.Text).Equals("") = False Then sqlDupl.Append("WHERE upper(cad.p_portad) LIKE @portad ")
                    mWhere = True
                End If

            End If


            'Tratamento do Tipo da Duplicata:
            Select Case Me.cbo_tipo.SelectedIndex
                Case 0 'Em ABERTO
                    If mWhere Then
                        sqlDupl.Append("AND a_status = @a_status ")
                    Else
                        sqlDupl.Append("WHERE a_status = @a_status ")
                        mWhere = True
                    End If

                    sqlDupl.Append("ORDER BY a_id, a_dtemis ASC LIMIT 500")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@a_status", False)
                    consultaTratamentoPortad(cmdDupl)

                Case 1 'Realizadas
                    If mWhere Then
                        sqlDupl.Append("AND a_status = @a_status ")
                    Else
                        sqlDupl.Append("WHERE a_status = @a_status ")
                        mWhere = True
                    End If

                    sqlDupl.Append("ORDER BY a_id, a_dtemis ASC LIMIT 500")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@a_status", True)
                    consultaTratamentoPortad(cmdDupl)

                Case 2 'Vencidas
                    If mWhere Then
                        sqlDupl.Append("AND a_dtagend < @a_dtagend ")
                    Else
                        sqlDupl.Append("WHERE a_dtagend < @a_dtagend ")
                        mWhere = True
                    End If

                    sqlDupl.Append("ORDER BY a_id, a_dtemis ASC LIMIT 500")

                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    cmdDupl.Parameters.Add("@a_dtagend", Convert.ChangeType(Date.Now, GetType(Date)))
                    consultaTratamentoPortad(cmdDupl)

                Case Else
                    sqlDupl.Append("ORDER BY a_id, a_dtemis ASC LIMIT 500")
                    cmdDupl = New NpgsqlCommand(sqlDupl.ToString, oConnBDMETROSYS)
                    consultaTratamentoPortad(cmdDupl)

            End Select



            drDupl = cmdDupl.ExecuteReader
            Me.dtg_documentos.Rows.Clear() : Me.dtg_documentos.Refresh()
            _diasVencimento = 0 : _sitDoc = "N"

            While drDupl.Read

                Try
                    mdtEmiss = Format(Convert.ChangeType(drDupl(4), GetType(Date)), "dd/MM/yyyy")
                Catch ex As Exception
                    mdtEmiss = ""
                End Try

                Try
                    mdtVencto = Format(Convert.ChangeType(drDupl(5), GetType(Date)), "dd/MM/yyyy")
                    mdtVenctoAux = Format(Date.Now, "dd/MM/yyyy")
                    _diasVencimento = 0
                    _diasVencimento = DateTime.Compare(Convert.ChangeType(mdtVencto, GetType(Date)), Convert.ChangeType(mdtVenctoAux, GetType(Date)))
                Catch ex As Exception
                    mdtVencto = ""
                End Try

                Try
                    mValor = Format(drDupl(8), "###,##0.00")
                Catch ex As Exception
                    mValor = _valorZERO
                End Try

                _agendRealizado = drDupl(1)
                _agendCancelado = drDupl(9)

                NomeTurno(drDupl(12).ToString)

                dtg_documentos.Rows.Add(drDupl(1), drDupl(0), drDupl(11).ToString, drDupl(3).ToString, drDupl(14).ToString, _
                                        mdtEmiss, mdtVencto, mValor, drDupl(7).ToString, drDupl(9), drDupl(10), drDupl(13).ToString, _turnoC)

            End While

            drDupl.Close()
            Me.dtg_documentos.Refresh()
            SomaTotais()
            txt_qtdRegistros.Text = dtg_documentos.Rows.Count
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

        Dim frmAgenda As New Frm_Agendamentos
        frmAgenda.ShowDialog()
        consultaBD()

    End Sub

    Private Sub zeraValoresPagamento()
        lojaDuplic = "" : numDuplicata = "" : valorDuplicata = 0.0
    End Sub

    Private Sub zeraValoresPagMarcados()
        mJuros = 0.0 : mDesconto = 0.0 : mvalor = 0.0 : msubtotal = 0.0
        mtotalgeral = 0.0 : mTaxa = 0.0 : mDias = 0 : mCarencia = 0
    End Sub

    Sub SomaTotais()

        Dim msomaMarcados As Double = 0.0
        For Each row As DataGridViewRow In Me.dtg_documentos.Rows

            If row.IsNewRow = False Then

                Try
                    msomaMarcados += row.Cells(7).Value
                Catch ex As Exception
                End Try
            End If

        Next

    End Sub

    Private Sub txt_documento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Enter Then

            If cbo_loja.SelectedIndex < _valorZERO Then

                MsgBox("SELECIONE UMA LOJA", MsgBoxStyle.Exclamation)

            Else
                consultaBD()

            End If

        End If

    End Sub

    Function ValidaRegistro() As Boolean

        'Se já tiver confirmado:
        If dtg_documentos.CurrentRow.Cells(0).Value Then MsgBox("Registro já foi Confirmado", MsgBoxStyle.Exclamation) : Return False
        'Se já tiver cancelado:
        If dtg_documentos.CurrentRow.Cells(9).Value Then MsgBox("Registro já foi Cancelado", MsgBoxStyle.Exclamation) : Return False

        Return True
    End Function

    Function ValidaRegistroFinan() As Boolean

        'Se já tiver confirmado:
        If dtg_documentos.CurrentRow.Cells(0).Value = False Then MsgBox("Agendamento ainda não foi confirmado", MsgBoxStyle.Exclamation) : Return False
        'Se já tiver cancelado:
        If dtg_documentos.CurrentRow.Cells(9).Value Then MsgBox("Registro já foi Cancelado", MsgBoxStyle.Exclamation) : Return False
        'Se já tiver lançado no Financeiro:
        If dtg_documentos.CurrentRow.Cells(10).Value Then
            Dim mId As Int64 = dtg_documentos.CurrentRow.Cells(1).Value
            Dim mNumFatura As String = ""
            mNumFatura = _clBD.trazNumFatd001_Por_Agendamento(mId, _geno001, MdlConexaoBD.conectionPadrao)
            MsgBox("Registro já foi Lançado no Financeiro! Num. da Fatura """ & mNumFatura & """", MsgBoxStyle.Exclamation) : Return False
        End If


        Return True
    End Function

    Private Sub btn_baixaMarcados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click

        Try


            If dtg_documentos.CurrentRow.IsNewRow = False Then

                If ValidaRegistro() = False Then Return

                lbl_mensagem.Text = "" : _idRecebimento = 0
                If MessageBox.Show("Deseja realmente Confirma?", "Confirmação de Agendamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


                    Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Dim transacao As NpgsqlTransaction
                    _numAgendamento = dtg_documentos.CurrentRow.Cells(1).Value
                    If _numAgendamento < 1 Then Return

                    Try
                        conexao.Open()
                    Catch ex As Exception
                        MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
                        Return

                    End Try

                    Try
                        transacao = conexao.BeginTransaction
                        ConfirmarAgendamento(_numAgendamento, conexao, transacao)
                        transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                        MsgBox("Confirmação Efetuada com Sucesso !", MsgBoxStyle.Exclamation, "METROSYS")
                        _numAgendamento = 0
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

    Private Sub ConfirmarAgendamento(ByVal Ndupl As Int64, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim oCmd As NpgsqlCommand
        Dim Mconsulta As Boolean = False

        Dim strSQL As New StringBuilder
        Try
            strSQL.Append("UPDATE " & _geno001.pEsquemaestab & ".tb_agend1 SET a_status = True WHERE a_id = " & Ndupl)

            oCmd = New NpgsqlCommand(strSQL.ToString, conexao)
            oCmd.Transaction = transacao
            oCmd.CommandText = strSQL.ToString
            oCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try


    End Sub

    Private Sub CancelarAgendamento(ByVal Ndupl As Int64, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim oCmd As NpgsqlCommand
        Dim Mconsulta As Boolean = False

        Dim strSQL As New StringBuilder
        Try
            strSQL.Append("UPDATE " & _geno001.pEsquemaestab & ".tb_agend1 SET a_cancelado = True WHERE a_id = " & Ndupl)

            oCmd = New NpgsqlCommand(strSQL.ToString, conexao)
            oCmd.Transaction = transacao
            oCmd.CommandText = strSQL.ToString
            oCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
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

        If _agendRealizado Then dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.MediumBlue : Return
        If _agendCancelado Then dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Strikeout) : Return
        If _diasVencimento = 0 Then dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Green : Return
        If _diasVencimento < 0 Then dtg_documentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red : Return


    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click

        Try

            If ValidaRegistro() = False Then Return

            lbl_mensagem.Text = "" : _idRecebimento = 0
            If dtg_documentos.CurrentRow.IsNewRow = False Then

                _numAgendamento = dtg_documentos.CurrentRow.Cells(1).Value
                Dim RecebRegistro As New Frm_AgendamentoAlt
                Frm_ManAgendamentos = Me
                RecebRegistro.Geno01 = _geno001
                RecebRegistro.ShowDialog()
                RecebRegistro = Nothing
                consultaBD()

            Else
                lbl_mensagem.Text = "Selecione um documento para Alterar !"
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_imprime_Click(sender As Object, e As EventArgs) Handles btn_imprime.Click
        ExecutaF6()
    End Sub

    Private Sub btn_relatorio_Click(sender As Object, e As EventArgs) Handles btn_relatorio.Click
        ExecutaF11()
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click

        Try


            If dtg_documentos.CurrentRow.IsNewRow = False Then

               If ValidaRegistro = False then Return

                lbl_mensagem.Text = "" : _idRecebimento = 0
                If MessageBox.Show("Deseja realmente Cancelar?", "Confirmação de Agendamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


                    Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Dim transacao As NpgsqlTransaction
                    _numAgendamento = dtg_documentos.CurrentRow.Cells(1).Value
                    If _numAgendamento < 1 Then Return

                    Try
                        conexao.Open()
                    Catch ex As Exception
                        MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
                        Return

                    End Try

                    Try
                        transacao = conexao.BeginTransaction
                        CancelarAgendamento(_numAgendamento, conexao, transacao)
                        transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                        MsgBox("Cancelado com Sucesso !", MsgBoxStyle.Exclamation, "METROSYS")
                        _numAgendamento = 0
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

    Private Sub btn_lancarFinanceiro_Click(sender As Object, e As EventArgs) Handles btn_lancarFinanceiro.Click


        Try

            lbl_mensagem.Text = ""
            If dtg_documentos.CurrentRow.IsNewRow = False Then

                If ValidaRegistroFinan() = False Then Return
                _agend1.a_id = dtg_documentos.CurrentRow.Cells(1).Value
                _cliente.pCod = dtg_documentos.CurrentRow.Cells(3).Value.ToString
                _clFuncoes.trazCadp001(_cliente.pCod, _cliente)
                _agendDAO.trazAgendamento1(_agend1.a_id, _geno001, _agend1)

                Dim mDrDAO As New Cl_DoutorDAO
                Dim mAgendFinan As New Frm_AgendFinanceiro
                mAgendFinan._Geno = _geno001
                mAgendFinan._clAgend1 = _agend1
                mAgendFinan._Cliente = _cliente
                mDrDAO.trazDoutorLojaNome(_agend1.a_doutor, _geno001, mAgendFinan._Dentista)
                mAgendFinan.ShowDialog()
                consultaBD()

            End If
        Catch ex As Exception
        End Try

    End Sub

End Class