<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LancamentoConvertOrca
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
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.chk_recebidoAnteriormente = New System.Windows.Forms.CheckBox()
        Me.cbo_tpAtendimento = New System.Windows.Forms.ComboBox()
        Me.txt_hora = New System.Windows.Forms.MaskedTextBox()
        Me.cbo_protetico = New System.Windows.Forms.ComboBox()
        Me.cbo_descricao = New System.Windows.Forms.ComboBox()
        Me.txt_codPart = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_nomePart = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbo_doutores = New System.Windows.Forms.ComboBox()
        Me.msk_data = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txt_comiss = New System.Windows.Forms.TextBox()
        Me.txt_valor = New System.Windows.Forms.TextBox()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.txt_grupo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grb_lancamentos = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grb_lancamentos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_incluir
        '
        Me.btn_incluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_incluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_incluir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_incluir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_incluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_incluir.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btn_incluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_incluir.Image = Global.RTecSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_incluir.Location = New System.Drawing.Point(739, 337)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(98, 43)
        Me.btn_incluir.TabIndex = 0
        Me.btn_incluir.Text = "&Inclui"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_incluir.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 331)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(693, 53)
        Me.GroupBox2.TabIndex = 57
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(12, 24)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = "    "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-5, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(867, 42)
        Me.Panel1.TabIndex = 59
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(349, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'chk_recebidoAnteriormente
        '
        Me.chk_recebidoAnteriormente.AutoSize = True
        Me.chk_recebidoAnteriormente.BackColor = System.Drawing.Color.Transparent
        Me.chk_recebidoAnteriormente.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.chk_recebidoAnteriormente.ForeColor = System.Drawing.Color.DarkBlue
        Me.chk_recebidoAnteriormente.Location = New System.Drawing.Point(605, 20)
        Me.chk_recebidoAnteriormente.Name = "chk_recebidoAnteriormente"
        Me.chk_recebidoAnteriormente.Size = New System.Drawing.Size(227, 26)
        Me.chk_recebidoAnteriormente.TabIndex = 37
        Me.chk_recebidoAnteriormente.Text = "Recebido Anteriormente"
        Me.chk_recebidoAnteriormente.UseVisualStyleBackColor = False
        '
        'cbo_tpAtendimento
        '
        Me.cbo_tpAtendimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tpAtendimento.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.cbo_tpAtendimento.FormattingEnabled = True
        Me.cbo_tpAtendimento.Location = New System.Drawing.Point(488, 138)
        Me.cbo_tpAtendimento.Name = "cbo_tpAtendimento"
        Me.cbo_tpAtendimento.Size = New System.Drawing.Size(179, 23)
        Me.cbo_tpAtendimento.TabIndex = 10
        '
        'txt_hora
        '
        Me.txt_hora.BackColor = System.Drawing.SystemColors.Info
        Me.txt_hora.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txt_hora.Location = New System.Drawing.Point(547, 78)
        Me.txt_hora.Mask = "00:00"
        Me.txt_hora.Name = "txt_hora"
        Me.txt_hora.ReadOnly = True
        Me.txt_hora.Size = New System.Drawing.Size(57, 24)
        Me.txt_hora.TabIndex = 36
        Me.txt_hora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txt_hora.ValidatingType = GetType(Date)
        '
        'cbo_protetico
        '
        Me.cbo_protetico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_protetico.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.cbo_protetico.FormattingEnabled = True
        Me.cbo_protetico.Location = New System.Drawing.Point(383, 197)
        Me.cbo_protetico.Name = "cbo_protetico"
        Me.cbo_protetico.Size = New System.Drawing.Size(171, 23)
        Me.cbo_protetico.TabIndex = 15
        '
        'cbo_descricao
        '
        Me.cbo_descricao.FormattingEnabled = True
        Me.cbo_descricao.Location = New System.Drawing.Point(15, 135)
        Me.cbo_descricao.Name = "cbo_descricao"
        Me.cbo_descricao.Size = New System.Drawing.Size(455, 27)
        Me.cbo_descricao.TabIndex = 9
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_codPart.Location = New System.Drawing.Point(81, 238)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(70, 23)
        Me.txt_codPart.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(485, 114)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 17)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Atendimento:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(12, 241)
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
        Me.txt_nomePart.Location = New System.Drawing.Point(157, 238)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(353, 23)
        Me.txt_nomePart.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(380, 173)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 17)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Prot.:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(285, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 17)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Comis.:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(12, 173)
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
        Me.cbo_doutores.Location = New System.Drawing.Point(15, 196)
        Me.cbo_doutores.Name = "cbo_doutores"
        Me.cbo_doutores.Size = New System.Drawing.Size(249, 23)
        Me.cbo_doutores.TabIndex = 11
        '
        'msk_data
        '
        Me.msk_data.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.msk_data.Location = New System.Drawing.Point(233, 75)
        Me.msk_data.Name = "msk_data"
        Me.msk_data.Size = New System.Drawing.Size(110, 26)
        Me.msk_data.TabIndex = 35
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Image = Global.RTecSys.My.Resources.Resources.Financ_1
        Me.PictureBox2.Location = New System.Drawing.Point(683, 57)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(142, 145)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'txt_comiss
        '
        Me.txt_comiss.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comiss.Location = New System.Drawing.Point(288, 196)
        Me.txt_comiss.MaxLength = 14
        Me.txt_comiss.Name = "txt_comiss"
        Me.txt_comiss.Size = New System.Drawing.Size(55, 23)
        Me.txt_comiss.TabIndex = 13
        Me.txt_comiss.Text = "0,00"
        Me.txt_comiss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_valor
        '
        Me.txt_valor.BackColor = System.Drawing.SystemColors.Window
        Me.txt_valor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_valor.Location = New System.Drawing.Point(446, 78)
        Me.txt_valor.MaxLength = 14
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.Size = New System.Drawing.Size(81, 23)
        Me.txt_valor.TabIndex = 7
        Me.txt_valor.Text = "0,00"
        Me.txt_valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.Info
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Red
        Me.txt_total.Location = New System.Drawing.Point(722, 242)
        Me.txt_total.MaxLength = 14
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(98, 26)
        Me.txt_total.TabIndex = 22
        Me.txt_total.Text = "0,00"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_grupo
        '
        Me.txt_grupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_grupo.Location = New System.Drawing.Point(354, 78)
        Me.txt_grupo.MaxLength = 3
        Me.txt_grupo.Name = "txt_grupo"
        Me.txt_grupo.Size = New System.Drawing.Size(59, 23)
        Me.txt_grupo.TabIndex = 33
        Me.txt_grupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(552, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 17)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Hora:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(443, 53)
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
        Me.cbo_tipo.Location = New System.Drawing.Point(15, 75)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(192, 24)
        Me.cbo_tipo.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(729, 222)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Total R$:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Descrição:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(230, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(351, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Grupo:"
        '
        'grb_lancamentos
        '
        Me.grb_lancamentos.Controls.Add(Me.chk_recebidoAnteriormente)
        Me.grb_lancamentos.Controls.Add(Me.cbo_tpAtendimento)
        Me.grb_lancamentos.Controls.Add(Me.txt_hora)
        Me.grb_lancamentos.Controls.Add(Me.cbo_protetico)
        Me.grb_lancamentos.Controls.Add(Me.cbo_descricao)
        Me.grb_lancamentos.Controls.Add(Me.txt_codPart)
        Me.grb_lancamentos.Controls.Add(Me.Label12)
        Me.grb_lancamentos.Controls.Add(Me.Label7)
        Me.grb_lancamentos.Controls.Add(Me.txt_nomePart)
        Me.grb_lancamentos.Controls.Add(Me.Label10)
        Me.grb_lancamentos.Controls.Add(Me.Label8)
        Me.grb_lancamentos.Controls.Add(Me.Label6)
        Me.grb_lancamentos.Controls.Add(Me.cbo_doutores)
        Me.grb_lancamentos.Controls.Add(Me.msk_data)
        Me.grb_lancamentos.Controls.Add(Me.PictureBox2)
        Me.grb_lancamentos.Controls.Add(Me.txt_comiss)
        Me.grb_lancamentos.Controls.Add(Me.txt_valor)
        Me.grb_lancamentos.Controls.Add(Me.txt_total)
        Me.grb_lancamentos.Controls.Add(Me.txt_grupo)
        Me.grb_lancamentos.Controls.Add(Me.Label11)
        Me.grb_lancamentos.Controls.Add(Me.Label9)
        Me.grb_lancamentos.Controls.Add(Me.cbo_tipo)
        Me.grb_lancamentos.Controls.Add(Me.Label5)
        Me.grb_lancamentos.Controls.Add(Me.Label4)
        Me.grb_lancamentos.Controls.Add(Me.Label3)
        Me.grb_lancamentos.Controls.Add(Me.Label2)
        Me.grb_lancamentos.Controls.Add(Me.Label1)
        Me.grb_lancamentos.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.grb_lancamentos.Location = New System.Drawing.Point(12, 46)
        Me.grb_lancamentos.Name = "grb_lancamentos"
        Me.grb_lancamentos.Size = New System.Drawing.Size(832, 277)
        Me.grb_lancamentos.TabIndex = 56
        Me.grb_lancamentos.TabStop = False
        Me.grb_lancamentos.Text = "Lançamentos"
        '
        'Frm_LancamentoConvertOrca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 395)
        Me.Controls.Add(Me.btn_incluir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grb_lancamentos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_LancamentoConvertOrca"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Convertendo Orçamento..."
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grb_lancamentos.ResumeLayout(False)
        Me.grb_lancamentos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents chk_recebidoAnteriormente As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_tpAtendimento As System.Windows.Forms.ComboBox
    Friend WithEvents txt_hora As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbo_protetico As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_descricao As System.Windows.Forms.ComboBox
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbo_doutores As System.Windows.Forms.ComboBox
    Friend WithEvents msk_data As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_comiss As System.Windows.Forms.TextBox
    Friend WithEvents txt_valor As System.Windows.Forms.TextBox
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents txt_grupo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grb_lancamentos As System.Windows.Forms.GroupBox
End Class
