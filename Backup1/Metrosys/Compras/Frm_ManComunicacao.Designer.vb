<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManComunicacao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManComunicacao))
        Me.dtg_manservicos = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_altera = New System.Windows.Forms.Button
        Me.btn_sair = New System.Windows.Forms.Button
        Me.btn_inclui = New System.Windows.Forms.Button
        Me.btn_exclui = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.dtg_manservicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_manservicos
        '
        Me.dtg_manservicos.AllowUserToAddRows = False
        Me.dtg_manservicos.AllowUserToDeleteRows = False
        Me.dtg_manservicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_manservicos.Location = New System.Drawing.Point(5, 12)
        Me.dtg_manservicos.Name = "dtg_manservicos"
        Me.dtg_manservicos.ReadOnly = True
        Me.dtg_manservicos.Size = New System.Drawing.Size(591, 461)
        Me.dtg_manservicos.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_altera)
        Me.GroupBox1.Controls.Add(Me.btn_sair)
        Me.GroupBox1.Controls.Add(Me.btn_inclui)
        Me.GroupBox1.Controls.Add(Me.btn_exclui)
        Me.GroupBox1.Location = New System.Drawing.Point(602, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(101, 201)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'btn_altera
        '
        Me.btn_altera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_altera.Image = Global.MetroSys.My.Resources.Resources.Load
        Me.btn_altera.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_altera.Location = New System.Drawing.Point(6, 60)
        Me.btn_altera.Name = "btn_altera"
        Me.btn_altera.Size = New System.Drawing.Size(89, 40)
        Me.btn_altera.TabIndex = 2
        Me.btn_altera.Text = "&Altera  [F3]"
        Me.btn_altera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_altera.UseVisualStyleBackColor = True
        '
        'btn_sair
        '
        Me.btn_sair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sair.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_sair.Location = New System.Drawing.Point(6, 154)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(89, 40)
        Me.btn_sair.TabIndex = 4
        Me.btn_sair.Text = "&Sai    [ESC]"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'btn_inclui
        '
        Me.btn_inclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_inclui.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_inclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_inclui.Location = New System.Drawing.Point(6, 14)
        Me.btn_inclui.Name = "btn_inclui"
        Me.btn_inclui.Size = New System.Drawing.Size(89, 40)
        Me.btn_inclui.TabIndex = 1
        Me.btn_inclui.Text = "&Inclui  [F2]"
        Me.btn_inclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_inclui.UseVisualStyleBackColor = True
        '
        'btn_exclui
        '
        Me.btn_exclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exclui.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_exclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exclui.Location = New System.Drawing.Point(6, 107)
        Me.btn_exclui.Name = "btn_exclui"
        Me.btn_exclui.Size = New System.Drawing.Size(89, 40)
        Me.btn_exclui.TabIndex = 3
        Me.btn_exclui.Text = "&Exclui  [F4]"
        Me.btn_exclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exclui.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(615, 391)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(88, 82)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Frm_ManComunicacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 485)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtg_manservicos)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ManComunicacao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção de Serviços de Comunicacao"
        CType(Me.dtg_manservicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtg_manservicos As System.Windows.Forms.DataGridView
    Friend WithEvents btn_inclui As System.Windows.Forms.Button
    Friend WithEvents btn_altera As System.Windows.Forms.Button
    Friend WithEvents btn_exclui As System.Windows.Forms.Button
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
