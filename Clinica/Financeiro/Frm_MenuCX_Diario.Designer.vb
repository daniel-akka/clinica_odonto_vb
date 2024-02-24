<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MenuCX_Diario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MenuCX_Diario))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_relatorios = New System.Windows.Forms.Button()
        Me.btn_manutencao = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-5, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(306, 37)
        Me.Panel1.TabIndex = 29
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 21.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(104, 0)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(78, 32)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btn_relatorios)
        Me.Panel2.Controls.Add(Me.btn_manutencao)
        Me.Panel2.Location = New System.Drawing.Point(9, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(277, 121)
        Me.Panel2.TabIndex = 30
        '
        'btn_relatorios
        '
        Me.btn_relatorios.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_relatorios.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_relatorios.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_relatorios.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_relatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_relatorios.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btn_relatorios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_relatorios.Image = CType(resources.GetObject("btn_relatorios.Image"), System.Drawing.Image)
        Me.btn_relatorios.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_relatorios.Location = New System.Drawing.Point(141, 13)
        Me.btn_relatorios.Name = "btn_relatorios"
        Me.btn_relatorios.Size = New System.Drawing.Size(119, 92)
        Me.btn_relatorios.TabIndex = 0
        Me.btn_relatorios.Text = "&Relatórios"
        Me.btn_relatorios.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_relatorios.UseVisualStyleBackColor = False
        '
        'btn_manutencao
        '
        Me.btn_manutencao.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_manutencao.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_manutencao.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_manutencao.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_manutencao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_manutencao.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btn_manutencao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_manutencao.Image = CType(resources.GetObject("btn_manutencao.Image"), System.Drawing.Image)
        Me.btn_manutencao.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_manutencao.Location = New System.Drawing.Point(14, 13)
        Me.btn_manutencao.Name = "btn_manutencao"
        Me.btn_manutencao.Size = New System.Drawing.Size(119, 92)
        Me.btn_manutencao.TabIndex = 0
        Me.btn_manutencao.Text = "Manuteção"
        Me.btn_manutencao.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_manutencao.UseVisualStyleBackColor = False
        '
        'Frm_MenuCX_Diario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(294, 177)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MenuCX_Diario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu do Caixa Diario"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_manutencao As System.Windows.Forms.Button
    Friend WithEvents btn_relatorios As System.Windows.Forms.Button
End Class
