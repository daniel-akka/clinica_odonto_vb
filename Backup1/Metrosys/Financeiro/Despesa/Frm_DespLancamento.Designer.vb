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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_DespLancamento))
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.msk_subconta = New System.Windows.Forms.MaskedTextBox
        Me.btn_incluir = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.msk_data = New System.Windows.Forms.MaskedTextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_descricao2 = New System.Windows.Forms.TextBox
        Me.txt_historico = New System.Windows.Forms.TextBox
        Me.lbl_tipoplanc = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_valor = New System.Windows.Forms.TextBox
        Me.txt_valor2 = New System.Windows.Forms.TextBox
        Me.cbo_loja = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbl_descricao = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_conta = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_alterar
        '
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_alterar.Location = New System.Drawing.Point(87, 12)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(75, 42)
        Me.btn_alterar.TabIndex = 12
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'msk_subconta
        '
        Me.msk_subconta.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.msk_subconta.Location = New System.Drawing.Point(73, 61)
        Me.msk_subconta.Mask = "999,9999"
        Me.msk_subconta.Name = "msk_subconta"
        Me.msk_subconta.Size = New System.Drawing.Size(68, 20)
        Me.msk_subconta.TabIndex = 3
        Me.msk_subconta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'btn_incluir
        '
        Me.btn_incluir.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_incluir.Location = New System.Drawing.Point(6, 12)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(75, 42)
        Me.btn_incluir.TabIndex = 11
        Me.btn_incluir.Text = "&Incluir"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 307)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(372, 60)
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
        Me.Label8.Location = New System.Drawing.Point(147, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "-"
        '
        'msk_data
        '
        Me.msk_data.Location = New System.Drawing.Point(73, 160)
        Me.msk_data.Mask = "00/00/0000"
        Me.msk_data.Name = "msk_data"
        Me.msk_data.Size = New System.Drawing.Size(79, 20)
        Me.msk_data.TabIndex = 11
        Me.msk_data.ValidatingType = GetType(Date)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_alterar)
        Me.GroupBox2.Controls.Add(Me.btn_incluir)
        Me.GroupBox2.Location = New System.Drawing.Point(386, 307)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(169, 60)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'txt_descricao2
        '
        Me.txt_descricao2.Location = New System.Drawing.Point(164, 60)
        Me.txt_descricao2.MaxLength = 30
        Me.txt_descricao2.Name = "txt_descricao2"
        Me.txt_descricao2.ReadOnly = True
        Me.txt_descricao2.Size = New System.Drawing.Size(308, 20)
        Me.txt_descricao2.TabIndex = 4
        '
        'txt_historico
        '
        Me.txt_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_historico.Location = New System.Drawing.Point(72, 94)
        Me.txt_historico.MaxLength = 30
        Me.txt_historico.Name = "txt_historico"
        Me.txt_historico.Size = New System.Drawing.Size(287, 20)
        Me.txt_historico.TabIndex = 5
        '
        'lbl_tipoplanc
        '
        Me.lbl_tipoplanc.AutoSize = True
        Me.lbl_tipoplanc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lbl_tipoplanc.ForeColor = System.Drawing.Color.Red
        Me.lbl_tipoplanc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_tipoplanc.Location = New System.Drawing.Point(73, 194)
        Me.lbl_tipoplanc.Name = "lbl_tipoplanc"
        Me.lbl_tipoplanc.Size = New System.Drawing.Size(28, 15)
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
        Me.GroupBox1.Location = New System.Drawing.Point(10, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(548, 220)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lançamentos"
        '
        'txt_valor
        '
        Me.txt_valor.Location = New System.Drawing.Point(73, 127)
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.Size = New System.Drawing.Size(81, 20)
        Me.txt_valor.TabIndex = 7
        Me.txt_valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_valor2
        '
        Me.txt_valor2.Location = New System.Drawing.Point(174, 127)
        Me.txt_valor2.MaxLength = 12
        Me.txt_valor2.Name = "txt_valor2"
        Me.txt_valor2.Size = New System.Drawing.Size(79, 20)
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
        Me.cbo_loja.Location = New System.Drawing.Point(72, 21)
        Me.cbo_loja.Name = "cbo_loja"
        Me.cbo_loja.Size = New System.Drawing.Size(114, 21)
        Me.cbo_loja.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Loja  :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(12, 195)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Tipo Lanc.:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(12, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Data :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(12, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Valor R$ :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(13, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Histórico  :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(12, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "SubConta:"
        '
        'lbl_descricao
        '
        Me.lbl_descricao.AutoSize = True
        Me.lbl_descricao.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_descricao.Location = New System.Drawing.Point(312, 27)
        Me.lbl_descricao.Name = "lbl_descricao"
        Me.lbl_descricao.Size = New System.Drawing.Size(55, 13)
        Me.lbl_descricao.TabIndex = 3
        Me.lbl_descricao.Text = "Descricao"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(303, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "-"
        '
        'txt_conta
        '
        Me.txt_conta.Location = New System.Drawing.Point(239, 22)
        Me.txt_conta.MaxLength = 3
        Me.txt_conta.Name = "txt_conta"
        Me.txt_conta.ReadOnly = True
        Me.txt_conta.Size = New System.Drawing.Size(60, 20)
        Me.txt_conta.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(199, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Conta:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(576, 67)
        Me.Panel1.TabIndex = 15
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(463, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(457, 44)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(66, 15)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox3.Location = New System.Drawing.Point(208, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(166, 54)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Frm_DespLancamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 382)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents msk_subconta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents msk_data As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_descricao2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_historico As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tipoplanc As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_descricao As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_conta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cbo_loja As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_valor2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_valor As System.Windows.Forms.TextBox
End Class
