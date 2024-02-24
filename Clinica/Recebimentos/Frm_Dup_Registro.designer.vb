<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Dup_Registro
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
        Me.Grp_duplicatas = New System.Windows.Forms.GroupBox
        Me.txt_codPart = New System.Windows.Forms.TextBox
        Me.txt_documento = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_historico = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Cbo_Banco = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Cbo_tipo = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbl_fatura = New System.Windows.Forms.Label
        Me.txt_outros = New System.Windows.Forms.TextBox
        Me.txt_protesto = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_situacao = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_desconto = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_juros = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Msk_dtpaga = New System.Windows.Forms.MaskedTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Msk_vencto = New System.Windows.Forms.MaskedTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_fatura = New System.Windows.Forms.TextBox
        Me.msk_emissao = New System.Windows.Forms.MaskedTextBox
        Me.txt_valor = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Btn_salvar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.Grp_duplicatas.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grp_duplicatas
        '
        Me.Grp_duplicatas.Controls.Add(Me.txt_codPart)
        Me.Grp_duplicatas.Controls.Add(Me.txt_documento)
        Me.Grp_duplicatas.Controls.Add(Me.Label1)
        Me.Grp_duplicatas.Controls.Add(Me.txt_historico)
        Me.Grp_duplicatas.Controls.Add(Me.Label6)
        Me.Grp_duplicatas.Controls.Add(Me.Cbo_Banco)
        Me.Grp_duplicatas.Controls.Add(Me.Label2)
        Me.Grp_duplicatas.Controls.Add(Me.Cbo_tipo)
        Me.Grp_duplicatas.Controls.Add(Me.Label3)
        Me.Grp_duplicatas.Controls.Add(Me.lbl_fatura)
        Me.Grp_duplicatas.Controls.Add(Me.txt_outros)
        Me.Grp_duplicatas.Controls.Add(Me.txt_protesto)
        Me.Grp_duplicatas.Controls.Add(Me.Label8)
        Me.Grp_duplicatas.Controls.Add(Me.txt_situacao)
        Me.Grp_duplicatas.Controls.Add(Me.Label9)
        Me.Grp_duplicatas.Controls.Add(Me.txt_desconto)
        Me.Grp_duplicatas.Controls.Add(Me.Label10)
        Me.Grp_duplicatas.Controls.Add(Me.Label15)
        Me.Grp_duplicatas.Controls.Add(Me.txt_juros)
        Me.Grp_duplicatas.Controls.Add(Me.Label14)
        Me.Grp_duplicatas.Controls.Add(Me.Label11)
        Me.Grp_duplicatas.Controls.Add(Me.Label13)
        Me.Grp_duplicatas.Controls.Add(Me.Msk_dtpaga)
        Me.Grp_duplicatas.Controls.Add(Me.Label12)
        Me.Grp_duplicatas.Controls.Add(Me.txt_nomePart)
        Me.Grp_duplicatas.Controls.Add(Me.Label5)
        Me.Grp_duplicatas.Controls.Add(Me.Msk_vencto)
        Me.Grp_duplicatas.Controls.Add(Me.Label4)
        Me.Grp_duplicatas.Controls.Add(Me.txt_fatura)
        Me.Grp_duplicatas.Controls.Add(Me.msk_emissao)
        Me.Grp_duplicatas.Controls.Add(Me.txt_valor)
        Me.Grp_duplicatas.Location = New System.Drawing.Point(8, 12)
        Me.Grp_duplicatas.Name = "Grp_duplicatas"
        Me.Grp_duplicatas.Size = New System.Drawing.Size(647, 221)
        Me.Grp_duplicatas.TabIndex = 0
        Me.Grp_duplicatas.TabStop = False
        Me.Grp_duplicatas.Text = "Duplicatas"
        '
        'txt_codPart
        '
        Me.txt_codPart.Location = New System.Drawing.Point(80, 16)
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(58, 20)
        Me.txt_codPart.TabIndex = 1
        '
        'txt_documento
        '
        Me.txt_documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_documento.Location = New System.Drawing.Point(80, 48)
        Me.txt_documento.MaxLength = 10
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.Size = New System.Drawing.Size(100, 20)
        Me.txt_documento.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente :"
        '
        'txt_historico
        '
        Me.txt_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_historico.Location = New System.Drawing.Point(80, 185)
        Me.txt_historico.MaxLength = 60
        Me.txt_historico.Name = "txt_historico"
        Me.txt_historico.Size = New System.Drawing.Size(306, 20)
        Me.txt_historico.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Historico:"
        '
        'Cbo_Banco
        '
        Me.Cbo_Banco.FormattingEnabled = True
        Me.Cbo_Banco.Items.AddRange(New Object() {"000 - Nenhum", "001 - Banco do Brasil", "104 - Cef", "237 - Bradesco", "220 - BNB", "999 - Outros"})
        Me.Cbo_Banco.Location = New System.Drawing.Point(440, 117)
        Me.Cbo_Banco.Name = "Cbo_Banco"
        Me.Cbo_Banco.Size = New System.Drawing.Size(174, 21)
        Me.Cbo_Banco.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Documento:"
        '
        'Cbo_tipo
        '
        Me.Cbo_tipo.FormattingEnabled = True
        Me.Cbo_tipo.Items.AddRange(New Object() {"AV", "CH", "NP", "BL", "CT", "OT"})
        Me.Cbo_tipo.Location = New System.Drawing.Point(331, 116)
        Me.Cbo_tipo.Name = "Cbo_tipo"
        Me.Cbo_tipo.Size = New System.Drawing.Size(53, 21)
        Me.Cbo_tipo.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Valor:"
        '
        'lbl_fatura
        '
        Me.lbl_fatura.AutoSize = True
        Me.lbl_fatura.Location = New System.Drawing.Point(439, 20)
        Me.lbl_fatura.Name = "lbl_fatura"
        Me.lbl_fatura.Size = New System.Drawing.Size(51, 13)
        Me.lbl_fatura.TabIndex = 6
        Me.lbl_fatura.Text = "N.Fatura:"
        '
        'txt_outros
        '
        Me.txt_outros.Location = New System.Drawing.Point(284, 151)
        Me.txt_outros.MaxLength = 12
        Me.txt_outros.Name = "txt_outros"
        Me.txt_outros.Size = New System.Drawing.Size(100, 20)
        Me.txt_outros.TabIndex = 15
        Me.txt_outros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_protesto
        '
        Me.txt_protesto.Location = New System.Drawing.Point(80, 151)
        Me.txt_protesto.MaxLength = 12
        Me.txt_protesto.Name = "txt_protesto"
        Me.txt_protesto.Size = New System.Drawing.Size(100, 20)
        Me.txt_protesto.TabIndex = 14
        Me.txt_protesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(208, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Data Emissão:"
        '
        'txt_situacao
        '
        Me.txt_situacao.Location = New System.Drawing.Point(244, 115)
        Me.txt_situacao.MaxLength = 1
        Me.txt_situacao.Name = "txt_situacao"
        Me.txt_situacao.ReadOnly = True
        Me.txt_situacao.Size = New System.Drawing.Size(39, 20)
        Me.txt_situacao.TabIndex = 11
        Me.txt_situacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(459, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Data Vencto:"
        '
        'txt_desconto
        '
        Me.txt_desconto.Location = New System.Drawing.Point(80, 115)
        Me.txt_desconto.MaxLength = 12
        Me.txt_desconto.Name = "txt_desconto"
        Me.txt_desconto.Size = New System.Drawing.Size(100, 20)
        Me.txt_desconto.TabIndex = 10
        Me.txt_desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(222, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Data Paga:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(237, 154)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Outros:"
        '
        'txt_juros
        '
        Me.txt_juros.Location = New System.Drawing.Point(514, 83)
        Me.txt_juros.MaxLength = 12
        Me.txt_juros.Name = "txt_juros"
        Me.txt_juros.Size = New System.Drawing.Size(100, 20)
        Me.txt_juros.TabIndex = 9
        Me.txt_juros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(392, 120)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Banco:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(439, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Juros Pagos:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(297, 119)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Tipo:"
        '
        'Msk_dtpaga
        '
        Me.Msk_dtpaga.Location = New System.Drawing.Point(289, 80)
        Me.Msk_dtpaga.Mask = "00/00/0000"
        Me.Msk_dtpaga.Name = "Msk_dtpaga"
        Me.Msk_dtpaga.Size = New System.Drawing.Size(74, 20)
        Me.Msk_dtpaga.TabIndex = 8
        Me.Msk_dtpaga.ValidatingType = GetType(Date)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(186, 119)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Situação:"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Location = New System.Drawing.Point(144, 16)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(289, 20)
        Me.txt_nomePart.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Protesto:"
        '
        'Msk_vencto
        '
        Me.Msk_vencto.Location = New System.Drawing.Point(535, 49)
        Me.Msk_vencto.Mask = "00/00/0000"
        Me.Msk_vencto.Name = "Msk_vencto"
        Me.Msk_vencto.Size = New System.Drawing.Size(79, 20)
        Me.Msk_vencto.TabIndex = 6
        Me.Msk_vencto.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Desconto:"
        '
        'txt_fatura
        '
        Me.txt_fatura.Location = New System.Drawing.Point(496, 17)
        Me.txt_fatura.MaxLength = 9
        Me.txt_fatura.Name = "txt_fatura"
        Me.txt_fatura.Size = New System.Drawing.Size(118, 20)
        Me.txt_fatura.TabIndex = 3
        '
        'msk_emissao
        '
        Me.msk_emissao.Location = New System.Drawing.Point(289, 48)
        Me.msk_emissao.Mask = "00/00/0000"
        Me.msk_emissao.Name = "msk_emissao"
        Me.msk_emissao.Size = New System.Drawing.Size(74, 20)
        Me.msk_emissao.TabIndex = 5
        Me.msk_emissao.ValidatingType = GetType(Date)
        '
        'txt_valor
        '
        Me.txt_valor.Location = New System.Drawing.Point(80, 80)
        Me.txt_valor.MaxLength = 12
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.Size = New System.Drawing.Size(100, 20)
        Me.txt_valor.TabIndex = 7
        Me.txt_valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Btn_salvar)
        Me.GroupBox2.Location = New System.Drawing.Point(566, 239)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(87, 57)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        '
        'Btn_salvar
        '
        Me.Btn_salvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ' Me.Btn_salvar.Image = Global.Genov.My.Resources.Resources.Load
        Me.Btn_salvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_salvar.Location = New System.Drawing.Point(7, 9)
        Me.Btn_salvar.Name = "Btn_salvar"
        Me.Btn_salvar.Size = New System.Drawing.Size(74, 45)
        Me.Btn_salvar.TabIndex = 18
        Me.Btn_salvar.Text = "&Salvar"
        Me.Btn_salvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_salvar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 240)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 56)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(12, 22)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(23, 17)
        Me.lbl_mensagem.TabIndex = 20
        Me.lbl_mensagem.Text = "   "
        '
        'Frm_Dup_Registro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 312)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Grp_duplicatas)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_Dup_Registro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Documentos a Receber"
        Me.Grp_duplicatas.ResumeLayout(False)
        Me.Grp_duplicatas.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grp_duplicatas As System.Windows.Forms.GroupBox
    Friend WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_historico As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Banco As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_fatura As System.Windows.Forms.Label
    Friend WithEvents txt_outros As System.Windows.Forms.TextBox
    Friend WithEvents txt_protesto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_situacao As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_desconto As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_juros As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Msk_dtpaga As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Msk_vencto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_fatura As System.Windows.Forms.TextBox
    Friend WithEvents msk_emissao As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_valor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_salvar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
End Class
