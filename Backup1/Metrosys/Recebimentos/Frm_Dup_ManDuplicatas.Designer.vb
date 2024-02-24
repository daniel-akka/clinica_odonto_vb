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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_loja = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Msk_inicio = New System.Windows.Forms.MaskedTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.msk_fim = New System.Windows.Forms.MaskedTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbo_tipo = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_somaMarcados = New System.Windows.Forms.TextBox
        Me.btn_incluir = New System.Windows.Forms.Button
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.btn_baixaMarcados = New System.Windows.Forms.Button
        Me.btn_pagamento = New System.Windows.Forms.Button
        Me.btn_outros = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_documento = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txt_totais = New System.Windows.Forms.TextBox
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dtg_documentos = New System.Windows.Forms.DataGridView
        Me.pagar = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.f_geno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.p_portad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_sit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_banco = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_duplic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_emiss = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_vencto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_juros = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DIAS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_dtpaga = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Loja:"
        '
        'cbo_loja
        '
        Me.cbo_loja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_loja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_loja.FormattingEnabled = True
        Me.cbo_loja.Items.AddRange(New Object() {"01", "02", "03", "04"})
        Me.cbo_loja.Location = New System.Drawing.Point(58, 16)
        Me.cbo_loja.Name = "cbo_loja"
        Me.cbo_loja.Size = New System.Drawing.Size(256, 23)
        Me.cbo_loja.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Periodo:"
        '
        'Msk_inicio
        '
        Me.Msk_inicio.Location = New System.Drawing.Point(58, 47)
        Me.Msk_inicio.Mask = "00/00/0000"
        Me.Msk_inicio.Name = "Msk_inicio"
        Me.Msk_inicio.Size = New System.Drawing.Size(100, 20)
        Me.Msk_inicio.TabIndex = 3
        Me.Msk_inicio.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(175, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "A"
        '
        'msk_fim
        '
        Me.msk_fim.Location = New System.Drawing.Point(207, 47)
        Me.msk_fim.Mask = "00/00/0000"
        Me.msk_fim.Name = "msk_fim"
        Me.msk_fim.Size = New System.Drawing.Size(107, 20)
        Me.msk_fim.TabIndex = 4
        Me.msk_fim.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(347, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Tipo:"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"Vencidas", "Quitadas", "Devolvidas", "Estornadas", "Em Aberto", "Documento"})
        Me.cbo_tipo.Location = New System.Drawing.Point(384, 18)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(117, 21)
        Me.cbo_tipo.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 473)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(777, 53)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(13, 23)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(39, 15)
        Me.lbl_mensagem.TabIndex = 13
        Me.lbl_mensagem.Text = "        "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_somaMarcados)
        Me.GroupBox2.Controls.Add(Me.btn_incluir)
        Me.GroupBox2.Controls.Add(Me.btn_alterar)
        Me.GroupBox2.Controls.Add(Me.btn_baixaMarcados)
        Me.GroupBox2.Controls.Add(Me.btn_pagamento)
        Me.GroupBox2.Controls.Add(Me.btn_outros)
        Me.GroupBox2.Location = New System.Drawing.Point(704, 164)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(99, 301)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'txt_somaMarcados
        '
        Me.txt_somaMarcados.BackColor = System.Drawing.SystemColors.Control
        Me.txt_somaMarcados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_somaMarcados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_somaMarcados.ForeColor = System.Drawing.Color.Red
        Me.txt_somaMarcados.Location = New System.Drawing.Point(10, 276)
        Me.txt_somaMarcados.MaxLength = 14
        Me.txt_somaMarcados.Name = "txt_somaMarcados"
        Me.txt_somaMarcados.Size = New System.Drawing.Size(83, 20)
        Me.txt_somaMarcados.TabIndex = 12
        Me.txt_somaMarcados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_incluir
        '
        Me.btn_incluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_incluir.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.Location = New System.Drawing.Point(8, 13)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(83, 44)
        Me.btn_incluir.TabIndex = 9
        Me.btn_incluir.Text = "Incluir"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(8, 63)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(83, 44)
        Me.btn_alterar.TabIndex = 10
        Me.btn_alterar.Text = "Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_baixaMarcados
        '
        Me.btn_baixaMarcados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_baixaMarcados.Image = CType(resources.GetObject("btn_baixaMarcados.Image"), System.Drawing.Image)
        Me.btn_baixaMarcados.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_baixaMarcados.Location = New System.Drawing.Point(10, 213)
        Me.btn_baixaMarcados.Name = "btn_baixaMarcados"
        Me.btn_baixaMarcados.Size = New System.Drawing.Size(83, 59)
        Me.btn_baixaMarcados.TabIndex = 11
        Me.btn_baixaMarcados.Text = "Baixa. Total Marcados"
        Me.btn_baixaMarcados.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_baixaMarcados.UseVisualStyleBackColor = True
        '
        'btn_pagamento
        '
        Me.btn_pagamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pagamento.Image = CType(resources.GetObject("btn_pagamento.Image"), System.Drawing.Image)
        Me.btn_pagamento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_pagamento.Location = New System.Drawing.Point(8, 163)
        Me.btn_pagamento.Name = "btn_pagamento"
        Me.btn_pagamento.Size = New System.Drawing.Size(83, 44)
        Me.btn_pagamento.TabIndex = 11
        Me.btn_pagamento.Text = "Pagamento"
        Me.btn_pagamento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_pagamento.UseVisualStyleBackColor = True
        '
        'btn_outros
        '
        Me.btn_outros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_outros.Image = Global.MetroSys.My.Resources.Resources.OutrasOpcoes
        Me.btn_outros.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_outros.Location = New System.Drawing.Point(8, 113)
        Me.btn_outros.Name = "btn_outros"
        Me.btn_outros.Size = New System.Drawing.Size(83, 44)
        Me.btn_outros.TabIndex = 11
        Me.btn_outros.Text = "Outros"
        Me.btn_outros.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_outros.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_documento)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.btn_buscar)
        Me.GroupBox3.Controls.Add(Me.cbo_tipo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.msk_fim)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.cbo_loja)
        Me.GroupBox3.Controls.Add(Me.Msk_inicio)
        Me.GroupBox3.Location = New System.Drawing.Point(26, 85)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(777, 73)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'txt_documento
        '
        Me.txt_documento.Location = New System.Drawing.Point(401, 47)
        Me.txt_documento.MaxLength = 9
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.Size = New System.Drawing.Size(100, 20)
        Me.txt_documento.TabIndex = 5
        Me.txt_documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(332, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Documento:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_totais)
        Me.GroupBox4.Location = New System.Drawing.Point(644, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(124, 54)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Totais R$"
        '
        'txt_totais
        '
        Me.txt_totais.Enabled = False
        Me.txt_totais.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totais.ForeColor = System.Drawing.Color.Red
        Me.txt_totais.Location = New System.Drawing.Point(6, 21)
        Me.txt_totais.MaxLength = 16
        Me.txt_totais.Name = "txt_totais"
        Me.txt_totais.Size = New System.Drawing.Size(112, 23)
        Me.txt_totais.TabIndex = 15
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = Global.MetroSys.My.Resources.Resources.Busca_16x16
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.Location = New System.Drawing.Point(511, 34)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(71, 33)
        Me.btn_buscar.TabIndex = 6
        Me.btn_buscar.Text = "&Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(818, 82)
        Me.Panel1.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(691, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 26)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "MetroSys"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(284, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(218, 63)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'dtg_documentos
        '
        Me.dtg_documentos.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Turquoise
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.dtg_documentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pagar, Me.f_geno, Me.p_portad, Me.f_tipo, Me.f_sit, Me.f_banco, Me.f_duplic, Me.f_emiss, Me.f_vencto, Me.f_valor, Me.f_juros, Me.DIAS, Me.f_dtpaga})
        Me.dtg_documentos.Location = New System.Drawing.Point(26, 164)
        Me.dtg_documentos.MultiSelect = False
        Me.dtg_documentos.Name = "dtg_documentos"
        Me.dtg_documentos.ReadOnly = True
        Me.dtg_documentos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_documentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_documentos.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dtg_documentos.Size = New System.Drawing.Size(667, 301)
        Me.dtg_documentos.TabIndex = 20
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
        Me.p_portad.HeaderText = "PORTADOR"
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
        'f_banco
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_banco.DefaultCellStyle = DataGridViewCellStyle5
        Me.f_banco.HeaderText = "BANCO"
        Me.f_banco.Name = "f_banco"
        Me.f_banco.ReadOnly = True
        Me.f_banco.Width = 53
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
        Me.f_emiss.HeaderText = "EMISSAO"
        Me.f_emiss.MaxInputLength = 10
        Me.f_emiss.Name = "f_emiss"
        Me.f_emiss.ReadOnly = True
        Me.f_emiss.Width = 90
        '
        'f_vencto
        '
        Me.f_vencto.HeaderText = "VENCTO"
        Me.f_vencto.MaxInputLength = 10
        Me.f_vencto.Name = "f_vencto"
        Me.f_vencto.ReadOnly = True
        Me.f_vencto.Width = 90
        '
        'f_valor
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.f_valor.DefaultCellStyle = DataGridViewCellStyle6
        Me.f_valor.HeaderText = "VALOR R$"
        Me.f_valor.Name = "f_valor"
        Me.f_valor.ReadOnly = True
        '
        'f_juros
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.f_juros.DefaultCellStyle = DataGridViewCellStyle7
        Me.f_juros.HeaderText = "JUROS"
        Me.f_juros.Name = "f_juros"
        Me.f_juros.ReadOnly = True
        '
        'DIAS
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DIAS.DefaultCellStyle = DataGridViewCellStyle8
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
        'Frm_Dup_ManDuplicatas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 533)
        Me.Controls.Add(Me.dtg_documentos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_Dup_ManDuplicatas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção de Duplicatas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_documentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Msk_inicio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents msk_fim As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_outros As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_totais As System.Windows.Forms.TextBox
    Friend WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtg_documentos As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_loja As System.Windows.Forms.ComboBox
    Friend WithEvents btn_pagamento As System.Windows.Forms.Button
    Friend WithEvents pagar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents f_geno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_portad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_sit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_duplic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_emiss As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_vencto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_juros As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_dtpaga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_baixaMarcados As System.Windows.Forms.Button
    Friend WithEvents txt_somaMarcados As System.Windows.Forms.TextBox
End Class
