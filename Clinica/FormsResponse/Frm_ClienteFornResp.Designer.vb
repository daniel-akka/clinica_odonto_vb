<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ClienteFornResp
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rdb_nome = New System.Windows.Forms.RadioButton()
        Me.rdb_codigo = New System.Windows.Forms.RadioButton()
        Me.btn_confirmar = New System.Windows.Forms.Button()
        Me.lbl_pesquisa = New System.Windows.Forms.Label()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.grp_opcoes = New System.Windows.Forms.GroupBox()
        Me.rdb_cnpj_cpf = New System.Windows.Forms.RadioButton()
        Me.Dtg_particpante = New System.Windows.Forms.DataGridView()
        Me.lbl_registros = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grb_registros = New System.Windows.Forms.GroupBox()
        Me.rdb_ficha = New System.Windows.Forms.RadioButton()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cpf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cnpj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grp_opcoes.SuspendLayout()
        CType(Me.Dtg_particpante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grb_registros.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(156, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(294, 35)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Pesquisa de Participante"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdb_nome
        '
        Me.rdb_nome.AutoSize = True
        Me.rdb_nome.Location = New System.Drawing.Point(6, 43)
        Me.rdb_nome.Name = "rdb_nome"
        Me.rdb_nome.Size = New System.Drawing.Size(94, 19)
        Me.rdb_nome.TabIndex = 1
        Me.rdb_nome.Text = "NOME       "
        Me.rdb_nome.UseVisualStyleBackColor = True
        '
        'rdb_codigo
        '
        Me.rdb_codigo.AutoSize = True
        Me.rdb_codigo.Location = New System.Drawing.Point(6, 66)
        Me.rdb_codigo.Name = "rdb_codigo"
        Me.rdb_codigo.Size = New System.Drawing.Size(94, 19)
        Me.rdb_codigo.TabIndex = 1
        Me.rdb_codigo.Text = "CODIGO    "
        Me.rdb_codigo.UseVisualStyleBackColor = True
        '
        'btn_confirmar
        '
        Me.btn_confirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_confirmar.Image = Global.RTecSys.My.Resources.Resources.accept001
        Me.btn_confirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_confirmar.Location = New System.Drawing.Point(135, 96)
        Me.btn_confirmar.Name = "btn_confirmar"
        Me.btn_confirmar.Size = New System.Drawing.Size(81, 60)
        Me.btn_confirmar.TabIndex = 18
        Me.btn_confirmar.Text = "&OK"
        Me.btn_confirmar.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btn_confirmar.UseVisualStyleBackColor = True
        '
        'lbl_pesquisa
        '
        Me.lbl_pesquisa.AutoSize = True
        Me.lbl_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pesquisa.Location = New System.Drawing.Point(132, 69)
        Me.lbl_pesquisa.Name = "lbl_pesquisa"
        Me.lbl_pesquisa.Size = New System.Drawing.Size(84, 15)
        Me.lbl_pesquisa.TabIndex = 17
        Me.lbl_pesquisa.Text = "CNPJ ou CPF:"
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(230, 65)
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(119, 23)
        Me.txt_pesquisa.TabIndex = 16
        '
        'grp_opcoes
        '
        Me.grp_opcoes.Controls.Add(Me.rdb_nome)
        Me.grp_opcoes.Controls.Add(Me.rdb_ficha)
        Me.grp_opcoes.Controls.Add(Me.rdb_codigo)
        Me.grp_opcoes.Controls.Add(Me.rdb_cnpj_cpf)
        Me.grp_opcoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_opcoes.Location = New System.Drawing.Point(10, 42)
        Me.grp_opcoes.Name = "grp_opcoes"
        Me.grp_opcoes.Size = New System.Drawing.Size(109, 114)
        Me.grp_opcoes.TabIndex = 15
        Me.grp_opcoes.TabStop = False
        Me.grp_opcoes.Text = "Opções"
        '
        'rdb_cnpj_cpf
        '
        Me.rdb_cnpj_cpf.AutoSize = True
        Me.rdb_cnpj_cpf.Checked = True
        Me.rdb_cnpj_cpf.Location = New System.Drawing.Point(6, 22)
        Me.rdb_cnpj_cpf.Name = "rdb_cnpj_cpf"
        Me.rdb_cnpj_cpf.Size = New System.Drawing.Size(94, 19)
        Me.rdb_cnpj_cpf.TabIndex = 1
        Me.rdb_cnpj_cpf.TabStop = True
        Me.rdb_cnpj_cpf.Text = "CNPJ; CPF"
        Me.rdb_cnpj_cpf.UseVisualStyleBackColor = True
        '
        'Dtg_particpante
        '
        Me.Dtg_particpante.AllowUserToAddRows = False
        Me.Dtg_particpante.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtg_particpante.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dtg_particpante.BackgroundColor = System.Drawing.Color.DarkGray
        Me.Dtg_particpante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dtg_particpante.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dtg_particpante.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dtg_particpante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dtg_particpante.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.ficha, Me.nome, Me.cpf, Me.UF, Me.cnpj})
        Me.Dtg_particpante.Location = New System.Drawing.Point(12, 166)
        Me.Dtg_particpante.MultiSelect = False
        Me.Dtg_particpante.Name = "Dtg_particpante"
        Me.Dtg_particpante.ReadOnly = True
        Me.Dtg_particpante.Size = New System.Drawing.Size(657, 168)
        Me.Dtg_particpante.TabIndex = 19
        '
        'lbl_registros
        '
        Me.lbl_registros.AutoSize = True
        Me.lbl_registros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_registros.ForeColor = System.Drawing.Color.OrangeRed
        Me.lbl_registros.Location = New System.Drawing.Point(85, 12)
        Me.lbl_registros.Name = "lbl_registros"
        Me.lbl_registros.Size = New System.Drawing.Size(14, 13)
        Me.lbl_registros.TabIndex = 1
        Me.lbl_registros.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Registros: "
        '
        'grb_registros
        '
        Me.grb_registros.BackColor = System.Drawing.SystemColors.Control
        Me.grb_registros.Controls.Add(Me.lbl_registros)
        Me.grb_registros.Controls.Add(Me.Label2)
        Me.grb_registros.Location = New System.Drawing.Point(529, 124)
        Me.grb_registros.Name = "grb_registros"
        Me.grb_registros.Size = New System.Drawing.Size(140, 32)
        Me.grb_registros.TabIndex = 20
        Me.grb_registros.TabStop = False
        '
        'rdb_ficha
        '
        Me.rdb_ficha.AutoSize = True
        Me.rdb_ficha.Location = New System.Drawing.Point(6, 89)
        Me.rdb_ficha.Name = "rdb_ficha"
        Me.rdb_ficha.Size = New System.Drawing.Size(88, 19)
        Me.rdb_ficha.TabIndex = 1
        Me.rdb_ficha.Text = "FICHA      "
        Me.rdb_ficha.UseVisualStyleBackColor = True
        '
        'codigo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codigo.DefaultCellStyle = DataGridViewCellStyle3
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.codigo.Width = 60
        '
        'ficha
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ficha.DefaultCellStyle = DataGridViewCellStyle4
        Me.ficha.HeaderText = "Ficha"
        Me.ficha.Name = "ficha"
        Me.ficha.ReadOnly = True
        Me.ficha.Width = 85
        '
        'nome
        '
        Me.nome.HeaderText = "Nome"
        Me.nome.Name = "nome"
        Me.nome.ReadOnly = True
        Me.nome.Width = 300
        '
        'cpf
        '
        Me.cpf.HeaderText = "Cpf"
        Me.cpf.Name = "cpf"
        Me.cpf.ReadOnly = True
        '
        'UF
        '
        Me.UF.HeaderText = "UF"
        Me.UF.MinimumWidth = 2
        Me.UF.Name = "UF"
        Me.UF.ReadOnly = True
        Me.UF.Width = 30
        '
        'cnpj
        '
        Me.cnpj.HeaderText = "Cnpj"
        Me.cnpj.Name = "cnpj"
        Me.cnpj.ReadOnly = True
        '
        'Frm_ClienteFornResp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 342)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_confirmar)
        Me.Controls.Add(Me.lbl_pesquisa)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.Controls.Add(Me.grp_opcoes)
        Me.Controls.Add(Me.Dtg_particpante)
        Me.Controls.Add(Me.grb_registros)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ClienteFornResp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pesquisa de Cliente"
        Me.grp_opcoes.ResumeLayout(False)
        Me.grp_opcoes.PerformLayout()
        CType(Me.Dtg_particpante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grb_registros.ResumeLayout(False)
        Me.grb_registros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdb_nome As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_codigo As System.Windows.Forms.RadioButton
    Friend WithEvents btn_confirmar As System.Windows.Forms.Button
    Friend WithEvents lbl_pesquisa As System.Windows.Forms.Label
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents grp_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_cnpj_cpf As System.Windows.Forms.RadioButton
    Friend WithEvents Dtg_particpante As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_registros As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grb_registros As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_ficha As System.Windows.Forms.RadioButton
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cpf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnpj As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
