<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ProcessaMov
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ProcessaMov))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_iniciar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtp_final = New System.Windows.Forms.DateTimePicker
        Me.dtp_inicial = New System.Windows.Forms.DateTimePicker
        Me.pgb_movimento = New System.Windows.Forms.ProgressBar
        Me.lbl_totreg = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Periodo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(164, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "A"
        '
        'btn_iniciar
        '
        Me.btn_iniciar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_iniciar.Location = New System.Drawing.Point(285, 211)
        Me.btn_iniciar.Name = "btn_iniciar"
        Me.btn_iniciar.Size = New System.Drawing.Size(83, 35)
        Me.btn_iniciar.TabIndex = 3
        Me.btn_iniciar.Text = "&Iniciar"
        Me.btn_iniciar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtp_final)
        Me.GroupBox1.Controls.Add(Me.dtp_inicial)
        Me.GroupBox1.Controls.Add(Me.pgb_movimento)
        Me.GroupBox1.Controls.Add(Me.lbl_totreg)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(356, 132)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dtp_final
        '
        Me.dtp_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_final.Location = New System.Drawing.Point(190, 25)
        Me.dtp_final.MaxDate = New Date(3000, 12, 31, 0, 0, 0, 0)
        Me.dtp_final.MinDate = New Date(1953, 1, 1, 0, 0, 0, 0)
        Me.dtp_final.Name = "dtp_final"
        Me.dtp_final.Size = New System.Drawing.Size(93, 21)
        Me.dtp_final.TabIndex = 1
        '
        'dtp_inicial
        '
        Me.dtp_inicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_inicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_inicial.Location = New System.Drawing.Point(61, 25)
        Me.dtp_inicial.MaxDate = New Date(3000, 12, 31, 0, 0, 0, 0)
        Me.dtp_inicial.MinDate = New Date(1953, 1, 1, 0, 0, 0, 0)
        Me.dtp_inicial.Name = "dtp_inicial"
        Me.dtp_inicial.Size = New System.Drawing.Size(93, 21)
        Me.dtp_inicial.TabIndex = 1
        '
        'pgb_movimento
        '
        Me.pgb_movimento.Location = New System.Drawing.Point(14, 95)
        Me.pgb_movimento.Name = "pgb_movimento"
        Me.pgb_movimento.Size = New System.Drawing.Size(326, 24)
        Me.pgb_movimento.TabIndex = 47
        '
        'lbl_totreg
        '
        Me.lbl_totreg.AutoSize = True
        Me.lbl_totreg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_totreg.ForeColor = System.Drawing.Color.Red
        Me.lbl_totreg.Location = New System.Drawing.Point(68, 62)
        Me.lbl_totreg.Name = "lbl_totreg"
        Me.lbl_totreg.Size = New System.Drawing.Size(19, 15)
        Me.lbl_totreg.TabIndex = 46
        Me.lbl_totreg.Text = "   "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Registros:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Wide Latin", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(274, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 15)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(107, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(145, 48)
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
        Me.Panel1.Size = New System.Drawing.Size(382, 66)
        Me.Panel1.TabIndex = 44
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 210)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(267, 35)
        Me.GroupBox2.TabIndex = 45
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(16, 16)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(16, 15)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = "   "
        '
        'Frm_ProcessaMov
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 257)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_iniciar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ProcessaMov"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Processa Movimento"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_iniciar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_totreg As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents pgb_movimento As System.Windows.Forms.ProgressBar
    Friend WithEvents dtp_inicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_final As System.Windows.Forms.DateTimePicker
End Class
