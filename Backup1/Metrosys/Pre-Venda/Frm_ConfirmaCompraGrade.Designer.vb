<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConfirmaCompraGrade
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_cores = New System.Windows.Forms.ComboBox
        Me.txt_tamanho = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.btn_ok = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Crimson
        Me.Label1.Location = New System.Drawing.Point(34, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Produto de Grade"
        '
        'cbo_cores
        '
        Me.cbo_cores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_cores.FormattingEnabled = True
        Me.cbo_cores.Items.AddRange(New Object() {"Amarelo", "Azul", "Braco", "Creme", "Marrom", "Nenhum", "Preto", "Rosa", "Verde", "Vermelho"})
        Me.cbo_cores.Location = New System.Drawing.Point(44, 48)
        Me.cbo_cores.Name = "cbo_cores"
        Me.cbo_cores.Size = New System.Drawing.Size(85, 21)
        Me.cbo_cores.Sorted = True
        Me.cbo_cores.TabIndex = 4
        '
        'txt_tamanho
        '
        Me.txt_tamanho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_tamanho.Location = New System.Drawing.Point(44, 19)
        Me.txt_tamanho.MaxLength = 2
        Me.txt_tamanho.Name = "txt_tamanho"
        Me.txt_tamanho.Size = New System.Drawing.Size(30, 20)
        Me.txt_tamanho.TabIndex = 2
        Me.txt_tamanho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(13, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(26, 13)
        Me.Label22.TabIndex = 87
        Me.Label22.Text = "Cor:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(12, 22)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(26, 13)
        Me.Label23.TabIndex = 86
        Me.Label23.Text = "TM:"
        '
        'btn_ok
        '
        Me.btn_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok.Image = Global.MetroSys.My.Resources.Resources.accept001
        Me.btn_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ok.Location = New System.Drawing.Point(151, 13)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(77, 61)
        Me.btn_ok.TabIndex = 6
        Me.btn_ok.Text = "&Ok"
        Me.btn_ok.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_ok)
        Me.GroupBox1.Controls.Add(Me.cbo_cores)
        Me.GroupBox1.Controls.Add(Me.txt_tamanho)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(233, 81)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        '
        'Frm_ConfirmaCompraGrade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(256, 122)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ConfirmaCompraGrade"
        Me.Opacity = 0.99
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confirma Compra Grade"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_cores As System.Windows.Forms.ComboBox
    Friend WithEvents txt_tamanho As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
