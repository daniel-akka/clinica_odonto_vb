<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_cadGrupo
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_cadGrupo))
        Me.lbl_mesagem2 = New System.Windows.Forms.Label
        Me.Dtg_Grupos = New System.Windows.Forms.DataGridView
        Me.idUsu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grupo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descricao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_descricao = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_novo = New System.Windows.Forms.Button
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.tbp_vizualiza = New System.Windows.Forms.TabPage
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_salvar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.txt_grupo = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.tbp_manutencao = New System.Windows.Forms.TabPage
        Me.tbc_grupos = New System.Windows.Forms.TabControl
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.Dtg_Grupos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbp_vizualiza.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tbp_manutencao.SuspendLayout()
        Me.tbc_grupos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Dtg_Grupos
        '
        Me.Dtg_Grupos.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtg_Grupos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dtg_Grupos.BackgroundColor = System.Drawing.Color.Gray
        Me.Dtg_Grupos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dtg_Grupos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.Dtg_Grupos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dtg_Grupos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dtg_Grupos.ColumnHeadersHeight = 26
        Me.Dtg_Grupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dtg_Grupos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idUsu, Me.grupo, Me.descricao})
        Me.Dtg_Grupos.Location = New System.Drawing.Point(13, 52)
        Me.Dtg_Grupos.MultiSelect = False
        Me.Dtg_Grupos.Name = "Dtg_Grupos"
        Me.Dtg_Grupos.ReadOnly = True
        Me.Dtg_Grupos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Dtg_Grupos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dtg_Grupos.Size = New System.Drawing.Size(453, 127)
        Me.Dtg_Grupos.TabIndex = 25
        '
        'idUsu
        '
        Me.idUsu.HeaderText = "Id"
        Me.idUsu.MaxInputLength = 13
        Me.idUsu.Name = "idUsu"
        Me.idUsu.ReadOnly = True
        Me.idUsu.Visible = False
        '
        'grupo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grupo.DefaultCellStyle = DataGridViewCellStyle3
        Me.grupo.HeaderText = "Grupo"
        Me.grupo.MaxInputLength = 30
        Me.grupo.Name = "grupo"
        Me.grupo.ReadOnly = True
        Me.grupo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grupo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.grupo.Width = 65
        '
        'descricao
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descricao.DefaultCellStyle = DataGridViewCellStyle4
        Me.descricao.HeaderText = "Descrição"
        Me.descricao.MaxInputLength = 60
        Me.descricao.Name = "descricao"
        Me.descricao.ReadOnly = True
        Me.descricao.Width = 328
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
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Grupos:"
        '
        'tbp_vizualiza
        '
        Me.tbp_vizualiza.Controls.Add(Me.Dtg_Grupos)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "&Grupo:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(410, 53)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 18)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-3, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(504, 83)
        Me.Panel1.TabIndex = 25
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
        'txt_grupo
        '
        Me.txt_grupo.BackColor = System.Drawing.SystemColors.Info
        Me.txt_grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_grupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_grupo.Location = New System.Drawing.Point(87, 35)
        Me.txt_grupo.MaxLength = 3
        Me.txt_grupo.Name = "txt_grupo"
        Me.txt_grupo.ReadOnly = True
        Me.txt_grupo.Size = New System.Drawing.Size(41, 22)
        Me.txt_grupo.TabIndex = 1
        Me.txt_grupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_descricao)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txt_grupo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(458, 176)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
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
        'tbc_grupos
        '
        Me.tbc_grupos.Controls.Add(Me.tbp_vizualiza)
        Me.tbc_grupos.Controls.Add(Me.tbp_manutencao)
        Me.tbc_grupos.Location = New System.Drawing.Point(6, 86)
        Me.tbc_grupos.Name = "tbc_grupos"
        Me.tbc_grupos.SelectedIndex = 0
        Me.tbc_grupos.Size = New System.Drawing.Size(485, 277)
        Me.tbc_grupos.TabIndex = 24
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(394, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Frm_cadGrupo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 368)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tbc_grupos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_cadGrupo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Grupos"
        CType(Me.Dtg_Grupos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbp_vizualiza.ResumeLayout(False)
        Me.tbp_vizualiza.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tbp_manutencao.ResumeLayout(False)
        Me.tbc_grupos.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_mesagem2 As System.Windows.Forms.Label
    Friend WithEvents Dtg_Grupos As System.Windows.Forms.DataGridView
    Friend WithEvents txt_descricao As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbp_vizualiza As System.Windows.Forms.TabPage
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents txt_grupo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbp_manutencao As System.Windows.Forms.TabPage
    Friend WithEvents tbc_grupos As System.Windows.Forms.TabControl
    Friend WithEvents idUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
