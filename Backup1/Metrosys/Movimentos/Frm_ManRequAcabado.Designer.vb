<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManRequAcabado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManRequAcabado))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.msk_dataFinal = New System.Windows.Forms.MaskedTextBox
        Me.msk_dataInicial = New System.Windows.Forms.MaskedTextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.btn_sair = New System.Windows.Forms.Button
        Me.btn_registro = New System.Windows.Forms.Button
        Me.dtg_requisicao = New System.Windows.Forms.DataGridView
        Me.numRequis = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataRequis = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.operRequis = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtg_requisicao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Período:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(255, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "ex: 01/12/2012"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(159, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "A"
        '
        'msk_dataFinal
        '
        Me.msk_dataFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_dataFinal.Location = New System.Drawing.Point(180, 20)
        Me.msk_dataFinal.Mask = "00/00/0000"
        Me.msk_dataFinal.Name = "msk_dataFinal"
        Me.msk_dataFinal.Size = New System.Drawing.Size(69, 21)
        Me.msk_dataFinal.TabIndex = 9
        Me.msk_dataFinal.ValidatingType = GetType(Date)
        '
        'msk_dataInicial
        '
        Me.msk_dataInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_dataInicial.Location = New System.Drawing.Point(84, 20)
        Me.msk_dataInicial.Mask = "00/00/0000"
        Me.msk_dataInicial.Name = "msk_dataInicial"
        Me.msk_dataInicial.Size = New System.Drawing.Size(69, 21)
        Me.msk_dataInicial.TabIndex = 8
        Me.msk_dataInicial.ValidatingType = GetType(Date)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_excluir)
        Me.GroupBox2.Controls.Add(Me.btn_imprimir)
        Me.GroupBox2.Controls.Add(Me.btn_sair)
        Me.GroupBox2.Controls.Add(Me.btn_registro)
        Me.GroupBox2.Location = New System.Drawing.Point(515, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(88, 216)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_excluir.Location = New System.Drawing.Point(7, 62)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(75, 47)
        Me.btn_excluir.TabIndex = 4
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Image = CType(resources.GetObject("btn_imprimir.Image"), System.Drawing.Image)
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.Location = New System.Drawing.Point(6, 113)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(75, 44)
        Me.btn_imprimir.TabIndex = 5
        Me.btn_imprimir.Text = "&Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'btn_sair
        '
        Me.btn_sair.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sair.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_sair.Location = New System.Drawing.Point(6, 164)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(75, 44)
        Me.btn_sair.TabIndex = 6
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'btn_registro
        '
        Me.btn_registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_registro.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_registro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_registro.Location = New System.Drawing.Point(6, 12)
        Me.btn_registro.Name = "btn_registro"
        Me.btn_registro.Size = New System.Drawing.Size(75, 46)
        Me.btn_registro.TabIndex = 3
        Me.btn_registro.Text = "&Registro"
        Me.btn_registro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_registro.UseVisualStyleBackColor = True
        '
        'dtg_requisicao
        '
        Me.dtg_requisicao.AllowUserToAddRows = False
        Me.dtg_requisicao.AllowUserToDeleteRows = False
        Me.dtg_requisicao.AllowUserToResizeColumns = False
        Me.dtg_requisicao.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        Me.dtg_requisicao.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_requisicao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_requisicao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_requisicao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_requisicao.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_requisicao.ColumnHeadersHeight = 25
        Me.dtg_requisicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_requisicao.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.numRequis, Me.dataRequis, Me.operRequis})
        Me.dtg_requisicao.Location = New System.Drawing.Point(10, 50)
        Me.dtg_requisicao.Name = "dtg_requisicao"
        Me.dtg_requisicao.ReadOnly = True
        Me.dtg_requisicao.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_requisicao.Size = New System.Drawing.Size(499, 386)
        Me.dtg_requisicao.TabIndex = 7
        '
        'numRequis
        '
        Me.numRequis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.numRequis.HeaderText = "Requisicao"
        Me.numRequis.MaxInputLength = 12
        Me.numRequis.Name = "numRequis"
        Me.numRequis.ReadOnly = True
        Me.numRequis.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.numRequis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.numRequis.Width = 120
        '
        'dataRequis
        '
        Me.dataRequis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dataRequis.HeaderText = "Data"
        Me.dataRequis.MaxInputLength = 10
        Me.dataRequis.Name = "dataRequis"
        Me.dataRequis.ReadOnly = True
        Me.dataRequis.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataRequis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dataRequis.Width = 85
        '
        'operRequis
        '
        Me.operRequis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.operRequis.HeaderText = "Operador"
        Me.operRequis.MaxInputLength = 20
        Me.operRequis.Name = "operRequis"
        Me.operRequis.ReadOnly = True
        Me.operRequis.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.operRequis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        '
        'Frm_ManRequAcabado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 457)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.msk_dataFinal)
        Me.Controls.Add(Me.msk_dataInicial)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dtg_requisicao)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ManRequAcabado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção Requisição Acabado"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dtg_requisicao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents msk_dataFinal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents msk_dataInicial As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents btn_registro As System.Windows.Forms.Button
    Friend WithEvents dtg_requisicao As System.Windows.Forms.DataGridView
    Friend WithEvents numRequis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataRequis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents operRequis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
