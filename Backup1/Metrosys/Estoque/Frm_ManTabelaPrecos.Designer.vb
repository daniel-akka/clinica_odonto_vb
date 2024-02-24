<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManTabelaPrecos
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
        Me.btn_atualizarTudo = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn_atualizarTudo
        '
        Me.btn_atualizarTudo.Location = New System.Drawing.Point(12, 38)
        Me.btn_atualizarTudo.Name = "btn_atualizarTudo"
        Me.btn_atualizarTudo.Size = New System.Drawing.Size(132, 41)
        Me.btn_atualizarTudo.TabIndex = 0
        Me.btn_atualizarTudo.Text = "&Atualizar Tudo"
        Me.btn_atualizarTudo.UseVisualStyleBackColor = True
        '
        'Frm_ManTabelaPrecos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 129)
        Me.Controls.Add(Me.btn_atualizarTudo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ManTabelaPrecos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção da Tabela de Preços"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_atualizarTudo As System.Windows.Forms.Button
End Class
