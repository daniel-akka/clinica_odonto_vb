<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ServicosComunicacao
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btn_sai = New System.Windows.Forms.Button
        Me.btn_exclui = New System.Windows.Forms.Button
        Me.dtg_servicos = New System.Windows.Forms.DataGridView
        Me.btn_altera = New System.Windows.Forms.Button
        Me.btn_inclui = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_creditopis = New System.Windows.Forms.TextBox
        Me.cbo_cstpis = New System.Windows.Forms.ComboBox
        Me.cbo_natureza = New System.Windows.Forms.ComboBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TextBox20 = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.TextBox19 = New System.Windows.Forms.TextBox
        Me.txt_municipio = New System.Windows.Forms.TextBox
        Me.cbo_municipio = New System.Windows.Forms.ComboBox
        Me.cbo_Ufcoleta = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Grp_servicos = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_cancela = New System.Windows.Forms.Button
        Me.btn_incluir = New System.Windows.Forms.Button
        Me.msk_dtentrada = New System.Windows.Forms.MaskedTextBox
        Me.msk_emissao = New System.Windows.Forms.MaskedTextBox
        Me.txt_outras = New System.Windows.Forms.TextBox
        Me.txt_isento = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txt_icmscred = New System.Windows.Forms.TextBox
        Me.txt_aliq = New System.Windows.Forms.TextBox
        Me.txt_bcalc = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cbo_cst = New System.Windows.Forms.ComboBox
        Me.cbo_cfop = New System.Windows.Forms.ComboBox
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.txt_abatimento = New System.Windows.Forms.TextBox
        Me.txt_outdesp = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_vlservico = New System.Windows.Forms.TextBox
        Me.txt_classe = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.msk_vencto = New System.Windows.Forms.MaskedTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.msk_mesano = New System.Windows.Forms.MaskedTextBox
        Me.msk_fone = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_pcod = New System.Windows.Forms.TextBox
        Me.txt_portador = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.txt_subserie = New System.Windows.Forms.TextBox
        Me.txt_serie = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtg_servicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Grp_servicos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 242)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(680, 293)
        Me.TabControl1.TabIndex = 23
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btn_sai)
        Me.TabPage1.Controls.Add(Me.btn_exclui)
        Me.TabPage1.Controls.Add(Me.dtg_servicos)
        Me.TabPage1.Controls.Add(Me.btn_altera)
        Me.TabPage1.Controls.Add(Me.btn_inclui)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(672, 267)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Serviços"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btn_sai
        '
        Me.btn_sai.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_sai.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_sai.Location = New System.Drawing.Point(199, 218)
        Me.btn_sai.Name = "btn_sai"
        Me.btn_sai.Size = New System.Drawing.Size(60, 43)
        Me.btn_sai.TabIndex = 27
        Me.btn_sai.Text = "&Sai"
        Me.btn_sai.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_sai.UseVisualStyleBackColor = True
        '
        'btn_exclui
        '
        Me.btn_exclui.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_exclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exclui.Location = New System.Drawing.Point(133, 218)
        Me.btn_exclui.Name = "btn_exclui"
        Me.btn_exclui.Size = New System.Drawing.Size(60, 43)
        Me.btn_exclui.TabIndex = 26
        Me.btn_exclui.Text = "&Exclui"
        Me.btn_exclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exclui.UseVisualStyleBackColor = True
        '
        'dtg_servicos
        '
        Me.dtg_servicos.AllowUserToAddRows = False
        Me.dtg_servicos.AllowUserToDeleteRows = False
        Me.dtg_servicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_servicos.Location = New System.Drawing.Point(-5, 0)
        Me.dtg_servicos.Name = "dtg_servicos"
        Me.dtg_servicos.ReadOnly = True
        Me.dtg_servicos.Size = New System.Drawing.Size(681, 212)
        Me.dtg_servicos.TabIndex = 2
        '
        'btn_altera
        '
        Me.btn_altera.Image = Global.MetroSys.My.Resources.Resources.Load
        Me.btn_altera.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_altera.Location = New System.Drawing.Point(70, 218)
        Me.btn_altera.Name = "btn_altera"
        Me.btn_altera.Size = New System.Drawing.Size(60, 43)
        Me.btn_altera.TabIndex = 25
        Me.btn_altera.Text = "&Altera"
        Me.btn_altera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_altera.UseVisualStyleBackColor = True
        '
        'btn_inclui
        '
        Me.btn_inclui.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_inclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_inclui.Location = New System.Drawing.Point(5, 218)
        Me.btn_inclui.Name = "btn_inclui"
        Me.btn_inclui.Size = New System.Drawing.Size(60, 43)
        Me.btn_inclui.TabIndex = 24
        Me.btn_inclui.Text = "&Inclui"
        Me.btn_inclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_inclui.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.txt_creditopis)
        Me.TabPage2.Controls.Add(Me.cbo_cstpis)
        Me.TabPage2.Controls.Add(Me.cbo_natureza)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(672, 267)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Trib.Federais"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(458, 34)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 7
        Me.Label25.Text = "(Pis/Cofins):"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(58, 35)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 13)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "Crédito"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(463, 17)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 13)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Crédito"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(232, 34)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 13)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "CST(PIS/COFINS):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(48, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Natureza do"
        '
        'txt_creditopis
        '
        Me.txt_creditopis.Location = New System.Drawing.Point(433, 53)
        Me.txt_creditopis.MaxLength = 14
        Me.txt_creditopis.Name = "txt_creditopis"
        Me.txt_creditopis.Size = New System.Drawing.Size(106, 20)
        Me.txt_creditopis.TabIndex = 30
        '
        'cbo_cstpis
        '
        Me.cbo_cstpis.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_cstpis.FormattingEnabled = True
        Me.cbo_cstpis.IntegralHeight = False
        Me.cbo_cstpis.Items.AddRange(New Object() {"50 - Op. c/ Dir. a Cred. - Vinc. Exclus. a Receita Tributada no Mercado Interno  " & _
                        "                        ", "51 - Op. c/ Dir. a Cred. - Vinc. Exclus. a Receita Nao Tributada no Mercado Inter" & _
                        "no                      ", "52 - Op. c/ Dir. a Cred. - Vinc. Exclus. a Receita de Exportacao                 " & _
                        "                        ", "53 - Op. c/ Dir. a Cred. - Vinc. a Receitas Tributadas e Nao Tributadas no Mercad" & _
                        "o Interno               ", "54 - Op. c/ Dir. a Cred. - Vinc. a Receitas Tributadas no Mercado Interno e de Ex" & _
                        "portacao                ", "55 - Op. c/ Dir. a Cred. - Vinc. a Receitas Nao-Tributadas no Mercado Interno e d" & _
                        "e Exportacao            ", "56 - Op. c/ Dir. a Cred. - Vinc. a Receitas Trib. e N/Trib.no Mercado Interno, e " & _
                        "de exportacao           ", "60 - Cred. Presum. - Op. de Aquis. Vinc. Exclus. a Receita Tributada no Mercado I" & _
                        "nterno                  ", "61 - Cred. Presum. - Op. de Aquis. Vinc. Exclus. a Receita Nao-Tributada no Merca" & _
                        "do Interno              ", "62 - Cred. Presum. - Op. de Aquis. Vinc. Exclus. a Receita de Exportacao         " & _
                        "                        ", "63 - Cred. Presum. - Op. de Aquis. Vinc. a Receitas Tributadas e Nao-Tributadas n" & _
                        "o Mercado Interno       ", "64 - Cred. Presum. - Op. de Aquis. Vinc. a Receitas Tributadas no Mercado Interno" & _
                        " e de Exportacao        ", "65 - Cred. Presum. - Op. de Aquis. Vinc. a Receitas Nao-Tributadas no Mercado Int" & _
                        "erno e de Exportacao    ", "66 - Cred. Presum. - Op. de Aquis. Vinc. a Receitas Tributadas e Nao-Tributadas n" & _
                        "o Mercado Interno e     ", "67 - Cred. Presum. - Outras Operacoes                                            " & _
                        "                        ", "70 - Op. de Aquis. sem Direito a Credito                                         " & _
                        "                        ", "71 - Op. de Aquis. com Isencao                                                   " & _
                        "                        ", "72 - Op. de Aquis. com Suspensao                                                 " & _
                        "                        ", "73 - Op. de Aquis. a Aliquota Zero                                               " & _
                        "                        ", "74 - Op. de Aquis. sem Incidencia da Contribuicao                                " & _
                        "                        ", "75 - Op. de Aquis. por Substituicao Tributária                                   " & _
                        "                        ", "98 - Outras Operacoes de Entrada                                                 " & _
                        "                        ", "99 - Outras Operacoes  "})
        Me.cbo_cstpis.Location = New System.Drawing.Point(158, 53)
        Me.cbo_cstpis.Name = "cbo_cstpis"
        Me.cbo_cstpis.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbo_cstpis.Size = New System.Drawing.Size(269, 20)
        Me.cbo_cstpis.TabIndex = 29
        '
        'cbo_natureza
        '
        Me.cbo_natureza.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_natureza.FormattingEnabled = True
        Me.cbo_natureza.Items.AddRange(New Object() {"03 - Aquisição de Serviços Utilizados como insumo", "13 - Outras operações com direito a crédito"})
        Me.cbo_natureza.Location = New System.Drawing.Point(15, 53)
        Me.cbo_natureza.MaxLength = 2
        Me.cbo_natureza.Name = "cbo_natureza"
        Me.cbo_natureza.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbo_natureza.Size = New System.Drawing.Size(137, 20)
        Me.cbo_natureza.TabIndex = 28
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TextBox20)
        Me.TabPage3.Controls.Add(Me.Label29)
        Me.TabPage3.Controls.Add(Me.Label28)
        Me.TabPage3.Controls.Add(Me.TextBox19)
        Me.TabPage3.Controls.Add(Me.txt_municipio)
        Me.TabPage3.Controls.Add(Me.cbo_municipio)
        Me.TabPage3.Controls.Add(Me.cbo_Ufcoleta)
        Me.TabPage3.Controls.Add(Me.Label27)
        Me.TabPage3.Controls.Add(Me.Label26)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(672, 267)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Outros"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TextBox20
        '
        Me.TextBox20.Location = New System.Drawing.Point(12, 205)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(522, 20)
        Me.TextBox20.TabIndex = 19
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(9, 187)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(133, 13)
        Me.Label29.TabIndex = 17
        Me.Label29.Text = "Informação Complementar:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(8, 65)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(73, 13)
        Me.Label28.TabIndex = 16
        Me.Label28.Text = "Observações:"
        '
        'TextBox19
        '
        Me.TextBox19.Location = New System.Drawing.Point(11, 81)
        Me.TextBox19.MaxLength = 512
        Me.TextBox19.Multiline = True
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox19.Size = New System.Drawing.Size(523, 95)
        Me.TextBox19.TabIndex = 15
        '
        'txt_municipio
        '
        Me.txt_municipio.Location = New System.Drawing.Point(148, 37)
        Me.txt_municipio.MaxLength = 30
        Me.txt_municipio.Name = "txt_municipio"
        Me.txt_municipio.ReadOnly = True
        Me.txt_municipio.Size = New System.Drawing.Size(174, 20)
        Me.txt_municipio.TabIndex = 14
        '
        'cbo_municipio
        '
        Me.cbo_municipio.FormattingEnabled = True
        Me.cbo_municipio.Location = New System.Drawing.Point(76, 37)
        Me.cbo_municipio.Name = "cbo_municipio"
        Me.cbo_municipio.Size = New System.Drawing.Size(66, 21)
        Me.cbo_municipio.TabIndex = 13
        '
        'cbo_Ufcoleta
        '
        Me.cbo_Ufcoleta.FormattingEnabled = True
        Me.cbo_Ufcoleta.Items.AddRange(New Object() {"", "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "EX", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO"})
        Me.cbo_Ufcoleta.Location = New System.Drawing.Point(12, 37)
        Me.cbo_Ufcoleta.Name = "cbo_Ufcoleta"
        Me.cbo_Ufcoleta.Size = New System.Drawing.Size(57, 21)
        Me.cbo_Ufcoleta.TabIndex = 12
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(79, 21)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 13)
        Me.Label27.TabIndex = 11
        Me.Label27.Text = "Municipio:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(9, 21)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(60, 13)
        Me.Label26.TabIndex = 10
        Me.Label26.Text = "Coleta - UF"
        '
        'Grp_servicos
        '
        Me.Grp_servicos.Controls.Add(Me.GroupBox1)
        Me.Grp_servicos.Controls.Add(Me.msk_dtentrada)
        Me.Grp_servicos.Controls.Add(Me.msk_emissao)
        Me.Grp_servicos.Controls.Add(Me.txt_outras)
        Me.Grp_servicos.Controls.Add(Me.txt_isento)
        Me.Grp_servicos.Controls.Add(Me.Label21)
        Me.Grp_servicos.Controls.Add(Me.Label20)
        Me.Grp_servicos.Controls.Add(Me.txt_icmscred)
        Me.Grp_servicos.Controls.Add(Me.txt_aliq)
        Me.Grp_servicos.Controls.Add(Me.txt_bcalc)
        Me.Grp_servicos.Controls.Add(Me.Label19)
        Me.Grp_servicos.Controls.Add(Me.Label18)
        Me.Grp_servicos.Controls.Add(Me.Label17)
        Me.Grp_servicos.Controls.Add(Me.Label16)
        Me.Grp_servicos.Controls.Add(Me.Label15)
        Me.Grp_servicos.Controls.Add(Me.cbo_cst)
        Me.Grp_servicos.Controls.Add(Me.cbo_cfop)
        Me.Grp_servicos.Controls.Add(Me.txt_total)
        Me.Grp_servicos.Controls.Add(Me.txt_abatimento)
        Me.Grp_servicos.Controls.Add(Me.txt_outdesp)
        Me.Grp_servicos.Controls.Add(Me.Label14)
        Me.Grp_servicos.Controls.Add(Me.Label13)
        Me.Grp_servicos.Controls.Add(Me.Label12)
        Me.Grp_servicos.Controls.Add(Me.txt_vlservico)
        Me.Grp_servicos.Controls.Add(Me.txt_classe)
        Me.Grp_servicos.Controls.Add(Me.Label11)
        Me.Grp_servicos.Controls.Add(Me.Label10)
        Me.Grp_servicos.Controls.Add(Me.msk_vencto)
        Me.Grp_servicos.Controls.Add(Me.Label9)
        Me.Grp_servicos.Controls.Add(Me.Label8)
        Me.Grp_servicos.Controls.Add(Me.msk_mesano)
        Me.Grp_servicos.Controls.Add(Me.msk_fone)
        Me.Grp_servicos.Controls.Add(Me.Label7)
        Me.Grp_servicos.Controls.Add(Me.txt_pcod)
        Me.Grp_servicos.Controls.Add(Me.TabControl1)
        Me.Grp_servicos.Controls.Add(Me.txt_portador)
        Me.Grp_servicos.Controls.Add(Me.Label4)
        Me.Grp_servicos.Controls.Add(Me.txt_numero)
        Me.Grp_servicos.Controls.Add(Me.txt_subserie)
        Me.Grp_servicos.Controls.Add(Me.txt_serie)
        Me.Grp_servicos.Controls.Add(Me.Label5)
        Me.Grp_servicos.Controls.Add(Me.Label3)
        Me.Grp_servicos.Controls.Add(Me.Label2)
        Me.Grp_servicos.Controls.Add(Me.Label1)
        Me.Grp_servicos.Location = New System.Drawing.Point(2, 10)
        Me.Grp_servicos.Name = "Grp_servicos"
        Me.Grp_servicos.Size = New System.Drawing.Size(680, 533)
        Me.Grp_servicos.TabIndex = 0
        Me.Grp_servicos.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_cancela)
        Me.GroupBox1.Controls.Add(Me.btn_incluir)
        Me.GroupBox1.Location = New System.Drawing.Point(596, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(83, 79)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        '
        'btn_cancela
        '
        Me.btn_cancela.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_cancela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancela.Location = New System.Drawing.Point(4, 41)
        Me.btn_cancela.Name = "btn_cancela"
        Me.btn_cancela.Size = New System.Drawing.Size(73, 30)
        Me.btn_cancela.TabIndex = 1
        Me.btn_cancela.Text = "&Cancela"
        Me.btn_cancela.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancela.UseVisualStyleBackColor = True
        '
        'btn_incluir
        '
        Me.btn_incluir.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_incluir.Location = New System.Drawing.Point(4, 9)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(73, 30)
        Me.btn_incluir.TabIndex = 0
        Me.btn_incluir.Text = "&Inclui"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'msk_dtentrada
        '
        Me.msk_dtentrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_dtentrada.Location = New System.Drawing.Point(306, 41)
        Me.msk_dtentrada.Mask = "00/00/0000"
        Me.msk_dtentrada.Name = "msk_dtentrada"
        Me.msk_dtentrada.Size = New System.Drawing.Size(84, 21)
        Me.msk_dtentrada.TabIndex = 5
        Me.msk_dtentrada.ValidatingType = GetType(Date)
        '
        'msk_emissao
        '
        Me.msk_emissao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_emissao.Location = New System.Drawing.Point(207, 41)
        Me.msk_emissao.Mask = "00/00/0000"
        Me.msk_emissao.Name = "msk_emissao"
        Me.msk_emissao.Size = New System.Drawing.Size(89, 21)
        Me.msk_emissao.TabIndex = 4
        Me.msk_emissao.ValidatingType = GetType(Date)
        '
        'txt_outras
        '
        Me.txt_outras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_outras.Location = New System.Drawing.Point(574, 191)
        Me.txt_outras.MaxLength = 14
        Me.txt_outras.Name = "txt_outras"
        Me.txt_outras.Size = New System.Drawing.Size(74, 21)
        Me.txt_outras.TabIndex = 22
        Me.txt_outras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_isento
        '
        Me.txt_isento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_isento.Location = New System.Drawing.Point(482, 193)
        Me.txt_isento.MaxLength = 14
        Me.txt_isento.Name = "txt_isento"
        Me.txt_isento.Size = New System.Drawing.Size(85, 21)
        Me.txt_isento.TabIndex = 21
        Me.txt_isento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(583, 176)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 13)
        Me.Label21.TabIndex = 42
        Me.Label21.Text = "Outras:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(479, 177)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 13)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "Isento/Não Trib.:"
        '
        'txt_icmscred
        '
        Me.txt_icmscred.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_icmscred.Location = New System.Drawing.Point(397, 193)
        Me.txt_icmscred.MaxLength = 14
        Me.txt_icmscred.Name = "txt_icmscred"
        Me.txt_icmscred.Size = New System.Drawing.Size(79, 21)
        Me.txt_icmscred.TabIndex = 20
        Me.txt_icmscred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_aliq
        '
        Me.txt_aliq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_aliq.Location = New System.Drawing.Point(354, 192)
        Me.txt_aliq.MaxLength = 5
        Me.txt_aliq.Name = "txt_aliq"
        Me.txt_aliq.Size = New System.Drawing.Size(36, 21)
        Me.txt_aliq.TabIndex = 19
        Me.txt_aliq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_bcalc
        '
        Me.txt_bcalc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_bcalc.Location = New System.Drawing.Point(264, 192)
        Me.txt_bcalc.MaxLength = 14
        Me.txt_bcalc.Name = "txt_bcalc"
        Me.txt_bcalc.Size = New System.Drawing.Size(84, 21)
        Me.txt_bcalc.TabIndex = 18
        Me.txt_bcalc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(396, 177)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 13)
        Me.Label19.TabIndex = 37
        Me.Label19.Text = "Icms Crédito:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(355, 176)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(35, 13)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "Aliq%:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(271, 175)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 13)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "BCalc. Icms"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(173, 173)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "CST(B):"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 173)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "CFOP:"
        '
        'cbo_cst
        '
        Me.cbo_cst.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_cst.FormattingEnabled = True
        Me.cbo_cst.Items.AddRange(New Object() {"00 - Trib. Integral", "10 - Trib. Icms/Subst.", "20 - Com Redução", "30 - Isenta /Não Trib.", "40 - Isenta", "41 - Não Tributada", "51 - Diferimento", "60 - ICMS Substituto", "70 - Redução e Icms p/ Subst.", "90 - Outros"})
        Me.cbo_cst.Location = New System.Drawing.Point(154, 191)
        Me.cbo_cst.Name = "cbo_cst"
        Me.cbo_cst.Size = New System.Drawing.Size(104, 23)
        Me.cbo_cst.TabIndex = 17
        '
        'cbo_cfop
        '
        Me.cbo_cfop.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_cfop.FormattingEnabled = True
        Me.cbo_cfop.Items.AddRange(New Object() {"1.101 - COMPRA P/ INDUSTRIALIZACAO                                  ", "1.102 - COMPRA P/ COMERCIALIZACAO                                   ", "1.111 - COMPRA P/ INDUSTRIALIZACAO DE MERC. RECEB. ANTER. EM CONSIG.", "1.113 - COMPRA P/ COMERC., DE MERC. RECEB. ANTER. EM CONSIG. MERCANT", "1.116 - COMPRA P/ INDUSTRIALIZ. ORIG. DE ENCOMENDA P/ RECEBIMENTO FU", "1.117 - COMPRA P/ COMERC. ORIG. DE ENCOMENDA P/ RECEBIMENTO FUTURO  ", "1.118 - COMPRA DE MERC. P/ COMERC. PELO ADQUIRENTE ORIGINARIO, ENTRE", "1.120 - COMPRA P/ INDUSTRIALIZ., EM VENDA A ORDEM, JA RECEB. DO VEND", "1.121 - COMPRA P/ COMERC., EM VENDA A ORDEM, JA RECEB. DO VENDEDOR R", "1.122 - COMPRA P/ INDUSTRIALIZ. EM QUE A MERC. FOI REMETIDA PELO FOR", "1.124 - INDUSTRIALIZ. EFETUADA POR OUTRA EMPRESA                    ", "1.125 - INDUSTRIALIZ. EFETUADA POR OUTRA EMPRESA QUANDO A MERC. REME", "1.126 - COMPRA P/ UTILIZ. NA PREST. DE SERV.                        ", "1.151 - TRANSF. P/ INDUSTRIALIZ.                                    ", "1.152 - TRANSF. P/ COMERC.                                          ", "1.153 - TRANSF. DE ENERG. ELETR. P/ DISTRIB.                        ", "1.154 - TRANSF. P/ UTILIZ. NA PREST. DE SERV.                       ", "1.201 - DEVOL. DE VENDA DE PRODUCAO DO ESTAB.                       ", "1.202 - DEVOL. DE VENDA DE MERC. ADQU. OU RECEB. DE TERC.           ", "1.203 - DEVOL. DE VENDA DE PRODUCAO DO ESTAB., DESTINADA A ZONA FRAN", "1.204 - DEVOL. DE VENDA DE MERC. ADQU. OU RECEB. DE TERC., DESTINADA", "1.205 - ANULACAO DE VALOR RELATIVO A PREST. DE SERV. DE COMUN.      ", "1.206 - ANULACAO DE VALOR RELATIVO A PREST. DE SERV. DE TRANSP.     ", "1.207 - ANULACAO DE VALOR RELATIVO A VENDA DE ENERG. ELETR.         ", "1.208 - DEVOL. DE PRODUCAO DO ESTAB., REMETIDA EM TRANSF.           ", "1.209 - DEVOL. DE MERC. ADQU. OU RECEB. DE TERC., REMETIDA EM TRANSF", "1.251 - COMPRA DE ENERG. ELETR. P/ DISTRIB. OU COMERC.              ", "1.252 - COMPRA DE ENERG. ELETR. POR ESTAB. INDUSTRIAL               ", "1.253 - COMPRA DE ENERG. ELETR. POR ESTAB. COMERCIAL                ", "1.254 - COMPRA DE ENERG. ELETR. POR ESTAB. PREST. DE SERV. DE TRANSP", "1.255 - COMPRA DE ENERG. ELETR. POR ESTAB. PREST. DE SERV. DE COMUN.", "1.256 - COMPRA DE ENERG. ELETR. POR ESTAB. DE PRODUTOR RURAL        ", "1.257 - COMPRA DE ENERG. ELETR. P/ CONSUMO POR DEMANDA CONTRATADA   ", "1.301 - AQUIS. DE SERV. DE COMUN. P/ EXEC. DE SERV. DA MESMA NATUREZ", "1.302 - AQUIS. DE SERV. DE COMUN. POR ESTAB. INDUSTRIAL             ", "1.303 - AQUIS. DE SERV. DE COMUN. POR ESTAB. COMERCIAL              ", "1.304 - AQUIS. DE SERV. DE COMUN. POR ESTAB. DE PREST. DE SERV. DE T", "1.305 - AQUIS. DE SERV. DE COMUN. POR ESTAB. DE GERADORA OU DE DISTR", "1.306 - AQUIS. DE SERV. DE COMUN. POR ESTAB. DE PRODUTOR RURAL      ", "1.351 - AQUIS. DE SERV. DE TRANSP. P/ EXEC. DE SERV. DA MESMA NATURE", "1.352 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. INDUSTRIAL            ", "1.353 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. COMERCIAL             ", "1.354 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. DE PREST. DE SERV. DE ", "1.355 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. DE GERADORA OU DE DIST", "1.356 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. DE PRODUTOR RURAL     ", "1.401 - COMPRA P/ INDUSTRIALIZ. EM OPER. COM MERC. SUJ. AO REGIME DE", "1.403 - COMPRA P/ COMERC. EM OPER. COM MERC. SUJ. AO REGIME DE SUBST", "1.406 - COMPRA DE BEM P/ O ATIVO IMOBILIZADO CUJA MERC. ESTA SUJ. AO", "1.407 - COMPRA DE MERC. P/ USO OU CONSUMO CUJA MERC. ESTA SUJ. AO RE", "1.408 - TRANSF. P/ INDUSTRIALIZ. EM OPER. COM MERC. SUJ. AO REGIME D", "1.409 - TRANSF. P/ COMERC. EM OPER. COM MERC. SUJ. AO REGIME DE SUBS", "1.410 - DEVOL. DE VENDA DE PRODUCAO DO ESTAB. EM OPER. COM PRODUTO S", "1.411 - DEVOL. DE VENDA DE MERC. ADQU. OU RECEB. DE TERC. EM OPER. C", "1.414 - RETORNO DE PRODUCAO DO ESTAB., REMETIDA P/ VENDA FORA DO EST", "1.415 - RETORNO DE MERC. ADQU. OU RECEB. DE TERC., REMETIDA P/ VENDA", "1.451 - RETORNO DE ANIMAL DO ESTAB. PRODUTOR                        ", "1.452 - RETORNO DE INSUMO NAO UTILIZADO NA PRODUCAO                 ", "1.501 - ENTR. DE MERC. RECEB. COM FIM ESPECIF. DE EXPORT.           ", "1.503 - ENTR. DECORRENTE DE DEVOL. DE PRODUTO REMETIDO COM FIM ESPEC", "1.504 - ENTR. DECORRENTE DE DEVOL. DE MERC. REMETIDA COM FIM ESPECIF", "1.551 - COMPRA DE BEM P/ O ATIVO IMOBILIZADO                        ", "1.552 - TRANSF. DE BEM DO ATIVO IMOBILIZADO                         ", "1.553 - DEVOL. DE VENDA DE BEM DO ATIVO IMOBILIZADO                 ", "1.554 - RETORNO DE BEM DO ATIVO IMOBILIZADO REMETIDO P/ USO FORA DO ", "1.555 - ENTR. DE BEM DO ATIVO IMOBILIZADO DE TERCEIRO, REMETIDO P/ U", "1.556 - COMPRA DE MATERIAL P/ USO OU CONSUMO                        ", "1.557 - TRANSF. DE MATERIAL P/ USO OU CONSUMO                       ", "1.601 - RECEBIMENTO, POR TRANSF., DE CREDITO DE ICMS                ", "1.602 - RECEBIMENTO, POR TRANSF., DE SALDO CREDOR DE ICMS DE OUTRO E", "1.603 - RESSARCIMENTO DE ICMS RETIDO POR SUBST. TRIB.               ", "1.604 - LANCAMENTO DO CREDITO RELATIVO A COMPRA DE BEM P/ O ATIVO IM", "1.605 - RECEBIMENTO, POR TRANSF., DE SALDO DEVEDOR DE ICMS DE OUTRO ", "1.650 - ENTR.S DE COMBUSTIVEIS, DERIVADOS OU NAO DE PETROLEO E LUBRI", "1.651 - COMPRA DE COMBUST. OU LUBRIFI. P/ INDUSTRIALIZ. SUBSEQ.     ", "1.652 - COMPRA DE COMBUST. OU LUBRIFI. P/ COMERC.                   ", "1.653 - COMPRA DE COMBUST. OU LUBRIFI. POR CONSUMIDOR OU USUARIO FIN", "1.658 - TRANSF. DE COMBUST. E LUBRIFI. P/ INDUSTRIALIZ.             ", "1.659 - TRANSF. DE COMBUST. E LUBRIFI. P/ COMERC.                   ", "1.660 - DEVOL. DE VENDA DE COMBUST. OU LUBRIFI. DESTINADO A INDUSTRI", "1.661 - DEVOL. DE VENDA DE COMBUST. OU LUBRIFI. DESTINADO A COMERC. ", "1.662 - DEVOL. DE VENDA DE COMBUST. OU LUBRIFI. DESTINADO A CONSUMID", "1.663 - ENTR. DE COMBUST. OU LUBRIFI. P/ ARMAZENAGEM                ", "1.664 - RETORNO DE COMBUST. OU LUBRIFI. REMETIDO P/ ARMAZENAGEM     ", "1.901 - ENTR. P/ INDUSTRIALIZ. POR ENCOMENDA                        ", "1.902 - RETORNO DE MERC. REMETIDA P/ INDUSTRIALIZ. POR ENCOMENDA    ", "1.903 - ENTR. DE MERC. REMETIDA P/ INDUSTRIALIZ. E NAO APLICADA NO R", "1.904 - RETORNO DE REMESSA P/ VENDA FORA DO ESTAB.                  ", "1.905 - ENTR. DE MERC. RECEB. P/ DEPOSITO EM DEPOSITO FECHADO OU ARM", "1.906 - RETORNO DE MERC. REMETIDA P/ DEPOSITO FECHADO OU ARMAZEM GER", "1.907 - RETORNO SIMBOLICO DE MERC. REMETIDA P/ DEPOSITO FECHADO OU A", "1.908 - ENTR. DE BEM POR CONTA DE CONTRATO DE COMODATO              ", "1.909 - RETORNO DE BEM REMETIDO POR CONTA DE CONTRATO DE COMODATO   ", "1.910 - ENTR. DE BONIF., DOACAO OU BRINDE                           ", "1.911 - ENTR. DE AMOSTRA GRATIS                                     ", "1.912 - ENTR. DE MERC. OU BEM RECEB. P/ DEMONSTRACAO                ", "1.913 - RETORNO DE MERC. OU BEM REMETIDO P/ DEMONSTRACAO            ", "1.914 - RETORNO DE MERC. OU BEM REMETIDO P/ EXPOSICAO OU FEIRA      ", "1.915 - ENTR. DE MERC. OU BEM RECEB. P/ CONSERTO OU REPARO          ", "1.916 - RETORNO DE MERC. OU BEM REMETIDO P/ CONSERTO OU REPARO      ", "1.917 - ENTR. DE MERC. RECEB. EM CONSIG. MERCANTIL OU INDUSTRIAL    ", "1.918 - DEVOL. DE MERC. REMETIDA EM CONSIG. MERCANTIL OU INDUSTRIAL ", "1.919 - DEVOL. SIMBOLICA DE MERC. VENDIDA OU UTILIZADA EM PROCESSO I", "1.920 - ENTR. DE VASILHAME OU SACARIA                               ", "1.921 - RETORNO DE VASILHAME OU SACARIA                             ", "1.922 - LANCAMENTO EFETUADO A TITULO DE SIMPLES FATURAMENTO DECORREN", "1.923 - ENTR. DE MERC. RECEB. DO VENDEDOR REMETENTE, EM VENDA A ORDE", "1.924 - ENTR. P/ INDUSTRIALIZ. POR CONTA E ORDEM DO ADQUIRENTE DA ME", "1.925 - RETORNO DE MERC. REMETIDA P/ INDUSTRIALIZ. POR CONTA E ORDEM", "1.926 - LANCAMENTO EFETUADO A TITULO DE RECLASSIFICACAO DE MERC. DEC", "1.931 - LANCAMENTO EFETUADO PELO TOMADOR DO SERV. DE TRANSP. QUANDO ", "1.932 - AQUIS. DE SERV. DE TRANSP. INICIADO EM UNIDADE DA FEDERACAO ", "1.933 - AQUIS. DE SERV. TRIBUTADO PELO ISSQN                        ", "1.949 - OUTRA ENTR. DE MERC. OU PREST. DE SERV. NAO ESPECIFICADA    ", "2.101 - COMPRA P/ INDUSTRIALIZ.                                     ", "2.102 - COMPRA P/ COMERC.                                           ", "2.111 - COMPRA P/ INDUSTRIALIZ. DE MERC. RECEB. ANTER. EM CONSIG. IN", "2.113 - COMPRA P/ COMERC., DE MERC. RECEB. ANTER. EM CONSIG. MERCANT", "2.116 - COMPRA P/ INDUSTRIALIZ. ORIG. DE ENCOMENDA P/ RECEBIMENTO FU", "2.117 - COMPRA P/ COMERC. ORIG. DE ENCOMENDA P/ RECEBIMENTO FUTURO  ", "2.118 - COMPRA DE MERC. P/ COMERC. PELO ADQUIRENTE ORIGINARIO, ENTRE", "2.120 - COMPRA P/ INDUSTRIALIZ., EM VENDA A ORDEM, JA RECEB. DO VEND", "2.121 - COMPRA P/ COMERC., EM VENDA A ORDEM, JA RECEB. DO VENDEDOR R", "2.122 - COMPRA P/ INDUSTRIALIZ. EM QUE A MERC. FOI REMETIDA PELO FOR", "2.124 - INDUSTRIALIZ. EFETUADA POR OUTRA EMPRESA                    ", "2.125 - INDUSTRIALIZ. EFETUADA POR OUTRA EMPRESA QUANDO A MERC. REME", "2.126 - COMPRA P/ UTILIZ. NA PREST. DE SERV.                        ", "2.151 - TRANSF. P/ INDUSTRIALIZ.                                    ", "2.152 - TRANSF. P/ COMERC.                                          ", "2.153 - TRANSF. DE ENERG. ELETR. P/ DISTRIB.                        ", "2.154 - TRANSF. P/ UTILIZ. NA PREST. DE SERV.                       ", "2.201 - DEVOL. DE VENDA DE PRODUCAO DO ESTAB.                       ", "2.202 - DEVOL. DE VENDA DE MERC. ADQU. OU RECEB. DE TERC.           ", "2.203 - DEVOL. DE VENDA DE PRODUCAO DO ESTAB., DESTINADA A ZONA FRAN", "2.204 - DEVOL. DE VENDA DE MERC. ADQU. OU RECEB. DE TERC., DESTINADA", "2.205 - ANULACAO DE VALOR RELATIVO A PREST. DE SERV. DE COMUN.      ", "2.206 - ANULACAO DE VALOR RELATIVO A PREST. DE SERV. DE TRANSP.     ", "2.207 - ANULACAO DE VALOR RELATIVO A VENDA DE ENERG. ELETR.         ", "2.208 - DEVOL. DE PRODUCAO DO ESTAB., REMETIDA EM TRANSF.           ", "2.209 - DEVOL. DE MERC. ADQU. OU RECEB. DE TERC., REMETIDA EM TRANSF", "2.251 - COMPRA DE ENERG. ELETR. P/ DISTRIB. OU COMERC.              ", "2.252 - COMPRA DE ENERG. ELETR. POR ESTAB. INDUSTRIAL               ", "2.253 - COMPRA DE ENERG. ELETR. POR ESTAB. COMERCIAL                ", "2.254 - COMPRA DE ENERG. ELETR. POR ESTAB. PREST. DE SERV. DE TRANSP", "2.255 - COMPRA DE ENERG. ELETR. POR ESTAB. PREST. DE SERV. DE COMUN.", "2.256 - COMPRA DE ENERG. ELETR. POR ESTAB. DE PRODUTOR RURAL        ", "2.257 - COMPRA DE ENERG. ELETR. P/ CONSUMO POR DEMANDA CONTRATADA   ", "2.301 - AQUIS. DE SERV. DE COMUN. P/ EXEC. DE SERV. DA MESMA NATUREZ", "2.302 - AQUIS. DE SERV. DE COMUN. POR ESTAB. INDUSTRIAL             ", "2.303 - AQUIS. DE SERV. DE COMUN. POR ESTAB. COMERCIAL              ", "2.304 - AQUIS. DE SERV. DE COMUN. POR ESTAB. DE PREST. DE SERV. DE T", "2.305 - AQUIS. DE SERV. DE COMUN. POR ESTAB. DE GERADORA OU DE DISTR", "2.306 - AQUIS. DE SERV. DE COMUN. POR ESTAB. DE PRODUTOR RURAL      ", "2.351 - AQUIS. DE SERV. DE TRANSP. P/ EXEC. DE SERV. DA MESMA NATURE", "2.352 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. INDUSTRIAL            ", "2.353 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. COMERCIAL             ", "2.354 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. DE PREST. DE SERV. DE ", "2.355 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. DE GERADORA OU DE DIST", "2.356 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. DE PRODUTOR RURAL     ", "2.401 - COMPRA P/ INDUSTRIALIZ. EM OPER. COM MERC. SUJ. AO REGIME DE", "2.403 - COMPRA P/ COMERC. EM OPER. COM MERC. SUJ. AO REGIME DE SUBST", "2.406 - COMPRA DE BEM P/ O ATIVO IMOBILIZADO CUJA MERC. ESTA SUJ. AO", "2.407 - COMPRA DE MERC. P/ USO OU CONSUMO CUJA MERC. ESTA SUJ. AO RE", "2.408 - TRANSF. P/ INDUSTRIALIZ. EM OPER. COM MERC. SUJ. AO REGIME D", "2.409 - TRANSF. P/ COMERC. EM OPER. COM MERC. SUJ. AO REGIME DE SUBS", "2.410 - DEVOL. DE VENDA DE PRODUCAO DO ESTAB. EM OPER. COM PRODUTO S", "2.411 - DEVOL. DE VENDA DE MERC. ADQU. OU RECEB. DE TERC. EM OPER. C", "2.414 - RETORNO DE PRODUCAO DO ESTAB., REMETIDA P/ VENDA FORA DO EST", "2.415 - RETORNO DE MERC. ADQU. OU RECEB. DE TERC., REMETIDA P/ VENDA", "2.501 - ENTR. DE MERC. RECEB. COM FIM ESPECIF. DE EXPORT.           ", "2.503 - ENTR. DECORRENTE DE DEVOL. DE PRODUTO REMETIDO COM FIM ESPEC", "2.504 - ENTR. DECORRENTE DE DEVOL. DE MERC. REMETIDA COM FIM ESPECIF", "2.551 - COMPRA DE BEM P/ O ATIVO IMOBILIZADO                        ", "2.552 - TRANSF. DE BEM DO ATIVO IMOBILIZADO                         ", "2.553 - DEVOL. DE VENDA DE BEM DO ATIVO IMOBILIZADO                 ", "2.554 - RETORNO DE BEM DO ATIVO IMOBILIZADO REMETIDO P/ USO FORA DO ", "2.555 - ENTR. DE BEM DO ATIVO IMOBILIZADO DE TERCEIRO, REMETIDO P/ U", "2.556 - COMPRA DE MATERIAL P/ USO OU CONSUMO                        ", "2.557 - TRANSF. DE MATERIAL P/ USO OU CONSUMO                       ", "2.603 - RESSARCIMENTO DE ICMS RETIDO POR SUBST. TRIB.               ", "2.651 - ENTR.S DE COMBUSTIVEIS, DERIVADOS OU NAO DE PETROLEO E LUBRI", "2.652 - COMPRA DE COMBUST. OU LUBRIFI. P/ COMERC.                   ", "2.653 - COMPRA DE COMBUST. OU LUBRIFI. POR CONSUMIDOR OU USUARIO FIN", "2.658 - TRANSF. DE COMBUST. E LUBRIFI. P/ INDUSTRIALIZ.             ", "2.659 - TRANSF. DE COMBUST. E LUBRIFI. P/ COMERC.                   ", "2.660 - DEVOL. DE VENDA DE COMBUST. OU LUBRIFI. DESTINADO A INDUSTRI", "2.661 - DEVOL. DE VENDA DE COMBUST. OU LUBRIFI. DESTINADO A COMERC. ", "2.662 - DEVOL. DE VENDA DE COMBUST. OU LUBRIFI. DESTINADO A CONSUMID", "2.663 - ENTR. DE COMBUST. OU LUBRIFI. P/ ARMAZENAGEM                ", "2.664 - RETORNO DE COMBUST. OU LUBRIFI. REMETIDO P/ ARMAZENAGEM     ", "2.901 - ENTR. P/ INDUSTRIALIZ. POR ENCOMENDA                        ", "2.902 - RETORNO DE MERC. REMETIDA P/ INDUSTRIALIZ. POR ENCOMENDA    ", "2.903 - ENTR. DE MERC. REMETIDA P/ INDUSTRIALIZ. E NAO APLICADA NO R", "2.904 - RETORNO DE REMESSA P/ VENDA FORA DO ESTAB.                  ", "2.905 - ENTR. DE MERC. RECEB. P/ DEPOSITO EM DEPOSITO FECHADO OU ARM", "2.906 - RETORNO DE MERC. REMETIDA P/ DEPOSITO FECHADO OU ARMAZEM GER", "2.907 - RETORNO SIMBOLICO DE MERC. REMETIDA P/ DEPOSITO FECHADO OU A", "2.908 - ENTR. DE BEM POR CONTA DE CONTRATO DE COMODATO              ", "2.909 - RETORNO DE BEM REMETIDO POR CONTA DE CONTRATO DE COMODATO   ", "2.910 - ENTR. DE BONIF., DOACAO OU BRINDE                           ", "2.911 - ENTR. DE AMOSTRA GRATIS                                     ", "2.912 - ENTR. DE MERC. OU BEM RECEB. P/ DEMONSTRACAO                ", "2.913 - RETORNO DE MERC. OU BEM REMETIDO P/ DEMONSTRACAO            ", "2.914 - RETORNO DE MERC. OU BEM REMETIDO P/ EXPOSICAO OU FEIRA      ", "2.915 - ENTR. DE MERC. OU BEM RECEB. P/ CONSERTO OU REPARO          ", "2.916 - RETORNO DE MERC. OU BEM REMETIDO P/ CONSERTO OU REPARO      ", "2.917 - ENTR. DE MERC. RECEB. EM CONSIG. MERCANTIL OU INDUSTRIAL    ", "2.918 - DEVOL. DE MERC. REMETIDA EM CONSIG. MERCANTIL OU INDUSTRIAL ", "2.919 - DEVOL. SIMBOLICA DE MERC. VENDIDA OU UTILIZADA EM PROCESSO I", "2.920 - ENTR. DE VASILHAME OU SACARIA                               ", "2.921 - RETORNO DE VASILHAME OU SACARIA                             ", "2.922 - LANCAMENTO EFETUADO A TITULO DE SIMPLES FATURAMENTO DECORREN", "2.923 - ENTR. DE MERC. RECEB. DO VENDEDOR REMETENTE, EM VENDA A ORDE", "2.924 - ENTR. P/ INDUSTRIALIZ. POR CONTA E ORDEM DO ADQUIRENTE DA ME", "2.925 - RETORNO DE MERC. REMETIDA P/ INDUSTRIALIZ. POR CONTA E ORDEM", "2.931 - LANCAMENTO EFETUADO PELO TOMADOR DO SERV. DE TRANSP. QUANDO ", "2.932 - AQUIS. DE SERV. DE TRANSP. INICIADO EM UNIDADE DA FEDERACAO ", "2.933 - AQUIS. DE SERV. TRIBUTADO PELO ISSQN                        ", "2.949 - OUTRA ENTR. DE MERC. OU PREST. DE SERV. NAO ESPECIFI.       ", "3.101 - COMPRA P/ INDUSTRIALIZ.                                     ", "3.102 - COMPRA P/ COMERC.                                           ", "3.126 - COMPRA P/ UTILIZ. NA PREST. DE SERV.                        ", "3.127 - COMPRA P/ INDUSTRIALIZ. SOB O REGIME DE DRAWBACK            ", "3.201 - DEVOL. DE VENDA DE PRODUCAO DO ESTAB.                       ", "3.202 - DEVOL. DE VENDA DE MERC. ADQU. OU RECEB. DE TERC.           ", "3.205 - ANULACAO DE VALOR RELATIVO A PREST. DE SERV. DE COMUN.      ", "3.206 - ANULACAO DE VALOR RELATIVO A PREST. DE SERV. DE TRANSP.     ", "3.207 - ANULACAO DE VALOR RELATIVO A VENDA DE ENERG. ELETR.         ", "3.211 - DEVOL. DE VENDA DE PRODUCAO DO ESTAB. SOB O REGIME DE ""DRAWB", "3.251 - COMPRA DE ENERG. ELETR. P/ DISTRIB. OU COMERC.              ", "3.301 - AQUIS. DE SERV. DE COMUN. P/ EXEC. DE SERV. DA MESMA NATUREZ", "3.351 - AQUIS. DE SERV. DE TRANSP. P/ EXEC. DE SERV. DA MESMA NATURE", "3.352 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. INDUSTRIAL            ", "3.353 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. COMERCIAL             ", "3.354 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. DE PREST. DE SERV. DE ", "3.355 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. DE GERADORA OU DE DIST", "3.356 - AQUIS. DE SERV. DE TRANSP. POR ESTAB. DE PRODUTOR RURAL     ", "3.503 - DEVOL. DE MERC. EXPORTADA QUE TENHA SIDO RECEB. COM FIM ESPE", "3.551 - COMPRA DE BEM P/ O ATIVO IMOBILIZADO                        ", "3.553 - DEVOL. DE VENDA DE BEM DO ATIVO IMOBILIZADO                 ", "3.556 - COMPRA DE MATERIAL P/ USO OU CONSUMO                        ", "3.650 - ENTR.S DE COMBUSTIVEIS, DERIVADOS OU NAO DE PETROLEO E LUBRI", "3.651 - COMPRA DE COMBUST. OU LUBRIFI. P/ INDUSTRIALIZ. SUBSEQ.     ", "3.652 - COMPRA DE COMBUST. OU LUBRIFI. P/ COMERC.                   ", "3.653 - COMPRA DE COMBUST. OU LUBRIFI. POR CONSUMIDOR OU USUARIO FIN", "3.930 - LANCAMENTO EFETUADO A TITULO DE ENTR. DE BEM SOB AMPARO DE R", "3.949 - OUTRA ENTR. DE MERC. OU PREST. DE SERV. NAO ESPECIFI.       "})
        Me.cbo_cfop.Location = New System.Drawing.Point(10, 193)
        Me.cbo_cfop.Name = "cbo_cfop"
        Me.cbo_cfop.Size = New System.Drawing.Size(138, 20)
        Me.cbo_cfop.TabIndex = 16
        '
        'txt_total
        '
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(576, 143)
        Me.txt_total.MaxLength = 14
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(75, 21)
        Me.txt_total.TabIndex = 15
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_abatimento
        '
        Me.txt_abatimento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_abatimento.Location = New System.Drawing.Point(507, 143)
        Me.txt_abatimento.MaxLength = 14
        Me.txt_abatimento.Name = "txt_abatimento"
        Me.txt_abatimento.Size = New System.Drawing.Size(60, 21)
        Me.txt_abatimento.TabIndex = 14
        Me.txt_abatimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_outdesp
        '
        Me.txt_outdesp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_outdesp.Location = New System.Drawing.Point(429, 143)
        Me.txt_outdesp.MaxLength = 14
        Me.txt_outdesp.Name = "txt_outdesp"
        Me.txt_outdesp.Size = New System.Drawing.Size(70, 21)
        Me.txt_outdesp.TabIndex = 13
        Me.txt_outdesp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(579, 126)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Valor Total:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(504, 126)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Abatimento:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(434, 126)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Out/Desp.:"
        '
        'txt_vlservico
        '
        Me.txt_vlservico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vlservico.Location = New System.Drawing.Point(341, 143)
        Me.txt_vlservico.MaxLength = 14
        Me.txt_vlservico.Name = "txt_vlservico"
        Me.txt_vlservico.Size = New System.Drawing.Size(72, 21)
        Me.txt_vlservico.TabIndex = 12
        Me.txt_vlservico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_classe
        '
        Me.txt_classe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_classe.Location = New System.Drawing.Point(274, 143)
        Me.txt_classe.MaxLength = 8
        Me.txt_classe.Name = "txt_classe"
        Me.txt_classe.Size = New System.Drawing.Size(57, 21)
        Me.txt_classe.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(354, 126)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Serviço:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(284, 126)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Classe:"
        '
        'msk_vencto
        '
        Me.msk_vencto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_vencto.Location = New System.Drawing.Point(188, 143)
        Me.msk_vencto.Mask = "00/00/0000"
        Me.msk_vencto.Name = "msk_vencto"
        Me.msk_vencto.Size = New System.Drawing.Size(79, 21)
        Me.msk_vencto.TabIndex = 10
        Me.msk_vencto.ValidatingType = GetType(Date)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(195, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Vencimento"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(121, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Mês/Ano:"
        '
        'msk_mesano
        '
        Me.msk_mesano.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_mesano.Location = New System.Drawing.Point(115, 143)
        Me.msk_mesano.Mask = "00/0000"
        Me.msk_mesano.Name = "msk_mesano"
        Me.msk_mesano.Size = New System.Drawing.Size(65, 21)
        Me.msk_mesano.TabIndex = 9
        '
        'msk_fone
        '
        Me.msk_fone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_fone.Location = New System.Drawing.Point(10, 143)
        Me.msk_fone.Mask = "(999)0000-0000"
        Me.msk_fone.Name = "msk_fone"
        Me.msk_fone.Size = New System.Drawing.Size(99, 21)
        Me.msk_fone.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Fone(xxx):"
        '
        'txt_pcod
        '
        Me.txt_pcod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pcod.Location = New System.Drawing.Point(10, 89)
        Me.txt_pcod.MaxLength = 6
        Me.txt_pcod.Name = "txt_pcod"
        Me.txt_pcod.Size = New System.Drawing.Size(48, 21)
        Me.txt_pcod.TabIndex = 6
        '
        'txt_portador
        '
        Me.txt_portador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_portador.Location = New System.Drawing.Point(66, 89)
        Me.txt_portador.MaxLength = 40
        Me.txt_portador.Name = "txt_portador"
        Me.txt_portador.ReadOnly = True
        Me.txt_portador.Size = New System.Drawing.Size(433, 21)
        Me.txt_portador.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Portador do Serviço:"
        '
        'txt_numero
        '
        Me.txt_numero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero.Location = New System.Drawing.Point(104, 41)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(88, 21)
        Me.txt_numero.TabIndex = 3
        '
        'txt_subserie
        '
        Me.txt_subserie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_subserie.Location = New System.Drawing.Point(52, 41)
        Me.txt_subserie.Name = "txt_subserie"
        Me.txt_subserie.Size = New System.Drawing.Size(31, 21)
        Me.txt_subserie.TabIndex = 2
        '
        'txt_serie
        '
        Me.txt_serie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_serie.Location = New System.Drawing.Point(10, 41)
        Me.txt_serie.Name = "txt_serie"
        Me.txt_serie.Size = New System.Drawing.Size(40, 21)
        Me.txt_serie.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(322, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Entrada:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(223, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Emissão:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(119, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Numero:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Série/Subs.:"
        '
        'Frm_ServicosComunicacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 546)
        Me.Controls.Add(Me.Grp_servicos)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ServicosComunicacao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Servicos de Comunicacao"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dtg_servicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Grp_servicos.ResumeLayout(False)
        Me.Grp_servicos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Grp_servicos As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents txt_subserie As System.Windows.Forms.TextBox
    Friend WithEvents txt_serie As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_pcod As System.Windows.Forms.TextBox
    Friend WithEvents txt_portador As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents msk_mesano As System.Windows.Forms.MaskedTextBox
    Friend WithEvents msk_fone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents txt_abatimento As System.Windows.Forms.TextBox
    Friend WithEvents txt_outdesp As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_vlservico As System.Windows.Forms.TextBox
    Friend WithEvents txt_classe As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents msk_vencto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_icmscred As System.Windows.Forms.TextBox
    Friend WithEvents txt_aliq As System.Windows.Forms.TextBox
    Friend WithEvents txt_bcalc As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbo_cst As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_cfop As System.Windows.Forms.ComboBox
    Friend WithEvents txt_outras As System.Windows.Forms.TextBox
    Friend WithEvents txt_isento As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents msk_dtentrada As System.Windows.Forms.MaskedTextBox
    Friend WithEvents msk_emissao As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btn_sai As System.Windows.Forms.Button
    Friend WithEvents btn_exclui As System.Windows.Forms.Button
    Friend WithEvents dtg_servicos As System.Windows.Forms.DataGridView
    Friend WithEvents btn_altera As System.Windows.Forms.Button
    Friend WithEvents btn_inclui As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_creditopis As System.Windows.Forms.TextBox
    Friend WithEvents cbo_cstpis As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_natureza As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents txt_municipio As System.Windows.Forms.TextBox
    Friend WithEvents cbo_municipio As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Ufcoleta As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancela As System.Windows.Forms.Button
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
End Class
