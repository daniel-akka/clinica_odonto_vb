<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ManEnergia
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ManEnergia))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_altera = New System.Windows.Forms.Button
        Me.btn_atualiza = New System.Windows.Forms.Button
        Me.btn_sair = New System.Windows.Forms.Button
        Me.btn_inclui = New System.Windows.Forms.Button
        Me.btn_exclui = New System.Windows.Forms.Button
        Me.dgEnergia = New System.Windows.Forms.DataGridView
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.grp_pesquisa = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.msk_dtFim = New System.Windows.Forms.MaskedTextBox
        Me.msk_dtInicio = New System.Windows.Forms.MaskedTextBox
        Me.cbo_consulta = New System.Windows.Forms.ComboBox
        Me.dtEntrada = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.numDoc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.participante = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.vencDoc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.consumo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgEnergia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_pesquisa.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_altera)
        Me.GroupBox1.Controls.Add(Me.btn_atualiza)
        Me.GroupBox1.Controls.Add(Me.btn_sair)
        Me.GroupBox1.Controls.Add(Me.btn_inclui)
        Me.GroupBox1.Controls.Add(Me.btn_exclui)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(607, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(145, 256)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'btn_altera
        '
        Me.btn_altera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_altera.Image = Global.MetroSys.My.Resources.Resources.Modify
        Me.btn_altera.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_altera.Location = New System.Drawing.Point(29, 63)
        Me.btn_altera.Name = "btn_altera"
        Me.btn_altera.Size = New System.Drawing.Size(95, 43)
        Me.btn_altera.TabIndex = 2
        Me.btn_altera.Text = "&Alterar  [F3]"
        Me.btn_altera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_altera.UseVisualStyleBackColor = True
        '
        'btn_atualiza
        '
        Me.btn_atualiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_atualiza.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_atualiza.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_atualiza.Location = New System.Drawing.Point(29, 207)
        Me.btn_atualiza.Name = "btn_atualiza"
        Me.btn_atualiza.Size = New System.Drawing.Size(95, 43)
        Me.btn_atualiza.TabIndex = 4
        Me.btn_atualiza.Text = "&Atualizar [F7]"
        Me.btn_atualiza.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_atualiza.UseVisualStyleBackColor = True
        '
        'btn_sair
        '
        Me.btn_sair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sair.Image = Global.MetroSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_sair.Location = New System.Drawing.Point(29, 161)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(95, 43)
        Me.btn_sair.TabIndex = 4
        Me.btn_sair.Text = "&Sair    [ESC]"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'btn_inclui
        '
        Me.btn_inclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_inclui.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.btn_inclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_inclui.Location = New System.Drawing.Point(29, 14)
        Me.btn_inclui.Name = "btn_inclui"
        Me.btn_inclui.Size = New System.Drawing.Size(95, 43)
        Me.btn_inclui.TabIndex = 1
        Me.btn_inclui.Text = "&Incluir  [F2]"
        Me.btn_inclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_inclui.UseVisualStyleBackColor = True
        '
        'btn_exclui
        '
        Me.btn_exclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exclui.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.btn_exclui.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exclui.Location = New System.Drawing.Point(29, 112)
        Me.btn_exclui.Name = "btn_exclui"
        Me.btn_exclui.Size = New System.Drawing.Size(95, 43)
        Me.btn_exclui.TabIndex = 3
        Me.btn_exclui.Text = "&Excluir  [F4]"
        Me.btn_exclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exclui.UseVisualStyleBackColor = True
        '
        'dgEnergia
        '
        Me.dgEnergia.AllowUserToAddRows = False
        Me.dgEnergia.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgEnergia.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgEnergia.BackgroundColor = System.Drawing.Color.DarkGray
        Me.dgEnergia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgEnergia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgEnergia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgEnergia.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgEnergia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgEnergia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtEntrada, Me.numDoc, Me.participante, Me.vencDoc, Me.consumo, Me.id})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgEnergia.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgEnergia.Location = New System.Drawing.Point(10, 21)
        Me.dgEnergia.MultiSelect = False
        Me.dgEnergia.Name = "dgEnergia"
        Me.dgEnergia.ReadOnly = True
        Me.dgEnergia.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgEnergia.Size = New System.Drawing.Size(591, 461)
        Me.dgEnergia.TabIndex = 6
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(625, 384)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(106, 98)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'grp_pesquisa
        '
        Me.grp_pesquisa.Controls.Add(Me.Label3)
        Me.grp_pesquisa.Controls.Add(Me.Label2)
        Me.grp_pesquisa.Controls.Add(Me.Label1)
        Me.grp_pesquisa.Controls.Add(Me.msk_dtFim)
        Me.grp_pesquisa.Controls.Add(Me.msk_dtInicio)
        Me.grp_pesquisa.Controls.Add(Me.cbo_consulta)
        Me.grp_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_pesquisa.Location = New System.Drawing.Point(607, 272)
        Me.grp_pesquisa.Name = "grp_pesquisa"
        Me.grp_pesquisa.Size = New System.Drawing.Size(145, 106)
        Me.grp_pesquisa.TabIndex = 9
        Me.grp_pesquisa.TabStop = False
        Me.grp_pesquisa.Text = "Opções de Consulta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "ex: 23/04/2004"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fim:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Inicio:"
        '
        'msk_dtFim
        '
        Me.msk_dtFim.Enabled = False
        Me.msk_dtFim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_dtFim.Location = New System.Drawing.Point(46, 67)
        Me.msk_dtFim.Mask = "00/00/0000"
        Me.msk_dtFim.Name = "msk_dtFim"
        Me.msk_dtFim.Size = New System.Drawing.Size(85, 21)
        Me.msk_dtFim.TabIndex = 2
        Me.msk_dtFim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.msk_dtFim.ValidatingType = GetType(Date)
        '
        'msk_dtInicio
        '
        Me.msk_dtInicio.Enabled = False
        Me.msk_dtInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_dtInicio.Location = New System.Drawing.Point(46, 43)
        Me.msk_dtInicio.Mask = "00/00/0000"
        Me.msk_dtInicio.Name = "msk_dtInicio"
        Me.msk_dtInicio.Size = New System.Drawing.Size(85, 21)
        Me.msk_dtInicio.TabIndex = 1
        Me.msk_dtInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.msk_dtInicio.ValidatingType = GetType(Date)
        '
        'cbo_consulta
        '
        Me.cbo_consulta.BackColor = System.Drawing.SystemColors.HighlightText
        Me.cbo_consulta.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbo_consulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_consulta.FormattingEnabled = True
        Me.cbo_consulta.Items.AddRange(New Object() {"As 10 últimas Notas", "Data atual", "No último mês", "No último ano", "Intervalo personalizado"})
        Me.cbo_consulta.Location = New System.Drawing.Point(4, 18)
        Me.cbo_consulta.Name = "cbo_consulta"
        Me.cbo_consulta.Size = New System.Drawing.Size(136, 21)
        Me.cbo_consulta.TabIndex = 0
        '
        'dtEntrada
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEntrada.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtEntrada.HeaderText = "Dt/Entrada"
        Me.dtEntrada.MaxInputLength = 10
        Me.dtEntrada.Name = "dtEntrada"
        Me.dtEntrada.ReadOnly = True
        Me.dtEntrada.Width = 85
        '
        'numDoc
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDoc.DefaultCellStyle = DataGridViewCellStyle4
        Me.numDoc.HeaderText = "Num. Doc"
        Me.numDoc.MaxInputLength = 9
        Me.numDoc.Name = "numDoc"
        Me.numDoc.ReadOnly = True
        Me.numDoc.Width = 90
        '
        'participante
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.participante.DefaultCellStyle = DataGridViewCellStyle5
        Me.participante.HeaderText = "Participante"
        Me.participante.MaxInputLength = 70
        Me.participante.Name = "participante"
        Me.participante.ReadOnly = True
        Me.participante.Width = 237
        '
        'vencDoc
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vencDoc.DefaultCellStyle = DataGridViewCellStyle6
        Me.vencDoc.HeaderText = "Vencimento"
        Me.vencDoc.MaxInputLength = 10
        Me.vencDoc.Name = "vencDoc"
        Me.vencDoc.ReadOnly = True
        Me.vencDoc.Width = 85
        '
        'consumo
        '
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consumo.DefaultCellStyle = DataGridViewCellStyle7
        Me.consumo.HeaderText = "Consumo"
        Me.consumo.MaxInputLength = 8
        Me.consumo.Name = "consumo"
        Me.consumo.ReadOnly = True
        Me.consumo.Width = 70
        '
        'id
        '
        Me.id.HeaderText = "ID"
        Me.id.MaxInputLength = 10
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 5
        '
        'Frm_ManEnergia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 499)
        Me.Controls.Add(Me.grp_pesquisa)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgEnergia)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_ManEnergia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutenção de Serviços de Energia Eletrica"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgEnergia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_pesquisa.ResumeLayout(False)
        Me.grp_pesquisa.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_altera As System.Windows.Forms.Button
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents btn_inclui As System.Windows.Forms.Button
    Friend WithEvents btn_exclui As System.Windows.Forms.Button
    Friend WithEvents dgEnergia As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_atualiza As System.Windows.Forms.Button
    Friend WithEvents grp_pesquisa As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_consulta As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents msk_dtFim As System.Windows.Forms.MaskedTextBox
    Friend WithEvents msk_dtInicio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtEntrada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents participante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vencDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents consumo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
