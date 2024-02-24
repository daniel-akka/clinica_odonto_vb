<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cadvendedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cadvendedores))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbo_supervisor = New System.Windows.Forms.ComboBox
        Me.grp_tipocomissao = New System.Windows.Forms.GroupBox
        Me.rdb_liquidez = New System.Windows.Forms.RadioButton
        Me.rdb_total = New System.Windows.Forms.RadioButton
        Me.rdb_produto = New System.Windows.Forms.RadioButton
        Me.rdb_nenhum = New System.Windows.Forms.RadioButton
        Me.msk_senha = New System.Windows.Forms.MaskedTextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_mensag3 = New System.Windows.Forms.TextBox
        Me.txt_mensag2 = New System.Windows.Forms.TextBox
        Me.txt_mensag1 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_alqcomis = New System.Windows.Forms.TextBox
        Me.chk_comissionado = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.msk_celular = New System.Windows.Forms.MaskedTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.msk_fone = New System.Windows.Forms.MaskedTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_rota = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbo_uf = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_bairro = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.pct_foto = New System.Windows.Forms.PictureBox
        Me.txt_cidade = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_endereco = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_nome = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_vendedor = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.btn_incluir = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_localfoto = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.grp_tipocomissao.SuspendLayout()
        CType(Me.pct_foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_localfoto)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cbo_supervisor)
        Me.GroupBox1.Controls.Add(Me.grp_tipocomissao)
        Me.GroupBox1.Controls.Add(Me.msk_senha)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txt_mensag3)
        Me.GroupBox1.Controls.Add(Me.txt_mensag2)
        Me.GroupBox1.Controls.Add(Me.txt_mensag1)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txt_alqcomis)
        Me.GroupBox1.Controls.Add(Me.chk_comissionado)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.msk_celular)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.msk_fone)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txt_rota)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cbo_uf)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_bairro)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.pct_foto)
        Me.GroupBox1.Controls.Add(Me.txt_cidade)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_endereco)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_nome)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_vendedor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(502, 390)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cbo_supervisor
        '
        Me.cbo_supervisor.FormattingEnabled = True
        Me.cbo_supervisor.Items.AddRange(New Object() {"01", "02"})
        Me.cbo_supervisor.Location = New System.Drawing.Point(196, 214)
        Me.cbo_supervisor.Name = "cbo_supervisor"
        Me.cbo_supervisor.Size = New System.Drawing.Size(55, 21)
        Me.cbo_supervisor.TabIndex = 32
        '
        'grp_tipocomissao
        '
        Me.grp_tipocomissao.Controls.Add(Me.rdb_liquidez)
        Me.grp_tipocomissao.Controls.Add(Me.rdb_total)
        Me.grp_tipocomissao.Controls.Add(Me.rdb_produto)
        Me.grp_tipocomissao.Controls.Add(Me.rdb_nenhum)
        Me.grp_tipocomissao.Location = New System.Drawing.Point(389, 179)
        Me.grp_tipocomissao.Name = "grp_tipocomissao"
        Me.grp_tipocomissao.Size = New System.Drawing.Size(107, 112)
        Me.grp_tipocomissao.TabIndex = 31
        Me.grp_tipocomissao.TabStop = False
        Me.grp_tipocomissao.Text = "Tipo Comissão"
        '
        'rdb_liquidez
        '
        Me.rdb_liquidez.AutoSize = True
        Me.rdb_liquidez.Location = New System.Drawing.Point(8, 87)
        Me.rdb_liquidez.Name = "rdb_liquidez"
        Me.rdb_liquidez.Size = New System.Drawing.Size(64, 17)
        Me.rdb_liquidez.TabIndex = 3
        Me.rdb_liquidez.TabStop = True
        Me.rdb_liquidez.Text = "Liquidez"
        Me.rdb_liquidez.UseVisualStyleBackColor = True
        '
        'rdb_total
        '
        Me.rdb_total.AutoSize = True
        Me.rdb_total.Location = New System.Drawing.Point(8, 67)
        Me.rdb_total.Name = "rdb_total"
        Me.rdb_total.Size = New System.Drawing.Size(49, 17)
        Me.rdb_total.TabIndex = 2
        Me.rdb_total.TabStop = True
        Me.rdb_total.Text = "Total"
        Me.rdb_total.UseVisualStyleBackColor = True
        '
        'rdb_produto
        '
        Me.rdb_produto.AutoSize = True
        Me.rdb_produto.Location = New System.Drawing.Point(8, 45)
        Me.rdb_produto.Name = "rdb_produto"
        Me.rdb_produto.Size = New System.Drawing.Size(62, 17)
        Me.rdb_produto.TabIndex = 1
        Me.rdb_produto.TabStop = True
        Me.rdb_produto.Text = "Produto"
        Me.rdb_produto.UseVisualStyleBackColor = True
        '
        'rdb_nenhum
        '
        Me.rdb_nenhum.AutoSize = True
        Me.rdb_nenhum.Location = New System.Drawing.Point(8, 22)
        Me.rdb_nenhum.Name = "rdb_nenhum"
        Me.rdb_nenhum.Size = New System.Drawing.Size(65, 17)
        Me.rdb_nenhum.TabIndex = 0
        Me.rdb_nenhum.TabStop = True
        Me.rdb_nenhum.Text = "Nenhum"
        Me.rdb_nenhum.UseVisualStyleBackColor = True
        '
        'msk_senha
        '
        Me.msk_senha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_senha.Location = New System.Drawing.Point(76, 349)
        Me.msk_senha.Mask = "9999"
        Me.msk_senha.Name = "msk_senha"
        Me.msk_senha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.msk_senha.Size = New System.Drawing.Size(58, 21)
        Me.msk_senha.TabIndex = 30
        Me.msk_senha.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(19, 349)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Senha:"
        '
        'txt_mensag3
        '
        Me.txt_mensag3.Location = New System.Drawing.Point(76, 323)
        Me.txt_mensag3.MaxLength = 60
        Me.txt_mensag3.Name = "txt_mensag3"
        Me.txt_mensag3.Size = New System.Drawing.Size(370, 20)
        Me.txt_mensag3.TabIndex = 28
        '
        'txt_mensag2
        '
        Me.txt_mensag2.Location = New System.Drawing.Point(76, 297)
        Me.txt_mensag2.MaxLength = 60
        Me.txt_mensag2.Name = "txt_mensag2"
        Me.txt_mensag2.Size = New System.Drawing.Size(370, 20)
        Me.txt_mensag2.TabIndex = 27
        '
        'txt_mensag1
        '
        Me.txt_mensag1.Location = New System.Drawing.Point(76, 270)
        Me.txt_mensag1.MaxLength = 60
        Me.txt_mensag1.Name = "txt_mensag1"
        Me.txt_mensag1.Size = New System.Drawing.Size(300, 20)
        Me.txt_mensag1.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 273)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Mensagem:"
        '
        'txt_alqcomis
        '
        Me.txt_alqcomis.Location = New System.Drawing.Point(76, 242)
        Me.txt_alqcomis.Name = "txt_alqcomis"
        Me.txt_alqcomis.Size = New System.Drawing.Size(40, 20)
        Me.txt_alqcomis.TabIndex = 24
        '
        'chk_comissionado
        '
        Me.chk_comissionado.AutoSize = True
        Me.chk_comissionado.Location = New System.Drawing.Point(276, 216)
        Me.chk_comissionado.Name = "chk_comissionado"
        Me.chk_comissionado.Size = New System.Drawing.Size(91, 17)
        Me.chk_comissionado.TabIndex = 23
        Me.chk_comissionado.Text = "Comissionado"
        Me.chk_comissionado.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 245)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Aliq.Comis:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(129, 216)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Supervisor:"
        '
        'msk_celular
        '
        Me.msk_celular.Location = New System.Drawing.Point(257, 183)
        Me.msk_celular.Mask = "(99)9999-9999"
        Me.msk_celular.Name = "msk_celular"
        Me.msk_celular.Size = New System.Drawing.Size(91, 20)
        Me.msk_celular.TabIndex = 20
        Me.msk_celular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(209, 186)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Celular:"
        '
        'msk_fone
        '
        Me.msk_fone.Location = New System.Drawing.Point(76, 183)
        Me.msk_fone.Mask = "(99)9999-9999"
        Me.msk_fone.Name = "msk_fone"
        Me.msk_fone.Size = New System.Drawing.Size(99, 20)
        Me.msk_fone.TabIndex = 18
        Me.msk_fone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 216)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Rota:"
        '
        'txt_rota
        '
        Me.txt_rota.Location = New System.Drawing.Point(76, 210)
        Me.txt_rota.MaxLength = 3
        Me.txt_rota.Name = "txt_rota"
        Me.txt_rota.Size = New System.Drawing.Size(47, 20)
        Me.txt_rota.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 186)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Fone:"
        '
        'cbo_uf
        '
        Me.cbo_uf.FormattingEnabled = True
        Me.cbo_uf.Location = New System.Drawing.Point(326, 124)
        Me.cbo_uf.Name = "cbo_uf"
        Me.cbo_uf.Size = New System.Drawing.Size(50, 21)
        Me.cbo_uf.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(296, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "UF:"
        '
        'txt_bairro
        '
        Me.txt_bairro.Location = New System.Drawing.Point(76, 153)
        Me.txt_bairro.Name = "txt_bairro"
        Me.txt_bairro.Size = New System.Drawing.Size(210, 20)
        Me.txt_bairro.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Bairro:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(418, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Foto"
        '
        'pct_foto
        '
        Me.pct_foto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pct_foto.ImageLocation = ""
        Me.pct_foto.Location = New System.Drawing.Point(389, 16)
        Me.pct_foto.Name = "pct_foto"
        Me.pct_foto.Size = New System.Drawing.Size(107, 139)
        Me.pct_foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pct_foto.TabIndex = 8
        Me.pct_foto.TabStop = False
        '
        'txt_cidade
        '
        Me.txt_cidade.Location = New System.Drawing.Point(76, 122)
        Me.txt_cidade.Name = "txt_cidade"
        Me.txt_cidade.Size = New System.Drawing.Size(214, 20)
        Me.txt_cidade.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cidade:"
        '
        'txt_endereco
        '
        Me.txt_endereco.Location = New System.Drawing.Point(76, 91)
        Me.txt_endereco.MaxLength = 35
        Me.txt_endereco.Name = "txt_endereco"
        Me.txt_endereco.Size = New System.Drawing.Size(272, 20)
        Me.txt_endereco.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Endereço:"
        '
        'txt_nome
        '
        Me.txt_nome.Location = New System.Drawing.Point(76, 59)
        Me.txt_nome.MaxLength = 10
        Me.txt_nome.Name = "txt_nome"
        Me.txt_nome.Size = New System.Drawing.Size(272, 20)
        Me.txt_nome.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nome:"
        '
        'txt_vendedor
        '
        Me.txt_vendedor.Location = New System.Drawing.Point(76, 28)
        Me.txt_vendedor.MaxLength = 5
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(70, 20)
        Me.txt_vendedor.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_alterar)
        Me.GroupBox2.Controls.Add(Me.btn_incluir)
        Me.GroupBox2.Location = New System.Drawing.Point(390, 416)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(124, 59)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(64, 13)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(54, 40)
        Me.btn_alterar.TabIndex = 1
        Me.btn_alterar.Text = "&Altera"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_incluir
        '
        Me.btn_incluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_incluir.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.Location = New System.Drawing.Point(6, 13)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(54, 40)
        Me.btn_incluir.TabIndex = 0
        Me.btn_incluir.Text = "&Inclui"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 418)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(367, 54)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(17, 23)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(0, 15)
        Me.lbl_mensagem.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(156, 357)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "LocalFoto:"
        '
        'txt_localfoto
        '
        Me.txt_localfoto.Location = New System.Drawing.Point(215, 354)
        Me.txt_localfoto.Name = "txt_localfoto"
        Me.txt_localfoto.Size = New System.Drawing.Size(231, 20)
        Me.txt_localfoto.TabIndex = 34
        Me.txt_localfoto.Text = "C:\Wged\Wgenov\Vendedores\Brahma3.bmp"
        '
        'Frm_Cadvendedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 488)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_Cadvendedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Vendedores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp_tipocomissao.ResumeLayout(False)
        Me.grp_tipocomissao.PerformLayout()
        CType(Me.pct_foto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_endereco As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_nome As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_uf As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_bairro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pct_foto As System.Windows.Forms.PictureBox
    Friend WithEvents txt_cidade As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_rota As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents msk_celular As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents msk_fone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents chk_comissionado As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_mensag1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_alqcomis As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_mensag3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_mensag2 As System.Windows.Forms.TextBox
    Friend WithEvents msk_senha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents grp_tipocomissao As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_supervisor As System.Windows.Forms.ComboBox
    Friend WithEvents rdb_total As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_produto As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_nenhum As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_liquidez As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents txt_localfoto As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
