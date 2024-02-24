<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ContrDivOutras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ContrDivOutras))
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_empresa2 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_vlrLiquido = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp_mes = New System.Windows.Forms.DateTimePicker()
        Me.btn_Editar = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtg_controleMensal = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dentista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.liquido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.soma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.dtp_data = New System.Windows.Forms.DateTimePicker()
        Me.pdRelatorio = New System.Drawing.Printing.PrintDocument()
        Me.cbo_empresa1 = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.tbc_CMensal = New System.Windows.Forms.TabControl()
        Me.tbp_visualizar = New System.Windows.Forms.TabPage()
        Me.grb_principal = New System.Windows.Forms.GroupBox()
        Me.txt_totLiquido = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_dentistas = New System.Windows.Forms.ComboBox()
        Me.tbp_manutencao = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_dentistaDAO = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtg_controleMensal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.tbc_CMensal.SuspendLayout()
        Me.tbp_visualizar.SuspendLayout()
        Me.grb_principal.SuspendLayout()
        Me.tbp_manutencao.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label11.Location = New System.Drawing.Point(53, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(430, 26)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "***  Controle Divisória de Dentistas  ***"
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
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(38, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 20)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Empresa:"
        '
        'cbo_empresa2
        '
        Me.cbo_empresa2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_empresa2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_empresa2.FormattingEnabled = True
        Me.cbo_empresa2.Location = New System.Drawing.Point(125, 73)
        Me.cbo_empresa2.Name = "cbo_empresa2"
        Me.cbo_empresa2.Size = New System.Drawing.Size(398, 28)
        Me.cbo_empresa2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Empr.:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(43, 296)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(480, 53)
        Me.GroupBox2.TabIndex = 55
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'txt_vlrLiquido
        '
        Me.txt_vlrLiquido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vlrLiquido.Location = New System.Drawing.Point(202, 191)
        Me.txt_vlrLiquido.MaxLength = 16
        Me.txt_vlrLiquido.Name = "txt_vlrLiquido"
        Me.txt_vlrLiquido.Size = New System.Drawing.Size(115, 26)
        Me.txt_vlrLiquido.TabIndex = 9
        Me.txt_vlrLiquido.Text = "0,00"
        Me.txt_vlrLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(199, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Vlr. Líquido:"
        '
        'dtp_mes
        '
        Me.dtp_mes.CustomFormat = "MM/yyyy"
        Me.dtp_mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_mes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_mes.Location = New System.Drawing.Point(433, 78)
        Me.dtp_mes.Name = "dtp_mes"
        Me.dtp_mes.Size = New System.Drawing.Size(113, 29)
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
        Me.btn_Editar.Location = New System.Drawing.Point(431, 36)
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
        Me.Label15.Size = New System.Drawing.Size(407, 19)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Atualizar [F5]     Editar [F3]     Relatório [F6]    Deletar[Del]"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Label2.Location = New System.Drawing.Point(386, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 18)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Mês:"
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
        Me.dtg_controleMensal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.dia, Me.dentista, Me.liquido, Me.soma})
        Me.dtg_controleMensal.Location = New System.Drawing.Point(15, 167)
        Me.dtg_controleMensal.MultiSelect = False
        Me.dtg_controleMensal.Name = "dtg_controleMensal"
        Me.dtg_controleMensal.ReadOnly = True
        Me.dtg_controleMensal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_controleMensal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_controleMensal.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_controleMensal.Size = New System.Drawing.Size(531, 200)
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
        'dentista
        '
        Me.dentista.HeaderText = "Dentista"
        Me.dentista.Name = "dentista"
        Me.dentista.ReadOnly = True
        Me.dentista.Width = 300
        '
        'liquido
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.MediumBlue
        Me.liquido.DefaultCellStyle = DataGridViewCellStyle3
        Me.liquido.HeaderText = "Líquido"
        Me.liquido.MaxInputLength = 7
        Me.liquido.MinimumWidth = 2
        Me.liquido.Name = "liquido"
        Me.liquido.ReadOnly = True
        Me.liquido.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.liquido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.liquido.Width = 120
        '
        'soma
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.MediumBlue
        Me.soma.DefaultCellStyle = DataGridViewCellStyle4
        Me.soma.HeaderText = "Soma"
        Me.soma.MaxInputLength = 14
        Me.soma.Name = "soma"
        Me.soma.ReadOnly = True
        Me.soma.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.soma.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.soma.Visible = False
        Me.soma.Width = 110
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 20)
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
        Me.Label12.Size = New System.Drawing.Size(643, 29)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "_____________________________________________"
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
        'dtp_data
        '
        Me.dtp_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_data.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_data.Location = New System.Drawing.Point(42, 191)
        Me.dtp_data.Name = "dtp_data"
        Me.dtp_data.Size = New System.Drawing.Size(119, 26)
        Me.dtp_data.TabIndex = 5
        '
        'cbo_empresa1
        '
        Me.cbo_empresa1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_empresa1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_empresa1.FormattingEnabled = True
        Me.cbo_empresa1.Location = New System.Drawing.Point(15, 63)
        Me.cbo_empresa1.Name = "cbo_empresa1"
        Me.cbo_empresa1.Size = New System.Drawing.Size(337, 24)
        Me.cbo_empresa1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-10, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(627, 42)
        Me.Panel1.TabIndex = 58
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(235, 4)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'tbc_CMensal
        '
        Me.tbc_CMensal.Controls.Add(Me.tbp_visualizar)
        Me.tbc_CMensal.Controls.Add(Me.tbp_manutencao)
        Me.tbc_CMensal.Location = New System.Drawing.Point(8, 47)
        Me.tbc_CMensal.Name = "tbc_CMensal"
        Me.tbc_CMensal.SelectedIndex = 0
        Me.tbc_CMensal.Size = New System.Drawing.Size(590, 411)
        Me.tbc_CMensal.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tbc_CMensal.TabIndex = 59
        '
        'tbp_visualizar
        '
        Me.tbp_visualizar.Controls.Add(Me.grb_principal)
        Me.tbp_visualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbp_visualizar.Location = New System.Drawing.Point(4, 25)
        Me.tbp_visualizar.Name = "tbp_visualizar"
        Me.tbp_visualizar.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_visualizar.Size = New System.Drawing.Size(582, 382)
        Me.tbp_visualizar.TabIndex = 0
        Me.tbp_visualizar.Text = "Visualizar"
        Me.tbp_visualizar.UseVisualStyleBackColor = True
        '
        'grb_principal
        '
        Me.grb_principal.Controls.Add(Me.txt_totLiquido)
        Me.grb_principal.Controls.Add(Me.Label6)
        Me.grb_principal.Controls.Add(Me.Label5)
        Me.grb_principal.Controls.Add(Me.cbo_dentistas)
        Me.grb_principal.Controls.Add(Me.dtp_mes)
        Me.grb_principal.Controls.Add(Me.btn_Editar)
        Me.grb_principal.Controls.Add(Me.Label15)
        Me.grb_principal.Controls.Add(Me.Label2)
        Me.grb_principal.Controls.Add(Me.dtg_controleMensal)
        Me.grb_principal.Controls.Add(Me.Label1)
        Me.grb_principal.Controls.Add(Me.cbo_empresa1)
        Me.grb_principal.Location = New System.Drawing.Point(9, 1)
        Me.grb_principal.Name = "grb_principal"
        Me.grb_principal.Size = New System.Drawing.Size(559, 373)
        Me.grb_principal.TabIndex = 16
        Me.grb_principal.TabStop = False
        '
        'txt_totLiquido
        '
        Me.txt_totLiquido.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totLiquido.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totLiquido.ForeColor = System.Drawing.Color.MediumBlue
        Me.txt_totLiquido.Location = New System.Drawing.Point(437, 126)
        Me.txt_totLiquido.MaxLength = 16
        Me.txt_totLiquido.Name = "txt_totLiquido"
        Me.txt_totLiquido.ReadOnly = True
        Me.txt_totLiquido.Size = New System.Drawing.Size(109, 24)
        Me.txt_totLiquido.TabIndex = 36
        Me.txt_totLiquido.Text = "0,00"
        Me.txt_totLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(342, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 18)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Tot. Líquido:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 18)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Dentista:"
        '
        'cbo_dentistas
        '
        Me.cbo_dentistas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_dentistas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_dentistas.FormattingEnabled = True
        Me.cbo_dentistas.Location = New System.Drawing.Point(15, 121)
        Me.cbo_dentistas.Name = "cbo_dentistas"
        Me.cbo_dentistas.Size = New System.Drawing.Size(284, 24)
        Me.cbo_dentistas.TabIndex = 33
        '
        'tbp_manutencao
        '
        Me.tbp_manutencao.Controls.Add(Me.Label3)
        Me.tbp_manutencao.Controls.Add(Me.cbo_dentistaDAO)
        Me.tbp_manutencao.Controls.Add(Me.GroupBox3)
        Me.tbp_manutencao.Controls.Add(Me.Label11)
        Me.tbp_manutencao.Controls.Add(Me.GroupBox2)
        Me.tbp_manutencao.Controls.Add(Me.Label7)
        Me.tbp_manutencao.Controls.Add(Me.cbo_empresa2)
        Me.tbp_manutencao.Controls.Add(Me.txt_vlrLiquido)
        Me.tbp_manutencao.Controls.Add(Me.Label9)
        Me.tbp_manutencao.Controls.Add(Me.dtp_data)
        Me.tbp_manutencao.Controls.Add(Me.Label4)
        Me.tbp_manutencao.Controls.Add(Me.Label12)
        Me.tbp_manutencao.Location = New System.Drawing.Point(4, 25)
        Me.tbp_manutencao.Name = "tbp_manutencao"
        Me.tbp_manutencao.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_manutencao.Size = New System.Drawing.Size(582, 382)
        Me.tbp_manutencao.TabIndex = 1
        Me.tbp_manutencao.Text = "Manutenção"
        Me.tbp_manutencao.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(39, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Dentista:"
        '
        'cbo_dentistaDAO
        '
        Me.cbo_dentistaDAO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_dentistaDAO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_dentistaDAO.FormattingEnabled = True
        Me.cbo_dentistaDAO.Location = New System.Drawing.Point(125, 118)
        Me.cbo_dentistaDAO.Name = "cbo_dentistaDAO"
        Me.cbo_dentistaDAO.Size = New System.Drawing.Size(284, 26)
        Me.cbo_dentistaDAO.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_alterar)
        Me.GroupBox3.Controls.Add(Me.btn_incluir)
        Me.GroupBox3.Location = New System.Drawing.Point(314, 228)
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
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Frm_ContrDivOutras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 466)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tbc_CMensal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Frm_ContrDivOutras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Controle de Divisória dos Dentistas de Outras Clínicas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtg_controleMensal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tbc_CMensal.ResumeLayout(False)
        Me.tbp_visualizar.ResumeLayout(False)
        Me.grb_principal.ResumeLayout(False)
        Me.grb_principal.PerformLayout()
        Me.tbp_manutencao.ResumeLayout(False)
        Me.tbp_manutencao.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_empresa2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_vlrLiquido As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtp_mes As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_Editar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtg_controleMensal As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents dtp_data As System.Windows.Forms.DateTimePicker
    Friend WithEvents pdRelatorio As System.Drawing.Printing.PrintDocument
    Friend WithEvents cbo_empresa1 As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents tbc_CMensal As System.Windows.Forms.TabControl
    Friend WithEvents tbp_visualizar As System.Windows.Forms.TabPage
    Friend WithEvents grb_principal As System.Windows.Forms.GroupBox
    Friend WithEvents tbp_manutencao As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_dentistas As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_dentistaDAO As System.Windows.Forms.ComboBox
    Friend WithEvents txt_totLiquido As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dentista As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents liquido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents soma As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
