<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CadDentistas
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.dtg_doutores = New System.Windows.Forms.DataGridView()
        Me.idUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.doutor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comissao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_comiss = New System.Windows.Forms.TextBox()
        Me.btn_salvar = New System.Windows.Forms.Button()
        Me.msk_Telefone = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Nome = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Id = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_iniciais = New System.Windows.Forms.TextBox()
        Me.chk_protetico = New System.Windows.Forms.CheckBox()
        CType(Me.dtg_doutores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(76, 60)
        Me.txt_pesquisa.MaxLength = 60
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(193, 23)
        Me.txt_pesquisa.TabIndex = 26
        '
        'dtg_doutores
        '
        Me.dtg_doutores.AllowUserToAddRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_doutores.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dtg_doutores.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_doutores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_doutores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_doutores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_doutores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_doutores.ColumnHeadersHeight = 26
        Me.dtg_doutores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_doutores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idUsu, Me.doutor, Me.telefone, Me.comissao})
        Me.dtg_doutores.Location = New System.Drawing.Point(19, 92)
        Me.dtg_doutores.MultiSelect = False
        Me.dtg_doutores.Name = "dtg_doutores"
        Me.dtg_doutores.ReadOnly = True
        Me.dtg_doutores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_doutores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_doutores.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dtg_doutores.Size = New System.Drawing.Size(571, 127)
        Me.dtg_doutores.TabIndex = 31
        '
        'idUsu
        '
        Me.idUsu.HeaderText = "Id"
        Me.idUsu.MaxInputLength = 13
        Me.idUsu.Name = "idUsu"
        Me.idUsu.ReadOnly = True
        Me.idUsu.Visible = False
        '
        'doutor
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.doutor.DefaultCellStyle = DataGridViewCellStyle9
        Me.doutor.HeaderText = "Dentista"
        Me.doutor.MaxInputLength = 2
        Me.doutor.Name = "doutor"
        Me.doutor.ReadOnly = True
        Me.doutor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.doutor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.doutor.Width = 340
        '
        'telefone
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.telefone.DefaultCellStyle = DataGridViewCellStyle10
        Me.telefone.HeaderText = "Telefone"
        Me.telefone.MaxInputLength = 60
        Me.telefone.Name = "telefone"
        Me.telefone.ReadOnly = True
        '
        'comissao
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.comissao.DefaultCellStyle = DataGridViewCellStyle11
        Me.comissao.HeaderText = "Comiss"
        Me.comissao.Name = "comissao"
        Me.comissao.ReadOnly = True
        Me.comissao.Width = 70
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
        Me.btn_excluir.Location = New System.Drawing.Point(499, 52)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(91, 31)
        Me.btn_excluir.TabIndex = 30
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
        Me.btn_novo.Location = New System.Drawing.Point(323, 52)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(80, 31)
        Me.btn_novo.TabIndex = 27
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = False
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
        Me.btn_alterar.Location = New System.Drawing.Point(407, 52)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(89, 31)
        Me.btn_alterar.TabIndex = 29
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 17)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Nome:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_protetico)
        Me.GroupBox1.Controls.Add(Me.txt_iniciais)
        Me.GroupBox1.Controls.Add(Me.txt_comiss)
        Me.GroupBox1.Controls.Add(Me.btn_salvar)
        Me.GroupBox1.Controls.Add(Me.msk_Telefone)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_Nome)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_Id)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(19, 225)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 96)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        '
        'txt_comiss
        '
        Me.txt_comiss.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comiss.Location = New System.Drawing.Point(393, 17)
        Me.txt_comiss.MaxLength = 14
        Me.txt_comiss.Name = "txt_comiss"
        Me.txt_comiss.Size = New System.Drawing.Size(55, 23)
        Me.txt_comiss.TabIndex = 5
        Me.txt_comiss.Text = "0,00"
        Me.txt_comiss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.btn_salvar.Location = New System.Drawing.Point(483, 17)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(75, 67)
        Me.btn_salvar.TabIndex = 12
        Me.btn_salvar.Text = "&Salvar"
        Me.btn_salvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salvar.UseVisualStyleBackColor = False
        '
        'msk_Telefone
        '
        Me.msk_Telefone.Location = New System.Drawing.Point(192, 17)
        Me.msk_Telefone.Mask = "(99) 0000-0000"
        Me.msk_Telefone.Name = "msk_Telefone"
        Me.msk_Telefone.Size = New System.Drawing.Size(100, 23)
        Me.msk_Telefone.TabIndex = 3
        Me.msk_Telefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(316, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Comissão:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(118, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Telefone:"
        '
        'txt_Nome
        '
        Me.txt_Nome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Nome.Location = New System.Drawing.Point(15, 64)
        Me.txt_Nome.MaxLength = 100
        Me.txt_Nome.Name = "txt_Nome"
        Me.txt_Nome.Size = New System.Drawing.Size(246, 23)
        Me.txt_Nome.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nome:"
        '
        'txt_Id
        '
        Me.txt_Id.BackColor = System.Drawing.SystemColors.Info
        Me.txt_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Id.Location = New System.Drawing.Point(44, 17)
        Me.txt_Id.MaxLength = 30
        Me.txt_Id.Name = "txt_Id"
        Me.txt_Id.ReadOnly = True
        Me.txt_Id.Size = New System.Drawing.Size(50, 23)
        Me.txt_Id.TabIndex = 1
        Me.txt_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-6, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(620, 42)
        Me.Panel1.TabIndex = 55
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(244, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(287, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 17)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Iniciais:"
        '
        'txt_iniciais
        '
        Me.txt_iniciais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_iniciais.Location = New System.Drawing.Point(290, 64)
        Me.txt_iniciais.MaxLength = 4
        Me.txt_iniciais.Name = "txt_iniciais"
        Me.txt_iniciais.Size = New System.Drawing.Size(67, 23)
        Me.txt_iniciais.TabIndex = 13
        '
        'chk_protetico
        '
        Me.chk_protetico.AutoSize = True
        Me.chk_protetico.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_protetico.Location = New System.Drawing.Point(386, 64)
        Me.chk_protetico.Name = "chk_protetico"
        Me.chk_protetico.Size = New System.Drawing.Size(62, 21)
        Me.chk_protetico.TabIndex = 14
        Me.chk_protetico.Text = "Prot."
        Me.chk_protetico.UseVisualStyleBackColor = True
        '
        'Frm_CadDentistas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 332)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.Controls.Add(Me.dtg_doutores)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.btn_alterar)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_CadDentistas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Dentistas"
        CType(Me.dtg_doutores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents dtg_doutores As System.Windows.Forms.DataGridView
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents msk_Telefone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Nome As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_comiss As System.Windows.Forms.TextBox
    Friend WithEvents idUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents doutor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents telefone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comissao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chk_protetico As System.Windows.Forms.CheckBox
    Friend WithEvents txt_iniciais As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
