<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Orcamento
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Orcamento))
        Me.grp_pedido = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_qtde = New System.Windows.Forms.TextBox()
        Me.btn_finalizar = New System.Windows.Forms.Button()
        Me.txt_valor = New System.Windows.Forms.TextBox()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_codProd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_nomeProd = New System.Windows.Forms.TextBox()
        Me.grp_total = New System.Windows.Forms.GroupBox()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo_local = New System.Windows.Forms.ComboBox()
        Me.txt_codpart = New System.Windows.Forms.TextBox()
        Me.txt_operador = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_nomePart = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_emissao = New System.Windows.Forms.DateTimePicker()
        Me.txt_orcamento = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_pedido = New System.Windows.Forms.Label()
        Me.dtg_pedidoServico = New System.Windows.Forms.DataGridView()
        Me.no_idpk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.no_filial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.no_codpr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.no_produt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.no_prunit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qtde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.pdRelatPedidos = New System.Drawing.Printing.PrintDocument()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.grp_pedido.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grp_total.SuspendLayout()
        CType(Me.dtg_pedidoServico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_pedido
        '
        Me.grp_pedido.Controls.Add(Me.GroupBox1)
        Me.grp_pedido.Controls.Add(Me.grp_total)
        Me.grp_pedido.Controls.Add(Me.Label9)
        Me.grp_pedido.Controls.Add(Me.cbo_local)
        Me.grp_pedido.Controls.Add(Me.txt_codpart)
        Me.grp_pedido.Controls.Add(Me.txt_operador)
        Me.grp_pedido.Controls.Add(Me.Label6)
        Me.grp_pedido.Controls.Add(Me.txt_nomePart)
        Me.grp_pedido.Controls.Add(Me.Label3)
        Me.grp_pedido.Controls.Add(Me.dtp_emissao)
        Me.grp_pedido.Controls.Add(Me.txt_orcamento)
        Me.grp_pedido.Controls.Add(Me.Label2)
        Me.grp_pedido.Controls.Add(Me.lbl_pedido)
        Me.grp_pedido.Location = New System.Drawing.Point(13, 45)
        Me.grp_pedido.Name = "grp_pedido"
        Me.grp_pedido.Size = New System.Drawing.Size(923, 159)
        Me.grp_pedido.TabIndex = 37
        Me.grp_pedido.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_qtde)
        Me.GroupBox1.Controls.Add(Me.btn_finalizar)
        Me.GroupBox1.Controls.Add(Me.txt_valor)
        Me.GroupBox1.Controls.Add(Me.btn_alterar)
        Me.GroupBox1.Controls.Add(Me.btn_excluir)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btn_incluir)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txt_codProd)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_nomeProd)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(910, 72)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'txt_qtde
        '
        Me.txt_qtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtde.Location = New System.Drawing.Point(454, 37)
        Me.txt_qtde.Name = "txt_qtde"
        Me.txt_qtde.Size = New System.Drawing.Size(74, 21)
        Me.txt_qtde.TabIndex = 67
        Me.txt_qtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_finalizar
        '
        Me.btn_finalizar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_finalizar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_finalizar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_finalizar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_finalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_finalizar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_finalizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_finalizar.Image = Global.RTecSys.My.Resources.Resources.Info
        Me.btn_finalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_finalizar.Location = New System.Drawing.Point(844, 15)
        Me.btn_finalizar.Name = "btn_finalizar"
        Me.btn_finalizar.Size = New System.Drawing.Size(55, 50)
        Me.btn_finalizar.TabIndex = 27
        Me.btn_finalizar.Text = "&Fim"
        Me.btn_finalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_finalizar.UseVisualStyleBackColor = False
        '
        'txt_valor
        '
        Me.txt_valor.BackColor = System.Drawing.SystemColors.Window
        Me.txt_valor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valor.Location = New System.Drawing.Point(548, 37)
        Me.txt_valor.MaxLength = 14
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.Size = New System.Drawing.Size(98, 22)
        Me.txt_valor.TabIndex = 21
        Me.txt_valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_alterar
        '
        Me.btn_alterar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_alterar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_alterar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_alterar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_alterar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_alterar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_alterar.Image = Global.RTecSys.My.Resources.Resources.Modify
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(722, 15)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(55, 50)
        Me.btn_alterar.TabIndex = 25
        Me.btn_alterar.Text = "&Alt"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = False
        '
        'btn_excluir
        '
        Me.btn_excluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_excluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_excluir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_excluir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_excluir.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_excluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_excluir.Image = Global.RTecSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_excluir.Location = New System.Drawing.Point(783, 15)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(55, 50)
        Me.btn_excluir.TabIndex = 26
        Me.btn_excluir.Text = "&Exc"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_excluir.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(171, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Descrição"
        '
        'btn_incluir
        '
        Me.btn_incluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_incluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_incluir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_incluir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_incluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_incluir.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_incluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_incluir.Image = Global.RTecSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.Location = New System.Drawing.Point(660, 15)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(55, 50)
        Me.btn_incluir.TabIndex = 24
        Me.btn_incluir.Text = "&Inc"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_incluir.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(469, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Qtde"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(551, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Pco. Serviço"
        '
        'txt_codProd
        '
        Me.txt_codProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codProd.Location = New System.Drawing.Point(6, 37)
        Me.txt_codProd.MaxLength = 14
        Me.txt_codProd.Name = "txt_codProd"
        Me.txt_codProd.Size = New System.Drawing.Size(66, 22)
        Me.txt_codProd.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "CodServ"
        '
        'txt_nomeProd
        '
        Me.txt_nomeProd.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nomeProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomeProd.Location = New System.Drawing.Point(78, 36)
        Me.txt_nomeProd.Name = "txt_nomeProd"
        Me.txt_nomeProd.ReadOnly = True
        Me.txt_nomeProd.Size = New System.Drawing.Size(355, 22)
        Me.txt_nomeProd.TabIndex = 19
        '
        'grp_total
        '
        Me.grp_total.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.grp_total.Controls.Add(Me.txt_total)
        Me.grp_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_total.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grp_total.Location = New System.Drawing.Point(792, 20)
        Me.grp_total.Name = "grp_total"
        Me.grp_total.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grp_total.Size = New System.Drawing.Size(123, 49)
        Me.grp_total.TabIndex = 29
        Me.grp_total.TabStop = False
        Me.grp_total.Text = "Total R$"
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.Info
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Blue
        Me.txt_total.Location = New System.Drawing.Point(11, 17)
        Me.txt_total.MaxLength = 12
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_total.Size = New System.Drawing.Size(101, 26)
        Me.txt_total.TabIndex = 30
        Me.txt_total.Text = "0,00"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 17)
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
        Me.cbo_local.Size = New System.Drawing.Size(257, 23)
        Me.cbo_local.TabIndex = 1
        '
        'txt_codpart
        '
        Me.txt_codpart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codpart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codpart.Location = New System.Drawing.Point(77, 54)
        Me.txt_codpart.MaxLength = 6
        Me.txt_codpart.Name = "txt_codpart"
        Me.txt_codpart.Size = New System.Drawing.Size(70, 22)
        Me.txt_codpart.TabIndex = 4
        '
        'txt_operador
        '
        Me.txt_operador.BackColor = System.Drawing.SystemColors.Info
        Me.txt_operador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_operador.Location = New System.Drawing.Point(627, 54)
        Me.txt_operador.MaxLength = 10
        Me.txt_operador.Name = "txt_operador"
        Me.txt_operador.ReadOnly = True
        Me.txt_operador.Size = New System.Drawing.Size(131, 21)
        Me.txt_operador.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(548, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 17)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Operador:"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomePart.Location = New System.Drawing.Point(153, 54)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(341, 22)
        Me.txt_nomePart.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Cliente:"
        '
        'dtp_emissao
        '
        Me.dtp_emissao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_emissao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_emissao.Location = New System.Drawing.Point(662, 20)
        Me.dtp_emissao.Name = "dtp_emissao"
        Me.dtp_emissao.Size = New System.Drawing.Size(96, 21)
        Me.dtp_emissao.TabIndex = 3
        '
        'txt_orcamento
        '
        Me.txt_orcamento.BackColor = System.Drawing.SystemColors.Info
        Me.txt_orcamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_orcamento.Location = New System.Drawing.Point(468, 20)
        Me.txt_orcamento.MaxLength = 8
        Me.txt_orcamento.Name = "txt_orcamento"
        Me.txt_orcamento.ReadOnly = True
        Me.txt_orcamento.Size = New System.Drawing.Size(109, 21)
        Me.txt_orcamento.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(614, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 17)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Data:"
        '
        'lbl_pedido
        '
        Me.lbl_pedido.AutoSize = True
        Me.lbl_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pedido.Location = New System.Drawing.Point(384, 21)
        Me.lbl_pedido.Name = "lbl_pedido"
        Me.lbl_pedido.Size = New System.Drawing.Size(82, 17)
        Me.lbl_pedido.TabIndex = 32
        Me.lbl_pedido.Text = "Orçamento:"
        '
        'dtg_pedidoServico
        '
        Me.dtg_pedidoServico.AllowUserToAddRows = False
        Me.dtg_pedidoServico.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_pedidoServico.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_pedidoServico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_pedidoServico.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_pedidoServico.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_pedidoServico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_pedidoServico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.no_idpk, Me.no_filial, Me.no_codpr, Me.no_produt, Me.no_prunit, Me.qtde, Me.total})
        Me.dtg_pedidoServico.Location = New System.Drawing.Point(12, 210)
        Me.dtg_pedidoServico.Name = "dtg_pedidoServico"
        Me.dtg_pedidoServico.ReadOnly = True
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_pedidoServico.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_pedidoServico.Size = New System.Drawing.Size(924, 179)
        Me.dtg_pedidoServico.TabIndex = 38
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.no_filial.DefaultCellStyle = DataGridViewCellStyle3
        Me.no_filial.HeaderText = "Loja"
        Me.no_filial.MaxInputLength = 3
        Me.no_filial.Name = "no_filial"
        Me.no_filial.ReadOnly = True
        Me.no_filial.Width = 60
        '
        'no_codpr
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.no_codpr.DefaultCellStyle = DataGridViewCellStyle4
        Me.no_codpr.HeaderText = "Codigo"
        Me.no_codpr.MaxInputLength = 14
        Me.no_codpr.MinimumWidth = 6
        Me.no_codpr.Name = "no_codpr"
        Me.no_codpr.ReadOnly = True
        Me.no_codpr.Width = 80
        '
        'no_produt
        '
        Me.no_produt.HeaderText = "Serviço"
        Me.no_produt.MaxInputLength = 80
        Me.no_produt.MinimumWidth = 20
        Me.no_produt.Name = "no_produt"
        Me.no_produt.ReadOnly = True
        Me.no_produt.Width = 422
        '
        'no_prunit
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.no_prunit.DefaultCellStyle = DataGridViewCellStyle5
        Me.no_prunit.HeaderText = "Pco Venda"
        Me.no_prunit.Name = "no_prunit"
        Me.no_prunit.ReadOnly = True
        Me.no_prunit.Width = 120
        '
        'qtde
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.qtde.DefaultCellStyle = DataGridViewCellStyle6
        Me.qtde.HeaderText = "Qtde"
        Me.qtde.Name = "qtde"
        Me.qtde.ReadOnly = True
        Me.qtde.Width = 80
        '
        'total
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.total.DefaultCellStyle = DataGridViewCellStyle7
        Me.total.HeaderText = "Total"
        Me.total.Name = "total"
        Me.total.ReadOnly = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'pdRelatPedidos
        '
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 395)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(924, 49)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-8, -3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(961, 42)
        Me.Panel1.TabIndex = 55
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(419, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Frm_Orcamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 454)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grp_pedido)
        Me.Controls.Add(Me.dtg_pedidoServico)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_Orcamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orcamento"
        Me.grp_pedido.ResumeLayout(False)
        Me.grp_pedido.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp_total.ResumeLayout(False)
        Me.grp_total.PerformLayout()
        CType(Me.dtg_pedidoServico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp_pedido As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents txt_codProd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents btn_finalizar As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Public WithEvents btn_excluir As System.Windows.Forms.Button
    Public WithEvents btn_incluir As System.Windows.Forms.Button
    Public WithEvents txt_nomeProd As System.Windows.Forms.TextBox
    Friend WithEvents grp_total As System.Windows.Forms.GroupBox
    Public WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents cbo_local As System.Windows.Forms.ComboBox
    Public WithEvents txt_codpart As System.Windows.Forms.TextBox
    Public WithEvents txt_operador As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents dtp_emissao As System.Windows.Forms.DateTimePicker
    Public WithEvents txt_orcamento As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_pedido As System.Windows.Forms.Label
    Friend WithEvents dtg_pedidoServico As System.Windows.Forms.DataGridView
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents pdRelatPedidos As System.Drawing.Printing.PrintDocument
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents txt_valor As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents no_idpk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_filial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_codpr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_produt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_prunit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_qtde As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
