<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BuscaProdComo
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grb_registros = New System.Windows.Forms.GroupBox
        Me.lbl_registros = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Dg_produto = New System.Windows.Forms.DataGridView
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cnpj_cpf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_confirmar = New System.Windows.Forms.Button
        Me.lbl_pesquisa = New System.Windows.Forms.Label
        Me.txt_pesquisa = New System.Windows.Forms.TextBox
        Me.grp_opcoes = New System.Windows.Forms.GroupBox
        Me.rdb_nome = New System.Windows.Forms.RadioButton
        Me.rdb_codigo = New System.Windows.Forms.RadioButton
        Me.rdb_CodForn = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.grb_registros.SuspendLayout()
        CType(Me.Dg_produto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_opcoes.SuspendLayout()
        Me.SuspendLayout()
        '
        'grb_registros
        '
        Me.grb_registros.BackColor = System.Drawing.SystemColors.Control
        Me.grb_registros.Controls.Add(Me.lbl_registros)
        Me.grb_registros.Controls.Add(Me.Label2)
        Me.grb_registros.Location = New System.Drawing.Point(478, 126)
        Me.grb_registros.Name = "grb_registros"
        Me.grb_registros.Size = New System.Drawing.Size(140, 32)
        Me.grb_registros.TabIndex = 20
        Me.grb_registros.TabStop = False
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
        'Dg_produto
        '
        Me.Dg_produto.AllowUserToAddRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dg_produto.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dg_produto.BackgroundColor = System.Drawing.Color.DarkGray
        Me.Dg_produto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dg_produto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg_produto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.nome, Me.cnpj_cpf})
        Me.Dg_produto.Location = New System.Drawing.Point(13, 165)
        Me.Dg_produto.MultiSelect = False
        Me.Dg_produto.Name = "Dg_produto"
        Me.Dg_produto.ReadOnly = True
        Me.Dg_produto.Size = New System.Drawing.Size(605, 168)
        Me.Dg_produto.TabIndex = 19
        '
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.MaxInputLength = 6
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.codigo.Width = 80
        '
        'nome
        '
        Me.nome.HeaderText = "Nome"
        Me.nome.Name = "nome"
        Me.nome.ReadOnly = True
        Me.nome.Width = 180
        '
        'cnpj_cpf
        '
        Me.cnpj_cpf.HeaderText = "Fornecedor"
        Me.cnpj_cpf.MaxInputLength = 12
        Me.cnpj_cpf.Name = "cnpj_cpf"
        Me.cnpj_cpf.ReadOnly = True
        Me.cnpj_cpf.Width = 300
        '
        'btn_confirmar
        '
        Me.btn_confirmar.Font = New System.Drawing.Font("Cooper Black", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_confirmar.Image = Global.MetroSys.My.Resources.Resources.accept001
        Me.btn_confirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_confirmar.Location = New System.Drawing.Point(136, 98)
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
        Me.lbl_pesquisa.Font = New System.Drawing.Font("Cooper Black", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pesquisa.Location = New System.Drawing.Point(133, 71)
        Me.lbl_pesquisa.Name = "lbl_pesquisa"
        Me.lbl_pesquisa.Size = New System.Drawing.Size(63, 14)
        Me.lbl_pesquisa.TabIndex = 16
        Me.lbl_pesquisa.Text = "CODIGO:"
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(202, 67)
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(79, 23)
        Me.txt_pesquisa.TabIndex = 17
        '
        'grp_opcoes
        '
        Me.grp_opcoes.Controls.Add(Me.rdb_nome)
        Me.grp_opcoes.Controls.Add(Me.rdb_codigo)
        Me.grp_opcoes.Controls.Add(Me.rdb_CodForn)
        Me.grp_opcoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_opcoes.Location = New System.Drawing.Point(11, 67)
        Me.grp_opcoes.Name = "grp_opcoes"
        Me.grp_opcoes.Size = New System.Drawing.Size(109, 91)
        Me.grp_opcoes.TabIndex = 15
        Me.grp_opcoes.TabStop = False
        Me.grp_opcoes.Text = "Opções"
        '
        'rdb_nome
        '
        Me.rdb_nome.AutoSize = True
        Me.rdb_nome.Location = New System.Drawing.Point(6, 43)
        Me.rdb_nome.Name = "rdb_nome"
        Me.rdb_nome.Size = New System.Drawing.Size(96, 19)
        Me.rdb_nome.TabIndex = 2
        Me.rdb_nome.Text = "NomeForn "
        Me.rdb_nome.UseVisualStyleBackColor = True
        '
        'rdb_codigo
        '
        Me.rdb_codigo.AutoSize = True
        Me.rdb_codigo.Checked = True
        Me.rdb_codigo.Location = New System.Drawing.Point(6, 20)
        Me.rdb_codigo.Name = "rdb_codigo"
        Me.rdb_codigo.Size = New System.Drawing.Size(94, 19)
        Me.rdb_codigo.TabIndex = 1
        Me.rdb_codigo.TabStop = True
        Me.rdb_codigo.Text = "Codigo      "
        Me.rdb_codigo.UseVisualStyleBackColor = True
        '
        'rdb_CodForn
        '
        Me.rdb_CodForn.AutoSize = True
        Me.rdb_CodForn.Location = New System.Drawing.Point(6, 64)
        Me.rdb_CodForn.Name = "rdb_CodForn"
        Me.rdb_CodForn.Size = New System.Drawing.Size(95, 19)
        Me.rdb_CodForn.TabIndex = 3
        Me.rdb_CodForn.Text = "CodForn    "
        Me.rdb_CodForn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(157, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 35)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Pesquisa de Produto"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Frm_BuscaProdComo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 344)
        Me.Controls.Add(Me.grb_registros)
        Me.Controls.Add(Me.Dg_produto)
        Me.Controls.Add(Me.btn_confirmar)
        Me.Controls.Add(Me.lbl_pesquisa)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.Controls.Add(Me.grp_opcoes)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_BuscaProdComo"
        Me.Opacity = 0.99
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comodatos"
        Me.grb_registros.ResumeLayout(False)
        Me.grb_registros.PerformLayout()
        CType(Me.Dg_produto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_opcoes.ResumeLayout(False)
        Me.grp_opcoes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grb_registros As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_registros As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Dg_produto As System.Windows.Forms.DataGridView
    Friend WithEvents btn_confirmar As System.Windows.Forms.Button
    Friend WithEvents lbl_pesquisa As System.Windows.Forms.Label
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents grp_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_nome As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_codigo As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_CodForn As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnpj_cpf As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
