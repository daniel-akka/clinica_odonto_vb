Imports Npgsql
Imports System.Text

Public Class FrmLoginPrivilegio

    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private Const INT_mValorZERO As Integer = 0
    Private _loginOK As Boolean = False
    Public _formRequest As New Object


    Public Sub set_frmRef(ByRef frmRef As Form)
        _formRequest = frmRef
    End Sub

    Private Sub FrmLoginPrivilegio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                _formRequest._frmRef._privilegio = False
                Me.Close()

        End Select
    End Sub

    Private Sub FrmLoginPrivilegio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click
        If txt_senhaUsuario.Text <> "" Then
            Dim Msenha(10), Xsenha(10) As Integer
            Dim mresultado As String

            Msenha(0) = 154
            Msenha(1) = 157
            Msenha(2) = 181
            Msenha(3) = 165
            Msenha(4) = 216
            Msenha(5) = 219
            Msenha(6) = 175
            Msenha(7) = 208
            Msenha(8) = 249
            Msenha(9) = 243

            Dim x As Integer
            For x = 1 To Len(Me.txt_senhaUsuario.Text)
                Xsenha(x - 1) = Asc(Mid(txt_senhaUsuario.Text, x, 1)) + Msenha(x - 1)
                mresultado = RTrim(mresultado) & Convert.ToChar(Xsenha(x - 1))
            Next

            If validaLogin(Me.txt_loginUsuario.Text, mresultado) Then
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
        _formRequest._frmRef._privilegio = False
        Me.Close()
    End Sub

    Private Function validaLogin(ByVal login As String, ByVal senhaCrypt As String) As Boolean
        Dim resultadoLogin As Boolean = False
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim _sqlUsuario As New StringBuilder
        Dim _cmdUsuario As NpgsqlCommand
        Dim _drUsuario As NpgsqlDataReader
        Try
            conection.Open()

            Try
                _sqlUsuario.Append("SELECT u_privilegio, u_nome FROM usuario WHERE u_login = @u_login AND ")
                _sqlUsuario.Append("u_senha = @u_senha")
                _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                _cmdUsuario.Parameters.Add("@u_login", login)
                _cmdUsuario.Parameters.Add("@u_senha", senhaCrypt)
                _drUsuario = _cmdUsuario.ExecuteReader

                While _drUsuario.Read

                    resultadoLogin = True
                    _formRequest._frmRef._privilegio = _drUsuario(0)
                    Try
                        _formRequest._frmRef._usuarioPrivilegio = _drUsuario(1).ToString
                    Catch ex As Exception
                    End Try

                End While
                _drUsuario.Close()
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
            _sqlUsuario = Nothing
            _cmdUsuario = Nothing
            _drUsuario = Nothing
            conection = Nothing
        End Try

        Return resultadoLogin
    End Function

    Private Sub txt_loginUsuario_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_loginUsuario.KeyPress
        'permite só letras
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = INT_mValorZERO Then e.Handled = True
    End Sub
End Class