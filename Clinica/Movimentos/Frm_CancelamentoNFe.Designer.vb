<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CancelamentoNFe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CancelamentoNFe))
        Me.grp_cancelamento = New System.Windows.Forms.GroupBox
        Me.txt_protocoloNFe = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_chaveNFe = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grp_mensagem = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label26 = New System.Windows.Forms.Label
        Me.rtb_mensagem = New System.Windows.Forms.RichTextBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.grp_cancelamento.SuspendLayout()
        Me.grp_mensagem.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp_cancelamento
        '
        Me.grp_cancelamento.Controls.Add(Me.btn_cancelar)
        Me.grp_cancelamento.Controls.Add(Me.txt_protocoloNFe)
        Me.grp_cancelamento.Controls.Add(Me.Label2)
        Me.grp_cancelamento.Controls.Add(Me.txt_chaveNFe)
        Me.grp_cancelamento.Controls.Add(Me.Label1)
        Me.grp_cancelamento.Location = New System.Drawing.Point(3, 64)
        Me.grp_cancelamento.Name = "grp_cancelamento"
        Me.grp_cancelamento.Size = New System.Drawing.Size(501, 96)
        Me.grp_cancelamento.TabIndex = 0
        Me.grp_cancelamento.TabStop = False
        '
        'txt_protocoloNFe
        '
        Me.txt_protocoloNFe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_protocoloNFe.Location = New System.Drawing.Point(97, 54)
        Me.txt_protocoloNFe.MaxLength = 15
        Me.txt_protocoloNFe.Name = "txt_protocoloNFe"
        Me.txt_protocoloNFe.Size = New System.Drawing.Size(201, 21)
        Me.txt_protocoloNFe.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Protocolo:"
        '
        'txt_chaveNFe
        '
        Me.txt_chaveNFe.BackColor = System.Drawing.SystemColors.Info
        Me.txt_chaveNFe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_chaveNFe.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txt_chaveNFe.Location = New System.Drawing.Point(97, 19)
        Me.txt_chaveNFe.MaxLength = 45
        Me.txt_chaveNFe.Name = "txt_chaveNFe"
        Me.txt_chaveNFe.ReadOnly = True
        Me.txt_chaveNFe.Size = New System.Drawing.Size(394, 21)
        Me.txt_chaveNFe.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Chave NFe:"
        '
        'grp_mensagem
        '
        Me.grp_mensagem.Controls.Add(Me.lbl_mensagem)
        Me.grp_mensagem.Location = New System.Drawing.Point(3, 255)
        Me.grp_mensagem.Name = "grp_mensagem"
        Me.grp_mensagem.Size = New System.Drawing.Size(501, 45)
        Me.grp_mensagem.TabIndex = 0
        Me.grp_mensagem.TabStop = False
        Me.grp_mensagem.Text = "Mensagem:"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(9, 17)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(78, 17)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = "              "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-4, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(520, 66)
        Me.Panel1.TabIndex = 13
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(422, 37)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(84, 20)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'rtb_mensagem
        '
        Me.rtb_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtb_mensagem.ForeColor = System.Drawing.Color.Red
        Me.rtb_mensagem.Location = New System.Drawing.Point(3, 166)
        Me.rtb_mensagem.Name = "rtb_mensagem"
        Me.rtb_mensagem.Size = New System.Drawing.Size(501, 86)
        Me.rtb_mensagem.TabIndex = 14
        Me.rtb_mensagem.Text = ""
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.RTecSys.My.Resources.Resources.metrosys2
        Me.PictureBox2.Location = New System.Drawing.Point(416, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(90, 31)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(160, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(176, 52)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.RTecSys.My.Resources.Resources.ok_16x16
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancelar.Location = New System.Drawing.Point(396, 47)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 37)
        Me.btn_cancelar.TabIndex = 3
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'Frm_CancelamentoNFe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 306)
        Me.Controls.Add(Me.rtb_mensagem)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grp_mensagem)
        Me.Controls.Add(Me.grp_cancelamento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_CancelamentoNFe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "** Cancelamento **"
        Me.grp_cancelamento.ResumeLayout(False)
        Me.grp_cancelamento.PerformLayout()
        Me.grp_mensagem.ResumeLayout(False)
        Me.grp_mensagem.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp_cancelamento As System.Windows.Forms.GroupBox
    Friend WithEvents grp_mensagem As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Public WithEvents txt_chaveNFe As System.Windows.Forms.TextBox
    Public WithEvents txt_protocoloNFe As System.Windows.Forms.TextBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents rtb_mensagem As System.Windows.Forms.RichTextBox
End Class
