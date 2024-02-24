<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MsgRTBox
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
        Me.rtb_mensagem = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'rtb_mensagem
        '
        Me.rtb_mensagem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtb_mensagem.ForeColor = System.Drawing.Color.Red
        Me.rtb_mensagem.Location = New System.Drawing.Point(0, 0)
        Me.rtb_mensagem.Name = "rtb_mensagem"
        Me.rtb_mensagem.ReadOnly = True
        Me.rtb_mensagem.Size = New System.Drawing.Size(604, 300)
        Me.rtb_mensagem.TabIndex = 0
        Me.rtb_mensagem.Text = ""
        '
        'Frm_MsgRTBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 300)
        Me.Controls.Add(Me.rtb_mensagem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MsgRTBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mensagem !"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents rtb_mensagem As System.Windows.Forms.RichTextBox
End Class
