<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BaixaFinancRMp
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_documento = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_valorPago = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_valorDesconto = New System.Windows.Forms.TextBox
        Me.grp_contas = New System.Windows.Forms.GroupBox
        Me.RDbContAtual = New System.Windows.Forms.RadioButton
        Me.RDbContAnterior = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_juros = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_nomeCliente = New System.Windows.Forms.TextBox
        Me.dtg_documentos = New System.Windows.Forms.DataGridView
        Me.p_portad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_sit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_duplic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_emiss = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_vencto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f_valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_baixar = New System.Windows.Forms.Button
        Me.dtp_dataPagamento = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.btn_finalizar = New System.Windows.Forms.Button
        Me.grp_contas.SuspendLayout()
        CType(Me.dtg_documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(204, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(395, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "*** Baixa Financeiro do Retorno do Mapa ***"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(323, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Documento:"
        '
        'txt_documento
        '
        Me.txt_documento.BackColor = System.Drawing.SystemColors.Info
        Me.txt_documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_documento.Enabled = False
        Me.txt_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_documento.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txt_documento.Location = New System.Drawing.Point(404, 59)
        Me.txt_documento.MaxLength = 10
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.ReadOnly = True
        Me.txt_documento.Size = New System.Drawing.Size(133, 21)
        Me.txt_documento.TabIndex = 5
        Me.txt_documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Valor Pago R$:"
        '
        'txt_valorPago
        '
        Me.txt_valorPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_valorPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valorPago.ForeColor = System.Drawing.Color.Red
        Me.txt_valorPago.Location = New System.Drawing.Point(113, 96)
        Me.txt_valorPago.MaxLength = 14
        Me.txt_valorPago.Name = "txt_valorPago"
        Me.txt_valorPago.Size = New System.Drawing.Size(130, 21)
        Me.txt_valorPago.TabIndex = 9
        Me.txt_valorPago.Text = "0,00"
        Me.txt_valorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(302, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Valor Desc. R$:"
        '
        'txt_valorDesconto
        '
        Me.txt_valorDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_valorDesconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valorDesconto.ForeColor = System.Drawing.Color.Red
        Me.txt_valorDesconto.Location = New System.Drawing.Point(405, 96)
        Me.txt_valorDesconto.MaxLength = 14
        Me.txt_valorDesconto.Name = "txt_valorDesconto"
        Me.txt_valorDesconto.Size = New System.Drawing.Size(130, 21)
        Me.txt_valorDesconto.TabIndex = 11
        Me.txt_valorDesconto.Text = "0,00"
        Me.txt_valorDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grp_contas
        '
        Me.grp_contas.Controls.Add(Me.RDbContAtual)
        Me.grp_contas.Controls.Add(Me.RDbContAnterior)
        Me.grp_contas.Location = New System.Drawing.Point(17, 43)
        Me.grp_contas.Name = "grp_contas"
        Me.grp_contas.Size = New System.Drawing.Size(258, 45)
        Me.grp_contas.TabIndex = 0
        Me.grp_contas.TabStop = False
        Me.grp_contas.Text = "Contas"
        '
        'RDbContAtual
        '
        Me.RDbContAtual.AutoSize = True
        Me.RDbContAtual.Checked = True
        Me.RDbContAtual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDbContAtual.Location = New System.Drawing.Point(141, 17)
        Me.RDbContAtual.Name = "RDbContAtual"
        Me.RDbContAtual.Size = New System.Drawing.Size(91, 17)
        Me.RDbContAtual.TabIndex = 3
        Me.RDbContAtual.TabStop = True
        Me.RDbContAtual.Text = "Conta Atual"
        Me.RDbContAtual.UseVisualStyleBackColor = True
        '
        'RDbContAnterior
        '
        Me.RDbContAnterior.AutoSize = True
        Me.RDbContAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDbContAnterior.Location = New System.Drawing.Point(10, 17)
        Me.RDbContAnterior.Name = "RDbContAnterior"
        Me.RDbContAnterior.Size = New System.Drawing.Size(106, 17)
        Me.RDbContAnterior.TabIndex = 1
        Me.RDbContAnterior.Text = "Conta Anterior"
        Me.RDbContAnterior.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(598, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Juros R$:"
        '
        'txt_juros
        '
        Me.txt_juros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_juros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_juros.ForeColor = System.Drawing.Color.Red
        Me.txt_juros.Location = New System.Drawing.Point(665, 96)
        Me.txt_juros.MaxLength = 12
        Me.txt_juros.Name = "txt_juros"
        Me.txt_juros.Size = New System.Drawing.Size(117, 21)
        Me.txt_juros.TabIndex = 13
        Me.txt_juros.Text = "0,00"
        Me.txt_juros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Cliente:"
        '
        'txt_nomeCliente
        '
        Me.txt_nomeCliente.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nomeCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nomeCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomeCliente.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txt_nomeCliente.Location = New System.Drawing.Point(70, 134)
        Me.txt_nomeCliente.MaxLength = 11
        Me.txt_nomeCliente.Name = "txt_nomeCliente"
        Me.txt_nomeCliente.ReadOnly = True
        Me.txt_nomeCliente.Size = New System.Drawing.Size(427, 21)
        Me.txt_nomeCliente.TabIndex = 15
        '
        'dtg_documentos
        '
        Me.dtg_documentos.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumAquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_documentos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_documentos.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_documentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_documentos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_documentos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_documentos.ColumnHeadersHeight = 21
        Me.dtg_documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_documentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.p_portad, Me.f_tipo, Me.f_sit, Me.f_duplic, Me.f_emiss, Me.f_vencto, Me.f_valor})
        Me.dtg_documentos.Location = New System.Drawing.Point(17, 167)
        Me.dtg_documentos.MultiSelect = False
        Me.dtg_documentos.Name = "dtg_documentos"
        Me.dtg_documentos.ReadOnly = True
        Me.dtg_documentos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_documentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_documentos.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_documentos.Size = New System.Drawing.Size(765, 164)
        Me.dtg_documentos.TabIndex = 21
        '
        'p_portad
        '
        Me.p_portad.HeaderText = "Cliente"
        Me.p_portad.MaxInputLength = 80
        Me.p_portad.Name = "p_portad"
        Me.p_portad.ReadOnly = True
        Me.p_portad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.p_portad.Width = 230
        '
        'f_tipo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_tipo.DefaultCellStyle = DataGridViewCellStyle2
        Me.f_tipo.HeaderText = "Tipo"
        Me.f_tipo.Name = "f_tipo"
        Me.f_tipo.ReadOnly = True
        Me.f_tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.f_tipo.Width = 50
        '
        'f_sit
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.f_sit.DefaultCellStyle = DataGridViewCellStyle3
        Me.f_sit.HeaderText = "Sit"
        Me.f_sit.Name = "f_sit"
        Me.f_sit.ReadOnly = True
        Me.f_sit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.f_sit.Width = 40
        '
        'f_duplic
        '
        Me.f_duplic.HeaderText = "Documento"
        Me.f_duplic.Name = "f_duplic"
        Me.f_duplic.ReadOnly = True
        Me.f_duplic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.f_duplic.Width = 110
        '
        'f_emiss
        '
        Me.f_emiss.HeaderText = "Emissao"
        Me.f_emiss.Name = "f_emiss"
        Me.f_emiss.ReadOnly = True
        Me.f_emiss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.f_emiss.Width = 90
        '
        'f_vencto
        '
        Me.f_vencto.HeaderText = "Vencto"
        Me.f_vencto.Name = "f_vencto"
        Me.f_vencto.ReadOnly = True
        Me.f_vencto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.f_vencto.Width = 90
        '
        'f_valor
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.f_valor.DefaultCellStyle = DataGridViewCellStyle4
        Me.f_valor.HeaderText = "Valor R$"
        Me.f_valor.Name = "f_valor"
        Me.f_valor.ReadOnly = True
        Me.f_valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.f_valor.Width = 110
        '
        'btn_baixar
        '
        Me.btn_baixar.AutoEllipsis = True
        Me.btn_baixar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_baixar.Image = Global.RTecSys.My.Resources.Resources.salvar
        Me.btn_baixar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_baixar.Location = New System.Drawing.Point(665, 125)
        Me.btn_baixar.Name = "btn_baixar"
        Me.btn_baixar.Size = New System.Drawing.Size(117, 36)
        Me.btn_baixar.TabIndex = 19
        Me.btn_baixar.Text = "&Baixar"
        Me.btn_baixar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_baixar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_baixar.UseVisualStyleBackColor = True
        '
        'dtp_dataPagamento
        '
        Me.dtp_dataPagamento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dataPagamento.Location = New System.Drawing.Point(685, 60)
        Me.dtp_dataPagamento.Name = "dtp_dataPagamento"
        Me.dtp_dataPagamento.Size = New System.Drawing.Size(97, 21)
        Me.dtp_dataPagamento.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(578, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "DataPagamento:"
        '
        'btn_finalizar
        '
        Me.btn_finalizar.AutoEllipsis = True
        Me.btn_finalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalizar.Image = Global.RTecSys.My.Resources.Resources.Info
        Me.btn_finalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_finalizar.Location = New System.Drawing.Point(542, 125)
        Me.btn_finalizar.Name = "btn_finalizar"
        Me.btn_finalizar.Size = New System.Drawing.Size(117, 36)
        Me.btn_finalizar.TabIndex = 17
        Me.btn_finalizar.Text = "&Finalizar"
        Me.btn_finalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_finalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_finalizar.UseVisualStyleBackColor = True
        '
        'Frm_BaixaFinancRMp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 339)
        Me.ControlBox = False
        Me.Controls.Add(Me.dtp_dataPagamento)
        Me.Controls.Add(Me.btn_finalizar)
        Me.Controls.Add(Me.btn_baixar)
        Me.Controls.Add(Me.dtg_documentos)
        Me.Controls.Add(Me.grp_contas)
        Me.Controls.Add(Me.txt_valorDesconto)
        Me.Controls.Add(Me.txt_juros)
        Me.Controls.Add(Me.txt_valorPago)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_nomeCliente)
        Me.Controls.Add(Me.txt_documento)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_BaixaFinancRMp"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "   Retorno do Mapa"
        Me.grp_contas.ResumeLayout(False)
        Me.grp_contas.PerformLayout()
        CType(Me.dtg_documentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_valorPago As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_valorDesconto As System.Windows.Forms.TextBox
    Friend WithEvents grp_contas As System.Windows.Forms.GroupBox
    Friend WithEvents RDbContAtual As System.Windows.Forms.RadioButton
    Friend WithEvents RDbContAnterior As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_juros As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_nomeCliente As System.Windows.Forms.TextBox
    Friend WithEvents dtg_documentos As System.Windows.Forms.DataGridView
    Friend WithEvents btn_baixar As System.Windows.Forms.Button
    Friend WithEvents p_portad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_sit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_duplic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_emiss As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_vencto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtp_dataPagamento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_finalizar As System.Windows.Forms.Button
End Class
