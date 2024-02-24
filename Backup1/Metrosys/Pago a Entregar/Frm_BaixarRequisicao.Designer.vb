<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_baixarrequisicao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_baixarrequisicao))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtp_data = New System.Windows.Forms.DateTimePicker
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.txt_codPart = New System.Windows.Forms.TextBox
        Me.txt_numRequisicao = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtg_processo = New System.Windows.Forms.DataGridView
        Me.dtg_requisicao = New System.Windows.Forms.DataGridView
        Me.codProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descrProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qtdeProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.btn_finalizar = New System.Windows.Forms.Button
        Me.Btn_novo = New System.Windows.Forms.Button
        Me.Btn_excluir = New System.Windows.Forms.Button
        Me.txt_qtdeProdRequisicao = New System.Windows.Forms.TextBox
        Me.txt_qtdeProdProcesso = New System.Windows.Forms.TextBox
        Me.txt_nomeProd = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.pdRelatPedidos = New System.Drawing.Printing.PrintDocument
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.txt_estoque = New System.Windows.Forms.TextBox
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.estoque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dtg_processo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_requisicao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtp_data)
        Me.GroupBox1.Controls.Add(Me.txt_nomePart)
        Me.GroupBox1.Controls.Add(Me.txt_codPart)
        Me.GroupBox1.Controls.Add(Me.txt_numRequisicao)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(737, 67)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Requisição"
        '
        'dtp_data
        '
        Me.dtp_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_data.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_data.Location = New System.Drawing.Point(380, 15)
        Me.dtp_data.Name = "dtp_data"
        Me.dtp_data.Size = New System.Drawing.Size(100, 21)
        Me.dtp_data.TabIndex = 2
        '
        'txt_nomePart
        '
        Me.txt_nomePart.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nomePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomePart.Location = New System.Drawing.Point(162, 41)
        Me.txt_nomePart.MaxLength = 40
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(318, 21)
        Me.txt_nomePart.TabIndex = 4
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codPart.Location = New System.Drawing.Point(85, 41)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(69, 21)
        Me.txt_codPart.TabIndex = 3
        '
        'txt_numRequisicao
        '
        Me.txt_numRequisicao.BackColor = System.Drawing.SystemColors.Info
        Me.txt_numRequisicao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numRequisicao.Location = New System.Drawing.Point(84, 14)
        Me.txt_numRequisicao.MaxLength = 7
        Me.txt_numRequisicao.Name = "txt_numRequisicao"
        Me.txt_numRequisicao.ReadOnly = True
        Me.txt_numRequisicao.Size = New System.Drawing.Size(112, 21)
        Me.txt_numRequisicao.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cliente:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(338, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Data:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Requisição:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(285, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(187, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(765, 66)
        Me.Panel1.TabIndex = 44
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Wide Latin", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(599, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 19)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'dtg_processo
        '
        Me.dtg_processo.AllowUserToAddRows = False
        Me.dtg_processo.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        Me.dtg_processo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_processo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_processo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_processo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_processo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_processo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_processo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.estoque})
        Me.dtg_processo.Location = New System.Drawing.Point(12, 143)
        Me.dtg_processo.MultiSelect = False
        Me.dtg_processo.Name = "dtg_processo"
        Me.dtg_processo.ReadOnly = True
        Me.dtg_processo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_processo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtg_processo.Size = New System.Drawing.Size(737, 193)
        Me.dtg_processo.TabIndex = 5
        '
        'dtg_requisicao
        '
        Me.dtg_requisicao.AllowUserToAddRows = False
        Me.dtg_requisicao.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Aquamarine
        Me.dtg_requisicao.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dtg_requisicao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_requisicao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_requisicao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_requisicao.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dtg_requisicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_requisicao.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codProd, Me.descrProd, Me.qtdeProd})
        Me.dtg_requisicao.Location = New System.Drawing.Point(13, 412)
        Me.dtg_requisicao.MultiSelect = False
        Me.dtg_requisicao.Name = "dtg_requisicao"
        Me.dtg_requisicao.ReadOnly = True
        Me.dtg_requisicao.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_requisicao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtg_requisicao.Size = New System.Drawing.Size(736, 212)
        Me.dtg_requisicao.TabIndex = 14
        '
        'codProd
        '
        Me.codProd.HeaderText = "Codigo"
        Me.codProd.MaxInputLength = 6
        Me.codProd.Name = "codProd"
        Me.codProd.ReadOnly = True
        Me.codProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'descrProd
        '
        Me.descrProd.HeaderText = "Descrição"
        Me.descrProd.MaxInputLength = 60
        Me.descrProd.Name = "descrProd"
        Me.descrProd.ReadOnly = True
        Me.descrProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.descrProd.Width = 450
        '
        'qtdeProd
        '
        Me.qtdeProd.HeaderText = "Qtde"
        Me.qtdeProd.MaxInputLength = 12
        Me.qtdeProd.Name = "qtdeProd"
        Me.qtdeProd.ReadOnly = True
        Me.qtdeProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.qtdeProd.Width = 142
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.txt_qtdeProdRequisicao)
        Me.GroupBox3.Controls.Add(Me.txt_estoque)
        Me.GroupBox3.Controls.Add(Me.txt_qtdeProdProcesso)
        Me.GroupBox3.Controls.Add(Me.txt_nomeProd)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 338)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(736, 68)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btn_finalizar)
        Me.GroupBox5.Controls.Add(Me.Btn_novo)
        Me.GroupBox5.Controls.Add(Me.Btn_excluir)
        Me.GroupBox5.Location = New System.Drawing.Point(490, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(240, 58)
        Me.GroupBox5.TabIndex = 9
        Me.GroupBox5.TabStop = False
        '
        'btn_finalizar
        '
        Me.btn_finalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalizar.Image = Global.MetroSys.My.Resources.Resources.Info
        Me.btn_finalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_finalizar.Location = New System.Drawing.Point(155, 9)
        Me.btn_finalizar.Name = "btn_finalizar"
        Me.btn_finalizar.Size = New System.Drawing.Size(81, 45)
        Me.btn_finalizar.TabIndex = 12
        Me.btn_finalizar.Text = "&Finalizar [F7]"
        Me.btn_finalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_finalizar.UseVisualStyleBackColor = True
        '
        'Btn_novo
        '
        Me.Btn_novo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_novo.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.Btn_novo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_novo.Location = New System.Drawing.Point(4, 10)
        Me.Btn_novo.Name = "Btn_novo"
        Me.Btn_novo.Size = New System.Drawing.Size(72, 44)
        Me.Btn_novo.TabIndex = 10
        Me.Btn_novo.Text = "&Novo [F2]"
        Me.Btn_novo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_novo.UseVisualStyleBackColor = True
        '
        'Btn_excluir
        '
        Me.Btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.Btn_excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_excluir.Location = New System.Drawing.Point(77, 9)
        Me.Btn_excluir.Name = "Btn_excluir"
        Me.Btn_excluir.Size = New System.Drawing.Size(74, 45)
        Me.Btn_excluir.TabIndex = 11
        Me.Btn_excluir.Text = "&Excluir [F4]"
        Me.Btn_excluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_excluir.UseVisualStyleBackColor = True
        '
        'txt_qtdeProdRequisicao
        '
        Me.txt_qtdeProdRequisicao.Location = New System.Drawing.Point(406, 31)
        Me.txt_qtdeProdRequisicao.MaxLength = 14
        Me.txt_qtdeProdRequisicao.Name = "txt_qtdeProdRequisicao"
        Me.txt_qtdeProdRequisicao.Size = New System.Drawing.Size(73, 20)
        Me.txt_qtdeProdRequisicao.TabIndex = 8
        Me.txt_qtdeProdRequisicao.Text = "0,00"
        Me.txt_qtdeProdRequisicao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_qtdeProdProcesso
        '
        Me.txt_qtdeProdProcesso.Location = New System.Drawing.Point(106, 61)
        Me.txt_qtdeProdProcesso.MaxLength = 14
        Me.txt_qtdeProdProcesso.Name = "txt_qtdeProdProcesso"
        Me.txt_qtdeProdProcesso.ReadOnly = True
        Me.txt_qtdeProdProcesso.Size = New System.Drawing.Size(95, 20)
        Me.txt_qtdeProdProcesso.TabIndex = 6
        Me.txt_qtdeProdProcesso.Text = "0,00"
        Me.txt_qtdeProdProcesso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_qtdeProdProcesso.Visible = False
        '
        'txt_nomeProd
        '
        Me.txt_nomeProd.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nomeProd.Location = New System.Drawing.Point(68, 31)
        Me.txt_nomeProd.MaxLength = 60
        Me.txt_nomeProd.Name = "txt_nomeProd"
        Me.txt_nomeProd.ReadOnly = True
        Me.txt_nomeProd.Size = New System.Drawing.Size(285, 20)
        Me.txt_nomeProd.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(364, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Qtde:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(232, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 15)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Disponivel:"
        Me.Label9.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Produto:"
        '
        'pdRelatPedidos
        '
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
        'txt_estoque
        '
        Me.txt_estoque.Location = New System.Drawing.Point(226, 61)
        Me.txt_estoque.MaxLength = 14
        Me.txt_estoque.Name = "txt_estoque"
        Me.txt_estoque.ReadOnly = True
        Me.txt_estoque.Size = New System.Drawing.Size(95, 20)
        Me.txt_estoque.TabIndex = 6
        Me.txt_estoque.Text = "0,00"
        Me.txt_estoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_estoque.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn1.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn1.MaxInputLength = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descrição"
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 80
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 450
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn3.HeaderText = "Qtde"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 12
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 142
        '
        'estoque
        '
        Me.estoque.HeaderText = "estoque"
        Me.estoque.MaxInputLength = 17
        Me.estoque.Name = "estoque"
        Me.estoque.ReadOnly = True
        Me.estoque.Visible = False
        '
        'Frm_baixarrequisicao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 631)
        Me.Controls.Add(Me.dtg_processo)
        Me.Controls.Add(Me.dtg_requisicao)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_baixarrequisicao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Baixa Requisição"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtg_processo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_requisicao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_numRequisicao As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_data As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtg_processo As System.Windows.Forms.DataGridView
    Friend WithEvents dtg_requisicao As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Public WithEvents btn_finalizar As System.Windows.Forms.Button
    Friend WithEvents Btn_novo As System.Windows.Forms.Button
    Public WithEvents Btn_excluir As System.Windows.Forms.Button
    Friend WithEvents txt_qtdeProdRequisicao As System.Windows.Forms.TextBox
    Friend WithEvents txt_qtdeProdProcesso As System.Windows.Forms.TextBox
    Friend WithEvents txt_nomeProd As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Friend WithEvents codProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descrProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtdeProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pdRelatPedidos As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents txt_estoque As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estoque As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
