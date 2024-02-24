Imports Npgsql

Public Class Cl_DoutorDAO

    Public Sub IncDoutor(ByVal objDoutor As Cl_Doutor, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO " & geno.pEsquemaestab & ".doutores(d_id, d_nome, d_telefone, d_comissao, d_iniciais, d_protetico) "
        sql += "VALUES (DEFAULT, @d_nome, @d_telefone, @d_comissao, @d_iniciais, @d_protetico)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@d_nome", objDoutor.Nome)
        comm.Parameters.Add("@d_telefone", objDoutor.Telefone)
        comm.Parameters.Add("@d_comissao", objDoutor.Comissao)
        comm.Parameters.Add("@d_iniciais", objDoutor.Iniciais)
        comm.Parameters.Add("@d_protetico", objDoutor.Protetico)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altDoutor(ByVal objDoutor As Cl_Doutor, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE " & geno.pEsquemaestab & ".doutores SET d_nome = @d_nome, d_telefone = @d_telefone, d_comissao = @d_comissao, "
        sql += "d_iniciais = @d_iniciais, d_protetico = @d_protetico "
        sql += "WHERE d_id = @d_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@d_id", objDoutor.Id)
        comm.Parameters.Add("@d_nome", objDoutor.Nome)
        comm.Parameters.Add("@d_telefone", objDoutor.Telefone)
        comm.Parameters.Add("@d_comissao", objDoutor.Comissao)
        comm.Parameters.Add("@d_iniciais", objDoutor.Iniciais)
        comm.Parameters.Add("@d_protetico", objDoutor.Protetico)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub desabilitaDoutor(ByVal objDoutor As Cl_Doutor, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE " & geno.pEsquemaestab & ".doutores SET d_desabilitado = true WHERE d_id = @d_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@d_id", objDoutor.Id)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Sub delDoutor(ByVal objDoutor As Cl_Doutor, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM " & geno.pEsquemaestab & ".doutores WHERE d_id = @d_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@d_id", objDoutor.Id)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Function trazDoutorLoja(ByVal IdDoutor As Int64, ByVal geno As Cl_Geno, ByRef doutor As Cl_Doutor) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Cmd As New NpgsqlCommand
        Dim Sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão p/ Buscar DOUTOR:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try
            Sql = "SELECT d_id, d_nome, d_telefone, d_comissao, d_iniciais, d_protetico FROM " & geno.pEsquemaestab & ".doutores WHERE d_id = " & IdDoutor
            Cmd = New NpgsqlCommand(Sql, oConn)
            dr = Cmd.ExecuteReader

            If dr.HasRows = False Then
                Return False

            Else

                While dr.Read

                    doutor.Id = dr(0)
                    doutor.Nome = dr(1).ToString
                    doutor.Telefone = dr(2).ToString
                    Try
                        doutor.Comissao = dr(3)
                    Catch ex As Exception
                        doutor.Comissao = 0
                    End Try

                    doutor.Iniciais = dr(4).ToString
                    doutor.Protetico = dr(5)
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

    Public Function trazDoutorLojaNome(ByVal NomeDoutor As String, ByVal geno As Cl_Geno, ByRef doutor As Cl_Doutor, _
                                       Optional ByVal protetico As Boolean = False) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Cmd As New NpgsqlCommand
        Dim Sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão p/ Buscar DOUTOR:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try
            Sql = "SELECT d_id, d_nome, d_telefone, d_comissao, d_iniciais, d_protetico FROM " & geno.pEsquemaestab & ".doutores "
            Sql += "WHERE d_nome LIKE '" & NomeDoutor & "' "
            If protetico Then Sql += " AND d_protetico = " & protetico & " "
            Sql += "LIMIT 1"

            Cmd = New NpgsqlCommand(Sql, oConn)
            dr = Cmd.ExecuteReader

            If dr.HasRows = False Then
                Return False

            Else

                While dr.Read

                    doutor.Id = dr(0)
                    doutor.Nome = dr(1).ToString
                    doutor.Telefone = dr(2).ToString
                    Try
                        doutor.Comissao = dr(3)
                    Catch ex As Exception
                        doutor.Comissao = 0
                    End Try

                    doutor.Iniciais = dr(4).ToString
                    doutor.Protetico = dr(5)
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

    Public Function PreenchComboDoutores(ByVal geno As Cl_Geno, ByVal cboDoutores As ComboBox, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDoutores

        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            sql = "SELECT d_nome FROM " & geno.pEsquemaestab & ".doutores WHERE d_desabilitado = false ORDER BY d_nome"
            cmd = New NpgsqlCommand(sql, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboDoutores.AutoCompleteCustomSource.Clear()
                cboDoutores.Items.Clear() : cboDoutores.Refresh()
                While dr.Read

                    cboDoutores.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboDoutores.Items.Add(dr(0).ToString)
                End While

                cboDoutores.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDoutores
        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboDoutores
    End Function

    Public Function PreenchComboDoutoresPesq(ByVal geno As Cl_Geno, ByVal cboDoutores As ComboBox, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDoutores

        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            sql = "SELECT d_nome FROM " & geno.pEsquemaestab & ".doutores WHERE d_desabilitado = false ORDER BY d_nome"
            cmd = New NpgsqlCommand(sql, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboDoutores.AutoCompleteCustomSource.Clear()
                cboDoutores.Items.Clear() : cboDoutores.Refresh()
                cboDoutores.AutoCompleteCustomSource.Add("")
                cboDoutores.Items.Add("")
                While dr.Read

                    cboDoutores.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboDoutores.Items.Add(dr(0).ToString)
                End While

                cboDoutores.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDoutores
        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboDoutores
    End Function

    Public Function PreenchComboProtetico(ByVal geno As Cl_Geno, ByVal cboDoutores As ComboBox, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDoutores

        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            sql = "SELECT d_nome FROM " & geno.pEsquemaestab & ".doutores WHERE d_desabilitado = false AND d_protetico = true ORDER BY d_nome"
            cmd = New NpgsqlCommand(sql, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboDoutores.AutoCompleteCustomSource.Clear()
                cboDoutores.Items.Clear() : cboDoutores.Refresh()
                cboDoutores.AutoCompleteCustomSource.Add("")
                cboDoutores.Items.Add("")
                While dr.Read

                    cboDoutores.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboDoutores.Items.Add(dr(0).ToString)
                End While

                cboDoutores.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDoutores
        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboDoutores
    End Function

    Public Function existeNomeDoutor(ByVal nome As String, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT d_id FROM " & geno.pEsquemaestab & ".doutores WHERE d_nome = @d_nome"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@d_nome", nome)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeNomeDoutorAlt(ByVal nomeAnterior As String, ByVal nome As String, ByVal geno As Cl_Geno, _
                                        ByVal conexao As NpgsqlConnection) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT d_id FROM " & geno.pEsquemaestab & ".doutores WHERE d_nome <> @nomeAnterior AND d_nome = @nome"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@nome", nome)
        comm.Parameters.Add("@nomeAnterior", nomeAnterior)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function ValidaDoutor(ByVal Doutor As Cl_Doutor, ByVal inclusao As Boolean) As Boolean

        If inclusao = False Then
            If Doutor.Id < 1 Then MsgBox("Selecione um Doutor ! Id não Encontrado!", MsgBoxStyle.Critical) : Return False
        End If

        If Trim(Doutor.Nome).Equals("") Then MsgBox("Informe um Nome !", MsgBoxStyle.Critical) : Return False

        Return True
    End Function

End Class
