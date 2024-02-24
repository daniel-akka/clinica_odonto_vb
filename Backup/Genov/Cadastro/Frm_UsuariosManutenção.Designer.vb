<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_UsuariosManutenção
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_nome = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_identificacao = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.msk_dtnascimento = New System.Windows.Forms.MaskedTextBox
        Me.msk_txtsenha = New System.Windows.Forms.MaskedTextBox
        Me.btn_gravar = New System.Windows.Forms.Button
        Me.txt_nivel = New System.Windows.Forms.TextBox
        Me.lbl_nivel = New System.Windows.Forms.Label
        Me.chk_bloqueado = New System.Windows.Forms.CheckBox
        Me.chk_administrador = New System.Windows.Forms.CheckBox
        Me.pct_foto = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbl_redigite = New System.Windows.Forms.Label
        Me.msk_redigite = New System.Windows.Forms.MaskedTextBox
        CType(Me.pct_foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome:"
        '
        'txt_nome
        '
        Me.txt_nome.Location = New System.Drawing.Point(109, 56)
        Me.txt_nome.MaxLength = 30
        Me.txt_nome.Name = "txt_nome"
        Me.txt_nome.Size = New System.Drawing.Size(173, 20)
        Me.txt_nome.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Identificação:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "DataNascimento:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(61, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Senha:"
        '
        'txt_identificacao
        '
        Me.txt_identificacao.Location = New System.Drawing.Point(109, 91)
        Me.txt_identificacao.MaxLength = 10
        Me.txt_identificacao.Name = "txt_identificacao"
        Me.txt_identificacao.Size = New System.Drawing.Size(100, 20)
        Me.txt_identificacao.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(106, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(190, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "* *  Registro de Usuarios  * *"
        '
        'msk_dtnascimento
        '
        Me.msk_dtnascimento.Location = New System.Drawing.Point(109, 125)
        Me.msk_dtnascimento.Mask = "99/99/9999"
        Me.msk_dtnascimento.Name = "msk_dtnascimento"
        Me.msk_dtnascimento.Size = New System.Drawing.Size(100, 20)
        Me.msk_dtnascimento.TabIndex = 3
        '
        'msk_txtsenha
        '
        Me.msk_txtsenha.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.msk_txtsenha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_txtsenha.Location = New System.Drawing.Point(107, 159)
        Me.msk_txtsenha.Name = "msk_txtsenha"
        Me.msk_txtsenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.msk_txtsenha.Size = New System.Drawing.Size(100, 21)
        Me.msk_txtsenha.TabIndex = 4
        '
        'btn_gravar
        '
        Me.btn_gravar.Location = New System.Drawing.Point(375, 291)
        Me.btn_gravar.Name = "btn_gravar"
        Me.btn_gravar.Size = New System.Drawing.Size(75, 29)
        Me.btn_gravar.TabIndex = 7
        Me.btn_gravar.Text = "&Gravar"
        Me.btn_gravar.UseVisualStyleBackColor = True
        '
        'txt_nivel
        '
        Me.txt_nivel.Location = New System.Drawing.Point(109, 224)
        Me.txt_nivel.MaxLength = 1
        Me.txt_nivel.Name = "txt_nivel"
        Me.txt_nivel.Size = New System.Drawing.Size(29, 20)
        Me.txt_nivel.TabIndex = 5
        '
        'lbl_nivel
        '
        Me.lbl_nivel.AutoSize = True
        Me.lbl_nivel.Location = New System.Drawing.Point(68, 231)
        Me.lbl_nivel.Name = "lbl_nivel"
        Me.lbl_nivel.Size = New System.Drawing.Size(34, 13)
        Me.lbl_nivel.TabIndex = 13
        Me.lbl_nivel.Text = "Nivel:"
        '
        'chk_bloqueado
        '
        Me.chk_bloqueado.AutoSize = True
        Me.chk_bloqueado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_bloqueado.Location = New System.Drawing.Point(47, 291)
        Me.chk_bloqueado.Name = "chk_bloqueado"
        Me.chk_bloqueado.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chk_bloqueado.Size = New System.Drawing.Size(77, 17)
        Me.chk_bloqueado.TabIndex = 7
        Me.chk_bloqueado.Text = "Bloqueado"
        Me.chk_bloqueado.UseVisualStyleBackColor = True
        '
        'chk_administrador
        '
        Me.chk_administrador.AutoSize = True
        Me.chk_administrador.Location = New System.Drawing.Point(35, 261)
        Me.chk_administrador.Name = "chk_administrador"
        Me.chk_administrador.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chk_administrador.Size = New System.Drawing.Size(89, 17)
        Me.chk_administrador.TabIndex = 6
        Me.chk_administrador.Text = "Administrador"
        Me.chk_administrador.UseVisualStyleBackColor = True
        '
        'pct_foto
        '
        Me.pct_foto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pct_foto.Location = New System.Drawing.Point(301, 94)
        Me.pct_foto.Name = "pct_foto"
        Me.pct_foto.Size = New System.Drawing.Size(149, 158)
        Me.pct_foto.TabIndex = 14
        Me.pct_foto.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(357, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Foto"
        '
        'lbl_redigite
        '
        Me.lbl_redigite.AutoSize = True
        Me.lbl_redigite.Location = New System.Drawing.Point(56, 193)
        Me.lbl_redigite.Name = "lbl_redigite"
        Me.lbl_redigite.Size = New System.Drawing.Size(49, 13)
        Me.lbl_redigite.TabIndex = 17
        Me.lbl_redigite.Text = "Redigite:"
        '
        'msk_redigite
        '
        Me.msk_redigite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_redigite.Location = New System.Drawing.Point(107, 190)
        Me.msk_redigite.Name = "msk_redigite"
        Me.msk_redigite.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.msk_redigite.Size = New System.Drawing.Size(100, 21)
        Me.msk_redigite.TabIndex = 18
        '
        'Frm_UsuariosManutenção
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 337)
        Me.Controls.Add(Me.msk_redigite)
        Me.Controls.Add(Me.lbl_redigite)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.pct_foto)
        Me.Controls.Add(Me.chk_administrador)
        Me.Controls.Add(Me.chk_bloqueado)
        Me.Controls.Add(Me.lbl_nivel)
        Me.Controls.Add(Me.txt_nivel)
        Me.Controls.Add(Me.btn_gravar)
        Me.Controls.Add(Me.msk_txtsenha)
        Me.Controls.Add(Me.msk_dtnascimento)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_identificacao)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_nome)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_UsuariosManutenção"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Usuários"
        CType(Me.pct_foto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_nivel As System.Windows.Forms.Label
    Public WithEvents txt_nome As System.Windows.Forms.TextBox
    Public WithEvents txt_identificacao As System.Windows.Forms.TextBox
    Public WithEvents msk_dtnascimento As System.Windows.Forms.MaskedTextBox
    Public WithEvents msk_txtsenha As System.Windows.Forms.MaskedTextBox
    Public WithEvents btn_gravar As System.Windows.Forms.Button
    Public WithEvents txt_nivel As System.Windows.Forms.TextBox
    Public WithEvents chk_bloqueado As System.Windows.Forms.CheckBox
    Public WithEvents chk_administrador As System.Windows.Forms.CheckBox
    Friend WithEvents pct_foto As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_redigite As System.Windows.Forms.Label
    Friend WithEvents msk_redigite As System.Windows.Forms.MaskedTextBox
End Class
