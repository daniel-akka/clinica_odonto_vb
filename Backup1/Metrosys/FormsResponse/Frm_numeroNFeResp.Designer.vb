<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_numeroNFeResp
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
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.grp_box1 = New System.Windows.Forms.GroupBox
        Me.btn_ok = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.grp_box1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_numero
        '
        Me.txt_numero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero.Location = New System.Drawing.Point(72, 20)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(110, 21)
        Me.txt_numero.TabIndex = 2
        '
        'grp_box1
        '
        Me.grp_box1.Controls.Add(Me.txt_numero)
        Me.grp_box1.Controls.Add(Me.btn_ok)
        Me.grp_box1.Controls.Add(Me.Label1)
        Me.grp_box1.Location = New System.Drawing.Point(9, 9)
        Me.grp_box1.Name = "grp_box1"
        Me.grp_box1.Size = New System.Drawing.Size(279, 57)
        Me.grp_box1.TabIndex = 3
        Me.grp_box1.TabStop = False
        '
        'btn_ok
        '
        Me.btn_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok.Image = Global.MetroSys.My.Resources.Resources.ok_16x16
        Me.btn_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ok.Location = New System.Drawing.Point(206, 16)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(60, 32)
        Me.btn_ok.TabIndex = 3
        Me.btn_ok.Text = "&OK"
        Me.btn_ok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Numero:"
        '
        'Frm_numeroNFeResp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 75)
        Me.Controls.Add(Me.grp_box1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_numeroNFeResp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Numero NFe"
        Me.grp_box1.ResumeLayout(False)
        Me.grp_box1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents grp_box1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
