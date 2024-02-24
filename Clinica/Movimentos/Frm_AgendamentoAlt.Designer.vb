<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AgendamentoAlt
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_informacao = New System.Windows.Forms.ComboBox()
        Me.cbo_doutores = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_agendamento = New System.Windows.Forms.DateTimePicker()
        Me.txt_orcamento = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_pedido = New System.Windows.Forms.Label()
        Me.rdb_noite = New System.Windows.Forms.RadioButton()
        Me.rdb_tarde = New System.Windows.Forms.RadioButton()
        Me.rdb_manha = New System.Windows.Forms.RadioButton()
        Me.grp_turno = New System.Windows.Forms.GroupBox()
        Me.btn_finalizar = New System.Windows.Forms.Button()
        Me.txt_nomePart = New System.Windows.Forms.TextBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.txt_operador = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo_local = New System.Windows.Forms.ComboBox()
        Me.txt_codpart = New System.Windows.Forms.TextBox()
        Me.grp_pedido = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grp_turno.SuspendLayout()
        Me.grp_pedido.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(225, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(396, 35)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Agendamento de Atendimento"
        '
        'cbo_informacao
        '
        Me.cbo_informacao.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_informacao.FormattingEnabled = True
        Me.cbo_informacao.Location = New System.Drawing.Point(17, 160)
        Me.cbo_informacao.Name = "cbo_informacao"
        Me.cbo_informacao.Size = New System.Drawing.Size(517, 25)
        Me.cbo_informacao.TabIndex = 68
        '
        'cbo_doutores
        '
        Me.cbo_doutores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_doutores.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_doutores.FormattingEnabled = True
        Me.cbo_doutores.Location = New System.Drawing.Point(483, 90)
        Me.cbo_doutores.Name = "cbo_doutores"
        Me.cbo_doutores.Size = New System.Drawing.Size(241, 26)
        Me.cbo_doutores.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Informação:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(480, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 17)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Dentista:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Cliente:"
        '
        'dtp_agendamento
        '
        Me.dtp_agendamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_agendamento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_agendamento.Location = New System.Drawing.Point(527, 36)
        Me.dtp_agendamento.Name = "dtp_agendamento"
        Me.dtp_agendamento.Size = New System.Drawing.Size(101, 23)
        Me.dtp_agendamento.TabIndex = 3
        '
        'txt_orcamento
        '
        Me.txt_orcamento.BackColor = System.Drawing.SystemColors.Info
        Me.txt_orcamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_orcamento.Location = New System.Drawing.Point(387, 36)
        Me.txt_orcamento.MaxLength = 8
        Me.txt_orcamento.Name = "txt_orcamento"
        Me.txt_orcamento.ReadOnly = True
        Me.txt_orcamento.Size = New System.Drawing.Size(101, 21)
        Me.txt_orcamento.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(524, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 17)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Data:"
        '
        'lbl_pedido
        '
        Me.lbl_pedido.AutoSize = True
        Me.lbl_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pedido.Location = New System.Drawing.Point(384, 14)
        Me.lbl_pedido.Name = "lbl_pedido"
        Me.lbl_pedido.Size = New System.Drawing.Size(100, 17)
        Me.lbl_pedido.TabIndex = 32
        Me.lbl_pedido.Text = "Agendamento:"
        '
        'rdb_noite
        '
        Me.rdb_noite.AutoSize = True
        Me.rdb_noite.Location = New System.Drawing.Point(151, 21)
        Me.rdb_noite.Name = "rdb_noite"
        Me.rdb_noite.Size = New System.Drawing.Size(59, 21)
        Me.rdb_noite.TabIndex = 0
        Me.rdb_noite.Text = "Noite"
        Me.rdb_noite.UseVisualStyleBackColor = True
        '
        'rdb_tarde
        '
        Me.rdb_tarde.AutoSize = True
        Me.rdb_tarde.Location = New System.Drawing.Point(81, 22)
        Me.rdb_tarde.Name = "rdb_tarde"
        Me.rdb_tarde.Size = New System.Drawing.Size(64, 21)
        Me.rdb_tarde.TabIndex = 0
        Me.rdb_tarde.Text = "Tarde"
        Me.rdb_tarde.UseVisualStyleBackColor = True
        '
        'rdb_manha
        '
        Me.rdb_manha.AutoSize = True
        Me.rdb_manha.Checked = True
        Me.rdb_manha.Location = New System.Drawing.Point(6, 21)
        Me.rdb_manha.Name = "rdb_manha"
        Me.rdb_manha.Size = New System.Drawing.Size(69, 21)
        Me.rdb_manha.TabIndex = 0
        Me.rdb_manha.TabStop = True
        Me.rdb_manha.Text = "Manhã"
        Me.rdb_manha.UseVisualStyleBackColor = True
        '
        'grp_turno
        '
        Me.grp_turno.Controls.Add(Me.rdb_noite)
        Me.grp_turno.Controls.Add(Me.rdb_tarde)
        Me.grp_turno.Controls.Add(Me.rdb_manha)
        Me.grp_turno.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_turno.Location = New System.Drawing.Point(650, 14)
        Me.grp_turno.Name = "grp_turno"
        Me.grp_turno.Size = New System.Drawing.Size(214, 50)
        Me.grp_turno.TabIndex = 69
        Me.grp_turno.TabStop = False
        Me.grp_turno.Text = "Turno: "
        '
        'btn_finalizar
        '
        Me.btn_finalizar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_finalizar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_finalizar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_finalizar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_finalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_finalizar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_finalizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_finalizar.Image = Global.RTecSys.My.Resources.Resources.Info
        Me.btn_finalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_finalizar.Location = New System.Drawing.Point(622, 140)
        Me.btn_finalizar.Name = "btn_finalizar"
        Me.btn_finalizar.Size = New System.Drawing.Size(103, 50)
        Me.btn_finalizar.TabIndex = 100
        Me.btn_finalizar.Text = "&Finalizar"
        Me.btn_finalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_finalizar.UseVisualStyleBackColor = False
        '
        'txt_nomePart
        '
        Me.txt_nomePart.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomePart.Location = New System.Drawing.Point(93, 96)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(370, 22)
        Me.txt_nomePart.TabIndex = 5
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(15, 21)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(24, 16)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = ".   "
        '
        'txt_operador
        '
        Me.txt_operador.BackColor = System.Drawing.SystemColors.Info
        Me.txt_operador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_operador.ForeColor = System.Drawing.Color.Red
        Me.txt_operador.Location = New System.Drawing.Point(759, 26)
        Me.txt_operador.MaxLength = 10
        Me.txt_operador.Name = "txt_operador"
        Me.txt_operador.ReadOnly = True
        Me.txt_operador.Size = New System.Drawing.Size(130, 21)
        Me.txt_operador.TabIndex = 49
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(722, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 17)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Op.:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 17)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Clínica :"
        '
        'cbo_local
        '
        Me.cbo_local.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_local.DropDownWidth = 150
        Me.cbo_local.Enabled = False
        Me.cbo_local.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_local.FormattingEnabled = True
        Me.cbo_local.Items.AddRange(New Object() {"01", "02", "03", "04", "05"})
        Me.cbo_local.Location = New System.Drawing.Point(17, 34)
        Me.cbo_local.Name = "cbo_local"
        Me.cbo_local.Size = New System.Drawing.Size(338, 24)
        Me.cbo_local.TabIndex = 1
        '
        'txt_codpart
        '
        Me.txt_codpart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codpart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codpart.Location = New System.Drawing.Point(17, 96)
        Me.txt_codpart.MaxLength = 6
        Me.txt_codpart.Name = "txt_codpart"
        Me.txt_codpart.Size = New System.Drawing.Size(70, 22)
        Me.txt_codpart.TabIndex = 4
        '
        'grp_pedido
        '
        Me.grp_pedido.Controls.Add(Me.grp_turno)
        Me.grp_pedido.Controls.Add(Me.cbo_informacao)
        Me.grp_pedido.Controls.Add(Me.cbo_doutores)
        Me.grp_pedido.Controls.Add(Me.btn_finalizar)
        Me.grp_pedido.Controls.Add(Me.Label1)
        Me.grp_pedido.Controls.Add(Me.Label4)
        Me.grp_pedido.Controls.Add(Me.Label9)
        Me.grp_pedido.Controls.Add(Me.cbo_local)
        Me.grp_pedido.Controls.Add(Me.txt_codpart)
        Me.grp_pedido.Controls.Add(Me.txt_nomePart)
        Me.grp_pedido.Controls.Add(Me.Label3)
        Me.grp_pedido.Controls.Add(Me.dtp_agendamento)
        Me.grp_pedido.Controls.Add(Me.txt_orcamento)
        Me.grp_pedido.Controls.Add(Me.Label2)
        Me.grp_pedido.Controls.Add(Me.lbl_pedido)
        Me.grp_pedido.Location = New System.Drawing.Point(12, 51)
        Me.grp_pedido.Name = "grp_pedido"
        Me.grp_pedido.Size = New System.Drawing.Size(877, 215)
        Me.grp_pedido.TabIndex = 50
        Me.grp_pedido.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 272)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(878, 49)
        Me.GroupBox2.TabIndex = 51
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'Frm_AgendamentoAlt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 334)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_operador)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.grp_pedido)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_AgendamentoAlt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agendamento ALTERAÇÃO!"
        Me.grp_turno.ResumeLayout(False)
        Me.grp_turno.PerformLayout()
        Me.grp_pedido.ResumeLayout(False)
        Me.grp_pedido.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_informacao As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_doutores As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents dtp_agendamento As System.Windows.Forms.DateTimePicker
    Public WithEvents txt_orcamento As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_pedido As System.Windows.Forms.Label
    Friend WithEvents rdb_noite As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_tarde As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_manha As System.Windows.Forms.RadioButton
    Friend WithEvents grp_turno As System.Windows.Forms.GroupBox
    Public WithEvents btn_finalizar As System.Windows.Forms.Button
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Public WithEvents txt_operador As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents cbo_local As System.Windows.Forms.ComboBox
    Public WithEvents txt_codpart As System.Windows.Forms.TextBox
    Friend WithEvents grp_pedido As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
