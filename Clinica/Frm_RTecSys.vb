Imports System.GC
Imports System.ComponentModel
Imports System.Threading

Public Class Frm_RTecSys

    Public rlogin As Boolean = False
    Public primeiroAcesso As Boolean = False
    Public Shared _frmRef As Frm_RTecSys
    Private linhaAtual As Integer = -1
    Private contNumThreads As Int64 = 0
    Private mcell As String
    Dim _formulario As New Windows.Forms.Form
    Dim Ximp As New Cl_bdMetrosys
    Dim mThreadLimpaObjetosMemoria As Thread
    Dim mThreadCarregaFormulario As Thread


    'Protected conexao As String = ModuloConexaoBD.conectionPadrao
    Dim msub() As String = {"00", "10", "20", "30", "40", "41", "50", "51", "60", "70", "90"}


    Private Sub ClientesFornTranspToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadClientesTSMItem.Click

        ExecutaF1()

    End Sub

    Sub ExecutaF1()

        Try

            Dim fmenucad As New Frm_MenuCadastro
            _formulario = fmenucad
            mThreadCarregaFormulario = New Threading.Thread(AddressOf carregaFormulario)
            mThreadCarregaFormulario.IsBackground = True
            mThreadCarregaFormulario.ApartmentState = Threading.ApartmentState.STA
            mThreadCarregaFormulario.Start()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        End Try

    End Sub

    Private Sub Frm_Genov_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                If MessageBox.Show("Saida do Sistema", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Close()
                End If

            Case Keys.F1
                ExecutaF1()
            Case Keys.F2
                ExecutaF2()
            Case Keys.F3
                ExecutaF3()
            Case Keys.F5
                ExecutaF5()
            Case Keys.F6
                ExecutaF6()
            Case Keys.F8
                ExecutaF8()
        End Select


    End Sub

    Sub ExecutaF8()
        Dim frmRelatDiario As New Frm_RelatDiario
        frmRelatDiario.Show()
    End Sub

    Private Sub Frm_Genov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.MaximizeBox = False
        mThreadLimpaObjetosMemoria = New Threading.Thread(AddressOf limpaObjetosMemoriaPorTempo)
        mThreadLimpaObjetosMemoria.Start()

        Dim IniLogin As New Frm_login
        _frmRef = Me
        IniLogin.ShowDialog()


        If System.IO.File.Exists(MdlEmpresaUsu.genp001.logomarcapath) Then
            Me.pbx_logoMarca.ImageLocation = MdlEmpresaUsu.genp001.logomarcapath : Me.pbx_logoMarca.Refresh()
        End If


        If rlogin = False Then

            Try
                mThreadLimpaObjetosMemoria.Abort()
                Me.Close()
                Application.Exit()
            Catch ex As Exception
            End Try


            mThreadCarregaFormulario = New Threading.Thread(AddressOf carregaFormulario)
            mThreadCarregaFormulario.Start()
            Try
                mThreadCarregaFormulario.Abort()
                Me.Close()
                Application.Exit()
            Catch ex As Exception
            End Try

            Try
                Application.ExitThread()
            Catch ex As Exception
            End Try
        End If

        If primeiroAcesso = False Then configuraTelas()

        'Me.Text = Me.Text & " - Gerencia de Clinica Odontológica" '" Ver. " & Application.ProductVersion ' & "   " & Application.CompanyName



    End Sub

    Sub limpaObjetosMemoriaPorTempo()

        While Me.Enabled

            Threading.Thread.Sleep(150000) 'Tempo que leva para coletar objetos da memória em cada 2,30minutos...
            Collect()
        End While
    End Sub

    Sub carregaFormulario()

        Dim mForm As New Form
        mForm = _formulario
        mForm.ShowDialog()

    End Sub

    Private Sub configuraTelas()

        'Cadastros....
        Me.CadastroTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_Cadastros
        Me.cadClientesTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cadcliente
        Me.cadGenovTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cadgeno

        'Movimentos...
        Me.MovimentosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_movimentos
        Me.movOrcamentosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_movorcamento
        Me.movAgendamentosToolStripMenuItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_movAgendamentos

        'Financeiro...
        Me.FinaceiroTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_financeiro
        Me.finPagamentosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_finpagamentos
        Me.finRecebimentosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_finrecebimentos
        Me.finFluxoCaixaTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_finfluxocaixa
        Me.finDespesasTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_findespesas

        'Paramentros...
        Me.ParamentrosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_parametros
        Me.paraBackupTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_parabackup


    End Sub

    Private Sub SairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click

        If MessageBox.Show("Saida do Sistema", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.Close()

        End If


    End Sub

    Private Sub UsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadUsuarioTSMItem.Click

        Dim forRegUsu As New Frm_UsuariosManutencao
        forRegUsu.Show()

    End Sub

    Private Sub GenovToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadGenovTSMItem.Click

        Dim RegGeno As New Frm_cadMetro
        RegGeno.Show()

    End Sub

    Private Sub RegistroToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroToolStripMenuItem1.Click

        ExecutaF2()

    End Sub

    Sub ExecutaF2()

        Dim ManDuplic As New Frm_Dup_ManDuplicatas
        ManDuplic.ShowDialog()
        ManDuplic.Dispose()

    End Sub

    Sub ExecutaF3()

        Dim frmMan As New Frm_ManCaixaDiario
        frmMan.Show()

    End Sub

    Private Sub movOrcamentosTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movOrcamentosTSMItem.Click

        Dim mGeraOrcamentos As New Frm_GeraOrcamento
        mGeraOrcamentos.ShowDialog()
        mGeraOrcamentos = Nothing

    End Sub

    Private Sub cadCidadesTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadCidadesTSMItem.Click

        Dim cadCidades As New Frm_CadCidades
        cadCidades.ShowDialog()
        cadCidades = Nothing

    End Sub

    Private Sub Frm_MetroSys_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            Me.pbx_logoMarca.ImageLocation = "" : Me.Refresh()
        Catch ex As Exception
        End Try

        Try

            mThreadLimpaObjetosMemoria.Abort()
        Catch ex As Exception
        End Try

        Try

            mThreadCarregaFormulario.Abort()
            'System.Threading.ThreadPool.
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RelatórioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelatórioToolStripMenuItem.Click


        Try

            Dim mFrmRelatFinanReceb As New Frm_relatFinanReceb
            mFrmRelatFinanReceb.Show()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub RegistrosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrosToolStripMenuItem.Click

        Try

            Dim mFrmManPagamentos As New Frm_ManPagamentos
            mFrmManPagamentos.Show()

        Catch ex As Exception
        End Try


    End Sub

    Private Sub RelatorioDeFluxoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelatorioDeFluxoToolStripMenuItem.Click

        ExecutaF6()
    End Sub


    Sub ExecutaF6()

        Dim mFrmRelatorioFluxo As New Frm_RelatorioFluxo
        mFrmRelatorioFluxo.Show()

    End Sub

    Private Sub LançamentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LançamentosToolStripMenuItem.Click

        Dim mFrmMenuCaixa As New Frm_MenuCX_Diario
        mFrmMenuCaixa.ShowDialog()

    End Sub

    Private Sub RelatoriosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelatoriosToolStripMenuItem.Click
        Try

            Dim mFrmRelatFinanPag As New Frm_relatFinanPaga
            mFrmRelatFinanPag.Show()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub paraBackupTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles paraBackupTSMItem.Click
        Dim FrmBackup As New Frm_Backup
        FrmBackup.ShowDialog()
    End Sub

    Private Sub SincronizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SincronizarToolStripMenuItem.Click

        If (MdlUsuarioLogando._usuarioPrivilegio = True) OrElse (MdlUsuarioLogando._cargo = 2) Then 'Cargo 2 = Gerente

            If MessageBox.Show("Deseja Sincronizar?", "Metrosys", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
            Windows.Forms.DialogResult.Yes Then

                Dim funcoes As New ClFuncoes
                funcoes.atualizaSincronizacaoBD(True, MdlConexaoBD.conectionPadrao)
                funcoes.atualizaSincronizacaoGenp001(True, MdlConexaoBD.conectionPadrao)
                funcoes = Nothing : MsgBox("Sincronização OK!", MsgBoxStyle.Exclamation)

                Try
                    mThreadLimpaObjetosMemoria.Abort()
                    Application.ExitThread()
                    Application.Exit()
                Catch ex As Exception
                End Try


                mThreadCarregaFormulario = New Threading.Thread(AddressOf carregaFormulario)
                mThreadCarregaFormulario.Start()
                Try
                    mThreadCarregaFormulario.Abort()
                    Application.Exit()
                Catch ex As Exception
                End Try

                Try
                    Application.ExitThread()
                    Application.Exit()
                Catch ex As Exception
                End Try

            Else

                Dim funcoes As New ClFuncoes
                funcoes.atualizaSincronizacaoBD(False, MdlConexaoBD.conectionPadrao)
                funcoes.atualizaSincronizacaoGenp001(False, MdlConexaoBD.conectionPadrao)
                funcoes = Nothing
            End If


        End If

    End Sub

    Private Sub finDespesasTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles finDespesasTSMItem.Click

        Dim menuDespesas As New Frm_Menudespesas
        menuDespesas.ShowDialog()
        menuDespesas = Nothing

    End Sub

    Private Sub cadServicosTSMItem_Click(sender As Object, e As EventArgs) Handles cadServicosTSMItem.Click

        Dim cadServico As New Frm_CadServico
        cadServico.ShowDialog()
        cadServico = Nothing

    End Sub

    Private Sub DoutoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DoutoresToolStripMenuItem.Click

        Dim cadDoutor As New Frm_CadDentistas
        cadDoutor.ShowDialog()
        cadDoutor = Nothing

    End Sub

    Private Sub AgendamentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles movAgendamentosToolStripMenuItem.Click
        ExecutaF5()
    End Sub

    Sub ExecutaF5()
        Dim manAgend As New Frm_ManAgendamentos
        manAgend.Show()
    End Sub

    Private Sub DescriçõesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescriçõesToolStripMenuItem.Click

        Dim manDescricoes As New Frm_CadDespesasReceitas
        manDescricoes.Show()

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        txt_hora.Text = Mid(TimeString, 1, 5)
    End Sub

    Private Sub RelatDiarioTSMI_Click(sender As Object, e As EventArgs) Handles RelatDiarioTSMI.Click
        Dim frmRelatDiario As New Frm_RelatDiario
        frmRelatDiario.Show()
    End Sub

    Private Sub TipoDeAtendimentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoDeAtendimentoToolStripMenuItem.Click
        Dim frmTpAtendimeto As New Frm_TpAtendimento
        frmTpAtendimeto.Show()
    End Sub

    Private Sub RelatoriosTSMI_Click(sender As Object, e As EventArgs) Handles RelatoriosTSMI.Click
        Dim frmMenuRelMovimento As New Frm_MenuMovRelatorios
        frmMenuRelMovimento.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Dim frmCMensal As New Frm_ControleMensal
        frmCMensal.Show()
    End Sub

    Private Sub ControleDeCartaoTSMI_Click(sender As Object, e As EventArgs) Handles ControleDeCartaoTSMI.Click

        Dim frmCCartao As New Frm_ControleCartao
        frmCCartao.Show()

    End Sub

    Private Sub OutrosDentistasTSMI_Click(sender As Object, e As EventArgs) Handles OutrosDentistasTSMI.Click

        Dim frmDentistaOutras As New Frm_CadDentistasOutras
        frmDentistaOutras.Show()

    End Sub

    Private Sub ControleDeDentistasTSMI_Click(sender As Object, e As EventArgs) Handles ControleDeDentistasTSMI.Click

        Dim frmCDivOutras As New Frm_ContrDivOutras
        frmCDivOutras.Show()

    End Sub

    Private Sub finFluxoCaixaTSMItem_Click(sender As Object, e As EventArgs) Handles finFluxoCaixaTSMItem.Click

    End Sub
End Class
