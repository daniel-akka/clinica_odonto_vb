<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PedidoProntEntrega
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PedidoProntEntrega))
        Me.grp_pedido = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cbo_condpgto = New System.Windows.Forms.ComboBox
        Me.cbo_forpgto = New System.Windows.Forms.ComboBox
        Me.lbl_formpagto = New System.Windows.Forms.Label
        Me.chk_rota = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cbo_tipopedido = New System.Windows.Forms.ComboBox
        Me.cbo_rota = New System.Windows.Forms.ComboBox
        Me.msk_senha = New System.Windows.Forms.MaskedTextBox
        Me.cbo_gerente = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_valor = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_codProd = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grp_registra = New System.Windows.Forms.GroupBox
        Me.btn_finalizar = New System.Windows.Forms.Button
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.btn_incluir = New System.Windows.Forms.Button
        Me.txt_nomeProd = New System.Windows.Forms.TextBox
        Me.txt_qtde = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_desconto = New System.Windows.Forms.TextBox
        Me.lbl_desconto = New System.Windows.Forms.Label
        Me.grp_descontos = New System.Windows.Forms.GroupBox
        Me.txt_descontosTotais = New System.Windows.Forms.TextBox
        Me.grp_total = New System.Windows.Forms.GroupBox
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.grp_peso = New System.Windows.Forms.GroupBox
        Me.txt_peso = New System.Windows.Forms.TextBox
        Me.grp_condicoes = New System.Windows.Forms.GroupBox
        Me.txt_cond7 = New System.Windows.Forms.TextBox
        Me.txt_cond6 = New System.Windows.Forms.TextBox
        Me.txt_cond5 = New System.Windows.Forms.TextBox
        Me.txt_cond4 = New System.Windows.Forms.TextBox
        Me.txt_cond3 = New System.Windows.Forms.TextBox
        Me.txt_cond2 = New System.Windows.Forms.TextBox
        Me.txt_cond1 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbo_local = New System.Windows.Forms.ComboBox
        Me.txt_codpart = New System.Windows.Forms.TextBox
        Me.lbl_senha = New System.Windows.Forms.Label
        Me.txt_entrada = New System.Windows.Forms.TextBox
        Me.labelEntrada = New System.Windows.Forms.Label
        Me.txt_obs = New System.Windows.Forms.TextBox
        Me.lbl_obs = New System.Windows.Forms.Label
        Me.cbo_vendedor = New System.Windows.Forms.ComboBox
        Me.txt_consumo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbl_vendedor = New System.Windows.Forms.Label
        Me.txt_operador = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtp_emissao = New System.Windows.Forms.DateTimePicker
        Me.txt_pedido = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_pedido = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dtg_pedidoprotaentrega = New System.Windows.Forms.DataGridView
        Me.no_idpk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.no_filial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.no_codpr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cdbarra = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.no_produt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.no_und = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.no_qtde = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.no_prunit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.no_prtot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.no_pesob = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.no_pesoliq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.alqIcms = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.linha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.alqcom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comis = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.basesub = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.alqsub = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.vlsub = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grupo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.alqdesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.vldesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.filial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.baseicms = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.outrasDesp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.vlicms = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pcovenda = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grade = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.corGrade = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tmGrade = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.idgrade = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.pdRelatPedidos = New System.Drawing.Printing.PrintDocument
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.pdRelatPedidos2 = New System.Drawing.Printing.PrintDocument
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.grp_pedido.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grp_registra.SuspendLayout()
        Me.grp_descontos.SuspendLayout()
        Me.grp_total.SuspendLayout()
        Me.grp_peso.SuspendLayout()
        Me.grp_condicoes.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_pedidoprotaentrega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp_pedido
        '
        Me.grp_pedido.Controls.Add(Me.Label11)
        Me.grp_pedido.Controls.Add(Me.cbo_condpgto)
        Me.grp_pedido.Controls.Add(Me.cbo_forpgto)
        Me.grp_pedido.Controls.Add(Me.lbl_formpagto)
        Me.grp_pedido.Controls.Add(Me.chk_rota)
        Me.grp_pedido.Controls.Add(Me.Label14)
        Me.grp_pedido.Controls.Add(Me.cbo_tipopedido)
        Me.grp_pedido.Controls.Add(Me.cbo_rota)
        Me.grp_pedido.Controls.Add(Me.msk_senha)
        Me.grp_pedido.Controls.Add(Me.cbo_gerente)
        Me.grp_pedido.Controls.Add(Me.GroupBox1)
        Me.grp_pedido.Controls.Add(Me.grp_descontos)
        Me.grp_pedido.Controls.Add(Me.grp_total)
        Me.grp_pedido.Controls.Add(Me.grp_peso)
        Me.grp_pedido.Controls.Add(Me.grp_condicoes)
        Me.grp_pedido.Controls.Add(Me.Label9)
        Me.grp_pedido.Controls.Add(Me.cbo_local)
        Me.grp_pedido.Controls.Add(Me.txt_codpart)
        Me.grp_pedido.Controls.Add(Me.lbl_senha)
        Me.grp_pedido.Controls.Add(Me.txt_entrada)
        Me.grp_pedido.Controls.Add(Me.labelEntrada)
        Me.grp_pedido.Controls.Add(Me.txt_obs)
        Me.grp_pedido.Controls.Add(Me.lbl_obs)
        Me.grp_pedido.Controls.Add(Me.cbo_vendedor)
        Me.grp_pedido.Controls.Add(Me.txt_consumo)
        Me.grp_pedido.Controls.Add(Me.Label8)
        Me.grp_pedido.Controls.Add(Me.lbl_vendedor)
        Me.grp_pedido.Controls.Add(Me.txt_operador)
        Me.grp_pedido.Controls.Add(Me.Label6)
        Me.grp_pedido.Controls.Add(Me.Label5)
        Me.grp_pedido.Controls.Add(Me.Label4)
        Me.grp_pedido.Controls.Add(Me.txt_nomePart)
        Me.grp_pedido.Controls.Add(Me.Label3)
        Me.grp_pedido.Controls.Add(Me.dtp_emissao)
        Me.grp_pedido.Controls.Add(Me.txt_pedido)
        Me.grp_pedido.Controls.Add(Me.Label2)
        Me.grp_pedido.Controls.Add(Me.lbl_pedido)
        Me.grp_pedido.Location = New System.Drawing.Point(14, 62)
        Me.grp_pedido.Name = "grp_pedido"
        Me.grp_pedido.Size = New System.Drawing.Size(835, 280)
        Me.grp_pedido.TabIndex = 0
        Me.grp_pedido.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 96
        Me.Label11.Text = "CondPagto:"
        '
        'cbo_condpgto
        '
        Me.cbo_condpgto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_condpgto.DropDownWidth = 200
        Me.cbo_condpgto.FormattingEnabled = True
        Me.cbo_condpgto.Items.AddRange(New Object() {"0", "15", "30", "30/45"})
        Me.cbo_condpgto.Location = New System.Drawing.Point(77, 150)
        Me.cbo_condpgto.Name = "cbo_condpgto"
        Me.cbo_condpgto.Size = New System.Drawing.Size(105, 21)
        Me.cbo_condpgto.TabIndex = 14
        '
        'cbo_forpgto
        '
        Me.cbo_forpgto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_forpgto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_forpgto.FormattingEnabled = True
        Me.cbo_forpgto.Items.AddRange(New Object() {"AV", "NP", "CH", "BL", "CT", "CR"})
        Me.cbo_forpgto.Location = New System.Drawing.Point(279, 149)
        Me.cbo_forpgto.Name = "cbo_forpgto"
        Me.cbo_forpgto.Size = New System.Drawing.Size(64, 23)
        Me.cbo_forpgto.TabIndex = 15
        '
        'lbl_formpagto
        '
        Me.lbl_formpagto.AutoSize = True
        Me.lbl_formpagto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_formpagto.Location = New System.Drawing.Point(209, 152)
        Me.lbl_formpagto.Name = "lbl_formpagto"
        Me.lbl_formpagto.Size = New System.Drawing.Size(64, 15)
        Me.lbl_formpagto.TabIndex = 95
        Me.lbl_formpagto.Text = "FormPgto:"
        '
        'chk_rota
        '
        Me.chk_rota.AutoSize = True
        Me.chk_rota.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_rota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_rota.Location = New System.Drawing.Point(555, 84)
        Me.chk_rota.Name = "chk_rota"
        Me.chk_rota.Size = New System.Drawing.Size(15, 14)
        Me.chk_rota.TabIndex = 78
        Me.chk_rota.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(301, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 77
        Me.Label14.Text = "Tipo:"
        '
        'cbo_tipopedido
        '
        Me.cbo_tipopedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipopedido.FormattingEnabled = True
        Me.cbo_tipopedido.Items.AddRange(New Object() {"Venda", "A Entregar", "Devolução", "Bonificação"})
        Me.cbo_tipopedido.Location = New System.Drawing.Point(338, 79)
        Me.cbo_tipopedido.Name = "cbo_tipopedido"
        Me.cbo_tipopedido.Size = New System.Drawing.Size(82, 21)
        Me.cbo_tipopedido.TabIndex = 8
        '
        'cbo_rota
        '
        Me.cbo_rota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_rota.DropDownWidth = 130
        Me.cbo_rota.FormattingEnabled = True
        Me.cbo_rota.Items.AddRange(New Object() {"01", "02"})
        Me.cbo_rota.Location = New System.Drawing.Point(477, 79)
        Me.cbo_rota.Name = "cbo_rota"
        Me.cbo_rota.Size = New System.Drawing.Size(68, 21)
        Me.cbo_rota.TabIndex = 9
        '
        'msk_senha
        '
        Me.msk_senha.Location = New System.Drawing.Point(212, 79)
        Me.msk_senha.Name = "msk_senha"
        Me.msk_senha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.msk_senha.Size = New System.Drawing.Size(75, 20)
        Me.msk_senha.TabIndex = 7
        '
        'cbo_gerente
        '
        Me.cbo_gerente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_gerente.DropDownWidth = 90
        Me.cbo_gerente.FormattingEnabled = True
        Me.cbo_gerente.Items.AddRange(New Object() {"01", "02"})
        Me.cbo_gerente.Location = New System.Drawing.Point(76, 79)
        Me.cbo_gerente.Name = "cbo_gerente"
        Me.cbo_gerente.Size = New System.Drawing.Size(71, 21)
        Me.cbo_gerente.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txt_valor)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txt_codProd)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.grp_registra)
        Me.GroupBox1.Controls.Add(Me.txt_nomeProd)
        Me.GroupBox1.Controls.Add(Me.txt_qtde)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_desconto)
        Me.GroupBox1.Controls.Add(Me.lbl_desconto)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 205)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(822, 69)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(171, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Descrição"
        '
        'txt_valor
        '
        Me.txt_valor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valor.Location = New System.Drawing.Point(467, 33)
        Me.txt_valor.MaxLength = 14
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.ReadOnly = True
        Me.txt_valor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_valor.Size = New System.Drawing.Size(93, 22)
        Me.txt_valor.TabIndex = 29
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(474, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Pco. Venda"
        '
        'txt_codProd
        '
        Me.txt_codProd.Location = New System.Drawing.Point(6, 34)
        Me.txt_codProd.MaxLength = 14
        Me.txt_codProd.Name = "txt_codProd"
        Me.txt_codProd.Size = New System.Drawing.Size(90, 20)
        Me.txt_codProd.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "CodProd"
        '
        'grp_registra
        '
        Me.grp_registra.Controls.Add(Me.btn_finalizar)
        Me.grp_registra.Controls.Add(Me.btn_alterar)
        Me.grp_registra.Controls.Add(Me.btn_excluir)
        Me.grp_registra.Controls.Add(Me.btn_incluir)
        Me.grp_registra.Location = New System.Drawing.Point(632, 8)
        Me.grp_registra.Name = "grp_registra"
        Me.grp_registra.Size = New System.Drawing.Size(186, 55)
        Me.grp_registra.TabIndex = 33
        Me.grp_registra.TabStop = False
        '
        'btn_finalizar
        '
        Me.btn_finalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalizar.Image = Global.MetroSys.My.Resources.Resources.Info
        Me.btn_finalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_finalizar.Location = New System.Drawing.Point(138, 11)
        Me.btn_finalizar.Name = "btn_finalizar"
        Me.btn_finalizar.Size = New System.Drawing.Size(44, 40)
        Me.btn_finalizar.TabIndex = 43
        Me.btn_finalizar.Text = "&Fim"
        Me.btn_finalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_finalizar.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.Modify
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(48, 11)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(44, 40)
        Me.btn_alterar.TabIndex = 39
        Me.btn_alterar.Text = "&Alt"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_excluir.Location = New System.Drawing.Point(93, 11)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(44, 40)
        Me.btn_excluir.TabIndex = 41
        Me.btn_excluir.Text = "&Exc"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_incluir
        '
        Me.btn_incluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_incluir.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.Location = New System.Drawing.Point(3, 11)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(44, 40)
        Me.btn_incluir.TabIndex = 37
        Me.btn_incluir.Text = "&Inc"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'txt_nomeProd
        '
        Me.txt_nomeProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomeProd.Location = New System.Drawing.Point(102, 33)
        Me.txt_nomeProd.Name = "txt_nomeProd"
        Me.txt_nomeProd.ReadOnly = True
        Me.txt_nomeProd.Size = New System.Drawing.Size(266, 21)
        Me.txt_nomeProd.TabIndex = 25
        '
        'txt_qtde
        '
        Me.txt_qtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtde.Location = New System.Drawing.Point(379, 33)
        Me.txt_qtde.MaxLength = 9
        Me.txt_qtde.Name = "txt_qtde"
        Me.txt_qtde.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_qtde.Size = New System.Drawing.Size(83, 22)
        Me.txt_qtde.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(384, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Quantidade"
        '
        'txt_desconto
        '
        Me.txt_desconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desconto.Location = New System.Drawing.Point(566, 34)
        Me.txt_desconto.MaxLength = 6
        Me.txt_desconto.Name = "txt_desconto"
        Me.txt_desconto.ReadOnly = True
        Me.txt_desconto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_desconto.Size = New System.Drawing.Size(59, 21)
        Me.txt_desconto.TabIndex = 31
        '
        'lbl_desconto
        '
        Me.lbl_desconto.AutoSize = True
        Me.lbl_desconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_desconto.Location = New System.Drawing.Point(565, 16)
        Me.lbl_desconto.Name = "lbl_desconto"
        Me.lbl_desconto.Size = New System.Drawing.Size(61, 13)
        Me.lbl_desconto.TabIndex = 58
        Me.lbl_desconto.Text = "Desc.(%):"
        '
        'grp_descontos
        '
        Me.grp_descontos.Controls.Add(Me.txt_descontosTotais)
        Me.grp_descontos.Location = New System.Drawing.Point(669, 108)
        Me.grp_descontos.Name = "grp_descontos"
        Me.grp_descontos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grp_descontos.Size = New System.Drawing.Size(158, 50)
        Me.grp_descontos.TabIndex = 31
        Me.grp_descontos.TabStop = False
        Me.grp_descontos.Text = "Descontos:"
        '
        'txt_descontosTotais
        '
        Me.txt_descontosTotais.BackColor = System.Drawing.SystemColors.Info
        Me.txt_descontosTotais.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descontosTotais.ForeColor = System.Drawing.Color.Red
        Me.txt_descontosTotais.Location = New System.Drawing.Point(27, 16)
        Me.txt_descontosTotais.MaxLength = 16
        Me.txt_descontosTotais.Name = "txt_descontosTotais"
        Me.txt_descontosTotais.ReadOnly = True
        Me.txt_descontosTotais.Size = New System.Drawing.Size(109, 26)
        Me.txt_descontosTotais.TabIndex = 32
        Me.txt_descontosTotais.Text = "0,00"
        '
        'grp_total
        '
        Me.grp_total.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.grp_total.Controls.Add(Me.txt_total)
        Me.grp_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_total.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grp_total.Location = New System.Drawing.Point(669, 57)
        Me.grp_total.Name = "grp_total"
        Me.grp_total.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grp_total.Size = New System.Drawing.Size(159, 49)
        Me.grp_total.TabIndex = 29
        Me.grp_total.TabStop = False
        Me.grp_total.Text = "Total R$"
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.Info
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Blue
        Me.txt_total.Location = New System.Drawing.Point(27, 17)
        Me.txt_total.MaxLength = 12
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_total.Size = New System.Drawing.Size(109, 26)
        Me.txt_total.TabIndex = 30
        Me.txt_total.Text = "0,00"
        '
        'grp_peso
        '
        Me.grp_peso.Controls.Add(Me.txt_peso)
        Me.grp_peso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_peso.Location = New System.Drawing.Point(669, 8)
        Me.grp_peso.Name = "grp_peso"
        Me.grp_peso.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grp_peso.Size = New System.Drawing.Size(158, 46)
        Me.grp_peso.TabIndex = 27
        Me.grp_peso.TabStop = False
        Me.grp_peso.Text = "Peso"
        '
        'txt_peso
        '
        Me.txt_peso.BackColor = System.Drawing.SystemColors.Info
        Me.txt_peso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_peso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt_peso.Location = New System.Drawing.Point(27, 15)
        Me.txt_peso.MaxLength = 12
        Me.txt_peso.Name = "txt_peso"
        Me.txt_peso.ReadOnly = True
        Me.txt_peso.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_peso.Size = New System.Drawing.Size(109, 26)
        Me.txt_peso.TabIndex = 28
        Me.txt_peso.Text = "0,000"
        '
        'grp_condicoes
        '
        Me.grp_condicoes.Controls.Add(Me.txt_cond7)
        Me.grp_condicoes.Controls.Add(Me.txt_cond6)
        Me.grp_condicoes.Controls.Add(Me.txt_cond5)
        Me.grp_condicoes.Controls.Add(Me.txt_cond4)
        Me.grp_condicoes.Controls.Add(Me.txt_cond3)
        Me.grp_condicoes.Controls.Add(Me.txt_cond2)
        Me.grp_condicoes.Controls.Add(Me.txt_cond1)
        Me.grp_condicoes.Location = New System.Drawing.Point(582, 162)
        Me.grp_condicoes.Name = "grp_condicoes"
        Me.grp_condicoes.Size = New System.Drawing.Size(246, 41)
        Me.grp_condicoes.TabIndex = 29
        Me.grp_condicoes.TabStop = False
        Me.grp_condicoes.Text = "Condições:"
        '
        'txt_cond7
        '
        Me.txt_cond7.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cond7.Location = New System.Drawing.Point(208, 15)
        Me.txt_cond7.MaxLength = 3
        Me.txt_cond7.Name = "txt_cond7"
        Me.txt_cond7.ReadOnly = True
        Me.txt_cond7.Size = New System.Drawing.Size(27, 20)
        Me.txt_cond7.TabIndex = 36
        Me.txt_cond7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_cond6
        '
        Me.txt_cond6.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cond6.Location = New System.Drawing.Point(175, 15)
        Me.txt_cond6.MaxLength = 3
        Me.txt_cond6.Name = "txt_cond6"
        Me.txt_cond6.ReadOnly = True
        Me.txt_cond6.Size = New System.Drawing.Size(27, 20)
        Me.txt_cond6.TabIndex = 35
        Me.txt_cond6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_cond5
        '
        Me.txt_cond5.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cond5.Location = New System.Drawing.Point(142, 15)
        Me.txt_cond5.MaxLength = 3
        Me.txt_cond5.Name = "txt_cond5"
        Me.txt_cond5.ReadOnly = True
        Me.txt_cond5.Size = New System.Drawing.Size(27, 20)
        Me.txt_cond5.TabIndex = 34
        Me.txt_cond5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_cond4
        '
        Me.txt_cond4.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cond4.Location = New System.Drawing.Point(109, 15)
        Me.txt_cond4.MaxLength = 3
        Me.txt_cond4.Name = "txt_cond4"
        Me.txt_cond4.ReadOnly = True
        Me.txt_cond4.Size = New System.Drawing.Size(27, 20)
        Me.txt_cond4.TabIndex = 33
        Me.txt_cond4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_cond3
        '
        Me.txt_cond3.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cond3.Location = New System.Drawing.Point(77, 15)
        Me.txt_cond3.MaxLength = 3
        Me.txt_cond3.Name = "txt_cond3"
        Me.txt_cond3.ReadOnly = True
        Me.txt_cond3.Size = New System.Drawing.Size(27, 20)
        Me.txt_cond3.TabIndex = 32
        Me.txt_cond3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_cond2
        '
        Me.txt_cond2.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cond2.Location = New System.Drawing.Point(44, 15)
        Me.txt_cond2.MaxLength = 3
        Me.txt_cond2.Name = "txt_cond2"
        Me.txt_cond2.ReadOnly = True
        Me.txt_cond2.Size = New System.Drawing.Size(27, 20)
        Me.txt_cond2.TabIndex = 31
        Me.txt_cond2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_cond1
        '
        Me.txt_cond1.BackColor = System.Drawing.SystemColors.Info
        Me.txt_cond1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_cond1.Location = New System.Drawing.Point(12, 15)
        Me.txt_cond1.MaxLength = 3
        Me.txt_cond1.Name = "txt_cond1"
        Me.txt_cond1.ReadOnly = True
        Me.txt_cond1.Size = New System.Drawing.Size(27, 20)
        Me.txt_cond1.TabIndex = 30
        Me.txt_cond1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 15)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Loja :"
        '
        'cbo_local
        '
        Me.cbo_local.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_local.DropDownWidth = 150
        Me.cbo_local.Enabled = False
        Me.cbo_local.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_local.FormattingEnabled = True
        Me.cbo_local.Items.AddRange(New Object() {"01", "02", "03", "04", "05"})
        Me.cbo_local.Location = New System.Drawing.Point(76, 12)
        Me.cbo_local.Name = "cbo_local"
        Me.cbo_local.Size = New System.Drawing.Size(89, 23)
        Me.cbo_local.TabIndex = 1
        '
        'txt_codpart
        '
        Me.txt_codpart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codpart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codpart.Location = New System.Drawing.Point(77, 47)
        Me.txt_codpart.MaxLength = 6
        Me.txt_codpart.Name = "txt_codpart"
        Me.txt_codpart.Size = New System.Drawing.Size(70, 21)
        Me.txt_codpart.TabIndex = 4
        '
        'lbl_senha
        '
        Me.lbl_senha.AutoSize = True
        Me.lbl_senha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_senha.Location = New System.Drawing.Point(160, 81)
        Me.lbl_senha.Name = "lbl_senha"
        Me.lbl_senha.Size = New System.Drawing.Size(46, 15)
        Me.lbl_senha.TabIndex = 55
        Me.lbl_senha.Text = "Senha:"
        '
        'txt_entrada
        '
        Me.txt_entrada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_entrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_entrada.Location = New System.Drawing.Point(477, 149)
        Me.txt_entrada.MaxLength = 14
        Me.txt_entrada.Name = "txt_entrada"
        Me.txt_entrada.ReadOnly = True
        Me.txt_entrada.Size = New System.Drawing.Size(93, 21)
        Me.txt_entrada.TabIndex = 16
        Me.txt_entrada.Text = "0,00"
        Me.txt_entrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'labelEntrada
        '
        Me.labelEntrada.AutoSize = True
        Me.labelEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelEntrada.Location = New System.Drawing.Point(364, 152)
        Me.labelEntrada.Name = "labelEntrada"
        Me.labelEntrada.Size = New System.Drawing.Size(107, 15)
        Me.labelEntrada.TabIndex = 54
        Me.labelEntrada.Text = "PorConta/Entrada:"
        '
        'txt_obs
        '
        Me.txt_obs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_obs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_obs.Location = New System.Drawing.Point(76, 182)
        Me.txt_obs.MaxLength = 79
        Me.txt_obs.Name = "txt_obs"
        Me.txt_obs.Size = New System.Drawing.Size(494, 21)
        Me.txt_obs.TabIndex = 17
        '
        'lbl_obs
        '
        Me.lbl_obs.AutoSize = True
        Me.lbl_obs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_obs.Location = New System.Drawing.Point(2, 185)
        Me.lbl_obs.Name = "lbl_obs"
        Me.lbl_obs.Size = New System.Drawing.Size(51, 15)
        Me.lbl_obs.TabIndex = 54
        Me.lbl_obs.Text = "Observ.:"
        '
        'cbo_vendedor
        '
        Me.cbo_vendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_vendedor.FormattingEnabled = True
        Me.cbo_vendedor.Location = New System.Drawing.Point(426, 113)
        Me.cbo_vendedor.Name = "cbo_vendedor"
        Me.cbo_vendedor.Size = New System.Drawing.Size(144, 23)
        Me.cbo_vendedor.TabIndex = 13
        '
        'txt_consumo
        '
        Me.txt_consumo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_consumo.Location = New System.Drawing.Point(317, 114)
        Me.txt_consumo.MaxLength = 1
        Me.txt_consumo.Name = "txt_consumo"
        Me.txt_consumo.Size = New System.Drawing.Size(27, 21)
        Me.txt_consumo.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(248, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 15)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Consumo:"
        '
        'lbl_vendedor
        '
        Me.lbl_vendedor.AutoSize = True
        Me.lbl_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_vendedor.Location = New System.Drawing.Point(357, 117)
        Me.lbl_vendedor.Name = "lbl_vendedor"
        Me.lbl_vendedor.Size = New System.Drawing.Size(63, 15)
        Me.lbl_vendedor.TabIndex = 49
        Me.lbl_vendedor.Text = "Vendedor:"
        '
        'txt_operador
        '
        Me.txt_operador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_operador.Location = New System.Drawing.Point(76, 114)
        Me.txt_operador.MaxLength = 10
        Me.txt_operador.Name = "txt_operador"
        Me.txt_operador.ReadOnly = True
        Me.txt_operador.Size = New System.Drawing.Size(155, 21)
        Me.txt_operador.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 15)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Operador:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(435, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 15)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Rota:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 15)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Gerente  :"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomePart.Location = New System.Drawing.Point(159, 48)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(411, 21)
        Me.txt_nomePart.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Cliente:"
        '
        'dtp_emissao
        '
        Me.dtp_emissao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_emissao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_emissao.Location = New System.Drawing.Point(477, 14)
        Me.dtp_emissao.Name = "dtp_emissao"
        Me.dtp_emissao.Size = New System.Drawing.Size(93, 21)
        Me.dtp_emissao.TabIndex = 3
        '
        'txt_pedido
        '
        Me.txt_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pedido.Location = New System.Drawing.Point(243, 14)
        Me.txt_pedido.MaxLength = 8
        Me.txt_pedido.Name = "txt_pedido"
        Me.txt_pedido.ReadOnly = True
        Me.txt_pedido.Size = New System.Drawing.Size(100, 21)
        Me.txt_pedido.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(381, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "DataPedido:"
        '
        'lbl_pedido
        '
        Me.lbl_pedido.AutoSize = True
        Me.lbl_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pedido.Location = New System.Drawing.Point(188, 17)
        Me.lbl_pedido.Name = "lbl_pedido"
        Me.lbl_pedido.Size = New System.Drawing.Size(49, 15)
        Me.lbl_pedido.TabIndex = 32
        Me.lbl_pedido.Text = "Pedido:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(730, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 25)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(863, 62)
        Me.Panel1.TabIndex = 35
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(343, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(187, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'dtg_pedidoprotaentrega
        '
        Me.dtg_pedidoprotaentrega.AllowUserToAddRows = False
        Me.dtg_pedidoprotaentrega.AllowUserToDeleteRows = False
        Me.dtg_pedidoprotaentrega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_pedidoprotaentrega.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.no_idpk, Me.no_filial, Me.no_codpr, Me.cdbarra, Me.no_produt, Me.no_und, Me.no_qtde, Me.no_prunit, Me.no_prtot, Me.no_pesob, Me.no_pesoliq, Me.alqIcms, Me.linha, Me.alqcom, Me.comis, Me.basesub, Me.alqsub, Me.vlsub, Me.grupo, Me.alqdesc, Me.vldesc, Me.filial, Me.baseicms, Me.outrasDesp, Me.vlicms, Me.pcovenda, Me.grade, Me.corGrade, Me.tmGrade, Me.idgrade})
        Me.dtg_pedidoprotaentrega.Location = New System.Drawing.Point(14, 348)
        Me.dtg_pedidoprotaentrega.Name = "dtg_pedidoprotaentrega"
        Me.dtg_pedidoprotaentrega.ReadOnly = True
        Me.dtg_pedidoprotaentrega.Size = New System.Drawing.Size(835, 267)
        Me.dtg_pedidoprotaentrega.TabIndex = 28
        '
        'no_idpk
        '
        Me.no_idpk.HeaderText = "ID"
        Me.no_idpk.MaxInputLength = 5
        Me.no_idpk.Name = "no_idpk"
        Me.no_idpk.ReadOnly = True
        Me.no_idpk.Visible = False
        Me.no_idpk.Width = 45
        '
        'no_filial
        '
        Me.no_filial.HeaderText = "Loja"
        Me.no_filial.MaxInputLength = 3
        Me.no_filial.Name = "no_filial"
        Me.no_filial.ReadOnly = True
        Me.no_filial.Width = 40
        '
        'no_codpr
        '
        Me.no_codpr.HeaderText = "Codigo"
        Me.no_codpr.MaxInputLength = 14
        Me.no_codpr.MinimumWidth = 6
        Me.no_codpr.Name = "no_codpr"
        Me.no_codpr.ReadOnly = True
        Me.no_codpr.Width = 115
        '
        'cdbarra
        '
        Me.cdbarra.HeaderText = "CodBarra"
        Me.cdbarra.MaxInputLength = 14
        Me.cdbarra.Name = "cdbarra"
        Me.cdbarra.ReadOnly = True
        Me.cdbarra.Visible = False
        Me.cdbarra.Width = 115
        '
        'no_produt
        '
        Me.no_produt.HeaderText = "Produto"
        Me.no_produt.MinimumWidth = 20
        Me.no_produt.Name = "no_produt"
        Me.no_produt.ReadOnly = True
        Me.no_produt.Width = 300
        '
        'no_und
        '
        Me.no_und.HeaderText = "Und"
        Me.no_und.MaxInputLength = 3
        Me.no_und.Name = "no_und"
        Me.no_und.ReadOnly = True
        Me.no_und.Width = 50
        '
        'no_qtde
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.no_qtde.DefaultCellStyle = DataGridViewCellStyle1
        Me.no_qtde.HeaderText = "Quantidade"
        Me.no_qtde.Name = "no_qtde"
        Me.no_qtde.ReadOnly = True
        Me.no_qtde.Width = 82
        '
        'no_prunit
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.no_prunit.DefaultCellStyle = DataGridViewCellStyle2
        Me.no_prunit.HeaderText = "PcoVenda"
        Me.no_prunit.Name = "no_prunit"
        Me.no_prunit.ReadOnly = True
        '
        'no_prtot
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.no_prtot.DefaultCellStyle = DataGridViewCellStyle3
        Me.no_prtot.HeaderText = "PcoTotal"
        Me.no_prtot.Name = "no_prtot"
        Me.no_prtot.ReadOnly = True
        Me.no_prtot.Width = 105
        '
        'no_pesob
        '
        Me.no_pesob.HeaderText = "PesoBruto"
        Me.no_pesob.Name = "no_pesob"
        Me.no_pesob.ReadOnly = True
        Me.no_pesob.Visible = False
        '
        'no_pesoliq
        '
        Me.no_pesoliq.HeaderText = "PesoLiq"
        Me.no_pesoliq.Name = "no_pesoliq"
        Me.no_pesoliq.ReadOnly = True
        Me.no_pesoliq.Visible = False
        '
        'alqIcms
        '
        Me.alqIcms.HeaderText = "AlqIcms"
        Me.alqIcms.Name = "alqIcms"
        Me.alqIcms.ReadOnly = True
        Me.alqIcms.Visible = False
        '
        'linha
        '
        Me.linha.HeaderText = "linha"
        Me.linha.Name = "linha"
        Me.linha.ReadOnly = True
        Me.linha.Visible = False
        '
        'alqcom
        '
        Me.alqcom.HeaderText = "AlqCom"
        Me.alqcom.Name = "alqcom"
        Me.alqcom.ReadOnly = True
        Me.alqcom.Visible = False
        '
        'comis
        '
        Me.comis.HeaderText = "Comis"
        Me.comis.Name = "comis"
        Me.comis.ReadOnly = True
        Me.comis.Visible = False
        '
        'basesub
        '
        Me.basesub.HeaderText = "BaseSub"
        Me.basesub.Name = "basesub"
        Me.basesub.ReadOnly = True
        Me.basesub.Visible = False
        '
        'alqsub
        '
        Me.alqsub.HeaderText = "AlqSub"
        Me.alqsub.Name = "alqsub"
        Me.alqsub.ReadOnly = True
        Me.alqsub.Visible = False
        '
        'vlsub
        '
        Me.vlsub.HeaderText = "VlSub"
        Me.vlsub.Name = "vlsub"
        Me.vlsub.ReadOnly = True
        Me.vlsub.Visible = False
        '
        'grupo
        '
        Me.grupo.HeaderText = "Grupo"
        Me.grupo.Name = "grupo"
        Me.grupo.ReadOnly = True
        Me.grupo.Visible = False
        '
        'alqdesc
        '
        Me.alqdesc.HeaderText = "AlqDesc"
        Me.alqdesc.Name = "alqdesc"
        Me.alqdesc.ReadOnly = True
        Me.alqdesc.Visible = False
        '
        'vldesc
        '
        Me.vldesc.HeaderText = "VlDesc"
        Me.vldesc.Name = "vldesc"
        Me.vldesc.ReadOnly = True
        Me.vldesc.Visible = False
        '
        'filial
        '
        Me.filial.HeaderText = "Filial"
        Me.filial.Name = "filial"
        Me.filial.ReadOnly = True
        Me.filial.Visible = False
        '
        'baseicms
        '
        Me.baseicms.HeaderText = "BaseIcms"
        Me.baseicms.Name = "baseicms"
        Me.baseicms.ReadOnly = True
        Me.baseicms.Visible = False
        '
        'outrasDesp
        '
        Me.outrasDesp.HeaderText = "OutrasDesp"
        Me.outrasDesp.Name = "outrasDesp"
        Me.outrasDesp.ReadOnly = True
        Me.outrasDesp.Visible = False
        '
        'vlicms
        '
        Me.vlicms.HeaderText = "VlIcms"
        Me.vlicms.Name = "vlicms"
        Me.vlicms.ReadOnly = True
        Me.vlicms.Visible = False
        '
        'pcovenda
        '
        Me.pcovenda.HeaderText = "PrecoUnitario"
        Me.pcovenda.Name = "pcovenda"
        Me.pcovenda.ReadOnly = True
        Me.pcovenda.Visible = False
        '
        'grade
        '
        Me.grade.HeaderText = "Grade"
        Me.grade.Name = "grade"
        Me.grade.ReadOnly = True
        Me.grade.Visible = False
        '
        'corGrade
        '
        Me.corGrade.HeaderText = "CorGrade"
        Me.corGrade.Name = "corGrade"
        Me.corGrade.ReadOnly = True
        Me.corGrade.Visible = False
        '
        'tmGrade
        '
        Me.tmGrade.HeaderText = "TmGrade"
        Me.tmGrade.Name = "tmGrade"
        Me.tmGrade.ReadOnly = True
        Me.tmGrade.Visible = False
        '
        'idgrade
        '
        Me.idgrade.HeaderText = "IdGrade"
        Me.idgrade.Name = "idgrade"
        Me.idgrade.ReadOnly = True
        Me.idgrade.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 616)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(835, 49)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(15, 21)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(24, 16)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = ".   "
        '
        'pdRelatPedidos
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'pdRelatPedidos2
        '
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(726, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 37)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'Frm_PedidoProntEntrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 672)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dtg_pedidoprotaentrega)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grp_pedido)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_PedidoProntEntrega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedido de Venda"
        Me.grp_pedido.ResumeLayout(False)
        Me.grp_pedido.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp_registra.ResumeLayout(False)
        Me.grp_descontos.ResumeLayout(False)
        Me.grp_descontos.PerformLayout()
        Me.grp_total.ResumeLayout(False)
        Me.grp_total.PerformLayout()
        Me.grp_peso.ResumeLayout(False)
        Me.grp_peso.PerformLayout()
        Me.grp_condicoes.ResumeLayout(False)
        Me.grp_condicoes.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_pedidoprotaentrega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp_pedido As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_qtde As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_desconto As System.Windows.Forms.Label
    Friend WithEvents txt_desconto As System.Windows.Forms.TextBox
    Friend WithEvents lbl_senha As System.Windows.Forms.Label
    Public WithEvents txt_obs As System.Windows.Forms.TextBox
    Friend WithEvents lbl_obs As System.Windows.Forms.Label
    Public WithEvents cbo_vendedor As System.Windows.Forms.ComboBox
    Public WithEvents txt_consumo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl_vendedor As System.Windows.Forms.Label
    Public WithEvents txt_operador As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents dtp_emissao As System.Windows.Forms.DateTimePicker
    Public WithEvents txt_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_pedido As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grp_registra As System.Windows.Forms.GroupBox
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Public WithEvents btn_excluir As System.Windows.Forms.Button
    Public WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents grp_descontos As System.Windows.Forms.GroupBox
    Friend WithEvents txt_descontosTotais As System.Windows.Forms.TextBox
    Friend WithEvents grp_total As System.Windows.Forms.GroupBox
    Public WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents grp_peso As System.Windows.Forms.GroupBox
    Public WithEvents txt_peso As System.Windows.Forms.TextBox
    Friend WithEvents grp_condicoes As System.Windows.Forms.GroupBox
    Public WithEvents txt_cond4 As System.Windows.Forms.TextBox
    Public WithEvents txt_cond3 As System.Windows.Forms.TextBox
    Public WithEvents txt_cond2 As System.Windows.Forms.TextBox
    Public WithEvents txt_cond1 As System.Windows.Forms.TextBox
    Friend WithEvents cbo_gerente As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents msk_senha As System.Windows.Forms.MaskedTextBox
    Public WithEvents btn_finalizar As System.Windows.Forms.Button
    Friend WithEvents dtg_pedidoprotaentrega As System.Windows.Forms.DataGridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbo_rota As System.Windows.Forms.ComboBox
    Public WithEvents txt_cond7 As System.Windows.Forms.TextBox
    Public WithEvents txt_cond6 As System.Windows.Forms.TextBox
    Public WithEvents txt_cond5 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_tipopedido As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents txt_codpart As System.Windows.Forms.TextBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Public WithEvents txt_codProd As System.Windows.Forms.TextBox
    Public WithEvents txt_nomeProd As System.Windows.Forms.TextBox
    Public WithEvents cbo_local As System.Windows.Forms.ComboBox
    Friend WithEvents pdRelatPedidos As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents chk_rota As System.Windows.Forms.CheckBox
    Friend WithEvents pdRelatPedidos2 As System.Drawing.Printing.PrintDocument
    Public WithEvents txt_entrada As System.Windows.Forms.TextBox
    Friend WithEvents labelEntrada As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbo_condpgto As System.Windows.Forms.ComboBox
    Public WithEvents cbo_forpgto As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_formpagto As System.Windows.Forms.Label
    Friend WithEvents no_idpk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_filial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_codpr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cdbarra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_produt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_und As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_qtde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_prunit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_prtot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_pesob As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_pesoliq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents alqIcms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents linha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents alqcom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents basesub As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents alqsub As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlsub As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents alqdesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vldesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents filial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents baseicms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents outrasDesp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlicms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcovenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents corGrade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tmGrade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idgrade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_valor As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
