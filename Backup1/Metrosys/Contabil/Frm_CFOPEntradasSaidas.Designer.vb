<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CFOPEntradasSaidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CFOPEntradasSaidas))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.brn_consult = New System.Windows.Forms.Button
        Me.btn_novo = New System.Windows.Forms.Button
        Me.btn_excluir = New System.Windows.Forms.Button
        Me.btn_alterar = New System.Windows.Forms.Button
        Me.dtg_CFOPEntradas = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.mst_cfop = New System.Windows.Forms.MaskedTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_descricao = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_pesquisa = New System.Windows.Forms.TextBox
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.btn_VisualizaRel = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtg_CFOPEntradas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.brn_consult)
        Me.GroupBox2.Controls.Add(Me.btn_novo)
        Me.GroupBox2.Controls.Add(Me.btn_excluir)
        Me.GroupBox2.Controls.Add(Me.btn_alterar)
        Me.GroupBox2.Location = New System.Drawing.Point(472, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(88, 201)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'brn_consult
        '
        Me.brn_consult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.brn_consult.Image = Global.MetroSys.My.Resources.Resources.Busca_16x16
        Me.brn_consult.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.brn_consult.Location = New System.Drawing.Point(8, 12)
        Me.brn_consult.Name = "brn_consult"
        Me.brn_consult.Size = New System.Drawing.Size(72, 42)
        Me.brn_consult.TabIndex = 5
        Me.brn_consult.Text = "&Consulta"
        Me.brn_consult.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.brn_consult.UseVisualStyleBackColor = True
        '
        'btn_novo
        '
        Me.btn_novo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_novo.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_novo.Location = New System.Drawing.Point(8, 58)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(72, 42)
        Me.btn_novo.TabIndex = 6
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'btn_excluir
        '
        Me.btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_excluir.Location = New System.Drawing.Point(8, 150)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(72, 42)
        Me.btn_excluir.TabIndex = 8
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_excluir.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterar.Image = Global.MetroSys.My.Resources.Resources.Load
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterar.Location = New System.Drawing.Point(8, 105)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(72, 42)
        Me.btn_alterar.TabIndex = 7
        Me.btn_alterar.Text = "&Alterar"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'dtg_CFOPEntradas
        '
        Me.dtg_CFOPEntradas.AllowUserToAddRows = False
        Me.dtg_CFOPEntradas.AllowUserToDeleteRows = False
        Me.dtg_CFOPEntradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_CFOPEntradas.Location = New System.Drawing.Point(11, 132)
        Me.dtg_CFOPEntradas.Name = "dtg_CFOPEntradas"
        Me.dtg_CFOPEntradas.ReadOnly = True
        Me.dtg_CFOPEntradas.Size = New System.Drawing.Size(455, 392)
        Me.dtg_CFOPEntradas.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Consulta....:"
        '
        'mst_cfop
        '
        Me.mst_cfop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mst_cfop.Location = New System.Drawing.Point(71, 14)
        Me.mst_cfop.Mask = "9,999"
        Me.mst_cfop.Name = "mst_cfop"
        Me.mst_cfop.Size = New System.Drawing.Size(55, 21)
        Me.mst_cfop.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.mst_cfop)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_descricao)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(549, 73)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descrição:"
        '
        'txt_descricao
        '
        Me.txt_descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_descricao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descricao.Location = New System.Drawing.Point(69, 43)
        Me.txt_descricao.Name = "txt_descricao"
        Me.txt_descricao.Size = New System.Drawing.Size(386, 21)
        Me.txt_descricao.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CFOP.......:"
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(80, 100)
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(386, 21)
        Me.txt_pesquisa.TabIndex = 11
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
        'btn_VisualizaRel
        '
        Me.btn_VisualizaRel.Location = New System.Drawing.Point(477, 298)
        Me.btn_VisualizaRel.Name = "btn_VisualizaRel"
        Me.btn_VisualizaRel.Size = New System.Drawing.Size(75, 37)
        Me.btn_VisualizaRel.TabIndex = 16
        Me.btn_VisualizaRel.Text = "&Imprime"
        Me.btn_VisualizaRel.UseVisualStyleBackColor = True
        '
        'Frm_CFOPEntradasSaidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 537)
        Me.Controls.Add(Me.btn_VisualizaRel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dtg_CFOPEntradas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_CFOPEntradasSaidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção no CFOP de Entradas"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dtg_CFOPEntradas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents brn_consult As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents dtg_CFOPEntradas As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents mst_cfop As System.Windows.Forms.MaskedTextBox
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_descricao As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents btn_VisualizaRel As System.Windows.Forms.Button
End Class
