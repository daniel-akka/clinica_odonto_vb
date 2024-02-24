Public Class Frm_UsuariosAcessos
    Public _formRequest As New Frm_UsuariosManutencao
    Public Shared _frmRefAcesso As New Frm_UsuariosAcessos

    Private Sub Frm_UsuariosAcessos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Escape) Then _frmRefAcesso = Me : Me.Close()

    End Sub

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click

        _frmRefAcesso = Me : Me.Close()

    End Sub

    Private Sub chq_cadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cadastros.Click, chk_cadastros.KeyDown

        If chk_cadastros.Checked = False Then

            If (chk_cadCliente.Checked = True) OrElse (chk_cadVendedor.Checked = True) OrElse _
            (chk_cadUsuario.Checked = True) OrElse (chk_cadTitular.Checked = True) OrElse _
            (chk_cadCidade.Checked = True) OrElse (chk_cadComodato.Checked = True) OrElse _
            (chk_cadServico.Checked = True) OrElse (chk_cadAutomovel.Checked = True) OrElse _
            (chk_cadGerais.Checked = True) OrElse (chk_cadGerente.Checked = True) OrElse _
            (chk_cadGeno.Checked = True) Then

                chk_cadastros.Checked = True

            End If
        Else

            If (chk_cadCliente.Checked = False) And (chk_cadVendedor.Checked = False) And _
           (chk_cadUsuario.Checked = False) And (chk_cadTitular.Checked = False) And _
           (chk_cadCidade.Checked = False) And (chk_cadComodato.Checked = False) And _
           (chk_cadServico.Checked = False) And (chk_cadAutomovel.Checked = False) And _
           (chk_cadGerais.Checked = False) And (chk_cadGerente.Checked = False) And _
           (chk_cadGeno.Checked = False) Then
                'Marca todos do menu cadastro...
                chk_cadCliente.Checked = True : chk_cadVendedor.Checked = True
                chk_cadUsuario.Checked = True : chk_cadTitular.Checked = True
                chk_cadCidade.Checked = True : chk_cadComodato.Checked = True
                chk_cadServico.Checked = True : chk_cadAutomovel.Checked = True
                chk_cadGerais.Checked = True : chk_cadGerente.Checked = True
                chk_cadGeno.Checked = True

            End If
        End If
        _formRequest._frmRef._clUsuarioTelas.pTl_Cadastros = chk_cadastros.Checked



    End Sub

    Private Sub chk_Movimentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Movimentos.Click, chk_Movimentos.KeyDown

        If chk_Movimentos.Checked = False Then

            If (chk_movPedido.Checked = True) OrElse (chk_movOrcamento.Checked = True) OrElse _
            (chk_movTransferencia.Checked = True) OrElse (chk_movNFe.Checked = True) OrElse _
            (chk_movRequisicao.Checked = True) OrElse (chk_movEmissPedido.Checked = True) OrElse _
            (chk_movGeraMapa.Checked = True) OrElse (chk_movPagoEntregar.Checked = True) Then

                chk_Movimentos.Checked = True

            End If
        Else

            If (chk_movPedido.Checked = False) And (chk_movOrcamento.Checked = False) And _
            (chk_movTransferencia.Checked = False) And (chk_movNFe.Checked = False) And _
            (chk_movRequisicao.Checked = False) And (chk_movEmissPedido.Checked = False) And _
            (chk_movGeraMapa.Checked = False) And (chk_movPagoEntregar.Checked = False) Then

                chk_movPedido.Checked = True : chk_movOrcamento.Checked = True
                chk_movTransferencia.Checked = True : chk_movNFe.Checked = True
                chk_movRequisicao.Checked = True : chk_movEmissPedido.Checked = True
                chk_movGeraMapa.Checked = True : chk_movPagoEntregar.Checked = True

            End If

        End If
        _formRequest._frmRef._clUsuarioTelas.pTl_movimentos = chk_Movimentos.Checked



    End Sub

    Private Sub chk_cupom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cupom.Click, chk_cupom.KeyDown

        If chk_cupom.Checked = False Then

            If (chk_cpPreVenda.Checked = True) OrElse (chk_cpVendaDireta.Checked = True) OrElse _
            (chk_cpConfiguracao.Checked = True) Then

                chk_cupom.Checked = True

            End If
        Else

            If (chk_cpPreVenda.Checked = False) And (chk_cpVendaDireta.Checked = False) And _
            (chk_cpConfiguracao.Checked = False) Then

                chk_cpPreVenda.Checked = True : chk_cpVendaDireta.Checked = True
                chk_cpConfiguracao.Checked = True

            End If

        End If
        _formRequest._frmRef._clUsuarioTelas.pTl_cupom = chk_cupom.Checked



    End Sub

    Private Sub chk_estoque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_estoque.Click, chk_estoque.KeyDown

        If chk_estoque.Checked = False Then

            If (chk_estPesquisa.Checked = True) OrElse (chk_estRestaura.Checked = True) OrElse _
            (chk_estImplantacao.Checked = True) OrElse (chk_estPedidoCompra.Checked = True) OrElse _
            (chk_estcompras.Checked = True) OrElse (chk_estatualizacao.Checked = True) OrElse _
            (chk_estRelatorios.Checked = True) Then

                chk_estoque.Checked = True

            End If
        Else

            If (chk_estPesquisa.Checked = False) And (chk_estRestaura.Checked = False) And _
           (chk_estImplantacao.Checked = False) And (chk_estPedidoCompra.Checked = False) And _
           (chk_estcompras.Checked = False) And (chk_estatualizacao.Checked = False) And _
           (chk_estRelatorios.Checked = False) Then

                chk_estPesquisa.Checked = True : chk_estRestaura.Checked = True
                chk_estImplantacao.Checked = True : chk_estPedidoCompra.Checked = True
                chk_estcompras.Checked = True : chk_estatualizacao.Checked = True
                chk_estRelatorios.Checked = True

            End If

        End If
        _formRequest._frmRef._clUsuarioTelas.pTl_estoque = chk_estoque.Checked



    End Sub

    Private Sub chk_financeiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_financeiro.Click, chk_financeiro.KeyDown

        If chk_financeiro.Checked = False Then

            If (chk_finPagamento.Checked = True) OrElse (chk_finRecebimento.Checked = True) OrElse _
            (chk_finFluxoCaixa.Checked = True) OrElse (chk_finDespesas.Checked = True) OrElse _
            (chk_finChqPreDatado.Checked = True) Then

                chk_financeiro.Checked = True

            End If
        Else

            If (chk_finPagamento.Checked = False) And (chk_finRecebimento.Checked = False) And _
            (chk_finFluxoCaixa.Checked = False) And (chk_finDespesas.Checked = False) And _
            (chk_finChqPreDatado.Checked = False) Then

                chk_finPagamento.Checked = True : chk_finRecebimento.Checked = True
                chk_finFluxoCaixa.Checked = True : chk_finDespesas.Checked = True
                chk_finChqPreDatado.Checked = True

            End If

        End If
        _formRequest._frmRef._clUsuarioTelas.pTl_financeiro = chk_financeiro.Checked



    End Sub

    Private Sub chk_manutencao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_manutencao.Click, chk_manutencao.KeyDown

        If chk_manutencao.Checked = False Then

            If (chk_manEmprestimos.Checked = True) OrElse (chk_manTrocas.Checked = True) OrElse _
            (chk_manPalmTop.Checked = True) OrElse (chk_manCidadesIBGE.Checked = True) Then

                chk_manutencao.Checked = True

            End If
        Else

            If (chk_manEmprestimos.Checked = False) And (chk_manTrocas.Checked = False) And _
            (chk_manPalmTop.Checked = False) And (chk_manCidadesIBGE.Checked = False) Then

                chk_manEmprestimos.Checked = True : chk_manTrocas.Checked = True
                chk_manPalmTop.Checked = True : chk_manCidadesIBGE.Checked = True

            End If

        End If
        _formRequest._frmRef._clUsuarioTelas.pTl_manutencao = chk_manutencao.Checked



    End Sub

    Private Sub chk_contabil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_contabil.Click, chk_contabil.KeyDown

        If chk_contabil.Checked = False Then

            If (chk_ctbArqDigital.Checked = True) OrElse (chk_ctbLivrosFiscais.Checked = True) OrElse _
            (chk_ctbContador.Checked = True) OrElse (chk_ctbCfop.Checked = True) Then

                chk_contabil.Checked = True

            End If
        Else

            If (chk_ctbArqDigital.Checked = False) And (chk_ctbLivrosFiscais.Checked = False) And _
            (chk_ctbContador.Checked = False) And (chk_ctbCfop.Checked = False) Then

                chk_ctbArqDigital.Checked = True : chk_ctbLivrosFiscais.Checked = True
                chk_ctbContador.Checked = True : chk_ctbCfop.Checked = True

            End If

        End If
        _formRequest._frmRef._clUsuarioTelas.pTl_contabil = chk_contabil.Checked



    End Sub

    Private Sub chk_paramentros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_parametros.Click, chk_parametros.KeyDown

        If chk_parametros.Checked = False Then

            If (chk_paraControle.Checked = True) OrElse (chk_paraUltilitarios.Checked = True) OrElse _
            (chk_paraBackup.Checked = True) OrElse (chk_paraConfiguracao.Checked = True) Then

                chk_parametros.Checked = True

            End If
        Else

            If (chk_paraControle.Checked = False) And (chk_paraUltilitarios.Checked = False) And _
            (chk_paraBackup.Checked = False) And (chk_paraConfiguracao.Checked = False) Then

                chk_paraControle.Checked = True : chk_paraUltilitarios.Checked = True
                chk_paraBackup.Checked = True : chk_paraConfiguracao.Checked = True

            End If

        End If
        _formRequest._frmRef._clUsuarioTelas.pTl_parametros = chk_parametros.Checked



    End Sub

    Private Sub chk_cadCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cadVendedor.Click, chk_cadUsuario.Click, chk_cadTitular.Click, chk_cadServico.Click, chk_cadGeno.Click, chk_cadCliente.Click, chk_cadCidade.Click, chk_cadAutomovel.Click, chk_cadComodato.Click, chk_cadGerais.Click, chk_cadGerente.Click, chk_cadVendedor.KeyDown, chk_cadUsuario.KeyDown, chk_cadTitular.KeyDown, chk_cadServico.KeyDown, chk_cadGeno.KeyDown, chk_cadCliente.KeyDown, chk_cadCidade.KeyDown, chk_cadAutomovel.KeyDown, chk_cadComodato.KeyDown, chk_cadGerais.KeyDown, chk_cadGerente.KeyDown

        _formRequest._frmRef._clUsuarioTelas.pTl_cadcliente = chk_cadCliente.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadvendedor = chk_cadVendedor.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadusuario = chk_cadUsuario.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadtitular = chk_cadTitular.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadcidade = chk_cadCidade.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadcomodato = chk_cadComodato.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadservico = chk_cadServico.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadautomovel = chk_cadAutomovel.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadgerais = chk_cadGerais.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadgerente = chk_cadGerente.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadgeno = chk_cadGeno.Checked

        If (chk_cadCliente.Checked = False) And (chk_cadVendedor.Checked = False) And _
           (chk_cadUsuario.Checked = False) And (chk_cadTitular.Checked = False) And _
           (chk_cadCidade.Checked = False) And (chk_cadComodato.Checked = False) And _
           (chk_cadServico.Checked = False) And (chk_cadAutomovel.Checked = False) And _
           (chk_cadGerais.Checked = False) And (chk_cadGerente.Checked = False) And _
           (chk_cadGeno.Checked = False) Then

            chk_cadastros.Checked = False

        ElseIf (chk_cadCliente.Checked = True) OrElse (chk_cadVendedor.Checked = True) OrElse _
            (chk_cadUsuario.Checked = True) OrElse (chk_cadTitular.Checked = True) OrElse _
            (chk_cadCidade.Checked = True) OrElse (chk_cadComodato.Checked = True) OrElse _
            (chk_cadServico.Checked = True) OrElse (chk_cadAutomovel.Checked = True) OrElse _
            (chk_cadGerais.Checked = True) OrElse (chk_cadGerente.Checked = True) OrElse _
            (chk_cadGeno.Checked = True) Then

            If chk_cadastros.Checked = False Then chk_cadastros.Checked = True

        End If



    End Sub

    Private Sub chk_movPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_movTransferencia.Click, chk_movPedido.Click, chk_movOrcamento.Click, chk_movNFe.Click, chk_cancelarExcluir.Click, chk_movEmissPedido.Click, chk_movRequisicao.Click, chk_movGeraMapa.Click, chk_movPagoEntregar.Click, chk_movTransferencia.KeyDown, chk_movPedido.KeyDown, chk_movOrcamento.KeyDown, chk_movNFe.KeyDown, chk_cancelarExcluir.KeyDown, chk_movEmissPedido.KeyDown, chk_movRequisicao.KeyDown, chk_movGeraMapa.KeyDown, chk_movPagoEntregar.KeyDown

        _formRequest._frmRef._clUsuarioTelas.pTl_movpedido = chk_movPedido.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movorcamento = chk_movOrcamento.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movtransferencia = chk_movTransferencia.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movnfe = chk_movNFe.Checked
        _formRequest._frmRef._clUsuarioTelas.pBtn_cancelarExcluir = chk_cancelarExcluir.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movrequisicao = chk_movRequisicao.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movemisspedido = chk_movEmissPedido.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movgeramapa = chk_movGeraMapa.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movpagoentregar = chk_movPagoEntregar.Checked


        If (chk_movPedido.Checked = False) And (chk_movOrcamento.Checked = False) And _
           (chk_movTransferencia.Checked = False) And (chk_movNFe.Checked = False) And _
           (chk_movRequisicao.Checked = False) And (chk_movEmissPedido.Checked = False) And _
           (chk_movGeraMapa.Checked = False) And (chk_movPagoEntregar.Checked = False) Then

            chk_Movimentos.Checked = False

        ElseIf (chk_movPedido.Checked = True) OrElse (chk_movOrcamento.Checked = True) OrElse _
            (chk_movTransferencia.Checked = True) OrElse (chk_movNFe.Checked = True) OrElse _
            (chk_movRequisicao.Checked = True) OrElse (chk_movEmissPedido.Checked = True) OrElse _
            (chk_movGeraMapa.Checked = True) OrElse (chk_movPagoEntregar.Checked = True) Then

            If chk_Movimentos.Checked = False Then chk_Movimentos.Checked = True

        End If



    End Sub

    Private Sub chk_cpPreVenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cpPreVenda.Click, chk_cpVendaDireta.Click, chk_cpConfiguracao.Click, chk_cpPreVenda.KeyDown, chk_cpVendaDireta.KeyDown, chk_cpConfiguracao.KeyDown

        _formRequest._frmRef._clUsuarioTelas.pTl_cpprevenda = chk_cpPreVenda.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cpvendadireta = chk_cpVendaDireta.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cpconfiguracao = chk_cpConfiguracao.Checked

        If (chk_cpPreVenda.Checked = False) And (chk_cpVendaDireta.Checked = False) And _
           (chk_cpConfiguracao.Checked = False) Then

            chk_cupom.Checked = False

        ElseIf (chk_cpPreVenda.Checked = True) OrElse (chk_cpVendaDireta.Checked = True) OrElse _
            (chk_cpConfiguracao.Checked = True) Then

            If chk_cupom.Checked = False Then chk_cupom.Checked = True

        End If



    End Sub

    Private Sub chk_estPesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_estPesquisa.Click, chk_estRestaura.Click, chk_estImplantacao.Click, chk_estPedidoCompra.Click, chk_estcompras.Click, chk_estatualizacao.Click, chk_estRelatorios.Click, chk_estPesquisa.KeyDown, chk_estRestaura.KeyDown, chk_estImplantacao.KeyDown, chk_estPedidoCompra.KeyDown, chk_estcompras.KeyDown, chk_estatualizacao.KeyDown, chk_estRelatorios.KeyDown

        _formRequest._frmRef._clUsuarioTelas.pTl_estpesquisa = chk_estPesquisa.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estrestaura = chk_estRestaura.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estimplantacao = chk_estImplantacao.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estpedidocompras = chk_estPedidoCompra.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estcompras = chk_estcompras.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estatualizacao = chk_estatualizacao.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estrelatorios = chk_estRelatorios.Checked

        If (chk_estPesquisa.Checked = False) And (chk_estRestaura.Checked = False) And _
           (chk_estImplantacao.Checked = False) And (chk_estPedidoCompra.Checked = False) And _
           (chk_estcompras.Checked = False) And (chk_estatualizacao.Checked = False) And _
           (chk_estRelatorios.Checked = False) Then

            chk_estoque.Checked = False

        ElseIf (chk_estPesquisa.Checked = True) OrElse (chk_estRestaura.Checked = True) OrElse _
            (chk_estImplantacao.Checked = True) OrElse (chk_estPedidoCompra.Checked = True) OrElse _
            (chk_estcompras.Checked = True) OrElse (chk_estatualizacao.Checked = True) OrElse _
            (chk_estRelatorios.Checked = True) Then

            If chk_estoque.Checked = False Then chk_estoque.Checked = True

        End If



    End Sub

    Private Sub chk_finPagamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_finRecebimento.Click, chk_finPagamento.Click, chk_finFluxoCaixa.Click, chk_finDespesas.Click, chk_finChqPreDatado.Click, chk_finRecebimento.KeyDown, chk_finPagamento.KeyDown, chk_finFluxoCaixa.KeyDown, chk_finDespesas.KeyDown, chk_finChqPreDatado.KeyDown

        _formRequest._frmRef._clUsuarioTelas.pTl_finpagamentos = chk_finPagamento.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_finrecebimentos = chk_finRecebimento.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_finfluxocaixa = chk_finFluxoCaixa.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_findespesas = chk_finDespesas.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_finchqPreDatado = chk_finChqPreDatado.Checked

        If (chk_finPagamento.Checked = False) And (chk_finRecebimento.Checked = False) And _
           (chk_finFluxoCaixa.Checked = False) And (chk_finDespesas.Checked = False) And _
           (chk_finChqPreDatado.Checked = False) Then

            chk_financeiro.Checked = False

        ElseIf (chk_finPagamento.Checked = True) OrElse (chk_finRecebimento.Checked = True) OrElse _
            (chk_finFluxoCaixa.Checked = True) OrElse (chk_finDespesas.Checked = True) OrElse _
            (chk_finChqPreDatado.Checked = True) Then

            If chk_financeiro.Checked = False Then chk_financeiro.Checked = True

        End If



    End Sub

    Private Sub chk_manEmprestimos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_manTrocas.Click, chk_manPalmTop.Click, chk_manEmprestimos.Click, chk_manCidadesIBGE.Click, chk_manTrocas.KeyDown, chk_manPalmTop.KeyDown, chk_manEmprestimos.KeyDown, chk_manCidadesIBGE.KeyDown

        _formRequest._frmRef._clUsuarioTelas.pTl_manemprestimos = chk_manEmprestimos.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_mantrocas = chk_manTrocas.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_manpalmtop = chk_manPalmTop.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_mancidadesibge = chk_manCidadesIBGE.Checked

        If (chk_manEmprestimos.Checked = False) And (chk_manTrocas.Checked = False) And _
            (chk_manPalmTop.Checked = False) And (chk_manCidadesIBGE.Checked = False) Then

            chk_manutencao.Checked = False

        ElseIf (chk_manEmprestimos.Checked = True) OrElse (chk_manTrocas.Checked = True) OrElse _
            (chk_manPalmTop.Checked = True) OrElse (chk_manCidadesIBGE.Checked = True) Then

            If chk_manutencao.Checked = False Then chk_manutencao.Checked = True

        End If



    End Sub

    Private Sub chk_ctbArqDigital_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_ctbArqDigital.Click, chk_ctbLivrosFiscais.Click, chk_ctbContador.Click, chk_ctbCfop.Click, chk_ctbArqDigital.KeyDown, chk_ctbLivrosFiscais.KeyDown, chk_ctbContador.KeyDown, chk_ctbCfop.KeyDown

        _formRequest._frmRef._clUsuarioTelas.pTl_ctbarqdigitais = chk_ctbArqDigital.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_ctblivrosfiscais = chk_ctbLivrosFiscais.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_ctbcontador = chk_ctbContador.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_ctbcfop = chk_ctbCfop.Checked

        If (chk_ctbArqDigital.Checked = False) And (chk_ctbLivrosFiscais.Checked = False) And _
            (chk_ctbContador.Checked = False) And (chk_ctbCfop.Checked = False) Then

            chk_contabil.Checked = False

        ElseIf (chk_ctbArqDigital.Checked = True) OrElse (chk_ctbLivrosFiscais.Checked = True) OrElse _
            (chk_ctbContador.Checked = True) OrElse (chk_ctbCfop.Checked = True) Then

            If chk_contabil.Checked = False Then chk_contabil.Checked = True

        End If



    End Sub

    Private Sub chk_paraControle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_paraUltilitarios.Click, chk_paraControle.Click, chk_paraBackup.Click, chk_paraConfiguracao.Click, chk_paraUltilitarios.KeyDown, chk_paraControle.KeyDown, chk_paraBackup.KeyDown, chk_paraConfiguracao.KeyDown

        _formRequest._frmRef._clUsuarioTelas.pTl_paracontrole = chk_paraControle.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_paraultilitarios = chk_paraUltilitarios.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_parabackup = chk_paraBackup.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_paraconfiguracao = chk_paraConfiguracao.Checked

        If (chk_paraControle.Checked = False) And (chk_paraUltilitarios.Checked = False) And _
           (chk_paraBackup.Checked = False) And (chk_paraConfiguracao.Checked = False) Then

            chk_parametros.Checked = False

        ElseIf (chk_paraControle.Checked = True) OrElse (chk_paraUltilitarios.Checked = True) OrElse _
            (chk_paraBackup.Checked = True) OrElse (chk_paraConfiguracao.Checked = True) Then

            If chk_parametros.Checked = False Then chk_parametros.Checked = True

        End If



    End Sub

    Private Sub Frm_UsuariosAcessos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        configTelasUsuarioEditando()
        'If _formRequest._frmRef._alterando = True Then

        '    configTelasUsuarioEditando()

        'Else
        '    chk_cadastros.Checked = True : chk_Movimentos.Checked = True : chk_mapas.Checked = True
        '    chk_cupom.Checked = True : chk_estoque.Checked = True : chk_financeiro.Checked = True
        '    chk_manutencao.Checked = True : chk_manutencao.Checked = True : chk_contabil.Checked = True
        '    chk_parametros.Checked = True

        'End If



    End Sub

    Private Sub configTelasUsuarioEditando()

        ' Cadastros
        chk_cadastros.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_Cadastros
        chk_cadCliente.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadcliente
        chk_cadVendedor.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadvendedor
        chk_cadUsuario.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadusuario
        chk_cadTitular.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadtitular
        chk_cadCidade.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadcidade
        chk_cadComodato.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadcomodato
        chk_cadServico.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadservico
        chk_cadAutomovel.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadautomovel
        chk_cadGerais.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadgerais
        chk_cadGerente.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadgerente
        chk_cadGeno.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadgeno

        'Movimentos
        chk_Movimentos.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_movimentos
        chk_movPedido.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_movpedido
        chk_movOrcamento.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_movorcamento
        chk_movTransferencia.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_movtransferencia
        chk_movNFe.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_movnfe
        chk_movRequisicao.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_movrequisicao
        chk_movEmissPedido.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_movemisspedido
        chk_movGeraMapa.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_movgeramapa
        chk_cancelarExcluir.Checked = _formRequest._frmRef._clUsuarioTelas.pBtn_cancelarExcluir
        chk_carne.Checked = _formRequest._frmRef._clUsuarioTelas.pBtn_carne

        'Mapas
        chk_mapas.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_mapas
        chk_mpVenda.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_mpvenda
        chk_mpRetornoVenda.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_mpretornovenda

        'Cupom
        chk_cupom.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cupom
        chk_cpPreVenda.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cpprevenda
        chk_cpVendaDireta.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cpvendadireta
        chk_cpConfiguracao.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cpconfiguracao

        'Estoque
        chk_estoque.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_estoque
        chk_estPesquisa.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_estpesquisa
        chk_estRestaura.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_estrestaura
        chk_estImplantacao.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_estimplantacao
        chk_estPedidoCompra.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_estpedidocompras
        chk_estcompras.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_estcompras
        chk_estatualizacao.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_estatualizacao
        chk_estRelatorios.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_estrelatorios

        'Financeiro
        chk_financeiro.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_financeiro
        chk_finPagamento.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_finpagamentos
        chk_finRecebimento.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_finrecebimentos
        chk_finFluxoCaixa.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_finfluxocaixa
        chk_finDespesas.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_findespesas
        chk_finChqPreDatado.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_finchqPreDatado

        'Manutenção
        chk_manutencao.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_manutencao
        chk_manEmprestimos.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_manemprestimos
        chk_manTrocas.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_mantrocas
        chk_manPalmTop.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_manpalmtop
        chk_manCidadesIBGE.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_mancidadesibge

        'Contabil
        chk_contabil.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_contabil
        chk_ctbArqDigital.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_ctbarqdigitais
        chk_ctbLivrosFiscais.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_ctblivrosfiscais
        chk_ctbContador.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_ctbcontador
        chk_ctbCfop.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_ctbcfop

        'Parametros
        chk_parametros.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_parametros
        chk_paraControle.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_paracontrole
        chk_paraUltilitarios.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_paraultilitarios
        chk_paraBackup.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_parabackup
        chk_paraConfiguracao.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_paraconfiguracao



    End Sub

    Private Sub setTelasUsuario()

        ' Cadastros
        _formRequest._frmRef._clUsuarioTelas.pTl_Cadastros = chk_cadastros.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadcliente = chk_cadCliente.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadvendedor = chk_cadVendedor.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadusuario = chk_cadUsuario.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadtitular = chk_cadTitular.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadcidade = chk_cadCidade.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadcomodato = chk_cadComodato.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadservico = chk_cadServico.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadautomovel = chk_cadAutomovel.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadgerais = chk_cadGerais.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadgerente = chk_cadGerente.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadgeno = chk_cadGeno.Checked

        'Movimentos
        _formRequest._frmRef._clUsuarioTelas.pTl_movimentos = chk_Movimentos.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movpedido = chk_movPedido.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movorcamento = chk_movOrcamento.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movtransferencia = chk_movTransferencia.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movnfe = chk_movNFe.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movrequisicao = chk_movRequisicao.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movemisspedido = chk_movEmissPedido.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movgeramapa = chk_movGeraMapa.Checked
        _formRequest._frmRef._clUsuarioTelas.pBtn_cancelarExcluir = chk_cancelarExcluir.Checked

        'Mapas
        _formRequest._frmRef._clUsuarioTelas.pTl_mapas = chk_mapas.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_mpvenda = chk_mpVenda.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_mpretornovenda = chk_mpRetornoVenda.Checked

        'Cupom
        _formRequest._frmRef._clUsuarioTelas.pTl_cupom = chk_cupom.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cpprevenda = chk_cpPreVenda.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cpvendadireta = chk_cpVendaDireta.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cpconfiguracao = chk_cpConfiguracao.Checked

        'Estoque
        _formRequest._frmRef._clUsuarioTelas.pTl_estoque = chk_estoque.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estpesquisa = chk_estPesquisa.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estrestaura = chk_estRestaura.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estimplantacao = chk_estImplantacao.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estpedidocompras = chk_estPedidoCompra.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estcompras = chk_estcompras.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estatualizacao = chk_estatualizacao.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_estrelatorios = chk_estRelatorios.Checked

        'Financeiro
        _formRequest._frmRef._clUsuarioTelas.pTl_financeiro = chk_financeiro.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_finpagamentos = chk_finPagamento.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_finrecebimentos = chk_finRecebimento.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_finfluxocaixa = chk_finFluxoCaixa.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_findespesas = chk_finDespesas.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_finchqPreDatado = chk_finChqPreDatado.Checked

        'Manutenção
        _formRequest._frmRef._clUsuarioTelas.pTl_manutencao = chk_manutencao.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_manemprestimos = chk_manEmprestimos.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_mantrocas = chk_manTrocas.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_manpalmtop = chk_manPalmTop.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_mancidadesibge = chk_manCidadesIBGE.Checked

        'Contabil
        _formRequest._frmRef._clUsuarioTelas.pTl_contabil = chk_contabil.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_ctbarqdigitais = chk_ctbArqDigital.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_ctblivrosfiscais = chk_ctbLivrosFiscais.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_ctbcontador = chk_ctbContador.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_ctbcfop = chk_ctbCfop.Checked

        'Parametros
        _formRequest._frmRef._clUsuarioTelas.pTl_parametros = chk_parametros.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_paracontrole = chk_paraControle.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_paraultilitarios = chk_paraUltilitarios.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_parabackup = chk_paraBackup.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_paraconfiguracao = chk_paraConfiguracao.Checked



    End Sub

    Private Sub chk_mapas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_mapas.Click

        If chk_mapas.Checked = False Then

            If (chk_mpVenda.Checked = True) OrElse (chk_mpRetornoVenda.Checked = True) Then

                chk_mapas.Checked = True
            End If
        Else

            If (chk_mpVenda.Checked = False) And (chk_mpRetornoVenda.Checked = False) Then

                chk_mpVenda.Checked = True : chk_mpRetornoVenda.Checked = True
            End If

        End If
        _formRequest._frmRef._clUsuarioTelas.pTl_mapas = chk_mapas.Checked

    End Sub

    Private Sub chk_mpVenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_mpVenda.Click, chk_mpRetornoVenda.Click, chk_mpVenda.KeyDown, chk_mpRetornoVenda.KeyDown

        _formRequest._frmRef._clUsuarioTelas.pTl_mpvenda = chk_mpVenda.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_mpretornovenda = chk_mpRetornoVenda.Checked

        If (chk_mpVenda.Checked = False) And (chk_mpRetornoVenda.Checked = False) Then

            chk_mapas.Checked = False

        ElseIf (chk_mpVenda.Checked = True) OrElse (chk_mpRetornoVenda.Checked = True) Then

            If chk_mapas.Checked = False Then chk_mapas.Checked = True

        End If

    End Sub

    Private Sub Frm_UsuariosAcessos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        setTelasUsuario()
    End Sub

    Private Sub chk_cancelarExcluir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cancelarExcluir.CheckedChanged

        _formRequest._frmRef._clUsuarioTelas.pBtn_cancelarExcluir = chk_cancelarExcluir.Checked
    End Sub

    Private Sub chk_carne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_carne.CheckedChanged

        _formRequest._frmRef._clUsuarioTelas.pBtn_carne = chk_carne.Checked
    End Sub

    
End Class