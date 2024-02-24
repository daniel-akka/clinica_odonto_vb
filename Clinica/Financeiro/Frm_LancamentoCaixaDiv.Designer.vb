<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LancamentoCaixaDiv
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.cbo_descricao = New System.Windows.Forms.ComboBox()
        Me.txt_codPart = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_nomePart = New System.Windows.Forms.TextBox()
        Me.lbl_comiss = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbo_doutores = New System.Windows.Forms.ComboBox()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.msk_data = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txt_comiss = New System.Windows.Forms.TextBox()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.txt_valor = New System.Windows.Forms.TextBox()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.txt_grupo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grb_lancamentos = New System.Windows.Forms.GroupBox()
        Me.cbo_protetico = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbo_tipoPag = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbo_tpAtendimento = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.grb_lancamentos.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 328)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(684, 49)
        Me.GroupBox2.TabIndex = 57
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(12, 22)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = "    "
        '
        'cbo_descricao
        '
        Me.cbo_descricao.FormattingEnabled = True
        Me.cbo_descricao.Location = New System.Drawing.Point(15, 116)
        Me.cbo_descricao.Name = "cbo_descricao"
        Me.cbo_descricao.Size = New System.Drawing.Size(368, 27)
        Me.cbo_descricao.TabIndex = 56
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_codPart.Location = New System.Drawing.Point(91, 245)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(70, 23)
        Me.txt_codPart.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(12, 248)
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
        Me.txt_nomePart.Location = New System.Drawing.Point(167, 245)
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
        Me.btn_incluir.Location = New System.Drawing.Point(711, 333)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(88, 41)
        Me.btn_incluir.TabIndex = 0
        Me.btn_incluir.Text = "&Incluir"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_incluir.UseVisualStyleBackColor = False
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
        Me.PictureBox2.Location = New System.Drawing.Point(620, 18)
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
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.Info
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Red
        Me.txt_total.Location = New System.Drawing.Point(673, 242)
        Me.txt_total.MaxLength = 14
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(98, 26)
        Me.txt_total.TabIndex = 8
        Me.txt_total.Text = "0,00"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_valor
        '
        Me.txt_valor.BackColor = System.Drawing.SystemColors.Window
        Me.txt_valor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_valor.Location = New System.Drawing.Point(412, 59)
        Me.txt_valor.MaxLength = 14
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.Size = New System.Drawing.Size(81, 23)
        Me.txt_valor.TabIndex = 8
        Me.txt_valor.Text = "0,00"
        Me.txt_valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(311, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'txt_grupo
        '
        Me.txt_grupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_grupo.Location = New System.Drawing.Point(324, 59)
        Me.txt_grupo.MaxLength = 3
        Me.txt_grupo.Name = "txt_grupo"
        Me.txt_grupo.Size = New System.Drawing.Size(59, 23)
        Me.txt_grupo.TabIndex = 7
        Me.txt_grupo.Text = "888"
        Me.txt_grupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(409, 34)
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
        Me.Label5.Location = New System.Drawing.Point(680, 222)
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
        Me.Panel1.Location = New System.Drawing.Point(-6, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(824, 42)
        Me.Panel1.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(321, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Grupo:"
        '
        'grb_lancamentos
        '
        Me.grb_lancamentos.Controls.Add(Me.cbo_tpAtendimento)
        Me.grb_lancamentos.Controls.Add(Me.Label12)
        Me.grb_lancamentos.Controls.Add(Me.cbo_protetico)
        Me.grb_lancamentos.Controls.Add(Me.Label11)
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
        Me.grb_lancamentos.Location = New System.Drawing.Point(12, 46)
        Me.grb_lancamentos.Name = "grb_lancamentos"
        Me.grb_lancamentos.Size = New System.Drawing.Size(787, 274)
        Me.grb_lancamentos.TabIndex = 56
        Me.grb_lancamentos.TabStop = False
        Me.grb_lancamentos.Text = "Lançamentos"
        '
        'cbo_protetico
        '
        Me.cbo_protetico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_protetico.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.cbo_protetico.FormattingEnabled = True
        Me.cbo_protetico.Location = New System.Drawing.Point(91, 208)
        Me.cbo_protetico.Name = "cbo_protetico"
        Me.cbo_protetico.Size = New System.Drawing.Size(249, 23)
        Me.cbo_protetico.TabIndex = 58
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(12, 210)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 17)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "Prot.:"
        '
        'cbo_tipoPag
        '
        Me.cbo_tipoPag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipoPag.Font = New System.Drawing.Font("Times New Roman", 11.0!)
        Me.cbo_tipoPag.FormattingEnabled = True
        Me.cbo_tipoPag.Items.AddRange(New Object() {"DN", "CT", "CH"})
        Me.cbo_tipoPag.Location = New System.Drawing.Point(524, 57)
        Me.cbo_tipoPag.Name = "cbo_tipoPag"
        Me.cbo_tipoPag.Size = New System.Drawing.Size(67, 25)
        Me.cbo_tipoPag.TabIndex = 57
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(521, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 17)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Tp. Pag:"
        '
        'cbo_tpAtendimento
        '
        Me.cbo_tpAtendimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tpAtendimento.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.cbo_tpAtendimento.FormattingEnabled = True
        Me.cbo_tpAtendimento.Location = New System.Drawing.Point(412, 116)
        Me.cbo_tpAtendimento.Name = "cbo_tpAtendimento"
        Me.cbo_tpAtendimento.Size = New System.Drawing.Size(179, 23)
        Me.cbo_tpAtendimento.TabIndex = 60
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(409, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 17)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "Atendimento:"
        '
        'Frm_LancamentoCaixaDiv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 387)
        Me.Controls.Add(Me.btn_incluir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grb_lancamentos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_LancamentoCaixaDiv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lancamento Caixa Divisória"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grb_lancamentos.ResumeLayout(False)
        Me.grb_lancamentos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents cbo_descricao As System.Windows.Forms.ComboBox
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents lbl_comiss As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbo_doutores As System.Windows.Forms.ComboBox
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents msk_data As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_comiss As System.Windows.Forms.TextBox
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents txt_valor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents txt_grupo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grb_lancamentos As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_tipoPag As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbo_protetico As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbo_tpAtendimento As System.Windows.Forms.ComboBox
    Public WithEvents Label12 As System.Windows.Forms.Label
End Class
