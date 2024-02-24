<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CfopResp
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_ok = New System.Windows.Forms.Button
        Me.dtg_cfop = New System.Windows.Forms.DataGridView
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nome = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_cfop = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtg_cfop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_ok)
        Me.GroupBox1.Controls.Add(Me.dtg_cfop)
        Me.GroupBox1.Controls.Add(Me.txt_cfop)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(564, 290)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btn_ok
        '
        Me.btn_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok.Image = Global.RTecSys.My.Resources.Resources.ok_16x16
        Me.btn_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ok.Location = New System.Drawing.Point(198, 14)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(67, 29)
        Me.btn_ok.TabIndex = 7
        Me.btn_ok.Text = "&OK"
        Me.btn_ok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'dtg_cfop
        '
        Me.dtg_cfop.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_cfop.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_cfop.BackgroundColor = System.Drawing.Color.DarkGray
        Me.dtg_cfop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_cfop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_cfop.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.nome})
        Me.dtg_cfop.Location = New System.Drawing.Point(12, 45)
        Me.dtg_cfop.MultiSelect = False
        Me.dtg_cfop.Name = "dtg_cfop"
        Me.dtg_cfop.ReadOnly = True
        Me.dtg_cfop.Size = New System.Drawing.Size(542, 234)
        Me.dtg_cfop.TabIndex = 6
        '
        'codigo
        '
        Me.codigo.HeaderText = "CFOP"
        Me.codigo.MaxInputLength = 5
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.codigo.Width = 60
        '
        'nome
        '
        Me.nome.HeaderText = "Descrição"
        Me.nome.MaxInputLength = 70
        Me.nome.Name = "nome"
        Me.nome.ReadOnly = True
        Me.nome.Width = 420
        '
        'txt_cfop
        '
        Me.txt_cfop.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_cfop.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cfop.Location = New System.Drawing.Point(57, 17)
        Me.txt_cfop.MaxLength = 30
        Me.txt_cfop.Name = "txt_cfop"
        Me.txt_cfop.Size = New System.Drawing.Size(110, 23)
        Me.txt_cfop.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CFOP:"
        '
        'Frm_CfopResp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 308)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_CfopResp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busca de CFOP"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtg_cfop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_cfop As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtg_cfop As System.Windows.Forms.DataGridView
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_ok As System.Windows.Forms.Button
End Class
