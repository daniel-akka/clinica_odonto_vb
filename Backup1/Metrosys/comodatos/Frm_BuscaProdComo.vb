Imports System.Text
Imports Npgsql

Public Class Frm_BuscaProdComo

    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes

    'ultilizados para o DataGridView
    Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Dim CmdProduto As New NpgsqlCommand
    Dim SqlProduto As New StringBuilder
    Dim drProduto As NpgsqlDataReader
    Public _formRequest As New Object

    Public Sub set_frmRef(ByRef frmRef As Form)

        _formRequest = frmRef

    End Sub

    Private Sub rdb_codigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rdb_nome.KeyDown, rdb_codigo.KeyDown, rdb_CodForn.KeyDown

        If e.KeyCode = Keys.Escape Then

            _formRequest._frmREf.txt_nomeProd.Focus() : _formRequest._frmREf.Show() : Me.Close()
        End If


    End Sub

    Private Sub Frm_BuscaProdComo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                _formRequest._frmREf.txt_nomeProd.Focus() : _formRequest._frmREf.Show() : Me.Close()

            Case Keys.P
                If Me.txt_pesquisa.Focus() = False Then Me.txt_pesquisa.Focus() : Me.txt_pesquisa.SelectAll()

            Case Keys.K
                If (Me.btn_confirmar.Focus = False) AndAlso (Me.txt_pesquisa.Focus = False) Then Me.btn_confirmar.Focus()

        End Select



    End Sub

    Private Sub rdb_codigo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_nome.CheckedChanged, rdb_codigo.CheckedChanged, rdb_CodForn.CheckedChanged

        If rdb_codigo.Checked = True Then
            Me.lbl_pesquisa.Text = "CODIGO:" : Me.txt_pesquisa.SetBounds(202, 66, 69, 23)
            Me.txt_pesquisa.MaxLength = 7 : Me.txt_pesquisa.Text = ""

        End If

        If rdb_nome.Checked = True Then
            Me.lbl_pesquisa.Text = "NOME:" : Me.txt_pesquisa.SetBounds(188, 63, 290, 23)
            Me.txt_pesquisa.MaxLength = 50 : Me.txt_pesquisa.Text = ""

        End If

        If rdb_CodForn.Checked = True Then
            Me.lbl_pesquisa.Text = "CODIGO FORNECEDOR:" : Me.txt_pesquisa.SetBounds(290, 63, 100, 23)
            Me.txt_pesquisa.MaxLength = 12 : Me.txt_pesquisa.Text = ""

        End If



    End Sub

    Private Sub preencheDgrd_Produto(ByVal pesquisa As String)

        Dim nomeCampo As String = ""

        If Me.rdb_CodForn.Checked = True Then
            nomeCampo = "im_cdport"

        ElseIf Me.rdb_codigo.Checked = True Then
            nomeCampo = "im_codprid"

        Else
            nomeCampo = "im_portad"

        End If


        Try
            If oConnBDMETROSYS.State = ConnectionState.Closed Then oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        If oConnBDMETROSYS.State = ConnectionState.Open Then
            Dim codigo, nome, fornecedor As String

            Try
                SqlProduto.Append("SELECT im_codprid, im_tipo, im_portad FROM " & MdlEmpresaUsu._esqVinc & ".cadimobilizado ") ' 5
                SqlProduto.Append("WHERE ")
                If Me.rdb_CodForn.Checked = True Then
                    SqlProduto.Append("UPPER(" & nomeCampo & ") LIKE '" & pesquisa.ToUpper & "%' ORDER BY im_portad ASC")

                ElseIf rdb_codigo.Checked = True Then
                    SqlProduto.Append("UPPER(CAST(" & nomeCampo & " AS TEXT)) LIKE '" & pesquisa.ToUpper & "%' ORDER BY im_portad ASC")

                Else
                    SqlProduto.Append("UPPER(" & nomeCampo & ") LIKE '" & pesquisa.ToUpper & "%' ORDER BY im_portad ASC")

                End If

                CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDMETROSYS)
                drProduto = CmdProduto.ExecuteReader
                Dg_produto.Rows.Clear()

                While drProduto.Read
                    codigo = drProduto(0).ToString

                    Select Case drProduto(1).ToString
                        Case "00"
                            nome = ""

                        Case "01"
                            nome = "Freezer"

                        Case "02"
                            nome = "Outros"

                        Case Else
                            nome = ""

                    End Select

                    fornecedor = drProduto(2).ToString : Dg_produto.Rows.Add(codigo, nome, fornecedor)
                End While

                Me.lbl_registros.Text = Me.Dg_produto.Rows.Count
                drProduto.Close() : Dg_produto.Refresh() : oConnBDMETROSYS.ClearPool()
                
            Catch ex As Exception
                MsgBox("ERRO no SELECT dos PRDUTOS:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            CmdProduto.CommandText = "" : SqlProduto.Remove(0, SqlProduto.ToString.Length)
            codigo = Nothing : nome = Nothing : fornecedor = Nothing
        End If



    End Sub

    Private Sub Frm_BuscaProdComo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then e.Handled = True : SendKeys.Send("{TAB}")

    End Sub

    Private Sub txt_pesquisa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pesquisa.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                'Se tiver Produto no GridView e não tiver selecionado algum...
                If ((Me.lbl_registros.Text \ 1) > _valorZERO) AndAlso (Dg_produto.CurrentRow.IsNewRow) Then
                    MsgBox("Selecione o registro desejado, por favor", MsgBoxStyle.Exclamation)
                    Me.Dg_produto.Focus()

                ElseIf (Me.lbl_registros.Text \ 1) <= _valorZERO Then
                    MsgBox("Pesquise o registro desejado, por favor", MsgBoxStyle.Exclamation)

                Else
                    If Dg_produto.CurrentRow.IsNewRow = False Then
                        _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                        _formRequest._frmREf.txt_codProd.BackColor = Color.White
                        _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                        _formRequest._frmREf.txt_nomeProd.Focus() : _formRequest._frmREf.Show() : Me.Close()

                    End If

                End If

            Case Keys.Down
                Me.Dg_produto.Focus()

            Case Keys.Up
                Me.Dg_produto.Focus()

            Case Keys.Escape
                _formRequest._frmREf.txt_nomeProd.Focus() : _formRequest._frmREf.Show() : Me.Close()

        End Select



    End Sub

    Private Sub Dg_produto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dg_produto.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter

                If Dg_produto.CurrentRow.IsNewRow = False Then
                    _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                    _formRequest._frmREf.txt_codProd.BackColor = Color.White
                    _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                    _formRequest._frmREf.txt_nomeProd.Focus() : _formRequest._frmREf.Show() : Me.Close()

                End If

        End Select



    End Sub

    Private Sub Dg_produto_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg_produto.CellContentDoubleClick

        If Dg_produto.CurrentRow.IsNewRow = False Then
            _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
            _formRequest._frmREf.txt_codProd.BackColor = Color.White
            _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
            _formRequest._frmREf.txt_nomeProd.Focus() : _formRequest._frmREf.Show() : Me.Close()

        End If


    End Sub

    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click

        'Se tiver Produto no GridView e não tiver selecionado algum...
        If ((Me.lbl_registros.Text \ 1) > _valorZERO) AndAlso (Dg_produto.CurrentRow.IsNewRow) Then
            MsgBox("Selecione o registro desejado, por favor", MsgBoxStyle.Exclamation)
            Me.Dg_produto.Focus()

        ElseIf (Me.lbl_registros.Text \ 1) <= _valorZERO Then
            MsgBox("Pesquise o registro desejado, por favor", MsgBoxStyle.Exclamation)

        Else
            If Dg_produto.CurrentRow.IsNewRow = False Then
                _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                _formRequest._frmREf.txt_codProd.BackColor = Color.White
                _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                _formRequest._frmREf.txt_nomeProd.Focus() : _formRequest._frmREf.Show() : Me.Close()

            End If

        End If



    End Sub

    Private Sub Frm_BuscaProdComo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Me.Dg_produto.Rows.Clear() : Me.Dg_produto.Refresh() : Me.txt_pesquisa.Text = ""
        Me.lbl_registros.Text = "0"
        If Me.rdb_codigo.Checked = True Then Me.rdb_codigo.Focus()
        If Me.rdb_nome.Checked = True Then Me.rdb_nome.Focus()
        If Me.rdb_CodForn.Checked = True Then Me.rdb_CodForn.Focus()


    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        Me.preencheDgrd_Produto(Me.txt_pesquisa.Text)

    End Sub

End Class