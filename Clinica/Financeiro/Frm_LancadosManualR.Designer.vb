<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LancadosManualR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_LancadosManualR))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtp_final = New System.Windows.Forms.DateTimePicker()
        Me.dtp_inicial = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbo_tipoPag = New System.Windows.Forms.ComboBox()
        Me.grb_totais = New System.Windows.Forms.GroupBox()
        Me.txt_totais = New System.Windows.Forms.TextBox()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_Relatorio = New System.Windows.Forms.Button()
        Me.txt_codPart = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_nomePart = New System.Windows.Forms.TextBox()
        Me.grb_periodo = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_doutores = New System.Windows.Forms.ComboBox()
        Me.btn_pesquisa = New System.Windows.Forms.Button()
        Me.dtg_caixamov = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.emissao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cocli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nomecli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.doutor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbo_tpAtendimento = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grb_totais.SuspendLayout()
        Me.grb_periodo.SuspendLayout()
        CType(Me.dtg_caixamov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(391, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(768, 486)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 19)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Atualizar [F5]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "    "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-6, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(949, 42)
        Me.Panel1.TabIndex = 28
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 469)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(745, 43)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'dtp_final
        '
        Me.dtp_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_final.Location = New System.Drawing.Point(139, 20)
        Me.dtp_final.Name = "dtp_final"
        Me.dtp_final.Size = New System.Drawing.Size(99, 21)
        Me.dtp_final.TabIndex = 11
        '
        'dtp_inicial
        '
        Me.dtp_inicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_inicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_inicial.Location = New System.Drawing.Point(13, 20)
        Me.dtp_inicial.Name = "dtp_inicial"
        Me.dtp_inicial.Size = New System.Drawing.Size(99, 21)
        Me.dtp_inicial.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cbo_tpAtendimento)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cbo_tipoPag)
        Me.GroupBox1.Controls.Add(Me.grb_totais)
        Me.GroupBox1.Controls.Add(Me.cbo_tipo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btn_Relatorio)
        Me.GroupBox1.Controls.Add(Me.txt_codPart)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_nomePart)
        Me.GroupBox1.Controls.Add(Me.grb_periodo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbo_doutores)
        Me.GroupBox1.Controls.Add(Me.btn_pesquisa)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(912, 123)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        '
        'cbo_tipoPag
        '
        Me.cbo_tipoPag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipoPag.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_tipoPag.FormattingEnabled = True
        Me.cbo_tipoPag.Items.AddRange(New Object() {"", "DN", "CT", "CH"})
        Me.cbo_tipoPag.Location = New System.Drawing.Point(442, 87)
        Me.cbo_tipoPag.Name = "cbo_tipoPag"
        Me.cbo_tipoPag.Size = New System.Drawing.Size(60, 23)
        Me.cbo_tipoPag.TabIndex = 22
        '
        'grb_totais
        '
        Me.grb_totais.Controls.Add(Me.txt_totais)
        Me.grb_totais.Location = New System.Drawing.Point(779, 12)
        Me.grb_totais.Name = "grb_totais"
        Me.grb_totais.Size = New System.Drawing.Size(123, 40)
        Me.grb_totais.TabIndex = 21
        Me.grb_totais.TabStop = False
        Me.grb_totais.Text = "Total:"
        '
        'txt_totais
        '
        Me.txt_totais.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totais.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totais.ForeColor = System.Drawing.Color.Red
        Me.txt_totais.Location = New System.Drawing.Point(36, 13)
        Me.txt_totais.MaxLength = 14
        Me.txt_totais.Name = "txt_totais"
        Me.txt_totais.ReadOnly = True
        Me.txt_totais.Size = New System.Drawing.Size(80, 23)
        Me.txt_totais.TabIndex = 0
        Me.txt_totais.Text = "0,00"
        Me.txt_totais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"", "Pagamento", "Recebimento", "Abertura", "Saldo Final do Dia", "Divisoria"})
        Me.cbo_tipo.Location = New System.Drawing.Point(256, 33)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(172, 23)
        Me.cbo_tipo.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(253, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Tipo:"
        '
        'btn_Relatorio
        '
        Me.btn_Relatorio.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_Relatorio.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_Relatorio.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_Relatorio.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_Relatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Relatorio.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btn_Relatorio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_Relatorio.Image = CType(resources.GetObject("btn_Relatorio.Image"), System.Drawing.Image)
        Me.btn_Relatorio.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btn_Relatorio.Location = New System.Drawing.Point(779, 69)
        Me.btn_Relatorio.Name = "btn_Relatorio"
        Me.btn_Relatorio.Size = New System.Drawing.Size(123, 43)
        Me.btn_Relatorio.TabIndex = 18
        Me.btn_Relatorio.Text = "&Impr. [F6]"
        Me.btn_Relatorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Relatorio.UseVisualStyleBackColor = False
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Location = New System.Drawing.Point(15, 90)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(70, 20)
        Me.txt_codPart.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.45!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(439, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 15)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Tp. Pag :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.45!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Cliente :"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomePart.Location = New System.Drawing.Point(91, 90)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(334, 20)
        Me.txt_nomePart.TabIndex = 17
        '
        'grb_periodo
        '
        Me.grb_periodo.BackColor = System.Drawing.Color.Transparent
        Me.grb_periodo.Controls.Add(Me.dtp_inicial)
        Me.grb_periodo.Controls.Add(Me.Label2)
        Me.grb_periodo.Controls.Add(Me.dtp_final)
        Me.grb_periodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grb_periodo.Location = New System.Drawing.Point(519, 66)
        Me.grb_periodo.Name = "grb_periodo"
        Me.grb_periodo.Size = New System.Drawing.Size(247, 47)
        Me.grb_periodo.TabIndex = 14
        Me.grb_periodo.TabStop = False
        Me.grb_periodo.Text = "Periodo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(118, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "A"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Dentista:"
        '
        'cbo_doutores
        '
        Me.cbo_doutores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_doutores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_doutores.FormattingEnabled = True
        Me.cbo_doutores.Location = New System.Drawing.Point(15, 33)
        Me.cbo_doutores.Name = "cbo_doutores"
        Me.cbo_doutores.Size = New System.Drawing.Size(219, 23)
        Me.cbo_doutores.TabIndex = 12
        '
        'btn_pesquisa
        '
        Me.btn_pesquisa.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_pesquisa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_pesquisa.Image = Global.RTecSys.My.Resources.Resources.Busca_16x161
        Me.btn_pesquisa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_pesquisa.Location = New System.Drawing.Point(676, 13)
        Me.btn_pesquisa.Name = "btn_pesquisa"
        Me.btn_pesquisa.Size = New System.Drawing.Size(90, 43)
        Me.btn_pesquisa.TabIndex = 6
        Me.btn_pesquisa.Text = "&Pesquisar"
        Me.btn_pesquisa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_pesquisa.UseVisualStyleBackColor = True
        '
        'dtg_caixamov
        '
        Me.dtg_caixamov.AllowUserToAddRows = False
        Me.dtg_caixamov.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_caixamov.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_caixamov.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_caixamov.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_caixamov.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_caixamov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_caixamov.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.tipo, Me.emissao, Me.descricao, Me.valor, Me.cocli, Me.nomecli, Me.doutor, Me.status, Me.usuario})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_caixamov.DefaultCellStyle = DataGridViewCellStyle7
        Me.dtg_caixamov.Location = New System.Drawing.Point(12, 178)
        Me.dtg_caixamov.Name = "dtg_caixamov"
        Me.dtg_caixamov.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_caixamov.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_caixamov.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dtg_caixamov.Size = New System.Drawing.Size(912, 285)
        Me.dtg_caixamov.TabIndex = 24
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'tipo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.tipo.DefaultCellStyle = DataGridViewCellStyle3
        Me.tipo.HeaderText = "Tipo"
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.Width = 50
        '
        'emissao
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.emissao.DefaultCellStyle = DataGridViewCellStyle4
        Me.emissao.HeaderText = "Emissao"
        Me.emissao.Name = "emissao"
        Me.emissao.ReadOnly = True
        Me.emissao.Width = 90
        '
        'descricao
        '
        Me.descricao.HeaderText = "Descrição"
        Me.descricao.Name = "descricao"
        Me.descricao.ReadOnly = True
        Me.descricao.Width = 320
        '
        'valor
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.MediumBlue
        Me.valor.DefaultCellStyle = DataGridViewCellStyle5
        Me.valor.HeaderText = "Valor"
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
        '
        'cocli
        '
        Me.cocli.HeaderText = "codcli"
        Me.cocli.Name = "cocli"
        Me.cocli.ReadOnly = True
        Me.cocli.Visible = False
        '
        'nomecli
        '
        Me.nomecli.HeaderText = "Cliente"
        Me.nomecli.Name = "nomecli"
        Me.nomecli.ReadOnly = True
        Me.nomecli.Width = 240
        '
        'doutor
        '
        Me.doutor.HeaderText = "Dentista"
        Me.doutor.Name = "doutor"
        Me.doutor.ReadOnly = True
        Me.doutor.Width = 150
        '
        'status
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.status.DefaultCellStyle = DataGridViewCellStyle6
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Width = 60
        '
        'usuario
        '
        Me.usuario.HeaderText = "Usuario"
        Me.usuario.Name = "usuario"
        Me.usuario.ReadOnly = True
        '
        'cbo_tpAtendimento
        '
        Me.cbo_tpAtendimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tpAtendimento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbo_tpAtendimento.FormattingEnabled = True
        Me.cbo_tpAtendimento.Location = New System.Drawing.Point(473, 34)
        Me.cbo_tpAtendimento.Name = "cbo_tpAtendimento"
        Me.cbo_tpAtendimento.Size = New System.Drawing.Size(179, 23)
        Me.cbo_tpAtendimento.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(470, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 15)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Atendimento:"
        '
        'Frm_LancadosManualR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 520)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtg_caixamov)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_LancadosManualR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatório dos Lançamentos Manuais"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grb_totais.ResumeLayout(False)
        Me.grb_totais.PerformLayout()
        Me.grb_periodo.ResumeLayout(False)
        Me.grb_periodo.PerformLayout()
        CType(Me.dtg_caixamov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_inicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_pesquisa As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtg_caixamov As System.Windows.Forms.DataGridView
    Friend WithEvents grb_periodo As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_doutores As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Relatorio As System.Windows.Forms.Button
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents emissao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cocli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nomecli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents doutor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grb_totais As System.Windows.Forms.GroupBox
    Friend WithEvents txt_totais As System.Windows.Forms.TextBox
    Friend WithEvents cbo_tipoPag As System.Windows.Forms.ComboBox
    Public WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_tpAtendimento As System.Windows.Forms.ComboBox
    Public WithEvents Label12 As System.Windows.Forms.Label
End Class
