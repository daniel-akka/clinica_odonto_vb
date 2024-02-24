<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_OutrosPagamentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_OutrosPagamentos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_baixaboleto = New System.Windows.Forms.Button
        Me.btn_posicao = New System.Windows.Forms.Button
        Me.btn_devolucao = New System.Windows.Forms.Button
        Me.btn_baixageral = New System.Windows.Forms.Button
        Me.btn_baixaindividual = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_baixaboleto)
        Me.GroupBox1.Controls.Add(Me.btn_posicao)
        Me.GroupBox1.Controls.Add(Me.btn_devolucao)
        Me.GroupBox1.Controls.Add(Me.btn_baixageral)
        Me.GroupBox1.Controls.Add(Me.btn_baixaindividual)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(333, 253)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opções"
        '
        'btn_baixaboleto
        '
        Me.btn_baixaboleto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_baixaboleto.Location = New System.Drawing.Point(81, 111)
        Me.btn_baixaboleto.Name = "btn_baixaboleto"
        Me.btn_baixaboleto.Size = New System.Drawing.Size(165, 34)
        Me.btn_baixaboleto.TabIndex = 5
        Me.btn_baixaboleto.Text = "Bai&xa Boletos"
        Me.btn_baixaboleto.UseVisualStyleBackColor = True
        '
        'btn_posicao
        '
        Me.btn_posicao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_posicao.Location = New System.Drawing.Point(81, 192)
        Me.btn_posicao.Name = "btn_posicao"
        Me.btn_posicao.Size = New System.Drawing.Size(165, 38)
        Me.btn_posicao.TabIndex = 4
        Me.btn_posicao.Text = "&Posição do Portador"
        Me.btn_posicao.UseVisualStyleBackColor = True
        '
        'btn_devolucao
        '
        Me.btn_devolucao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_devolucao.Location = New System.Drawing.Point(81, 152)
        Me.btn_devolucao.Name = "btn_devolucao"
        Me.btn_devolucao.Size = New System.Drawing.Size(165, 34)
        Me.btn_devolucao.TabIndex = 2
        Me.btn_devolucao.Text = "&Devolução/Estorno"
        Me.btn_devolucao.UseVisualStyleBackColor = True
        '
        'btn_baixageral
        '
        Me.btn_baixageral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_baixageral.Location = New System.Drawing.Point(81, 67)
        Me.btn_baixageral.Name = "btn_baixageral"
        Me.btn_baixageral.Size = New System.Drawing.Size(165, 36)
        Me.btn_baixageral.TabIndex = 1
        Me.btn_baixageral.Text = "Baixa &Geral"
        Me.btn_baixageral.UseVisualStyleBackColor = True
        '
        'btn_baixaindividual
        '
        Me.btn_baixaindividual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_baixaindividual.Location = New System.Drawing.Point(81, 26)
        Me.btn_baixaindividual.Name = "btn_baixaindividual"
        Me.btn_baixaindividual.Size = New System.Drawing.Size(165, 33)
        Me.btn_baixaindividual.TabIndex = 0
        Me.btn_baixaindividual.Text = "&Baixa Individual"
        Me.btn_baixaindividual.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-9, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(400, 61)
        Me.Panel1.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label5.Font = New System.Drawing.Font("Wide Latin", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(268, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 18)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "MetroSys"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(96, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(162, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Frm_OutrosPagamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 362)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_OutrosPagamentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Outras Opções"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_baixaboleto As System.Windows.Forms.Button
    Friend WithEvents btn_posicao As System.Windows.Forms.Button
    Friend WithEvents btn_devolucao As System.Windows.Forms.Button
    Friend WithEvents btn_baixageral As System.Windows.Forms.Button
    Friend WithEvents btn_baixaindividual As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
