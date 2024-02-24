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

            If (chk_cadCliente.Checked = True) OrElse (chk_cadUsuario.Checked = True) OrElse _
            (chk_cadCidade.Checked = True) OrElse (chk_cadServico.Checked = True) OrElse _
            (chk_cadGeno.Checked = True) Then

                chk_cadastros.Checked = True

            End If
        Else

            If (chk_cadCliente.Checked = False) And (chk_cadUsuario.Checked = False) And _
           (chk_cadCidade.Checked = False) And (chk_cadServico.Checked = False) And _
           (chk_cadGeno.Checked = False) Then

                'Marca todos do menu cadastro...
                chk_cadCliente.Checked = True
                chk_cadUsuario.Checked = True
                chk_cadCidade.Checked = True
                chk_cadServico.Checked = True
                chk_cadGeno.Checked = True


            End If
        End If
        _formRequest._frmRef._clUsuarioTelas.pTl_Cadastros = chk_cadastros.Checked



    End Sub

    Private Sub chk_Movimentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Movimentos.Click, chk_Movimentos.KeyDown

        If chk_Movimentos.Checked = False Then

            If (chk_movOrcamento.Checked = True) OrElse (chk_movAgendamentos.Checked = True) Then

                chk_Movimentos.Checked = True
            End If
        Else

            If (chk_movOrcamento.Checked = False) And (chk_movAgendamentos.Checked = False) Then

                chk_movOrcamento.Checked = True : chk_movAgendamentos.Checked = True

            End If

        End If
        _formRequest._frmRef._clUsuarioTelas.pTl_movimentos = chk_Movimentos.Checked



    End Sub

    Private Sub chk_financeiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_financeiro.Click, chk_financeiro.KeyDown

        If chk_financeiro.Checked = False Then

            If (chk_finPagamento.Checked = True) OrElse (chk_finRecebimento.Checked = True) OrElse _
            (chk_finFluxoCaixa.Checked = True) OrElse (chk_finDespesas.Checked = True) Then

                chk_financeiro.Checked = True

            End If
        Else

            If (chk_finPagamento.Checked = False) And (chk_finRecebimento.Checked = False) And _
            (chk_finFluxoCaixa.Checked = False) And (chk_finDespesas.Checked = False) Then

                chk_finPagamento.Checked = True : chk_finRecebimento.Checked = True
                chk_finFluxoCaixa.Checked = True : chk_finDespesas.Checked = True

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

    Private Sub chk_cadCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_cadUsuario.Click, chk_cadServico.Click, chk_cadGeno.Click, chk_cadCliente.Click, chk_cadCidade.Click, chk_cadUsuario.KeyDown, chk_cadServico.KeyDown, chk_cadGeno.KeyDown, chk_cadCliente.KeyDown, chk_cadCidade.KeyDown

        _formRequest._frmRef._clUsuarioTelas.pTl_cadcliente = chk_cadCliente.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadusuario = chk_cadUsuario.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadcidade = chk_cadCidade.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadservico = chk_cadServico.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadgeno = chk_cadGeno.Checked

        If (chk_cadCliente.Checked = False) And (chk_cadUsuario.Checked = False) And _
           (chk_cadCidade.Checked = False) And (chk_cadServico.Checked = False) And _
           (chk_cadGeno.Checked = False) Then

            chk_cadastros.Checked = False

        ElseIf (chk_cadCliente.Checked = True) OrElse (chk_cadUsuario.Checked = True) OrElse _
            (chk_cadCidade.Checked = True) OrElse (chk_cadServico.Checked = True) OrElse _
            (chk_cadGeno.Checked = True) Then

            If chk_cadastros.Checked = False Then chk_cadastros.Checked = True

        End If



    End Sub

    Private Sub chk_movPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_movOrcamento.Click, chk_movAgendamentos.Click

        _formRequest._frmRef._clUsuarioTelas.pTl_movorcamento = chk_movOrcamento.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movAgendamentos = chk_movAgendamentos.Checked


        If (chk_movOrcamento.Checked = False) And (chk_movAgendamentos.Checked = False) Then

            chk_Movimentos.Checked = False

        ElseIf (chk_movOrcamento.Checked = True) OrElse (chk_movAgendamentos.Checked = True) Then

            If chk_Movimentos.Checked = False Then chk_Movimentos.Checked = True

        End If



    End Sub

    Private Sub chk_finPagamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_finRecebimento.Click, chk_finPagamento.Click, chk_finFluxoCaixa.Click, chk_finDespesas.Click, chk_finRecebimento.KeyDown, chk_finPagamento.KeyDown, chk_finFluxoCaixa.KeyDown, chk_finDespesas.KeyDown

        _formRequest._frmRef._clUsuarioTelas.pTl_finpagamentos = chk_finPagamento.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_finrecebimentos = chk_finRecebimento.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_finfluxocaixa = chk_finFluxoCaixa.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_findespesas = chk_finDespesas.Checked

        If (chk_finPagamento.Checked = False) And (chk_finRecebimento.Checked = False) And _
           (chk_finFluxoCaixa.Checked = False) And (chk_finDespesas.Checked = False) Then

            chk_financeiro.Checked = False

        ElseIf (chk_finPagamento.Checked = True) OrElse (chk_finRecebimento.Checked = True) OrElse _
            (chk_finFluxoCaixa.Checked = True) OrElse (chk_finDespesas.Checked = True) Then

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

    End Sub

    Private Sub configTelasUsuarioEditando()

        ' Cadastros
        chk_cadastros.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_Cadastros
        chk_cadCliente.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadcliente
        chk_cadUsuario.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadusuario
        chk_cadCidade.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadcidade
        chk_cadServico.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadservico
        chk_cadGeno.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_cadgeno

        'Movimentos
        chk_Movimentos.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_movimentos
        chk_movOrcamento.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_movorcamento
        chk_movAgendamentos.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_movAgendamentos

        'Financeiro
        chk_financeiro.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_financeiro
        chk_finPagamento.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_finpagamentos
        chk_finRecebimento.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_finrecebimentos
        chk_finFluxoCaixa.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_finfluxocaixa
        chk_finDespesas.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_findespesas

        'Manutenção
        chk_manutencao.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_manutencao
        chk_manEmprestimos.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_manemprestimos
        chk_manTrocas.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_mantrocas
        chk_manPalmTop.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_manpalmtop
        chk_manCidadesIBGE.Checked = _formRequest._frmRef._clUsuarioTelas.pTl_mancidadesibge

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
        _formRequest._frmRef._clUsuarioTelas.pTl_cadusuario = chk_cadUsuario.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadcidade = chk_cadCidade.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadservico = chk_cadServico.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_cadgeno = chk_cadGeno.Checked

        'Movimentos
        _formRequest._frmRef._clUsuarioTelas.pTl_movimentos = chk_Movimentos.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movorcamento = chk_movOrcamento.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_movAgendamentos = chk_movAgendamentos.Checked

        'Financeiro
        _formRequest._frmRef._clUsuarioTelas.pTl_financeiro = chk_financeiro.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_finpagamentos = chk_finPagamento.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_finrecebimentos = chk_finRecebimento.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_finfluxocaixa = chk_finFluxoCaixa.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_findespesas = chk_finDespesas.Checked

        'Manutenção
        _formRequest._frmRef._clUsuarioTelas.pTl_manutencao = chk_manutencao.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_manemprestimos = chk_manEmprestimos.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_mantrocas = chk_manTrocas.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_manpalmtop = chk_manPalmTop.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_mancidadesibge = chk_manCidadesIBGE.Checked

        'Parametros
        _formRequest._frmRef._clUsuarioTelas.pTl_parametros = chk_parametros.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_paracontrole = chk_paraControle.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_paraultilitarios = chk_paraUltilitarios.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_parabackup = chk_paraBackup.Checked
        _formRequest._frmRef._clUsuarioTelas.pTl_paraconfiguracao = chk_paraConfiguracao.Checked



    End Sub


    Private Sub Frm_UsuariosAcessos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        setTelasUsuario()
    End Sub

End Class