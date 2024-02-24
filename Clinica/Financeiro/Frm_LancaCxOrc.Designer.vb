<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LancaCxOrc
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.txt_hora = New System.Windows.Forms.MaskedTextBox()
        Me.cbo_protetico = New System.Windows.Forms.ComboBox()
        Me.cbo_descricao = New System.Windows.Forms.ComboBox()
        Me.txt_codPart = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_nomePart = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.cbo_doutores = New System.Windows.Forms.ComboBox()
        Me.msk_data = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.txt_valor = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grb_lancamentos = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grb_lancamentos.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 305)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(487, 66)
        Me.GroupBox2.TabIndex = 57
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(19, 27)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = "    "
        '
        'txt_hora
        '
        Me.txt_hora.BackColor = System.Drawing.SystemColors.Info
        Me.txt_hora.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txt_hora.Location = New System.Drawing.Point(283, 57)
        Me.txt_hora.Mask = "00:00"
        Me.txt_hora.Name = "txt_hora"
        Me.txt_hora.ReadOnly = True
        Me.txt_hora.Size = New System.Drawing.Size(60, 26)
        Me.txt_hora.TabIndex = 36
        Me.txt_hora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txt_hora.ValidatingType = GetType(Date)
        '
        'cbo_protetico
        '
        Me.cbo_protetico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_protetico.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.cbo_protetico.FormattingEnabled = True
        Me.cbo_protetico.Location = New System.Drawing.Point(300, 178)
        Me.cbo_protetico.Name = "cbo_protetico"
        Me.cbo_protetico.Size = New System.Drawing.Size(171, 23)
        Me.cbo_protetico.TabIndex = 15
        '
        'cbo_descricao
        '
        Me.cbo_descricao.FormattingEnabled = True
        Me.cbo_descricao.Location = New System.Drawing.Point(15, 116)
        Me.cbo_descricao.Name = "cbo_descricao"
        Me.cbo_descricao.Size = New System.Drawing.Size(456, 27)
        Me.cbo_descricao.TabIndex = 9
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_codPart.Location = New System.Drawing.Point(91, 218)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(70, 23)
        Me.txt_codPart.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(12, 221)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 17)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Cliente:"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomePart.Location = New System.Drawing.Point(167, 218)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.Size = New System.Drawing.Size(343, 23)
        Me.txt_nomePart.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(297, 154)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 17)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Prot.:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(12, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 17)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Dentista:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_alterar)
        Me.GroupBox3.Controls.Add(Me.btn_incluir)
        Me.GroupBox3.Location = New System.Drawing.Point(507, 305)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(210, 66)
        Me.GroupBox3.TabIndex = 58
        Me.GroupBox3.TabStop = False
        '
        'btn_alterar
        '
        Me.btn_alterar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_alterar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_alterar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_alterar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_alterar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_alterar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_alterar.Image = Global.RTecSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(106, 11)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(94, 50)
        Me.btn_alterar.TabIndex = 1
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = False
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
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.Location = New System.Drawing.Point(6, 11)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(94, 50)
        Me.btn_incluir.TabIndex = 0
        Me.btn_incluir.Text = "&Inclui"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_incluir.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-6, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(744, 42)
        Me.Panel1.TabIndex = 59
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(281, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'cbo_doutores
        '
        Me.cbo_doutores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_doutores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_doutores.FormattingEnabled = True
        Me.cbo_doutores.Location = New System.Drawing.Point(15, 177)
        Me.cbo_doutores.Name = "cbo_doutores"
        Me.cbo_doutores.Size = New System.Drawing.Size(249, 23)
        Me.cbo_doutores.TabIndex = 11
        '
        'msk_data
        '
        Me.msk_data.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.msk_data.Location = New System.Drawing.Point(15, 56)
        Me.msk_data.Name = "msk_data"
        Me.msk_data.Size = New System.Drawing.Size(110, 26)
        Me.msk_data.TabIndex = 35
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Image = Global.RTecSys.My.Resources.Resources.Financ_1
        Me.PictureBox2.Location = New System.Drawing.Point(526, 24)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(159, 153)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.Info
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Red
        Me.txt_total.Location = New System.Drawing.Point(587, 215)
        Me.txt_total.MaxLength = 14
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(98, 26)
        Me.txt_total.TabIndex = 25
        Me.txt_total.Text = "0,00"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_valor
        '
        Me.txt_valor.BackColor = System.Drawing.SystemColors.Window
        Me.txt_valor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_valor.Location = New System.Drawing.Point(155, 57)
        Me.txt_valor.MaxLength = 14
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.Size = New System.Drawing.Size(92, 26)
        Me.txt_valor.TabIndex = 7
        Me.txt_valor.Text = "0,00"
        Me.txt_valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(288, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 17)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Hora:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(152, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 17)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Valor R$:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(594, 195)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data:"
        '
        'grb_lancamentos
        '
        Me.grb_lancamentos.Controls.Add(Me.txt_hora)
        Me.grb_lancamentos.Controls.Add(Me.cbo_protetico)
        Me.grb_lancamentos.Controls.Add(Me.cbo_descricao)
        Me.grb_lancamentos.Controls.Add(Me.txt_codPart)
        Me.grb_lancamentos.Controls.Add(Me.Label7)
        Me.grb_lancamentos.Controls.Add(Me.txt_nomePart)
        Me.grb_lancamentos.Controls.Add(Me.Label10)
        Me.grb_lancamentos.Controls.Add(Me.Label6)
        Me.grb_lancamentos.Controls.Add(Me.cbo_doutores)
        Me.grb_lancamentos.Controls.Add(Me.msk_data)
        Me.grb_lancamentos.Controls.Add(Me.PictureBox2)
        Me.grb_lancamentos.Controls.Add(Me.txt_valor)
        Me.grb_lancamentos.Controls.Add(Me.txt_total)
        Me.grb_lancamentos.Controls.Add(Me.Label11)
        Me.grb_lancamentos.Controls.Add(Me.Label9)
        Me.grb_lancamentos.Controls.Add(Me.Label5)
        Me.grb_lancamentos.Controls.Add(Me.Label4)
        Me.grb_lancamentos.Controls.Add(Me.Label2)
        Me.grb_lancamentos.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.grb_lancamentos.Location = New System.Drawing.Point(11, 46)
        Me.grb_lancamentos.Name = "grb_lancamentos"
        Me.grb_lancamentos.Size = New System.Drawing.Size(706, 252)
        Me.grb_lancamentos.TabIndex = 56
        Me.grb_lancamentos.TabStop = False
        Me.grb_lancamentos.Text = "Lançamentos"
        '
        'Frm_LancaCxOrc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 383)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grb_lancamentos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_LancaCxOrc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lança Orçamento"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grb_lancamentos.ResumeLayout(False)
        Me.grb_lancamentos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents txt_hora As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbo_protetico As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_descricao As System.Windows.Forms.ComboBox
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents cbo_doutores As System.Windows.Forms.ComboBox
    Friend WithEvents msk_data As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents txt_valor As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grb_lancamentos As System.Windows.Forms.GroupBox
End Class
