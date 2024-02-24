<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DespLancamento
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
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.msk_subconta = New System.Windows.Forms.MaskedTextBox()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.msk_data = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_descricao2 = New System.Windows.Forms.TextBox()
        Me.txt_historico = New System.Windows.Forms.TextBox()
        Me.lbl_tipoplanc = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_valor = New System.Windows.Forms.TextBox()
        Me.txt_valor2 = New System.Windows.Forms.TextBox()
        Me.cbo_loja = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_descricao = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_conta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.RTecSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_alterar.Location = New System.Drawing.Point(87, 11)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(75, 45)
        Me.btn_alterar.TabIndex = 12
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'msk_subconta
        '
        Me.msk_subconta.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.msk_subconta.Location = New System.Drawing.Point(100, 86)
        Me.msk_subconta.Mask = "999,9999"
        Me.msk_subconta.Name = "msk_subconta"
        Me.msk_subconta.Size = New System.Drawing.Size(68, 23)
        Me.msk_subconta.TabIndex = 3
        Me.msk_subconta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'btn_incluir
        '
        Me.btn_incluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_incluir.Image = Global.RTecSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_incluir.Location = New System.Drawing.Point(6, 11)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(75, 45)
        Me.btn_incluir.TabIndex = 11
        Me.btn_incluir.Text = "&Incluir"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 300)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(464, 60)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_mensagem.Location = New System.Drawing.Point(18, 31)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem.TabIndex = 15
        Me.lbl_mensagem.Text = "    "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(174, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 17)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "-"
        '
        'msk_data
        '
        Me.msk_data.Location = New System.Drawing.Point(100, 185)
        Me.msk_data.Mask = "00/00/0000"
        Me.msk_data.Name = "msk_data"
        Me.msk_data.Size = New System.Drawing.Size(79, 23)
        Me.msk_data.TabIndex = 11
        Me.msk_data.ValidatingType = GetType(Date)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_alterar)
        Me.GroupBox2.Controls.Add(Me.btn_incluir)
        Me.GroupBox2.Location = New System.Drawing.Point(478, 300)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(169, 60)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'txt_descricao2
        '
        Me.txt_descricao2.BackColor = System.Drawing.SystemColors.Info
        Me.txt_descricao2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descricao2.Location = New System.Drawing.Point(191, 85)
        Me.txt_descricao2.MaxLength = 30
        Me.txt_descricao2.Name = "txt_descricao2"
        Me.txt_descricao2.ReadOnly = True
        Me.txt_descricao2.Size = New System.Drawing.Size(373, 23)
        Me.txt_descricao2.TabIndex = 4
        '
        'txt_historico
        '
        Me.txt_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_historico.Location = New System.Drawing.Point(99, 119)
        Me.txt_historico.MaxLength = 30
        Me.txt_historico.Name = "txt_historico"
        Me.txt_historico.Size = New System.Drawing.Size(465, 23)
        Me.txt_historico.TabIndex = 5
        '
        'lbl_tipoplanc
        '
        Me.lbl_tipoplanc.AutoSize = True
        Me.lbl_tipoplanc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_tipoplanc.ForeColor = System.Drawing.Color.Red
        Me.lbl_tipoplanc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_tipoplanc.Location = New System.Drawing.Point(97, 220)
        Me.lbl_tipoplanc.Name = "lbl_tipoplanc"
        Me.lbl_tipoplanc.Size = New System.Drawing.Size(31, 15)
        Me.lbl_tipoplanc.TabIndex = 9
        Me.lbl_tipoplanc.Text = "P-R"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_valor)
        Me.GroupBox1.Controls.Add(Me.txt_valor2)
        Me.GroupBox1.Controls.Add(Me.cbo_loja)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.msk_subconta)
        Me.GroupBox1.Controls.Add(Me.txt_descricao2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.msk_data)
        Me.GroupBox1.Controls.Add(Me.txt_historico)
        Me.GroupBox1.Controls.Add(Me.lbl_tipoplanc)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lbl_descricao)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_conta)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 248)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lançamentos"
        '
        'txt_valor
        '
        Me.txt_valor.Location = New System.Drawing.Point(100, 152)
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.Size = New System.Drawing.Size(81, 23)
        Me.txt_valor.TabIndex = 7
        Me.txt_valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_valor2
        '
        Me.txt_valor2.Location = New System.Drawing.Point(201, 152)
        Me.txt_valor2.MaxLength = 12
        Me.txt_valor2.Name = "txt_valor2"
        Me.txt_valor2.Size = New System.Drawing.Size(79, 23)
        Me.txt_valor2.TabIndex = 9
        Me.txt_valor2.Text = "0,00"
        Me.txt_valor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_valor2.Visible = False
        '
        'cbo_loja
        '
        Me.cbo_loja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_loja.FormattingEnabled = True
        Me.cbo_loja.Items.AddRange(New Object() {"001 - Matriz"})
        Me.cbo_loja.Location = New System.Drawing.Point(99, 22)
        Me.cbo_loja.Name = "cbo_loja"
        Me.cbo_loja.Size = New System.Drawing.Size(381, 24)
        Me.cbo_loja.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 17)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Loja  :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(12, 220)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 17)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Tipo Lanc.:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(12, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 17)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Data :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(12, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 17)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Valor R$ :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(13, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Histórico  :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(12, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "SubConta:"
        '
        'lbl_descricao
        '
        Me.lbl_descricao.AutoSize = True
        Me.lbl_descricao.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_descricao.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_descricao.Location = New System.Drawing.Point(188, 57)
        Me.lbl_descricao.Name = "lbl_descricao"
        Me.lbl_descricao.Size = New System.Drawing.Size(80, 17)
        Me.lbl_descricao.TabIndex = 3
        Me.lbl_descricao.Text = "Descricao"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(169, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "-"
        '
        'txt_conta
        '
        Me.txt_conta.BackColor = System.Drawing.SystemColors.Info
        Me.txt_conta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_conta.Location = New System.Drawing.Point(100, 54)
        Me.txt_conta.MaxLength = 3
        Me.txt_conta.Name = "txt_conta"
        Me.txt_conta.ReadOnly = True
        Me.txt_conta.Size = New System.Drawing.Size(60, 23)
        Me.txt_conta.TabIndex = 2
        Me.txt_conta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Conta:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-4, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(670, 42)
        Me.Panel1.TabIndex = 65
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(257, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Frm_DespLancamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 372)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_DespLancamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lançamento de Despesas"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents msk_data As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_historico As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tipoplanc As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_loja As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_valor2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_valor As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Public WithEvents lbl_descricao As System.Windows.Forms.Label
    Public WithEvents msk_subconta As System.Windows.Forms.MaskedTextBox
    Public WithEvents txt_descricao2 As System.Windows.Forms.TextBox
    Public WithEvents txt_conta As System.Windows.Forms.TextBox
End Class
