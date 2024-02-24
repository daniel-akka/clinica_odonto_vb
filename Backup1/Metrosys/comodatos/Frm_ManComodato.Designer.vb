<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManComodato
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManComodato))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label26 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.tbc_comodatos = New System.Windows.Forms.TabControl
        Me.tbp_visuComodato = New System.Windows.Forms.TabPage
        Me.grp_opcoes = New System.Windows.Forms.GroupBox
        Me.cbo_tipoPesq = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem01 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.btn_novo = New System.Windows.Forms.Button
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.Dtg_Comodatos = New System.Windows.Forms.DataGridView
        Me.idComodato = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.modelo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.plaquete = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tbp_cadComodato = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_salvar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_codPart = New System.Windows.Forms.TextBox
        Me.txt_codComodato = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_observacao = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_plaqueta = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_modelo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_tipo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbc_comodatos.SuspendLayout()
        Me.tbp_visuComodato.SuspendLayout()
        Me.grp_opcoes.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Dtg_Comodatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbp_cadComodato.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Wide Latin", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(444, 40)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(167, 22)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-2, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(627, 74)
        Me.Panel1.TabIndex = 5
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
        'tbc_comodatos
        '
        Me.tbc_comodatos.Controls.Add(Me.tbp_visuComodato)
        Me.tbc_comodatos.Controls.Add(Me.tbp_cadComodato)
        Me.tbc_comodatos.Location = New System.Drawing.Point(6, 71)
        Me.tbc_comodatos.Name = "tbc_comodatos"
        Me.tbc_comodatos.SelectedIndex = 0
        Me.tbc_comodatos.Size = New System.Drawing.Size(613, 307)
        Me.tbc_comodatos.TabIndex = 6
        '
        'tbp_visuComodato
        '
        Me.tbp_visuComodato.Controls.Add(Me.grp_opcoes)
        Me.tbp_visuComodato.Controls.Add(Me.GroupBox4)
        Me.tbp_visuComodato.Controls.Add(Me.btn_excluir)
        Me.tbp_visuComodato.Controls.Add(Me.btn_novo)
        Me.tbp_visuComodato.Controls.Add(Me.btn_alterar)
        Me.tbp_visuComodato.Controls.Add(Me.Dtg_Comodatos)
        Me.tbp_visuComodato.Location = New System.Drawing.Point(4, 22)
        Me.tbp_visuComodato.Name = "tbp_visuComodato"
        Me.tbp_visuComodato.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_visuComodato.Size = New System.Drawing.Size(605, 281)
        Me.tbp_visuComodato.TabIndex = 0
        Me.tbp_visuComodato.Text = "Visualização"
        Me.tbp_visuComodato.UseVisualStyleBackColor = True
        '
        'grp_opcoes
        '
        Me.grp_opcoes.Controls.Add(Me.cbo_tipoPesq)
        Me.grp_opcoes.Controls.Add(Me.Label7)
        Me.grp_opcoes.Location = New System.Drawing.Point(10, 6)
        Me.grp_opcoes.Name = "grp_opcoes"
        Me.grp_opcoes.Size = New System.Drawing.Size(361, 40)
        Me.grp_opcoes.TabIndex = 28
        Me.grp_opcoes.TabStop = False
        Me.grp_opcoes.Text = "Opções"
        '
        'cbo_tipoPesq
        '
        Me.cbo_tipoPesq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipoPesq.FormattingEnabled = True
        Me.cbo_tipoPesq.Items.AddRange(New Object() {"00 - Todos", "01 - Freezer", "02 - Outros"})
        Me.cbo_tipoPesq.Location = New System.Drawing.Point(48, 14)
        Me.cbo_tipoPesq.Name = "cbo_tipoPesq"
        Me.cbo_tipoPesq.Size = New System.Drawing.Size(94, 21)
        Me.cbo_tipoPesq.TabIndex = 29
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Tipo:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbl_mensagem01)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 232)
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
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excluir.Location = New System.Drawing.Point(522, 12)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(73, 34)
        Me.btn_excluir.TabIndex = 24
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_novo
        '
        Me.btn_novo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_novo.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_novo.Location = New System.Drawing.Point(377, 12)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(65, 34)
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
        Me.btn_alterar.Location = New System.Drawing.Point(446, 12)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(72, 34)
        Me.btn_alterar.TabIndex = 23
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'Dtg_Comodatos
        '
        Me.Dtg_Comodatos.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtg_Comodatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dtg_Comodatos.BackgroundColor = System.Drawing.Color.Gray
        Me.Dtg_Comodatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dtg_Comodatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.Dtg_Comodatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dtg_Comodatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dtg_Comodatos.ColumnHeadersHeight = 28
        Me.Dtg_Comodatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dtg_Comodatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idComodato, Me.tipo, Me.cliente, Me.modelo, Me.plaquete})
        Me.Dtg_Comodatos.Location = New System.Drawing.Point(10, 65)
        Me.Dtg_Comodatos.MultiSelect = False
        Me.Dtg_Comodatos.Name = "Dtg_Comodatos"
        Me.Dtg_Comodatos.ReadOnly = True
        Me.Dtg_Comodatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Dtg_Comodatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dtg_Comodatos.Size = New System.Drawing.Size(583, 166)
        Me.Dtg_Comodatos.TabIndex = 19
        '
        'idComodato
        '
        Me.idComodato.HeaderText = "id"
        Me.idComodato.Name = "idComodato"
        Me.idComodato.ReadOnly = True
        Me.idComodato.Visible = False
        '
        'tipo
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo.DefaultCellStyle = DataGridViewCellStyle3
        Me.tipo.HeaderText = "Tipo"
        Me.tipo.MaxInputLength = 6
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tipo.Width = 72
        '
        'cliente
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cliente.DefaultCellStyle = DataGridViewCellStyle4
        Me.cliente.HeaderText = "Cliente"
        Me.cliente.MaxInputLength = 80
        Me.cliente.Name = "cliente"
        Me.cliente.ReadOnly = True
        Me.cliente.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cliente.Width = 307
        '
        'modelo
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modelo.DefaultCellStyle = DataGridViewCellStyle5
        Me.modelo.HeaderText = "Modelo"
        Me.modelo.MaxInputLength = 14
        Me.modelo.Name = "modelo"
        Me.modelo.ReadOnly = True
        Me.modelo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.modelo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.modelo.Visible = False
        Me.modelo.Width = 140
        '
        'plaquete
        '
        Me.plaquete.HeaderText = "Plaqueta"
        Me.plaquete.MaxInputLength = 80
        Me.plaquete.Name = "plaquete"
        Me.plaquete.ReadOnly = True
        Me.plaquete.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.plaquete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.plaquete.Width = 160
        '
        'tbp_cadComodato
        '
        Me.tbp_cadComodato.Controls.Add(Me.GroupBox3)
        Me.tbp_cadComodato.Controls.Add(Me.GroupBox2)
        Me.tbp_cadComodato.Controls.Add(Me.GroupBox1)
        Me.tbp_cadComodato.Location = New System.Drawing.Point(4, 22)
        Me.tbp_cadComodato.Name = "tbp_cadComodato"
        Me.tbp_cadComodato.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_cadComodato.Size = New System.Drawing.Size(605, 281)
        Me.tbp_cadComodato.TabIndex = 1
        Me.tbp_cadComodato.Text = "Cadastro"
        Me.tbp_cadComodato.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 206)
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
        Me.lbl_mensagem.Location = New System.Drawing.Point(20, 27)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(19, 15)
        Me.lbl_mensagem.TabIndex = 12
        Me.lbl_mensagem.Text = ".   "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_salvar)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Location = New System.Drawing.Point(432, 206)
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
        Me.GroupBox1.Controls.Add(Me.txt_codComodato)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_observacao)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_plaqueta)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_nomePart)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_modelo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbo_tipo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(587, 176)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Location = New System.Drawing.Point(87, 71)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(61, 20)
        Me.txt_codPart.TabIndex = 6
        '
        'txt_codComodato
        '
        Me.txt_codComodato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codComodato.Location = New System.Drawing.Point(87, 14)
        Me.txt_codComodato.MaxLength = 5
        Me.txt_codComodato.Name = "txt_codComodato"
        Me.txt_codComodato.ReadOnly = True
        Me.txt_codComodato.Size = New System.Drawing.Size(62, 20)
        Me.txt_codComodato.TabIndex = 0
        Me.txt_codComodato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txt_observacao
        '
        Me.txt_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_observacao.Location = New System.Drawing.Point(87, 126)
        Me.txt_observacao.MaxLength = 40
        Me.txt_observacao.Name = "txt_observacao"
        Me.txt_observacao.Size = New System.Drawing.Size(408, 20)
        Me.txt_observacao.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Observação:"
        '
        'txt_plaqueta
        '
        Me.txt_plaqueta.Location = New System.Drawing.Point(87, 99)
        Me.txt_plaqueta.MaxLength = 20
        Me.txt_plaqueta.Name = "txt_plaqueta"
        Me.txt_plaqueta.Size = New System.Drawing.Size(111, 20)
        Me.txt_plaqueta.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Plaqueta:"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Location = New System.Drawing.Point(154, 71)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(341, 20)
        Me.txt_nomePart.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fornecedor:"
        '
        'txt_modelo
        '
        Me.txt_modelo.Location = New System.Drawing.Point(87, 43)
        Me.txt_modelo.MaxLength = 25
        Me.txt_modelo.Name = "txt_modelo"
        Me.txt_modelo.Size = New System.Drawing.Size(179, 20)
        Me.txt_modelo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Modelo :"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"01 - Freezer", "02 - Outros"})
        Me.cbo_tipo.Location = New System.Drawing.Point(221, 13)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(94, 21)
        Me.cbo_tipo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(184, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo:"
        '
        'Frm_ManComodato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 384)
        Me.Controls.Add(Me.tbc_comodatos)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ManComodato"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção de Comodatos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbc_comodatos.ResumeLayout(False)
        Me.tbp_visuComodato.ResumeLayout(False)
        Me.grp_opcoes.ResumeLayout(False)
        Me.grp_opcoes.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.Dtg_Comodatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbp_cadComodato.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents tbc_comodatos As System.Windows.Forms.TabControl
    Friend WithEvents tbp_visuComodato As System.Windows.Forms.TabPage
    Friend WithEvents tbp_cadComodato As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_codComodato As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_observacao As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_plaqueta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_modelo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtg_Comodatos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem01 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents grp_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_tipoPesq As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents idComodato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents modelo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents plaquete As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
