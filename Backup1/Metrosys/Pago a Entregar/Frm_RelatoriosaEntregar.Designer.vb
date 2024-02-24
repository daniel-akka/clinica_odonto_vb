<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RelatoriosaEntregar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RelatoriosaEntregar))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_requisicao = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.msk_periodo2 = New System.Windows.Forms.MaskedTextBox
        Me.msk_periodo1 = New System.Windows.Forms.MaskedTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.txt_codPart = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_relatorios = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_relatorios)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(474, 312)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txt_requisicao)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.msk_periodo2)
        Me.GroupBox2.Controls.Add(Me.msk_periodo1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txt_nomePart)
        Me.GroupBox2.Controls.Add(Me.txt_codPart)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 115)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(437, 179)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(157, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "A"
        '
        'txt_requisicao
        '
        Me.txt_requisicao.Location = New System.Drawing.Point(68, 107)
        Me.txt_requisicao.MaxLength = 8
        Me.txt_requisicao.Name = "txt_requisicao"
        Me.txt_requisicao.Size = New System.Drawing.Size(100, 20)
        Me.txt_requisicao.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Reguisição:"
        '
        'msk_periodo2
        '
        Me.msk_periodo2.Location = New System.Drawing.Point(178, 69)
        Me.msk_periodo2.Mask = "00/00/0000"
        Me.msk_periodo2.Name = "msk_periodo2"
        Me.msk_periodo2.Size = New System.Drawing.Size(78, 20)
        Me.msk_periodo2.TabIndex = 6
        Me.msk_periodo2.ValidatingType = GetType(Date)
        '
        'msk_periodo1
        '
        Me.msk_periodo1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.msk_periodo1.Location = New System.Drawing.Point(68, 69)
        Me.msk_periodo1.Mask = "00/00/0000"
        Me.msk_periodo1.Name = "msk_periodo1"
        Me.msk_periodo1.Size = New System.Drawing.Size(83, 20)
        Me.msk_periodo1.TabIndex = 5
        Me.msk_periodo1.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Periodo:"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.Location = New System.Drawing.Point(127, 27)
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(304, 20)
        Me.txt_nomePart.TabIndex = 4
        '
        'txt_codPart
        '
        Me.txt_codPart.Location = New System.Drawing.Point(68, 27)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(53, 20)
        Me.txt_codPart.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cliente:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(30, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Selecione Relatório Diversos"
        '
        'cbo_relatorios
        '
        Me.cbo_relatorios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_relatorios.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_relatorios.FormattingEnabled = True
        Me.cbo_relatorios.Items.AddRange(New Object() {"Relatorio Diario", "Baixas Diarias", "Posição Geral", "Posição Clientes", "", "", "", "", ""})
        Me.cbo_relatorios.Location = New System.Drawing.Point(53, 67)
        Me.cbo_relatorios.Name = "cbo_relatorios"
        Me.cbo_relatorios.Size = New System.Drawing.Size(202, 24)
        Me.cbo_relatorios.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(396, 383)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 45)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "&Imprimir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 383)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(378, 42)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Location = New System.Drawing.Point(16, 21)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(19, 13)
        Me.lbl_mensagem.TabIndex = 9
        Me.lbl_mensagem.Text = "    "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkCyan
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(502, 71)
        Me.Panel1.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Wide Latin", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(369, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(131, 18)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "MetroSys"
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(160, 6)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(156, 57)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Frm_RelatoriosaEntregar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 449)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_RelatoriosaEntregar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatorios do Pago a Entregar"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_relatorios As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents txt_codPart As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_requisicao As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents msk_periodo2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents msk_periodo1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
