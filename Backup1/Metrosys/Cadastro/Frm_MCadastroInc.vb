Imports System
Imports System.Data
Imports Npgsql
Imports System.Text.RegularExpressions

Public Class Frm_MCadastroInc

    Private Const _vlrZERO As Integer = 0
    Dim _clFunc As New ClFuncoes
    Dim _clBD As New Cl_bdMetrosys
    Dim clCap001 As New Cl_Cadp001
    Private _mtipo As String = "C"
    Private _ufCorrenteCbo As String = ""

    Private Sub Frm_MCadastroInc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If (e.KeyCode = Keys.Escape) Then Me.Close()

    End Sub

    Private Sub Frm_MCadastroInc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub RdBFisica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBFisica.CheckedChanged

        If Me.RdBFisica.Checked = True Then

            Me.txt_insc.Enabled = False : Me.msk_cnpj.Enabled = False : Me.msk_cpf.Enabled = True
            Me.txt_ident.Enabled = True : Me.cbo_sexo.SelectedIndex = -1 : Me.cbo_sexo.Enabled = True
            Me.lbl_RazaoSocial.Text = "Nome:" : Me.lbl_RazaoSocial.SetBounds(163, 19, 38, 13)
            Me.txt_Fantasia.Enabled = False

        End If


    End Sub

    Private Sub RdBJuridica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBJuridica.CheckedChanged

        If Me.RdBJuridica.Checked = True Then

            Me.txt_insc.Enabled = True : Me.msk_cnpj.Enabled = True : Me.msk_cpf.Enabled = False
            Me.txt_ident.Enabled = False : Me.cbo_sexo.SelectedIndex = 2 : Me.cbo_sexo.Enabled = False
            Me.lbl_RazaoSocial.Text = "RazãoSocial:" : Me.lbl_RazaoSocial.SetBounds(132, 19, 70, 13)
            Me.txt_Fantasia.Enabled = True

        End If


    End Sub

    Private Sub AlfaMaiuscula()

        Me.txt_RazaoSocialNome.CharacterCasing = CharacterCasing.Upper
        Me.txt_insc.CharacterCasing = CharacterCasing.Upper
        Me.txt_Fantasia.CharacterCasing = CharacterCasing.Upper
        Me.txt_endereco.CharacterCasing = CharacterCasing.Upper
        Me.txt_bairro.CharacterCasing = CharacterCasing.Upper
        Me.txt_preposto.CharacterCasing = CharacterCasing.Upper
        Me.txt_ident.CharacterCasing = CharacterCasing.Upper
        Me.txt_obs1.CharacterCasing = CharacterCasing.Upper
        Me.txt_obs2.CharacterCasing = CharacterCasing.Upper
        Me.txt_obs3.CharacterCasing = CharacterCasing.Upper
        Me.txt_RazaoSocialNome.Modified = True


    End Sub

    Private Function Testa_controle() As Boolean

        Try
            If Me.cbo_uf.SelectedIndex = -1 Then MessageBox.Show(Me.cbo_uf.SelectedItem.ToString, "Item Selecionado ")

            If (Me.RdBFisica.Checked = False) And (Me.RdBJuridica.Checked = False) Then

                MessageBox.Show("Erro Caracteristica", "Fisica ou Juridica ")
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("Item não selecionado ", "Erro UF")
            Me.txt_Fantasia.Focus() : Return False

        End Try



    End Function

    Private Sub cbo_uf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_uf.GotFocus

        If Not (cbo_uf.DroppedDown) Then cbo_uf.DroppedDown = True

    End Sub

    Private Sub cbo_uf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_uf.Leave

        If _ufCorrenteCbo.Equals("") Then

            If cbo_uf.SelectedIndex >= _vlrZERO Then

                Me.cbo_cidade = _clFunc.PreenchComboMunicipios(Me.cbo_uf.SelectedItem, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
                _ufCorrenteCbo = Me.cbo_uf.SelectedItem

            End If
        ElseIf cbo_uf.SelectedIndex > _vlrZERO And Not _ufCorrenteCbo.Equals(cbo_uf.Text) Then

            Me.cbo_cidade = _clFunc.PreenchComboMunicipios(Me.cbo_uf.SelectedItem, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
            _ufCorrenteCbo = Me.cbo_uf.SelectedItem

        End If



    End Sub

    Private Sub Frm_MCadastro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cbo_uf.Items.Add("AC") : Me.cbo_uf.Items.Add("AL") : Me.cbo_uf.Items.Add("AP")
        Me.cbo_uf.Items.Add("AM") : Me.cbo_uf.Items.Add("BA") : Me.cbo_uf.Items.Add("CE")
        Me.cbo_uf.Items.Add("DF") : Me.cbo_uf.Items.Add("ES") : Me.cbo_uf.Items.Add("EX")
        Me.cbo_uf.Items.Add("GO") : Me.cbo_uf.Items.Add("MA") : Me.cbo_uf.Items.Add("MT")
        Me.cbo_uf.Items.Add("MS") : Me.cbo_uf.Items.Add("MG") : Me.cbo_uf.Items.Add("PA")
        Me.cbo_uf.Items.Add("PB") : Me.cbo_uf.Items.Add("PE") : Me.cbo_uf.Items.Add("PI")
        Me.cbo_uf.Items.Add("RJ") : Me.cbo_uf.Items.Add("RN") : Me.cbo_uf.Items.Add("RS")
        Me.cbo_uf.Items.Add("RO") : Me.cbo_uf.Items.Add("RR") : Me.cbo_uf.Items.Add("SC")
        Me.cbo_uf.Items.Add("SP") : Me.cbo_uf.Items.Add("SE") : Me.cbo_uf.Items.Add("TO")
        Me.cbo_uf.Items.Add("PR")

        Me.cbo_uf.Sorted = True : Me.msk_UltCompra.Enabled = False : Me.msk_valor.Enabled = False
        Me.txt_pedido.Enabled = False : AlfaMaiuscula() : Me.RdBCli.Checked = True : Me.RdBFisica.Checked = True
        Me.txt_RazaoSocialNome.Focus()

        If Not MdlUsuarioLogando._local.Equals("") Then

            cbo_loja.Items.Clear() : cbo_loja.Refresh() : cbo_loja.Items.Add(MdlUsuarioLogando._local)
            cbo_loja.Refresh()
        End If

        If MdlUsuarioLogando._usuarioPrivilegio = True Then
            cbo_loja = _clFunc.PreenchComboLoja2(cbo_loja, MdlConexaoBD.conectionPadrao)
        End If
        cbo_vendedores = _clFunc.PreenchComboVendedores(cbo_vendedores, MdlConexaoBD.conectionPadrao)


        'Se a Empresa for SIMPLES
        If MdlEmpresaUsu._crt.Equals("1") Then Me.chk_isento.Checked = True

    End Sub

    Private Sub txt_RazaoSocial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_RazaoSocialNome.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            If (Me.RdBFisica.Checked = False) And (Me.RdBJuridica.Checked = False) Then

                MessageBox.Show("Fisica ou Juridica ? ", " Erro Caracteristica ", MessageBoxButtons.OK, MessageBoxIcon.Question)
            End If
        End If



    End Sub

    Private Sub cbo_loja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_loja.GotFocus

        If Not (Me.cbo_loja.DroppedDown) Then Me.cbo_loja.DroppedDown = True

    End Sub

    Private Sub btn_proximaAba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proximaAba.Click

        tbc_participante.SelectTab(1)

    End Sub

    Private Function verificaParticipante()

        Dim mNaoDeuErro As Boolean = True
        lbl_mensagem.Text = "" : lbl_mensagem_.Text = ""

        'If Me.cbo_loja.SelectedIndex < _vlrZERO Then

        '    mNaoDeuErro = False : lbl_mensagem.Text = "Selecione uma LOJA por favor !"
        '    lbl_mensagem_.Text = "Selecione uma LOJA por favor !" : Return mNaoDeuErro
        'End If


        If (Me.RdBCli.Checked = False) AndAlso (Me.RdBForn.Checked = False) _
        AndAlso (Me.RdBTransp.Checked = False) Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Selecione um tipo de Participante !"
            lbl_mensagem_.Text = "Selecione um tipo de Participante !" : Return mNaoDeuErro
        End If


        If (Me.RdBFisica.Checked = False) AndAlso (Me.RdBJuridica.Checked = False) Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Selecione a característica do Participante !"
            lbl_mensagem_.Text = "Selecione a característica do Participante !" : Return mNaoDeuErro
        End If


        If Trim(Me.txt_codigo.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Código do participante não informado !"
            lbl_mensagem_.Text = "Código do participante não informado !" : Return mNaoDeuErro
        End If


        If Trim(Me.txt_RazaoSocialNome.Text).Equals("") Then

            If RdBFisica.Checked = True Then

                mNaoDeuErro = False : lbl_mensagem.Text = "Informe a Razao Social do Participante !"
                lbl_mensagem_.Text = "Informe a Razao Social do Participante !" : Return mNaoDeuErro

            ElseIf RdBJuridica.Checked = True Then

                mNaoDeuErro = False : lbl_mensagem.Text = "Informe o Nome do Participante !"
                lbl_mensagem_.Text = "Informe o Nome do Participante !" : Return mNaoDeuErro
            End If
        End If


        If RdBFisica.Checked Then

            'If Not IsDate(Me.msk_nascativ.Text) Then

            '    mNaoDeuErro = False : lbl_mensagem.Text = "Informe a Data de Nasc/Ativ do Paricipante !"
            '    lbl_mensagem_.Text = "Informe a Data de Nasc/Ativ do Paricipante !" : Return mNaoDeuErro

            'End If
        End If

        If Trim(Me.txt_endereco.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Informe o ENDEREÇO do Participante !"
            lbl_mensagem_.Text = "Informe o ENDEREÇO do Participante !" : Return mNaoDeuErro
        End If

        If Me.cbo_uf.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Informe a UF do Participante !"
            lbl_mensagem_.Text = "Informe a UF do Participante !" : Return mNaoDeuErro
        End If

        If Me.cbo_cidade.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Informe a CIDADE do Participante !"
            lbl_mensagem_.Text = "Informe a CIDADE do Participante !" : Return mNaoDeuErro
        End If

        If Trim(Me.txt_bairro.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Informe o BAIRRO do Participante !"
            lbl_mensagem_.Text = "Informe o BAIRRO do Participante !" : Return mNaoDeuErro
        End If

        If Trim(Me.msk_cep.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Informe o CEP do Participante !"
            lbl_mensagem_.Text = "Informe o CEP do Participante !" : Return mNaoDeuErro
        End If

        If Trim(Me.msk_fone.Text).Equals("") AndAlso Trim(Me.msk_celular.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Informe um TelefoneFixo ou Celular do Participante !"
            lbl_mensagem_.Text = "Informe um TelefoneFixo ou Celular do Participante !" : Return mNaoDeuErro
        End If

        'If (cbo_vendedores.SelectedIndex < _vlrZERO) AndAlso (cbo_vendedores.Items.Count > _vlrZERO) Then

        '    mNaoDeuErro = False
        '    lbl_mensagem.Text = "Informe um Vendedor por favor !"
        '    lbl_mensagem_.Text = "Informe um Vendedor por favor !"
        '    Return mNaoDeuErro

        'End If

        If Me.RdBFisica.Checked Then

            If Trim(Me.txt_ident.Text).Equals("") Then 'AndAlso Trim(Me.msk_cpf.Text).Equals("") Then

                mNaoDeuErro = False : lbl_mensagem.Text = "Informe a Identidade do Participante !"
                lbl_mensagem_.Text = "Informe a Identidade do Participante !" : Return mNaoDeuErro

            ElseIf _clFunc.existIdentidadeCadp001(txt_ident.Text, MdlConexaoBD.conectionPadrao) Then

                mNaoDeuErro = False : lbl_mensagem.Text = "IDENTIDADE Já Existe !"
                lbl_mensagem_.Text = "IDENTIDADE Já Existe !" : Return mNaoDeuErro
            End If


            If MdlEmpresaUsu.cpfvalidar Then

                If Trim(Me.msk_cpf.Text).Equals("") Then

                    mNaoDeuErro = False : lbl_mensagem.Text = "Informe o CPF do Participante !"
                    lbl_mensagem_.Text = "Informe o CPF do Participante !" : Return mNaoDeuErro

                Else

                    If Not _clBD.ValidaCPF(_clFunc.RemoverCaracter2(Me.msk_cpf.Text)) Then

                        lbl_mensagem.Text = "CPF Incorreto !" : lbl_mensagem_.Text = "CPF Incorreto !"
                        mNaoDeuErro = False : Return mNaoDeuErro

                    ElseIf _clFunc.existCpfCadp001(_clFunc.RemoverCaracter2(Me.msk_cpf.Text), _
                                                MdlConexaoBD.conectionPadrao) Then

                        mNaoDeuErro = False : lbl_mensagem.Text = "CPF Já Existe !"
                        lbl_mensagem_.Text = "CPF Já Existe !" : Return mNaoDeuErro
                    End If

                End If

            End If

        End If


        If Me.RdBJuridica.Checked Then

            If Trim(Me.msk_cnpj.Text).Equals("") Then

                mNaoDeuErro = False : lbl_mensagem.Text = "Informe o CNPJ do Participante !"
                lbl_mensagem_.Text = "Informe o CNPJ do Participante !" : Return mNaoDeuErro

            ElseIf Not _clBD.ValidaCNPJ(_clFunc.RemoverCaracter2(Me.msk_cnpj.Text)) Then

                mNaoDeuErro = False : lbl_mensagem.Text = "CNPJ Incorreto !"
                lbl_mensagem_.Text = "CNPJ Incorreto !" : Return mNaoDeuErro

            ElseIf _clFunc.existCnpjCadp001(_clFunc.RemoverCaracter2(Me.msk_cnpj.Text), _
                                            MdlConexaoBD.conectionPadrao) Then

                mNaoDeuErro = False : lbl_mensagem.Text = "CNPJ Já Existe !"
                lbl_mensagem_.Text = "CNPJ Já Existe !" : Return mNaoDeuErro
            End If


            If Trim(Me.txt_insc.Text).Equals("") Then

                mNaoDeuErro = False : lbl_mensagem.Text = "Informe a INSCRIÇÂO do Participante !"
                lbl_mensagem_.Text = "Informe a INSCRIÇÂO do Participante !" : Return mNaoDeuErro

            ElseIf _clFunc.existInscricaoCadp001(txt_insc.Text, MdlConexaoBD.conectionPadrao) Then

                mNaoDeuErro = False : lbl_mensagem.Text = "INSCRIÇÃO ESTADUAL Já Existe !"
                lbl_mensagem_.Text = "INSCRIÇÃO ESTADUAL Já Existe !" : Return mNaoDeuErro
            End If

        End If

        ' Pattern ou mascara de verificação do email
        'Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\." _
        '& "[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"

        'If Trim(Me.txt_email.Text).Equals("") Then

        '    mNaoDeuErro = False : lbl_mensagem.Text = "Informe o EMAIL do Paricipante !"
        '    lbl_mensagem_.Text = "Informe o EMAIL do Paricipante !" : Return mNaoDeuErro

        'ElseIf Not Regex.Match(Me.txt_email.Text, pattern).Success Then

        '    mNaoDeuErro = False : lbl_mensagem.Text = "EMAIL Incorreto !"
        '    lbl_mensagem_.Text = "EMAIL Incorreto !" : Return mNaoDeuErro
        'End If



        Return mNaoDeuErro
    End Function

    Private Sub salvaParticipanteIcluindo(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)


        'Preechendo objetos CADP001
        clCap001.pTipo = _mtipo
        If Me.RdBFisica.Checked Then
            clCap001.pCarac = "F"
        Else
            clCap001.pCarac = "J"
        End If

        Try
            clCap001.pDtcad = CDate(Trim(dtp_cadastro.Text))
        Catch ex As Exception
        End Try

        clCap001.pCod = Trim(Me.txt_codigo.Text) : clCap001.pPortad = Trim(txt_RazaoSocialNome.Text)
        clCap001.pFantas = Trim(txt_Fantasia.Text)

        Try
            clCap001.pDtnativ = CDate(Trim(msk_nascativ.Text))
        Catch ex As Exception
        End Try

        clCap001.pEnder = Trim(txt_endereco.Text)
        clCap001.pUf = Trim(Me.cbo_uf.SelectedItem) : clCap001.pCid = Trim(Me.cbo_cidade.SelectedItem)
        clCap001.pBairro = Trim(txt_bairro.Text) : clCap001.pCep = Trim(msk_cep.Text)
        If IsNumeric(msk_celular.Text) Then clCap001.pCelular = Trim(msk_celular.Text)
        If IsNumeric(msk_fone.Text) Then clCap001.pFone = Trim(msk_fone.Text)

        If cbo_vendedores.SelectedIndex < _vlrZERO Then
            clCap001.pVend = "" : clCap001.pCdvend = ""
        Else
            clCap001.pVend = Trim(Mid(cbo_vendedores.SelectedItem, 1, 6)) : clCap001.pCdvend = Trim(Mid(cbo_vendedores.SelectedItem, 4, 3))
        End If

        Try
            If IsNumeric(Trim(txt_rota.Text)) Then clCap001.pRota = CInt(Trim(txt_rota.Text))
        Catch ex As Exception
            clCap001.pRota = 0
        End Try

        clCap001.pIdent = Trim(txt_ident.Text) : clCap001.pCpf = Trim(_clFunc.RemoverCaracter2(msk_cpf.Text))
        clCap001.pCgc = Trim(_clFunc.RemoverCaracter2(msk_cnpj.Text)) : clCap001.pInsc = Trim(txt_insc.Text)
        clCap001.pPrep = Trim(Me.txt_preposto.Text) : clCap001.pFax = Trim(Me.msk_fax.Text)
        clCap001.pSexo = cbo_sexo.SelectedItem : clCap001.pEmail = txt_email.Text : clCap001.pMun = txt_codmun.Text
        clCap001.pCoduf = _clBD.trazCodEstado(conection, clCap001.pUf) : clCap001.pCoduf = Trim(clCap001.pCoduf)
        clCap001.pInativo = chk_inativo.Checked
        Try
            clCap001.pUsuario = Mid(MdlUsuarioLogando._usuarioNome, 1, 10)
        Catch ex As Exception
            clCap001.pUsuario = MdlUsuarioLogando._usuarioNome
        End Try

        clCap001.pConsumo = "N"
        If chk_consumo.Checked Then clCap001.pConsumo = "S"

        clCap001.pIsento = chk_isento.Checked

        clCap001.pBloq = "N"
        If chk_bloqueio.Checked Then clCap001.pBloq = "S"

        'Chamando a fução de gravar as informações do fornecedor...
        _clBD.inclueParticipante(clCap001, conection, transacao)

        _clBD.updateCadregCodcli(conection, CInt(Mid(clCap001.pCod, 2, 5)))



    End Sub

    Private Sub btn_salvar_Click_Incluindo()

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
            salvaParticipanteIcluindo(conection, transacao)
            transacao.Commit() : conection.ClearPool()

            If MessageBox.Show("Participante salvo com sucesso! Deseja continuar Incluido?", "BDMETROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                'Me.txt_codigo.Text = "" : Me.msk_cpf.Text = "" : Me.msk_cnpj.Text = "" : Me.txt_insc.Text = ""
                'Me.txt_bairro.Text = "" : Me.txt_RazaoSocialNome.Text = "" : Me.txt_Fantasia.Text = "" : Me.txt_endereco.Text = ""
                'Me.msk_fone.Text = "" : Me.msk_fax.Text = "" : Me.msk_celular.Text = ""
                clCap001.zeraValores()
                tbc_participante.SelectTab(0) : conection.Close()
                transacao = Nothing : conection = Nothing

            Else
                conection.Close() : transacao = Nothing : conection = Nothing : Me.Close()
            End If

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try
        
        End Try



    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        If RdBCli.Checked = True Then _mtipo = "C"
        If RdBForn.Checked = True Then _mtipo = "F"
        If RdBTransp.Checked = True Then _mtipo = "T"


        If Me.txt_codigo.Text.Equals("") Then
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try

                Try
                    conection.Open()
                Catch ex As Exception
                    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                    Return

                End Try

                Me.txt_codigo.Text = String.Format("{0:D5}", _clBD.trazProxCodForn(conection))
                If RdBCli.Checked = True Then Me.txt_codigo.Text = "C" & Me.txt_codigo.Text
                If RdBForn.Checked = True Then Me.txt_codigo.Text = "F" & Me.txt_codigo.Text
                If RdBTransp.Checked = True Then Me.txt_codigo.Text = "F" & Me.txt_codigo.Text
                conection.ClearPool() : conection.Close()

            Catch ex As Exception
            End Try

            conection = Nothing
        End If

        If verificaParticipante() Then
            btn_salvar_Click_Incluindo()

        End If





    End Sub

    Private Sub cbo_cidade_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cidade.Leave

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Me.txt_codmun.Text = _clBD.trazCodMun(conection, Me.cbo_uf.SelectedItem, Me.cbo_cidade.SelectedItem)
        conection.ClearPool() : conection.Close() : conection = Nothing



    End Sub

    Private Sub msk_cpf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_cpf.Leave

        lbl_mensagem.Text = "" : lbl_mensagem_.Text = ""

        ' Pattern ou mascara de verificação do Cpf
        If MdlEmpresaUsu.cpfvalidar = True Then

            If _clBD.ValidaCPF(Me.msk_cpf.Text) = False Then

                lbl_mensagem.Text = "CPF Incorreto !" : lbl_mensagem_.Text = "CPF Incorreto !"
            End If
        End If


    End Sub

    Private Sub msk_cnpj_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_cnpj.Leave

        lbl_mensagem.Text = "" : lbl_mensagem_.Text = ""

        If Trim(Me.msk_cnpj.Text).Equals("") Then

            lbl_mensagem.Text = "Informe o CNPJ do Paricipante !"
            lbl_mensagem_.Text = "Informe o CNPJ do Paricipante !"

        ElseIf Not _clBD.ValidaCNPJ(_clFunc.RemoverCaracter2(Me.msk_cnpj.Text)) Then

            lbl_mensagem.Text = "CNPJ Incorreto !" : lbl_mensagem_.Text = "CNPJ Incorreto !"
        End If



    End Sub

    Private Sub msk_cep_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_cep.Leave

        lbl_mensagem.Text = "" : lbl_mensagem_.Text = ""

        ' Pattern ou mascara de verificação do Cpf
        Dim pattern As String = "^\d{5}\-?\d{3}$"

        If Not Regex.Match(Me.msk_cep.Text, pattern).Success Then

            lbl_mensagem.Text = "CEP Incorreto !" : lbl_mensagem_.Text = "CEP Incorreto !"
        End If



    End Sub

    Private Sub cbo_vendedores_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_vendedores.GotFocus

        If Not cbo_vendedores.DroppedDown Then cbo_vendedores.DroppedDown = True

    End Sub

End Class