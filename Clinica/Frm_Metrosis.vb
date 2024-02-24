Imports System.GC

Public Class Frm_MetroSys

    Public rlogin As Integer = 0
    Private linhaAtual As Integer = -1
    Private mcell As String
    Dim Ximp As New Cl_bdMetrosys
    Dim mThreadLimpaObjetosMemoria As Threading.Thread

    'Protected conexao As String = ModuloConexaoBD.conectionPadrao
    Dim msub() As String = {"00", "10", "20", "30", "40", "41", "50", "51", "60", "70", "90"}


    Private Sub ClientesFornTranspToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadClientesTSMItem.Click

        Dim fmenucad As New Frm_MenuCadastro
        fmenucad.Show()

    End Sub

    Private Sub Frm_Genov_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If (e.KeyCode = Keys.Escape) Then

            If MessageBox.Show("Saida do Sistema", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Me.Close()

            End If
        End If



    End Sub

    Private Sub Frm_Genov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If rlogin = 0 Then

            Dim IniLogin As New Frm_login
            IniLogin.ShowDialog() : rlogin = rlogin + 1

        End If

        mThreadLimpaObjetosMemoria = New Threading.Thread(AddressOf limpaObjetosMemoriaPorTempo)
        mThreadLimpaObjetosMemoria.Start()

        configuraTelas()

        Me.Text = Me.Text & " Ver. " & Application.ProductVersion ' & "   " & Application.CompanyName


    End Sub

    Sub limpaObjetosMemoriaPorTempo()

        While Me.Enabled

            Threading.Thread.Sleep(150000) 'Tempo que leva para coletar objetos da memória em cada 2,30minutos...
            Collect()
        End While
    End Sub

    Private Sub configuraTelas()

        'Cadastros....
        Me.CadastroTSMItem.Visible = MdlTelasAcesso._tl_cadastros
        Me.cadClientesTSMItem.Visible = MdlTelasAcesso._tl_cadcliente
        Me.cadVendedoresTSMItem.Visible = MdlTelasAcesso._tl_cadvendedor
        Me.cadUsuarioTSMItem.Visible = MdlTelasAcesso._tl_cadusuario
        Me.cadTitularesTSMItem.Visible = MdlTelasAcesso._tl_cadtitular
        Me.cadCidadesTSMItem.Visible = MdlTelasAcesso._tl_cadcidade
        Me.cadServicosTSMItem.Visible = MdlTelasAcesso._tl_cadservico
        Me.cadGenovTSMItem.Visible = MdlTelasAcesso._tl_cadgeno

        'Movimentos...
        Me.MovimentosTSMItem.Visible = MdlTelasAcesso._tl_movimentos
        Me.movPedidosTSMItem.Visible = MdlTelasAcesso._tl_movpedido
        Me.movOrcamentosTSMItem.Visible = MdlTelasAcesso._tl_movorcamento
        Me.movTransferenciasTSMItem.Visible = MdlTelasAcesso._tl_movtransferencia
        Me.movNFeTSMItem.Visible = MdlTelasAcesso._tl_movnfe

        'Mapas...

        'Cupom...
        Me.CupomTSMItem.Visible = MdlTelasAcesso._tl_cupom
        Me.cpPreVendaTSMItem.Visible = MdlTelasAcesso._tl_cpprevenda
        Me.cpVendaDiretaTSMItem.Visible = MdlTelasAcesso._tl_cpvendadireta
        Me.cpConfiguracaoTSMItem.Visible = MdlTelasAcesso._tl_cpconfiguracao

        'Estoque...
        Me.EstoqueTSMItem.Visible = MdlTelasAcesso._tl_estoque
        Me.estPesquisaTSMItem.Visible = MdlTelasAcesso._tl_estpesquisa
        Me.estRestauraTSMItem.Visible = MdlTelasAcesso._tl_estrestaura
        Me.estImplantacaoTSMItem.Visible = MdlTelasAcesso._tl_estimplantacao
        Me.estPedidoComprasTSMItem.Visible = MdlTelasAcesso._tl_estpedidocompras
        Me.estComprasTSMItem.Visible = MdlTelasAcesso._tl_estcompras
        Me.estAtualizacaoTSMItem.Visible = MdlTelasAcesso._tl_estatualizacao


        'Financeiro...
        Me.FinaceiroTSMItem.Visible = MdlTelasAcesso._tl_financeiro
        Me.finPagamentosTSMItem.Visible = MdlTelasAcesso._tl_finpagamentos
        Me.finRecebimentosTSMItem.Visible = MdlTelasAcesso._tl_finrecebimentos
        Me.finFluxoCaixaTSMItem.Visible = MdlTelasAcesso._tl_finfluxocaixa
        Me.finDespesasTSMItem.Visible = MdlTelasAcesso._tl_findespesas
        Me.finChqPreDatadoTSMItem.Visible = MdlTelasAcesso._tl_finchqPreDatado

        'Manutenção...
        Me.ManutencaoTSMItem.Visible = MdlTelasAcesso._tl_manutencao
        Me.manEmprestimosTSMItem.Visible = MdlTelasAcesso._tl_manemprestimos
        Me.manTrocasTSMItem.Visible = MdlTelasAcesso._tl_mantrocas
        Me.manPalmTopTSMItem.Visible = MdlTelasAcesso._tl_manpalmtop
        Me.manCidadesIbgeTSMItem.Visible = MdlTelasAcesso._tl_mancidadesibge

        'Contábil...
        Me.ContabilTSMItem.Visible = MdlTelasAcesso._tl_contabil
        Me.ctbArqDigitaisTSMItem.Visible = MdlTelasAcesso._tl_ctbarqdigitais
        Me.ctbLivrosFiscaisTSMItem.Visible = MdlTelasAcesso._tl_ctblivrosfiscais
        Me.ctbContadorTSMItem.Visible = MdlTelasAcesso._tl_ctbcontador
        Me.ctbCFOPTSMItem.Visible = MdlTelasAcesso._tl_ctbcfop

        'Paramentros...
        Me.ParamentrosTSMItem.Visible = MdlTelasAcesso._tl_parametros
        Me.paraControleTSMItem.Visible = MdlTelasAcesso._tl_paracontrole
        Me.paraUtilitariosTSMItem.Visible = MdlTelasAcesso._tl_parautilitarios
        Me.paraBackupTSMItem.Visible = MdlTelasAcesso._tl_parabackup


    End Sub

    Private Sub SairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click

        If MessageBox.Show("Saida do Sistema", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.Close()

        End If


    End Sub

    Private Sub PedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movPedidosTSMItem.Click

        Dim formPedido As New Frm_GeraPedidos
        formPedido.Show()

    End Sub

    Private Sub UsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadUsuarioTSMItem.Click

        Dim forRegUsu As New Frm_UsuariosManutencao
        forRegUsu.Show()

    End Sub

    Private Sub GenovToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadGenovTSMItem.Click

        Dim RegGeno As New Frm_cadGeno
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

        Dim PesqProd As New Frm_ManProdutos
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

        Dim Relestoq As New Frm_Relatorio_001
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

    End Sub

    Private Sub NotasFiscalEletronicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movNFeTSMItem.Click

        Dim nfeG As New Frm_GeraNotasFiscais
        nfeG.ShowDialog()

    End Sub

    Private Sub RegistroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroToolStripMenuItem.Click

        Dim manProd As New Frm_ManProdutos
        manProd.Show()

    End Sub

    Private Sub VendedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadVendedoresTSMItem.Click

        Dim manVend As New Frm_ManVendedores
        manVend.ShowDialog()

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


    Private Sub AutomovelMapaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutomovelMapaToolStripMenuItem.Click

        Dim manAutomovel As New Frm_cadAutomovel
        manAutomovel.Show()

    End Sub

    Private Sub movOrcamentosTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movOrcamentosTSMItem.Click

        'Dim baixaFinaceiro As New Frm_BaixaFinancRMp
        'baixaFinaceiro.ShowDialog()

    End Sub

    Private Sub EmissãoDePedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmissãoDePedidosToolStripMenuItem.Click

        Dim GeraPedidos As New Frm_GeraPedidos
        GeraPedidos.ShowDialog()

    End Sub

    Private Sub RegistroToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroToolStripMenuItem2.Click

        Dim FormGerente As New Frm_CadGerente
        FormGerente.ShowDialog()

    End Sub

    Private Sub AtualizaFilial1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtualizaFilial1ToolStripMenuItem.Click

        Dim altEstoque As New Frm_altEstoque
        altEstoque.ShowDialog()

    End Sub


    Private Sub CadUnidadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadUnidadesToolStripMenuItem.Click

        Dim cadUnidades As New Frm_CadUnidades
        cadUnidades.ShowDialog()

    End Sub

    Private Sub cadCidadesTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cadCidadesTSMItem.Click

        Dim cadCidades As New Frm_CadCidades
        cadCidades.ShowDialog()

    End Sub

    Private Sub Frm_MetroSys_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            mThreadLimpaObjetosMemoria.Abort()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CondiçõesDePagamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CondiçõesDePagamentoToolStripMenuItem.Click

        Dim condPagto As New Frm_cadCondPagto
        condPagto.ShowDialog()

    End Sub

    Private Sub CadastroDeRotasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroDeRotasToolStripMenuItem.Click

        Dim cadRotas As New Frm_CadRotas
        cadRotas.ShowDialog()

    End Sub

    Private Sub TabelaDePreçosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabelaDePreçosToolStripMenuItem.Click

        Dim atualTabelaPrecos As New Frm_ManTabelaPrecos
        atualTabelaPrecos.ShowDialog()
    End Sub

    Private Sub MontaCargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MontaCargaToolStripMenuItem.Click

        Dim mFrmMontCarga As New Frm_ManCargas
        mFrmMontCarga.ShowDialog()

    End Sub

    Private Sub CorteDeProdutosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorteDeProdutosToolStripMenuItem.Click

        Dim mFrmCorteCarga As New Frm_CorteCargas
        mFrmCorteCarga.ShowDialog()

    End Sub

    Private Sub ManifestoFinanceiroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManifestoFinanceiroToolStripMenuItem.Click

        Dim mFrmManifestoCarga As New Frm_ManifestoCarga
        mFrmManifestoCarga.ShowDialog()
    End Sub

    Private Sub cpConfiguracaoTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cpConfiguracaoTSMItem.Click

        Dim mFrmConfImpressora As New Frm_ConfiguraCupomFiscal
        mFrmConfImpressora.ShowDialog()
    End Sub

    Private Sub cpVendaDiretaTSMItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cpVendaDiretaTSMItem.Click

        Dim mFrmCPVendaDireta As New Frm_CupomVendaDireta
        mFrmCPVendaDireta.ShowDialog()
    End Sub
End Class
