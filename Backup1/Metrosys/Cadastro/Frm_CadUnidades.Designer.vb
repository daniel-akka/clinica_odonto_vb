<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CadUnidades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CadUnidades))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lbl_mesagem2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label26 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_salvar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.tbp_manutencao = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_descricao = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_abreveatura = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.btn_novo = New System.Windows.Forms.Button
        Me.Dtg_Unidades = New System.Windows.Forms.DataGridView
        Me.idUsu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.abreveatura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descricao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tbp_vizualiza = New System.Windows.Forms.TabPage
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.tbc_unidades = New System.Windows.Forms.TabControl
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tbp_manutencao.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Dtg_Unidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tbp_vizualiza.SuspendLayout()
        Me.tbc_unidades.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_mesagem2
        '
        Me.lbl_mesagem2.AutoSize = True
        Me.lbl_mesagem2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mesagem2.ForeColor = System.Drawing.Color.Red
        Me.lbl_mesagem2.Location = New System.Drawing.Point(20, 23)
        Me.lbl_mesagem2.Name = "lbl_mesagem2"
        Me.lbl_mesagem2.Size = New System.Drawing.Size(23, 17)
        Me.lbl_mesagem2.TabIndex = 0
        Me.lbl_mesagem2.Text = "   "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(504, 83)
        Me.Panel1.TabIndex = 23
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Wide Latin", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(359, 56)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(140, 18)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(157, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(193, 59)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbl_mesagem2)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 189)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(458, 52)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Mensagem"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_salvar)
        Me.GroupBox3.Controls.Add(Me.btn_cancelar)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(237, 112)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(211, 58)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        '
        'btn_salvar
        '
        Me.btn_salvar.Enabled = False
        Me.btn_salvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salvar.Image = Global.MetroSys.My.Resources.Resources.salvar
        Me.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salvar.Location = New System.Drawing.Point(17, 18)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(83, 29)
        Me.btn_salvar.TabIndex = 11
        Me.btn_salvar.Text = "&Salvar"
        Me.btn_salvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.MetroSys.My.Resources.Resources.cancelar1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancelar.Location = New System.Drawing.Point(106, 18)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(83, 29)
        Me.btn_cancelar.TabIndex = 12
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'tbp_manutencao
        '
        Me.tbp_manutencao.Controls.Add(Me.GroupBox4)
        Me.tbp_manutencao.Controls.Add(Me.GroupBox2)
        Me.tbp_manutencao.Location = New System.Drawing.Point(4, 22)
        Me.tbp_manutencao.Name = "tbp_manutencao"
        Me.tbp_manutencao.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_manutencao.Size = New System.Drawing.Size(477, 251)
        Me.tbp_manutencao.TabIndex = 1
        Me.tbp_manutencao.Text = "Manutenção"
        Me.tbp_manutencao.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_descricao)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txt_abreveatura)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(458, 176)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        '
        'txt_descricao
        '
        Me.txt_descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_descricao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descricao.Location = New System.Drawing.Point(87, 68)
        Me.txt_descricao.MaxLength = 60
        Me.txt_descricao.Name = "txt_descricao"
        Me.txt_descricao.Size = New System.Drawing.Size(361, 22)
        Me.txt_descricao.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Descrição:"
        '
        'txt_abreveatura
        '
        Me.txt_abreveatura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_abreveatura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_abreveatura.Location = New System.Drawing.Point(87, 35)
        Me.txt_abreveatura.MaxLength = 3
        Me.txt_abreveatura.Name = "txt_abreveatura"
        Me.txt_abreveatura.Size = New System.Drawing.Size(55, 22)
        Me.txt_abreveatura.TabIndex = 1
        Me.txt_abreveatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "&Abrevatura:"
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excluir.Location = New System.Drawing.Point(394, 12)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(72, 32)
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
        Me.btn_novo.Location = New System.Drawing.Point(245, 12)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(72, 32)
        Me.btn_novo.TabIndex = 21
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'Dtg_Unidades
        '
        Me.Dtg_Unidades.AllowUserToAddRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtg_Unidades.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.Dtg_Unidades.BackgroundColor = System.Drawing.Color.Gray
        Me.Dtg_Unidades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dtg_Unidades.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.Dtg_Unidades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dtg_Unidades.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.Dtg_Unidades.ColumnHeadersHeight = 26
        Me.Dtg_Unidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dtg_Unidades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idUsu, Me.abreveatura, Me.descricao})
        Me.Dtg_Unidades.Location = New System.Drawing.Point(13, 52)
        Me.Dtg_Unidades.MultiSelect = False
        Me.Dtg_Unidades.Name = "Dtg_Unidades"
        Me.Dtg_Unidades.ReadOnly = True
        Me.Dtg_Unidades.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Dtg_Unidades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dtg_Unidades.Size = New System.Drawing.Size(453, 127)
        Me.Dtg_Unidades.TabIndex = 25
        '
        'idUsu
        '
        Me.idUsu.HeaderText = "Id"
        Me.idUsu.MaxInputLength = 13
        Me.idUsu.Name = "idUsu"
        Me.idUsu.ReadOnly = True
        Me.idUsu.Visible = False
        '
        'abreveatura
        '
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.abreveatura.DefaultCellStyle = DataGridViewCellStyle11
        Me.abreveatura.HeaderText = "Abrev."
        Me.abreveatura.MaxInputLength = 30
        Me.abreveatura.Name = "abreveatura"
        Me.abreveatura.ReadOnly = True
        Me.abreveatura.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.abreveatura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.abreveatura.Width = 65
        '
        'descricao
        '
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descricao.DefaultCellStyle = DataGridViewCellStyle12
        Me.descricao.HeaderText = "Descrição"
        Me.descricao.MaxInputLength = 60
        Me.descricao.Name = "descricao"
        Me.descricao.ReadOnly = True
        Me.descricao.Width = 328
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(20, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "   "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 189)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(453, 52)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mensagem"
        '
        'tbp_vizualiza
        '
        Me.tbp_vizualiza.Controls.Add(Me.Dtg_Unidades)
        Me.tbp_vizualiza.Controls.Add(Me.btn_excluir)
        Me.tbp_vizualiza.Controls.Add(Me.btn_novo)
        Me.tbp_vizualiza.Controls.Add(Me.btn_alterar)
        Me.tbp_vizualiza.Controls.Add(Me.Label7)
        Me.tbp_vizualiza.Controls.Add(Me.GroupBox1)
        Me.tbp_vizualiza.Location = New System.Drawing.Point(4, 22)
        Me.tbp_vizualiza.Name = "tbp_vizualiza"
        Me.tbp_vizualiza.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_vizualiza.Size = New System.Drawing.Size(477, 251)
        Me.tbp_vizualiza.TabIndex = 0
        Me.tbp_vizualiza.Text = "Vizualização"
        Me.tbp_vizualiza.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.editar
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(320, 12)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(72, 32)
        Me.btn_alterar.TabIndex = 23
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(157, 16)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Unidades de Medida:"
        '
        'tbc_unidades
        '
        Me.tbc_unidades.Controls.Add(Me.tbp_vizualiza)
        Me.tbc_unidades.Controls.Add(Me.tbp_manutencao)
        Me.tbc_unidades.Location = New System.Drawing.Point(8, 86)
        Me.tbc_unidades.Name = "tbc_unidades"
        Me.tbc_unidades.SelectedIndex = 0
        Me.tbc_unidades.Size = New System.Drawing.Size(485, 277)
        Me.tbc_unidades.TabIndex = 22
        '
        'Frm_CadUnidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 370)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tbc_unidades)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_CadUnidades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadatros de Unidades de Medida"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.tbp_manutencao.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Dtg_Unidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbp_vizualiza.ResumeLayout(False)
        Me.tbp_vizualiza.PerformLayout()
        Me.tbc_unidades.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_mesagem2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents tbp_manutencao As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents Dtg_Unidades As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbp_vizualiza As System.Windows.Forms.TabPage
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbc_unidades As System.Windows.Forms.TabControl
    Friend WithEvents txt_descricao As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_abreveatura As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents idUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents abreveatura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descricao As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
