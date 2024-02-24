<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MenuLancamentos
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_grupo = New System.Windows.Forms.ComboBox()
        Me.txt_qtdeRegistros = New System.Windows.Forms.TextBox()
        Me.msk_final = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.msk_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.txt_somaTotais = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_pesquisa = New System.Windows.Forms.Button()
        Me.lbl_intervalo = New System.Windows.Forms.Label()
        Me.grp_opcao = New System.Windows.Forms.GroupBox()
        Me.rdb_periodo = New System.Windows.Forms.RadioButton()
        Me.rdb_historico = New System.Windows.Forms.RadioButton()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.dtg_lancamentos = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbl_mensagem = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbo_empresa = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.grp_opcao.SuspendLayout()
        CType(Me.dtg_lancamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pesquisa:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbo_grupo)
        Me.GroupBox1.Controls.Add(Me.txt_qtdeRegistros)
        Me.GroupBox1.Controls.Add(Me.msk_final)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.msk_inicio)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_tipo)
        Me.GroupBox1.Controls.Add(Me.txt_somaTotais)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btn_pesquisa)
        Me.GroupBox1.Controls.Add(Me.lbl_intervalo)
        Me.GroupBox1.Controls.Add(Me.grp_opcao)
        Me.GroupBox1.Controls.Add(Me.txt_pesquisa)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(791, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Grupo:"
        '
        'cbo_grupo
        '
        Me.cbo_grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_grupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_grupo.FormattingEnabled = True
        Me.cbo_grupo.Location = New System.Drawing.Point(70, 51)
        Me.cbo_grupo.Name = "cbo_grupo"
        Me.cbo_grupo.Size = New System.Drawing.Size(209, 23)
        Me.cbo_grupo.TabIndex = 65
        '
        'txt_qtdeRegistros
        '
        Me.txt_qtdeRegistros.BackColor = System.Drawing.Color.Silver
        Me.txt_qtdeRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_qtdeRegistros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_qtdeRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtdeRegistros.ForeColor = System.Drawing.Color.Red
        Me.txt_qtdeRegistros.Location = New System.Drawing.Point(516, 55)
        Me.txt_qtdeRegistros.MaxLength = 16
        Me.txt_qtdeRegistros.Name = "txt_qtdeRegistros"
        Me.txt_qtdeRegistros.ReadOnly = True
        Me.txt_qtdeRegistros.Size = New System.Drawing.Size(82, 16)
        Me.txt_qtdeRegistros.TabIndex = 64
        Me.txt_qtdeRegistros.Text = "0"
        Me.txt_qtdeRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'msk_final
        '
        Me.msk_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.msk_final.Location = New System.Drawing.Point(176, 18)
        Me.msk_final.Name = "msk_final"
        Me.msk_final.Size = New System.Drawing.Size(87, 23)
        Me.msk_final.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(400, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 15)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Qtde. Registros:"
        '
        'msk_inicio
        '
        Me.msk_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.msk_inicio.Location = New System.Drawing.Point(63, 18)
        Me.msk_inicio.Name = "msk_inicio"
        Me.msk_inicio.Size = New System.Drawing.Size(87, 23)
        Me.msk_inicio.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(627, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 15)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Totais:"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"", "P", "R"})
        Me.cbo_tipo.Location = New System.Drawing.Point(729, 18)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(51, 24)
        Me.cbo_tipo.TabIndex = 7
        '
        'txt_somaTotais
        '
        Me.txt_somaTotais.BackColor = System.Drawing.SystemColors.Info
        Me.txt_somaTotais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_somaTotais.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_somaTotais.ForeColor = System.Drawing.Color.DarkBlue
        Me.txt_somaTotais.Location = New System.Drawing.Point(683, 51)
        Me.txt_somaTotais.MaxLength = 16
        Me.txt_somaTotais.Name = "txt_somaTotais"
        Me.txt_somaTotais.ReadOnly = True
        Me.txt_somaTotais.Size = New System.Drawing.Size(102, 24)
        Me.txt_somaTotais.TabIndex = 61
        Me.txt_somaTotais.Text = "0,00"
        Me.txt_somaTotais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(691, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tipo:"
        '
        'btn_pesquisa
        '
        Me.btn_pesquisa.Image = Global.RTecSys.My.Resources.Resources.Busca_16x16
        Me.btn_pesquisa.Location = New System.Drawing.Point(427, 15)
        Me.btn_pesquisa.Name = "btn_pesquisa"
        Me.btn_pesquisa.Size = New System.Drawing.Size(28, 27)
        Me.btn_pesquisa.TabIndex = 4
        Me.btn_pesquisa.UseVisualStyleBackColor = True
        '
        'lbl_intervalo
        '
        Me.lbl_intervalo.AutoSize = True
        Me.lbl_intervalo.Location = New System.Drawing.Point(156, 23)
        Me.lbl_intervalo.Name = "lbl_intervalo"
        Me.lbl_intervalo.Size = New System.Drawing.Size(14, 13)
        Me.lbl_intervalo.TabIndex = 4
        Me.lbl_intervalo.Text = "A"
        '
        'grp_opcao
        '
        Me.grp_opcao.BackColor = System.Drawing.Color.Transparent
        Me.grp_opcao.Controls.Add(Me.rdb_periodo)
        Me.grp_opcao.Controls.Add(Me.rdb_historico)
        Me.grp_opcao.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_opcao.Location = New System.Drawing.Point(492, 6)
        Me.grp_opcao.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.grp_opcao.Name = "grp_opcao"
        Me.grp_opcao.Size = New System.Drawing.Size(189, 38)
        Me.grp_opcao.TabIndex = 5
        Me.grp_opcao.TabStop = False
        '
        'rdb_periodo
        '
        Me.rdb_periodo.AutoSize = True
        Me.rdb_periodo.Location = New System.Drawing.Point(108, 12)
        Me.rdb_periodo.Name = "rdb_periodo"
        Me.rdb_periodo.Size = New System.Drawing.Size(75, 21)
        Me.rdb_periodo.TabIndex = 7
        Me.rdb_periodo.Text = "Periodo"
        Me.rdb_periodo.UseVisualStyleBackColor = True
        '
        'rdb_historico
        '
        Me.rdb_historico.AutoSize = True
        Me.rdb_historico.Checked = True
        Me.rdb_historico.Location = New System.Drawing.Point(12, 12)
        Me.rdb_historico.Name = "rdb_historico"
        Me.rdb_historico.Size = New System.Drawing.Size(81, 21)
        Me.rdb_historico.TabIndex = 6
        Me.rdb_historico.TabStop = True
        Me.rdb_historico.Text = "&Histórico"
        Me.rdb_historico.UseVisualStyleBackColor = True
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(63, 18)
        Me.txt_pesquisa.MaxLength = 30
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(358, 21)
        Me.txt_pesquisa.TabIndex = 1
        '
        'dtg_lancamentos
        '
        Me.dtg_lancamentos.AllowUserToAddRows = False
        Me.dtg_lancamentos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.dtg_lancamentos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_lancamentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_lancamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_lancamentos.Location = New System.Drawing.Point(13, 163)
        Me.dtg_lancamentos.Name = "dtg_lancamentos"
        Me.dtg_lancamentos.ReadOnly = True
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_lancamentos.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_lancamentos.Size = New System.Drawing.Size(791, 284)
        Me.dtg_lancamentos.TabIndex = 8
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 453)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(579, 59)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(12, 26)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(23, 15)
        Me.lbl_mensagem.TabIndex = 14
        Me.lbl_mensagem.Text = "    "
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_excluir)
        Me.GroupBox4.Controls.Add(Me.btn_alterar)
        Me.GroupBox4.Controls.Add(Me.btn_novo)
        Me.GroupBox4.Location = New System.Drawing.Point(597, 453)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(207, 62)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.RTecSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_excluir.Location = New System.Drawing.Point(137, 12)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(63, 45)
        Me.btn_excluir.TabIndex = 12
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.RTecSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(72, 12)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(62, 45)
        Me.btn_alterar.TabIndex = 11
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_novo
        '
        Me.btn_novo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_novo.Image = Global.RTecSys.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_novo.Location = New System.Drawing.Point(7, 12)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(62, 45)
        Me.btn_novo.TabIndex = 10
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-3, -3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(826, 42)
        Me.Panel1.TabIndex = 60
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(343, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 17)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Empresa:"
        '
        'cbo_empresa
        '
        Me.cbo_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_empresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_empresa.FormattingEnabled = True
        Me.cbo_empresa.Location = New System.Drawing.Point(94, 52)
        Me.cbo_empresa.Name = "cbo_empresa"
        Me.cbo_empresa.Size = New System.Drawing.Size(374, 24)
        Me.cbo_empresa.TabIndex = 65
        '
        'Frm_MenuLancamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 519)
        Me.Controls.Add(Me.cbo_empresa)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dtg_lancamentos)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_MenuLancamentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lançamento das Despesas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp_opcao.ResumeLayout(False)
        Me.grp_opcao.PerformLayout()
        CType(Me.dtg_lancamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents grp_opcao As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_periodo As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_historico As System.Windows.Forms.RadioButton
    Friend WithEvents dtg_lancamentos As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_intervalo As System.Windows.Forms.Label
    Friend WithEvents btn_pesquisa As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_somaTotais As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_qtdeRegistros As System.Windows.Forms.TextBox
    Friend WithEvents msk_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents msk_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_grupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbo_empresa As System.Windows.Forms.ComboBox
End Class
