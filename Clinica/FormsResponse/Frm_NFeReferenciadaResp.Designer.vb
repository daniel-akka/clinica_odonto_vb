<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_NFeReferenciadaResp
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_deletar = New System.Windows.Forms.Button()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.grb_cp = New System.Windows.Forms.GroupBox()
        Me.txt_coo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_ecf = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_modelo = New System.Windows.Forms.TextBox()
        Me.txt_aamm = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_TipoDoc = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbo_uf = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_numeroNFe = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_serie = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Cnpj = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_chaveNFe = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtg_notaReferenciada = New System.Windows.Forms.DataGridView()
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.modelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coduf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cnpj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ecf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aamm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.grb_cp.SuspendLayout()
        CType(Me.dtg_notaReferenciada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_deletar)
        Me.GroupBox1.Controls.Add(Me.btn_incluir)
        Me.GroupBox1.Controls.Add(Me.grb_cp)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_modelo)
        Me.GroupBox1.Controls.Add(Me.txt_aamm)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbo_TipoDoc)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbo_uf)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_numeroNFe)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_serie)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_Cnpj)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_chaveNFe)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(745, 122)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btn_deletar
        '
        Me.btn_deletar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_deletar.Image = Global.RTecSys.My.Resources.Resources.Delete
        Me.btn_deletar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_deletar.Location = New System.Drawing.Point(669, 64)
        Me.btn_deletar.Name = "btn_deletar"
        Me.btn_deletar.Size = New System.Drawing.Size(65, 50)
        Me.btn_deletar.TabIndex = 23
        Me.btn_deletar.Text = "Del. [F4]"
        Me.btn_deletar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_deletar.UseVisualStyleBackColor = True
        '
        'btn_incluir
        '
        Me.btn_incluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_incluir.Image = Global.RTecSys.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_incluir.Location = New System.Drawing.Point(598, 64)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(64, 50)
        Me.btn_incluir.TabIndex = 21
        Me.btn_incluir.Text = "Inc. [F2]"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_incluir.UseVisualStyleBackColor = True
        '
        'grb_cp
        '
        Me.grb_cp.Controls.Add(Me.txt_coo)
        Me.grb_cp.Controls.Add(Me.Label10)
        Me.grb_cp.Controls.Add(Me.Label11)
        Me.grb_cp.Controls.Add(Me.txt_ecf)
        Me.grb_cp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grb_cp.Location = New System.Drawing.Point(399, 64)
        Me.grb_cp.Name = "grb_cp"
        Me.grb_cp.Size = New System.Drawing.Size(181, 51)
        Me.grb_cp.TabIndex = 17
        Me.grb_cp.TabStop = False
        Me.grb_cp.Text = "Cupom:"
        '
        'txt_coo
        '
        Me.txt_coo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_coo.Location = New System.Drawing.Point(117, 19)
        Me.txt_coo.MaxLength = 6
        Me.txt_coo.Name = "txt_coo"
        Me.txt_coo.Size = New System.Drawing.Size(60, 22)
        Me.txt_coo.TabIndex = 3
        Me.txt_coo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "ECF"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(86, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "COO"
        '
        'txt_ecf
        '
        Me.txt_ecf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ecf.Location = New System.Drawing.Point(36, 19)
        Me.txt_ecf.MaxLength = 3
        Me.txt_ecf.Name = "txt_ecf"
        Me.txt_ecf.Size = New System.Drawing.Size(41, 22)
        Me.txt_ecf.TabIndex = 1
        Me.txt_ecf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 16)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Mod."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkRed
        Me.Label8.Location = New System.Drawing.Point(317, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 12)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "ex: 1501"
        '
        'txt_modelo
        '
        Me.txt_modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_modelo.Location = New System.Drawing.Point(13, 82)
        Me.txt_modelo.MaxLength = 2
        Me.txt_modelo.Name = "txt_modelo"
        Me.txt_modelo.Size = New System.Drawing.Size(37, 22)
        Me.txt_modelo.TabIndex = 9
        Me.txt_modelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_aamm
        '
        Me.txt_aamm.Location = New System.Drawing.Point(317, 82)
        Me.txt_aamm.MaxLength = 4
        Me.txt_aamm.Name = "txt_aamm"
        Me.txt_aamm.Size = New System.Drawing.Size(53, 22)
        Me.txt_aamm.TabIndex = 15
        Me.txt_aamm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(314, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Ano/Mes"
        '
        'cbo_TipoDoc
        '
        Me.cbo_TipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_TipoDoc.FormattingEnabled = True
        Me.cbo_TipoDoc.Items.AddRange(New Object() {"NFe", "CP", "01", "1A", "CTe"})
        Me.cbo_TipoDoc.Location = New System.Drawing.Point(423, 32)
        Me.cbo_TipoDoc.Name = "cbo_TipoDoc"
        Me.cbo_TipoDoc.Size = New System.Drawing.Size(78, 24)
        Me.cbo_TipoDoc.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(420, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Tipo Doc.:"
        '
        'cbo_uf
        '
        Me.cbo_uf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_uf.FormattingEnabled = True
        Me.cbo_uf.Location = New System.Drawing.Point(530, 34)
        Me.cbo_uf.Name = "cbo_uf"
        Me.cbo_uf.Size = New System.Drawing.Size(55, 24)
        Me.cbo_uf.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(527, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "UF:"
        '
        'txt_numeroNFe
        '
        Me.txt_numeroNFe.Location = New System.Drawing.Point(620, 34)
        Me.txt_numeroNFe.MaxLength = 9
        Me.txt_numeroNFe.Name = "txt_numeroNFe"
        Me.txt_numeroNFe.Size = New System.Drawing.Size(114, 22)
        Me.txt_numeroNFe.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(617, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Numero:"
        '
        'txt_serie
        '
        Me.txt_serie.Location = New System.Drawing.Point(72, 82)
        Me.txt_serie.MaxLength = 3
        Me.txt_serie.Name = "txt_serie"
        Me.txt_serie.Size = New System.Drawing.Size(52, 22)
        Me.txt_serie.TabIndex = 11
        Me.txt_serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Serie:"
        '
        'txt_Cnpj
        '
        Me.txt_Cnpj.Location = New System.Drawing.Point(145, 82)
        Me.txt_Cnpj.Name = "txt_Cnpj"
        Me.txt_Cnpj.Size = New System.Drawing.Size(153, 22)
        Me.txt_Cnpj.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(142, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Cnpj:"
        '
        'txt_chaveNFe
        '
        Me.txt_chaveNFe.Location = New System.Drawing.Point(13, 34)
        Me.txt_chaveNFe.MaxLength = 44
        Me.txt_chaveNFe.Name = "txt_chaveNFe"
        Me.txt_chaveNFe.Size = New System.Drawing.Size(380, 22)
        Me.txt_chaveNFe.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Chave NFe:"
        '
        'dtg_notaReferenciada
        '
        Me.dtg_notaReferenciada.AllowUserToAddRows = False
        Me.dtg_notaReferenciada.AllowUserToDeleteRows = False
        Me.dtg_notaReferenciada.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_notaReferenciada.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_notaReferenciada.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_notaReferenciada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_notaReferenciada.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.numero, Me.tipo, Me.modelo, Me.chave, Me.coduf, Me.cnpj, Me.serie, Me.coo, Me.ecf, Me.aamm})
        Me.dtg_notaReferenciada.Location = New System.Drawing.Point(8, 132)
        Me.dtg_notaReferenciada.Name = "dtg_notaReferenciada"
        Me.dtg_notaReferenciada.ReadOnly = True
        Me.dtg_notaReferenciada.Size = New System.Drawing.Size(745, 122)
        Me.dtg_notaReferenciada.TabIndex = 29
        '
        'numero
        '
        Me.numero.HeaderText = "Numero"
        Me.numero.MaxInputLength = 9
        Me.numero.MinimumWidth = 6
        Me.numero.Name = "numero"
        Me.numero.ReadOnly = True
        Me.numero.Width = 90
        '
        'tipo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.tipo.DefaultCellStyle = DataGridViewCellStyle2
        Me.tipo.HeaderText = "Tipo"
        Me.tipo.MaxInputLength = 5
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.Width = 50
        '
        'modelo
        '
        Me.modelo.HeaderText = "Modelo"
        Me.modelo.MaxInputLength = 2
        Me.modelo.Name = "modelo"
        Me.modelo.ReadOnly = True
        Me.modelo.Width = 60
        '
        'chave
        '
        Me.chave.HeaderText = "Chave"
        Me.chave.MaxInputLength = 44
        Me.chave.Name = "chave"
        Me.chave.ReadOnly = True
        Me.chave.Width = 300
        '
        'coduf
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.coduf.DefaultCellStyle = DataGridViewCellStyle3
        Me.coduf.HeaderText = "UF"
        Me.coduf.Name = "coduf"
        Me.coduf.ReadOnly = True
        Me.coduf.Width = 40
        '
        'cnpj
        '
        Me.cnpj.HeaderText = "Cnpj"
        Me.cnpj.Name = "cnpj"
        Me.cnpj.ReadOnly = True
        '
        'serie
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.serie.DefaultCellStyle = DataGridViewCellStyle4
        Me.serie.HeaderText = "Serie"
        Me.serie.MaxInputLength = 3
        Me.serie.Name = "serie"
        Me.serie.ReadOnly = True
        Me.serie.Width = 50
        '
        'coo
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.coo.DefaultCellStyle = DataGridViewCellStyle5
        Me.coo.HeaderText = "COO"
        Me.coo.MaxInputLength = 6
        Me.coo.Name = "coo"
        Me.coo.ReadOnly = True
        '
        'ecf
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ecf.DefaultCellStyle = DataGridViewCellStyle6
        Me.ecf.HeaderText = "ECF"
        Me.ecf.MaxInputLength = 3
        Me.ecf.Name = "ecf"
        Me.ecf.ReadOnly = True
        Me.ecf.Width = 50
        '
        'aamm
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.aamm.DefaultCellStyle = DataGridViewCellStyle7
        Me.aamm.HeaderText = "Ano/Mes"
        Me.aamm.MaxInputLength = 4
        Me.aamm.Name = "aamm"
        Me.aamm.ReadOnly = True
        Me.aamm.Width = 60
        '
        'Frm_NFeReferenciadaResp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 264)
        Me.Controls.Add(Me.dtg_notaReferenciada)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_NFeReferenciadaResp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Info. Adicionais da NFe Referenciada"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grb_cp.ResumeLayout(False)
        Me.grb_cp.PerformLayout()
        CType(Me.dtg_notaReferenciada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_chaveNFe As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Cnpj As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_serie As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_uf As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_numeroNFe As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_TipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtg_notaReferenciada As System.Windows.Forms.DataGridView
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents modelo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coduf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnpj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ecf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aamm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_aamm As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_coo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_ecf As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_modelo As System.Windows.Forms.TextBox
    Friend WithEvents btn_deletar As System.Windows.Forms.Button
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents grb_cp As System.Windows.Forms.GroupBox
End Class
