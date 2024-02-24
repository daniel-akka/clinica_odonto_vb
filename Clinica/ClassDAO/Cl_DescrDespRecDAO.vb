Imports Npgsql

Public Class Cl_DescrDespRecDAO

    Public Sub IncDescrDespRec(ByVal objDescrDespRec As Cl_DescrDespRec, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO descr_desp_rec(d_id, d_descricao, d_tipo) "
        sql += "VALUES (DEFAULT, @d_descricao, @d_tipo)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@d_descricao", objDescrDespRec.d_descricao)
        comm.Parameters.Add("@d_tipo", objDescrDespRec.d_tipo)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altDescrDespRec(ByVal objDescrDespRec As Cl_DescrDespRec, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE descr_desp_rec SET d_descricao = @d_descricao, d_tipo = @d_tipo "
        sql += "WHERE d_id = @d_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@d_id", objDescrDespRec.d_id)
        comm.Parameters.Add("@d_descricao", objDescrDespRec.d_descricao)
        comm.Parameters.Add("@d_tipo", objDescrDespRec.d_tipo)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delDoutor(ByVal objDescrDespRec As Cl_DescrDespRec, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM descr_desp_rec WHERE d_id = @d_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@d_id", objDescrDespRec.d_id)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Function trazDescricaoPorId(ByVal IdDescricao As Int64, ByRef descricao As Cl_DescrDespRec) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Cmd As New NpgsqlCommand
        Dim Sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão p/ Descricao:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try
            Sql = "SELECT d_id, d_descricao, d_tipo FROM descr_desp_rec WHERE d_id = " & IdDescricao
            Cmd = New NpgsqlCommand(Sql, oConn)
            dr = Cmd.ExecuteReader

            If dr.HasRows = False Then
                Return False

            Else

                While dr.Read

                    descricao.d_id = dr(0)
                    descricao.d_descricao = dr(1).ToString
                    descricao.d_tipo = dr(2).ToString

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

    Public Function trazDescricaoPorNome(ByVal Ndescricao As String, ByRef descricao As Cl_DescrDespRec) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Cmd As New NpgsqlCommand
        Dim Sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão p/ Descricao:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try
            Sql = "SELECT d_id, d_descricao, d_tipo FROM descr_desp_rec WHERE d_descricao = '" & Ndescricao & "'"
            Cmd = New NpgsqlCommand(Sql, oConn)
            dr = Cmd.ExecuteReader

            If dr.HasRows = False Then
                Return False

            Else

                While dr.Read

                    descricao.d_id = dr(0)
                    descricao.d_descricao = dr(1).ToString
                    descricao.d_tipo = dr(2).ToString

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

    Public Function PreenchComboDescricoes(ByVal cboDescricao As ComboBox, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDescricao

        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            sql = "SELECT d_descricao FROM descr_desp_rec ORDER BY d_descricao"
            cmd = New NpgsqlCommand(sql, oConn)
            dr = cmd.ExecuteReader

            cboDescricao.AutoCompleteCustomSource.Clear()
            cboDescricao.Items.Clear() : cboDescricao.Refresh()

            If dr.HasRows = True Then

                While dr.Read

                    cboDescricao.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboDescricao.Items.Add(dr(0).ToString)
                End While

                cboDescricao.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDescricao
        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboDescricao
    End Function

    Public Function PreenchComboDescricoesPorTIPO(ByVal mTipo As String, ByVal cboDescricao As ComboBox, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDescricao

        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            sql = "SELECT d_descricao FROM descr_desp_rec WHERE d_tipo = '" & mTipo & "' ORDER BY d_descricao"
            cmd = New NpgsqlCommand(sql, oConn)
            dr = cmd.ExecuteReader

            cboDescricao.AutoCompleteCustomSource.Clear()
            cboDescricao.Items.Clear() : cboDescricao.Refresh()

            If dr.HasRows = True Then

                While dr.Read

                    cboDescricao.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboDescricao.Items.Add(dr(0).ToString)
                End While

                cboDescricao.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDescricao
        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboDescricao
    End Function

    Public Function existeNomeDescr(ByVal nome As String, ByVal conexao As NpgsqlConnection) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT d_descricao FROM descr_desp_rec WHERE d_descricao = @d_descricao"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@d_descricao", nome)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeNomeDescrAlt(ByVal nomeAnterior As String, ByVal nome As String, ByVal conexao As NpgsqlConnection) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT d_id FROM descr_desp_rec WHERE d_descricao <> @nomeAnterior AND d_descricao = @nome"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@nome", nome)
        comm.Parameters.Add("@nomeAnterior", nomeAnterior)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function ValidaDescricao(ByVal Descricao As Cl_DescrDespRec, ByVal inclusao As Boolean) As Boolean

        If inclusao = False Then
            If Descricao.d_id < 1 Then MsgBox("Selecione uma Descrição ! Id não Encontrado!", MsgBoxStyle.Critical) : Return False
        End If

        If Trim(Descricao.d_descricao).Equals("") Then MsgBox("Informe uma Descrição !", MsgBoxStyle.Critical) : Return False
        If Trim(Descricao.d_tipo).Equals("") Then MsgBox("Informe um Tipo da Descrição !", MsgBoxStyle.Critical) : Return False

        Return True
    End Function

End Class
