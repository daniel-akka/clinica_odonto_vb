﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManPagamentos
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManPagamentos))
        Me.dtg_documentos = New System.Windows.Forms.DataGridView()
        Me.pagar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.f_geno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_portad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_sit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_duplic = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_emiss = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_vencto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_juros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataPagamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.historico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_documento = New System.Windows.Forms.TextBox()
        Me.txt_totais = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.msk_fim = New System.Windows.Forms.DateTimePicker()
        Me.Msk_inicio = New System.Windows.Forms.DateTimePicker()
        Me.txt_portador = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_loja = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_outros = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_somaMarcados = New System.Windows.Forms.TextBox()
        Me.btn_baixaMarcados = New System.Windows.Forms.Button()
        Me.btn_pagamento = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_LblNormal = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_normal = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        CType(Me.dtg_documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_documentos
        '
        Me.dtg_documentos.AllowUserToAddRows = False
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_documentos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.dtg_documentos.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_documentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_documentos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_documentos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_documentos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dtg_documentos.ColumnHeadersHeight = 25
        Me.dtg_documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_documentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pagar, Me.f_geno, Me.p_portad, Me.f_tipo, Me.f_sit, Me.f_banco, Me.f_duplic, Me.f_emiss, Me.f_vencto, Me.f_valor, Me.f_juros, Me.DIAS, Me.dataPagamento, Me.id, Me.historico})
        Me.dtg_documentos.Location = New System.Drawing.Point(15, 161)
        Me.dtg_documentos.MultiSelect = False
        Me.dtg_documentos.Name = "dtg_documentos"
        Me.dtg_documentos.ReadOnly = True
        Me.dtg_documentos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_documentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_documentos.RowsDefaultCellStyle = DataGridViewCellStyle26
        Me.dtg_documentos.Size = New System.Drawing.Size(919, 301)
        Me.dtg_documentos.TabIndex = 25
        '
        'pagar
        '
        Me.pagar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pagar.HeaderText = "PAG."
        Me.pagar.Name = "pagar"
        Me.pagar.ReadOnly = True
        Me.pagar.Width = 40
        '
        'f_geno
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_geno.DefaultCellStyle = DataGridViewCellStyle16
        Me.f_geno.HeaderText = "LOJA"
        Me.f_geno.MaxInputLength = 8
        Me.f_geno.Name = "f_geno"
        Me.f_geno.ReadOnly = True
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
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_tipo.DefaultCellStyle = DataGridViewCellStyle17
        Me.f_tipo.HeaderText = "TIPO"
        Me.f_tipo.Name = "f_tipo"
        Me.f_tipo.ReadOnly = True
        Me.f_tipo.Width = 50
        '
        'f_sit
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_sit.DefaultCellStyle = DataGridViewCellStyle18
        Me.f_sit.HeaderText = "SIT"
        Me.f_sit.Name = "f_sit"
        Me.f_sit.ReadOnly = True
        Me.f_sit.Width = 40
        '
        'f_banco
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_banco.DefaultCellStyle = DataGridViewCellStyle19
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
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_emiss.DefaultCellStyle = DataGridViewCellStyle20
        Me.f_emiss.HeaderText = "EMISSAO"
        Me.f_emiss.Name = "f_emiss"
        Me.f_emiss.ReadOnly = True
        Me.f_emiss.Width = 90
        '
        'f_vencto
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_vencto.DefaultCellStyle = DataGridViewCellStyle21
        Me.f_vencto.HeaderText = "VENCTO"
        Me.f_vencto.Name = "f_vencto"
        Me.f_vencto.ReadOnly = True
        Me.f_vencto.Width = 90
        '
        'f_valor
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.f_valor.DefaultCellStyle = DataGridViewCellStyle22
        Me.f_valor.HeaderText = "VALOR R$"
        Me.f_valor.Name = "f_valor"
        Me.f_valor.ReadOnly = True
        '
        'f_juros
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.f_juros.DefaultCellStyle = DataGridViewCellStyle23
        Me.f_juros.HeaderText = "JUROS"
        Me.f_juros.Name = "f_juros"
        Me.f_juros.ReadOnly = True
        '
        'DIAS
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DIAS.DefaultCellStyle = DataGridViewCellStyle24
        Me.DIAS.HeaderText = "DIAS"
        Me.DIAS.Name = "DIAS"
        Me.DIAS.ReadOnly = True
        Me.DIAS.Width = 70
        '
        'dataPagamento
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dataPagamento.DefaultCellStyle = DataGridViewCellStyle25
        Me.dataPagamento.HeaderText = "Data PAG"
        Me.dataPagamento.Name = "dataPagamento"
        Me.dataPagamento.ReadOnly = True
        Me.dataPagamento.Width = 85
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
        Me.historico.HeaderText = "Historico"
        Me.historico.Name = "historico"
        Me.historico.ReadOnly = True
        Me.historico.Width = 200
        '
        'txt_documento
        '
        Me.txt_documento.Location = New System.Drawing.Point(643, 16)
        Me.txt_documento.MaxLength = 9
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.Size = New System.Drawing.Size(100, 21)
        Me.txt_documento.TabIndex = 5
        Me.txt_documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_totais
        '
        Me.txt_totais.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totais.Enabled = False
        Me.txt_totais.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totais.ForeColor = System.Drawing.Color.Red
        Me.txt_totais.Location = New System.Drawing.Point(6, 21)
        Me.txt_totais.MaxLength = 16
        Me.txt_totais.Name = "txt_totais"
        Me.txt_totais.ReadOnly = True
        Me.txt_totais.Size = New System.Drawing.Size(112, 23)
        Me.txt_totais.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(563, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Documento:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_totais)
        Me.GroupBox4.Location = New System.Drawing.Point(893, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(124, 54)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Totais R$"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"Vencidas", "Liquidada", "Devolvidas", "Estornadas", "Em Aberto", "Documento"})
        Me.cbo_tipo.Location = New System.Drawing.Point(416, 16)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(126, 23)
        Me.cbo_tipo.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(376, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Tipo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Periodo:"
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = Global.RTecSys.My.Resources.Resources.Busca_16x16
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.Location = New System.Drawing.Point(762, 18)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(76, 48)
        Me.btn_buscar.TabIndex = 6
        Me.btn_buscar.Text = "&Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Loja:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.msk_fim)
        Me.GroupBox3.Controls.Add(Me.Msk_inicio)
        Me.GroupBox3.Controls.Add(Me.txt_portador)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txt_documento)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.btn_buscar)
        Me.GroupBox3.Controls.Add(Me.cbo_tipo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.cbo_loja)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(15, 75)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1025, 73)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        '
        'msk_fim
        '
        Me.msk_fim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.msk_fim.Location = New System.Drawing.Point(175, 47)
        Me.msk_fim.Name = "msk_fim"
        Me.msk_fim.Size = New System.Drawing.Size(84, 21)
        Me.msk_fim.TabIndex = 17
        '
        'Msk_inicio
        '
        Me.Msk_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Msk_inicio.Location = New System.Drawing.Point(65, 47)
        Me.Msk_inicio.Name = "Msk_inicio"
        Me.Msk_inicio.Size = New System.Drawing.Size(84, 21)
        Me.Msk_inicio.TabIndex = 17
        '
        'txt_portador
        '
        Me.txt_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_portador.Location = New System.Drawing.Point(383, 47)
        Me.txt_portador.MaxLength = 100
        Me.txt_portador.Name = "txt_portador"
        Me.txt_portador.Size = New System.Drawing.Size(360, 21)
        Me.txt_portador.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(320, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Portador:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(155, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "A"
        '
        'cbo_loja
        '
        Me.cbo_loja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_loja.FormattingEnabled = True
        Me.cbo_loja.Location = New System.Drawing.Point(65, 16)
        Me.cbo_loja.Name = "cbo_loja"
        Me.cbo_loja.Size = New System.Drawing.Size(265, 23)
        Me.cbo_loja.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 469)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1025, 42)
        Me.GroupBox1.TabIndex = 23
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
        Me.lbl_mensagem.Size = New System.Drawing.Size(19, 15)
        Me.lbl_mensagem.TabIndex = 13
        Me.lbl_mensagem.Text = "   "
        '
        'btn_incluir
        '
        Me.btn_incluir.BackColor = System.Drawing.SystemColors.Control
        Me.btn_incluir.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btn_incluir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_incluir.Image = Global.RTecSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.Location = New System.Drawing.Point(8, 13)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(83, 49)
        Me.btn_incluir.TabIndex = 9
        Me.btn_incluir.Text = "Incluir"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.BackColor = System.Drawing.SystemColors.Control
        Me.btn_alterar.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btn_alterar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_alterar.Image = Global.RTecSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(8, 68)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(83, 48)
        Me.btn_alterar.TabIndex = 10
        Me.btn_alterar.Text = "Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_outros
        '
        Me.btn_outros.BackColor = System.Drawing.SystemColors.Control
        Me.btn_outros.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btn_outros.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_outros.Image = Global.RTecSys.My.Resources.Resources.OutrasOpcoes
        Me.btn_outros.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_outros.Location = New System.Drawing.Point(8, 122)
        Me.btn_outros.Name = "btn_outros"
        Me.btn_outros.Size = New System.Drawing.Size(83, 41)
        Me.btn_outros.TabIndex = 11
        Me.btn_outros.Text = "Outros"
        Me.btn_outros.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_outros.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_somaMarcados)
        Me.GroupBox2.Controls.Add(Me.btn_incluir)
        Me.GroupBox2.Controls.Add(Me.btn_baixaMarcados)
        Me.GroupBox2.Controls.Add(Me.btn_alterar)
        Me.GroupBox2.Controls.Add(Me.btn_pagamento)
        Me.GroupBox2.Controls.Add(Me.btn_outros)
        Me.GroupBox2.Location = New System.Drawing.Point(941, 154)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(99, 310)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        '
        'txt_somaMarcados
        '
        Me.txt_somaMarcados.BackColor = System.Drawing.SystemColors.Info
        Me.txt_somaMarcados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_somaMarcados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_somaMarcados.ForeColor = System.Drawing.Color.Blue
        Me.txt_somaMarcados.Location = New System.Drawing.Point(8, 284)
        Me.txt_somaMarcados.MaxLength = 14
        Me.txt_somaMarcados.Name = "txt_somaMarcados"
        Me.txt_somaMarcados.Size = New System.Drawing.Size(83, 20)
        Me.txt_somaMarcados.TabIndex = 39
        Me.txt_somaMarcados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_baixaMarcados
        '
        Me.btn_baixaMarcados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_baixaMarcados.Image = CType(resources.GetObject("btn_baixaMarcados.Image"), System.Drawing.Image)
        Me.btn_baixaMarcados.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_baixaMarcados.Location = New System.Drawing.Point(8, 219)
        Me.btn_baixaMarcados.Name = "btn_baixaMarcados"
        Me.btn_baixaMarcados.Size = New System.Drawing.Size(83, 59)
        Me.btn_baixaMarcados.TabIndex = 37
        Me.btn_baixaMarcados.Text = "Baixa. Total Marcados"
        Me.btn_baixaMarcados.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_baixaMarcados.UseVisualStyleBackColor = True
        '
        'btn_pagamento
        '
        Me.btn_pagamento.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btn_pagamento.Image = CType(resources.GetObject("btn_pagamento.Image"), System.Drawing.Image)
        Me.btn_pagamento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_pagamento.Location = New System.Drawing.Point(8, 169)
        Me.btn_pagamento.Name = "btn_pagamento"
        Me.btn_pagamento.Size = New System.Drawing.Size(83, 44)
        Me.btn_pagamento.TabIndex = 38
        Me.btn_pagamento.Text = "Pagamento"
        Me.btn_pagamento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_pagamento.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(874, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(166, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Atualizar [F5]    Deletar[Del]"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Red
        Me.Button4.Enabled = False
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(525, 60)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(17, 14)
        Me.Button4.TabIndex = 31
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.MediumOrchid
        Me.Button3.Enabled = False
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(400, 60)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(17, 14)
        Me.Button3.TabIndex = 32
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MediumBlue
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(138, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(17, 14)
        Me.Button1.TabIndex = 33
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Green
        Me.Button2.Enabled = False
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(272, 60)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(17, 14)
        Me.Button2.TabIndex = 34
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btn_LblNormal
        '
        Me.btn_LblNormal.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_LblNormal.Enabled = False
        Me.btn_LblNormal.FlatAppearance.BorderSize = 0
        Me.btn_LblNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_LblNormal.Location = New System.Drawing.Point(18, 60)
        Me.btn_LblNormal.Name = "btn_LblNormal"
        Me.btn_LblNormal.Size = New System.Drawing.Size(17, 14)
        Me.btn_LblNormal.TabIndex = 35
        Me.btn_LblNormal.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(543, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 19)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "- Vencida"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.MediumOrchid
        Me.Label9.Location = New System.Drawing.Point(418, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 19)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "- Estornada"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Green
        Me.Label8.Location = New System.Drawing.Point(290, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 19)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "- Devolvida"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label7.Location = New System.Drawing.Point(156, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 19)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "- Liquidada"
        '
        'lbl_normal
        '
        Me.lbl_normal.AutoSize = True
        Me.lbl_normal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_normal.Location = New System.Drawing.Point(36, 57)
        Me.lbl_normal.Name = "lbl_normal"
        Me.lbl_normal.Size = New System.Drawing.Size(68, 19)
        Me.lbl_normal.TabIndex = 30
        Me.lbl_normal.Text = "- Normal"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(652, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(191, 19)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "- Menos de 6 dias a Vencer"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Maroon
        Me.Button5.Enabled = False
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.ForeColor = System.Drawing.Color.Maroon
        Me.Button5.Location = New System.Drawing.Point(634, 60)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(17, 14)
        Me.Button5.TabIndex = 31
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-4, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1065, 42)
        Me.Panel1.TabIndex = 55
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(424, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Frm_ManPagamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1052, 520)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_LblNormal)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbl_normal)
        Me.Controls.Add(Me.dtg_documentos)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ManPagamentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção de Duplicatas a Pagar"
        CType(Me.dtg_documentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_documentos As System.Windows.Forms.DataGridView
    Friend WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents txt_totais As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_loja As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_outros As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_portador As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_LblNormal As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_normal As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents msk_fim As System.Windows.Forms.DateTimePicker
    Friend WithEvents Msk_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_somaMarcados As System.Windows.Forms.TextBox
    Friend WithEvents btn_baixaMarcados As System.Windows.Forms.Button
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
    Friend WithEvents dataPagamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents historico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
End Class
