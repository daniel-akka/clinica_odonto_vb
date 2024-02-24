Imports System.Text
Imports Npgsql

Public Class Frm_buscaProdNFe

    Private conexao As String = MdlConexaoBD.conectionPadrao
    Private Const _valorZERO As Integer = 0


    'ultilizados para o DataGridView
    Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(conexao)
    Dim CmdProduto As New NpgsqlCommand
    Dim SqlProduto As New StringBuilder
    Dim drProduto As NpgsqlDataReader
    Public _formRequest As New Object
    Public geno001 As New Cl_Geno
    Dim loja As String = "" '2 digitos

    Public Sub set_frmRef(ByRef frmRef As Form)

        _formRequest = frmRef

    End Sub

    Public Sub set_Geno001Ref(ByRef geno As Cl_Geno)

        geno001 = geno

    End Sub

    Private Sub rdb_codigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rdb_nome.KeyDown, rdb_codigo.KeyDown, rdb_CodForn.KeyDown

        If e.KeyCode = Keys.Escape Then
            _formRequest._frmREf.txt_nomeProd.Focus() : _formRequest._frmREf.Show() : Me.Close()

        End If


    End Sub

    Private Sub Frm_buscaProdNFe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                _formRequest._frmREf.txt_nomeProd.Focus() : _formRequest._frmREf.Show() : Me.Close()

            Case Keys.P
                If Me.txt_pesquisa.Focus() = False Then Me.txt_pesquisa.Focus() : Me.txt_pesquisa.SelectAll()

            Case Keys.K
                If Me.btn_confirmar.Focus = False And Me.txt_pesquisa.Focus = False Then Me.btn_confirmar.Focus()

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
            nomeCampo = "e_cdport"
        ElseIf Me.rdb_codigo.Checked = True Then
            nomeCampo = "e_codig"
        Else
            nomeCampo = "e_produt"
        End If

        Try
            If oConnBDMETROSYS.State = ConnectionState.Closed Then oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        If oConnBDMETROSYS.State = ConnectionState.Open Then
            Dim codigo, nome, fornecedor, qtdEstoque, undMedida, ncmProd As String
            Dim sldAtual, pcoAnt, custAnt, CLF As String
            Dim CST, CFV, GRUPO, REDUZ As Integer

            Try
                SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, e.e_qtdfisc, e.e_und, e.e_ncm, ") ' 5
                SqlProduto.Append("e.e_cst, e.e_cfv, e.e_grupo, e.e_reduz, el.e_qtdfisc, el.e_pcusto, el.e_pcomp, ") ' 12
                SqlProduto.Append("e.e_clf FROM " & geno001.pEsquemavinc & ".est0001 e JOIN estloja01 el ON e.e_codig = el.e_codig WHERE ")
                SqlProduto.Append("e.e_materiaprima = " & chk_matPrima.Checked & " AND ")
                SqlProduto.Append("el.e_loja = '" & loja & "' AND ")

                If Me.rdb_CodForn.Checked = True Then
                    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE '" & pesquisa.ToUpper & "%' ORDER BY e.e_produt ASC")

                ElseIf rdb_codigo.Checked = True Then
                    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE '" & pesquisa.ToUpper & "%' ORDER BY e.e_produt ASC")

                Else
                    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE '" & pesquisa.ToUpper & "%' ORDER BY e.e_produt ASC")

                End If

                CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDMETROSYS)
                drProduto = CmdProduto.ExecuteReader : Dg_produto.Rows.Clear()

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
                    pcoAnt = drProduto(12).ToString
                    CLF = drProduto(13).ToString
                    Dg_produto.Rows.Add(codigo, nome, fornecedor, qtdEstoque, undMedida, ncmProd, _
                                        CST, CFV, GRUPO, REDUZ, sldAtual, custAnt, pcoAnt, CLF)

                End While

                Dg_produto.Refresh() : drProduto.Close() : oConnBDMETROSYS.ClearPool()
                Me.lbl_registros.Text = Me.Dg_produto.Rows.Count

            Catch ex As Exception
                MsgBox("ERRO no SELECT dos PRODUTOS:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            End Try

            CmdProduto.CommandText = "" : SqlProduto.Remove(0, SqlProduto.ToString.Length)

            'Limpa Objetos da Memória...
            codigo = Nothing : nome = Nothing : fornecedor = Nothing : qtdEstoque = Nothing
            undMedida = Nothing : ncmProd = Nothing : sldAtual = Nothing : pcoAnt = Nothing
            custAnt = Nothing : CLF = Nothing : CST = Nothing : CFV = Nothing : GRUPO = Nothing : REDUZ = Nothing

        End If



    End Sub

    Private Sub Frm_buscaProdNFe_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If


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
                    _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                    _formRequest._frmREf.txt_codProd.BackColor = Color.White
                    _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                    Me.Close()

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
                _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
                _formRequest._frmREf.txt_codProd.BackColor = Color.White
                _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
                Me.Close()

        End Select



    End Sub

    Private Sub Dg_produto_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg_produto.CellContentDoubleClick

        _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
        _formRequest._frmREf.txt_codProd.BackColor = Color.White
        _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
        Me.Close()


    End Sub

    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click

        'Se tiver Produto no GridView e não tiver selecionado algum...
        If ((Me.lbl_registros.Text \ 1) > _valorZERO) AndAlso (Dg_produto.CurrentRow.IsNewRow) Then
            MsgBox("Selecione o registro desejado, por favor", MsgBoxStyle.Exclamation)
            Me.Dg_produto.Focus()

        ElseIf (Me.lbl_registros.Text \ 1) <= _valorZERO Then
            MsgBox("Pesquise o registro desejado, por favor", MsgBoxStyle.Exclamation)

        Else
            _formRequest._frmREf.txt_codProd.Text = Me.Dg_produto.CurrentRow.Cells(0).Value.ToString
            _formRequest._frmREf.txt_codProd.BackColor = Color.White
            _formRequest._frmREf.txt_nomeProd.Text = Me.Dg_produto.CurrentRow.Cells(1).Value.ToString
            Me.Close()

        End If



    End Sub

    Private Sub Frm_buscaProdNFe_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Me.Dg_produto.Rows.Clear() : Me.Dg_produto.Refresh() : Me.txt_pesquisa.Text = ""
        If Me.rdb_codigo.Checked = True Then Me.rdb_codigo.Focus()
        If Me.rdb_nome.Checked = True Then Me.rdb_nome.Focus()
        If Me.rdb_CodForn.Checked = True Then Me.rdb_CodForn.Focus()


    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        preencheDgrd_Produto(Me.txt_pesquisa.Text)

    End Sub

    Private Sub txt_pesquisa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pesquisa.KeyPress

        If rdb_codigo.Checked = True Then
            'permite só numeros
            If Char.IsLetter(e.KeyChar) Then e.Handled = True

        End If


    End Sub

    Private Sub chk_matPrima_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_matPrima.CheckedChanged

        Me.preencheDgrd_Produto(Me.txt_pesquisa.Text)

    End Sub

    Private Sub Frm_buscaProdNFeNFe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            loja = geno001.pCodig.Substring(geno001.pCodig.Length - 2, 2)
        Catch ex As Exception
        End Try

    End Sub
End Class