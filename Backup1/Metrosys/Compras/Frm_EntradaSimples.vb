Imports System.IO
Imports System.DateTime
Imports System.Text
Imports System.Math
Imports Npgsql
Imports Npgsql.NpgsqlTransaction
Imports System.Drawing.Printing

Public Class Frm_EntradaSimples

    Private agora As Date = Now
    Private _BuscaForn As New Frm_BuscaForn
    Private _BuscaProd As New Frm_BuscaProdMp
    Public local_Ref As String = Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1)
    Private _loja As String = Mid(MdlEmpresaUsu._codigo, MdlEmpresaUsu._codigo.Length - 1, 2)
    Private codBarras, vCodprod As String
    Private vqtde, vTotal As Double
    Private linhaAtual As Integer = -1
    Public _gradeRef As String = ""
    Private _clFuncoes As New ClFuncoes
    Private codLoja As String = ""
    Private Mnatur As String = "E"
    '
    ' Variaveis auxiliares:
    Private vNatureza As String
    Private _tipoBusca As String = ""

    '
    ' Informações de conexão e auxilio com banco de dados
    Private Cl_bd As New Cl_bdMetrosys
    Private transacao As NpgsqlTransaction
    Private transacao2 As NpgsqlTransaction
    Private Conn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Private conex As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Private mGravaitens As Boolean = False
    Private Mindice As Integer


    'Atributos do Participante...
    Public mbUf As String = "", mbCNPJ As String = ""
    Public _codPart As String = "", _nomePart As String = ""
    Private _formBusca As Boolean = False

    'Forms:
    Private frmBuscaNome As New Frm_NomeResp
    Private frmBuscaCnpjCpf As New Frm_CnpjCpfResp
    Private frmBuscaNumeroNFe As New Frm_numeroNFeResp
    Private frmBuscaDataPeriodo As New Frm_DataPeriodoResp
    Public Shared _frmREf As New Frm_EntradaSimples

    'Variaveis de Referencia:
    Public nomeRef, cnpjCpfRef, numeroNFeRef As String
    Public dataInicialRef, dataFinalRef As Date

    'Variáveis impressão:
    Private _StringToPrint As String = ""
    Private mDgProdutos As New DataGridView
    Private MostrarCaixaImpressoras As Boolean = False
    Private _PrintFont As New Font("Lucida Console", 8) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _sImpressao As StreamWriter
    Private _dtAdaptPrint As NpgsqlDataAdapter


    Private Sub Frm_EntradaSimples_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                executaF5()
            Case Keys.P
                If tbc_entradaSimples.SelectedIndex = 0 Then Me.tsb_opcoes.ShowDropDown()
            Case Keys.R
                If tbc_entradaSimples.SelectedIndex = 0 Then Me.tsb_relatorio.ShowDropDown()

        End Select


    End Sub

    Private Sub executaF5()
        lbl_mensagem.Text = ""
        preecheDtgNFeBusca("")
    End Sub

    Private Sub Frm_EntradaSimples_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btn_lancaitens.Enabled = False
        Me.cbo_natureza.SelectedIndex = 0
        limpa_totalizador()
        '
        '  Desabilita boao de Itens
        Me.btn_itinclui.Enabled = False : Me.btn_itexclui.Enabled = False
        Me.btn_itsai.Enabled = False : Me.txt_codProd.Enabled = False
        '
        ' Desabilita Controles de Tamanho p/ Prdutos s/ Grade
        Me.lbl_tm.Visible = False : Me.lbl_cor.Visible = False
        Me.txt_tamanho.Visible = False : Me.cbo_cores.Visible = False
        '
        ' Iniciando controles dos itens
        Me.txt_qtde.Text = "0,00" : Me.txt_vlproduto.Text = "0,00"
        Me.txt_desconto.Text = "0,00" : Me.txt_total.Text = "0,00"
        Me.txt_vlUnitario.Text = "0,00" : Me.txt_taxageral.Text = "0,00"
        Me.txt_custo.Text = "0,00" : Me.txt_lucro.Text = "0,00" : Me.txt_pcosugerido.Text = "0,00"
        Me.cbo_local = _clFuncoes.PreenchComboLoja(Me.cbo_local, MdlConexaoBD.conectionPadrao)
        Me.cbo_local.SelectedIndex = _clFuncoes.trazIndexComboBox(_loja, 2, Me.cbo_local)
        Me.cbo_local.Enabled = False

        'relaciona o objeto pd ao procedimento
        AddHandler pdRelatorio.BeginPrint, AddressOf InicializaRelatorio

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdGrafico.PrintPage, AddressOf rptGravaTotaisNF
        AddHandler pdGrafico.EndPrint, AddressOf InicializaRelatorio
        AddHandler PrintPreviewDialog1.FormClosed, AddressOf fechaCaixaImpressao
        executaF5()


    End Sub

    Private Sub txt_totgeral_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_totgeral.Leave
        If txt_documento.Text = "" Then
            MessageBox.Show("Digite Numero do Documento ", "Documento em Branco ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_documento.Focus()
        Else
            Me.btn_lancaitens.Enabled = True
        End If
        txt_totgeral.Text = Format(CDbl(Me.txt_totgeral.Text), "###,##0.00")
    End Sub

    Private Sub txt_codpart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codpart.KeyDown
        If Not Me.txt_codpart.Text.Equals("") Then

            If Me.txt_codpart.TextLength > 5 AndAlso e.KeyCode = Keys.Enter Then 'Se retornar nada

                If trazFornecedor(Me.txt_codpart.Text) Then

                    'Aqui tenta chamar a Busca do Produto...
                    Try
                        Me.txt_nomePart.Focus()
                        Me.txt_nomePart.SelectAll()

                        Return
                    Catch ex As Exception
                    End Try

                End If
            End If
        End If

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            If Me.txt_codpart.Text.Equals("") Then


                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try

                    _frmREf = Me
                    _BuscaForn.set_frmRef(Me)
                    _BuscaForn.ShowDialog(Me)
                    If Me.txt_codpart.Text.Equals("") Then Me.txt_codpart.Focus()

                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()

                Catch ex As Exception
                End Try

            End If
        End If
    End Sub

    Public Function trazFornecedor(ByVal codFornec As String) As Boolean

        Dim nomeCampo As String = ""
        Dim nomeCampoCgc As String = ""
        Dim nomeCampoCpf As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        Dim pesquisa As String = codFornec.ToUpper

        Try
            If oConnBDGENOV.State = ConnectionState.Closed Then
                oConnBDGENOV.Open()
            End If
        Catch ex As Exception
        End Try

        If oConnBDGENOV.State = ConnectionState.Open Then
            Dim codigo, nome, cpf_cnpj, inscricao, UF As String

            Try
                SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc, p_uf FROM cadp001 WHERE ") ' 5
                SqlParticipante.Append("p_cod = '" & pesquisa & "' ORDER BY p_portad ASC")
                CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDGENOV)
                drParticipante = CmdParticipante.ExecuteReader

                If drParticipante.HasRows = False Then
                    Return False
                Else
                    While drParticipante.Read
                        codigo = drParticipante(0).ToString
                        nome = drParticipante(1).ToString
                        If Not drParticipante(2).ToString.Equals("") Then 'se tiver CNPJ...
                            cpf_cnpj = drParticipante(2).ToString
                        Else
                            cpf_cnpj = drParticipante(3).ToString
                        End If
                        inscricao = drParticipante(4).ToString
                        UF = drParticipante(5).ToString

                    End While
                    Me.txt_nomePart.Text = nome
                    Me.mbCNPJ = cpf_cnpj
                    Me.mbUf = UF

                End If

            Catch ex As Exception
            End Try

            CmdParticipante.CommandText = ""
            SqlParticipante.Remove(0, SqlParticipante.ToString.Length)
        End If

        Return True
    End Function

    Private Sub Frm_EntradaSimples_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txt_totprodutos_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_totprodutos.Leave
        Me.txt_basecalculo.Text = Me.txt_totprodutos.Text
        Me.txt_totgeral.Text = Me.txt_totprodutos.Text
        Me.txt_totprodutos.Text = Format(CDbl(Me.txt_totprodutos.Text), "###,##0.00")
    End Sub

    Private Sub txt_documento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_documento.Leave
        Try
            If txt_documento.Text = "" Then
                MessageBox.Show("Digite Numero do Documento !", "Documento em Branco ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_documento.Focus()
            End If
            txt_documento.Text = String.Format("{0:D9}", CInt(Me.txt_documento.Text))
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub txt_alqicms_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqicms.Leave
        Me.txt_vlicms.Text = Round((CDbl(txt_basecalculo.Text) * CDbl(txt_alqicms.Text)) / 100, 2)
        Me.txt_vlicms.Text = Format(CDbl(txt_vlicms.Text), "##,###0.00")
        Me.txt_alqicms.Text = Format(CDbl(txt_alqicms.Text), "##0.00")
    End Sub

    Private Sub btn_lancaitens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lancaitens.Click
        If MessageBox.Show(" Confirme Dados ? ", " Confirmação  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.txt_codProd.Enabled = True
            Me.btn_itinclui.Enabled = True : Me.btn_itexclui.Enabled = True
            Me.btn_itsai.Enabled = True
            If cbo_natureza.SelectedIndex = 1 Then vNatureza = "C" Else vNatureza = "T"


            Me.txt_codProd.Focus()
        Else
            Me.txt_codpart.Focus()
        End If

    End Sub

    Private Sub txt_basecalculo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_basecalculo.Leave
        If Trim(Me.txt_basecalculo.Text).Equals("") Then
            Me.txt_basecalculo.Text = Format(0.0, "###,##0.00")
        Else
            Me.txt_basecalculo.Text = Format(CDbl(Me.txt_basecalculo.Text), "###,##0.00")
        End If

    End Sub

    Private Sub txt_tamanho_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tamanho.Leave
        Me.txt_qtde.Text = "0"
    End Sub

    Private Sub txt_codProd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codProd.GotFocus
        Me.btn_lancaitens.Enabled = False
    End Sub

    Private Sub txt_codProd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codProd.KeyDown
        If (e.KeyCode = Keys.Enter) Then


            If Me.txt_codProd.Text.Equals("") Then

                'Aqui tenta chamar a Busca do Produto...
                Try
                    _formBusca = True : _frmREf = Me : _BuscaProd.set_frmRef(Me)
                    _BuscaProd.ShowDialog(Me) : _formBusca = False
                    If Me.txt_codProd.Text.Equals("") Then Me.txt_codProd.Focus()
                    If _gradeRef.Equals("S") Then

                    End If

                Catch ex As Exception
                End Try

            Else

                If trazItenBD(Me.txt_codProd.Text) = False Then

                    'Aqui tenta chamar a Busca do Produto...
                    Try
                        _formBusca = True : _frmREf = Me : _BuscaProd.set_frmRef(Me)
                        _BuscaProd.ShowDialog(Me) : _formBusca = False
                        If Me.txt_codProd.Text.Equals("") Then Me.txt_codProd.Focus()
                        '  txt_codProd_KeyDownExtracted()

                    Catch ex As Exception
                    End Try

                Else
                    ' txt_codProd_KeyDownExtracted()

                End If
            End If
        End If

    End Sub

    Public Function trazItenBD(ByVal codIten As String) As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        Dim codigo, nome, fornecedor, qtdEstoque, undMedida, ncmProd As String
        Dim CST, CFV, GRUPO, REDUZ As Integer
        Dim sldAtual, pcoAnt, custAnt, CLF As String

        Try
            SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, e.e_qtdfisc, e.e_und, e.e_ncm, ") ' 5
            SqlProduto.Append("e.e_cst, e.e_cfv, e.e_grupo, e.e_reduz, el.e_qtdfisc, el.e_pcusto, el.e_pcomp, ") ' 12
            SqlProduto.Append("e.e_clf, e.e_cdbarra FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN estloja01 el ON e.e_codig = el.e_codig WHERE ")
            SqlProduto.Append("el.e_loja = '01" & "' AND el.e_codig = ")
            SqlProduto.Append("'" & codIten & "' ORDER BY e_produt ASC")

            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDGENOV)
            drProduto = CmdProduto.ExecuteReader

            If drProduto.HasRows = False Then Return False
            While drProduto.Read

                codigo = drProduto(0).ToString : nome = drProduto(1).ToString
                fornecedor = drProduto(2).ToString : qtdEstoque = drProduto(3).ToString
                undMedida = drProduto(4).ToString : ncmProd = drProduto(5).ToString
                CST = drProduto(6) : CFV = drProduto(7) : GRUPO = drProduto(8)
                REDUZ = drProduto(9) : sldAtual = drProduto(10).ToString
                custAnt = drProduto(11).ToString : pcoAnt = drProduto(12).ToString
                CLF = drProduto(13).ToString
                codBarras = drProduto(14).ToString

                'mCstIten = CST : mCfvIten = CFV : mClfIten = CLF : mGrupoIten = GRUPO
                'mReduzIten = REDUZ

                Me.txt_codProd.Text = codigo : Me.txt_nomeProd.Text = nome
                'Me.mbUndProd = undMedida : Me.txt_SaldoAtual.Text = sldAtual
                'Me.txt_custAnter.Text = custAnt : Me.txt_pcoAnt.Text = pcoAnt

            End While
            drProduto.Close() : oConnBDGENOV.ClearPool()

        Catch ex As Exception
            MsgBox("ERRO ao trazer ITEM:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        Finally

            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
        End Try


        CmdProduto.CommandText = "" : SqlProduto.Remove(0, SqlProduto.ToString.Length)

        'LIMPA OBJETOS DA MEMÓRIA...
        codigo = Nothing : nome = Nothing : fornecedor = Nothing : qtdEstoque = Nothing
        undMedida = Nothing : ncmProd = Nothing : CST = Nothing : CFV = Nothing
        GRUPO = Nothing : REDUZ = Nothing : sldAtual = Nothing : pcoAnt = Nothing
        custAnt = Nothing : CLF = Nothing

        SqlProduto = Nothing : oConnBDGENOV = Nothing : drProduto = Nothing : CmdProduto = Nothing

        Return True
    End Function

    Private Sub txt_total_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total.Leave
        Try
            Me.txt_vlUnitario.Text = (CDbl(Me.txt_total.Text) / CDbl(Me.txt_qtde.Text))
            Me.txt_vlUnitario.Text = Format(CDbl(Me.txt_vlUnitario.Text), "##,###0.00")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub txt_taxageral_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_taxageral.Leave
        Dim mcusto As Double = 0.0
        mcusto = ((CDbl(Me.txt_vlUnitario.Text) * (CDbl(Me.txt_taxageral.Text)) / 100))
        Me.txt_custo.Text = CDbl(Me.txt_vlUnitario.Text) + Round(mcusto, 2)
        Me.txt_custo.Text = Format(CDbl(Me.txt_custo.Text), "##,###0.00")
        Me.txt_taxageral.Text = Format(CDbl(Me.txt_taxageral.Text), "##0.00")
    End Sub

    Private Sub txt_lucro_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lucro.Leave
        Dim mPcoSugerido As Double = 0.0
        mPcoSugerido = ((CDbl(Me.txt_custo.Text) * (CDbl(Me.txt_lucro.Text)) / 100))
        Me.txt_pcosugerido.Text = CDbl(Me.txt_custo.Text) + Round(mPcoSugerido, 2)
        Me.txt_pcosugerido.Text = Format(CDbl(Me.txt_pcosugerido.Text), "##,###0.00")
        txt_lucro.Text = Format(CDbl(txt_lucro.Text), "##0.00")
    End Sub

    Private Sub txt_desconto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_desconto.Leave
        Dim mDesconto As Double = 0.0
        mDesconto = CDbl(Me.txt_desconto.Text)

        Me.txt_total.Text = (CDbl(Me.txt_vlproduto.Text) * CDbl(Me.txt_qtde.Text)) - mDesconto
        Me.txt_total.Text = Format(CDbl(Me.txt_total.Text), "##,###0.00")
        Me.txt_desconto.Text = Format(CDbl(Me.txt_desconto.Text), "##,###0.00")
    End Sub

    Private Sub btn_itinclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_itinclui.Click
        Dim ve_cdbarra As String = ""

        Dim mlinha As String() = {txt_codProd.Text, codBarras.ToString, txt_nomeProd.Text, txt_tamanho.Text, txt_qtde.Text, _
                                 txt_vlproduto.Text, txt_desconto.Text, txt_vlUnitario.Text, txt_total.Text, _
                                 txt_custo.Text}

        'Adicionando Linha
        Me.dtg_itemsEntradaSimples.AllowUserToResizeColumns = False
        Me.dtg_itemsEntradaSimples.AllowUserToResizeRows = False
        Me.dtg_itemsEntradaSimples.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
        ' Me.dtg_EntradaSimples.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells


        Me.dtg_itemsEntradaSimples.Columns(2).Width = 250

        Me.dtg_itemsEntradaSimples.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dtg_itemsEntradaSimples.Columns(4).DefaultCellStyle.Format = "###,##0.00"


        Me.dtg_itemsEntradaSimples.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dtg_itemsEntradaSimples.Columns(4).DefaultCellStyle.Format = "###,##0.00"

        Me.dtg_itemsEntradaSimples.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dtg_itemsEntradaSimples.Columns(5).DefaultCellStyle.Format = "###,##0.00"

        Me.dtg_itemsEntradaSimples.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dtg_itemsEntradaSimples.Columns(6).DefaultCellStyle.Format = "###,##0.00"

        Me.dtg_itemsEntradaSimples.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dtg_itemsEntradaSimples.Columns(7).DefaultCellStyle.Format = "###,##0.00"

        Me.dtg_itemsEntradaSimples.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dtg_itemsEntradaSimples.Columns(8).DefaultCellStyle.Format = "###,##0.00"

        Me.dtg_itemsEntradaSimples.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.dtg_itemsEntradaSimples.Columns(9).DefaultCellStyle.Format = "###,##0.00"

        Me.dtg_itemsEntradaSimples.Rows.Add(mlinha)
        Me.dtg_itemsEntradaSimples.Refresh()

        Try
            If mGravaitens = False Then
                Conn.Open()
                ' *** Grava Totais das Entrada  ***
                ' ***                           ***
                Cl_bd.Reg_EntradaSimples(0, txt_codpart.Text, txt_documento.Text, dtp_dtemissao.Value, dtp_dtentrada.Value, _
                                    CDbl(txt_totprodutos.Text), CDbl(txt_basecalculo.Text), CDbl(txt_alqicms.Text), CDbl(txt_vlicms.Text), _
                                    CDbl(txt_totgeral.Text), txt_tipo.Text, codLoja, vNatureza, transacao, Conn)

                ' ** pega indice gravado dos totais
                Mindice = Cl_bd.trazIdNote4f(Conn, txt_documento.Text)
                Conn.Close()
            End If

            '  *** Inicia Gravação dos Itens na Entrada  ***
            '  ***                                       ***
            If cbo_natureza.SelectedIndex = 2 Then
                Mnatur = "R"
            End If
            Cl_bd.Reg_ItemSimples(0, txt_codProd.Text, txt_tamanho.Text, Mid(cbo_cores.SelectedItem, 1, 2), _
                            ve_cdbarra.ToString, CDbl(txt_qtde.Text), CDbl(txt_vlproduto.Text), CDbl(txt_desconto.Text), _
                            CDbl(txt_vlUnitario.Text), CDbl(txt_total.Text), CDbl(txt_taxageral.Text), _
                            CDbl(txt_custo.Text), CDbl(txt_lucro.Text), CDbl(txt_pcosugerido.Text), _
                            txt_tipo.Text, Mnatur, txt_documento.Text, Mindice, transacao2, conex)

            ' Adiciona Registro ao Estoque
            If cbo_natureza.SelectedIndex = 2 Then
                Cl_bd.somaQtdeProdFisc_entradaSimples(txt_codpart.Text, txt_codProd.Text, codLoja, CDbl(txt_qtde.Text), _
                                                             dtp_dtentrada.Value, conex, transacao2)
            Else
                Cl_bd.somaQtdeProd_entradaSimples(txt_codpart.Text, txt_codProd.Text, codLoja, CDbl(txt_qtde.Text), _
                                                            dtp_dtentrada.Value, CDbl(txt_vlUnitario.Text), _
                                                            CDbl(txt_custo.Text), conex, transacao2)

            End If

            Me.lbl_mensagem.Text = "Registro Incluido c/ Sucesso !"

        Catch ex As Exception
            transacao.Rollback()
            MsgBox(ex.Message.ToString)
            Me.lbl_mensagem.Text = ""
            Me.txt_codpart.Focus()
        End Try

        mGravaitens = True : Me.txt_codProd.Text = ""
        limpa_itens()
        Me.txt_codProd.Focus()

    End Sub

    Private Sub limpa_itens()
        Me.txt_nomeProd.Text = ""
        Me.txt_qtde.Text = "0,00" : Me.txt_vlproduto.Text = "0,00"
        Me.txt_desconto.Text = "0,00" : Me.txt_total.Text = "0,00"
        Me.txt_vlUnitario.Text = "0,00" : Me.txt_tamanho.Text = "" : cbo_cores.SelectedIndex = -1
        Me.txt_custo.Text = "0,00" : Me.txt_pcosugerido.Text = "0,00"

    End Sub

    Private Sub limpa_totalizador()
        Me.txt_codpart.Text = ""
        Me.txt_nomePart.Text = ""
        Me.txt_documento.Text = ""
        Me.txt_tipo.Text = ""
        Me.txt_totprodutos.Text = "0,00"
        Me.txt_basecalculo.Text = "0,00"
        Me.txt_totgeral.Text = "0,00"
        Me.txt_vlicms.Text = "0,00"
        Me.txt_alqicms.Text = "0,00"
        Me.dtp_dtentrada.Value = DateValue(Now)
        Me.dtp_dtemissao.Value = DateValue(Now).AddDays(-3)
        Me.cbo_natureza.SelectedIndex = 0

    End Sub

    Private Sub btn_itsai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_itsai.Click
        If CDbl(txt_totGeralITems.Text) <> CDbl(txt_totgeral.Text) Then
            MessageBox.Show("Atenção Valores Totais Incorretos , Favor Corrigir !", "Erro nos Totais ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_codProd.Focus()
        Else
            MessageBox.Show("Documento Registrado  C/ Sucesso ", " Confirmação ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            limpa_itens()
            limpa_totalizador()
            Me.btn_lancaitens.Enabled = True
            Me.dtg_itemsEntradaSimples.Rows.Clear()
            Me.txt_codProd.Enabled = False
            Me.cbo_natureza.SelectedIndex = 0
            Me.txt_codpart.Focus()
        End If

    End Sub

    Private Sub txt_qtde_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtde.Leave
        Me.lbl_mensagem.Text = ""
        If txt_qtde.Text = "0,00" Or txt_qtde.Text = "" Then
            MessageBox.Show("Digite Quantidade ! ", "Quantidade Zerada ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_qtde.Focus()
            Return
        End If
    End Sub

    Private Sub btn_itexclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_itexclui.Click
        Dim mPegaTotal As Double = 0.0
        mPegaTotal = CDbl(txt_totGeralITems.Text)
        If linhaAtual <> -1 Then
            If cbo_natureza.SelectedIndex = 2 Then
                Cl_bd.subtraiQtdeProdFisc_entradaSimples(vCodprod, codLoja, vqtde, conex, transacao2)
            Else
                Cl_bd.subtraiQtdeProd_entradaSimples(vCodprod, codLoja, vqtde, conex, transacao2)
            End If

            Me.dtg_itemsEntradaSimples.Rows.Remove(dtg_itemsEntradaSimples.CurrentRow)
            Me.txt_totGeralITems.Text = Round((mPegaTotal), 2) - Round(vTotal, 2)
            Me.txt_totGeralITems.Text = Format(CDbl(Me.txt_totGeralITems.Text), "###,##0.00")
            lbl_mensagem.Text = "Registro Excluido C/ Sucesso !"
        Else
            MessageBox.Show("Favor Selecione uma linha, para Deletar ", " Deleta Registro ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_codProd.Focus()
        End If
        linhaAtual = -1
    End Sub

    Private Sub dtg_EntradaSimples_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_itemsEntradaSimples.CellContentClick
        vTotal = 0.0
        linhaAtual = Convert.ToInt32(e.RowIndex.ToString())
        vCodprod = Me.dtg_itemsEntradaSimples.CurrentRow.Cells(0).Value.ToString()
        vqtde = Me.dtg_itemsEntradaSimples.CurrentRow.Cells(4).Value.ToString()
        vTotal = Me.dtg_itemsEntradaSimples.CurrentRow.Cells(8).Value.ToString()
    End Sub

    Private Sub cbo_local_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_local.SelectedIndexChanged

        codLoja = Mid(cbo_local.SelectedItem.ToString, 1, 2)
    End Sub

#Region "  *** Funções e Procedimentos Auxiliares ***  "

    Private Function somaVlrTotalItensGrid() As Double

        Dim mVlrTotalITens As Double = 0
        Dim mVlrTotaLGeralItens As Double = 0
        Dim mVlrDescItens As Double = 0
        mVlrTotaLGeralItens = somaVlrTotalGeralItensGrid()
        mVlrDescItens = somaVlrDescontoItensGrid()

        mVlrTotalITens = Round(mVlrTotaLGeralItens + mVlrDescItens, 2)
        Return mVlrTotalITens
    End Function

    Private Function somaVlrTotalGeralItensGrid() As Double

        Dim mVlrTotalGeraLItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itemsEntradaSimples.Rows

            If Not row.IsNewRow Then mVlrTotalGeraLItens += row.Cells(8).Value

        Next

        Return mVlrTotalGeraLItens
    End Function

    Private Function somaVlrIcmsItensGrid() As Double

        Dim mVlrIcmsItens As Double = 0
        'For Each row As DataGridViewRow In Me.dtg_itemsEntradaSimples.Rows

        '    If Not row.IsNewRow Then mVlrIcmsItens += row.Cells(14).Value

        'Next

        mVlrIcmsItens = 0 'Round(mVlrIcmsItens, 2)
        Return mVlrIcmsItens
    End Function

    Private Function somaVlrBaseIcmsItensGrid() As Double

        Dim mVlrBaseIcmsItens As Double = 0
        'For Each row As DataGridViewRow In Me.dtg_itemsEntradaSimples.Rows

        '    If Not row.IsNewRow Then mVlrBaseIcmsItens += row.Cells(12).Value

        'Next

        mVlrBaseIcmsItens = 0 'Round(mVlrBaseIcmsItens, 2)
        Return mVlrBaseIcmsItens
    End Function

    Private Function somaVlrDescontoItensGrid() As Double

        Dim mVlrDescontoItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itemsEntradaSimples.Rows

            If Not row.IsNewRow Then mVlrDescontoItens += row.Cells(6).Value

        Next

        mVlrDescontoItens = Round(mVlrDescontoItens, 2)
        Return mVlrDescontoItens
    End Function

    Private Sub preecheDtgNFeBusca(ByVal tipoBusca As String)

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim cmd As NpgsqlCommand
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao abrir conexão:: " & ex.Message) : Return
        End Try

        Try

            Sqlcomm.Remove(0, Sqlcomm.ToString.Length)
            Sqlcomm.Append("SELECT n4.n4_id, n4.n4_numer, to_char(n4_dtemis, 'dd/MM/yyyy'), to_char(n4_dtentrada, 'dd/MM/yyyy'), ") '3
            Sqlcomm.Append("cad.p_cod || ' - ' || cad.p_portad, n4.n4_totgeral, cad.p_cod, n4_basecalculo, n4_vlicms, n4_totproduto ") '9
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".note4ff n4 LEFT JOIN cadp001 cad ON n4.n4_cdforn = cad.p_cod ")

            Select Case tipoBusca
                Case "nome"
                    Sqlcomm.Append("WHERE cad.p_portad LIKE @p_portad ")
                    Sqlcomm.Append("ORDER BY n4.n4_numer DESC, n4.n4_dtentrada ASC")
                Case "numero"
                    Sqlcomm.Append("WHERE n4.n4_numer = @nt_nume ")
                    Sqlcomm.Append("ORDER BY n4.n4_numer DESC, n4.n4_dtentrada ASC")
                Case "cnpjcpf"
                    Sqlcomm.Append("WHERE cad.p_cgc = @p_cnpjcpf OR cad.p_cpf = @p_cnpjcpf ")
                    Sqlcomm.Append("ORDER BY n4.n4_numer DESC, n4.n4_dtentrada ASC")
                Case "data"
                    Sqlcomm.Append("WHERE n4.n4_dtentrada BETWEEN @dtinical AND @dtfinal ")
                    Sqlcomm.Append("ORDER BY n4.n4_dtentrada ASC")
                Case Else
                    Sqlcomm.Append("ORDER BY n4.n4_dtentrada ASC LIMIT 34")
            End Select


            cmd = New NpgsqlCommand(Sqlcomm.ToString, conn)

            Select Case tipoBusca
                Case "nome"
                    cmd.Parameters.Add("@p_portad", nomeRef & "%")
                Case "numero"
                    cmd.Parameters.Add("@nt_nume", numeroNFeRef)
                Case "cnpjcpf"
                    cmd.Parameters.Add("@p_cnpjcpf", cnpjCpfRef)
                Case "data"
                    cmd.Parameters.Add("@dtinical", dataInicialRef)
                    cmd.Parameters.Add("@dtfinal", dataFinalRef)
            End Select

            dr = cmd.ExecuteReader

            Me.dtg_vizualiza.Rows.Clear() : Me.dtg_vizualiza.Refresh()
            While dr.Read


                dtg_vizualiza.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, _
                                    Format(dr(5), "###,##0.00"), dr(6).ToString, dr(7), dr(8), dr(9)) '9

            End While
            dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length) : cmd.CommandText = "" : conn.ClearAllPools()
            conn.Close() : dr = Nothing : Sqlcomm = Nothing : cmd = Nothing : conn = Nothing
            Me.dtg_vizualiza.Refresh() : txt_totRegistrosN4FF.Text = dtg_vizualiza.Rows.Count

        Catch ex As Exception
            MsgBox("ERRO na consulta:: " & ex.Message) : Return
        End Try


    End Sub

#End Region

#Region "***  Impressão de Documentos  ***"

#Region "Espelho da Nota:"

    Private Sub executaEspelhoNota(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\relatorios\TEMPconsulta.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Catch ex As Exception

            Try
                fs.Dispose() : File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex01 As Exception
                MsgBox(ex01.Message, MsgBoxStyle.Exclamation)
            End Try

        End Try

        Dim s As New StreamWriter(fs)
        _PrintFont = New Font("Lucida Console", 8)
        Dim strLinha As String = ""
        Dim dtEntrada As String = Me.dtg_vizualiza.CurrentRow.Cells(2).Value.ToString
        Dim dtEmissao As String = Me.dtg_vizualiza.CurrentRow.Cells(3).Value.ToString
        Dim mNumero As String = Me.dtg_vizualiza.CurrentRow.Cells(1).Value.ToString
        Dim mCodForn As String = Me.dtg_vizualiza.CurrentRow.Cells(6).Value.ToString

        'titulo
        Try
            s.Write(vbNewLine & vbNewLine)

            '8 caracteres
            strLinha = _clFuncoes.Exibe_Str(("NUMERO: " & mNumero), 20)

            '9 caracteres
            strLinha += _clFuncoes.Exibe_Str(("ENTRADA: " & dtEntrada), 21)

            '9 caracteres
            strLinha += _clFuncoes.Exibe_Str(("EMISSÃO: " & dtEmissao), 21)


            s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 120))
        Catch ex As Exception
        End Try


        'cabeçalho
        Dim lShouldReturn2 As Boolean
        GravCabecalhoArq(s, dtEntrada, dtEmissao, lShouldReturn2)
        If lShouldReturn2 Then Return

        'totais
        Dim lShouldReturn As Boolean
        GravTotaisArq(s, lShouldReturn)
        If lShouldReturn Then Return

        'itens
        Dim lShouldReturn1 As Boolean
        GravItensArq(mNumero, mCodForn, arqSaida, mArqTemp, fs, s, lShouldReturn1)
        If lShouldReturn1 Then Return

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo()

        _StringToPrint = ""
    End Sub

    Private Sub GravCabecalhoArq(ByVal s As StreamWriter, ByVal dtEntrada As String, ByVal dtEmissao As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim codFornecedor As String = Me.dtg_vizualiza.CurrentRow.Cells(6).Value.ToString
            codFornecedor = codFornecedor.Substring(0, 6)

            Dim codEstab As String = _loja
            gravaCabecalhoNota(s, codFornecedor, codEstab, dtEntrada, dtEmissao)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Nota", MsgBoxStyle.Exclamation)
            s.Close() : shouldReturn = True : Return

        End Try



    End Sub

    Private Sub gravaCabecalhoNota(ByVal s As StreamWriter, ByVal codFornecedor As String, _
                ByVal codEstab As String, ByVal dtEntr As String, ByVal dtEmiss As String)

        If codEstab.Length = 2 Then codEstab = "0" & codEstab
        If codEstab.Length > 3 Then codEstab = Mid(codEstab, codEstab.Length - 2, 3)

        Dim strLinha As String = ""
        s.WriteLine("")

        'Traz os dados do Fornecedor da nota...
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlForn As New StringBuilder
        Dim cmdForn As NpgsqlCommand
        Dim drForn As NpgsqlDataReader

        sqlForn.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_insc, p_cid, p_uf ")
        sqlForn.Append("FROM cadp001 WHERE p_cod = '" & codFornecedor & "'")

        cmdForn = New NpgsqlCommand(sqlForn.ToString, oConnBDGENOV)
        drForn = cmdForn.ExecuteReader

        Dim nomeForn, cnpjForn, inscForn, cidForn, ufForn As String

        nomeForn = "" : cnpjForn = "" : inscForn = "" : cidForn = "" : ufForn = ""

        While drForn.Read

            nomeForn = drForn(0) : cnpjForn = drForn(1) : inscForn = drForn(2)
            cidForn = drForn(3) : ufForn = drForn(4)

        End While
        drForn.Close() : cmdForn = Nothing : sqlForn = Nothing : drForn = Nothing
        oConnBDGENOV.ClearPool()

        '                      1        2         3         4         5         6         7         8         9         0         1         2
        '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        s.WriteLine("  FORNECEDOR -----------------------------------------------------------------------------------------------------")
        strLinha = _clFuncoes.Exibe_StrEsquerda("NOME/RAZÃO SOCIAL: " & nomeForn, 80)
        strLinha += _clFuncoes.Exibe_StrDireita("CNPJ/CPF: " & cnpjForn, 30)
        s.WriteLine(_clFuncoes.Exibe_cabecalho(strLinha, 4, 120))

        strLinha = _clFuncoes.Exibe_StrEsquerda("INSCRIÇÃO ESTADUAL: " & inscForn, 44)
        strLinha += _clFuncoes.Exibe_StrEsquerda("CIDADE: " & cidForn, 60)
        strLinha += _clFuncoes.Exibe_StrDireita("UF: " & ufForn, 6)

        s.Write(_clFuncoes.Exibe_cabecalho(strLinha, 4, 120))
        s.WriteLine(vbNewLine)
        '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxZ xxx xxxxxxxxxx 999,999.99 999,999.99   
        's.WriteLine("-------------------------------------------------------------------------------------------------------------------")


        'Traz dados do Cliente da Nota...
        Dim sqlClient As New StringBuilder
        Dim cmdClient As NpgsqlCommand
        Dim drClient As NpgsqlDataReader

        sqlClient.Append("SELECT g_geno, g_cgc, g_insc, g_uf, g_ender, g_cid ")
        sqlClient.Append("FROM geno001 WHERE SUBSTR(g_codig, 3, 3) = '" & codEstab & "'")

        cmdClient = New NpgsqlCommand(sqlClient.ToString, oConnBDGENOV)
        drClient = cmdClient.ExecuteReader

        Dim nomeClient, cnpjClient, inscClient, ufClient, enderClient, cidClient As String

        nomeClient = "" : cnpjClient = "" : inscClient = "" : ufClient = "" : enderClient = "" : cidClient = ""

        While drClient.Read

            nomeClient = drClient(0) : cnpjClient = drClient(1) : inscClient = drClient(2)
            ufClient = drClient(3) : enderClient = drClient(4) : cidClient = drClient(5)

        End While
        drClient.Close() : oConnBDGENOV.ClearPool()
        cmdClient = Nothing : sqlClient = Nothing : drClient = Nothing


        '                      1        2         3         4         5         6         7         8         9         0         1         2
        '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        s.WriteLine("  CLIENTE --------------------------------------------------------------------------------------------------------")
        strLinha = _clFuncoes.Exibe_StrEsquerda("NOME/RAZÃO SOCIAL: " & nomeClient, 80)
        strLinha += _clFuncoes.Exibe_StrDireita("CNPJ/CPF: " & cnpjClient, 30)
        s.WriteLine(_clFuncoes.Exibe_cabecalho(strLinha, 4, 120))

        strLinha = _clFuncoes.Exibe_StrEsquerda("INSCRIÇÃO ESTADUAL: " & inscClient, 44)
        strLinha += _clFuncoes.Exibe_StrEsquerda("CIDADE: " & cidClient, 60)
        strLinha += _clFuncoes.Exibe_StrDireita("UF: " & ufClient, 6)
        s.WriteLine(_clFuncoes.Exibe_cabecalho(strLinha, 4, 120))

        strLinha = _clFuncoes.Exibe_StrEsquerda("ENDEREÇO: " & enderClient, 90)
        s.Write(_clFuncoes.Exibe_cabecalho(strLinha, 4, 120))
        s.WriteLine(vbNewLine)
        '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxZ xxx xxxxxxxxxx 999,999.99 999,999.99   
        's.WriteLine("--------------------------------------------------------------------------------------------------------------------")



    End Sub

    Private Sub GravTotaisArq(ByVal s As StreamWriter, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim vlTotNota, vlBcICMS, vlICMS, vlBcSubs, vlSubs, vlTotItens As Decimal
            Dim vlFrete, vlSeguro, vlDesc, vlOutrasDesp, vlIPI As Decimal

            vlTotNota = CDec(Me.dtg_vizualiza.CurrentRow.Cells(5).Value)
            vlBcICMS = CDec(Me.dtg_vizualiza.CurrentRow.Cells(7).Value)
            vlICMS = CDec(Me.dtg_vizualiza.CurrentRow.Cells(8).Value)
            vlBcSubs = 0.0
            vlSubs = 0.0
            vlTotItens = CDec(Me.dtg_vizualiza.CurrentRow.Cells(9).Value)
            vlFrete = 0.0
            vlSeguro = 0.0
            vlDesc = 0.0
            vlOutrasDesp = 0.0
            vlIPI = 0.0

            gravaTotaisNota(s, vlBcICMS, vlICMS, vlBcSubs, vlSubs, vlTotItens, vlFrete, vlSeguro, _
                            vlDesc, vlOutrasDesp, vlIPI, vlTotNota)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar os totais da Nota", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Private Sub gravaTotaisNotaExtracted(ByVal s As StreamWriter, ByVal bcICMS As Decimal, ByVal vlICMS As Decimal, ByVal bcSubs As Decimal, ByVal vlSubs As Decimal, ByVal strLinha As String)

        '                      1        2         3         4         5         6         7         8         9         0         1         2
        '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        s.WriteLine("  TOTAIS DA NOTA -------------------------------------------------------------------------------------------------")

        '10 CARACTERES
        strLinha = _clFuncoes.Exibe_StrEsquerda("BC. ICMS: " & Format(bcICMS, "###,##0.00"), 30) '10+20=30 CARACTERES

        '10 CARACTERES
        strLinha += _clFuncoes.Exibe_StrEsquerda("VL. ICMS: " & Format(vlICMS, "###,##0.00"), 26) '10+16=26 CARACTERES

        '12 CARACTERES
        strLinha += _clFuncoes.Exibe_StrEsquerda("BC. SUBST.: " & Format(bcSubs, "###,##0.00"), 27) '12+16=27 CARACTERES

        '12 CARACTERES
        strLinha += _clFuncoes.Exibe_StrDireita("VL. SUBST.: " & Format(vlSubs, "###,##0.00"), 27) '12+16=27 CARACTERES
        s.WriteLine(_clFuncoes.Exibe_cabecalho(strLinha, 4, 120)) '104+4=108 CARACTERES, ALINHAMENTO = 103, MAX = 103



    End Sub

    Private Sub gravaTotaisNotaExtracted1(ByVal s As StreamWriter, ByVal vlTotItens As Decimal, ByVal vlFrete As Decimal, ByVal vlSeguro As Decimal, ByVal vlDesconto As Decimal, ByVal strLinha As String)

        '14 CARACTERES
        strLinha = _clFuncoes.Exibe_StrEsquerda("VL. PRODUTOS: " & Format(vlTotItens, "###,##0.00"), 31) '14+16=30 CARACTERES

        '11 CARACTERES
        strLinha += _clFuncoes.Exibe_StrEsquerda("VL. FRETE: " & Format(vlFrete, "###,##0.00"), 26) '11+15=26 CARACTERES

        '12 CARACTERES
        strLinha += _clFuncoes.Exibe_StrEsquerda("VL. SEGURO: " & Format(vlSeguro, "###,##0.00"), 27) '12+15=27 CARACTERES

        '7 CARACTERES
        strLinha += _clFuncoes.Exibe_StrDireita("DESC.: " & Format(vlDesconto, "###,##0.00"), 26) '7+12=19 CARACTERES
        'Dim MMMSTR As String = cl_funcoes.Exibe_cabecalho(strLinha, 4, 110)

        'MMMSTR = MMMSTR
        s.WriteLine(_clFuncoes.Exibe_cabecalho(strLinha, 4, 120)) '98+4=102 CARACTERES, ALINHAMENTO = 103, MAX = 103



    End Sub

    Private Function gravaTotaisNotaExtracted2(ByVal vlOutrasDesp As Decimal, ByVal vlIPI As Decimal, ByVal vlTotNota As Decimal) As String

        Dim strLinha As String
        '233d

        '16 CARACTERES
        strLinha = _clFuncoes.Exibe_StrEsquerda("OUTR. DESPESAS: " & Format(vlOutrasDesp, "###,##0.00"), 35) '16+14=30 CARACTERES

        '9 CARACTERES
        strLinha += _clFuncoes.Exibe_StrEsquerda("VL. IPI: " & Format(vlIPI, "###,##0.00"), 35) '9+17=26 CARACTERES

        '19 CARACTERES
        strLinha += _clFuncoes.Exibe_StrDireita("VL. TOTAL DA NOTA: " & Format(vlTotNota, "###,##0.00"), 40) '19+16=35 CARACTERES



        Return strLinha
    End Function

    Private Sub gravaTotaisNota(ByVal s As StreamWriter, ByVal bcICMS As Decimal, _
     ByVal vlICMS As Decimal, ByVal bcSubs As Decimal, ByVal vlSubs As Decimal, _
     ByVal vlTotItens As Decimal, ByVal vlFrete As Decimal, _
     ByVal vlSeguro As Decimal, ByVal vlDesconto As Decimal, ByVal vlOutrasDesp _
     As Decimal, ByVal vlIPI As Decimal, ByVal vlTotNota As Decimal)

        Dim strLinha As String = ""

        'Grava Totais
        gravaTotaisNotaExtracted(s, bcICMS, vlICMS, bcSubs, vlSubs, strLinha)
        gravaTotaisNotaExtracted1(s, vlTotItens, vlFrete, vlSeguro, vlDesconto, strLinha)
        strLinha = gravaTotaisNotaExtracted2(vlOutrasDesp, vlIPI, vlTotNota)
        s.Write(_clFuncoes.Exibe_cabecalho(strLinha, 4, 120)) '88+4=92 CARACTERES, ALINHAMENTO = 103, MAX = 103
        s.WriteLine(vbNewLine)
        '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxZ xxx xxxxxxxxxx 999,999.99 999,999.99   


    End Sub

    Private Sub GravItensArq(ByVal numero As String, ByVal codforn As String, ByVal arqSaida As String, _
                             ByVal mArqTemp As String, ByVal fs As FileStream, ByVal s As StreamWriter, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim idN4ff As Int32 = CInt(Me.dtg_vizualiza.CurrentRow.Cells(0).Value)
            gravaItemsNota(s, idN4ff, numero, codforn)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) da Nota:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try

        s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)

        Catch ex As Exception
        End Try
        s.Dispose() : File.Delete(mArqTemp) : mArqTemp = Nothing : fs = Nothing : s = Nothing



    End Sub

    Private Sub gravaItemsNota(ByVal s As StreamWriter, ByVal idN4ff As Int32, ByVal numero As String, ByVal codforn As String)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd As String
        Dim mQtdeProd, mVlProd, mVlBrutoProd, mVlTotProd, mvlSubs, mvlFrete, mvlIPI As Decimal
        Dim mvlOutrasDesp, mvlSeguro, mvlDesconto As Decimal
        Dim mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mVlIpiProd As Decimal
        Dim mSomaBrutoProd, mSomaTotProd, mSomaSubs, mSomaFrete, mSomaIPI As Decimal
        Dim UndIten, strLinha As String
        strLinha = ""

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlItem As New StringBuilder
        Dim cmdItem As NpgsqlCommand
        Dim drItem As NpgsqlDataReader
        Dim mContItens As Integer = 0

        sqlItem.Append("SELECT nc_idprod, nc_codpr, e_produt, 'xxxx', 'xxx', nc_qtde, nc_vlunitario, ") '6
        sqlItem.Append("0, nc_desconto, nc_total, e_und, 0, 0, 0, ") '13
        sqlItem.Append("0, 0, 0, 0, 0, 0, 0, ") '20
        sqlItem.Append("0, 0, 0, nc_total, ")
        sqlItem.Append("'" & _loja & "' FROM " & MdlEmpresaUsu._esqEstab & ".note2ff LEFT JOIN " & MdlEmpresaUsu._esqVinc)
        sqlItem.Append(".est0001 ON e_codig = nc_codpr WHERE nc_idbig4 = " & idN4ff)

        cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
        drItem = cmdItem.ExecuteReader

        If drItem.HasRows = True Then

            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine("------------------------------------------------------------------------------------------------------------------")
            s.WriteLine("CODIGO DESCRICÃO DO PRODUTO                CST CFOP UND   QUANT.    V.BRUTO      IPI       SUBS.      VL. TOTAL")
            '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx xxx xxxx xxx 99,999.99 999,999.99 99,999.99 999,999.99 9,999,999.99  
            s.WriteLine("------------------------------------------------------------------------------------------------------------------")
            s.WriteLine("")

        End If

        While drItem.Read

            mCodProd = drItem(1) : mNomeProd = drItem(2) : mNcmProd = ""
            mCfopProd = drItem(3) : mCstProd = drItem(4) : mQtdeProd = drItem(5)
            mVlProd = drItem(6) : mVlBrutoProd = drItem(9) : UndIten = drItem(10)
            mVlBcIcmsProd = drItem(12) : mVlAlqIcmsProd = drItem(13) : mVlIcmsProd = drItem(14)
            mVlIpiProd = drItem(19) : mvlSubs = drItem(17) : mvlIPI = drItem(19)
            mvlFrete = drItem(20) : mvlSeguro = drItem(21) : mvlOutrasDesp = drItem(22)
            mvlDesconto = drItem(8)

            mVlTotProd = ((mVlBrutoProd + mvlSubs + mvlIPI + mvlFrete + mvlSeguro + mvlOutrasDesp) _
                          - mvlDesconto)

            mSomaBrutoProd += mVlBrutoProd : mSomaSubs += mvlSubs : mSomaFrete += mvlFrete
            mSomaIPI += mvlIPI : mSomaTotProd += mVlTotProd

            strLinha = _clFuncoes.Exibe_Str(mCodProd, 6) & " " & _clFuncoes.Exibe_Str(mNomeProd, 35) & " " & _
            _clFuncoes.Exibe_Str(mCstProd, 3) & " " & _clFuncoes.Exibe_Str(mCfopProd, 4) & " " & _
            _clFuncoes.Exibe_Str(UndIten, 3) & " " & _clFuncoes.Exibe_StrDireita(Format(mQtdeProd, "###,##0.00"), 9) _
            & " " & _clFuncoes.Exibe_StrDireita(Format(mVlBrutoProd, "###,##0.00"), 10) & " " & _
            _clFuncoes.Exibe_StrDireita(Format(mVlIpiProd, "###,##0.00"), 9) & " " & _
            _clFuncoes.Exibe_StrDireita(Format(mvlSubs, "###,##0.00"), 10) & " " & _
            _clFuncoes.Exibe_StrDireita(Format(mVlTotProd, "###,##0.00"), 12) '106 CARACTERES

            s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 110))
            mContItens += 1

        End While


        If drItem.HasRows = True Then

            s.WriteLine("")
            strLinha = "TOTAIS --->          " & _clFuncoes.Exibe_StrDireita(mContItens, 3)
            If mContItens > 1 Then

                strLinha += " - Itens"

            Else
                strLinha += " - Iten"

            End If

            strLinha = _clFuncoes.Exibe_Str(strLinha, 65)
            strLinha += " " & _clFuncoes.Exibe_StrDireita(Format(mSomaBrutoProd, "###,##0.00"), 10) & " " & _
            _clFuncoes.Exibe_StrDireita(Format(mSomaIPI, "###,##0.00"), 9) & " " & _
            _clFuncoes.Exibe_StrDireita(Format(mSomaSubs, "###,##0.00"), 10) & " " & _
            _clFuncoes.Exibe_StrDireita(Format(mSomaTotProd, "###,##0.00"), 12) '106 CARACTERES
            s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 115))


            '                      1        2         3         4         5         6         7         8                    9         0         1         2
            '            12345678901234567890123456789012345678901234567890123456789012345678901234567890           1234567890123456789012345678901234567890
            s.WriteLine("------------------------------------------------------------------------------------------------------------------")
            s.WriteLine("")

        End If
        drItem.Close() : oConnBDGENOV.ClearPool()
        cmdItem.CommandText = "" : sqlItem.Remove(0, sqlItem.ToString.Length)
        oConnBDGENOV.Close()

        'LIMPA OBJETOS DA MEMÓRIA...
        cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
        mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing : mCstProd = Nothing
        mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing : mVlBcIcmsProd = Nothing
        mVlAlqIcmsProd = Nothing : mVlIcmsProd = Nothing : mVlIpiProd = Nothing

    End Sub

#End Region

#Region "Listagem das Notas:"

    Private Sub executaEspelhoNF_R(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\relatorios\TEMPconsulta.TMP"
        Dim fs As New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)
        Dim s As New StreamWriter(fs)

        Dim mContPaginas As Integer = 0, mContQuebrasPag As Integer = 0
        Dim strLinha As String = ""
        Dim dtAtual As String = Format(Date.Now, "dd/MM/yyyy")
        Dim codEstab As String = Mid(MdlUsuarioLogando._local, _
                                     MdlUsuarioLogando._local.Length - 1, 2)


        _PrintFont = New Font("Lucida Console", 7) '126 Quebras de Linha padrao para esta configuração

        'Titulo da NF
        gravaTituloNF_R(s, codEstab, dtAtual, mContPaginas, mContQuebrasPag)

        'Totais
        Dim lShouldReturn As Boolean
        executaEspelhoNF_RExtracted(arqSaida, mArqTemp, fs, s, mContPaginas, mContQuebrasPag, dtAtual, codEstab, lShouldReturn)
        If lShouldReturn Then Return

        'Ler o Arquivo salvo...
        executaEspelhoNF_RExtracted1(arqSaida, mArqTemp, fs, s)

        '_stringToPrintAux = "" : MostrarCaixaImpressoras = False
        'Visualiza o conteúdo do arquivo salvo em TEXTO...
        'executaEspelhoNF_RExtracted2()
        _StringToPrint = ""



    End Sub

    Private Sub gravaTituloNF_R(ByRef s As StreamWriter, ByVal codEstab As String, ByVal dtAtual As String, _
                                   ByRef mContPaginas As Integer, ByRef mContQuebrasPag As Integer)

        Dim strLinha As String = ""

        'titulo
        Try
            s.Write(vbNewLine & vbNewLine)
            mContQuebrasPag += 2

            Select Case _tipoBusca
                Case "numero"
                    s.WriteLine(_clFuncoes.Centraliza_Str("RELATORIO DE ENTRADAS POR NUMERO", 132))
                    _tituloConsulta = "RELATORIO DE ENTRADAS POR NUMERO "
                Case "cnpjcpf"
                    s.WriteLine(_clFuncoes.Centraliza_Str("RELATORIO DE ENTRADAS POR FORNECEDOR", 132))
                    _tituloConsulta = "RELATORIO DE ENTRADAS POR FORNECEDOR"
                Case "data"
                    s.WriteLine(_clFuncoes.Centraliza_Str("RELATORIO DE ENTRADAS DE: " & Format(dataInicialRef, "dd/MM/yyyy") & " A " & Format(dataFinalRef, "dd/MM/yyyy"), 133))
                    _tituloConsulta = "RELATORIO DE ENTRADAS DE: " & Format(dataInicialRef, "dd/MM/yyyy") & " A " & Format(dataFinalRef, "dd/MM/yyyy")
                Case Else
                    s.WriteLine(_clFuncoes.Centraliza_Str("RELATORIO DE ENTRADAS DAS ULTIMAS 60 NOTAS", 132))
                    _tituloConsulta = "RELATORIO DE ENTRADAS DAS ULTIMAS 60 NOTAS"
            End Select

            mContQuebrasPag += 1

            s.Write(vbNewLine)
            mContQuebrasPag += 1

            s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 133))
            mContQuebrasPag += 1

        Catch ex As Exception
        End Try


        'cabeçalho
        Try
            gravaCabecalhoNF_R(s, codEstab, dtAtual, mContPaginas, mContQuebrasPag)
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Nota", MsgBoxStyle.Exclamation)
            Return

        End Try

    End Sub

    Private Sub gravaCabecalhoNF_R(ByRef s As StreamWriter, ByVal codEstab As String, ByVal dtAtual As String, _
                                  ByRef mContPaginas As Integer, ByRef mContQuebrasPag As Integer)

        If codEstab.Length = 2 Then codEstab = "0" & codEstab
        If codEstab.Length > 3 Then codEstab = Mid(codEstab, codEstab.Length - 2, 3)

        mContPaginas += 1
        Dim strLinha As String = ""
        'Traz os dados do Fornecedor da nota...
        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBD.Open()

        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try


        'Traz dados do ESTABELECIMENTO CORRENTE...
        Dim sqlEstab As New StringBuilder
        Dim cmdEstab As NpgsqlCommand
        Dim drEstab As NpgsqlDataReader

        sqlEstab.Append("SELECT g_geno, g_cgc, g_insc, g_uf, g_ender, g_cid ")
        sqlEstab.Append("FROM geno001 WHERE SUBSTR(g_codig, 3, 3) = '" & codEstab & "'")

        cmdEstab = New NpgsqlCommand(sqlEstab.ToString, oConnBD)
        drEstab = cmdEstab.ExecuteReader

        Dim nomeEstab, cnpjEstab, inscEstab, ufEstab, enderEstab, cidEstab As String

        nomeEstab = "" : cnpjEstab = "" : inscEstab = "" : ufEstab = "" : enderEstab = "" : cidEstab = ""

        While drEstab.Read

            nomeEstab = drEstab(0) : cnpjEstab = drEstab(1) : inscEstab = drEstab(2)
            ufEstab = drEstab(3) : enderEstab = drEstab(4) : cidEstab = drEstab(5)

        End While
        drEstab.Close() : oConnBD.ClearPool()
        cmdEstab.CommandText = "" : sqlEstab.Remove(0, sqlEstab.ToString.Length)
        oConnBD.Close() : cmdEstab = Nothing : sqlEstab = Nothing : drEstab = Nothing


        '                      1        2         3         4         5         6         7         8         9         0         1         2
        '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        strLinha = _clFuncoes.Exibe_StrEsquerda("EMPRESA: " & codEstab & "  " & nomeEstab, 109)
        strLinha += " "

        strLinha += _clFuncoes.Exibe_StrDireita("DATA: " & dtAtual, 17)
        s.WriteLine(strLinha)
        mContQuebrasPag += 1

        strLinha = _clFuncoes.Exibe_StrEsquerda("ENDEREÇO: " & enderEstab, 117)
        strLinha += " "

        strLinha += _clFuncoes.Exibe_StrDireita("PAG.: " & String.Format("{0:D3}", Convert.ToInt32(mContPaginas)), 9)
        s.WriteLine(strLinha & vbNewLine)
        mContQuebrasPag += 2

    End Sub

    Private Sub executaEspelhoNF_RExtracted(ByVal arqSaida As String, ByVal mArqTemp As String, ByVal fs As FileStream, ByRef s As StreamWriter, ByVal mContPaginas As Integer, ByVal mContQuebrasPag As Integer, ByVal dtAtual As String, ByVal codEstab As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        'Totais
        Try
            Dim mConsultaAtual As String = ""
            Select Case _tipoBusca
                Case "numero"
                    mConsultaAtual = ConsulNumero()
                Case "cnpjcpf"
                    mConsultaAtual = ConsulFornec()
                Case "data"
                    mConsultaAtual = ConsulPeriodos()
                Case Else
                    mConsultaAtual = "ORDER BY n4_dtentrada DESC LIMIT 60"
            End Select

            gravaTotaisNF_R(s, mContPaginas, mConsultaAtual, mContQuebrasPag, codEstab, dtAtual)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar os totais da Nota", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Private Function ConsulNumero() As String

        Try
            If numeroNFeRef.Equals("") = False AndAlso _tipoBusca = "numero" Then

                Return "WHERE n4_numer = '" & numeroNFeRef & "' "
            End If

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
       

        Return ""
    End Function

    Private Function ConsulPeriodos() As String

        'valida as datas
        If (IsDate(dataInicialRef) AndAlso IsDate(dataFinalRef)) AndAlso _tipoBusca = "data" Then

            Return "WHERE n4_dtentrada BETWEEN '" & dataInicialRef & "' AND '" & _
                dataFinalRef & "' ORDER BY n4_dtentrada ASC"
        End If


        Return ""
    End Function

    Private Function ConsulFornec() As String

        If Not cnpjCpfRef.Equals("") AndAlso (_tipoBusca = "cnpjcpf") Then

            Return "WHERE cad.p_cgc = '" & cnpjCpfRef & "' "
        End If

        Return ""
    End Function

    Private Sub executaEspelhoNF_RExtracted1(ByVal arqSaida As String, ByVal mArqTemp As String, ByVal fs As FileStream, ByVal s As StreamWriter)

        Dim FilePath As String = arqSaida

        s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)

        Catch ex As Exception
        End Try
        s.Dispose() : File.Delete(mArqTemp) : mArqTemp = Nothing : fs = Nothing : s = Nothing

        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrint = MyfileStream.ReadToEnd : MyfileStream.Close()
            MyfileStream.Dispose() : MyfileStream = Nothing

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub gravaTotaisNF_R(ByRef s As StreamWriter, ByRef mContPaginas As Integer, _
                                ByVal ConsultaAtual As String, ByRef mContQuebrasPag As Integer, _
                                ByVal codEstab As String, ByVal dtAtual As String)

        Dim strLinha As String = ""
        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlNF As New StringBuilder
        Dim cmdNF, cmdPrint As NpgsqlCommand
        Dim drNF As NpgsqlDataReader
        Dim numero, dtEntrada, cfop, uf, fornecedor As String
        Dim bcIcms, icms, IPI, bcSubs, totNota As Decimal
        Dim somaBcIcms, somaIcms, somaIPI, somaBcSubs, somaTotNota As Decimal
        Dim mContRegistros As Integer = 0

        somaBcIcms = 0 : somaIcms = 0 : somaIPI = 0 : somaBcSubs = 0
        somaTotNota = 0 : bcIcms = 0 : icms = 0 : IPI = 0
        bcSubs = 0 : totNota = 0 : numero = "" : dtEntrada = "" : cfop = "" : uf = ""
        fornecedor = ""

        Try
            sqlNF.Append("SELECT n4_numer, to_char(n4_dtentrada, 'DD/MM'), SUBSTR(cad.p_portad, 1, 40), 'xxxx', ") '3
            sqlNF.Append("cad.p_uf, n4_basecalculo, n4_vlicms, 0, 0, n4_totgeral FROM " & MdlEmpresaUsu._esqEstab & ".note4ff ") '9
            sqlNF.Append("LEFT JOIN cadp001 cad ON cad.p_cod = n4_cdforn " & ConsultaAtual)

            cmdNF = New NpgsqlCommand(sqlNF.ToString, oConnBD)
            _dtAdaptPrint = New NpgsqlDataAdapter(sqlNF.ToString, oConnBD)
            drNF = cmdNF.ExecuteReader

            If drNF.HasRows = True Then

                s.WriteLine("-------------------------------------------------------------------------------------------------------------------------------")
                '                     1         2         3         4         5         6         7         8         9         0         1         2         3         4
                '            12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("NUMERO    ENTR. CFOP FORNECEDOR                         UF        B.CALC         ICMS          IPI       SUBST.          TOTAL ")
                '            XXXXXXXXX XXXXX XXXX XXXXXXXXXZXXXXXXXXXZXXXXXXXXXZXXXX XX XXXXXXXXXZXXXX XXXXXXXXXZXX XXXXXXXXXZXX XXXXXXXXXZXX XXXXXXXXXZXXXX 
                s.WriteLine("-------------------------------------------------------------------------------------------------------------------------------")
                mContQuebrasPag += 3

            Else
                s.WriteLine("NÃO EXISTE NOTAS PARA ESTA CONSULTA!!!")
                mContQuebrasPag += 1

            End If


            While drNF.Read

                numero = String.Format("{0:D9}", Convert.ToInt32(drNF(0).ToString))
                dtEntrada = drNF(1).ToString
                cfop = drNF(3).ToString
                fornecedor = drNF(2).ToString.ToUpper
                uf = drNF(4).ToString : bcIcms = drNF(5) : icms = drNF(6)
                IPI = drNF(7) : bcSubs = drNF(8) : totNota = drNF(9)

                strLinha = numero & " " & dtEntrada & " " & cfop & " " & _clFuncoes.Exibe_StrEsquerda(fornecedor, 34) & " " '61
                strLinha += uf & " " & _clFuncoes.Exibe_StrDireita(Format(bcIcms, "###,##0.00"), 14) & " "
                strLinha += _clFuncoes.Exibe_StrDireita(Format(icms, "###,##0.00"), 12) & " "
                strLinha += _clFuncoes.Exibe_StrDireita(Format(IPI, "###,##0.00"), 12) & " "
                strLinha += _clFuncoes.Exibe_StrDireita(Format(bcSubs, "###,##0.00"), 12) & " "
                strLinha += _clFuncoes.Exibe_StrDireita(Format(totNota, "###,##0.00"), 14)

                s.WriteLine(strLinha)
                mContQuebrasPag += 1
                somaBcIcms += bcIcms : somaIcms += icms : somaIPI += IPI : somaBcSubs += bcSubs
                somaTotNota += totNota : mContRegistros += 1

                'se chegou ao maximo de quebras de linha em na pagina, então chama o título
                If mContQuebrasPag = 117 Then

                    mContQuebrasPag = 0
                    gravaTituloNF_R(s, codEstab, dtAtual, mContPaginas, mContQuebrasPag)
                    s.WriteLine("-------------------------------------------------------------------------------------------------------------------------------")

                    '                     1         2         3         4         5         6         7         8         9         0         1         2         3         4
                    '            12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                    s.WriteLine("NUMERO    ENTR. CFOP FORNECEDOR                         UF        B.CALC         ICMS          IPI       SUBST.          TOTAL ")

                    '            XXXXXXXXX XXXXX XXXX XXXXXXXXXZXXXXXXXXXZXXXXXXXXXZXXXX XX XXXXXXXXXZXXXX XXXXXXXXXZXX XXXXXXXXXZXX XXXXXXXXXZXX XXXXXXXXXZXXXX 
                    s.WriteLine("-------------------------------------------------------------------------------------------------------------------------------")
                    mContQuebrasPag += 3
                End If


            End While


            If drNF.HasRows = True Then

                s.Write(vbNewLine)
                mContQuebrasPag += 1

                'se chegou ao maximo de quebras de linha em na pagina, então chama o título
                If mContQuebrasPag = 117 Then
                    mContQuebrasPag = 0
                    gravaTituloNF_R(s, codEstab, dtAtual, mContPaginas, mContQuebrasPag)
                    s.WriteLine("-------------------------------------------------------------------------------------------------------------------------------")
                    '                     1         2         3         4         5         6         7         8         9         0         1         2         3         4
                    '            12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                    s.WriteLine("NUMERO    ENTR. CFOP FORNECEDOR                         UF        B.CALC         ICMS          IPI       SUBST.          TOTAL ")
                    '            XXXXXXXXX XXXXX XXXX XXXXXXXXXZXXXXXXXXXZXXXXXXXXXZXXXX XX XXXXXXXXXZXXXX XXXXXXXXXZXX XXXXXXXXXZXX XXXXXXXXXZXX XXXXXXXXXZXXXX 
                    s.WriteLine("-------------------------------------------------------------------------------------------------------------------------------")
                    mContQuebrasPag += 3

                End If


                If mContRegistros > 1 Then

                    strLinha = _clFuncoes.Exibe_StrEsquerda("Totais  ->  " & mContRegistros & " Notas", 59)

                Else
                    strLinha = _clFuncoes.Exibe_StrEsquerda("Totais  ->  " & mContRegistros & " Nota", 59)

                End If

                strLinha += _clFuncoes.Exibe_StrDireita(Format(somaBcIcms, "###,##0.00"), 14) & " "
                strLinha += _clFuncoes.Exibe_StrDireita(Format(somaIcms, "###,##0.00"), 12) & " "
                strLinha += _clFuncoes.Exibe_StrDireita(Format(somaIPI, "###,##0.00"), 12) & " "
                strLinha += _clFuncoes.Exibe_StrDireita(Format(somaBcSubs, "###,##0.00"), 12) & " "
                strLinha += _clFuncoes.Exibe_StrDireita(Format(somaTotNota, "###,##0.00"), 14)
                s.WriteLine(strLinha)
                mContQuebrasPag += 1

                'se chegou ao maximo de quebras de linha em na pagina, então chama o título
                If mContQuebrasPag < 117 Then
                    s.WriteLine("-------------------------------------------------------------------------------------------------------------------------------")
                    '                     1         2         3         4         5         6         7         8         9         0         1         2         3         4
                    '            12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890

                End If

            End If
            drNF.Close()


            _dtAdaptPrint.SelectCommand = cmdNF
            _leitorTabela = cmdNF.ExecuteReader()


            'IMPRESSÃO COM GRAFICOS     ...............................

            'cria uma nova instância do objeto PrintPreviewDialog
            Dim objPrintPreview As New PrintPreviewDialog
            objPrintPreview = PrintPreviewDialog1

            'define algumas propriedades do obejto
            With objPrintPreview

                'indica qual o documento vai ser visualizado
                .Document = pdGrafico
                .WindowState = FormWindowState.Maximized
                .PrintPreviewControl.Zoom = 1   'maxima a visualização
                .Text = "Relatório de Notas"

                'exibe a janela de visualização para o usuário
                .ShowDialog()


            End With

            objPrintPreview = Nothing : _leitorTabela.Close()
            mContQuebrasPag = 0 : cmdNF.CommandText = ""

        Catch ex As Exception
        End Try

        sqlNF.Remove(0, sqlNF.ToString.Length)
        oConnBD.ClearPool()

        'LIMPA OBJETOS DA MEMÓRIA...
        cmdNF = Nothing : sqlNF = Nothing : numero = Nothing : dtEntrada = Nothing : cfop = Nothing
        fornecedor = Nothing : uf = Nothing : bcIcms = Nothing : icms = Nothing : IPI = Nothing
        bcSubs = Nothing : totNota = Nothing : somaBcIcms = Nothing : somaIcms = Nothing
        somaIPI = Nothing : somaBcSubs = Nothing : cmdPrint = Nothing : somaTotNota = Nothing
        oConnBD.Close() : oConnBD = Nothing



    End Sub

    Private Sub rptGravaTotaisNF(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintPageEventArgs)

        'Asssumindo as Margens definidas pela impressora padrão
        Dim margemEsq As Single = Relatorio.MarginBounds.Left
        Dim margemSup As Single = Relatorio.MarginBounds.Top
        Dim margemDir As Single = Relatorio.MarginBounds.Right
        Dim margemInf As Single = Relatorio.MarginBounds.Bottom

        margemDir -= 700 : margemEsq += 700 : margemInf += 40

        'Trabalhando com Fontes
        Dim fonteTitulo, fonteColuna, fonteRodape, fonteNormal As Font

        fonteTitulo = New Font("Times New Roman", 13, FontStyle.Bold)
        fonteColuna = New Font("Times New Roman", 10, FontStyle.Bold)
        fonteRodape = New Font("Times New Roman", 8)
        fonteNormal = New Font("Times New Roman", 8)

        'Criando variável para alinhar os numeros
        Dim strFormatNumeros = New StringFormat()
        strFormatNumeros.Alignment = StringAlignment.Far
        strFormatNumeros.LineAlignment = StringAlignment.Far

        'Titulo do relatorio
        Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, 60, margemDir, 60)
        Try
            Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "empresaR.jpg"), 40, 68)

        Catch ex As Exception
        End Try
        Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, 125, margemDir, 125)
        Relatorio.Graphics.DrawString(_tituloConsulta, fonteTitulo, Brushes.Black, margemEsq - 600, 80, New StringFormat())

        'impressão do titulo das colunas
        Relatorio.Graphics.DrawString("Numero", fonteColuna, Brushes.Red, margemDir, 128, New StringFormat())
        Relatorio.Graphics.DrawString("DtEntr", fonteColuna, Brushes.Red, margemDir + 63, 128, New StringFormat())
        Relatorio.Graphics.DrawString("Cfop", fonteColuna, Brushes.Red, margemDir + 110, 128, New StringFormat())
        Relatorio.Graphics.DrawString("Fornecedor", fonteColuna, Brushes.Red, margemDir + 147, 128, New StringFormat())
        Relatorio.Graphics.DrawString("UF", fonteColuna, Brushes.Red, margemDir + 420, 128, New StringFormat())
        Relatorio.Graphics.DrawString("B.Calc", fonteColuna, Brushes.Red, margemDir + 500, 128, New StringFormat())
        Relatorio.Graphics.DrawString("Icms", fonteColuna, Brushes.Red, margemDir + 600, 128, New StringFormat())
        'Relatorio.Graphics.DrawString("Ipi", fonteColuna, Brushes.Red, margemDir + 550, 128, New StringFormat())
        'Relatorio.Graphics.DrawString("B.Subs", fonteColuna, Brushes.Red, margemDir + 620, 128, New StringFormat())
        Relatorio.Graphics.DrawString("Total", fonteColuna, Brushes.Red, margemDir + 690, 128, New StringFormat())

        Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, 147, margemDir, 147)

        'define o número de linhas por página
        'para isto faço a divisão da área de impressão pelo tamanho da fonte subtraido do valor 10
        Dim linhasPorPagina As Integer = Relatorio.MarginBounds.Height / fonteNormal.GetHeight(Relatorio.Graphics) - 10
        Dim linhaAtual As Integer = 1
        Dim posicaoDaLinha As Double

        Dim strLinha As String = ""
        Dim numero, dtEntrada, cfop, uf, fornecedor As String
        Dim bcIcms, icms, IPI, bcSubs, totNota As Decimal
        Dim somaBcIcms, somaIcms, somaIPI, somaBcSubs, somaTotNota As Decimal
        Dim mContRegistros As Integer = 0

        somaBcIcms = 0 : somaIcms = 0 : somaIPI = 0 : somaBcSubs = 0
        somaTotNota = 0 : bcIcms = 0 : icms = 0 : IPI = 0
        bcSubs = 0 : totNota = 0 : numero = "" : dtEntrada = "" : cfop = "" : uf = ""
        fornecedor = ""

        Try
            If Not _leitorTabela.HasRows Then _leitorTabela = _dtAdaptPrint.SelectCommand.ExecuteReader
        Catch ex As Exception
            _leitorTabela = _dtAdaptPrint.SelectCommand.ExecuteReader

        End Try


        While (linhaAtual < linhasPorPagina And _leitorTabela.Read())

            'acompanha a posição da linha atual
            posicaoDaLinha = (margemSup + 37) + (linhaAtual * fonteNormal.GetHeight(Relatorio.Graphics)) \ 1

            numero = _leitorTabela(0).ToString
            fornecedor = _clFuncoes.Exibe_StrEsquerda(_leitorTabela(2).ToString, 32)
            dtEntrada = _leitorTabela(1)
            cfop = _leitorTabela(3).ToString
            uf = _leitorTabela(4).ToString

            'imprime os dados relativo ao codigo , nome do produto e preço do produto
            Relatorio.Graphics.DrawString(numero, fonteNormal, Brushes.Black, margemDir, posicaoDaLinha, New StringFormat())
            Relatorio.Graphics.DrawString(dtEntrada, fonteNormal, Brushes.Black, margemDir + 68, posicaoDaLinha, New StringFormat())
            Relatorio.Graphics.DrawString(cfop, fonteNormal, Brushes.Black, margemDir + 113, posicaoDaLinha, New StringFormat())
            Relatorio.Graphics.DrawString(fornecedor, fonteNormal, Brushes.Black, margemDir + 147, posicaoDaLinha, New StringFormat())
            Relatorio.Graphics.DrawString(uf, fonteNormal, Brushes.Black, margemDir + 422, posicaoDaLinha, New StringFormat())

            bcIcms = _leitorTabela(5)
            strLinha = _clFuncoes.Exibe_StrEsquerda(Format(bcIcms, "###,##0.00"), 14)
            Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 543, posicaoDaLinha, New StringFormat(StringFormatFlags.DirectionRightToLeft))

            icms = _leitorTabela(6)
            strLinha = _clFuncoes.Exibe_StrEsquerda(Format(icms, "###,##0.00"), 12)
            Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 633, posicaoDaLinha, New StringFormat(StringFormatFlags.DirectionRightToLeft))

            'IPI = _leitorTabela(7)
            'strLinha = _clFuncoes.Exibe_StrEsquerda(Format(IPI, "###,##0.00"), 12)
            'Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 650, posicaoDaLinha, New StringFormat(StringFormatFlags.DirectionRightToLeft))

            'bcSubs = _leitorTabela(8)
            'strLinha = _clFuncoes.Exibe_StrEsquerda(Format(bcSubs, "###,##0.00"), 12)
            'Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 620, posicaoDaLinha, New StringFormat(StringFormatFlags.DirectionRightToLeft))

            totNota = _leitorTabela(9)
            strLinha = _clFuncoes.Exibe_StrEsquerda(Format(totNota, "###,##0.00"), 14)
            Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 729, posicaoDaLinha, New StringFormat(StringFormatFlags.DirectionRightToLeft))

            somaBcIcms += bcIcms : somaIcms += icms : somaIPI += IPI : somaBcSubs += bcSubs
            somaTotNota += totNota : mContRegistros += 1

            'faz o incremento no número de linha
            linhaAtual += 1

        End While

        'Imprime totais
        posicaoDaLinha = (margemSup + 40) + ((linhaAtual + 1) * fonteNormal.GetHeight(Relatorio.Graphics)) \ 1


        If mContRegistros > 1 Then

            strLinha = "Totais ->  " & mContRegistros & " Notas"

        Else

            strLinha = "Totais ->  " & mContRegistros & " Nota"

        End If

        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir, posicaoDaLinha, New StringFormat())
        strLinha = _clFuncoes.Exibe_StrEsquerda(Format(somaBcIcms, "###,##0.00"), 14)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 543, posicaoDaLinha, New StringFormat(StringFormatFlags.DirectionRightToLeft))
        strLinha = _clFuncoes.Exibe_StrEsquerda(Format(somaIcms, "###,##0.00"), 12)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 633, posicaoDaLinha, New StringFormat(StringFormatFlags.DirectionRightToLeft))
        'strLinha = _clFuncoes.Exibe_StrEsquerda(Format(somaIPI, "###,##0.00"), 12)
        'Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 550, posicaoDaLinha, New StringFormat(StringFormatFlags.DirectionRightToLeft))
        'strLinha = _clFuncoes.Exibe_StrEsquerda(Format(somaBcSubs, "###,##0.00"), 12)
        'Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 620, posicaoDaLinha, New StringFormat(StringFormatFlags.DirectionRightToLeft))
        strLinha = _clFuncoes.Exibe_StrEsquerda(Format(somaTotNota, "###,##0.00"), 14)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 729, posicaoDaLinha, New StringFormat(StringFormatFlags.DirectionRightToLeft))

        'imprime o rodape no relatorio
        Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, margemInf, margemDir, margemInf)
        Relatorio.Graphics.DrawString(System.DateTime.Now, fonteRodape, Brushes.Black, margemEsq - 110, margemInf, New StringFormat())
        Relatorio.Graphics.DrawString("Pag. " & _pgAtualImpressao.ToString, fonteRodape, Brushes.Black, margemDir, margemInf, New StringFormat())

        'incrementa a página atual
        _pgAtualImpressao += 1

        'verifica se ainda existem registros para serem impressos
        If (_leitorTabela.NextResult) Then

            Relatorio.HasMorePages = True

        Else
            Relatorio.PageSettings.PrinterSettings.PrintToFile = True
            Relatorio.HasMorePages = False : _pgAtualImpressao = 1 : _leitorTabela.Close()

        End If


        'LIMPA OBJETOS DA MEMÓRIA...
        numero = Nothing : dtEntrada = Nothing : cfop = Nothing : fornecedor = Nothing
        uf = Nothing : bcIcms = Nothing : icms = Nothing : IPI = Nothing
        bcSubs = Nothing : totNota = Nothing : somaBcIcms = Nothing
        somaIcms = Nothing : somaIPI = Nothing : somaBcSubs = Nothing
        margemDir = Nothing : margemEsq = Nothing : margemInf = Nothing : strLinha = Nothing



    End Sub

#End Region

    Private Sub LerOArquivoSalvo(ByVal arqSaida As String)

        'Ler o Arquivo salvo...
        Dim FilePath As String = arqSaida
        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrint = MyfileStream.ReadToEnd : MyfileStream.Close()
            MyfileStream.Dispose() : MyfileStream = Nothing : File.Delete(arqSaida)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub VisuConteArqSalvo()

        Try
            ' Especifica as configurações da pagina atual
            pdRelatorio.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatorio.DefaultPageSettings.Margins.Top = 12
            pdRelatorio.DefaultPageSettings.Margins.Right = 12
            pdRelatorio.DefaultPageSettings.Margins.Left = 10
            pdRelatorio.DefaultPageSettings.Margins.Bottom = 8

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando Notas Fiscais"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatorio
            PrintPreviewDialog1.ShowDialog()

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdRelatorio.PrintPage
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
        StringforPage = _StringToPrint.Substring(0, NumChars)

        ' Imprime a string na pagina atual
        e.Graphics.DrawString(StringforPage, _PrintFont, Brushes.Black, recdraw, Strformat)

        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then

            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else

            e.HasMorePages = False

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

                    pdRelatorio.PrinterSettings = Impressora.PrinterSettings
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
        End If
        MostrarCaixaImpressoras = True



    End Sub

    Private Sub fechaCaixaImpressao()
        MostrarCaixaImpressoras = False
    End Sub

#End Region

    Private Sub dtg_itemsEntradaSimples_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dtg_itemsEntradaSimples.RowsAdded

        txt_totprodutos.Text = Format(somaVlrTotalItensGrid(), "###,##0.00")
        txt_totBCalc.Text = Format(somaVlrBaseIcmsItensGrid, "###,##0.00")
        txt_totIcms.Text = Format(somaVlrIcmsItensGrid, "###,##0.00")
        txt_totDesconto.Text = Format(somaVlrDescontoItensGrid, "###,##0.00")
        txt_totGeralITems.Text = Format(somaVlrTotalGeralItensGrid, "###,##0.00")
        txt_qtdRegItems.Text = Me.dtg_itemsEntradaSimples.Rows.Count

    End Sub

    Private Sub dtg_itemsEntradaSimples_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dtg_itemsEntradaSimples.RowsRemoved

        txt_totprodutos.Text = Format(somaVlrTotalItensGrid(), "###,##0.00")
        txt_totBCalc.Text = Format(somaVlrBaseIcmsItensGrid, "###,##0.00")
        txt_totIcms.Text = Format(somaVlrIcmsItensGrid, "###,##0.00")
        txt_totDesconto.Text = Format(somaVlrDescontoItensGrid, "###,##0.00")
        txt_totGeralITems.Text = Format(somaVlrTotalGeralItensGrid, "###,##0.00")
        txt_qtdRegItems.Text = Me.dtg_itemsEntradaSimples.Rows.Count

    End Sub

    Private Sub btn_proximaAba01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proximaAba01.Click
        tbc_entradaSimples.SelectTab(1)
    End Sub

    Private Sub opt_nome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_nome.Click

        _frmREf = Me
        frmBuscaNome.set_frmRef(Me)
        frmBuscaNome.ShowDialog()
        _tipoBusca = "nome"
        preecheDtgNFeBusca("nome")

    End Sub

    Private Sub opt_CnpjCpf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_CnpjCpf.Click

        _frmREf = Me
        frmBuscaCnpjCpf.set_frmRef(Me)
        frmBuscaCnpjCpf.ShowDialog()
        _tipoBusca = "cnpjcpf"
        preecheDtgNFeBusca("cnpjcpf")

    End Sub

    Private Sub opt_data_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_data.Click

        _frmREf = Me
        frmBuscaDataPeriodo.set_frmRef(Me)
        frmBuscaDataPeriodo.ShowDialog()
        _tipoBusca = "data"
        preecheDtgNFeBusca("data")

    End Sub

    Private Sub opt_numero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_numero.Click

        _frmREf = Me
        frmBuscaNumeroNFe.set_frmRef(Me)
        frmBuscaNumeroNFe.ShowDialog()
        _tipoBusca = "numero"
        preecheDtgNFeBusca("numero")

    End Sub

    Private Sub opt_EspelhoNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_EspelhoNota.Click

        If Me.dtg_vizualiza.CurrentRow.IsNewRow = False Then

            executaEspelhoNota("", "\wged\TEMPconsulta.txt")

        End If

    End Sub

    Private Sub opt_ListagemNotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_ListagemNotas.Click

        'Aqui o relatorio...
        executaEspelhoNF_R("", "\wged\relatorios\TEMPconsultaR.txt")

    End Sub
End Class