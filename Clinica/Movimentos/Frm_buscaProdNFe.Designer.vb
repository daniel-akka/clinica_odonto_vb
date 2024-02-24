<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_buscaProdNFe
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grb_registros = New System.Windows.Forms.GroupBox()
        Me.lbl_registros = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_pesquisa = New System.Windows.Forms.Label()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.grp_opcoes = New System.Windows.Forms.GroupBox()
        Me.rdb_nome = New System.Windows.Forms.RadioButton()
        Me.rdb_codigo = New System.Windows.Forms.RadioButton()
        Me.rdb_CodForn = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_matPrima = New System.Windows.Forms.CheckBox()
        Me.btn_confirmar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dg_produto = New System.Windows.Forms.DataGridView()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cnpj_cpf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.inscricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ncm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cstProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cfvProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grupoProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reduzProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sldAtual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.custoAnter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcoAnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clfProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcoVenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grb_registros.SuspendLayout()
        Me.grp_opcoes.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Dg_produto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grb_registros
        '
        Me.grb_registros.BackColor = System.Drawing.SystemColors.Control
        Me.grb_registros.Controls.Add(Me.lbl_registros)
        Me.grb_registros.Controls.Add(Me.Label2)
        Me.grb_registros.Location = New System.Drawing.Point(560, 126)
        Me.grb_registros.Name = "grb_registros"
        Me.grb_registros.Size = New System.Drawing.Size(140, 32)
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
        'lbl_pesquisa
        '
        Me.lbl_pesquisa.AutoSize = True
        Me.lbl_pesquisa.Font = New System.Drawing.Font("Cooper Black", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pesquisa.Location = New System.Drawing.Point(133, 71)
        Me.lbl_pesquisa.Name = "lbl_pesquisa"
        Me.lbl_pesquisa.Size = New System.Drawing.Size(63, 14)
        Me.lbl_pesquisa.TabIndex = 23
        Me.lbl_pesquisa.Text = "CODIGO:"
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(202, 67)
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(79, 23)
        Me.txt_pesquisa.TabIndex = 25
        '
        'grp_opcoes
        '
        Me.grp_opcoes.Controls.Add(Me.rdb_nome)
        Me.grp_opcoes.Controls.Add(Me.rdb_codigo)
        Me.grp_opcoes.Controls.Add(Me.rdb_CodForn)
        Me.grp_opcoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_opcoes.Location = New System.Drawing.Point(11, 67)
        Me.grp_opcoes.Name = "grp_opcoes"
        Me.grp_opcoes.Size = New System.Drawing.Size(109, 91)
        Me.grp_opcoes.TabIndex = 24
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
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.chk_matPrima)
        Me.GroupBox1.Location = New System.Drawing.Point(560, 97)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(140, 32)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'chk_matPrima
        '
        Me.chk_matPrima.AutoSize = True
        Me.chk_matPrima.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_matPrima.Location = New System.Drawing.Point(13, 12)
        Me.chk_matPrima.Name = "chk_matPrima"
        Me.chk_matPrima.Size = New System.Drawing.Size(119, 17)
        Me.chk_matPrima.TabIndex = 0
        Me.chk_matPrima.Text = "Matéria Prima    "
        Me.chk_matPrima.UseVisualStyleBackColor = True
        '
        'btn_confirmar
        '
        Me.btn_confirmar.Font = New System.Drawing.Font("Cooper Black", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_confirmar.Image = Global.RTecSys.My.Resources.Resources.accept001
        Me.btn_confirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_confirmar.Location = New System.Drawing.Point(136, 98)
        Me.btn_confirmar.Name = "btn_confirmar"
        Me.btn_confirmar.Size = New System.Drawing.Size(81, 60)
        Me.btn_confirmar.TabIndex = 26
        Me.btn_confirmar.Text = "&OK"
        Me.btn_confirmar.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btn_confirmar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(207, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 35)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Pesquisa de Produto"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dg_produto
        '
        Me.Dg_produto.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dg_produto.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dg_produto.BackgroundColor = System.Drawing.Color.DarkGray
        Me.Dg_produto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dg_produto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dg_produto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg_produto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.nome, Me.cnpj_cpf, Me.inscricao, Me.UF, Me.Ncm, Me.cstProd, Me.cfvProd, Me.grupoProd, Me.reduzProd, Me.sldAtual, Me.custoAnter, Me.pcoAnt, Me.clfProd, Me.pcoVenda})
        Me.Dg_produto.Location = New System.Drawing.Point(13, 165)
        Me.Dg_produto.MultiSelect = False
        Me.Dg_produto.Name = "Dg_produto"
        Me.Dg_produto.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dg_produto.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dg_produto.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.Dg_produto.Size = New System.Drawing.Size(687, 168)
        Me.Dg_produto.TabIndex = 27
        '
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.codigo.Width = 60
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
        Me.cnpj_cpf.Visible = False
        Me.cnpj_cpf.Width = 80
        '
        'inscricao
        '
        Me.inscricao.HeaderText = "QtdEstoque"
        Me.inscricao.Name = "inscricao"
        Me.inscricao.ReadOnly = True
        Me.inscricao.Width = 90
        '
        'UF
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.UF.DefaultCellStyle = DataGridViewCellStyle3
        Me.UF.HeaderText = "UND"
        Me.UF.MaxInputLength = 7
        Me.UF.MinimumWidth = 2
        Me.UF.Name = "UF"
        Me.UF.ReadOnly = True
        Me.UF.Width = 60
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
        'sldAtual
        '
        Me.sldAtual.HeaderText = "SaldoAtual"
        Me.sldAtual.Name = "sldAtual"
        Me.sldAtual.ReadOnly = True
        Me.sldAtual.Visible = False
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
        'pcoVenda
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.pcoVenda.DefaultCellStyle = DataGridViewCellStyle4
        Me.pcoVenda.HeaderText = "Pco. Venda"
        Me.pcoVenda.Name = "pcoVenda"
        Me.pcoVenda.ReadOnly = True
        Me.pcoVenda.Width = 115
        '
        'Frm_buscaProdNFe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 344)
        Me.Controls.Add(Me.grb_registros)
        Me.Controls.Add(Me.lbl_pesquisa)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.Controls.Add(Me.grp_opcoes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_confirmar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Dg_produto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_buscaProdNFe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busca do Produto"
        Me.grb_registros.ResumeLayout(False)
        Me.grb_registros.PerformLayout()
        Me.grp_opcoes.ResumeLayout(False)
        Me.grp_opcoes.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Dg_produto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grb_registros As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_registros As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_pesquisa As System.Windows.Forms.Label
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents grp_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_nome As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_codigo As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_CodForn As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_matPrima As System.Windows.Forms.CheckBox
    Friend WithEvents btn_confirmar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dg_produto As System.Windows.Forms.DataGridView
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnpj_cpf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents inscricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ncm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cstProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cfvProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grupoProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reduzProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sldAtual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents custoAnter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcoAnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clfProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcoVenda As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
