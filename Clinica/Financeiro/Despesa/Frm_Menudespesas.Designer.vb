<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Menudespesas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Menudespesas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_relatorios = New System.Windows.Forms.Button()
        Me.btn_lancamentos = New System.Windows.Forms.Button()
        Me.btn_cadplano = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_relatorios)
        Me.GroupBox1.Controls.Add(Me.btn_lancamentos)
        Me.GroupBox1.Controls.Add(Me.btn_cadplano)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 193)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btn_relatorios
        '
        Me.btn_relatorios.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_relatorios.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_relatorios.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_relatorios.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_relatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_relatorios.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_relatorios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_relatorios.Location = New System.Drawing.Point(75, 127)
        Me.btn_relatorios.Name = "btn_relatorios"
        Me.btn_relatorios.Size = New System.Drawing.Size(166, 48)
        Me.btn_relatorios.TabIndex = 2
        Me.btn_relatorios.Text = "&Relatórios"
        Me.btn_relatorios.UseVisualStyleBackColor = False
        '
        'btn_lancamentos
        '
        Me.btn_lancamentos.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_lancamentos.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_lancamentos.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_lancamentos.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_lancamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_lancamentos.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_lancamentos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_lancamentos.Location = New System.Drawing.Point(75, 73)
        Me.btn_lancamentos.Name = "btn_lancamentos"
        Me.btn_lancamentos.Size = New System.Drawing.Size(166, 48)
        Me.btn_lancamentos.TabIndex = 1
        Me.btn_lancamentos.Text = "&Lancamentos"
        Me.btn_lancamentos.UseVisualStyleBackColor = False
        '
        'btn_cadplano
        '
        Me.btn_cadplano.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_cadplano.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_cadplano.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_cadplano.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_cadplano.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cadplano.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_cadplano.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_cadplano.Location = New System.Drawing.Point(75, 19)
        Me.btn_cadplano.Name = "btn_cadplano"
        Me.btn_cadplano.Size = New System.Drawing.Size(166, 48)
        Me.btn_cadplano.TabIndex = 0
        Me.btn_cadplano.Text = "&Plano de Contas"
        Me.btn_cadplano.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-4, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(383, 42)
        Me.Panel1.TabIndex = 64
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(122, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Frm_Menudespesas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 249)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_Menudespesas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Despesas"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_relatorios As System.Windows.Forms.Button
    Friend WithEvents btn_lancamentos As System.Windows.Forms.Button
    Friend WithEvents btn_cadplano As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
End Class
