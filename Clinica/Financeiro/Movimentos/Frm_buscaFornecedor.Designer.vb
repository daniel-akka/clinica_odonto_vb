<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_buscaFornecedor
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.grp_opcoes = New System.Windows.Forms.GroupBox
        Me.rdb_nome = New System.Windows.Forms.RadioButton
        Me.rdb_codigo = New System.Windows.Forms.RadioButton
        Me.rdb_cnpj_cpf = New System.Windows.Forms.RadioButton
        Me.txt_pesquisa = New System.Windows.Forms.TextBox
        Me.lbl_pesquisa = New System.Windows.Forms.Label
        Me.btn_confirmar = New System.Windows.Forms.Button
        Me.Dg_particpante = New System.Windows.Forms.DataGridView
        Me.grb_registros = New System.Windows.Forms.GroupBox
        Me.lbl_registros = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cnpj_cpf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.inscricao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cidade = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.endereco = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fone = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grp_opcoes.SuspendLayout()
        CType(Me.Dg_particpante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grb_registros.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(158, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(294, 35)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pesquisa de Participante"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grp_opcoes
        '
        Me.grp_opcoes.Controls.Add(Me.rdb_nome)
        Me.grp_opcoes.Controls.Add(Me.rdb_codigo)
        Me.grp_opcoes.Controls.Add(Me.rdb_cnpj_cpf)
        Me.grp_opcoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_opcoes.Location = New System.Drawing.Point(12, 63)
        Me.grp_opcoes.Name = "grp_opcoes"
        Me.grp_opcoes.Size = New System.Drawing.Size(109, 91)
        Me.grp_opcoes.TabIndex = 1
        Me.grp_opcoes.TabStop = False
        Me.grp_opcoes.Text = "Opções"
        '
        'rdb_nome
        '
        Me.rdb_nome.AutoSize = True
        Me.rdb_nome.Location = New System.Drawing.Point(6, 43)
        Me.rdb_nome.Name = "rdb_nome"
        Me.rdb_nome.Size = New System.Drawing.Size(94, 19)
        Me.rdb_nome.TabIndex = 1
        Me.rdb_nome.TabStop = True
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
        Me.rdb_codigo.TabStop = True
        Me.rdb_codigo.Text = "CODIGO    "
        Me.rdb_codigo.UseVisualStyleBackColor = True
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
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(232, 63)
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(119, 23)
        Me.txt_pesquisa.TabIndex = 2
        '
        'lbl_pesquisa
        '
        Me.lbl_pesquisa.AutoSize = True
        Me.lbl_pesquisa.Font = New System.Drawing.Font("Cooper Black", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pesquisa.Location = New System.Drawing.Point(134, 67)
        Me.lbl_pesquisa.Name = "lbl_pesquisa"
        Me.lbl_pesquisa.Size = New System.Drawing.Size(92, 14)
        Me.lbl_pesquisa.TabIndex = 3
        Me.lbl_pesquisa.Text = "CNPJ ou CPF:"
        '
        'btn_confirmar
        '
        Me.btn_confirmar.Font = New System.Drawing.Font("Cooper Black", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_confirmar.Image = Global.MetroSys.My.Resources.Resources.accept001
        Me.btn_confirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_confirmar.Location = New System.Drawing.Point(137, 94)
        Me.btn_confirmar.Name = "btn_confirmar"
        Me.btn_confirmar.Size = New System.Drawing.Size(81, 60)
        Me.btn_confirmar.TabIndex = 4
        Me.btn_confirmar.Text = "&OK"
        Me.btn_confirmar.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btn_confirmar.UseVisualStyleBackColor = True
        '
        'Dg_particpante
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dg_particpante.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dg_particpante.BackgroundColor = System.Drawing.Color.DarkGray
        Me.Dg_particpante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dg_particpante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg_particpante.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.nome, Me.cnpj_cpf, Me.inscricao, Me.UF, Me.cidade, Me.endereco, Me.cep, Me.fone})
        Me.Dg_particpante.Location = New System.Drawing.Point(14, 164)
        Me.Dg_particpante.MultiSelect = False
        Me.Dg_particpante.Name = "Dg_particpante"
        Me.Dg_particpante.ReadOnly = True
        Me.Dg_particpante.Size = New System.Drawing.Size(605, 168)
        Me.Dg_particpante.TabIndex = 5
        '
        'grb_registros
        '
        Me.grb_registros.BackColor = System.Drawing.SystemColors.Control
        Me.grb_registros.Controls.Add(Me.lbl_registros)
        Me.grb_registros.Controls.Add(Me.Label2)
        Me.grb_registros.Location = New System.Drawing.Point(479, 122)
        Me.grb_registros.Name = "grb_registros"
        Me.grb_registros.Size = New System.Drawing.Size(140, 32)
        Me.grb_registros.TabIndex = 6
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
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.codigo.Width = 60
        '
        'nome
        '
        Me.nome.HeaderText = "Nome"
        Me.nome.Name = "nome"
        Me.nome.ReadOnly = True
        Me.nome.Width = 300
        '
        'cnpj_cpf
        '
        Me.cnpj_cpf.HeaderText = "Cnpj ou Cpf"
        Me.cnpj_cpf.Name = "cnpj_cpf"
        Me.cnpj_cpf.ReadOnly = True
        '
        'inscricao
        '
        Me.inscricao.HeaderText = "Inscricao"
        Me.inscricao.Name = "inscricao"
        Me.inscricao.ReadOnly = True
        '
        'UF
        '
        Me.UF.HeaderText = "UF"
        Me.UF.MinimumWidth = 2
        Me.UF.Name = "UF"
        Me.UF.ReadOnly = True
        Me.UF.Width = 25
        '
        'cidade
        '
        Me.cidade.HeaderText = "Cidade"
        Me.cidade.MaxInputLength = 40
        Me.cidade.Name = "cidade"
        Me.cidade.ReadOnly = True
        Me.cidade.Width = 150
        '
        'endereco
        '
        Me.endereco.HeaderText = "Endereco"
        Me.endereco.MaxInputLength = 60
        Me.endereco.Name = "endereco"
        Me.endereco.ReadOnly = True
        Me.endereco.Width = 250
        '
        'cep
        '
        Me.cep.HeaderText = "Cep"
        Me.cep.MaxInputLength = 15
        Me.cep.Name = "cep"
        Me.cep.ReadOnly = True
        '
        'fone
        '
        Me.fone.HeaderText = "Fone"
        Me.fone.MaxInputLength = 15
        Me.fone.Name = "fone"
        Me.fone.ReadOnly = True
        '
        'Frm_buscaFornecedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(628, 344)
        Me.Controls.Add(Me.grb_registros)
        Me.Controls.Add(Me.Dg_particpante)
        Me.Controls.Add(Me.btn_confirmar)
        Me.Controls.Add(Me.lbl_pesquisa)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.Controls.Add(Me.grp_opcoes)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_buscaFornecedor"
        Me.Opacity = 0.99
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pesquisa Participante"
        Me.grp_opcoes.ResumeLayout(False)
        Me.grp_opcoes.PerformLayout()
        CType(Me.Dg_particpante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grb_registros.ResumeLayout(False)
        Me.grb_registros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grp_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_codigo As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_cnpj_cpf As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_nome As System.Windows.Forms.RadioButton
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents lbl_pesquisa As System.Windows.Forms.Label
    Friend WithEvents btn_confirmar As System.Windows.Forms.Button
    Friend WithEvents Dg_particpante As System.Windows.Forms.DataGridView
    Friend WithEvents grb_registros As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_registros As System.Windows.Forms.Label
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnpj_cpf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents inscricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents endereco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fone As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
