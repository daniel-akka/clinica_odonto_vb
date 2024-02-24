Imports Npgsql
Imports System.Text
Imports System.Data
Imports System.DateTime
Imports System.Math

Public Class Frm_ManProdutos

    Private linhaAtual As Integer = -1
    Private mcell As String
    Dim configPisCofinsPadrao As Boolean = False

    Private Const _valorZERO As Integer = 0
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Dim _Produto As New Cl_Est0001
    Dim objImagem As New Cl_ImagemProdutos
    Private _tip As ToolTip = Nothing
    Dim _msgErroCelula As String = ""
    Dim _indexCelulaErro As Integer = 0
    Dim _indexLinhaErro As Integer = 0
    Dim _ncmProduto As String = ""
    Private _local As String = Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2)
    Private _alterando As Boolean = False, _incluindo As Boolean = False

    Public Shared _frmRef As New Frm_ManProdutos
    Dim _BuscaForn As New Frm_BuscaForn

    'ultilizados para o DataGridView
    Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Dim CmdProduto As New NpgsqlCommand
    Dim SqlProduto As New StringBuilder
    Dim drProduto As NpgsqlDataReader


    Private Sub Frm_ProdutosGerais_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown


        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                executeF5()
            Case Keys.F2
                executeF2()
            Case Keys.F3
                executeF3()
        End Select

    End Sub

    Private Sub executeF5()

        preencheDtg_Produto()
    End Sub

    Private Sub executeF2()

        'Preenche o combo box do grupo e unidades...
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        If cbo_grupo.Items.Count <= _valorZERO Then
            preencheCbo_Grupo(conection)
            preencheCbo_Unidades(conection)
        End If


        If conection.State = ConnectionState.Closed Then conection.Open()

        If Not txt_codigo.Text.Equals("") Then 'Se tiver operação executando, então...
            If MessageBox.Show("Operação em aberto! Ela será Substituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                _incluindo = True
                _alterando = False
                tbc_produtos.SelectTab(1)
                limpaCamposProd()
                zeraValoresProdutoPrincipal()
                zeraValoresProdutoInfo()
                zeraValoresProdutoPis()
                apagaImagem()
                _Produto.zeraValores()
                objImagem.zeraValores()
                'txt_codigo.Text = String.Format("{0:D5}", _clBD.trazProxCodProd(conection))
                txt_codigo.Focus()
                tbp_cadPrincipal.Text = "Cadastro"
                Btn_salvar.Enabled = True
            End If

        Else

            _incluindo = True
            _alterando = False
            tbc_produtos.SelectTab(1)
            limpaCamposProd()
            zeraValoresProdutoPrincipal()
            zeraValoresProdutoInfo()
            zeraValoresProdutoPis()
            apagaImagem()
            _Produto.zeraValores()
            objImagem.zeraValores()
            'txt_codigo.Text = String.Format("{0:D5}", _clBD.trazProxCodProd(conection))
            txt_codigo.Focus()
            tbp_cadPrincipal.Text = "Cadastro"
            Btn_salvar.Enabled = True
        End If
        conection = Nothing

    End Sub

    Private Sub executeF3()


        'Preenche o combo box do grupo e unidades...
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        If cbo_grupo.Items.Count <= _valorZERO Then
            preencheCbo_Grupo(conection)
            preencheCbo_Unidades(conection)
        End If

        If conection.State = ConnectionState.Closed Then conection.Open()

        If Not txt_codigo.Text.Equals("") Then 'Se tiver operação executando, então...
            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                _alterando = True
                _incluindo = False
                tbc_produtos.SelectTab(1)
                limpaCamposProd()
                leituraCamposValores()
                zeraValoresProdutoPrincipal()
                zeraValoresProdutoInfo()
                zeraValoresProdutoPis()
                apagaImagem()
                _Produto.zeraValores()
                objImagem.zeraValores()
                trazProdutoSelecionado()
                trazImagemProduto()
                txt_codigo.Focus()
                tbc_produtos.Text = "Alterando"
                Btn_salvar.Enabled = True
            Else
                txt_codigo.Focus()
                'tbc_produtos.Text = "Alterando"
                Btn_salvar.Enabled = True
            End If

        Else

            _alterando = True
            _incluindo = False
            tbc_produtos.SelectTab(1)
            limpaCamposProd()
            leituraCamposValores()
            zeraValoresProdutoPrincipal()
            zeraValoresProdutoInfo()
            zeraValoresProdutoPis()
            apagaImagem()
            _Produto.zeraValores()
            objImagem.zeraValores()
            trazProdutoSelecionado()
            trazImagemProduto()
            txt_codigo.Focus()
            tbc_produtos.Text = "Alterando"
            Btn_salvar.Enabled = True

        End If
        conection = Nothing


    End Sub

    Private Sub salvaImagemIncluindo(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        objImagem.pId = Convert.ToInt64(_clBD.trazProxIdImagemProd(conection))
        objImagem.pNome = System.IO.Path.GetFileName(lbl_caminhoImagem.Text)
        objImagem.pImagem = lbl_caminhoImagem.Text

        _clBD.incImagemProduto(objImagem, conection, transacao)

    End Sub

    Private Sub salvaProdutoIncluindo(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        _Produto.pCodig = txt_codigo.Text
        _Produto.pCdbarra = txt_codbarras.Text
        _Produto.pNcm = txt_ncm.Text
        _Produto.pProdut = txt_descricao.Text
        _Produto.pProdut2 = txt_descrNfeP2.Text
        _Produto.pProdut3 = txt_descrAutomovelP3.Text
        _Produto.pCdport = txt_codPart.Text
        _Produto.pUnd = Trim(Mid(cbo_und.Text, 1, 4))
        _Produto.pEmbalag = txt_embalagem.Text
        _Produto.pClf = txt_clfiscal.Text
        _Produto.pCst = Trim(Mid(cbo_CST.SelectedItem, 1, 2))
        _Produto.pCfv = Trim(cbo_CFV.SelectedItem)
        _Produto.pCstIpi = Trim(Mid(cbo_cstIpi.SelectedItem.ToString, 1, 2))
        _Produto.pPcomp = Format(CDbl(txt_pcompra.Text), "###,##0.00")
        _Produto.pPcusto = Format(CDbl(txt_pcusto.Text), "###,##0.00")
        _Produto.pLinha = txt_linha.Text
        _Produto.pGrupo = Trim(Mid(cbo_grupo.SelectedItem, 1, 2))
        _Produto.pBalanca = txt_balanca.Text
        _Produto.pProm = txt_promocao.Text
        _Produto.pVprom = Format(CDbl(txt_vlpromocao.Text), "###,##0.00")
        _Produto.pReduz = Format(CDbl(txt_reducao.Text), "###,##0.00")
        _Produto.pPauta = Format(CDbl(txt_pauta.Text), "###,##0.00")
        _Produto.pPvenda = Format(CDbl(txt_pvenda.Text), "###,##0.00")
        _Produto.pQtdfisc = Format(CDbl(txt_sldfiscal.Text), "###,##0.00")
        _Produto.pQtde = Format(CDbl(txt_saldo.Text), "###,##0.00")
        _Produto.pQtdxUnd = Format(CDbl(txt_QTDxUND.Text), "###,##0.00")
        _Produto.pPesobruto = Format(CDbl(txt_pesoBruto.Text), "###,##0.00")
        _Produto.pPesoliq = Format(CDbl(txt_pesoLiquido.Text), "###,##0.00")
        _Produto.pCom1 = Format(CDbl(txt_com1.Text), "###,##0.00")
        _Produto.pEstmin = Format(CDbl(txt_minimo.Text), "###,##0.00")
        _Produto.pGrade = Me.txt_grade.Text


        Try
            _Produto.pDtcomp = Format(CDate(Me.Msk_dtcomp.Text), "dd/MM/yyyy")
        Catch ex As Exception
            _Produto.pDtcomp = Nothing
        End Try

        Try
            _Produto.pDtvend = Format(CDate(Me.msk_dtvenda.Text), "dd/MM/yyyy")
        Catch ex As Exception
            _Produto.pDtvend = Nothing
        End Try

        Try
            _Produto.pValid = Format(CDate(Me.msk_dtValid.Text), "dd/MM/yyyy")
        Catch ex As Exception
            _Produto.pValid = Nothing
        End Try
        _Produto.pIpi = Format(CDbl(txt_ipi.Text), "###,##0.00")

        _Produto.pClasse = txt_classe.Text
        Try
            _Produto.pOrigem = Trim(Mid(cbo_origem.SelectedItem, 1, 1))
        Catch ex As Exception
        End Try

        _Produto.pPcstent = Trim(Mid(cbo_pisEntrada.SelectedItem.ToString, 1, 2))
        _Produto.pPcstsai = Trim(Mid(cbo_pisSaida.SelectedItem.ToString, 1, 2))
        _Produto.pCcstent = Trim(Mid(cbo_cofinsEntrada.SelectedItem.ToString, 1, 2))
        _Produto.pCcstsai = Trim(Mid(cbo_cofinsSaida.SelectedItem.ToString, 1, 2))



        'PROMOÇÃO...
        Try
            _Produto.pDtinicialpromocao = CDate(msk_dtPromInicio.Text)
        Catch ex As Exception
            _Produto.pDtinicialpromocao = Nothing
        End Try
        Try
            _Produto.pDtfinalpromocao = CDate(msk_dtPromFim.Text)
        Catch ex As Exception
            _Produto.pDtfinalpromocao = Nothing
        End Try
        Try
            _Produto.pQuotaPromocao = CInt(txt_VlrQuota.Text)
        Catch ex As Exception
        End Try
        _Produto.pConsumo = chk_consumo.Checked
        _Produto.pImobilizado = chk_imobilizado.Checked
        _Produto.pServico = chk_servico.Checked
        _Produto.pInativo = chk_inativo.Checked
        _Produto.pMateriaprima = chk_matePrima.Checked
        Try
            _Produto.pTipo = Trim(Mid(cbo_tipo.SelectedItem, 1, 2))
        Catch ex As Exception
        End Try

        'BONIFICAÇÃO...
        Try
            _Produto.pDtinicialbonific = CDate(msk_dtBonifInicio.Text)
        Catch ex As Exception
            _Produto.pDtinicialbonific = Nothing
        End Try
        Try
            _Produto.pDtfinalbonific = CDate(msk_dtBonifFin.Text)
        Catch ex As Exception
            _Produto.pDtfinalbonific = Nothing
        End Try
        _Produto.pBonif = 0
        Try
            _Produto.pQtdebonifcliente = CInt(txt_qtdeBonificCliente.Text)
        Catch ex As Exception
        End Try
        _Produto.pBonificquantidade = rdb_bonifQuant.Checked
        _Produto.pBonificvalor = rdb_bonifVlr.Checked
        If _Produto.pBonificquantidade Then _Produto.pBonif = CDbl(txt_bonifQuant.Text)
        If _Produto.pBonificvalor Then _Produto.pBonif = CDbl(txt_bonifVlr.Text)

        _Produto.pIdImagem = objImagem.pId


        _clBD.incProduto(_Produto, conection, transacao)

        'Inclue em todas as lojas do Vinculo...
        _clBD.incTodasEstloja(MdlEmpresaUsu._vinculo, _local, _Produto.pCodig, _Produto.pCdport, _Produto.pQtde, _Produto.pPcusto, _Produto.pPvenda, _
                       _Produto.pVprom, _Produto.pQtdfisc, _Produto.pInventa, _Produto.pPcustom, _Produto.pPcustoa, _Produto.pPcomp, _Produto.pDtcomp, _Produto.pDtvend, _Produto.pPvend15, _
                       _Produto.pPvend30, _Produto.pPcustoa, _Produto.pValid, conection, transacao)

        _clBD.updateCodprodVinculo(conection, CInt(_Produto.pCodig))

    End Sub

    Private Sub salvaProdutoAlterando(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        _Produto.pCodig = txt_codigo.Text
        _Produto.pCdbarra = txt_codbarras.Text
        _Produto.pNcm = txt_ncm.Text
        _Produto.pProdut = txt_descricao.Text
        _Produto.pProdut2 = txt_descrNfeP2.Text
        _Produto.pProdut3 = txt_descrAutomovelP3.Text
        _Produto.pCdport = txt_codPart.Text
        _Produto.pUnd = Trim(Mid(cbo_und.Text, 1, 4))
        _Produto.pEmbalag = txt_embalagem.Text
        _Produto.pClf = txt_clfiscal.Text
        _Produto.pCst = Trim(Mid(cbo_CST.SelectedItem, 1, 2))
        _Produto.pCfv = Trim(cbo_CFV.SelectedItem)
        _Produto.pCstIpi = Trim(Mid(cbo_cstIpi.SelectedItem.ToString, 1, 2))
        _Produto.pPcomp = Format(CDbl(txt_pcompra.Text), "###,##0.00")
        _Produto.pPcusto = Format(CDbl(txt_pcusto.Text), "###,##0.00")
        _Produto.pLinha = txt_linha.Text
        _Produto.pGrupo = Trim(Mid(cbo_grupo.SelectedItem, 1, 2))
        _Produto.pBalanca = txt_balanca.Text
        _Produto.pProm = txt_promocao.Text
        _Produto.pVprom = Format(CDbl(txt_vlpromocao.Text), "###,##0.00")
        _Produto.pReduz = Format(CDbl(txt_reducao.Text), "###,##0.00")
        _Produto.pPauta = Format(CDbl(txt_pauta.Text), "###,##0.00")
        _Produto.pPvenda = Format(CDbl(txt_pvenda.Text), "###,##0.00")
        _Produto.pQtdfisc = Format(CDbl(txt_sldfiscal.Text), "###,##0.00")
        _Produto.pQtde = Format(CDbl(txt_saldo.Text), "###,##0.00")
        _Produto.pQtdxUnd = Format(CDbl(txt_QTDxUND.Text), "###,##0.00")
        _Produto.pPesobruto = Format(CDbl(txt_pesoBruto.Text), "###,##0.00")
        _Produto.pPesoliq = Format(CDbl(txt_pesoLiquido.Text), "###,##0.00")
        _Produto.pCom1 = Format(CDbl(txt_com1.Text), "###,##0.00")
        _Produto.pEstmin = Format(CDbl(txt_minimo.Text), "###,##0.00")
        _Produto.pGrade = Me.txt_grade.Text
        Try
            _Produto.pOrigem = Trim(Mid(cbo_origem.SelectedItem, 1, 1))
        Catch ex As Exception
        End Try


        Try
            _Produto.pDtcomp = Format(CDate(Me.Msk_dtcomp.Text), "dd/MM/yyyy")
        Catch ex As Exception
            _Produto.pDtcomp = Nothing
        End Try

        Try
            _Produto.pDtvend = Format(CDate(Me.msk_dtvenda.Text), "dd/MM/yyyy")
        Catch ex As Exception
            _Produto.pDtvend = Nothing
        End Try

        Try
            _Produto.pValid = Format(CDate(Me.msk_dtValid.Text), "dd/MM/yyyy")
        Catch ex As Exception
            _Produto.pValid = Nothing
        End Try
        _Produto.pIpi = Format(CDbl(txt_ipi.Text), "###,##0.00")

        _Produto.pClasse = txt_classe.Text
        Try
            _Produto.pOrigem = Trim(Mid(cbo_origem.SelectedItem, 1, 1))
        Catch ex As Exception
        End Try
        _Produto.pPcstent = Trim(Mid(cbo_pisEntrada.SelectedItem.ToString, 1, 2))
        _Produto.pPcstsai = Trim(Mid(cbo_pisSaida.SelectedItem.ToString, 1, 2))
        _Produto.pCcstent = Trim(Mid(cbo_cofinsEntrada.SelectedItem.ToString, 1, 2))
        _Produto.pCcstsai = Trim(Mid(cbo_cofinsSaida.SelectedItem.ToString, 1, 2))



        'PROMOÇÃO...
        Try
            _Produto.pDtinicialpromocao = CDate(msk_dtPromInicio.Text)
        Catch ex As Exception
            _Produto.pDtinicialpromocao = Nothing
        End Try
        Try
            _Produto.pDtfinalpromocao = CDate(msk_dtPromFim.Text)
        Catch ex As Exception
            _Produto.pDtfinalpromocao = Nothing
        End Try
        Try
            _Produto.pQuotaPromocao = txt_VlrQuota.Text
        Catch ex As Exception
        End Try
        _Produto.pConsumo = chk_consumo.Checked
        _Produto.pImobilizado = chk_imobilizado.Checked
        _Produto.pServico = chk_servico.Checked
        _Produto.pInativo = chk_inativo.Checked
        _Produto.pMateriaprima = chk_matePrima.Checked
        Try
            _Produto.pTipo = Trim(Mid(cbo_tipo.SelectedItem, 1, 2))
        Catch ex As Exception
        End Try

        'BONIFICAÇÃO...
        Try
            _Produto.pDtinicialbonific = CDate(msk_dtBonifInicio.Text)
        Catch ex As Exception
            _Produto.pDtinicialbonific = Nothing
        End Try
        Try
            _Produto.pDtfinalbonific = CDate(msk_dtBonifFin.Text)
        Catch ex As Exception
            _Produto.pDtfinalbonific = Nothing
        End Try
        _Produto.pBonif = 0
        Try
            _Produto.pQtdebonifcliente = CInt(txt_qtdeBonificCliente.Text)
        Catch ex As Exception
        End Try
        _Produto.pBonificquantidade = rdb_bonifQuant.Checked
        _Produto.pBonificvalor = rdb_bonifVlr.Checked
        If _Produto.pBonificquantidade Then _Produto.pBonif = CDbl(txt_bonifQuant.Text)
        If _Produto.pBonificvalor Then _Produto.pBonif = CDbl(txt_bonifVlr.Text)

        _Produto.pIdImagem = objImagem.pId

        _clBD.altProduto(_Produto, conection, transacao)

        '_clBD.altEstloja(_local, mcodig, mcdport, mqtde, mpcusto, mpvenda, mvprom, mqtdfisc, _
        '                 minventa, mpcustom, mpcustoa, mpcomp, mdtcomp, mdtvend, mpvend15, mpvend30, _
        '                 mpcustoa, conection, transacao)

    End Sub

    Private Sub salvaImagemAlterando(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        objImagem.pNome = System.IO.Path.GetFileName(lbl_caminhoImagem.Text)
        objImagem.pImagem = lbl_caminhoImagem.Text

        _clBD.altImagemProduto(objImagem, conection, transacao)

    End Sub

    Private Sub btn_salvar_Click_Incluindo()

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction

        Try
            conection.Open()
            transacao = conection.BeginTransaction

            If Trim(lbl_caminhoImagem.Text).Equals("") = False Then
                salvaImagemIncluindo(conection, transacao)
            End If

            salvaProdutoIncluindo(conection, transacao)

            transacao.Commit() : conection.ClearPool()

            If MessageBox.Show("Produto salvo com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False
                Btn_salvar.Enabled = True
                zeraValoresProdutoPrincipal()
                zeraValoresProdutoInfo()
                zeraValoresProdutoPis()
                txt_codigo.Text = String.Format("{0:D5}", _clBD.trazProxCodProd(conection))
                txt_codigo.Focus()
                tbc_produtos.SelectTab(1)

            Else

                _incluindo = False : _alterando = False
                Btn_salvar.Enabled = False
                tbc_produtos.SelectTab(0)

                zeraValoresProdutoPrincipal()
                zeraValoresProdutoInfo()
                zeraValoresProdutoPis()

                preencheDtg_Produto()
                txt_pesquisa.Focus()

            End If

        Catch ex As Exception

            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()
            Catch ex1 As Exception
            End Try

        Finally

            If conection.State = ConnectionState.Open Then conection.Close()
            transacao = Nothing : conection = Nothing
        End Try

    End Sub

    Private Sub btn_salvar_Click_Alterando()

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Try

            conection.Open()
            transacao = conection.BeginTransaction

            If Trim(lbl_caminhoImagem.Text).Equals("") = False Then

                If objImagem.pId > 0 Then
                    salvaImagemAlterando(conection, transacao)
                Else
                    salvaImagemIncluindo(conection, transacao)
                End If
            End If

            salvaProdutoAlterando(conection, transacao)

            transacao.Commit() : conection.ClearPool()

            MsgBox("Produto salvo com sucesso", MsgBoxStyle.Exclamation)

            _incluindo = False : _alterando = False
            Btn_salvar.Enabled = False
            tbc_produtos.SelectTab(0)

            limpaLeituraCamposValores()
            zeraValoresProdutoPrincipal()
            zeraValoresProdutoInfo()
            zeraValoresProdutoPis()

            preencheDtg_Produto()
            txt_pesquisa.Focus()

            apagaImagem()
        Catch ex As Exception

            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()
            Catch ex1 As Exception
            End Try

        Finally

            If conection.State = ConnectionState.Open Then conection.Close()
            transacao = Nothing : conection = Nothing
        End Try

    End Sub

    Private Sub Btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_salvar.Click

        salvandoProduto()

    End Sub

    Private Sub salvandoProduto()

        If _incluindo Then

            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            If conection.State = ConnectionState.Closed Then conection.Open()
            txt_codigo.Text = String.Format("{0:D5}", _clBD.trazProxCodProd(conection))

            conection.ClearPool() : conection.Close() : conection = Nothing
        End If

        If verifCamposProduto() = True Then

            If _incluindo = True Then
                btn_salvar_Click_Incluindo()
            ElseIf _alterando = True Then
                btn_salvar_Click_Alterando()
            End If
        End If

    End Sub

    Private Function verifCamposProduto() As Boolean

        Dim mCamposOK As Boolean = True

        If Trim(txt_codigo.Text).Equals("") Then

            lbl_mensagem01.Text = "Codigo do Produto em Branco !"
            lbl_mensagem02.Text = "Codigo do Produto em Branco !"
            mCamposOK = False
            Return mCamposOK
        End If

        If Trim(txt_descricao.Text).Equals("") Then

            lbl_mensagem01.Text = "Descricao do Produto em Branco !"
            lbl_mensagem02.Text = "Descricao do Produto em Branco !"
            mCamposOK = False
            Return mCamposOK
        End If

        If Trim(txt_codPart.Text).Equals("") Then

            lbl_mensagem01.Text = "Codigo do Fornecedor em Branco !"
            lbl_mensagem02.Text = "Codigo do Fornecedor em Branco !"
            mCamposOK = False
            Return mCamposOK
        End If

        If Not IsNumeric(txt_pcompra.Text) Then

            lbl_mensagem01.Text = "Preço de Compra não é número !"
            lbl_mensagem02.Text = "Preço de Compra não é número !"
            mCamposOK = False
            Return mCamposOK
        ElseIf CDbl(txt_pcompra.Text) < _valorZERO Then

            lbl_mensagem01.Text = "Preço de Compra deve ser maior ou igual a ZERO !"
            lbl_mensagem02.Text = "Preço de Compra deve ser maior ou igual a ZERO !"
            mCamposOK = False
            Return mCamposOK
        End If

        If Not IsNumeric(txt_sldfiscal.Text) Then

            lbl_mensagem01.Text = "Quantidade Fiscal não é número !"
            lbl_mensagem02.Text = "Quantidade Fiscal não é número !"
            mCamposOK = False
            Return mCamposOK
        ElseIf CDbl(txt_sldfiscal.Text) < _valorZERO Then

            lbl_mensagem01.Text = "Quantidade Fiscal deve ser maior ou igual a ZERO !"
            lbl_mensagem02.Text = "Quantidade Fiscal deve ser maior ou igual a ZERO !"
            mCamposOK = False
            Return mCamposOK
        End If

        If cbo_grupo.SelectedIndex < _valorZERO Then

            lbl_mensagem01.Text = "Grupo do Produto não informado !"
            lbl_mensagem02.Text = "Grupo do Produto não informado !"
            mCamposOK = False
            Return mCamposOK
        End If

        If cbo_und.SelectedIndex < _valorZERO Then

            lbl_mensagem01.Text = "Unidade de medida não informada !"
            lbl_mensagem02.Text = "Unidade de medida não informada !"
            mCamposOK = False
            Return mCamposOK
        End If

        If cbo_tipo.SelectedIndex < _valorZERO Then

            lbl_mensagem01.Text = "Aliquota do Produto não informado !"
            lbl_mensagem02.Text = "Aliquota do Produto não informado !"
            mCamposOK = False
            Return mCamposOK
        End If

        'If (cbo_cstIpi.SelectedIndex > 0) And (CDbl(txt_ipi.Text) <= 0) Then

        '    lbl_mensagem01.Text = "Valor do IPI deve ser Maior que 0,00 !"
        '    lbl_mensagem02.Text = "Valor do IPI deve ser Maior que 0,00 !"
        '    mCamposOK = False
        '    Return mCamposOK

        'End If

        If Not Trim(_clFuncoes.RemoverCaracter(msk_dtValid.Text)).Equals("") Then
            If Not IsDate(msk_dtValid.Text) Then

                lbl_mensagem01.Text = "DATA inválida no campo da Data de Validade !"
                lbl_mensagem02.Text = "DATA inválida no campo da Data de Validade !"
                mCamposOK = False
                Return mCamposOK

            End If

        End If


        'CST Produto...
        If cbo_CST.SelectedIndex = 2 Then 'Se o CST for 20, então a taxa de redução deve ser maior que ZERO

            If CDbl(Me.txt_reducao.Text) <= _valorZERO Then

                lbl_mensagem01.Text = "Taxa de Redução deve ser Maior do ZERO para ""CST 20"" !"
                lbl_mensagem02.Text = "Taxa de Redução deve ser Maior do ZERO para ""CST 20"" !"
                mCamposOK = False
                Return mCamposOK

            End If
        End If

        If cbo_origem.SelectedIndex < 0 Then
            lbl_mensagem01.Text = "Informe a Origem do Produto !"
            lbl_mensagem02.Text = "Informe a Origem do Produto "
            mCamposOK = False
            Return mCamposOK
        End If

        If cbo_pisEntrada.SelectedIndex < 0 Then
            lbl_mensagem01.Text = "Informe o Pis de Entrada !"
            lbl_mensagem02.Text = "Informe o Pis de Entrada !"
            cbo_pisEntrada.Focus()
            mCamposOK = False
            Return mCamposOK
        End If

        If cbo_cofinsEntrada.SelectedIndex < 0 Then
            lbl_mensagem01.Text = "Informe o Cofins de Entrada !"
            lbl_mensagem02.Text = "Informe o Cofins de Entrada !"
            cbo_cofinsEntrada.Focus()
            mCamposOK = False
            Return mCamposOK
        End If

        If cbo_pisSaida.SelectedIndex < 0 Then
            lbl_mensagem01.Text = "Informe o Pis de Saída !"
            lbl_mensagem02.Text = "Informe o Pis de Saída !"
            cbo_pisSaida.Focus()
            mCamposOK = False
            Return mCamposOK
        End If

        If cbo_cofinsSaida.SelectedIndex < 0 Then
            lbl_mensagem01.Text = "Informe o Cofins de Saída !"
            lbl_mensagem02.Text = "Informe o Cofins de Saída !"
            cbo_cofinsSaida.Focus()
            mCamposOK = False
            Return mCamposOK
        End If


        Return mCamposOK
    End Function

    Private Sub Frm_ProdutosGerais_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btn_GravaPis.Enabled = False

        Try
            'Aqui é no caso de a pessoa estar na tela de Entradas XML e não tem o Ítem cadastrado...
            If Not Frm_MenuCompras._frmREf.txt_xmcodigoForn.Text.Equals("") Then
                txt_codbarras.Text = Frm_MenuCompras._frmREf.txt_xmcodbarraForn.Text
                txt_ncm.Text = Frm_MenuCompras._frmREf.txt_xmncmForn.Text
                txt_descricao.Text = Frm_MenuCompras._frmREf.txt_xmprodutoforn.Text
                txt_codPart.Text = Frm_MenuCompras._frmREf._codFornXML
                txt_nomePart.Text = Frm_MenuCompras._frmREf.txt_xmfornecedor.Text
                txt_ncmpis.Text = Frm_MenuCompras._frmREf.txt_xmncmForn.Text
                btn_consultaPis.Focus() : tbc_produtos.Focus()

            ElseIf Not Frm_MenuCompras._frmREf.txt_nfnumero.Text.Equals("") Then
            End If

            'Preenche o combo box do grupo e unidades...
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            preencheCbo_Grupo(conection)
            preencheCbo_Unidades(conection)
            Me.cbo_tipo = _clFuncoes.PreenchComboAliqProd(Me.cbo_tipo, MdlConexaoBD.conectionPadrao)
            conection = Nothing

            Me.dtg_produto.Rows.Clear()
            Me.dtg_produto.Refresh()
            preencheDtg_Produto()
            Me.txt_pesquisa.Focus()

            zeraValoresProdutoPrincipal()
            zeraValoresProdutoInfo()
            zeraValoresProdutoPis()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub zeraValoresProdutoPrincipal()
        Me.txt_codigo.Text = ""
        Me.txt_codbarras.Text = ""
        Me.txt_ncm.Text = ""
        Me.txt_descricao.Text = ""
        Me.txt_descrAutomovelP3.Text = ""
        Me.txt_descrNfeP2.Text = ""
        Me.txt_codPart.Text = ""
        Me.txt_nomePart.Text = ""
        Me.cbo_und.SelectedIndex = -1
        Me.txt_embalagem.Text = ""
        Me.txt_clfiscal.Text = "00"
        Me.cbo_CST.SelectedIndex = -1
        Me.cbo_CFV.SelectedIndex = -1
        Me.txt_pcompra.Text = "0,00"
        Me.txt_pcusto.Text = "0,00"
        Me.txt_linha.Text = "0"
        Me.cbo_grupo.SelectedIndex = -1
        Me.cbo_tipo.SelectedIndex = -1
        Me.txt_balanca.Text = "N"
        Me.txt_promocao.Text = "N"
        Me.txt_vlpromocao.Text = "0,00"
        Me.txt_reducao.Text = "0"
        Me.txt_pauta.Text = "0"
        Me.txt_pvenda.Text = "0,00"
        Me.txt_sldfiscal.Text = "0"
        Me.txt_saldo.Text = "0"
        Me.txt_QTDxUND.Text = "0"
        Me.Msk_dtcomp.Text = ""
        Me.msk_dtvenda.Text = ""
        Me.txt_ipi.Text = "0"
        Me.txt_classe.Text = ""
        Me.txt_pesoBruto.Text = "0,000"
        Me.txt_pesoLiquido.Text = "0,000"
        Me.txt_com1.Text = "0,00"
        Me.txt_minimo.Text = "0,00"
        msk_dtValid.Text = ""
        lbl_mensagem01.Text = ""
        Me.txt_grade.Text = "N"
        Me.cbo_origem.SelectedIndex = 0
        Me.cbo_cofinsSaida.SelectedIndex = 0
        Me.cbo_cofinsEntrada.SelectedIndex = 0
        Me.cbo_cstIpi.SelectedIndex = 0
        Me.cbo_pisEntrada.SelectedIndex = 0
        Me.cbo_pisSaida.SelectedIndex = 0
        Me.lbl_caminhoImagem.Text = ""
        pct_produto.Image = Nothing

    End Sub

    Private Sub zeraValoresProdutoInfo()
        Me.msk_dtPromInicio.Text = ""
        Me.msk_dtPromFim.Text = ""
        Me.txt_VlrQuota.Text = "0"
        Me.chk_consumo.Checked = False
        Me.chk_imobilizado.Checked = False
        Me.chk_servico.Checked = False
        Me.chk_inativo.Checked = False
        Me.chk_matePrima.Checked = False
        Me.dtg_saldos.Rows.Clear()
        Me.msk_dtBonifInicio.Text = ""
        Me.msk_dtBonifFin.Text = ""
        Me.rdb_bonifQuant.Checked = False
        Me.rdb_bonifVlr.Checked = False
        Me.rdb_bonifNao.Checked = False
        Me.txt_bonifQuant.Text = "0,00"
        Me.txt_bonifVlr.Text = "0,00"
        Me.txt_qtdeBonificCliente.Text = "0"
        lbl_mensagem02.Text = ""

    End Sub

    Private Sub zeraValoresProdutoPis()
        Me.txt_ncmpis.Text = ""
        configPisCofinsPadrao = False
        Try
            Me.dtg_BuscaPisCofins.Rows.Clear()
            Me.dtg_BuscaPisCofins.Refresh()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_consultaPis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultaPis.Click
        If Not Me.txt_ncmpis.Text.Equals("") AndAlso IsNumeric(Me.txt_ncmpis.Text) AndAlso _
        Me.txt_ncmpis.TextLength = 8 Then
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            preenchDtgPisCofins(conection)
            btn_GravaPis.Enabled = True
            _ncmProduto = Me.txt_ncmpis.Text
            conection = Nothing
        End If

    End Sub

    Private Sub preenchDtgPisCofins(ByVal conexao As NpgsqlConnection)

        Try
            If conexao.State = ConnectionState.Closed Then conexao.Open()
        Catch ex As Exception
        End Try

        If conexao.State = ConnectionState.Open Then
            Dim sqlPisCofins As New StringBuilder
            Dim cmdPisCofins As NpgsqlCommand
            Dim daPisCofins As NpgsqlDataAdapter
            Dim drPisCofins As NpgsqlDataReader
            Dim dtNotas As New DataTable
            Dim mDescricao As String = ""

            Try
                sqlPisCofins.Append("SELECT ncm_ncm, ncm_cfop, ncm_pisent, ncm_cofinsent, ncm_pissaid, ncm_cofinssaid, ") '5
                sqlPisCofins.Append("ncm_natpis, ncm_natcofins, ncm_descricao FROM estncm WHERE ncm_ncm = '" & Me.txt_ncmpis.Text & "'") '7
                cmdPisCofins = New NpgsqlCommand(sqlPisCofins.ToString, conexao)
                drPisCofins = cmdPisCofins.ExecuteReader

                dtg_BuscaPisCofins.Rows.Clear()
                dtg_BuscaPisCofins.Refresh()

                'Se não retornar resultados preenche com os valores padrões...
                If (drPisCofins.HasRows = False) OrElse (configPisCofinsPadrao = True) Then
                    cmdPisCofins.CommandText = ""
                    drPisCofins.Close()
                    sqlPisCofins.Remove(0, sqlPisCofins.ToString.Length)

                    sqlPisCofins.Append("SELECT descroperacao, pisent, cofent, pissaid, cofsaid, natpis, natcof, ") '6
                    sqlPisCofins.Append("cfops FROM piscofpadrao") '7
                    cmdPisCofins = New NpgsqlCommand(sqlPisCofins.ToString, conexao)
                    drPisCofins = cmdPisCofins.ExecuteReader

                    dtg_BuscaPisCofins.Rows.Clear()
                    dtg_BuscaPisCofins.Refresh()
                    While drPisCofins.Read

                        Dim mlinha As String() = {Me.txt_ncmpis.Text, drPisCofins(0).ToString, drPisCofins(1).ToString, _
                                                  drPisCofins(2).ToString, drPisCofins(3).ToString, drPisCofins(4).ToString, _
                                                  drPisCofins(5).ToString, drPisCofins(6).ToString, drPisCofins(7).ToString}
                        'Adicionando Linha
                        Me.dtg_BuscaPisCofins.Rows.Add(mlinha)
                        dtg_BuscaPisCofins.Refresh()
                        mlinha = Nothing
                    End While
                    drPisCofins.Close()

                Else

                    While drPisCofins.Read
                        mDescricao = drPisCofins(8).ToString 'trazDescricaoCFOP(drPisCofins(1).ToString) 'drPisCofins(1).ToString.Substring(0, 4)
                        'If mDescricao.Equals("") Then mDescricao = drPisCofins(8).ToString

                        Dim mlinha As String() = {drPisCofins(_valorZERO).ToString, mDescricao, drPisCofins(2).ToString, _
                                                  drPisCofins(3).ToString, drPisCofins(4).ToString, drPisCofins(5).ToString, _
                                                  drPisCofins(6).ToString, drPisCofins(7).ToString, drPisCofins(1).ToString}
                        'Adicionando Linha
                        Me.dtg_BuscaPisCofins.Rows.Add(mlinha)
                        dtg_BuscaPisCofins.Refresh()
                        mlinha = Nothing
                    End While
                    drPisCofins.Close()
                End If


                cmdPisCofins.CommandText = ""
            Catch ex As Exception
            End Try

            sqlPisCofins.Remove(_valorZERO, sqlPisCofins.ToString.Length)

            conexao.ClearPool()
            daPisCofins = Nothing
            cmdPisCofins = Nothing
            sqlPisCofins = Nothing
            dtNotas = Nothing
            Me.dtg_BuscaPisCofins.Focus()
            conexao.Close()
            conexao = Nothing

        End If

    End Sub

    Private Sub dtg_BuscaPisCofins_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dtg_BuscaPisCofins.EditingControlShowing
        Me.dtg_BuscaPisCofins.CurrentCell.Style.BackColor = Color.White
        Me.dtg_BuscaPisCofins.CurrentCell.InheritedStyle.BackColor = Color.PaleTurquoise
    End Sub

    Private Sub btn_delPis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delPis.Click
        Try
            dtg_BuscaPisCofins.Rows.Remove(dtg_BuscaPisCofins.CurrentRow)
            dtg_BuscaPisCofins.Refresh()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_GravaPis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GravaPis.Click
        Dim _mstr As String = ""
        _msgErroCelula = ""
        If existErroGridPis() = False Then

            If gravaGridPis() Then

                dtg_BuscaPisCofins.Rows.Clear()
                dtg_BuscaPisCofins.Refresh()
                If MessageBox.Show("Situações de NCM gravadas com sucesso! Deseja gravar tudo?", "METROSYS", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) _
                                = Windows.Forms.DialogResult.Yes Then
                    'Aqui chama o gravar produtos..
                    salvandoProduto()
                Else
                    tbc_produtos.SelectTab(0)
                    Btn_salvar.Focus()
                End If
                btn_GravaPis.Enabled = False

            Else
                MsgBox("Deu erro ao gravar as Situações de NCM", MsgBoxStyle.Exclamation)
            End If
        End If

    End Sub

    Public Function gravaGridPis() As Boolean
        Dim mNCM As String = "", mCSTpisEnt As String = "", mCSTcofinsEnt As String = ""
        Dim mCSTpisSaid As String = "", mCSTcofinsSaid As String = ""
        Dim mNatPis As String = "", mNatCofins As String = "", mCFOPs As String = "", mDescricao As String = ""
        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim tudoOK As Boolean = False
        Dim deletaNCM As Boolean = True

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try

        Try
            transacao = conexao.BeginTransaction

            Try
                For Each row As DataGridViewRow In Me.dtg_BuscaPisCofins.Rows
                    If Not row.IsNewRow Then
                        mNCM = Me.txt_ncmpis.Text 'row.Cells(0).Value
                        mDescricao = row.Cells(1).Value.ToString
                        mCSTpisEnt = row.Cells(2).Value
                        mCSTcofinsEnt = row.Cells(3).Value
                        mCSTpisSaid = row.Cells(4).Value
                        mCSTcofinsSaid = row.Cells(5).Value
                        mNatPis = row.Cells(6).Value
                        mNatCofins = row.Cells(7).Value
                        mCFOPs = row.Cells(8).Value

                        ' se não existir o NCM na tabela, inclui valores, caso exista deleta e depois inclui os novos valores
                        If _clBD.existEstNCM(mNCM, conexao) = False Then
                            _clBD.incluiEstNCM(mNCM, mCFOPs, mCSTpisEnt, mCSTcofinsEnt, mCSTpisSaid, mCSTcofinsSaid, mNatPis, mNatCofins, mDescricao, conexao)
                        Else
                            If deletaNCM = True Then
                                _clBD.deletaEstNCM(mNCM, conexao)
                                deletaNCM = False
                            End If
                            _clBD.incluiEstNCM(mNCM, mCFOPs, mCSTpisEnt, mCSTcofinsEnt, mCSTpisSaid, mCSTcofinsSaid, mNatPis, mNatCofins, mDescricao, conexao)
                        End If

                    End If
                Next

                transacao.Commit()
                tudoOK = True
            Catch ex1 As Exception
                Try
                    transacao.Rollback()
                Catch ex2 As Exception
                    tudoOK = False
                End Try
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
            tudoOK = False

        Finally

            conexao.ClearAllPools()
            If conexao.State = ConnectionState.Open Then conexao.Close()
            conexao = Nothing : transacao = Nothing
        End Try

        Return tudoOK
    End Function

    Private Function existErroGridPis() As Boolean

        For Each row As DataGridViewRow In Me.dtg_BuscaPisCofins.Rows
            If Not row.IsNewRow Then
                row.Cells(0).Value = Me.txt_ncmpis.Text
                If row.Cells(0).Value = Nothing OrElse Trim(row.Cells(0).Value).Equals("") OrElse _
                row.Cells(0).Value.ToString.Length <> 8 Then
                    MsgBox("NCM errado!", MsgBoxStyle.Exclamation)
                    Return True
                End If

                If row.Cells(1).Value = Nothing OrElse Trim(row.Cells(1).Value).Equals("") Then
                    Me.dtg_BuscaPisCofins.Rows(row.Index).Cells(1).Style.BackColor = Color.OrangeRed
                    MsgBox("Descricao de PIS/COFINS errada!", MsgBoxStyle.Exclamation)
                    _indexCelulaErro = 1
                    _indexLinhaErro = row.Index

                    If MessageBox.Show("Deseja buscar com a configuração padrão?", "PIS/COFINS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
                    Windows.Forms.DialogResult.Yes Then

                        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                        configPisCofinsPadrao = True
                        preenchDtgPisCofins(conection)
                        btn_GravaPis.Enabled = True
                        _ncmProduto = Me.txt_ncmpis.Text
                        conection = Nothing
                        configPisCofinsPadrao = False

                    End If

                    Return True
                End If

                If row.Cells(2).Value = Nothing OrElse Trim(row.Cells(2).Value).Equals("") OrElse _
                Trim(row.Cells(2).Value).Length <> 2 Then
                    Me.dtg_BuscaPisCofins.Rows(row.Index).Cells(2).Style.BackColor = Color.OrangeRed
                    MsgBox("Valor do PisEntrada errado!", MsgBoxStyle.Exclamation)
                    _indexCelulaErro = 2
                    _indexLinhaErro = row.Index
                    Return True
                End If

                If row.Cells(3).Value = Nothing OrElse Trim(row.Cells(3).Value).Equals("") OrElse _
                Trim(row.Cells(3).Value).Length <> 2 Then
                    Me.dtg_BuscaPisCofins.Rows(row.Index).Cells(3).Style.BackColor = Color.OrangeRed
                    MsgBox("Valor do CofinsEntrada errado!", MsgBoxStyle.Exclamation)
                    _indexCelulaErro = 3
                    _indexLinhaErro = row.Index
                    Return True
                End If

                If row.Cells(4).Value = Nothing OrElse Trim(row.Cells(4).Value).Equals("") OrElse _
                Trim(row.Cells(4).Value).Length <> 2 Then
                    Me.dtg_BuscaPisCofins.Rows(row.Index).Cells(4).Style.BackColor = Color.OrangeRed
                    MsgBox("Valor do PisSaida errado!", MsgBoxStyle.Exclamation)
                    _indexCelulaErro = 4
                    _indexLinhaErro = row.Index
                    Return True
                End If

                If row.Cells(5).Value = Nothing OrElse Trim(row.Cells(5).Value).Equals("") OrElse _
                Trim(row.Cells(5).Value).Length <> 2 Then
                    Me.dtg_BuscaPisCofins.Rows(row.Index).Cells(5).Style.BackColor = Color.OrangeRed
                    MsgBox("Valor do CofinsSaida errado!", MsgBoxStyle.Exclamation)
                    _indexCelulaErro = 5
                    _indexLinhaErro = row.Index
                    Return True
                End If

                If row.Cells(6).Value <> Nothing Then
                    If Trim(row.Cells(6).Value).Length <> 3 Then
                        Me.dtg_BuscaPisCofins.Rows(row.Index).Cells(6).Style.BackColor = Color.OrangeRed
                        MsgBox("Valor da Natureza do Pis errado!", MsgBoxStyle.Exclamation)
                        _indexCelulaErro = 6
                        _indexLinhaErro = row.Index
                        Return True
                    End If
                End If

                If row.Cells(7).Value <> Nothing Then
                    If Trim(row.Cells(7).Value).Length <> 3 Then
                        Me.dtg_BuscaPisCofins.Rows(row.Index).Cells(7).Style.BackColor = Color.OrangeRed
                        MsgBox("Valor da Natureza do Cofins errado!", MsgBoxStyle.Exclamation)
                        _indexCelulaErro = 7
                        _indexLinhaErro = row.Index
                        Return True
                    End If
                End If

                If row.Cells(8).Value = Nothing OrElse Trim(row.Cells(8).Value).Length < 4 Then
                    Me.dtg_BuscaPisCofins.Rows(row.Index).Cells(8).Style.BackColor = Color.OrangeRed
                    Me.dtg_BuscaPisCofins.Rows(row.Index).Selected = True
                    MsgBox("CFOPs deve ter 4 caracteres, separados por ; com exeção do último", MsgBoxStyle.Exclamation)
                    _indexCelulaErro = 8
                    _indexLinhaErro = row.Index
                    Return True
                ElseIf verifCFOPsPisOK(row.Cells(8).Value.ToString) = False Then
                    Me.dtg_BuscaPisCofins.Rows(row.Index).Cells(8).Style.BackColor = Color.OrangeRed
                    MsgBox("CFOP(s) não existe!", MsgBoxStyle.Exclamation)
                    _indexCelulaErro = 8
                    _indexLinhaErro = row.Index
                    Return True
                End If

            End If
        Next

        Return False
    End Function

    Private Function trazDescricaoCFOP(ByVal cfop As String) As String
        Dim mdescricao As String = ""

        If cfop.IndexOf("910") >= 0 OrElse cfop.IndexOf("949") >= 0 OrElse cfop.IndexOf("923") >= 0 _
        OrElse cfop.IndexOf("920") >= 0 OrElse cfop.IndexOf("921") >= 0 Then
            mdescricao = "Bonificacao e outras"
            Return mdescricao
        End If

        If cfop.IndexOf("202") >= 0 Then
            mdescricao = "Devolucao"
            Return mdescricao
        End If

        If cfop.IndexOf("904") >= 0 OrElse cfop.IndexOf("905") >= 0 OrElse cfop.IndexOf("906") >= 0 _
        OrElse cfop.IndexOf("152") >= 0 OrElse cfop.IndexOf("409") >= 0 Then
            mdescricao = "Tranferencias e Remessa"
            Return mdescricao
        End If

        If cfop.IndexOf("908") >= 0 OrElse cfop.IndexOf("556") >= 0 Then
            mdescricao = "Comodato e Mater. Consumo"
            Return mdescricao
        End If

        If cfop.IndexOf("102") >= 0 Then
            mdescricao = "Normal"
            Return mdescricao
        End If

        Return mdescricao
    End Function


    Private Function verifCFOPsPisOK(ByVal cfops As String) As Boolean
        Dim mCFOPsPisOK As Boolean = True
        Dim mArray As Array = Nothing
        Dim i As Integer = 0
        Dim mCfop As String = ""

        mArray = Split(cfops, ";")
        For i = 0 To mArray.Length - 1
            mCfop = mArray(i).ToString
            If _clFuncoes.existCFOP_Tabela(mCfop, MdlConexaoBD.conectionPadrao) Then
                mCFOPsPisOK = True
            Else
                mCFOPsPisOK = False
                Exit For
            End If

        Next

        Return mCFOPsPisOK
    End Function

    Private Sub txt_ncmpis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ncmpis.TextChanged
        btn_GravaPis.Enabled = False
    End Sub

    Private Sub txt_ncmpis_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ncmpis.KeyPress
        'permite só numeros sem ponto e sem virgula
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub dtg_BuscaPisCofins_CellMouseDownExtracted(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

        If _tip Is Nothing Then
            _tip = New ToolTip
            _tip.IsBalloon = False
            _tip.InitialDelay = 1000
            _tip.ToolTipIcon = ToolTipIcon.None
            _tip.ToolTipTitle = ""
            _tip.Active = True
            Try
                _tip.Show(dtg_BuscaPisCofins.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, Me.dtg_BuscaPisCofins)
            Catch ex As Exception
            End Try

        Else
            If e.RowIndex >= 0 AndAlso e.ColumnIndex > 0 Then
                _tip.ToolTipIcon = ToolTipIcon.None
                _tip.ToolTipTitle = ""
                _tip.IsBalloon = False
                _tip.InitialDelay = 1000
                _tip.Active = True
                Try
                    Dim mValorColuna As String = Trim(dtg_BuscaPisCofins.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString)
                    Dim mCorColuna As String = Me.dtg_BuscaPisCofins.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor.ToString
                    Select Case e.ColumnIndex
                        'Me.dtg_BuscaPisCofins.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor <> Color.OrangeRed
                        Case 1 And Not mCorColuna.Equals("Color.OrangeRed")
                            If Not mValorColuna.Equals("") AndAlso mValorColuna.Length > 23 Then
                                _tip.Show(mValorColuna, Me.dtg_BuscaPisCofins)
                            End If

                        Case 8 And (mCorColuna <> "Color.OrangeRed")
                            If Not mValorColuna.Equals("") AndAlso mValorColuna.Length > 13 Then
                                _tip.Show(mValorColuna, Me.dtg_BuscaPisCofins)
                            End If

                    End Select
                    mValorColuna = Nothing : mCorColuna = Nothing
                Catch ex As Exception
                End Try

            End If
        End If
    End Sub

    Private Sub dtg_BuscaPisCofins_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dtg_BuscaPisCofins.CellMouseDown

        If Not _msgErroCelula.Equals("") Then

            If e.ColumnIndex = _indexCelulaErro Then

                If _tip Is Nothing Then
                    _tip = New ToolTip
                    _tip.IsBalloon = True
                    _tip.InitialDelay = 2000
                    _tip.ToolTipIcon = ToolTipIcon.Error
                    _tip.ToolTipTitle = "Erro"
                    _tip.Active = True
                    _tip.Show(_msgErroCelula, Me.dtg_BuscaPisCofins)

                Else
                    _tip.IsBalloon = True
                    _tip.InitialDelay = 2000
                    _tip.ToolTipIcon = ToolTipIcon.Error
                    _tip.ToolTipTitle = "Erro"
                    If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                        Dim mVlColuna As String = ""
                        Try
                            mVlColuna = Me.dtg_BuscaPisCofins.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                        Catch ex As Exception
                            mVlColuna = Nothing
                        End Try

                        If e.RowIndex = _indexLinhaErro AndAlso e.ColumnIndex = _indexCelulaErro Then
                            Select Case _indexCelulaErro
                                Case 1
                                    If mVlColuna = Nothing OrElse Trim(mVlColuna).Equals("") Then
                                        _tip.Active = True
                                        _tip.Show(_msgErroCelula, Me.dtg_BuscaPisCofins)
                                    End If
                                Case 2
                                    If mVlColuna = Nothing OrElse Trim(mVlColuna).Equals("") OrElse _
                                    Trim(mVlColuna).Length <> 2 Then
                                        _tip.Active = True
                                        _tip.Show(_msgErroCelula, Me.dtg_BuscaPisCofins)
                                    End If
                                Case 3
                                    If mVlColuna = Nothing OrElse Trim(mVlColuna).Equals("") OrElse _
                                    Trim(mVlColuna).Length <> 2 Then
                                        _tip.Active = True
                                        _tip.Show(_msgErroCelula, Me.dtg_BuscaPisCofins)
                                    End If
                                Case 4
                                    If mVlColuna = Nothing OrElse Trim(mVlColuna).Equals("") OrElse _
                                    Trim(mVlColuna).Length <> 2 Then
                                        _tip.Active = True
                                        _tip.Show(_msgErroCelula, Me.dtg_BuscaPisCofins)
                                    End If

                                Case 5
                                    If mVlColuna = Nothing OrElse Trim(mVlColuna).Equals("") OrElse _
                                    Trim(mVlColuna).Length <> 2 Then
                                        _tip.Active = True
                                        _tip.Show(_msgErroCelula, Me.dtg_BuscaPisCofins)
                                    End If

                                Case 6
                                    If mVlColuna <> Nothing Then
                                        If Trim(mVlColuna).Length <> 3 Then
                                            _tip.Active = True
                                            _tip.Show(_msgErroCelula, Me.dtg_BuscaPisCofins)
                                        End If
                                    End If
                                Case 7
                                    If mVlColuna <> Nothing Then
                                        If Trim(mVlColuna).Length <> 3 Then
                                            _tip.Active = True
                                            _tip.Show(_msgErroCelula, Me.dtg_BuscaPisCofins)
                                        End If
                                    End If
                                Case 8
                                    If mVlColuna = Nothing OrElse Trim(mVlColuna).Length < 4 Then
                                        _tip.Active = True
                                        _tip.Show(_msgErroCelula, Me.dtg_BuscaPisCofins)
                                    End If
                            End Select
                        End If

                    End If
                End If


            Else
                If _tip IsNot Nothing Then _tip.Active = False
                dtg_BuscaPisCofins_CellMouseDownExtracted(e)
            End If

        Else
            dtg_BuscaPisCofins_CellMouseDownExtracted(e)
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbc_produtos.SelectedIndexChanged

        Select Case tbc_produtos.SelectedIndex
            Case 3

                If Not Me.txt_ncm.Text.Equals("") AndAlso IsNumeric(Me.txt_ncm.Text) AndAlso _
                   Me.txt_ncm.TextLength = 8 Then

                    If Trim(Me.txt_ncmpis.Text).Equals("") Then
                        txt_ncmpis.Text = txt_ncm.Text 'Preenche o combo box do grupo e unidades...
                        'Preenche o DataGridPisCofins
                        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                        preenchDtgPisCofins(conection)
                        conection = Nothing
                    End If

                End If
        End Select
    End Sub

    Private Sub txt_ncm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ncm.KeyPress
        'permite só numeros sem ponto e sem virgula
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub preencheCbo_Grupo(ByVal conexao As NpgsqlConnection)
        Try
            If conexao.State = ConnectionState.Closed Then conexao.Open()
        Catch ex As Exception
        End Try

        If conexao.State = ConnectionState.Open Then
            Dim sqlGrupo As New StringBuilder
            Dim cmdGrupo As NpgsqlCommand
            Dim drGrupo As NpgsqlDataReader

            Try
                sqlGrupo.Append("SELECT eg_grupo || ' - ' || eg_descri FROM estg003 ORDER BY eg_grupo ASC")
                cmdGrupo = New NpgsqlCommand(sqlGrupo.ToString, conexao)
                drGrupo = cmdGrupo.ExecuteReader

                If drGrupo.HasRows = True Then
                    cbo_grupo.AutoCompleteCustomSource.Clear()
                    cbo_grupo.Items.Clear()
                    cbo_grupo.Refresh()
                    While drGrupo.Read
                        cbo_grupo.AutoCompleteCustomSource.Add(drGrupo(0).ToString)
                        cbo_grupo.Items.Add(drGrupo(0).ToString)

                    End While
                    cbo_grupo.SelectedIndex = -1
                    drGrupo.Close() : conexao.ClearPool()

                End If
                cmdGrupo.CommandText = ""

            Catch ex As Exception
            End Try

            sqlGrupo.Remove(_valorZERO, sqlGrupo.ToString.Length)
            cmdGrupo = Nothing : sqlGrupo = Nothing : Me.dtg_BuscaPisCofins.Focus()
            conexao.Close() : conexao = Nothing

        End If

    End Sub

    Private Sub preencheCbo_Unidades(ByVal conexao As NpgsqlConnection)
        Try
            If conexao.State = ConnectionState.Closed Then conexao.Open()
        Catch ex As Exception
        End Try

        If conexao.State = ConnectionState.Open Then
            Dim sqlUnd As New StringBuilder
            Dim cmdUnd As NpgsqlCommand
            Dim drUnd As NpgsqlDataReader

            Try
                sqlUnd.Append("SELECT medida || '  ' || descricao  FROM medida")
                cmdUnd = New NpgsqlCommand(sqlUnd.ToString, conexao)
                drUnd = cmdUnd.ExecuteReader

                If drUnd.HasRows = True Then
                    cbo_und.AutoCompleteCustomSource.Clear()
                    cbo_und.Items.Clear()
                    cbo_und.Refresh()
                    While drUnd.Read
                        cbo_und.AutoCompleteCustomSource.Add(drUnd(0).ToString)
                        cbo_und.Items.Add(drUnd(0).ToString)

                    End While
                    cbo_und.SelectedIndex = -1
                    drUnd.Close() : conexao.ClearPool()

                End If
                cmdUnd.CommandText = ""

            Catch ex As Exception
            End Try

            sqlUnd.Remove(_valorZERO, sqlUnd.ToString.Length)
            cmdUnd = Nothing : sqlUnd = Nothing : Me.dtg_BuscaPisCofins.Focus()
            conexao.Close() : conexao = Nothing

        End If

    End Sub

    Private Sub cbo_grupo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_grupo.GotFocus
        If Not (Me.cbo_grupo.DroppedDown) AndAlso Me.cbo_grupo.SelectedIndex < _valorZERO Then Me.cbo_grupo.DroppedDown = True
    End Sub

    Private Sub cbo_und_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_und.GotFocus
        If Not (Me.cbo_und.DroppedDown) AndAlso Me.cbo_und.SelectedIndex < _valorZERO Then Me.cbo_und.DroppedDown = True
    End Sub

    Private Sub btn_proximaAba01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proximaAba01.Click
        tbc_produtos.SelectTab(2)
    End Sub

    Private Sub preencheDtg_Produto()
        Dim nomeCampo As String = ""

        Dim pesquisa As String = (Me.txt_pesquisa.Text).ToUpper
        Me.lbl_mensagem01.Text = ".  "

        If Me.rdb_barra.Checked = True Then
            nomeCampo = "e_cdbarra"
        ElseIf Me.Rdb_codigo.Checked = True Then
            nomeCampo = "e_codig"
        Else
            nomeCampo = "e_produt"
        End If


        Try

            If oConnBDMETROSYS.State = ConnectionState.Closed Then oConnBDMETROSYS.Open()
        Catch ex As Exception
            Me.lbl_mensagem01.Text = "Erro:: " & ex.Message & " !"
        End Try

        apagaImagem()
        If oConnBDMETROSYS.State = ConnectionState.Open Then
            Dim codigo, nome, fornecedor, qtdEstoque, undMedida, ncmProd As String
            Dim sldAtual, pcoAnt, custAnt, CLF, prvenda As String
            Dim CST, CFV, GRUPO, REDUZ As Integer

            Try

                SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, el.e_qtde, e.e_und, e.e_ncm, ") ' 5
                SqlProduto.Append("e.e_cst, e.e_cfv, e.e_grupo, e.e_reduz, el.e_qtdfisc, el.e_pcusto, el.e_pcomp, ") ' 12
                SqlProduto.Append("e.e_clf, el.e_pvenda FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN ")
                SqlProduto.Append("estloja01 el ON e.e_codig = el.e_codig WHERE ")
                SqlProduto.Append("e.e_materiaprima = " & Me.chk_MPrima.Checked & " AND ")
                SqlProduto.Append("el.e_loja = '" & _local & "' AND ")
                If Me.rdb_barra.Checked = True Then
                    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE @pesquisa ORDER BY e.e_produt ASC")
                ElseIf Rdb_codigo.Checked = True Then
                    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE @pesquisa ORDER BY e.e_produt ASC")
                Else
                    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE @pesquisa ORDER BY e.e_produt ASC")
                End If


                CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDMETROSYS)

                If Me.rdb_barra.Checked = True Then
                    CmdProduto.Parameters.Add("@pesquisa", pesquisa & "%")
                ElseIf Rdb_codigo.Checked = True Then
                    CmdProduto.Parameters.Add("@pesquisa", "%" & pesquisa)
                Else
                    CmdProduto.Parameters.Add("@pesquisa", pesquisa & "%")
                End If


                drProduto = CmdProduto.ExecuteReader
                dtg_produto.Rows.Clear()
                While drProduto.Read
                    codigo = drProduto(0).ToString
                    nome = drProduto(1).ToString
                    fornecedor = drProduto(2).ToString
                    Try
                        qtdEstoque = drProduto(3)
                    Catch ex As Exception
                        qtdEstoque = "0,00"
                    End Try

                    undMedida = drProduto(4).ToString
                    ncmProd = drProduto(5).ToString
                    CST = drProduto(6)
                    CFV = drProduto(7)
                    GRUPO = drProduto(8)
                    REDUZ = drProduto(9)
                    sldAtual = drProduto(10).ToString
                    custAnt = drProduto(11).ToString
                    pcoAnt = drProduto(12).ToString
                    CLF = drProduto(13).ToString
                    prvenda = drProduto(14).ToString

                    dtg_produto.Rows.Add(codigo, nome, Format(CDbl(qtdEstoque), "###,##0.00"), undMedida, _
                                         Format(CDbl(prvenda), "###,##0.00"), fornecedor, ncmProd, _
                                        CST, CFV, GRUPO, REDUZ, sldAtual, custAnt, pcoAnt, CLF)

                End While

                drProduto.Close()
                txt_qtdRegistros.Text = dtg_produto.Rows.Count
            Catch ex As Exception
                Me.lbl_mensagem01.Text = "Erro:: " & ex.Message & " !"
            End Try

            CmdProduto.CommandText = ""
            SqlProduto.Remove(0, SqlProduto.ToString.Length)
            oConnBDMETROSYS.ClearPool()

        End If

    End Sub

    Private Sub preencheDtg_Saldos(ByVal codProduto As String)

        Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim daSaldos As NpgsqlDataAdapter
        Dim dsSaldos As New DataSet
        Dim cmdSaldos As New NpgsqlCommand
        Dim sqlSaldos As New StringBuilder
        Dim drSaldos As NpgsqlDataReader

        Try

            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return
        End Try

        Dim codigo, sldAtual, pcoVenda As String

        Try

            sqlSaldos.Append("SELECT el.e_loja, el.e_qtde, el.e_pvenda ")
            sqlSaldos.Append("FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN ")
            sqlSaldos.Append(" estloja01 el ON e.e_codig = el.e_codig WHERE el.e_codig = @e_codig ")

            CmdProduto = New NpgsqlCommand(sqlSaldos.ToString, oConnBDMETROSYS)
            CmdProduto.Parameters.Add("@e_codig", codProduto)

            daSaldos = New NpgsqlDataAdapter(sqlSaldos.ToString, oConnBDMETROSYS)
            drSaldos = CmdProduto.ExecuteReader
            dtg_saldos.Rows.Clear()
            While drSaldos.Read
                codigo = drSaldos(0).ToString
                sldAtual = drSaldos(1).ToString
                pcoVenda = Format(drSaldos(2), "###,##0.00")

                dtg_saldos.Rows.Add(codigo, sldAtual, pcoVenda)

            End While
            dtg_saldos.Refresh()

            drSaldos.Close()
            dsSaldos.Clear()
        Catch ex As Exception
        End Try

        CmdProduto.CommandText = ""
        sqlSaldos.Remove(0, sqlSaldos.ToString.Length)
        dsSaldos.Clear() : daSaldos.Dispose()
        oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()


    End Sub

    Private Sub leituraCamposValores()

        txt_pcompra.ReadOnly = True : txt_pcompra.BackColor = Me.txt_nomePart.BackColor
        txt_pcusto.ReadOnly = True : txt_pcusto.BackColor = Me.txt_nomePart.BackColor
        txt_pvenda.ReadOnly = True : txt_pvenda.BackColor = Me.txt_nomePart.BackColor
        'txt_pauta.ReadOnly = True : txt_pauta.BackColor = Me.txt_nomePart.BackColor
        txt_sldfiscal.ReadOnly = True : txt_sldfiscal.BackColor = Me.txt_nomePart.BackColor
        txt_saldo.ReadOnly = True : txt_saldo.BackColor = Me.txt_nomePart.BackColor
        'txt_pesoBruto.ReadOnly = True : txt_pesoBruto.BackColor = Me.txt_nomePart.BackColor
        'txt_pesoLiquido.ReadOnly = True : txt_pesoLiquido.BackColor = Me.txt_nomePart.BackColor
        msk_dtValid.ReadOnly = True : msk_dtValid.BackColor = Me.txt_nomePart.BackColor
        txt_minimo.BackColor = Me.txt_nomePart.BackColor

    End Sub

    Private Sub limpaLeituraCamposValores()
        txt_pcompra.ReadOnly = False : txt_pcompra.BackColor = Color.White
        txt_pcusto.ReadOnly = False : txt_pcusto.BackColor = Color.White
        txt_pvenda.ReadOnly = False : txt_pvenda.BackColor = Color.White
        'txt_pauta.ReadOnly = False : txt_pauta.BackColor = Color.White
        txt_sldfiscal.ReadOnly = False : txt_sldfiscal.BackColor = Color.White
        txt_saldo.ReadOnly = False : txt_saldo.BackColor = Color.White
        'txt_pesoBruto.ReadOnly = False : txt_pesoBruto.BackColor = Color.White
        'txt_pesoLiquido.ReadOnly = False : txt_pesoLiquido.BackColor = Color.White
        msk_dtValid.ReadOnly = False : msk_dtValid.BackColor = Color.White
        txt_minimo.BackColor = Color.White

    End Sub

    Private Sub limpaCamposProd()
        txt_codigo.Text = ""
        txt_codbarras.Text = ""
        txt_ncm.Text = ""
        txt_descricao.Text = ""
        txt_codPart.Text = ""
        txt_nomePart.Text = ""
        txt_embalagem.Text = ""
        txt_linha.Text = "0"
        txt_pcompra.Text = "0,00"
        txt_sldfiscal.Text = "0,00"
        cbo_grupo.SelectedIndex = -1
        cbo_und.SelectedIndex = -1
        If MdlUsuarioLogando._usuarioPrivilegio = True Then
            Me.txt_sldfiscal.ReadOnly = False
        Else
            Me.txt_sldfiscal.ReadOnly = True
        End If
        Me.txt_sldfiscal.Text = "0,00"

    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        executeF2()
    End Sub

    Private Function trazFornecedor(ByVal codFornec As String) As Boolean
        Dim nomeCampo As String = ""
        Dim nomeCampoCgc As String = ""
        Dim nomeCampoCpf As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        Dim pesquisa As String = codFornec.ToUpper

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
        End Try


        Dim codigo, nome, cpf_cnpj, inscricao, UF As String
        codigo = "" : nome = "" : cpf_cnpj = "" : inscricao = "" : UF = ""

        Try
            SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc,p_uf FROM cadp001 WHERE ") ' 5
            SqlParticipante.Append("p_cod = '" & pesquisa & "' ORDER BY p_portad ASC")
            CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDGENOV)
            drParticipante = CmdParticipante.ExecuteReader

            If drParticipante.HasRows = False Then
                Return False
            Else
                While drParticipante.Read
                    codigo = drParticipante(_valorZERO).ToString
                    nome = drParticipante(1).ToString
                End While
                Me.txt_nomePart.Text = nome
                drParticipante.Close()

            End If

        Catch ex As Exception
        End Try

        CmdParticipante.CommandText = ""
        SqlParticipante.Remove(_valorZERO, SqlParticipante.ToString.Length)
        oConnBDGENOV.ClearPool() : oConnBDGENOV.Close()

        drParticipante = Nothing : CmdParticipante = Nothing : SqlParticipante = Nothing
        oConnBDGENOV = Nothing


        Return True
    End Function

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown

        If Not Me.txt_codPart.Text.Equals("") Then

            If (Me.txt_codPart.TextLength > 5) AndAlso (e.KeyCode = Keys.Enter) Then 'Se retornar nada

                If trazFornecedor(Me.txt_codPart.Text) Then
                    Dim lShouldReturn As Boolean
                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()
                    If lShouldReturn Then
                        Return
                    End If
                    lShouldReturn = Nothing

                End If
            End If
        End If

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then
            If Me.txt_codPart.Text.Equals("") Then
                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    _frmRef = Me
                    _BuscaForn.set_frmRef(Me)
                    _BuscaForn.ShowDialog(Me)
                    If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus()

                    Dim lShouldReturn As Boolean
                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()
                    If lShouldReturn Then
                        Return
                    End If
                    lShouldReturn = Nothing
                Catch ex As Exception
                End Try

            End If
        End If

    End Sub

    Private Sub Frm_ManProdutos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")

        End If


    End Sub

    Private Sub cbo_subst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_CST.GotFocus
        If Not (Me.cbo_CST.DroppedDown) AndAlso Me.cbo_CST.SelectedIndex < _valorZERO Then Me.cbo_CST.DroppedDown = True
    End Sub

    Private Sub cbo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo.GotFocus
        If Not (Me.cbo_tipo.DroppedDown) AndAlso Me.cbo_tipo.SelectedIndex < _valorZERO Then Me.cbo_tipo.DroppedDown = True
    End Sub

    Private Sub cbo_VF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_CFV.GotFocus
        If Not (Me.cbo_CFV.DroppedDown) AndAlso Me.cbo_CFV.SelectedIndex < _valorZERO Then Me.cbo_CFV.DroppedDown = True
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If Not txt_codigo.Text.Equals("") Then
            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then


                tbc_produtos.SelectTab(0)
                limpaCamposProd()
                limpaLeituraCamposValores()
                zeraValoresProdutoPrincipal()
                zeraValoresProdutoInfo()
                zeraValoresProdutoPis()
                preencheDtg_Produto()
                apagaImagem()
                tbp_cadPrincipal.Text = "Cadastro"
                _incluindo = False
                _alterando = False
                Btn_salvar.Enabled = False
                txt_pesquisa.Focus()

            End If
        Else

            tbc_produtos.SelectTab(0)
            limpaCamposProd()
            limpaLeituraCamposValores()
            zeraValoresProdutoPrincipal()
            zeraValoresProdutoInfo()
            zeraValoresProdutoPis()
            apagaImagem()
            tbp_cadPrincipal.Text = "Cadastro"
            _incluindo = False
            _alterando = False
            Btn_salvar.Enabled = False
        End If

    End Sub

    Private Sub txt_pesquisa_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pesquisa.KeyUp

        Select Case e.KeyCode
            Case Keys.Down
                Me.dtg_produto.Focus()
        End Select
    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged
        Me.preencheDtg_Produto()
    End Sub

    Private Sub rdb_bonifQuant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_bonifVlr.CheckedChanged, rdb_bonifQuant.CheckedChanged, rdb_bonifNao.CheckedChanged
        If rdb_bonifQuant.Checked Then
            txt_bonifQuant.ReadOnly = False
            txt_bonifVlr.ReadOnly = True
        End If

        If rdb_bonifVlr.Checked Then
            txt_bonifVlr.ReadOnly = False
            txt_bonifQuant.ReadOnly = True
        End If

        If rdb_bonifNao.Checked Then
            txt_bonifVlr.ReadOnly = True
            txt_bonifQuant.ReadOnly = True
        End If

    End Sub

    Private Sub txt_pcompra_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pcompra.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_pcompra.Text.Equals("") Then Me.txt_pcompra.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pcompra.Text) Then

            If CDec(Me.txt_pcompra.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Preço de Compra deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Preço de Compra deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pcompra.Text = Format(CDec(Me.txt_pcompra.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_pcusto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pcusto.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_pcusto.Text.Equals("") Then Me.txt_pcusto.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pcusto.Text) Then

            If CDec(Me.txt_pcusto.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Preço de Custo deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Preço de Custo deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pcusto.Text = Format(CDec(Me.txt_pcusto.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_vlpromocao_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlpromocao.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_vlpromocao.Text.Equals("") Then Me.txt_vlpromocao.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vlpromocao.Text) Then

            If CDec(Me.txt_vlpromocao.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Valor da Promoção deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Valor da Promoção deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_vlpromocao.Text = Format(CDec(Me.txt_vlpromocao.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_reducao_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_reducao.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_reducao.Text.Equals("") Then Me.txt_reducao.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_reducao.Text) Then

            If CDec(Me.txt_reducao.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Valor da Redução deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Valor da Redução deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_reducao.Text = Format(CDec(Me.txt_reducao.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_pvenda_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pvenda.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_pvenda.Text.Equals("") Then Me.txt_pvenda.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pvenda.Text) Then

            If CDec(Me.txt_pvenda.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Preço de Venda deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Preço de Venda deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pvenda.Text = Format(CDec(Me.txt_pvenda.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_sldfiscal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_sldfiscal.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_sldfiscal.Text.Equals("") Then Me.txt_sldfiscal.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_sldfiscal.Text) Then

            If CDec(Me.txt_sldfiscal.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Saldo Fiscal deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Saldo Fiscal deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_sldfiscal.Text = Format(CDec(Me.txt_sldfiscal.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_saldo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_saldo.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_saldo.Text.Equals("") Then Me.txt_saldo.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_saldo.Text) Then

            If CDec(Me.txt_saldo.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Saldo deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Saldo deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_saldo.Text = Format(CDec(Me.txt_saldo.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_bonifQuant_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_bonifQuant.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_bonifQuant.Text.Equals("") Then Me.txt_bonifQuant.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_bonifQuant.Text) Then

            If CDec(Me.txt_bonifQuant.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Bonificação por Quantidade deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Bonificação por Quantidade deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_bonifQuant.Text = Format(CDec(Me.txt_bonifQuant.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_bonifVlr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_bonifVlr.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_bonifVlr.Text.Equals("") Then Me.txt_bonifVlr.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_bonifVlr.Text) Then

            If CDec(Me.txt_bonifVlr.Text) <= _valorZERO Then

                lbl_mensagem01.Text = "Bonificação por Valor deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Bonificação por Valor deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_bonifVlr.Text = Format(CDec(Me.txt_bonifVlr.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_quota_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_VlrQuota.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_VlrQuota.Text.Equals("") Then Me.txt_VlrQuota.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_VlrQuota.Text) Then

            If CDec(Me.txt_VlrQuota.Text) < _valorZERO Then

                lbl_mensagem01.Text = "QUOTA deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "QUOTA deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_VlrQuota.Text = Format(CDec(Me.txt_VlrQuota.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_pcompra_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pcompra.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_pcusto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pcusto.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_vlpromocao_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_vlpromocao.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_reducao_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_reducao.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_pvenda_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pvenda.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_sldfiscal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_sldfiscal.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_saldo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_saldo.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_bonifQuant_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_bonifQuant.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_bonifVlr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_bonifVlr.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_quota_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_VlrQuota.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub trazProdutoSelecionado()
        Dim codProduto As String = ""
        codProduto = dtg_produto.CurrentRow.Cells(0).Value

        Try
            If oConnBDMETROSYS.State = ConnectionState.Closed Then oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        If oConnBDMETROSYS.State = ConnectionState.Open Then

            Dim mnomePart As String = ""
            Dim _LOCAL As String = Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2)

            Try
                SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, e.e_und, e.e_clf, e.e_cst, ") '5
                SqlProduto.Append("e.e_cfv, e.e_linha, e.e_grupo, e.e_locacao, e.e_codsubs, e.e_estmin, ") '11
                SqlProduto.Append("e.e_comer, el.e_qtde, el.e_pcusto, el.e_pvenda, e.e_com1, e.e_com2, e.e_peso, ") '18
                SqlProduto.Append("e.e_prom, e.e_reduz, el.e_vprom, el.e_qtdfisc, el.e_inventa, el.e_pcustom, ") '24
                SqlProduto.Append("el.e_pcustoa, e.e_prepo, el.e_pcomp, el.e_dtcomp, el.e_dtvend, el.e_pvend15, ") '30
                SqlProduto.Append("el.e_pvend30, e.e_agreg1, e.e_agreg2, e.e_deposito, e.e_empcre, ") '35
                SqlProduto.Append("e.e_empdeb, e.e_promi, el.e_valid, e.e_status, e.e_fixo, e.e_ptran, ") '41
                SqlProduto.Append("e.e_ipi, e.e_letra, e.e_icmsub, e.e_pis, e.e_icms, e.e_filial1, e.e_filial2, ") '48
                SqlProduto.Append("e.e_bonif, e.e_ncm, e.e_produt2, e.e_pcstent, e.e_pcstsai, e.e_ccstent, ") '54
                SqlProduto.Append("e.e_ccstsai, e.e_pbcalc, e.e_cdforte, e.e_fortcof, e.e_cdbarra, ") '59
                SqlProduto.Append("e.e_embalag, e.e_pesobruto, e.e_pesoliq, e.e_consumo, e.e_imobilizado, ") '64
                SqlProduto.Append("e.e_servico, e.e_inativo, e.e_materiaprima, e.e_balanca, e.e_qtdxund, ") '69
                SqlProduto.Append("e.e_pauta, e.e_classe, cad.p_portad, e.e_tipo, e.e_grade, e.e_dtinicialpromocao, ") '75
                SqlProduto.Append("e.e_dtfinalpromocao, e.e_dtinicialbonific, e.e_dtfinalbonific, e.e_bonificquantidade, ") '79
                SqlProduto.Append("e.e_bonificvalor, e.e_quotapromocao, e.e_qtdebonifcliente, e.e_origem, e.e_cstipi, ") '84
                SqlProduto.Append("e.e_pcstent, e.e_pcstsai, e.e_ccstent, e.e_ccstsai, e.e_produt3, e.e_idimagem ") '90
                SqlProduto.Append("FROM cadp001 cad, " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN ")
                SqlProduto.Append("estloja01 el ON e.e_codig = el.e_codig WHERE ")
                SqlProduto.Append("el.e_codig = '" & codProduto & "' AND el.e_loja = '" & _LOCAL & "' ")
                SqlProduto.Append("AND cad.p_cod = e.e_cdport")

                CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDMETROSYS)
                drProduto = CmdProduto.ExecuteReader

                While drProduto.Read

                    _Produto.pCodig = drProduto(0).ToString : _Produto.pProdut = drProduto(1).ToString
                    _Produto.pCdport = drProduto(2).ToString : _Produto.pUnd = drProduto(3).ToString
                    _Produto.pClf = drProduto(4).ToString : _Produto.pCst = drProduto(5)
                    _Produto.pCfv = drProduto(6) : _Produto.pLinha = drProduto(7)
                    _Produto.pGrupo = drProduto(8) : _Produto.pLocacao = drProduto(9).ToString
                    _Produto.pCodsubs = drProduto(10).ToString : _Produto.pEstmin = drProduto(11)
                    _Produto.pComer = drProduto(12).ToString : _Produto.pQtde = drProduto(13)
                    _Produto.pPcusto = drProduto(14) : _Produto.pPvenda = drProduto(15)
                    _Produto.pCom1 = drProduto(16) : _Produto.pCom2 = drProduto(17)
                    _Produto.pPeso = drProduto(18) : _Produto.pProm = drProduto(19).ToString
                    _Produto.pReduz = drProduto(20) : _Produto.pVprom = drProduto(21)
                    _Produto.pQtdfisc = drProduto(22) : _Produto.pInventa = drProduto(23)
                    _Produto.pPcustom = drProduto(24) : _Produto.pPcustoa = drProduto(25)
                    _Produto.pPrepo = drProduto(26) : _Produto.pPcomp = drProduto(27)
                    _Produto.pTipo = drProduto(73) : _Produto.pGrade = drProduto(74).ToString

                    'Date
                    Try
                        _Produto.pDtcomp = Format(CDate(drProduto(28)), "dd/MM/yyyy")
                    Catch ex As Exception
                        _Produto.pDtcomp = Nothing
                    End Try
                    'Date
                    Try
                        _Produto.pDtvend = CDate(drProduto(29))
                    Catch ex As Exception
                        _Produto.pDtvend = Nothing
                    End Try


                    _Produto.pPvend15 = drProduto(30) : _Produto.pPvend30 = drProduto(31)
                    _Produto.pAgreg1 = drProduto(32) : _Produto.pAgreg2 = drProduto(33)
                    _Produto.pDeposito = drProduto(34) : _Produto.pEmpcre = drProduto(35)
                    _Produto.pEmpdeb = drProduto(36) : _Produto.pPromi = drProduto(37).ToString

                    'Date
                    Try
                        _Produto.pValid = CDate(drProduto(38))
                    Catch ex As Exception
                        _Produto.pValid = Nothing
                    End Try


                    _Produto.pStatus = drProduto(39).ToString
                    _Produto.pFixo = drProduto(40).ToString : _Produto.pPtran = drProduto(41)
                    _Produto.pIpi = drProduto(42) : _Produto.pLetra = drProduto(43).ToString
                    _Produto.pIcmsub = drProduto(44).ToString : _Produto.pPis = drProduto(45).ToString
                    _Produto.pIcms = drProduto(46) : _Produto.pFilial1 = drProduto(47)
                    _Produto.pFilial2 = drProduto(48) : _Produto.pBonif = drProduto(49)
                    _Produto.pNcm = drProduto(50).ToString : _Produto.pProdut2 = drProduto(51).ToString
                    _Produto.pPcstent = drProduto(52).ToString : _Produto.pPcstsai = drProduto(53).ToString
                    _Produto.pCcstent = drProduto(54).ToString : _Produto.pCcstsai = drProduto(55).ToString
                    _Produto.pPbcalc = drProduto(56).ToString : _Produto.pCdforte = drProduto(57).ToString
                    _Produto.pFortcof = drProduto(58).ToString : _Produto.pCdbarra = drProduto(59).ToString
                    _Produto.pEmbalag = drProduto(60).ToString : _Produto.pPesobruto = drProduto(61)
                    _Produto.pPesoliq = drProduto(62) : _Produto.pConsumo = drProduto(63).ToString

                    'Imagem
                    _Produto.pIdImagem = drProduto(90) : objImagem.pId = _Produto.pIdImagem

                    'Boolean
                    _Produto.pImobilizado = drProduto(64) : _Produto.pServico = drProduto(65)
                    _Produto.pInativo = drProduto(66) : _Produto.pMateriaprima = drProduto(67)

                    _Produto.pBalanca = drProduto(68).ToString : _Produto.pQtdxUnd = drProduto(69)
                    _Produto.pPauta = drProduto(70) : _Produto.pClasse = drProduto(71).ToString
                    mnomePart = drProduto(72).ToString


                    'Promoção...
                    Try
                        _Produto.pDtinicialpromocao = drProduto(75)
                    Catch ex As Exception
                        _Produto.pDtinicialpromocao = Nothing
                    End Try
                    Try
                        _Produto.pDtfinalpromocao = drProduto(76)
                    Catch ex As Exception
                        _Produto.pDtfinalpromocao = Nothing
                    End Try
                    Try
                        _Produto.pDtinicialbonific = drProduto(77)
                    Catch ex As Exception
                        _Produto.pDtinicialbonific = Nothing
                    End Try
                    Try
                        _Produto.pDtfinalbonific = drProduto(78)
                    Catch ex As Exception
                        _Produto.pDtfinalbonific = Nothing
                    End Try
                    _Produto.pBonificquantidade = drProduto(79) : _Produto.pBonificvalor = drProduto(80)

                    Try
                        _Produto.pQuotaPromocao = drProduto(81)
                    Catch ex As Exception
                    End Try
                    Try
                        _Produto.pQtdebonifcliente = drProduto(82)
                    Catch ex As Exception
                    End Try
                    _Produto.pOrigem = drProduto(83)
                    _Produto.pCstIpi = drProduto(84).ToString
                    _Produto.pPcstent = drProduto(85).ToString : _Produto.pPcstsai = drProduto(86).ToString
                    _Produto.pCcstent = drProduto(87).ToString : _Produto.pCcstsai = drProduto(88).ToString
                    _Produto.pProdut3 = drProduto(89).ToString



                    txt_codigo.Text = _Produto.pCodig
                    txt_codbarras.Text = _Produto.pCdbarra
                    txt_ncm.Text = _Produto.pNcm
                    txt_descricao.Text = _Produto.pProdut
                    txt_descrNfeP2.Text = _Produto.pProdut2
                    txt_descrAutomovelP3.Text = _Produto.pProdut3
                    txt_codPart.Text = _Produto.pCdport
                    txt_nomePart.Text = mnomePart
                    cbo_und.SelectedIndex = _clFuncoes.trazIndexCboUND(_Produto.pUnd, cbo_und)
                    txt_embalagem.Text = _Produto.pEmbalag
                    txt_clfiscal.Text = _Produto.pClf
                    cbo_CST.SelectedIndex = _clFuncoes.trazIndexCboCST(_Produto.pCst, cbo_CST)
                    cbo_CFV.SelectedIndex = _clFuncoes.trazIndexCboCFV(_Produto.pCfv, cbo_CFV)
                    txt_pcompra.Text = Format(_Produto.pPcomp, "###,##0.00")
                    txt_pcusto.Text = Format(_Produto.pPcusto, "###,##0.00")
                    txt_linha.Text = _Produto.pLinha
                    cbo_grupo.SelectedIndex = _clFuncoes.trazIndexCboGRUPO(_Produto.pGrupo, cbo_grupo)
                    cbo_tipo.SelectedIndex = _clFuncoes.trazIndexCboTipoProd(_Produto.pTipo, cbo_tipo)
                    txt_balanca.Text = _Produto.pBalanca
                    txt_promocao.Text = _Produto.pProm
                    txt_vlpromocao.Text = Format(_Produto.pVprom, "###,##0.00")
                    txt_reducao.Text = Format(_Produto.pReduz, "###,##0.00")
                    txt_pauta.Text = Format(_Produto.pPauta, "###,##0.00")
                    txt_pvenda.Text = Format(_Produto.pPvenda, "###,##0.00")
                    txt_sldfiscal.Text = Format(_Produto.pQtdfisc, "###,##0.00")
                    txt_saldo.Text = Format(_Produto.pQtde, "###,##0.00")
                    txt_QTDxUND.Text = Format(_Produto.pQtdxUnd, "###,##0.00")
                    txt_pesoBruto.Text = Format(_Produto.pPesobruto, "###,##0.00")
                    txt_pesoLiquido.Text = Format(_Produto.pPesoliq, "###,##0.00")
                    txt_com1.Text = Format(_Produto.pCom1, "###,##0.00")


                    Try
                        Me.Msk_dtcomp.Text = CDate(_Produto.pDtcomp.ToString("d"))

                        If IsDate(Me.Msk_dtcomp.Text) Then

                            Me.Msk_dtcomp.Text = Format(CDate(_Produto.pDtcomp), "ddMMyyyy")
                        Else
                            Me.Msk_dtcomp.Text = ""
                        End If
                    Catch ex As Exception
                        Me.Msk_dtcomp.Text = ""
                    End Try

                    Try
                        Me.msk_dtvenda.Text = CDate(_Produto.pDtvend.ToString("d"))

                        If IsDate(Me.msk_dtvenda.Text) Then

                            Me.msk_dtvenda.Text = Format(CDate(_Produto.pDtvend), "ddMMyyyy")
                        Else
                            Me.msk_dtvenda.Text = ""
                        End If

                    Catch ex As Exception
                        Me.msk_dtvenda.Text = ""
                    End Try

                    Try
                        Me.msk_dtValid.Text = CDate(_Produto.pValid.ToString("d"))

                        If IsDate(Me.msk_dtValid.Text) Then

                            Me.msk_dtValid.Text = Format(CDate(_Produto.pValid), "ddMMyyyy")
                        Else
                            Me.msk_dtValid.Text = ""
                        End If
                    Catch ex As Exception
                        Me.msk_dtValid.Text = ""
                    End Try

                    txt_ipi.Text = Format(_Produto.pIpi, "###,##0.00")

                    txt_classe.Text = _Produto.pClasse
                    txt_grade.Text = _Produto.pGrade
                    cbo_origem.SelectedIndex = _clFuncoes.trazIndexCboOrigem(_Produto.pOrigem, cbo_origem)
                    cbo_cstIpi.SelectedIndex = _clFuncoes.trazIndexComboBox(Trim(_Produto.pCstIpi), 2, cbo_cstIpi)
                    cbo_pisEntrada.SelectedIndex = _clFuncoes.trazIndexComboBox(Trim(_Produto.pPcstent), 2, cbo_pisEntrada)
                    cbo_pisSaida.SelectedIndex = _clFuncoes.trazIndexComboBox(Trim(_Produto.pPcstsai), 2, cbo_pisSaida)
                    cbo_cofinsEntrada.SelectedIndex = _clFuncoes.trazIndexComboBox(Trim(_Produto.pCcstent), 2, cbo_cofinsEntrada)
                    cbo_cofinsSaida.SelectedIndex = _clFuncoes.trazIndexComboBox(Trim(_Produto.pCcstsai), 2, cbo_cofinsSaida)



                    'Promoção...
                    msk_dtPromInicio.Text = Format(CDate(_Produto.pDtinicialpromocao), "ddMMyyyy")
                    If _Produto.pDtinicialpromocao = Nothing Then msk_dtPromInicio.Text = ""

                    msk_dtPromFim.Text = Format(CDate(_Produto.pDtfinalpromocao), "ddMMyyyy")
                    If _Produto.pDtfinalpromocao = Nothing Then msk_dtPromFim.Text = ""

                    txt_VlrQuota.Text = Format(_Produto.pQuotaPromocao, "###,##0.00")
                    chk_consumo.Checked = _Produto.pConsumo
                    chk_imobilizado.Checked = _Produto.pImobilizado
                    chk_servico.Checked = _Produto.pServico
                    chk_inativo.Checked = _Produto.pInativo
                    chk_matePrima.Checked = _Produto.pMateriaprima

                    'Bonificação...
                    msk_dtBonifInicio.Text = Format(CDate(_Produto.pDtinicialbonific), "ddMMyyyy")
                    If _Produto.pDtinicialbonific = Nothing Then msk_dtBonifInicio.Text = ""

                    msk_dtBonifFin.Text = Format(CDate(_Produto.pDtfinalbonific), "ddMMyyyy")
                    If _Produto.pDtfinalbonific = Nothing Then msk_dtBonifFin.Text = ""

                    rdb_bonifQuant.Checked = _Produto.pBonificquantidade
                    rdb_bonifVlr.Checked = _Produto.pBonificvalor
                    txt_qtdeBonificCliente.Text = _Produto.pQtdebonifcliente
                    If _Produto.pBonificquantidade Then txt_bonifQuant.Text = Format(_Produto.pBonif, "###,##0.00")
                    If _Produto.pBonificvalor Then txt_bonifVlr.Text = Format(_Produto.pBonif, "###,##0.00")
                    If _Produto.pBonificquantidade = False AndAlso _Produto.pBonificvalor = False Then
                        rdb_bonifNao.Checked = False
                    End If


                End While

                drProduto.Close() : oConnBDMETROSYS.ClearPool()
                preencheDtg_Saldos(codProduto)

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
            End Try

            CmdProduto.CommandText = ""
            SqlProduto.Remove(0, SqlProduto.ToString.Length)
            drProduto = Nothing

        End If

    End Sub

    Private Sub trazImagemProduto()

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        objImagem.pNome = _clFuncoes.trazNomeImagemProduto(objImagem.pId, MdlConexaoBD.conectionPadrao)
        objImagem.pImagem = "c:/wged/temp/" & objImagem.pNome
        Try
            sql.Append("SELECT lo_export(img_imagem, '" & objImagem.pImagem & "') FROM ")
            sql.Append(MdlEmpresaUsu._esqVinc & ".imagemprodutos WHERE img_id = " & objImagem.pId)
            cmd = New NpgsqlCommand(sql.ToString, oConn)
            dr = cmd.ExecuteReader

            While dr.Read
                pct_produto.Image = Image.FromFile(objImagem.pImagem)
                lbl_caminhoImagem.Text = objImagem.pImagem
            End While

            dr.Close() : oConn.ClearPool()
            oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        cmd.CommandText = ""
        sql.Remove(0, sql.ToString.Length)
        sql = Nothing : dr = Nothing : cmd = Nothing : oConn = Nothing

    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        executeF3()
    End Sub

    Private Sub txt_ipi_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ipi.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_ipi.Text.Equals("") Then Me.txt_ipi.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_ipi.Text) Then

            If CDec(Me.txt_ipi.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Valor IPI deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Valor IPI deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_ipi.Text = Format(CDec(Me.txt_ipi.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_ipi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ipi.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_pauta_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pauta.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_pauta.Text.Equals("") Then Me.txt_pauta.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pauta.Text) Then

            If CDec(Me.txt_pauta.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Valor da Pauta deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Valor da Pauta deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pauta.Text = Format(CDec(Me.txt_pauta.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_pauta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pauta.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_classe_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_classe.KeyPress
        'permite só letras
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub chk_matPrima_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_MPrima.CheckedChanged

        preencheDtg_Produto()

    End Sub

    Private Sub txt_pesoBruto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesoBruto.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_pesoBruto.Text.Equals("") Then Me.txt_pesoBruto.Text = Format(0.0, "###,##0.000")
        If IsNumeric(Me.txt_pesoBruto.Text) Then

            If CDec(Me.txt_pesoBruto.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Valor do Peso Bruto deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Valor do Peso Bruto deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pesoBruto.Text = Format(CDec(Me.txt_pesoBruto.Text), "###,##0.000")

        End If


    End Sub

    Private Sub txt_pesoBruto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pesoBruto.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_pesoLiquido_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesoLiquido.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_pesoLiquido.Text.Equals("") Then Me.txt_pesoLiquido.Text = Format(0.0, "###,##0.000")
        If IsNumeric(Me.txt_pesoLiquido.Text) Then

            If CDec(Me.txt_pesoLiquido.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Valor do Peso Liquido deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Valor do Peso Liquido deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pesoLiquido.Text = Format(CDec(Me.txt_pesoLiquido.Text), "###,##0.000")

        End If


    End Sub

    Private Sub txt_pesoLiquido_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pesoLiquido.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_com1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_com1.Leave, txt_minimo.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_com1.Text.Equals("") Then Me.txt_com1.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_com1.Text) Then

            If CDec(Me.txt_com1.Text) < _valorZERO Then

                lbl_mensagem01.Text = "Valor de Comissão deve ser maior ou igual a ZERO !"
                lbl_mensagem02.Text = "Valor do Comissão deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_com1.Text = Format(CDec(Me.txt_com1.Text), "###,##0.00")

        End If


    End Sub

    Private Sub txt_com1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_com1.KeyPress, txt_minimo.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub cbo_CST_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_CST.SelectedIndexChanged

        Try

            Select Case Mid(cbo_CST.SelectedItem, 1, 2)
                Case "00", "10", "20", "70"
                    cbo_CFV.SelectedIndex = 0
                Case "30", "40", "41", "51", "60"
                    cbo_CFV.SelectedIndex = -1
            End Select
        Catch ex As Exception
        End Try

        If cbo_CST.SelectedIndex = 2 Then

            Me.txt_reducao.Text = "0,00" : Me.txt_reducao.ReadOnly = False

        Else
            Me.txt_reducao.Text = "0,00" : Me.txt_reducao.ReadOnly = True
        End If


    End Sub

#Region "   * * Muda as cores dos controles * *  "

    Private Sub txt_codbarras_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codbarras.GotFocus
        Me.txt_codbarras.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_codbarras_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codbarras.LostFocus
        Me.txt_codbarras.BackColor = Color.White
    End Sub

    Private Sub txt_ncm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ncm.GotFocus
        Me.txt_ncm.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_ncm_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ncm.LostFocus
        Me.txt_ncm.BackColor = Color.White
    End Sub

    Private Sub txt_descricao_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descricao.GotFocus
        Me.txt_descricao.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_descricao_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descricao.LostFocus, txt_descrAutomovelP3.LostFocus
        Me.txt_descricao.BackColor = Color.White
    End Sub

    Private Sub txt_descrAutomovelP3_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descrAutomovelP3.GotFocus
        Me.txt_descrAutomovelP3.BackColor = Color.AliceBlue
    End Sub

    Private Sub ttxt_descrAutomovelP3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descrAutomovelP3.LostFocus
        Me.txt_descrAutomovelP3.BackColor = Color.White
    End Sub

    Private Sub txt_produt2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descrNfeP2.GotFocus
        Me.txt_descrNfeP2.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_produt2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descrNfeP2.LostFocus
        Me.txt_descrNfeP2.BackColor = Color.White
    End Sub

    Private Sub txt_codPart_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codPart.GotFocus
        Me.txt_codPart.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_codPart_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codPart.LostFocus
        Me.txt_codPart.BackColor = Color.White
    End Sub

    Private Sub txt_embalagem_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_embalagem.GotFocus
        Me.txt_embalagem.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_embalagem_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_embalagem.LostFocus
        Me.txt_embalagem.BackColor = Color.White
    End Sub

    Private Sub txt_clfiscal_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_clfiscal.GotFocus
        Me.txt_clfiscal.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_clfiscal_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_clfiscal.LostFocus
        Me.txt_clfiscal.BackColor = Color.White
    End Sub

    Private Sub txt_pcompra_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pcompra.GotFocus
        If _incluindo Then Me.txt_pcompra.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_pcompra_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pcompra.LostFocus
        If _incluindo Then Me.txt_pcompra.BackColor = Color.White
    End Sub

    Private Sub txt_pcusto_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pcusto.GotFocus
        If _incluindo Then Me.txt_pcusto.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_pcusto_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pcusto.LostFocus
        If _incluindo Then Me.txt_pcusto.BackColor = Color.White
    End Sub

    Private Sub txt_linha_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_linha.GotFocus
        Me.txt_linha.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_linha_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_linha.LostFocus
        Me.txt_linha.BackColor = Color.White
    End Sub

    Private Sub txt_balanca_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_balanca.GotFocus
        Me.txt_balanca.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_balanca_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_balanca.LostFocus
        Me.txt_balanca.BackColor = Color.White
    End Sub

    Private Sub txt_promocao_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_promocao.GotFocus
        Me.txt_promocao.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_promocao_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_promocao.LostFocus
        Me.txt_promocao.BackColor = Color.White
    End Sub

    Private Sub txt_vlpromocao_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlpromocao.GotFocus
        Me.txt_vlpromocao.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_vlpromocao_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlpromocao.LostFocus
        Me.txt_vlpromocao.BackColor = Color.White
    End Sub

    Private Sub txt_reducao_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_reducao.GotFocus
        Me.txt_reducao.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_reducao_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_reducao.LostFocus
        Me.txt_reducao.BackColor = Color.White
    End Sub

    Private Sub txt_pauta_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pauta.GotFocus
        Me.txt_pauta.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_pauta_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pauta.LostFocus
        Me.txt_pauta.BackColor = Color.White
    End Sub

    Private Sub txt_pvenda_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pvenda.GotFocus
        If _incluindo Then Me.txt_pvenda.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_pvenda_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pvenda.LostFocus
        If _incluindo Then Me.txt_pvenda.BackColor = Color.White
    End Sub

    Private Sub txt_sldfiscal_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_sldfiscal.GotFocus
        If _incluindo Then Me.txt_sldfiscal.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_sldfiscal_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_sldfiscal.LostFocus
        If _incluindo Then Me.txt_sldfiscal.BackColor = Color.White
    End Sub

    Private Sub txt_saldo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_saldo.GotFocus
        If _incluindo Then Me.txt_saldo.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_saldo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_saldo.LostFocus
        If _incluindo Then Me.txt_saldo.BackColor = Color.White
    End Sub

    Private Sub txt_QTDxUND_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_QTDxUND.GotFocus
        Me.txt_QTDxUND.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_QTDxUND_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_QTDxUND.LostFocus
        Me.txt_QTDxUND.BackColor = Color.White
    End Sub

    Private Sub txt_ipi_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ipi.GotFocus
        Me.txt_ipi.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_ipi_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ipi.LostFocus
        Me.txt_ipi.BackColor = Color.White
    End Sub

    Private Sub txt_classe_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_classe.GotFocus
        Me.txt_classe.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_classe_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_classe.LostFocus
        Me.txt_classe.BackColor = Color.White
    End Sub

    Private Sub txt_minimo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_minimo.GotFocus
        Me.txt_minimo.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_minimo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_minimo.LostFocus
        Me.txt_minimo.BackColor = Color.White
    End Sub

    Private Sub msk_dtValid_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtValid.GotFocus
        If _incluindo Then Me.msk_dtValid.BackColor = Color.AliceBlue
    End Sub

    Private Sub msk_dtValid_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtValid.LostFocus
        If _incluindo Then Me.msk_dtValid.BackColor = Color.White
    End Sub

    Private Sub txt_pesoBruto_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesoBruto.GotFocus
        If _incluindo Then Me.txt_pesoBruto.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_pesoBruto_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesoBruto.LostFocus
        If _incluindo Then Me.txt_pesoBruto.BackColor = Color.White
    End Sub

    Private Sub txt_pesoLiquido_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesoLiquido.GotFocus
        If _incluindo Then Me.txt_pesoLiquido.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_pesoLiquido_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesoLiquido.LostFocus
        If _incluindo Then Me.txt_pesoLiquido.BackColor = Color.White
    End Sub

    Private Sub txt_com1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_com1.GotFocus, txt_minimo.GotFocus
        Me.txt_com1.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_com1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_com1.LostFocus, txt_minimo.LostFocus
        Me.txt_com1.BackColor = Color.White
    End Sub

    Private Sub msk_dtPromInicio_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtPromInicio.GotFocus
        Me.msk_dtPromInicio.BackColor = Color.AliceBlue
    End Sub

    Private Sub msk_dtPromInicio_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtPromInicio.LostFocus
        Me.msk_dtPromInicio.BackColor = Color.White
    End Sub

    Private Sub msk_dtPromFim_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtPromFim.GotFocus
        Me.msk_dtPromFim.BackColor = Color.AliceBlue
    End Sub

    Private Sub msk_dtPromFim_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtPromFim.LostFocus
        Me.msk_dtPromFim.BackColor = Color.White
    End Sub

    Private Sub txt_quota_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_VlrQuota.GotFocus
        Me.txt_VlrQuota.BackColor = Color.AliceBlue
    End Sub

    Private Sub txt_quota_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_VlrQuota.LostFocus
        Me.txt_VlrQuota.BackColor = Color.White
    End Sub

    Private Sub msk_dtBonifInicio_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtBonifInicio.GotFocus
        Me.msk_dtBonifInicio.BackColor = Color.AliceBlue
    End Sub

    Private Sub msk_dtBonifInicio_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtBonifInicio.LostFocus
        Me.msk_dtBonifInicio.BackColor = Color.White
    End Sub

    Private Sub msk_dtBonifFin_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtBonifFin.GotFocus
        Me.msk_dtBonifFin.BackColor = Color.AliceBlue
    End Sub

    Private Sub msk_dtBonifFin_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtBonifFin.LostFocus
        Me.msk_dtBonifFin.BackColor = Color.White
    End Sub

#End Region

    Private Sub cbo_CFV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_CFV.SelectedIndexChanged

        Try

            Select Case Mid(cbo_CST.SelectedItem, 1, 2)
                Case "00", "10", "20", "70"
                    cbo_CFV.SelectedIndex = 0
                Case "30", "40", "41", "51", "60"
                    If cbo_CFV.SelectedIndex = 0 Then cbo_CFV.SelectedIndex = -1
            End Select
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dtg_produto_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_produto.CellContentClick
        linhaAtual = Convert.ToInt32(e.RowIndex.ToString())
        mcell = Me.dtg_produto.CurrentRow.Cells(0).Value.ToString()
        Me.btn_excluir.Enabled = True
    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click
        If linhaAtual <> -1 Then
            If MessageBox.Show("Deseja Efetuar a Exclusao Selecionada ? ", " Exclusao de Item  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                _clBD.exc_estoquecad(mcell, oConnBDMETROSYS)
                _clBD.exc_estoqueloja(mcell, oConnBDMETROSYS)
                lbl_mensagem01.Text = "produto Excluido c/ Sucesso !"
                lbl_mensagem02.Text = "produto Excluido c/ Sucesso !"
            End If
        End If
    End Sub

    Private Sub txt_qtdeBonificCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtdeBonificCliente.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_qtdeBonificCliente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtdeBonificCliente.Leave

        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""

        If Me.txt_qtdeBonificCliente.Text.Equals("") Then Me.txt_qtdeBonificCliente.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_qtdeBonificCliente.Text) = False Then
            Me.txt_qtdeBonificCliente.Text = "0"
        End If

    End Sub

    Private Sub msk_dtPromInicio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtPromInicio.Leave


        If IsDate(msk_dtPromInicio.Text) AndAlso IsDate(msk_dtPromFim.Text) Then

            If CDate(msk_dtPromInicio.Text) > CDate(msk_dtPromFim.Text) Then

                MsgBox("Data Inical da Promoção deve ser IGUAL ou MENOR que a Data Final", MsgBoxStyle.Exclamation)
                msk_dtPromInicio.Focus() : msk_dtPromInicio.SelectAll()
                Return
            End If
            txt_VlrQuota.ReadOnly = False
        Else
            txt_VlrQuota.ReadOnly = True : txt_VlrQuota.Text = "0,00"
        End If

    End Sub

    Private Sub msk_dtPromFim_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtPromFim.Leave


        If IsDate(msk_dtPromInicio.Text) AndAlso IsDate(msk_dtPromFim.Text) Then

            If CDate(msk_dtPromFim.Text) < CDate(msk_dtPromInicio.Text) Then

                MsgBox("Data Final da Promoção deve ser IGUAL ou MAIOR que a Data Inicial", MsgBoxStyle.Exclamation)
                msk_dtPromFim.Focus() : msk_dtPromFim.SelectAll()
                Return
            End If
            txt_VlrQuota.ReadOnly = False
        Else
            txt_VlrQuota.ReadOnly = True : txt_VlrQuota.Text = "0,00"
        End If

    End Sub

    Private Sub dtg_BuscaPisCofins_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtg_BuscaPisCofins.KeyDown

        Try
            If e.KeyCode = Keys.F7 Then Me.btn_GravaPis.Enabled = True
            If e.KeyCode = Keys.Down Then

                If Me.dtg_BuscaPisCofins.CurrentRow.IsNewRow = False Then

                    If Me.dtg_BuscaPisCofins.CurrentRow.Index = (Me.dtg_BuscaPisCofins.RowCount - 1) Then

                        If Me.btn_GravaPis.Enabled = False Then
                            Me.dtg_BuscaPisCofins.Rows.Add("Nova Linha", "", "", "", "", "")
                            Me.btn_GravaPis.Enabled = True
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub txt_descrAutomovelP3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descrAutomovelP3.TextChanged

        If Trim(txt_descrAutomovelP3.Text).Equals("") Then
            Me.txt_descrNfeP2.Text = "" : Me.txt_descrNfeP2.ReadOnly = False
        Else
            Me.txt_descrNfeP2.Text = "" : Me.txt_descrNfeP2.ReadOnly = True
        End If

    End Sub


    Private Sub txt_descrNfeP2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descrNfeP2.TextChanged

        If Trim(txt_descrNfeP2.Text).Equals("") Then
            Me.txt_descrAutomovelP3.Text = "" : Me.txt_descrAutomovelP3.ReadOnly = False
        Else
            Me.txt_descrAutomovelP3.Text = "" : Me.txt_descrAutomovelP3.ReadOnly = True
        End If

    End Sub

    Private Sub btn_importaImagem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_importaImagem.Click
        AbreArquivoImagem()

        If Trim(lbl_caminhoImagem.Text).Equals("") = False Then

            Try
                pct_produto.Image = Image.FromFile(lbl_caminhoImagem.Text)
            Catch ex As Exception
            End Try

        End If
    End Sub

    Private Sub AbreArquivoImagem()

        Try
            OpenFileImagem.Filter = "PNG (*.png)|*.png|JPEG (*.jpg; *.jpeg; *.jpe)|*.jpg; *.jpeg; *.jpe|GIF (*.gif)|*.gif"
            OpenFileImagem.ShowDialog()
            If OpenFileImagem.FileName <> "" Then Me.lbl_caminhoImagem.Text = OpenFileImagem.FileName
        Catch ex As Exception
            Me.lbl_caminhoImagem.Text = ""
        End Try

    End Sub

    Private Sub apagaImagem()

        If objImagem.pId > 0 Then

            Try
                drProduto = Nothing
                CmdProduto = Nothing
                oConnBDMETROSYS.ClearPool()
            Catch ex As Exception
            End Try

            Try
                System.IO.File.Delete(objImagem.pImagem)
            Catch ex As Exception

            End Try
        End If

    End Sub

End Class