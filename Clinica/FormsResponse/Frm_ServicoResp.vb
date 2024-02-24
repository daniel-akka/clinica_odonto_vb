Imports System.Text
Imports Npgsql

Public Class Frm_ServicoResp

    Private conexao As String = MdlConexaoBD.conectionPadrao
    Private Const _valorZERO As Integer = 0
    Dim _clFuncoes As New ClFuncoes
    Dim _objservico As New Cl_Servico

    'ultilizados para o DataGridView
    Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
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

    Private Sub preencheDtg_Servicos()

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdMunicipios As New NpgsqlCommand
        Dim sqlMunicipios As New StringBuilder
        Dim drMunicipios As NpgsqlDataReader


        Try

            sqlMunicipios.Append("SELECT s_id, s_descricao, s_valor FROM servico ") '3
            sqlMunicipios.Append("WHERE s_descricao LIKE @s_descricao ORDER BY s_descricao ASC")
            cmdMunicipios = New NpgsqlCommand(sqlMunicipios.ToString, oConn)
            cmdMunicipios.Parameters.Add("@s_descricao", Me.txt_pesquisa.Text & "%")
            drMunicipios = cmdMunicipios.ExecuteReader

            dtg_servicos.Rows.Clear()
            If drMunicipios.HasRows = False Then Return
            While drMunicipios.Read
                dtg_servicos.Rows.Add(drMunicipios(0), drMunicipios(1).ToString, Format(drMunicipios(2), "###,##0.00"))
            End While

            dtg_servicos.Refresh() : drMunicipios.Close()
            oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT dos SERVICOS:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmdMunicipios.CommandText = ""
        sqlMunicipios.Remove(0, sqlMunicipios.ToString.Length)

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmdMunicipios = Nothing
        sqlMunicipios = Nothing : drMunicipios = Nothing



    End Sub

    Private Sub Frm_buscaProdNFe_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If


    End Sub

    Sub PegarServico()

        Try
            'Se tiver Produto no GridView e não tiver selecionado algum...
            If dtg_servicos.CurrentRow.IsNewRow Then
                MsgBox("Selecione o registro desejado, por favor", MsgBoxStyle.Exclamation)
                Me.dtg_servicos.Focus()

            ElseIf dtg_servicos.Rows.Count < 1 Then
                MsgBox("Pesquise o registro desejado, por favor", MsgBoxStyle.Exclamation)
                Me.txt_pesquisa.Focus()

            Else
                _clFuncoes.trazServicoSelecionado(dtg_servicos.CurrentRow.Cells(0).Value, _objservico)
                _formRequest._frmREf._servico = _objservico
                _formRequest._frmREf.txt_codProd.BackColor = Color.White
                _formRequest._frmREf.txt_nomeProd.Text = dtg_servicos.CurrentRow.Cells(1).Value.ToString
                Me.Close()

            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub txt_pesquisa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        Select Case e.KeyCode
            Case Keys.Enter

                PegarServico()

            Case Keys.Down
                Me.dtg_servicos.Focus()

            Case Keys.Up
                Me.dtg_servicos.Focus()

            Case Keys.Escape
                _formRequest._frmREf.txt_nomeProd.Focus() : _formRequest._frmREf.Show() : Me.Close()

        End Select



    End Sub

    Private Sub dtg_servicos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtg_servicos.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                PegarServico()

        End Select



    End Sub

    Private Sub dtg_servicos_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_servicos.CellContentDoubleClick

        PegarServico()


    End Sub

    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click

        PegarServico()



    End Sub

    Private Sub Frm_buscaProdNFe_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Me.dtg_servicos.Rows.Clear() : Me.dtg_servicos.Refresh() : Me.txt_pesquisa.Text = ""

    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        preencheDtg_Servicos()

    End Sub

    Private Sub Frm_buscaProdNFeNFe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            loja = geno001.pCodig.Substring(geno001.pCodig.Length - 2, 2)
        Catch ex As Exception
        End Try

        preencheDtg_Servicos()
        Me.txt_pesquisa.Focus()
    End Sub

    Private Sub txt_pesquisa_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_pesquisa.KeyUp

        If e.KeyCode = Keys.Down Then dtg_servicos.Focus()

    End Sub

End Class