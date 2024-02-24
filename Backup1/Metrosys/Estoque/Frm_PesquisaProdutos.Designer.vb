<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PesquisaProdutos
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PesquisaProdutos))
        Me.tbc_produtos = New System.Windows.Forms.TabControl
        Me.tbp_vizualicao = New System.Windows.Forms.TabPage
        Me.Label44 = New System.Windows.Forms.Label
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.chk_MPrima = New System.Windows.Forms.CheckBox
        Me.Grp_opcao = New System.Windows.Forms.GroupBox
        Me.Rdb_codigo = New System.Windows.Forms.RadioButton
        Me.Rdb_produto = New System.Windows.Forms.RadioButton
        Me.rdb_barra = New System.Windows.Forms.RadioButton
        Me.dtg_produto = New System.Windows.Forms.DataGridView
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qtde = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.und = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codpart = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_pesquisa = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem01 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label26 = New System.Windows.Forms.Label
        Me.ToolTipInfo = New System.Windows.Forms.ToolTip(Me.components)
        Me.tbc_produtos.SuspendLayout()
        Me.tbp_vizualicao.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.Grp_opcao.SuspendLayout()
        CType(Me.dtg_produto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbc_produtos
        '
        Me.tbc_produtos.Controls.Add(Me.tbp_vizualicao)
        Me.tbc_produtos.Location = New System.Drawing.Point(6, 72)
        Me.tbc_produtos.Name = "tbc_produtos"
        Me.tbc_produtos.SelectedIndex = 0
        Me.tbc_produtos.Size = New System.Drawing.Size(822, 467)
        Me.tbc_produtos.TabIndex = 5
        '
        'tbp_vizualicao
        '
        Me.tbp_vizualicao.Controls.Add(Me.Label44)
        Me.tbp_vizualicao.Controls.Add(Me.GroupBox9)
        Me.tbp_vizualicao.Controls.Add(Me.Grp_opcao)
        Me.tbp_vizualicao.Controls.Add(Me.dtg_produto)
        Me.tbp_vizualicao.Controls.Add(Me.txt_pesquisa)
        Me.tbp_vizualicao.Controls.Add(Me.Label28)
        Me.tbp_vizualicao.Controls.Add(Me.GroupBox7)
        Me.tbp_vizualicao.Location = New System.Drawing.Point(4, 22)
        Me.tbp_vizualicao.Name = "tbp_vizualicao"
        Me.tbp_vizualicao.Size = New System.Drawing.Size(814, 441)
        Me.tbp_vizualicao.TabIndex = 3
        Me.tbp_vizualicao.Text = "Vizualização"
        Me.tbp_vizualicao.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(7, 5)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(85, 13)
        Me.Label44.TabIndex = 31
        Me.Label44.Text = "Altualizar [F5]"
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.chk_MPrima)
        Me.GroupBox9.Location = New System.Drawing.Point(444, 18)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(119, 37)
        Me.GroupBox9.TabIndex = 28
        Me.GroupBox9.TabStop = False
        '
        'chk_MPrima
        '
        Me.chk_MPrima.AutoSize = True
        Me.chk_MPrima.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_MPrima.Location = New System.Drawing.Point(8, 14)
        Me.chk_MPrima.Name = "chk_MPrima"
        Me.chk_MPrima.Size = New System.Drawing.Size(103, 17)
        Me.chk_MPrima.TabIndex = 0
        Me.chk_MPrima.Text = "Matéria Prima"
        Me.chk_MPrima.UseVisualStyleBackColor = True
        '
        'Grp_opcao
        '
        Me.Grp_opcao.Controls.Add(Me.Rdb_codigo)
        Me.Grp_opcao.Controls.Add(Me.Rdb_produto)
        Me.Grp_opcao.Controls.Add(Me.rdb_barra)
        Me.Grp_opcao.Location = New System.Drawing.Point(569, 18)
        Me.Grp_opcao.Name = "Grp_opcao"
        Me.Grp_opcao.Size = New System.Drawing.Size(235, 37)
        Me.Grp_opcao.TabIndex = 27
        Me.Grp_opcao.TabStop = False
        Me.Grp_opcao.Text = "Opção:"
        '
        'Rdb_codigo
        '
        Me.Rdb_codigo.AutoSize = True
        Me.Rdb_codigo.Location = New System.Drawing.Point(14, 15)
        Me.Rdb_codigo.Name = "Rdb_codigo"
        Me.Rdb_codigo.Size = New System.Drawing.Size(58, 17)
        Me.Rdb_codigo.TabIndex = 2
        Me.Rdb_codigo.Text = "Código"
        Me.Rdb_codigo.UseVisualStyleBackColor = True
        '
        'Rdb_produto
        '
        Me.Rdb_produto.AutoSize = True
        Me.Rdb_produto.Checked = True
        Me.Rdb_produto.Location = New System.Drawing.Point(162, 14)
        Me.Rdb_produto.Name = "Rdb_produto"
        Me.Rdb_produto.Size = New System.Drawing.Size(62, 17)
        Me.Rdb_produto.TabIndex = 1
        Me.Rdb_produto.TabStop = True
        Me.Rdb_produto.Text = "Produto"
        Me.Rdb_produto.UseVisualStyleBackColor = True
        '
        'rdb_barra
        '
        Me.rdb_barra.AutoSize = True
        Me.rdb_barra.Location = New System.Drawing.Point(84, 14)
        Me.rdb_barra.Name = "rdb_barra"
        Me.rdb_barra.Size = New System.Drawing.Size(69, 17)
        Me.rdb_barra.TabIndex = 0
        Me.rdb_barra.Text = "CodBarra"
        Me.rdb_barra.UseVisualStyleBackColor = True
        '
        'dtg_produto
        '
        Me.dtg_produto.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumAquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_produto.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_produto.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_produto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_produto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_produto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_produto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_produto.ColumnHeadersHeight = 28
        Me.dtg_produto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_produto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.nome, Me.qtde, Me.und, Me.valor, Me.codpart})
        Me.dtg_produto.Location = New System.Drawing.Point(10, 63)
        Me.dtg_produto.MultiSelect = False
        Me.dtg_produto.Name = "dtg_produto"
        Me.dtg_produto.ReadOnly = True
        Me.dtg_produto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_produto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtg_produto.Size = New System.Drawing.Size(794, 317)
        Me.dtg_produto.TabIndex = 25
        '
        'codigo
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigo.DefaultCellStyle = DataGridViewCellStyle3
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.MaxInputLength = 6
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.codigo.Width = 80
        '
        'nome
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nome.DefaultCellStyle = DataGridViewCellStyle4
        Me.nome.HeaderText = "Nome"
        Me.nome.MaxInputLength = 80
        Me.nome.Name = "nome"
        Me.nome.ReadOnly = True
        Me.nome.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nome.Width = 355
        '
        'qtde
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtde.DefaultCellStyle = DataGridViewCellStyle5
        Me.qtde.HeaderText = "Qtde"
        Me.qtde.MaxInputLength = 14
        Me.qtde.Name = "qtde"
        Me.qtde.ReadOnly = True
        Me.qtde.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.qtde.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.qtde.Width = 90
        '
        'und
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.und.DefaultCellStyle = DataGridViewCellStyle6
        Me.und.HeaderText = "UND"
        Me.und.MaxInputLength = 7
        Me.und.MinimumWidth = 2
        Me.und.Name = "und"
        Me.und.ReadOnly = True
        Me.und.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.und.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.und.Width = 53
        '
        'valor
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valor.DefaultCellStyle = DataGridViewCellStyle7
        Me.valor.HeaderText = "Pr. Venda"
        Me.valor.MaxInputLength = 25
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
        Me.valor.Width = 90
        '
        'codpart
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codpart.DefaultCellStyle = DataGridViewCellStyle8
        Me.codpart.HeaderText = "CodPart"
        Me.codpart.MaxInputLength = 7
        Me.codpart.Name = "codpart"
        Me.codpart.ReadOnly = True
        Me.codpart.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.codpart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.codpart.Width = 80
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(61, 28)
        Me.txt_pesquisa.MaxLength = 80
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(375, 23)
        Me.txt_pesquisa.TabIndex = 19
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(7, 31)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(48, 16)
        Me.Label28.TabIndex = 22
        Me.Label28.Text = "Nome:"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.lbl_mensagem01)
        Me.GroupBox7.Location = New System.Drawing.Point(10, 386)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(794, 48)
        Me.GroupBox7.TabIndex = 20
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Mensagem"
        '
        'lbl_mensagem01
        '
        Me.lbl_mensagem01.AutoSize = True
        Me.lbl_mensagem01.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem01.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem01.Location = New System.Drawing.Point(20, 19)
        Me.lbl_mensagem01.Name = "lbl_mensagem01"
        Me.lbl_mensagem01.Size = New System.Drawing.Size(28, 17)
        Me.lbl_mensagem01.TabIndex = 0
        Me.lbl_mensagem01.Text = ".   "
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(274, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(234, 63)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-3, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(838, 74)
        Me.Panel1.TabIndex = 6
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Wide Latin", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(629, 41)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(201, 27)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'ToolTipInfo
        '
        Me.ToolTipInfo.IsBalloon = True
        '
        'Frm_PesquisaProdutos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 548)
        Me.Controls.Add(Me.tbc_produtos)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_PesquisaProdutos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pesquisa de Produtos"
        Me.tbc_produtos.ResumeLayout(False)
        Me.tbp_vizualicao.ResumeLayout(False)
        Me.tbp_vizualicao.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.Grp_opcao.ResumeLayout(False)
        Me.Grp_opcao.PerformLayout()
        CType(Me.dtg_produto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbc_produtos As System.Windows.Forms.TabControl
    Friend WithEvents tbp_vizualicao As System.Windows.Forms.TabPage
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_MPrima As System.Windows.Forms.CheckBox
    Friend WithEvents Grp_opcao As System.Windows.Forms.GroupBox
    Friend WithEvents Rdb_codigo As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_produto As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_barra As System.Windows.Forms.RadioButton
    Friend WithEvents dtg_produto As System.Windows.Forms.DataGridView
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem01 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ToolTipInfo As System.Windows.Forms.ToolTip
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents und As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codpart As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
