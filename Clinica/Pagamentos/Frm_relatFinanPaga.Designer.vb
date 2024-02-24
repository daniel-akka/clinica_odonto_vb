<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_relatFinanPaga
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_relatFinanPaga))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbo_vendedor = New System.Windows.Forms.ComboBox()
        Me.cbo_opcoes = New System.Windows.Forms.ComboBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.lbl_carteira = New System.Windows.Forms.Label()
        Me.cbo_loja = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbox_impressora = New System.Windows.Forms.PictureBox()
        Me.grp_menu = New System.Windows.Forms.GroupBox()
        Me.cbo_carteira = New System.Windows.Forms.ComboBox()
        Me.grp_periodo = New System.Windows.Forms.GroupBox()
        Me.dtp_final = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_inicial = New System.Windows.Forms.DateTimePicker()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pbox_impressora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_menu.SuspendLayout()
        Me.grp_periodo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(292, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Vendedor:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Opções:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_vendedor)
        Me.GroupBox1.Controls.Add(Me.cbo_opcoes)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(462, 46)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'cbo_vendedor
        '
        Me.cbo_vendedor.DropDownHeight = 120
        Me.cbo_vendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_vendedor.DropDownWidth = 180
        Me.cbo_vendedor.Enabled = False
        Me.cbo_vendedor.FormattingEnabled = True
        Me.cbo_vendedor.IntegralHeight = False
        Me.cbo_vendedor.Location = New System.Drawing.Point(372, 16)
        Me.cbo_vendedor.Name = "cbo_vendedor"
        Me.cbo_vendedor.Size = New System.Drawing.Size(84, 24)
        Me.cbo_vendedor.TabIndex = 4
        '
        'cbo_opcoes
        '
        Me.cbo_opcoes.DropDownHeight = 200
        Me.cbo_opcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_opcoes.FormattingEnabled = True
        Me.cbo_opcoes.IntegralHeight = False
        Me.cbo_opcoes.Items.AddRange(New Object() {"Doc. Pagos no Período", "Doc. Vencidas por Carteira", "Doc. a Vencer por Período", "Doc. Incluidas por Dia", "Dupl.Pagas-Pendente", "Vencidas Alfabética", "Gera Fatura", "Emite Bloquete", "Emite Duplicatas", "Vencidas por Vendedor", "Comissao por Vendedor"})
        Me.cbo_opcoes.Location = New System.Drawing.Point(73, 16)
        Me.cbo_opcoes.Name = "cbo_opcoes"
        Me.cbo_opcoes.Size = New System.Drawing.Size(203, 24)
        Me.cbo_opcoes.TabIndex = 3
        '
        'PrintDocument1
        '
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Loja:"
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
        'lbl_carteira
        '
        Me.lbl_carteira.AutoSize = True
        Me.lbl_carteira.Location = New System.Drawing.Point(292, 19)
        Me.lbl_carteira.Name = "lbl_carteira"
        Me.lbl_carteira.Size = New System.Drawing.Size(42, 17)
        Me.lbl_carteira.TabIndex = 0
        Me.lbl_carteira.Text = "Cart.:"
        '
        'cbo_loja
        '
        Me.cbo_loja.BackColor = System.Drawing.Color.LightYellow
        Me.cbo_loja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_loja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_loja.FormattingEnabled = True
        Me.cbo_loja.Items.AddRange(New Object() {"01", "02", "03", "04"})
        Me.cbo_loja.Location = New System.Drawing.Point(59, 50)
        Me.cbo_loja.Name = "cbo_loja"
        Me.cbo_loja.Size = New System.Drawing.Size(420, 24)
        Me.cbo_loja.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.lbl_carteira)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cbo_tipo)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 62)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(462, 46)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Tipo:"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownHeight = 120
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.IntegralHeight = False
        Me.cbo_tipo.Items.AddRange(New Object() {"< TODOS >", "CH - Cheque", "BL - Boleto", "NP - N. Promissoria", "CR - Carnê", "CT - Cartão"})
        Me.cbo_tipo.Location = New System.Drawing.Point(73, 16)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(176, 24)
        Me.cbo_tipo.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Inicial:"
        '
        'pbox_impressora
        '
        Me.pbox_impressora.Image = Global.RTecSys.My.Resources.Resources.impressoraG
        Me.pbox_impressora.Location = New System.Drawing.Point(498, 30)
        Me.pbox_impressora.Name = "pbox_impressora"
        Me.pbox_impressora.Size = New System.Drawing.Size(121, 128)
        Me.pbox_impressora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbox_impressora.TabIndex = 4
        Me.pbox_impressora.TabStop = False
        '
        'grp_menu
        '
        Me.grp_menu.BackColor = System.Drawing.SystemColors.Control
        Me.grp_menu.Controls.Add(Me.pbox_impressora)
        Me.grp_menu.Controls.Add(Me.cbo_carteira)
        Me.grp_menu.Controls.Add(Me.grp_periodo)
        Me.grp_menu.Controls.Add(Me.GroupBox2)
        Me.grp_menu.Controls.Add(Me.GroupBox1)
        Me.grp_menu.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grp_menu.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_menu.Location = New System.Drawing.Point(10, 81)
        Me.grp_menu.Name = "grp_menu"
        Me.grp_menu.Size = New System.Drawing.Size(629, 164)
        Me.grp_menu.TabIndex = 11
        Me.grp_menu.TabStop = False
        Me.grp_menu.Text = "Relatórios"
        '
        'cbo_carteira
        '
        Me.cbo_carteira.DropDownHeight = 120
        Me.cbo_carteira.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_carteira.DropDownWidth = 180
        Me.cbo_carteira.Enabled = False
        Me.cbo_carteira.FormattingEnabled = True
        Me.cbo_carteira.IntegralHeight = False
        Me.cbo_carteira.Items.AddRange(New Object() {"00", "01"})
        Me.cbo_carteira.Location = New System.Drawing.Point(347, 78)
        Me.cbo_carteira.Name = "cbo_carteira"
        Me.cbo_carteira.Size = New System.Drawing.Size(116, 24)
        Me.cbo_carteira.TabIndex = 10
        '
        'grp_periodo
        '
        Me.grp_periodo.BackColor = System.Drawing.Color.Transparent
        Me.grp_periodo.Controls.Add(Me.dtp_final)
        Me.grp_periodo.Controls.Add(Me.Label3)
        Me.grp_periodo.Controls.Add(Me.dtp_inicial)
        Me.grp_periodo.Controls.Add(Me.Label2)
        Me.grp_periodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_periodo.Location = New System.Drawing.Point(7, 110)
        Me.grp_periodo.Name = "grp_periodo"
        Me.grp_periodo.Size = New System.Drawing.Size(462, 48)
        Me.grp_periodo.TabIndex = 12
        Me.grp_periodo.TabStop = False
        Me.grp_periodo.Text = "Período"
        '
        'dtp_final
        '
        Me.dtp_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_final.Location = New System.Drawing.Point(235, 17)
        Me.dtp_final.Name = "dtp_final"
        Me.dtp_final.Size = New System.Drawing.Size(100, 23)
        Me.dtp_final.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(187, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Final:"
        '
        'dtp_inicial
        '
        Me.dtp_inicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_inicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_inicial.Location = New System.Drawing.Point(59, 17)
        Me.dtp_inicial.Name = "dtp_inicial"
        Me.dtp_inicial.Size = New System.Drawing.Size(100, 23)
        Me.dtp_inicial.TabIndex = 14
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-5, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(658, 42)
        Me.Panel1.TabIndex = 57
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(237, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Frm_relatFinanPaga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 257)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbo_loja)
        Me.Controls.Add(Me.grp_menu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_relatFinanPaga"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatório Financeiro Pagamento"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pbox_impressora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_menu.ResumeLayout(False)
        Me.grp_periodo.ResumeLayout(False)
        Me.grp_periodo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_vendedor As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_opcoes As System.Windows.Forms.ComboBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents lbl_carteira As System.Windows.Forms.Label
    Friend WithEvents cbo_loja As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbox_impressora As System.Windows.Forms.PictureBox
    Friend WithEvents grp_menu As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_carteira As System.Windows.Forms.ComboBox
    Friend WithEvents grp_periodo As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_inicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
End Class
