Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class Frm_PedidoProntEntregAlt

    Private Const _valorZERO As Integer = 0
    Dim _mapaPedido As Integer = 0
    Dim xcont As Integer = 0
    Dim _clBD As New Cl_bdMetrosys
    Dim _clFuncoes As New ClFuncoes
    Dim _formBusca As Boolean = False
    Dim mNumPedido As String = "", _numPedidoTemp As String = ""
    Dim mIdOrca1pp As Int32 = _valorZERO, mIdOrca1ppTemp As Int32 = _valorZERO
    Public _mPesquisaForn As Boolean = False 'Serve para configura os campos CodFornec e NomeFornec
    Public Shared _frmREf As New Frm_PedidoProntEntregAlt
    Dim _BuscaForn As New Frm_BuscaCliPedido
    Dim _BuscaProd As New Frm_BuscaProdPedido
    Dim _FrmGeraPedidos As New Frm_GeraPedidos
    Dim _FrmConfirmaCompraGrade As New Frm_ConfirmaCompraGrade
    Dim _numPedidoOK As Boolean = False
    Dim _mConsulta As New StringBuilder
    Dim _editandoProduto As Boolean = False
    Dim _gerenteOK As Boolean = False

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
    Dim objGrade As New Cl_Grade
    Public codCorGrade_Ref, nomeCorGrade_Ref, tamanhoGrade_Ref As String

    'objetos para impressão...
    Dim MostrarCaixaImpressoras As Boolean = False
    Dim _StringToPrint As String = "", _StringToPrintItens As String = "", _stringToPrintAux As String = ""
    Private _PrintFont As New Font("Lucida Console", 8) 'Stenci
    Private _PrintFont1 As New Font("Lucida Console", 8) 'Stenci
    Private _PrintFont2 As New Font("Lucida Console", 8)
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Dim _cabecalho As Boolean = True
    Private _sImpressao As StreamWriter
    Private _leitorTabelaImprimir As NpgsqlDataReader

    'Objetos para salvar o pedido...
    Dim _arqTempPedido As String = "\wged\TempSalvaPedido.TMP"
    Dim _fsPedido As FileStream
    Dim _arqNumPedido As String = "\wged\numpedido.TXT"

    'Objetos para tratar o Gerente...
    Dim _vlrMaxDesconto As Double = 0.0
    Dim _nomeGerente As String = ""

    'Objetos para tratar o vendedor...
    Dim _descVendedor As Double = 0.0


    Private Sub Frm_PedidoProntEntregAlt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Frm_PedidoProntEntregAlt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_PedidoProntEntregAlt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_desconto.Text = "0,00"
        Me.txt_valor.Text = "0,00"

        Me.txt_consumo.Text = "N"
        Me.cbo_condpgto.SelectedIndex = 0
        Me.cbo_forpgto.SelectedIndex = 0
        Me.cbo_tipopedido.SelectedIndex = 0
        Me.cbo_tipopedido.Enabled = False
        Me.txt_qtde.Text = "1,00"
        'Me.txt_desconto.Enabled = False
        'Me.txt_valor.ReadOnly = False  ' Modificar de acordo com o usuario
        Me.txt_operador.Text = MdlUsuarioLogando._usuarioNome
        cbo_local = _clFuncoes.PreenchComboLoja(cbo_local, MdlConexaoBD.conectionPadrao)
        Me.cbo_local.SelectedIndex = _clFuncoes.trazIndexCboLoja(Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2), cbo_local)

        If MdlUsuarioLogando._usuarioPrivilegio = True Then Me.cbo_local.Enabled = True

        Me.dtg_pedidoprotaentrega.Columns(7).DefaultCellStyle.Format = "###,##0.00"
        Me.dtg_pedidoprotaentrega.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque  ' Color.Gainsboro

        If MdlEmpresaUsu._codProd = False Then

            Me.dtg_pedidoprotaentrega.Columns(2).Visible = False
            Me.dtg_pedidoprotaentrega.Columns(3).Visible = True
        End If


        cbo_vendedor = _clFuncoes.PreenchComboVendedores(cbo_vendedor, MdlConexaoBD.conectionPadrao)

        Select Case MdlEmpresaUsu.tipoCondPagto
            Case 1
                cbo_condpgto = _clFuncoes.PreenchComboCondPagto1(cbo_condpgto, MdlConexaoBD.conectionPadrao)
            Case 2
                cbo_condpgto = _clFuncoes.PreenchComboCondPagto2(cbo_condpgto, MdlConexaoBD.conectionPadrao)
        End Select

        cbo_gerente = _clFuncoes.PreenchComboGerente(cbo_gerente, MdlConexaoBD.conectionPadrao)
        cbo_rota = _clFuncoes.PreenchComboRotas(cbo_rota, MdlConexaoBD.conectionPadrao)
        cbo_rota.Enabled = False


        _numPedidoOK = True
        _numPedidoTemp = _FrmGeraPedidos._frmRefGeraPedidos._numPedidoTemp
        _mapaPedido = _FrmGeraPedidos._frmRefGeraPedidos._mapaPedido
        If _numPedidoTemp.Equals("") Then

            preenchCamposRegistroPedido(_FrmGeraPedidos._frmRefGeraPedidos._numPedido)
            preenchItensPedido(_FrmGeraPedidos._frmRefGeraPedidos._numPedido)

        Else ' Se for o Pedido temporário então traz ele...

            preenchCamposRegistroPedidoTemp(_FrmGeraPedidos._frmRefGeraPedidos._numPedidoTemp)
            preenchItensPedidoTemp(_FrmGeraPedidos._frmRefGeraPedidos._numPedidoTemp)
        End If

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos.BeginPrint, AddressOf InicializaRelatorio

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos2.BeginPrint, AddressOf InicializaRelatorio2

        'relaciona o objeto pd.FimDaImpressao com Atualização da Situação do Pedido como Impresso
        AddHandler pdRelatPedidos2.EndPrint, AddressOf atualizaSituacaoPedido

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos.EndPrint, AddressOf atualizaSituacaoPedido

    End Sub

    Private Sub atualizaSituacaoPedido()
        _clBD.altSituacaoPedido_Orca1(Me.txt_pedido.Text, 2, MdlConexaoBD.conectionPadrao)
    End Sub

    Private Sub msk_senha_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_senha.Leave


        _gerenteOK = False
        If msk_senha.Text.Equals("") = False Then

            Dim mnomeGerente As String = cbo_gerente.SelectedItem
            Dim msenhaGerente As String = msk_senha.Text
            Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try
                oConnBDMETROSYS.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            If _clBD.existeGerente(oConnBDMETROSYS, mnomeGerente, msenhaGerente) Then

                Me.txt_valor.ReadOnly = True : Me.txt_valor.Text = "0,00"
                Me.txt_desconto.ReadOnly = True : Me.txt_desconto.Text = "0,00"
                _gerenteOK = True

                _nomeGerente = mnomeGerente
                If _clBD.trazLibDescGerente(oConnBDMETROSYS, mnomeGerente, msenhaGerente) Then

                    Me.txt_desconto.Enabled = True : Me.txt_desconto.ReadOnly = False
                End If

                If _clBD.trazLibValorGerente(oConnBDMETROSYS, mnomeGerente, msenhaGerente) Then

                    Me.txt_valor.Enabled = True : Me.txt_valor.ReadOnly = False
                End If


            Else

                If cbo_gerente.SelectedIndex >= 0 Then

                    MsgBox("Senha do gerente incorreta!")
                    Me.msk_senha.Focus()
                End If


            End If

            oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close() : oConnBDMETROSYS = Nothing
        Else

            Me.cbo_gerente.SelectedIndex = -1
        End If


    End Sub

    Private Sub cbo_condpgto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_condpgto.GotFocus

        If Not cbo_condpgto.DroppedDown Then cbo_condpgto.DroppedDown = True
    End Sub

    Private Sub cbo_condpgto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_condpgto.Leave

        If cbo_condpgto.SelectedIndex >= _valorZERO Then


            'Verifica se a Condicao de pagamento é 0, se for, seleciona Forma de pagamento AV
            If IsNumeric(Me.cbo_condpgto.SelectedItem) Then

                If CInt(Me.cbo_condpgto.SelectedItem) = _valorZERO Then Me.cbo_forpgto.SelectedIndex = _valorZERO

            Else

                Me.cbo_forpgto.SelectedIndex = 1

            End If


            Select Case MdlEmpresaUsu.tipoCondPagto
                Case 1
                    preencheCondicoesPagto2(Me.cbo_condpgto.SelectedItem)
            End Select
        End If


    End Sub

    Private Sub preencheCondicoesPagto2(ByVal condicoes As String)

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdCondPagto As New NpgsqlCommand
        Dim sqlCondPagto As New StringBuilder
        Dim drCondPagto As NpgsqlDataReader

        Try
            sqlCondPagto.Append("SELECT cpg_cond1, cpg_cond2, cpg_cond3, cpg_cond4, cpg_cond5, cpg_cond6, ") '5
            sqlCondPagto.Append("cpg_cond7 FROM condpagto WHERE cpg_descricao = @cpg_descricao")

            cmdCondPagto = New NpgsqlCommand(sqlCondPagto.ToString, oConnBDMETROSYS)
            cmdCondPagto.Parameters.Add("@cpg_descricao", condicoes)
            drCondPagto = cmdCondPagto.ExecuteReader

            While drCondPagto.Read

                Me.txt_cond1.Text = drCondPagto(0)
                Me.txt_cond2.Text = drCondPagto(1)
                Me.txt_cond3.Text = drCondPagto(2)
                Me.txt_cond4.Text = drCondPagto(3)
                Me.txt_cond5.Text = drCondPagto(4)
                Me.txt_cond6.Text = drCondPagto(5)
                Me.txt_cond7.Text = drCondPagto(6)

            End While
            drCondPagto.Close()

        Catch ex As Exception
            MsgBox("ERRO no SELECT das CONDIÇÕES:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return

        End Try

        cmdCondPagto.CommandText = "" : sqlCondPagto.Remove(0, sqlCondPagto.ToString.Length)
        oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()
        cmdCondPagto = Nothing : sqlCondPagto = Nothing : oConnBDMETROSYS = Nothing

    End Sub

    Private Sub txt_codPart_KeyDownExtracted()

        _formBusca = True : _mPesquisaForn = False : _frmREf = Me
        _BuscaForn.set_frmRef(Me)
        _BuscaForn.ShowDialog(Me)
        _formBusca = False
        If Me.txt_codpart.Text.Equals("") Then Me.txt_codpart.Focus()

        Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()


        'Tratamento do Consumo...
        Me.txt_consumo.ReadOnly = False
        If mIsento = True Then

            Me.txt_consumo.Text = "S" : Me.txt_consumo.ReadOnly = True
        Else


            If mConsumo.Equals("S") Then

                Me.txt_consumo.Text = "S"
            Else
                Me.txt_consumo.Text = "N"
            End If
        End If

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

                    If trazFornecedor(Me.txt_codpart.Text) Then

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

    Private Function trazFornecedor(ByVal codFornec As String) As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        Dim pesquisa As String = codFornec.ToUpper

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try
            SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc, p_uf, p_end, p_cid, p_cep, ") ' 8
            SqlParticipante.Append("p_fone, p_consumo, p_isento FROM cadp001 WHERE p_cod = '" & pesquisa & "' ORDER BY p_portad ASC")
            CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDGENOV)
            drParticipante = CmdParticipante.ExecuteReader

            If drParticipante.HasRows = False Then
                Return False

            Else

                While drParticipante.Read

                    mCodPart = drParticipante(_valorZERO).ToString
                    mNomePart = drParticipante(1).ToString
                    mbCNPJ = drParticipante(2).ToString
                    mbCPF = drParticipante(3).ToString
                    mbUf = drParticipante(5).ToString
                    mEnderecoPart = drParticipante(6).ToString
                    mCidadePart = drParticipante(7).ToString
                    mCepPart = drParticipante(8).ToString
                    mFonePart = drParticipante(9).ToString
                    mConsumo = drParticipante(10).ToString
                    mIsento = drParticipante(11)

                End While
                drParticipante.Close() : Me.txt_nomePart.Text = mNomePart


                'Tratamento do Consumo...
                Me.txt_consumo.ReadOnly = False
                If mIsento = True Then

                    Me.txt_consumo.Text = "S" : Me.txt_consumo.ReadOnly = True
                Else


                    If mConsumo.Equals("S") Then

                        Me.txt_consumo.Text = "S"
                    Else
                        Me.txt_consumo.Text = "N"
                    End If
                End If



            End If

        Catch ex As Exception
        End Try

        CmdParticipante.CommandText = "" : SqlParticipante.Remove(_valorZERO, SqlParticipante.ToString.Length)
        CmdParticipante = Nothing : SqlParticipante = Nothing : drParticipante = Nothing
        oConnBDGENOV.ClearPool() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing



        Return True
    End Function

    Private Sub txt_desconto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_desconto.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(_clBD.SoNumerov(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_qtde_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtde.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(_clBD.SoNumerov(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_valor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valor.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(_clBD.SoNumerov(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_codprod_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codProd.KeyDown


        If (e.KeyCode = Keys.Enter  ) OrElse (e.KeyCode = Keys.Tab) Then

            If Me.txt_codProd.Text.Equals("") Then

                'Aqui tenta chamar a Busca do Produto...
                Try
                    _formBusca = True
                    local_ref = Mid(cbo_local.SelectedItem, 1, 2)
                    _frmREf = Me
                    _BuscaProd.set_frmRef(Me)
                    _BuscaProd.ShowDialog(Me)
                    _formBusca = False

                    If MdlEmpresaUsu._codProd Then

                        Me.txt_codProd.Text = codProd_Ref

                    Else
                        Me.txt_codProd.Text = cdBarraProd_Ref
                    End If


                    Me.txt_nomeProd.Text = nomeProd_Ref
                    ValorUnitProd_Ref = Round(ValorUnitProd_Ref, 2)
                    Me.txt_valor.Text = Format(ValorUnitProd_Ref, "###,##0.00")

                    'Tratamento da Grade...
                    If gradeProd_Ref.Equals("S") Then

                        _frmREf = Me
                        _FrmConfirmaCompraGrade.set_frmRef(Me)
                        _FrmConfirmaCompraGrade.ShowDialog()
                        If codCorGrade_Ref.Equals("01") = False Then
                            nomeProd_Ref += " - " & nomeCorGrade_Ref
                            Me.txt_nomeProd.Text = nomeProd_Ref
                        End If
                    End If

                    'Tratamento para Promoção...
                    If IsDate(dtInicialPromocao_Ref) AndAlso IsDate(dtFinalPromocao_Ref) Then

                        'Se a Promoção estiver dentro do período...
                        If (dtp_emissao.Value >= dtInicialPromocao_Ref) AndAlso (dtp_emissao.Value <= dtFinalPromocao_Ref) Then

                            Me.txt_valor.Text = Format(vlPromocao_Ref, "###,##0.00")

                        End If
                    End If


                    If Me.txt_codProd.Text.Equals("") Then
                        Me.txt_codProd.Focus()
                    Else

                        Me.txt_nomeProd.Focus()
                    End If


                Catch ex As Exception
                End Try

            Else

                If _editandoProduto = False Then

                    If trazItenBD(RTrim(Me.txt_codProd.Text)) = False Then
                        'Aqui tenta chamar a Busca do Produto...
                        Try
                            _formBusca = True
                            local_ref = Mid(cbo_local.SelectedItem, 1, 2)
                            _frmREf = Me
                            _BuscaProd.set_frmRef(Me)
                            _BuscaProd.ShowDialog(Me)
                            _formBusca = False

                            If MdlEmpresaUsu._codProd Then

                                Me.txt_codProd.Text = codProd_Ref

                            Else
                                Me.txt_codProd.Text = cdBarraProd_Ref
                            End If

                            Me.txt_nomeProd.Text = nomeProd_Ref
                            Me.txt_valor.Text = Format(Round(ValorUnitProd_Ref, 2), "###,#00.00")

                            'Tratamento da Grade...
                            If gradeProd_Ref.Equals("S") Then

                                _frmREf = Me
                                _FrmConfirmaCompraGrade.set_frmRef(Me)
                                _FrmConfirmaCompraGrade.ShowDialog()
                                If codCorGrade_Ref.Equals("01") = False Then
                                    nomeProd_Ref += " - " & nomeCorGrade_Ref
                                    Me.txt_nomeProd.Text = nomeProd_Ref
                                End If
                            End If

                            'Tratamento para Promoção...
                            If IsDate(dtInicialPromocao_Ref) AndAlso IsDate(dtFinalPromocao_Ref) Then

                                'Se a Promoção estiver dentro do período...
                                If (dtp_emissao.Value >= dtInicialPromocao_Ref) AndAlso (dtp_emissao.Value <= dtFinalPromocao_Ref) Then

                                    Me.txt_valor.Text = Format(vlPromocao_Ref, "###,##0.00")

                                End If
                            End If


                            If Me.txt_codProd.Text.Equals("") Then
                                Me.txt_codProd.Focus()
                            Else

                                Me.txt_nomeProd.Focus()
                            End If

                        Catch ex As Exception
                        End Try

                    Else

                        If MdlEmpresaUsu._codProd Then

                            Me.txt_codProd.Text = codProd_Ref

                        Else
                            Me.txt_codProd.Text = cdBarraProd_Ref
                        End If

                        Me.txt_nomeProd.Text = nomeProd_Ref
                        Me.txt_valor.Text = Format(Round(ValorUnitProd_Ref, 2), "###,#00.00")
                        qtdeProd_Ref += _qtdeAnteriorProd

                        'Tratamento da Grade...
                        If gradeProd_Ref.Equals("S") Then

                            _frmREf = Me
                            _FrmConfirmaCompraGrade.set_frmRef(Me)
                            _FrmConfirmaCompraGrade.ShowDialog()
                            If codCorGrade_Ref.Equals("01") = False Then
                                nomeProd_Ref += " - " & nomeCorGrade_Ref
                                Me.txt_nomeProd.Text = nomeProd_Ref
                            End If
                        End If

                        'Tratamento para Promoção...
                        If IsDate(dtInicialPromocao_Ref) AndAlso IsDate(dtFinalPromocao_Ref) Then

                            'Se a Promoção estiver dentro do período...
                            If (dtp_emissao.Value >= dtInicialPromocao_Ref) AndAlso (dtp_emissao.Value <= dtFinalPromocao_Ref) Then

                                Me.txt_valor.Text = Format(vlPromocao_Ref, "###,##0.00")

                            End If
                        End If


                        If Me.txt_codProd.Text.Equals("") Then
                            Me.txt_codProd.Focus()
                        Else

                            Me.txt_nomeProd.Focus()
                        End If

                    End If
                End If


            End If
        End If


    End Sub

    Public Function trazItenBD(ByVal codIten As String) As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader
        Dim _erro As Boolean = False
        Dim _msgErro As String = ""
        Dim _contErros As Integer = _valorZERO
        Dim nomeCampo As String = ""

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("Banco de Dados ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return False

        End Try



        Dim codigo, nome, fornecedor, qtdEstoque, undMedida, ncmProd As String
        Dim CST, CFV, GRUPO, REDUZ As Integer
        Dim sldAtual, pcoAnt, custAnt, CLF As String

        Try
            SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, e.e_qtde, e.e_und, e.e_ncm, ") ' 5
            SqlProduto.Append("e.e_cst, e.e_cfv, e.e_grupo, e.e_reduz, el.e_qtde, el.e_pcusto, el.e_pcomp, ") ' 12
            SqlProduto.Append("e.e_clf, el.e_pvenda, e.e_pesobruto, e.e_pesoliq, e.e_cdbarra, e.e_linha, ") ' 18
            SqlProduto.Append("e.e_dtinicialpromocao, e.e_dtfinalpromocao, e.e_quotapromocao, e.e_grade ") ' 22
            SqlProduto.Append("FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN estloja01 el ON e.e_codig = el.e_codig WHERE ")
            SqlProduto.Append("el.e_loja = '" & Mid(Me.cbo_local.SelectedItem, 1, 2) & "' AND ")

            If MdlEmpresaUsu._codProd Then

                SqlProduto.Append("el.e_codig = '" & codIten & "' ORDER BY e_produt ASC")

            Else
                SqlProduto.Append("e.e_cdbarra = '" & codIten & "' ORDER BY e_produt ASC")

            End If


            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDGENOV)
            drProduto = CmdProduto.ExecuteReader

            If drProduto.HasRows = False Then Return False
            While drProduto.Read
                codigo = drProduto(_valorZERO).ToString : nome = drProduto(1).ToString
                fornecedor = drProduto(2).ToString : qtdEstoque = drProduto(3).ToString
                undMedida = drProduto(4).ToString : ncmProd = drProduto(5).ToString
                CST = drProduto(6) : CFV = drProduto(7) : GRUPO = drProduto(8)
                REDUZ = drProduto(9) : sldAtual = drProduto(10).ToString
                custAnt = drProduto(11).ToString : pcoAnt = drProduto(12).ToString
                CLF = drProduto(13).ToString


                cdBarraProd_Ref = drProduto(17).ToString
                LinhaProd_Ref = drProduto(18).ToString
                qtdeProd_Ref = drProduto(10).ToString
                codProd_Ref = codigo
                nomeProd_Ref = nome
                UndProd_Ref = undMedida
                qtdeProd_Ref = qtdEstoque
                CstProd_Ref = CST
                CfvProd_Ref = CFV
                ClfProd_Ref = CLF
                GrupoProd_Ref = GRUPO
                ReduzProd_Ref = REDUZ
                ValorUnitProd_Ref = drProduto(14)
                ValorUnitProd_Ref = Round(ValorUnitProd_Ref, 2)
                pesoBrutoProd_Ref = drProduto(15)
                pesoLiqProd_Ref = drProduto(16)
                local_ref = Mid(Me.cbo_local.SelectedItem, 1, 2)
                FilialProd_Ref = local_ref
                gradeProd_Ref = drProduto(22).ToString

                Try
                    dtInicialPromocao_Ref = drProduto(19).ToString
                Catch ex As Exception
                    dtInicialPromocao_Ref = Nothing
                End Try

                Try
                    dtFinalPromocao_Ref = drProduto(20).ToString
                Catch ex As Exception
                    dtFinalPromocao_Ref = Nothing
                End Try

                Try
                    vlPromocao_Ref = drProduto(21).ToString
                Catch ex As Exception
                    vlPromocao_Ref = Nothing
                End Try

                If MdlEmpresaUsu._codProd Then

                    Me.txt_codProd.Text = codigo

                Else
                    Me.txt_codProd.Text = cdBarraProd_Ref

                End If


                Me.txt_nomeProd.Text = nome


            End While
            drProduto.Close()

        Catch ex As Exception
            MsgBox("Tabela de PRODUTOS ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return False

        End Try

        CmdProduto.CommandText = "" : SqlProduto.Remove(_valorZERO, SqlProduto.ToString.Length)
        CmdProduto = Nothing : SqlProduto = Nothing : drProduto = Nothing
        oConnBDGENOV.ClearPool() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return True
    End Function

    Public Function trazItenFilialBD(ByVal codIten As String) As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader
        Dim _erro As Boolean = False
        Dim _msgErro As String = ""
        Dim _contErros As Integer = _valorZERO
        Dim nomeCampo As String = ""

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("Banco de Dados ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return False

        End Try



        Dim codigo, nome, fornecedor, qtdEstoque, undMedida, ncmProd As String
        Dim CST, CFV, GRUPO, REDUZ As Integer
        Dim sldAtual, pcoAnt, custAnt, CLF As String

        Try
            SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, e.e_qtde, e.e_und, e.e_ncm, ") ' 5
            SqlProduto.Append("e.e_cst, e.e_cfv, e.e_grupo, e.e_reduz, el.e_qtde, el.e_pcusto, el.e_pcomp, ") ' 12
            SqlProduto.Append("e.e_clf, el.e_pvenda, e.e_pesobruto, e.e_pesoliq, e.e_cdbarra, e.e_linha, ") ' 18
            SqlProduto.Append("e.e_dtinicialpromocao, e.e_dtfinalpromocao, e.e_quotapromocao, e.e_grade ") ' 22
            SqlProduto.Append("FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN estloja01 el ON e.e_codig = el.e_codig WHERE ")
            SqlProduto.Append("el.e_loja = '" & FilialProd_Ref & "' AND ")

            If MdlEmpresaUsu._codProd Then

                SqlProduto.Append("el.e_codig = '" & codIten & "' ORDER BY e_produt ASC")

            Else
                SqlProduto.Append("e.e_cdbarra = '" & codIten & "' ORDER BY e_produt ASC")

            End If


            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDGENOV)
            drProduto = CmdProduto.ExecuteReader

            If drProduto.HasRows = False Then Return False
            While drProduto.Read
                codigo = drProduto(_valorZERO).ToString : nome = drProduto(1).ToString
                fornecedor = drProduto(2).ToString : qtdEstoque = drProduto(3).ToString
                undMedida = drProduto(4).ToString : ncmProd = drProduto(5).ToString
                CST = drProduto(6) : CFV = drProduto(7) : GRUPO = drProduto(8)
                REDUZ = drProduto(9) : sldAtual = drProduto(10).ToString
                custAnt = drProduto(11).ToString : pcoAnt = drProduto(12).ToString
                CLF = drProduto(13).ToString


                cdBarraProd_Ref = drProduto(17).ToString
                LinhaProd_Ref = drProduto(18).ToString
                qtdeProd_Ref = drProduto(10)
                codProd_Ref = codigo
                nomeProd_Ref = nome
                UndProd_Ref = undMedida
                qtdeProd_Ref = qtdEstoque
                CstProd_Ref = CST
                CfvProd_Ref = CFV
                ClfProd_Ref = CLF
                GrupoProd_Ref = GRUPO
                ReduzProd_Ref = REDUZ
                ValorUnitProd_Ref = drProduto(14)
                ValorUnitProd_Ref = Round(ValorUnitProd_Ref, 2)
                pesoBrutoProd_Ref = drProduto(15)
                pesoLiqProd_Ref = drProduto(16)
                local_ref = FilialProd_Ref
                gradeProd_Ref = drProduto(22).ToString

                Try
                    dtInicialPromocao_Ref = drProduto(19).ToString
                Catch ex As Exception
                    dtInicialPromocao_Ref = Nothing
                End Try

                Try
                    dtFinalPromocao_Ref = drProduto(20).ToString
                Catch ex As Exception
                    dtFinalPromocao_Ref = Nothing
                End Try

                Try
                    vlPromocao_Ref = drProduto(21).ToString
                Catch ex As Exception
                    vlPromocao_Ref = Nothing
                End Try

                If MdlEmpresaUsu._codProd Then

                    Me.txt_codProd.Text = codigo

                Else
                    Me.txt_codProd.Text = cdBarraProd_Ref

                End If


                Me.txt_nomeProd.Text = nome


            End While
            drProduto.Close()


        Catch ex As Exception
            MsgBox("Tabela de PRODUTOS ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return False

        End Try

        CmdProduto.CommandText = "" : SqlProduto.Remove(_valorZERO, SqlProduto.ToString.Length)
        CmdProduto = Nothing : SqlProduto = Nothing : drProduto = Nothing
        oConnBDGENOV.ClearPool() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return True
    End Function

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

        'Verifica se foi informado algum Vendedor...
        If cbo_vendedor.SelectedIndex < _valorZERO Then

            lbl_mensagem.Text = "Selecione um VENDEDOR para o Pedido !" : dtp_emissao.Focus() : Return False

        End If

        'Verifica se foi informado alguma Condicao de pagamento...
        If cbo_condpgto.SelectedIndex < _valorZERO Then

            lbl_mensagem.Text = "Selecione uma Condição de Pagamento !" : dtp_emissao.Focus() : Return False

        End If

        'Verifica se foi informado alguma Forma de Pagamento...
        If cbo_forpgto.SelectedIndex < _valorZERO Then

            lbl_mensagem.Text = "Selecione uma Forma de Pagamento !" : dtp_emissao.Focus() : Return False

        End If

        If Me.dtg_pedidoprotaentrega.Rows.Count <= _valorZERO Then

            lbl_mensagem.Text = "Informe algum Item por favor !" : Return False

        End If



        Return True
    End Function

    Private Function verificaProduto() As Boolean

        lbl_mensagem.Text = ""

        Dim conection As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO::" & ex.Message) : Return False
        End Try

        Dim mqtdeAtual As Double = _clBD.pegaQtdeEstoque(codProd_Ref, FilialProd_Ref, conection)
        conection.ClearPool() : conection.Close() : conection = Nothing
        mqtdeAtual += _qtdeAnteriorProd

        If mqtdeAtual < CDbl(txt_qtde.Text) Then

            lbl_mensagem.Text = "Quantidade Requerida é Maior do que a do Estoque ! ""QtdeAtual = " & mqtdeAtual & """"
            Me.txt_qtde.Focus() : Me.txt_qtde.SelectAll() : Return False

        End If

        If Trim(Me.txt_codProd.Text).Equals("") Then

            lbl_mensagem.Text = "Produto não informado !" : Me.txt_codProd.Focus() : Return False

        End If

        If IsNumeric(Me.txt_valor.Text) Then

            If CDbl(Me.txt_valor.Text) = _valorZERO Then

                lbl_mensagem.Text = "Valor do Iten deve ser MAIOR que ZERO !"
                Me.txt_valor.Focus() : Return False

            End If
        Else

            lbl_mensagem.Text = "Valor inválido para o Iten !"
            Me.txt_valor.Focus() : Return False

        End If

        If _descVendedor > _valorZERO Then

            If CDbl(Me.txt_desconto.Text) < _valorZERO Then

                lbl_mensagem.Text = "Valor do Desconto de ser MAIOR ou IGUAL a ZERO !"
                Me.txt_desconto.Focus() : Return False
            End If

            If (CDbl(Me.txt_desconto.Text) > _valorZERO) AndAlso (CDbl(Me.txt_desconto.Text) > _descVendedor) Then

                lbl_mensagem.Text = "Valor do Desconto de ser MENOR ou IGUAL a " & _descVendedor & "% !"
                Me.txt_desconto.Focus() : Return False
            End If
        End If



        Return True
    End Function

    Private Sub addItemGrid()

        Try

            Dim mCodVendedor As String = "", mtipoComissVend As String = ""
            Dim mcomissionado As Boolean
            Dim mvltotal As Double
            Dim malqicms, malqcom, mcomis, mbasesub, malqsub, mvlcims As Double
            Dim mvlsub, malqdesc, mvldesc, mbaseicms, moutrasdesp As Double
            Dim mvldesconto As Double
            Dim mvlUnitVendPorItem, mvlSubPorItem, mvldescPorItem, mvlUnitItem As Double


            'Tratamento para Promoção...
            If IsDate(dtInicialPromocao_Ref) AndAlso IsDate(dtFinalPromocao_Ref) Then

                'Se a Promoção estiver dentro do período...
                If (dtp_emissao.Value >= dtInicialPromocao_Ref) AndAlso (dtp_emissao.Value <= dtFinalPromocao_Ref) Then

                    Me.ValorUnitProd_Ref = vlPromocao_Ref
                End If
            End If

            mvlUnitItem = ValorUnitProd_Ref
            mvltotal = Round((CDbl(txt_qtde.Text) * CDbl(txt_valor.Text)), 2)
            malqdesc = CDbl(Me.txt_desconto.Text)
            If malqdesc > _valorZERO Then

                mvldescPorItem = Round((CDbl(txt_valor.Text) * malqdesc) / 100, 2)
                mvldesc = Round(mvldescPorItem * CDbl(txt_qtde.Text), 2) 'Round((mvltotal * malqdesc) / 100, 2)
                mvltotal -= mvldesc
                mvlUnitVendPorItem = Round(CDbl(txt_valor.Text) - mvldescPorItem, 2)
            Else

                If CDbl(Me.txt_valor.Text) < ValorUnitProd_Ref Then

                    mvldescPorItem = Round((ValorUnitProd_Ref - CDbl(Me.txt_valor.Text)), 2)
                    mvldesc = Round(mvldescPorItem * CDbl(Me.txt_qtde.Text), 2)
                    mvlUnitVendPorItem = CDbl(txt_valor.Text)
                    'mvlUnitItem = mvlUnitVendPorItem
                Else
                    mvlUnitVendPorItem = CDbl(Me.txt_valor.Text)
                    'mvlUnitItem = mvlUnitVendPorItem
                End If
            End If


            'Tratamento da comissão do vendedor...
            mCodVendedor = Trim(Mid(cbo_vendedor.SelectedItem, 3, 4))
            mcomissionado = _clFuncoes.trazComissionadoVendedor(mCodVendedor, "G00" & Mid(Me.cbo_local.SelectedItem, 1, 2), MdlConexaoBD.conectionPadrao)
            If mcomissionado = True Then
                mtipoComissVend = _clFuncoes.trazTipoComissaoVendedor(mCodVendedor, "G00" & Mid(Me.cbo_local.SelectedItem, 1, 2), MdlConexaoBD.conectionPadrao)

                Select Case mtipoComissVend
                    Case "P" 'por Produto
                        malqcom = _clFuncoes.trazCom1Produto(MdlEmpresaUsu._esqVinc, codProd_Ref, MdlConexaoBD.conectionPadrao)

                    Case "T" 'por Total
                        malqcom = _clFuncoes.trazAlqComissVendedor(mCodVendedor, "G00" & Mid(Me.cbo_local.SelectedItem, 1, 2), MdlConexaoBD.conectionPadrao)

                    Case "L" 'por Liquedez
                        malqcom = _valorZERO

                End Select

            End If


            'Tratamento do ICMS NORMAL....
            'Se não for tributado...
            If (CfvProd_Ref = 4) OrElse (CfvProd_Ref = 3) Then

                mbaseicms = 0.0 : malqicms = 0.0 : mvlcims = 0.0
            Else 'Se for tributado...


                If mIsento = False Then 'Se o Cliente tiver que pagar imposto

                    mbaseicms = mvltotal
                    'Tratamento da Aliquota...
                    'Se a UF do Cliente for igual a dessa Empresa
                    If mbUf.ToUpper.Equals(MdlEmpresaUsu._uf.ToUpper) Then

                        malqicms = MdlEmpresaUsu._alqIcmsInterno

                        'Tratamento da Substituição Tributária...
                        'Se o cliente for CPF
                        If mbCNPJ.Equals("") Then


                            If MdlEmpresaUsu._alqSubst > _valorZERO Then 'Verifica se a empresa combra Subst.

                                If Me.txt_consumo.Text.Equals("N") Then 'Se não for para consumo

                                    Try
                                        malqsub = MdlEmpresaUsu._alqSubst
                                        mvlSubPorItem = Round(((mvlUnitVendPorItem * malqsub) / 100), 2)
                                        mvlsub = Round(mvlSubPorItem * CDbl(txt_qtde.Text), 2)
                                        mbasesub = Round((mvlsub * 100) / malqsub, 2)
                                        mvlUnitVendPorItem = Round(mvlUnitVendPorItem + mvlSubPorItem, 2)
                                    Catch ex As Exception
                                        mbasesub = 0 : malqsub = 0 : mvlsub = 0
                                    End Try
                                    mvltotal = Round(mvltotal + mvlsub, 2)
                                End If
                            End If
                        End If

                    Else
                        malqicms = MdlEmpresaUsu._alqIcmsExterno

                    End If
                    mvlcims = Round((mbaseicms * malqicms) / 100, 2)

                Else 'Se o Cliente NÃO tiver que pagar imposto

                    mbaseicms = 0.0 : malqicms = 0.0 : mvlcims = 0.0
                    mbasesub = 0.0 : malqsub = 0.0 : mvlsub = 0.0
                End If
            End If

            'Tratamento da Grade...
            objGrade.zeraValores()
            If gradeProd_Ref.Equals("S") Then
                objGrade.pCodig = txt_codProd.Text
                objGrade.pCor = codCorGrade_Ref
                objGrade.pTm = tamanhoGrade_Ref
                objGrade.pLoja = FilialProd_Ref
                objGrade.pQtde = CDbl(txt_qtde.Text)
                objGrade.pId = _clFuncoes.trazIdGrade(objGrade, MdlConexaoBD.conectionPadrao)

            End If

            If malqcom > 0 Then mcomis = Round(((mvltotal * malqcom) / 100), 2)

            Dim mlinha As String() = {_valorZERO, Mid(Me.cbo_local.SelectedItem, 1, 2), codProd_Ref, cdBarraProd_Ref, _
                                      txt_nomeProd.Text, UndProd_Ref, Format(CDbl(txt_qtde.Text), "###,##0.00"), _
                                      Format(mvlUnitVendPorItem, "###,##0.00"), _
                                      Format(mvltotal, "###,##0.00"), _
                                      Format(CDbl(CDbl(txt_qtde.Text) * pesoBrutoProd_Ref), "###,##0.00"), _
                                      Format(CDbl(CDbl(txt_qtde.Text) * pesoLiqProd_Ref), "###,##0.00"), malqicms, _
                                      LinhaProd_Ref, malqcom, mcomis, mbasesub, malqsub, mvlsub, GrupoProd_Ref, _
                                      malqdesc, mvldesc, FilialProd_Ref, mbaseicms, moutrasdesp, mvlcims, mvlUnitItem, _
                                      gradeProd_Ref, objGrade.pCor, objGrade.pTm, objGrade.pId}


            'Adicionando Linha
            Me.dtg_pedidoprotaentrega.Rows.Add(mlinha)
            Me.dtg_pedidoprotaentrega.Refresh()

            mlinha = Nothing
            Me.txt_total.Text = Format(somaVlrTotalItensGrid, "###,##0.00")
            Me.txt_peso.Text = Format(somaPesoBrutolItensGrid, "###,##0.000")
            Me.txt_descontosTotais.Text = Format(somaVlrTdescItensGrid, "###,##0.00")


            Select Case cbo_tipopedido.SelectedIndex

                Case 0, 3 'Venda ou Bonificação (Tira do Estoque)

                    'Subtrai a quantidade do Estoque a quantidade requerida para o Pedido...
                    Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Dim transacao As NpgsqlTransaction

                    conection.Open() : transacao = conection.BeginTransaction
                    _clBD.subtraiQtdeProdEstloja(txt_codProd.Text, FilialProd_Ref, CDbl(txt_qtde.Text), conection, transacao)


                    'Tratamento da Grade...
                    If gradeProd_Ref.Equals("S") Then
                        _clBD.atualizaQtdeGradeSubtraindo(conection, transacao, objGrade)
                    End If

                    transacao.Commit() : conection.ClearPool()

                    conection.Close() : conection = Nothing : mlinha = Nothing


                Case 1 'Pago a Entregar (Faz nada)
                    '-----------------------------
                Case 2 'Devolução (Acrescenta no Estoque)

                    'Soma a quantidade do Estoque a quantidade requerida para o Pedido...
                    Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Dim transacao As NpgsqlTransaction

                    conection.Open() : transacao = conection.BeginTransaction
                    _clBD.somaQtdeProdEstloja(txt_codProd.Text, FilialProd_Ref, CDbl(txt_qtde.Text), conection, transacao)

                    'Tratamento da Grade...
                    If gradeProd_Ref.Equals("S") Then
                        _clBD.atualizaQtdeGradeSomando(conection, transacao, objGrade)
                    End If

                    transacao.Commit() : conection.ClearPool()

                    conection.Close() : conection = Nothing : mlinha = Nothing


            End Select

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try



    End Sub

    Private Sub addItemEditadoGrid()

        Try

            Dim mCodVendedor As String = "", mtipoComissVend As String = ""
            Dim mcomissionado As Boolean
            Dim mvltotal As Double
            Dim malqicms, malqcom, mcomis, mbasesub, malqsub, mvlcims As Double
            Dim mvlsub, malqdesc, mvldesc, mbaseicms, moutrasdesp As Double
            Dim mvlUnitVendPorItem, mvlSubPorItem, mvldescPorItem, mvlUnitItem As Double


            mvlUnitItem = ValorUnitProd_Ref
            mvltotal = Round((CDbl(txt_qtde.Text) * CDbl(txt_valor.Text)), 2)
            malqdesc = CDbl(Me.txt_desconto.Text)
            If malqdesc > _valorZERO Then

                mvldescPorItem = Round((CDbl(txt_valor.Text) * malqdesc) / 100, 2)
                mvldesc = Round(mvldescPorItem * CDbl(txt_qtde.Text), 2) 'Round((mvltotal * malqdesc) / 100, 2)
                mvltotal -= mvldesc
                mvlUnitVendPorItem = Round(CDbl(txt_valor.Text) - mvldescPorItem, 2)
                'mvlUnitItem = mvlUnitVendPorItem
            Else

                If CDbl(Me.txt_valor.Text) < ValorUnitProd_Ref Then

                    mvldescPorItem = Round((ValorUnitProd_Ref - CDbl(Me.txt_valor.Text)), 2)
                    mvldesc = Round(mvldescPorItem * CDbl(Me.txt_qtde.Text), 2)
                    mvlUnitVendPorItem = CDbl(txt_valor.Text)
                    'mvlUnitItem = mvlUnitVendPorItem
                Else
                    mvlUnitVendPorItem = CDbl(Me.txt_valor.Text)
                    'mvlUnitItem = mvlUnitVendPorItem
                End If
            End If


            'Tratamento da comissão do vendedor...
            mCodVendedor = Trim(Mid(cbo_vendedor.SelectedItem, 3, 4))
            mcomissionado = _clFuncoes.trazComissionadoVendedor(mCodVendedor, "G00" & Mid(Me.cbo_local.SelectedItem, 1, 2), MdlConexaoBD.conectionPadrao)
            If mcomissionado = True Then
                mtipoComissVend = _clFuncoes.trazTipoComissaoVendedor(mCodVendedor, "G00" & Mid(Me.cbo_local.SelectedItem, 1, 2), MdlConexaoBD.conectionPadrao)

                Select Case mtipoComissVend
                    Case "P" 'por Produto
                        malqcom = _clFuncoes.trazCom1Produto(MdlEmpresaUsu._esqVinc, codProd_Ref, MdlConexaoBD.conectionPadrao)

                    Case "T" 'por Total
                        malqcom = _clFuncoes.trazAlqComissVendedor(mCodVendedor, "G00" & Mid(Me.cbo_local.SelectedItem, 1, 2), MdlConexaoBD.conectionPadrao)

                    Case "L" 'por Liquedez
                        malqcom = _valorZERO

                End Select

            End If


            'Tratamento do ICMS NORMAL....
            'Se não for tributado...
            If (CfvProd_Ref = 4) OrElse (CfvProd_Ref = 3) Then

                mbaseicms = 0.0 : malqicms = 0.0 : mvlcims = 0.0

            Else 'Se for tributado...


                If mIsento = False Then 'Se o Cliente tiver que pagar imposto

                    mbaseicms = mvltotal
                    'Tratamento da Aliquota...
                    'Se a UF do Cliente for igual a dessa Empresa
                    If mbUf.ToUpper.Equals(MdlEmpresaUsu._uf.ToUpper) Then

                        malqicms = MdlEmpresaUsu._alqIcmsInterno

                        'Tratamento da Substituição Tributária...
                        'Se o cliente for CPF
                        If mbCNPJ.Equals("") Then


                            If MdlEmpresaUsu._alqSubst > _valorZERO Then 'Verifica se a empresa combra Subst.

                                If Me.txt_consumo.Text.Equals("N") Then 'Se não for para consumo

                                    Try
                                        malqsub = MdlEmpresaUsu._alqSubst
                                        mvlSubPorItem = Round(((mvlUnitVendPorItem * malqsub) / 100), 2)
                                        mvlsub = Round(mvlSubPorItem * CDbl(txt_qtde.Text), 2)
                                        mbasesub = Round((mvlsub * 100) / malqsub, 2)
                                        mvlUnitVendPorItem = Round(mvlUnitVendPorItem + mvlSubPorItem, 2)
                                    Catch ex As Exception
                                        mbasesub = 0 : malqsub = 0 : mvlsub = 0
                                    End Try
                                    mvltotal = Round(mvltotal + mvlsub, 2)
                                End If
                            End If
                        End If

                    Else
                        malqicms = MdlEmpresaUsu._alqIcmsExterno

                    End If
                    mvlcims = Round((mbaseicms * (malqicms / 100)), 2)

                Else 'Se o Cliente NÃO tiver que pagar imposto

                    mbaseicms = 0.0 : malqicms = 0.0 : mvlcims = 0.0
                    mbasesub = 0.0 : malqsub = 0.0 : mvlsub = 0.0
                End If
            End If

            'Tratamento da Grade...
            objGrade.zeraValores()
            If gradeProd_Ref.Equals("S") Then

                objGrade.pCodig = txt_codProd.Text
                objGrade.pCor = codCorGrade_Ref
                objGrade.pTm = tamanhoGrade_Ref
                objGrade.pLoja = FilialProd_Ref
                objGrade.pQtde = CDbl(txt_qtde.Text)
                objGrade.pId = _clFuncoes.trazIdGrade(objGrade, MdlConexaoBD.conectionPadrao)
            End If

            If malqcom > 0 Then mcomis = Round(((mvltotal * malqcom) / 100), 2)

            Dim mlinha As String() = {_valorZERO, Mid(Me.cbo_local.SelectedItem, 1, 2), codProd_Ref, cdBarraProd_Ref, _
                                      txt_nomeProd.Text, UndProd_Ref, Format(CDbl(txt_qtde.Text), "###,##0.00"), _
                                      Format(mvlUnitVendPorItem, "###,##0.00"), _
                                      Format(mvltotal, "###,##0.00"), _
                                      Format(CDbl(CDbl(txt_qtde.Text) * pesoBrutoProd_Ref), "###,##0.00"), _
                                      Format(CDbl(CDbl(txt_qtde.Text) * pesoLiqProd_Ref), "###,##0.00"), malqicms, _
                                      LinhaProd_Ref, malqcom, mcomis, mbasesub, malqsub, mvlsub, GrupoProd_Ref, _
                                      malqdesc, mvldesc, FilialProd_Ref, mbaseicms, moutrasdesp, mvlcims, mvlUnitItem, _
                                      gradeProd_Ref, objGrade.pCor, objGrade.pTm, objGrade.pId}

            'Adicionando Linha
            Me.dtg_pedidoprotaentrega.Rows(_indexProdEditando).SetValues(mlinha)
            Me.dtg_pedidoprotaentrega.Refresh()

            Me.txt_total.Text = Format(somaVlrTotalItensGrid, "###,##0.00")
            Me.txt_peso.Text = Format(somaPesoBrutolItensGrid, "###,##0.000")
            Me.txt_descontosTotais.Text = Format(somaVlrTdescItensGrid, "###,##0.00")


            Select Case cbo_tipopedido.SelectedIndex

                Case 0, 3 'Venda ou Bonificação (Tira do Estoque)

                    'Atualiza a quantidade do Estoque do produto requerido para o Pedido...
                    If txt_codProd.Text.Equals(_codProdEditando) Then

                        If CDbl(txt_qtde.Text) <> _qtdeAnteriorProd Then

                            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                            Dim transacao As NpgsqlTransaction
                            Dim mNovaQtde As Double = _valorZERO
                            conection.Open()
                            transacao = conection.BeginTransaction

                            If CDbl(txt_qtde.Text) < _qtdeAnteriorProd Then
                                mNovaQtde = _qtdeAnteriorProd - CDbl(txt_qtde.Text)
                                _clBD.somaQtdeProdEstloja(txt_codProd.Text, FilialProd_Ref, mNovaQtde, conection, transacao)

                                'Tratamento da Grade...
                                If gradeProd_Ref.Equals("S") Then
                                    objGrade.pQtde = mNovaQtde
                                    _clBD.atualizaQtdeGradeSomando(conection, transacao, objGrade)
                                End If

                            ElseIf CDbl(txt_qtde.Text) > _qtdeAnteriorProd Then
                                mNovaQtde = CDbl(txt_qtde.Text) - _qtdeAnteriorProd
                                _clBD.subtraiQtdeProdEstloja(txt_codProd.Text, FilialProd_Ref, mNovaQtde, conection, transacao)

                                'Tratamento da Grade...
                                If gradeProd_Ref.Equals("S") Then
                                    objGrade.pQtde = mNovaQtde
                                    _clBD.atualizaQtdeGradeSubtraindo(conection, transacao, objGrade)
                                End If

                            End If

                            transacao.Commit() : conection.ClearPool() : conection.Close() : conection = Nothing


                        End If
                    Else

                        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                        Dim transacao As NpgsqlTransaction
                        conection.Open()
                        transacao = conection.BeginTransaction

                        _clBD.subtraiQtdeProdEstloja(txt_codProd.Text, FilialProd_Ref, CDbl(txt_qtde.Text), conection, transacao)

                        'Tratamento da Grade...
                        If gradeProd_Ref.Equals("S") Then
                            _clBD.atualizaQtdeGradeSubtraindo(conection, transacao, objGrade)
                        End If

                        transacao.Commit() : conection.ClearPool() : conection.Close() : conection = Nothing


                    End If


                Case 1 'Pago a Entregar (Faz nada)
                    '-----------------------------
                Case 2 'Devolução (Acrescenta no Estoque)

                    'Atualiza a quantidade do Estoque do produto requerido para o Pedido...
                    If txt_codProd.Text.Equals(_codProdEditando) Then

                        If CDbl(txt_qtde.Text) <> _qtdeAnteriorProd Then

                            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                            Dim transacao As NpgsqlTransaction
                            Dim mNovaQtde As Double = _valorZERO
                            conection.Open()
                            transacao = conection.BeginTransaction

                            If CDbl(txt_qtde.Text) < _qtdeAnteriorProd Then
                                mNovaQtde = _qtdeAnteriorProd - CDbl(txt_qtde.Text)
                                _clBD.subtraiQtdeProdEstloja(txt_codProd.Text, FilialProd_Ref, mNovaQtde, conection, transacao)

                                'Tratamento da Grade...
                                If gradeProd_Ref.Equals("S") Then
                                    objGrade.pQtde = mNovaQtde
                                    _clBD.atualizaQtdeGradeSubtraindo(conection, transacao, objGrade)
                                End If

                            ElseIf CDbl(txt_qtde.Text) > _qtdeAnteriorProd Then
                                mNovaQtde = CDbl(txt_qtde.Text) - _qtdeAnteriorProd
                                _clBD.somaQtdeProdEstloja(txt_codProd.Text, FilialProd_Ref, mNovaQtde, conection, transacao)

                                'Tratamento da Grade...
                                If gradeProd_Ref.Equals("S") Then
                                    objGrade.pQtde = mNovaQtde
                                    _clBD.atualizaQtdeGradeSomando(conection, transacao, objGrade)
                                End If

                            End If

                            transacao.Commit() : conection.ClearPool() : conection.Close() : conection = Nothing


                        End If
                    Else

                        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                        Dim transacao As NpgsqlTransaction
                        conection.Open()
                        transacao = conection.BeginTransaction

                        _clBD.somaQtdeProdEstloja(txt_codProd.Text, FilialProd_Ref, CDbl(txt_qtde.Text), conection, transacao)

                        'Tratamento da Grade...
                        If gradeProd_Ref.Equals("S") Then
                            _clBD.atualizaQtdeGradeSomando(conection, transacao, objGrade)
                        End If

                        transacao.Commit() : conection.ClearPool() : conection.Close() : conection = Nothing


                    End If


            End Select

            _codProdEditando = "" : _indexProdEditando = -1 : mlinha = Nothing
        Catch ex As Exception

            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try



    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        If verificaProduto() Then


            If _codProdEditando.Equals("") Then

                If colunaDuplicada(Me.txt_codProd.Text) = False Then


                    addItemGrid()

                    If _numPedidoTemp.Equals("") = False Then

                        executaIncluiOrca2TblTemp()
                    End If
                End If

            Else

                addItemEditadoGrid()
                If _numPedidoTemp.Equals("") = False Then

                    executaIncluiOrca2TblTemp()
                End If
            End If

            local_ref = Mid(Me.cbo_local.SelectedItem, 1, 2) : FilialProd_Ref = Mid(Me.cbo_local.SelectedItem, 1, 2)
            Me.txt_codProd.Text = "" : Me.txt_qtde.Text = "1,00" : Me.txt_valor.Text = "0,00"
            Me.txt_desconto.Text = "0,00" : xcont = xcont + 1 : Me.txt_codProd.Focus() : _qtdeAnteriorProd = _valorZERO

            If Me.dtg_pedidoprotaentrega.Rows.Count > _valorZERO Then

                limpaCamposRegistroProd()
            End If
        End If
        _editandoProduto = False : _qtdeAnteriorProd = 0

    End Sub

    Private Sub executaIncluiOrca2TblTemp()

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

            incluiDtg_itensPedidoTemporaria(conexao, transacao)

            transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
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

    End Sub

    Private Sub incluiDtg_itensPedidoTemporaria(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mUsuario As String = Me.txt_operador.Text
        Dim mCodpr, MUnd, mCodVendedor, mFilial, mcdBarra As String
        Dim mQtde As Double = CDbl(Me.txt_qtde.Text)
        Dim mPrvenda, mPrunit, mDesc, mtotal, mpesoLiq, mpesoBruto, mbaseIcms, moutrasDesp As Double
        Dim malqicms, malqcom, mcomis, mbasesub, malqsub, mvlsub, malqdesc, mvldesc As Double
        Dim mvlicms As Double
        Dim mdtemis As Date
        Dim mLinha, mGrupo, mrota, midGrade As Integer

        mCodVendedor = Trim(Mid(cbo_vendedor.SelectedItem, 1, 6))

        mrota = 0
        If cbo_rota.SelectedIndex >= _valorZERO Then mrota = CInt(Trim(Mid(cbo_rota.SelectedItem, 1, 3)))

        _clBD.delPedido_Orca2Temporaria(_numPedidoTemp, Mid(Me.cbo_local.SelectedItem, 1, 2), conexao, transacao)

        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

            If Not row.IsNewRow Then

                mCodpr = row.Cells(2).Value
                mcdBarra = row.Cells(3).Value
                MUnd = row.Cells(5).Value
                mQtde = row.Cells(6).Value
                mPrunit = row.Cells(25).Value
                mPrvenda = row.Cells(7).Value
                mDesc = CDbl(txt_desconto.Text)
                mtotal = row.Cells(8).Value
                mdtemis = DateValue(dtp_emissao.Text)
                mpesoBruto = row.Cells(9).Value
                mpesoLiq = row.Cells(10).Value
                malqicms = row.Cells(11).Value
                mLinha = row.Cells(12).Value
                malqcom = row.Cells(13).Value
                mcomis = row.Cells(14).Value
                mbasesub = row.Cells(15).Value
                malqsub = row.Cells(16).Value
                mvlsub = row.Cells(17).Value
                mGrupo = row.Cells(18).Value
                malqdesc = row.Cells(19).Value
                mvldesc = row.Cells(20).Value
                mFilial = row.Cells(21).Value
                mbaseIcms = row.Cells(22).Value
                moutrasDesp = row.Cells(23).Value
                mvlicms = row.Cells(24).Value
                mtotal = Round(mtotal - mvlsub, 2)
                midGrade = row.Cells(29).Value


                _clBD.incPedido_Orca2Temporaria(Mid(cbo_local.SelectedItem, 1, 2), _numPedidoTemp, mCodpr, MUnd, mQtde, mPrvenda, malqdesc, _
                                       mvldesc, mPrunit, mtotal, malqicms, mbaseIcms, mbasesub, malqsub, mvlsub, _
                                       mdtemis, mrota, "01", mCodVendedor, mLinha, mGrupo, malqcom, mcomis, _valorZERO, _
                                       mIdOrca1ppTemp, 2, Me.txt_codpart.Text, mFilial, mpesoBruto, mpesoLiq, mcdBarra, _
                                       moutrasDesp, mvlicms, midGrade, conexao, transacao)

            End If
        Next

        'LIMPA OBJETOS DA MEMÓRIA...
        mCodpr = Nothing : MUnd = Nothing : mQtde = Nothing : mPrvenda = Nothing
        mPrunit = Nothing : mDesc = Nothing : mtotal = Nothing : mdtemis = Nothing



    End Sub

    Private Sub limpaCamposRegistroProd()

        Me.cbo_local.Enabled = False ': Me.cbo_gerente.Enabled = False
        Me.msk_senha.Enabled = False ' : Me.msk_senha.Text = ""
        'Me.cbo_vendedor.Enabled = False
        Me.txt_nomeProd.Text = ""

    End Sub



    Private Sub zeraTudo()
        dtp_emissao.Value = Date.Now 'cbo_local.SelectedIndex = -1 : 

        'Zera dados cliente...
        Me.txt_codpart.Text = "" : Me.txt_nomePart.Text = ""
        mbCNPJ = "" : mbCPF = "" : mbUf = "" : mNomePart = ""
        mCodPart = "" : mCepPart = "" : mCidadePart = ""
        mEnderecoPart = "" : cbo_gerente.SelectedIndex = -1

        Me.msk_senha.Text = "" : cbo_tipopedido.SelectedIndex = -1
        cbo_rota.SelectedIndex = -1 : Me.txt_consumo.Text = ""
        cbo_vendedor.SelectedIndex = -1 : cbo_condpgto.SelectedIndex = -1
        cbo_forpgto.SelectedIndex = -1 : Me.txt_obs.Text = ""
        Me.txt_cond1.Text = "0" : Me.txt_cond2.Text = "0"
        Me.txt_cond3.Text = "0" : Me.txt_cond4.Text = "0"
        Me.txt_cond5.Text = "0" : Me.txt_cond6.Text = "0"
        Me.txt_cond7.Text = "0" : Me.txt_peso.Text = "0,00"
        Me.txt_total.Text = "0,00" : Me.txt_descontosTotais.Text = "0,00"

        'Zera dados produto...
        Me.txt_codProd.Text = "" : Me.txt_nomeProd.Text = ""
        Me.txt_qtde.Text = "1,00" : Me.txt_valor.Text = "0,00"
        Me.txt_desconto.Text = "0,00"
        codProd_Ref = "" : nomeProd_Ref = "" : UndProd_Ref = ""
        codBarraProd_Ref = "" : local_ref = "" : ClfProd_Ref = ""
        FilialProd_Ref = "" : cdBarraProd_Ref = "" : CstProd_Ref = _valorZERO
        CfvProd_Ref = _valorZERO : GrupoProd_Ref = _valorZERO
        ReduzProd_Ref = _valorZERO : LinhaProd_Ref = _valorZERO
        pesoLiqProd_Ref = _valorZERO : pesoBrutoProd_Ref = _valorZERO
        ValorUnitProd_Ref = _valorZERO : qtdeProd_Ref = _valorZERO

        Me.dtg_pedidoprotaentrega.Rows.Clear() : Me.dtg_pedidoprotaentrega.Refresh()
        lbl_mensagem.Text = "" : mNumPedido = "" : mIdOrca1pp = _valorZERO
        _qtdeAnteriorProd = _valorZERO : _codProdEditando = "" : _indexProdEditando = _valorZERO


    End Sub

    Private Function colunaDuplicada(ByVal codProduto As String) As Boolean

        lbl_mensagem.Text = ""
        'Verifica se Produto já existe no Grid...
        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

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

    Private Sub alteraRegistroPedido(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim nt_orca, nt_geno, nt_codig, nt_cfop, nt_vend, nt_cid, nt_x, nt_y As String
        Dim nt_tipo2, nt_auto, nt_auto2, nt_descrcondpagto As String
        Dim nt_dtemis, nt_dtsai As Date
        Dim nt_emiss As Boolean = False
        Dim nt_rota, nt_parc, nt_cod1, nt_cod2, nt_cod3, nt_cod4, nt_cod5 As Integer
        Dim nt_cod6, nt_cod7, nt_mapa, nt_sit, nt_itens As Integer
        Dim nt_peso, nt_volum, nt_entrada As Double

        nt_geno = MdlUsuarioLogando._local
        nt_codig = mCodPart
        nt_dtemis = dtp_emissao.Value
        nt_dtsai = nt_dtemis
        nt_emiss = False
        nt_cfop = "5102"
        nt_vend = Trim(Mid(cbo_vendedor.SelectedItem, 1, 6))
        nt_cid = mCidadePart
        nt_itens = Me.dtg_pedidoprotaentrega.Rows.Count

        Try
            nt_rota = CInt(cbo_rota.SelectedItem)
        Catch ex As Exception
            nt_rota = _valorZERO
        End Try

        nt_peso = CDbl(Me.txt_peso.Text)
        nt_x = "" : nt_y = ""

        'Trata Quantidade de parcelas...
        nt_parc = _valorZERO : nt_cod1 = _valorZERO : nt_cod2 = _valorZERO : nt_cod3 = _valorZERO
        nt_cod4 = _valorZERO : nt_cod5 = _valorZERO : nt_cod6 = _valorZERO : nt_cod7 = _valorZERO
        If IsNumeric(txt_cond1.Text) AndAlso CInt(txt_cond1.Text) > _valorZERO Then nt_parc += 1 : nt_cod1 = CInt(txt_cond1.Text)
        If IsNumeric(txt_cond2.Text) AndAlso CInt(txt_cond2.Text) > _valorZERO Then nt_parc += 1 : nt_cod2 = CInt(txt_cond2.Text)
        If IsNumeric(txt_cond3.Text) AndAlso CInt(txt_cond3.Text) > _valorZERO Then nt_parc += 1 : nt_cod3 = CInt(txt_cond3.Text)
        If IsNumeric(txt_cond4.Text) AndAlso CInt(txt_cond4.Text) > _valorZERO Then nt_parc += 1 : nt_cod4 = CInt(txt_cond4.Text)
        If IsNumeric(txt_cond5.Text) AndAlso CInt(txt_cond5.Text) > _valorZERO Then nt_parc += 1 : nt_cod5 = CInt(txt_cond5.Text)
        If IsNumeric(txt_cond6.Text) AndAlso CInt(txt_cond6.Text) > _valorZERO Then nt_parc += 1 : nt_cod6 = CInt(txt_cond6.Text)
        If IsNumeric(txt_cond7.Text) AndAlso CInt(txt_cond7.Text) > _valorZERO Then nt_parc += 1 : nt_cod7 = CInt(txt_cond7.Text)


        nt_volum = somaVolumeItensGrid()
        nt_tipo2 = cbo_forpgto.SelectedItem
        nt_auto = MdlUsuarioLogando._usuarioLogin
        nt_auto2 = ""
        nt_mapa = _mapaPedido

        'nt_sit -- Verifica status do Pedido 1-Digitado , 2-Impresso, 3 - ECF , 4-NFe
        nt_sit = 1
        nt_entrada = CDbl(Me.txt_entrada.Text)
        nt_descrcondpagto = cbo_condpgto.SelectedItem

        'Numero do pedido...
        nt_orca = Me.txt_pedido.Text : mNumPedido = nt_orca

        _clBD.altPedido_Orca1(nt_orca, nt_geno, nt_codig, nt_dtemis, nt_dtsai, nt_emiss, nt_cfop, _
                              nt_vend, nt_cid, nt_itens, nt_rota, nt_peso, nt_x, nt_y, nt_parc, _
                              nt_volum, nt_tipo2, nt_auto, nt_auto2, nt_cod1, nt_cod2, nt_cod3, _
                              nt_cod4, nt_cod5, nt_cod6, nt_cod7, nt_mapa, nt_sit, mbUf, _
                              nt_entrada, nt_descrcondpagto, conexao, transacao)

        mIdOrca1pp = _clBD.trazIdOrca1pp(conexao, nt_orca)



    End Sub

    Private Sub alteraOrca4(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim tipo As String = "", nume As String = "", pgto As String = "", tipo2 As String = ""
        Dim tprod, aliss, vliss, vlser, basec, icms, bsub, icsub, tpro2, frete As Double
        Dim segu, outros, ipi, tgeral, peso, desc As Double

        tipo = "P" : nume = mNumPedido : tipo2 = cbo_forpgto.SelectedItem

        tprod = somaVlrTprodItensGrid()
        tpro2 = tprod
        basec = somaVlrTbcicmsItensGrid()
        icms = somaVlrTicmsItensGrid()
        bsub = somaVlrTbcsubItensGrid()
        icsub = somaVlrTsubItensGrid()
        tgeral = somaVlrTotalItensGrid()
        peso = somaPesoBrutolItensGrid()
        desc = somaVlrTdescItensGrid()
        'tgeral = Round(tgeral + icsub, 2)

        _clBD.altPedido_Orca4(tipo, nume, tprod, aliss, vliss, vlser, basec, icms, bsub, icsub, tpro2, _
                              frete, segu, outros, ipi, tgeral, pgto, peso, desc, tipo2, conexao, transacao)

    End Sub

    Private Function somaVlrTotalItensGrid() As Double

        Dim mVlrTotalItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

            If Not row.IsNewRow Then mVlrTotalItens += row.Cells(8).Value

        Next

        mVlrTotalItens = Round(mVlrTotalItens, 2)
        Return mVlrTotalItens
    End Function

    Private Function somaVlrTprodItensGrid() As Double

        Dim mVlrTprodItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows
            'vlTprod = pcoUnitario * vlUnitario
            If Not row.IsNewRow Then mVlrTprodItens += (row.Cells(6).Value * row.Cells(25).Value)

        Next

        mVlrTprodItens = Round(mVlrTprodItens, 2)
        Return mVlrTprodItens
    End Function

    Private Function somaVlrTbcicmsItensGrid() As Double

        Dim mVlrTbcicmsItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

            If Not row.IsNewRow Then mVlrTbcicmsItens += row.Cells(22).Value

        Next

        mVlrTbcicmsItens = Round(mVlrTbcicmsItens, 2)
        Return mVlrTbcicmsItens
    End Function

    Private Function somaVlrTicmsItensGrid() As Double

        Dim mVlrTicmsItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

            If Not row.IsNewRow Then mVlrTicmsItens += row.Cells(24).Value

        Next

        mVlrTicmsItens = Round(mVlrTicmsItens, 2)
        Return mVlrTicmsItens
    End Function

    Private Function somaVlrTbcsubItensGrid() As Double

        Dim mVlrTbcsubItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

            If Not row.IsNewRow Then mVlrTbcsubItens += row.Cells(15).Value

        Next

        mVlrTbcsubItens = Round(mVlrTbcsubItens, 2)
        Return mVlrTbcsubItens
    End Function

    Private Function somaVlrTsubItensGrid() As Double

        Dim mVlrTsubItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

            If Not row.IsNewRow Then mVlrTsubItens += row.Cells(17).Value

        Next

        mVlrTsubItens = Round(mVlrTsubItens, 2)
        Return mVlrTsubItens
    End Function

    Private Function somaVlrTdescItensGrid() As Double

        Dim mVlrTdescItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

            If Not row.IsNewRow Then mVlrTdescItens += row.Cells(20).Value

        Next

        mVlrTdescItens = Round(mVlrTdescItens, 2)
        Return mVlrTdescItens
    End Function

    Private Function somaVolumeItensGrid() As Double

        Dim mVolume As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

            If Not row.IsNewRow Then mVolume += row.Cells(6).Value

        Next

        mVolume = Round(mVolume, 2)
        Return mVolume
    End Function

    Private Function somaPesoBrutolItensGrid() As Double

        Dim mPesoBrutoItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

            If Not row.IsNewRow Then mPesoBrutoItens += (row.Cells(9).Value * row.Cells(6).Value)

        Next

        mPesoBrutoItens = Round(mPesoBrutoItens, 3)
        Return mPesoBrutoItens
    End Function

    Private Function somaVlrTcomisItensGrid() As Double

        Dim mVlrTcomisItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

            If Not row.IsNewRow Then mVlrTcomisItens += row.Cells(14).Value

        Next

        mVlrTcomisItens = Round(mVlrTcomisItens, 2)
        Return mVlrTcomisItens
    End Function

    Private Sub incluiRegistroPedido(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim nt_orca, nt_geno, nt_codig, nt_cfop, nt_vend, nt_cid, nt_x, nt_y As String
        Dim nt_tipo2, nt_auto, nt_auto2, nt_descrcondpagto As String
        Dim nt_dtemis, nt_dtsai As Date
        Dim nt_emiss As Boolean = False
        Dim itens, nt_rota, nt_parc, nt_cod1, nt_cod2, nt_cod3, nt_cod4, nt_cod5, nt_tiposelecao As Integer
        Dim nt_cod6, nt_cod7, nt_mapa, nt_sit, mProxNumPedido, nt_itens, nt_parcelas As Integer
        Dim nt_peso, nt_volum, nt_entrada As Double

        nt_geno = MdlUsuarioLogando._local
        nt_codig = mCodPart
        nt_dtemis = dtp_emissao.Value
        nt_dtsai = nt_dtemis
        nt_emiss = False
        nt_cfop = "5102"
        nt_vend = Trim(Mid(cbo_vendedor.SelectedItem, 1, 6))
        nt_cid = mCidadePart
        nt_itens = Me.dtg_pedidoprotaentrega.Rows.Count

        nt_tiposelecao = _valorZERO
        If cbo_tipopedido.SelectedIndex >= _valorZERO Then nt_tiposelecao = cbo_tipopedido.SelectedIndex

        Try
            nt_rota = CInt(cbo_rota.SelectedItem)
        Catch ex As Exception
            nt_rota = _valorZERO
        End Try

        nt_peso = CDbl(Me.txt_peso.Text)
        nt_x = "" : nt_y = ""

        'Trata Quantidade de parcelas...
        nt_parc = _valorZERO : nt_cod1 = _valorZERO : nt_cod2 = _valorZERO : nt_cod3 = _valorZERO
        nt_cod4 = _valorZERO : nt_cod5 = _valorZERO : nt_cod6 = _valorZERO : nt_cod7 = _valorZERO
        If IsNumeric(txt_cond1.Text) AndAlso CInt(txt_cond1.Text) > _valorZERO Then nt_parc += 1 : nt_cod1 = CInt(txt_cond1.Text)
        If IsNumeric(txt_cond2.Text) AndAlso CInt(txt_cond2.Text) > _valorZERO Then nt_parc += 1 : nt_cod2 = CInt(txt_cond2.Text)
        If IsNumeric(txt_cond3.Text) AndAlso CInt(txt_cond3.Text) > _valorZERO Then nt_parc += 1 : nt_cod3 = CInt(txt_cond3.Text)
        If IsNumeric(txt_cond4.Text) AndAlso CInt(txt_cond4.Text) > _valorZERO Then nt_parc += 1 : nt_cod4 = CInt(txt_cond4.Text)
        If IsNumeric(txt_cond5.Text) AndAlso CInt(txt_cond5.Text) > _valorZERO Then nt_parc += 1 : nt_cod5 = CInt(txt_cond5.Text)
        If IsNumeric(txt_cond6.Text) AndAlso CInt(txt_cond6.Text) > _valorZERO Then nt_parc += 1 : nt_cod6 = CInt(txt_cond6.Text)
        If IsNumeric(txt_cond7.Text) AndAlso CInt(txt_cond7.Text) > _valorZERO Then nt_parc += 1 : nt_cod7 = CInt(txt_cond7.Text)


        nt_volum = somaVolumeItensGrid()
        nt_tipo2 = cbo_forpgto.SelectedItem
        nt_auto = MdlUsuarioLogando._usuarioLogin
        nt_auto2 = ""
        nt_mapa = _valorZERO

        'nt_sit -- Verifica status do Pedido 1-Digitado , 2-Impresso, 3 - ECF , 4-NFe
        nt_sit = 1
        nt_entrada = CDbl(Me.txt_entrada.Text)
        nt_descrcondpagto = cbo_condpgto.SelectedItem

        nt_parcelas = 0
        If nt_tipo2.ToUpper.Equals("AV") = False Then

            If MdlEmpresaUsu.tipoCondPagto = 1 Then
                Dim marray As Array = Split(nt_descrcondpagto, "/")
                nt_parcelas = marray.Length

            Else

                Try
                    nt_parcelas = CInt(Trim(Mid(nt_descrcondpagto, 1, 2)))
                Catch ex As Exception
                    nt_parcelas = 1
                End Try
            End If
        End If

        ''Numero do pedido...
        nt_orca = mNumPedido
        'nt_orca = _clBD.trazProxNumPedido(nt_geno, conexao) : mNumPedido = nt_orca
        'mProxNumPedido = CInt(nt_orca) + 1
        '_clBD.updateGenp001NumPedido(nt_geno, String.Format("{0:D8}", mProxNumPedido), conexao, transacao)

        _clBD.incPedido_Orca1(nt_orca, nt_geno, nt_codig, nt_dtemis, nt_dtsai, nt_emiss, nt_cfop, _
                              nt_vend, nt_cid, nt_itens, nt_rota, nt_peso, nt_x, nt_y, nt_parc, _
                              nt_volum, nt_tipo2, nt_auto, nt_auto2, nt_cod1, nt_cod2, nt_cod3, _
                              nt_cod4, nt_cod5, nt_cod6, nt_cod7, nt_mapa, nt_sit, mbUf, nt_tiposelecao, _
                              nt_entrada, nt_descrcondpagto, nt_parcelas, conexao, transacao)

        mIdOrca1pp = _clBD.trazIdOrca1pp(conexao, nt_orca)



    End Sub

    Private Sub incluiDtg_itens(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mUsuario As String = Me.txt_operador.Text
        Dim mCodpr, MUnd, mCodVendedor, mFilial, mcdBarra As String
        Dim mQtde As Double = CDbl(Me.txt_qtde.Text)
        Dim mPrvenda, mPrunit, mDesc, mtotal, mpesoLiq, mpesoBruto, mbaseIcms, moutrasDesp As Double
        Dim malqicms, malqcom, mcomis, mbasesub, malqsub, mvlsub, malqdesc, mvldesc As Double
        Dim mvlicms As Double
        Dim mdtemis As Date
        Dim mLinha, mGrupo, mrota, mmapa, midGrade As Integer

        mCodVendedor = Trim(Mid(cbo_vendedor.SelectedItem, 1, 6))
        mmapa = _mapaPedido : mrota = 0
        If cbo_rota.SelectedIndex >= _valorZERO Then mrota = CInt(Trim(Mid(cbo_rota.SelectedItem, 1, 3)))

        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

            If Not row.IsNewRow Then

                mCodpr = row.Cells(2).Value
                mcdBarra = row.Cells(3).Value
                MUnd = row.Cells(5).Value
                mQtde = row.Cells(6).Value
                mPrunit = row.Cells(25).Value
                mPrvenda = row.Cells(7).Value
                mDesc = CDbl(txt_desconto.Text)
                mtotal = row.Cells(8).Value
                mdtemis = DateValue(dtp_emissao.Text)
                mpesoBruto = row.Cells(9).Value
                mpesoLiq = row.Cells(10).Value
                malqicms = row.Cells(11).Value
                mLinha = row.Cells(12).Value
                malqcom = row.Cells(13).Value
                mcomis = row.Cells(14).Value
                mbasesub = row.Cells(15).Value
                malqsub = row.Cells(16).Value
                mvlsub = row.Cells(17).Value
                mGrupo = row.Cells(18).Value
                malqdesc = row.Cells(19).Value
                mvldesc = row.Cells(20).Value
                mFilial = row.Cells(21).Value
                mbaseIcms = row.Cells(22).Value
                moutrasDesp = row.Cells(23).Value
                mvlicms = row.Cells(24).Value
                mtotal = Round(mtotal - mvlsub, 2)
                midGrade = row.Cells(29).Value


                _clBD.incPedido_Orca2(Mid(cbo_local.SelectedItem, 1, 2), mNumPedido, mCodpr, MUnd, mQtde, mPrvenda, malqdesc, _
                                       mvldesc, mPrunit, mtotal, malqicms, mbaseIcms, mbasesub, malqsub, mvlsub, _
                                       mdtemis, mrota, "01", mCodVendedor, mLinha, mGrupo, malqcom, mcomis, mmapa, _
                                       mIdOrca1pp, 2, Me.txt_codpart.Text, mFilial, mpesoBruto, mpesoLiq, mcdBarra, _
                                       moutrasDesp, mvlicms, midGrade, conexao, transacao)

            End If
        Next

        'LIMPA OBJETOS DA MEMÓRIA...
        mCodpr = Nothing : MUnd = Nothing : mQtde = Nothing : mPrvenda = Nothing
        mPrunit = Nothing : mDesc = Nothing : mtotal = Nothing : mdtemis = Nothing



    End Sub

    Private Sub inclueOrca4(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim tipo As String = "", nume As String = "", pgto As String = "", tipo2 As String = ""
        Dim tprod, aliss, vliss, vlser, basec, icms, bsub, icsub, tpro2, frete As Double
        Dim segu, outros, ipi, tgeral, peso, desc, comis As Double

        tipo = "P" : nume = mNumPedido : tipo2 = cbo_forpgto.SelectedItem

        tprod = somaVlrTprodItensGrid()
        tpro2 = tprod
        basec = somaVlrTbcicmsItensGrid()
        icms = somaVlrTicmsItensGrid()
        bsub = somaVlrTbcsubItensGrid()
        icsub = somaVlrTsubItensGrid()
        tgeral = somaVlrTotalItensGrid()
        peso = somaPesoBrutolItensGrid()
        desc = somaVlrTdescItensGrid()
        comis = somaVlrTcomisItensGrid()
        'tgeral = Round(tgeral - icsub, 2)

        _clBD.incPedido_Orca4(tipo, nume, tprod, aliss, vliss, vlser, basec, icms, bsub, icsub, tpro2, _
                              frete, segu, outros, ipi, tgeral, pgto, peso, desc, tipo2, comis, conexao, transacao)

    End Sub

    Private Sub btn_finalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalizar.Click

        'Se foi informado algum produto...
        If Me.dtg_pedidoprotaentrega.Rows.Count > _valorZERO Then


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

                        If _numPedidoTemp.Equals("") Then ' Se for alteração de pedido...

                            alteraRegistroPedido(conexao, transacao)
                            _clBD.delPedido_Orca2(mNumPedido, conexao, transacao)
                            incluiDtg_itens(conexao, transacao)
                            alteraOrca4(conexao, transacao)

                        Else ' Se for continuação do pedido...

                            incluiRegistroPedido(conexao, transacao)
                            incluiDtg_itens(conexao, transacao)
                            inclueOrca4(conexao, transacao)

                        End If



                        transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                        MsgBox("Registro Efetuado c/ Sucesso", MsgBoxStyle.Exclamation, "METROSYS")

                        executaEspelhoPedido("", "\wged\pedidoSucesso.txt")

                        zeraTudo() : Me.cbo_local.Focus() : Me.btn_finalizar.Enabled = False
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

    Private Sub cbo_forpgto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_forpgto.GotFocus
        If Not cbo_forpgto.DroppedDown Then cbo_forpgto.DroppedDown = True
    End Sub

    Private Sub cbo_gerente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_gerente.GotFocus
        If Not cbo_gerente.DroppedDown Then cbo_gerente.DroppedDown = True
    End Sub

    Private Sub cbo_rota_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_rota.GotFocus
        If Not cbo_rota.DroppedDown Then cbo_rota.DroppedDown = True
    End Sub

    Private Sub cbo_tipopedido_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipopedido.GotFocus
        If Not cbo_tipopedido.DroppedDown Then cbo_tipopedido.DroppedDown = True
    End Sub

    Private Sub cbo_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_vendedor.GotFocus
        If Not cbo_vendedor.DroppedDown Then cbo_vendedor.DroppedDown = True
    End Sub

    Private Sub txt_qtde_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtde.Leave

        lbl_mensagem.Text = ""
        If Me.txt_qtde.Text.Equals("") Then Me.txt_qtde.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_qtde.Text) Then

            If CDec(Me.txt_qtde.Text) <= _valorZERO Then
                lbl_mensagem.Text = "Quantidade deve ser maior que ZERO !"
                Return

            End If
            Me.txt_qtde.Text = Format(CDec(Me.txt_qtde.Text), "###,##0.00")

        End If



    End Sub

    Private Sub SeFormaDePagamentoVAREJO()

        If Me.cbo_forpgto.SelectedIndex = _valorZERO Then 'Se a Forma de pagamento for A Vista


            If Me.cbo_condpgto.SelectedIndex >= _valorZERO Then

                'Verifica se a Condicao de pagamento é > 0, se for seleciona Forma de pagamento NP
                If IsNumeric(Me.cbo_condpgto.SelectedItem) Then

                    If CInt(Me.cbo_condpgto.SelectedItem) > _valorZERO Then Me.cbo_forpgto.SelectedIndex = 1

                Else

                    Me.cbo_forpgto.SelectedIndex = 1
                End If
            End If

        Else


            If Me.cbo_condpgto.SelectedIndex >= _valorZERO Then

                'Verifica se a Condicao de pagamento é 0, se for seleciona Forma de pagamento AV
                If IsNumeric(Me.cbo_condpgto.SelectedItem) AndAlso CInt(Me.cbo_condpgto.SelectedItem) = _valorZERO Then

                    Me.cbo_forpgto.SelectedIndex = _valorZERO

                End If
            End If
        End If

    End Sub

    Private Sub cbo_forpgto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_forpgto.SelectedIndexChanged

        Select Case MdlEmpresaUsu.tipoCondPagto
            Case 1
                SeFormaDePagamentoVAREJO()

            Case 2

                If Me.cbo_condpgto.SelectedIndex > _valorZERO Then

                    If cbo_forpgto.SelectedIndex = 0 Then cbo_forpgto.SelectedIndex = 1
                ElseIf Me.cbo_condpgto.SelectedIndex = _valorZERO Then
                    cbo_forpgto.SelectedIndex = 0
                End If

        End Select

        Select Case cbo_forpgto.SelectedIndex

            Case 0 'A VISTA
                Me.txt_entrada.Text = "0,00" : Me.txt_entrada.ReadOnly = True
            Case Is > 0
                Me.txt_entrada.ReadOnly = False
        End Select

    End Sub

    Private Sub executeF5()


        _qtdeAnteriorProd = 0
        _editandoProduto = False
        Try
            If Not dtg_pedidoprotaentrega.CurrentRow.IsNewRow Then

                _qtdeAnteriorProd = dtg_pedidoprotaentrega.CurrentRow.Cells(6).Value
                _codProdEditando = dtg_pedidoprotaentrega.CurrentRow.Cells(2).Value
                _vlrProdEditado = dtg_pedidoprotaentrega.CurrentRow.Cells(7).Value
                _aliqDescProdEditado = dtg_pedidoprotaentrega.CurrentRow.Cells(19).Value
                _vlDescProdEditado = dtg_pedidoprotaentrega.CurrentRow.Cells(20).Value
                FilialProd_Ref = dtg_pedidoprotaentrega.CurrentRow.Cells(21).Value
                gradeProd_Ref = dtg_pedidoprotaentrega.CurrentRow.Cells(26).Value.ToString
                codCorGrade_Ref = dtg_pedidoprotaentrega.CurrentRow.Cells(27).Value.ToString
                tamanhoGrade_Ref = dtg_pedidoprotaentrega.CurrentRow.Cells(28).Value.ToString


                '_vlrProdEditado = ValorUnitProd_Ref
                'If _aliqDescProdEditado <= 0 Then

                '    _vlrProdEditado = Round((ValorUnitProd_Ref - _vlDescProdEditado), 2)
                'End If

                Me._indexProdEditando = dtg_pedidoprotaentrega.CurrentRow.Index
                Me.txt_codProd.Text = dtg_pedidoprotaentrega.CurrentRow.Cells(2).Value
                Me.txt_nomeProd.Text = dtg_pedidoprotaentrega.CurrentRow.Cells(4).Value
                Me.txt_qtde.Text = dtg_pedidoprotaentrega.CurrentRow.Cells(6).Value
                Me.txt_valor.Text = Format(_vlrProdEditado, "##,##0.00") 'dtg_pedidoprotaentrega.CurrentRow.Cells(7).Value
                Me.txt_desconto.Text = Format(_aliqDescProdEditado, "##0.00")

                trazItenFilialBD(txt_codProd.Text)
                _editandoProduto = True
                qtdeProd_Ref += _qtdeAnteriorProd
                txt_codProd.Focus() : txt_codProd.SelectAll()


            End If

        Catch ex As Exception
        End Try



    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        executeF5()
    End Sub

    Private Sub DeleteItemGrid()

        Try

            lbl_mensagem.Text = ""
            If Me.dtg_pedidoprotaentrega.Enabled = True Then
                'Remove Linha
                Dim mLocal As String = dtg_pedidoprotaentrega.CurrentRow.Cells(21).Value
                Dim codigoProduto As String = dtg_pedidoprotaentrega.CurrentRow.Cells(2).Value
                Dim qtdeProduto As Double = dtg_pedidoprotaentrega.CurrentRow.Cells(6).Value

                gradeProd_Ref = dtg_pedidoprotaentrega.CurrentRow.Cells(26).Value.ToString
                objGrade.pCodig = codigoProduto
                objGrade.pLoja = mLocal
                objGrade.pCor = dtg_pedidoprotaentrega.CurrentRow.Cells(27).Value.ToString
                objGrade.pTm = dtg_pedidoprotaentrega.CurrentRow.Cells(28).Value.ToString
                objGrade.pQtde = qtdeProduto

                Me.dtg_pedidoprotaentrega.Rows.Remove(Me.dtg_pedidoprotaentrega.CurrentRow)
                Me.dtg_pedidoprotaentrega.Refresh()

                Me.txt_total.Text = Format(somaVlrTotalItensGrid, "###,##0.00")
                Me.txt_peso.Text = Format(somaPesoBrutolItensGrid, "###,##0.000")
                Me.txt_descontosTotais.Text = Format(somaVlrTdescItensGrid, "###,##0.00")



                Select Case cbo_tipopedido.SelectedIndex

                    Case 0, 3 'Venda ou Bonificação (Soma Estoque)

                        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                        Dim transacao As NpgsqlTransaction

                        If conection.State = ConnectionState.Closed Then conection.Open()
                        transacao = conection.BeginTransaction
                        _clBD.somaQtdeProdEstloja(codigoProduto, mLocal, qtdeProduto, conection, transacao)
                        If gradeProd_Ref.Equals("S") Then
                            _clBD.atualizaQtdeGradeSomando(conection, transacao, objGrade)
                        End If

                        If _indexProdEditando >= _valorZERO Then

                            _indexProdEditando = -1 : _codProdEditando = ""

                        End If
                        transacao.Commit() : conection.Close() : conection = Nothing


                    Case 1 'Pago a Entregar (Faz nada)
                        '-----------------------------
                    Case 2 'Devolução (Diminue Estoque)

                        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                        Dim transacao As NpgsqlTransaction

                        If conection.State = ConnectionState.Closed Then conection.Open()
                        transacao = conection.BeginTransaction
                        _clBD.subtraiQtdeProdEstloja(codigoProduto, mLocal, qtdeProduto, conection, transacao)
                        If gradeProd_Ref.Equals("S") Then
                            _clBD.atualizaQtdeGradeSubtraindo(conection, transacao, objGrade)
                        End If

                        If _indexProdEditando >= _valorZERO Then

                            _indexProdEditando = -1 : _codProdEditando = ""

                        End If
                        transacao.Commit() : conection.Close() : conection = Nothing


                End Select


            End If

        Catch ex As Exception
            MsgBox("Deu ERRO ao Deletar este Item " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try



    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click

        If Me.dtg_pedidoprotaentrega.Rows.Count > _valorZERO Then
            If MessageBox.Show("Deseja realmente Deletar esse Item?", "METROSYS", MessageBoxButtons.YesNo, _
                               MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Me.DeleteItemGrid()

                Try
                    If _numPedidoTemp.Equals("") = False Then
                        executaIncluiOrca2TblTemp()
                    End If
                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message)
                End Try
                _qtdeAnteriorProd = 0
            End If
        End If



    End Sub

    'Inicia-se o Tratamento da Impressão do pedido...
    Private Sub executaEspelhoPedidoExtracted1(ByVal s As StreamWriter, ByVal loja As String, ByVal numeroPedido As String, ByVal dtEmissao As String, ByVal codClient As String, ByVal nomeClient As String, ByVal condicao As String, ByVal codVendedor As String, ByVal idOrca1 As Int32, ByRef shouldReturn As Boolean)

        shouldReturn = False

        s.WriteLine("")

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Loja
        _mConsulta.Append("SELECT g_geno, g_ender, g_fone, g_uf, g_cid FROM geno001 WHERE g_codig = '" & loja & "'")
        Dim lShouldReturn1 As Boolean
        _clFuncoes.GravCabLojPedidoMatricial(_mConsulta.ToString, s, loja, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Cliente
        'Traz dados do CLIENTE do Pedido...
        _mConsulta.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
        _mConsulta.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codClient & "'")
        Dim lShouldReturn2 As Boolean
        _clFuncoes.GravCabCliPedidoMatricial(_mConsulta.ToString, s, codClient, numeroPedido, dtEmissao, codVendedor, condicao, loja, lShouldReturn2)
        If lShouldReturn2 Then shouldReturn = True : Return


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'itens
        _mConsulta.Append("SELECT o2.no_codpr, o2.no_qtde, o2.no_und, e.e_produt, o2.no_prunit, o2.no_prtot, o2.no_filial, el.e_locacao, o2.no_vldesc, o2.no_pesobruto, o2.no_vlsub, o2.no_pruvenda  ") '11
        _mConsulta.Append("FROM estloja01 el, " & MdlEmpresaUsu._esqEstab & ".orca2cc o2 LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 ")
        _mConsulta.Append("e ON e.e_codig = o2.no_codpr WHERE no_idxo1 = " & idOrca1 & " AND el.e_loja = o2.no_filial AND el.e_codig = o2.no_codpr")
        Dim lShouldReturn3 As Boolean
        _clFuncoes.GravItensPedidoMatricial(_mConsulta.ToString, s, numeroPedido, idOrca1, codClient, nomeClient, lShouldReturn3)
        If lShouldReturn3 Then shouldReturn = True : Return

    End Sub

    Private Sub GravaPedidoMatricialAlterado1(ByVal arqSaida As String, ByVal loja As String, ByVal numeroPedido As String, ByVal dtEmissao As String, ByVal codClient As String, ByVal nomeClient As String, ByVal condicao As String, ByVal codVendedor As String, ByVal idOrca1 As Int32, ByRef shouldReturn As Boolean)

        shouldReturn = False
        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp1 As String = "\wged\TEMPconsultaPed1.TMP"
        Dim mArqTemp2 As String = "\wged\TEMPconsultaPed2.TMP"
        Dim mArqTemp3 As String = "\wged\TEMPconsultaPed3.TMP"
        Dim fs1 As FileStream
        Dim fs2 As FileStream
        Dim fs3 As FileStream
        Try
            fs1 = New FileStream(mArqTemp1, FileMode.Truncate, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp1)
                fs1 = New FileStream(mArqTemp1, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs1 = New FileStream("\new1.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try

        Try
            fs2 = New FileStream(mArqTemp2, FileMode.Truncate, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp2)
                fs2 = New FileStream(mArqTemp2, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs2 = New FileStream("\new2.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try

        Try
            fs3 = New FileStream(mArqTemp3, FileMode.Truncate, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp3)
                fs3 = New FileStream(mArqTemp3, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs3 = New FileStream("\new3.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        Dim s1 As New StreamWriter(fs1)
        Dim s2 As New StreamWriter(fs2)
        Dim s3 As New StreamWriter(fs3)
        _PrintFont1 = New Font("Lucida Console", 10)


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Loja
        _mConsulta.Append("SELECT g_geno, g_ender, g_fone, g_uf, g_cid ")
        _mConsulta.Append("FROM geno001 WHERE g_codig = '" & loja & "'")
        Dim lShouldReturn1 As Boolean
        _clFuncoes.GravCabLojPediMatriAlterado1(_mConsulta.ToString, s1, loja, lShouldReturn1)
        If lShouldReturn1 Then Return

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Cliente
        'Traz dados do CLIENTE do Pedido...
        _mConsulta.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
        _mConsulta.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codClient & "'")
        Dim lShouldReturn2 As Boolean
        _clFuncoes.GravCabCliPediMatriAlterado1(_mConsulta.ToString, s1, codClient, numeroPedido, dtEmissao, codVendedor, condicao, loja, lShouldReturn2)
        If lShouldReturn2 Then Return

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'itens
        _mConsulta.Append("SELECT o2.no_codpr, o2.no_qtde, o2.no_und, e.e_produt, o2.no_prunit, o2.no_prtot, o2.no_filial, el.e_locacao, o2.no_vldesc, o2.no_pesobruto, o2.no_vlsub ") '10
        _mConsulta.Append("FROM estloja01 el, " & MdlEmpresaUsu._esqEstab & ".orca2cc o2 LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 ")
        _mConsulta.Append("e ON e.e_codig = o2.no_codpr WHERE no_idxo1 = " & idOrca1 & " AND el.e_loja = o2.no_filial AND el.e_codig = o2.no_codpr")
        Dim lShouldReturn3 As Boolean
        _clFuncoes.GravItensPediMatriAlterado1(_mConsulta.ToString, s2, numeroPedido, idOrca1, codClient, nomeClient, lShouldReturn3)
        If lShouldReturn3 Then Return

        'Deleta o arquivo temporário...
        s1.Close()
        'Ler o Arquivo salvo...
        Dim FilePath As String = mArqTemp1
        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrint = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream.Dispose() : MyfileStream = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        s3.Write(_StringToPrint)

        'Deleta o arquivo temporário...
        s2.Close()

        'Ler o Arquivo salvo...
        FilePath = mArqTemp2
        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrintItens = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream.Dispose() : MyfileStream = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        s3.Write(_StringToPrintItens)

        'Deleta o arquivo temporário...
        s3.Close()
        Try
            File.Copy(mArqTemp3, arqSaida, True)
        Catch ex As Exception
        End Try
        s1.Dispose()
        File.Delete(mArqTemp1)
        s2.Dispose()
        File.Delete(mArqTemp2)
        s3.Dispose()
        File.Delete(mArqTemp3)

        'Ler o arquivo salvo
        'LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrintItens

        'Visualiza Arquivo salvo
        VisuConteArqSalvo2()


    End Sub

    Private Sub executaEspelhoPedido(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPconsultaPedi.TMP"
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


        Dim s As New StreamWriter(fs)
        _PrintFont1 = New Font("Lucida Console", 12)
        Dim strLinha As String = ""
        Dim loja As String = "G00" & Mid(Me.cbo_local.SelectedItem, 1, 2)
        Dim numeroPedido As String = mNumPedido
        Dim dtEmissao As String = Me.dtp_emissao.Text
        Dim codClient As String = Me.txt_codpart.Text
        Dim nomeClient As String = Me.txt_nomePart.Text
        Dim condicao As String = Me.cbo_forpgto.SelectedItem
        Dim codVendedor As String = Trim(Mid(Me.cbo_vendedor.SelectedItem, 1, 6))
        Dim idOrca1 As Int32 = mIdOrca1pp 'Me.dtg_pedidos.CurrentRow.Cells(0).Value


        Select Case MdlRelatorioTelas._tl_movpedido

            Case 1 'Impressora Matricial
                Dim lShouldReturn As Boolean
                executaEspelhoPedidoExtracted1(s, loja, numeroPedido, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
                If lShouldReturn Then Return

                'Deleta o arquivo temporário...
                s.Close()
                Try
                    File.Copy(mArqTemp, arqSaida, True)
                Catch ex As Exception
                End Try
                s.Dispose()
                File.Delete(mArqTemp)

                'Ler o arquivo salvo
                LerOArquivoSalvo(arqSaida)
                _stringToPrintAux = _StringToPrint

                'Visualiza o conteúdo do arquivo salvo...
                VisuConteArqSalvo()

            Case 3 'Impressora Matricial Relatório Alterado 1
                Try
                    'Deleta o arquivo temporário...
                    s.Close()
                Catch ex As Exception
                End Try
                Try
                    File.Copy(mArqTemp, arqSaida, True)
                Catch ex As Exception
                End Try
                Try
                    s.Dispose()
                    File.Delete(mArqTemp)
                Catch ex As Exception
                End Try


                Dim lShouldReturn1 As Boolean
                GravaPedidoMatricialAlterado1(arqSaida, loja, numeroPedido, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn1)
                If lShouldReturn1 Then Return


            Case Else
                Dim lShouldReturn As Boolean
                executaEspelhoPedidoExtracted1(s, loja, numeroPedido, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
                If lShouldReturn Then Return

                'Deleta o arquivo temporário...
                s.Close()
                Try
                    File.Copy(mArqTemp, arqSaida, True)
                Catch ex As Exception
                End Try
                s.Dispose()
                File.Delete(mArqTemp)

                'Ler o arquivo salvo
                LerOArquivoSalvo(arqSaida)
                _stringToPrintAux = _StringToPrint

                'Visualiza o conteúdo do arquivo salvo...
                VisuConteArqSalvo()

        End Select


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
            'PrintDocument1 = New 

            ' Especifica as configurações da pagina atual
            pdRelatPedidos.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatPedidos.DefaultPageSettings.Margins.Top = 12
            pdRelatPedidos.DefaultPageSettings.Margins.Right = 12
            pdRelatPedidos.DefaultPageSettings.Margins.Left = 10
            pdRelatPedidos.DefaultPageSettings.Margins.Bottom = 8
            '========================================================

            'Orientação em Paisagem...
            Select Case MdlRelatorioTelas._tl_movpedido
                Case 1 'Impressora Matricial
                    pdRelatPedidos.DefaultPageSettings.Landscape = True
                Case 2 'Impressora Laiser
                    pdRelatPedidos.DefaultPageSettings.Landscape = False
                Case Else
                    pdRelatPedidos.DefaultPageSettings.Landscape = True
            End Select
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando PEDIDO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatPedidos
            PrintPreviewDialog1.ShowDialog()
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
        e.Graphics.DrawString(StringforPage, _PrintFont, Brushes.Black, recdraw, Strformat)

        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False : _stringToPrintAux = _StringToPrint

        End If



    End Sub

    Private Sub InicializaRelatorio(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintEventArgs)

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

    Private Sub VisuConteArqSalvo2()

        Try

            ' Especifica as configurações da pagina atual
            pdRelatPedidos2.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatPedidos2.DefaultPageSettings.Margins.Top = 12
            pdRelatPedidos2.DefaultPageSettings.Margins.Right = 12
            pdRelatPedidos2.DefaultPageSettings.Margins.Left = 10
            pdRelatPedidos2.DefaultPageSettings.Margins.Bottom = 8
            '========================================================

            'Orientação em Paisagem...
            Select Case MdlRelatorioTelas._tl_movpedido
                Case 1 'Impressora Matricial
                    pdRelatPedidos.DefaultPageSettings.Landscape = True
                Case 2 'Impressora Laiser
                    pdRelatPedidos.DefaultPageSettings.Landscape = False
                Case Else
                    pdRelatPedidos.DefaultPageSettings.Landscape = True
            End Select
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando PEDIDO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatPedidos2
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False
            _StringToPrint = "" : _StringToPrintItens = ""

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub pdRelatPedidos2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdRelatPedidos2.PrintPage

        Dim NumChars As Integer
        Dim NumLines As Integer
        Dim NumChars2 As Integer = 100000
        Dim NumLines2 As Integer = 100
        Dim StringforPage As String
        Dim Strformat As New StringFormat

        Dim recdraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, _
                                      e.MarginBounds.Width, e.MarginBounds.Height)
        Dim SizeMeassure As New SizeF(e.MarginBounds.Width, _
                                      e.MarginBounds.Height - _PrintFont1.GetHeight(e.Graphics))

        Dim SizeMeassure2 As New SizeF(e.MarginBounds.Width, _
                                      e.MarginBounds.Height - _PrintFont2.GetHeight(e.Graphics))

        Strformat.Trimming = StringTrimming.Word

        If _cabecalho Then

            e.Graphics.MeasureString(_StringToPrint, _PrintFont1, SizeMeassure, Strformat, NumChars, NumLines)
            StringforPage = _StringToPrint.Substring(_valorZERO, NumChars)

            ' Imprime a string na pagina atual
            e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, (recdraw.X + 80), (recdraw.Y + 100), Strformat)

            '_stringToPrintAux = _StringToPrint
        End If
        _cabecalho = False


        e.Graphics.MeasureString(_StringToPrintItens, _PrintFont2, SizeMeassure2, Strformat, NumChars2, NumLines2)
        StringforPage = _StringToPrintItens.Substring(_valorZERO, NumChars2)

        ' Imprime a string na pagina atual
        e.Graphics.DrawString(StringforPage, _PrintFont2, Brushes.Black, (recdraw.X + 80), (recdraw.Y + 213), Strformat)
        'e.Graphics.DrawString(StringforPage, _PrintFont2, Brushes.Black, 80, 227, Strformat) 'e.MarginBounds.Left

        ' Se Hover mais texto, indica que há mais paginas
        If NumChars2 < _StringToPrintItens.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrintItens = _StringToPrintItens.Substring(NumChars2)
            e.HasMorePages = True

        Else
            e.HasMorePages = False '_stringToPrintAux += _StringToPrintItens

        End If



    End Sub

    Private Sub InicializaRelatorio2(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintEventArgs)

        _cabecalho = True
        _StringToPrintItens = _stringToPrintAux
        If MostrarCaixaImpressoras Then

            Dim Impressora As New PrintDialog
            Impressora.AllowCurrentPage = True : Impressora.AllowSomePages = True
            If Impressora.ShowDialog() = DialogResult.Cancel Then

                Relatorio.Cancel = True

            Else

                Try

                    pdRelatPedidos2.PrinterSettings = Impressora.PrinterSettings
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
        End If
        MostrarCaixaImpressoras = True



    End Sub

    Private Sub chk_rota_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_rota.CheckedChanged

        If chk_rota.Checked Then

            cbo_rota.SelectedIndex = _valorZERO : cbo_rota.Enabled = True
        Else
            cbo_rota.SelectedIndex = -1 : cbo_rota.Enabled = False
        End If


    End Sub

    Private Sub cbo_rota_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_rota.SelectedIndexChanged

        Me.txt_valor.ReadOnly = False : Me.txt_valor.Text = "0,00"
        'If chk_rota.Checked Then Me.txt_valor.ReadOnly = True : Me.txt_valor.Text = "0,00"

    End Sub

    Private Sub txt_codProd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codProd.Leave

        If (Trim(txt_codProd.Text).Length >= 5) AndAlso (cbo_condpgto.SelectedIndex >= _valorZERO) _
        AndAlso (cbo_rota.SelectedIndex >= _valorZERO) Then

            Dim mConnection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try
                mConnection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message) : Return
            End Try

            Dim mColunaTblPreco As Integer = _valorZERO, mIdRota As Integer = _valorZERO
            Dim mCodProduto As String = "", mPrecoProduto As Double

            mCodProduto = txt_codProd.Text
            mIdRota = CInt(Trim(Mid(cbo_rota.SelectedItem, 1, 3)))
            mColunaTblPreco = _clBD.trazColunaTblPreco(cbo_condpgto.SelectedItem, mConnection)
            mPrecoProduto = _clBD.trazPrecoTblRota(mCodProduto, mIdRota, mColunaTblPreco, _
                                                   MdlEmpresaUsu._esqVinc, mConnection)
            Me.txt_valor.Text = Format(mPrecoProduto, "###,##0.00")

            mConnection.ClearAllPools() : mConnection.Close() : mConnection = Nothing

        End If


    End Sub

    Private Sub cbo_gerente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_gerente.SelectedIndexChanged

        If cbo_gerente.SelectedItem <> _nomeGerente Then

            Me.msk_senha.Enabled = True
        End If
    End Sub

    Private Sub cbo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_vendedor.SelectedIndexChanged

        Dim mcodVendedor As String = Trim(Mid(cbo_vendedor.SelectedItem, 1, 6))
        _descVendedor = _clBD.trazDescVendedor(MdlConexaoBD.conectionPadrao, mcodVendedor)

        If _descVendedor > 0.0 Then

            Me.txt_desconto.ReadOnly = False : Me.txt_desconto.Text = "0,00"
        Else
            Me.txt_desconto.ReadOnly = True : Me.txt_desconto.Text = "0,00"
        End If
        mcodVendedor = Nothing

    End Sub

    Private Sub txt_desconto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_desconto.Leave

        lbl_mensagem.Text = ""
        If Me.txt_desconto.Text.Equals("") Then Me.txt_desconto.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_desconto.Text) Then
            If CDec(Me.txt_desconto.Text) < _valorZERO Then
                lbl_mensagem.Text = "Valor do Desconto deve ser MAIOR ou IGUAL que ZERO !"
                Return

            End If
            Me.txt_desconto.Text = Format(CDec(Me.txt_desconto.Text), "###,##0.00")

        End If



        If _gerenteOK = False Then

            If _descVendedor > _valorZERO Then

                If CDbl(Me.txt_desconto.Text) > _descVendedor Then

                    lbl_mensagem.Text = "Valor do Desconto dever ser Menor ou Igual a " & _descVendedor & "% !"
                    Me.txt_desconto.Focus() : Me.txt_desconto.SelectAll() : Return
                End If
            End If
        End If



    End Sub

    Private Sub preenchCamposRegistroPedido(ByVal numPedido As String)

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearPool() : conection = Nothing : Return

        End Try

        Dim cmdPedido As New NpgsqlCommand
        Dim sqlPedido As New StringBuilder
        Dim drPedido As NpgsqlDataReader

        Dim condicao As String = ""

        'Dim nt_orca, nt_geno, nt_codig, nt_cfop, nt_vend, nt_cid, nt_x, nt_y As String
        'Dim nt_tipo2, nt_auto, nt_auto2 As String
        'Dim nt_emiss As Boolean = False
        'Dim nt_rota, nt_parc, nt_cod1, nt_cod2, nt_cod3, nt_cod4, nt_cod5 As Integer
        'Dim nt_cod6, nt_cod7, nt_mapa, nt_sit, nt_itens As Integer
        'Dim nt_peso, nt_volum As Double

        'nt_orca = "" : nt_geno = "" : nt_codig = "" : nt_cfop = "" : nt_vend = "" : nt_cid = "" : nt_x = ""
        'nt_y = "" : nt_tipo2 = "" : nt_auto = "" : nt_auto2 = ""
        'nt_rota = 0 : nt_parc = 0 : nt_cod1 = 0 : nt_cod2 = 0 : nt_cod3 = 0 : nt_cod4 = 0 : nt_cod5 = 0
        'nt_cod6 = 0 : nt_cod7 = 0 : nt_mapa = 0 : nt_sit = 0 : nt_itens = 0 : nt_peso = 0 : nt_volum = 0


        Try

            sqlPedido.Append("SELECT nt_orca, nt_geno, nt_codig, nt_dtemis, nt_dtsai, nt_emiss, nt_cfop, ") '6
            sqlPedido.Append("nt_vend, nt_cid, nt_itens, nt_rota, nt_peso, nt_x, nt_y, nt_parc, nt_cod1, ") '15
            sqlPedido.Append("nt_cod2, nt_volum, nt_tipo2, nt_auto, nt_auto2, nt_cod3, nt_cod4, nt_cod5, ") '23
            sqlPedido.Append("nt_cod6, nt_cod7, nt_mapa, nt_sit, nt_idx, nt_tiposelecao, nt_entrada, nt_descrcondpagto ") '31
            sqlPedido.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp WHERE nt_orca = @nt_orca") '25

            cmdPedido = New NpgsqlCommand(sqlPedido.ToString, conection)
            cmdPedido.Parameters.Add("@nt_orca", numPedido)
            drPedido = cmdPedido.ExecuteReader

            While drPedido.Read

                Me.txt_pedido.Text = drPedido(0).ToString
                cbo_local.SelectedIndex = _clFuncoes.trazIndexCboLoja(Mid(drPedido(1).ToString, _
                                          drPedido(1).ToString.Length - 1, 2), cbo_local)
                dtp_emissao.Value = drPedido(3) : txt_codpart.Text = drPedido(2).ToString
                trazFornecedor(drPedido(2).ToString)
                If drPedido(10) > _valorZERO Then

                    cbo_rota.SelectedIndex = _clFuncoes.trazIndexCboRota(drPedido(10).ToString, cbo_rota)
                    chk_rota.Checked = True
                End If

                Me.txt_operador.Text = drPedido(19).ToString
                'Me.txt_consumo.Text = drPedido(1).ToString
                'condicao = formaDescricao(drPedido(15).ToString, drPedido(16).ToString, drPedido(21).ToString, _
                '                drPedido(22).ToString, drPedido(23).ToString, drPedido(24).ToString, drPedido(25).ToString)
                condicao = drPedido(31).ToString
                Me.txt_entrada.Text = Format(drPedido(30), "###,##0.00")
                cbo_condpgto.SelectedIndex = _clFuncoes.trazIndexCboCondPagto(condicao, cbo_condpgto)
                cbo_vendedor.SelectedIndex = _clFuncoes.trazIndexCboVendedor(drPedido(7).ToString, cbo_vendedor)
                If cbo_vendedor.SelectedIndex >= 0 Then cbo_vendedor.Enabled = False
                cbo_forpgto.SelectedIndex = _clFuncoes.trazIndexCboFormPagto(drPedido(18).ToString, cbo_forpgto)
                cbo_tipopedido.SelectedIndex = drPedido(29)


                Me.cbo_local.Enabled = False
            End While

            conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        cmdPedido.CommandText = "" : sqlPedido.Remove(0, sqlPedido.ToString.Length)
        conection.ClearPool() : conection = Nothing : cmdPedido = Nothing
        drPedido = Nothing : sqlPedido = Nothing



    End Sub

    Private Sub preenchCamposRegistroPedidoTemp(ByVal numPedido As String)

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearPool() : conection = Nothing : Return

        End Try

        mIdOrca1ppTemp = _clBD.trazIdOrca1ppTemporaria(conection, _numPedidoTemp, MdlUsuarioLogando._local)

        Dim cmdPedido As New NpgsqlCommand
        Dim sqlPedido As New StringBuilder
        Dim drPedido As NpgsqlDataReader

        Dim condicao As String = ""

        Try

            sqlPedido.Append("SELECT nt_orca, nt_geno, nt_codig, nt_dtemis, nt_dtsai, nt_emiss, nt_cfop, ") '6
            sqlPedido.Append("nt_vend, nt_cid, nt_itens, nt_rota, nt_peso, nt_x, nt_y, nt_parc, nt_cod1, ") '15
            sqlPedido.Append("nt_cod2, nt_volum, nt_tipo2, nt_auto, nt_auto2, nt_cod3, nt_cod4, nt_cod5, ") '23
            sqlPedido.Append("nt_cod6, nt_cod7, nt_mapa, nt_sit, nt_idx, nt_tiposelecao ") '29
            sqlPedido.Append("FROM orca1pp WHERE nt_orca = @nt_orca AND nt_geno = @nt_geno") '25

            cmdPedido = New NpgsqlCommand(sqlPedido.ToString, conection)
            cmdPedido.Parameters.Add("@nt_orca", numPedido)
            cmdPedido.Parameters.Add("@nt_geno", MdlUsuarioLogando._local)
            drPedido = cmdPedido.ExecuteReader

            While drPedido.Read

                Me.txt_pedido.Text = drPedido(0).ToString
                cbo_local.SelectedIndex = _clFuncoes.trazIndexCboLoja(Mid(drPedido(1).ToString, _
                                          drPedido(1).ToString.Length - 1, 2), cbo_local)
                dtp_emissao.Value = drPedido(3) : txt_codpart.Text = drPedido(2).ToString
                trazFornecedor(drPedido(2).ToString)
                If drPedido(10) > _valorZERO Then

                    cbo_rota.SelectedIndex = _clFuncoes.trazIndexCboRota(drPedido(10).ToString, cbo_rota)
                    chk_rota.Checked = True
                End If

                Me.txt_operador.Text = drPedido(19).ToString
                'Me.txt_consumo.Text = drPedido(1).ToString
                condicao = formaDescricao(drPedido(15).ToString, drPedido(16).ToString, drPedido(21).ToString, _
                drPedido(22).ToString, drPedido(23).ToString, drPedido(24).ToString, drPedido(25).ToString)
                cbo_condpgto.SelectedIndex = _clFuncoes.trazIndexCboCondPagto(condicao, cbo_condpgto)
                cbo_vendedor.SelectedIndex = _clFuncoes.trazIndexCboVendedor(drPedido(7).ToString, cbo_vendedor)
                If cbo_vendedor.SelectedIndex >= 0 Then cbo_vendedor.Enabled = False
                cbo_forpgto.SelectedIndex = _clFuncoes.trazIndexCboFormPagto(drPedido(18).ToString, cbo_forpgto)
                cbo_tipopedido.SelectedIndex = drPedido(29)


                Me.cbo_local.Enabled = False
            End While

            conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        cmdPedido.CommandText = "" : sqlPedido.Remove(0, sqlPedido.ToString.Length)
        conection.ClearPool() : conection = Nothing : cmdPedido = Nothing
        drPedido = Nothing : sqlPedido = Nothing



    End Sub

    Private Function formaDescricao(ByVal cond1 As String, ByVal cond2 As String, ByVal cond3 As String, _
                              ByVal cond4 As String, ByVal cond5 As String, ByVal cond6 As String, _
                              ByVal cond7 As String) As String

        Dim descricao As String = ""

        If CInt(cond1) > _valorZERO Then descricao += cond1
        If CInt(cond2) > _valorZERO Then descricao += "/" & cond2
        If CInt(cond3) > _valorZERO Then descricao += "/" & cond3
        If CInt(cond4) > _valorZERO Then descricao += "/" & cond4
        If CInt(cond5) > _valorZERO Then descricao += "/" & cond5
        If CInt(cond6) > _valorZERO Then descricao += "/" & cond6
        If CInt(cond7) > _valorZERO Then descricao += "/" & cond7
        If descricao.Equals("") Then descricao = "0"


        Return descricao
    End Function

    Private Sub preenchItensPedido(ByVal numPedido As String)


        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearPool() : conection = Nothing : Return

        End Try

        Dim cmdPedido As New NpgsqlCommand
        Dim sqlPedido As New StringBuilder
        Dim drPedido As NpgsqlDataReader
        Dim grade As String = ""

        Try

            sqlPedido.Append("SELECT no_idpk, no_codpr, no_cdbarra, e_produt, no_und, no_qtde, no_pruvenda, no_prtot, ") '7
            sqlPedido.Append("no_pesobruto, no_pesoliquido, no_alqicm, no_lin, no_alqcom, no_comis, no_basesub, ") '14
            sqlPedido.Append("no_alqsub, no_vlsub, no_grupo, no_alqdesc, no_vldesc, no_filial, no_baseicm, ") '21
            sqlPedido.Append("no_outrasdesp, no_vlicms, no_prunit, no_idgrade, ") '25
            sqlPedido.Append("(SELECT eg.e_cor FROM " & MdlEmpresaUsu._esqVinc & ".estgrade eg ") '26 [subconsulta = drPedido(26)]
            sqlPedido.Append("WHERE e_idgrade = no_idgrade), (SELECT eg.e_tm FROM " & MdlEmpresaUsu._esqVinc & ".estgrade eg ") '26
            sqlPedido.Append("WHERE e_idgrade = no_idgrade) ")
            sqlPedido.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc LEFT JOIN ")
            sqlPedido.Append(MdlEmpresaUsu._esqVinc & ".est0001 ON ")
            sqlPedido.Append("e_codig = no_codpr WHERE no_orca = @no_orca")

            cmdPedido = New NpgsqlCommand(sqlPedido.ToString, conection)
            cmdPedido.Parameters.Add("@no_orca", numPedido)
            drPedido = cmdPedido.ExecuteReader

            While drPedido.Read
                grade = "N"
                If drPedido(25) > 0 Then grade = "S"

                Dim mlinha As String() = {drPedido(0), Mid(Me.cbo_local.SelectedItem, 1, 2), drPedido(1), drPedido(2), drPedido(3), drPedido(4), _
                    Format(drPedido(5), "###,##0.00"), Format(drPedido(6), "###,##0.00"), Format(Round((drPedido(7) + drPedido(16)), 2), "###,##0.00"), _
                    drPedido(8), drPedido(9), drPedido(10), drPedido(11), _
                    drPedido(12), drPedido(13), drPedido(14), drPedido(15), drPedido(16), drPedido(17), _
                    drPedido(18), drPedido(19), drPedido(20).ToString, drPedido(21), drPedido(22), drPedido(23), drPedido(24), _
                    grade, drPedido(26).ToString, drPedido(27).ToString, drPedido(25)}


                'Adicionando Linha
                Me.dtg_pedidoprotaentrega.Rows.Add(mlinha)
                Me.dtg_pedidoprotaentrega.Refresh()

                mlinha = Nothing
                Me.txt_total.Text = Format(somaVlrTotalItensGrid, "###,##0.00")
                Me.txt_peso.Text = Format(somaPesoBrutolItensGrid, "###,##0.000")
                Me.txt_descontosTotais.Text = Format(somaVlrTdescItensGrid, "##,##0.00")
            End While

            drPedido.Close()
            conection.ClearPool() : conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        cmdPedido.CommandText = "" : sqlPedido.Remove(0, sqlPedido.ToString.Length)
        conection = Nothing : cmdPedido = Nothing
        drPedido = Nothing : sqlPedido = Nothing



    End Sub

    Private Sub preenchItensPedidoTemp(ByVal numPedido As String)


        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearPool() : conection = Nothing : Return

        End Try

        Dim cmdPedido As New NpgsqlCommand
        Dim sqlPedido As New StringBuilder
        Dim drPedido As NpgsqlDataReader
        Dim grade As String = ""

        Try

            sqlPedido.Append("SELECT no_idpk, no_codpr, no_cdbarra, e_produt, no_und, no_qtde, no_pruvenda, no_prtot, ") '7
            sqlPedido.Append("no_pesobruto, no_pesoliquido, no_alqicm, no_lin, no_alqcom, no_comis, no_basesub, ") '14
            sqlPedido.Append("no_alqsub, no_vlsub, no_grupo, no_alqdesc, no_vldesc, no_filial, no_baseicm, ") '21
            sqlPedido.Append("no_outrasdesp, no_vlicms, no_prunit, no_idgrade, ") '25
            sqlPedido.Append("(SELECT eg.e_cor FROM " & MdlEmpresaUsu._esqVinc & ".estgrade eg ") '26 [subconsulta = drPedido(26)]
            sqlPedido.Append("WHERE e_idgrade = no_idgrade), (SELECT eg.e_tm FROM " & MdlEmpresaUsu._esqVinc & ".estgrade eg ") '26
            sqlPedido.Append("WHERE e_idgrade = no_idgrade) ")
            sqlPedido.Append("FROM orca2cc LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 ON ")
            sqlPedido.Append("e_codig = no_codpr WHERE no_orca = @no_orca AND no_geno = @no_geno")

            cmdPedido = New NpgsqlCommand(sqlPedido.ToString, conection)
            cmdPedido.Parameters.Add("@no_orca", numPedido)
            cmdPedido.Parameters.Add("@no_geno", Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2))
            drPedido = cmdPedido.ExecuteReader

            While drPedido.Read

                grade = "N"
                If drPedido(25) > 0 Then grade = "S"

                Dim mlinha As String() = {drPedido(0), Mid(Me.cbo_local.SelectedItem, 1, 2), drPedido(1), drPedido(2), drPedido(3), drPedido(4), _
                    Format(drPedido(5), "###,##0.00"), Format(drPedido(6), "###,##0.00"), Format(Round((drPedido(7) + drPedido(16)), 2), "###,##0.00"), _
                    drPedido(8), drPedido(9), drPedido(10), drPedido(11), _
                    drPedido(12), drPedido(13), drPedido(14), drPedido(15), drPedido(16), drPedido(17), _
                    drPedido(18), drPedido(19), drPedido(20), drPedido(21), drPedido(22), drPedido(23), drPedido(24), _
                    grade, drPedido(26).ToString, drPedido(27).ToString, drPedido(25)}


                'Adicionando Linha
                Me.dtg_pedidoprotaentrega.Rows.Add(mlinha)
                Me.dtg_pedidoprotaentrega.Refresh()

                mlinha = Nothing
                Me.txt_total.Text = Format(somaVlrTotalItensGrid, "###,##0.00")
                Me.txt_peso.Text = Format(somaPesoBrutolItensGrid, "###,##0.000")
                Me.txt_descontosTotais.Text = Format(somaVlrTdescItensGrid, "##,##0.00")
            End While

            drPedido.Close()
            conection.ClearPool() : conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        cmdPedido.CommandText = "" : sqlPedido.Remove(0, sqlPedido.ToString.Length)
        conection = Nothing : cmdPedido = Nothing
        drPedido = Nothing : sqlPedido = Nothing



    End Sub

    Private Sub Frm_PedidoProntEntregAlt_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If btn_finalizar.Enabled Then

            If Me.dtg_pedidoprotaentrega.Rows.Count > _valorZERO Then


                If _numPedidoTemp.Equals("") = False Then

                    Select Case MessageBox.Show("Deseja salvar esse pedido?", "METROSYS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)

                        Case Windows.Forms.DialogResult.Yes

                            finalizaPedidoFormClosing()

                        Case Windows.Forms.DialogResult.No

                            Try
                                File.Delete(_arqNumPedido)
                            Catch ex As Exception
                            End Try

                            devolveQtdeEstloja01()
                            deletaPedidoDasTabelasTemporarias(Me.txt_pedido.Text, MdlUsuarioLogando._local)


                        Case Windows.Forms.DialogResult.Cancel
                            e.Cancel = True 'Cancela o fechamento do formulário

                    End Select

                Else

                    Select Case MessageBox.Show("Deseja salvar esse pedido?", "METROSYS", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                        Case Windows.Forms.DialogResult.OK

                            finalizaPedidoFormClosing()

                        Case Windows.Forms.DialogResult.Cancel
                            e.Cancel = True 'Cancela o fechamento do formulário

                    End Select

                End If
            End If
        End If



    End Sub

    Private Sub finalizaPedidoFormClosing()

        'Se foi informado algum produto...
        If Me.dtg_pedidoprotaentrega.Rows.Count > _valorZERO Then


            If verificaRegistroPedido() Then

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

                    alteraRegistroPedido(conexao, transacao)
                    _clBD.delPedido_Orca2(mNumPedido, conexao, transacao)
                    incluiDtg_itens(conexao, transacao)
                    alteraOrca4(conexao, transacao)

                    transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                    MsgBox("Registro Salvo com Sucesso", MsgBoxStyle.Exclamation, "METROSYS")

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



    End Sub

    Private Sub deletaPedidoDasTabelasTemporarias(ByVal numpedido As String, ByVal codGeno As String)

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim mloja As String = Mid(codGeno, codGeno.Length - 1, 2)

        Try

            conection.Open()
            transacao = conection.BeginTransaction

            _clBD.delPedido_Orca2Temporaria(numpedido, mloja, conection, transacao)
            _clBD.delPedido_Orca4Temporaria(numpedido, codGeno, conection, transacao)
            _clBD.delPedido_Orca1Temporaria(numpedido, codGeno, conection, transacao)

            transacao.Commit() : conection.ClearAllPools() : conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            transacao = Nothing : conection = Nothing

        End Try

    End Sub

    Private Sub devolveQtdeEstloja01()

        Select Case cbo_tipopedido.SelectedIndex

            Case 0, 3 'Venda ou Bonificação (Acrescenta Estoque)

                Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Dim transacao As NpgsqlTransaction
                Dim codigoProduto As String = ""
                Dim qtdeProduto As Double = _valorZERO
                Dim mloja As String = "" 'Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2)

                Try

                    conection.Open()
                    transacao = conection.BeginTransaction
                    For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

                        If Not row.IsNewRow Then
                            codigoProduto = row.Cells(2).Value
                            qtdeProduto = row.Cells(6).Value
                            mloja = row.Cells(21).Value
                            gradeProd_Ref = row.Cells(26).Value.ToString
                            objGrade.pCodig = codigoProduto
                            objGrade.pLoja = mloja
                            objGrade.pCor = dtg_pedidoprotaentrega.CurrentRow.Cells(27).Value.ToString
                            objGrade.pTm = dtg_pedidoprotaentrega.CurrentRow.Cells(28).Value.ToString
                            objGrade.pQtde = qtdeProduto

                            _clBD.somaQtdeProdEstloja(codigoProduto, mloja, qtdeProduto, conection, transacao)
                            If gradeProd_Ref.Equals("S") Then
                                _clBD.atualizaQtdeGradeSomando(conection, transacao, objGrade)
                            End If

                        End If
                    Next

                    transacao.Commit() : conection.ClearAllPools() : conection.Close()
                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                Finally
                    transacao = Nothing : conection = Nothing : codigoProduto = Nothing : qtdeProduto = Nothing

                End Try


            Case 1 'Pago a Entregar (Faz nada)
                '-----------------------------
            Case 2 'Devolução (Diminue Estoque)

                Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Dim transacao As NpgsqlTransaction
                Dim codigoProduto As String = ""
                Dim qtdeProduto As Double = _valorZERO
                Dim mloja As String = "" 'Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2)

                Try

                    conection.Open()
                    transacao = conection.BeginTransaction
                    For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

                        If Not row.IsNewRow Then
                            codigoProduto = row.Cells(2).Value
                            qtdeProduto = row.Cells(6).Value
                            mloja = row.Cells(21).Value
                            gradeProd_Ref = row.Cells(26).Value.ToString
                            objGrade.pCodig = codigoProduto
                            objGrade.pLoja = mloja
                            objGrade.pCor = dtg_pedidoprotaentrega.CurrentRow.Cells(27).Value.ToString
                            objGrade.pTm = dtg_pedidoprotaentrega.CurrentRow.Cells(28).Value.ToString
                            objGrade.pQtde = qtdeProduto

                            _clBD.subtraiQtdeProdEstloja(codigoProduto, mloja, qtdeProduto, conection, transacao)
                            If gradeProd_Ref.Equals("S") Then
                                _clBD.atualizaQtdeGradeSubtraindo(conection, transacao, objGrade)
                            End If

                        End If
                    Next

                    transacao.Commit() : conection.ClearAllPools() : conection.Close()
                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                Finally
                    transacao = Nothing : conection = Nothing : codigoProduto = Nothing : qtdeProduto = Nothing

                End Try


        End Select


    End Sub

    Private Sub dtg_pedidoprotaentrega_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dtg_pedidoprotaentrega.RowsAdded

        If dtg_pedidoprotaentrega.Rows.Count >= 1 Then

            cbo_tipopedido.Enabled = False

        Else
            cbo_tipopedido.Enabled = True
        End If

    End Sub

    Private Sub dtg_pedidoprotaentrega_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dtg_pedidoprotaentrega.RowsRemoved

        If dtg_pedidoprotaentrega.Rows.Count >= 1 Then

            cbo_tipopedido.Enabled = False

        Else
            cbo_tipopedido.Enabled = True
        End If

    End Sub

    Private Sub dtg_pedidoprotaentrega_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_pedidoprotaentrega.MouseDoubleClick

        executeF5()
    End Sub

    Private Sub txt_entrada_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_entrada.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_entrada_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_entrada.Leave


        lbl_mensagem.Text = ""
        If Me.txt_entrada.Text.Equals("") Then Me.txt_entrada.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_entrada.Text) Then
            If CDec(Me.txt_entrada.Text) < _valorZERO Then
                lbl_mensagem.Text = "Entrada deve ser maior ou igual a ZERO !"
                Return

            End If
            Me.txt_entrada.Text = Format(CDec(Me.txt_entrada.Text), "###,##0.00")

        End If

    End Sub

    Private Sub cbo_condpgto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_condpgto.SelectedIndexChanged

        If cbo_condpgto.SelectedIndex = _valorZERO Then

            If Me.cbo_forpgto.SelectedIndex > _valorZERO Then Me.cbo_forpgto.SelectedIndex = 0
        ElseIf cbo_condpgto.SelectedIndex > _valorZERO Then

            If Me.cbo_forpgto.SelectedIndex = _valorZERO Then Me.cbo_forpgto.SelectedIndex = 1
        End If

    End Sub

End Class