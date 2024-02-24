Imports System
Imports System.Text
Imports Npgsql

Public Class Frm_ConfiguraCupomFiscal
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private Const _valorZERO As Integer = 0
    Public _alterando As Boolean = False, _incluindo As Boolean = False
    Private _ufCorrenteCbo As String = ""

    'ultilizados para o DataGridView
    Private _oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Private _cmdImpressora As New NpgsqlCommand
    Private _sqlImpressora As New StringBuilder
    Private _drImpressora As NpgsqlDataReader
    Private _idImpressora As Int32 = _valorZERO
    Private _NFabricImpressora As String = ""
    Private _regMacImpressora As String = ""
    Private _tipoComissao As String = ""


    Private Sub Frm_ConfCupomFiscal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select


    End Sub

    Private Sub Frm_ConfCupomFiscal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub limpaCamposImpressora()

        Me.cbo_loja.SelectedIndex = -1 : Me.txt_caixa.Text = ""
        Me.cbo_impressora.SelectedIndex = -1
        Me.txt_numFabricacao.Text = "" : Me.txt_autorizacao.Text = ""
        Me.txt_lacre1.Text = "" : Me.txt_lacre2.Text = ""
        Me.txt_regMac.Text = "" : Me.txt_pafEcf.Text = ""
        Me.txt_codExterno.Text = ""

        _idImpressora = _valorZERO
        _regMacImpressora = "" : _NFabricImpressora = ""

    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        Try


            If (_incluindo = True) OrElse (_alterando = True) Then

                If MessageBox.Show("Operação em aberto! Ela será Subistituída!", "METROSYS", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    _incluindo = True : _alterando = False : tbc_impressora.SelectTab(1) : limpaCamposImpressora()
                    Me.cbo_loja.SelectedIndex = _clFuncoes.trazIndexCboLoja2(MdlEmpresaUsu._codigo, cbo_loja)
                    Me.cbo_loja.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True

                End If
            Else
                _incluindo = True : _alterando = False : tbc_impressora.SelectTab(1) : limpaCamposImpressora()
                Me.cbo_loja.SelectedIndex = _clFuncoes.trazIndexCboLoja2(MdlEmpresaUsu._codigo, cbo_loja)
                Me.cbo_loja.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True

            End If

        Catch ex As Exception
            lbl_mensagem01.Text = "ERRO:: " & ex.Message & "!"
        End Try



    End Sub

    Private Sub preencheDgrd_Impressora(ByVal pesquisa As String)

        Dim nomeCampo As String = ""
        lbl_mensagem01.Text = "" : nomeCampo = "v_nome"

        Try
            If _oConnBDMETROSYS.State = ConnectionState.Closed Then _oConnBDMETROSYS.Open()
        Catch ex As Exception
            lbl_mensagem01.Text = "ERRO:: " & ex.Message & "!" : Return

        End Try

        If _oConnBDMETROSYS.State = ConnectionState.Open Then
            Dim impressora, loja, caixa, mac, nfabricacao As String
            Dim id As Int32 = _valorZERO

            Try

                _sqlImpressora.Append("SELECT ec_id, ec_caixa, ec_geno, ec_modelo, ec_regmac, ec_autoriz, ") '5
                _sqlImpressora.Append("ec_lacre1, ec_lacre2, ec_nfabri, ec_codexterno ") '9
                _sqlImpressora.Append("FROM cdcaixa ") '4
                If MdlUsuarioLogando._usuarioPrivilegio = False Then _sqlImpressora.Append("WHERE ec_geno = @ec_geno")
                '_sqlImpressora.Append("UPPER(" & nomeCampo & ") LIKE '" & pesquisa & "%' ORDER BY v_nome ASC")
                _cmdImpressora = New NpgsqlCommand(_sqlImpressora.ToString, _oConnBDMETROSYS)
                If MdlUsuarioLogando._usuarioPrivilegio = False Then _cmdImpressora.Parameters.Add("@ec_geno", MdlEmpresaUsu._codigo)
                _drImpressora = _cmdImpressora.ExecuteReader

                dtg_Impressoras.Rows.Clear()
                While _drImpressora.Read
                    id = _drImpressora(0)
                    caixa = _drImpressora(1).ToString
                    loja = _drImpressora(2).ToString
                    impressora = _drImpressora(3).ToString
                    mac = _drImpressora(4).ToString
                    nfabricacao = _drImpressora(8).ToString

                    dtg_Impressoras.Rows.Add(id, caixa, loja, impressora, mac, nfabricacao)

                End While

                _drImpressora.Close()
            Catch ex As Exception
                lbl_mensagem01.Text = "ERRO:: " & ex.Message & "!"

            End Try

            _cmdImpressora.CommandText = ""
            _sqlImpressora.Remove(0, _sqlImpressora.ToString.Length)
            _oConnBDMETROSYS.ClearPool()

            'LIMPA OBJETOS DA MEMORIA...
            impressora = Nothing : loja = Nothing : caixa = Nothing : mac = Nothing
            id = Nothing
        End If



    End Sub

    Private Sub Frm_ConfCupomFiscal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cbo_loja = _clFuncoes.PreenchComboLoja2(cbo_loja, MdlConexaoBD.conectionPadrao)
        If MdlUsuarioLogando._usuarioPrivilegio = False Then Me.cbo_loja.Enabled = False
        limpaCamposImpressora()
        preencheDgrd_Impressora("%")


    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click


        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _alterando = True : _incluindo = False : tbc_impressora.SelectTab(1) : limpaCamposImpressora()
                _idImpressora = dtg_Impressoras.CurrentRow.Cells(0).Value
                _regMacImpressora = dtg_Impressoras.CurrentRow.Cells(4).Value
                _NFabricImpressora = dtg_Impressoras.CurrentRow.Cells(5).Value
                trazImpressoraSelecionado()
                cbo_loja.Focus() : tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True

            End If
        Else
            _alterando = True : _incluindo = False : tbc_impressora.SelectTab(1) : limpaCamposImpressora()
            _idImpressora = dtg_Impressoras.CurrentRow.Cells(0).Value
            _regMacImpressora = dtg_Impressoras.CurrentRow.Cells(4).Value
            _NFabricImpressora = dtg_Impressoras.CurrentRow.Cells(5).Value
            trazImpressoraSelecionado()
            cbo_loja.Focus() : tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True

        End If



    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", MessageBoxButtons.YesNo, _
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                tbc_impressora.SelectTab(0) : limpaCamposImpressora() : tbp_manutencao.Text = "Impressora"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False
                Me.dtg_Impressoras.Rows.Clear() : Me.dtg_Impressoras.Refresh() : preencheDgrd_Impressora("%")

            End If
        End If



    End Sub

    Private Sub trazImpressoraSelecionado()

        Try
            If _oConnBDMETROSYS.State = ConnectionState.Closed Then _oConnBDMETROSYS.Open()
        Catch ex As Exception
            lbl_mensagem01.Text = "ERRO:: " & ex.Message & "!" : Return

        End Try

        If _oConnBDMETROSYS.State = ConnectionState.Open Then
            Dim impressora, loja, caixa, mac As String
            Dim id As Int32 = _valorZERO

            Try
                _sqlImpressora.Append("SELECT ec_id, ec_caixa, ec_geno, ec_modelo, ec_regmac, ec_autoriz, ") '5
                _sqlImpressora.Append("ec_lacre1, ec_lacre2, ec_nfabri, ec_codexterno, ec_tipo, ec_pafecf ") '11
                _sqlImpressora.Append("FROM cdcaixa WHERE ec_id = @ec_id")

                _cmdImpressora = New NpgsqlCommand(_sqlImpressora.ToString, _oConnBDMETROSYS)
                _cmdImpressora.Parameters.Add("@ec_id", _idImpressora)
                _drImpressora = _cmdImpressora.ExecuteReader

                While _drImpressora.Read

                    Me.cbo_loja.SelectedIndex = _clFuncoes.trazIndexCboLoja2(_drImpressora(2).ToString, cbo_loja)
                    Me.txt_caixa.Text = _drImpressora(1).ToString
                    Me.cbo_impressora.SelectedIndex = _clFuncoes.trazIndexCboImpressora(_drImpressora(10), cbo_impressora)
                    Me.txt_numFabricacao.Text = _drImpressora(8).ToString
                    Me.txt_autorizacao.Text = _drImpressora(5).ToString
                    Me.txt_lacre1.Text = _drImpressora(6).ToString
                    Me.txt_lacre2.Text = _drImpressora(7).ToString
                    Me.txt_regMac.Text = _drImpressora(4).ToString
                    Me.txt_pafEcf.Text = _drImpressora(11).ToString
                    Me.txt_codExterno.Text = _drImpressora(9).ToString

                End While
                _drImpressora.Close()

            Catch ex As Exception
                lbl_mensagem01.Text = "ERRO:: " & ex.Message & "!"

            End Try


            _cmdImpressora.CommandText = ""
            _sqlImpressora.Remove(0, _sqlImpressora.ToString.Length)
            _oConnBDMETROSYS.ClearPool() : _oConnBDMETROSYS.Close()
        End If



    End Sub

    Private Function verificaImpressora() As Boolean

        lbl_mensagem02.Text = ""

        If Trim(Me.txt_caixa.Text).Equals("") Then

            lbl_mensagem02.Text = "Favor informe o CAIXA para a Impressora !"
            txt_caixa.Focus() : txt_caixa.SelectAll() : Return False

        End If

        If cbo_impressora.SelectedIndex < _valorZERO Then

            lbl_mensagem02.Text = "Favor informe a Impressora !"
            cbo_impressora.Focus() : cbo_impressora.SelectAll() : Return False

        End If

        If Trim(txt_numFabricacao.Text).Equals("") Then

            lbl_mensagem02.Text = "Favor informe o NUM. FABRICAÇÃO da Impressora !"
            txt_numFabricacao.Focus() : txt_numFabricacao.SelectAll() : Return False

        End If

        If Trim(txt_autorizacao.Text).Equals("") Then

            lbl_mensagem02.Text = "Favor informe a AUTORIZAÇÃO da Impressora !"
            txt_autorizacao.Focus() : txt_autorizacao.SelectAll() : Return False

        End If

        If Trim(txt_lacre1.Text).Equals("") Then

            lbl_mensagem02.Text = "Favor informe o Lacre1 da Impressora !"
            txt_lacre1.Focus() : txt_lacre1.SelectAll() : Return False

        End If

        If Trim(txt_regMac.Text).Equals("") Then

            lbl_mensagem02.Text = "Favor informe o MAC do Computador da Impressora !"
            txt_regMac.Focus() : txt_regMac.SelectAll() : Return False

        ElseIf Trim(txt_regMac.Text).Length <> 17 Then

            lbl_mensagem02.Text = "O MAC do Computador da Impressora deve ter 17 caracteres !"
            txt_regMac.Focus() : txt_regMac.SelectAll() : Return False
        End If



        Return True
    End Function

    Private Sub inclueImpressora(ByVal ec_caixa As String, ByVal ec_autoriz As String, ByVal ec_lacre1 As String, _
                          ByVal ec_lacre2 As String, ByVal ec_nfabri As String, ByVal ec_modelo As String, _
                          ByVal ec_geno As String, ByVal ec_codexterno As String, ByVal ec_regmac As String, _
                          ByVal ec_tipo As Integer, ByVal ec_pafecf As String)

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
            _clBD.incImpressora(conection, transacao, ec_caixa, ec_autoriz, ec_lacre1, ec_lacre2, _
                                ec_nfabri, ec_modelo, ec_geno, ec_codexterno, ec_regmac, _
                                ec_tipo, ec_pafecf)
            transacao.Commit() : conection.ClearPool()


            If MessageBox.Show("Impressora salvo com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                limpaCamposImpressora() : conection.Close() : Me.txt_regMac.Focus()
                Me.cbo_loja.SelectedIndex = _clFuncoes.trazIndexCboLoja2(MdlEmpresaUsu._codigo, cbo_loja)

            Else
                limpaCamposImpressora() : _incluindo = False : _alterando = False : conection.Close()
                Me.dtg_Impressoras.Rows.Clear() : Me.dtg_Impressoras.Refresh() : Me.txt_pesquisa.Text = ""
                preencheDgrd_Impressora("%") : Me.txt_pesquisa.Focus() : tbc_impressora.SelectTab(0)
                conection.ClearPool() : conection.Close()

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

    Private Sub alteraImpressora(ByVal ec_caixa As String, ByVal ec_autoriz As String, ByVal ec_lacre1 As String, _
                          ByVal ec_lacre2 As String, ByVal ec_nfabri As String, ByVal ec_modelo As String, _
                          ByVal ec_geno As String, ByVal ec_codexterno As String, ByVal ec_regmac As String, _
                          ByVal ec_tipo As Integer, ByVal ec_pafecf As String)

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
            _clBD.altImpressora(conection, transacao, _idImpressora, ec_caixa, ec_autoriz, ec_lacre1, _
                                ec_lacre2, ec_nfabri, ec_modelo, ec_geno, ec_codexterno, ec_regmac, _
                                ec_tipo, ec_pafecf)
            transacao.Commit() : conection.ClearPool()

            MsgBox("Impressora salvo com sucesso", MsgBoxStyle.Exclamation)
            limpaCamposImpressora() : _incluindo = False : _alterando = False : conection.Close()
            tbc_impressora.SelectTab(0) : Me.dtg_Impressoras.Rows.Clear() : Me.dtg_Impressoras.Refresh()
            Me.txt_pesquisa.Text = "" : preencheDgrd_Impressora("%") : Me.txt_pesquisa.Focus()

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

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click


        If verificaImpressora() Then

            Dim tipo As Integer = CInt(Me.cbo_impressora.SelectedItem.ToString.Substring(0, 1))

            If _incluindo = True Then

                Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Try
                    conection.Open()

                    If _clBD.existeMacImpressora(conection, Me.txt_regMac.Text) Then

                        lbl_mensagem02.Text = "Esse MAC do Computador da Impressora já existe em outra configuração !"
                        txt_regMac.Focus() : txt_regMac.SelectAll() : Return
                    End If

                    If _clBD.existeNFabricImpressora(conection, Me.txt_numFabricacao.Text) Then

                        lbl_mensagem02.Text = "Esse MAC do Computador da Impressora já existe em outra configuração !"
                        txt_regMac.Focus() : txt_regMac.SelectAll() : Return
                    End If
                    conection.ClearAllPools() : conection.Close()
                Catch ex As Exception
                    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                    Return

                End Try

                

                inclueImpressora(Me.txt_caixa.Text, Me.txt_autorizacao.Text, Me.txt_lacre1.Text, _
                               Me.txt_lacre2.Text, Me.txt_numFabricacao.Text, _
                               Me.cbo_impressora.SelectedItem.ToString.Substring(2), _
                      Me.cbo_loja.SelectedItem.ToString.Substring(0, 6), Me.txt_codExterno.Text, _
                      Me.txt_regMac.Text, tipo, Me.txt_pafEcf.Text)

            ElseIf _alterando = True Then

                Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Try
                    conection.Open()

                    If _clBD.existeMacImpressoraAlt(conection, Me.txt_regMac.Text, _regMacImpressora) Then

                        lbl_mensagem02.Text = "Esse MAC do Computador da Impressora já existe em outra configuração !"
                        txt_regMac.Focus() : txt_regMac.SelectAll() : Return
                    End If

                    If _clBD.existeNFabricImpressoraAlt(conection, Me.txt_numFabricacao.Text, _NFabricImpressora) Then

                        lbl_mensagem02.Text = "Esse MAC do Computador da Impressora já existe em outra configuração !"
                        txt_regMac.Focus() : txt_regMac.SelectAll() : Return
                    End If
                    conection.ClearAllPools() : conection.Close()
                Catch ex As Exception
                    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                    Return

                End Try

                alteraImpressora(Me.txt_caixa.Text, Me.txt_autorizacao.Text, Me.txt_lacre1.Text, _
                               Me.txt_lacre2.Text, Me.txt_numFabricacao.Text, _
                               Me.cbo_impressora.SelectedItem.ToString.Substring(2), _
                      Me.cbo_loja.SelectedItem.ToString.Substring(0, 6), Me.txt_codExterno.Text, _
                      Me.txt_regMac.Text, tipo, Me.txt_pafEcf.Text)


            End If
        End If



    End Sub

    Private Sub cbo_impressora_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_impressora.GotFocus
        If Me.cbo_impressora.DroppedDown = False Then Me.cbo_impressora.DroppedDown = True
    End Sub

    Private Sub cbo_loja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_loja.GotFocus
        If Me.cbo_loja.DroppedDown = False Then Me.cbo_loja.DroppedDown = True
    End Sub

    Private Sub txt_caixa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_caixa.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub btn_mac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mac.Click

        Me.txt_regMac.Text = _clFuncoes.EnderecoMac()
    End Sub

    Private Sub txt_codExterno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codExterno.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub executaF4()

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
            _clBD.delImpressora(conection, transacao, _idImpressora)
            transacao.Commit() : conection.ClearPool()

            MsgBox("Impressora deletada com sucesso", MsgBoxStyle.Exclamation)
            limpaCamposImpressora() : _incluindo = False : _alterando = False : conection.Close()
            tbc_impressora.SelectTab(0) : Me.dtg_Impressoras.Rows.Clear() : Me.dtg_Impressoras.Refresh()
            Me.txt_pesquisa.Text = "" : preencheDgrd_Impressora("%") : Me.txt_pesquisa.Focus()

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

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click

        If Me.dtg_Impressoras.CurrentRow.IsNewRow = False Then

            If MessageBox.Show("Deseja realmente deletar essa configuração?", "METROSYS", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                executaF4()
            End If
        End If


    End Sub
End Class