<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManRetorMp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManRetorMp))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtp_final = New System.Windows.Forms.DateTimePicker
        Me.dtp_inicio = New System.Windows.Forms.DateTimePicker
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbo_natureza = New System.Windows.Forms.ComboBox
        Me.cbo_verPor = New System.Windows.Forms.ComboBox
        Me.cbo_loja = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_incluir = New System.Windows.Forms.Button
        Me.dtg_retornos = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Loja = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PEDIDO_MAPA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MAPA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NATUREZA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DtEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codCli = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.OpConsTsmItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RelatoriosDasNotasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.grp_opRelatorios = New System.Windows.Forms.GroupBox
        Me.ts_relatorios = New System.Windows.Forms.ToolStrip
        Me.tSlpB_relatorios = New System.Windows.Forms.ToolStripSplitButton
        Me.rmi_ralatIndividual = New System.Windows.Forms.ToolStripMenuItem
        Me.rmi_ralatConsulta = New System.Windows.Forms.ToolStripMenuItem
        Me.rmi_ralatComissao = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtg_retornos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grp_opRelatorios.SuspendLayout()
        Me.ts_relatorios.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_numero)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.dtp_final)
        Me.GroupBox3.Controls.Add(Me.dtp_inicio)
        Me.GroupBox3.Controls.Add(Me.btn_buscar)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.cbo_natureza)
        Me.GroupBox3.Controls.Add(Me.cbo_verPor)
        Me.GroupBox3.Controls.Add(Me.cbo_loja)
        Me.GroupBox3.Location = New System.Drawing.Point(25, 90)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(682, 73)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        '
        'txt_numero
        '
        Me.txt_numero.Enabled = False
        Me.txt_numero.Location = New System.Drawing.Point(400, 47)
        Me.txt_numero.MaxLength = 10
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(100, 20)
        Me.txt_numero.TabIndex = 10
        Me.txt_numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(347, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Numero:"
        '
        'dtp_final
        '
        Me.dtp_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_final.Location = New System.Drawing.Point(197, 47)
        Me.dtp_final.Name = "dtp_final"
        Me.dtp_final.Size = New System.Drawing.Size(105, 20)
        Me.dtp_final.TabIndex = 8
        '
        'dtp_inicio
        '
        Me.dtp_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_inicio.Location = New System.Drawing.Point(58, 47)
        Me.dtp_inicio.Name = "dtp_inicio"
        Me.dtp_inicio.Size = New System.Drawing.Size(103, 20)
        Me.dtp_inicio.TabIndex = 6
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = Global.MetroSys.My.Resources.Resources.Busca_16x16
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.Location = New System.Drawing.Point(567, 36)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(106, 35)
        Me.btn_buscar.TabIndex = 12
        Me.btn_buscar.Text = "&Buscar [F5]"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Periodo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(341, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Natureza:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(149, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ver por:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Loja:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(175, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "A"
        '
        'cbo_natureza
        '
        Me.cbo_natureza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_natureza.FormattingEnabled = True
        Me.cbo_natureza.Items.AddRange(New Object() {"Todos", "Venda", "Troca", "Devolucao", "Outros"})
        Me.cbo_natureza.Location = New System.Drawing.Point(400, 18)
        Me.cbo_natureza.Name = "cbo_natureza"
        Me.cbo_natureza.Size = New System.Drawing.Size(103, 21)
        Me.cbo_natureza.TabIndex = 4
        '
        'cbo_verPor
        '
        Me.cbo_verPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_verPor.FormattingEnabled = True
        Me.cbo_verPor.Items.AddRange(New Object() {"Todos", "Pedido", "Mapa"})
        Me.cbo_verPor.Location = New System.Drawing.Point(199, 18)
        Me.cbo_verPor.Name = "cbo_verPor"
        Me.cbo_verPor.Size = New System.Drawing.Size(103, 21)
        Me.cbo_verPor.TabIndex = 2
        '
        'cbo_loja
        '
        Me.cbo_loja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_loja.FormattingEnabled = True
        Me.cbo_loja.Items.AddRange(New Object() {"01", "02", "03", "04"})
        Me.cbo_loja.Location = New System.Drawing.Point(58, 18)
        Me.cbo_loja.Name = "cbo_loja"
        Me.cbo_loja.Size = New System.Drawing.Size(78, 21)
        Me.cbo_loja.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(727, 80)
        Me.Panel1.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label5.Font = New System.Drawing.Font("Wide Latin", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(519, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 22)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "MetroSys"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(234, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(196, 57)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_incluir)
        Me.GroupBox2.Location = New System.Drawing.Point(582, 167)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(125, 55)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        '
        'btn_incluir
        '
        Me.btn_incluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_incluir.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_incluir.Location = New System.Drawing.Point(10, 15)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(106, 35)
        Me.btn_incluir.TabIndex = 16
        Me.btn_incluir.Text = "Incluir [F2]"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'dtg_retornos
        '
        Me.dtg_retornos.AllowUserToAddRows = False
        Me.dtg_retornos.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Aquamarine
        Me.dtg_retornos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_retornos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_retornos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_retornos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtg_retornos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_retornos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Loja, Me.PEDIDO_MAPA, Me.MAPA, Me.CLIENTE, Me.NATUREZA, Me.DtEntrega, Me.TOTAL, Me.codCli})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_retornos.DefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_retornos.Location = New System.Drawing.Point(25, 169)
        Me.dtg_retornos.Name = "dtg_retornos"
        Me.dtg_retornos.ReadOnly = True
        Me.dtg_retornos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_retornos.Size = New System.Drawing.Size(551, 301)
        Me.dtg_retornos.TabIndex = 22
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Loja
        '
        Me.Loja.HeaderText = "Loja"
        Me.Loja.MaxInputLength = 2
        Me.Loja.Name = "Loja"
        Me.Loja.ReadOnly = True
        Me.Loja.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Loja.Width = 40
        '
        'PEDIDO_MAPA
        '
        Me.PEDIDO_MAPA.HeaderText = "PEDIDO_MAPA"
        Me.PEDIDO_MAPA.MaxInputLength = 10
        Me.PEDIDO_MAPA.Name = "PEDIDO_MAPA"
        Me.PEDIDO_MAPA.ReadOnly = True
        Me.PEDIDO_MAPA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PEDIDO_MAPA.Width = 90
        '
        'MAPA
        '
        Me.MAPA.HeaderText = "MAPA"
        Me.MAPA.MaxInputLength = 10
        Me.MAPA.Name = "MAPA"
        Me.MAPA.ReadOnly = True
        Me.MAPA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MAPA.Width = 90
        '
        'CLIENTE
        '
        Me.CLIENTE.HeaderText = "CLIENTE"
        Me.CLIENTE.MaxInputLength = 80
        Me.CLIENTE.Name = "CLIENTE"
        Me.CLIENTE.ReadOnly = True
        Me.CLIENTE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CLIENTE.Width = 230
        '
        'NATUREZA
        '
        Me.NATUREZA.HeaderText = "NATUREZA"
        Me.NATUREZA.MaxInputLength = 20
        Me.NATUREZA.Name = "NATUREZA"
        Me.NATUREZA.ReadOnly = True
        Me.NATUREZA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NATUREZA.Width = 90
        '
        'DtEntrega
        '
        Me.DtEntrega.HeaderText = "DtEntrega"
        Me.DtEntrega.MaxInputLength = 10
        Me.DtEntrega.Name = "DtEntrega"
        Me.DtEntrega.ReadOnly = True
        Me.DtEntrega.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DtEntrega.Width = 90
        '
        'TOTAL
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle7.NullValue = "0.00"
        Me.TOTAL.DefaultCellStyle = DataGridViewCellStyle7
        Me.TOTAL.HeaderText = "TOTAL R$"
        Me.TOTAL.MaxInputLength = 14
        Me.TOTAL.Name = "TOTAL"
        Me.TOTAL.ReadOnly = True
        Me.TOTAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'codCli
        '
        Me.codCli.HeaderText = "codCli"
        Me.codCli.Name = "codCli"
        Me.codCli.ReadOnly = True
        Me.codCli.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 476)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(682, 53)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(13, 19)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem.TabIndex = 13
        Me.lbl_mensagem.Text = ".   "
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
        'OpConsTsmItem
        '
        Me.OpConsTsmItem.BackColor = System.Drawing.Color.Transparent
        Me.OpConsTsmItem.Name = "OpConsTsmItem"
        Me.OpConsTsmItem.Size = New System.Drawing.Size(255, 22)
        Me.OpConsTsmItem.Text = "Espelho da(s) Nota(s)"
        '
        'RelatoriosDasNotasToolStripMenuItem
        '
        Me.RelatoriosDasNotasToolStripMenuItem.Name = "RelatoriosDasNotasToolStripMenuItem"
        Me.RelatoriosDasNotasToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.RelatoriosDasNotasToolStripMenuItem.Text = "Relatorios das Notas"
        '
        'grp_opRelatorios
        '
        Me.grp_opRelatorios.Controls.Add(Me.ts_relatorios)
        Me.grp_opRelatorios.Location = New System.Drawing.Point(582, 228)
        Me.grp_opRelatorios.Name = "grp_opRelatorios"
        Me.grp_opRelatorios.Size = New System.Drawing.Size(125, 43)
        Me.grp_opRelatorios.TabIndex = 26
        Me.grp_opRelatorios.TabStop = False
        Me.grp_opRelatorios.Text = "Opções"
        '
        'ts_relatorios
        '
        Me.ts_relatorios.BackColor = System.Drawing.Color.Transparent
        Me.ts_relatorios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ts_relatorios.Dock = System.Windows.Forms.DockStyle.None
        Me.ts_relatorios.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ts_relatorios.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ts_relatorios.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tSlpB_relatorios})
        Me.ts_relatorios.Location = New System.Drawing.Point(3, 14)
        Me.ts_relatorios.Name = "ts_relatorios"
        Me.ts_relatorios.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ts_relatorios.Size = New System.Drawing.Size(151, 25)
        Me.ts_relatorios.TabIndex = 0
        '
        'tSlpB_relatorios
        '
        Me.tSlpB_relatorios.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tSlpB_relatorios.BackColor = System.Drawing.Color.Transparent
        Me.tSlpB_relatorios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tSlpB_relatorios.DropDownButtonWidth = 17
        Me.tSlpB_relatorios.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.rmi_ralatIndividual, Me.rmi_ralatConsulta, Me.rmi_ralatComissao})
        Me.tSlpB_relatorios.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.tSlpB_relatorios.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.tSlpB_relatorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tSlpB_relatorios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tSlpB_relatorios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tSlpB_relatorios.Name = "tSlpB_relatorios"
        Me.tSlpB_relatorios.Size = New System.Drawing.Size(117, 22)
        Me.tSlpB_relatorios.Text = "&Relatórios"
        Me.tSlpB_relatorios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rmi_ralatIndividual
        '
        Me.rmi_ralatIndividual.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.rmi_ralatIndividual.Name = "rmi_ralatIndividual"
        Me.rmi_ralatIndividual.Size = New System.Drawing.Size(238, 22)
        Me.rmi_ralatIndividual.Text = "&Relatório Individual"
        '
        'rmi_ralatConsulta
        '
        Me.rmi_ralatConsulta.Name = "rmi_ralatConsulta"
        Me.rmi_ralatConsulta.Size = New System.Drawing.Size(238, 22)
        Me.rmi_ralatConsulta.Text = "Relatório da Consulta"
        '
        'rmi_ralatComissao
        '
        Me.rmi_ralatComissao.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.rmi_ralatComissao.Name = "rmi_ralatComissao"
        Me.rmi_ralatComissao.Size = New System.Drawing.Size(238, 22)
        Me.rmi_ralatComissao.Text = "&Relatório Comissão"
        '
        'Frm_ManRetorMp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 533)
        Me.Controls.Add(Me.grp_opRelatorios)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dtg_retornos)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ManRetorMp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção do Retorno de Vendas"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dtg_retornos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp_opRelatorios.ResumeLayout(False)
        Me.grp_opRelatorios.PerformLayout()
        Me.ts_relatorios.ResumeLayout(False)
        Me.ts_relatorios.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_loja As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents dtg_retornos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_verPor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbo_natureza As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents OpConsTsmItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelatoriosDasNotasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grp_opRelatorios As System.Windows.Forms.GroupBox
    Friend WithEvents ts_relatorios As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_relatIndividual As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_relatConsulta As System.Windows.Forms.ToolStripButton
    Friend WithEvents tSlpB_relatorios As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents rmi_ralatIndividual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rmi_ralatConsulta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Loja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PEDIDO_MAPA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MAPA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NATUREZA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DtEntrega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codCli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rmi_ralatComissao As System.Windows.Forms.ToolStripMenuItem
End Class
