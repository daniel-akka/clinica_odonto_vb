Imports Npgsql
Imports System.Text
Imports System.Math

Public Class Frm_MapaPrevenda
    Private Const _valorZERO As Integer = 0
    Private _vlrTotalItem As Double = _valorZERO
    Private _CodProdEditando As String = ""
    Private _indexProdEditando As Integer = -1
    Private _qtdeAnterior As Double = _valorZERO
    Public Shared _frmREf As New Frm_MapaPrevenda

    'Objetos para tratar o Produto...
    Dim _BuscaProdMp As New Frm_BuscaProdMp
    Public qtdFiscProd_Ref As Double = _valorZERO
    Public ValorUnitProd_Ref As Double = _valorZERO
    Public pesoBrutoProd_Ref As Double = _valorZERO
    Public pesoLiqProd_Ref As Double = _valorZERO
    Public nomeProd_Ref As String = "", codProd_Ref As String = "", local_Ref As String = ""
    Public UndProd_Ref As String = "", CstProd_Ref As String = "", CfvProd_Ref As String = ""
    Public GrupoProd_Ref As String = "", ReduzProd_Ref As String = "", ClfProd_Ref As String = ""
    Public codBarraProd_Ref As String = ""


    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes

    Private Sub Frm_MapaPrevenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_numeroMp.Text = ""
        Me.txt_qtde.Text = "0,00"
        Me.cbo_local.SelectedIndex = 0
        msk_dtemisao.Text = Format(Date.Now, "ddMMyyyy")

        'Traz um Data com 1 dia a frente da Data Atual...
        msk_dtsaida.Text = _
        Format(DateSerial(CDate(msk_dtemisao.Text).Year, CDate(msk_dtemisao.Text).Month, CDate(msk_dtemisao.Text).Day + 1), "ddMMyyyy")

        If Not MdlUsuarioLogando._local.Equals("") Then
            cbo_local.Items.Clear() : cbo_local.Refresh()
            cbo_local.Items.Add(MdlUsuarioLogando._local.Substring(3, 2))
            cbo_local.Refresh()

        End If

        Me.cbo_placaVeic = _clFuncoes.PreenchComboPlacaVeic(Me.cbo_placaVeic, MdlConexaoBD.conectionPadrao)

    End Sub

    Private Sub Frm_MapaPrevenda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                executaF2()
            Case Keys.F3
                executaF3()
            Case Keys.F4
                executaF4()
            Case Keys.F7
                executaF7()

        End Select


    End Sub

    Private Sub Frm_MapaPrevenda_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If


    End Sub

    Private Sub addItemGrid()

        Try
            _vlrTotalItem = _valorZERO
            _vlrTotalItem = Round((CDbl(txt_valorunit.Text) * CDbl(txt_qtde.Text)), 2)
            Dim mlinha As String() = {txt_codprod.Text, txt_nomeProd.Text, txt_qtde.Text, txt_valorunit.Text, _
                                      Format(_vlrTotalItem, "###,##0.00"), UndProd_Ref, pesoLiqProd_Ref, _
                                      pesoBrutoProd_Ref, codBarraProd_Ref}

            'Adicionando Linha
            Me.dtg_mapa.Rows.Add(mlinha)
            Me.dtg_mapa.Refresh()
            Me.txt_vltotalMp.Text = Format(somaVlrTotalItensGrid, "###,##0.00")


            'Subtrai a quantidade do Estoque a quantidade requerida para o Mapa...
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim transacao As NpgsqlTransaction

            If conection.State = ConnectionState.Closed Then conection.Open()
            transacao = conection.BeginTransaction
            _clBD.subtraiQtdeProdEstloja(txt_codprod.Text, cbo_local.Text, CDbl(txt_qtde.Text), conection, transacao)
            transacao.Commit()

            conection.Close() : conection = Nothing : mlinha = Nothing
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try



    End Sub

    Private Sub addItemEditadoGrid()

        Try
            _vlrTotalItem = _valorZERO
            _vlrTotalItem = Round((CDbl(txt_valorunit.Text) * CDbl(txt_qtde.Text)), 2)
            Dim mlinha As String() = {txt_codprod.Text, txt_nomeProd.Text, txt_qtde.Text, txt_valorunit.Text, _
                                      Format(_vlrTotalItem, "###,##0.00"), UndProd_Ref, pesoLiqProd_Ref, _
                                      pesoBrutoProd_Ref, codBarraProd_Ref}

            'Adicionando Linha
            Me.dtg_mapa.Rows(_indexProdEditando).SetValues(mlinha)
            Me.dtg_mapa.Refresh()
            Me.txt_vltotalMp.Text = Format(somaVlrTotalItensGrid, "###,##0.00")


            'Atualiza a quantidade do Estoque do produto requerido para o Mapa...
            If txt_codprod.Text.Equals(_CodProdEditando) Then

                If CDbl(txt_qtde.Text) <> _qtdeAnterior Then

                    Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Dim transacao As NpgsqlTransaction
                    Dim mNovaQtde As Double = _valorZERO
                    If conection.State = ConnectionState.Closed Then conection.Open()
                    transacao = conection.BeginTransaction

                    If CDbl(txt_qtde.Text) < _qtdeAnterior Then
                        mNovaQtde = _qtdeAnterior - CDbl(txt_qtde.Text)
                        _clBD.somaQtdeProdEstloja(txt_codprod.Text, cbo_local.Text, mNovaQtde, conection, transacao)

                    ElseIf CDbl(txt_qtde.Text) > _qtdeAnterior Then
                        mNovaQtde = CDbl(txt_qtde.Text) - _qtdeAnterior
                        _clBD.subtraiQtdeProdEstloja(txt_codprod.Text, cbo_local.Text, mNovaQtde, conection, transacao)

                    End If

                    transacao.Commit()
                    conection = Nothing


                End If
            Else

                Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Dim transacao As NpgsqlTransaction
                Dim mNovaQtde As Double = _valorZERO
                conection.Open()
                transacao = conection.BeginTransaction

                _clBD.subtraiQtdeProdEstloja(txt_codprod.Text, cbo_local.Text, CDbl(txt_qtde.Text), conection, transacao)

                transacao.Commit() : conection.ClearPool() : conection.Close()
                conection = Nothing


            End If

            _CodProdEditando = ""
            _indexProdEditando = -1
            mlinha = Nothing
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try



    End Sub

    Private Function verifCamposAddDtg() As Boolean

        Dim mNaoDeuErro As Boolean = True
        lbl_mensagem.Text = ""
        If Not IsDate(msk_dtemisao.Text) Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Data de emissão inválida !"
            'MsgBox("Data de emissão inválida!", MsgBoxStyle.Exclamation)
            msk_dtemisao.Focus()
            Return mNaoDeuErro

        End If

        If Not IsDate(msk_dtsaida.Text) Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Data de Saída inválida !"
            msk_dtsaida.Focus()
            Return mNaoDeuErro

        End If

        If txt_codProd.Text.Equals("") Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Informar o Código do Produto !"
            txt_codprod.Focus()
            Return mNaoDeuErro

        End If

        If Not IsNumeric(txt_qtde.Text) Then
            mNaoDeuErro = False
            lbl_mensagem.Text = "Quantidade para o Produto inválida !"
            txt_qtde.Focus()
            Return mNaoDeuErro

        ElseIf CDbl(txt_qtde.Text) <= 0 Then
            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe a quantidade para o Produto !"
            txt_qtde.Focus()
            Return mNaoDeuErro

        Else

            If CDbl(txt_qtde.Text) > _qtdeAnterior Then
                If (CDbl(txt_qtde.Text) - _qtdeAnterior) > qtdFiscProd_Ref Then

                    mNaoDeuErro = False
                    lbl_mensagem.Text = "Quantidade MAIOR do que a do Estoque !"
                    txt_qtde.Focus()
                    Return mNaoDeuErro

                End If
            End If
        End If

        If Not IsNumeric(txt_valorunit.Text) Then
            mNaoDeuErro = False
            lbl_mensagem.Text = "Valor Unitario para o Produto inválido !"
            txt_valorunit.Focus()
            Return mNaoDeuErro

        ElseIf CDbl(txt_valorunit.Text) <= 0 Then
            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe um valor Unitario para o Produto !"
            txt_valorunit.Focus()
            Return mNaoDeuErro

        End If

        If _indexProdEditando < _valorZERO Then

            'Verifica se Produto já existe no Grid...
            For Each row As DataGridViewRow In Me.dtg_mapa.Rows

                If Not row.IsNewRow Then
                    If row.Cells(0).Value.Equals(txt_codprod.Text) Then

                        mNaoDeuErro = False
                        lbl_mensagem.Text = "Produto já exite no Mapa !"
                        Return mNaoDeuErro

                    End If
                End If
            Next

        ElseIf Me.txt_codprod.Text <> _CodProdEditando Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Produto já exite no Mapa !"
            Return mNaoDeuErro

        End If



        Return mNaoDeuErro
    End Function

    Private Function somaVlrTotalItensGrid() As Double

        Dim mVlrTotalItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_mapa.Rows

            If Not row.IsNewRow Then mVlrTotalItens += row.Cells(4).Value

        Next



        mVlrTotalItens = Round(mVlrTotalItens, 2)
        Return mVlrTotalItens
    End Function

    Private Sub limpaObjetos_Ref()

        codProd_Ref = "" : nomeProd_Ref = "" : qtdFiscProd_Ref = _valorZERO
        UndProd_Ref = "" : CstProd_Ref = "" : CfvProd_Ref = "" : GrupoProd_Ref = ""
        ReduzProd_Ref = "" : ValorUnitProd_Ref = _valorZERO : ClfProd_Ref = ""

    End Sub

    Private Sub executaF2()

        If verifCamposAddDtg() Then
            If _CodProdEditando.Equals("") Then
                addItemGrid()
            Else
                addItemEditadoGrid()
            End If

            If Me.txt_numeroMp.Text.Equals("") Then

                Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                conection.Open()
                Me.txt_numeroMp.Text = String.Format("{0:D10}", _clBD.trazProxCodMapa(MdlEmpresaUsu._codigo, conection))
                _clBD.updateGenp001CodMapa(conection, Me.txt_numeroMp.Text, MdlEmpresaUsu._codigo)
                conection.ClearPool() : conection.Close() : conection = Nothing

            End If

            txt_codprod.Text = "" : txt_nomeProd.Text = "" : lbl_qtdFisc.Text = "0,00"
            Me.txt_codprod.Focus() : _qtdeAnterior = _valorZERO : limpaObjetos_Ref()

        End If



    End Sub

    Private Sub Btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_novo.Click

        executaF2()

    End Sub

    Public Function trazItenBD(ByVal codIten As String) As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader


        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False
        End Try



        Try
            SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, e.e_qtde, e.e_und, e.e_ncm, ") ' 5
            SqlProduto.Append("e.e_cst, e.e_cfv, e.e_grupo, e.e_reduz, el.e_qtdfisc, el.e_pcusto, el.e_pvenda, ") ' 12
            SqlProduto.Append("e.e_clf, e.e_pesobruto, e.e_pesoliq, e.e_cdbarra FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN ") '16
            SqlProduto.Append("estloja01 el ON e.e_codig = el.e_codig WHERE ")
            SqlProduto.Append("el.e_loja = '" & local_Ref & "' AND ")
            SqlProduto.Append("e.e_codig = '" & codIten & "' ORDER BY e_produt ASC")

            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDGENOV)
            drProduto = CmdProduto.ExecuteReader
            If drProduto.HasRows = False Then Return False
            While drProduto.Read
                codProd_Ref = drProduto(0).ToString
                nomeProd_Ref = drProduto(1).ToString
                qtdFiscProd_Ref = drProduto(10)
                UndProd_Ref = drProduto(4).ToString
                CstProd_Ref = drProduto(6).ToString
                CfvProd_Ref = drProduto(7).ToString
                GrupoProd_Ref = drProduto(8).ToString
                ReduzProd_Ref = drProduto(9).ToString
                ValorUnitProd_Ref = drProduto(12)
                ClfProd_Ref = drProduto(13).ToString
                pesoLiqProd_Ref = drProduto(14)
                pesoBrutoProd_Ref = drProduto(15)
                codBarraProd_Ref = drProduto(16).ToString
                txt_codprod.Text = codProd_Ref : txt_nomeProd.Text = nomeProd_Ref
                txt_valorunit.Text = Format(ValorUnitProd_Ref, "###,##0.00")
                lbl_qtdFisc.Text = Format(qtdFiscProd_Ref, "###,##0.00")

            End While
            drProduto.Close()


        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        Finally
            CmdProduto.CommandText = ""
            SqlProduto.Remove(_valorZERO, SqlProduto.ToString.Length)

            oConnBDGENOV.ClearPool()
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            drProduto = Nothing : SqlProduto = Nothing : CmdProduto = Nothing
            oConnBDGENOV = Nothing

        End Try



        Return True
    End Function

    Private Sub txt_codprod_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codprod.GotFocus

        txt_codprod.SelectAll()

    End Sub

    Private Sub txt_nomeProd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nomeProd.GotFocus

        txt_nomeProd.SelectAll()

    End Sub

    Private Sub txt_numeroMp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numeroMp.GotFocus

        txt_numeroMp.SelectAll()

    End Sub

    Private Sub txt_codprod_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codprod.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then
            If Me.txt_codprod.Text.Equals("") Then

                'Aqui tenta chamar a Busca do Produto...
                Try
                    _frmREf = Me : _BuscaProdMp.set_frmRef(Me) : _BuscaProdMp.ShowDialog(Me)
                    If Me.txt_codprod.Text.Equals("") Then Me.txt_codprod.Focus()

                    txt_nomeProd.Focus() : txt_nomeProd.SelectAll()
                    txt_codprod.Text = codProd_Ref : txt_nomeProd.Text = nomeProd_Ref
                    txt_valorunit.Text = Format(ValorUnitProd_Ref, "###,##0.00")
                    lbl_qtdFisc.Text = Format(qtdFiscProd_Ref, "###,##0.00")
                Catch ex As Exception
                End Try

            Else

                'Se o código informado não existir no Banco de Dados, então...
                If trazItenBD(Me.txt_codprod.Text) = False Then
                    'Aqui tenta chamar a Busca do Produto...
                    Try
                        _frmREf = Me : _BuscaProdMp.set_frmRef(Me) : _BuscaProdMp.ShowDialog(Me)
                        If Me.txt_codprod.Text.Equals("") Then Me.txt_codprod.Focus()

                        txt_nomeProd.Focus() : txt_nomeProd.SelectAll()
                        txt_codprod.Text = codProd_Ref : txt_nomeProd.Text = nomeProd_Ref
                        txt_valorunit.Text = Format(ValorUnitProd_Ref, "###,##0.00")
                        lbl_qtdFisc.Text = Format(qtdFiscProd_Ref, "###,##0.00")
                    Catch ex As Exception
                    End Try
                End If


            End If
        End If



    End Sub

    Private Sub cbo_local_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_local.GotFocus

        If Not (Me.cbo_local.DroppedDown) Then Me.cbo_local.DroppedDown = True

    End Sub

    Private Sub cbo_local_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_local.Leave

        lbl_mensagem.Text = ""
        If Me.cbo_local.SelectedIndex < _valorZERO Then

            lbl_mensagem.Text = "Informe o local da entrada do Mapa !"
            Return
        End If


    End Sub

    Private Sub cbo_local_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_local.SelectedIndexChanged

        local_Ref = cbo_local.Text

    End Sub

    Private Sub txt_codprod_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codprod.KeyPress
        'permite só numeros sem ponto e sem virgula
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_qtde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_qtde.GotFocus

        txt_qtde.SelectAll()

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

    Private Sub txt_qtde_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtde.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_valorunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_valorunit.GotFocus

        txt_valorunit.SelectAll()

    End Sub

    Private Sub txt_valorunit_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valorunit.Leave

        lbl_mensagem.Text = ""
        If Me.txt_valorunit.Text.Equals("") Then Me.txt_valorunit.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valorunit.Text) Then

            If CDec(Me.txt_valorunit.Text) <= _valorZERO Then

                lbl_mensagem.Text = "Valor Unitário deve ser maior que ZERO !"
                Return

            End If
            Me.txt_valorunit.Text = Format(CDec(Me.txt_valorunit.Text), "###,##0.00")

        End If



    End Sub

    Private Sub txt_valorunit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valorunit.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub executaF3()

        Try
            If Not dtg_mapa.CurrentRow.IsNewRow Then

                _qtdeAnterior = dtg_mapa.CurrentRow.Cells(2).Value
                _CodProdEditando = dtg_mapa.CurrentRow.Cells(_valorZERO).Value
                Me._indexProdEditando = dtg_mapa.CurrentRow.Index
                Me.txt_codprod.Text = dtg_mapa.CurrentRow.Cells(_valorZERO).Value
                Me.txt_nomeProd.Text = dtg_mapa.CurrentRow.Cells(1).Value
                Me.txt_qtde.Text = dtg_mapa.CurrentRow.Cells(2).Value
                Me.txt_valorunit.Text = dtg_mapa.CurrentRow.Cells(3).Value
                trazItenBD(txt_codprod.Text)
                txt_codprod.Focus() : txt_codprod.SelectAll()


            End If

        Catch ex As Exception
        End Try



    End Sub

    Private Sub Btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_alterar.Click

        executaF3()

    End Sub

    Private Sub zeraValoresItem()

        txt_codprod.Text = "" : txt_nomeProd.Text = ""
        txt_qtde.Text = "0,00" : txt_valorunit.Text = "0,00"
        lbl_mensagem.Text = "" : lbl_qtdFisc.Text = "0,00"

    End Sub

    Private Sub DeleteItemGrid()

        Try

            If Me.dtg_mapa.Enabled = True Then
                'Remove Linha
                Dim codigoProduto As String = dtg_mapa.CurrentRow.Cells(0).Value
                Dim qtdeProduto As Double = dtg_mapa.CurrentRow.Cells(2).Value

                Me.dtg_mapa.Rows.Remove(Me.dtg_mapa.CurrentRow)
                Me.dtg_mapa.Refresh()
                Me.txt_vltotalMp.Text = Format(somaVlrTotalItensGrid, "###,##0.00")
                If dtg_mapa.Rows.Count <= _valorZERO Then zeraValoresItem()


                Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Dim transacao As NpgsqlTransaction

                conection.Open()
                transacao = conection.BeginTransaction
                _clBD.somaQtdeProdEstloja(codigoProduto, cbo_local.Text, qtdeProduto, conection, transacao)
                If _indexProdEditando >= _valorZERO Then
                    _indexProdEditando = -1 : _CodProdEditando = ""
                    lbl_qtdFisc.Text = Format(_clBD.pegaQtdeEstoque(codigoProduto, cbo_local.Text, conection), "###,##0.00")

                End If
                transacao.Commit() : conection.ClearPool() : conection.Close()
                conection = Nothing

            End If

        Catch ex As Exception
            MsgBox("Deu ERRO ao Deletar este Item " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try



    End Sub

    Private Sub devolveQtdeEstloja01()

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim codigoProduto As String = ""
        Dim qtdeProduto As Double = _valorZERO
        Try

            conection.Open()
            transacao = conection.BeginTransaction
            For Each row As DataGridViewRow In Me.dtg_mapa.Rows

                If Not row.IsNewRow Then
                    codigoProduto = row.Cells(0).Value
                    qtdeProduto = row.Cells(2).Value
                    _clBD.somaQtdeProdEstloja(codigoProduto, cbo_local.SelectedItem, qtdeProduto, conection, transacao)

                End If
            Next

            transacao.Commit() : conection.ClearPool()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
        Finally

            If conection.State = ConnectionState.Open Then conection.Close()
            transacao = Nothing : conection = Nothing : codigoProduto = Nothing : qtdeProduto = Nothing

        End Try



    End Sub

    Private Sub dtg_mapa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtg_mapa.KeyDown

        Select Case e.KeyCode
            Case Keys.Delete
                If MessageBox.Show("Deseja realmente Deletar esse Item?", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.DeleteItemGrid()
                End If

            Case Keys.F2
                If Not dtg_mapa.CurrentRow.IsNewRow Then
                    _qtdeAnterior = dtg_mapa.CurrentRow.Cells(2).Value
                    Me._indexProdEditando = dtg_mapa.CurrentRow.Index
                    Me._CodProdEditando = dtg_mapa.CurrentRow.Cells(_valorZERO).Value
                    Me.txt_codprod.Text = dtg_mapa.CurrentRow.Cells(_valorZERO).Value
                    Me.txt_nomeProd.Text = dtg_mapa.CurrentRow.Cells(1).Value
                    Me.txt_qtde.Text = dtg_mapa.CurrentRow.Cells(2).Value
                    Me.txt_valorunit.Text = dtg_mapa.CurrentRow.Cells(3).Value
                    trazItenBD(txt_codprod.Text)

                End If

        End Select



    End Sub

    Private Sub executaF4()

        If Me.dtg_mapa.Rows.Count > _valorZERO Then
            If MessageBox.Show("Deseja realmente Deletar esse Item?", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Me.DeleteItemGrid()

            End If
        End If



    End Sub

    Private Sub Btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_excluir.Click

        executaF4()

    End Sub

    Private Sub inclueMpRegistro(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim numMapa As String = Me.txt_numeroMp.Text, dtEmissao As Date = CDate(Me.msk_dtemisao.Text)
        Dim dtSaida As Date = CDate(Me.msk_dtsaida.Text), vlrTotalMapa As Double = CDbl(Me.txt_vltotalMp.Text)
        Dim local As String = cbo_local.SelectedItem, idVeic As Int32 = _valorZERO
        Dim placaVeic As String = ""

        Dim marray As Array = Split(cbo_placaVeic.SelectedItem, "|")
        idVeic = Convert.ToInt32(Trim(marray(0).ToString))
        placaVeic = Trim(marray(1).ToString)

        _clBD.incMapa1pp(conexao, transacao, numMapa, dtEmissao, dtSaida, vlrTotalMapa, local, idVeic, placaVeic)
        _clBD.incMapa1ppr(conexao, transacao, numMapa, dtEmissao, dtSaida, vlrTotalMapa, local, idVeic, placaVeic)
        numMapa = Nothing : dtEmissao = Nothing : dtSaida = Nothing : vlrTotalMapa = Nothing
        local = Nothing : idVeic = Nothing : placaVeic = Nothing

    End Sub

    Private Sub inclueMpItens(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mpId As Int32 = _valorZERO, numMapa As String = Me.txt_numeroMp.Text
        Dim cod As String = "", nome As String = "", und As String = ""
        Dim qtde As Double = _valorZERO, vlrUnit As Double = _valorZERO
        Dim vlrTotal As Double = _valorZERO, pesoBruto As Double = _valorZERO
        Dim pesoLiq As Double = _valorZERO, codBarra As String = ""
        Dim local As String = cbo_local.SelectedItem
        Dim mprId As Int32 = _valorZERO

        mpId = _clBD.trazIdMapa1pp(conexao, numMapa)
        mprId = _clBD.trazIdMapa1ppr(conexao, numMapa)

        For Each row As DataGridViewRow In Me.dtg_mapa.Rows
            If Not row.IsNewRow Then
                cod = row.Cells(0).Value
                nome = row.Cells(1).Value
                qtde = row.Cells(2).Value
                vlrUnit = row.Cells(3).Value
                vlrTotal = row.Cells(4).Value
                und = row.Cells(5).Value
                pesoBruto = row.Cells(6).Value
                pesoLiq = row.Cells(7).Value
                codBarra = row.Cells(8).Value

                _clBD.incMapa2cc(conexao, transacao, mpId, numMapa, cod, nome, und, qtde, vlrUnit, _
                                 vlrTotal, pesoBruto, pesoLiq, codBarra, local)
                _clBD.incMapa2ccr(conexao, transacao, mprId, numMapa, cod, nome, und, qtde, vlrUnit, _
                                                 vlrTotal, pesoBruto, pesoLiq, codBarra, local)

            End If
        Next

        mpId = Nothing : numMapa = Nothing : cod = Nothing : nome = Nothing : und = Nothing
        qtde = Nothing : vlrUnit = Nothing : vlrTotal = Nothing : pesoBruto = Nothing
        pesoLiq = Nothing : codBarra = Nothing : local = Nothing
        mprId = Nothing



    End Sub

    Private Function verifCamposRegMapa() As Boolean

        lbl_mensagem.Text = ""

        If cbo_local.SelectedIndex < _valorZERO Then
            lbl_mensagem.Text = "Selecione um Local por favor !"
            Return False

        End If

        If Not IsDate(msk_dtemisao.Text) Then
            lbl_mensagem.Text = "Data de emissão inválida !"
            msk_dtemisao.Focus()
            Return False

        End If

        If Not IsDate(msk_dtsaida.Text) Then
            lbl_mensagem.Text = "Data de Saída inválida !"
            msk_dtsaida.Focus()
            Return False

        End If

        If cbo_placaVeic.SelectedIndex < _valorZERO Then
            lbl_mensagem.Text = "Selecione um veículo Por Favor !"
            cbo_placaVeic.Focus()
            Return False

        End If



        Return True
    End Function

    Private Function inclueDtg_Mapa() As Boolean

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim tudoOK As Boolean = True

        Try
            conexao.Open()

            Try

                transacao = conexao.BeginTransaction
                inclueMpRegistro(conexao, transacao)
                inclueMpItens(conexao, transacao)
                transacao.Commit() : conexao.ClearAllPools()

            Catch ex As Exception
                Try
                    transacao.Rollback()
                    tudoOK = False
                Catch ex2 As Exception
                    tudoOK = False

                End Try
            End Try

        Catch ex As Exception
            tudoOK = False
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)

        Finally

            If conexao.State = ConnectionState.Open Then conexao.Close()
            conexao = Nothing : transacao = Nothing
        End Try



        Return tudoOK
    End Function

    Private Sub executaF7()

        If Me.dtg_mapa.Rows.Count > _valorZERO Then


            If MessageBox.Show("Deseja realmente Gravar esse Mapa?", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If verifCamposRegMapa() Then

                    If inclueDtg_Mapa() Then

                        MsgBox("Mapa Gravado com Sucesso", MsgBoxStyle.Exclamation)
                        btn_finalizar.Enabled = False
                        Me.Close()


                    End If
                End If
            End If
        End If



    End Sub

    Private Sub finalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalizar.Click

        executaF7()

    End Sub

    Private Sub txt_numeroMp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numeroMp.TextChanged

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        conection.Open()
        _clBD.updateGenp001CodMapa(conection, Convert.ToInt32(Me.txt_numeroMp.Text), MdlEmpresaUsu._codigo)
        conection.ClearPool() : conection.Close() : conection = Nothing

    End Sub

    Private Sub Frm_MapaPrevenda_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        'Depois que grava o Mapa no banco o btn_finalizar fica desabilitado, se tiver habilitado é pq não gravou ainda
        If btn_finalizar.Enabled = True Then

            If Me.dtg_mapa.RowCount > 0 Then

                If MessageBox.Show("Deseja realmente Sair? O Processo será Abortado!", "METROSYS", MessageBoxButtons.YesNo, _
                                   MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    devolveQtdeEstloja01()

                Else
                    e.Cancel = True

                End If
            End If
        End If

    End Sub


    Private Sub cbo_placaVeic_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_placaVeic.GotFocus

        If Not (Me.cbo_placaVeic.DroppedDown) Then Me.cbo_placaVeic.DroppedDown = True

    End Sub

End Class