<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManMovComodato
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManMovComodato))
        Me.tbc_comodatos = New System.Windows.Forms.TabControl
        Me.tbp_visuComodato = New System.Windows.Forms.TabPage
        Me.grp_opcoes = New System.Windows.Forms.GroupBox
        Me.txt_pesquisa = New System.Windows.Forms.TextBox
        Me.cbo_tipo = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem01 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.btn_novo = New System.Windows.Forms.Button
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.Dtg_MovComodatos = New System.Windows.Forms.DataGridView
        Me.idComodato = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.produto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Plaqueta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataMov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tbp_cadComodato = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_salvar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtp_dtDevolucao = New System.Windows.Forms.DateTimePicker
        Me.dtp_dtEmprestimo = New System.Windows.Forms.DateTimePicker
        Me.txt_motorista = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_nomeProd = New System.Windows.Forms.TextBox
        Me.txt_codProd = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.txt_codPart = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label26 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.tbc_comodatos.SuspendLayout()
        Me.tbp_visuComodato.SuspendLayout()
        Me.grp_opcoes.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Dtg_MovComodatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbp_cadComodato.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbc_comodatos
        '
        Me.tbc_comodatos.Controls.Add(Me.tbp_visuComodato)
        Me.tbc_comodatos.Controls.Add(Me.tbp_cadComodato)
        Me.tbc_comodatos.Location = New System.Drawing.Point(6, 72)
        Me.tbc_comodatos.Name = "tbc_comodatos"
        Me.tbc_comodatos.SelectedIndex = 0
        Me.tbc_comodatos.Size = New System.Drawing.Size(613, 325)
        Me.tbc_comodatos.TabIndex = 8
        '
        'tbp_visuComodato
        '
        Me.tbp_visuComodato.Controls.Add(Me.grp_opcoes)
        Me.tbp_visuComodato.Controls.Add(Me.GroupBox4)
        Me.tbp_visuComodato.Controls.Add(Me.btn_excluir)
        Me.tbp_visuComodato.Controls.Add(Me.btn_novo)
        Me.tbp_visuComodato.Controls.Add(Me.btn_alterar)
        Me.tbp_visuComodato.Controls.Add(Me.Dtg_MovComodatos)
        Me.tbp_visuComodato.Location = New System.Drawing.Point(4, 22)
        Me.tbp_visuComodato.Name = "tbp_visuComodato"
        Me.tbp_visuComodato.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_visuComodato.Size = New System.Drawing.Size(605, 299)
        Me.tbp_visuComodato.TabIndex = 0
        Me.tbp_visuComodato.Text = "Visualização"
        Me.tbp_visuComodato.UseVisualStyleBackColor = True
        '
        'grp_opcoes
        '
        Me.grp_opcoes.Controls.Add(Me.txt_pesquisa)
        Me.grp_opcoes.Controls.Add(Me.cbo_tipo)
        Me.grp_opcoes.Controls.Add(Me.Label6)
        Me.grp_opcoes.Controls.Add(Me.Label7)
        Me.grp_opcoes.Location = New System.Drawing.Point(10, 6)
        Me.grp_opcoes.Name = "grp_opcoes"
        Me.grp_opcoes.Size = New System.Drawing.Size(361, 40)
        Me.grp_opcoes.TabIndex = 28
        Me.grp_opcoes.TabStop = False
        Me.grp_opcoes.Text = "Opções"
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Location = New System.Drawing.Point(172, 14)
        Me.txt_pesquisa.MaxLength = 90
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(183, 20)
        Me.txt_pesquisa.TabIndex = 29
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"Nenhum", "Cliente", "CodProduto", "PlaquetaProd", "DtEmprestimo"})
        Me.cbo_tipo.Location = New System.Drawing.Point(41, 14)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(79, 21)
        Me.cbo_tipo.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(129, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Nome:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Tipo:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbl_mensagem01)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 249)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(591, 40)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Mensagem"
        '
        'lbl_mensagem01
        '
        Me.lbl_mensagem01.AutoSize = True
        Me.lbl_mensagem01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem01.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem01.Location = New System.Drawing.Point(10, 17)
        Me.lbl_mensagem01.Name = "lbl_mensagem01"
        Me.lbl_mensagem01.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem01.TabIndex = 1
        Me.lbl_mensagem01.Text = ".   "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(20, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "   "
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excluir.Location = New System.Drawing.Point(522, 12)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(73, 34)
        Me.btn_excluir.TabIndex = 10
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_novo
        '
        Me.btn_novo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_novo.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_novo.Location = New System.Drawing.Point(377, 12)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(65, 34)
        Me.btn_novo.TabIndex = 6
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.Modify
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(446, 12)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(72, 34)
        Me.btn_alterar.TabIndex = 8
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'Dtg_MovComodatos
        '
        Me.Dtg_MovComodatos.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtg_MovComodatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dtg_MovComodatos.BackgroundColor = System.Drawing.Color.Gray
        Me.Dtg_MovComodatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dtg_MovComodatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.Dtg_MovComodatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dtg_MovComodatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dtg_MovComodatos.ColumnHeadersHeight = 28
        Me.Dtg_MovComodatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dtg_MovComodatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idComodato, Me.cliente, Me.produto, Me.Plaqueta, Me.dataMov})
        Me.Dtg_MovComodatos.Location = New System.Drawing.Point(10, 63)
        Me.Dtg_MovComodatos.MultiSelect = False
        Me.Dtg_MovComodatos.Name = "Dtg_MovComodatos"
        Me.Dtg_MovComodatos.ReadOnly = True
        Me.Dtg_MovComodatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Dtg_MovComodatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtg_MovComodatos.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Dtg_MovComodatos.Size = New System.Drawing.Size(583, 182)
        Me.Dtg_MovComodatos.TabIndex = 19
        '
        'idComodato
        '
        Me.idComodato.HeaderText = "id"
        Me.idComodato.Name = "idComodato"
        Me.idComodato.ReadOnly = True
        Me.idComodato.Visible = False
        '
        'cliente
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cliente.DefaultCellStyle = DataGridViewCellStyle3
        Me.cliente.HeaderText = "Cliente"
        Me.cliente.MaxInputLength = 60
        Me.cliente.Name = "cliente"
        Me.cliente.ReadOnly = True
        Me.cliente.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cliente.Width = 230
        '
        'produto
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.produto.DefaultCellStyle = DataGridViewCellStyle4
        Me.produto.HeaderText = "Produto"
        Me.produto.MaxInputLength = 80
        Me.produto.Name = "produto"
        Me.produto.ReadOnly = True
        Me.produto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.produto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.produto.Width = 110
        '
        'Plaqueta
        '
        Me.Plaqueta.HeaderText = "Plaqueta"
        Me.Plaqueta.MaxInputLength = 80
        Me.Plaqueta.Name = "Plaqueta"
        Me.Plaqueta.ReadOnly = True
        Me.Plaqueta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Plaqueta.Width = 200
        '
        'dataMov
        '
        Me.dataMov.HeaderText = "Emprestimo"
        Me.dataMov.MaxInputLength = 12
        Me.dataMov.Name = "dataMov"
        Me.dataMov.ReadOnly = True
        Me.dataMov.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataMov.Width = 90
        '
        'tbp_cadComodato
        '
        Me.tbp_cadComodato.Controls.Add(Me.GroupBox3)
        Me.tbp_cadComodato.Controls.Add(Me.GroupBox2)
        Me.tbp_cadComodato.Controls.Add(Me.GroupBox1)
        Me.tbp_cadComodato.Location = New System.Drawing.Point(4, 22)
        Me.tbp_cadComodato.Name = "tbp_cadComodato"
        Me.tbp_cadComodato.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_cadComodato.Size = New System.Drawing.Size(605, 299)
        Me.tbp_cadComodato.TabIndex = 1
        Me.tbp_cadComodato.Text = "Cadastro"
        Me.tbp_cadComodato.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 212)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(417, 60)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(20, 27)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(19, 15)
        Me.lbl_mensagem.TabIndex = 12
        Me.lbl_mensagem.Text = ".   "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_salvar)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Location = New System.Drawing.Point(434, 212)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(164, 60)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        '
        'btn_salvar
        '
        Me.btn_salvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salvar.Image = Global.MetroSys.My.Resources.Resources.Save
        Me.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salvar.Location = New System.Drawing.Point(6, 13)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(75, 42)
        Me.btn_salvar.TabIndex = 16
        Me.btn_salvar.Text = "&Salvar"
        Me.btn_salvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.MetroSys.My.Resources.Resources.cancelar
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(87, 13)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(71, 42)
        Me.btn_cancelar.TabIndex = 18
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtp_dtDevolucao)
        Me.GroupBox1.Controls.Add(Me.dtp_dtEmprestimo)
        Me.GroupBox1.Controls.Add(Me.txt_motorista)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_nomeProd)
        Me.GroupBox1.Controls.Add(Me.txt_codProd)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_nomePart)
        Me.GroupBox1.Controls.Add(Me.txt_codPart)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(587, 195)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'dtp_dtDevolucao
        '
        Me.dtp_dtDevolucao.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dtDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dtDevolucao.Location = New System.Drawing.Point(101, 141)
        Me.dtp_dtDevolucao.Name = "dtp_dtDevolucao"
        Me.dtp_dtDevolucao.Size = New System.Drawing.Size(100, 23)
        Me.dtp_dtDevolucao.TabIndex = 12
        '
        'dtp_dtEmprestimo
        '
        Me.dtp_dtEmprestimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dtEmprestimo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dtEmprestimo.Location = New System.Drawing.Point(101, 103)
        Me.dtp_dtEmprestimo.Name = "dtp_dtEmprestimo"
        Me.dtp_dtEmprestimo.Size = New System.Drawing.Size(100, 23)
        Me.dtp_dtEmprestimo.TabIndex = 10
        '
        'txt_motorista
        '
        Me.txt_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_motorista.Location = New System.Drawing.Point(74, 75)
        Me.txt_motorista.MaxLength = 30
        Me.txt_motorista.Name = "txt_motorista"
        Me.txt_motorista.Size = New System.Drawing.Size(272, 20)
        Me.txt_motorista.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Motorista:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "DT.Devolução:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "DtEmprestimo:"
        '
        'txt_nomeProd
        '
        Me.txt_nomeProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomeProd.Location = New System.Drawing.Point(151, 45)
        Me.txt_nomeProd.MaxLength = 80
        Me.txt_nomeProd.Name = "txt_nomeProd"
        Me.txt_nomeProd.ReadOnly = True
        Me.txt_nomeProd.Size = New System.Drawing.Size(308, 20)
        Me.txt_nomeProd.TabIndex = 6
        '
        'txt_codProd
        '
        Me.txt_codProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codProd.Location = New System.Drawing.Point(74, 45)
        Me.txt_codProd.MaxLength = 5
        Me.txt_codProd.Name = "txt_codProd"
        Me.txt_codProd.Size = New System.Drawing.Size(59, 20)
        Me.txt_codProd.TabIndex = 4
        Me.txt_codProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Produto:"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Location = New System.Drawing.Point(151, 15)
        Me.txt_nomePart.MaxLength = 80
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(308, 20)
        Me.txt_nomePart.TabIndex = 1
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Location = New System.Drawing.Point(74, 15)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(59, 20)
        Me.txt_codPart.TabIndex = 0
        Me.txt_codPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(627, 74)
        Me.Panel1.TabIndex = 7
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Wide Latin", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(444, 40)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(167, 22)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(226, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(156, 58)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Frm_ManMovComodato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 405)
        Me.Controls.Add(Me.tbc_comodatos)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ManMovComodato"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimentação de Comodatos"
        Me.tbc_comodatos.ResumeLayout(False)
        Me.tbp_visuComodato.ResumeLayout(False)
        Me.grp_opcoes.ResumeLayout(False)
        Me.grp_opcoes.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.Dtg_MovComodatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbp_cadComodato.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbc_comodatos As System.Windows.Forms.TabControl
    Friend WithEvents tbp_visuComodato As System.Windows.Forms.TabPage
    Friend WithEvents grp_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem01 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents Dtg_MovComodatos As System.Windows.Forms.DataGridView
    Friend WithEvents tbp_cadComodato As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_motorista As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Public WithEvents txt_codProd As System.Windows.Forms.TextBox
    Public WithEvents txt_nomeProd As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents dtp_dtEmprestimo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_dtDevolucao As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents idComodato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents produto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Plaqueta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataMov As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
