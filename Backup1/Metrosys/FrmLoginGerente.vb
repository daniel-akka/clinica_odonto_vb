Imports Npgsql
Imports System.Text

Public Class FrmLoginGerente

    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private Const INT_mValorZERO As Integer = 0
    Private _loginOK As Boolean = False
    Public _formRequest As New Object


    Public Sub set_frmRef(ByRef frmRef As Form)

        _formRequest = frmRef
    End Sub

    Private Sub FrmLoginGerente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                _formRequest._frmRef._privilegioGerente = False
                Me.Close()
        End Select
    End Sub

    Private Sub FrmLoginGerente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click

        If txt_senhaUsuario.Text <> "" Then


            If validaLogin(Me.txt_loginUsuario.Text, Me.txt_senhaUsuario.Text) Then

                _loginOK = True
                Me.Close()
            Else

                MsgBox("Login Incorreto", MsgBoxStyle.Exclamation)
                Me.txt_loginUsuario.Focus()
                Me.txt_loginUsuario.SelectAll()
            End If

        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        _formRequest._frmRef._privilegioGerente = False
        Me.Close()
    End Sub

    Private Function validaLogin(ByVal login As String, ByVal mSenha As String) As Boolean

        Dim resultadoLogin As Boolean = False
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim _sqlUsuario As New StringBuilder
        Dim _cmdUsuario As NpgsqlCommand
        Dim _drUsuario As NpgsqlDataReader

        Try
            conection.Open()

            Try
                _sqlUsuario.Append("SELECT gr_privilegiolojas, gr_gerente FROM cadgerente WHERE gr_gerente = @gr_gerente AND ")
                _sqlUsuario.Append("gr_senha = @gr_senha")
                _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                _cmdUsuario.Parameters.Add("@gr_gerente", login)
                _cmdUsuario.Parameters.Add("@gr_senha", mSenha)
                _drUsuario = _cmdUsuario.ExecuteReader


                If _drUsuario.HasRows Then

                    resultadoLogin = True
                    _formRequest._frmRef._privilegioGerente = True

                    While _drUsuario.Read

                        _formRequest._frmRef._privilegioLojas = _drUsuario(0)
                        Try
                            _formRequest._frmRef._nomeGerente = _drUsuario(1).ToString
                        Catch ex As Exception
                        End Try
                    End While
                    _drUsuario.Close()

                Else

                    resultadoLogin = False
                    _formRequest._frmRef._privilegioGerente = False
                End If

                conection.ClearPool()

            Catch ex As Exception

                MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                resultadoLogin = False
            End Try

            conection.Close()
            _cmdUsuario.CommandText = ""
            _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)


        Catch ex_ As Exception
            MsgBox("ERRO:: " & ex_.Message, MsgBoxStyle.Critical)

        Finally
            _sqlUsuario = Nothing : _cmdUsuario = Nothing
            _drUsuario = Nothing : conection = Nothing

        End Try



        Return resultadoLogin
    End Function

    Private Sub txt_loginUsuario_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_loginUsuario.KeyPress
        'permite só letras
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = INT_mValorZERO Then e.Handled = True
    End Sub

End Class
