Imports Npgsql
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Math
Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog

Public Class Frm_Orcamento

    Private Const _valorZERO As Integer = 0
    Dim xcont As Integer = 0
    Dim _clBD As New Cl_bdMetrosys
    Dim _clFuncoes As New ClFuncoes
    Dim _formBusca As Boolean = False
    Dim _numOrcamentoAtual As Int64 = 0
    Dim _numPedidoOK As Boolean = False
    Public _mPesquisaForn As Boolean = False 'Serve para configura os campos CodFornec e NomeFornec
    Public Shared _frmREf As New Frm_Orcamento
    Dim _BuscaForn As New Frm_BuscaCliPedido
    Dim _BuscaProd As New Frm_BuscaProdPedido
    Dim _FrmConfirmaCompraGrade As New Frm_ConfirmaCompraGrade
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
    Dim objGrade As New Cl_Grade
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
                executaRelatorioOrcamento("", "\wged\orcamento.txt")
        End Select

    End Sub

    Private Sub Frm_Orcamento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Orcamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_desconto.Text = "0,00"
        Me.txt_valor.Text = "0,00"
        Me.txt_qtde.Text = "1,00"
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

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos.BeginPrint, AddressOf InicializaRelatorio

        'Me.txt_orcamento.Text = "00000003" : _numOrcamentoAtual = 3

    End Sub

    Private Sub txt_codPart_KeyDownExtracted()

        _formBusca = True : _mPesquisaForn = False : _frmREf = Me
        _BuscaForn.set_frmRef(Me)
        _BuscaForn.ShowDialog(Me)
        _formBusca = False
        If Me.txt_codpart.Text.Equals("") Then Me.txt_codpart.Focus()

        Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()


        'Tratamento do Consumo...
        If mIsento = True Then

            _consumo = "S"
        Else


            If mConsumo.Equals("S") Then

                _consumo = "S"
            Else
                _consumo = "N"
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
                drParticipante.Close()
                Me.txt_nomePart.Text = mNomePart


                'Tratamento do Consumo...
                If mIsento = True Then

                    _consumo = "S"
                Else

                    If mConsumo.Equals("S") Then

                        _consumo = "S"
                    Else
                        _consumo = "N"
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

        'permite só numeros com vírgula
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_qtde_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtde.KeyPress

        'permite só numeros com vírgula
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_valor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valor.KeyPress

        'permite só numeros com vírgula
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_codprod_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codProd.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

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
                            Me.txt_valor.Text = Format(Round(ValorUnitProd_Ref, 2), "###,##0.00")

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
                        Me.txt_valor.Text = Format(Round(ValorUnitProd_Ref, 2), "###,##0.00")


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
                pesoBrutoProd_Ref = drProduto(15)
                pesoLiqProd_Ref = drProduto(16)
                local_ref = Mid(cbo_local.SelectedItem, 1, 2)
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
            drProduto.Close() : drProduto = Nothing

        Catch ex As Exception
            MsgBox("Tabela de PRODUTOS ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return False

        End Try

        CmdProduto.CommandText = "" : SqlProduto.Remove(_valorZERO, SqlProduto.ToString.Length)
        oConnBDGENOV.ClearPool() : oConnBDGENOV.Close()
        CmdProduto = Nothing : SqlProduto = Nothing : oConnBDGENOV = Nothing


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
                pesoBrutoProd_Ref = drProduto(15)
                pesoLiqProd_Ref = drProduto(16)
                local_ref = Mid(cbo_local.SelectedItem, 1, 2)
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
            drProduto.Close() : drProduto = Nothing


        Catch ex As Exception
            MsgBox("Tabela de PRODUTOS ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return False

        End Try

        CmdProduto.CommandText = "" : SqlProduto.Remove(_valorZERO, SqlProduto.ToString.Length)
        oConnBDGENOV.ClearPool() : oConnBDGENOV.Close()
        CmdProduto = Nothing : SqlProduto = Nothing : oConnBDGENOV = Nothing



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


        If Me.dtg_pedidoprotaentrega.Rows.Count <= _valorZERO Then

            lbl_mensagem.Text = "Informe algum Item por favor !" : Return False

        End If



        Return True
    End Function

    Private Function verificaProduto() As Boolean

        lbl_mensagem.Text = ""

        'Dim conection As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        'Try
        '    conection.Open()
        'Catch ex As Exception
        '    MsgBox("ERRO::" & ex.Message) : Return False
        'End Try

        'Dim mqtdeAtual As Double = _clBD.pegaQtdeEstoque(codProd_Ref, FilialProd_Ref, conection)
        'conection = Nothing


        'If mqtdeAtual < CDbl(txt_qtde.Text) Then

        '    lbl_mensagem.Text = "Quantidade Requerida é Maior do que a do Estoque ! ""QtdeAtual = " & mqtdeAtual & """"
        '    Me.txt_qtde.Focus() : Me.txt_qtde.SelectAll() : Return False

        'End If

        If CDbl(txt_qtde.Text) <= _valorZERO Then

            lbl_mensagem.Text = "Quantidade Requerida deve ser maior que ZERO ! "
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

                                'If Me.txt_consumo.Text.Equals("N") Then 'Se não for para consumo

                                '    Try
                                '        malqsub = MdlEmpresaUsu._alqSubst
                                '        mvlSubPorItem = Round(((mvlUnitVendPorItem * malqsub) / 100), 2)
                                '        mvlsub = Round(mvlSubPorItem * CDbl(txt_qtde.Text), 2)
                                '        mbasesub = Round((mvlsub * 100) / malqsub, 2)
                                '        mvlUnitVendPorItem = Round(mvlUnitVendPorItem + mvlSubPorItem, 2)
                                '    Catch ex As Exception
                                '        mbasesub = 0 : malqsub = 0 : mvlsub = 0
                                '    End Try
                                '    mvltotal = Round(mvltotal + mvlsub, 2)
                                'End If
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
            Me.txt_descontosTotais.Text = Format(somaVlrTdescItensGrid, "###,##0.00")

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

                    If _numPedidoOK = False Then

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

                    End If
                End If

            Else

                addItemEditadoGrid()
            End If

            local_ref = Mid(Me.cbo_local.SelectedItem, 1, 2) : FilialProd_Ref = Mid(Me.cbo_local.SelectedItem, 1, 2)
            Me.txt_codProd.Text = "" : Me.txt_qtde.Text = "1,00" : Me.txt_valor.Text = "0,00"
            xcont = xcont + 1 : Me.txt_codProd.Focus() : _qtdeAnteriorProd = _valorZERO

            If Me.dtg_pedidoprotaentrega.Rows.Count > _valorZERO Then

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

                                'If Me.txt_consumo.Text.Equals("N") Then 'Se não for para consumo

                                '    Try
                                '        malqsub = MdlEmpresaUsu._alqSubst
                                '        mvlSubPorItem = Round(((mvlUnitVendPorItem * malqsub) / 100), 2)
                                '        mvlsub = Round(mvlSubPorItem * CDbl(txt_qtde.Text), 2)
                                '        mbasesub = Round((mvlsub * 100) / malqsub, 2)
                                '        mvlUnitVendPorItem = Round(mvlUnitVendPorItem + mvlSubPorItem, 2)
                                '    Catch ex As Exception
                                '        mbasesub = 0 : malqsub = 0 : mvlsub = 0
                                '    End Try
                                '    mvltotal = Round(mvltotal + mvlsub, 2)
                                'End If
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
            Me.txt_descontosTotais.Text = Format(somaVlrTdescItensGrid, "###,##0.00")

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
        lbl_mensagem.Text = "" : _qtdeAnteriorProd = _valorZERO : _codProdEditando = ""
        _indexProdEditando = _valorZERO


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

    Private Sub incluiRegistroOrcamento(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim nt_orca, nt_geno, nt_codig, nt_cfop, nt_vend, nt_cid, nt_x, nt_y As String
        Dim nt_tipo2, nt_auto, nt_auto2 As String
        Dim nt_dtemis, nt_dtsai As Date
        Dim nt_emiss As Boolean = False
        Dim itens, nt_rota, nt_parc, nt_cod1, nt_cod2, nt_cod3, nt_cod4, nt_cod5 As Integer
        Dim nt_cod6, nt_cod7, nt_mapa, nt_sit, mProxNumPedido, nt_itens As Integer
        Dim nt_peso, nt_volum As Double

        nt_geno = MdlUsuarioLogando._local
        nt_codig = mCodPart
        nt_dtemis = dtp_emissao.Value
        nt_dtsai = nt_dtemis
        nt_emiss = False
        nt_cfop = "5102"
        nt_cid = mCidadePart
        nt_itens = Me.dtg_pedidoprotaentrega.Rows.Count
        nt_vend = Trim(Mid(cbo_vendedor.SelectedItem, 1, 6))

        nt_x = "" : nt_y = ""

        nt_volum = somaVolumeItensGrid()
        nt_auto = MdlUsuarioLogando._usuarioLogin
        nt_auto2 = ""
        nt_mapa = _valorZERO

        'nt_sit -- Verifica status do Pedido 1-Digitado , 2-Impresso, 3 - ECF , 4-NFe
        nt_sit = 1

        ''Numero do orcamento...
        nt_orca = Me.txt_orcamento.Text

        _clBD.incOrcamento_Orca1(_numOrcamentoAtual, nt_orca, nt_geno, nt_codig, nt_dtemis, nt_dtsai, nt_emiss, nt_cfop, _
                              nt_vend, nt_cid, nt_itens, nt_rota, nt_peso, nt_x, nt_y, nt_parc, _
                              nt_volum, nt_tipo2, nt_auto, nt_auto2, nt_cod1, nt_cod2, nt_cod3, _
                              nt_cod4, nt_cod5, nt_cod6, nt_cod7, nt_mapa, nt_sit, mbUf, conexao, transacao)



    End Sub


    Private Sub incluiDtg_itens(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

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

        For Each row As DataGridViewRow In Me.dtg_pedidoprotaentrega.Rows

            If Not row.IsNewRow Then

                mCodpr = row.Cells(2).Value
                mcdBarra = row.Cells(3).Value
                MUnd = row.Cells(5).Value
                mQtde = row.Cells(6).Value
                mPrunit = row.Cells(25).Value
                mPrvenda = row.Cells(7).Value 'mPrvenda
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


                _clBD.incOrcamento_Orca2(Mid(cbo_local.SelectedItem, 1, 2), Me.txt_orcamento.Text, mCodpr, MUnd, mQtde, mPrvenda, malqdesc, _
                                       mvldesc, mPrunit, mtotal, malqicms, mbaseIcms, mbasesub, malqsub, mvlsub, _
                                       mdtemis, mrota, "01", mCodVendedor, mLinha, mGrupo, malqcom, mcomis, _valorZERO, _
                                       _numOrcamentoAtual, 2, Me.txt_codpart.Text, mFilial, mpesoBruto, mpesoLiq, mcdBarra, _
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
        Dim segu, outros, ipi, tgeral, peso, desc As Double

        tipo = "P" : nume = Me.txt_orcamento.Text : tipo2 = ""

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

        _clBD.incOrcamento_Orca4(tipo, nume, tprod, aliss, vliss, vlser, basec, icms, bsub, icsub, tpro2, _
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
            If Not row.IsNewRow Then mVlrTprodItens += (row.Cells(6).Value * row.Cells(7).Value)

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

                        incluiRegistroOrcamento(conexao, transacao)
                        incluiDtg_itens(conexao, transacao)
                        inclueOrca4(conexao, transacao)

                        transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                        MsgBox("Registro Efetuado c/ Sucesso", MsgBoxStyle.Exclamation, "METROSYS")

                        executaRelatorioOrcamento("", "\wged\orcamentoSucesso.txt")
                        Me.txt_orcamento.Text = ""

                        zeraTudo() : Me.cbo_local.Focus() : _numPedidoOK = False

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


        Try

            executeF5()

        Catch ex As Exception
        End Try


    End Sub

    Private Sub DeleteItemGrid()

        Try

            lbl_mensagem.Text = ""
            If Me.dtg_pedidoprotaentrega.Enabled = True Then
                'Remove Linha
                Dim mLocal As String = dtg_pedidoprotaentrega.CurrentRow.Cells(21).Value.ToString
                Dim codigoProduto As String = dtg_pedidoprotaentrega.CurrentRow.Cells(2).Value.ToString
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
                Me.txt_descontosTotais.Text = Format(somaVlrTdescItensGrid, "###,##0.00")


                If _indexProdEditando >= _valorZERO Then

                    _indexProdEditando = -1 : _codProdEditando = ""
                End If

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
            End If
        End If



    End Sub


    'Inicia-se o Tratamento da Impressão do pedido...
    Private Sub executaRelatorio1(ByVal s As StreamWriter, ByVal loja As String, ByVal numeroOrcamento As String, ByVal dtEmissao As String, ByVal codClient As String, ByVal nomeClient As String, ByVal condicao As String, ByVal codVendedor As String, ByVal idOrca1 As Int32, ByRef shouldReturn As Boolean)

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
        _mConsulta.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codClient & "'")
        Dim lShouldReturn2 As Boolean
        _clFuncoes.GravCabCliOrcamentoMatricial(_mConsulta.ToString, s, codClient, numeroOrcamento, dtEmissao, codVendedor, condicao, loja, lShouldReturn2)
        If lShouldReturn2 Then shouldReturn = True : Return

        'Orçamento
        s.WriteLine("-------------------------------------------------------------------------------------")
        s.WriteLine(_clFuncoes.Centraliza_Str("ORÇAMENTO Nº " & numeroOrcamento, 85) & vbNewLine)

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'itens
        _mConsulta.Append("SELECT o2.no_codpr, o2.no_qtde, o2.no_und, e.e_produt, o2.no_prunit, o2.no_prtot, o2.no_filial, el.e_locacao, o2.no_vldesc, o2.no_pesobruto, o2.no_vlsub ") '10
        _mConsulta.Append("FROM estloja01 el, " & MdlEmpresaUsu._esqEstab & ".tb_orca2 o2 LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 ")
        _mConsulta.Append("e ON e.e_codig = o2.no_codpr WHERE no_idorca1 = " & idOrca1 & " AND el.e_loja = o2.no_filial AND el.e_codig = o2.no_codpr")
        Dim lShouldReturn3 As Boolean
        _clFuncoes.GravItensOrcamentoMatricial(_mConsulta.ToString, s, numeroOrcamento, idOrca1, codClient, nomeClient, lShouldReturn3)
        If lShouldReturn3 Then shouldReturn = True : Return

    End Sub

    Private Sub executaRelatorioOrcamento(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TempOrcamento.TMP"
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
        _PrintFont = New Font("Lucida Console", 9)
        Dim strLinha As String = ""
        Dim loja As String = "G00" & Mid(Me.cbo_local.SelectedItem, 1, 2)
        Dim numeroOrcamento As String = Me.txt_orcamento.Text
        Dim dtEmissao As String = Me.dtp_emissao.Text
        Dim codClient As String = Me.txt_codpart.Text
        Dim nomeClient As String = Me.txt_nomePart.Text
        Dim condicao As String = ""
        Dim codVendedor As String = Trim(Mid(Me.cbo_vendedor.SelectedItem, 1, 6))
        Dim idOrca1 As Int32 = Convert.ToInt64(Me.txt_orcamento.Text)

        Select Case MdlRelatorioTelas._tl_movorcamento

            Case 1 'Impressora Matricial
                Dim lShouldReturn As Boolean
                executaRelatorio1(s, loja, numeroOrcamento, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
                If lShouldReturn Then Return

            Case 2 'Impressora Laiser
                Dim lShouldReturn As Boolean
                'executaRelatorio2(s, loja, numeroOrcamento, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
                If lShouldReturn Then Return

            Case Else
                Dim lShouldReturn As Boolean
                executaRelatorio1(s, loja, numeroOrcamento, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
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

        If _descVendedor > _valorZERO Then

            If CDbl(Me.txt_desconto.Text) > _descVendedor Then

                lbl_mensagem.Text = "Valor do Desconto dever ser menor que " & _descVendedor & "% !"
                Me.txt_desconto.Focus() : Me.txt_desconto.SelectAll() : Return
            End If
        End If



    End Sub

    Private Sub txt_pedido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_orcamento.TextChanged

        If Me.txt_orcamento.Text.Equals("") Then Me._numPedidoOK = False

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

    Private Sub cbo_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_vendedor.GotFocus
        If Not cbo_vendedor.DroppedDown Then cbo_vendedor.DroppedDown = True
    End Sub

    Private Sub Frm_Orcamento_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing


        If dtg_pedidoprotaentrega.Rows.Count > 0 Then

            If MessageBox.Show("Deseja Realmente Sair?", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
            = Windows.Forms.DialogResult.No Then

                e.Cancel = True
            End If
        End If

    End Sub
End Class