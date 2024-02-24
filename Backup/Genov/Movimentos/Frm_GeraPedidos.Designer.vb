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
        Me.dtg_pedidos = New System.Windows.Forms.DataGridView
        Me.btn_sair = New System.Windows.Forms.Button
        Me.btn_imprime = New System.Windows.Forms.Button
        Me.btn_boleto = New System.Windows.Forms.Button
        Me.btn_np = New System.Windows.Forms.Button
        Me.btn_busca = New System.Windows.Forms.Button
        Me.btn_exclui = New System.Windows.Forms.Button
        Me.btn_altera = New System.Windows.Forms.Button
        Me.btn_novo = New System.Windows.Forms.Button
        CType(Me.dtg_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_pedidos
        '
        Me.dtg_pedidos.AllowUserToAddRows = False
        Me.dtg_pedidos.AllowUserToDeleteRows = False
        Me.dtg_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_pedidos.Location = New System.Drawing.Point(-1, -2)
        Me.dtg_pedidos.Name = "dtg_pedidos"
        Me.dtg_pedidos.ReadOnly = True
        Me.dtg_pedidos.Size = New System.Drawing.Size(712, 363)
        Me.dtg_pedidos.TabIndex = 1
        '
        'btn_sair
        '
        Me.btn_sair.Image = Global.Genov.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sair.Location = New System.Drawing.Point(644, 368)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(65, 29)
        Me.btn_sair.TabIndex = 9
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'btn_imprime
        '
        Me.btn_imprime.Image = Global.Genov.My.Resources.Resources.Imprime
        Me.btn_imprime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_imprime.Location = New System.Drawing.Point(433, 368)
        Me.btn_imprime.Name = "btn_imprime"
        Me.btn_imprime.Size = New System.Drawing.Size(65, 29)
        Me.btn_imprime.TabIndex = 8
        Me.btn_imprime.Text = "&Imprime"
        Me.btn_imprime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprime.UseVisualStyleBackColor = True
        '
        'btn_boleto
        '
        Me.btn_boleto.Image = Global.Genov.My.Resources.Resources.Boleto_2_16x16
        Me.btn_boleto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_boleto.Location = New System.Drawing.Point(362, 368)
        Me.btn_boleto.Name = "btn_boleto"
        Me.btn_boleto.Size = New System.Drawing.Size(65, 29)
        Me.btn_boleto.TabIndex = 7
        Me.btn_boleto.Text = "Bole&to"
        Me.btn_boleto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_boleto.UseVisualStyleBackColor = True
        '
        'btn_np
        '
        Me.btn_np.Image = Global.Genov.My.Resources.Resources.disc_r
        Me.btn_np.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_np.Location = New System.Drawing.Point(292, 368)
        Me.btn_np.Name = "btn_np"
        Me.btn_np.Size = New System.Drawing.Size(65, 29)
        Me.btn_np.TabIndex = 6
        Me.btn_np.Text = "&Np"
        Me.btn_np.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_np.UseVisualStyleBackColor = True
        '
        'btn_busca
        '
        Me.btn_busca.Image = Global.Genov.My.Resources.Resources.Search
        Me.btn_busca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_busca.Location = New System.Drawing.Point(222, 368)
        Me.btn_busca.Name = "btn_busca"
        Me.btn_busca.Size = New System.Drawing.Size(65, 29)
        Me.btn_busca.TabIndex = 5
        Me.btn_busca.Text = "&Busca"
        Me.btn_busca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_busca.UseVisualStyleBackColor = True
        '
        'btn_exclui
        '
        Me.btn_exclui.Image = Global.Genov.My.Resources.Resources.Delete
        Me.btn_exclui.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_exclui.Location = New System.Drawing.Point(151, 367)
        Me.btn_exclui.Name = "btn_exclui"
        Me.btn_exclui.Size = New System.Drawing.Size(65, 29)
        Me.btn_exclui.TabIndex = 4
        Me.btn_exclui.Text = "&Exclui"
        Me.btn_exclui.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_exclui.UseVisualStyleBackColor = True
        '
        'btn_altera
        '
        Me.btn_altera.Image = Global.Genov.My.Resources.Resources.Modify
        Me.btn_altera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_altera.Location = New System.Drawing.Point(82, 368)
        Me.btn_altera.Name = "btn_altera"
        Me.btn_altera.Size = New System.Drawing.Size(65, 29)
        Me.btn_altera.TabIndex = 3
        Me.btn_altera.Text = "&Altera"
        Me.btn_altera.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_altera.UseVisualStyleBackColor = True
        '
        'btn_novo
        '
        Me.btn_novo.Image = Global.Genov.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_novo.Location = New System.Drawing.Point(12, 368)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(65, 29)
        Me.btn_novo.TabIndex = 2
        Me.btn_novo.Text = "&Novo"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = True
        '
        'Frm_GeraPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 409)
        Me.Controls.Add(Me.btn_sair)
        Me.Controls.Add(Me.btn_imprime)
        Me.Controls.Add(Me.btn_boleto)
        Me.Controls.Add(Me.btn_np)
        Me.Controls.Add(Me.btn_busca)
        Me.Controls.Add(Me.btn_exclui)
        Me.Controls.Add(Me.btn_altera)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.dtg_pedidos)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_GeraPedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Controle de Pedidos"
        CType(Me.dtg_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
