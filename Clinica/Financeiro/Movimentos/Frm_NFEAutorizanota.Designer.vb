<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_NFEAutorizanota
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_NFEAutorizanota))
        Me.cbo_tiponfe = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_codPart = New System.Windows.Forms.TextBox
        Me.cbo_transportador = New System.Windows.Forms.ComboBox
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.msk_dtsaida = New System.Windows.Forms.MaskedTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.lbl_emitente = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cbo_estabelecimento = New System.Windows.Forms.ComboBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_pedido = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbo_nfeCfop = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_ambiente = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lbl_tipoemissao = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btn_nfe = New System.Windows.Forms.Button
        Me.cbo_placa = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbo_tiponfe
        '
        Me.cbo_tiponfe.FormattingEnabled = True
        Me.cbo_tiponfe.Items.AddRange(New Object() {"Saidas Normal", "Transferência"})
        Me.cbo_tiponfe.Location = New System.Drawing.Point(88, 54)
        Me.cbo_tiponfe.Name = "cbo_tiponfe"
        Me.cbo_tiponfe.Size = New System.Drawing.Size(112, 21)
        Me.cbo_tiponfe.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo de NFE:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "DTSaida:"
        '
        'txt_codPart
        '
        Me.txt_codPart.Location = New System.Drawing.Point(65, 83)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(72, 20)
        Me.txt_codPart.TabIndex = 4
        Me.txt_codPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbo_transportador
        '
        Me.cbo_transportador.FormattingEnabled = True
        Me.cbo_transportador.Items.AddRange(New Object() {"Emitente", "Terceiro"})
        Me.cbo_transportador.Location = New System.Drawing.Point(88, 16)
        Me.cbo_transportador.Name = "cbo_transportador"
        Me.cbo_transportador.Size = New System.Drawing.Size(121, 21)
        Me.cbo_transportador.TabIndex = 9
        '
        'txt_nomePart
        '
        Me.txt_nomePart.Location = New System.Drawing.Point(150, 83)
        Me.txt_nomePart.MaxLength = 50
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(356, 20)
        Me.txt_nomePart.TabIndex = 5
        '
        'msk_dtsaida
        '
        Me.msk_dtsaida.Location = New System.Drawing.Point(65, 115)
        Me.msk_dtsaida.Mask = "00/00/0000"
        Me.msk_dtsaida.Name = "msk_dtsaida"
        Me.msk_dtsaida.Size = New System.Drawing.Size(74, 20)
        Me.msk_dtsaida.TabIndex = 6
        Me.msk_dtsaida.ValidatingType = GetType(Date)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lbl_emitente)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cbo_estabelecimento)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.txt_pedido)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbo_nfeCfop)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_codPart)
        Me.GroupBox1.Controls.Add(Me.msk_dtsaida)
        Me.GroupBox1.Controls.Add(Me.cbo_tiponfe)
        Me.GroupBox1.Controls.Add(Me.txt_nomePart)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(634, 144)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados do Destinatário"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(141, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "-"
        '
        'lbl_emitente
        '
        Me.lbl_emitente.AutoSize = True
        Me.lbl_emitente.Location = New System.Drawing.Point(155, 24)
        Me.lbl_emitente.Name = "lbl_emitente"
        Me.lbl_emitente.Size = New System.Drawing.Size(48, 13)
        Me.lbl_emitente.TabIndex = 17
        Me.lbl_emitente.Text = "Emitente"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Empresa:"
        '
        'cbo_estabelecimento
        '
        Me.cbo_estabelecimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_estabelecimento.FormattingEnabled = True
        Me.cbo_estabelecimento.Items.AddRange(New Object() {"01", "02", "03", "04", "05 ", "06"})
        Me.cbo_estabelecimento.Location = New System.Drawing.Point(65, 22)
        Me.cbo_estabelecimento.Name = "cbo_estabelecimento"
        Me.cbo_estabelecimento.Size = New System.Drawing.Size(68, 21)
        Me.cbo_estabelecimento.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Location = New System.Drawing.Point(520, 83)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(107, 43)
        Me.GroupBox6.TabIndex = 14
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Itens"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(30, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "0"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Location = New System.Drawing.Point(515, 16)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(112, 55)
        Me.GroupBox5.TabIndex = 13
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Totais R$"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(16, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "0,00"
        '
        'txt_pedido
        '
        Me.txt_pedido.Location = New System.Drawing.Point(318, 55)
        Me.txt_pedido.MaxLength = 10
        Me.txt_pedido.Name = "txt_pedido"
        Me.txt_pedido.Size = New System.Drawing.Size(89, 20)
        Me.txt_pedido.TabIndex = 3
        Me.txt_pedido.Text = "  "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(226, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Pedido/Docum:"
        '
        'cbo_nfeCfop
        '
        Me.cbo_nfeCfop.FormattingEnabled = True
        Me.cbo_nfeCfop.Items.AddRange(New Object() {"5.102 Venda de Mercadorias Tributadas", "5.152 Transferencia de Mercadorias Tributadas", "5.405 Venda de Mercadoria Suj. Reg. de subst. Tributaria", "5.409 Transferencia de Mercadorias Suj. Reg. de subst. Tributaria", "6.102 Venda de Mercadorias Tributadas", "6.405 Venda de Mercadoria Suj. Reg. de subst. Tributaria"})
        Me.cbo_nfeCfop.Location = New System.Drawing.Point(211, 115)
        Me.cbo_nfeCfop.Name = "cbo_nfeCfop"
        Me.cbo_nfeCfop.Size = New System.Drawing.Size(295, 21)
        Me.cbo_nfeCfop.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(167, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "CFOP:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_ambiente)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.lbl_tipoemissao)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.btn_nfe)
        Me.GroupBox2.Controls.Add(Me.cbo_placa)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbo_transportador)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(634, 76)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Transportador"
        '
        'lbl_ambiente
        '
        Me.lbl_ambiente.AutoSize = True
        Me.lbl_ambiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ambiente.ForeColor = System.Drawing.Color.Red
        Me.lbl_ambiente.Location = New System.Drawing.Point(262, 50)
        Me.lbl_ambiente.Name = "lbl_ambiente"
        Me.lbl_ambiente.Size = New System.Drawing.Size(61, 13)
        Me.lbl_ambiente.TabIndex = 12
        Me.lbl_ambiente.Text = "Produção"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(201, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Ambiente:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MetroSys.My.Resources.Resources.logo_NFe
        Me.PictureBox1.Location = New System.Drawing.Point(534, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(93, 54)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'lbl_tipoemissao
        '
        Me.lbl_tipoemissao.AutoSize = True
        Me.lbl_tipoemissao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tipoemissao.ForeColor = System.Drawing.Color.Red
        Me.lbl_tipoemissao.Location = New System.Drawing.Point(87, 50)
        Me.lbl_tipoemissao.Name = "lbl_tipoemissao"
        Me.lbl_tipoemissao.Size = New System.Drawing.Size(46, 13)
        Me.lbl_tipoemissao.TabIndex = 9
        Me.lbl_tipoemissao.Text = "Normal"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Tipo Emissao:"
        '
        'btn_nfe
        '
        Me.btn_nfe.Image = Global.MetroSys.My.Resources.Resources.NFe
        Me.btn_nfe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_nfe.Location = New System.Drawing.Point(416, 16)
        Me.btn_nfe.Name = "btn_nfe"
        Me.btn_nfe.Size = New System.Drawing.Size(64, 33)
        Me.btn_nfe.TabIndex = 11
        Me.btn_nfe.Text = "&Gerar"
        Me.btn_nfe.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nfe.UseVisualStyleBackColor = True
        '
        'cbo_placa
        '
        Me.cbo_placa.FormattingEnabled = True
        Me.cbo_placa.Items.AddRange(New Object() {"LVX-5051", "LVX-5052", "LVV-5050", "LWX-6585", "LWX-6855"})
        Me.cbo_placa.Location = New System.Drawing.Point(260, 16)
        Me.cbo_placa.Name = "cbo_placa"
        Me.cbo_placa.Size = New System.Drawing.Size(121, 21)
        Me.cbo_placa.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(217, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Placa:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Transportador:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(12, 459)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(634, 63)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RichTextBox1)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 253)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(633, 200)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Retorno Sefaz"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(4, 15)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(623, 179)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'Frm_NFEAutorizanota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 534)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_NFEAutorizanota"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autoriza Nota Fiscal Eletrônica"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbo_tiponfe As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_transportador As System.Windows.Forms.ComboBox
    Friend WithEvents msk_dtsaida As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_nfeCfop As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_placa As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents btn_nfe As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_tipoemissao As System.Windows.Forms.Label
    Friend WithEvents cbo_estabelecimento As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_ambiente As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbl_emitente As System.Windows.Forms.Label
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
End Class
