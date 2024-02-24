<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MenuPagoaEntregar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MenuPagoaEntregar))
        Me.dtg_PagoaEntregar = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.btn_processo = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_requisicoes = New System.Windows.Forms.Button
        Me.btn_relatorios = New System.Windows.Forms.Button
        Me.btn_saldo = New System.Windows.Forms.Button
        Me.btn_extrato = New System.Windows.Forms.Button
        Me.btn_baixa = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.grb_data = New System.Windows.Forms.GroupBox
        Me.dtp_final = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtp_inicial = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_dtinicial = New System.Windows.Forms.Label
        CType(Me.dtg_PagoaEntregar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grb_data.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_PagoaEntregar
        '
        Me.dtg_PagoaEntregar.AllowUserToAddRows = False
        Me.dtg_PagoaEntregar.AllowUserToDeleteRows = False
        Me.dtg_PagoaEntregar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_PagoaEntregar.Location = New System.Drawing.Point(12, 75)
        Me.dtg_PagoaEntregar.Name = "dtg_PagoaEntregar"
        Me.dtg_PagoaEntregar.ReadOnly = True
        Me.dtg_PagoaEntregar.Size = New System.Drawing.Size(544, 427)
        Me.dtg_PagoaEntregar.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 508)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(763, 50)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Location = New System.Drawing.Point(6, 22)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(19, 13)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = "    "
        '
        'btn_processo
        '
        Me.btn_processo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_processo.Location = New System.Drawing.Point(8, 15)
        Me.btn_processo.Name = "btn_processo"
        Me.btn_processo.Size = New System.Drawing.Size(199, 47)
        Me.btn_processo.TabIndex = 2
        Me.btn_processo.Text = "&Processo Diario"
        Me.btn_processo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_requisicoes)
        Me.GroupBox2.Controls.Add(Me.btn_relatorios)
        Me.GroupBox2.Controls.Add(Me.btn_saldo)
        Me.GroupBox2.Controls.Add(Me.btn_extrato)
        Me.GroupBox2.Controls.Add(Me.btn_baixa)
        Me.GroupBox2.Controls.Add(Me.btn_processo)
        Me.GroupBox2.Location = New System.Drawing.Point(562, 65)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(213, 326)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'btn_requisicoes
        '
        Me.btn_requisicoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_requisicoes.Location = New System.Drawing.Point(8, 275)
        Me.btn_requisicoes.Name = "btn_requisicoes"
        Me.btn_requisicoes.Size = New System.Drawing.Size(199, 47)
        Me.btn_requisicoes.TabIndex = 6
        Me.btn_requisicoes.Text = "&Requisicoes"
        Me.btn_requisicoes.UseVisualStyleBackColor = True
        '
        'btn_relatorios
        '
        Me.btn_relatorios.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_relatorios.Location = New System.Drawing.Point(8, 225)
        Me.btn_relatorios.Name = "btn_relatorios"
        Me.btn_relatorios.Size = New System.Drawing.Size(199, 47)
        Me.btn_relatorios.TabIndex = 6
        Me.btn_relatorios.Text = "&Relatorios"
        Me.btn_relatorios.UseVisualStyleBackColor = True
        '
        'btn_saldo
        '
        Me.btn_saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_saldo.Location = New System.Drawing.Point(8, 174)
        Me.btn_saldo.Name = "btn_saldo"
        Me.btn_saldo.Size = New System.Drawing.Size(199, 47)
        Me.btn_saldo.TabIndex = 5
        Me.btn_saldo.Text = "&Saldo da Conta"
        Me.btn_saldo.UseVisualStyleBackColor = True
        '
        'btn_extrato
        '
        Me.btn_extrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_extrato.Location = New System.Drawing.Point(8, 121)
        Me.btn_extrato.Name = "btn_extrato"
        Me.btn_extrato.Size = New System.Drawing.Size(199, 47)
        Me.btn_extrato.TabIndex = 4
        Me.btn_extrato.Text = "&Extrato  de Movimento"
        Me.btn_extrato.UseVisualStyleBackColor = True
        '
        'btn_baixa
        '
        Me.btn_baixa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_baixa.Location = New System.Drawing.Point(8, 68)
        Me.btn_baixa.Name = "btn_baixa"
        Me.btn_baixa.Size = New System.Drawing.Size(199, 47)
        Me.btn_baixa.TabIndex = 3
        Me.btn_baixa.Text = "&Baixa Requisição"
        Me.btn_baixa.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 66)
        Me.Panel1.TabIndex = 43
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Wide Latin", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(625, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 19)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "MetroSys"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(273, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(187, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'grb_data
        '
        Me.grb_data.Controls.Add(Me.dtp_final)
        Me.grb_data.Controls.Add(Me.Label1)
        Me.grb_data.Controls.Add(Me.dtp_inicial)
        Me.grb_data.Controls.Add(Me.Label2)
        Me.grb_data.Controls.Add(Me.lbl_dtinicial)
        Me.grb_data.Location = New System.Drawing.Point(562, 397)
        Me.grb_data.Name = "grb_data"
        Me.grb_data.Size = New System.Drawing.Size(213, 105)
        Me.grb_data.TabIndex = 44
        Me.grb_data.TabStop = False
        '
        'dtp_final
        '
        Me.dtp_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_final.Location = New System.Drawing.Point(88, 73)
        Me.dtp_final.MaxDate = New Date(3000, 12, 31, 0, 0, 0, 0)
        Me.dtp_final.MinDate = New Date(1953, 1, 1, 0, 0, 0, 0)
        Me.dtp_final.Name = "dtp_final"
        Me.dtp_final.Size = New System.Drawing.Size(102, 21)
        Me.dtp_final.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Final:"
        '
        'dtp_inicial
        '
        Me.dtp_inicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_inicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_inicial.Location = New System.Drawing.Point(88, 42)
        Me.dtp_inicial.MaxDate = New Date(3000, 12, 31, 0, 0, 0, 0)
        Me.dtp_inicial.MinDate = New Date(1953, 1, 1, 0, 0, 0, 0)
        Me.dtp_inicial.Name = "dtp_inicial"
        Me.dtp_inicial.Size = New System.Drawing.Size(102, 21)
        Me.dtp_inicial.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(73, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Período"
        '
        'lbl_dtinicial
        '
        Me.lbl_dtinicial.AutoSize = True
        Me.lbl_dtinicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dtinicial.Location = New System.Drawing.Point(28, 45)
        Me.lbl_dtinicial.Name = "lbl_dtinicial"
        Me.lbl_dtinicial.Size = New System.Drawing.Size(53, 16)
        Me.lbl_dtinicial.TabIndex = 0
        Me.lbl_dtinicial.Text = "Inicial:"
        '
        'Frm_MenuPagoaEntregar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 570)
        Me.Controls.Add(Me.grb_data)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtg_PagoaEntregar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_MenuPagoaEntregar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Pago a Entregar - Contrôle de Movimentação de Clientes"
        CType(Me.dtg_PagoaEntregar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grb_data.ResumeLayout(False)
        Me.grb_data.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtg_PagoaEntregar As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_processo As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_saldo As System.Windows.Forms.Button
    Friend WithEvents btn_extrato As System.Windows.Forms.Button
    Friend WithEvents btn_baixa As System.Windows.Forms.Button
    Friend WithEvents btn_relatorios As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents grb_data As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_inicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_dtinicial As System.Windows.Forms.Label
    Friend WithEvents dtp_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_requisicoes As System.Windows.Forms.Button
End Class
