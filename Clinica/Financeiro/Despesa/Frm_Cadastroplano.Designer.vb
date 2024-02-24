<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cadastroplano
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtg_planodecontas = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_conta = New System.Windows.Forms.TextBox()
        Me.msk_subconta = New System.Windows.Forms.MaskedTextBox()
        Me.txt_descricao2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_descricao = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_local = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_pesquisa = New System.Windows.Forms.Button()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rdb_descricao = New System.Windows.Forms.RadioButton()
        Me.rdb_subconta = New System.Windows.Forms.RadioButton()
        Me.rdb_conta = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        CType(Me.dtg_planodecontas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_planodecontas
        '
        Me.dtg_planodecontas.AllowUserToAddRows = False
        Me.dtg_planodecontas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.dtg_planodecontas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_planodecontas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_planodecontas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_planodecontas.Location = New System.Drawing.Point(12, 107)
        Me.dtg_planodecontas.Name = "dtg_planodecontas"
        Me.dtg_planodecontas.ReadOnly = True
        Me.dtg_planodecontas.Size = New System.Drawing.Size(638, 283)
        Me.dtg_planodecontas.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_excluir)
        Me.GroupBox1.Controls.Add(Me.btn_alterar)
        Me.GroupBox1.Controls.Add(Me.btn_incluir)
        Me.GroupBox1.Location = New System.Drawing.Point(662, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(98, 185)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.RTecSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_excluir.Location = New System.Drawing.Point(14, 123)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(75, 47)
        Me.btn_excluir.TabIndex = 19
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.RTecSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(14, 70)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(75, 47)
        Me.btn_alterar.TabIndex = 18
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_incluir
        '
        Me.btn_incluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_incluir.Image = Global.RTecSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.Location = New System.Drawing.Point(14, 17)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(75, 47)
        Me.btn_incluir.TabIndex = 17
        Me.btn_incluir.Text = "&Incluir"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_conta)
        Me.GroupBox2.Controls.Add(Me.msk_subconta)
        Me.GroupBox2.Controls.Add(Me.txt_descricao2)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cbo_tipo)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txt_descricao)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbo_local)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 396)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(640, 134)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cadastro"
        '
        'txt_conta
        '
        Me.txt_conta.Location = New System.Drawing.Point(78, 65)
        Me.txt_conta.MaxLength = 3
        Me.txt_conta.Name = "txt_conta"
        Me.txt_conta.Size = New System.Drawing.Size(56, 21)
        Me.txt_conta.TabIndex = 12
        '
        'msk_subconta
        '
        Me.msk_subconta.Culture = New System.Globalization.CultureInfo("")
        Me.msk_subconta.Location = New System.Drawing.Point(78, 98)
        Me.msk_subconta.Mask = "999.9999"
        Me.msk_subconta.Name = "msk_subconta"
        Me.msk_subconta.Size = New System.Drawing.Size(71, 21)
        Me.msk_subconta.TabIndex = 13
        Me.msk_subconta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txt_descricao2
        '
        Me.txt_descricao2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_descricao2.Location = New System.Drawing.Point(299, 98)
        Me.txt_descricao2.MaxLength = 30
        Me.txt_descricao2.Name = "txt_descricao2"
        Me.txt_descricao2.Size = New System.Drawing.Size(319, 21)
        Me.txt_descricao2.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(183, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 15)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Descrição2:"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"G - Grupo", "P - Pagamento", "R - Recebimento"})
        Me.cbo_tipo.Location = New System.Drawing.Point(480, 21)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(138, 23)
        Me.cbo_tipo.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(406, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 15)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Tipo Conta:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "SubConta:"
        '
        'txt_descricao
        '
        Me.txt_descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_descricao.Location = New System.Drawing.Point(299, 66)
        Me.txt_descricao.MaxLength = 30
        Me.txt_descricao.Name = "txt_descricao"
        Me.txt_descricao.Size = New System.Drawing.Size(319, 21)
        Me.txt_descricao.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(183, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Descrição:"
        '
        'cbo_local
        '
        Me.cbo_local.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_local.FormattingEnabled = True
        Me.cbo_local.Items.AddRange(New Object() {"001 - Matriz"})
        Me.cbo_local.Location = New System.Drawing.Point(78, 23)
        Me.cbo_local.Name = "cbo_local"
        Me.cbo_local.Size = New System.Drawing.Size(310, 23)
        Me.cbo_local.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Conta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Local:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 544)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(640, 41)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(10, 16)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(19, 15)
        Me.lbl_mensagem.TabIndex = 22
        Me.lbl_mensagem.Text = "   "
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_pesquisa)
        Me.GroupBox4.Controls.Add(Me.txt_pesquisa)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(415, 53)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'btn_pesquisa
        '
        Me.btn_pesquisa.Image = Global.RTecSys.My.Resources.Resources.Busca_16x161
        Me.btn_pesquisa.Location = New System.Drawing.Point(369, 14)
        Me.btn_pesquisa.Name = "btn_pesquisa"
        Me.btn_pesquisa.Size = New System.Drawing.Size(33, 29)
        Me.btn_pesquisa.TabIndex = 2
        Me.btn_pesquisa.UseVisualStyleBackColor = True
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(60, 16)
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(300, 23)
        Me.txt_pesquisa.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Pesquisa:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rdb_descricao)
        Me.GroupBox5.Controls.Add(Me.rdb_subconta)
        Me.GroupBox5.Controls.Add(Me.rdb_conta)
        Me.GroupBox5.Location = New System.Drawing.Point(433, 47)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(326, 53)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'rdb_descricao
        '
        Me.rdb_descricao.AutoSize = True
        Me.rdb_descricao.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_descricao.Location = New System.Drawing.Point(196, 20)
        Me.rdb_descricao.Name = "rdb_descricao"
        Me.rdb_descricao.Size = New System.Drawing.Size(89, 21)
        Me.rdb_descricao.TabIndex = 6
        Me.rdb_descricao.TabStop = True
        Me.rdb_descricao.Text = "&Descrição"
        Me.rdb_descricao.UseVisualStyleBackColor = True
        '
        'rdb_subconta
        '
        Me.rdb_subconta.AutoSize = True
        Me.rdb_subconta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_subconta.Location = New System.Drawing.Point(91, 20)
        Me.rdb_subconta.Name = "rdb_subconta"
        Me.rdb_subconta.Size = New System.Drawing.Size(88, 21)
        Me.rdb_subconta.TabIndex = 5
        Me.rdb_subconta.TabStop = True
        Me.rdb_subconta.Text = "&SubConta"
        Me.rdb_subconta.UseVisualStyleBackColor = True
        '
        'rdb_conta
        '
        Me.rdb_conta.AutoSize = True
        Me.rdb_conta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_conta.Location = New System.Drawing.Point(11, 20)
        Me.rdb_conta.Name = "rdb_conta"
        Me.rdb_conta.Size = New System.Drawing.Size(63, 21)
        Me.rdb_conta.TabIndex = 4
        Me.rdb_conta.TabStop = True
        Me.rdb_conta.Text = "&Conta"
        Me.rdb_conta.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-5, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(778, 42)
        Me.Panel1.TabIndex = 66
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(315, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Frm_Cadastroplano
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 595)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtg_planodecontas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_Cadastroplano"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção Plano de Contas"
        CType(Me.dtg_planodecontas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtg_planodecontas As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_subconta As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_conta As System.Windows.Forms.RadioButton
    Friend WithEvents btn_pesquisa As System.Windows.Forms.Button
    Friend WithEvents rdb_descricao As System.Windows.Forms.RadioButton
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_descricao As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_local As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_descricao2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents msk_subconta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_conta As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
End Class
