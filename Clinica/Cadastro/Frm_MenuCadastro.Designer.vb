<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MenuCadastro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MenuCadastro))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_restaurar = New System.Windows.Forms.Button()
        Me.btn_relatorio = New System.Windows.Forms.Button()
        Me.btn_altera = New System.Windows.Forms.Button()
        Me.btn_inclui = New System.Windows.Forms.Button()
        Me.btn_exclui = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.grb_registros = New System.Windows.Forms.GroupBox()
        Me.lbl_registros = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.grb_periodo = New System.Windows.Forms.GroupBox()
        Me.dtp_final = New System.Windows.Forms.DateTimePicker()
        Me.dtp_inicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chk_simPeriodo = New System.Windows.Forms.CheckBox()
        Me.cbo_doutores = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grp_Tipo = New System.Windows.Forms.GroupBox()
        Me.RdbNd = New System.Windows.Forms.RadioButton()
        Me.RdBForn = New System.Windows.Forms.RadioButton()
        Me.RdBCli = New System.Windows.Forms.RadioButton()
        Me.cbo_cidade = New System.Windows.Forms.ComboBox()
        Me.lbl_cidade = New System.Windows.Forms.Label()
        Me.cbo_uf = New System.Windows.Forms.ComboBox()
        Me.lbl_uf = New System.Windows.Forms.Label()
        Me.lbl_pesquisa = New System.Windows.Forms.Label()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.grp_opcoes = New System.Windows.Forms.GroupBox()
        Me.rdb_ficha = New System.Windows.Forms.RadioButton()
        Me.rdb_nome = New System.Windows.Forms.RadioButton()
        Me.rdb_nao = New System.Windows.Forms.RadioButton()
        Me.rdb_codigo = New System.Windows.Forms.RadioButton()
        Me.rdb_cnpj_cpf = New System.Windows.Forms.RadioButton()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.chk_todos = New System.Windows.Forms.CheckBox()
        Me.dtgClientes = New System.Windows.Forms.DataGridView()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dentista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cpf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataCad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_SemCpf = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grb_registros.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grb_periodo.SuspendLayout()
        Me.grp_Tipo.SuspendLayout()
        Me.grp_opcoes.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_restaurar)
        Me.GroupBox1.Controls.Add(Me.btn_relatorio)
        Me.GroupBox1.Controls.Add(Me.btn_altera)
        Me.GroupBox1.Controls.Add(Me.btn_inclui)
        Me.GroupBox1.Controls.Add(Me.btn_exclui)
        Me.GroupBox1.Location = New System.Drawing.Point(923, 161)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(130, 290)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'btn_restaurar
        '
        Me.btn_restaurar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_restaurar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_restaurar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_restaurar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_restaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_restaurar.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btn_restaurar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_restaurar.Image = Global.RTecSys.My.Resources.Resources.restaurar
        Me.btn_restaurar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_restaurar.Location = New System.Drawing.Point(9, 233)
        Me.btn_restaurar.Name = "btn_restaurar"
        Me.btn_restaurar.Size = New System.Drawing.Size(112, 51)
        Me.btn_restaurar.TabIndex = 16
        Me.btn_restaurar.Text = "&Restaurar [F1]"
        Me.btn_restaurar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_restaurar.UseVisualStyleBackColor = False
        '
        'btn_relatorio
        '
        Me.btn_relatorio.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_relatorio.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_relatorio.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_relatorio.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_relatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_relatorio.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btn_relatorio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_relatorio.Image = Global.RTecSys.My.Resources.Resources.Imprime
        Me.btn_relatorio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_relatorio.Location = New System.Drawing.Point(9, 180)
        Me.btn_relatorio.Name = "btn_relatorio"
        Me.btn_relatorio.Size = New System.Drawing.Size(112, 47)
        Me.btn_relatorio.TabIndex = 16
        Me.btn_relatorio.Text = "&Relatório [F6]"
        Me.btn_relatorio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_relatorio.UseVisualStyleBackColor = False
        '
        'btn_altera
        '
        Me.btn_altera.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_altera.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_altera.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_altera.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_altera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_altera.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_altera.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_altera.Image = Global.RTecSys.My.Resources.Resources.editar
        Me.btn_altera.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_altera.Location = New System.Drawing.Point(8, 69)
        Me.btn_altera.Name = "btn_altera"
        Me.btn_altera.Size = New System.Drawing.Size(112, 48)
        Me.btn_altera.TabIndex = 12
        Me.btn_altera.Text = "&Altera  [F3]"
        Me.btn_altera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_altera.UseVisualStyleBackColor = False
        '
        'btn_inclui
        '
        Me.btn_inclui.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_inclui.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_inclui.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_inclui.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_inclui.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_inclui.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_inclui.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_inclui.Image = Global.RTecSys.My.Resources.Resources.Add
        Me.btn_inclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_inclui.Location = New System.Drawing.Point(8, 14)
        Me.btn_inclui.Name = "btn_inclui"
        Me.btn_inclui.Size = New System.Drawing.Size(112, 49)
        Me.btn_inclui.TabIndex = 10
        Me.btn_inclui.Text = "&Inclui  [F2]"
        Me.btn_inclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_inclui.UseVisualStyleBackColor = False
        '
        'btn_exclui
        '
        Me.btn_exclui.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_exclui.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_exclui.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_exclui.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_exclui.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exclui.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_exclui.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_exclui.Image = Global.RTecSys.My.Resources.Resources.Delete
        Me.btn_exclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exclui.Location = New System.Drawing.Point(8, 124)
        Me.btn_exclui.Name = "btn_exclui"
        Me.btn_exclui.Size = New System.Drawing.Size(112, 50)
        Me.btn_exclui.TabIndex = 14
        Me.btn_exclui.Text = "&Exclui  [F4]"
        Me.btn_exclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exclui.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 497)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1044, 47)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(18, 19)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(16, 15)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = ".  "
        '
        'grb_registros
        '
        Me.grb_registros.BackColor = System.Drawing.SystemColors.Control
        Me.grb_registros.Controls.Add(Me.lbl_registros)
        Me.grb_registros.Location = New System.Drawing.Point(923, 457)
        Me.grb_registros.Name = "grb_registros"
        Me.grb_registros.Size = New System.Drawing.Size(70, 34)
        Me.grb_registros.TabIndex = 12
        Me.grb_registros.TabStop = False
        Me.grb_registros.Text = "Registros"
        '
        'lbl_registros
        '
        Me.lbl_registros.AutoSize = True
        Me.lbl_registros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_registros.ForeColor = System.Drawing.Color.OrangeRed
        Me.lbl_registros.Location = New System.Drawing.Point(8, 16)
        Me.lbl_registros.Name = "lbl_registros"
        Me.lbl_registros.Size = New System.Drawing.Size(14, 13)
        Me.lbl_registros.TabIndex = 1
        Me.lbl_registros.Text = "0"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grb_periodo)
        Me.GroupBox3.Controls.Add(Me.cbo_doutores)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.grp_Tipo)
        Me.GroupBox3.Controls.Add(Me.cbo_cidade)
        Me.GroupBox3.Controls.Add(Me.lbl_cidade)
        Me.GroupBox3.Controls.Add(Me.cbo_uf)
        Me.GroupBox3.Controls.Add(Me.lbl_uf)
        Me.GroupBox3.Controls.Add(Me.lbl_pesquisa)
        Me.GroupBox3.Controls.Add(Me.txt_pesquisa)
        Me.GroupBox3.Controls.Add(Me.grp_opcoes)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 67)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1044, 88)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'grb_periodo
        '
        Me.grb_periodo.Controls.Add(Me.dtp_final)
        Me.grb_periodo.Controls.Add(Me.dtp_inicial)
        Me.grb_periodo.Controls.Add(Me.Label2)
        Me.grb_periodo.Controls.Add(Me.chk_simPeriodo)
        Me.grb_periodo.Location = New System.Drawing.Point(867, 7)
        Me.grb_periodo.Name = "grb_periodo"
        Me.grb_periodo.Size = New System.Drawing.Size(168, 75)
        Me.grb_periodo.TabIndex = 72
        Me.grb_periodo.TabStop = False
        Me.grb_periodo.Text = "Período: "
        '
        'dtp_final
        '
        Me.dtp_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_final.Location = New System.Drawing.Point(56, 46)
        Me.dtp_final.Name = "dtp_final"
        Me.dtp_final.Size = New System.Drawing.Size(102, 23)
        Me.dtp_final.TabIndex = 76
        '
        'dtp_inicial
        '
        Me.dtp_inicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_inicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_inicial.Location = New System.Drawing.Point(56, 16)
        Me.dtp_inicial.Name = "dtp_inicial"
        Me.dtp_inicial.Size = New System.Drawing.Size(102, 23)
        Me.dtp_inicial.TabIndex = 75
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(35, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "A"
        '
        'chk_simPeriodo
        '
        Me.chk_simPeriodo.AutoSize = True
        Me.chk_simPeriodo.BackColor = System.Drawing.Color.Transparent
        Me.chk_simPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_simPeriodo.Location = New System.Drawing.Point(6, 19)
        Me.chk_simPeriodo.Name = "chk_simPeriodo"
        Me.chk_simPeriodo.Size = New System.Drawing.Size(46, 17)
        Me.chk_simPeriodo.TabIndex = 77
        Me.chk_simPeriodo.Text = "Sim"
        Me.chk_simPeriodo.UseVisualStyleBackColor = False
        '
        'cbo_doutores
        '
        Me.cbo_doutores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_doutores.DropDownWidth = 200
        Me.cbo_doutores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_doutores.FormattingEnabled = True
        Me.cbo_doutores.Location = New System.Drawing.Point(686, 22)
        Me.cbo_doutores.Name = "cbo_doutores"
        Me.cbo_doutores.Size = New System.Drawing.Size(162, 23)
        Me.cbo_doutores.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(625, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Dentista:"
        '
        'grp_Tipo
        '
        Me.grp_Tipo.BackColor = System.Drawing.Color.Transparent
        Me.grp_Tipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.grp_Tipo.Controls.Add(Me.RdbNd)
        Me.grp_Tipo.Controls.Add(Me.RdBForn)
        Me.grp_Tipo.Controls.Add(Me.RdBCli)
        Me.grp_Tipo.Location = New System.Drawing.Point(198, 46)
        Me.grp_Tipo.Name = "grp_Tipo"
        Me.grp_Tipo.Size = New System.Drawing.Size(177, 36)
        Me.grp_Tipo.TabIndex = 27
        Me.grp_Tipo.TabStop = False
        Me.grp_Tipo.Text = "Tipo"
        '
        'RdbNd
        '
        Me.RdbNd.AutoSize = True
        Me.RdbNd.Checked = True
        Me.RdbNd.Location = New System.Drawing.Point(130, 15)
        Me.RdbNd.Name = "RdbNd"
        Me.RdbNd.Size = New System.Drawing.Size(41, 17)
        Me.RdbNd.TabIndex = 3
        Me.RdbNd.TabStop = True
        Me.RdbNd.Text = "ND"
        Me.RdbNd.UseVisualStyleBackColor = True
        '
        'RdBForn
        '
        Me.RdBForn.AutoSize = True
        Me.RdBForn.Location = New System.Drawing.Point(76, 15)
        Me.RdBForn.Name = "RdBForn"
        Me.RdBForn.Size = New System.Drawing.Size(46, 17)
        Me.RdBForn.TabIndex = 3
        Me.RdBForn.Text = "Forn"
        Me.RdBForn.UseVisualStyleBackColor = True
        '
        'RdBCli
        '
        Me.RdBCli.AutoSize = True
        Me.RdBCli.Location = New System.Drawing.Point(9, 15)
        Me.RdBCli.Name = "RdBCli"
        Me.RdBCli.Size = New System.Drawing.Size(57, 17)
        Me.RdBCli.TabIndex = 2
        Me.RdBCli.Text = "Cliente"
        Me.RdBCli.UseVisualStyleBackColor = True
        '
        'cbo_cidade
        '
        Me.cbo_cidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbo_cidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cbo_cidade.DropDownWidth = 300
        Me.cbo_cidade.FormattingEnabled = True
        Me.cbo_cidade.Location = New System.Drawing.Point(560, 58)
        Me.cbo_cidade.Name = "cbo_cidade"
        Me.cbo_cidade.Size = New System.Drawing.Size(288, 21)
        Me.cbo_cidade.TabIndex = 7
        '
        'lbl_cidade
        '
        Me.lbl_cidade.AutoSize = True
        Me.lbl_cidade.Location = New System.Drawing.Point(511, 61)
        Me.lbl_cidade.Name = "lbl_cidade"
        Me.lbl_cidade.Size = New System.Drawing.Size(43, 13)
        Me.lbl_cidade.TabIndex = 26
        Me.lbl_cidade.Text = "Cidade:"
        '
        'cbo_uf
        '
        Me.cbo_uf.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbo_uf.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_uf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_uf.FormattingEnabled = True
        Me.cbo_uf.Items.AddRange(New Object() {"", "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO", "EX"})
        Me.cbo_uf.Location = New System.Drawing.Point(430, 57)
        Me.cbo_uf.Name = "cbo_uf"
        Me.cbo_uf.Size = New System.Drawing.Size(45, 21)
        Me.cbo_uf.TabIndex = 6
        '
        'lbl_uf
        '
        Me.lbl_uf.AutoSize = True
        Me.lbl_uf.Location = New System.Drawing.Point(403, 61)
        Me.lbl_uf.Name = "lbl_uf"
        Me.lbl_uf.Size = New System.Drawing.Size(24, 13)
        Me.lbl_uf.TabIndex = 25
        Me.lbl_uf.Text = "UF:"
        '
        'lbl_pesquisa
        '
        Me.lbl_pesquisa.AutoSize = True
        Me.lbl_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pesquisa.Location = New System.Drawing.Point(204, 25)
        Me.lbl_pesquisa.Name = "lbl_pesquisa"
        Me.lbl_pesquisa.Size = New System.Drawing.Size(84, 15)
        Me.lbl_pesquisa.TabIndex = 24
        Me.lbl_pesquisa.Text = "CNPJ ou CPF:"
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(302, 20)
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(119, 23)
        Me.txt_pesquisa.TabIndex = 5
        '
        'grp_opcoes
        '
        Me.grp_opcoes.BackColor = System.Drawing.Color.Transparent
        Me.grp_opcoes.Controls.Add(Me.rdb_ficha)
        Me.grp_opcoes.Controls.Add(Me.rdb_nome)
        Me.grp_opcoes.Controls.Add(Me.rdb_nao)
        Me.grp_opcoes.Controls.Add(Me.rdb_codigo)
        Me.grp_opcoes.Controls.Add(Me.rdb_cnpj_cpf)
        Me.grp_opcoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grp_opcoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_opcoes.Location = New System.Drawing.Point(5, 12)
        Me.grp_opcoes.Name = "grp_opcoes"
        Me.grp_opcoes.Size = New System.Drawing.Size(185, 70)
        Me.grp_opcoes.TabIndex = 0
        Me.grp_opcoes.TabStop = False
        Me.grp_opcoes.Text = "Opções"
        '
        'rdb_ficha
        '
        Me.rdb_ficha.AutoSize = True
        Me.rdb_ficha.Location = New System.Drawing.Point(63, 42)
        Me.rdb_ficha.Name = "rdb_ficha"
        Me.rdb_ficha.Size = New System.Drawing.Size(60, 19)
        Me.rdb_ficha.TabIndex = 5
        Me.rdb_ficha.TabStop = True
        Me.rdb_ficha.Text = "Ficha"
        Me.rdb_ficha.UseVisualStyleBackColor = True
        '
        'rdb_nome
        '
        Me.rdb_nome.AutoSize = True
        Me.rdb_nome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_nome.Location = New System.Drawing.Point(111, 18)
        Me.rdb_nome.Name = "rdb_nome"
        Me.rdb_nome.Size = New System.Drawing.Size(65, 17)
        Me.rdb_nome.TabIndex = 2
        Me.rdb_nome.TabStop = True
        Me.rdb_nome.Text = "NOME "
        Me.rdb_nome.UseVisualStyleBackColor = True
        '
        'rdb_nao
        '
        Me.rdb_nao.AutoSize = True
        Me.rdb_nao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_nao.Location = New System.Drawing.Point(135, 44)
        Me.rdb_nao.Name = "rdb_nao"
        Me.rdb_nao.Size = New System.Drawing.Size(43, 17)
        Me.rdb_nao.TabIndex = 4
        Me.rdb_nao.TabStop = True
        Me.rdb_nao.Text = "ND"
        Me.rdb_nao.UseVisualStyleBackColor = True
        '
        'rdb_codigo
        '
        Me.rdb_codigo.AutoSize = True
        Me.rdb_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_codigo.Location = New System.Drawing.Point(6, 44)
        Me.rdb_codigo.Name = "rdb_codigo"
        Me.rdb_codigo.Size = New System.Drawing.Size(51, 17)
        Me.rdb_codigo.TabIndex = 3
        Me.rdb_codigo.TabStop = True
        Me.rdb_codigo.Text = "COD"
        Me.rdb_codigo.UseVisualStyleBackColor = True
        '
        'rdb_cnpj_cpf
        '
        Me.rdb_cnpj_cpf.AutoSize = True
        Me.rdb_cnpj_cpf.Checked = True
        Me.rdb_cnpj_cpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_cnpj_cpf.Location = New System.Drawing.Point(6, 18)
        Me.rdb_cnpj_cpf.Name = "rdb_cnpj_cpf"
        Me.rdb_cnpj_cpf.Size = New System.Drawing.Size(85, 17)
        Me.rdb_cnpj_cpf.TabIndex = 1
        Me.rdb_cnpj_cpf.TabStop = True
        Me.rdb_cnpj_cpf.Text = "CNPJ/CPF"
        Me.rdb_cnpj_cpf.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-5, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1076, 42)
        Me.Panel1.TabIndex = 21
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(449, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'chk_todos
        '
        Me.chk_todos.AutoSize = True
        Me.chk_todos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_todos.ForeColor = System.Drawing.Color.Blue
        Me.chk_todos.Location = New System.Drawing.Point(1004, 468)
        Me.chk_todos.Name = "chk_todos"
        Me.chk_todos.Size = New System.Drawing.Size(49, 21)
        Me.chk_todos.TabIndex = 22
        Me.chk_todos.Text = "All!"
        Me.chk_todos.UseVisualStyleBackColor = True
        '
        'dtgClientes
        '
        Me.dtgClientes.AllowUserToAddRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightYellow
        Me.dtgClientes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dtgClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgClientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dtgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.ficha, Me.nome, Me.dentista, Me.cpf, Me.dataCad})
        Me.dtgClientes.Location = New System.Drawing.Point(9, 167)
        Me.dtgClientes.Name = "dtgClientes"
        Me.dtgClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtgClientes.Size = New System.Drawing.Size(905, 322)
        Me.dtgClientes.TabIndex = 21
        '
        'codigo
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codigo.DefaultCellStyle = DataGridViewCellStyle15
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.Width = 80
        '
        'ficha
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ficha.DefaultCellStyle = DataGridViewCellStyle16
        Me.ficha.HeaderText = "Ficha"
        Me.ficha.Name = "ficha"
        Me.ficha.Width = 80
        '
        'nome
        '
        Me.nome.HeaderText = "Nome"
        Me.nome.Name = "nome"
        Me.nome.Width = 305
        '
        'dentista
        '
        Me.dentista.HeaderText = "Dentista"
        Me.dentista.Name = "dentista"
        Me.dentista.Width = 180
        '
        'cpf
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cpf.DefaultCellStyle = DataGridViewCellStyle17
        Me.cpf.HeaderText = "CPF"
        Me.cpf.Name = "cpf"
        Me.cpf.Width = 110
        '
        'dataCad
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dataCad.DefaultCellStyle = DataGridViewCellStyle18
        Me.dataCad.HeaderText = "Dt. Cad"
        Me.dataCad.Name = "dataCad"
        Me.dataCad.Width = 90
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(381, 18)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "[ F5 ] - Atualiza Pesquisa       [ F9 ] - Consulta BD"
        '
        'btn_SemCpf
        '
        Me.btn_SemCpf.BackColor = System.Drawing.Color.Red
        Me.btn_SemCpf.Enabled = False
        Me.btn_SemCpf.FlatAppearance.BorderSize = 0
        Me.btn_SemCpf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_SemCpf.Location = New System.Drawing.Point(698, 48)
        Me.btn_SemCpf.Name = "btn_SemCpf"
        Me.btn_SemCpf.Size = New System.Drawing.Size(24, 15)
        Me.btn_SemCpf.TabIndex = 24
        Me.btn_SemCpf.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(725, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 15)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "- Clientes SEM CPF"
        '
        'Frm_MenuCadastro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1065, 535)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_SemCpf)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtgClientes)
        Me.Controls.Add(Me.chk_todos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grb_registros)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_MenuCadastro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Cadastro de Clientes/Fornecedores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grb_registros.ResumeLayout(False)
        Me.grb_registros.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grb_periodo.ResumeLayout(False)
        Me.grb_periodo.PerformLayout()
        Me.grp_Tipo.ResumeLayout(False)
        Me.grp_Tipo.PerformLayout()
        Me.grp_opcoes.ResumeLayout(False)
        Me.grp_opcoes.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtgClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_altera As System.Windows.Forms.Button
    Friend WithEvents btn_inclui As System.Windows.Forms.Button
    Friend WithEvents btn_exclui As System.Windows.Forms.Button
    Friend WithEvents btn_relatorio As System.Windows.Forms.Button
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents grb_registros As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_registros As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_cidade As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_cidade As System.Windows.Forms.Label
    Public WithEvents cbo_uf As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_uf As System.Windows.Forms.Label
    Friend WithEvents lbl_pesquisa As System.Windows.Forms.Label
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents grp_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_nome As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_nao As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_codigo As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_cnpj_cpf As System.Windows.Forms.RadioButton
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Public WithEvents grp_Tipo As System.Windows.Forms.GroupBox
    Friend WithEvents RdbNd As System.Windows.Forms.RadioButton
    Friend WithEvents RdBForn As System.Windows.Forms.RadioButton
    Friend WithEvents RdBCli As System.Windows.Forms.RadioButton
    Friend WithEvents btn_restaurar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chk_todos As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_doutores As System.Windows.Forms.ComboBox
    Friend WithEvents rdb_ficha As System.Windows.Forms.RadioButton
    Friend WithEvents dtgClientes As System.Windows.Forms.DataGridView
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dentista As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cpf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataCad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grb_periodo As System.Windows.Forms.GroupBox
    Friend WithEvents chk_simPeriodo As System.Windows.Forms.CheckBox
    Friend WithEvents dtp_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_inicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_SemCpf As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
