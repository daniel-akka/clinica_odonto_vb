<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConfigBD
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_serverBD = New System.Windows.Forms.TextBox()
        Me.grp_configBD = New System.Windows.Forms.GroupBox()
        Me.btn_salvar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_dataBaseBD = New System.Windows.Forms.TextBox()
        Me.txt_passwordBD = New System.Windows.Forms.TextBox()
        Me.txt_userIdBD = New System.Windows.Forms.TextBox()
        Me.txt_portBD = New System.Windows.Forms.TextBox()
        Me.grp_configBD.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Servidor:"
        '
        'txt_serverBD
        '
        Me.txt_serverBD.Location = New System.Drawing.Point(80, 28)
        Me.txt_serverBD.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_serverBD.MaxLength = 80
        Me.txt_serverBD.Name = "txt_serverBD"
        Me.txt_serverBD.Size = New System.Drawing.Size(272, 23)
        Me.txt_serverBD.TabIndex = 1
        Me.txt_serverBD.Text = "localhost"
        '
        'grp_configBD
        '
        Me.grp_configBD.Controls.Add(Me.btn_salvar)
        Me.grp_configBD.Controls.Add(Me.Label5)
        Me.grp_configBD.Controls.Add(Me.Label4)
        Me.grp_configBD.Controls.Add(Me.Label3)
        Me.grp_configBD.Controls.Add(Me.Label2)
        Me.grp_configBD.Controls.Add(Me.Label1)
        Me.grp_configBD.Controls.Add(Me.txt_dataBaseBD)
        Me.grp_configBD.Controls.Add(Me.txt_passwordBD)
        Me.grp_configBD.Controls.Add(Me.txt_userIdBD)
        Me.grp_configBD.Controls.Add(Me.txt_portBD)
        Me.grp_configBD.Controls.Add(Me.txt_serverBD)
        Me.grp_configBD.Location = New System.Drawing.Point(19, 6)
        Me.grp_configBD.Name = "grp_configBD"
        Me.grp_configBD.Size = New System.Drawing.Size(372, 185)
        Me.grp_configBD.TabIndex = 2
        Me.grp_configBD.TabStop = False
        Me.grp_configBD.Text = "Configurações"
        '
        'btn_salvar
        '
        Me.btn_salvar.Image = Global.RTecSys.My.Resources.Resources.salvar
        Me.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salvar.Location = New System.Drawing.Point(272, 143)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(80, 33)
        Me.btn_salvar.TabIndex = 3
        Me.btn_salvar.Text = "&Salvar"
        Me.btn_salvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 62)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Banco:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 124)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Senha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 93)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Usuário:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 155)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Porta:"
        '
        'txt_dataBaseBD
        '
        Me.txt_dataBaseBD.Location = New System.Drawing.Point(80, 59)
        Me.txt_dataBaseBD.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_dataBaseBD.MaxLength = 15
        Me.txt_dataBaseBD.Name = "txt_dataBaseBD"
        Me.txt_dataBaseBD.Size = New System.Drawing.Size(151, 23)
        Me.txt_dataBaseBD.TabIndex = 2
        Me.txt_dataBaseBD.Text = "BDMETROSYS"
        '
        'txt_passwordBD
        '
        Me.txt_passwordBD.Location = New System.Drawing.Point(80, 121)
        Me.txt_passwordBD.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_passwordBD.MaxLength = 15
        Me.txt_passwordBD.Name = "txt_passwordBD"
        Me.txt_passwordBD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_passwordBD.ReadOnly = True
        Me.txt_passwordBD.Size = New System.Drawing.Size(75, 23)
        Me.txt_passwordBD.TabIndex = 5
        Me.txt_passwordBD.Text = "Servnet"
        '
        'txt_userIdBD
        '
        Me.txt_userIdBD.Location = New System.Drawing.Point(80, 90)
        Me.txt_userIdBD.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_userIdBD.MaxLength = 20
        Me.txt_userIdBD.Name = "txt_userIdBD"
        Me.txt_userIdBD.ReadOnly = True
        Me.txt_userIdBD.Size = New System.Drawing.Size(132, 23)
        Me.txt_userIdBD.TabIndex = 4
        Me.txt_userIdBD.Text = "postgres"
        '
        'txt_portBD
        '
        Me.txt_portBD.Location = New System.Drawing.Point(80, 152)
        Me.txt_portBD.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_portBD.MaxLength = 4
        Me.txt_portBD.Name = "txt_portBD"
        Me.txt_portBD.ReadOnly = True
        Me.txt_portBD.Size = New System.Drawing.Size(75, 23)
        Me.txt_portBD.TabIndex = 6
        Me.txt_portBD.Text = "5432"
        '
        'Frm_ConfigBD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 204)
        Me.Controls.Add(Me.grp_configBD)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ConfigBD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuração do Banco de Dados"
        Me.grp_configBD.ResumeLayout(False)
        Me.grp_configBD.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_serverBD As System.Windows.Forms.TextBox
    Friend WithEvents grp_configBD As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_portBD As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_dataBaseBD As System.Windows.Forms.TextBox
    Friend WithEvents txt_passwordBD As System.Windows.Forms.TextBox
    Friend WithEvents txt_userIdBD As System.Windows.Forms.TextBox
    Friend WithEvents btn_salvar As System.Windows.Forms.Button
End Class
