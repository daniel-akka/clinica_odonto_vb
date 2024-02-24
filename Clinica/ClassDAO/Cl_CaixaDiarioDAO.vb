Imports Npgsql

Public Class Cl_CaixaDiarioDAO


    Public Sub IncCX_Diario(ByVal objCX_Diario As Cl_CaixaDiario, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection)

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

        sql = "INSERT INTO " & geno.pEsquemaestab & ".caixadiario(cx_id, cx_tipo, cx_data, cx_grupo, cx_descricao, cx_valor, cx_usu, "
        sql += "cx_status, cx_loja, cx_caixa, cx_hora, cx_codcli, cx_nomecli, cx_iddoutor, cx_doutor, cx_comissdoutor, cx_idduplreceb, cx_tipopag, "
        sql += "cx_protetico, cx_driniciais, cx_doutor_old, cx_tpatend_id, cx_tpatend, cx_recebido, cx_orcamento) "
        sql += "VALUES (DEFAULT, @cx_tipo, @cx_data, @cx_grupo, @cx_descricao, @cx_valor, @cx_usu, @cx_status, @cx_loja, @cx_caixa, "
        sql += "@cx_hora, @cx_codcli, @cx_nomecli, @cx_iddoutor, @cx_doutor, @cx_comissdoutor, @cx_idduplreceb, @cx_tipopag, @cx_protetico, "
        sql += "@cx_driniciais, @cx_doutor_old, @cx_tpatend_id, @cx_tpatend, @cx_recebido, @cx_orcamento)"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cx_tipo", objCX_Diario.cx_tipo)
        comm.Parameters.Add("@cx_data", Convert.ChangeType(objCX_Diario.cx_data, GetType(Date)))
        comm.Parameters.Add("@cx_grupo", objCX_Diario.cx_grupo)
        comm.Parameters.Add("@cx_descricao", objCX_Diario.cx_descricao)
        comm.Parameters.Add("@cx_valor", objCX_Diario.cx_valor)
        comm.Parameters.Add("@cx_usu", objCX_Diario.cx_usu)
        comm.Parameters.Add("@cx_status", objCX_Diario.cx_status)
        comm.Parameters.Add("@cx_loja", objCX_Diario.cx_loja)
        comm.Parameters.Add("@cx_caixa", objCX_Diario.cx_caixa)
        comm.Parameters.Add("@cx_hora", objCX_Diario.cx_hora)
        comm.Parameters.Add("@cx_codcli", objCX_Diario.cx_codcli)
        comm.Parameters.Add("@cx_nomecli", objCX_Diario.cx_nomecli)
        comm.Parameters.Add("@cx_iddoutor", objCX_Diario.cx_iddoutor)
        comm.Parameters.Add("@cx_doutor", objCX_Diario.cx_doutor)
        comm.Parameters.Add("@cx_comissdoutor", objCX_Diario.cx_comissdoutor)
        comm.Parameters.Add("@cx_idduplreceb", objCX_Diario.cx_idduplreceb)
        comm.Parameters.Add("@cx_tipopag", objCX_Diario.cx_tipopag)
        comm.Parameters.Add("@cx_protetico", objCX_Diario.cx_protetico)
        comm.Parameters.Add("@cx_driniciais", objCX_Diario.cx_driniciais)
        comm.Parameters.Add("@cx_doutor_old", objCX_Diario.cx_doutor_old)
        comm.Parameters.Add("@cx_tpatend_id", objCX_Diario.cx_tpatend_id)
        comm.Parameters.Add("@cx_tpatend", objCX_Diario.cx_tpatend)
        comm.Parameters.Add("@cx_recebido", objCX_Diario.cx_recebido)
        comm.Parameters.Add("@cx_orcamento", objCX_Diario.cx_orcamento)


        comm.ExecuteNonQuery()
        transacao.Commit()
        Try
            conexao.Close()
        Catch ex As Exception
        End Try


        comm = Nothing : sql = Nothing

    End Sub

    Public Sub IncCX_Diario(ByVal objCX_Diario As Cl_CaixaDiario, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "INSERT INTO " & geno.pEsquemaestab & ".caixadiario(cx_id, cx_tipo, cx_data, cx_grupo, cx_descricao, cx_valor, cx_usu, "
        sql += "cx_status, cx_loja, cx_caixa, cx_hora, cx_codcli, cx_nomecli, cx_iddoutor, cx_doutor, cx_comissdoutor, cx_idduplreceb, cx_tipopag, "
        sql += "cx_protetico, cx_driniciais, cx_doutor_old, cx_tpatend_id, cx_tpatend, cx_recebido, cx_orcamento) "
        sql += "VALUES (DEFAULT, @cx_tipo, @cx_data, @cx_grupo, @cx_descricao, @cx_valor, @cx_usu, @cx_status, @cx_loja, @cx_caixa, "
        sql += "@cx_hora, @cx_codcli, @cx_nomecli, @cx_iddoutor, @cx_doutor, @cx_comissdoutor, @cx_idduplreceb, @cx_tipopag, @cx_protetico, "
        sql += "@cx_driniciais, @cx_doutor_old, @cx_tpatend_id, @cx_tpatend, @cx_recebido, @cx_orcamento) "
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cx_tipo", objCX_Diario.cx_tipo)
        comm.Parameters.Add("@cx_data", Convert.ChangeType(objCX_Diario.cx_data, GetType(Date)))
        comm.Parameters.Add("@cx_grupo", objCX_Diario.cx_grupo)
        comm.Parameters.Add("@cx_descricao", objCX_Diario.cx_descricao)
        comm.Parameters.Add("@cx_valor", objCX_Diario.cx_valor)
        comm.Parameters.Add("@cx_usu", objCX_Diario.cx_usu)
        comm.Parameters.Add("@cx_status", objCX_Diario.cx_status)
        comm.Parameters.Add("@cx_loja", objCX_Diario.cx_loja)
        comm.Parameters.Add("@cx_caixa", objCX_Diario.cx_caixa)
        comm.Parameters.Add("@cx_hora", objCX_Diario.cx_hora)
        comm.Parameters.Add("@cx_codcli", objCX_Diario.cx_codcli)
        comm.Parameters.Add("@cx_nomecli", objCX_Diario.cx_nomecli)
        comm.Parameters.Add("@cx_iddoutor", objCX_Diario.cx_iddoutor)
        comm.Parameters.Add("@cx_doutor", objCX_Diario.cx_doutor)
        comm.Parameters.Add("@cx_comissdoutor", objCX_Diario.cx_comissdoutor)
        comm.Parameters.Add("@cx_idduplreceb", objCX_Diario.cx_idduplreceb)
        comm.Parameters.Add("@cx_tipopag", objCX_Diario.cx_tipopag)
        comm.Parameters.Add("@cx_protetico", objCX_Diario.cx_protetico)
        comm.Parameters.Add("@cx_driniciais", objCX_Diario.cx_driniciais)
        comm.Parameters.Add("@cx_doutor_old", objCX_Diario.cx_doutor_old)
        comm.Parameters.Add("@cx_tpatend_id", objCX_Diario.cx_tpatend_id)
        comm.Parameters.Add("@cx_tpatend", objCX_Diario.cx_tpatend)
        comm.Parameters.Add("@cx_recebido", objCX_Diario.cx_recebido)
        comm.Parameters.Add("@cx_orcamento", objCX_Diario.cx_orcamento)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altCX_Diario(ByVal objCX_Diario As Cl_CaixaDiario, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection)

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


        sql = "UPDATE " & geno.pEsquemaestab & ".caixadiario SET cx_tipo = @cx_tipo, cx_data = @cx_data, cx_grupo = @cx_grupo, "
        sql += "cx_descricao = @cx_descricao, cx_valor = @cx_valor, cx_usuarioalt = @cx_usuarioalt, cx_status = @cx_status, "
        sql += "cx_loja = @cx_loja, cx_caixa = @cx_caixa, cx_hora = @cx_hora, cx_codcli = @cx_codcli, "
        sql += "cx_nomecli = @cx_nomecli, cx_iddoutor = @cx_iddoutor, cx_doutor = @cx_doutor, cx_comissdoutor = @cx_comissdoutor, "
        sql += "cx_idduplreceb = @cx_idduplreceb, cx_tipopag = @cx_tipopag, cx_protetico = @cx_protetico, cx_driniciais = @cx_driniciais, "
        sql += "cx_tpatend_id = @cx_tpatend_id, cx_tpatend = @cx_tpatend, cx_recebido = @cx_recebido, "
        sql += "cx_orcamento = @cx_orcamento WHERE cx_id = @cx_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cx_id", objCX_Diario.cx_id)
        comm.Parameters.Add("@cx_tipo", objCX_Diario.cx_tipo)
        comm.Parameters.Add("@cx_data", Convert.ChangeType(objCX_Diario.cx_data, GetType(Date)))
        comm.Parameters.Add("@cx_grupo", objCX_Diario.cx_grupo)
        comm.Parameters.Add("@cx_descricao", objCX_Diario.cx_descricao)
        comm.Parameters.Add("@cx_valor", objCX_Diario.cx_valor)
        comm.Parameters.Add("@cx_usuarioalt", objCX_Diario.cx_usuarioalt)
        comm.Parameters.Add("@cx_status", objCX_Diario.cx_status)
        comm.Parameters.Add("@cx_loja", objCX_Diario.cx_loja)
        comm.Parameters.Add("@cx_caixa", objCX_Diario.cx_caixa)
        comm.Parameters.Add("@cx_hora", objCX_Diario.cx_hora)
        comm.Parameters.Add("@cx_codcli", objCX_Diario.cx_codcli)
        comm.Parameters.Add("@cx_nomecli", objCX_Diario.cx_nomecli)
        comm.Parameters.Add("@cx_iddoutor", objCX_Diario.cx_iddoutor)
        comm.Parameters.Add("@cx_doutor", objCX_Diario.cx_doutor)
        comm.Parameters.Add("@cx_comissdoutor", objCX_Diario.cx_comissdoutor)
        comm.Parameters.Add("@cx_idduplreceb", objCX_Diario.cx_idduplreceb)
        comm.Parameters.Add("@cx_tipopag", objCX_Diario.cx_tipopag)
        comm.Parameters.Add("@cx_protetico", objCX_Diario.cx_protetico)
        comm.Parameters.Add("@cx_driniciais", objCX_Diario.cx_driniciais)
        comm.Parameters.Add("@cx_tpatend_id", objCX_Diario.cx_tpatend_id)
        comm.Parameters.Add("@cx_tpatend", objCX_Diario.cx_tpatend)
        comm.Parameters.Add("@cx_recebido", objCX_Diario.cx_recebido)
        comm.Parameters.Add("@cx_orcamento", objCX_Diario.cx_orcamento)

        comm.ExecuteNonQuery()
        transacao.Commit()
        Try
            conexao.Close()
        Catch ex As Exception
        End Try


        comm = Nothing : sql = Nothing

    End Sub

    Public Sub altCX_Diario(ByVal objCX_Diario As Cl_CaixaDiario, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE " & geno.pEsquemaestab & ".caixadiario SET cx_tipo = @cx_tipo, cx_data = @cx_data, cx_grupo = @cx_grupo, "
        sql += "cx_descricao = @cx_descricao, cx_valor = @cx_valor, cx_usuarioalt = @cx_usuarioalt, cx_status = @cx_status, "
        sql += "cx_loja = @cx_loja, cx_caixa = @cx_caixa, cx_hora = @cx_hora, cx_codcli = @cx_codcli, "
        sql += "cx_nomecli = @cx_nomecli, cx_iddoutor = @cx_iddoutor, cx_doutor = @cx_doutor, cx_comissdoutor = @cx_comissdoutor, "
        sql += "cx_idduplreceb = @cx_idduplreceb, cx_tipopag = @cx_tipopag, cx_protetico = @cx_protetico, cx_driniciais = @cx_driniciais, "
        sql += "cx_tpatend_id = @cx_tpatend_id, cx_tpatend = @cx_tpatend, cx_recebido = @cx_recebido, "
        sql += "cx_orcamento = @cx_orcamento WHERE cx_id = @cx_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cx_id", objCX_Diario.cx_id)
        comm.Parameters.Add("@cx_tipo", objCX_Diario.cx_tipo)
        comm.Parameters.Add("@cx_data", Convert.ChangeType(objCX_Diario.cx_data, GetType(Date)))
        comm.Parameters.Add("@cx_grupo", objCX_Diario.cx_grupo)
        comm.Parameters.Add("@cx_descricao", objCX_Diario.cx_descricao)
        comm.Parameters.Add("@cx_valor", objCX_Diario.cx_valor)
        comm.Parameters.Add("@cx_usuarioalt", objCX_Diario.cx_usuarioalt)
        comm.Parameters.Add("@cx_status", objCX_Diario.cx_status)
        comm.Parameters.Add("@cx_loja", objCX_Diario.cx_loja)
        comm.Parameters.Add("@cx_caixa", objCX_Diario.cx_caixa)
        comm.Parameters.Add("@cx_hora", objCX_Diario.cx_hora)
        comm.Parameters.Add("@cx_codcli", objCX_Diario.cx_codcli)
        comm.Parameters.Add("@cx_nomecli", objCX_Diario.cx_nomecli)
        comm.Parameters.Add("@cx_iddoutor", objCX_Diario.cx_iddoutor)
        comm.Parameters.Add("@cx_doutor", objCX_Diario.cx_doutor)
        comm.Parameters.Add("@cx_comissdoutor", objCX_Diario.cx_comissdoutor)
        comm.Parameters.Add("@cx_idduplreceb", objCX_Diario.cx_idduplreceb)
        comm.Parameters.Add("@cx_tipopag", objCX_Diario.cx_tipopag)
        comm.Parameters.Add("@cx_protetico", objCX_Diario.cx_protetico)
        comm.Parameters.Add("@cx_driniciais", objCX_Diario.cx_driniciais)
        comm.Parameters.Add("@cx_tpatend_id", objCX_Diario.cx_tpatend_id)
        comm.Parameters.Add("@cx_tpatend", objCX_Diario.cx_tpatend)
        comm.Parameters.Add("@cx_recebido", objCX_Diario.cx_recebido)
        comm.Parameters.Add("@cx_orcamento", objCX_Diario.cx_orcamento)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delCX_Diario(ByVal objCX_Diario As Cl_CaixaDiario, ByVal geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM " & geno.pEsquemaestab & ".caixadiario WHERE cx_id = @cx_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cx_id", objCX_Diario.cx_id)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Sub delCX_Diario(ByVal objCX_Diario As Cl_CaixaDiario, ByVal geno As Cl_Geno, ByVal strConexao As String)

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

        sql = "DELETE FROM " & geno.pEsquemaestab & ".caixadiario WHERE cx_id = @cx_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cx_id", objCX_Diario.cx_id)

        comm.ExecuteNonQuery()
        transacao.Commit()
        conexao.Close()

        MsgBox("Registro DELETADO com Sucesso!")
        comm = Nothing : sql = Nothing
        transacao = Nothing : conexao = Nothing
    End Sub

    Public Function trazValorCX_DiarioDuplic(ByVal idDupl As String, ByVal geno As Cl_Geno) As Double

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sql As String = ""
        Dim valor As Double = 0.0

        Try
            conexao.Open()
        Catch ex As Exception
            Return 0
        End Try

        sql = "SELECT Sum(cx_valor) FROM " & geno.pEsquemaestab & ".caixadiario WHERE cx_idduplreceb = '" & idDupl & "' AND cx_tipo = 'D'"

        comm = New NpgsqlCommand(sql, conexao)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                valor = dr(0)
            Catch ex As Exception
                valor = 0
            End Try
        End While
        dr.Close()
        comm = Nothing : sql = Nothing
        conexao.Close()

        Return valor
    End Function

    Public Function trazLancamentoCX_Diario(idLancamento As Int64, geno As Cl_Geno) As Cl_CaixaDiario

        Dim Cx_Diario As New Cl_CaixaDiario
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearAllPools() : conection = Nothing : Return Cx_Diario

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As String
        Dim dr As NpgsqlDataReader

        Try
            sql += "SELECT cx_tipo, cx_data, cx_grupo, cx_descricao, cx_valor, cx_doutor, cx_codcli, cx_comissdoutor, cx_hora, "
            sql += "cx_protetico, cx_tpatend, cx_recebido, cx_orcamento FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario "
            sql += "WHERE cx_id = @cx_id"
            cmd = New NpgsqlCommand(sql.ToString, conection)
            cmd.Parameters.Add("@cx_id", idLancamento)
            dr = cmd.ExecuteReader

            While dr.Read

                Cx_Diario.cx_id = idLancamento
                Cx_Diario.cx_tipo = dr(0)
                Cx_Diario.cx_data = dr(1)
                Cx_Diario.cx_grupo = dr(2).ToString
                Cx_Diario.cx_descricao = dr(3).ToString
                Cx_Diario.cx_valor = dr(4)
                Cx_Diario.cx_doutor = dr(5).ToString
                Cx_Diario.cx_codcli = dr(6).ToString
                Cx_Diario.cx_comissdoutor = dr(7)
                Cx_Diario.cx_hora = dr(8).ToString
                Cx_Diario.cx_protetico = dr(9).ToString
                Cx_Diario.cx_tpatend = dr(10).ToString
                Cx_Diario.cx_recebido = dr(11)
                Cx_Diario.cx_orcamento = dr(12)

            End While
            dr.Close()

        Catch ex As Exception
            MsgBox("Erro ao trazer Lançamento:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")

        End Try

        cmd.CommandText = "" : sql.Remove(0, sql.ToString.Length) : conection.Close()
        cmd = Nothing : sql = Nothing : conection = Nothing

    End Function

    Public Function trazLancamentoCX_DiarioFULL(idLancamento As Int64, geno As Cl_Geno) As Cl_CaixaDiario
        'Não Implementado ainda!!!


        'Dim Cx_Diario As New Cl_CaixaDiario
        'Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        'Try
        '    conection.Open()
        'Catch ex As Exception
        '    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        '    conection.ClearAllPools() : conection = Nothing : Return Cx_Diario

        'End Try

        'Dim cmd As New NpgsqlCommand
        'Dim sql As String
        'Dim dr As NpgsqlDataReader

        'Try
        '    sql += "SELECT cx_tipo, cx_data, cx_grupo, cx_descricao, cx_valor, cx_doutor, cx_codcli, cx_comissdoutor, cx_hora, "
        '    sql += "cx_protetico, cx_tpatend, cx_recebido, cx_orcamento FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario "
        '    sql += "WHERE cx_id = @cx_id"
        '    cmd = New NpgsqlCommand(sql.ToString, conection)
        '    cmd.Parameters.Add("@cx_id", idLancamento)
        '    dr = cmd.ExecuteReader

        '    While dr.Read

        '        Cx_Diario.cx_id = idLancamento
        '        Cx_Diario.cx_tipo = dr(0)
        '        Cx_Diario.cx_data = dr(1)
        '        Cx_Diario.cx_grupo = dr(2).ToString
        '        Cx_Diario.cx_descricao = dr(3).ToString
        '        Cx_Diario.cx_valor = dr(4)
        '        Cx_Diario.cx_doutor = dr(5).ToString
        '        Cx_Diario.cx_codcli = dr(6).ToString
        '        Cx_Diario.cx_comissdoutor = dr(7)
        '        Cx_Diario.cx_hora = dr(8).ToString
        '        Cx_Diario.cx_protetico = dr(9).ToString
        '        Cx_Diario.cx_tpatend = dr(10).ToString
        '        Cx_Diario.cx_recebido = dr(11)
        '        Cx_Diario.cx_orcamento = dr(12)

        '    End While
        '    dr.Close()

        'Catch ex As Exception
        '    MsgBox("Erro ao trazer Lançamento:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")

        'End Try

        'cmd.CommandText = "" : sql.Remove(0, sql.ToString.Length) : conection.Close()
        'cmd = Nothing : sql = Nothing : conection = Nothing

    End Function

End Class
