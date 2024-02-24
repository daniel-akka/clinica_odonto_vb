<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MenuLancamentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MenuLancamentos))
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label26 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_pesquisa = New System.Windows.Forms.Button
        Me.msk_final = New System.Windows.Forms.MaskedTextBox
        Me.lbl_intervalo = New System.Windows.Forms.Label
        Me.msk_inicio = New System.Windows.Forms.MaskedTextBox
        Me.grp_opcao = New System.Windows.Forms.GroupBox
        Me.rdb_periodo = New System.Windows.Forms.RadioButton
        Me.rdb_historico = New System.Windows.Forms.RadioButton
        Me.txt_pesquisa = New System.Windows.Forms.TextBox
        Me.dtg_lancamentos = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.btn_novo = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grp_opcao.SuspendLayout()
        CType(Me.dtg_lancamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pesquisa:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(625, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(748, 67)
        Me.Panel1.TabIndex = 16
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(652, 43)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(66, 15)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox3.Location = New System.Drawing.Point(313, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(166, 54)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_pesquisa)
        Me.GroupBox1.Controls.Add(Me.msk_final)
        Me.GroupBox1.Controls.Add(Me.lbl_intervalo)
        Me.GroupBox1.Controls.Add(Me.msk_inicio)
        Me.GroupBox1.Controls.Add(Me.grp_opcao)
        Me.GroupBox1.Controls.Add(Me.txt_pesquisa)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(717, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btn_pesquisa
        '
        Me.btn_pesquisa.Image = Global.MetroSys.My.Resources.Resources.Busca_16x16
        Me.btn_pesquisa.Location = New System.Drawing.Point(392, 16)
        Me.btn_pesquisa.Name = "btn_pesquisa"
        Me.btn_pesquisa.Size = New System.Drawing.Size(28, 27)
        Me.btn_pesquisa.TabIndex = 4
        Me.btn_pesquisa.UseVisualStyleBackColor = True
        '
        'msk_final
        '
        Me.msk_final.Location = New System.Drawing.Point(178, 19)
        Me.msk_final.Mask = "00/00/0000"
        Me.msk_final.Name = "msk_final"
        Me.msk_final.Size = New System.Drawing.Size(77, 20)
        Me.msk_final.TabIndex = 3
        Me.msk_final.ValidatingType = GetType(Date)
        '
        'lbl_intervalo
        '
        Me.lbl_intervalo.AutoSize = True
        Me.lbl_intervalo.Location = New System.Drawing.Point(149, 23)
        Me.lbl_intervalo.Name = "lbl_intervalo"
        Me.lbl_intervalo.Size = New System.Drawing.Size(14, 13)
        Me.lbl_intervalo.TabIndex = 4
        Me.lbl_intervalo.Text = "A"
        '
        'msk_inicio
        '
        Me.msk_inicio.Location = New System.Drawing.Point(64, 19)
        Me.msk_inicio.Mask = "00/00/0000"
        Me.msk_inicio.Name = "msk_inicio"
        Me.msk_inicio.Size = New System.Drawing.Size(76, 20)
        Me.msk_inicio.TabIndex = 2
        Me.msk_inicio.ValidatingType = GetType(Date)
        '
        'grp_opcao
        '
        Me.grp_opcao.Controls.Add(Me.rdb_periodo)
        Me.grp_opcao.Controls.Add(Me.rdb_historico)
        Me.grp_opcao.Location = New System.Drawing.Point(516, 8)
        Me.grp_opcao.Name = "grp_opcao"
        Me.grp_opcao.Size = New System.Drawing.Size(166, 35)
        Me.grp_opcao.TabIndex = 5
        Me.grp_opcao.TabStop = False
        '
        'rdb_periodo
        '
        Me.rdb_periodo.AutoSize = True
        Me.rdb_periodo.Location = New System.Drawing.Point(96, 12)
        Me.rdb_periodo.Name = "rdb_periodo"
        Me.rdb_periodo.Size = New System.Drawing.Size(61, 17)
        Me.rdb_periodo.TabIndex = 7
        Me.rdb_periodo.Text = "Periodo"
        Me.rdb_periodo.UseVisualStyleBackColor = True
        '
        'rdb_historico
        '
        Me.rdb_historico.AutoSize = True
        Me.rdb_historico.Checked = True
        Me.rdb_historico.Location = New System.Drawing.Point(12, 12)
        Me.rdb_historico.Name = "rdb_historico"
        Me.rdb_historico.Size = New System.Drawing.Size(66, 17)
        Me.rdb_historico.TabIndex = 6
        Me.rdb_historico.TabStop = True
        Me.rdb_historico.Text = "&Histórico"
        Me.rdb_historico.UseVisualStyleBackColor = True
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(63, 18)
        Me.txt_pesquisa.MaxLength = 30
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(319, 21)
        Me.txt_pesquisa.TabIndex = 1
        '
        'dtg_lancamentos
        '
        Me.dtg_lancamentos.AllowUserToAddRows = False
        Me.dtg_lancamentos.AllowUserToDeleteRows = False
        Me.dtg_lancamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_lancamentos.Location = New System.Drawing.Point(13, 129)
        Me.dtg_lancamentos.Name = "dtg_lancamentos"
        Me.dtg_lancamentos.ReadOnly = True
        Me.dtg_lancamentos.Size = New System.Drawing.Size(717, 345)
        Me.dtg_lancamentos.TabIndex = 8
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 479)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(531, 59)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(12, 26)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem.TabIndex = 14
        Me.lbl_mensagem.Text = "    "
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_excluir)
        Me.GroupBox4.Controls.Add(Me.btn_alterar)
        Me.GroupBox4.Controls.Add(Me.btn_novo)
        Me.GroupBox4.Location = New System.Drawing.Point(549, 479)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(184, 62)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        '
        'btn_excluir
        '
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_excluir.Location = New System.Drawing.Point(125, 15)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(53, 39)
        Me.btn_excluir.TabIndex = 12
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(67, 15)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(52, 39)
        Me.btn_alterar.TabIndex = 11
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_novo
        '
        Me.btn_novo.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_novo.Location = New System.Drawing.Point(9, 15)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(52, 39)
        Me.btn_novo.TabIndex = 10
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'Frm_MenuLancamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 544)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dtg_lancamentos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_MenuLancamentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lançamento das Despesas"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp_opcao.ResumeLayout(False)
        Me.grp_opcao.PerformLayout()
        CType(Me.dtg_lancamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents grp_opcao As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_periodo As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_historico As System.Windows.Forms.RadioButton
    Friend WithEvents dtg_lancamentos As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_intervalo As System.Windows.Forms.Label
    Friend WithEvents msk_inicio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btn_pesquisa As System.Windows.Forms.Button
    Friend WithEvents msk_final As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
End Class
