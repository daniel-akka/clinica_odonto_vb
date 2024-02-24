<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Relatorio_002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Relatorio_002))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label26 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.cbo_relatorio = New System.Windows.Forms.ComboBox
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chk_zerados = New System.Windows.Forms.CheckBox
        Me.cbo_grupo = New System.Windows.Forms.ComboBox
        Me.lbl_grupo = New System.Windows.Forms.Label
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.txt_codPart = New System.Windows.Forms.TextBox
        Me.lbl_fornecedor = New System.Windows.Forms.Label
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Teal
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Location = New System.Drawing.Point(-2, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(581, 75)
        Me.Panel2.TabIndex = 11
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Wide Latin", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(429, 49)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(140, 18)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(181, 8)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(183, 59)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'cbo_relatorio
        '
        Me.cbo_relatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_relatorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_relatorio.FormattingEnabled = True
        Me.cbo_relatorio.Items.AddRange(New Object() {"Tabela de Precos C/ Saldo", "Tabela de Precos c/ Acrescimos", "Tabela de Precos p/ Grupo", "Relat. de produtos Abaixo do Minimo p/ Grupo", "Relatorio Geral de Produtos", "Relatorio de Produtos c/ Estoque", "Relatorio de Produtos s/ Estoque", "Relatorio de Produtos p/ Fornecedores"})
        Me.cbo_relatorio.Location = New System.Drawing.Point(67, 48)
        Me.cbo_relatorio.Name = "cbo_relatorio"
        Me.cbo_relatorio.Size = New System.Drawing.Size(353, 23)
        Me.cbo_relatorio.TabIndex = 1
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.PaleGreen
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 238)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(532, 20)
        Me.RichTextBox1.TabIndex = 20
        Me.RichTextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(164, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Selecione Relatório Desejado"
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_imprimir.Location = New System.Drawing.Point(476, 363)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(79, 45)
        Me.btn_imprimir.TabIndex = 5
        Me.btn_imprimir.Text = "&Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_zerados)
        Me.GroupBox1.Controls.Add(Me.cbo_grupo)
        Me.GroupBox1.Controls.Add(Me.lbl_grupo)
        Me.GroupBox1.Controls.Add(Me.txt_nomePart)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_codPart)
        Me.GroupBox1.Controls.Add(Me.lbl_fornecedor)
        Me.GroupBox1.Controls.Add(Me.RichTextBox1)
        Me.GroupBox1.Controls.Add(Me.cbo_relatorio)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 277)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chk_zerados
        '
        Me.chk_zerados.AutoSize = True
        Me.chk_zerados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_zerados.Location = New System.Drawing.Point(250, 165)
        Me.chk_zerados.Name = "chk_zerados"
        Me.chk_zerados.Size = New System.Drawing.Size(71, 19)
        Me.chk_zerados.TabIndex = 21
        Me.chk_zerados.Text = "Zerados"
        Me.chk_zerados.UseVisualStyleBackColor = True
        '
        'cbo_grupo
        '
        Me.cbo_grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_grupo.FormattingEnabled = True
        Me.cbo_grupo.Location = New System.Drawing.Point(78, 163)
        Me.cbo_grupo.Name = "cbo_grupo"
        Me.cbo_grupo.Size = New System.Drawing.Size(103, 21)
        Me.cbo_grupo.TabIndex = 4
        '
        'lbl_grupo
        '
        Me.lbl_grupo.AutoSize = True
        Me.lbl_grupo.Location = New System.Drawing.Point(15, 163)
        Me.lbl_grupo.Name = "lbl_grupo"
        Me.lbl_grupo.Size = New System.Drawing.Size(39, 13)
        Me.lbl_grupo.TabIndex = 17
        Me.lbl_grupo.Text = "Grupo:"
        '
        'txt_nomePart
        '
        Me.txt_nomePart.Location = New System.Drawing.Point(150, 129)
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(342, 20)
        Me.txt_nomePart.TabIndex = 3
        '
        'txt_codPart
        '
        Me.txt_codPart.Location = New System.Drawing.Point(78, 129)
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(65, 20)
        Me.txt_codPart.TabIndex = 2
        '
        'lbl_fornecedor
        '
        Me.lbl_fornecedor.AutoSize = True
        Me.lbl_fornecedor.Location = New System.Drawing.Point(15, 132)
        Me.lbl_fornecedor.Name = "lbl_fornecedor"
        Me.lbl_fornecedor.Size = New System.Drawing.Size(64, 13)
        Me.lbl_fornecedor.TabIndex = 14
        Me.lbl_fornecedor.Text = "Fornecedor:"
        '
        'PrintDocument1
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 362)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(458, 43)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Location = New System.Drawing.Point(10, 19)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(19, 13)
        Me.lbl_mensagem.TabIndex = 7
        Me.lbl_mensagem.Text = "    "
        '
        'Frm_Relatorio_002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 420)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.Panel2)
        Me.KeyPreview = True
        Me.Name = "Frm_Relatorio_002"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatorio de Estoque"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cbo_relatorio As System.Windows.Forms.ComboBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents lbl_grupo As System.Windows.Forms.Label
    Friend WithEvents lbl_fornecedor As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents cbo_grupo As System.Windows.Forms.ComboBox
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Friend WithEvents chk_zerados As System.Windows.Forms.CheckBox
End Class
