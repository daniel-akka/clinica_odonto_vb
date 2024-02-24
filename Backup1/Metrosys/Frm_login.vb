Imports Npgsql
Imports System.Text
Imports System.DateTime
Imports System.Threading
Imports System.ComponentModel

Public Class Frm_login

    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Dim agora As Date = Now
    Dim Hoje As String = "28/11/2015"
    Dim _camihoArq As String = "\wged\MetroSys\configBD.sys"
    Public Shared _frmRef_Login As New Frm_login
    Private INT_mValorZERO As Integer = 0
    Private _loginOK As Boolean = False
    Private _mac As String = ""
    Private _sincronizar As Boolean = False
    Public _privilegio As Boolean = False
    Dim mtenta As Integer = 1
    Public _formRequest As New Frm_MetroSys
    Public Shared _frmRef As Frm_login
    Dim bw As New BackgroundWorker




    Private Sub Frm_login_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If


    End Sub

    Private Sub txt_senha_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_senha.GotFocus
        Me.txt_senha.SelectAll()
    End Sub

    Private Sub txt_senha_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_senha.Leave

        If txt_senha.Text <> "" Then
            Dim Msenha(10), Xsenha(10) As Integer
            Dim mresultado As String

            Msenha(0) = 154 : Msenha(1) = 157 : Msenha(2) = 181 : Msenha(3) = 165
            Msenha(4) = 216 : Msenha(5) = 219 : Msenha(6) = 175 : Msenha(7) = 208
            Msenha(8) = 249 : Msenha(9) = 243

            Dim x As Integer
            For x = 1 To Len(Me.txt_senha.Text)
                Xsenha(x - 1) = Asc(Mid(txt_senha.Text, x, 1)) + Msenha(x - 1)
                mresultado = RTrim(mresultado) & Convert.ToChar(Xsenha(x - 1))

            Next

            If validaLogin(Me.txt_login.Text, mresultado) Then

                If MdlEmpresaUsu.sincroniza Then

                    If _sincronizar Then

                        Try
                            Shell("\Wged\Sincroniza\Sincroniza.exe", AppWinStyle.Hide, False)
                            _loginOK = False
                            _formRequest._frmRef.rlogin = _loginOK
                            Application.ExitThread()
                            Application.Exit()
                            Me.Close()

                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                        End Try
                    End If

                End If


                _loginOK = True
                _formRequest._frmRef.rlogin = _loginOK
                Me.Close()

            Else
                MsgBox("Login Incorreto", MsgBoxStyle.Exclamation)
                SendKeys.Send("{TAB}")
            End If


        End If



    End Sub

    Private Shared Sub validaLoginTelas(ByVal _drUsuario As NpgsqlDataReader)

        '      0            1               2               3             4              5
        'tl_cadastros, tl_cadcliente, tl_cadvendedor, tl_cadusuario, tl_cadtitular, tl_cadcidade, 

        '       6           7             8             9               10                  11
        'tl_cadservico, tl_cadgeno, tl_movimentos, tl_movpedido, tl_movorcamento, tl_movtransferencia, 

        '    12        13           14              15                 16             17            18
        'tl_movnfe, tl_cupom, tl_cpprevenda, tl_cpvendadireta, tl_cpconfiguracao, tl_estoque, tl_estpesquisa, 

        '       19              20                  21                22                23
        'tl_estrestaura, tl_estimplantacao, tl_estpedidocompras, tl_estcompras, tl_estatualizacao, 

        '      24               25                26                 27               28
        'tl_financeiro, tl_finpagamentos, tl_finrecebimentos, tl_finfluxocaixa, tl_findespesas, 

        '       29                 30               31              32              33              34
        'tl_finchqpredatado, tl_manutencao, tl_manemprestimos, tl_mantrocas, tl_manpalmtop, tl_mancidadesibge,

        '     35              36                  37                38            39            40
        'tl_contabil, tl_ctbarqdigitais, tl_ctblivrosfiscais, tl_ctbcontador, tl_ctbcfop, tl_parametros, 

        '       41                  42              43                 44
        'tl_paracontrole, tl_paraultilitarios, tl_parabackup, btn_cancelarexcluir


        While _drUsuario.Read
            ' Menu Cadastros
            MdlTelasAcesso._usuarioTelas.pTl_Cadastros = _drUsuario(0)
            MdlTelasAcesso._usuarioTelas.pTl_cadcliente = _drUsuario(1)
            MdlTelasAcesso._usuarioTelas.pTl_cadvendedor = _drUsuario(2)
            MdlTelasAcesso._usuarioTelas.pTl_cadusuario = _drUsuario(3)
            MdlTelasAcesso._usuarioTelas.pTl_cadtitular = _drUsuario(4)
            MdlTelasAcesso._usuarioTelas.pTl_cadcidade = _drUsuario(5)
            MdlTelasAcesso._usuarioTelas.pTl_cadcomodato = _drUsuario(45)
            MdlTelasAcesso._usuarioTelas.pTl_cadservico = _drUsuario(6)
            MdlTelasAcesso._usuarioTelas.pTl_cadautomovel = _drUsuario(46)
            MdlTelasAcesso._usuarioTelas.pTl_cadgerais = _drUsuario(47)
            MdlTelasAcesso._usuarioTelas.pTl_cadgerente = _drUsuario(48)
            MdlTelasAcesso._usuarioTelas.pTl_cadgeno = _drUsuario(7)


            ' Menu Movimentos
            MdlTelasAcesso._usuarioTelas.pTl_movimentos = _drUsuario(8)
            MdlTelasAcesso._usuarioTelas.pTl_movpedido = _drUsuario(9)
            MdlTelasAcesso._usuarioTelas.pTl_movorcamento = _drUsuario(10)
            MdlTelasAcesso._usuarioTelas.pTl_movtransferencia = _drUsuario(11)
            MdlTelasAcesso._usuarioTelas.pTl_movnfe = _drUsuario(12)
            MdlTelasAcesso._usuarioTelas.pTl_movrequisicao = _drUsuario(49)
            MdlTelasAcesso._usuarioTelas.pTl_movemisspedido = _drUsuario(50)
            MdlTelasAcesso._usuarioTelas.pTl_movgeramapa = _drUsuario(51)
            MdlTelasAcesso._usuarioTelas.pBtn_cancelarExcluir = _drUsuario(44)
            MdlTelasAcesso._usuarioTelas.pTl_movpagoentregar = _drUsuario(57)
            MdlTelasAcesso._usuarioTelas.pBtn_carne = _drUsuario(58)


            ' Menu Mapas
            MdlTelasAcesso._usuarioTelas.pTl_mapas = _drUsuario(52)
            MdlTelasAcesso._usuarioTelas.pTl_mpvenda = _drUsuario(53)
            MdlTelasAcesso._usuarioTelas.pTl_mpretornovenda = _drUsuario(54)

            ' Menu Cupom
            MdlTelasAcesso._usuarioTelas.pTl_cupom = _drUsuario(13)
            MdlTelasAcesso._usuarioTelas.pTl_cpprevenda = _drUsuario(14)
            MdlTelasAcesso._usuarioTelas.pTl_cpvendadireta = _drUsuario(15)
            MdlTelasAcesso._usuarioTelas.pTl_cpconfiguracao = _drUsuario(16)

            ' Menu Estoque
            MdlTelasAcesso._usuarioTelas.pTl_estoque = _drUsuario(17)
            MdlTelasAcesso._usuarioTelas.pTl_estpesquisa = _drUsuario(18)
            MdlTelasAcesso._usuarioTelas.pTl_estrestaura = _drUsuario(19)
            MdlTelasAcesso._usuarioTelas.pTl_estimplantacao = _drUsuario(20)
            MdlTelasAcesso._usuarioTelas.pTl_estpedidocompras = _drUsuario(21)
            MdlTelasAcesso._usuarioTelas.pTl_estcompras = _drUsuario(22)
            MdlTelasAcesso._usuarioTelas.pTl_estatualizacao = _drUsuario(23)
            MdlTelasAcesso._usuarioTelas.pTl_estrelatorios = _drUsuario(55)

            ' Menu Financeiro
            MdlTelasAcesso._usuarioTelas.pTl_financeiro = _drUsuario(24)
            MdlTelasAcesso._usuarioTelas.pTl_finpagamentos = _drUsuario(25)
            MdlTelasAcesso._usuarioTelas.pTl_finrecebimentos = _drUsuario(26)
            MdlTelasAcesso._usuarioTelas.pTl_finfluxocaixa = _drUsuario(27)
            MdlTelasAcesso._usuarioTelas.pTl_findespesas = _drUsuario(28)
            MdlTelasAcesso._usuarioTelas.pTl_finchqPreDatado = _drUsuario(29)

            ' Menu Manutenção
            MdlTelasAcesso._usuarioTelas.pTl_manutencao = _drUsuario(30)
            MdlTelasAcesso._usuarioTelas.pTl_manemprestimos = _drUsuario(31)
            MdlTelasAcesso._usuarioTelas.pTl_mantrocas = _drUsuario(32)
            MdlTelasAcesso._usuarioTelas.pTl_manpalmtop = _drUsuario(33)
            MdlTelasAcesso._usuarioTelas.pTl_mancidadesibge = _drUsuario(34)

            ' Menu Contábil
            MdlTelasAcesso._usuarioTelas.pTl_contabil = _drUsuario(35)
            MdlTelasAcesso._usuarioTelas.pTl_ctbarqdigitais = _drUsuario(36)
            MdlTelasAcesso._usuarioTelas.pTl_ctblivrosfiscais = _drUsuario(37)
            MdlTelasAcesso._usuarioTelas.pTl_ctbcontador = _drUsuario(38)
            MdlTelasAcesso._usuarioTelas.pTl_ctbcfop = _drUsuario(39)

            ' Menu Parametros
            MdlTelasAcesso._usuarioTelas.pTl_parametros = _drUsuario(40)
            MdlTelasAcesso._usuarioTelas.pTl_paracontrole = _drUsuario(41)
            MdlTelasAcesso._usuarioTelas.pTl_paraultilitarios = _drUsuario(42)
            MdlTelasAcesso._usuarioTelas.pTl_parabackup = _drUsuario(43)
            MdlTelasAcesso._usuarioTelas.pTl_paraconfiguracao = _drUsuario(56)


        End While



    End Sub

    Private Shared Sub validaLoginRelatorioTelas(ByVal _dr As NpgsqlDataReader)

        '_sqlUsuario.Append("SELECT tl_cadcliente, tl_cadvendedor, ") '1
        '_sqlUsuario.Append("tl_cadusuario, tl_cadtitular, tl_cadcidade, tl_cadservico, tl_cadgeno, ") '6
        '_sqlUsuario.Append("tl_movpedido, tl_movorcamento, tl_movtransferencia, ") '9
        '_sqlUsuario.Append("tl_movnfe, tl_cpprevenda, tl_cpvendadireta, tl_cpconfiguracao, ") '13
        '_sqlUsuario.Append("tl_estpesquisa, tl_estrestaura, tl_estimplantacao, ") '16
        '_sqlUsuario.Append("tl_estpedidocompras, tl_estcompras, tl_estatualizacao, ") '19
        '_sqlUsuario.Append("tl_finpagamentos, tl_finrecebimentos, tl_finfluxocaixa, tl_findespesas, ") '23
        '_sqlUsuario.Append("tl_finchqpredatado, tl_manemprestimos, tl_mantrocas, ") '26
        '_sqlUsuario.Append("tl_manpalmtop, tl_mancidadesibge, tl_ctbarqdigitais, ") '29
        '_sqlUsuario.Append("tl_ctblivrosfiscais, tl_ctbcontador, tl_ctbcfop, ") '32
        '_sqlUsuario.Append("tl_paracontrole, tl_paraultilitarios, tl_parabackup, ") '35
        '_sqlUsuario.Append("tl_cadcomodato, tl_cadautomovel, tl_cadgerais, tl_cadgerente, tl_movrequisicao, ") '40
        '_sqlUsuario.Append("tl_movemispedido, tl_movgeramapa, tl_mpvenda, tl_mpretornovenda, ") '44
        '_sqlUsuario.Append("tl_estrelatorios, tl_paraconfiguracao ") '46
        While _dr.Read

            ' Menu Cadastros
            MdlRelatorioTelas._tl_cadcliente = _dr(0)
            MdlRelatorioTelas._tl_cadvendedor = _dr(1)
            MdlRelatorioTelas._tl_cadusuario = _dr(2)
            MdlRelatorioTelas._tl_cadtitular = _dr(3)
            MdlRelatorioTelas._tl_cadcidade = _dr(4)
            MdlRelatorioTelas._tl_cadservico = _dr(5)
            MdlRelatorioTelas._tl_cadgeno = _dr(6)
            MdlRelatorioTelas._tl_cadcomodato = _dr(36)
            MdlRelatorioTelas._tl_cadautomovel = _dr(37)
            MdlRelatorioTelas._tl_cadgerais = _dr(38)
            MdlRelatorioTelas._tl_cadgerente = _dr(39)

            ' Menu Movimentos
            MdlRelatorioTelas._tl_movpedido = _dr(7)
            MdlRelatorioTelas._tl_movorcamento = _dr(8)
            MdlRelatorioTelas._tl_movtransferencia = _dr(9)
            MdlRelatorioTelas._tl_movnfe = _dr(10)
            MdlRelatorioTelas._tl_movrequisicao = _dr(40)
            MdlRelatorioTelas._tl_movemispedido = _dr(41)
            MdlRelatorioTelas._tl_movgeramapa = _dr(42)

            ' Menu Mapas
            MdlRelatorioTelas._tl_mpvenda = _dr(43)
            MdlRelatorioTelas._tl_mpretornovenda = _dr(44)

            ' Menu Cupom
            MdlRelatorioTelas._tl_cpprevenda = _dr(11)
            MdlRelatorioTelas._tl_cpvendadireta = _dr(12)
            MdlRelatorioTelas._tl_cpconfiguracao = _dr(13)

            ' Menu Estoque
            MdlRelatorioTelas._tl_estpesquisa = _dr(14)
            MdlRelatorioTelas._tl_estrestaura = _dr(15)
            MdlRelatorioTelas._tl_estimplantacao = _dr(16)
            MdlRelatorioTelas._tl_estpedidocompras = _dr(17)
            MdlRelatorioTelas._tl_estcompras = _dr(18)
            MdlRelatorioTelas._tl_estatualizacao = _dr(19)
            MdlRelatorioTelas._tl_estrelatorios = _dr(45)

            ' Menu Financeiro
            MdlRelatorioTelas._tl_finpagamentos = _dr(20)
            MdlRelatorioTelas._tl_finrecebimentos = _dr(21)
            MdlRelatorioTelas._tl_finfluxocaixa = _dr(22)
            MdlRelatorioTelas._tl_findespesas = _dr(23)
            MdlRelatorioTelas._tl_finchqPreDatado = _dr(24)

            ' Menu Manutenção
            MdlRelatorioTelas._tl_manemprestimos = _dr(25)
            MdlRelatorioTelas._tl_mantrocas = _dr(26)
            MdlRelatorioTelas._tl_manpalmtop = _dr(27)
            MdlRelatorioTelas._tl_mancidadesibge = _dr(28)

            ' Menu Contábil
            MdlRelatorioTelas._tl_ctbarqdigitais = _dr(29)
            MdlRelatorioTelas._tl_ctblivrosfiscais = _dr(30)
            MdlRelatorioTelas._tl_ctbcontador = _dr(31)
            MdlRelatorioTelas._tl_ctbcfop = _dr(32)

            ' Menu Parametros
            MdlRelatorioTelas._tl_paracontrole = _dr(33)
            MdlRelatorioTelas._tl_parautilitarios = _dr(34)
            MdlRelatorioTelas._tl_parabackup = _dr(35)
            MdlRelatorioTelas._tl_paraconfiguracao = _dr(46)


        End While



    End Sub

    Private Function validaLogin(ByVal login As String, ByVal senhaCrypt As String) As Boolean

        Dim resultadoLogin As Boolean = False
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim _sqlUsuario As New StringBuilder
        Dim _cmdUsuario As NpgsqlCommand
        Dim _dr As NpgsqlDataReader

        Try
            conection.Open()

            If conection.State = ConnectionState.Open Then
                Try
                    _sqlUsuario.Append("SELECT * FROM usuario")
                    _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                    _dr = _cmdUsuario.ExecuteReader

                    If _dr.HasRows = False Then

                        resultadoLogin = True
                        MdlUsuarioLogando._usuarioPrivilegio = True
                        _formRequest._frmRef.primeiroAcesso = True

                    Else

                        _formRequest._frmRef.primeiroAcesso = False

                        'Traz o Usuário...
                        _cmdUsuario.CommandText = ""
                        _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
                        _dr.Close()
                        _sqlUsuario.Append("SELECT u.u_login, u.u_nome, u.u_privilegio, u.u_senha, u.u_bloqueado, u.u_datanascimento, ") '5
                        _sqlUsuario.Append("u.u_id, u.u_local, u.u_codvendedor, u.u_cargo, CURRENT_DATE, u.u_codcaixa FROM usuario u ")
                        _sqlUsuario.Append("WHERE u_login = @u_login AND u_senha = @u_senha")
                        _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                        _cmdUsuario.Parameters.Add("@u_login", login)
                        _cmdUsuario.Parameters.Add("@u_senha", senhaCrypt)
                        _dr = _cmdUsuario.ExecuteReader

                        If _dr.HasRows = True Then
                            Dim idUsuario As Int32 = INT_mValorZERO
                            resultadoLogin = True

                            While _dr.Read

                                MdlUsuarioLogando._usuarioLogin = _dr(0).ToString
                                MdlUsuarioLogando._usuarioNome = _dr(1).ToString
                                MdlUsuarioLogando._usuarioSenha = _dr(3).ToString
                                MdlUsuarioLogando._usuarioPrivilegio = _dr(2)
                                MdlUsuarioLogando._bloqueado = _dr(4)
                                MdlUsuarioLogando._local = _dr(7)
                                MdlUsuarioLogando._codvendedor = _dr(8).ToString
                                MdlUsuarioLogando._cargo = _dr(9)
                                MdlConexaoBD.dataServidor = _dr(10)
                                MdlUsuarioLogando._codcaixa = _dr(11).ToString
                                idUsuario = _dr(6).ToString


                            End While

                            If MdlUsuarioLogando._bloqueado = True Then
                                MsgBox("Usuario Bloqueado", MsgBoxStyle.Exclamation)
                                resultadoLogin = False
                                Me.Close()

                            End If

                            'Traz as Telas do Usuário...
                            _cmdUsuario.CommandText = ""
                            _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
                            _dr.Close()
                            _sqlUsuario.Append("SELECT tl_cadastros, tl_cadcliente, tl_cadvendedor, ") '2
                            _sqlUsuario.Append("tl_cadusuario, tl_cadtitular, tl_cadcidade, tl_cadservico, tl_cadgeno, ") '7
                            _sqlUsuario.Append("tl_movimentos, tl_movpedido, tl_movorcamento, tl_movtransferencia, ") '11
                            _sqlUsuario.Append("tl_movnfe, tl_cupom, tl_cpprevenda, tl_cpvendadireta, tl_cpconfiguracao, ") '16
                            _sqlUsuario.Append("tl_estoque, tl_estpesquisa, tl_estrestaura, tl_estimplantacao, ") '20
                            _sqlUsuario.Append("tl_estpedidocompras, tl_estcompras, tl_estatualizacao, tl_financeiro, ") '24
                            _sqlUsuario.Append("tl_finpagamentos, tl_finrecebimentos, tl_finfluxocaixa, tl_findespesas, ") '28
                            _sqlUsuario.Append("tl_finchqpredatado, tl_manutencao, tl_manemprestimos, tl_mantrocas, ") '32
                            _sqlUsuario.Append("tl_manpalmtop, tl_mancidadesibge, tl_contabil, tl_ctbarqdigitais, ") '36
                            _sqlUsuario.Append("tl_ctblivrosfiscais, tl_ctbcontador, tl_ctbcfop, tl_parametros, ") '40
                            _sqlUsuario.Append("tl_paracontrole, tl_paraultilitarios, tl_parabackup, btn_cancelarexcluir, ") '44
                            _sqlUsuario.Append("tl_cadcomodato, tl_cadautomovel, tl_cadgerais, tl_cadgerente, tl_movrequisicao, ") '49
                            _sqlUsuario.Append("tl_movemispedido, tl_movgeramapa, tl_mapas, tl_mpvenda, tl_mpretornovenda, ") '54
                            _sqlUsuario.Append("tl_estrelatorios, tl_paraconfiguracao, tl_pagoaentregar, btn_carne ") '58
                            _sqlUsuario.Append("FROM usuariotelas WHERE tl_idusuario = @tl_idusuario")
                            _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                            _cmdUsuario.Parameters.Add("@tl_idusuario", idUsuario)
                            _dr = _cmdUsuario.ExecuteReader
                            If _dr.HasRows = True Then validaLoginTelas(_dr)


                            'Traz Geno001 e Genp001...
                            _cmdUsuario.CommandText = ""
                            _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
                            _dr.Close()
                            _sqlUsuario.Append("SELECT g.g_codig, g.g_razaosocial, g.g_geno, g.g_ender, g.g_bair, g.g_cid, ") '5
                            _sqlUsuario.Append("g.g_cep, g.g_uf, g.g_cgc, g.g_insc, gp.gp_icms, gp.gp_icmse, gp.gp_txipi, ") '12
                            _sqlUsuario.Append("gp.gp_pis, gp.gp_confin, gp.gp_alqsub, gp.gp_txcob, gp.gp_carencia, gp.gp_serie, ") '18
                            _sqlUsuario.Append("gp.gp_amb, gp.gp_codprod, g.g_vinculo, g.g_esquemaestab, g.g_esquemavinc, ") '23
                            _sqlUsuario.Append("gp.gp_canc_pedauto, gp.gp_grade, gp.gp_tipocondpagto, g.g_crt, g.g_retencao, ") '28
                            _sqlUsuario.Append("gp.gp_cpfvalidar, gp.gp_tptransfentrada, gp.gp_tptransfsaida, gp.gp_sincroniza, ") '32
                            _sqlUsuario.Append("gp.gp_comisavista, gp.gp_comisaprazo, gp.gp_envioxml, gp.gp_lotxml, ") '36
                            _sqlUsuario.Append("gp.gp_retornoxml, gp.gp_enviadoxml, gp.gp_imagemcarne, gp.gp_sldfiscalnegativo, gp.gp_aplicacao, ") '41
                            _sqlUsuario.Append("gp.gp_tabletenvio, gp.gp_tabletretorno, gp.gp_tabletpathimg, gp.gp_ftptablet, ") '45
                            _sqlUsuario.Append("gp.gp_usuarioftptablet, gp.gp_senhaftptablet, gp.gp_palmenvio, gp.gp_palmretorno, ") '49
                            _sqlUsuario.Append("gp.gp_ftppalm, gp.gp_usuarioftppalm, gp.gp_senhaftppalm, gp.gp_pauta, gp.gp_descontonfe ") '54
                            _sqlUsuario.Append("FROM geno001 g LEFT JOIN genp001 gp ON gp.gp_geno = g.g_codig WHERE g.g_codig = @g_codig")
                            _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                            _cmdUsuario.Parameters.Add("@g_codig", MdlUsuarioLogando._local)
                            _dr = _cmdUsuario.ExecuteReader

                            
                            While _dr.Read

                                'Set Geno001...
                                MdlEmpresaUsu._codigo = _dr(0).ToString
                                MdlEmpresaUsu._razaoSocialNome = _dr(1).ToString
                                MdlEmpresaUsu._fantasia = _dr(2).ToString
                                MdlEmpresaUsu._endereco = _dr(3).ToString
                                MdlEmpresaUsu._bairro = _dr(4).ToString
                                MdlEmpresaUsu._cidade = _dr(5).ToString
                                MdlEmpresaUsu._cep = _dr(6).ToString
                                MdlEmpresaUsu._uf = _dr(7).ToString
                                MdlEmpresaUsu._cnpj = _dr(8).ToString
                                MdlEmpresaUsu._inscEstadual = _dr(9).ToString
                                MdlEmpresaUsu._vinculo = _dr(21)
                                MdlEmpresaUsu._esqEstab = _dr(22).ToString
                                MdlEmpresaUsu._esqVinc = _dr(23).ToString
                                MdlEmpresaUsu._retencao = _dr(28)


                                'Set Genp001...
                                MdlEmpresaUsu._alqIcmsInterno = _dr(10).ToString
                                MdlEmpresaUsu._alqIcmsExterno = _dr(11).ToString
                                MdlEmpresaUsu._alqIpi = _dr(12).ToString
                                MdlEmpresaUsu._alqPis = _dr(13).ToString
                                MdlEmpresaUsu._alqCofins = _dr(14).ToString
                                MdlEmpresaUsu._alqSubst = _dr(15).ToString
                                MdlEmpresaUsu._taxaCobranca = _dr(16).ToString
                                MdlEmpresaUsu._carencia = _dr(17).ToString
                                MdlEmpresaUsu._serieNFe = _dr(18).ToString
                                MdlEmpresaUsu._ambienteNFe = _dr(19).ToString
                                MdlEmpresaUsu._codProd = _dr(20).ToString
                                MdlEmpresaUsu._cancPedidoAuto = _dr(24)
                                MdlEmpresaUsu.grade = _dr(25)
                                MdlEmpresaUsu.tipoCondPagto = _dr(26)
                                MdlEmpresaUsu._crt = _dr(27).ToString
                                MdlEmpresaUsu.cpfvalidar = _dr(29)
                                MdlEmpresaUsu.tpTransfEntrada = _dr(30).ToString
                                MdlEmpresaUsu.tpTransfSaida = _dr(31).ToString
                                MdlEmpresaUsu.sincroniza = _dr(32)
                                MdlEmpresaUsu.alqComisAVista = _dr(33)
                                MdlEmpresaUsu.alqComisAPrazo = _dr(34)
                                MdlEmpresaUsu.genp001.pathEnvioXML = _dr(35).ToString
                                MdlEmpresaUsu.genp001.pathLotXML = _dr(36).ToString
                                MdlEmpresaUsu.genp001.pathRetornoXML = _dr(37).ToString
                                MdlEmpresaUsu.genp001.pathEnviadoXML = _dr(38).ToString
                                MdlEmpresaUsu.genp001.imagemCarne = _dr(39).ToString
                                MdlEmpresaUsu.genp001.sldfiscalnegativo = _dr(40)
                                MdlEmpresaUsu.genp001.aplicacao = _dr(41)
                                MdlEmpresaUsu.genp001.pathEnvioTablet = _dr(42).ToString
                                MdlEmpresaUsu.genp001.pathRetornoTablet = _dr(43).ToString
                                MdlEmpresaUsu.genp001.pathImgTablet = _dr(44).ToString
                                MdlEmpresaUsu.genp001.ftpTablet = _dr(45).ToString
                                MdlEmpresaUsu.genp001.usuarioFtpTablet = _dr(46).ToString
                                MdlEmpresaUsu.genp001.senhaFtpTablet = _dr(47).ToString
                                MdlEmpresaUsu.genp001.pathEnvioPalm = _dr(48).ToString
                                MdlEmpresaUsu.genp001.pathRetornoPalm = _dr(49).ToString
                                MdlEmpresaUsu.genp001.ftpPalm = _dr(50).ToString
                                MdlEmpresaUsu.genp001.usuarioFtpPalm = _dr(51).ToString
                                MdlEmpresaUsu.genp001.senhaFtpPalm = _dr(52).ToString
                                MdlEmpresaUsu.genp001.pauta = _dr(53)
                                MdlEmpresaUsu.genp001.descontonfe = _dr(54)



                            End While


                            'Traz tipo de Relatório por Telas da Empresa...
                            _cmdUsuario.CommandText = ""
                            _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
                            _dr.Close()
                            _sqlUsuario.Append("SELECT tl_cadcliente, tl_cadvendedor, ") '1
                            _sqlUsuario.Append("tl_cadusuario, tl_cadtitular, tl_cadcidade, tl_cadservico, tl_cadgeno, ") '6
                            _sqlUsuario.Append("tl_movpedido, tl_movorcamento, tl_movtransferencia, ") '9
                            _sqlUsuario.Append("tl_movnfe, tl_cpprevenda, tl_cpvendadireta, tl_cpconfiguracao, ") '13
                            _sqlUsuario.Append("tl_estpesquisa, tl_estrestaura, tl_estimplantacao, ") '16
                            _sqlUsuario.Append("tl_estpedidocompras, tl_estcompras, tl_estatualizacao, ") '19
                            _sqlUsuario.Append("tl_finpagamentos, tl_finrecebimentos, tl_finfluxocaixa, tl_findespesas, ") '23
                            _sqlUsuario.Append("tl_finchqpredatado, tl_manemprestimos, tl_mantrocas, ") '26
                            _sqlUsuario.Append("tl_manpalmtop, tl_mancidadesibge, tl_ctbarqdigitais, ") '29
                            _sqlUsuario.Append("tl_ctblivrosfiscais, tl_ctbcontador, tl_ctbcfop, ") '32
                            _sqlUsuario.Append("tl_paracontrole, tl_paraultilitarios, tl_parabackup, ") '35
                            _sqlUsuario.Append("tl_cadcomodato, tl_cadautomovel, tl_cadgerais, tl_cadgerente, tl_movrequisicao, ") '40
                            _sqlUsuario.Append("tl_movemispedido, tl_movgeramapa, tl_mpvenda, tl_mpretornovenda, ") '44
                            _sqlUsuario.Append("tl_estrelatorios, tl_paraconfiguracao ") '46
                            _sqlUsuario.Append("FROM relatoriotelas WHERE rt_geno = @rt_geno")
                            _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                            _cmdUsuario.Parameters.Add("@rt_geno", MdlEmpresaUsu._codigo)
                            _dr = _cmdUsuario.ExecuteReader
                            If _dr.HasRows = True Then validaLoginRelatorioTelas(_dr)

                            _cmdUsuario.CommandText = ""
                            _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
                            _dr.Close()
                        Else
                            resultadoLogin = False
                        End If

                    End If

                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                    resultadoLogin = False
                End Try

                _cmdUsuario.CommandText = ""
                _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
            End If

            conection.ClearAllPools() : conection.Close()
        Catch ex_ As Exception
            MsgBox("ERRO:: " & ex_.Message, MsgBoxStyle.Critical)

            Try
                conection.ClearAllPools()
                If conection.State = ConnectionState.Open Then conection.Close()
                _sqlUsuario = Nothing : _cmdUsuario = Nothing : _dr = Nothing : conection = Nothing
                Return False
            Catch ex As Exception
            End Try
        End Try

        _sqlUsuario = Nothing : _cmdUsuario = Nothing : _dr = Nothing : conection = Nothing

        Return resultadoLogin
    End Function

    Private Sub Frm_login_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        _formRequest._frmRef.rlogin = _loginOK

    End Sub

    Private Sub txt_login_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_login.GotFocus
        Me.txt_login.SelectAll()
    End Sub

    Private Sub txt_login_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_login.KeyPress
        'permite só letras
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = INT_mValorZERO Then e.Handled = True

    End Sub

    Private Function tempoOK(ByVal tempo As Integer) As Boolean

        Dim cont As Integer = 0

        While cont < 3

            System.Threading.Thread.Sleep(CInt((tempo * 1000)))
            cont += 1
        End While

        Return True
    End Function

    Private Sub Frm_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        MdlConexaoBD.conectionPadrao = "Server=" & _clFuncoes.trazIpServidorBD(_camihoArq) & _
        ";Port=5432;UserId=postgres;Password=Servnet;Database=" & _clFuncoes.trazNomeBancoServidorBD(_camihoArq) & _
        ";maxPoolSize=100;Timeout=7;CommandTimeout=7;"

        _mac = _clFuncoes.EnderecoMac
        _sincronizar = _clFuncoes.trazSincronizaBD(_mac, MdlConexaoBD.conectionPadrao)
        If agora >= DateValue(Hoje) Then
            Me.Close()
            Return
        End If

    End Sub

    Private Sub Frm_login_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        _frmRef = Me
        Dim mFrmLogGeral As New Frm_LoginGeral
        mFrmLogGeral.set_frmRef(Me)
        mFrmLogGeral.ShowDialog()
        mFrmLogGeral.Dispose()

        If _privilegio = True Then

            Dim mFrmConfBD As New Frm_ConfigBD
            mFrmConfBD.ShowDialog()
        End If


    End Sub

End Class