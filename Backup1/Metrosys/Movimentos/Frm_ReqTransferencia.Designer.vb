<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ReqTransferencia
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lbl_qtdeFisc = New System.Windows.Forms.Label
        Me.lbl_usuario = New System.Windows.Forms.Label
        Me.txt_requisicao = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtg_lancamento = New System.Windows.Forms.DataGridView
        Me.codProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.data = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nomeProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.quantidade = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_quantidade = New System.Windows.Forms.TextBox
        Me.txt_nomeProd = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_codProd = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_lanca = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.btn_finalizar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.btn_sair = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtp_data = New System.Windows.Forms.DateTimePicker
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.txt_codPart = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        CType(Me.dtg_lancamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_qtdeFisc
        '
        Me.lbl_qtdeFisc.AutoSize = True
        Me.lbl_qtdeFisc.ForeColor = System.Drawing.Color.Red
        Me.lbl_qtdeFisc.Location = New System.Drawing.Point(241, 127)
        Me.lbl_qtdeFisc.Name = "lbl_qtdeFisc"
        Me.lbl_qtdeFisc.Size = New System.Drawing.Size(19, 13)
        Me.lbl_qtdeFisc.TabIndex = 10
        Me.lbl_qtdeFisc.Text = "    "
        Me.lbl_qtdeFisc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_usuario
        '
        Me.lbl_usuario.AutoSize = True
        Me.lbl_usuario.ForeColor = System.Drawing.Color.Red
        Me.lbl_usuario.Location = New System.Drawing.Point(372, 127)
        Me.lbl_usuario.Name = "lbl_usuario"
        Me.lbl_usuario.Size = New System.Drawing.Size(19, 13)
        Me.lbl_usuario.TabIndex = 10
        Me.lbl_usuario.Text = "    "
        '
        'txt_requisicao
        '
        Me.txt_requisicao.BackColor = System.Drawing.SystemColors.Info
        Me.txt_requisicao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_requisicao.Location = New System.Drawing.Point(82, 26)
        Me.txt_requisicao.Name = "txt_requisicao"
        Me.txt_requisicao.ReadOnly = True
        Me.txt_requisicao.Size = New System.Drawing.Size(100, 20)
        Me.txt_requisicao.TabIndex = 1
        Me.txt_requisicao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Requisição:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(198, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 15)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Qtde:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(313, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Usuário:"
        '
        'dtg_lancamento
        '
        Me.dtg_lancamento.AllowUserToAddRows = False
        Me.dtg_lancamento.AllowUserToDeleteRows = False
        Me.dtg_lancamento.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        Me.dtg_lancamento.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_lancamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_lancamento.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_lancamento.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_lancamento.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_lancamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_lancamento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codProd, Me.data, Me.nomeProd, Me.quantidade})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_lancamento.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_lancamento.Location = New System.Drawing.Point(11, 166)
        Me.dtg_lancamento.Name = "dtg_lancamento"
        Me.dtg_lancamento.ReadOnly = True
        Me.dtg_lancamento.Size = New System.Drawing.Size(495, 270)
        Me.dtg_lancamento.TabIndex = 13
        '
        'codProd
        '
        Me.codProd.HeaderText = "CodProd"
        Me.codProd.Name = "codProd"
        Me.codProd.ReadOnly = True
        Me.codProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.codProd.Visible = False
        '
        'data
        '
        Me.data.HeaderText = "Data"
        Me.data.MaxInputLength = 10
        Me.data.Name = "data"
        Me.data.ReadOnly = True
        Me.data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.data.Width = 85
        '
        'nomeProd
        '
        Me.nomeProd.HeaderText = "Produto"
        Me.nomeProd.MaxInputLength = 80
        Me.nomeProd.Name = "nomeProd"
        Me.nomeProd.ReadOnly = True
        Me.nomeProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nomeProd.Width = 267
        '
        'quantidade
        '
        Me.quantidade.HeaderText = "Quantidade"
        Me.quantidade.MaxInputLength = 14
        Me.quantidade.Name = "quantidade"
        Me.quantidade.ReadOnly = True
        Me.quantidade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'txt_quantidade
        '
        Me.txt_quantidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_quantidade.Location = New System.Drawing.Point(82, 122)
        Me.txt_quantidade.Name = "txt_quantidade"
        Me.txt_quantidade.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_quantidade.Size = New System.Drawing.Size(88, 21)
        Me.txt_quantidade.TabIndex = 13
        '
        'txt_nomeProd
        '
        Me.txt_nomeProd.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nomeProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomeProd.Location = New System.Drawing.Point(155, 88)
        Me.txt_nomeProd.MaxLength = 80
        Me.txt_nomeProd.Name = "txt_nomeProd"
        Me.txt_nomeProd.ReadOnly = True
        Me.txt_nomeProd.Size = New System.Drawing.Size(336, 21)
        Me.txt_nomeProd.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Quantid. :"
        '
        'txt_codProd
        '
        Me.txt_codProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codProd.Location = New System.Drawing.Point(82, 88)
        Me.txt_codProd.MaxLength = 6
        Me.txt_codProd.Name = "txt_codProd"
        Me.txt_codProd.Size = New System.Drawing.Size(67, 21)
        Me.txt_codProd.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Código..:"
        '
        'btn_lanca
        '
        Me.btn_lanca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_lanca.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_lanca.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_lanca.Location = New System.Drawing.Point(7, 13)
        Me.btn_lanca.Name = "btn_lanca"
        Me.btn_lanca.Size = New System.Drawing.Size(75, 46)
        Me.btn_lanca.TabIndex = 19
        Me.btn_lanca.Text = "&Lancar"
        Me.btn_lanca.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_lanca.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(224, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 438)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(497, 47)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensagem"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(6, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = ".   "
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.editar
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(7, 64)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(75, 46)
        Me.btn_alterar.TabIndex = 21
        Me.btn_alterar.Text = "&Editar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_finalizar
        '
        Me.btn_finalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalizar.Image = Global.MetroSys.My.Resources.Resources.Info
        Me.btn_finalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_finalizar.Location = New System.Drawing.Point(7, 165)
        Me.btn_finalizar.Name = "btn_finalizar"
        Me.btn_finalizar.Size = New System.Drawing.Size(75, 46)
        Me.btn_finalizar.TabIndex = 25
        Me.btn_finalizar.Text = "&Finalizar"
        Me.btn_finalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_finalizar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_alterar)
        Me.GroupBox2.Controls.Add(Me.btn_finalizar)
        Me.GroupBox2.Controls.Add(Me.btn_excluir)
        Me.GroupBox2.Controls.Add(Me.btn_sair)
        Me.GroupBox2.Controls.Add(Me.btn_lanca)
        Me.GroupBox2.Location = New System.Drawing.Point(512, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(88, 271)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_excluir.Location = New System.Drawing.Point(7, 115)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(75, 46)
        Me.btn_excluir.TabIndex = 23
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_sair
        '
        Me.btn_sair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sair.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_sair.Location = New System.Drawing.Point(7, 216)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(75, 46)
        Me.btn_sair.TabIndex = 27
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtp_data)
        Me.GroupBox1.Controls.Add(Me.lbl_qtdeFisc)
        Me.GroupBox1.Controls.Add(Me.lbl_usuario)
        Me.GroupBox1.Controls.Add(Me.txt_requisicao)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_quantidade)
        Me.GroupBox1.Controls.Add(Me.txt_nomePart)
        Me.GroupBox1.Controls.Add(Me.txt_nomeProd)
        Me.GroupBox1.Controls.Add(Me.txt_codPart)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_codProd)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(497, 152)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'dtp_data
        '
        Me.dtp_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_data.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_data.Location = New System.Drawing.Point(267, 25)
        Me.dtp_data.Name = "dtp_data"
        Me.dtp_data.Size = New System.Drawing.Size(94, 21)
        Me.dtp_data.TabIndex = 3
        '
        'txt_nomePart
        '
        Me.txt_nomePart.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nomePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomePart.Location = New System.Drawing.Point(155, 56)
        Me.txt_nomePart.MaxLength = 60
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(336, 21)
        Me.txt_nomePart.TabIndex = 7
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codPart.Location = New System.Drawing.Point(82, 56)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(67, 21)
        Me.txt_codPart.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 15)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Destino.:"
        '
        'Frm_ReqTransferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 493)
        Me.Controls.Add(Me.dtg_lancamento)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ReqTransferencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transferência"
        CType(Me.dtg_lancamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents lbl_qtdeFisc As System.Windows.Forms.Label
    Friend WithEvents lbl_usuario As System.Windows.Forms.Label
    Friend WithEvents txt_requisicao As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtg_lancamento As System.Windows.Forms.DataGridView
    Friend WithEvents codProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nomeProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_quantidade As System.Windows.Forms.TextBox
    Public WithEvents txt_nomeProd As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents txt_codProd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_lanca As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_finalizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_data As System.Windows.Forms.DateTimePicker
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
