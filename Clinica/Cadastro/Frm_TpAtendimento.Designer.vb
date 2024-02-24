<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_TpAtendimento
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
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_comiss = New System.Windows.Forms.TextBox()
        Me.btn_salvar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Descricao = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Id = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.dtg_doutores = New System.Windows.Forms.DataGridView()
        Me.idUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.doutor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comissao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtg_doutores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-8, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(591, 42)
        Me.Panel1.TabIndex = 63
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_comiss)
        Me.GroupBox1.Controls.Add(Me.btn_salvar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_Descricao)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_Id)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(17, 226)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(550, 96)
        Me.GroupBox1.TabIndex = 62
        Me.GroupBox1.TabStop = False
        '
        'txt_comiss
        '
        Me.txt_comiss.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comiss.Location = New System.Drawing.Point(355, 63)
        Me.txt_comiss.MaxLength = 14
        Me.txt_comiss.Name = "txt_comiss"
        Me.txt_comiss.Size = New System.Drawing.Size(61, 24)
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
        Me.btn_salvar.Location = New System.Drawing.Point(447, 17)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(75, 67)
        Me.btn_salvar.TabIndex = 12
        Me.btn_salvar.Text = "&Salvar"
        Me.btn_salvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salvar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(352, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Comissão:"
        '
        'txt_Descricao
        '
        Me.txt_Descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Descricao.Location = New System.Drawing.Point(15, 65)
        Me.txt_Descricao.MaxLength = 60
        Me.txt_Descricao.Name = "txt_Descricao"
        Me.txt_Descricao.Size = New System.Drawing.Size(315, 23)
        Me.txt_Descricao.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descrição:"
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
        Me.btn_novo.Location = New System.Drawing.Point(288, 53)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(80, 31)
        Me.btn_novo.TabIndex = 57
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
        Me.btn_alterar.Location = New System.Drawing.Point(372, 53)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(89, 31)
        Me.btn_alterar.TabIndex = 59
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 17)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "Nome:"
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(74, 61)
        Me.txt_pesquisa.MaxLength = 60
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(185, 23)
        Me.txt_pesquisa.TabIndex = 56
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
        Me.btn_excluir.Location = New System.Drawing.Point(464, 53)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(91, 31)
        Me.btn_excluir.TabIndex = 60
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = False
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
        Me.dtg_doutores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idUsu, Me.doutor, Me.comissao})
        Me.dtg_doutores.Location = New System.Drawing.Point(17, 93)
        Me.dtg_doutores.MultiSelect = False
        Me.dtg_doutores.Name = "dtg_doutores"
        Me.dtg_doutores.ReadOnly = True
        Me.dtg_doutores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_doutores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_doutores.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_doutores.Size = New System.Drawing.Size(550, 127)
        Me.dtg_doutores.TabIndex = 61
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.doutor.DefaultCellStyle = DataGridViewCellStyle3
        Me.doutor.HeaderText = "Descrição de Atendimento"
        Me.doutor.MaxInputLength = 2
        Me.doutor.Name = "doutor"
        Me.doutor.ReadOnly = True
        Me.doutor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.doutor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.doutor.Width = 400
        '
        'comissao
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.comissao.DefaultCellStyle = DataGridViewCellStyle4
        Me.comissao.HeaderText = "Comissão"
        Me.comissao.Name = "comissao"
        Me.comissao.ReadOnly = True
        Me.comissao.Width = 90
        '
        'Frm_TpAtendimento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 332)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.btn_alterar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.dtg_doutores)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_TpAtendimento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo de Atendimento"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtg_doutores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_comiss As System.Windows.Forms.TextBox
    Public WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Descricao As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents dtg_doutores As System.Windows.Forms.DataGridView
    Friend WithEvents idUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents doutor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comissao As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
