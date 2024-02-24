<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManCaixaDiario
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManCaixaDiario))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtg_caixamov = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_totMarcados = New System.Windows.Forms.TextBox()
        Me.btn_convertOrca = New System.Windows.Forms.Button()
        Me.btn_orcamento = New System.Windows.Forms.Button()
        Me.btn_divisoria = New System.Windows.Forms.Button()
        Me.btn_fechamento = New System.Windows.Forms.Button()
        Me.btn_deletar = New System.Windows.Forms.Button()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.btn_lancar = New System.Windows.Forms.Button()
        Me.dtp_final = New System.Windows.Forms.DateTimePicker()
        Me.dtp_inicial = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_pesquisa = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chk_lanca_orca = New System.Windows.Forms.CheckBox()
        Me.chk_orcamento = New System.Windows.Forms.CheckBox()
        Me.txt_qtde = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chk_marcarTodos = New System.Windows.Forms.CheckBox()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.cbo_dentistas = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.marcar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.emissao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dentista_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.orcamento = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.paciente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtg_caixamov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
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
        Me.dtg_caixamov.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.marcar, Me.tipo, Me.emissao, Me.descricao, Me.valor, Me.dentista_, Me.usuario, Me.status, Me.orcamento, Me.paciente})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_caixamov.DefaultCellStyle = DataGridViewCellStyle7
        Me.dtg_caixamov.Location = New System.Drawing.Point(12, 139)
        Me.dtg_caixamov.Name = "dtg_caixamov"
        Me.dtg_caixamov.ReadOnly = True
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_caixamov.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_caixamov.Size = New System.Drawing.Size(889, 346)
        Me.dtg_caixamov.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_totMarcados)
        Me.GroupBox1.Controls.Add(Me.btn_convertOrca)
        Me.GroupBox1.Controls.Add(Me.btn_orcamento)
        Me.GroupBox1.Controls.Add(Me.btn_divisoria)
        Me.GroupBox1.Controls.Add(Me.btn_fechamento)
        Me.GroupBox1.Controls.Add(Me.btn_deletar)
        Me.GroupBox1.Controls.Add(Me.btn_editar)
        Me.GroupBox1.Controls.Add(Me.btn_lancar)
        Me.GroupBox1.Location = New System.Drawing.Point(915, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(145, 353)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txt_totMarcados
        '
        Me.txt_totMarcados.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totMarcados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totMarcados.ForeColor = System.Drawing.Color.Red
        Me.txt_totMarcados.Location = New System.Drawing.Point(31, 327)
        Me.txt_totMarcados.MaxLength = 20
        Me.txt_totMarcados.Name = "txt_totMarcados"
        Me.txt_totMarcados.ReadOnly = True
        Me.txt_totMarcados.Size = New System.Drawing.Size(84, 20)
        Me.txt_totMarcados.TabIndex = 13
        Me.txt_totMarcados.Text = "0,00"
        Me.txt_totMarcados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_convertOrca
        '
        Me.btn_convertOrca.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_convertOrca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_convertOrca.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_convertOrca.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_convertOrca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_convertOrca.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn_convertOrca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_convertOrca.Image = Global.RTecSys.My.Resources.Resources.converter
        Me.btn_convertOrca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_convertOrca.Location = New System.Drawing.Point(11, 224)
        Me.btn_convertOrca.Name = "btn_convertOrca"
        Me.btn_convertOrca.Size = New System.Drawing.Size(123, 37)
        Me.btn_convertOrca.TabIndex = 12
        Me.btn_convertOrca.Text = "Convrt. Orça"
        Me.btn_convertOrca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_convertOrca.UseVisualStyleBackColor = False
        '
        'btn_orcamento
        '
        Me.btn_orcamento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_orcamento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_orcamento.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_orcamento.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_orcamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_orcamento.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_orcamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_orcamento.Image = CType(resources.GetObject("btn_orcamento.Image"), System.Drawing.Image)
        Me.btn_orcamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_orcamento.Location = New System.Drawing.Point(11, 183)
        Me.btn_orcamento.Name = "btn_orcamento"
        Me.btn_orcamento.Size = New System.Drawing.Size(123, 36)
        Me.btn_orcamento.TabIndex = 12
        Me.btn_orcamento.Text = "Orçamento"
        Me.btn_orcamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_orcamento.UseVisualStyleBackColor = False
        '
        'btn_divisoria
        '
        Me.btn_divisoria.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_divisoria.Enabled = False
        Me.btn_divisoria.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_divisoria.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_divisoria.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_divisoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_divisoria.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_divisoria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_divisoria.Image = CType(resources.GetObject("btn_divisoria.Image"), System.Drawing.Image)
        Me.btn_divisoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_divisoria.Location = New System.Drawing.Point(11, 141)
        Me.btn_divisoria.Name = "btn_divisoria"
        Me.btn_divisoria.Size = New System.Drawing.Size(123, 36)
        Me.btn_divisoria.TabIndex = 12
        Me.btn_divisoria.Text = "Divisória"
        Me.btn_divisoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_divisoria.UseVisualStyleBackColor = False
        '
        'btn_fechamento
        '
        Me.btn_fechamento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_fechamento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_fechamento.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_fechamento.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_fechamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_fechamento.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn_fechamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_fechamento.Image = Global.RTecSys.My.Resources.Resources.disc_r
        Me.btn_fechamento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_fechamento.Location = New System.Drawing.Point(11, 267)
        Me.btn_fechamento.Name = "btn_fechamento"
        Me.btn_fechamento.Size = New System.Drawing.Size(123, 54)
        Me.btn_fechamento.TabIndex = 7
        Me.btn_fechamento.Text = "Abert. &Fecha."
        Me.btn_fechamento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_fechamento.UseVisualStyleBackColor = False
        '
        'btn_deletar
        '
        Me.btn_deletar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_deletar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_deletar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_deletar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_deletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_deletar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_deletar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_deletar.Image = Global.RTecSys.My.Resources.Resources.Delete
        Me.btn_deletar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_deletar.Location = New System.Drawing.Point(11, 99)
        Me.btn_deletar.Name = "btn_deletar"
        Me.btn_deletar.Size = New System.Drawing.Size(123, 36)
        Me.btn_deletar.TabIndex = 1
        Me.btn_deletar.Text = "&Deletar"
        Me.btn_deletar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_deletar.UseVisualStyleBackColor = False
        '
        'btn_editar
        '
        Me.btn_editar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_editar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_editar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_editar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_editar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_editar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_editar.Image = Global.RTecSys.My.Resources.Resources.editar
        Me.btn_editar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_editar.Location = New System.Drawing.Point(11, 57)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(123, 36)
        Me.btn_editar.TabIndex = 0
        Me.btn_editar.Text = "&Editar"
        Me.btn_editar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_editar.UseVisualStyleBackColor = False
        '
        'btn_lancar
        '
        Me.btn_lancar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_lancar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_lancar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_lancar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_lancar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_lancar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_lancar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_lancar.Image = Global.RTecSys.My.Resources.Resources.Add
        Me.btn_lancar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_lancar.Location = New System.Drawing.Point(11, 15)
        Me.btn_lancar.Name = "btn_lancar"
        Me.btn_lancar.Size = New System.Drawing.Size(123, 36)
        Me.btn_lancar.TabIndex = 0
        Me.btn_lancar.Text = "&Lancar"
        Me.btn_lancar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_lancar.UseVisualStyleBackColor = False
        '
        'dtp_final
        '
        Me.dtp_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_final.Location = New System.Drawing.Point(260, 52)
        Me.dtp_final.Name = "dtp_final"
        Me.dtp_final.Size = New System.Drawing.Size(102, 23)
        Me.dtp_final.TabIndex = 11
        '
        'dtp_inicial
        '
        Me.dtp_inicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_inicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_inicial.Location = New System.Drawing.Point(131, 52)
        Me.dtp_inicial.Name = "dtp_inicial"
        Me.dtp_inicial.Size = New System.Drawing.Size(102, 23)
        Me.dtp_inicial.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(73, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Período"
        '
        'btn_pesquisa
        '
        Me.btn_pesquisa.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_pesquisa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_pesquisa.Image = Global.RTecSys.My.Resources.Resources.Busca_16x16
        Me.btn_pesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_pesquisa.Location = New System.Drawing.Point(796, 24)
        Me.btn_pesquisa.Name = "btn_pesquisa"
        Me.btn_pesquisa.Size = New System.Drawing.Size(83, 39)
        Me.btn_pesquisa.TabIndex = 6
        Me.btn_pesquisa.Text = "&Pesq."
        Me.btn_pesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pesquisa.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(239, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "A"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 493)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(796, 43)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(825, 508)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 19)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Atualizar [F5]"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-2, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1085, 42)
        Me.Panel1.TabIndex = 23
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(454, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(935, 508)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 19)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Deletar [Del]"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.txt_qtde)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.chk_marcarTodos)
        Me.GroupBox3.Controls.Add(Me.txt_total)
        Me.GroupBox3.Controls.Add(Me.cbo_tipo)
        Me.GroupBox3.Controls.Add(Me.cbo_dentistas)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.dtp_final)
        Me.GroupBox3.Controls.Add(Me.btn_pesquisa)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.dtp_inicial)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 44)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1048, 82)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.chk_lanca_orca)
        Me.GroupBox4.Controls.Add(Me.chk_orcamento)
        Me.GroupBox4.Location = New System.Drawing.Point(590, 9)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(182, 65)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        '
        'chk_lanca_orca
        '
        Me.chk_lanca_orca.AutoSize = True
        Me.chk_lanca_orca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_lanca_orca.Location = New System.Drawing.Point(16, 40)
        Me.chk_lanca_orca.Name = "chk_lanca_orca"
        Me.chk_lanca_orca.Size = New System.Drawing.Size(158, 19)
        Me.chk_lanca_orca.TabIndex = 1
        Me.chk_lanca_orca.Text = "Orça+Lançamentos?"
        Me.chk_lanca_orca.UseVisualStyleBackColor = True
        '
        'chk_orcamento
        '
        Me.chk_orcamento.AutoSize = True
        Me.chk_orcamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_orcamento.Location = New System.Drawing.Point(16, 14)
        Me.chk_orcamento.Name = "chk_orcamento"
        Me.chk_orcamento.Size = New System.Drawing.Size(104, 19)
        Me.chk_orcamento.TabIndex = 0
        Me.chk_orcamento.Text = "Orçamento?"
        Me.chk_orcamento.UseVisualStyleBackColor = True
        '
        'txt_qtde
        '
        Me.txt_qtde.BackColor = System.Drawing.Color.Gainsboro
        Me.txt_qtde.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_qtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtde.ForeColor = System.Drawing.Color.Red
        Me.txt_qtde.Location = New System.Drawing.Point(953, 59)
        Me.txt_qtde.MaxLength = 10
        Me.txt_qtde.Name = "txt_qtde"
        Me.txt_qtde.ReadOnly = True
        Me.txt_qtde.Size = New System.Drawing.Size(84, 17)
        Me.txt_qtde.TabIndex = 18
        Me.txt_qtde.Text = "0"
        Me.txt_qtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkRed
        Me.Label10.Location = New System.Drawing.Point(909, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Qtde:"
        '
        'chk_marcarTodos
        '
        Me.chk_marcarTodos.AutoSize = True
        Me.chk_marcarTodos.BackColor = System.Drawing.SystemColors.Control
        Me.chk_marcarTodos.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_marcarTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_marcarTodos.ForeColor = System.Drawing.Color.Green
        Me.chk_marcarTodos.Location = New System.Drawing.Point(12, 40)
        Me.chk_marcarTodos.Name = "chk_marcarTodos"
        Me.chk_marcarTodos.Size = New System.Drawing.Size(54, 25)
        Me.chk_marcarTodos.TabIndex = 16
        Me.chk_marcarTodos.Text = "All"
        Me.chk_marcarTodos.UseVisualStyleBackColor = False
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.Info
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.DarkBlue
        Me.txt_total.Location = New System.Drawing.Point(930, 29)
        Me.txt_total.MaxLength = 20
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(107, 24)
        Me.txt_total.TabIndex = 15
        Me.txt_total.Text = "0,00"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"", "Recebimento", "Pagamento", "Divisoria", "Abertura", "Saldo do Dia"})
        Me.cbo_tipo.Location = New System.Drawing.Point(412, 16)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(159, 23)
        Me.cbo_tipo.TabIndex = 14
        '
        'cbo_dentistas
        '
        Me.cbo_dentistas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_dentistas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_dentistas.FormattingEnabled = True
        Me.cbo_dentistas.Location = New System.Drawing.Point(141, 16)
        Me.cbo_dentistas.Name = "cbo_dentistas"
        Me.cbo_dentistas.Size = New System.Drawing.Size(202, 23)
        Me.cbo_dentistas.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.Location = New System.Drawing.Point(961, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 15)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Total:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(367, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Tipo:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 15)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Todos:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(71, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Dentista:"
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'marcar
        '
        Me.marcar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.marcar.HeaderText = "  [X]"
        Me.marcar.Name = "marcar"
        Me.marcar.ReadOnly = True
        Me.marcar.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.marcar.Width = 42
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
        Me.emissao.HeaderText = "Data"
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
        'dentista_
        '
        Me.dentista_.HeaderText = "Dentista"
        Me.dentista_.Name = "dentista_"
        Me.dentista_.ReadOnly = True
        Me.dentista_.Width = 160
        '
        'usuario
        '
        Me.usuario.HeaderText = "Usuario"
        Me.usuario.Name = "usuario"
        Me.usuario.ReadOnly = True
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
        'orcamento
        '
        Me.orcamento.HeaderText = "Orca."
        Me.orcamento.Name = "orcamento"
        Me.orcamento.ReadOnly = True
        Me.orcamento.Visible = False
        '
        'paciente
        '
        Me.paciente.HeaderText = "Paciente"
        Me.paciente.Name = "paciente"
        Me.paciente.ReadOnly = True
        Me.paciente.Width = 250
        '
        'Frm_ManCaixaDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1071, 545)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtg_caixamov)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ManCaixaDiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção em Movimentação de Caixa"
        CType(Me.dtg_caixamov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_caixamov As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_deletar As System.Windows.Forms.Button
    Friend WithEvents btn_lancar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_pesquisa As System.Windows.Forms.Button
    Friend WithEvents btn_fechamento As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_inicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_editar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents btn_divisoria As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_dentistas As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chk_marcarTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_totMarcados As System.Windows.Forms.TextBox
    Friend WithEvents txt_qtde As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_orcamento As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_lanca_orca As System.Windows.Forms.CheckBox
    Friend WithEvents chk_orcamento As System.Windows.Forms.CheckBox
    Friend WithEvents btn_convertOrca As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents marcar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents emissao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dentista_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents orcamento As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents paciente As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
