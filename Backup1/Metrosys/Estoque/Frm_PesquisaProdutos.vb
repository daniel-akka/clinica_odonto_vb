Imports Npgsql
Imports System.Text
Imports System.Data
Imports System.DateTime
Imports System.Math

Public Class Frm_PesquisaProdutos


    Private Const _valorZERO As Integer = 0
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Dim _Produto As New Cl_Est0001
    Private _tip As ToolTip = Nothing
    Dim _msgErroCelula As String = ""
    Private _local As String = Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2)

    'ultilizados para o DataGridView
    Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Private da As NpgsqlDataAdapter
    Private ds As New DataSet
    Dim CmdProduto As New NpgsqlCommand
    Dim SqlProduto As New StringBuilder
    Dim drProduto As NpgsqlDataReader



    Private Sub Frm_PesquisaProdutos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown


        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                executeF5()
            
        End Select

    End Sub

    Private Sub executeF5()

        preencheDtg_Produto()
    End Sub

    Private Sub Frm_PesquisaProdutos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Try

            Me.dtg_produto.Rows.Clear()
            Me.dtg_produto.Refresh()
            preencheDtg_Produto()
            Me.txt_pesquisa.Focus()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub preencheDtg_Produto()
        Dim nomeCampo As String = ""

        Dim pesquisa As String = (Me.txt_pesquisa.Text).ToUpper
        Me.lbl_mensagem01.Text = ".  "

        If Me.rdb_barra.Checked = True Then
            nomeCampo = "e_cdbarra"
        ElseIf Me.Rdb_codigo.Checked = True Then
            nomeCampo = "e_codig"
        Else
            nomeCampo = "e_produt"
        End If

        Try

            If oConnBDMETROSYS.State = ConnectionState.Closed Then oConnBDMETROSYS.Open()
        Catch ex As Exception
            Me.lbl_mensagem01.Text = "Erro:: " & ex.Message & " !"
        End Try

        If oConnBDMETROSYS.State = ConnectionState.Open Then
            Dim codigo, nome, fornecedor, qtdEstoque, undMedida, ncmProd As String
            Dim sldAtual, pcoAnt, custAnt, CLF, prvenda As String
            Dim CST, CFV, GRUPO, REDUZ As Integer

            Try

                SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, el.e_qtde, e.e_und, e.e_ncm, ") ' 5
                SqlProduto.Append("e.e_cst, e.e_cfv, e.e_grupo, e.e_reduz, el.e_qtdfisc, el.e_pcusto, el.e_pcomp, ") ' 12
                SqlProduto.Append("e.e_clf, el.e_pvenda FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN ")
                SqlProduto.Append("estloja01 el ON e.e_codig = el.e_codig WHERE ")
                SqlProduto.Append("e.e_materiaprima = " & Me.chk_MPrima.Checked & " AND ")
                SqlProduto.Append("el.e_loja = '" & _local & "' AND ")
                If Me.rdb_barra.Checked = True Then
                    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE @pesquisa ORDER BY e.e_produt ASC")
                ElseIf Rdb_codigo.Checked = True Then
                    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE @pesquisa ORDER BY e.e_produt ASC")
                Else
                    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE @pesquisa ORDER BY e.e_produt ASC")
                End If


                CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDMETROSYS)

                If Me.rdb_barra.Checked = True Then
                    CmdProduto.Parameters.Add("@pesquisa", pesquisa & "%")
                ElseIf Rdb_codigo.Checked = True Then
                    CmdProduto.Parameters.Add("@pesquisa", "%" & pesquisa)
                Else
                    CmdProduto.Parameters.Add("@pesquisa", pesquisa & "%")
                End If


                da = New NpgsqlDataAdapter(SqlProduto.ToString, oConnBDMETROSYS)
                drProduto = CmdProduto.ExecuteReader
                dtg_produto.Rows.Clear()
                While drProduto.Read

                    codigo = drProduto(0).ToString
                    nome = drProduto(1).ToString
                    fornecedor = drProduto(2).ToString
                    Try
                        qtdEstoque = drProduto(3)
                    Catch ex As Exception
                        qtdEstoque = "0,00"
                    End Try

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
                    prvenda = drProduto(14).ToString

                    dtg_produto.Rows.Add(codigo, nome, Format(CDbl(qtdEstoque), "###,##0.00"), undMedida, _
                                        Format(CDbl(prvenda), "###,##0.00"), fornecedor, ncmProd, _
                                        CST, CFV, GRUPO, REDUZ, sldAtual, custAnt, pcoAnt, CLF)

                End While

                drProduto.Close()
                ds.Clear()
            Catch ex As Exception
                Me.lbl_mensagem01.Text = "Erro:: " & ex.Message & " !"
            End Try

            CmdProduto.CommandText = ""
            SqlProduto.Remove(0, SqlProduto.ToString.Length)
            ds.Clear()
            da.Dispose()
            oConnBDMETROSYS.ClearPool()

        End If

    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged
        Me.preencheDtg_Produto()
    End Sub

End Class