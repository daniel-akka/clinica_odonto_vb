<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CorteCargas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CorteCargas))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_sair = New System.Windows.Forms.Button
        Me.btn_cortar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_qtdeCorte = New System.Windows.Forms.TextBox
        Me.txt_qtdeAtual = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_pesquisar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_codProduto = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_numMapa = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dtg_prodCorte = New System.Windows.Forms.DataGridView
        Me.numpedido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.data = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.produto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qtde = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdb_aumentar = New System.Windows.Forms.RadioButton
        Me.rdb_diminuir = New System.Windows.Forms.RadioButton
        Me.lbl_numPedido = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_prodCorte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_sair)
        Me.GroupBox2.Controls.Add(Me.btn_cortar)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txt_qtdeCorte)
        Me.GroupBox2.Controls.Add(Me.txt_qtdeAtual)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 565)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(797, 50)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        '
        'btn_sair
        '
        Me.btn_sair.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sair.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sair.Location = New System.Drawing.Point(723, 12)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(68, 37)
        Me.btn_sair.TabIndex = 8
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'btn_cortar
        '
        Me.btn_cortar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cortar.Image = Global.MetroSys.My.Resources.Resources.tesoura
        Me.btn_cortar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cortar.Location = New System.Drawing.Point(634, 12)
        Me.btn_cortar.Name = "btn_cortar"
        Me.btn_cortar.Size = New System.Drawing.Size(82, 37)
        Me.btn_cortar.TabIndex = 7
        Me.btn_cortar.Text = "&Cortar"
        Me.btn_cortar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cortar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(240, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Corte:"
        '
        'txt_qtdeCorte
        '
        Me.txt_qtdeCorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtdeCorte.Location = New System.Drawing.Point(291, 18)
        Me.txt_qtdeCorte.MaxLength = 16
        Me.txt_qtdeCorte.Name = "txt_qtdeCorte"
        Me.txt_qtdeCorte.Size = New System.Drawing.Size(105, 22)
        Me.txt_qtdeCorte.TabIndex = 6
        Me.txt_qtdeCorte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_qtdeAtual
        '
        Me.txt_qtdeAtual.BackColor = System.Drawing.SystemColors.Info
        Me.txt_qtdeAtual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtdeAtual.Location = New System.Drawing.Point(110, 18)
        Me.txt_qtdeAtual.MaxLength = 14
        Me.txt_qtdeAtual.Name = "txt_qtdeAtual"
        Me.txt_qtdeAtual.ReadOnly = True
        Me.txt_qtdeAtual.Size = New System.Drawing.Size(100, 22)
        Me.txt_qtdeAtual.TabIndex = 4
        Me.txt_qtdeAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "QtdeAtual:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_pesquisar)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_codProduto)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_numMapa)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(795, 46)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        '
        'btn_pesquisar
        '
        Me.btn_pesquisar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pesquisar.Image = Global.MetroSys.My.Resources.Resources.Busca_16x161
        Me.btn_pesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pesquisar.Location = New System.Drawing.Point(522, 10)
        Me.btn_pesquisar.Name = "btn_pesquisar"
        Me.btn_pesquisar.Size = New System.Drawing.Size(99, 30)
        Me.btn_pesquisar.TabIndex = 43
        Me.btn_pesquisar.Text = "&Pesquisar"
        Me.btn_pesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_pesquisar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Num.Mapa:"
        '
        'txt_codProduto
        '
        Me.txt_codProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codProduto.Location = New System.Drawing.Point(376, 13)
        Me.txt_codProduto.MaxLength = 6
        Me.txt_codProduto.Name = "txt_codProduto"
        Me.txt_codProduto.Size = New System.Drawing.Size(96, 22)
        Me.txt_codProduto.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(301, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Cod.Produto:"
        '
        'txt_numMapa
        '
        Me.txt_numMapa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numMapa.Location = New System.Drawing.Point(95, 13)
        Me.txt_numMapa.MaxLength = 10
        Me.txt_numMapa.Name = "txt_numMapa"
        Me.txt_numMapa.Size = New System.Drawing.Size(106, 22)
        Me.txt_numMapa.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Wide Latin", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(647, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(167, 22)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(824, 66)
        Me.Panel1.TabIndex = 42
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(304, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(187, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'dtg_prodCorte
        '
        Me.dtg_prodCorte.AllowUserToAddRows = False
        Me.dtg_prodCorte.AllowUserToDeleteRows = False
        Me.dtg_prodCorte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_prodCorte.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_prodCorte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_prodCorte.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.numpedido, Me.data, Me.produto, Me.qtde, Me.total})
        Me.dtg_prodCorte.Location = New System.Drawing.Point(8, 121)
        Me.dtg_prodCorte.Name = "dtg_prodCorte"
        Me.dtg_prodCorte.ReadOnly = True
        Me.dtg_prodCorte.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_prodCorte.Size = New System.Drawing.Size(796, 440)
        Me.dtg_prodCorte.TabIndex = 44
        '
        'numpedido
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.numpedido.DefaultCellStyle = DataGridViewCellStyle9
        Me.numpedido.HeaderText = "Pedido"
        Me.numpedido.MaxInputLength = 10
        Me.numpedido.Name = "numpedido"
        Me.numpedido.ReadOnly = True
        '
        'data
        '
        Me.data.HeaderText = "Data"
        Me.data.MaxInputLength = 10
        Me.data.Name = "data"
        Me.data.ReadOnly = True
        Me.data.Width = 80
        '
        'produto
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.produto.DefaultCellStyle = DataGridViewCellStyle10
        Me.produto.HeaderText = "Produto"
        Me.produto.MaxInputLength = 80
        Me.produto.Name = "produto"
        Me.produto.ReadOnly = True
        Me.produto.Width = 370
        '
        'qtde
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.qtde.DefaultCellStyle = DataGridViewCellStyle11
        Me.qtde.HeaderText = "Qtde"
        Me.qtde.MaxInputLength = 14
        Me.qtde.Name = "qtde"
        Me.qtde.ReadOnly = True
        '
        'total
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.total.DefaultCellStyle = DataGridViewCellStyle12
        Me.total.HeaderText = "Total"
        Me.total.MaxInputLength = 14
        Me.total.Name = "total"
        Me.total.ReadOnly = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdb_aumentar)
        Me.GroupBox3.Controls.Add(Me.rdb_diminuir)
        Me.GroupBox3.Location = New System.Drawing.Point(429, 573)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 38)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo de Corte"
        '
        'rdb_aumentar
        '
        Me.rdb_aumentar.AutoSize = True
        Me.rdb_aumentar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_aumentar.Location = New System.Drawing.Point(101, 15)
        Me.rdb_aumentar.Name = "rdb_aumentar"
        Me.rdb_aumentar.Size = New System.Drawing.Size(86, 19)
        Me.rdb_aumentar.TabIndex = 0
        Me.rdb_aumentar.Text = "Aumentar"
        Me.rdb_aumentar.UseVisualStyleBackColor = True
        '
        'rdb_diminuir
        '
        Me.rdb_diminuir.AutoSize = True
        Me.rdb_diminuir.Checked = True
        Me.rdb_diminuir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_diminuir.Location = New System.Drawing.Point(6, 15)
        Me.rdb_diminuir.Name = "rdb_diminuir"
        Me.rdb_diminuir.Size = New System.Drawing.Size(80, 19)
        Me.rdb_diminuir.TabIndex = 0
        Me.rdb_diminuir.TabStop = True
        Me.rdb_diminuir.Text = "Diminuir"
        Me.rdb_diminuir.UseVisualStyleBackColor = True
        '
        'lbl_numPedido
        '
        Me.lbl_numPedido.AutoSize = True
        Me.lbl_numPedido.Location = New System.Drawing.Point(35, 519)
        Me.lbl_numPedido.Name = "lbl_numPedido"
        Me.lbl_numPedido.Size = New System.Drawing.Size(62, 13)
        Me.lbl_numPedido.TabIndex = 45
        Me.lbl_numPedido.Text = "NumPedido"
        Me.lbl_numPedido.Visible = False
        '
        'Frm_CorteCargas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 619)
        Me.Controls.Add(Me.lbl_numPedido)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtg_prodCorte)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_CorteCargas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Corte de Produtos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_prodCorte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_qtdeCorte As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_numMapa As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dtg_prodCorte As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_codProduto As System.Windows.Forms.TextBox
    Friend WithEvents btn_pesquisar As System.Windows.Forms.Button
    Friend WithEvents btn_cortar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_qtdeAtual As System.Windows.Forms.TextBox
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents numpedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents produto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_aumentar As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_diminuir As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_numPedido As System.Windows.Forms.Label
End Class
