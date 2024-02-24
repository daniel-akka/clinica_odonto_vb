<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManAgendamentos
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManAgendamentos))
        Me.dtg_documentos = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_portad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_emiss = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_vencto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.historico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cancelado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.financeiro = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Info = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Turno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_LblNormal = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_normal = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_loja = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_lancarFinanceiro = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_imprime = New System.Windows.Forms.Button()
        Me.btn_relatorio = New System.Windows.Forms.Button()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_confirmar = New System.Windows.Forms.Button()
        Me.grb_opcoes = New System.Windows.Forms.GroupBox()
        Me.cbo_turno = New System.Windows.Forms.ComboBox()
        Me.cbo_dentistas = New System.Windows.Forms.ComboBox()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.msk_fim = New System.Windows.Forms.DateTimePicker()
        Me.Msk_inicio = New System.Windows.Forms.DateTimePicker()
        Me.txt_portador = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.grb_qtde = New System.Windows.Forms.GroupBox()
        Me.txt_qtdRegistros = New System.Windows.Forms.TextBox()
        CType(Me.dtg_documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grb_opcoes.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grb_qtde.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_documentos
        '
        Me.dtg_documentos.AllowUserToAddRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_documentos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dtg_documentos.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_documentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_documentos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_documentos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_documentos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dtg_documentos.ColumnHeadersHeight = 25
        Me.dtg_documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_documentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.pagar, Me.ficha, Me.codCliente, Me.p_portad, Me.f_emiss, Me.f_vencto, Me.f_valor, Me.historico, Me.cancelado, Me.financeiro, Me.Info, Me.Turno})
        Me.dtg_documentos.Location = New System.Drawing.Point(11, 155)
        Me.dtg_documentos.MultiSelect = False
        Me.dtg_documentos.Name = "dtg_documentos"
        Me.dtg_documentos.ReadOnly = True
        Me.dtg_documentos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_documentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_documentos.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.dtg_documentos.Size = New System.Drawing.Size(856, 301)
        Me.dtg_documentos.TabIndex = 28
        '
        'id
        '
        Me.id.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.id.HeaderText = "ST"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.id.Width = 40
        '
        'pagar
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.pagar.DefaultCellStyle = DataGridViewCellStyle11
        Me.pagar.HeaderText = "ID"
        Me.pagar.MaxInputLength = 15
        Me.pagar.Name = "pagar"
        Me.pagar.ReadOnly = True
        Me.pagar.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pagar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pagar.Visible = False
        Me.pagar.Width = 70
        '
        'ficha
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ficha.DefaultCellStyle = DataGridViewCellStyle12
        Me.ficha.HeaderText = "FICHA"
        Me.ficha.MaxInputLength = 25
        Me.ficha.Name = "ficha"
        Me.ficha.ReadOnly = True
        Me.ficha.Width = 80
        '
        'codCliente
        '
        Me.codCliente.HeaderText = "codCli"
        Me.codCliente.Name = "codCliente"
        Me.codCliente.ReadOnly = True
        Me.codCliente.Visible = False
        '
        'p_portad
        '
        Me.p_portad.HeaderText = "PACIENTE"
        Me.p_portad.Name = "p_portad"
        Me.p_portad.ReadOnly = True
        Me.p_portad.Width = 270
        '
        'f_emiss
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_emiss.DefaultCellStyle = DataGridViewCellStyle13
        Me.f_emiss.HeaderText = "EMISSAO"
        Me.f_emiss.MaxInputLength = 10
        Me.f_emiss.Name = "f_emiss"
        Me.f_emiss.ReadOnly = True
        Me.f_emiss.Width = 90
        '
        'f_vencto
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_vencto.DefaultCellStyle = DataGridViewCellStyle14
        Me.f_vencto.HeaderText = "AGEND."
        Me.f_vencto.MaxInputLength = 10
        Me.f_vencto.Name = "f_vencto"
        Me.f_vencto.ReadOnly = True
        Me.f_vencto.Width = 90
        '
        'f_valor
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.f_valor.DefaultCellStyle = DataGridViewCellStyle15
        Me.f_valor.HeaderText = "VALOR R$"
        Me.f_valor.Name = "f_valor"
        Me.f_valor.ReadOnly = True
        Me.f_valor.Visible = False
        '
        'historico
        '
        Me.historico.HeaderText = "Dentista"
        Me.historico.Name = "historico"
        Me.historico.ReadOnly = True
        Me.historico.Width = 170
        '
        'cancelado
        '
        Me.cancelado.HeaderText = "Canceldo"
        Me.cancelado.Name = "cancelado"
        Me.cancelado.ReadOnly = True
        Me.cancelado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cancelado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cancelado.Visible = False
        '
        'financeiro
        '
        Me.financeiro.HeaderText = "Financeiro"
        Me.financeiro.Name = "financeiro"
        Me.financeiro.ReadOnly = True
        Me.financeiro.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.financeiro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.financeiro.Visible = False
        '
        'Info
        '
        Me.Info.HeaderText = "Info:"
        Me.Info.Name = "Info"
        Me.Info.ReadOnly = True
        Me.Info.Width = 150
        '
        'Turno
        '
        Me.Turno.HeaderText = "Turno"
        Me.Turno.Name = "Turno"
        Me.Turno.ReadOnly = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MediumBlue
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(155, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(17, 14)
        Me.Button1.TabIndex = 35
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btn_LblNormal
        '
        Me.btn_LblNormal.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_LblNormal.Enabled = False
        Me.btn_LblNormal.FlatAppearance.BorderSize = 0
        Me.btn_LblNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_LblNormal.Location = New System.Drawing.Point(27, 55)
        Me.btn_LblNormal.Name = "btn_LblNormal"
        Me.btn_LblNormal.Size = New System.Drawing.Size(17, 14)
        Me.btn_LblNormal.TabIndex = 37
        Me.btn_LblNormal.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Green
        Me.Label10.Location = New System.Drawing.Point(299, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(162, 19)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "- Agendamento do DIA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label7.Location = New System.Drawing.Point(173, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 19)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "- Realizado"
        '
        'lbl_normal
        '
        Me.lbl_normal.AutoSize = True
        Me.lbl_normal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_normal.Location = New System.Drawing.Point(45, 52)
        Me.lbl_normal.Name = "lbl_normal"
        Me.lbl_normal.Size = New System.Drawing.Size(89, 19)
        Me.lbl_normal.TabIndex = 33
        Me.lbl_normal.Text = "- Em Aberto"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(721, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(291, 13)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Atualizar [F5]       Imprime [F6]       Relatorio [F11]"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Loja:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(158, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "A"
        '
        'cbo_loja
        '
        Me.cbo_loja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_loja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_loja.FormattingEnabled = True
        Me.cbo_loja.Items.AddRange(New Object() {"01", "02", "03", "04"})
        Me.cbo_loja.Location = New System.Drawing.Point(65, 16)
        Me.cbo_loja.Name = "cbo_loja"
        Me.cbo_loja.Size = New System.Drawing.Size(283, 23)
        Me.cbo_loja.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 463)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1061, 53)
        Me.GroupBox1.TabIndex = 26
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
        Me.GroupBox2.Controls.Add(Me.btn_lancarFinanceiro)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.btn_imprime)
        Me.GroupBox2.Controls.Add(Me.btn_relatorio)
        Me.GroupBox2.Controls.Add(Me.btn_incluir)
        Me.GroupBox2.Controls.Add(Me.btn_alterar)
        Me.GroupBox2.Controls.Add(Me.btn_confirmar)
        Me.GroupBox2.Location = New System.Drawing.Point(873, 148)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(199, 266)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        '
        'btn_lancarFinanceiro
        '
        Me.btn_lancarFinanceiro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_lancarFinanceiro.Enabled = False
        Me.btn_lancarFinanceiro.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_lancarFinanceiro.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_lancarFinanceiro.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_lancarFinanceiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_lancarFinanceiro.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_lancarFinanceiro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_lancarFinanceiro.Image = CType(resources.GetObject("btn_lancarFinanceiro.Image"), System.Drawing.Image)
        Me.btn_lancarFinanceiro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_lancarFinanceiro.Location = New System.Drawing.Point(18, 133)
        Me.btn_lancarFinanceiro.Name = "btn_lancarFinanceiro"
        Me.btn_lancarFinanceiro.Size = New System.Drawing.Size(162, 66)
        Me.btn_lancarFinanceiro.TabIndex = 15
        Me.btn_lancarFinanceiro.Text = "&Lançar no &Financeiro"
        Me.btn_lancarFinanceiro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_lancarFinanceiro.UseVisualStyleBackColor = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_cancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Strikeout), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_cancelar.Image = Global.RTecSys.My.Resources.Resources.cancelar
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(102, 74)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(92, 53)
        Me.btn_cancelar.TabIndex = 14
        Me.btn_cancelar.Text = "&Cancelar!"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_imprime
        '
        Me.btn_imprime.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_imprime.Enabled = False
        Me.btn_imprime.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_imprime.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_imprime.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_imprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_imprime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_imprime.Image = Global.RTecSys.My.Resources.Resources.Imprime
        Me.btn_imprime.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprime.Location = New System.Drawing.Point(6, 205)
        Me.btn_imprime.Name = "btn_imprime"
        Me.btn_imprime.Size = New System.Drawing.Size(92, 53)
        Me.btn_imprime.TabIndex = 13
        Me.btn_imprime.Text = "&Imprime"
        Me.btn_imprime.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprime.UseVisualStyleBackColor = False
        '
        'btn_relatorio
        '
        Me.btn_relatorio.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_relatorio.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_relatorio.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_relatorio.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_relatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_relatorio.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_relatorio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_relatorio.Image = Global.RTecSys.My.Resources.Resources.Imprime
        Me.btn_relatorio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_relatorio.Location = New System.Drawing.Point(102, 205)
        Me.btn_relatorio.Name = "btn_relatorio"
        Me.btn_relatorio.Size = New System.Drawing.Size(92, 53)
        Me.btn_relatorio.TabIndex = 13
        Me.btn_relatorio.Text = "&Relatório"
        Me.btn_relatorio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_relatorio.UseVisualStyleBackColor = False
        '
        'btn_incluir
        '
        Me.btn_incluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_incluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_incluir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_incluir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_incluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_incluir.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_incluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_incluir.Image = Global.RTecSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.Location = New System.Drawing.Point(6, 15)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(92, 53)
        Me.btn_incluir.TabIndex = 9
        Me.btn_incluir.Text = "Incluir"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_incluir.UseVisualStyleBackColor = False
        '
        'btn_alterar
        '
        Me.btn_alterar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_alterar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_alterar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_alterar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_alterar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_alterar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_alterar.Image = Global.RTecSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(102, 15)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(92, 53)
        Me.btn_alterar.TabIndex = 10
        Me.btn_alterar.Text = "Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = False
        '
        'btn_confirmar
        '
        Me.btn_confirmar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_confirmar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_confirmar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_confirmar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_confirmar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_confirmar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_confirmar.Image = Global.RTecSys.My.Resources.Resources.ok_16x16
        Me.btn_confirmar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_confirmar.Location = New System.Drawing.Point(6, 74)
        Me.btn_confirmar.Name = "btn_confirmar"
        Me.btn_confirmar.Size = New System.Drawing.Size(92, 53)
        Me.btn_confirmar.TabIndex = 11
        Me.btn_confirmar.Text = "Confirmar!"
        Me.btn_confirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_confirmar.UseVisualStyleBackColor = False
        '
        'grb_opcoes
        '
        Me.grb_opcoes.Controls.Add(Me.cbo_turno)
        Me.grb_opcoes.Controls.Add(Me.cbo_dentistas)
        Me.grb_opcoes.Controls.Add(Me.cbo_tipo)
        Me.grb_opcoes.Controls.Add(Me.Label9)
        Me.grb_opcoes.Controls.Add(Me.Label6)
        Me.grb_opcoes.Controls.Add(Me.Label4)
        Me.grb_opcoes.Controls.Add(Me.msk_fim)
        Me.grb_opcoes.Controls.Add(Me.Msk_inicio)
        Me.grb_opcoes.Controls.Add(Me.txt_portador)
        Me.grb_opcoes.Controls.Add(Me.Label5)
        Me.grb_opcoes.Controls.Add(Me.btn_buscar)
        Me.grb_opcoes.Controls.Add(Me.Label2)
        Me.grb_opcoes.Controls.Add(Me.Label1)
        Me.grb_opcoes.Controls.Add(Me.Label3)
        Me.grb_opcoes.Controls.Add(Me.cbo_loja)
        Me.grb_opcoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grb_opcoes.Location = New System.Drawing.Point(11, 71)
        Me.grb_opcoes.Name = "grb_opcoes"
        Me.grb_opcoes.Size = New System.Drawing.Size(1061, 76)
        Me.grb_opcoes.TabIndex = 24
        Me.grb_opcoes.TabStop = False
        '
        'cbo_turno
        '
        Me.cbo_turno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_turno.FormattingEnabled = True
        Me.cbo_turno.Items.AddRange(New Object() {"< Nenhum >", "Manhã", "Tarde", "Noite"})
        Me.cbo_turno.Location = New System.Drawing.Point(762, 45)
        Me.cbo_turno.Name = "cbo_turno"
        Me.cbo_turno.Size = New System.Drawing.Size(140, 23)
        Me.cbo_turno.TabIndex = 20
        '
        'cbo_dentistas
        '
        Me.cbo_dentistas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_dentistas.FormattingEnabled = True
        Me.cbo_dentistas.Location = New System.Drawing.Point(654, 18)
        Me.cbo_dentistas.Name = "cbo_dentistas"
        Me.cbo_dentistas.Size = New System.Drawing.Size(248, 23)
        Me.cbo_dentistas.TabIndex = 19
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"Em Aberto", "Realizadas", "Vencidas", "Documento"})
        Me.cbo_tipo.Location = New System.Drawing.Point(420, 18)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(142, 23)
        Me.cbo_tipo.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(714, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 15)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Turno:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(593, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 15)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Dentista:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(380, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 15)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Tipo:"
        '
        'msk_fim
        '
        Me.msk_fim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.msk_fim.Location = New System.Drawing.Point(178, 47)
        Me.msk_fim.Name = "msk_fim"
        Me.msk_fim.Size = New System.Drawing.Size(87, 21)
        Me.msk_fim.TabIndex = 16
        '
        'Msk_inicio
        '
        Me.Msk_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Msk_inicio.Location = New System.Drawing.Point(65, 47)
        Me.Msk_inicio.Name = "Msk_inicio"
        Me.Msk_inicio.Size = New System.Drawing.Size(87, 21)
        Me.Msk_inicio.TabIndex = 16
        '
        'txt_portador
        '
        Me.txt_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_portador.Location = New System.Drawing.Point(371, 47)
        Me.txt_portador.MaxLength = 100
        Me.txt_portador.Name = "txt_portador"
        Me.txt_portador.Size = New System.Drawing.Size(310, 21)
        Me.txt_portador.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(308, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Paciente:"
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = Global.RTecSys.My.Resources.Resources.Busca_16x16
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.Location = New System.Drawing.Point(977, 16)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(78, 46)
        Me.btn_buscar.TabIndex = 6
        Me.btn_buscar.Text = "&Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Green
        Me.Button4.Enabled = False
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(281, 55)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(17, 14)
        Me.Button4.TabIndex = 38
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Red
        Me.Button2.Enabled = False
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(490, 55)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(17, 14)
        Me.Button2.TabIndex = 38
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(508, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 19)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "- Vencido"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-5, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1097, 42)
        Me.Panel1.TabIndex = 76
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(480, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'grb_qtde
        '
        Me.grb_qtde.Controls.Add(Me.txt_qtdRegistros)
        Me.grb_qtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grb_qtde.Location = New System.Drawing.Point(873, 414)
        Me.grb_qtde.Name = "grb_qtde"
        Me.grb_qtde.Size = New System.Drawing.Size(199, 43)
        Me.grb_qtde.TabIndex = 77
        Me.grb_qtde.TabStop = False
        Me.grb_qtde.Text = "Registros:"
        '
        'txt_qtdRegistros
        '
        Me.txt_qtdRegistros.BackColor = System.Drawing.SystemColors.Control
        Me.txt_qtdRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_qtdRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtdRegistros.ForeColor = System.Drawing.Color.DarkRed
        Me.txt_qtdRegistros.Location = New System.Drawing.Point(57, 16)
        Me.txt_qtdRegistros.MaxLength = 20
        Me.txt_qtdRegistros.Name = "txt_qtdRegistros"
        Me.txt_qtdRegistros.ReadOnly = True
        Me.txt_qtdRegistros.Size = New System.Drawing.Size(100, 17)
        Me.txt_qtdRegistros.TabIndex = 0
        Me.txt_qtdRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Frm_ManAgendamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 525)
        Me.Controls.Add(Me.grb_qtde)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtg_documentos)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_LblNormal)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbl_normal)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.grb_opcoes)
        Me.Controls.Add(Me.Button4)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ManAgendamentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção de Agendamentos"
        CType(Me.dtg_documentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.grb_opcoes.ResumeLayout(False)
        Me.grb_opcoes.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grb_qtde.ResumeLayout(False)
        Me.grb_qtde.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_documentos As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_LblNormal As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_normal As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_loja As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_confirmar As System.Windows.Forms.Button
    Friend WithEvents grb_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents msk_fim As System.Windows.Forms.DateTimePicker
    Friend WithEvents Msk_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_portador As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btn_imprime As System.Windows.Forms.Button
    Friend WithEvents btn_relatorio As System.Windows.Forms.Button
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents btn_lancarFinanceiro As System.Windows.Forms.Button
    Friend WithEvents grb_qtde As System.Windows.Forms.GroupBox
    Friend WithEvents txt_qtdRegistros As System.Windows.Forms.TextBox
    Friend WithEvents id As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pagar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_portad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_emiss As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_vencto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents historico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cancelado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents financeiro As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Info As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Turno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbo_turno As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_dentistas As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
