<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GeraNotasFiscais
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GeraNotasFiscais))
        Me.dtg_nfe = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_corrigeOutrasNFe = New System.Windows.Forms.Button
        Me.btn_nfeMapa = New System.Windows.Forms.Button
        Me.btn_geraDanfe = New System.Windows.Forms.Button
        Me.btn_cce = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_recibo = New System.Windows.Forms.Button
        Me.btn_inutiliza = New System.Windows.Forms.Button
        Me.btn_corrigeNFe = New System.Windows.Forms.Button
        Me.btn_imprime = New System.Windows.Forms.Button
        Me.btn_nfeOutras = New System.Windows.Forms.Button
        Me.btn_nfe = New System.Windows.Forms.Button
        Me.sstrip = New System.Windows.Forms.StatusStrip
        Me.tsb_opcoes = New System.Windows.Forms.ToolStripSplitButton
        Me.opt_nome = New System.Windows.Forms.ToolStripMenuItem
        Me.opt_CnpjCpf = New System.Windows.Forms.ToolStripMenuItem
        Me.opt_data = New System.Windows.Forms.ToolStripMenuItem
        Me.opt_numero = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.PorPeriodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PorCNPJCPFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PorClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.lbl_comandos = New System.Windows.Forms.Label
        Me.nt_x = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_emissao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_cnpj_cpf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_portador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_chave = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_proto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.seqcce = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.numpedido = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dtg_nfe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.sstrip.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_nfe
        '
        Me.dtg_nfe.AllowUserToAddRows = False
        Me.dtg_nfe.AllowUserToDeleteRows = False
        Me.dtg_nfe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_nfe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_nfe.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_nfe.ColumnHeadersHeight = 24
        Me.dtg_nfe.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nt_x, Me.nt_Codigo, Me.nt_emissao, Me.nt_cnpj_cpf, Me.nt_portador, Me.nt_chave, Me.nt_proto, Me.seqcce, Me.numpedido})
        Me.dtg_nfe.Location = New System.Drawing.Point(11, 86)
        Me.dtg_nfe.MultiSelect = False
        Me.dtg_nfe.Name = "dtg_nfe"
        Me.dtg_nfe.ReadOnly = True
        Me.dtg_nfe.Size = New System.Drawing.Size(991, 390)
        Me.dtg_nfe.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_corrigeOutrasNFe)
        Me.GroupBox1.Controls.Add(Me.btn_nfeMapa)
        Me.GroupBox1.Controls.Add(Me.btn_geraDanfe)
        Me.GroupBox1.Controls.Add(Me.btn_cce)
        Me.GroupBox1.Controls.Add(Me.btn_cancelar)
        Me.GroupBox1.Controls.Add(Me.btn_recibo)
        Me.GroupBox1.Controls.Add(Me.btn_inutiliza)
        Me.GroupBox1.Controls.Add(Me.btn_corrigeNFe)
        Me.GroupBox1.Controls.Add(Me.btn_imprime)
        Me.GroupBox1.Controls.Add(Me.btn_nfeOutras)
        Me.GroupBox1.Controls.Add(Me.btn_nfe)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 481)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(991, 58)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'btn_corrigeOutrasNFe
        '
        Me.btn_corrigeOutrasNFe.Image = Global.MetroSys.My.Resources.Resources.ok_16x16
        Me.btn_corrigeOutrasNFe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_corrigeOutrasNFe.Location = New System.Drawing.Point(187, 10)
        Me.btn_corrigeOutrasNFe.Name = "btn_corrigeOutrasNFe"
        Me.btn_corrigeOutrasNFe.Size = New System.Drawing.Size(96, 43)
        Me.btn_corrigeOutrasNFe.TabIndex = 15
        Me.btn_corrigeOutrasNFe.Text = "&Corrige Outras"
        Me.btn_corrigeOutrasNFe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_corrigeOutrasNFe.UseVisualStyleBackColor = True
        '
        'btn_nfeMapa
        '
        Me.btn_nfeMapa.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_nfeMapa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nfeMapa.Location = New System.Drawing.Point(294, 10)
        Me.btn_nfeMapa.Name = "btn_nfeMapa"
        Me.btn_nfeMapa.Size = New System.Drawing.Size(79, 43)
        Me.btn_nfeMapa.TabIndex = 14
        Me.btn_nfeMapa.Text = "NFe &Mapa"
        Me.btn_nfeMapa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nfeMapa.UseVisualStyleBackColor = True
        '
        'btn_geraDanfe
        '
        Me.btn_geraDanfe.Image = Global.MetroSys.My.Resources.Resources.ok_16x16
        Me.btn_geraDanfe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_geraDanfe.Location = New System.Drawing.Point(384, 10)
        Me.btn_geraDanfe.Name = "btn_geraDanfe"
        Me.btn_geraDanfe.Size = New System.Drawing.Size(87, 43)
        Me.btn_geraDanfe.TabIndex = 13
        Me.btn_geraDanfe.Text = "&Autoriza NFe"
        Me.btn_geraDanfe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_geraDanfe.UseVisualStyleBackColor = True
        '
        'btn_cce
        '
        Me.btn_cce.Image = Global.MetroSys.My.Resources.Resources.disc_r
        Me.btn_cce.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cce.Location = New System.Drawing.Point(485, 10)
        Me.btn_cce.Name = "btn_cce"
        Me.btn_cce.Size = New System.Drawing.Size(75, 43)
        Me.btn_cce.TabIndex = 13
        Me.btn_cce.Text = "&Carta CCe"
        Me.btn_cce.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cce.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Image = Global.MetroSys.My.Resources.Resources.cancelar
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(656, 10)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(72, 43)
        Me.btn_cancelar.TabIndex = 13
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_recibo
        '
        Me.btn_recibo.Image = Global.MetroSys.My.Resources.Resources.Modify
        Me.btn_recibo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_recibo.Location = New System.Drawing.Point(916, 10)
        Me.btn_recibo.Name = "btn_recibo"
        Me.btn_recibo.Size = New System.Drawing.Size(68, 43)
        Me.btn_recibo.TabIndex = 12
        Me.btn_recibo.Text = "&Recibo"
        Me.btn_recibo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_recibo.UseVisualStyleBackColor = True
        '
        'btn_inutiliza
        '
        Me.btn_inutiliza.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_inutiliza.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_inutiliza.Location = New System.Drawing.Point(573, 10)
        Me.btn_inutiliza.Name = "btn_inutiliza"
        Me.btn_inutiliza.Size = New System.Drawing.Size(71, 43)
        Me.btn_inutiliza.TabIndex = 11
        Me.btn_inutiliza.Text = "&Cancelar"
        Me.btn_inutiliza.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_inutiliza.UseVisualStyleBackColor = True
        '
        'btn_corrigeNFe
        '
        Me.btn_corrigeNFe.Image = Global.MetroSys.My.Resources.Resources.ok_16x16
        Me.btn_corrigeNFe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_corrigeNFe.Location = New System.Drawing.Point(741, 10)
        Me.btn_corrigeNFe.Name = "btn_corrigeNFe"
        Me.btn_corrigeNFe.Size = New System.Drawing.Size(84, 43)
        Me.btn_corrigeNFe.TabIndex = 11
        Me.btn_corrigeNFe.Text = "&Corrige NFe"
        Me.btn_corrigeNFe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_corrigeNFe.UseVisualStyleBackColor = True
        '
        'btn_imprime
        '
        Me.btn_imprime.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_imprime.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprime.Location = New System.Drawing.Point(836, 10)
        Me.btn_imprime.Name = "btn_imprime"
        Me.btn_imprime.Size = New System.Drawing.Size(70, 43)
        Me.btn_imprime.TabIndex = 11
        Me.btn_imprime.Text = "&Imprime"
        Me.btn_imprime.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprime.UseVisualStyleBackColor = True
        '
        'btn_nfeOutras
        '
        Me.btn_nfeOutras.Image = Global.MetroSys.My.Resources.Resources.NFe
        Me.btn_nfeOutras.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nfeOutras.Location = New System.Drawing.Point(96, 10)
        Me.btn_nfeOutras.Name = "btn_nfeOutras"
        Me.btn_nfeOutras.Size = New System.Drawing.Size(80, 43)
        Me.btn_nfeOutras.TabIndex = 9
        Me.btn_nfeOutras.Text = "NFe &Outras"
        Me.btn_nfeOutras.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nfeOutras.UseVisualStyleBackColor = True
        '
        'btn_nfe
        '
        Me.btn_nfe.Image = Global.MetroSys.My.Resources.Resources.NFe
        Me.btn_nfe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nfe.Location = New System.Drawing.Point(12, 10)
        Me.btn_nfe.Name = "btn_nfe"
        Me.btn_nfe.Size = New System.Drawing.Size(72, 43)
        Me.btn_nfe.TabIndex = 9
        Me.btn_nfe.Text = "&NFe"
        Me.btn_nfe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nfe.UseVisualStyleBackColor = True
        '
        'sstrip
        '
        Me.sstrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_opcoes})
        Me.sstrip.Location = New System.Drawing.Point(0, 584)
        Me.sstrip.Name = "sstrip"
        Me.sstrip.Size = New System.Drawing.Size(1014, 22)
        Me.sstrip.TabIndex = 7
        Me.sstrip.Text = "Opções de Busca"
        '
        'tsb_opcoes
        '
        Me.tsb_opcoes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_opcoes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.opt_nome, Me.opt_CnpjCpf, Me.opt_data, Me.opt_numero})
        Me.tsb_opcoes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsb_opcoes.Image = CType(resources.GetObject("tsb_opcoes.Image"), System.Drawing.Image)
        Me.tsb_opcoes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_opcoes.Name = "tsb_opcoes"
        Me.tsb_opcoes.Size = New System.Drawing.Size(131, 20)
        Me.tsb_opcoes.Text = "Opções de Pesquisa"
        '
        'opt_nome
        '
        Me.opt_nome.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.opt_nome.Name = "opt_nome"
        Me.opt_nome.Size = New System.Drawing.Size(123, 22)
        Me.opt_nome.Text = "&Nome"
        '
        'opt_CnpjCpf
        '
        Me.opt_CnpjCpf.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.opt_CnpjCpf.Name = "opt_CnpjCpf"
        Me.opt_CnpjCpf.Size = New System.Drawing.Size(123, 22)
        Me.opt_CnpjCpf.Text = "&Cnpj/Cpf"
        '
        'opt_data
        '
        Me.opt_data.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.opt_data.Name = "opt_data"
        Me.opt_data.Size = New System.Drawing.Size(123, 22)
        Me.opt_data.Text = "&Data"
        '
        'opt_numero
        '
        Me.opt_numero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.opt_numero.Name = "opt_numero"
        Me.opt_numero.Size = New System.Drawing.Size(123, 22)
        Me.opt_numero.Text = "&Numero"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(59, 17)
        Me.ToolStripStatusLabel1.Text = "Consultas"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 540)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(991, 41)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(15, 19)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(47, 13)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = "          "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1018, 66)
        Me.Panel1.TabIndex = 38
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(905, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(97, 35)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(898, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 25)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(397, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(187, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PorPeriodoToolStripMenuItem, Me.PorCNPJCPFToolStripMenuItem, Me.PorClienteToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 20)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'PorPeriodoToolStripMenuItem
        '
        Me.PorPeriodoToolStripMenuItem.Name = "PorPeriodoToolStripMenuItem"
        Me.PorPeriodoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PorPeriodoToolStripMenuItem.Text = "Por Periodo"
        '
        'PorCNPJCPFToolStripMenuItem
        '
        Me.PorCNPJCPFToolStripMenuItem.Name = "PorCNPJCPFToolStripMenuItem"
        Me.PorCNPJCPFToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PorCNPJCPFToolStripMenuItem.Text = "Por CNPJ/CPF "
        '
        'PorClienteToolStripMenuItem
        '
        Me.PorClienteToolStripMenuItem.Name = "PorClienteToolStripMenuItem"
        Me.PorClienteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PorClienteToolStripMenuItem.Text = "Por Cliente"
        '
        'lbl_comandos
        '
        Me.lbl_comandos.AutoSize = True
        Me.lbl_comandos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_comandos.Location = New System.Drawing.Point(12, 70)
        Me.lbl_comandos.Name = "lbl_comandos"
        Me.lbl_comandos.Size = New System.Drawing.Size(599, 13)
        Me.lbl_comandos.TabIndex = 39
        Me.lbl_comandos.Text = "Visualiza NF-e [ F1 ]   ;   Atualiza Consulta [ F5 ]   ;   Atualiza Protocolo [ F" & _
            "7 ]    ;   Autorizar XML [ F10 ]"
        '
        'nt_x
        '
        Me.nt_x.HeaderText = "ST"
        Me.nt_x.MaxInputLength = 1
        Me.nt_x.Name = "nt_x"
        Me.nt_x.ReadOnly = True
        Me.nt_x.Width = 30
        '
        'nt_Codigo
        '
        Me.nt_Codigo.HeaderText = "Numero"
        Me.nt_Codigo.Name = "nt_Codigo"
        Me.nt_Codigo.ReadOnly = True
        Me.nt_Codigo.Width = 80
        '
        'nt_emissao
        '
        Me.nt_emissao.HeaderText = "DTEmissão"
        Me.nt_emissao.MaxInputLength = 10
        Me.nt_emissao.Name = "nt_emissao"
        Me.nt_emissao.ReadOnly = True
        Me.nt_emissao.Width = 90
        '
        'nt_cnpj_cpf
        '
        Me.nt_cnpj_cpf.HeaderText = "Cnpj/Cpf"
        Me.nt_cnpj_cpf.MaxInputLength = 14
        Me.nt_cnpj_cpf.Name = "nt_cnpj_cpf"
        Me.nt_cnpj_cpf.ReadOnly = True
        Me.nt_cnpj_cpf.Width = 120
        '
        'nt_portador
        '
        Me.nt_portador.HeaderText = "Cliente"
        Me.nt_portador.MaxInputLength = 40
        Me.nt_portador.Name = "nt_portador"
        Me.nt_portador.ReadOnly = True
        Me.nt_portador.Width = 250
        '
        'nt_chave
        '
        Me.nt_chave.HeaderText = "Chave"
        Me.nt_chave.MaxInputLength = 44
        Me.nt_chave.Name = "nt_chave"
        Me.nt_chave.ReadOnly = True
        Me.nt_chave.Width = 220
        '
        'nt_proto
        '
        Me.nt_proto.HeaderText = "Protocolo"
        Me.nt_proto.MaxInputLength = 15
        Me.nt_proto.Name = "nt_proto"
        Me.nt_proto.ReadOnly = True
        Me.nt_proto.Width = 155
        '
        'seqcce
        '
        Me.seqcce.HeaderText = "SeqCCe"
        Me.seqcce.Name = "seqcce"
        Me.seqcce.ReadOnly = True
        Me.seqcce.Visible = False
        '
        'numpedido
        '
        Me.numpedido.HeaderText = "numpedido"
        Me.numpedido.Name = "numpedido"
        Me.numpedido.ReadOnly = True
        Me.numpedido.Visible = False
        '
        'Frm_GeraNotasFiscais
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 606)
        Me.Controls.Add(Me.lbl_comandos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.sstrip)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtg_nfe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_GeraNotasFiscais"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gerênciador de Notas Fiscais Eletrônicas"
        CType(Me.dtg_nfe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.sstrip.ResumeLayout(False)
        Me.sstrip.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_nfe As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents btn_imprime As System.Windows.Forms.Button
    Public WithEvents btn_nfe As System.Windows.Forms.Button
    Friend WithEvents btn_recibo As System.Windows.Forms.Button
    Public WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents sstrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents PorClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PorPeriodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents PorCNPJCPFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_comandos As System.Windows.Forms.Label
    Public WithEvents btn_cce As System.Windows.Forms.Button
    Public WithEvents btn_nfeOutras As System.Windows.Forms.Button
    Public WithEvents btn_geraDanfe As System.Windows.Forms.Button
    Public WithEvents btn_inutiliza As System.Windows.Forms.Button
    Public WithEvents btn_nfeMapa As System.Windows.Forms.Button
    Friend WithEvents tsb_opcoes As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents opt_nome As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents opt_CnpjCpf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents opt_data As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents opt_numero As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents btn_corrigeNFe As System.Windows.Forms.Button
    Public WithEvents btn_corrigeOutrasNFe As System.Windows.Forms.Button
    Friend WithEvents nt_x As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_emissao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_cnpj_cpf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_portador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_chave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_proto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents seqcce As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numpedido As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
