<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DataPeriodoResp
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
        Me.btn_ok = New System.Windows.Forms.Button
        Me.grp_box1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtp_dataFinal = New System.Windows.Forms.DateTimePicker
        Me.dtp_dataInicial = New System.Windows.Forms.DateTimePicker
        Me.grp_box1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_ok
        '
        Me.btn_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok.Image = Global.RTecSys.My.Resources.Resources.ok_16x16
        Me.btn_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ok.Location = New System.Drawing.Point(327, 16)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(67, 32)
        Me.btn_ok.TabIndex = 3
        Me.btn_ok.Text = "&OK"
        Me.btn_ok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'grp_box1
        '
        Me.grp_box1.Controls.Add(Me.btn_ok)
        Me.grp_box1.Controls.Add(Me.Label2)
        Me.grp_box1.Controls.Add(Me.Label1)
        Me.grp_box1.Controls.Add(Me.dtp_dataFinal)
        Me.grp_box1.Controls.Add(Me.dtp_dataInicial)
        Me.grp_box1.Location = New System.Drawing.Point(12, 16)
        Me.grp_box1.Name = "grp_box1"
        Me.grp_box1.Size = New System.Drawing.Size(400, 57)
        Me.grp_box1.TabIndex = 1
        Me.grp_box1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(173, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "A"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "De:"
        '
        'dtp_dataFinal
        '
        Me.dtp_dataFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dataFinal.Location = New System.Drawing.Point(196, 20)
        Me.dtp_dataFinal.Name = "dtp_dataFinal"
        Me.dtp_dataFinal.Size = New System.Drawing.Size(113, 23)
        Me.dtp_dataFinal.TabIndex = 1
        '
        'dtp_dataInicial
        '
        Me.dtp_dataInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dataInicial.Location = New System.Drawing.Point(54, 20)
        Me.dtp_dataInicial.Name = "dtp_dataInicial"
        Me.dtp_dataInicial.Size = New System.Drawing.Size(113, 23)
        Me.dtp_dataInicial.TabIndex = 0
        '
        'Frm_DataPeriodoResp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 87)
        Me.Controls.Add(Me.grp_box1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_DataPeriodoResp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Período de Data"
        Me.grp_box1.ResumeLayout(False)
        Me.grp_box1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents grp_box1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_dataInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_dataFinal As System.Windows.Forms.DateTimePicker
End Class
