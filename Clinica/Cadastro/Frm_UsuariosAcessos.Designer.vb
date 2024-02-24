<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_UsuariosAcessos
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
        Me.btn_sair = New System.Windows.Forms.Button()
        Me.grp_acesso1 = New System.Windows.Forms.GroupBox()
        Me.chk_movAgendamentos = New System.Windows.Forms.CheckBox()
        Me.chk_cadServico = New System.Windows.Forms.CheckBox()
        Me.chk_movOrcamento = New System.Windows.Forms.CheckBox()
        Me.chk_cadastros = New System.Windows.Forms.CheckBox()
        Me.chk_Movimentos = New System.Windows.Forms.CheckBox()
        Me.chk_cadGeno = New System.Windows.Forms.CheckBox()
        Me.chk_cadCidade = New System.Windows.Forms.CheckBox()
        Me.chk_cadUsuario = New System.Windows.Forms.CheckBox()
        Me.chk_cadCliente = New System.Windows.Forms.CheckBox()
        Me.grp_acesso3 = New System.Windows.Forms.GroupBox()
        Me.chk_manCidadesIBGE = New System.Windows.Forms.CheckBox()
        Me.chk_manPalmTop = New System.Windows.Forms.CheckBox()
        Me.chk_manTrocas = New System.Windows.Forms.CheckBox()
        Me.chk_manEmprestimos = New System.Windows.Forms.CheckBox()
        Me.chk_manutencao = New System.Windows.Forms.CheckBox()
        Me.chk_finFluxoCaixa = New System.Windows.Forms.CheckBox()
        Me.chk_finDespesas = New System.Windows.Forms.CheckBox()
        Me.chk_finRecebimento = New System.Windows.Forms.CheckBox()
        Me.chk_finPagamento = New System.Windows.Forms.CheckBox()
        Me.chk_financeiro = New System.Windows.Forms.CheckBox()
        Me.grp_acesso4 = New System.Windows.Forms.GroupBox()
        Me.chk_paraConfiguracao = New System.Windows.Forms.CheckBox()
        Me.chk_paraBackup = New System.Windows.Forms.CheckBox()
        Me.chk_paraUltilitarios = New System.Windows.Forms.CheckBox()
        Me.chk_paraControle = New System.Windows.Forms.CheckBox()
        Me.chk_parametros = New System.Windows.Forms.CheckBox()
        Me.grp_acesso1.SuspendLayout()
        Me.grp_acesso3.SuspendLayout()
        Me.grp_acesso4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_sair
        '
        Me.btn_sair.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sair.Image = Global.RTecSys.My.Resources.Resources._Exit
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btn_sair.Location = New System.Drawing.Point(752, 529)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(71, 40)
        Me.btn_sair.TabIndex = 3
        Me.btn_sair.Text = "&Sair"
        Me.btn_sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'grp_acesso1
        '
        Me.grp_acesso1.Controls.Add(Me.chk_movAgendamentos)
        Me.grp_acesso1.Controls.Add(Me.chk_cadServico)
        Me.grp_acesso1.Controls.Add(Me.chk_movOrcamento)
        Me.grp_acesso1.Controls.Add(Me.chk_cadastros)
        Me.grp_acesso1.Controls.Add(Me.chk_Movimentos)
        Me.grp_acesso1.Controls.Add(Me.chk_cadGeno)
        Me.grp_acesso1.Controls.Add(Me.chk_cadCidade)
        Me.grp_acesso1.Controls.Add(Me.chk_cadUsuario)
        Me.grp_acesso1.Controls.Add(Me.chk_cadCliente)
        Me.grp_acesso1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.grp_acesso1.Location = New System.Drawing.Point(16, 3)
        Me.grp_acesso1.Name = "grp_acesso1"
        Me.grp_acesso1.Size = New System.Drawing.Size(159, 317)
        Me.grp_acesso1.TabIndex = 4
        Me.grp_acesso1.TabStop = False
        Me.grp_acesso1.Text = "Acesso 1"
        '
        'chk_movAgendamentos
        '
        Me.chk_movAgendamentos.AutoSize = True
        Me.chk_movAgendamentos.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_movAgendamentos.Location = New System.Drawing.Point(22, 266)
        Me.chk_movAgendamentos.Name = "chk_movAgendamentos"
        Me.chk_movAgendamentos.Size = New System.Drawing.Size(127, 23)
        Me.chk_movAgendamentos.TabIndex = 20
        Me.chk_movAgendamentos.Text = "Agendamentos"
        Me.chk_movAgendamentos.UseVisualStyleBackColor = True
        '
        'chk_cadServico
        '
        Me.chk_cadServico.AutoSize = True
        Me.chk_cadServico.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_cadServico.Location = New System.Drawing.Point(22, 126)
        Me.chk_cadServico.Name = "chk_cadServico"
        Me.chk_cadServico.Size = New System.Drawing.Size(85, 23)
        Me.chk_cadServico.TabIndex = 20
        Me.chk_cadServico.Text = "Serviços"
        Me.chk_cadServico.UseVisualStyleBackColor = True
        '
        'chk_movOrcamento
        '
        Me.chk_movOrcamento.AutoSize = True
        Me.chk_movOrcamento.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_movOrcamento.Location = New System.Drawing.Point(22, 241)
        Me.chk_movOrcamento.Name = "chk_movOrcamento"
        Me.chk_movOrcamento.Size = New System.Drawing.Size(109, 23)
        Me.chk_movOrcamento.TabIndex = 9
        Me.chk_movOrcamento.Text = "Orçamentos"
        Me.chk_movOrcamento.UseVisualStyleBackColor = True
        '
        'chk_cadastros
        '
        Me.chk_cadastros.AutoSize = True
        Me.chk_cadastros.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold)
        Me.chk_cadastros.ForeColor = System.Drawing.Color.Blue
        Me.chk_cadastros.Location = New System.Drawing.Point(6, 20)
        Me.chk_cadastros.Name = "chk_cadastros"
        Me.chk_cadastros.Size = New System.Drawing.Size(99, 24)
        Me.chk_cadastros.TabIndex = 7
        Me.chk_cadastros.Text = "Cadastro"
        Me.chk_cadastros.UseVisualStyleBackColor = True
        '
        'chk_Movimentos
        '
        Me.chk_Movimentos.AutoSize = True
        Me.chk_Movimentos.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold)
        Me.chk_Movimentos.ForeColor = System.Drawing.Color.Blue
        Me.chk_Movimentos.Location = New System.Drawing.Point(6, 211)
        Me.chk_Movimentos.Name = "chk_Movimentos"
        Me.chk_Movimentos.Size = New System.Drawing.Size(125, 24)
        Me.chk_Movimentos.TabIndex = 6
        Me.chk_Movimentos.Text = "Movimentos"
        Me.chk_Movimentos.UseVisualStyleBackColor = True
        '
        'chk_cadGeno
        '
        Me.chk_cadGeno.AutoSize = True
        Me.chk_cadGeno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_cadGeno.Location = New System.Drawing.Point(22, 152)
        Me.chk_cadGeno.Name = "chk_cadGeno"
        Me.chk_cadGeno.Size = New System.Drawing.Size(93, 23)
        Me.chk_cadGeno.TabIndex = 5
        Me.chk_cadGeno.Text = "Metrosys"
        Me.chk_cadGeno.UseVisualStyleBackColor = True
        '
        'chk_cadCidade
        '
        Me.chk_cadCidade.AutoSize = True
        Me.chk_cadCidade.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_cadCidade.Location = New System.Drawing.Point(22, 100)
        Me.chk_cadCidade.Name = "chk_cadCidade"
        Me.chk_cadCidade.Size = New System.Drawing.Size(82, 23)
        Me.chk_cadCidade.TabIndex = 4
        Me.chk_cadCidade.Text = "Cidades"
        Me.chk_cadCidade.UseVisualStyleBackColor = True
        '
        'chk_cadUsuario
        '
        Me.chk_cadUsuario.AutoSize = True
        Me.chk_cadUsuario.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_cadUsuario.Location = New System.Drawing.Point(22, 74)
        Me.chk_cadUsuario.Name = "chk_cadUsuario"
        Me.chk_cadUsuario.Size = New System.Drawing.Size(87, 23)
        Me.chk_cadUsuario.TabIndex = 2
        Me.chk_cadUsuario.Text = "Usuarios"
        Me.chk_cadUsuario.UseVisualStyleBackColor = True
        '
        'chk_cadCliente
        '
        Me.chk_cadCliente.AutoSize = True
        Me.chk_cadCliente.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_cadCliente.Location = New System.Drawing.Point(22, 48)
        Me.chk_cadCliente.Name = "chk_cadCliente"
        Me.chk_cadCliente.Size = New System.Drawing.Size(83, 23)
        Me.chk_cadCliente.TabIndex = 0
        Me.chk_cadCliente.Text = "Clientes"
        Me.chk_cadCliente.UseVisualStyleBackColor = True
        '
        'grp_acesso3
        '
        Me.grp_acesso3.Controls.Add(Me.chk_manCidadesIBGE)
        Me.grp_acesso3.Controls.Add(Me.chk_manPalmTop)
        Me.grp_acesso3.Controls.Add(Me.chk_manTrocas)
        Me.grp_acesso3.Controls.Add(Me.chk_manEmprestimos)
        Me.grp_acesso3.Controls.Add(Me.chk_manutencao)
        Me.grp_acesso3.Controls.Add(Me.chk_finFluxoCaixa)
        Me.grp_acesso3.Controls.Add(Me.chk_finDespesas)
        Me.grp_acesso3.Controls.Add(Me.chk_finRecebimento)
        Me.grp_acesso3.Controls.Add(Me.chk_finPagamento)
        Me.grp_acesso3.Controls.Add(Me.chk_financeiro)
        Me.grp_acesso3.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.grp_acesso3.Location = New System.Drawing.Point(181, 3)
        Me.grp_acesso3.Name = "grp_acesso3"
        Me.grp_acesso3.Size = New System.Drawing.Size(161, 317)
        Me.grp_acesso3.TabIndex = 18
        Me.grp_acesso3.TabStop = False
        Me.grp_acesso3.Text = "Acesso 3"
        '
        'chk_manCidadesIBGE
        '
        Me.chk_manCidadesIBGE.AutoSize = True
        Me.chk_manCidadesIBGE.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_manCidadesIBGE.Location = New System.Drawing.Point(20, 284)
        Me.chk_manCidadesIBGE.Name = "chk_manCidadesIBGE"
        Me.chk_manCidadesIBGE.Size = New System.Drawing.Size(125, 23)
        Me.chk_manCidadesIBGE.TabIndex = 32
        Me.chk_manCidadesIBGE.Text = "Cidades IBGE"
        Me.chk_manCidadesIBGE.UseVisualStyleBackColor = True
        '
        'chk_manPalmTop
        '
        Me.chk_manPalmTop.AutoSize = True
        Me.chk_manPalmTop.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_manPalmTop.Location = New System.Drawing.Point(20, 257)
        Me.chk_manPalmTop.Name = "chk_manPalmTop"
        Me.chk_manPalmTop.Size = New System.Drawing.Size(90, 23)
        Me.chk_manPalmTop.TabIndex = 31
        Me.chk_manPalmTop.Text = "Palm Top"
        Me.chk_manPalmTop.UseVisualStyleBackColor = True
        '
        'chk_manTrocas
        '
        Me.chk_manTrocas.AutoSize = True
        Me.chk_manTrocas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_manTrocas.Location = New System.Drawing.Point(20, 230)
        Me.chk_manTrocas.Name = "chk_manTrocas"
        Me.chk_manTrocas.Size = New System.Drawing.Size(73, 23)
        Me.chk_manTrocas.TabIndex = 30
        Me.chk_manTrocas.Text = "Trocas"
        Me.chk_manTrocas.UseVisualStyleBackColor = True
        '
        'chk_manEmprestimos
        '
        Me.chk_manEmprestimos.AutoSize = True
        Me.chk_manEmprestimos.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_manEmprestimos.Location = New System.Drawing.Point(20, 205)
        Me.chk_manEmprestimos.Name = "chk_manEmprestimos"
        Me.chk_manEmprestimos.Size = New System.Drawing.Size(115, 23)
        Me.chk_manEmprestimos.TabIndex = 29
        Me.chk_manEmprestimos.Text = "Emprestimos"
        Me.chk_manEmprestimos.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chk_manEmprestimos.UseVisualStyleBackColor = True
        '
        'chk_manutencao
        '
        Me.chk_manutencao.AutoSize = True
        Me.chk_manutencao.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold)
        Me.chk_manutencao.ForeColor = System.Drawing.Color.Blue
        Me.chk_manutencao.Location = New System.Drawing.Point(6, 176)
        Me.chk_manutencao.Name = "chk_manutencao"
        Me.chk_manutencao.Size = New System.Drawing.Size(115, 24)
        Me.chk_manutencao.TabIndex = 28
        Me.chk_manutencao.Text = "Manuteção"
        Me.chk_manutencao.UseVisualStyleBackColor = True
        '
        'chk_finFluxoCaixa
        '
        Me.chk_finFluxoCaixa.AutoSize = True
        Me.chk_finFluxoCaixa.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_finFluxoCaixa.Location = New System.Drawing.Point(20, 100)
        Me.chk_finFluxoCaixa.Name = "chk_finFluxoCaixa"
        Me.chk_finFluxoCaixa.Size = New System.Drawing.Size(128, 23)
        Me.chk_finFluxoCaixa.TabIndex = 27
        Me.chk_finFluxoCaixa.Text = "Fluxo de Caixa"
        Me.chk_finFluxoCaixa.UseVisualStyleBackColor = True
        '
        'chk_finDespesas
        '
        Me.chk_finDespesas.AutoSize = True
        Me.chk_finDespesas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_finDespesas.Location = New System.Drawing.Point(20, 125)
        Me.chk_finDespesas.Name = "chk_finDespesas"
        Me.chk_finDespesas.Size = New System.Drawing.Size(93, 23)
        Me.chk_finDespesas.TabIndex = 26
        Me.chk_finDespesas.Text = "Despesas"
        Me.chk_finDespesas.UseVisualStyleBackColor = True
        '
        'chk_finRecebimento
        '
        Me.chk_finRecebimento.AutoSize = True
        Me.chk_finRecebimento.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_finRecebimento.Location = New System.Drawing.Point(20, 73)
        Me.chk_finRecebimento.Name = "chk_finRecebimento"
        Me.chk_finRecebimento.Size = New System.Drawing.Size(123, 23)
        Me.chk_finRecebimento.TabIndex = 24
        Me.chk_finRecebimento.Text = "Recebimentos"
        Me.chk_finRecebimento.UseVisualStyleBackColor = True
        '
        'chk_finPagamento
        '
        Me.chk_finPagamento.AutoSize = True
        Me.chk_finPagamento.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_finPagamento.Location = New System.Drawing.Point(20, 48)
        Me.chk_finPagamento.Name = "chk_finPagamento"
        Me.chk_finPagamento.Size = New System.Drawing.Size(109, 23)
        Me.chk_finPagamento.TabIndex = 23
        Me.chk_finPagamento.Text = "Pagamentos"
        Me.chk_finPagamento.UseVisualStyleBackColor = True
        '
        'chk_financeiro
        '
        Me.chk_financeiro.AutoSize = True
        Me.chk_financeiro.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold)
        Me.chk_financeiro.ForeColor = System.Drawing.Color.Blue
        Me.chk_financeiro.Location = New System.Drawing.Point(6, 20)
        Me.chk_financeiro.Name = "chk_financeiro"
        Me.chk_financeiro.Size = New System.Drawing.Size(110, 24)
        Me.chk_financeiro.TabIndex = 22
        Me.chk_financeiro.Text = "Financeiro"
        Me.chk_financeiro.UseVisualStyleBackColor = True
        '
        'grp_acesso4
        '
        Me.grp_acesso4.Controls.Add(Me.chk_paraConfiguracao)
        Me.grp_acesso4.Controls.Add(Me.chk_paraBackup)
        Me.grp_acesso4.Controls.Add(Me.chk_paraUltilitarios)
        Me.grp_acesso4.Controls.Add(Me.chk_paraControle)
        Me.grp_acesso4.Controls.Add(Me.chk_parametros)
        Me.grp_acesso4.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.grp_acesso4.Location = New System.Drawing.Point(348, 3)
        Me.grp_acesso4.Name = "grp_acesso4"
        Me.grp_acesso4.Size = New System.Drawing.Size(161, 317)
        Me.grp_acesso4.TabIndex = 19
        Me.grp_acesso4.TabStop = False
        Me.grp_acesso4.Text = "Acesso 4"
        '
        'chk_paraConfiguracao
        '
        Me.chk_paraConfiguracao.AutoSize = True
        Me.chk_paraConfiguracao.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_paraConfiguracao.Location = New System.Drawing.Point(21, 127)
        Me.chk_paraConfiguracao.Name = "chk_paraConfiguracao"
        Me.chk_paraConfiguracao.Size = New System.Drawing.Size(117, 23)
        Me.chk_paraConfiguracao.TabIndex = 8
        Me.chk_paraConfiguracao.Text = "Configuração"
        Me.chk_paraConfiguracao.UseVisualStyleBackColor = True
        '
        'chk_paraBackup
        '
        Me.chk_paraBackup.AutoSize = True
        Me.chk_paraBackup.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_paraBackup.Location = New System.Drawing.Point(21, 100)
        Me.chk_paraBackup.Name = "chk_paraBackup"
        Me.chk_paraBackup.Size = New System.Drawing.Size(79, 23)
        Me.chk_paraBackup.TabIndex = 8
        Me.chk_paraBackup.Text = "Backup"
        Me.chk_paraBackup.UseVisualStyleBackColor = True
        '
        'chk_paraUltilitarios
        '
        Me.chk_paraUltilitarios.AutoSize = True
        Me.chk_paraUltilitarios.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_paraUltilitarios.Location = New System.Drawing.Point(21, 73)
        Me.chk_paraUltilitarios.Name = "chk_paraUltilitarios"
        Me.chk_paraUltilitarios.Size = New System.Drawing.Size(94, 23)
        Me.chk_paraUltilitarios.TabIndex = 7
        Me.chk_paraUltilitarios.Text = "Utilitarios"
        Me.chk_paraUltilitarios.UseVisualStyleBackColor = True
        '
        'chk_paraControle
        '
        Me.chk_paraControle.AutoSize = True
        Me.chk_paraControle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chk_paraControle.Location = New System.Drawing.Point(21, 48)
        Me.chk_paraControle.Name = "chk_paraControle"
        Me.chk_paraControle.Size = New System.Drawing.Size(86, 23)
        Me.chk_paraControle.TabIndex = 6
        Me.chk_paraControle.Text = "Contrôle"
        Me.chk_paraControle.UseVisualStyleBackColor = True
        '
        'chk_parametros
        '
        Me.chk_parametros.AutoSize = True
        Me.chk_parametros.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold)
        Me.chk_parametros.ForeColor = System.Drawing.Color.Blue
        Me.chk_parametros.Location = New System.Drawing.Point(6, 20)
        Me.chk_parametros.Name = "chk_parametros"
        Me.chk_parametros.Size = New System.Drawing.Size(117, 24)
        Me.chk_parametros.TabIndex = 5
        Me.chk_parametros.Text = "Parâmetros"
        Me.chk_parametros.UseVisualStyleBackColor = True
        '
        'Frm_UsuariosAcessos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 341)
        Me.Controls.Add(Me.grp_acesso4)
        Me.Controls.Add(Me.grp_acesso3)
        Me.Controls.Add(Me.grp_acesso1)
        Me.Controls.Add(Me.btn_sair)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_UsuariosAcessos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liberação de Acessos"
        Me.grp_acesso1.ResumeLayout(False)
        Me.grp_acesso1.PerformLayout()
        Me.grp_acesso3.ResumeLayout(False)
        Me.grp_acesso3.PerformLayout()
        Me.grp_acesso4.ResumeLayout(False)
        Me.grp_acesso4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_sair As System.Windows.Forms.Button
    Friend WithEvents grp_acesso1 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_cadCliente As System.Windows.Forms.CheckBox
    Friend WithEvents chk_movOrcamento As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Movimentos As System.Windows.Forms.CheckBox
    Friend WithEvents chk_cadGeno As System.Windows.Forms.CheckBox
    Friend WithEvents chk_cadCidade As System.Windows.Forms.CheckBox
    Friend WithEvents grp_acesso3 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_manPalmTop As System.Windows.Forms.CheckBox
    Friend WithEvents chk_manTrocas As System.Windows.Forms.CheckBox
    Friend WithEvents chk_manEmprestimos As System.Windows.Forms.CheckBox
    Friend WithEvents chk_manutencao As System.Windows.Forms.CheckBox
    Friend WithEvents grp_acesso4 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_parametros As System.Windows.Forms.CheckBox
    Friend WithEvents chk_paraUltilitarios As System.Windows.Forms.CheckBox
    Friend WithEvents chk_paraControle As System.Windows.Forms.CheckBox
    Friend WithEvents chk_paraBackup As System.Windows.Forms.CheckBox
    Friend WithEvents chk_manCidadesIBGE As System.Windows.Forms.CheckBox
    Friend WithEvents chk_cadServico As System.Windows.Forms.CheckBox
    Public WithEvents chk_cadastros As System.Windows.Forms.CheckBox
    Public WithEvents chk_cadUsuario As System.Windows.Forms.CheckBox
    Friend WithEvents chk_finFluxoCaixa As System.Windows.Forms.CheckBox
    Friend WithEvents chk_finDespesas As System.Windows.Forms.CheckBox
    Friend WithEvents chk_finRecebimento As System.Windows.Forms.CheckBox
    Friend WithEvents chk_finPagamento As System.Windows.Forms.CheckBox
    Friend WithEvents chk_financeiro As System.Windows.Forms.CheckBox
    Friend WithEvents chk_paraConfiguracao As System.Windows.Forms.CheckBox
    Friend WithEvents chk_movAgendamentos As System.Windows.Forms.CheckBox
End Class
