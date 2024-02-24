<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Relatorio_001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Relatorio_001))
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.btn_open = New System.Windows.Forms.Button
        Me.btn_print = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_gerar = New System.Windows.Forms.Button
        Me.btn_imprime = New System.Windows.Forms.Button
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_pagesetup = New System.Windows.Forms.Button
        Me.btn_prtpreview = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrintDocument1
        '
        '
        'btn_open
        '
        Me.btn_open.Location = New System.Drawing.Point(6, 11)
        Me.btn_open.Name = "btn_open"
        Me.btn_open.Size = New System.Drawing.Size(75, 23)
        Me.btn_open.TabIndex = 0
        Me.btn_open.Text = "&Open"
        Me.btn_open.UseVisualStyleBackColor = True
        '
        'btn_print
        '
        Me.btn_print.Location = New System.Drawing.Point(6, 38)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(75, 23)
        Me.btn_print.TabIndex = 1
        Me.btn_print.Text = "&Print"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-4, -3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(514, 76)
        Me.Panel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("Wide Latin", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(381, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Genov"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(149, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(156, 58)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_open)
        Me.GroupBox1.Controls.Add(Me.btn_print)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(88, 65)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(7, 145)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(489, 321)
        Me.RichTextBox1.TabIndex = 4
        Me.RichTextBox1.Text = ""
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_gerar)
        Me.GroupBox2.Controls.Add(Me.btn_imprime)
        Me.GroupBox2.Location = New System.Drawing.Point(407, 74)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(88, 65)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'btn_gerar
        '
        Me.btn_gerar.Location = New System.Drawing.Point(6, 11)
        Me.btn_gerar.Name = "btn_gerar"
        Me.btn_gerar.Size = New System.Drawing.Size(75, 23)
        Me.btn_gerar.TabIndex = 0
        Me.btn_gerar.Text = "&Gerar"
        Me.btn_gerar.UseVisualStyleBackColor = True
        '
        'btn_imprime
        '
        Me.btn_imprime.Location = New System.Drawing.Point(6, 38)
        Me.btn_imprime.Name = "btn_imprime"
        Me.btn_imprime.Size = New System.Drawing.Size(75, 23)
        Me.btn_imprime.TabIndex = 1
        Me.btn_imprime.Text = "&Imprime"
        Me.btn_imprime.UseVisualStyleBackColor = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_pagesetup)
        Me.GroupBox3.Controls.Add(Me.btn_prtpreview)
        Me.GroupBox3.Location = New System.Drawing.Point(213, 77)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(105, 65)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'btn_pagesetup
        '
        Me.btn_pagesetup.Location = New System.Drawing.Point(6, 11)
        Me.btn_pagesetup.Name = "btn_pagesetup"
        Me.btn_pagesetup.Size = New System.Drawing.Size(93, 23)
        Me.btn_pagesetup.TabIndex = 0
        Me.btn_pagesetup.Text = "P&age Setup"
        Me.btn_pagesetup.UseVisualStyleBackColor = True
        '
        'btn_prtpreview
        '
        Me.btn_prtpreview.Location = New System.Drawing.Point(6, 38)
        Me.btn_prtpreview.Name = "btn_prtpreview"
        Me.btn_prtpreview.Size = New System.Drawing.Size(93, 23)
        Me.btn_prtpreview.TabIndex = 1
        Me.btn_prtpreview.Text = "P&rint Preview"
        Me.btn_prtpreview.UseVisualStyleBackColor = True
        '
        'Frm_Relatorio_001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 478)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_Relatorio_001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatorio de Estoque"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents btn_open As System.Windows.Forms.Button
    Friend WithEvents btn_print As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_gerar As System.Windows.Forms.Button
    Friend WithEvents btn_imprime As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_pagesetup As System.Windows.Forms.Button
    Friend WithEvents btn_prtpreview As System.Windows.Forms.Button
End Class
