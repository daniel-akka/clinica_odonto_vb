<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Dup_ManDuplicatas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Dup_ManDuplicatas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_loja = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_lancarDespesa = New System.Windows.Forms.Button()
        Me.btn_divisoria = New System.Windows.Forms.Button()
        Me.txt_somaMarcados = New System.Windows.Forms.TextBox()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_baixaMarcados = New System.Windows.Forms.Button()
        Me.btn_pagamento = New System.Windows.Forms.Button()
        Me.btn_outros = New System.Windows.Forms.Button()
        Me.grb_opcoes = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbo_doutores = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lbl_registros = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdb_nenhuma = New System.Windows.Forms.RadioButton()
        Me.rdb_vencimento = New System.Windows.Forms.RadioButton()
        Me.rdb_pagamento = New System.Windows.Forms.RadioButton()
        Me.rdb_emiss = New System.Windows.Forms.RadioButton()
        Me.msk_fim = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Msk_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_portador = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_documento = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txt_totais = New System.Windows.Forms.TextBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.dtg_documentos = New System.Windows.Forms.DataGridView()
        Me.lbl_normal = New System.Windows.Forms.Label()
        Me.btn_LblNormal = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.pagar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.f_geno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_portad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_sit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dentista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_duplic = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_emiss = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_vencto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_juros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_dtpaga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.historico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.divisoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.despesa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numfatura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codcli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grb_opcoes.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dtg_documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Loja:"
        '
        'cbo_loja
        '
        Me.cbo_loja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_loja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_loja.FormattingEnabled = True
        Me.cbo_loja.Items.AddRange(New Object() {"01", "02", "03", "04"})
        Me.cbo_loja.Location = New System.Drawing.Point(65, 16)
        Me.cbo_loja.Name = "cbo_loja"
        Me.cbo_loja.Size = New System.Drawing.Size(281, 23)
        Me.cbo_loja.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(375, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Tipo:"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"Vencidas", "Quitadas", "Devolvidas", "Estornadas", "Em Aberto", "Documento"})
        Me.cbo_tipo.Location = New System.Drawing.Point(415, 18)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(142, 23)
        Me.cbo_tipo.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 498)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(997, 42)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(13, 19)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(39, 15)
        Me.lbl_mensagem.TabIndex = 13
        Me.lbl_mensagem.Text = "        "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_lancarDespesa)
        Me.GroupBox2.Controls.Add(Me.btn_divisoria)
        Me.GroupBox2.Controls.Add(Me.txt_somaMarcados)
        Me.GroupBox2.Controls.Add(Me.btn_incluir)
        Me.GroupBox2.Controls.Add(Me.btn_alterar)
        Me.GroupBox2.Controls.Add(Me.btn_baixaMarcados)
        Me.GroupBox2.Controls.Add(Me.btn_pagamento)
        Me.GroupBox2.Controls.Add(Me.btn_outros)
        Me.GroupBox2.Location = New System.Drawing.Point(871, 182)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(139, 309)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'btn_lancarDespesa
        '
        Me.btn_lancarDespesa.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_lancarDespesa.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_lancarDespesa.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_lancarDespesa.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_lancarDespesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_lancarDespesa.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_lancarDespesa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_lancarDespesa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_lancarDespesa.Location = New System.Drawing.Point(13, 160)
        Me.btn_lancarDespesa.Name = "btn_lancarDespesa"
        Me.btn_lancarDespesa.Size = New System.Drawing.Size(116, 32)
        Me.btn_lancarDespesa.TabIndex = 13
        Me.btn_lancarDespesa.Text = "Lançar Desp.!"
        Me.btn_lancarDespesa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_lancarDespesa.UseVisualStyleBackColor = False
        '
        'btn_divisoria
        '
        Me.btn_divisoria.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_divisoria.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_divisoria.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_divisoria.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_divisoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_divisoria.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_divisoria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_divisoria.Image = CType(resources.GetObject("btn_divisoria.Image"), System.Drawing.Image)
        Me.btn_divisoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_divisoria.Location = New System.Drawing.Point(13, 123)
        Me.btn_divisoria.Name = "btn_divisoria"
        Me.btn_divisoria.Size = New System.Drawing.Size(116, 32)
        Me.btn_divisoria.TabIndex = 13
        Me.btn_divisoria.Text = "Divisória"
        Me.btn_divisoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_divisoria.UseVisualStyleBackColor = False
        '
        'txt_somaMarcados
        '
        Me.txt_somaMarcados.BackColor = System.Drawing.SystemColors.Info
        Me.txt_somaMarcados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_somaMarcados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_somaMarcados.ForeColor = System.Drawing.Color.Blue
        Me.txt_somaMarcados.Location = New System.Drawing.Point(20, 282)
        Me.txt_somaMarcados.MaxLength = 14
        Me.txt_somaMarcados.Name = "txt_somaMarcados"
        Me.txt_somaMarcados.Size = New System.Drawing.Size(96, 20)
        Me.txt_somaMarcados.TabIndex = 12
        Me.txt_somaMarcados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_incluir
        '
        Me.btn_incluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_incluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_incluir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_incluir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_incluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_incluir.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_incluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_incluir.Image = Global.RTecSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_incluir.Location = New System.Drawing.Point(13, 13)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(116, 32)
        Me.btn_incluir.TabIndex = 9
        Me.btn_incluir.Text = "Incluir"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_incluir.UseVisualStyleBackColor = False
        '
        'btn_alterar
        '
        Me.btn_alterar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_alterar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_alterar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_alterar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_alterar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_alterar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_alterar.Image = Global.RTecSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(13, 49)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(116, 32)
        Me.btn_alterar.TabIndex = 10
        Me.btn_alterar.Text = "Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = False
        '
        'btn_baixaMarcados
        '
        Me.btn_baixaMarcados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_baixaMarcados.Image = CType(resources.GetObject("btn_baixaMarcados.Image"), System.Drawing.Image)
        Me.btn_baixaMarcados.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_baixaMarcados.Location = New System.Drawing.Point(13, 233)
        Me.btn_baixaMarcados.Name = "btn_baixaMarcados"
        Me.btn_baixaMarcados.Size = New System.Drawing.Size(116, 46)
        Me.btn_baixaMarcados.TabIndex = 11
        Me.btn_baixaMarcados.Text = "Baixa. Total"
        Me.btn_baixaMarcados.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_baixaMarcados.UseVisualStyleBackColor = True
        '
        'btn_pagamento
        '
        Me.btn_pagamento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pagamento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_pagamento.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_pagamento.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_pagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pagamento.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_pagamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_pagamento.Image = CType(resources.GetObject("btn_pagamento.Image"), System.Drawing.Image)
        Me.btn_pagamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_pagamento.Location = New System.Drawing.Point(13, 196)
        Me.btn_pagamento.Name = "btn_pagamento"
        Me.btn_pagamento.Size = New System.Drawing.Size(116, 32)
        Me.btn_pagamento.TabIndex = 11
        Me.btn_pagamento.Text = "Pagamento"
        Me.btn_pagamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pagamento.UseVisualStyleBackColor = False
        '
        'btn_outros
        '
        Me.btn_outros.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_outros.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_outros.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_outros.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_outros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_outros.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_outros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_outros.Image = Global.RTecSys.My.Resources.Resources.OutrasOpcoes
        Me.btn_outros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_outros.Location = New System.Drawing.Point(13, 86)
        Me.btn_outros.Name = "btn_outros"
        Me.btn_outros.Size = New System.Drawing.Size(116, 32)
        Me.btn_outros.TabIndex = 11
        Me.btn_outros.Text = "Outros"
        Me.btn_outros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_outros.UseVisualStyleBackColor = False
        '
        'grb_opcoes
        '
        Me.grb_opcoes.Controls.Add(Me.Label12)
        Me.grb_opcoes.Controls.Add(Me.cbo_doutores)
        Me.grb_opcoes.Controls.Add(Me.GroupBox5)
        Me.grb_opcoes.Controls.Add(Me.GroupBox3)
        Me.grb_opcoes.Controls.Add(Me.txt_portador)
        Me.grb_opcoes.Controls.Add(Me.Label5)
        Me.grb_opcoes.Controls.Add(Me.txt_documento)
        Me.grb_opcoes.Controls.Add(Me.Label6)
        Me.grb_opcoes.Controls.Add(Me.GroupBox4)
        Me.grb_opcoes.Controls.Add(Me.btn_buscar)
        Me.grb_opcoes.Controls.Add(Me.cbo_tipo)
        Me.grb_opcoes.Controls.Add(Me.Label4)
        Me.grb_opcoes.Controls.Add(Me.Label1)
        Me.grb_opcoes.Controls.Add(Me.cbo_loja)
        Me.grb_opcoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grb_opcoes.Location = New System.Drawing.Point(13, 72)
        Me.grb_opcoes.Name = "grb_opcoes"
        Me.grb_opcoes.Size = New System.Drawing.Size(997, 110)
        Me.grb_opcoes.TabIndex = 0
        Me.grb_opcoes.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(243, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Dentista:"
        '
        'cbo_doutores
        '
        Me.cbo_doutores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_doutores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_doutores.FormattingEnabled = True
        Me.cbo_doutores.Location = New System.Drawing.Point(246, 69)
        Me.cbo_doutores.Name = "cbo_doutores"
        Me.cbo_doutores.Size = New System.Drawing.Size(170, 23)
        Me.cbo_doutores.TabIndex = 20
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lbl_registros)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(875, 70)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(114, 35)
        Me.GroupBox5.TabIndex = 19
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Registros"
        '
        'lbl_registros
        '
        Me.lbl_registros.AutoSize = True
        Me.lbl_registros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_registros.ForeColor = System.Drawing.Color.Red
        Me.lbl_registros.Location = New System.Drawing.Point(30, 16)
        Me.lbl_registros.Name = "lbl_registros"
        Me.lbl_registros.Size = New System.Drawing.Size(14, 13)
        Me.lbl_registros.TabIndex = 0
        Me.lbl_registros.Text = "0"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.rdb_nenhuma)
        Me.GroupBox3.Controls.Add(Me.rdb_vencimento)
        Me.GroupBox3.Controls.Add(Me.rdb_pagamento)
        Me.GroupBox3.Controls.Add(Me.rdb_emiss)
        Me.GroupBox3.Controls.Add(Me.msk_fim)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Msk_inicio)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(427, 41)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(347, 64)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        '
        'rdb_nenhuma
        '
        Me.rdb_nenhuma.AutoSize = True
        Me.rdb_nenhuma.Checked = True
        Me.rdb_nenhuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_nenhuma.Location = New System.Drawing.Point(290, 16)
        Me.rdb_nenhuma.Name = "rdb_nenhuma"
        Me.rdb_nenhuma.Size = New System.Drawing.Size(49, 19)
        Me.rdb_nenhuma.TabIndex = 17
        Me.rdb_nenhuma.TabStop = True
        Me.rdb_nenhuma.Text = "N/D"
        Me.rdb_nenhuma.UseVisualStyleBackColor = True
        '
        'rdb_vencimento
        '
        Me.rdb_vencimento.AutoSize = True
        Me.rdb_vencimento.Location = New System.Drawing.Point(215, 39)
        Me.rdb_vencimento.Name = "rdb_vencimento"
        Me.rdb_vencimento.Size = New System.Drawing.Size(90, 19)
        Me.rdb_vencimento.TabIndex = 17
        Me.rdb_vencimento.Text = "Vencimento"
        Me.rdb_vencimento.UseVisualStyleBackColor = True
        '
        'rdb_pagamento
        '
        Me.rdb_pagamento.AutoSize = True
        Me.rdb_pagamento.Location = New System.Drawing.Point(109, 39)
        Me.rdb_pagamento.Name = "rdb_pagamento"
        Me.rdb_pagamento.Size = New System.Drawing.Size(89, 19)
        Me.rdb_pagamento.TabIndex = 17
        Me.rdb_pagamento.Text = "Pagamento"
        Me.rdb_pagamento.UseVisualStyleBackColor = True
        '
        'rdb_emiss
        '
        Me.rdb_emiss.AutoSize = True
        Me.rdb_emiss.Location = New System.Drawing.Point(14, 39)
        Me.rdb_emiss.Name = "rdb_emiss"
        Me.rdb_emiss.Size = New System.Drawing.Size(73, 19)
        Me.rdb_emiss.TabIndex = 17
        Me.rdb_emiss.Text = "Emissão"
        Me.rdb_emiss.UseVisualStyleBackColor = True
        '
        'msk_fim
        '
        Me.msk_fim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.msk_fim.Location = New System.Drawing.Point(183, 13)
        Me.msk_fim.Name = "msk_fim"
        Me.msk_fim.Size = New System.Drawing.Size(87, 21)
        Me.msk_fim.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(163, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "A"
        '
        'Msk_inicio
        '
        Me.Msk_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Msk_inicio.Location = New System.Drawing.Point(70, 13)
        Me.Msk_inicio.Name = "Msk_inicio"
        Me.Msk_inicio.Size = New System.Drawing.Size(87, 21)
        Me.Msk_inicio.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Periodo:"
        '
        'txt_portador
        '
        Me.txt_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_portador.Location = New System.Drawing.Point(12, 70)
        Me.txt_portador.MaxLength = 100
        Me.txt_portador.Name = "txt_portador"
        Me.txt_portador.Size = New System.Drawing.Size(218, 21)
        Me.txt_portador.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 15)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Cliente:"
        '
        'txt_documento
        '
        Me.txt_documento.Location = New System.Drawing.Point(658, 18)
        Me.txt_documento.MaxLength = 9
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.Size = New System.Drawing.Size(100, 21)
        Me.txt_documento.TabIndex = 5
        Me.txt_documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(578, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Documento:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_totais)
        Me.GroupBox4.Location = New System.Drawing.Point(875, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(114, 54)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Totais R$"
        '
        'txt_totais
        '
        Me.txt_totais.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totais.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totais.ForeColor = System.Drawing.Color.Red
        Me.txt_totais.Location = New System.Drawing.Point(6, 21)
        Me.txt_totais.MaxLength = 16
        Me.txt_totais.Name = "txt_totais"
        Me.txt_totais.ReadOnly = True
        Me.txt_totais.Size = New System.Drawing.Size(102, 23)
        Me.txt_totais.TabIndex = 15
        Me.txt_totais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = Global.RTecSys.My.Resources.Resources.Busca_16x16
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.Location = New System.Drawing.Point(786, 26)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(81, 63)
        Me.btn_buscar.TabIndex = 6
        Me.btn_buscar.Text = "&Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'dtg_documentos
        '
        Me.dtg_documentos.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_documentos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_documentos.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_documentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_documentos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_documentos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_documentos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_documentos.ColumnHeadersHeight = 25
        Me.dtg_documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_documentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pagar, Me.f_geno, Me.p_portad, Me.f_tipo, Me.f_sit, Me.dentista, Me.f_duplic, Me.f_emiss, Me.f_valor, Me.f_vencto, Me.f_juros, Me.DIAS, Me.f_dtpaga, Me.id, Me.historico, Me.divisoria, Me.despesa, Me.numfatura, Me.codcli, Me.f_banco})
        Me.dtg_documentos.Location = New System.Drawing.Point(13, 189)
        Me.dtg_documentos.MultiSelect = False
        Me.dtg_documentos.Name = "dtg_documentos"
        Me.dtg_documentos.ReadOnly = True
        Me.dtg_documentos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_documentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_documentos.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dtg_documentos.Size = New System.Drawing.Size(852, 302)
        Me.dtg_documentos.TabIndex = 20
        '
        'lbl_normal
        '
        Me.lbl_normal.AutoSize = True
        Me.lbl_normal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_normal.Location = New System.Drawing.Point(47, 53)
        Me.lbl_normal.Name = "lbl_normal"
        Me.lbl_normal.Size = New System.Drawing.Size(68, 19)
        Me.lbl_normal.TabIndex = 21
        Me.lbl_normal.Text = "- Normal"
        '
        'btn_LblNormal
        '
        Me.btn_LblNormal.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_LblNormal.Enabled = False
        Me.btn_LblNormal.FlatAppearance.BorderSize = 0
        Me.btn_LblNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_LblNormal.Location = New System.Drawing.Point(29, 56)
        Me.btn_LblNormal.Name = "btn_LblNormal"
        Me.btn_LblNormal.Size = New System.Drawing.Size(17, 14)
        Me.btn_LblNormal.TabIndex = 22
        Me.btn_LblNormal.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label7.Location = New System.Drawing.Point(167, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 19)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "- Liquidada"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MediumBlue
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(149, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(17, 14)
        Me.Button1.TabIndex = 22
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Green
        Me.Label8.Location = New System.Drawing.Point(301, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 19)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "- Devolvida"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.MediumOrchid
        Me.Label9.Location = New System.Drawing.Point(429, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 19)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "- Estornada"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Green
        Me.Button2.Enabled = False
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(283, 56)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(17, 14)
        Me.Button2.TabIndex = 22
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.MediumOrchid
        Me.Button3.Enabled = False
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(411, 56)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(17, 14)
        Me.Button3.TabIndex = 22
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(563, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 19)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "- Vencida"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Red
        Me.Button4.Enabled = False
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(545, 56)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(17, 14)
        Me.Button4.TabIndex = 22
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(820, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(182, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Atualizar [F5]       Deletar [Del]"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-7, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1033, 42)
        Me.Panel1.TabIndex = 55
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(423, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'pagar
        '
        Me.pagar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pagar.HeaderText = "PAG."
        Me.pagar.Name = "pagar"
        Me.pagar.ReadOnly = True
        Me.pagar.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pagar.Width = 40
        '
        'f_geno
        '
        Me.f_geno.HeaderText = "LOJA"
        Me.f_geno.MaxInputLength = 8
        Me.f_geno.Name = "f_geno"
        Me.f_geno.ReadOnly = True
        Me.f_geno.Visible = False
        Me.f_geno.Width = 50
        '
        'p_portad
        '
        Me.p_portad.HeaderText = "CLIENTE"
        Me.p_portad.Name = "p_portad"
        Me.p_portad.ReadOnly = True
        Me.p_portad.Width = 230
        '
        'f_tipo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_tipo.DefaultCellStyle = DataGridViewCellStyle3
        Me.f_tipo.HeaderText = "TIPO"
        Me.f_tipo.Name = "f_tipo"
        Me.f_tipo.ReadOnly = True
        Me.f_tipo.Width = 50
        '
        'f_sit
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_sit.DefaultCellStyle = DataGridViewCellStyle4
        Me.f_sit.HeaderText = "SIT"
        Me.f_sit.Name = "f_sit"
        Me.f_sit.ReadOnly = True
        Me.f_sit.Width = 40
        '
        'dentista
        '
        Me.dentista.HeaderText = "DENTISTA"
        Me.dentista.Name = "dentista"
        Me.dentista.ReadOnly = True
        Me.dentista.Width = 140
        '
        'f_duplic
        '
        Me.f_duplic.HeaderText = "DOCUMENTO"
        Me.f_duplic.Name = "f_duplic"
        Me.f_duplic.ReadOnly = True
        Me.f_duplic.Width = 110
        '
        'f_emiss
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_emiss.DefaultCellStyle = DataGridViewCellStyle5
        Me.f_emiss.HeaderText = "EMISSAO"
        Me.f_emiss.MaxInputLength = 10
        Me.f_emiss.Name = "f_emiss"
        Me.f_emiss.ReadOnly = True
        Me.f_emiss.Width = 90
        '
        'f_valor
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.f_valor.DefaultCellStyle = DataGridViewCellStyle6
        Me.f_valor.HeaderText = "VALOR R$"
        Me.f_valor.Name = "f_valor"
        Me.f_valor.ReadOnly = True
        '
        'f_vencto
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_vencto.DefaultCellStyle = DataGridViewCellStyle7
        Me.f_vencto.HeaderText = "VENCTO"
        Me.f_vencto.MaxInputLength = 10
        Me.f_vencto.Name = "f_vencto"
        Me.f_vencto.ReadOnly = True
        Me.f_vencto.Width = 90
        '
        'f_juros
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.f_juros.DefaultCellStyle = DataGridViewCellStyle8
        Me.f_juros.HeaderText = "JUROS"
        Me.f_juros.Name = "f_juros"
        Me.f_juros.ReadOnly = True
        '
        'DIAS
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DIAS.DefaultCellStyle = DataGridViewCellStyle9
        Me.DIAS.HeaderText = "DIAS"
        Me.DIAS.Name = "DIAS"
        Me.DIAS.ReadOnly = True
        Me.DIAS.Width = 70
        '
        'f_dtpaga
        '
        Me.f_dtpaga.HeaderText = "PAGAMENTO"
        Me.f_dtpaga.MaxInputLength = 10
        Me.f_dtpaga.Name = "f_dtpaga"
        Me.f_dtpaga.ReadOnly = True
        Me.f_dtpaga.Width = 90
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'historico
        '
        Me.historico.HeaderText = "HISTORICO"
        Me.historico.Name = "historico"
        Me.historico.ReadOnly = True
        Me.historico.Width = 300
        '
        'divisoria
        '
        Me.divisoria.HeaderText = "Divisoria"
        Me.divisoria.Name = "divisoria"
        Me.divisoria.ReadOnly = True
        Me.divisoria.Visible = False
        '
        'despesa
        '
        Me.despesa.HeaderText = "Despesa"
        Me.despesa.Name = "despesa"
        Me.despesa.ReadOnly = True
        Me.despesa.Visible = False
        '
        'numfatura
        '
        Me.numfatura.HeaderText = "Num Fatura"
        Me.numfatura.Name = "numfatura"
        Me.numfatura.ReadOnly = True
        Me.numfatura.Visible = False
        '
        'codcli
        '
        Me.codcli.HeaderText = "CodCliente"
        Me.codcli.Name = "codcli"
        Me.codcli.ReadOnly = True
        Me.codcli.Visible = False
        '
        'f_banco
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_banco.DefaultCellStyle = DataGridViewCellStyle10
        Me.f_banco.HeaderText = "BANCO"
        Me.f_banco.Name = "f_banco"
        Me.f_banco.ReadOnly = True
        Me.f_banco.Visible = False
        Me.f_banco.Width = 53
        '
        'Frm_Dup_ManDuplicatas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 552)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_LblNormal)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbl_normal)
        Me.Controls.Add(Me.dtg_documentos)
        Me.Controls.Add(Me.grb_opcoes)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_Dup_ManDuplicatas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção de Duplicatas a Receber"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grb_opcoes.ResumeLayout(False)
        Me.grb_opcoes.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dtg_documentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grb_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_totais As System.Windows.Forms.TextBox
    Friend WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtg_documentos As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_loja As System.Windows.Forms.ComboBox
    Friend WithEvents btn_baixaMarcados As System.Windows.Forms.Button
    Friend WithEvents txt_portador As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_normal As System.Windows.Forms.Label
    Friend WithEvents btn_LblNormal As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_somaMarcados As System.Windows.Forms.TextBox
    Friend WithEvents btn_pagamento As System.Windows.Forms.Button
    Friend WithEvents btn_outros As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_nenhuma As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_vencimento As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_pagamento As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_emiss As System.Windows.Forms.RadioButton
    Friend WithEvents msk_fim As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Msk_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_registros As System.Windows.Forms.Label
    Friend WithEvents btn_lancarDespesa As System.Windows.Forms.Button
    Friend WithEvents btn_divisoria As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbo_doutores As System.Windows.Forms.ComboBox
    Friend WithEvents pagar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents f_geno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_portad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_sit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dentista As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_duplic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_emiss As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_vencto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_juros As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_dtpaga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents historico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents divisoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents despesa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numfatura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codcli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_banco As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
