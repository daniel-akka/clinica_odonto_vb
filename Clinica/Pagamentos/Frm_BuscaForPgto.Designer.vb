<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BuscaForPgto
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Rdb_Fornecedor = New System.Windows.Forms.RadioButton
        Me.Rdb_Codigo = New System.Windows.Forms.RadioButton
        Me.DtGdVw_manfornecedores = New System.Windows.Forms.DataGridView
        Me.Txt_pesquisa = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Btn_pesquisa = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.DtGdVw_manfornecedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rdb_Fornecedor)
        Me.GroupBox1.Controls.Add(Me.Rdb_Codigo)
        Me.GroupBox1.Location = New System.Drawing.Point(426, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(149, 36)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opção:"
        '
        'Rdb_Fornecedor
        '
        Me.Rdb_Fornecedor.AutoSize = True
        Me.Rdb_Fornecedor.Location = New System.Drawing.Point(66, 14)
        Me.Rdb_Fornecedor.Name = "Rdb_Fornecedor"
        Me.Rdb_Fornecedor.Size = New System.Drawing.Size(79, 17)
        Me.Rdb_Fornecedor.TabIndex = 1
        Me.Rdb_Fornecedor.TabStop = True
        Me.Rdb_Fornecedor.Text = "Fornecedor"
        Me.Rdb_Fornecedor.UseVisualStyleBackColor = True
        '
        'Rdb_Codigo
        '
        Me.Rdb_Codigo.AutoSize = True
        Me.Rdb_Codigo.Location = New System.Drawing.Point(6, 14)
        Me.Rdb_Codigo.Name = "Rdb_Codigo"
        Me.Rdb_Codigo.Size = New System.Drawing.Size(58, 17)
        Me.Rdb_Codigo.TabIndex = 0
        Me.Rdb_Codigo.TabStop = True
        Me.Rdb_Codigo.Text = "Codigo"
        Me.Rdb_Codigo.UseVisualStyleBackColor = True
        '
        'DtGdVw_manfornecedores
        '
        Me.DtGdVw_manfornecedores.AllowUserToAddRows = False
        Me.DtGdVw_manfornecedores.AllowUserToDeleteRows = False
        Me.DtGdVw_manfornecedores.AllowUserToResizeColumns = False
        Me.DtGdVw_manfornecedores.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DtGdVw_manfornecedores.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DtGdVw_manfornecedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DtGdVw_manfornecedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtGdVw_manfornecedores.Location = New System.Drawing.Point(27, 63)
        Me.DtGdVw_manfornecedores.Name = "DtGdVw_manfornecedores"
        Me.DtGdVw_manfornecedores.ReadOnly = True
        Me.DtGdVw_manfornecedores.Size = New System.Drawing.Size(594, 284)
        Me.DtGdVw_manfornecedores.TabIndex = 14
        '
        'Txt_pesquisa
        '
        Me.Txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_pesquisa.Location = New System.Drawing.Point(86, 32)
        Me.Txt_pesquisa.Name = "Txt_pesquisa"
        Me.Txt_pesquisa.Size = New System.Drawing.Size(334, 22)
        Me.Txt_pesquisa.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "&Pesquisa:"
        '
        'Btn_pesquisa
        '
        Me.Btn_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_pesquisa.Image = Global.MetroSys.My.Resources.Resources.Busca_16x16
        Me.Btn_pesquisa.Location = New System.Drawing.Point(581, 26)
        Me.Btn_pesquisa.Name = "Btn_pesquisa"
        Me.Btn_pesquisa.Size = New System.Drawing.Size(40, 33)
        Me.Btn_pesquisa.TabIndex = 13
        Me.Btn_pesquisa.Text = "..."
        Me.Btn_pesquisa.UseVisualStyleBackColor = True
        '
        'Frm_BuscaForPgto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 370)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DtGdVw_manfornecedores)
        Me.Controls.Add(Me.Btn_pesquisa)
        Me.Controls.Add(Me.Txt_pesquisa)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_BuscaForPgto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busca Fornecedores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DtGdVw_manfornecedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdb_Fornecedor As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_Codigo As System.Windows.Forms.RadioButton
    Friend WithEvents DtGdVw_manfornecedores As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_pesquisa As System.Windows.Forms.Button
    Friend WithEvents Txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
