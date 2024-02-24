<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CadGrade
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CadGrade))
        Me.tbc_Grade = New System.Windows.Forms.TabControl
        Me.tbp_visuGrade = New System.Windows.Forms.TabPage
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.btn_novo = New System.Windows.Forms.Button
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lbl_menssage1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Dtg_grade = New System.Windows.Forms.DataGridView
        Me.tbp_manutencaoGrade = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbl_menssage2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_salvar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.pnl_totalqtde = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_qtdeTotal = New System.Windows.Forms.Label
        Me.pnl_somaqtde = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbl_qtdeSoma = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbo_cores = New System.Windows.Forms.ComboBox
        Me.txt_qtde = New System.Windows.Forms.TextBox
        Me.txt_tamanho = New System.Windows.Forms.TextBox
        Me.txt_nomeProd = New System.Windows.Forms.TextBox
        Me.txt_codProd = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.tbc_Grade.SuspendLayout()
        Me.tbp_visuGrade.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Dtg_grade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbp_manutencaoGrade.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnl_totalqtde.SuspendLayout()
        Me.pnl_somaqtde.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbc_Grade
        '
        Me.tbc_Grade.Controls.Add(Me.tbp_visuGrade)
        Me.tbc_Grade.Controls.Add(Me.tbp_manutencaoGrade)
        Me.tbc_Grade.Location = New System.Drawing.Point(4, 71)
        Me.tbc_Grade.Name = "tbc_Grade"
        Me.tbc_Grade.SelectedIndex = 0
        Me.tbc_Grade.Size = New System.Drawing.Size(741, 261)
        Me.tbc_Grade.TabIndex = 10
        '
        'tbp_visuGrade
        '
        Me.tbp_visuGrade.Controls.Add(Me.Label9)
        Me.tbp_visuGrade.Controls.Add(Me.GroupBox5)
        Me.tbp_visuGrade.Controls.Add(Me.GroupBox4)
        Me.tbp_visuGrade.Controls.Add(Me.Dtg_grade)
        Me.tbp_visuGrade.Location = New System.Drawing.Point(4, 22)
        Me.tbp_visuGrade.Name = "tbp_visuGrade"
        Me.tbp_visuGrade.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_visuGrade.Size = New System.Drawing.Size(733, 235)
        Me.tbp_visuGrade.TabIndex = 0
        Me.tbp_visuGrade.Text = "Visualização"
        Me.tbp_visuGrade.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(150, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "[F5] - Atualiza a Consulta"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btn_novo)
        Me.GroupBox5.Controls.Add(Me.btn_alterar)
        Me.GroupBox5.Controls.Add(Me.btn_excluir)
        Me.GroupBox5.Location = New System.Drawing.Point(639, 23)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(88, 148)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        '
        'btn_novo
        '
        Me.btn_novo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_novo.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_novo.Location = New System.Drawing.Point(9, 13)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(73, 39)
        Me.btn_novo.TabIndex = 2
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.Modify
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(9, 58)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(73, 39)
        Me.btn_alterar.TabIndex = 4
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excluir.Location = New System.Drawing.Point(9, 103)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(73, 39)
        Me.btn_excluir.TabIndex = 6
        Me.btn_excluir.Text = " &Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbl_menssage1)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 181)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(720, 40)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Mensagem"
        '
        'lbl_menssage1
        '
        Me.lbl_menssage1.AutoSize = True
        Me.lbl_menssage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_menssage1.ForeColor = System.Drawing.Color.Red
        Me.lbl_menssage1.Location = New System.Drawing.Point(10, 17)
        Me.lbl_menssage1.Name = "lbl_menssage1"
        Me.lbl_menssage1.Size = New System.Drawing.Size(23, 15)
        Me.lbl_menssage1.TabIndex = 1
        Me.lbl_menssage1.Text = ".   "
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
        'Dtg_grade
        '
        Me.Dtg_grade.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtg_grade.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dtg_grade.BackgroundColor = System.Drawing.Color.Gray
        Me.Dtg_grade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dtg_grade.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.Dtg_grade.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dtg_grade.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dtg_grade.ColumnHeadersHeight = 22
        Me.Dtg_grade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dtg_grade.DefaultCellStyle = DataGridViewCellStyle3
        Me.Dtg_grade.Location = New System.Drawing.Point(10, 23)
        Me.Dtg_grade.MultiSelect = False
        Me.Dtg_grade.Name = "Dtg_grade"
        Me.Dtg_grade.ReadOnly = True
        Me.Dtg_grade.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Dtg_grade.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dtg_grade.Size = New System.Drawing.Size(623, 148)
        Me.Dtg_grade.TabIndex = 19
        '
        'tbp_manutencaoGrade
        '
        Me.tbp_manutencaoGrade.Controls.Add(Me.GroupBox3)
        Me.tbp_manutencaoGrade.Controls.Add(Me.GroupBox2)
        Me.tbp_manutencaoGrade.Controls.Add(Me.GroupBox1)
        Me.tbp_manutencaoGrade.Location = New System.Drawing.Point(4, 22)
        Me.tbp_manutencaoGrade.Name = "tbp_manutencaoGrade"
        Me.tbp_manutencaoGrade.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_manutencaoGrade.Size = New System.Drawing.Size(733, 235)
        Me.tbp_manutencaoGrade.TabIndex = 1
        Me.tbp_manutencaoGrade.Text = "Manutenção"
        Me.tbp_manutencaoGrade.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_menssage2)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 155)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(547, 60)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'lbl_menssage2
        '
        Me.lbl_menssage2.AutoSize = True
        Me.lbl_menssage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_menssage2.ForeColor = System.Drawing.Color.Red
        Me.lbl_menssage2.Location = New System.Drawing.Point(10, 24)
        Me.lbl_menssage2.Name = "lbl_menssage2"
        Me.lbl_menssage2.Size = New System.Drawing.Size(19, 15)
        Me.lbl_menssage2.TabIndex = 12
        Me.lbl_menssage2.Text = ".   "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_salvar)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Location = New System.Drawing.Point(563, 155)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(164, 60)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'btn_salvar
        '
        Me.btn_salvar.Enabled = False
        Me.btn_salvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salvar.Image = Global.MetroSys.My.Resources.Resources.Save
        Me.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salvar.Location = New System.Drawing.Point(6, 11)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(75, 45)
        Me.btn_salvar.TabIndex = 30
        Me.btn_salvar.Text = "&Salvar"
        Me.btn_salvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.MetroSys.My.Resources.Resources.cancelar
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(87, 11)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 45)
        Me.btn_cancelar.TabIndex = 32
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pnl_totalqtde)
        Me.GroupBox1.Controls.Add(Me.pnl_somaqtde)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbo_cores)
        Me.GroupBox1.Controls.Add(Me.txt_qtde)
        Me.GroupBox1.Controls.Add(Me.txt_tamanho)
        Me.GroupBox1.Controls.Add(Me.txt_nomeProd)
        Me.GroupBox1.Controls.Add(Me.txt_codProd)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(718, 145)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'pnl_totalqtde
        '
        Me.pnl_totalqtde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_totalqtde.Controls.Add(Me.Label5)
        Me.pnl_totalqtde.Controls.Add(Me.lbl_qtdeTotal)
        Me.pnl_totalqtde.Location = New System.Drawing.Point(588, 15)
        Me.pnl_totalqtde.Name = "pnl_totalqtde"
        Me.pnl_totalqtde.Size = New System.Drawing.Size(124, 26)
        Me.pnl_totalqtde.TabIndex = 21
        Me.pnl_totalqtde.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "&TotQtd:"
        '
        'lbl_qtdeTotal
        '
        Me.lbl_qtdeTotal.AutoSize = True
        Me.lbl_qtdeTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_qtdeTotal.ForeColor = System.Drawing.Color.Red
        Me.lbl_qtdeTotal.Location = New System.Drawing.Point(43, 4)
        Me.lbl_qtdeTotal.Name = "lbl_qtdeTotal"
        Me.lbl_qtdeTotal.Size = New System.Drawing.Size(35, 15)
        Me.lbl_qtdeTotal.TabIndex = 20
        Me.lbl_qtdeTotal.Text = "0,00"
        Me.lbl_qtdeTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnl_somaqtde
        '
        Me.pnl_somaqtde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_somaqtde.Controls.Add(Me.Label7)
        Me.pnl_somaqtde.Controls.Add(Me.lbl_qtdeSoma)
        Me.pnl_somaqtde.Location = New System.Drawing.Point(588, 44)
        Me.pnl_somaqtde.Name = "pnl_somaqtde"
        Me.pnl_somaqtde.Size = New System.Drawing.Size(124, 26)
        Me.pnl_somaqtde.TabIndex = 21
        Me.pnl_somaqtde.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "&Soma:"
        '
        'lbl_qtdeSoma
        '
        Me.lbl_qtdeSoma.AutoSize = True
        Me.lbl_qtdeSoma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_qtdeSoma.ForeColor = System.Drawing.Color.Red
        Me.lbl_qtdeSoma.Location = New System.Drawing.Point(43, 4)
        Me.lbl_qtdeSoma.Name = "lbl_qtdeSoma"
        Me.lbl_qtdeSoma.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_qtdeSoma.Size = New System.Drawing.Size(35, 15)
        Me.lbl_qtdeSoma.TabIndex = 20
        Me.lbl_qtdeSoma.Text = "0,00"
        Me.lbl_qtdeSoma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(111, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(156, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Exemplo:31,32,33,.., P,M,G,GG"
        '
        'cbo_cores
        '
        Me.cbo_cores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_cores.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_cores.FormattingEnabled = True
        Me.cbo_cores.Items.AddRange(New Object() {"Amarelo", "Azul", "Braco", "Creme", "Marrom", "Nenhum", "Preto", "Rosa", "Verde", "Vermelho"})
        Me.cbo_cores.Location = New System.Drawing.Point(65, 104)
        Me.cbo_cores.Name = "cbo_cores"
        Me.cbo_cores.Size = New System.Drawing.Size(105, 24)
        Me.cbo_cores.Sorted = True
        Me.cbo_cores.TabIndex = 18
        '
        'txt_qtde
        '
        Me.txt_qtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtde.Location = New System.Drawing.Point(65, 72)
        Me.txt_qtde.MaxLength = 4
        Me.txt_qtde.Name = "txt_qtde"
        Me.txt_qtde.Size = New System.Drawing.Size(62, 23)
        Me.txt_qtde.TabIndex = 16
        Me.txt_qtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_tamanho
        '
        Me.txt_tamanho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_tamanho.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tamanho.Location = New System.Drawing.Point(65, 44)
        Me.txt_tamanho.MaxLength = 2
        Me.txt_tamanho.Name = "txt_tamanho"
        Me.txt_tamanho.Size = New System.Drawing.Size(30, 23)
        Me.txt_tamanho.TabIndex = 14
        Me.txt_tamanho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_nomeProd
        '
        Me.txt_nomeProd.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nomeProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomeProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomeProd.Location = New System.Drawing.Point(161, 15)
        Me.txt_nomeProd.MaxLength = 48
        Me.txt_nomeProd.Name = "txt_nomeProd"
        Me.txt_nomeProd.ReadOnly = True
        Me.txt_nomeProd.Size = New System.Drawing.Size(382, 23)
        Me.txt_nomeProd.TabIndex = 12
        '
        'txt_codProd
        '
        Me.txt_codProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codProd.Location = New System.Drawing.Point(65, 15)
        Me.txt_codProd.MaxLength = 14
        Me.txt_codProd.Name = "txt_codProd"
        Me.txt_codProd.Size = New System.Drawing.Size(90, 23)
        Me.txt_codProd.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Cores:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Qtde:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Tamanho:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Código:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(576, 40)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(93, 22)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-4, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(756, 74)
        Me.Panel1.TabIndex = 9
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(281, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(156, 58)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Frm_CadGrade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 342)
        Me.Controls.Add(Me.tbc_Grade)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_CadGrade"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Grade"
        Me.tbc_Grade.ResumeLayout(False)
        Me.tbp_visuGrade.ResumeLayout(False)
        Me.tbp_visuGrade.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.Dtg_grade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbp_manutencaoGrade.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnl_totalqtde.ResumeLayout(False)
        Me.pnl_totalqtde.PerformLayout()
        Me.pnl_somaqtde.ResumeLayout(False)
        Me.pnl_somaqtde.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbc_Grade As System.Windows.Forms.TabControl
    Friend WithEvents tbp_visuGrade As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_menssage1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Dtg_grade As System.Windows.Forms.DataGridView
    Friend WithEvents tbp_manutencaoGrade As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_menssage2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salvar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbo_cores As System.Windows.Forms.ComboBox
    Friend WithEvents txt_qtde As System.Windows.Forms.TextBox
    Friend WithEvents txt_tamanho As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_qtdeSoma As System.Windows.Forms.Label
    Friend WithEvents lbl_qtdeTotal As System.Windows.Forms.Label
    Friend WithEvents pnl_somaqtde As System.Windows.Forms.Panel
    Friend WithEvents pnl_totalqtde As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents txt_codProd As System.Windows.Forms.TextBox
    Public WithEvents txt_nomeProd As System.Windows.Forms.TextBox
End Class
