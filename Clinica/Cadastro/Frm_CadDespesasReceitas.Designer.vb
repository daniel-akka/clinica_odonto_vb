<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CadDespesasReceitas
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_salvar = New System.Windows.Forms.Button()
        Me.txt_Nome = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.txt_Id = New System.Windows.Forms.TextBox()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.dtg_doutores = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.idUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtg_doutores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_salvar
        '
        Me.btn_salvar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_salvar.Enabled = False
        Me.btn_salvar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_salvar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_salvar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salvar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_salvar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_salvar.Image = Global.RTecSys.My.Resources.Resources.salvar
        Me.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salvar.Location = New System.Drawing.Point(453, 17)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(75, 67)
        Me.btn_salvar.TabIndex = 12
        Me.btn_salvar.Text = "&Salvar"
        Me.btn_salvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salvar.UseVisualStyleBackColor = False
        '
        'txt_Nome
        '
        Me.txt_Nome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Nome.Location = New System.Drawing.Point(15, 64)
        Me.txt_Nome.MaxLength = 100
        Me.txt_Nome.Name = "txt_Nome"
        Me.txt_Nome.Size = New System.Drawing.Size(415, 23)
        Me.txt_Nome.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descricao"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_tipo)
        Me.GroupBox1.Controls.Add(Me.btn_salvar)
        Me.GroupBox1.Controls.Add(Me.txt_Nome)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_Id)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(20, 224)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(536, 94)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(250, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Tipo:"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"Despesa", "Receita"})
        Me.cbo_tipo.Location = New System.Drawing.Point(296, 16)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(134, 24)
        Me.cbo_tipo.TabIndex = 13
        '
        'txt_Id
        '
        Me.txt_Id.BackColor = System.Drawing.SystemColors.Info
        Me.txt_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Id.Location = New System.Drawing.Point(44, 16)
        Me.txt_Id.MaxLength = 30
        Me.txt_Id.Name = "txt_Id"
        Me.txt_Id.ReadOnly = True
        Me.txt_Id.Size = New System.Drawing.Size(61, 23)
        Me.txt_Id.TabIndex = 1
        Me.txt_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_alterar
        '
        Me.btn_alterar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_alterar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_alterar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_alterar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_alterar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_alterar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_alterar.Image = Global.RTecSys.My.Resources.Resources.editar
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(373, 51)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(89, 31)
        Me.btn_alterar.TabIndex = 37
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = False
        '
        'btn_excluir
        '
        Me.btn_excluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_excluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_excluir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_excluir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_excluir.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_excluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_excluir.Image = Global.RTecSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excluir.Location = New System.Drawing.Point(465, 51)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(91, 31)
        Me.btn_excluir.TabIndex = 38
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = False
        '
        'btn_novo
        '
        Me.btn_novo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_novo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_novo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_novo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_novo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_novo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_novo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_novo.Image = Global.RTecSys.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_novo.Location = New System.Drawing.Point(289, 51)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(80, 31)
        Me.btn_novo.TabIndex = 35
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = False
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(77, 59)
        Me.txt_pesquisa.MaxLength = 60
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(193, 23)
        Me.txt_pesquisa.TabIndex = 34
        '
        'dtg_doutores
        '
        Me.dtg_doutores.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_doutores.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_doutores.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_doutores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_doutores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_doutores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_doutores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_doutores.ColumnHeadersHeight = 26
        Me.dtg_doutores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_doutores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idUsu, Me.descricao, Me.d_tipo})
        Me.dtg_doutores.Location = New System.Drawing.Point(20, 91)
        Me.dtg_doutores.MultiSelect = False
        Me.dtg_doutores.Name = "dtg_doutores"
        Me.dtg_doutores.ReadOnly = True
        Me.dtg_doutores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_doutores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_doutores.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_doutores.Size = New System.Drawing.Size(536, 127)
        Me.dtg_doutores.TabIndex = 39
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 17)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Nome:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-5, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(594, 42)
        Me.Panel1.TabIndex = 56
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(236, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'idUsu
        '
        Me.idUsu.HeaderText = "Id"
        Me.idUsu.MaxInputLength = 13
        Me.idUsu.Name = "idUsu"
        Me.idUsu.ReadOnly = True
        Me.idUsu.Visible = False
        '
        'descricao
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descricao.DefaultCellStyle = DataGridViewCellStyle3
        Me.descricao.HeaderText = "Descrição"
        Me.descricao.MaxInputLength = 2
        Me.descricao.Name = "descricao"
        Me.descricao.ReadOnly = True
        Me.descricao.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.descricao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.descricao.Width = 420
        '
        'd_tipo
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.d_tipo.DefaultCellStyle = DataGridViewCellStyle4
        Me.d_tipo.HeaderText = "Tipo"
        Me.d_tipo.MaxInputLength = 60
        Me.d_tipo.Name = "d_tipo"
        Me.d_tipo.ReadOnly = True
        Me.d_tipo.Width = 50
        '
        'Frm_CadDespesasReceitas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 333)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_alterar)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.Controls.Add(Me.dtg_doutores)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_CadDespesasReceitas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Despesa e Receitas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtg_doutores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents txt_Nome As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_Id As System.Windows.Forms.TextBox
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents dtg_doutores As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents idUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_tipo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
