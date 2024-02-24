Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog
Imports System.Text
Imports System.IO
Imports System.Math
Imports System.Net
Imports Npgsql


Public Class Frm_MenuCompras
    Private Const _valorZERO As Integer = 0

    'http://www.sintegra.gov.br/
    'http://www.webdanfe.com.br/danfe/index.html
    Public Shared _frmREf As New Frm_MenuCompras
    Dim ArqTmp As String = "\wged\temp\Importa.txt"
    Dim _clBD As New Cl_bdMetrosys

    Dim agora As Date = Now
    Dim mNF_Cfop As String
    Dim _clFunc As New ClFuncoes
    Dim _idDtg_Itens As Integer = _valorZERO, _idItemEditado As Integer = _valorZERO
    Dim _BoletoEditado As Integer = _valorZERO
    Dim _mStrConsulta As String = "", _StringToPrint As String = ""
    Dim mIDn4FF, mContParcelas As Int32
    Dim mVlTotParcelas As Decimal = 0.0
    Dim _BuscaForn As New Frm_BuscaForn, _BuscaProd As New Frm_buscaProd, _xmlBuscaProd As New Frm_xmlBuscaProd
    Dim _editaNota As Boolean = False, _formBusca As Boolean = False, _visualizaNota As Boolean = False
    Dim _importXml As Boolean = False
    Dim _itensAnteriores As New StringBuilder

    'objetos auxiliares
    Dim _mValidaValores As Boolean = True

    'objetos para XML
    Dim posNextProd, posXmlProdEdit, posGridProdEditXml As Integer
    Dim _prodEditXml As String = ""
    Dim _produtosXml As New StringBuilder
    Dim _chaveNFeXML As String
    Public _codFornXML As String
    Dim _vlCompProdXml As Double

    'objetos Totais da Nota do XML
    Dim _totBcICMS, _totICMS, _totBcST, _totST, _totPROD, _totFRETE, _totSEGU As Double
    Dim _totDESC, _totOutrDESP, _totIPI, _totNOTA As Double
    Public mbUf, mbCNPJ, mClfIten, mXmlCstIten As String
    Public mCstIten, mCfvIten, mGrupoIten, mReduzIten As Integer
    Public mbUndProd As String
    Public _mCodFonecedor As String = ""
    Public _mPesquisaForn As Boolean = False 'Serve para configura os campos CodFornec e NomeFornec

    Private mDgProdutos As New DataGridView

    'objetos para impressão
    Dim MostrarCaixaImpressoras As Boolean = False
    Private _PrintFont As New Font("Lucida Console", 8) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _sImpressao As StreamWriter
    Private _dtAdaptPrint As NpgsqlDataAdapter


    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub Frm_MenuCompras_KeyDownExtracted()

        _editaNota = False : Me.zeraValoresRegNF() : Me.zeraValoresItemNF() : Me.zeraValoresDuplicat()
        If Me.dtg_itensCompras.Rows.Count > _valorZERO Then Me.dtg_itensCompras.Rows.Clear()
        Me.atualizSomaVlItens() : Me.tbp_importXml.Enabled = False
        Me.tbp_lancanotas.Enabled = True : Me.tbp_Itensnotas.Enabled = False
        Me.tbp_contasapagar.Enabled = False : Me.tbc_compras.SelectTab(1)
        Me.txt_codPart.Focus() : lbl_mensagen.Text = ""


    End Sub

    Private Sub Frm_MenuCompras_KeyDownExtracted1()

        abilitElementsItens() : _visualizaNota = False

        If Me.dtg_itensCompras.Rows.Count > _valorZERO Then

            Me.dtg_itensCompras.Rows.Clear() : Me.dtg_itensCompras.Refresh()

        End If

        Me.zeraValoresRegNF() : Me.zeraValoresItemNF() : Me.zeraValoresDuplicat()
        If Me.dtg_itensCompras.Rows.Count > _valorZERO Then Me.dtg_itensCompras.Rows.Clear()
        Me.atualizSomaVlItens() : Me.tbp_lancanotas.Enabled = True : Me.tbp_Itensnotas.Enabled = False
        Me.tbp_contasapagar.Enabled = False : Me.tbc_compras.SelectTab(1)
        Me.txt_codPart.Focus() : lbl_mensagen.Text = ""


    End Sub

    Private Sub Frm_MenuCompras_KeyDownExtracted2()

        Me.tbp_importXml.Enabled = False : Me.tbp_lancanotas.Enabled = True
        Me.tbc_compras.SelectTab(1) : Me.txt_codPart.Focus() : lbl_mensagen.Text = ""

    End Sub

    Private Sub Frm_MenuCompras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then Me.Close()

        If e.KeyCode = Keys.F2 Then

            If tbc_compras.SelectedIndex = _valorZERO Then

                If _editaNota = True Then


                    If MessageBox.Show("Processo de Edição está aberto! Deseja Cancelar?", "METROSYS", _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Frm_MenuCompras_KeyDownExtracted()

                    Else
                        Frm_MenuCompras_KeyDownExtracted2()

                    End If
                ElseIf _visualizaNota = True Then

                    Frm_MenuCompras_KeyDownExtracted1()

                Else
                    Frm_MenuCompras_KeyDownExtracted2()

                End If
            End If
        End If



    End Sub

    Private Sub Frm_MenuCompras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If (tbc_compras.SelectedIndex <> _valorZERO) AndAlso (_formBusca = False) AndAlso _
        (e.KeyChar = Convert.ToChar(13)) Then

            e.Handled = True : SendKeys.Send("{TAB}")

        End If


    End Sub

    Private Sub Frm_MComprasLoadDuplicatas()

        Me.txt_blParcelas.Text = "0" : Me.grp_lancadup.Enabled = False : Me.tbp_Itensnotas.Enabled = False
        Me.tbp_contasapagar.Enabled = False : Me.tbp_lancanotas.Enabled = False : _mValidaValores = True
        Me.txt_codPart.Focus()


    End Sub

    Private Sub Frm_MenuCompras_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        cbo_local = _clFunc.PreenchComboLoja(cbo_local, MdlConexaoBD.conectionPadrao)
        cbo_xmlocal = _clFunc.PreenchComboLoja(cbo_xmlocal, MdlConexaoBD.conectionPadrao)
        If MdlUsuarioLogando._usuarioPrivilegio = False Then

            cbo_local.SelectedIndex = _
            _clFunc.trazIndexCboLoja(MdlUsuarioLogando._local.Substring(MdlUsuarioLogando._local.Length - 2, 2), cbo_local)
            cbo_local.Enabled = False

            cbo_xmlocal.SelectedIndex = _
            _clFunc.trazIndexCboLoja(MdlUsuarioLogando._local.Substring(MdlUsuarioLogando._local.Length - 2, 2), cbo_xmlocal)
            cbo_xmlocal.Enabled = False
        End If

        'Preenche DataGridView das NOTAS
        Me.cbo_consulta.SelectedIndex = 1 : executaConsulta() : zeraValoresRegNF() : zeraValoresItemNF()
        Me.txt_alqIcmsProd.Text = "0,00" : Me.txt_alqIpiProd.Text = "0,00"

        'Duplicatas
        Frm_MComprasLoadDuplicatas()

        'importa xml
        Me.txt_xmcodpr.Enabled = False : Me.txt_xmqtde.Enabled = False : Me.cbo_xmcfopProd.Enabled = False
        Me.btn_xmadiciona.Enabled = False : Me.cbo_xmTipoFrete.Enabled = False : Me.cbo_xmcst.Enabled = False


        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorio.BeginPrint, AddressOf InicializaRelatorio

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorio.PrintPage, AddressOf rptGravaTotaisNF
    End Sub

    Private Sub btn_itsai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_itsai.Click

        If MessageBox.Show("Deseja realmente Sair dos Itens?", "METROSYS", MessageBoxButtons.YesNo, _
        MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.tbc_compras.SelectTab(1) : Me.tbp_Itensnotas.Enabled = False : Me.btn_salvar.Focus()

        End If


    End Sub

    Private Sub btn_registrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_registrar.Click
        'verifica se o registro da NF tá OK, caso estiver e não for Frete habilita a aba dos Itens
        ' e foca ela para inserir os itens
        If verificaRegistroNF() Then

            If (Not Me.cbo_especie.Text.Equals("FT")) AndAlso (Not Me.cbo_especie.Text.Equals("FTE")) Then

                _formBusca = False : Me.tbp_Itensnotas.Enabled = True
                Me.tbc_compras.SelectTab(2) : Me.tbp_Itensnotas.Focus()

            End If
        End If



    End Sub

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        salvaTudo() : Me.tbp_importXml.Enabled = True

    End Sub

    Private Sub salvaTudoExtracted()

        Me.zeraValoresRegNF() : Me.zeraValoresItemNF() : Me.zeraValoresDuplicat()
        Me.dtg_itensCompras.Rows.Clear() : Me.tbp_Itensnotas.Enabled = False
        Me.tbp_contasapagar.Enabled = False : Me.tbc_compras.SelectTab(_valorZERO)
        _mStrConsulta = "ORDER BY n4_dtent DESC" : Me.ConsultaBD(_mStrConsulta)


    End Sub

    Private Sub salvaTudoExtracted1(ByRef shouldReturn As Boolean)

        shouldReturn = False
        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            shouldReturn = True : Return

        End Try


        Try
            transacao = conn.BeginTransaction

            Try
                Me.salvaRegistroNF(conn, transacao) : Me.salvaItensNF(conn, transacao)
                Me.incResumAlq(conn, transacao) : Me.incResumCfopAlq(conn, transacao)
                Me.incResumCstCfopAlq(conn, transacao)
                If Me.dtg_boletos.RowCount > _valorZERO Then Me.incContas_A_Pagar(conn, transacao)

                transacao.Commit() : conn.ClearPool()

            Catch ex1 As Exception
                Try
                    transacao.Rollback()

                Catch ex2 As Exception
                    shouldReturn = True
                End Try
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
            shouldReturn = True

        Finally

            If conn.State = ConnectionState.Open Then conn.Close()
            conn = Nothing : transacao = Nothing
        End Try



        Return
    End Sub

    Private Sub salvaTudoExtracted2(ByRef shouldReturn As Boolean)

        shouldReturn = False
        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            shouldReturn = True : Return

        End Try


        Try
            transacao = conn.BeginTransaction

            Try
                Me.salvaRegistroNF(conn, transacao)
                If Me.dtg_boletos.RowCount > _valorZERO Then Me.incContas_A_Pagar(conn, transacao)

                transacao.Commit() : conn.ClearPool()

            Catch ex1 As Exception
                Try
                    transacao.Rollback()

                Catch ex2 As Exception
                    shouldReturn = True
                End Try
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
            shouldReturn = True

        Finally

            If conn.State = ConnectionState.Open Then conn.Close()
            conn = Nothing : transacao = Nothing
        End Try



        Return
    End Sub

    Private Sub salvaTudo()

        'Verifica se a nota não é Frete
        If Not Me.cbo_especie.Text.Equals("FT") AndAlso Not Me.cbo_especie.Text.Equals("FTE") Then

            'Verifica se tem itens inseridos no DataGridView
            If Me.dtg_itensCompras.RowCount <= _valorZERO Then

                MsgBox("NF incompleta! Falta informar os Itens!", MsgBoxStyle.Exclamation)
                Return

            End If

            If validTotItens() Then
                'Aqui salva a Nota e os Itens, Zera os valores e chama a aba de vizualizar as Notas

                Dim lShouldReturn As Boolean : salvaTudoExtracted1(lShouldReturn)
                If lShouldReturn Then Return

                If _editaNota = False Then

                    MsgBox("Nota incluida com sucesso", MsgBoxStyle.Exclamation, "METROSYS")

                Else
                    MsgBox("Nota editada com sucesso", MsgBoxStyle.Exclamation, "METROSYS")
                    _editaNota = False

                End If

                salvaTudoExtracted()
            End If


        Else
            'Se a nota for FRETE
            'Aqui salva a Nota, Zera os valores e chama a aba de vizualizar as Notas

            Dim lShouldReturn As Boolean
            salvaTudoExtracted2(lShouldReturn)
            If lShouldReturn Then Return

            If _editaNota = False Then

                MsgBox("Nota incluida com sucesso", MsgBoxStyle.Exclamation, "METROSYS")

            Else
                MsgBox("Nota editada com sucesso", MsgBoxStyle.Exclamation, "METROSYS")
                _editaNota = False

            End If

            salvaTudoExtracted()

        End If
        Me.txt_alqIcmsProd.Text = "0,00" : Me.txt_alqIpiProd.Text = "0,00"



    End Sub

    Private Sub btn_inclui_ClickExtracted()

        _editaNota = False : Me.zeraValoresRegNF() : Me.zeraValoresItemNF() : Me.zeraValoresDuplicat()
        If Me.dtg_itensCompras.Rows.Count > _valorZERO Then Me.dtg_itensCompras.Rows.Clear()
        Me.atualizSomaVlItens() : Me.tbp_importXml.Enabled = False : Me.tbp_lancanotas.Enabled = True
        Me.tbp_Itensnotas.Enabled = False : Me.tbp_contasapagar.Enabled = False
        Me.tbc_compras.SelectTab(1) : Me.txt_codPart.Focus() : lbl_mensagen.Text = ""


    End Sub

    Private Sub btn_inclui_ClickExtracted1()

        Me.tbp_importXml.Enabled = False : Me.tbp_lancanotas.Enabled = True
        Me.tbc_compras.SelectTab(1) : Me.txt_codPart.Focus() : lbl_mensagen.Text = ""

    End Sub

    Private Sub btn_inclui_ClickExtracted2()

        abilitElementsItens() : _visualizaNota = False
        If Me.dtg_itensCompras.Rows.Count > _valorZERO Then

            Me.dtg_itensCompras.Rows.Clear() : Me.dtg_itensCompras.Refresh()

        End If

        Me.zeraValoresRegNF() : Me.zeraValoresItemNF() : Me.zeraValoresDuplicat()
        If Me.dtg_itensCompras.Rows.Count > _valorZERO Then Me.dtg_itensCompras.Rows.Clear()
        Me.atualizSomaVlItens() : Me.tbp_lancanotas.Enabled = True
        Me.tbp_Itensnotas.Enabled = False : Me.tbp_contasapagar.Enabled = False
        Me.tbc_compras.SelectTab(1) : Me.txt_codPart.Focus() : lbl_mensagen.Text = ""



    End Sub

    Private Sub btn_inclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inclui.Click

        If _editaNota = True Then

            If MessageBox.Show("Processo de Edição está aberto! Deseja Cancelar?", "METROSYS", MessageBoxButtons.YesNo, _
            MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                btn_inclui_ClickExtracted()

            Else
                btn_inclui_ClickExtracted1()

            End If

        ElseIf _visualizaNota = True Then

            btn_inclui_ClickExtracted2()

        Else 'Aqui é o processo de inclusão da nota
            btn_inclui_ClickExtracted1()

        End If



    End Sub

    Private Sub txt_nfalqicm_LostFocusExtracted()

        If Me.txt_nfalqicm.Text.Equals("") Then Me.txt_nfalqicm.Text = Format(0.0, "###,##0.00")
        Dim micm As Double : mNF_Cfop = Mid(Me.cbo_nfcfop.SelectedItem, 1, 5)
        Try
            'verifica se é numero a aliquota do ICMS
            If IsNumeric(Me.txt_nfalqicm.Text) Then

                If CDec(Me.txt_nfalqicm.Text) <> _valorZERO Then

                    micm = ((Convert.ToDouble(Me.txt_nfbscalculo.Text) * Convert.ToDouble(Me.txt_nfalqicm.Text)) / 100)
                    micm = Round(micm, 2)
                    Me.txt_nfvlicm.Text = Format(CDbl(micm), "###,##0.00")
                    If mNF_Cfop = "1.403" Or mNF_Cfop = "2.403" Then Me.lbl_mensagen.Text = "Atenção ! CFOP Selecionado não necessida de Base de Cálculo !"

                Else
                    Me.txt_nfvlicm.Text = "0,00"

                End If
                Me.txt_nfalqicm.Text = Format(CDbl(txt_nfalqicm.Text), "##0.00")

            Else
                lbl_mensagen.Text = "Valor da Aliquota do Icms na Nota é inválido !" : Return

            End If

            lbl_mensagen.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub txt_nfalqicm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfalqicm.GotFocus

        txt_nfalqicm.SelectAll()

    End Sub

    Private Sub txt_nfalqicm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfalqicm.LostFocus

        If _mValidaValores = True Then txt_nfalqicm_LostFocusExtracted()

    End Sub

    Private Sub txt_nfalqipi_LostFocusExtracted()

        If Me.txt_nfalqipi.Text.Equals("") Then Me.txt_nfalqipi.Text = Format(0.0, "###,##0.00")
        Dim mipi As Double
        Try

            If IsNumeric(Me.txt_nfalqipi.Text) Then

                If CDec(Me.txt_nfalqipi.Text) <> _valorZERO AndAlso CDec(Me.txt_nfbscalculo.Text) <> _valorZERO Then

                    mipi = ((Convert.ToDouble(Me.txt_nfbscalculo.Text) * Convert.ToDouble(Me.txt_nfalqipi.Text)) / 100)
                    mipi = Round(mipi, 2)
                    Me.txt_nfvlipi.Text = Format(Convert.ToDouble(mipi), "##,##0.00")

                ElseIf CDec(Me.txt_nfalqipi.Text) = _valorZERO Then

                    Me.txt_nfvlipi.Text = Format(0.0, "##,##0.00")

                End If
                Me.txt_nfalqipi.Text = Format(CDbl(txt_nfalqipi.Text), "##0.00")

            Else
                lbl_mensagen.Text = "Valor da Aliquota do IPI na Nota é inválido !" : Return

            End If

            lbl_mensagen.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub txt_nfalqipi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfalqipi.GotFocus

        txt_nfalqipi.SelectAll()

    End Sub

    Private Sub txt_nfalqipi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfalqipi.LostFocus

        If _mValidaValores = True Then txt_nfalqipi_LostFocusExtracted()

    End Sub

    Private Sub txt_nfvlfrete_LostFocusExtracted()

        If Me.txt_nfvlfrete.Text.Equals("") Then Me.txt_nfvlfrete.Text = Format(0.0, "###,##0.00")
        If _editaNota = False Then

            Dim moutros, mfrete As Double
            Try
                mfrete = Convert.ToDouble(Me.txt_nfvlfrete.Text)
                moutros = (CDbl(Me.txt_nftprodutos.Text) - CDbl(Me.txt_nfbscalculo.Text))
                Me.txt_nfoutros.Text = Format(Convert.ToDouble(moutros), "###,##0.00")

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try

        End If



    End Sub

    Private Sub txt_nfvlfrete_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfvlfrete.GotFocus

        txt_nfvlfrete.SelectAll()

    End Sub

    Private Sub txt_nfvlfrete_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfvlfrete.LostFocus

        If _mValidaValores = True Then txt_nfvlfrete_LostFocusExtracted()

    End Sub

    Private Sub txt_nfoutros_LostFocusExtracted()

        Dim mtgeral As Double
        Try
            mtgeral = CDbl(txt_nftprodutos.Text) + CDbl(txt_nficmsub.Text) + CDbl(txt_nfvlipi.Text) + CDbl(txt_nfipisento.Text) + _
            CDbl(txt_nfipioutros.Text) + CDbl(txt_nfvlfrete.Text)
            Me.txt_nfvltgeral.Text = Format(CDbl(mtgeral), "###,##0.00")

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub txt_nfoutros_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfoutros.GotFocus

        txt_nfoutros.SelectAll()

    End Sub

    Private Sub txt_nfoutros_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfoutros.LostFocus

        If _mValidaValores = True Then

            If Me.txt_nfoutros.Text.Equals("") Then Me.txt_nfoutros.Text = Format(0.0, "###,##0.00")
            txt_nfoutros_LostFocusExtracted()

        End If


    End Sub

    Private Sub cbo_nfcfop_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_nfcfop.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then e.Handled = True : SendKeys.Send("{TAB}")

    End Sub

    Private Sub txt_nfbasesub_LostFocusExtracted()

        If Me.txt_nfbasesub.Text.Equals("") Then Me.txt_nfbasesub.Text = Format(0.0, "###,##0.00")

        mNF_Cfop = Mid(Me.cbo_nfcfop.SelectedItem, 1, 5)
        If mNF_Cfop.Substring(2, 3).Equals("403") Then

            If IsNumeric(Me.txt_nfbasesub.Text) Then

                If CDec(Me.txt_nfbasesub.Text) <= _valorZERO Then

                    Me.lbl_mensagen.Text = "Atenção ! Favor Informar Base de Cálculo da Substituição !"
                    Return

                End If
                Me.txt_nfbasesub.Text = Format(CDbl(txt_nfbasesub.Text), "##0.00")

            End If
        End If
        lbl_mensagen.Text = ""



    End Sub

    Private Sub txt_nfbasesub_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfbasesub.GotFocus

        txt_nfbasesub.SelectAll()

    End Sub

    Private Sub txt_nfbasesub_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfbasesub.LostFocus

        If _mValidaValores = True Then txt_nfbasesub_LostFocusExtracted()

    End Sub

    Private Sub txt_nficmsub_LostFocusExtracted()

        If Me.txt_nficmsub.Text.Equals("") Then Me.txt_nficmsub.Text = Format(0.0, "###,##0.00")
        Me.lbl_mensagen.Text = ""
        mNF_Cfop = Mid(Me.cbo_nfcfop.SelectedItem, 1, 5)

        If mNF_Cfop.Substring(2, 3).Equals("403") Then


            If IsNumeric(Me.txt_nficmsub.Text) Then

                If CDec(Me.txt_nficmsub.Text) <= _valorZERO Then

                    Me.lbl_mensagen.Text = "Atenção ! Favor Informar o Valor IcmSubstituição! "
                    Return

                End If

            Else

                lbl_mensagen.Text = "Numero inválido para Valor de ICMS SUBSTITUTO!"
                Return

            End If
        End If
        Me.txt_nficmsub.Text = Format(CDec(Me.txt_nficmsub.Text), "###,##0.00")
        lbl_mensagen.Text = ""



    End Sub

    Private Sub txt_nficmsub_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nficmsub.LostFocus

        If _mValidaValores = True Then txt_nficmsub_LostFocusExtracted()

    End Sub

    Private Sub txt_nfvlicm_LostFocusExtracted()

        If Me.txt_nfvlicm.Text.Equals("") Then Me.txt_nfvlicm.Text = Format(0.0, "###,##0.00")
        'teste se operador informou valor do icms sem preencher o campo de aliquota
        If IsNumeric(Me.txt_nfvlicm.Text) Then


            If CDec(Me.txt_nfvlicm.Text) > _valorZERO Then

                If IsNumeric(Me.txt_nfalqicm.Text) Then

                    If CDec(Me.txt_nfalqicm.Text) <= _valorZERO Then

                        Me.lbl_mensagen.Text = "Atenção ! Informar Aliquota do Icms !" : Return

                    End If
                End If
            End If

        Else

            lbl_mensagen.Text = "Informe um numero válido para o Valor do Icms !"
            Return

        End If

        If CDec(Me.txt_nfvlicm.Text) = _valorZERO Then

            If CDec(Me.txt_nfalqicm.Text) <> _valorZERO Then

                Me.lbl_mensagen.Text = "Atenção ! Informar Valor do Icms !" : Return

            End If
        End If
        Me.txt_nfvlicm.Text = Format(CDec(Me.txt_nfvlicm.Text), "###,##0.00") : lbl_mensagen.Text = ""


    End Sub

    Private Sub txt_nfvlicm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfvlicm.GotFocus

        txt_nfvlicm.SelectAll()

    End Sub

    Private Sub txt_nfvlicm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfvlicm.LostFocus

        If _mValidaValores = True Then txt_nfvlicm_LostFocusExtracted()

    End Sub

    Private Sub txt_nfvlipi_LostFocusExtracted()

        If Me.txt_nfvlipi.Text.Equals("") Then Me.txt_nfvlipi.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_nfvlipi.Text) Then


            If CDec(Me.txt_nfvlipi.Text) <> _valorZERO AndAlso CDec(Me.txt_nfalqipi.Text) = _valorZERO Then

                Me.lbl_mensagen.Text = "Atenção ! Informar Aliquota do IPI para um valor de IPI diferente de ZERO !"
                Return

            End If

            If CDec(Me.txt_nfvlipi.Text) = _valorZERO AndAlso CDec(Me.txt_nfalqipi.Text) <> _valorZERO Then

                Me.lbl_mensagen.Text = "Atenção ! Informar Valor do IPI para uma aliquota diferente de ZERO !"
                Return

            End If
            Me.txt_nfvlipi.Text = Format(CDec(Me.txt_nfvlipi.Text), "###,##0.00")

        Else
            lbl_mensagen.Text = "Informe um numero válido para o Valor do IPI !" : Return

        End If

        lbl_mensagen.Text = ""



    End Sub

    Private Sub txt_nfvlipi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfvlipi.GotFocus

        txt_nfvlipi.SelectAll()

    End Sub

    Private Sub txt_nfvlipi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfvlipi.LostFocus

        If _mValidaValores = True Then
            ' teste se operador informou valor do IPI sem preencher o campo de aliquota
            txt_nfvlipi_LostFocusExtracted()

        End If



    End Sub

    Private Sub txt_nfipisento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfipisento.GotFocus

        Me.lbl_mensagen.Text = "" : txt_nfipisento.SelectAll()

    End Sub

    Private Sub txt_nfnumero_LostFocusExtracted()

        Dim mnum As Integer
        Try
            mnum = Convert.ToInt32(Me.txt_nfnumero.Text)
            Me.txt_nfnumero.Text = String.Format("{0:D9}", mnum)

        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
        End Try
        mnum = Nothing



    End Sub

    Private Sub txt_nfnumero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfnumero.GotFocus

        txt_nfnumero.SelectAll()

    End Sub

    Private Sub txt_nfnumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfnumero.LostFocus

        If _mValidaValores = True Then txt_nfnumero_LostFocusExtracted()

    End Sub

    Private Sub txt_nfserie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfserie.LostFocus

        If Me.txt_nfserie.Text = "" AndAlso IsNumeric(Me.txt_nfnumero.Text) AndAlso (CInt(Me.txt_nfnumero.Text) > _valorZERO) Then

            lbl_mensagen.Text = "Favor Preencher Serie !" : Return

        End If
        lbl_mensagen.Text = ""



    End Sub

    Private Sub txt_nftprodutos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nftprodutos.GotFocus

        txt_nftprodutos.SelectAll()

    End Sub

    Private Sub txt_nfbscalculo_LostFocusExtracted()

        If Me.txt_nfbscalculo.Text.Equals("") Then Me.txt_nfbscalculo.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_nfbscalculo.Text) Then

            If mNF_Cfop.Substring(2, 3).Equals("910") OrElse mNF_Cfop.Substring(2, 3).Equals("403") _
            OrElse mNF_Cfop.Substring(2, 3).Equals("908") OrElse mNF_Cfop.Substring(2, 3).Equals("949") Then

                If Me.txt_nfbscalculo.Text <> "0,00" Then

                    Me.lbl_mensagen.Text = "Atenção ! Base de Cálculo Inválida p/ CFOP !"
                    Return

                End If
            End If
            Me.txt_nfbscalculo.Text = Format(CDec(Me.txt_nfbscalculo.Text), "###,##0.00")

        Else

            Me.lbl_mensagen.Text = "Atenção ! Base de Cálculo Inválida !"
            Return

        End If
        Me.txt_nfbscalculo.Text = Format(CDec(Me.txt_nfbscalculo.Text), "###,##0.00")
        lbl_mensagen.Text = ""



    End Sub

    Private Sub txt_nfbscalculo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfbscalculo.GotFocus

        txt_nfbscalculo.SelectAll()

    End Sub

    Private Sub txt_nfbscalculo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfbscalculo.LostFocus

        If _mValidaValores = True Then txt_nfbscalculo_LostFocusExtracted()

    End Sub

    Private Sub msk_chavenfe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles msk_chavenfe.GotFocus

        If Me.msk_chavenfe.TextLength > _valorZERO Then Me.msk_chavenfe.SelectAll()

    End Sub

    Private Sub txt_nfipioutros_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfipioutros.GotFocus

        txt_nfipioutros.SelectAll()

    End Sub

    Private Sub txt_nftprodutos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nfvltgeral.KeyPress, txt_nfvlipi.KeyPress, txt_nfvlicm.KeyPress, txt_nfvlfrete.KeyPress, txt_nftprodutos.KeyPress, txt_nfoutros.KeyPress, txt_nfipisento.KeyPress, txt_nfipioutros.KeyPress, txt_nficmsub.KeyPress, txt_nfbscalculo.KeyPress, txt_nfbasesub.KeyPress, txt_nfalqipi.KeyPress, txt_nfalqicm.KeyPress
        'permite só numeros com virgulas
        If _clFunc.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_nfnumero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nfnumero.KeyPress
        'permite só numeros sem ponto e sem virgula
        If _clFunc.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_nfnumero_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nfnumero.Leave

        If (Me.txt_nfnumero.Text = "") OrElse (CInt(Me.txt_nfnumero.Text) = _valorZERO) Then

            lbl_mensagen.Text = "Por favor, informe o numero da nota fiscal !"
            Return

        End If
        lbl_mensagen.Text = ""


    End Sub

    Public Function trazIndexCfop(ByVal mCFOP As String, ByVal mCboCFOP As Object) As Integer

        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = _valorZERO To mCboCFOP.Items.Count - 1

            If mCFOP.Equals(mCboCFOP.Items.Item(index).ToString.Substring(_valorZERO, 5)) Then

                indiceCfop = index : Exit For

            End If
        Next
        index = Nothing



        Return indiceCfop
    End Function

    Public Function trazIndexCST(ByVal mCST As String, ByVal mCboCST As Object) As Integer

        Dim index As Integer
        For index = _valorZERO To mCboCST.Items.Count - 1

            If mCST.Equals(mCboCST.Items.Item(index).ToString.Substring(_valorZERO, 2)) Then

                Exit For

            End If
        Next



        Return index
    End Function

    Public Function trazIndexEstab(ByVal mEstab As String, ByVal mCboLocal As Object) As Integer

        Dim index As Integer
        For index = _valorZERO To mCboLocal.Items.Count - 1

            If mEstab.Equals(mCboLocal.Items.Item(index).ToString.Substring(_valorZERO, 2)) Then

                Exit For

            End If
        Next



        Return index
    End Function

    Public Function trazIndexEspec(ByVal mEspec As String, ByVal mCboEspecie As Object) As Integer

        Dim index As Integer
        For index = _valorZERO To mCboEspecie.Items.Count - 1

            If mEspec.Length < 3 Then

                If mCboEspecie.Items.Item(index).ToString.Length < 3 Then
                    If mEspec.Equals(Trim(Mid(mCboEspecie.Items.Item(index).ToString, 1, 2))) Then

                        Exit For

                    End If
                End If

            Else

                If mCboEspecie.Items.Item(index).ToString.Length >= 3 Then

                    If mEspec.Equals(Trim(Mid(mCboEspecie.Items.Item(index).ToString, 1, 3))) Then

                        Exit For

                    End If
                End If
            End If
        Next



        Return index
    End Function

    Private Sub txt_codProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codProd.Click

        Me.txt_codProd.Focus()

    End Sub

    Private Sub cbo_itcfop_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_itcfop.GotFocus

        If Not (Me.cbo_itcfop.DroppedDown) Then Me.cbo_itcfop.DroppedDown = True

    End Sub

    Private Sub cbo_itcfop_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_itcfop.KeyDown

        If Me.cbo_itcfop.SelectedIndex >= _valorZERO AndAlso e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            If Me.verifCfop(Me.cbo_itcfop) Then

                If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")

            End If
        ElseIf (e.KeyCode = Keys.Down) AndAlso Not (Me.cbo_itcfop.DroppedDown) Then

            Me.cbo_itcfop.DroppedDown = True

        ElseIf (Me.cbo_itcfop.DroppedDown) AndAlso (e.KeyCode <> Keys.Down) AndAlso (e.KeyCode <> Keys.Up) Then

            Me.cbo_itcfop.DroppedDown = False

        End If



    End Sub

    Private Function verifCfopExtracted(ByVal cboCFOP As ComboBox, ByRef shouldReturn As Boolean) As Boolean

        shouldReturn = False
        If Not mbUf.Equals("") Then

            If mbUf = "PI" Then

                If Mid(mNF_Cfop, 1, 1) <> "1" Then

                    MessageBox.Show("CFOP Invalido p/ Dentro do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    cboCFOP.Focus() : shouldReturn = True : Return False

                End If
            End If


            If mbUf <> "PI" Then

                If Mid(mNF_Cfop, 1, 1) = "1" Then

                    MessageBox.Show("CFOP Invalido p/ Fora do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    cboCFOP.Focus() : shouldReturn = True : Return False

                End If
            End If
        End If



        Return False
    End Function

    Private Function verifCfop(ByVal cboCFOP As ComboBox) As Boolean

        mNF_Cfop = Mid(cboCFOP.SelectedItem, 1, 5)
        Try

            Dim lShouldReturn As Boolean
            Dim lResult As Boolean = verifCfopExtracted(cboCFOP, lShouldReturn)
            If lShouldReturn Then Return lResult

        Catch ex As Exception
            Return True
        End Try



        Return True
    End Function

    Private Sub txt_vlIpiProd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_vlIpiProd.GotFocus

        txt_vlIpiProd.SelectAll()
        If IsNumeric(Me.txt_alqIpiProd.Text) AndAlso IsNumeric(Me.txt_BcalculoItem.Text) Then

            If CDbl(Me.txt_alqIpiProd.Text) > _valorZERO AndAlso CDbl(Me.txt_BcalculoItem.Text) > _valorZERO Then

                Me.txt_vlIpiProd.Text = (CDbl(Me.txt_BcalculoItem.Text) * CDbl(Me.txt_alqIpiProd.Text)) / 100
                Me.txt_vlIpiProd.Text = Format(CDbl(Me.txt_vlIpiProd.Text), "###,##0.00")

            End If
        End If



    End Sub

    Private Sub txt_Qtde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Qtde.GotFocus

        txt_Qtde.SelectAll()

    End Sub

    Private Sub txt_Vlproduto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Vlproduto.GotFocus

        txt_Vlproduto.SelectAll()

    End Sub

    Private Sub txt_alqIcmsProd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_alqIcmsProd.GotFocus

        txt_alqIcmsProd.SelectAll()

    End Sub

    Private Sub txt_vlDescProd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_vlDescProd.GotFocus

        txt_vlDescProd.SelectAll()

    End Sub

    Private Sub txt_vlOutrosProd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_vlOutrosProd.GotFocus

        txt_vlOutrosProd.SelectAll()

    End Sub

    Private Sub txt_vlfreteProd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_vlfreteProd.GotFocus

        txt_vlfreteProd.SelectAll()

    End Sub

    Private Sub txt_prunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_prunit.GotFocus

        txt_prunit.SelectAll()

    End Sub

    Private Sub txt_alqSubsProd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_alqSubsProd.GotFocus

        txt_alqSubsProd.SelectAll()

    End Sub

    Private Sub txt_vlSeguroProd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_vlSeguroProd.GotFocus

        txt_vlSeguroProd.SelectAll()

    End Sub

    Private Sub txt_OutrasDesp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_OutrasDesp.GotFocus

        txt_OutrasDesp.SelectAll()

    End Sub

    Private Sub txt_IcmSubProd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_IcmSubProd.GotFocus

        txt_IcmSubProd.SelectAll()

    End Sub

    Private Sub txt_Qtde_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Vlproduto.KeyPress, txt_VlicmsProd.KeyPress, txt_vlOutrosProd.KeyPress, txt_txLucro.KeyPress, txt_alqIpiProd.KeyPress, txt_alqIcmsProd.KeyPress, txt_txfrete.KeyPress, txt_vlSeguroProd.KeyPress, txt_reducao.KeyPress, txt_Qtde.KeyPress, txt_prunit.KeyPress, txt_prtot.KeyPress, txt_PcoSugerido.KeyPress, txt_pcoCusto.KeyPress, txt_IcmSubProd.KeyPress, txt_vlfreteProd.KeyPress, txt_OutrasDesp.KeyPress, txt_vlDescProd.KeyPress, txt_BSubsItem.KeyPress, txt_BcalculoItem.KeyPress, txt_vlIpiProd.KeyPress, txt_alqSubsProd.KeyPress, txt_vlPercDescProd.KeyPress
        'permite só numeros com virgulas
        If _clFunc.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub Frm_MenuCompras_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        _mValidaValores = False
        Try

            If Not IsNothing(_BuscaForn) Or Not _BuscaForn.IsDisposed Then _BuscaForn.Close()
            If Not IsNothing(_BuscaProd) Or Not _BuscaProd.IsDisposed Then _BuscaProd.Close()
            _BuscaForn = Nothing : _BuscaProd = Nothing

        Catch ex As Exception
        End Try



    End Sub

    Private Sub txt_Qtde_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlPercDescProd.LostFocus, txt_vlIpiProd.LostFocus, txt_VlicmsProd.LostFocus, txt_vlDescProd.LostFocus, txt_vlOutrosProd.LostFocus, txt_txLucro.LostFocus, txt_alqIpiProd.LostFocus, txt_alqIcmsProd.LostFocus, txt_txfrete.LostFocus, txt_vlSeguroProd.LostFocus, txt_reducao.LostFocus, txt_prunit.LostFocus, txt_prtot.LostFocus, txt_PcoSugerido.LostFocus, txt_pcoCusto.LostFocus, txt_IcmSubProd.LostFocus, txt_vlfreteProd.LostFocus, txt_OutrasDesp.LostFocus, txt_BSubsItem.LostFocus, txt_BcalculoItem.LostFocus, txt_alqSubsProd.LostFocus

        Try
            verifValores(sender)

        Catch ex As Exception
        End Try



    End Sub

    Private Shared Sub verifValoresExtracted(ByVal txt_box As TextBox)

        Try

            Dim mtxt_box As New TextBox
            mtxt_box = txt_box
            If mtxt_box.Text.Equals("") Then

                mtxt_box.Text = Format(0.0, "##,##0.00")

            Else

                If Not IsNumeric(mtxt_box.Text) Then

                    MsgBox("valor inválido para campo numerico", MsgBoxStyle.Exclamation)
                    mtxt_box.Focus()

                End If
            End If

            mtxt_box = Nothing

        Catch ex As Exception
        End Try



    End Sub

    Private Sub verifValores(ByVal txt_box As TextBox)

        If _mValidaValores = True Then verifValoresExtracted(txt_box)

    End Sub

    Private Sub txt_Qtde_LeaveExtracted()

        If IsNumeric(Me.txt_Qtde.Text) Then

            If CInt(Me.txt_Qtde.Text) <= _valorZERO Then

                lbl_mensageniten.Text = "Valor do campo deve ser maior que ZERO !" : Return

            End If
            Me.txt_Qtde.Text = Format(CDec(Me.txt_Qtde.Text), "###,##0.00")

        Else
            lbl_mensageniten.Text = "valor inválido para campo numerico !" : Return

        End If
        lbl_mensageniten.Text = ""



    End Sub

    Private Sub txt_Qtde_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Qtde.Leave

        If _mValidaValores = True Then txt_Qtde_LeaveExtracted()

    End Sub

    Private Sub txt_Vlproduto_LeaveExtracted()

        If IsNumeric(Me.txt_Vlproduto.Text) Then

            If CDec(Me.txt_Vlproduto.Text) <= _valorZERO Then

                lbl_mensageniten.Text = "Valor do Produto deve ser maior que ZERO !" : Return

            Else
                Try

                    Dim vlprod, qtdeProd As Double
                    vlprod = CDec(Me.txt_Vlproduto.Text) : qtdeProd = CDec(Me.txt_Qtde.Text)

                    Me.txt_prtot.Text = Format(Convert.ToDouble(Round(((CDec(Me.txt_Vlproduto.Text) * CDec(Me.txt_Qtde.Text)) + _
                                        CDec(Me.txt_IcmSubProd.Text) + CDec(Me.txt_vlIpiProd.Text) + CDec(Me.txt_vlfreteProd.Text) + _
                                        CDec(Me.txt_vlSeguroProd.Text) - CDec(Me.txt_vlDescProd.Text)), 2)), "##,##0.00")

                    Me.txt_prunit.Text = Format(Convert.ToDouble(Round((CDec(Me.txt_prtot.Text) / CDec(Me.txt_Qtde.Text)), 3)), "##,##0.000")
                    vlprod = Nothing : qtdeProd = Nothing

                Catch ex As Exception
                End Try

            End If
            Me.txt_Vlproduto.Text = Format(CDec(Me.txt_Vlproduto.Text), "###,##0.000")

        Else
            lbl_mensageniten.Text = "valor inválido para campo Valor do Produto !" : Return

        End If
        lbl_mensageniten.Text = ""



    End Sub

    Private Sub txt_Vlproduto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Vlproduto.Leave

        If _mValidaValores = True Then txt_Vlproduto_LeaveExtracted()

    End Sub

    Private Sub txt_vlDescProd_LeaveExtracted()

        Me.txt_prunit.Text = Format(Convert.ToDouble(Round(((CDec(Me.txt_prtot.Text) - CDec(Me.txt_vlDescProd.Text)) / CDec(Me.txt_Qtde.Text)), 3)), "##,##0.000")
        Me.txt_vlDescProd.Text = Format(CDec(Me.txt_vlDescProd.Text), "###,##0.00")
        Me.txt_BcalculoItem.Text = Format(CDec(Me.txt_BcalculoItem.Text), "###,##0.00")
        Me.txt_alqIcmsProd.Text = Format(CDec(Me.txt_alqIcmsProd.Text), "###,##0.00")
        Me.txt_VlicmsProd.Text = Format(CDec(Me.txt_VlicmsProd.Text), "###,##0.00")
        Me.txt_BSubsItem.Text = Format(CDec(Me.txt_BSubsItem.Text), "###,##0.00")
        Me.txt_IcmSubProd.Text = Format(CDec(Me.txt_IcmSubProd.Text), "###,##0.00")
        Me.txt_alqIpiProd.Text = Format(CDec(Me.txt_alqIpiProd.Text), "###,##0.00")
        Me.txt_vlfreteProd.Text = Format(CDec(Me.txt_vlfreteProd.Text), "###,##0.00")
        Me.txt_vlSeguroProd.Text = Format(CDec(Me.txt_vlSeguroProd.Text), "###,##0.00")
        Me.txt_OutrasDesp.Text = Format(CDec(Me.txt_OutrasDesp.Text), "###,##0.00")
        Me.txt_vlOutrosProd.Text = Format(CDec(Me.txt_vlOutrosProd.Text), "###,##0.00")
        Me.txt_pcoCusto.Text = Format(CDec(Me.txt_pcoCusto.Text), "###,##0.00")
        Me.txt_txLucro.Text = Format(CDec(Me.txt_txLucro.Text), "###,##0.00")
        Me.txt_PcoSugerido.Text = Format(CDec(Me.txt_PcoSugerido.Text), "###,##0.00")
        Me.txt_reducao.Text = Format(CDec(Me.txt_reducao.Text), "###,##0.000")



    End Sub

    Private Sub txt_vlDescProd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlSeguroProd.Leave, txt_vlPercDescProd.Leave, txt_VlicmsProd.Leave, txt_vlfreteProd.Leave, txt_vlDescProd.Leave, txt_vlOutrosProd.Leave, txt_txLucro.Leave, txt_alqIpiProd.Leave, txt_alqIcmsProd.Leave, txt_txfrete.Leave, txt_reducao.Leave, txt_prunit.Leave, txt_prtot.Leave, txt_PcoSugerido.Leave, txt_pcoCusto.Leave, txt_IcmSubProd.Leave, txt_OutrasDesp.Leave, txt_BSubsItem.Leave

        Try
            txt_vlDescProd_LeaveExtracted()
        Catch ex As Exception
        End Try


    End Sub

    Private Sub txt_vlIpiProd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlIpiProd.Leave

        Try

            Me.txt_prunit.Text = Format(Convert.ToDouble(Round(((CDec(Me.txt_prtot.Text) - CDec(Me.txt_vlDescProd.Text)) / CDec(Me.txt_Qtde.Text)), 3)), "##,##0.000")
            If CDbl(Me.txt_alqIpiProd.Text) > _valorZERO AndAlso CDbl(Me.txt_vlIpiProd.Text) <= _valorZERO Then

                lbl_mensageniten.Text = "Aliquota do IPI maior que ZERO, informar valor do IPI maior que ZERO !"
                Return

            End If
            Me.txt_vlIpiProd.Text = Format(CDec(Me.txt_vlIpiProd.Text), "###,##0.00")

        Catch ex As Exception
        End Try
        lbl_mensageniten.Text = ""



    End Sub

    Private Sub cbo_local_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_local.GotFocus

        If Not (Me.cbo_local.DroppedDown) Then Me.cbo_local.DroppedDown = True

    End Sub

    Private Sub cbo_nfcfop_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_nfcfop.GotFocus

        If Not (Me.cbo_nfcfop.DroppedDown) AndAlso (Me.cbo_nfcfop.SelectedIndex < _valorZERO) Then Me.cbo_nfcfop.DroppedDown = True ' 

    End Sub

    Private Sub cbo_especie_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_especie.GotFocus

        If Not (Me.cbo_especie.DroppedDown) Then Me.cbo_especie.DroppedDown = True

    End Sub

    Private Sub cbo_cstProd_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cstProd.GotFocus

        If Not (Me.cbo_cstProd.DroppedDown) Then Me.cbo_cstProd.DroppedDown = True

    End Sub

    Private Function verifReducaoBsCalc(ByRef shouldReturn As Boolean) As Boolean

        shouldReturn = False
        If CDbl(txt_BcalculoItem.Text) > _valorZERO Then

            Dim mNewBsCalc As Double = _valorZERO, mNewPercReduz As Double = _valorZERO
            Dim mDiferBsCalc As Double = _valorZERO
            mNewBsCalc = (CDbl(txt_BcalculoItem.Text) + CDbl(txt_vlDescProd.Text)) - CDbl(txt_vlfreteProd.Text)

            If mNewBsCalc < CDbl(txt_prtot.Text) Then

                mDiferBsCalc = CDbl(txt_prtot.Text) - mNewBsCalc
                mNewPercReduz = Round(((mDiferBsCalc * 100) / CDbl(txt_prtot.Text)), 5)

                If CDbl(txt_reducao.Text) <= _valorZERO Then

                    If MessageBox.Show("Atribua um percentual de redução ! Deseja fazer isso automaticamente agora?", _
                                "Percentual de Reducão", MessageBoxButtons.YesNo, MessageBoxIcon.Information, _
                                 MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        txt_reducao.Text = Format(mNewPercReduz, "###,##0.00000")

                    Else
                        txt_reducao.Focus() : txt_reducao.SelectAll() : shouldReturn = True

                    End If

                Else

                    If Abs(mNewPercReduz - CDbl(txt_reducao.Text)) > 1 Then

                        If MessageBox.Show("Verifique o Percentual de redução ! Deseja atribuir o percentual automaticamente agora?", _
                                "Percentual de Reducão", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then

                            txt_reducao.Text = Format(mNewPercReduz, "###,##0.00000")

                        Else
                            txt_reducao.Focus() : txt_reducao.SelectAll() : shouldReturn = True

                        End If
                    End If


                End If
            End If
        End If



        Return shouldReturn
    End Function

    Private Function verifValoresItens(ByRef ShouldReturn As Boolean) As Boolean

        'Verifica o campo txt_Qtde (Quantidade do Produto)
        If IsNumeric(Me.txt_Qtde.Text) Then

            If CInt(Me.txt_Qtde.Text) <= _valorZERO Then

                MsgBox("Valor do campo deve ser maior que ZERO", MsgBoxStyle.Exclamation)
                Me.txt_Qtde.Focus() : Me.txt_Qtde.SelectAll() : ShouldReturn = True

            End If
        Else

            MsgBox("valor inválido para campo numerico", MsgBoxStyle.Exclamation)
            Me.txt_Qtde.Focus() : Me.txt_Qtde.SelectAll() : ShouldReturn = True
        End If

        'Verifica o campo txt_Vlproduto (Valor do Produto)
        If IsNumeric(Me.txt_Vlproduto.Text) Then

            If CDec(Me.txt_Vlproduto.Text) <= _valorZERO Then

                MsgBox("Valor do Produto deve ser maior que ZERO", MsgBoxStyle.Exclamation)
                Me.txt_Vlproduto.Focus() : Me.txt_Vlproduto.SelectAll() : ShouldReturn = True

            End If
        Else

            MsgBox("valor inválido para campo Valor do Produto", MsgBoxStyle.Exclamation)
            Me.txt_Vlproduto.Focus() : Me.txt_Vlproduto.SelectAll() : ShouldReturn = True
        End If

        'Verifica o campo txt_alqIpiProd (Aliquota do IPI do Produto)
        If (CDbl(Me.txt_alqIpiProd.Text) > _valorZERO) AndAlso (CDbl(Me.txt_vlIpiProd.Text) <= _valorZERO) Then

            MsgBox("Aliquota do IPI maior que ZERO, informar valor do IPI maior que ZERO", MsgBoxStyle.Exclamation)
            Me.txt_vlIpiProd.Focus() : Me.txt_vlIpiProd.SelectAll() : ShouldReturn = True

        End If



        Return ShouldReturn
    End Function

    Private Sub btn_itinclui_ClickExtracted()

        Dim shouldReturn As Boolean = False : verifReducaoBsCalc(shouldReturn) : If shouldReturn Then Return
        verifValoresItens(shouldReturn) : If shouldReturn Then Return
        If dtg_itensCompras.Columns.Count = _valorZERO Then addColunasItens()
        Me.addDataGridItem() : zeraValoresItemNF() : Me.atualizSomaVlItens() : Me.txt_codProd.Focus()


    End Sub

    Private Sub btn_itinclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_itinclui.Click

        btn_itinclui_ClickExtracted()

    End Sub

    Private Sub AdicionandoColunasNessaOrdem()

        Me.dtg_itensCompras.Columns.Add("codProd", "CodProd")
        Me.dtg_itensCompras.Columns.Add("nomeProd", "NomeProd")
        Me.dtg_itensCompras.Columns.Add("ncmProd", "NcmProd")
        Me.dtg_itensCompras.Columns.Add("cfopProd", "CfopProd")
        Me.dtg_itensCompras.Columns.Add("cstProd", "CstProd")
        Me.dtg_itensCompras.Columns.Add("csosnProd", "CSOSN")
        Me.dtg_itensCompras.Columns.Add("qtdProd", "QtdProd")
        Me.dtg_itensCompras.Columns.Add("vlrProd", "VlrProd") '7
        Me.dtg_itensCompras.Columns.Add("percDescProd", "PercDescProd")
        Me.dtg_itensCompras.Columns.Add("vlrDescProd", "VlrDescProd")
        Me.dtg_itensCompras.Columns.Add("vlrTotProd", "VlrTotProd")
        Me.dtg_itensCompras.Columns.Add("vlUnitComprProd", "VlUnitComprProd")
        Me.dtg_itensCompras.Columns.Add("vlUnitProdNF", "VlUnitComprProdNF")
        Me.dtg_itensCompras.Columns.Add("percReducProd", "PercReducProd")
        Me.dtg_itensCompras.Columns.Add("bcIcmsProd", "BcIcmsProd") '14
        Me.dtg_itensCompras.Columns.Add("alqIcmsProd", "AlqIcmsProd")
        Me.dtg_itensCompras.Columns.Add("vlrIcmsProd", "VlrIcmsProd")
        Me.dtg_itensCompras.Columns.Add("bcSubsProd", "BcSubsProd")
        Me.dtg_itensCompras.Columns.Add("alqSubsProd", "AlqSubsProd")
        Me.dtg_itensCompras.Columns.Add("vlrSubsProd", "VlrSubsProd")
        Me.dtg_itensCompras.Columns.Add("alqIPIProd", "alqIPIProd")
        Me.dtg_itensCompras.Columns.Add("vlrIPIProd", "VlrIPIProd") '21
        Me.dtg_itensCompras.Columns.Add("percFTProd", "PercFTProd")
        Me.dtg_itensCompras.Columns.Add("vlrFTProd", "VlrFTProd")
        Me.dtg_itensCompras.Columns.Add("vlrSegProd", "VlrSegProd")
        Me.dtg_itensCompras.Columns.Add("vlrDespProd", "VlrDespProd")
        Me.dtg_itensCompras.Columns.Add("vlrOutrosProd", "VlrOutrosProd")
        Me.dtg_itensCompras.Columns.Add("vlrPrCustProd", "VlrPrCustProd")
        Me.dtg_itensCompras.Columns.Add("vlrPercLucrProd", "VlrPercLucrProd") '28
        Me.dtg_itensCompras.Columns.Add("vlrPrSurgProd", "VlrPrSurgProd")
        Me.dtg_itensCompras.Columns.Add("undIten", "UND")
        Me.dtg_itensCompras.Columns.Add("idItem", "IdItem")



    End Sub

    Private Sub PersonalizandoColunas()

        Me.dtg_itensCompras.Columns(_valorZERO).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(10).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(11).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(12).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(13).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(14).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(15).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(16).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(17).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(18).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(19).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(20).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(21).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(22).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(23).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(24).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(25).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(26).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(27).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(28).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(29).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(30).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(31).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtg_itensCompras.Columns(31).Visible = False



    End Sub

    Private Sub addColunasItens()

        'Adicionando Colunas, nessa ordem...
        AdicionandoColunasNessaOrdem()
        'Personalizando Colunas
        PersonalizandoColunas()


    End Sub

    Private Sub addDataGridItemExtracted(ByRef mCodProd As String, ByRef mNomeProd As String, ByRef mNcmProd As String, ByRef mCfopProd As String, ByRef mCstProd As String, ByRef mCsosnProd As String, ByRef mQtdeProd As Decimal, ByRef mVlProd As Decimal, ByRef mVlPercDesc As Decimal, ByRef mVlDesc As Decimal, ByRef mVlTotProd As Decimal, ByRef mVlUnitComprProd As Decimal, ByRef mVlPercRedProd As Decimal, ByRef mVlBcIcmsProd As Decimal, ByRef mVlAlqIcmsProd As Decimal, ByRef mVlIcmsProd As Decimal, ByRef mBcSubsProd As Decimal, ByRef mVlAlqSubsProd As Decimal, ByRef mVlSubsProd As Decimal, ByRef mVlAlqIpiProd As Decimal, ByRef mVlIpiProd As Decimal, ByRef mVlPercFretProd As Decimal, ByRef mVlFretProd As Decimal, ByRef mVlSeguroProd As Decimal, ByRef mVlDespProd As Decimal, ByRef mVlOutrosProd As Decimal, ByRef mVlCustoProd As Decimal, ByRef mVlPercLucroProd As Decimal, ByRef mVlSurgeridoProd As Decimal, ByRef mVlUnitProdNF As Decimal)

        mCodProd = Me.txt_codProd.Text : mNomeProd = Me.txt_nomeProd.Text : mNcmProd = Me.txt_ncm.Text
        mCfopProd = Mid(Me.cbo_itcfop.Text, 1, 1) & Mid(Me.cbo_itcfop.Text, 3, 3)
        mCstProd = Mid(Me.cbo_cstProd.Text, 1, 2) : mCsosnProd = Me.txt_csosn.Text
        mQtdeProd = Me.txt_Qtde.Text : mVlProd = Me.txt_Vlproduto.Text : mVlPercDesc = Me.txt_vlPercDescProd.Text
        mVlDesc = Me.txt_vlDescProd.Text : mVlTotProd = Me.txt_prtot.Text : mVlUnitComprProd = Me.txt_prunit.Text
        mVlUnitProdNF = Me.txt_prunit.Text : mVlPercRedProd = Me.txt_reducao.Text
        mVlBcIcmsProd = Me.txt_BcalculoItem.Text : mVlAlqIcmsProd = Me.txt_alqIcmsProd.Text
        mVlIcmsProd = Me.txt_VlicmsProd.Text : mBcSubsProd = Me.txt_BSubsItem.Text
        mVlAlqSubsProd = Me.txt_alqSubsProd.Text : mVlSubsProd = Me.txt_IcmSubProd.Text
        mVlAlqIpiProd = Me.txt_alqIpiProd.Text : mVlIpiProd = Me.txt_vlIpiProd.Text
        mVlPercFretProd = Me.txt_txfrete.Text : mVlFretProd = Me.txt_vlfreteProd.Text
        mVlSeguroProd = Me.txt_vlSeguroProd.Text : mVlDespProd = Me.txt_OutrasDesp.Text
        mVlOutrosProd = Me.txt_vlOutrosProd.Text : mVlCustoProd = Me.txt_pcoCusto.Text
        mVlPercLucroProd = Me.txt_txLucro.Text : mVlSurgeridoProd = Me.txt_PcoSugerido.Text



    End Sub

    Private Sub addDataGridItem()

        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd As String
        mCodProd = "" : mNomeProd = "" : mNcmProd = "" : mCfopProd = "" : mCstProd = "" : mCsosnProd = ""

        Dim mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd As Decimal
        Dim mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd As Decimal
        Dim mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd As Decimal
        Dim mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd As Decimal
        Dim mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF As Decimal

        addDataGridItemExtracted(mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd, mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd, mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd, mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd, mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd, mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF)


        Try

            'Se o Item do momento for um iten que esta sendo editado...
            If _idItemEditado <= _valorZERO Then

                _idDtg_Itens += 1
                Dim mlinha As String() = {mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd, mQtdeProd, mVlProd, _
                                          mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd, mVlUnitProdNF, mVlPercRedProd, _
                                          mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd, mVlAlqSubsProd, mVlSubsProd, _
                                          mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd, mVlFretProd, mVlSeguroProd, mVlDespProd, _
                                          mVlOutrosProd, mVlCustoProd, mVlPercLucroProd, mVlSurgeridoProd, mbUndProd}

                'Adicionando Linha
                Me.dtg_itensCompras.Rows.Add(mlinha) : mlinha = Nothing

            ElseIf _idItemEditado > _valorZERO Then

                _idItemEditado = (_idItemEditado - 1)
                Dim mlinha As String() = {mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd, mQtdeProd, mVlProd, _
                                          mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd, mVlUnitProdNF, mVlPercRedProd, _
                                          mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd, mVlAlqSubsProd, mVlSubsProd, _
                                          mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd, mVlFretProd, mVlSeguroProd, mVlDespProd, _
                                          mVlOutrosProd, mVlCustoProd, mVlPercLucroProd, mVlSurgeridoProd, mbUndProd}

                'Adicionando Linha
                Me.dtg_itensCompras.Rows(_idItemEditado).SetValues(mlinha) : Me.dtg_itensCompras.Refresh()
                mlinha = Nothing

            End If


            'LIMPA OBJETOS DA MEMÓRIA...
            mCodProd = Nothing : mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing
            mCstProd = Nothing : mCsosnProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing
            mVlPercDesc = Nothing : mVlDesc = Nothing : mVlTotProd = Nothing : mVlUnitComprProd = Nothing
            mVlUnitProdNF = Nothing : mVlPercRedProd = Nothing : mVlBcIcmsProd = Nothing : mVlAlqIcmsProd = Nothing
            mVlIcmsProd = Nothing : mBcSubsProd = Nothing : mVlAlqSubsProd = Nothing : mVlSubsProd = Nothing
            mVlAlqIpiProd = Nothing : mVlIpiProd = Nothing : mVlPercFretProd = Nothing : mVlFretProd = Nothing
            mVlSeguroProd = Nothing : mVlDespProd = Nothing : mVlOutrosProd = Nothing : mVlCustoProd = Nothing
            mVlPercLucroProd = Nothing : mVlSurgeridoProd = Nothing

        Catch ex As Exception
            MsgBox("Não deu ERRO ao Incluir este Item " & ex.Message, MsgBoxStyle.Exclamation)
        End Try



    End Sub

    Private Sub DeleteDataGridItem()

        Try

            If Me.dtg_itensCompras.Enabled = True Then

                'Remove Linha
                Me.dtg_itensCompras.Rows.Remove(Me.dtg_itensCompras.CurrentRow)
                Me.dtg_itensCompras.Refresh() : Me.atualizSomaVlItens()

            End If

        Catch ex As Exception
            MsgBox("Deu ERRO ao Deletar este Item " & ex.Message, MsgBoxStyle.Exclamation)
        End Try



    End Sub

    Private Sub btn_itexclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_itexclui.Click

        If MessageBox.Show("Deseja realmente Deletar esse Item?", "Genov", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.DeleteDataGridItem()

        End If



    End Sub

    Private Function validTotItens() As Boolean
        'Se o total do valor bruto dos produtos for diferente do total do valor brutos dos produtos 
        'informado na nota
        If mNF_Cfop.Substring(2, 3).Equals("910") = False AndAlso mNF_Cfop.Substring(2, 3).Equals("949") = False Then

            If CDec(Me.lbl_VlBrutoItens.Text) <> CDec(Me.txt_nftprodutos.Text) Then

                MsgBox("Total dos Valores bruto dos Produtos diferente do valor Informado no registro da Nota", MsgBoxStyle.Exclamation)
                Return False

            End If
        End If

        If CDec(Me.lbl_VlBcIcmsItens.Text) <> CDec(Me.txt_nfbscalculo.Text) Then

            MsgBox("Total da Base de Calculo do ICMS dos Produtos diferente do valor Informado no registro da Nota", MsgBoxStyle.Exclamation)
            Return False

        End If

        If CDec(Me.lbl_VlIcmsItens.Text) <> CDec(Me.txt_nfvlicm.Text) Then

            MsgBox("Total do ICMS dos Produtos diferente do valor Informado no registro da Nota", MsgBoxStyle.Exclamation)
            Return False

        End If

        If CDec(Me.lbl_VlBcSubsItens.Text) <> CDec(Me.txt_nfbasesub.Text) Then

            MsgBox("Total a Base de Calculo do IcmsSubstituto dos Produtos diferente do valor Informado no registro da Nota", MsgBoxStyle.Exclamation)
            Return False

        End If

        If CDec(Me.lbl_VlSubs.Text) <> CDec(Me.txt_nficmsub.Text) Then

            MsgBox("Total do IcmsSubstituto dos Produtos diferente do valor Informado no registro da Nota", MsgBoxStyle.Exclamation)
            Return False

        End If

        If CDec(Me.lbl_VlIpiItens.Text) <> CDec(Me.txt_nfvlipi.Text) Then

            MsgBox("Total do IPI nos Produtos diferente do valor Informado no registro da Nota!", MsgBoxStyle.Exclamation)
            Return False

        End If

        If CDec(Me.lbl_VlFretItens.Text) <> CDec(Me.txt_nfvlfrete.Text) Then
            MsgBox("Total do FRETE dos Produtos diferente do valor Informado no registro da Nota", MsgBoxStyle.Exclamation)
            Return False
        End If

        If CDec(Me.lbl_VlSegItens.Text) <> CDec(Me.txt_nfVlSeguro.Text) Then

            MsgBox("Total do SEGURO dos Produtos diferente do valor Informado no registro da Nota", MsgBoxStyle.Exclamation)
            Return False

        End If

        If CDec(Me.lbl_VlDescItens.Text) <> CDec(Me.txt_nfDesconto.Text) Then

            MsgBox("Total do Desconto dos Produtos diferente do valor Informado no registro da Nota", MsgBoxStyle.Exclamation)
            Return False

        End If

        If CDec(Me.lbl_vlOutrasDesp.Text) <> CDec(Me.txt_nfOutrasDesp.Text) Then

            MsgBox("Total de Outras Despesas dos Produtos diferente do valor Informado no registro da Nota", MsgBoxStyle.Exclamation)
            Return False

        End If

        If CDec(Me.lbl_vlTotalItens.Text) <> CDec(Me.txt_nfvltgeral.Text) Then

            MsgBox("Valor Total dos Produtos diferente do valor Total Informado no registro da Nota", MsgBoxStyle.Exclamation)
            Return False

        End If



        Return True
    End Function

    Private Function verificaItem() As Boolean

        Dim ItemOK As Boolean = True
        'verifica se já existem o Item corrente na Nota
        For Each row As DataGridViewRow In Me.dtg_itensCompras.Rows

            If Not row.IsNewRow Then

                If row.Cells(_valorZERO).Value = Me.txt_codProd.Text Then

                    MsgBox("Produto já existe na nota", MsgBoxStyle.Exclamation, "ERRO")
                    ItemOK = False : Exit For

                End If
            End If
        Next



        Return ItemOK
    End Function

    Private Function ExtractedValidaCodPart(ByRef nfOK As Boolean) As Boolean

        If Me.txt_codPart.Text.Equals("") Then

            nfOK = False : MsgBox("Informe um Fornecedor para a NF", MsgBoxStyle.Exclamation)
            Me.txt_codPart.Focus() : Return nfOK

        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaCboLocal(ByRef nfOK As Boolean) As Boolean

        If Me.cbo_local.SelectedIndex < _valorZERO Then

            nfOK = False : MsgBox("Informe o local da entrada da nota", MsgBoxStyle.Exclamation)
            Me.cbo_local.Focus() : Return nfOK

        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfNumero(ByRef nfOK As Boolean) As Boolean

        If (Me.txt_nfnumero.Text = "") OrElse (CInt(Me.txt_nfnumero.Text) = _valorZERO) Then

            nfOK = False : MsgBox("Por favor, informe o numero da nota fiscal", MsgBoxStyle.Exclamation)
            Me.txt_nfnumero.Focus() : Return nfOK

        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfSerie(ByRef nfOK As Boolean) As Boolean

        Try

            If verifNotaExist(Me.txt_codPart.Text, Me.txt_nfnumero.Text, Me.txt_nfserie.Text) Then

                nfOK = False : MsgBox("Essa Nota já existe no banco de dados", MsgBoxStyle.Exclamation)
                Return nfOK

            End If


            If Me.txt_nfserie.Text.Equals("") Then

                nfOK = False : MsgBox("Informe a Serie da Nota por favor", MsgBoxStyle.Exclamation)
                Me.txt_nfserie.Focus() : Me.txt_nfserie.SelectAll() : Return nfOK

            End If
        Catch ex As Exception
        End Try



        Return nfOK
    End Function

    Private Function ExtractedValidaEspecie(ByRef nfOK As Boolean) As Boolean

        If cbo_especie.SelectedIndex < 0 Then

            nfOK = False : MsgBox("Selecione uma Especie de Nota", MsgBoxStyle.Exclamation)
            Me.cbo_especie.Focus() : Me.cbo_especie.SelectAll() : Me.btn_registrar.Enabled = True
            Return nfOK

        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfCfop(ByRef nfOK As Boolean) As Boolean

        If cbo_nfcfop.SelectedIndex < 0 Then

            nfOK = False : MsgBox("Selecione um CFOP padrão para a Nota", MsgBoxStyle.Exclamation)
            Me.cbo_nfcfop.Focus() : Return nfOK

        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfTprodutos(ByVal nfOK As Boolean) As Boolean

        If IsNumeric(Me.txt_nftprodutos.Text) Then

            'Se a nota não for Frete
            If Not Me.cbo_especie.Text.Equals("FT") AndAlso Not Me.cbo_especie.Text.Equals("FTE") Then

                If CDec(Me.txt_nftprodutos.Text) <= _valorZERO Then

                    nfOK = False : MsgBox("Total dos Produtos na nota deve ser maior que ZERO", MsgBoxStyle.Exclamation)
                    Me.txt_nftprodutos.Focus() : Me.txt_nftprodutos.SelectAll() : Return nfOK

                End If
            End If
            Me.txt_nftprodutos.Text = Format(CDec(Me.txt_nftprodutos.Text), "###,##0.00")

        Else

            nfOK = False : MsgBox("Numero inválido para o Total dos Produtos", MsgBoxStyle.Exclamation)
            Me.txt_nftprodutos.Focus() : Me.txt_nftprodutos.SelectAll() : Return nfOK

        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfBsCalculo(ByRef nfOK As Boolean) As Boolean

        If IsNumeric(Me.txt_nfbscalculo.Text) Then

            If mNF_Cfop.Substring(2, 3).Equals("910") OrElse mNF_Cfop.Substring(2, 3).Equals("403") _
            OrElse mNF_Cfop.Substring(2, 3).Equals("908") OrElse mNF_Cfop.Substring(2, 3).Equals("949") Then

                If CDec(Me.txt_nfbscalculo.Text) <> _valorZERO Then

                    nfOK = False : MsgBox("Atenção ! Base de Cálculo Inválida p/ CFOP", MsgBoxStyle.Exclamation)
                    Me.txt_nfbscalculo.Focus() : Me.txt_nfbscalculo.SelectAll() : Return nfOK

                End If
            End If
            Me.txt_nfbscalculo.Text = Format(CDec(Me.txt_nfbscalculo.Text), "###,##0.00")

        Else

            nfOK = False : MsgBox("Atenção ! Base de Cálculo Inválida", MsgBoxStyle.Exclamation)
            Me.txt_nfbscalculo.Focus() : Me.txt_nfbscalculo.SelectAll() : Return nfOK

        End If
        Me.txt_nfbscalculo.Text = Format(CDec(Me.txt_nfbscalculo.Text), "###,##0.00")



        Return nfOK
    End Function

    Private Function ExtractedValidaNfalqicm(ByVal nfOK As Boolean) As Boolean

        Dim micm As Double = 0
        If IsNumeric(Me.txt_nfalqicm.Text) Then

            If CDec(Me.txt_nfalqicm.Text) <> _valorZERO Then
                micm = ((Convert.ToDouble(Me.txt_nfbscalculo.Text) * Convert.ToDouble(Me.txt_nfalqicm.Text)) / 100)
                micm = Round(micm, 2) : Me.txt_nfvlicm.Text = Format(CDbl(micm), "###,##0.00")

                If mNF_Cfop.Substring(2, 3).Equals("403") OrElse mNF_Cfop.Substring(2, 3).Equals("910") _
                OrElse mNF_Cfop.Substring(2, 3).Equals("908") OrElse mNF_Cfop.Substring(2, 3).Equals("949") Then

                    nfOK = False
                    MsgBox("Atenção ! CFOP Selecionado não necessita de Aliquota do ICMS !", MsgBoxStyle.Exclamation)
                    Me.txt_nfalqicm.Focus() : Me.txt_nfalqicm.SelectAll() : Return nfOK

                End If

            Else

                Me.txt_nfvlicm.Text = "0,00"
            End If
            Me.txt_nfalqicm.Text = Format(CDbl(txt_nfalqicm.Text), "##0.00")

        Else

            nfOK = False : MsgBox("Valor da Aliquota do Icms na Nota é inválido", MsgBoxStyle.Exclamation)
            Me.txt_nfalqicm.Focus() : Me.txt_nfalqicm.SelectAll() : Return nfOK

        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfVlIcm(ByVal nfOK As Boolean) As Boolean

        If IsNumeric(Me.txt_nfvlicm.Text) Then

            If CDec(Me.txt_nfvlicm.Text) > _valorZERO Then

                If IsNumeric(Me.txt_nfalqicm.Text) Then

                    If CDec(Me.txt_nfalqicm.Text) <= _valorZERO Then

                        nfOK = False : MsgBox("Atenção ! Informar Aliquota do Icms", MsgBoxStyle.Exclamation)
                        Me.txt_nfalqicm.Focus() : Me.txt_nfalqicm.SelectAll() : Return nfOK

                    End If
                End If
            End If

        Else

            nfOK = False : MsgBox("Informe um numero válido para o Valor do Icms", MsgBoxStyle.Exclamation)
            Me.txt_nfvlicm.Focus() : Me.txt_nfvlicm.SelectAll() : Return nfOK
        End If


        If CDec(Me.txt_nfvlicm.Text) = _valorZERO Then

            If CDec(Me.txt_nfalqicm.Text) <> _valorZERO Then

                nfOK = False : MsgBox("Atenção ! Informar Valor do Icms", MsgBoxStyle.Exclamation)
                Me.txt_nfvlicm.Focus() : Me.txt_nfvlicm.SelectAll() : Return nfOK
            End If
        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfBaseSub(ByVal nfOK As Boolean) As Boolean

        If mNF_Cfop.Substring(2, 3).Equals("403") Then

            If IsNumeric(Me.txt_nfbasesub.Text) Then

                If CDbl(txt_nficmsub.Text) > _valorZERO AndAlso CDec(Me.txt_nfbasesub.Text) <= _valorZERO Then

                    nfOK = False
                    MsgBox("Atenção ! Favor Informar Base de Cálculo da Substituição", MsgBoxStyle.Exclamation)
                    Me.txt_nfbasesub.Focus() : Me.txt_nfbasesub.SelectAll() : Return nfOK

                End If
                Me.txt_nfbasesub.Text = Format(CDbl(txt_nfbasesub.Text), "##0.00")

            End If
        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfIcmSub(ByVal nfOK As Boolean) As Boolean

        If mNF_Cfop.Substring(2, 3).Equals("403") Then

            If IsNumeric(Me.txt_nficmsub.Text) Then

                Dim mtgeral As Double
                Try
                    mtgeral = ((CDbl(txt_nftprodutos.Text) + CDbl(txt_nficmsub.Text) + CDbl(txt_nfvlipi.Text) + CDbl(txt_nfVlSeguro.Text) + _
                    CDbl(txt_nfvlfrete.Text) + CDbl(txt_nfOutrasDesp.Text)) - CDbl(txt_nfDesconto.Text))
                Catch ex As Exception
                End Try

                If mtgeral <> CDbl(txt_nfvltgeral.Text) Then

                    If CDec(Me.txt_nficmsub.Text) <= _valorZERO Then

                        nfOK = False
                        MsgBox("Atenção ! Favor Informar o Valor ICMS SUBSTITUTO", MsgBoxStyle.Exclamation)
                        Me.txt_nficmsub.Focus() : Me.txt_nficmsub.SelectAll() : Return nfOK

                    End If
                End If
                mtgeral = Nothing

            Else

                nfOK = False : MsgBox("Numero inválido para Valor de ICMS SUBSTITUTO", MsgBoxStyle.Exclamation)
                Me.txt_nficmsub.Focus() : Me.txt_nficmsub.SelectAll() : Return nfOK
            End If
        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfAlqIpi(ByVal nfOK As Boolean) As Boolean

        Try
            If Not IsNumeric(Me.txt_nfalqipi.Text) Then

                nfOK = False
                MsgBox("Valor da Aliquota do IPI na Nota é inválido", MsgBoxStyle.Exclamation)
                Me.txt_nfalqipi.Focus() : Me.txt_nfalqipi.SelectAll() : Return nfOK

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try



        Return nfOK
    End Function

    Private Function ExtractedValidaNfVlIpi(ByRef nfOK As Boolean) As Boolean

        If IsNumeric(Me.txt_nfvlipi.Text) Then

            If CDec(Me.txt_nfvlipi.Text) <> _valorZERO AndAlso CDec(Me.txt_nfalqipi.Text) = _valorZERO Then

                nfOK = False
                MsgBox("Atenção ! Informar Aliquota do IPI para um valor do IPI diferente de ZERO", MsgBoxStyle.Exclamation)
                Me.txt_nfalqipi.Focus() : Return nfOK

            End If

            If CDec(Me.txt_nfvlipi.Text) = _valorZERO AndAlso CDec(Me.txt_nfalqipi.Text) <> _valorZERO Then

                nfOK = False
                MsgBox("Atenção ! Informar Valor do IPI para uma Aliquota diferente de ZERO", MsgBoxStyle.Exclamation)
                Me.txt_nfalqipi.Focus() : Return nfOK

            End If
            Me.txt_nfvlipi.Text = Format(CDec(Me.txt_nfvlipi.Text), "###,##0.00")

        Else

            nfOK = False : MsgBox("Informe um numero válido para o Valor do IPI", MsgBoxStyle.Exclamation)
            Me.txt_nfvlipi.Focus() : Return nfOK
        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfVlFrete(ByRef nfOK As Boolean) As Boolean

        If Not IsNumeric(Me.txt_nfvlfrete.Text) Then

            nfOK = False
            MsgBox("Numero inválido para Valor do Frete", MsgBoxStyle.Exclamation)
            Me.txt_nfvlfrete.Focus() : Return nfOK

        End If


        Return nfOK
    End Function

    Private Function ExtractedValidaNfVlSeguro(ByRef nfOK As Boolean) As Boolean

        If Not IsNumeric(Me.txt_nfVlSeguro.Text) Then

            nfOK = False
            MsgBox("Valor do Seguro é inválido", MsgBoxStyle.Exclamation)
            txt_nfVlSeguro.Focus() : txt_nfVlSeguro.SelectAll() : Return nfOK

        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfVlDesconto(ByRef nfOK As Boolean) As Boolean

        If Not IsNumeric(Me.txt_nfDesconto.Text) Then

            nfOK = False
            MsgBox("Numero inválido para Valor do Desconto", MsgBoxStyle.Exclamation)
            Me.txt_nfDesconto.Focus() : Me.txt_nfDesconto.SelectAll() : Return nfOK

        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfVlOutrasDesp(ByRef nfOK As Boolean) As Boolean

        If Not IsNumeric(Me.txt_nfOutrasDesp.Text) Then

            nfOK = False
            MsgBox("Valor de Outras despesas é inválido", MsgBoxStyle.Exclamation)
            txt_nfOutrasDesp.Focus() : txt_nfOutrasDesp.SelectAll() : Return nfOK

        End If



        Return nfOK
    End Function

    Private Function ExtractedValidaNfVlTgeral(ByRef nfOK As Boolean) As Boolean

        If CDec(Me.txt_nfvltgeral.Text) <= _valorZERO Then

            nfOK = False
            MsgBox("Valor total da nota deve ser maior do que ZERO", MsgBoxStyle.Exclamation)
            txt_nfvltgeral.Focus() : txt_nfvltgeral.SelectAll() : Return nfOK

        Else

            Dim mtgeral As Double
            Try
                mtgeral = (CDbl(txt_nftprodutos.Text) + CDbl(txt_nficmsub.Text) + CDbl(txt_nfvlipi.Text) + CDbl(txt_nfipisento.Text) + _
                CDbl(txt_nfipioutros.Text) + CDbl(txt_nfvlfrete.Text) - CDbl(txt_nfDesconto.Text))

                If CDbl(Me.txt_nfvltgeral.Text) <> mtgeral Then

                    nfOK = False
                    MsgBox("Valor total da nota difere da soma dos TOTAIS", MsgBoxStyle.Exclamation)
                    txt_nfvltgeral.Focus() : txt_nfvltgeral.SelectAll() : Return nfOK

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try

        End If



        Return nfOK
    End Function

    Private Function verificaRegistroNF() As Boolean

        Dim nfOK As Boolean = True

        'extractedValidaCodPart
        If ExtractedValidaCodPart(nfOK) = False Then Return False

        'extractedValidaCboLocal
        If ExtractedValidaCboLocal(nfOK) = False Then Return False

        'extractedValidaNfNumero
        If ExtractedValidaNfNumero(nfOK) = False Then Return False

        'extractedValidaNfSerie
        If ExtractedValidaNfSerie(nfOK) = False Then Return False

        'extractedValidaEspecie
        If ExtractedValidaEspecie(nfOK) = False Then Return False

        'extractedValidaNfCfop
        If ExtractedValidaNfCfop(nfOK) = False Then Return False

        'extractedValidaNfTprodutos
        If ExtractedValidaNfTprodutos(nfOK) = False Then Return False

        'extractedValidaNfBsCalculo
        If ExtractedValidaNfBsCalculo(nfOK) = False Then Return False

        'extractedValidaNfalqicm
        If ExtractedValidaNfalqicm(nfOK) = False Then Return False

        'extractedValidaNfVlIcm
        If ExtractedValidaNfVlIcm(nfOK) = False Then Return False

        'extractedValidaNfIcmSub
        If ExtractedValidaNfIcmSub(nfOK) = False Then Return False

        'extractedValidaNfBaseSub
        If ExtractedValidaNfBaseSub(nfOK) = False Then Return False

        'extractedValidaNfAlqIpi
        If ExtractedValidaNfAlqIpi(nfOK) = False Then Return False

        'extractedValidaNfVlIpi
        If ExtractedValidaNfVlIpi(nfOK) = False Then Return False

        'extractedValidaNfVlFrete
        If ExtractedValidaNfVlFrete(nfOK) = False Then Return False

        'extractedValidaNfVlSeguro
        If ExtractedValidaNfVlSeguro(nfOK) = False Then Return False

        'extractedValidaNfVlDesconto
        If ExtractedValidaNfVlDesconto(nfOK) = False Then Return False

        'extractedValidaNfVlOutrasDesp
        If ExtractedValidaNfVlOutrasDesp(nfOK) = False Then Return False

        'extractedValidaNfVlTgeral
        If ExtractedValidaNfVlTgeral(nfOK) = False Then Return False



        Return nfOK
    End Function

    Private Sub zeraValoresItemNF()

        ' Colunas dos itens
        Me.txt_SaldoAtual.Text = "0,00" : Me.txt_txfrete.Text = "0,00"
        Me.txt_txLucro.Text = "0,00" : Me.txt_vlOutrosProd.Text = "0,00"
        Me.txt_pcoCusto.Text = "0,00" : Me.txt_PcoSugerido.Text = "0,00"
        Me.txt_Vlproduto.Text = "0,00" : Me.txt_Qtde.Text = "1,00"
        Me.txt_prtot.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_Vlproduto.Text = Format(Convert.ToDouble(0.0), "##,##0.000")
        Me.txt_frete.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_BcalculoItem.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_BaseSub.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_icmSub.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_vlIcms.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_Vlipi.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_VlicmsProd.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_alqipi.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_BSCalc.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_BSubsItem.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_vlDescProd.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_vlSeguroProd.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_vlfreteProd.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_vlIpiProd.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_alqSubsProd.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_IcmSubProd.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_OutrasDesp.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_reducao.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_prunit.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_vlPercDescProd.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_codProd.Text = "" : Me.txt_nomeProd.Text = "" : Me.txt_ncm.Text = ""
        Me.cbo_itcfop.SelectedIndex = -1 : Me.cbo_cstProd.SelectedIndex = -1



    End Sub

    Private Sub zeraValoresDuplicat()

        Me.cbo_blPlanoPgto.SelectedIndex = -1 : Me.txt_blParcelas.Text = _valorZERO
        Me.cbo_bltipo.SelectedIndex = -1 : Me.cbo_blcarteira.SelectedIndex = -1
        Me.txt_blNumduplic.Text = "" : Me.dtp_blVenctoDup.Text = ""
        Me.txt_blValordup.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        If Me.dtg_boletos.Rows.Count > _valorZERO Then Me.dtg_boletos.Rows.Clear()



    End Sub

    Private Sub zeraValoresRegNF()

        btn_salvar.Enabled = False
        Me.Msk_nfdtent.Text = Format(agora, "ddMMyyyy")
        agora = agora.AddDays(-2)
        Me.Msk_nfemissao.Text = Format(agora, "ddMMyyyy")
        Me.txt_nftipo.Text = "1" : Me.txt_codPart.Text = ""
        Me.txt_nomePart.Text = "" : Me.txt_ncm.Text = ""
        Me.txt_nfnumero.Text = "" : Me.txt_serie.Text = ""
        Me.cbo_local.SelectedIndex = -1 : Me.cbo_especie.SelectedIndex = -1
        Me.cbo_nfcfop.SelectedIndex = -1 : Me.msk_chavenfe.Text = ""
        Me.txt_nfObs.Text = "" : Me.txt_nfserie.Text = ""
        Me.txt_nftprodutos.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfbscalculo.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfalqicm.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfalqipi.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfvlicm.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfoutros.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfbasesub.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nficmsub.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfvlipi.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfvlfrete.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfipisento.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfipioutros.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfVlSeguro.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfDesconto.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfOutrasDesp.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_nfvltgeral.Text = Format(Convert.ToDouble(0.0), "##,##0.00")



    End Sub

    Private Sub salvaRegistroNFExtracted(ByRef mCodForn As String, ByRef mEstabNF As String, ByRef mNumNF As String, ByRef mSerieNF As String, ByRef mEspecNF As String, ByRef mTipoNF As String, ByRef mChaveNFe As String, ByRef mCfopNF As String, ByRef mTotProdutosNF As Decimal, ByRef mBcIcmsNF As Decimal, ByRef mAlqIcmsNF As Decimal, ByRef mVlIcmsNF As Decimal, ByRef mBcSubsNF As Decimal, ByRef mVlSubsNF As Decimal, ByRef mAlqIpiNF As Decimal, ByRef mVlIpiNF As Decimal, ByRef mVlIpiIsentoNF As Decimal, ByRef mVlIpiOutrosNF As Decimal, ByRef mVlFreteNF As Decimal, ByRef mVlOutrosNF As Decimal, ByRef mVlSeguroNF As Decimal, ByRef mVlTotGeralNF As Decimal, ByRef mVlDescontoNF As Decimal, ByRef mVlOutrasDespNF As Decimal, ByRef mDtEmissao As Date, ByRef mDtEntrada As Date, ByRef mObservacao As String, ByRef mPagamento As Integer)

        mCodForn = Me.txt_codPart.Text : mEstabNF = Me.cbo_local.SelectedItem.ToString.Substring(0, 2)
        mNumNF = Me.txt_nfnumero.Text : mSerieNF = Me.txt_nfserie.Text
        mEspecNF = Me.cbo_especie.Text : mTipoNF = Me.txt_nftipo.Text
        mChaveNFe = Me.msk_chavenfe.Text
        mCfopNF = Mid(Me.cbo_nfcfop.Text, 1, 1) & Mid(Me.cbo_nfcfop.Text, 3, 3)
        mDtEmissao = CDate(Me.Msk_nfemissao.Text)
        mDtEntrada = CDate(Me.Msk_nfdtent.Text)
        mTotProdutosNF = CDec(Me.txt_nftprodutos.Text)
        mBcIcmsNF = CDec(Me.txt_nfbscalculo.Text)
        mAlqIcmsNF = CDec(Me.txt_nfalqicm.Text)
        mVlIcmsNF = CDec(Me.txt_nfvlicm.Text)
        mBcSubsNF = CDec(Me.txt_nfbasesub.Text)
        mVlSubsNF = CDec(Me.txt_nficmsub.Text)
        mAlqIpiNF = CDec(Me.txt_nfalqipi.Text)
        mVlIpiNF = CDec(Me.txt_nfvlipi.Text)
        mVlIpiIsentoNF = CDec(Me.txt_nfipisento.Text)
        mVlIpiOutrosNF = CDec(Me.txt_nfipioutros.Text)
        mVlFreteNF = CDec(Me.txt_nfvlfrete.Text)
        mVlOutrosNF = CDec(Me.txt_nfoutros.Text)
        mVlSeguroNF = CDec(Me.txt_nfVlSeguro.Text)
        mVlDescontoNF = CDec(Me.txt_nfDesconto.Text)
        mVlOutrasDespNF = CDec(Me.txt_nfOutrasDesp.Text)
        mVlTotGeralNF = CDec(Me.txt_nfvltgeral.Text)
        mPagamento = Me.cbo_blPlanoPgto.SelectedIndex
        '0 - A Vista
        '1 - A prazo
        '2 - Sem Pagamento
        '3 - Outros
        mObservacao = Me.txt_nfObs.Text



    End Sub

    Private Sub salvaRegistroNF(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mCodForn, mEstabNF, mNumNF, mSerieNF, mEspecNF, mTipoNF, mChaveNFe, mCfopNF As String

        mCodForn = "" : mEstabNF = "" : mNumNF = "" : mSerieNF = "" : mEspecNF = "" : mTipoNF = ""
        mChaveNFe = "" : mCfopNF = ""

        Dim mTotProdutosNF, mBcIcmsNF, mAlqIcmsNF, mVlIcmsNF, mBcSubsNF, mVlSubsNF As Decimal
        Dim mAlqIpiNF, mVlIpiNF, mVlIpiIsentoNF, mVlIpiOutrosNF, mVlFreteNF, mVlOutrosNF As Decimal
        Dim mVlSeguroNF, mVlTotGeralNF, mVlDescontoNF, mVlOutrasDespNF As Decimal
        Dim mDtEmissao, mDtEntrada As Date
        Dim mObservacao As String = ""
        Dim mPagamento As Integer


        salvaRegistroNFExtracted(mCodForn, mEstabNF, mNumNF, mSerieNF, mEspecNF, mTipoNF, mChaveNFe, mCfopNF, _
                                 mTotProdutosNF, mBcIcmsNF, mAlqIcmsNF, mVlIcmsNF, mBcSubsNF, mVlSubsNF, mAlqIpiNF, _
                                 mVlIpiNF, mVlIpiIsentoNF, mVlIpiOutrosNF, mVlFreteNF, mVlOutrosNF, mVlSeguroNF, _
                                 mVlTotGeralNF, mVlDescontoNF, mVlOutrasDespNF, mDtEmissao, mDtEntrada, mObservacao, mPagamento)


        If _editaNota = False Then 'Se a nota não estiver no processo de edição, então Inclui

            _clBD.IncNfEntradaTerc(mNumNF, mCodForn, mEstabNF, mSerieNF, mEspecNF, mDtEmissao, mDtEntrada, _
                               mTipoNF, mChaveNFe, mCfopNF, mTotProdutosNF, mBcIcmsNF, mAlqIcmsNF, _
                               mVlIcmsNF, mBcSubsNF, mVlSubsNF, mAlqIpiNF, mVlIpiNF, mVlIpiIsentoNF, _
                               mVlIpiOutrosNF, mVlFreteNF, mVlOutrosNF, mVlSeguroNF, mVlDescontoNF, _
                               mVlOutrasDespNF, mVlTotGeralNF, mbUf, mPagamento, mObservacao, oConnBDGENOV, transacao)

        Else

            _clBD.AtualNfEntradaTerc(mIDn4FF, mNumNF, mCodForn, mEstabNF, mSerieNF, mEspecNF, mDtEmissao, mDtEntrada, _
                               mTipoNF, mChaveNFe, mCfopNF, mTotProdutosNF, mBcIcmsNF, mAlqIcmsNF, _
                               mVlIcmsNF, mBcSubsNF, mVlSubsNF, mAlqIpiNF, mVlIpiNF, mVlIpiIsentoNF, _
                               mVlIpiOutrosNF, mVlFreteNF, mVlOutrosNF, mVlSeguroNF, mVlDescontoNF, _
                               mVlOutrasDespNF, mVlTotGeralNF, mbUf, mPagamento, mObservacao, oConnBDGENOV, transacao)
        End If

        'LIMPA OBJETOS DA MEMÓRIA...
        mCodForn = Nothing : mEstabNF = Nothing : mNumNF = Nothing : mSerieNF = Nothing
        mEspecNF = Nothing : mTipoNF = Nothing : mChaveNFe = Nothing : mCfopNF = Nothing
        mDtEmissao = Nothing : mDtEntrada = Nothing : mTotProdutosNF = Nothing : mBcIcmsNF = Nothing
        mAlqIcmsNF = Nothing : mVlIcmsNF = Nothing : mBcSubsNF = Nothing : mVlSubsNF = Nothing
        mAlqIpiNF = Nothing : mVlIpiNF = Nothing : mVlIpiIsentoNF = Nothing : mVlIpiOutrosNF = Nothing
        mVlFreteNF = Nothing : mVlOutrosNF = Nothing : mVlSeguroNF = Nothing : mVlTotGeralNF = Nothing
        mPagamento = Nothing : mObservacao = Nothing


    End Sub

    Private Sub AjustaOsItensAlteradosEDeletados(ByRef mQtdeProd As Decimal, ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim itenDeletado As Boolean
        Dim arrayItens, arrayItensAux As Array
        Dim i As Integer
        Dim codProdAnterior, strQtdeAnterior As String
        Dim qtdeAnterior, qtdeAux As Double

        'ajusta os Itens alterados e deletados
        arrayItens = Split(_itensAnteriores.ToString, "?")
        For i = _valorZERO To arrayItens.Length - 2


            arrayItensAux = Split(arrayItens(i).ToString, "|")
            codProdAnterior = arrayItensAux(_valorZERO).ToString
            Try
                strQtdeAnterior = arrayItensAux(1).ToString

            Catch ex As Exception
                strQtdeAnterior = _valorZERO
            End Try

            qtdeAnterior = CDbl(strQtdeAnterior)
            itenDeletado = True

            'Percorre o GridView e verifica se o produto corrente foi deletado durante a edição
            For Each row As DataGridViewRow In Me.dtg_itensCompras.Rows

                If Not row.IsNewRow Then

                    If codProdAnterior.Equals(row.Cells(_valorZERO).Value) Then

                        itenDeletado = False

                    End If
                End If
            Next 'fim For GridView


            'Altera o estoque para o estado anterior se foi deletado
            If itenDeletado = True Then

                mQtdeProd = _clBD.pegaQtdeEstoque(codProdAnterior, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), oConnBDGENOV)
                If (mQtdeProd - qtdeAnterior) < _valorZERO Then

                    mQtdeProd = _valorZERO
                    _clBD.altualizaQtdsProdEstoq(codProdAnterior, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), mQtdeProd, oConnBDGENOV, transacao)

                Else

                    _clBD.altualizaQtdsProdEstoq(codProdAnterior, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), _
                                                Round((mQtdeProd - qtdeAnterior), 2), oConnBDGENOV, transacao)
                End If
            End If


            'Percorre o GridView e verifica se o produto corrente foi editado durante a edição
            For Each row As DataGridViewRow In Me.dtg_itensCompras.Rows


                If Not row.IsNewRow Then
                    If codProdAnterior.Equals(row.Cells(_valorZERO).Value) Then

                        If qtdeAnterior < CDbl(row.Cells(6).Value) Then

                            mQtdeProd = _clBD.pegaQtdeEstoque(codProdAnterior, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), oConnBDGENOV)
                            qtdeAux = (CDbl(row.Cells(6).Value) - qtdeAnterior)
                            _clBD.altualizaQtdsProdEstoq(codProdAnterior, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), _
                                                        Round((mQtdeProd + qtdeAux), 2), oConnBDGENOV, transacao)

                        ElseIf qtdeAnterior > CDbl(row.Cells(6).Value) Then

                            mQtdeProd = _clBD.pegaQtdeEstoque(codProdAnterior, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), oConnBDGENOV)
                            qtdeAux = (qtdeAnterior - CDbl(row.Cells(6).Value))
                            _clBD.altualizaQtdsProdEstoq(codProdAnterior, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), _
                                                            Round((mQtdeProd - qtdeAux), 2), oConnBDGENOV, transacao)

                        End If
                    End If
                End If
            Next 'fim For GridView
        Next

        'LIMPA OBJETOS DA MEMÓRIA...
        itenDeletado = Nothing : arrayItens = Nothing : arrayItensAux = Nothing : i = Nothing
        codProdAnterior = Nothing : strQtdeAnterior = Nothing : qtdeAnterior = Nothing
        qtdeAux = Nothing



    End Sub

    Private Function salvaItensNFExtractedIDn4FF(ByVal mCodForn As String, ByVal mNumeroNF As String, ByVal mSerie As String, ByVal oConnBDGENOV As NpgsqlConnection) As Int32

        Dim sqlNF As New StringBuilder
        Dim cmdNF As NpgsqlCommand
        Dim drNF As NpgsqlDataReader
        Dim IDn4ff As Int32 = 0

        sqlNF.Append("SELECT n4_id FROM " & MdlEmpresaUsu._esqEstab & ".Nota4ff WHERE n4_numer = '" & mNumeroNF & "' AND ")
        sqlNF.Append(" n4_cdport = '" & mCodForn & "' AND n4_serie = '" & mSerie & "'")
        cmdNF = New NpgsqlCommand(sqlNF.ToString, oConnBDGENOV)
        drNF = cmdNF.ExecuteReader

        While drNF.Read

            IDn4ff = drNF(_valorZERO)
        End While
        drNF.Close() : cmdNF = Nothing : sqlNF = Nothing : drNF = Nothing



        Return IDn4ff
    End Function

    Private Sub SalvaItensEdicao(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd As String
        Dim mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd As Decimal
        Dim mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd As Decimal
        Dim mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd As Decimal
        Dim mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd As Decimal
        Dim mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF, mVlBrutProd As Decimal
        Dim mCodForn, mUndProd, mNumeroNF, mEstab, mSerie As String
        Dim mDtEntrProd, mDtUsuProd As String
        Dim idItem As Int32

        mSerie = txt_nfserie.Text : mNumeroNF = Me.txt_nfnumero.Text
        mEstab = Me.cbo_local.SelectedItem.ToString.Substring(0, 2) : mCodForn = Me.txt_codPart.Text

        AjustaOsItensAlteradosEDeletados(mQtdeProd, oConnBDGENOV, transacao)

        'Grava Itens da NF
        For Each row As DataGridViewRow In Me.dtg_itensCompras.Rows

            If Not row.IsNewRow Then

                mCodProd = row.Cells(_valorZERO).Value
                mNomeProd = row.Cells(1).Value
                mNcmProd = row.Cells(2).Value
                mCfopProd = row.Cells(3).Value
                mCstProd = row.Cells(4).Value
                mCsosnProd = row.Cells(5).Value
                mQtdeProd = CDec(row.Cells(6).Value)
                mVlUnitComprProd = CDec(row.Cells(7).Value)
                mVlPercDesc = CDec(row.Cells(8).Value)
                mVlDesc = CDec(row.Cells(9).Value)
                mVlBrutProd = CDec(row.Cells(10).Value) 'CDec(Round((mQtdeProd * mVlUnitComprProd), 2)) 'CDec(row.Cells(10).Value)
                mVlProd = CDec(row.Cells(11).Value)
                mVlTotProd = Round(mVlBrutProd - mVlDesc, 2) 'CDec(Round((mQtdeProd * mVlProd), 2)) 'CDec(row.Cells(10).Value)
                mVlUnitProdNF = CDec(row.Cells(12).Value)
                mVlPercRedProd = CDec(row.Cells(13).Value)
                mVlBcIcmsProd = CDec(row.Cells(14).Value)
                mVlAlqIcmsProd = CDec(row.Cells(15).Value)
                mVlIcmsProd = CDec(row.Cells(16).Value)
                mBcSubsProd = CDec(row.Cells(17).Value)
                mVlAlqSubsProd = CDec(row.Cells(18).Value)
                mVlSubsProd = CDec(row.Cells(19).Value)
                mVlAlqIpiProd = CDec(row.Cells(20).Value)
                mVlIpiProd = CDec(row.Cells(21).Value)
                mVlPercFretProd = CDec(row.Cells(22).Value)
                mVlFretProd = CDec(row.Cells(23).Value)
                mVlSeguroProd = CDec(row.Cells(24).Value)
                mVlDespProd = CDec(row.Cells(25).Value)
                mVlOutrosProd = CDec(row.Cells(26).Value)
                mVlCustoProd = CDec(row.Cells(27).Value)
                mVlPercLucroProd = CDec(row.Cells(28).Value)
                mVlSurgeridoProd = CDec(row.Cells(29).Value)
                mUndProd = mbUndProd
                mDtEntrProd = Me.Msk_nfdtent.Text
                mDtUsuProd = Format(Date.Now, "dd/MM/yyyy")

                idItem = (row.Cells(31).Value \ 1)
                _clBD.AtuilItensNfEntrTerc(idItem, mIDn4FF, mNumeroNF, mCodForn, mCodProd, mNomeProd, mNcmProd, mCfopProd, _
                mUndProd, mDtEntrProd, mDtUsuProd, mCstProd, mCsosnProd, mQtdeProd, mVlUnitComprProd, mVlPercDesc, _
                mVlDesc, mVlTotProd, mVlProd, mVlBrutProd, mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, _
                mBcSubsProd, mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd, mVlFretProd, _
                mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd, mVlPercLucroProd, mVlSurgeridoProd, _
                mEstab, oConnBDGENOV, transacao)

                _clBD.altDtcompEstoque(mCodProd, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), CDate(mDtEntrProd), oConnBDGENOV, transacao)

            End If
        Next

        If _editaNota = True Then _itensAnteriores.Remove(_valorZERO, _itensAnteriores.ToString.Length)

        'LIMPA OBJETOS DA MEMÓRIA...
        mCodProd = Nothing : mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing
        mCstProd = Nothing : mCsosnProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing
        mVlPercDesc = Nothing : mVlDesc = Nothing : mVlTotProd = Nothing : mVlUnitComprProd = Nothing
        mVlUnitProdNF = Nothing : mVlPercRedProd = Nothing : mVlBcIcmsProd = Nothing : mVlAlqIcmsProd = Nothing
        mVlIcmsProd = Nothing : mBcSubsProd = Nothing : mVlAlqSubsProd = Nothing : mVlSubsProd = Nothing
        mVlAlqIpiProd = Nothing : mVlIpiProd = Nothing : mVlPercFretProd = Nothing : mVlFretProd = Nothing
        mVlSeguroProd = Nothing : mVlDespProd = Nothing : mVlOutrosProd = Nothing : mVlCustoProd = Nothing
        mVlPercLucroProd = Nothing : mVlSurgeridoProd = Nothing : mCodForn = Nothing : mUndProd = Nothing
        mNumeroNF = Nothing : mEstab = Nothing : mSerie = Nothing : mDtEntrProd = Nothing
        mDtUsuProd = Nothing : idItem = Nothing



    End Sub

    Private Sub SalvaItensInclusao(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd As String
        Dim mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd As Decimal
        Dim mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd As Decimal
        Dim mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd As Decimal
        Dim mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd As Decimal
        Dim mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF, mVlBrutProd As Decimal
        Dim mCodForn, mUndProd, mNumeroNF, mEstab, mSerie As String
        Dim mDtEntrProd, mDtUsuProd As String
        Dim pcustoAtual, qtde, novopcusto, novopcustom As Double


        mSerie = txt_nfserie.Text : mNumeroNF = Me.txt_nfnumero.Text
        mEstab = Me.cbo_local.SelectedItem.ToString.Substring(0, 2) : mCodForn = Me.txt_codPart.Text

        mIDn4FF = salvaItensNFExtractedIDn4FF(mCodForn, mNumeroNF, mSerie, oConnBDGENOV)

        'Grava Itens da NF
        For Each row As DataGridViewRow In Me.dtg_itensCompras.Rows

            If Not row.IsNewRow Then
                mCodProd = row.Cells(_valorZERO).Value
                mNomeProd = row.Cells(1).Value
                mNcmProd = row.Cells(2).Value
                mCfopProd = row.Cells(3).Value
                mCstProd = row.Cells(4).Value
                mCsosnProd = row.Cells(5).Value
                mQtdeProd = CDec(row.Cells(6).Value)
                mVlUnitComprProd = CDec(row.Cells(7).Value)
                mVlPercDesc = CDec(row.Cells(8).Value)
                mVlDesc = CDec(row.Cells(9).Value)
                mVlBrutProd = CDec(row.Cells(10).Value)
                mVlProd = CDec(row.Cells(11).Value)
                mVlTotProd = Round(mVlBrutProd - mVlDesc, 2)
                mVlUnitProdNF = CDec(row.Cells(12).Value)
                mVlPercRedProd = CDec(row.Cells(13).Value)
                mVlBcIcmsProd = CDec(row.Cells(14).Value)
                mVlAlqIcmsProd = CDec(row.Cells(15).Value)
                mVlIcmsProd = CDec(row.Cells(16).Value)
                mBcSubsProd = CDec(row.Cells(17).Value)
                mVlAlqSubsProd = CDec(row.Cells(18).Value)
                mVlSubsProd = CDec(row.Cells(19).Value)
                mVlAlqIpiProd = CDec(row.Cells(20).Value)
                mVlIpiProd = CDec(row.Cells(21).Value)
                mVlPercFretProd = CDec(row.Cells(22).Value)
                mVlFretProd = CDec(row.Cells(23).Value)
                mVlSeguroProd = CDec(row.Cells(24).Value)
                mVlDespProd = CDec(row.Cells(25).Value)
                mVlOutrosProd = CDec(row.Cells(26).Value)
                mVlCustoProd = CDec(row.Cells(27).Value)
                mVlPercLucroProd = CDec(row.Cells(28).Value)
                mVlSurgeridoProd = CDec(row.Cells(29).Value)
                mUndProd = mbUndProd
                mDtEntrProd = Me.Msk_nfdtent.Text
                mDtUsuProd = Format(Date.Now, "dd/MM/yyyy")


                _clBD.incItensNfEntradasTerc(mIDn4FF, mNumeroNF, mCodForn, mCodProd, mNomeProd, mNcmProd, mCfopProd, _
                        mUndProd, mDtEntrProd, mDtUsuProd, mCstProd, mCsosnProd, mQtdeProd, mVlUnitComprProd, mVlPercDesc, _
                        mVlDesc, mVlTotProd, mVlProd, mVlBrutProd, mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, _
                        mBcSubsProd, mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd, mVlFretProd, _
                        mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd, mVlPercLucroProd, mVlSurgeridoProd, _
                        mEstab, oConnBDGENOV, transacao)


                pcustoAtual = _clBD.pegaPcustoEstoque(mCodProd, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), oConnBDGENOV)
                qtde = _clBD.pegaQtdeEstoque(mCodProd, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), oConnBDGENOV)
                novopcustom = _clBD.Calcula_CustoMedio(qtde, pcustoAtual, mQtdeProd, mVlUnitComprProd)
                novopcusto = _clBD.Calcula_CustoProd(mVlUnitComprProd, mQtdeProd, mVlIpiProd, mVlFretProd, mVlDespProd, _
                             mVlSubsProd, mVlIcmsProd, mVlSeguroProd, mVlOutrosProd)


                _clBD.altPcustoaEstoque(mCodProd, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), Round(pcustoAtual, 2), oConnBDGENOV, transacao)
                _clBD.altPcustomEstoque(mCodProd, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), Round(novopcustom, 3), oConnBDGENOV, transacao)
                _clBD.altSomandoQtdsProdEstoque(mCodProd, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), Round(mQtdeProd, 3), oConnBDGENOV, transacao)
                _clBD.altPcustoEstoque(mCodProd, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), Round(novopcusto, 2), oConnBDGENOV, transacao)
                _clBD.altPcompEstoque(mCodProd, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), mVlUnitComprProd, oConnBDGENOV, transacao)
                _clBD.altDtcompEstoque(mCodProd, Me.cbo_local.SelectedItem.ToString.Substring(0, 2), CDate(mDtEntrProd), oConnBDGENOV, transacao)

            End If
        Next

        If _editaNota = True Then _itensAnteriores.Remove(_valorZERO, _itensAnteriores.ToString.Length)

        'LIMPA OBJETOS DA MEMÓRIA...
        mCodProd = Nothing : mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing
        mCstProd = Nothing : mCsosnProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing
        mVlPercDesc = Nothing : mVlDesc = Nothing : mVlTotProd = Nothing : mVlUnitComprProd = Nothing
        mVlUnitProdNF = Nothing : mVlPercRedProd = Nothing : mVlBcIcmsProd = Nothing : mVlAlqIcmsProd = Nothing
        mVlIcmsProd = Nothing : mBcSubsProd = Nothing : mVlAlqSubsProd = Nothing : mVlSubsProd = Nothing
        mVlAlqIpiProd = Nothing : mVlIpiProd = Nothing : mVlPercFretProd = Nothing : mVlFretProd = Nothing
        mVlSeguroProd = Nothing : mVlDespProd = Nothing : mVlOutrosProd = Nothing : mVlCustoProd = Nothing
        mVlPercLucroProd = Nothing : mVlSurgeridoProd = Nothing : mCodForn = Nothing : mUndProd = Nothing
        mNumeroNF = Nothing : mEstab = Nothing : mSerie = Nothing : mDtEntrProd = Nothing
        mDtUsuProd = Nothing

    End Sub

    Private Sub salvaItensNF(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        If _editaNota = False Then

            SalvaItensInclusao(oConnBDGENOV, transacao)

        Else

            SalvaItensEdicao(oConnBDGENOV, transacao)

        End If



    End Sub

    Private Sub cbo_nfcfop_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_nfcfop.KeyDown

        If Me.cbo_nfcfop.SelectedIndex >= _valorZERO AndAlso e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            If Me.verifCfop(Me.cbo_nfcfop) Then

                If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")

            End If

        ElseIf e.KeyCode = Keys.Down AndAlso Not (Me.cbo_nfcfop.DroppedDown) Then

            Me.cbo_nfcfop.DroppedDown = True

        ElseIf (Me.cbo_nfcfop.DroppedDown) AndAlso (e.KeyCode <> Keys.Down) AndAlso (e.KeyCode <> Keys.Up) Then

            Me.cbo_nfcfop.DroppedDown = False

        End If



    End Sub

    Private Sub dtg_itensCompras_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_itensCompras.DoubleClick

        preenchElementsItenCorrent()

    End Sub

    Private Sub preenchItenCorrentExtracted(ByRef mCodProd As String, ByRef mNomeProd As String, ByRef mNcmProd As String, ByRef mCfopProd As String, ByRef mCstProd As String, ByRef mCsosnProd As String, ByRef mQtdeProd As Decimal, ByRef mVlProd As Decimal, ByRef mVlPercDesc As Decimal, ByRef mVlDesc As Decimal, ByRef mVlTotProd As Decimal, ByRef mVlPercRedProd As Decimal, ByRef mVlBcIcmsProd As Decimal, ByRef mVlAlqIcmsProd As Decimal, ByRef mVlIcmsProd As Decimal, ByRef mBcSubsProd As Decimal, ByRef mVlAlqSubsProd As Decimal, ByRef mVlSubsProd As Decimal, ByRef mVlAlqIpiProd As Decimal, ByRef mVlIpiProd As Decimal, ByRef mVlPercFretProd As Decimal, ByRef mVlFretProd As Decimal, ByRef mVlSeguroProd As Decimal, ByRef mVlDespProd As Decimal, ByRef mVlOutrosProd As Decimal, ByRef mVlCustoProd As Decimal, ByRef mVlPercLucroProd As Decimal, ByRef mVlSurgeridoProd As Decimal, ByRef mVlUnitProdNF As Decimal)

        Dim mVlUnitComprProd As Decimal
        mCodProd = Me.dtg_itensCompras.CurrentRow.Cells(_valorZERO).Value
        mNomeProd = Me.dtg_itensCompras.CurrentRow.Cells(1).Value
        mNcmProd = Me.dtg_itensCompras.CurrentRow.Cells(2).Value
        mCfopProd = Me.dtg_itensCompras.CurrentRow.Cells(3).Value
        mCstProd = Me.dtg_itensCompras.CurrentRow.Cells(4).Value
        mCsosnProd = Me.dtg_itensCompras.CurrentRow.Cells(5).Value
        mQtdeProd = Me.dtg_itensCompras.CurrentRow.Cells(6).Value
        mVlProd = Me.dtg_itensCompras.CurrentRow.Cells(7).Value
        mVlPercDesc = Me.dtg_itensCompras.CurrentRow.Cells(8).Value
        mVlDesc = Me.dtg_itensCompras.CurrentRow.Cells(9).Value
        mVlTotProd = Me.dtg_itensCompras.CurrentRow.Cells(10).Value
        mVlUnitComprProd = Me.dtg_itensCompras.CurrentRow.Cells(11).Value
        mVlUnitProdNF = Me.dtg_itensCompras.CurrentRow.Cells(12).Value
        mVlPercRedProd = Me.dtg_itensCompras.CurrentRow.Cells(13).Value
        mVlBcIcmsProd = Me.dtg_itensCompras.CurrentRow.Cells(14).Value
        mVlAlqIcmsProd = Me.dtg_itensCompras.CurrentRow.Cells(15).Value
        mVlIcmsProd = Me.dtg_itensCompras.CurrentRow.Cells(16).Value
        mBcSubsProd = Me.dtg_itensCompras.CurrentRow.Cells(17).Value
        mVlAlqSubsProd = Me.dtg_itensCompras.CurrentRow.Cells(18).Value
        mVlSubsProd = Me.dtg_itensCompras.CurrentRow.Cells(19).Value
        mVlAlqIpiProd = Me.dtg_itensCompras.CurrentRow.Cells(20).Value
        mVlIpiProd = Me.dtg_itensCompras.CurrentRow.Cells(21).Value
        mVlPercFretProd = Me.dtg_itensCompras.CurrentRow.Cells(22).Value
        mVlFretProd = Me.dtg_itensCompras.CurrentRow.Cells(23).Value
        mVlSeguroProd = Me.dtg_itensCompras.CurrentRow.Cells(24).Value
        mVlDespProd = Me.dtg_itensCompras.CurrentRow.Cells(25).Value
        mVlOutrosProd = Me.dtg_itensCompras.CurrentRow.Cells(26).Value
        mVlCustoProd = Me.dtg_itensCompras.CurrentRow.Cells(27).Value
        mVlPercLucroProd = Me.dtg_itensCompras.CurrentRow.Cells(28).Value
        mVlSurgeridoProd = Me.dtg_itensCompras.CurrentRow.Cells(29).Value
        mbUndProd = Me.dtg_itensCompras.CurrentRow.Cells(30).Value


    End Sub

    Private Sub preenchElementsItenCorrent()

        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd As String

        mCodProd = "" : mNomeProd = "" : mNcmProd = "" : mCfopProd = "" : mCstProd = "" : mCsosnProd = ""

        Dim mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd As Decimal
        Dim mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd As Decimal
        Dim mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd As Decimal
        Dim mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd As Decimal
        Dim mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF As Decimal

        Try

            _idItemEditado = (Me.dtg_itensCompras.CurrentRow.Index + 1)
            preenchItenCorrentExtracted(mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd, mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd, mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd, mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd, mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF)

            Me.txt_codProd.Text = mCodProd : Me.txt_nomeProd.Text = mNomeProd : Me.txt_ncm.Text = mNcmProd
            Me.txt_csosn.Text = mCsosnProd

            Dim mCfopCbo, mCstCbo As String
            Dim index As Integer
            For index = _valorZERO To Me.cbo_itcfop.Items.Count - 1

                mCfopCbo = Me.cbo_itcfop.Items.Item(index).ToString.Substring(_valorZERO, 1) & Me.cbo_itcfop.Items.Item(index).ToString.Substring(2, 3)
                If mCfopCbo.Equals(mCfopProd) Then

                    Me.cbo_itcfop.SelectedIndex = index
                    Exit For

                End If
            Next

            For index = _valorZERO To Me.cbo_cstProd.Items.Count - 1

                mCstCbo = Me.cbo_cstProd.Items.Item(index).ToString.Substring(_valorZERO, 2)
                If mCstCbo.Equals(mCstProd) Then

                    Me.cbo_cstProd.SelectedIndex = index
                    Exit For

                End If
            Next

            index = Nothing : mCfopCbo = Nothing : mCstCbo = Nothing

            Me.txt_Qtde.Text = mQtdeProd
            Me.txt_Vlproduto.Text = mVlProd
            Me.txt_vlPercDescProd.Text = mVlPercDesc
            Me.txt_vlDescProd.Text = mVlDesc
            Me.txt_prtot.Text = mVlTotProd
            Me.txt_prunit.Text = mVlUnitProdNF
            Me.txt_reducao.Text = mVlPercRedProd
            Me.txt_BcalculoItem.Text = mVlBcIcmsProd
            Me.txt_alqIcmsProd.Text = mVlAlqIcmsProd
            Me.txt_VlicmsProd.Text = mVlIcmsProd
            Me.txt_BSubsItem.Text = mBcSubsProd
            Me.txt_alqSubsProd.Text = mVlAlqSubsProd
            Me.txt_IcmSubProd.Text = mVlSubsProd
            Me.txt_alqIpiProd.Text = mVlAlqIpiProd
            Me.txt_vlIpiProd.Text = mVlIpiProd
            Me.txt_txfrete.Text = mVlPercFretProd
            Me.txt_vlfreteProd.Text = mVlFretProd
            Me.txt_vlSeguroProd.Text = mVlSeguroProd
            Me.txt_OutrasDesp.Text = mVlDespProd
            Me.txt_vlOutrosProd.Text = mVlOutrosProd
            Me.txt_pcoCusto.Text = mVlCustoProd
            Me.txt_txLucro.Text = mVlPercLucroProd
            Me.txt_PcoSugerido.Text = mVlSurgeridoProd


        Catch ex As Exception
        End Try

        'LIMPA OBJETOS DA MEMÓRIA...
        mCodProd = Nothing : mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing
        mCstProd = Nothing : mCsosnProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing
        mVlPercDesc = Nothing : mVlDesc = Nothing : mVlTotProd = Nothing : mVlUnitComprProd = Nothing
        mVlUnitProdNF = Nothing : mVlPercRedProd = Nothing : mVlBcIcmsProd = Nothing : mVlAlqIcmsProd = Nothing
        mVlIcmsProd = Nothing : mBcSubsProd = Nothing : mVlAlqSubsProd = Nothing : mVlSubsProd = Nothing
        mVlAlqIpiProd = Nothing : mVlIpiProd = Nothing : mVlPercFretProd = Nothing : mVlFretProd = Nothing
        mVlSeguroProd = Nothing : mVlDespProd = Nothing : mVlOutrosProd = Nothing : mVlCustoProd = Nothing
        mVlPercLucroProd = Nothing : mVlSurgeridoProd = Nothing



    End Sub

    Private Sub txt_nftprodutos_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nftprodutos.Leave

        If Me.txt_nftprodutos.Text.Equals("") Then Me.txt_nftprodutos.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_nftprodutos.Text) Then


            'Se a nota não for Frete
            If Not Me.cbo_especie.Text.Equals("FT") AndAlso Not Me.cbo_especie.Text.Equals("FTE") Then

                If CDec(Me.txt_nftprodutos.Text) <= _valorZERO Then

                    lbl_mensagen.Text = "Total dos Produtos na nota deve ser maior que ZERO!"
                    Return

                End If
            End If
            Me.txt_nftprodutos.Text = Format(CDec(Me.txt_nftprodutos.Text), "###,##0.00")

        Else

            lbl_mensagen.Text = "Numero inválido para o Total dos Produtos!"
            Return
        End If
        lbl_mensagen.Text = ""



    End Sub

    Private Sub atualizSomaVlItens()

        Dim mValor, mValorTotal As Decimal

        mValor = _valorZERO : mValorTotal = _valorZERO
        'Soma valor bruto dos produtos
        For Each col As DataGridViewRow In Me.dtg_itensCompras.Rows

            mValor += col.Cells(10).Value
        Next
        Me.lbl_VlBrutoItens.Text = Format(Round(mValor, 2), "##,##0.00")
        mValorTotal += mValor


        mValor = _valorZERO
        'Soma valor da base icms dos produtos
        For Each col As DataGridViewRow In Me.dtg_itensCompras.Rows

            mValor += col.Cells(14).Value
        Next
        Me.lbl_VlBcIcmsItens.Text = Format(Round(mValor, 2), "##,##0.00")


        mValor = _valorZERO
        'Soma valor icms dos produtos
        For Each col As DataGridViewRow In Me.dtg_itensCompras.Rows

            mValor += col.Cells(16).Value
        Next
        Me.lbl_VlIcmsItens.Text = Format(Round(mValor, 2), "##,##0.00")


        mValor = _valorZERO
        'Soma valor da base substituição dos produtos
        For Each col As DataGridViewRow In Me.dtg_itensCompras.Rows

            mValor += col.Cells(17).Value
        Next
        Me.lbl_VlBcSubsItens.Text = Format(Round(mValor, 2), "##,##0.00")


        mValor = _valorZERO
        'Soma valor da substituição dos produtos
        For Each col As DataGridViewRow In Me.dtg_itensCompras.Rows

            mValor += col.Cells(19).Value
        Next
        Me.lbl_VlSubs.Text = Format(Round(mValor, 2), "##,##0.00")
        mValorTotal += mValor


        mValor = _valorZERO
        'Soma valor IPI dos produtos
        For Each col As DataGridViewRow In Me.dtg_itensCompras.Rows

            mValor += col.Cells(21).Value
        Next
        Me.lbl_VlIpiItens.Text = Format(Round(mValor, 2), "##,##0.00")
        mValorTotal += mValor


        mValor = _valorZERO
        'Soma valor Frete dos produtos
        For Each col As DataGridViewRow In Me.dtg_itensCompras.Rows

            mValor += col.Cells(23).Value
        Next
        Me.lbl_VlFretItens.Text = Format(Round(mValor, 2), "##,##0.00")
        mValorTotal += mValor


        mValor = _valorZERO
        'Soma valor Seguro dos produtos
        For Each col As DataGridViewRow In Me.dtg_itensCompras.Rows

            mValor += col.Cells(24).Value
        Next
        Me.lbl_VlSegItens.Text = Format(Round(mValor, 2), "##,##0.00")
        mValorTotal += mValor


        mValor = _valorZERO
        'Soma valor Seguro dos produtos
        For Each col As DataGridViewRow In Me.dtg_itensCompras.Rows

            mValor += col.Cells(25).Value
        Next
        Me.lbl_vlOutrasDesp.Text = Format(Round(mValor, 2), "##,##0.00")
        mValorTotal += mValor


        mValor = _valorZERO
        'Soma valor Desconto dos produtos
        For Each col As DataGridViewRow In Me.dtg_itensCompras.Rows

            mValor += col.Cells(9).Value
        Next
        Me.lbl_VlDescItens.Text = Format(Round(mValor, 2), "##,##0.00")
        mValorTotal -= mValor

        Me.lbl_vlTotalItens.Text = Format(Round(mValorTotal, 2), "##,##0.00")



    End Sub

    Private Sub txt_VlicmsProd_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_VlicmsProd.GotFocus

        txt_VlicmsProd.SelectAll()
        If CDec(Me.txt_BcalculoItem.Text) > _valorZERO AndAlso CDec(Me.txt_alqIcmsProd.Text) > _valorZERO Then Me.txt_VlicmsProd.Text = _
        CDec(Round((CDec(Me.txt_BcalculoItem.Text) * (CDec(Me.txt_alqIcmsProd.Text) / 100)), 2))



    End Sub

    Private Sub cbo_especie_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_especie.Leave

        If Me.cbo_especie.SelectedIndex >= _valorZERO AndAlso Me.cbo_especie.SelectedIndex = 2 OrElse _
        Me.cbo_especie.SelectedIndex = 3 Then

            Me.btn_registrar.Enabled = False
            cbo_nfcfop.SelectedIndex = trazIndexCfop("1.353", cbo_nfcfop)
            If cbo_nfcfop.SelectedIndex < _valorZERO Then

                cbo_nfcfop.SelectedIndex = trazIndexCfop("2.353", cbo_nfcfop)

            End If
        ElseIf Me.cbo_especie.SelectedIndex >= _valorZERO Then

            Me.btn_registrar.Enabled = True

        Else

            lbl_mensagen.Text = "Selecione uma Especie de Nota!"
            Me.btn_registrar.Enabled = True : Return
        End If
        lbl_mensagen.Text = ""



    End Sub

    Private Sub txt_nfDesconto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfDesconto.GotFocus

        txt_nfDesconto.SelectAll()

    End Sub

    Private Sub txt_nfDesconto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nfDesconto.Leave

        If IsNumeric(Me.txt_nfDesconto.Text) Then

            Dim mtgeral As Double
            If Me.txt_nfDesconto.Text.Equals("") Then Me.txt_nfDesconto.Text = Format(0.0, "###,##0.00")

            Try

                mtgeral = ((CDbl(txt_nftprodutos.Text) + CDbl(txt_nficmsub.Text) + CDbl(txt_nfvlipi.Text) + CDbl(txt_nfipisento.Text) + _
                CDbl(txt_nfipioutros.Text) + CDbl(txt_nfvlfrete.Text)) - CDbl(txt_nfDesconto.Text))
                Me.txt_nfvltgeral.Text = Format(Round(mtgeral, 2), "###,##0.00")
                Me.txt_nfDesconto.Text = Format(CDec(Me.txt_nfDesconto.Text), "###,##0.00")

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try

        Else

            lbl_mensagen.Text = "Numero inválido para Valor do Desconto !"
            Return
        End If
        lbl_mensagen.Text = ""



    End Sub

    Private Sub msk_chavenfe_LostFocusExtracted()

        Try

            If cbo_especie.SelectedIndex = _valorZERO OrElse cbo_especie.SelectedIndex = 3 Then


                If msk_chavenfe.Text <> "" Then

                    If Me.msk_chavenfe.Text.Substring(6, 14).IndexOf(mbCNPJ) < _valorZERO Then

                        lbl_mensagen.Text = "CNPJ e CPF do Fornecedor não coincide com o da CHAVE!"
                        Me.txt_codPart.Focus() : Me.txt_codPart.SelectAll() : Return

                    End If

                    Dim mNumeDocumento As String = CStr((Me.txt_nfnumero.Text \ 1))
                    If Me.msk_chavenfe.Text.Substring(25, 9).IndexOf(mNumeDocumento) < _valorZERO Then

                        lbl_mensagen.Text = "Numero da nota não coincide com o da CHAVE !"
                        Me.txt_nftipo.Focus() : Return

                    End If

                    If _clBD.ValidaChaveNFE(RTrim(Me.msk_chavenfe.Text)) = False Then

                        lbl_mensagen.Text = "Chave Invalida, tente Novamente !"
                        Me.txt_nftipo.Focus() : Return

                    End If

                Else

                    lbl_mensagen.Text = "Chave Invalida, tente Novamente !"
                    Me.txt_nftipo.Focus() : Return

                End If
            End If
            lbl_mensagen.Text = ""

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Private Sub msk_chavenfe_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_chavenfe.LostFocus

        If _mValidaValores Then msk_chavenfe_LostFocusExtracted()

    End Sub

    Private Sub txt_Basecalculo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_BcalculoItem.GotFocus

        txt_BcalculoItem.SelectAll()
        If CDbl(Me.txt_nfbscalculo.Text) > _valorZERO AndAlso CDbl(Me.txt_BcalculoItem.Text) <= _valorZERO Then

            If IsNumeric(Me.txt_reducao.Text) AndAlso CDbl(Me.txt_reducao.Text) > _valorZERO Then

                Me.txt_BcalculoItem.Text = (CDbl(Me.txt_prtot.Text) - Round((CDbl(Me.txt_prtot.Text) * _
                                            (CDbl(Me.txt_reducao.Text) / 100)), 2))

            Else

                Me.txt_BcalculoItem.Text = Me.txt_prtot.Text
                Me.txt_BcalculoItem.SelectAll()

            End If
        End If



    End Sub

    Private Sub cbo_local_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_local.Leave

        If Me.cbo_local.SelectedIndex < _valorZERO Then

            lbl_mensagen.Text = "Informe o local da entrada da nota !"
            Return

        End If
        lbl_mensagen.Text = ""



    End Sub

    Private Sub txt_nfvlfrete_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nfvlfrete.Leave

        If Me.txt_nfvlfrete.Text.Equals("") Then Me.txt_nfvlfrete.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_nfvlfrete.Text) Then

            Me.txt_nfvlfrete.Text = Format(CDec(Me.txt_nfvlfrete.Text), "###,##0.00")

        Else

            lbl_mensagen.Text = "Numero inválido para Valor do Frete !"
            Return
        End If
        lbl_mensagen.Text = ""



    End Sub

    Private Sub executaConsulta()

        _mStrConsulta = trazStrConsulAtual()
        Me.ConsultaBD(_mStrConsulta)
        If Me.DtgConsultaNotas.RowCount > _valorZERO Then Me.DtgConsultaNotas.Focus()


    End Sub

    Private Function trazStrConsulAtual() As String

        Return ConsulFornec() & ConsulEspec() & ConsulPeriodos()

    End Function

    Private Function ConsulEspec() As String

        If cbo_EspecConsulta.SelectedIndex > _valorZERO Then

            If chk_FornConsuta.Checked = False OrElse _mCodFonecedor.Equals("") Then

                Return "WHERE n4_espec = '" & Me.cbo_EspecConsulta.Text & "' "

            Else
                Return "AND n4_espec = '" & Me.cbo_EspecConsulta.Text & "' "

            End If
        End If



        Return ""
    End Function

    Private Function ConsulPeriodos() As String

        Select Case cbo_consulta.SelectedIndex
            Case _valorZERO 'Todas as Notas
                Me.msk_dtInicio.Enabled = False : Me.msk_dtFim.Enabled = False
                Me.msk_dtInicio.Text = "" : Me.msk_dtFim.Text = ""
                Return "ORDER BY n4_dtent DESC"

            Case 1 'As últimas 10 Notas
                Me.msk_dtInicio.Enabled = False : Me.msk_dtFim.Enabled = False
                Me.msk_dtInicio.Text = "" : Me.msk_dtFim.Text = ""
                Return "ORDER BY n4_dtent DESC LIMIT 10"

            Case 2 'Notas da data atual
                Me.msk_dtInicio.Enabled = False : Me.msk_dtFim.Enabled = False
                Me.msk_dtInicio.Text = "" : Me.msk_dtFim.Text = ""

                If chk_FornConsuta.Checked = False AndAlso cbo_EspecConsulta.SelectedIndex <= _valorZERO Then

                    Return "WHERE n4_dtent = CURRENT_DATE ORDER BY n4_dtent DESC"

                Else
                    Return "AND n4_dtent = CURRENT_DATE ORDER BY n4_dtent DESC"

                End If


            Case 3 'Notas apartir do ultimo mes
                Me.msk_dtInicio.Enabled = False : Me.msk_dtFim.Enabled = False
                Me.msk_dtInicio.Text = "" : Me.msk_dtFim.Text = ""

                If chk_FornConsuta.Checked = False AndAlso cbo_EspecConsulta.SelectedIndex <= _valorZERO Then

                    Return "WHERE n4_dtent BETWEEN date_trunc('month',CURRENT_DATE - " & _
                    "INTERVAL '1 month')::date AND CURRENT_DATE ORDER BY n4_dtent ASC"

                Else
                    Return "AND n4_dtent BETWEEN date_trunc('month',CURRENT_DATE - " & _
                "INTERVAL '1 month')::date AND CURRENT_DATE ORDER BY n4_dtent ASC"

                End If


            Case 4 'Notas apartir do ultimo ano
                Me.msk_dtInicio.Enabled = False : Me.msk_dtFim.Enabled = False
                Me.msk_dtInicio.Text = "" : Me.msk_dtFim.Text = ""

                If chk_FornConsuta.Checked = False AndAlso cbo_EspecConsulta.SelectedIndex <= _valorZERO Then

                    Return "WHERE n4_dtent BETWEEN date_trunc('year',CURRENT_DATE - " & _
                    "INTERVAL '1 year')::date AND CURRENT_DATE ORDER BY n4_dtent ASC"

                Else
                    Return "AND n4_dtent BETWEEN date_trunc('year',CURRENT_DATE - " & _
                "INTERVAL '1 year')::date AND CURRENT_DATE ORDER BY n4_dtent ASC"

                End If


            Case 5 'data personalizada
                Me.msk_dtInicio.Enabled = True : Me.msk_dtFim.Enabled = True
                Me.msk_dtInicio.Focus() : Me.msk_dtInicio.SelectAll()

                'valida as datas
                If IsDate(Me.msk_dtInicio.Text) AndAlso IsDate(Me.msk_dtFim.Text) Then

                    If chk_FornConsuta.Checked = False AndAlso cbo_EspecConsulta.SelectedIndex <= _valorZERO Then

                        Return "WHERE n4_dtent BETWEEN '" & Me.msk_dtInicio.Text & "' AND '" & _
                        Me.msk_dtFim.Text & "' ORDER BY n4_dtent ASC"

                    Else
                        Return "AND n4_dtent BETWEEN '" & Me.msk_dtInicio.Text & "' AND '" & _
                    Me.msk_dtFim.Text & "' ORDER BY n4_dtent ASC"

                    End If
                End If


        End Select



        Return ""
    End Function

    Private Function ConsulFornec() As String

        If Not _mCodFonecedor.Equals("") AndAlso (chk_FornConsuta.Checked = True) Then

            Return "WHERE n4_cdport = '" & _mCodFonecedor & "' "

        End If



        Return ""
    End Function

    Private Sub ConsultaBD(ByVal consulta As String)
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlNF As New StringBuilder
        Dim cmdNF As NpgsqlCommand
        Dim daNF As NpgsqlDataAdapter
        Dim drNF As NpgsqlDataReader
        Dim dtNotas As New DataTable

        Try
            sqlNF.Append("SELECT n4_id AS ""ID"", to_char(n4_dtent, 'DD/MM/YYYY') AS ""DtEntrada"", n4_numer AS ")
            sqlNF.Append("""Numero"", n4_serie AS ""Serie"", (n4_cdport || ' - ' || SUBSTR(cad.p_portad, 1, 60)) ")
            sqlNF.Append("AS ""Fornecedor"", to_char(n4_dtemis, 'DD/MM/YYYY') AS ""DtEmissao"", n4_espec AS ")
            sqlNF.Append("""Espec"", n4_cdfisc AS ""CFOP"", n4_tgeral AS ""Tot.Nota"", n4_tprod AS ""Tot.Prod"", ")
            sqlNF.Append("n4_basec AS ""Bc.ICMS"", n4_icms AS ""Vl.ICMS"", n4_bsub AS ""Bc.SUBs"", n4_icsub ")
            sqlNF.Append("AS ""Vl.SUBs"", n4_ipi AS ""Vl.IPI"", n4_frete AS ""Vl.Frete"", n4_segu AS ""Vl.Segu"", ")
            sqlNF.Append("n4_desc AS ""Vl.Desconto"", n4_outrasdesp AS ""Outr. Desp."", n4_estab AS ""Estab."", ")
            sqlNF.Append("n4_fechamento AS ""Fechamento"" FROM " & MdlEmpresaUsu._esqEstab & ".Nota4ff LEFT JOIN cadp001 ")
            sqlNF.Append("cad ON cad.p_cod = n4_cdport " & consulta)

            cmdNF = New NpgsqlCommand(sqlNF.ToString, oConnBDGENOV)
            daNF = New NpgsqlDataAdapter(sqlNF.ToString, oConnBDGENOV)

            dtNotas = New DataTable : daNF.Fill(dtNotas)
            drNF = cmdNF.ExecuteReader
            Me.DtgConsultaNotas.DataSource = dtNotas

            If drNF.HasRows = True Then
                Me.DtgConsultaNotas.Columns(_valorZERO).Width = 50
                Me.DtgConsultaNotas.Columns(_valorZERO).Visible = False
                Me.DtgConsultaNotas.Columns(1).Width = 70 'dtEntr
                Me.DtgConsultaNotas.Columns(2).Width = 70 'numero
                Me.DtgConsultaNotas.Columns(3).Width = 40 'serie
                Me.DtgConsultaNotas.Columns(4).Width = 250 'Fornecedor
                Me.DtgConsultaNotas.Columns(5).Width = 70 'dtEmiss
                Me.DtgConsultaNotas.Columns(6).Width = 40 'Espec
                Me.DtgConsultaNotas.Columns(7).Width = 50 'CFOP
                Me.DtgConsultaNotas.Columns(8).Width = 90 'tgeral
                Me.DtgConsultaNotas.Columns(9).Width = 90 'tprod
                Me.DtgConsultaNotas.Columns(10).Width = 90 'bcIcms
                Me.DtgConsultaNotas.Columns(11).Width = 90 'vlIcms
                Me.DtgConsultaNotas.Columns(12).Width = 90 'bcSubs
                Me.DtgConsultaNotas.Columns(13).Width = 90 'vlSubs
                Me.DtgConsultaNotas.Columns(14).Width = 90 'vlIPI
                Me.DtgConsultaNotas.Columns(15).Width = 90 'frete
                Me.DtgConsultaNotas.Columns(16).Width = 90 'Seguro
                Me.DtgConsultaNotas.Columns(17).Width = 80 'Desconto
                Me.DtgConsultaNotas.Columns(18).Width = 90 'OutrasDesp
                Me.DtgConsultaNotas.Columns(19).Width = 70 'estabelecimento
                Me.DtgConsultaNotas.Columns(20).Width = 70 'fechamento


            End If

            cmdNF.CommandText = "" : oConnBDGENOV.ClearPool() : oConnBDGENOV.Close()
        Catch ex As Exception
        End Try

        sqlNF.Remove(_valorZERO, sqlNF.ToString.Length)

        daNF = Nothing : cmdNF = Nothing : sqlNF = Nothing : dtNotas = Nothing : drNF = Nothing
        oConnBDGENOV = Nothing : Me.DtgConsultaNotas.Focus()



    End Sub

    Private Sub buscaNfEspecie()

        If cbo_EspecConsulta.SelectedIndex > _valorZERO Then

            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try


            Dim sqlNF As New StringBuilder
            Dim daNF As NpgsqlDataAdapter
            Dim dtNotas As New DataTable
            Dim mEspecie As String = cbo_EspecConsulta.Text

            Try
                sqlNF.Append("SELECT n4_id, to_char(n4_dtent, 'DD/MM/YYYY') AS ""Data Entrada"", n4_numer AS ")
                sqlNF.Append("""Numero"", (n4_cdport || ' - ' || SUBSTR(cad.p_portad, 1, 60)) AS ""Fornecedor"", ")
                sqlNF.Append("to_char(n4_dtemis, 'DD/MM/YYYY') AS ""DataEmisao"", n4_espec AS ""Especie"", ")
                sqlNF.Append("n4_cdfisc AS ""CFOP"", n4_tgeral AS ""Tot.Nota"", n4_tprod AS ""Tot.Prod"", ")
                sqlNF.Append("n4_basec AS ""Bc.ICMS"", n4_icms AS ""Vl.ICMS"", n4_bsub AS ""Bc.SUBs"", ")
                sqlNF.Append("n4_icsub AS ""Vl.SUBs"", n4_ipi AS ""Vl.IPI"", n4_frete AS ""Vl.Frete"", ")
                sqlNF.Append("n4_segu AS ""Vl.Segu"", n4_desc AS ""Vl.Desconto"" FROM " & MdlEmpresaUsu._esqEstab & ".nota4ff ")
                sqlNF.Append("LEFT JOIN cadp001 cad ON cad.p_cod = n4_cdport WHERE n4_espec = '")
                sqlNF.Append("'")

                daNF = New NpgsqlDataAdapter(sqlNF.ToString, oConnBDGENOV)
                dtNotas = New DataTable
                daNF.Fill(dtNotas)
                Me.DtgConsultaNotas.DataSource = dtNotas

                sqlNF.Remove(_valorZERO, sqlNF.ToString.Length)
                oConnBDGENOV.ClearPool() : oConnBDGENOV.Close()
            Catch ex As Exception
            End Try


            daNF = Nothing : sqlNF = Nothing : dtNotas = Nothing
            oConnBDGENOV = Nothing : Me.DtgConsultaNotas.Focus()
        End If



    End Sub

    Private Sub msk_dtInicio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_dtInicio.KeyDown

        If e.KeyCode = Keys.Enter Then


            If (Trim(Me.msk_dtInicio.Text).Length = 10) AndAlso (Trim(Me.msk_dtFim.Text).Length = 10) Then

                If IsDate(Me.msk_dtInicio.Text) AndAlso IsDate(Me.msk_dtFim.Text) Then

                    executaConsulta()

                ElseIf Not IsDate(Me.msk_dtInicio.Text) Then

                    Me.msk_dtInicio.BackColor = Color.Red
                    Me.msk_dtInicio.Focus() : Me.msk_dtInicio.SelectAll()
                    MsgBox("Intervalo de data inicial inválida", MsgBoxStyle.Exclamation)
                    Return

                ElseIf Not IsDate(Me.msk_dtFim.Text) Then

                    Me.msk_dtFim.BackColor = Color.Red
                    Me.msk_dtFim.Focus() : Me.msk_dtFim.SelectAll()
                    MsgBox("Intervalo de data final inválida", MsgBoxStyle.Exclamation)
                    Return

                End If
            End If

            Me.msk_dtFim.Focus() : Me.msk_dtFim.SelectAll()


            If IsDate(Me.msk_dtFim.Text) AndAlso IsDate(Me.msk_dtInicio.Text) Then

                If Me.DtgConsultaNotas.RowCount > _valorZERO Then

                    Me.DtgConsultaNotas.Focus()

                Else

                    Me.msk_dtFim.Focus() : Me.msk_dtFim.SelectAll()

                End If
            End If
        End If



    End Sub

    Private Sub msk_dtInicio_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_dtInicio.KeyUp

        Me.msk_dtInicio.BackColor = Color.White : Me.msk_dtFim.BackColor = Color.White

    End Sub

    Private Sub msk_dtFim_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_dtFim.KeyDown

        If e.KeyCode = Keys.Enter Then


            If (Trim(Me.msk_dtInicio.Text).Length = 10) AndAlso (Trim(Me.msk_dtFim.Text).Length = 10) Then

                If IsDate(Me.msk_dtInicio.Text) AndAlso IsDate(Me.msk_dtFim.Text) Then

                    executaConsulta()

                ElseIf Not IsDate(Me.msk_dtInicio.Text) Then

                    Me.msk_dtInicio.BackColor = Color.Red
                    Me.msk_dtInicio.Focus() : Me.msk_dtInicio.SelectAll()
                    MsgBox("Intervalo de data inicial inválida", MsgBoxStyle.Exclamation)
                    Return

                ElseIf Not IsDate(Me.msk_dtFim.Text) Then

                    Me.msk_dtFim.BackColor = Color.Red
                    Me.msk_dtFim.Focus() : Me.msk_dtFim.SelectAll()
                    MsgBox("Intervalo de data final inválida", MsgBoxStyle.Exclamation)
                    Return

                End If
            End If


            If IsDate(Me.msk_dtFim.Text) AndAlso IsDate(Me.msk_dtInicio.Text) Then

                If Me.DtgConsultaNotas.RowCount > _valorZERO Then

                    Me.DtgConsultaNotas.Focus()

                Else
                    Me.msk_dtInicio.Focus() : Me.msk_dtInicio.SelectAll()

                End If
            End If
        End If



    End Sub

    Private Sub msk_dtFim_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_dtFim.KeyUp

        Me.msk_dtInicio.BackColor = Color.White : Me.msk_dtFim.BackColor = Color.White

    End Sub

    Private Sub cbo_consulta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_consulta.GotFocus

        If Not (Me.cbo_consulta.DroppedDown) Then Me.cbo_consulta.DroppedDown = True

    End Sub

    Private Sub cbo_consulta_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_consulta.SelectedValueChanged

        Me.executaConsulta()

    End Sub

    Private Sub cbo_EspecConsulta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_EspecConsulta.GotFocus

        If Not (Me.cbo_EspecConsulta.DroppedDown) Then Me.cbo_EspecConsulta.DroppedDown = True 'AndAlso Me.cbo_consulta.Text.Equals("")

    End Sub

    Private Sub cbo_EspecConsulta_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_EspecConsulta.SelectedValueChanged

        Me.executaConsulta()

    End Sub

    Private Sub btn_ConsForn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ConsForn.Click

        'Aqui tenta chamar o Formulario de Busca do Fornecedor...
        Try
            _mPesquisaForn = True : _frmREf = Me
            _BuscaForn.set_frmRef(Me) : _BuscaForn.ShowDialog(Me)
            _mPesquisaForn = False : Me.txt_codPart.Text = "" : Me.txt_nomePart.Text = ""
            Me.executaConsulta() : Me.cbo_nfcfop.Text = "" : Me.cbo_itcfop.Text = ""
            Me.cbo_nfcfop.SelectedIndex = -1 : Me.cbo_itcfop.SelectedIndex = -1
            Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()

        Catch ex As Exception
        End Try



    End Sub

    Private Sub chk_FornConsuta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_FornConsuta.CheckedChanged

        Me.executaConsulta()

    End Sub

    Private Sub incResumAlq(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mAliquotas As Array = ReturnAlqGridView()
        Dim i As Integer
        Dim strALQ As String, mNumeroNF As String = Me.txt_nfnumero.Text
        Dim aliqICMS, totProd, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI As Decimal
        Dim vlDesc, vlFrete, vlSeguro, vlOutrasDesp As Decimal
        Dim mExistAlq As Boolean = False

        For i = _valorZERO To mAliquotas.Length - 1

            totProd = 0.0 : vlDesc = 0.0 : vlFrete = 0.0 : vlSeguro = 0.0 : bcalcICMS = 0.0
            vlICMS = 0.0 : vlOutras = 0.0 : vlIPI = 0.0 : vlIsento = 0.0 : vlOutrasDesp = 0.0
            mExistAlq = False

            'Percorre o GridView
            For Each row As DataGridViewRow In Me.dtg_itensCompras.Rows

                If Not row.IsNewRow Then

                    strALQ = CDec(row.Cells(15).Value)
                    If mAliquotas(i).Equals(strALQ) Then

                        mExistAlq = True
                        totProd += CDec(row.Cells(10).Value) : vlDesc += CDec(row.Cells(9).Value)
                        vlFrete += CDec(row.Cells(23).Value) : vlSeguro += CDec(row.Cells(24).Value)
                        vlOutrasDesp += CDec(row.Cells(25).Value) : aliqICMS = CDec(row.Cells(15).Value)
                        bcalcICMS += CDec(row.Cells(14).Value) : vlICMS += CDec(row.Cells(16).Value)
                        vlOutras += CDec(row.Cells(19).Value) : vlIPI += CDec(row.Cells(21).Value)

                        'CST
                        If row.Cells(4).Value.Equals("30") OrElse _
                        row.Cells(4).Value.Equals("40") Then

                            vlIsento += CDec(row.Cells(10).Value)

                        Else
                            vlIsento += 0.0

                        End If
                    End If
                End If
            Next 'fim For GridView


            If mExistAlq = True Then 'Grava o Resumo das Aliquotas no resn4ff01

                If _editaNota = False Then 'Se a nota não estiver no processo de edição, então inclui

                    _clBD.IncResEntrTercALQ(mIDn4FF, mNumeroNF, aliqICMS, totProd, vlDesc, vlFrete, vlSeguro, _
                                        vlOutrasDesp, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI, oConnBDGENOV, transacao)

                Else

                    Try
                        _clBD.delResEntrTercALQ(mIDn4FF, oConnBDGENOV, transacao)
                        _clBD.IncResEntrTercALQ(mIDn4FF, mNumeroNF, aliqICMS, totProd, vlDesc, vlFrete, vlSeguro, _
                                        vlOutrasDesp, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI, oConnBDGENOV, transacao)

                    Catch ex As Exception
                    End Try

                End If
            End If

        Next 'fim For Aliquotas

        'LIMPA OBJETOS DA MEMÓRIA...
        mAliquotas = Nothing : i = Nothing : strALQ = Nothing : mNumeroNF = Nothing : aliqICMS = Nothing
        totProd = Nothing : bcalcICMS = Nothing : vlICMS = Nothing : vlIsento = Nothing : vlOutras = Nothing
        vlIPI = Nothing : vlDesc = Nothing : vlFrete = Nothing : vlSeguro = Nothing : vlOutrasDesp = Nothing
        mExistAlq = Nothing



    End Sub

    Private Sub incResumCfopAlq(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mCfopAlq As Array = ReturnCfopAlqGridView()
        Dim i As Integer
        Dim strCFOP_ALQ As String, mNumeroNF As String = Me.txt_nfnumero.Text
        Dim aliqICMS, totProd, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI As Decimal
        Dim vlDesc, vlFrete, vlSeguro, vlOutrasDesp As Decimal
        Dim Cfop As String
        Dim mExistCfopAlq As Boolean = False


        For i = _valorZERO To mCfopAlq.Length - 1

            Cfop = "" : totProd = 0.0 : vlDesc = 0.0 : vlFrete = 0.0 : vlSeguro = 0.0 : bcalcICMS = 0.0
            vlICMS = 0.0 : vlOutras = 0.0 : vlIPI = 0.0 : vlIsento = 0.0 : vlOutrasDesp = 0.0
            mExistCfopAlq = False

            'Percorre o GridView
            For Each row As DataGridViewRow In Me.dtg_itensCompras.Rows


                If Not row.IsNewRow Then

                    strCFOP_ALQ = row.Cells(3).Value & "/" & CDec(row.Cells(15).Value)
                    If mCfopAlq(i).Equals(strCFOP_ALQ) Then

                        mExistCfopAlq = True : Cfop = row.Cells(3).Value : totProd += CDec(row.Cells(10).Value)
                        vlDesc += CDec(row.Cells(9).Value) : vlFrete += CDec(row.Cells(23).Value)
                        vlSeguro += CDec(row.Cells(24).Value) : vlOutrasDesp += CDec(row.Cells(25).Value)
                        aliqICMS = CDec(row.Cells(15).Value) : bcalcICMS += CDec(row.Cells(14).Value)
                        vlICMS += CDec(row.Cells(16).Value) : vlOutras += CDec(row.Cells(19).Value)
                        vlIPI += CDec(row.Cells(21).Value)

                        'CST
                        If row.Cells(4).Value.Equals("30") OrElse _
                        row.Cells(4).Value.Equals("40") Then

                            vlIsento += CDec(row.Cells(10).Value)

                        Else

                            vlIsento += 0.0

                        End If

                    End If
                End If
            Next 'fim For GridView


            If mExistCfopAlq = True Then 'Grava o Resumo dos CFOP/Aliquotas no resn4ff02
                If _editaNota = False Then 'Se a nota não estiver no processo de edição, então inclui

                    _clBD.IncResEntrTercCfopAlq(mIDn4FF, mNumeroNF, Cfop, aliqICMS, totProd, vlDesc, vlFrete, vlSeguro, _
                                        vlOutrasDesp, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI, oConnBDGENOV, transacao)

                Else

                    _clBD.delResEntrTercCfopALQ(mIDn4FF, oConnBDGENOV, transacao)
                    _clBD.IncResEntrTercCfopAlq(mIDn4FF, mNumeroNF, Cfop, aliqICMS, totProd, vlDesc, vlFrete, vlSeguro, _
                                        vlOutrasDesp, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI, oConnBDGENOV, transacao)

                End If
            End If

        Next 'fim For Aliquotas

        'LIMPA OBJETOS DA MEMÓRIA...
        mCfopAlq = Nothing : i = Nothing : strCFOP_ALQ = Nothing : mNumeroNF = Nothing
        aliqICMS = Nothing : totProd = Nothing : bcalcICMS = Nothing : vlICMS = Nothing
        vlIsento = Nothing : vlOutras = Nothing : vlIPI = Nothing : vlDesc = Nothing
        vlFrete = Nothing : vlSeguro = Nothing : vlOutrasDesp = Nothing : Cfop = Nothing
        mExistCfopAlq = Nothing



    End Sub

    Private Sub incResumCstCfopAlq(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mCstCfopAlq As Array = ReturnCstCfopAlqGridView()
        Dim i As Integer
        Dim strCST_CFOP_ALQ As String, mNumeroNF As String = Me.txt_nfnumero.Text
        Dim aliqICMS, totProd, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI As Decimal
        Dim vlDesc, vlFrete, vlSeguro, vlOutrasDesp As Decimal
        Dim Cfop, Cst As String
        Dim mExistCstCfopAlq As Boolean = False

        For i = _valorZERO To mCstCfopAlq.Length - 1

            Cst = "" : Cfop = "" : totProd = 0.0 : vlDesc = 0.0 : vlFrete = 0.0 : vlSeguro = 0.0
            bcalcICMS = 0.0 : vlICMS = 0.0 : vlOutras = 0.0 : vlIPI = 0.0 : vlIsento = 0.0
            vlOutrasDesp = 0.0 : mExistCstCfopAlq = False

            'Percorre o GridView
            For Each row As DataGridViewRow In Me.dtg_itensCompras.Rows


                If Not row.IsNewRow Then

                    strCST_CFOP_ALQ = row.Cells(4).Value & "/" & row.Cells(3).Value & "/" & CDec(row.Cells(15).Value)
                    If mCstCfopAlq(i).Equals(strCST_CFOP_ALQ) Then

                        mExistCstCfopAlq = True : Cfop = row.Cells(3).Value : Cst = row.Cells(4).Value
                        totProd += CDec(row.Cells(10).Value) : vlDesc += CDec(row.Cells(9).Value)
                        vlFrete += CDec(row.Cells(23).Value) : vlSeguro += CDec(row.Cells(24).Value)
                        vlOutrasDesp += CDec(row.Cells(25).Value) : aliqICMS = CDec(row.Cells(15).Value)
                        bcalcICMS += CDec(row.Cells(14).Value) : vlICMS += CDec(row.Cells(16).Value)
                        vlOutras += CDec(row.Cells(19).Value) : vlIPI += CDec(row.Cells(21).Value)

                        'CST
                        If row.Cells(4).Value.Equals("30") OrElse _
                        row.Cells(4).Value.Equals("40") Then

                            vlIsento += CDec(row.Cells(10).Value)

                        Else
                            vlIsento += 0.0

                        End If

                    End If
                End If
            Next 'fim For GridView


            If mExistCstCfopAlq = True Then 'Grava o Resumo dos CST/CFOP/Aliquotas no resn4ff03

                If _editaNota = False Then 'Se a nota não estiver no processo de edição, então inclui

                    _clBD.IncResEntrTercCstCfopAlq(mIDn4FF, mNumeroNF, Cst, Cfop, aliqICMS, totProd, vlDesc, vlFrete, vlSeguro, _
                                        vlOutrasDesp, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI, oConnBDGENOV, transacao)

                Else

                    _clBD.delResEntrTercCstCfopALQ(mIDn4FF, oConnBDGENOV, transacao)
                    _clBD.IncResEntrTercCstCfopAlq(mIDn4FF, mNumeroNF, Cst, Cfop, aliqICMS, totProd, vlDesc, vlFrete, vlSeguro, _
                                        vlOutrasDesp, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI, oConnBDGENOV, transacao)

                End If
            End If

        Next 'fim For Aliquotas

        'LIMPA OBJETOS DA MEMÓRIA...
        mCstCfopAlq = Nothing : i = Nothing : strCST_CFOP_ALQ = Nothing : mNumeroNF = Nothing
        aliqICMS = Nothing : totProd = Nothing : bcalcICMS = Nothing : vlICMS = Nothing
        vlIsento = Nothing : vlOutras = Nothing : vlIPI = Nothing : vlDesc = Nothing
        vlFrete = Nothing : vlSeguro = Nothing : vlOutrasDesp = Nothing : Cfop = Nothing
        Cst = Nothing : mExistCstCfopAlq = Nothing



    End Sub

    Private Sub incContas_A_Pagar(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mCodForn, mEstabBL, mNumFatBL, mSerieBL, mTipoBL As String
        Dim mVlFat, mJurosBL, mVlDescontoBL, mTxDescBL As Decimal
        Dim mDtEmissao, mDtVencBL, mDtPagBL As Date
        Dim mNFiscal, mCarteiBL, mSitBL, mNunDuplicBL, mHistBL As String
        Dim mStatsBL As Boolean
        Dim mBancoBL As Integer

        mCodForn = Me.txt_codPart.Text : mEstabBL = Me.cbo_local.SelectedItem.ToString.Substring(0, 2)
        mNumFatBL = Me.txt_nfnumero.Text : mNFiscal = mNumFatBL
        mSerieBL = Me.txt_nfserie.Text : mIDn4FF = trazIdN4ff(mSerieBL, mNumFatBL, mCodForn)
        mTipoBL = Me.cbo_bltipo.Text : mNFiscal = ""
        mVlDescontoBL = 0.0 : mTxDescBL = 0.0 : mDtEmissao = CDate(Me.Msk_nfemissao.Text)
        mCarteiBL = Me.cbo_blcarteira.Text : mSitBL = "N" : mStatsBL = False
        mBancoBL = _valorZERO : mHistBL = "" : mJurosBL = 0.0

        If Me.cbo_blPlanoPgto.SelectedIndex = 1 Then 'Se o Plano do boleto for "A PRAZO"

            'Percorre o GridView boleto
            For Each row As DataGridViewRow In Me.dtg_boletos.Rows

                If Not row.IsNewRow Then

                    mNunDuplicBL = row.Cells(1).Value : mDtVencBL = CDate(row.Cells(3).Value)
                    mDtPagBL = mDtVencBL : mVlFat = CDec(row.Cells(4).Value)

                    _clBD.IncContas_a_Pagar(mIDn4FF, mEstabBL, mCodForn, mTipoBL, mNumFatBL, mNFiscal, mSerieBL, _
                                        mTxDescBL, mNunDuplicBL, mDtEmissao, mDtVencBL, mVlFat, mCarteiBL, mDtPagBL, _
                                        mJurosBL, mVlDescontoBL, mBancoBL, mHistBL, mSitBL, mStatsBL, oConnBDGENOV, transacao)

                End If
            Next 'fim For GridView boleto

        Else

            mNunDuplicBL = mNumFatBL '& "-1"
            mDtVencBL = CDate(Me.Msk_nfdtent.Text)
            mDtPagBL = mDtVencBL
            mVlFat = CDec(Me.txt_nfvltgeral.Text)

            _clBD.IncContas_a_Pagar(mIDn4FF, mEstabBL, mCodForn, mTipoBL, mNumFatBL, mNFiscal, mSerieBL, _
                                mTxDescBL, mNunDuplicBL, mDtEmissao, mDtVencBL, mVlFat, mCarteiBL, mDtPagBL, _
                                mJurosBL, mVlDescontoBL, mBancoBL, mHistBL, mSitBL, mStatsBL, oConnBDGENOV, transacao)

        End If

        'LIMPA OBJETOS DA MEMÓRIA...
        mCodForn = Nothing : mEstabBL = Nothing : mNumFatBL = Nothing : mSerieBL = Nothing : mTipoBL = Nothing
        mNFiscal = Nothing : mVlDescontoBL = Nothing : mTxDescBL = Nothing : mDtEmissao = Nothing
        mCarteiBL = Nothing : mSitBL = Nothing : mStatsBL = Nothing : mBancoBL = Nothing : mHistBL = Nothing
        mNunDuplicBL = Nothing : mDtVencBL = Nothing : mDtPagBL = Nothing : mVlFat = Nothing : mJurosBL = Nothing



    End Sub

    Private Sub incContas_A_PagarXml(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mCodForn, mEstabBL, mNumFatBL, mSerieBL, mTipoBL As String
        Dim mVlFat, mJurosBL, mVlDescontoBL, mTxDescBL As Decimal
        Dim mDtEmissao, mDtVencBL, mDtPagBL As Date
        Dim mNFiscal, mCarteiBL, mSitBL, mNunDuplicBL, mHistBL As String
        Dim mStatsBL As Boolean, mBancoBL As Integer

        mCodForn = _codFornXML : mEstabBL = cbo_xmlocal.Text : mNumFatBL = Me.txt_xmnumero.Text
        mNFiscal = mNumFatBL : mSerieBL = Me.txt_xmserie.Text : mTipoBL = Me.cbo_bltipo.Text
        mNFiscal = "" : mVlDescontoBL = 0.0 : mTxDescBL = 0.0 : mDtEmissao = CDate(Me.Msk_nfemissao.Text)
        mCarteiBL = Me.cbo_blcarteira.Text : mSitBL = "N" : mStatsBL = False
        mBancoBL = _valorZERO : mHistBL = "" : mJurosBL = 0.0


        If Me.cbo_blPlanoPgto.SelectedIndex = 1 Then 'Se o Plano do boleto for "A PRAZO"

            'Percorre o GridView boleto
            For Each row As DataGridViewRow In Me.dtg_boletos.Rows

                If Not row.IsNewRow Then

                    mNunDuplicBL = row.Cells(1).Value : mDtVencBL = CDate(row.Cells(3).Value)
                    mDtPagBL = mDtVencBL : mVlFat = CDec(row.Cells(4).Value)

                    _clBD.IncContas_a_Pagar(mIDn4FF, mEstabBL, mCodForn, mTipoBL, mNumFatBL, mNFiscal, mSerieBL, _
                                        mTxDescBL, mNunDuplicBL, mDtEmissao, mDtVencBL, mVlFat, mCarteiBL, mDtPagBL, _
                                        mJurosBL, mVlDescontoBL, mBancoBL, mHistBL, mSitBL, mStatsBL, oConnBDGENOV, transacao)

                End If
            Next 'fim For GridView boleto

        Else

            mNunDuplicBL = mNumFatBL : mDtVencBL = CDate(Me.Msk_nfdtent.Text)
            mDtPagBL = mDtVencBL : mVlFat = CDec(Me.txt_nfvltgeral.Text)

            _clBD.IncContas_a_Pagar(mIDn4FF, mEstabBL, mCodForn, mTipoBL, mNumFatBL, mNFiscal, mSerieBL, _
                                mTxDescBL, mNunDuplicBL, mDtEmissao, mDtVencBL, mVlFat, mCarteiBL, mDtPagBL, _
                                mJurosBL, mVlDescontoBL, mBancoBL, mHistBL, mSitBL, mStatsBL, oConnBDGENOV, transacao)

        End If

        'LIMPA OBJETOS DA MEMÓRIA...
        mCodForn = Nothing : mEstabBL = Nothing : mNumFatBL = Nothing : mSerieBL = Nothing : mTipoBL = Nothing
        mNFiscal = Nothing : mVlDescontoBL = Nothing : mTxDescBL = Nothing : mDtEmissao = Nothing
        mCarteiBL = Nothing : mSitBL = Nothing : mStatsBL = Nothing : mBancoBL = Nothing
        mHistBL = Nothing : mNunDuplicBL = Nothing : mDtVencBL = Nothing : mDtPagBL = Nothing
        mVlFat = Nothing : mJurosBL = Nothing



    End Sub

    Private Function ReturnAlqGridView() As Array

        Dim mStrBuildAlq As New StringBuilder
        Dim mArray As Array
        Dim i As Integer
        Dim mExitAlq As Boolean = False

        mStrBuildAlq.Append("")
        'Percorre o GridView
        For Each row As DataGridViewRow In Me.dtg_itensCompras.Rows

            If Not row.IsNewRow Then

                Try
                    mArray = Split(mStrBuildAlq.ToString, "|")
                    mExitAlq = False
                    For i = _valorZERO To mArray.Length - 1

                        If CDec(row.Cells(15).Value).ToString.Equals(mArray(i).ToString) Then

                            mExitAlq = True
                            Exit For

                        End If
                    Next
                    If mExitAlq = False Then mStrBuildAlq.Append(CDec(row.Cells(15).Value) & "|")

                Catch ex As Exception
                End Try

            End If
        Next
        mArray = Nothing : mExitAlq = Nothing : i = Nothing



        Return Split(mStrBuildAlq.ToString, "|")
    End Function

    Private Function ReturnAlqGridViewXml() As Array

        Dim mStrBuildAlq As New StringBuilder
        Dim mArray As Array
        Dim i As Integer
        Dim mExitAlq As Boolean = False

        mStrBuildAlq.Append("")
        'Percorre o GridView
        For Each row As DataGridViewRow In Me.dtgXmlItens.Rows

            If Not row.IsNewRow Then

                Try
                    mArray = Split(mStrBuildAlq.ToString, "|")
                    mExitAlq = False
                    For i = _valorZERO To mArray.Length - 1

                        If CDec(row.Cells(13).Value).ToString.Equals(mArray(i).ToString) Then

                            mExitAlq = True
                            Exit For

                        End If
                    Next
                    If mExitAlq = False Then mStrBuildAlq.Append(CDec(row.Cells(13).Value) & "|")

                Catch ex As Exception
                End Try

            End If
        Next
        mArray = Nothing : mExitAlq = Nothing : i = Nothing



        Return Split(mStrBuildAlq.ToString, "|")
    End Function

    Private Function ReturnCfopAlqGridView() As Array

        Dim mStrBuild As New StringBuilder
        Dim mArray As Array
        Dim i As Integer
        Dim mExitAlq As Boolean = False
        Dim CFOP_ALQ As String

        mStrBuild.Append("")
        'Percorre o GridView
        For Each row As DataGridViewRow In Me.dtg_itensCompras.Rows

            If Not row.IsNewRow Then

                Try
                    CFOP_ALQ = row.Cells(3).Value & "/" & CDec(row.Cells(15).Value)
                    mArray = Split(mStrBuild.ToString, "|")
                    mExitAlq = False

                    For i = _valorZERO To mArray.Length - 1

                        If CFOP_ALQ.Equals(mArray(i).ToString) Then
                            mExitAlq = True
                            Exit For

                        End If
                    Next
                    If mExitAlq = False Then mStrBuild.Append(CFOP_ALQ & "|")

                Catch ex As Exception
                End Try

            End If
        Next
        mArray = Nothing : mExitAlq = Nothing : i = Nothing : CFOP_ALQ = Nothing



        Return Split(mStrBuild.ToString, "|")
    End Function

    Private Function ReturnCfopAlqGridViewXml() As Array

        Dim mStrBuild As New StringBuilder
        Dim mArray As Array
        Dim i As Integer
        Dim mExitAlq As Boolean = False
        Dim CFOP_ALQ As String

        mStrBuild.Append("")
        'Percorre o GridView
        For Each row As DataGridViewRow In Me.dtgXmlItens.Rows

            If Not row.IsNewRow Then

                Try
                    CFOP_ALQ = row.Cells(4).Value & "/" & CDec(row.Cells(13).Value)
                    mArray = Split(mStrBuild.ToString, "|")
                    mExitAlq = False

                    For i = _valorZERO To mArray.Length - 1
                        If CFOP_ALQ.Equals(mArray(i).ToString) Then

                            mExitAlq = True : Exit For

                        End If
                    Next
                    If mExitAlq = False Then mStrBuild.Append(CFOP_ALQ & "|")

                Catch ex As Exception
                End Try

            End If
        Next
        mArray = Nothing : mExitAlq = Nothing : i = Nothing : CFOP_ALQ = Nothing



        Return Split(mStrBuild.ToString, "|")
    End Function

    Private Function ReturnCstCfopAlqGridView() As Array

        Dim mStrBuild As New StringBuilder
        Dim mArray As Array
        Dim i As Integer
        Dim mExitAlq As Boolean = False
        Dim CST_CFOP_ALQ As String

        mStrBuild.Append("")
        'Percorre o GridView
        For Each row As DataGridViewRow In Me.dtg_itensCompras.Rows

            If Not row.IsNewRow Then

                Try
                    CST_CFOP_ALQ = row.Cells(4).Value & "/" & row.Cells(3).Value & "/" & CDec(row.Cells(15).Value)
                    mArray = Split(mStrBuild.ToString, "|")
                    mExitAlq = False

                    For i = _valorZERO To mArray.Length - 1
                        If CST_CFOP_ALQ.Equals(mArray(i).ToString) Then

                            mExitAlq = True : Exit For

                        End If
                    Next
                    If mExitAlq = False Then mStrBuild.Append(CST_CFOP_ALQ & "|")

                Catch ex As Exception
                End Try

            End If
        Next
        mArray = Nothing : mExitAlq = Nothing : i = Nothing : CST_CFOP_ALQ = Nothing



        Return Split(mStrBuild.ToString, "|")
    End Function

    Private Function ReturnCstCfopAlqGridViewXml() As Array

        Dim mStrBuild As New StringBuilder
        Dim mArray As Array
        Dim i As Integer
        Dim mExitAlq As Boolean = False
        Dim CST_CFOP_ALQ As String

        mStrBuild.Append("")
        'Percorre o GridView
        For Each row As DataGridViewRow In Me.dtgXmlItens.Rows

            If Not row.IsNewRow Then

                Try
                    CST_CFOP_ALQ = row.Cells(5).Value & "/" & row.Cells(4).Value & "/" & CDec(row.Cells(13).Value)
                    mArray = Split(mStrBuild.ToString, "|")
                    mExitAlq = False

                    For i = _valorZERO To mArray.Length - 1
                        If CST_CFOP_ALQ.Equals(mArray(i).ToString) Then

                            mExitAlq = True : Exit For

                        End If
                    Next
                    If mExitAlq = False Then mStrBuild.Append(CST_CFOP_ALQ & "|")

                Catch ex As Exception
                End Try

            End If
        Next
        mArray = Nothing : mExitAlq = Nothing : i = Nothing : CST_CFOP_ALQ = Nothing



        Return Split(mStrBuild.ToString, "|")
    End Function

    Private Sub cbo_planopgto_LeaveExtracted()

        Me.cbo_bltipo.Enabled = True : Me.cbo_blcarteira.Enabled = True
        Me.txt_blParcelas.Enabled = True : Me.grp_lancadup.Enabled = True
        Me.dtp_blVenctoDup.Enabled = True : Me.txt_blValordup.Enabled = True
        Me.btn_incBol.Enabled = True : Me.btn_delBol.Enabled = True


    End Sub

    Private Sub cbo_planopgto_LeaveExtracted1()

        Me.txt_blNumduplic.Text = "" : Me.dtp_blVenctoDup.Text = ""
        Me.txt_blValordup.Text = "" : Me.txt_blParcelas.Text = "0"
        Me.cbo_bltipo.SelectedIndex = -1 : Me.cbo_blcarteira.SelectedIndex = -1
        Me.cbo_bltipo.Enabled = False : Me.cbo_blcarteira.Enabled = False
        Me.btn_SaiBol.Enabled = True : Me.dtp_blVenctoDup.Enabled = False
        Me.txt_blValordup.Enabled = False : Me.btn_incBol.Enabled = False
        Me.btn_delBol.Enabled = False


    End Sub

    Private Sub cbo_planopgto_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_blPlanoPgto.Leave

        Select Case cbo_blPlanoPgto.SelectedIndex
            Case 1
                cbo_planopgto_LeaveExtracted()

            Case Else
                cbo_planopgto_LeaveExtracted1()

        End Select



    End Sub

    Private Sub txt_parcelas_LeaveExtracted()

        Me.grp_lancadup.Enabled = True : Me.txt_blNumduplic.Enabled = False
        Me.dtp_blVenctoDup.Enabled = False : Me.txt_blValordup.Enabled = False
        Me.btn_incBol.Enabled = False : Me.btn_delBol.Enabled = False


    End Sub

    Private Sub txt_parcelas_LeaveExtracted1()

        Me.grp_lancadup.Enabled = True : Me.txt_blNumduplic.Enabled = True
        Me.dtp_blVenctoDup.Enabled = True : Me.txt_blValordup.Enabled = True
        Me.btn_incBol.Enabled = True : Me.btn_delBol.Enabled = True

        If CInt(Me.txt_blParcelas.Text) > _valorZERO Then
            If dtg_boletos.Rows.Count < CInt(Me.txt_blParcelas.Text) Then

                If Not Me.txt_nfnumero.Text.Equals("") Then

                    Me.txt_blNumduplic.Text = RTrim(Me.txt_nfnumero.Text) & "-" & Me.dtg_boletos.Rows.Count + 1
                    Me.txt_blValordup.Text = CDec(Round((Me.txt_nfvltgeral.Text / CInt(Me.txt_blParcelas.Text)), 2))

                Else

                    Me.txt_blNumduplic.Text = RTrim(Me.txt_xmnumero.Text) & "-" & Me.dtg_boletos.Rows.Count + 1
                    Me.txt_blValordup.Text = CDec(Round((Me.lbl_xmVlTot.Text / CInt(Me.txt_blParcelas.Text)), 2))

                End If

            End If
        End If



    End Sub

    Private Sub txt_parcelas_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_blParcelas.Leave

        If cbo_blPlanoPgto.SelectedIndex = 1 AndAlso IsNumeric(Me.txt_blParcelas.Text) AndAlso _
        CDec(Me.txt_blParcelas.Text) <= _valorZERO Then

            MsgBox("Favor Preencher Parcelas Maior que 0", MsgBoxStyle.Information, "Erro Parcelas")
            Me.txt_blParcelas.Focus() : Me.txt_blParcelas.SelectAll()

        End If

        If cbo_blPlanoPgto.SelectedIndex <> 1 Then txt_parcelas_LeaveExtracted()

        If cbo_blPlanoPgto.SelectedIndex = 1 AndAlso IsNumeric(Me.txt_blParcelas.Text) And _
        CDec(Me.txt_blParcelas.Text) > _valorZERO Then

            txt_parcelas_LeaveExtracted1()

        End If



    End Sub

    Private Sub btn_incBol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incBol.Click

        If _BoletoEditado <= _valorZERO Then

            If CInt(Me.txt_blParcelas.Text) >= 1 Then

                If dtg_boletos.Rows.Count < CInt(Me.txt_blParcelas.Text) AndAlso Me.cbo_blPlanoPgto.SelectedIndex = 1 Then

                    If verifCamposContasPagar() Then

                        'adicionar
                        addDataGridBoleto() : Me.txt_blNumduplic.Focus() : Me.txt_blNumduplic.SelectAll()

                    End If
                End If
            End If
        Else

            editDataGridBoleto()

        End If



    End Sub

    Private Function verifCamposContasPagar() As Boolean

        If Me.cbo_bltipo.SelectedIndex < _valorZERO Then

            MsgBox("Selecione Tipo de pagamento", MsgBoxStyle.Exclamation)
            Me.cbo_bltipo.Focus() : Return False

        End If

        If Me.cbo_blPlanoPgto.SelectedIndex < _valorZERO Then

            MsgBox("Selecione um Condição de pagamento", MsgBoxStyle.Exclamation)
            Me.cbo_blPlanoPgto.Focus() : Return False

        End If

        If Me.cbo_blcarteira.SelectedIndex < _valorZERO Then

            MsgBox("Selecione a Carteira de pagamento", MsgBoxStyle.Exclamation)
            Me.cbo_blcarteira.Focus() : Return False

        End If



        Return True
    End Function

    Private Sub addDataGridBoleto()

        Dim mValor As Decimal
        Dim mTotalGeral As Double
        Dim mTipo, mDocumento As String
        Dim mEmissao, mVencimento As Date
        Dim mDt As String

        Try

            mTipo = Me.cbo_bltipo.Text
            mDocumento = Me.txt_blNumduplic.Text
            If Not Me.txt_nfnumero.Text.Equals("") Then

                mEmissao = CDate(Me.Msk_nfemissao.Text) : mTotalGeral = CDbl(Me.txt_nfvltgeral.Text)

            Else
                mEmissao = CDate(Me.msk_xmemissao.Text) : mTotalGeral = CDbl(Me.lbl_xmVlTot.Text)

            End If


            mVencimento = Me.dtp_blVenctoDup.Value
            mValor = CDec(Me.txt_blValordup.Text)
            mDt = Me.dtp_blVenctoDup.Text
            If ((Me.txt_blParcelas.Text) \ 1) > 1 AndAlso (mVlTotParcelas <> mTotalGeral) Then

                If Me.dtg_boletos.Rows.Count = CInt(Me.txt_blParcelas.Text) Then

                    mVlTotParcelas += mValor : mDocumento = ""
                    Me.txt_blValordup.Text = Format(0.0, "###,##0.00")
                    Me.dtp_blVenctoDup.Text = "" : Me.txt_blNumduplic.Enabled = False
                    Me.txt_blValordup.Enabled = False : Me.dtp_blVenctoDup.Enabled = False

                ElseIf Me.dtg_boletos.Rows.Count < CInt(Me.txt_blParcelas.Text) Then


                    mVlTotParcelas += mValor
                    If Not Me.txt_nfnumero.Text.Equals("") Then

                        mDocumento = RTrim(Me.txt_nfnumero.Text) & "-" & Me.dtg_boletos.Rows.Count + 1
                        If (Me.dtg_boletos.Rows.Count + 2) = CInt(Me.txt_blParcelas.Text) Then 'Se a proxima parcela for a última

                            Me.txt_blValordup.Text = Format(CDec(Round((CDec(Me.txt_nfvltgeral.Text) - mVlTotParcelas), 2)), "###,##0.00")

                        Else
                            Me.txt_blValordup.Text = Format(CDec(Round((Me.txt_nfvltgeral.Text / CInt(Me.txt_blParcelas.Text)), 2)), "###,##0.00")

                        End If
                    Else


                        mDocumento = RTrim(Me.txt_xmnumero.Text) & "-" & Me.dtg_boletos.Rows.Count + 1
                        If (Me.dtg_boletos.Rows.Count + 2) = CInt(Me.txt_blParcelas.Text) Then 'Se a proxima parcela for a última

                            Me.txt_blValordup.Text = Format(CDec(Round((mTotalGeral - mVlTotParcelas), 2)), "###,##0.00")

                        Else
                            Me.txt_blValordup.Text = Format(CDec(Round((mTotalGeral / CInt(Me.txt_blParcelas.Text)), 2)), "###,##0.00")

                        End If
                    End If
                End If

            Else

                Me.txt_blNumduplic.Text = "" : Me.txt_blValordup.Text = Format(0.0, "###,##0.00")
                Me.dtp_blVenctoDup.Text = "" : Me.txt_blNumduplic.Enabled = False
                Me.txt_blValordup.Enabled = False : Me.dtp_blVenctoDup.Enabled = False

            End If


            Try

                If Not mDocumento.Equals("") AndAlso IsDate(mVencimento) AndAlso CDec(mValor) <> _valorZERO Then

                    If _BoletoEditado <= _valorZERO Then

                        _BoletoEditado = _valorZERO
                        Dim mlinha As String() = {mTipo, mDocumento, mEmissao, mVencimento, mValor}

                        'Adicionando Linha
                        Me.dtg_boletos.Rows.Add(mlinha)
                        If mVlTotParcelas <> CDec(Me.txt_nfvltgeral.Text) Then

                            If Not Me.txt_nfnumero.Text.Equals("") Then

                                Me.txt_blNumduplic.Text = RTrim(Me.txt_nfnumero.Text) & "-" & Me.dtg_boletos.Rows.Count + 1

                            Else
                                Me.txt_blNumduplic.Text = RTrim(Me.txt_xmnumero.Text) & "-" & Me.dtg_boletos.Rows.Count + 1

                            End If


                            Dim ano As Integer = CInt(mDt.Substring(6, 4))
                            Dim mes As Integer = CInt(mDt.Substring(3, 2))
                            Dim dia As Integer = CInt(mDt.Substring(_valorZERO, 2))
                            mes += 1

                            If mes > 12 Then mes = 1 : ano += 1

                            Me.dtp_blVenctoDup.Text = Format(DateSerial(ano, mes, dia), "ddMMyyyy")

                            If CInt(Me.dtp_blVenctoDup.Text.Substring(3, 2)) <> mes Then

                                Me.dtp_blVenctoDup.Text = Format(DateSerial(ano, mes + 1, _valorZERO), "ddMMyyyy")

                            End If
                            ano = Nothing : mes = Nothing : dia = Nothing


                        Else

                            Me.txt_blNumduplic.Text = "" : Me.txt_blValordup.Text = Format(0.0, "###,##0.00")
                            Me.dtp_blVenctoDup.Text = ""

                        End If


                        If Me.dtg_boletos.Rows.Count + 1 > CInt(Me.txt_blParcelas.Text) Then

                            Me.txt_blNumduplic.Enabled = False : Me.txt_blValordup.Enabled = False
                            Me.dtp_blVenctoDup.Enabled = False

                        End If

                        mlinha = Nothing
                    Else

                        _BoletoEditado = _valorZERO
                        Dim mlinha As String() = {mTipo, mDocumento, mEmissao, mVencimento, mValor}

                        'Adicionando Linha
                        Me.dtg_boletos.Rows(_BoletoEditado).SetValues(mlinha)

                        If Me.dtg_boletos.Rows.Count + 1 > CInt(Me.txt_blParcelas.Text) Then

                            Me.txt_blNumduplic.Enabled = False : Me.txt_blValordup.Enabled = False
                            Me.dtp_blVenctoDup.Enabled = False

                        End If
                        mlinha = Nothing

                    End If
                End If


            Catch ex As Exception
                MsgBox("Deu ERRO ao Incluir este Boleto " & ex.Message, MsgBoxStyle.Exclamation)
            End Try

        Catch ex As Exception
        End Try



    End Sub

    Private Sub editDataGridBoleto()

        Dim mValor As Decimal
        Dim mTipo, mDocumento As String
        Dim mEmissao, mVencimento As Date

        Try

            mTipo = Me.cbo_bltipo.Text : mDocumento = Me.txt_blNumduplic.Text
            mEmissao = CDate(Me.Msk_nfemissao.Text) : mVencimento = Me.dtp_blVenctoDup.Value
            mValor = CDec(Me.txt_blValordup.Text)

            Try
                If Not mDocumento.Equals("") AndAlso IsDate(mVencimento) AndAlso CDec(mValor) <> _valorZERO Then
                    Dim mlinha As String() = {mTipo, mDocumento, mEmissao, mVencimento, mValor}

                    'Adicionando Linha
                    Me.dtg_boletos.Rows(_BoletoEditado - 1).SetValues(mlinha)
                    _BoletoEditado = _valorZERO
                    Me.dtg_boletos.Refresh()

                    If returnVlBoletosGrid() <> CDec(Me.txt_nfvltgeral.Text) Then

                        Me.dtg_boletos.Rows(Me.dtg_boletos.Rows.Count - 1).Cells(4).Value = _
                        Format(CDec(Round((Me.dtg_boletos.Rows(Me.dtg_boletos.Rows.Count - 1).Cells(4).Value + _
                                (CDec(Me.txt_nfvltgeral.Text) - returnVlBoletosGrid())), 2)), "###,##0.00")

                    End If

                    If Me.dtg_boletos.Rows.Count + 1 > CInt(Me.txt_blParcelas.Text) Then

                        Me.txt_blNumduplic.Enabled = False : Me.txt_blValordup.Enabled = False
                        Me.dtp_blVenctoDup.Enabled = False

                    End If

                    mlinha = Nothing : Me.txt_blNumduplic.Text = ""
                    Me.txt_blValordup.Text = Format(0.0, "###,##0.00")
                    Me.dtp_blVenctoDup.Text = ""

                End If

            Catch ex As Exception
                MsgBox("Deu ERRO ao Incluir este Boleto " & ex.Message, MsgBoxStyle.Exclamation)
            End Try
        Catch ex As Exception
        End Try



    End Sub

    Private Sub DeleteDataGridBoletos()

        Try

            If Me.dtg_boletos.Enabled = True AndAlso Me.dtg_boletos.Rows.Count > _valorZERO Then

                If (Me.dtg_boletos.CurrentRow.Index + 1) = Me.dtg_boletos.Rows.Count Then

                    'Remove Linha
                    mVlTotParcelas = returnVlBoletosGrid()
                    If Not Me.txt_nfnumero.Text.Equals("") Then

                        Me.txt_blNumduplic.Text = RTrim(Me.txt_nfnumero.Text) & "-" & Me.dtg_boletos.Rows.Count + 1

                    Else
                        Me.txt_blNumduplic.Text = RTrim(Me.txt_xmnumero.Text) & "-" & Me.dtg_boletos.Rows.Count + 1

                    End If

                    Dim dt As String = Format(CDate(Me.dtg_boletos.Rows(Me.dtg_boletos.Rows.Count - 1).Cells(3).Value), "dd/MM/yyyy")
                    Dim ano As Integer = CInt(dt.Substring(6, 4))
                    Dim mes As Integer = CInt(dt.Substring(3, 2))
                    Dim dia As Integer = CInt(dt.Substring(_valorZERO, 2))
                    mes += 1

                    If mes > 12 Then mes = 1 : ano += 1

                    Me.dtp_blVenctoDup.Text = Format(DateSerial(ano, mes, dia), "ddMMyyyy")
                    dt = Nothing : ano = Nothing : mes = Nothing : dia = Nothing

                    _BoletoEditado = _valorZERO


                    If Not Me.txt_nfvltgeral.Text.Equals("") Then

                        If IsNumeric(Me.txt_nfvltgeral.Text) AndAlso CDbl(Me.txt_nfvltgeral.Text) > _valorZERO Then


                            If Me.dtg_boletos.Rows.Count < CInt(Me.txt_blParcelas.Text) Then

                                If Me.dtg_boletos.Rows.Count + 1 = CInt(Me.txt_blParcelas.Text) Then 'Se a proxima parcela for a última

                                    Me.txt_blValordup.Text = Format(CDec(Round((CDec(Me.txt_nfvltgeral.Text) - mVlTotParcelas), 2)), "###,##0.00")

                                Else
                                    Me.txt_blValordup.Text = Format(CDec(Round((Me.txt_nfvltgeral.Text / CInt(Me.txt_blParcelas.Text)), 2)), "###,##0.00")

                                End If
                            Else
                                Me.txt_blValordup.Text = Format(CDec(Round((Me.txt_nfvltgeral.Text / CInt(Me.txt_blParcelas.Text)), 2)), "###,##0.00")

                            End If

                        Else

                            If Me.dtg_boletos.Rows.Count < CInt(Me.txt_blParcelas.Text) Then

                                If Me.dtg_boletos.Rows.Count + 1 = CInt(Me.txt_blParcelas.Text) Then 'Se a proxima parcela for a última

                                    Me.txt_blValordup.Text = Format(CDec(Round((CDec(Me.lbl_xmVlTot.Text) - mVlTotParcelas), 2)), "###,##0.00")

                                Else
                                    Me.txt_blValordup.Text = Format(CDec(Round((Me.lbl_xmVlTot.Text / CInt(Me.txt_blParcelas.Text)), 2)), "###,##0.00")

                                End If
                            Else
                                Me.txt_blValordup.Text = Format(CDec(Round((Me.lbl_xmVlTot.Text / CInt(Me.txt_blParcelas.Text)), 2)), "###,##0.00")

                            End If
                        End If

                    Else

                        If Me.dtg_boletos.Rows.Count < CInt(Me.txt_blParcelas.Text) Then

                            If Me.dtg_boletos.Rows.Count + 1 = CInt(Me.txt_blParcelas.Text) Then 'Se a proxima parcela for a última

                                Me.txt_blValordup.Text = Format(CDec(Round((CDec(Me.lbl_xmVlTot.Text) - mVlTotParcelas), 2)), "###,##0.00")

                            Else
                                Me.txt_blValordup.Text = Format(CDec(Round((Me.lbl_xmVlTot.Text / CInt(Me.txt_blParcelas.Text)), 2)), "###,##0.00")

                            End If
                        Else
                            Me.txt_blValordup.Text = Format(CDec(Round((Me.lbl_xmVlTot.Text / CInt(Me.txt_blParcelas.Text)), 2)), "###,##0.00")

                        End If
                    End If

                    Me.dtg_boletos.Rows.Remove(Me.dtg_boletos.CurrentRow)
                    Me.dtg_boletos.Refresh() : Me.txt_blNumduplic.Enabled = True
                    Me.txt_blValordup.Enabled = True : Me.dtp_blVenctoDup.Enabled = True

                End If
            End If

        Catch ex As Exception
            MsgBox("Deu ERRO ao Deletar este Boleto " & ex.Message, MsgBoxStyle.Exclamation)
        End Try



    End Sub

    Private Sub dtg_boletos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_boletos.DoubleClick

        Dim mDocumento As String
        Dim mVencimento As Date
        Dim mValor As Decimal

        Try
            _BoletoEditado = (Me.dtg_boletos.CurrentRow.Index + 1)
            mDocumento = Me.dtg_boletos.CurrentRow.Cells(1).Value
            mVencimento = Me.dtg_boletos.CurrentRow.Cells(3).Value
            mValor = Me.dtg_boletos.CurrentRow.Cells(4).Value

            Me.txt_blNumduplic.Enabled = True : Me.txt_blValordup.Enabled = True
            Me.dtp_blVenctoDup.Enabled = True : Me.txt_blNumduplic.Text = mDocumento
            Me.dtp_blVenctoDup.Text = Format(mVencimento, "ddMMyyyy")
            Me.txt_blValordup.Text = mValor

            Me.txt_blNumduplic.Focus() : Me.txt_blNumduplic.SelectAll()
            mDocumento = Nothing : mVencimento = Nothing : mValor = Nothing

        Catch ex As Exception
        End Try



    End Sub

    Private Function returnVlBoletosGrid() As Decimal

        Dim vlBoletos As Decimal = 0.0

        'Percorre o GridView Boletos
        For Each row As DataGridViewRow In Me.dtg_boletos.Rows

            If Not row.IsNewRow Then vlBoletos += CDec(row.Cells(4).Value)

        Next 'fim For GridView Boletos



        Return CDec(Round(vlBoletos, 2))
    End Function

    Private Sub btn_delBol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delBol.Click

        DeleteDataGridBoletos() : Me.txt_blNumduplic.Focus() : Me.txt_blNumduplic.SelectAll()

    End Sub

    Private Sub cbo_blPlanoPgto_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_blPlanoPgto.GotFocus

        If Not (Me.cbo_blPlanoPgto.DroppedDown) Then Me.cbo_blPlanoPgto.DroppedDown = True 'AndAlso Me.cbo_cstProd.Text.Equals("") 

    End Sub

    Private Sub txt_blValordup_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_blValordup.Leave

        If IsNumeric(Me.txt_blValordup.Text) Then

            If CDec(Me.txt_blValordup.Text) <= _valorZERO Then

                MsgBox("Valor da Duplicata deve ser maior que ZERO", MsgBoxStyle.Exclamation)
                Me.txt_blValordup.Focus() : Me.txt_blValordup.SelectAll()

            Else
                Me.txt_blValordup.Text = Format(CDec(Me.txt_blValordup.Text), "###,##0.00")

            End If
        End If



    End Sub

    Private Sub txt_blValordup_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_blValordup.KeyPress
        'permite só numeros com virgulas
        If _clFunc.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub msk_blVenctoDup_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'permite só numeros sem ponto e sem virgula
        If _clFunc.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_blParcelas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_blParcelas.KeyPress
        'permite só numeros sem ponto e sem virgula
        If _clFunc.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub msk_blVenctoDup_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Not IsDate(Me.dtp_blVenctoDup.Value) Then

            MsgBox("Data do Vencimento inválida", MsgBoxStyle.Exclamation)
            Me.dtp_blVenctoDup.Focus() : Me.dtp_blVenctoDup.Select()

        Else

            If _importXml = False Then

                If Me.dtp_blVenctoDup.Value < CDate(Me.Msk_nfemissao.Text) Then

                    MsgBox("Data do Vencimento deve ser maior que a Data de Emissao", MsgBoxStyle.Exclamation)
                    Me.dtp_blVenctoDup.Focus() : Me.dtp_blVenctoDup.Select()

                End If

            Else

                If CDate(Me.dtp_blVenctoDup.Text) < CDate(Me.msk_xmemissao.Text) Then

                    MsgBox("Data do Vencimento deve ser maior que a Data de Emissao", MsgBoxStyle.Exclamation)
                    Me.dtp_blVenctoDup.Focus() : Me.dtp_blVenctoDup.Select()

                End If
            End If

        End If



    End Sub

    Private Sub txt_nfserie_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nfserie.Leave

        If _editaNota = False Then 'Se não for edição da nota, então verifica se a nota existe no banco

            If Not Me.txt_codPart.Text.Equals("") AndAlso Not Me.txt_nfnumero.Text.Equals("") _
            AndAlso Not Me.txt_nfserie.Text.Equals("") Then

                Try

                    If verifNotaExist(Me.txt_codPart.Text, Me.txt_nfnumero.Text, Me.txt_nfserie.Text) Then

                        MsgBox("Essa Nota já existe no banco de dados", MsgBoxStyle.Exclamation)
                        Me.txt_nfserie.Focus() : Me.txt_nfserie.SelectAll() : Return

                    End If
                Catch ex As Exception
                End Try

            ElseIf Me.txt_nfserie.Text.Equals("") Then

                lbl_mensagen.Text = "Informe a Serie da Nota por favor !"
                Return

            End If
        End If
        lbl_mensagen.Text = ""



    End Sub

    Private Function verifNotaExist(ByVal CodForn As String, ByVal numeroDoc As String, ByVal serie As String) As Boolean
        Dim mExistNota As Boolean = False
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            mExistNota = False : Return mExistNota

        End Try

        Dim sqlNF As New StringBuilder
        Dim cmdNF As NpgsqlCommand
        Dim drNF As NpgsqlDataReader

        Try
            sqlNF.Append("SELECT * FROM " & MdlEmpresaUsu._esqEstab & ".Nota4ff WHERE n4_numer = '" & numeroDoc & "' AND n4_cdport = '" & CodForn)
            sqlNF.Append("' AND n4_serie = '" & serie & "'")
            cmdNF = New NpgsqlCommand(sqlNF.ToString, oConnBDGENOV)
            drNF = cmdNF.ExecuteReader

            'Se existir a NotaFiscal
            If drNF.HasRows = True Then mExistNota = True
            cmdNF.CommandText = ""

        Catch ex As Exception
        End Try

        sqlNF.Remove(_valorZERO, sqlNF.ToString.Length) : oConnBDGENOV.ClearPool()
        oConnBDGENOV.Close() : cmdNF = Nothing : sqlNF = Nothing : oConnBDGENOV = Nothing



        Return mExistNota
    End Function

    Private Sub txt_numDocPesq_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numDocPesq.KeyPress
        'permite só numeros sem ponto e sem virgula
        If _clFunc.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_numDocPesq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numDocPesq.Click

        Me.txt_numDocPesq.SelectAll()

    End Sub

    Private Sub txt_numDocPesq_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_numDocPesq.KeyDown

        If e.KeyCode = Keys.Enter Then

            If IsNumeric(Me.txt_numDocPesq.Text) AndAlso CInt(Me.txt_numDocPesq.Text) > _valorZERO Then

                Me.txt_numDocPesq.Text = String.Format("{0:D9}", Convert.ToInt32(Me.txt_numDocPesq.Text))
                Me.ConsultaBD("WHERE n4_numer = '" & Me.txt_numDocPesq.Text & "' " & trazConsulNumDoc())
                Me.txt_numDocPesq.Focus() : Me.txt_numDocPesq.SelectAll()

            Else
                Me.ConsultaBD(trazConsulNumDoc()) : Me.txt_numDocPesq.Focus() : Me.txt_numDocPesq.SelectAll()

            End If
        End If



    End Sub

    Private Function trazConsulNumDoc() As String

        Dim mConsul As String = ""

        If IsNumeric(Me.txt_numDocPesq.Text) AndAlso CInt(Me.txt_numDocPesq.Text) > _valorZERO Then
            'Consulta por Fonecedor
            If Not _mCodFonecedor.Equals("") AndAlso chk_FornConsuta.Checked = True Then mConsul = "AND n4_cdport = '" & _mCodFonecedor & "' "

            'Consulta por Especie
            If cbo_EspecConsulta.SelectedIndex > _valorZERO Then mConsul = "AND n4_espec = '" & Me.cbo_EspecConsulta.Text & "' "

            'Consulta por Período
            Select Case cbo_consulta.SelectedIndex
                Case _valorZERO 'Todas as Notas
                    mConsul += "ORDER BY n4_dtent DESC"

                Case 1 'As últimas 10 Notas
                    mConsul += "ORDER BY n4_dtent DESC LIMIT 10"

                Case 2 'Notas da data atual
                    mConsul += "AND n4_dtent = CURRENT_DATE ORDER BY n4_dtent DESC"

                Case 3 'Notas apartir do ultimo mes
                    mConsul += "AND n4_dtent BETWEEN date_trunc('month',CURRENT_DATE - " & _
                    "INTERVAL '1 month')::date AND CURRENT_DATE ORDER BY n4_dtent ASC"

                Case 4 'Notas apartir do ultimo ano
                    mConsul += "AND n4_dtent BETWEEN date_trunc('year',CURRENT_DATE - " & _
                    "INTERVAL '1 year')::date AND CURRENT_DATE ORDER BY n4_dtent ASC"

                Case 5 'data personalizada
                    'valida as datas
                    If IsDate(Me.msk_dtInicio.Text) AndAlso IsDate(Me.msk_dtFim.Text) Then mConsul += "AND n4_dtent BETWEEN '" & _
                    Me.msk_dtInicio.Text & "' AND '" & Me.msk_dtFim.Text & "' ORDER BY n4_dtent ASC"

            End Select

        Else
            'Consulta por Fonecedor
            If Not _mCodFonecedor.Equals("") AndAlso chk_FornConsuta.Checked = True Then mConsul = "WHERE n4_cdport = '" & _mCodFonecedor & "' "

            'Consulta por Especie
            If cbo_EspecConsulta.SelectedIndex > _valorZERO Then

                If mConsul.Equals("") Then

                    mConsul = "WHERE n4_espec = '" & Me.cbo_EspecConsulta.Text & "' "

                Else
                    mConsul = "AND n4_espec = '" & Me.cbo_EspecConsulta.Text & "' "

                End If
            End If


            'Consulta por Período
            Select Case cbo_consulta.SelectedIndex
                Case _valorZERO 'Todas as Notas
                    mConsul += "ORDER BY n4_dtent DESC"

                Case 1 'As últimas 10 Notas
                    mConsul += "ORDER BY n4_dtent DESC LIMIT 10"

                Case 2 'Notas da data atual
                    If mConsul.Equals("") Then

                        mConsul += "WHERE n4_dtent = CURRENT_DATE ORDER BY n4_dtent DESC"

                    Else
                        mConsul += "AND n4_dtent = CURRENT_DATE ORDER BY n4_dtent DESC"

                    End If

                Case 3 'Notas apartir do ultimo mes
                    If mConsul.Equals("") Then

                        mConsul += "WHERE n4_dtent BETWEEN date_trunc('month',CURRENT_DATE - " & _
                        "INTERVAL '1 month')::date AND CURRENT_DATE ORDER BY n4_dtent ASC"

                    Else
                        mConsul += "AND n4_dtent BETWEEN date_trunc('month',CURRENT_DATE - " & _
                        "INTERVAL '1 month')::date AND CURRENT_DATE ORDER BY n4_dtent ASC"

                    End If

                Case 4 'Notas apartir do ultimo ano
                    If mConsul.Equals("") Then

                        mConsul += "WHERE n4_dtent BETWEEN date_trunc('year',CURRENT_DATE - " & _
                        "INTERVAL '1 year')::date AND CURRENT_DATE ORDER BY n4_dtent ASC"

                    Else
                        mConsul += "AND n4_dtent BETWEEN date_trunc('year',CURRENT_DATE - " & _
                        "INTERVAL '1 year')::date AND CURRENT_DATE ORDER BY n4_dtent ASC"

                    End If

                Case 5 'data personalizada
                    'valida as datas
                    If IsDate(Me.msk_dtInicio.Text) AndAlso IsDate(Me.msk_dtFim.Text) Then

                        If mConsul.Equals("") Then

                            mConsul += "WHERE n4_dtent BETWEEN '" & _
                            Me.msk_dtInicio.Text & "' AND '" & Me.msk_dtFim.Text & "' ORDER BY n4_dtent ASC"

                        Else

                            mConsul += "AND n4_dtent BETWEEN '" & _
                            Me.msk_dtInicio.Text & "' AND '" & Me.msk_dtFim.Text & "' ORDER BY n4_dtent ASC"

                        End If
                    End If


            End Select
        End If



        Return mConsul
    End Function

    Private Sub DtgConsultaNotas_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles DtgConsultaNotas.SortCompare

        Dim DataValida As Date
        'VERIFICA SE A COLUNA É DO TIPO DATA PARA FAZER A COMPARAÇÃO
        If DateTime.TryParse(e.CellValue1, DataValida) = False Then
            e.SortResult = System.String.Compare(e.CellValue2, e.CellValue1)

        Else 'CASO A COLUNA NÃO SEJA UMA DATA VALIDA COMPARA STRING

            If DateTime.TryParse(e.CellValue1, DataValida) = False Then

                e.SortResult = -1

            Else
                e.SortResult = System.DateTime.Compare(CType(e.CellValue2, Date), CType(e.CellValue1, Date))

            End If
        End If

        e.Handled = True



    End Sub

    Private Function trazIdN4ff(ByVal mSerie As String, ByVal mNumeroNF As String, ByVal mCodForn As String) As Int32

        Dim idN4ff_ As Int32 = _valorZERO
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return idN4ff_

        End Try

        Dim sqlNF As New StringBuilder
        Dim cmdNF As NpgsqlCommand
        Dim drNF As NpgsqlDataReader

        mSerie = txt_nfserie.Text : mNumeroNF = Me.txt_nfnumero.Text
        mCodForn = Me.txt_codPart.Text
        sqlNF.Append("SELECT n4_id FROM " & MdlEmpresaUsu._esqEstab & ".Nota4ff WHERE n4_numer = '" & mNumeroNF & "' AND ")
        sqlNF.Append(" n4_cdport = '" & mCodForn & "' AND n4_serie = '" & mSerie & "'")
        cmdNF = New NpgsqlCommand(sqlNF.ToString, oConnBDGENOV)
        drNF = cmdNF.ExecuteReader
        While drNF.Read

            idN4ff_ = drNF(_valorZERO)
        End While
        drNF.Close() : oConnBDGENOV.ClearPool() : oConnBDGENOV.Close()
        cmdNF = Nothing : sqlNF = Nothing : drNF = Nothing



        Return idN4ff_
    End Function

    Private Sub txt_codPart_KeyDownExtracted(ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try

            'preenche CBO CFOP...
            If Not mbUf.Equals("") Then

                Dim mUfEstab As String = "PI" 'UF global da Empresa
                Me.cbo_nfcfop = _clFunc.PreenchComboCfopEntradas(mUfEstab, mbUf, Me.cbo_nfcfop, MdlConexaoBD.conectionPadrao)
                Me.cbo_itcfop = _clFunc.PreenchComboCfopEntradas(mUfEstab, mbUf, Me.cbo_itcfop, MdlConexaoBD.conectionPadrao)
                mUfEstab = Nothing

            End If

            Me.cbo_nfcfop.Text = "" : Me.cbo_itcfop.Text = ""
            Me.cbo_nfcfop.SelectedIndex = -1 : Me.cbo_itcfop.SelectedIndex = -1
            Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()

            shouldReturn = True : Return
        Catch ex As Exception
        End Try



    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown

        If Not Me.txt_codPart.Text.Equals("") Then

            If Me.txt_codPart.TextLength > 5 AndAlso e.KeyCode = Keys.Enter Then 'Se retornar nada

                If trazFornecedor(Me.txt_codPart.Text) Then

                    _formBusca = False : Dim lShouldReturn As Boolean
                    txt_codPart_KeyDownExtracted(lShouldReturn)
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing

                End If
            End If
        End If


        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

            If Me.txt_codPart.Text.Equals("") Then
                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    _formBusca = True : _mPesquisaForn = False : _frmREf = Me
                    _BuscaForn.set_frmRef(Me) : _BuscaForn.ShowDialog(Me) : _formBusca = False
                    If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus()

                    Dim lShouldReturn As Boolean
                    txt_codPart_KeyDownExtracted(lShouldReturn)
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing

                Catch ex As Exception
                End Try

            End If
        End If



    End Sub

    Private Function txt_codProd_KeyDownTrazIndexCfop(ByVal clfProd As String, ByVal cstProd As Integer, _
                                                      ByVal cfvProd As Integer, ByVal cfopNota As String, _
                                                      ByVal cbo_cfop As Object) As Integer

        Dim mIndex As Integer = -1
        If cfopNota.Substring(0, 1).Equals("1") Then 'Se o Fornecedor for de fora

            If clfProd.Equals("00") AndAlso cstProd = 2 AndAlso cfvProd = 1 Then mIndex = trazIndexCfop("1.102", cbo_cfop)
            If clfProd.Equals("00") AndAlso cstProd = 0 AndAlso cfvProd = 1 Then mIndex = trazIndexCfop("1.102", cbo_cfop)
            If clfProd.Equals("00") AndAlso cstProd = 6 AndAlso cfvProd = 3 Then mIndex = trazIndexCfop("1.403", cbo_cfop)
            If clfProd.Equals("00") AndAlso cstProd = 0 AndAlso cfvProd = 4 Then mIndex = trazIndexCfop("1.102", cbo_cfop)

        Else

            If clfProd.Equals("00") AndAlso cstProd = 2 AndAlso cfvProd = 1 Then mIndex = trazIndexCfop("2.102", cbo_cfop)
            If clfProd.Equals("00") AndAlso cstProd = 0 AndAlso cfvProd = 1 Then mIndex = trazIndexCfop("2.102", cbo_cfop)
            If clfProd.Equals("00") AndAlso cstProd = 6 AndAlso cfvProd = 3 Then mIndex = trazIndexCfop("2.403", cbo_cfop)
            If clfProd.Equals("00") AndAlso cstProd = 0 AndAlso cfvProd = 4 Then mIndex = trazIndexCfop("2.102", cbo_cfop)

        End If



        Return mIndex
    End Function

    Private Function txt_codProd_KeyDownTrazIndexCST(ByVal clfProd As String, ByVal cstProd As Integer, _
                                                      ByVal cfvProd As Integer, ByVal cfopNota As String, _
                                                      ByVal cbo_cfop As Object) As Integer

        Dim mIndex As Integer = -1
        If mReduzIten <> 0 Then

            mIndex = trazIndexCST("20", cbo_cfop)

        Else

            If cfopNota.Substring(0, 1).Equals("1") Then 'Se o Fornecedor for de fora

                If clfProd.Equals("00") AndAlso cstProd = 2 AndAlso cfvProd = 1 Then mIndex = trazIndexCST("00", cbo_cfop)
                If clfProd.Equals("00") AndAlso cstProd = 0 AndAlso cfvProd = 1 Then mIndex = trazIndexCST("00", cbo_cfop)
                If clfProd.Equals("00") AndAlso cstProd = 6 AndAlso cfvProd = 3 Then mIndex = trazIndexCST("60", cbo_cfop)
                If clfProd.Equals("00") AndAlso cstProd = 0 AndAlso cfvProd = 4 Then mIndex = trazIndexCST("40", cbo_cfop)

            Else

                If clfProd.Equals("00") AndAlso cstProd = 2 AndAlso cfvProd = 1 Then mIndex = trazIndexCST("00", cbo_cfop)
                If clfProd.Equals("00") AndAlso cstProd = 0 AndAlso cfvProd = 1 Then mIndex = trazIndexCST("00", cbo_cfop)
                If clfProd.Equals("00") AndAlso cstProd = 6 AndAlso cfvProd = 3 Then mIndex = trazIndexCST("60", cbo_cfop)
                If clfProd.Equals("00") AndAlso cstProd = 0 AndAlso cfvProd = 4 Then mIndex = trazIndexCST("40", cbo_cfop)

            End If

        End If



        Return mIndex
    End Function

    Private Sub txt_codProd_KeyDownExtracted()

        'tratamento do CFOP dos itens, pega o CFOP do registro da nota e Set ele nos Itens
        Dim mCfopCbo As String = Me.cbo_nfcfop.Text.Substring(_valorZERO, 5)

        If mNF_Cfop.Substring(2, 3).Equals("102") OrElse mNF_Cfop.Substring(2, 3).Equals("403") _
        OrElse mNF_Cfop.Substring(2, 3).Equals("409") Then

            Me.cbo_itcfop.SelectedIndex = txt_codProd_KeyDownTrazIndexCfop(mClfIten, mCstIten, mCfvIten, mCfopCbo, Me.cbo_itcfop)
            If cbo_itcfop.SelectedIndex < 0 Then

                Me.cbo_itcfop.SelectedIndex = trazIndexCfop(mCfopCbo, Me.cbo_itcfop)
                If CDec(Me.txt_nfbasesub.Text) > _valorZERO Then Me.cbo_itcfop.SelectedIndex = trazIndexCfop(mCfopCbo.Substring(0, 1) & ".403", Me.cbo_itcfop)

            End If


            'tratamento do CST dos itens
            Me.cbo_cstProd.SelectedIndex = txt_codProd_KeyDownTrazIndexCST(mClfIten, mCstIten, mCfvIten, mCfopCbo, Me.cbo_cstProd)
            If Me.cbo_cstProd.SelectedIndex < 0 Then

                Me.cbo_cstProd.SelectedIndex = trazIndexCST("00", Me.cbo_cstProd)
                If CDec(Me.txt_nfbasesub.Text) > _valorZERO Then Me.cbo_cstProd.SelectedIndex = trazIndexCST("60", Me.cbo_cstProd)

            End If

        ElseIf mNF_Cfop.Substring(2, 3).Equals("908") OrElse mNF_Cfop.Substring(2, 3).Equals("556") _
        OrElse mNF_Cfop.Substring(2, 3).Equals("910") OrElse mNF_Cfop.Substring(2, 3).Equals("908") _
        OrElse mNF_Cfop.Substring(2, 3).Equals("949") Then

            Me.cbo_itcfop.SelectedIndex = trazIndexCfop(mNF_Cfop, Me.cbo_itcfop)
            Me.cbo_cstProd.SelectedIndex = trazIndexCST("90", Me.cbo_cstProd)

        End If



    End Sub

    Private Sub txt_codProd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codProd.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then


            If Me.txt_codProd.Text.Equals("") Then

                'Aqui tenta chamar a Busca do Produto...
                Try
                    _formBusca = True : _frmREf = Me : _BuscaProd.set_frmRef(Me)
                    _BuscaProd.ShowDialog(Me) : _formBusca = False
                    If Me.txt_codProd.Text.Equals("") Then Me.txt_codProd.Focus()
                    txt_codProd_KeyDownExtracted()

                Catch ex As Exception
                End Try

            Else

                If trazItenBD(Me.txt_codProd.Text) = False Then

                    'Aqui tenta chamar a Busca do Produto...
                    Try
                        _formBusca = True : _frmREf = Me : _BuscaProd.set_frmRef(Me)
                        _BuscaProd.ShowDialog(Me) : _formBusca = False
                        If Me.txt_codProd.Text.Equals("") Then Me.txt_codProd.Focus()
                        txt_codProd_KeyDownExtracted()

                    Catch ex As Exception
                    End Try

                Else
                    txt_codProd_KeyDownExtracted()

                End If
            End If
        End If



    End Sub

    Public Function trazFornecedor(ByVal codFornec As String) As Boolean

        Dim nomeCampo As String = "", nomeCampoCgc As String = "", nomeCampoCpf As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader
        Dim pesquisa As String = codFornec.ToUpper

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

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
                    If Not drParticipante(2).ToString.Equals("") Then 'se tiver CNPJ...

                        cpf_cnpj = drParticipante(2).ToString

                    Else

                        cpf_cnpj = drParticipante(3).ToString

                    End If
                    inscricao = drParticipante(4).ToString
                    UF = drParticipante(5).ToString

                End While
                drParticipante.Close() : oConnBDGENOV.ClearPool()
                Me.txt_nomePart.Text = nome : Me.mbCNPJ = cpf_cnpj : Me.mbUf = UF


            End If

        Catch ex As Exception
        End Try

        CmdParticipante.CommandText = ""
        SqlParticipante.Remove(_valorZERO, SqlParticipante.ToString.Length)
        oConnBDGENOV.Close()

        'LIMPA OBJETOS DA MEMÓRIA...
        nomeCampo = Nothing : nomeCampoCgc = Nothing : nomeCampoCpf = Nothing : oConnBDGENOV = Nothing
        CmdParticipante = Nothing : SqlParticipante = Nothing : drParticipante = Nothing
        pesquisa = Nothing : codigo = Nothing : nome = Nothing : cpf_cnpj = Nothing
        inscricao = Nothing : UF = Nothing



        Return True
    End Function

    Private Sub tbc_compras_SelectedIndexChangedExtracted()

        Me.tbp_importXml.Enabled = True : tbp_lancanotas.Enabled = False
        tbp_Itensnotas.Enabled = False : tbp_contasapagar.Enabled = False : lbl_mensagen.Text = ""

    End Sub

    Private Sub tbc_compras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbc_compras.SelectedIndexChanged

        Select Case tbc_compras.SelectedIndex
            Case _valorZERO
                'Se a Nota estiver no processo de Edição
                If _editaNota = True Then

                    If MessageBox.Show("Processo de Edição em aberto Deseja Cancelar?", "Genov", MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Me.zeraValoresRegNF() : Me.zeraValoresItemNF() : Me.zeraValoresDuplicat()
                        If Me.dtg_itensCompras.Rows.Count > _valorZERO Then Me.dtg_itensCompras.Rows.Clear()
                        Me.atualizSomaVlItens() : tbc_compras_SelectedIndexChangedExtracted()
                        Me.tbc_compras.SelectTab(_valorZERO) : _editaNota = False

                    Else
                        Me.tbc_compras.SelectTab(1) : Me.btn_salvar.Focus()

                    End If
                End If

                'Se a Nota estiver no processo de Importação do XML
                If _importXml = True AndAlso Not Me.txt_xmnumero.Text.Equals("") Then

                    If MessageBox.Show("Processo de Importação do XML em aberto Deseja Cancelar?", "Genov", MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Me.zeraValoresNfXml() : Me.atuaXmlVlTotal() : Me.zeraValoresDuplicat()
                        tbc_compras_SelectedIndexChangedExtracted()
                        Me.tbc_compras.SelectTab(_valorZERO)
                        _importXml = False : posNextProd = _valorZERO

                    Else
                        Me.tbc_compras.SelectTab(4) : Me.btn_xmsair.Focus()

                    End If
                End If

            Case 3 'aba de contas a pagar
                'Se a Nota não estiver no processo de Edição e nem de Visualização
                If _editaNota = False AndAlso _visualizaNota = False Then

                    If CDbl(Me.txt_nfvltgeral.Text) > 0.0 OrElse CDbl(Me.lbl_xmVlTot.Text) > 0.0 Then

                        tbp_contasapagar.Enabled = True

                    End If
                End If

            Case 4 'aba de importação do xml

                'Se a Nota não estiver no processo de Edição e nem de Visualização
                If _editaNota = True Then

                    If MessageBox.Show("Processo de Edição em aberto Deseja Cancelar?", "Genov", MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Me.zeraValoresRegNF() : Me.zeraValoresItemNF() : Me.zeraValoresDuplicat()
                        If Me.dtg_itensCompras.Rows.Count > _valorZERO Then Me.dtg_itensCompras.Rows.Clear()
                        Me.atualizSomaVlItens() : tbc_compras_SelectedIndexChangedExtracted()
                        Me.tbc_compras.SelectTab(4) : _editaNota = False

                    Else
                        Me.tbc_compras.SelectTab(1) : Me.btn_salvar.Focus()

                    End If
                End If


                If _visualizaNota = True Then

                    If MessageBox.Show("Processo de Visualização em aberto Deseja Cancelar?", "Genov", MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Me.zeraValoresRegNF() : Me.zeraValoresItemNF()
                        If Me.dtg_itensCompras.Rows.Count > _valorZERO Then Me.dtg_itensCompras.Rows.Clear()
                        Me.zeraValoresDuplicat() : Me.atualizSomaVlItens()
                        tbc_compras_SelectedIndexChangedExtracted()
                        Me.tbc_compras.SelectTab(4) : _editaNota = False

                    Else
                        Me.tbc_compras.SelectTab(1) : Me.btn_salvar.Focus()

                    End If
                End If

        End Select



    End Sub

    Private Sub btn_SaiBol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SaiBol.Click

        If MessageBox.Show("Deseja Gravar Tudo?", "METROSYS", MessageBoxButtons.YesNo, _
        MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If Me.dtg_itensCompras.Rows.Count > _valorZERO Then

                salvaTudo() : Me.tbp_importXml.Enabled = True

            Else
                salvaValoresXML()

            End If

        Else

            If Me.dtg_itensCompras.Rows.Count > _valorZERO Then

                Me.tbc_compras.SelectTab(1) : Me.btn_salvar.Focus()

            Else
                Me.tbc_compras.SelectTab(3) : Me.btn_xmsair.Focus()

            End If

        End If
        lbl_mensagen.Text = ""



    End Sub

    Private Sub btn_altera_ClickExtracted()

        Me.tbp_importXml.Enabled = False : Me.tbp_lancanotas.Enabled = True : Me.tbc_compras.SelectTab(1)
        Me.tbp_lancanotas.Focus() : Me.tbp_Itensnotas.Enabled = True : Me.tbp_contasapagar.Enabled = False
        Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll() : lbl_mensagen.Text = ""

    End Sub

    Private Sub btn_altera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_altera.Click

        Try


            If DtgConsultaNotas.CurrentRow.Index >= _valorZERO Then

                'Se a Nota estiver no processo de Edição
                If _editaNota = True Then

                    If MessageBox.Show("Processo de Edição em aberto, deseja Cancelá-lo?", "METROSYS", MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        'primeiro zera os valores
                        Me.zeraValoresRegNF() : Me.zeraValoresItemNF() : Me.zeraValoresDuplicat()
                        If Me.dtg_itensCompras.Rows.Count > _valorZERO Then Me.dtg_itensCompras.Rows.Clear()
                        Me.atualizSomaVlItens() : tbp_lancanotas.Enabled = False
                        tbp_Itensnotas.Enabled = False : tbp_contasapagar.Enabled = False
                        Me.tbc_compras.SelectTab(_valorZERO) : _editaNota = False
                        mIDn4FF = DtgConsultaNotas.CurrentRow.Cells(_valorZERO).Value
                        _editaNota = True : preenchValoresReg(mIDn4FF) : preenchValoresItens(mIDn4FF)
                        atualizSomaVlItens() : btn_altera_ClickExtracted()

                    End If

                ElseIf _visualizaNota = True Then

                    abilitElementsItens() : _visualizaNota = False
                    If Me.dtg_itensCompras.Rows.Count > _valorZERO Then

                        Me.dtg_itensCompras.Rows.Clear() : Me.dtg_itensCompras.Refresh()

                    End If

                    Me.zeraValoresRegNF() : Me.zeraValoresItemNF() : Me.zeraValoresDuplicat()
                    Me.atualizSomaVlItens() : Me.tbp_lancanotas.Enabled = True
                    Me.tbp_Itensnotas.Enabled = False : Me.tbp_contasapagar.Enabled = False
                    Me.tbc_compras.SelectTab(1) : Me.txt_codPart.Focus()

                    mIDn4FF = DtgConsultaNotas.CurrentRow.Cells(_valorZERO).Value
                    _editaNota = True : preenchValoresReg(mIDn4FF) : preenchValoresItens(mIDn4FF)
                    atualizSomaVlItens() : btn_altera_ClickExtracted()

                Else

                    mIDn4FF = DtgConsultaNotas.CurrentRow.Cells(_valorZERO).Value
                    _editaNota = True : preenchValoresReg(mIDn4FF) : preenchValoresItens(mIDn4FF)
                    atualizSomaVlItens()

                    'Alimenta o objeto = _itensAnteriores que irá armazenar o código e a qtde dos 
                    'ítens anteriores
                    'Percorre o GridView
                    For Each row As DataGridViewRow In Me.dtg_itensCompras.Rows

                        If Not row.IsNewRow Then

                            _itensAnteriores.Append(row.Cells(_valorZERO).Value & "|" & CDbl(row.Cells(6).Value) & "?")

                        End If

                    Next 'fim For GridView

                    btn_altera_ClickExtracted()
                End If
            End If

        Catch ex As Exception
        End Try



    End Sub

    Private Sub preenchValoresReg(ByVal idN4ff As Int32)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlNF As New StringBuilder
        Dim cmdNF As NpgsqlCommand
        Dim drNF As NpgsqlDataReader

        sqlNF.Append("SELECT n4_cdport, SUBSTR(cad.p_portad, 1, 60), n4_estab, n4_numer, n4_serie, n4_espec, ")
        sqlNF.Append("to_char(n4_dtemis, 'DD/MM/YYYY'), to_char(n4_dtent, 'DD/MM/YYYY'), n4_tipo, n4_chave, ")
        sqlNF.Append("n4_cdfisc, n4_tprod, n4_basec, n4_aliq, n4_icms, n4_bsub, n4_icsub, n4_alqipi, n4_ipi, ")
        sqlNF.Append("n4_ipisent, n4_ipoutro, n4_frete, n4_outros, n4_segu, n4_desc, n4_outrasdesp, ")
        sqlNF.Append("n4_tgeral, n4_obs, cad.p_cgc, cad.p_cpf, cad.p_uf FROM " & MdlEmpresaUsu._esqEstab & ".Nota4ff LEFT ")
        sqlNF.Append("JOIN cadp001 cad ON cad.p_cod = n4_cdport WHERE n4_id = " & mIDn4FF)

        cmdNF = New NpgsqlCommand(sqlNF.ToString, oConnBDGENOV)
        drNF = cmdNF.ExecuteReader
        While drNF.Read
            Me.txt_codPart.Text = drNF(_valorZERO)
            Me.txt_nomePart.Text = drNF(1)
            Me.cbo_local.SelectedIndex = _clFunc.trazIndexCboLoja(drNF(2), Me.cbo_local)
            Me.txt_nfnumero.Text = drNF(3)
            Me.txt_nfserie.Text = drNF(4)
            Me.cbo_especie.SelectedIndex = trazIndexEspec(drNF(5), Me.cbo_especie)
            Me.Msk_nfemissao.Text = drNF(6)
            Me.Msk_nfdtent.Text = drNF(7)
            Me.txt_nftipo.Text = drNF(8)
            Me.msk_chavenfe.Text = drNF(9)
            mbUf = drNF(30)

            Dim mUfEstab As String = "PI" 'UF global do estabelecimento
            _clFunc.PreenchComboCfopEntradas(mUfEstab, mbUf, Me.cbo_nfcfop, MdlConexaoBD.conectionPadrao)
            _clFunc.PreenchComboCfopEntradas(mUfEstab, mbUf, Me.cbo_itcfop, MdlConexaoBD.conectionPadrao)
            mUfEstab = Nothing

            Me.cbo_nfcfop.SelectedIndex = trazIndexCfop((Mid(drNF(10), 1, 1) & "." & Mid(drNF(10), 2, 3)), _
                                                        Me.cbo_nfcfop)

            Me.txt_nftprodutos.Text = Format(Round(drNF(11), 2), "##,##0.00")
            Me.txt_nfbscalculo.Text = Format(Round(drNF(12), 2), "##,##0.00")
            Me.txt_nfalqicm.Text = Format(Round(drNF(13), 2), "##,##0.00")
            Me.txt_nfvlicm.Text = Format(Round(drNF(14), 2), "##,##0.00")
            Me.txt_nfbasesub.Text = Format(Round(drNF(15), 2), "##,##0.00")
            Me.txt_nficmsub.Text = Format(Round(drNF(16), 2), "##,##0.00")
            Me.txt_nfalqipi.Text = Format(Round(drNF(17), 2), "##,##0.00")
            Me.txt_nfvlipi.Text = Format(Round(drNF(18), 2), "##,##0.00")
            Me.txt_nfipisento.Text = Format(Round(drNF(19), 2), "##,##0.00")
            Me.txt_nfipioutros.Text = Format(Round(drNF(20), 2), "##,##0.00")
            Me.txt_nfvlfrete.Text = Format(Round(drNF(21), 2), "##,##0.00")
            Me.txt_nfoutros.Text = Format(Round(drNF(22), 2), "##,##0.00")
            Me.txt_nfVlSeguro.Text = Format(Round(drNF(23), 2), "##,##0.00")
            Me.txt_nfDesconto.Text = Format(Round(drNF(24), 2), "##,##0.00")
            Me.txt_nfOutrasDesp.Text = Format(Round(drNF(25), 2), "##,##0.00")
            Me.txt_nfvltgeral.Text = Format(Round(drNF(26), 2), "##,##0.00")
            Me.txt_nfObs.Text = drNF(27).ToString


            If Not drNF(28).ToString.Equals("") Then

                mbCNPJ = drNF(28)

            Else
                mbCNPJ = drNF(29)

            End If

        End While
        drNF.Close() : oConnBDGENOV.ClearPool()
        cmdNF.CommandText = "" : sqlNF.Remove(0, sqlNF.ToString.Length)
        oConnBDGENOV.Close()

        cmdNF = Nothing : sqlNF = Nothing : drNF = Nothing



    End Sub

    Private Sub preenchValoresItens(ByVal idN4ff As Int32)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd As String
        Dim mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd As Decimal
        Dim mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd As Decimal
        Dim mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd As Decimal
        Dim mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd As Decimal
        Dim mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF As Decimal
        Dim idN2ff As Int32
        Dim UndIten As String

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlNF As New StringBuilder
        Dim cmdNF As NpgsqlCommand
        Dim drNF As NpgsqlDataReader

        sqlNF.Append("SELECT nc_id, nc_codpr, nc_produt, nc_cfop, nc_cst, nc_qtde, nc_prunit, ") '6
        sqlNF.Append("nc_desc, nc_vldesc, nc_totbruto, nc_und, nc_prucom, nc_bscalc, nc_alqicm, ") '13
        sqlNF.Append("nc_vlicm, nc_basesub, nc_icmsub, nc_vlicsub, nc_alqipi, nc_vlipi, nc_frete, ") '20
        sqlNF.Append("nc_seguro, nc_outrasdesp, nc_alqnot, nc_prtot, ")
        sqlNF.Append("nc_estab FROM " & MdlEmpresaUsu._esqEstab & ".nota2ff WHERE nc_idn4ff = " & mIDn4FF)

        cmdNF = New NpgsqlCommand(sqlNF.ToString, oConnBDGENOV)
        drNF = cmdNF.ExecuteReader

        If drNF.HasRows = True AndAlso dtg_itensCompras.Columns.Count = _valorZERO Then addColunasItens()
        While drNF.Read
            idN2ff = drNF(_valorZERO) : mCodProd = drNF(1) : mNomeProd = drNF(2)
            mNcmProd = "" : mCfopProd = drNF(3) : mCstProd = drNF(4)
            mCsosnProd = "" : mQtdeProd = drNF(5) : mVlProd = drNF(6)
            mVlPercDesc = drNF(7) : mVlDesc = drNF(8) : mVlTotProd = drNF(9)
            UndIten = drNF(10) : mVlUnitComprProd = drNF(11) : mVlUnitProdNF = drNF(11)

            mVlPercRedProd = Format(0.0, "##,##0.00") 'depois acresentar no nota2ff

            mVlBcIcmsProd = drNF(12) : mVlAlqIcmsProd = drNF(13) : mVlIcmsProd = drNF(14)
            mBcSubsProd = drNF(15) : mVlAlqSubsProd = drNF(16) : mVlSubsProd = drNF(17)
            mVlAlqIpiProd = drNF(18) : mVlIpiProd = drNF(19)

            mVlPercFretProd = Format(0.0, "##,##0.00") 'depois acresentar no nota2ff

            mVlFretProd = drNF(20) : mVlSeguroProd = drNF(21) : mVlDespProd = drNF(22)

            mVlOutrosProd = Format(0.0, "##,##0.00") 'depois acresentar no nota2ff
            mVlCustoProd = Format(0.0, "##,##0.00") 'depois acresentar no nota2ff
            mVlPercLucroProd = Format(0.0, "##,##0.00") 'depois acresentar no nota2ff
            mVlSurgeridoProd = Format(0.0, "##,##0.00") 'depois acresentar no nota2ff


            Dim mlinha As String() = {mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd, mQtdeProd, mVlProd, _
                                      mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd, mVlUnitProdNF, mVlPercRedProd, _
                                      mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd, mVlAlqSubsProd, mVlSubsProd, _
                                      mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd, mVlFretProd, mVlSeguroProd, mVlDespProd, _
                                      mVlOutrosProd, mVlCustoProd, mVlPercLucroProd, mVlSurgeridoProd, UndIten, idN2ff}

            'Adicionando Linha
            Me.dtg_itensCompras.Rows.Add(mlinha) : mlinha = Nothing

        End While
        drNF.Close() : oConnBDGENOV.ClearPool()
        cmdNF.CommandText = "" : sqlNF.Remove(0, sqlNF.ToString.Length)
        oConnBDGENOV.Close()

        Me.dtg_itensCompras.Refresh()
        oConnBDGENOV.Close()

        'LIMPA OBJETOS DA MEMÓRIA...
        cmdNF = Nothing : sqlNF = Nothing : drNF = Nothing : mCodProd = Nothing : mNomeProd = Nothing
        mNcmProd = Nothing : mCfopProd = Nothing : mCstProd = Nothing : mCsosnProd = Nothing
        mQtdeProd = Nothing : mVlProd = Nothing : mVlPercDesc = Nothing : mVlDesc = Nothing
        mVlTotProd = Nothing : mVlUnitComprProd = Nothing : mVlUnitProdNF = Nothing
        mVlPercRedProd = Nothing : mVlBcIcmsProd = Nothing : mVlAlqIcmsProd = Nothing
        mVlIcmsProd = Nothing : mBcSubsProd = Nothing : mVlAlqSubsProd = Nothing
        mVlSubsProd = Nothing : mVlAlqIpiProd = Nothing : mVlIpiProd = Nothing
        mVlPercFretProd = Nothing : mVlFretProd = Nothing : mVlSeguroProd = Nothing
        mVlDespProd = Nothing : mVlOutrosProd = Nothing : mVlCustoProd = Nothing
        mVlPercLucroProd = Nothing : mVlSurgeridoProd = Nothing



    End Sub

    Private Sub preenchVlrContasPagar(ByVal idN4ff As Int32)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd As String
        Dim mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd As Decimal
        Dim mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd As Decimal
        Dim mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd As Decimal
        Dim mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd As Decimal
        Dim mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF As Decimal
        Dim idN2ff As Int32
        Dim UndIten As String

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlNF As New StringBuilder
        Dim cmdNF As NpgsqlCommand
        Dim drNF As NpgsqlDataReader

        sqlNF.Append("SELECT nc_id, nc_codpr, nc_produt, nc_cfop, nc_cst, nc_qtde, nc_prunit, ") '6
        sqlNF.Append("nc_desc, nc_vldesc, nc_totbruto, nc_und, nc_prucom, nc_bscalc, nc_alqicm, ") '13
        sqlNF.Append("nc_vlicm, nc_basesub, nc_icmsub, nc_vlicsub, nc_alqipi, nc_vlipi, nc_frete, ") '20
        sqlNF.Append("nc_seguro, nc_outrasdesp, nc_alqnot, nc_prtot, ")
        sqlNF.Append("nc_estab FROM " & MdlEmpresaUsu._esqEstab & ".nota2ff WHERE nc_idn4ff = " & mIDn4FF)

        cmdNF = New NpgsqlCommand(sqlNF.ToString, oConnBDGENOV)
        drNF = cmdNF.ExecuteReader

        If drNF.HasRows = True AndAlso dtg_itensCompras.Columns.Count = _valorZERO Then addColunasItens()
        While drNF.Read
            idN2ff = drNF(_valorZERO) : mCodProd = drNF(1) : mNomeProd = drNF(2)
            mNcmProd = "" : mCfopProd = drNF(3) : mCstProd = drNF(4)
            mCsosnProd = "" : mQtdeProd = drNF(5) : mVlProd = drNF(6) : mVlPercDesc = drNF(7)
            mVlDesc = drNF(8) : mVlTotProd = drNF(9) : UndIten = drNF(10)
            mVlUnitComprProd = drNF(11) : mVlUnitProdNF = drNF(11)

            mVlPercRedProd = Format(0.0, "##,##0.00") 'depois acresentar no nota2ff

            mVlBcIcmsProd = drNF(12) : mVlAlqIcmsProd = drNF(13) : mVlIcmsProd = drNF(14)
            mBcSubsProd = drNF(15) : mVlAlqSubsProd = drNF(16) : mVlSubsProd = drNF(17)
            mVlAlqIpiProd = drNF(18) : mVlIpiProd = drNF(19)

            mVlPercFretProd = Format(0.0, "##,##0.00") 'depois acresentar no nota2ff

            mVlFretProd = drNF(20) : mVlSeguroProd = drNF(21) : mVlDespProd = drNF(22)

            mVlOutrosProd = Format(0.0, "##,##0.00") 'depois acresentar no nota2ff
            mVlCustoProd = Format(0.0, "##,##0.00") 'depois acresentar no nota2ff
            mVlPercLucroProd = Format(0.0, "##,##0.00") 'depois acresentar no nota2ff
            mVlSurgeridoProd = Format(0.0, "##,##0.00") 'depois acresentar no nota2ff


            Dim mlinha As String() = {mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd, mQtdeProd, mVlProd, _
                                      mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd, mVlUnitProdNF, mVlPercRedProd, _
                                      mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd, mVlAlqSubsProd, mVlSubsProd, _
                                      mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd, mVlFretProd, mVlSeguroProd, mVlDespProd, _
                                      mVlOutrosProd, mVlCustoProd, mVlPercLucroProd, mVlSurgeridoProd, UndIten, idN2ff}

            'Adicionando Linha
            Me.dtg_itensCompras.Rows.Add(mlinha)

            mlinha = Nothing

        End While
        drNF.Close() : oConnBDGENOV.ClearPool()
        cmdNF.CommandText = "" : sqlNF.Remove(0, sqlNF.ToString.Length)
        oConnBDGENOV.Close()
        Me.dtg_itensCompras.Refresh()

        'LIMPA OBJETOS DA MEMÓRIA...
        cmdNF = Nothing : sqlNF = Nothing : drNF = Nothing : mCodProd = Nothing : mNomeProd = Nothing
        mNcmProd = Nothing : mCfopProd = Nothing : mCstProd = Nothing : mCsosnProd = Nothing
        mQtdeProd = Nothing : mVlProd = Nothing : mVlPercDesc = Nothing : mVlDesc = Nothing
        mVlTotProd = Nothing : mVlUnitComprProd = Nothing : mVlUnitProdNF = Nothing
        mVlPercRedProd = Nothing : mVlBcIcmsProd = Nothing : mVlAlqIcmsProd = Nothing
        mVlIcmsProd = Nothing : mBcSubsProd = Nothing : mVlAlqSubsProd = Nothing
        mVlSubsProd = Nothing : mVlAlqIpiProd = Nothing : mVlIpiProd = Nothing
        mVlPercFretProd = Nothing : mVlFretProd = Nothing : mVlSeguroProd = Nothing
        mVlDespProd = Nothing : mVlOutrosProd = Nothing : mVlCustoProd = Nothing
        mVlPercLucroProd = Nothing : mVlSurgeridoProd = Nothing



    End Sub

    Private Sub txt_nfvltgeral_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nfvltgeral.GotFocus

        txt_nfvltgeral.SelectAll()
        If _mValidaValores = True Then
            Dim mtgeral As Double
            Try

                mtgeral = ((CDbl(txt_nftprodutos.Text) + CDbl(txt_nficmsub.Text) + CDbl(txt_nfvlipi.Text) + _
                CDbl(txt_nfVlSeguro.Text) + CDbl(txt_nfvlfrete.Text) + CDbl(txt_nfOutrasDesp.Text)) - CDbl(txt_nfDesconto.Text))
                Me.txt_nfvltgeral.Text = Format(CDbl(mtgeral), "###,##0.00")

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try

        End If



    End Sub

    Private Sub txt_nfipisento_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nfipisento.LostFocus

        If Me.txt_nfipisento.Text.Equals("") Then Me.txt_nfipisento.Text = Format(0.0, "###,##0.00")

    End Sub

    Private Sub txt_nfVlSeguro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfVlSeguro.GotFocus

        txt_nfVlSeguro.SelectAll()

    End Sub

    Private Sub txt_nfVlSeguro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfVlSeguro.LostFocus

        If Me.txt_nfVlSeguro.Text.Equals("") Then Me.txt_nfVlSeguro.Text = Format(0.0, "###,##0.00")
        If Not IsNumeric(Me.txt_nfVlSeguro.Text) Then

            lbl_mensagen.Text = "Valor do Seguro é inválido !"
            Return

        End If
        lbl_mensagen.Text = ""



    End Sub

    Private Sub txt_nfipioutros_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfipioutros.LostFocus

        If Me.txt_nfipioutros.Text.Equals("") Then Me.txt_nfipioutros.Text = Format(0.0, "###,##0.00")

    End Sub

    Private Sub txt_nfOutrasDesp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfOutrasDesp.GotFocus

        txt_nfOutrasDesp.SelectAll()

    End Sub

    Private Sub txt_nfOutrasDesp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfOutrasDesp.LostFocus

        If Me.txt_nfOutrasDesp.Text.Equals("") Then Me.txt_nfOutrasDesp.Text = Format(0.0, "###,##0.00")
        If Not IsNumeric(Me.txt_nfOutrasDesp.Text) Then

            lbl_mensagen.Text = "Valor de Outras despesas é inválido !"
            Return

        End If
        lbl_mensagen.Text = ""



    End Sub

    Private Sub txt_nfvltgeral_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nfvltgeral.LostFocus

        If Me.txt_nfvltgeral.Text.Equals("") Then Me.txt_nfvltgeral.Text = Format(0.0, "###,##0.00")
        If Not IsNumeric(Me.txt_nfvltgeral.Text) Then

            lbl_mensagen.Text = "Valor total da nota é inválido !"
            Return

        End If
        lbl_mensagen.Text = ""



    End Sub

    Private Sub btn_CancelarNF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CancelarNF.Click

        If MessageBox.Show("Deseja realmente cancelar esse processo?", "METROSYS", MessageBoxButtons.YesNo, _
        MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.zeraValoresRegNF() : Me.zeraValoresItemNF() : Me.txt_alqIcmsProd.Text = "0,00"
            Me.txt_alqIpiProd.Text = "0,00" : Me.zeraValoresDuplicat()
            If Me.dtg_itensCompras.Rows.Count > _valorZERO Then Me.dtg_itensCompras.Rows.Clear()
            Me.atualizSomaVlItens() : Me.tbp_importXml.Enabled = True
            tbp_lancanotas.Enabled = False : tbp_Itensnotas.Enabled = False
            tbp_contasapagar.Enabled = False : _editaNota = False
            Me.tbc_compras.SelectTab(_valorZERO) : lbl_mensagen.Text = ""

        End If



    End Sub

    Private Sub txt_nfvltgeral_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nfvltgeral.TextChanged

        If IsNumeric(Me.txt_nfvltgeral.Text) AndAlso CDec(Me.txt_nfvltgeral.Text) > _valorZERO Then

            btn_salvar.Enabled = True

        Else
            btn_salvar.Enabled = False

        End If



    End Sub

    Private Sub btn_visualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_visualiza.Click

        Try

            If DtgConsultaNotas.CurrentRow.Index >= _valorZERO Then

                _visualizaNota = True
                mIDn4FF = DtgConsultaNotas.CurrentRow.Cells(_valorZERO).Value
                _editaNota = False

                If Me.dtg_itensCompras.Rows.Count > _valorZERO Then

                    Me.dtg_itensCompras.Rows.Clear() : Me.dtg_itensCompras.Refresh()

                End If

                Me.zeraValoresRegNF() : Me.zeraValoresItemNF() : Me.zeraValoresDuplicat()
                preenchValoresReg(mIDn4FF) : preenchValoresItens(mIDn4FF)
                atualizSomaVlItens() : desabElementsItens()

                Me.tbp_importXml.Enabled = False : Me.tbp_lancanotas.Enabled = True
                Me.tbc_compras.SelectTab(1) : Me.tbp_lancanotas.Focus()
                Me.tbp_lancanotas.Enabled = False : Me.tbp_Itensnotas.Enabled = True
                Me.tbp_contasapagar.Enabled = False : Me.txt_nomePart.Focus()
                Me.txt_nomePart.SelectAll()

            End If
        Catch ex As Exception
        End Try



    End Sub

    Private Sub desabElementsItens()

        Me.txt_SaldoAtual.Enabled = False : Me.txt_csosn.Enabled = False
        Me.txt_alqIcmsProd.Enabled = False : Me.txt_alqIpiProd.Enabled = False
        Me.txt_txfrete.Enabled = False : Me.txt_txLucro.Enabled = False
        Me.txt_vlOutrosProd.Enabled = False : Me.txt_pcoCusto.Enabled = False
        Me.txt_PcoSugerido.Enabled = False : Me.txt_Vlproduto.Enabled = False
        Me.txt_Qtde.Enabled = False : Me.txt_prtot.Enabled = False
        Me.txt_Vlproduto.Enabled = False : Me.txt_frete.Enabled = False
        Me.txt_BcalculoItem.Enabled = False : Me.txt_BaseSub.Enabled = False
        Me.txt_icmSub.Enabled = False : Me.txt_vlIcms.Enabled = False
        Me.txt_Vlipi.Enabled = False : Me.txt_VlicmsProd.Enabled = False
        Me.txt_alqIcmsProd.Enabled = False : Me.txt_alqipi.Enabled = False
        Me.txt_BSCalc.Enabled = False : Me.txt_BSubsItem.Enabled = False
        Me.txt_vlDescProd.Enabled = False : Me.txt_vlSeguroProd.Enabled = False
        Me.txt_vlfreteProd.Enabled = False : Me.txt_vlIpiProd.Enabled = False
        Me.txt_alqSubsProd.Enabled = False : Me.txt_IcmSubProd.Enabled = False
        Me.txt_OutrasDesp.Enabled = False : Me.txt_reducao.Enabled = False
        Me.txt_prunit.Enabled = False : Me.txt_vlPercDescProd.Enabled = False
        Me.txt_codProd.Enabled = False : Me.txt_nomeProd.Enabled = False
        Me.txt_ncm.Enabled = False : Me.cbo_itcfop.Enabled = False
        Me.cbo_cstProd.Enabled = False : Me.btn_itexclui.Enabled = False
        Me.btn_itinclui.Enabled = False : Me.btn_itsai.Enabled = False



    End Sub

    Private Sub abilitElementsItens()

        Me.txt_SaldoAtual.Enabled = True : Me.txt_csosn.Enabled = False
        Me.txt_alqIcmsProd.Enabled = True : Me.txt_alqIpiProd.Enabled = True
        Me.txt_txfrete.Enabled = True : Me.txt_txLucro.Enabled = True
        Me.txt_vlOutrosProd.Enabled = True : Me.txt_pcoCusto.Enabled = True
        Me.txt_PcoSugerido.Enabled = True : Me.txt_Vlproduto.Enabled = True
        Me.txt_Qtde.Enabled = True : Me.txt_prtot.Enabled = True
        Me.txt_Vlproduto.Enabled = True : Me.txt_frete.Enabled = True
        Me.txt_BcalculoItem.Enabled = True : Me.txt_BaseSub.Enabled = True
        Me.txt_icmSub.Enabled = True : Me.txt_vlIcms.Enabled = True
        Me.txt_Vlipi.Enabled = True : Me.txt_VlicmsProd.Enabled = True
        Me.txt_alqIcmsProd.Enabled = True : Me.txt_alqipi.Enabled = True
        Me.txt_BSCalc.Enabled = True : Me.txt_BSubsItem.Enabled = True
        Me.txt_vlDescProd.Enabled = True : Me.txt_vlSeguroProd.Enabled = True
        Me.txt_vlfreteProd.Enabled = True : Me.txt_vlIpiProd.Enabled = True
        Me.txt_alqSubsProd.Enabled = True : Me.txt_IcmSubProd.Enabled = True
        Me.txt_OutrasDesp.Enabled = True : Me.txt_reducao.Enabled = True
        Me.txt_prunit.Enabled = True : Me.txt_vlPercDescProd.Enabled = True
        Me.txt_codProd.Enabled = True : Me.txt_nomeProd.Enabled = True
        Me.txt_ncm.Enabled = True : Me.cbo_itcfop.Enabled = True
        Me.cbo_cstProd.Enabled = True : Me.btn_itexclui.Enabled = True
        Me.btn_itinclui.Enabled = True : Me.btn_itsai.Enabled = True


    End Sub

    Private Sub dtg_itensCompras_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_itensCompras.SelectionChanged

        If _visualizaNota = True Then preenchElementsItenCorrent()

    End Sub

    Private Sub OpConsTsmItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpConsTsmItem.Click

        If Me.DtgConsultaNotas.Rows.Count > _valorZERO AndAlso Me.DtgConsultaNotas.SelectedCells.Count > 0 Then

            executaEspelhoNota("", "\wged\TEMPconsulta.txt")

        End If


    End Sub

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

    Private Sub GravTotaisArq(ByVal s As StreamWriter, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim vlTotNota, vlBcICMS, vlICMS, vlBcSubs, vlSubs, vlTotItens As Decimal
            Dim vlFrete, vlSeguro, vlDesc, vlOutrasDesp, vlIPI As Decimal

            vlTotNota = CDec(Me.DtgConsultaNotas.CurrentRow.Cells(8).Value)
            vlBcICMS = CDec(Me.DtgConsultaNotas.CurrentRow.Cells(10).Value)
            vlICMS = CDec(Me.DtgConsultaNotas.CurrentRow.Cells(11).Value)
            vlBcSubs = CDec(Me.DtgConsultaNotas.CurrentRow.Cells(12).Value)
            vlSubs = CDec(Me.DtgConsultaNotas.CurrentRow.Cells(13).Value)
            vlTotItens = CDec(Me.DtgConsultaNotas.CurrentRow.Cells(9).Value)
            vlFrete = CDec(Me.DtgConsultaNotas.CurrentRow.Cells(15).Value)
            vlSeguro = CDec(Me.DtgConsultaNotas.CurrentRow.Cells(16).Value)
            vlDesc = CDec(Me.DtgConsultaNotas.CurrentRow.Cells(17).Value)
            vlOutrasDesp = CDec(Me.DtgConsultaNotas.CurrentRow.Cells(18).Value)
            vlIPI = CDec(Me.DtgConsultaNotas.CurrentRow.Cells(14).Value)

            gravaTotaisNota(s, vlBcICMS, vlICMS, vlBcSubs, vlSubs, vlTotItens, vlFrete, vlSeguro, _
                            vlDesc, vlOutrasDesp, vlIPI, vlTotNota)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar os totais da Nota", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Private Sub GravItensArq(ByVal arqSaida As String, ByVal mArqTemp As String, ByVal fs As FileStream, ByVal s As StreamWriter, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim idN4ff As Int32 = CInt(Me.DtgConsultaNotas.CurrentRow.Cells(_valorZERO).Value)
            gravaItemsNota(s, idN4ff)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) da Nota", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try

        s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)

        Catch ex As Exception
        End Try
        s.Dispose() : File.Delete(mArqTemp) : mArqTemp = Nothing : fs = Nothing : s = Nothing



    End Sub

    Private Sub GravCabecalhoArq(ByVal s As StreamWriter, ByVal dtEntrada As String, ByVal dtEmissao As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim codFornecedor As String = Me.DtgConsultaNotas.CurrentRow.Cells(4).Value.ToString
            codFornecedor = codFornecedor.Substring(_valorZERO, 6)

            Dim codEstab As String = Me.DtgConsultaNotas.CurrentRow.Cells(19).Value.ToString
            gravaCabecalhoNota(s, codFornecedor, codEstab, dtEntrada, dtEmissao)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Nota", MsgBoxStyle.Exclamation)
            s.Close() : shouldReturn = True : Return

        End Try



    End Sub

    Private Sub executaEspelhoNota(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPconsulta.TMP"
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
        Dim dtEntrada As String = Me.DtgConsultaNotas.CurrentRow.Cells(1).Value
        Dim dtEmissao As String = Me.DtgConsultaNotas.CurrentRow.Cells(5).Value
        Dim serie As String = Me.DtgConsultaNotas.CurrentRow.Cells(3).Value
        Dim numero As String = Me.DtgConsultaNotas.CurrentRow.Cells(2).Value
        Dim especie As String = Me.DtgConsultaNotas.CurrentRow.Cells(6).Value
        Dim cfopNota As String = Me.DtgConsultaNotas.CurrentRow.Cells(7).Value

        'titulo
        Try
            s.Write(vbNewLine & vbNewLine)

            '8 caracteres
            strLinha = _clFunc.Exibe_Str(("NUMERO: " & numero), 20)

            '7 caracteres
            strLinha += _clFunc.Exibe_Str(("SERIE: " & serie), 12)

            '9 caracteres
            strLinha += _clFunc.Exibe_Str(("ENTRADA: " & dtEntrada), 21)

            '9 caracteres
            strLinha += _clFunc.Exibe_Str(("EMISSÃO: " & dtEmissao), 21)

            '9 caracteres
            strLinha += _clFunc.Exibe_Str(("ESPECIE: " & especie), 14)

            '13 caracteres
            strLinha += _clFunc.Exibe_StrDireita(("CFOP PADRÃO: " & cfopNota), 26)


            s.WriteLine(_clFunc.Exibe_Str(strLinha, 120))
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
        GravItensArq(arqSaida, mArqTemp, fs, s, lShouldReturn1)
        If lShouldReturn1 Then Return

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo()

        _StringToPrint = ""
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

            nomeForn = drForn(_valorZERO) : cnpjForn = drForn(1) : inscForn = drForn(2)
            cidForn = drForn(3) : ufForn = drForn(4)

        End While
        drForn.Close() : cmdForn = Nothing : sqlForn = Nothing : drForn = Nothing
        oConnBDGENOV.ClearPool()

        '                      1        2         3         4         5         6         7         8         9         0         1         2
        '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        s.WriteLine("  FORNECEDOR -----------------------------------------------------------------------------------------------------")
        strLinha = _clFunc.Exibe_StrEsquerda("NOME/RAZÃO SOCIAL: " & nomeForn, 80)
        strLinha += _clFunc.Exibe_StrDireita("CNPJ/CPF: " & cnpjForn, 30)
        s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 120))

        strLinha = _clFunc.Exibe_StrEsquerda("INSCRIÇÃO ESTADUAL: " & inscForn, 44)
        strLinha += _clFunc.Exibe_StrEsquerda("CIDADE: " & cidForn, 60)
        strLinha += _clFunc.Exibe_StrDireita("UF: " & ufForn, 6)

        s.Write(_clFunc.Exibe_cabecalho(strLinha, 4, 120))
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

            nomeClient = drClient(_valorZERO) : cnpjClient = drClient(1) : inscClient = drClient(2)
            ufClient = drClient(3) : enderClient = drClient(4) : cidClient = drClient(5)

        End While
        drClient.Close() : oConnBDGENOV.ClearPool()
        cmdClient = Nothing : sqlClient = Nothing : drClient = Nothing


        '                      1        2         3         4         5         6         7         8         9         0         1         2
        '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        s.WriteLine("  CLIENTE --------------------------------------------------------------------------------------------------------")
        strLinha = _clFunc.Exibe_StrEsquerda("NOME/RAZÃO SOCIAL: " & nomeClient, 80)
        strLinha += _clFunc.Exibe_StrDireita("CNPJ/CPF: " & cnpjClient, 30)
        s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 120))

        strLinha = _clFunc.Exibe_StrEsquerda("INSCRIÇÃO ESTADUAL: " & inscClient, 44)
        strLinha += _clFunc.Exibe_StrEsquerda("CIDADE: " & cidClient, 60)
        strLinha += _clFunc.Exibe_StrDireita("UF: " & ufClient, 6)
        s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 120))

        strLinha = _clFunc.Exibe_StrEsquerda("ENDEREÇO: " & enderClient, 90)
        s.Write(_clFunc.Exibe_cabecalho(strLinha, 4, 120))
        s.WriteLine(vbNewLine)
        '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxZ xxx xxxxxxxxxx 999,999.99 999,999.99   
        's.WriteLine("--------------------------------------------------------------------------------------------------------------------")



    End Sub

    Private Sub gravaTotaisNotaExtracted(ByVal s As StreamWriter, ByVal bcICMS As Decimal, ByVal vlICMS As Decimal, ByVal bcSubs As Decimal, ByVal vlSubs As Decimal, ByVal strLinha As String)

        '                      1        2         3         4         5         6         7         8         9         0         1         2
        '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        s.WriteLine("  TOTAIS DA NOTA -------------------------------------------------------------------------------------------------")

        '10 CARACTERES
        strLinha = _clFunc.Exibe_StrEsquerda("BC. ICMS: " & Format(bcICMS, "###,##0.00"), 30) '10+20=30 CARACTERES

        '10 CARACTERES
        strLinha += _clFunc.Exibe_StrEsquerda("VL. ICMS: " & Format(vlICMS, "###,##0.00"), 26) '10+16=26 CARACTERES

        '12 CARACTERES
        strLinha += _clFunc.Exibe_StrEsquerda("BC. SUBST.: " & Format(bcSubs, "###,##0.00"), 27) '12+16=27 CARACTERES

        '12 CARACTERES
        strLinha += _clFunc.Exibe_StrDireita("VL. SUBST.: " & Format(vlSubs, "###,##0.00"), 27) '12+16=27 CARACTERES
        s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 120)) '104+4=108 CARACTERES, ALINHAMENTO = 103, MAX = 103



    End Sub

    Private Sub gravaTotaisNotaExtracted1(ByVal s As StreamWriter, ByVal vlTotItens As Decimal, ByVal vlFrete As Decimal, ByVal vlSeguro As Decimal, ByVal vlDesconto As Decimal, ByVal strLinha As String)

        '14 CARACTERES
        strLinha = _clFunc.Exibe_StrEsquerda("VL. PRODUTOS: " & Format(vlTotItens, "###,##0.00"), 31) '14+16=30 CARACTERES

        '11 CARACTERES
        strLinha += _clFunc.Exibe_StrEsquerda("VL. FRETE: " & Format(vlFrete, "###,##0.00"), 26) '11+15=26 CARACTERES

        '12 CARACTERES
        strLinha += _clFunc.Exibe_StrEsquerda("VL. SEGURO: " & Format(vlSeguro, "###,##0.00"), 27) '12+15=27 CARACTERES

        '7 CARACTERES
        strLinha += _clFunc.Exibe_StrDireita("DESC.: " & Format(vlDesconto, "###,##0.00"), 26) '7+12=19 CARACTERES
        'Dim MMMSTR As String = cl_funcoes.Exibe_cabecalho(strLinha, 4, 110)

        'MMMSTR = MMMSTR
        s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 120)) '98+4=102 CARACTERES, ALINHAMENTO = 103, MAX = 103



    End Sub

    Private Function gravaTotaisNotaExtracted2(ByVal vlOutrasDesp As Decimal, ByVal vlIPI As Decimal, ByVal vlTotNota As Decimal) As String

        Dim strLinha As String
        '233d

        '16 CARACTERES
        strLinha = _clFunc.Exibe_StrEsquerda("OUTR. DESPESAS: " & Format(vlOutrasDesp, "###,##0.00"), 35) '16+14=30 CARACTERES

        '9 CARACTERES
        strLinha += _clFunc.Exibe_StrEsquerda("VL. IPI: " & Format(vlIPI, "###,##0.00"), 35) '9+17=26 CARACTERES

        '19 CARACTERES
        strLinha += _clFunc.Exibe_StrDireita("VL. TOTAL DA NOTA: " & Format(vlTotNota, "###,##0.00"), 40) '19+16=35 CARACTERES



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
        s.Write(_clFunc.Exibe_cabecalho(strLinha, 4, 120)) '88+4=92 CARACTERES, ALINHAMENTO = 103, MAX = 103
        s.WriteLine(vbNewLine)
        '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxZ xxx xxxxxxxxxx 999,999.99 999,999.99   


    End Sub

    Private Sub gravaItemsNota(ByVal s As StreamWriter, ByVal idN4ff As Int32)

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
        Dim mContItens As Integer = _valorZERO

        sqlItem.Append("SELECT nc_id, nc_codpr, nc_produt, nc_cfop, nc_cst, nc_qtde, nc_prunit, ") '6
        sqlItem.Append("nc_desc, nc_vldesc, nc_totbruto, nc_und, nc_prucom, nc_bscalc, nc_alqicm, ") '13
        sqlItem.Append("nc_vlicm, nc_basesub, nc_icmsub, nc_vlicsub, nc_alqipi, nc_vlipi, nc_frete, ") '20
        sqlItem.Append("nc_seguro, nc_outrasdesp, nc_alqnot, nc_prtot, ")
        sqlItem.Append("nc_estab FROM " & MdlEmpresaUsu._esqEstab & ".nota2ff WHERE nc_idn4ff = " & idN4ff)

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

            strLinha = _clFunc.Exibe_Str(mCodProd, 6) & " " & _clFunc.Exibe_Str(mNomeProd, 35) & " " & _
            _clFunc.Exibe_Str(mCstProd, 3) & " " & _clFunc.Exibe_Str(mCfopProd, 4) & " " & _
            _clFunc.Exibe_Str(UndIten, 3) & " " & _clFunc.Exibe_StrDireita(Format(mQtdeProd, "###,##0.00"), 9) _
            & " " & _clFunc.Exibe_StrDireita(Format(mVlBrutoProd, "###,##0.00"), 10) & " " & _
            _clFunc.Exibe_StrDireita(Format(mVlIpiProd, "###,##0.00"), 9) & " " & _
            _clFunc.Exibe_StrDireita(Format(mvlSubs, "###,##0.00"), 10) & " " & _
            _clFunc.Exibe_StrDireita(Format(mVlTotProd, "###,##0.00"), 12) '106 CARACTERES

            s.WriteLine(_clFunc.Exibe_Str(strLinha, 110))
            mContItens += 1

        End While


        If drItem.HasRows = True Then

            s.WriteLine("")
            strLinha = "TOTAIS --->          " & _clFunc.Exibe_StrDireita(mContItens, 3)
            If mContItens > 1 Then

                strLinha += " - Itens"

            Else
                strLinha += " - Iten"

            End If

            strLinha = _clFunc.Exibe_Str(strLinha, 65)
            strLinha += " " & _clFunc.Exibe_StrDireita(Format(mSomaBrutoProd, "###,##0.00"), 10) & " " & _
            _clFunc.Exibe_StrDireita(Format(mSomaIPI, "###,##0.00"), 9) & " " & _
            _clFunc.Exibe_StrDireita(Format(mSomaSubs, "###,##0.00"), 10) & " " & _
            _clFunc.Exibe_StrDireita(Format(mSomaTotProd, "###,##0.00"), 12) '106 CARACTERES
            s.WriteLine(_clFunc.Exibe_Str(strLinha, 115))


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
        StringforPage = _StringToPrint.Substring(_valorZERO, NumChars)

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

    Private Sub RelatoriosDasNotasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelatoriosDasNotasToolStripMenuItem.Click

        'Aqui o relatorio...
        executaEspelhoNF_R("", "\wged\relatorios\TEMPconsultaR.txt")

    End Sub

    Private Sub executaEspelhoNF_RExtracted(ByVal arqSaida As String, ByVal mArqTemp As String, ByVal fs As FileStream, ByRef s As StreamWriter, ByVal mContPaginas As Integer, ByVal mContQuebrasPag As Integer, ByVal dtAtual As String, ByVal codEstab As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        'Totais
        Try
            Dim mConsultaAtual As String = ConsulFornec() & ConsulEspec() & ConsulPeriodos()
            gravaTotaisNF_R(s, mContPaginas, mConsultaAtual, mContQuebrasPag, codEstab, dtAtual)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar os totais da Nota", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

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

    Private Sub executaEspelhoNF_RExtracted2()

        Try

            ' Especifica as configurações da pagina atual
            pdRelatorio.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatorio.DefaultPageSettings.Margins.Top = 12 'cima
            pdRelatorio.DefaultPageSettings.Margins.Right = 11 'direita
            pdRelatorio.DefaultPageSettings.Margins.Left = 11 'esquerda
            pdRelatorio.DefaultPageSettings.Margins.Bottom = 8 'baixo

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando Relatorio"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatorio
            PrintPreviewDialog1.ShowDialog()

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub executaEspelhoNF_R(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\relatorios\TEMPconsulta.TMP"
        Dim fs As New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)
        Dim s As New StreamWriter(fs)

        Dim mContPaginas As Integer = _valorZERO, mContQuebrasPag As Integer = _valorZERO
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

            Select Case Me.cbo_consulta.SelectedIndex
                Case _valorZERO 'Todas as Notas
                    s.WriteLine(_clFunc.Centraliza_Str("RELATORIO DE ENTRADAS DE TODAS AS NOTAS", 132))
                    _tituloConsulta = "RELATORIO DE ENTRADAS DE TODAS AS NOTAS"

                Case 1 'As 10 últimas Notas
                    s.WriteLine(_clFunc.Centraliza_Str("RELATORIO DE ENTRADAS DAS 10 ULTIMAS NOTAS", 132))
                    _tituloConsulta = "RELATORIO DE ENTRADAS DAS 10 ULTIMAS NOTAS"

                Case 2 'Data atual
                    s.WriteLine(_clFunc.Centraliza_Str("RELATORIO DE ENTRADAS DE HOJE", 132))
                    _tituloConsulta = "        RELATORIO DE ENTRADAS DE " & Format(Date.Now, "dd/MM/yyyy")

                Case 3 'No último mês
                    s.WriteLine(_clFunc.Centraliza_Str("RELATORIO DE ENTRADAS APARTIR DO ULTIMO MÊS", 132))
                    _tituloConsulta = "RELATORIO DE ENTRADAS APARTIR DO ULTIMO MÊS"

                Case 4 'No último ano
                    s.WriteLine(_clFunc.Centraliza_Str("RELATORIO DE ENTRADAS APARTIR DO ULTIMO ANO", 132))
                    _tituloConsulta = "RELATORIO DE ENTRADAS APARTIR DO ULTIMO ANO"

                Case 5 'Intervalo personalizado
                    s.WriteLine(_clFunc.Centraliza_Str("RELATORIO DE ENTRADAS DE: " & Me.msk_dtInicio.Text & " A " & Me.msk_dtFim.Text, 133))
                    _tituloConsulta = "RELATORIO DE ENTRADAS DE: " & Me.msk_dtInicio.Text & " A " & Me.msk_dtFim.Text


            End Select
            mContQuebrasPag += 1

            s.Write(vbNewLine)
            mContQuebrasPag += 1

            s.WriteLine(_clFunc.Exibe_Str(strLinha, 133))
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
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()

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

        cmdEstab = New NpgsqlCommand(sqlEstab.ToString, oConnBDGENOV)
        drEstab = cmdEstab.ExecuteReader

        Dim nomeEstab, cnpjEstab, inscEstab, ufEstab, enderEstab, cidEstab As String

        nomeEstab = "" : cnpjEstab = "" : inscEstab = "" : ufEstab = "" : enderEstab = "" : cidEstab = ""

        While drEstab.Read

            nomeEstab = drEstab(_valorZERO) : cnpjEstab = drEstab(1) : inscEstab = drEstab(2)
            ufEstab = drEstab(3) : enderEstab = drEstab(4) : cidEstab = drEstab(5)

        End While
        drEstab.Close() : oConnBDGENOV.ClearPool()
        cmdEstab.CommandText = "" : sqlEstab.Remove(0, sqlEstab.ToString.Length)
        oConnBDGENOV.Close() : cmdEstab = Nothing : sqlEstab = Nothing : drEstab = Nothing


        '                      1        2         3         4         5         6         7         8         9         0         1         2
        '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        strLinha = _clFunc.Exibe_StrEsquerda("EMPRESA: " & codEstab & "  " & nomeEstab, 109)
        strLinha += " "

        strLinha += _clFunc.Exibe_StrDireita("DATA: " & dtAtual, 17)
        s.WriteLine(strLinha)
        mContQuebrasPag += 1

        strLinha = _clFunc.Exibe_StrEsquerda("ENDEREÇO: " & enderEstab, 117)
        strLinha += " "

        strLinha += _clFunc.Exibe_StrDireita("PAG.: " & String.Format("{0:D3}", Convert.ToInt32(mContPaginas)), 9)
        s.WriteLine(strLinha & vbNewLine)
        mContQuebrasPag += 2

    End Sub

    Private Sub gravaTotaisNF_R(ByRef s As StreamWriter, ByRef mContPaginas As Integer, _
                                ByVal ConsultaAtual As String, ByRef mContQuebrasPag As Integer, _
                                ByVal codEstab As String, ByVal dtAtual As String)

        Dim strLinha As String = ""
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()
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
        Dim mContRegistros As Integer = _valorZERO

        somaBcIcms = _valorZERO : somaIcms = _valorZERO : somaIPI = _valorZERO : somaBcSubs = _valorZERO
        somaTotNota = _valorZERO : bcIcms = _valorZERO : icms = _valorZERO : IPI = _valorZERO
        bcSubs = _valorZERO : totNota = _valorZERO : numero = "" : dtEntrada = "" : cfop = "" : uf = ""
        fornecedor = ""

        Try
            sqlNF.Append("SELECT n4_numer, to_char(n4_dtent, 'DD/MM'), SUBSTR(cad.p_portad, 1, 40), n4_cdfisc, ") '3
            sqlNF.Append("n4_uf, n4_basec, n4_icms, n4_ipi, n4_bsub, n4_tgeral FROM " & MdlEmpresaUsu._esqEstab & ".Nota4ff ") '9
            sqlNF.Append("LEFT JOIN cadp001 cad ON cad.p_cod = n4_cdport " & ConsultaAtual)

            cmdNF = New NpgsqlCommand(sqlNF.ToString, oConnBDGENOV)
            _dtAdaptPrint = New NpgsqlDataAdapter(sqlNF.ToString, oConnBDGENOV)
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

                numero = String.Format("{0:D9}", Convert.ToInt32(drNF(_valorZERO).ToString))
                dtEntrada = drNF(1).ToString
                cfop = drNF(3).ToString
                fornecedor = drNF(2).ToString.ToUpper
                uf = drNF(4).ToString : bcIcms = drNF(5) : icms = drNF(6)
                IPI = drNF(7) : bcSubs = drNF(8) : totNota = drNF(9)

                strLinha = numero & " " & dtEntrada & " " & cfop & " " & _clFunc.Exibe_StrEsquerda(fornecedor, 34) & " " '61
                strLinha += uf & " " & _clFunc.Exibe_StrDireita(Format(bcIcms, "###,##0.00"), 14) & " "
                strLinha += _clFunc.Exibe_StrDireita(Format(icms, "###,##0.00"), 12) & " "
                strLinha += _clFunc.Exibe_StrDireita(Format(IPI, "###,##0.00"), 12) & " "
                strLinha += _clFunc.Exibe_StrDireita(Format(bcSubs, "###,##0.00"), 12) & " "
                strLinha += _clFunc.Exibe_StrDireita(Format(totNota, "###,##0.00"), 14)

                s.WriteLine(strLinha)
                mContQuebrasPag += 1
                somaBcIcms += bcIcms : somaIcms += icms : somaIPI += IPI : somaBcSubs += bcSubs
                somaTotNota += totNota : mContRegistros += 1

                'se chegou ao maximo de quebras de linha em na pagina, então chama o título
                If mContQuebrasPag = 117 Then

                    mContQuebrasPag = _valorZERO
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
                    mContQuebrasPag = _valorZERO
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

                    strLinha = _clFunc.Exibe_StrEsquerda("Totais  ->  " & mContRegistros & " Notas", 59)

                Else
                    strLinha = _clFunc.Exibe_StrEsquerda("Totais  ->  " & mContRegistros & " Nota", 59)

                End If

                strLinha += _clFunc.Exibe_StrDireita(Format(somaBcIcms, "###,##0.00"), 14) & " "
                strLinha += _clFunc.Exibe_StrDireita(Format(somaIcms, "###,##0.00"), 12) & " "
                strLinha += _clFunc.Exibe_StrDireita(Format(somaIPI, "###,##0.00"), 12) & " "
                strLinha += _clFunc.Exibe_StrDireita(Format(somaBcSubs, "###,##0.00"), 12) & " "
                strLinha += _clFunc.Exibe_StrDireita(Format(somaTotNota, "###,##0.00"), 14)
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
                .Document = pdRelatorio
                .WindowState = FormWindowState.Maximized
                .PrintPreviewControl.Zoom = 1   'maxima a visualização
                .Text = "Relatório de Notas"

                'exibe a janela de visualização para o usuário
                .ShowDialog()


            End With

            objPrintPreview = Nothing : _leitorTabela.Close()
            mContQuebrasPag = _valorZERO : cmdNF.CommandText = ""

        Catch ex As Exception
        End Try

        sqlNF.Remove(_valorZERO, sqlNF.ToString.Length)
        oConnBDGENOV.ClearPool()

        'LIMPA OBJETOS DA MEMÓRIA...
        cmdNF = Nothing : sqlNF = Nothing : numero = Nothing : dtEntrada = Nothing : cfop = Nothing
        fornecedor = Nothing : uf = Nothing : bcIcms = Nothing : icms = Nothing : IPI = Nothing
        bcSubs = Nothing : totNota = Nothing : somaBcIcms = Nothing : somaIcms = Nothing
        somaIPI = Nothing : somaBcSubs = Nothing : cmdPrint = Nothing : somaTotNota = Nothing
        oConnBDGENOV.Close() : oConnBDGENOV = Nothing



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
        Relatorio.Graphics.DrawString("UF", fonteColuna, Brushes.Red, margemDir + 372, 128, New StringFormat())
        Relatorio.Graphics.DrawString("B.Calc", fonteColuna, Brushes.Red, margemDir + 395, 128, New StringFormat())
        Relatorio.Graphics.DrawString("Icms", fonteColuna, Brushes.Red, margemDir + 480, 128, New StringFormat())
        Relatorio.Graphics.DrawString("Ipi", fonteColuna, Brushes.Red, margemDir + 550, 128, New StringFormat())
        Relatorio.Graphics.DrawString("B.Subs", fonteColuna, Brushes.Red, margemDir + 620, 128, New StringFormat())
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
        Dim mContRegistros As Integer = _valorZERO

        somaBcIcms = _valorZERO : somaIcms = _valorZERO : somaIPI = _valorZERO : somaBcSubs = _valorZERO
        somaTotNota = _valorZERO : bcIcms = _valorZERO : icms = _valorZERO : IPI = _valorZERO
        bcSubs = _valorZERO : totNota = _valorZERO : numero = "" : dtEntrada = "" : cfop = "" : uf = ""
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
            fornecedor = _clFunc.Exibe_StrEsquerda(_leitorTabela(2).ToString, 32)
            dtEntrada = _leitorTabela(1)
            cfop = _leitorTabela(3).ToString
            uf = _leitorTabela(4).ToString

            'imprime os dados relativo ao codigo , nome do produto e preço do produto
            Relatorio.Graphics.DrawString(numero, fonteNormal, Brushes.Black, margemDir, posicaoDaLinha, New StringFormat())
            Relatorio.Graphics.DrawString(dtEntrada, fonteNormal, Brushes.Black, margemDir + 68, posicaoDaLinha, New StringFormat())
            Relatorio.Graphics.DrawString(cfop, fonteNormal, Brushes.Black, margemDir + 113, posicaoDaLinha, New StringFormat())
            Relatorio.Graphics.DrawString(fornecedor, fonteNormal, Brushes.Black, margemDir + 147, posicaoDaLinha, New StringFormat())
            Relatorio.Graphics.DrawString(uf, fonteNormal, Brushes.Black, margemDir + 372, posicaoDaLinha, New StringFormat())

            bcIcms = _leitorTabela(5)
            strLinha = _clFunc.Exibe_StrEsquerda(Format(bcIcms, "###,##0.00"), 14)
            Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 395, posicaoDaLinha, New StringFormat())

            icms = _leitorTabela(6)
            strLinha = _clFunc.Exibe_StrEsquerda(Format(icms, "###,##0.00"), 12)
            Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 480, posicaoDaLinha, New StringFormat())

            IPI = _leitorTabela(7)
            strLinha = _clFunc.Exibe_StrEsquerda(Format(IPI, "###,##0.00"), 12)
            Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 550, posicaoDaLinha, New StringFormat())

            bcSubs = _leitorTabela(8)
            strLinha = _clFunc.Exibe_StrEsquerda(Format(bcSubs, "###,##0.00"), 12)
            Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 620, posicaoDaLinha, New StringFormat())

            totNota = _leitorTabela(9)
            strLinha = _clFunc.Exibe_StrEsquerda(Format(totNota, "###,##0.00"), 14)
            Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 690, posicaoDaLinha, New StringFormat())

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
        strLinha = _clFunc.Exibe_StrEsquerda(Format(somaBcIcms, "###,##0.00"), 14)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 395, posicaoDaLinha, New StringFormat())
        strLinha = _clFunc.Exibe_StrEsquerda(Format(somaIcms, "###,##0.00"), 12)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 480, posicaoDaLinha, New StringFormat())
        strLinha = _clFunc.Exibe_StrEsquerda(Format(somaIPI, "###,##0.00"), 12)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 550, posicaoDaLinha, New StringFormat())
        strLinha = _clFunc.Exibe_StrEsquerda(Format(somaBcSubs, "###,##0.00"), 12)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 620, posicaoDaLinha, New StringFormat())
        strLinha = _clFunc.Exibe_StrEsquerda(Format(somaTotNota, "###,##0.00"), 14)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir + 690, posicaoDaLinha, New StringFormat())

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

    Public Sub Cria_arqxml()

        OpenFileDialog1.Filter = "Text files (*.xml)|*.xml"
        'OpenFileDialog1
        Me.txt_implocal.Text = OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName <> "" Then Me.txt_implocal.Text = OpenFileDialog1.FileName

    End Sub

    Private Sub btn_implocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_implocal.Click

        If Me.txt_implocal.Text = "" Then Cria_arqxml()

    End Sub

    Private Sub btn_consulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta.Click

        Me.WebBrowser1.Navigate(New Uri("http://www.sintegra.gov.br/".ToString))
        Me.tbc_compras.TabPages(1).Focus()

    End Sub

    Private Sub btn_consultadanfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultadanfe.Click

        Try
            Dim mSite As New Uri("http://www.webdanfe.com.br")
            Dim mRequest As WebRequest = WebRequest.Create(mSite)
            Dim mResponse As WebResponse = mRequest.GetResponse()
            Me.frm_WB_xmldanfe.Navigate(mSite)
            mSite = Nothing : mRequest = Nothing : mResponse = Nothing


        Catch ex As WebException

            Try
                Dim mSite As New Uri("http://www.banpagnfe.com.br/") 'https://www.danfeonline.com.br/
                Dim mRequest As WebRequest = WebRequest.Create(mSite)
                Dim mResponse As WebResponse = mRequest.GetResponse()
                Me.frm_WB_xmldanfe.Navigate(mSite)
                mSite = Nothing : mRequest = Nothing : mResponse = Nothing

            Catch ex2 As Exception
                Me.frm_WB_xmldanfe.Navigate(New Uri("http://www.geradanfe.com.br/"))

            End Try


        Catch ex1 As Exception
            MsgBox("ERRO -> " & ex1.Message)
        End Try



    End Sub

    Private Sub btn_importar_ClickNFeXML(ByVal StrXml As String)
        Dim _Dtemis As String
        Dim xpos, xpos1, xpos2, xpos3, xpos4, xpos5, xpos6, xpos7, xpos8, xposfim, xposdif, xmnum, Mcrt, mxSerie As Integer
        Dim xmCnpjCpf, mAuxValores As String
        xpos = _valorZERO : xpos1 = _valorZERO : xpos2 = _valorZERO : xposfim = _valorZERO : xposdif = _valorZERO

        Try
            ' CHAVE NFe
            xpos2 = StrXml.IndexOf("<infNFe ") : mAuxValores = StrXml.Substring(xpos2)
            xpos2 = StrXml.IndexOf("Id=""NFe") : _chaveNFeXML = StrXml.Substring(xpos2 + 7, 44)

            ' Serie
            mxSerie = Mid(_chaveNFeXML, 23, 3)
            Me.txt_xmserie.Text = Convert.ToInt16(mxSerie)

            ' Numero da NFe
            xpos2 = StrXml.IndexOf("<nNF>") : xposfim = StrXml.IndexOf("</nNF>")
            xposdif = (xposfim - xpos2) - 5
            xmnum = Convert.ToInt32(Mid(StrXml, xpos2 + 6, xposdif))
            Me.txt_xmnumero.Text = String.Format("{0:D9}", xmnum)

            ' Data de Emissao <dEmi>
            xpos1 = StrXml.IndexOf("<dEmi>") : xposfim = StrXml.IndexOf("</dEmi>")
            xposdif = (xposfim - xpos1) - 6
            _Dtemis = Mid(StrXml, xpos1 + 7, xposdif)
            Me.msk_xmemissao.Text = Mid(_Dtemis, 9, 2) & "/" & Mid(_Dtemis, 6, 2) & "/" & Mid(_Dtemis, 1, 4)

            ' Numero do CNPJ
            xpos = StrXml.IndexOf("<CNPJ>")
            xmCnpjCpf = Mid(StrXml, xpos + 7, 14)
            Me.msk_cnpj.Text = xmCnpjCpf


            _codFornXML = ""
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try

                oConnBDGENOV.Open()
                Dim sqlNF As New StringBuilder
                Dim cmdNF As NpgsqlCommand
                Dim drNF As NpgsqlDataReader

                sqlNF.Append("SELECT p_cod FROM cadp001 WHERE p_cgc = '" & xmCnpjCpf & "' OR ")
                sqlNF.Append("p_cpf = '" & xmCnpjCpf & "'")
                cmdNF = New NpgsqlCommand(sqlNF.ToString, oConnBDGENOV)
                drNF = cmdNF.ExecuteReader

                While drNF.Read

                    _codFornXML = drNF(_valorZERO)

                End While
                drNF.Close() : oConnBDGENOV.ClearPool()
                cmdNF = Nothing : sqlNF = Nothing : drNF = Nothing
                oConnBDGENOV.Close()

            Catch ex As Exception
            Finally
                oConnBDGENOV = Nothing
            End Try


            'Verifica a Nota... 
            If _codFornXML.Equals("") Then

                If MessageBox.Show("Fornecedor não existe no Banco de Dados! Deseja incluí-lo?", "METROSYS", MessageBoxButtons.YesNo, _
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    incluiFornecedorXml()

                Else

                    Me.txt_xmserie.Text = "" : Me.txt_xmnumero.Text = "" : Me.msk_xmemissao.Text = ""
                    Me.msk_cnpj.Text = "" : Me.txt_implocal.Text = ""
                    Me.btn_implocal.Focus() : Return

                End If

            Else

                If verifNotaExist(_codFornXML, Me.txt_xmnumero.Text, Me.txt_xmserie.Text) Then

                    MsgBox("Nota já registrada no Banco de Dados!", MsgBoxStyle.Exclamation)
                    Me.txt_xmserie.Text = "" : Me.txt_xmnumero.Text = "" : Me.msk_xmemissao.Text = ""
                    Me.msk_cnpj.Text = "" : Me.txt_implocal.Text = ""
                    Me.btn_implocal.Focus() : Return

                End If
            End If
            ativaCamposItenXML()
            lbl_xmTipoNota.Text = "NFE"

            ' Inscrição Estadual <IE>
            xpos1 = StrXml.IndexOf("<IE>") : xposfim = StrXml.IndexOf("</IE>")
            xposdif = (xposfim - xpos1) - 4
            Me.txt_xminscricao.Text = Mid(StrXml, xpos1 + 5, xposdif)

            ' tipo de Empresa CRT
            xpos = StrXml.IndexOf("<CRT>")
            Mcrt = Convert.ToInt16(Mid(StrXml, xpos + 6, 1))
            Me.txt_xmtipoemp.Text = "EMPRESA NORMAL"
            If Mcrt = 1 Then Me.txt_xmtipoemp.Text = "SIMPLES NACIONAL"

            ' Razao Social
            xpos1 = StrXml.IndexOf("<xNome>") : xposfim = StrXml.IndexOf("</xNome>")
            xposdif = (xposfim - xpos1) - 7
            Me.txt_xmfornecedor.Text = Mid(StrXml, xpos1 + 8, xposdif)

            ' <UF>
            xpos1 = StrXml.IndexOf("<UF>") : xposfim = StrXml.IndexOf("</UF>")
            xposdif = (xposfim - xpos1) - 4
            Me.txt_xmuf.Text = Mid(StrXml, xpos1 + 5, xposdif)
            mbUf = Me.txt_xmuf.Text

            Dim mUfEstab As String = "PI" 'UF global do estabelecimento
            _clFunc.PreenchComboCfopEntradas(mUfEstab, Me.txt_xmuf.Text, Me.cbo_xmcfopNF, MdlConexaoBD.conectionPadrao)
            _clFunc.PreenchComboCfopEntradas(mUfEstab, Me.txt_xmuf.Text, Me.cbo_xmcfopProd, MdlConexaoBD.conectionPadrao)
            mUfEstab = Nothing

            pegaTotaisNFeXML()

            While True
                ' Codigo do Produto
                xpos1 = StrXml.IndexOf("<cProd>") : posNextProd = xpos1 - 1
                xposfim = StrXml.IndexOf("</cProd>") : xposdif = (xposfim - xpos1) - 7
                mAuxValores = Mid(StrXml, xpos1 + 8, xposdif)
                If mAuxValores.Length > 14 Then mAuxValores = Mid(mAuxValores, mAuxValores.Length - 9, 14)
                Me.txt_xmcodigoForn.Text = mAuxValores 'Mid(StrXml, xpos1 + 8, xposdif)

                ' Descriçao do Produto
                xpos2 = StrXml.IndexOf("<xProd>") : xposfim = StrXml.IndexOf("</xProd>")
                xposdif = (xposfim - xpos2) - 7
                Me.txt_xmprodutoforn.Text = Mid(StrXml, xpos2 + 8, xposdif)

                ' NCM
                xpos3 = StrXml.IndexOf("<NCM>") : xposfim = StrXml.IndexOf("</NCM>")
                xposdif = (xposfim - xpos3) - 5
                Me.txt_xmncmForn.Text = Mid(StrXml, xpos3 + 6, xposdif)

                ' Unidade
                xpos4 = StrXml.IndexOf("<uCom>") : xposfim = StrXml.IndexOf("</uCom>")
                xposdif = (xposfim - xpos4) - 6
                Me.txt_xmunidForn.Text = Mid(StrXml, xpos4 + 7, xposdif)

                ' Codigo de Barras <cEAN>
                xpos5 = StrXml.IndexOf("<cEAN>") : xposfim = StrXml.IndexOf("</cEAN>")
                xposdif = (xposfim - xpos5) - 6
                If xposdif > 5 Then Me.txt_xmcodbarraForn.Text = Mid(StrXml, xpos5 + 7, xposdif)

                ' Valor Unitario <vUnCom>
                xpos6 = StrXml.IndexOf("<vUnCom>") : xposfim = StrXml.IndexOf("</vUnCom>")
                xposdif = (xposfim - xpos6) - 8
                Me.txt_xmpcounit.Text = Mid(StrXml, xpos6 + 9, xposdif)
                Try
                    mAuxValores = Mid(StrXml, xpos6 + 9, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : _vlCompProdXml = CDbl(mAuxValores)

                Catch ex As Exception
                    _vlCompProdXml = 0.0
                End Try


                ' Total dos Produtos <vProd>
                xpos7 = StrXml.IndexOf("<vProd>") : xposfim = StrXml.IndexOf("</vProd>")
                xposdif = (xposfim - xpos7) - 7
                Me.txt_xmprtot.Text = Mid(StrXml, xpos7 + 8, xposdif)

                ' Quantidade <qCom>
                xpos8 = StrXml.IndexOf("<qCom>") : xposfim = StrXml.IndexOf("</qCom>")
                xposdif = (xposfim - xpos8) - 6
                Me.txt_xmqtde.Text = Mid(StrXml, xpos8 + 7, xposdif)


                If Not Me.txt_xmcodigoForn.Text.Equals("") Then

                    Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Try
                        conn.Open()
                        Me.txt_xmcodpr.Text = _clBD.pegaRelacionProdFornXML(_clFunc.RemoverCaracter(Me.msk_cnpj.Text), _
                                       Me.txt_xmcodigoForn.Text, conn)
                        conn.Close()
                    Catch ex As Exception
                    Finally
                        conn = Nothing
                    End Try

                End If


                Exit While
            End While

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Private Sub btn_importar_ClickCteXML(ByVal StrXml As String)

        Dim xpos, xpos1, xpos2, xposfim, xposdif, xmnum, mxSerie As Integer
        Dim _Dtemis, xmCnpjCpf, mAux, mAuxStr As String
        xpos = _valorZERO : xpos1 = _valorZERO : xpos2 = _valorZERO : xposfim = _valorZERO : xposdif = _valorZERO

        Try
            ' CHAVE CTe
            xpos2 = StrXml.IndexOf("<infCte ") : mAuxStr = StrXml.Substring(xpos2)
            xpos2 = StrXml.IndexOf("Id=""CTe") : _chaveNFeXML = StrXml.Substring(xpos2 + 7, 44)


            xpos1 = StrXml.IndexOf("<ide>") : xpos2 = StrXml.IndexOf("</ide>")
            mAuxStr = StrXml.Substring(xpos1, (xpos2 - xpos1))

            xpos1 = StrXml.IndexOf("<emit>") : xpos2 = StrXml.IndexOf("</emit>")
            mAux = StrXml.Substring(xpos1, (xpos2 - xpos1))


            ' Serie
            xpos1 = mAuxStr.IndexOf("<serie>") : xpos2 = mAuxStr.IndexOf("</serie>")
            mxSerie = mAuxStr.Substring(xpos1 + 7, (xpos2 - (xpos1 + 7)))
            Me.txt_xmserie.Text = Convert.ToInt16(mxSerie)

            ' Numero da NFe
            xpos2 = mAuxStr.IndexOf("<nCT>") : xposfim = mAuxStr.IndexOf("</nCT>")
            xposdif = (xposfim - xpos2) - 5
            xmnum = Convert.ToInt32(Mid(mAuxStr, xpos2 + 6, xposdif))
            Me.txt_xmnumero.Text = String.Format("{0:D9}", xmnum)

            ' Data de Emissao <dEmi>
            xpos1 = mAuxStr.IndexOf("<dhEmi>") : xposfim = mAuxStr.IndexOf("</dhEmi>")
            xposdif = (xposfim - xpos1) - 7
            _Dtemis = mAuxStr.Substring(xpos1 + 7, 10)
            Me.msk_xmemissao.Text = Mid(_Dtemis, 9, 2) & "/" & Mid(_Dtemis, 6, 2) & "/" & Mid(_Dtemis, 1, 4)

            ' Numero do CNPJ
            xpos1 = mAux.IndexOf("<CNPJ>") : xposfim = mAux.IndexOf("</CNPJ>")
            xposdif = (xposfim - xpos1) - 6
            xmCnpjCpf = mAux.Substring(xpos1 + 6, xposdif)
            Me.msk_cnpj.Text = xmCnpjCpf


            _codFornXML = ""
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try
                oConnBDGENOV.Open()

                Dim sqlNF As New StringBuilder
                Dim cmdNF As NpgsqlCommand
                Dim drNF As NpgsqlDataReader

                sqlNF.Append("SELECT p_cod FROM cadp001 WHERE p_cgc = '" & xmCnpjCpf & "' OR ")
                sqlNF.Append("p_cpf = '" & xmCnpjCpf & "'")
                cmdNF = New NpgsqlCommand(sqlNF.ToString, oConnBDGENOV)
                drNF = cmdNF.ExecuteReader

                While drNF.Read

                    _codFornXML = drNF(_valorZERO)

                End While
                drNF.Close() : oConnBDGENOV.ClearPool()
                cmdNF = Nothing : sqlNF = Nothing : drNF = Nothing
                oConnBDGENOV.Close()

            Catch ex As Exception
            Finally
                oConnBDGENOV = Nothing
            End Try


            'Verifica a Nota...
            If _codFornXML.Equals("") Then

                If MessageBox.Show("Fornecedor não existe no Banco de Dados! Deseja incluí-lo?", "METROSYS", MessageBoxButtons.YesNo, _
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    incluiFornecedorXml()

                Else

                    Me.txt_xmserie.Text = "" : Me.txt_xmnumero.Text = "" : Me.msk_xmemissao.Text = ""
                    Me.msk_cnpj.Text = "" : Me.txt_implocal.Text = ""
                    Me.btn_implocal.Focus() : Return

                End If

            Else

                If verifNotaExist(_codFornXML, Me.txt_xmnumero.Text, Me.txt_xmserie.Text) Then

                    MsgBox("Nota já registrada no Banco de Dados!", MsgBoxStyle.Exclamation)
                    Me.txt_xmserie.Text = "" : Me.txt_xmnumero.Text = "" : Me.msk_xmemissao.Text = ""
                    Me.msk_cnpj.Text = "" : Me.txt_implocal.Text = ""
                    Me.btn_implocal.Focus() : Return

                End If
            End If
            desativaCamposItenXML()
            lbl_xmTipoNota.Text = "FTE"

            ' Inscrição Estadual <IE>
            xpos1 = mAux.IndexOf("<IE>") : xposfim = mAux.IndexOf("</IE>")
            xposdif = (xposfim - xpos1) - 4
            Me.txt_xminscricao.Text = Mid(mAux, xpos1 + 5, xposdif)

            '' tipo de Empresa CRT falta pesquisar
            'xpos = StrXml.IndexOf("<CRT>")
            'Mcrt = Convert.ToInt16(Mid(StrXml, xpos + 6, 1))
            'Me.txt_xmtipoemp.Text = "EMPRESA NORMAL"
            'If Mcrt = 1 Then Me.txt_xmtipoemp.Text = "SIMPLES NACIONAL"

            ' Razao Social
            xpos1 = mAux.IndexOf("<xNome>") : xposfim = mAux.IndexOf("</xNome>")
            xposdif = (xposfim - xpos1) - 7
            Me.txt_xmfornecedor.Text = Mid(mAux, xpos1 + 8, xposdif)

            ' <UF>
            xpos1 = mAux.IndexOf("<UF>") : xposfim = mAux.IndexOf("</UF>")
            xposdif = (xposfim - xpos1) - 4
            Me.txt_xmuf.Text = Mid(mAux, xpos1 + 5, xposdif)
            mbUf = Me.txt_xmuf.Text

            Dim mUfEstab As String = "PI" 'UF global do estabelecimento
            _clFunc.PreenchComboCfopEntradas(mUfEstab, Me.txt_xmuf.Text, Me.cbo_xmcfopNF, MdlConexaoBD.conectionPadrao)
            _clFunc.PreenchComboCfopEntradas(mUfEstab, Me.txt_xmuf.Text, Me.cbo_xmcfopProd, MdlConexaoBD.conectionPadrao)
            mUfEstab = Nothing

            Me.cbo_xmcfopNF.SelectedIndex = trazIndexCfop("1.353", Me.cbo_xmcfopNF)
            If Me.cbo_xmcfopNF.SelectedIndex < _valorZERO Then

                Me.cbo_xmcfopNF.SelectedIndex = trazIndexCfop("2.353", Me.cbo_xmcfopNF)

            End If

            pegaTotaisCTeXML()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub btn_importar_ClickExtracted()

        Dim StrXml As String
        _importXml = True
        Try
            ' deleta a rquivo anterior
            If File.Exists(RTrim(ArqTmp.ToString)) Then File.Delete(RTrim(ArqTmp.ToString))

            ' Cria copia do arquivo xml p/ arquivo temporario
            File.Copy(RTrim(Me.txt_implocal.Text), ArqTmp, True)
            Dim MyfileStream As New IO.StreamReader(ArqTmp.ToString)

            StrXml = MyfileStream.ReadToEnd : MyfileStream.Close() : MyfileStream = Nothing

            If StrXml.IndexOf("<infNFe ") >= _valorZERO Then

                btn_importar_ClickNFeXML(StrXml)

            ElseIf StrXml.IndexOf("<infCte ") >= _valorZERO Then

                btn_importar_ClickCteXML(StrXml)

            End If

            'copia o arquivo com o nome do estabelecimento
            File.Copy(RTrim(Me.txt_implocal.Text), "\wged\xml\" & MdlUsuarioLogando._local & "_" & _
                      txt_xmnumero.Text & ".xml", True)

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Private Sub desativaCamposItenXML()

        Me.txt_xmcodpr.Enabled = False : Me.txt_xmqtde.Enabled = False : Me.cbo_xmcfopProd.Enabled = False
        Me.btn_xmadiciona.Enabled = False : Me.cbo_xmTipoFrete.Enabled = True : Me.cbo_xmcst.Enabled = False

    End Sub

    Private Sub ativaCamposItenXML()

        Me.txt_xmcodpr.Enabled = True : Me.txt_xmqtde.Enabled = True : Me.cbo_xmcfopProd.Enabled = True
        Me.btn_xmadiciona.Enabled = True : Me.btn_xmsair.Enabled = True : Me.cbo_xmTipoFrete.Enabled = False
        Me.cbo_xmcst.Enabled = True

    End Sub

    Private Sub btn_importar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_importar.Click

        If Not Me.txt_implocal.Text.Equals("") Then btn_importar_ClickExtracted()

    End Sub

    Private Sub pegaTotaisNFeXML()

        Dim StrXml As String

        Try
            ' deleta a rquivo anterior
            If File.Exists(RTrim(ArqTmp.ToString)) Then File.Delete(RTrim(ArqTmp.ToString))

            ' Cria copia do arquivo xml p/ arquivo temporario
            File.Copy(RTrim(Me.txt_implocal.Text), ArqTmp, True)

            Dim MyfileStream As New IO.StreamReader(ArqTmp.ToString)
            Dim posTotal As Integer = _valorZERO

            StrXml = MyfileStream.ReadToEnd : posTotal = StrXml.IndexOf("<total>")
            StrXml = StrXml.Substring(posTotal, (StrXml.Length - posTotal))
            MyfileStream.Close() : MyfileStream = Nothing

            Dim xpos, xpos1, xpos2, xposfim, xposdif As Integer
            Dim mAuxValores As String = "0"

            xpos = _valorZERO : xpos1 = _valorZERO : xpos2 = _valorZERO : xposfim = _valorZERO
            xposdif = _valorZERO

            ' Total da Base do ICMS <vBC>
            xpos1 = StrXml.IndexOf("<vBC>") : xposfim = StrXml.IndexOf("</vBC>")
            xposdif = (xposfim - xpos1) - 5

            Try
                mAuxValores = Mid(StrXml, xpos1 + 6, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totBcICMS = CDbl(mAuxValores)

            Catch ex As Exception
                _totBcICMS = 0.0
            End Try


            ' Total do valor do ICMS <vICMS>
            xpos1 = StrXml.IndexOf("<vICMS>") : xposfim = StrXml.IndexOf("</vICMS>")
            xposdif = (xposfim - xpos1) - 7
            Try
                mAuxValores = Mid(StrXml, xpos1 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totICMS = CDbl(mAuxValores)

            Catch ex As Exception
                _totICMS = 0.0
            End Try


            ' Total da Base do ICMS SUBSTITUTO <vBCST>
            xpos1 = StrXml.IndexOf("<vBCST>") : xposfim = StrXml.IndexOf("</vBCST>")
            xposdif = (xposfim - xpos1) - 7
            Try
                mAuxValores = Mid(StrXml, xpos1 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totBcST = CDbl(mAuxValores)

            Catch ex As Exception
                _totBcST = 0.0
            End Try


            ' Total do ICMS SUBSTITUTO <vST>
            xpos1 = StrXml.IndexOf("<vST>") : xposfim = StrXml.IndexOf("</vST>")
            xposdif = (xposfim - xpos1) - 5
            Try
                mAuxValores = Mid(StrXml, xpos1 + 6, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totST = CDbl(mAuxValores)

            Catch ex As Exception
                _totST = 0.0
            End Try


            ' Total dos PRODUTOS <vProd>
            xpos1 = StrXml.IndexOf("<vProd>") : xposfim = StrXml.IndexOf("</vProd>")
            xposdif = (xposfim - xpos1) - 7
            Try
                mAuxValores = Mid(StrXml, xpos1 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totPROD = CDbl(mAuxValores)

            Catch ex As Exception
                _totPROD = 0.0
            End Try


            ' Total do FRETE <vFrete>
            xpos1 = StrXml.IndexOf("<vFrete>") : xposfim = StrXml.IndexOf("</vFrete>")
            xposdif = (xposfim - xpos1) - 8
            Try
                mAuxValores = Mid(StrXml, xpos1 + 9, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totFRETE = CDbl(mAuxValores)

            Catch ex As Exception
                _totFRETE = 0.0
            End Try


            ' Total do SEGURO <vSeg>
            xpos1 = StrXml.IndexOf("<vSeg>") : xposfim = StrXml.IndexOf("</vSeg>")
            xposdif = (xposfim - xpos1) - 6
            Try
                mAuxValores = Mid(StrXml, xpos1 + 7, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totSEGU = CDbl(mAuxValores)

            Catch ex As Exception
                _totSEGU = 0.0
            End Try


            ' Total do DESCONTO <vDesc>
            xpos1 = StrXml.IndexOf("<vDesc>") : xposfim = StrXml.IndexOf("</vDesc>")
            xposdif = (xposfim - xpos1) - 7
            Try
                mAuxValores = Mid(StrXml, xpos1 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totDESC = CDbl(mAuxValores)

            Catch ex As Exception
                _totDESC = 0.0
            End Try


            ' Total do IPI <vIPI>
            xpos1 = StrXml.IndexOf("<vIPI>") : xposfim = StrXml.IndexOf("</vIPI>")
            xposdif = (xposfim - xpos1) - 6
            Try
                mAuxValores = Mid(StrXml, xpos1 + 7, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totIPI = CDbl(mAuxValores)

            Catch ex As Exception
                _totIPI = 0.0
            End Try


            ' Total de OUTRAS DESPESAS <vOutro>
            xpos1 = StrXml.IndexOf("<vOutro>") : xposfim = StrXml.IndexOf("</vOutro>")
            xposdif = (xposfim - xpos1) - 8
            Try
                mAuxValores = Mid(StrXml, xpos1 + 9, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totOutrDESP = CDbl(mAuxValores)

            Catch ex As Exception
                _totOutrDESP = 0.0
            End Try


            ' Total da NOTA <vNF>
            xpos1 = StrXml.IndexOf("<vNF>") : xposfim = StrXml.IndexOf("</vNF>")
            xposdif = (xposfim - xpos1) - 5
            Try
                mAuxValores = Mid(StrXml, xpos1 + 6, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totNOTA = CDbl(mAuxValores)

            Catch ex As Exception
                _totNOTA = 0.0
            End Try

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Private Sub pegaTotaisCTeXML()

        Dim StrXml As String

        Try
            ' deleta a rquivo anterior
            If File.Exists(RTrim(ArqTmp.ToString)) Then File.Delete(RTrim(ArqTmp.ToString))

            ' Cria copia do arquivo xml p/ arquivo temporario
            File.Copy(RTrim(Me.txt_implocal.Text), ArqTmp, True)
            Dim MyfileStream As New IO.StreamReader(ArqTmp.ToString)
            Dim posTotal As Integer = _valorZERO

            StrXml = MyfileStream.ReadToEnd : MyfileStream.Close() : MyfileStream = Nothing
            Dim xpos1, xpos2, xposfim, xposdif As Integer, mAuxValores, mAuxStr As String
            xpos1 = _valorZERO : xpos2 = _valorZERO : xposfim = _valorZERO : xposdif = _valorZERO

            xpos1 = StrXml.IndexOf("<imp>") : xposfim = StrXml.IndexOf("</imp>")
            xposdif = (xposfim - xpos1) - 5 : mAuxStr = Mid(StrXml, xpos1 + 6, xposdif)


            ' Total da Base do ICMS <vBC>
            xpos1 = mAuxStr.IndexOf("<vBC>") : xposfim = mAuxStr.IndexOf("</vBC>")
            xposdif = (xposfim - xpos1) - 5
            Try
                mAuxValores = Mid(mAuxStr, xpos1 + 6, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totBcICMS = CDbl(mAuxValores)

            Catch ex As Exception
                _totBcICMS = 0.0
            End Try


            ' Total do valor do ICMS <vICMS>
            xpos1 = mAuxStr.IndexOf("<vICMS>") : xposfim = mAuxStr.IndexOf("</vICMS>")
            xposdif = (xposfim - xpos1) - 7
            Try
                mAuxValores = Mid(mAuxStr, xpos1 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totICMS = CDbl(mAuxValores)

            Catch ex As Exception
                _totICMS = 0.0
            End Try


            ' Total da Base do ICMS SUBSTITUTO <vBCST>
            xpos1 = mAuxStr.IndexOf("<vBCST>") : xposfim = mAuxStr.IndexOf("</vBCST>")
            xposdif = (xposfim - xpos1) - 7
            Try
                mAuxValores = Mid(mAuxStr, xpos1 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totBcST = CDbl(mAuxValores)

            Catch ex As Exception
                _totBcST = 0.0
            End Try


            ' Total do ICMS SUBSTITUTO <vST>
            xpos1 = mAuxStr.IndexOf("<vST>") : xposfim = mAuxStr.IndexOf("</vST>")
            xposdif = (xposfim - xpos1) - 5
            Try
                mAuxValores = Mid(mAuxStr, xpos1 + 6, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totST = CDbl(mAuxValores)

            Catch ex As Exception
                _totST = 0.0
            End Try


            ' Total dos PRODUTOS <vProd>
            xpos1 = mAuxStr.IndexOf("<vProd>") : xposfim = mAuxStr.IndexOf("</vProd>")
            xposdif = (xposfim - xpos1) - 7
            Try
                mAuxValores = Mid(mAuxStr, xpos1 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totPROD = CDbl(mAuxValores)

            Catch ex As Exception
                _totPROD = 0.0
            End Try


            ' Total do FRETE <vFrete>
            xpos1 = mAuxStr.IndexOf("<vFrete>") : xposfim = mAuxStr.IndexOf("</vFrete>")
            xposdif = (xposfim - xpos1) - 8
            Try
                mAuxValores = Mid(mAuxStr, xpos1 + 9, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totFRETE = CDbl(mAuxValores)

            Catch ex As Exception
                _totFRETE = 0.0
            End Try


            ' Total do SEGURO <vSeg>
            xpos1 = mAuxStr.IndexOf("<vSeg>") : xposfim = mAuxStr.IndexOf("</vSeg>")
            xposdif = (xposfim - xpos1) - 6
            Try
                mAuxValores = Mid(mAuxStr, xpos1 + 7, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totSEGU = CDbl(mAuxValores)

            Catch ex As Exception
                _totSEGU = 0.0
            End Try


            ' Total do DESCONTO <vDesc>
            xpos1 = mAuxStr.IndexOf("<vDesc>") : xposfim = mAuxStr.IndexOf("</vDesc>")
            xposdif = (xposfim - xpos1) - 7
            Try
                mAuxValores = Mid(mAuxStr, xpos1 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totDESC = CDbl(mAuxValores)

            Catch ex As Exception
                _totDESC = 0.0
            End Try


            ' Total do IPI <vIPI>
            xpos1 = mAuxStr.IndexOf("<vIPI>") : xposfim = mAuxStr.IndexOf("</vIPI>")
            xposdif = (xposfim - xpos1) - 6
            Try
                mAuxValores = Mid(mAuxStr, xpos1 + 7, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totIPI = CDbl(mAuxValores)

            Catch ex As Exception
                _totIPI = 0.0
            End Try


            ' Total de OUTRAS DESPESAS <vOutro>
            xpos1 = mAuxStr.IndexOf("<vOutro>") : xposfim = mAuxStr.IndexOf("</vOutro>")
            xposdif = (xposfim - xpos1) - 8
            Try
                mAuxValores = Mid(mAuxStr, xpos1 + 9, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totOutrDESP = CDbl(mAuxValores)

            Catch ex As Exception
                _totOutrDESP = 0.0
            End Try

            xpos1 = StrXml.IndexOf("<vPrest>") : xposfim = StrXml.IndexOf("</vPrest>")
            xposdif = (xposfim - xpos1) - 8 : mAuxStr = Mid(StrXml, xpos1 + 9, xposdif)


            ' Total da NOTA <vNF>
            xpos1 = mAuxStr.IndexOf("<vTPrest>") : xposfim = mAuxStr.IndexOf("</vTPrest>")
            xposdif = (xposfim - xpos1) - 9
            Try
                mAuxValores = Mid(mAuxStr, xpos1 + 10, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                mAuxValores = mAuxValores.Replace(".", ",") : _totNOTA = CDbl(mAuxValores)

            Catch ex As Exception
                _totNOTA = 0.0
            End Try
            Me.lbl_xmVlTot.Text = Format(_totNOTA, "###,##0.00")

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Public Function Ler_ArquivoXML(ByVal ArqXMl) As String

        Dim fs As New FileStream(ArqXMl, FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(fs)
        Dim xByte As Integer
        Dim linha, MResult As String
        MResult = ""

        Try
            Do
                'lê uma linha de cada vez
                linha = sr.ReadLine() : MResult = MResult & linha

            Loop Until linha Is Nothing
            sr.Close()
            xByte = Len(MResult)

            Return Trim(MResult)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        Return ("ERRO:")
    End Function

    Private Sub btn_adiciona_ClickExtracted()

        If Me.dtgXmlItens.ColumnCount <= _valorZERO Then addColunasItensXml()
        relacionaProduto()


        If _prodEditXml.Equals("") Then

            addItenXmlGrid()

        Else

            addItenEditXmlGrid()

        End If

        Me.dtgXmlItens.Refresh() : atuaXmlVlTotal() : proximoItenXml() : Me.txt_xmcodpr.Focus()



    End Sub

    Private Sub relacionaProduto()

        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try


        Try

            If _clBD.existRelacionProdFornXML(_clFunc.RemoverCaracter(Me.msk_cnpj.Text), Me.txt_xmcodigoForn.Text, _
                                              Me.txt_xmcodpr.Text, conn) = False Then

                transacao = conn.BeginTransaction
                Try

                    If _clBD.alterouRelacionProdFornXML(_clFunc.RemoverCaracter(Me.msk_cnpj.Text), Me.txt_xmcodigoForn.Text, Me.txt_xmcodpr.Text, _
                                              conn) Then

                        If MessageBox.Show("Deseja associar este produto ?", "Associação com Produtos", _
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) Then

                            Dim antigoCodProdLoja As String = _clBD.pegaRelacionProdFornXML( _
                            _clFunc.RemoverCaracter(Me.msk_cnpj.Text), Me.txt_xmcodigoForn.Text, conn)

                            _clBD.updateProdFornecedorXML(_clFunc.RemoverCaracter(Me.msk_cnpj.Text), Me.txt_xmcodigoForn.Text, Me.txt_xmunidForn.Text, _
                                                      Me.txt_xmcodpr.Text, Me.txt_xmundprod.Text, antigoCodProdLoja, conn, transacao)
                            antigoCodProdLoja = Nothing

                        End If

                    Else

                        If MessageBox.Show("Deseja associar este produto ?", "Associação com Produtos", _
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) Then

                            _clBD.insertProdFornecedorXML(_clFunc.RemoverCaracter(Me.msk_cnpj.Text), Me.txt_xmcodigoForn.Text, Me.txt_xmunidForn.Text, _
                                                      Me.txt_xmcodpr.Text, Me.txt_xmundprod.Text, conn, transacao)

                        End If

                    End If

                    transacao.Commit() : conn.ClearPool()
                Catch ex1 As Exception
                    Try
                        transacao.Rollback()
                    Catch ex2 As Exception
                    End Try
                End Try

            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally

            If conn.State = ConnectionState.Open Then conn.Close()
            conn = Nothing : transacao = Nothing
        End Try



    End Sub

    Private Sub btn_adiciona_ClickExtracted1()

        If IsNumeric(Me.txt_xmqtde.Text) Then

            If CDbl(Me.txt_xmqtde.Text) > _valorZERO Then

                If Not Trim(Me.txt_xmNomeProd.Text).Equals("") Then

                    If verifCamposImportXml() Then btn_adiciona_ClickExtracted()

                Else

                    MsgBox("Favor associar este produto", MsgBoxStyle.Exclamation)
                    Me.txt_xmcodpr.Focus() : Me.txt_xmcodpr.SelectAll()

                End If

            Else

                MsgBox("Quantidade do Item deve ser maior que ZERO", MsgBoxStyle.Exclamation)

            End If

        Else

            MsgBox("Valor de Quantidade inválido", MsgBoxStyle.Exclamation)

        End If



    End Sub

    Private Sub btn_adiciona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_xmadiciona.Click

        If Me.cbo_xmlocal.SelectedIndex >= _valorZERO Then

            If Trim(Me.txt_xmcodpr.Text).Equals("") AndAlso Not Trim(Me.txt_xmcodigoForn.Text).Equals("") Then

                MsgBox("Favor associar este produto", MsgBoxStyle.Exclamation)
                Me.txt_xmcodpr.Focus()

            ElseIf Not Trim(Me.txt_xmcodpr.Text).Equals("") AndAlso Not Trim(Me.txt_xmcodigoForn.Text).Equals("") Then

                btn_adiciona_ClickExtracted1()

            End If

        Else

            MsgBox("Favor informe o local desse produto", MsgBoxStyle.Exclamation)
            Me.cbo_xmlocal.Focus()

        End If



    End Sub

    Private Sub atuaXmlVlTotal()

        Dim mValor, mValorTotal As Decimal

        mValor = _valorZERO
        mValorTotal = _valorZERO
        'Soma valor bruto dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(9).Value '(col.Cells(6).Value * col.Cells(7).Value)

        Next
        mValorTotal += mValor


        mValor = _valorZERO
        'Soma valor da substituição dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(17).Value

        Next
        mValorTotal += mValor


        mValor = _valorZERO
        'Soma valor IPI dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(19).Value

        Next
        mValorTotal += mValor


        mValor = _valorZERO
        'Soma valor Frete dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(21).Value

        Next
        mValorTotal += mValor


        mValor = _valorZERO
        'Soma valor Seguro dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(22).Value

        Next
        mValorTotal += mValor

        mValor = _valorZERO
        'Soma valor Outras Despesas dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(23).Value

        Next
        mValorTotal += mValor


        mValor = _valorZERO
        'Soma valor Desconto dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(29).Value

        Next
        mValorTotal -= mValor

        Me.lbl_xmVlTot.Text = Format(mValorTotal, "##,##0.00")



    End Sub

    Private Sub addItenXmlGrid()

        Dim StrXml, StrXmlAux As String
        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd, mUndProd As String
        Dim mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd As Double
        Dim mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mVlBcSubsProd As Double
        Dim mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd As Double
        Dim mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd As Double
        Dim mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF As Double
        Dim mAuxValores As String

        Try
            ' deleta arquivo anterior
            If File.Exists(RTrim(ArqTmp.ToString)) Then File.Delete(RTrim(ArqTmp.ToString))

            ' Cria copia do arquivo xml p/ arquivo temporario
            File.Copy(RTrim(Me.txt_implocal.Text), ArqTmp, True)
            Dim MyfileStream As New IO.StreamReader(ArqTmp.ToString)

            StrXml = MyfileStream.ReadToEnd : MyfileStream.Close() : MyfileStream = Nothing

            Dim xpos, xpos1, xpos2, xpos3, xpos7, xpos8, xposfim, xposdif As Integer
            xpos = _valorZERO : xpos1 = _valorZERO : xpos2 = _valorZERO : xposfim = _valorZERO
            xposdif = _valorZERO

            Try
                mCsosnProd = "" : StrXmlAux = StrXml

                xpos1 = StrXml.IndexOf("<cProd>", posNextProd)
                If xpos1 >= _valorZERO Then

                    xposfim = StrXml.IndexOf("</det>", posNextProd)
                    xpos3 = xposfim - xpos1
                    StrXmlAux = StrXml.Substring(xpos1, xpos3)

                End If
                posNextProd = xpos1 - 1


                ' Codigo do Produto
                mCodProd = Me.txt_xmcodpr.Text

                ' Descriçao do Produto
                mNomeProd = Me.txt_xmNomeProd.Text

                ' NCM
                xpos3 = StrXmlAux.IndexOf("<NCM>")
                xposfim = StrXmlAux.IndexOf("</NCM>")
                xposdif = (xposfim - xpos3) - 5
                mNcmProd = Mid(StrXmlAux, xpos3 + 6, xposdif)


                ' CFOP <CFOP>
                mCfopProd = Mid(Me.cbo_xmcfopProd.Text, 1, 1) & Mid(Me.cbo_xmcfopProd.Text, 3, 3) 'Mid(StrXmlAux, xpos8 + 7, xposdif)

                ' CST <CST>
                mCstProd = cbo_xmcst.Text.Substring(0, 2)

                ' Unidade
                mUndProd = Me.txt_xmundprod.Text 'mbUndProd '<---

                '' Codigo de Barras <cEAN>    Falta revisar!
                'xpos5 = StrXmlAux.IndexOf("<cEAN>")
                'xposfim = StrXmlAux.IndexOf("</cEAN>")
                'xposdif = (xposfim - xpos5) - 6
                'If xposdif > 5 Then
                '    Me.txt_xmcdbarra.Text = Mid(StrXmlAux, xpos5 + 7, xposdif)
                'End If

                'Preço unitario de Compra do Produto
                mVlUnitComprProd = Round(CDbl(Me.txt_xmpcounit.Text), 2)


                ' Total dos Produtos <vProd>
                xpos7 = StrXmlAux.IndexOf("<vProd>") : xposfim = StrXmlAux.IndexOf("</vProd>")
                xposdif = (xposfim - xpos7) - 7
                Try
                    mAuxValores = Mid(StrXmlAux, xpos7 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlTotProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlTotProd = 0.0
                End Try


                ' Quantidade <qCom>
                xpos8 = StrXmlAux.IndexOf("<qCom>") : xposfim = StrXmlAux.IndexOf("</qCom>")
                xposdif = (xposfim - xpos8) - 6
                Try
                    mAuxValores = Me.txt_xmqtde.Text : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mQtdeProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mQtdeProd = 0.0
                End Try


                'Valor Unitario <vUnCom>
                mVlUnitComprProd = 0.0
                mVlUnitComprProd = Round(mVlTotProd / mQtdeProd, 2)


                'ICMS NORMAL ... 
                ' Base de calculo do ICMS <vBC>
                xpos8 = StrXmlAux.IndexOf("<vBC>") : xposfim = StrXmlAux.IndexOf("</vBC>")
                xposdif = (xposfim - xpos8) - 5
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 6, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlBcIcmsProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlBcIcmsProd = 0.0
                End Try


                ' ALIQUOTA DO ICMS <pICMS>
                xpos8 = StrXmlAux.IndexOf("<pICMS>") : xposfim = StrXmlAux.IndexOf("</pICMS>")
                xposdif = (xposfim - xpos8) - 7
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlAlqIcmsProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlAlqIcmsProd = 0.0
                End Try


                ' VALOR DO ICMS <vICMS>
                xpos8 = StrXmlAux.IndexOf("<vICMS>") : xposfim = StrXmlAux.IndexOf("</vICMS>")
                xposdif = (xposfim - xpos8) - 7
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlIcmsProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlIcmsProd = 0.0
                End Try


                'SUBSTITUIÇÃO ... 
                ' Base de calculo da Substituição <vBCST>
                xpos8 = StrXmlAux.IndexOf("<vBCST>") : xposfim = StrXmlAux.IndexOf("</vBCST>")
                xposdif = (xposfim - xpos8) - 7
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlBcSubsProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlBcSubsProd = 0.0
                End Try


                ' aliquota da Substituição <pICMSST>
                xpos8 = StrXmlAux.IndexOf("<pICMSST>") : xposfim = StrXmlAux.IndexOf("</pICMSST>")
                xposdif = (xposfim - xpos8) - 9
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 10, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlAlqSubsProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlAlqSubsProd = 0.0
                End Try


                ' valor da Substituição <vICMSST>
                xpos8 = StrXmlAux.IndexOf("<vICMSST>") : xposfim = StrXmlAux.IndexOf("</vICMSST>")
                xposdif = (xposfim - xpos8) - 9
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 10, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlSubsProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlSubsProd = 0.0
                End Try

                'IPI ... 
                'aliquota do ipi <pIPI>
                xpos8 = StrXmlAux.IndexOf("<pIPI>") : xposfim = StrXmlAux.IndexOf("</pIPI>")
                xposdif = (xposfim - xpos8) - 6
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 7, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlAlqIpiProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlAlqIpiProd = 0.0
                End Try


                'valor do ipi <vIPI>
                xpos8 = StrXmlAux.IndexOf("<vIPI>") : xposfim = StrXmlAux.IndexOf("</vIPI>")
                xposdif = (xposfim - xpos8) - 6
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 7, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlIpiProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlIpiProd = 0.0
                End Try


                'verificação da aliquota do ipi
                If mVlIpiProd > _valorZERO AndAlso mVlAlqIpiProd <= _valorZERO Then

                    If mVlBcIcmsProd > _valorZERO Then

                        mVlAlqIpiProd = Round((mVlIpiProd / mVlBcIcmsProd) * 100, 2)

                    Else
                        mVlAlqIpiProd = Round((mVlIpiProd / mVlTotProd) * 100, 2)

                    End If
                End If


                'valor do Frete <vFrete> 
                xpos8 = StrXmlAux.IndexOf("<vFrete>") : xposfim = StrXmlAux.IndexOf("</vFrete>")
                xposdif = (xposfim - xpos8) - 8
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 9, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlFretProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlFretProd = 0.0
                End Try


                'valor do Seguro <vSeg> 
                xpos8 = StrXmlAux.IndexOf("<vSeg>") : xposfim = StrXmlAux.IndexOf("</vSeg>")
                xposdif = (xposfim - xpos8) - 6
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 7, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlSeguroProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlSeguroProd = 0.0
                End Try


                'valor de Outra Despesas <vOutro> 
                xpos8 = StrXmlAux.IndexOf("<vOutro>") : xposfim = StrXmlAux.IndexOf("</vOutro>")
                xposdif = (xposfim - xpos8) - 8
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 9, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlDespProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlDespProd = 0.0
                End Try


                'valor do Desconto <vDesc> 
                xpos8 = StrXmlAux.IndexOf("<vDesc>") : xposfim = StrXmlAux.IndexOf("</vDesc>")
                xposdif = (xposfim - xpos8) - 7
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlDesc = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlDesc = 0.0
                End Try

                mVlProd = _vlCompProdXml
                mVlUnitProdNF = Round((mVlTotProd - mVlDesc) / mQtdeProd, 2)

                If Mid(mCfopProd, 2, 3).Equals("910") OrElse Mid(mCfopProd, 2, 3).Equals("949") _
                OrElse Mid(mCfopProd, 2, 3).Equals("556") Then

                    mVlTotProd += (mVlSubsProd + mVlIpiProd + mVlFretProd + mVlSeguroProd + mVlDespProd)
                    mVlBcIcmsProd = 0.0 : mVlAlqIcmsProd = 0.0 : mVlIcmsProd = 0.0
                    mVlBcSubsProd = 0.0 : mVlAlqSubsProd = 0.0 : mVlSubsProd = 0.0
                    mVlAlqIpiProd = 0.0 : mVlIpiProd = 0.0 : mVlPercFretProd = 0.0
                    mVlFretProd = 0.0 : mVlSeguroProd = 0.0 : mVlDespProd = 0.0

                End If


                Try
                    Dim mlinha As String() = {mCodProd, mNomeProd, mbUndProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd, mQtdeProd, mVlProd, _
                                                  mVlTotProd, mVlUnitComprProd, mVlUnitProdNF, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, _
                                                  mVlBcSubsProd, mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd, _
                                                  mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd, mVlPercLucroProd, _
                                                  mVlSurgeridoProd, mVlPercDesc, mVlDesc, mVlPercRedProd}

                    'Adicionando Linha
                    Me.dtgXmlItens.Rows.Add(mlinha)
                    dtgXmlItens.Refresh()
                    _produtosXml.Append(posNextProd & "|" & (dtgXmlItens.RowCount - 1) & "|" & mCodProd & "?")
                    posNextProd += 5 : mlinha = Nothing

                    limpaCamposXmlIten()

                Catch ex As Exception
                    MsgBox("Deu ERRO ao Incluir este Item " & ex.Message, MsgBoxStyle.Exclamation)
                End Try
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message.ToString)

        Finally

            'LIMPA OBJETOS DA MEMÓRIA...
            mCodProd = Nothing : mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing
            mCstProd = Nothing : mCsosnProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing
            mVlPercDesc = Nothing : mVlDesc = Nothing : mVlTotProd = Nothing : mVlUnitComprProd = Nothing
            mVlUnitProdNF = Nothing : mVlPercRedProd = Nothing : mVlBcIcmsProd = Nothing
            mVlAlqIcmsProd = Nothing : mVlIcmsProd = Nothing : mVlBcSubsProd = Nothing
            mVlAlqSubsProd = Nothing : mVlSubsProd = Nothing : mVlAlqIpiProd = Nothing
            mVlIpiProd = Nothing : mVlPercFretProd = Nothing : mVlFretProd = Nothing
            mVlSeguroProd = Nothing : mVlDespProd = Nothing : mVlOutrosProd = Nothing
            mVlCustoProd = Nothing : mVlPercLucroProd = Nothing : mVlSurgeridoProd = Nothing

        End Try



    End Sub

    Private Sub limpaCamposXmlIten()

        Me.txt_xmcodigoForn.Text = "" : Me.txt_xmcodbarraForn.Text = "" : Me.txt_xmprodutoforn.Text = ""
        Me.txt_xmqtde.Text = "" : Me.txt_xmpcounit.Text = "" : Me.txt_xmNomeProd.Text = ""
        Me.txt_xmncmForn.Text = "" : Me.txt_xmcodpr.Text = "" : Me.txt_xmprtot.Text = ""
        Me.txt_xmunidForn.Text = ""


    End Sub

    Private Sub proximoItenXml()

        Dim StrXml As String
        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd As String
        Dim mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd As Double
        Dim mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd As Double
        Dim mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd As Double
        Dim mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd As Double
        Dim mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF As Double

        Try
            ' deleta a rquivo anterior
            If File.Exists(RTrim(ArqTmp.ToString)) Then File.Delete(RTrim(ArqTmp.ToString))

            ' Cria copia do arquivo xml p/ arquivo temporario
            File.Copy(RTrim(Me.txt_implocal.Text), ArqTmp, True)
            Dim MyfileStream As New IO.StreamReader(ArqTmp.ToString)
            StrXml = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream = Nothing
            Dim xpos, xpos1, xpos2, xpos3, xpos4, xpos5, xpos6, xpos7, xpos8, xposfim, xposdif As Integer
            Dim mAuxValores As String = "0"
            xpos = _valorZERO : xpos1 = _valorZERO : xpos2 = _valorZERO : xposfim = _valorZERO : xposdif = _valorZERO


            Try

                ' Codigo do Produto
                xpos1 = StrXml.IndexOf("<cProd>", posNextProd)
                If xpos1 >= _valorZERO Then

                    posNextProd = xpos1 - 1 : xposfim = StrXml.IndexOf("</cProd>", posNextProd)
                    xposdif = (xposfim - xpos1) - 7 : Me.txt_xmcodigoForn.Text = Mid(StrXml, xpos1 + 8, xposdif)

                    ' Descriçao do Produto
                    xpos2 = StrXml.IndexOf("<xProd>", posNextProd) : xposfim = StrXml.IndexOf("</xProd>", posNextProd)
                    xposdif = (xposfim - xpos2) - 7 : Me.txt_xmprodutoforn.Text = Mid(StrXml, xpos2 + 8, xposdif)

                    ' NCM
                    xpos3 = StrXml.IndexOf("<NCM>", posNextProd) : xposfim = StrXml.IndexOf("</NCM>", posNextProd)
                    xposdif = (xposfim - xpos3) - 5 : Me.txt_xmncmForn.Text = Mid(StrXml, xpos3 + 6, xposdif)


                    ' Unidade
                    xpos4 = StrXml.IndexOf("<uCom>", posNextProd) : xposfim = StrXml.IndexOf("</uCom>", posNextProd)
                    xposdif = (xposfim - xpos4) - 6
                    If xposdif = 2 Then

                        Me.txt_xmunidForn.Text = Mid(StrXml, xposfim - 1, 2)

                    Else

                        Me.txt_xmunidForn.Text = Mid(StrXml, xpos4 + 7, xposdif)
                    End If


                    ' Codigo de Barras <cEAN>
                    xpos5 = StrXml.IndexOf("<cEAN>", posNextProd) : xposfim = StrXml.IndexOf("</cEAN>", posNextProd)
                    xposdif = (xposfim - xpos5) - 6
                    If xposdif > 5 Then Me.txt_xmcodbarraForn.Text = Mid(StrXml, xpos5 + 7, xposdif)


                    ' Valor Unitario <vUnCom>
                    xpos6 = StrXml.IndexOf("<vUnCom>", posNextProd) : xposfim = StrXml.IndexOf("</vUnCom>", posNextProd)
                    xposdif = (xposfim - xpos6) - 8 : Me.txt_xmpcounit.Text = Mid(StrXml, xpos6 + 9, xposdif)
                    Try

                        mAuxValores = Mid(StrXml, xpos6 + 9, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                        mAuxValores = mAuxValores.Replace(".", ",") : _vlCompProdXml = CDbl(mAuxValores)
                    Catch ex As Exception
                        _vlCompProdXml = 0.0
                    End Try


                    ' Total dos Produtos <vProd>
                    xpos7 = StrXml.IndexOf("<vProd>", posNextProd) : xposfim = StrXml.IndexOf("</vProd>", posNextProd)
                    xposdif = (xposfim - xpos7) - 7 : Me.txt_xmprtot.Text = Mid(StrXml, xpos7 + 8, xposdif)

                    ' Quantidade <qCom>
                    xpos8 = StrXml.IndexOf("<qCom>", posNextProd) : xposfim = StrXml.IndexOf("</qCom>", posNextProd)
                    xposdif = (xposfim - xpos8) - 6 : Me.txt_xmqtde.Text = Mid(StrXml, xpos8 + 7, xposdif)


                    If Not Me.txt_xmcodigoForn.Text.Equals("") Then

                        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                        Try
                            conn.Open()
                            Me.txt_xmcodpr.Text = _clBD.pegaRelacionProdFornXML(_clFunc.RemoverCaracter(Me.msk_cnpj.Text), _
                                           Me.txt_xmcodigoForn.Text, conn)
                            conn.ClearPool()

                        Catch ex As Exception
                        Finally

                            If conn.State = ConnectionState.Open Then conn.Close()
                            conn = Nothing
                        End Try

                    End If
                End If

            Catch ex As Exception
                MsgBox("Não deu ERRO ao Incluir este Item " & ex.Message, MsgBoxStyle.Exclamation)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message.ToString)

        Finally
            'LIMPA OBJETO DA MEMÓRIA...
            mCodProd = Nothing : mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing
            mCstProd = Nothing : mCsosnProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing
            mVlPercDesc = Nothing : mVlDesc = Nothing : mVlTotProd = Nothing : mVlUnitComprProd = Nothing
            mVlUnitProdNF = Nothing : mVlPercRedProd = Nothing : mVlBcIcmsProd = Nothing
            mVlAlqIcmsProd = Nothing : mVlIcmsProd = Nothing : mBcSubsProd = Nothing
            mVlAlqSubsProd = Nothing : mVlSubsProd = Nothing : mVlAlqIpiProd = Nothing
            mVlIpiProd = Nothing : mVlPercFretProd = Nothing : mVlFretProd = Nothing : mVlSeguroProd = Nothing
            mVlDespProd = Nothing : mVlOutrosProd = Nothing : mVlCustoProd = Nothing
            mVlPercLucroProd = Nothing : mVlSurgeridoProd = Nothing

        End Try



    End Sub

    Private Function txt_xmcodpr_KeyDownTrazIndexCfop(ByVal clfProd As String, ByVal cstProd As Integer, _
                                                    ByVal cfvProd As Integer, ByVal cfopNota As String, _
                                                    ByVal cbo_cfop As Object) As Integer

        Dim mIndex As Integer = -1
        If cfopNota.Substring(0, 1).Equals("1") Then 'Se o Fornecedor for de fora

            If clfProd.Equals("00") AndAlso cstProd = 2 AndAlso cfvProd = 1 Then mIndex = trazIndexCfop("1.102", cbo_cfop)
            If clfProd.Equals("00") AndAlso cstProd = 0 AndAlso cfvProd = 1 Then mIndex = trazIndexCfop("1.102", cbo_cfop)
            If clfProd.Equals("00") AndAlso cstProd = 6 AndAlso cfvProd = 3 Then mIndex = trazIndexCfop("1.403", cbo_cfop)
            If clfProd.Equals("00") AndAlso cstProd = 0 AndAlso cfvProd = 4 Then mIndex = trazIndexCfop("1.102", cbo_cfop)

        Else

            If clfProd.Equals("00") AndAlso cstProd = 2 AndAlso cfvProd = 1 Then mIndex = trazIndexCfop("2.102", cbo_cfop)
            If clfProd.Equals("00") AndAlso cstProd = 0 AndAlso cfvProd = 1 Then mIndex = trazIndexCfop("2.102", cbo_cfop)
            If clfProd.Equals("00") AndAlso cstProd = 6 AndAlso cfvProd = 3 Then mIndex = trazIndexCfop("2.403", cbo_cfop)
            If clfProd.Equals("00") AndAlso cstProd = 0 AndAlso cfvProd = 4 Then mIndex = trazIndexCfop("2.102", cbo_cfop)

        End If



        Return mIndex
    End Function

    Private Sub txt_xmcodpr_KeyDownExtracted1()

        'tratamento do CFOP dos itens, pega o CFOP do registro da nota e Set ele nos Itens
        Dim mCfopCbo As String = Me.cbo_xmcfopNF.Text.Substring(_valorZERO, 5)

        If mCfopCbo.Substring(2, 3).Equals("102") OrElse mCfopCbo.Substring(2, 3).Equals("403") _
        OrElse mCfopCbo.Substring(2, 3).Equals("409") Then

            Me.cbo_xmcfopProd.SelectedIndex = txt_xmcodpr_KeyDownTrazIndexCfop(mClfIten, mCstIten, mCfvIten, mCfopCbo, Me.cbo_xmcfopProd)
            If cbo_xmcfopProd.SelectedIndex < _valorZERO Then

                Me.cbo_xmcfopProd.SelectedIndex = trazIndexCfop(mCfopCbo, Me.cbo_xmcfopProd)
                If _totBcST > _valorZERO Then Me.cbo_xmcfopProd.SelectedIndex = trazIndexCfop(mCfopCbo.Substring(_valorZERO, 1) & ".403", Me.cbo_xmcfopProd)

            End If

            'tratamento do CST dos itens
            Me.cbo_xmcst.SelectedIndex = txt_codProd_KeyDownTrazIndexCST(mClfIten, mCstIten, mCfvIten, mCfopCbo, Me.cbo_xmcst)
            If Me.cbo_xmcst.SelectedIndex < 0 Then

                Me.cbo_xmcst.SelectedIndex = trazIndexCST("00", Me.cbo_xmcst)
                If CDec(Me.txt_nfbasesub.Text) > _valorZERO Then Me.cbo_xmcst.SelectedIndex = trazIndexCST("60", Me.cbo_xmcst)

            End If


        ElseIf mCfopCbo.Substring(2, 3).Equals("908") OrElse mCfopCbo.Substring(2, 3).Equals("556") _
        OrElse mCfopCbo.Substring(2, 3).Equals("910") OrElse mCfopCbo.Substring(2, 3).Equals("949") Then

            Me.cbo_xmcfopProd.SelectedIndex = trazIndexCfop(mNF_Cfop, Me.cbo_xmcfopProd)
            'mXmlCstIten = "90"
            Me.cbo_xmcst.SelectedIndex = trazIndexCST("90", Me.cbo_xmcst)

        End If



    End Sub

    Private Sub txt_xmcodpr_KeyDownExtracted()

        Try
            _formBusca = True : _frmREf = Me
            _xmlBuscaProd.set_frmRef(Me) : _xmlBuscaProd.ShowDialog(Me)
            _formBusca = False
            If Me.txt_xmcodpr.Text.Equals("") Then Me.txt_xmcodpr.Focus()
            txt_xmcodpr_KeyDownExtracted1()

        Catch ex As Exception
        End Try



    End Sub

    Private Sub txt_xmcodpr_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_xmcodpr.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

            If Me.txt_xmcodpr.Text.Equals("") Then
                'Aqui tenta chamar a Busca do Produto...
                txt_xmcodpr_KeyDownExtracted()

            Else

                If trazItenXML(Me.txt_xmcodpr.Text) Then

                    txt_xmcodpr_KeyDownExtracted1()

                Else

                    'Aqui tenta chamar a Busca do Produto...
                    txt_xmcodpr_KeyDownExtracted()
                End If
            End If
        End If



    End Sub

    Private Sub addColunasItensXmlExtracted()

        'Adicionando Colunas, nessa ordem...
        Me.dtgXmlItens.Columns.Add("codProd", "CodProd")
        Me.dtgXmlItens.Columns.Add("nomeProd", "NomeProd")
        Me.dtgXmlItens.Columns.Add("undIten", "UND")
        Me.dtgXmlItens.Columns.Add("ncmProd", "NCM")
        Me.dtgXmlItens.Columns.Add("cfopProd", "CFOP")
        Me.dtgXmlItens.Columns.Add("cstProd", "CST") '5
        Me.dtgXmlItens.Columns.Add("csosnProd", "CSOSN")
        Me.dtgXmlItens.Columns.Add("qtdProd", "QtdProd")
        Me.dtgXmlItens.Columns.Add("vlrProd", "VlrProd") '8
        Me.dtgXmlItens.Columns.Add("vlrTotProd", "VlrTotProd")
        Me.dtgXmlItens.Columns.Add("vlUnitComprProd", "VlUnitComprProd")
        Me.dtgXmlItens.Columns.Add("vlUnitProdNF", "VlUnitComprProdNF")
        Me.dtgXmlItens.Columns.Add("bcIcmsProd", "BcIcmsProd")
        Me.dtgXmlItens.Columns.Add("alqIcmsProd", "AlqIcmsProd") '13
        Me.dtgXmlItens.Columns.Add("vlrIcmsProd", "VlrIcmsProd") '14
        Me.dtgXmlItens.Columns.Add("bcSubsProd", "BcSubsProd")
        Me.dtgXmlItens.Columns.Add("alqSubsProd", "AlqSubsProd")
        Me.dtgXmlItens.Columns.Add("vlrSubsProd", "VlrSubsProd")
        Me.dtgXmlItens.Columns.Add("alqIPIProd", "alqIPIProd")
        Me.dtgXmlItens.Columns.Add("vlrIPIProd", "VlrIPIProd")
        Me.dtgXmlItens.Columns.Add("percFTProd", "PercFTProd") '20
        Me.dtgXmlItens.Columns.Add("vlrFTProd", "VlrFTProd")
        Me.dtgXmlItens.Columns.Add("vlrSegProd", "VlrSegProd")
        Me.dtgXmlItens.Columns.Add("vlrDespProd", "VlrDespProd")
        Me.dtgXmlItens.Columns.Add("vlrOutrosProd", "VlrOutrosProd")
        Me.dtgXmlItens.Columns.Add("vlrPrCustProd", "VlrPrCustProd")
        Me.dtgXmlItens.Columns.Add("vlrPercLucrProd", "VlrPercLucrProd") '26
        Me.dtgXmlItens.Columns.Add("vlrPrSurgProd", "VlrPrSurgProd")
        Me.dtgXmlItens.Columns.Add("percDescProd", "PercDescProd")
        Me.dtgXmlItens.Columns.Add("vlrDescProd", "VlrDescProd")
        Me.dtgXmlItens.Columns.Add("percReducProd", "PercReducProd")


    End Sub

    Private Sub addColunasItensXmlExtracted1()

        'Personalizando colunas
        Me.dtgXmlItens.Columns(_valorZERO).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(_valorZERO).Width = 60
        Me.dtgXmlItens.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(1).Width = 215
        Me.dtgXmlItens.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(2).Width = 40
        Me.dtgXmlItens.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(3).Width = 60
        Me.dtgXmlItens.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(4).Width = 40
        Me.dtgXmlItens.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(5).Width = 30
        Me.dtgXmlItens.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(6).Width = 60
        Me.dtgXmlItens.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(10).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(11).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(12).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(13).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(14).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(15).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(16).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(17).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(18).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(19).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(20).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(21).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(22).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(23).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(24).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(25).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(26).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(27).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(28).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(29).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dtgXmlItens.Columns(30).SortMode = DataGridViewColumnSortMode.NotSortable


    End Sub

    Private Sub addColunasItensXml()

        addColunasItensXmlExtracted() : addColunasItensXmlExtracted1()

    End Sub

    Public Function trazItenXML(ByVal codIten As String) As Boolean

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



        Dim codigo, nome, fornecedor, qtdEstoque, undMedida, ncmProd, CLF As String
        Dim CST, CFV, GRUPO, REDUZ As Integer

        Try
            SqlProduto.Append("SELECT e_codig, e_produt, e_cdport, e_qtdfisc, e_und, e_ncm, ") ' 5
            SqlProduto.Append("e_cst, e_cfv, e_grupo, e_reduz, e_clf FROM " & MdlEmpresaUsu._esqVinc & ".est0001 WHERE ") ' 10
            SqlProduto.Append("e_codig = '" & codIten & "' ORDER BY e_produt ASC")

            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDGENOV)
            drProduto = CmdProduto.ExecuteReader

            If drProduto.HasRows = False Then Return False
            While drProduto.Read
                codigo = drProduto(_valorZERO).ToString
                nome = drProduto(1).ToString
                fornecedor = drProduto(2).ToString
                qtdEstoque = drProduto(3).ToString
                undMedida = drProduto(4).ToString
                ncmProd = drProduto(5).ToString
                CST = drProduto(6) : CFV = drProduto(7) : GRUPO = drProduto(8)
                REDUZ = drProduto(9) : CLF = drProduto(10)

                Me.txt_xmcodpr.Text = codigo
                Me.txt_xmNomeProd.Text = nome
                Me.txt_xmundprod.Text = undMedida
                Me.txt_ncm.Text = ncmProd
                Me.mbUndProd = undMedida

                mCstIten = CST : mCfvIten = CFV : mGrupoIten = GRUPO : mReduzIten = REDUZ
                mClfIten = CLF
                Me.txt_ncm.Focus()

            End While
            drProduto.Close() : oConnBDGENOV.ClearPool()


        Catch ex As Exception
            MsgBox("ERRO ao trazer ITEM:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        Finally

            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
        End Try


        CmdProduto.CommandText = ""
        SqlProduto.Remove(_valorZERO, SqlProduto.ToString.Length)

        'LIMPA OBJETOS DA MEMÓRIA...
        codigo = Nothing : nome = Nothing : fornecedor = Nothing : qtdEstoque = Nothing
        undMedida = Nothing : ncmProd = Nothing : CST = Nothing : CFV = Nothing
        GRUPO = Nothing : REDUZ = Nothing : CLF = Nothing

        SqlProduto = Nothing : oConnBDGENOV = Nothing : drProduto = Nothing : CmdProduto = Nothing



        Return True
    End Function

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
            SqlProduto.Append("e.e_clf FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN estloja01 el ON e.e_codig = el.e_codig WHERE ")
            SqlProduto.Append("el.e_loja = '" & Me.cbo_local.SelectedItem.ToString.Substring(0, 2) & "' AND el.e_codig = ")
            SqlProduto.Append("'" & codIten & "' ORDER BY e_produt ASC")

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

                mCstIten = CST : mCfvIten = CFV : mClfIten = CLF : mGrupoIten = GRUPO
                mReduzIten = REDUZ

                Me.txt_codProd.Text = codigo : Me.txt_nomeProd.Text = nome : Me.txt_ncm.Text = ncmProd
                Me.mbUndProd = undMedida : Me.txt_SaldoAtual.Text = sldAtual
                Me.txt_custAnter.Text = custAnt : Me.txt_pcoAnt.Text = pcoAnt

            End While
            drProduto.Close() : oConnBDGENOV.ClearPool()

        Catch ex As Exception
            MsgBox("ERRO ao trazer ITEM:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        Finally

            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
        End Try


        CmdProduto.CommandText = "" : SqlProduto.Remove(_valorZERO, SqlProduto.ToString.Length)

        'LIMPA OBJETOS DA MEMÓRIA...
        codigo = Nothing : nome = Nothing : fornecedor = Nothing : qtdEstoque = Nothing
        undMedida = Nothing : ncmProd = Nothing : CST = Nothing : CFV = Nothing
        GRUPO = Nothing : REDUZ = Nothing : sldAtual = Nothing : pcoAnt = Nothing
        custAnt = Nothing : CLF = Nothing

        SqlProduto = Nothing : oConnBDGENOV = Nothing : drProduto = Nothing : CmdProduto = Nothing



        Return True
    End Function

    Private Function trazCFOPentrada(ByVal CFOP As String, ByVal CST As String) As String

        Dim mCFOP As String = "1"

        If Mid(CFOP, 1, 1).Equals("5") Then

            mCFOP = "1" & Mid(CFOP, 2, 3)

        ElseIf Mid(CFOP, 1, 1).Equals("6") Then

            mCFOP = "2" & Mid(CFOP, 2, 3)

        ElseIf Mid(CFOP, 1, 1).Equals("7") Then

            mCFOP = "3" & Mid(CFOP, 2, 3)

        End If



        Return mCFOP
    End Function

    Private Sub deleteDtGridItemXml()

        Try

            If Me.dtgXmlItens.Enabled = True Then

                'Remove Linha
                Me.dtgXmlItens.Rows.Remove(Me.dtgXmlItens.CurrentRow)
                Me.dtgXmlItens.Refresh() : Me.atualizSomaVlItens()

            End If

        Catch ex As Exception
            MsgBox("Deu ERRO ao Deletar este Item " & ex.Message, MsgBoxStyle.Exclamation)
        End Try



    End Sub

    Private Sub txt_xmqtde_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_xmqtde.KeyPress
        'permite só numeros com pontos
        If _clFunc.SoNumerosPonto(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_xmcodpr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_xmcodpr.KeyPress
        'permite só numeros
        If _clFunc.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_xmqtde_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_xmqtde.Leave

        If Not Me.txt_xmprtot.Text.Equals("") AndAlso IsNumeric(Me.txt_xmqtde.Text) Then

            Dim mPrTot, mQtde As Double
            Dim mAuxValores As String
            mAuxValores = Me.txt_xmprtot.Text : mAuxValores = mAuxValores.Replace(",", "")
            mAuxValores = mAuxValores.Replace(".", ",") : mPrTot = mAuxValores

            mAuxValores = Me.txt_xmqtde.Text : mAuxValores = mAuxValores.Replace(",", "")
            mAuxValores = mAuxValores.Replace(".", ",") : mQtde = mAuxValores
            Me.txt_xmpcounit.Text = mPrTot / mQtde

        End If



    End Sub

    Private Sub Btn_sair_Click_1ExtractedExtracted()

        salvaValoresXML()
        MsgBox("Nota Importada com sucesso!")


    End Sub

    Private Sub Btn_sair_Click_1Extracted()

        If MessageBox.Show("Deseja Gravar Tudo?", "Genov", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If lbl_xmTipoNota.Text.Equals("NFE") Then

                If verifVlNF_XML() Then Btn_sair_Click_1ExtractedExtracted()

            Else

                Btn_sair_Click_1ExtractedExtracted()

            End If
        End If



    End Sub

    Private Sub Btn_sair_Click_1Extracted1()

        If MessageBox.Show("Deseja Informar Contas a Pagar?", "Genov", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.tbc_compras.SelectTab(3)

        Else


            If MessageBox.Show("Deseja Gravar Tudo?", "Genov", MessageBoxButtons.YesNo, _
            MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If lbl_xmTipoNota.Text.Equals("NFE") Then

                    If verifVlNF_XML() Then Btn_sair_Click_1ExtractedExtracted()

                Else
                    Btn_sair_Click_1ExtractedExtracted()

                End If
            End If
        End If



    End Sub

    Private Sub Btn_sair_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_xmsair.Click

        If dtgXmlItens.RowCount > _valorZERO Then

            If (Me.dtg_boletos.Rows.Count > _valorZERO) OrElse (IsNumeric(Me.txt_blValordup.Text) AndAlso _
            (CDbl(Me.txt_blValordup.Text) > _valorZERO)) Then

                Btn_sair_Click_1Extracted()

            Else

                Btn_sair_Click_1Extracted1()

            End If
        End If



    End Sub

    Private Function verifVlNF_XML() As Boolean

        Dim mValor, mValorTotal As Double

        mValor = _valorZERO
        mValorTotal = _valorZERO
        'Soma valor bruto dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(9).Value

        Next

        mValorTotal += mValor
        If Round(mValor, 2) <> _totPROD Then

            MsgBox("Total dos Valores bruto nos Produtos diferente do valor Informado no registro da Nota!", MsgBoxStyle.Exclamation)
            Return False
        End If

        mValor = _valorZERO
        'Soma valor da Bc ICMS dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(12).Value

        Next

        mValorTotal += mValor
        If Round(mValor, 2) <> _totBcICMS Then

            MsgBox("Total da Base de Calculo do ICMS nos Produtos diferente do valor Informado no registro da Nota!", MsgBoxStyle.Exclamation)
            Return False
        End If

        mValor = _valorZERO
        'Soma valor do ICMS dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(14).Value

        Next

        mValorTotal += mValor
        If Round(mValor, 2) <> _totICMS Then

            MsgBox("Total do ICMS nos Produtos diferente do valor Informado no registro da Nota!", MsgBoxStyle.Exclamation)
            Return False
        End If

        mValor = _valorZERO
        'Soma valor da BaseCalculo da substituição dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(15).Value

        Next

        If Round(mValor, 2) <> _totBcST Then

            MsgBox("Total a Base de Calculo do IcmsSubstituto nos Produtos diferente do valor Informado no registro da Nota!", MsgBoxStyle.Exclamation)
            Return False
        End If

        mValor = _valorZERO
        'Soma valor da substituição dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(17).Value

        Next

        mValorTotal += mValor
        If Round(mValor, 2) <> _totST Then

            MsgBox("Total do IcmsSubstituto nos Produtos diferente do valor Informado no registro da Nota!", MsgBoxStyle.Exclamation)
            Return False
        End If

        mValor = _valorZERO
        'Soma valor IPI dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(19).Value

        Next

        mValorTotal += mValor
        If Round(mValor, 2) <> _totIPI Then

            MsgBox("Total do IPI nos Produtos diferente do valor Informado no registro da Nota!", MsgBoxStyle.Exclamation)
            Return False
        End If

        mValor = _valorZERO
        'Soma valor Frete dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(21).Value

        Next

        mValorTotal += mValor
        If Round(mValor, 2) <> _totFRETE Then

            MsgBox("Total do FRETE nos Produtos diferente do valor Informado no registro da Nota!", MsgBoxStyle.Exclamation)
            Return False
        End If

        mValor = _valorZERO
        'Soma valor Seguro dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(22).Value

        Next

        mValorTotal += mValor
        If Round(mValor, 2) <> _totSEGU Then

            MsgBox("Total do SEGURO nos Produtos diferente do valor Informado no registro da Nota!", MsgBoxStyle.Exclamation)
            Return False
        End If

        mValor = _valorZERO
        'Soma valor Outras Despesas dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(23).Value

        Next

        mValorTotal += mValor
        If Round(mValor, 2) <> _totOutrDESP Then

            MsgBox("Total de Outras Despesas nos Produtos diferente do valor Informado no registro da Nota!", MsgBoxStyle.Exclamation)
            Return False
        End If

        mValor = _valorZERO
        'Soma valor Desconto dos produtos
        For Each col As DataGridViewRow In Me.dtgXmlItens.Rows

            mValor += col.Cells(29).Value

        Next

        mValorTotal -= mValor
        If Round(mValor, 2) <> _totDESC Then

            MsgBox("Total do Desconto nos Produtos diferente do valor Informado no registro da Nota!", MsgBoxStyle.Exclamation)
            Return False
        End If



        Return True
    End Function

    Private Sub salvaValoresXML()

        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return

        End Try


        Try
            transacao = conn.BeginTransaction
            Try

                If lbl_xmTipoNota.Text.Equals("NFE") Then

                    imporRegistroXmlNFe(conn, transacao) : imporItensXmlNF(conn, transacao)
                    incResAlqXml(conn, transacao) : incResCfopAlqXml(conn, transacao)
                    incResCstCfopAlqXml(conn, transacao)
                    If Me.dtg_boletos.RowCount > _valorZERO Then Me.incContas_A_PagarXml(conn, transacao)

                Else
                    imporRegistroXmlCTe(conn, transacao)
                    If Me.dtg_boletos.RowCount > _valorZERO Then Me.incContas_A_PagarXml(conn, transacao)

                End If
                transacao.Commit() : conn.ClearPool()

                zeraValoresNfXml() : zeraValoresDuplicat() : Me.tbp_contasapagar.Enabled = False
                Me.tbc_compras.SelectTab(_valorZERO) : Me.executaConsulta()

            Catch ex1 As Exception
                MsgBox(ex1.Message)
                Try
                    transacao.Rollback()
                Catch ex2 As Exception
                End Try
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If conn.State = ConnectionState.Open Then conn.Close()
            conn = Nothing : transacao = Nothing
        End Try



    End Sub

    Private Function verifCamposImportXml() As Boolean

        If Me.cbo_xmcfopNF.SelectedIndex < _valorZERO Then

            lbl_xmMsg.Text = "Por favor! Selecione um CFOP PADRÃO para NFE !"
            cbo_xmcfopNF.Focus() : Return False
        End If

        If Me.cbo_xmcfopProd.SelectedIndex < _valorZERO Then

            lbl_xmMsg.Text = "Por favor! Selecione um CFOP para o PRODUTO !"
            cbo_xmcfopProd.Focus() : Return False
        End If

        If Me.cbo_xmcst.SelectedIndex < _valorZERO Then

            lbl_xmMsg.Text = "Por Favor informe um CST para o Produto !"
            cbo_xmcst.Focus() : Return False
        End If
        lbl_xmMsg.Text = ""



        Return True
    End Function

    Private Sub zeraValoresNfXml()

        Me.txt_implocal.Text = "" : Me.txt_xmfornecedor.Text = ""
        Me.txt_xmnumero.Text = "" : Me.txt_xmserie.Text = "" : Me.txt_xmuf.Text = ""
        Me.txt_xminscricao.Text = "" : Me.msk_xmemissao.Text = "" : Me.msk_cnpj.Text = ""
        Me.txt_xmtipoemp.Text = "" : Me.cbo_xmcfopNF.SelectedIndex = -1
        Me.txt_xmunidForn.Text = "" : Me.txt_xmprodutoforn.Text = "" : Me.txt_xmcodbarraForn.Text = ""
        Me.txt_xmncmForn.Text = "" : Me.txt_xmcodpr.Text = "" : Me.txt_xmcodigoForn.Text = ""
        Me.txt_xmNomeProd.Text = "" : Me.txt_xmpcounit.Text = "" : Me.txt_xmqtde.Text = ""
        Me.txt_xmprtot.Text = "" : Me.txt_xmundprod.Text = ""
        Me.cbo_xmcfopProd.SelectedIndex = -1 : Me.dtgXmlItens.Rows.Clear()


    End Sub

    Private Sub imporRegistroXmlNFe(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mCodForn, mEstabNF, mNumNF, mSerieNF, mEspecNF, mTipoNF, mChaveNFe, mCfopNF As String
        Dim mTotProdutosNF, mBcIcmsNF, mAlqIcmsNF, mVlIcmsNF, mBcSubsNF, mVlSubsNF As Double
        Dim mAlqIpiNF, mVlIpiNF, mVlIpiIsentoNF, mVlIpiOutrosNF, mVlFreteNF, mVlOutrosNF As Double
        Dim mVlSeguroNF, mVlTotGeralNF, mVlDescontoNF, mVlOutrasDespNF As Double
        Dim mVlIcmsProd, mVlSubsProd, mVlIpiProd, mVlFretProd, mVlSeguroProd, mVlDespProd As Double
        Dim mDtEmissao, mDtEntrada As Date
        Dim mObservacao As String
        Dim mPagamento As Integer

        mCodForn = _codFornXML
        mEstabNF = cbo_xmlocal.Text.Substring(_valorZERO, 2)
        mNumNF = Me.txt_xmnumero.Text : mSerieNF = Me.txt_xmserie.Text
        mEspecNF = "NFE" : mTipoNF = "E" : mChaveNFe = _chaveNFeXML
        mCfopNF = Mid(Me.cbo_xmcfopNF.Text, 1, 1) & Mid(Me.cbo_xmcfopNF.Text, 3, 3)
        mDtEmissao = CDate(Me.msk_xmemissao.Text)
        mDtEntrada = CDate(Format(Date.Now, "dd/MM/yyyy"))
        mTotProdutosNF = _totPROD : mBcIcmsNF = _totBcICMS : mVlIcmsNF = _totICMS
        mAlqIcmsNF = 0.0

        If mVlIcmsNF > _valorZERO Then mAlqIcmsNF = Round((mVlIcmsNF / mBcIcmsNF) * 100, 2)
        mBcSubsNF = _totBcST : mVlSubsNF = _totST : mVlIpiNF = _totIPI
        mAlqIpiNF = 0.0

        If mVlIpiNF > _valorZERO Then mAlqIpiNF = Round((mVlIpiNF / mTotProdutosNF) * 100, 2)
        mVlIpiIsentoNF = 0.0 : mVlIpiOutrosNF = 0.0 : mVlFreteNF = _totFRETE
        mVlOutrosNF = 0.0 : mVlSeguroNF = _totSEGU : mVlDescontoNF = _totDESC
        mVlOutrasDespNF = _totOutrDESP : mVlTotGeralNF = _totNOTA
        mPagamento = Me.cbo_blPlanoPgto.SelectedIndex
        '0 - A Vista
        '1 - A prazo
        '2 - Sem Pagamento
        '3 - Outros
        mObservacao = "IMPORTADA DO XML"

        'Grava Itens da NF
        For Each row As DataGridViewRow In Me.dtgXmlItens.Rows

            If Not row.IsNewRow Then

                mVlIcmsProd += CDec(row.Cells(14).Value) : mVlSubsProd += CDec(row.Cells(17).Value)
                mVlIpiProd += CDec(row.Cells(19).Value) : mVlFretProd += CDec(row.Cells(21).Value)
                mVlSeguroProd += CDec(row.Cells(22).Value) : mVlDespProd += CDec(row.Cells(23).Value)

            End If
        Next

        If mVlIcmsProd <= 0 Then mBcIcmsNF = 0.0 : mAlqIcmsNF = 0.0 : mVlIcmsNF = 0.0

        If mVlSubsProd <= 0 Then mBcSubsNF = 0.0 : mVlSubsNF = 0.0

        If mVlIpiProd <= 0 Then mAlqIpiNF = 0.0 : mVlIpiNF = 0.0

        If mVlFretProd <= 0 Then mVlFreteNF = 0.0
        If mVlSeguroProd <= 0 Then mVlSeguroNF = 0.0
        If mVlDespProd <= 0 Then mVlDescontoNF = 0.0

        _clBD.IncNfEntradaTerc(mNumNF, mCodForn, mEstabNF, mSerieNF, mEspecNF, mDtEmissao, mDtEntrada, _
                               mTipoNF, mChaveNFe, mCfopNF, mTotProdutosNF, mBcIcmsNF, mAlqIcmsNF, _
                               mVlIcmsNF, mBcSubsNF, mVlSubsNF, mAlqIpiNF, mVlIpiNF, mVlIpiIsentoNF, _
                               mVlIpiOutrosNF, mVlFreteNF, mVlOutrosNF, mVlSeguroNF, mVlDescontoNF, _
                               mVlOutrasDespNF, mVlTotGeralNF, mbUf, mPagamento, mObservacao, oConnBDGENOV, transacao)


        'LIMPA OBJETOS DA MEMÓRIA...
        mCodForn = Nothing : mEstabNF = Nothing : mNumNF = Nothing
        mSerieNF = Nothing : mEspecNF = Nothing : mTipoNF = Nothing
        mChaveNFe = Nothing : mCfopNF = Nothing : mDtEmissao = Nothing
        mDtEntrada = Nothing : mTotProdutosNF = Nothing : mBcIcmsNF = Nothing
        mAlqIcmsNF = Nothing : mVlIcmsNF = Nothing : mBcSubsNF = Nothing
        mVlSubsNF = Nothing : mAlqIpiNF = Nothing : mVlIpiNF = Nothing
        mVlIpiIsentoNF = Nothing : mVlIpiOutrosNF = Nothing : mVlFreteNF = Nothing
        mVlOutrosNF = Nothing : mVlSeguroNF = Nothing : mVlTotGeralNF = Nothing


    End Sub

    Private Sub imporRegistroXmlCTe(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mCodForn, mEstabNF, mNumNF, mSerieNF, mEspecNF, mTipoNF, mChaveNFe, mCfopNF As String
        Dim mTotProdutosNF, mBcIcmsNF, mAlqIcmsNF, mVlIcmsNF, mBcSubsNF, mVlSubsNF As Double
        Dim mAlqIpiNF, mVlIpiNF, mVlIpiIsentoNF, mVlIpiOutrosNF, mVlFreteNF, mVlOutrosNF As Double
        Dim mVlSeguroNF, mVlTotGeralNF, mVlDescontoNF, mVlOutrasDespNF As Double
        Dim mDtEmissao, mDtEntrada As Date
        Dim mObservacao As String
        Dim mPagamento As Integer

        mCodForn = _codFornXML
        mEstabNF = cbo_xmlocal.Text.Substring(_valorZERO, 2)
        mNumNF = Me.txt_xmnumero.Text : mSerieNF = Me.txt_xmserie.Text
        mEspecNF = "FTE" : mTipoNF = "E" : mChaveNFe = _chaveNFeXML
        mCfopNF = Mid(Me.cbo_xmcfopNF.Text, 1, 1) & Mid(Me.cbo_xmcfopNF.Text, 3, 3)
        mDtEmissao = CDate(Me.msk_xmemissao.Text)
        mDtEntrada = CDate(Format(Date.Now, "dd/MM/yyyy"))
        mTotProdutosNF = _totPROD : mBcIcmsNF = _totBcICMS : mVlIcmsNF = _totICMS
        mAlqIcmsNF = 0.0
        If mVlIcmsNF > _valorZERO Then mAlqIcmsNF = Round((mVlIcmsNF / mBcIcmsNF) * 100, 2)
        mBcSubsNF = _totBcST : mVlSubsNF = _totST : mVlIpiNF = _totIPI
        mAlqIpiNF = 0.0
        If mVlIpiNF > _valorZERO Then mAlqIpiNF = Round((mVlIpiNF / mTotProdutosNF) * 100, 2)
        mVlIpiIsentoNF = 0.0 : mVlIpiOutrosNF = 0.0 : mVlFreteNF = _totFRETE
        mVlOutrosNF = 0.0 : mVlSeguroNF = _totSEGU : mVlDescontoNF = _totDESC
        mVlOutrasDespNF = _totOutrDESP : mVlTotGeralNF = _totNOTA
        mPagamento = Me.cbo_blPlanoPgto.SelectedIndex
        '0 - A Vista
        '1 - A prazo
        '2 - Sem Pagamento
        '3 - Outros
        mObservacao = "IMPORTADA DO XML"

        _clBD.IncNfEntradaTerc(mNumNF, mCodForn, mEstabNF, mSerieNF, mEspecNF, mDtEmissao, mDtEntrada, _
                               mTipoNF, mChaveNFe, mCfopNF, mTotProdutosNF, mBcIcmsNF, mAlqIcmsNF, _
                               mVlIcmsNF, mBcSubsNF, mVlSubsNF, mAlqIpiNF, mVlIpiNF, mVlIpiIsentoNF, _
                               mVlIpiOutrosNF, mVlFreteNF, mVlOutrosNF, mVlSeguroNF, mVlDescontoNF, _
                               mVlOutrasDespNF, mVlTotGeralNF, mbUf, mPagamento, mObservacao, oConnBDGENOV, transacao)


        'LIMPA OBJETOS DA MEMÓRIA...
        mCodForn = Nothing : mEstabNF = Nothing : mNumNF = Nothing
        mSerieNF = Nothing : mEspecNF = Nothing : mTipoNF = Nothing
        mChaveNFe = Nothing : mCfopNF = Nothing : mDtEmissao = Nothing
        mDtEntrada = Nothing : mTotProdutosNF = Nothing : mBcIcmsNF = Nothing
        mAlqIcmsNF = Nothing : mVlIcmsNF = Nothing : mBcSubsNF = Nothing
        mVlSubsNF = Nothing : mAlqIpiNF = Nothing : mVlIpiNF = Nothing
        mVlIpiIsentoNF = Nothing : mVlIpiOutrosNF = Nothing : mVlFreteNF = Nothing
        mVlOutrosNF = Nothing : mVlSeguroNF = Nothing : mVlTotGeralNF = Nothing



    End Sub

    Private Sub imporItensXmlNF(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd As String
        Dim mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd As Double
        Dim mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd As Double
        Dim mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd As Double
        Dim mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd As Double
        Dim mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF, mVlBrutProd As Double
        Dim mCodForn, mUndProd, mNumeroNF, mEstab, mSerie As String
        Dim mDtEntrProd, mDtUsuProd As String

        Dim pcustoAtual, qtde, novopcusto, novopcustom As Double

        mSerie = Me.txt_xmserie.Text : mNumeroNF = Me.txt_xmnumero.Text
        mEstab = cbo_xmlocal.Text : mCodForn = _codFornXML

        Dim sqlNF As New StringBuilder
        Dim cmdNF As NpgsqlCommand
        Dim drNF As NpgsqlDataReader

        sqlNF.Append("SELECT n4_id FROM " & MdlEmpresaUsu._esqEstab & ".Nota4ff WHERE n4_numer = '" & mNumeroNF & "' AND ")
        sqlNF.Append(" n4_cdport = '" & mCodForn & "' AND n4_serie = '" & mSerie & "'")
        cmdNF = New NpgsqlCommand(sqlNF.ToString, oConnBDGENOV)
        drNF = cmdNF.ExecuteReader
        While drNF.Read

            mIDn4FF = drNF(_valorZERO)
        End While
        drNF.Close() : cmdNF = Nothing : sqlNF = Nothing : drNF = Nothing


        'Grava Itens da NF
        For Each row As DataGridViewRow In Me.dtgXmlItens.Rows

            If Not row.IsNewRow Then

                mCodProd = row.Cells(_valorZERO).Value
                mNomeProd = row.Cells(1).Value
                mUndProd = row.Cells(2).Value
                mNcmProd = row.Cells(3).Value
                mCfopProd = row.Cells(4).Value
                mCstProd = row.Cells(5).Value
                mCsosnProd = row.Cells(6).Value
                mQtdeProd = CDec(row.Cells(7).Value)
                mVlUnitComprProd = CDec(row.Cells(10).Value)
                mVlBrutProd = CDec(row.Cells(9).Value)
                mVlProd = CDec(row.Cells(10).Value)
                mVlUnitProdNF = CDec(row.Cells(11).Value)
                mVlBcIcmsProd = CDec(row.Cells(12).Value)
                mVlAlqIcmsProd = CDec(row.Cells(13).Value)
                mVlIcmsProd = CDec(row.Cells(14).Value)
                mBcSubsProd = CDec(row.Cells(15).Value)
                mVlAlqSubsProd = CDec(row.Cells(16).Value)
                mVlSubsProd = CDec(row.Cells(17).Value)
                mVlAlqIpiProd = CDec(row.Cells(18).Value)
                mVlIpiProd = CDec(row.Cells(19).Value)
                mVlPercFretProd = CDec(row.Cells(20).Value)
                mVlFretProd = CDec(row.Cells(21).Value)
                mVlSeguroProd = CDec(row.Cells(22).Value)
                mVlDespProd = CDec(row.Cells(23).Value)
                mVlOutrosProd = CDec(row.Cells(24).Value)
                mVlCustoProd = CDec(row.Cells(25).Value)
                mVlPercLucroProd = CDec(row.Cells(26).Value)
                mVlSurgeridoProd = CDec(row.Cells(27).Value)
                mVlPercDesc = CDec(row.Cells(28).Value)
                mVlDesc = CDec(row.Cells(29).Value)
                mVlPercRedProd = CDec(row.Cells(30).Value)
                mVlTotProd = Round(mVlBrutProd - mVlDesc, 2)
                mDtEntrProd = Format(Date.Now, "dd/MM/yyyy")
                mDtUsuProd = Format(Date.Now, "dd/MM/yyyy")

                _clBD.incItensNfEntradasTerc(mIDn4FF, mNumeroNF, mCodForn, mCodProd, mNomeProd, mNcmProd, mCfopProd, _
                        mUndProd, mDtEntrProd, mDtUsuProd, mCstProd, mCsosnProd, mQtdeProd, mVlUnitProdNF, mVlPercDesc, _
                        mVlDesc, mVlTotProd, mVlUnitComprProd, mVlBrutProd, mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, _
                        mBcSubsProd, mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd, mVlFretProd, _
                        mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd, mVlPercLucroProd, mVlSurgeridoProd, _
                        mEstab, oConnBDGENOV, transacao)

                pcustoAtual = _clBD.pegaPcustoEstoque(mCodProd, Me.cbo_xmlocal.SelectedItem.ToString.Substring(0, 2), oConnBDGENOV)
                qtde = _clBD.pegaQtdeEstoque(mCodProd, Me.cbo_xmlocal.SelectedItem.ToString.Substring(0, 2), oConnBDGENOV)
                novopcustom = _clBD.Calcula_CustoMedio(qtde, pcustoAtual, mQtdeProd, mVlUnitComprProd)
                novopcusto = _clBD.Calcula_CustoProd(mVlUnitComprProd, mQtdeProd, mVlIpiProd, mVlFretProd, mVlDespProd, _
                             mVlSubsProd, mVlIcmsProd, mVlSeguroProd, mVlOutrosProd)


                _clBD.altPcustoaEstoque(mCodProd, Me.cbo_xmlocal.SelectedItem.ToString.Substring(0, 2), Round(pcustoAtual, 2), oConnBDGENOV, transacao)
                _clBD.altPcustomEstoque(mCodProd, Me.cbo_xmlocal.SelectedItem.ToString.Substring(0, 2), Round(novopcustom, 3), oConnBDGENOV, transacao)
                _clBD.altSomandoQtdsProdEstoque(mCodProd, Me.cbo_xmlocal.SelectedItem.ToString.Substring(0, 2), Round(mQtdeProd, 3), oConnBDGENOV, transacao)
                _clBD.altPcustoEstoque(mCodProd, Me.cbo_xmlocal.SelectedItem.ToString.Substring(0, 2), Round(novopcusto, 2), oConnBDGENOV, transacao)
                _clBD.altPcompEstoque(mCodProd, Me.cbo_xmlocal.SelectedItem.ToString.Substring(0, 2), mVlUnitComprProd, oConnBDGENOV, transacao)
                _clBD.altDtcompEstoque(mCodProd, Me.cbo_xmlocal.SelectedItem.ToString.Substring(0, 2), CDate(mDtEntrProd), oConnBDGENOV, transacao)


            End If
        Next

        'LIMPA OBJETOS DA MEMÓRIA...
        mCodProd = Nothing : mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing
        mCstProd = Nothing : mCsosnProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing
        mVlPercDesc = Nothing : mVlDesc = Nothing : mVlTotProd = Nothing : mVlUnitComprProd = Nothing
        mVlUnitProdNF = Nothing : mVlPercRedProd = Nothing : mVlBcIcmsProd = Nothing
        mVlAlqIcmsProd = Nothing : mVlIcmsProd = Nothing : mBcSubsProd = Nothing : mVlAlqSubsProd = Nothing
        mVlSubsProd = Nothing : mVlAlqIpiProd = Nothing : mVlIpiProd = Nothing : mVlPercFretProd = Nothing
        mVlFretProd = Nothing : mVlSeguroProd = Nothing : mVlDespProd = Nothing : mVlOutrosProd = Nothing
        mVlCustoProd = Nothing : mVlPercLucroProd = Nothing : mVlSurgeridoProd = Nothing



    End Sub

    Private Sub incResAlqXml(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mAliquotas As Array = ReturnAlqGridViewXml()
        Dim i As Integer
        Dim strALQ As String
        Dim mNumeroNF As String = Me.txt_xmnumero.Text
        Dim aliqICMS, totProd, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI As Decimal
        Dim vlDesc, vlFrete, vlSeguro, vlOutrasDesp As Decimal
        Dim mExistAlq As Boolean = False

        For i = _valorZERO To mAliquotas.Length - 1

            totProd = 0.0 : vlDesc = 0.0 : vlFrete = 0.0 : vlSeguro = 0.0 : bcalcICMS = 0.0
            vlICMS = 0.0 : vlOutras = 0.0 : vlIPI = 0.0 : vlIsento = 0.0 : vlOutrasDesp = 0.0
            mExistAlq = False
            'Percorre o GridView
            For Each row As DataGridViewRow In Me.dtgXmlItens.Rows

                If Not row.IsNewRow Then

                    strALQ = CDec(row.Cells(13).Value)
                    If mAliquotas(i).Equals(strALQ) Then
                        mExistAlq = True
                        totProd += CDec(row.Cells(9).Value) : vlDesc += CDec(row.Cells(29).Value)
                        vlFrete += CDec(row.Cells(21).Value) : vlSeguro += CDec(row.Cells(22).Value)
                        vlOutrasDesp += CDec(row.Cells(23).Value) : aliqICMS = CDec(row.Cells(13).Value)
                        bcalcICMS += CDec(row.Cells(12).Value) : vlICMS += CDec(row.Cells(14).Value)
                        vlOutras += CDec(row.Cells(24).Value) : vlIPI += CDec(row.Cells(19).Value)

                        'CST
                        If row.Cells(5).Value.Equals("30") OrElse _
                        row.Cells(5).Value.Equals("40") Then

                            vlIsento += CDec(row.Cells(10).Value)

                        Else
                            vlIsento += 0.0

                        End If


                    End If
                End If
            Next 'fim For GridView


            If mExistAlq = True Then 'Grava o Resumo das Aliquotas no resn4ff01

                _clBD.IncResEntrTercALQ(mIDn4FF, mNumeroNF, aliqICMS, totProd, vlDesc, vlFrete, vlSeguro, _
                                        vlOutrasDesp, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI, oConnBDGENOV, transacao)

            End If

        Next 'fim For Aliquotas

        'LIMPA OBJETOS DA MEMÓRIA...
        strALQ = Nothing : i = Nothing : mNumeroNF = Nothing : vlDesc = Nothing : vlFrete = Nothing
        aliqICMS = Nothing : totProd = Nothing : bcalcICMS = Nothing : vlICMS = Nothing
        vlIsento = Nothing : vlOutras = Nothing : vlIPI = Nothing : vlSeguro = Nothing
        vlOutrasDesp = Nothing : mExistAlq = Nothing



    End Sub

    Private Sub incResCfopAlqXml(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mCfopAlq As Array = ReturnCfopAlqGridViewXml()
        Dim i As Integer
        Dim strCFOP_ALQ As String
        Dim mNumeroNF As String = Me.txt_xmnumero.Text
        Dim aliqICMS, totProd, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI As Decimal
        Dim vlDesc, vlFrete, vlSeguro, vlOutrasDesp As Decimal
        Dim Cfop As String
        Dim mExistCfopAlq As Boolean = False

        For i = _valorZERO To mCfopAlq.Length - 1

            Cfop = "" : totProd = 0.0 : vlDesc = 0.0 : vlFrete = 0.0 : vlSeguro = 0.0
            bcalcICMS = 0.0 : vlICMS = 0.0 : vlOutras = 0.0 : vlIPI = 0.0 : vlIsento = 0.0
            vlOutrasDesp = 0.0 : mExistCfopAlq = False
            'Percorre o GridView
            For Each row As DataGridViewRow In Me.dtgXmlItens.Rows

                If Not row.IsNewRow Then

                    strCFOP_ALQ = row.Cells(4).Value & "/" & CDec(row.Cells(13).Value)
                    If mCfopAlq(i).Equals(strCFOP_ALQ) Then

                        mExistCfopAlq = True : Cfop = row.Cells(4).Value : totProd += CDec(row.Cells(9).Value)
                        vlDesc += CDec(row.Cells(29).Value) : vlFrete += CDec(row.Cells(21).Value)
                        vlSeguro += CDec(row.Cells(22).Value) : vlOutrasDesp += CDec(row.Cells(23).Value)
                        aliqICMS = CDec(row.Cells(13).Value) : bcalcICMS += CDec(row.Cells(12).Value)
                        vlICMS += CDec(row.Cells(14).Value) : vlOutras += CDec(row.Cells(24).Value)
                        vlIPI += CDec(row.Cells(19).Value)

                        'CST
                        If row.Cells(5).Value.Equals("30") OrElse _
                        row.Cells(5).Value.Equals("40") Then

                            vlIsento += CDec(row.Cells(10).Value)

                        Else
                            vlIsento += 0.0

                        End If


                    End If
                End If
            Next 'fim For GridView


            If mExistCfopAlq = True Then 'Grava o Resumo dos CFOP/Aliquotas no resn4ff02

                _clBD.IncResEntrTercCfopAlq(mIDn4FF, mNumeroNF, Cfop, aliqICMS, totProd, vlDesc, vlFrete, vlSeguro, _
                                    vlOutrasDesp, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI, oConnBDGENOV, transacao)

            End If

        Next 'fim For Aliquotas

        'LIMPA OBJETOS DA MEMÓRIA...
        mCfopAlq = Nothing : i = Nothing : strCFOP_ALQ = Nothing : mNumeroNF = Nothing
        aliqICMS = Nothing : totProd = Nothing : bcalcICMS = Nothing : vlICMS = Nothing
        vlIsento = Nothing : vlOutras = Nothing : vlIPI = Nothing : vlDesc = Nothing : vlFrete = Nothing
        vlSeguro = Nothing : vlOutrasDesp = Nothing : Cfop = Nothing : mExistCfopAlq = Nothing



    End Sub

    Private Sub incResCstCfopAlqXml(ByVal oConnBDGENOV As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mCstCfopAlq As Array = ReturnCstCfopAlqGridViewXml()
        Dim i As Integer
        Dim strCST_CFOP_ALQ As String
        Dim mNumeroNF As String = Me.txt_xmnumero.Text
        Dim aliqICMS, totProd, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI As Decimal
        Dim vlDesc, vlFrete, vlSeguro, vlOutrasDesp As Decimal
        Dim Cfop, Cst As String
        Dim mExistCstCfopAlq As Boolean = False

        For i = _valorZERO To mCstCfopAlq.Length - 1

            Cst = "" : Cfop = "" : totProd = 0.0 : vlDesc = 0.0 : vlFrete = 0.0 : vlSeguro = 0.0
            bcalcICMS = 0.0 : vlICMS = 0.0 : vlOutras = 0.0 : vlIPI = 0.0 : vlIsento = 0.0
            vlOutrasDesp = 0.0 : mExistCstCfopAlq = False
            'Percorre o GridView
            For Each row As DataGridViewRow In Me.dtgXmlItens.Rows

                If Not row.IsNewRow Then

                    strCST_CFOP_ALQ = row.Cells(5).Value & "/" & row.Cells(4).Value & "/" & CDec(row.Cells(13).Value)
                    If mCstCfopAlq(i).Equals(strCST_CFOP_ALQ) Then

                        mExistCstCfopAlq = True : Cfop = row.Cells(4).Value : Cst = row.Cells(5).Value
                        totProd += CDec(row.Cells(9).Value) : vlDesc += CDec(row.Cells(29).Value)
                        vlFrete += CDec(row.Cells(21).Value) : vlSeguro += CDec(row.Cells(22).Value)
                        vlOutrasDesp += CDec(row.Cells(23).Value) : aliqICMS = CDec(row.Cells(13).Value)
                        bcalcICMS += CDec(row.Cells(12).Value) : vlICMS += CDec(row.Cells(14).Value)
                        vlOutras += CDec(row.Cells(24).Value) : vlIPI += CDec(row.Cells(19).Value)

                        'CST
                        If row.Cells(5).Value.Equals("30") OrElse _
                        row.Cells(5).Value.Equals("40") Then

                            vlIsento += CDec(row.Cells(10).Value)

                        Else

                            vlIsento += 0.0
                        End If


                    End If
                End If
            Next 'fim For GridView


            If mExistCstCfopAlq = True Then 'Grava o Resumo dos CST/CFOP/Aliquotas no resn4ff03

                _clBD.IncResEntrTercCstCfopAlq(mIDn4FF, mNumeroNF, Cst, Cfop, aliqICMS, totProd, vlDesc, vlFrete, vlSeguro, _
                                    vlOutrasDesp, bcalcICMS, vlICMS, vlIsento, vlOutras, vlIPI, oConnBDGENOV, transacao)

            End If

        Next 'fim For Aliquotas

        'LIMPA OBJETOS DA MEMÓRIA...
        mCstCfopAlq = Nothing : i = Nothing : strCST_CFOP_ALQ = Nothing : mNumeroNF = Nothing
        aliqICMS = Nothing : totProd = Nothing : bcalcICMS = Nothing : vlICMS = Nothing
        vlIsento = Nothing : vlOutras = Nothing : vlIPI = Nothing : vlDesc = Nothing : vlFrete = Nothing
        vlSeguro = Nothing : vlOutrasDesp = Nothing : Cfop = Nothing : Cst = Nothing
        mExistCstCfopAlq = Nothing



    End Sub

    Private Sub cbo_xmcfopNF_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_xmcfopNF.GotFocus

        If Not (Me.cbo_xmcfopNF.DroppedDown) Then Me.cbo_xmcfopNF.DroppedDown = True

    End Sub

    Private Sub cbo_bltipo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_bltipo.GotFocus

        If Not (Me.cbo_bltipo.DroppedDown) Then Me.cbo_bltipo.DroppedDown = True

    End Sub

    Private Sub cbo_blcarteira_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_blcarteira.GotFocus

        If Not (Me.cbo_blcarteira.DroppedDown) Then Me.cbo_blcarteira.DroppedDown = True

    End Sub

    Private Sub cbo_xmcfopProd_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_xmcfopProd.GotFocus

        If Not (Me.cbo_xmcfopProd.DroppedDown) Then Me.cbo_xmcfopProd.DroppedDown = True

    End Sub

    Private Sub cbo_xmcfopNF_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_xmcfopNF.Leave

        If cbo_xmcfopNF.SelectedIndex >= _valorZERO Then cbo_xmcfopProd.SelectedIndex = _
        trazIndexCfop(Mid(cbo_xmcfopNF.Text, 1, 5), cbo_xmcfopProd)

        If Mid(cbo_xmcfopNF.Text, 3, 3).Equals("910") Then

            cbo_xmcst.SelectedIndex = trazIndexCST("90", cbo_xmcst)

        End If



    End Sub

    Private Sub cbo_xmcfopNF_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_xmcfopNF.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")

        End If


    End Sub

    Private Sub cbo_xmcfopProd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_xmcfopProd.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")

        End If


    End Sub

    Private Sub cbo_xmcfopNF_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_xmcfopNF.KeyDown

        If Me.cbo_xmcfopNF.SelectedIndex >= _valorZERO AndAlso e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            If Me.verifCfop(Me.cbo_xmcfopNF) Then

                If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")

            End If
        ElseIf e.KeyCode = Keys.Down AndAlso Not (Me.cbo_xmcfopNF.DroppedDown) Then

            Me.cbo_xmcfopNF.DroppedDown = True

        ElseIf (Me.cbo_xmcfopNF.DroppedDown) AndAlso e.KeyCode <> Keys.Down AndAlso e.KeyCode <> Keys.Up Then

            Me.cbo_xmcfopNF.DroppedDown = False

        End If



    End Sub

    Private Sub cbo_xmcfopProd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_xmcfopProd.KeyDown

        If Me.cbo_xmcfopProd.SelectedIndex >= _valorZERO AndAlso e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            If Me.verifCfop(Me.cbo_xmcfopProd) Then

                If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")

            End If

        ElseIf e.KeyCode = Keys.Down AndAlso Not (Me.cbo_xmcfopProd.DroppedDown) Then

            Me.cbo_xmcfopProd.DroppedDown = True

        ElseIf (Me.cbo_xmcfopProd.DroppedDown) AndAlso e.KeyCode <> Keys.Down AndAlso e.KeyCode <> Keys.Up Then

            Me.cbo_xmcfopProd.DroppedDown = False

        End If



    End Sub

    Private Sub dtg_itensCompras_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtg_itensCompras.KeyDown

        Select Case e.KeyCode
            Case Keys.Delete
                If MessageBox.Show("Deseja deletar este item?", "GENOV", MessageBoxButtons.YesNo, _
                                   MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Me.DeleteDataGridItem()

                End If

        End Select



    End Sub

    Private Sub incluiFornecedorXml()

        Dim StrXml, StrXmlAux As String
        _importXml = True

        Dim xpos, xposfim, xposdif As Integer
        Dim xmCnpj, xmCpf As String
        Dim xmInscEstad, xmNome, xmNomeFantasia, xmCodMun, xmMun, xmCrt, xmLogradouro, xmNum As String
        Dim xmCompl, xmBairro, xmUF, xmCep, xmFone, xmCodPais, xmPais As String
        Dim tipo, carac, cod, civil, natur, ident, pai, mae, ender As String
        Dim ltrab, endtr, fontr, cargo, esposo, ltrabe, vend, obs1 As String
        Dim obs2, obs3, ultcomp, pedido, cdvend, cdcid As String
        Dim bloq, tb, consumo, ctactb, ctaanli As String
        Dim dtcad, dtnativ As Date
        Dim mes, valor, limite, rota, salar, salae As Double

        Try
            ' deleta a rquivo anterior
            If File.Exists(RTrim(ArqTmp.ToString)) Then File.Delete(RTrim(ArqTmp.ToString))

            ' Cria copia do arquivo xml p/ arquivo temporario
            File.Copy(RTrim(Me.txt_implocal.Text), ArqTmp, True)
            Dim MyfileStream As New IO.StreamReader(ArqTmp.ToString)

            StrXml = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream = Nothing

            xpos = _valorZERO : xposfim = _valorZERO : xposdif = _valorZERO
            Try
                xpos = StrXml.IndexOf("<emit>") : xposfim = StrXml.IndexOf("</emit>")
                StrXmlAux = StrXml.Substring(xpos, (xposfim - xpos))
                xmCnpj = "" : xmCpf = ""


                Try
                    ' Numero do CNPJ
                    xpos = StrXmlAux.IndexOf("<CNPJ>") '6
                    xposfim = StrXmlAux.IndexOf("</CNPJ>")
                    xposdif = (xposfim - xpos) - 6
                    xmCnpj = StrXmlAux.Substring(xpos + 6, xposdif)
                Catch ex As Exception
                    xmCnpj = ""
                End Try


                If xmCnpj.Equals("") Then
                    Try
                        ' Numero do CPF
                        xpos = StrXmlAux.IndexOf("<CPF>") : xposfim = StrXmlAux.IndexOf("</CPF>")
                        xposdif = (xposfim - xpos) - 5 : xmCpf = StrXmlAux.Substring(xpos + 5, xposdif)
                    Catch ex As Exception
                        xmCpf = ""
                    End Try
                End If


                Try
                    ' Inscrição Estadual <IE>
                    xpos = StrXmlAux.IndexOf("<IE>") : xposfim = StrXmlAux.IndexOf("</IE>")
                    xposdif = (xposfim - xpos) - 4 : xmInscEstad = StrXmlAux.Substring(xpos + 4, xposdif)

                Catch ex As Exception
                    xmInscEstad = ""
                End Try


                Try
                    ' tipo de Empresa CRT
                    xpos = StrXmlAux.IndexOf("<CRT>") : xposfim = StrXmlAux.IndexOf("</CRT>")
                    xposdif = (xposfim - xpos) - 5 : xmCrt = StrXmlAux.Substring(xpos + 5, xposdif)

                Catch ex As Exception
                    xmCrt = ""
                End Try


                Try
                    ' Razao Social  
                    xpos = StrXmlAux.IndexOf("<xNome>") : xposfim = StrXmlAux.IndexOf("</xNome>")
                    xposdif = (xposfim - xpos) - 7 : xmNome = StrXmlAux.Substring(xpos + 7, xposdif)

                Catch ex As Exception
                    xmNome = ""
                End Try


                Try
                    ' Nome Fantasia
                    xpos = StrXmlAux.IndexOf("<xFant>") : xposfim = StrXmlAux.IndexOf("</xFant>")
                    xposdif = (xposfim - xpos) - 7 : xmNomeFantasia = StrXmlAux.Substring(xpos + 7, xposdif)

                Catch ex As Exception
                    xmNomeFantasia = ""
                End Try


                Try
                    ' Logradouro
                    xpos = StrXmlAux.IndexOf("<xLgr>") : xposfim = StrXmlAux.IndexOf("</xLgr>")
                    xposdif = (xposfim - xpos) - 6 : xmLogradouro = StrXmlAux.Substring(xpos + 6, xposdif)

                Catch ex As Exception
                    xmLogradouro = ""
                End Try


                Try
                    ' Numero
                    xpos = StrXmlAux.IndexOf("<nro>") : xposfim = StrXmlAux.IndexOf("</nro>")
                    xposdif = (xposfim - xpos) - 5 : xmNum = StrXmlAux.Substring(xpos + 5, xposdif)

                Catch ex As Exception
                    xmNum = ""
                End Try


                Try
                    ' Complemento
                    xpos = StrXmlAux.IndexOf("<xCpl>") : xposfim = StrXmlAux.IndexOf("</xCpl>")
                    xposdif = (xposfim - xpos) - 6 : xmCompl = StrXmlAux.Substring(xpos + 6, xposdif)

                Catch ex As Exception
                    xmCompl = ""
                End Try


                Try
                    ' Bairro
                    xpos = StrXmlAux.IndexOf("<xBairro>") : xposfim = StrXmlAux.IndexOf("</xBairro>")
                    xposdif = (xposfim - xpos) - 9 : xmBairro = StrXmlAux.Substring(xpos + 9, xposdif)

                Catch ex As Exception
                    xmBairro = ""
                End Try


                Try
                    ' Municipio
                    xpos = StrXmlAux.IndexOf("<xMun>") : xposfim = StrXmlAux.IndexOf("</xMun>")
                    xposdif = (xposfim - xpos) - 6 : xmMun = StrXmlAux.Substring(xpos + 6, xposdif)

                Catch ex As Exception
                    xmMun = ""
                End Try


                Try
                    ' Codigo do Municipio
                    xpos = StrXmlAux.IndexOf("<cMun>") : xposfim = StrXmlAux.IndexOf("</cMun>")
                    xposdif = (xposfim - xpos) - 6 : xmCodMun = StrXmlAux.Substring(xpos + 6, xposdif)

                Catch ex As Exception
                    xmCodMun = ""
                End Try


                Try
                    ' Unidade de Federação
                    xpos = StrXmlAux.IndexOf("<UF>") : xposfim = StrXmlAux.IndexOf("</UF>")
                    xposdif = (xposfim - xpos) - 4 : xmUF = StrXmlAux.Substring(xpos + 4, xposdif)

                Catch ex As Exception
                    xmUF = ""
                End Try


                Try
                    ' CEP
                    xpos = StrXmlAux.IndexOf("<CEP>") : xposfim = StrXmlAux.IndexOf("</CEP>")
                    xposdif = (xposfim - xpos) - 5 : xmCep = StrXmlAux.Substring(xpos + 5, xposdif)

                Catch ex As Exception
                    xmCep = ""
                End Try


                Try
                    ' Fone
                    xpos = StrXmlAux.IndexOf("<fone>") : xposfim = StrXmlAux.IndexOf("</fone>")
                    xposdif = (xposfim - xpos) - 6 : xmFone = StrXmlAux.Substring(xpos + 6, xposdif)

                Catch ex As Exception
                    xmFone = ""
                End Try


                Try
                    ' Codigo do Pais
                    xpos = StrXmlAux.IndexOf("<cPais>") : xposfim = StrXmlAux.IndexOf("</cPais>")
                    xposdif = (xposfim - xpos) - 7 : xmCodPais = StrXmlAux.Substring(xpos + 7, xposdif)

                Catch ex As Exception
                    xmCodPais = ""
                End Try


                Try
                    ' Nome do Pais
                    xpos = StrXmlAux.IndexOf("<xPais>") : xposfim = StrXmlAux.IndexOf("</xPais>")
                    xposdif = (xposfim - xpos) - 7 : xmPais = StrXmlAux.Substring(xpos + 7, xposdif)

                Catch ex As Exception
                    xmPais = ""
                End Try

                tipo = "F" : carac = "J" : dtcad = Date.Now : cod = "" : civil = "" : dtnativ = Date.Now
                natur = "" : ident = "" : pai = "" : mae = "" : ender = xmLogradouro & "," & xmNum
                ltrab = "" : endtr = "" : fontr = "" : cargo = "" : salar = _valorZERO : esposo = ""
                ltrabe = "" : salae = _valorZERO : rota = _valorZERO : vend = "" : obs1 = "" : obs2 = "" : obs3 = ""
                ultcomp = "" : valor = _valorZERO : limite = _valorZERO : pedido = "" : cdvend = "" : cdcid = ""
                bloq = "" : tb = "" : consumo = "" : ctactb = "" : ctaanli = "" : mes = _valorZERO


            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally

            'LIMPA OBJETOS DA MEMÓRIA...
            xpos = Nothing : xposfim = Nothing : xposdif = Nothing : xmCnpj = Nothing : xmCpf = Nothing
            xmInscEstad = Nothing : xmNome = Nothing : xmNomeFantasia = Nothing : xmCodMun = Nothing
            xmMun = Nothing : xmCrt = Nothing : xmLogradouro = Nothing : xmNum = Nothing
            xmCompl = Nothing : xmBairro = Nothing : xmUF = Nothing : xmCep = Nothing : xmFone = Nothing
            xmCodPais = Nothing : xmPais = Nothing : tipo = Nothing : carac = Nothing : cod = Nothing
            civil = Nothing : natur = Nothing : ident = Nothing : pai = Nothing : mae = Nothing
            ender = Nothing : ltrab = Nothing : endtr = Nothing : fontr = Nothing : cargo = Nothing
            esposo = Nothing : ltrabe = Nothing : vend = Nothing : obs1 = Nothing : obs2 = Nothing
            obs3 = Nothing : ultcomp = Nothing : pedido = Nothing : cdvend = Nothing : cdcid = Nothing
            bloq = Nothing : tb = Nothing : consumo = Nothing : ctactb = Nothing : ctaanli = Nothing
            dtcad = Nothing : dtnativ = Nothing : mes = Nothing : valor = Nothing : limite = Nothing
            rota = Nothing : salar = Nothing : salae = Nothing

        End Try



    End Sub

    Private Sub cbo_localxm_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_xmlocal.GotFocus

        If Not (Me.cbo_xmlocal.DroppedDown) Then Me.cbo_xmlocal.DroppedDown = True

    End Sub

    Private Sub Msk_nfemissao_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Msk_nfemissao.GotFocus

        Msk_nfemissao.SelectAll()

    End Sub

    Private Sub Msk_nfdtent_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Msk_nfdtent.GotFocus

        Msk_nfdtent.SelectAll()

    End Sub

    Private Sub txt_alqSubsProd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqSubsProd.Leave

        Try
            Me.txt_alqSubsProd.Text = Format(CDec(Me.txt_alqSubsProd.Text), "###,##0.00")
            If (CDec(txt_alqSubsProd.Text) > _valorZERO) AndAlso (CDec(txt_BSubsItem.Text) > _valorZERO) Then

                txt_IcmSubProd.Text = Format( _
                CDec(txt_BSubsItem.Text) * (CDec(Me.txt_alqSubsProd.Text) / 100), "###,##0.00")

            End If
        Catch ex As Exception
        End Try



    End Sub

    Private Sub txt_nfbasesub_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nfbasesub.Leave

        If IsNumeric(txt_nfbasesub.Text) Then

            Me.txt_nfbasesub.Text = Format(CDec(Me.txt_nfbasesub.Text), "###,##0.00")

        Else

            Me.txt_nfbasesub.Text = Format(0, "###,##0.00")
        End If



    End Sub

    Private Sub Msk_nfemissao_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Msk_nfemissao.Leave

        If Not IsDate(Me.Msk_nfemissao.Text) Then

            Me.Msk_nfemissao.Focus() : Me.Msk_nfemissao.SelectAll()
            MsgBox("Data de Emissão da Nota inválida !", MsgBoxStyle.Exclamation)
            Me.Msk_nfemissao.Focus() : Me.Msk_nfemissao.SelectAll() : Return

        End If



    End Sub

    Private Sub Msk_nfdtent_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Msk_nfdtent.Leave

        If Not IsDate(Me.Msk_nfdtent.Text) Then

            Me.Msk_nfdtent.Focus() : Me.Msk_nfdtent.SelectAll()
            MsgBox("Data de Entrada da Nota inválida !", MsgBoxStyle.Exclamation)
            Me.Msk_nfdtent.Focus() : Me.Msk_nfdtent.SelectAll() : Return

        End If



    End Sub

    Private Sub cbo_nfcfop_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_nfcfop.Leave

        mNF_Cfop = ""
        If cbo_nfcfop.SelectedIndex >= 0 Then mNF_Cfop = cbo_nfcfop.Text.Substring(0, 5)
        Try

            If Not mbUf.Equals("") Then

                If mbUf = MdlEmpresaUsu._uf Then
                    If Mid(mNF_Cfop, 1, 1) <> "1" Then

                        MessageBox.Show("CFOP Invalido p/ Dentro do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        Me.cbo_nfcfop.Focus() : Me.cbo_nfcfop.SelectedIndex = -1 : Me.cbo_nfcfop.SelectAll() : Return

                    End If
                End If


                If mbUf <> MdlEmpresaUsu._uf Then
                    If Mid(mNF_Cfop, 1, 1) = "1" Then

                        MessageBox.Show("CFOP Invalido p/ Fora do Estado !", " ERRO CFOP ", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        Me.cbo_nfcfop.Focus() : Me.cbo_nfcfop.SelectedIndex = -1 : Me.cbo_nfcfop.SelectAll() : Return

                    End If
                End If
            End If

        Catch ex As Exception
        End Try



    End Sub

    Private Sub cbo_xmcst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_xmcst.GotFocus

        If Not (Me.cbo_xmcst.DroppedDown) Then Me.cbo_xmcst.DroppedDown = True

    End Sub

    Private Sub dtgXmlItens_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgXmlItens.MouseDoubleClick

        _prodEditXml = dtgXmlItens.CurrentRow.Index & "|" & dtgXmlItens.CurrentRow.Cells(6).Value & "|" & dtgXmlItens.CurrentRow.Cells(8).Value & "|" & _
        dtgXmlItens.CurrentRow.Cells(9).Value & "|" & dtgXmlItens.CurrentRow.Cells(12).Value & "|" & dtgXmlItens.CurrentRow.Cells(13).Value _
        & "|" & dtgXmlItens.CurrentRow.Cells(14).Value & "|" & dtgXmlItens.CurrentRow.Cells(15).Value & "|" & dtgXmlItens.CurrentRow.Cells(16).Value _
        & "|" & dtgXmlItens.CurrentRow.Cells(17).Value & "|" & dtgXmlItens.CurrentRow.Cells(18).Value & "|" & dtgXmlItens.CurrentRow.Cells(19).Value _
        & "|" & dtgXmlItens.CurrentRow.Cells(20).Value & "|" & dtgXmlItens.CurrentRow.Cells(21).Value & "|" & dtgXmlItens.CurrentRow.Cells(22).Value _
        & "|" & dtgXmlItens.CurrentRow.Cells(23).Value & "|" & dtgXmlItens.CurrentRow.Cells(24).Value & "|" & dtgXmlItens.CurrentRow.Cells(25).Value _
        & "|" & dtgXmlItens.CurrentRow.Cells(26).Value & "|" & dtgXmlItens.CurrentRow.Cells(27).Value & "|" & dtgXmlItens.CurrentRow.Cells(28).Value _
        & "|" & dtgXmlItens.CurrentRow.Cells(29).Value & "|" & dtgXmlItens.CurrentRow.Cells(30).Value
        _prodEditXml = _prodEditXml

        posXmlProdEdit = trazPosCurrentProdXml(dtgXmlItens.CurrentRow.Index)
        trazItenEditXml() : posGridProdEditXml = dtgXmlItens.CurrentRow.Index



    End Sub

    Private Function trazPosCurrentProdXml(ByVal indiceProdGrid As Integer) As Integer

        Dim posicao As Integer = 0
        Dim marray As Array = Split(_produtosXml.ToString, "?")
        Dim marray2 As Array
        Dim i As Integer

        For i = 0 To marray.Length - 2

            marray2 = Split(marray(i).ToString, "|")
            If marray2(1).ToString.Equals(indiceProdGrid.ToString) Then

                posicao = CInt(marray2(0).ToString) : Exit For

            End If

            If posicao > 0 Then Exit For
        Next
        marray = Nothing : marray2 = Nothing : i = Nothing


        Return posicao
    End Function

    Private Sub trazItenEditXml()

        Dim StrXml As String

        Try
            ' deleta a rquivo anterior
            If File.Exists(RTrim(ArqTmp.ToString)) Then File.Delete(RTrim(ArqTmp.ToString))

            ' Cria copia do arquivo xml p/ arquivo temporario
            File.Copy(RTrim(Me.txt_implocal.Text), ArqTmp, True)
            Dim MyfileStream As New IO.StreamReader(ArqTmp.ToString)
            StrXml = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream = Nothing
            Dim xpos, xpos1, xpos2, xpos3, xpos4, xpos5, xpos6, xpos7, xpos8, xposfim, xposdif As Integer
            Dim mAuxValores As String = "0"
            xpos = _valorZERO : xpos1 = _valorZERO : xpos2 = _valorZERO : xposfim = _valorZERO : xposdif = _valorZERO

            Try
                Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd As String
                Dim mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd As Double
                Dim mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mBcSubsProd As Double
                Dim mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd As Double
                Dim mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd As Double
                Dim mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF As Double

                ' Codigo do Produto
                xpos1 = StrXml.IndexOf("<cProd>", posXmlProdEdit)
                If xpos1 >= _valorZERO Then

                    posXmlProdEdit = xpos1 - 1 : xposfim = StrXml.IndexOf("</cProd>", posXmlProdEdit)
                    xposdif = (xposfim - xpos1) - 7
                    Me.txt_xmcodigoForn.Text = Mid(StrXml, xpos1 + 8, xposdif)


                    ' Descriçao do Produto
                    xpos2 = StrXml.IndexOf("<xProd>", posXmlProdEdit) : xposfim = StrXml.IndexOf("</xProd>", posXmlProdEdit)
                    xposdif = (xposfim - xpos2) - 7 : Me.txt_xmprodutoforn.Text = Mid(StrXml, xpos2 + 8, xposdif)


                    ' NCM
                    xpos3 = StrXml.IndexOf("<NCM>", posXmlProdEdit) : xposfim = StrXml.IndexOf("</NCM>", posXmlProdEdit)
                    xposdif = (xposfim - xpos3) - 5
                    Me.txt_xmncmForn.Text = Mid(StrXml, xpos3 + 6, xposdif)


                    ' Unidade
                    xpos4 = StrXml.IndexOf("<uCom>", posXmlProdEdit) : xposfim = StrXml.IndexOf("</uCom>", posXmlProdEdit)
                    xposdif = (xposfim - xpos4) - 6
                    If xposdif = 2 Then

                        Me.txt_xmunidForn.Text = Mid(StrXml, xposfim - 1, 2)

                    Else

                        Me.txt_xmunidForn.Text = Mid(StrXml, xpos4 + 7, xposdif)
                    End If


                    ' Codigo de Barras <cEAN>
                    xpos5 = StrXml.IndexOf("<cEAN>", posXmlProdEdit) : xposfim = StrXml.IndexOf("</cEAN>", posXmlProdEdit)
                    xposdif = (xposfim - xpos5) - 6
                    If xposdif > 5 Then Me.txt_xmcodbarraForn.Text = Mid(StrXml, xpos5 + 7, xposdif)


                    ' Valor Unitario <vUnCom>
                    xpos6 = StrXml.IndexOf("<vUnCom>", posXmlProdEdit)
                    xposfim = StrXml.IndexOf("</vUnCom>", posXmlProdEdit)
                    xposdif = (xposfim - xpos6) - 8
                    Me.txt_xmpcounit.Text = Mid(StrXml, xpos6 + 9, xposdif)
                    Try
                        mAuxValores = Mid(StrXml, xpos6 + 9, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                        mAuxValores = mAuxValores.Replace(".", ",") : _vlCompProdXml = CDbl(mAuxValores)

                    Catch ex As Exception
                        _vlCompProdXml = 0.0
                    End Try

                    ' Total dos Produtos <vProd>
                    xpos7 = StrXml.IndexOf("<vProd>", posXmlProdEdit) : xposfim = StrXml.IndexOf("</vProd>", posXmlProdEdit)
                    xposdif = (xposfim - xpos7) - 7 : Me.txt_xmprtot.Text = Mid(StrXml, xpos7 + 8, xposdif)

                    ' Quantidade <qCom>
                    xpos8 = StrXml.IndexOf("<qCom>", posXmlProdEdit) : xposfim = StrXml.IndexOf("</qCom>", posXmlProdEdit)
                    xposdif = (xposfim - xpos8) - 6 : Me.txt_xmqtde.Text = Mid(StrXml, xpos8 + 7, xposdif)


                    If Not Me.txt_xmcodigoForn.Text.Equals("") Then

                        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                        Try
                            conn.Open()
                            Me.txt_xmcodpr.Text = _clBD.pegaRelacionProdFornXML(_clFunc.RemoverCaracter(Me.msk_cnpj.Text), _
                                           Me.txt_xmcodigoForn.Text, conn)
                            conn.ClearPool()
                        Catch ex As Exception
                        Finally

                            If conn.State = ConnectionState.Open Then conn.Close()
                            conn = Nothing
                        End Try

                    End If
                End If


                'LIMPA OBJETOS DA MEMÓRIA...
                mCodProd = Nothing : mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing
                mCstProd = Nothing : mCsosnProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing
                mVlPercDesc = Nothing : mVlDesc = Nothing : mVlTotProd = Nothing : mVlUnitComprProd = Nothing
                mVlUnitProdNF = Nothing : mVlPercRedProd = Nothing : mVlBcIcmsProd = Nothing
                mVlAlqIcmsProd = Nothing : mVlIcmsProd = Nothing : mBcSubsProd = Nothing
                mVlAlqSubsProd = Nothing : mVlSubsProd = Nothing : mVlAlqIpiProd = Nothing
                mVlIpiProd = Nothing : mVlPercFretProd = Nothing : mVlFretProd = Nothing : mVlSeguroProd = Nothing
                mVlDespProd = Nothing : mVlOutrosProd = Nothing : mVlCustoProd = Nothing
                mVlPercLucroProd = Nothing : mVlSurgeridoProd = Nothing


            Catch ex As Exception
                MsgBox("Não deu ERRO ao Incluir este Item " & ex.Message, MsgBoxStyle.Exclamation)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Private Sub addItenEditXmlGrid()

        Dim StrXml, StrXmlAux As String

        Try
            ' deleta arquivo anterior
            If File.Exists(RTrim(ArqTmp.ToString)) Then File.Delete(RTrim(ArqTmp.ToString))

            ' Cria copia do arquivo XML p/ arquivo temporario
            File.Copy(RTrim(Me.txt_implocal.Text), ArqTmp, True)
            Dim MyfileStream As New IO.StreamReader(ArqTmp.ToString)
            StrXml = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream = Nothing

            Dim xpos, xpos1, xpos2, xpos3, xpos7, xpos8, xposfim, xposdif As Integer
            xpos = _valorZERO : xpos1 = _valorZERO : xpos2 = _valorZERO : xposfim = _valorZERO : xposdif = _valorZERO

            Try
                Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd, mUndProd As String
                Dim mQtdeProd, mVlProd, mVlPercDesc, mVlDesc, mVlTotProd, mVlUnitComprProd As Double
                Dim mVlPercRedProd, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, mVlBcSubsProd As Double
                Dim mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd As Double
                Dim mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd As Double
                Dim mVlPercLucroProd, mVlSurgeridoProd, mVlUnitProdNF As Double
                Dim mAuxValores As String

                mCsosnProd = "" : StrXmlAux = StrXml

                xpos1 = StrXml.IndexOf("<cProd>", posXmlProdEdit)
                If xpos1 >= _valorZERO Then

                    xposfim = StrXml.IndexOf("</det>", posXmlProdEdit) : xpos3 = xposfim - xpos1
                    StrXmlAux = StrXml.Substring(xpos1, xpos3)

                End If


                ' Codigo do Produto
                mCodProd = Me.txt_xmcodpr.Text

                ' Descriçao do Produto
                mNomeProd = Me.txt_xmNomeProd.Text

                ' NCM
                xpos3 = StrXmlAux.IndexOf("<NCM>") : xposfim = StrXmlAux.IndexOf("</NCM>")
                xposdif = (xposfim - xpos3) - 5 : mNcmProd = Mid(StrXmlAux, xpos3 + 6, xposdif)

                ' CFOP <CFOP>
                mCfopProd = Mid(Me.cbo_xmcfopProd.Text, 1, 1) & Mid(Me.cbo_xmcfopProd.Text, 3, 3) 'Mid(StrXmlAux, xpos8 + 7, xposdif)
                ' CST <CST>
                mCstProd = cbo_xmcst.Text.Substring(0, 2)

                ' Unidade
                mUndProd = Me.txt_xmundprod.Text 'mbUndProd '<---

                'Preço unitario de Compra do Produto
                mVlUnitComprProd = Round(CDbl(Me.txt_xmpcounit.Text), 2)


                ' Total dos Produtos <vProd>
                xpos7 = StrXmlAux.IndexOf("<vProd>") : xposfim = StrXmlAux.IndexOf("</vProd>")
                xposdif = (xposfim - xpos7) - 7
                Try
                    mAuxValores = Mid(StrXmlAux, xpos7 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlTotProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlTotProd = 0.0
                End Try


                ' Quantidade <qCom>
                xpos8 = StrXmlAux.IndexOf("<qCom>") : xposfim = StrXmlAux.IndexOf("</qCom>")
                xposdif = (xposfim - xpos8) - 6
                Try
                    mAuxValores = Me.txt_xmqtde.Text : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mQtdeProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mQtdeProd = 0.0
                End Try

                'Valor Unitario <vUnCom>
                mVlUnitComprProd = 0.0
                mVlUnitComprProd = Round(mVlTotProd / mQtdeProd, 2)


                'ICMS NORMAL ... 
                ' Base de calculo do ICMS <vBC>
                xpos8 = StrXmlAux.IndexOf("<vBC>") : xposfim = StrXmlAux.IndexOf("</vBC>")
                xposdif = (xposfim - xpos8) - 5
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 6, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlBcIcmsProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlBcIcmsProd = 0.0
                End Try


                ' ALIQUOTA DO ICMS <pICMS>
                xpos8 = StrXmlAux.IndexOf("<pICMS>") : xposfim = StrXmlAux.IndexOf("</pICMS>")
                xposdif = (xposfim - xpos8) - 7
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlAlqIcmsProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlAlqIcmsProd = 0.0
                End Try


                ' VALOR DO ICMS <vICMS>
                xpos8 = StrXmlAux.IndexOf("<vICMS>") : xposfim = StrXmlAux.IndexOf("</vICMS>")
                xposdif = (xposfim - xpos8) - 7
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlIcmsProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlIcmsProd = 0.0
                End Try


                'SUBSTITUIÇÃO ... 
                ' Base de calculo da Substituição <vBCST>
                xpos8 = StrXmlAux.IndexOf("<vBCST>") : xposfim = StrXmlAux.IndexOf("</vBCST>")
                xposdif = (xposfim - xpos8) - 7
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlBcSubsProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlBcSubsProd = 0.0
                End Try


                ' aliquota da Substituição <pICMSST>
                xpos8 = StrXmlAux.IndexOf("<pICMSST>") : xposfim = StrXmlAux.IndexOf("</pICMSST>")
                xposdif = (xposfim - xpos8) - 9
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 10, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlAlqSubsProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlAlqSubsProd = 0.0
                End Try


                ' valor da Substituição <vICMSST>
                xpos8 = StrXmlAux.IndexOf("<vICMSST>") : xposfim = StrXmlAux.IndexOf("</vICMSST>")
                xposdif = (xposfim - xpos8) - 9
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 10, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlSubsProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlSubsProd = 0.0
                End Try


                'IPI ... 
                'aliquota do ipi <pIPI>
                xpos8 = StrXmlAux.IndexOf("<pIPI>") : xposfim = StrXmlAux.IndexOf("</pIPI>")
                xposdif = (xposfim - xpos8) - 6
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 7, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlAlqIpiProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlAlqIpiProd = 0.0
                End Try


                'valor do ipi <vIPI>
                xpos8 = StrXmlAux.IndexOf("<vIPI>") : xposfim = StrXmlAux.IndexOf("</vIPI>")
                xposdif = (xposfim - xpos8) - 6
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 7, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlIpiProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlIpiProd = 0.0
                End Try


                'verificação da aliquota do ipi
                If (mVlIpiProd > _valorZERO) AndAlso (mVlAlqIpiProd <= _valorZERO) Then

                    If mVlBcIcmsProd > _valorZERO Then

                        mVlAlqIpiProd = Round((mVlIpiProd / mVlBcIcmsProd) * 100, 2)

                    Else
                        mVlAlqIpiProd = Round((mVlIpiProd / mVlTotProd) * 100, 2)

                    End If
                End If


                'valor do Frete <vFrete> 
                xpos8 = StrXmlAux.IndexOf("<vFrete>") : xposfim = StrXmlAux.IndexOf("</vFrete>")
                xposdif = (xposfim - xpos8) - 8
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 9, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlFretProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlFretProd = 0.0
                End Try


                'valor do Seguro <vSeg> 
                xpos8 = StrXmlAux.IndexOf("<vSeg>") : xposfim = StrXmlAux.IndexOf("</vSeg>")
                xposdif = (xposfim - xpos8) - 6
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 7, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlSeguroProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlSeguroProd = 0.0
                End Try


                'valor de Outra Despesas <vOutro> 
                xpos8 = StrXmlAux.IndexOf("<vOutro>") : xposfim = StrXmlAux.IndexOf("</vOutro>")
                xposdif = (xposfim - xpos8) - 8
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 9, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlDespProd = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlDespProd = 0.0
                End Try


                'valor do Desconto <vDesc> 
                xpos8 = StrXmlAux.IndexOf("<vDesc>") : xposfim = StrXmlAux.IndexOf("</vDesc>")
                xposdif = (xposfim - xpos8) - 7
                Try
                    mAuxValores = Mid(StrXmlAux, xpos8 + 8, xposdif) : mAuxValores = mAuxValores.Replace(",", "")
                    mAuxValores = mAuxValores.Replace(".", ",") : mVlDesc = CDbl(mAuxValores)

                Catch ex As Exception
                    mVlDesc = 0.0
                End Try

                mVlProd = _vlCompProdXml
                mVlUnitProdNF = Round((mVlTotProd - mVlDesc) / mQtdeProd, 2)


                Try
                    Dim mlinha As String() = {mCodProd, mNomeProd, mbUndProd, mNcmProd, mCfopProd, mCstProd, mCsosnProd, mQtdeProd, mVlProd, _
                                                  mVlTotProd, mVlUnitComprProd, mVlUnitProdNF, mVlBcIcmsProd, mVlAlqIcmsProd, mVlIcmsProd, _
                                                  mVlBcSubsProd, mVlAlqSubsProd, mVlSubsProd, mVlAlqIpiProd, mVlIpiProd, mVlPercFretProd, _
                                                  mVlFretProd, mVlSeguroProd, mVlDespProd, mVlOutrosProd, mVlCustoProd, mVlPercLucroProd, _
                                                  mVlSurgeridoProd, mVlPercDesc, mVlDesc, mVlPercRedProd}

                    'Adicionando Linha
                    Me.dtgXmlItens.Rows(posGridProdEditXml).SetValues(mlinha)
                    dtgXmlItens.Refresh() : _prodEditXml = "" : mlinha = Nothing

                    limpaCamposXmlIten()

                    'LIMPA OBJETOS DA MEMÓRIA...
                    mCodProd = Nothing : mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing
                    mCstProd = Nothing : mCsosnProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing
                    mVlPercDesc = Nothing : mVlDesc = Nothing : mVlTotProd = Nothing : mVlUnitComprProd = Nothing
                    mVlUnitProdNF = Nothing : mVlPercRedProd = Nothing : mVlBcIcmsProd = Nothing
                    mVlAlqIcmsProd = Nothing : mVlIcmsProd = Nothing : mVlBcSubsProd = Nothing
                    mVlAlqSubsProd = Nothing : mVlSubsProd = Nothing : mVlAlqIpiProd = Nothing
                    mVlIpiProd = Nothing : mVlPercFretProd = Nothing : mVlFretProd = Nothing
                    mVlSeguroProd = Nothing : mVlDespProd = Nothing : mVlOutrosProd = Nothing
                    mVlCustoProd = Nothing : mVlPercLucroProd = Nothing : mVlSurgeridoProd = Nothing


                Catch ex As Exception
                    MsgBox("Deu ERRO ao Incluir este Item " & ex.Message, MsgBoxStyle.Exclamation)
                End Try

            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Private Sub txt_BcalculoItem_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_BcalculoItem.Leave

        Me.txt_BcalculoItem.Text = Format(CDec(Me.txt_BcalculoItem.Text), "###,##0.00")
        If IsNumeric(Me.txt_BcalculoItem.Text) Then
            If (CDbl(Me.txt_nfbscalculo.Text) > _valorZERO) AndAlso (CDbl(Me.txt_BcalculoItem.Text) > _valorZERO) _
                AndAlso (CDbl(Me.txt_BcalculoItem.Text) < CDbl(Me.txt_prtot.Text)) Then

                Me.txt_reducao.Text = Format(Round(((CDbl(Me.txt_prtot.Text) - CDbl(Me.txt_BcalculoItem.Text)) / _
                                                    (CDbl(Me.txt_prtot.Text)) * 100), 3), "###,##0.000")
            End If
        End If



    End Sub

    Private Sub btn_consultaXml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultaXml.Click

        Try
            Dim mSite As New Uri("http://www.nfe.fazenda.gov.br/portal/consulta.aspx?tipoConsulta=completa&tipoConteudo=XbSeqxE8pl8=")
            Dim mRequest As WebRequest = WebRequest.Create(mSite)
            Dim mResponse As WebResponse = mRequest.GetResponse()
            Me.frm_WB_xmldanfe.Navigate(mSite)
            mSite = Nothing : mRequest = Nothing : mResponse = Nothing

        Catch ex1 As Exception
            MsgBox("ERRO -> " & ex1.Message)
        End Try



    End Sub

    Private Sub btn_xmNovoItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_xmNovoItem.Click

        _frmREf = Me
        Dim FrmProdutosGerais As New Frm_ManProdutos
        FrmProdutosGerais.ShowDialog() : FrmProdutosGerais = Nothing : Me.txt_xmcodpr.Focus()

    End Sub

    Private Sub cbo_itcfop_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_itcfop.Leave

        If cbo_itcfop.SelectedIndex < _valorZERO Then

            MsgBox("Selecione um CFOP para o produto", MsgBoxStyle.Exclamation, "METROSYS")
            Me.cbo_itcfop.Focus()

        End If


    End Sub

End Class