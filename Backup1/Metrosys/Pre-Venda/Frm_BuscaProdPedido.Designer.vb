<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BuscaProdPedido
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_BuscaProdPedido))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chk_matPrima = New System.Windows.Forms.CheckBox
        Me.grb_registros = New System.Windows.Forms.GroupBox
        Me.lbl_registros = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Dg_produto = New System.Windows.Forms.DataGridView
        Me.btn_confirmar = New System.Windows.Forms.Button
        Me.lbl_pesquisa = New System.Windows.Forms.Label
        Me.txt_pesquisa = New System.Windows.Forms.TextBox
        Me.grp_opcoes = New System.Windows.Forms.GroupBox
        Me.rdb_nome = New System.Windows.Forms.RadioButton
        Me.rdb_codigo = New System.Windows.Forms.RadioButton
        Me.rdb_CodForn = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtg_saldos = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label35 = New System.Windows.Forms.Label
        Me.lbl_loja = New System.Windows.Forms.Label
        Me.lbl_qtde = New System.Windows.Forms.Label
        Me.lbl_pcoVenda = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cnpj_cpf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sldAtual = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ncm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cstProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cfvProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grupoProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.reduzProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.inscricao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.custoAnter = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pcoAnt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clfProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pesobruto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pesoliq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codbarra = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.linha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grade = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtinicialpromoca = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtfinalpromocao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.vlprom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.grb_registros.SuspendLayout()
        CType(Me.Dg_produto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_opcoes.SuspendLayout()
        CType(Me.dtg_saldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.chk_matPrima)
        Me.GroupBox1.Location = New System.Drawing.Point(520, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(139, 32)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'chk_matPrima
        '
        Me.chk_matPrima.AutoSize = True
        Me.chk_matPrima.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_matPrima.Location = New System.Drawing.Point(13, 10)
        Me.chk_matPrima.Name = "chk_matPrima"
        Me.chk_matPrima.Size = New System.Drawing.Size(103, 17)
        Me.chk_matPrima.TabIndex = 0
        Me.chk_matPrima.Text = "Matéria Prima"
        Me.chk_matPrima.UseVisualStyleBackColor = True
        '
        'grb_registros
        '
        Me.grb_registros.BackColor = System.Drawing.SystemColors.Control
        Me.grb_registros.Controls.Add(Me.lbl_registros)
        Me.grb_registros.Controls.Add(Me.Label2)
        Me.grb_registros.Location = New System.Drawing.Point(520, 129)
        Me.grb_registros.Name = "grb_registros"
        Me.grb_registros.Size = New System.Drawing.Size(139, 32)
        Me.grb_registros.TabIndex = 28
        Me.grb_registros.TabStop = False
        '
        'lbl_registros
        '
        Me.lbl_registros.AutoSize = True
        Me.lbl_registros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_registros.ForeColor = System.Drawing.Color.OrangeRed
        Me.lbl_registros.Location = New System.Drawing.Point(85, 12)
        Me.lbl_registros.Name = "lbl_registros"
        Me.lbl_registros.Size = New System.Drawing.Size(14, 13)
        Me.lbl_registros.TabIndex = 1
        Me.lbl_registros.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Registros: "
        '
        'Dg_produto
        '
        Me.Dg_produto.AllowUserToAddRows = False
        Me.Dg_produto.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dg_produto.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dg_produto.BackgroundColor = System.Drawing.Color.DarkGray
        Me.Dg_produto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dg_produto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg_produto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.nome, Me.cnpj_cpf, Me.sldAtual, Me.UF, Me.Ncm, Me.cstProd, Me.cfvProd, Me.grupoProd, Me.reduzProd, Me.inscricao, Me.custoAnter, Me.pcoAnt, Me.clfProd, Me.pesobruto, Me.pesoliq, Me.codbarra, Me.linha, Me.Grade, Me.dtinicialpromoca, Me.dtfinalpromocao, Me.vlprom})
        Me.Dg_produto.Location = New System.Drawing.Point(11, 168)
        Me.Dg_produto.MultiSelect = False
        Me.Dg_produto.Name = "Dg_produto"
        Me.Dg_produto.ReadOnly = True
        Me.Dg_produto.Size = New System.Drawing.Size(648, 168)
        Me.Dg_produto.TabIndex = 26
        '
        'btn_confirmar
        '
        Me.btn_confirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_confirmar.Image = Global.MetroSys.My.Resources.Resources.accept001
        Me.btn_confirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_confirmar.Location = New System.Drawing.Point(136, 101)
        Me.btn_confirmar.Name = "btn_confirmar"
        Me.btn_confirmar.Size = New System.Drawing.Size(81, 60)
        Me.btn_confirmar.TabIndex = 25
        Me.btn_confirmar.Text = "&OK"
        Me.btn_confirmar.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btn_confirmar.UseVisualStyleBackColor = True
        '
        'lbl_pesquisa
        '
        Me.lbl_pesquisa.AutoSize = True
        Me.lbl_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pesquisa.Location = New System.Drawing.Point(133, 74)
        Me.lbl_pesquisa.Name = "lbl_pesquisa"
        Me.lbl_pesquisa.Size = New System.Drawing.Size(57, 15)
        Me.lbl_pesquisa.TabIndex = 23
        Me.lbl_pesquisa.Text = "CODIGO:"
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(202, 70)
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(79, 23)
        Me.txt_pesquisa.TabIndex = 24
        '
        'grp_opcoes
        '
        Me.grp_opcoes.Controls.Add(Me.rdb_nome)
        Me.grp_opcoes.Controls.Add(Me.rdb_codigo)
        Me.grp_opcoes.Controls.Add(Me.rdb_CodForn)
        Me.grp_opcoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_opcoes.Location = New System.Drawing.Point(11, 70)
        Me.grp_opcoes.Name = "grp_opcoes"
        Me.grp_opcoes.Size = New System.Drawing.Size(109, 91)
        Me.grp_opcoes.TabIndex = 22
        Me.grp_opcoes.TabStop = False
        Me.grp_opcoes.Text = "Opções"
        '
        'rdb_nome
        '
        Me.rdb_nome.AutoSize = True
        Me.rdb_nome.Checked = True
        Me.rdb_nome.Location = New System.Drawing.Point(6, 43)
        Me.rdb_nome.Name = "rdb_nome"
        Me.rdb_nome.Size = New System.Drawing.Size(95, 19)
        Me.rdb_nome.TabIndex = 2
        Me.rdb_nome.TabStop = True
        Me.rdb_nome.Text = "Nome        "
        Me.rdb_nome.UseVisualStyleBackColor = True
        '
        'rdb_codigo
        '
        Me.rdb_codigo.AutoSize = True
        Me.rdb_codigo.Location = New System.Drawing.Point(6, 20)
        Me.rdb_codigo.Name = "rdb_codigo"
        Me.rdb_codigo.Size = New System.Drawing.Size(94, 19)
        Me.rdb_codigo.TabIndex = 1
        Me.rdb_codigo.Text = "Codigo      "
        Me.rdb_codigo.UseVisualStyleBackColor = True
        '
        'rdb_CodForn
        '
        Me.rdb_CodForn.AutoSize = True
        Me.rdb_CodForn.Location = New System.Drawing.Point(6, 64)
        Me.rdb_CodForn.Name = "rdb_CodForn"
        Me.rdb_CodForn.Size = New System.Drawing.Size(95, 19)
        Me.rdb_CodForn.TabIndex = 3
        Me.rdb_CodForn.Text = "CodForn    "
        Me.rdb_CodForn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(157, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 35)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Pesquisa de Produto"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtg_saldos
        '
        Me.dtg_saldos.AllowUserToAddRows = False
        Me.dtg_saldos.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_saldos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_saldos.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_saldos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_saldos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_saldos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_saldos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_saldos.ColumnHeadersHeight = 25
        Me.dtg_saldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_saldos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dtg_saldos.Location = New System.Drawing.Point(11, 370)
        Me.dtg_saldos.MultiSelect = False
        Me.dtg_saldos.Name = "dtg_saldos"
        Me.dtg_saldos.ReadOnly = True
        Me.dtg_saldos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_saldos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtg_saldos.Size = New System.Drawing.Size(238, 126)
        Me.dtg_saldos.TabIndex = 30
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn1.HeaderText = "Loja"
        Me.DataGridViewTextBoxColumn1.MaxInputLength = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 70
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn3.HeaderText = "Saldo"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 14
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 125
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn4.HeaderText = "Pco. Venda"
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 16
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 125
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(8, 347)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(55, 15)
        Me.Label35.TabIndex = 29
        Me.Label35.Text = "Saldos:"
        '
        'lbl_loja
        '
        Me.lbl_loja.AutoSize = True
        Me.lbl_loja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_loja.Location = New System.Drawing.Point(286, 347)
        Me.lbl_loja.Name = "lbl_loja"
        Me.lbl_loja.Size = New System.Drawing.Size(23, 15)
        Me.lbl_loja.TabIndex = 29
        Me.lbl_loja.Text = ".   "
        Me.lbl_loja.Visible = False
        '
        'lbl_qtde
        '
        Me.lbl_qtde.AutoSize = True
        Me.lbl_qtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_qtde.Location = New System.Drawing.Point(347, 347)
        Me.lbl_qtde.Name = "lbl_qtde"
        Me.lbl_qtde.Size = New System.Drawing.Size(23, 15)
        Me.lbl_qtde.TabIndex = 29
        Me.lbl_qtde.Text = ".   "
        Me.lbl_qtde.Visible = False
        '
        'lbl_pcoVenda
        '
        Me.lbl_pcoVenda.AutoSize = True
        Me.lbl_pcoVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pcoVenda.Location = New System.Drawing.Point(408, 347)
        Me.lbl_pcoVenda.Name = "lbl_pcoVenda"
        Me.lbl_pcoVenda.Size = New System.Drawing.Size(23, 15)
        Me.lbl_pcoVenda.TabIndex = 29
        Me.lbl_pcoVenda.Text = ".   "
        Me.lbl_pcoVenda.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(322, 370)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(337, 126)
        Me.Panel1.TabIndex = 36
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(192, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 20)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(9, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(177, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.codigo.Width = 50
        '
        'nome
        '
        Me.nome.HeaderText = "Nome"
        Me.nome.Name = "nome"
        Me.nome.ReadOnly = True
        Me.nome.Width = 300
        '
        'cnpj_cpf
        '
        Me.cnpj_cpf.HeaderText = "Fornecedor"
        Me.cnpj_cpf.MaxInputLength = 12
        Me.cnpj_cpf.Name = "cnpj_cpf"
        Me.cnpj_cpf.ReadOnly = True
        Me.cnpj_cpf.Width = 80
        '
        'sldAtual
        '
        Me.sldAtual.HeaderText = "SaldoAtual"
        Me.sldAtual.Name = "sldAtual"
        Me.sldAtual.ReadOnly = True
        '
        'UF
        '
        Me.UF.HeaderText = "UND"
        Me.UF.MaxInputLength = 7
        Me.UF.MinimumWidth = 2
        Me.UF.Name = "UF"
        Me.UF.ReadOnly = True
        Me.UF.Width = 75
        '
        'Ncm
        '
        Me.Ncm.HeaderText = "ncmProd"
        Me.Ncm.Name = "Ncm"
        Me.Ncm.ReadOnly = True
        Me.Ncm.Visible = False
        '
        'cstProd
        '
        Me.cstProd.HeaderText = "cst"
        Me.cstProd.MaxInputLength = 3
        Me.cstProd.Name = "cstProd"
        Me.cstProd.ReadOnly = True
        Me.cstProd.Visible = False
        '
        'cfvProd
        '
        Me.cfvProd.HeaderText = "cfv"
        Me.cfvProd.MaxInputLength = 3
        Me.cfvProd.Name = "cfvProd"
        Me.cfvProd.ReadOnly = True
        Me.cfvProd.Visible = False
        '
        'grupoProd
        '
        Me.grupoProd.HeaderText = "grupo"
        Me.grupoProd.MaxInputLength = 3
        Me.grupoProd.Name = "grupoProd"
        Me.grupoProd.ReadOnly = True
        Me.grupoProd.Visible = False
        '
        'reduzProd
        '
        Me.reduzProd.HeaderText = "reduz"
        Me.reduzProd.MaxInputLength = 3
        Me.reduzProd.Name = "reduzProd"
        Me.reduzProd.ReadOnly = True
        Me.reduzProd.Visible = False
        '
        'inscricao
        '
        Me.inscricao.HeaderText = "QtdEstoque"
        Me.inscricao.Name = "inscricao"
        Me.inscricao.ReadOnly = True
        Me.inscricao.Visible = False
        Me.inscricao.Width = 80
        '
        'custoAnter
        '
        Me.custoAnter.HeaderText = "cutoAnterior"
        Me.custoAnter.Name = "custoAnter"
        Me.custoAnter.ReadOnly = True
        Me.custoAnter.Visible = False
        '
        'pcoAnt
        '
        Me.pcoAnt.HeaderText = "PcoAnterior"
        Me.pcoAnt.Name = "pcoAnt"
        Me.pcoAnt.ReadOnly = True
        Me.pcoAnt.Visible = False
        '
        'clfProd
        '
        Me.clfProd.HeaderText = "clf"
        Me.clfProd.Name = "clfProd"
        Me.clfProd.ReadOnly = True
        Me.clfProd.Visible = False
        '
        'pesobruto
        '
        Me.pesobruto.HeaderText = "pesobruto"
        Me.pesobruto.Name = "pesobruto"
        Me.pesobruto.ReadOnly = True
        Me.pesobruto.Visible = False
        '
        'pesoliq
        '
        Me.pesoliq.HeaderText = "pesoliq"
        Me.pesoliq.Name = "pesoliq"
        Me.pesoliq.ReadOnly = True
        Me.pesoliq.Visible = False
        '
        'codbarra
        '
        Me.codbarra.HeaderText = "codbarra"
        Me.codbarra.Name = "codbarra"
        Me.codbarra.ReadOnly = True
        Me.codbarra.Visible = False
        '
        'linha
        '
        Me.linha.HeaderText = "Linha"
        Me.linha.Name = "linha"
        Me.linha.ReadOnly = True
        Me.linha.Visible = False
        '
        'Grade
        '
        Me.Grade.HeaderText = "grade"
        Me.Grade.MaxInputLength = 1
        Me.Grade.Name = "Grade"
        Me.Grade.ReadOnly = True
        Me.Grade.Visible = False
        Me.Grade.Width = 80
        '
        'dtinicialpromoca
        '
        Me.dtinicialpromoca.HeaderText = "DtInicialPromoca"
        Me.dtinicialpromoca.Name = "dtinicialpromoca"
        Me.dtinicialpromoca.ReadOnly = True
        Me.dtinicialpromoca.Visible = False
        '
        'dtfinalpromocao
        '
        Me.dtfinalpromocao.HeaderText = "DtFinalPromocao"
        Me.dtfinalpromocao.Name = "dtfinalpromocao"
        Me.dtfinalpromocao.ReadOnly = True
        Me.dtfinalpromocao.Visible = False
        '
        'vlprom
        '
        Me.vlprom.HeaderText = "VlProm"
        Me.vlprom.Name = "vlprom"
        Me.vlprom.ReadOnly = True
        Me.vlprom.Visible = False
        '
        'Frm_BuscaProdPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 507)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtg_saldos)
        Me.Controls.Add(Me.lbl_pcoVenda)
        Me.Controls.Add(Me.lbl_qtde)
        Me.Controls.Add(Me.lbl_loja)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grb_registros)
        Me.Controls.Add(Me.Dg_produto)
        Me.Controls.Add(Me.btn_confirmar)
        Me.Controls.Add(Me.lbl_pesquisa)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.Controls.Add(Me.grp_opcoes)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_BuscaProdPedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produtos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grb_registros.ResumeLayout(False)
        Me.grb_registros.PerformLayout()
        CType(Me.Dg_produto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_opcoes.ResumeLayout(False)
        Me.grp_opcoes.PerformLayout()
        CType(Me.dtg_saldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_matPrima As System.Windows.Forms.CheckBox
    Friend WithEvents grb_registros As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_registros As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Dg_produto As System.Windows.Forms.DataGridView
    Friend WithEvents btn_confirmar As System.Windows.Forms.Button
    Friend WithEvents lbl_pesquisa As System.Windows.Forms.Label
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents grp_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_nome As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_codigo As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_CodForn As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtg_saldos As System.Windows.Forms.DataGridView
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lbl_loja As System.Windows.Forms.Label
    Friend WithEvents lbl_qtde As System.Windows.Forms.Label
    Friend WithEvents lbl_pcoVenda As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnpj_cpf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sldAtual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ncm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cstProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cfvProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grupoProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reduzProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents inscricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents custoAnter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcoAnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clfProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pesobruto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pesoliq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codbarra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents linha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtinicialpromoca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtfinalpromocao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlprom As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
