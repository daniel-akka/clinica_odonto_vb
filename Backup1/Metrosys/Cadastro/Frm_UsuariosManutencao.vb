Imports System
Imports System.Text
Imports Npgsql

Public Class Frm_UsuariosManutencao
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private _clUsuario As New Cl_Usuario
    Public _clUsuarioTelas As New Cl_UsuarioTelas
    Private Const _valorZERO As Integer = 0
    Public Shared _frmRef As New Frm_UsuariosManutencao
    Dim mResultado, mResultado2 As String
    Public _alterando As Boolean = False, _incluindo As Boolean = False
    Dim _acessos As Integer = 0

    'ultilizados para o DataGridView
    Private _oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Private _cmdUsuario As New NpgsqlCommand
    Private _sqlUsuario As New StringBuilder
    Private _drUsuario As NpgsqlDataReader
    Private _idUsuario As Int32 = _valorZERO
    Private _senhaUsuario As String = ""


    Private Sub Frm_UsuariosManutenção_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F5
                executaF5()
            Case Keys.Escape
                Me.Close()
        End Select


    End Sub

    Private Sub executaF5()

        preencheDgrd_Usuario(Me.txt_pesquisa.Text)

    End Sub

    Private Sub btn_acesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_acesso.Click

        If _incluindo = True And _alterando = False AndAlso _acessos = 0 Then

            '_clUsuarioTelas.pTl_Cadastros = True : _clUsuarioTelas.pTl_movimentos = True : _clUsuarioTelas.pTl_mapas = True
            '_clUsuarioTelas.pTl_cupom = True : _clUsuarioTelas.pTl_estoque = True : _clUsuarioTelas.pTl_financeiro = True
            '_clUsuarioTelas.pTl_manutencao = True : _clUsuarioTelas.pTl_manutencao = True : _clUsuarioTelas.pTl_contabil = True
            '_clUsuarioTelas.pTl_parametros = True
        End If

        Dim _usuAcessos As New Frm_UsuariosAcessos : _frmRef = Me
        Try
            _usuAcessos._frmRefAcesso.ShowDialog()
            _acessos = 1
        Catch ex As Exception
            _usuAcessos.ShowDialog()
        End Try


    End Sub

    Private Sub btn_gravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        mResultado = criptografaSenha(Me.txt_senha.Text) : mResultado2 = criptografaSenha(Me.txt_redigita.Text)

        If mResultado <> mResultado2 Then

            MsgBox("Atenção ! " & Chr(10) & "Senhas Digitadas não conferem, Redigite !", MsgBoxStyle.Exclamation)
            Me.txt_senha.Text = "" : Me.txt_redigita.Text = "" : Me.txt_senha.Focus()
            Return

        End If

        If verificaUsuario() Then

            If MessageBox.Show("Verifique as telas de Acesso! Deseja Continuar?", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
             Windows.Forms.DialogResult.Yes Then

                If _incluindo = True Then
                    Try
                        inclueUsuario(Me.cbo_local.SelectedItem, Me.txt_nome.Text, Me.txt_login.Text, mResultado, Me.chk_privilegio.Checked, _
                          chk_bloqueado.Checked, msk_dtnascimento.Text, Mid(cbo_vendedor.SelectedItem, 1, 6), CInt(Trim(Mid(cbo_cargoUsuario.SelectedItem.ToString, 1, 2))), _
                          Mid(cbo_caixa.SelectedItem.ToString, 1, 3))
                    Catch ex As Exception
                        inclueUsuario(Me.cbo_local.SelectedItem, Me.txt_nome.Text, Me.txt_login.Text, mResultado, Me.chk_privilegio.Checked, _
                          chk_bloqueado.Checked, msk_dtnascimento.Text, Mid(cbo_vendedor.SelectedItem, 1, 6), CInt(Trim(Mid(cbo_cargoUsuario.SelectedItem.ToString, 1, 2))), _
                          "")
                    End Try
                    

                ElseIf _alterando = True Then
                    Try
                        alteraUsuario(Me.cbo_local.SelectedItem, Me.txt_nome.Text, Me.txt_login.Text, mResultado, Me.chk_privilegio.Checked, _
                         chk_bloqueado.Checked, msk_dtnascimento.Text, Mid(cbo_vendedor.SelectedItem, 1, 6), CInt(Trim(Mid(cbo_cargoUsuario.SelectedItem.ToString, 1, 2))), _
                          Mid(cbo_caixa.SelectedItem.ToString, 1, 3))
                    Catch ex As Exception
                        alteraUsuario(Me.cbo_local.SelectedItem, Me.txt_nome.Text, Me.txt_login.Text, mResultado, Me.chk_privilegio.Checked, _
                         chk_bloqueado.Checked, msk_dtnascimento.Text, Mid(cbo_vendedor.SelectedItem, 1, 6), CInt(Trim(Mid(cbo_cargoUsuario.SelectedItem.ToString, 1, 2))), _
                          "")
                    End Try


                End If

            End If
        End If



    End Sub

    Private Sub Frm_UsuariosManutencao_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

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
        If mResultado <> mResultado2 Then

            MsgBox("Atenção ! " & Chr(10) & "Senhas Digitadas não conferem, Redigite !", MsgBoxStyle.Exclamation)
            Me.txt_redigita.Text = "" : Me.txt_senha.Focus()

        End If



    End Sub

    Private Function verificaUsuario() As Boolean

        If Me.cbo_local.SelectedIndex < _valorZERO Then

            MsgBox("Favor informe o LOCAL para o usuario", MsgBoxStyle.Exclamation)
            cbo_local.Focus() : cbo_local.SelectAll() : Return False
        End If

        If txt_nome.Text.Equals("") Then

            MsgBox("Favor informe o NOME de usuario", MsgBoxStyle.Exclamation)
            txt_senha.Focus() : txt_senha.SelectAll() : Return False
        End If

        If txt_login.Text.Equals("") Then

            MsgBox("Favor informe seu Login", MsgBoxStyle.Exclamation)
            txt_login.Focus() : txt_login.SelectAll() : Return False
        End If

        If txt_senha.Text.Equals("") Then

            MsgBox("Favor informe sua Senha", MsgBoxStyle.Exclamation)
            txt_senha.Focus() : txt_senha.SelectAll() : Return False
        End If

        If criptografaSenha(Me.txt_senha.Text) <> criptografaSenha(Me.txt_redigita.Text) Then

            MsgBox("Atenção ! " & Chr(10) & "Senhas Digitadas não conferem, Redigite !", MsgBoxStyle.Exclamation)
            Me.txt_senhaAtual.SelectAll() : Return False
        End If

        If criptografaSenha(Me.txt_senhaAtual.Text) <> _senhaUsuario Then

            MsgBox("Atenção ! " & Chr(10) & "SenhaAtual incorreta!", MsgBoxStyle.Exclamation)
            Me.txt_senhaAtual.SelectAll() : Return False
        End If



        Return True
    End Function

    Private Sub limpaCamposUsuario()

        Me.txt_nome.Text = "" : Me.txt_login.Text = "" : Me.txt_senhaAtual.Text = "" : _senhaUsuario = ""
        Me.txt_senha.Text = "" : Me.txt_redigita.Text = "" : Me.msk_dtnascimento.Text = ""
        Me.chk_privilegio.Checked = False : Me.chk_bloqueado.Checked = False : _idUsuario = _valorZERO
        Me.cbo_cargoUsuario.SelectedIndex = -1

        Try
            Me.cbo_local.SelectedIndex = -1
            Me.cbo_vendedor.SelectedIndex = -1
        Catch ex As Exception
        End Try

        Try
            Me.cbo_caixa.SelectedItem = -1 : Me.cbo_caixa.Visible = False : Me.lbl_caixa.Visible = False
        Catch ex As Exception

        End Try


        'telas do Usuario...
        _clUsuarioTelas.pTl_Cadastros = False : _clUsuarioTelas.pTl_cadcliente = False : _clUsuarioTelas.pTl_cadvendedor = False
        _clUsuarioTelas.pTl_cadusuario = False : _clUsuarioTelas.pTl_cadtitular = False : _clUsuarioTelas.pTl_cadcidade = False
        _clUsuarioTelas.pTl_cadservico = False : _clUsuarioTelas.pTl_cadgeno = False : _clUsuarioTelas.pTl_cadcomodato = False
        _clUsuarioTelas.pTl_cadautomovel = False : _clUsuarioTelas.pTl_cadgerais = False : _clUsuarioTelas.pTl_cadgerente = False
        _clUsuarioTelas.pTl_movimentos = False : _clUsuarioTelas.pTl_movpedido = False : _clUsuarioTelas.pTl_movorcamento = False
        _clUsuarioTelas.pTl_movtransferencia = False : _clUsuarioTelas.pTl_movnfe = False : _clUsuarioTelas.pTl_movrequisicao = False
        _clUsuarioTelas.pTl_movemisspedido = False : _clUsuarioTelas.pTl_movgeramapa = False : _clUsuarioTelas.pTl_mapas = False
        _clUsuarioTelas.pTl_mpvenda = False : _clUsuarioTelas.pTl_mpretornovenda = False : _clUsuarioTelas.pTl_cupom = False
        _clUsuarioTelas.pTl_cpprevenda = False : _clUsuarioTelas.pTl_cpvendadireta = False : _clUsuarioTelas.pTl_cpconfiguracao = False
        _clUsuarioTelas.pTl_estoque = False : _clUsuarioTelas.pTl_estpesquisa = False : _clUsuarioTelas.pTl_estrestaura = False
        _clUsuarioTelas.pTl_estimplantacao = False : _clUsuarioTelas.pTl_estpedidocompras = False : _clUsuarioTelas.pTl_estcompras = False
        _clUsuarioTelas.pTl_estatualizacao = False : _clUsuarioTelas.pTl_estrelatorios = False : _clUsuarioTelas.pTl_financeiro = False
        _clUsuarioTelas.pTl_finpagamentos = False : _clUsuarioTelas.pTl_finrecebimentos = False : _clUsuarioTelas.pTl_finfluxocaixa = False
        _clUsuarioTelas.pTl_findespesas = False : _clUsuarioTelas.pTl_finchqPreDatado = False : _clUsuarioTelas.pTl_manutencao = False
        _clUsuarioTelas.pTl_manemprestimos = False : _clUsuarioTelas.pTl_mantrocas = False : _clUsuarioTelas.pTl_manpalmtop = False
        _clUsuarioTelas.pTl_mancidadesibge = False : _clUsuarioTelas.pTl_contabil = False : _clUsuarioTelas.pTl_ctbarqdigitais = False
        _clUsuarioTelas.pTl_ctblivrosfiscais = False : _clUsuarioTelas.pTl_ctbcontador = False : _clUsuarioTelas.pTl_ctbcfop = False
        _clUsuarioTelas.pTl_parametros = False : _clUsuarioTelas.pTl_paracontrole = False : _clUsuarioTelas.pTl_paraultilitarios = False
        _clUsuarioTelas.pTl_parabackup = False

        _clUsuarioTelas.pBtn_cancelarExcluir = False



    End Sub

    Private Sub inclueUsuarioTelas2(ByVal idUsuario As Int32, ByVal conection As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        _clUsuarioTelas.pIdUsuario = idUsuario
        If conection.State = ConnectionState.Closed Then conection.Open()
        _clBD.incUsuarioTelas(_clUsuarioTelas, conection, transacao)



    End Sub

    Private Sub inclueUsuarioTelas(ByVal conection As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim resultadoLogin As Boolean = False
        Dim _sqlUsuario As New StringBuilder
        Dim _cmdUsuario As NpgsqlCommand
        Dim _drUsuario As NpgsqlDataReader
        Dim idUsuario As Int32 = _valorZERO
        Try
            If conection.State = ConnectionState.Closed Then conection.Open()

            If conection.State = ConnectionState.Open Then
                Try
                    _sqlUsuario.Append("SELECT MAX(u_id) FROM usuario")
                    _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                    _drUsuario = _cmdUsuario.ExecuteReader

                    If _drUsuario.HasRows = True Then

                        While _drUsuario.Read

                            idUsuario = _drUsuario(0)
                        End While
                        _drUsuario.Close()

                        inclueUsuarioTelas2(idUsuario, conection, transacao)
                    End If

                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                    resultadoLogin = False

                End Try

                _cmdUsuario.CommandText = ""
                _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
            End If

            conection.ClearPool()

        Catch ex_ As Exception
            MsgBox("ERRO:: " & ex_.Message, MsgBoxStyle.Critical)

        Finally
            _sqlUsuario = Nothing : _cmdUsuario = Nothing : _drUsuario = Nothing : conection = Nothing

        End Try



    End Sub

    Private Sub inclueUsuario(ByVal local As String, ByVal nome As String, ByVal login As String, ByVal senhaCripto As String, _
                          ByVal privilegio As Boolean, ByVal bloqueado As Boolean, ByVal dataNascimento As Date, _
                          ByVal codvendedor As String, ByVal cargo As Integer, ByVal codcaixa As String)

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

            _clUsuario.pLocal = local
            _clUsuario.pNome = nome
            _clUsuario.pLogin = login
            _clUsuario.pSenha = senhaCripto
            _clUsuario.pPrivilegio = privilegio
            _clUsuario.pBloqueado = bloqueado
            _clUsuario.pDataNascimento = dataNascimento
            _clUsuario.pCodVendedor = codvendedor
            _clUsuario.pCargo = cargo
            _clUsuario.pCodCaixa = codcaixa


            transacao = conection.BeginTransaction
            _clBD.incUsuario(_clUsuario, conection, transacao)
            inclueUsuarioTelas(conection, transacao)
            _clBD.altLojaVendedor(_clUsuario.pLocal, _clUsuario.pCodVendedor, conection, transacao)
            transacao.Commit() : conection.ClearPool()

            If MessageBox.Show("Usuario salvo com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                limpaCamposUsuario() : conection.Close() : Me.txt_nome.Focus()

            Else

                limpaCamposUsuario() : _incluindo = False : _alterando = False : conection.Close()
                tbc_usuario.SelectTab(0) : Me.Dg_usuario.Rows.Clear() : Me.Dg_usuario.Refresh()
                Me.txt_pesquisa.Text = "" : preencheDgrd_Usuario("%") : Me.txt_pesquisa.Focus()

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

    Private Sub alteraUsuarioTelas2(ByVal idUsuario As Int32, ByVal conection As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        _clUsuarioTelas.pIdUsuario = idUsuario
        If conection.State = ConnectionState.Closed Then conection.Open()
        _clBD.altUsuarioTelas(_clUsuarioTelas, conection, transacao)


    End Sub

    Private Sub alteraUsuarioTelas(ByVal conection As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim idUsuario As Int32 = _valorZERO
        If conection.State = ConnectionState.Closed Then conection.Open()
        If conection.State = ConnectionState.Open Then

            alteraUsuarioTelas2(_idUsuario, conection, transacao)

        End If



    End Sub

    Private Sub alteraUsuario(ByVal local As String, ByVal nome As String, ByVal login As String, _
                              ByVal senhaCripto As String, ByVal privilegio As Boolean, _
                              ByVal bloqueado As Boolean, ByVal dataNascimento As Date, _
                              ByVal codvendedor As String, ByVal cargo As Integer, ByVal codcaixa As String)

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

            _clUsuario.pLocal = local
            _clUsuario.pNome = nome
            _clUsuario.pLogin = login
            _clUsuario.pSenha = senhaCripto
            _clUsuario.pPrivilegio = privilegio
            _clUsuario.pBloqueado = bloqueado
            _clUsuario.pDataNascimento = dataNascimento
            _clUsuario.pCodVendedor = codvendedor
            _clUsuario.pCargo = cargo
            _clUsuario.pCodCaixa = codcaixa


            transacao = conection.BeginTransaction
            _clBD.altUsuario(_clUsuario, _idUsuario, conection, transacao)
            alteraUsuarioTelas(conection, transacao)
            _clBD.altLojaVendedor(_clUsuario.pLocal, _clUsuario.pCodVendedor, conection, transacao)
            transacao.Commit() : conection.ClearAllPools()

            MsgBox("Usuario salvo com sucesso!", MsgBoxStyle.Exclamation)
            limpaCamposUsuario() : _incluindo = False : _alterando = False : conection.Close()
            tbc_usuario.SelectTab(0) : Me.Dg_usuario.Rows.Clear() : Me.Dg_usuario.Refresh()
            Me.txt_pesquisa.Text = "" : preencheDgrd_Usuario("%") : Me.txt_pesquisa.Focus()


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

    Private Sub txt_login_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_login.KeyPress
        'permite só letras
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_nome_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nome.KeyPress
        'permite só letras
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub msk_dtnascimento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtnascimento.Leave

        If Me.msk_dtnascimento.Text.Length > _valorZERO Then

            If (Not IsDate(Me.msk_dtnascimento.Text)) OrElse (Me.msk_dtnascimento.Text.Length < 10) Then

                MsgBox("Data de Nascimento Inválida", MsgBoxStyle.Exclamation)
                msk_dtnascimento.Focus() : msk_dtnascimento.SelectAll()
                Return


            End If
        End If



    End Sub

    Private Sub Frm_UsuariosManutencao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Dg_usuario.Rows.Clear() : Me.Dg_usuario.Refresh() : preencheDgrd_Usuario("%")
        Me.txt_pesquisa.Focus() : Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try

            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            Me.cbo_local = trazGenoCbo_local(conection, Me.cbo_local)
            Me.cbo_vendedor = _clFuncoes.PreenchComboVendedores(Me.cbo_vendedor, MdlConexaoBD.conectionPadrao)
            Me.cbo_cargoUsuario = _clFuncoes.PreenchComboCargoUsuario(Me.cbo_cargoUsuario, MdlConexaoBD.conectionPadrao)
            Me.cbo_caixa = _clFuncoes.PreenchComboCaixa(Me.cbo_caixa, MdlConexaoBD.conectionPadrao)
            conection.ClearPool() : conection.Close()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)

        Finally
            conection = Nothing
        End Try



    End Sub

    Private Sub preencheDgrd_Usuario(ByVal pesquisa As String)

        Dim nomeCampo As String = ""
        nomeCampo = "u_nome"

        Try
            If _oConnBDMETROSYS.State = ConnectionState.Closed Then _oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        If _oConnBDMETROSYS.State = ConnectionState.Open Then
            Dim nome, login, codcaixa As String
            Dim privilegio, bloqueado As Boolean
            Dim id As Int32 = _valorZERO

            Try
                Try
                    _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
                    _cmdUsuario.CommandText = ""
                Catch ex As Exception
                End Try

                _sqlUsuario.Append("SELECT u_id, u_nome, u_login, u_privilegio, u_bloqueado, u_codcaixa FROM usuario WHERE ") '4
                _sqlUsuario.Append("UPPER(" & nomeCampo & ") LIKE '" & pesquisa & "%' ORDER BY u_nome ASC")
                _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, _oConnBDMETROSYS)
                _drUsuario = _cmdUsuario.ExecuteReader

                Dg_usuario.Rows.Clear()
                If _drUsuario.HasRows = False Then Return
                While _drUsuario.Read
                    id = _drUsuario(0)
                    nome = _drUsuario(1).ToString
                    login = _drUsuario(2).ToString
                    privilegio = _drUsuario(3)
                    bloqueado = _drUsuario(4)

                    Dg_usuario.Rows.Add(id, nome, login, privilegio, bloqueado)

                End While

                Dg_usuario.Refresh()
                _drUsuario.Close()
                _oConnBDMETROSYS.ClearPool()

            Catch ex As Exception
                MsgBox("ERRO no SELECT do USUARIO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            _cmdUsuario.CommandText = ""
            _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)

            'Limpa Objetos de Memoria...
            nome = Nothing : login = Nothing : privilegio = Nothing : bloqueado = Nothing
            id = Nothing
        End If



    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        If (_incluindo = True) OrElse (_alterando = True) Then

            If MessageBox.Show("Operação em aberto! Ela será Subistituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False : tbc_usuario.SelectTab(1) : limpaCamposUsuario()
                Me.txt_nome.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True
                configTelaNormal()

            End If

        Else
            _incluindo = True : _alterando = False : tbc_usuario.SelectTab(1) : limpaCamposUsuario()
            Me.txt_nome.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True
            configTelaNormal()

        End If



    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _alterando = True : _incluindo = False : tbc_usuario.SelectTab(1) : limpaCamposUsuario()
                _idUsuario = Dg_usuario.CurrentRow.Cells(0).Value : configTelaEditando()
                trazUsuarioSelecionado() : txt_nome.Focus() : tbp_manutencao.Text = "Alterando"
                btn_salvar.Enabled = True


            End If

        Else
            _alterando = True : _incluindo = False : tbc_usuario.SelectTab(1) : limpaCamposUsuario()
            _idUsuario = Dg_usuario.CurrentRow.Cells(0).Value : configTelaEditando()
            trazUsuarioSelecionado() : txt_nome.Focus() : tbp_manutencao.Text = "Alterando"
            btn_salvar.Enabled = True

        End If



    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If _incluindo = True OrElse _alterando = True Then 'Se tiver operação executando, então...

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                tbc_usuario.SelectTab(0) : limpaCamposUsuario() : tbp_manutencao.Text = "Usuario"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False : configTelaNormal()
                Me.Dg_usuario.Rows.Clear() : Me.Dg_usuario.Refresh() : preencheDgrd_Usuario("%")
                Me.txt_pesquisa.Focus()

            End If
        End If



    End Sub

    Private Function trazGenoCbo_local(ByVal connection As NpgsqlConnection, _
                                  ByVal mCbo_local As ComboBox) As ComboBox

        Dim _cmdGeno As New NpgsqlCommand
        Dim _sqlGeno As New StringBuilder
        Dim _drGeno As NpgsqlDataReader

        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return mCbo_local

        End Try

        If connection.State = ConnectionState.Open Then

            Try
                _sqlGeno.Append("SELECT g_codig || ' - ' || g_geno AS ""Geno"" FROM ")
                _sqlGeno.Append("geno001 ORDER BY g_codig;")
                _cmdGeno = New NpgsqlCommand(_sqlGeno.ToString, connection)
                _drGeno = _cmdGeno.ExecuteReader

                If _drGeno.HasRows Then mCbo_local.Items.Clear() : mCbo_local.Refresh()

                While _drGeno.Read

                    mCbo_local.Items.Add(_drGeno(0).ToString)
                End While
                mCbo_local.Refresh()
                _drGeno.Close()

            Catch ex As Exception
                MsgBox("ERRO no SELECT das LOJAS", MsgBoxStyle.Exclamation)
                Return mCbo_local

            End Try

            _cmdGeno.CommandText = ""
            _sqlGeno.Remove(0, _sqlGeno.ToString.Length)
        End If

        _cmdGeno = Nothing : _sqlGeno = Nothing : _drGeno = Nothing



        Return mCbo_local
    End Function

    Private Function trazIndexLocal(ByVal mLocal As String, ByVal mCboLOCAL As ComboBox) As Integer

        Dim index As Integer : Dim indiceLocal As Integer = -1
        For index = _valorZERO To mCboLOCAL.Items.Count - 1

            If mLocal.Equals(mCboLOCAL.Items.Item(index).ToString.Substring(_valorZERO, 5)) Then

                indiceLocal = index : Exit For

            End If
        Next



        Return indiceLocal
    End Function

    Private Sub trazUsuarioSelecionado()

        Try
            If _oConnBDMETROSYS.State = ConnectionState.Closed Then _oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        If _oConnBDMETROSYS.State = ConnectionState.Open Then

            Try
                _sqlUsuario.Append("SELECT u.u_id, u.u_nome, u.u_login, u.u_senha, u.u_datanascimento, u.u_privilegio, ") '5
                _sqlUsuario.Append("u.u_bloqueado, utl.tl_cadastros, utl.tl_cadcliente, utl.tl_cadvendedor, ") '9
                _sqlUsuario.Append("utl.tl_cadusuario, utl.tl_cadtitular, utl.tl_cadcidade, utl.tl_cadservico, utl.tl_cadgeno, ") '14
                _sqlUsuario.Append("utl.tl_movimentos, utl.tl_movpedido, utl.tl_movorcamento, utl.tl_movtransferencia, ") '18
                _sqlUsuario.Append("utl.tl_movnfe, utl.tl_cupom, utl.tl_cpprevenda, utl.tl_cpvendadireta, utl.tl_cpconfiguracao, ") '23
                _sqlUsuario.Append("utl.tl_estoque, utl.tl_estpesquisa, utl.tl_estrestaura, utl.tl_estimplantacao, ") '27
                _sqlUsuario.Append("utl.tl_estpedidocompras, utl.tl_estcompras, utl.tl_estatualizacao, utl.tl_financeiro, ") '31
                _sqlUsuario.Append("utl.tl_finpagamentos, utl.tl_finrecebimentos, utl.tl_finfluxocaixa, utl.tl_findespesas, ") '35
                _sqlUsuario.Append("utl.tl_finchqpredatado, utl.tl_manutencao, utl.tl_manemprestimos, utl.tl_mantrocas, ") '39
                _sqlUsuario.Append("utl.tl_manpalmtop, utl.tl_mancidadesibge, utl.tl_contabil, utl.tl_ctbarqdigitais, ") '43
                _sqlUsuario.Append("utl.tl_ctblivrosfiscais, utl.tl_ctbcontador, utl.tl_ctbcfop, utl.tl_parametros, ") '47
                _sqlUsuario.Append("utl.tl_paracontrole, utl.tl_paraultilitarios, utl.tl_parabackup, u.u_local, u.u_codvendedor, utl.btn_cancelarexcluir, ") '53
                _sqlUsuario.Append("utl.tl_cadcomodato, utl.tl_cadautomovel, utl.tl_cadgerais, utl.tl_cadgerente, utl.tl_movrequisicao, ") '58
                _sqlUsuario.Append("utl.tl_movemispedido, utl.tl_movgeramapa, utl.tl_mapas, utl.tl_mpvenda, utl.tl_mpretornovenda, ") '63
                _sqlUsuario.Append("utl.tl_estrelatorios, utl.tl_paraconfiguracao, u.u_cargo, utl.btn_carne, u.u_codcaixa ") '68
                _sqlUsuario.Append("FROM usuario u LEFT JOIN usuarioTelas utl ON u.u_id = utl.tl_idusuario ")
                _sqlUsuario.Append("WHERE u.u_id = @u_id")

                _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, _oConnBDMETROSYS)
                _cmdUsuario.Parameters.Add("@u_id", _idUsuario)
                _drUsuario = _cmdUsuario.ExecuteReader

                While _drUsuario.Read
                    Me.txt_nome.Text = _drUsuario(1).ToString
                    Me.txt_login.Text = _drUsuario(2).ToString
                    _senhaUsuario = _drUsuario(3).ToString
                    Me.msk_dtnascimento.Text = Format(_drUsuario(4), "dd/MM/yyyy")
                    Me.chk_privilegio.Checked = _drUsuario(5)
                    Me.chk_bloqueado.Checked = _drUsuario(6)

                    Try
                        Me.cbo_local.SelectedIndex = trazIndexLocal(_drUsuario(51).ToString, Me.cbo_local)
                    Catch ex As Exception
                        Me.cbo_local.SelectedIndex = -1
                    End Try

                    Try
                        Me.cbo_vendedor.SelectedIndex = _clFuncoes.trazIndexCboVendedor(_drUsuario(52).ToString, _
                                                        Me.cbo_vendedor)
                    Catch ex As Exception
                        Me.cbo_local.SelectedIndex = -1
                    End Try

                    Try
                        Me.cbo_cargoUsuario.SelectedIndex = _clFuncoes.trazIndexCboCargoUsuario(_drUsuario(66).ToString, _
                                                        Me.cbo_cargoUsuario)
                    Catch ex As Exception
                        Me.cbo_cargoUsuario.SelectedIndex = -1
                    End Try


                    If _drUsuario(66) = 4 Then 'Se o cargo for caixa

                        Try
                            Me.cbo_caixa.SelectedIndex = _clFuncoes.trazIndexCboCaixa(_drUsuario(68).ToString, _
                                                                                   Me.cbo_caixa)
                        Catch ex As Exception
                            Me.cbo_caixa.SelectedIndex = -1
                        End Try
                    End If
                    

                    'telas do Usuario...
                    'Cadastros
                    _clUsuarioTelas.pTl_Cadastros = _drUsuario(7) : _clUsuarioTelas.pTl_cadcliente = _drUsuario(8)
                    _clUsuarioTelas.pTl_cadvendedor = _drUsuario(9) : _clUsuarioTelas.pTl_cadusuario = _drUsuario(10)
                    _clUsuarioTelas.pTl_cadtitular = _drUsuario(11) : _clUsuarioTelas.pTl_cadcidade = _drUsuario(12)
                    _clUsuarioTelas.pTl_cadservico = _drUsuario(13) : _clUsuarioTelas.pTl_cadgeno = _drUsuario(14)
                    _clUsuarioTelas.pTl_cadcomodato = _drUsuario(54) : _clUsuarioTelas.pTl_cadautomovel = _drUsuario(55)
                    _clUsuarioTelas.pTl_cadgerais = _drUsuario(56) : _clUsuarioTelas.pTl_cadgerente = _drUsuario(57)

                    'movimentos
                    _clUsuarioTelas.pTl_movimentos = _drUsuario(15) : _clUsuarioTelas.pTl_movpedido = _drUsuario(16)
                    _clUsuarioTelas.pTl_movorcamento = _drUsuario(17) : _clUsuarioTelas.pTl_movtransferencia = _drUsuario(18)
                    _clUsuarioTelas.pTl_movnfe = _drUsuario(19) : _clUsuarioTelas.pTl_movgeramapa = _drUsuario(60)
                    _clUsuarioTelas.pTl_movrequisicao = _drUsuario(58) : _clUsuarioTelas.pTl_movemisspedido = _drUsuario(59)
                    _clUsuarioTelas.pBtn_cancelarExcluir = _drUsuario(53) : _clUsuarioTelas.pBtn_carne = _drUsuario(67)

                    'mapas
                    _clUsuarioTelas.pTl_mapas = _drUsuario(61) : _clUsuarioTelas.pTl_mpvenda = _drUsuario(62)
                    _clUsuarioTelas.pTl_mpretornovenda = _drUsuario(63)

                    'cupom
                    _clUsuarioTelas.pTl_cupom = _drUsuario(20) : _clUsuarioTelas.pTl_cpprevenda = _drUsuario(21)
                    _clUsuarioTelas.pTl_cpvendadireta = _drUsuario(22) : _clUsuarioTelas.pTl_cpconfiguracao = _drUsuario(23)

                    'estoque
                    _clUsuarioTelas.pTl_estoque = _drUsuario(24) : _clUsuarioTelas.pTl_estpesquisa = _drUsuario(25)
                    _clUsuarioTelas.pTl_estrestaura = _drUsuario(26) : _clUsuarioTelas.pTl_estimplantacao = _drUsuario(27)
                    _clUsuarioTelas.pTl_estpedidocompras = _drUsuario(28) : _clUsuarioTelas.pTl_estcompras = _drUsuario(29)
                    _clUsuarioTelas.pTl_estatualizacao = _drUsuario(30) : _clUsuarioTelas.pTl_estrelatorios = _drUsuario(64)

                    'financeiro
                    _clUsuarioTelas.pTl_financeiro = _drUsuario(31) : _clUsuarioTelas.pTl_finpagamentos = _drUsuario(32)
                    _clUsuarioTelas.pTl_finrecebimentos = _drUsuario(33) : _clUsuarioTelas.pTl_finfluxocaixa = _drUsuario(34)
                    _clUsuarioTelas.pTl_findespesas = _drUsuario(35) : _clUsuarioTelas.pTl_finchqPreDatado = _drUsuario(36)

                    'manutencao
                    _clUsuarioTelas.pTl_manutencao = _drUsuario(37) : _clUsuarioTelas.pTl_manemprestimos = _drUsuario(38)
                    _clUsuarioTelas.pTl_mantrocas = _drUsuario(39) : _clUsuarioTelas.pTl_manpalmtop = _drUsuario(40)
                    _clUsuarioTelas.pTl_mancidadesibge = _drUsuario(41)

                    'contabil
                    _clUsuarioTelas.pTl_contabil = _drUsuario(42) : _clUsuarioTelas.pTl_ctbarqdigitais = _drUsuario(43)
                    _clUsuarioTelas.pTl_ctblivrosfiscais = _drUsuario(44) : _clUsuarioTelas.pTl_ctbcontador = _drUsuario(45)
                    _clUsuarioTelas.pTl_ctbcfop = _drUsuario(46)

                    'parametros
                    _clUsuarioTelas.pTl_parametros = _drUsuario(47) : _clUsuarioTelas.pTl_paracontrole = _drUsuario(48)
                    _clUsuarioTelas.pTl_paraultilitarios = _drUsuario(49) : _clUsuarioTelas.pTl_parabackup = _drUsuario(50)
                    _clUsuarioTelas.pTl_paraconfiguracao = _drUsuario(65)



                End While


            Catch ex As Exception
                MsgBox("ERRO no SELECT do USUARIO:: " & ex.Message, MsgBoxStyle.Exclamation)
                Return

            End Try

            _cmdUsuario.CommandText = "" : _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
        End If



    End Sub

    Private Sub configTelaNormal()

        lbl_senha.SetBounds(72, 144, 54, 18) : txt_senha.SetBounds(133, 141, 90, 24)
        lbl_redigite.SetBounds(61, 177, 65, 18) : txt_redigita.SetBounds(133, 173, 90, 24)
        chk_privilegio.SetBounds(12, 209, 114, 21) : chk_bloqueado.SetBounds(31, 232, 95, 21)
        lbl_senhaAtual.SetBounds(144, 260, 86, 18) : txt_senhaAtual.SetBounds(236, 257, 90, 24)
        lbl_senhaAtual.Visible = False : txt_senhaAtual.Visible = False

    End Sub

    Private Sub configTelaEditando()

        lbl_senha.SetBounds(72, 179, 54, 18) : txt_senha.SetBounds(133, 176, 90, 24)
        lbl_redigite.SetBounds(61, 212, 65, 18) : txt_redigita.SetBounds(133, 208, 90, 24)
        chk_privilegio.SetBounds(12, 244, 114, 21) : chk_bloqueado.SetBounds(31, 267, 95, 21)
        lbl_senhaAtual.SetBounds(40, 148, 86, 18) : txt_senhaAtual.SetBounds(133, 145, 90, 24)
        lbl_senhaAtual.Visible = True : txt_senhaAtual.Visible = True

    End Sub

    Private Sub txt_senhaAtual_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_senhaAtual.Leave

        If criptografaSenha(Me.txt_senhaAtual.Text) <> _senhaUsuario Then

            MsgBox("Atenção ! " & Chr(10) & "SenhaAtual incorreta!", MsgBoxStyle.Exclamation)
            Me.txt_senhaAtual.SelectAll()

        End If


    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        Me.preencheDgrd_Usuario(Me.txt_pesquisa.Text)

    End Sub

    Private Sub cbo_cargoUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cargoUsuario.SelectedIndexChanged

        Try

            If CInt(cbo_cargoUsuario.SelectedItem.ToString.Substring(0, 2)) = 4 Then 'Se o cargo for caixa

                lbl_caixa.Visible = True : cbo_caixa.Visible = True
                cbo_caixa.SelectedIndex = 0
            Else
                lbl_caixa.Visible = False : cbo_caixa.Visible = False
                cbo_caixa.SelectedIndex = -1
            End If

        Catch ex As Exception
        End Try


    End Sub

End Class