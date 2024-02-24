<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GeraNotasFiscais
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GeraNotasFiscais))
        Me.dtg_nfe = New System.Windows.Forms.DataGridView
        Me.nt_x = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_emissao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_cnpj_cpf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_portador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_chave = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_proto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nt_usu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_outrasnfe = New System.Windows.Forms.Button
        Me.btn_exclui = New System.Windows.Forms.Button
        Me.btn_recibo = New System.Windows.Forms.Button
        Me.btn_imprime = New System.Windows.Forms.Button
        Me.btn_nfe = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.PorPeriodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PorCNPJCPFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PorClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        CType(Me.dtg_nfe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_nfe
        '
        Me.dtg_nfe.AllowUserToAddRows = False
        Me.dtg_nfe.AllowUserToDeleteRows = False
        Me.dtg_nfe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_nfe.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nt_x, Me.nt_Codigo, Me.nt_emissao, Me.nt_cnpj_cpf, Me.nt_portador, Me.nt_chave, Me.nt_proto, Me.nt_usu})
        Me.dtg_nfe.Location = New System.Drawing.Point(11, 68)
        Me.dtg_nfe.Name = "dtg_nfe"
        Me.dtg_nfe.ReadOnly = True
        Me.dtg_nfe.Size = New System.Drawing.Size(729, 390)
        Me.dtg_nfe.TabIndex = 5
        '
        'nt_x
        '
        Me.nt_x.HeaderText = "ST"
        Me.nt_x.MaxInputLength = 1
        Me.nt_x.Name = "nt_x"
        Me.nt_x.ReadOnly = True
        Me.nt_x.Width = 25
        '
        'nt_Codigo
        '
        Me.nt_Codigo.HeaderText = "Codigo"
        Me.nt_Codigo.Name = "nt_Codigo"
        Me.nt_Codigo.ReadOnly = True
        Me.nt_Codigo.Width = 60
        '
        'nt_emissao
        '
        Me.nt_emissao.HeaderText = "DTEmissão"
        Me.nt_emissao.MaxInputLength = 10
        Me.nt_emissao.Name = "nt_emissao"
        Me.nt_emissao.ReadOnly = True
        '
        'nt_cnpj_cpf
        '
        Me.nt_cnpj_cpf.HeaderText = "Cnpj_Cpf"
        Me.nt_cnpj_cpf.MaxInputLength = 14
        Me.nt_cnpj_cpf.Name = "nt_cnpj_cpf"
        Me.nt_cnpj_cpf.ReadOnly = True
        Me.nt_cnpj_cpf.Width = 120
        '
        'nt_portador
        '
        Me.nt_portador.HeaderText = "Cliente"
        Me.nt_portador.MaxInputLength = 40
        Me.nt_portador.Name = "nt_portador"
        Me.nt_portador.ReadOnly = True
        Me.nt_portador.Width = 250
        '
        'nt_chave
        '
        Me.nt_chave.HeaderText = "Chave"
        Me.nt_chave.MaxInputLength = 44
        Me.nt_chave.Name = "nt_chave"
        Me.nt_chave.ReadOnly = True
        Me.nt_chave.Width = 180
        '
        'nt_proto
        '
        Me.nt_proto.HeaderText = "Protocolo"
        Me.nt_proto.MaxInputLength = 15
        Me.nt_proto.Name = "nt_proto"
        Me.nt_proto.ReadOnly = True
        Me.nt_proto.Width = 150
        '
        'nt_usu
        '
        Me.nt_usu.HeaderText = "Usuario"
        Me.nt_usu.Name = "nt_usu"
        Me.nt_usu.ReadOnly = True
        Me.nt_usu.Width = 60
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_outrasnfe)
        Me.GroupBox1.Controls.Add(Me.btn_exclui)
        Me.GroupBox1.Controls.Add(Me.btn_recibo)
        Me.GroupBox1.Controls.Add(Me.btn_imprime)
        Me.GroupBox1.Controls.Add(Me.btn_nfe)
        Me.GroupBox1.Location = New System.Drawing.Point(435, 464)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 54)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'btn_outrasnfe
        '
        Me.btn_outrasnfe.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_outrasnfe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_outrasnfe.Location = New System.Drawing.Point(67, 10)
        Me.btn_outrasnfe.Name = "btn_outrasnfe"
        Me.btn_outrasnfe.Size = New System.Drawing.Size(53, 39)
        Me.btn_outrasnfe.TabIndex = 14
        Me.btn_outrasnfe.Text = "&Outras"
        Me.btn_outrasnfe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_outrasnfe.UseVisualStyleBackColor = True
        '
        'btn_exclui
        '
        Me.btn_exclui.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_exclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exclui.Location = New System.Drawing.Point(128, 9)
        Me.btn_exclui.Name = "btn_exclui"
        Me.btn_exclui.Size = New System.Drawing.Size(53, 39)
        Me.btn_exclui.TabIndex = 13
        Me.btn_exclui.Text = "&Exclui"
        Me.btn_exclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exclui.UseVisualStyleBackColor = True
        '
        'btn_recibo
        '
        Me.btn_recibo.Image = Global.MetroSys.My.Resources.Resources.Modify
        Me.btn_recibo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_recibo.Location = New System.Drawing.Point(246, 10)
        Me.btn_recibo.Name = "btn_recibo"
        Me.btn_recibo.Size = New System.Drawing.Size(53, 39)
        Me.btn_recibo.TabIndex = 12
        Me.btn_recibo.Text = "&Recibo"
        Me.btn_recibo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_recibo.UseVisualStyleBackColor = True
        '
        'btn_imprime
        '
        Me.btn_imprime.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_imprime.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprime.Location = New System.Drawing.Point(187, 10)
        Me.btn_imprime.Name = "btn_imprime"
        Me.btn_imprime.Size = New System.Drawing.Size(53, 39)
        Me.btn_imprime.TabIndex = 11
        Me.btn_imprime.Text = "&Imprime"
        Me.btn_imprime.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprime.UseVisualStyleBackColor = True
        '
        'btn_nfe
        '
        Me.btn_nfe.Image = Global.MetroSys.My.Resources.Resources.NFe
        Me.btn_nfe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nfe.Location = New System.Drawing.Point(7, 10)
        Me.btn_nfe.Name = "btn_nfe"
        Me.btn_nfe.Size = New System.Drawing.Size(53, 39)
        Me.btn_nfe.TabIndex = 9
        Me.btn_nfe.Text = "&NFe"
        Me.btn_nfe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nfe.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("Wide Latin", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(615, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Genov"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(754, 67)
        Me.Panel1.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(312, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripDropDownButton1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 527)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(753, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(63, 17)
        Me.ToolStripStatusLabel1.Text = "Consultas"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PorPeriodoToolStripMenuItem, Me.PorCNPJCPFToolStripMenuItem, Me.PorClienteToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 20)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'PorPeriodoToolStripMenuItem
        '
        Me.PorPeriodoToolStripMenuItem.Name = "PorPeriodoToolStripMenuItem"
        Me.PorPeriodoToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PorPeriodoToolStripMenuItem.Text = "Por Periodo"
        '
        'PorCNPJCPFToolStripMenuItem
        '
        Me.PorCNPJCPFToolStripMenuItem.Name = "PorCNPJCPFToolStripMenuItem"
        Me.PorCNPJCPFToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PorCNPJCPFToolStripMenuItem.Text = "Por CNPJ/CPF "
        '
        'PorClienteToolStripMenuItem
        '
        Me.PorClienteToolStripMenuItem.Name = "PorClienteToolStripMenuItem"
        Me.PorClienteToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PorClienteToolStripMenuItem.Text = "Por Cliente"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 464)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(417, 54)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Location = New System.Drawing.Point(15, 24)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(0, 13)
        Me.lbl_mensagem.TabIndex = 0
        '
        'Frm_GeraNotasFiscais
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 549)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtg_nfe)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_GeraNotasFiscais"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gerênciador de Notas Fiscais Eletrônicas"
        CType(Me.dtg_nfe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_nfe As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents btn_imprime As System.Windows.Forms.Button
    Public WithEvents btn_nfe As System.Windows.Forms.Button
    Friend WithEvents btn_recibo As System.Windows.Forms.Button
    Public WithEvents btn_exclui As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents PorClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PorPeriodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents PorCNPJCPFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents nt_x As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_emissao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_cnpj_cpf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_portador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_chave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_proto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nt_usu As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents btn_outrasnfe As System.Windows.Forms.Button
End Class
