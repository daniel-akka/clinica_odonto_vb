<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RelatComodatos
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RelatComodatos))
        Me.tbc_comodatos = New System.Windows.Forms.TabControl
        Me.tbp_visuComodato = New System.Windows.Forms.TabPage
        Me.grp_opcoes = New System.Windows.Forms.GroupBox
        Me.cbo_cidade = New System.Windows.Forms.ComboBox
        Me.lbl_cidade = New System.Windows.Forms.Label
        Me.cbo_uf = New System.Windows.Forms.ComboBox
        Me.lbl_uf = New System.Windows.Forms.Label
        Me.cbo_tipo = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem01 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btn_novo = New System.Windows.Forms.Button
        Me.Dtg_MovComodatos = New System.Windows.Forms.DataGridView
        Me.idComodato = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.produto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Plaqueta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataMov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label26 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.tbc_comodatos.SuspendLayout()
        Me.tbp_visuComodato.SuspendLayout()
        Me.grp_opcoes.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Dtg_MovComodatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbc_comodatos
        '
        Me.tbc_comodatos.Controls.Add(Me.tbp_visuComodato)
        Me.tbc_comodatos.Location = New System.Drawing.Point(4, 70)
        Me.tbc_comodatos.Name = "tbc_comodatos"
        Me.tbc_comodatos.SelectedIndex = 0
        Me.tbc_comodatos.Size = New System.Drawing.Size(718, 325)
        Me.tbc_comodatos.TabIndex = 10
        '
        'tbp_visuComodato
        '
        Me.tbp_visuComodato.Controls.Add(Me.grp_opcoes)
        Me.tbp_visuComodato.Controls.Add(Me.GroupBox4)
        Me.tbp_visuComodato.Controls.Add(Me.btn_novo)
        Me.tbp_visuComodato.Controls.Add(Me.Dtg_MovComodatos)
        Me.tbp_visuComodato.Location = New System.Drawing.Point(4, 22)
        Me.tbp_visuComodato.Name = "tbp_visuComodato"
        Me.tbp_visuComodato.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_visuComodato.Size = New System.Drawing.Size(710, 299)
        Me.tbp_visuComodato.TabIndex = 0
        Me.tbp_visuComodato.Text = "Visualização"
        Me.tbp_visuComodato.UseVisualStyleBackColor = True
        '
        'grp_opcoes
        '
        Me.grp_opcoes.Controls.Add(Me.cbo_cidade)
        Me.grp_opcoes.Controls.Add(Me.lbl_cidade)
        Me.grp_opcoes.Controls.Add(Me.cbo_uf)
        Me.grp_opcoes.Controls.Add(Me.lbl_uf)
        Me.grp_opcoes.Controls.Add(Me.cbo_tipo)
        Me.grp_opcoes.Controls.Add(Me.Label7)
        Me.grp_opcoes.Location = New System.Drawing.Point(10, 6)
        Me.grp_opcoes.Name = "grp_opcoes"
        Me.grp_opcoes.Size = New System.Drawing.Size(572, 40)
        Me.grp_opcoes.TabIndex = 28
        Me.grp_opcoes.TabStop = False
        Me.grp_opcoes.Text = "Opções"
        '
        'cbo_cidade
        '
        Me.cbo_cidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbo_cidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cbo_cidade.DropDownWidth = 300
        Me.cbo_cidade.FormattingEnabled = True
        Me.cbo_cidade.Location = New System.Drawing.Point(297, 14)
        Me.cbo_cidade.Name = "cbo_cidade"
        Me.cbo_cidade.Size = New System.Drawing.Size(259, 21)
        Me.cbo_cidade.TabIndex = 3
        '
        'lbl_cidade
        '
        Me.lbl_cidade.AutoSize = True
        Me.lbl_cidade.Location = New System.Drawing.Point(248, 18)
        Me.lbl_cidade.Name = "lbl_cidade"
        Me.lbl_cidade.Size = New System.Drawing.Size(43, 13)
        Me.lbl_cidade.TabIndex = 32
        Me.lbl_cidade.Text = "Cidade:"
        '
        'cbo_uf
        '
        Me.cbo_uf.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbo_uf.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_uf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_uf.FormattingEnabled = True
        Me.cbo_uf.Items.AddRange(New Object() {"", "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO", "EX"})
        Me.cbo_uf.Location = New System.Drawing.Point(177, 14)
        Me.cbo_uf.Name = "cbo_uf"
        Me.cbo_uf.Size = New System.Drawing.Size(48, 21)
        Me.cbo_uf.TabIndex = 2
        '
        'lbl_uf
        '
        Me.lbl_uf.AutoSize = True
        Me.lbl_uf.Location = New System.Drawing.Point(150, 18)
        Me.lbl_uf.Name = "lbl_uf"
        Me.lbl_uf.Size = New System.Drawing.Size(24, 13)
        Me.lbl_uf.TabIndex = 31
        Me.lbl_uf.Text = "UF:"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"01 - Freezer", "02 - Outros", "00 - Todos"})
        Me.cbo_tipo.Location = New System.Drawing.Point(41, 14)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(79, 21)
        Me.cbo_tipo.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Tipo:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbl_mensagem01)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 249)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(687, 40)
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
        'btn_novo
        '
        Me.btn_novo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_novo.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_novo.Location = New System.Drawing.Point(599, 14)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(95, 34)
        Me.btn_novo.TabIndex = 6
        Me.btn_novo.Text = "&Relatorios"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'Dtg_MovComodatos
        '
        Me.Dtg_MovComodatos.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtg_MovComodatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dtg_MovComodatos.BackgroundColor = System.Drawing.Color.Gray
        Me.Dtg_MovComodatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dtg_MovComodatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.Dtg_MovComodatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dtg_MovComodatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dtg_MovComodatos.ColumnHeadersHeight = 28
        Me.Dtg_MovComodatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dtg_MovComodatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idComodato, Me.cliente, Me.produto, Me.Plaqueta, Me.dataMov})
        Me.Dtg_MovComodatos.Location = New System.Drawing.Point(10, 63)
        Me.Dtg_MovComodatos.MultiSelect = False
        Me.Dtg_MovComodatos.Name = "Dtg_MovComodatos"
        Me.Dtg_MovComodatos.ReadOnly = True
        Me.Dtg_MovComodatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Dtg_MovComodatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtg_MovComodatos.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Dtg_MovComodatos.Size = New System.Drawing.Size(684, 182)
        Me.Dtg_MovComodatos.TabIndex = 19
        '
        'idComodato
        '
        Me.idComodato.HeaderText = "id"
        Me.idComodato.Name = "idComodato"
        Me.idComodato.ReadOnly = True
        Me.idComodato.Visible = False
        '
        'cliente
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cliente.DefaultCellStyle = DataGridViewCellStyle3
        Me.cliente.HeaderText = "Cliente"
        Me.cliente.MaxInputLength = 60
        Me.cliente.Name = "cliente"
        Me.cliente.ReadOnly = True
        Me.cliente.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cliente.Width = 230
        '
        'produto
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.produto.DefaultCellStyle = DataGridViewCellStyle4
        Me.produto.HeaderText = "Produto"
        Me.produto.MaxInputLength = 80
        Me.produto.Name = "produto"
        Me.produto.ReadOnly = True
        Me.produto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.produto.Width = 110
        '
        'Plaqueta
        '
        Me.Plaqueta.HeaderText = "Plaqueta"
        Me.Plaqueta.MaxInputLength = 80
        Me.Plaqueta.Name = "Plaqueta"
        Me.Plaqueta.ReadOnly = True
        Me.Plaqueta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Plaqueta.Width = 200
        '
        'dataMov
        '
        Me.dataMov.HeaderText = "Emprestimo"
        Me.dataMov.MaxInputLength = 12
        Me.dataMov.Name = "dataMov"
        Me.dataMov.ReadOnly = True
        Me.dataMov.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Wide Latin", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(552, 40)
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
        Me.Panel1.Location = New System.Drawing.Point(-3, -3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(733, 74)
        Me.Panel1.TabIndex = 9
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(246, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(204, 61)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
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
        'Frm_RelatComodatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 403)
        Me.Controls.Add(Me.tbc_comodatos)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_RelatComodatos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatórios de Comodatos"
        Me.tbc_comodatos.ResumeLayout(False)
        Me.tbp_visuComodato.ResumeLayout(False)
        Me.grp_opcoes.ResumeLayout(False)
        Me.grp_opcoes.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.Dtg_MovComodatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbc_comodatos As System.Windows.Forms.TabControl
    Friend WithEvents tbp_visuComodato As System.Windows.Forms.TabPage
    Friend WithEvents grp_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem01 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents Dtg_MovComodatos As System.Windows.Forms.DataGridView
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents idComodato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents produto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Plaqueta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataMov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbo_cidade As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_cidade As System.Windows.Forms.Label
    Public WithEvents cbo_uf As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_uf As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
End Class
