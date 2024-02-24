<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CTBLivroEntradas
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.lbl_folha = New System.Windows.Forms.Label
        Me.txt_folha = New System.Windows.Forms.TextBox
        Me.btn_gerar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Período de:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(212, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Até"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DateTimePicker1.Location = New System.Drawing.Point(103, 46)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(101, 23)
        Me.DateTimePicker1.TabIndex = 2
        Me.DateTimePicker1.Value = New Date(2008, 10, 28, 0, 0, 0, 0)
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(252, 47)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(103, 23)
        Me.DateTimePicker2.TabIndex = 3
        '
        'lbl_folha
        '
        Me.lbl_folha.AutoSize = True
        Me.lbl_folha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_folha.Location = New System.Drawing.Point(47, 115)
        Me.lbl_folha.Name = "lbl_folha"
        Me.lbl_folha.Size = New System.Drawing.Size(51, 17)
        Me.lbl_folha.TabIndex = 4
        Me.lbl_folha.Text = "Folha :"
        '
        'txt_folha
        '
        Me.txt_folha.Location = New System.Drawing.Point(103, 113)
        Me.txt_folha.MaxLength = 5
        Me.txt_folha.Name = "txt_folha"
        Me.txt_folha.Size = New System.Drawing.Size(73, 20)
        Me.txt_folha.TabIndex = 5
        '
        'btn_gerar
        '
        Me.btn_gerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_gerar.Location = New System.Drawing.Point(280, 115)
        Me.btn_gerar.Name = "btn_gerar"
        Me.btn_gerar.Size = New System.Drawing.Size(75, 23)
        Me.btn_gerar.TabIndex = 6
        Me.btn_gerar.Text = "&Gerar"
        Me.btn_gerar.UseVisualStyleBackColor = True
        '
        'Frm_CTBLivroEntradas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 183)
        Me.Controls.Add(Me.btn_gerar)
        Me.Controls.Add(Me.txt_folha)
        Me.Controls.Add(Me.lbl_folha)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_CTBLivroEntradas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gera Livro de Entradas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_folha As System.Windows.Forms.Label
    Friend WithEvents txt_folha As System.Windows.Forms.TextBox
    Friend WithEvents btn_gerar As System.Windows.Forms.Button
End Class
