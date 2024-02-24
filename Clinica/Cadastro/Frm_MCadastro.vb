Imports System
Imports System.Data
Imports System.IO
Imports Npgsql
Imports System.Text.RegularExpressions

Public Class Frm_MCadastro

    Private Const _vlrZERO As Integer = 0
    Dim s As String
    Dim operador As [Enum]
    Dim _cl_fun As New Funcoes
    Dim xoper As New Cl_bdMetrosys
    Dim _cl_BD As New Cl_bdMetrosys
    Private _mtipo As String = "C"

    Private Sub Frm_Cadastro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Cadastro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
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

            Me.txt_insc.Enabled = False
            Me.msk_cnpj.Enabled = False
            Me.msk_cpf.Enabled = True
            Me.txt_ident.Enabled = True
            Me.cbo_sexo.SelectedIndex = -1
            Me.cbo_sexo.Enabled = True
            Me.lbl_RazaoSocial.Text = "Nome:"
            Me.lbl_RazaoSocial.SetBounds(163, 19, 38, 13)
            Me.txt_Fantasia.Enabled = False

        End If
    End Sub

    Private Sub RdBJuridica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBJuridica.CheckedChanged
        If Me.RdBJuridica.Checked = True Then

            Me.txt_insc.Enabled = True
            Me.msk_cnpj.Enabled = True
            Me.msk_cpf.Enabled = False
            Me.txt_ident.Enabled = False
            Me.cbo_sexo.SelectedIndex = 2
            Me.cbo_sexo.Enabled = False
            Me.lbl_RazaoSocial.Text = "RazãoSocial:"
            Me.lbl_RazaoSocial.SetBounds(132, 19, 70, 13)
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
            If Me.cbo_uf.SelectedIndex = -1 Then
                MessageBox.Show(Me.cbo_uf.SelectedItem.ToString, "Item Selecionado ")
            End If
            If Me.RdBFisica.Checked = False And Me.RdBJuridica.Checked = False Then
                MessageBox.Show("Erro Caracteristica", "Fisica ou Juridica ")

            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("Item não selecionado ", "Erro UF")
            Me.txt_Fantasia.Focus()
            Return False
        End Try
    End Function

    Private Sub cbo_uf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_uf.GotFocus
        If Not (cbo_uf.DroppedDown) Then cbo_uf.DroppedDown = True
    End Sub

    Private Sub cbo_uf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_uf.Leave
        If cbo_uf.SelectedIndex >= 0 Then cbo_cidade = _cl_fun.PreenchComboMunicipios(cbo_uf.Text, cbo_cidade, _cl_BD.conectionPadrao)
    End Sub

    Private Sub Frm_MCadastro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cbo_uf.Items.Add("AC")
        Me.cbo_uf.Items.Add("AL")
        Me.cbo_uf.Items.Add("AP")
        Me.cbo_uf.Items.Add("AM")
        Me.cbo_uf.Items.Add("BA")
        Me.cbo_uf.Items.Add("CE")
        Me.cbo_uf.Items.Add("DF")
        Me.cbo_uf.Items.Add("ES")
        Me.cbo_uf.Items.Add("EX")
        Me.cbo_uf.Items.Add("GO")
        Me.cbo_uf.Items.Add("MA")
        Me.cbo_uf.Items.Add("MT")
        Me.cbo_uf.Items.Add("MS")
        Me.cbo_uf.Items.Add("MG")
        Me.cbo_uf.Items.Add("PA")
        Me.cbo_uf.Items.Add("PB")
        Me.cbo_uf.Items.Add("PE")
        Me.cbo_uf.Items.Add("PI")
        Me.cbo_uf.Items.Add("RJ")
        Me.cbo_uf.Items.Add("RN")
        Me.cbo_uf.Items.Add("RS")
        Me.cbo_uf.Items.Add("RD")
        Me.cbo_uf.Items.Add("RR")
        Me.cbo_uf.Items.Add("SC")
        Me.cbo_uf.Items.Add("SP")
        Me.cbo_uf.Items.Add("SE")
        Me.cbo_uf.Items.Add("TO")
        Me.cbo_uf.Sorted = True

        Me.msk_UltCompra.Enabled = False
        Me.msk_valor.Enabled = False
        Me.txt_pedido.Enabled = False
        AlfaMaiuscula()
        Me.RdBCli.Checked = True
        Me.RdBFisica.Checked = True
        Me.txt_RazaoSocialNome.Focus()

        If Not ModuloUsuarioLogando._local.Equals("") Then
            cbo_loja.Items.Clear()
            cbo_loja.Refresh()
            cbo_loja.Items.Add(ModuloUsuarioLogando._local)
            cbo_loja.Refresh()
        End If

        txt_vendedor.Text = ModuloUsuarioLogando._usuarioLogin
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

        If Me.cbo_loja.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Selecione uma LOJA por favor !"
            lbl_mensagem_.Text = "Selecione uma LOJA por favor !"
            Return mNaoDeuErro

        End If


        If (Me.RdBCli.Checked = False) AndAlso (Me.RdBForn.Checked = False) _
        AndAlso (Me.RdBTransp.Checked = False) Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Selecione um tipo de Participante !"
            lbl_mensagem_.Text = "Selecione um tipo de Participante !"
            Return mNaoDeuErro

        End If


        If (Me.RdBFisica.Checked = False) AndAlso (Me.RdBJuridica.Checked = False) Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Selecione a característica do Participante !"
            lbl_mensagem_.Text = "Selecione a característica do Participante !"
            Return mNaoDeuErro

        End If


        If Trim(Me.txt_codigo.Text).Equals("") Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Código do participante não informado !"
            lbl_mensagem_.Text = "Código do participante não informado !"
            Return mNaoDeuErro

        End If


        If Trim(Me.txt_RazaoSocialNome.Text).Equals("") Then

            If RdBFisica.Checked = True Then

                mNaoDeuErro = False
                lbl_mensagem.Text = "Informe a Razao Social do Paricipante !"
                lbl_mensagem_.Text = "Informe a Razao Social do Paricipante !"
                Return mNaoDeuErro

            ElseIf RdBJuridica.Checked = True Then

                mNaoDeuErro = False
                lbl_mensagem.Text = "Informe o Nome do Paricipante !"
                lbl_mensagem_.Text = "Informe o Nome do Paricipante !"
                Return mNaoDeuErro

            End If
        End If


        If RdBFisica.Checked Then

            If Not IsDate(Me.msk_nascativ.Text) Then

                mNaoDeuErro = False
                lbl_mensagem.Text = "Informe a Data de Nasc/Ativ do Paricipante !"
                lbl_mensagem_.Text = "Informe a Data de Nasc/Ativ do Paricipante !"
                Return mNaoDeuErro

            End If
        End If
        
        If Trim(Me.txt_endereco.Text).Equals("") Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe o ENDEREÇO do Paricipante !"
            lbl_mensagem_.Text = "Informe o ENDEREÇO do Paricipante !"
            Return mNaoDeuErro

        End If

        If Me.cbo_uf.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe a UF do Paricipante !"
            lbl_mensagem_.Text = "Informe a UF do Paricipante !"
            Return mNaoDeuErro

        End If

        If Me.cbo_cidade.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe a CIDADE do Paricipante !"
            lbl_mensagem_.Text = "Informe a CIDADE do Paricipante !"
            Return mNaoDeuErro

        End If

        If Trim(Me.txt_bairro.Text).Equals("") Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe o BAIRRO do Paricipante !"
            lbl_mensagem_.Text = "Informe o BAIRRO do Paricipante !"
            Return mNaoDeuErro

        End If

        If Trim(Me.msk_cep.Text).Equals("") Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe o CEP do Paricipante !"
            lbl_mensagem_.Text = "Informe o CEP do Paricipante !"
            Return mNaoDeuErro

        End If

        If Trim(Me.msk_fone.Text).Equals("") AndAlso Trim(Me.msk_celular.Text).Equals("") Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe um TelefoneFixo ou Celular do Paricipante !"
            lbl_mensagem_.Text = "Informe um TelefoneFixo ou Celular do Paricipante !"
            Return mNaoDeuErro

        End If


        If Me.RdBFisica.Checked Then

            If Trim(Me.txt_ident.Text).Equals("") Then

                mNaoDeuErro = False
                lbl_mensagem.Text = "Informe a Identidade do Paricipante !"
                lbl_mensagem_.Text = "Informe a Identidade do Paricipante !"
                Return mNaoDeuErro

            End If

            If Trim(Me.msk_cpf.Text).Equals("") Then

                mNaoDeuErro = False
                lbl_mensagem.Text = "Informe o CPF do Paricipante !"
                lbl_mensagem_.Text = "Informe o CPF do Paricipante !"
                Return mNaoDeuErro

            End If
        End If


        If Me.RdBJuridica.Checked Then

            If Trim(Me.msk_cnpj.Text).Equals("") Then

                mNaoDeuErro = False
                lbl_mensagem.Text = "Informe o CNPJ do Paricipante !"
                lbl_mensagem_.Text = "Informe o CNPJ do Paricipante !"
                Return mNaoDeuErro

            End If

            If Trim(Me.txt_insc.Text).Equals("") Then

                mNaoDeuErro = False
                lbl_mensagem.Text = "Informe a INSCRIÇÂO do Paricipante !"
                lbl_mensagem_.Text = "Informe a INSCRIÇÂO do Paricipante !"
                Return mNaoDeuErro

            End If

            ' Pattern ou mascara de verificação do email
            Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\." _
            & "[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"

            If Trim(Me.txt_email.Text).Equals("") Then

                mNaoDeuErro = False
                lbl_mensagem.Text = "Informe o EMAIL do Paricipante !"
                lbl_mensagem_.Text = "Informe o EMAIL do Paricipante !"
                Return mNaoDeuErro

            ElseIf Not Regex.Match(Me.txt_email.Text, pattern).Success Then

                mNaoDeuErro = False
                lbl_mensagem.Text = "EMAIL Incorreto !"
                lbl_mensagem_.Text = "EMAIL Incorreto !"
                Return mNaoDeuErro

            End If
        End If


        Return mNaoDeuErro
    End Function

    Private Sub salvaParticipanteIcluindo(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)
        Dim tipo As String, carac As String, dtcad As String, cod As String, portad As String
        Dim fantas As String, civil As String, dtnativ As String, natur As String, ident As String
        Dim cpf As String, cgc As String, insc As String, pai As String, mae As String
        Dim ender As String, bairro As String, cid As String, uf As String, cep As String
        Dim fone As String, ltrab As String, endtr As String, fontr As String, cargo As String
        Dim salar As Double, esposo As String, crt As String, ltrabe As String, salae As Double
        Dim rota As Int32, vend As String, obs1 As String, obs2 As String, obs3 As String
        Dim ultcomp As String, valor As Double, limite As Double, pedido As String, cdvend As String
        Dim cdcid As String, bloq As String, tb As String, consumo As String, mun As String
        Dim coduf As String, ctactb As String, ctaanli As String, mes As Integer
        Dim fax As String = "", prep As String = "", sexo As String = ""
        Dim email As String = ""
        tipo = "" : carac = "" : dtcad = "" : cod = "" : portad = "" : fantas = "" : civil = ""
        dtnativ = "" : natur = "" : ident = "" : cpf = "" : cgc = "" : insc = "" : pai = ""
        mae = "" : ender = "" : bairro = "" : cid = "" : uf = "" : cep = "" : fone = "" : ltrab = ""
        ender = "" : fontr = "" : cargo = "" : salar = 0 : esposo = "" : crt = "" : ltrabe = ""
        endtr = "" : cargo = "" : rota = 0 : vend = "" : obs1 = "" : obs2 = "" : obs3 = ""
        salae = 0 : ultcomp = "" : valor = 0 : limite = 0 : pedido = "" : cdvend = "" : cdcid = ""
        bloq = "" : tb = "" : consumo = "" : mun = "" : coduf = "" : ctactb = "" : ctaanli = ""
        mes = 0

        'Preechendo objetos pro banco
        tipo = _mtipo
        If Me.RdBFisica.Checked Then
            carac = "F"
        Else
            carac = "J"
        End If
        dtcad = Trim(dtp_cadastro.Text)
        cod = Trim(Me.txt_codigo.Text)
        portad = Trim(txt_RazaoSocialNome.Text)
        fantas = Trim(txt_Fantasia.Text)
        dtnativ = Trim(msk_nascativ.Text)
        ender = Trim(txt_endereco.Text)
        uf = Trim(Me.cbo_uf.SelectedItem)
        cid = Trim(Me.cbo_cidade.SelectedItem)
        bairro = Trim(txt_bairro.Text)
        cep = Trim(msk_cep.Text)
        If IsNumeric(msk_celular.Text) Then fone = Trim(msk_celular.Text)
        If IsNumeric(msk_fone.Text) Then fone = Trim(msk_fone.Text)

        If Not Trim(txt_vendedor.Text).Equals("") Then

            If Trim(txt_vendedor.Text).Length < 6 Then
                vend = txt_vendedor.Text
            Else
                vend = Mid(txt_vendedor.Text, 1, 5)
            End If
        End If

        If IsNumeric(Trim(txt_rota.Text)) Then rota = Trim(txt_rota.Text)

        ident = Trim(txt_ident.Text)
        cpf = Trim(_cl_fun.RemoverCaracter(msk_cpf.Text))
        cgc = Trim(_cl_fun.RemoverCaracter(msk_cnpj.Text))
        insc = Trim(txt_insc.Text)
        sexo = cbo_sexo.SelectedItem
        email = txt_email.Text
        mun = txt_codmun.Text
        coduf = _cl_BD.trazCodEstado(conection, uf)
        coduf = Trim(coduf)

        'Chamando a fução de gravar as informações do fornecedor...
        _cl_BD.inclueParticipante(conection, transacao, tipo, carac, dtcad, cod, portad, fantas, civil, _
                                 dtnativ, natur, ident, cpf, cgc, insc, pai, mae, ender, bairro, cid, _
                                 uf, cep, fone, ltrab, endtr, fontr, cargo, salar, esposo, crt, ltrabe, _
                                 salae, rota, vend, obs1, obs2, obs3, ultcomp, valor, limite, pedido, _
                                 cdvend, cdcid, bloq, tb, consumo, mun, coduf, ctactb, ctaanli, mes)

        _cl_BD.updateCadregCodcli(conection, CInt(Mid(cod, 2, 5)))

    End Sub

    Private Sub btn_salvar_Click_Incluindo()
        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(ModuloConexaoBD.conectionPadrao)
        Try
            If conection.State = ConnectionState.Closed Then conection.Open()
            transacao = conection.BeginTransaction
            salvaParticipanteIcluindo(conection, transacao)
            transacao.Commit()

            If MessageBox.Show("Participante salvo com sucesso! Deseja continuar incluido?", "BDHEMOSIS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then
                tbc_participante.SelectTab(0)
                
                conection.Close()
            Else
                conection.Close()
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()
            Catch ex1 As Exception
            End Try
        Finally
            transacao = Nothing
            conection = Nothing
        End Try
    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        If RdBCli.Checked = True Then _mtipo = "C"
        If RdBForn.Checked = True Then _mtipo = "F"
        If RdBTransp.Checked = True Then _mtipo = "F"


        Dim conection As New NpgsqlConnection(ModuloConexaoBD.conectionPadrao)
        Try

            If conection.State = ConnectionState.Closed Then conection.Open()
            Me.txt_codigo.Text = _mtipo & String.Format("{0:D5}", _cl_BD.trazProxCodForn(conection))
            conection.Close()
            conection = Nothing

        Catch ex As Exception
        End Try
        conection = Nothing

        If verificaParticipante() Then

            btn_salvar_Click_Incluindo()

        End If

    End Sub

    Private Sub cbo_cidade_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cidade.Leave

        Dim conection As New NpgsqlConnection(ModuloConexaoBD.conectionPadrao)
        If conection.State = ConnectionState.Closed Then conection.Open()
        Me.txt_codmun.Text = _cl_BD.trazCodMun(conection, Me.cbo_uf.SelectedItem, Me.cbo_cidade.SelectedItem)
        conection.Close()
        conection = Nothing

    End Sub

    Private Sub msk_cpf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_cpf.Leave

        lbl_mensagem.Text = "" : lbl_mensagem_.Text = ""

        ' Pattern ou mascara de verificação do Cpf
        Dim pattern As String = "^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$"

        If Not Regex.Match(Me.msk_cpf.Text, pattern).Success Then

            lbl_mensagem.Text = "CPF Incorreto !"
            lbl_mensagem_.Text = "CPF Incorreto !"

        ElseIf Not _cl_BD.ValidaCPF(Me.msk_cpf.Text) Then

            lbl_mensagem.Text = "CPF Incorreto !"
            lbl_mensagem_.Text = "CPF Incorreto !"

        End If

    End Sub

    Private Sub msk_cnpj_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_cnpj.Leave

        lbl_mensagem.Text = "" : lbl_mensagem_.Text = ""

        ' Pattern ou mascara de verificação do Cpf
        Dim pattern As String = "^\d{3}.?\d{3}.?\d{3}/?\d{3}-?\d{2}$"

        If Not Regex.Match(Me.msk_cnpj.Text, pattern).Success Then

            lbl_mensagem.Text = "CNPJ Incorreto !"
            lbl_mensagem_.Text = "CNPJ Incorreto !"

        ElseIf Not _cl_BD.ValidaCNPJ(Me.msk_cnpj.Text) Then

            lbl_mensagem.Text = "CNPJ Incorreto !"
            lbl_mensagem_.Text = "CNPJ Incorreto !"

        End If

    End Sub

    Private Sub msk_cep_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_cep.Leave

        lbl_mensagem.Text = "" : lbl_mensagem_.Text = ""

        ' Pattern ou mascara de verificação do Cpf
        Dim pattern As String = "^\d{5}\-?\d{3}$"

        If Not Regex.Match(Me.msk_cep.Text, pattern).Success Then

            lbl_mensagem.Text = "CEP Incorreto !"
            lbl_mensagem_.Text = "CEP Incorreto !"

        End If

    End Sub
End Class