<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_NFEGeraMapa
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
        Me.tab_nfe = New System.Windows.Forms.TabControl
        Me.tbp_nfe = New System.Windows.Forms.TabPage
        Me.tbp_retransmissao = New System.Windows.Forms.TabPage
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
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
        Me.cbo_transportador = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.lbl_emitente = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cbo_estabelecimento = New System.Windows.Forms.ComboBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.lbl_qtdenfe = New System.Windows.Forms.Label
        Me.txt_pedido = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.msk_dtsaida = New System.Windows.Forms.MaskedTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.tab_nfe.SuspendLayout()
        Me.tbp_nfe.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab_nfe
        '
        Me.tab_nfe.Controls.Add(Me.tbp_nfe)
        Me.tab_nfe.Controls.Add(Me.tbp_retransmissao)
        Me.tab_nfe.Location = New System.Drawing.Point(12, 12)
        Me.tab_nfe.Name = "tab_nfe"
        Me.tab_nfe.SelectedIndex = 0
        Me.tab_nfe.Size = New System.Drawing.Size(865, 494)
        Me.tab_nfe.TabIndex = 13
        '
        'tbp_nfe
        '
        Me.tbp_nfe.Controls.Add(Me.GroupBox4)
        Me.tbp_nfe.Controls.Add(Me.GroupBox2)
        Me.tbp_nfe.Controls.Add(Me.GroupBox1)
        Me.tbp_nfe.Location = New System.Drawing.Point(4, 22)
        Me.tbp_nfe.Name = "tbp_nfe"
        Me.tbp_nfe.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_nfe.Size = New System.Drawing.Size(857, 468)
        Me.tbp_nfe.TabIndex = 0
        Me.tbp_nfe.Text = "NFe Mapa"
        Me.tbp_nfe.UseVisualStyleBackColor = True
        '
        'tbp_retransmissao
        '
        Me.tbp_retransmissao.Location = New System.Drawing.Point(4, 22)
        Me.tbp_retransmissao.Name = "tbp_retransmissao"
        Me.tbp_retransmissao.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_retransmissao.Size = New System.Drawing.Size(857, 490)
        Me.tbp_retransmissao.TabIndex = 1
        Me.tbp_retransmissao.Text = "Retransmissão"
        Me.tbp_retransmissao.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RichTextBox1)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 222)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(685, 203)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Retorno Sefaz"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 19)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(671, 175)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
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
        Me.GroupBox2.Location = New System.Drawing.Point(6, 140)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(685, 76)
        Me.GroupBox2.TabIndex = 14
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
        Me.PictureBox1.Location = New System.Drawing.Point(584, 13)
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
        'cbo_transportador
        '
        Me.cbo_transportador.FormattingEnabled = True
        Me.cbo_transportador.Items.AddRange(New Object() {"Emitente", "Terceiro"})
        Me.cbo_transportador.Location = New System.Drawing.Point(88, 16)
        Me.cbo_transportador.Name = "cbo_transportador"
        Me.cbo_transportador.Size = New System.Drawing.Size(121, 21)
        Me.cbo_transportador.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lbl_emitente)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cbo_estabelecimento)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.txt_pedido)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.msk_dtsaida)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(685, 115)
        Me.GroupBox1.TabIndex = 13
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
        Me.cbo_estabelecimento.FormattingEnabled = True
        Me.cbo_estabelecimento.Items.AddRange(New Object() {"01", "02", "03", "04", "05 ", "06"})
        Me.cbo_estabelecimento.Location = New System.Drawing.Point(65, 22)
        Me.cbo_estabelecimento.Name = "cbo_estabelecimento"
        Me.cbo_estabelecimento.Size = New System.Drawing.Size(68, 21)
        Me.cbo_estabelecimento.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.lbl_qtdenfe)
        Me.GroupBox6.Location = New System.Drawing.Point(572, 19)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(107, 43)
        Me.GroupBox6.TabIndex = 14
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "NFe´s"
        '
        'lbl_qtdenfe
        '
        Me.lbl_qtdenfe.AutoSize = True
        Me.lbl_qtdenfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_qtdenfe.Location = New System.Drawing.Point(30, 16)
        Me.lbl_qtdenfe.Name = "lbl_qtdenfe"
        Me.lbl_qtdenfe.Size = New System.Drawing.Size(15, 15)
        Me.lbl_qtdenfe.TabIndex = 0
        Me.lbl_qtdenfe.Text = "0"
        '
        'txt_pedido
        '
        Me.txt_pedido.Location = New System.Drawing.Point(102, 55)
        Me.txt_pedido.MaxLength = 10
        Me.txt_pedido.Name = "txt_pedido"
        Me.txt_pedido.Size = New System.Drawing.Size(89, 20)
        Me.txt_pedido.TabIndex = 3
        Me.txt_pedido.Text = "  "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Pedido/Docum:"
        '
        'msk_dtsaida
        '
        Me.msk_dtsaida.Location = New System.Drawing.Point(65, 81)
        Me.msk_dtsaida.Mask = "00/00/0000"
        Me.msk_dtsaida.Name = "msk_dtsaida"
        Me.msk_dtsaida.Size = New System.Drawing.Size(74, 20)
        Me.msk_dtsaida.TabIndex = 6
        Me.msk_dtsaida.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "DTSaida:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(12, 512)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(861, 48)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'Frm_NFEGeraMapa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 572)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.tab_nfe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_NFEGeraMapa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gera Notas Fiscais pelo Mapa"
        Me.tab_nfe.ResumeLayout(False)
        Me.tbp_nfe.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tab_nfe As System.Windows.Forms.TabControl
    Friend WithEvents tbp_nfe As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_ambiente As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_tipoemissao As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_nfe As System.Windows.Forms.Button
    Friend WithEvents cbo_placa As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_transportador As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbl_emitente As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbo_estabelecimento As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_qtdenfe As System.Windows.Forms.Label
    Friend WithEvents txt_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents msk_dtsaida As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbp_retransmissao As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
