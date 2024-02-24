Imports Npgsql
Imports System.IO
Imports GenoNFeXml
Imports System.Math
Imports System.Text
Imports System.Data
Imports System.DateTime
Imports System.Threading

Public Class Frm_NFEOutras

    'Inicio da Criação dos Objetos...
    Private nota1pp As New Cl_Nota1pp
    Private nota2cc As New Cl_Nota2cc
    Private nota4dd As New Cl_Nota4dd
    Private nota6hh As New Cl_Nota6hh
    Private nota5tt As New Cl_Nota5tt
    Dim cliTranportador As New Cl_Cadp001

    'Resumo da Saida:
    Dim resn4dd01 As New Cl_ResN4dd01
    Dim resn4dd02 As New Cl_ResN4dd02
    Dim resn4dd03 As New Cl_ResN4dd03
    Dim dtgItensResumo As New DataGridView
    'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
    'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14


    Private geno001 As New Cl_Geno
    Private genp001 As New Cl_Genp001
    Private cadp001 As New Cl_Cadp001
    Private produto As New Cl_Est0001

    Private cl_NFe As New GeraXml
    Private _clFuncoes As New ClFuncoes
    Private cl_BD As New Cl_bdMetrosys

    Dim frmMsgRtbox As New Frm_MsgRTBox
    Public Shared _frmREf As New Frm_NFEOutras
    Private buscaCliente As New Frm_BuscaCli
    Private buscaProduto As New Frm_buscaProdNFe
    Private _frmGeraNFe As New Frm_GeraNotasFiscais
    'Fim da Criação dos Objetos


    'INICIO da Criação de Variáveis...
    'Gerais:
    Dim formBusca As Boolean = False
    Dim codLoja As String = "" '2 Digitos
    Dim tipoNFe As String = "" 'Armazenará o primeiro Dígito do Valor Cbo_TipoNFe S ou E
    Dim digCFOP As String = "" 'Armazenará o primeiro Dígito do CFOP
    Dim _cfop As String = "", _cst As String = ""
    Public cfopRef As String = ""
    Dim alqInterna, alqExterna As Double
    Protected conexao As String = MdlConexaoBD.conectionPadrao

    'NF-e:
    Dim vnt_pag As String
    Dim codUf As String, AnoMes As String, cgc As String, modelo As String
    Dim serie As String, numeroNfe As String, cont As String, seqNfe As String, seqNFeInt As Int64, digito As Int16
    Dim chaveSemDigitoFinal As String, chaveNFe, anoMesPath As String

    'XML:
    Dim fsxml As FileStream
    Dim s As StreamWriter
    Private Arqxml As String = "\wged\NFE001.txt"
    Private ArqTemp As String = "\wged\NFE002.txt"
    Private xmlPath As String = "\wged\MyData.xml"

    Dim mcfop As String = "", mtipoPag As String = ""
    Dim mAmb, mcontf, mSeqNFe As String
    Dim mExisteNota1pp As Boolean = False
    Dim mNumNota1ppExist As String = "", mCodPartNota1ppExist As String = ""
    Dim xmlArquivo As New StringBuilder

    Dim strXmlRetorno As String = "", strArqErroRetorno As String = "", strXmlLoteRecebido As String = "", strXmlProcRec As String = ""
    Dim numLotRetorno As String = "", strXmlStatus As String = "", strXmlMotivo As String = "", strXmlProcRecAux As String = ""
    Dim strXmlProtocolo As String = ""
    Dim strXmlRec As String = "", strXmlHora As String = ""
    Dim strAux1 As String = "", strAux2 As String = ""
    Dim xposinicio, xposfim, xposdif, xposAux As Integer

    'FIM da Criação de Variáveis

    Private Sub Frm_NFEOutras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        zeraValoresGeral()


        Me.cbo_placa = _clFuncoes.PreenchComboPlacaVeicNFe(Me.cbo_placa, MdlConexaoBD.conectionPadrao)

        'INICIO do Tratamento do DataGridView Resumo

        'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
        'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
        dtgItensResumo.Columns.Add("r4_numero", "r4_numero") : dtgItensResumo.Columns.Add("r4_cfop", "r4_cfop")
        dtgItensResumo.Columns.Add("r4_cst", "r4_cst") : dtgItensResumo.Columns.Add("r4_aliq", "r4_aliq")
        dtgItensResumo.Columns.Add("r4_tprod", "r4_tprod") : dtgItensResumo.Columns.Add("r4_tdesc", "r4_tdesc")
        dtgItensResumo.Columns.Add("r4_tfrete", "r4_tfrete") : dtgItensResumo.Columns.Add("r4_tseguro", "r4_tseguro")
        dtgItensResumo.Columns.Add("r4_toutrasdesp", "r4_toutrasdesp") : dtgItensResumo.Columns.Add("r4_bcalc", "r4_bcalc")
        dtgItensResumo.Columns.Add("r4_icms", "r4_icms") : dtgItensResumo.Columns.Add("r4_isento", "r4_isento")
        dtgItensResumo.Columns.Add("r4_outras", "r4_outras") : dtgItensResumo.Columns.Add("r4_ipi", "r4_ipi")
        dtgItensResumo.Columns.Add("r4_tgeral", "r4_tgeral")

        'FIM do Tratamento do DataGridView Resumo


        Try
            fsxml = New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
            s = New StreamWriter(fsxml)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Frm_NFEOutras_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If formBusca = False Then

            If e.KeyChar = Convert.ToChar(13) Then
                e.Handled = True
                SendKeys.Send("{TAB}")

            End If
        End If


    End Sub

    Private Sub Frm_NFEOutras_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

    Private Sub cbo_estabelecimento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.GotFocus
        If cbo_estabelecimento.DroppedDown = False Then cbo_estabelecimento.DroppedDown = True
    End Sub

    Private Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged

        Try
            codLoja = ""
            codLoja = cbo_estabelecimento.SelectedItem.ToString.Substring(0, 2)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbo_estabelecimento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.Leave

        cboEstabLeave()
    End Sub

    Private Sub cboEstabLeave()

        lbl_mensagem.Text = ""
        If codLoja.Equals("") Then

            lbl_mensagem.Text = "Selecione uma Loja Por Favor !"
            cbo_estabelecimento.Focus()
            codLoja = MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2)
            cbo_estabelecimento.SelectedIndex = _clFuncoes.trazIndexCboLoja(codLoja, cbo_estabelecimento)
            Return

        Else
            _clFuncoes.trazGenoSelecionado("G00" & codLoja, geno001)
            _clFuncoes.trazGenpSelecionado("G00" & codLoja, genp001)
        End If


        Select Case genp001.pAmb
            Case "1"
                Me.lbl_ambiente.Text = "Produção"
            Case "2"
                Me.lbl_ambiente.Text = "Homologação"
        End Select

        Select Case genp001.pContf
            Case "1"
                Me.lbl_tipoemissao.Text = "Normal"
            Case "3"
                Me.lbl_tipoemissao.Text = "Contingência(SCAN)"
            Case "4"
                Me.lbl_tipoemissao.Text = "Contigência DPEC"
        End Select

    End Sub

    Private Sub cbo_tiponfe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tiponfe.GotFocus
        If cbo_tiponfe.DroppedDown = False Then cbo_tiponfe.DroppedDown = True
    End Sub

    Private Sub cbo_tiponfe_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tiponfe.Leave

        lbl_mensagem.Text = ""
        If cbo_tiponfe.SelectedIndex < 0 Then

            lbl_mensagem.Text = "Selecione o Tipo da NFe Por Favor !"
            cbo_tiponfe.Focus() : cbo_tiponfe.SelectedIndex = 0

        Else
            tipoNFe = Mid(cbo_tiponfe.SelectedItem.ToString, 1, 1)
        End If

    End Sub

#Region "   *** Funções e Procedimentos Auxiliares ***   "

    Private Sub enviaTecla(ByVal tecla As String)
        SendKeys.Send("{" & tecla & "}")
    End Sub

    Sub zeraValoresGeral()

        txt_alqicms.Text = "0,00"
        txt_alqipi.Text = "0,00"
        txt_alqsubs.Text = "0,00"
        txt_basecalc.Text = "0,00"
        txt_basesubs.Text = "0,00"
        txt_cfop.Text = ""
        txt_codProd.Text = ""
        txt_codPart.Text = ""
        txt_desconto.Text = "0,00"
        txt_despacessoria.Text = "0,00"
        txt_frete.Text = "0,00"
        txt_nomePart.Text = ""
        txt_nomeProd.Text = ""
        txt_qtde.Text = "0,000"
        txt_total.Text = "0,00"
        txt_vlicms.Text = "0,00"
        txt_vlipi.Text = "0,00"
        txt_vlsubs.Text = "0,00"
        txt_seguro.Text = "0,00"
        txt_vlunitario.Text = "0,0000"
        txt_pruvenda.Text = "0,0000"

        cbo_estabelecimento = _clFuncoes.PreenchComboLoja(cbo_estabelecimento, MdlConexaoBD.conectionPadrao)
        codLoja = MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2)
        cbo_estabelecimento.SelectedIndex = _clFuncoes.trazIndexCboLoja(codLoja, cbo_estabelecimento)

    End Sub

    Sub zeraValoresItems()

        txt_alqicms.Text = "0,00"
        txt_alqipi.Text = "0,00"
        txt_alqsubs.Text = "0,00"
        txt_basecalc.Text = "0,00"
        txt_basesubs.Text = "0,00"
        txt_cfop.Text = ""
        txt_codProd.Text = ""
        txt_desconto.Text = "0,00"
        txt_despacessoria.Text = "0,00"
        txt_frete.Text = "0,00"
        txt_seguro.Text = "0,00"
        txt_nomeProd.Text = ""
        txt_qtde.Text = "0,000"
        txt_total.Text = "0,00"
        txt_vlicms.Text = "0,00"
        txt_vlipi.Text = "0,00"
        txt_vlsubs.Text = "0,00"
        txt_seguro.Text = "0,00"
        txt_vlunitario.Text = "0,0000"
        txt_pruvenda.Text = "0,0000"
        lbl_qtdFiscal.Text = "0"

    End Sub

    Private Sub buscaCFOP()

        cfopRef = Me.txt_cfop.Text
        Dim buscaCfop As New Frm_CfopResp
        buscaCfop.set_frmRef(Me)
        buscaCfop.ShowDialog()
        Me.txt_cfop.Text = cfopRef.Replace(".", "")

    End Sub

    Private Sub alteraVlUnit_PcoTotal()

        Dim valorTotal As Double = 0.0
        Dim valorUnit As Double = 0.0
        valorTotal = Round(((CDec(Me.txt_pruvenda.Text) * CDec(Me.txt_qtde.Text)) - CDec(txt_desconto.Text)), 2)
        valorUnit = Round(valorTotal / CDec(txt_qtde.Text), 4)

        Try
            Me.txt_vlunitario.Text = Format(valorUnit, "###,##0.0000")
        Catch ex As Exception
            Me.txt_vlunitario.Text = Format(0.0, "###,##0.0000")
        End Try

        Try
            Me.txt_total.Text = Format(Round(CDec(Me.txt_vlunitario.Text) * CDec(Me.txt_qtde.Text), 4), "###,##0.00")
        Catch ex As Exception
            Me.txt_total.Text = Format(0.0, "###,##0.00")
        End Try

    End Sub

    Private Function validaIcmsNormal() As Boolean


        'INICIO da validação do ICMS NORMAL
        If (CDec(txt_basecalc.Text) > 0) Then

            If (CDec(txt_alqicms.Text) <= 0) Then
                lbl_mensagem.Text = "A Aliquota do ICMS NORMAL devem ser maior que ZERO para Base de Calculo com Valor !"
                txt_alqicms.Focus() : txt_alqicms.SelectAll() : Return False
            End If

            If (CDec(txt_vlicms.Text) <= 0) Then
                lbl_mensagem.Text = "O Valor do ICMS NORMAL devem ser maior que ZERO para Base de Calculo com Valor !"
                txt_vlicms.Focus() : txt_vlicms.SelectAll() : Return False
            End If
        End If


        If (CDec(txt_alqicms.Text) > 0) Then

            If (CDec(txt_basecalc.Text) <= 0) Then
                lbl_mensagem.Text = "A Base de Calculo do ICMS NORMAL devem ser maior que ZERO para Aliquota com Valor !"
                txt_basecalc.Focus() : txt_basecalc.SelectAll() : Return False
            End If

            If (CDec(txt_vlicms.Text) <= 0) Then
                lbl_mensagem.Text = "O Valor do ICMS NORMAL devem ser maior que ZERO para Aliquota com Valor !"
                txt_vlicms.Focus() : txt_vlicms.SelectAll() : Return False
            End If
        End If


        If (CDec(txt_vlicms.Text) > 0) Then

            If (CDec(txt_alqicms.Text) <= 0) Then
                lbl_mensagem.Text = "A Aliquota do ICMS NORMAL devem ser maior que ZERO para Valor ICMS com Valor !"
                txt_alqicms.Focus() : txt_alqicms.SelectAll() : Return False
            End If

            If (CDec(txt_basecalc.Text) <= 0) Then
                lbl_mensagem.Text = "A Base de Calculo do ICMS NORMAL devem ser maior que ZERO para Valor ICMS com Valor !"
                txt_basecalc.Focus() : txt_basecalc.SelectAll() : Return False
            End If
        End If
        'FIM da Validação do ICMS NORMAL


        Return True
    End Function

    Private Function validaIcmsNormalZERADOS_CST(ByVal cst As String) As Boolean

        'INICIO da validação do ICMS NORMAL
        If (CDec(txt_basecalc.Text) <= 0) Then
            lbl_mensagem.Text = "A Base de Calculo do ICMS NORMAL devem ser maior que ZERO para produto com CST " & cst & " !"
            txt_basecalc.Focus() : txt_basecalc.SelectAll() : Return False
        End If

        If (CDec(txt_alqicms.Text) <= 0) Then
            lbl_mensagem.Text = "A Aliquota do ICMS NORMAL devem ser maior que ZERO para produto com CST " & cst & " !"
            txt_alqicms.Focus() : txt_alqicms.SelectAll() : Return False
        End If

        If (CDec(txt_vlicms.Text) <= 0) Then
            lbl_mensagem.Text = "O Valor do ICMS NORMAL devem ser maior que ZERO para produto com CST " & cst & " !"
            txt_vlicms.Focus() : txt_vlicms.SelectAll() : Return False
        End If
        'FIM da Validação do ICMS NORMAL

        Return True
    End Function

    Private Function validaIcmsNormalVALORES_CST(ByVal cst As String) As Boolean

        'INICIO da Validação do ICMS NORMAL
        If (CDec(txt_basecalc.Text) > 0) Then
            lbl_mensagem.Text = "Os valores de ICMS NORMAL devem ser ZERADOS para produto com CST " & cst & " !"
            txt_basecalc.Focus() : txt_basecalc.SelectAll() : Return False
        End If

        If (CDec(txt_alqicms.Text) > 0) Then
            lbl_mensagem.Text = "Os valores de ICMS NORMAL devem ser ZERADOS para produto com CST " & cst & " !"
            txt_alqicms.Focus() : txt_alqicms.SelectAll() : Return False
        End If

        If (CDec(txt_vlicms.Text) > 0) Then
            lbl_mensagem.Text = "Os valores de ICMS NORMAL devem ser ZERADOS para produto com CST " & cst & " !"
            txt_vlicms.Focus() : txt_vlicms.SelectAll() : Return False
        End If
        'FIM da Validação do ICMS NORMAL

        Return True
    End Function

    Private Function validaIcmsSubstitutoZERADOS_CST(ByVal cst As String) As Boolean

        'INICIO da validação do ICMS SUBSTITUTO
        If (CDec(txt_basesubs.Text) <= 0) Then
            lbl_mensagem.Text = "Os valores de ICMS SUBSTITUTO devem ser Maior que ZERO para produto com CST " & cst & " !"
            txt_basesubs.Focus() : txt_basesubs.SelectAll() : Return False
        End If

        If (CDec(txt_alqsubs.Text) <= 0) Then
            lbl_mensagem.Text = "Os valores de ICMS SUBSTITUTO devem ser Maior que ZERO para produto com CST " & cst & " !"
            txt_alqsubs.Focus() : txt_alqsubs.SelectAll() : Return False
        End If

        If (CDec(txt_vlsubs.Text) <= 0) Then
            lbl_mensagem.Text = "Os valores de ICMS SUBSTITUTO devem ser Maior que ZERO para produto com CST " & cst & " !"
            txt_vlsubs.Focus() : txt_vlsubs.SelectAll() : Return False
        End If
        'FIM da Validação do ICMS SUBSTITUTO


        Return True
    End Function

    Private Function validaIcmsSubstitutoVALORES_CST(ByVal cst As String) As Boolean

        'INICIO da validação do ICMS SUBSTITUTO
        If (CDec(txt_basesubs.Text) > 0) Then
            lbl_mensagem.Text = "Os valores de ICMS SUBSTITUTO devem ser ZERADOS para produto com CST """ & cst & """ !"
            txt_basesubs.Focus() : txt_basesubs.SelectAll() : Return False
        End If

        If (CDec(txt_alqsubs.Text) > 0) Then
            lbl_mensagem.Text = "Os valores de ICMS SUBSTITUTO devem ser ZERADOS para produto com CST """ & cst & """ !"
            txt_alqsubs.Focus() : txt_alqsubs.SelectAll() : Return False
        End If

        If (CDec(txt_vlsubs.Text) > 0) Then
            lbl_mensagem.Text = "Os valores de ICMS SUBSTITUTO devem ser ZERADOS para produto com CST """ & cst & """ !"
            txt_vlsubs.Focus() : txt_vlsubs.SelectAll() : Return False
        End If
        'FIM da validação do ICMS SUBSTITUTO

        Return True
    End Function

    Private Function validaCamposItem() As Boolean

        lbl_mensagem.Text = ""

        If existeItemGrid(txt_codProd.Text) Then
            lbl_mensagem.Text = "Esse Produto Já foi Adicionado !" : Return False
        End If


        'SITUAÇÃO CST:
        '00 - Trib. Integral
        '10 - Trib. Icms/Subst.
        '20 - Com Redução
        '30 - Isenta /Não Trib.
        '40 - Isenta
        '41 - Não Tributada
        '51 - Diferimento
        '60 - ICMS Substituto
        '70 - Redução e Icms p/ Subst.
        '90 - Outros

        Select Case _cst
            Case "30", "40", "41", "60" '          ! Não informar os ICMS(Normal e Substituto) !

                If validaIcmsNormalVALORES_CST("30, 40, 41 ou 60") = False Then Return False

                If validaIcmsSubstitutoVALORES_CST("30, 40, 41 ou 60") = False Then Return False


                Select Case Mid(_cfop, 2, 3) 'CFOP da NOta
                    Case "152" 'Transferencia pra deposito fechado

                        If (Mid(txt_cfop.Text, 2, 3) <> "409") AndAlso (_cst = "60") Then
                            lbl_mensagem.Text = "O CFOP deve ser terminar em 409 para produto com CST ""60"" !"
                            txt_cfop.Focus() : txt_cfop.SelectAll() : Return False
                        End If
                    Case "905", "906" 'Remessa pra deposito fechado

                        If (Mid(txt_cfop.Text, 2, 3) <> "905") AndAlso (Mid(txt_cfop.Text, 2, 3) <> "906") Then
                            lbl_mensagem.Text = "O CFOP deve ser terminar em ""905, 906"" para produto com CST ""60"" !"
                            txt_cfop.Focus() : txt_cfop.SelectAll() : Return False
                        End If
                    Case Else

                        If (Mid(txt_cfop.Text, 2, 3) <> "403") AndAlso (Mid(txt_cfop.Text, 2, 3) <> "404") AndAlso _
                            (Mid(txt_cfop.Text, 2, 3) <> "405") Then
                            lbl_mensagem.Text = "O CFOP deve ser terminar em ""403, 404, 405"" para produto com CST ""30, 40, 41 ou 60"" !"
                            txt_cfop.Focus() : txt_cfop.SelectAll() : Return False
                        End If

                End Select

                

            Case "00" '          ! Não Informar o ICMS SUBSTITUTO !

                Select Case geno001.pCrt
                    Case "1" '1 - Simples Nacional: 
                        'Podem ser usados:
                        '101 - Tributado
                        '102 - Tributado Sem Credito; 
                        '103 - Isenção dentro da faixa; 
                        '300 - Imune; 
                        '400 - Não Tributado pelo Simples:
                        '201 - Tributado c/ Permissão de Crédito
                        '202 - Tributado sem P. Credito, mas c/ cobrança por Subtituição
                        '203 - Isenção por faixa de receita e com cobrança de Substituição
                        '500 - ICMS Cobrado anteriormente por Subst. / Antecipação
                        '900 - Outras Tributações

                        If CDec(Me.txt_basecalc.Text) > 0 Then
                            If validaIcmsNormalZERADOS_CST("00") = False Then Return False
                            If validaIcmsSubstitutoVALORES_CST("00") = False Then Return False
                        End If


                    Case "2" '1 - Simples Nacional com Retenção

                        If CDec(Me.txt_basecalc.Text) > 0 Then
                            If validaIcmsNormalZERADOS_CST("00") = False Then Return False
                            If validaIcmsSubstitutoVALORES_CST("00") = False Then Return False
                        End If

                    Case "3" '3 - Regime Normal

                        If validaIcmsNormalZERADOS_CST("00") = False Then Return False
                        If validaIcmsSubstitutoVALORES_CST("00") = False Then Return False
                        
                End Select

                




                Select Case Mid(_cfop, 2, 3) 'CFOP da NOta
                    Case "152" 'Transferencia pra deposito fechado

                        If (Mid(txt_cfop.Text, 2, 3) <> "152") Then
                            lbl_mensagem.Text = "O CFOP deve ser terminar em 152 para produto com CST ""60"" !"
                            txt_cfop.Focus() : txt_cfop.SelectAll() : Return False
                        End If
                    Case "905", "906" 'Remessa pra deposito fechado

                        If (Mid(txt_cfop.Text, 2, 3) <> "905") AndAlso (Mid(txt_cfop.Text, 2, 3) <> "906") Then
                            lbl_mensagem.Text = "O CFOP deve ser terminar em ""905, 906"" para produto com CST ""60"" !"
                            txt_cfop.Focus() : txt_cfop.SelectAll() : Return False
                        End If

                End Select

            Case "10" '          ! Pode ou Não informar o ICMS NORMAL !

                If validaIcmsSubstitutoZERADOS_CST("10") = False Then Return False

                If validaIcmsNormal() = False Then Return False



        End Select



        'INICIO da validação do IPI
        If CDec(txt_vlipi.Text) > 0 Then

            If CDec(txt_alqipi.Text) <= 0 Then
                lbl_mensagem.Text = "Aliquota do IPI deve ser Maior que ZERO quando o Valor do IPI for Maior que ZERO !"
                txt_alqipi.Focus() : txt_alqipi.SelectAll() : Return False
            End If
        Else

            If CDec(txt_alqipi.Text) > 0 Then
                lbl_mensagem.Text = "Aliquota do IPI deve ser ZERO quando o Valor do IPI for ZERO !"
                txt_alqipi.Focus() : txt_alqipi.SelectAll() : Return False
            End If
        End If
        'FIM da Validação do IPI


        'Para Simples o "CSOSN = 900" se tiver preenchido os valores de ICMS NORMAL e ICMS SUBSTITUTO
        'SENÃO irá seguir o padrão do FrmAutoriza NF-e...


        Return True
    End Function

    Private Function existeItemGrid(ByVal codItem As String) As Boolean

        For Each row As DataGridViewRow In dtg_itensNFe.Rows

            If row.IsNewRow = False Then

                If row.Cells(0).Value.ToString.Equals(codItem) Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Private Sub addItemGrid()


        lbl_mensagem.Text = ""
        Dim conexaoNcm As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conexaoNcm.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão para DataReader:: " & ex.Message, MsgBoxStyle.Critical) : Return
        End Try

        Try

            nota1pp.pNt_cfop = Mid(Me.cbo_nfeCfop.SelectedItem, 1, 5)
            'variaveis conexão:
            Dim SqlNcm As String = ""
            Dim drNcm As NpgsqlDataReader
            Dim commNcm As NpgsqlCommand

            'Variaveis Nota2cc:
            Dim cfv, grupo As Integer
            Dim cfopRegistroItem As String
            Dim mTotalGeraLItem As String
            Dim valorTotal, alqDesc, qtdeFiscalAtual, vnc_vlPis, vnc_vlCofins, vnc_prtotAux As Double
            nota2cc.zeraValores()

            nota2cc.pNc_codpr = Me.txt_codProd.Text
            nota2cc.pNc_produt = Me.txt_nomeProd.Text
            nota2cc.pNc_cfop = Me.txt_cfop.Text
            nota2cc.pNc_qtde = Me.txt_qtde.Text
            nota2cc.pNc_pruvenda = Me.txt_pruvenda.Text
            nota2cc.pNc_vldesc = Me.txt_desconto.Text
            nota2cc.pNc_prunit = Me.txt_vlunitario.Text
            nota2cc.pNc_prtot = Me.txt_total.Text
            nota2cc.pNc_frete = Me.txt_frete.Text
            nota2cc.pNc_segur = Me.txt_seguro.Text
            nota2cc.pNc_descpac = Me.txt_despacessoria.Text
            nota2cc.pNc_bcalc = Me.txt_basecalc.Text
            nota2cc.pNc_alqicm = Me.txt_alqicms.Text
            nota2cc.pNc_vlicm = Me.txt_vlicms.Text
            nota2cc.pNc_basesub = Me.txt_basesubs.Text
            nota2cc.pNc_alqsub = Me.txt_alqsubs.Text
            nota2cc.pNc_vlsubs = Me.txt_vlsubs.Text
            nota2cc.pNc_alqipi = Me.txt_alqipi.Text
            nota2cc.pNc_vlipi = Me.txt_vlipi.Text

            valorTotal = Round(CDec(Me.txt_total.Text) + CDec(Me.txt_desconto.Text), 2)
            Try
                alqDesc = Round((CDec(Me.txt_desconto.Text) * 100) / valorTotal, 2)
            Catch ex As Exception
                alqDesc = 0.0
            End Try
            nota2cc.pNc_desc = alqDesc


            nota2cc.pNc_cf = produto.pClf
            nota2cc.pNc_cst = _cst 'Format(produto.pCst, "00")
            cfv = produto.pCfv
            grupo = produto.pGrupo
            nota2cc.pNc_und = produto.pUnd
            nota2cc.pNc_isento = 0.0
            If cfv = 4 Then nota2cc.pNc_isento = nota2cc.pNc_prtot
            nota2cc.pNc_csosn = ""
            nota2cc.pNc_vltrib = 0.0

            nota2cc.pNc_alqreduz = produto.pReduz
            nota2cc.pNc_reduz = 0.0
            If nota2cc.pNc_alqreduz > 0 Then nota2cc.pNc_reduz = Round((nota2cc.pNc_prtot * nota2cc.pNc_alqreduz) / 100, 2)


            'Tratamento do NCM....
            nota2cc.pNc_ncm = produto.pNcm
            If nota2cc.pNc_ncm.Length <> 8 Then
                MsgBox("Produto """ & nota2cc.pNc_codpr & """ corrigir NCM!  Por Favor alterar no cadastro do Produto", MsgBoxStyle.Exclamation)
                Return
            End If
            'END NCM......

            Select Case geno001.pCrt
                Case "1" '1 - Simples Nacional: 
                    'Podem ser usados:
                    '101 - Tributado
                    '102 - Tributado Sem Credito; 
                    '103 - Isenção dentro da faixa; 
                    '300 - Imune; 
                    '400 - Não Tributado pelo Simples:
                    '201 - Tributado c/ Permissão de Crédito
                    '202 - Tributado sem P. Credito, mas c/ cobrança por Subtituição
                    '203 - Isenção por faixa de receita e com cobrança de Substituição
                    '500 - ICMS Cobrado anteriormente por Subst. / Antecipação
                    '900 - Outras Tributações

                    'nota2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, nota1pp.pNt_cfop, 0)
                    If nota2cc.pNc_bcalc > 0 Then
                        nota2cc.pNc_csosn = "101"
                    Else

                        If cfv = 1 Or cfv = 4 Then 'CSOSN 102
                            ' /Icms12 - Produto Trib. p/ Simples Nacional s/ Permissao de Credito **
                            nota2cc.pNc_csosn = "102"
                            nota2cc.pNc_alqicm = 0
                            nota2cc.pNc_vlicm = 0 : nota2cc.pNc_unipi = 0
                            nota2cc.pNc_vlsubs = 0 : nota2cc.pNc_alqsub = 0
                            nota2cc.pNc_bcalc = 0 : nota2cc.pNc_basesub = 0
                        End If


                        If cfv = 3 Then 'CSOSN 500 Produto com substitui‡Æo
                            nota2cc.pNc_csosn = "500"
                            nota2cc.pNc_alqicm = 0
                            nota2cc.pNc_vlicm = 0 : nota2cc.pNc_unipi = 0
                            nota2cc.pNc_vlsubs = 0 : nota2cc.pNc_alqsub = 0
                            nota2cc.pNc_bcalc = 0 : nota2cc.pNc_basesub = 0
                        End If
                    End If


                    If (nota2cc.pNc_vlsubs > 0) OrElse (nota2cc.pNc_vlipi > 0) Then
                        nota2cc.pNc_csosn = "900"
                    End If



                Case "2" '1 - Simples Nacional com Retenção
                    'nota2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, nota1pp.pNt_cfop, 0)
                    Select Case cfv
                        Case 1
                            nota2cc.pNc_csosn = "202"
                            nota2cc.pNc_vlsubs = 0 : nota2cc.pNc_alqsub = 0
                            nota2cc.pNc_basesub = 0
                        Case 3 'Produto com substituição
                            nota2cc.pNc_csosn = "500"
                        Case 4
                            nota2cc.pNc_csosn = "102"
                    End Select

                    If (nota2cc.pNc_vlsubs > 0) OrElse (nota2cc.pNc_vlipi > 0) Then
                        nota2cc.pNc_csosn = "900"
                    End If

                Case "3" '3 - Regime Normal

                    If cfv = 3 Then
                        nota2cc.pNc_alqicm = 0.0 : nota2cc.pNc_vlicm = 0.0
                        nota6hh.pC_compl5 = "(*) ICMS PAGO ANTEC CONF.DECR. N.6551/85 E 9483/97"
                        nota2cc.pNc_produt = RTrim(nota2cc.pNc_produt) & " (*)"
                        nota4dd.pN4_outras = nota4dd.pN4_outras + Round((nota2cc.pNc_qtde * nota2cc.pNc_prunit), 2)
                    End If

                    If nota1pp.pNt_cfop.Substring(0, 1).Equals("5") Then
                        nota2cc.pNc_alqicm = alqInterna
                    ElseIf nota1pp.pNt_cfop.Substring(0, 1).Equals("6") Then
                        nota2cc.pNc_alqicm = alqExterna
                    End If

                    'nota2cc.pNc_cfop = _clFuncoes.tratamentoCfopItemSaidas(cfv, nota1pp.pNt_cfop, 0)

            End Select


            'Calculando Tributos......................................................................
            'ICMS
            If nota2cc.pNc_alqicm <= 0 Then
                nota2cc.pNc_vlicm = 0
            Else

                Select Case nota2cc.pNc_cst
                    Case "20"
                        nota2cc.pNc_bcalc = Round((nota2cc.pNc_prtot * nota2cc.pNc_alqreduz) / 100, 2)
                        nota2cc.pNc_bcalc = Round(nota2cc.pNc_prtot - nota2cc.pNc_bcalc, 2)
                        nota2cc.pNc_vlicm = Round((nota2cc.pNc_bcalc * nota2cc.pNc_alqicm) / 100, 2)

                    Case Else
                        nota2cc.pNc_bcalc = Round((nota2cc.pNc_prtot - nota2cc.pNc_vldesc), 2)
                        nota2cc.pNc_vlicm = Round((nota2cc.pNc_bcalc * nota2cc.pNc_alqicm) / 100, 2)

                End Select

            End If

            'IPI
            If nota2cc.pNc_alqipi <= 0 Then
                nota2cc.pNc_vlipi = 0
            End If


            'ICMS/IPI
            If (nota2cc.pNc_alqicm <= 0) AndAlso (nota2cc.pNc_alqipi <= 0) Then
                nota2cc.pNc_bcalc = 0.0
            End If


            Select Case nota2cc.pNc_cst
                Case "01", "02", "03"
                    vnc_vlPis = 0.0
                    vnc_vlCofins = 0.0
                Case Else

            End Select

            nota2cc.pNc_cstipi = produto.pCstIpi

            'Tratamento do PIS/COFINS ............
            cfopRegistroItem = nota2cc.pNc_cfop.Substring(nota2cc.pNc_cfop.Length - 3, 3)
            SqlNcm = "SELECT ncm_pissaid, ncm_cofinssaid FROM estncm WHERE ncm_ncm = '" & nota2cc.pNc_ncm & "' " & _
            "AND ncm_cfop LIKE '%" & cfopRegistroItem & "%' LIMIT 1"
            commNcm = New NpgsqlCommand(SqlNcm, conexaoNcm)
            drNcm = commNcm.ExecuteReader
            If drNcm.HasRows = False Then
                MsgBox("Produto """ & nota2cc.pNc_codpr & """ não tem configurações para PIS/COFINS!  Por Favor alterar no cadastro do Produto", MsgBoxStyle.Exclamation)
                Return
            End If

            While drNcm.Read
                nota2cc.pNc_cstpis = drNcm(0).ToString
                nota2cc.pNc_cstcofins = drNcm(1).ToString
            End While
            drNcm.Close() : commNcm.CommandText = "" : conexaoNcm.ClearPool()

            'Select Case nota2cc.pNc_cstpis
            '    Case "49"
            '        Select Case cfopRegistroItem
            '            Case "904" 'Remesssa...
            '            Case Else
            '                nota2cc.pNc_cstpis = "01"
            '        End Select

            'End Select
            'Select Case nota2cc.pNc_cstcofins
            '    Case "49"
            '        Select Case cfopRegistroItem
            '            Case "904" 'Remesssa...
            '            Case Else
            '                nota2cc.pNc_cstcofins = "01"
            '        End Select
            'End Select


            vnc_prtotAux = Round(((nota2cc.pNc_prtot - nota2cc.pNc_vldesc) - nota2cc.pNc_reduz), 2)

            Select Case geno001.pCrt
                Case "1", "2"
                Case "3" 'Regime Normal

                    If geno001.pPis > 0 Then

                        Try
                            If CInt(nota2cc.pNc_cstpis) < 5 Then vnc_vlPis = Round((vnc_prtotAux * geno001.pPis) / 100, 2)
                        Catch ex As Exception
                        End Try

                    End If

                    If geno001.pCofins > 0 Then

                        Try
                            If CInt(nota2cc.pNc_cstcofins) < 5 Then vnc_vlCofins = Round((vnc_prtotAux * geno001.pCofins) / 100, 2)
                        Catch ex As Exception
                        End Try

                    End If

            End Select




            nota2cc.pNc_vltrib = cl_NFe.LeidaTransprencia(vnc_prtotAux, geno001.pPis, geno001.pCofins, geno001.pCsll, geno001.pIRenda, _
                                                          geno001.pSn, nota2cc.pNc_vlicm, nota2cc.pNc_vlipi, nota2cc.pNc_cfop)




            'Subtraindo QtdFiscal Atual.....
            qtdeFiscalAtual = _clFuncoes.trazQtdFiscEstloja01(nota2cc.pNc_codpr, codLoja, MdlConexaoBD.conectionPadrao)
            Select Case tipoNFe
                Case "E" 'Entrada
                    cl_BD.somaQtdFiscProdEstloja(nota2cc.pNc_codpr, codLoja, nota2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)
                    cl_BD.somaQtdeProdEstloja(nota2cc.pNc_codpr, codLoja, nota2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)

                Case "S" 'Saida

                    If qtdeFiscalAtual < nota2cc.pNc_qtde Then

                        If genp001.sldfiscalnegativo Then
                            cl_BD.subtraiQtdFiscProdEstloja(nota2cc.pNc_codpr, codLoja, nota2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)
                            cl_BD.subtraiQtdeProdEstloja(nota2cc.pNc_codpr, codLoja, nota2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)
                        Else

                            lbl_mensagem.Text = "Qtde. Fiscal Atual Insuficiente! Empresa não pode ficar com Saldo Fiscal Negativo !"
                            Me.txt_qtde.Focus() : Me.txt_qtde.SelectAll()
                            Return
                        End If
                    Else
                        cl_BD.subtraiQtdFiscProdEstloja(nota2cc.pNc_codpr, codLoja, nota2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)
                        cl_BD.subtraiQtdeProdEstloja(nota2cc.pNc_codpr, codLoja, nota2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)
                    End If

            End Select


            mTotalGeraLItem = Format(Round((nota2cc.pNc_prtot + nota2cc.pNc_frete + nota2cc.pNc_segur + _
                                       nota2cc.pNc_descpac + nota2cc.pNc_vlsubs + nota2cc.pNc_vlipi), 2), "#,###,##0.00")

            'dtg_itensNFe colunas:
            'Me.txt_alqicms.Text, Me.txt_vlicms.Text, Me.txt_basesubs.Text, Me.txt_alqsubs.Text, Me.txt_vlsubs.Text, Me.txt_alqipi.Text,  - 18
            'Me.txt_vlipi.Text, nc_cf, nc_cst, nc_isento, nc_csosn, nc_vltrib, nc_ncm, nc_desc, nc_voutro, nc_reduz, nc_alqreduz,  - 29
            'nc_cstpis, nc_cstcofins, nc_cstipi, descrNFe, descrAuto, pesoBruto, pesoLiquido, mTotalGeraLItem   - 35

            dtg_itensNFe.Rows.Add(nota2cc.pNc_codpr, nota2cc.pNc_produt, produto.pUnd, Me.txt_qtde.Text, Me.txt_pruvenda.Text, _
                                  Me.txt_vlunitario.Text, Me.txt_total.Text, nota2cc.pNc_cfop, Me.txt_desconto.Text, _
                                  Me.txt_frete.Text, Me.txt_seguro.Text, Me.txt_despacessoria.Text, Me.txt_basecalc.Text, Me.txt_alqicms.Text, _
                                  Me.txt_vlicms.Text, Me.txt_basesubs.Text, Me.txt_alqsubs.Text, Me.txt_vlsubs.Text, _
                                  Me.txt_alqipi.Text, Me.txt_vlipi.Text, nota2cc.pNc_cf, nota2cc.pNc_cst, nota2cc.pNc_isento, _
                                  nota2cc.pNc_csosn, nota2cc.pNc_vltrib, nota2cc.pNc_ncm, nota2cc.pNc_desc, nota2cc.pNc_voutro, _
                                  nota2cc.pNc_reduz, nota2cc.pNc_alqreduz, nota2cc.pNc_cstpis, nota2cc.pNc_cstcofins, _
                                  nota2cc.pNc_cstipi, produto.pProdut2, produto.pProdut3, produto.pPesobruto, produto.pPesoliq, mTotalGeraLItem)

            dtg_itensNFe.Refresh()


            zeraValoresItems()
            Me.txt_codProd.Focus()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally

            If conexaoNcm.State = ConnectionState.Open Then
                conexaoNcm.Close()
            End If
        End Try


    End Sub

    Private Function somaVlrTotalItensGrid() As Double

        Dim mVlrTotaLItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrTotaLItens += row.Cells(6).Value

        Next

        mVlrTotaLItens = Round(mVlrTotaLItens, 2)
        Return mVlrTotaLItens
    End Function

    Private Function somaVlrTotalGeralItensGrid() As Double

        Dim mVlrTotalGeraLItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrTotalGeraLItens += row.Cells(37).Value

        Next

        Return mVlrTotalGeraLItens
    End Function

    Private Function somaVlrFreteItensGrid() As Double

        Dim mVlrFreteItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrFreteItens += row.Cells(9).Value

        Next

        mVlrFreteItens = Round(mVlrFreteItens, 2)
        Return mVlrFreteItens
    End Function

    Private Function somaVlrDesAcessItensGrid() As Double

        Dim mVlrDesAcessItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrDesAcessItens += row.Cells(10).Value

        Next

        mVlrDesAcessItens = Round(mVlrDesAcessItens, 2)
        Return mVlrDesAcessItens
    End Function

    Private Function somaVlrSubsItensGrid() As Double

        Dim mVlrSubsItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrSubsItens += row.Cells(16).Value

        Next

        mVlrSubsItens = Round(mVlrSubsItens, 2)
        Return mVlrSubsItens
    End Function

    Private Function somaVlrIpiItensGrid() As Double

        Dim mVlrIpiItens As Double = 0
        For Each row As DataGridViewRow In Me.dtg_itensNFe.Rows

            If Not row.IsNewRow Then mVlrIpiItens += row.Cells(18).Value

        Next

        mVlrIpiItens = Round(mVlrIpiItens, 2)
        Return mVlrIpiItens
    End Function

    Private Sub atualizaVlTotalNFe()

        Dim prtotGeral As Double
        prtotGeral = somaVlrTotalGeralItensGrid()

        Me.lbl_totalNota.Text = Format(prtotGeral, "###,##0.00")

    End Sub

    Public Sub trazAliquotasBD(ByVal codIten As String, ByRef produto As Cl_Est0001)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao abrir conexão p/ buscar Aliquota:: " & ex.Message, MsgBoxStyle.Exclamation) : Return
        End Try


        Try
            SqlProduto.Append("SELECT al.alq_interna, al.alq_externa FROM aliquotas al WHERE al.alq_tipo = " & produto.pTipo)
            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConn)
            drProduto = CmdProduto.ExecuteReader

            If drProduto.HasRows = False Then Return
            While drProduto.Read

                alqInterna = drProduto(0)
                alqExterna = drProduto(1)

            End While
            drProduto.Close() : drProduto = Nothing

        Catch ex As Exception
            MsgBox("Tabela de Aliquotas ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return

        End Try

        CmdProduto.CommandText = "" : SqlProduto.Remove(0, SqlProduto.ToString.Length)
        oConn.ClearPool() : oConn.Close()
        CmdProduto = Nothing : SqlProduto = Nothing : oConn = Nothing


    End Sub

    Private Sub deletaItemGrid()

        If dtg_itensNFe.CurrentRow.IsNewRow = False Then

            If MessageBox.Show("Deseja realmente Excluir este Item ?", "Deletar Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
            Windows.Forms.DialogResult.Yes Then


                Dim mCodProd As String = Me.dtg_itensNFe.CurrentRow.Cells(0).Value.ToString
                Dim qtdeFiscalGrid As Double = Me.dtg_itensNFe.CurrentRow.Cells(3).Value
                Select Case tipoNFe
                    Case "E" 'Entrada
                        cl_BD.subtraiQtdFiscProdEstloja(mCodProd, codLoja, qtdeFiscalGrid, MdlConexaoBD.conectionPadrao)
                        cl_BD.subtraiQtdeProdEstloja(mCodProd, codLoja, qtdeFiscalGrid, MdlConexaoBD.conectionPadrao)
                    Case "S" 'Saida

                        cl_BD.somaQtdFiscProdEstloja(mCodProd, codLoja, qtdeFiscalGrid, MdlConexaoBD.conectionPadrao)
                        cl_BD.somaQtdeProdEstloja(nota2cc.pNc_codpr, codLoja, nota2cc.pNc_qtde, MdlConexaoBD.conectionPadrao)

                End Select

                dtg_itensNFe.Rows.Remove(dtg_itensNFe.CurrentRow)
                dtg_itensNFe.Refresh()

                Me.txt_codProd.Focus() : Me.txt_codProd.SelectAll()
            End If
        End If

    End Sub

    Private Function verificaRegistro() As Boolean

        lbl_mensagem.Text = ""

        If cbo_estabelecimento.SelectedIndex < 0 Then

            lbl_mensagem.Text = "Selecione uma Empresa !"
            cbo_estabelecimento.Focus() : Return False
        End If

        If cbo_tiponfe.SelectedIndex < 0 Then

            lbl_mensagem.Text = "Selecione uma Tipo de NFe !"
            cbo_tiponfe.Focus() : Return False
        End If

        If IsDate(dtp_dtSaida.Value) = False Then

            lbl_mensagem.Text = "Informe uma Data de Saída !"
            dtp_dtSaida.Focus() : Return False
        End If

        If cadp001.pCod.Equals("") Then

            lbl_mensagem.Text = "Informe um Cliente !"
            txt_nomePart.Text = "" : txt_nomePart.Focus() : Return False
        End If

        If cbo_nfeCfop.SelectedIndex < 0 Then

            lbl_mensagem.Text = "Selecione um CFOP de Registro !"
            cbo_nfeCfop.Focus() : Return False
        End If

        Return True
    End Function

    Private Function sugereCFOP_cst(ByVal cfop As String, ByVal cst As String) As String

        Dim mCfop As String = cfop

        If cst.Equals("60") Then

            Select Case Mid(cfop, 1, 1)
                Case "5"
                    mCfop = "5405"
                Case "6"
                    mCfop = "6404"
                Case "1"
                    mCfop = "1403"
                Case "2"
                    mCfop = "2403"
            End Select
        End If

        Return mCfop
    End Function

#End Region

#Region "   *** Tratamento da NF-e ***   "

    Private Function gravaNFe() As Boolean

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim Ok As Boolean = True

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try

        Try
            transacao = conexao.BeginTransaction

            incluiRegistroNFe(conexao, transacao, Ok)

            transacao.Commit() : conexao.ClearAllPools() : conexao.Close()

        Catch ex As NpgsqlException

            transacao.Rollback()
            MsgBox(ex.Message.ToString)
            Ok = False
        Catch ex As Exception

            Try
                transacao.Rollback()
            Catch ex2 As Exception
            End Try
            Ok = False
        Finally
            conexao = Nothing : transacao = Nothing

        End Try


        Return Ok
    End Function

    Private Sub incluiRegistroNFe(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, ByRef ok As Boolean)

        Dim oCmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim SqlNcm As String = ""
        Dim conexaoConsultas As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim conexaoNcm As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim drNcm As NpgsqlDataReader
        Dim commNcm As NpgsqlCommand
        Dim cfv, grupo As Integer
        Try
            conexaoConsultas.Open()
            conexaoNcm.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão para :: " & ex.Message, MsgBoxStyle.Critical) : Return
        End Try

        Dim mSomaPesoBruto, mSomaPesoLiquido, mSomaIsentos, mSomatprod, mSomaaliss, mSomavliss, mSomavlser, mAlqInterna, mAlqExterna As Double
        Dim mSomabasec, mSomaicms, mSomabsub, mSomaicsub, mSomatpro2, mSomafrete, mSomasegu, mSomaoutros, mSomatgeral As Double
        Dim mSomadesc, mSomaipi, vnc_alqDesconto, vnc_prtotAux, vnc_vlPis, vnc_vlCofins As Double
        Dim mprtotAux, vnc_reduz As Double


        'INICIO Atribuindo valores ao Nota1pp...
        nota1pp.pTipo_nt = "P"
        nota1pp.pNt_tipo = tipoNFe
        nota1pp.pNt_nume = _clFuncoes.trazVlrColunaGenp001("G00" & codLoja, "gp_sai", conexao.ConnectionString)
        Dim gp_sai As String = CInt(nota1pp.pNt_nume) + 1
        gp_sai = String.Format("{0:D9}", CInt(gp_sai))
        cl_BD.altGp_SaiGenp001(gp_sai, "G00" & codLoja, conexao, transacao)
        gp_sai = Nothing
        resn4dd01.r4_numero = nota1pp.pNt_nume
        resn4dd02.r4_numero = nota1pp.pNt_nume
        resn4dd03.r4_numero = nota1pp.pNt_nume

        nota1pp.pNt_serie = _clFuncoes.trazVlrColunaGenp001("G00" & codLoja, "gp_serie", conexao.ConnectionString)
        nota1pp.pNt_natur = Mid(Me.cbo_nfeCfop.SelectedItem, 9, 40)
        nota1pp.pNt_cfop = Mid(Me.cbo_nfeCfop.SelectedItem, 1, 5)
        nota1pp.pNt_geno = "G00" & codLoja
        nota1pp.pNt_codig = cadp001.pCod
        nota1pp.pNt_dtemis = Date.Now
        nota1pp.pNt_dtsai = dtp_dtSaida.Value
        nota1pp.pNt_emiss = False
        nota1pp.pNt_cnpj = cadp001.pCgc
        nota1pp.pNt_insc = cadp001.pInsc
        If cadp001.pCgc.Equals("") Then
            nota1pp.pNt_cnpj = cadp001.pCpf
        End If
        nota1pp.pNt_uf = cadp001.pUf
        nota1pp.pNt_orca = ""

        'Incluindo Nota1pp...
        cl_BD.incNota1pp(nota1pp, conexao, transacao)
        nota1pp.pNt_id = cl_BD.trazIdNota1pp(conexao, nota1pp.pNt_nume)
        'FIM Atribuindo valores ao Nota1pp...


        nota5tt.pT_qtde = 0
        dtgItensResumo.Rows.Clear() : dtgItensResumo.Refresh()
        nota2cc.zeraValores()
        'INICIO Tratamento do Nota2cc...
        'dtg_itensNFe colunas:
        'nota2cc.pNc_codpr, nota2cc.pNc_produt, produto.pUnd, Me.txt_qtde.Text, Me.txt_pruvenda.Text, Me.txt_vlunitario.Text,  - 5
        'Me.txt_total.Text, nota2cc.pNc_cfop, Me.txt_desconto.Text, Me.txt_frete.Text, Me.txt_seguro.Text, Me.txt_despacessoria.Text, Me.txt_basecalc.Text,  - 12
        'Me.txt_alqicms.Text, Me.txt_vlicms.Text, Me.txt_basesubs.Text, Me.txt_alqsubs.Text, Me.txt_vlsubs.Text, Me.txt_alqipi.Text,  - 18
        'Me.txt_vlipi.Text, nc_cf, nc_cst, nc_isento, nc_csosn, nc_vltrib, nc_ncm, nc_desc, nc_voutro, nc_reduz, nc_alqreduz,  - 29
        'nc_cstpis, nc_cstcofins, nc_cstipi, descrNFe, descrAuto, pesoBruto, pesoLiquido, mprtotgeral   - 37


        'Atribuindo valores padrão ao Nota2cc...
        nota2cc.pNc_tipo = tipoNFe
        nota2cc.pNc_numer = nota1pp.pNt_nume
        nota2cc.pNc_dtemis = nota1pp.pNt_dtemis
        nota2cc.pNc_cdport = nota1pp.pNt_codig
        nota2cc.pNc_ntid = nota1pp.pNt_id
        nota2cc.pNc_indtot = 1
        nota2cc.pNc_seqitem = 0


        For Each row As DataGridViewRow In dtg_itensNFe.Rows

            If row.IsNewRow = False Then


                nota2cc.pNc_codpr = row.Cells(0).Value.ToString
                nota2cc.pNc_und = row.Cells(2).Value.ToString
                nota2cc.pNc_qtde = row.Cells(3).Value.ToString
                nota2cc.pNc_pruvenda = row.Cells(4).Value
                nota2cc.pNc_prunit = row.Cells(5).Value
                nota2cc.pNc_prtot = row.Cells(6).Value
                nota2cc.pNc_cfop = row.Cells(7).Value
                nota2cc.pNc_vldesc = row.Cells(8).Value
                nota2cc.pNc_frete = row.Cells(9).Value
                nota2cc.pNc_segur = row.Cells(10).Value
                nota2cc.pNc_descpac = row.Cells(11).Value
                nota2cc.pNc_bcalc = row.Cells(12).Value
                nota2cc.pNc_alqicm = row.Cells(13).Value
                nota2cc.pNc_vlicm = row.Cells(14).Value
                nota2cc.pNc_basesub = row.Cells(15).Value
                nota2cc.pNc_alqsub = row.Cells(16).Value
                nota2cc.pNc_vlsubs = row.Cells(17).Value
                nota2cc.pNc_alqipi = row.Cells(18).Value
                nota2cc.pNc_vlipi = row.Cells(19).Value

                nota2cc.pNc_produt = row.Cells(33).Value.ToString
                If Trim(nota2cc.pNc_produt).Equals("") Then ' Se a descrição para NFe estiver em branco

                    nota2cc.pNc_produt = row.Cells(34).Value.ToString 'descrição para Automóvel
                    If Trim(nota2cc.pNc_produt).Equals("") Then ' Se a descrição para Automóvel estiver em branco
                        nota2cc.pNc_produt = row.Cells(1).Value.ToString

                    End If
                End If
                nota2cc.pNc_cf = row.Cells(20).Value.ToString
                nota2cc.pNc_cst = row.Cells(21).Value.ToString
                nota2cc.pNc_isento = row.Cells(22).Value
                nota2cc.pNc_csosn = row.Cells(23).Value.ToString
                nota2cc.pNc_vltrib = row.Cells(24).Value
                nota2cc.pNc_ncm = row.Cells(25).Value.ToString
                nota2cc.pNc_desc = row.Cells(26).Value
                nota2cc.pNc_voutro = row.Cells(27).Value
                nota2cc.pNc_reduz = row.Cells(28).Value
                nota2cc.pNc_alqreduz = row.Cells(29).Value
                nota2cc.pNc_cstpis = row.Cells(30).Value.ToString
                nota2cc.pNc_cstcofins = row.Cells(31).Value.ToString
                nota2cc.pNc_cstipi = row.Cells(32).Value.ToString

                vnc_prtotAux = Round(nota2cc.pNc_prtot - vnc_reduz, 2)
                vnc_vlPis = 0.0
                If genp001.pPis > 0 Then
                    If CInt(nota2cc.pNc_cstpis) < 5 Then vnc_vlPis = Round((vnc_prtotAux * genp001.pPis) / 100, 2)
                End If

                vnc_vlCofins = 0.0
                If genp001.pConfin > 0 Then
                    If CInt(nota2cc.pNc_cstcofins) < 5 Then vnc_vlCofins = Round((vnc_prtotAux * genp001.pConfin) / 100, 2)
                End If


                'Soma Totais........................................................
                nota4dd.pN4_pesobruto += row.Cells(35).Value
                nota4dd.pN4_pesoliquido += row.Cells(36).Value
                nota4dd.pN4_tgeral += Round(nota2cc.pNc_prtot + nota2cc.pNc_frete + nota2cc.pNc_segur + _
                                            nota2cc.pNc_descpac + nota2cc.pNc_vlsubs + nota2cc.pNc_vlipi, 2)
                nota4dd.pN4_aliss = 0
                nota4dd.pN4_vliss = 0
                nota4dd.pN4_vlser = 0
                nota4dd.pN4_basec += nota2cc.pNc_bcalc
                nota4dd.pN4_bsub += nota2cc.pNc_basesub
                nota4dd.pN4_desc += nota2cc.pNc_vldesc
                nota4dd.pN4_frete += nota2cc.pNc_frete
                nota4dd.pN4_icms += nota2cc.pNc_vlicm
                nota4dd.pN4_icsub += nota2cc.pNc_vlsubs
                nota4dd.pN4_ipi += nota2cc.pNc_vlipi
                nota4dd.pN4_isento += nota2cc.pNc_isento
                nota4dd.pN4_outros += nota2cc.pNc_descpac 'nota2cc.pNc_voutro
                nota4dd.pN4_outras += 0.0
                nota4dd.pN4_segu += nota2cc.pNc_segur
                nota4dd.pN4_tprod += Round(nota2cc.pNc_pruvenda * nota2cc.pNc_qtde, 2)
                nota4dd.pN4_vlpis += vnc_vlPis
                nota4dd.pN4_vlcofins += vnc_vlCofins
                nota4dd.pN4_totaltrib += nota2cc.pNc_vltrib

                nota2cc.pNc_seqitem += 1
                nota5tt.pT_qtde += CInt(nota2cc.pNc_qtde)
                cl_BD.incNota2cc(nota2cc, conexao, transacao)

                'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
                'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
                dtgItensResumo.Rows.Add(nota1pp.pNt_nume, nota2cc.pNc_cfop, nota2cc.pNc_cst, Round(nota2cc.pNc_alqicm, 2), _
                                        Round((nota2cc.pNc_prunit * nota2cc.pNc_qtde), 2), Round(nota2cc.pNc_vldesc, 2), _
                                        Round(nota2cc.pNc_frete, 2), Round(nota2cc.pNc_segur, 2), Round(nota2cc.pNc_descpac, 2), _
                                        Round(nota2cc.pNc_bcalc, 2), Round(nota2cc.pNc_vlicm, 2), Round(nota2cc.pNc_isento, 2), _
                                        Round(nota2cc.pNc_voutro, 2), Round(nota2cc.pNc_vlipi, 2), Round(nota2cc.pNc_prtot, 2))
                nota2cc.zeraValoresNFe01()

            End If
        Next


        'Tratamentos <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        Select Case geno001.pCrt
            Case "1" '1 - Simples Nacional

                nota6hh.pC_compl4 = "DOCTO EMITIDO P/ ME OU EPP OPTANTE PELO SIMPLES NACIONAL"
                nota6hh.pC_compl5 = "NAO GERA CREDITO FISCAL DE ICMS"
            Case "2" '2 - Simples Nacional - Excesso RB

                nota6hh.pC_compl4 = "DOCTO EMITIDO P/ ME OU EPP OPTANTE PELO SIMPLES NACIONAL"
                nota6hh.pC_compl5 = "NAO GERA CREDITO FISCAL DE ICMS"

        End Select


        'Tratamento do NOTA4DD...
        nota4dd.pN4_numer = nota1pp.pNt_nume
        nota4dd.pN4_tipo = tipoNFe
        nota4dd.pN4_idn1pp = nota1pp.pNt_id
        nota4dd.pN4_tprod = Round(nota4dd.pN4_tprod, 2)
        nota4dd.pN4_aliss = Round(nota4dd.pN4_aliss, 2)
        nota4dd.pN4_vliss = Round(nota4dd.pN4_vliss, 2)
        nota4dd.pN4_vlser = Round(nota4dd.pN4_vlser, 2)
        nota4dd.pN4_basec = Round(nota4dd.pN4_basec, 2)
        nota4dd.pN4_icms = Round(nota4dd.pN4_icms, 2)
        nota4dd.pN4_bsub = Round(nota4dd.pN4_bsub, 2)
        nota4dd.pN4_icsub = Round(nota4dd.pN4_icsub, 2)
        nota4dd.pN4_tpro2 = Round(nota4dd.pN4_tprod, 2)
        nota4dd.pN4_frete = Round(nota4dd.pN4_frete, 2)
        nota4dd.pN4_segu = Round(nota4dd.pN4_segu, 2)
        nota4dd.pN4_outros = Round(nota4dd.pN4_outros, 2)
        nota4dd.pN4_outras = Round(nota4dd.pN4_outras, 2)
        nota4dd.pN4_ipi = Round(nota4dd.pN4_ipi, 2)
        nota4dd.pN4_tgeral = Round(nota4dd.pN4_tgeral, 2)
        nota4dd.pN4_pgto = vnt_pag
        nota4dd.pN4_peso = Round(nota4dd.pN4_peso, 2)
        nota4dd.pN4_pesobruto = Round(nota4dd.pN4_pesobruto, 2)
        nota4dd.pN4_pesoliquido = Round(nota4dd.pN4_pesoliquido, 2)
        nota4dd.pN4_isento = Round(nota4dd.pN4_isento, 2)
        nota4dd.pN4_desc = Round(nota4dd.pN4_desc, 2)
        nota4dd.pN4_vlpis = Round(nota4dd.pN4_vlpis, 2)
        nota4dd.pN4_vlcofins = Round(nota4dd.pN4_vlcofins, 2)
        If nota4dd.pN4_vlpis > 0 Then nota4dd.pN4_pis = genp001.pPis
        If nota4dd.pN4_vlcofins > 0 Then nota4dd.pN4_cofins = genp001.pConfin
        nota4dd.pN4_totaltrib = Round(nota4dd.pN4_totaltrib, 2)

        cl_BD.incNota4dd(nota4dd, conexao, transacao)


        'Tratamento do Nota6hh...
        nota6hh.pC_tipo = nota1pp.pNt_tipo
        nota6hh.pC_numer = nota1pp.pNt_nume
        nota6hh.pC_idn1pp = nota1pp.pNt_id

        cl_BD.incNota6hh(nota6hh, conexao, transacao)


        'Tratamento do Nota5tt...
        cliTranportador.zeraValores()
        nota5tt.pT_numer = nota1pp.pNt_nume
        nota5tt.pT_id1pp = nota1pp.pNt_id
        nota5tt.pT_placa = ""
        nota5tt.pT_pesob = Round(nota4dd.pN4_pesobruto, 3)
        nota5tt.pT_pesol = Round(nota4dd.pN4_pesoliquido, 3)

        Select Case Me.cbo_transportador.SelectedIndex
            Case 0
                nota5tt.pT_tpfret = 0
                nota5tt.pT_placa = Me.cbo_placa.SelectedItem.ToString
                nota5tt.pT_marca = "Diversos"
                nota5tt.pT_espec = "Volumes"

                Sqlcomm.Append("SELECT aut_placa, aut_descricao, aut_fornecedor, c.p_uf, c.p_portad, c.p_cpf, c.p_cgc, c.p_end, ") '7
                Sqlcomm.Append("c.p_mun, c.p_coduf, c.p_insc FROM cadautomovel JOIN ")
                Sqlcomm.Append("cadp001 c ON c.p_cod = aut_fornecedor WHERE aut_placa LIKE '" & nota5tt.pT_placa & "'")
                oCmd = New NpgsqlCommand(Sqlcomm.ToString, conexaoConsultas)
                dr = oCmd.ExecuteReader

                While dr.Read

                    nota5tt.pT_codp = dr(2).ToString
                    nota5tt.pT_uf = dr(3).ToString
                    cliTranportador.pCod = dr(2).ToString
                    cliTranportador.pUf = dr(3).ToString
                    cliTranportador.pPortad = dr(4).ToString
                    cliTranportador.pCpf = dr(5).ToString
                    cliTranportador.pCgc = dr(6).ToString
                    cliTranportador.pEnder = dr(7).ToString
                    cliTranportador.pMun = dr(8).ToString
                    cliTranportador.pCoduf = dr(3).ToString
                    cliTranportador.pInsc = dr(10).ToString

                End While
                dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length)

                nota5tt.pT_placa = nota5tt.pT_placa.Replace("-", "")
            Case 1
                nota5tt.pT_codp = "999999"
                nota5tt.pT_tpfret = 1
                nota5tt.pT_placa = Me.txt_placa.Text
            Case 2
                nota5tt.pT_codp = "999999"
                nota5tt.pT_tpfret = 2
                nota5tt.pT_placa = Me.txt_placa.Text
            Case 3
                nota5tt.pT_codp = "999999"
                nota5tt.pT_tpfret = 9
        End Select

        cl_BD.incNota5tt(nota5tt, conexao, transacao)


        'INCIO do armazenamento dos Resumos...
        _clFuncoes.incResumAlqSaida(False, dtgItensResumo, resn4dd01, geno001, cl_BD, conexao, transacao)
        _clFuncoes.incResumCfopAlqSaida(False, dtgItensResumo, resn4dd02, geno001, cl_BD, conexao, transacao)
        _clFuncoes.incResumCstCfopAlqSaida(False, dtgItensResumo, resn4dd03, geno001, cl_BD, conexao, transacao)
        'FIM do armazenamento dos Resumos

        Try
            conexaoConsultas.Close() : conexaoConsultas = Nothing
            conexaoNcm.Close() : conexaoNcm = Nothing
        Catch ex As Exception
        End Try

    End Sub

    Private Sub gerandoNFe()


        Dim oConUp As New NpgsqlConnection(conexao)
        'Dim oCmdUp As NpgsqlCommand

        Dim oConn As New NpgsqlConnection(conexao)
        Dim oCmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim daCont As New NpgsqlDataAdapter
        Dim Mconsulta As Boolean = False
        Dim Sqlcomm As StringBuilder = New StringBuilder


        codUf = geno001.pCoduf
        AnoMes = Format(nota1pp.pNt_dtemis, "yyMM")
        anoMesPath = Format(nota1pp.pNt_dtemis, "yyyyMM")
        _frmGeraNFe.frmGeraNFeRef.AnoMes = AnoMes
        _frmGeraNFe.frmGeraNFeRef.anoMesPath = anoMesPath
        cgc = geno001.pCgc
        modelo = "55"
        serie = genp001.pSerie
        numeroNfe = nota1pp.pNt_nume
        cont = genp001.pContf

        chaveNFe = _clFuncoes.trazVlrColunaNota1pp(nota1pp.pNt_nume, geno001.pEsquemaestab, "nt_chave", MdlConexaoBD.conectionPadrao)

        If chaveNFe.Equals("") Then
            seqNFeInt = Convert.ToInt64(_clFuncoes.trazVlrColunaGenp001(geno001.pCodig, "gp_seqnfe", MdlConexaoBD.conectionPadrao))
            seqNfe = String.Format("{0:D8}", seqNFeInt)
            seqNFeInt += 1
            cl_BD.altGp_SeqNFeGenp001(String.Format("{0:D9}", seqNFeInt), geno001.pCodig, MdlConexaoBD.conectionPadrao)
        End If


        'Tratamento da Chave da NFe.............
        If Trim(chaveNFe).Equals("") Then 'Se o nota1pp não tiver com chave

            chaveSemDigitoFinal = cl_NFe.Cria_ChaveNFeSemDigitoFinal(codUf, AnoMes, cgc, modelo, serie, numeroNfe, cont, seqNfe)
            digito = cl_NFe.Digito_ChaveNFe(chaveSemDigitoFinal)
            chaveNFe = cl_NFe.Cria_ChaveNFe(codUf, AnoMes, cgc, modelo, serie, numeroNfe, cont, seqNfe, digito)
            cl_BD.altChaveNota1pp(nota1pp.pNt_nume, chaveNFe, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)

        Else 'Se já tiver chave no nota1pp...
            cl_BD.altChaveNota1pp(nota1pp.pNt_nume, chaveNFe, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
            chaveSemDigitoFinal = Mid(chaveNFe, 1, 43)
            seqNfe = Mid(chaveNFe, 36, 8)
            digito = CInt(Mid(chaveNFe, 44, 1))
        End If

        _frmGeraNFe.frmGeraNFeRef.chaveNFe = chaveNFe


        '   * *  Inicio de Criação de XML  ***
        Try

            ' Cabeçalho Padrão do Xml
            cl_NFe.Cria_xml(s)

            ' Chave da NFe
            cl_NFe.Abre_xml_infNFe(chaveNFe, s)

            ' Elementos do grupo B
            ' Identificação da Nota Fiscal eletrônica 
            ' vnt_dtemis = Date.Now

            cl_NFe.xmlGrupo_B(geno001.pCoduf, seqNfe, Trim(Mid(cbo_nfeCfop.SelectedItem, 8, 59)), nota4dd.pN4_pgto, "55", CInt(genp001.pSerie), nota1pp.pNt_nume, _
                            nota1pp.pNt_dtemis, nota1pp.pNt_dtsai, "1", geno001.pMun, "1", genp001.pContf, digito, genp001.pAmb, "1", "0", _
                            Mid(Application.ProductVersion, 1, 20), s)
            ' Encerramento do Cabeçalho do Atributo Inicial


            ' '* Inicia Tag's do Grupo C -  Emitente da NFe '**
            ' Elementos do grupo C
            cl_NFe.xmlGrupo_C(geno001.pCgc, geno001.pGeno, geno001.pEnder, geno001.pBair, geno001.pMun, geno001.pCid, geno001.pUf, _
                              geno001.pCep, geno001.pFone, geno001.pInsc, geno001.pCrt, s)

            ' '* Inicio do Grupo E -  Destinatario da NFe '**
            ' Elementos do grupo E
            Dim vp_suframa As String

            vp_suframa = ""
            If genp001.pAmb.Equals("2") Then ' Se estiver e ambiente de HOMOLOGAÇÃO
                cadp001.pPortad = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
            End If
            If Trim(cadp001.pBairro).Equals("") Then
                cadp001.pBairro = "CENTRO"
            End If

            cl_NFe.xmlGrupo_E(cadp001.pCarac, cadp001.pCgc, cadp001.pCpf, cadp001.pPortad, cadp001.pEnder, cadp001.pBairro, cadp001.pMun, _
                              cadp001.pCid, cadp001.pUf, cadp001.pCep, cadp001.pFone, cadp001.pInsc, vp_suframa, cadp001.pEmail, s)
            'Fim do Grupo E ******


            '''''''''''''''''''***
            ' Acoplando itens do pedido a Nfe - Nota2cc

            Dim conItens As New Npgsql.NpgsqlConnection(conexao)
            Dim SqlcomItens As StringBuilder = New StringBuilder
            Dim DrItens As NpgsqlDataReader

            Dim vnc_tipo, vnc_numer, vnc_codpr, vnc_produt, vnc_produt2, vnc_cf, vnc_cst, vnc_und, vnc_ncm, vnc_csosn As String
            Dim vnc_cdbarra, vnc_cfop, vnc_cdport, vnc_cstipi, vnc_cstpis, vnc_cstcofins As String
            Dim vnc_qtde, vnc_prunit, vnc_prtot, vnc_alqicm, vnc_alqipi, vnc_vlipi, vnc_vltrib As Double
            Dim vnc_vlicm, vnc_dtemis, vnc_unipi, vnc_vlsubs, vnc_descpac, vnc_reduz, vnc_alqreduz, vnc_vlpis, vnc_vlcofins As Double
            Dim vnc_bcalc, vnc_basesub, vnc_frete, vnc_segur, vnc_vldesc, vnc_isento, vnc_icmsub, vnc_prtotAux As Double
            Dim vnc_seqitem, vnc_indtot, vnc_origem As Integer
            Dim mprtotAux, mprUnitVendAux As Double

            Try
                conItens.Open()
                SqlcomItens.Append("SELECT n1.nt_orca, n1.nt_nume, n2.nc_codpr, n2.nc_produt, n2.nc_cf, n2.nc_cst, E.e_und, n2.nc_qtde, ") '7
                SqlcomItens.Append("n2.nc_prunit, n2.nc_prtot, n2.nc_alqicm, n2.nc_vlicm, n2.nc_bcalc, n2.nc_alqipi, n2.nc_vlipi, ") '14
                SqlcomItens.Append("n2.nc_unipi, n2.nc_vlsubs, n2.nc_basesub, n2.nc_cfop, n2.nc_frete, n2.nc_segur, n2.nc_vldesc, ") '21
                SqlcomItens.Append("nc_isento, E.e_produt2, n2.nc_ncm, n2.nc_csosn, n2.nc_alqsub, E.e_cdbarra, n2.nc_indtot, ") '28
                SqlcomItens.Append("n2.nc_seqitem, n2.nc_descpac, nc_reduz, nc_alqreduz, E.e_produt2, E.e_produt3, E.e_origem, ") '35
                SqlcomItens.Append("n2.nc_vltrib, n2.nc_cstpis, n2.nc_cstcofins, n2.nc_cstipi ") '39
                SqlcomItens.Append("FROM " & geno001.pEsquemaestab & ".nota1pp n1, " & geno001.pEsquemaestab & ".nota2cc n2 ")
                SqlcomItens.Append("LEFT JOIN " & geno001.pEsquemavinc & ".est0001 E ON E.e_codig = n2.nc_codpr WHERE n1.nt_nume = '")
                SqlcomItens.Append(nota1pp.pNt_nume & "' AND n2.nc_numer = n1.nt_nume ORDER BY n2.nc_seqitem ASC")

                Dim cmdItens As NpgsqlCommand = New NpgsqlCommand(SqlcomItens.ToString, conItens)
                DrItens = cmdItens.ExecuteReader          ' Executa leitura do commando

                While DrItens.Read()                   ' Ler Registros Selecionado no Paramentro
                    vnc_tipo = "S"
                    vnc_numer = DrItens(1).ToString
                    vnc_codpr = DrItens(2).ToString

                    vnc_produt = DrItens(3).ToString 'produt
                    If Trim(DrItens(33).ToString).Equals("") = False Then 'Se produt2 não está em branco
                        vnc_produt = DrItens(33).ToString
                    End If
                    If Trim(DrItens(34).ToString).Equals("") = False Then 'Se produt3 não está em branco - VEÍCULO
                        vnc_produt = DrItens(3).ToString & DrItens(34).ToString
                    End If
                    vnc_produt = Trim(vnc_produt)

                    vnc_cf = DrItens(4).ToString
                    vnc_cst = DrItens(5).ToString
                    vnc_und = DrItens(6).ToString
                    vnc_qtde = Round(DrItens(7), 6)
                    vnc_prunit = Round(DrItens(8), 4)
                    vnc_prtot = Round(DrItens(9), 2)  '(DrItens(8) * vnc_qtde)
                    vnc_alqicm = Round(DrItens(10), 2)
                    vnc_vlicm = Round(DrItens(11), 2)
                    vnc_bcalc = Round(DrItens(12), 2)
                    vnc_alqipi = Round(DrItens(13), 2)
                    vnc_vlipi = Round(DrItens(14), 2)
                    vnc_dtemis = DateValue(Now).ToOADate()
                    vnc_cdport = nota1pp.pNt_codig
                    vnc_unipi = Round(DrItens(15), 2)
                    vnc_vlsubs = Round(DrItens(16), 2)
                    vnc_basesub = Round(DrItens(17), 2)
                    vnc_cfop = DrItens(18)
                    vnc_frete = Round(DrItens(19), 2)
                    vnc_segur = Round(DrItens(20), 2)
                    vnc_vldesc = Round(DrItens(21), 2)
                    vnc_isento = Round(DrItens(22), 2)
                    vnc_produt2 = DrItens(23).ToString
                    vnc_ncm = DrItens(24).ToString
                    vnc_csosn = DrItens(25).ToString
                    vnc_icmsub = Round(DrItens(26), 2)
                    vnc_cdbarra = DrItens(27).ToString
                    If vnc_cdbarra.Length < 7 Then vnc_cdbarra = ""
                    vnc_indtot = DrItens(28)
                    vnc_seqitem = DrItens(29)
                    vnc_descpac = Round(DrItens(30), 2)
                    vnc_reduz = Round(DrItens(31), 2)
                    vnc_alqreduz = Round(DrItens(32), 2)
                    vnc_origem = DrItens(35)
                    vnc_vltrib = DrItens(36)
                    vnc_cstpis = DrItens(37).ToString
                    vnc_cstcofins = DrItens(38).ToString
                    vnc_cstipi = DrItens(39).ToString

                    mprtotAux = Round((vnc_prtot + vnc_vldesc), 2) 'vnc_prtot vem com desconto; Na NF-e precisa ir sem o desconto
                    mprUnitVendAux = Round((mprtotAux / vnc_qtde), 4) 'vnc_prunit valor unitário com desconto; Na NF-e precisa ir sem o desconto

                    vnc_prtotAux = Round((mprtotAux - vnc_vldesc) - vnc_reduz, 2)
                    vnc_vlpis = 0.0
                    If genp001.pPis > 0 Then
                        If CInt(vnc_cstpis) < 5 Then vnc_vlpis = Round((vnc_prtotAux * genp001.pPis) / 100, 2)
                    End If

                    vnc_vlcofins = 0.0
                    If genp001.pConfin > 0 Then
                        If CInt(vnc_cstcofins) < 5 Then vnc_vlcofins = Round((vnc_prtotAux * genp001.pConfin) / 100, 2)
                    End If

                    

                    cl_NFe.xmlGrupo_L(vnc_seqitem, vnc_codpr, vnc_produt, vnc_ncm, vnc_cfop, vnc_cst, vnc_origem, vnc_csosn, _
                                      vnc_und, vnc_qtde, mprUnitVendAux, mprtotAux, vnc_vldesc, vnc_bcalc, vnc_basesub, _
                                      vnc_icmsub, vnc_vlsubs, vnc_alqicm, vnc_vlicm, vnc_alqipi, vnc_vlipi, vnc_frete, _
                                      vnc_vldesc, vnc_indtot, vnc_cdbarra, vnc_descpac, vnc_reduz, geno001.pCrt, vnc_vltrib, _
                                      vnc_cstpis, vnc_cstcofins, genp001.pPis, genp001.pConfin, vnc_vlpis, vnc_vlcofins, vnc_segur, s)
                End While

                conItens.Close()
            Catch ex As NpgsqlException
                MsgBox(ex.Message.ToString) : Return
            Catch ex As Exception
                MsgBox(ex.Message.ToString) : Return
            End Try

            ''''''''''''''''''''
            ' '* Inicia Tag's do Grupo L -  Produtos da Nfe '**


            ' Valores Totais da NFe Tag W ' - Nota4dd
            cl_NFe.xmlGrupo_W(nota4dd.pN4_basec, nota4dd.pN4_icms, nota4dd.pN4_bsub, nota4dd.pN4_icsub, nota4dd.pN4_tprod, _
                              nota4dd.pN4_frete, nota4dd.pN4_segu, nota4dd.pN4_desc, nota4dd.pN4_ipi, nota4dd.pN4_vlpis, _
                              nota4dd.pN4_vlcofins, nota4dd.pN4_outros, nota4dd.pN4_tgeral, nota4dd.pN4_totaltrib, s)

            ' '* Inicia Tag's do Grupo X -  Transportador da Nfe '**  - Nota5tt
            Dim vt_codp, codfret, mp_cpf, mp_cgc, mp_ie, mp_insc, mp_portad, mp_end, mp_cid As String
            Dim mp_uf, vt_placa, vt_antt, vt_uf, vt_marca, vt_espec As String
            vt_codp = "" : codfret = "" : mp_cpf = "" : mp_cgc = "" : mp_ie = "" : mp_insc = "" : mp_portad = ""
            mp_end = "" : mp_cid = "" : mp_uf = "" : vt_placa = "" : vt_antt = "" : vt_uf = "" : vt_marca = "" : vt_espec = ""
            Dim vt_pesol As Double = 0.0
            Dim vt_pesob As Double = 0.0
            Dim vt_qtde As Integer


            vt_codp = nota5tt.pT_codp
            codfret = nota5tt.pT_tpfret
            vt_marca = nota5tt.pT_marca
            vt_espec = nota5tt.pT_espec
            vt_placa = nota5tt.pT_placa
            vt_antt = nota5tt.pT_antt
            vt_uf = nota5tt.pT_uf
            vt_qtde = nota5tt.pT_qtde
            vt_pesol = nota5tt.pT_pesol
            vt_pesob = nota5tt.pT_pesob
            mp_cpf = cliTranportador.pCpf
            mp_cgc = cliTranportador.pCgc
            mp_insc = cliTranportador.pInsc
            mp_portad = cliTranportador.pPortad
            mp_end = cliTranportador.pEnder
            mp_uf = cliTranportador.pCoduf
            mp_cid = cliTranportador.pMun

            cl_NFe.xmlGrupo_X(vt_codp, codfret, mp_cpf, mp_cgc, mp_insc, mp_portad, mp_end, mp_cid, mp_uf, vt_placa, _
                        vt_antt, vt_uf, vt_qtde, vt_espec, vt_marca, vt_pesol, vt_pesob, s)

            ' '* Inicia Tag's do Grupo Z -  Informações Complementares da Nfe '** - Nota6hh
            cl_NFe.xmlGrupo_Z(nota6hh.pC_compl1, nota6hh.pC_compl2, nota6hh.pC_compl3, nota6hh.pC_compl4, nota6hh.pC_compl5, _
                              nota6hh.pC_compl6, nota6hh.pC_compl7, nota6hh.pC_compl8, nota6hh.pC_compl9, s)


            cl_NFe.Fecha_xml_infNFe(s)
            cl_NFe.Fecha_xml(s)

            s.Close()
            fsxml.Close()


            Try
                _frmGeraNFe.frmGeraNFeRef.clickGerar = True
                _frmGeraNFe.frmGeraNFeRef.genp001 = genp001

                xmlArquivo.Remove(0, xmlArquivo.ToString.Length)
                xmlArquivo.Append(_clFuncoes.LerArquivoSalvo(ArqTemp))
                cl_BD.altXmlNota1pp(nota1pp.pNt_nume, xmlArquivo, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)

                xmlPath = genp001.pathEnvioXML & "\" & chaveNFe & "-nfe.xml"
                File.Copy(ArqTemp, xmlPath, True)
            Catch ex As Exception
                MsgBox("ERRO ao copiar o XML para """ & xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
            End Try

            buscaArquivosXML()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)

        End Try

    End Sub

    Private Function buscaArquivosXML() As Boolean

        Me.lbl_mensagem.Text = "Iniciando Validação da NFe..."
        Me.Refresh()
        System.Threading.Thread.Sleep(2000)
        strXmlRetorno = _clFuncoes.lerXmlRetorno(chaveNFe, genp001)


        If strXmlRetorno.Equals("") Then 'Se retornou nada...


            System.Threading.Thread.Sleep(500)
            strArqErroRetorno = _clFuncoes.lerArqErroRetorno(chaveNFe, genp001)
            frmMsgRtbox.rtb_mensagem.Text = strArqErroRetorno
            frmMsgRtbox.ShowDialog()
            Me.btn_finaliza.Enabled = False
            If strArqErroRetorno.Equals("") Then Me.Close()

        Else


            'Tratamento do lote recebido...
            strAux1 = "<NumeroLoteGerado>"
            strAux2 = "</NumeroLoteGerado>"
            xposinicio = strXmlRetorno.IndexOf("<NumeroLoteGerado>") : xposfim = strXmlRetorno.IndexOf("</NumeroLoteGerado>")
            xposdif = (xposfim - xposinicio) - strAux1.Length
            Try
                numLotRetorno = CInt(Mid(strXmlRetorno, xposinicio + strAux2.Length, xposdif))
                numLotRetorno = String.Format("{0:D15}", CInt(numLotRetorno))
            Catch ex As Exception
                MsgBox("ERRO ao Ler Xml Retorno """ & xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
                Me.btn_finaliza.Enabled = False
                Return False
            End Try

            Me.lbl_mensagem.Text = "Lendo o Lote de Recibo... !"
            Me.Refresh()
            System.Threading.Thread.Sleep(1000)
            strXmlLoteRecebido = _clFuncoes.lerXmlLoteRecebido(numLotRetorno, genp001)

            If strXmlLoteRecebido.Equals("") = False Then ' se ele vinher alguma coisa


                strAux1 = "<cStat>"
                strAux2 = "</cStat>"
                xposinicio = strXmlLoteRecebido.IndexOf("<cStat>") : xposfim = strXmlLoteRecebido.IndexOf("</cStat>")
                xposdif = (xposfim - xposinicio) - strAux1.Length
                Try
                    strXmlStatus = Mid(strXmlLoteRecebido, xposinicio + strAux2.Length, xposdif)

                    strAux1 = "<xMotivo>"
                    strAux2 = "</xMotivo>"
                    xposinicio = strXmlLoteRecebido.IndexOf("<xMotivo>") : xposfim = strXmlLoteRecebido.IndexOf("</xMotivo>")
                    xposdif = (xposfim - xposinicio) - strAux1.Length
                    strXmlMotivo = Mid(strXmlLoteRecebido, xposinicio + strAux2.Length, xposdif)

                    Me.lbl_mensagem.Text = strXmlStatus & " - " & strXmlMotivo & " !"
                    Me.Refresh()


                    strAux1 = "<nRec>"
                    strAux2 = "</nRec>"
                    xposinicio = strXmlLoteRecebido.IndexOf("<nRec>") : xposfim = strXmlLoteRecebido.IndexOf("</nRec>")
                    xposdif = (xposfim - xposinicio) - strAux1.Length
                    strXmlRec = Mid(strXmlLoteRecebido, xposinicio + strAux2.Length, xposdif)

                    Try

                        'Lendo o Arquivo de Recibo processado...
                        Me.lbl_mensagem.Text = "'Lendo o Arquivo de Recibo processado... !"
                        Me.Refresh()

                        System.Threading.Thread.Sleep(1000) '1 segundo...
                        strXmlProcRec = _clFuncoes.lerXmlProRec(strXmlRec, genp001)

                        xposAux = strXmlProcRec.IndexOf("</cStat>") + 10
                        strXmlProcRecAux = strXmlProcRec.Substring(xposAux)
                        strAux1 = "<cStat>"
                        strAux2 = "</cStat>"
                        xposinicio = strXmlProcRecAux.IndexOf("<cStat>") : xposfim = strXmlProcRecAux.IndexOf("</cStat>")
                        xposdif = (xposfim - xposinicio) - strAux1.Length
                        strXmlStatus = Mid(strXmlProcRecAux, xposinicio + strAux2.Length, xposdif)


                        strAux1 = "<dhRecbto>"
                        strAux2 = "</dhRecbto>"
                        xposinicio = strXmlProcRec.IndexOf("<dhRecbto>") : xposfim = strXmlProcRec.IndexOf("</dhRecbto>")
                        xposdif = (xposfim - xposinicio) - strAux1.Length
                        strXmlHora = Mid(strXmlProcRec, xposinicio + strAux2.Length, xposdif)

                        Try

                            strAux1 = "<nProt>"
                            strAux2 = "</nProt>"
                            xposinicio = strXmlProcRec.IndexOf("<nProt>") : xposfim = strXmlProcRec.IndexOf("</nProt>")
                            xposdif = (xposfim - xposinicio) - strAux1.Length
                            strXmlProtocolo = Mid(strXmlProcRec, xposinicio + strAux2.Length, xposdif)
                        Catch ex As Exception

                            xposAux = strXmlProcRec.IndexOf("</xMotivo>") + 10
                            strXmlProcRecAux = strXmlProcRec.Substring(xposAux)
                            strAux1 = "<xMotivo>"
                            strAux2 = "</xMotivo>"
                            xposinicio = strXmlProcRecAux.IndexOf("<xMotivo>") : xposfim = strXmlProcRecAux.IndexOf("</xMotivo>")
                            xposdif = (xposfim - xposinicio) - strAux1.Length
                            strXmlMotivo = Mid(strXmlProcRecAux, xposinicio + strAux2.Length, xposdif)
                            Me.lbl_mensagem.Text = strXmlStatus & " - " & strXmlMotivo
                            Me.Refresh() : Me.btn_finaliza.Enabled = False

                        End Try

                    Catch ex As Exception
                        MsgBox("ERRO ao Arquivo de Recibo processado :: " & ex.Message, MsgBoxStyle.Exclamation)
                        Me.btn_finaliza.Enabled = False
                        Return False
                    End Try

                    _frmGeraNFe.frmGeraNFeRef.mProtocolo = strXmlProtocolo

                    cl_BD.altWebrecNota1pp(nota1pp.pNt_nume, strXmlRec, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altHrwebNota1pp(nota1pp.pNt_nume, strXmlHora, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altLoteNota1pp(nota1pp.pNt_nume, numLotRetorno, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altProtoNota1pp(nota1pp.pNt_nume, strXmlProtocolo, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    If strXmlStatus.Equals("100") Then
                        cl_BD.altStatusNota1pp(nota1pp.pNt_nume, strXmlStatus, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    ElseIf strXmlStatus.Equals("110") Then
                        cl_BD.altStatusNota1pp(nota1pp.pNt_nume, strXmlStatus, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                        cl_BD.altTipoNt_Nota1pp(nota1pp.pNt_nume, "D", geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)
                    End If
                    Me.lbl_mensagem.Text = strXmlStatus & " - " & strXmlMotivo
                    Me.Refresh()

                    System.Threading.Thread.Sleep(1000) '1 segundo...
                    xmlArquivo.Remove(0, xmlArquivo.ToString.Length)
                    xmlArquivo.Append(_clFuncoes.lerXmlEnviado(anoMesPath, chaveNFe, genp001))
                    cl_BD.altXmlNota1pp(nota1pp.pNt_nume, xmlArquivo, geno001.pEsquemaestab, MdlConexaoBD.conectionPadrao)


                    If btn_finaliza.Enabled Then MessageBox.Show("Nota Gerada c/ Sucessso !", "Finalização", MessageBoxButtons.OK, MessageBoxIcon.Information)


                    Me.Close()
                Catch ex As Exception
                    MsgBox("ERRO ao Ler Lote Recebido """ & xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
                    Return False
                End Try


            Else


                strXmlLoteRecebido = _clFuncoes.lerXmlLoteRecebidoErro(numLotRetorno, genp001)
                frmMsgRtbox.rtb_mensagem.Text = strXmlLoteRecebido
                Me.btn_finaliza.Enabled = False
                frmMsgRtbox.ShowDialog()
                If strXmlLoteRecebido.Equals("") Then Me.Close()

            End If

        End If


        Return True
    End Function

#End Region

    Private Sub txt_codPart_KeyDownExtracted()

        formBusca = True : _frmREf = Me
        buscaCliente.set_frmRef(Me)
        buscaCliente.ShowDialog(Me)
        formBusca = False
        If Me.txt_codPart.Text.Equals("") Then
            Me.txt_codPart.Focus()
        Else
            _clFuncoes.trazFornecedor(Me.txt_codPart.Text, cadp001)
        End If
        Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()

    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown



        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

            If Me.txt_codPart.Text.Equals("") Then


                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    txt_codPart_KeyDownExtracted()

                    'preenche CBO CFOP...
                    If Not cadp001.pUf.Equals("") Then

                        Select Case tipoNFe
                            Case "S" ' Se for uma Nota de Saída
                                Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopSaidas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                            Case "E" ' Se for uma Nota de Entrada
                                Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopEntradas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                        End Select

                    End If
                    Me.cbo_nfeCfop.Text = "" : Me.cbo_nfeCfop.SelectedIndex = -1

                Catch ex As Exception
                End Try

            Else  ' Consulta pelo codigo do cliente...


                If _clFuncoes.trazFornecedor(Me.txt_codPart.Text, cadp001) Then

                    Dim lShouldReturn As Boolean
                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing
                    Me.txt_codPart.Text = cadp001.pCod : Me.txt_nomePart.Text = cadp001.pPortad

                    'preenche CBO CFOP...
                    If Not cadp001.pUf.Equals("") Then

                        Select Case tipoNFe
                            Case "S" ' Se for uma Nota de Saída
                                Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopSaidas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                            Case "E" ' Se for uma Nota de Entrada
                                Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopEntradas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                        End Select

                    End If
                    Me.cbo_nfeCfop.Text = "" : Me.cbo_nfeCfop.SelectedIndex = -1

                Else


                    'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                    Try
                        txt_codPart_KeyDownExtracted()

                        'preenche CBO CFOP...
                        If Not cadp001.pUf.Equals("") Then

                            Select Case tipoNFe
                                Case "S" ' Se for uma Nota de Saída
                                    Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopSaidas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                                Case "E" ' Se for uma Nota de Entrada
                                    Me.cbo_nfeCfop = _clFuncoes.PreenchComboCfopEntradas(geno001.pUf, cadp001.pUf, Me.cbo_nfeCfop, MdlConexaoBD.conectionPadrao)
                            End Select

                        End If
                        Me.cbo_nfeCfop.Text = "" : Me.cbo_nfeCfop.SelectedIndex = -1

                    Catch ex As Exception
                    End Try

                End If
            End If

        End If

        formBusca = False


    End Sub

    Private Sub cbo_nfeCfop_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_nfeCfop.GotFocus
        If cbo_nfeCfop.DroppedDown = False Then cbo_nfeCfop.DroppedDown = True
    End Sub

    Private Sub cbo_nfeCfop_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_nfeCfop.Leave

        lbl_mensagem.Text = ""
        If cbo_nfeCfop.SelectedIndex < 0 Then
            lbl_mensagem.Text = "Selecione um CFOP Por Favor !"
            cbo_nfeCfop.Focus()

        Else
            digCFOP = Mid(cbo_nfeCfop.SelectedItem.ToString, 1, 1)
            _cfop = Mid(cbo_nfeCfop.SelectedItem.ToString, 1, 5).Replace(".", "")
        End If

    End Sub

    Private Sub txt_codProd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codProd.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_codProd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codProd.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

            If Me.txt_codProd.Text.Equals("") Then

                'Aqui tenta chamar a Busca do Produto...
                Try
                    _frmREf = Me
                    buscaProduto.set_frmRef(Me)
                    buscaProduto.set_Geno001Ref(geno001)
                    buscaProduto.ShowDialog(Me)
                    formBusca = False

                    If txt_nomeProd.Equals("") = False Then
                        _clFuncoes.trazProdutoBD(Me.txt_codProd.Text, produto, geno001)
                    End If

                    If MdlEmpresaUsu._codProd Then

                        Me.txt_codProd.Text = produto.pCodig
                    Else
                        Me.txt_codProd.Text = produto.pCdbarra
                    End If


                    Me.txt_nomeProd.Text = produto.pProdut
                    Me.lbl_qtdFiscal.Text = produto.pQtdfisc
                    Me.txt_pruvenda.Text = Format(produto.pPvenda, "###,##0.0000")
                    Me.txt_vlunitario.Text = Format(produto.pPvenda, "###,##0.0000")
                    Me.txt_cfop.Text = _cfop

                    txt_codProd.Text = produto.pCodig
                    If Me.txt_codProd.Text.Equals("") Then

                        Me.txt_codProd.Focus()
                    Else
                        Me.txt_nomeProd.Focus()
                    End If

                    extractedCodProdKeyDown()

                Catch ex As Exception
                End Try

            Else

                If _clFuncoes.trazProdutoBD(Me.txt_codProd.Text, produto, geno001) = False Then


                    'Aqui tenta chamar a Busca do Produto...
                    Try
                        _frmREf = Me
                        buscaProduto.set_frmRef(Me)
                        buscaProduto.set_Geno001Ref(geno001)
                        buscaProduto.ShowDialog(Me)
                        formBusca = False

                        If txt_nomeProd.Equals("") = False Then
                            _clFuncoes.trazProdutoBD(Me.txt_codProd.Text, produto, geno001)
                        End If

                        If MdlEmpresaUsu._codProd Then

                            Me.txt_codProd.Text = produto.pCodig
                        Else
                            Me.txt_codProd.Text = produto.pCdbarra
                        End If


                        Me.txt_nomeProd.Text = produto.pProdut
                        Me.lbl_qtdFiscal.Text = produto.pQtdfisc
                        Me.txt_pruvenda.Text = Format(produto.pPvenda, "###,##0.0000")
                        Me.txt_vlunitario.Text = Format(produto.pPvenda, "###,##0.0000")
                        Me.txt_cfop.Text = _cfop

                        txt_codProd.Text = produto.pCodig
                        If Me.txt_codProd.Text.Equals("") Then

                            Me.txt_codProd.Focus()
                        Else
                            Me.txt_nomeProd.Focus()
                        End If

                        extractedCodProdKeyDown()

                    Catch ex As Exception
                    End Try

                Else

                    If MdlEmpresaUsu._codProd Then

                        Me.txt_codProd.Text = produto.pCodig
                    Else
                        Me.txt_codProd.Text = produto.pCdbarra
                    End If


                    Me.txt_nomeProd.Text = produto.pProdut
                    Me.lbl_qtdFiscal.Text = produto.pQtdfisc
                    Me.txt_pruvenda.Text = Format(produto.pPvenda, "###,##0.0000")
                    Me.txt_vlunitario.Text = Format(produto.pPvenda, "###,##0.0000")
                    Me.txt_cfop.Text = _cfop

                    txt_codProd.Text = produto.pCodig
                    If Me.txt_codProd.Text.Equals("") Then

                        Me.txt_codProd.Focus()
                    Else
                        Me.txt_nomeProd.Focus()
                    End If

                    extractedCodProdKeyDown()

                End If


            End If
        End If

    End Sub

    Private Sub extractedCodProdKeyDown()

        trazAliquotasBD(produto.pCodig, produto)


        Select Case geno001.pCrt
            Case "1"
            Case "2" 'Simples - Retenção

                If cadp001.pUf.Equals(geno001.pUf) Then
                    txt_alqicms.Text = Format(alqInterna, "###,##0.00")
                Else
                    txt_alqicms.Text = Format(alqExterna, "###,##0.00")
                End If

            Case "3" 'Regime Normal

                If cadp001.pUf.Equals(geno001.pUf) Then
                    txt_alqicms.Text = Format(alqInterna, "###,##0.00")
                Else
                    txt_alqicms.Text = Format(alqExterna, "###,##0.00")
                End If

        End Select

        txt_alqipi.Text = Format(produto.pIpi, "###,##0.00")

        cbo_cst.SelectedIndex = _clFuncoes.trazIndexCboCST(produto.pCst, cbo_cst)
        _cst = Format(produto.pCst, "00")

        If tipoNFe.Equals("S") Then
            txt_cfop.Text = _clFuncoes.tratamentoCfopItemSaidas(_cfop, _cst)
        End If
        If tipoNFe.Equals("E") Then
            txt_cfop.Text = _clFuncoes.tratamentoCfopItemSaidas(_cfop, _cst)
        End If


        If existeItemGrid(produto.pCodig) Then
            lbl_mensagem.Text = "Esse Produto Já foi Adicionado !" : Return
        End If

        If produto.pNcm.Length <> 8 Then
            lbl_mensagem.Text = "Produto com NCM Incorreto !" : Return
        End If

    End Sub

    Private Sub txt_cfop_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cfop.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_cfop_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cfop.Leave

        lbl_mensagem.Text = ""
        If Trim(Me.txt_cfop.Text).Equals("") Then
            lbl_mensagem.Text = "Preencha o CFOP Por Favor !"
            txt_cfop.Focus() : txt_cfop.SelectAll() : Return
        Else

            If Trim(Me.txt_cfop.Text).Length <> 4 Then
                lbl_mensagem.Text = "CFOP Inválido !"
                txt_cfop.Focus() : txt_cfop.SelectAll() : Return
            Else

                If Mid(txt_cfop.Text, 1, 1).Equals(digCFOP) = False Then

                    lbl_mensagem.Text = "Primeiro Digito do CFOP deve começar com """ & digCFOP & """ !"
                    txt_cfop.Focus() : txt_cfop.SelectAll() : Return
                End If

                If _clFuncoes.existCFOP_Tabela(Me.txt_cfop.Text, MdlConexaoBD.conectionPadrao) = False Then

                    lbl_mensagem.Text = "CFOP Não Existe Na Tabela Padrão de CFOPs !"

                    buscaCFOP()
                    txt_cfop.Focus() : txt_cfop.SelectAll() : Return
                End If

            End If
        End If

    End Sub

    Private Sub txt_vlicms_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_vlicms.GotFocus

        Try
            txt_vlicms.Text = Format(Round(((CDec(txt_basecalc.Text) * CDec(txt_alqicms.Text)) / 100), 2), "###,##0.00")
        Catch ex As Exception
            txt_vlicms.Text = Format(0.0, "###,##0.00")
        End Try

    End Sub

    Private Sub txt_Valores_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_vlunitario.KeyPress, txt_vlsubs.KeyPress, txt_vlipi.KeyPress, txt_vlicms.KeyPress, txt_total.KeyPress, txt_qtde.KeyPress, txt_pruvenda.KeyPress, txt_frete.KeyPress, txt_despacessoria.KeyPress, txt_desconto.KeyPress, txt_basesubs.KeyPress, txt_basecalc.KeyPress, txt_alqsubs.KeyPress, txt_alqipi.KeyPress, txt_alqicms.KeyPress, txt_seguro.KeyPress
        'permite só numeros virgula
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_qtde_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtde.Leave

        lbl_mensagem.Text = ""
        If Me.txt_qtde.Text.Equals("") Then Me.txt_qtde.Text = Format(0.0, "###,##0.000")
        If IsNumeric(Me.txt_qtde.Text) Then
            If CDec(Me.txt_qtde.Text) <= 0 Then
                lbl_mensagem.Text = "Quantidade deve ser maior que ZERO !"
                txt_qtde.Focus() : txt_qtde.SelectAll() : Return

            End If
            Me.txt_qtde.Text = Format(CDec(Me.txt_qtde.Text), "###,##0.000")
            alteraVlUnit_PcoTotal()

        Else
            lbl_mensagem.Text = "Quantidade não é Numerico !"
            txt_qtde.Focus() : txt_qtde.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_pruvenda_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pruvenda.Leave

        lbl_mensagem.Text = ""
        If Me.txt_pruvenda.Text.Equals("") Then Me.txt_pruvenda.Text = Format(0.0, "###,##0.0000")
        If IsNumeric(Me.txt_pruvenda.Text) Then
            If CDec(Me.txt_pruvenda.Text) <= 0 Then
                lbl_mensagem.Text = "Preço de Venda deve ser maior que ZERO !"
                txt_qtde.Focus() : txt_qtde.SelectAll() : Return

            End If
            Me.txt_pruvenda.Text = Format(CDec(Me.txt_pruvenda.Text), "###,##0.0000")
            alteraVlUnit_PcoTotal()

        Else
            lbl_mensagem.Text = "Preço de Venda não é Numerico !"
            txt_qtde.Focus() : txt_qtde.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_desconto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_desconto.Leave

        lbl_mensagem.Text = ""
        If Me.txt_desconto.Text.Equals("") Then Me.txt_desconto.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_desconto.Text) Then
            If CDec(Me.txt_desconto.Text) < 0 Then
                lbl_mensagem.Text = "Desconto deve ser Maior ou Igual a ZERO !"
                txt_desconto.Focus() : txt_desconto.SelectAll() : Return

            End If
            Me.txt_desconto.Text = Format(CDec(Me.txt_desconto.Text), "###,##0.00")
            alteraVlUnit_PcoTotal()

        Else
            lbl_mensagem.Text = "Desconto não é Numerico !"
            txt_desconto.Focus() : txt_desconto.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_vlunitario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_vlunitario.GotFocus

        Dim valorTotal As Double = 0.0
        Dim valorUnit As Double = 0.0
        valorTotal = Round(((CDec(Me.txt_pruvenda.Text) * CDec(Me.txt_qtde.Text)) - CDec(txt_desconto.Text)), 2)
        valorUnit = Round(valorTotal / CDec(txt_qtde.Text), 4)

        Try
            Me.txt_vlunitario.Text = Format(valorUnit, "###,##0.0000")
        Catch ex As Exception
            Me.txt_vlunitario.Text = Format(0.0, "###,##0.0000")
        End Try


    End Sub

    Private Sub txt_vlunitario_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlunitario.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlunitario.Text.Equals("") Then Me.txt_vlunitario.Text = Format(0.0, "###,##0.0000")
        If IsNumeric(Me.txt_vlunitario.Text) Then
            If CDec(Me.txt_vlunitario.Text) <= 0 Then
                lbl_mensagem.Text = "Valor Unitário deve ser maior que ZERO !"
                txt_vlunitario.Focus() : txt_vlunitario.SelectAll() : Return

            End If
            Me.txt_vlunitario.Text = Format(CDec(Me.txt_vlunitario.Text), "###,##0.0000")
        Else
            lbl_mensagem.Text = "Valor Unitário não é Numerico !"
            txt_vlunitario.Focus() : txt_vlunitario.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_total_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total.GotFocus

        Try
            Me.txt_total.Text = Format(Round(CDec(Me.txt_vlunitario.Text) * CDec(Me.txt_qtde.Text), 4), "###,##0.00")
        Catch ex As Exception
            Me.txt_total.Text = Format(0.0, "###,##0.00")
        End Try

    End Sub

    Private Sub txt_total_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total.Leave

        lbl_mensagem.Text = ""
        If Me.txt_total.Text.Equals("") Then Me.txt_total.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_total.Text) Then
            If CDec(Me.txt_total.Text) <= 0 Then
                lbl_mensagem.Text = "Total R$ deve ser maior que ZERO !"
                txt_total.Focus() : txt_total.SelectAll() : Return

            End If
            Me.txt_total.Text = Format(CDec(Me.txt_total.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Total R$ não é Numerico !"
            txt_total.Focus() : txt_total.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_frete_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_frete.Leave, txt_seguro.Leave

        lbl_mensagem.Text = ""
        If Me.txt_frete.Text.Equals("") Then Me.txt_frete.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_frete.Text) Then
            If CDec(Me.txt_frete.Text) < 0 Then
                lbl_mensagem.Text = "Frete deve ser Maior ou Igual a ZERO !"
                txt_frete.Focus() : txt_frete.SelectAll() : Return

            End If
            Me.txt_frete.Text = Format(CDec(Me.txt_frete.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Frete não é Numerico !"
            txt_frete.Focus() : txt_frete.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_seguro_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_seguro.Leave

        lbl_mensagem.Text = ""
        If Me.txt_seguro.Text.Equals("") Then Me.txt_seguro.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_seguro.Text) Then
            If CDec(Me.txt_seguro.Text) < 0 Then
                lbl_mensagem.Text = "Seguro deve ser Maior ou Igual a ZERO !"
                txt_seguro.Focus() : txt_seguro.SelectAll() : Return

            End If
            Me.txt_seguro.Text = Format(CDec(Me.txt_seguro.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Seguro não é Numerico !"
            txt_seguro.Focus() : txt_seguro.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_despacessoria_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_despacessoria.Leave

        lbl_mensagem.Text = ""
        If Me.txt_despacessoria.Text.Equals("") Then Me.txt_despacessoria.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_despacessoria.Text) Then
            If CDec(Me.txt_despacessoria.Text) < 0 Then
                lbl_mensagem.Text = "Despesa Acessória deve ser Maior ou Igual a ZERO !"
                txt_despacessoria.Focus() : txt_despacessoria.SelectAll() : Return

            End If
            Me.txt_despacessoria.Text = Format(CDec(Me.txt_despacessoria.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Despesa Acessória não é Numerico !"
            txt_despacessoria.Focus() : txt_despacessoria.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_basecalc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_basecalc.GotFocus

        Try
            If _cst.Equals("00") Then 'txt_cfop.Text.Substring(txt_cfop.Text.Length - 3, 3).Equals("102")

                Select Case geno001.pCrt
                    Case "1"
                    Case "2" 'Simples - Retenção
                        txt_basecalc.Text = Format(Round(CDec(txt_total.Text) + CDec(txt_frete.Text) + CDec(txt_seguro.Text) + CDec(txt_despacessoria.Text), 2), "###,##0.00")
                    Case "3" 'Regime Normal
                        txt_basecalc.Text = Format(Round(CDec(txt_total.Text) + CDec(txt_frete.Text) + CDec(txt_seguro.Text) + CDec(txt_despacessoria.Text), 2), "###,##0.00")
                End Select

            End If
        Catch ex As Exception
        End Try


    End Sub

    Private Sub txt_basecalc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_basecalc.Leave

        lbl_mensagem.Text = ""
        If Me.txt_basecalc.Text.Equals("") Then Me.txt_basecalc.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_basecalc.Text) Then

            If CDec(Me.txt_basecalc.Text) < 0 Then
                lbl_mensagem.Text = "Base de Calculo ICMS ser Maior ou Igual a ZERO !"
                txt_basecalc.Focus() : txt_basecalc.SelectAll() : Return

            End If
            Me.txt_basecalc.Text = Format(CDec(Me.txt_basecalc.Text), "###,##0.00")

            Try

                If CDec(Me.txt_basecalc.Text) > 0 Then
                    txt_vlicms.Text = Format(Round(((CDec(txt_basecalc.Text) * CDec(txt_alqicms.Text)) / 100), 2), "###,##0.00")
                End If
            Catch ex As Exception
                txt_vlicms.Text = Format(0.0, "###,##0.00")
            End Try

        Else
            lbl_mensagem.Text = "Base de Calculo ICMS não é Numerico !"
            txt_basecalc.Focus() : txt_basecalc.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_alqicms_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqicms.Leave

        lbl_mensagem.Text = ""
        If Me.txt_alqicms.Text.Equals("") Then Me.txt_alqicms.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_alqicms.Text) Then
            If CDec(Me.txt_alqicms.Text) < 0 Then
                lbl_mensagem.Text = "Aliquota do ICMS ser Maior ou Igual a ZERO !"
                txt_alqicms.Focus() : txt_alqicms.SelectAll() : Return

            End If
            Me.txt_alqicms.Text = Format(CDec(Me.txt_alqicms.Text), "###,##0.00")

            Try
                txt_vlicms.Text = Format(Round(((CDec(txt_basecalc.Text) * CDec(txt_alqicms.Text)) / 100), 2), "###,##0.00")
            Catch ex As Exception
                txt_vlicms.Text = Format(0.0, "###,##0.00")
            End Try

        Else
            lbl_mensagem.Text = "Aliquota do ICMS não é Numerico !"
            txt_alqicms.Focus() : txt_alqicms.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_vlicms_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlicms.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlicms.Text.Equals("") Then Me.txt_vlicms.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vlicms.Text) Then
            If CDec(Me.txt_vlicms.Text) < 0 Then
                lbl_mensagem.Text = "Valor do ICMS ser Maior ou Igual a ZERO !"
                txt_vlicms.Focus() : txt_vlicms.SelectAll() : Return

            End If
            Me.txt_vlicms.Text = Format(CDec(Me.txt_vlicms.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Valor do ICMS não é Numerico !"
            txt_vlicms.Focus() : txt_vlicms.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_basesubs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_basesubs.Leave

        lbl_mensagem.Text = ""
        If Me.txt_basesubs.Text.Equals("") Then Me.txt_basesubs.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_basesubs.Text) Then
            If CDec(Me.txt_basesubs.Text) < 0 Then
                lbl_mensagem.Text = "B. Calculo do Icms Substituto ser Maior ou Igual a ZERO !"
                txt_basesubs.Focus() : txt_basesubs.SelectAll() : Return

            End If
            Me.txt_basesubs.Text = Format(CDec(Me.txt_basesubs.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "B. Calculo do Icms Substituto não é Numerico !"
            txt_basesubs.Focus() : txt_basesubs.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_alqsubs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqsubs.Leave

        lbl_mensagem.Text = ""
        If Me.txt_alqsubs.Text.Equals("") Then Me.txt_alqsubs.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_alqsubs.Text) Then
            If CDec(Me.txt_alqsubs.Text) < 0 Then
                lbl_mensagem.Text = "Aliquota do Icms Substituto ser Maior ou Igual a ZERO !"
                txt_alqsubs.Focus() : txt_alqsubs.SelectAll() : Return

            End If
            Me.txt_alqsubs.Text = Format(CDec(Me.txt_alqsubs.Text), "###,##0.00")

            Try
                txt_vlsubs.Text = Format(Round(((CDec(txt_basesubs.Text) * CDec(txt_alqsubs.Text)) / 100), 2), "###,##0.00")
            Catch ex As Exception
                txt_vlsubs.Text = Format(0.0, "###,##0.00")
            End Try

        Else
            lbl_mensagem.Text = "Aliquota do Icms Substituto não é Numerico !"
            txt_alqsubs.Focus() : txt_alqsubs.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_vlsubs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlsubs.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlsubs.Text.Equals("") Then Me.txt_vlsubs.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vlsubs.Text) Then
            If CDec(Me.txt_vlsubs.Text) < 0 Then
                lbl_mensagem.Text = "Valor do Icms Substituto ser Maior ou Igual a ZERO !"
                txt_vlsubs.Focus() : txt_vlsubs.SelectAll() : Return

            End If
            Me.txt_vlsubs.Text = Format(CDec(Me.txt_vlsubs.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Valor do Icms Substituto não é Numerico !"
            txt_vlsubs.Focus() : txt_vlsubs.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_alqipi_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqipi.Leave

        lbl_mensagem.Text = ""
        If Me.txt_alqipi.Text.Equals("") Then Me.txt_alqipi.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_alqipi.Text) Then
            If CDec(Me.txt_alqipi.Text) < 0 Then
                lbl_mensagem.Text = "Aliquota do IPI ser Maior ou Igual a ZERO !"
                txt_alqipi.Focus() : txt_alqipi.SelectAll() : Return

            End If
            Me.txt_alqipi.Text = Format(CDec(Me.txt_alqipi.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Aliquota do IPI não é Numerico !"
            txt_alqipi.Focus() : txt_alqipi.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_vlipi_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlipi.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlipi.Text.Equals("") Then Me.txt_vlipi.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vlipi.Text) Then
            If CDec(Me.txt_vlipi.Text) < 0 Then
                lbl_mensagem.Text = "Valor do IPI ser Maior ou Igual a ZERO !"
                txt_vlipi.Focus() : txt_vlipi.SelectAll() : Return

            End If
            Me.txt_vlipi.Text = Format(CDec(Me.txt_vlipi.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Valor do IPI não é Numerico !"
            txt_vlipi.Focus() : txt_vlipi.SelectAll() : Return
        End If

    End Sub

    Private Sub btn_inclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inclui.Click

        If validaCamposItem() Then

            addItemGrid()

        End If

    End Sub

    Private Sub btn_exclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exclui.Click
        deletaItemGrid()
    End Sub

    Private Sub dtg_itensNFe_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dtg_itensNFe.RowsAdded
        atualizaVlTotalNFe()
        lbl_qtdeItens.Text = dtg_itensNFe.Rows.Count
    End Sub

    Private Sub dtg_itensNFe_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dtg_itensNFe.RowsRemoved
        atualizaVlTotalNFe()
        lbl_qtdeItens.Text = dtg_itensNFe.Rows.Count
    End Sub

    Private Sub dtg_itensNFe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtg_itensNFe.KeyDown
        If e.KeyCode = Keys.Delete Then deletaItemGrid()
    End Sub

    Private Sub btn_finaliza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finaliza.Click

        lbl_mensagem.Text = ""
        If verificaRegistro() Then

            If (dtg_itensNFe.Rows.Count > 0) Then


                If MessageBox.Show("Deseja Continuar ?", "Gravar NF-e", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
                    Windows.Forms.DialogResult.Yes Then

                    If gravaNFe() Then 'Aqui Tenta Persistir os Dados da NF-e

                        If MessageBox.Show("Deseja Gerar a NF-e agora ?", "Gerar NF-e", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
                        Windows.Forms.DialogResult.Yes Then

                            'Gerando a NF-e...
                            gerandoNFe()
                        End If
                    End If
                End If


            Else
                lbl_mensagem.Text = "Informe pelo menos um Produto !"
            End If
        End If


    End Sub

    Private Sub cbo_transportador_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_transportador.GotFocus
        If Not (Me.cbo_transportador.DroppedDown) Then Me.cbo_transportador.DroppedDown = True
    End Sub

    Private Sub cbo_transportador_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_transportador.SelectedIndexChanged

        Select Case Me.cbo_transportador.SelectedIndex
            Case 0 'Emitente
                Me.txt_placa.Text = "" : Me.txt_placa.Visible = False
                Me.cbo_placa.SelectedIndex = -1 : Me.cbo_placa.Visible = True
            Case 1, 2 'Destinatário ou Terceiro
                Me.txt_placa.Text = "" : Me.txt_placa.Visible = True
                Me.cbo_placa.SelectedIndex = -1 : Me.cbo_placa.Visible = False
            Case 3
                Me.txt_placa.Text = "" : Me.txt_placa.Visible = False
                Me.cbo_placa.SelectedIndex = -1 : Me.cbo_placa.Visible = False
        End Select
    End Sub

    Private Sub cbo_placa_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_placa.GotFocus
        If Not (Me.cbo_placa.DroppedDown) Then Me.cbo_placa.DroppedDown = True
    End Sub

    Private Sub cbo_cst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_cst.GotFocus
        If cbo_cst.DroppedDown = False Then cbo_cst.DroppedDown = True
    End Sub

    Private Sub cbo_cst_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_cst.Leave

        Try
            _cst = Mid(cbo_cst.SelectedItem.ToString, 1, 2)
        Catch ex As Exception
            MsgBox("Erro CST:: " & ex.Message, MsgBoxStyle.Exclamation)
            cbo_cst.Focus() : Return
        End Try


        If tipoNFe.Equals("S") Then
            txt_cfop.Text = _clFuncoes.tratamentoCfopItemSaidas(_cfop, _cst)
        End If
        If tipoNFe.Equals("E") Then
            txt_cfop.Text = _clFuncoes.tratamentoCfopItemSaidas(_cfop, _cst)
        End If


    End Sub
End Class