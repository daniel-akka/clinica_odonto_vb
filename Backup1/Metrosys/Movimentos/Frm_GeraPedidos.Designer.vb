<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GeraPedidos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GeraPedidos))
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
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_vend = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_sit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mapa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.entrada = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.parcelas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_pagar = New System.Windows.Forms.Button
        Me.btn_exclui = New System.Windows.Forms.Button
        Me.btn_novo = New System.Windows.Forms.Button
        Me.btn_altera = New System.Windows.Forms.Button
        Me.btn_carne = New System.Windows.Forms.Button
        Me.btn_copiar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.btn_imprime = New System.Windows.Forms.Button
        Me.btn_busca = New System.Windows.Forms.Button
        Me.btn_boleto = New System.Windows.Forms.Button
        Me.btn_np = New System.Windows.Forms.Button
        Me.pdRelatPedidos = New System.Drawing.Printing.PrintDocument
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.pdRelatPedidos2 = New System.Drawing.Printing.PrintDocument
        Me.cbo_opcoes = New System.Windows.Forms.ComboBox
        Me.lbl_opcao = New System.Windows.Forms.Label
        Me.msk_pesquisa = New System.Windows.Forms.MaskedTextBox
        Me.msk_pesq2PeriodoFinal = New System.Windows.Forms.MaskedTextBox
        Me.lbl_periodo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        CType(Me.dtg_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.dtg_pedidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nt_id, Me.nt_geno, Me.nt_orca, Me.nt_dtemis, Me.nt_codig, Me.p_portad, Me.p_cid, Me.p_uf, Me.tgeral, Me.tipo, Me.nt_vend, Me.nt_sit, Me.mapa, Me.entrada, Me.parcelas})
        Me.dtg_pedidos.Location = New System.Drawing.Point(9, 71)
        Me.dtg_pedidos.MultiSelect = False
        Me.dtg_pedidos.Name = "dtg_pedidos"
        Me.dtg_pedidos.ReadOnly = True
        Me.dtg_pedidos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_pedidos.Size = New System.Drawing.Size(829, 461)
        Me.dtg_pedidos.TabIndex = 1
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
        Me.p_portad.Name = "p_portad"
        Me.p_portad.ReadOnly = True
        Me.p_portad.Width = 210
        '
        'p_cid
        '
        Me.p_cid.HeaderText = "Cidade"
        Me.p_cid.Name = "p_cid"
        Me.p_cid.ReadOnly = True
        '
        'p_uf
        '
        Me.p_uf.HeaderText = "UF"
        Me.p_uf.MaxInputLength = 2
        Me.p_uf.Name = "p_uf"
        Me.p_uf.ReadOnly = True
        Me.p_uf.Width = 35
        '
        'tgeral
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.tgeral.DefaultCellStyle = DataGridViewCellStyle1
        Me.tgeral.HeaderText = "Total R$"
        Me.tgeral.MaxInputLength = 16
        Me.tgeral.Name = "tgeral"
        Me.tgeral.ReadOnly = True
        '
        'tipo
        '
        Me.tipo.HeaderText = "Tipo"
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.Visible = False
        Me.tipo.Width = 90
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
        'parcelas
        '
        Me.parcelas.HeaderText = "Parcelas"
        Me.parcelas.Name = "parcelas"
        Me.parcelas.ReadOnly = True
        Me.parcelas.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(852, 66)
        Me.Panel1.TabIndex = 37
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(732, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 25)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(330, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(187, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_pagar)
        Me.GroupBox1.Controls.Add(Me.btn_exclui)
        Me.GroupBox1.Controls.Add(Me.btn_novo)
        Me.GroupBox1.Controls.Add(Me.btn_altera)
        Me.GroupBox1.Controls.Add(Me.btn_carne)
        Me.GroupBox1.Controls.Add(Me.btn_copiar)
        Me.GroupBox1.Controls.Add(Me.btn_cancelar)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.btn_imprime)
        Me.GroupBox1.Controls.Add(Me.btn_busca)
        Me.GroupBox1.Controls.Add(Me.btn_boleto)
        Me.GroupBox1.Controls.Add(Me.btn_np)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 537)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(828, 52)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        '
        'btn_pagar
        '
        Me.btn_pagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pagar.Image = CType(resources.GetObject("btn_pagar.Image"), System.Drawing.Image)
        Me.btn_pagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_pagar.Location = New System.Drawing.Point(734, 13)
        Me.btn_pagar.Name = "btn_pagar"
        Me.btn_pagar.Size = New System.Drawing.Size(91, 33)
        Me.btn_pagar.TabIndex = 10
        Me.btn_pagar.Text = "&Pagar"
        Me.btn_pagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pagar.UseVisualStyleBackColor = True
        '
        'btn_exclui
        '
        Me.btn_exclui.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_exclui.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_exclui.Location = New System.Drawing.Point(146, 13)
        Me.btn_exclui.Name = "btn_exclui"
        Me.btn_exclui.Size = New System.Drawing.Size(65, 33)
        Me.btn_exclui.TabIndex = 4
        Me.btn_exclui.Text = "&Exclui"
        Me.btn_exclui.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_exclui.UseVisualStyleBackColor = True
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
        'btn_carne
        '
        Me.btn_carne.Image = Global.MetroSys.My.Resources.Resources.Boleto_2_16x16
        Me.btn_carne.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_carne.Location = New System.Drawing.Point(655, 13)
        Me.btn_carne.Name = "btn_carne"
        Me.btn_carne.Size = New System.Drawing.Size(74, 33)
        Me.btn_carne.TabIndex = 9
        Me.btn_carne.Text = "&Carnê"
        Me.btn_carne.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_carne.UseVisualStyleBackColor = True
        '
        'btn_copiar
        '
        Me.btn_copiar.Image = Global.MetroSys.My.Resources.Resources.copiar1
        Me.btn_copiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_copiar.Location = New System.Drawing.Point(577, 13)
        Me.btn_copiar.Name = "btn_copiar"
        Me.btn_copiar.Size = New System.Drawing.Size(74, 33)
        Me.btn_copiar.TabIndex = 8
        Me.btn_copiar.Text = "&Copiar"
        Me.btn_copiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_copiar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Image = Global.MetroSys.My.Resources.Resources.cancelar
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancelar.Location = New System.Drawing.Point(497, 13)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 33)
        Me.btn_cancelar.TabIndex = 8
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.MetroSys.My.Resources.Resources.cancelar
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(497, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 33)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "&Cancelar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_imprime
        '
        Me.btn_imprime.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_imprime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_imprime.Location = New System.Drawing.Point(426, 13)
        Me.btn_imprime.Name = "btn_imprime"
        Me.btn_imprime.Size = New System.Drawing.Size(67, 33)
        Me.btn_imprime.TabIndex = 8
        Me.btn_imprime.Text = "&Imprime"
        Me.btn_imprime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprime.UseVisualStyleBackColor = True
        '
        'btn_busca
        '
        Me.btn_busca.Image = Global.MetroSys.My.Resources.Resources.Search
        Me.btn_busca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_busca.Location = New System.Drawing.Point(217, 13)
        Me.btn_busca.Name = "btn_busca"
        Me.btn_busca.Size = New System.Drawing.Size(65, 33)
        Me.btn_busca.TabIndex = 5
        Me.btn_busca.Text = "&Busca"
        Me.btn_busca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_busca.UseVisualStyleBackColor = True
        '
        'btn_boleto
        '
        Me.btn_boleto.Image = CType(resources.GetObject("btn_boleto.Image"), System.Drawing.Image)
        Me.btn_boleto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_boleto.Location = New System.Drawing.Point(357, 13)
        Me.btn_boleto.Name = "btn_boleto"
        Me.btn_boleto.Size = New System.Drawing.Size(65, 33)
        Me.btn_boleto.TabIndex = 7
        Me.btn_boleto.Text = "Bole&to"
        Me.btn_boleto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_boleto.UseVisualStyleBackColor = True
        '
        'btn_np
        '
        Me.btn_np.Image = Global.MetroSys.My.Resources.Resources.disc_r
        Me.btn_np.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_np.Location = New System.Drawing.Point(287, 13)
        Me.btn_np.Name = "btn_np"
        Me.btn_np.Size = New System.Drawing.Size(65, 33)
        Me.btn_np.TabIndex = 6
        Me.btn_np.Text = "&Np"
        Me.btn_np.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_np.UseVisualStyleBackColor = True
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
        'pdRelatPedidos2
        '
        '
        'cbo_opcoes
        '
        Me.cbo_opcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_opcoes.FormattingEnabled = True
        Me.cbo_opcoes.Items.AddRange(New Object() {"N. Pedido", "Data", "Cliente"})
        Me.cbo_opcoes.Location = New System.Drawing.Point(72, 597)
        Me.cbo_opcoes.Name = "cbo_opcoes"
        Me.cbo_opcoes.Size = New System.Drawing.Size(134, 21)
        Me.cbo_opcoes.TabIndex = 10
        Me.cbo_opcoes.Visible = False
        '
        'lbl_opcao
        '
        Me.lbl_opcao.AutoSize = True
        Me.lbl_opcao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_opcao.Location = New System.Drawing.Point(12, 600)
        Me.lbl_opcao.Name = "lbl_opcao"
        Me.lbl_opcao.Size = New System.Drawing.Size(54, 13)
        Me.lbl_opcao.TabIndex = 41
        Me.lbl_opcao.Text = "Opções:"
        Me.lbl_opcao.Visible = False
        '
        'msk_pesquisa
        '
        Me.msk_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_pesquisa.Location = New System.Drawing.Point(227, 597)
        Me.msk_pesquisa.Name = "msk_pesquisa"
        Me.msk_pesquisa.Size = New System.Drawing.Size(104, 21)
        Me.msk_pesquisa.TabIndex = 13
        Me.msk_pesquisa.Visible = False
        '
        'msk_pesq2PeriodoFinal
        '
        Me.msk_pesq2PeriodoFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_pesq2PeriodoFinal.Location = New System.Drawing.Point(365, 597)
        Me.msk_pesq2PeriodoFinal.Name = "msk_pesq2PeriodoFinal"
        Me.msk_pesq2PeriodoFinal.Size = New System.Drawing.Size(104, 21)
        Me.msk_pesq2PeriodoFinal.TabIndex = 15
        Me.msk_pesq2PeriodoFinal.Visible = False
        '
        'lbl_periodo
        '
        Me.lbl_periodo.AutoSize = True
        Me.lbl_periodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_periodo.Location = New System.Drawing.Point(340, 600)
        Me.lbl_periodo.Name = "lbl_periodo"
        Me.lbl_periodo.Size = New System.Drawing.Size(15, 13)
        Me.lbl_periodo.TabIndex = 41
        Me.lbl_periodo.Text = "A"
        Me.lbl_periodo.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(683, 603)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 15)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "[F5] - Atualiza Consulta"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(725, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 37)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'Frm_GeraPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 630)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.msk_pesq2PeriodoFinal)
        Me.Controls.Add(Me.msk_pesquisa)
        Me.Controls.Add(Me.lbl_periodo)
        Me.Controls.Add(Me.lbl_opcao)
        Me.Controls.Add(Me.cbo_opcoes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtg_pedidos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_GeraPedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista Pedidos"
        CType(Me.dtg_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents dtg_pedidos As System.Windows.Forms.DataGridView
    Public WithEvents btn_novo As System.Windows.Forms.Button
    Public WithEvents btn_altera As System.Windows.Forms.Button
    Public WithEvents btn_exclui As System.Windows.Forms.Button
    Public WithEvents btn_busca As System.Windows.Forms.Button
    Public WithEvents btn_np As System.Windows.Forms.Button
    Public WithEvents btn_boleto As System.Windows.Forms.Button
    Public WithEvents btn_imprime As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pdRelatPedidos As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdRelatPedidos2 As System.Drawing.Printing.PrintDocument
    Public WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents cbo_opcoes As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_opcao As System.Windows.Forms.Label
    Friend WithEvents msk_pesquisa As System.Windows.Forms.MaskedTextBox
    Friend WithEvents msk_pesq2PeriodoFinal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbl_periodo As System.Windows.Forms.Label
    Public WithEvents btn_copiar As System.Windows.Forms.Button
    Public WithEvents btn_carne As System.Windows.Forms.Button
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
    Friend WithEvents parcelas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_pagar As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
