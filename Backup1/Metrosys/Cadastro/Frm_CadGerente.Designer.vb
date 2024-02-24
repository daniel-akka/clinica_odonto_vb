<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CadGerente
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CadGerente))
        Me.tbp_manutencao = New System.Windows.Forms.TabPage
        Me.cbo_local = New System.Windows.Forms.ComboBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.txt_senhaAtual = New System.Windows.Forms.TextBox
        Me.txt_redigita = New System.Windows.Forms.TextBox
        Me.lbl_senhaAtual = New System.Windows.Forms.Label
        Me.txt_senha = New System.Windows.Forms.TextBox
        Me.lbl_redigite = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.chk_libDesconto = New System.Windows.Forms.CheckBox
        Me.chk_privilegioLojas = New System.Windows.Forms.CheckBox
        Me.chk_libValor = New System.Windows.Forms.CheckBox
        Me.lbl_senha = New System.Windows.Forms.Label
        Me.txt_libVlrMaximo = New System.Windows.Forms.TextBox
        Me.txt_codGerente = New System.Windows.Forms.TextBox
        Me.txt_nome = New System.Windows.Forms.TextBox
        Me.lbl_libvalor = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbl_local = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.pct_foto = New System.Windows.Forms.PictureBox
        Me.btn_salvar = New System.Windows.Forms.Button
        Me.tbc_Gerente = New System.Windows.Forms.TabControl
        Me.tbp_vizualiza = New System.Windows.Forms.TabPage
        Me.Dtg_Gerente = New System.Windows.Forms.DataGridView
        Me.idUsu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.loja = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.privilegoLojas = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.libdesc = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.libvalor = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.valo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.btn_novo = New System.Windows.Forms.Button
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.txt_pesquisa = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.tbp_manutencao.SuspendLayout()
        CType(Me.pct_foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbc_Gerente.SuspendLayout()
        Me.tbp_vizualiza.SuspendLayout()
        CType(Me.Dtg_Gerente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbp_manutencao
        '
        Me.tbp_manutencao.Controls.Add(Me.cbo_local)
        Me.tbp_manutencao.Controls.Add(Me.btn_cancelar)
        Me.tbp_manutencao.Controls.Add(Me.txt_senhaAtual)
        Me.tbp_manutencao.Controls.Add(Me.txt_redigita)
        Me.tbp_manutencao.Controls.Add(Me.lbl_senhaAtual)
        Me.tbp_manutencao.Controls.Add(Me.txt_senha)
        Me.tbp_manutencao.Controls.Add(Me.lbl_redigite)
        Me.tbp_manutencao.Controls.Add(Me.Label6)
        Me.tbp_manutencao.Controls.Add(Me.chk_libDesconto)
        Me.tbp_manutencao.Controls.Add(Me.chk_privilegioLojas)
        Me.tbp_manutencao.Controls.Add(Me.chk_libValor)
        Me.tbp_manutencao.Controls.Add(Me.lbl_senha)
        Me.tbp_manutencao.Controls.Add(Me.txt_libVlrMaximo)
        Me.tbp_manutencao.Controls.Add(Me.txt_codGerente)
        Me.tbp_manutencao.Controls.Add(Me.txt_nome)
        Me.tbp_manutencao.Controls.Add(Me.lbl_libvalor)
        Me.tbp_manutencao.Controls.Add(Me.Label3)
        Me.tbp_manutencao.Controls.Add(Me.lbl_local)
        Me.tbp_manutencao.Controls.Add(Me.Label1)
        Me.tbp_manutencao.Controls.Add(Me.pct_foto)
        Me.tbp_manutencao.Controls.Add(Me.btn_salvar)
        Me.tbp_manutencao.Location = New System.Drawing.Point(4, 22)
        Me.tbp_manutencao.Name = "tbp_manutencao"
        Me.tbp_manutencao.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_manutencao.Size = New System.Drawing.Size(526, 309)
        Me.tbp_manutencao.TabIndex = 1
        Me.tbp_manutencao.Text = "Manutenção"
        Me.tbp_manutencao.UseVisualStyleBackColor = True
        '
        'cbo_local
        '
        Me.cbo_local.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_local.DropDownWidth = 235
        Me.cbo_local.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_local.FormattingEnabled = True
        Me.cbo_local.Location = New System.Drawing.Point(133, 11)
        Me.cbo_local.Name = "cbo_local"
        Me.cbo_local.Size = New System.Drawing.Size(173, 23)
        Me.cbo_local.TabIndex = 1
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.MetroSys.My.Resources.Resources.cancelar1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancelar.Location = New System.Drawing.Point(430, 256)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(83, 29)
        Me.btn_cancelar.TabIndex = 12
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'txt_senhaAtual
        '
        Me.txt_senhaAtual.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_senhaAtual.Location = New System.Drawing.Point(236, 257)
        Me.txt_senhaAtual.MaxLength = 10
        Me.txt_senhaAtual.Name = "txt_senhaAtual"
        Me.txt_senhaAtual.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_senhaAtual.Size = New System.Drawing.Size(90, 24)
        Me.txt_senhaAtual.TabIndex = 5
        Me.txt_senhaAtual.Visible = False
        '
        'txt_redigita
        '
        Me.txt_redigita.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_redigita.Location = New System.Drawing.Point(133, 109)
        Me.txt_redigita.MaxLength = 10
        Me.txt_redigita.Name = "txt_redigita"
        Me.txt_redigita.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_redigita.Size = New System.Drawing.Size(90, 24)
        Me.txt_redigita.TabIndex = 4
        '
        'lbl_senhaAtual
        '
        Me.lbl_senhaAtual.AutoSize = True
        Me.lbl_senhaAtual.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_senhaAtual.Location = New System.Drawing.Point(144, 260)
        Me.lbl_senhaAtual.Name = "lbl_senhaAtual"
        Me.lbl_senhaAtual.Size = New System.Drawing.Size(86, 18)
        Me.lbl_senhaAtual.TabIndex = 34
        Me.lbl_senhaAtual.Text = "SenhaAtual:"
        Me.lbl_senhaAtual.Visible = False
        '
        'txt_senha
        '
        Me.txt_senha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_senha.Location = New System.Drawing.Point(133, 77)
        Me.txt_senha.MaxLength = 10
        Me.txt_senha.Name = "txt_senha"
        Me.txt_senha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_senha.Size = New System.Drawing.Size(90, 24)
        Me.txt_senha.TabIndex = 3
        '
        'lbl_redigite
        '
        Me.lbl_redigite.AutoSize = True
        Me.lbl_redigite.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_redigite.Location = New System.Drawing.Point(53, 113)
        Me.lbl_redigite.Name = "lbl_redigite"
        Me.lbl_redigite.Size = New System.Drawing.Size(65, 18)
        Me.lbl_redigite.TabIndex = 34
        Me.lbl_redigite.Text = "Redigite:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(421, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 15)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Foto"
        '
        'chk_libDesconto
        '
        Me.chk_libDesconto.AutoSize = True
        Me.chk_libDesconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_libDesconto.Location = New System.Drawing.Point(57, 172)
        Me.chk_libDesconto.Name = "chk_libDesconto"
        Me.chk_libDesconto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chk_libDesconto.Size = New System.Drawing.Size(114, 21)
        Me.chk_libDesconto.TabIndex = 6
        Me.chk_libDesconto.Text = "Lib. Desconto"
        Me.chk_libDesconto.UseVisualStyleBackColor = True
        '
        'chk_privilegioLojas
        '
        Me.chk_privilegioLojas.AutoSize = True
        Me.chk_privilegioLojas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_privilegioLojas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_privilegioLojas.Location = New System.Drawing.Point(57, 199)
        Me.chk_privilegioLojas.Name = "chk_privilegioLojas"
        Me.chk_privilegioLojas.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chk_privilegioLojas.Size = New System.Drawing.Size(122, 21)
        Me.chk_privilegioLojas.TabIndex = 9
        Me.chk_privilegioLojas.Text = "Privilégio Lojas"
        Me.chk_privilegioLojas.UseVisualStyleBackColor = True
        '
        'chk_libValor
        '
        Me.chk_libValor.AutoSize = True
        Me.chk_libValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_libValor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_libValor.Location = New System.Drawing.Point(57, 145)
        Me.chk_libValor.Name = "chk_libValor"
        Me.chk_libValor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chk_libValor.Size = New System.Drawing.Size(87, 21)
        Me.chk_libValor.TabIndex = 7
        Me.chk_libValor.Text = "Lib. Valor"
        Me.chk_libValor.UseVisualStyleBackColor = True
        '
        'lbl_senha
        '
        Me.lbl_senha.AutoSize = True
        Me.lbl_senha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_senha.Location = New System.Drawing.Point(53, 80)
        Me.lbl_senha.Name = "lbl_senha"
        Me.lbl_senha.Size = New System.Drawing.Size(54, 18)
        Me.lbl_senha.TabIndex = 24
        Me.lbl_senha.Text = "Senha:"
        '
        'txt_libVlrMaximo
        '
        Me.txt_libVlrMaximo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_libVlrMaximo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_libVlrMaximo.Location = New System.Drawing.Point(233, 168)
        Me.txt_libVlrMaximo.MaxLength = 12
        Me.txt_libVlrMaximo.Name = "txt_libVlrMaximo"
        Me.txt_libVlrMaximo.ReadOnly = True
        Me.txt_libVlrMaximo.Size = New System.Drawing.Size(90, 24)
        Me.txt_libVlrMaximo.TabIndex = 8
        Me.txt_libVlrMaximo.Text = "0,00"
        Me.txt_libVlrMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_codGerente
        '
        Me.txt_codGerente.BackColor = System.Drawing.SystemColors.Info
        Me.txt_codGerente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codGerente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codGerente.Location = New System.Drawing.Point(460, 11)
        Me.txt_codGerente.MaxLength = 3
        Me.txt_codGerente.Name = "txt_codGerente"
        Me.txt_codGerente.ReadOnly = True
        Me.txt_codGerente.Size = New System.Drawing.Size(53, 24)
        Me.txt_codGerente.TabIndex = 20
        Me.txt_codGerente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_nome
        '
        Me.txt_nome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nome.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nome.Location = New System.Drawing.Point(133, 45)
        Me.txt_nome.MaxLength = 30
        Me.txt_nome.Name = "txt_nome"
        Me.txt_nome.Size = New System.Drawing.Size(173, 24)
        Me.txt_nome.TabIndex = 2
        '
        'lbl_libvalor
        '
        Me.lbl_libvalor.AutoSize = True
        Me.lbl_libvalor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_libvalor.Location = New System.Drawing.Point(184, 171)
        Me.lbl_libvalor.Name = "lbl_libvalor"
        Me.lbl_libvalor.Size = New System.Drawing.Size(46, 18)
        Me.lbl_libvalor.TabIndex = 18
        Me.lbl_libvalor.Text = "Valor:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(414, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 18)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Cod."
        '
        'lbl_local
        '
        Me.lbl_local.AutoSize = True
        Me.lbl_local.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_local.Location = New System.Drawing.Point(54, 12)
        Me.lbl_local.Name = "lbl_local"
        Me.lbl_local.Size = New System.Drawing.Size(48, 18)
        Me.lbl_local.TabIndex = 18
        Me.lbl_local.Text = "Local:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(54, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 18)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Nome:"
        '
        'pct_foto
        '
        Me.pct_foto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pct_foto.Location = New System.Drawing.Point(356, 60)
        Me.pct_foto.Name = "pct_foto"
        Me.pct_foto.Size = New System.Drawing.Size(157, 158)
        Me.pct_foto.TabIndex = 32
        Me.pct_foto.TabStop = False
        '
        'btn_salvar
        '
        Me.btn_salvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salvar.Image = Global.MetroSys.My.Resources.Resources.salvar
        Me.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salvar.Location = New System.Drawing.Point(430, 225)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(83, 29)
        Me.btn_salvar.TabIndex = 11
        Me.btn_salvar.Text = "&Salvar"
        Me.btn_salvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'tbc_Gerente
        '
        Me.tbc_Gerente.Controls.Add(Me.tbp_vizualiza)
        Me.tbc_Gerente.Controls.Add(Me.tbp_manutencao)
        Me.tbc_Gerente.Location = New System.Drawing.Point(9, 87)
        Me.tbc_Gerente.Name = "tbc_Gerente"
        Me.tbc_Gerente.SelectedIndex = 0
        Me.tbc_Gerente.Size = New System.Drawing.Size(534, 335)
        Me.tbc_Gerente.TabIndex = 20
        '
        'tbp_vizualiza
        '
        Me.tbp_vizualiza.Controls.Add(Me.Dtg_Gerente)
        Me.tbp_vizualiza.Controls.Add(Me.btn_excluir)
        Me.tbp_vizualiza.Controls.Add(Me.btn_novo)
        Me.tbp_vizualiza.Controls.Add(Me.btn_alterar)
        Me.tbp_vizualiza.Controls.Add(Me.txt_pesquisa)
        Me.tbp_vizualiza.Controls.Add(Me.Label7)
        Me.tbp_vizualiza.Controls.Add(Me.GroupBox1)
        Me.tbp_vizualiza.Location = New System.Drawing.Point(4, 22)
        Me.tbp_vizualiza.Name = "tbp_vizualiza"
        Me.tbp_vizualiza.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_vizualiza.Size = New System.Drawing.Size(526, 309)
        Me.tbp_vizualiza.TabIndex = 0
        Me.tbp_vizualiza.Text = "Vizualização"
        Me.tbp_vizualiza.UseVisualStyleBackColor = True
        '
        'Dtg_Gerente
        '
        Me.Dtg_Gerente.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtg_Gerente.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dtg_Gerente.BackgroundColor = System.Drawing.Color.Gray
        Me.Dtg_Gerente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dtg_Gerente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.Dtg_Gerente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Dtg_Gerente.ColumnHeadersHeight = 26
        Me.Dtg_Gerente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dtg_Gerente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idUsu, Me.loja, Me.codigo, Me.nome, Me.privilegoLojas, Me.libdesc, Me.libvalor, Me.valo})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dtg_Gerente.DefaultCellStyle = DataGridViewCellStyle7
        Me.Dtg_Gerente.Location = New System.Drawing.Point(13, 52)
        Me.Dtg_Gerente.MultiSelect = False
        Me.Dtg_Gerente.Name = "Dtg_Gerente"
        Me.Dtg_Gerente.ReadOnly = True
        Me.Dtg_Gerente.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dtg_Gerente.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Dtg_Gerente.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dtg_Gerente.Size = New System.Drawing.Size(496, 181)
        Me.Dtg_Gerente.TabIndex = 25
        '
        'idUsu
        '
        Me.idUsu.HeaderText = "Id"
        Me.idUsu.MaxInputLength = 13
        Me.idUsu.Name = "idUsu"
        Me.idUsu.ReadOnly = True
        Me.idUsu.Visible = False
        '
        'loja
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loja.DefaultCellStyle = DataGridViewCellStyle2
        Me.loja.HeaderText = "Loja"
        Me.loja.MaxInputLength = 5
        Me.loja.Name = "loja"
        Me.loja.ReadOnly = True
        Me.loja.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.loja.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.loja.Width = 50
        '
        'codigo
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigo.DefaultCellStyle = DataGridViewCellStyle3
        Me.codigo.HeaderText = "Cod."
        Me.codigo.MaxInputLength = 3
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.codigo.Width = 43
        '
        'nome
        '
        Me.nome.HeaderText = "Nome"
        Me.nome.MaxInputLength = 30
        Me.nome.Name = "nome"
        Me.nome.ReadOnly = True
        Me.nome.Width = 150
        '
        'privilegoLojas
        '
        Me.privilegoLojas.HeaderText = "Privlegio"
        Me.privilegoLojas.Name = "privilegoLojas"
        Me.privilegoLojas.ReadOnly = True
        Me.privilegoLojas.Width = 60
        '
        'libdesc
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.NullValue = False
        Me.libdesc.DefaultCellStyle = DataGridViewCellStyle4
        Me.libdesc.HeaderText = "Desc."
        Me.libdesc.Name = "libdesc"
        Me.libdesc.ReadOnly = True
        Me.libdesc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.libdesc.Width = 40
        '
        'libvalor
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.NullValue = False
        Me.libvalor.DefaultCellStyle = DataGridViewCellStyle5
        Me.libvalor.HeaderText = "Valor"
        Me.libvalor.MinimumWidth = 2
        Me.libvalor.Name = "libvalor"
        Me.libvalor.ReadOnly = True
        Me.libvalor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.libvalor.Width = 40
        '
        'valo
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.valo.DefaultCellStyle = DataGridViewCellStyle6
        Me.valo.HeaderText = "Valor"
        Me.valo.MaxInputLength = 14
        Me.valo.Name = "valo"
        Me.valo.ReadOnly = True
        Me.valo.Width = 70
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excluir.Location = New System.Drawing.Point(437, 12)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(72, 34)
        Me.btn_excluir.TabIndex = 24
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_novo
        '
        Me.btn_novo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_novo.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_novo.Location = New System.Drawing.Point(288, 12)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(72, 34)
        Me.btn_novo.TabIndex = 21
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.editar
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(363, 12)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(72, 34)
        Me.btn_alterar.TabIndex = 23
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(64, 19)
        Me.txt_pesquisa.MaxLength = 80
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(216, 23)
        Me.txt_pesquisa.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Nome:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 239)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 52)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mensagem"
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
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(440, 58)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(84, 20)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-2, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(553, 89)
        Me.Panel1.TabIndex = 21
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(157, 7)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(209, 70)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(425, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Frm_CadGerente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 427)
        Me.Controls.Add(Me.tbc_Gerente)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_CadGerente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Gerentes"
        Me.tbp_manutencao.ResumeLayout(False)
        Me.tbp_manutencao.PerformLayout()
        CType(Me.pct_foto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbc_Gerente.ResumeLayout(False)
        Me.tbp_vizualiza.ResumeLayout(False)
        Me.tbp_vizualiza.PerformLayout()
        CType(Me.Dtg_Gerente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbp_manutencao As System.Windows.Forms.TabPage
    Friend WithEvents cbo_local As System.Windows.Forms.ComboBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents txt_senhaAtual As System.Windows.Forms.TextBox
    Friend WithEvents txt_redigita As System.Windows.Forms.TextBox
    Friend WithEvents lbl_senhaAtual As System.Windows.Forms.Label
    Friend WithEvents txt_senha As System.Windows.Forms.TextBox
    Friend WithEvents lbl_redigite As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents chk_libDesconto As System.Windows.Forms.CheckBox
    Public WithEvents chk_libValor As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_senha As System.Windows.Forms.Label
    Public WithEvents txt_nome As System.Windows.Forms.TextBox
    Friend WithEvents lbl_local As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pct_foto As System.Windows.Forms.PictureBox
    Public WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents tbc_Gerente As System.Windows.Forms.TabControl
    Friend WithEvents tbp_vizualiza As System.Windows.Forms.TabPage
    Friend WithEvents Dtg_Gerente As System.Windows.Forms.DataGridView
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Public WithEvents txt_libVlrMaximo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_libvalor As System.Windows.Forms.Label
    Public WithEvents chk_privilegioLojas As System.Windows.Forms.CheckBox
    Public WithEvents txt_codGerente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents idUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents loja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents privilegoLojas As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents libdesc As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents libvalor As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents valo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
