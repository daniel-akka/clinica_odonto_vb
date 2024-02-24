<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Sintegra
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Sintegra))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbo_estabelecimento = New System.Windows.Forms.ComboBox
        Me.txt_razaosocial = New System.Windows.Forms.TextBox
        Me.chk_retificacao = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.txt_ddd = New System.Windows.Forms.TextBox
        Me.txt_responsavel = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_arquivo = New System.Windows.Forms.TextBox
        Me.btn_salvar = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.btn_gerar = New System.Windows.Forms.Button
        Me.btn_sair = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.msk_dtinicial = New System.Windows.Forms.MaskedTextBox
        Me.msk_dtfinal = New System.Windows.Forms.MaskedTextBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(562, 74)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("Wide Latin", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(437, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Genov"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(176, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(156, 58)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Estabelecimento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Periodo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(111, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "a"
        '
        'cbo_estabelecimento
        '
        Me.cbo_estabelecimento.FormattingEnabled = True
        Me.cbo_estabelecimento.Items.AddRange(New Object() {"01 P. da Silva - Matriz", "02 P. da Silva - Filial", "03 P. da Silva - Açucar", "04 Pascoal  Joaquim - Matriz", "05 Pascoal  Joaquim - Dep1", "06 Pascoal  Joaquim - Dep2"})
        Me.cbo_estabelecimento.Location = New System.Drawing.Point(16, 100)
        Me.cbo_estabelecimento.Name = "cbo_estabelecimento"
        Me.cbo_estabelecimento.Size = New System.Drawing.Size(78, 21)
        Me.cbo_estabelecimento.TabIndex = 8
        '
        'txt_razaosocial
        '
        Me.txt_razaosocial.Location = New System.Drawing.Point(100, 101)
        Me.txt_razaosocial.MaxLength = 50
        Me.txt_razaosocial.Name = "txt_razaosocial"
        Me.txt_razaosocial.ReadOnly = True
        Me.txt_razaosocial.Size = New System.Drawing.Size(362, 20)
        Me.txt_razaosocial.TabIndex = 11
        '
        'chk_retificacao
        '
        Me.chk_retificacao.AutoSize = True
        Me.chk_retificacao.Location = New System.Drawing.Point(289, 143)
        Me.chk_retificacao.Name = "chk_retificacao"
        Me.chk_retificacao.Size = New System.Drawing.Size(80, 17)
        Me.chk_retificacao.TabIndex = 12
        Me.chk_retificacao.Text = "Retificação"
        Me.chk_retificacao.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.txt_ddd)
        Me.GroupBox1.Controls.Add(Me.txt_responsavel)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 169)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(471, 66)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Responsavel para Contato"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(359, 32)
        Me.TextBox4.MaxLength = 8
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(87, 20)
        Me.TextBox4.TabIndex = 5
        Me.TextBox4.Text = "34153008"
        '
        'txt_ddd
        '
        Me.txt_ddd.Location = New System.Drawing.Point(316, 32)
        Me.txt_ddd.MaxLength = 3
        Me.txt_ddd.Name = "txt_ddd"
        Me.txt_ddd.Size = New System.Drawing.Size(37, 20)
        Me.txt_ddd.TabIndex = 4
        Me.txt_ddd.Text = "089"
        '
        'txt_responsavel
        '
        Me.txt_responsavel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_responsavel.Location = New System.Drawing.Point(12, 32)
        Me.txt_responsavel.MaxLength = 40
        Me.txt_responsavel.Name = "txt_responsavel"
        Me.txt_responsavel.Size = New System.Drawing.Size(298, 20)
        Me.txt_responsavel.TabIndex = 3
        Me.txt_responsavel.Text = "ADAILDO PEREIRA DA SILVA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(376, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Fone:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(319, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "DDD:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nome:"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(18, 247)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(224, 17)
        Me.CheckBox2.TabIndex = 14
        Me.CheckBox2.Text = "Gerar Inventário Mensal(Regime Especial)"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(18, 271)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(184, 17)
        Me.CheckBox3.TabIndex = 15
        Me.CheckBox3.Text = "Não Gerar Itens dos Documentos"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 307)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Arquivo:"
        '
        'txt_arquivo
        '
        Me.txt_arquivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_arquivo.Location = New System.Drawing.Point(15, 326)
        Me.txt_arquivo.MaxLength = 100
        Me.txt_arquivo.Name = "txt_arquivo"
        Me.txt_arquivo.Size = New System.Drawing.Size(311, 23)
        Me.txt_arquivo.TabIndex = 17
        '
        'btn_salvar
        '
        Me.btn_salvar.Image = Global.MetroSys.My.Resources.Resources.Load
        Me.btn_salvar.Location = New System.Drawing.Point(330, 322)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(33, 31)
        Me.btn_salvar.TabIndex = 18
        Me.btn_salvar.Text = "..."
        Me.btn_salvar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(18, 367)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(521, 23)
        Me.ProgressBar1.TabIndex = 19
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 460)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(560, 22)
        Me.StatusStrip1.TabIndex = 20
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'btn_gerar
        '
        Me.btn_gerar.Image = Global.MetroSys.My.Resources.Resources.disc_r
        Me.btn_gerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_gerar.Location = New System.Drawing.Point(6, 13)
        Me.btn_gerar.Name = "btn_gerar"
        Me.btn_gerar.Size = New System.Drawing.Size(54, 42)
        Me.btn_gerar.TabIndex = 21
        Me.btn_gerar.Text = "&Gerar"
        Me.btn_gerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_gerar.UseVisualStyleBackColor = True
        '
        'btn_sair
        '
        Me.btn_sair.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_sair.Location = New System.Drawing.Point(67, 14)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(54, 42)
        Me.btn_sair.TabIndex = 22
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_gerar)
        Me.GroupBox2.Controls.Add(Me.btn_sair)
        Me.GroupBox2.Location = New System.Drawing.Point(414, 393)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(125, 61)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        '
        'msk_dtinicial
        '
        Me.msk_dtinicial.Location = New System.Drawing.Point(18, 143)
        Me.msk_dtinicial.Mask = "00/00/0000"
        Me.msk_dtinicial.Name = "msk_dtinicial"
        Me.msk_dtinicial.Size = New System.Drawing.Size(81, 20)
        Me.msk_dtinicial.TabIndex = 24
        Me.msk_dtinicial.ValidatingType = GetType(Date)
        '
        'msk_dtfinal
        '
        Me.msk_dtfinal.Location = New System.Drawing.Point(134, 144)
        Me.msk_dtfinal.Mask = "00/00/0000"
        Me.msk_dtfinal.Name = "msk_dtfinal"
        Me.msk_dtfinal.Size = New System.Drawing.Size(85, 20)
        Me.msk_dtfinal.TabIndex = 25
        Me.msk_dtfinal.ValidatingType = GetType(Date)
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Frm_Sintegra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 482)
        Me.Controls.Add(Me.msk_dtfinal)
        Me.Controls.Add(Me.msk_dtinicial)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btn_salvar)
        Me.Controls.Add(Me.txt_arquivo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chk_retificacao)
        Me.Controls.Add(Me.txt_razaosocial)
        Me.Controls.Add(Me.cbo_estabelecimento)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_Sintegra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gera Arquivo Sintegra"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_estabelecimento As System.Windows.Forms.ComboBox
    Friend WithEvents txt_razaosocial As System.Windows.Forms.TextBox
    Friend WithEvents chk_retificacao As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ddd As System.Windows.Forms.TextBox
    Friend WithEvents txt_responsavel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_arquivo As System.Windows.Forms.TextBox
    Friend WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents btn_gerar As System.Windows.Forms.Button
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents msk_dtinicial As System.Windows.Forms.MaskedTextBox
    Friend WithEvents msk_dtfinal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
