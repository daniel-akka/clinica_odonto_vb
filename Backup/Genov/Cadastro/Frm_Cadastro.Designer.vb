<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cadastro
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grp_Tipo = New System.Windows.Forms.GroupBox
        Me.RdBTransp = New System.Windows.Forms.RadioButton
        Me.RdBForn = New System.Windows.Forms.RadioButton
        Me.RdBCli = New System.Windows.Forms.RadioButton
        Me.grp_caracteristica = New System.Windows.Forms.GroupBox
        Me.RdBJuridica = New System.Windows.Forms.RadioButton
        Me.RdBFisica = New System.Windows.Forms.RadioButton
        Me.lbl_Codigo = New System.Windows.Forms.Label
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtp_cadastro = New System.Windows.Forms.DateTimePicker
        Me.lbl_RazaoSocial = New System.Windows.Forms.Label
        Me.txt_RazaoSocial = New System.Windows.Forms.TextBox
        Me.lbl_uf = New System.Windows.Forms.Label
        Me.cbo_uf = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_email = New System.Windows.Forms.TextBox
        Me.lbl_email = New System.Windows.Forms.Label
        Me.dtp_nascativ = New System.Windows.Forms.DateTimePicker
        Me.lbl_datanasc = New System.Windows.Forms.Label
        Me.txt_insc = New System.Windows.Forms.TextBox
        Me.lbl_Insc = New System.Windows.Forms.Label
        Me.msk_cnpj = New System.Windows.Forms.MaskedTextBox
        Me.msk_txtcpf = New System.Windows.Forms.MaskedTextBox
        Me.lbl_cnpj = New System.Windows.Forms.Label
        Me.lbl_cpf = New System.Windows.Forms.Label
        Me.lbl_rg = New System.Windows.Forms.Label
        Me.lbl_preposto = New System.Windows.Forms.Label
        Me.lbl_vendedor = New System.Windows.Forms.Label
        Me.msk_celular = New System.Windows.Forms.MaskedTextBox
        Me.msk_txtfax = New System.Windows.Forms.MaskedTextBox
        Me.msk_txtfone = New System.Windows.Forms.MaskedTextBox
        Me.txt_ident = New System.Windows.Forms.TextBox
        Me.lbl_celular = New System.Windows.Forms.Label
        Me.txt_preposto = New System.Windows.Forms.TextBox
        Me.lbl_fax = New System.Windows.Forms.Label
        Me.txt_vendedor = New System.Windows.Forms.TextBox
        Me.lbl_fone = New System.Windows.Forms.Label
        Me.msk_cep = New System.Windows.Forms.MaskedTextBox
        Me.lbl_cep = New System.Windows.Forms.Label
        Me.txt_bairro = New System.Windows.Forms.TextBox
        Me.lbl_bairro = New System.Windows.Forms.Label
        Me.lbl_Fantasia = New System.Windows.Forms.Label
        Me.txt_Fantasia = New System.Windows.Forms.TextBox
        Me.txt_cidade = New System.Windows.Forms.TextBox
        Me.lbl_cidade = New System.Windows.Forms.Label
        Me.txt_endereco = New System.Windows.Forms.TextBox
        Me.lbl_endereco = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_valor = New System.Windows.Forms.Label
        Me.lbl_pedido = New System.Windows.Forms.Label
        Me.txt_pedido = New System.Windows.Forms.TextBox
        Me.msk_UltCompra = New System.Windows.Forms.MaskedTextBox
        Me.msk_valor = New System.Windows.Forms.MaskedTextBox
        Me.msk_limite = New System.Windows.Forms.MaskedTextBox
        Me.lbl_limite = New System.Windows.Forms.Label
        Me.chk_consumo = New System.Windows.Forms.CheckBox
        Me.chk_bloqueio = New System.Windows.Forms.CheckBox
        Me.chk_etiqueta = New System.Windows.Forms.CheckBox
        Me.lbl_observacao = New System.Windows.Forms.Label
        Me.txt_obs1 = New System.Windows.Forms.TextBox
        Me.txt_obs2 = New System.Windows.Forms.TextBox
        Me.txt_obs3 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_pesquisa = New System.Windows.Forms.Button
        Me.btn_incluir = New System.Windows.Forms.Button
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.btn_sair = New System.Windows.Forms.Button
        Me.btn_gravar = New System.Windows.Forms.Button
        Me.grp_Tipo.SuspendLayout()
        Me.grp_caracteristica.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_Tipo
        '
        Me.grp_Tipo.Controls.Add(Me.RdBTransp)
        Me.grp_Tipo.Controls.Add(Me.RdBForn)
        Me.grp_Tipo.Controls.Add(Me.RdBCli)
        Me.grp_Tipo.Location = New System.Drawing.Point(16, 3)
        Me.grp_Tipo.Name = "grp_Tipo"
        Me.grp_Tipo.Size = New System.Drawing.Size(182, 36)
        Me.grp_Tipo.TabIndex = 0
        Me.grp_Tipo.TabStop = False
        Me.grp_Tipo.Text = "Tipo"
        '
        'RdBTransp
        '
        Me.RdBTransp.AutoSize = True
        Me.RdBTransp.Location = New System.Drawing.Point(110, 16)
        Me.RdBTransp.Name = "RdBTransp"
        Me.RdBTransp.Size = New System.Drawing.Size(58, 17)
        Me.RdBTransp.TabIndex = 2
        Me.RdBTransp.TabStop = True
        Me.RdBTransp.Text = "Transp"
        Me.RdBTransp.UseVisualStyleBackColor = True
        '
        'RdBForn
        '
        Me.RdBForn.AutoSize = True
        Me.RdBForn.Location = New System.Drawing.Point(53, 16)
        Me.RdBForn.Name = "RdBForn"
        Me.RdBForn.Size = New System.Drawing.Size(46, 17)
        Me.RdBForn.TabIndex = 1
        Me.RdBForn.TabStop = True
        Me.RdBForn.Text = "Forn"
        Me.RdBForn.UseVisualStyleBackColor = True
        '
        'RdBCli
        '
        Me.RdBCli.AutoSize = True
        Me.RdBCli.Location = New System.Drawing.Point(6, 16)
        Me.RdBCli.Name = "RdBCli"
        Me.RdBCli.Size = New System.Drawing.Size(36, 17)
        Me.RdBCli.TabIndex = 0
        Me.RdBCli.TabStop = True
        Me.RdBCli.Text = "Cli"
        Me.RdBCli.UseVisualStyleBackColor = True
        '
        'grp_caracteristica
        '
        Me.grp_caracteristica.Controls.Add(Me.RdBJuridica)
        Me.grp_caracteristica.Controls.Add(Me.RdBFisica)
        Me.grp_caracteristica.Location = New System.Drawing.Point(232, 3)
        Me.grp_caracteristica.Name = "grp_caracteristica"
        Me.grp_caracteristica.Size = New System.Drawing.Size(161, 36)
        Me.grp_caracteristica.TabIndex = 1
        Me.grp_caracteristica.TabStop = False
        Me.grp_caracteristica.Text = "Caracterítica"
        '
        'RdBJuridica
        '
        Me.RdBJuridica.AutoSize = True
        Me.RdBJuridica.Location = New System.Drawing.Point(83, 14)
        Me.RdBJuridica.Name = "RdBJuridica"
        Me.RdBJuridica.Size = New System.Drawing.Size(63, 17)
        Me.RdBJuridica.TabIndex = 1
        Me.RdBJuridica.TabStop = True
        Me.RdBJuridica.Text = "Jurídica"
        Me.RdBJuridica.UseVisualStyleBackColor = True
        '
        'RdBFisica
        '
        Me.RdBFisica.AutoSize = True
        Me.RdBFisica.Location = New System.Drawing.Point(15, 14)
        Me.RdBFisica.Name = "RdBFisica"
        Me.RdBFisica.Size = New System.Drawing.Size(54, 17)
        Me.RdBFisica.TabIndex = 0
        Me.RdBFisica.TabStop = True
        Me.RdBFisica.Text = "Fisíca"
        Me.RdBFisica.UseVisualStyleBackColor = True
        '
        'lbl_Codigo
        '
        Me.lbl_Codigo.AutoSize = True
        Me.lbl_Codigo.Location = New System.Drawing.Point(5, 19)
        Me.lbl_Codigo.Name = "lbl_Codigo"
        Me.lbl_Codigo.Size = New System.Drawing.Size(43, 13)
        Me.lbl_Codigo.TabIndex = 2
        Me.lbl_Codigo.Text = "Código:"
        '
        'txt_codigo
        '
        Me.txt_codigo.Enabled = False
        Me.txt_codigo.Location = New System.Drawing.Point(60, 16)
        Me.txt_codigo.MaxLength = 6
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(65, 20)
        Me.txt_codigo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(461, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Data Cadastro:"
        '
        'dtp_cadastro
        '
        Me.dtp_cadastro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_cadastro.Location = New System.Drawing.Point(550, 16)
        Me.dtp_cadastro.Name = "dtp_cadastro"
        Me.dtp_cadastro.RightToLeftLayout = True
        Me.dtp_cadastro.Size = New System.Drawing.Size(85, 20)
        Me.dtp_cadastro.TabIndex = 5
        '
        'lbl_RazaoSocial
        '
        Me.lbl_RazaoSocial.AutoSize = True
        Me.lbl_RazaoSocial.Location = New System.Drawing.Point(131, 19)
        Me.lbl_RazaoSocial.Name = "lbl_RazaoSocial"
        Me.lbl_RazaoSocial.Size = New System.Drawing.Size(70, 13)
        Me.lbl_RazaoSocial.TabIndex = 6
        Me.lbl_RazaoSocial.Text = "RazãoSocial:"
        '
        'txt_RazaoSocial
        '
        Me.txt_RazaoSocial.Location = New System.Drawing.Point(205, 16)
        Me.txt_RazaoSocial.MaxLength = 45
        Me.txt_RazaoSocial.Name = "txt_RazaoSocial"
        Me.txt_RazaoSocial.Size = New System.Drawing.Size(321, 20)
        Me.txt_RazaoSocial.TabIndex = 7
        '
        'lbl_uf
        '
        Me.lbl_uf.AutoSize = True
        Me.lbl_uf.Location = New System.Drawing.Point(607, 76)
        Me.lbl_uf.Name = "lbl_uf"
        Me.lbl_uf.Size = New System.Drawing.Size(24, 13)
        Me.lbl_uf.TabIndex = 8
        Me.lbl_uf.Text = "UF:"
        '
        'cbo_uf
        '
        Me.cbo_uf.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbo_uf.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_uf.FormattingEnabled = True
        Me.cbo_uf.Location = New System.Drawing.Point(632, 72)
        Me.cbo_uf.Name = "cbo_uf"
        Me.cbo_uf.Size = New System.Drawing.Size(43, 21)
        Me.cbo_uf.TabIndex = 9
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_email)
        Me.GroupBox3.Controls.Add(Me.lbl_email)
        Me.GroupBox3.Controls.Add(Me.dtp_nascativ)
        Me.GroupBox3.Controls.Add(Me.lbl_datanasc)
        Me.GroupBox3.Controls.Add(Me.txt_insc)
        Me.GroupBox3.Controls.Add(Me.lbl_Insc)
        Me.GroupBox3.Controls.Add(Me.msk_cnpj)
        Me.GroupBox3.Controls.Add(Me.msk_txtcpf)
        Me.GroupBox3.Controls.Add(Me.lbl_cnpj)
        Me.GroupBox3.Controls.Add(Me.lbl_cpf)
        Me.GroupBox3.Controls.Add(Me.lbl_rg)
        Me.GroupBox3.Controls.Add(Me.lbl_preposto)
        Me.GroupBox3.Controls.Add(Me.lbl_vendedor)
        Me.GroupBox3.Controls.Add(Me.msk_celular)
        Me.GroupBox3.Controls.Add(Me.msk_txtfax)
        Me.GroupBox3.Controls.Add(Me.msk_txtfone)
        Me.GroupBox3.Controls.Add(Me.txt_ident)
        Me.GroupBox3.Controls.Add(Me.lbl_celular)
        Me.GroupBox3.Controls.Add(Me.txt_preposto)
        Me.GroupBox3.Controls.Add(Me.lbl_fax)
        Me.GroupBox3.Controls.Add(Me.txt_vendedor)
        Me.GroupBox3.Controls.Add(Me.lbl_fone)
        Me.GroupBox3.Controls.Add(Me.msk_cep)
        Me.GroupBox3.Controls.Add(Me.lbl_cep)
        Me.GroupBox3.Controls.Add(Me.txt_bairro)
        Me.GroupBox3.Controls.Add(Me.lbl_bairro)
        Me.GroupBox3.Controls.Add(Me.lbl_Fantasia)
        Me.GroupBox3.Controls.Add(Me.txt_Fantasia)
        Me.GroupBox3.Controls.Add(Me.txt_cidade)
        Me.GroupBox3.Controls.Add(Me.lbl_cidade)
        Me.GroupBox3.Controls.Add(Me.txt_endereco)
        Me.GroupBox3.Controls.Add(Me.lbl_endereco)
        Me.GroupBox3.Controls.Add(Me.lbl_Codigo)
        Me.GroupBox3.Controls.Add(Me.cbo_uf)
        Me.GroupBox3.Controls.Add(Me.txt_codigo)
        Me.GroupBox3.Controls.Add(Me.lbl_uf)
        Me.GroupBox3.Controls.Add(Me.lbl_RazaoSocial)
        Me.GroupBox3.Controls.Add(Me.txt_RazaoSocial)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 43)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(700, 196)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        '
        'txt_email
        '
        Me.txt_email.Location = New System.Drawing.Point(430, 165)
        Me.txt_email.MaxLength = 50
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(236, 20)
        Me.txt_email.TabIndex = 41
        '
        'lbl_email
        '
        Me.lbl_email.AutoSize = True
        Me.lbl_email.Location = New System.Drawing.Point(388, 168)
        Me.lbl_email.Name = "lbl_email"
        Me.lbl_email.Size = New System.Drawing.Size(39, 13)
        Me.lbl_email.TabIndex = 40
        Me.lbl_email.Text = "E-Mail:"
        '
        'dtp_nascativ
        '
        Me.dtp_nascativ.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_nascativ.Location = New System.Drawing.Point(539, 43)
        Me.dtp_nascativ.Name = "dtp_nascativ"
        Me.dtp_nascativ.Size = New System.Drawing.Size(85, 20)
        Me.dtp_nascativ.TabIndex = 39
        '
        'lbl_datanasc
        '
        Me.lbl_datanasc.AutoSize = True
        Me.lbl_datanasc.Location = New System.Drawing.Point(465, 47)
        Me.lbl_datanasc.Name = "lbl_datanasc"
        Me.lbl_datanasc.Size = New System.Drawing.Size(72, 13)
        Me.lbl_datanasc.TabIndex = 38
        Me.lbl_datanasc.Text = "DtNasc/Ativ.:"
        '
        'txt_insc
        '
        Me.txt_insc.Location = New System.Drawing.Point(277, 165)
        Me.txt_insc.MaxLength = 18
        Me.txt_insc.Name = "txt_insc"
        Me.txt_insc.Size = New System.Drawing.Size(100, 20)
        Me.txt_insc.TabIndex = 37
        '
        'lbl_Insc
        '
        Me.lbl_Insc.AutoSize = True
        Me.lbl_Insc.Location = New System.Drawing.Point(218, 169)
        Me.lbl_Insc.Name = "lbl_Insc"
        Me.lbl_Insc.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Insc.TabIndex = 36
        Me.lbl_Insc.Text = "Inscrição:"
        '
        'msk_cnpj
        '
        Me.msk_cnpj.Location = New System.Drawing.Point(60, 163)
        Me.msk_cnpj.Mask = "99.999.999/9999-99"
        Me.msk_cnpj.Name = "msk_cnpj"
        Me.msk_cnpj.Size = New System.Drawing.Size(141, 20)
        Me.msk_cnpj.TabIndex = 35
        '
        'msk_txtcpf
        '
        Me.msk_txtcpf.Location = New System.Drawing.Point(549, 136)
        Me.msk_txtcpf.Mask = "999.999.999-99"
        Me.msk_txtcpf.Name = "msk_txtcpf"
        Me.msk_txtcpf.Size = New System.Drawing.Size(117, 20)
        Me.msk_txtcpf.TabIndex = 34
        Me.msk_txtcpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lbl_cnpj
        '
        Me.lbl_cnpj.AutoSize = True
        Me.lbl_cnpj.Location = New System.Drawing.Point(9, 165)
        Me.lbl_cnpj.Name = "lbl_cnpj"
        Me.lbl_cnpj.Size = New System.Drawing.Size(37, 13)
        Me.lbl_cnpj.TabIndex = 33
        Me.lbl_cnpj.Text = "CNPJ:"
        '
        'lbl_cpf
        '
        Me.lbl_cpf.AutoSize = True
        Me.lbl_cpf.Location = New System.Drawing.Point(519, 140)
        Me.lbl_cpf.Name = "lbl_cpf"
        Me.lbl_cpf.Size = New System.Drawing.Size(30, 13)
        Me.lbl_cpf.TabIndex = 32
        Me.lbl_cpf.Text = "CPF:"
        '
        'lbl_rg
        '
        Me.lbl_rg.AutoSize = True
        Me.lbl_rg.Location = New System.Drawing.Point(365, 140)
        Me.lbl_rg.Name = "lbl_rg"
        Me.lbl_rg.Size = New System.Drawing.Size(45, 13)
        Me.lbl_rg.TabIndex = 31
        Me.lbl_rg.Text = "Identid.:"
        '
        'lbl_preposto
        '
        Me.lbl_preposto.AutoSize = True
        Me.lbl_preposto.Location = New System.Drawing.Point(274, 138)
        Me.lbl_preposto.Name = "lbl_preposto"
        Me.lbl_preposto.Size = New System.Drawing.Size(52, 13)
        Me.lbl_preposto.TabIndex = 30
        Me.lbl_preposto.Text = "Preposto:"
        '
        'lbl_vendedor
        '
        Me.lbl_vendedor.AutoSize = True
        Me.lbl_vendedor.Location = New System.Drawing.Point(164, 138)
        Me.lbl_vendedor.Name = "lbl_vendedor"
        Me.lbl_vendedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_vendedor.TabIndex = 29
        Me.lbl_vendedor.Text = "Vendedor:"
        '
        'msk_celular
        '
        Me.msk_celular.Location = New System.Drawing.Point(60, 134)
        Me.msk_celular.Mask = "(99)9999-9999"
        Me.msk_celular.Name = "msk_celular"
        Me.msk_celular.Size = New System.Drawing.Size(100, 20)
        Me.msk_celular.TabIndex = 28
        Me.msk_celular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'msk_txtfax
        '
        Me.msk_txtfax.Location = New System.Drawing.Point(549, 104)
        Me.msk_txtfax.Mask = "(99)9999-9999"
        Me.msk_txtfax.Name = "msk_txtfax"
        Me.msk_txtfax.Size = New System.Drawing.Size(100, 20)
        Me.msk_txtfax.TabIndex = 27
        Me.msk_txtfax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'msk_txtfone
        '
        Me.msk_txtfone.Location = New System.Drawing.Point(411, 104)
        Me.msk_txtfone.Mask = "(99)9999-9999"
        Me.msk_txtfone.Name = "msk_txtfone"
        Me.msk_txtfone.Size = New System.Drawing.Size(100, 20)
        Me.msk_txtfone.TabIndex = 26
        Me.msk_txtfone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txt_ident
        '
        Me.txt_ident.Location = New System.Drawing.Point(411, 137)
        Me.txt_ident.MaxLength = 16
        Me.txt_ident.Name = "txt_ident"
        Me.txt_ident.Size = New System.Drawing.Size(100, 20)
        Me.txt_ident.TabIndex = 25
        '
        'lbl_celular
        '
        Me.lbl_celular.AutoSize = True
        Me.lbl_celular.Location = New System.Drawing.Point(9, 137)
        Me.lbl_celular.Name = "lbl_celular"
        Me.lbl_celular.Size = New System.Drawing.Size(42, 13)
        Me.lbl_celular.TabIndex = 24
        Me.lbl_celular.Text = "Celular:"
        '
        'txt_preposto
        '
        Me.txt_preposto.Location = New System.Drawing.Point(327, 135)
        Me.txt_preposto.MaxLength = 3
        Me.txt_preposto.Name = "txt_preposto"
        Me.txt_preposto.Size = New System.Drawing.Size(34, 20)
        Me.txt_preposto.TabIndex = 23
        '
        'lbl_fax
        '
        Me.lbl_fax.AutoSize = True
        Me.lbl_fax.Location = New System.Drawing.Point(523, 109)
        Me.lbl_fax.Name = "lbl_fax"
        Me.lbl_fax.Size = New System.Drawing.Size(27, 13)
        Me.lbl_fax.TabIndex = 22
        Me.lbl_fax.Text = "Fax:"
        '
        'txt_vendedor
        '
        Me.txt_vendedor.Location = New System.Drawing.Point(222, 135)
        Me.txt_vendedor.MaxLength = 5
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(46, 20)
        Me.txt_vendedor.TabIndex = 21
        '
        'lbl_fone
        '
        Me.lbl_fone.AutoSize = True
        Me.lbl_fone.Location = New System.Drawing.Point(376, 109)
        Me.lbl_fone.Name = "lbl_fone"
        Me.lbl_fone.Size = New System.Drawing.Size(34, 13)
        Me.lbl_fone.TabIndex = 20
        Me.lbl_fone.Text = "Fone:"
        '
        'msk_cep
        '
        Me.msk_cep.Location = New System.Drawing.Point(264, 105)
        Me.msk_cep.Mask = "99.999-999"
        Me.msk_cep.Name = "msk_cep"
        Me.msk_cep.Size = New System.Drawing.Size(100, 20)
        Me.msk_cep.TabIndex = 19
        Me.msk_cep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lbl_cep
        '
        Me.lbl_cep.AutoSize = True
        Me.lbl_cep.Location = New System.Drawing.Point(231, 107)
        Me.lbl_cep.Name = "lbl_cep"
        Me.lbl_cep.Size = New System.Drawing.Size(29, 13)
        Me.lbl_cep.TabIndex = 18
        Me.lbl_cep.Text = "Cep:"
        '
        'txt_bairro
        '
        Me.txt_bairro.Location = New System.Drawing.Point(60, 104)
        Me.txt_bairro.MaxLength = 25
        Me.txt_bairro.Name = "txt_bairro"
        Me.txt_bairro.Size = New System.Drawing.Size(163, 20)
        Me.txt_bairro.TabIndex = 17
        '
        'lbl_bairro
        '
        Me.lbl_bairro.AutoSize = True
        Me.lbl_bairro.Location = New System.Drawing.Point(8, 107)
        Me.lbl_bairro.Name = "lbl_bairro"
        Me.lbl_bairro.Size = New System.Drawing.Size(37, 13)
        Me.lbl_bairro.TabIndex = 16
        Me.lbl_bairro.Text = "Bairro:"
        '
        'lbl_Fantasia
        '
        Me.lbl_Fantasia.AutoSize = True
        Me.lbl_Fantasia.Location = New System.Drawing.Point(5, 47)
        Me.lbl_Fantasia.Name = "lbl_Fantasia"
        Me.lbl_Fantasia.Size = New System.Drawing.Size(50, 13)
        Me.lbl_Fantasia.TabIndex = 15
        Me.lbl_Fantasia.Text = "Fantasia:"
        '
        'txt_Fantasia
        '
        Me.txt_Fantasia.Location = New System.Drawing.Point(60, 46)
        Me.txt_Fantasia.MaxLength = 45
        Me.txt_Fantasia.Name = "txt_Fantasia"
        Me.txt_Fantasia.Size = New System.Drawing.Size(388, 20)
        Me.txt_Fantasia.TabIndex = 14
        '
        'txt_cidade
        '
        Me.txt_cidade.Location = New System.Drawing.Point(368, 73)
        Me.txt_cidade.MaxLength = 30
        Me.txt_cidade.Name = "txt_cidade"
        Me.txt_cidade.Size = New System.Drawing.Size(233, 20)
        Me.txt_cidade.TabIndex = 13
        '
        'lbl_cidade
        '
        Me.lbl_cidade.AutoSize = True
        Me.lbl_cidade.Location = New System.Drawing.Point(324, 77)
        Me.lbl_cidade.Name = "lbl_cidade"
        Me.lbl_cidade.Size = New System.Drawing.Size(43, 13)
        Me.lbl_cidade.TabIndex = 12
        Me.lbl_cidade.Text = "Cidade:"
        '
        'txt_endereco
        '
        Me.txt_endereco.Location = New System.Drawing.Point(60, 74)
        Me.txt_endereco.MaxLength = 35
        Me.txt_endereco.Name = "txt_endereco"
        Me.txt_endereco.Size = New System.Drawing.Size(255, 20)
        Me.txt_endereco.TabIndex = 11
        '
        'lbl_endereco
        '
        Me.lbl_endereco.AutoSize = True
        Me.lbl_endereco.Location = New System.Drawing.Point(5, 77)
        Me.lbl_endereco.Name = "lbl_endereco"
        Me.lbl_endereco.Size = New System.Drawing.Size(56, 13)
        Me.lbl_endereco.TabIndex = 10
        Me.lbl_endereco.Text = "Endereco:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Ult.Compra:"
        '
        'lbl_valor
        '
        Me.lbl_valor.AutoSize = True
        Me.lbl_valor.Location = New System.Drawing.Point(229, 21)
        Me.lbl_valor.Name = "lbl_valor"
        Me.lbl_valor.Size = New System.Drawing.Size(34, 13)
        Me.lbl_valor.TabIndex = 13
        Me.lbl_valor.Text = "Valor:"
        '
        'lbl_pedido
        '
        Me.lbl_pedido.AutoSize = True
        Me.lbl_pedido.Location = New System.Drawing.Point(388, 21)
        Me.lbl_pedido.Name = "lbl_pedido"
        Me.lbl_pedido.Size = New System.Drawing.Size(43, 13)
        Me.lbl_pedido.TabIndex = 14
        Me.lbl_pedido.Text = "Pedido:"
        '
        'txt_pedido
        '
        Me.txt_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pedido.Location = New System.Drawing.Point(432, 16)
        Me.txt_pedido.MaxLength = 8
        Me.txt_pedido.Name = "txt_pedido"
        Me.txt_pedido.Size = New System.Drawing.Size(100, 21)
        Me.txt_pedido.TabIndex = 15
        '
        'msk_UltCompra
        '
        Me.msk_UltCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_UltCompra.Location = New System.Drawing.Point(72, 17)
        Me.msk_UltCompra.Mask = "99/99/9999"
        Me.msk_UltCompra.Name = "msk_UltCompra"
        Me.msk_UltCompra.Size = New System.Drawing.Size(114, 21)
        Me.msk_UltCompra.TabIndex = 16
        Me.msk_UltCompra.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'msk_valor
        '
        Me.msk_valor.Location = New System.Drawing.Point(264, 17)
        Me.msk_valor.Mask = "9,999,999.99"
        Me.msk_valor.Name = "msk_valor"
        Me.msk_valor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.msk_valor.Size = New System.Drawing.Size(100, 20)
        Me.msk_valor.TabIndex = 17
        Me.msk_valor.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'msk_limite
        '
        Me.msk_limite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_limite.Location = New System.Drawing.Point(72, 50)
        Me.msk_limite.Name = "msk_limite"
        Me.msk_limite.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.msk_limite.Size = New System.Drawing.Size(114, 21)
        Me.msk_limite.TabIndex = 18
        Me.msk_limite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.msk_limite.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lbl_limite
        '
        Me.lbl_limite.AutoSize = True
        Me.lbl_limite.Location = New System.Drawing.Point(8, 50)
        Me.lbl_limite.Name = "lbl_limite"
        Me.lbl_limite.Size = New System.Drawing.Size(37, 13)
        Me.lbl_limite.TabIndex = 19
        Me.lbl_limite.Text = "Limite:"
        '
        'chk_consumo
        '
        Me.chk_consumo.AutoSize = True
        Me.chk_consumo.Location = New System.Drawing.Point(314, 52)
        Me.chk_consumo.Name = "chk_consumo"
        Me.chk_consumo.Size = New System.Drawing.Size(70, 17)
        Me.chk_consumo.TabIndex = 20
        Me.chk_consumo.Text = "Consumo"
        Me.chk_consumo.UseVisualStyleBackColor = True
        '
        'chk_bloqueio
        '
        Me.chk_bloqueio.AutoSize = True
        Me.chk_bloqueio.Location = New System.Drawing.Point(413, 53)
        Me.chk_bloqueio.Name = "chk_bloqueio"
        Me.chk_bloqueio.Size = New System.Drawing.Size(67, 17)
        Me.chk_bloqueio.TabIndex = 21
        Me.chk_bloqueio.Text = "Bloqueio"
        Me.chk_bloqueio.UseVisualStyleBackColor = True
        '
        'chk_etiqueta
        '
        Me.chk_etiqueta.AutoSize = True
        Me.chk_etiqueta.Location = New System.Drawing.Point(506, 52)
        Me.chk_etiqueta.Name = "chk_etiqueta"
        Me.chk_etiqueta.Size = New System.Drawing.Size(65, 17)
        Me.chk_etiqueta.TabIndex = 22
        Me.chk_etiqueta.Text = "Etiqueta"
        Me.chk_etiqueta.UseVisualStyleBackColor = True
        '
        'lbl_observacao
        '
        Me.lbl_observacao.AutoSize = True
        Me.lbl_observacao.Location = New System.Drawing.Point(6, 88)
        Me.lbl_observacao.Name = "lbl_observacao"
        Me.lbl_observacao.Size = New System.Drawing.Size(68, 13)
        Me.lbl_observacao.TabIndex = 23
        Me.lbl_observacao.Text = "Observacao:"
        '
        'txt_obs1
        '
        Me.txt_obs1.Location = New System.Drawing.Point(72, 85)
        Me.txt_obs1.MaxLength = 80
        Me.txt_obs1.Name = "txt_obs1"
        Me.txt_obs1.Size = New System.Drawing.Size(499, 20)
        Me.txt_obs1.TabIndex = 24
        '
        'txt_obs2
        '
        Me.txt_obs2.Location = New System.Drawing.Point(72, 111)
        Me.txt_obs2.MaxLength = 80
        Me.txt_obs2.Name = "txt_obs2"
        Me.txt_obs2.Size = New System.Drawing.Size(499, 20)
        Me.txt_obs2.TabIndex = 25
        '
        'txt_obs3
        '
        Me.txt_obs3.Location = New System.Drawing.Point(72, 139)
        Me.txt_obs3.MaxLength = 80
        Me.txt_obs3.Name = "txt_obs3"
        Me.txt_obs3.Size = New System.Drawing.Size(499, 20)
        Me.txt_obs3.TabIndex = 26
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_pesquisa)
        Me.GroupBox1.Controls.Add(Me.btn_incluir)
        Me.GroupBox1.Controls.Add(Me.btn_excluir)
        Me.GroupBox1.Controls.Add(Me.btn_sair)
        Me.GroupBox1.Controls.Add(Me.btn_gravar)
        Me.GroupBox1.Controls.Add(Me.txt_obs3)
        Me.GroupBox1.Controls.Add(Me.msk_UltCompra)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_obs2)
        Me.GroupBox1.Controls.Add(Me.lbl_valor)
        Me.GroupBox1.Controls.Add(Me.lbl_pedido)
        Me.GroupBox1.Controls.Add(Me.txt_obs1)
        Me.GroupBox1.Controls.Add(Me.txt_pedido)
        Me.GroupBox1.Controls.Add(Me.lbl_observacao)
        Me.GroupBox1.Controls.Add(Me.msk_valor)
        Me.GroupBox1.Controls.Add(Me.msk_limite)
        Me.GroupBox1.Controls.Add(Me.chk_etiqueta)
        Me.GroupBox1.Controls.Add(Me.lbl_limite)
        Me.GroupBox1.Controls.Add(Me.chk_consumo)
        Me.GroupBox1.Controls.Add(Me.chk_bloqueio)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 242)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(702, 185)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'btn_pesquisa
        '
        Me.btn_pesquisa.Location = New System.Drawing.Point(603, 112)
        Me.btn_pesquisa.Name = "btn_pesquisa"
        Me.btn_pesquisa.Size = New System.Drawing.Size(83, 23)
        Me.btn_pesquisa.TabIndex = 31
        Me.btn_pesquisa.Text = "&Pesquisa"
        Me.btn_pesquisa.UseVisualStyleBackColor = True
        '
        'btn_incluir
        '
        Me.btn_incluir.Location = New System.Drawing.Point(604, 30)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(82, 23)
        Me.btn_incluir.TabIndex = 30
        Me.btn_incluir.Text = "&Incluir"
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'btn_excluir
        '
        Me.btn_excluir.Location = New System.Drawing.Point(604, 88)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(82, 23)
        Me.btn_excluir.TabIndex = 29
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_sair
        '
        Me.btn_sair.Location = New System.Drawing.Point(604, 139)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(82, 23)
        Me.btn_sair.TabIndex = 28
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'btn_gravar
        '
        Me.btn_gravar.Location = New System.Drawing.Point(604, 59)
        Me.btn_gravar.Name = "btn_gravar"
        Me.btn_gravar.Size = New System.Drawing.Size(82, 23)
        Me.btn_gravar.TabIndex = 27
        Me.btn_gravar.Text = "&Gravar"
        Me.btn_gravar.UseVisualStyleBackColor = True
        '
        'Frm_Cadastro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 439)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dtp_cadastro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grp_caracteristica)
        Me.Controls.Add(Me.grp_Tipo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_Cadastro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Clientes/Fornecedores e Transportadores"
        Me.grp_Tipo.ResumeLayout(False)
        Me.grp_Tipo.PerformLayout()
        Me.grp_caracteristica.ResumeLayout(False)
        Me.grp_caracteristica.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_Codigo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_RazaoSocial As System.Windows.Forms.Label
    Friend WithEvents lbl_uf As System.Windows.Forms.Label
    Friend WithEvents lbl_cidade As System.Windows.Forms.Label
    Friend WithEvents lbl_endereco As System.Windows.Forms.Label
    Friend WithEvents lbl_Fantasia As System.Windows.Forms.Label
    Friend WithEvents lbl_cep As System.Windows.Forms.Label
    Friend WithEvents lbl_bairro As System.Windows.Forms.Label
    Friend WithEvents lbl_celular As System.Windows.Forms.Label
    Friend WithEvents lbl_fax As System.Windows.Forms.Label
    Friend WithEvents lbl_fone As System.Windows.Forms.Label
    Friend WithEvents lbl_vendedor As System.Windows.Forms.Label
    Friend WithEvents lbl_preposto As System.Windows.Forms.Label
    Friend WithEvents lbl_rg As System.Windows.Forms.Label
    Friend WithEvents lbl_cnpj As System.Windows.Forms.Label
    Friend WithEvents lbl_cpf As System.Windows.Forms.Label
    Friend WithEvents lbl_Insc As System.Windows.Forms.Label
    Friend WithEvents lbl_datanasc As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_valor As System.Windows.Forms.Label
    Friend WithEvents lbl_pedido As System.Windows.Forms.Label
    Friend WithEvents lbl_limite As System.Windows.Forms.Label
    Friend WithEvents lbl_observacao As System.Windows.Forms.Label
    Friend WithEvents lbl_email As System.Windows.Forms.Label
    Public WithEvents RdBForn As System.Windows.Forms.RadioButton
    Public WithEvents RdBCli As System.Windows.Forms.RadioButton
    Public WithEvents RdBTransp As System.Windows.Forms.RadioButton
    Public WithEvents RdBJuridica As System.Windows.Forms.RadioButton
    Public WithEvents RdBFisica As System.Windows.Forms.RadioButton
    Public WithEvents txt_codigo As System.Windows.Forms.TextBox
    Public WithEvents dtp_cadastro As System.Windows.Forms.DateTimePicker
    Public WithEvents txt_RazaoSocial As System.Windows.Forms.TextBox
    Public WithEvents cbo_uf As System.Windows.Forms.ComboBox
    Public WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents txt_cidade As System.Windows.Forms.TextBox
    Public WithEvents txt_endereco As System.Windows.Forms.TextBox
    Public WithEvents txt_Fantasia As System.Windows.Forms.TextBox
    Public WithEvents msk_cep As System.Windows.Forms.MaskedTextBox
    Public WithEvents txt_bairro As System.Windows.Forms.TextBox
    Public WithEvents txt_ident As System.Windows.Forms.TextBox
    Public WithEvents txt_preposto As System.Windows.Forms.TextBox
    Public WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Public WithEvents msk_txtfax As System.Windows.Forms.MaskedTextBox
    Public WithEvents msk_txtfone As System.Windows.Forms.MaskedTextBox
    Public WithEvents msk_celular As System.Windows.Forms.MaskedTextBox
    Public WithEvents msk_cnpj As System.Windows.Forms.MaskedTextBox
    Public WithEvents msk_txtcpf As System.Windows.Forms.MaskedTextBox
    Public WithEvents txt_insc As System.Windows.Forms.TextBox
    Public WithEvents dtp_nascativ As System.Windows.Forms.DateTimePicker
    Public WithEvents txt_pedido As System.Windows.Forms.TextBox
    Public WithEvents msk_UltCompra As System.Windows.Forms.MaskedTextBox
    Public WithEvents msk_valor As System.Windows.Forms.MaskedTextBox
    Public WithEvents txt_email As System.Windows.Forms.TextBox
    Public WithEvents grp_Tipo As System.Windows.Forms.GroupBox
    Public WithEvents grp_caracteristica As System.Windows.Forms.GroupBox
    Public WithEvents msk_limite As System.Windows.Forms.MaskedTextBox
    Public WithEvents chk_consumo As System.Windows.Forms.CheckBox
    Public WithEvents chk_bloqueio As System.Windows.Forms.CheckBox
    Public WithEvents chk_etiqueta As System.Windows.Forms.CheckBox
    Public WithEvents txt_obs1 As System.Windows.Forms.TextBox
    Public WithEvents txt_obs2 As System.Windows.Forms.TextBox
    Public WithEvents txt_obs3 As System.Windows.Forms.TextBox
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents btn_gravar As System.Windows.Forms.Button
    Public WithEvents btn_sair As System.Windows.Forms.Button
    Public WithEvents btn_incluir As System.Windows.Forms.Button
    Public WithEvents btn_excluir As System.Windows.Forms.Button
    Public WithEvents btn_pesquisa As System.Windows.Forms.Button
End Class
