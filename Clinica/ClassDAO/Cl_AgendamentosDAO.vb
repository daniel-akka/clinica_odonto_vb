Imports Npgsql

Public Class Cl_AgendamentosDAO

    Public Sub IncAgendamento1(ByVal objAgend1 As Cl_Agendamento1, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO " & geno.pEsquemaestab & ".tb_agend1(a_id, a_codig, a_dtemis, a_dtagend, a_status, a_iddoutor, a_doutor, a_valor, "
        sql += "a_cancelado, a_usuario, a_usuarioalt, a_turno, a_info, a_paciente) VALUES (@a_id, @a_codig, @a_dtemis, @a_dtagend, @a_status, @a_iddoutor, @a_doutor, "
        sql += "@a_valor, @a_cancelado, @a_usuario, @a_usuarioalt, @a_turno, @a_info, @a_paciente)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@a_id", objAgend1.a_id)
        comm.Parameters.Add("@a_codig", objAgend1.a_codig)
        comm.Parameters.Add("@a_dtemis", Convert.ChangeType(objAgend1.a_dtemis, GetType(Date)))
        comm.Parameters.Add("@a_dtagend", Convert.ChangeType(objAgend1.a_dtagend, GetType(Date)))
        comm.Parameters.Add("@a_status", objAgend1.a_status)
        comm.Parameters.Add("@a_iddoutor", objAgend1.a_iddoutor)
        comm.Parameters.Add("@a_doutor", objAgend1.a_doutor)
        comm.Parameters.Add("@a_valor", objAgend1.a_valor)
        comm.Parameters.Add("@a_cancelado", objAgend1.a_cancelado)
        comm.Parameters.Add("@a_usuario", objAgend1.a_usuario)
        comm.Parameters.Add("@a_usuarioalt", objAgend1.a_usuarioAlt)
        comm.Parameters.Add("@a_turno", objAgend1.a_turno)
        comm.Parameters.Add("@a_info", objAgend1.a_info)
        comm.Parameters.Add("@a_paciente", objAgend1.a_paciente)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub AltAgendamento1(ByVal objAgend1 As Cl_Agendamento1, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE " & geno.pEsquemaestab & ".tb_agend1 SET a_codig = @a_codig, a_dtemis =  @a_dtemis, a_dtagend = @a_dtagend, "
        sql += "a_status = @a_status, a_iddoutor = @a_iddoutor, a_doutor = @a_doutor, a_valor = @a_valor, a_cancelado = @a_cancelado, "
        sql += "a_usuarioalt = @a_usuarioalt, a_turno = @a_turno, a_info = @a_info, a_paciente = @a_paciente "
        sql += "WHERE a_id = @a_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@a_id", objAgend1.a_id)
        comm.Parameters.Add("@a_codig", objAgend1.a_codig)
        comm.Parameters.Add("@a_dtemis", Convert.ChangeType(objAgend1.a_dtemis, GetType(Date)))
        comm.Parameters.Add("@a_dtagend", Convert.ChangeType(objAgend1.a_dtagend, GetType(Date)))
        comm.Parameters.Add("@a_status", objAgend1.a_status)
        comm.Parameters.Add("@a_iddoutor", objAgend1.a_iddoutor)
        comm.Parameters.Add("@a_doutor", objAgend1.a_doutor)
        comm.Parameters.Add("@a_valor", objAgend1.a_valor)
        comm.Parameters.Add("@a_cancelado", objAgend1.a_cancelado)
        comm.Parameters.Add("@a_usuarioalt", objAgend1.a_usuarioAlt)
        comm.Parameters.Add("@a_turno", objAgend1.a_turno)
        comm.Parameters.Add("@a_info", objAgend1.a_info)
        comm.Parameters.Add("@a_paciente", objAgend1.a_paciente)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub IncAgendamento2(ByVal objAgend2 As Cl_Agendamento2, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO " & geno.pEsquemaestab & ".tb_agend2(a2_id, a2_id1, a2_codserv, a2_descrserv, a2_dtemis, a2_valor, a2_qtde, a2_total) "
        sql += "VALUES (DEFAULT, @a2_id1, @a2_codserv, @a2_descrserv, @a2_dtemis, @a2_valor, @a2_qtde, @a2_total)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@a2_id1", objAgend2.a2_id1)
        comm.Parameters.Add("@a2_codserv", objAgend2.a2_codserv)
        comm.Parameters.Add("@a2_descrserv", objAgend2.a2_descrserv)
        comm.Parameters.Add("@a2_dtemis", Convert.ChangeType(objAgend2.a2_dtemis, GetType(Date)))
        comm.Parameters.Add("@a2_valor", objAgend2.a2_valor)
        comm.Parameters.Add("@a2_qtde", objAgend2.a2_qtde)
        comm.Parameters.Add("@a2_total", objAgend2.a2_total)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delAgendamento2(ByVal objAgend1 As Cl_Agendamento1, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM " & geno.pEsquemaestab & ".tb_agend2 WHERE a2_id1 = @a2_id1"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@a2_id1", objAgend1.a_id)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Function trazAgendamento1(ByVal IdAgend As Int64, ByVal geno As Cl_Geno, ByRef agend1 As Cl_Agendamento1) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Cmd As New NpgsqlCommand
        Dim Sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão p/ Buscar Agendamento:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try
            Sql = "SELECT a_id, a_codig, a_dtemis, a_dtagend, a_status, a_iddoutor, a_doutor, "
            Sql += "a_valor, a_cancelado, a_turno, a_info, a_paciente FROM " & geno.pEsquemaestab & ".tb_agend1 WHERE a_id = " & IdAgend
            Cmd = New NpgsqlCommand(Sql, oConn)
            dr = Cmd.ExecuteReader

            If dr.HasRows = False Then
                Return False

            Else

                While dr.Read

                    agend1.a_id = dr(0)
                    agend1.a_codig = dr(1).ToString
                    agend1.a_dtemis = dr(2)
                    agend1.a_dtagend = dr(3)
                    agend1.a_status = dr(4)
                    agend1.a_iddoutor = dr(5)
                    agend1.a_doutor = dr(6).ToString
                    agend1.a_valor = dr(7)
                    agend1.a_cancelado = dr(8)
                    agend1.a_turno = dr(9).ToString
                    agend1.a_info = dr(10).ToString
                    agend1.a_paciente = dr(11).ToString

                End While
                dr.Close()


            End If

        Catch ex As Exception
            MsgBox("ERRO::" & ex.Message)
            Return False
        End Try

        Cmd.CommandText = "" : Sql.Remove(0, Sql.ToString.Length)
        Cmd = Nothing : Sql = Nothing : dr = Nothing
        oConn.Close() : oConn = Nothing



        Return True
    End Function

    Public Function trazProxNumAgendamento1(ByVal conexao As NpgsqlConnection, ByVal geno As Cl_Geno) As String
        Dim mNumero As String = ""
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT nextval('" & geno.pEsquemaestab & ".tb_agend1_a_id_seq'::regclass)"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        dr = comm.ExecuteReader
        While dr.Read

            mNumero = dr(0).ToString
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumero
    End Function

End Class
