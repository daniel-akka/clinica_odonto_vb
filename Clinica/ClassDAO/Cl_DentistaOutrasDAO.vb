Imports Npgsql

Public Class Cl_DentistaOutrasDAO

    Public Sub IncDentistaO(ByVal objDentistaO As Cl_DentistaOutras, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO dentistas_outras(do_id, do_loja, do_nome, do_telefone, do_comissao, do_iniciais, do_protetico) "
        sql += "VALUES (DEFAULT, @do_loja, @do_nome, @do_telefone, @do_comissao, @do_iniciais, @do_protetico)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@do_loja", objDentistaO.do_loja)
        comm.Parameters.Add("@do_nome", objDentistaO.do_nome)
        comm.Parameters.Add("@do_telefone", objDentistaO.do_telefone)
        comm.Parameters.Add("@do_comissao", objDentistaO.do_comissao)
        comm.Parameters.Add("@do_iniciais", objDentistaO.do_iniciais)
        comm.Parameters.Add("@do_protetico", objDentistaO.do_protetico)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altDentistaO(ByVal objDentistaO As Cl_DentistaOutras, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE dentistas_outras SET do_loja = @do_loja, do_nome = @do_nome, do_telefone = @do_telefone, do_comissao = @do_comissao, "
        sql += "do_iniciais = @do_iniciais, do_protetico = @do_protetico "
        sql += "WHERE do_id = @do_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@do_id", objDentistaO.do_id)
        comm.Parameters.Add("@do_loja", objDentistaO.do_loja)
        comm.Parameters.Add("@do_nome", objDentistaO.do_nome)
        comm.Parameters.Add("@do_telefone", objDentistaO.do_telefone)
        comm.Parameters.Add("@do_comissao", objDentistaO.do_comissao)
        comm.Parameters.Add("@do_iniciais", objDentistaO.do_iniciais)
        comm.Parameters.Add("@do_protetico", objDentistaO.do_protetico)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub desabilitaDentistaO(ByVal objDentistaO As Cl_DentistaOutras, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE dentistas_outras SET do_desabilitado = true WHERE do_id = @do_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@do_id", objDentistaO.do_id)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Sub delDentistaO(ByVal objDentistaO As Cl_DentistaOutras, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM dentistas_outras WHERE do_id = @do_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@do_id", objDentistaO.do_id)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Function trazDentistaOLoja(ByVal IdDentistaO As Int64, ByVal geno As Cl_Geno, ByRef dentista As Cl_DentistaOutras) As Boolean

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
            Sql = "SELECT do_id, do_loja, do_nome, do_telefone, do_comissao, do_iniciais, do_protetico FROM dentistas_outras WHERE do_id = " & IdDentistaO
            Cmd = New NpgsqlCommand(Sql, oConn)
            dr = Cmd.ExecuteReader

            If dr.HasRows = False Then
                Return False

            Else

                While dr.Read

                    dentista.do_id = dr(0)
                    dentista.do_loja = dr(1).ToString
                    dentista.do_nome = dr(2).ToString
                    dentista.do_telefone = dr(3).ToString
                    Try
                        dentista.do_comissao = dr(4)
                    Catch ex As Exception
                        dentista.do_comissao = 0
                    End Try

                    dentista.do_iniciais = dr(5).ToString
                    dentista.do_protetico = dr(6)
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

    Public Function trazDentistaOLojaNome(ByVal NomeDentistaO As String, ByVal geno As Cl_Geno, ByRef dentista As Cl_DentistaOutras) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Cmd As New NpgsqlCommand
        Dim Sql As String = ""
        Dim loja2Dig As String = Mid(geno.pCodig, geno.pCodig.Length - 1)
        Dim dr As NpgsqlDataReader

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão p/ Buscar DOUTOR:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try
            Sql = "SELECT do_id, do_loja, do_nome, do_telefone, do_comissao, do_iniciais, do_protetico FROM dentistas_outras "
            Sql += "WHERE do_nome = '" & NomeDentistaO & "' AND do_loja = '" & loja2Dig & "' LIMIT 1"
            Cmd = New NpgsqlCommand(Sql, oConn)
            dr = Cmd.ExecuteReader

            If dr.HasRows = False Then
                Return False

            Else

                While dr.Read

                    dentista.do_id = dr(0)
                    dentista.do_loja = dr(1).ToString
                    dentista.do_nome = dr(2).ToString
                    dentista.do_telefone = dr(3).ToString
                    Try
                        dentista.do_comissao = dr(4)
                    Catch ex As Exception
                        dentista.do_comissao = 0
                    End Try

                    dentista.do_iniciais = dr(5).ToString
                    dentista.do_protetico = dr(6)
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

    Public Function trazProteticoOLoja(ByVal geno As Cl_Geno, ByRef dentista As Cl_DentistaOutras, _
                                           ByVal limitRows As Integer) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Cmd As New NpgsqlCommand
        Dim Sql As String = ""
        Dim loja2Dig As String = Mid(geno.pCodig, geno.pCodig.Length - 1)
        Dim dr As NpgsqlDataReader

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão p/ Buscar DOUTOR:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try
            Sql = "SELECT do_id, do_loja, do_nome, do_telefone, do_comissao, do_iniciais, do_protetico FROM dentistas_outras "
            Sql += "WHERE do_loja = '" & loja2Dig & "' AND do_protetico = true LIMIT " & limitRows
            Cmd = New NpgsqlCommand(Sql, oConn)
            dr = Cmd.ExecuteReader

            If dr.HasRows = False Then
                Return False

            Else

                While dr.Read

                    dentista.do_id = dr(0)
                    dentista.do_loja = dr(1).ToString
                    dentista.do_nome = dr(2).ToString
                    dentista.do_telefone = dr(3).ToString
                    Try
                        dentista.do_comissao = dr(4)
                    Catch ex As Exception
                        dentista.do_comissao = 0
                    End Try

                    dentista.do_iniciais = dr(5).ToString
                    dentista.do_protetico = dr(6)
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

    Public Function PreenchComboDentistaO(ByVal geno As Cl_Geno, ByVal cboDentistaOes As ComboBox, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDentistaOes

        End Try


        Dim loja2Dig As String = Mid(geno.pCodig, geno.pCodig.Length - 1)
        Dim cmd As New NpgsqlCommand
        Dim sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            sql = "SELECT do_nome FROM dentistas_outras WHERE do_loja = '" & loja2Dig & "' AND do_desabilitado = false ORDER BY do_nome"
            cmd = New NpgsqlCommand(sql, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboDentistaOes.AutoCompleteCustomSource.Clear()
                cboDentistaOes.Items.Clear() : cboDentistaOes.Refresh()
                While dr.Read

                    cboDentistaOes.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboDentistaOes.Items.Add(dr(0).ToString)
                End While

                cboDentistaOes.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDentistaOes
        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboDentistaOes
    End Function

    Public Function PreenchComboDentistaOesPesq(ByVal geno As Cl_Geno, ByVal cboDentistaOes As ComboBox, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDentistaOes

        End Try


        Dim loja2Dig As String = Mid(geno.pCodig, geno.pCodig.Length - 1)
        Dim cmd As New NpgsqlCommand
        Dim sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            sql = "SELECT do_nome FROM dentistas_outras WHERE do_loja = '" & loja2Dig & "' AND do_desabilitado = false ORDER BY do_nome"
            cmd = New NpgsqlCommand(sql, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboDentistaOes.AutoCompleteCustomSource.Clear()
                cboDentistaOes.Items.Clear() : cboDentistaOes.Refresh()
                cboDentistaOes.AutoCompleteCustomSource.Add("")
                cboDentistaOes.Items.Add("")
                While dr.Read

                    cboDentistaOes.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboDentistaOes.Items.Add(dr(0).ToString)
                End While

                cboDentistaOes.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDentistaOes
        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboDentistaOes
    End Function

    Public Function PreenchComboDentistaOSemProtetico(ByVal geno As Cl_Geno, ByVal cboDentistaOes As ComboBox, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDentistaOes

        End Try


        Dim loja2Dig As String = Mid(geno.pCodig, geno.pCodig.Length - 1)
        Dim cmd As New NpgsqlCommand
        Dim sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            sql = "SELECT do_nome FROM dentistas_outras WHERE do_loja = '" & loja2Dig & "' AND do_desabilitado = false AND do_protetico = false ORDER BY do_nome"
            cmd = New NpgsqlCommand(sql, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboDentistaOes.AutoCompleteCustomSource.Clear()
                cboDentistaOes.Items.Clear() : cboDentistaOes.Refresh()
                While dr.Read

                    cboDentistaOes.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboDentistaOes.Items.Add(dr(0).ToString)
                End While

                cboDentistaOes.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDentistaOes
        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboDentistaOes
    End Function

    Public Function PreenchComboProtetico(ByVal geno As Cl_Geno, ByVal cboDentistaOes As ComboBox, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDentistaOes

        End Try


        Dim loja2Dig As String = Mid(geno.pCodig, geno.pCodig.Length - 1)
        Dim cmd As New NpgsqlCommand
        Dim sql As String = ""
        Dim dr As NpgsqlDataReader

        Try
            sql = "SELECT do_nome FROM dentistas_outras WHERE do_loja = '" & loja2Dig & "' AND do_desabilitado = false AND do_protetico = true ORDER BY do_nome"
            cmd = New NpgsqlCommand(sql, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboDentistaOes.AutoCompleteCustomSource.Clear()
                cboDentistaOes.Items.Clear() : cboDentistaOes.Refresh()
                cboDentistaOes.AutoCompleteCustomSource.Add("")
                cboDentistaOes.Items.Add("")
                While dr.Read

                    cboDentistaOes.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboDentistaOes.Items.Add(dr(0).ToString)
                End While

                cboDentistaOes.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboDentistaOes
        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboDentistaOes
    End Function

    Public Function existeNomeDentistaO(ByVal nome As String, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection) As Boolean

        Dim loja2Dig As String = Mid(geno.pCodig, geno.pCodig.Length - 1)
        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT do_id FROM dentistas_outras WHERE do_loja = '" & loja2Dig & "' AND do_nome = @do_nome"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@do_nome", nome)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeNomeDentistaOAlt(ByVal nomeAnterior As String, ByVal nome As String, ByVal geno As Cl_Geno, _
                                        ByVal conexao As NpgsqlConnection) As Boolean

        Dim loja2Dig As String = Mid(geno.pCodig, geno.pCodig.Length - 1)
        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT do_id FROM dentistas_outras WHERE do_loja = '" & loja2Dig & "' AND do_nome <> @nomeAnterior AND do_nome = @nome"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@nome", nome)
        comm.Parameters.Add("@nomeAnterior", nomeAnterior)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function ValidaDentistaO(ByVal DentistaO As Cl_DentistaOutras, ByVal inclusao As Boolean) As Boolean

        If inclusao = False Then
            If DentistaO.do_id < 1 Then MsgBox("Selecione um DentistaO ! Id não Encontrado!", MsgBoxStyle.Critical) : Return False
        End If

        If Trim(DentistaO.do_nome).Equals("") Then MsgBox("Informe um Nome !", MsgBoxStyle.Critical) : Return False

        Return True
    End Function

End Class
