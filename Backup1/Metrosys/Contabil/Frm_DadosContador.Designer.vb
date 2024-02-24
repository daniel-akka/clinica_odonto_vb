<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DadosContador
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.msk_cep = New System.Windows.Forms.MaskedTextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.msk_cpf = New System.Windows.Forms.MaskedTextBox
        Me.msk_cnpj = New System.Windows.Forms.MaskedTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.msk_fone = New System.Windows.Forms.MaskedTextBox
        Me.msk_fax = New System.Windows.Forms.MaskedTextBox
        Me.txt_codmun = New System.Windows.Forms.TextBox
        Me.txt_crc = New System.Windows.Forms.TextBox
        Me.txt_email = New System.Windows.Forms.TextBox
        Me.txt_bairro = New System.Windows.Forms.TextBox
        Me.txt_complemento = New System.Windows.Forms.TextBox
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.txt_endereco = New System.Windows.Forms.TextBox
        Me.txt_nome = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btn_gravar = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.grp_contabil = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.grp_contabil.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.msk_cep)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.msk_cpf)
        Me.GroupBox4.Controls.Add(Me.msk_cnpj)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.msk_fone)
        Me.GroupBox4.Controls.Add(Me.msk_fax)
        Me.GroupBox4.Controls.Add(Me.txt_codmun)
        Me.GroupBox4.Controls.Add(Me.txt_crc)
        Me.GroupBox4.Controls.Add(Me.txt_email)
        Me.GroupBox4.Controls.Add(Me.txt_bairro)
        Me.GroupBox4.Controls.Add(Me.txt_complemento)
        Me.GroupBox4.Controls.Add(Me.txt_numero)
        Me.GroupBox4.Controls.Add(Me.txt_endereco)
        Me.GroupBox4.Controls.Add(Me.txt_nome)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 25)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(437, 232)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Informações Contabeis:"
        '
        'msk_cep
        '
        Me.msk_cep.Location = New System.Drawing.Point(54, 118)
        Me.msk_cep.Mask = "99999-999"
        Me.msk_cep.Name = "msk_cep"
        Me.msk_cep.Size = New System.Drawing.Size(85, 20)
        Me.msk_cep.TabIndex = 25
        Me.msk_cep.Text = "64600000"
        Me.msk_cep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(13, 121)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(29, 13)
        Me.Label27.TabIndex = 24
        Me.Label27.Text = "Cep:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(10, 206)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 13)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "E-Mail:"
        '
        'msk_cpf
        '
        Me.msk_cpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_cpf.Location = New System.Drawing.Point(54, 177)
        Me.msk_cpf.Mask = "999,999,999-99"
        Me.msk_cpf.Name = "msk_cpf"
        Me.msk_cpf.Size = New System.Drawing.Size(130, 21)
        Me.msk_cpf.TabIndex = 15
        Me.msk_cpf.Text = "33952370444"
        Me.msk_cpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'msk_cnpj
        '
        Me.msk_cnpj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_cnpj.Location = New System.Drawing.Point(269, 150)
        Me.msk_cnpj.Mask = "99,999,999/9999-99"
        Me.msk_cnpj.Name = "msk_cnpj"
        Me.msk_cnpj.Size = New System.Drawing.Size(149, 21)
        Me.msk_cnpj.TabIndex = 14
        Me.msk_cnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 180)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(30, 13)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "CPF:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(222, 153)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 13)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "CNPJ:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(245, 180)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "CRC:"
        '
        'msk_fone
        '
        Me.msk_fone.Location = New System.Drawing.Point(318, 118)
        Me.msk_fone.Mask = "(99)9999-9999"
        Me.msk_fone.Name = "msk_fone"
        Me.msk_fone.Size = New System.Drawing.Size(100, 20)
        Me.msk_fone.TabIndex = 12
        Me.msk_fone.Text = "8999841087"
        Me.msk_fone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'msk_fax
        '
        Me.msk_fax.Location = New System.Drawing.Point(54, 150)
        Me.msk_fax.Mask = "(99)9999-9999"
        Me.msk_fax.Name = "msk_fax"
        Me.msk_fax.Size = New System.Drawing.Size(100, 20)
        Me.msk_fax.TabIndex = 13
        Me.msk_fax.Text = "8934223840"
        Me.msk_fax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txt_codmun
        '
        Me.txt_codmun.Location = New System.Drawing.Point(207, 117)
        Me.txt_codmun.MaxLength = 8
        Me.txt_codmun.Name = "txt_codmun"
        Me.txt_codmun.Size = New System.Drawing.Size(65, 20)
        Me.txt_codmun.TabIndex = 11
        Me.txt_codmun.Text = "2208007"
        '
        'txt_crc
        '
        Me.txt_crc.Location = New System.Drawing.Point(291, 177)
        Me.txt_crc.MaxLength = 10
        Me.txt_crc.Name = "txt_crc"
        Me.txt_crc.Size = New System.Drawing.Size(127, 20)
        Me.txt_crc.TabIndex = 16
        Me.txt_crc.Text = "3926"
        '
        'txt_email
        '
        Me.txt_email.Location = New System.Drawing.Point(54, 204)
        Me.txt_email.MaxLength = 30
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(188, 20)
        Me.txt_email.TabIndex = 17
        Me.txt_email.Text = "jocileluz@gmail.com"
        '
        'txt_bairro
        '
        Me.txt_bairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_bairro.Location = New System.Drawing.Point(291, 84)
        Me.txt_bairro.MaxLength = 25
        Me.txt_bairro.Name = "txt_bairro"
        Me.txt_bairro.Size = New System.Drawing.Size(127, 20)
        Me.txt_bairro.TabIndex = 10
        Me.txt_bairro.Text = "CENTRO"
        '
        'txt_complemento
        '
        Me.txt_complemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_complemento.Location = New System.Drawing.Point(54, 84)
        Me.txt_complemento.MaxLength = 15
        Me.txt_complemento.Name = "txt_complemento"
        Me.txt_complemento.Size = New System.Drawing.Size(188, 20)
        Me.txt_complemento.TabIndex = 9
        Me.txt_complemento.Text = "O MESMO"
        '
        'txt_numero
        '
        Me.txt_numero.Location = New System.Drawing.Point(369, 53)
        Me.txt_numero.MaxLength = 5
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(49, 20)
        Me.txt_numero.TabIndex = 8
        Me.txt_numero.Text = "300"
        '
        'txt_endereco
        '
        Me.txt_endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_endereco.Location = New System.Drawing.Point(54, 52)
        Me.txt_endereco.MaxLength = 30
        Me.txt_endereco.Name = "txt_endereco"
        Me.txt_endereco.Size = New System.Drawing.Size(260, 20)
        Me.txt_endereco.TabIndex = 7
        Me.txt_endereco.Text = "AV. GETULO VARGAS, 300 2º ANDAR SALA 2"
        '
        'txt_nome
        '
        Me.txt_nome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nome.Location = New System.Drawing.Point(54, 19)
        Me.txt_nome.Name = "txt_nome"
        Me.txt_nome.Size = New System.Drawing.Size(364, 20)
        Me.txt_nome.TabIndex = 6
        Me.txt_nome.Text = "JOCILE MOURA LUZ"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(158, 121)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "CdMun:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 153)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Fax:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(278, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Fone:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(248, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Bairro:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Compl.:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(330, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Num.:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Ender.:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Nome:"
        '
        'btn_gravar
        '
        Me.btn_gravar.Image = Global.MetroSys.My.Resources.Resources.Load
        Me.btn_gravar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_gravar.Location = New System.Drawing.Point(10, 14)
        Me.btn_gravar.Name = "btn_gravar"
        Me.btn_gravar.Size = New System.Drawing.Size(58, 41)
        Me.btn_gravar.TabIndex = 15
        Me.btn_gravar.Text = "&Gravar"
        Me.btn_gravar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_gravar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(79, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(58, 41)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "&Sair"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'grp_contabil
        '
        Me.grp_contabil.Controls.Add(Me.Button2)
        Me.grp_contabil.Controls.Add(Me.btn_gravar)
        Me.grp_contabil.Location = New System.Drawing.Point(303, 257)
        Me.grp_contabil.Name = "grp_contabil"
        Me.grp_contabil.Size = New System.Drawing.Size(146, 62)
        Me.grp_contabil.TabIndex = 17
        Me.grp_contabil.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Mensagem:"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(80, 290)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(0, 17)
        Me.lbl_mensagem.TabIndex = 19
        '
        'Frm_DadosContador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 333)
        Me.Controls.Add(Me.lbl_mensagem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grp_contabil)
        Me.Controls.Add(Me.GroupBox4)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_DadosContador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dados Contabeis"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.grp_contabil.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents msk_cep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents msk_cpf As System.Windows.Forms.MaskedTextBox
    Friend WithEvents msk_cnpj As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents msk_fone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents msk_fax As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_codmun As System.Windows.Forms.TextBox
    Friend WithEvents txt_crc As System.Windows.Forms.TextBox
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents txt_bairro As System.Windows.Forms.TextBox
    Friend WithEvents txt_complemento As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents txt_endereco As System.Windows.Forms.TextBox
    Friend WithEvents txt_nome As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_gravar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents grp_contabil As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
End Class
