<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LancaCX_DivD
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
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.grb_lancamentos = New System.Windows.Forms.GroupBox()
        Me.cbo_protetico = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cbo_tipoPag = New System.Windows.Forms.ComboBox()
        Me.cbo_descricao = New System.Windows.Forms.ComboBox()
        Me.txt_codPart = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_nomePart = New System.Windows.Forms.TextBox()
        Me.lbl_comiss = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbo_doutores = New System.Windows.Forms.ComboBox()
        Me.msk_data = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txt_comiss = New System.Windows.Forms.TextBox()
        Me.txt_valor = New System.Windows.Forms.TextBox()
        Me.txt_grupo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.grb_lancaDespCartao = New System.Windows.Forms.GroupBox()
        Me.cbo_TipoPagCT = New System.Windows.Forms.ComboBox()
        Me.cbo_descricaoCT = New System.Windows.Forms.ComboBox()
        Me.dtp_dataCT = New System.Windows.Forms.DateTimePicker()
        Me.txt_valorCT = New System.Windows.Forms.TextBox()
        Me.txt_totalCT = New System.Windows.Forms.TextBox()
        Me.txt_grupoCT = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbo_tipoCT = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.chk_divisoria = New System.Windows.Forms.CheckBox()
        Me.chk_despCartao = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_valorDupl = New System.Windows.Forms.TextBox()
        Me.txt_numDuplicata = New System.Windows.Forms.TextBox()
        Me.cbo_tpAtendimento = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grb_lancamentos.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grb_lancaDespCartao.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.Info
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Red
        Me.txt_total.Location = New System.Drawing.Point(738, 228)
        Me.txt_total.MaxLength = 14
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(98, 26)
        Me.txt_total.TabIndex = 8
        Me.txt_total.Text = "0,00"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grb_lancamentos
        '
        Me.grb_lancamentos.Controls.Add(Me.cbo_tpAtendimento)
        Me.grb_lancamentos.Controls.Add(Me.Label8)
        Me.grb_lancamentos.Controls.Add(Me.cbo_protetico)
        Me.grb_lancamentos.Controls.Add(Me.Label20)
        Me.grb_lancamentos.Controls.Add(Me.cbo_tipoPag)
        Me.grb_lancamentos.Controls.Add(Me.cbo_descricao)
        Me.grb_lancamentos.Controls.Add(Me.txt_codPart)
        Me.grb_lancamentos.Controls.Add(Me.Label7)
        Me.grb_lancamentos.Controls.Add(Me.txt_nomePart)
        Me.grb_lancamentos.Controls.Add(Me.lbl_comiss)
        Me.grb_lancamentos.Controls.Add(Me.Label6)
        Me.grb_lancamentos.Controls.Add(Me.cbo_doutores)
        Me.grb_lancamentos.Controls.Add(Me.msk_data)
        Me.grb_lancamentos.Controls.Add(Me.PictureBox2)
        Me.grb_lancamentos.Controls.Add(Me.txt_comiss)
        Me.grb_lancamentos.Controls.Add(Me.txt_valor)
        Me.grb_lancamentos.Controls.Add(Me.txt_total)
        Me.grb_lancamentos.Controls.Add(Me.txt_grupo)
        Me.grb_lancamentos.Controls.Add(Me.Label10)
        Me.grb_lancamentos.Controls.Add(Me.Label9)
        Me.grb_lancamentos.Controls.Add(Me.cbo_tipo)
        Me.grb_lancamentos.Controls.Add(Me.Label5)
        Me.grb_lancamentos.Controls.Add(Me.Label4)
        Me.grb_lancamentos.Controls.Add(Me.Label3)
        Me.grb_lancamentos.Controls.Add(Me.Label2)
        Me.grb_lancamentos.Controls.Add(Me.Label1)
        Me.grb_lancamentos.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.grb_lancamentos.Location = New System.Drawing.Point(11, 72)
        Me.grb_lancamentos.Name = "grb_lancamentos"
        Me.grb_lancamentos.Size = New System.Drawing.Size(848, 263)
        Me.grb_lancamentos.TabIndex = 61
        Me.grb_lancamentos.TabStop = False
        Me.grb_lancamentos.Text = "Lançar Divisória: "
        '
        'cbo_protetico
        '
        Me.cbo_protetico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_protetico.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.cbo_protetico.FormattingEnabled = True
        Me.cbo_protetico.Location = New System.Drawing.Point(91, 200)
        Me.cbo_protetico.Name = "cbo_protetico"
        Me.cbo_protetico.Size = New System.Drawing.Size(249, 23)
        Me.cbo_protetico.TabIndex = 60
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(12, 203)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 17)
        Me.Label20.TabIndex = 61
        Me.Label20.Text = "Prot.:"
        '
        'cbo_tipoPag
        '
        Me.cbo_tipoPag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipoPag.Font = New System.Drawing.Font("Times New Roman", 11.0!)
        Me.cbo_tipoPag.FormattingEnabled = True
        Me.cbo_tipoPag.Items.AddRange(New Object() {"DN", "CT", "CH"})
        Me.cbo_tipoPag.Location = New System.Drawing.Point(552, 57)
        Me.cbo_tipoPag.Name = "cbo_tipoPag"
        Me.cbo_tipoPag.Size = New System.Drawing.Size(67, 25)
        Me.cbo_tipoPag.TabIndex = 57
        '
        'cbo_descricao
        '
        Me.cbo_descricao.FormattingEnabled = True
        Me.cbo_descricao.Location = New System.Drawing.Point(15, 116)
        Me.cbo_descricao.Name = "cbo_descricao"
        Me.cbo_descricao.Size = New System.Drawing.Size(430, 27)
        Me.cbo_descricao.TabIndex = 56
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_codPart.Location = New System.Drawing.Point(91, 231)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(70, 23)
        Me.txt_codPart.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(12, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 17)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Cliente:"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomePart.Location = New System.Drawing.Point(167, 231)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(410, 23)
        Me.txt_nomePart.TabIndex = 20
        '
        'lbl_comiss
        '
        Me.lbl_comiss.AutoSize = True
        Me.lbl_comiss.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_comiss.Location = New System.Drawing.Point(384, 172)
        Me.lbl_comiss.Name = "lbl_comiss"
        Me.lbl_comiss.Size = New System.Drawing.Size(61, 17)
        Me.lbl_comiss.TabIndex = 15
        Me.lbl_comiss.Text = "Comis.:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(12, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 17)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Dentista:"
        '
        'cbo_doutores
        '
        Me.cbo_doutores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_doutores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_doutores.FormattingEnabled = True
        Me.cbo_doutores.Location = New System.Drawing.Point(91, 169)
        Me.cbo_doutores.Name = "cbo_doutores"
        Me.cbo_doutores.Size = New System.Drawing.Size(249, 23)
        Me.cbo_doutores.TabIndex = 14
        '
        'msk_data
        '
        Me.msk_data.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.msk_data.Location = New System.Drawing.Point(185, 56)
        Me.msk_data.Name = "msk_data"
        Me.msk_data.Size = New System.Drawing.Size(110, 26)
        Me.msk_data.TabIndex = 11
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Image = Global.RTecSys.My.Resources.Resources.Financ_1
        Me.PictureBox2.Location = New System.Drawing.Point(685, 18)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(151, 150)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'txt_comiss
        '
        Me.txt_comiss.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comiss.Location = New System.Drawing.Point(451, 169)
        Me.txt_comiss.MaxLength = 14
        Me.txt_comiss.Name = "txt_comiss"
        Me.txt_comiss.Size = New System.Drawing.Size(55, 23)
        Me.txt_comiss.TabIndex = 8
        Me.txt_comiss.Text = "0,00"
        Me.txt_comiss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_valor
        '
        Me.txt_valor.BackColor = System.Drawing.SystemColors.Window
        Me.txt_valor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_valor.Location = New System.Drawing.Point(425, 59)
        Me.txt_valor.MaxLength = 14
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.Size = New System.Drawing.Size(81, 23)
        Me.txt_valor.TabIndex = 8
        Me.txt_valor.Text = "0,00"
        Me.txt_valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_grupo
        '
        Me.txt_grupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_grupo.Location = New System.Drawing.Point(332, 59)
        Me.txt_grupo.MaxLength = 3
        Me.txt_grupo.Name = "txt_grupo"
        Me.txt_grupo.Size = New System.Drawing.Size(59, 23)
        Me.txt_grupo.TabIndex = 7
        Me.txt_grupo.Text = "888"
        Me.txt_grupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(549, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 17)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Tp. Pag:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(422, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 17)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Valor R$:"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Location = New System.Drawing.Point(15, 56)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(146, 24)
        Me.cbo_tipo.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(745, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Total R$:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Descrição:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(329, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Grupo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(182, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-5, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(881, 42)
        Me.Panel1.TabIndex = 63
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(338, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
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
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_incluir.Location = New System.Drawing.Point(759, 520)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(88, 44)
        Me.btn_incluir.TabIndex = 60
        Me.btn_incluir.Text = "&Incluir"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_incluir.UseVisualStyleBackColor = False
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(12, 21)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = "    "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 515)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(742, 49)
        Me.GroupBox2.TabIndex = 62
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(7, 324)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(857, 24)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "_____________________________________________________________________________"
        '
        'grb_lancaDespCartao
        '
        Me.grb_lancaDespCartao.Controls.Add(Me.cbo_TipoPagCT)
        Me.grb_lancaDespCartao.Controls.Add(Me.cbo_descricaoCT)
        Me.grb_lancaDespCartao.Controls.Add(Me.dtp_dataCT)
        Me.grb_lancaDespCartao.Controls.Add(Me.txt_valorCT)
        Me.grb_lancaDespCartao.Controls.Add(Me.txt_totalCT)
        Me.grb_lancaDespCartao.Controls.Add(Me.txt_grupoCT)
        Me.grb_lancaDespCartao.Controls.Add(Me.Label12)
        Me.grb_lancaDespCartao.Controls.Add(Me.cbo_tipoCT)
        Me.grb_lancaDespCartao.Controls.Add(Me.Label13)
        Me.grb_lancaDespCartao.Controls.Add(Me.Label14)
        Me.grb_lancaDespCartao.Controls.Add(Me.Label15)
        Me.grb_lancaDespCartao.Controls.Add(Me.Label16)
        Me.grb_lancaDespCartao.Controls.Add(Me.Label17)
        Me.grb_lancaDespCartao.Controls.Add(Me.Label18)
        Me.grb_lancaDespCartao.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.grb_lancaDespCartao.Location = New System.Drawing.Point(11, 350)
        Me.grb_lancaDespCartao.Name = "grb_lancaDespCartao"
        Me.grb_lancaDespCartao.Size = New System.Drawing.Size(848, 159)
        Me.grb_lancaDespCartao.TabIndex = 65
        Me.grb_lancaDespCartao.TabStop = False
        Me.grb_lancaDespCartao.Text = "Lançar Desp. Cartão: "
        '
        'cbo_TipoPagCT
        '
        Me.cbo_TipoPagCT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_TipoPagCT.FormattingEnabled = True
        Me.cbo_TipoPagCT.Items.AddRange(New Object() {"CT", "CH", "DN"})
        Me.cbo_TipoPagCT.Location = New System.Drawing.Point(555, 56)
        Me.cbo_TipoPagCT.Name = "cbo_TipoPagCT"
        Me.cbo_TipoPagCT.Size = New System.Drawing.Size(72, 27)
        Me.cbo_TipoPagCT.TabIndex = 57
        '
        'cbo_descricaoCT
        '
        Me.cbo_descricaoCT.FormattingEnabled = True
        Me.cbo_descricaoCT.Location = New System.Drawing.Point(15, 121)
        Me.cbo_descricaoCT.Name = "cbo_descricaoCT"
        Me.cbo_descricaoCT.Size = New System.Drawing.Size(491, 27)
        Me.cbo_descricaoCT.TabIndex = 56
        '
        'dtp_dataCT
        '
        Me.dtp_dataCT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dataCT.Location = New System.Drawing.Point(185, 58)
        Me.dtp_dataCT.Name = "dtp_dataCT"
        Me.dtp_dataCT.Size = New System.Drawing.Size(110, 26)
        Me.dtp_dataCT.TabIndex = 11
        '
        'txt_valorCT
        '
        Me.txt_valorCT.BackColor = System.Drawing.SystemColors.Window
        Me.txt_valorCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valorCT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_valorCT.Location = New System.Drawing.Point(425, 61)
        Me.txt_valorCT.MaxLength = 14
        Me.txt_valorCT.Name = "txt_valorCT"
        Me.txt_valorCT.Size = New System.Drawing.Size(81, 23)
        Me.txt_valorCT.TabIndex = 8
        Me.txt_valorCT.Text = "0,00"
        Me.txt_valorCT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_totalCT
        '
        Me.txt_totalCT.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totalCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totalCT.ForeColor = System.Drawing.Color.Red
        Me.txt_totalCT.Location = New System.Drawing.Point(690, 116)
        Me.txt_totalCT.MaxLength = 14
        Me.txt_totalCT.Name = "txt_totalCT"
        Me.txt_totalCT.ReadOnly = True
        Me.txt_totalCT.Size = New System.Drawing.Size(146, 30)
        Me.txt_totalCT.TabIndex = 22
        Me.txt_totalCT.Text = "0,00"
        Me.txt_totalCT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_grupoCT
        '
        Me.txt_grupoCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_grupoCT.Location = New System.Drawing.Point(324, 61)
        Me.txt_grupoCT.MaxLength = 3
        Me.txt_grupoCT.Name = "txt_grupoCT"
        Me.txt_grupoCT.Size = New System.Drawing.Size(59, 23)
        Me.txt_grupoCT.TabIndex = 7
        Me.txt_grupoCT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(422, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 17)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Valor R$:"
        '
        'cbo_tipoCT
        '
        Me.cbo_tipoCT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipoCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_tipoCT.FormattingEnabled = True
        Me.cbo_tipoCT.Items.AddRange(New Object() {"Pagamento"})
        Me.cbo_tipoCT.Location = New System.Drawing.Point(15, 58)
        Me.cbo_tipoCT.Name = "cbo_tipoCT"
        Me.cbo_tipoCT.Size = New System.Drawing.Size(146, 24)
        Me.cbo_tipoCT.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(727, 95)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 17)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Total R$:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 100)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 17)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Descrição:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(321, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 17)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Grupo:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(182, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 17)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Data:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(552, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 17)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Tp. Pag:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(12, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 17)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Tipo:"
        '
        'chk_divisoria
        '
        Me.chk_divisoria.AutoSize = True
        Me.chk_divisoria.Checked = True
        Me.chk_divisoria.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_divisoria.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_divisoria.ForeColor = System.Drawing.Color.DarkBlue
        Me.chk_divisoria.Location = New System.Drawing.Point(26, 49)
        Me.chk_divisoria.Name = "chk_divisoria"
        Me.chk_divisoria.Size = New System.Drawing.Size(106, 24)
        Me.chk_divisoria.TabIndex = 66
        Me.chk_divisoria.Text = "Divisória?"
        Me.chk_divisoria.UseVisualStyleBackColor = True
        '
        'chk_despCartao
        '
        Me.chk_despCartao.AutoSize = True
        Me.chk_despCartao.Checked = True
        Me.chk_despCartao.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_despCartao.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_despCartao.ForeColor = System.Drawing.Color.DarkBlue
        Me.chk_despCartao.Location = New System.Drawing.Point(160, 49)
        Me.chk_despCartao.Name = "chk_despCartao"
        Me.chk_despCartao.Size = New System.Drawing.Size(139, 24)
        Me.chk_despCartao.TabIndex = 66
        Me.chk_despCartao.Text = "Desp. Cartão?"
        Me.chk_despCartao.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(658, 52)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(86, 17)
        Me.Label19.TabIndex = 67
        Me.Label19.Text = "Valor Dupl.:"
        '
        'txt_valorDupl
        '
        Me.txt_valorDupl.BackColor = System.Drawing.SystemColors.Info
        Me.txt_valorDupl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_valorDupl.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valorDupl.ForeColor = System.Drawing.Color.DarkBlue
        Me.txt_valorDupl.Location = New System.Drawing.Point(750, 46)
        Me.txt_valorDupl.MaxLength = 20
        Me.txt_valorDupl.Name = "txt_valorDupl"
        Me.txt_valorDupl.ReadOnly = True
        Me.txt_valorDupl.Size = New System.Drawing.Size(109, 29)
        Me.txt_valorDupl.TabIndex = 68
        Me.txt_valorDupl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_numDuplicata
        '
        Me.txt_numDuplicata.BackColor = System.Drawing.SystemColors.Control
        Me.txt_numDuplicata.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_numDuplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_numDuplicata.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numDuplicata.ForeColor = System.Drawing.Color.DarkBlue
        Me.txt_numDuplicata.Location = New System.Drawing.Point(539, 53)
        Me.txt_numDuplicata.MaxLength = 12
        Me.txt_numDuplicata.Name = "txt_numDuplicata"
        Me.txt_numDuplicata.ReadOnly = True
        Me.txt_numDuplicata.Size = New System.Drawing.Size(91, 15)
        Me.txt_numDuplicata.TabIndex = 69
        Me.txt_numDuplicata.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbo_tpAtendimento
        '
        Me.cbo_tpAtendimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tpAtendimento.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.cbo_tpAtendimento.FormattingEnabled = True
        Me.cbo_tpAtendimento.Location = New System.Drawing.Point(474, 117)
        Me.cbo_tpAtendimento.Name = "cbo_tpAtendimento"
        Me.cbo_tpAtendimento.Size = New System.Drawing.Size(179, 23)
        Me.cbo_tpAtendimento.TabIndex = 62
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(471, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 17)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Atendimento:"
        '
        'Frm_LancaCX_DivD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 576)
        Me.Controls.Add(Me.txt_numDuplicata)
        Me.Controls.Add(Me.txt_valorDupl)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.chk_despCartao)
        Me.Controls.Add(Me.chk_divisoria)
        Me.Controls.Add(Me.grb_lancaDespCartao)
        Me.Controls.Add(Me.grb_lancamentos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btn_incluir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label11)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_LancaCX_DivD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lança Divisória e Despesa de Cartão"
        Me.grb_lancamentos.ResumeLayout(False)
        Me.grb_lancamentos.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grb_lancaDespCartao.ResumeLayout(False)
        Me.grb_lancaDespCartao.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents grb_lancamentos As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_tipoPag As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_descricao As System.Windows.Forms.ComboBox
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents lbl_comiss As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbo_doutores As System.Windows.Forms.ComboBox
    Friend WithEvents msk_data As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_comiss As System.Windows.Forms.TextBox
    Friend WithEvents txt_valor As System.Windows.Forms.TextBox
    Friend WithEvents txt_grupo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grb_lancaDespCartao As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_TipoPagCT As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_descricaoCT As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_dataCT As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_valorCT As System.Windows.Forms.TextBox
    Friend WithEvents txt_totalCT As System.Windows.Forms.TextBox
    Friend WithEvents txt_grupoCT As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbo_tipoCT As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents chk_divisoria As System.Windows.Forms.CheckBox
    Friend WithEvents chk_despCartao As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents txt_valorDupl As System.Windows.Forms.TextBox
    Friend WithEvents txt_numDuplicata As System.Windows.Forms.TextBox
    Friend WithEvents cbo_protetico As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cbo_tpAtendimento As System.Windows.Forms.ComboBox
    Public WithEvents Label8 As System.Windows.Forms.Label
End Class
