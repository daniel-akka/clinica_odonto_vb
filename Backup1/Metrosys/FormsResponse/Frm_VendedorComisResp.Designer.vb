<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_VendedorComisResp
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
        Me.cbo_vendedores = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grp_alqComis = New System.Windows.Forms.GroupBox
        Me.txt_alqEntrada = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_alqAVista = New System.Windows.Forms.TextBox
        Me.txt_alqAPrazo = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.grp_alqComis.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbo_vendedores
        '
        Me.cbo_vendedores.DropDownHeight = 203
        Me.cbo_vendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_vendedores.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_vendedores.FormattingEnabled = True
        Me.cbo_vendedores.IntegralHeight = False
        Me.cbo_vendedores.Location = New System.Drawing.Point(86, 19)
        Me.cbo_vendedores.Name = "cbo_vendedores"
        Me.cbo_vendedores.Size = New System.Drawing.Size(203, 24)
        Me.cbo_vendedores.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vendedor:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grp_alqComis)
        Me.GroupBox1.Controls.Add(Me.cbo_vendedores)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(311, 169)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'grp_alqComis
        '
        Me.grp_alqComis.Controls.Add(Me.txt_alqAVista)
        Me.grp_alqComis.Controls.Add(Me.txt_alqAPrazo)
        Me.grp_alqComis.Controls.Add(Me.txt_alqEntrada)
        Me.grp_alqComis.Controls.Add(Me.Label2)
        Me.grp_alqComis.Controls.Add(Me.Label4)
        Me.grp_alqComis.Controls.Add(Me.Label3)
        Me.grp_alqComis.Location = New System.Drawing.Point(9, 51)
        Me.grp_alqComis.Name = "grp_alqComis"
        Me.grp_alqComis.Size = New System.Drawing.Size(296, 112)
        Me.grp_alqComis.TabIndex = 2
        Me.grp_alqComis.TabStop = False
        Me.grp_alqComis.Text = "Aliquotas de Comissão"
        '
        'txt_alqEntrada
        '
        Me.txt_alqEntrada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_alqEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_alqEntrada.Location = New System.Drawing.Point(82, 46)
        Me.txt_alqEntrada.MaxLength = 14
        Me.txt_alqEntrada.Name = "txt_alqEntrada"
        Me.txt_alqEntrada.Size = New System.Drawing.Size(74, 21)
        Me.txt_alqEntrada.TabIndex = 5
        Me.txt_alqEntrada.Text = "0,00"
        Me.txt_alqEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "A Vista:    "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Entrada:  "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "A Prazo:  "
        '
        'txt_alqAVista
        '
        Me.txt_alqAVista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_alqAVista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_alqAVista.Location = New System.Drawing.Point(82, 16)
        Me.txt_alqAVista.MaxLength = 14
        Me.txt_alqAVista.Name = "txt_alqAVista"
        Me.txt_alqAVista.Size = New System.Drawing.Size(74, 21)
        Me.txt_alqAVista.TabIndex = 3
        Me.txt_alqAVista.Text = "0,00"
        Me.txt_alqAVista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_alqAPrazo
        '
        Me.txt_alqAPrazo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_alqAPrazo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_alqAPrazo.Location = New System.Drawing.Point(82, 76)
        Me.txt_alqAPrazo.MaxLength = 14
        Me.txt_alqAPrazo.Name = "txt_alqAPrazo"
        Me.txt_alqAPrazo.Size = New System.Drawing.Size(74, 21)
        Me.txt_alqAPrazo.TabIndex = 7
        Me.txt_alqAPrazo.Text = "0,00"
        Me.txt_alqAPrazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frm_VendedorComisResp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 192)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_VendedorComisResp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendedor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp_alqComis.ResumeLayout(False)
        Me.grp_alqComis.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbo_vendedores As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grp_alqComis As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents txt_alqEntrada As System.Windows.Forms.TextBox
    Public WithEvents txt_alqAVista As System.Windows.Forms.TextBox
    Public WithEvents txt_alqAPrazo As System.Windows.Forms.TextBox
End Class
