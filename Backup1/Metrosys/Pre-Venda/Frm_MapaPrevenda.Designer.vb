<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MapaPrevenda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MapaPrevenda))
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbo_local = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.pct_metrosys = New System.Windows.Forms.PictureBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txt_vltotalMp = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Btn_novo = New System.Windows.Forms.Button
        Me.Btn_alterar = New System.Windows.Forms.Button
        Me.btn_finalizar = New System.Windows.Forms.Button
        Me.Btn_excluir = New System.Windows.Forms.Button
        Me.txt_valorunit = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_qtde = New System.Windows.Forms.TextBox
        Me.lbl_qtdFisc = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_nomeProd = New System.Windows.Forms.TextBox
        Me.txt_codprod = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.msk_dtsaida = New System.Windows.Forms.MaskedTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.msk_dtemisao = New System.Windows.Forms.MaskedTextBox
        Me.txt_numeroMp = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_mensagem = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label26 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.dtg_mapa = New System.Windows.Forms.DataGridView
        Me.codProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descrProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qtdeProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precoUnitProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.totalProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.und = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pesobruto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pesoliq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codbarra = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbo_placaVeic = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.pct_metrosys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_mapa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo_placaVeic)
        Me.GroupBox1.Controls.Add(Me.cbo_local)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.pct_metrosys)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.txt_valorunit)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_qtde)
        Me.GroupBox1.Controls.Add(Me.lbl_qtdFisc)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_nomeProd)
        Me.GroupBox1.Controls.Add(Me.txt_codprod)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.msk_dtsaida)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.msk_dtemisao)
        Me.GroupBox1.Controls.Add(Me.txt_numeroMp)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(875, 140)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cbo_local
        '
        Me.cbo_local.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_local.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_local.FormattingEnabled = True
        Me.cbo_local.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07"})
        Me.cbo_local.Location = New System.Drawing.Point(255, 14)
        Me.cbo_local.Name = "cbo_local"
        Me.cbo_local.Size = New System.Drawing.Size(49, 24)
        Me.cbo_local.TabIndex = 2
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(209, 18)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 15)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = "Local:"
        '
        'pct_metrosys
        '
        Me.pct_metrosys.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pct_metrosys.Image = Global.MetroSys.My.Resources.Resources.metrosys
        Me.pct_metrosys.Location = New System.Drawing.Point(706, 11)
        Me.pct_metrosys.Name = "pct_metrosys"
        Me.pct_metrosys.Size = New System.Drawing.Size(156, 50)
        Me.pct_metrosys.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pct_metrosys.TabIndex = 13
        Me.pct_metrosys.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_vltotalMp)
        Me.GroupBox4.Location = New System.Drawing.Point(706, 71)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(156, 56)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Total R$"
        '
        'txt_vltotalMp
        '
        Me.txt_vltotalMp.BackColor = System.Drawing.SystemColors.Control
        Me.txt_vltotalMp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vltotalMp.ForeColor = System.Drawing.Color.Red
        Me.txt_vltotalMp.Location = New System.Drawing.Point(15, 19)
        Me.txt_vltotalMp.MaxLength = 16
        Me.txt_vltotalMp.Name = "txt_vltotalMp"
        Me.txt_vltotalMp.ReadOnly = True
        Me.txt_vltotalMp.Size = New System.Drawing.Size(133, 23)
        Me.txt_vltotalMp.TabIndex = 14
        Me.txt_vltotalMp.Text = "0,00"
        Me.txt_vltotalMp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Btn_novo)
        Me.GroupBox3.Controls.Add(Me.Btn_alterar)
        Me.GroupBox3.Controls.Add(Me.btn_finalizar)
        Me.GroupBox3.Controls.Add(Me.Btn_excluir)
        Me.GroupBox3.Location = New System.Drawing.Point(394, 66)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(297, 65)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        '
        'Btn_novo
        '
        Me.Btn_novo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_novo.Image = Global.MetroSys.My.Resources.Resources.Add
        Me.Btn_novo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_novo.Location = New System.Drawing.Point(4, 8)
        Me.Btn_novo.Name = "Btn_novo"
        Me.Btn_novo.Size = New System.Drawing.Size(68, 55)
        Me.Btn_novo.TabIndex = 10
        Me.Btn_novo.Text = "&Novo [F2]"
        Me.Btn_novo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_novo.UseVisualStyleBackColor = True
        '
        'Btn_alterar
        '
        Me.Btn_alterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_alterar.Image = Global.MetroSys.My.Resources.Resources.editar
        Me.Btn_alterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_alterar.Location = New System.Drawing.Point(77, 8)
        Me.Btn_alterar.Name = "Btn_alterar"
        Me.Btn_alterar.Size = New System.Drawing.Size(68, 55)
        Me.Btn_alterar.TabIndex = 11
        Me.Btn_alterar.Text = "&Alterar [F3]"
        Me.Btn_alterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_alterar.UseVisualStyleBackColor = True
        '
        'btn_finalizar
        '
        Me.btn_finalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalizar.Image = Global.MetroSys.My.Resources.Resources.Info
        Me.btn_finalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_finalizar.Location = New System.Drawing.Point(225, 8)
        Me.btn_finalizar.Name = "btn_finalizar"
        Me.btn_finalizar.Size = New System.Drawing.Size(68, 55)
        Me.btn_finalizar.TabIndex = 13
        Me.btn_finalizar.Text = "&Finalizar [F7]"
        Me.btn_finalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_finalizar.UseVisualStyleBackColor = True
        '
        'Btn_excluir
        '
        Me.Btn_excluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_excluir.Image = Global.MetroSys.My.Resources.Resources.Delete
        Me.Btn_excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_excluir.Location = New System.Drawing.Point(151, 8)
        Me.Btn_excluir.Name = "Btn_excluir"
        Me.Btn_excluir.Size = New System.Drawing.Size(68, 55)
        Me.Btn_excluir.TabIndex = 12
        Me.Btn_excluir.Text = "&Excluir [F4]"
        Me.Btn_excluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_excluir.UseVisualStyleBackColor = True
        '
        'txt_valorunit
        '
        Me.txt_valorunit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_valorunit.Location = New System.Drawing.Point(99, 105)
        Me.txt_valorunit.MaxLength = 14
        Me.txt_valorunit.Name = "txt_valorunit"
        Me.txt_valorunit.Size = New System.Drawing.Size(122, 22)
        Me.txt_valorunit.TabIndex = 9
        Me.txt_valorunit.Text = "0,00"
        Me.txt_valorunit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Vl.Unitario R$:"
        '
        'txt_qtde
        '
        Me.txt_qtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtde.Location = New System.Drawing.Point(99, 75)
        Me.txt_qtde.MaxLength = 14
        Me.txt_qtde.Name = "txt_qtde"
        Me.txt_qtde.Size = New System.Drawing.Size(122, 22)
        Me.txt_qtde.TabIndex = 8
        Me.txt_qtde.Text = "0,00"
        Me.txt_qtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_qtdFisc
        '
        Me.lbl_qtdFisc.AutoSize = True
        Me.lbl_qtdFisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_qtdFisc.ForeColor = System.Drawing.Color.Red
        Me.lbl_qtdFisc.Location = New System.Drawing.Point(292, 81)
        Me.lbl_qtdFisc.Name = "lbl_qtdFisc"
        Me.lbl_qtdFisc.Size = New System.Drawing.Size(23, 15)
        Me.lbl_qtdFisc.TabIndex = 9
        Me.lbl_qtdFisc.Text = ".   "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(231, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 15)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Estoque:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Quantidade:"
        '
        'txt_nomeProd
        '
        Me.txt_nomeProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomeProd.Location = New System.Drawing.Point(177, 43)
        Me.txt_nomeProd.MaxLength = 100
        Me.txt_nomeProd.Name = "txt_nomeProd"
        Me.txt_nomeProd.ReadOnly = True
        Me.txt_nomeProd.Size = New System.Drawing.Size(349, 22)
        Me.txt_nomeProd.TabIndex = 6
        '
        'txt_codprod
        '
        Me.txt_codprod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codprod.Location = New System.Drawing.Point(99, 43)
        Me.txt_codprod.MaxLength = 6
        Me.txt_codprod.Name = "txt_codprod"
        Me.txt_codprod.Size = New System.Drawing.Size(72, 22)
        Me.txt_codprod.TabIndex = 5
        Me.txt_codprod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "CodProduto:"
        '
        'msk_dtsaida
        '
        Me.msk_dtsaida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_dtsaida.Location = New System.Drawing.Point(613, 15)
        Me.msk_dtsaida.Mask = "00/00/0000"
        Me.msk_dtsaida.Name = "msk_dtsaida"
        Me.msk_dtsaida.Size = New System.Drawing.Size(78, 22)
        Me.msk_dtsaida.TabIndex = 4
        Me.msk_dtsaida.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(536, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Data Saida:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(341, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Data Emissão:"
        '
        'msk_dtemisao
        '
        Me.msk_dtemisao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msk_dtemisao.Location = New System.Drawing.Point(434, 15)
        Me.msk_dtemisao.Mask = "00/00/0000"
        Me.msk_dtemisao.Name = "msk_dtemisao"
        Me.msk_dtemisao.Size = New System.Drawing.Size(81, 22)
        Me.msk_dtemisao.TabIndex = 3
        Me.msk_dtemisao.ValidatingType = GetType(Date)
        '
        'txt_numeroMp
        '
        Me.txt_numeroMp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numeroMp.Location = New System.Drawing.Point(99, 15)
        Me.txt_numeroMp.MaxLength = 10
        Me.txt_numeroMp.Name = "txt_numeroMp"
        Me.txt_numeroMp.ReadOnly = True
        Me.txt_numeroMp.Size = New System.Drawing.Size(100, 22)
        Me.txt_numeroMp.TabIndex = 1
        Me.txt_numeroMp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numero Mapa:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_mensagem)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 597)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(875, 53)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'lbl_mensagem
        '
        Me.lbl_mensagem.AutoSize = True
        Me.lbl_mensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensagem.ForeColor = System.Drawing.Color.Red
        Me.lbl_mensagem.Location = New System.Drawing.Point(8, 19)
        Me.lbl_mensagem.Name = "lbl_mensagem"
        Me.lbl_mensagem.Size = New System.Drawing.Size(34, 20)
        Me.lbl_mensagem.TabIndex = 0
        Me.lbl_mensagem.Text = ".    "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(895, 89)
        Me.Panel1.TabIndex = 16
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("Wide Latin", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(682, 53)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(201, 27)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MetroSys"
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(344, 10)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(202, 70)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'dtg_mapa
        '
        Me.dtg_mapa.AllowUserToAddRows = False
        Me.dtg_mapa.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Aquamarine
        Me.dtg_mapa.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_mapa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_mapa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_mapa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_mapa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dtg_mapa.ColumnHeadersHeight = 28
        Me.dtg_mapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_mapa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codProd, Me.descrProd, Me.qtdeProd, Me.precoUnitProd, Me.totalProd, Me.und, Me.pesobruto, Me.pesoliq, Me.codbarra})
        Me.dtg_mapa.Location = New System.Drawing.Point(9, 241)
        Me.dtg_mapa.Name = "dtg_mapa"
        Me.dtg_mapa.ReadOnly = True
        Me.dtg_mapa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_mapa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtg_mapa.Size = New System.Drawing.Size(875, 346)
        Me.dtg_mapa.TabIndex = 22
        '
        'codProd
        '
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codProd.DefaultCellStyle = DataGridViewCellStyle10
        Me.codProd.HeaderText = "Codigo"
        Me.codProd.MaxInputLength = 6
        Me.codProd.Name = "codProd"
        Me.codProd.ReadOnly = True
        Me.codProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.codProd.Width = 115
        '
        'descrProd
        '
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descrProd.DefaultCellStyle = DataGridViewCellStyle11
        Me.descrProd.HeaderText = "Descrição"
        Me.descrProd.MaxInputLength = 80
        Me.descrProd.Name = "descrProd"
        Me.descrProd.ReadOnly = True
        Me.descrProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.descrProd.Width = 345
        '
        'qtdeProd
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtdeProd.DefaultCellStyle = DataGridViewCellStyle12
        Me.qtdeProd.HeaderText = "Qtde"
        Me.qtdeProd.MaxInputLength = 12
        Me.qtdeProd.Name = "qtdeProd"
        Me.qtdeProd.ReadOnly = True
        Me.qtdeProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.qtdeProd.Width = 115
        '
        'precoUnitProd
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.precoUnitProd.DefaultCellStyle = DataGridViewCellStyle13
        Me.precoUnitProd.HeaderText = "VlrUnit."
        Me.precoUnitProd.MaxInputLength = 12
        Me.precoUnitProd.Name = "precoUnitProd"
        Me.precoUnitProd.ReadOnly = True
        Me.precoUnitProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.precoUnitProd.Width = 115
        '
        'totalProd
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalProd.DefaultCellStyle = DataGridViewCellStyle14
        Me.totalProd.HeaderText = "Total"
        Me.totalProd.MaxInputLength = 16
        Me.totalProd.Name = "totalProd"
        Me.totalProd.ReadOnly = True
        Me.totalProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.totalProd.Width = 140
        '
        'und
        '
        Me.und.HeaderText = "und"
        Me.und.Name = "und"
        Me.und.ReadOnly = True
        Me.und.Visible = False
        '
        'pesobruto
        '
        Me.pesobruto.HeaderText = "pesobruto"
        Me.pesobruto.Name = "pesobruto"
        Me.pesobruto.ReadOnly = True
        Me.pesobruto.Visible = False
        '
        'pesoliq
        '
        Me.pesoliq.HeaderText = "pesoliq"
        Me.pesoliq.Name = "pesoliq"
        Me.pesoliq.ReadOnly = True
        Me.pesoliq.Visible = False
        '
        'codbarra
        '
        Me.codbarra.HeaderText = "codbarra"
        Me.codbarra.Name = "codbarra"
        Me.codbarra.ReadOnly = True
        Me.codbarra.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(536, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 15)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Veículo:"
        '
        'cbo_placaVeic
        '
        Me.cbo_placaVeic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_placaVeic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_placaVeic.FormattingEnabled = True
        Me.cbo_placaVeic.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07"})
        Me.cbo_placaVeic.Location = New System.Drawing.Point(592, 42)
        Me.cbo_placaVeic.Name = "cbo_placaVeic"
        Me.cbo_placaVeic.Size = New System.Drawing.Size(99, 23)
        Me.cbo_placaVeic.TabIndex = 7
        '
        'Frm_MapaPrevenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 662)
        Me.Controls.Add(Me.dtg_mapa)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_MapaPrevenda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registra Mapa de Vendas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pct_metrosys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_mapa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents msk_dtsaida As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents msk_dtemisao As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_numeroMp As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_qtde As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_novo As System.Windows.Forms.Button
    Public WithEvents Btn_alterar As System.Windows.Forms.Button
    Public WithEvents Btn_excluir As System.Windows.Forms.Button
    Friend WithEvents txt_vltotalMp As System.Windows.Forms.TextBox
    Friend WithEvents lbl_mensagem As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents pct_metrosys As System.Windows.Forms.PictureBox
    Friend WithEvents dtg_mapa As System.Windows.Forms.DataGridView
    Public WithEvents btn_finalizar As System.Windows.Forms.Button
    Public WithEvents txt_nomeProd As System.Windows.Forms.TextBox
    Public WithEvents txt_codprod As System.Windows.Forms.TextBox
    Public WithEvents txt_valorunit As System.Windows.Forms.TextBox
    Public WithEvents cbo_local As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lbl_qtdFisc As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents codProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descrProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtdeProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precoUnitProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents und As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pesobruto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pesoliq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codbarra As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents cbo_placaVeic As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
