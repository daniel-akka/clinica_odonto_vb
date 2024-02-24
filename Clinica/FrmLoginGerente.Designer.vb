<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class FrmLoginGerente
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_confirmar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_senhaUsuario = New System.Windows.Forms.TextBox
        Me.txt_loginUsuario = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.RTecSys.My.Resources.Resources.yast_sysadmin
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(7, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(136, 168)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Location = New System.Drawing.Point(245, 144)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 28)
        Me.btn_cancelar.TabIndex = 20
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_confirmar
        '
        Me.btn_confirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_confirmar.Location = New System.Drawing.Point(154, 144)
        Me.btn_confirmar.Name = "btn_confirmar"
        Me.btn_confirmar.Size = New System.Drawing.Size(84, 28)
        Me.btn_confirmar.TabIndex = 19
        Me.btn_confirmar.Text = "&Confirmar"
        Me.btn_confirmar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(151, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Senha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Palatino Linotype", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(149, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 28)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Gerente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(151, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Login"
        '
        'txt_senhaUsuario
        '
        Me.txt_senhaUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_senhaUsuario.Location = New System.Drawing.Point(154, 108)
        Me.txt_senhaUsuario.MaxLength = 15
        Me.txt_senhaUsuario.Name = "txt_senhaUsuario"
        Me.txt_senhaUsuario.Size = New System.Drawing.Size(166, 22)
        Me.txt_senhaUsuario.TabIndex = 18
        Me.txt_senhaUsuario.UseSystemPasswordChar = True
        '
        'txt_loginUsuario
        '
        Me.txt_loginUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_loginUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_loginUsuario.Location = New System.Drawing.Point(154, 61)
        Me.txt_loginUsuario.MaxLength = 15
        Me.txt_loginUsuario.Name = "txt_loginUsuario"
        Me.txt_loginUsuario.Size = New System.Drawing.Size(166, 22)
        Me.txt_loginUsuario.TabIndex = 14
        '
        'FrmLoginGerente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 176)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_confirmar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_senhaUsuario)
        Me.Controls.Add(Me.txt_loginUsuario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLoginGerente"
        Me.Opacity = 0.99
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login Gerente"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_confirmar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_senhaUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txt_loginUsuario As System.Windows.Forms.TextBox

End Class
