<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MenuMovRelatorios
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_relMovAtendimento = New System.Windows.Forms.Button()
        Me.btn_relTpAtendimento = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-2, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(390, 42)
        Me.Panel1.TabIndex = 29
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(121, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btn_relMovAtendimento)
        Me.GroupBox1.Controls.Add(Me.btn_relTpAtendimento)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(347, 90)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'btn_relMovAtendimento
        '
        Me.btn_relMovAtendimento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_relMovAtendimento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_relMovAtendimento.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_relMovAtendimento.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_relMovAtendimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_relMovAtendimento.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btn_relMovAtendimento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_relMovAtendimento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_relMovAtendimento.Location = New System.Drawing.Point(187, 19)
        Me.btn_relMovAtendimento.Name = "btn_relMovAtendimento"
        Me.btn_relMovAtendimento.Size = New System.Drawing.Size(140, 59)
        Me.btn_relMovAtendimento.TabIndex = 1
        Me.btn_relMovAtendimento.Text = "&Movimento de Atendimento"
        Me.btn_relMovAtendimento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_relMovAtendimento.UseVisualStyleBackColor = False
        '
        'btn_relTpAtendimento
        '
        Me.btn_relTpAtendimento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_relTpAtendimento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_relTpAtendimento.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_relTpAtendimento.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_relTpAtendimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_relTpAtendimento.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btn_relTpAtendimento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_relTpAtendimento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_relTpAtendimento.Location = New System.Drawing.Point(19, 19)
        Me.btn_relTpAtendimento.Name = "btn_relTpAtendimento"
        Me.btn_relTpAtendimento.Size = New System.Drawing.Size(140, 59)
        Me.btn_relTpAtendimento.TabIndex = 1
        Me.btn_relTpAtendimento.Text = "&Tipo de Atendimento"
        Me.btn_relTpAtendimento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_relTpAtendimento.UseVisualStyleBackColor = False
        '
        'Frm_MenuMovRelatorios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 147)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Frm_MenuMovRelatorios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Relátorio de Movimentos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_relMovAtendimento As System.Windows.Forms.Button
    Friend WithEvents btn_relTpAtendimento As System.Windows.Forms.Button
End Class
