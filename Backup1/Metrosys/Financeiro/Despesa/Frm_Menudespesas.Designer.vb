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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_relatorios = New System.Windows.Forms.Button
        Me.btn_lancamentos = New System.Windows.Forms.Button
        Me.btn_cadplano = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_relatorios)
        Me.GroupBox1.Controls.Add(Me.btn_lancamentos)
        Me.GroupBox1.Controls.Add(Me.btn_cadplano)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(373, 248)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btn_relatorios
        '
        Me.btn_relatorios.Location = New System.Drawing.Point(90, 147)
        Me.btn_relatorios.Name = "btn_relatorios"
        Me.btn_relatorios.Size = New System.Drawing.Size(166, 41)
        Me.btn_relatorios.TabIndex = 2
        Me.btn_relatorios.Text = "&Relatórios"
        Me.btn_relatorios.UseVisualStyleBackColor = True
        '
        'btn_lancamentos
        '
        Me.btn_lancamentos.Location = New System.Drawing.Point(90, 97)
        Me.btn_lancamentos.Name = "btn_lancamentos"
        Me.btn_lancamentos.Size = New System.Drawing.Size(166, 40)
        Me.btn_lancamentos.TabIndex = 1
        Me.btn_lancamentos.Text = "&Lancamentos"
        Me.btn_lancamentos.UseVisualStyleBackColor = True
        '
        'btn_cadplano
        '
        Me.btn_cadplano.Location = New System.Drawing.Point(90, 42)
        Me.btn_cadplano.Name = "btn_cadplano"
        Me.btn_cadplano.Size = New System.Drawing.Size(166, 39)
        Me.btn_cadplano.TabIndex = 0
        Me.btn_cadplano.Text = "&Plano de Contas"
        Me.btn_cadplano.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(438, 75)
        Me.Panel1.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(315, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(321, 44)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(66, 15)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(134, 7)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(166, 54)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Frm_Menudespesas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 367)
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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_relatorios As System.Windows.Forms.Button
    Friend WithEvents btn_lancamentos As System.Windows.Forms.Button
    Friend WithEvents btn_cadplano As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
