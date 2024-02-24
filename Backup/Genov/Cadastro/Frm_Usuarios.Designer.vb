<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Usuarios
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
        Me.btn_acesso = New System.Windows.Forms.Button
        Me.btn_usuario = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn_acesso
        '
        Me.btn_acesso.Image = Global.Genov.My.Resources.Resources.usuario_Adm_16x16
        Me.btn_acesso.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_acesso.Location = New System.Drawing.Point(131, 119)
        Me.btn_acesso.Name = "btn_acesso"
        Me.btn_acesso.Size = New System.Drawing.Size(132, 43)
        Me.btn_acesso.TabIndex = 1
        Me.btn_acesso.Text = "&Acessos"
        Me.btn_acesso.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_acesso.UseVisualStyleBackColor = True
        '
        'btn_usuario
        '
        Me.btn_usuario.Image = Global.Genov.My.Resources.Resources.user2__add__16x16
        Me.btn_usuario.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_usuario.Location = New System.Drawing.Point(131, 49)
        Me.btn_usuario.Name = "btn_usuario"
        Me.btn_usuario.Size = New System.Drawing.Size(132, 44)
        Me.btn_usuario.TabIndex = 0
        Me.btn_usuario.Text = "&Usuários"
        Me.btn_usuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_usuario.UseVisualStyleBackColor = True
        '
        'Frm_Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 234)
        Me.Controls.Add(Me.btn_acesso)
        Me.Controls.Add(Me.btn_usuario)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Controle de Usuários"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents btn_usuario As System.Windows.Forms.Button
    Public WithEvents btn_acesso As System.Windows.Forms.Button
End Class
