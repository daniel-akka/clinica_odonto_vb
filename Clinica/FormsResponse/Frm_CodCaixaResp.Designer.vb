﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CodCaixaResp
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
        Me.grp_box1 = New System.Windows.Forms.GroupBox()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_codCaixa = New System.Windows.Forms.ComboBox()
        Me.grp_box1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_box1
        '
        Me.grp_box1.Controls.Add(Me.cbo_codCaixa)
        Me.grp_box1.Controls.Add(Me.btn_ok)
        Me.grp_box1.Controls.Add(Me.Label1)
        Me.grp_box1.Location = New System.Drawing.Point(10, 12)
        Me.grp_box1.Name = "grp_box1"
        Me.grp_box1.Size = New System.Drawing.Size(284, 57)
        Me.grp_box1.TabIndex = 1
        Me.grp_box1.TabStop = False
        '
        'btn_ok
        '
        Me.btn_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok.Image = Global.RTecSys.My.Resources.Resources.ok_16x16
        Me.btn_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ok.Location = New System.Drawing.Point(212, 16)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(65, 32)
        Me.btn_ok.TabIndex = 2
        Me.btn_ok.Text = "&OK"
        Me.btn_ok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cod. do Caixa:"
        '
        'cbo_codCaixa
        '
        Me.cbo_codCaixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_codCaixa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_codCaixa.FormattingEnabled = True
        Me.cbo_codCaixa.Location = New System.Drawing.Point(116, 20)
        Me.cbo_codCaixa.Name = "cbo_codCaixa"
        Me.cbo_codCaixa.Size = New System.Drawing.Size(77, 24)
        Me.cbo_codCaixa.TabIndex = 2
        '
        'Frm_CodCaixaResp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 80)
        Me.Controls.Add(Me.grp_box1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_CodCaixaResp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Codigo do Caixa"
        Me.grp_box1.ResumeLayout(False)
        Me.grp_box1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp_box1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_codCaixa As System.Windows.Forms.ComboBox
End Class
