<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MenuPedidoCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MenuPedidoCompras))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.tbc_pedidos = New System.Windows.Forms.TabControl
        Me.tb_pedidos = New System.Windows.Forms.TabPage
        Me.grp_opcoes = New System.Windows.Forms.GroupBox
        Me.btn_inclui = New System.Windows.Forms.Button
        Me.btn_exclui = New System.Windows.Forms.Button
        Me.btn_altera = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.tb_lancapedidos = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.grp_total = New System.Windows.Forms.GroupBox
        Me.dtg_itenspedido = New System.Windows.Forms.DataGridView
        Me.grp_mensagem = New System.Windows.Forms.GroupBox
        Me.txt_codpart = New System.Windows.Forms.TextBox
        Me.txt_fornecedor = New System.Windows.Forms.TextBox
        Me.txt_pedido = New System.Windows.Forms.TextBox
        Me.msk_dtcomp = New System.Windows.Forms.MaskedTextBox
        Me.msd_dtchegada = New System.Windows.Forms.MaskedTextBox
        Me.txt_prazos = New System.Windows.Forms.TextBox
        Me.txt_desconto = New System.Windows.Forms.TextBox
        Me.txt_binificacao = New System.Windows.Forms.TextBox
        Me.txt_obs = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_ipi = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_vendedor = New System.Windows.Forms.TextBox
        Me.cbo_tipopgto = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_Qtde = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt_Produto = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_qtdepedida = New System.Windows.Forms.TextBox
        Me.txt_codpr = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_pcoUnitario = New System.Windows.Forms.TextBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.btn_itsai = New System.Windows.Forms.Button
        Me.btn_itexclui = New System.Windows.Forms.Button
        Me.btn_itinclui = New System.Windows.Forms.Button
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbc_pedidos.SuspendLayout()
        Me.tb_pedidos.SuspendLayout()
        Me.grp_opcoes.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tb_lancapedidos.SuspendLayout()
        Me.grp_total.SuspendLayout()
        CType(Me.dtg_itenspedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_mensagem.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(769, 74)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("Wide Latin", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(640, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Genov"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(314, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(156, 58)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'tbc_pedidos
        '
        Me.tbc_pedidos.Controls.Add(Me.tb_pedidos)
        Me.tbc_pedidos.Controls.Add(Me.tb_lancapedidos)
        Me.tbc_pedidos.Location = New System.Drawing.Point(3, 74)
        Me.tbc_pedidos.Name = "tbc_pedidos"
        Me.tbc_pedidos.SelectedIndex = 0
        Me.tbc_pedidos.Size = New System.Drawing.Size(765, 539)
        Me.tbc_pedidos.TabIndex = 5
        '
        'tb_pedidos
        '
        Me.tb_pedidos.Controls.Add(Me.grp_opcoes)
        Me.tb_pedidos.Controls.Add(Me.DataGridView1)
        Me.tb_pedidos.Location = New System.Drawing.Point(4, 22)
        Me.tb_pedidos.Name = "tb_pedidos"
        Me.tb_pedidos.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_pedidos.Size = New System.Drawing.Size(757, 493)
        Me.tb_pedidos.TabIndex = 0
        Me.tb_pedidos.Text = "Pedidos Lançados"
        Me.tb_pedidos.UseVisualStyleBackColor = True
        '
        'grp_opcoes
        '
        Me.grp_opcoes.Controls.Add(Me.btn_inclui)
        Me.grp_opcoes.Controls.Add(Me.btn_exclui)
        Me.grp_opcoes.Controls.Add(Me.btn_altera)
        Me.grp_opcoes.Location = New System.Drawing.Point(675, 7)
        Me.grp_opcoes.Name = "grp_opcoes"
        Me.grp_opcoes.Size = New System.Drawing.Size(76, 159)
        Me.grp_opcoes.TabIndex = 6
        Me.grp_opcoes.TabStop = False
        '
        'btn_inclui
        '
        Me.btn_inclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_inclui.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_inclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_inclui.Location = New System.Drawing.Point(6, 16)
        Me.btn_inclui.Name = "btn_inclui"
        Me.btn_inclui.Size = New System.Drawing.Size(60, 42)
        Me.btn_inclui.TabIndex = 1
        Me.btn_inclui.Text = "&Inclui"
        Me.btn_inclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_inclui.UseVisualStyleBackColor = True
        '
        'btn_exclui
        '
        Me.btn_exclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exclui.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_exclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exclui.Location = New System.Drawing.Point(6, 111)
        Me.btn_exclui.Name = "btn_exclui"
        Me.btn_exclui.Size = New System.Drawing.Size(60, 42)
        Me.btn_exclui.TabIndex = 3
        Me.btn_exclui.Text = "&Exclui"
        Me.btn_exclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exclui.UseVisualStyleBackColor = True
        '
        'btn_altera
        '
        Me.btn_altera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_altera.Image = Global.MetroSys.My.Resources.Resources.Load
        Me.btn_altera.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_altera.Location = New System.Drawing.Point(6, 63)
        Me.btn_altera.Name = "btn_altera"
        Me.btn_altera.Size = New System.Drawing.Size(60, 42)
        Me.btn_altera.TabIndex = 2
        Me.btn_altera.Text = "&Altera"
        Me.btn_altera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_altera.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(5, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(664, 430)
        Me.DataGridView1.TabIndex = 5
        '
        'tb_lancapedidos
        '
        Me.tb_lancapedidos.Controls.Add(Me.GroupBox1)
        Me.tb_lancapedidos.Controls.Add(Me.grp_mensagem)
        Me.tb_lancapedidos.Controls.Add(Me.dtg_itenspedido)
        Me.tb_lancapedidos.Location = New System.Drawing.Point(4, 22)
        Me.tb_lancapedidos.Name = "tb_lancapedidos"
        Me.tb_lancapedidos.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_lancapedidos.Size = New System.Drawing.Size(757, 513)
        Me.tb_lancapedidos.TabIndex = 1
        Me.tb_lancapedidos.Text = "Pedidos (F2)"
        Me.tb_lancapedidos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Código:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Pedido:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(181, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Data Ped:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(320, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Prev.Cheg:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Prazo:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(154, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Desconto:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(276, 102)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Bonificação:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 140)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Observ.:"
        '
        'grp_total
        '
        Me.grp_total.Controls.Add(Me.txt_total)
        Me.grp_total.Location = New System.Drawing.Point(589, 192)
        Me.grp_total.Name = "grp_total"
        Me.grp_total.Size = New System.Drawing.Size(110, 58)
        Me.grp_total.TabIndex = 9
        Me.grp_total.TabStop = False
        Me.grp_total.Text = "Total R$"
        '
        'dtg_itenspedido
        '
        Me.dtg_itenspedido.AllowUserToAddRows = False
        Me.dtg_itenspedido.AllowUserToDeleteRows = False
        Me.dtg_itenspedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_itenspedido.Location = New System.Drawing.Point(11, 273)
        Me.dtg_itenspedido.Name = "dtg_itenspedido"
        Me.dtg_itenspedido.ReadOnly = True
        Me.dtg_itenspedido.Size = New System.Drawing.Size(706, 171)
        Me.dtg_itenspedido.TabIndex = 10
        '
        'grp_mensagem
        '
        Me.grp_mensagem.Controls.Add(Me.lbl_mensagem)
        Me.grp_mensagem.Location = New System.Drawing.Point(11, 450)
        Me.grp_mensagem.Name = "grp_mensagem"
        Me.grp_mensagem.Size = New System.Drawing.Size(706, 57)
        Me.grp_mensagem.TabIndex = 11
        Me.grp_mensagem.TabStop = False
        Me.grp_mensagem.Text = "Mensagem"
        '
        'txt_codpart
        '
        Me.txt_codpart.Location = New System.Drawing.Point(64, 19)
        Me.txt_codpart.MaxLength = 6
        Me.txt_codpart.Name = "txt_codpart"
        Me.txt_codpart.Size = New System.Drawing.Size(61, 20)
        Me.txt_codpart.TabIndex = 12
        '
        'txt_fornecedor
        '
        Me.txt_fornecedor.Location = New System.Drawing.Point(141, 19)
        Me.txt_fornecedor.MaxLength = 45
        Me.txt_fornecedor.Name = "txt_fornecedor"
        Me.txt_fornecedor.ReadOnly = True
        Me.txt_fornecedor.Size = New System.Drawing.Size(429, 20)
        Me.txt_fornecedor.TabIndex = 13
        '
        'txt_pedido
        '
        Me.txt_pedido.Location = New System.Drawing.Point(64, 63)
        Me.txt_pedido.MaxLength = 10
        Me.txt_pedido.Name = "txt_pedido"
        Me.txt_pedido.Size = New System.Drawing.Size(100, 20)
        Me.txt_pedido.TabIndex = 14
        '
        'msk_dtcomp
        '
        Me.msk_dtcomp.Location = New System.Drawing.Point(236, 62)
        Me.msk_dtcomp.Mask = "00/00/0000"
        Me.msk_dtcomp.Name = "msk_dtcomp"
        Me.msk_dtcomp.Size = New System.Drawing.Size(78, 20)
        Me.msk_dtcomp.TabIndex = 15
        Me.msk_dtcomp.ValidatingType = GetType(Date)
        '
        'msd_dtchegada
        '
        Me.msd_dtchegada.Location = New System.Drawing.Point(385, 62)
        Me.msd_dtchegada.Mask = "00/00/0000"
        Me.msd_dtchegada.Name = "msd_dtchegada"
        Me.msd_dtchegada.Size = New System.Drawing.Size(79, 20)
        Me.msd_dtchegada.TabIndex = 16
        Me.msd_dtchegada.ValidatingType = GetType(Date)
        '
        'txt_prazos
        '
        Me.txt_prazos.Location = New System.Drawing.Point(64, 99)
        Me.txt_prazos.MaxLength = 12
        Me.txt_prazos.Name = "txt_prazos"
        Me.txt_prazos.Size = New System.Drawing.Size(78, 20)
        Me.txt_prazos.TabIndex = 17
        '
        'txt_desconto
        '
        Me.txt_desconto.Location = New System.Drawing.Point(213, 99)
        Me.txt_desconto.MaxLength = 6
        Me.txt_desconto.Name = "txt_desconto"
        Me.txt_desconto.Size = New System.Drawing.Size(54, 20)
        Me.txt_desconto.TabIndex = 18
        '
        'txt_binificacao
        '
        Me.txt_binificacao.Location = New System.Drawing.Point(347, 99)
        Me.txt_binificacao.MaxLength = 14
        Me.txt_binificacao.Name = "txt_binificacao"
        Me.txt_binificacao.Size = New System.Drawing.Size(78, 20)
        Me.txt_binificacao.TabIndex = 19
        '
        'txt_obs
        '
        Me.txt_obs.Location = New System.Drawing.Point(64, 137)
        Me.txt_obs.MaxLength = 80
        Me.txt_obs.Name = "txt_obs"
        Me.txt_obs.Size = New System.Drawing.Size(600, 20)
        Me.txt_obs.TabIndex = 20
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cbo_tipopgto)
        Me.GroupBox1.Controls.Add(Me.txt_vendedor)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txt_ipi)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_fornecedor)
        Me.GroupBox1.Controls.Add(Me.txt_obs)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.grp_total)
        Me.GroupBox1.Controls.Add(Me.txt_binificacao)
        Me.GroupBox1.Controls.Add(Me.txt_desconto)
        Me.GroupBox1.Controls.Add(Me.txt_prazos)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.msd_dtchegada)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.msk_dtcomp)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txt_codpart)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_pedido)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(706, 256)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pedido"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(432, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "IPI:"
        '
        'txt_ipi
        '
        Me.txt_ipi.Location = New System.Drawing.Point(457, 99)
        Me.txt_ipi.MaxLength = 6
        Me.txt_ipi.Name = "txt_ipi"
        Me.txt_ipi.Size = New System.Drawing.Size(49, 20)
        Me.txt_ipi.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(477, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Vendedor:"
        '
        'txt_vendedor
        '
        Me.txt_vendedor.Location = New System.Drawing.Point(533, 62)
        Me.txt_vendedor.MaxLength = 20
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(131, 20)
        Me.txt_vendedor.TabIndex = 24
        '
        'cbo_tipopgto
        '
        Me.cbo_tipopgto.FormattingEnabled = True
        Me.cbo_tipopgto.Items.AddRange(New Object() {"AV ", "CH", "BL", "NP", "DP"})
        Me.cbo_tipopgto.Location = New System.Drawing.Point(577, 99)
        Me.cbo_tipopgto.Name = "cbo_tipopgto"
        Me.cbo_tipopgto.Size = New System.Drawing.Size(87, 21)
        Me.cbo_tipopgto.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(514, 102)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "TipoPgto:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox7)
        Me.GroupBox3.Controls.Add(Me.txt_pcoUnitario)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txt_codpr)
        Me.GroupBox3.Controls.Add(Me.txt_qtdepedida)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.txt_Qtde)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.txt_Produto)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 160)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(569, 90)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Itens"
        '
        'txt_Qtde
        '
        Me.txt_Qtde.Location = New System.Drawing.Point(606, 23)
        Me.txt_Qtde.MaxLength = 12
        Me.txt_Qtde.Name = "txt_Qtde"
        Me.txt_Qtde.Size = New System.Drawing.Size(62, 20)
        Me.txt_Qtde.TabIndex = 28
        Me.txt_Qtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(572, 28)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(33, 13)
        Me.Label21.TabIndex = 26
        Me.Label21.Text = "Qtde:"
        '
        'txt_Produto
        '
        Me.txt_Produto.Location = New System.Drawing.Point(115, 19)
        Me.txt_Produto.MaxLength = 40
        Me.txt_Produto.Name = "txt_Produto"
        Me.txt_Produto.ReadOnly = True
        Me.txt_Produto.Size = New System.Drawing.Size(256, 20)
        Me.txt_Produto.TabIndex = 27
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Codigo:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Qtde:"
        '
        'txt_qtdepedida
        '
        Me.txt_qtdepedida.Location = New System.Drawing.Point(49, 49)
        Me.txt_qtdepedida.MaxLength = 12
        Me.txt_qtdepedida.Name = "txt_qtdepedida"
        Me.txt_qtdepedida.Size = New System.Drawing.Size(62, 20)
        Me.txt_qtdepedida.TabIndex = 28
        Me.txt_qtdepedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_codpr
        '
        Me.txt_codpr.Location = New System.Drawing.Point(49, 19)
        Me.txt_codpr.MaxLength = 6
        Me.txt_codpr.Name = "txt_codpr"
        Me.txt_codpr.Size = New System.Drawing.Size(58, 20)
        Me.txt_codpr.TabIndex = 29
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(116, 52)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "VlUnit:"
        '
        'txt_pcoUnitario
        '
        Me.txt_pcoUnitario.Location = New System.Drawing.Point(160, 46)
        Me.txt_pcoUnitario.MaxLength = 12
        Me.txt_pcoUnitario.Name = "txt_pcoUnitario"
        Me.txt_pcoUnitario.Size = New System.Drawing.Size(79, 20)
        Me.txt_pcoUnitario.TabIndex = 31
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btn_itsai)
        Me.GroupBox7.Controls.Add(Me.btn_itexclui)
        Me.GroupBox7.Controls.Add(Me.btn_itinclui)
        Me.GroupBox7.Location = New System.Drawing.Point(378, 32)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(183, 53)
        Me.GroupBox7.TabIndex = 81
        Me.GroupBox7.TabStop = False
        '
        'btn_itsai
        '
        Me.btn_itsai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_itsai.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_itsai.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_itsai.Location = New System.Drawing.Point(122, 12)
        Me.btn_itsai.Name = "btn_itsai"
        Me.btn_itsai.Size = New System.Drawing.Size(57, 36)
        Me.btn_itsai.TabIndex = 61
        Me.btn_itsai.Text = "&Sai"
        Me.btn_itsai.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_itsai.UseVisualStyleBackColor = True
        '
        'btn_itexclui
        '
        Me.btn_itexclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_itexclui.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_itexclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_itexclui.Location = New System.Drawing.Point(63, 12)
        Me.btn_itexclui.Name = "btn_itexclui"
        Me.btn_itexclui.Size = New System.Drawing.Size(57, 36)
        Me.btn_itexclui.TabIndex = 60
        Me.btn_itexclui.Text = "&Del"
        Me.btn_itexclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_itexclui.UseVisualStyleBackColor = True
        '
        'btn_itinclui
        '
        Me.btn_itinclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_itinclui.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_itinclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_itinclui.Location = New System.Drawing.Point(3, 12)
        Me.btn_itinclui.Name = "btn_itinclui"
        Me.btn_itinclui.Size = New System.Drawing.Size(57, 36)
        Me.btn_itinclui.TabIndex = 59
        Me.btn_itinclui.Text = "&Inc"
        Me.btn_itinclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_itinclui.UseVisualStyleBackColor = True
        '
        'txt_total
        '
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(8, 20)
        Me.txt_total.MaxLength = 14
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(89, 23)
        Me.txt_total.TabIndex = 0
        Me.txt_total.Text = "0,00"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(18, 32)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(0, 15)
        Me.lbl_mensagem.TabIndex = 0
        '
        'Frm_MenuPedidoCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 619)
        Me.Controls.Add(Me.tbc_pedidos)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "Frm_MenuPedidoCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contrôle de Pedido de Compras"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbc_pedidos.ResumeLayout(False)
        Me.tb_pedidos.ResumeLayout(False)
        Me.grp_opcoes.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tb_lancapedidos.ResumeLayout(False)
        Me.grp_total.ResumeLayout(False)
        Me.grp_total.PerformLayout()
        CType(Me.dtg_itenspedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_mensagem.ResumeLayout(False)
        Me.grp_mensagem.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tbc_pedidos As System.Windows.Forms.TabControl
    Friend WithEvents tb_pedidos As System.Windows.Forms.TabPage
    Friend WithEvents tb_lancapedidos As System.Windows.Forms.TabPage
    Friend WithEvents grp_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents btn_inclui As System.Windows.Forms.Button
    Friend WithEvents btn_exclui As System.Windows.Forms.Button
    Friend WithEvents btn_altera As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents grp_mensagem As System.Windows.Forms.GroupBox
    Friend WithEvents dtg_itenspedido As System.Windows.Forms.DataGridView
    Friend WithEvents grp_total As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_fornecedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_codpart As System.Windows.Forms.TextBox
    Friend WithEvents txt_obs As System.Windows.Forms.TextBox
    Friend WithEvents txt_binificacao As System.Windows.Forms.TextBox
    Friend WithEvents txt_desconto As System.Windows.Forms.TextBox
    Friend WithEvents txt_prazos As System.Windows.Forms.TextBox
    Friend WithEvents msd_dtchegada As System.Windows.Forms.MaskedTextBox
    Friend WithEvents msk_dtcomp As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_pedido As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbo_tipopgto As System.Windows.Forms.ComboBox
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_ipi As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_codpr As System.Windows.Forms.TextBox
    Friend WithEvents txt_qtdepedida As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_Qtde As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_Produto As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_pcoUnitario As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_itsai As System.Windows.Forms.Button
    Friend WithEvents btn_itexclui As System.Windows.Forms.Button
    Friend WithEvents btn_itinclui As System.Windows.Forms.Button
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
End Class
