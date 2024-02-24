<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GeraPedidos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GeraPedidos))
        Me.dtg_pedidos = New System.Windows.Forms.DataGridView
        Me.btn_sair = New System.Windows.Forms.Button
        Me.btn_imprime = New System.Windows.Forms.Button
        Me.btn_boleto = New System.Windows.Forms.Button
        Me.btn_np = New System.Windows.Forms.Button
        Me.btn_busca = New System.Windows.Forms.Button
        Me.btn_exclui = New System.Windows.Forms.Button
        Me.btn_altera = New System.Windows.Forms.Button
        Me.btn_novo = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        CType(Me.dtg_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_pedidos
        '
        Me.dtg_pedidos.AllowUserToAddRows = False
        Me.dtg_pedidos.AllowUserToDeleteRows = False
        Me.dtg_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_pedidos.Location = New System.Drawing.Point(9, 70)
        Me.dtg_pedidos.Name = "dtg_pedidos"
        Me.dtg_pedidos.ReadOnly = True
        Me.dtg_pedidos.Size = New System.Drawing.Size(829, 461)
        Me.dtg_pedidos.TabIndex = 1
        '
        'btn_sair
        '
        Me.btn_sair.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sair.Location = New System.Drawing.Point(9, 12)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(65, 33)
        Me.btn_sair.TabIndex = 9
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'btn_imprime
        '
        Me.btn_imprime.Image = Global.MetroSys.My.Resources.Resources.Imprime
        Me.btn_imprime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_imprime.Location = New System.Drawing.Point(426, 12)
        Me.btn_imprime.Name = "btn_imprime"
        Me.btn_imprime.Size = New System.Drawing.Size(65, 33)
        Me.btn_imprime.TabIndex = 8
        Me.btn_imprime.Text = "&Imprime"
        Me.btn_imprime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprime.UseVisualStyleBackColor = True
        '
        'btn_boleto
        '
        Me.btn_boleto.Image = CType(resources.GetObject("btn_boleto.Image"), System.Drawing.Image)
        Me.btn_boleto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_boleto.Location = New System.Drawing.Point(357, 13)
        Me.btn_boleto.Name = "btn_boleto"
        Me.btn_boleto.Size = New System.Drawing.Size(65, 33)
        Me.btn_boleto.TabIndex = 7
        Me.btn_boleto.Text = "Bole&to"
        Me.btn_boleto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_boleto.UseVisualStyleBackColor = True
        '
        'btn_np
        '
        Me.btn_np.Image = Global.MetroSys.My.Resources.Resources.disc_r
        Me.btn_np.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_np.Location = New System.Drawing.Point(287, 13)
        Me.btn_np.Name = "btn_np"
        Me.btn_np.Size = New System.Drawing.Size(65, 33)
        Me.btn_np.TabIndex = 6
        Me.btn_np.Text = "&Np"
        Me.btn_np.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_np.UseVisualStyleBackColor = True
        '
        'btn_busca
        '
        Me.btn_busca.Image = Global.MetroSys.My.Resources.Resources.Search
        Me.btn_busca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_busca.Location = New System.Drawing.Point(217, 13)
        Me.btn_busca.Name = "btn_busca"
        Me.btn_busca.Size = New System.Drawing.Size(65, 33)
        Me.btn_busca.TabIndex = 5
        Me.btn_busca.Text = "&Busca"
        Me.btn_busca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_busca.UseVisualStyleBackColor = True
        '
        'btn_exclui
        '
        Me.btn_exclui.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_exclui.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_exclui.Location = New System.Drawing.Point(146, 12)
        Me.btn_exclui.Name = "btn_exclui"
        Me.btn_exclui.Size = New System.Drawing.Size(65, 33)
        Me.btn_exclui.TabIndex = 4
        Me.btn_exclui.Text = "&Exclui"
        Me.btn_exclui.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_exclui.UseVisualStyleBackColor = True
        '
        'btn_altera
        '
        Me.btn_altera.Image = Global.MetroSys.My.Resources.Resources.Modify
        Me.btn_altera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_altera.Location = New System.Drawing.Point(77, 13)
        Me.btn_altera.Name = "btn_altera"
        Me.btn_altera.Size = New System.Drawing.Size(65, 33)
        Me.btn_altera.TabIndex = 3
        Me.btn_altera.Text = "&Altera"
        Me.btn_altera.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_altera.UseVisualStyleBackColor = True
        '
        'btn_novo
        '
        Me.btn_novo.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_novo.Location = New System.Drawing.Point(7, 13)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(65, 33)
        Me.btn_novo.TabIndex = 2
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(852, 66)
        Me.Panel1.TabIndex = 37
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Wide Latin", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(661, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(184, 24)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(283, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(187, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_exclui)
        Me.GroupBox1.Controls.Add(Me.btn_novo)
        Me.GroupBox1.Controls.Add(Me.btn_altera)
        Me.GroupBox1.Controls.Add(Me.btn_imprime)
        Me.GroupBox1.Controls.Add(Me.btn_busca)
        Me.GroupBox1.Controls.Add(Me.btn_boleto)
        Me.GroupBox1.Controls.Add(Me.btn_np)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 531)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(495, 52)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_sair)
        Me.GroupBox2.Location = New System.Drawing.Point(753, 531)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(85, 47)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        '
        'Frm_GeraPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 602)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtg_pedidos)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_GeraPedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista Pedidos"
        CType(Me.dtg_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Public WithEvents dtg_pedidos As System.Windows.Forms.DataGridView
    Public WithEvents btn_novo As System.Windows.Forms.Button
    Public WithEvents btn_altera As System.Windows.Forms.Button
    Public WithEvents btn_exclui As System.Windows.Forms.Button
    Public WithEvents btn_busca As System.Windows.Forms.Button
    Public WithEvents btn_np As System.Windows.Forms.Button
    Public WithEvents btn_boleto As System.Windows.Forms.Button
    Public WithEvents btn_imprime As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
