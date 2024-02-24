<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AtualizaCaixas
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
        Me.btn_novos = New System.Windows.Forms.Button
        Me.btn_alterador = New System.Windows.Forms.Button
        Me.lbl_novos = New System.Windows.Forms.Label
        Me.lbl_alterados = New System.Windows.Forms.Label
        Me.btn_sair = New System.Windows.Forms.Button
        Me.grp_atualizacao = New System.Windows.Forms.GroupBox
        Me.grp_atualizacao.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_novos
        '
        Me.btn_novos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_novos.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_novos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_novos.Location = New System.Drawing.Point(31, 36)
        Me.btn_novos.Name = "btn_novos"
        Me.btn_novos.Size = New System.Drawing.Size(100, 44)
        Me.btn_novos.TabIndex = 0
        Me.btn_novos.Text = "Itens &Novos"
        Me.btn_novos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_novos.UseVisualStyleBackColor = True
        '
        'btn_alterador
        '
        Me.btn_alterador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alterador.Image = Global.MetroSys.My.Resources.Resources.Save
        Me.btn_alterador.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_alterador.Location = New System.Drawing.Point(31, 101)
        Me.btn_alterador.Name = "btn_alterador"
        Me.btn_alterador.Size = New System.Drawing.Size(100, 43)
        Me.btn_alterador.TabIndex = 1
        Me.btn_alterador.Text = "Itens &Alterados"
        Me.btn_alterador.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_alterador.UseVisualStyleBackColor = True
        '
        'lbl_novos
        '
        Me.lbl_novos.AutoSize = True
        Me.lbl_novos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_novos.Location = New System.Drawing.Point(153, 49)
        Me.lbl_novos.Name = "lbl_novos"
        Me.lbl_novos.Size = New System.Drawing.Size(51, 15)
        Me.lbl_novos.TabIndex = 2
        Me.lbl_novos.Text = "Ocioso"
        '
        'lbl_alterados
        '
        Me.lbl_alterados.AutoSize = True
        Me.lbl_alterados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_alterados.Location = New System.Drawing.Point(153, 117)
        Me.lbl_alterados.Name = "lbl_alterados"
        Me.lbl_alterados.Size = New System.Drawing.Size(51, 15)
        Me.lbl_alterados.TabIndex = 3
        Me.lbl_alterados.Text = "Ocioso"
        '
        'btn_sair
        '
        Me.btn_sair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sair.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_sair.Location = New System.Drawing.Point(300, 101)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(75, 43)
        Me.btn_sair.TabIndex = 4
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'grp_atualizacao
        '
        Me.grp_atualizacao.Controls.Add(Me.btn_novos)
        Me.grp_atualizacao.Controls.Add(Me.btn_sair)
        Me.grp_atualizacao.Controls.Add(Me.btn_alterador)
        Me.grp_atualizacao.Controls.Add(Me.lbl_alterados)
        Me.grp_atualizacao.Controls.Add(Me.lbl_novos)
        Me.grp_atualizacao.Location = New System.Drawing.Point(12, 22)
        Me.grp_atualizacao.Name = "grp_atualizacao"
        Me.grp_atualizacao.Size = New System.Drawing.Size(413, 191)
        Me.grp_atualizacao.TabIndex = 5
        Me.grp_atualizacao.TabStop = False
        '
        'Frm_AtualizaCaixas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 233)
        Me.Controls.Add(Me.grp_atualizacao)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_AtualizaCaixas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atualização das Tabelas de Preços"
        Me.grp_atualizacao.ResumeLayout(False)
        Me.grp_atualizacao.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_novos As System.Windows.Forms.Button
    Friend WithEvents btn_alterador As System.Windows.Forms.Button
    Friend WithEvents lbl_novos As System.Windows.Forms.Label
    Friend WithEvents lbl_alterados As System.Windows.Forms.Label
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents grp_atualizacao As System.Windows.Forms.GroupBox
End Class
