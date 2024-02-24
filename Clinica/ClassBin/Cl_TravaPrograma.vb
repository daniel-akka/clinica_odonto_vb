Imports Npgsql

Public Class Cl_TravaPrograma

    Public Id As Int64
    Public DataTravamento As Date
    Public Travar As Boolean

    Sub New()

        Me.Id = 0
        Me.DataTravamento = Nothing
        Me.Travar = False

    End Sub

    Public Function trazDataTravamento(ByVal StrConexao As String) As Date

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(StrConexao)
        Dim Cmd As New NpgsqlCommand
        Dim Sql As String = ""
        Dim dr As NpgsqlDataReader
        Dim mDataTravamento As Date

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão ""Trava"":: " & ex.Message, MsgBoxStyle.Exclamation)
            Return mDataTravamento

        End Try


        Try
            Sql = "SELECT datatravamento FROM trava LIMIT 1"
            Cmd = New NpgsqlCommand(Sql, oConn)
            dr = Cmd.ExecuteReader

            While dr.Read
                mDataTravamento = dr(0)
            End While
            dr.Close()

        Catch ex As Exception
            MsgBox("ERRO::" & ex.Message)
            Return mDataTravamento
        End Try

        Cmd.CommandText = "" : Sql.Remove(0, Sql.ToString.Length)
        Cmd = Nothing : Sql = Nothing : dr = Nothing
        oConn.Close() : oConn = Nothing



        Return mDataTravamento
    End Function

    Public Function trazTravar(ByVal StrConexao As String, ByRef erro As Boolean) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(StrConexao)
        Dim Cmd As New NpgsqlCommand
        Dim Sql As String = ""
        Dim dr As NpgsqlDataReader
        Dim mTravar As Boolean = False

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão ""Trava"":: " & ex.Message, MsgBoxStyle.Exclamation)
            erro = True
            Return mTravar

        End Try


        Try
            Sql = "SELECT travar FROM trava LIMIT 1"
            Cmd = New NpgsqlCommand(Sql, oConn)
            dr = Cmd.ExecuteReader

            While dr.Read
                mTravar = dr(0)
            End While
            dr.Close()

        Catch ex As Exception
            MsgBox("ERRO::" & ex.Message)
            erro = True
            Return mTravar
        End Try

        Cmd.CommandText = "" : Sql.Remove(0, Sql.ToString.Length)
        Cmd = Nothing : Sql = Nothing : dr = Nothing
        oConn.Close() : oConn = Nothing



        Return mTravar
    End Function

    Public Function atualizaTravar(ByVal travar As Boolean, ByVal StrConexao As String) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(StrConexao)
        Dim Cmd As New NpgsqlCommand
        Dim Sql As String = ""
        Dim mTravar As Boolean = False

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão ""Trava"":: " & ex.Message, MsgBoxStyle.Exclamation)
            Return mTravar

        End Try


        Try
            Sql = "UPDATE trava SET travar = " & travar
            Cmd = New NpgsqlCommand(Sql, oConn)
            Cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("ERRO::" & ex.Message)
            Return mTravar
        End Try

        Cmd.CommandText = "" : Sql.Remove(0, Sql.ToString.Length)
        Cmd = Nothing : Sql = Nothing
        oConn.Close() : oConn = Nothing



        Return mTravar
    End Function

End Class
