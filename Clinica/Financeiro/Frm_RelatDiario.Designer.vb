<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RelatDiario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RelatDiario))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.grb_opcoes = New System.Windows.Forms.GroupBox()
        Me.btn_pesquisa = New System.Windows.Forms.Button()
        Me.btn_Relatorio = New System.Windows.Forms.Button()
        Me.dtp_dia = New System.Windows.Forms.DateTimePicker()
        Me.cbo_dentistas = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grb_info = New System.Windows.Forms.GroupBox()
        Me.txt_diaSemana = New System.Windows.Forms.TextBox()
        Me.txt_nomeEmpresa = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grb_totais = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_totalGeral = New System.Windows.Forms.TextBox()
        Me.txt_totCheque = New System.Windows.Forms.TextBox()
        Me.txt_totCartao = New System.Windows.Forms.TextBox()
        Me.txt_totDivProt = New System.Windows.Forms.TextBox()
        Me.txt_totDivDentista = New System.Windows.Forms.TextBox()
        Me.txt_totOrca = New System.Windows.Forms.TextBox()
        Me.txt_totDinheiro = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtg_caixaDiario = New System.Windows.Forms.DataGridView()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.pdRelatorio = New System.Drawing.Printing.PrintDocument()
        Me.nomecli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.orcamento = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Dentistas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chegada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Protetico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlOrcamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlFicha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoLancamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.grb_opcoes.SuspendLayout()
        Me.grb_info.SuspendLayout()
        Me.grb_totais.SuspendLayout()
        CType(Me.dtg_caixaDiario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-9, -1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(834, 48)
        Me.Panel1.TabIndex = 29
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(337, 4)
        Me.lbl_NomeSys.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'grb_opcoes
        '
        Me.grb_opcoes.Controls.Add(Me.btn_pesquisa)
        Me.grb_opcoes.Controls.Add(Me.btn_Relatorio)
        Me.grb_opcoes.Controls.Add(Me.dtp_dia)
        Me.grb_opcoes.Controls.Add(Me.cbo_dentistas)
        Me.grb_opcoes.Controls.Add(Me.Label2)
        Me.grb_opcoes.Controls.Add(Me.Label1)
        Me.grb_opcoes.Location = New System.Drawing.Point(12, 54)
        Me.grb_opcoes.Name = "grb_opcoes"
        Me.grb_opcoes.Size = New System.Drawing.Size(795, 61)
        Me.grb_opcoes.TabIndex = 30
        Me.grb_opcoes.TabStop = False
        Me.grb_opcoes.Text = "Opções: "
        '
        'btn_pesquisa
        '
        Me.btn_pesquisa.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_pesquisa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_pesquisa.Image = Global.RTecSys.My.Resources.Resources.Busca_16x161
        Me.btn_pesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_pesquisa.Location = New System.Drawing.Point(570, 16)
        Me.btn_pesquisa.Name = "btn_pesquisa"
        Me.btn_pesquisa.Size = New System.Drawing.Size(62, 39)
        Me.btn_pesquisa.TabIndex = 20
        Me.btn_pesquisa.Text = "[F5]"
        Me.btn_pesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pesquisa.UseVisualStyleBackColor = True
        '
        'btn_Relatorio
        '
        Me.btn_Relatorio.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_Relatorio.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_Relatorio.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_Relatorio.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_Relatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Relatorio.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btn_Relatorio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_Relatorio.Image = CType(resources.GetObject("btn_Relatorio.Image"), System.Drawing.Image)
        Me.btn_Relatorio.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btn_Relatorio.Location = New System.Drawing.Point(662, 15)
        Me.btn_Relatorio.Name = "btn_Relatorio"
        Me.btn_Relatorio.Size = New System.Drawing.Size(123, 40)
        Me.btn_Relatorio.TabIndex = 19
        Me.btn_Relatorio.Text = "&Impr. [F6]"
        Me.btn_Relatorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Relatorio.UseVisualStyleBackColor = False
        '
        'dtp_dia
        '
        Me.dtp_dia.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dia.Location = New System.Drawing.Point(436, 22)
        Me.dtp_dia.Name = "dtp_dia"
        Me.dtp_dia.Size = New System.Drawing.Size(122, 29)
        Me.dtp_dia.TabIndex = 2
        '
        'cbo_dentistas
        '
        Me.cbo_dentistas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_dentistas.FormattingEnabled = True
        Me.cbo_dentistas.Location = New System.Drawing.Point(92, 22)
        Me.cbo_dentistas.Name = "cbo_dentistas"
        Me.cbo_dentistas.Size = New System.Drawing.Size(262, 27)
        Me.cbo_dentistas.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(392, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Dia:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dentista:"
        '
        'grb_info
        '
        Me.grb_info.Controls.Add(Me.txt_diaSemana)
        Me.grb_info.Controls.Add(Me.txt_nomeEmpresa)
        Me.grb_info.Controls.Add(Me.Label4)
        Me.grb_info.Controls.Add(Me.Label3)
        Me.grb_info.Location = New System.Drawing.Point(12, 117)
        Me.grb_info.Name = "grb_info"
        Me.grb_info.Size = New System.Drawing.Size(795, 55)
        Me.grb_info.TabIndex = 31
        Me.grb_info.TabStop = False
        Me.grb_info.Text = "Info.: "
        '
        'txt_diaSemana
        '
        Me.txt_diaSemana.BackColor = System.Drawing.SystemColors.Info
        Me.txt_diaSemana.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_diaSemana.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_diaSemana.Location = New System.Drawing.Point(612, 21)
        Me.txt_diaSemana.MaxLength = 100
        Me.txt_diaSemana.Name = "txt_diaSemana"
        Me.txt_diaSemana.ReadOnly = True
        Me.txt_diaSemana.Size = New System.Drawing.Size(157, 26)
        Me.txt_diaSemana.TabIndex = 0
        Me.txt_diaSemana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_nomeEmpresa
        '
        Me.txt_nomeEmpresa.BackColor = System.Drawing.SystemColors.Window
        Me.txt_nomeEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomeEmpresa.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomeEmpresa.Location = New System.Drawing.Point(92, 21)
        Me.txt_nomeEmpresa.MaxLength = 100
        Me.txt_nomeEmpresa.Name = "txt_nomeEmpresa"
        Me.txt_nomeEmpresa.Size = New System.Drawing.Size(376, 26)
        Me.txt_nomeEmpresa.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(511, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 19)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Dia Semana:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Clínica:"
        '
        'grb_totais
        '
        Me.grb_totais.Controls.Add(Me.Label8)
        Me.grb_totais.Controls.Add(Me.Label6)
        Me.grb_totais.Controls.Add(Me.Label7)
        Me.grb_totais.Controls.Add(Me.Label11)
        Me.grb_totais.Controls.Add(Me.Label10)
        Me.grb_totais.Controls.Add(Me.Label9)
        Me.grb_totais.Controls.Add(Me.Label5)
        Me.grb_totais.Controls.Add(Me.txt_totalGeral)
        Me.grb_totais.Controls.Add(Me.txt_totCheque)
        Me.grb_totais.Controls.Add(Me.txt_totCartao)
        Me.grb_totais.Controls.Add(Me.txt_totDivProt)
        Me.grb_totais.Controls.Add(Me.txt_totDivDentista)
        Me.grb_totais.Controls.Add(Me.txt_totOrca)
        Me.grb_totais.Controls.Add(Me.txt_totDinheiro)
        Me.grb_totais.Location = New System.Drawing.Point(12, 175)
        Me.grb_totais.Name = "grb_totais"
        Me.grb_totais.Size = New System.Drawing.Size(795, 89)
        Me.grb_totais.TabIndex = 32
        Me.grb_totais.TabStop = False
        Me.grb_totais.Text = "Totais:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(580, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 19)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Tot. Geral:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(245, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 19)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cartão:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(419, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 19)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Cheque:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(214, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 19)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Div. Prot(a):"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 19)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Div. Dr(a):"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(594, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 19)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Orçamento:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Dinheiro:"
        '
        'txt_totalGeral
        '
        Me.txt_totalGeral.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totalGeral.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_totalGeral.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totalGeral.ForeColor = System.Drawing.Color.Red
        Me.txt_totalGeral.Location = New System.Drawing.Point(668, 54)
        Me.txt_totalGeral.MaxLength = 100
        Me.txt_totalGeral.Name = "txt_totalGeral"
        Me.txt_totalGeral.ReadOnly = True
        Me.txt_totalGeral.Size = New System.Drawing.Size(101, 29)
        Me.txt_totalGeral.TabIndex = 0
        Me.txt_totalGeral.Text = "0,00"
        Me.txt_totalGeral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_totCheque
        '
        Me.txt_totCheque.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_totCheque.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totCheque.ForeColor = System.Drawing.Color.DarkBlue
        Me.txt_totCheque.Location = New System.Drawing.Point(490, 22)
        Me.txt_totCheque.MaxLength = 100
        Me.txt_totCheque.Name = "txt_totCheque"
        Me.txt_totCheque.ReadOnly = True
        Me.txt_totCheque.Size = New System.Drawing.Size(77, 26)
        Me.txt_totCheque.TabIndex = 0
        Me.txt_totCheque.Text = "0,00"
        Me.txt_totCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_totCartao
        '
        Me.txt_totCartao.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totCartao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_totCartao.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totCartao.ForeColor = System.Drawing.Color.DarkBlue
        Me.txt_totCartao.Location = New System.Drawing.Point(311, 22)
        Me.txt_totCartao.MaxLength = 100
        Me.txt_totCartao.Name = "txt_totCartao"
        Me.txt_totCartao.ReadOnly = True
        Me.txt_totCartao.Size = New System.Drawing.Size(77, 26)
        Me.txt_totCartao.TabIndex = 0
        Me.txt_totCartao.Text = "0,00"
        Me.txt_totCartao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_totDivProt
        '
        Me.txt_totDivProt.BackColor = System.Drawing.SystemColors.Window
        Me.txt_totDivProt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_totDivProt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totDivProt.ForeColor = System.Drawing.Color.DarkBlue
        Me.txt_totDivProt.Location = New System.Drawing.Point(311, 56)
        Me.txt_totDivProt.MaxLength = 14
        Me.txt_totDivProt.Name = "txt_totDivProt"
        Me.txt_totDivProt.Size = New System.Drawing.Size(77, 26)
        Me.txt_totDivProt.TabIndex = 0
        Me.txt_totDivProt.Text = "0,00"
        Me.txt_totDivProt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_totDivDentista
        '
        Me.txt_totDivDentista.BackColor = System.Drawing.SystemColors.Window
        Me.txt_totDivDentista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_totDivDentista.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totDivDentista.ForeColor = System.Drawing.Color.DarkBlue
        Me.txt_totDivDentista.Location = New System.Drawing.Point(102, 56)
        Me.txt_totDivDentista.MaxLength = 14
        Me.txt_totDivDentista.Name = "txt_totDivDentista"
        Me.txt_totDivDentista.Size = New System.Drawing.Size(77, 26)
        Me.txt_totDivDentista.TabIndex = 0
        Me.txt_totDivDentista.Text = "0,00"
        Me.txt_totDivDentista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_totOrca
        '
        Me.txt_totOrca.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totOrca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_totOrca.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totOrca.ForeColor = System.Drawing.Color.DarkBlue
        Me.txt_totOrca.Location = New System.Drawing.Point(692, 22)
        Me.txt_totOrca.MaxLength = 100
        Me.txt_totOrca.Name = "txt_totOrca"
        Me.txt_totOrca.ReadOnly = True
        Me.txt_totOrca.Size = New System.Drawing.Size(77, 26)
        Me.txt_totOrca.TabIndex = 0
        Me.txt_totOrca.Text = "0,00"
        Me.txt_totOrca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_totDinheiro
        '
        Me.txt_totDinheiro.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totDinheiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_totDinheiro.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totDinheiro.ForeColor = System.Drawing.Color.DarkBlue
        Me.txt_totDinheiro.Location = New System.Drawing.Point(102, 22)
        Me.txt_totDinheiro.MaxLength = 100
        Me.txt_totDinheiro.Name = "txt_totDinheiro"
        Me.txt_totDinheiro.ReadOnly = True
        Me.txt_totDinheiro.Size = New System.Drawing.Size(77, 26)
        Me.txt_totDinheiro.TabIndex = 0
        Me.txt_totDinheiro.Text = "0,00"
        Me.txt_totDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(13, 257)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(793, 19)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "_________________________________________________________________________________" & _
    "_________________"
        '
        'dtg_caixaDiario
        '
        Me.dtg_caixaDiario.AllowUserToAddRows = False
        Me.dtg_caixaDiario.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_caixaDiario.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_caixaDiario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_caixaDiario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dtg_caixaDiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_caixaDiario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nomecli, Me.ficha, Me.orcamento, Me.Dentistas, Me.chegada, Me.Protetico, Me.vlOrcamento, Me.vlFicha, Me.tipo, Me.tipoLancamento})
        Me.dtg_caixaDiario.Location = New System.Drawing.Point(9, 287)
        Me.dtg_caixaDiario.Name = "dtg_caixaDiario"
        Me.dtg_caixaDiario.ReadOnly = True
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_caixaDiario.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_caixaDiario.Size = New System.Drawing.Size(802, 222)
        Me.dtg_caixaDiario.TabIndex = 33
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
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'pdRelatorio
        '
        '
        'nomecli
        '
        Me.nomecli.HeaderText = "Cliente"
        Me.nomecli.Name = "nomecli"
        Me.nomecli.ReadOnly = True
        Me.nomecli.Width = 243
        '
        'ficha
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ficha.DefaultCellStyle = DataGridViewCellStyle2
        Me.ficha.HeaderText = "Nº Ficha"
        Me.ficha.Name = "ficha"
        Me.ficha.ReadOnly = True
        '
        'orcamento
        '
        Me.orcamento.HeaderText = "Orç."
        Me.orcamento.Name = "orcamento"
        Me.orcamento.ReadOnly = True
        Me.orcamento.Width = 40
        '
        'Dentistas
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Dentistas.DefaultCellStyle = DataGridViewCellStyle3
        Me.Dentistas.HeaderText = "Dr.(a)"
        Me.Dentistas.Name = "Dentistas"
        Me.Dentistas.ReadOnly = True
        Me.Dentistas.Width = 60
        '
        'chegada
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.chegada.DefaultCellStyle = DataGridViewCellStyle4
        Me.chegada.HeaderText = "Cheg."
        Me.chegada.Name = "chegada"
        Me.chegada.ReadOnly = True
        Me.chegada.Width = 60
        '
        'Protetico
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Protetico.DefaultCellStyle = DataGridViewCellStyle5
        Me.Protetico.HeaderText = "Prot.(a)"
        Me.Protetico.Name = "Protetico"
        Me.Protetico.ReadOnly = True
        Me.Protetico.Width = 60
        '
        'vlOrcamento
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.vlOrcamento.DefaultCellStyle = DataGridViewCellStyle6
        Me.vlOrcamento.HeaderText = "R$ Orç."
        Me.vlOrcamento.Name = "vlOrcamento"
        Me.vlOrcamento.ReadOnly = True
        Me.vlOrcamento.Width = 90
        '
        'vlFicha
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.vlFicha.DefaultCellStyle = DataGridViewCellStyle7
        Me.vlFicha.HeaderText = "R$ Ficha"
        Me.vlFicha.Name = "vlFicha"
        Me.vlFicha.ReadOnly = True
        Me.vlFicha.Width = 90
        '
        'tipo
        '
        Me.tipo.HeaderText = "TipoPag"
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.Visible = False
        '
        'tipoLancamento
        '
        Me.tipoLancamento.HeaderText = "Tipo do Lancamento"
        Me.tipoLancamento.Name = "tipoLancamento"
        Me.tipoLancamento.ReadOnly = True
        Me.tipoLancamento.Visible = False
        '
        'Frm_RelatDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 521)
        Me.Controls.Add(Me.dtg_caixaDiario)
        Me.Controls.Add(Me.grb_totais)
        Me.Controls.Add(Me.grb_info)
        Me.Controls.Add(Me.grb_opcoes)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Frm_RelatDiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatório Diário"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grb_opcoes.ResumeLayout(False)
        Me.grb_opcoes.PerformLayout()
        Me.grb_info.ResumeLayout(False)
        Me.grb_info.PerformLayout()
        Me.grb_totais.ResumeLayout(False)
        Me.grb_totais.PerformLayout()
        CType(Me.dtg_caixaDiario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents grb_opcoes As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_dia As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_dentistas As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Relatorio As System.Windows.Forms.Button
    Friend WithEvents grb_info As System.Windows.Forms.GroupBox
    Friend WithEvents txt_diaSemana As System.Windows.Forms.TextBox
    Friend WithEvents txt_nomeEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grb_totais As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_totalGeral As System.Windows.Forms.TextBox
    Friend WithEvents txt_totCheque As System.Windows.Forms.TextBox
    Friend WithEvents txt_totCartao As System.Windows.Forms.TextBox
    Friend WithEvents txt_totDivProt As System.Windows.Forms.TextBox
    Friend WithEvents txt_totDivDentista As System.Windows.Forms.TextBox
    Friend WithEvents txt_totOrca As System.Windows.Forms.TextBox
    Friend WithEvents txt_totDinheiro As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtg_caixaDiario As System.Windows.Forms.DataGridView
    Friend WithEvents btn_pesquisa As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents pdRelatorio As System.Drawing.Printing.PrintDocument
    Friend WithEvents nomecli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents orcamento As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Dentistas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chegada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Protetico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlOrcamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlFicha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipoLancamento As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
