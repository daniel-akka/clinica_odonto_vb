Imports Npgsql

Public Class Cl_ControleMensalDAO

    Public Sub IncCMensal(ByVal objCMensal As Cl_ControleMensal, ByVal conexao As NpgsqlConnection)

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

        sql = "INSERT INTO controle_mensal(c_id, c_data, c_vlrbruto, c_vlrdespesas, c_vlrliquido, c_loja, c_dentista, c_vlrcartao, c_tipoatendimento) "
        sql += "VALUES (DEFAULT, @c_data, @c_vlrbruto, @c_vlrdespesas, @c_vlrliquido, @c_loja, @c_dentista, @c_vlrcartao, @c_tipoatendimento) "
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        Try
            comm.Parameters.Add("@c_data", Convert.ChangeType(objCMensal.c_data, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@c_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@c_vlrbruto", objCMensal.c_vlrbruto)
        comm.Parameters.Add("@c_vlrdespesas", objCMensal.c_vlrdespesas)
        comm.Parameters.Add("@c_vlrliquido", objCMensal.c_vlrliquido)
        comm.Parameters.Add("@c_loja", objCMensal.c_loja)
        comm.Parameters.Add("@c_dentista", objCMensal.c_dentista)
        comm.Parameters.Add("@c_vlrcartao", objCMensal.c_Vlrcartao)
        comm.Parameters.Add("@c_tipoatendimento", objCMensal.c_tipoatendimento)

        comm.ExecuteNonQuery()
        transacao.Commit()
        Try
            conexao.Close()
        Catch ex As Exception
        End Try


        comm = Nothing : sql = Nothing

    End Sub

    Public Sub IncCMensal(ByVal objCMensal As Cl_ControleMensal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "INSERT INTO controle_mensal(c_id, c_data, c_vlrbruto, c_vlrdespesas, c_vlrliquido, c_loja, c_dentista, c_vlrcartao, c_tipoatendimento) "
        sql += "VALUES (DEFAULT, @c_data, @c_vlrbruto, @c_vlrdespesas, @c_vlrliquido, @c_loja, @c_dentista, @c_vlrcartao, @c_tipoatendimento) "
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        Try
            comm.Parameters.Add("@c_data", Convert.ChangeType(objCMensal.c_data, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@c_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@c_vlrbruto", objCMensal.c_vlrbruto)
        comm.Parameters.Add("@c_vlrdespesas", objCMensal.c_vlrdespesas)
        comm.Parameters.Add("@c_vlrliquido", objCMensal.c_vlrliquido)
        comm.Parameters.Add("@c_loja", objCMensal.c_loja)
        comm.Parameters.Add("@c_dentista", objCMensal.c_dentista)
        comm.Parameters.Add("@c_vlrcartao", objCMensal.c_Vlrcartao)
        comm.Parameters.Add("@c_tipoatendimento", objCMensal.c_tipoatendimento)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altCMensal(ByVal objCMensal As Cl_ControleMensal, ByVal conexao As NpgsqlConnection)

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


        sql = "UPDATE controle_mensal SET c_data = @c_data, c_vlrbruto = @c_vlrbruto, c_vlrdespesas = @c_vlrdespesas, "
        sql += "c_vlrliquido = @c_vlrliquido, c_loja = @c_loja, c_dentista = @c_dentista, c_vlrcartao = @c_vlrcartao, "
        sql += "c_tipoatendimento = @c_tipoatendimento WHERE c_id = @c_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@c_id", objCMensal.c_id)
        comm.Parameters.Add("@c_data", Convert.ChangeType(objCMensal.c_data, GetType(Date)))
        comm.Parameters.Add("@c_vlrbruto", objCMensal.c_vlrbruto)
        comm.Parameters.Add("@c_vlrdespesas", objCMensal.c_vlrdespesas)
        comm.Parameters.Add("@c_vlrliquido", objCMensal.c_vlrliquido)
        comm.Parameters.Add("@c_loja", objCMensal.c_loja)
        comm.Parameters.Add("@c_dentista", objCMensal.c_dentista)
        comm.Parameters.Add("@c_vlrcartao", objCMensal.c_Vlrcartao)
        comm.Parameters.Add("@c_tipoatendimento", objCMensal.c_tipoatendimento)

        comm.ExecuteNonQuery()
        transacao.Commit()
        Try
            conexao.Close()
        Catch ex As Exception
        End Try


        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altCMensal(ByVal objCMensal As Cl_ControleMensal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE controle_mensal SET c_data = @c_data, c_vlrbruto = @c_vlrbruto, c_vlrdespesas = @c_vlrdespesas, "
        sql += "c_vlrliquido = @c_vlrliquido, c_loja = @c_loja, c_dentista = @c_dentista, c_vlrcartao = @c_vlrcartao, "
        sql += "c_tipoatendimento = @c_tipoatendimento WHERE c_id = @c_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@c_id", objCMensal.c_id)
        comm.Parameters.Add("@c_data", Convert.ChangeType(objCMensal.c_data, GetType(Date)))
        comm.Parameters.Add("@c_vlrbruto", objCMensal.c_vlrbruto)
        comm.Parameters.Add("@c_vlrdespesas", objCMensal.c_vlrdespesas)
        comm.Parameters.Add("@c_vlrliquido", objCMensal.c_vlrliquido)
        comm.Parameters.Add("@c_loja", objCMensal.c_loja)
        comm.Parameters.Add("@c_dentista", objCMensal.c_dentista)
        comm.Parameters.Add("@c_vlrcartao", objCMensal.c_Vlrcartao)
        comm.Parameters.Add("@c_tipoatendimento", objCMensal.c_tipoatendimento)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delCMensal(ByVal objCMensal As Cl_ControleMensal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM controle_mensal WHERE c_id = @c_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@c_id", objCMensal.c_id)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Sub delCMensal(ByVal objCMensal As Cl_ControleMensal, ByVal strConexao As String)

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

        sql = "DELETE FROM controle_mensal WHERE c_id = @c_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@c_id", objCMensal.c_id)

        comm.ExecuteNonQuery()
        transacao.Commit()
        conexao.Close()

        MsgBox("Registro DELETADO com Sucesso!")
        comm = Nothing : sql = Nothing
        transacao = Nothing : conexao = Nothing
    End Sub

    Public Function trazCMensal_por_ID(ByVal Id As Int64) As Cl_ControleMensal

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sql As String = ""
        Dim CMensal As New Cl_ControleMensal

        Try
            conexao.Open()
        Catch ex As Exception
            Return CMensal
        End Try

        sql = "SELECT c_id, c_data, c_vlrbruto, c_vlrdespesas, c_vlrliquido, c_loja, c_dentista, c_vlrcartao, c_tipoatendimento FROM controle_mensal WHERE c_id = " & Id
        comm = New NpgsqlCommand(sql, conexao)
        dr = comm.ExecuteReader

        While dr.Read

            CMensal.c_id = dr(0)
            CMensal.c_data = dr(1)
            CMensal.c_vlrbruto = dr(2)
            CMensal.c_vlrdespesas = dr(3)
            CMensal.c_vlrliquido = dr(4)
            CMensal.c_loja = dr(5).ToString
            CMensal.c_dentista = dr(6).ToString
            CMensal.c_Vlrcartao = dr(7)
            CMensal.c_tipoatendimento = dr(8).ToString
        End While
        dr.Close()
        comm = Nothing : sql = Nothing
        conexao.Close()

        Return CMensal
    End Function

    Public Function existeCMensal_por_Data_Tp_Loja(ByVal data As Date, ByVal tp As String, ByVal loja As String) As Boolean

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

        sql = "SELECT c_id FROM controle_mensal WHERE c_data = @c_data AND c_loja = @c_loja AND c_tipoatendimento = @c_tipoatendimento"
        comm = New NpgsqlCommand(sql, conexao)
        'Add parametros:
        comm.Parameters.Add("@c_data", Convert.ChangeType(data, GetType(Date)))
        comm.Parameters.Add("@c_loja", loja)
        comm.Parameters.Add("@c_tipoatendimento", tp)
        dr = comm.ExecuteReader

        If dr.HasRows Then existe = True
        dr.Close()
        comm = Nothing : sql = Nothing
        conexao.Close()

        Return existe
    End Function

End Class
