<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConfiguraCupomFiscal
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ConfiguraCupomFiscal))
        Me.btn_salvar = New System.Windows.Forms.Button
        Me.tbc_impressora = New System.Windows.Forms.TabControl
        Me.tbp_visualizacao = New System.Windows.Forms.TabPage
        Me.dtg_Impressoras = New System.Windows.Forms.DataGridView
        Me.idUsu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.endereco = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.regmac = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nfabricacao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_pesquisa = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem01 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.btn_incluir = New System.Windows.Forms.Button
        Me.tbp_manutencao = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem02 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.btn_mac = New System.Windows.Forms.Button
        Me.txt_regMac = New System.Windows.Forms.TextBox
        Me.txt_codExterno = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_pafEcf = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_lacre2 = New System.Windows.Forms.TextBox
        Me.txt_lacre1 = New System.Windows.Forms.TextBox
        Me.txt_autorizacao = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_numFabricacao = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbo_loja = New System.Windows.Forms.ComboBox
        Me.cbo_impressora = New System.Windows.Forms.ComboBox
        Me.txt_caixa = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label26 = New System.Windows.Forms.Label
        Me.tbc_impressora.SuspendLayout()
        Me.tbp_visualizacao.SuspendLayout()
        CType(Me.dtg_Impressoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbp_manutencao.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_salvar
        '
        Me.btn_salvar.Enabled = False
        Me.btn_salvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salvar.Image = Global.MetroSys.My.Resources.Resources.Save
        Me.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salvar.Location = New System.Drawing.Point(8, 14)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(66, 42)
        Me.btn_salvar.TabIndex = 43
        Me.btn_salvar.Text = "&Salvar"
        Me.btn_salvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'tbc_impressora
        '
        Me.tbc_impressora.Controls.Add(Me.tbp_visualizacao)
        Me.tbc_impressora.Controls.Add(Me.tbp_manutencao)
        Me.tbc_impressora.Location = New System.Drawing.Point(5, 74)
        Me.tbc_impressora.Name = "tbc_impressora"
        Me.tbc_impressora.SelectedIndex = 0
        Me.tbc_impressora.Size = New System.Drawing.Size(599, 373)
        Me.tbc_impressora.TabIndex = 8
        '
        'tbp_visualizacao
        '
        Me.tbp_visualizacao.Controls.Add(Me.dtg_Impressoras)
        Me.tbp_visualizacao.Controls.Add(Me.txt_pesquisa)
        Me.tbp_visualizacao.Controls.Add(Me.Label7)
        Me.tbp_visualizacao.Controls.Add(Me.GroupBox2)
        Me.tbp_visualizacao.Controls.Add(Me.GroupBox1)
        Me.tbp_visualizacao.Location = New System.Drawing.Point(4, 22)
        Me.tbp_visualizacao.Name = "tbp_visualizacao"
        Me.tbp_visualizacao.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_visualizacao.Size = New System.Drawing.Size(591, 347)
        Me.tbp_visualizacao.TabIndex = 0
        Me.tbp_visualizacao.Text = "Visualização"
        Me.tbp_visualizacao.UseVisualStyleBackColor = True
        '
        'dtg_Impressoras
        '
        Me.dtg_Impressoras.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_Impressoras.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_Impressoras.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_Impressoras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_Impressoras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_Impressoras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_Impressoras.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_Impressoras.ColumnHeadersHeight = 26
        Me.dtg_Impressoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_Impressoras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idUsu, Me.codigo, Me.endereco, Me.nome, Me.regmac, Me.nfabricacao})
        Me.dtg_Impressoras.Location = New System.Drawing.Point(12, 58)
        Me.dtg_Impressoras.MultiSelect = False
        Me.dtg_Impressoras.Name = "dtg_Impressoras"
        Me.dtg_Impressoras.ReadOnly = True
        Me.dtg_Impressoras.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_Impressoras.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtg_Impressoras.Size = New System.Drawing.Size(562, 223)
        Me.dtg_Impressoras.TabIndex = 26
        '
        'idUsu
        '
        Me.idUsu.HeaderText = "Id"
        Me.idUsu.MaxInputLength = 13
        Me.idUsu.Name = "idUsu"
        Me.idUsu.ReadOnly = True
        Me.idUsu.Visible = False
        '
        'codigo
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigo.DefaultCellStyle = DataGridViewCellStyle3
        Me.codigo.HeaderText = "Caixa"
        Me.codigo.MaxInputLength = 2
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.codigo.Width = 60
        '
        'endereco
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.endereco.DefaultCellStyle = DataGridViewCellStyle4
        Me.endereco.HeaderText = "Loja"
        Me.endereco.MaxInputLength = 10
        Me.endereco.Name = "endereco"
        Me.endereco.ReadOnly = True
        Me.endereco.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.endereco.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.endereco.Width = 80
        '
        'nome
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nome.DefaultCellStyle = DataGridViewCellStyle5
        Me.nome.HeaderText = "Impressora"
        Me.nome.MaxInputLength = 30
        Me.nome.Name = "nome"
        Me.nome.ReadOnly = True
        Me.nome.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nome.Width = 150
        '
        'regmac
        '
        Me.regmac.HeaderText = "Maquina"
        Me.regmac.MaxInputLength = 18
        Me.regmac.Name = "regmac"
        Me.regmac.ReadOnly = True
        Me.regmac.Width = 228
        '
        'nfabricacao
        '
        Me.nfabricacao.HeaderText = "NFabricacao"
        Me.nfabricacao.MaxInputLength = 40
        Me.nfabricacao.Name = "nfabricacao"
        Me.nfabricacao.ReadOnly = True
        Me.nfabricacao.Visible = False
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(63, 19)
        Me.txt_pesquisa.MaxLength = 80
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(268, 21)
        Me.txt_pesquisa.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Nome:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem01)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 287)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(562, 46)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem01
        '
        Me.lbl_mensagem01.AutoSize = True
        Me.lbl_mensagem01.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem01.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem01.Location = New System.Drawing.Point(12, 20)
        Me.lbl_mensagem01.Name = "lbl_mensagem01"
        Me.lbl_mensagem01.Size = New System.Drawing.Size(28, 17)
        Me.lbl_mensagem01.TabIndex = 0
        Me.lbl_mensagem01.Text = ".   "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_excluir)
        Me.GroupBox1.Controls.Add(Me.btn_alterar)
        Me.GroupBox1.Controls.Add(Me.btn_incluir)
        Me.GroupBox1.Location = New System.Drawing.Point(348, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(226, 48)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excluir.Location = New System.Drawing.Point(151, 10)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(70, 33)
        Me.btn_excluir.TabIndex = 3
        Me.btn_excluir.Text = "&Exclui"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.Modify
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(79, 10)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(70, 33)
        Me.btn_alterar.TabIndex = 2
        Me.btn_alterar.Text = "&Altera"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_incluir
        '
        Me.btn_incluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_incluir.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btn_incluir.Location = New System.Drawing.Point(7, 10)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(70, 33)
        Me.btn_incluir.TabIndex = 1
        Me.btn_incluir.Text = "&Inclui"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'tbp_manutencao
        '
        Me.tbp_manutencao.Controls.Add(Me.GroupBox3)
        Me.tbp_manutencao.Controls.Add(Me.GroupBox5)
        Me.tbp_manutencao.Location = New System.Drawing.Point(4, 22)
        Me.tbp_manutencao.Name = "tbp_manutencao"
        Me.tbp_manutencao.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_manutencao.Size = New System.Drawing.Size(591, 347)
        Me.tbp_manutencao.TabIndex = 1
        Me.tbp_manutencao.Text = "Impressora"
        Me.tbp_manutencao.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_mensagem02)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 289)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(577, 41)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'lbl_mensagem02
        '
        Me.lbl_mensagem02.AutoSize = True
        Me.lbl_mensagem02.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem02.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem02.Location = New System.Drawing.Point(10, 16)
        Me.lbl_mensagem02.Name = "lbl_mensagem02"
        Me.lbl_mensagem02.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem02.TabIndex = 0
        Me.lbl_mensagem02.Text = ".   "
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Controls.Add(Me.txt_codExterno)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.txt_pafEcf)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.txt_lacre2)
        Me.GroupBox5.Controls.Add(Me.txt_lacre1)
        Me.GroupBox5.Controls.Add(Me.txt_autorizacao)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.txt_numFabricacao)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.cbo_loja)
        Me.GroupBox5.Controls.Add(Me.cbo_impressora)
        Me.GroupBox5.Controls.Add(Me.txt_caixa)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(577, 277)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btn_mac)
        Me.GroupBox6.Controls.Add(Me.txt_regMac)
        Me.GroupBox6.Location = New System.Drawing.Point(26, 163)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(297, 48)
        Me.GroupBox6.TabIndex = 14
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Registro Interno"
        '
        'btn_mac
        '
        Me.btn_mac.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btn_mac.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_mac.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_mac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mac.Location = New System.Drawing.Point(215, 20)
        Me.btn_mac.Name = "btn_mac"
        Me.btn_mac.Size = New System.Drawing.Size(77, 22)
        Me.btn_mac.TabIndex = 16
        Me.btn_mac.Text = "Mac Local"
        Me.btn_mac.UseVisualStyleBackColor = True
        '
        'txt_regMac
        '
        Me.txt_regMac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_regMac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_regMac.Location = New System.Drawing.Point(6, 20)
        Me.txt_regMac.MaxLength = 17
        Me.txt_regMac.Name = "txt_regMac"
        Me.txt_regMac.Size = New System.Drawing.Size(204, 21)
        Me.txt_regMac.TabIndex = 15
        '
        'txt_codExterno
        '
        Me.txt_codExterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codExterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codExterno.Location = New System.Drawing.Point(25, 238)
        Me.txt_codExterno.MaxLength = 3
        Me.txt_codExterno.Name = "txt_codExterno"
        Me.txt_codExterno.Size = New System.Drawing.Size(59, 21)
        Me.txt_codExterno.TabIndex = 19
        Me.txt_codExterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(22, 219)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 15)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "Cod. Externo"
        '
        'txt_pafEcf
        '
        Me.txt_pafEcf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pafEcf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pafEcf.Location = New System.Drawing.Point(338, 184)
        Me.txt_pafEcf.MaxLength = 10
        Me.txt_pafEcf.Name = "txt_pafEcf"
        Me.txt_pafEcf.Size = New System.Drawing.Size(112, 21)
        Me.txt_pafEcf.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(350, 165)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 15)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Laudo Paf-Ecf"
        '
        'txt_lacre2
        '
        Me.txt_lacre2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lacre2.Location = New System.Drawing.Point(326, 134)
        Me.txt_lacre2.MaxLength = 10
        Me.txt_lacre2.Name = "txt_lacre2"
        Me.txt_lacre2.Size = New System.Drawing.Size(124, 21)
        Me.txt_lacre2.TabIndex = 13
        '
        'txt_lacre1
        '
        Me.txt_lacre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lacre1.Location = New System.Drawing.Point(160, 134)
        Me.txt_lacre1.MaxLength = 10
        Me.txt_lacre1.Name = "txt_lacre1"
        Me.txt_lacre1.Size = New System.Drawing.Size(126, 21)
        Me.txt_lacre1.TabIndex = 11
        '
        'txt_autorizacao
        '
        Me.txt_autorizacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_autorizacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_autorizacao.Location = New System.Drawing.Point(25, 134)
        Me.txt_autorizacao.MaxLength = 10
        Me.txt_autorizacao.Name = "txt_autorizacao"
        Me.txt_autorizacao.Size = New System.Drawing.Size(104, 21)
        Me.txt_autorizacao.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(364, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 15)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Lacre2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(197, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Lacre1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 15)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Autorização"
        '
        'txt_numFabricacao
        '
        Me.txt_numFabricacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_numFabricacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numFabricacao.Location = New System.Drawing.Point(269, 79)
        Me.txt_numFabricacao.MaxLength = 20
        Me.txt_numFabricacao.Name = "txt_numFabricacao"
        Me.txt_numFabricacao.Size = New System.Drawing.Size(181, 21)
        Me.txt_numFabricacao.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(321, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "N.Fabricação"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(121, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Impressora"
        '
        'cbo_loja
        '
        Me.cbo_loja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_loja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_loja.FormattingEnabled = True
        Me.cbo_loja.Items.AddRange(New Object() {"1-EcfBematech", "2-EcfDaruma", "3-EcfZanthus", "4-EcfElgin", "5-EcfDataRegis", "6-EcfOutras", "7-NaoFiscal"})
        Me.cbo_loja.Location = New System.Drawing.Point(58, 22)
        Me.cbo_loja.Name = "cbo_loja"
        Me.cbo_loja.Size = New System.Drawing.Size(392, 23)
        Me.cbo_loja.TabIndex = 1
        '
        'cbo_impressora
        '
        Me.cbo_impressora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_impressora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_impressora.FormattingEnabled = True
        Me.cbo_impressora.Items.AddRange(New Object() {"1-EcfBematech", "2-EcfDaruma", "3-EcfZanthus", "4-EcfElgin", "5-EcfDataRegis", "6-EcfOutras", "7-NaoFiscal"})
        Me.cbo_impressora.Location = New System.Drawing.Point(102, 77)
        Me.cbo_impressora.Name = "cbo_impressora"
        Me.cbo_impressora.Size = New System.Drawing.Size(122, 23)
        Me.cbo_impressora.TabIndex = 5
        '
        'txt_caixa
        '
        Me.txt_caixa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_caixa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_caixa.Location = New System.Drawing.Point(25, 77)
        Me.txt_caixa.MaxLength = 2
        Me.txt_caixa.Name = "txt_caixa"
        Me.txt_caixa.Size = New System.Drawing.Size(44, 21)
        Me.txt_caixa.TabIndex = 3
        Me.txt_caixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 15)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Caixa"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Loja:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_cancelar)
        Me.GroupBox4.Controls.Add(Me.btn_salvar)
        Me.GroupBox4.Location = New System.Drawing.Point(471, 149)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(81, 110)
        Me.GroupBox4.TabIndex = 41
        Me.GroupBox4.TabStop = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.MetroSys.My.Resources.Resources.cancelar1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(8, 62)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(66, 42)
        Me.btn_cancelar.TabIndex = 45
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(215, 7)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(156, 58)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-4, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(615, 74)
        Me.Panel1.TabIndex = 7
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Wide Latin", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(421, 44)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(175, 23)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'Frm_ConfiguraCupomFiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 452)
        Me.Controls.Add(Me.tbc_impressora)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "Frm_ConfiguraCupomFiscal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuração de Impressora"
        Me.tbc_impressora.ResumeLayout(False)
        Me.tbp_visualizacao.ResumeLayout(False)
        Me.tbp_visualizacao.PerformLayout()
        CType(Me.dtg_Impressoras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.tbp_manutencao.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents tbc_impressora As System.Windows.Forms.TabControl
    Friend WithEvents tbp_visualizacao As System.Windows.Forms.TabPage
    Friend WithEvents dtg_Impressoras As System.Windows.Forms.DataGridView
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem01 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents tbp_manutencao As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem02 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txt_pafEcf As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_regMac As System.Windows.Forms.TextBox
    Friend WithEvents txt_lacre2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_lacre1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_autorizacao As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_numFabricacao As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_impressora As System.Windows.Forms.ComboBox
    Friend WithEvents txt_caixa As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_codExterno As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_mac As System.Windows.Forms.Button
    Friend WithEvents idUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents endereco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents regmac As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nfabricacao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbo_loja As System.Windows.Forms.ComboBox
End Class
