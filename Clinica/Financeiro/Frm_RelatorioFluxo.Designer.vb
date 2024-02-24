<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RelatorioFluxo
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RelatorioFluxo))
        Me.lbl_opcao = New System.Windows.Forms.Label()
        Me.lbl_periodo = New System.Windows.Forms.Label()
        Me.dtg_pedidos = New System.Windows.Forms.DataGridView()
        Me.nt_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nt_geno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nt_orca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nt_dtemis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nt_codig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_portad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_cid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_uf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tgeral = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nt_vend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nt_sit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mapa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.entrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tiposelec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbo_opcoes = New System.Windows.Forms.ComboBox()
        Me.msk_periodoFinal = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbo_tiporelatorio = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grp_pesquisa = New System.Windows.Forms.GroupBox()
        Me.msk_pesquisa = New System.Windows.Forms.MaskedTextBox()
        Me.pdRelatPedidos = New System.Drawing.Printing.PrintDocument()
        Me.pdRelatorios = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.btn_busca = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_imprime = New System.Windows.Forms.Button()
        Me.btn_sair = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        CType(Me.dtg_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grp_pesquisa.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_opcao
        '
        Me.lbl_opcao.AutoSize = True
        Me.lbl_opcao.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_opcao.Location = New System.Drawing.Point(18, 20)
        Me.lbl_opcao.Name = "lbl_opcao"
        Me.lbl_opcao.Size = New System.Drawing.Size(61, 17)
        Me.lbl_opcao.TabIndex = 50
        Me.lbl_opcao.Text = "Opções:"
        '
        'lbl_periodo
        '
        Me.lbl_periodo.AutoSize = True
        Me.lbl_periodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_periodo.Location = New System.Drawing.Point(329, 20)
        Me.lbl_periodo.Name = "lbl_periodo"
        Me.lbl_periodo.Size = New System.Drawing.Size(18, 18)
        Me.lbl_periodo.TabIndex = 49
        Me.lbl_periodo.Text = "A"
        Me.lbl_periodo.Visible = False
        '
        'dtg_pedidos
        '
        Me.dtg_pedidos.AllowUserToAddRows = False
        Me.dtg_pedidos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow
        Me.dtg_pedidos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_pedidos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_pedidos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_pedidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_pedidos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_pedidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nt_id, Me.nt_geno, Me.nt_orca, Me.nt_dtemis, Me.nt_codig, Me.p_portad, Me.p_cid, Me.p_uf, Me.tgeral, Me.tipo, Me.nt_vend, Me.nt_sit, Me.mapa, Me.entrada, Me.tiposelec})
        Me.dtg_pedidos.Location = New System.Drawing.Point(9, 46)
        Me.dtg_pedidos.MultiSelect = False
        Me.dtg_pedidos.Name = "dtg_pedidos"
        Me.dtg_pedidos.ReadOnly = True
        Me.dtg_pedidos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_pedidos.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dtg_pedidos.Size = New System.Drawing.Size(876, 272)
        Me.dtg_pedidos.TabIndex = 49
        '
        'nt_id
        '
        Me.nt_id.HeaderText = "nt_id"
        Me.nt_id.Name = "nt_id"
        Me.nt_id.ReadOnly = True
        Me.nt_id.Visible = False
        '
        'nt_geno
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.nt_geno.DefaultCellStyle = DataGridViewCellStyle3
        Me.nt_geno.HeaderText = "Loja"
        Me.nt_geno.MaxInputLength = 6
        Me.nt_geno.Name = "nt_geno"
        Me.nt_geno.ReadOnly = True
        Me.nt_geno.Width = 60
        '
        'nt_orca
        '
        Me.nt_orca.HeaderText = "Pedido"
        Me.nt_orca.Name = "nt_orca"
        Me.nt_orca.ReadOnly = True
        '
        'nt_dtemis
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.nt_dtemis.DefaultCellStyle = DataGridViewCellStyle4
        Me.nt_dtemis.HeaderText = "Emissão"
        Me.nt_dtemis.Name = "nt_dtemis"
        Me.nt_dtemis.ReadOnly = True
        Me.nt_dtemis.Width = 90
        '
        'nt_codig
        '
        Me.nt_codig.HeaderText = "Codigo"
        Me.nt_codig.Name = "nt_codig"
        Me.nt_codig.ReadOnly = True
        Me.nt_codig.Visible = False
        Me.nt_codig.Width = 60
        '
        'p_portad
        '
        Me.p_portad.HeaderText = "Cliente"
        Me.p_portad.Name = "p_portad"
        Me.p_portad.ReadOnly = True
        Me.p_portad.Width = 392
        '
        'p_cid
        '
        Me.p_cid.HeaderText = "Cidade"
        Me.p_cid.Name = "p_cid"
        Me.p_cid.ReadOnly = True
        Me.p_cid.Visible = False
        '
        'p_uf
        '
        Me.p_uf.HeaderText = "UF"
        Me.p_uf.MaxInputLength = 2
        Me.p_uf.Name = "p_uf"
        Me.p_uf.ReadOnly = True
        Me.p_uf.Visible = False
        Me.p_uf.Width = 35
        '
        'tgeral
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.MediumBlue
        Me.tgeral.DefaultCellStyle = DataGridViewCellStyle5
        Me.tgeral.HeaderText = "Total R$"
        Me.tgeral.MaxInputLength = 16
        Me.tgeral.Name = "tgeral"
        Me.tgeral.ReadOnly = True
        Me.tgeral.Width = 110
        '
        'tipo
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.tipo.DefaultCellStyle = DataGridViewCellStyle6
        Me.tipo.HeaderText = "Tipo"
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.Width = 60
        '
        'nt_vend
        '
        Me.nt_vend.HeaderText = "Vendedor"
        Me.nt_vend.Name = "nt_vend"
        Me.nt_vend.ReadOnly = True
        Me.nt_vend.Visible = False
        Me.nt_vend.Width = 70
        '
        'nt_sit
        '
        Me.nt_sit.HeaderText = "Sit."
        Me.nt_sit.MaxInputLength = 3
        Me.nt_sit.Name = "nt_sit"
        Me.nt_sit.ReadOnly = True
        Me.nt_sit.Visible = False
        Me.nt_sit.Width = 40
        '
        'mapa
        '
        Me.mapa.HeaderText = "Mapa"
        Me.mapa.Name = "mapa"
        Me.mapa.ReadOnly = True
        Me.mapa.Visible = False
        '
        'entrada
        '
        Me.entrada.HeaderText = "Entrada"
        Me.entrada.Name = "entrada"
        Me.entrada.ReadOnly = True
        Me.entrada.Visible = False
        '
        'tiposelec
        '
        Me.tiposelec.HeaderText = "tiposelec"
        Me.tiposelec.Name = "tiposelec"
        Me.tiposelec.ReadOnly = True
        Me.tiposelec.Visible = False
        '
        'cbo_opcoes
        '
        Me.cbo_opcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_opcoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_opcoes.FormattingEnabled = True
        Me.cbo_opcoes.Items.AddRange(New Object() {"N. Pedido", "Data", "Cliente"})
        Me.cbo_opcoes.Location = New System.Drawing.Point(89, 17)
        Me.cbo_opcoes.Name = "cbo_opcoes"
        Me.cbo_opcoes.Size = New System.Drawing.Size(134, 24)
        Me.cbo_opcoes.TabIndex = 11
        '
        'msk_periodoFinal
        '
        Me.msk_periodoFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_periodoFinal.Location = New System.Drawing.Point(353, 17)
        Me.msk_periodoFinal.Name = "msk_periodoFinal"
        Me.msk_periodoFinal.Size = New System.Drawing.Size(77, 22)
        Me.msk_periodoFinal.TabIndex = 15
        Me.msk_periodoFinal.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo_tiporelatorio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.grp_pesquisa)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 324)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(596, 105)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cbo_tiporelatorio
        '
        Me.cbo_tiporelatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tiporelatorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_tiporelatorio.FormattingEnabled = True
        Me.cbo_tiporelatorio.Items.AddRange(New Object() {"Sintético", "Analítico", "Arquivo", "Movimento Caixa", "Movimento Diario Período", "Movimento Diario Dia"})
        Me.cbo_tiporelatorio.Location = New System.Drawing.Point(98, 16)
        Me.cbo_tiporelatorio.Name = "cbo_tiporelatorio"
        Me.cbo_tiporelatorio.Size = New System.Drawing.Size(231, 23)
        Me.cbo_tiporelatorio.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Relatório:"
        '
        'grp_pesquisa
        '
        Me.grp_pesquisa.Controls.Add(Me.lbl_opcao)
        Me.grp_pesquisa.Controls.Add(Me.msk_pesquisa)
        Me.grp_pesquisa.Controls.Add(Me.lbl_periodo)
        Me.grp_pesquisa.Controls.Add(Me.msk_periodoFinal)
        Me.grp_pesquisa.Controls.Add(Me.cbo_opcoes)
        Me.grp_pesquisa.Location = New System.Drawing.Point(9, 49)
        Me.grp_pesquisa.Name = "grp_pesquisa"
        Me.grp_pesquisa.Size = New System.Drawing.Size(581, 47)
        Me.grp_pesquisa.TabIndex = 7
        Me.grp_pesquisa.TabStop = False
        Me.grp_pesquisa.Text = "Opções de Pesquisa"
        '
        'msk_pesquisa
        '
        Me.msk_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_pesquisa.Location = New System.Drawing.Point(243, 17)
        Me.msk_pesquisa.Name = "msk_pesquisa"
        Me.msk_pesquisa.Size = New System.Drawing.Size(77, 22)
        Me.msk_pesquisa.TabIndex = 13
        '
        'pdRelatPedidos
        '
        '
        'pdRelatorios
        '
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
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'btn_busca
        '
        Me.btn_busca.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_busca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_busca.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_busca.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_busca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_busca.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_busca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_busca.Image = Global.RTecSys.My.Resources.Resources.Search
        Me.btn_busca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_busca.Location = New System.Drawing.Point(7, 31)
        Me.btn_busca.Name = "btn_busca"
        Me.btn_busca.Size = New System.Drawing.Size(82, 57)
        Me.btn_busca.TabIndex = 23
        Me.btn_busca.Text = "&Busca"
        Me.btn_busca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_busca.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_busca)
        Me.GroupBox2.Controls.Add(Me.btn_imprime)
        Me.GroupBox2.Controls.Add(Me.btn_sair)
        Me.GroupBox2.Location = New System.Drawing.Point(612, 324)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(273, 105)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        '
        'btn_imprime
        '
        Me.btn_imprime.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_imprime.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_imprime.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_imprime.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_imprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_imprime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_imprime.Image = Global.RTecSys.My.Resources.Resources.Imprime
        Me.btn_imprime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_imprime.Location = New System.Drawing.Point(96, 31)
        Me.btn_imprime.Name = "btn_imprime"
        Me.btn_imprime.Size = New System.Drawing.Size(94, 57)
        Me.btn_imprime.TabIndex = 25
        Me.btn_imprime.Text = "&Imprime"
        Me.btn_imprime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprime.UseVisualStyleBackColor = False
        '
        'btn_sair
        '
        Me.btn_sair.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_sair.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_sair.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_sair.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sair.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_sair.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_sair.Image = Global.RTecSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sair.Location = New System.Drawing.Point(198, 31)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(69, 57)
        Me.btn_sair.TabIndex = 27
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sair.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-5, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(906, 42)
        Me.Panel1.TabIndex = 55
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(389, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Frm_RelatorioFluxo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 443)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtg_pedidos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_RelatorioFluxo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatóro de Fluxo do Caixa"
        CType(Me.dtg_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp_pesquisa.ResumeLayout(False)
        Me.grp_pesquisa.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_opcao As System.Windows.Forms.Label
    Friend WithEvents lbl_periodo As System.Windows.Forms.Label
    Public WithEvents dtg_pedidos As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_opcoes As System.Windows.Forms.ComboBox
    Friend WithEvents msk_periodoFinal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents msk_pesquisa As System.Windows.Forms.MaskedTextBox
    Friend WithEvents pdRelatPedidos As System.Drawing.Printing.PrintDocument
    Friend WithEvents pdRelatorios As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Public WithEvents btn_busca As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents btn_imprime As System.Windows.Forms.Button
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents grp_pesquisa As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_tiporelatorio As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nt_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_geno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_orca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_dtemis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_codig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_portad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_cid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_uf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tgeral As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_vend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_sit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mapa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents entrada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tiposelec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
End Class
