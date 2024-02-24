<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManCargas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManCargas))
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbo_cidade = New System.Windows.Forms.ComboBox
        Me.cbo_uf = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_NovoMapa = New System.Windows.Forms.Button
        Me.msk_data = New System.Windows.Forms.MaskedTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_numMapa = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_pesoBruto = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_gerar = New System.Windows.Forms.Button
        Me.txt_valorTotal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_totPedidos = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtg_pedidos = New System.Windows.Forms.DataGridView
        Me.nt_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.checkPedido = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.numPedido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.data = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.portador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.uf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cidade = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pdRelatPedidos = New System.Drawing.Printing.PrintDocument
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_roteiro = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtg_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_roteiro)
        Me.GroupBox1.Controls.Add(Me.cbo_cidade)
        Me.GroupBox1.Controls.Add(Me.cbo_uf)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btn_NovoMapa)
        Me.GroupBox1.Controls.Add(Me.msk_data)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_numMapa)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(795, 79)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cbo_cidade
        '
        Me.cbo_cidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbo_cidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cbo_cidade.DropDownWidth = 300
        Me.cbo_cidade.FormattingEnabled = True
        Me.cbo_cidade.Location = New System.Drawing.Point(409, 16)
        Me.cbo_cidade.Name = "cbo_cidade"
        Me.cbo_cidade.Size = New System.Drawing.Size(225, 21)
        Me.cbo_cidade.TabIndex = 7
        '
        'cbo_uf
        '
        Me.cbo_uf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_uf.FormattingEnabled = True
        Me.cbo_uf.Items.AddRange(New Object() {"", "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "EX", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PE", "PI", "RJ", "RN", "RS", "RD", "RR", "SC", "SP", "SE", "TO"})
        Me.cbo_uf.Location = New System.Drawing.Point(282, 16)
        Me.cbo_uf.Name = "cbo_uf"
        Me.cbo_uf.Size = New System.Drawing.Size(54, 21)
        Me.cbo_uf.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(252, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "UF:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(360, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Cidade:"
        '
        'btn_NovoMapa
        '
        Me.btn_NovoMapa.Image = Global.MetroSys.My.Resources.Resources.disc_r
        Me.btn_NovoMapa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_NovoMapa.Location = New System.Drawing.Point(13, 10)
        Me.btn_NovoMapa.Name = "btn_NovoMapa"
        Me.btn_NovoMapa.Size = New System.Drawing.Size(96, 33)
        Me.btn_NovoMapa.TabIndex = 1
        Me.btn_NovoMapa.Text = "&Novo Mapa"
        Me.btn_NovoMapa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_NovoMapa.UseVisualStyleBackColor = True
        '
        'msk_data
        '
        Me.msk_data.BackColor = System.Drawing.SystemColors.Info
        Me.msk_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_data.Location = New System.Drawing.Point(693, 14)
        Me.msk_data.Mask = "00/00/0000"
        Me.msk_data.Name = "msk_data"
        Me.msk_data.ReadOnly = True
        Me.msk_data.Size = New System.Drawing.Size(93, 24)
        Me.msk_data.TabIndex = 9
        Me.msk_data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.msk_data.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(654, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Data:"
        '
        'txt_numMapa
        '
        Me.txt_numMapa.BackColor = System.Drawing.SystemColors.Info
        Me.txt_numMapa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numMapa.Location = New System.Drawing.Point(115, 14)
        Me.txt_numMapa.MaxLength = 10
        Me.txt_numMapa.Name = "txt_numMapa"
        Me.txt_numMapa.ReadOnly = True
        Me.txt_numMapa.Size = New System.Drawing.Size(106, 24)
        Me.txt_numMapa.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(304, 5)
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
        Me.Panel1.Size = New System.Drawing.Size(852, 66)
        Me.Panel1.TabIndex = 38
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Wide Latin", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(647, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(167, 22)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Peso Bruto:"
        '
        'txt_pesoBruto
        '
        Me.txt_pesoBruto.BackColor = System.Drawing.SystemColors.Info
        Me.txt_pesoBruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesoBruto.Location = New System.Drawing.Point(107, 16)
        Me.txt_pesoBruto.MaxLength = 14
        Me.txt_pesoBruto.Name = "txt_pesoBruto"
        Me.txt_pesoBruto.ReadOnly = True
        Me.txt_pesoBruto.Size = New System.Drawing.Size(100, 24)
        Me.txt_pesoBruto.TabIndex = 11
        Me.txt_pesoBruto.Text = "0,00"
        Me.txt_pesoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_gerar)
        Me.GroupBox2.Controls.Add(Me.txt_valorTotal)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txt_totPedidos)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txt_pesoBruto)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(11, 561)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(797, 50)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        '
        'btn_gerar
        '
        Me.btn_gerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gerar.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_gerar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_gerar.Location = New System.Drawing.Point(716, 11)
        Me.btn_gerar.Name = "btn_gerar"
        Me.btn_gerar.Size = New System.Drawing.Size(75, 33)
        Me.btn_gerar.TabIndex = 17
        Me.btn_gerar.Text = "&Gerar"
        Me.btn_gerar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_gerar.UseVisualStyleBackColor = True
        '
        'txt_valorTotal
        '
        Me.txt_valorTotal.BackColor = System.Drawing.SystemColors.Info
        Me.txt_valorTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valorTotal.Location = New System.Drawing.Point(543, 16)
        Me.txt_valorTotal.MaxLength = 18
        Me.txt_valorTotal.Name = "txt_valorTotal"
        Me.txt_valorTotal.ReadOnly = True
        Me.txt_valorTotal.Size = New System.Drawing.Size(120, 24)
        Me.txt_valorTotal.TabIndex = 15
        Me.txt_valorTotal.Text = "0,00"
        Me.txt_valorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(431, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Valor Total R$ :"
        '
        'txt_totPedidos
        '
        Me.txt_totPedidos.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totPedidos.Location = New System.Drawing.Point(326, 16)
        Me.txt_totPedidos.MaxLength = 16
        Me.txt_totPedidos.Name = "txt_totPedidos"
        Me.txt_totPedidos.ReadOnly = True
        Me.txt_totPedidos.Size = New System.Drawing.Size(62, 24)
        Me.txt_totPedidos.TabIndex = 13
        Me.txt_totPedidos.Text = "0"
        Me.txt_totPedidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(233, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tot.Pedidos:"
        '
        'dtg_pedidos
        '
        Me.dtg_pedidos.AllowUserToAddRows = False
        Me.dtg_pedidos.AllowUserToDeleteRows = False
        DataGridViewCellStyle36.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dtg_pedidos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle36
        Me.dtg_pedidos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_pedidos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_pedidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_pedidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nt_id, Me.checkPedido, Me.numPedido, Me.data, Me.portador, Me.uf, Me.cidade, Me.valor})
        Me.dtg_pedidos.Location = New System.Drawing.Point(12, 150)
        Me.dtg_pedidos.Name = "dtg_pedidos"
        Me.dtg_pedidos.ReadOnly = True
        Me.dtg_pedidos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_pedidos.Size = New System.Drawing.Size(796, 407)
        Me.dtg_pedidos.TabIndex = 40
        '
        'nt_id
        '
        Me.nt_id.HeaderText = "nt_id"
        Me.nt_id.Name = "nt_id"
        Me.nt_id.ReadOnly = True
        Me.nt_id.Visible = False
        '
        'checkPedido
        '
        Me.checkPedido.HeaderText = "Marcar"
        Me.checkPedido.Name = "checkPedido"
        Me.checkPedido.ReadOnly = True
        Me.checkPedido.Width = 50
        '
        'numPedido
        '
        DataGridViewCellStyle37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPedido.DefaultCellStyle = DataGridViewCellStyle37
        Me.numPedido.HeaderText = "Pedido"
        Me.numPedido.MaxInputLength = 9
        Me.numPedido.Name = "numPedido"
        Me.numPedido.ReadOnly = True
        Me.numPedido.Width = 80
        '
        'data
        '
        DataGridViewCellStyle38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data.DefaultCellStyle = DataGridViewCellStyle38
        Me.data.HeaderText = "Data"
        Me.data.MaxInputLength = 10
        Me.data.Name = "data"
        Me.data.ReadOnly = True
        Me.data.Width = 80
        '
        'portador
        '
        DataGridViewCellStyle39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.portador.DefaultCellStyle = DataGridViewCellStyle39
        Me.portador.HeaderText = "Participante"
        Me.portador.MaxInputLength = 80
        Me.portador.Name = "portador"
        Me.portador.ReadOnly = True
        Me.portador.Width = 300
        '
        'uf
        '
        Me.uf.HeaderText = "UF"
        Me.uf.Name = "uf"
        Me.uf.ReadOnly = True
        Me.uf.Width = 30
        '
        'cidade
        '
        Me.cidade.HeaderText = "Cidade"
        Me.cidade.Name = "cidade"
        Me.cidade.ReadOnly = True
        Me.cidade.Width = 110
        '
        'valor
        '
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valor.DefaultCellStyle = DataGridViewCellStyle40
        Me.valor.HeaderText = "Valor"
        Me.valor.MaxInputLength = 16
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 16)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Roteiro:"
        '
        'txt_roteiro
        '
        Me.txt_roteiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_roteiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_roteiro.Location = New System.Drawing.Point(76, 50)
        Me.txt_roteiro.MaxLength = 58
        Me.txt_roteiro.Name = "txt_roteiro"
        Me.txt_roteiro.Size = New System.Drawing.Size(466, 22)
        Me.txt_roteiro.TabIndex = 10
        '
        'Frm_ManCargas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 619)
        Me.Controls.Add(Me.dtg_pedidos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ManCargas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monta Relatorio de Cargas "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtg_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_pesoBruto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_numMapa As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents msk_data As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btn_NovoMapa As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtg_pedidos As System.Windows.Forms.DataGridView
    Friend WithEvents txt_valorTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_totPedidos As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_uf As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_gerar As System.Windows.Forms.Button
    Friend WithEvents cbo_cidade As System.Windows.Forms.ComboBox
    Friend WithEvents nt_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents checkPedido As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents numPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents portador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pdRelatPedidos As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents txt_roteiro As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
