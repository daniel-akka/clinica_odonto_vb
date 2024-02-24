<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LerMemoriaData
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
        Me.dtp_periodoInicial = New System.Windows.Forms.DateTimePicker
        Me.dtp_periodoFinal = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_confirma = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtp_periodoInicial
        '
        Me.dtp_periodoInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_periodoInicial.Location = New System.Drawing.Point(32, 48)
        Me.dtp_periodoInicial.Name = "dtp_periodoInicial"
        Me.dtp_periodoInicial.Size = New System.Drawing.Size(89, 20)
        Me.dtp_periodoInicial.TabIndex = 0
        '
        'dtp_periodoFinal
        '
        Me.dtp_periodoFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_periodoFinal.Location = New System.Drawing.Point(166, 48)
        Me.dtp_periodoFinal.Name = "dtp_periodoFinal"
        Me.dtp_periodoFinal.Size = New System.Drawing.Size(89, 20)
        Me.dtp_periodoFinal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(134, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "A"
        '
        'btn_confirma
        '
        Me.btn_confirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_confirma.Location = New System.Drawing.Point(244, 99)
        Me.btn_confirma.Name = "btn_confirma"
        Me.btn_confirma.Size = New System.Drawing.Size(75, 31)
        Me.btn_confirma.TabIndex = 2
        Me.btn_confirma.Text = "&Confirma"
        Me.btn_confirma.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtp_periodoFinal)
        Me.GroupBox1.Controls.Add(Me.dtp_periodoInicial)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 85)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(119, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Período"
        '
        'Frm_LerMemoriaData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 144)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_confirma)
        Me.KeyPreview = True
        Me.Name = "Frm_LerMemoriaData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Periodo p/ Leitura da Memória"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtp_periodoInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_periodoFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_confirma As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
