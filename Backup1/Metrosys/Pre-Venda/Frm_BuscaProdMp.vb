Imports System.Text
Imports Npgsql

Public Class Frm_BuscaProdMp
    Private conexao As String = MdlConexaoBD.conectionPadrao

    'ultilizados para o DataGridView
    Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)
    Dim CmdProduto As New NpgsqlCommand
    Dim SqlProduto As New StringBuilder
    Dim drProduto As NpgsqlDataReader
    Public _formRequest As New Object
    Dim codigoProduto, nomeProduto, fornecedorProduto, qtdEstoqueProduto, undMedidaProduto As String
    Dim ncmProduto, codBarraProduto, sldAtualProduto, custAntProduto, ClfProduto As String
    Dim pcoVendProduto, pesoBrutoProduto, pesoLiqProduto As Double
    Dim CstProduto, CfvProduto, GrupoProduto, ReduzProduto As Integer

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
                SqlProduto.Append("e.e_clf, e.e_pesobruto, e.e_pesoliq, e.e_cdbarra FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN estloja01 ") ' 16
                SqlProduto.Append("el ON e.e_codig = el.e_codig WHERE ")
                SqlProduto.Append("e.e_materiaprima = " & chk_matPrima.Checked & " AND ")
                SqlProduto.Append("el.e_loja = '" & _formRequest._frmREf.local_Ref & "' AND ")

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

                    Dg_produto.Rows.Add(codigoProduto, nomeProduto, fornecedorProduto, sldAtualProduto, _
                                        undMedidaProduto, ncmProduto, CstProduto, CfvProduto, GrupoProduto, _
                                        ReduzProduto, qtdEstoqueProduto, custAntProduto, pcoVendProduto, ClfProduto, _
                                        pesoBrutoProduto, pesoLiqProduto, codBarraProduto)
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

                    Try
                        'Set os objetos do formulário do Mapa...
                        _formRequest._frmREf.codProd_Ref = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                        _formRequest._frmREf.nomeProd_Ref = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                        _formRequest._frmREf.UndProd_Ref = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
                        _formRequest._frmREf.CstProd_Ref = Me.Dg_produto.CurrentRow.Cells(6).Value.ToString
                        _formRequest._frmREf.CfvProd_Ref = Me.Dg_produto.CurrentRow.Cells(7).Value.ToString
                        _formRequest._frmREf.GrupoProd_Ref = Me.Dg_produto.CurrentRow.Cells(8).Value.ToString
                        _formRequest._frmREf.ReduzProd_Ref = Me.Dg_produto.CurrentRow.Cells(9).Value.ToString
                        _formRequest._frmREf.qtdFiscProd_Ref = Me.Dg_produto.CurrentRow.Cells(3).Value.ToString
                        _formRequest._frmREf.ValorUnitProd_Ref = Me.Dg_produto.CurrentRow.Cells(12).Value.ToString
                        _formRequest._frmREf.ClfProd_Ref = Me.Dg_produto.CurrentRow.Cells(13).Value.ToString
                        _formRequest._frmREf.pesoBrutoProd_Ref = Me.Dg_produto.CurrentRow.Cells(14).Value.ToString
                        _formRequest._frmREf.pesoLiqProd_Ref = Me.Dg_produto.CurrentRow.Cells(15).Value.ToString
                        _formRequest._frmREf.codBarraProd_Ref = Me.Dg_produto.CurrentRow.Cells(16).Value.ToString

                    Catch ex As Exception

                        'Se deu erro é por que não é o formulário do Mapa...
                        'Faz o tratamento do formulário de Requisição
                        _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                        _formRequest._frmREf.txt_codProd.BackColor = Color.White
                        _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                        _formRequest._frmREf.txt_nomeProd.Focus()
                        Try
                            _formRequest._frmREf._qtdFisc = Me.Dg_produto.CurrentRow.Cells(3).Value.ToString
                        Catch ex1 As Exception
                        End Try


                    End Try
                    _formRequest._frmREf.Show()
                    Me.Close()


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

    Private Sub Dg_produto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dg_produto.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter

                Try
                    'Set os objetos do formulário do Mapa...
                    _formRequest._frmREf.codProd_Ref = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                    _formRequest._frmREf.nomeProd_Ref = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                    _formRequest._frmREf.UndProd_Ref = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
                    _formRequest._frmREf.CstProd_Ref = Me.Dg_produto.CurrentRow.Cells(6).Value.ToString
                    _formRequest._frmREf.CfvProd_Ref = Me.Dg_produto.CurrentRow.Cells(7).Value.ToString
                    _formRequest._frmREf.GrupoProd_Ref = Me.Dg_produto.CurrentRow.Cells(8).Value.ToString
                    _formRequest._frmREf.ReduzProd_Ref = Me.Dg_produto.CurrentRow.Cells(9).Value.ToString
                    _formRequest._frmREf.qtdFiscProd_Ref = Me.Dg_produto.CurrentRow.Cells(3).Value.ToString
                    _formRequest._frmREf.ValorUnitProd_Ref = Me.Dg_produto.CurrentRow.Cells(12).Value.ToString
                    _formRequest._frmREf.ClfProd_Ref = Me.Dg_produto.CurrentRow.Cells(13).Value.ToString
                    _formRequest._frmREf.pesoBrutoProd_Ref = Me.Dg_produto.CurrentRow.Cells(14).Value.ToString
                    _formRequest._frmREf.pesoLiqProd_Ref = Me.Dg_produto.CurrentRow.Cells(15).Value.ToString
                    _formRequest._frmREf.codBarraProd_Ref = Me.Dg_produto.CurrentRow.Cells(16).Value.ToString

                Catch ex As Exception

                    'Se deu erro é por que não é o formulário do Mapa...
                    'Faz o tratamento do formulário de Requisição
                    _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                    _formRequest._frmREf.txt_codProd.BackColor = Color.White
                    _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                    _formRequest._frmREf.txt_nomeProd.Focus()
                    Try
                        _formRequest._frmREf._qtdFisc = Me.Dg_produto.CurrentRow.Cells(3).Value.ToString
                    Catch ex1 As Exception
                    End Try

                End Try
                _formRequest._frmREf.Show()
                Me.Close()

        End Select



    End Sub

    Private Sub Dg_produto_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg_produto.CellContentDoubleClick

        If Not Dg_produto.CurrentRow.IsNewRow Then

            Try
                'Set os objetos do formulário do Mapa...
                _formRequest._frmREf.codProd_Ref = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                _formRequest._frmREf.nomeProd_Ref = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                _formRequest._frmREf.UndProd_Ref = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
                _formRequest._frmREf.CstProd_Ref = Me.Dg_produto.CurrentRow.Cells(6).Value.ToString
                _formRequest._frmREf.CfvProd_Ref = Me.Dg_produto.CurrentRow.Cells(7).Value.ToString
                _formRequest._frmREf.GrupoProd_Ref = Me.Dg_produto.CurrentRow.Cells(8).Value.ToString
                _formRequest._frmREf.ReduzProd_Ref = Me.Dg_produto.CurrentRow.Cells(9).Value.ToString
                _formRequest._frmREf.qtdFiscProd_Ref = Me.Dg_produto.CurrentRow.Cells(3).Value.ToString
                _formRequest._frmREf.ValorUnitProd_Ref = Me.Dg_produto.CurrentRow.Cells(12).Value.ToString
                _formRequest._frmREf.ClfProd_Ref = Me.Dg_produto.CurrentRow.Cells(13).Value.ToString
                _formRequest._frmREf.pesoBrutoProd_Ref = Me.Dg_produto.CurrentRow.Cells(14).Value.ToString
                _formRequest._frmREf.pesoLiqProd_Ref = Me.Dg_produto.CurrentRow.Cells(15).Value.ToString
                _formRequest._frmREf.codBarraProd_Ref = Me.Dg_produto.CurrentRow.Cells(16).Value.ToString

            Catch ex As Exception

                'Se deu erro é por que não é o formulário do Mapa...
                'Faz o tratamento do formulário de Requisição
                _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                _formRequest._frmREf.txt_codProd.BackColor = Color.White
                _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                _formRequest._frmREf.txt_nomeProd.Focus()
                Try
                    _formRequest._frmREf._qtdFisc = Me.Dg_produto.CurrentRow.Cells(3).Value.ToString
                Catch ex1 As Exception
                End Try

            End Try
            _formRequest._frmREf.Show()
            Me.Close()

        End If



    End Sub

    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click

        If Not Dg_produto.CurrentRow.IsNewRow Then

            Try
                'Set os objetos do formulário do Mapa...
                _formRequest._frmREf.codProd_Ref = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                _formRequest._frmREf.nomeProd_Ref = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                _formRequest._frmREf.UndProd_Ref = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
                _formRequest._frmREf.CstProd_Ref = Me.Dg_produto.CurrentRow.Cells(6).Value.ToString
                _formRequest._frmREf.CfvProd_Ref = Me.Dg_produto.CurrentRow.Cells(7).Value.ToString
                _formRequest._frmREf.GrupoProd_Ref = Me.Dg_produto.CurrentRow.Cells(8).Value.ToString
                _formRequest._frmREf.ReduzProd_Ref = Me.Dg_produto.CurrentRow.Cells(9).Value.ToString
                _formRequest._frmREf.qtdFiscProd_Ref = Me.Dg_produto.CurrentRow.Cells(3).Value.ToString
                _formRequest._frmREf.ValorUnitProd_Ref = Me.Dg_produto.CurrentRow.Cells(12).Value.ToString
                _formRequest._frmREf.ClfProd_Ref = Me.Dg_produto.CurrentRow.Cells(13).Value.ToString
                _formRequest._frmREf.pesoBrutoProd_Ref = Me.Dg_produto.CurrentRow.Cells(14).Value.ToString
                _formRequest._frmREf.pesoLiqProd_Ref = Me.Dg_produto.CurrentRow.Cells(15).Value.ToString
                _formRequest._frmREf.codBarraProd_Ref = Me.Dg_produto.CurrentRow.Cells(16).Value.ToString

            Catch ex As Exception

                'Se deu erro é por que não é o formulário do Mapa...
                'Faz o tratamento do formulário de Requisição
                _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                _formRequest._frmREf.txt_codProd.BackColor = Color.White
                _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                _formRequest._frmREf.txt_nomeProd.Focus()
                Try
                    'Se deu erro é por que é um Formulário que precisa so do código e nome
                    _formRequest._frmREf._qtdFisc = Me.Dg_produto.CurrentRow.Cells(3).Value.ToString
                Catch ex1 As Exception
                End Try

            End Try
            _formRequest._frmREf.Show()
            Me.Close()

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

End Class