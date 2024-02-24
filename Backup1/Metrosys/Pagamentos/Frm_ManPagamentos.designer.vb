<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManPagamentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManPagamentos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.f_juros = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtg_documentos = New System.Windows.Forms.DataGridView
        Me.f_geno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.p_portad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_sit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_banco = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_duplic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_emiss = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_vencto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DIAS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_documento = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txt_totais = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cbo_tipo = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.msk_fim = New System.Windows.Forms.MaskedTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbo_loja = New System.Windows.Forms.ComboBox
        Me.Msk_inicio = New System.Windows.Forms.MaskedTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.btn_incluir = New System.Windows.Forms.Button
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.btn_outros = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(284, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(218, 63)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'f_juros
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.f_juros.DefaultCellStyle = DataGridViewCellStyle1
        Me.f_juros.HeaderText = "JUROS"
        Me.f_juros.Name = "f_juros"
        Me.f_juros.ReadOnly = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label5.Font = New System.Drawing.Font("Wide Latin", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(602, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(201, 27)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "MetroSys"
        '
        'dtg_documentos
        '
        Me.dtg_documentos.AllowUserToAddRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumAquamarine
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_documentos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_documentos.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_documentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_documentos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_documentos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_documentos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_documentos.ColumnHeadersHeight = 25
        Me.dtg_documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_documentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.f_geno, Me.p_portad, Me.f_tipo, Me.f_sit, Me.f_banco, Me.f_duplic, Me.f_emiss, Me.f_vencto, Me.f_valor, Me.f_juros, Me.DIAS})
        Me.dtg_documentos.Location = New System.Drawing.Point(24, 163)
        Me.dtg_documentos.MultiSelect = False
        Me.dtg_documentos.Name = "dtg_documentos"
        Me.dtg_documentos.ReadOnly = True
        Me.dtg_documentos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_documentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_documentos.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dtg_documentos.Size = New System.Drawing.Size(667, 301)
        Me.dtg_documentos.TabIndex = 25
        '
        'f_geno
        '
        Me.f_geno.HeaderText = "LOJA"
        Me.f_geno.MaxInputLength = 8
        Me.f_geno.Name = "f_geno"
        Me.f_geno.ReadOnly = True
        Me.f_geno.Width = 50
        '
        'p_portad
        '
        Me.p_portad.HeaderText = "PORTADOR"
        Me.p_portad.Name = "p_portad"
        Me.p_portad.ReadOnly = True
        Me.p_portad.Width = 230
        '
        'f_tipo
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_tipo.DefaultCellStyle = DataGridViewCellStyle4
        Me.f_tipo.HeaderText = "TIPO"
        Me.f_tipo.Name = "f_tipo"
        Me.f_tipo.ReadOnly = True
        Me.f_tipo.Width = 50
        '
        'f_sit
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_sit.DefaultCellStyle = DataGridViewCellStyle5
        Me.f_sit.HeaderText = "SIT"
        Me.f_sit.Name = "f_sit"
        Me.f_sit.ReadOnly = True
        Me.f_sit.Width = 40
        '
        'f_banco
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_banco.DefaultCellStyle = DataGridViewCellStyle6
        Me.f_banco.HeaderText = "BANCO"
        Me.f_banco.Name = "f_banco"
        Me.f_banco.ReadOnly = True
        Me.f_banco.Width = 53
        '
        'f_duplic
        '
        Me.f_duplic.HeaderText = "DOCUMENTO"
        Me.f_duplic.Name = "f_duplic"
        Me.f_duplic.ReadOnly = True
        Me.f_duplic.Width = 110
        '
        'f_emiss
        '
        Me.f_emiss.HeaderText = "EMISSAO"
        Me.f_emiss.Name = "f_emiss"
        Me.f_emiss.ReadOnly = True
        Me.f_emiss.Width = 90
        '
        'f_vencto
        '
        Me.f_vencto.HeaderText = "VENCTO"
        Me.f_vencto.Name = "f_vencto"
        Me.f_vencto.ReadOnly = True
        Me.f_vencto.Width = 90
        '
        'f_valor
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.f_valor.DefaultCellStyle = DataGridViewCellStyle7
        Me.f_valor.HeaderText = "VALOR R$"
        Me.f_valor.Name = "f_valor"
        Me.f_valor.ReadOnly = True
        '
        'DIAS
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DIAS.DefaultCellStyle = DataGridViewCellStyle8
        Me.DIAS.HeaderText = "DIAS"
        Me.DIAS.Name = "DIAS"
        Me.DIAS.ReadOnly = True
        Me.DIAS.Width = 70
        '
        'txt_documento
        '
        Me.txt_documento.Location = New System.Drawing.Point(401, 47)
        Me.txt_documento.MaxLength = 9
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.Size = New System.Drawing.Size(100, 20)
        Me.txt_documento.TabIndex = 5
        Me.txt_documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-2, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(818, 82)
        Me.Panel1.TabIndex = 24
        '
        'txt_totais
        '
        Me.txt_totais.Enabled = False
        Me.txt_totais.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totais.ForeColor = System.Drawing.Color.Red
        Me.txt_totais.Location = New System.Drawing.Point(6, 21)
        Me.txt_totais.MaxLength = 16
        Me.txt_totais.Name = "txt_totais"
        Me.txt_totais.Size = New System.Drawing.Size(112, 23)
        Me.txt_totais.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(332, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Documento:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_totais)
        Me.GroupBox4.Location = New System.Drawing.Point(644, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(124, 54)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Totais R$"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"Vencidas", "Quitadas", "Devolvidas", "Estornadas", "Em Aberto", "Documento"})
        Me.cbo_tipo.Location = New System.Drawing.Point(369, 18)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(117, 21)
        Me.cbo_tipo.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(332, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Tipo:"
        '
        'msk_fim
        '
        Me.msk_fim.Location = New System.Drawing.Point(207, 47)
        Me.msk_fim.Mask = "00/00/0000"
        Me.msk_fim.Name = "msk_fim"
        Me.msk_fim.Size = New System.Drawing.Size(107, 20)
        Me.msk_fim.TabIndex = 4
        Me.msk_fim.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Periodo:"
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = Global.MetroSys.My.Resources.Resources.Busca_16x16
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.Location = New System.Drawing.Point(511, 34)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(71, 33)
        Me.btn_buscar.TabIndex = 6
        Me.btn_buscar.Text = "&Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Loja:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_documento)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.btn_buscar)
        Me.GroupBox3.Controls.Add(Me.cbo_tipo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.msk_fim)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.cbo_loja)
        Me.GroupBox3.Controls.Add(Me.Msk_inicio)
        Me.GroupBox3.Location = New System.Drawing.Point(24, 84)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(777, 73)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(175, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "A"
        '
        'cbo_loja
        '
        Me.cbo_loja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_loja.FormattingEnabled = True
        Me.cbo_loja.Location = New System.Drawing.Point(58, 18)
        Me.cbo_loja.Name = "cbo_loja"
        Me.cbo_loja.Size = New System.Drawing.Size(256, 21)
        Me.cbo_loja.TabIndex = 1
        '
        'Msk_inicio
        '
        Me.Msk_inicio.Location = New System.Drawing.Point(58, 47)
        Me.Msk_inicio.Mask = "00/00/0000"
        Me.Msk_inicio.Name = "Msk_inicio"
        Me.Msk_inicio.Size = New System.Drawing.Size(100, 20)
        Me.Msk_inicio.TabIndex = 3
        Me.Msk_inicio.ValidatingType = GetType(Date)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 472)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(777, 53)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Location = New System.Drawing.Point(13, 27)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(16, 13)
        Me.lbl_mensagem.TabIndex = 13
        Me.lbl_mensagem.Text = "   "
        '
        'btn_incluir
        '
        Me.btn_incluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_incluir.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.Location = New System.Drawing.Point(8, 13)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(83, 44)
        Me.btn_incluir.TabIndex = 9
        Me.btn_incluir.Text = "Incluir"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(10, 63)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(83, 38)
        Me.btn_alterar.TabIndex = 10
        Me.btn_alterar.Text = "Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_outros
        '
        Me.btn_outros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_outros.Image = Global.MetroSys.My.Resources.Resources.OutrasOpcoes
        Me.btn_outros.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_outros.Location = New System.Drawing.Point(10, 107)
        Me.btn_outros.Name = "btn_outros"
        Me.btn_outros.Size = New System.Drawing.Size(83, 38)
        Me.btn_outros.TabIndex = 11
        Me.btn_outros.Text = "Outros"
        Me.btn_outros.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_outros.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_incluir)
        Me.GroupBox2.Controls.Add(Me.btn_alterar)
        Me.GroupBox2.Controls.Add(Me.btn_outros)
        Me.GroupBox2.Location = New System.Drawing.Point(702, 163)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(99, 151)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        '
        'Frm_ManPagamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 533)
        Me.Controls.Add(Me.dtg_documentos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ManPagamentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção em Cantas a Pagar"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_documentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents f_juros As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtg_documentos As System.Windows.Forms.DataGridView
    Friend WithEvents f_geno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_portad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_sit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_duplic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_emiss As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_vencto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_totais As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents msk_fim As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_loja As System.Windows.Forms.ComboBox
    Friend WithEvents Msk_inicio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_outros As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
