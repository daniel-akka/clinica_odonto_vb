<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_OrcamentoAlt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_OrcamentoAlt))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grp_pedido = New System.Windows.Forms.GroupBox
        Me.cbo_vendedor = New System.Windows.Forms.ComboBox
        Me.lbl_vendedor = New System.Windows.Forms.Label
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
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbo_local = New System.Windows.Forms.ComboBox
        Me.txt_codpart = New System.Windows.Forms.TextBox
        Me.txt_obs = New System.Windows.Forms.TextBox
        Me.lbl_obs = New System.Windows.Forms.Label
        Me.txt_operador = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtp_emissao = New System.Windows.Forms.DateTimePicker
        Me.txt_orcamento = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_pedido = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.pdRelatPedidos = New System.Drawing.Printing.PrintDocument
        Me.dtg_pedidoprotaentrega = New System.Windows.Forms.DataGridView
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
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
        Me.corgrade = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tmgrade = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.idgrade = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grp_pedido.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grp_registra.SuspendLayout()
        Me.grp_descontos.SuspendLayout()
        Me.grp_total.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtg_pedidoprotaentrega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp_pedido
        '
        Me.grp_pedido.Controls.Add(Me.cbo_vendedor)
        Me.grp_pedido.Controls.Add(Me.lbl_vendedor)
        Me.grp_pedido.Controls.Add(Me.GroupBox1)
        Me.grp_pedido.Controls.Add(Me.grp_descontos)
        Me.grp_pedido.Controls.Add(Me.grp_total)
        Me.grp_pedido.Controls.Add(Me.Label9)
        Me.grp_pedido.Controls.Add(Me.cbo_local)
        Me.grp_pedido.Controls.Add(Me.txt_codpart)
        Me.grp_pedido.Controls.Add(Me.txt_obs)
        Me.grp_pedido.Controls.Add(Me.lbl_obs)
        Me.grp_pedido.Controls.Add(Me.txt_operador)
        Me.grp_pedido.Controls.Add(Me.Label6)
        Me.grp_pedido.Controls.Add(Me.txt_nomePart)
        Me.grp_pedido.Controls.Add(Me.Label3)
        Me.grp_pedido.Controls.Add(Me.dtp_emissao)
        Me.grp_pedido.Controls.Add(Me.txt_orcamento)
        Me.grp_pedido.Controls.Add(Me.Label2)
        Me.grp_pedido.Controls.Add(Me.lbl_pedido)
        Me.grp_pedido.Location = New System.Drawing.Point(13, 67)
        Me.grp_pedido.Name = "grp_pedido"
        Me.grp_pedido.Size = New System.Drawing.Size(906, 207)
        Me.grp_pedido.TabIndex = 41
        Me.grp_pedido.TabStop = False
        '
        'cbo_vendedor
        '
        Me.cbo_vendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_vendedor.FormattingEnabled = True
        Me.cbo_vendedor.Location = New System.Drawing.Point(77, 89)
        Me.cbo_vendedor.Name = "cbo_vendedor"
        Me.cbo_vendedor.Size = New System.Drawing.Size(175, 23)
        Me.cbo_vendedor.TabIndex = 9
        '
        'lbl_vendedor
        '
        Me.lbl_vendedor.AutoSize = True
        Me.lbl_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_vendedor.Location = New System.Drawing.Point(9, 92)
        Me.lbl_vendedor.Name = "lbl_vendedor"
        Me.lbl_vendedor.Size = New System.Drawing.Size(63, 15)
        Me.lbl_vendedor.TabIndex = 68
        Me.lbl_vendedor.Text = "Vendedor:"
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
        Me.GroupBox1.Location = New System.Drawing.Point(5, 123)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(895, 73)
        Me.GroupBox1.TabIndex = 17
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
        Me.txt_valor.Location = New System.Drawing.Point(485, 32)
        Me.txt_valor.MaxLength = 14
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.ReadOnly = True
        Me.txt_valor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_valor.Size = New System.Drawing.Size(93, 22)
        Me.txt_valor.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(492, 14)
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
        Me.txt_codProd.TabIndex = 18
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
        Me.grp_registra.Location = New System.Drawing.Point(665, 8)
        Me.grp_registra.Name = "grp_registra"
        Me.grp_registra.Size = New System.Drawing.Size(222, 58)
        Me.grp_registra.TabIndex = 23
        Me.grp_registra.TabStop = False
        '
        'btn_finalizar
        '
        Me.btn_finalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalizar.Image = Global.MetroSys.My.Resources.Resources.Info
        Me.btn_finalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_finalizar.Location = New System.Drawing.Point(167, 11)
        Me.btn_finalizar.Name = "btn_finalizar"
        Me.btn_finalizar.Size = New System.Drawing.Size(50, 43)
        Me.btn_finalizar.TabIndex = 27
        Me.btn_finalizar.Text = "&Fim"
        Me.btn_finalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_finalizar.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.Modify
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(59, 11)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(50, 43)
        Me.btn_alterar.TabIndex = 25
        Me.btn_alterar.Text = "&Alt"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_excluir.Location = New System.Drawing.Point(113, 11)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(50, 43)
        Me.btn_excluir.TabIndex = 26
        Me.btn_excluir.Text = "&Exc"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_incluir
        '
        Me.btn_incluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_incluir.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.Location = New System.Drawing.Point(5, 11)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(50, 43)
        Me.btn_incluir.TabIndex = 24
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
        Me.txt_nomeProd.Size = New System.Drawing.Size(285, 21)
        Me.txt_nomeProd.TabIndex = 19
        '
        'txt_qtde
        '
        Me.txt_qtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtde.Location = New System.Drawing.Point(393, 32)
        Me.txt_qtde.MaxLength = 9
        Me.txt_qtde.Name = "txt_qtde"
        Me.txt_qtde.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_qtde.Size = New System.Drawing.Size(83, 22)
        Me.txt_qtde.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(398, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Quantidade"
        '
        'txt_desconto
        '
        Me.txt_desconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desconto.Location = New System.Drawing.Point(586, 33)
        Me.txt_desconto.MaxLength = 6
        Me.txt_desconto.Name = "txt_desconto"
        Me.txt_desconto.ReadOnly = True
        Me.txt_desconto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_desconto.Size = New System.Drawing.Size(59, 21)
        Me.txt_desconto.TabIndex = 22
        '
        'lbl_desconto
        '
        Me.lbl_desconto.AutoSize = True
        Me.lbl_desconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_desconto.Location = New System.Drawing.Point(585, 14)
        Me.lbl_desconto.Name = "lbl_desconto"
        Me.lbl_desconto.Size = New System.Drawing.Size(61, 13)
        Me.lbl_desconto.TabIndex = 58
        Me.lbl_desconto.Text = "Desc.(%):"
        '
        'grp_descontos
        '
        Me.grp_descontos.Controls.Add(Me.txt_descontosTotais)
        Me.grp_descontos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_descontos.Location = New System.Drawing.Point(742, 63)
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
        Me.grp_total.Location = New System.Drawing.Point(741, 11)
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 21)
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
        Me.cbo_local.Location = New System.Drawing.Point(77, 18)
        Me.cbo_local.Name = "cbo_local"
        Me.cbo_local.Size = New System.Drawing.Size(203, 23)
        Me.cbo_local.TabIndex = 1
        '
        'txt_codpart
        '
        Me.txt_codpart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codpart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codpart.Location = New System.Drawing.Point(77, 54)
        Me.txt_codpart.MaxLength = 6
        Me.txt_codpart.Name = "txt_codpart"
        Me.txt_codpart.Size = New System.Drawing.Size(70, 21)
        Me.txt_codpart.TabIndex = 4
        '
        'txt_obs
        '
        Me.txt_obs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_obs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_obs.Location = New System.Drawing.Point(384, 89)
        Me.txt_obs.MaxLength = 79
        Me.txt_obs.Name = "txt_obs"
        Me.txt_obs.Size = New System.Drawing.Size(334, 21)
        Me.txt_obs.TabIndex = 11
        '
        'lbl_obs
        '
        Me.lbl_obs.AutoSize = True
        Me.lbl_obs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_obs.Location = New System.Drawing.Point(321, 92)
        Me.lbl_obs.Name = "lbl_obs"
        Me.lbl_obs.Size = New System.Drawing.Size(51, 15)
        Me.lbl_obs.TabIndex = 54
        Me.lbl_obs.Text = "Observ.:"
        '
        'txt_operador
        '
        Me.txt_operador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_operador.Location = New System.Drawing.Point(587, 54)
        Me.txt_operador.MaxLength = 10
        Me.txt_operador.Name = "txt_operador"
        Me.txt_operador.ReadOnly = True
        Me.txt_operador.Size = New System.Drawing.Size(131, 21)
        Me.txt_operador.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(519, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 15)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Operador:"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomePart.Location = New System.Drawing.Point(153, 54)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(351, 21)
        Me.txt_nomePart.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Cliente:"
        '
        'dtp_emissao
        '
        Me.dtp_emissao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_emissao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_emissao.Location = New System.Drawing.Point(622, 20)
        Me.dtp_emissao.Name = "dtp_emissao"
        Me.dtp_emissao.Size = New System.Drawing.Size(96, 21)
        Me.dtp_emissao.TabIndex = 3
        '
        'txt_orcamento
        '
        Me.txt_orcamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_orcamento.Location = New System.Drawing.Point(378, 20)
        Me.txt_orcamento.MaxLength = 8
        Me.txt_orcamento.Name = "txt_orcamento"
        Me.txt_orcamento.ReadOnly = True
        Me.txt_orcamento.Size = New System.Drawing.Size(126, 21)
        Me.txt_orcamento.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(526, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "DataPedido:"
        '
        'lbl_pedido
        '
        Me.lbl_pedido.AutoSize = True
        Me.lbl_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pedido.Location = New System.Drawing.Point(301, 23)
        Me.lbl_pedido.Name = "lbl_pedido"
        Me.lbl_pedido.Size = New System.Drawing.Size(71, 15)
        Me.lbl_pedido.TabIndex = 32
        Me.lbl_pedido.Text = "Orçamento:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(732, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 25)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-3, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(937, 69)
        Me.Panel1.TabIndex = 43
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(364, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(199, 58)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 554)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(907, 49)
        Me.GroupBox2.TabIndex = 44
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
        'dtg_pedidoprotaentrega
        '
        Me.dtg_pedidoprotaentrega.AllowUserToAddRows = False
        Me.dtg_pedidoprotaentrega.AllowUserToDeleteRows = False
        Me.dtg_pedidoprotaentrega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_pedidoprotaentrega.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.no_idpk, Me.no_filial, Me.no_codpr, Me.cdbarra, Me.no_produt, Me.no_und, Me.no_qtde, Me.no_prunit, Me.no_prtot, Me.no_pesob, Me.no_pesoliq, Me.alqIcms, Me.linha, Me.alqcom, Me.comis, Me.basesub, Me.alqsub, Me.vlsub, Me.grupo, Me.alqdesc, Me.vldesc, Me.filial, Me.baseicms, Me.outrasDesp, Me.vlicms, Me.pcovenda, Me.grade, Me.corgrade, Me.tmgrade, Me.idgrade})
        Me.dtg_pedidoprotaentrega.Location = New System.Drawing.Point(12, 280)
        Me.dtg_pedidoprotaentrega.Name = "dtg_pedidoprotaentrega"
        Me.dtg_pedidoprotaentrega.ReadOnly = True
        Me.dtg_pedidoprotaentrega.Size = New System.Drawing.Size(907, 267)
        Me.dtg_pedidoprotaentrega.TabIndex = 42
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
        Me.no_produt.MaxInputLength = 80
        Me.no_produt.MinimumWidth = 20
        Me.no_produt.Name = "no_produt"
        Me.no_produt.ReadOnly = True
        Me.no_produt.Width = 350
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
        Me.no_prtot.Width = 125
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
        'corgrade
        '
        Me.corgrade.HeaderText = "CorGrade"
        Me.corgrade.Name = "corgrade"
        Me.corgrade.ReadOnly = True
        Me.corgrade.Visible = False
        '
        'tmgrade
        '
        Me.tmgrade.HeaderText = "TmGrade"
        Me.tmgrade.Name = "tmgrade"
        Me.tmgrade.ReadOnly = True
        Me.tmgrade.Visible = False
        '
        'idgrade
        '
        Me.idgrade.HeaderText = "IdGrade"
        Me.idgrade.Name = "idgrade"
        Me.idgrade.ReadOnly = True
        Me.idgrade.Visible = False
        '
        'Frm_OrcamentoAlt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 616)
        Me.Controls.Add(Me.grp_pedido)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dtg_pedidoprotaentrega)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_OrcamentoAlt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alterando Orcamento..."
        Me.grp_pedido.ResumeLayout(False)
        Me.grp_pedido.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp_registra.ResumeLayout(False)
        Me.grp_descontos.ResumeLayout(False)
        Me.grp_descontos.PerformLayout()
        Me.grp_total.ResumeLayout(False)
        Me.grp_total.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtg_pedidoprotaentrega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp_pedido As System.Windows.Forms.GroupBox
    Public WithEvents cbo_vendedor As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_vendedor As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_valor As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents txt_codProd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grp_registra As System.Windows.Forms.GroupBox
    Public WithEvents btn_finalizar As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Public WithEvents btn_excluir As System.Windows.Forms.Button
    Public WithEvents btn_incluir As System.Windows.Forms.Button
    Public WithEvents txt_nomeProd As System.Windows.Forms.TextBox
    Friend WithEvents txt_qtde As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_desconto As System.Windows.Forms.TextBox
    Friend WithEvents lbl_desconto As System.Windows.Forms.Label
    Friend WithEvents grp_descontos As System.Windows.Forms.GroupBox
    Friend WithEvents txt_descontosTotais As System.Windows.Forms.TextBox
    Friend WithEvents grp_total As System.Windows.Forms.GroupBox
    Public WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents cbo_local As System.Windows.Forms.ComboBox
    Public WithEvents txt_codpart As System.Windows.Forms.TextBox
    Public WithEvents txt_obs As System.Windows.Forms.TextBox
    Friend WithEvents lbl_obs As System.Windows.Forms.Label
    Public WithEvents txt_operador As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents dtp_emissao As System.Windows.Forms.DateTimePicker
    Public WithEvents txt_orcamento As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_pedido As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents pdRelatPedidos As System.Drawing.Printing.PrintDocument
    Friend WithEvents dtg_pedidoprotaentrega As System.Windows.Forms.DataGridView
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
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
    Friend WithEvents corgrade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tmgrade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idgrade As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
