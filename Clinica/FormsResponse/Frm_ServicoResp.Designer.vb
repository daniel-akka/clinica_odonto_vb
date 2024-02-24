<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ServicoResp
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.dtg_servicos = New System.Windows.Forms.DataGridView()
        Me.idUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.servico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_confirmar = New System.Windows.Forms.Button()
        CType(Me.dtg_servicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(139, 73)
        Me.txt_pesquisa.MaxLength = 100
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(444, 26)
        Me.txt_pesquisa.TabIndex = 3
        '
        'dtg_servicos
        '
        Me.dtg_servicos.AllowUserToAddRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_servicos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dtg_servicos.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_servicos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_servicos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_servicos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_servicos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dtg_servicos.ColumnHeadersHeight = 26
        Me.dtg_servicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_servicos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idUsu, Me.servico, Me.valor})
        Me.dtg_servicos.Location = New System.Drawing.Point(22, 109)
        Me.dtg_servicos.MultiSelect = False
        Me.dtg_servicos.Name = "dtg_servicos"
        Me.dtg_servicos.ReadOnly = True
        Me.dtg_servicos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_servicos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_servicos.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dtg_servicos.Size = New System.Drawing.Size(663, 173)
        Me.dtg_servicos.TabIndex = 107
        '
        'idUsu
        '
        Me.idUsu.HeaderText = "Id"
        Me.idUsu.MaxInputLength = 13
        Me.idUsu.Name = "idUsu"
        Me.idUsu.ReadOnly = True
        Me.idUsu.Visible = False
        '
        'servico
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.servico.DefaultCellStyle = DataGridViewCellStyle8
        Me.servico.HeaderText = "Serviço"
        Me.servico.MaxInputLength = 2
        Me.servico.Name = "servico"
        Me.servico.ReadOnly = True
        Me.servico.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.servico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.servico.Width = 500
        '
        'valor
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valor.DefaultCellStyle = DataGridViewCellStyle9
        Me.valor.HeaderText = "Valor R$"
        Me.valor.MaxInputLength = 60
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 20)
        Me.Label7.TabIndex = 103
        Me.Label7.Text = "Descr. Serviço:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(234, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 35)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Pesquisa de Serviço"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_confirmar
        '
        Me.btn_confirmar.Font = New System.Drawing.Font("Cooper Black", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_confirmar.Image = Global.RTecSys.My.Resources.Resources.ok_16x16
        Me.btn_confirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_confirmar.Location = New System.Drawing.Point(604, 68)
        Me.btn_confirmar.Name = "btn_confirmar"
        Me.btn_confirmar.Size = New System.Drawing.Size(81, 32)
        Me.btn_confirmar.TabIndex = 2
        Me.btn_confirmar.Text = "&OK"
        Me.btn_confirmar.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btn_confirmar.UseVisualStyleBackColor = True
        '
        'Frm_ServicoResp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 290)
        Me.Controls.Add(Me.btn_confirmar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.Controls.Add(Me.dtg_servicos)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ServicoResp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Serviço"
        CType(Me.dtg_servicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents dtg_servicos As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents idUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents servico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_confirmar As System.Windows.Forms.Button
End Class
