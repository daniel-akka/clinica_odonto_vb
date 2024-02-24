Imports Npgsql

Public Class Cl_TratamentoDAO

    Public Sub IncTratamento(ByVal Tratamento As Cl_Tratamento, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim comm As New NpgsqlCommand
        Dim transacao As NpgsqlTransaction
        Dim sql As String = ""

        Try
            conexao.Open()
            transacao = conexao.BeginTransaction
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexao em ""IncTratamento"":: " & ex.Message, MsgBoxStyle.Critical)
            Return
        End Try

        sql = "INSERT INTO tratamento(t_id, t_codcliente, t_tratamento, t_qtde, t_valor, t_ficha, t_dentista) "
        sql += "VALUES (DEFAULT, @t_codcliente, @t_tratamento, @t_qtde, @t_valor, @t_ficha, @t_dentista) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@t_codcliente", Tratamento.t_codcliente)
        comm.Parameters.Add("@t_tratamento", Tratamento.t_tratamento)
        comm.Parameters.Add("@t_qtde", Tratamento.t_qtde)
        comm.Parameters.Add("@t_valor", Tratamento.t_valor)
        comm.Parameters.Add("@t_ficha", Tratamento.t_ficha)
        comm.Parameters.Add("@t_dentista", Tratamento.t_dentista)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub IncTratamento(ByVal Tratamento As Cl_Tratamento, ByVal conexao As NpgsqlConnection)

        Dim comm As New NpgsqlCommand
        Dim transacao As NpgsqlTransaction
        Dim sql As String = ""

        Try
            If conexao.State = ConnectionState.Closed Then conexao.Open()
            transacao = conexao.BeginTransaction
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexao em ""IncTratamento"":: " & ex.Message, MsgBoxStyle.Critical)
            Return
        End Try

        sql = "INSERT INTO tratamento(t_id, t_codcliente, t_tratamento, t_qtde, t_valor, t_ficha, t_dentista) "
        sql += "VALUES (DEFAULT, @t_codcliente, @t_tratamento, @t_qtde, @t_valor, @t_ficha, @t_dentista) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@t_codcliente", Tratamento.t_codcliente)
        comm.Parameters.Add("@t_tratamento", Tratamento.t_tratamento)
        comm.Parameters.Add("@t_qtde", Tratamento.t_qtde)
        comm.Parameters.Add("@t_valor", Tratamento.t_valor)
        comm.Parameters.Add("@t_ficha", Tratamento.t_ficha)
        comm.Parameters.Add("@t_dentista", Tratamento.t_dentista)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub IncTratamento(ByVal Tratamento As Cl_Tratamento, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        Try
            If conexao.State = ConnectionState.Closed Then conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexao em ""IncTratamento"":: " & ex.Message, MsgBoxStyle.Critical)
            Return
        End Try

        sql = "INSERT INTO tratamento(t_id, t_codcliente, t_tratamento, t_qtde, t_valor, t_ficha, t_dentista) "
        sql += "VALUES (DEFAULT, @t_codcliente, @t_tratamento, @t_qtde, @t_valor, @t_ficha, @t_dentista) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@t_codcliente", Tratamento.t_codcliente)
        comm.Parameters.Add("@t_tratamento", Tratamento.t_tratamento)
        comm.Parameters.Add("@t_qtde", Tratamento.t_qtde)
        comm.Parameters.Add("@t_valor", Tratamento.t_valor)
        comm.Parameters.Add("@t_ficha", Tratamento.t_ficha)
        comm.Parameters.Add("@t_dentista", Tratamento.t_dentista)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub DelTratamento(ByVal Tratamento As Cl_Tratamento, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim comm As New NpgsqlCommand
        Dim transacao As NpgsqlTransaction
        Dim sql As String = ""

        Try
            conexao.Open()
            transacao = conexao.BeginTransaction
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexao em ""DelTratamento"":: " & ex.Message, MsgBoxStyle.Critical)
            Return
        End Try

        sql = "DELETE FROM tratamento WHERE t_codcliente = @t_codcliente "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@t_codcliente", Tratamento.t_codcliente)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub DelTratamento(ByVal Tratamento As Cl_Tratamento, ByVal conexao As NpgsqlConnection)

        Dim comm As New NpgsqlCommand
        Dim transacao As NpgsqlTransaction
        Dim sql As String = ""

        Try
            If conexao.State = ConnectionState.Closed Then conexao.Open()
            transacao = conexao.BeginTransaction
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexao em ""DelTratamento"":: " & ex.Message, MsgBoxStyle.Critical)
            Return
        End Try

        sql = "DELETE FROM tratamento WHERE t_codcliente = @t_codcliente "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@t_codcliente", Tratamento.t_codcliente)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub DelTratamento(ByVal Tratamento As Cl_Tratamento, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        Try
            If conexao.State = ConnectionState.Closed Then conexao.Open()
        Catch ex As Exception
           MsgBox("Erro ao Abrir conexao em ""DelTratamento"":: " & ex.Message, MsgBoxStyle.Critical)
            Return
        End Try

        sql = "DELETE FROM tratamento WHERE t_codcliente = @t_codcliente "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@t_codcliente", Tratamento.t_codcliente)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

End Class
