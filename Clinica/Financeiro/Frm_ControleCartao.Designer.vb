<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ControleCartao
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_Editar = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbo_empresa2 = New System.Windows.Forms.ComboBox()
        Me.txt_vlrCartao = New System.Windows.Forms.TextBox()
        Me.tbp_visualizar = New System.Windows.Forms.TabPage()
        Me.grb_principal = New System.Windows.Forms.GroupBox()
        Me.txt_totValores = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_inicial = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_final = New System.Windows.Forms.DateTimePicker()
        Me.dtg_controleCartao = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.loja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cartao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_empresa1 = New System.Windows.Forms.ComboBox()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbc_CMensal = New System.Windows.Forms.TabControl()
        Me.tbp_manutencao = New System.Windows.Forms.TabPage()
        Me.dtp_data = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tbp_visualizar.SuspendLayout()
        Me.grb_principal.SuspendLayout()
        CType(Me.dtg_controleCartao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.tbc_CMensal.SuspendLayout()
        Me.tbp_manutencao.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_alterar)
        Me.GroupBox3.Controls.Add(Me.btn_incluir)
        Me.GroupBox3.Location = New System.Drawing.Point(257, 228)
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
        Me.btn_alterar.Location = New System.Drawing.Point(108, 15)
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
        Me.btn_incluir.Location = New System.Drawing.Point(8, 15)
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
        Me.Label11.Location = New System.Drawing.Point(91, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(291, 29)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "***  Controle Cartão  ***"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 296)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(449, 53)
        Me.GroupBox2.TabIndex = 55
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(13, 24)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = "    "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(36, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 17)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Empresa:"
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
        Me.btn_Editar.Location = New System.Drawing.Point(332, 14)
        Me.btn_Editar.Name = "btn_Editar"
        Me.btn_Editar.Size = New System.Drawing.Size(114, 32)
        Me.btn_Editar.TabIndex = 32
        Me.btn_Editar.Text = "&Editar [F3]"
        Me.btn_Editar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Editar.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(293, 19)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Atualizar [F5]     Editar [F3]    Deletar[Del]"
        '
        'cbo_empresa2
        '
        Me.cbo_empresa2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_empresa2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_empresa2.FormattingEnabled = True
        Me.cbo_empresa2.Location = New System.Drawing.Point(39, 101)
        Me.cbo_empresa2.Name = "cbo_empresa2"
        Me.cbo_empresa2.Size = New System.Drawing.Size(344, 24)
        Me.cbo_empresa2.TabIndex = 1
        '
        'txt_vlrCartao
        '
        Me.txt_vlrCartao.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vlrCartao.Location = New System.Drawing.Point(178, 166)
        Me.txt_vlrCartao.MaxLength = 16
        Me.txt_vlrCartao.Name = "txt_vlrCartao"
        Me.txt_vlrCartao.Size = New System.Drawing.Size(98, 24)
        Me.txt_vlrCartao.TabIndex = 7
        Me.txt_vlrCartao.Text = "0,00"
        Me.txt_vlrCartao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbp_visualizar
        '
        Me.tbp_visualizar.Controls.Add(Me.grb_principal)
        Me.tbp_visualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbp_visualizar.Location = New System.Drawing.Point(4, 25)
        Me.tbp_visualizar.Name = "tbp_visualizar"
        Me.tbp_visualizar.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_visualizar.Size = New System.Drawing.Size(484, 382)
        Me.tbp_visualizar.TabIndex = 0
        Me.tbp_visualizar.Text = "Visualizar"
        Me.tbp_visualizar.UseVisualStyleBackColor = True
        '
        'grb_principal
        '
        Me.grb_principal.Controls.Add(Me.txt_totValores)
        Me.grb_principal.Controls.Add(Me.Label5)
        Me.grb_principal.Controls.Add(Me.dtp_inicial)
        Me.grb_principal.Controls.Add(Me.Label3)
        Me.grb_principal.Controls.Add(Me.Label2)
        Me.grb_principal.Controls.Add(Me.btn_Editar)
        Me.grb_principal.Controls.Add(Me.dtp_final)
        Me.grb_principal.Controls.Add(Me.Label15)
        Me.grb_principal.Controls.Add(Me.dtg_controleCartao)
        Me.grb_principal.Controls.Add(Me.Label1)
        Me.grb_principal.Controls.Add(Me.cbo_empresa1)
        Me.grb_principal.Location = New System.Drawing.Point(10, 1)
        Me.grb_principal.Name = "grb_principal"
        Me.grb_principal.Size = New System.Drawing.Size(455, 373)
        Me.grb_principal.TabIndex = 16
        Me.grb_principal.TabStop = False
        '
        'txt_totValores
        '
        Me.txt_totValores.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totValores.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totValores.ForeColor = System.Drawing.Color.MediumBlue
        Me.txt_totValores.Location = New System.Drawing.Point(332, 117)
        Me.txt_totValores.MaxLength = 16
        Me.txt_totValores.Name = "txt_totValores"
        Me.txt_totValores.ReadOnly = True
        Me.txt_totValores.Size = New System.Drawing.Size(114, 26)
        Me.txt_totValores.TabIndex = 34
        Me.txt_totValores.Text = "0,00"
        Me.txt_totValores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(349, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 17)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Total:"
        '
        'dtp_inicial
        '
        Me.dtp_inicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_inicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_inicial.Location = New System.Drawing.Point(16, 118)
        Me.dtp_inicial.Name = "dtp_inicial"
        Me.dtp_inicial.Size = New System.Drawing.Size(121, 26)
        Me.dtp_inicial.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(13, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Período:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(145, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "A"
        '
        'dtp_final
        '
        Me.dtp_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_final.Location = New System.Drawing.Point(172, 118)
        Me.dtp_final.Name = "dtp_final"
        Me.dtp_final.Size = New System.Drawing.Size(118, 26)
        Me.dtp_final.TabIndex = 11
        '
        'dtg_controleCartao
        '
        Me.dtg_controleCartao.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_controleCartao.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_controleCartao.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_controleCartao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_controleCartao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_controleCartao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_controleCartao.ColumnHeadersHeight = 28
        Me.dtg_controleCartao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_controleCartao.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.loja, Me.dia, Me.cartao})
        Me.dtg_controleCartao.Location = New System.Drawing.Point(54, 150)
        Me.dtg_controleCartao.MultiSelect = False
        Me.dtg_controleCartao.Name = "dtg_controleCartao"
        Me.dtg_controleCartao.ReadOnly = True
        Me.dtg_controleCartao.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_controleCartao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_controleCartao.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_controleCartao.Size = New System.Drawing.Size(357, 213)
        Me.dtg_controleCartao.TabIndex = 26
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'loja
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loja.DefaultCellStyle = DataGridViewCellStyle2
        Me.loja.HeaderText = "Loja"
        Me.loja.Name = "loja"
        Me.loja.ReadOnly = True
        Me.loja.Width = 55
        '
        'dia
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dia.DefaultCellStyle = DataGridViewCellStyle3
        Me.dia.HeaderText = "Data"
        Me.dia.MaxInputLength = 6
        Me.dia.Name = "dia"
        Me.dia.ReadOnly = True
        Me.dia.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dia.Width = 110
        '
        'cartao
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkRed
        Me.cartao.DefaultCellStyle = DataGridViewCellStyle4
        Me.cartao.HeaderText = "Cartão"
        Me.cartao.Name = "cartao"
        Me.cartao.ReadOnly = True
        Me.cartao.Width = 130
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 58)
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
        Me.cbo_empresa1.Location = New System.Drawing.Point(69, 56)
        Me.cbo_empresa1.Name = "cbo_empresa1"
        Me.cbo_empresa1.Size = New System.Drawing.Size(325, 24)
        Me.cbo_empresa1.TabIndex = 1
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(185, 4)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-11, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(532, 42)
        Me.Panel1.TabIndex = 58
        '
        'tbc_CMensal
        '
        Me.tbc_CMensal.Controls.Add(Me.tbp_visualizar)
        Me.tbc_CMensal.Controls.Add(Me.tbp_manutencao)
        Me.tbc_CMensal.Location = New System.Drawing.Point(5, 64)
        Me.tbc_CMensal.Name = "tbc_CMensal"
        Me.tbc_CMensal.SelectedIndex = 0
        Me.tbc_CMensal.Size = New System.Drawing.Size(492, 411)
        Me.tbc_CMensal.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tbc_CMensal.TabIndex = 59
        '
        'tbp_manutencao
        '
        Me.tbp_manutencao.Controls.Add(Me.GroupBox3)
        Me.tbp_manutencao.Controls.Add(Me.Label11)
        Me.tbp_manutencao.Controls.Add(Me.GroupBox2)
        Me.tbp_manutencao.Controls.Add(Me.Label7)
        Me.tbp_manutencao.Controls.Add(Me.cbo_empresa2)
        Me.tbp_manutencao.Controls.Add(Me.txt_vlrCartao)
        Me.tbp_manutencao.Controls.Add(Me.dtp_data)
        Me.tbp_manutencao.Controls.Add(Me.Label6)
        Me.tbp_manutencao.Controls.Add(Me.Label4)
        Me.tbp_manutencao.Controls.Add(Me.Label12)
        Me.tbp_manutencao.Location = New System.Drawing.Point(4, 25)
        Me.tbp_manutencao.Name = "tbp_manutencao"
        Me.tbp_manutencao.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_manutencao.Size = New System.Drawing.Size(484, 382)
        Me.tbp_manutencao.TabIndex = 1
        Me.tbp_manutencao.Text = "Manutenção"
        Me.tbp_manutencao.UseVisualStyleBackColor = True
        '
        'dtp_data
        '
        Me.dtp_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_data.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_data.Location = New System.Drawing.Point(39, 166)
        Me.dtp_data.Name = "dtp_data"
        Me.dtp_data.Size = New System.Drawing.Size(110, 24)
        Me.dtp_data.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(175, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Vlr. Cartão:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 146)
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
        Me.Label12.Location = New System.Drawing.Point(-5, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(517, 29)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "____________________________________"
        '
        'Frm_ControleCartao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 491)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tbc_CMensal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Frm_ControleCartao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Controle Cartão"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tbp_visualizar.ResumeLayout(False)
        Me.grb_principal.ResumeLayout(False)
        Me.grb_principal.PerformLayout()
        CType(Me.dtg_controleCartao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tbc_CMensal.ResumeLayout(False)
        Me.tbp_manutencao.ResumeLayout(False)
        Me.tbp_manutencao.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_Editar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbo_empresa2 As System.Windows.Forms.ComboBox
    Friend WithEvents txt_vlrCartao As System.Windows.Forms.TextBox
    Friend WithEvents tbp_visualizar As System.Windows.Forms.TabPage
    Friend WithEvents grb_principal As System.Windows.Forms.GroupBox
    Friend WithEvents dtg_controleCartao As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_empresa1 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbc_CMensal As System.Windows.Forms.TabControl
    Friend WithEvents tbp_manutencao As System.Windows.Forms.TabPage
    Friend WithEvents dtp_data As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtp_inicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents loja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cartao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_totValores As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
