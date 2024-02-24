Imports Npgsql

Public Class Cl_CxOrcamentoDAO


    Public Sub IncCX_Diario(ByVal objCX_DiarioOrc As Cl_CxOrcamento, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection)

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

        sql = "INSERT INTO " & geno.pEsquemaestab & ".cxorcamento(oc_id, oc_data, oc_descricao, oc_valor, oc_usu, "
        sql += "oc_status, oc_loja, oc_caixa, oc_hora, oc_codcli, oc_nomecli, oc_iddoutor, oc_doutor, "
        sql += "oc_protetico, oc_driniciais) "
        sql += "VALUES (DEFAULT, @oc_data, @oc_descricao, @oc_valor, @oc_usu, @oc_status, @oc_loja, @oc_caixa, "
        sql += "@oc_hora, @oc_codcli, @oc_nomecli, @oc_iddoutor, @oc_doutor, @oc_protetico, @oc_driniciais) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@oc_data", Convert.ChangeType(objCX_DiarioOrc.oc_data, GetType(Date)))
        comm.Parameters.Add("@oc_descricao", objCX_DiarioOrc.oc_descricao)
        comm.Parameters.Add("@oc_valor", objCX_DiarioOrc.oc_valor)
        comm.Parameters.Add("@oc_usu", objCX_DiarioOrc.oc_usu)
        comm.Parameters.Add("@oc_status", objCX_DiarioOrc.oc_status)
        comm.Parameters.Add("@oc_loja", objCX_DiarioOrc.oc_loja)
        comm.Parameters.Add("@oc_caixa", objCX_DiarioOrc.oc_caixa)
        comm.Parameters.Add("@oc_hora", objCX_DiarioOrc.oc_hora)
        comm.Parameters.Add("@oc_codcli", objCX_DiarioOrc.oc_codcli)
        comm.Parameters.Add("@oc_nomecli", objCX_DiarioOrc.oc_nomecli)
        comm.Parameters.Add("@oc_iddoutor", objCX_DiarioOrc.oc_iddoutor)
        comm.Parameters.Add("@oc_doutor", objCX_DiarioOrc.oc_doutor)
        comm.Parameters.Add("@oc_protetico", objCX_DiarioOrc.oc_protetico)
        comm.Parameters.Add("@oc_driniciais", objCX_DiarioOrc.oc_driniciais)

        comm.ExecuteNonQuery()
        transacao.Commit()
        Try
            conexao.Close()
        Catch ex As Exception
        End Try


        comm = Nothing : sql = Nothing

    End Sub

    Public Sub IncCX_Diario(ByVal objCX_DiarioOrc As Cl_CxOrcamento, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "INSERT INTO " & geno.pEsquemaestab & ".cxorcamento(oc_id, oc_data, oc_descricao, oc_valor, oc_usu, "
        sql += "oc_status, oc_loja, oc_caixa, oc_hora, oc_codcli, oc_nomecli, oc_iddoutor, oc_doutor, "
        sql += "oc_protetico, oc_driniciais) "
        sql += "VALUES (DEFAULT, @oc_data, @oc_descricao, @oc_valor, @oc_usu, @oc_status, @oc_loja, @oc_caixa, "
        sql += "@oc_hora, @oc_codcli, @oc_nomecli, @oc_iddoutor, @oc_doutor, @oc_protetico, @oc_driniciais) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@oc_data", Convert.ChangeType(objCX_DiarioOrc.oc_data, GetType(Date)))
        comm.Parameters.Add("@oc_descricao", objCX_DiarioOrc.oc_descricao)
        comm.Parameters.Add("@oc_valor", objCX_DiarioOrc.oc_valor)
        comm.Parameters.Add("@oc_usu", objCX_DiarioOrc.oc_usu)
        comm.Parameters.Add("@oc_status", objCX_DiarioOrc.oc_status)
        comm.Parameters.Add("@oc_loja", objCX_DiarioOrc.oc_loja)
        comm.Parameters.Add("@oc_caixa", objCX_DiarioOrc.oc_caixa)
        comm.Parameters.Add("@oc_hora", objCX_DiarioOrc.oc_hora)
        comm.Parameters.Add("@oc_codcli", objCX_DiarioOrc.oc_codcli)
        comm.Parameters.Add("@oc_nomecli", objCX_DiarioOrc.oc_nomecli)
        comm.Parameters.Add("@oc_iddoutor", objCX_DiarioOrc.oc_iddoutor)
        comm.Parameters.Add("@oc_doutor", objCX_DiarioOrc.oc_doutor)
        comm.Parameters.Add("@oc_protetico", objCX_DiarioOrc.oc_protetico)
        comm.Parameters.Add("@oc_driniciais", objCX_DiarioOrc.oc_driniciais)


        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altCX_Diario(ByVal objCX_DiarioOrc As Cl_CxOrcamento, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection)

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


        sql = "UPDATE " & geno.pEsquemaestab & ".cxorcamento SET oc_data = @oc_data, "
        sql += "oc_descricao = @oc_descricao, oc_valor = @oc_valor, oc_usuarioalt = @oc_usuarioalt, oc_status = @oc_status, "
        sql += "oc_loja = @oc_loja, oc_caixa = @oc_caixa, oc_hora = @oc_hora, oc_codcli = @oc_codcli, "
        sql += "oc_nomecli = @oc_nomecli, oc_iddoutor = @oc_iddoutor, oc_doutor = @oc_doutor, "
        sql += "oc_protetico = @oc_protetico, oc_driniciais = @oc_driniciais WHERE oc_id = @oc_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@oc_id", objCX_DiarioOrc.oc_id)
        comm.Parameters.Add("@oc_data", Convert.ChangeType(objCX_DiarioOrc.oc_data, GetType(Date)))
        comm.Parameters.Add("@oc_descricao", objCX_DiarioOrc.oc_descricao)
        comm.Parameters.Add("@oc_valor", objCX_DiarioOrc.oc_valor)
        comm.Parameters.Add("@oc_usuarioalt", objCX_DiarioOrc.oc_usuarioalt)
        comm.Parameters.Add("@oc_status", objCX_DiarioOrc.oc_status)
        comm.Parameters.Add("@oc_loja", objCX_DiarioOrc.oc_loja)
        comm.Parameters.Add("@oc_caixa", objCX_DiarioOrc.oc_caixa)
        comm.Parameters.Add("@oc_hora", objCX_DiarioOrc.oc_hora)
        comm.Parameters.Add("@oc_codcli", objCX_DiarioOrc.oc_codcli)
        comm.Parameters.Add("@oc_nomecli", objCX_DiarioOrc.oc_nomecli)
        comm.Parameters.Add("@oc_iddoutor", objCX_DiarioOrc.oc_iddoutor)
        comm.Parameters.Add("@oc_doutor", objCX_DiarioOrc.oc_doutor)
        comm.Parameters.Add("@oc_protetico", objCX_DiarioOrc.oc_protetico)
        comm.Parameters.Add("@oc_driniciais", objCX_DiarioOrc.oc_driniciais)

        comm.ExecuteNonQuery()
        transacao.Commit()
        Try
            conexao.Close()
        Catch ex As Exception
        End Try


        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altCX_Diario(ByVal objCX_DiarioOrc As Cl_CxOrcamento, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE " & geno.pEsquemaestab & ".cxorcamento SET oc_data = @oc_data, "
        sql += "oc_descricao = @oc_descricao, oc_valor = @oc_valor, oc_usuarioalt = @oc_usuarioalt, oc_status = @oc_status, "
        sql += "oc_loja = @oc_loja, oc_caixa = @oc_caixa, oc_hora = @oc_hora, oc_codcli = @oc_codcli, "
        sql += "oc_nomecli = @oc_nomecli, oc_iddoutor = @oc_iddoutor, oc_doutor = @oc_doutor, "
        sql += "oc_protetico = @oc_protetico, oc_driniciais = @oc_driniciais WHERE oc_id = @oc_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@oc_id", objCX_DiarioOrc.oc_id)
        comm.Parameters.Add("@oc_data", Convert.ChangeType(objCX_DiarioOrc.oc_data, GetType(Date)))
        comm.Parameters.Add("@oc_descricao", objCX_DiarioOrc.oc_descricao)
        comm.Parameters.Add("@oc_valor", objCX_DiarioOrc.oc_valor)
        comm.Parameters.Add("@oc_usuarioalt", objCX_DiarioOrc.oc_usuarioalt)
        comm.Parameters.Add("@oc_status", objCX_DiarioOrc.oc_status)
        comm.Parameters.Add("@oc_loja", objCX_DiarioOrc.oc_loja)
        comm.Parameters.Add("@oc_caixa", objCX_DiarioOrc.oc_caixa)
        comm.Parameters.Add("@oc_hora", objCX_DiarioOrc.oc_hora)
        comm.Parameters.Add("@oc_codcli", objCX_DiarioOrc.oc_codcli)
        comm.Parameters.Add("@oc_nomecli", objCX_DiarioOrc.oc_nomecli)
        comm.Parameters.Add("@oc_iddoutor", objCX_DiarioOrc.oc_iddoutor)
        comm.Parameters.Add("@oc_doutor", objCX_DiarioOrc.oc_doutor)
        comm.Parameters.Add("@oc_protetico", objCX_DiarioOrc.oc_protetico)
        comm.Parameters.Add("@oc_driniciais", objCX_DiarioOrc.oc_driniciais)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delCX_Diario(ByVal objCX_DiarioOrc As Cl_CxOrcamento, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM " & geno.pEsquemaestab & ".cxorcamento WHERE oc_id = @oc_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@oc_id", objCX_DiarioOrc.oc_id)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Sub delCX_Diario(ByVal objCX_DiarioOrc As Cl_CxOrcamento, ByVal geno As Cl_Geno, ByVal strConexao As String, _
                            Optional ByVal msg As Boolean = True)

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

        sql = "DELETE FROM " & geno.pEsquemaestab & ".cxorcamento WHERE oc_id = @oc_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@oc_id", objCX_DiarioOrc.oc_id)

        comm.ExecuteNonQuery()
        transacao.Commit()
        conexao.Close()

        If msg Then MsgBox("Registro DELETADO com Sucesso!")
        comm = Nothing : sql = Nothing
        transacao = Nothing : conexao = Nothing
    End Sub

    Public Function trazCX_DiarioOrca(ByVal idOrca As Int64, ByVal geno As Cl_Geno, ByVal strConexao As String) As Cl_CxOrcamento

        Dim objOrcamento As New Cl_CxOrcamento
        Dim conexao As New NpgsqlConnection(strConexao)
        Dim transacao As NpgsqlTransaction
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sql As String = ""

        Try
            conexao.Open()
            transacao = conexao.BeginTransaction
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message) : Return objOrcamento
        End Try


        sql = "SELECT oc_id, oc_data, oc_descricao, oc_valor, oc_usu, oc_status, oc_loja, " '6
        sql += "oc_caixa, oc_hora, oc_codcli, oc_nomecli, oc_iddoutor, oc_doutor, " '12
        sql += "oc_usuarioalt, oc_protetico, oc_driniciais "
        sql += "FROM " & geno.pEsquemaestab & ".cxorcamento WHERE oc_id = @oc_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@oc_id", idOrca)
        dr = comm.ExecuteReader

        While dr.Read

            objOrcamento.oc_id = dr(0) : objOrcamento.oc_data = dr(1)
            objOrcamento.oc_descricao = dr(2).ToString : objOrcamento.oc_valor = dr(3)
            objOrcamento.oc_usu = dr(4).ToString : objOrcamento.oc_status = dr(5)
            objOrcamento.oc_loja = dr(6).ToString : objOrcamento.oc_caixa = dr(7).ToString
            objOrcamento.oc_hora = dr(8).ToString : objOrcamento.oc_codcli = dr(9).ToString
            objOrcamento.oc_nomecli = dr(10).ToString : objOrcamento.oc_iddoutor = dr(11)
            objOrcamento.oc_doutor = dr(12).ToString : objOrcamento.oc_usuarioalt = dr(13).ToString
            objOrcamento.oc_protetico = dr(14).ToString : objOrcamento.oc_driniciais = dr(15).ToString

        End While
        conexao.Close()
        comm = Nothing : sql = Nothing
        transacao = Nothing : conexao = Nothing

        Return objOrcamento
    End Function


End Class
