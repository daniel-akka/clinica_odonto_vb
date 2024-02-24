<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Backup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Backup))
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btn_implocal = New System.Windows.Forms.Button()
        Me.txt_implocal = New System.Windows.Forms.TextBox()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.btn_importar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_implocal
        '
        Me.btn_implocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_implocal.Location = New System.Drawing.Point(483, 27)
        Me.btn_implocal.Name = "btn_implocal"
        Me.btn_implocal.Size = New System.Drawing.Size(33, 25)
        Me.btn_implocal.TabIndex = 5
        Me.btn_implocal.Text = ". . ."
        Me.btn_implocal.UseVisualStyleBackColor = True
        '
        'txt_implocal
        '
        Me.txt_implocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_implocal.Location = New System.Drawing.Point(118, 29)
        Me.txt_implocal.MaxLength = 90
        Me.txt_implocal.Name = "txt_implocal"
        Me.txt_implocal.Size = New System.Drawing.Size(361, 21)
        Me.txt_implocal.TabIndex = 4
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.Location = New System.Drawing.Point(11, 32)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(101, 15)
        Me.Label106.TabIndex = 3
        Me.Label106.Text = "Local do Backup:"
        '
        'btn_importar
        '
        Me.btn_importar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_importar.Image = CType(resources.GetObject("btn_importar.Image"), System.Drawing.Image)
        Me.btn_importar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_importar.Location = New System.Drawing.Point(525, 14)
        Me.btn_importar.Name = "btn_importar"
        Me.btn_importar.Size = New System.Drawing.Size(73, 66)
        Me.btn_importar.TabIndex = 6
        Me.btn_importar.Text = "&Backup"
        Me.btn_importar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_importar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_implocal)
        Me.GroupBox1.Controls.Add(Me.btn_importar)
        Me.GroupBox1.Controls.Add(Me.Label106)
        Me.GroupBox1.Controls.Add(Me.btn_implocal)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(607, 88)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Backup "
        '
        'Frm_Backup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 113)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Backup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cópia do Banco de Dados"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btn_implocal As System.Windows.Forms.Button
    Friend WithEvents txt_implocal As System.Windows.Forms.TextBox
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents btn_importar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
