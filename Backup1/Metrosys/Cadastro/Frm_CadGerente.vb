Imports System
Imports System.Text
Imports Npgsql

Public Class Frm_CadGerente

    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private Const _valorZERO As Integer = 0
    Public Shared _frmRef As New Frm_UsuariosManutencao
    Dim mResultado As String = "", mResultado2 As String = ""
    Public _alterando As Boolean = False, _incluindo As Boolean = False

    'ultilizados para o DataGridView
    Private _oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Private _cmdGerente As New NpgsqlCommand
    Private _sqlGerente As New StringBuilder
    Private _drGerente As NpgsqlDataReader
    Private _idGerente As Int32 = _valorZERO
    Private _senhaGerente As String = ""


    Private Sub Frm_CadGerente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()

        End Select


    End Sub

    Private Sub btn_gravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        mResultado = Me.txt_senha.Text : mResultado2 = Me.txt_redigita.Text

        If mResultado.Equals(mResultado2) = False Then

            MsgBox("Atenção ! " & Chr(10) & " Senhas Digitadas não conferem, Redigite !", MsgBoxStyle.Exclamation)
            Me.txt_senha.Text = "" : Me.txt_redigita.Text = "" : Me.txt_senha.Focus()
            Return

        End If

        If verificaGerente() Then

            If _incluindo = True Then
                inclueGerente(Me.txt_nome.Text, Me.txt_senha.Text, Me.chk_libDesconto.Checked, _
                              Me.chk_libValor.Checked, Me.txt_libVlrMaximo.Text, _
                              Me.chk_privilegioLojas.Checked, Trim(Mid(Me.cbo_local.SelectedItem, 1, 6)))

            ElseIf _alterando = True Then
                alteraGerente(_idGerente, Me.txt_nome.Text, Me.txt_senha.Text, Me.chk_libDesconto.Checked, _
                              Me.chk_libValor.Checked, Me.txt_libVlrMaximo.Text, Me.chk_privilegioLojas.Checked, _
                              Trim(Mid(Me.cbo_local.SelectedItem, 1, 6)))

            End If
        End If



    End Sub

    Private Sub Frm_CadGerente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Function criptografaSenha(ByVal senha As String) As String

        Dim Msenha(10), Xsenha(10) As Integer
        Dim senhaCripto As String = ""

        Msenha(0) = 154 : Msenha(1) = 157 : Msenha(2) = 181 : Msenha(3) = 165 : Msenha(4) = 216
        Msenha(5) = 219 : Msenha(6) = 175 : Msenha(7) = 208 : Msenha(8) = 249 : Msenha(9) = 243

        Dim x As Integer
        For x = 1 To Len(senha)

            Xsenha(x - 1) = Asc(Mid(senha, x, 1)) + Msenha(x - 1)
            senhaCripto = RTrim(senhaCripto) & Convert.ToChar(Xsenha(x - 1))

        Next



        Return senhaCripto
    End Function

    Private Sub txt_redigita_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_redigita.Leave

        If Len(txt_redigita.Text) > 10 Then

            MsgBox("Senha com mais de 10 digitus!", MsgBoxStyle.Information)
            txt_redigita.Text = "" : Me.txt_redigita.Focus()
        End If

        If mResultado.Equals(mResultado2) = False Then

            MsgBox("Atenção ! " & Chr(10) & " Senhas Digitadas não conferem, Redigite !", MsgBoxStyle.Exclamation)
            Me.txt_redigita.Text = "" : Me.txt_senha.Focus()
        End If



    End Sub

    Private Function verificaGerente() As Boolean

        If Me.cbo_local.SelectedIndex < _valorZERO Then

            MsgBox("Favor informe o LOCAL para o Gerente", MsgBoxStyle.Exclamation)
            cbo_local.Focus() : cbo_local.SelectAll() : Return False
        End If

        If txt_nome.Text.Equals("") Then

            MsgBox("Favor informe o NOME do Gerente", MsgBoxStyle.Exclamation)
            txt_senha.Focus() : txt_senha.SelectAll() : Return False
        End If

        If txt_senha.Text.Equals("") Then

            MsgBox("Favor informe sua Senha", MsgBoxStyle.Exclamation)
            txt_senha.Focus() : txt_senha.SelectAll() : Return False
        End If

        If Me.txt_senha.Text.Equals(Me.txt_redigita.Text) = False Then

            MsgBox("Atenção ! " & Chr(10) & "Senhas Digitadas não conferem, Redigite !", MsgBoxStyle.Exclamation)
            Me.txt_senhaAtual.SelectAll() : Return False
        End If

        If Me.txt_senhaAtual.Text.Equals(_senhaGerente) = False Then

            MsgBox("Atenção ! " & Chr(10) & " SenhaAtual incorreta!", MsgBoxStyle.Exclamation)
            Me.txt_senhaAtual.SelectAll() : Return False
        End If



        Return True
    End Function

    Private Sub limpaCamposGerente()

        Me.txt_nome.Text = "" : Me.txt_senhaAtual.Text = "" : _senhaGerente = ""
        Me.txt_codGerente.Text = "" : Me.txt_senha.Text = "" : Me.txt_redigita.Text = ""
        Me.chk_libDesconto.Checked = False : Me.chk_libValor.Checked = False
        Me.chk_privilegioLojas.Checked = False : _idGerente = _valorZERO
        Me.txt_libVlrMaximo.Text = "0,00" : Me.cbo_local.SelectedIndex = -1


    End Sub

    Private Sub inclueGerente(ByVal gerente As String, ByVal senha As String, ByVal libdesc As Boolean, _
                          ByVal libvalor As Boolean, ByVal libmax As Double, _
                          ByVal privilegioLojas As Boolean, ByVal local As String)

        local = Trim(local.Substring(0, 5))
        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            Try
                conection.Open()

            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            Dim mCodGerente As Int32 = _clBD.trazProxCodGerente(conection)
            transacao = conection.BeginTransaction
            _clBD.incGerente(conection, transacao, gerente, senha, libdesc, libvalor, libmax, _
                             mCodGerente, privilegioLojas, local)
            transacao.Commit()

            If MessageBox.Show("Gerente salvo com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                limpaCamposGerente() : conection.ClearPool() : conection.Close() : Me.txt_nome.Focus()

            Else

                limpaCamposGerente() : _incluindo = False : _alterando = False
                conection.ClearPool() : conection.Close()
                tbc_Gerente.SelectTab(0) : Me.Dtg_Gerente.Rows.Clear() : Me.Dtg_Gerente.Refresh()
                Me.txt_pesquisa.Text = "" : preencheDtg_Gerente("%") : Me.txt_pesquisa.Focus()

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

    Private Sub alteraGerente(ByVal idGerente As Int32, ByVal gerente As String, ByVal senha As String, _
                              ByVal libdesc As Boolean, ByVal libvalor As Boolean, ByVal libmax As Double, _
                              ByVal privilegioLojas As Boolean, ByVal local As String)

        local = Trim(local.Substring(0, 5))
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
            _clBD.altGerente(conection, transacao, idGerente, gerente, senha, libdesc, libvalor, _
                             libmax, privilegioLojas, local)
            transacao.Commit()

            MsgBox("Gerente salvo com sucesso!", MsgBoxStyle.Exclamation)
            limpaCamposGerente() : _incluindo = False : _alterando = False
            conection.ClearPool() : conection.Close()
            tbc_Gerente.SelectTab(0) : Me.Dtg_Gerente.Rows.Clear() : Me.Dtg_Gerente.Refresh()
            Me.txt_pesquisa.Text = "" : preencheDtg_Gerente("%") : Me.txt_pesquisa.Focus()


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

    Private Sub txt_login_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'permite só letras
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_nome_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nome.KeyPress, txt_codGerente.KeyPress
        'permite só letras
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub Frm_CadGerente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Dtg_Gerente.Rows.Clear() : Me.Dtg_Gerente.Refresh() : preencheDtg_Gerente("%")
        Me.txt_pesquisa.Focus() : Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try

            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            Me.cbo_local = trazGenoCbo_local(conection, Me.cbo_local)
            conection.ClearPool() : conection.Close()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)

        Finally
            conection = Nothing
        End Try



    End Sub

    Private Sub preencheDtg_Gerente(ByVal pesquisa As String)

        Dim nomeCampo As String = ""
        nomeCampo = "gr_gerente"

        Try
            If _oConnBDMETROSYS.State = ConnectionState.Closed Then _oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        If _oConnBDMETROSYS.State = ConnectionState.Open Then

            Dim mnome, mvalor, mcodigo, mlocal As String
            Dim mlibDesconto, mlibValor, mprivilegioLojas As Boolean
            Dim id As Int32 = _valorZERO

            Try

                _cmdGerente.CommandText = "" : _sqlGerente.Remove(0, _sqlGerente.ToString.Length)

                _sqlGerente.Append("SELECT gr_id, gr_cod, gr_gerente, gr_libdesc, gr_libvalor, gr_libmax, ") '5
                _sqlGerente.Append("gr_privilegiolojas, gr_local FROM cadgerente WHERE ")
                _sqlGerente.Append("UPPER(" & nomeCampo & ") LIKE @pesquisa ORDER BY gr_gerente ASC")

                _cmdGerente = New NpgsqlCommand(_sqlGerente.ToString, _oConnBDMETROSYS)
                _cmdGerente.Parameters.Add("@pesquisa", pesquisa & "%")
                _drGerente = _cmdGerente.ExecuteReader

                Dtg_Gerente.Rows.Clear()
                'If _drGerente.HasRows = False Then Return
                While _drGerente.Read

                    id = _drGerente(0)
                    mcodigo = String.Format("{0:D3}", _drGerente(1))
                    mnome = _drGerente(2).ToString
                    mlibDesconto = _drGerente(3)
                    mlibValor = _drGerente(4)
                    mvalor = Format(_drGerente(5), "###,##0.00")
                    mprivilegioLojas = _drGerente(6)
                    mlocal = _drGerente(7).ToString


                    Dtg_Gerente.Rows.Add(id, mlocal, mcodigo, mnome, mprivilegioLojas, mlibDesconto, _
                                         mlibValor, mvalor)

                End While

                Dtg_Gerente.Refresh()
                _drGerente.Close() : _oConnBDMETROSYS.ClearPool()

            Catch ex As Exception
                MsgBox("ERRO no SELECT do GERENTE:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                _cmdGerente.CommandText = "" : _sqlGerente.Remove(0, _sqlGerente.ToString.Length)
                Return

            End Try

            _cmdGerente.CommandText = "" : _sqlGerente.Remove(0, _sqlGerente.ToString.Length)

            'Limpa Objetos de Memoria...
            mnome = Nothing : mvalor = Nothing : mlibDesconto = Nothing : mlibValor = Nothing
            id = Nothing
        End If



    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        If _incluindo = True OrElse _alterando = True Then

            If MessageBox.Show("Operação em aberto! Ela será Subistituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False : tbc_Gerente.SelectTab(1) : limpaCamposGerente()
                Me.cbo_local.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True
                configTelaNormal()

            End If
        Else

            _incluindo = True : _alterando = False : tbc_Gerente.SelectTab(1) : limpaCamposGerente()
            Me.cbo_local.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True
            configTelaNormal()
        End If



    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _alterando = True : _incluindo = False : tbc_Gerente.SelectTab(1) : limpaCamposGerente()
                _idGerente = Dtg_Gerente.CurrentRow.Cells(0).Value : configTelaEditando()
                trazGerenteSelecionado() : cbo_local.Focus() : tbp_manutencao.Text = "Alterando"
                btn_salvar.Enabled = True


            End If
        Else

            _alterando = True : _incluindo = False : tbc_Gerente.SelectTab(1) : limpaCamposGerente()
            _idGerente = Dtg_Gerente.CurrentRow.Cells(0).Value : configTelaEditando()
            trazGerenteSelecionado() : cbo_local.Focus() : tbp_manutencao.Text = "Alterando"
            btn_salvar.Enabled = True
        End If



    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If _incluindo = True OrElse _alterando = True Then 'Se tiver operação executando, então...

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                tbc_Gerente.SelectTab(0) : limpaCamposGerente() : tbp_manutencao.Text = "Gerente"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False : configTelaNormal()
                Me.Dtg_Gerente.Rows.Clear() : Me.Dtg_Gerente.Refresh() : preencheDtg_Gerente("%")
                Me.txt_pesquisa.Focus()

            End If
        End If



    End Sub

    Private Function trazGenoCbo_local(ByVal connection As NpgsqlConnection, _
                                  ByVal mCbo_local As ComboBox) As ComboBox

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return mCbo_local

        End Try

        If connection.State = ConnectionState.Open Then

            Try
                sql.Append("SELECT g_codig || ' - ' || g_geno AS ""Geno"" FROM ")
                sql.Append("geno001 ORDER BY g_codig;")
                cmd = New NpgsqlCommand(sql.ToString, connection)
                dr = cmd.ExecuteReader

                If dr.HasRows Then mCbo_local.Items.Clear() : mCbo_local.Refresh()

                While dr.Read

                    mCbo_local.Items.Add(dr(0).ToString)
                End While
                mCbo_local.Refresh()
                dr.Close() : connection.ClearPool()

            Catch ex As Exception
                MsgBox("ERRO no SELECT das LOJAS", MsgBoxStyle.Exclamation)
                Return mCbo_local

            End Try

            cmd.CommandText = ""
            sql.Remove(0, sql.ToString.Length)
        End If

        cmd = Nothing : sql = Nothing : dr = Nothing



        Return mCbo_local
    End Function

    Private Function trazIndexCboLocal(ByVal mLocal As String, ByVal mCboLOCAL As ComboBox) As Integer

        Dim index As Integer : Dim indiceLocal As Integer = -1
        For index = _valorZERO To mCboLOCAL.Items.Count - 1

            If mLocal.Equals(mCboLOCAL.Items.Item(index).ToString.Substring(_valorZERO, 5)) Then

                indiceLocal = index : Exit For

            End If
        Next


        Return indiceLocal
    End Function

    Private Sub trazGerenteSelecionado()

        Try
            If _oConnBDMETROSYS.State = ConnectionState.Closed Then _oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        If _oConnBDMETROSYS.State = ConnectionState.Open Then

            Try
                _sqlGerente.Append("SELECT gr_id, gr_gerente, gr_senha, gr_libdesc, gr_libvalor, gr_libmax, ") '5
                _sqlGerente.Append("gr_cod, gr_privilegiolojas, gr_local FROM cadgerente WHERE gr_id = @gr_id")

                _cmdGerente = New NpgsqlCommand(_sqlGerente.ToString, _oConnBDMETROSYS)
                _cmdGerente.Parameters.Add("@gr_id", _idGerente)
                _drGerente = _cmdGerente.ExecuteReader

                While _drGerente.Read

                    Me.txt_nome.Text = _drGerente(1).ToString
                    Me.txt_codGerente.Text = String.Format("{0:D3}", _drGerente(6))
                    _senhaGerente = _drGerente(2).ToString
                    Me.chk_libDesconto.Checked = _drGerente(3)
                    Me.chk_libValor.Checked = _drGerente(4)
                    Me.txt_libVlrMaximo.Text = Format(_drGerente(5), "###,##0.00")
                    Me.chk_privilegioLojas.Checked = _drGerente(7)

                    Try
                        Me.cbo_local.SelectedIndex = trazIndexCboLocal(_drGerente(8).ToString, Me.cbo_local)
                    Catch ex As Exception
                        Me.cbo_local.SelectedIndex = -1
                    End Try


                End While
                _drGerente.Close() : _oConnBDMETROSYS.ClearPool()

            Catch ex As Exception
                MsgBox("ERRO no SELECT do GERENTE", MsgBoxStyle.Exclamation)
                Return

            End Try

            _cmdGerente.CommandText = "" : _sqlGerente.Remove(0, _sqlGerente.ToString.Length)
        End If



    End Sub

    Private Sub configTelaNormal()

        lbl_senha.SetBounds(53, 80, 54, 18) : txt_senha.SetBounds(133, 77, 90, 24)
        lbl_redigite.SetBounds(53, 113, 65, 18) : txt_redigita.SetBounds(133, 109, 90, 24)

        chk_libValor.SetBounds(57, 145, 95, 21) 'chk_libValor.SetBounds(57, 172, 95, 21)
        chk_libDesconto.SetBounds(57, 172, 114, 21) 'chk_libDesconto.SetBounds(56, 145, 114, 21)
        chk_privilegioLojas.SetBounds(57, 199, 95, 21)

        lbl_libvalor.SetBounds(184, 171, 54, 18) : txt_libVlrMaximo.SetBounds(233, 168, 90, 24)
        lbl_senhaAtual.SetBounds(144, 260, 86, 18) : txt_senhaAtual.SetBounds(236, 257, 90, 24)
        lbl_senhaAtual.Visible = False : txt_senhaAtual.Visible = False

    End Sub

    Private Sub configTelaEditando()

        lbl_senha.SetBounds(53, 80, 54, 18) : txt_senha.SetBounds(133, 77, 90, 24)
        lbl_redigite.SetBounds(53, 113, 65, 18) : txt_redigita.SetBounds(133, 109, 90, 24)

        chk_libValor.SetBounds(57, 180, 87, 21)
        chk_libDesconto.SetBounds(58, 208, 114, 21)

        chk_privilegioLojas.SetBounds(58, 236, 122, 21)
        lbl_libvalor.SetBounds(184, 208, 46, 18) : txt_libVlrMaximo.SetBounds(233, 205, 90, 24)

        lbl_senhaAtual.SetBounds(41, 144, 86, 18) : txt_senhaAtual.SetBounds(133, 141, 90, 24)
        lbl_senhaAtual.Visible = True : txt_senhaAtual.Visible = True

    End Sub

    Private Sub txt_senhaAtual_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_senhaAtual.Leave

        If Me.txt_senhaAtual.Text.Equals(_senhaGerente) = False Then

            MsgBox("Atenção ! " & Chr(10) & " SenhaAtual incorreta!", MsgBoxStyle.Exclamation)
            Me.txt_senhaAtual.SelectAll()
        End If


    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        Me.preencheDtg_Gerente(Me.txt_pesquisa.Text)

    End Sub

    Private Sub txt_libVlrMaximo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_libVlrMaximo.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_libVlrMaximo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_libVlrMaximo.Leave

        If Me.txt_libVlrMaximo.ReadOnly = False Then

            If Me.txt_libVlrMaximo.Text.Equals("") Then Me.txt_libVlrMaximo.Text = Format(0.0, "###,##0.00")
            If IsNumeric(Me.txt_libVlrMaximo.Text) Then

                If CDec(Me.txt_libVlrMaximo.Text) <= _valorZERO Then

                    MsgBox("Valor Máximo deve ser maior que ZERO !", MsgBoxStyle.Exclamation)
                    Return
                End If
                Me.txt_libVlrMaximo.Text = Format(CDec(Me.txt_libVlrMaximo.Text), "###,##0.00")

            End If
        End If


    End Sub

    Private Sub cbo_local_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_local.GotFocus

        If Me.cbo_local.DroppedDown = False Then Me.cbo_local.DroppedDown = True
    End Sub

    Private Sub chk_libDesconto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_libDesconto.CheckedChanged

        If chk_libDesconto.Checked Then

            txt_libVlrMaximo.ReadOnly = False
        Else
            txt_libVlrMaximo.ReadOnly = True : txt_libVlrMaximo.Text = "0,00"
        End If

    End Sub
End Class