<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_NFEAutorizanota
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_NFEAutorizanota))
        Me.cbo_tiponfe = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_codPart = New System.Windows.Forms.TextBox
        Me.cbo_transportador = New System.Windows.Forms.ComboBox
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chk_pauta = New System.Windows.Forms.CheckBox
        Me.dtp_dtSaida = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.lbl_emitente = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cbo_estabelecimento = New System.Windows.Forms.ComboBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.lbl_qtdeItens = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lbl_totalNota = New System.Windows.Forms.Label
        Me.txt_pedido = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbo_nfeCfop = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_placa = New System.Windows.Forms.TextBox
        Me.lbl_ambiente = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lbl_tipoemissao = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btn_nfe = New System.Windows.Forms.Button
        Me.cbo_placa = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.rtb_mensagem = New System.Windows.Forms.RichTextBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.lbl_numeroNota1pp = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbo_tiponfe
        '
        Me.cbo_tiponfe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tiponfe.FormattingEnabled = True
        Me.cbo_tiponfe.Items.AddRange(New Object() {"Saidas Normal", "Transferência"})
        Me.cbo_tiponfe.Location = New System.Drawing.Point(88, 58)
        Me.cbo_tiponfe.Name = "cbo_tiponfe"
        Me.cbo_tiponfe.Size = New System.Drawing.Size(112, 21)
        Me.cbo_tiponfe.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo de NFE:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "DTSaida:"
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Location = New System.Drawing.Point(65, 87)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(72, 20)
        Me.txt_codPart.TabIndex = 4
        Me.txt_codPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbo_transportador
        '
        Me.cbo_transportador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_transportador.FormattingEnabled = True
        Me.cbo_transportador.Items.AddRange(New Object() {"Emitente", "Destinatário", "Terceiros", "Sem Frete"})
        Me.cbo_transportador.Location = New System.Drawing.Point(88, 16)
        Me.cbo_transportador.Name = "cbo_transportador"
        Me.cbo_transportador.Size = New System.Drawing.Size(121, 21)
        Me.cbo_transportador.TabIndex = 9
        '
        'txt_nomePart
        '
        Me.txt_nomePart.Location = New System.Drawing.Point(150, 87)
        Me.txt_nomePart.MaxLength = 50
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(356, 20)
        Me.txt_nomePart.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_numeroNota1pp)
        Me.GroupBox1.Controls.Add(Me.chk_pauta)
        Me.GroupBox1.Controls.Add(Me.dtp_dtSaida)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lbl_emitente)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cbo_estabelecimento)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.txt_pedido)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbo_nfeCfop)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_codPart)
        Me.GroupBox1.Controls.Add(Me.cbo_tiponfe)
        Me.GroupBox1.Controls.Add(Me.txt_nomePart)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(634, 156)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados do Destinatário"
        '
        'chk_pauta
        '
        Me.chk_pauta.AutoSize = True
        Me.chk_pauta.Checked = True
        Me.chk_pauta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_pauta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_pauta.Location = New System.Drawing.Point(443, 59)
        Me.chk_pauta.Name = "chk_pauta"
        Me.chk_pauta.Size = New System.Drawing.Size(63, 19)
        Me.chk_pauta.TabIndex = 19
        Me.chk_pauta.Text = "Pauta"
        Me.chk_pauta.UseVisualStyleBackColor = True
        '
        'dtp_dtSaida
        '
        Me.dtp_dtSaida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dtSaida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dtSaida.Location = New System.Drawing.Point(71, 119)
        Me.dtp_dtSaida.Name = "dtp_dtSaida"
        Me.dtp_dtSaida.Size = New System.Drawing.Size(94, 21)
        Me.dtp_dtSaida.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(285, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "-"
        '
        'lbl_emitente
        '
        Me.lbl_emitente.AutoSize = True
        Me.lbl_emitente.Location = New System.Drawing.Point(299, 29)
        Me.lbl_emitente.Name = "lbl_emitente"
        Me.lbl_emitente.Size = New System.Drawing.Size(48, 13)
        Me.lbl_emitente.TabIndex = 17
        Me.lbl_emitente.Text = "Emitente"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Empresa:"
        '
        'cbo_estabelecimento
        '
        Me.cbo_estabelecimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_estabelecimento.FormattingEnabled = True
        Me.cbo_estabelecimento.Location = New System.Drawing.Point(65, 26)
        Me.cbo_estabelecimento.Name = "cbo_estabelecimento"
        Me.cbo_estabelecimento.Size = New System.Drawing.Size(214, 21)
        Me.cbo_estabelecimento.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.lbl_qtdeItens)
        Me.GroupBox6.Location = New System.Drawing.Point(520, 87)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(107, 43)
        Me.GroupBox6.TabIndex = 14
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Itens"
        '
        'lbl_qtdeItens
        '
        Me.lbl_qtdeItens.AutoSize = True
        Me.lbl_qtdeItens.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_qtdeItens.Location = New System.Drawing.Point(30, 16)
        Me.lbl_qtdeItens.Name = "lbl_qtdeItens"
        Me.lbl_qtdeItens.Size = New System.Drawing.Size(15, 15)
        Me.lbl_qtdeItens.TabIndex = 0
        Me.lbl_qtdeItens.Text = "0"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lbl_totalNota)
        Me.GroupBox5.Location = New System.Drawing.Point(515, 20)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(112, 55)
        Me.GroupBox5.TabIndex = 13
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Totais R$"
        '
        'lbl_totalNota
        '
        Me.lbl_totalNota.AutoSize = True
        Me.lbl_totalNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_totalNota.ForeColor = System.Drawing.Color.Red
        Me.lbl_totalNota.Location = New System.Drawing.Point(16, 23)
        Me.lbl_totalNota.Name = "lbl_totalNota"
        Me.lbl_totalNota.Size = New System.Drawing.Size(35, 15)
        Me.lbl_totalNota.TabIndex = 0
        Me.lbl_totalNota.Text = "0,00"
        '
        'txt_pedido
        '
        Me.txt_pedido.Location = New System.Drawing.Point(318, 59)
        Me.txt_pedido.MaxLength = 10
        Me.txt_pedido.Name = "txt_pedido"
        Me.txt_pedido.Size = New System.Drawing.Size(89, 20)
        Me.txt_pedido.TabIndex = 3
        Me.txt_pedido.Text = "  "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(226, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Pedido/Docum:"
        '
        'cbo_nfeCfop
        '
        Me.cbo_nfeCfop.AutoCompleteCustomSource.AddRange(New String() {"5.101 - VENDA DE PRODUCAO DO ESTAB.                                 ", "5.102 - VENDA DE MERC. ADQU. OU RECEB. DE TERC.                     ", "5.103 - VENDA DE PRODUCAO DO ESTAB., EFETUADA FORA DO ESTAB.        ", "5.104 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., EFETUADA FORA DO ES", "5.105 - VENDA DE PRODUCAO DO ESTAB. QUE NAO DEVA POR ELE TRANSITAR  ", "5.106 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., QUE NAO DEVA POR EL", "5.109 - VENDA DE PRODUCAO DO ESTAB., DESTINADA A ZONA FRANCA DE MANA", "5.110 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., DESTINADA A ZONA FR", "5.111 - VENDA DE PRODUCAO DO ESTAB. REMETIDA ANTER. EM CONSIG. INDUS", "5.112 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. REMETIDA ANTER. EM C", "5.113 - VENDA DE PRODUCAO DO ESTAB. REMETIDA ANTER. EM CONSIG. MERCA", "5.114 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. REMETIDA ANTER. EM C", "5.115 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., RECEB. ANTER. EM CO", "5.116 - VENDA DE PRODUCAO DO ESTAB. ORIG. DE ENCOMENDA P/ ENTREGA FU", "5.117 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., ORIG. DE ENCOMENDA ", "5.118 - VENDA DE PRODUCAO DO ESTAB. ENTREGUE AO DESTI. POR CONTA E O", "5.119 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. ENTREGUE AO DESTI. P", "5.120 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. ENTREGUE AO DESTI. P", "5.122 - VENDA DE PRODUCAO DO ESTAB. REMETIDA P/ INDUSTRIALIZ., POR C", "5.123 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. REMETIDA P/ INDUSTRI", "5.124 - INDUSTRIALIZ. EFETUADA P/ OUTRA EMPRESA                     ", "5.125 - INDUSTRIALIZ. EFETUADA P/ OUTRA EMPRESA QUANDO A MERC. RECEB", "5.151 - TRANSF. DE PRODUCAO DO ESTAB.                               ", "5.152 - TRANSF. DE MERC. ADQU. OU RECEB. DE TERC.                   ", "5.153 - TRANSF. DE ENERG. ELETR.                                    ", "5.155 - TRANSF. DE PRODUCAO DO ESTAB., QUE NAO DEVA POR ELE TRANSITA", "5.156 - TRANSF. DE MERC. ADQU. OU RECEB. DE TERC., QUE NAO DEVA POR ", "5.201 - DEVOL. DE COMPRA P/ INDUSTRIALIZ.                           ", "5.202 - DEVOL. DE COMPRA P/ COMERC.                                 ", "5.205 - ANULACAO DE VALOR RELATIVO A AQUIS. DE SERV. DE COMUN.      ", "5.206 - ANULACAO DE VALOR RELATIVO A AQUIS. DE SERV. DE TRANSP.     ", "5.207 - ANULACAO DE VALOR RELATIVO A COMPRA DE ENERG. ELETR.        ", "5.208 - DEVOL. DE MERC. RECEB. EM TRANSF. P/ INDUSTRIALIZ.          ", "5.209 - DEVOL. DE MERC. RECEB. EM TRANSF. P/ COMERC.                ", "5.210 - DEVOL. DE COMPRA P/ UTILIZ. NA PREST. DE SERV.              ", "5.251 - VENDA DE ENERG. ELETR. P/ DISTRIB. OU COMERC.               ", "5.252 - VENDA DE ENERG. ELETR. P/ ESTAB. INDUSTRIAL                 ", "5.253 - VENDA DE ENERG. ELETR. P/ ESTAB. COMERCIAL                  ", "5.254 - VENDA DE ENERG. ELETR. P/ ESTAB. PREST. DE SERV. DE TRANSP. ", "5.255 - VENDA DE ENERG. ELETR. P/ ESTAB. PREST. DE SERV. DE COMUN.  ", "5.256 - VENDA DE ENERG. ELETR. P/ ESTAB. DE PRODUTOR RURAL          ", "5.257 - VENDA DE ENERG. ELETR. P/ CONSUMO POR DEMANDA CONTRATADA    ", "5.258 - VENDA DE ENERG. ELETR. A NAO CONTRIBUINTE                   ", "5.301 - PREST. DE SERV. DE COMUN. P/ EXEC. DE SERV. DA MESMA NATUREZ", "5.302 - PREST. DE SERV. DE COMUN. A ESTAB. INDUSTRIAL               ", "5.303 - PREST. DE SERV. DE COMUN. A ESTAB. COMERCIAL                ", "5.304 - PREST. DE SERV. DE COMUN. A ESTAB. DE PREST. DE SERV. DE TRA", "5.305 - PREST. DE SERV. DE COMUN. A ESTAB. DE GERADORA OU DE DISTRIB", "5.306 - PREST. DE SERV. DE COMUN. A ESTAB. DE PRODUTOR RURAL        ", "5.307 - PREST. DE SERV. DE COMUN. A NAO CONTRIBUINTE                ", "5.351 - PREST. DE SERV. DE TRANSP. P/ EXEC. DE SERV. DA MESMA NATURE", "5.352 - PREST. DE SERV. DE TRANSP. A ESTAB. INDUSTRIAL              ", "5.353 - PREST. DE SERV. DE TRANSP. A ESTAB. COMERCIAL               ", "5.354 - PREST. DE SERV. DE TRANSP. A ESTAB. DE PREST. DE SERV. DE CO", "5.355 - PREST. DE SERV. DE TRANSP. A ESTAB. DE GERADORA OU DE DISTRI", "5.356 - PREST. DE SERV. DE TRANSP. A ESTAB. DE PRODUTOR RURAL       ", "5.357 - PREST. DE SERV. DE TRANSP. A NAO CONTRIBUINTE               ", "5.359 - PREST. DE SERV. DE TRANSP. A CONTRIBUINTE OU A NAO CONTRIBUI", "5.401 - VENDA DE PRODUCAO DO ESTAB. EM OPER. COM PRODUTO SUJEITO AO ", "5.402 - VENDA DE PRODUCAO DO ESTAB. DE PRODUTO SUJEITO AO REGIME DE ", "5.403 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. EM OPER. COM MERC. S", "5.405 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. EM OPER. COM MERC. S", "5.408 - TRANSF. DE PRODUCAO DO ESTAB. EM OPER. COM PRODUTO SUJEITO A", "5.409 - TRANSF. DE MERC. ADQU. OU RECEB. DE TERC. EM OPER. COM MERC.", "5.410 - DEVOL. DE COMPRA P/ INDUSTRIALIZ. EM OPER. COM MERC. SUJ. AO", "5.411 - DEVOL. DE COMPRA P/ COMERC. EM OPER. COM MERC. SUJ. AO REGIM", "5.412 - DEVOL. DE BEM DO ATIVO IMOBILIZADO, EM OPER. COM MERC. SUJ. ", "5.413 - DEVOL. DE MERC. DESTINADA AO USO OU CONSUMO, EM OPER. COM ME", "5.414 - REMESSA DE PRODUCAO DO ESTAB. P/ VENDA FORA DO ESTAB. EM OPE", "5.415 - REMESSA DE MERC. ADQU. OU RECEB. DE TERC. P/ VENDA FORA DO E", "5.451 - REMESSA DE ANIMAL E DE INSUMO P/ ESTAB. PRODUTOR            ", "5.501 - REMESSA DE PRODUCAO DO ESTAB., COM FIM ESPECIF. DE EXPORT.  ", "5.502 - REMESSA DE MERC. ADQU. OU RECEB. DE TERC., COM FIM ESPECIF. ", "5.503 - DEVOL. DE MERC. RECEB. COM FIM ESPECIF. DE EXPORT.          ", "5.551 - VENDA DE BEM DO ATIVO IMOBILIZADO                           ", "5.552 - TRANSF. DE BEM DO ATIVO IMOBILIZADO                         ", "5.553 - DEVOL. DE COMPRA DE BEM P/ O ATIVO IMOBILIZADO              ", "5.554 - REMESSA DE BEM DO ATIVO IMOBILIZADO P/ USO FORA DO ESTAB.   ", "5.555 - DEVOL. DE BEM DO ATIVO IMOBILIZADO DE TERCEIRO, RECEB. P/ US", "5.556 - DEVOL. DE COMPRA DE MATERIAL DE USO OU CONSUMO              ", "5.557 - TRANSF. DE MATERIAL DE USO OU CONSUMO                       ", "5.601 - TRANSF. DE CREDITO DE ICMS ACUMULADO                        ", "5.602 - TRANSF. DE SALDO CREDOR DE ICMS P/ OUTRO ESTAB. DA MESMA EMP", "5.603 - RESSARCIMENTO DE ICMS RETIDO POR SUBST. TRIB.               ", "5.605 - TRANSF. DE SALDO DEVEDOR DE ICMS DE OUTRO ESTAB. DA MESMA EM", "5.650 - SAID. DE COMBUSTIVEIS, DERIVADOS OU NAO DE PETROLEO E LUBRIF", "5.651 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB. DESTINAD", "5.652 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB. DESTINAD", "5.653 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB. DESTINAD", "5.654 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. DEST", "5.655 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. DEST", "5.656 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. DEST", "5.657 - REMESSA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. P/", "5.658 - TRANSF. DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB.       ", "5.659 - TRANSF. DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERCEIRO", "5.660 - DEVOL. DE COMPRA DE COMBUST. OU LUBRIFI. ADQUI. P/ INDUSTRIA", "5.661 - DEVOL. DE COMPRA DE COMBUST. OU LUBRIFI. ADQUI. P/ COMERCIAL", "5.662 - DEVOL. DE COMPRA DE COMBUST. OU LUBRIFI. ADQUI. POR CONSUMID", "5.663 - REMESSA P/ ARMAZENAGEM DE COMBUST. OU LUBRIFI.              ", "5.664 - RETORNO DE COMBUST. OU LUBRIFI. RECEB. P/ ARMAZENAGEM       ", "5.665 - RETORNO SIMBOLICO DE COMBUST. OU LUBRIFI. RECEB. P/ ARMAZENA", "5.666 - REMESSA POR CONTA E ORDEM DE TERC. DE COMBUST. OU LUBRIFI. R", "5.901 - REMESSA P/ INDUSTRIALIZ. POR ENCOMENDA                      ", "5.902 - RETORNO DE MERC. UTILIZADA NA INDUSTRIALIZ. POR ENCOMENDA   ", "5.903 - RETORNO DE MERC. RECEB. P/ INDUSTRIALIZ. E NAO APLICADA NO R", "5.904 - REMESSA P/ VENDA FORA DO ESTAB.                             ", "5.905 - REMESSA P/ DEPOSITO FECHADO OU ARMAZEM GERAL                ", "5.906 - RETORNO DE MERC. DEPOSITADA EM DEPOSITO FECHADO OU ARMAZEM G", "5.907 - RETORNO SIMBOLICO DE MERC. DEPOSITADA EM DEPOSITO FECHADO OU", "5.908 - REMESSA DE BEM POR CONTA DE CONTRATO DE COMODATO            ", "5.909 - RETORNO DE BEM RECEB. POR CONTA DE CONTRATO DE COMODATO     ", "5.910 - REMESSA EM BONIF., DOACAO OU BRINDE                         ", "5.911 - REMESSA DE AMOSTRA GRATIS                                   ", "5.912 - REMESSA DE MERC. OU BEM P/ DEMONSTRACAO                     ", "5.913 - RETORNO DE MERC. OU BEM RECEB. P/ DEMONSTRACAO              ", "5.914 - REMESSA DE MERC. OU BEM P/ EXPOSICAO OU FEIRA               ", "5.915 - REMESSA DE MERC. OU BEM P/ CONSERTO OU REPARO               ", "5.916 - RETORNO DE MERC. OU BEM RECEB. P/ CONSERTO OU REPARO        ", "5.917 - REMESSA DE MERC. EM CONSIG. MERCANTIL OU INDUSTRIAL         ", "5.918 - DEVOL. DE MERC. RECEB. EM CONSIG. MERCANTIL OU INDUSTRIAL   ", "5.919 - DEVOL. SIMBOLICA DE MERC. VENDIDA OU UTILIZADA EM PROCESSO I", "5.920 - REMESSA DE VASILHAME OU SACARIA                             ", "5.921 - DEVOL. DE VASILHAME OU SACARIA                              ", "5.922 - LANCAMENTO EFETUADO A TITULO DE SIMPLES FATURAMENTO DECORREN", "5.923 - REMESSA DE MERC. POR CONTA E ORDEM DE TERC., EM VENDA A ORDE", "5.924 - REMESSA P/ INDUSTRIALIZ. POR CONTA E ORDEM DO ADQUIRENTE DA ", "5.925 - RETORNO DE MERC. RECEB. P/ INDUSTRIALIZ. POR CONTA E ORDEM D", "5.926 - LANCAMENTO EFETUADO A TITULO DE RECLASSIFICACAO DE MERC. DEC", "5.927 - LANCAMENTO EFETUADO A TITULO DE BAIXA DE ESTOQUE DECORRENTE ", "5.928 - LANCAMENTO EFETUADO A TITULO DE BAIXA DE ESTOQUE DECORRENTE ", "5.929 - LANCAMENTO EFETUADO EM DECORRENCIA DE EMISSAO DE DOCUMENTO F", "5.931 - LANCAMENTO EFETUADO EM DECORRENCIA DA RESPONSABILIDADE DE RE", "5.932 - PREST. DE SERV. DE TRANSP. INICIADA EM UNIDADE DA FEDERACAO ", "5.933 - PREST. DE SERV. TRIBUTADO PELO ISSQN                        ", "5.949 - OUTRA SAIDA DE MERC. OU PREST. DE SERV. NAO ESPECIFI.       ", "6.101 - VENDA DE PRODUCAO DO ESTAB.                                 ", "6.102 - VENDA DE MERC. ADQU. OU RECEB. DE TERC.                     ", "6.103 - VENDA DE PRODUCAO DO ESTAB., EFETUADA FORA DO ESTAB.        ", "6.104 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., EFETUADA FORA DO ES", "6.105 - VENDA DE PRODUCAO DO ESTAB. QUE NAO DEVA POR ELE TRANSITAR  ", "6.106 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., QUE NAO DEVA POR EL", "6.107 - VENDA DE PRODUCAO DO ESTAB., DESTINADA A NAO CONTRIBUINTE   ", "6.108 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., DESTINADA A NAO CON", "6.109 - VENDA DE PRODUCAO DO ESTAB., DESTINADA A ZONA FRANCA DE MANA", "6.110 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., DESTINADA A ZONA FR", "6.111 - VENDA DE PRODUCAO DO ESTAB. REMETIDA ANTER. EM CONSIG. INDUS", "6.112 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. REMETIDA ANTER. EM C", "6.113 - VENDA DE PRODUCAO DO ESTAB. REMETIDA ANTER. EM CONSIG. MERCA", "6.114 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. REMETIDA ANTER. EM C", "6.115 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., RECEB. ANTER. EM CO", "6.116 - VENDA DE PRODUCAO DO ESTAB. ORIG. DE ENCOMENDA P/ ENTREGA FU", "6.117 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., ORIG. DE ENCOMENDA ", "6.118 - VENDA DE PRODUCAO DO ESTAB. ENTREGUE AO DESTI. POR CONTA E O", "6.119 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. ENTREGUE AO DESTI. P", "6.120 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. ENTREGUE AO DESTI. P", "6.122 - VENDA DE PRODUCAO DO ESTAB. REMETIDA P/ INDUSTRIALIZ., POR C", "6.123 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. REMETIDA P/ INDUSTRI", "6.124 - INDUSTRIALIZ. EFETUADA P/ OUTRA EMPRESA                     ", "6.125 - INDUSTRIALIZ. EFETUADA P/ OUTRA EMPRESA QUANDO A MERC. RECEB", "6.151 - TRANSF. DE PRODUCAO DO ESTAB.                               ", "6.152 - TRANSF. DE MERC. ADQU. OU RECEB. DE TERC.                   ", "6.153 - TRANSF. DE ENERG. ELETR.                                    ", "6.155 - TRANSF. DE PRODUCAO DO ESTAB., QUE NAO DEVA POR ELE TRANSITA", "6.156 - TRANSF. DE MERC. ADQU. OU RECEB. DE TERC., QUE NAO DEVA POR ", "6.201 - DEVOL. DE COMPRA P/ INDUSTRIALIZ.                           ", "6.202 - DEVOL. DE COMPRA P/ COMERC.                                 ", "6.205 - ANULACAO DE VALOR RELATIVO A AQUIS. DE SERV. DE COMUN.      ", "6.206 - ANULACAO DE VALOR RELATIVO A AQUIS. DE SERV. DE TRANSP.     ", "6.207 - ANULACAO DE VALOR RELATIVO A COMPRA DE ENERG. ELETR.        ", "6.208 - DEVOL. DE MERC. RECEB. EM TRANSF. P/ INDUSTRIALIZ.          ", "6.209 - DEVOL. DE MERC. RECEB. EM TRANSF. P/ COMERC.                ", "6.210 - DEVOL. DE COMPRA P/ UTILIZ. NA PREST. DE SERV.              ", "6.251 - VENDA DE ENERG. ELETR. P/ DISTRIB. OU COMERC.               ", "6.252 - VENDA DE ENERG. ELETR. P/ ESTAB. INDUSTRIAL                 ", "6.253 - VENDA DE ENERG. ELETR. P/ ESTAB. COMERCIAL                  ", "6.254 - VENDA DE ENERG. ELETR. P/ ESTAB. PREST. DE SERV. DE TRANSP. ", "6.255 - VENDA DE ENERG. ELETR. P/ ESTAB. PREST. DE SERV. DE COMUN.  ", "6.256 - VENDA DE ENERG. ELETR. P/ ESTAB. DE PRODUTOR RURAL          ", "6.257 - VENDA DE ENERG. ELETR. P/ CONSUMO POR DEMANDA CONTRATADA    ", "6.258 - VENDA DE ENERG. ELETR. A NAO CONTRIBUINTE                   ", "6.301 - PREST. DE SERV. DE COMUN. P/ EXEC. DE SERV. DA MESMA NATUREZ", "6.302 - PREST. DE SERV. DE COMUN. A ESTAB. INDUSTRIAL               ", "6.303 - PREST. DE SERV. DE COMUN. A ESTAB. COMERCIAL                ", "6.304 - PREST. DE SERV. DE COMUN. A ESTAB. DE PREST. DE SERV. DE TRA", "6.305 - PREST. DE SERV. DE COMUN. A ESTAB. DE GERADORA OU DE DISTRIB", "6.306 - PREST. DE SERV. DE COMUN. A ESTAB. DE PRODUTOR RURAL        ", "6.307 - PREST. DE SERV. DE COMUN. A NAO CONTRIBUINTE                ", "6.351 - PREST. DE SERV. DE TRANSP. P/ EXEC. DE SERV. DA MESMA NATURE", "6.352 - PREST. DE SERV. DE TRANSP. A ESTAB. INDUSTRIAL              ", "6.353 - PREST. DE SERV. DE TRANSP. A ESTAB. COMERCIAL               ", "6.354 - PREST. DE SERV. DE TRANSP. A ESTAB. DE PREST. DE SERV. DE CO", "6.355 - PREST. DE SERV. DE TRANSP. A ESTAB. DE GERADORA OU DE DISTRI", "6.356 - PREST. DE SERV. DE TRANSP. A ESTAB. DE PRODUTOR RURAL       ", "6.357 - PREST. DE SERV. DE TRANSP. A NAO CONTRIBUINTE               ", "6.359 - PREST. DE SERV. DE TRANSP. A CONTRIBUINTE OU A NAO CONTRIBUI", "6.401 - VENDA DE PRODUCAO DO ESTAB. EM OPER. COM PRODUTO SUJEITO AO ", "6.402 - VENDA DE PRODUCAO DO ESTAB. DE PRODUTO SUJEITO AO REGIME DE ", "6.403 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. EM OPER. COM MERC. S", "6.404 - VENDA DE MERC. SUJ. AO REGIME DE SUBST. TRIB., CUJO IMPOSTO ", "6.408 - TRANSF. DE PRODUCAO DO ESTAB. EM OPER. COM PRODUTO SUJEITO A", "6.409 - TRANSF. DE MERC. ADQU. OU RECEB. DE TERC. EM OPER. COM MERC.", "6.410 - DEVOL. DE COMPRA P/ INDUSTRIALIZ. EM OPER. COM MERC. SUJ. AO", "6.411 - DEVOL. DE COMPRA P/ COMERC. EM OPER. COM MERC. SUJ. AO REGIM", "6.412 - DEVOL. DE BEM DO ATIVO IMOBILIZADO, EM OPER. COM MERC. SUJ. ", "6.413 - DEVOL. DE MERC. DESTINADA AO USO OU CONSUMO, EM OPER. COM ME", "6.414 - REMESSA DE PRODUCAO DO ESTAB. P/ VENDA FORA DO ESTAB. EM OPE", "6.415 - REMESSA DE MERC. ADQU. OU RECEB. DE TERC. P/ VENDA FORA DO E", "6.501 - REMESSA DE PRODUCAO DO ESTAB., COM FIM ESPECIF. DE EXPORT.  ", "6.502 - REMESSA DE MERC. ADQU. OU RECEB. DE TERC., COM FIM ESPECIF. ", "6.503 - DEVOL. DE MERC. RECEB. COM FIM ESPECIF. DE EXPORT.          ", "6.551 - VENDA DE BEM DO ATIVO IMOBILIZADO                           ", "6.552 - TRANSF. DE BEM DO ATIVO IMOBILIZADO                         ", "6.553 - DEVOL. DE COMPRA DE BEM P/ O ATIVO IMOBILIZADO              ", "6.554 - REMESSA DE BEM DO ATIVO IMOBILIZADO P/ USO FORA DO ESTAB.   ", "6.555 - DEVOL. DE BEM DO ATIVO IMOBILIZADO DE TERCEIRO, RECEB. P/ US", "6.556 - DEVOL. DE COMPRA DE MATERIAL DE USO OU CONSUMO              ", "6.557 - TRANSF. DE MATERIAL DE USO OU CONSUMO                       ", "6.603 - RESSARCIMENTO DE ICMS RETIDO POR SUBST. TRIB.               ", "6.650 - SAID. DE COMBUSTIVEIS, DERIVADOS OU NAO DE PETROLEO E LUBRIF", "6.651 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB. DESTINAD", "6.652 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB. DESTINAD", "6.653 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB. DESTINAD", "6.654 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. DEST", "6.655 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. DEST", "6.656 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. DEST", "6.657 - REMESSA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. P/", "6.658 - TRANSF. DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB.       ", "6.659 - TRANSF. DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERCEIRO", "6.660 - DEVOL. DE COMPRA DE COMBUST. OU LUBRIFI. ADQUI. P/ INDUSTRIA", "6.661 - DEVOL. DE COMPRA DE COMBUST. OU LUBRIFI. ADQUI. P/ COMERC.  ", "6.662 - DEVOL. DE COMPRA DE COMBUST. OU LUBRIFI. ADQUI. POR CONSUMID", "6.663 - REMESSA P/ ARMAZENAGEM DE COMBUST. OU LUBRIFI.              ", "6.664 - RETORNO DE COMBUST. OU LUBRIFI. RECEB. P/ ARMAZENAGEM       ", "6.665 - RETORNO SIMBOLICO DE COMBUST. OU LUBRIFI. RECEB. P/ ARMAZENA", "6.666 - REMESSA POR CONTA E ORDEM DE TERC. DE COMBUST. OU LUBRIFI. R", "6.901 - REMESSA P/ INDUSTRIALIZ. POR ENCOMENDA                      ", "6.902 - RETORNO DE MERC. UTILIZADA NA INDUSTRIALIZ. POR ENCOMENDA   ", "6.903 - RETORNO DE MERC. RECEB. P/ INDUSTRIALIZ. E NAO APLICADA NO R", "6.904 - REMESSA P/ VENDA FORA DO ESTAB.                             ", "6.905 - REMESSA P/ DEPOSITO FECHADO OU ARMAZEM GERAL                ", "6.906 - RETORNO DE MERC. DEPOSITADA EM DEPOSITO FECHADO OU ARMAZEM G", "6.907 - RETORNO SIMBOLICO DE MERC. DEPOSITADA EM DEPOSITO FECHADO OU", "6.908 - REMESSA DE BEM POR CONTA DE CONTRATO DE COMODATO            ", "6.909 - RETORNO DE BEM RECEB. POR CONTA DE CONTRATO DE COMODATO     ", "6.910 - REMESSA EM BONIF., DOACAO OU BRINDE                         ", "6.911 - REMESSA DE AMOSTRA GRATIS                                   ", "6.912 - REMESSA DE MERC. OU BEM P/ DEMONSTRACAO                     ", "6.913 - RETORNO DE MERC. OU BEM RECEB. P/ DEMONSTRACAO              ", "6.914 - REMESSA DE MERC. OU BEM P/ EXPOSICAO OU FEIRA               ", "6.915 - REMESSA DE MERC. OU BEM P/ CONSERTO OU REPARO               ", "6.916 - RETORNO DE MERC. OU BEM RECEB. P/ CONSERTO OU REPARO        ", "6.917 - REMESSA DE MERC. EM CONSIG. MERCANTIL OU INDUSTRIAL         ", "6.918 - DEVOL. DE MERC. RECEB. EM CONSIG. MERCANTIL OU INDUSTRIAL   ", "6.919 - DEVOL. SIMBOLICA DE MERC. VENDIDA OU UTILIZADA EM PROCESSO I", "6.920 - REMESSA DE VASILHAME OU SACARIA                             ", "6.921 - DEVOL. DE VASILHAME OU SACARIA                              ", "6.922 - LANCAMENTO EFETUADO A TITULO DE SIMPLES FATURAMENTO DECORREN", "6.923 - REMESSA DE MERC. POR CONTA E ORDEM DE TERC., EM VENDA A ORDE", "6.924 - REMESSA P/ INDUSTRIALIZ. POR CONTA E ORDEM DO ADQUIRENTE DA ", "6.925 - RETORNO DE MERC. RECEB. P/ INDUSTRIALIZ. POR CONTA E ORDEM D", "6.929 - LANCAMENTO EFETUADO EM DECORRENCIA DE EMISSAO DE DOCUMENTO F", "6.931 - LANCAMENTO EFETUADO EM DECORRENCIA DA RESPONSABILIDADE DE RE", "6.932 - PREST. DE SERV. DE TRANSP. INICIADA EM UNIDADE DA FEDERACAO ", "6.933 - PREST. DE SERV. TRIBUTADO PELO ISSQN                        ", "6.949 - OUTRA SAIDA DE MERC. OU PREST. DE SERV. NAO ESPECIFI.       ", "7.101 - VENDA DE PRODUCAO DO ESTAB.                                 ", "7.102 - VENDA DE MERC. ADQU. OU RECEB. DE TERC.                     ", "7.105 - VENDA DE PRODUCAO DO ESTAB., QUE NAO DEVA POR ELE TRANSITAR ", "7.106 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., QUE NAO DEVA POR EL", "7.127 - VENDA DE PRODUCAO DO ESTAB. SOB O REGIME DE DRAWBACK        ", "7.201 - DEVOL. DE COMPRA P/ INDUSTRIALIZ.                           ", "7.202 - DEVOL. DE COMPRA P/ COMERC.                                 ", "7.205 - ANULACAO DE VALOR RELATIVO A AQUIS. DE SERV. DE COMUN.      ", "7.206 - ANULACAO DE VALOR RELATIVO A AQUIS. DE SERV. DE TRANSP.     ", "7.207 - ANULACAO DE VALOR RELATIVO A COMPRA DE ENERG. ELETR.        ", "7.210 - DEVOL. DE COMPRA P/ UTILIZ. NA PREST. DE SERV.              ", "7.211 - DEVOL. DE COMPRAS P/ INDUSTRIALIZ. SOB O REGIME DE DRAWBACK ", "7.251 - VENDA DE ENERG. ELETR. P/ O EXTERIOR                        ", "7.301 - PREST. DE SERV. DE COMUN. P/ EXEC. DE SERV. DA MESMA NATUREZ", "7.358 - PREST. DE SERV. DE TRANSP.                                  ", "7.501 - EXPORT. DE MERC.S RECEB.S COM FIM ESPECIF. DE EXPORT.       ", "7.551 - VENDA DE BEM DO ATIVO IMOBILIZADO                           ", "7.553 - DEVOL. DE COMPRA DE BEM P/ O ATIVO IMOBILIZADO              ", "7.556 - DEVOL. DE COMPRA DE MATERIAL DE USO OU CONSUMO              ", "7.650 - SAID. DE COMBUSTIVEIS, DERIVADOS OU NAO DE PETROLEO E LUBRIF", "7.651 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB.         ", "7.654 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC.     ", "7.930 - LANCAMENTO EFETUADO A TITULO DE DEVOL. DE BEM CUJA ENTR. TEN", "7.949 - OUTRA SAIDA DE MERC. OU PREST. DE SERV. NAO ESPECIFI.       "})
        Me.cbo_nfeCfop.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbo_nfeCfop.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cbo_nfeCfop.DropDownWidth = 315
        Me.cbo_nfeCfop.FormattingEnabled = True
        Me.cbo_nfeCfop.Items.AddRange(New Object() {"5.101 - VENDA DE PRODUCAO DO ESTAB.                                 ", "5.102 - VENDA DE MERC. ADQU. OU RECEB. DE TERC.                     ", "5.103 - VENDA DE PRODUCAO DO ESTAB., EFETUADA FORA DO ESTAB.        ", "5.104 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., EFETUADA FORA DO ES", "5.105 - VENDA DE PRODUCAO DO ESTAB. QUE NAO DEVA POR ELE TRANSITAR  ", "5.106 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., QUE NAO DEVA POR EL", "5.109 - VENDA DE PRODUCAO DO ESTAB., DESTINADA A ZONA FRANCA DE MANA", "5.110 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., DESTINADA A ZONA FR", "5.111 - VENDA DE PRODUCAO DO ESTAB. REMETIDA ANTER. EM CONSIG. INDUS", "5.112 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. REMETIDA ANTER. EM C", "5.113 - VENDA DE PRODUCAO DO ESTAB. REMETIDA ANTER. EM CONSIG. MERCA", "5.114 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. REMETIDA ANTER. EM C", "5.115 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., RECEB. ANTER. EM CO", "5.116 - VENDA DE PRODUCAO DO ESTAB. ORIG. DE ENCOMENDA P/ ENTREGA FU", "5.117 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., ORIG. DE ENCOMENDA ", "5.118 - VENDA DE PRODUCAO DO ESTAB. ENTREGUE AO DESTI. POR CONTA E O", "5.119 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. ENTREGUE AO DESTI. P", "5.120 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. ENTREGUE AO DESTI. P", "5.122 - VENDA DE PRODUCAO DO ESTAB. REMETIDA P/ INDUSTRIALIZ., POR C", "5.123 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. REMETIDA P/ INDUSTRI", "5.124 - INDUSTRIALIZ. EFETUADA P/ OUTRA EMPRESA                     ", "5.125 - INDUSTRIALIZ. EFETUADA P/ OUTRA EMPRESA QUANDO A MERC. RECEB", "5.151 - TRANSF. DE PRODUCAO DO ESTAB.                               ", "5.152 - TRANSF. DE MERC. ADQU. OU RECEB. DE TERC.                   ", "5.153 - TRANSF. DE ENERG. ELETR.                                    ", "5.155 - TRANSF. DE PRODUCAO DO ESTAB., QUE NAO DEVA POR ELE TRANSITA", "5.156 - TRANSF. DE MERC. ADQU. OU RECEB. DE TERC., QUE NAO DEVA POR ", "5.201 - DEVOL. DE COMPRA P/ INDUSTRIALIZ.                           ", "5.202 - DEVOL. DE COMPRA P/ COMERC.                                 ", "5.205 - ANULACAO DE VALOR RELATIVO A AQUIS. DE SERV. DE COMUN.      ", "5.206 - ANULACAO DE VALOR RELATIVO A AQUIS. DE SERV. DE TRANSP.     ", "5.207 - ANULACAO DE VALOR RELATIVO A COMPRA DE ENERG. ELETR.        ", "5.208 - DEVOL. DE MERC. RECEB. EM TRANSF. P/ INDUSTRIALIZ.          ", "5.209 - DEVOL. DE MERC. RECEB. EM TRANSF. P/ COMERC.                ", "5.210 - DEVOL. DE COMPRA P/ UTILIZ. NA PREST. DE SERV.              ", "5.251 - VENDA DE ENERG. ELETR. P/ DISTRIB. OU COMERC.               ", "5.252 - VENDA DE ENERG. ELETR. P/ ESTAB. INDUSTRIAL                 ", "5.253 - VENDA DE ENERG. ELETR. P/ ESTAB. COMERCIAL                  ", "5.254 - VENDA DE ENERG. ELETR. P/ ESTAB. PREST. DE SERV. DE TRANSP. ", "5.255 - VENDA DE ENERG. ELETR. P/ ESTAB. PREST. DE SERV. DE COMUN.  ", "5.256 - VENDA DE ENERG. ELETR. P/ ESTAB. DE PRODUTOR RURAL          ", "5.257 - VENDA DE ENERG. ELETR. P/ CONSUMO POR DEMANDA CONTRATADA    ", "5.258 - VENDA DE ENERG. ELETR. A NAO CONTRIBUINTE                   ", "5.301 - PREST. DE SERV. DE COMUN. P/ EXEC. DE SERV. DA MESMA NATUREZ", "5.302 - PREST. DE SERV. DE COMUN. A ESTAB. INDUSTRIAL               ", "5.303 - PREST. DE SERV. DE COMUN. A ESTAB. COMERCIAL                ", "5.304 - PREST. DE SERV. DE COMUN. A ESTAB. DE PREST. DE SERV. DE TRA", "5.305 - PREST. DE SERV. DE COMUN. A ESTAB. DE GERADORA OU DE DISTRIB", "5.306 - PREST. DE SERV. DE COMUN. A ESTAB. DE PRODUTOR RURAL        ", "5.307 - PREST. DE SERV. DE COMUN. A NAO CONTRIBUINTE                ", "5.351 - PREST. DE SERV. DE TRANSP. P/ EXEC. DE SERV. DA MESMA NATURE", "5.352 - PREST. DE SERV. DE TRANSP. A ESTAB. INDUSTRIAL              ", "5.353 - PREST. DE SERV. DE TRANSP. A ESTAB. COMERCIAL               ", "5.354 - PREST. DE SERV. DE TRANSP. A ESTAB. DE PREST. DE SERV. DE CO", "5.355 - PREST. DE SERV. DE TRANSP. A ESTAB. DE GERADORA OU DE DISTRI", "5.356 - PREST. DE SERV. DE TRANSP. A ESTAB. DE PRODUTOR RURAL       ", "5.357 - PREST. DE SERV. DE TRANSP. A NAO CONTRIBUINTE               ", "5.359 - PREST. DE SERV. DE TRANSP. A CONTRIBUINTE OU A NAO CONTRIBUI", "5.401 - VENDA DE PRODUCAO DO ESTAB. EM OPER. COM PRODUTO SUJEITO AO ", "5.402 - VENDA DE PRODUCAO DO ESTAB. DE PRODUTO SUJEITO AO REGIME DE ", "5.403 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. EM OPER. COM MERC. S", "5.405 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. EM OPER. COM MERC. S", "5.408 - TRANSF. DE PRODUCAO DO ESTAB. EM OPER. COM PRODUTO SUJEITO A", "5.409 - TRANSF. DE MERC. ADQU. OU RECEB. DE TERC. EM OPER. COM MERC.", "5.410 - DEVOL. DE COMPRA P/ INDUSTRIALIZ. EM OPER. COM MERC. SUJ. AO", "5.411 - DEVOL. DE COMPRA P/ COMERC. EM OPER. COM MERC. SUJ. AO REGIM", "5.412 - DEVOL. DE BEM DO ATIVO IMOBILIZADO, EM OPER. COM MERC. SUJ. ", "5.413 - DEVOL. DE MERC. DESTINADA AO USO OU CONSUMO, EM OPER. COM ME", "5.414 - REMESSA DE PRODUCAO DO ESTAB. P/ VENDA FORA DO ESTAB. EM OPE", "5.415 - REMESSA DE MERC. ADQU. OU RECEB. DE TERC. P/ VENDA FORA DO E", "5.451 - REMESSA DE ANIMAL E DE INSUMO P/ ESTAB. PRODUTOR            ", "5.501 - REMESSA DE PRODUCAO DO ESTAB., COM FIM ESPECIF. DE EXPORT.  ", "5.502 - REMESSA DE MERC. ADQU. OU RECEB. DE TERC., COM FIM ESPECIF. ", "5.503 - DEVOL. DE MERC. RECEB. COM FIM ESPECIF. DE EXPORT.          ", "5.551 - VENDA DE BEM DO ATIVO IMOBILIZADO                           ", "5.552 - TRANSF. DE BEM DO ATIVO IMOBILIZADO                         ", "5.553 - DEVOL. DE COMPRA DE BEM P/ O ATIVO IMOBILIZADO              ", "5.554 - REMESSA DE BEM DO ATIVO IMOBILIZADO P/ USO FORA DO ESTAB.   ", "5.555 - DEVOL. DE BEM DO ATIVO IMOBILIZADO DE TERCEIRO, RECEB. P/ US", "5.556 - DEVOL. DE COMPRA DE MATERIAL DE USO OU CONSUMO              ", "5.557 - TRANSF. DE MATERIAL DE USO OU CONSUMO                       ", "5.601 - TRANSF. DE CREDITO DE ICMS ACUMULADO                        ", "5.602 - TRANSF. DE SALDO CREDOR DE ICMS P/ OUTRO ESTAB. DA MESMA EMP", "5.603 - RESSARCIMENTO DE ICMS RETIDO POR SUBST. TRIB.               ", "5.605 - TRANSF. DE SALDO DEVEDOR DE ICMS DE OUTRO ESTAB. DA MESMA EM", "5.650 - SAID. DE COMBUSTIVEIS, DERIVADOS OU NAO DE PETROLEO E LUBRIF", "5.651 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB. DESTINAD", "5.652 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB. DESTINAD", "5.653 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB. DESTINAD", "5.654 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. DEST", "5.655 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. DEST", "5.656 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. DEST", "5.657 - REMESSA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. P/", "5.658 - TRANSF. DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB.       ", "5.659 - TRANSF. DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERCEIRO", "5.660 - DEVOL. DE COMPRA DE COMBUST. OU LUBRIFI. ADQUI. P/ INDUSTRIA", "5.661 - DEVOL. DE COMPRA DE COMBUST. OU LUBRIFI. ADQUI. P/ COMERCIAL", "5.662 - DEVOL. DE COMPRA DE COMBUST. OU LUBRIFI. ADQUI. POR CONSUMID", "5.663 - REMESSA P/ ARMAZENAGEM DE COMBUST. OU LUBRIFI.              ", "5.664 - RETORNO DE COMBUST. OU LUBRIFI. RECEB. P/ ARMAZENAGEM       ", "5.665 - RETORNO SIMBOLICO DE COMBUST. OU LUBRIFI. RECEB. P/ ARMAZENA", "5.666 - REMESSA POR CONTA E ORDEM DE TERC. DE COMBUST. OU LUBRIFI. R", "5.901 - REMESSA P/ INDUSTRIALIZ. POR ENCOMENDA                      ", "5.902 - RETORNO DE MERC. UTILIZADA NA INDUSTRIALIZ. POR ENCOMENDA   ", "5.903 - RETORNO DE MERC. RECEB. P/ INDUSTRIALIZ. E NAO APLICADA NO R", "5.904 - REMESSA P/ VENDA FORA DO ESTAB.                             ", "5.905 - REMESSA P/ DEPOSITO FECHADO OU ARMAZEM GERAL                ", "5.906 - RETORNO DE MERC. DEPOSITADA EM DEPOSITO FECHADO OU ARMAZEM G", "5.907 - RETORNO SIMBOLICO DE MERC. DEPOSITADA EM DEPOSITO FECHADO OU", "5.908 - REMESSA DE BEM POR CONTA DE CONTRATO DE COMODATO            ", "5.909 - RETORNO DE BEM RECEB. POR CONTA DE CONTRATO DE COMODATO     ", "5.910 - REMESSA EM BONIF., DOACAO OU BRINDE                         ", "5.911 - REMESSA DE AMOSTRA GRATIS                                   ", "5.912 - REMESSA DE MERC. OU BEM P/ DEMONSTRACAO                     ", "5.913 - RETORNO DE MERC. OU BEM RECEB. P/ DEMONSTRACAO              ", "5.914 - REMESSA DE MERC. OU BEM P/ EXPOSICAO OU FEIRA               ", "5.915 - REMESSA DE MERC. OU BEM P/ CONSERTO OU REPARO               ", "5.916 - RETORNO DE MERC. OU BEM RECEB. P/ CONSERTO OU REPARO        ", "5.917 - REMESSA DE MERC. EM CONSIG. MERCANTIL OU INDUSTRIAL         ", "5.918 - DEVOL. DE MERC. RECEB. EM CONSIG. MERCANTIL OU INDUSTRIAL   ", "5.919 - DEVOL. SIMBOLICA DE MERC. VENDIDA OU UTILIZADA EM PROCESSO I", "5.920 - REMESSA DE VASILHAME OU SACARIA                             ", "5.921 - DEVOL. DE VASILHAME OU SACARIA                              ", "5.922 - LANCAMENTO EFETUADO A TITULO DE SIMPLES FATURAMENTO DECORREN", "5.923 - REMESSA DE MERC. POR CONTA E ORDEM DE TERC., EM VENDA A ORDE", "5.924 - REMESSA P/ INDUSTRIALIZ. POR CONTA E ORDEM DO ADQUIRENTE DA ", "5.925 - RETORNO DE MERC. RECEB. P/ INDUSTRIALIZ. POR CONTA E ORDEM D", "5.926 - LANCAMENTO EFETUADO A TITULO DE RECLASSIFICACAO DE MERC. DEC", "5.927 - LANCAMENTO EFETUADO A TITULO DE BAIXA DE ESTOQUE DECORRENTE ", "5.928 - LANCAMENTO EFETUADO A TITULO DE BAIXA DE ESTOQUE DECORRENTE ", "5.929 - LANCAMENTO EFETUADO EM DECORRENCIA DE EMISSAO DE DOCUMENTO F", "5.931 - LANCAMENTO EFETUADO EM DECORRENCIA DA RESPONSABILIDADE DE RE", "5.932 - PREST. DE SERV. DE TRANSP. INICIADA EM UNIDADE DA FEDERACAO ", "5.933 - PREST. DE SERV. TRIBUTADO PELO ISSQN                        ", "5.949 - OUTRA SAIDA DE MERC. OU PREST. DE SERV. NAO ESPECIFI.       ", "6.101 - VENDA DE PRODUCAO DO ESTAB.                                 ", "6.102 - VENDA DE MERC. ADQU. OU RECEB. DE TERC.                     ", "6.103 - VENDA DE PRODUCAO DO ESTAB., EFETUADA FORA DO ESTAB.        ", "6.104 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., EFETUADA FORA DO ES", "6.105 - VENDA DE PRODUCAO DO ESTAB. QUE NAO DEVA POR ELE TRANSITAR  ", "6.106 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., QUE NAO DEVA POR EL", "6.107 - VENDA DE PRODUCAO DO ESTAB., DESTINADA A NAO CONTRIBUINTE   ", "6.108 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., DESTINADA A NAO CON", "6.109 - VENDA DE PRODUCAO DO ESTAB., DESTINADA A ZONA FRANCA DE MANA", "6.110 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., DESTINADA A ZONA FR", "6.111 - VENDA DE PRODUCAO DO ESTAB. REMETIDA ANTER. EM CONSIG. INDUS", "6.112 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. REMETIDA ANTER. EM C", "6.113 - VENDA DE PRODUCAO DO ESTAB. REMETIDA ANTER. EM CONSIG. MERCA", "6.114 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. REMETIDA ANTER. EM C", "6.115 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., RECEB. ANTER. EM CO", "6.116 - VENDA DE PRODUCAO DO ESTAB. ORIG. DE ENCOMENDA P/ ENTREGA FU", "6.117 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., ORIG. DE ENCOMENDA ", "6.118 - VENDA DE PRODUCAO DO ESTAB. ENTREGUE AO DESTI. POR CONTA E O", "6.119 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. ENTREGUE AO DESTI. P", "6.120 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. ENTREGUE AO DESTI. P", "6.122 - VENDA DE PRODUCAO DO ESTAB. REMETIDA P/ INDUSTRIALIZ., POR C", "6.123 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. REMETIDA P/ INDUSTRI", "6.124 - INDUSTRIALIZ. EFETUADA P/ OUTRA EMPRESA                     ", "6.125 - INDUSTRIALIZ. EFETUADA P/ OUTRA EMPRESA QUANDO A MERC. RECEB", "6.151 - TRANSF. DE PRODUCAO DO ESTAB.                               ", "6.152 - TRANSF. DE MERC. ADQU. OU RECEB. DE TERC.                   ", "6.153 - TRANSF. DE ENERG. ELETR.                                    ", "6.155 - TRANSF. DE PRODUCAO DO ESTAB., QUE NAO DEVA POR ELE TRANSITA", "6.156 - TRANSF. DE MERC. ADQU. OU RECEB. DE TERC., QUE NAO DEVA POR ", "6.201 - DEVOL. DE COMPRA P/ INDUSTRIALIZ.                           ", "6.202 - DEVOL. DE COMPRA P/ COMERC.                                 ", "6.205 - ANULACAO DE VALOR RELATIVO A AQUIS. DE SERV. DE COMUN.      ", "6.206 - ANULACAO DE VALOR RELATIVO A AQUIS. DE SERV. DE TRANSP.     ", "6.207 - ANULACAO DE VALOR RELATIVO A COMPRA DE ENERG. ELETR.        ", "6.208 - DEVOL. DE MERC. RECEB. EM TRANSF. P/ INDUSTRIALIZ.          ", "6.209 - DEVOL. DE MERC. RECEB. EM TRANSF. P/ COMERC.                ", "6.210 - DEVOL. DE COMPRA P/ UTILIZ. NA PREST. DE SERV.              ", "6.251 - VENDA DE ENERG. ELETR. P/ DISTRIB. OU COMERC.               ", "6.252 - VENDA DE ENERG. ELETR. P/ ESTAB. INDUSTRIAL                 ", "6.253 - VENDA DE ENERG. ELETR. P/ ESTAB. COMERCIAL                  ", "6.254 - VENDA DE ENERG. ELETR. P/ ESTAB. PREST. DE SERV. DE TRANSP. ", "6.255 - VENDA DE ENERG. ELETR. P/ ESTAB. PREST. DE SERV. DE COMUN.  ", "6.256 - VENDA DE ENERG. ELETR. P/ ESTAB. DE PRODUTOR RURAL          ", "6.257 - VENDA DE ENERG. ELETR. P/ CONSUMO POR DEMANDA CONTRATADA    ", "6.258 - VENDA DE ENERG. ELETR. A NAO CONTRIBUINTE                   ", "6.301 - PREST. DE SERV. DE COMUN. P/ EXEC. DE SERV. DA MESMA NATUREZ", "6.302 - PREST. DE SERV. DE COMUN. A ESTAB. INDUSTRIAL               ", "6.303 - PREST. DE SERV. DE COMUN. A ESTAB. COMERCIAL                ", "6.304 - PREST. DE SERV. DE COMUN. A ESTAB. DE PREST. DE SERV. DE TRA", "6.305 - PREST. DE SERV. DE COMUN. A ESTAB. DE GERADORA OU DE DISTRIB", "6.306 - PREST. DE SERV. DE COMUN. A ESTAB. DE PRODUTOR RURAL        ", "6.307 - PREST. DE SERV. DE COMUN. A NAO CONTRIBUINTE                ", "6.351 - PREST. DE SERV. DE TRANSP. P/ EXEC. DE SERV. DA MESMA NATURE", "6.352 - PREST. DE SERV. DE TRANSP. A ESTAB. INDUSTRIAL              ", "6.353 - PREST. DE SERV. DE TRANSP. A ESTAB. COMERCIAL               ", "6.354 - PREST. DE SERV. DE TRANSP. A ESTAB. DE PREST. DE SERV. DE CO", "6.355 - PREST. DE SERV. DE TRANSP. A ESTAB. DE GERADORA OU DE DISTRI", "6.356 - PREST. DE SERV. DE TRANSP. A ESTAB. DE PRODUTOR RURAL       ", "6.357 - PREST. DE SERV. DE TRANSP. A NAO CONTRIBUINTE               ", "6.359 - PREST. DE SERV. DE TRANSP. A CONTRIBUINTE OU A NAO CONTRIBUI", "6.401 - VENDA DE PRODUCAO DO ESTAB. EM OPER. COM PRODUTO SUJEITO AO ", "6.402 - VENDA DE PRODUCAO DO ESTAB. DE PRODUTO SUJEITO AO REGIME DE ", "6.403 - VENDA DE MERC. ADQU. OU RECEB. DE TERC. EM OPER. COM MERC. S", "6.404 - VENDA DE MERC. SUJ. AO REGIME DE SUBST. TRIB., CUJO IMPOSTO ", "6.408 - TRANSF. DE PRODUCAO DO ESTAB. EM OPER. COM PRODUTO SUJEITO A", "6.409 - TRANSF. DE MERC. ADQU. OU RECEB. DE TERC. EM OPER. COM MERC.", "6.410 - DEVOL. DE COMPRA P/ INDUSTRIALIZ. EM OPER. COM MERC. SUJ. AO", "6.411 - DEVOL. DE COMPRA P/ COMERC. EM OPER. COM MERC. SUJ. AO REGIM", "6.412 - DEVOL. DE BEM DO ATIVO IMOBILIZADO, EM OPER. COM MERC. SUJ. ", "6.413 - DEVOL. DE MERC. DESTINADA AO USO OU CONSUMO, EM OPER. COM ME", "6.414 - REMESSA DE PRODUCAO DO ESTAB. P/ VENDA FORA DO ESTAB. EM OPE", "6.415 - REMESSA DE MERC. ADQU. OU RECEB. DE TERC. P/ VENDA FORA DO E", "6.501 - REMESSA DE PRODUCAO DO ESTAB., COM FIM ESPECIF. DE EXPORT.  ", "6.502 - REMESSA DE MERC. ADQU. OU RECEB. DE TERC., COM FIM ESPECIF. ", "6.503 - DEVOL. DE MERC. RECEB. COM FIM ESPECIF. DE EXPORT.          ", "6.551 - VENDA DE BEM DO ATIVO IMOBILIZADO                           ", "6.552 - TRANSF. DE BEM DO ATIVO IMOBILIZADO                         ", "6.553 - DEVOL. DE COMPRA DE BEM P/ O ATIVO IMOBILIZADO              ", "6.554 - REMESSA DE BEM DO ATIVO IMOBILIZADO P/ USO FORA DO ESTAB.   ", "6.555 - DEVOL. DE BEM DO ATIVO IMOBILIZADO DE TERCEIRO, RECEB. P/ US", "6.556 - DEVOL. DE COMPRA DE MATERIAL DE USO OU CONSUMO              ", "6.557 - TRANSF. DE MATERIAL DE USO OU CONSUMO                       ", "6.603 - RESSARCIMENTO DE ICMS RETIDO POR SUBST. TRIB.               ", "6.650 - SAID. DE COMBUSTIVEIS, DERIVADOS OU NAO DE PETROLEO E LUBRIF", "6.651 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB. DESTINAD", "6.652 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB. DESTINAD", "6.653 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB. DESTINAD", "6.654 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. DEST", "6.655 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. DEST", "6.656 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. DEST", "6.657 - REMESSA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC. P/", "6.658 - TRANSF. DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB.       ", "6.659 - TRANSF. DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERCEIRO", "6.660 - DEVOL. DE COMPRA DE COMBUST. OU LUBRIFI. ADQUI. P/ INDUSTRIA", "6.661 - DEVOL. DE COMPRA DE COMBUST. OU LUBRIFI. ADQUI. P/ COMERC.  ", "6.662 - DEVOL. DE COMPRA DE COMBUST. OU LUBRIFI. ADQUI. POR CONSUMID", "6.663 - REMESSA P/ ARMAZENAGEM DE COMBUST. OU LUBRIFI.              ", "6.664 - RETORNO DE COMBUST. OU LUBRIFI. RECEB. P/ ARMAZENAGEM       ", "6.665 - RETORNO SIMBOLICO DE COMBUST. OU LUBRIFI. RECEB. P/ ARMAZENA", "6.666 - REMESSA POR CONTA E ORDEM DE TERC. DE COMBUST. OU LUBRIFI. R", "6.901 - REMESSA P/ INDUSTRIALIZ. POR ENCOMENDA                      ", "6.902 - RETORNO DE MERC. UTILIZADA NA INDUSTRIALIZ. POR ENCOMENDA   ", "6.903 - RETORNO DE MERC. RECEB. P/ INDUSTRIALIZ. E NAO APLICADA NO R", "6.904 - REMESSA P/ VENDA FORA DO ESTAB.                             ", "6.905 - REMESSA P/ DEPOSITO FECHADO OU ARMAZEM GERAL                ", "6.906 - RETORNO DE MERC. DEPOSITADA EM DEPOSITO FECHADO OU ARMAZEM G", "6.907 - RETORNO SIMBOLICO DE MERC. DEPOSITADA EM DEPOSITO FECHADO OU", "6.908 - REMESSA DE BEM POR CONTA DE CONTRATO DE COMODATO            ", "6.909 - RETORNO DE BEM RECEB. POR CONTA DE CONTRATO DE COMODATO     ", "6.910 - REMESSA EM BONIF., DOACAO OU BRINDE                         ", "6.911 - REMESSA DE AMOSTRA GRATIS                                   ", "6.912 - REMESSA DE MERC. OU BEM P/ DEMONSTRACAO                     ", "6.913 - RETORNO DE MERC. OU BEM RECEB. P/ DEMONSTRACAO              ", "6.914 - REMESSA DE MERC. OU BEM P/ EXPOSICAO OU FEIRA               ", "6.915 - REMESSA DE MERC. OU BEM P/ CONSERTO OU REPARO               ", "6.916 - RETORNO DE MERC. OU BEM RECEB. P/ CONSERTO OU REPARO        ", "6.917 - REMESSA DE MERC. EM CONSIG. MERCANTIL OU INDUSTRIAL         ", "6.918 - DEVOL. DE MERC. RECEB. EM CONSIG. MERCANTIL OU INDUSTRIAL   ", "6.919 - DEVOL. SIMBOLICA DE MERC. VENDIDA OU UTILIZADA EM PROCESSO I", "6.920 - REMESSA DE VASILHAME OU SACARIA                             ", "6.921 - DEVOL. DE VASILHAME OU SACARIA                              ", "6.922 - LANCAMENTO EFETUADO A TITULO DE SIMPLES FATURAMENTO DECORREN", "6.923 - REMESSA DE MERC. POR CONTA E ORDEM DE TERC., EM VENDA A ORDE", "6.924 - REMESSA P/ INDUSTRIALIZ. POR CONTA E ORDEM DO ADQUIRENTE DA ", "6.925 - RETORNO DE MERC. RECEB. P/ INDUSTRIALIZ. POR CONTA E ORDEM D", "6.929 - LANCAMENTO EFETUADO EM DECORRENCIA DE EMISSAO DE DOCUMENTO F", "6.931 - LANCAMENTO EFETUADO EM DECORRENCIA DA RESPONSABILIDADE DE RE", "6.932 - PREST. DE SERV. DE TRANSP. INICIADA EM UNIDADE DA FEDERACAO ", "6.933 - PREST. DE SERV. TRIBUTADO PELO ISSQN                        ", "6.949 - OUTRA SAIDA DE MERC. OU PREST. DE SERV. NAO ESPECIFI.       ", "7.101 - VENDA DE PRODUCAO DO ESTAB.                                 ", "7.102 - VENDA DE MERC. ADQU. OU RECEB. DE TERC.                     ", "7.105 - VENDA DE PRODUCAO DO ESTAB., QUE NAO DEVA POR ELE TRANSITAR ", "7.106 - VENDA DE MERC. ADQU. OU RECEB. DE TERC., QUE NAO DEVA POR EL", "7.127 - VENDA DE PRODUCAO DO ESTAB. SOB O REGIME DE DRAWBACK        ", "7.201 - DEVOL. DE COMPRA P/ INDUSTRIALIZ.                           ", "7.202 - DEVOL. DE COMPRA P/ COMERC.                                 ", "7.205 - ANULACAO DE VALOR RELATIVO A AQUIS. DE SERV. DE COMUN.      ", "7.206 - ANULACAO DE VALOR RELATIVO A AQUIS. DE SERV. DE TRANSP.     ", "7.207 - ANULACAO DE VALOR RELATIVO A COMPRA DE ENERG. ELETR.        ", "7.210 - DEVOL. DE COMPRA P/ UTILIZ. NA PREST. DE SERV.              ", "7.211 - DEVOL. DE COMPRAS P/ INDUSTRIALIZ. SOB O REGIME DE DRAWBACK ", "7.251 - VENDA DE ENERG. ELETR. P/ O EXTERIOR                        ", "7.301 - PREST. DE SERV. DE COMUN. P/ EXEC. DE SERV. DA MESMA NATUREZ", "7.358 - PREST. DE SERV. DE TRANSP.                                  ", "7.501 - EXPORT. DE MERC.S RECEB.S COM FIM ESPECIF. DE EXPORT.       ", "7.551 - VENDA DE BEM DO ATIVO IMOBILIZADO                           ", "7.553 - DEVOL. DE COMPRA DE BEM P/ O ATIVO IMOBILIZADO              ", "7.556 - DEVOL. DE COMPRA DE MATERIAL DE USO OU CONSUMO              ", "7.650 - SAID. DE COMBUSTIVEIS, DERIVADOS OU NAO DE PETROLEO E LUBRIF", "7.651 - VENDA DE COMBUST. OU LUBRIFI. DE PRODUCAO DO ESTAB.         ", "7.654 - VENDA DE COMBUST. OU LUBRIFI. ADQUI. OU RECEB. DE TERC.     ", "7.930 - LANCAMENTO EFETUADO A TITULO DE DEVOL. DE BEM CUJA ENTR. TEN", "7.949 - OUTRA SAIDA DE MERC. OU PREST. DE SERV. NAO ESPECIFI.       "})
        Me.cbo_nfeCfop.Location = New System.Drawing.Point(231, 119)
        Me.cbo_nfeCfop.Name = "cbo_nfeCfop"
        Me.cbo_nfeCfop.Size = New System.Drawing.Size(275, 21)
        Me.cbo_nfeCfop.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(187, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "CFOP:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_placa)
        Me.GroupBox2.Controls.Add(Me.lbl_ambiente)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.lbl_tipoemissao)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.btn_nfe)
        Me.GroupBox2.Controls.Add(Me.cbo_placa)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbo_transportador)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 230)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(634, 76)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Transportador"
        '
        'txt_placa
        '
        Me.txt_placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_placa.Location = New System.Drawing.Point(260, 16)
        Me.txt_placa.MaxLength = 8
        Me.txt_placa.Name = "txt_placa"
        Me.txt_placa.Size = New System.Drawing.Size(87, 20)
        Me.txt_placa.TabIndex = 10
        Me.txt_placa.Visible = False
        '
        'lbl_ambiente
        '
        Me.lbl_ambiente.AutoSize = True
        Me.lbl_ambiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ambiente.ForeColor = System.Drawing.Color.Red
        Me.lbl_ambiente.Location = New System.Drawing.Point(262, 50)
        Me.lbl_ambiente.Name = "lbl_ambiente"
        Me.lbl_ambiente.Size = New System.Drawing.Size(61, 13)
        Me.lbl_ambiente.TabIndex = 12
        Me.lbl_ambiente.Text = "Produção"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(201, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Ambiente:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MetroSys.My.Resources.Resources.logo_NFe
        Me.PictureBox1.Location = New System.Drawing.Point(534, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(93, 54)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'lbl_tipoemissao
        '
        Me.lbl_tipoemissao.AutoSize = True
        Me.lbl_tipoemissao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tipoemissao.ForeColor = System.Drawing.Color.Red
        Me.lbl_tipoemissao.Location = New System.Drawing.Point(87, 50)
        Me.lbl_tipoemissao.Name = "lbl_tipoemissao"
        Me.lbl_tipoemissao.Size = New System.Drawing.Size(46, 13)
        Me.lbl_tipoemissao.TabIndex = 9
        Me.lbl_tipoemissao.Text = "Normal"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Tipo Emissao:"
        '
        'btn_nfe
        '
        Me.btn_nfe.Image = Global.MetroSys.My.Resources.Resources.NFe
        Me.btn_nfe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_nfe.Location = New System.Drawing.Point(416, 16)
        Me.btn_nfe.Name = "btn_nfe"
        Me.btn_nfe.Size = New System.Drawing.Size(64, 33)
        Me.btn_nfe.TabIndex = 11
        Me.btn_nfe.Text = "&Gerar"
        Me.btn_nfe.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nfe.UseVisualStyleBackColor = True
        '
        'cbo_placa
        '
        Me.cbo_placa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_placa.FormattingEnabled = True
        Me.cbo_placa.Location = New System.Drawing.Point(260, 16)
        Me.cbo_placa.Name = "cbo_placa"
        Me.cbo_placa.Size = New System.Drawing.Size(121, 21)
        Me.cbo_placa.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(217, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Placa:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Transportador:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rtb_mensagem)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 312)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(633, 200)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Retorno Sefaz"
        '
        'rtb_mensagem
        '
        Me.rtb_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtb_mensagem.ForeColor = System.Drawing.Color.Red
        Me.rtb_mensagem.Location = New System.Drawing.Point(4, 15)
        Me.rtb_mensagem.Name = "rtb_mensagem"
        Me.rtb_mensagem.Size = New System.Drawing.Size(623, 179)
        Me.rtb_mensagem.TabIndex = 0
        Me.rtb_mensagem.Text = ""
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 515)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(634, 46)
        Me.GroupBox7.TabIndex = 10
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(8, 18)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(35, 15)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = "       "
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(550, 38)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(96, 24)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-3, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(664, 66)
        Me.Panel1.TabIndex = 12
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(546, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(97, 35)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(233, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(187, 53)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'lbl_numeroNota1pp
        '
        Me.lbl_numeroNota1pp.AutoSize = True
        Me.lbl_numeroNota1pp.Location = New System.Drawing.Point(426, 7)
        Me.lbl_numeroNota1pp.Name = "lbl_numeroNota1pp"
        Me.lbl_numeroNota1pp.Size = New System.Drawing.Size(83, 13)
        Me.lbl_numeroNota1pp.TabIndex = 20
        Me.lbl_numeroNota1pp.Text = "numeroNota1pp"
        Me.lbl_numeroNota1pp.Visible = False
        '
        'Frm_NFEAutorizanota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 568)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_NFEAutorizanota"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autoriza Nota Fiscal Eletrônica"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbo_tiponfe As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_transportador As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_nfeCfop As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_placa As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rtb_mensagem As System.Windows.Forms.RichTextBox
    Friend WithEvents btn_nfe As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_totalNota As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_qtdeItens As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_tipoemissao As System.Windows.Forms.Label
    Friend WithEvents cbo_estabelecimento As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_ambiente As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbl_emitente As System.Windows.Forms.Label
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents dtp_dtSaida As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_placa As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents chk_pauta As System.Windows.Forms.CheckBox
    Public WithEvents lbl_numeroNota1pp As System.Windows.Forms.Label
End Class
