<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_UsuariosManutencao
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbc_usuario = New System.Windows.Forms.TabControl()
        Me.tbp_vizualiza = New System.Windows.Forms.TabPage()
        Me.Dg_usuario = New System.Windows.Forms.DataGridView()
        Me.idUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.login = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.privilegio = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bloqueado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbp_manutencao = New System.Windows.Forms.TabPage()
        Me.cbo_caixa = New System.Windows.Forms.ComboBox()
        Me.cbo_cargoUsuario = New System.Windows.Forms.ComboBox()
        Me.cbo_local = New System.Windows.Forms.ComboBox()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.txt_senhaAtual = New System.Windows.Forms.TextBox()
        Me.txt_redigita = New System.Windows.Forms.TextBox()
        Me.lbl_senhaAtual = New System.Windows.Forms.Label()
        Me.txt_senha = New System.Windows.Forms.TextBox()
        Me.lbl_redigite = New System.Windows.Forms.Label()
        Me.chk_privilegio = New System.Windows.Forms.CheckBox()
        Me.chk_bloqueado = New System.Windows.Forms.CheckBox()
        Me.msk_dtnascimento = New System.Windows.Forms.MaskedTextBox()
        Me.txt_login = New System.Windows.Forms.TextBox()
        Me.lbl_senha = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_caixa = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_nome = New System.Windows.Forms.TextBox()
        Me.lbl_local = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_acesso = New System.Windows.Forms.Button()
        Me.pct_foto = New System.Windows.Forms.PictureBox()
        Me.btn_salvar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.tbc_usuario.SuspendLayout()
        Me.tbp_vizualiza.SuspendLayout()
        CType(Me.Dg_usuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tbp_manutencao.SuspendLayout()
        CType(Me.pct_foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbc_usuario
        '
        Me.tbc_usuario.Controls.Add(Me.tbp_vizualiza)
        Me.tbc_usuario.Controls.Add(Me.tbp_manutencao)
        Me.tbc_usuario.Location = New System.Drawing.Point(9, 46)
        Me.tbc_usuario.Name = "tbc_usuario"
        Me.tbc_usuario.SelectedIndex = 0
        Me.tbc_usuario.Size = New System.Drawing.Size(619, 335)
        Me.tbc_usuario.TabIndex = 18
        '
        'tbp_vizualiza
        '
        Me.tbp_vizualiza.Controls.Add(Me.Dg_usuario)
        Me.tbp_vizualiza.Controls.Add(Me.btn_excluir)
        Me.tbp_vizualiza.Controls.Add(Me.btn_novo)
        Me.tbp_vizualiza.Controls.Add(Me.btn_alterar)
        Me.tbp_vizualiza.Controls.Add(Me.txt_pesquisa)
        Me.tbp_vizualiza.Controls.Add(Me.Label7)
        Me.tbp_vizualiza.Controls.Add(Me.GroupBox1)
        Me.tbp_vizualiza.Location = New System.Drawing.Point(4, 22)
        Me.tbp_vizualiza.Name = "tbp_vizualiza"
        Me.tbp_vizualiza.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_vizualiza.Size = New System.Drawing.Size(611, 309)
        Me.tbp_vizualiza.TabIndex = 0
        Me.tbp_vizualiza.Text = "Vizualização"
        Me.tbp_vizualiza.UseVisualStyleBackColor = True
        '
        'Dg_usuario
        '
        Me.Dg_usuario.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dg_usuario.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dg_usuario.BackgroundColor = System.Drawing.Color.Gray
        Me.Dg_usuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dg_usuario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.Dg_usuario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dg_usuario.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dg_usuario.ColumnHeadersHeight = 26
        Me.Dg_usuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dg_usuario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idUsu, Me.nome, Me.login, Me.privilegio, Me.bloqueado})
        Me.Dg_usuario.Location = New System.Drawing.Point(13, 52)
        Me.Dg_usuario.MultiSelect = False
        Me.Dg_usuario.Name = "Dg_usuario"
        Me.Dg_usuario.ReadOnly = True
        Me.Dg_usuario.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Dg_usuario.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dg_usuario.Size = New System.Drawing.Size(496, 181)
        Me.Dg_usuario.TabIndex = 25
        '
        'idUsu
        '
        Me.idUsu.HeaderText = "Id"
        Me.idUsu.MaxInputLength = 13
        Me.idUsu.Name = "idUsu"
        Me.idUsu.ReadOnly = True
        Me.idUsu.Visible = False
        '
        'nome
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nome.DefaultCellStyle = DataGridViewCellStyle3
        Me.nome.HeaderText = "Nome"
        Me.nome.MaxInputLength = 30
        Me.nome.Name = "nome"
        Me.nome.ReadOnly = True
        Me.nome.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nome.Width = 200
        '
        'login
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.login.DefaultCellStyle = DataGridViewCellStyle4
        Me.login.HeaderText = "Login"
        Me.login.MaxInputLength = 10
        Me.login.Name = "login"
        Me.login.ReadOnly = True
        Me.login.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.login.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'privilegio
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.NullValue = False
        Me.privilegio.DefaultCellStyle = DataGridViewCellStyle5
        Me.privilegio.HeaderText = "Privilegio"
        Me.privilegio.Name = "privilegio"
        Me.privilegio.ReadOnly = True
        Me.privilegio.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.privilegio.Width = 75
        '
        'bloqueado
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.NullValue = False
        Me.bloqueado.DefaultCellStyle = DataGridViewCellStyle6
        Me.bloqueado.HeaderText = "Bloqueado"
        Me.bloqueado.MinimumWidth = 2
        Me.bloqueado.Name = "bloqueado"
        Me.bloqueado.ReadOnly = True
        Me.bloqueado.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.bloqueado.Width = 78
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.RTecSys.My.Resources.Resources.Delete
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
        Me.btn_novo.Image = Global.RTecSys.My.Resources.Resources.Add
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
        Me.btn_alterar.Image = Global.RTecSys.My.Resources.Resources.editar
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
        'tbp_manutencao
        '
        Me.tbp_manutencao.Controls.Add(Me.cbo_caixa)
        Me.tbp_manutencao.Controls.Add(Me.cbo_cargoUsuario)
        Me.tbp_manutencao.Controls.Add(Me.cbo_local)
        Me.tbp_manutencao.Controls.Add(Me.btn_cancelar)
        Me.tbp_manutencao.Controls.Add(Me.txt_senhaAtual)
        Me.tbp_manutencao.Controls.Add(Me.txt_redigita)
        Me.tbp_manutencao.Controls.Add(Me.lbl_senhaAtual)
        Me.tbp_manutencao.Controls.Add(Me.txt_senha)
        Me.tbp_manutencao.Controls.Add(Me.lbl_redigite)
        Me.tbp_manutencao.Controls.Add(Me.chk_privilegio)
        Me.tbp_manutencao.Controls.Add(Me.chk_bloqueado)
        Me.tbp_manutencao.Controls.Add(Me.msk_dtnascimento)
        Me.tbp_manutencao.Controls.Add(Me.txt_login)
        Me.tbp_manutencao.Controls.Add(Me.lbl_senha)
        Me.tbp_manutencao.Controls.Add(Me.Label3)
        Me.tbp_manutencao.Controls.Add(Me.lbl_caixa)
        Me.tbp_manutencao.Controls.Add(Me.Label2)
        Me.tbp_manutencao.Controls.Add(Me.Label5)
        Me.tbp_manutencao.Controls.Add(Me.txt_nome)
        Me.tbp_manutencao.Controls.Add(Me.lbl_local)
        Me.tbp_manutencao.Controls.Add(Me.Label1)
        Me.tbp_manutencao.Controls.Add(Me.btn_acesso)
        Me.tbp_manutencao.Controls.Add(Me.pct_foto)
        Me.tbp_manutencao.Controls.Add(Me.btn_salvar)
        Me.tbp_manutencao.Location = New System.Drawing.Point(4, 22)
        Me.tbp_manutencao.Name = "tbp_manutencao"
        Me.tbp_manutencao.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_manutencao.Size = New System.Drawing.Size(611, 309)
        Me.tbp_manutencao.TabIndex = 1
        Me.tbp_manutencao.Text = "Manutenção"
        Me.tbp_manutencao.UseVisualStyleBackColor = True
        '
        'cbo_caixa
        '
        Me.cbo_caixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_caixa.DropDownWidth = 125
        Me.cbo_caixa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_caixa.FormattingEnabled = True
        Me.cbo_caixa.Location = New System.Drawing.Point(501, 41)
        Me.cbo_caixa.Name = "cbo_caixa"
        Me.cbo_caixa.Size = New System.Drawing.Size(99, 23)
        Me.cbo_caixa.TabIndex = 35
        Me.cbo_caixa.Visible = False
        '
        'cbo_cargoUsuario
        '
        Me.cbo_cargoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_cargoUsuario.DropDownWidth = 125
        Me.cbo_cargoUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_cargoUsuario.FormattingEnabled = True
        Me.cbo_cargoUsuario.Location = New System.Drawing.Point(501, 11)
        Me.cbo_cargoUsuario.Name = "cbo_cargoUsuario"
        Me.cbo_cargoUsuario.Size = New System.Drawing.Size(99, 23)
        Me.cbo_cargoUsuario.TabIndex = 35
        '
        'cbo_local
        '
        Me.cbo_local.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_local.DropDownWidth = 235
        Me.cbo_local.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_local.FormattingEnabled = True
        Me.cbo_local.Location = New System.Drawing.Point(61, 11)
        Me.cbo_local.Name = "cbo_local"
        Me.cbo_local.Size = New System.Drawing.Size(300, 23)
        Me.cbo_local.TabIndex = 1
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.RTecSys.My.Resources.Resources.cancelar1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancelar.Location = New System.Drawing.Point(517, 256)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(83, 29)
        Me.btn_cancelar.TabIndex = 24
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
        Me.txt_senhaAtual.TabIndex = 9
        Me.txt_senhaAtual.Visible = False
        '
        'txt_redigita
        '
        Me.txt_redigita.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_redigita.Location = New System.Drawing.Point(133, 173)
        Me.txt_redigita.MaxLength = 10
        Me.txt_redigita.Name = "txt_redigita"
        Me.txt_redigita.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_redigita.Size = New System.Drawing.Size(90, 24)
        Me.txt_redigita.TabIndex = 12
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
        Me.txt_senha.Location = New System.Drawing.Point(133, 141)
        Me.txt_senha.MaxLength = 10
        Me.txt_senha.Name = "txt_senha"
        Me.txt_senha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_senha.Size = New System.Drawing.Size(90, 24)
        Me.txt_senha.TabIndex = 10
        '
        'lbl_redigite
        '
        Me.lbl_redigite.AutoSize = True
        Me.lbl_redigite.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_redigite.Location = New System.Drawing.Point(61, 177)
        Me.lbl_redigite.Name = "lbl_redigite"
        Me.lbl_redigite.Size = New System.Drawing.Size(65, 18)
        Me.lbl_redigite.TabIndex = 34
        Me.lbl_redigite.Text = "Redigite:"
        '
        'chk_privilegio
        '
        Me.chk_privilegio.AutoSize = True
        Me.chk_privilegio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_privilegio.Location = New System.Drawing.Point(12, 209)
        Me.chk_privilegio.Name = "chk_privilegio"
        Me.chk_privilegio.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chk_privilegio.Size = New System.Drawing.Size(114, 21)
        Me.chk_privilegio.TabIndex = 14
        Me.chk_privilegio.Text = "Administrador"
        Me.chk_privilegio.UseVisualStyleBackColor = True
        '
        'chk_bloqueado
        '
        Me.chk_bloqueado.AutoSize = True
        Me.chk_bloqueado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_bloqueado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_bloqueado.Location = New System.Drawing.Point(31, 232)
        Me.chk_bloqueado.Name = "chk_bloqueado"
        Me.chk_bloqueado.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chk_bloqueado.Size = New System.Drawing.Size(95, 21)
        Me.chk_bloqueado.TabIndex = 16
        Me.chk_bloqueado.Text = "Bloqueado"
        Me.chk_bloqueado.UseVisualStyleBackColor = True
        '
        'msk_dtnascimento
        '
        Me.msk_dtnascimento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_dtnascimento.Location = New System.Drawing.Point(133, 109)
        Me.msk_dtnascimento.Mask = "99/99/9999"
        Me.msk_dtnascimento.Name = "msk_dtnascimento"
        Me.msk_dtnascimento.Size = New System.Drawing.Size(90, 24)
        Me.msk_dtnascimento.TabIndex = 8
        '
        'txt_login
        '
        Me.txt_login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_login.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_login.Location = New System.Drawing.Point(133, 77)
        Me.txt_login.MaxLength = 10
        Me.txt_login.Name = "txt_login"
        Me.txt_login.Size = New System.Drawing.Size(100, 24)
        Me.txt_login.TabIndex = 6
        '
        'lbl_senha
        '
        Me.lbl_senha.AutoSize = True
        Me.lbl_senha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_senha.Location = New System.Drawing.Point(72, 144)
        Me.lbl_senha.Name = "lbl_senha"
        Me.lbl_senha.Size = New System.Drawing.Size(54, 18)
        Me.lbl_senha.TabIndex = 24
        Me.lbl_senha.Text = "Senha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 18)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "DataNascimento:"
        '
        'lbl_caixa
        '
        Me.lbl_caixa.AutoSize = True
        Me.lbl_caixa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_caixa.Location = New System.Drawing.Point(448, 42)
        Me.lbl_caixa.Name = "lbl_caixa"
        Me.lbl_caixa.Size = New System.Drawing.Size(49, 18)
        Me.lbl_caixa.TabIndex = 18
        Me.lbl_caixa.Text = "Caixa:"
        Me.lbl_caixa.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 18)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Login:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(444, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 18)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Cargo:"
        '
        'txt_nome
        '
        Me.txt_nome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nome.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nome.Location = New System.Drawing.Point(133, 45)
        Me.txt_nome.MaxLength = 30
        Me.txt_nome.Name = "txt_nome"
        Me.txt_nome.Size = New System.Drawing.Size(173, 24)
        Me.txt_nome.TabIndex = 4
        '
        'lbl_local
        '
        Me.lbl_local.AutoSize = True
        Me.lbl_local.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_local.Location = New System.Drawing.Point(7, 12)
        Me.lbl_local.Name = "lbl_local"
        Me.lbl_local.Size = New System.Drawing.Size(48, 18)
        Me.lbl_local.TabIndex = 18
        Me.lbl_local.Text = "Local:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(73, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 18)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Nome:"
        '
        'btn_acesso
        '
        Me.btn_acesso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_acesso.Image = Global.RTecSys.My.Resources.Resources.controle_usuarios1
        Me.btn_acesso.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_acesso.Location = New System.Drawing.Point(443, 225)
        Me.btn_acesso.Name = "btn_acesso"
        Me.btn_acesso.Size = New System.Drawing.Size(69, 60)
        Me.btn_acesso.TabIndex = 20
        Me.btn_acesso.Text = "&Acessos"
        Me.btn_acesso.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_acesso.UseVisualStyleBackColor = True
        '
        'pct_foto
        '
        Me.pct_foto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pct_foto.Location = New System.Drawing.Point(443, 77)
        Me.pct_foto.Name = "pct_foto"
        Me.pct_foto.Size = New System.Drawing.Size(157, 141)
        Me.pct_foto.TabIndex = 32
        Me.pct_foto.TabStop = False
        '
        'btn_salvar
        '
        Me.btn_salvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salvar.Image = Global.RTecSys.My.Resources.Resources.salvar
        Me.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salvar.Location = New System.Drawing.Point(517, 225)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(83, 29)
        Me.btn_salvar.TabIndex = 22
        Me.btn_salvar.Text = "&Salvar"
        Me.btn_salvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-7, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(645, 42)
        Me.Panel1.TabIndex = 56
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(232, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Frm_UsuariosManutencao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 391)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tbc_usuario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_UsuariosManutencao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Usuários"
        Me.tbc_usuario.ResumeLayout(False)
        Me.tbp_vizualiza.ResumeLayout(False)
        Me.tbp_vizualiza.PerformLayout()
        CType(Me.Dg_usuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbp_manutencao.ResumeLayout(False)
        Me.tbp_manutencao.PerformLayout()
        CType(Me.pct_foto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbc_usuario As System.Windows.Forms.TabControl
    Friend WithEvents tbp_vizualiza As System.Windows.Forms.TabPage
    Friend WithEvents tbp_manutencao As System.Windows.Forms.TabPage
    Friend WithEvents txt_redigita As System.Windows.Forms.TextBox
    Friend WithEvents txt_senha As System.Windows.Forms.TextBox
    Public WithEvents btn_acesso As System.Windows.Forms.Button
    Friend WithEvents lbl_redigite As System.Windows.Forms.Label
    Friend WithEvents pct_foto As System.Windows.Forms.PictureBox
    Public WithEvents chk_privilegio As System.Windows.Forms.CheckBox
    Public WithEvents chk_bloqueado As System.Windows.Forms.CheckBox
    Public WithEvents btn_salvar As System.Windows.Forms.Button
    Public WithEvents msk_dtnascimento As System.Windows.Forms.MaskedTextBox
    Public WithEvents txt_login As System.Windows.Forms.TextBox
    Friend WithEvents lbl_senha As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents txt_nome As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dg_usuario As System.Windows.Forms.DataGridView
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents idUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents login As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents privilegio As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents bloqueado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txt_senhaAtual As System.Windows.Forms.TextBox
    Friend WithEvents lbl_senhaAtual As System.Windows.Forms.Label
    Friend WithEvents cbo_local As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_local As System.Windows.Forms.Label
    Friend WithEvents cbo_cargoUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_caixa As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_caixa As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
End Class
