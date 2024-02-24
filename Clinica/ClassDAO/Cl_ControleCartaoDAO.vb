Imports Npgsql

Public Class Cl_ControleCartaoDAO

    Public Sub IncControleCartao(ByVal objControleCartao As Cl_ControleCartao, ByVal conexao As NpgsqlConnection)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        Dim transacao As NpgsqlTransaction

        Try
            If conexao.State = ConnectionState.Closed Then
                conexao.Open()
            End If
        Catch ex As Exception
            MsgBox("Erro ao Abri conexao:: " & ex.Message, MsgBoxStyle.Critical) : Return
        End Try
        transacao = conexao.BeginTransaction

        sql = "INSERT INTO controle_cartao(cc_id, cc_loja, cc_data, cc_vlrcartao) "
        sql += "VALUES (DEFAULT, @cc_loja, @cc_data, @cc_vlrcartao) "
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        Try
            comm.Parameters.Add("@cc_data", Convert.ChangeType(objControleCartao.cc_data, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@cc_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@cc_loja", objControleCartao.cc_loja)
        comm.Parameters.Add("@cc_vlrcartao", objControleCartao.cc_vlrcartao)


        comm.ExecuteNonQuery()
        transacao.Commit()
        Try
            conexao.Close()
        Catch ex As Exception
        End Try


        comm = Nothing : sql = Nothing

    End Sub

    Public Sub IncControleCartao(ByVal objControleCartao As Cl_ControleCartao, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "INSERT INTO controle_cartao(cc_id, cc_loja, cc_data, cc_vlrcartao) "
        sql += "VALUES (DEFAULT, @cc_loja, @cc_data, @cc_vlrcartao) "
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        Try
            comm.Parameters.Add("@cc_data", Convert.ChangeType(objControleCartao.cc_data, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@cc_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@cc_loja", objControleCartao.cc_loja)
        comm.Parameters.Add("@cc_vlrcartao", objControleCartao.cc_vlrcartao)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altControleCartao(ByVal objControleCartao As Cl_ControleCartao, ByVal conexao As NpgsqlConnection)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        Dim transacao As NpgsqlTransaction

        Try
            If conexao.State = ConnectionState.Closed Then
                conexao.Open()
            End If
        Catch ex As Exception
            MsgBox("Erro ao Abri conexao:: " & ex.Message, MsgBoxStyle.Critical) : Return
        End Try
        transacao = conexao.BeginTransaction


        sql = "UPDATE controle_cartao SET cc_data = @cc_data, cc_loja = @cc_loja, cc_vlrcartao = @cc_vlrcartao WHERE cc_id = @cc_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cc_id", objControleCartao.cc_id)
        Try
            comm.Parameters.Add("@cc_data", Convert.ChangeType(objControleCartao.cc_data, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@cc_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@cc_loja", objControleCartao.cc_loja)
        comm.Parameters.Add("@cc_vlrcartao", objControleCartao.cc_vlrcartao)

        comm.ExecuteNonQuery()
        transacao.Commit()
        Try
            conexao.Close()
        Catch ex As Exception
        End Try


        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altControleCartao(ByVal objControleCartao As Cl_ControleCartao, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE controle_cartao SET cc_data = @cc_data, cc_loja = @cc_loja, cc_vlrcartao = @cc_vlrcartao WHERE cc_id = @cc_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cc_id", objControleCartao.cc_id)
        Try
            comm.Parameters.Add("@cc_data", Convert.ChangeType(objControleCartao.cc_data, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@cc_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@cc_loja", objControleCartao.cc_loja)
        comm.Parameters.Add("@cc_vlrcartao", objControleCartao.cc_vlrcartao)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delControleCartao(ByVal objControleCartao As Cl_ControleCartao, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM controle_cartao WHERE cc_id = @cc_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cc_id", objControleCartao.cc_id)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Sub delControleCartao(ByVal objControleCartao As Cl_ControleCartao, ByVal strConexao As String)

        Dim conexao As New NpgsqlConnection(strConexao)
        Dim transacao As NpgsqlTransaction
        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        Try
            conexao.Open()
            transacao = conexao.BeginTransaction
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message) : Return
        End Try

        sql = "DELETE FROM controle_cartao WHERE cc_id = @cc_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cc_id", objControleCartao.cc_id)

        comm.ExecuteNonQuery()
        transacao.Commit()
        conexao.Close()

        MsgBox("Registro DELETADO com Sucesso!")
        comm = Nothing : sql = Nothing
        transacao = Nothing : conexao = Nothing
    End Sub

    Public Function trazControleCartao_por_ID(ByVal Id As Int64) As Cl_ControleCartao

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sql As String = ""
        Dim ControleCartao As New Cl_ControleCartao

        Try
            conexao.Open()
        Catch ex As Exception
            Return ControleCartao
        End Try

        sql = "SELECT cc_id, cc_loja, cc_data, cc_vlrcartao FROM controle_cartao WHERE cc_id = " & Id
        comm = New NpgsqlCommand(sql, conexao)
        dr = comm.ExecuteReader

        While dr.Read

            ControleCartao.cc_id = dr(0)
            ControleCartao.cc_loja = dr(1).ToString
            ControleCartao.cc_data = dr(2)
            ControleCartao.cc_vlrcartao = dr(3)
        End While
        dr.Close()
        comm = Nothing : sql = Nothing
        conexao.Close()

        Return ControleCartao
    End Function

    Public Function existeControleCartao_por_Data_Loja(ByVal data As Date, ByVal loja As String) As Boolean

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sql As String = ""
        Dim existe As Boolean = False

        Try
            conexao.Open()
        Catch ex As Exception
            Return False
        End Try

        sql = "SELECT cc_id FROM controle_cartao WHERE cc_data = @cc_data AND cc_loja = @cc_loja"
        comm = New NpgsqlCommand(sql, conexao)
        'Add parametros:
        comm.Parameters.Add("@cc_data", Convert.ChangeType(data, GetType(Date)))
        comm.Parameters.Add("@cc_loja", loja)
        dr = comm.ExecuteReader

        If dr.HasRows Then existe = True
        dr.Close()
        comm = Nothing : sql = Nothing
        conexao.Close()

        Return existe
    End Function


End Class
