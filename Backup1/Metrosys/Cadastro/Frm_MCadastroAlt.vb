Imports System
Imports System.Data
Imports Npgsql
Imports System.Text.RegularExpressions

Public Class Frm_MCadastroAlt

    Private Const _vlrZERO As Integer = 0
    Dim _clFunc As New ClFuncoes
    Dim _clBD As New Cl_bdMetrosys
    Dim clCadp001 As New Cl_Cadp001
    Dim _codAtual As String = ""

    Private _ufCorrenteCbo As String = ""
    Private _mtipo As String = "C"
    Private _MenuCadatro As New Frm_MenuCadastro

    Private Sub Frm_MCadastroAlt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If (e.KeyCode = Keys.Escape) Then Me.Close()

    End Sub

    Private Sub Frm_MCadastroAlt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
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
            If Me.RdBFisica.Checked = False And Me.RdBJuridica.Checked = False Then MessageBox.Show("Erro Caracteristica", "Fisica ou Juridica ")
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

                Me.cbo_cidade = _clFunc.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
                _ufCorrenteCbo = Me.cbo_uf.Text

            End If
        ElseIf cbo_uf.SelectedIndex > _vlrZERO And Not _ufCorrenteCbo.Equals(cbo_uf.Text) Then

            Me.cbo_cidade = _clFunc.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
            _ufCorrenteCbo = Me.cbo_uf.Text

        End If



    End Sub

    Private Sub setValoresPart()

        Me.txt_codigo.Text = _MenuCadatro._FrmRef.clCadp001.pCod
        _codAtual = _MenuCadatro._FrmRef.clCadp001.pCod
        Me.txt_RazaoSocialNome.Text = _MenuCadatro._FrmRef.clCadp001.pPortad

        If _MenuCadatro._FrmRef.clCadp001.pTipo.Equals("C") Then RdBCli.Checked = True
        If _MenuCadatro._FrmRef.clCadp001.pTipo.Equals("F") Then RdBForn.Checked = True
        If _MenuCadatro._FrmRef.clCadp001.pTipo.Equals("T") Then RdBTransp.Checked = True

        If _MenuCadatro._FrmRef.clCadp001.pCarac.Equals("F") Then
            RdBFisica.Checked = True
        Else
            RdBJuridica.Checked = True
        End If

        Try
            dtp_cadastro.Text = Format(CDate(_MenuCadatro._FrmRef.clCadp001.pDtcad), "ddMMyyyy")
        Catch ex As Exception
        End Try


        Me.txt_Fantasia.Text = _MenuCadatro._FrmRef.clCadp001.pFantas
        Try
            Me.msk_nascativ.Text = Format(CDate(_MenuCadatro._FrmRef.clCadp001.pDtnativ), "ddMMyyyy")
        Catch ex As Exception
        End Try

        Me.txt_endereco.Text = _MenuCadatro._FrmRef.clCadp001.pEnder

        Me.cbo_uf.SelectedIndex = trazIndexUF(_MenuCadatro._FrmRef.clCadp001.pUf, cbo_uf)
        If cbo_uf.SelectedIndex >= 0 Then

            Me.cbo_cidade = _clFunc.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
            cbo_cidade.Refresh()
            cbo_cidade.SelectedIndex = trazIndexMUN(_MenuCadatro._FrmRef.clCadp001.pCid, cbo_cidade)
            _ufCorrenteCbo = cbo_uf.Text

        End If

        Me.txt_bairro.Text = _MenuCadatro._FrmRef.clCadp001.pBairro : Me.msk_cep.Text = _MenuCadatro._FrmRef.clCadp001.pCep
        Me.msk_fone.Text = _MenuCadatro._FrmRef.clCadp001.pFone : Me.msk_fax.Text = _MenuCadatro._FrmRef.clCadp001.pFax
        Me.msk_celular.Text = _MenuCadatro._FrmRef.clCadp001.pCelular
        cbo_vendedores.SelectedIndex = _clFunc.trazIndexCboVendedor(_MenuCadatro._FrmRef.clCadp001.pVend, cbo_vendedores)
        Me.txt_preposto.Text = _MenuCadatro._FrmRef.clCadp001.pPrep : Me.txt_rota.Text = _MenuCadatro._FrmRef.clCadp001.pRota
        Me.txt_ident.Text = _MenuCadatro._FrmRef.clCadp001.pIdent : Me.msk_cpf.Text = _MenuCadatro._FrmRef.clCadp001.pCpf
        Me.msk_cnpj.Text = _MenuCadatro._FrmRef.clCadp001.pCgc : Me.txt_insc.Text = _MenuCadatro._FrmRef.clCadp001.pInsc
        Me.txt_codmun.Text = _MenuCadatro._FrmRef.clCadp001.pMun : Me.txt_email.Text = _MenuCadatro._FrmRef.clCadp001.pEmail
        Me.cbo_sexo.SelectedIndex = trazIndexSexo(_MenuCadatro._FrmRef.clCadp001.pSexo, Me.cbo_sexo)
        Me.chk_isento.Checked = _MenuCadatro._FrmRef.clCadp001.pIsento

        Try
            Me.msk_UltCompra.Text = CDate(_MenuCadatro._FrmRef.clCadp001.pUltcomp.Date)

            Try
                If CInt(Me.msk_UltCompra.Text) = 0 Then
                    Me.msk_UltCompra.Text = ""
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
            Me.msk_UltCompra.Text = ""
        End Try

        Me.chk_consumo.Checked = False
        If _MenuCadatro._FrmRef.clCadp001.pConsumo.Equals("S") Then Me.chk_consumo.Checked = True


    End Sub

    Public Function trazIndexUF(ByVal mUF As String, ByVal mCboUF As Object) As Integer

        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = _vlrZERO To mCboUF.Items.Count - 1

            If mUF.Equals(Trim(mCboUF.Items.Item(index).ToString.Substring(_vlrZERO, 2))) Then
                indiceCfop = index
                Exit For

            End If
        Next



        Return indiceCfop
    End Function

    Public Function trazIndexMUN(ByVal mMUN As String, ByVal mCboMUN As Object) As Integer

        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = _vlrZERO To mCboMUN.Items.Count - 1

            If mMUN.Equals(Trim(mCboMUN.Items.Item(index).ToString)) Then
                indiceCfop = index
                Exit For

            End If
        Next



        Return indiceCfop
    End Function

    Public Function trazIndexSexo(ByVal mSexo As String, ByVal mCboSexo As Object) As Integer

        Dim index As Integer : Dim indicesexo As Integer = -1
        For index = _vlrZERO To mCboSexo.Items.Count - 1

            If mSexo.Equals(Trim(mCboSexo.Items.Item(index).ToString)) Then
                indicesexo = index
                Exit For

            End If
        Next



        Return indicesexo
    End Function

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

        Me.cbo_uf.Sorted = True : Me.msk_UltCompra.Enabled = False : Me.msk_valor.Enabled = False : Me.RdBCli.Checked = True
        AlfaMaiuscula() : Me.txt_pedido.Enabled = False : Me.RdBFisica.Checked = True : Me.txt_RazaoSocialNome.Focus()

        If Not MdlUsuarioLogando._local.Equals("") Then
            cbo_loja.Items.Clear() : cbo_loja.Refresh() : cbo_loja.Items.Add(MdlUsuarioLogando._local)
            cbo_loja.Refresh()

        End If

        If MdlUsuarioLogando._usuarioPrivilegio = True Then
            cbo_loja = _clFunc.PreenchComboLoja2(cbo_loja, MdlConexaoBD.conectionPadrao)
        End If

        cbo_vendedores = _clFunc.PreenchComboVendedores(cbo_vendedores, MdlConexaoBD.conectionPadrao)

        'setValoresPart() deve ficar sempre no final do FormLoad...
        setValoresPart()



    End Sub

    Private Sub txt_RazaoSocial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_RazaoSocialNome.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            If Me.RdBFisica.Checked = False And Me.RdBJuridica.Checked = False Then
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

            mNaoDeuErro = False : lbl_mensagem.Text = "Código do Participante não informado !"
            lbl_mensagem_.Text = "Código do Participante não informado !" : Return mNaoDeuErro
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

            'If Trim(Me.txt_ident.Text).Equals("") AndAlso Trim(Me.msk_cpf.Text).Equals("") Then

            '    mNaoDeuErro = False : lbl_mensagem.Text = "Informe a Identidade ou CPF do Paricipante !"
            '    lbl_mensagem_.Text = "Informe a Identidade  ou CPF do Paricipante !" : Return mNaoDeuErro
            'End If


            If Trim(Me.txt_ident.Text).Equals("") Then 'AndAlso Trim(Me.msk_cpf.Text).Equals("") 

                mNaoDeuErro = False : lbl_mensagem.Text = "Informe a Identidade do Participante !"
                lbl_mensagem_.Text = "Informe a Identidade do Participante !" : Return mNaoDeuErro
            End If


            If MdlEmpresaUsu.cpfvalidar Then

                If Trim(Me.msk_cpf.Text).Equals("") Then


                    mNaoDeuErro = False : lbl_mensagem.Text = "Informe o CPF do Participante !"
                    lbl_mensagem_.Text = "Informe o CPF do Participante !" : Return mNaoDeuErro

                Else

                    If Not _clBD.ValidaCPF(_clFunc.RemoverCaracter2(Me.msk_cpf.Text)) Then

                        lbl_mensagem.Text = "CPF Incorreto !" : lbl_mensagem_.Text = "CPF Incorreto !"
                        mNaoDeuErro = False : Return mNaoDeuErro

                    ElseIf _clFunc.existCpfCadp001(_clFunc.RemoverCaracter2(Me.msk_cpf.Text), Me.txt_codigo.Text, _
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

                lbl_mensagem.Text = "CNPJ Incorreto !" : lbl_mensagem_.Text = "CNPJ Incorreto !"

            ElseIf _clFunc.existCnpjCadp001(_clFunc.RemoverCaracter2(Me.msk_cnpj.Text), Me.txt_codigo.Text, _
                                        MdlConexaoBD.conectionPadrao) Then

                mNaoDeuErro = False : lbl_mensagem.Text = "CNPJ Já Existe !"
                lbl_mensagem_.Text = "CNPJ Já Existe !" : Return mNaoDeuErro

            End If

            If Trim(Me.txt_insc.Text).Equals("") Then

                mNaoDeuErro = False : lbl_mensagem.Text = "Informe a INSCRIÇÂO do Participante !"
                lbl_mensagem_.Text = "Informe a INSCRIÇÂO do Participante !" : Return mNaoDeuErro
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

    Private Sub salvaParticipanteAlterando(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)


        'Preechendo objetos para CADP001
        clCadp001.pTipo = _mtipo
        If Me.RdBFisica.Checked Then
            clCadp001.pCarac = "F"
        Else
            clCadp001.pCarac = "J"
        End If

        Try
            clCadp001.pDtcad = CDate(Trim(dtp_cadastro.Text))
        Catch ex As Exception
        End Try

        clCadp001.pCod = Trim(Me.txt_codigo.Text)
        clCadp001.pPortad = Trim(txt_RazaoSocialNome.Text)
        clCadp001.pFantas = Trim(txt_Fantasia.Text)

        Try
            clCadp001.pDtnativ = CDate(Trim(msk_nascativ.Text))
        Catch ex As Exception
        End Try

        clCadp001.pEnder = Trim(txt_endereco.Text)
        clCadp001.pUf = Trim(Me.cbo_uf.SelectedItem) : clCadp001.pCid = Trim(Me.cbo_cidade.SelectedItem) : clCadp001.pBairro = Trim(txt_bairro.Text)
        clCadp001.pCep = Trim(msk_cep.Text)
        If IsNumeric(msk_celular.Text) Then clCadp001.pCelular = Trim(msk_celular.Text)
        If IsNumeric(msk_fone.Text) Then clCadp001.pFone = Trim(msk_fone.Text)

        If cbo_vendedores.SelectedIndex < _vlrZERO Then
            clCadp001.pVend = "" : clCadp001.pCdvend = ""
        Else
            clCadp001.pVend = Trim(Mid(cbo_vendedores.SelectedItem, 1, 6)) : clCadp001.pCdvend = Trim(Mid(cbo_vendedores.SelectedItem, 4, 3))
        End If

        Try
            If IsNumeric(Trim(txt_rota.Text)) Then clCadp001.pRota = Trim(txt_rota.Text)
        Catch ex As Exception
        End Try


        clCadp001.pIdent = Trim(txt_ident.Text) : clCadp001.pCpf = Trim(_clFunc.RemoverCaracter2(msk_cpf.Text))
        clCadp001.pCgc = Trim(_clFunc.RemoverCaracter2(msk_cnpj.Text)) : clCadp001.pInsc = Trim(txt_insc.Text)
        clCadp001.pPrep = Trim(Me.txt_preposto.Text) : clCadp001.pFax = Trim(Me.msk_fax.Text) : clCadp001.pSexo = cbo_sexo.SelectedItem
        clCadp001.pEmail = txt_email.Text : clCadp001.pMun = txt_codmun.Text : clCadp001.pCoduf = _clBD.trazCodEstado(conection, clCadp001.pUf)
        clCadp001.pCoduf = Trim(clCadp001.pCoduf) : clCadp001.pInativo = chk_inativo.Checked
        clCadp001.pConsumo = "N"
        If chk_consumo.Checked Then clCadp001.pConsumo = "S"

        clCadp001.pIsento = chk_isento.Checked

        'Chamando a fução de gravar as informações do fornecedor...
        _clBD.altParticipante(clCadp001, _codAtual, conection, transacao)



    End Sub

    Private Sub btn_salvar_Click_Alterando()

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
            salvaParticipanteAlterando(conection, transacao)
            transacao.Commit()

            MsgBox("Participante salvo com sucesso", MsgBoxStyle.Exclamation)
            conection.ClearPool() : conection.Close()
            transacao = Nothing : conection = Nothing
            clCadp001.zeraValores()
            Me.Close()

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try
        
        End Try



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

        If _clBD.ValidaCPF(Me.msk_cpf.Text) = False Then

            lbl_mensagem.Text = "CPF Incorreto !" : lbl_mensagem_.Text = "CPF Incorreto !"
        End If



    End Sub

    Private Sub msk_cnpj_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_cnpj.Leave

        lbl_mensagem.Text = "" : lbl_mensagem_.Text = ""

        If _clBD.ValidaCNPJ(_clFunc.RemoverCaracter2(Me.msk_cnpj.Text)) = False Then

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

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If RdBCli.Checked = True Then _mtipo = "C"
        If RdBForn.Checked = True Then _mtipo = "F"
        If RdBTransp.Checked = True Then _mtipo = "T"


        If verificaParticipante() Then

            btn_salvar_Click_Alterando()

        End If



    End Sub

    Private Sub cbo_cidade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cidade.Click

        cbo_cidade.SelectAll()

    End Sub

    Private Sub RdBCli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBTransp.CheckedChanged, RdBForn.CheckedChanged, RdBCli.CheckedChanged

        If RdBCli.Checked = True Then Me.txt_codigo.Text = "C" & Mid(Me.txt_codigo.Text, 2, 5)
        If RdBForn.Checked = True Then Me.txt_codigo.Text = "F" & Mid(Me.txt_codigo.Text, 2, 5)
        If RdBTransp.Checked = True Then Me.txt_codigo.Text = "F" & Mid(Me.txt_codigo.Text, 2, 5)


    End Sub

    Private Sub cbo_vendedores_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_vendedores.GotFocus

        If Not cbo_vendedores.DroppedDown Then cbo_vendedores.DroppedDown = True

    End Sub

End Class