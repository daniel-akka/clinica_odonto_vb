Imports Npgsql
Imports System.Text

Public Class Frm_ConfigBD

    Private _clFuncoes As New ClFuncoes
    Private _caminhoArq As String = "\wged\MetroSys\configBD.sys"

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click
        'Dim transacao As NpgsqlTransaction
        Try
            Dim mConexao As String = ""
            mConexao = "Server=" & txt_serverBD.Text & ";"
            mConexao += "Port=" & txt_portBD.Text & ";"
            mConexao += "UserId=" & txt_userIdBD.Text & ";"
            mConexao += "Password=" & txt_passwordBD.Text & ";"
            mConexao += "Database=" & txt_dataBaseBD.Text & ""

            MdlConexaoBD.conectionPadrao = mConexao

            _clFuncoes.AlteraConfigBD(_caminhoArq, txt_serverBD.Text, txt_dataBaseBD.Text)
            'Dim conection As New NpgsqlConnection(ModuloConexaoBD.conectionPadrao)
            'If conection.State = ConnectionState.Closed Then conection.Open()
            'transacao = conection.BeginTransaction
            'salvarConfBD(conection, transacao, txt_serverBD.Text, txt_portBD.Text, txt_userIdBD.Text, _
            '             txt_passwordBD.Text, txt_dataBaseBD.Text)
            'transacao.Commit()

            MsgBox("Configurações salvadas", MsgBoxStyle.Exclamation)
            'conection.Close()
            'transacao = Nothing
            'conection = Nothing
            Me.Close()
        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                'transacao.Rollback()
            Catch ex1 As Exception
            End Try
        End Try


    End Sub

    Private Sub salvarConfBD(ByVal conection As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                             ByVal server As String, ByVal port As String, ByVal userID As String, _
                             ByVal password As String, ByVal dataBase As String)

        Dim resultadoLogin As Boolean = False
        Dim _sqlUsuario As New StringBuilder
        Dim _cmdUsuario As NpgsqlCommand
        Try
            If conection.State = ConnectionState.Open Then
                Try
                    _sqlUsuario.Append("UPDATE confbd SET bd_server = @bd_server, bd_port = @bd_port, ")
                    _sqlUsuario.Append("bd_userid = @bd_userid, bd_password = @bd_password, bd_database = ")
                    _sqlUsuario.Append("@bd_database")
                    _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                    _cmdUsuario.Parameters.Add("@bd_server", server)
                    _cmdUsuario.Parameters.Add("@bd_port", port)
                    _cmdUsuario.Parameters.Add("@bd_userid", userID)
                    _cmdUsuario.Parameters.Add("@bd_password", password)
                    _cmdUsuario.Parameters.Add("@bd_database", dataBase)

                    _cmdUsuario.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                    resultadoLogin = False
                End Try

                _cmdUsuario.CommandText = ""
                _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
            End If

        Catch ex_ As Exception
            MsgBox("ERRO:: " & ex_.Message, MsgBoxStyle.Critical)

        Finally
            _sqlUsuario = Nothing
            _cmdUsuario = Nothing
            conection = Nothing
        End Try

    End Sub

    Private Sub trazConfigBD()
        Dim resultadoLogin As Boolean = False
        Me.txt_serverBD.Text = _clFuncoes.trazIpServidorBD(_caminhoArq)
        Me.txt_dataBaseBD.Text = _clFuncoes.trazNomeBancoServidorBD(_caminhoArq)
        'Dim conection As New NpgsqlConnection(ModuloConexaoBD.conectionPadrao)
        'Dim _sqlUsuario As New StringBuilder
        'Dim _cmdUsuario As NpgsqlCommand
        'Dim _drUsuario As NpgsqlDataReader
        'Try
        '    If conection.State = ConnectionState.Closed Then conection.Open()

        '    If conection.State = ConnectionState.Open Then
        '        Try


        '            _sqlUsuario.Append("SELECT bd_server, bd_port, bd_userid, bd_password, bd_database FROM confbd")
        '            _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
        '            _drUsuario = _cmdUsuario.ExecuteReader

        '            While _drUsuario.Read
        '                txt_serverBD.Text = _drUsuario(0).ToString
        '                txt_portBD.Text = _drUsuario(1).ToString
        '                txt_userIdBD.Text = _drUsuario(2).ToString
        '                txt_passwordBD.Text = _drUsuario(3).ToString
        '                txt_dataBaseBD.Text = _drUsuario(4).ToString
        '            End While

        '        Catch ex As Exception
        '            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
        '            resultadoLogin = False
        '        End Try

        '        _cmdUsuario.CommandText = ""
        '        _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
        '    End If

        'Catch ex_ As Exception
        '    MsgBox("ERRO:: " & ex_.Message, MsgBoxStyle.Critical)

        'Finally
        '    _sqlUsuario = Nothing
        '    _cmdUsuario = Nothing
        '    _drUsuario = Nothing
        '    conection = Nothing
        'End Try

    End Sub

    Private Sub Frm_ConfigBD_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

        End Select
    End Sub

    Private Sub Frm_ConfigBD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        trazConfigBD()
    End Sub

    Private Sub Frm_ConfigBD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class