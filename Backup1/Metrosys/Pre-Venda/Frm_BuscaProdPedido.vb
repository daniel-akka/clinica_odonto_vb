Imports System.Text
Imports Npgsql

Public Class Frm_BuscaProdPedido
    Private conexao As String = MdlConexaoBD.conectionPadrao
    Dim _clFunc As New ClFuncoes

    'ultilizados para o DataGridView
    Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)
    Dim CmdProduto As New NpgsqlCommand
    Dim SqlProduto As New StringBuilder
    Dim drProduto As NpgsqlDataReader
    Public _formRequest As New Object
    Dim codigoProduto, nomeProduto, fornecedorProduto, qtdEstoqueProduto, undMedidaProduto As String
    Dim ncmProduto, codBarraProduto, sldAtualProduto, custAntProduto, ClfProduto, GradeProduto As String
    Dim pcoVendProduto, pesoBrutoProduto, pesoLiqProduto As Double
    Dim CstProduto, CfvProduto, GrupoProduto, ReduzProduto, LinhaProduto As Integer
    Dim mdtiniciopromocao, mdtfinalpromocao As String
    Dim mvlpromocao As Double

    Public Sub set_frmRef(ByRef frmRef As Form)
        _formRequest = frmRef
    End Sub

    Private Sub rdb_codigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rdb_nome.KeyDown, rdb_codigo.KeyDown, rdb_CodForn.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}") 'Envia o comando da tecla TAB

        End If

        If e.KeyCode = Keys.Escape Then
            _formRequest._frmREf.txt_nomeProd.Focus()
            _formRequest._frmREf.Show()
            Me.Close()

        End If


    End Sub

    Private Sub Frm_buscaProd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                _formRequest._frmREf.txt_nomeProd.Focus()
                _formRequest._frmREf.Show()
                Me.Close()

            Case Keys.P
                If Me.txt_pesquisa.Focus() = False Then
                    Me.txt_pesquisa.Focus()
                    Me.txt_pesquisa.SelectAll()

                End If

            Case Keys.K
                If Me.btn_confirmar.Focus = False And Me.txt_pesquisa.Focus = False Then Me.btn_confirmar.Focus()

        End Select


    End Sub

    Private Sub rdb_codigo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_nome.CheckedChanged, rdb_codigo.CheckedChanged, rdb_CodForn.CheckedChanged

        ' Altera o tamanho e posicionamento do TextBox da pesquisa, de acordo com o Rdb_button selecionado
        If rdb_codigo.Checked = True Then
            Me.lbl_pesquisa.Text = "CODIGO:"
            Me.txt_pesquisa.SetBounds(202, 66, 69, 23)
            Me.txt_pesquisa.MaxLength = 7
            Me.txt_pesquisa.Text = ""

        End If

        If rdb_nome.Checked = True Then
            Me.lbl_pesquisa.Text = "NOME:"
            Me.txt_pesquisa.SetBounds(188, 63, 290, 23)
            Me.txt_pesquisa.MaxLength = 50
            Me.txt_pesquisa.Text = ""

        End If

        If rdb_CodForn.Checked = True Then
            Me.lbl_pesquisa.Text = "CODIGO FORNECEDOR:"
            Me.txt_pesquisa.SetBounds(290, 63, 100, 23)
            Me.txt_pesquisa.MaxLength = 12
            Me.txt_pesquisa.Text = ""

        End If


    End Sub

    Private Sub preencheDgrd_Produto(ByVal pesquisa As String)

        'Objeto usado para o nome do Campo da tabela cadp001 no Banco de Dados
        Dim nomeCampo As String = ""

        'Modifica o nome do campo da tabela cadp001 a ser pesquisado de acordo com o rdb_button selecionado
        nomeCampo = "e_produt"
        If Me.rdb_CodForn.Checked = True Then
            nomeCampo = "e_cdport"
        ElseIf Me.rdb_codigo.Checked = True Then
            nomeCampo = "e_codig"
        End If

        Try
            If oConnBDGENOV.State = ConnectionState.Closed Then oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        If oConnBDGENOV.State = ConnectionState.Open Then

            Try
                SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, e.e_qtde, e.e_und, e.e_ncm, ") ' 5
                SqlProduto.Append("e.e_cst, e.e_cfv, e.e_grupo, e.e_reduz, el.e_qtde, el.e_pcusto, el.e_pvenda, ") ' 12
                SqlProduto.Append("e.e_clf, e.e_pesobruto, e.e_pesoliq, e.e_cdbarra, e.e_linha, e.e_grade, ") ' 18
                SqlProduto.Append("e.e_dtinicialpromocao, e.e_dtfinalpromocao, e_quotapromocao ") ' 21
                SqlProduto.Append("FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN estloja01 ")
                SqlProduto.Append("el ON e.e_codig = el.e_codig WHERE ")
                SqlProduto.Append("e.e_materiaprima = " & chk_matPrima.Checked & " AND ")
                SqlProduto.Append("el.e_loja = '" & Mid(_formRequest._frmREf.local_Ref, 1, 2) & "' AND ")

                If Me.rdb_CodForn.Checked = True Then
                    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE '" & pesquisa.ToUpper & "%' ORDER BY e_produt ASC")
                ElseIf rdb_codigo.Checked = True Then
                    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE '" & pesquisa.ToUpper & "%' ORDER BY e_produt ASC")
                Else
                    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE '" & pesquisa.ToUpper & "%' ORDER BY e_produt ASC")
                End If

                CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDGENOV)
                drProduto = CmdProduto.ExecuteReader
                Dg_produto.Rows.Clear()

                While drProduto.Read
                    codigoProduto = drProduto(0).ToString
                    nomeProduto = drProduto(1).ToString
                    fornecedorProduto = drProduto(2).ToString
                    qtdEstoqueProduto = drProduto(10)
                    undMedidaProduto = drProduto(4).ToString
                    ncmProduto = drProduto(5).ToString
                    CstProduto = drProduto(6)
                    CfvProduto = drProduto(7)
                    GrupoProduto = drProduto(8)
                    ReduzProduto = drProduto(9)
                    sldAtualProduto = drProduto(10)
                    custAntProduto = drProduto(11).ToString
                    pcoVendProduto = drProduto(12).ToString
                    ClfProduto = drProduto(13).ToString
                    pesoBrutoProduto = drProduto(14)
                    pesoLiqProduto = drProduto(15)
                    codBarraProduto = drProduto(16).ToString
                    LinhaProduto = drProduto(17).ToString
                    GradeProduto = drProduto(18).ToString

                    mdtiniciopromocao = drProduto(19).ToString
                    mdtfinalpromocao = drProduto(20).ToString
                    mvlpromocao = drProduto(21)

                    Dg_produto.Rows.Add(codigoProduto, nomeProduto, fornecedorProduto, qtdEstoqueProduto, _
                                        undMedidaProduto, ncmProduto, CstProduto, CfvProduto, GrupoProduto, _
                                        ReduzProduto, sldAtualProduto, custAntProduto, pcoVendProduto, ClfProduto, _
                                        pesoBrutoProduto, pesoLiqProduto, codBarraProduto, LinhaProduto, GradeProduto, _
                                        mdtiniciopromocao, mdtfinalpromocao, mvlpromocao)
                End While

                Me.lbl_registros.Text = Me.Dg_produto.Rows.Count
                drProduto.Close() : oConnBDGENOV.ClearPool()


                'Limpa essa varáveis da memória...
                codigoProduto = Nothing : nomeProduto = Nothing : fornecedorProduto = Nothing : qtdEstoqueProduto = Nothing
                undMedidaProduto = Nothing : ncmProduto = Nothing : codBarraProduto = Nothing : sldAtualProduto = Nothing
                custAntProduto = Nothing : ClfProduto = Nothing : pcoVendProduto = Nothing : pesoBrutoProduto = Nothing
                pesoLiqProduto = Nothing : CstProduto = Nothing : CfvProduto = Nothing : GrupoProduto = Nothing : ReduzProduto = Nothing

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")

            End Try

            CmdProduto.CommandText = ""
            SqlProduto.Remove(0, SqlProduto.ToString.Length)
        End If


    End Sub

    Private Sub txt_pesquisa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pesquisa.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter

                If (Me.lbl_registros.Text \ 1) > 1 Then
                    MsgBox("Selecione o registro desejado, por favor!", MsgBoxStyle.Exclamation, "METROSYS")
                    Me.Dg_produto.Focus()

                ElseIf (Me.lbl_registros.Text \ 1) < 1 Then
                    MsgBox("Pesquise o registro desejado, por favor!", MsgBoxStyle.Exclamation, "METROSYS")

                Else

                    If Not lbl_loja.Text.Equals("") Then setObjetosFormRef()

                End If

            Case Keys.Down
                Me.Dg_produto.Focus()
            Case Keys.Up
                Me.Dg_produto.Focus()
            Case Keys.Escape
                _formRequest._frmREf.txt_nomeProd.Focus()
                _formRequest._frmREf.Show()
                Me.Close()

        End Select



    End Sub

    Private Sub setObjetosFormRef()

        Try
            'Set os objetos do formulário do Mapa...
            _formRequest._frmREf.codProd_Ref = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
            _formRequest._frmREf.nomeProd_Ref = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
            _formRequest._frmREf.UndProd_Ref = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
            _formRequest._frmREf.CstProd_Ref = Me.Dg_produto.CurrentRow.Cells(6).Value.ToString
            _formRequest._frmREf.CfvProd_Ref = Me.Dg_produto.CurrentRow.Cells(7).Value.ToString
            _formRequest._frmREf.GrupoProd_Ref = Me.Dg_produto.CurrentRow.Cells(8).Value.ToString
            _formRequest._frmREf.ReduzProd_Ref = Me.Dg_produto.CurrentRow.Cells(9).Value.ToString
            '_formRequest._frmREf.qtdeProd_Ref = Me.Dg_produto.CurrentRow.Cells(3).Value.ToString
            '_formRequest._frmREf.ValorUnitProd_Ref = Me.Dg_produto.CurrentRow.Cells(12).Value.ToString
            _formRequest._frmREf.ClfProd_Ref = Me.Dg_produto.CurrentRow.Cells(13).Value.ToString
            _formRequest._frmREf.pesoBrutoProd_Ref = Me.Dg_produto.CurrentRow.Cells(14).Value.ToString
            _formRequest._frmREf.pesoLiqProd_Ref = Me.Dg_produto.CurrentRow.Cells(15).Value.ToString
            _formRequest._frmREf.cdBarraProd_Ref = Me.Dg_produto.CurrentRow.Cells(16).Value.ToString
            _formRequest._frmREf.LinhaProd_Ref = Me.Dg_produto.CurrentRow.Cells(17).Value.ToString
            _formRequest._frmREf.FilialProd_Ref = Me.lbl_loja.Text
            _formRequest._frmREf.qtdeProd_Ref = Me.lbl_qtde.Text
            _formRequest._frmREf.ValorUnitProd_Ref = Me.lbl_pcoVenda.Text


            _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
            _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
            _formRequest._frmREf.txt_nomeProd.Focus()

            'grade
            _formRequest._frmREf.gradeProd_Ref = Me.Dg_produto.CurrentRow.Cells(18).Value.ToString

            'Promoção...
            Try
                _formRequest._frmREf.dtInicialPromocao_Ref = Me.Dg_produto.CurrentRow.Cells(19).Value.ToString
            Catch ex As Exception
                _formRequest._frmREf.dtInicialPromocao_Ref = Nothing
            End Try
            Try
                _formRequest._frmREf.dtFinalPromocao_Ref = Me.Dg_produto.CurrentRow.Cells(20).Value.ToString
            Catch ex As Exception
                _formRequest._frmREf.dtFinalPromocao_Ref = Nothing
            End Try
            _formRequest._frmREf.vlPromocao_Ref = Me.Dg_produto.CurrentRow.Cells(21).Value.ToString

        Catch ex As Exception

        End Try
        _formRequest._frmREf.Show()
        Me.Close()


    End Sub

    Private Function trazIndexDtgSaldo(ByVal codLoja As String) As Integer

        Dim mindex As Integer = 0
        For Each row As DataGridViewRow In Me.dtg_saldos.Rows

            If Not row.IsNewRow Then

                If row.Cells(0).Value.ToString.Equals(codLoja) Then

                    mindex = row.Index : Exit For

                End If
            End If
        Next



        Return mindex
    End Function

    Private Sub Dg_produto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dg_produto.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter

                If Not lbl_loja.Text.Equals("") Then setObjetosFormRef()

        End Select



    End Sub

    Private Sub preencheDtg_Saldos(ByVal codProduto As String)

        If Dg_produto.CurrentRow.IsNewRow = False Then


            Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim daSaldos As NpgsqlDataAdapter
            Dim dsSaldos As New DataSet
            Dim cmdSaldos As New NpgsqlCommand
            Dim sqlSaldos As New StringBuilder
            Dim drSaldos As NpgsqlDataReader

            Try

                oConnBDMETROSYS.Open()
            Catch ex As Exception
                Return
            End Try

            Dim codigo, sldAtual, pcoVenda As String

            Try

                sqlSaldos.Append("SELECT el.e_loja, el.e_qtde, el.e_pvenda ")
                sqlSaldos.Append("FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN estloja01 el ON e.e_codig = el.e_codig WHERE ")
                sqlSaldos.Append("el.e_codig = @e_codig AND el.e_idvinculo = " & MdlEmpresaUsu._vinculo)
                CmdProduto = New NpgsqlCommand(sqlSaldos.ToString, oConnBDMETROSYS)

                CmdProduto.Parameters.Add("@e_codig", codProduto)

                daSaldos = New NpgsqlDataAdapter(sqlSaldos.ToString, oConnBDMETROSYS)
                drSaldos = CmdProduto.ExecuteReader
                dtg_saldos.Rows.Clear() : dtg_saldos.Refresh()
                While drSaldos.Read
                    codigo = drSaldos(0).ToString
                    sldAtual = drSaldos(1).ToString
                    pcoVenda = Format(drSaldos(2), "###,##0.00")

                    dtg_saldos.Rows.Add(codigo, sldAtual, pcoVenda)

                End While

                dtg_saldos.CurrentRow.Selected = False
                dtg_saldos.Rows(trazIndexDtgSaldo(_formRequest._frmREf.local_Ref)).Selected = True
                dtg_saldos.Refresh()
                setValoresSaldos()

                drSaldos.Close() : dsSaldos.Clear() : oConnBDMETROSYS.ClearPool()
            Catch ex As Exception
            End Try

            CmdProduto.CommandText = "" : sqlSaldos.Remove(0, sqlSaldos.ToString.Length)
            dsSaldos.Clear()

            'Limpa Objetos da Memória...
            oConnBDMETROSYS = Nothing : daSaldos = Nothing : dsSaldos = Nothing
            cmdSaldos = Nothing : sqlSaldos = Nothing : drSaldos = Nothing
            codigo = Nothing : sldAtual = Nothing : pcoVenda = Nothing

        End If



    End Sub

    Private Sub Dg_produto_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg_produto.CellContentDoubleClick

        If Not Dg_produto.CurrentRow.IsNewRow Then

           If Not lbl_loja.Text.Equals("") Then setObjetosFormRef()

        End If



    End Sub

    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click

        If Not Dg_produto.CurrentRow.IsNewRow Then

            If Not lbl_loja.Text.Equals("") Then setObjetosFormRef()

        Else
            MsgBox("Selecione o registro desejado, por favor!", MsgBoxStyle.Exclamation)
            Me.Dg_produto.Focus()

        End If



    End Sub

    Private Sub Frm_buscaProd_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Me.Dg_produto.Rows.Clear() : Me.Dg_produto.Refresh() : Me.txt_pesquisa.Text = ""
        If Me.rdb_codigo.Checked = True Then Me.rdb_codigo.Focus()
        If Me.rdb_nome.Checked = True Then Me.rdb_nome.Focus()
        If Me.rdb_CodForn.Checked = True Then Me.rdb_CodForn.Focus()

    End Sub

    Private Sub chk_matPrima_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_matPrima.CheckedChanged

        Me.preencheDgrd_Produto(Me.txt_pesquisa.Text)

    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        Me.preencheDgrd_Produto(Me.txt_pesquisa.Text)

    End Sub

    Private Sub Frm_BuscaProdMp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If


    End Sub

    Private Sub Dg_produto_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dg_produto.CellMouseClick

        Dim codProd As String = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
        preencheDtg_Saldos(codProd)
        codProd = Nothing

    End Sub

    Private Sub Dg_produto_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dg_produto.KeyUp

        Select Case e.KeyCode
            Case Keys.Up 'seta pra cima

                Try
                    Dim codProd As String = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                    preencheDtg_Saldos(codProd)
                    codProd = Nothing
                Catch ex As Exception
                End Try

            Case Keys.Down 'seta pra baixo

                Try
                    Dim codProd As String = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                    preencheDtg_Saldos(codProd)
                    codProd = Nothing
                Catch ex As Exception
                End Try

        End Select



    End Sub

    Private Sub setValoresSaldos()

        If dtg_saldos.CurrentRow.IsNewRow = False Then

            lbl_loja.Text = dtg_saldos.CurrentRow.Cells(0).Value
            lbl_qtde.Text = dtg_saldos.CurrentRow.Cells(1).Value
            lbl_pcoVenda.Text = dtg_saldos.CurrentRow.Cells(2).Value

        End If



    End Sub

    Private Sub dtg_saldos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtg_saldos.KeyUp

        Select Case e.KeyCode
            Case Keys.Up 'seta pra cima
                Try
                    setValoresSaldos()
                Catch ex As Exception
                End Try


            Case Keys.Down 'seta pra baixo
                Try
                    setValoresSaldos()
                Catch ex As Exception
                End Try


        End Select



    End Sub

    Private Sub dtg_saldos_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dtg_saldos.CellMouseClick

        setValoresSaldos()

    End Sub

    Private Sub Frm_BuscaProdPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_qtde.Text = "" : lbl_loja.Text = "" : lbl_pcoVenda.Text = ""

    End Sub

End Class