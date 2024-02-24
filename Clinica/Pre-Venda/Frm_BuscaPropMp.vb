Imports System.Text
Imports Npgsql

Public Class Frm_BuscaProdMp
    Private conexao As String = ModuloConexaoBD.conectionPadrao
    Private _erro As Boolean = False
    Private _msgErro As String = ""
    Private _contErros As Integer = 0

    'ultilizados para o DataGridView
    Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)
    Private da As NpgsqlDataAdapter
    Private ds As New DataSet
    Dim CmdProduto As New NpgsqlCommand
    Dim SqlProduto As New StringBuilder
    Dim drProduto As NpgsqlDataReader
    Public _formRequest As New Object

    Public Sub set_frmRef(ByRef frmRef As Form)
        _formRequest = frmRef
    End Sub

    Private Sub rdb_codigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rdb_nome.KeyDown, rdb_codigo.KeyDown, rdb_CodForn.KeyDown
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{TAB}")
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
                If Me.btn_confirmar.Focus = False And Me.txt_pesquisa.Focus = False Then
                    Me.btn_confirmar.Focus()
                End If

        End Select

    End Sub

    Private Sub rdb_codigo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_nome.CheckedChanged, rdb_codigo.CheckedChanged, rdb_CodForn.CheckedChanged
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

    Private Sub txt_pesquisa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pesquisa.KeyPress


        If e.KeyChar = Convert.ToChar(8) Then 'se for BackSpace
            Me.preencheDgrd_Produto("")
        ElseIf e.KeyChar <> Convert.ToChar(13) Then 'se for Enter
            Me.preencheDgrd_Produto(e.KeyChar.ToString)
        End If

        If Me.Dg_produto.Rows.Count > 0 Then Me.lbl_registros.Text = Me.Dg_produto.Rows.Count - 1

    End Sub

    Private Sub preencheDgrd_Produto(ByVal ultimChar As String)
        Dim nomeCampo As String = ""

        Dim pesquisa As String = (Me.txt_pesquisa.Text & ultimChar).ToUpper
        If ultimChar.Equals("") Then
            If Me.txt_pesquisa.Text.Length > 0 Then
                pesquisa = Me.txt_pesquisa.Text.Substring(0, Me.txt_pesquisa.Text.Length - 1).ToUpper
            Else
                Return
            End If
        End If

        If Me.rdb_CodForn.Checked = True Then
            nomeCampo = "e_cdport"
        ElseIf Me.rdb_codigo.Checked = True Then
            nomeCampo = "e_codig"
        Else
            nomeCampo = "e_produt"
        End If

        Try
            If oConnBDGENOV.State = ConnectionState.Closed Then
                oConnBDGENOV.Open()
            End If
        Catch ex As Exception

            Me._erro = True
            Me._msgErro = "Banco de Dados Inexistente!"
            Me._contErros += 1
        End Try

        If oConnBDGENOV.State = ConnectionState.Open Then
            Dim codigo, nome, fornecedor, qtdEstoque, undMedida, ncmProd, codBarra As String
            Dim sldAtual, custAnt, CLF As String
            Dim pcoVend, pesobruto, pesoliq As Double
            Dim CST, CFV, GRUPO, REDUZ As Integer

            Try
                SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, e.e_qtde, e.e_und, e.e_ncm, ") ' 5
                SqlProduto.Append("e.e_cst, e.e_cfv, e.e_grupo, e.e_reduz, el.e_qtdfisc, el.e_pcusto, el.e_pvenda, ") ' 12
                SqlProduto.Append("e.e_clf, e.e_pesobruto, e.e_pesoliq, e.e_cdbarra FROM est0001 e JOIN estloja01 el ON e.e_codig = el.e_codig WHERE ")
                SqlProduto.Append("el.e_loja = '" & _formRequest._frmREf.local_Ref & "' AND ")
                If Me.rdb_CodForn.Checked = True Then
                    SqlProduto.Append("UPPER(" & nomeCampo & ") LIKE '" & pesquisa & "%' ORDER BY e_produt ASC")
                ElseIf rdb_codigo.Checked = True Then
                    SqlProduto.Append("UPPER(" & nomeCampo & ") LIKE '" & pesquisa & "%' ORDER BY e_produt ASC")
                Else
                    SqlProduto.Append("UPPER(" & nomeCampo & ") LIKE '" & pesquisa & "%' ORDER BY e_produt ASC")
                End If

                CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDGENOV)
                da = New NpgsqlDataAdapter(SqlProduto.ToString, oConnBDGENOV)
                drProduto = CmdProduto.ExecuteReader

                Dg_produto.Rows.Clear()
                While drProduto.Read
                    codigo = drProduto(0).ToString
                    nome = drProduto(1).ToString
                    fornecedor = drProduto(2).ToString
                    qtdEstoque = drProduto(3).ToString
                    undMedida = drProduto(4).ToString
                    ncmProd = drProduto(5).ToString
                    CST = drProduto(6)
                    CFV = drProduto(7)
                    GRUPO = drProduto(8)
                    REDUZ = drProduto(9)
                    sldAtual = drProduto(10).ToString
                    custAnt = drProduto(11).ToString
                    pcoVend = drProduto(12).ToString
                    CLF = drProduto(13).ToString
                    pesobruto = drProduto(14)
                    pesoliq = drProduto(15)
                    codBarra = drProduto(16).ToString
                    Dg_produto.Rows.Add(codigo, nome, fornecedor, sldAtual, undMedida, ncmProd, _
                                        CST, CFV, GRUPO, REDUZ, qtdEstoque, custAnt, pcoVend, CLF, _
                                        pesobruto, pesoliq, codBarra)

                End While

                drProduto.Close()
                ds.Clear()
                Me._erro = False
            Catch ex As Exception
                Me._erro = True
                Me._msgErro = "Tabela de PRODUTOS Inexistente!"
                Me._contErros += 1
            End Try

            CmdProduto.CommandText = ""
            SqlProduto.Remove(0, SqlProduto.ToString.Length)
            ds.Clear()
            da.Dispose()
        End If

        If Me._contErros < 4 AndAlso Me._erro = True Then
            MsgBox(Me._msgErro, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Frm_buscaProd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Me.Dg_produto.Rows.Count > 0 Then Me.lbl_registros.Text = Me.Dg_produto.Rows.Count - 1

    End Sub

    Private Sub txt_pesquisa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pesquisa.KeyDown
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

        Select Case e.KeyCode
            Case Keys.Enter
                If (Me.lbl_registros.Text \ 1) > 1 Then
                    MsgBox("Selecione o registro desejado, por favor!", MsgBoxStyle.Exclamation, "GENOV")
                    Me.Dg_produto.Focus()
                ElseIf (Me.lbl_registros.Text \ 1) < 1 Then
                    MsgBox("Pesquise o registro desejado, por favor!", MsgBoxStyle.Exclamation, "GENOV")
                Else
                    Dim formRequest As New Form
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
                _formRequest._frmREf.Show()
                Me.Close()
        End Select
    End Sub

    Private Sub Dg_produto_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg_produto.CellContentDoubleClick
        If Not Dg_produto.CurrentRow.IsNewRow Then
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
            _formRequest._frmREf.Show()
            Me.Close()
        End If
        
    End Sub

    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click
        If (Me.lbl_registros.Text \ 1) > 1 Then
            If Not Dg_produto.CurrentRow.IsNewRow Then
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
                _formRequest._frmREf.Show()
                Me.Close()
            Else
                MsgBox("Selecione o registro desejado, por favor!", MsgBoxStyle.Exclamation)
                Me.Dg_produto.Focus()
            End If

        ElseIf (Me.lbl_registros.Text \ 1) < 1 Then
            MsgBox("Pesquise o registro desejado, por favor!", MsgBoxStyle.Exclamation)
            Me.txt_pesquisa.Focus()
        Else
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
            _formRequest._frmREf.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Frm_buscaProd_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dg_produto.Rows.Clear()
        Me.Dg_produto.Refresh()
        Me.txt_pesquisa.Text = ""
        If Me.rdb_codigo.Checked = True Then Me.rdb_codigo.Focus()
        If Me.rdb_nome.Checked = True Then Me.rdb_nome.Focus()
        If Me.rdb_CodForn.Checked = True Then Me.rdb_CodForn.Focus()

    End Sub

End Class