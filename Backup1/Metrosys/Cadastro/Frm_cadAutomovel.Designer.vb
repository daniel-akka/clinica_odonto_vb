<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_cadAutomovel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_cadAutomovel))
        Me.tbc_Automovels = New System.Windows.Forms.TabControl
        Me.tbp_visuAutomovel = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.btn_novo = New System.Windows.Forms.Button
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem01 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Dtg_automovel = New System.Windows.Forms.DataGridView
        Me.idComodato = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.placa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descricao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fornecedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tbp_cadAutomovel = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_salvar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_codPart = New System.Windows.Forms.TextBox
        Me.txt_codAutomovel = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_descricao = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_placa = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label26 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.tbc_Automovels.SuspendLayout()
        Me.tbp_visuAutomovel.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Dtg_automovel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbp_cadAutomovel.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbc_Automovels
        '
        Me.tbc_Automovels.Controls.Add(Me.tbp_visuAutomovel)
        Me.tbc_Automovels.Controls.Add(Me.tbp_cadAutomovel)
        Me.tbc_Automovels.Location = New System.Drawing.Point(5, 71)
        Me.tbc_Automovels.Name = "tbc_Automovels"
        Me.tbc_Automovels.SelectedIndex = 0
        Me.tbc_Automovels.Size = New System.Drawing.Size(613, 261)
        Me.tbc_Automovels.TabIndex = 8
        '
        'tbp_visuAutomovel
        '
        Me.tbp_visuAutomovel.Controls.Add(Me.GroupBox5)
        Me.tbp_visuAutomovel.Controls.Add(Me.GroupBox4)
        Me.tbp_visuAutomovel.Controls.Add(Me.Dtg_automovel)
        Me.tbp_visuAutomovel.Location = New System.Drawing.Point(4, 22)
        Me.tbp_visuAutomovel.Name = "tbp_visuAutomovel"
        Me.tbp_visuAutomovel.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_visuAutomovel.Size = New System.Drawing.Size(605, 235)
        Me.tbp_visuAutomovel.TabIndex = 0
        Me.tbp_visuAutomovel.Text = "Visualização"
        Me.tbp_visuAutomovel.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btn_novo)
        Me.GroupBox5.Controls.Add(Me.btn_alterar)
        Me.GroupBox5.Controls.Add(Me.btn_excluir)
        Me.GroupBox5.Location = New System.Drawing.Point(510, 23)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(88, 137)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        '
        'btn_novo
        '
        Me.btn_novo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_novo.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_novo.Location = New System.Drawing.Point(9, 13)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(73, 34)
        Me.btn_novo.TabIndex = 21
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.Modify
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(9, 52)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(73, 34)
        Me.btn_alterar.TabIndex = 23
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excluir.Location = New System.Drawing.Point(9, 91)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(73, 34)
        Me.btn_excluir.TabIndex = 24
        Me.btn_excluir.Text = " &Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbl_mensagem01)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 181)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(591, 40)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Mensagem"
        '
        'lbl_mensagem01
        '
        Me.lbl_mensagem01.AutoSize = True
        Me.lbl_mensagem01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem01.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem01.Location = New System.Drawing.Point(10, 17)
        Me.lbl_mensagem01.Name = "lbl_mensagem01"
        Me.lbl_mensagem01.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem01.TabIndex = 1
        Me.lbl_mensagem01.Text = ".   "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(20, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "   "
        '
        'Dtg_automovel
        '
        Me.Dtg_automovel.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtg_automovel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dtg_automovel.BackgroundColor = System.Drawing.Color.Gray
        Me.Dtg_automovel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dtg_automovel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.Dtg_automovel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dtg_automovel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dtg_automovel.ColumnHeadersHeight = 28
        Me.Dtg_automovel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dtg_automovel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idComodato, Me.placa, Me.descricao, Me.fornecedor})
        Me.Dtg_automovel.Location = New System.Drawing.Point(10, 23)
        Me.Dtg_automovel.MultiSelect = False
        Me.Dtg_automovel.Name = "Dtg_automovel"
        Me.Dtg_automovel.ReadOnly = True
        Me.Dtg_automovel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Dtg_automovel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dtg_automovel.Size = New System.Drawing.Size(482, 148)
        Me.Dtg_automovel.TabIndex = 19
        '
        'idComodato
        '
        Me.idComodato.HeaderText = "id"
        Me.idComodato.Name = "idComodato"
        Me.idComodato.ReadOnly = True
        Me.idComodato.Visible = False
        '
        'placa
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.placa.DefaultCellStyle = DataGridViewCellStyle3
        Me.placa.HeaderText = "Placa"
        Me.placa.MaxInputLength = 12
        Me.placa.Name = "placa"
        Me.placa.ReadOnly = True
        Me.placa.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.placa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'descricao
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descricao.DefaultCellStyle = DataGridViewCellStyle4
        Me.descricao.HeaderText = "Descricao"
        Me.descricao.MaxInputLength = 40
        Me.descricao.Name = "descricao"
        Me.descricao.ReadOnly = True
        Me.descricao.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.descricao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.descricao.Width = 160
        '
        'fornecedor
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fornecedor.DefaultCellStyle = DataGridViewCellStyle5
        Me.fornecedor.HeaderText = "Fornecedor"
        Me.fornecedor.MaxInputLength = 80
        Me.fornecedor.Name = "fornecedor"
        Me.fornecedor.ReadOnly = True
        Me.fornecedor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.fornecedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fornecedor.Width = 307
        '
        'tbp_cadAutomovel
        '
        Me.tbp_cadAutomovel.Controls.Add(Me.GroupBox3)
        Me.tbp_cadAutomovel.Controls.Add(Me.GroupBox2)
        Me.tbp_cadAutomovel.Controls.Add(Me.GroupBox1)
        Me.tbp_cadAutomovel.Location = New System.Drawing.Point(4, 22)
        Me.tbp_cadAutomovel.Name = "tbp_cadAutomovel"
        Me.tbp_cadAutomovel.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_cadAutomovel.Size = New System.Drawing.Size(605, 235)
        Me.tbp_cadAutomovel.TabIndex = 1
        Me.tbp_cadAutomovel.Text = "Cadastro"
        Me.tbp_cadAutomovel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 126)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(417, 60)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(10, 24)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(19, 15)
        Me.lbl_mensagem.TabIndex = 12
        Me.lbl_mensagem.Text = ".   "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_salvar)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Location = New System.Drawing.Point(432, 126)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(164, 60)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'btn_salvar
        '
        Me.btn_salvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salvar.Image = Global.MetroSys.My.Resources.Resources.Save
        Me.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salvar.Location = New System.Drawing.Point(6, 13)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(75, 42)
        Me.btn_salvar.TabIndex = 9
        Me.btn_salvar.Text = "&Salvar"
        Me.btn_salvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.MetroSys.My.Resources.Resources.cancelar
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(87, 13)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(71, 42)
        Me.btn_cancelar.TabIndex = 18
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_codPart)
        Me.GroupBox1.Controls.Add(Me.txt_codAutomovel)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_descricao)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_nomePart)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_placa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(587, 111)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Location = New System.Drawing.Point(87, 40)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(61, 20)
        Me.txt_codPart.TabIndex = 6
        '
        'txt_codAutomovel
        '
        Me.txt_codAutomovel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codAutomovel.Location = New System.Drawing.Point(87, 14)
        Me.txt_codAutomovel.MaxLength = 5
        Me.txt_codAutomovel.Name = "txt_codAutomovel"
        Me.txt_codAutomovel.ReadOnly = True
        Me.txt_codAutomovel.Size = New System.Drawing.Size(62, 20)
        Me.txt_codAutomovel.TabIndex = 0
        Me.txt_codAutomovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Codigo:"
        '
        'txt_descricao
        '
        Me.txt_descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_descricao.Location = New System.Drawing.Point(87, 69)
        Me.txt_descricao.MaxLength = 40
        Me.txt_descricao.Name = "txt_descricao"
        Me.txt_descricao.Size = New System.Drawing.Size(408, 20)
        Me.txt_descricao.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Descrição:"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Location = New System.Drawing.Point(154, 40)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(341, 20)
        Me.txt_nomePart.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fornecedor:"
        '
        'txt_placa
        '
        Me.txt_placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_placa.Location = New System.Drawing.Point(218, 14)
        Me.txt_placa.MaxLength = 12
        Me.txt_placa.Name = "txt_placa"
        Me.txt_placa.Size = New System.Drawing.Size(98, 20)
        Me.txt_placa.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(172, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Placa :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-3, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(627, 74)
        Me.Panel1.TabIndex = 7
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(509, 40)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(93, 22)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(226, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(156, 58)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(502, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Frm_cadAutomovel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 338)
        Me.Controls.Add(Me.tbc_Automovels)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_cadAutomovel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção Automóvel"
        Me.tbc_Automovels.ResumeLayout(False)
        Me.tbp_visuAutomovel.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.Dtg_automovel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbp_cadAutomovel.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbc_Automovels As System.Windows.Forms.TabControl
    Friend WithEvents tbp_visuAutomovel As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem01 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents Dtg_automovel As System.Windows.Forms.DataGridView
    Friend WithEvents tbp_cadAutomovel As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Friend WithEvents txt_codAutomovel As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_descricao As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_placa As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents idComodato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents placa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fornecedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
