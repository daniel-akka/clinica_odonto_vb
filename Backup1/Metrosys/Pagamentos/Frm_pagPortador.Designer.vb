<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_pagPortador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_pagPortador))
        Me.dtg_posicaoport = New System.Windows.Forms.DataGridView
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbo_opcoes = New System.Windows.Forms.ComboBox
        Me.txt_nomePart = New System.Windows.Forms.TextBox
        Me.cbo_tipo = New System.Windows.Forms.ComboBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.grp_btn = New System.Windows.Forms.GroupBox
        Me.btn_pesquisa = New System.Windows.Forms.Button
        Me.btn_relatorio = New System.Windows.Forms.Button
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_totais = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_codPart = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        CType(Me.dtg_posicaoport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.grp_btn.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_posicaoport
        '
        Me.dtg_posicaoport.AllowUserToAddRows = False
        Me.dtg_posicaoport.AllowUserToDeleteRows = False
        Me.dtg_posicaoport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_posicaoport.Location = New System.Drawing.Point(7, 168)
        Me.dtg_posicaoport.Name = "dtg_posicaoport"
        Me.dtg_posicaoport.ReadOnly = True
        Me.dtg_posicaoport.Size = New System.Drawing.Size(695, 379)
        Me.dtg_posicaoport.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label8.Font = New System.Drawing.Font("Wide Latin", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(469, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 19)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "MetroSys"
        '
        'cbo_opcoes
        '
        Me.cbo_opcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_opcoes.FormattingEnabled = True
        Me.cbo_opcoes.Items.AddRange(New Object() {"Em Aberto", "Quitados", "Devolvidos", "Todos", "Vencidos"})
        Me.cbo_opcoes.Location = New System.Drawing.Point(62, 48)
        Me.cbo_opcoes.Name = "cbo_opcoes"
        Me.cbo_opcoes.Size = New System.Drawing.Size(121, 21)
        Me.cbo_opcoes.TabIndex = 3
        '
        'txt_nomePart
        '
        Me.txt_nomePart.Location = New System.Drawing.Point(132, 16)
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(449, 20)
        Me.txt_nomePart.TabIndex = 2
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"TODOS", "CH - Cheque", "BL - Boleto", "NP - N. Promissoria", "CR - Carnê", "CT - Cartão"})
        Me.cbo_tipo.Location = New System.Drawing.Point(243, 48)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(106, 21)
        Me.cbo_tipo.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(243, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(181, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(717, 74)
        Me.Panel1.TabIndex = 22
        '
        'grp_btn
        '
        Me.grp_btn.Controls.Add(Me.btn_pesquisa)
        Me.grp_btn.Controls.Add(Me.btn_relatorio)
        Me.grp_btn.Location = New System.Drawing.Point(370, 38)
        Me.grp_btn.Name = "grp_btn"
        Me.grp_btn.Size = New System.Drawing.Size(179, 43)
        Me.grp_btn.TabIndex = 8
        Me.grp_btn.TabStop = False
        '
        'btn_pesquisa
        '
        Me.btn_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pesquisa.Location = New System.Drawing.Point(6, 10)
        Me.btn_pesquisa.Name = "btn_pesquisa"
        Me.btn_pesquisa.Size = New System.Drawing.Size(75, 30)
        Me.btn_pesquisa.TabIndex = 4
        Me.btn_pesquisa.Text = "&Buscar"
        Me.btn_pesquisa.UseVisualStyleBackColor = True
        '
        'btn_relatorio
        '
        Me.btn_relatorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_relatorio.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_relatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_relatorio.Location = New System.Drawing.Point(87, 10)
        Me.btn_relatorio.Name = "btn_relatorio"
        Me.btn_relatorio.Size = New System.Drawing.Size(86, 30)
        Me.btn_relatorio.TabIndex = 7
        Me.btn_relatorio.Text = "Relatorio"
        Me.btn_relatorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_relatorio.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_totais)
        Me.GroupBox2.Location = New System.Drawing.Point(555, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(134, 38)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Em Aberto"
        '
        'lbl_totais
        '
        Me.lbl_totais.AutoSize = True
        Me.lbl_totais.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbl_totais.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_totais.ForeColor = System.Drawing.Color.Red
        Me.lbl_totais.Location = New System.Drawing.Point(24, 17)
        Me.lbl_totais.Name = "lbl_totais"
        Me.lbl_totais.Size = New System.Drawing.Size(35, 15)
        Me.lbl_totais.TabIndex = 0
        Me.lbl_totais.Text = "0,00"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grp_btn)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cbo_tipo)
        Me.GroupBox1.Controls.Add(Me.cbo_opcoes)
        Me.GroupBox1.Controls.Add(Me.txt_nomePart)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_codPart)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 73)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(695, 89)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(206, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Tipo:"
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Location = New System.Drawing.Point(62, 16)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(64, 20)
        Me.txt_codPart.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Opções:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CodCli:"
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
        'Frm_pagPortador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 558)
        Me.Controls.Add(Me.dtg_posicaoport)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_pagPortador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagamento Portador"
        CType(Me.dtg_posicaoport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grp_btn.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtg_posicaoport As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbo_opcoes As System.Windows.Forms.ComboBox
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grp_btn As System.Windows.Forms.GroupBox
    Friend WithEvents btn_pesquisa As System.Windows.Forms.Button
    Friend WithEvents btn_relatorio As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_totais As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
End Class
