<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CadRecebimentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CadRecebimentos))
        Me.Grp_duplicatas = New System.Windows.Forms.GroupBox
        Me.txt_qtdeParcelas = New System.Windows.Forms.TextBox
        Me.lbl_parcelas = New System.Windows.Forms.Label
        Me.cbo_loja = New System.Windows.Forms.ComboBox
        Me.dtp_dtpaga = New System.Windows.Forms.DateTimePicker
        Me.dtp_emissao = New System.Windows.Forms.DateTimePicker
        Me.dtp_vencto = New System.Windows.Forms.DateTimePicker
        Me.txt_codPart = New System.Windows.Forms.TextBox
        Me.txt_documento = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
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
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_fatura = New System.Windows.Forms.TextBox
        Me.txt_valor = New System.Windows.Forms.TextBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Btn_salvar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Grp_duplicatas.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grp_duplicatas
        '
        Me.Grp_duplicatas.Controls.Add(Me.txt_qtdeParcelas)
        Me.Grp_duplicatas.Controls.Add(Me.lbl_parcelas)
        Me.Grp_duplicatas.Controls.Add(Me.cbo_loja)
        Me.Grp_duplicatas.Controls.Add(Me.dtp_dtpaga)
        Me.Grp_duplicatas.Controls.Add(Me.dtp_emissao)
        Me.Grp_duplicatas.Controls.Add(Me.dtp_vencto)
        Me.Grp_duplicatas.Controls.Add(Me.txt_codPart)
        Me.Grp_duplicatas.Controls.Add(Me.txt_documento)
        Me.Grp_duplicatas.Controls.Add(Me.Label16)
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
        Me.Grp_duplicatas.Controls.Add(Me.Label12)
        Me.Grp_duplicatas.Controls.Add(Me.txt_nomePart)
        Me.Grp_duplicatas.Controls.Add(Me.Label5)
        Me.Grp_duplicatas.Controls.Add(Me.Label4)
        Me.Grp_duplicatas.Controls.Add(Me.txt_fatura)
        Me.Grp_duplicatas.Controls.Add(Me.txt_valor)
        Me.Grp_duplicatas.Location = New System.Drawing.Point(9, 86)
        Me.Grp_duplicatas.Name = "Grp_duplicatas"
        Me.Grp_duplicatas.Size = New System.Drawing.Size(711, 261)
        Me.Grp_duplicatas.TabIndex = 40
        Me.Grp_duplicatas.TabStop = False
        Me.Grp_duplicatas.Text = "Duplicatas"
        '
        'txt_qtdeParcelas
        '
        Me.txt_qtdeParcelas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtdeParcelas.Location = New System.Drawing.Point(666, 24)
        Me.txt_qtdeParcelas.MaxLength = 2
        Me.txt_qtdeParcelas.Name = "txt_qtdeParcelas"
        Me.txt_qtdeParcelas.Size = New System.Drawing.Size(32, 20)
        Me.txt_qtdeParcelas.TabIndex = 2
        Me.txt_qtdeParcelas.Text = "1"
        Me.txt_qtdeParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_parcelas
        '
        Me.lbl_parcelas.AutoSize = True
        Me.lbl_parcelas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_parcelas.Location = New System.Drawing.Point(560, 24)
        Me.lbl_parcelas.Name = "lbl_parcelas"
        Me.lbl_parcelas.Size = New System.Drawing.Size(100, 16)
        Me.lbl_parcelas.TabIndex = 34
        Me.lbl_parcelas.Text = "Qtde. Parcelas:"
        '
        'cbo_loja
        '
        Me.cbo_loja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_loja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_loja.FormattingEnabled = True
        Me.cbo_loja.Location = New System.Drawing.Point(80, 21)
        Me.cbo_loja.Name = "cbo_loja"
        Me.cbo_loja.Size = New System.Drawing.Size(399, 23)
        Me.cbo_loja.TabIndex = 1
        '
        'dtp_dtpaga
        '
        Me.dtp_dtpaga.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dtpaga.Location = New System.Drawing.Point(385, 117)
        Me.dtp_dtpaga.Name = "dtp_dtpaga"
        Me.dtp_dtpaga.Size = New System.Drawing.Size(94, 20)
        Me.dtp_dtpaga.TabIndex = 17
        '
        'dtp_emissao
        '
        Me.dtp_emissao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_emissao.Location = New System.Drawing.Point(385, 85)
        Me.dtp_emissao.Name = "dtp_emissao"
        Me.dtp_emissao.Size = New System.Drawing.Size(94, 20)
        Me.dtp_emissao.TabIndex = 11
        '
        'dtp_vencto
        '
        Me.dtp_vencto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_vencto.Location = New System.Drawing.Point(604, 85)
        Me.dtp_vencto.Name = "dtp_vencto"
        Me.dtp_vencto.Size = New System.Drawing.Size(94, 20)
        Me.dtp_vencto.TabIndex = 13
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Location = New System.Drawing.Point(80, 53)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(63, 20)
        Me.txt_codPart.TabIndex = 3
        '
        'txt_documento
        '
        Me.txt_documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_documento.Location = New System.Drawing.Point(96, 86)
        Me.txt_documento.MaxLength = 10
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.Size = New System.Drawing.Size(100, 20)
        Me.txt_documento.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 16)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Loja :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente :"
        '
        'txt_historico
        '
        Me.txt_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_historico.Location = New System.Drawing.Point(96, 226)
        Me.txt_historico.MaxLength = 60
        Me.txt_historico.Name = "txt_historico"
        Me.txt_historico.Size = New System.Drawing.Size(306, 20)
        Me.txt_historico.TabIndex = 33
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 227)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Historico:"
        '
        'Cbo_Banco
        '
        Me.Cbo_Banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_Banco.FormattingEnabled = True
        Me.Cbo_Banco.Location = New System.Drawing.Point(554, 151)
        Me.Cbo_Banco.Name = "Cbo_Banco"
        Me.Cbo_Banco.Size = New System.Drawing.Size(144, 21)
        Me.Cbo_Banco.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Documento:"
        '
        'Cbo_tipo
        '
        Me.Cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_tipo.FormattingEnabled = True
        Me.Cbo_tipo.Items.AddRange(New Object() {"AV - A Vista", "CH - Cheque", "BL - Boleto", "NP - N. Promissoria", "CR - Carnê", "CT - Cartão"})
        Me.Cbo_tipo.Location = New System.Drawing.Point(379, 151)
        Me.Cbo_tipo.Name = "Cbo_tipo"
        Me.Cbo_tipo.Size = New System.Drawing.Size(100, 21)
        Me.Cbo_tipo.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Valor:"
        '
        'lbl_fatura
        '
        Me.lbl_fatura.AutoSize = True
        Me.lbl_fatura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fatura.Location = New System.Drawing.Point(498, 56)
        Me.lbl_fatura.Name = "lbl_fatura"
        Me.lbl_fatura.Size = New System.Drawing.Size(62, 16)
        Me.lbl_fatura.TabIndex = 6
        Me.lbl_fatura.Text = "N.Fatura:"
        '
        'txt_outros
        '
        Me.txt_outros.Location = New System.Drawing.Point(293, 190)
        Me.txt_outros.MaxLength = 12
        Me.txt_outros.Name = "txt_outros"
        Me.txt_outros.Size = New System.Drawing.Size(109, 20)
        Me.txt_outros.TabIndex = 31
        Me.txt_outros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_protesto
        '
        Me.txt_protesto.Location = New System.Drawing.Point(96, 190)
        Me.txt_protesto.MaxLength = 12
        Me.txt_protesto.Name = "txt_protesto"
        Me.txt_protesto.Size = New System.Drawing.Size(100, 20)
        Me.txt_protesto.TabIndex = 29
        Me.txt_protesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(264, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Data Emissão:"
        '
        'txt_situacao
        '
        Me.txt_situacao.BackColor = System.Drawing.SystemColors.Info
        Me.txt_situacao.Location = New System.Drawing.Point(280, 152)
        Me.txt_situacao.MaxLength = 1
        Me.txt_situacao.Name = "txt_situacao"
        Me.txt_situacao.ReadOnly = True
        Me.txt_situacao.Size = New System.Drawing.Size(39, 20)
        Me.txt_situacao.TabIndex = 23
        Me.txt_situacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(498, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Data Vencto:"
        '
        'txt_desconto
        '
        Me.txt_desconto.BackColor = System.Drawing.SystemColors.Info
        Me.txt_desconto.Location = New System.Drawing.Point(96, 152)
        Me.txt_desconto.MaxLength = 12
        Me.txt_desconto.Name = "txt_desconto"
        Me.txt_desconto.ReadOnly = True
        Me.txt_desconto.Size = New System.Drawing.Size(100, 20)
        Me.txt_desconto.TabIndex = 21
        Me.txt_desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(264, 121)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Data Paga:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(237, 191)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 16)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Outros:"
        '
        'txt_juros
        '
        Me.txt_juros.BackColor = System.Drawing.SystemColors.Info
        Me.txt_juros.Location = New System.Drawing.Point(598, 118)
        Me.txt_juros.MaxLength = 12
        Me.txt_juros.Name = "txt_juros"
        Me.txt_juros.ReadOnly = True
        Me.txt_juros.Size = New System.Drawing.Size(100, 20)
        Me.txt_juros.TabIndex = 19
        Me.txt_juros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(498, 153)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 16)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Banco:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(498, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 16)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Juros Pagos:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(334, 153)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 16)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Tipo:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(210, 153)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Situação:"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Location = New System.Drawing.Point(150, 53)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(329, 20)
        Me.txt_nomePart.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 191)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Protesto:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Desconto:"
        '
        'txt_fatura
        '
        Me.txt_fatura.Location = New System.Drawing.Point(580, 53)
        Me.txt_fatura.MaxLength = 9
        Me.txt_fatura.Name = "txt_fatura"
        Me.txt_fatura.Size = New System.Drawing.Size(118, 20)
        Me.txt_fatura.TabIndex = 7
        '
        'txt_valor
        '
        Me.txt_valor.Location = New System.Drawing.Point(96, 118)
        Me.txt_valor.MaxLength = 12
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.Size = New System.Drawing.Size(100, 20)
        Me.txt_valor.TabIndex = 15
        Me.txt_valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 354)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(618, 56)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mensagem"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-5, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(743, 82)
        Me.Panel1.TabIndex = 43
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(543, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 24)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "MetroSys"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(256, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(218, 63)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Btn_salvar
        '
        Me.Btn_salvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_salvar.Image = Global.MetroSys.My.Resources.Resources.Load
        Me.Btn_salvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_salvar.Location = New System.Drawing.Point(7, 9)
        Me.Btn_salvar.Name = "Btn_salvar"
        Me.Btn_salvar.Size = New System.Drawing.Size(74, 45)
        Me.Btn_salvar.TabIndex = 37
        Me.Btn_salvar.Text = "&Salvar"
        Me.Btn_salvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_salvar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Btn_salvar)
        Me.GroupBox2.Location = New System.Drawing.Point(633, 353)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(87, 57)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        '
        'Frm_CadRecebimentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 419)
        Me.Controls.Add(Me.Grp_duplicatas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_CadRecebimentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Recebimentos"
        Me.Grp_duplicatas.ResumeLayout(False)
        Me.Grp_duplicatas.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grp_duplicatas As System.Windows.Forms.GroupBox
    Public WithEvents txt_qtdeParcelas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_parcelas As System.Windows.Forms.Label
    Public WithEvents cbo_loja As System.Windows.Forms.ComboBox
    Public WithEvents dtp_dtpaga As System.Windows.Forms.DateTimePicker
    Public WithEvents dtp_emissao As System.Windows.Forms.DateTimePicker
    Public WithEvents dtp_vencto As System.Windows.Forms.DateTimePicker
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Public WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_historico As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Cbo_Banco As System.Windows.Forms.ComboBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Cbo_tipo As System.Windows.Forms.ComboBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents lbl_fatura As System.Windows.Forms.Label
    Friend WithEvents txt_outros As System.Windows.Forms.TextBox
    Friend WithEvents txt_protesto As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents txt_situacao As System.Windows.Forms.TextBox
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents txt_desconto As System.Windows.Forms.TextBox
    Public WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents txt_juros As System.Windows.Forms.TextBox
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents txt_fatura As System.Windows.Forms.TextBox
    Public WithEvents txt_valor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents Btn_salvar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
