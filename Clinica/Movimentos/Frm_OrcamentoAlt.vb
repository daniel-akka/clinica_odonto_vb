Imports Npgsql
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Math
Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog

Public Class Frm_OrcamentoAlt


    Private Const _valorZERO As Integer = 0
    Dim xcont As Integer = 0
    Dim _clBD As New Cl_bdMetrosys
    Dim _clFuncoes As New ClFuncoes
    Public _servico As New Cl_Servico
    Dim _cadp001 As New Cl_Cadp001
    Dim _formBusca As Boolean = False
    Dim _numOrcamentoAtual As Int64 = 0
    Dim _numPedidoOK As Boolean = False
    Dim mNumPedido As String = "", _numPedidoTemp As String = ""
    Public _mPesquisaForn As Boolean = False 'Serve para configura os campos CodFornec e NomeFornec
    Public Shared _frmREf As New Frm_OrcamentoAlt
    Dim _BuscaForn As New Frm_ClienteFornResp
    Dim _BuscaProd As New Frm_ServicoResp
    Dim _FrmGeraOrcamento As New Frm_GeraOrcamento
    Dim _mConsulta As New StringBuilder
    Dim _editandoProduto As Boolean = False

    'Objetos auxiliares para editar o produto...
    Private _qtdeAnteriorProd As Double
    Private _codProdEditando As String = ""
    Private _indexProdEditando As Integer
    Private _aliqDescProdEditado, _vlrProdEditado, _vlDescProdEditado As Double

    'OBJETOS AUXILIAR DO CLIENTE...
    Public mbUf, mbCNPJ, mbCPF, mCodPart, mNomePart, mEnderecoPart, mCidadePart, mCepPart As String
    Public mFonePart, mConsumo As String
    Public mIsento As Boolean

    ' OBJETOS AUXILIAR DO PRODUTO...
    Public codProd_Ref, nomeProd_Ref, UndProd_Ref, codBarraProd_Ref, local_ref As String
    Public ClfProd_Ref, FilialProd_Ref, cdBarraProd_Ref, gradeProd_Ref As String
    Public CstProd_Ref, CfvProd_Ref, GrupoProd_Ref, ReduzProd_Ref, LinhaProd_Ref As Integer
    Public pesoLiqProd_Ref, pesoBrutoProd_Ref, ValorUnitProd_Ref, qtdeProd_Ref As Double
    Public dtInicialPromocao_Ref, dtFinalPromocao_Ref As Date
    Public vlPromocao_Ref As Double

    'OBJETOS AUXILIAR DA GRADE...
    Public codCorGrade_Ref, nomeCorGrade_Ref, tamanhoGrade_Ref As String

    'objetos para impressão...
    Dim MostrarCaixaImpressoras As Boolean = False
    Dim _StringToPrint As String = "", _stringToPrintAux As String = ""
    Private _PrintFont As New Font("Lucida Console", 8) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _sImpressao As StreamWriter
    Private _leitorTabelaImprimir As NpgsqlDataReader

    'Objetos para salvar o pedido...
    Dim _arqNumPedido As String = "\wged\numpedido.TXT"
    Dim _fsnumpedido As FileStream
    Dim _snumpedido As StreamWriter

    'Objetos para tratar o Gerente...
    Dim _vlrMaxDesconto As Double = 0.0
    Dim _nomeGerente As String = ""

    'Objetos para tratar o vendedor...
    Dim _descVendedor As Double = 0.0

    Dim _consumo As String = "S"

    Private Sub Frm_Orcamento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F6
                executaRelatorioOrcamento("", "\wged\relatorios\orcamento.txt")
        End Select

    End Sub

    Private Sub Frm_Orcamento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Orcamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        lbl_NomeSys.Text = Application.ProductName
        Me.txt_valor.Text = "0,00" : txt_qtde.Text = "1,00"
        Me.txt_operador.Text = MdlUsuarioLogando._usuarioNome
        cbo_local = _clFuncoes.PreenchComboLoja2Dig(cbo_local, MdlConexaoBD.conectionPadrao)
        Me.cbo_local.SelectedIndex = _clFuncoes.trazIndexCboLoja2dig(Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2), cbo_local)

        If MdlUsuarioLogando._usuarioPrivilegio = True Then Me.cbo_local.Enabled = True


        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos.BeginPrint, AddressOf InicializaRelatorio

        'Me.txt_orcamento.Text = "00000003" : _numOrcamentoAtual = 3
        _numPedidoOK = True
        _numPedidoTemp = _FrmGeraOrcamento._frmRefGeraOrcamento._numOrcamentoTemp
        _numOrcamentoAtual = Convert.ToInt64(_FrmGeraOrcamento._frmRefGeraOrcamento._numOrcamento)
        preenchCamposRegistroPedido(_FrmGeraOrcamento._frmRefGeraOrcamento._numOrcamento)
        preenchItensPedido(_FrmGeraOrcamento._frmRefGeraOrcamento._numOrcamento)

    End Sub

    Private Sub preenchCamposRegistroPedido(ByVal numOrcamento As String)

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection = Nothing : Return

        End Try

        Dim cmdPedido As New NpgsqlCommand
        Dim sqlPedido As New StringBuilder
        Dim drPedido As NpgsqlDataReader

        Dim condicao As String = ""


        Try

            sqlPedido.Append("SELECT nt_orca, nt_geno, nt_codig, nt_dtemis, nt_dtsai, nt_emiss, nt_cfop, ") '6
            sqlPedido.Append("nt_vend, nt_cid, nt_itens, nt_rota, nt_peso, nt_x, nt_y, nt_parc, nt_cod1, ") '15
            sqlPedido.Append("nt_cod2, nt_volum, nt_tipo2, nt_auto, nt_auto2, nt_cod3, nt_cod4, nt_cod5, ") '23
            sqlPedido.Append("nt_cod6, nt_cod7, nt_mapa, nt_sit, nt_id ") '29
            sqlPedido.Append("FROM " & MdlEmpresaUsu._esqEstab & ".tb_orca1 WHERE nt_orca = @nt_orca") '25

            cmdPedido = New NpgsqlCommand(sqlPedido.ToString, conection)
            cmdPedido.Parameters.Add("@nt_orca", numOrcamento)
            drPedido = cmdPedido.ExecuteReader

            While drPedido.Read

                Me.txt_orcamento.Text = drPedido(0).ToString
                cbo_local.SelectedIndex = _clFuncoes.trazIndexCboLoja2dig(Mid(drPedido(1).ToString, _
                                          drPedido(1).ToString.Length - 1, 2), cbo_local)
                dtp_emissao.Value = drPedido(3) : txt_codpart.Text = drPedido(2).ToString
                _clFuncoes.trazCadp001(drPedido(2).ToString, _cadp001)
                Me.txt_operador.Text = drPedido(19).ToString


                Me.cbo_local.Enabled = False
            End While

            conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        cmdPedido.CommandText = "" : sqlPedido.Remove(0, sqlPedido.ToString.Length)
        conection = Nothing : cmdPedido = Nothing
        drPedido = Nothing : sqlPedido = Nothing



    End Sub

    Private Sub preenchItensPedido(ByVal numPedido As String)


        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection = Nothing : Return

        End Try

        Dim cmdPedido As New NpgsqlCommand
        Dim sqlPedido As New StringBuilder
        Dim drPedido As NpgsqlDataReader
        Dim grade As String = ""


        Try

            sqlPedido.Append("SELECT no_id, no_codpr, s_descricao, no_prunit, no_qtde, no_prtot FROM " & MdlEmpresaUsu._esqEstab & ".tb_orca2 LEFT JOIN ")
            sqlPedido.Append("servico ON TEXT(s_id) = no_codpr WHERE no_orca = @no_orca")

            cmdPedido = New NpgsqlCommand(sqlPedido.ToString, conection)
            cmdPedido.Parameters.Add("@no_orca", numPedido)
            drPedido = cmdPedido.ExecuteReader

            While drPedido.Read


                Dim mlinha As String() = {drPedido(0), Mid(Me.cbo_local.SelectedItem, 1, 2), drPedido(1), drPedido(2), Format(drPedido(3), "###,##0.00"), _
                                          Format(drPedido(4), "###,##0.00"), Format(drPedido(5), "###,##0.00")}


                'Adicionando Linha
                Me.dtg_pedidoServico.Rows.Add(mlinha)
                Me.dtg_pedidoServico.Refresh()

                mlinha = Nothing
                Me.txt_total.Text = Format(somaVlrTotalItensGrid, "###,##0.00")
            End While

            drPedido.Close()
            conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        cmdPedido.CommandText = "" : sqlPedido.Remove(0, sqlPedido.ToString.Length)
        conection = Nothing : cmdPedido = Nothing
        drPedido = Nothing : sqlPedido = Nothing



    End Sub

    Private Sub txt_codPart_KeyDownExtracted()

        _formBusca = True : _mPesquisaForn = False : _frmREf = Me
        _BuscaForn.set_frmRef(Me)
        _BuscaForn.ShowDialog(Me)
        _formBusca = False
        If Me.txt_codpart.Text.Equals("") Then Me.txt_codpart.Focus() : Return

        Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()

        _clFuncoes.trazCadp001(Me.txt_codpart.Text, _cadp001)
    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codpart.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then


            If Me.txt_codpart.Text.Equals("") Then


                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    txt_codPart_KeyDownExtracted()

                Catch ex As Exception
                End Try

            Else  ' Consulta pelo codigo do cliente...


                If (Me.txt_codpart.TextLength > 5) AndAlso (e.KeyCode = Keys.Enter) Then 'Se retornar nada

                    If _clFuncoes.trazCadp001(Me.txt_codpart.Text, _cadp001) Then

                        Dim lShouldReturn As Boolean
                        Me.txt_nomePart.Focus()
                        Me.txt_nomePart.SelectAll()
                        If lShouldReturn Then Return
                        lShouldReturn = Nothing

                    Else


                        'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                        Try
                            txt_codPart_KeyDownExtracted()

                        Catch ex As Exception
                        End Try

                    End If
                End If

            End If
        End If



    End Sub

    Private Sub txt_valor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valor.KeyPress

        'permite só numeros com vírgula
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub


    Sub txt_codprod_keydownExtracted()


        _formBusca = True
        local_ref = Mid(cbo_local.SelectedItem, 1, 2)
        _frmREf = Me
        _BuscaProd.set_frmRef(Me)
        _BuscaProd.ShowDialog(Me)
        _formBusca = False

        If MdlEmpresaUsu._codProd Then

            Me.txt_codProd.Text = _servico.pIdServico
        Else
            Me.txt_codProd.Text = _servico.pIdServico
        End If


        Me.txt_nomeProd.Text = _servico.pDescricao
        Me.txt_valor.Text = Format(_servico.pValor, "###,##0.00")


        If Me.txt_codProd.Text.Equals("") Then

            Me.txt_codProd.Focus() : Return
        Else
            Me.txt_nomeProd.Focus()
        End If


        _clFuncoes.trazServicoSelecionado(Trim(Me.txt_codProd.Text), _servico)

    End Sub

    Private Sub txt_codprod_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codProd.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

            If Me.txt_codProd.Text.Equals("") Then

                'Aqui tenta chamar a Busca do Produto...
                Try

                    txt_codprod_keydownExtracted()
                Catch ex As Exception
                End Try

            Else

                If _editandoProduto = False Then

                    If _clFuncoes.trazServicoSelecionado(Trim(Me.txt_codProd.Text), _servico) = False Then
                        'Aqui tenta chamar a Busca do Produto...
                        Try
                            txt_codprod_keydownExtracted()
                        Catch ex As Exception
                        End Try

                    Else

                        txt_codprod_keydownExtracted()
                    End If
                End If


            End If
        End If


    End Sub

    Private Function verificaRegistroPedido() As Boolean

        lbl_mensagem.Text = ""

        'Verifica se foi selecionado alguma Loja...
        If cbo_local.SelectedIndex < _valorZERO Then

            lbl_mensagem.Text = "Selecione uma LOJA !" : cbo_local.Focus() : Return False

        End If

        'Verifica se foi informado alguma Data para o Pedido...
        If Not IsDate(dtp_emissao.Text) Then

            lbl_mensagem.Text = "Informe alguma DATA para o Pedido !" : dtp_emissao.Focus() : Return False

        End If

        'Verifica se foi informado algum Cliente...
        If Trim(Me.txt_codpart.Text).Equals("") AndAlso Trim(Me.txt_nomePart.Text).Equals("") Then

            lbl_mensagem.Text = "Informe um CLIENTE para o Pedido !" : dtp_emissao.Focus() : Return False

        End If


        If Me.dtg_pedidoServico.Rows.Count <= _valorZERO Then

            lbl_mensagem.Text = "Informe algum Serviço por favor !" : Return False

        End If



        Return True
    End Function

    Private Function verificaProduto() As Boolean

        lbl_mensagem.Text = ""

        If Trim(Me.txt_codProd.Text).Equals("") Then

            lbl_mensagem.Text = "Serviço não informado !" : Me.txt_codProd.Focus() : Return False

        End If

        If IsNumeric(Me.txt_valor.Text) Then

            If CDbl(Me.txt_valor.Text) = _valorZERO Then

                lbl_mensagem.Text = "Valor do Serviço deve ser MAIOR que ZERO !"
                Me.txt_valor.Focus() : Return False

            End If
        Else

            lbl_mensagem.Text = "Valor inválido para o Serviço !"
            Me.txt_valor.Focus() : Return False

        End If


        Return True
    End Function

    Private Sub addItemEditadoGrid()

        Try

            Dim mlinha As String() = {_valorZERO, Mid(Me.cbo_local.SelectedItem, 1, 2), txt_codProd.Text, txt_nomeProd.Text, _
                                      Format(CDbl(txt_valor.Text), "###,##0.00"), Format(CDbl(txt_qtde.Text), "###,##0.00"), _
                                      Format(Round(CDbl(txt_valor.Text) * CDbl(txt_qtde.Text), 2), "###,##0.00")}

            'Adicionando Linha
            Me.dtg_pedidoServico.Rows(_indexProdEditando).SetValues(mlinha)
            Me.dtg_pedidoServico.Refresh()

            Me.txt_total.Text = Format(somaVlrTotalItensGrid, "###,##0.00")

            _codProdEditando = "" : _indexProdEditando = -1 : mlinha = Nothing
        Catch ex As Exception

            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try



    End Sub

    Sub TrazNumOrcamento()

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return
        End Try

        transacao = conexao.BeginTransaction

        'Numero do orçamento...
        _numOrcamentoAtual = _clBD.trazProxNumOrcamento(conexao)
        Me.txt_orcamento.Text = String.Format("{0:D8}", _numOrcamentoAtual)
        transacao.Commit() : conexao.ClearAllPools() : conexao.Close() : conexao = Nothing
        _numPedidoOK = True

    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        If verificaProduto() Then


            If _codProdEditando.Equals("") Then

                If colunaDuplicada(Me.txt_codProd.Text) = False Then

                    addItemGrid()

                    If _numPedidoOK = False Then

                        TrazNumOrcamento()

                    End If
                End If

            Else

                addItemEditadoGrid()
            End If

            local_ref = Mid(Me.cbo_local.SelectedItem, 1, 2) : FilialProd_Ref = Mid(Me.cbo_local.SelectedItem, 1, 2)
            Me.txt_codProd.Text = "" : Me.txt_valor.Text = "0,00"
            xcont = xcont + 1 : Me.txt_codProd.Focus() : _qtdeAnteriorProd = _valorZERO

            If Me.dtg_pedidoServico.Rows.Count > _valorZERO Then

                limpaCamposRegistroProd()
            End If
        End If



    End Sub

    Private Sub limpaCamposRegistroProd()

        Me.cbo_local.Enabled = False
        If MdlUsuarioLogando._usuarioPrivilegio = True Then Me.cbo_local.Enabled = True
        'Me.cbo_vendedor.Enabled = False
        Me.txt_nomeProd.Text = ""
    End Sub

    Private Sub addItemGrid()
        Try

            Dim mlinha As String() = {_valorZERO, Mid(Me.cbo_local.SelectedItem, 1, 2), txt_codProd.Text, txt_nomeProd.Text, _
                                      Format(CDbl(txt_valor.Text), "###,##0.00"), Format(CDbl(txt_qtde.Text), "###,##0.00"), _
                                      Format(Round(CDbl(txt_valor.Text) * CDbl(txt_qtde.Text), 2), "###,##0.00")}

            'Adicionando Linha
            Me.dtg_pedidoServico.Rows.Add(mlinha)
            Me.dtg_pedidoServico.Refresh()

            Me.txt_total.Text = Format(somaVlrTotalItensGrid, "###,##0.00")

            _codProdEditando = "" : _indexProdEditando = -1 : mlinha = Nothing
        Catch ex As Exception

            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

    End Sub

    Private Sub zeraTudo()
        dtp_emissao.Value = Date.Now 'cbo_local.SelectedIndex = -1 : 

        'Zera dados cliente...
        Me.txt_codpart.Text = "" : Me.txt_nomePart.Text = ""
        mbCNPJ = "" : mbCPF = "" : mbUf = "" : mNomePart = ""
        mCodPart = "" : mCepPart = "" : mCidadePart = ""
        mEnderecoPart = ""
        Me.txt_total.Text = "0,00"

        'Zera dados produto...
        Me.txt_codProd.Text = "" : Me.txt_nomeProd.Text = ""
        Me.txt_valor.Text = "0,00"

        codProd_Ref = "" : nomeProd_Ref = "" : UndProd_Ref = ""
        codBarraProd_Ref = "" : local_ref = "" : ClfProd_Ref = ""
        FilialProd_Ref = "" : cdBarraProd_Ref = "" : CstProd_Ref = _valorZERO
        CfvProd_Ref = _valorZERO : GrupoProd_Ref = _valorZERO
        ReduzProd_Ref = _valorZERO : LinhaProd_Ref = _valorZERO
        pesoLiqProd_Ref = _valorZERO : pesoBrutoProd_Ref = _valorZERO
        ValorUnitProd_Ref = _valorZERO : qtdeProd_Ref = _valorZERO

        Me.dtg_pedidoServico.Rows.Clear() : Me.dtg_pedidoServico.Refresh()
        lbl_mensagem.Text = "" : _qtdeAnteriorProd = _valorZERO : _codProdEditando = ""
        _indexProdEditando = _valorZERO


    End Sub

    Private Function colunaDuplicada(ByVal codProduto As String) As Boolean

        lbl_mensagem.Text = ""
        'Verifica se Produto já existe no Grid...
        For Each row As DataGridViewRow In Me.dtg_pedidoServico.Rows

            If Not row.IsNewRow Then
                If row.Cells(2).Value.Equals(codProduto) Then

                    lbl_mensagem.Text = "Produto já exite no Pedido !"
                    Return True

                End If
            End If
        Next

        Return False
    End Function

    Private Sub txt_valor_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valor.Leave

        lbl_mensagem.Text = ""
        If Me.txt_valor.Text.Equals("") Then Me.txt_valor.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valor.Text) Then
            If CDec(Me.txt_valor.Text) <= _valorZERO Then
                lbl_mensagem.Text = "Valor deve ser maior que ZERO !"
                Return

            End If
            Me.txt_valor.Text = Format(CDec(Me.txt_valor.Text), "###,##0.00")

        End If



    End Sub

    Private Sub alteraRegistroOrcamento(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim nt_orca, nt_geno, nt_codig, nt_cfop, nt_vend, nt_cid, nt_x, nt_y As String
        Dim nt_tipo2, nt_auto, nt_auto2 As String
        Dim nt_dtemis, nt_dtsai As Date
        Dim nt_emiss As Boolean = False
        Dim itens, nt_rota, nt_parc, nt_cod1, nt_cod2, nt_cod3, nt_cod4, nt_cod5 As Integer
        Dim nt_cod6, nt_cod7, nt_mapa, nt_sit, mProxNumPedido, nt_itens As Integer
        Dim nt_peso, nt_volum As Double

        nt_geno = MdlUsuarioLogando._local
        nt_codig = _cadp001.pCod
        nt_dtemis = dtp_emissao.Value
        nt_dtsai = nt_dtemis
        nt_emiss = False
        nt_cfop = "5102"
        nt_cid = mCidadePart
        nt_itens = Me.dtg_pedidoServico.Rows.Count

        nt_x = "" : nt_y = ""

        nt_volum = 0
        nt_auto = MdlUsuarioLogando._usuarioLogin
        nt_auto2 = ""
        nt_mapa = _valorZERO

        'nt_sit -- Verifica status do Pedido 1-Digitado , 2-Impresso, 3 - ECF , 4-NFe
        nt_sit = 1

        ''Numero do orcamento...
        nt_orca = Me.txt_orcamento.Text

        _clBD.altOrcamento_Orca1(nt_orca, nt_geno, nt_codig, nt_dtemis, nt_dtsai, nt_emiss, nt_cfop, _
                              nt_vend, nt_cid, nt_itens, nt_rota, nt_peso, nt_x, nt_y, nt_parc, _
                              nt_volum, nt_tipo2, nt_auto, nt_auto2, nt_cod1, nt_cod2, nt_cod3, _
                              nt_cod4, nt_cod5, nt_cod6, nt_cod7, nt_mapa, nt_sit, mbUf, conexao, transacao)



    End Sub

    Private Sub incluiDtg_itens(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mUsuario As String = Me.txt_operador.Text
        Dim mCodpr, MUnd, mCodVendedor, mFilial, mcdBarra As String
        Dim mPrvenda, mPrunit, mDesc, mtotal, mpesoLiq, mpesoBruto, mbaseIcms, moutrasDesp As Double
        Dim malqicms, malqcom, mcomis, mbasesub, malqsub, mvlsub, malqdesc, mvldesc As Double
        Dim mvlicms, mQtde As Double
        Dim mdtemis As Date
        Dim mLinha, mGrupo, mrota, midGrade As Integer

        mrota = 0 : mcdBarra = "" : MUnd = ""
        mpesoBruto = 0 : mpesoLiq = 0 : malqicms = 0 : mLinha = 0 : malqcom = 0
        mcomis = 0 : mbasesub = 0 : malqsub = 0 : mvlsub = 0 : mGrupo = 0
        malqdesc = 0 : mvldesc = 0 : mFilial = 0 : mbaseIcms = 0
        moutrasDesp = 0 : mvlicms = 0 : midGrade = 0

        For Each row As DataGridViewRow In Me.dtg_pedidoServico.Rows

            If Not row.IsNewRow Then

                mCodpr = row.Cells(2).Value
                mQtde = row.Cells(5).Value
                mPrunit = row.Cells(4).Value
                mPrvenda = row.Cells(4).Value
                mtotal = row.Cells(6).Value
                mdtemis = DateValue(dtp_emissao.Text)
                mtotal = Round(mtotal - mvlsub, 2)

                _clBD.incOrcamento_Orca2(Mid(cbo_local.SelectedItem, 1, 2), Me.txt_orcamento.Text, mCodpr, MUnd, mQtde, mPrvenda, malqdesc, _
                                       mvldesc, mPrunit, mtotal, malqicms, mbaseIcms, mbasesub, malqsub, mvlsub, _
                                       mdtemis, mrota, "01", mCodVendedor, mLinha, mGrupo, malqcom, mcomis, _valorZERO, _
                                       _numOrcamentoAtual, 2, Me.txt_codpart.Text, mFilial, mpesoBruto, mpesoLiq, mcdBarra, _
                                       moutrasDesp, mvlicms, midGrade, conexao, transacao)

            End If
        Next

        'LIMPA OBJETOS DA MEMÓRIA...
        mCodpr = Nothing : MUnd = Nothing : mPrvenda = Nothing
        mPrunit = Nothing : mDesc = Nothing : mtotal = Nothing : mdtemis = Nothing



    End Sub


    Private Sub alteraOrca4(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim tipo As String = "", nume As String = "", pgto As String = "", tipo2 As String = ""
        Dim tprod, aliss, vliss, vlser, basec, icms, bsub, icsub, tpro2, frete As Double
        Dim segu, outros, ipi, tgeral, peso, desc As Double

        tipo = "P" : nume = Me.txt_orcamento.Text : tipo2 = ""

        tprod = somaVlrTotalItensGrid()
        tpro2 = tprod
        basec = 0
        icms = 0
        bsub = 0
        icsub = 0
        tgeral = somaVlrTotalItensGrid()
        peso = 0
        desc = 0

        _clBD.altOrcamento_Orca4(tipo, nume, tprod, aliss, vliss, vlser, basec, icms, bsub, icsub, tpro2, _
                              frete, segu, outros, ipi, tgeral, pgto, peso, desc, tipo2, conexao, transacao)

    End Sub

    Private Function somaVlrTotalItensGrid() As Double

        Dim mVlrTotalItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_pedidoServico.Rows

            If Not row.IsNewRow Then mVlrTotalItens += row.Cells(6).Value

        Next

        mVlrTotalItens = Round(mVlrTotalItens, 2)
        Return mVlrTotalItens
    End Function

    Private Sub btn_finalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalizar.Click

        'Se foi informado algum produto...
        If Me.dtg_pedidoServico.Rows.Count > _valorZERO Then


            If verificaRegistroPedido() Then

                If MessageBox.Show("Deseja Finalizar Registros ?", "Finalizar ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Me.txt_codProd.Focus()
                Else


                    Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Dim transacao As NpgsqlTransaction

                    Try
                        conexao.Open()
                    Catch ex As Exception
                        MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
                        Return

                    End Try

                    Try
                        transacao = conexao.BeginTransaction

                        alteraRegistroOrcamento(conexao, transacao)
                        _clBD.delOrcamento_Orca2(Me.txt_orcamento.Text, conexao, transacao)
                        incluiDtg_itens(conexao, transacao)
                        alteraOrca4(conexao, transacao)

                        transacao.Commit()
                        Try
                            conexao.ClearAllPools()
                        Catch ex As Exception
                        End Try
                        conexao.Close()
                        MsgBox("Registro Efetuado c/ Sucesso", MsgBoxStyle.Exclamation, "METROSYS")
                        executaRelatorioOrcamento("", "\wged\relatorios\orcamentoSucesso.txt")
                        Me.txt_orcamento.Text = ""

                        zeraTudo() : Me.cbo_local.Focus() : _numPedidoOK = False
                        Me.Close()

                    Catch ex As NpgsqlException

                        transacao.Rollback()
                        MsgBox(ex.Message.ToString)
                    Catch ex As Exception


                        Try
                            transacao.Rollback()
                        Catch ex2 As Exception
                            MsgBox(ex2.Message.ToString)
                        End Try

                        MsgBox(ex.Message.ToString)
                    Finally
                        conexao = Nothing : transacao = Nothing

                    End Try


                End If
            End If
        End If



    End Sub

    Private Sub cbo_local_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_local.GotFocus

        If Not cbo_local.DroppedDown Then cbo_local.DroppedDown = True
    End Sub

    Private Sub executeF5()


        _qtdeAnteriorProd = 0
        _editandoProduto = False
        Try
            If Not dtg_pedidoServico.CurrentRow.IsNewRow Then

                _indexProdEditando = dtg_pedidoServico.CurrentRow.Index
                _codProdEditando = dtg_pedidoServico.CurrentRow.Cells(2).Value.ToString
                Me.txt_codProd.Text = dtg_pedidoServico.CurrentRow.Cells(2).Value
                Me.txt_nomeProd.Text = dtg_pedidoServico.CurrentRow.Cells(3).Value
                Me.txt_valor.Text = Format(CDbl(dtg_pedidoServico.CurrentRow.Cells(4).Value.ToString), "##,##0.00") 'dtg_pedidoServico.CurrentRow.Cells(7).Value
                Me.txt_qtde.Text = Format(CDbl(dtg_pedidoServico.CurrentRow.Cells(5).Value.ToString), "##,##0.00")


                _editandoProduto = True
                qtdeProd_Ref += _qtdeAnteriorProd
                txt_codProd.Focus() : txt_codProd.SelectAll()


            End If

        Catch ex As Exception
        End Try



    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click


        Try

            executeF5()

        Catch ex As Exception
        End Try


    End Sub

    Private Sub DeleteItemGrid()

        Try

            lbl_mensagem.Text = ""
            If Me.dtg_pedidoServico.Enabled = True Then

                Me.dtg_pedidoServico.Rows.Remove(Me.dtg_pedidoServico.CurrentRow)
                Me.dtg_pedidoServico.Refresh()

                Me.txt_total.Text = Format(somaVlrTotalItensGrid, "###,##0.00")

                If _indexProdEditando >= _valorZERO Then

                    _indexProdEditando = -1 : _codProdEditando = ""
                End If

            End If

        Catch ex As Exception
            MsgBox("Deu ERRO ao Deletar este Item " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try



    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click

        If Me.dtg_pedidoServico.Rows.Count > _valorZERO Then

            If MessageBox.Show("Deseja realmente Deletar esse Item?", "METROSYS", MessageBoxButtons.YesNo, _
                               MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Me.DeleteItemGrid()
            End If
        End If



    End Sub


    'Inicia-se o Tratamento da Impressão do pedido...
    Private Sub executaRelatorio1(ByVal s As Cl_EscreveArquivo, ByVal loja As String, ByVal numeroOrcamento As String, ByVal dtEmissao As String, ByVal codClient As String, ByVal nomeClient As String, ByVal condicao As String, ByVal codVendedor As String, ByVal idOrca1 As Int32, ByRef shouldReturn As Boolean)

        shouldReturn = False
        s.WriteLine("")

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Loja
        _mConsulta.Append("SELECT g_geno, g_ender, g_fone, g_uf, g_cid FROM geno001 WHERE g_codig = '" & loja & "'")
        Dim lShouldReturn1 As Boolean
        _clFuncoes.GravCabLojOrcamentoMatricial(_mConsulta.ToString, s, loja, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return
        _mConsulta.Remove(0, _mConsulta.ToString.Length)

        'Cliente
        _mConsulta.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
        _mConsulta.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & _cadp001.pCod & "'")
        Dim lShouldReturn2 As Boolean
        _clFuncoes.GravCabCliOrcamentoMatricial(_mConsulta.ToString, s, codClient, numeroOrcamento, dtEmissao, codVendedor, condicao, loja, lShouldReturn2)
        If lShouldReturn2 Then shouldReturn = True : Return

        'Orçamento
        s.WriteLine("-------------------------------------------------------------------------------------")
        s.WriteLine(_clFuncoes.Centraliza_Str("ORÇAMENTO Nº " & numeroOrcamento, 85) & vbNewLine)

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'itens
        _mConsulta.Append("SELECT o2.no_codpr, o2.no_qtde, o2.no_und, el.s_descricao, o2.no_prunit, o2.no_prtot, o2.no_filial, '', o2.no_vldesc, o2.no_pesobruto, o2.no_vlsub ") '10
        _mConsulta.Append("FROM " & MdlEmpresaUsu._esqEstab & ".tb_orca2 o2 LEFT JOIN servico el ON text(el.s_id) = ")
        _mConsulta.Append("o2.no_codpr WHERE no_idorca1 = " & idOrca1)
        Dim lShouldReturn3 As Boolean
        _clFuncoes.GravItensOrcamentoMatricial(_mConsulta.ToString, s, numeroOrcamento, idOrca1, codClient, nomeClient, lShouldReturn3)
        If lShouldReturn3 Then shouldReturn = True : Return

    End Sub

    Private Sub executaRelatorioOrcamento(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\tmp\TempOrcamento.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Truncate, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        Dim s As New Cl_EscreveArquivo(fs)
        _PrintFont = New Font("Lucida Console", 9)
        Dim strLinha As String = ""
        Dim loja As String = "G00" & Mid(Me.cbo_local.SelectedItem, 1, 2)
        Dim numeroOrcamento As String = Me.txt_orcamento.Text
        Dim dtEmissao As String = Me.dtp_emissao.Text
        Dim codClient As String = Me.txt_codpart.Text
        Dim nomeClient As String = Me.txt_nomePart.Text
        Dim condicao As String = ""
        Dim idOrca1 As Int32 = Convert.ToInt64(Me.txt_orcamento.Text)

        Select Case MdlRelatorioTelas._tl_movorcamento

            Case 1 'Impressora Matricial
                Dim lShouldReturn As Boolean
                executaRelatorio1(s, loja, numeroOrcamento, dtEmissao, codClient, nomeClient, condicao, "", idOrca1, lShouldReturn)
                If lShouldReturn Then Return

            Case 2 'Impressora Laiser
                Dim lShouldReturn As Boolean
                executaRelatorio1(s, loja, numeroOrcamento, dtEmissao, codClient, nomeClient, condicao, "", idOrca1, lShouldReturn)
                If lShouldReturn Then Return

            Case Else
                Dim lShouldReturn As Boolean
                executaRelatorio1(s, loja, numeroOrcamento, dtEmissao, codClient, nomeClient, condicao, "", idOrca1, lShouldReturn)
                If lShouldReturn Then Return

        End Select


        'Deleta o arquivo temporário...
        s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        s.Dispose()
        Try
            File.Delete(mArqTemp)
        Catch ex As Exception
        End Try


        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo()

        _StringToPrint = ""
    End Sub

    Private Sub LerOArquivoSalvo(ByVal arqSaida As String)
        'Ler o Arquivo salvo...
        Dim FilePath As String = arqSaida
        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrint = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream.Dispose() : MyfileStream = Nothing
            'File.Delete(arqSaida)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub VisuConteArqSalvo()

        Try

            ' Especifica as configurações da pagina atual
            Me.pdRelatPedidos.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            Me.pdRelatPedidos.DefaultPageSettings.Margins.Top = 12
            Me.pdRelatPedidos.DefaultPageSettings.Margins.Right = 12
            Me.pdRelatPedidos.DefaultPageSettings.Margins.Left = 10
            Me.pdRelatPedidos.DefaultPageSettings.Margins.Bottom = 8

            'Orientação em Paisagem...
            Select Case MdlRelatorioTelas._tl_movorcamento
                Case 1 'Impressora Matricial
                    pdRelatPedidos.DefaultPageSettings.Landscape = True
                Case 2 'Impressora Laiser
                    pdRelatPedidos.DefaultPageSettings.Landscape = False
                Case Else
                    pdRelatPedidos.DefaultPageSettings.Landscape = True
            End Select
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            Me.PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            Me.PrintPreviewDialog1.Text = "Vizualizando ORÇAMENTO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            Me.PrintPreviewDialog1.Document = pdRelatPedidos
            Me.PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub pdRelatPedidos_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdRelatPedidos.PrintPage

        Dim NumChars As Integer
        Dim NumLines As Integer
        Dim StringforPage As String
        Dim Strformat As New StringFormat

        Dim recdraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, _
                                      e.MarginBounds.Width, e.MarginBounds.Height)
        Dim SizeMeassure As New SizeF(e.MarginBounds.Width, _
                                      e.MarginBounds.Height - _PrintFont.GetHeight(e.Graphics))

        Strformat.Trimming = StringTrimming.Word
        e.Graphics.MeasureString(_StringToPrint, _PrintFont, SizeMeassure, Strformat, NumChars, NumLines)
        StringforPage = _StringToPrint.Substring(_valorZERO, NumChars)

        ' Imprime a string na pagina atual
        'e.Graphics.DrawString(StringforPage, _PrintFont, Brushes.Black, recdraw, Strformat)
        e.Graphics.DrawString(StringforPage, _PrintFont, Brushes.Black, 80, 100, New StringFormat())

        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False '_stringToPrintAux = _StringToPrint

        End If



    End Sub

    Private Sub InicializaRelatorio(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintEventArgs)

        _StringToPrint = _stringToPrintAux
        If MostrarCaixaImpressoras Then


            Dim Impressora As New PrintDialog
            Impressora.AllowCurrentPage = True : Impressora.AllowSomePages = True
            If Impressora.ShowDialog() = DialogResult.Cancel Then

                Relatorio.Cancel = True

            Else

                Try

                    pdRelatPedidos.PrinterSettings = Impressora.PrinterSettings
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
        End If
        MostrarCaixaImpressoras = True



    End Sub

    Private Sub txt_pedido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_orcamento.TextChanged

        If Me.txt_orcamento.Text.Equals("") Then Me._numPedidoOK = False

    End Sub

    Private Sub Frm_Orcamento_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing


        If dtg_pedidoServico.Rows.Count > 0 Then

            If MessageBox.Show("Deseja Realmente Sair?", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
            = Windows.Forms.DialogResult.No Then

                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub dtg_pedidoServico_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtg_pedidoServico.RowsAdded

        dtg_pedidoServico.Rows(e.RowIndex).Cells(4).Style.ForeColor = Color.DarkBlue

    End Sub

    Private Sub txt_qtde_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtde.Leave

        lbl_mensagem.Text = ""
        If Me.txt_qtde.Text.Equals("") Then Me.txt_qtde.Text = Format(1.0, "###,##0.00")
        If IsNumeric(Me.txt_qtde.Text) Then
            If CDec(Me.txt_qtde.Text) <= _valorZERO Then
                lbl_mensagem.Text = "Quantidade deve ser maior que ZERO !"
                Return

            End If
            Me.txt_qtde.Text = Format(CDec(Me.txt_qtde.Text), "###,##0.00")

        End If



    End Sub

    Private Sub txt_qtde_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtde.KeyPress

        'permite só numeros com vírgula
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

End Class