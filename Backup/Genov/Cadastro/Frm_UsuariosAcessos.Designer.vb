<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_UsuariosAcessos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtg_lbAcesso = New System.Windows.Forms.DataGridView
        Me.btn_sair = New System.Windows.Forms.Button
        Me.lbl_usuario = New System.Windows.Forms.Label
        Me.txt_pesquisa = New System.Windows.Forms.TextBox
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        CType(Me.dtg_lbAcesso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_lbAcesso
        '
        Me.dtg_lbAcesso.AllowUserToAddRows = False
        Me.dtg_lbAcesso.AllowUserToDeleteRows = False
        Me.dtg_lbAcesso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_lbAcesso.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column2, Me.Column1})
        Me.dtg_lbAcesso.Location = New System.Drawing.Point(29, 39)
        Me.dtg_lbAcesso.Name = "dtg_lbAcesso"
        Me.dtg_lbAcesso.ReadOnly = True
        Me.dtg_lbAcesso.Size = New System.Drawing.Size(545, 346)
        Me.dtg_lbAcesso.TabIndex = 2
        '
        'btn_sair
        '
        Me.btn_sair.Image = Global.Genov.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sair.Location = New System.Drawing.Point(513, 391)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(61, 30)
        Me.btn_sair.TabIndex = 3
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'lbl_usuario
        '
        Me.lbl_usuario.AutoSize = True
        Me.lbl_usuario.Location = New System.Drawing.Point(26, 13)
        Me.lbl_usuario.Name = "lbl_usuario"
        Me.lbl_usuario.Size = New System.Drawing.Size(53, 13)
        Me.lbl_usuario.TabIndex = 3
        Me.lbl_usuario.Text = "Pesquisa:"
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.Location = New System.Drawing.Point(85, 10)
        Me.txt_pesquisa.MaxLength = 15
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(149, 20)
        Me.txt_pesquisa.TabIndex = 1
        '
        'Column3
        '
        Me.Column3.HeaderText = "Rotina"
        Me.Column3.MaxInputLength = 15
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descrição"
        Me.Column2.MaxInputLength = 30
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Status"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Frm_UsuariosAcessos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 428)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.Controls.Add(Me.lbl_usuario)
        Me.Controls.Add(Me.btn_sair)
        Me.Controls.Add(Me.dtg_lbAcesso)
        Me.KeyPreview = True
        Me.Name = "Frm_UsuariosAcessos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liberação de Acessos"
        CType(Me.dtg_lbAcesso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_lbAcesso As System.Windows.Forms.DataGridView
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents lbl_usuario As System.Windows.Forms.Label
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
