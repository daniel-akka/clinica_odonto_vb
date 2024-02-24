Imports System
Imports System.Text
Imports Npgsql

Public Class Frm_cadCondPagto

    Private _valorZERO As Integer = 0
    Private _alterando As Boolean = False, _incluindo As Boolean = False
    Private _idCondpagto As Int32 = _valorZERO
    Private _descricaoAnterior As String = ""
    Dim _clFuncoes As New ClFuncoes
    Dim _clBD As New Cl_bdMetrosys
    Dim condPagto As New Cl_CondPagto

    Private Sub txt_cond2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cond2.GotFocus, txt_cond12.GotFocus

        lbl_mensage2.Text = ""
        If CInt(txt_cond1.Text) = _valorZERO Then lbl_mensage2.Text = "Preencha a condição anterior!" : Me.txt_cond1.Focus()

    End Sub

    Private Sub txt_cond3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cond3.GotFocus, txt_cond13.GotFocus

        lbl_mensage2.Text = ""
        If CInt(txt_cond2.Text) = _valorZERO Then lbl_mensage2.Text = "Preencha a condição anterior!" : Me.txt_cond1.Focus()

    End Sub

    Private Sub txt_cond4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cond4.GotFocus, txt_cond14.GotFocus

        lbl_mensage2.Text = ""
        If CInt(txt_cond3.Text) = _valorZERO Then lbl_mensage2.Text = "Preencha a condição anterior!" : Me.txt_cond2.Focus()

    End Sub

    Private Sub txt_cond5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cond5.GotFocus, txt_cond15.GotFocus

        lbl_mensage2.Text = ""
        If CInt(txt_cond4.Text) = _valorZERO Then lbl_mensage2.Text = "Preencha a condição anterior!" : Me.txt_cond3.Focus()

    End Sub

    Private Sub txt_cond6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cond6.GotFocus, txt_cond16.GotFocus

        lbl_mensage2.Text = ""
        If CInt(txt_cond5.Text) = _valorZERO Then lbl_mensage2.Text = "Preencha a condição anterior!" : Me.txt_cond4.Focus()

    End Sub

    Private Sub txt_cond7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cond7.GotFocus, txt_cond8.GotFocus, txt_cond9.GotFocus, txt_cond10.GotFocus, txt_cond17.GotFocus, txt_cond18.GotFocus, txt_cond19.GotFocus, txt_cond20.GotFocus

        lbl_mensage2.Text = ""
        If CInt(txt_cond6.Text) = _valorZERO Then lbl_mensage2.Text = "Preencha a condição anterior!" : Me.txt_cond5.Focus()

    End Sub

    Private Sub txt_cond1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cond1.KeyPress, txt_cond2.KeyPress, txt_cond3.KeyPress, txt_cond4.KeyPress, txt_cond5.KeyPress, txt_cond6.KeyPress, txt_cond7.KeyPress, txt_cond8.KeyPress, txt_cond16.KeyPress, txt_cond15.KeyPress, txt_cond14.KeyPress, txt_cond13.KeyPress, txt_cond12.KeyPress, txt_cond11.KeyPress, txt_cond10.KeyPress, txt_cond9.KeyPress, txt_cond20.KeyPress, txt_cond19.KeyPress, txt_cond18.KeyPress, txt_cond17.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_cond2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cond1.LostFocus, txt_cond2.LostFocus, txt_cond3.LostFocus, txt_cond4.LostFocus, txt_cond5.LostFocus, txt_cond6.LostFocus, txt_cond7.LostFocus, txt_cond8.LostFocus, txt_cond9.LostFocus, txt_cond10.LostFocus, txt_cond11.LostFocus, txt_cond12.LostFocus, txt_cond13.LostFocus, txt_cond14.LostFocus, txt_cond15.LostFocus, txt_cond16.LostFocus, txt_cond17.LostFocus, txt_cond18.LostFocus, txt_cond19.LostFocus, txt_cond20.LostFocus

        If IsNumeric(txt_cond1.Text) = False Then txt_cond1.Text = "0" : Return
        If IsNumeric(txt_cond2.Text) = False Then txt_cond2.Text = "0" : Return
        If IsNumeric(txt_cond3.Text) = False Then txt_cond3.Text = "0" : Return
        If IsNumeric(txt_cond4.Text) = False Then txt_cond4.Text = "0" : Return
        If IsNumeric(txt_cond5.Text) = False Then txt_cond5.Text = "0" : Return
        If IsNumeric(txt_cond6.Text) = False Then txt_cond6.Text = "0" : Return
        If IsNumeric(txt_cond7.Text) = False Then txt_cond7.Text = "0" : Return


    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        If _incluindo = True OrElse _alterando = True Then
            btn_salvar.Enabled = True
            If MessageBox.Show("Operação em aberto! Ela será Subistituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False : tbc_condpagto.SelectTab(1) : limpaCamposCond()
                Me.txt_colpreco.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True
                _idCondpagto = _valorZERO

            End If

        Else
            btn_salvar.Enabled = False
            _incluindo = True : _alterando = False : tbc_condpagto.SelectTab(1) : limpaCamposCond()
            Me.txt_colpreco.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True
            _idCondpagto = _valorZERO

        End If



    End Sub

    Private Sub Frm_cadCondPagto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                executaF5()

        End Select


    End Sub

    Private Sub Frm_cadCondPagto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub limpaCamposCond()

        lbl_mensage2.Text = "" : Me.txt_colpreco.Text = "" : Me.txt_colrotas.Text = ""
        txt_cond1.Text = "0" : txt_cond2.Text = "0" : txt_cond3.Text = "0"
        txt_cond4.Text = "0" : txt_cond5.Text = "0" : txt_cond6.Text = "0"
        txt_cond7.Text = "0" : cbo_qtdeCondPagto.SelectedIndex = 0
        txt_prazo.Text = "0" : txt_acrescimo.Text = "0,00" : condPagto.zeraValores()


    End Sub

    Private Sub preencheDtg_Condpagto1()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdCondpagto As New NpgsqlCommand
        Dim sqlCondpagto As New StringBuilder
        Dim drCondpagto As NpgsqlDataReader

        Dim descricao As String = "", colpreco As String = "", colrota As String = ""
        Dim id As Int32 = _valorZERO
        Dim cond1, cond2, cond3, cond4, cond5, cond6, cond7 As Integer

        Try

            sqlCondpagto.Append("SELECT cpg_id, cpg_descricao, cpg_cond1, cpg_cond2, cpg_cond3, cpg_cond4, ") '5
            sqlCondpagto.Append("cpg_cond5, cpg_cond6, cpg_cond7, cpg_colpreco, cpg_colrotas FROM condpagto ")
            sqlCondpagto.Append("WHERE cpg_tipo = 1 ORDER BY LENGTH(cpg_descricao), cpg_descricao ASC")  '8
            cmdCondpagto = New NpgsqlCommand(sqlCondpagto.ToString, oConnBDMETROSYS)
            drCondpagto = cmdCondpagto.ExecuteReader

            Dtg_condPagto.Rows.Clear()
            If drCondpagto.HasRows = False Then Return
            While drCondpagto.Read
                id = drCondpagto(0)
                descricao = drCondpagto(1).ToString
                cond1 = drCondpagto(2) : cond2 = drCondpagto(3)
                cond3 = drCondpagto(4) : cond4 = drCondpagto(5)
                cond5 = drCondpagto(6) : cond6 = drCondpagto(7)
                cond7 = drCondpagto(8) : colpreco = drCondpagto(9).ToString
                colrota = drCondpagto(10).ToString

                Dtg_condPagto.Rows.Add(id, descricao, cond1, cond2, cond3, cond4, cond5, cond6, _
                                       cond7, colpreco, colrota)

            End While

            Dtg_condPagto.Refresh()
            drCondpagto.Close()

        Catch ex As Exception
            MsgBox("ERRO no SELECT das Condições:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmdCondpagto.CommandText = ""
        sqlCondpagto.Remove(0, sqlCondpagto.ToString.Length)
        oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()

        'Limpa Objetos de Memoria...
        descricao = Nothing : id = Nothing : oConnBDMETROSYS = Nothing : cmdCondpagto = Nothing
        sqlCondpagto = Nothing : drCondpagto = Nothing



    End Sub

    Private Sub preencheDtg_Condpagto2()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdCondpagto As New NpgsqlCommand
        Dim sqlCondpagto As New StringBuilder
        Dim drCondpagto As NpgsqlDataReader

        Dim descricao As String = "", colpreco As String = "", colrota As String = ""
        Dim id As Int32 = _valorZERO
        Dim cond1, cond2, cond3, cond4, cond5, cond6, cond7 As Integer

        Try

            sqlCondpagto.Append("SELECT cpg_id, cpg_descricao FROM condpagto WHERE cpg_tipo = 2 ")
            sqlCondpagto.Append("ORDER BY LENGTH(cpg_descricao), cpg_descricao ASC")  '8
            cmdCondpagto = New NpgsqlCommand(sqlCondpagto.ToString, oConnBDMETROSYS)
            drCondpagto = cmdCondpagto.ExecuteReader

            Dtg_condPagto.Rows.Clear()
            If drCondpagto.HasRows = False Then Return
            While drCondpagto.Read
                id = drCondpagto(0)
                descricao = drCondpagto(1).ToString

                Dtg_condPagto.Rows.Add(id, descricao)

            End While

            Dtg_condPagto.Refresh()
            drCondpagto.Close()

        Catch ex As Exception
            MsgBox("ERRO no SELECT das Condições:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmdCondpagto.CommandText = ""
        sqlCondpagto.Remove(0, sqlCondpagto.ToString.Length)
        oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()

        'Limpa Objetos de Memoria...
        descricao = Nothing : id = Nothing : oConnBDMETROSYS = Nothing : cmdCondpagto = Nothing
        sqlCondpagto = Nothing : drCondpagto = Nothing



    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _alterando = True : _incluindo = False : tbc_condpagto.SelectTab(1) : limpaCamposCond()
                _idCondpagto = Dtg_condPagto.CurrentRow.Cells(0).Value : trazCondPagtoSelecionada()
                txt_colpreco.Focus() : tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True


            End If

        Else
            _alterando = True : _incluindo = False : tbc_condpagto.SelectTab(1) : limpaCamposCond()
            _idCondpagto = Dtg_condPagto.CurrentRow.Cells(0).Value : trazCondPagtoSelecionada()
            txt_colpreco.Focus() : tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True

        End If



    End Sub

    Private Sub trazCondPagtoSelecionada()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdCondPagto As New NpgsqlCommand
        Dim sqlCondPagto As New StringBuilder
        Dim drCondPagto As NpgsqlDataReader

        Try
            sqlCondPagto.Append("SELECT cpg_id, cpg_descricao, cpg_cond1, cpg_cond2, cpg_cond3, cpg_cond4, cpg_cond5, cpg_cond6, ") '7
            sqlCondPagto.Append("cpg_cond7, cpg_colpreco, cpg_colrotas, cpg_qtdeparcelas, cpg_intervaloparcelas, cpg_acrescimo FROM condpagto WHERE cpg_id = @cpg_id")


            cmdCondPagto = New NpgsqlCommand(sqlCondPagto.ToString, oConnBDMETROSYS)
            cmdCondPagto.Parameters.Add("@cpg_id", _idCondpagto)
            drCondPagto = cmdCondPagto.ExecuteReader

            While drCondPagto.Read

                _descricaoAnterior = drCondPagto(1).ToString
                Me.txt_cond1.Text = drCondPagto(2)
                Me.txt_cond2.Text = drCondPagto(3)
                Me.txt_cond3.Text = drCondPagto(4)
                Me.txt_cond4.Text = drCondPagto(5)
                Me.txt_cond5.Text = drCondPagto(6)
                Me.txt_cond6.Text = drCondPagto(7)
                Me.txt_cond7.Text = drCondPagto(8)
                Me.txt_colpreco.Text = drCondPagto(9).ToString
                Me.txt_colrotas.Text = drCondPagto(10).ToString
                Me.cbo_qtdeCondPagto.SelectedIndex = drCondPagto(11)
                Me.txt_prazo.Text = drCondPagto(12)
                Me.txt_acrescimo.Text = Format(drCondPagto(13), "###,##0.00")


            End While

            drCondPagto.Close() : oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT das CONDIÇÕES", MsgBoxStyle.Exclamation)
            Return

        End Try

        cmdCondPagto.CommandText = "" : sqlCondPagto.Remove(0, sqlCondPagto.ToString.Length)
        cmdCondPagto = Nothing : sqlCondPagto = Nothing : oConnBDMETROSYS = Nothing



    End Sub

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click


        Dim descricao As String = formaDescricao(Me.txt_cond1.Text, Me.txt_cond2.Text, Me.txt_cond3.Text, _
                        Me.txt_cond4.Text, Me.txt_cond5.Text, Me.txt_cond6.Text, Me.txt_cond7.Text)

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        If _incluindo = True Then

            If _clBD.existeCondpagto(conection, descricao) = False Then

                conection.ClearPool() : conection.Close()
                inclueCondpagto(Me.txt_cond1.Text, Me.txt_cond2.Text, Me.txt_cond3.Text, Me.txt_cond4.Text, _
                          Me.txt_cond5.Text, Me.txt_cond6.Text, Me.txt_cond7.Text, descricao, _
                          Me.txt_colpreco.Text, Me.txt_colrotas.Text, Me.txt_acrescimo.Text)
            Else

                conection.ClearPool() : conection.Close()
                MsgBox("Essa Condição de pagamento já existe! Informe outra Condição!", MsgBoxStyle.Exclamation)
            End If


        ElseIf _alterando = True Then


            If _clBD.existeCondpagto2(conection, descricao, _descricaoAnterior) = False Then

                conection.ClearPool() : conection.Close()
                alteraCondpagto(Me.txt_cond1.Text, Me.txt_cond2.Text, Me.txt_cond3.Text, Me.txt_cond4.Text, _
                          Me.txt_cond5.Text, Me.txt_cond6.Text, Me.txt_cond7.Text, Me.txt_colpreco.Text, _
                          Me.txt_colrotas.Text, Me.txt_acrescimo.Text)
            Else

                conection.ClearPool() : conection.Close()
                MsgBox("Essa Condição de pagamento já existe! Informe outra Condição!", MsgBoxStyle.Exclamation)
            End If
        End If

        conection = Nothing



    End Sub

    Private Function formaDescricao(ByVal cond1 As String, ByVal cond2 As String, ByVal cond3 As String, _
                              ByVal cond4 As String, ByVal cond5 As String, ByVal cond6 As String, _
                              ByVal cond7 As String) As String

        Dim descricao As String = ""

        If CInt(cond1) > _valorZERO Then descricao += cond1
        If CInt(cond2) > _valorZERO Then descricao += "/" & cond2
        If CInt(cond3) > _valorZERO Then descricao += "/" & cond3
        If CInt(cond4) > _valorZERO Then descricao += "/" & cond4
        If CInt(cond5) > _valorZERO Then descricao += "/" & cond5
        If CInt(cond6) > _valorZERO Then descricao += "/" & cond6
        If CInt(cond7) > _valorZERO Then descricao += "/" & cond7
        If descricao.Equals("") Then descricao = "0"

        If grp_cond2.Visible Then

            If CInt(Me.cbo_qtdeCondPagto.SelectedItem) > 0 Then

                If CInt(txt_prazo.Text) > 1 Then
                    descricao = Me.cbo_qtdeCondPagto.SelectedItem & " Parcelas em prazo de " & Me.txt_prazo.Text & " dias"
                ElseIf CInt(txt_prazo.Text) = 1 Then
                    descricao = Me.cbo_qtdeCondPagto.SelectedItem & " Parcela em prazo de " & Me.txt_prazo.Text & " dia"
                End If
            Else
                descricao = "A VISTA"
            End If
        End If



        Return descricao
    End Function

    Private Sub inclueCondpagto(ByVal cond1 As String, ByVal cond2 As String, ByVal cond3 As String, _
                              ByVal cond4 As String, ByVal cond5 As String, ByVal cond6 As String, _
                              ByVal cond7 As String, ByVal descricao As String, ByVal colpreco As String, _
                              ByVal colrotas As String, ByVal acrescimo As Double)

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim prazo As Int16 = Me.txt_prazo.Text
        Dim qtdeParcelas As Int16 = Me.cbo_qtdeCondPagto.SelectedItem


        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            condPagto.pDescricao = descricao
            condPagto.pCond1 = cond1
            condPagto.pCond2 = cond2
            condPagto.pCond3 = cond3
            condPagto.pCond4 = cond4
            condPagto.pCond5 = cond5
            condPagto.pCond6 = cond6
            condPagto.pCond7 = cond7
            condPagto.pColpreco = colpreco
            condPagto.pColrotas = colrotas
            condPagto.pQtdeparcelas = CInt(Me.cbo_qtdeCondPagto.SelectedItem)
            condPagto.pIntervaloparcelas = CInt(Me.txt_prazo.Text)
            condPagto.pAcrescimo = acrescimo
            condPagto.pTipo = MdlEmpresaUsu.tipoCondPagto



            transacao = conection.BeginTransaction
            _clBD.incCondPagto(condPagto, conection, transacao)
            transacao.Commit()

            If MessageBox.Show("CONDIÇÃO salva com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                limpaCamposCond() : conection.ClearPool() : conection.Close() : Me.txt_cond1.Focus()
            Else

                btn_salvar.Enabled = False : limpaCamposCond() : _incluindo = False : _alterando = False
                conection.ClearPool() : conection.Close()
                tbc_condpagto.SelectTab(0) : Me.Dtg_condPagto.Rows.Clear() : Me.Dtg_condPagto.Refresh()
                executaF5()

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

    Private Sub alteraCondpagto(ByVal cond1 As String, ByVal cond2 As String, ByVal cond3 As String, _
                              ByVal cond4 As String, ByVal cond5 As String, ByVal cond6 As String, _
                              ByVal cond7 As String, ByVal colpreco As String, ByVal colrotas As String, _
                              ByVal acrescimo As Double)

        Dim descricao As String = ""
        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim prazo As Int16 = Me.txt_prazo.Text
        Dim qtdeParcelas As Int16 = Me.cbo_qtdeCondPagto.SelectedItem

        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            transacao = conection.BeginTransaction

            If CInt(cond1) > _valorZERO Then descricao += cond1
            If CInt(cond2) > _valorZERO Then descricao += "/" & cond2
            If CInt(cond3) > _valorZERO Then descricao += "/" & cond3
            If CInt(cond4) > _valorZERO Then descricao += "/" & cond4
            If CInt(cond5) > _valorZERO Then descricao += "/" & cond5
            If CInt(cond6) > _valorZERO Then descricao += "/" & cond6
            If CInt(cond7) > _valorZERO Then descricao += "/" & cond7
            If descricao.Equals("") Then descricao = "0"

            If grp_cond2.Visible Then

                If CInt(Me.cbo_qtdeCondPagto.SelectedItem) > 0 Then

                    If CInt(txt_prazo.Text) > 1 Then
                        descricao = Me.cbo_qtdeCondPagto.SelectedItem & " Parcelas em prazo de " & Me.txt_prazo.Text & " dias"
                    ElseIf CInt(txt_prazo.Text) = 1 Then
                        descricao = Me.cbo_qtdeCondPagto.SelectedItem & " Parcela em prazo de " & Me.txt_prazo.Text & " dia"
                    End If
                Else
                    descricao = "A VISTA"
                End If
            End If


            condPagto.pDescricao = descricao
            condPagto.pCond1 = cond1
            condPagto.pCond2 = cond2
            condPagto.pCond3 = cond3
            condPagto.pCond4 = cond4
            condPagto.pCond5 = cond5
            condPagto.pCond6 = cond6
            condPagto.pCond7 = cond7
            condPagto.pColpreco = colpreco
            condPagto.pColrotas = colrotas
            condPagto.pQtdeparcelas = CInt(Me.cbo_qtdeCondPagto.SelectedItem)
            condPagto.pIntervaloparcelas = CInt(Me.txt_prazo.Text)
            condPagto.pAcrescimo = acrescimo
            condPagto.pTipo = MdlEmpresaUsu.tipoCondPagto


            _clBD.altCondPagto(conection, transacao, _idCondpagto, condPagto)
            transacao.Commit()

            MsgBox("CONDIÇÃO salva com sucesso!", MsgBoxStyle.Exclamation)
            limpaCamposCond() : _incluindo = False : _alterando = False
            btn_salvar.Enabled = False : conection.ClearPool() : conection.Close()
            tbc_condpagto.SelectTab(0) : Me.Dtg_condPagto.Rows.Clear() : Me.Dtg_condPagto.Refresh()
            executaF5() : _idCondpagto = _valorZERO


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

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If _incluindo = True OrElse _alterando = True Then 'Se tiver operação executando, então...

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                tbc_condpagto.SelectTab(0) : limpaCamposCond() : tbp_manutencao.Text = "Condições"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False
                Me.Dtg_condPagto.Rows.Clear() : Me.Dtg_condPagto.Refresh() : executaF5()
                _idCondpagto = _valorZERO

            End If
        End If




    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click

        If Me.Dtg_condPagto.CurrentRow.IsNewRow = False Then

            _idCondpagto = CInt(Me.Dtg_condPagto.CurrentRow.Cells(0).Value)
            If MessageBox.Show("Deseja realmente Deletar esta Descrição?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then


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

                    _clBD.delCondPagto(conection, transacao, _idCondpagto)

                    transacao.Commit() : conection.ClearPool() : conection.Close()

                Catch ex As Exception
                    MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                    Try
                        transacao.Rollback()

                    Catch ex1 As Exception
                    End Try

                Finally
                    transacao = Nothing : conection = Nothing
                End Try



                limpaCamposCond() : tbp_manutencao.Text = "Condições"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False
                Me.Dtg_condPagto.Rows.Clear() : Me.Dtg_condPagto.Refresh() : executaF5()
                _idCondpagto = _valorZERO

            End If
        End If


    End Sub

    Private Sub modificaDtgTipo1()

        Dtg_condPagto.Columns(1).Width = 300
        Dtg_condPagto.Columns(2).Visible = True
        Dtg_condPagto.Columns(3).Visible = True
        Dtg_condPagto.Columns(4).Visible = True
        Dtg_condPagto.Columns(5).Visible = True
        Dtg_condPagto.Columns(6).Visible = True
        Dtg_condPagto.Columns(7).Visible = True
        Dtg_condPagto.Columns(8).Visible = True
        Dtg_condPagto.Columns(9).Visible = True
        Dtg_condPagto.Columns(10).Visible = True

    End Sub

    Private Sub modificaDtgTipo2()

        Dtg_condPagto.Columns(1).Width = 445
        Dtg_condPagto.Columns(2).Visible = False
        Dtg_condPagto.Columns(3).Visible = False
        Dtg_condPagto.Columns(4).Visible = False
        Dtg_condPagto.Columns(5).Visible = False
        Dtg_condPagto.Columns(6).Visible = False
        Dtg_condPagto.Columns(7).Visible = False
        Dtg_condPagto.Columns(8).Visible = False
        Dtg_condPagto.Columns(9).Visible = False
        Dtg_condPagto.Columns(10).Visible = False

    End Sub

    Private Sub Frm_cadCondPagto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        Select Case MdlEmpresaUsu.tipoCondPagto

            Case 1
                grp_cond1.Visible = True : grp_cond2.Visible = False
                grp_cond2.SetBounds(6, 56, 377, 112)
                modificaDtgTipo1()

            Case 2
                grp_cond1.Visible = False : grp_cond2.Visible = True
                grp_cond2.SetBounds(6, 56, 377, 112)
                cbo_qtdeCondPagto.SelectedIndex = 0
                modificaDtgTipo2()


        End Select
        executaF5()


    End Sub

    Private Sub executaF5()

        If MdlEmpresaUsu.tipoCondPagto = 1 Then preencheDtg_Condpagto1()
        If MdlEmpresaUsu.tipoCondPagto = 2 Then preencheDtg_Condpagto2()

    End Sub

    Private Sub txt_colpreco_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_colpreco.KeyPress, txt_colrotas.KeyPress

        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_colpreco_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_colpreco.Leave

        lbl_mensage2.Text = ""
        If IsNumeric(Me.txt_colpreco.Text) Then

            If (CInt(Me.txt_colpreco.Text) <= _valorZERO) OrElse (CInt(Me.txt_colpreco.Text) > 7) Then

                lbl_mensage2.Text = "Valor da coluna dever ser de 1 a 7 !" : Me.txt_colpreco.Focus()
            End If
        Else

            Me.txt_colpreco.Text = "1"
        End If


    End Sub

    Private Sub txt_colrotas_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_colrotas.Leave

        lbl_mensage2.Text = ""
        If IsNumeric(Me.txt_colrotas.Text) Then

            If (CInt(Me.txt_colrotas.Text) <= _valorZERO) OrElse (CInt(Me.txt_colrotas.Text) > 5) Then

                lbl_mensage2.Text = "Valor da coluna dever ser de 1 a 5 !" : Me.txt_colrotas.Focus()
            End If
        Else

            Me.txt_colrotas.Text = "1"
        End If

    End Sub

    Private Sub txt_prazo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_prazo.KeyPress

        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub cbo_qtdeCondPagto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_qtdeCondPagto.SelectedIndexChanged

        If cbo_qtdeCondPagto.SelectedIndex = 0 Then
            Me.txt_prazo.Text = "0" : Me.txt_prazo.ReadOnly = True
        ElseIf cbo_qtdeCondPagto.SelectedIndex > 0 Then
            Me.txt_prazo.Text = "0" : Me.txt_prazo.ReadOnly = False
        End If

    End Sub

    Private Sub txt_acrescimo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_acrescimo.KeyPress
        'permite só numeros vírgula
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_acrescimo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_acrescimo.Leave

        lbl_mensage2.Text = ""
        If Me.txt_acrescimo.Text.Equals("") Then Me.txt_acrescimo.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_acrescimo.Text) Then
            If CDec(Me.txt_acrescimo.Text) < _valorZERO Then
                lbl_mensage2.Text = "Entrada deve ser maior ou igual a ZERO !"
                Return

            End If
            Me.txt_acrescimo.Text = Format(CDec(Me.txt_acrescimo.Text), "###,##0.00")

        End If

    End Sub
End Class