<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pedido
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
        Me.grp_condicoes = New System.Windows.Forms.GroupBox
        Me.txt_cond4 = New System.Windows.Forms.TextBox
        Me.txt_cond3 = New System.Windows.Forms.TextBox
        Me.txt_cond2 = New System.Windows.Forms.TextBox
        Me.txt_cond1 = New System.Windows.Forms.TextBox
        Me.grp_peso = New System.Windows.Forms.GroupBox
        Me.txt_peso = New System.Windows.Forms.TextBox
        Me.grp_total = New System.Windows.Forms.GroupBox
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.dtg_produtos = New System.Windows.Forms.DataGridView
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.btn_sair = New System.Windows.Forms.Button
        Me.grp_descontos = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.grp_pedido = New System.Windows.Forms.GroupBox
        Me.txt_codprod = New System.Windows.Forms.TextBox
        Me.txt_codpart = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.txt_pesquisa = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_desconto = New System.Windows.Forms.Label
        Me.txt_desconto = New System.Windows.Forms.TextBox
        Me.txt_senha = New System.Windows.Forms.TextBox
        Me.lbl_senha = New System.Windows.Forms.Label
        Me.txt_obs = New System.Windows.Forms.TextBox
        Me.lbl_obs = New System.Windows.Forms.Label
        Me.txt_plano = New System.Windows.Forms.TextBox
        Me.lbl_plano = New System.Windows.Forms.Label
        Me.cbo_vendedor = New System.Windows.Forms.ComboBox
        Me.cbo_forpgto = New System.Windows.Forms.ComboBox
        Me.lbl_formpagto = New System.Windows.Forms.Label
        Me.txt_consumo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbl_vendedor = New System.Windows.Forms.Label
        Me.txt_operador = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_rota = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_supervisor = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_portador = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.txt_pedido = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_pedido = New System.Windows.Forms.Label
        Me.btn_produtos = New System.Windows.Forms.Button
        Me.grp_registra = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.grp_mensagem = New System.Windows.Forms.GroupBox
        Me.grp_opcao = New System.Windows.Forms.GroupBox
        Me.grp_condicoes.SuspendLayout()
        Me.grp_peso.SuspendLayout()
        Me.grp_total.SuspendLayout()
        CType(Me.dtg_produtos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_descontos.SuspendLayout()
        Me.grp_pedido.SuspendLayout()
        Me.grp_registra.SuspendLayout()
        Me.grp_opcao.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_condicoes
        '
        Me.grp_condicoes.Controls.Add(Me.txt_cond4)
        Me.grp_condicoes.Controls.Add(Me.txt_cond3)
        Me.grp_condicoes.Controls.Add(Me.txt_cond2)
        Me.grp_condicoes.Controls.Add(Me.txt_cond1)
        Me.grp_condicoes.Location = New System.Drawing.Point(529, 140)
        Me.grp_condicoes.Name = "grp_condicoes"
        Me.grp_condicoes.Size = New System.Drawing.Size(138, 41)
        Me.grp_condicoes.TabIndex = 8
        Me.grp_condicoes.TabStop = False
        Me.grp_condicoes.Text = "Condi��es:"
        '
        'txt_cond4
        '
        Me.txt_cond4.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cond4.Location = New System.Drawing.Point(105, 14)
        Me.txt_cond4.Name = "txt_cond4"
        Me.txt_cond4.Size = New System.Drawing.Size(27, 20)
        Me.txt_cond4.TabIndex = 15
        '
        'txt_cond3
        '
        Me.txt_cond3.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cond3.Location = New System.Drawing.Point(73, 13)
        Me.txt_cond3.Name = "txt_cond3"
        Me.txt_cond3.Size = New System.Drawing.Size(27, 20)
        Me.txt_cond3.TabIndex = 14
        '
        'txt_cond2
        '
        Me.txt_cond2.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cond2.Location = New System.Drawing.Point(40, 14)
        Me.txt_cond2.Name = "txt_cond2"
        Me.txt_cond2.Size = New System.Drawing.Size(27, 20)
        Me.txt_cond2.TabIndex = 13
        '
        'txt_cond1
        '
        Me.txt_cond1.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cond1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_cond1.Location = New System.Drawing.Point(8, 14)
        Me.txt_cond1.MaxLength = 3
        Me.txt_cond1.Name = "txt_cond1"
        Me.txt_cond1.Size = New System.Drawing.Size(27, 20)
        Me.txt_cond1.TabIndex = 12
        '
        'grp_peso
        '
        Me.grp_peso.Controls.Add(Me.txt_peso)
        Me.grp_peso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_peso.Location = New System.Drawing.Point(529, 0)
        Me.grp_peso.Name = "grp_peso"
        Me.grp_peso.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grp_peso.Size = New System.Drawing.Size(138, 46)
        Me.grp_peso.TabIndex = 19
        Me.grp_peso.TabStop = False
        Me.grp_peso.Text = "Peso"
        '
        'txt_peso
        '
        Me.txt_peso.BackColor = System.Drawing.SystemColors.Info
        Me.txt_peso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_peso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt_peso.Location = New System.Drawing.Point(17, 16)
        Me.txt_peso.MaxLength = 11
        Me.txt_peso.Name = "txt_peso"
        Me.txt_peso.ReadOnly = True
        Me.txt_peso.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_peso.Size = New System.Drawing.Size(100, 26)
        Me.txt_peso.TabIndex = 19
        Me.txt_peso.Text = "0,000"
        '
        'grp_total
        '
        Me.grp_total.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.grp_total.Controls.Add(Me.txt_total)
        Me.grp_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_total.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grp_total.Location = New System.Drawing.Point(530, 52)
        Me.grp_total.Name = "grp_total"
        Me.grp_total.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grp_total.Size = New System.Drawing.Size(138, 49)
        Me.grp_total.TabIndex = 20
        Me.grp_total.TabStop = False
        Me.grp_total.Text = "Total R$"
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.Info
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Blue
        Me.txt_total.Location = New System.Drawing.Point(17, 17)
        Me.txt_total.MaxLength = 11
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_total.Size = New System.Drawing.Size(100, 26)
        Me.txt_total.TabIndex = 20
        Me.txt_total.Text = "0,00"
        '
        'dtg_produtos
        '
        Me.dtg_produtos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_produtos.Location = New System.Drawing.Point(19, 240)
        Me.dtg_produtos.Name = "dtg_produtos"
        Me.dtg_produtos.Size = New System.Drawing.Size(649, 292)
        Me.dtg_produtos.TabIndex = 24
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_excluir.Location = New System.Drawing.Point(51, 10)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(37, 37)
        Me.btn_excluir.TabIndex = 18
        Me.btn_excluir.Text = "&Exc"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_sair
        '
        Me.btn_sair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sair.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_sair.Location = New System.Drawing.Point(74, 12)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(65, 35)
        Me.btn_sair.TabIndex = 17
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'grp_descontos
        '
        Me.grp_descontos.Controls.Add(Me.TextBox1)
        Me.grp_descontos.Location = New System.Drawing.Point(529, 98)
        Me.grp_descontos.Name = "grp_descontos"
        Me.grp_descontos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grp_descontos.Size = New System.Drawing.Size(138, 42)
        Me.grp_descontos.TabIndex = 32
        Me.grp_descontos.TabStop = False
        Me.grp_descontos.Text = "Descontos:"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Info
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(17, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 26)
        Me.TextBox1.TabIndex = 0
        '
        'grp_pedido
        '
        Me.grp_pedido.Controls.Add(Me.txt_codprod)
        Me.grp_pedido.Controls.Add(Me.txt_codpart)
        Me.grp_pedido.Controls.Add(Me.Label7)
        Me.grp_pedido.Controls.Add(Me.TextBox2)
        Me.grp_pedido.Controls.Add(Me.txt_pesquisa)
        Me.grp_pedido.Controls.Add(Me.Label1)
        Me.grp_pedido.Controls.Add(Me.lbl_desconto)
        Me.grp_pedido.Controls.Add(Me.txt_desconto)
        Me.grp_pedido.Controls.Add(Me.txt_senha)
        Me.grp_pedido.Controls.Add(Me.lbl_senha)
        Me.grp_pedido.Controls.Add(Me.txt_obs)
        Me.grp_pedido.Controls.Add(Me.lbl_obs)
        Me.grp_pedido.Controls.Add(Me.txt_plano)
        Me.grp_pedido.Controls.Add(Me.lbl_plano)
        Me.grp_pedido.Controls.Add(Me.cbo_vendedor)
        Me.grp_pedido.Controls.Add(Me.cbo_forpgto)
        Me.grp_pedido.Controls.Add(Me.lbl_formpagto)
        Me.grp_pedido.Controls.Add(Me.txt_consumo)
        Me.grp_pedido.Controls.Add(Me.Label8)
        Me.grp_pedido.Controls.Add(Me.lbl_vendedor)
        Me.grp_pedido.Controls.Add(Me.txt_operador)
        Me.grp_pedido.Controls.Add(Me.Label6)
        Me.grp_pedido.Controls.Add(Me.txt_rota)
        Me.grp_pedido.Controls.Add(Me.Label5)
        Me.grp_pedido.Controls.Add(Me.txt_supervisor)
        Me.grp_pedido.Controls.Add(Me.Label4)
        Me.grp_pedido.Controls.Add(Me.txt_portador)
        Me.grp_pedido.Controls.Add(Me.Label3)
        Me.grp_pedido.Controls.Add(Me.DateTimePicker1)
        Me.grp_pedido.Controls.Add(Me.txt_pedido)
        Me.grp_pedido.Controls.Add(Me.Label2)
        Me.grp_pedido.Controls.Add(Me.lbl_pedido)
        Me.grp_pedido.Location = New System.Drawing.Point(19, 0)
        Me.grp_pedido.Name = "grp_pedido"
        Me.grp_pedido.Size = New System.Drawing.Size(504, 234)
        Me.grp_pedido.TabIndex = 33
        Me.grp_pedido.TabStop = False
        '
        'txt_codprod
        '
        Me.txt_codprod.Location = New System.Drawing.Point(61, 197)
        Me.txt_codprod.Name = "txt_codprod"
        Me.txt_codprod.Size = New System.Drawing.Size(53, 20)
        Me.txt_codprod.TabIndex = 36
        '
        'txt_codpart
        '
        Me.txt_codpart.Location = New System.Drawing.Point(62, 38)
        Me.txt_codpart.MaxLength = 6
        Me.txt_codpart.Name = "txt_codpart"
        Me.txt_codpart.Size = New System.Drawing.Size(70, 20)
        Me.txt_codpart.TabIndex = 64
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(394, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Qtde:"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(428, 195)
        Me.TextBox2.MaxLength = 9
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(71, 21)
        Me.TextBox2.TabIndex = 62
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(130, 194)
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(258, 21)
        Me.txt_pesquisa.TabIndex = 60
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 199)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Produto:"
        '
        'lbl_desconto
        '
        Me.lbl_desconto.AutoSize = True
        Me.lbl_desconto.Location = New System.Drawing.Point(358, 102)
        Me.lbl_desconto.Name = "lbl_desconto"
        Me.lbl_desconto.Size = New System.Drawing.Size(70, 13)
        Me.lbl_desconto.TabIndex = 58
        Me.lbl_desconto.Text = "Desconto(%):"
        '
        'txt_desconto
        '
        Me.txt_desconto.Location = New System.Drawing.Point(430, 100)
        Me.txt_desconto.MaxLength = 6
        Me.txt_desconto.Name = "txt_desconto"
        Me.txt_desconto.Size = New System.Drawing.Size(68, 20)
        Me.txt_desconto.TabIndex = 57
        '
        'txt_senha
        '
        Me.txt_senha.Location = New System.Drawing.Point(232, 67)
        Me.txt_senha.MaxLength = 6
        Me.txt_senha.Name = "txt_senha"
        Me.txt_senha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_senha.Size = New System.Drawing.Size(115, 20)
        Me.txt_senha.TabIndex = 56
        '
        'lbl_senha
        '
        Me.lbl_senha.AutoSize = True
        Me.lbl_senha.Location = New System.Drawing.Point(185, 71)
        Me.lbl_senha.Name = "lbl_senha"
        Me.lbl_senha.Size = New System.Drawing.Size(41, 13)
        Me.lbl_senha.TabIndex = 55
        Me.lbl_senha.Text = "Senha:"
        '
        'txt_obs
        '
        Me.txt_obs.Location = New System.Drawing.Point(61, 160)
        Me.txt_obs.MaxLength = 79
        Me.txt_obs.Name = "txt_obs"
        Me.txt_obs.Size = New System.Drawing.Size(438, 20)
        Me.txt_obs.TabIndex = 51
        '
        'lbl_obs
        '
        Me.lbl_obs.AutoSize = True
        Me.lbl_obs.Location = New System.Drawing.Point(2, 163)
        Me.lbl_obs.Name = "lbl_obs"
        Me.lbl_obs.Size = New System.Drawing.Size(47, 13)
        Me.lbl_obs.TabIndex = 54
        Me.lbl_obs.Text = "Observ.:"
        '
        'txt_plano
        '
        Me.txt_plano.Location = New System.Drawing.Point(304, 128)
        Me.txt_plano.Name = "txt_plano"
        Me.txt_plano.Size = New System.Drawing.Size(24, 20)
        Me.txt_plano.TabIndex = 46
        '
        'lbl_plano
        '
        Me.lbl_plano.AutoSize = True
        Me.lbl_plano.Location = New System.Drawing.Point(261, 131)
        Me.lbl_plano.Name = "lbl_plano"
        Me.lbl_plano.Size = New System.Drawing.Size(37, 13)
        Me.lbl_plano.TabIndex = 53
        Me.lbl_plano.Text = "Plano:"
        '
        'cbo_vendedor
        '
        Me.cbo_vendedor.FormattingEnabled = True
        Me.cbo_vendedor.Location = New System.Drawing.Point(62, 126)
        Me.cbo_vendedor.Name = "cbo_vendedor"
        Me.cbo_vendedor.Size = New System.Drawing.Size(185, 21)
        Me.cbo_vendedor.TabIndex = 43
        '
        'cbo_forpgto
        '
        Me.cbo_forpgto.FormattingEnabled = True
        Me.cbo_forpgto.Items.AddRange(New Object() {"AV", "NP", "CH", "BL", "CR"})
        Me.cbo_forpgto.Location = New System.Drawing.Point(430, 127)
        Me.cbo_forpgto.Name = "cbo_forpgto"
        Me.cbo_forpgto.Size = New System.Drawing.Size(69, 21)
        Me.cbo_forpgto.TabIndex = 47
        '
        'lbl_formpagto
        '
        Me.lbl_formpagto.AutoSize = True
        Me.lbl_formpagto.Location = New System.Drawing.Point(346, 131)
        Me.lbl_formpagto.Name = "lbl_formpagto"
        Me.lbl_formpagto.Size = New System.Drawing.Size(55, 13)
        Me.lbl_formpagto.TabIndex = 52
        Me.lbl_formpagto.Text = "FormPgto:"
        '
        'txt_consumo
        '
        Me.txt_consumo.Location = New System.Drawing.Point(301, 96)
        Me.txt_consumo.Name = "txt_consumo"
        Me.txt_consumo.Size = New System.Drawing.Size(27, 20)
        Me.txt_consumo.TabIndex = 45
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(241, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Consumo:"
        '
        'lbl_vendedor
        '
        Me.lbl_vendedor.AutoSize = True
        Me.lbl_vendedor.Location = New System.Drawing.Point(3, 131)
        Me.lbl_vendedor.Name = "lbl_vendedor"
        Me.lbl_vendedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_vendedor.TabIndex = 49
        Me.lbl_vendedor.Text = "Vendedor:"
        '
        'txt_operador
        '
        Me.txt_operador.Location = New System.Drawing.Point(61, 98)
        Me.txt_operador.MaxLength = 10
        Me.txt_operador.Name = "txt_operador"
        Me.txt_operador.ReadOnly = True
        Me.txt_operador.Size = New System.Drawing.Size(155, 20)
        Me.txt_operador.TabIndex = 42
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Operador:"
        '
        'txt_rota
        '
        Me.txt_rota.Location = New System.Drawing.Point(430, 67)
        Me.txt_rota.MaxLength = 3
        Me.txt_rota.Name = "txt_rota"
        Me.txt_rota.Size = New System.Drawing.Size(66, 20)
        Me.txt_rota.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(388, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Rota:"
        '
        'txt_supervisor
        '
        Me.txt_supervisor.Location = New System.Drawing.Point(61, 68)
        Me.txt_supervisor.MaxLength = 10
        Me.txt_supervisor.Name = "txt_supervisor"
        Me.txt_supervisor.Size = New System.Drawing.Size(100, 20)
        Me.txt_supervisor.TabIndex = 39
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Supervisor:"
        '
        'txt_portador
        '
        Me.txt_portador.Location = New System.Drawing.Point(138, 38)
        Me.txt_portador.MaxLength = 40
        Me.txt_portador.Name = "txt_portador"
        Me.txt_portador.ReadOnly = True
        Me.txt_portador.Size = New System.Drawing.Size(358, 20)
        Me.txt_portador.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Cliente:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(416, 7)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(82, 20)
        Me.DateTimePicker1.TabIndex = 35
        '
        'txt_pedido
        '
        Me.txt_pedido.Location = New System.Drawing.Point(61, 9)
        Me.txt_pedido.MaxLength = 8
        Me.txt_pedido.Name = "txt_pedido"
        Me.txt_pedido.ReadOnly = True
        Me.txt_pedido.Size = New System.Drawing.Size(100, 20)
        Me.txt_pedido.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(341, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "DataPedido:"
        '
        'lbl_pedido
        '
        Me.lbl_pedido.AutoSize = True
        Me.lbl_pedido.Location = New System.Drawing.Point(2, 11)
        Me.lbl_pedido.Name = "lbl_pedido"
        Me.lbl_pedido.Size = New System.Drawing.Size(43, 13)
        Me.lbl_pedido.TabIndex = 32
        Me.lbl_pedido.Text = "Pedido:"
        '
        'btn_produtos
        '
        Me.btn_produtos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_produtos.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_produtos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_produtos.Location = New System.Drawing.Point(6, 11)
        Me.btn_produtos.Name = "btn_produtos"
        Me.btn_produtos.Size = New System.Drawing.Size(39, 37)
        Me.btn_produtos.TabIndex = 16
        Me.btn_produtos.Text = "&Inc"
        Me.btn_produtos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_produtos.UseVisualStyleBackColor = True
        '
        'grp_registra
        '
        Me.grp_registra.Controls.Add(Me.Button2)
        Me.grp_registra.Controls.Add(Me.btn_excluir)
        Me.grp_registra.Controls.Add(Me.btn_produtos)
        Me.grp_registra.Location = New System.Drawing.Point(529, 181)
        Me.grp_registra.Name = "grp_registra"
        Me.grp_registra.Size = New System.Drawing.Size(138, 53)
        Me.grp_registra.TabIndex = 34
        Me.grp_registra.TabStop = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.MetroSys.My.Resources.Resources.Modify
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(94, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(38, 36)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "&Alt"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(6, 13)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(63, 33)
        Me.Button3.TabIndex = 35
        Me.Button3.Text = "&Imprime"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'grp_mensagem
        '
        Me.grp_mensagem.Location = New System.Drawing.Point(19, 538)
        Me.grp_mensagem.Name = "grp_mensagem"
        Me.grp_mensagem.Size = New System.Drawing.Size(496, 47)
        Me.grp_mensagem.TabIndex = 36
        Me.grp_mensagem.TabStop = False
        Me.grp_mensagem.Text = "Mensagem"
        '
        'grp_opcao
        '
        Me.grp_opcao.Controls.Add(Me.Button3)
        Me.grp_opcao.Controls.Add(Me.btn_sair)
        Me.grp_opcao.Location = New System.Drawing.Point(525, 536)
        Me.grp_opcao.Name = "grp_opcao"
        Me.grp_opcao.Size = New System.Drawing.Size(143, 55)
        Me.grp_opcao.TabIndex = 65
        Me.grp_opcao.TabStop = False
        '
        'Frm_Pedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 602)
        Me.Controls.Add(Me.grp_opcao)
        Me.Controls.Add(Me.grp_mensagem)
        Me.Controls.Add(Me.grp_registra)
        Me.Controls.Add(Me.grp_pedido)
        Me.Controls.Add(Me.grp_descontos)
        Me.Controls.Add(Me.dtg_produtos)
        Me.Controls.Add(Me.grp_total)
        Me.Controls.Add(Me.grp_peso)
        Me.Controls.Add(Me.grp_condicoes)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Pedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos"
        Me.grp_condicoes.ResumeLayout(False)
        Me.grp_condicoes.PerformLayout()
        Me.grp_peso.ResumeLayout(False)
        Me.grp_peso.PerformLayout()
        Me.grp_total.ResumeLayout(False)
        Me.grp_total.PerformLayout()
        CType(Me.dtg_produtos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_descontos.ResumeLayout(False)
        Me.grp_descontos.PerformLayout()
        Me.grp_pedido.ResumeLayout(False)
        Me.grp_pedido.PerformLayout()
        Me.grp_registra.ResumeLayout(False)
        Me.grp_opcao.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp_condicoes As System.Windows.Forms.GroupBox
    Friend WithEvents grp_peso As System.Windows.Forms.GroupBox
    Friend WithEvents grp_total As System.Windows.Forms.GroupBox
    Public WithEvents txt_cond4 As System.Windows.Forms.TextBox
    Public WithEvents txt_cond3 As System.Windows.Forms.TextBox
    Public WithEvents txt_cond2 As System.Windows.Forms.TextBox
    Public WithEvents txt_cond1 As System.Windows.Forms.TextBox
    Public WithEvents txt_peso As System.Windows.Forms.TextBox
    Public WithEvents txt_total As System.Windows.Forms.TextBox
    Public WithEvents dtg_produtos As System.Windows.Forms.DataGridView
    Public WithEvents btn_excluir As System.Windows.Forms.Button
    Public WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents grp_descontos As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents grp_pedido As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_desconto As System.Windows.Forms.Label
    Friend WithEvents txt_desconto As System.Windows.Forms.TextBox
    Friend WithEvents txt_senha As System.Windows.Forms.TextBox
    Friend WithEvents lbl_senha As System.Windows.Forms.Label
    Public WithEvents txt_obs As System.Windows.Forms.TextBox
    Friend WithEvents lbl_obs As System.Windows.Forms.Label
    Public WithEvents txt_plano As System.Windows.Forms.TextBox
    Friend WithEvents lbl_plano As System.Windows.Forms.Label
    Public WithEvents cbo_vendedor As System.Windows.Forms.ComboBox
    Public WithEvents cbo_forpgto As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_formpagto As System.Windows.Forms.Label
    Public WithEvents txt_consumo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl_vendedor As System.Windows.Forms.Label
    Public WithEvents txt_operador As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txt_rota As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents txt_supervisor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents txt_portador As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Public WithEvents txt_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_pedido As System.Windows.Forms.Label
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents btn_produtos As System.Windows.Forms.Button
    Friend WithEvents grp_registra As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txt_codpart As System.Windows.Forms.TextBox
    Friend WithEvents txt_codprod As System.Windows.Forms.TextBox
    Friend WithEvents grp_opcao As System.Windows.Forms.GroupBox
    Friend WithEvents grp_mensagem As System.Windows.Forms.GroupBox
End Class
