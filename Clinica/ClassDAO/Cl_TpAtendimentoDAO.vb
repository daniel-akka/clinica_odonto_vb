Imports Npgsql

Public Class Cl_TpAtendimentoDAO


    Public Sub IncTpAtend(ByVal objTpAtend As Cl_TpAtendimento, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO tpantendimento(tpa_id, tpa_atendimento, tpa_porcentage) "
        sql += "VALUES (DEFAULT, @tpa_atendimento, @tpa_porcentage)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@tpa_atendimento", objTpAtend.tpa_atendimento)
        comm.Parameters.Add("@tpa_porcentage", objTpAtend.tpa_porcentage)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altTpAtend(ByVal objTpAtend As Cl_TpAtendimento, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE tpantendimento SET tpa_atendimento = @tpa_atendimento, tpa_porcentage = @tpa_porcentage "
        sql += "WHERE tpa_id = @tpa_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@tpa_id", objTpAtend.tpa_id)
        comm.Parameters.Add("@tpa_atendimento", objTpAtend.tpa_atendimento)
        comm.Parameters.Add("@tpa_porcentage", objTpAtend.tpa_porcentage)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delTpAtend(ByVal objTpAtend As Cl_TpAtendimento, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM tpantendimento WHERE tpa_id = @tpa_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@tpa_id", objTpAtend.tpa_id)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Function trazTpAtendimentoID(ByVal IdTpAtend As Integer, ByRef tpAtendimento As Cl_TpAtendimento) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Cmd As New NpgsqlCommand
        Dim Sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão p/ Buscar Tipo Antedimento:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try
            Sql = "SELECT tpa_id, tpa_atendimento, tpa_porcentage FROM tpantendimento WHERE tpa_id = " & IdTpAtend & " LIMIT 1"
            Cmd = New NpgsqlCommand(Sql, oConn)
            dr = Cmd.ExecuteReader

            If dr.HasRows = False Then
                Return False

            Else

                While dr.Read

                    tpAtendimento.tpa_id = dr(0)
                    tpAtendimento.tpa_atendimento = dr(1).ToString
                    Try
                        tpAtendimento.tpa_porcentage = dr(2)
                    Catch ex As Exception
                        tpAtendimento.tpa_porcentage = 0
                    End Try
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

    Public Function trazTpAtendimentoDescr(ByVal NomeTpAtend As String, ByRef tpAtendimento As Cl_TpAtendimento) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Cmd As New NpgsqlCommand
        Dim Sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão p/ Buscar Tipo Antedimento:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try
            Sql = "SELECT tpa_id, tpa_atendimento, tpa_porcentage FROM tpantendimento WHERE tpa_atendimento = '" & NomeTpAtend & "' LIMIT 1"
            Cmd = New NpgsqlCommand(Sql, oConn)
            dr = Cmd.ExecuteReader

            If dr.HasRows = False Then
                Return False

            Else

                While dr.Read

                    tpAtendimento.tpa_id = dr(0)
                    tpAtendimento.tpa_atendimento = dr(1).ToString
                    Try
                        tpAtendimento.tpa_porcentage = dr(2)
                    Catch ex As Exception
                        tpAtendimento.tpa_porcentage = 0
                    End Try
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

    Public Function PreenchComboTpAtendimento(ByVal cboTpAtendes As ComboBox, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboTpAtendes

        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            sql = "SELECT tpa_atendimento FROM tpantendimento ORDER BY tpa_atendimento"
            cmd = New NpgsqlCommand(sql, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboTpAtendes.AutoCompleteCustomSource.Clear()
                cboTpAtendes.Items.Clear() : cboTpAtendes.Refresh()
                While dr.Read

                    cboTpAtendes.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboTpAtendes.Items.Add(dr(0).ToString)
                End While

                cboTpAtendes.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboTpAtendes
        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboTpAtendes
    End Function

    Public Function PreenchComboTpAtendementoPesq(ByVal cboTpAtendes As ComboBox, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboTpAtendes

        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            sql = "SELECT tpa_atendimento FROM tpantendimento ORDER BY tpa_atendimento"
            cmd = New NpgsqlCommand(sql, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboTpAtendes.AutoCompleteCustomSource.Clear()
                cboTpAtendes.Items.Clear() : cboTpAtendes.Refresh()
                cboTpAtendes.AutoCompleteCustomSource.Add("")
                cboTpAtendes.Items.Add("")
                While dr.Read

                    cboTpAtendes.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboTpAtendes.Items.Add(dr(0).ToString)
                End While

                cboTpAtendes.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboTpAtendes
        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboTpAtendes
    End Function

    Public Function existDescrTpAtend(ByVal descricao As String, ByVal conexao As NpgsqlConnection) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT tpa_id FROM tpantendimento WHERE tpa_atendimento = @tpa_atendimento"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@tpa_atendimento", descricao)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeNomeTpAtendAlt(ByVal nomeAnterior As String, ByVal nome As String, _
                                        ByVal conexao As NpgsqlConnection) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT tpa_id FROM tpantendimento WHERE tpa_atendimento <> @nomeAnterior AND tpa_atendimento = @nome"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@nome", nome)
        comm.Parameters.Add("@nomeAnterior", nomeAnterior)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function ValidaTpAtend(ByVal TpAtend As Cl_TpAtendimento, ByVal inclusao As Boolean) As Boolean

        If inclusao = False Then
            If TpAtend.tpa_id < 1 Then MsgBox("Selecione um Tipo de Atendimento ! Id não Encontrado!", MsgBoxStyle.Critical) : Return False
        End If

        If Trim(TpAtend.tpa_atendimento).Equals("") Then MsgBox("Informe uma Descrição de Atendimento !", MsgBoxStyle.Critical) : Return False

        Return True
    End Function

End Class
