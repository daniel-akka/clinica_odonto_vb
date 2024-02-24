Imports Npgsql

Public Class Cl_ContrDivOutrosDAO

    Public Sub IncCDOutros(ByVal objCDOutros As Cl_ControlDivOutros, ByVal conexao As NpgsqlConnection)

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

        sql = "INSERT INTO contr_div_outros(cd_id, cd_loja, cd_data, cd_dentista, cd_vlrliquido, cd_vlrsoma) "
        sql += "VALUES (DEFAULT, @cd_loja, @cd_data, @cd_dentista, @cd_vlrliquido, @cd_vlrsoma) "
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        Try
            comm.Parameters.Add("@cd_data", Convert.ChangeType(objCDOutros.cd_data, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@cd_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@cd_loja", objCDOutros.cd_loja)
        comm.Parameters.Add("@cd_dentista", objCDOutros.cd_dentista)
        comm.Parameters.Add("@cd_vlrsoma", objCDOutros.cd_vlrsoma)
        comm.Parameters.Add("@cd_vlrliquido", objCDOutros.cd_vlrliquido)

        comm.ExecuteNonQuery()
        transacao.Commit()
        Try
            conexao.Close()
        Catch ex As Exception
        End Try


        comm = Nothing : sql = Nothing

    End Sub

    Public Sub IncCDOutros(ByVal objCDOutros As Cl_ControlDivOutros, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "INSERT INTO contr_div_outros(cd_id, cd_loja, cd_data, cd_dentista, cd_vlrliquido, cd_vlrsoma) "
        sql += "VALUES (DEFAULT, @cd_loja, @cd_data, @cd_dentista, @cd_vlrliquido, @cd_vlrsoma) "
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        Try
            comm.Parameters.Add("@cd_data", Convert.ChangeType(objCDOutros.cd_data, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@cd_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@cd_loja", objCDOutros.cd_loja)
        comm.Parameters.Add("@cd_dentista", objCDOutros.cd_dentista)
        comm.Parameters.Add("@cd_vlrsoma", objCDOutros.cd_vlrsoma)
        comm.Parameters.Add("@cd_vlrliquido", objCDOutros.cd_vlrliquido)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altCDOutros(ByVal objCDOutros As Cl_ControlDivOutros, ByVal conexao As NpgsqlConnection)

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


        sql = "UPDATE contr_div_outros SET cd_data = @cd_data, cd_vlrsoma = @cd_vlrsoma, "
        sql += "cd_vlrliquido = @cd_vlrliquido, cd_loja = @cd_loja, cd_dentista = @cd_dentista "
        sql += "WHERE cd_id = @cd_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cd_id", objCDOutros.cd_id)
        comm.Parameters.Add("@cd_data", Convert.ChangeType(objCDOutros.cd_data, GetType(Date)))
        comm.Parameters.Add("@cd_loja", objCDOutros.cd_loja)
        comm.Parameters.Add("@cd_dentista", objCDOutros.cd_dentista)
        comm.Parameters.Add("@cd_vlrsoma", objCDOutros.cd_vlrsoma)
        comm.Parameters.Add("@cd_vlrliquido", objCDOutros.cd_vlrliquido)

        comm.ExecuteNonQuery()
        transacao.Commit()
        Try
            conexao.Close()
        Catch ex As Exception
        End Try


        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altCDOutros(ByVal objCDOutros As Cl_ControlDivOutros, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE contr_div_outros SET cd_data = @cd_data, cd_vlrsoma = @cd_vlrsoma, "
        sql += "cd_vlrliquido = @cd_vlrliquido, cd_loja = @cd_loja, cd_dentista = @cd_dentista "
        sql += "WHERE cd_id = @cd_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cd_id", objCDOutros.cd_id)
        comm.Parameters.Add("@cd_data", Convert.ChangeType(objCDOutros.cd_data, GetType(Date)))
        comm.Parameters.Add("@cd_loja", objCDOutros.cd_loja)
        comm.Parameters.Add("@cd_dentista", objCDOutros.cd_dentista)
        comm.Parameters.Add("@cd_vlrsoma", objCDOutros.cd_vlrsoma)
        comm.Parameters.Add("@cd_vlrliquido", objCDOutros.cd_vlrliquido)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delCDOutros(ByVal objCDOutros As Cl_ControlDivOutros, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM contr_div_outros WHERE cd_id = @cd_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cd_id", objCDOutros.cd_id)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Sub delCDOutros(ByVal objCDOutros As Cl_ControlDivOutros, ByVal strConexao As String)

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

        sql = "DELETE FROM contr_div_outros WHERE cd_id = @cd_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cd_id", objCDOutros.cd_id)

        comm.ExecuteNonQuery()
        transacao.Commit()
        conexao.Close()

        MsgBox("Registro DELETADO com Sucesso!")
        comm = Nothing : sql = Nothing
        transacao = Nothing : conexao = Nothing
    End Sub

    Public Function trazCDOutros_por_ID(ByVal Id As Int64) As Cl_ControlDivOutros

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sql As String = ""
        Dim CDOutros As New Cl_ControlDivOutros

        Try
            conexao.Open()
        Catch ex As Exception
            Return CDOutros
        End Try

        sql = "SELECT cd_id, cd_data, cd_vlrsoma, cd_vlrliquido, cd_loja, cd_dentista FROM contr_div_outros WHERE cd_id = " & Id
        comm = New NpgsqlCommand(sql, conexao)
        dr = comm.ExecuteReader

        While dr.Read

            CDOutros.cd_id = dr(0)
            CDOutros.cd_data = dr(1)
            CDOutros.cd_vlrsoma = dr(2)
            CDOutros.cd_vlrliquido = dr(3)
            CDOutros.cd_loja = dr(4).ToString
            CDOutros.cd_dentista = dr(5)
        End While
        dr.Close()
        comm = Nothing : sql = Nothing
        conexao.Close()

        Return CDOutros
    End Function

    Public Function existeCDOutros_por_Data_Dentista_Loja(ByVal data As Date, ByVal dentista As Integer, ByVal loja As String) As Boolean

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

        sql = "SELECT cd_id FROM contr_div_outros WHERE cd_data = @cd_data AND cd_loja = @cd_loja AND cd_dentista = @cd_dentista"
        comm = New NpgsqlCommand(sql, conexao)
        'Add parametros:
        comm.Parameters.Add("@cd_data", Convert.ChangeType(data, GetType(Date)))
        comm.Parameters.Add("@cd_loja", loja)
        comm.Parameters.Add("@cd_dentista", dentista)
        dr = comm.ExecuteReader

        If dr.HasRows Then existe = True
        dr.Close()
        comm = Nothing : sql = Nothing
        conexao.Close()

        Return existe
    End Function


End Class
