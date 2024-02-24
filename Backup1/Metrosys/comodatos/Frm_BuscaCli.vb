Imports System.Text
Imports Npgsql

Public Class Frm_BuscaCli
    Protected conexao As String = MdlConexaoBD.conectionPadrao
    Private Const _valorZERO As Integer = 0

    'ultilizados para o DataGridView
    Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(conexao)
    Dim CmdParticipante As New NpgsqlCommand
    Dim SqlParticipante As New StringBuilder
    Dim drParticipante As NpgsqlDataReader
    Public _formRequest As New Object


    Public Sub set_frmRef(ByRef frmRef As Form)

        _formRequest = frmRef

    End Sub

    Private Sub rdb_cnpj_cpf_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rdb_codigo.KeyDown, rdb_nome.KeyDown, rdb_cnpj_cpf.KeyDown

        If e.KeyCode = Keys.Escape Then

            _formRequest._frmREf.txt_nomePart.Focus() : _formRequest._frmREf.Show() : Me.Close()
        End If


    End Sub

    Private Sub txt_pesquisa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pesquisa.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                'Se tiver Cliente no GridView e não tiver selecionado algum...
                If ((Me.lbl_registros.Text \ 1) > _valorZERO) AndAlso (Dg_particpante.CurrentRow.IsNewRow) Then
                    MsgBox("Selecione o registro desejado, por favor", MsgBoxStyle.Exclamation)
                    Me.Dg_particpante.Focus()

                ElseIf (Me.lbl_registros.Text \ 1) <= _valorZERO Then
                    MsgBox("Pesquise o registro desejado, por favor", MsgBoxStyle.Exclamation)

                Else
                    _formRequest._frmREf.txt_codPart.Text = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
                    _formRequest._frmREf.txt_codPart.BackColor = Color.White
                    _formRequest._frmREf.txt_nomePart.Text = Me.Dg_particpante.CurrentRow.Cells(1).Value.ToString
                    _formRequest._frmREf.txt_nomePart.Focus() : _formRequest._frmREf.Show() : Me.Close()

                End If


            Case Keys.Down
                Me.Dg_particpante.Focus()

            Case Keys.Up
                Me.Dg_particpante.Focus()

            Case Keys.Escape
                _formRequest._frmREf.txt_nomePart.Focus() : _formRequest._frmREf.Show() : Me.Close()

        End Select



    End Sub

    Private Sub rdb_cnpj_cpf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_nome.CheckedChanged, rdb_codigo.CheckedChanged, rdb_cnpj_cpf.CheckedChanged

        If rdb_cnpj_cpf.Checked = True Then

            Me.lbl_pesquisa.Text = "CNPJ ou CPF:" : Me.txt_pesquisa.SetBounds(232, 63, 119, 23)
            Me.txt_pesquisa.MaxLength = 20 : Me.txt_pesquisa.Text = ""
        End If

        If rdb_codigo.Checked = True Then

            Me.lbl_pesquisa.Text = "CODIGO:" : Me.txt_pesquisa.SetBounds(200, 63, 65, 23)
            Me.txt_pesquisa.MaxLength = 7 : Me.txt_pesquisa.Text = ""
        End If

        If rdb_nome.Checked = True Then

            Me.lbl_pesquisa.Text = "NOME:" : Me.txt_pesquisa.SetBounds(188, 63, 400, 23)
            Me.txt_pesquisa.MaxLength = 65 : Me.txt_pesquisa.Text = ""
        End If



    End Sub

    Private Sub txt_pesquisa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pesquisa.KeyPress

        If rdb_cnpj_cpf.Checked = True Then
            'permite só numeros
            If Char.IsLetter(e.KeyChar) Then e.Handled = True

        End If

        If rdb_nome.Checked = True Then
            'permite só letras
            If Char.IsNumber(e.KeyChar) Then e.Handled = True

        End If



    End Sub

    Private Sub Frm_BuscaCli_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                _formRequest._frmREf.txt_nomePart.Focus() : _formRequest._frmREf.Show() : Me.Close()

            Case Keys.P
                If Me.txt_pesquisa.Focus() = False Then Me.txt_pesquisa.Focus() : Me.txt_pesquisa.SelectAll()

            Case Keys.K
                If (Me.btn_confirmar.Focus = False) AndAlso (Me.txt_pesquisa.Focus = False) Then Me.btn_confirmar.Focus()

        End Select



    End Sub

    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click

        'Se tiver Cliente no GridView e não tiver selecionado algum...
        If ((Me.lbl_registros.Text \ 1) > _valorZERO) AndAlso (Dg_particpante.CurrentRow.IsNewRow) Then
            MsgBox("Selecione o registro desejado, por favor", MsgBoxStyle.Exclamation)
            Me.Dg_particpante.Focus()

        ElseIf (Me.lbl_registros.Text \ 1) <= _valorZERO Then
            MsgBox("Pesquise o registro desejado, por favor", MsgBoxStyle.Exclamation)
            Me.txt_pesquisa.Focus()

        Else
            _formRequest._frmREf.txt_codPart.Text = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
            _formRequest._frmREf.txt_codPart.BackColor = Color.White
            _formRequest._frmREf.txt_nomePart.Text = Me.Dg_particpante.CurrentRow.Cells(1).Value.ToString
            _formRequest._frmREf.txt_nomePart.Focus() : _formRequest._frmREf.Show() : Me.Close()

        End If



    End Sub

    Private Sub preencheDgrd_Participante(ByVal pesquisa As String)

        Dim nomeCampo As String = "", nomeCampoCgc As String = "", nomeCampoCpf As String = ""

        If Me.rdb_cnpj_cpf.Checked = True Then
            nomeCampoCgc = "p_cgc" : nomeCampoCpf = "p_cpf"

        ElseIf Me.rdb_codigo.Checked = True Then
            nomeCampo = "p_cod"

        Else
            nomeCampo = "p_portad"

        End If


        Try
            If oConnBDMETROSYS.State = ConnectionState.Closed Then oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        If oConnBDMETROSYS.State = ConnectionState.Open Then
            Dim codigo, nome, cpf_cnpj, inscricao, UF, endereco, cidade, cep, fone As String

            Try
                SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc, p_uf, p_end, p_cid, ") ' 7
                SqlParticipante.Append("p_cep, p_fone FROM cadp001 WHERE p_inativo = FALSE ") ' 9

                If Not nomeCampoCpf.Equals("") Then 'se for CPF ou CNPJ, entao...
                    SqlParticipante.Append("AND " & nomeCampoCgc & " LIKE '" & pesquisa & "%' OR " & nomeCampoCpf)
                    SqlParticipante.Append(" LIKE '" & pesquisa & "%'")

                Else
                    If rdb_codigo.Checked = True Then
                        SqlParticipante.Append("AND UPPER(" & nomeCampo & ") LIKE '" & pesquisa.ToUpper & "%' ORDER BY p_cod ASC")

                    Else
                        SqlParticipante.Append("AND UPPER(" & nomeCampo & ") LIKE '" & pesquisa.ToUpper & "%' ORDER BY p_portad ASC")

                    End If

                End If

                CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDMETROSYS)
                drParticipante = CmdParticipante.ExecuteReader
                Dg_particpante.Rows.Clear()

                While drParticipante.Read
                    codigo = drParticipante(0).ToString : nome = drParticipante(1).ToString

                    If Not drParticipante(2).ToString.Equals("") Then 'se tiver CNPJ...
                        cpf_cnpj = drParticipante(2).ToString

                    Else
                        cpf_cnpj = drParticipante(3).ToString

                    End If

                    inscricao = drParticipante(4).ToString : UF = drParticipante(5).ToString
                    endereco = drParticipante(6).ToString : cidade = drParticipante(7).ToString
                    cep = drParticipante(8).ToString : fone = drParticipante(9).ToString


                    Dg_particpante.Rows.Add(codigo, nome, cpf_cnpj, inscricao, UF, cidade, endereco, _
                                            cep, fone)

                End While

                Dg_particpante.Refresh()
                Me.lbl_registros.Text = Me.Dg_particpante.Rows.Count
                drParticipante.Close() : oConnBDMETROSYS.ClearPool()

            Catch ex As Exception
                MsgBox("ERRO no SELECT do CLIENTES:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            CmdParticipante.CommandText = ""
            SqlParticipante.Remove(0, SqlParticipante.ToString.Length)

            'Limpa Objetos da Memória...
            codigo = Nothing : nome = Nothing : cpf_cnpj = Nothing : inscricao = Nothing : UF = Nothing
            endereco = Nothing : cidade = Nothing : cep = Nothing : fone = Nothing
        End If



    End Sub

    Private Sub Frm_BuscaCli_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub Dg_particpante_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg_particpante.CellContentDoubleClick

        If Dg_particpante.CurrentRow.IsNewRow = False Then

            _formRequest._frmREf.txt_codPart.Text = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
            _formRequest._frmREf.txt_codPart.BackColor = Color.White
            _formRequest._frmREf.txt_nomePart.Text = Me.Dg_particpante.CurrentRow.Cells(1).Value.ToString
            _formRequest._frmREf.txt_nomePart.Focus() : _formRequest._frmREf.Show() : Me.Close()

        End If
        

    End Sub

    Private Sub dgrd_particpante_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dg_particpante.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter

                If Dg_particpante.CurrentRow.IsNewRow = False Then

                    _formRequest._frmREf.txt_codPart.Text = Me.Dg_particpante.CurrentRow.Cells(0).Value.ToString
                    _formRequest._frmREf.txt_codPart.BackColor = Color.White
                    _formRequest._frmREf.txt_nomePart.Text = Me.Dg_particpante.CurrentRow.Cells(1).Value.ToString
                    _formRequest._frmREf.txt_nomePart.Focus() : _formRequest._frmREf.Show() : Me.Close()

                End If

        End Select



    End Sub

    Private Sub Frm_BuscaCli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Dg_particpante.Rows.Clear() : Me.Dg_particpante.Refresh() : Me.txt_pesquisa.Text = ""
        If Me.rdb_cnpj_cpf.Checked = True Then Me.rdb_cnpj_cpf.Focus()
        If Me.rdb_codigo.Checked = True Then Me.rdb_codigo.Focus()
        If Me.rdb_nome.Checked = True Then Me.rdb_nome.Focus()


    End Sub

    Private Sub Frm_BuscaCli_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Me.Dg_particpante.Rows.Clear() : Me.Dg_particpante.Refresh() : Me.txt_pesquisa.Text = ""
        Me.lbl_registros.Text = "0"
        If Me.rdb_cnpj_cpf.Checked = True Then Me.rdb_cnpj_cpf.Focus()
        If Me.rdb_codigo.Checked = True Then Me.rdb_codigo.Focus()
        If Me.rdb_nome.Checked = True Then Me.rdb_nome.Focus()


    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        Me.preencheDgrd_Participante(Me.txt_pesquisa.Text)

    End Sub

End Class