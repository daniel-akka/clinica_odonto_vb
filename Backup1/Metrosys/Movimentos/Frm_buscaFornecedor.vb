Imports System.Text
Imports Npgsql
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Frm_buscaFornecedor

    Protected conexao As String = MdlConexaoBD.conectionPadrao
    Private _erro As Boolean = False
    Private _msgErro As String = ""
    Private _contErros As Integer = 0

    'ultilizados para o DataGridView
    Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)
    Private da As NpgsqlDataAdapter
    Private ds As New DataSet
    Dim CmdParticipante As New NpgsqlCommand
    Dim SqlParticipante As New StringBuilder
    Dim drParticipante As NpgsqlDataReader
    Public _formRequest As New Object

    Public Sub set_frmRef(ByRef frmRef As Form)
        _formRequest = frmRef
    End Sub

    Private Sub rdb_cnpj_cpf_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rdb_codigo.KeyDown, rdb_nome.KeyDown, rdb_cnpj_cpf.KeyDown
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

        If e.KeyCode = Keys.Escape Then
            If _formRequest._frmREf._mPesquisaForn = False Then _formRequest._frmREf.txt_nomePart.Focus()
            _formRequest._frmREf.Show()
            Me.Close()

        End If
    End Sub

    Private Sub txt_pesquisa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pesquisa.KeyDown
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

        Select Case e.KeyCode
            Case Keys.Enter
                If (Me.lbl_registros.Text \ 1) > 1 Then
                    MsgBox("Selecione o registro desejado, por favor!", MsgBoxStyle.Exclamation)
                    Me.Dg_particpante.Focus()
                ElseIf (Me.lbl_registros.Text \ 1) < 1 Then
                    MsgBox("Pesquise o registro desejado, por favor!", MsgBoxStyle.Exclamation)
                Else
                    If _formRequest._frmREf._mPesquisaForn = False Then
                        _formRequest._frmREf.txt_codPart.Text = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
                        _formRequest._frmREf.txt_codPart.BackColor = Color.White
                        _formRequest._frmREf.txt_nomePart.Text = Me.Dg_particpante.CurrentRow.Cells(1).Value.ToString
                        _formRequest._frmREf.txt_nomePart.Focus()
                        _formRequest._frmREf.mbUf = Me.Dg_particpante.CurrentRow.Cells(4).Value.ToString
                        _formRequest._frmREf.mbCNPJ = Me.Dg_particpante.CurrentRow.Cells(2).Value.ToString
                        _formRequest._frmREf.mCodPart = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
                        _formRequest._frmREf.mNomePart = Me.Dg_particpante.CurrentRow.Cells(1).Value.ToString
                        _formRequest._frmREf.mEnderecoPart = Me.Dg_particpante.CurrentRow.Cells(5).Value.ToString
                        _formRequest._frmREf.mCidadePart = Me.Dg_particpante.CurrentRow.Cells(6).Value.ToString
                        _formRequest._frmREf.mCepPart = Me.Dg_particpante.CurrentRow.Cells(7).Value.ToString
                        _formRequest._frmREf.mFonePart = Me.Dg_particpante.CurrentRow.Cells(8).Value.ToString

                    Else
                        _formRequest._frmREf._mCodFonecedor = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
                    End If
                    _formRequest._frmREf.Show()
                    Me.Close()
                End If

            Case Keys.Down
                Me.Dg_particpante.Focus()
            Case Keys.Up
                Me.Dg_particpante.Focus()
            Case Keys.Escape
                If _formRequest._frmREf._mPesquisaForn = False Then _formRequest._frmREf.txt_nomePart.Focus()
                _formRequest._frmREf.Show()
                Me.Close()
        End Select

    End Sub

    Private Sub rdb_cnpj_cpf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_nome.CheckedChanged, rdb_codigo.CheckedChanged, rdb_cnpj_cpf.CheckedChanged
        If rdb_cnpj_cpf.Checked = True Then
            Me.lbl_pesquisa.Text = "CNPJ ou CPF:"
            Me.txt_pesquisa.SetBounds(232, 63, 119, 23)
            Me.txt_pesquisa.MaxLength = 20
            Me.txt_pesquisa.Text = ""
        End If

        If rdb_codigo.Checked = True Then
            Me.lbl_pesquisa.Text = "CODIGO:"
            Me.txt_pesquisa.SetBounds(200, 63, 65, 23)
            Me.txt_pesquisa.MaxLength = 7
            Me.txt_pesquisa.Text = ""
        End If

        If rdb_nome.Checked = True Then
            Me.lbl_pesquisa.Text = "NOME:"
            Me.txt_pesquisa.SetBounds(188, 63, 400, 23)
            Me.txt_pesquisa.MaxLength = 65
            Me.txt_pesquisa.Text = ""
        End If
    End Sub

    Private Sub txt_pesquisa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pesquisa.KeyPress

        If rdb_cnpj_cpf.Checked = True Then
            'permite só numeros
            If Char.IsLetter(e.KeyChar) Then
                e.Handled = True
            End If
        End If

        If rdb_nome.Checked = True Then
            'permite só letras
            If Char.IsNumber(e.KeyChar) Then
                e.Handled = True
            End If
        End If

        If e.KeyChar = Convert.ToChar(8) Then 'se for BackSpace
            Me.preencheDgrd_Participante("")
        ElseIf e.KeyChar <> Convert.ToChar(13) Then 'se for Enter
            Me.preencheDgrd_Participante(e.KeyChar.ToString)
        End If


    End Sub

    Private Sub Frm_buscaForn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If _formRequest._frmREf._mPesquisaForn = False Then _formRequest._frmREf.txt_nomePart.Focus()
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

    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click
        If (Me.lbl_registros.Text \ 1) > 1 Then
            MsgBox("Selecione o registro desejado, por favor!", MsgBoxStyle.Exclamation)
            Me.Dg_particpante.Focus()
        ElseIf (Me.lbl_registros.Text \ 1) < 1 Then
            MsgBox("Pesquise o registro desejado, por favor!", MsgBoxStyle.Exclamation)
            Me.txt_pesquisa.Focus()
        Else
            If _formRequest._frmREf._mPesquisaForn = False Then
                _formRequest._frmREf.txt_codPart.Text = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
                _formRequest._frmREf.txt_codPart.BackColor = Color.White
                _formRequest._frmREf.txt_nomePart.Text = Me.Dg_particpante.CurrentRow.Cells(1).Value.ToString
                _formRequest._frmREf.txt_nomePart.Focus()
                _formRequest._frmREf.mbUf = Me.Dg_particpante.CurrentRow.Cells(4).Value.ToString
                _formRequest._frmREf.mbCNPJ = Me.Dg_particpante.CurrentRow.Cells(2).Value.ToString
                _formRequest._frmREf.mCodPart = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
                _formRequest._frmREf.mNomePart = Me.Dg_particpante.CurrentRow.Cells(1).Value.ToString
                _formRequest._frmREf.mEnderecoPart = Me.Dg_particpante.CurrentRow.Cells(5).Value.ToString
                _formRequest._frmREf.mCidadePart = Me.Dg_particpante.CurrentRow.Cells(6).Value.ToString
                _formRequest._frmREf.mCepPart = Me.Dg_particpante.CurrentRow.Cells(7).Value.ToString
                _formRequest._frmREf.mFonePart = Me.Dg_particpante.CurrentRow.Cells(8).Value.ToString

            Else
                _formRequest._frmREf._mCodFonecedor = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
            End If
            _formRequest._frmREf.Show()
            Me.Close()
        End If
    End Sub

    Private Sub preencheDgrd_Participante(ByVal ultimChar As String)
        Dim nomeCampo As String = ""
        Dim nomeCampoCgc As String = ""
        Dim nomeCampoCpf As String = ""

        Dim pesquisa As String = (Me.txt_pesquisa.Text & ultimChar).ToUpper
        If ultimChar.Equals("") Then
            If Me.txt_pesquisa.Text.Length > 0 Then
                pesquisa = Me.txt_pesquisa.Text.Substring(0, Me.txt_pesquisa.Text.Length - 1).ToUpper
            Else
                Return
            End If
        End If

        If Me.rdb_cnpj_cpf.Checked = True Then
            nomeCampoCgc = "p_cgc"
            nomeCampoCpf = "p_cpf"
        ElseIf Me.rdb_codigo.Checked = True Then
            nomeCampo = "p_cod"
        Else
            nomeCampo = "p_portad"
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
            Dim codigo, nome, cpf_cnpj, inscricao, UF, endereco, cidade, cep, fone As String

            Try
                SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc, p_uf, p_end, p_cid, ") ' 7
                SqlParticipante.Append("p_cep, p_fone FROM cadp001 WHERE p_inativo = FALSE ") ' 9
                If Not nomeCampoCpf.Equals("") Then 'se for CPF ou CNPJ, entao...
                    SqlParticipante.Append("AND " & nomeCampoCgc & " LIKE '" & pesquisa & "%' OR " & nomeCampoCpf)
                    SqlParticipante.Append(" LIKE '" & pesquisa & "%'")
                Else
                    If rdb_codigo.Checked = True Then
                        SqlParticipante.Append("AND UPPER(" & nomeCampo & ") LIKE '" & pesquisa & "%' ORDER BY p_cod ASC")
                    Else
                        SqlParticipante.Append("AND UPPER(" & nomeCampo & ") LIKE '" & pesquisa & "%' ORDER BY p_portad ASC")
                    End If

                End If

                CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDGENOV)
                da = New NpgsqlDataAdapter(SqlParticipante.ToString, oConnBDGENOV)
                drParticipante = CmdParticipante.ExecuteReader

                Dg_particpante.Rows.Clear()
                While drParticipante.Read
                    codigo = drParticipante(0).ToString
                    nome = drParticipante(1).ToString
                    If Not drParticipante(2).ToString.Equals("") Then 'se tiver CNPJ...
                        cpf_cnpj = drParticipante(2).ToString
                    Else
                        cpf_cnpj = drParticipante(3).ToString
                    End If
                    inscricao = drParticipante(4).ToString
                    UF = drParticipante(5).ToString
                    endereco = drParticipante(6).ToString
                    cidade = drParticipante(7).ToString
                    cep = drParticipante(8).ToString
                    fone = drParticipante(9).ToString

                    Dg_particpante.Rows.Add(codigo, nome, cpf_cnpj, inscricao, UF, cidade, endereco, _
                                            cep, fone)

                End While

                drParticipante.Close() : oConnBDGENOV.ClearPool()
                ds.Clear()
                Me.lbl_registros.Text = Me.Dg_particpante.Rows.Count
                Me._erro = False
            Catch ex As Exception
                Me._erro = True
                Me._msgErro = "Tabela de CLIENTES Inexistente!"
                Me._contErros += 1
            End Try

            CmdParticipante.CommandText = ""
            SqlParticipante.Remove(0, SqlParticipante.ToString.Length)
            ds.Clear()
            da.Dispose()
        End If

        If Me._contErros < 4 AndAlso Me._erro = True Then
            MsgBox(Me._msgErro, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Dg_particpante_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg_particpante.CellContentDoubleClick

        If _formRequest._frmREf._mPesquisaForn = False Then
            _formRequest._frmREf.txt_codPart.Text = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
            _formRequest._frmREf.txt_codPart.BackColor = Color.White
            _formRequest._frmREf.txt_nomePart.Text = Me.Dg_particpante.CurrentRow.Cells(1).Value.ToString
            _formRequest._frmREf.txt_nomePart.Focus()
            _formRequest._frmREf.mbUf = Me.Dg_particpante.CurrentRow.Cells(4).Value.ToString
            _formRequest._frmREf.mbCNPJ = Me.Dg_particpante.CurrentRow.Cells(2).Value.ToString
            _formRequest._frmREf.mCodPart = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
            _formRequest._frmREf.mNomePart = Me.Dg_particpante.CurrentRow.Cells(1).Value.ToString
            _formRequest._frmREf.mEnderecoPart = Me.Dg_particpante.CurrentRow.Cells(5).Value.ToString
            _formRequest._frmREf.mCidadePart = Me.Dg_particpante.CurrentRow.Cells(6).Value.ToString
            _formRequest._frmREf.mCepPart = Me.Dg_particpante.CurrentRow.Cells(7).Value.ToString
            _formRequest._frmREf.mFonePart = Me.Dg_particpante.CurrentRow.Cells(8).Value.ToString

        Else
            _formRequest._frmREf._mCodFonecedor = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
        End If
        _formRequest._frmREf.Show()
        Me.Close()

    End Sub

    Private Sub dgrd_particpante_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dg_particpante.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If _formRequest._frmREf._mPesquisaForn = False Then
                    _formRequest._frmREf.txt_codPart.Text = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
                    _formRequest._frmREf.txt_codPart.BackColor = Color.White
                    _formRequest._frmREf.txt_nomePart.Text = Me.Dg_particpante.CurrentRow.Cells(1).Value.ToString
                    _formRequest._frmREf.txt_nomePart.Focus()
                    _formRequest._frmREf.mbUf = Me.Dg_particpante.CurrentRow.Cells(4).Value.ToString
                    _formRequest._frmREf.mbCNPJ = Me.Dg_particpante.CurrentRow.Cells(2).Value.ToString
                    _formRequest._frmREf.mCodPart = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
                    _formRequest._frmREf.mNomePart = Me.Dg_particpante.CurrentRow.Cells(1).Value.ToString
                    _formRequest._frmREf.mEnderecoPart = Me.Dg_particpante.CurrentRow.Cells(5).Value.ToString
                    _formRequest._frmREf.mCidadePart = Me.Dg_particpante.CurrentRow.Cells(6).Value.ToString
                    _formRequest._frmREf.mCepPart = Me.Dg_particpante.CurrentRow.Cells(7).Value.ToString
                    _formRequest._frmREf.mFonePart = Me.Dg_particpante.CurrentRow.Cells(8).Value.ToString

                Else
                    _formRequest._frmREf._mCodFonecedor = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
                End If
                _formRequest._frmREf.Show()
                Me.Close()
        End Select

    End Sub

    Private Sub Frm_buscaForn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TESTE
        Me.Dg_particpante.Rows.Clear()
        Me.Dg_particpante.Refresh()
        Me.txt_pesquisa.Text = ""
        If Me.rdb_cnpj_cpf.Checked = True Then Me.rdb_cnpj_cpf.Focus()
        If Me.rdb_codigo.Checked = True Then Me.rdb_codigo.Focus()
        If Me.rdb_nome.Checked = True Then Me.rdb_nome.Focus()

    End Sub

    Private Sub Dg_particpante_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg_particpante.CellContentClick

    End Sub

    Private Sub Frm_buscaForn_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dg_particpante.Rows.Clear()
        Me.Dg_particpante.Refresh()
        Me.txt_pesquisa.Text = ""
        If Me.rdb_cnpj_cpf.Checked = True Then Me.rdb_cnpj_cpf.Focus()
        If Me.rdb_codigo.Checked = True Then Me.rdb_codigo.Focus()
        If Me.rdb_nome.Checked = True Then Me.rdb_nome.Focus()

    End Sub
End Class