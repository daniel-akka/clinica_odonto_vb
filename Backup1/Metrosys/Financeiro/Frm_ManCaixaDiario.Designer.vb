<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManCaixaDiario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManCaixaDiario))
        Me.dtg_caixamov = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_fechamento = New System.Windows.Forms.Button
        Me.btn_pesquisa = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.MaskedTextBox2 = New System.Windows.Forms.MaskedTextBox
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox
        Me.btn_sair = New System.Windows.Forms.Button
        Me.btn_estorno = New System.Windows.Forms.Button
        Me.btn_lancar = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dtg_caixamov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_caixamov
        '
        Me.dtg_caixamov.AllowUserToAddRows = False
        Me.dtg_caixamov.AllowUserToDeleteRows = False
        Me.dtg_caixamov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_caixamov.Location = New System.Drawing.Point(12, 80)
        Me.dtg_caixamov.Name = "dtg_caixamov"
        Me.dtg_caixamov.ReadOnly = True
        Me.dtg_caixamov.Size = New System.Drawing.Size(586, 319)
        Me.dtg_caixamov.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btn_fechamento)
        Me.GroupBox1.Controls.Add(Me.btn_pesquisa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.MaskedTextBox2)
        Me.GroupBox1.Controls.Add(Me.MaskedTextBox1)
        Me.GroupBox1.Controls.Add(Me.btn_sair)
        Me.GroupBox1.Controls.Add(Me.btn_estorno)
        Me.GroupBox1.Controls.Add(Me.btn_lancar)
        Me.GroupBox1.Location = New System.Drawing.Point(615, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(128, 335)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(30, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Período"
        '
        'btn_fechamento
        '
        Me.btn_fechamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_fechamento.Image = Global.MetroSys.My.Resources.Resources.disc_r
        Me.btn_fechamento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_fechamento.Location = New System.Drawing.Point(11, 107)
        Me.btn_fechamento.Name = "btn_fechamento"
        Me.btn_fechamento.Size = New System.Drawing.Size(107, 47)
        Me.btn_fechamento.TabIndex = 7
        Me.btn_fechamento.Text = "Abert. &Fecham."
        Me.btn_fechamento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_fechamento.UseVisualStyleBackColor = True
        '
        'btn_pesquisa
        '
        Me.btn_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pesquisa.Location = New System.Drawing.Point(24, 295)
        Me.btn_pesquisa.Name = "btn_pesquisa"
        Me.btn_pesquisa.Size = New System.Drawing.Size(75, 23)
        Me.btn_pesquisa.TabIndex = 6
        Me.btn_pesquisa.Text = "&Pesquisa"
        Me.btn_pesquisa.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(51, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "A"
        '
        'MaskedTextBox2
        '
        Me.MaskedTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox2.Location = New System.Drawing.Point(11, 266)
        Me.MaskedTextBox2.Mask = "00/00/0000"
        Me.MaskedTextBox2.Name = "MaskedTextBox2"
        Me.MaskedTextBox2.Size = New System.Drawing.Size(100, 21)
        Me.MaskedTextBox2.TabIndex = 4
        Me.MaskedTextBox2.ValidatingType = GetType(Date)
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox1.Location = New System.Drawing.Point(11, 226)
        Me.MaskedTextBox1.Mask = "00/00/0000"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(100, 21)
        Me.MaskedTextBox1.TabIndex = 3
        Me.MaskedTextBox1.ValidatingType = GetType(Date)
        '
        'btn_sair
        '
        Me.btn_sair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sair.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_sair.Location = New System.Drawing.Point(11, 159)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(107, 42)
        Me.btn_sair.TabIndex = 2
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'btn_estorno
        '
        Me.btn_estorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_estorno.Image = Global.MetroSys.My.Resources.Resources.cancelar
        Me.btn_estorno.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_estorno.Location = New System.Drawing.Point(11, 62)
        Me.btn_estorno.Name = "btn_estorno"
        Me.btn_estorno.Size = New System.Drawing.Size(107, 42)
        Me.btn_estorno.TabIndex = 1
        Me.btn_estorno.Text = "&Estorno"
        Me.btn_estorno.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_estorno.UseVisualStyleBackColor = True
        '
        'btn_lancar
        '
        Me.btn_lancar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_lancar.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_lancar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_lancar.Location = New System.Drawing.Point(11, 12)
        Me.btn_lancar.Name = "btn_lancar"
        Me.btn_lancar.Size = New System.Drawing.Size(107, 42)
        Me.btn_lancar.TabIndex = 0
        Me.btn_lancar.Text = "&Lancar"
        Me.btn_lancar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_lancar.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Wide Latin", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(583, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(148, 19)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(276, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(183, 59)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(757, 75)
        Me.Panel1.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 405)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(586, 48)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "    "
        '
        'Frm_ManCaixaDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 459)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtg_caixamov)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ManCaixaDiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção em Movimentação de Caixa"
        CType(Me.dtg_caixamov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtg_caixamov As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents btn_estorno As System.Windows.Forms.Button
    Friend WithEvents btn_lancar As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MaskedTextBox2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_pesquisa As System.Windows.Forms.Button
    Friend WithEvents btn_fechamento As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
