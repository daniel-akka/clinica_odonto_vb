<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_importaProdutos
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_contagem = New System.Windows.Forms.Label
        Me.btn_iniciar = New System.Windows.Forms.Button
        Me.btn_sair = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Contagem de Registros: "
        '
        'lbl_contagem
        '
        Me.lbl_contagem.AutoSize = True
        Me.lbl_contagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_contagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_contagem.Location = New System.Drawing.Point(249, 108)
        Me.lbl_contagem.Name = "lbl_contagem"
        Me.lbl_contagem.Size = New System.Drawing.Size(17, 18)
        Me.lbl_contagem.TabIndex = 1
        Me.lbl_contagem.Text = "0"
        '
        'btn_iniciar
        '
        Me.btn_iniciar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_iniciar.Location = New System.Drawing.Point(18, 29)
        Me.btn_iniciar.Name = "btn_iniciar"
        Me.btn_iniciar.Size = New System.Drawing.Size(78, 37)
        Me.btn_iniciar.TabIndex = 2
        Me.btn_iniciar.Text = "&Iniciar"
        Me.btn_iniciar.UseVisualStyleBackColor = True
        '
        'btn_sair
        '
        Me.btn_sair.Location = New System.Drawing.Point(469, 239)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(75, 46)
        Me.btn_sair.TabIndex = 3
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Mensagem:"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(108, 256)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(0, 18)
        Me.lbl_mensagem.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_iniciar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbl_contagem)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(532, 187)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Importação:"
        '
        'Form_importaProdutos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 297)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_mensagem)
        Me.Controls.Add(Me.btn_sair)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Form_importaProdutos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importação de Produtos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_contagem As System.Windows.Forms.Label
    Friend WithEvents btn_iniciar As System.Windows.Forms.Button
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
