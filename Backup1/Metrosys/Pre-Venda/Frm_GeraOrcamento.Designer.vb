﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GeraOrcamento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GeraOrcamento))
        Me.dtg_pedidos = New System.Windows.Forms.DataGridView
        Me.nt_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_geno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_orca = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_dtemis = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_codig = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.p_portad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.p_cid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.p_uf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tgeral = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_vend = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_sair = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_convertOrca = New System.Windows.Forms.Button
        Me.btn_busca = New System.Windows.Forms.Button
        Me.btn_novo = New System.Windows.Forms.Button
        Me.btn_altera = New System.Windows.Forms.Button
        Me.btn_imprime = New System.Windows.Forms.Button
        Me.pdRelatPedidos = New System.Drawing.Printing.PrintDocument
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.msk_periodoFinal = New System.Windows.Forms.MaskedTextBox
        Me.msk_pesquisa = New System.Windows.Forms.MaskedTextBox
        Me.lbl_opcao = New System.Windows.Forms.Label
        Me.cbo_opcoes = New System.Windows.Forms.ComboBox
        Me.pdRelatPedidos2 = New System.Drawing.Printing.PrintDocument
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lbl_periodo = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        CType(Me.dtg_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_pedidos
        '
        Me.dtg_pedidos.AllowUserToAddRows = False
        Me.dtg_pedidos.AllowUserToDeleteRows = False
        Me.dtg_pedidos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_pedidos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_pedidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_pedidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nt_id, Me.nt_geno, Me.nt_orca, Me.nt_dtemis, Me.nt_codig, Me.p_portad, Me.p_cid, Me.p_uf, Me.tgeral, Me.nt_vend})
        Me.dtg_pedidos.Location = New System.Drawing.Point(9, 76)
        Me.dtg_pedidos.MultiSelect = False
        Me.dtg_pedidos.Name = "dtg_pedidos"
        Me.dtg_pedidos.ReadOnly = True
        Me.dtg_pedidos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_pedidos.Size = New System.Drawing.Size(913, 347)
        Me.dtg_pedidos.TabIndex = 42
        '
        'nt_id
        '
        Me.nt_id.HeaderText = "nt_id"
        Me.nt_id.MaxInputLength = 30
        Me.nt_id.Name = "nt_id"
        Me.nt_id.ReadOnly = True
        Me.nt_id.Visible = False
        '
        'nt_geno
        '
        Me.nt_geno.HeaderText = "Loja"
        Me.nt_geno.MaxInputLength = 6
        Me.nt_geno.Name = "nt_geno"
        Me.nt_geno.ReadOnly = True
        Me.nt_geno.Width = 60
        '
        'nt_orca
        '
        Me.nt_orca.HeaderText = "Orçamento"
        Me.nt_orca.MaxInputLength = 10
        Me.nt_orca.Name = "nt_orca"
        Me.nt_orca.ReadOnly = True
        '
        'nt_dtemis
        '
        Me.nt_dtemis.HeaderText = "Emissão"
        Me.nt_dtemis.Name = "nt_dtemis"
        Me.nt_dtemis.ReadOnly = True
        Me.nt_dtemis.Width = 80
        '
        'nt_codig
        '
        Me.nt_codig.HeaderText = "Codigo"
        Me.nt_codig.Name = "nt_codig"
        Me.nt_codig.ReadOnly = True
        Me.nt_codig.Width = 60
        '
        'p_portad
        '
        Me.p_portad.HeaderText = "Cliente"
        Me.p_portad.MaxInputLength = 100
        Me.p_portad.Name = "p_portad"
        Me.p_portad.ReadOnly = True
        Me.p_portad.Width = 285
        '
        'p_cid
        '
        Me.p_cid.HeaderText = "Cidade"
        Me.p_cid.Name = "p_cid"
        Me.p_cid.ReadOnly = True
        Me.p_cid.Width = 150
        '
        'p_uf
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.p_uf.DefaultCellStyle = DataGridViewCellStyle1
        Me.p_uf.HeaderText = "UF"
        Me.p_uf.MaxInputLength = 2
        Me.p_uf.Name = "p_uf"
        Me.p_uf.ReadOnly = True
        Me.p_uf.Width = 35
        '
        'tgeral
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.tgeral.DefaultCellStyle = DataGridViewCellStyle2
        Me.tgeral.HeaderText = "Total R$"
        Me.tgeral.MaxInputLength = 16
        Me.tgeral.Name = "tgeral"
        Me.tgeral.ReadOnly = True
        '
        'nt_vend
        '
        Me.nt_vend.HeaderText = "Vendedor"
        Me.nt_vend.Name = "nt_vend"
        Me.nt_vend.ReadOnly = True
        Me.nt_vend.Visible = False
        Me.nt_vend.Width = 70
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_sair)
        Me.GroupBox2.Location = New System.Drawing.Point(844, 435)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(78, 53)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        '
        'btn_sair
        '
        Me.btn_sair.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sair.Location = New System.Drawing.Point(7, 13)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(65, 33)
        Me.btn_sair.TabIndex = 9
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_convertOrca)
        Me.GroupBox1.Controls.Add(Me.btn_busca)
        Me.GroupBox1.Controls.Add(Me.btn_novo)
        Me.GroupBox1.Controls.Add(Me.btn_altera)
        Me.GroupBox1.Controls.Add(Me.btn_imprime)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 435)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(413, 52)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        '
        'btn_convertOrca
        '
        Me.btn_convertOrca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_convertOrca.Image = Global.MetroSys.My.Resources.Resources.converter
        Me.btn_convertOrca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_convertOrca.Location = New System.Drawing.Point(221, 13)
        Me.btn_convertOrca.Name = "btn_convertOrca"
        Me.btn_convertOrca.Size = New System.Drawing.Size(117, 33)
        Me.btn_convertOrca.TabIndex = 10
        Me.btn_convertOrca.Text = "&Conv. p/ Pedido"
        Me.btn_convertOrca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_convertOrca.UseVisualStyleBackColor = True
        '
        'btn_busca
        '
        Me.btn_busca.Image = Global.MetroSys.My.Resources.Resources.Search
        Me.btn_busca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_busca.Location = New System.Drawing.Point(342, 13)
        Me.btn_busca.Name = "btn_busca"
        Me.btn_busca.Size = New System.Drawing.Size(65, 33)
        Me.btn_busca.TabIndex = 12
        Me.btn_busca.Text = "&Busca"
        Me.btn_busca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_busca.UseVisualStyleBackColor = True
        '
        'btn_novo
        '
        Me.btn_novo.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_novo.Location = New System.Drawing.Point(7, 13)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(65, 33)
        Me.btn_novo.TabIndex = 2
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'btn_altera
        '
        Me.btn_altera.Image = Global.MetroSys.My.Resources.Resources.Modify
        Me.btn_altera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_altera.Location = New System.Drawing.Point(77, 13)
        Me.btn_altera.Name = "btn_altera"
        Me.btn_altera.Size = New System.Drawing.Size(65, 33)
        Me.btn_altera.TabIndex = 3
        Me.btn_altera.Text = "&Altera"
        Me.btn_altera.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_altera.UseVisualStyleBackColor = True
        '
        'btn_imprime
        '
        Me.btn_imprime.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_imprime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_imprime.Location = New System.Drawing.Point(148, 13)
        Me.btn_imprime.Name = "btn_imprime"
        Me.btn_imprime.Size = New System.Drawing.Size(67, 33)
        Me.btn_imprime.TabIndex = 8
        Me.btn_imprime.Text = "&Imprime"
        Me.btn_imprime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprime.UseVisualStyleBackColor = True
        '
        'pdRelatPedidos
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
        'msk_periodoFinal
        '
        Me.msk_periodoFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_periodoFinal.Location = New System.Drawing.Point(279, 21)
        Me.msk_periodoFinal.Name = "msk_periodoFinal"
        Me.msk_periodoFinal.Size = New System.Drawing.Size(78, 21)
        Me.msk_periodoFinal.TabIndex = 45
        Me.msk_periodoFinal.Visible = False
        '
        'msk_pesquisa
        '
        Me.msk_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_pesquisa.Location = New System.Drawing.Point(171, 21)
        Me.msk_pesquisa.Name = "msk_pesquisa"
        Me.msk_pesquisa.Size = New System.Drawing.Size(78, 21)
        Me.msk_pesquisa.TabIndex = 44
        Me.msk_pesquisa.Visible = False
        '
        'lbl_opcao
        '
        Me.lbl_opcao.AutoSize = True
        Me.lbl_opcao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_opcao.Location = New System.Drawing.Point(9, 24)
        Me.lbl_opcao.Name = "lbl_opcao"
        Me.lbl_opcao.Size = New System.Drawing.Size(54, 13)
        Me.lbl_opcao.TabIndex = 50
        Me.lbl_opcao.Text = "Opções:"
        Me.lbl_opcao.Visible = False
        '
        'cbo_opcoes
        '
        Me.cbo_opcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_opcoes.FormattingEnabled = True
        Me.cbo_opcoes.Items.AddRange(New Object() {"N. Orçamento", "Data", "Cliente"})
        Me.cbo_opcoes.Location = New System.Drawing.Point(69, 21)
        Me.cbo_opcoes.Name = "cbo_opcoes"
        Me.cbo_opcoes.Size = New System.Drawing.Size(88, 21)
        Me.cbo_opcoes.TabIndex = 43
        Me.cbo_opcoes.Visible = False
        '
        'pdRelatPedidos2
        '
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(819, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 25)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(938, 71)
        Me.Panel1.TabIndex = 46
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(364, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(191, 61)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lbl_periodo
        '
        Me.lbl_periodo.AutoSize = True
        Me.lbl_periodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_periodo.Location = New System.Drawing.Point(257, 24)
        Me.lbl_periodo.Name = "lbl_periodo"
        Me.lbl_periodo.Size = New System.Drawing.Size(15, 13)
        Me.lbl_periodo.TabIndex = 49
        Me.lbl_periodo.Text = "A"
        Me.lbl_periodo.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.msk_pesquisa)
        Me.GroupBox3.Controls.Add(Me.lbl_periodo)
        Me.GroupBox3.Controls.Add(Me.cbo_opcoes)
        Me.GroupBox3.Controls.Add(Me.lbl_opcao)
        Me.GroupBox3.Controls.Add(Me.msk_periodoFinal)
        Me.GroupBox3.Location = New System.Drawing.Point(429, 437)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(409, 50)
        Me.GroupBox3.TabIndex = 51
        Me.GroupBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(817, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 37)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'Frm_GeraOrcamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 498)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dtg_pedidos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_GeraOrcamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Orcamentos"
        CType(Me.dtg_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents dtg_pedidos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Public WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents btn_altera As System.Windows.Forms.Button
    Public WithEvents btn_imprime As System.Windows.Forms.Button
    Friend WithEvents pdRelatPedidos As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents msk_periodoFinal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents msk_pesquisa As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbl_opcao As System.Windows.Forms.Label
    Friend WithEvents cbo_opcoes As System.Windows.Forms.ComboBox
    Friend WithEvents pdRelatPedidos2 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_periodo As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents btn_busca As System.Windows.Forms.Button
    Friend WithEvents btn_convertOrca As System.Windows.Forms.Button
    Friend WithEvents nt_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_geno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_orca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_dtemis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_codig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_portad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_cid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_uf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tgeral As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_vend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
