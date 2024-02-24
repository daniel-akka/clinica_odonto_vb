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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MenuCadastro))
        Me.dtgPortadores = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_restaurar = New System.Windows.Forms.Button
        Me.btn_relatorio = New System.Windows.Forms.Button
        Me.btn_altera = New System.Windows.Forms.Button
        Me.btn_inclui = New System.Windows.Forms.Button
        Me.btn_exclui = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.grb_registros = New System.Windows.Forms.GroupBox
        Me.lbl_registros = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grp_Tipo = New System.Windows.Forms.GroupBox
        Me.RdBTransp = New System.Windows.Forms.RadioButton
        Me.RdbNd = New System.Windows.Forms.RadioButton
        Me.RdBForn = New System.Windows.Forms.RadioButton
        Me.RdBCli = New System.Windows.Forms.RadioButton
        Me.cbo_cidade = New System.Windows.Forms.ComboBox
        Me.lbl_cidade = New System.Windows.Forms.Label
        Me.cbo_uf = New System.Windows.Forms.ComboBox
        Me.lbl_uf = New System.Windows.Forms.Label
        Me.lbl_pesquisa = New System.Windows.Forms.Label
        Me.txt_pesquisa = New System.Windows.Forms.TextBox
        Me.grp_opcoes = New System.Windows.Forms.GroupBox
        Me.rdb_nome = New System.Windows.Forms.RadioButton
        Me.rdb_nao = New System.Windows.Forms.RadioButton
        Me.rdb_codigo = New System.Windows.Forms.RadioButton
        Me.rdb_cnpj_cpf = New System.Windows.Forms.RadioButton
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        CType(Me.dtgPortadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grb_registros.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grp_Tipo.SuspendLayout()
        Me.grp_opcoes.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgPortadores
        '
        Me.dtgPortadores.AllowUserToAddRows = False
        Me.dtgPortadores.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        Me.dtgPortadores.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgPortadores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtgPortadores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtgPortadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgPortadores.Location = New System.Drawing.Point(9, 170)
        Me.dtgPortadores.MultiSelect = False
        Me.dtgPortadores.Name = "dtgPortadores"
        Me.dtgPortadores.ReadOnly = True
        Me.dtgPortadores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgPortadores.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgPortadores.Size = New System.Drawing.Size(635, 327)
        Me.dtgPortadores.TabIndex = 20
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_restaurar)
        Me.GroupBox1.Controls.Add(Me.btn_relatorio)
        Me.GroupBox1.Controls.Add(Me.btn_altera)
        Me.GroupBox1.Controls.Add(Me.btn_inclui)
        Me.GroupBox1.Controls.Add(Me.btn_exclui)
        Me.GroupBox1.Location = New System.Drawing.Point(650, 170)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(121, 261)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'btn_restaurar
        '
        Me.btn_restaurar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_restaurar.Image = Global.MetroSys.My.Resources.Resources.restaurar
        Me.btn_restaurar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_restaurar.Location = New System.Drawing.Point(12, 210)
        Me.btn_restaurar.Name = "btn_restaurar"
        Me.btn_restaurar.Size = New System.Drawing.Size(98, 43)
        Me.btn_restaurar.TabIndex = 16
        Me.btn_restaurar.Text = "&Restaurar [F1]"
        Me.btn_restaurar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_restaurar.UseVisualStyleBackColor = True
        '
        'btn_relatorio
        '
        Me.btn_relatorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_relatorio.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_relatorio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_relatorio.Location = New System.Drawing.Point(12, 161)
        Me.btn_relatorio.Name = "btn_relatorio"
        Me.btn_relatorio.Size = New System.Drawing.Size(98, 43)
        Me.btn_relatorio.TabIndex = 16
        Me.btn_relatorio.Text = "&Relatório [F6]"
        Me.btn_relatorio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_relatorio.UseVisualStyleBackColor = True
        '
        'btn_altera
        '
        Me.btn_altera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_altera.Image = Global.MetroSys.My.Resources.Resources.editar
        Me.btn_altera.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_altera.Location = New System.Drawing.Point(11, 63)
        Me.btn_altera.Name = "btn_altera"
        Me.btn_altera.Size = New System.Drawing.Size(98, 43)
        Me.btn_altera.TabIndex = 12
        Me.btn_altera.Text = "&Altera  [F3]"
        Me.btn_altera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_altera.UseVisualStyleBackColor = True
        '
        'btn_inclui
        '
        Me.btn_inclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_inclui.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_inclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_inclui.Location = New System.Drawing.Point(11, 14)
        Me.btn_inclui.Name = "btn_inclui"
        Me.btn_inclui.Size = New System.Drawing.Size(98, 43)
        Me.btn_inclui.TabIndex = 10
        Me.btn_inclui.Text = "&Inclui  [F2]"
        Me.btn_inclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_inclui.UseVisualStyleBackColor = True
        '
        'btn_exclui
        '
        Me.btn_exclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exclui.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_exclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exclui.Location = New System.Drawing.Point(11, 112)
        Me.btn_exclui.Name = "btn_exclui"
        Me.btn_exclui.Size = New System.Drawing.Size(98, 43)
        Me.btn_exclui.TabIndex = 14
        Me.btn_exclui.Text = "&Exclui  [F4]"
        Me.btn_exclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exclui.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 525)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(635, 47)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-2, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(781, 75)
        Me.Panel1.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(664, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "MetroSys"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(266, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(204, 63)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'grb_registros
        '
        Me.grb_registros.BackColor = System.Drawing.SystemColors.Control
        Me.grb_registros.Controls.Add(Me.lbl_registros)
        Me.grb_registros.Location = New System.Drawing.Point(650, 463)
        Me.grb_registros.Name = "grb_registros"
        Me.grb_registros.Size = New System.Drawing.Size(121, 34)
        Me.grb_registros.TabIndex = 12
        Me.grb_registros.TabStop = False
        Me.grb_registros.Text = "Registros"
        '
        'lbl_registros
        '
        Me.lbl_registros.AutoSize = True
        Me.lbl_registros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_registros.ForeColor = System.Drawing.Color.OrangeRed
        Me.lbl_registros.Location = New System.Drawing.Point(9, 15)
        Me.lbl_registros.Name = "lbl_registros"
        Me.lbl_registros.Size = New System.Drawing.Size(14, 13)
        Me.lbl_registros.TabIndex = 1
        Me.lbl_registros.Text = "0"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grp_Tipo)
        Me.GroupBox3.Controls.Add(Me.cbo_cidade)
        Me.GroupBox3.Controls.Add(Me.lbl_cidade)
        Me.GroupBox3.Controls.Add(Me.cbo_uf)
        Me.GroupBox3.Controls.Add(Me.lbl_uf)
        Me.GroupBox3.Controls.Add(Me.lbl_pesquisa)
        Me.GroupBox3.Controls.Add(Me.txt_pesquisa)
        Me.GroupBox3.Controls.Add(Me.grp_opcoes)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 76)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(762, 88)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'grp_Tipo
        '
        Me.grp_Tipo.BackColor = System.Drawing.Color.Transparent
        Me.grp_Tipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.grp_Tipo.Controls.Add(Me.RdBTransp)
        Me.grp_Tipo.Controls.Add(Me.RdbNd)
        Me.grp_Tipo.Controls.Add(Me.RdBForn)
        Me.grp_Tipo.Controls.Add(Me.RdBCli)
        Me.grp_Tipo.Location = New System.Drawing.Point(198, 46)
        Me.grp_Tipo.Name = "grp_Tipo"
        Me.grp_Tipo.Size = New System.Drawing.Size(219, 33)
        Me.grp_Tipo.TabIndex = 27
        Me.grp_Tipo.TabStop = False
        Me.grp_Tipo.Text = "Tipo"
        '
        'RdBTransp
        '
        Me.RdBTransp.AutoSize = True
        Me.RdBTransp.Location = New System.Drawing.Point(108, 13)
        Me.RdBTransp.Name = "RdBTransp"
        Me.RdBTransp.Size = New System.Drawing.Size(58, 17)
        Me.RdBTransp.TabIndex = 4
        Me.RdBTransp.TabStop = True
        Me.RdBTransp.Text = "Transp"
        Me.RdBTransp.UseVisualStyleBackColor = True
        '
        'RdbNd
        '
        Me.RdbNd.AutoSize = True
        Me.RdbNd.Location = New System.Drawing.Point(171, 13)
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
        Me.RdBForn.Location = New System.Drawing.Point(54, 13)
        Me.RdBForn.Name = "RdBForn"
        Me.RdBForn.Size = New System.Drawing.Size(46, 17)
        Me.RdBForn.TabIndex = 3
        Me.RdBForn.TabStop = True
        Me.RdBForn.Text = "Forn"
        Me.RdBForn.UseVisualStyleBackColor = True
        '
        'RdBCli
        '
        Me.RdBCli.AutoSize = True
        Me.RdBCli.Location = New System.Drawing.Point(9, 13)
        Me.RdBCli.Name = "RdBCli"
        Me.RdBCli.Size = New System.Drawing.Size(36, 17)
        Me.RdBCli.TabIndex = 2
        Me.RdBCli.TabStop = True
        Me.RdBCli.Text = "Cli"
        Me.RdBCli.UseVisualStyleBackColor = True
        '
        'cbo_cidade
        '
        Me.cbo_cidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbo_cidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cbo_cidade.DropDownWidth = 300
        Me.cbo_cidade.FormattingEnabled = True
        Me.cbo_cidade.Location = New System.Drawing.Point(546, 58)
        Me.cbo_cidade.Name = "cbo_cidade"
        Me.cbo_cidade.Size = New System.Drawing.Size(204, 21)
        Me.cbo_cidade.TabIndex = 7
        '
        'lbl_cidade
        '
        Me.lbl_cidade.AutoSize = True
        Me.lbl_cidade.Location = New System.Drawing.Point(501, 60)
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
        Me.cbo_uf.Location = New System.Drawing.Point(451, 57)
        Me.cbo_uf.Name = "cbo_uf"
        Me.cbo_uf.Size = New System.Drawing.Size(45, 21)
        Me.cbo_uf.TabIndex = 6
        '
        'lbl_uf
        '
        Me.lbl_uf.AutoSize = True
        Me.lbl_uf.Location = New System.Drawing.Point(424, 61)
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
        Me.grp_opcoes.Controls.Add(Me.rdb_nome)
        Me.grp_opcoes.Controls.Add(Me.rdb_nao)
        Me.grp_opcoes.Controls.Add(Me.rdb_codigo)
        Me.grp_opcoes.Controls.Add(Me.rdb_cnpj_cpf)
        Me.grp_opcoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grp_opcoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_opcoes.Location = New System.Drawing.Point(5, 9)
        Me.grp_opcoes.Name = "grp_opcoes"
        Me.grp_opcoes.Size = New System.Drawing.Size(185, 70)
        Me.grp_opcoes.TabIndex = 0
        Me.grp_opcoes.TabStop = False
        Me.grp_opcoes.Text = "Opções"
        '
        'rdb_nome
        '
        Me.rdb_nome.AutoSize = True
        Me.rdb_nome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_nome.Location = New System.Drawing.Point(6, 44)
        Me.rdb_nome.Name = "rdb_nome"
        Me.rdb_nome.Size = New System.Drawing.Size(89, 17)
        Me.rdb_nome.TabIndex = 2
        Me.rdb_nome.TabStop = True
        Me.rdb_nome.Text = "NOME       "
        Me.rdb_nome.UseVisualStyleBackColor = True
        '
        'rdb_nao
        '
        Me.rdb_nao.AutoSize = True
        Me.rdb_nao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_nao.Location = New System.Drawing.Point(99, 44)
        Me.rdb_nao.Name = "rdb_nao"
        Me.rdb_nao.Size = New System.Drawing.Size(75, 17)
        Me.rdb_nao.TabIndex = 4
        Me.rdb_nao.TabStop = True
        Me.rdb_nao.Text = "ND        "
        Me.rdb_nao.UseVisualStyleBackColor = True
        '
        'rdb_codigo
        '
        Me.rdb_codigo.AutoSize = True
        Me.rdb_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_codigo.Location = New System.Drawing.Point(99, 18)
        Me.rdb_codigo.Name = "rdb_codigo"
        Me.rdb_codigo.Size = New System.Drawing.Size(77, 17)
        Me.rdb_codigo.TabIndex = 3
        Me.rdb_codigo.TabStop = True
        Me.rdb_codigo.Text = "CODIGO "
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
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(661, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 37)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'Frm_MenuCadastro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 584)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grb_registros)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtgPortadores)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_MenuCadastro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Cadastro de Clientes/Fornecedores/Transporte "
        CType(Me.dtgPortadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grb_registros.ResumeLayout(False)
        Me.grb_registros.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grp_Tipo.ResumeLayout(False)
        Me.grp_Tipo.PerformLayout()
        Me.grp_opcoes.ResumeLayout(False)
        Me.grp_opcoes.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgPortadores As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_altera As System.Windows.Forms.Button
    Friend WithEvents btn_inclui As System.Windows.Forms.Button
    Friend WithEvents btn_exclui As System.Windows.Forms.Button
    Friend WithEvents btn_relatorio As System.Windows.Forms.Button
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
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
    Friend WithEvents RdBTransp As System.Windows.Forms.RadioButton
    Friend WithEvents RdBForn As System.Windows.Forms.RadioButton
    Friend WithEvents RdBCli As System.Windows.Forms.RadioButton
    Friend WithEvents btn_restaurar As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
