<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManifestoCarga
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManifestoCarga))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.grp_manifesto = New System.Windows.Forms.GroupBox
        Me.txt_numMapa = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_roteiro = New System.Windows.Forms.TextBox
        Me.grb_buttons = New System.Windows.Forms.GroupBox
        Me.btn_NFe = New System.Windows.Forms.Button
        Me.btn_boletos = New System.Windows.Forms.Button
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.pdRelatManifCarga = New System.Drawing.Printing.PrintDocument
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.grp_manifesto.SuspendLayout()
        Me.grb_buttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(161, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(161, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 63)
        Me.Panel1.TabIndex = 43
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Wide Latin", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(366, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(131, 18)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'grp_manifesto
        '
        Me.grp_manifesto.Controls.Add(Me.txt_numMapa)
        Me.grp_manifesto.Controls.Add(Me.Label1)
        Me.grp_manifesto.Controls.Add(Me.txt_roteiro)
        Me.grp_manifesto.Controls.Add(Me.grb_buttons)
        Me.grp_manifesto.Controls.Add(Me.Label2)
        Me.grp_manifesto.Location = New System.Drawing.Point(4, 65)
        Me.grp_manifesto.Name = "grp_manifesto"
        Me.grp_manifesto.Size = New System.Drawing.Size(486, 162)
        Me.grp_manifesto.TabIndex = 0
        Me.grp_manifesto.TabStop = False
        '
        'txt_numMapa
        '
        Me.txt_numMapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_numMapa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numMapa.Location = New System.Drawing.Point(84, 19)
        Me.txt_numMapa.MaxLength = 8
        Me.txt_numMapa.Name = "txt_numMapa"
        Me.txt_numMapa.Size = New System.Drawing.Size(100, 22)
        Me.txt_numMapa.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Mapa:"
        '
        'txt_roteiro
        '
        Me.txt_roteiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_roteiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_roteiro.Location = New System.Drawing.Point(84, 50)
        Me.txt_roteiro.MaxLength = 60
        Me.txt_roteiro.Name = "txt_roteiro"
        Me.txt_roteiro.Size = New System.Drawing.Size(389, 22)
        Me.txt_roteiro.TabIndex = 2
        '
        'grb_buttons
        '
        Me.grb_buttons.Controls.Add(Me.btn_NFe)
        Me.grb_buttons.Controls.Add(Me.btn_boletos)
        Me.grb_buttons.Controls.Add(Me.btn_imprimir)
        Me.grb_buttons.Location = New System.Drawing.Point(18, 84)
        Me.grb_buttons.Name = "grb_buttons"
        Me.grb_buttons.Size = New System.Drawing.Size(455, 70)
        Me.grb_buttons.TabIndex = 4
        Me.grb_buttons.TabStop = False
        Me.grb_buttons.Text = "Impressão:"
        '
        'btn_NFe
        '
        Me.btn_NFe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_NFe.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_NFe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_NFe.Location = New System.Drawing.Point(181, 16)
        Me.btn_NFe.Name = "btn_NFe"
        Me.btn_NFe.Size = New System.Drawing.Size(99, 48)
        Me.btn_NFe.TabIndex = 3
        Me.btn_NFe.Text = "&NF-e"
        Me.btn_NFe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_NFe.UseVisualStyleBackColor = True
        '
        'btn_boletos
        '
        Me.btn_boletos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_boletos.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_boletos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_boletos.Location = New System.Drawing.Point(304, 16)
        Me.btn_boletos.Name = "btn_boletos"
        Me.btn_boletos.Size = New System.Drawing.Size(99, 48)
        Me.btn_boletos.TabIndex = 3
        Me.btn_boletos.Text = "&Boletos"
        Me.btn_boletos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_boletos.UseVisualStyleBackColor = True
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.Location = New System.Drawing.Point(50, 16)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(99, 48)
        Me.btn_imprimir.TabIndex = 3
        Me.btn_imprimir.Text = "&Financeiro"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "&Roteiro:"
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
        'pdRelatManifCarga
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Frm_ManifestoCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 235)
        Me.Controls.Add(Me.grp_manifesto)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ManifestoCarga"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manifesto de Carga"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grp_manifesto.ResumeLayout(False)
        Me.grp_manifesto.PerformLayout()
        Me.grb_buttons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grp_manifesto As System.Windows.Forms.GroupBox
    Friend WithEvents txt_numMapa As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdRelatManifCarga As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents txt_roteiro As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grb_buttons As System.Windows.Forms.GroupBox
    Friend WithEvents btn_NFe As System.Windows.Forms.Button
    Friend WithEvents btn_boletos As System.Windows.Forms.Button
End Class
