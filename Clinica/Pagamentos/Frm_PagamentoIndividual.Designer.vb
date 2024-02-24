<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PagamentoIndividual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PagamentoIndividual))
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_desconto = New System.Windows.Forms.TextBox()
        Me.msk_vencto = New System.Windows.Forms.MaskedTextBox()
        Me.txt_atrazo = New System.Windows.Forms.TextBox()
        Me.pdRelatorio = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.msk_dtpaga = New System.Windows.Forms.DateTimePicker()
        Me.cbo_loja = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_baixar = New System.Windows.Forms.Button()
        Me.txt_valor = New System.Windows.Forms.TextBox()
        Me.txt_documento = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_juros = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_totgeral = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_subtotal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_portad = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(431, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 16)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Atrazo:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(212, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 16)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Vencto:"
        '
        'txt_desconto
        '
        Me.txt_desconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desconto.Location = New System.Drawing.Point(271, 92)
        Me.txt_desconto.MaxLength = 16
        Me.txt_desconto.Name = "txt_desconto"
        Me.txt_desconto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_desconto.Size = New System.Drawing.Size(72, 22)
        Me.txt_desconto.TabIndex = 12
        '
        'msk_vencto
        '
        Me.msk_vencto.BackColor = System.Drawing.SystemColors.Info
        Me.msk_vencto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_vencto.Location = New System.Drawing.Point(271, 54)
        Me.msk_vencto.Mask = "00/00/0000"
        Me.msk_vencto.Name = "msk_vencto"
        Me.msk_vencto.ReadOnly = True
        Me.msk_vencto.Size = New System.Drawing.Size(82, 22)
        Me.msk_vencto.TabIndex = 9
        Me.msk_vencto.ValidatingType = GetType(Date)
        '
        'txt_atrazo
        '
        Me.txt_atrazo.BackColor = System.Drawing.SystemColors.Info
        Me.txt_atrazo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_atrazo.Location = New System.Drawing.Point(486, 54)
        Me.txt_atrazo.MaxLength = 4
        Me.txt_atrazo.Name = "txt_atrazo"
        Me.txt_atrazo.ReadOnly = True
        Me.txt_atrazo.Size = New System.Drawing.Size(76, 22)
        Me.txt_atrazo.TabIndex = 10
        Me.txt_atrazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.msk_dtpaga)
        Me.GroupBox1.Controls.Add(Me.cbo_loja)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btn_baixar)
        Me.GroupBox1.Controls.Add(Me.txt_valor)
        Me.GroupBox1.Controls.Add(Me.txt_documento)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 115)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'msk_dtpaga
        '
        Me.msk_dtpaga.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.msk_dtpaga.Location = New System.Drawing.Point(154, 81)
        Me.msk_dtpaga.Name = "msk_dtpaga"
        Me.msk_dtpaga.Size = New System.Drawing.Size(103, 23)
        Me.msk_dtpaga.TabIndex = 6
        '
        'cbo_loja
        '
        Me.cbo_loja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_loja.FormattingEnabled = True
        Me.cbo_loja.Items.AddRange(New Object() {"01", "02", "03", "04"})
        Me.cbo_loja.Location = New System.Drawing.Point(66, 19)
        Me.cbo_loja.Name = "cbo_loja"
        Me.cbo_loja.Size = New System.Drawing.Size(385, 24)
        Me.cbo_loja.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(12, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 19)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Loja :"
        '
        'btn_baixar
        '
        Me.btn_baixar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_baixar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_baixar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_baixar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_baixar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_baixar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_baixar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_baixar.Location = New System.Drawing.Point(470, 28)
        Me.btn_baixar.Name = "btn_baixar"
        Me.btn_baixar.Size = New System.Drawing.Size(87, 72)
        Me.btn_baixar.TabIndex = 5
        Me.btn_baixar.Text = "&Baixar"
        Me.btn_baixar.UseVisualStyleBackColor = False
        '
        'txt_valor
        '
        Me.txt_valor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valor.Location = New System.Drawing.Point(297, 81)
        Me.txt_valor.MaxLength = 16
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_valor.Size = New System.Drawing.Size(100, 23)
        Me.txt_valor.TabIndex = 4
        '
        'txt_documento
        '
        Me.txt_documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_documento.Location = New System.Drawing.Point(16, 81)
        Me.txt_documento.MaxLength = 10
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.Size = New System.Drawing.Size(111, 23)
        Me.txt_documento.TabIndex = 2
        Me.txt_documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(293, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ValorPago R$:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(150, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data Paga:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Documento:"
        '
        'txt_juros
        '
        Me.txt_juros.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txt_juros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_juros.Location = New System.Drawing.Point(89, 92)
        Me.txt_juros.MaxLength = 16
        Me.txt_juros.Name = "txt_juros"
        Me.txt_juros.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_juros.Size = New System.Drawing.Size(81, 22)
        Me.txt_juros.TabIndex = 11
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_atrazo)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.msk_vencto)
        Me.GroupBox2.Controls.Add(Me.txt_desconto)
        Me.GroupBox2.Controls.Add(Me.txt_totgeral)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txt_juros)
        Me.GroupBox2.Controls.Add(Me.txt_subtotal)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txt_portad)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 167)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(571, 129)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'txt_totgeral
        '
        Me.txt_totgeral.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totgeral.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totgeral.ForeColor = System.Drawing.Color.Red
        Me.txt_totgeral.Location = New System.Drawing.Point(462, 92)
        Me.txt_totgeral.MaxLength = 16
        Me.txt_totgeral.Name = "txt_totgeral"
        Me.txt_totgeral.ReadOnly = True
        Me.txt_totgeral.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_totgeral.Size = New System.Drawing.Size(100, 22)
        Me.txt_totgeral.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(193, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 16)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Desc. R$  :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(356, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "ToT-Geral R$  :"
        '
        'txt_subtotal
        '
        Me.txt_subtotal.BackColor = System.Drawing.SystemColors.Info
        Me.txt_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_subtotal.Location = New System.Drawing.Point(89, 57)
        Me.txt_subtotal.MaxLength = 16
        Me.txt_subtotal.Name = "txt_subtotal"
        Me.txt_subtotal.ReadOnly = True
        Me.txt_subtotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_subtotal.Size = New System.Drawing.Size(100, 22)
        Me.txt_subtotal.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Juros R$:"
        '
        'txt_portad
        '
        Me.txt_portad.BackColor = System.Drawing.SystemColors.Info
        Me.txt_portad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_portad.Location = New System.Drawing.Point(89, 20)
        Me.txt_portad.MaxLength = 50
        Me.txt_portad.Name = "txt_portad"
        Me.txt_portad.ReadOnly = True
        Me.txt_portad.Size = New System.Drawing.Size(473, 22)
        Me.txt_portad.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Valor   R$:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Portador :"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-6, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(617, 42)
        Me.Panel1.TabIndex = 55
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(235, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Frm_PagamentoIndividual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 307)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_PagamentoIndividual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagamento Individual"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_desconto As System.Windows.Forms.TextBox
    Friend WithEvents msk_vencto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_atrazo As System.Windows.Forms.TextBox
    Friend WithEvents pdRelatorio As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_loja As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btn_baixar As System.Windows.Forms.Button
    Friend WithEvents txt_valor As System.Windows.Forms.TextBox
    Friend WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_juros As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_totgeral As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_portad As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents msk_dtpaga As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
End Class
