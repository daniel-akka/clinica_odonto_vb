Imports System.Text
Imports Npgsql

Public Class Frm_xmlBuscaProd
    Protected _conexao As String = MdlConexaoBD.conectionPadrao
    Private _erro As Boolean = False
    Private _msgErro As String = ""
    Private _contErros As Integer = 0

    'ultilizados para o DataGridView
    Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(_conexao)
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
            Frm_MenuCompras._frmREf.txt_xmNomeProd.Focus()
            Frm_MenuCompras._frmREf.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Frm_xmlBuscaProd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Frm_MenuCompras._frmREf.txt_xmNomeProd.Focus()
                Frm_MenuCompras._frmREf.Show()
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
            Dim codigo, nome, fornecedor, qtdEstoque, undMedida, ncmProd, CLF As String
            Dim CST, CFV, GRUPO, REDUZ As Integer

            Try
                SqlProduto.Append("SELECT e_codig, e_produt, e_cdport, e_qtdfisc, e_und, e_ncm, ") ' 5
                SqlProduto.Append("e_cst, e_cfv, e_grupo, e_reduz, e_clf FROM " & MdlEmpresaUsu._esqVinc & ".est0001 WHERE ") ' 10
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
                    CLF = drProduto(10).ToString
                    Dg_produto.Rows.Add(codigo, nome, fornecedor, qtdEstoque, undMedida, ncmProd, _
                                        CST, CFV, GRUPO, REDUZ, CLF)

                End While

                drProduto.Close() : ds.Clear() : oConnBDGENOV.ClearPool()
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

    Private Sub Frm_xmlBuscaProd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
                    Frm_MenuCompras._frmREf.txt_xmcodpr.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                    Frm_MenuCompras._frmREf.txt_xmcodpr.BackColor = Color.White
                    Frm_MenuCompras._frmREf.txt_xmNomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                    Frm_MenuCompras._frmREf.txt_xmundprod.Text = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
                    Frm_MenuCompras._frmREf.mbUndProd = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
                    Frm_MenuCompras._frmREf.txt_xmNomeProd.Focus()
                    Frm_MenuCompras._frmREf.mCstIten = Me.Dg_produto.CurrentRow.Cells(6).Value.ToString
                    Frm_MenuCompras._frmREf.mCfvIten = Me.Dg_produto.CurrentRow.Cells(7).Value.ToString
                    Frm_MenuCompras._frmREf.mGrupoIten = Me.Dg_produto.CurrentRow.Cells(8).Value.ToString
                    Frm_MenuCompras._frmREf.mReduzIten = Me.Dg_produto.CurrentRow.Cells(9).Value.ToString
                    Frm_MenuCompras._frmREf.mClfIten = Me.Dg_produto.CurrentRow.Cells(10).Value.ToString
                    Frm_MenuCompras._frmREf.Show()
                    Me.Close()
                End If

            Case Keys.Down
                Me.Dg_produto.Focus()
            Case Keys.Up
                Me.Dg_produto.Focus()
            Case Keys.Escape
                Frm_MenuCompras._frmREf.txt_xmNomeProd.Focus()
                Frm_MenuCompras._frmREf.Show()
                Me.Close()
        End Select

    End Sub

    Private Sub Dg_produto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dg_produto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Frm_MenuCompras._frmREf.txt_xmcodpr.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                Frm_MenuCompras._frmREf.txt_xmcodpr.BackColor = Color.White
                Frm_MenuCompras._frmREf.txt_xmNomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                Frm_MenuCompras._frmREf.txt_xmundprod.Text = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
                Frm_MenuCompras._frmREf.mbUndProd = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
                Frm_MenuCompras._frmREf.txt_xmNomeProd.Focus()
                Frm_MenuCompras._frmREf.mCstIten = Me.Dg_produto.CurrentRow.Cells(6).Value.ToString
                Frm_MenuCompras._frmREf.mCfvIten = Me.Dg_produto.CurrentRow.Cells(7).Value.ToString
                Frm_MenuCompras._frmREf.mGrupoIten = Me.Dg_produto.CurrentRow.Cells(8).Value.ToString
                Frm_MenuCompras._frmREf.mReduzIten = Me.Dg_produto.CurrentRow.Cells(9).Value.ToString
                Frm_MenuCompras._frmREf.mClfIten = Me.Dg_produto.CurrentRow.Cells(10).Value.ToString
                Frm_MenuCompras._frmREf.Show()
                Me.Close()
        End Select
    End Sub

    Private Sub Dg_produto_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg_produto.CellContentDoubleClick
        Frm_MenuCompras._frmREf.txt_xmcodpr.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
        Frm_MenuCompras._frmREf.txt_xmcodpr.BackColor = Color.White
        Frm_MenuCompras._frmREf.txt_xmNomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
        Frm_MenuCompras._frmREf.txt_xmundprod.Text = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
        Frm_MenuCompras._frmREf.mbUndProd = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
        Frm_MenuCompras._frmREf.txt_xmNomeProd.Focus()
        Frm_MenuCompras._frmREf.mCstIten = Me.Dg_produto.CurrentRow.Cells(6).Value.ToString
        Frm_MenuCompras._frmREf.mCfvIten = Me.Dg_produto.CurrentRow.Cells(7).Value.ToString
        Frm_MenuCompras._frmREf.mGrupoIten = Me.Dg_produto.CurrentRow.Cells(8).Value.ToString
        Frm_MenuCompras._frmREf.mReduzIten = Me.Dg_produto.CurrentRow.Cells(9).Value.ToString
        Frm_MenuCompras._frmREf.mClfIten = Me.Dg_produto.CurrentRow.Cells(10).Value.ToString
        Frm_MenuCompras._frmREf.Show()
        Me.Close()
    End Sub

    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click
        If (Me.lbl_registros.Text \ 1) > 1 Then
            MsgBox("Selecione o registro desejado, por favor!", MsgBoxStyle.Exclamation)
            Me.Dg_produto.Focus()
        ElseIf (Me.lbl_registros.Text \ 1) < 1 Then
            MsgBox("Pesquise o registro desejado, por favor!", MsgBoxStyle.Exclamation)
            Me.txt_pesquisa.Focus()
        Else
            Frm_MenuCompras._frmREf.txt_xmcodpr.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
            Frm_MenuCompras._frmREf.txt_xmcodpr.BackColor = Color.White
            Frm_MenuCompras._frmREf.txt_xmNomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
            Frm_MenuCompras._frmREf.txt_xmundprod.Text = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
            Frm_MenuCompras._frmREf.mbUndProd = Me.Dg_produto.CurrentRow.Cells(4).Value.ToString
            Frm_MenuCompras._frmREf.txt_xmNomeProd.Focus()
            Frm_MenuCompras._frmREf.mCstIten = Me.Dg_produto.CurrentRow.Cells(6).Value.ToString
            Frm_MenuCompras._frmREf.mCfvIten = Me.Dg_produto.CurrentRow.Cells(7).Value.ToString
            Frm_MenuCompras._frmREf.mGrupoIten = Me.Dg_produto.CurrentRow.Cells(8).Value.ToString
            Frm_MenuCompras._frmREf.mReduzIten = Me.Dg_produto.CurrentRow.Cells(9).Value.ToString
            Frm_MenuCompras._frmREf.mClfIten = Me.Dg_produto.CurrentRow.Cells(10).Value.ToString
            Frm_MenuCompras._frmREf.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Frm_xmlBuscaProd_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dg_produto.Rows.Clear()
        Me.Dg_produto.Refresh()
        Me.txt_pesquisa.Text = ""
        If Me.rdb_codigo.Checked = True Then Me.rdb_codigo.Focus()
        If Me.rdb_nome.Checked = True Then Me.rdb_nome.Focus()
        If Me.rdb_CodForn.Checked = True Then Me.rdb_CodForn.Focus()

    End Sub

End Class