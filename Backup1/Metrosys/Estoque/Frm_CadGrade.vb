Imports System.Text
Imports System.Math
Imports Npgsql

Public Class Frm_CadGrade
    Private Const _valorZERO As Integer = 0
    Dim _clBD As New Cl_bdMetrosys
    Dim _clFuncoes As New ClFuncoes
    Public local_Ref As String = Mid(MdlEmpresaUsu._codigo, MdlEmpresaUsu._codigo.Length - 1)

    Public _incluindo As Boolean
    Public mSaldoInicialEstoqueProd As Double = 0
    Dim qtdeFinal As Double = 0
    Dim mSomaSaldoas As Double = 0

    Dim _alterando As Boolean
    Dim _objGrade As New Cl_Grade
    Dim _idGrade As Int64

    Public Shared _frmREf As New Frm_CadGrade
    Dim _BuscaProd As New Frm_BuscaProdMp
    Public codProd_Ref, nomeProd_Ref, cdBarraProd_Ref As String


    Private Sub txt_Codigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codProd.KeyPress

        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_qtde_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtde.KeyPress

        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub cbo_cores_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_cores.GotFocus
        If cbo_cores.DroppedDown = False Then cbo_cores.DroppedDown = True
    End Sub

    Private Sub Form_CadGrade_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Form_CadGrade_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbo_cores = _clFuncoes.PreenchComboCoresGrade(cbo_cores, MdlConexaoBD.conectionPadrao)
        executaF5()
        If _incluindo Then

            _incluindo = True : _alterando = False
            tbc_Grade.SelectTab(1) : Me.txt_nomeProd.Focus()
            txt_codProd.Text = codProd_Ref
            txt_nomeProd.Text = nomeProd_Ref
            txt_qtde.Text = CInt(mSaldoInicialEstoqueProd)
        End If


    End Sub

    Private Sub consultaBD()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim nomeCampo As String = "", nomeCampoAux As String = ""

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim tamanhos As String = "", nomeColuna As String = "", indexColuna As Integer = 0
        Dim tamanhos2 As String = "", marray As Array

        Try
            'Limpa o DataGrideWiew...
            Me.Dtg_grade.Rows.Clear() : Me.Dtg_grade.Columns.Clear() : Me.Dtg_grade.Refresh()

            'Consulta...
            sql.Append("SELECT DISTINCT eg.e_tm ")
            sql.Append("FROM " & MdlEmpresaUsu._esqVinc & ".estgrade eg LEFT JOIN " & MdlEmpresaUsu._esqVinc)
            sql.Append(".est0001 e ON e.e_codig = eg.e_codig WHERE eg.e_loja = '" & local_Ref & "'")


            cmd = New NpgsqlCommand(sql.ToString, oConnBDMETROSYS)
            dr = cmd.ExecuteReader

            While dr.Read
                tamanhos += dr(0).ToString & "|"
            End While
            dr.Close() : sql.Remove(0, sql.ToString.Length)

            'Adicionando colunas
            Me.Dtg_grade.Columns.Add("id", "ID") : Me.Dtg_grade.Columns(0).Visible = False
            Me.Dtg_grade.Columns.Add("codigo", "CODIGO") : Me.Dtg_grade.Columns(1).Width = 60
            Me.Dtg_grade.Columns.Add("produto", "PRODUTO") : Me.Dtg_grade.Columns(2).Width = 250 : indexColuna = 2

            marray = Split(tamanhos, "|")
            For index As Integer = 0 To marray.Length - 2
                indexColuna += 1
                nomeColuna = marray(index).ToString
                Me.Dtg_grade.Columns.Add(nomeColuna.ToLower, nomeColuna.ToUpper) : Me.Dtg_grade.Columns(indexColuna).Width = 30
                tamanhos2 += indexColuna & "|" & nomeColuna & "?"
            Next



            sql.Append("SELECT eg.e_codig, eg.e_tm, eg.e_idgrade, e.e_produt, eg.e_qtde, eg.e_loja, eg.e_cor ") '6
            sql.Append("FROM " & MdlEmpresaUsu._esqVinc & ".estgrade eg LEFT JOIN " & MdlEmpresaUsu._esqVinc)
            sql.Append(".est0001 e ON e.e_codig = eg.e_codig WHERE eg.e_loja = '" & local_Ref & "' ORDER BY e.e_produt")
            cmd = New NpgsqlCommand(sql.ToString, oConnBDMETROSYS)
            dr = cmd.ExecuteReader

            While dr.Read

                Me.Dtg_grade.Rows.Add(dr(2), dr(0).ToString, dr(3).ToString & " - " & _
                                      _clFuncoes.trazNomeCorCboCoresGrade(dr(6).ToString, cbo_cores).ToUpper)

                setValorColunaGrade(dr(1).ToString, tamanhos2, Me.Dtg_grade.RowCount - 1, dr(4))
            End While


            oConnBDMETROSYS.ClearAllPools() : oConnBDMETROSYS.Close()
        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        sql.Remove(_valorZERO, sql.ToString.Length)

        'LIMPA OS OBJETOS DE MEMORIA...
        cmd = Nothing : sql = Nothing : oConnBDMETROSYS = Nothing



    End Sub

    Private Sub setValorColunaGrade(ByVal tamanhoGrade As String, ByVal todosTamanhosComIndex As String, _
                                    ByVal indexLinhaGrade As Integer, ByVal qtdeTamanho As Integer)

        Dim marray, marray2 As Array
        Dim indexColuna As Integer = 0
        Dim nomeColuna As String = "", aux As String = ""

        marray = Split(todosTamanhosComIndex, "?")
        For index As Integer = 0 To marray.Length

            aux = marray(index).ToString
            marray2 = Split(aux, "|")
            indexColuna = CInt(marray2(0).ToString)
            nomeColuna = marray2(1).ToString

            If nomeColuna.ToUpper.Equals(tamanhoGrade.ToUpper) Then

                Me.Dtg_grade.Rows(indexLinhaGrade).Cells(indexColuna).Value = qtdeTamanho.ToString
                Exit For
            End If

        Next

    End Sub

    Private Sub Form_CadGrade_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                executaF5()
        End Select

    End Sub

    Private Sub executaF5()
        consultaBD()
    End Sub

    Private Sub txt_Codigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codProd.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

            If Me.txt_codProd.Text.Equals("") Then

                'Aqui tenta chamar a Busca do Produto...
                Try
                    _frmREf = Me
                    _BuscaProd.set_frmRef(Me)
                    _BuscaProd.ShowDialog(Me)

                    If MdlEmpresaUsu._codProd Then

                        Me.txt_codProd.Text = codProd_Ref
                    Else
                        Me.txt_codProd.Text = cdBarraProd_Ref
                    End If


                    Me.txt_nomeProd.Text = nomeProd_Ref

                    If Me.txt_codProd.Text.Equals("") Then

                        Me.txt_codProd.Focus()
                    Else
                        Me.txt_nomeProd.Focus()
                    End If


                Catch ex As Exception
                End Try

            Else

                If _alterando = False Then

                    If trazItenBD(RTrim(Me.txt_codProd.Text)) = False Then
                        'Aqui tenta chamar a Busca do Produto...
                        Try
                            _frmREf = Me
                            _BuscaProd.set_frmRef(Me)
                            _BuscaProd.ShowDialog(Me)


                            If MdlEmpresaUsu._codProd Then

                                Me.txt_codProd.Text = codProd_Ref
                            Else
                                Me.txt_codProd.Text = cdBarraProd_Ref
                            End If

                            Me.txt_nomeProd.Text = nomeProd_Ref


                            If Me.txt_codProd.Text.Equals("") Then

                                Me.txt_codProd.Focus()
                            Else
                                Me.txt_nomeProd.Focus()
                            End If


                        Catch ex As Exception
                        End Try

                    Else

                        If MdlEmpresaUsu._codProd Then

                            Me.txt_codProd.Text = codProd_Ref

                        Else
                            Me.txt_codProd.Text = cdBarraProd_Ref
                        End If


                    End If
                End If


            End If
        End If


    End Sub

    Public Function trazItenBD(ByVal codIten As String) As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader
        Dim _erro As Boolean = False
        Dim _msgErro As String = ""
        Dim _contErros As Integer = _valorZERO
        Dim nomeCampo As String = ""

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("Banco de Dados ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return False

        End Try


        Try

            SqlProduto.Append("SELECT est.e_codig, est.e_produt, est.e_cdbarra FROM " & MdlEmpresaUsu._esqVinc & ".est0001 est ") ' 1
            SqlProduto.Append("LEFT JOIN estloja01 e ON e.e_codig = est.e_codig WHERE ")
            SqlProduto.Append("e.e_codig = '" & Me.txt_codProd.Text & "' AND e.e_loja = '" & local_Ref & "'")

            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDGENOV)
            drProduto = CmdProduto.ExecuteReader

            If drProduto.HasRows = False Then Return False
            While drProduto.Read

                codProd_Ref = drProduto(0).ToString
                nomeProd_Ref = drProduto(1).ToString
                cdBarraProd_Ref = drProduto(2).ToString


                If MdlEmpresaUsu._codProd Then

                    Me.txt_codProd.Text = codProd_Ref
                Else
                    Me.txt_codProd.Text = cdBarraProd_Ref
                End If


                Me.txt_nomeProd.Text = nomeProd_Ref

            End While
            drProduto.Close() : drProduto = Nothing

        Catch ex As Exception
            MsgBox("Tabela de PRODUTOS ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return False

        End Try

        CmdProduto.CommandText = "" : SqlProduto.Remove(_valorZERO, SqlProduto.ToString.Length)
        oConnBDGENOV.ClearPool() : oConnBDGENOV.Close()
        CmdProduto = Nothing : SqlProduto = Nothing : oConnBDGENOV = Nothing


        Return True
    End Function

    Private Sub zeraValores()
        Me.txt_codProd.Text = "" : Me.txt_nomeProd.Text = ""
        Me.txt_tamanho.Text = "" : Me.txt_qtde.Text = "0"
        Me.cbo_cores.SelectedIndex = 0

        codProd_Ref = "" : nomeProd_Ref = "" : cdBarraProd_Ref = ""
    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        mSaldoInicialEstoqueProd = 0 : qtdeFinal = 0
        If _incluindo AndAlso Trim(txt_nomeProd.Text).Equals("") = False Then

            If MessageBox.Show("Tem uma operação de inclusão em Aberto, ela será cancelada. Deseja Continuar?", "METROSYS", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False : zeraValores()
                Me.tbc_Grade.SelectTab(1) : Me.txt_codProd.Focus()
                btn_salvar.Enabled = True

            Else
                Me.tbc_Grade.SelectTab(1) : Me.txt_nomeProd.Focus() : btn_salvar.Enabled = True
            End If

        ElseIf _alterando Then

            If MessageBox.Show("Tem uma operação de Alteração em Aberto, ela será cancelada. Deseja Continuar?", "METROSYS", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False : zeraValores()
                Me.tbc_Grade.SelectTab(1) : Me.txt_codProd.Focus()
                btn_salvar.Enabled = True
            Else
                Me.tbc_Grade.SelectTab(1) : Me.txt_nomeProd.Focus() : btn_salvar.Enabled = True
            End If

        Else

            _incluindo = True : _alterando = False : zeraValores()
            Me.tbc_Grade.SelectTab(1) : Me.txt_codProd.Focus()
            btn_salvar.Enabled = True
        End If


    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        _objGrade.pId = Me.Dtg_grade.CurrentRow.Cells(0).Value.ToString
        qtdeFinal = 0
        If _alterando AndAlso Trim(txt_nomeProd.Text).Equals("") = False Then

            If MessageBox.Show("Tem uma operação de Alteração em Aberto, ela será cancelada. Deseja Continuar?", "METROSYS", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                _incluindo = False : _alterando = True : zeraValores() : trazGradeSelecionada()
                Me.tbc_Grade.SelectTab(1) : Me.txt_codProd.Focus()
                btn_salvar.Enabled = True

            Else
                trazGradeSelecionada() : Me.tbc_Grade.SelectTab(1) : Me.txt_nomeProd.Focus()
                btn_salvar.Enabled = True
            End If

        ElseIf _incluindo Then

            If MessageBox.Show("Tem uma operação de Inclusão em Aberto, ela será cancelada. Deseja Continuar?", "METROSYS", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                _incluindo = False : _alterando = True : zeraValores()
                Me.tbc_Grade.SelectTab(1) : Me.txt_codProd.Focus() : trazGradeSelecionada()
                btn_salvar.Enabled = True

            Else
                Me.tbc_Grade.SelectTab(1) : Me.txt_nomeProd.Focus() : trazGradeSelecionada()
                btn_salvar.Enabled = True
            End If

        Else

            _incluindo = False : _alterando = True : zeraValores()
            Me.tbc_Grade.SelectTab(1) : Me.txt_codProd.Focus() : trazGradeSelecionada()
            btn_salvar.Enabled = True
        End If


    End Sub

    Private Sub trazGradeSelecionada()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT eg.e_codig, eg.e_tm, eg.e_cor, eg.e_qtde, eg.e_idgrade, eg.e_loja, e.e_produt FROM " & MdlEmpresaUsu._esqVinc & ".estgrade eg ")
            sql.Append("LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 e ON e.e_codig = eg.e_codig WHERE eg.e_idgrade = @e_idgrade")
            cmd = New NpgsqlCommand(sql.ToString, oConnBDMETROSYS)
            cmd.Parameters.AddWithValue("@e_idgrade", _objGrade.pId)

            dr = cmd.ExecuteReader

            While dr.Read

                _objGrade.pCodig = dr(0)
                _objGrade.pTm = dr(1).ToString
                _objGrade.pCor = dr(2).ToString
                _objGrade.pQtde = dr(3)
                _objGrade.pId = dr(4)
                _objGrade.pLoja = dr(5)

                Me.txt_codProd.Text = _objGrade.pCodig
                Me.txt_nomeProd.Text = dr(6).ToString
                Me.txt_tamanho.Text = _objGrade.pTm
                Me.txt_qtde.Text = _objGrade.pQtde
                Me.cbo_cores.SelectedIndex = _clFuncoes.trazIndexCboCoresGrade(_objGrade.pCor, Me.cbo_cores)
                mSaldoInicialEstoqueProd = _objGrade.pQtde

            End While
            dr.Close() : oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()

        Catch ex As Exception
            MsgBox("ERRO no SELECT das GRADES:: ", MsgBoxStyle.Exclamation)
            Return

        End Try

        cmd.CommandText = "" : sql.Remove(0, sql.ToString.Length)
        dr = Nothing : sql = Nothing : cmd = Nothing : oConnBDMETROSYS = Nothing


    End Sub

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        If verificaCampos() Then

            _objGrade.pCodig = txt_codProd.Text
            _objGrade.pTm = txt_tamanho.Text
            _objGrade.pQtde = txt_qtde.Text
            _objGrade.pCor = cbo_cores.SelectedItem.ToString.Substring(0, 2)
            _objGrade.pLoja = local_Ref
            qtdeFinal = (CDbl(txt_qtde.Text) - mSaldoInicialEstoqueProd)

            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            If _incluindo = True Then

                If (_clBD.existeGradeInclusao(conection, _objGrade) = False) Then

                    conection.ClearAllPools() : conection.Close()
                    inclueGrade(_objGrade)

                Else

                    conection.ClearAllPools() : conection.Close()
                    MsgBox("Essa GRADE já existe! Informe outra GRADE", MsgBoxStyle.Exclamation)
                    txt_nomeProd.Focus() : Return
                End If


            ElseIf _alterando = True Then


                If _clBD.existeGradeAlteracao(conection, _objGrade) = False Then

                    conection.ClearAllPools() : conection.Close()
                    alteraGrade(_objGrade)
                Else

                    conection.ClearAllPools() : conection.Close()
                    MsgBox("Essa GRADE já existe! Informe outra GRADE", MsgBoxStyle.Exclamation)
                    txt_nomeProd.Focus() : Return
                End If
            End If
            conection = Nothing

            'zeraValores()
            'btn_salvar.Enabled = False
            'tbc_Grade.SelectTab(0) : executaF5()
        End If



    End Sub

    Private Function verificaCampos() As Boolean

        lbl_menssage2.Text = ""

        If Trim(Me.txt_codProd.Text).Equals("") OrElse Trim(Me.txt_nomeProd.Text).Equals("") Then

            lbl_menssage2.Text = "Informe um PRODUTO Por Favor!"
            Me.txt_codProd.Focus()
            Return False
        End If

        If Trim(Me.txt_tamanho.Text).Equals("") Then

            lbl_menssage2.Text = "Informe um TAMANHO Por Favor!"
            Me.txt_tamanho.Focus()
            Return False
        End If

        Try
            If Trim(Me.txt_qtde.Text).Equals("") OrElse CDbl(Me.txt_qtde.Text) <= 0 Then

                lbl_menssage2.Text = "Informe uma QUANTIDADE Por Favor!"
                Me.txt_qtde.Focus()
                Return False
            End If
        Catch ex As Exception

            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            lbl_menssage2.Text = "Informe uma QUANTIDADE Por Favor!"
            Me.txt_qtde.Focus()
            Return False
        End Try

        If cbo_cores.SelectedIndex < 0 Then

            lbl_menssage2.Text = "Informe uma COR Por Favor!"
            Me.cbo_cores.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub inclueGrade(ByVal grade As Cl_Grade)

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            transacao = conection.BeginTransaction

            _clBD.incGrade(conection, transacao, _objGrade)
            _clBD.somaQtdeProdEstloja(_objGrade.pCodig, _objGrade.pLoja, _objGrade.pQtde, conection, transacao)

            transacao.Commit() : conection.ClearPool()

            If MessageBox.Show("GRADE salva com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                zeraValores() : conection.Close() : Me.txt_codProd.Focus() : _objGrade.zeraValores()
            Else

                zeraValores() : _objGrade.zeraValores() : _incluindo = False : _alterando = False : conection.Close()
                tbc_Grade.SelectTab(0) : Me.Dtg_grade.Rows.Clear() : Me.Dtg_grade.Refresh() : executaF5()
                btn_salvar.Enabled = False : _objGrade.zeraValores()
            End If

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try

        Finally
            transacao = Nothing : conection = Nothing
        End Try



    End Sub

    Private Sub alteraGrade(ByVal grade As Cl_Grade)

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            transacao = conection.BeginTransaction

            _clBD.altGrade(conection, transacao, _objGrade)
            If qtdeFinal < 0 Then
                _clBD.subtraiQtdeProdEstloja(_objGrade.pCodig, _objGrade.pLoja, Abs(qtdeFinal), conection, transacao)
            Else
                _clBD.somaQtdeProdEstloja(_objGrade.pCodig, _objGrade.pLoja, qtdeFinal, conection, transacao)
            End If

            transacao.Commit() : conection.ClearPool()

            MsgBox("GRADE foi salva com sucesso", MsgBoxStyle.Exclamation)
            zeraValores() : _incluindo = False : _alterando = False : conection.Close()
            tbc_Grade.SelectTab(0) : executaF5() : btn_salvar.Enabled = False : _objGrade.zeraValores()


        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try

        Finally
            transacao = Nothing : conection = Nothing
        End Try



    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If _incluindo OrElse _alterando Then

            If MessageBox.Show("Deseja realmente Cancelar?", "METROSYS", MessageBoxButtons.YesNo, _
            MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                zeraValores() : _incluindo = False : _alterando = False
                btn_salvar.Enabled = False
                tbc_Grade.SelectTab(0) : executaF5()
            Else
                Me.btn_salvar.Focus()
            End If
        End If
        
    End Sub


    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click

        If MessageBox.Show("Deseja realmente Excluir este item?", "METROSYS", MessageBoxButtons.YesNo, _
           MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _objGrade.pId = Me.Dtg_grade.CurrentRow.Cells(0).Value.ToString
            zeraValores() : trazGradeSelecionada() : zeraValores()
            excluirGrade(_objGrade)
        End If
    End Sub

    Private Sub excluirGrade(ByVal grade As Cl_Grade)

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            transacao = conection.BeginTransaction

            _clBD.delGrade(conection, transacao, _objGrade)
            If MessageBox.Show("Deseja Diminuir a Quantidade Excluida do Estoque?", "METROSYS", MessageBoxButtons.YesNo, _
            MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                _clBD.subtraiQtdeProdEstloja(_objGrade.pCodig, _objGrade.pLoja, _objGrade.pQtde, conection, transacao)
            End If

            transacao.Commit() : conection.ClearPool()

            MsgBox("GRADE EXCLUIDA com sucesso", MsgBoxStyle.Exclamation)
            zeraValores() : _incluindo = False : _alterando = False : conection.Close()
            tbc_Grade.SelectTab(0) : executaF5() : btn_salvar.Enabled = False
            _objGrade.zeraValores()


        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try

        Finally
            transacao = Nothing : conection = Nothing
        End Try



    End Sub

End Class