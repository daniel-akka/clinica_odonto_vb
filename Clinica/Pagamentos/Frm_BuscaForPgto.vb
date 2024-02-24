Imports System.Data
Imports System.IO
Imports System.Text
Imports Npgsql
Public Class Frm_BuscaForPgto

    Private linhaAtual As Integer = -1
    Private mcell As String
    Public Imcell As String
    Protected Const conexao As String = _
    "Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDGRHOTEL"

    Private Sub Btn_pesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_pesquisa.Click
        'texto que representará o valor da célula do grid
        Dim txt As String = Nothing

        'percorre linha por linha da grid
        For Each row As DataGridViewRow In Me.DtGdVw_manfornecedores.Rows

            ' percorre cada celula da linha
            For Each cell As DataGridViewCell In DtGdVw_manfornecedores.Rows(row.Index).Cells

                ' se a caixa de texto nao estiver vazia prossegue, caso não
                ' tira a seleção da linha do grid
                If Txt_pesquisa.Text <> "" Then

                    ' se for a primeira coluna, no caso a coluna nome
                    If cell.ColumnIndex = 1 Then

                        '    atribui a valor a variavel txt, passando tudo convertido para minusculo
                        txt = cell.Value.ToString.ToUpper
                        '  se essa variavel tiver caracteres que corresponde ao da pesquisa no texto,
                        ' tambem convertido para o minusculo
                        If txt.Contains(Txt_pesquisa.Text.ToUpper) Then
                            '  faz o teste para ver se o valor da celula comeca com o mesmo valor
                            '  da pesquisa, caso sim, seleciona a linha do grid
                            If txt.StartsWith(Txt_pesquisa.Text.ToUpper.Substring(0, Txt_pesquisa.Text.Length)) Then
                                Me.DtGdVw_manfornecedores.Rows(cell.RowIndex).Selected = True
                            End If
                        End If
                    End If
                Else
                    Me.DtGdVw_manfornecedores.Rows(cell.RowIndex).Selected = False
                End If
            Next
        Next
    End Sub

    Private Sub DtGdVw_manfornecedores_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DtGdVw_manfornecedores.CellContentClick

        Frm_CadPagamento.cadpagRef.CodForn = Me.DtGdVw_manfornecedores.CurrentRow.Cells(0).Value.ToString()
        linhaAtual = Convert.ToInt32(e.RowIndex.ToString())
        Frm_CadPagamento.cadpagRef.txt_pesquisa.Text = Me.DtGdVw_manfornecedores.CurrentRow.Cells(1).Value.ToString
        Frm_CadPagamento.cadpagRef.Show()
        Me.Close()
    End Sub

    Private Sub Frm_BuscaForPgto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New Npgsql.NpgsqlConnection(conexao)
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Sqlcomm.Append("Select f_codigo,f_fornecedor,f_cidade,f_bairro,f_fone,f_cpf_cnpj from Fornecedores order by f_fornecedor")
        Dim daF As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
        Dim dsF As DataSet = New DataSet()
        Try
            daF.Fill(dsF, "Fornecedores")
            conn.Open()
            ' adicionando colunas
            Me.DtGdVw_manfornecedores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.DtGdVw_manfornecedores.DataSource = dsF.Tables("Fornecedores").DefaultView

            conn.ClearPool() : conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
End Class