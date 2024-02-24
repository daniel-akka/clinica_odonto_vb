<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ControleMensal
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ControleMensal))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.tbc_CMensal = New System.Windows.Forms.TabControl()
        Me.tbp_visualizar = New System.Windows.Forms.TabPage()
        Me.grb_principal = New System.Windows.Forms.GroupBox()
        Me.dtp_mes = New System.Windows.Forms.DateTimePicker()
        Me.btn_Editar = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chk_recusaAtend = New System.Windows.Forms.CheckBox()
        Me.cbo_tipoAtend1 = New System.Windows.Forms.ComboBox()
        Me.dtg_controleMensal = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bruto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.despesas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.liquido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cartao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dentista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoatendimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_empresa1 = New System.Windows.Forms.ComboBox()
        Me.tbp_manutencao = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_empresa2 = New System.Windows.Forms.ComboBox()
        Me.txt_vlrLiquido = New System.Windows.Forms.TextBox()
        Me.txt_vlrDespesas = New System.Windows.Forms.TextBox()
        Me.txt_vlrBruto = New System.Windows.Forms.TextBox()
        Me.cbo_tipoAtend2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp_data = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.pdRelatorio = New System.Drawing.Printing.PrintDocument()
        Me.Panel1.SuspendLayout()
        Me.tbc_CMensal.SuspendLayout()
        Me.tbp_visualizar.SuspendLayout()
        Me.grb_principal.SuspendLayout()
        CType(Me.dtg_controleMensal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbp_manutencao.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-4, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(719, 42)
        Me.Panel1.TabIndex = 56
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(274, 4)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'tbc_CMensal
        '
        Me.tbc_CMensal.Controls.Add(Me.tbp_visualizar)
        Me.tbc_CMensal.Controls.Add(Me.tbp_manutencao)
        Me.tbc_CMensal.Location = New System.Drawing.Point(12, 46)
        Me.tbc_CMensal.Name = "tbc_CMensal"
        Me.tbc_CMensal.SelectedIndex = 0
        Me.tbc_CMensal.Size = New System.Drawing.Size(676, 411)
        Me.tbc_CMensal.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tbc_CMensal.TabIndex = 57
        '
        'tbp_visualizar
        '
        Me.tbp_visualizar.Controls.Add(Me.grb_principal)
        Me.tbp_visualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbp_visualizar.Location = New System.Drawing.Point(4, 25)
        Me.tbp_visualizar.Name = "tbp_visualizar"
        Me.tbp_visualizar.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_visualizar.Size = New System.Drawing.Size(668, 382)
        Me.tbp_visualizar.TabIndex = 0
        Me.tbp_visualizar.Text = "Visualizar"
        Me.tbp_visualizar.UseVisualStyleBackColor = True
        '
        'grb_principal
        '
        Me.grb_principal.Controls.Add(Me.dtp_mes)
        Me.grb_principal.Controls.Add(Me.btn_Editar)
        Me.grb_principal.Controls.Add(Me.Label15)
        Me.grb_principal.Controls.Add(Me.Label2)
        Me.grb_principal.Controls.Add(Me.chk_recusaAtend)
        Me.grb_principal.Controls.Add(Me.cbo_tipoAtend1)
        Me.grb_principal.Controls.Add(Me.dtg_controleMensal)
        Me.grb_principal.Controls.Add(Me.Label3)
        Me.grb_principal.Controls.Add(Me.Label1)
        Me.grb_principal.Controls.Add(Me.cbo_empresa1)
        Me.grb_principal.Location = New System.Drawing.Point(8, 1)
        Me.grb_principal.Name = "grb_principal"
        Me.grb_principal.Size = New System.Drawing.Size(653, 373)
        Me.grb_principal.TabIndex = 16
        Me.grb_principal.TabStop = False
        '
        'dtp_mes
        '
        Me.dtp_mes.CustomFormat = "MM/yyyy"
        Me.dtp_mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_mes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_mes.Location = New System.Drawing.Point(540, 90)
        Me.dtp_mes.Name = "dtp_mes"
        Me.dtp_mes.Size = New System.Drawing.Size(104, 29)
        Me.dtp_mes.TabIndex = 9
        '
        'btn_Editar
        '
        Me.btn_Editar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_Editar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_Editar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_Editar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Editar.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btn_Editar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_Editar.Image = Global.RTecSys.My.Resources.Resources.editar
        Me.btn_Editar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btn_Editar.Location = New System.Drawing.Point(529, 14)
        Me.btn_Editar.Name = "btn_Editar"
        Me.btn_Editar.Size = New System.Drawing.Size(115, 32)
        Me.btn_Editar.TabIndex = 32
        Me.btn_Editar.Text = "&Editar [F3]"
        Me.btn_Editar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Editar.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(11, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(435, 19)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Atualizar [F5]       Editar [F3]       Relatório [F6]       Deletar[Del]"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(496, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Mês:"
        '
        'chk_recusaAtend
        '
        Me.chk_recusaAtend.AutoSize = True
        Me.chk_recusaAtend.Location = New System.Drawing.Point(330, 97)
        Me.chk_recusaAtend.Name = "chk_recusaAtend"
        Me.chk_recusaAtend.Size = New System.Drawing.Size(125, 21)
        Me.chk_recusaAtend.TabIndex = 28
        Me.chk_recusaAtend.Text = "Recusar Atend."
        Me.chk_recusaAtend.UseVisualStyleBackColor = True
        '
        'cbo_tipoAtend1
        '
        Me.cbo_tipoAtend1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipoAtend1.FormattingEnabled = True
        Me.cbo_tipoAtend1.Location = New System.Drawing.Point(92, 95)
        Me.cbo_tipoAtend1.Name = "cbo_tipoAtend1"
        Me.cbo_tipoAtend1.Size = New System.Drawing.Size(214, 24)
        Me.cbo_tipoAtend1.TabIndex = 27
        '
        'dtg_controleMensal
        '
        Me.dtg_controleMensal.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_controleMensal.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_controleMensal.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_controleMensal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_controleMensal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_controleMensal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_controleMensal.ColumnHeadersHeight = 28
        Me.dtg_controleMensal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_controleMensal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.dia, Me.bruto, Me.despesas, Me.liquido, Me.cartao, Me.dentista, Me.tipoatendimento})
        Me.dtg_controleMensal.Location = New System.Drawing.Point(15, 129)
        Me.dtg_controleMensal.MultiSelect = False
        Me.dtg_controleMensal.Name = "dtg_controleMensal"
        Me.dtg_controleMensal.ReadOnly = True
        Me.dtg_controleMensal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_controleMensal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_controleMensal.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dtg_controleMensal.Size = New System.Drawing.Size(629, 236)
        Me.dtg_controleMensal.TabIndex = 26
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'dia
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dia.DefaultCellStyle = DataGridViewCellStyle2
        Me.dia.HeaderText = "Dia"
        Me.dia.MaxInputLength = 6
        Me.dia.Name = "dia"
        Me.dia.ReadOnly = True
        Me.dia.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dia.Width = 50
        '
        'bruto
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.bruto.DefaultCellStyle = DataGridViewCellStyle3
        Me.bruto.HeaderText = "Bruto"
        Me.bruto.MaxInputLength = 80
        Me.bruto.Name = "bruto"
        Me.bruto.ReadOnly = True
        Me.bruto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.bruto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'despesas
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.despesas.DefaultCellStyle = DataGridViewCellStyle4
        Me.despesas.HeaderText = "Despesas"
        Me.despesas.MaxInputLength = 14
        Me.despesas.Name = "despesas"
        Me.despesas.ReadOnly = True
        Me.despesas.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.despesas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'liquido
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.liquido.DefaultCellStyle = DataGridViewCellStyle5
        Me.liquido.HeaderText = "Líquido"
        Me.liquido.MaxInputLength = 7
        Me.liquido.MinimumWidth = 2
        Me.liquido.Name = "liquido"
        Me.liquido.ReadOnly = True
        Me.liquido.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.liquido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cartao
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.cartao.DefaultCellStyle = DataGridViewCellStyle6
        Me.cartao.HeaderText = "Cartão"
        Me.cartao.Name = "cartao"
        Me.cartao.ReadOnly = True
        Me.cartao.Visible = False
        '
        'dentista
        '
        Me.dentista.HeaderText = "Dentista"
        Me.dentista.Name = "dentista"
        Me.dentista.ReadOnly = True
        Me.dentista.Visible = False
        Me.dentista.Width = 190
        '
        'tipoatendimento
        '
        Me.tipoatendimento.HeaderText = "Tipo Atend."
        Me.tipoatendimento.Name = "tipoatendimento"
        Me.tipoatendimento.ReadOnly = True
        Me.tipoatendimento.Width = 215
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tp Atend.:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Empr.:"
        '
        'cbo_empresa1
        '
        Me.cbo_empresa1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_empresa1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_empresa1.FormattingEnabled = True
        Me.cbo_empresa1.Location = New System.Drawing.Point(92, 54)
        Me.cbo_empresa1.Name = "cbo_empresa1"
        Me.cbo_empresa1.Size = New System.Drawing.Size(325, 24)
        Me.cbo_empresa1.TabIndex = 1
        '
        'tbp_manutencao
        '
        Me.tbp_manutencao.Controls.Add(Me.GroupBox3)
        Me.tbp_manutencao.Controls.Add(Me.Label11)
        Me.tbp_manutencao.Controls.Add(Me.GroupBox2)
        Me.tbp_manutencao.Controls.Add(Me.Label7)
        Me.tbp_manutencao.Controls.Add(Me.cbo_empresa2)
        Me.tbp_manutencao.Controls.Add(Me.txt_vlrLiquido)
        Me.tbp_manutencao.Controls.Add(Me.txt_vlrDespesas)
        Me.tbp_manutencao.Controls.Add(Me.txt_vlrBruto)
        Me.tbp_manutencao.Controls.Add(Me.cbo_tipoAtend2)
        Me.tbp_manutencao.Controls.Add(Me.Label5)
        Me.tbp_manutencao.Controls.Add(Me.Label8)
        Me.tbp_manutencao.Controls.Add(Me.Label9)
        Me.tbp_manutencao.Controls.Add(Me.dtp_data)
        Me.tbp_manutencao.Controls.Add(Me.Label6)
        Me.tbp_manutencao.Controls.Add(Me.Label4)
        Me.tbp_manutencao.Controls.Add(Me.Label12)
        Me.tbp_manutencao.Location = New System.Drawing.Point(4, 25)
        Me.tbp_manutencao.Name = "tbp_manutencao"
        Me.tbp_manutencao.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_manutencao.Size = New System.Drawing.Size(668, 382)
        Me.tbp_manutencao.TabIndex = 1
        Me.tbp_manutencao.Text = "Manutenção"
        Me.tbp_manutencao.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_alterar)
        Me.GroupBox3.Controls.Add(Me.btn_incluir)
        Me.GroupBox3.Location = New System.Drawing.Point(421, 228)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(209, 65)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
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
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(107, 15)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(94, 42)
        Me.btn_alterar.TabIndex = 1
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = False
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
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_incluir.Location = New System.Drawing.Point(7, 15)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(94, 42)
        Me.btn_incluir.TabIndex = 0
        Me.btn_incluir.Text = "&Inclui"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_incluir.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label11.Location = New System.Drawing.Point(167, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(298, 29)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "***  Controle Mensal  ***"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(38, 296)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(592, 53)
        Me.GroupBox2.TabIndex = 55
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(12, 24)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = "    "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 17)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Empresa:"
        '
        'cbo_empresa2
        '
        Me.cbo_empresa2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_empresa2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_empresa2.FormattingEnabled = True
        Me.cbo_empresa2.Location = New System.Drawing.Point(126, 78)
        Me.cbo_empresa2.Name = "cbo_empresa2"
        Me.cbo_empresa2.Size = New System.Drawing.Size(344, 24)
        Me.cbo_empresa2.TabIndex = 1
        '
        'txt_vlrLiquido
        '
        Me.txt_vlrLiquido.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vlrLiquido.Location = New System.Drawing.Point(425, 182)
        Me.txt_vlrLiquido.MaxLength = 16
        Me.txt_vlrLiquido.Name = "txt_vlrLiquido"
        Me.txt_vlrLiquido.Size = New System.Drawing.Size(98, 24)
        Me.txt_vlrLiquido.TabIndex = 11
        Me.txt_vlrLiquido.Text = "0,00"
        Me.txt_vlrLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_vlrDespesas
        '
        Me.txt_vlrDespesas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vlrDespesas.Location = New System.Drawing.Point(297, 182)
        Me.txt_vlrDespesas.MaxLength = 16
        Me.txt_vlrDespesas.Name = "txt_vlrDespesas"
        Me.txt_vlrDespesas.Size = New System.Drawing.Size(98, 24)
        Me.txt_vlrDespesas.TabIndex = 9
        Me.txt_vlrDespesas.Text = "0,00"
        Me.txt_vlrDespesas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_vlrBruto
        '
        Me.txt_vlrBruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vlrBruto.Location = New System.Drawing.Point(177, 182)
        Me.txt_vlrBruto.MaxLength = 16
        Me.txt_vlrBruto.Name = "txt_vlrBruto"
        Me.txt_vlrBruto.Size = New System.Drawing.Size(98, 24)
        Me.txt_vlrBruto.TabIndex = 7
        Me.txt_vlrBruto.Text = "0,00"
        Me.txt_vlrBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbo_tipoAtend2
        '
        Me.cbo_tipoAtend2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipoAtend2.FormattingEnabled = True
        Me.cbo_tipoAtend2.Location = New System.Drawing.Point(126, 117)
        Me.cbo_tipoAtend2.Name = "cbo_tipoAtend2"
        Me.cbo_tipoAtend2.Size = New System.Drawing.Size(216, 24)
        Me.cbo_tipoAtend2.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 17)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Tipo Atend.:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(294, 162)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Vlr. Despesas:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(422, 162)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 17)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Vlr. Líquido:"
        '
        'dtp_data
        '
        Me.dtp_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_data.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_data.Location = New System.Drawing.Point(38, 182)
        Me.dtp_data.Name = "dtp_data"
        Me.dtp_data.Size = New System.Drawing.Size(110, 24)
        Me.dtp_data.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(174, 162)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Vlr. Bruto:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Data:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label12.Location = New System.Drawing.Point(-6, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(685, 29)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "________________________________________________"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Frm_ControleMensal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 466)
        Me.Controls.Add(Me.tbc_CMensal)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Frm_ControleMensal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Controle Mensal R$"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tbc_CMensal.ResumeLayout(False)
        Me.tbp_visualizar.ResumeLayout(False)
        Me.grb_principal.ResumeLayout(False)
        Me.grb_principal.PerformLayout()
        CType(Me.dtg_controleMensal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbp_manutencao.ResumeLayout(False)
        Me.tbp_manutencao.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents tbc_CMensal As System.Windows.Forms.TabControl
    Friend WithEvents tbp_visualizar As System.Windows.Forms.TabPage
    Friend WithEvents tbp_manutencao As System.Windows.Forms.TabPage
    Friend WithEvents cbo_empresa1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grb_principal As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_mes As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtg_controleMensal As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_tipoAtend1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_data As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chk_recusaAtend As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_tipoAtend2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_vlrBruto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_empresa2 As System.Windows.Forms.ComboBox
    Friend WithEvents txt_vlrLiquido As System.Windows.Forms.TextBox
    Friend WithEvents txt_vlrDespesas As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents pdRelatorio As System.Drawing.Printing.PrintDocument
    Friend WithEvents btn_Editar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bruto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents despesas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents liquido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cartao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dentista As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipoatendimento As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
