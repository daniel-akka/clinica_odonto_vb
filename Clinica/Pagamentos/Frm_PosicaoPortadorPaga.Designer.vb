<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PosicaoPortadorPaga
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PosicaoPortadorPaga))
        Me.dtg_posicaoport = New System.Windows.Forms.DataGridView()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grp_btn = New System.Windows.Forms.GroupBox()
        Me.btn_pesquisa = New System.Windows.Forms.Button()
        Me.btn_relatorio = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_totais = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.cbo_opcoes = New System.Windows.Forms.ComboBox()
        Me.txt_nomePart = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_codPart = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_NomeSys = New System.Windows.Forms.Label()
        CType(Me.dtg_posicaoport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grp_btn.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_posicaoport
        '
        Me.dtg_posicaoport.AllowUserToAddRows = False
        Me.dtg_posicaoport.AllowUserToDeleteRows = False
        Me.dtg_posicaoport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_posicaoport.Location = New System.Drawing.Point(7, 165)
        Me.dtg_posicaoport.Name = "dtg_posicaoport"
        Me.dtg_posicaoport.ReadOnly = True
        Me.dtg_posicaoport.Size = New System.Drawing.Size(715, 354)
        Me.dtg_posicaoport.TabIndex = 21
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
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
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(715, 116)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'grp_btn
        '
        Me.grp_btn.Controls.Add(Me.btn_pesquisa)
        Me.grp_btn.Controls.Add(Me.btn_relatorio)
        Me.grp_btn.Location = New System.Drawing.Point(495, 55)
        Me.grp_btn.Name = "grp_btn"
        Me.grp_btn.Size = New System.Drawing.Size(214, 53)
        Me.grp_btn.TabIndex = 8
        Me.grp_btn.TabStop = False
        '
        'btn_pesquisa
        '
        Me.btn_pesquisa.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn_pesquisa.Image = Global.RTecSys.My.Resources.Resources.Busca_16x161
        Me.btn_pesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_pesquisa.Location = New System.Drawing.Point(8, 12)
        Me.btn_pesquisa.Name = "btn_pesquisa"
        Me.btn_pesquisa.Size = New System.Drawing.Size(86, 37)
        Me.btn_pesquisa.TabIndex = 4
        Me.btn_pesquisa.Text = "&Buscar"
        Me.btn_pesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pesquisa.UseVisualStyleBackColor = True
        '
        'btn_relatorio
        '
        Me.btn_relatorio.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_relatorio.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_relatorio.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_relatorio.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_relatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_relatorio.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_relatorio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_relatorio.Image = Global.RTecSys.My.Resources.Resources.Imprime
        Me.btn_relatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_relatorio.Location = New System.Drawing.Point(100, 13)
        Me.btn_relatorio.Name = "btn_relatorio"
        Me.btn_relatorio.Size = New System.Drawing.Size(106, 36)
        Me.btn_relatorio.TabIndex = 7
        Me.btn_relatorio.Text = "Relatorio"
        Me.btn_relatorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_relatorio.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_totais)
        Me.GroupBox2.Location = New System.Drawing.Point(575, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(134, 40)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Total Geral"
        '
        'lbl_totais
        '
        Me.lbl_totais.AutoSize = True
        Me.lbl_totais.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbl_totais.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_totais.ForeColor = System.Drawing.Color.Red
        Me.lbl_totais.Location = New System.Drawing.Point(24, 20)
        Me.lbl_totais.Name = "lbl_totais"
        Me.lbl_totais.Size = New System.Drawing.Size(35, 15)
        Me.lbl_totais.TabIndex = 0
        Me.lbl_totais.Text = "0,00"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"TODOS", "CH - Cheque", "BL - Boleto", "NP - N. Promissoria", "CR - Carnê", "CT - Cartão", "DN - Dinheiro"})
        Me.cbo_tipo.Location = New System.Drawing.Point(306, 73)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(148, 24)
        Me.cbo_tipo.TabIndex = 4
        '
        'cbo_opcoes
        '
        Me.cbo_opcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_opcoes.FormattingEnabled = True
        Me.cbo_opcoes.Items.AddRange(New Object() {"Em Aberto", "Quitados", "Devolvidos", "Todos", "Vencidos", "Estornados"})
        Me.cbo_opcoes.Location = New System.Drawing.Point(70, 73)
        Me.cbo_opcoes.Name = "cbo_opcoes"
        Me.cbo_opcoes.Size = New System.Drawing.Size(148, 24)
        Me.cbo_opcoes.TabIndex = 3
        '
        'txt_nomePart
        '
        Me.txt_nomePart.BackColor = System.Drawing.SystemColors.Info
        Me.txt_nomePart.Location = New System.Drawing.Point(147, 26)
        Me.txt_nomePart.Name = "txt_nomePart"
        Me.txt_nomePart.ReadOnly = True
        Me.txt_nomePart.Size = New System.Drawing.Size(418, 23)
        Me.txt_nomePart.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(260, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Tipo:"
        '
        'txt_codPart
        '
        Me.txt_codPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codPart.Location = New System.Drawing.Point(70, 26)
        Me.txt_codPart.MaxLength = 6
        Me.txt_codPart.Name = "txt_codPart"
        Me.txt_codPart.Size = New System.Drawing.Size(71, 23)
        Me.txt_codPart.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Opções:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CodCli:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lbl_NomeSys)
        Me.Panel1.Location = New System.Drawing.Point(-8, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(751, 42)
        Me.Panel1.TabIndex = 55
        '
        'lbl_NomeSys
        '
        Me.lbl_NomeSys.AutoSize = True
        Me.lbl_NomeSys.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NomeSys.ForeColor = System.Drawing.Color.Beige
        Me.lbl_NomeSys.Location = New System.Drawing.Point(307, 1)
        Me.lbl_NomeSys.Name = "lbl_NomeSys"
        Me.lbl_NomeSys.Size = New System.Drawing.Size(92, 36)
        Me.lbl_NomeSys.TabIndex = 0
        Me.lbl_NomeSys.Text = "-------"
        '
        'Frm_PosicaoPortadorPaga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 530)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtg_posicaoport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_PosicaoPortadorPaga"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Posição do Portador"
        CType(Me.dtg_posicaoport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp_btn.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtg_posicaoport As System.Windows.Forms.DataGridView
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grp_btn As System.Windows.Forms.GroupBox
    Friend WithEvents btn_pesquisa As System.Windows.Forms.Button
    Friend WithEvents btn_relatorio As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_totais As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_opcoes As System.Windows.Forms.ComboBox
    Public WithEvents txt_nomePart As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents txt_codPart As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NomeSys As System.Windows.Forms.Label
End Class
