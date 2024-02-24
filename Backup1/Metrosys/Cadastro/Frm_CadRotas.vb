Imports System
Imports System.Text
Imports Npgsql

Public Class Frm_CadRotas

    Private _valorZERO As Integer = 0
    Private _alterando As Boolean = False, _incluindo As Boolean = False
    Private _rota As Int32 = _valorZERO
    Private _destinoAnterior As String = ""
    Dim _clFuncoes As New ClFuncoes
    Dim _clBD As New Cl_bdMetrosys

    Private Sub txt_acresc2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_acresc2.GotFocus

        lbl_mesagem2.Text = ""
        If CInt(txt_acresc1.Text) = _valorZERO Then lbl_mesagem2.Text = "Preencha o acréscimo anterior!" : Me.txt_acresc1.Focus()

    End Sub

    Private Sub txt_acresc3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_acresc3.GotFocus

        lbl_mesagem2.Text = ""
        If CInt(txt_acresc2.Text) = _valorZERO Then lbl_mesagem2.Text = "Preencha o acréscimo anterior!" : Me.txt_acresc1.Focus()

    End Sub

    Private Sub txt_acresc4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_acresc4.GotFocus

        lbl_mesagem2.Text = ""
        If CInt(txt_acresc3.Text) = _valorZERO Then lbl_mesagem2.Text = "Preencha o acréscimo anterior!" : Me.txt_acresc2.Focus()

    End Sub

    Private Sub txt_acresc5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_acresc5.GotFocus

        lbl_mesagem2.Text = ""
        If CInt(txt_acresc4.Text) = _valorZERO Then lbl_mesagem2.Text = "Preencha o acréscimo anterior!" : Me.txt_acresc3.Focus()

    End Sub

    Private Sub txt_cond1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_acresc1.KeyPress, txt_acresc2.KeyPress, txt_acresc3.KeyPress, txt_acresc4.KeyPress, txt_acresc5.KeyPress

        'permite só numeros com virgula
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_cond2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_acresc1.LostFocus, txt_acresc2.LostFocus, txt_acresc3.LostFocus, txt_acresc4.LostFocus, txt_acresc5.LostFocus

        If IsNumeric(txt_acresc1.Text) = False Then txt_acresc1.Text = "0" : Return
        If IsNumeric(txt_acresc2.Text) = False Then txt_acresc2.Text = "0" : Return
        If IsNumeric(txt_acresc3.Text) = False Then txt_acresc3.Text = "0" : Return
        If IsNumeric(txt_acresc4.Text) = False Then txt_acresc4.Text = "0" : Return
        If IsNumeric(txt_acresc5.Text) = False Then txt_acresc5.Text = "0" : Return


    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        If (_incluindo = True) OrElse (_alterando = True) Then

            If MessageBox.Show("Operação em aberto! Ela será Subistituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False : tbc_Rotas.SelectTab(1) : limpaCamposRota()
                Me.txt_destino.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True
                _rota = _valorZERO

            End If

        Else
            _incluindo = True : _alterando = False : tbc_Rotas.SelectTab(1) : limpaCamposRota()
            Me.txt_destino.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True
            _rota = _valorZERO

        End If



    End Sub

    Private Sub Frm_CadRotas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Escape) Then Me.Close()
        If (e.KeyCode = Keys.F5) Then preencheDtg_Rotas()

    End Sub

    Private Sub Frm_cadCondPagto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub limpaCamposRota()

        Me.txt_rota.Text = "" : Me.txt_destino.Text = ""
        txt_acresc1.Text = "0" : txt_acresc2.Text = "0" : txt_acresc3.Text = "0"
        txt_acresc4.Text = "0" : txt_acresc5.Text = "0"

    End Sub

    Private Sub preencheDtg_Rotas()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdRotas As New NpgsqlCommand
        Dim sqlRotas As New StringBuilder
        Dim drRotas As NpgsqlDataReader

        Dim destino As String = ""
        Dim rota As Int32 = _valorZERO
        Dim acresc1, acresc2, acresc3, acresc4, acresc5 As String

        Try

            sqlRotas.Append("SELECT rt_rota, rt_destino, rt_acresc1, rt_acresc2, rt_acresc3, rt_acresc4, ") '5
            sqlRotas.Append("rt_acresc5 FROM cadrotas ORDER BY rt_rota ASC")  '6
            cmdRotas = New NpgsqlCommand(sqlRotas.ToString, oConnBDMETROSYS)
            drRotas = cmdRotas.ExecuteReader

            Dtg_Rotas.Rows.Clear()
            If drRotas.HasRows = False Then Return
            While drRotas.Read

                rota = drRotas(0)
                destino = drRotas(1).ToString
                acresc1 = Format(drRotas(2), "###,##0.00")
                acresc2 = Format(drRotas(3), "###,##0.00")
                acresc3 = Format(drRotas(4), "###,##0.00")
                acresc4 = Format(drRotas(5), "###,##0.00")
                acresc5 = Format(drRotas(6), "###,##0.00")

                Dtg_Rotas.Rows.Add(rota, destino, acresc1, acresc2, acresc3, acresc4, acresc5)

            End While

            Dtg_Rotas.Refresh()
            drRotas.Close()
            oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()

        Catch ex As Exception
            MsgBox("ERRO no SELECT das Rotas:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmdRotas.CommandText = ""
        sqlRotas.Remove(0, sqlRotas.ToString.Length)

        'Limpa Objetos de Memoria...
        destino = Nothing : rota = Nothing : oConnBDMETROSYS = Nothing : cmdRotas = Nothing
        sqlRotas = Nothing : drRotas = Nothing



    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _alterando = True : _incluindo = False : tbc_Rotas.SelectTab(1) : limpaCamposRota()
                _rota = Dtg_Rotas.CurrentRow.Cells(0).Value : trazRotaSelecionada()
                txt_destino.Focus() : tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True


            End If

        Else
            _alterando = True : _incluindo = False : tbc_Rotas.SelectTab(1) : limpaCamposRota()
            _rota = Dtg_Rotas.CurrentRow.Cells(0).Value : trazRotaSelecionada()
            txt_destino.Focus() : tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True

        End If



    End Sub

    Private Sub trazRotaSelecionada()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdRota As New NpgsqlCommand
        Dim sqlRota As New StringBuilder
        Dim drRota As NpgsqlDataReader

        Try

            sqlRota.Append("SELECT rt_rota, rt_destino, rt_acresc1, rt_acresc2, rt_acresc3, rt_acresc4, ") '5
            sqlRota.Append("rt_acresc5 FROM cadrotas WHERE rt_rota = @rt_rota")

            cmdRota = New NpgsqlCommand(sqlRota.ToString, oConnBDMETROSYS)
            cmdRota.Parameters.Add("@rt_rota", _rota)
            drRota = cmdRota.ExecuteReader

            While drRota.Read

                Me.txt_rota.Text = String.Format("{0:D2}", _rota)
                Me.txt_destino.Text = drRota(1).ToString
                _destinoAnterior = drRota(1).ToString
                Me.txt_acresc1.Text = drRota(2)
                Me.txt_acresc2.Text = drRota(3)
                Me.txt_acresc3.Text = drRota(4)
                Me.txt_acresc4.Text = drRota(5)
                Me.txt_acresc5.Text = drRota(6)

            End While

            drRota.Close()
            oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT das ROTAS:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return

        End Try

        cmdRota.CommandText = "" : sqlRota.Remove(0, sqlRota.ToString.Length)
        oConnBDMETROSYS = Nothing : cmdRota = Nothing : sqlRota = Nothing : drRota = Nothing



    End Sub

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click


        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        If _incluindo = True Then

            If _clBD.existeRota(conection, Me.txt_destino.Text) = False Then

                conection.ClearPool() : conection.Close()
                inclueRota(Me.txt_acresc1.Text, Me.txt_acresc2.Text, Me.txt_acresc3.Text, Me.txt_acresc4.Text, _
                          Me.txt_acresc5.Text, Me.txt_destino.Text)

            Else

                conection.ClearPool() : conection.Close()
                MsgBox("Esse Destino já existe! Informe outro Destino", MsgBoxStyle.Exclamation)
            End If


        ElseIf _alterando = True Then


            If _clBD.existeRota2(conection, Me.txt_destino.Text, _destinoAnterior) = False Then

                conection.ClearPool() : conection.Close()
                alteraRota(Me.txt_acresc1.Text, Me.txt_acresc2.Text, Me.txt_acresc3.Text, Me.txt_acresc4.Text, _
                          Me.txt_acresc5.Text, Me.txt_destino.Text)
            Else

                conection.ClearPool() : conection.Close()
                MsgBox("Esse Destino já existe! Informe outro Destino", MsgBoxStyle.Exclamation)
            End If
        End If

        conection = Nothing



    End Sub

    Private Sub inclueRota(ByVal acresc1 As String, ByVal acresc2 As String, ByVal acresc3 As String, _
                              ByVal acresc4 As String, ByVal acresc5 As String, ByVal destino As String)

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

            _clBD.incRota(conection, transacao, destino, acresc1, acresc2, acresc3, acresc4, acresc5)

            transacao.Commit()

            If MessageBox.Show("ROTA salva com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                limpaCamposRota() : conection.ClearPool() : conection.Close() : Me.txt_acresc1.Focus()

            Else

                limpaCamposRota() : _incluindo = False : _alterando = False
                conection.ClearPool() : conection.Close()
                tbc_Rotas.SelectTab(0) : Me.Dtg_Rotas.Rows.Clear() : Me.Dtg_Rotas.Refresh()
                preencheDtg_Rotas()

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

    Private Sub alteraRota(ByVal acresc1 As String, ByVal acresc2 As String, ByVal acresc3 As String, _
                              ByVal acresc4 As String, ByVal acresc5 As String, ByVal destino As String)

        Dim descricao As String = ""
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

            _clBD.altRota(conection, transacao, _rota, descricao, acresc1, acresc2, acresc3, acresc4, _
                               acresc5)

            transacao.Commit()

            MsgBox("ROTA salva com sucesso!", MsgBoxStyle.Exclamation)
            limpaCamposRota() : _incluindo = False : _alterando = False : conection.Close()
            tbc_Rotas.SelectTab(0) : Me.Dtg_Rotas.Rows.Clear() : Me.Dtg_Rotas.Refresh()
            preencheDtg_Rotas() : _rota = _valorZERO
            conection.ClearPool() : conection.Close()

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

                tbc_Rotas.SelectTab(0) : limpaCamposRota() : tbp_manutencao.Text = "Condições"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False
                Me.Dtg_Rotas.Rows.Clear() : Me.Dtg_Rotas.Refresh() : preencheDtg_Rotas()
                _rota = _valorZERO

            End If
        End If



    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click

        If Me.Dtg_Rotas.CurrentRow.IsNewRow = False Then

            _rota = CInt(Me.Dtg_Rotas.CurrentRow.Cells(0).Value)
            If MessageBox.Show("Deseja realmente Deletar esta ROTA?", "METROSYS", _
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

                    _clBD.delCondPagto(conection, transacao, _rota)

                    transacao.Commit()

                    conection.ClearPool() : conection.Close()
                Catch ex As Exception
                    MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                    Try
                        transacao.Rollback()

                    Catch ex1 As Exception
                    End Try

                Finally
                    transacao = Nothing : conection = Nothing
                End Try



                limpaCamposRota() : tbp_manutencao.Text = "Condições"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False
                Me.Dtg_Rotas.Rows.Clear() : Me.Dtg_Rotas.Refresh() : preencheDtg_Rotas()
                _rota = _valorZERO

            End If
        End If


    End Sub

    Private Sub Frm_cadCondPagto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        preencheDtg_Rotas()

    End Sub

    Private Sub txt_acresc1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_acresc1.Leave

        lbl_mesagem2.Text = ""

        If Me.txt_acresc1.Text.Equals("") Then Me.txt_acresc1.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_acresc1.Text) Then

            If CDec(Me.txt_acresc1.Text) < _valorZERO Then

                lbl_mesagem2.Text = "A Vista deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_acresc1.Text = Format(CDec(Me.txt_acresc1.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_acresc2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_acresc2.Leave

        lbl_mesagem2.Text = ""

        If Me.txt_acresc2.Text.Equals("") Then Me.txt_acresc2.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_acresc2.Text) Then

            If CDec(Me.txt_acresc2.Text) < _valorZERO Then

                lbl_mesagem2.Text = "Prazo de 15 Dias deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_acresc2.Text = Format(CDec(Me.txt_acresc2.Text), "###,##0.00")

        End If
    End Sub

    Private Sub txt_acresc3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_acresc3.Leave

        lbl_mesagem2.Text = ""

        If Me.txt_acresc3.Text.Equals("") Then Me.txt_acresc3.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_acresc3.Text) Then

            If CDec(Me.txt_acresc3.Text) < _valorZERO Then

                lbl_mesagem2.Text = "Prazo de 30 Dias deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_acresc3.Text = Format(CDec(Me.txt_acresc3.Text), "###,##0.00")

        End If
    End Sub

    Private Sub txt_acresc4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_acresc4.Leave

        lbl_mesagem2.Text = ""

        If Me.txt_acresc4.Text.Equals("") Then Me.txt_acresc4.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_acresc4.Text) Then

            If CDec(Me.txt_acresc4.Text) < _valorZERO Then

                lbl_mesagem2.Text = "Prazo de 35 Dias deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_acresc4.Text = Format(CDec(Me.txt_acresc4.Text), "###,##0.00")

        End If
    End Sub

    Private Sub txt_acresc5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_acresc5.Leave

        lbl_mesagem2.Text = ""

        If Me.txt_acresc5.Text.Equals("") Then Me.txt_acresc5.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_acresc5.Text) Then

            If CDec(Me.txt_acresc5.Text) < _valorZERO Then

                lbl_mesagem2.Text = "Prazo de 45 Dias deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_acresc5.Text = Format(CDec(Me.txt_acresc5.Text), "###,##0.00")

        End If
    End Sub
End Class