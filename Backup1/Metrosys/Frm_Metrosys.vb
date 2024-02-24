Imports System.GC
Imports System.ComponentModel
Imports System.Threading

Public Class Frm_MetroSys

    Public rlogin As Boolean = False
    Public primeiroAcesso As Boolean = False
    Public Shared _frmRef As Frm_MetroSys
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

        If (e.KeyCode = Keys.Escape) Then

            If MessageBox.Show("Saida do Sistema", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Me.Close()

            End If
        End If



    End Sub

    Private Sub Frm_Genov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        mThreadLimpaObjetosMemoria = New Threading.Thread(AddressOf limpaObjetosMemoriaPorTempo)
        mThreadLimpaObjetosMemoria.Start()

        Dim IniLogin As New Frm_login
        _frmRef = Me
        IniLogin.ShowDialog()


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

        Me.Text = Me.Text & " Ver. " & Application.ProductVersion ' & "   " & Application.CompanyName
        


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
        Me.cadVendedoresTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cadvendedor
        Me.cadUsuarioTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cadusuario
        Me.cadTitularesTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cadtitular
        Me.cadCidadesTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cadcidade
        Me.cadComodatosToolStripMenuItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cadcomodato
        Me.cadServicosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cadservico
        Me.cadAutomovelMapaToolStripMenuItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cadautomovel
        Me.cadGeraisToolStripMenuItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cadgerais
        Me.cadGerenteToolStripMenuItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cadgerente
        Me.cadGenovTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cadgeno

        'Movimentos...
        Me.MovimentosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_movimentos
        Me.movPedidosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_movpedido
        Me.movOrcamentosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_movorcamento
        Me.movTransferenciasTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_movtransferencia
        Me.movNFeTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_movnfe
        Me.movRequisiçãoToolStripMenuItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_movrequisicao
        Me.movEmissãoDePedidosToolStripMenuItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_movemisspedido
        Me.movGeraMapaToolStripMenuItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_movgeramapa
        Me.PagoAEntregarToolStripMenuItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_movpagoentregar

        'Mapas...
        Me.MapaTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_mapas
        Me.mpMapaVendaTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_mpvenda
        Me.mpRetornoVendasTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_mpretornovenda

        'Cupom...
        Me.CupomTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cupom
        Me.cpPreVendaTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cpprevenda
        Me.cpVendaDiretaTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cpvendadireta
        Me.cpConfiguracaoTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_cpconfiguracao

        'Estoque...
        Me.EstoqueTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_estoque
        Me.estPesquisaTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_estpesquisa
        Me.estRestauraTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_estrestaura
        Me.estImplantacaoTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_estimplantacao
        Me.estPedidoComprasTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_estpedidocompras
        Me.estComprasTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_estcompras
        Me.estAtualizacaoTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_estatualizacao
        Me.estRelatoriosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_estrelatorios

        'Financeiro...
        Me.FinaceiroTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_financeiro
        Me.finPagamentosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_finpagamentos
        Me.finRecebimentosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_finrecebimentos
        Me.finFluxoCaixaTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_finfluxocaixa
        Me.finDespesasTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_findespesas
        Me.finChqPreDatadoTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_finchqPreDatado

        'Manutenção...
        Me.ManutencaoTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_manutencao
        Me.manEmprestimosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_manemprestimos
        Me.manTrocasTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_mantrocas
        Me.manPalmTopTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_manpalmtop
        Me.manCidadesIbgeTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_mancidadesibge

        'Contábil...
        Me.ContabilTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_contabil
        Me.ctbArqDigitaisTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_ctbarqdigitais
        Me.ctbLivrosFiscaisTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_ctblivrosfiscais
        Me.ctbContadorTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_ctbcontador
        Me.ctbCFOPTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_ctbcfop

        'Paramentros...
        Me.ParamentrosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_parametros
        Me.paraControleTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_paracontrole
        Me.paraUtilitariosTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_paraultilitarios
        Me.paraBackupTSMItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_parabackup
        Me.paraConfiguraçõesToolStripMenuItem.Visible = MdlTelasAcesso._usuarioTelas.pTl_paraconfiguracao


    End Sub

    Private Sub SairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click

        If MessageBox.Show("Saida do Sistema", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.Close()

        End If


    End Sub

    Private Sub PedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movPedidosTSMItem.Click

        Try

            Dim formPedido As New Frm_GeraPedidos
            _formulario = formPedido
            contNumThreads += 1
            mThreadCarregaFormulario = New Threading.Thread(AddressOf carregaFormulario)
            mThreadCarregaFormulario.IsBackground = True
            mThreadCarregaFormulario.ApartmentState = Threading.ApartmentState.STA
            mThreadCarregaFormulario.Start()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        End Try
        


    End Sub

    Private Sub UsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadUsuarioTSMItem.Click

        Dim forRegUsu As New Frm_UsuariosManutencao
        forRegUsu.Show()

    End Sub

    Private Sub GenovToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadGenovTSMItem.Click

        Dim RegGeno As New Frm_cadMetro
        RegGeno.Show()

    End Sub

    Private Sub LivroDeEntradasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LivroDeEntradasToolStripMenuItem.Click

        Dim LivroEnt As New Frm_CTBLivroEntradas
        LivroEnt.Show()

    End Sub

    Private Sub LivroDeSaidasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LivroDeSaidasToolStripMenuItem.Click

        Dim LivroSai As New Frm_CTBLivrodeSaidas
        LivroSai.Show()

    End Sub

    Private Sub ImportaEstoqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportaEstoqueToolStripMenuItem.Click

        Dim impProd As New Form_importaProdutos
        impProd.Show()

    End Sub

    Private Sub PesquisaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles estPesquisaTSMItem.Click

        Dim PesqProd As New Frm_PesquisaProdutos
        PesqProd.Show()

    End Sub

    Private Sub AtualizaCaixasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtualizaCaixasToolStripMenuItem.Click

        Dim FormCaixas As New Frm_AtualizaCaixas
        FormCaixas.Show()

    End Sub

    Private Sub ContadorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctbContadorTSMItem.Click

        Dim DadoContab As New Frm_DadosContador
        DadoContab.Show()

    End Sub

    Private Sub ManutençãoDeComprasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManutençãoDeComprasToolStripMenuItem.Click

        Dim Compras As New Frm_MenuCompras ' Frm_MenuCompras 'Frm_Compras
        Compras.Show()

    End Sub

    Private Sub ServiçosTelefonicosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiçosTelefonicosToolStripMenuItem.Click

        Dim ManServFone As New Frm_ManComunicacao
        ManServFone.Show()

    End Sub

    Private Sub ServiçosDeEnergiaEletricaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiçosDeEnergiaEletricaToolStripMenuItem.Click

        Dim ManServEnerg As New Frm_ManEnergia
        ManServEnerg.Show()

    End Sub

    Private Sub PosicaoDeEstoqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PosicaoDeEstoqueToolStripMenuItem.Click

        Dim Relestoq As New Frm_Relatorio_002
        Relestoq.Show()

    End Sub

    Private Sub XToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XToolStripMenuItem.Click

        Dim CompPedidos As New Frm_MenuPedidoCompras
        CompPedidos.Show()

    End Sub

    Private Sub SintegraGeralToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SintegraGeralToolStripMenuItem1.Click

        Dim GeraSintegra As New Frm_Sintegra
        GeraSintegra.Show()

    End Sub

    Private Sub TesteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TesteToolStripMenuItem.Click

        Try
            Dim procID As Integer
            procID = Shell("C:\Wged\GenoSped32\GenoSped32.exe", AppWinStyle.NormalFocus)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try



    End Sub

    Private Sub EntradasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntradasToolStripMenuItem.Click

        Dim cfopG As New Frm_CFOPEntradasSaidas
        cfopG.ShowDialog()
        cfopG = Nothing

    End Sub

    Private Sub NotasFiscalEletronicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movNFeTSMItem.Click

        Dim nfeG As New Frm_GeraNotasFiscais
        nfeG.Show()

    End Sub

    Private Sub RegistroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroToolStripMenuItem.Click

        Dim manProd As New Frm_ManProdutos
        manProd.Show()

    End Sub

    Private Sub VendedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadVendedoresTSMItem.Click

        Dim manVend As New Frm_ManVendedores
        manVend.ShowDialog()
        manVend.Dispose()

    End Sub

    Private Sub ChamaMapasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mpMapaVendaTSMItem.Click

        Dim RegMapa As New Frm_ManMapas
        RegMapa.Show()

    End Sub

    Private Sub ManutençãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mpRetornoVendasTSMItem.Click

        Dim retornoVendas As New Frm_ManRetorMp
        retornoVendas.Show()

    End Sub

    Private Sub RegistroToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroToolStripMenuItem1.Click

        Dim ManDuplic As New Frm_Dup_ManDuplicatas
        ManDuplic.ShowDialog()
        ManDuplic.Dispose()

    End Sub

    Private Sub CadastroDeImobilizadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroDeImobilizadoToolStripMenuItem.Click

        Dim CMDComod As New Frm_ManComodato
        CMDComod.Show()

    End Sub

    Private Sub EmprestimosComodatosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmprestimosComodatosToolStripMenuItem.Click

        Dim MovComodat As New Frm_ManMovComodato
        MovComodat.Show()

    End Sub

    Private Sub ManutençãoToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManutençãoToolStripMenuItem.Click

        Dim manRequisicao As New Frm_ManRequMatPrima
        manRequisicao.Show()

    End Sub

    Private Sub ManutençãoProdAcabadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManutençãoProdAcabadoToolStripMenuItem.Click

        Dim manRequisicao As New Frm_ManRequAcabado
        manRequisicao.Show()

    End Sub


    Private Sub AutomovelMapaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadAutomovelMapaToolStripMenuItem.Click

        Dim manAutomovel As New Frm_cadAutomovel
        manAutomovel.Show()

    End Sub

    Private Sub movOrcamentosTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movOrcamentosTSMItem.Click

        Dim mGeraOrcamentos As New Frm_GeraOrcamento
        mGeraOrcamentos.ShowDialog()
        mGeraOrcamentos = Nothing

    End Sub

    Private Sub EmissãoDePedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movEmissãoDePedidosToolStripMenuItem.Click

        Dim GeraPedidos As New Frm_GeraPedidos
        GeraPedidos.ShowDialog()
        GeraPedidos = Nothing

    End Sub

    Private Sub RegistroToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroToolStripMenuItem2.Click

        Dim FormGerente As New Frm_CadGerente
        FormGerente.ShowDialog()
        FormGerente = Nothing

    End Sub

    Private Sub AtualizaFilial1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtualizaFilial1ToolStripMenuItem.Click

        Dim altEstoque As New Frm_altEstoque
        altEstoque.ShowDialog()
        altEstoque = Nothing

    End Sub


    Private Sub CadUnidadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadUnidadesToolStripMenuItem.Click

        Dim cadUnidades As New Frm_CadUnidades
        cadUnidades.ShowDialog()
        cadUnidades = Nothing

    End Sub

    Private Sub cadCidadesTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadCidadesTSMItem.Click

        Dim cadCidades As New Frm_CadCidades
        cadCidades.ShowDialog()
        cadCidades = Nothing

    End Sub

    Private Sub Frm_MetroSys_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub CondiçõesDePagamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CondiçõesDePagamentoToolStripMenuItem.Click

        Dim condPagto As New Frm_cadCondPagto
        condPagto.ShowDialog()
        condPagto = Nothing

    End Sub

    Private Sub CadastroDeRotasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroDeRotasToolStripMenuItem.Click

        Dim cadRotas As New Frm_CadRotas
        cadRotas.ShowDialog()
        cadRotas = Nothing

    End Sub

    Private Sub TabelaDePreçosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabelaDePreçosToolStripMenuItem.Click

        Dim atualTabelaPrecos As New Frm_ManTabelaPrecos
        atualTabelaPrecos.ShowDialog()
        atualTabelaPrecos = Nothing
    End Sub

    Private Sub MontaCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MontaCargaToolStripMenuItem.Click

        Dim mFrmMontCarga As New Frm_ManCargas
        mFrmMontCarga.ShowDialog()
        mFrmMontCarga = Nothing
    End Sub

    Private Sub CorteDeProdutosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorteDeProdutosToolStripMenuItem.Click

        Dim mFrmCorteCarga As New Frm_CorteCargas
        mFrmCorteCarga.ShowDialog()
        mFrmCorteCarga = Nothing

    End Sub

    Private Sub ManifestoFinanceiroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManifestoFinanceiroToolStripMenuItem.Click

        Dim mFrmManifestoCarga As New Frm_ManifestoCarga
        mFrmManifestoCarga.ShowDialog()
        mFrmManifestoCarga = Nothing
    End Sub

    Private Sub cpConfiguracaoTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cpConfiguracaoTSMItem.Click

        Dim mFrmConfImpressora As New Frm_ConfiguraCupomFiscal
        mFrmConfImpressora.ShowDialog()
        mFrmConfImpressora = Nothing
    End Sub

    Private Sub cpVendaDiretaTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cpVendaDiretaTSMItem.Click

        Dim mFrmCPVendaDireta As New Frm_CupomVendaDireta
        mFrmCPVendaDireta.ShowDialog()
        mFrmCPVendaDireta = Nothing
    End Sub


    Private Sub RelatóriosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelatóriosToolStripMenuItem.Click

        Dim mFrmRelatComodatos As New Frm_RelatComodatos
        mFrmRelatComodatos.ShowDialog()
        mFrmRelatComodatos = Nothing
    End Sub

    Private Sub RelatórioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelatórioToolStripMenuItem.Click

        
        Try

            Dim mFrmRelatFinanReceb As New Frm_relatFinanReceb
            mFrmRelatFinanReceb.Show()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub PagoAEntregarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagoAEntregarToolStripMenuItem.Click

        
        Try

            Dim mFrmMenuPagEntregar As New Frm_MenuPagoaEntregar
            mFrmMenuPagEntregar.Show()
            '_formulario = mFrmMenuPagEntregar
            'mThreadCarregaFormulario = New Threading.Thread(AddressOf carregaFormulario)
            'mThreadCarregaFormulario.IsBackground = False
            'mThreadCarregaFormulario.ApartmentState = Threading.ApartmentState.STA
            'mThreadCarregaFormulario.Start()

        Catch ex As Exception
        End Try
        

    End Sub

    Private Sub RegistrosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrosToolStripMenuItem.Click

        Try

            Dim mFrmManPagamentos As New Frm_ManPagamentos
            mFrmManPagamentos.Show()
            '_formulario = mFrmManPagamentos
            'mThreadCarregaFormulario = New Threading.Thread(AddressOf carregaFormulario)
            'mThreadCarregaFormulario.IsBackground = False
            'mThreadCarregaFormulario.ApartmentState = Threading.ApartmentState.STA
            'mThreadCarregaFormulario.Start()

        Catch ex As Exception
        End Try
        

    End Sub

    Private Sub CadGruposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadGruposToolStripMenuItem.Click

        Try

            Dim mFrmCadGrupos As New Frm_cadGrupo
            mFrmCadGrupos.Show()
            '_formulario = mFrmCadGrupos
            'mThreadCarregaFormulario = New Threading.Thread(AddressOf carregaFormulario)
            'mThreadCarregaFormulario.IsBackground = False
            'mThreadCarregaFormulario.ApartmentState = Threading.ApartmentState.STA
            'mThreadCarregaFormulario.Start()
        Catch ex As Exception
        End Try
        

    End Sub

    Private Sub movTransferenciasTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movTransferenciasTSMItem.Click

        Try

            Dim mFrmManReqTransf As New Frm_ManReqTransferencia
            mFrmManReqTransf.Show()
            '_formulario = mFrmManReqTransf
            'mThreadCarregaFormulario = New Threading.Thread(AddressOf carregaFormulario)
            'mThreadCarregaFormulario.IsBackground = False
            'mThreadCarregaFormulario.ApartmentState = Threading.ApartmentState.STA
            'mThreadCarregaFormulario.Start()
        Catch ex As Exception
        End Try
        

    End Sub

    Private Sub PedidosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidosToolStripMenuItem.Click

        Dim mFrmRelatorioPedidos As New Frm_relatorioPedidos
        mFrmRelatorioPedidos.Show()
    End Sub

    Private Sub RelatorioDeFluxoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelatorioDeFluxoToolStripMenuItem.Click

        Dim mFrmRelatorioFluxo As New Frm_RelatorioFluxo
        mFrmRelatorioFluxo.Show()
    End Sub

    Private Sub LançamentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LançamentosToolStripMenuItem.Click

        Dim mFrmMenuCaixa As New Frm_ManCaixaDiario
        mFrmMenuCaixa.ShowDialog()
    End Sub

    Private Sub RelatoriosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelatoriosToolStripMenuItem.Click
        Try

            Dim mFrmRelatFinanPag As New Frm_relatFinanPaga
            mFrmRelatFinanPag.Show()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub CadGradeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadGradeToolStripMenuItem.Click
        Dim cadGrade As New Frm_CadGrade
        cadGrade.ShowDialog()
    End Sub

    Private Sub EntradaSimplesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntradaSimplesToolStripMenuItem.Click
        Dim FrmEntrasimples As New Frm_EntradaSimples
        FrmEntrasimples.Show()
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

    Private Sub EntradaDeTransferenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntradaDeTransferenciasToolStripMenuItem.Click

        Dim entradasTransf As New Frm_EntradasTransferencias
        entradasTransf.Show()
        entradasTransf = Nothing

    End Sub
End Class
