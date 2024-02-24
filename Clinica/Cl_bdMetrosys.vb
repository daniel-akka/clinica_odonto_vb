Imports System
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Math
Imports Npgsql
Imports Npgsql.NpgsqlTransaction

Public Class Cl_bdMetrosys
    
    Dim _transacao As NpgsqlTransaction
    Enum opera
        inc
        alt
        exc
        pesq
    End Enum 'operação

    Enum Dia_Semana
        Domingo = 1
        Segunda = 2
        Terça = 3
        Quarta = 4
        Quinta = 5
        Sexta = 6
        Sabado = 7
    End Enum 'Dia_semana


#Region "  * * Manutenção Nota Referenciada * *  "

    Public Sub incNotaref(ByVal clNotaref As GenoNFeXml.Cl_notaref, ByVal clGeno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & clGeno.pEsquemaestab & ".notaref(")
        sqlbuild.Append("refid, refnumero, reftipo, refchave, refcoduf, refaamm, refcnpj, ")
        sqlbuild.Append("refmod, refserie, refecf, refcoo, nt1pp) ")
        sqlbuild.Append("VALUES (DEFAULT, @refnumero, @reftipo, @refchave, @refcoduf, @refaamm, @refcnpj, ")
        sqlbuild.Append("@refmod, @refserie, @refecf, @refcoo, @nt1pp);")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@refnumero", clNotaref.refnumero)
        comm.Parameters.Add("@reftipo", clNotaref.reftipo)
        comm.Parameters.Add("@refchave", clNotaref.refchave)
        comm.Parameters.Add("@refcoduf", clNotaref.refcoduf)
        comm.Parameters.Add("@refaamm", clNotaref.refaamm)
        comm.Parameters.Add("@refcnpj", clNotaref.refcnpj)
        comm.Parameters.Add("@refmod", clNotaref.refmod)
        comm.Parameters.Add("@refserie", clNotaref.refserie)
        comm.Parameters.Add("@refecf", clNotaref.refecf)
        comm.Parameters.Add("@refcoo", clNotaref.refcoo)
        comm.Parameters.Add("@nt1pp", clNotaref.nt1pp)
        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delNotaref(ByVal numero As String, ByVal clGeno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & clGeno.pEsquemaestab & ".notaref WHERE nt1pp = @nt1pp")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@nt1pp", numero)
        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delNotaref(ByVal clNotaref As Cl_notaref, ByVal clGeno As Cl_Geno, ByVal conexao As NpgsqlConnection)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & clGeno.pEsquemaestab & ".notaref WHERE refnumero = @refnumero")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@refnumero", clNotaref.refnumero)
        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

#End Region

#Region "  * * Manutenção da Fatd001 * *  "


    Public Sub incEntradaFatd001(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
        ByVal f_geno As Cl_Geno, ByVal f_entrada As Double, ByVal f_duplicata As Int64, _
        ByVal f_data As Date)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        If conexao.State = ConnectionState.Closed Then conexao.Open()
        sqlbuild.Append("INSERT INTO " & f_geno.pEsquemaestab & ".entradafatd(")
        sqlbuild.Append("e_entrada, e_duplicata, e_data) ")
        sqlbuild.Append("VALUES (@e_entrada, @e_duplicata, @e_data);")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@e_entrada", f_entrada)
        comm.Parameters.Add("@e_duplicata", f_duplicata)

        Try
            comm.Parameters.Add("@e_data", Convert.ChangeType(f_data, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Transaction = transacao
        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incFatd001RetornoMp(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
        ByVal f_geno As String, ByVal f_portad As String, ByVal f_tipo As String, _
        ByVal f_nfat As String, ByVal f_nfisc As String, ByVal f_serie As String, _
        ByVal f_txdesc As Double, ByVal f_duplic As String, ByVal f_emiss As Date, _
        ByVal f_vencto As Date, ByVal f_valor As Double, ByVal f_cartei As String, _
        ByVal f_juros As Double, ByVal f_desc As Double, _
        ByVal f_banco As Double, ByVal f_hist As String, ByVal f_hvenc As String, _
        ByVal f_protest As Double, ByVal f_outros As Double, ByVal f_codi1 As String, _
        ByVal f_codi2 As String, ByVal f_codi3 As String, ByVal f_sit As String, _
        ByVal f_stat As Boolean, ByVal f_loja As String, _
        ByVal f_ctactb As String, ByVal f_ctareduz As String, ByVal f_nnumero As String, _
        ByVal f_imp As String, ByVal f_mtransm As String)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".fatd001(")
        sqlbuild.Append("f_geno, f_portad, f_tipo, f_nfat, f_nfisc, f_serie, f_txdesc, ")
        sqlbuild.Append("f_duplic, f_emiss, f_vencto, f_valor, f_cartei, f_juros, ")
        sqlbuild.Append("f_desc, f_banco, f_hist, f_hvenc, f_protest, f_outros, f_codi1, ")
        sqlbuild.Append("f_codi2, f_codi3, f_sit, f_stat, f_loja, f_ftidx, f_ctactb, ")
        sqlbuild.Append("f_ctareduz, f_nnumero, f_imp, f_mtransm) ")
        sqlbuild.Append("VALUES (@f_geno, @f_portad, @f_tipo, @f_nfat, ")
        sqlbuild.Append("@f_nfisc, @f_serie, @f_txdesc, @f_duplic, @f_emiss, ")
        sqlbuild.Append("@f_vencto, @f_valor, @f_cartei, @f_juros, ")
        sqlbuild.Append("@f_desc, @f_banco, @f_hist, @f_hvenc, @f_protest, @f_outros, ")
        sqlbuild.Append("@f_codi1, @f_codi2, @f_codi3, @f_sit, @f_stat, @f_loja, DEFAULT, ")
        sqlbuild.Append("@f_ctactb, @f_ctareduz, @f_nnumero, @f_imp, @f_mtransm);")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@f_geno", f_geno)
        comm.Parameters.Add("@f_portad", f_portad)
        comm.Parameters.Add("@f_tipo", f_tipo)
        comm.Parameters.Add("@f_nfat", f_nfat)
        comm.Parameters.Add("@f_nfisc", f_nfisc)
        comm.Parameters.Add("@f_serie", f_serie)
        comm.Parameters.Add("@f_txdesc", f_txdesc)
        comm.Parameters.Add("@f_duplic", f_duplic)
        Try
            comm.Parameters.Add("@f_emiss", Convert.ChangeType(f_emiss, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@f_emiss", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        Try
            comm.Parameters.Add("@f_vencto", Convert.ChangeType(f_vencto, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@f_vencto", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@f_valor", f_valor)
        comm.Parameters.Add("@f_cartei", f_cartei)
        comm.Parameters.Add("@f_juros", f_juros)
        comm.Parameters.Add("@f_desc", f_desc)
        comm.Parameters.Add("@f_banco", f_banco)
        comm.Parameters.Add("@f_hist", f_hist)
        comm.Parameters.Add("@f_hvenc", f_hvenc)
        comm.Parameters.Add("@f_protest", f_protest)
        comm.Parameters.Add("@f_outros", f_outros)
        comm.Parameters.Add("@f_codi1", f_codi1)
        comm.Parameters.Add("@f_codi2", f_codi2)
        comm.Parameters.Add("@f_codi3", f_codi3)
        comm.Parameters.Add("@f_sit", f_sit)
        comm.Parameters.Add("@f_stat", f_stat)
        comm.Parameters.Add("@f_loja", f_loja)
        'comm.Parameters.Add("@f_ftidx", f_ftidx)
        comm.Parameters.Add("@f_ctactb", f_ctactb)
        comm.Parameters.Add("@f_ctareduz", f_ctareduz)
        comm.Parameters.Add("@f_nnumero", f_nnumero)
        comm.Parameters.Add("@f_imp", f_imp)
        comm.Parameters.Add("@f_mtransm", f_mtransm)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function trazProxIdFatd001(ByVal Geno As Cl_Geno, ByVal strConection As String) As Int64
        Dim mNumero As Int64 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim conexao As New NpgsqlConnection(strConection)
        Try
            conexao.Open()
        Catch ex As Exception
            Return 0
        End Try
        Dim sqlcmd As String = "SELECT nextval('" & Geno.pEsquemaestab & ".numfatd001_nf_id_seq'::regclass)"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        dr = comm.ExecuteReader
        While dr.Read

            mNumero = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumero
    End Function

    Public Sub SetaIdFatd001(ByVal id As Int64, ByVal Geno As Cl_Geno, ByVal strConection As String)
        Dim mNumero As Int64 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim conexao As New NpgsqlConnection(strConection)
        Try
            conexao.Open()
        Catch ex As Exception
            Return
        End Try
        'SELECT setval('loja1.orca1pp_nt_idx_seq'::regclass, 41) --nextval retornara 42
        Dim sqlcmd As String = "SELECT setval('" & Geno.pEsquemaestab & ".numfatd001_nf_id_seq'::regclass, " & id & ")"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        dr = comm.ExecuteReader
        While dr.Read

            mNumero = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


    End Sub

    Public Function trazMaxIdFatd001(ByVal Geno As Cl_Geno, ByVal strConection As String) As Int64
        Dim mNumero As Int64 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim conexao As New NpgsqlConnection(strConection)
        Try
            conexao.Open()
        Catch ex As Exception
            Return 0
        End Try

        Dim sqlcmd As String = "SELECT Max(nf_id) FROM " & Geno.pEsquemaestab & ".numfatd001"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        dr = comm.ExecuteReader
        While dr.Read

            Try
                mNumero = dr(0)
            Catch ex As Exception
                mNumero = 0
            End Try

        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumero
    End Function

    Public Function vlrPendenciasPartFatd001(ByVal connection As NpgsqlConnection, _
                                             ByVal codPart As String) As Double
        Dim mVlrPendencias As Double = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT SUM(f_valor) FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 WHERE f_portad = " _
        & "@f_portad AND f_sit = 'N'"

        comm = New NpgsqlCommand(sqlcmd.ToString, connection)
        comm.Parameters.Add("@f_portad", codPart)
        dr = comm.ExecuteReader
        While dr.Read

            Try
                mVlrPendencias = dr(0)
            Catch ex As Exception
                mVlrPendencias = 0
            End Try
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing

        Return mVlrPendencias
    End Function

    Public Sub atualTodasSitPartFatd001(ByVal connection As NpgsqlConnection, _
                                            ByVal transacao As NpgsqlTransaction, _
                                            ByVal codPart As String, ByVal sit As Char, _
                                            ByVal dtPagamento As Date)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".fatd001 SET f_sit = @f_sit, f_dtpaga = @f_dtpaga WHERE " _
        & "f_portad = @f_portad AND f_sit = 'N'"
        comm = New NpgsqlCommand(sqlcmd.ToString, connection)

        comm.Transaction = transacao
        comm.Parameters.Add("@f_sit", Convert.ChangeType(sit, GetType(Char)))
        comm.Parameters.Add("@f_portad", codPart)
        comm.Parameters.Add("@f_dtpaga", Convert.ChangeType(dtPagamento, GetType(Date)))

        comm.ExecuteNonQuery()

        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub alteraSitFatd001_Cancelamento(ByVal connection As NpgsqlConnection, _
                                            ByVal transacao As NpgsqlTransaction, _
                                            ByVal fatd001 As Cl_Fatd001)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".fatd001 SET f_sit = @f_sit WHERE " _
        & "f_nfat = @f_nfat AND f_sit = 'N'"
        comm = New NpgsqlCommand(sqlcmd.ToString, connection)

        comm.Transaction = transacao
        comm.Parameters.Add("@f_sit", fatd001.ft_sit)
        comm.Parameters.Add("@f_nfat", fatd001.ft_Nfat)


        comm.ExecuteNonQuery()

        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub alteraDataPagaFatd001_Canc(ByVal connection As NpgsqlConnection, _
                                            ByVal transacao As NpgsqlTransaction, _
                                            ByVal fatd001 As Cl_Fatd001)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".fatd001 SET f_dtpaga = @f_dtpaga WHERE " _
        & "f_nfat = @f_nfat AND f_sit = 'N'"
        comm = New NpgsqlCommand(sqlcmd.ToString, connection)

        comm.Transaction = transacao
        comm.Parameters.Add("@f_dtpaga", Convert.ChangeType(fatd001.ft_dtpaga, GetType(Date)))
        comm.Parameters.Add("@f_nfat", fatd001.ft_Nfat)


        comm.ExecuteNonQuery()

        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function trazNumFatd001_Por_Agendamento(ByVal idAgend As Int64, ByVal geno As Cl_Geno, _
                                                   ByVal strConnection As String) As String
        Dim mNumFatd001 As String = ""
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim connection As New NpgsqlConnection(strConnection)
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexao com Fatura" & ex.Message, MsgBoxStyle.Critical)
            Return mNumFatd001
        End Try
        Dim sqlcmd As String = "SELECT f_nfat FROM " & geno.pEsquemaestab & ".fatd001 WHERE f_agendamento = " _
        & "@f_agendamento LIMIT 1"

        comm = New NpgsqlCommand(sqlcmd.ToString, connection)
        comm.Parameters.Add("@f_agendamento", idAgend)
        dr = comm.ExecuteReader
        While dr.Read
            mNumFatd001 = dr(0).ToString
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing

        Return mNumFatd001
    End Function

    Public Sub IncCarne_a_Receber(ByVal Geno As String, ByVal Portador As String, ByVal tipo As String, ByVal nfat As String, ByVal nfisc As String, ByVal serie As String, _
                                    ByVal txdesc As Double, ByVal Documento As String, ByVal emiss As Date, ByVal vencto As Date, ByVal valor As Double, ByVal cartei As String, _
                                    ByVal dtpaga As Date, ByVal juros As Double, ByVal desconto As Double, ByVal banco As String, ByVal hist As String, ByVal hvenc As String, _
                                    ByVal protesto As Double, ByVal outros As Double, ByVal codi1 As String, ByVal codi2 As String, ByVal codi3 As String, ByVal sit As String, _
                                    ByVal stat As Boolean, ByVal loja As String, ByVal ftidx As String, ByVal ctactb As String, ByVal ctareduz As String, ByVal nnumero As String, _
                                    ByVal imp As String, ByVal mtransm As String, ByVal vendedor As String, ByVal valorpago As Double, ByVal valordevido As Double, ByVal comissao As Double, _
                                    ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        Try
            conexao.Open()
            sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".fatd001(")
            sqlbuild.Append("f_geno, f_portad, f_tipo, f_nfat, f_nfisc, f_serie, f_txdesc,f_duplic, f_emiss, f_vencto,f_valor, f_cartei, f_dtpaga, f_juros, ")
            sqlbuild.Append("f_desc, f_banco, f_hist, f_hvenc, f_protest, f_outros, f_codi1,f_codi2, f_codi3, f_sit, f_stat, f_loja, f_ftidx, f_ctactb,  ")
            sqlbuild.Append("f_ctareduz,f_nnumero, f_imp, f_mtransm, f_vend, f_valorpago, f_valordevido, f_comissao, f_caixa) ")
            sqlbuild.Append("VALUES (@f_geno, @f_portad, @f_tipo, @f_nfat, @f_nfisc, @f_serie, @f_txdesc, @f_duplic, @f_emiss, @f_vencto,@f_valor,")
            sqlbuild.Append("@f_cartei, @f_dtpaga, @f_juros,@f_desc, @f_banco, @f_hist, @f_hvenc, @f_protest, @f_outros, @f_codi1, @f_codi2, @f_codi3,")
            sqlbuild.Append("@f_sit, @f_stat, @f_loja, Default, @f_ctactb, @f_ctareduz, @f_nnumero, @f_imp, @f_mtransm, @f_vend, @f_valorpago,")
            sqlbuild.Append("@f_valordevido, @f_comissao, @f_caixa)")

            comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
            comm.Parameters.Add("@f_geno", Geno)
            comm.Parameters.Add("@f_portad", Portador)
            comm.Parameters.Add("@f_tipo", tipo)
            comm.Parameters.Add("@f_nfat", nfat)
            comm.Parameters.Add("@f_nfisc", nfisc)
            comm.Parameters.Add("@f_serie", serie)
            comm.Parameters.Add("@f_txdesc", txdesc)
            comm.Parameters.Add("@f_duplic", Documento)
            comm.Parameters.Add("@f_emiss", Convert.ChangeType(emiss, GetType(Date)))
            comm.Parameters.Add("@f_vencto", Convert.ChangeType(vencto, GetType(Date)))
            comm.Parameters.Add("@f_valor", valor)
            comm.Parameters.Add("@f_cartei", cartei)
            comm.Parameters.Add("@f_dtpaga", NpgsqlTypes.NpgsqlDbType.Date) ' confirmar registro
            comm.Parameters.Add("@f_juros", juros)
            comm.Parameters.Add("@f_desc", desconto)
            comm.Parameters.Add("@f_banco", banco)
            comm.Parameters.Add("@f_hist", hist)
            comm.Parameters.Add("@f_hvenc", hvenc)
            comm.Parameters.Add("@f_protest", protesto)
            comm.Parameters.Add("@f_outros", outros)
            comm.Parameters.Add("@f_codi1", codi1)
            comm.Parameters.Add("@f_codi2", codi2)
            comm.Parameters.Add("@f_codi3", codi3)
            comm.Parameters.Add("@f_sit", sit)
            comm.Parameters.Add("@f_stat", stat)
            comm.Parameters.Add("@f_loja", loja)
            ' comm.Parameters.Add("@f_ftidx", ftidx)  Automastico
            comm.Parameters.Add("@f_ctactb", ctactb)
            comm.Parameters.Add("@f_ctareduz", ctareduz)
            comm.Parameters.Add("@f_nnumero", nnumero)
            comm.Parameters.Add("@f_imp", imp)
            comm.Parameters.Add("@f_mtransm", mtransm)
            comm.Parameters.Add("@f_vend", vendedor)
            comm.Parameters.Add("@f_valorpago", valorpago)
            comm.Parameters.Add("@f_valordevido", valordevido)
            comm.Parameters.Add("@f_comissao", comissao)
            comm.Parameters.Add("@f_caixa", MdlUsuarioLogando._codcaixa)

            comm.Transaction = transaction
            comm.ExecuteNonQuery()

            conexao.Close()
            comm = Nothing
            sqlbuild = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Public Sub IncNP_a_Receber(ByVal qtdeParcelas As Int16, ByVal Geno As String, ByVal Portador As String, ByVal tipo As String, ByVal nfat As String, ByVal nfisc As String, ByVal serie As String, _
                                    ByVal txdesc As Double, ByVal Documento As String, ByVal emiss As Date, ByVal vencto As Date, ByVal valor As Double, ByVal cartei As String, _
                                    ByVal dtpaga As Date, ByVal juros As Double, ByVal desconto As Double, ByVal banco As String, ByVal hist As String, ByVal hvenc As String, _
                                    ByVal protesto As Double, ByVal outros As Double, ByVal codi1 As String, ByVal codi2 As String, ByVal codi3 As String, ByVal sit As String, _
                                    ByVal stat As Boolean, ByVal loja As String, ByVal ftidx As String, ByVal ctactb As String, ByVal ctareduz As String, ByVal nnumero As String, _
                                    ByVal imp As String, ByVal mtransm As String, ByVal vendedor As String, ByVal valorpago As Double, ByVal valordevido As Double, ByVal comissao As Double, _
                                    ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        Try

            If conexao.State = ConnectionState.Closed Then conexao.Open()
            sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".fatd001(")
            sqlbuild.Append("f_geno, f_portad, f_tipo, f_nfat, f_nfisc, f_serie, f_txdesc,f_duplic, f_emiss, f_vencto,f_valor, f_cartei, f_dtpaga, f_juros, ")
            sqlbuild.Append("f_desc, f_banco, f_hist, f_hvenc, f_protest, f_outros, f_codi1,f_codi2, f_codi3, f_sit, f_stat, f_loja, f_ftidx, f_ctactb,  ")
            sqlbuild.Append("f_ctareduz,f_nnumero, f_imp, f_mtransm, f_vend, f_valorpago, f_valordevido, f_comissao, f_parcelas, f_caixa) ")
            sqlbuild.Append("VALUES (@f_geno, @f_portad, @f_tipo, @f_nfat, @f_nfisc, @f_serie, @f_txdesc, @f_duplic, @f_emiss, @f_vencto,@f_valor,")
            sqlbuild.Append("@f_cartei, @f_dtpaga, @f_juros,@f_desc, @f_banco, @f_hist, @f_hvenc, @f_protest, @f_outros, @f_codi1, @f_codi2, @f_codi3,")
            sqlbuild.Append("@f_sit, @f_stat, @f_loja, Default, @f_ctactb, @f_ctareduz, @f_nnumero, @f_imp, @f_mtransm, @f_vend, @f_valorpago,")
            sqlbuild.Append("@f_valordevido, @f_comissao, @f_parcelas, @f_caixa)")

            comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
            comm.Parameters.Add("@f_geno", Geno)
            comm.Parameters.Add("@f_portad", Portador)
            comm.Parameters.Add("@f_tipo", tipo)
            comm.Parameters.Add("@f_nfat", nfat)
            comm.Parameters.Add("@f_nfisc", nfisc)
            comm.Parameters.Add("@f_serie", serie)
            comm.Parameters.Add("@f_txdesc", txdesc)
            comm.Parameters.Add("@f_duplic", Documento)
            comm.Parameters.Add("@f_emiss", Convert.ChangeType(emiss, GetType(Date)))
            comm.Parameters.Add("@f_vencto", Convert.ChangeType(vencto, GetType(Date)))
            comm.Parameters.Add("@f_valor", valor)
            comm.Parameters.Add("@f_cartei", cartei)
            comm.Parameters.Add("@f_dtpaga", NpgsqlTypes.NpgsqlDbType.Date) ' confirmar registro
            comm.Parameters.Add("@f_juros", juros)
            comm.Parameters.Add("@f_desc", desconto)
            comm.Parameters.Add("@f_banco", banco)
            comm.Parameters.Add("@f_hist", hist)
            comm.Parameters.Add("@f_hvenc", hvenc)
            comm.Parameters.Add("@f_protest", protesto)
            comm.Parameters.Add("@f_outros", outros)
            comm.Parameters.Add("@f_codi1", codi1)
            comm.Parameters.Add("@f_codi2", codi2)
            comm.Parameters.Add("@f_codi3", codi3)
            comm.Parameters.Add("@f_sit", sit)
            comm.Parameters.Add("@f_stat", stat)
            comm.Parameters.Add("@f_loja", loja)
            ' comm.Parameters.Add("@f_ftidx", ftidx)  Automastico
            comm.Parameters.Add("@f_ctactb", ctactb)
            comm.Parameters.Add("@f_ctareduz", ctareduz)
            comm.Parameters.Add("@f_nnumero", nnumero)
            comm.Parameters.Add("@f_imp", imp)
            comm.Parameters.Add("@f_mtransm", mtransm)
            comm.Parameters.Add("@f_vend", vendedor)
            comm.Parameters.Add("@f_valorpago", valorpago)
            comm.Parameters.Add("@f_valordevido", valordevido)
            comm.Parameters.Add("@f_comissao", comissao)
            comm.Parameters.Add("@f_parcelas", qtdeParcelas)
            comm.Parameters.Add("@f_caixa", MdlUsuarioLogando._codcaixa)

            comm.Transaction = transaction
            comm.ExecuteNonQuery()

            conexao.Close()
            comm = Nothing
            sqlbuild = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Public Sub IncNP_a_Receber(ByVal agend1 As Cl_Agendamento1, ByVal qtdeParcelas As Int16, ByVal Geno As String, ByVal Portador As String, ByVal tipo As String, ByVal nfat As String, ByVal nfisc As String, ByVal serie As String, _
                                    ByVal txdesc As Double, ByVal Documento As String, ByVal emiss As Date, ByVal vencto As Date, ByVal valor As Double, ByVal cartei As String, _
                                    ByVal dtpaga As Date, ByVal juros As Double, ByVal desconto As Double, ByVal banco As String, ByVal hist As String, ByVal hvenc As String, _
                                    ByVal protesto As Double, ByVal outros As Double, ByVal codi1 As String, ByVal codi2 As String, ByVal codi3 As String, ByVal sit As String, _
                                    ByVal stat As Boolean, ByVal loja As String, ByVal ftidx As String, ByVal ctactb As String, ByVal ctareduz As String, ByVal nnumero As String, _
                                    ByVal imp As String, ByVal mtransm As String, ByVal vendedor As String, ByVal valorpago As Double, ByVal valordevido As Double, ByVal comissao As Double, _
                                    ByVal txCobrada As Double, ByVal vlTxCobrada As Double, ByVal Doutor As String, ByVal Hora As String, _
                                    ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        If conexao.State = ConnectionState.Closed Then conexao.Open()
        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".fatd001(")
        sqlbuild.Append("f_geno, f_portad, f_tipo, f_nfat, f_nfisc, f_serie, f_txdesc,f_duplic, f_emiss, f_vencto,f_valor, f_cartei, f_dtpaga, f_juros, ")
        sqlbuild.Append("f_desc, f_banco, f_hist, f_hvenc, f_protest, f_outros, f_codi1,f_codi2, f_codi3, f_sit, f_stat, f_loja, f_ftidx, f_ctactb,  ")
        sqlbuild.Append("f_ctareduz,f_nnumero, f_imp, f_mtransm, f_vend, f_valorpago, f_valordevido, f_comissao, f_agendamento, f_parcelas, f_caixa, ")
        sqlbuild.Append("f_txcobrada, f_vltxcobrada, f_usuarioinc, f_doutor, f_hora) ")
        sqlbuild.Append("VALUES (@f_geno, @f_portad, @f_tipo, @f_nfat, @f_nfisc, @f_serie, @f_txdesc, @f_duplic, @f_emiss, @f_vencto,@f_valor,")
        sqlbuild.Append("@f_cartei, @f_dtpaga, @f_juros,@f_desc, @f_banco, @f_hist, @f_hvenc, @f_protest, @f_outros, @f_codi1, @f_codi2, @f_codi3,")
        sqlbuild.Append("@f_sit, @f_stat, @f_loja, Default, @f_ctactb, @f_ctareduz, @f_nnumero, @f_imp, @f_mtransm, @f_vend, @f_valorpago,")
        sqlbuild.Append("@f_valordevido, @f_comissao, @f_agendamento, @f_parcelas, @f_caixa, @f_txcobrada, @f_vltxcobrada, @f_usuarioinc, @f_doutor, @f_hora)")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@f_geno", Geno)
        comm.Parameters.Add("@f_portad", Portador)
        comm.Parameters.Add("@f_tipo", tipo)
        comm.Parameters.Add("@f_nfat", nfat)
        comm.Parameters.Add("@f_nfisc", nfisc)
        comm.Parameters.Add("@f_serie", serie)
        comm.Parameters.Add("@f_txdesc", txdesc)
        comm.Parameters.Add("@f_duplic", Documento)
        comm.Parameters.Add("@f_emiss", Convert.ChangeType(emiss, GetType(Date)))
        comm.Parameters.Add("@f_vencto", Convert.ChangeType(vencto, GetType(Date)))
        comm.Parameters.Add("@f_valor", valor)
        comm.Parameters.Add("@f_cartei", cartei)
        comm.Parameters.Add("@f_dtpaga", NpgsqlTypes.NpgsqlDbType.Date) ' confirmar registro
        comm.Parameters.Add("@f_juros", juros)
        comm.Parameters.Add("@f_desc", desconto)
        comm.Parameters.Add("@f_banco", banco)
        comm.Parameters.Add("@f_hist", hist)
        comm.Parameters.Add("@f_hvenc", hvenc)
        comm.Parameters.Add("@f_protest", protesto)
        comm.Parameters.Add("@f_outros", outros)
        comm.Parameters.Add("@f_codi1", codi1)
        comm.Parameters.Add("@f_codi2", codi2)
        comm.Parameters.Add("@f_codi3", codi3)
        comm.Parameters.Add("@f_sit", sit)
        comm.Parameters.Add("@f_stat", stat)
        comm.Parameters.Add("@f_loja", loja)
        ' comm.Parameters.Add("@f_ftidx", ftidx)  Automastico
        comm.Parameters.Add("@f_ctactb", ctactb)
        comm.Parameters.Add("@f_ctareduz", ctareduz)
        comm.Parameters.Add("@f_nnumero", nnumero)
        comm.Parameters.Add("@f_imp", imp)
        comm.Parameters.Add("@f_mtransm", mtransm)
        comm.Parameters.Add("@f_vend", vendedor)
        comm.Parameters.Add("@f_valorpago", valorpago)
        comm.Parameters.Add("@f_valordevido", valordevido)
        comm.Parameters.Add("@f_comissao", comissao)
        comm.Parameters.Add("@f_agendamento", agend1.a_id)
        comm.Parameters.Add("@f_parcelas", qtdeParcelas)
        comm.Parameters.Add("@f_caixa", MdlUsuarioLogando._codcaixa)
        comm.Parameters.Add("@f_txcobrada", txCobrada)
        comm.Parameters.Add("@f_vltxcobrada", vlTxCobrada)
        comm.Parameters.Add("@f_usuarioinc", MdlUsuarioLogando._usuarioLogin)
        comm.Parameters.Add("@f_doutor", Doutor)
        comm.Parameters.Add("@f_hora", Hora)


        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        conexao.Close()
        comm = Nothing
        sqlbuild = Nothing

    End Sub

#End Region

#Region "* *  Manutenção de Usuário  * *"

    Public Sub incUsuario(ByVal objUsuario As Cl_Usuario, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO usuario(")
        sqlbuild.Append("u_id, u_login, u_nome, u_senha, u_privilegio, u_bloqueado, u_datanascimento, u_local, ")
        sqlbuild.Append("u_codvendedor, u_cargo, u_codcaixa ) VALUES (DEFAULT, @u_login, @u_nome, @u_senha, @u_privilegio, @u_bloqueado, ")
        sqlbuild.Append("@u_datanascimento, @u_local, @u_codvendedor, @u_cargo, @u_codcaixa );")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@u_login", objUsuario.pLogin)
        comm.Parameters.Add("@u_nome", objUsuario.pNome)
        comm.Parameters.Add("@u_senha", objUsuario.pSenha)
        comm.Parameters.Add("@u_privilegio", objUsuario.pPrivilegio)
        comm.Parameters.Add("@u_bloqueado", objUsuario.pBloqueado)
        Try
            comm.Parameters.Add("@u_datanascimento", Convert.ChangeType(objUsuario.pDataNascimento, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@u_datanascimento", NpgsqlTypes.NpgsqlDbType.Date)
        End Try
        comm.Parameters.Add("@u_local", objUsuario.pLocal)
        comm.Parameters.Add("@u_codvendedor", objUsuario.pCodVendedor)
        comm.Parameters.Add("@u_cargo", objUsuario.pCargo)
        comm.Parameters.Add("@u_codcaixa", objUsuario.pCodCaixa)


        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altUsuario(ByVal objUsuario As Cl_Usuario, ByVal idUsuario As Int32, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE usuario SET ")
        sqlbuild.Append("u_login = @u_login, u_nome = @u_nome, u_senha = @u_senha, u_privilegio = @u_privilegio, ")
        sqlbuild.Append("u_bloqueado = @u_bloqueado, u_datanascimento = @u_datanascimento, u_local = @u_local, ")
        sqlbuild.Append("u_codvendedor = @u_codvendedor, u_cargo = @u_cargo, u_codcaixa = @u_codcaixa WHERE u_id = @u_id")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@u_id", idUsuario)
        comm.Parameters.Add("@u_login", objUsuario.pLogin)
        comm.Parameters.Add("@u_nome", objUsuario.pNome)
        comm.Parameters.Add("@u_senha", objUsuario.pSenha)
        comm.Parameters.Add("@u_privilegio", objUsuario.pPrivilegio)
        comm.Parameters.Add("@u_bloqueado", objUsuario.pBloqueado)
        comm.Parameters.Add("@u_datanascimento", Convert.ChangeType(objUsuario.pDataNascimento, GetType(Date)))
        comm.Parameters.Add("@u_local", objUsuario.pLocal)
        comm.Parameters.Add("@u_codvendedor", objUsuario.pCodVendedor)
        comm.Parameters.Add("@u_cargo", objUsuario.pCargo)
        comm.Parameters.Add("@u_codcaixa", objUsuario.pCodCaixa)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incUsuarioTelas(ByVal objUsuarioTelas As Cl_UsuarioTelas, ByVal conexao As NpgsqlConnection, _
                               ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO usuariotelas(")
        sqlbuild.Append("tl_id, tl_idusuario, tl_cadastros, tl_cadcliente, tl_cadvendedor, ")
        sqlbuild.Append("tl_cadusuario, tl_cadtitular, tl_cadcidade, tl_cadservico, tl_cadgeno, ")
        sqlbuild.Append("tl_movimentos, tl_movpedido, tl_movorcamento, tl_movtransferencia, ")
        sqlbuild.Append("tl_movnfe, tl_cupom, tl_cpprevenda, tl_cpvendadireta, tl_cpconfiguracao, ")
        sqlbuild.Append("tl_estoque, tl_estpesquisa, tl_estrestaura, tl_estimplantacao, ")
        sqlbuild.Append("tl_estpedidocompras, tl_estcompras, tl_estatualizacao, tl_financeiro, ")
        sqlbuild.Append("tl_finpagamentos, tl_finrecebimentos, tl_finfluxocaixa, tl_findespesas, ")
        sqlbuild.Append("tl_finchqpredatado, tl_manutencao, tl_manemprestimos, tl_mantrocas, ")
        sqlbuild.Append("tl_manpalmtop, tl_mancidadesibge, tl_contabil, tl_ctbarqdigitais, ")
        sqlbuild.Append("tl_ctblivrosfiscais, tl_ctbcontador, tl_ctbcfop, tl_parametros, ")
        sqlbuild.Append("tl_paracontrole, tl_paraultilitarios, tl_parabackup, btn_cancelarexcluir, tl_cadcomodato, ")
        sqlbuild.Append("tl_cadautomovel, tl_cadgerais, tl_cadgerente, tl_movrequisicao, tl_movemispedido, ")
        sqlbuild.Append("tl_movgeramapa, tl_mapas, tl_mpvenda, tl_mpretornovenda, tl_estrelatorios, ")
        sqlbuild.Append("tl_paraconfiguracao, tl_pagoaentregar, btn_carne, tl_movagendamentos)")
        sqlbuild.Append("VALUES (DEFAULT, @tl_idusuario, @tl_cadastros, @tl_cadcliente, @tl_cadvendedor, ")
        sqlbuild.Append("@tl_cadusuario, @tl_cadtitular, @tl_cadcidade, @tl_cadservico, @tl_cadgeno, ")
        sqlbuild.Append("@tl_movimentos, @tl_movpedido, @tl_movorcamento, @tl_movtransferencia, ")
        sqlbuild.Append("@tl_movnfe, @tl_cupom, @tl_cpprevenda, @tl_cpvendadireta, @tl_cpconfiguracao, ")
        sqlbuild.Append("@tl_estoque, @tl_estpesquisa, @tl_estrestaura, @tl_estimplantacao, ")
        sqlbuild.Append("@tl_estpedidocompras, @tl_estcompras, @tl_estatualizacao, @tl_financeiro, ")
        sqlbuild.Append("@tl_finpagamentos, @tl_finrecebimentos, @tl_finfluxocaixa, @tl_findespesas, ")
        sqlbuild.Append("@tl_finchqpredatado, @tl_manutencao, @tl_manemprestimos, @tl_mantrocas, ")
        sqlbuild.Append("@tl_manpalmtop, @tl_mancidadesibge, @tl_contabil, @tl_ctbarqdigitais, ")
        sqlbuild.Append("@tl_ctblivrosfiscais, @tl_ctbcontador, @tl_ctbcfop, @tl_parametros, ")
        sqlbuild.Append("@tl_paracontrole, @tl_paraultilitarios, @tl_parabackup, @btn_cancelarexcluir, @tl_cadcomodato, ")
        sqlbuild.Append("@tl_cadautomovel, @tl_cadgerais, @tl_cadgerente, @tl_movrequisicao, @tl_movemispedido, ")
        sqlbuild.Append("@tl_movgeramapa, @tl_mapas, @tl_mpvenda, @tl_mpretornovenda, @tl_estrelatorios, ")
        sqlbuild.Append("@tl_paraconfiguracao, @tl_pagoaentregar, @btn_carne, @tl_movagendamentos)")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@tl_idusuario", objUsuarioTelas.pIdUsuario)
        'Cadastros...
        comm.Parameters.Add("@tl_cadastros", objUsuarioTelas.pTl_Cadastros)
        comm.Parameters.Add("@tl_cadcliente", objUsuarioTelas.pTl_cadcliente)
        comm.Parameters.Add("@tl_cadvendedor", objUsuarioTelas.pTl_cadvendedor)
        comm.Parameters.Add("@tl_cadusuario", objUsuarioTelas.pTl_cadusuario)
        comm.Parameters.Add("@tl_cadtitular", objUsuarioTelas.pTl_cadtitular)
        comm.Parameters.Add("@tl_cadcidade", objUsuarioTelas.pTl_cadcidade)
        comm.Parameters.Add("@tl_cadcomodato", objUsuarioTelas.pTl_cadcomodato)
        comm.Parameters.Add("@tl_cadservico", objUsuarioTelas.pTl_cadservico)
        comm.Parameters.Add("@tl_cadautomovel", objUsuarioTelas.pTl_cadautomovel)
        comm.Parameters.Add("@tl_cadgerais", objUsuarioTelas.pTl_cadgerais)
        comm.Parameters.Add("@tl_cadgerente", objUsuarioTelas.pTl_cadgerente)
        comm.Parameters.Add("@tl_cadgeno", objUsuarioTelas.pTl_cadgeno)
        'Movimentos...
        comm.Parameters.Add("@tl_movimentos", objUsuarioTelas.pTl_movimentos)
        comm.Parameters.Add("@tl_movpedido", objUsuarioTelas.pTl_movpedido)
        comm.Parameters.Add("@tl_movorcamento", objUsuarioTelas.pTl_movorcamento)
        comm.Parameters.Add("@tl_movtransferencia", objUsuarioTelas.pTl_movtransferencia)
        comm.Parameters.Add("@tl_movnfe", objUsuarioTelas.pTl_movnfe)
        comm.Parameters.Add("@tl_movrequisicao", objUsuarioTelas.pTl_movrequisicao)
        comm.Parameters.Add("@tl_movemispedido", objUsuarioTelas.pTl_movemisspedido)
        comm.Parameters.Add("@tl_movgeramapa", objUsuarioTelas.pTl_movgeramapa)
        comm.Parameters.Add("@tl_pagoaentregar", objUsuarioTelas.pTl_movpagoentregar)
        comm.Parameters.Add("@btn_cancelarexcluir", objUsuarioTelas.pBtn_cancelarExcluir)
        comm.Parameters.Add("@btn_carne", objUsuarioTelas.pBtn_carne)
        comm.Parameters.Add("@tl_movagendamentos", objUsuarioTelas.pTl_movAgendamentos)

        'Mapas
        comm.Parameters.Add("@tl_mapas", objUsuarioTelas.pTl_mapas)
        comm.Parameters.Add("@tl_mpvenda", objUsuarioTelas.pTl_mpvenda)
        comm.Parameters.Add("@tl_mpretornovenda", objUsuarioTelas.pTl_mpretornovenda)
        'Cupom...
        comm.Parameters.Add("@tl_cupom", objUsuarioTelas.pTl_cupom)
        comm.Parameters.Add("@tl_cpprevenda", objUsuarioTelas.pTl_cpprevenda)
        comm.Parameters.Add("@tl_cpvendadireta", objUsuarioTelas.pTl_cpvendadireta)
        comm.Parameters.Add("@tl_cpconfiguracao", objUsuarioTelas.pTl_cpconfiguracao)
        'Estoque...
        comm.Parameters.Add("@tl_estoque", objUsuarioTelas.pTl_estoque)
        comm.Parameters.Add("@tl_estpesquisa", objUsuarioTelas.pTl_estpesquisa)
        comm.Parameters.Add("@tl_estrestaura", objUsuarioTelas.pTl_estrestaura)
        comm.Parameters.Add("@tl_estimplantacao", objUsuarioTelas.pTl_estimplantacao)
        comm.Parameters.Add("@tl_estpedidocompras", objUsuarioTelas.pTl_estpedidocompras)
        comm.Parameters.Add("@tl_estcompras", objUsuarioTelas.pTl_estcompras)
        comm.Parameters.Add("@tl_estatualizacao", objUsuarioTelas.pTl_estatualizacao)
        comm.Parameters.Add("@tl_estrelatorios", objUsuarioTelas.pTl_estrelatorios)
        'Financeiro...
        comm.Parameters.Add("@tl_financeiro", objUsuarioTelas.pTl_financeiro)
        comm.Parameters.Add("@tl_finpagamentos", objUsuarioTelas.pTl_finpagamentos)
        comm.Parameters.Add("@tl_finrecebimentos", objUsuarioTelas.pTl_finrecebimentos)
        comm.Parameters.Add("@tl_finfluxocaixa", objUsuarioTelas.pTl_finfluxocaixa)
        comm.Parameters.Add("@tl_findespesas", objUsuarioTelas.pTl_findespesas)
        comm.Parameters.Add("@tl_finchqpredatado", objUsuarioTelas.pTl_finchqPreDatado)
        'Manutenção...
        comm.Parameters.Add("@tl_manutencao", objUsuarioTelas.pTl_manutencao)
        comm.Parameters.Add("@tl_manemprestimos", objUsuarioTelas.pTl_manemprestimos)
        comm.Parameters.Add("@tl_mantrocas", objUsuarioTelas.pTl_mantrocas)
        comm.Parameters.Add("@tl_manpalmtop", objUsuarioTelas.pTl_manpalmtop)
        comm.Parameters.Add("@tl_mancidadesibge", objUsuarioTelas.pTl_mancidadesibge)
        'Contabil...
        comm.Parameters.Add("@tl_contabil", objUsuarioTelas.pTl_contabil)
        comm.Parameters.Add("@tl_ctbarqdigitais", objUsuarioTelas.pTl_ctbarqdigitais)
        comm.Parameters.Add("@tl_ctblivrosfiscais", objUsuarioTelas.pTl_ctblivrosfiscais)
        comm.Parameters.Add("@tl_ctbcontador", objUsuarioTelas.pTl_ctbcontador)
        comm.Parameters.Add("@tl_ctbcfop", objUsuarioTelas.pTl_ctbcfop)
        'Parametros
        comm.Parameters.Add("@tl_parametros", objUsuarioTelas.pTl_parametros)
        comm.Parameters.Add("@tl_paracontrole", objUsuarioTelas.pTl_paracontrole)
        comm.Parameters.Add("@tl_paraultilitarios", objUsuarioTelas.pTl_paraultilitarios)
        comm.Parameters.Add("@tl_parabackup", objUsuarioTelas.pTl_parabackup)
        comm.Parameters.Add("@tl_paraconfiguracao", objUsuarioTelas.pTl_paraconfiguracao)


        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altUsuarioTelas(ByVal objUsuarioTelas As Cl_UsuarioTelas, ByVal conexao As NpgsqlConnection, _
                               ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE usuariotelas SET ")
        sqlbuild.Append("tl_cadastros = @tl_cadastros, tl_cadcliente = @tl_cadcliente, tl_cadvendedor = @tl_cadvendedor, ")
        sqlbuild.Append("tl_cadusuario = @tl_cadusuario, tl_cadtitular = @tl_cadtitular, tl_cadcidade = @tl_cadcidade, tl_cadservico = @tl_cadservico, tl_cadgeno = @tl_cadgeno, ")
        sqlbuild.Append("tl_movimentos = @tl_movimentos, tl_movpedido = @tl_movpedido, tl_movorcamento = @tl_movorcamento, tl_movtransferencia = @tl_movtransferencia, ")
        sqlbuild.Append("tl_movnfe = @tl_movnfe, tl_cupom = @tl_cupom, tl_cpprevenda = @tl_cpprevenda, tl_cpvendadireta = @tl_cpvendadireta, tl_cpconfiguracao = @tl_cpconfiguracao, ")
        sqlbuild.Append("tl_estoque = @tl_estoque, tl_estpesquisa = @tl_estpesquisa, tl_estrestaura = @tl_estrestaura, tl_estimplantacao = @tl_estimplantacao, ")
        sqlbuild.Append("tl_estpedidocompras = @tl_estpedidocompras, tl_estcompras = @tl_estcompras, tl_estatualizacao = @tl_estatualizacao, tl_financeiro = @tl_financeiro, ")
        sqlbuild.Append("tl_finpagamentos = @tl_finpagamentos, tl_finrecebimentos = @tl_finrecebimentos, tl_finfluxocaixa = @tl_finfluxocaixa, tl_findespesas = @tl_findespesas, ")
        sqlbuild.Append("tl_finchqpredatado = @tl_finchqpredatado, tl_manutencao = @tl_manutencao, tl_manemprestimos = @tl_manemprestimos, tl_mantrocas = @tl_mantrocas, ")
        sqlbuild.Append("tl_manpalmtop = @tl_manpalmtop, tl_mancidadesibge = @tl_mancidadesibge, tl_contabil = @tl_contabil, tl_ctbarqdigitais = @tl_ctbarqdigitais, ")
        sqlbuild.Append("tl_ctblivrosfiscais = @tl_ctblivrosfiscais, tl_ctbcontador = @tl_ctbcontador, tl_ctbcfop = @tl_ctbcfop, tl_parametros = @tl_parametros, ")
        sqlbuild.Append("tl_paracontrole = @tl_paracontrole, tl_paraultilitarios = @tl_paraultilitarios, tl_parabackup = @tl_parabackup, btn_cancelarexcluir = @btn_cancelarexcluir, ")
        sqlbuild.Append("tl_cadcomodato = @tl_cadcomodato, tl_cadautomovel = @tl_cadautomovel, tl_cadgerais = @tl_cadgerais, tl_cadgerente = @tl_cadgerente, ")
        sqlbuild.Append("tl_movrequisicao = @tl_movrequisicao, tl_movemispedido = @tl_movemispedido, tl_movgeramapa = @tl_movgeramapa, tl_mapas = @tl_mapas, tl_mpvenda = @tl_mpvenda, ")
        sqlbuild.Append("tl_mpretornovenda = @tl_mpretornovenda, tl_estrelatorios = @tl_estrelatorios, tl_paraconfiguracao = @tl_paraconfiguracao, ")
        sqlbuild.Append("tl_pagoaentregar = @tl_pagoaentregar, btn_carne = @btn_carne, tl_movagendamentos = @tl_movagendamentos WHERE tl_idusuario = @tl_idusuario")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@tl_idusuario", objUsuarioTelas.pIdUsuario)
        'Cadastros...
        comm.Parameters.Add("@tl_cadastros", objUsuarioTelas.pTl_Cadastros)
        comm.Parameters.Add("@tl_cadcliente", objUsuarioTelas.pTl_cadcliente)
        comm.Parameters.Add("@tl_cadvendedor", objUsuarioTelas.pTl_cadvendedor)
        comm.Parameters.Add("@tl_cadusuario", objUsuarioTelas.pTl_cadusuario)
        comm.Parameters.Add("@tl_cadtitular", objUsuarioTelas.pTl_cadtitular)
        comm.Parameters.Add("@tl_cadcidade", objUsuarioTelas.pTl_cadcidade)
        comm.Parameters.Add("@tl_cadcomodato", objUsuarioTelas.pTl_cadcomodato)
        comm.Parameters.Add("@tl_cadservico", objUsuarioTelas.pTl_cadservico)
        comm.Parameters.Add("@tl_cadautomovel", objUsuarioTelas.pTl_cadautomovel)
        comm.Parameters.Add("@tl_cadgerais", objUsuarioTelas.pTl_cadgerais)
        comm.Parameters.Add("@tl_cadgerente", objUsuarioTelas.pTl_cadgerente)
        comm.Parameters.Add("@tl_cadgeno", objUsuarioTelas.pTl_cadgeno)
        'Movimentos...
        comm.Parameters.Add("@tl_movimentos", objUsuarioTelas.pTl_movimentos)
        comm.Parameters.Add("@tl_movpedido", objUsuarioTelas.pTl_movpedido)
        comm.Parameters.Add("@tl_movorcamento", objUsuarioTelas.pTl_movorcamento)
        comm.Parameters.Add("@tl_movtransferencia", objUsuarioTelas.pTl_movtransferencia)
        comm.Parameters.Add("@tl_movnfe", objUsuarioTelas.pTl_movnfe)
        comm.Parameters.Add("@tl_movrequisicao", objUsuarioTelas.pTl_movrequisicao)
        comm.Parameters.Add("@tl_movemispedido", objUsuarioTelas.pTl_movemisspedido)
        comm.Parameters.Add("@tl_movgeramapa", objUsuarioTelas.pTl_movgeramapa)
        comm.Parameters.Add("@tl_pagoaentregar", objUsuarioTelas.pTl_movpagoentregar)
        comm.Parameters.Add("@btn_cancelarexcluir", objUsuarioTelas.pBtn_cancelarExcluir)
        comm.Parameters.Add("@btn_carne", objUsuarioTelas.pBtn_carne)
        comm.Parameters.Add("@tl_movagendamentos", objUsuarioTelas.pTl_movAgendamentos)

        'Mapas
        comm.Parameters.Add("@tl_mapas", objUsuarioTelas.pTl_mapas)
        comm.Parameters.Add("@tl_mpvenda", objUsuarioTelas.pTl_mpvenda)
        comm.Parameters.Add("@tl_mpretornovenda", objUsuarioTelas.pTl_mpretornovenda)
        'Cupom...
        comm.Parameters.Add("@tl_cupom", objUsuarioTelas.pTl_cupom)
        comm.Parameters.Add("@tl_cpprevenda", objUsuarioTelas.pTl_cpprevenda)
        comm.Parameters.Add("@tl_cpvendadireta", objUsuarioTelas.pTl_cpvendadireta)
        comm.Parameters.Add("@tl_cpconfiguracao", objUsuarioTelas.pTl_cpconfiguracao)
        'Estoque...
        comm.Parameters.Add("@tl_estoque", objUsuarioTelas.pTl_estoque)
        comm.Parameters.Add("@tl_estpesquisa", objUsuarioTelas.pTl_estpesquisa)
        comm.Parameters.Add("@tl_estrestaura", objUsuarioTelas.pTl_estrestaura)
        comm.Parameters.Add("@tl_estimplantacao", objUsuarioTelas.pTl_estimplantacao)
        comm.Parameters.Add("@tl_estpedidocompras", objUsuarioTelas.pTl_estpedidocompras)
        comm.Parameters.Add("@tl_estcompras", objUsuarioTelas.pTl_estcompras)
        comm.Parameters.Add("@tl_estatualizacao", objUsuarioTelas.pTl_estatualizacao)
        comm.Parameters.Add("@tl_estrelatorios", objUsuarioTelas.pTl_estrelatorios)
        'Financeiro...
        comm.Parameters.Add("@tl_financeiro", objUsuarioTelas.pTl_financeiro)
        comm.Parameters.Add("@tl_finpagamentos", objUsuarioTelas.pTl_finpagamentos)
        comm.Parameters.Add("@tl_finrecebimentos", objUsuarioTelas.pTl_finrecebimentos)
        comm.Parameters.Add("@tl_finfluxocaixa", objUsuarioTelas.pTl_finfluxocaixa)
        comm.Parameters.Add("@tl_findespesas", objUsuarioTelas.pTl_findespesas)
        comm.Parameters.Add("@tl_finchqpredatado", objUsuarioTelas.pTl_finchqPreDatado)
        'Manutenção...
        comm.Parameters.Add("@tl_manutencao", objUsuarioTelas.pTl_manutencao)
        comm.Parameters.Add("@tl_manemprestimos", objUsuarioTelas.pTl_manemprestimos)
        comm.Parameters.Add("@tl_mantrocas", objUsuarioTelas.pTl_mantrocas)
        comm.Parameters.Add("@tl_manpalmtop", objUsuarioTelas.pTl_manpalmtop)
        comm.Parameters.Add("@tl_mancidadesibge", objUsuarioTelas.pTl_mancidadesibge)
        'Contabil...
        comm.Parameters.Add("@tl_contabil", objUsuarioTelas.pTl_contabil)
        comm.Parameters.Add("@tl_ctbarqdigitais", objUsuarioTelas.pTl_ctbarqdigitais)
        comm.Parameters.Add("@tl_ctblivrosfiscais", objUsuarioTelas.pTl_ctblivrosfiscais)
        comm.Parameters.Add("@tl_ctbcontador", objUsuarioTelas.pTl_ctbcontador)
        comm.Parameters.Add("@tl_ctbcfop", objUsuarioTelas.pTl_ctbcfop)
        'Parametros
        comm.Parameters.Add("@tl_parametros", objUsuarioTelas.pTl_parametros)
        comm.Parameters.Add("@tl_paracontrole", objUsuarioTelas.pTl_paracontrole)
        comm.Parameters.Add("@tl_paraultilitarios", objUsuarioTelas.pTl_paraultilitarios)
        comm.Parameters.Add("@tl_parabackup", objUsuarioTelas.pTl_parabackup)
        comm.Parameters.Add("@tl_paraconfiguracao", objUsuarioTelas.pTl_paraconfiguracao)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

#End Region

#Region "*  *  Manutenção de EstFinanceiro  *  *"

    Public Sub incEstFinanceiro(ByVal objEstFinanceiro As Cl_EstFinanceiro, ByVal conexao As NpgsqlConnection, _
                         ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO estfinanceiro(")
        sqlbuild.Append("ef_id, ef_loja, ef_data, ef_totalcusto, ef_totalvenda, ef_totalitens, ef_tiposaldo)")
        sqlbuild.Append("VALUES (DEFAULT, @ef_loja, @ef_data, @ef_totalcusto, @ef_totalvenda, @ef_totalitens, @ef_tiposaldo);")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@ef_totalcusto", objEstFinanceiro.pTotalCusto)
        comm.Parameters.Add("@ef_totalvenda", objEstFinanceiro.pTotalVenda)
        comm.Parameters.Add("@ef_totalitens", objEstFinanceiro.pTotalItens)
        comm.Parameters.Add("@ef_loja", objEstFinanceiro.pLoja)
        comm.Parameters.Add("@ef_tiposaldo", objEstFinanceiro.pTipoSaldo)
        Try
            comm.Parameters.Add("@ef_data", Convert.ChangeType(objEstFinanceiro.pData, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@ef_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try


        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incEstFinanceiro(ByVal objEstFinanceiro As Cl_EstFinanceiro, ByVal conexao As NpgsqlConnection)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO estfinanceiro(")
        sqlbuild.Append("ef_id, ef_loja, ef_data, ef_totalcusto, ef_totalvenda, ef_totalitens, ef_tiposaldo)")
        sqlbuild.Append("VALUES (DEFAULT, @ef_loja, @ef_data, @ef_totalcusto, @ef_totalvenda, @ef_totalitens, @ef_tiposaldo);")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@ef_totalcusto", objEstFinanceiro.pTotalCusto)
        comm.Parameters.Add("@ef_totalvenda", objEstFinanceiro.pTotalVenda)
        comm.Parameters.Add("@ef_totalitens", objEstFinanceiro.pTotalItens)
        comm.Parameters.Add("@ef_loja", objEstFinanceiro.pLoja)
        comm.Parameters.Add("@ef_tiposaldo", objEstFinanceiro.pTipoSaldo)
        Try
            comm.Parameters.Add("@ef_data", Convert.ChangeType(objEstFinanceiro.pData, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@ef_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try


        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altEstFinanceiroPorDataLoja(ByVal objEstFinanceiro As Cl_EstFinanceiro, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE estfinanceiro SET ")
        sqlbuild.Append("ef_totalcusto = @ef_totalcusto, ef_totalvenda = @ef_totalvenda, ef_totalitens = @ef_totalitens ")
        sqlbuild.Append("WHERE ef_data = @ef_data AND ef_loja = @ef_loja AND ef_tiposaldo = @ef_tiposaldo")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@ef_totalcusto", objEstFinanceiro.pTotalCusto)
        comm.Parameters.Add("@ef_totalvenda", objEstFinanceiro.pTotalVenda)
        comm.Parameters.Add("@ef_totalitens", objEstFinanceiro.pTotalItens)
        Try
            comm.Parameters.Add("@ef_data", Convert.ChangeType(objEstFinanceiro.pData, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@ef_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try
        comm.Parameters.Add("@ef_loja", objEstFinanceiro.pLoja)
        comm.Parameters.Add("@ef_tiposaldo", objEstFinanceiro.pTipoSaldo)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altEstFinanceiroPorDataLoja(ByVal objEstFinanceiro As Cl_EstFinanceiro, ByVal conexao As NpgsqlConnection)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE estfinanceiro SET ")
        sqlbuild.Append("ef_totalcusto = @ef_totalcusto, ef_totalvenda = @ef_totalvenda, ef_totalitens = @ef_totalitens ")
        sqlbuild.Append("WHERE ef_data = @ef_data AND ef_loja = @ef_loja AND ef_tiposaldo = @ef_tiposaldo")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@ef_totalcusto", objEstFinanceiro.pTotalCusto)
        comm.Parameters.Add("@ef_totalvenda", objEstFinanceiro.pTotalVenda)
        comm.Parameters.Add("@ef_totalitens", objEstFinanceiro.pTotalItens)
        Try
            comm.Parameters.Add("@ef_data", Convert.ChangeType(objEstFinanceiro.pData, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@ef_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try
        comm.Parameters.Add("@ef_loja", objEstFinanceiro.pLoja)
        comm.Parameters.Add("@ef_tiposaldo", objEstFinanceiro.pTipoSaldo)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altEstFinanceiroPorID(ByVal objEstFinanceiro As Cl_EstFinanceiro, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE estfinanceiro SET ")
        sqlbuild.Append("ef_totalcusto = @ef_totalcusto, ef_totalvenda = @ef_totalvenda, ef_totalitens = @ef_totalitens ")
        sqlbuild.Append("WHERE ef_id = @ef_id")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@ef_id", objEstFinanceiro.pId)
        comm.Parameters.Add("@ef_totalcusto", objEstFinanceiro.pTotalCusto)
        comm.Parameters.Add("@ef_totalvenda", objEstFinanceiro.pTotalVenda)
        comm.Parameters.Add("@ef_totalitens", objEstFinanceiro.pTotalItens)
        'comm.Parameters.Add("@ef_data", objEstFinanceiro.pData)
        'comm.Parameters.Add("@ef_loja", objEstFinanceiro.pLoja)
        'comm.Parameters.Add("@ef_tiposaldo", objEstFinanceiro.pTipoSaldo)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

#End Region

#Region "  * * Manutenção de Gerente * *  "

    Public Sub incGerente(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal gerente As String, ByVal senha As String, ByVal libdesc As Boolean, _
                          ByVal libvalor As Boolean, ByVal libmax As Double, ByVal cod As Int32, _
                          ByVal privilegioLojas As Boolean, ByVal local As String)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO cadgerente(")
        sqlbuild.Append("gr_id, gr_gerente, gr_senha, gr_libdesc, gr_libvalor, gr_libmax, ")
        sqlbuild.Append("gr_cod, gr_privilegiolojas, gr_local)")
        sqlbuild.Append("VALUES (DEFAULT, @gr_gerente, @gr_senha, @gr_libdesc, @gr_libvalor, @gr_libmax, ")
        sqlbuild.Append("@gr_cod, @gr_privilegiolojas, @gr_local);")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@gr_gerente", gerente)
        comm.Parameters.Add("@gr_senha", senha)
        comm.Parameters.Add("@gr_libdesc", libdesc)
        comm.Parameters.Add("@gr_libvalor", libvalor)
        comm.Parameters.Add("@gr_libmax", libmax)
        comm.Parameters.Add("@gr_cod", cod)
        comm.Parameters.Add("@gr_privilegiolojas", privilegioLojas)
        comm.Parameters.Add("@gr_local", local)


        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altGerente(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal idGerente As Int32, ByVal gerente As String, ByVal senha As String, _
                          ByVal libdesc As Boolean, ByVal libvalor As Boolean, ByVal libmax As Double, _
                          ByVal privilegioLojas As Boolean, ByVal local As String)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE cadgerente SET ")
        sqlbuild.Append("gr_gerente = @gr_gerente, gr_senha = @gr_senha, gr_libdesc = @gr_libdesc, ")
        sqlbuild.Append("gr_libvalor = @gr_libvalor, gr_libmax = @gr_libmax, gr_privilegiolojas = ")
        sqlbuild.Append("@gr_privilegiolojas, gr_local = @gr_local WHERE gr_id = @gr_id")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@gr_gerente", gerente)
        comm.Parameters.Add("@gr_senha", senha)
        comm.Parameters.Add("@gr_libdesc", libdesc)
        comm.Parameters.Add("@gr_libvalor", libvalor)
        comm.Parameters.Add("@gr_libmax", libmax)
        comm.Parameters.Add("@gr_privilegiolojas", privilegioLojas)
        comm.Parameters.Add("@gr_local", local)
        comm.Parameters.Add("@gr_id", idGerente)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function trazProxCodGerente(ByVal conexao As NpgsqlConnection) As Int32

        Dim codGerente As Int32 = 1
        Dim drGerente As NpgsqlDataReader
        Dim comm As New NpgsqlCommand

        Dim sqlcmd As String = "SELECT (MAX(gr_id) + 1) FROM cadgerente"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        drGerente = comm.ExecuteReader
        While drGerente.Read

            Try
                codGerente = drGerente(0)
            Catch ex As Exception
            End Try
        End While
        drGerente.Close() : drGerente = Nothing : comm = Nothing : sqlcmd = Nothing


        Return codGerente
    End Function

    Public Function existeGerente(ByVal conexao As NpgsqlConnection, _
                                     ByVal nomeGerente As String, ByVal senhaGerente As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT gr_gerente FROM cadgerente WHERE gr_gerente = @gr_gerente AND gr_senha = @gr_senha;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@gr_gerente", nomeGerente)
        comm.Parameters.Add("@gr_senha", senhaGerente)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function trazLibDescGerente(ByVal conexao As NpgsqlConnection, _
                                     ByVal nomeGerente As String, ByVal senhaGerente As String) As Boolean

        Dim mvalorDesc As Boolean
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT gr_libdesc FROM cadgerente WHERE gr_gerente = @gr_gerente AND gr_senha = @gr_senha;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@gr_gerente", nomeGerente)
        comm.Parameters.Add("@gr_senha", senhaGerente)
        dr = comm.ExecuteReader
        While dr.Read

            Try
                mvalorDesc = dr(0)
            Catch ex As Exception
            End Try
        End While

        dr.Close() : comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mvalorDesc
    End Function

    Public Function trazLibValorGerente(ByVal conexao As NpgsqlConnection, _
                                     ByVal nomeGerente As String, ByVal senhaGerente As String) As Boolean

        Dim mvalor As Boolean
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT gr_libvalor FROM cadgerente WHERE gr_gerente = @gr_gerente AND gr_senha = @gr_senha;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@gr_gerente", nomeGerente)
        comm.Parameters.Add("@gr_senha", senhaGerente)
        dr = comm.ExecuteReader
        While dr.Read

            Try
                mvalor = dr(0)
            Catch ex As Exception
            End Try
        End While

        dr.Close() : comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mvalor
    End Function

    Public Function trazLibMaxGerente(ByVal conexao As NpgsqlConnection, _
                                     ByVal nomeGerente As String, ByVal senhaGerente As String) As Double

        Dim mvalor As Double = 0.0
        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT gr_libmax FROM cadgerente WHERE gr_gerente = @gr_gerente AND gr_senha = @gr_senha;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@gr_gerente", nomeGerente)
        comm.Parameters.Add("@gr_senha", senhaGerente)
        dr = comm.ExecuteReader
        While dr.Read

            Try
                mvalor = dr(0)
            Catch ex As Exception
            End Try
        End While

        dr.Close() : comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mvalor
    End Function

#End Region

#Region "  * * Manutenção da Configuração da Impressora  CDCAIXA * *  "

    Public Sub incImpressora(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal ec_caixa As String, ByVal ec_autoriz As String, ByVal ec_lacre1 As String, _
                          ByVal ec_lacre2 As String, ByVal ec_nfabri As String, ByVal ec_modelo As String, _
                          ByVal ec_geno As String, ByVal ec_codexterno As String, ByVal ec_regmac As String, _
                          ByVal ec_tipo As Integer, ByVal ec_pafecf As String)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO cdcaixa(")
        sqlbuild.Append("ec_id, ec_caixa, ec_autoriz, ec_lacre1, ec_lacre2, ec_nfabri, ec_modelo, ")
        sqlbuild.Append("ec_geno, ec_codexterno, ec_regmac, ec_tipo, ec_pafecf)")
        sqlbuild.Append("VALUES (DEFAULT, @ec_caixa, @ec_autoriz, @ec_lacre1, @ec_lacre2, @ec_nfabri, ")
        sqlbuild.Append("@ec_modelo, @ec_geno, @ec_codexterno, @ec_regmac, @ec_tipo, @ec_pafecf);")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@ec_caixa", ec_caixa)
        comm.Parameters.Add("@ec_autoriz", ec_autoriz)
        comm.Parameters.Add("@ec_lacre1", ec_lacre1)
        comm.Parameters.Add("@ec_lacre2", ec_lacre2)
        comm.Parameters.Add("@ec_nfabri", ec_nfabri)
        comm.Parameters.Add("@ec_modelo", ec_modelo)
        comm.Parameters.Add("@ec_geno", ec_geno)
        comm.Parameters.Add("@ec_codexterno", ec_codexterno)
        comm.Parameters.Add("@ec_regmac", ec_regmac)
        comm.Parameters.Add("@ec_tipo", ec_tipo)
        comm.Parameters.Add("@ec_pafecf", ec_pafecf)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altImpressora(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal ec_id As Int32, ByVal ec_caixa As String, ByVal ec_autoriz As String, _
                          ByVal ec_lacre1 As String, ByVal ec_lacre2 As String, ByVal ec_nfabri As String, _
                          ByVal ec_modelo As String, ByVal ec_geno As String, ByVal ec_codexterno As String, _
                          ByVal ec_regmac As String, ByVal ec_tipo As Integer, ByVal ec_pafecf As String)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE cdcaixa SET ")
        sqlbuild.Append("ec_caixa = @ec_caixa, ec_autoriz = @ec_autoriz, ec_lacre1 = @ec_lacre1, ")
        sqlbuild.Append("ec_lacre2 = @ec_lacre2, ec_nfabri = @ec_nfabri, ec_modelo = @ec_modelo, ")
        sqlbuild.Append("ec_geno = @ec_geno, ec_codexterno = @ec_codexterno, ec_regmac = @ec_regmac, ")
        sqlbuild.Append("ec_tipo = @ec_tipo, ec_pafecf = @ec_pafecf WHERE ec_id = @ec_id")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@ec_id", ec_id)
        comm.Parameters.Add("@ec_caixa", ec_caixa)
        comm.Parameters.Add("@ec_autoriz", ec_autoriz)
        comm.Parameters.Add("@ec_lacre1", ec_lacre1)
        comm.Parameters.Add("@ec_lacre2", ec_lacre2)
        comm.Parameters.Add("@ec_nfabri", ec_nfabri)
        comm.Parameters.Add("@ec_modelo", ec_modelo)
        comm.Parameters.Add("@ec_geno", ec_geno)
        comm.Parameters.Add("@ec_codexterno", ec_codexterno)
        comm.Parameters.Add("@ec_regmac", ec_regmac)
        comm.Parameters.Add("@ec_tipo", ec_tipo)
        comm.Parameters.Add("@ec_pafecf", ec_pafecf)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altImpressoraNumCupom(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal ec_id As Int32, ByVal ec_ncupom As Integer)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE cdcaixa SET ")
        sqlbuild.Append("ec_ncupom = @ec_ncupom WHERE ec_id = @ec_id")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@ec_id", ec_id)
        comm.Parameters.Add("@ec_ncupom", ec_ncupom)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altImpressoraTGeral(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal ec_id As Int32, ByVal ec_tgeral As Double)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE cdcaixa SET ")
        sqlbuild.Append("ec_tgeral = @ec_tgeral WHERE ec_id = @ec_id")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@ec_id", ec_id)
        comm.Parameters.Add("@ec_tgeral", ec_tgeral)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altImpressoraCooInicial(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal ec_id As Int32, ByVal ec_cooinical As Integer)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE cdcaixa SET ")
        sqlbuild.Append("ec_cooinical = @ec_cooinical WHERE ec_id = @ec_id")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@ec_id", ec_id)
        comm.Parameters.Add("@ec_cooinical", ec_cooinical)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altImpressoraCRZ(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal ec_id As Int32, ByVal ec_crz As Integer)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE cdcaixa SET ")
        sqlbuild.Append("ec_crz = @ec_crz WHERE ec_id = @ec_id")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@ec_id", ec_id)
        comm.Parameters.Add("@ec_crz", ec_crz)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delImpressora(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal ec_id As Int32)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM cdcaixa WHERE ec_id = @ec_id")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@ec_id", ec_id)
        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function existeMacImpressora(ByVal conexao As NpgsqlConnection, _
                                     ByVal ec_regmac As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT ec_regmac FROM cdcaixa WHERE ec_regmac = @ec_regmac;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@ec_regmac", ec_regmac)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeNFabricImpressora(ByVal conexao As NpgsqlConnection, _
                                     ByVal ec_nfabri As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT ec_nfabri FROM cdcaixa WHERE ec_nfabri = @ec_nfabri;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@ec_nfabri", ec_nfabri)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeMacImpressoraAlt(ByVal conexao As NpgsqlConnection, _
                                     ByVal ec_regmac As String, ByVal ec_regmacAnterior As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT ec_regmac FROM cdcaixa WHERE ec_regmac <> @ec_regmacant AND ec_regmac = @ec_regmac;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@ec_regmac", ec_regmac)
        comm.Parameters.Add("@ec_regmacant", ec_regmacAnterior)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeNFabricImpressoraAlt(ByVal conexao As NpgsqlConnection, _
                                     ByVal ec_nfabric As String, ByVal ec_nfabricAnterior As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT ec_nfabri FROM cdcaixa WHERE ec_nfabri <> @ec_nfabriant AND ec_nfabri = @ec_nfabri;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@ec_nfabri", ec_nfabric)
        comm.Parameters.Add("@ec_nfabriant", ec_nfabricAnterior)

        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

#End Region

#Region "* * *   Manutenção Retorno do Mapa   * * *"

    Public Sub incRetorno1pp(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal numPedido As String, ByVal numMapa As String, ByVal dtEntrega As Date, _
                          ByVal codPart As String, ByVal formaPgto As String, _
                          ByVal especPgto As String, ByVal naturezaPgto As String, _
                          ByVal total As Double, ByVal loja As String)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "INSERT INTO " & MdlEmpresaUsu._esqEstab & ".retorno1pp(rt_id, rt_numpedido, rt_mapa, rt_dtentegra, " _
            & "rt_codpart, rt_formapgto, rt_especpgto, rt_naturezapgto, rt_total, rt_loja) " _
            & "VALUES (DEFAULT, @rt_numpedido, @rt_mapa, @rt_dtentegra, @rt_codpart, @rt_formapgto, " _
            & "@rt_especpgto, @rt_naturezapgto, @rt_total, @rt_loja);"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@rt_numpedido", numPedido)
        comm.Parameters.Add("@rt_mapa", numMapa)
        comm.Parameters.Add("@rt_dtentegra", Convert.ChangeType(dtEntrega, GetType(Date)))
        comm.Parameters.Add("@rt_codpart", codPart)
        comm.Parameters.Add("@rt_formapgto", formaPgto)
        comm.Parameters.Add("@rt_especpgto", especPgto)
        comm.Parameters.Add("@rt_naturezapgto", naturezaPgto)
        comm.Parameters.Add("@rt_total", total)
        comm.Parameters.Add("@rt_loja", loja)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub incRetorno2cc(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal id1pp As Int32, ByVal numPedido As String, ByVal codPart As String, _
                          ByVal codProd As String, ByVal nomeProd As String, ByVal qtdeProd As Double, _
                          ByVal vlrUnitProd As Double, ByVal vlrTotalProd As Double, ByVal loja As String)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "INSERT INTO " & MdlEmpresaUsu._esqEstab & ".retorno2cc(rtc_id, rtc_id1pp, rtc_numpedido, " _
        & "rtc_codpart, rtc_codprod, rtc_nomeprod, rtc_qtde, rtc_vlrunit, rtc_vlrtotal, rtc_loja) " _
        & "VALUES (DEFAULT, @rtc_id1pp, @rtc_numpedido, @rtc_codpart, @rtc_codprod, " _
        & "@rtc_nomeprod, @rtc_qtde, @rtc_vlrunit, @rtc_vlrtotal, @rtc_loja);"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@rtc_id1pp", id1pp)
        comm.Parameters.Add("@rtc_numpedido", numPedido)
        comm.Parameters.Add("@rtc_codpart", codPart)
        comm.Parameters.Add("@rtc_codprod", codProd)
        comm.Parameters.Add("@rtc_nomeprod", nomeProd)
        comm.Parameters.Add("@rtc_qtde", qtdeProd)
        comm.Parameters.Add("@rtc_vlrunit", vlrUnitProd)
        comm.Parameters.Add("@rtc_vlrtotal", vlrTotalProd)
        comm.Parameters.Add("@rtc_loja", loja)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function trazIdRetorno1pp(ByVal conexao As NpgsqlConnection, ByVal numPedidoMp As String) As Int32

        Dim idMp As Int32 = 0
        Dim drMp As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT rt_id FROM " & MdlEmpresaUsu._esqEstab & ".retorno1pp WHERE rt_numpedido = @rt_numpedido"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@rt_numpedido", numPedidoMp)
        drMp = comm.ExecuteReader
        While drMp.Read

            idMp = drMp(0)
        End While

        drMp.Close() : drMp = Nothing : comm = Nothing : sqlcmd = Nothing


        Return idMp
    End Function

#End Region

#Region " *  *  *    Caixa, Despesa e Tesouraria    *  *  * "

    Public Sub incCaixa_lancamento(ByVal ID As Integer, ByVal Tipo As String, ByVal DTEmissao As Date, ByVal Grupo As String, ByVal Descricao As String, ByVal Valor As Double, _
                  ByVal usuario As String, ByVal Status As String, ByVal Loja As String, ByVal Caixa As String, ByVal Hora As String, ByVal conexao As NpgsqlConnection, _
                  ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        Try
            conexao.Open()
            sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".caixadiario(")
            sqlbuild.Append("cx_id, cx_tipo, cx_data, cx_grupo, cx_descricao, cx_valor, cx_usu, ")
            sqlbuild.Append("cx_status, cx_loja,cx_caixa,cx_hora) VALUES (Default, @cx_tipo, @cx_data, @cx_grupo, ")
            sqlbuild.Append("@cx_descricao, @cx_valor, @cx_usu, @cx_status, @cx_loja,@cx_caixa,@cx_hora)")

            comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
            'comm.Parameters.Add("id", )
            comm.Parameters.Add("@cx_tipo", Tipo)
            comm.Parameters.Add("@cx_data", Convert.ChangeType(DTEmissao, GetType(Date)))
            comm.Parameters.Add("@cx_grupo", Grupo)
            comm.Parameters.Add("@cx_descricao", Descricao)
            comm.Parameters.Add("@cx_valor", Valor)
            comm.Parameters.Add("@cx_usu", usuario)
            comm.Parameters.Add("@cx_status", Status)
            comm.Parameters.Add("@cx_loja", Loja)
            comm.Parameters.Add("@cx_caixa", Caixa)
            comm.Parameters.Add("@cx_hora", Hora)

            comm.Transaction = transaction
            comm.ExecuteNonQuery()

            conexao.Close()
            conexao.Dispose()
            comm = Nothing
            sqlbuild = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)

        End Try

    End Sub

    Public Sub altCaixa_lancamento(ByVal ID As Integer, ByVal Tipo As String, ByVal DTEmissao As Date, ByVal Grupo As String, ByVal Descricao As String, ByVal Valor As Double, _
                  ByVal usuario As String, ByVal Status As String, ByVal Loja As String, ByVal Caixa As String, ByVal Hora As String, ByVal conexao As NpgsqlConnection, _
                  ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        Try
            sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".caixadiario SET ")
            sqlbuild.Append("cx_tipo = @cx_tipo, cx_data = @cx_data, cx_grupo = @cx_grupo, cx_descricao = @cx_descricao, cx_valor = @cx_valor, ")
            sqlbuild.Append("cx_usu = @cx_usu, cx_status = @cx_status, cx_loja = @cx_loja, cx_caixa = @cx_caixa, cx_hora = @cx_hora ")
            sqlbuild.Append("WHERE cx_id = @cx_id ")

            comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
            comm.Transaction = transaction
            comm.Parameters.Add("@cx_id", ID)
            comm.Parameters.Add("@cx_tipo", Tipo)
            comm.Parameters.Add("@cx_data", Convert.ChangeType(DTEmissao, GetType(Date)))
            comm.Parameters.Add("@cx_grupo", Grupo)
            comm.Parameters.Add("@cx_descricao", Descricao)
            comm.Parameters.Add("@cx_valor", Valor)
            comm.Parameters.Add("@cx_usu", usuario)
            comm.Parameters.Add("@cx_status", Status)
            comm.Parameters.Add("@cx_loja", Loja)
            comm.Parameters.Add("@cx_caixa", Caixa)
            comm.Parameters.Add("@cx_hora", Hora)

            comm.ExecuteNonQuery()

        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Public Sub crud_PlanoConta_Despesa(ByVal Sit As String, ByVal local As String, ByVal grupo As String, ByVal subgrupo As String, _
                         ByVal tipo As String, ByVal descricao As String, ByVal saldoatual As Double, ByVal id As Integer, _
                         ByVal descricao2 As String, ByVal Transaction As NpgsqlTransaction, ByVal Conexao As NpgsqlConnection)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        Try
            If Sit = "I" Then
                sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".desp001(")
                sqlbuild.Append("ds_local, ds_grupo, ds_subgrupo, ds_tipo, ds_descricao,ds_saldoatual, ")
                sqlbuild.Append("ds_id, ds_descricao2) VALUES (@ds_local, @ds_grupo, @ds_subgrupo, @ds_tipo, ")
                sqlbuild.Append("@ds_descricao, @ds_saldoatual,Default, @ds_descricao2)")

                comm = New NpgsqlCommand(sqlbuild.ToString, Conexao)
            Else

                sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".desp001 SET ds_local=@ds_local, ds_grupo=@ds_grupo, ds_subgrupo=@ds_subgrupo, ")
                sqlbuild.Append("ds_tipo=@ds_tipo, ds_descricao=@ds_descricao,ds_saldoatual=@ds_saldoatual, ")
                sqlbuild.Append("ds_descricao2=@ds_descricao2 WHERE ds_id=@ds_id ")

                comm = New NpgsqlCommand(sqlbuild.ToString, Conexao)
                comm.Parameters.Add("@ds_id", id)
            End If

            comm.Parameters.Add("@ds_local", local)
            comm.Parameters.Add("@ds_grupo", grupo)
            comm.Parameters.Add("@ds_subgrupo", subgrupo)
            comm.Parameters.Add("@ds_tipo", tipo)
            comm.Parameters.Add("@ds_descricao", descricao)
            comm.Parameters.Add("@ds_saldoatual", saldoatual)
            comm.Parameters.Add("@ds_descricao2", descricao2)

            comm.Transaction = Transaction
            comm.ExecuteNonQuery()

            comm = Nothing
            sqlbuild = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)

        End Try

    End Sub


    Public Sub crud_DespLancamentos(ByVal Sit As String, ByVal ID As Integer, ByVal firma As String, ByVal grupo As String, ByVal subgrupo As String, _
                            ByVal datamov As Date, ByVal tipo As String, ByVal historico As String, ByVal valor As Double, _
                            ByVal Transaction As NpgsqlTransaction, ByVal Conexao As NpgsqlConnection)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        Try

            If Sit = "I" Then
                sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".despm002(")
                sqlbuild.Append("dm_id, dm_firma, dm_grupo, dm_subgrupo, dm_data, dm_tipo, dm_historico,dm_valor) ")
                sqlbuild.Append("VALUES (Default, @dm_firma, @dm_grupo, @dm_subgrupo, @dm_data, @dm_tipo,")
                sqlbuild.Append("@dm_historico,@dm_valor)")

                comm = New NpgsqlCommand(sqlbuild.ToString, Conexao)
            Else

                sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".despm002 SET dm_firma=@dm_firma, dm_grupo=@dm_grupo,")
                sqlbuild.Append("dm_subgrupo=@dm_subgrupo, dm_data=@dm_data, dm_tipo=@dm_tipo, dm_historico=@dm_historico,")
                sqlbuild.Append("dm_valor=@dm_valor WHERE dm_id=@dm_id")

                comm = New NpgsqlCommand(sqlbuild.ToString, Conexao)
                comm.Parameters.Add("@dm_id", ID)
            End If

            comm.Parameters.Add("dm_firma", firma)
            comm.Parameters.Add("dm_grupo", grupo)
            comm.Parameters.Add("dm_subgrupo", subgrupo)
            comm.Parameters.Add("dm_data", Convert.ChangeType(datamov, GetType(Date)))
            comm.Parameters.Add("dm_tipo", tipo)
            comm.Parameters.Add("dm_historico", historico)
            comm.Parameters.Add("dm_valor", valor)

            comm.Transaction = Transaction
            comm.ExecuteNonQuery()

            comm = Nothing
            sqlbuild = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)

        End Try

    End Sub

    Public Sub crud_ExcPlanodeContas(ByVal Codigo As String, strConexao As String)
        Dim conn As New NpgsqlConnection(strConexao)
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão: " & ex.Message) : Return
        End Try

        Dim transacao As NpgsqlTransaction
        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        Try
            transacao = conn.BeginTransaction
            sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".desp001 WHERE ds_id=@ds_id")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)

            comm.Parameters.AddWithValue("@ds_id", Codigo)
            comm.Transaction = transacao

            comm.ExecuteNonQuery()
            transacao.Commit()
            conn.Close()
        Catch ex As NpgsqlException
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
            _transacao.Rollback()
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub crud_ExcDespLancamentos(ByVal Codigo As String, ByVal conexao As NpgsqlConnection)
        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        Try
            sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".despm002 WHERE dm_id=@dm_id")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)

            conn.Open()
            comm.Parameters.AddWithValue("@dm_id", Codigo)
            _transacao = conn.BeginTransaction
            comm.Transaction = _transacao

            comm.ExecuteNonQuery()
            _transacao.Commit()
            conn.Close()
        Catch ex As NpgsqlException
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
            _transacao.Rollback()
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela", MsgBoxStyle.Exclamation)
        End Try
    End Sub



#End Region

#Region "* * *  Manutenção ESTNCM  * * *"

    Public Sub incEstncm(clEstncm As Cl_Estncm, ByRef conexao As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO estncm(")
        sqlbuild.Append("ncm_id, ncm_ncm, ncm_cfop, ncm_pisent, ncm_cofinsent, ncm_pissaid, ")
        sqlbuild.Append("ncm_cofinssaid, ncm_natpis, ncm_natcofins, ncm_descricao) ")
        sqlbuild.Append("VALUES (DEFAULT, @ncm_ncm, @ncm_cfop, @ncm_pisent, @ncm_cofinsent, @ncm_pissaid, ")
        sqlbuild.Append("@ncm_cofinssaid, @ncm_natpis, @ncm_natcofins, @ncm_descricao)")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@ncm_ncm", clEstncm.ncm_ncm)
        comm.Parameters.Add("@ncm_cfop", clEstncm.ncm_cfop)
        comm.Parameters.Add("@ncm_pisent", clEstncm.ncm_pisent)
        comm.Parameters.Add("@ncm_cofinsent", clEstncm.ncm_cofinsent)
        comm.Parameters.Add("@ncm_pissaid", clEstncm.ncm_pissaid)
        comm.Parameters.Add("@ncm_cofinssaid", clEstncm.ncm_cofinssaid)
        comm.Parameters.Add("@ncm_natpis", clEstncm.ncm_natpis)
        comm.Parameters.Add("@ncm_natcofins", clEstncm.ncm_natcofins)
        comm.Parameters.Add("@ncm_descricao", clEstncm.ncm_descricao)

        comm.ExecuteNonQuery()
    End Sub

#End Region

#Region "  * **Manuteção do estloja01** *  "

    Public Function existeProdEstloja01(ByVal mCodProd As String, ByVal mLoja As String, _
                                      ByVal conexao As NpgsqlConnection) As Boolean

        Dim connection As New NpgsqlConnection(conexao.ConnectionString)
        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        sqlbuild.Append("SELECT * FROM estloja01 WHERE e_codig = @e_codig AND e_loja = @e_loja ")

        comm = New NpgsqlCommand(sqlbuild.ToString, connection)
        ' Prepara Paramentros
        comm.Parameters.Add("@e_codig", mCodProd)
        comm.Parameters.Add("@e_loja", mLoja)
        dr = comm.ExecuteReader
        If dr.HasRows = True Then

            sqlbuild = Nothing : comm = Nothing : dr.Close() : dr = Nothing
            connection.Close() : connection = Nothing : Return True
        End If


        sqlbuild = Nothing : comm = Nothing : dr.Close() : dr = Nothing
        connection.Close() : connection = Nothing
        Return False
    End Function

    Public Sub incEstloja(ByVal loja As String, ByVal idVinculo As Int16, ByVal codig As String, ByVal cdport As String, ByVal qtde As Double, _
                          ByVal pcusto As Double, ByVal pvenda As Double, ByVal vprom As Double, _
                          ByVal qtdfisc As Double, ByVal inventa As Double, ByVal pcustom As Double, _
                          ByVal pcustoa As Double, ByVal pcomp As Double, ByVal dtcomp As String, _
                          ByVal dtvend As String, ByVal pvend15 As Double, ByVal pvend30 As Double, _
                          ByVal pcompa As Double, ByVal mlocacao As String, ByVal dtvalid As Date, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO estloja01(")
        sqlbuild.Append("e_loja, e_codig, e_cdport, e_qtde, e_pcusto, e_pvenda, e_vprom, ")
        sqlbuild.Append("e_qtdfisc, e_inventa, e_pcustom, e_pcustoa, e_pcomp, ") 'e_dtcomp, 
        sqlbuild.Append("e_pvend15, e_pvend30, e_pcompa, e_idvinculo, e_locacao, e_valid) ") 'e_dtvend, 
        sqlbuild.Append("VALUES (@e_loja, @e_codig, @e_cdport, @e_qtde, @e_pcusto, @e_pvenda, ")
        sqlbuild.Append("@e_vprom, @e_qtdfisc, @e_inventa, @e_pcustom, @e_pcustoa, ")
        sqlbuild.Append("@e_pcomp, @e_pvend15, @e_pvend30, @e_pcompa, @e_idvinculo, @e_locacao, @e_valid) ") '@e_dtcomp, @e_dtvend, 

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@e_loja", loja)
        comm.Parameters.Add("@e_codig", codig)
        comm.Parameters.Add("@e_cdport", cdport)
        comm.Parameters.Add("@e_qtde", qtde)
        comm.Parameters.Add("@e_pcusto", pcusto)
        comm.Parameters.Add("@e_pvenda", pvenda)
        comm.Parameters.Add("@e_vprom", vprom)
        comm.Parameters.Add("@e_qtdfisc", qtdfisc)
        comm.Parameters.Add("@e_inventa", inventa)
        comm.Parameters.Add("@e_pcustom", pcustom)
        comm.Parameters.Add("@e_pcustoa", pcustoa)
        comm.Parameters.Add("@e_pcomp", pcomp)
        'comm.Parameters.Add("@e_dtcomp", dtcomp)
        'comm.Parameters.Add("@e_dtvend", dtvend)
        comm.Parameters.Add("@e_pvend15", pvend15)
        comm.Parameters.Add("@e_pvend30", pvend30)
        comm.Parameters.Add("@e_pcompa", pcompa)
        comm.Parameters.Add("@e_idvinculo", idVinculo)
        comm.Parameters.Add("@e_locacao", mlocacao)


        Try
            dtvalid = Convert.ChangeType(dtvalid.ToString("u"), GetType(Date))

            If IsDate(dtvalid.ToString) Then
                comm.Parameters.Add("@e_valid", Convert.ChangeType(dtvalid, GetType(Date)))
            Else
                comm.Parameters.Add("@e_valid", NpgsqlTypes.NpgsqlDbType.Date)
            End If
        Catch ex As Exception
            comm.Parameters.Add("@e_valid", NpgsqlTypes.NpgsqlDbType.Date)
        End Try



        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incTodasEstloja(ByVal vinculo As Int32, ByVal loja As String, ByVal codig As String, ByVal cdport As String, ByVal qtde As Double, _
                          ByVal pcusto As Double, ByVal pvenda As Double, ByVal vprom As Double, _
                          ByVal qtdfisc As Double, ByVal inventa As Double, ByVal pcustom As Double, _
                          ByVal pcustoa As Double, ByVal pcomp As Double, ByVal dtcomp As String, _
                          ByVal dtvend As String, ByVal pvend15 As Double, ByVal pvend30 As Double, _
                          ByVal pcompa As Double, ByVal dtvalid As Date, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim connection As New NpgsqlConnection(conexao.ConnectionString)
        Dim commInc As New NpgsqlCommand
        Dim commSelec As New NpgsqlCommand
        Dim sqlbuildInc As New StringBuilder
        Dim sqlbuildSelec As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return
        End Try

        'Traz Todas as empresas do vínculo...
        sqlbuildSelec.Append("SELECT SUBSTR(g_codig, 4, 2) FROM geno001 WHERE g_vinculo = @g_vinculo")
        commSelec = New NpgsqlCommand(sqlbuildSelec.ToString, connection)

        ' Prepara Paramentros
        commSelec.Parameters.Add("@g_vinculo", vinculo)
        dr = commSelec.ExecuteReader

        While dr.Read

            loja = dr(0).ToString

            If existeProdEstloja01(codig, loja, conexao) = False Then

                'Inclue no Estloja por empresa...
                sqlbuildInc.Append("INSERT INTO estloja01(")
                sqlbuildInc.Append("e_loja, e_codig, e_cdport, e_qtde, e_pcusto, e_pvenda, e_vprom, ")
                sqlbuildInc.Append("e_qtdfisc, e_inventa, e_pcustom, e_pcustoa, e_pcomp, ") 'e_dtcomp, 
                sqlbuildInc.Append("e_pvend15, e_pvend30, e_pcompa, e_idvinculo, e_valid) ") 'e_dtvend, 
                sqlbuildInc.Append("VALUES (@e_loja, @e_codig, @e_cdport, @e_qtde, @e_pcusto, @e_pvenda, ")
                sqlbuildInc.Append("@e_vprom, @e_qtdfisc, @e_inventa, @e_pcustom, @e_pcustoa, ")
                sqlbuildInc.Append("@e_pcomp, @e_pvend15, @e_pvend30, @e_pcompa, @e_idvinculo, @e_valid) ") '@e_dtcomp, @e_dtvend, 

                commInc.Transaction = transacao
                commInc = New NpgsqlCommand(sqlbuildInc.ToString, conexao)

                ' Prepara Paramentros
                commInc.Parameters.Add("@e_loja", loja)
                commInc.Parameters.Add("@e_codig", codig)
                commInc.Parameters.Add("@e_cdport", cdport)
                commInc.Parameters.Add("@e_qtde", qtde)
                commInc.Parameters.Add("@e_pcusto", pcusto)
                commInc.Parameters.Add("@e_pvenda", pvenda)
                commInc.Parameters.Add("@e_vprom", vprom)
                commInc.Parameters.Add("@e_qtdfisc", qtdfisc)
                commInc.Parameters.Add("@e_inventa", inventa)
                commInc.Parameters.Add("@e_pcustom", pcustom)
                commInc.Parameters.Add("@e_pcustoa", pcustoa)
                commInc.Parameters.Add("@e_pcomp", pcomp)
                'comm.Parameters.Add("@e_dtcomp", dtcomp)
                'comm.Parameters.Add("@e_dtvend", dtvend)
                commInc.Parameters.Add("@e_pvend15", pvend15)
                commInc.Parameters.Add("@e_pvend30", pvend30)
                commInc.Parameters.Add("@e_pcompa", pcompa)
                commInc.Parameters.Add("@e_idvinculo", vinculo)

                Try
                    dtvalid = Convert.ChangeType(dtvalid.ToString("u"), GetType(Date))

                    If IsDate(dtvalid.ToString) Then
                        commInc.Parameters.Add("@e_valid", Convert.ChangeType(dtvalid, GetType(Date)))
                    Else
                        commInc.Parameters.Add("@e_valid", NpgsqlTypes.NpgsqlDbType.Date)
                    End If
                Catch ex As Exception
                    commInc.Parameters.Add("@e_valid", NpgsqlTypes.NpgsqlDbType.Date)
                End Try


                commInc.ExecuteNonQuery()

                sqlbuildInc.Remove(0, sqlbuildInc.ToString.Length)
                commInc.CommandText = ""

            End If

        End While


        dr.Close() : dr = Nothing : commInc = Nothing : commSelec = Nothing
        sqlbuildInc = Nothing : sqlbuildSelec = Nothing
        connection.Close() : connection = Nothing
    End Sub

    Public Sub altEstloja(ByVal loja As String, ByVal codig As String, ByVal cdport As String, ByVal qtde As Double, _
                          ByVal pcusto As Double, ByVal pvenda As Double, ByVal vprom As Double, _
                          ByVal qtdfisc As Double, ByVal inventa As Double, ByVal pcustom As Double, _
                          ByVal pcustoa As Double, ByVal pcomp As Double, ByVal dtcomp As String, _
                          ByVal dtvend As String, ByVal pvend15 As Double, ByVal pvend30 As Double, _
                          ByVal pcompa As Double, ByVal dtvalid As Date, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE estloja01 ")
        sqlbuild.Append("SET e_cdport = @e_cdport, e_qtde = @e_qtde, e_pcusto = @e_pcusto, e_pvenda = @e_pvenda, ")
        sqlbuild.Append("e_vprom = @e_vprom, e_qtdfisc = @e_qtdfisc, e_inventa = @e_inventa, e_pcustom = @e_pcustom, ")
        sqlbuild.Append("e_pcustoa = @e_pcustoa, e_pcomp = @e_pcomp, e_dtcomp = @e_dtcomp, e_dtvend = @e_dtvend, ")
        sqlbuild.Append("e_pvend15 = @e_pvend15, e_pvend30 = @e_pvend30, e_pcompa = @e_pcompa, e_valid = @e_valid ")
        sqlbuild.Append("WHERE e_loja = @e_loja AND e_codig = @e_codig")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@e_loja", loja)
        comm.Parameters.Add("@e_codig", codig)
        comm.Parameters.Add("@e_cdport", cdport)
        comm.Parameters.Add("@e_qtde", qtde)
        comm.Parameters.Add("@e_pcusto", pcusto)
        comm.Parameters.Add("@e_pvenda", pvenda)
        comm.Parameters.Add("@e_vprom", vprom)
        comm.Parameters.Add("@e_qtdfisc", qtdfisc)
        comm.Parameters.Add("@e_inventa", inventa)
        comm.Parameters.Add("@e_pcustom", pcustom)
        comm.Parameters.Add("@e_pcustoa", pcustoa)
        comm.Parameters.Add("@e_pcomp", pcomp)


        Try
            dtcomp = Convert.ChangeType(dtcomp.ToString("u"), GetType(Date))

            If IsDate(dtcomp.ToString) Then
                comm.Parameters.Add("@e_dtcomp", dtcomp)
            Else
                comm.Parameters.Add("@e_dtcomp", NpgsqlTypes.NpgsqlDbType.Date)
            End If
        Catch ex As Exception
            comm.Parameters.Add("@e_dtcomp", NpgsqlTypes.NpgsqlDbType.Date)
        End Try


        Try
            dtvend = Convert.ChangeType(dtvend.ToString("u"), GetType(Date))

            If IsDate(dtvend.ToString) Then
                comm.Parameters.Add("@e_dtvend", dtvend)
            Else
                comm.Parameters.Add("@e_dtvend", NpgsqlTypes.NpgsqlDbType.Date)
            End If
        Catch ex As Exception
            comm.Parameters.Add("@e_dtvend", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@e_pvend15", pvend15)
        comm.Parameters.Add("@e_pvend30", pvend30)
        comm.Parameters.Add("@e_pcompa", pcompa)

        Try
            dtvalid = Convert.ChangeType(dtvalid.ToString("u"), GetType(Date))

            If IsDate(dtvalid.ToString) Then
                comm.Parameters.Add("@e_valid", Convert.ChangeType(dtvalid, GetType(Date)))
            Else
                comm.Parameters.Add("@e_valid", NpgsqlTypes.NpgsqlDbType.Date)
            End If
        Catch ex As Exception
            comm.Parameters.Add("@e_valid", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altEstlojaSaldos(ByVal loja As String, ByVal codig As String, ByVal qtde As Double, _
                          ByVal pcusto As Double, ByVal pvenda As Double, ByVal vprom As Double, _
                          ByVal qtdfisc As Double, ByVal inventa As Double, ByVal pcustom As Double, _
                          ByVal pcustoa As Double, ByVal pcomp As Double, ByVal pvend15 As Double, _
                          ByVal pvend30 As Double, ByVal pcompa As Double, ByVal mlocacao As String, _
                          ByVal mGerente As String, ByVal mUsuario As String, ByVal dtvalid As Date, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE estloja01 ")
        sqlbuild.Append("SET e_qtde = @e_qtde, e_pcusto = @e_pcusto, e_pvenda = @e_pvenda, ")
        sqlbuild.Append("e_vprom = @e_vprom, e_qtdfisc = @e_qtdfisc, e_inventa = @e_inventa, ")
        sqlbuild.Append("e_pcustom = @e_pcustom, e_pcustoa = @e_pcustoa, e_pcomp = @e_pcomp, ")
        sqlbuild.Append("e_pvend15 = @e_pvend15, e_pvend30 = @e_pvend30, e_pcompa = @e_pcompa, ")
        sqlbuild.Append("e_locacao = @e_locacao, e_gerente = @e_gerente, e_estoquista = @e_estoquista, ")
        sqlbuild.Append("e_valid = @e_valid WHERE e_loja = @e_loja AND e_codig = @e_codig")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@e_loja", loja)
        comm.Parameters.Add("@e_codig", codig)
        comm.Parameters.Add("@e_qtde", qtde)
        comm.Parameters.Add("@e_pcusto", pcusto)
        comm.Parameters.Add("@e_pvenda", pvenda)
        comm.Parameters.Add("@e_vprom", vprom)
        comm.Parameters.Add("@e_qtdfisc", qtdfisc)
        comm.Parameters.Add("@e_inventa", inventa)
        comm.Parameters.Add("@e_pcustom", pcustom)
        comm.Parameters.Add("@e_pcustoa", pcustoa)
        comm.Parameters.Add("@e_pcomp", pcomp)
        comm.Parameters.Add("@e_pvend15", pvend15)
        comm.Parameters.Add("@e_pvend30", pvend30)
        comm.Parameters.Add("@e_pcompa", pcompa)
        comm.Parameters.Add("@e_locacao", mlocacao)
        comm.Parameters.Add("@e_gerente", mGerente)
        comm.Parameters.Add("@e_estoquista", mUsuario)
        'comm.Parameters.Add("@e_valid", dtvalid)

        Try
            dtvalid = Convert.ChangeType(dtvalid.ToString("u"), GetType(Date))

            If IsDate(dtvalid.ToString) Then
                comm.Parameters.Add("@e_valid", Convert.ChangeType(dtvalid, GetType(Date)))
            Else
                comm.Parameters.Add("@e_valid", NpgsqlTypes.NpgsqlDbType.Date)
            End If
        Catch ex As Exception
            comm.Parameters.Add("@e_valid", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub exc_estoquecad(ByVal Codigo As String, ByVal conexao As NpgsqlConnection)
        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        Try
            sqlbuild.Append("DELETE FROM vinc1.est0001 WHERE e_codig=@e_codig")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            ' Exclui Definitivamente o funcionario
            conn.Open()
            comm.Parameters.AddWithValue("@e_codig", Codigo)
            _transacao = conn.BeginTransaction
            comm.Transaction = _transacao

            comm.ExecuteNonQuery()
            _transacao.Commit()
            conn.Close()
        Catch ex As NpgsqlException
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
            _transacao.Rollback()
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub exc_estoqueloja(ByVal Codigo As String, ByVal conexao As NpgsqlConnection)
        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        Try
            sqlbuild.Append("DELETE FROM estloja01 WHERE e_codig=@e_codig")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            ' Exclui Definitivamente o funcionario
            conn.Open()
            comm.Parameters.AddWithValue("@e_codig", Codigo)
            _transacao = conn.BeginTransaction
            comm.Transaction = _transacao

            comm.ExecuteNonQuery()
            _transacao.Commit()
            conn.Close()
        Catch ex As NpgsqlException
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
            _transacao.Rollback()
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela", MsgBoxStyle.Exclamation)
        End Try
    End Sub

#End Region

#Region "  * * Manutenção do Geno001 e Genp001 * *  "

    Public Sub incGeno001(ByVal objGeno As Cl_Geno, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO geno001(")
        sqlbuild.Append("g_id, g_codig, g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, ")
        sqlbuild.Append("g_insc, g_fone, g_fax, g_mun, g_coduf, g_email, g_razaosocial, ")
        sqlbuild.Append("g_retencao, g_cnae, g_crt, g_vinculo, g_esquemaestab, g_esquemavinc, g_pis, ")
        sqlbuild.Append("g_cofins, g_csll, g_irenda, g_sn, g_ativempresa, g_bl_bancopadrao, g_bl_optpadrao) ")
        sqlbuild.Append("VALUES (DEFAULT, @g_codig, @g_geno, @g_ender, @g_cid, @g_uf, @g_cep, ")
        sqlbuild.Append("@g_bair, @g_cgc, @g_insc, @g_fone, @g_fax, @g_mun, @g_coduf, ")
        sqlbuild.Append("@g_email, @g_razaosocial, @g_retencao, @g_cnae, @g_crt, @g_vinculo, ")
        sqlbuild.Append("@g_esquemaestab, @g_esquemavinc, @g_pis, @g_cofins, @g_csll, @g_irenda, @g_sn, ")
        sqlbuild.Append("@g_ativempresa, @g_bl_bancopadrao, @g_bl_optpadrao)")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@g_codig", objGeno.pCodig) : comm.Parameters.Add("@g_geno", objGeno.pGeno)
        comm.Parameters.Add("@g_ender", objGeno.pEnder) : comm.Parameters.Add("@g_cid", objGeno.pCid)
        comm.Parameters.Add("@g_uf", objGeno.pUf) : comm.Parameters.Add("@g_cep", objGeno.pCep)
        comm.Parameters.Add("@g_bair", objGeno.pBair) : comm.Parameters.Add("@g_cgc", objGeno.pCgc)
        comm.Parameters.Add("@g_insc", objGeno.pInsc) : comm.Parameters.Add("@g_fone", objGeno.pFone)
        comm.Parameters.Add("@g_fax", objGeno.pFax) : comm.Parameters.Add("@g_mun", objGeno.pMun)
        comm.Parameters.Add("@g_coduf", objGeno.pCoduf) : comm.Parameters.Add("@g_email", objGeno.pEmail)
        comm.Parameters.Add("@g_razaosocial", objGeno.pRazaosocial) : comm.Parameters.Add("@g_retencao", objGeno.pRetencao)
        comm.Parameters.Add("@g_cnae", objGeno.pCnae) : comm.Parameters.Add("@g_crt", objGeno.pCrt)
        comm.Parameters.Add("@g_vinculo", objGeno.pVinculo) : comm.Parameters.Add("@g_esquemaestab", objGeno.pEsquemaestab)
        comm.Parameters.Add("@g_esquemavinc", objGeno.pEsquemavinc) : comm.Parameters.Add("@g_pis", objGeno.pPis)
        comm.Parameters.Add("@g_cofins", objGeno.pCofins) : comm.Parameters.Add("@g_csll", objGeno.pCsll)
        comm.Parameters.Add("@g_irenda", objGeno.pIRenda) : comm.Parameters.Add("@g_sn", objGeno.pSn)
        comm.Parameters.Add("@g_ativempresa", objGeno.pAtivEmpresa) : comm.Parameters.Add("@g_bl_bancopadrao", objGeno.pBlBancoPadrao)
        comm.Parameters.Add("@g_bl_optpadrao", objGeno.pBlOptPadrao)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altGeno001(ByVal objGeno As Cl_Geno, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE geno001 ")
        sqlbuild.Append("SET g_geno = @g_geno, g_ender = @g_ender, g_cid = @g_cid, g_uf = @g_uf, ")
        sqlbuild.Append("g_cep = @g_cep, g_bair = @g_bair, g_cgc = @g_cgc, g_insc = @g_insc, ")
        sqlbuild.Append("g_fone = @g_fone, g_fax = @g_fax, g_mun = @g_mun, g_coduf = @g_coduf, ")
        sqlbuild.Append("g_email = @g_email, g_razaosocial = @g_razaosocial, g_cnae = @g_cnae, ") 'g_aidf = @g_aidf, g_iniform=@, g_fimform=@, 
        sqlbuild.Append("g_crt = @g_crt, g_vinculo = @g_vinculo, g_esquemaestab = @g_esquemaestab, ")
        sqlbuild.Append("g_esquemavinc = @g_esquemavinc, g_retencao = @g_retencao, g_pis = @g_pis, ")
        sqlbuild.Append("g_cofins = @g_cofins, g_csll = @g_csll, g_irenda = @g_irenda, g_sn = @g_sn, ")
        sqlbuild.Append("g_ativempresa = @g_ativempresa, g_bl_bancopadrao = @g_bl_bancopadrao, g_bl_optpadrao = @g_bl_optpadrao ")
        sqlbuild.Append("WHERE g_codig = @g_codig")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@g_codig", objGeno.pCodig) : comm.Parameters.Add("@g_geno", objGeno.pGeno)
        comm.Parameters.Add("@g_ender", objGeno.pEnder) : comm.Parameters.Add("@g_cid", objGeno.pCid)
        comm.Parameters.Add("@g_uf", objGeno.pUf) : comm.Parameters.Add("@g_cep", objGeno.pCep)
        comm.Parameters.Add("@g_bair", objGeno.pBair) : comm.Parameters.Add("@g_cgc", objGeno.pCgc)
        comm.Parameters.Add("@g_insc", objGeno.pInsc) : comm.Parameters.Add("@g_fone", objGeno.pFone)
        comm.Parameters.Add("@g_fax", objGeno.pFax) : comm.Parameters.Add("@g_mun", objGeno.pMun)
        comm.Parameters.Add("@g_coduf", objGeno.pCoduf) : comm.Parameters.Add("@g_email", objGeno.pEmail)
        comm.Parameters.Add("@g_razaosocial", objGeno.pRazaosocial) : comm.Parameters.Add("@g_aidf", objGeno.pAidf)
        comm.Parameters.Add("@g_cnae", objGeno.pCnae) : comm.Parameters.Add("@g_crt", objGeno.pCrt)
        comm.Parameters.Add("@g_vinculo", objGeno.pVinculo) : comm.Parameters.Add("@g_esquemaestab", objGeno.pEsquemaestab)
        comm.Parameters.Add("@g_esquemavinc", objGeno.pEsquemavinc) : comm.Parameters.Add("@g_retencao", objGeno.pRetencao)
        comm.Parameters.Add("@g_pis", objGeno.pPis) : comm.Parameters.Add("@g_cofins", objGeno.pCofins)
        comm.Parameters.Add("@g_csll", objGeno.pCsll) : comm.Parameters.Add("@g_irenda", objGeno.pIRenda)
        comm.Parameters.Add("@g_sn", objGeno.pSn)
        comm.Parameters.Add("@g_ativempresa", objGeno.pAtivEmpresa) : comm.Parameters.Add("@g_bl_bancopadrao", objGeno.pBlBancoPadrao)
        comm.Parameters.Add("@g_bl_optpadrao", objGeno.pBlOptPadrao)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incGenp001(ByVal objGenp001 As Cl_Genp001, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO genp001(")
        sqlbuild.Append("gp_requis, gp_sai, gp_fat, gp_data, gp_icms, gp_icmse, gp_alqiss, ")
        sqlbuild.Append("gp_serv, gp_orca, gp_palm, gp_txreduz, gp_icmred, gp_txcob, gp_txipi, ")
        sqlbuild.Append("gp_txga, gp_txesvei, gp_serie, gp_contf, gp_amb, gp_prazo, gp_seqnfe, ")
        sqlbuild.Append("gp_mensag, gp_pis, gp_confin, gp_alqsub, gp_geno, gp_carencia, ")
        sqlbuild.Append("gp_codprod, gp_codrequis, gp_codmapa, gp_numpedidomp, gp_mapapedido, ")
        sqlbuild.Append("gp_canc_pedauto, gp_grade, gp_codreqproc, gp_tipocondpagto,gp_cpfvalidar, gp_tptransfentrada, ")
        sqlbuild.Append("gp_tptransfsaida, gp_sincroniza, gp_comisavista, gp_comisaprazo, gp_envioxml, gp_lotxml, ")
        sqlbuild.Append("gp_retornoxml, gp_enviadoxml, gp_imagemcarne, gp_sldfiscalnegativo, gp_aplicacao, ")
        sqlbuild.Append("gp_tabletenvio, gp_tabletretorno, gp_palmenvio, gp_palmretorno, ")
        sqlbuild.Append("gp_tabletpathimg, gp_ftptablet, gp_usuarioftptablet, gp_senhaftptablet, ")
        sqlbuild.Append("gp_ftppalm, gp_usuarioftppalm, gp_senhaftppalm, gp_pauta, gp_descontonfe, gp_descontopedido, ")
        sqlbuild.Append("gp_pastasgbd, gp_logomarcapath)")
        sqlbuild.Append("VALUES (@gp_requis, @gp_sai, @gp_fat, @gp_data, @gp_icms, @gp_icmse, ")
        sqlbuild.Append("@gp_alqiss, @gp_serv, @gp_orca, @gp_palm, @gp_txreduz, @gp_icmred, ")
        sqlbuild.Append("@gp_txcob, @gp_txipi, @gp_txga, @gp_txesvei, @gp_serie, @gp_contf, ")
        sqlbuild.Append("@gp_amb, @gp_prazo, @gp_seqnfe, @gp_mensag, @gp_pis, @gp_confin, @gp_alqsub, @gp_geno, ")
        sqlbuild.Append("@gp_carencia, @gp_codprod, @gp_codrequis, @gp_codmapa, @gp_numpedidomp, @gp_mapapedido, ")
        sqlbuild.Append("@gp_canc_pedauto, @gp_grade, @gp_codreqproc, @gp_tipocondpagto,@gp_cpfvalidar, ")
        sqlbuild.Append("@gp_tptransfentrada, @gp_tptransfsaida, @gp_sincroniza, @gp_comisavista, ")
        sqlbuild.Append("@gp_comisaprazo, @gp_envioxml, @gp_lotxml, @gp_retornoxml, @gp_enviadoxml, ")
        sqlbuild.Append("@gp_imagemcarne, @gp_sldfiscalnegativo, @gp_aplicacao, @gp_tabletenvio, @gp_tabletretorno, ")
        sqlbuild.Append("@gp_palmenvio, @gp_palmretorno, @gp_tabletpathimg, @gp_ftptablet, @gp_usuarioftptablet, ")
        sqlbuild.Append("@gp_senhaftptablet, @gp_ftppalm, @gp_usuarioftppalm, @gp_senhaftppalm, @gp_pauta, ")
        sqlbuild.Append("@gp_descontonfe, @gp_descontopedido, @gp_pastasgbd, @gp_logomarcapath) ")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@gp_requis", objGenp001.pRequis) : comm.Parameters.Add("@gp_sai", objGenp001.pSai)
        comm.Parameters.Add("@gp_fat", objGenp001.pFat)

        Try
            comm.Parameters.Add("@gp_data", Convert.ChangeType(objGenp001.pData, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@gp_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@gp_icms", objGenp001.pIcms) : comm.Parameters.Add("@gp_icmse", objGenp001.pIcmse)
        comm.Parameters.Add("@gp_alqiss", objGenp001.pAlqiss) : comm.Parameters.Add("@gp_serv", objGenp001.pServ)
        comm.Parameters.Add("@gp_orca", objGenp001.pOrca) : comm.Parameters.Add("@gp_palm", objGenp001.pPalm)
        comm.Parameters.Add("@gp_txreduz", objGenp001.pTxreduz) : comm.Parameters.Add("@gp_icmred", objGenp001.pIcmred)
        comm.Parameters.Add("@gp_txcob", objGenp001.pTxcob) : comm.Parameters.Add("@gp_txipi", objGenp001.pTxipi)
        comm.Parameters.Add("@gp_txga", objGenp001.pTxga) : comm.Parameters.Add("@gp_txesvei", objGenp001.pTxesvei)
        comm.Parameters.Add("@gp_serie", objGenp001.pSerie) : comm.Parameters.Add("@gp_contf", objGenp001.pContf)
        comm.Parameters.Add("@gp_amb", objGenp001.pAmb) : comm.Parameters.Add("@gp_prazo", objGenp001.pPrazo)
        comm.Parameters.Add("@gp_seqnfe", objGenp001.pSeqnfe) : comm.Parameters.Add("@gp_mensag", objGenp001.pMensag)
        comm.Parameters.Add("@gp_pis", objGenp001.pPis) : comm.Parameters.Add("@gp_confin", objGenp001.pConfin)
        comm.Parameters.Add("@gp_alqsub", objGenp001.pAlqsub) : comm.Parameters.Add("@gp_geno", objGenp001.pGeno)
        comm.Parameters.Add("@gp_carencia", objGenp001.pCarencia) : comm.Parameters.Add("@gp_codprod", objGenp001.pCodprod)
        comm.Parameters.Add("@gp_codrequis", objGenp001.pCodrequis) : comm.Parameters.Add("@gp_codmapa", objGenp001.pCodmapa)
        comm.Parameters.Add("@gp_numpedidomp", objGenp001.pNumpedidomp) : comm.Parameters.Add("@gp_mapapedido", objGenp001.pMapapedido)
        comm.Parameters.Add("@gp_canc_pedauto", objGenp001.pCanc_pedauto) : comm.Parameters.Add("@gp_grade", objGenp001.pGrade)
        comm.Parameters.Add("@gp_codreqproc", objGenp001.pCodreqproc) : comm.Parameters.Add("@gp_tipocondpagto", objGenp001.pTipocondpagto)
        comm.Parameters.Add("@gp_cpfvalidar", objGenp001.pConfirmCPF) : comm.Parameters.Add("@gp_tptransfentrada", objGenp001.pTptransfentrada)
        comm.Parameters.Add("@gp_tptransfsaida", objGenp001.pTptransfsaida) : comm.Parameters.Add("@gp_sincroniza", objGenp001.pSincroniza)
        comm.Parameters.Add("@gp_comisavista", objGenp001.pComisavista)
        comm.Parameters.Add("@gp_comisaprazo", objGenp001.pComisaprazo) : comm.Parameters.Add("@gp_envioxml", objGenp001.pathEnvioXML)
        comm.Parameters.Add("@gp_lotxml", objGenp001.pathLotXML) : comm.Parameters.Add("@gp_retornoxml", objGenp001.pathRetornoXML)
        comm.Parameters.Add("@gp_enviadoxml", objGenp001.pathEnviadoXML) : comm.Parameters.Add("@gp_imagemcarne", objGenp001.imagemCarne)
        comm.Parameters.Add("@gp_sldfiscalnegativo", objGenp001.sldfiscalnegativo)
        comm.Parameters.Add("@gp_aplicacao", objGenp001.aplicacao)
        comm.Parameters.Add("@gp_tabletenvio", objGenp001.pathEnvioTablet)
        comm.Parameters.Add("@gp_tabletretorno", objGenp001.pathRetornoTablet)
        comm.Parameters.Add("@gp_palmenvio", objGenp001.pathEnvioPalm)
        comm.Parameters.Add("@gp_palmretorno", objGenp001.pathRetornoPalm)
        comm.Parameters.Add("@gp_tabletpathimg", objGenp001.pathImgTablet)
        comm.Parameters.Add("@gp_ftptablet", objGenp001.ftpTablet)
        comm.Parameters.Add("@gp_usuarioftptablet", objGenp001.usuarioFtpTablet)
        comm.Parameters.Add("@gp_senhaftptablet", objGenp001.senhaFtpTablet)
        comm.Parameters.Add("@gp_ftppalm", objGenp001.ftpPalm)
        comm.Parameters.Add("@gp_usuarioftppalm", objGenp001.usuarioFtpPalm)
        comm.Parameters.Add("@gp_senhaftppalm", objGenp001.senhaFtpPalm)
        comm.Parameters.Add("@gp_pauta", objGenp001.pauta)
        comm.Parameters.Add("@gp_descontonfe", objGenp001.descontonfe)
        comm.Parameters.Add("@gp_descontopedido", objGenp001.descontopedido)
        comm.Parameters.Add("@gp_pastasgbd", objGenp001.pastaSgbd)
        comm.Parameters.Add("@gp_logomarcapath", objGenp001.logomarcapath)


        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altGenp001(ByVal objGenp001 As Cl_Genp001, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE genp001 SET ")
        sqlbuild.Append("gp_requis = @gp_requis, gp_sai = @gp_sai, gp_fat = @gp_fat, gp_data = @gp_data, ")
        sqlbuild.Append("gp_icms = @gp_icms, gp_icmse = @gp_icmse, gp_alqiss = @gp_alqiss, gp_serv = @gp_serv, ")
        sqlbuild.Append("gp_orca = @gp_orca, gp_palm = @gp_palm, gp_txreduz = @gp_txreduz, gp_icmred = @gp_icmred, ")
        sqlbuild.Append("gp_txcob = @gp_txcob, gp_txipi = @gp_txipi, gp_txga = @gp_txga, gp_txesvei = @gp_txesvei, ")
        sqlbuild.Append("gp_serie = @gp_serie, gp_contf = @gp_contf, gp_amb = @gp_amb, gp_prazo = @gp_prazo, ")
        sqlbuild.Append("gp_seqnfe = @gp_seqnfe, gp_mensag = @gp_mensag, gp_pis = @gp_pis, gp_confin = @gp_confin, ")
        sqlbuild.Append("gp_alqsub = @gp_alqsub, gp_carencia = @gp_carencia, gp_codprod = @gp_codprod, ")
        sqlbuild.Append("gp_codrequis = @gp_codrequis, gp_codmapa = @gp_codmapa, gp_numpedidomp = @gp_numpedidomp, ")
        sqlbuild.Append("gp_mapapedido = @gp_mapapedido, gp_canc_pedauto = @gp_canc_pedauto, gp_grade = @gp_grade, ")
        sqlbuild.Append("gp_codreqproc = @gp_codreqproc, gp_tipocondpagto = @gp_tipocondpagto, gp_cpfvalidar = @gp_cpfvalidar, ")
        sqlbuild.Append("gp_tptransfentrada = @gp_tptransfentrada, gp_tptransfsaida = @gp_tptransfsaida, ")
        sqlbuild.Append("gp_comisavista = @gp_comisavista, gp_comisaprazo = @gp_comisaprazo, gp_envioxml = @gp_envioxml, ")
        sqlbuild.Append("gp_lotxml = @gp_lotxml, gp_retornoxml = @gp_retornoxml, gp_enviadoxml = @gp_enviadoxml, ")
        sqlbuild.Append("gp_imagemcarne = @gp_imagemcarne, gp_sldfiscalnegativo = @gp_sldfiscalnegativo, ")
        sqlbuild.Append("gp_aplicacao = @gp_aplicacao, gp_tabletenvio = @gp_tabletenvio, gp_tabletretorno = @gp_tabletretorno, ")
        sqlbuild.Append("gp_palmenvio = @gp_palmenvio, gp_palmretorno = @gp_palmretorno, gp_tabletpathimg = @gp_tabletpathimg, ")
        sqlbuild.Append("gp_ftptablet = @gp_ftptablet, gp_usuarioftptablet = @gp_usuarioftptablet, ")
        sqlbuild.Append("gp_senhaftptablet = @gp_senhaftptablet, gp_ftppalm = @gp_ftppalm, gp_usuarioftppalm = @gp_usuarioftppalm, ")
        sqlbuild.Append("gp_senhaftppalm = @gp_senhaftppalm, gp_pauta = @gp_pauta, gp_descontonfe = @gp_descontonfe, ")
        sqlbuild.Append("gp_descontopedido = @gp_descontopedido, gp_pastasgbd = @gp_pastasgbd, gp_logomarcapath = @gp_logomarcapath ")
        sqlbuild.Append("WHERE gp_geno = @gp_geno")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@gp_requis", objGenp001.pRequis) : comm.Parameters.Add("@gp_sai", objGenp001.pSai)
        comm.Parameters.Add("@gp_fat", objGenp001.pFat)

        Try
            comm.Parameters.Add("@gp_data", Convert.ChangeType(objGenp001.pData, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@gp_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@gp_icms", objGenp001.pIcms) : comm.Parameters.Add("@gp_icmse", objGenp001.pIcmse)
        comm.Parameters.Add("@gp_alqiss", objGenp001.pAlqiss) : comm.Parameters.Add("@gp_serv", objGenp001.pServ)
        comm.Parameters.Add("@gp_orca", objGenp001.pOrca) : comm.Parameters.Add("@gp_palm", objGenp001.pPalm)
        comm.Parameters.Add("@gp_txreduz", objGenp001.pTxreduz) : comm.Parameters.Add("@gp_icmred", objGenp001.pIcmred)
        comm.Parameters.Add("@gp_txcob", objGenp001.pTxcob) : comm.Parameters.Add("@gp_txipi", objGenp001.pTxipi)
        comm.Parameters.Add("@gp_txga", objGenp001.pTxga) : comm.Parameters.Add("@gp_txesvei", objGenp001.pTxesvei)
        comm.Parameters.Add("@gp_serie", objGenp001.pSerie) : comm.Parameters.Add("@gp_contf", objGenp001.pContf)
        comm.Parameters.Add("@gp_amb", objGenp001.pAmb) : comm.Parameters.Add("@gp_prazo", objGenp001.pPrazo)
        comm.Parameters.Add("@gp_seqnfe", objGenp001.pSeqnfe) : comm.Parameters.Add("@gp_mensag", objGenp001.pMensag)
        comm.Parameters.Add("@gp_pis", objGenp001.pPis) : comm.Parameters.Add("@gp_confin", objGenp001.pConfin)
        comm.Parameters.Add("@gp_alqsub", objGenp001.pAlqsub) : comm.Parameters.Add("@gp_geno", objGenp001.pGeno)
        comm.Parameters.Add("@gp_carencia", objGenp001.pCarencia) : comm.Parameters.Add("@gp_codprod", objGenp001.pCodprod)
        comm.Parameters.Add("@gp_codrequis", objGenp001.pCodrequis) : comm.Parameters.Add("@gp_codmapa", objGenp001.pCodmapa)
        comm.Parameters.Add("@gp_numpedidomp", objGenp001.pNumpedidomp) : comm.Parameters.Add("@gp_mapapedido", objGenp001.pMapapedido)
        comm.Parameters.Add("@gp_canc_pedauto", objGenp001.pCanc_pedauto) : comm.Parameters.Add("@gp_grade", objGenp001.pGrade)
        comm.Parameters.Add("@gp_codreqproc", objGenp001.pCodreqproc) : comm.Parameters.Add("@gp_tipocondpagto", objGenp001.pTipocondpagto)
        comm.Parameters.Add("@gp_cpfvalidar", objGenp001.pConfirmCPF) : comm.Parameters.Add("@gp_tptransfentrada", objGenp001.pTptransfentrada)
        comm.Parameters.Add("@gp_tptransfsaida", objGenp001.pTptransfsaida) : comm.Parameters.Add("@gp_comisavista", objGenp001.pComisavista)
        comm.Parameters.Add("@gp_comisaprazo", objGenp001.pComisaprazo) : comm.Parameters.Add("@gp_envioxml", objGenp001.pathEnvioXML)
        comm.Parameters.Add("@gp_lotxml", objGenp001.pathLotXML) : comm.Parameters.Add("@gp_retornoxml", objGenp001.pathRetornoXML)
        comm.Parameters.Add("@gp_enviadoxml", objGenp001.pathEnviadoXML) : comm.Parameters.Add("@gp_imagemcarne", objGenp001.imagemCarne)
        comm.Parameters.Add("@gp_sldfiscalnegativo", objGenp001.sldfiscalnegativo)
        comm.Parameters.Add("@gp_aplicacao", objGenp001.aplicacao)
        comm.Parameters.Add("@gp_tabletenvio", objGenp001.pathEnvioTablet)
        comm.Parameters.Add("@gp_tabletretorno", objGenp001.pathRetornoTablet)
        comm.Parameters.Add("@gp_palmenvio", objGenp001.pathEnvioPalm)
        comm.Parameters.Add("@gp_palmretorno", objGenp001.pathRetornoPalm)
        comm.Parameters.Add("@gp_tabletpathimg", objGenp001.pathImgTablet)
        comm.Parameters.Add("@gp_ftptablet", objGenp001.ftpTablet)
        comm.Parameters.Add("@gp_usuarioftptablet", objGenp001.usuarioFtpTablet)
        comm.Parameters.Add("@gp_senhaftptablet", objGenp001.senhaFtpTablet)
        comm.Parameters.Add("@gp_ftppalm", objGenp001.ftpPalm)
        comm.Parameters.Add("@gp_usuarioftppalm", objGenp001.usuarioFtpPalm)
        comm.Parameters.Add("@gp_senhaftppalm", objGenp001.senhaFtpPalm)
        comm.Parameters.Add("@gp_pauta", objGenp001.pauta)
        comm.Parameters.Add("@gp_descontonfe", objGenp001.descontonfe)
        comm.Parameters.Add("@gp_descontopedido", objGenp001.descontopedido)
        comm.Parameters.Add("@gp_pastasgbd", objGenp001.pastaSgbd)
        comm.Parameters.Add("@gp_logomarcapath", objGenp001.logomarcapath)



        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altGp_SaiGenp001(ByVal gp_sai As String, ByVal gp_geno As String, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE genp001 SET ")
        sqlbuild.Append("gp_sai = @gp_sai WHERE gp_geno = @gp_geno")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@gp_sai", gp_sai) : comm.Parameters.Add("@gp_geno", gp_geno)


        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altGp_SeqNFeGenp001(ByVal gp_seqnfe As String, ByVal gp_geno As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE genp001 SET ")
        sqlbuild.Append("gp_seqnfe = @gp_seqnfe WHERE gp_geno = @gp_geno")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@gp_seqnfe", gp_seqnfe) : comm.Parameters.Add("@gp_geno", gp_geno)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub altGp_IdLoteGenp001(ByVal gp_idLote As Int64, ByVal gp_geno As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE genp001 SET ")
        sqlbuild.Append("gp_idlote = @gp_idlote WHERE gp_geno = @gp_geno")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@gp_idlote", gp_idLote) : comm.Parameters.Add("@gp_geno", gp_geno)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Function trazProxCodGeno(ByVal conexao As NpgsqlConnection) As Int32

        Dim mCodGeno As Int32 = 0
        Dim drGeno As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT (CAST(MAX(SUBSTR(g_codig, 2, 4)) AS INTEGER) + 1) AS ""Codigo"" FROM Geno001"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        drGeno = comm.ExecuteReader
        While drGeno.Read

            Try
                mCodGeno = drGeno(0)
            Catch ex As Exception
            End Try
        End While

        drGeno.Close() : drGeno = Nothing : comm = Nothing : sqlcmd = Nothing
        If mCodGeno = 0 Then mCodGeno = 1


        Return mCodGeno
    End Function

    Public Function existCNPJGeno001(ByVal cnpj As String, ByVal codGeno As String, ByVal conexao As String) As Boolean

        Dim conection As New NpgsqlConnection(conexao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        Dim mCodGeno As Int32 = 0
        Dim drGeno As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT * FROM Geno001 WHERE g_codig <> @g_codig AND g_cgc = @g_cgc "

        comm = New NpgsqlCommand(sqlcmd.ToString, conection)
        comm.Parameters.Add("@g_cgc", cnpj)
        comm.Parameters.Add("@g_codig", codGeno)
        drGeno = comm.ExecuteReader
        If drGeno.HasRows = True Then

            conection.Close() : conection = Nothing : drGeno.Close()
            comm = Nothing : sqlcmd = Nothing : Return True
        End If

        conection.Close() : conection = Nothing : drGeno.Close()
        comm = Nothing : sqlcmd = Nothing


        Return False
    End Function

    Public Function existInscricaoGeno001(ByVal inscricao As String, ByVal codGeno As String, ByVal conexao As String) As Boolean

        Dim conection As New NpgsqlConnection(conexao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        Dim mCodGeno As Int32 = 0
        Dim drGeno As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT * FROM Geno001 WHERE g_codig <> @g_codig AND g_insc = @g_insc"

        comm = New NpgsqlCommand(sqlcmd.ToString, conection)
        comm.Parameters.Add("@g_insc", inscricao)
        comm.Parameters.Add("@g_codig", codGeno)
        drGeno = comm.ExecuteReader
        If drGeno.HasRows = True Then

            conection.Close() : conection = Nothing : drGeno.Close()
            comm = Nothing : sqlcmd = Nothing : Return True
        End If

        conection.Close() : conection = Nothing : drGeno.Close()
        comm = Nothing : sqlcmd = Nothing

        Return False
    End Function

    Public Sub incCaixaNaLoja(ByVal cx_loja As String, ByVal cx_codcaixa As String, ByVal cx_funcao As String, _
                            ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO caixa(")
        sqlbuild.Append("cx_id, cx_loja, cx_codcaixa, cx_funcao) ")
        sqlbuild.Append("VALUES (DEFAULT, @cx_loja, @cx_codcaixa, @cx_funcao)")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@cx_loja", cx_loja) : comm.Parameters.Add("@cx_codcaixa", cx_codcaixa)
        comm.Parameters.Add("@cx_funcao", cx_funcao)
        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function Caixa_fechado(ByVal DtFechada As Date, ByVal Mtipo As String, ByVal Loja As String, ByVal Caixa As String, _
                                  ByVal conexao As String) As Boolean

        Dim mexiste As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT cx_data,cx_tipo FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_data = @cx_data and cx_tipo=@cx_tipo ")
            SqlCmd.Append("and cx_caixa=@cx_caixa and cx_loja=@cx_loja")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@cx_data", Convert.ChangeType(DtFechada, GetType(Date)))
            Cmd.Parameters.Add("@cx_tipo", Mtipo)
            Cmd.Parameters.Add("@cx_caixa", Caixa)
            Cmd.Parameters.Add("@cx_loja", "G0" + Loja)
            dr = Cmd.ExecuteReader

            If dr.HasRows Then mexiste = True

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : mexiste = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing

        Return mexiste
    End Function

#End Region

#Region "  * * Manutenção de vínculo * *  "

    Public Sub incVinculo(ByVal v_codvinc As Int32, ByVal v_descricao As String, ByVal v_usuario As String, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO vinculo(")
        sqlbuild.Append("v_id, v_codvinc, v_descricao, v_usuario) ")
        sqlbuild.Append("VALUES (DEFAULT, @v_codvinc, @v_descricao, @v_usuario);")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@v_codvinc", v_codvinc) : comm.Parameters.Add("@v_descricao", v_descricao)
        comm.Parameters.Add("@v_usuario", v_usuario)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altVinculo(ByVal v_id As Int32, ByVal v_descricao As String, _
                          ByVal v_usuario As String, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE vinculo ")
        sqlbuild.Append("SET v_descricao = @v_descricao, v_usuario = @v_usuario ")
        sqlbuild.Append("WHERE v_id = @v_id")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@v_id", v_id) : comm.Parameters.Add("@v_descricao", v_descricao)
        comm.Parameters.Add("@v_usuario", v_usuario)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delVinculo(ByVal v_id As Int32, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("DELETE FROM vinculo WHERE v_id = @v_id")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@v_id", v_id)
        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function trazProxCodVínculo(ByVal conexao As NpgsqlConnection) As Int32

        Dim mCodVinculo As Int32 = 0
        Dim drVinculo As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT (MAX(v_codvinc) + 1) AS ""Codigo"" FROM vinculo"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        drVinculo = comm.ExecuteReader
        While drVinculo.Read

            Try
                mCodVinculo = drVinculo(0)
            Catch ex As Exception
                mCodVinculo = 0
            End Try
        End While

        drVinculo.Close() : drVinculo = Nothing : comm = Nothing : sqlcmd = Nothing
        If mCodVinculo = 0 Then mCodVinculo = 1



        Return mCodVinculo
    End Function

#End Region

#Region " * * *  Requisição * * *  "

    Public Sub inclueRequisicao(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                                     ByVal numRequis As String, ByVal dataRequis As Date, _
                                     ByVal codProdRequis As String, ByVal qtdeRequis As Double, _
                                     ByVal usuarioRequis As String)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "INSERT INTO " & MdlEmpresaUsu._esqEstab & ".requisicao(id, reqnumero, reqdata, reqcodprod, " & _
        "reqqtde, requsuario) VALUES (DEFAULT, @reqnumero, @reqdata, @reqcodprod, @reqqtde, " & _
        "@requsuario);"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@reqnumero", numRequis)
        comm.Parameters.Add("@reqdata", Convert.ChangeType(dataRequis, GetType(Date)))
        comm.Parameters.Add("@reqcodprod", codProdRequis)
        comm.Parameters.Add("@reqqtde", qtdeRequis)
        comm.Parameters.Add("@requsuario", usuarioRequis)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub updateCadregCodRequis(ByVal conexao As NpgsqlConnection, ByVal codRequis As String, _
                                     ByVal geno As String)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE genp001 SET gp_codrequis = @gp_codrequis WHERE gp_geno = @gp_geno"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_codrequis", codRequis)
        comm.Parameters.Add("@gp_geno", geno)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

#End Region

#Region " * * *  Requisição para Transferência * * *  "

    Public Sub inclueReqTransferencia(ByVal objReqTransf As Cl_ReqTransferencia, ByVal conexao As NpgsqlConnection, _
                                      ByVal transacao As NpgsqlTransaction)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "INSERT INTO " & MdlEmpresaUsu._esqEstab & ".reqtransf(id, reqnumero, reqdata, reqcodprod, " & _
        "reqqtde, requsuario, reqcoddestino, reqnomedestino) VALUES (DEFAULT, @reqnumero, @reqdata, @reqcodprod, @reqqtde, " & _
        "@requsuario, @reqcoddestino, @reqnomedestino);"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@reqnumero", objReqTransf.pReqNumero)
        comm.Parameters.Add("@reqdata", Convert.ChangeType(objReqTransf.pReqData, GetType(Date)))
        comm.Parameters.Add("@reqcodprod", objReqTransf.pReqCodprod)
        comm.Parameters.Add("@reqqtde", objReqTransf.pReqQtde)
        comm.Parameters.Add("@requsuario", objReqTransf.pReqUsuario)
        comm.Parameters.Add("@reqcoddestino", objReqTransf.pReqCoddestino)
        comm.Parameters.Add("@reqnomedestino", objReqTransf.pReqNomedestino)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function trazNumAtualReqTransf(ByVal conexao As NpgsqlConnection) As String

        Dim mNumero As String = ""
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT currval('" & MdlEmpresaUsu._esqEstab & ".reqtransf_id_seq'::regclass)"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        dr = comm.ExecuteReader
        While dr.Read

            mNumero = dr(0).ToString
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumero
    End Function

    Public Function trazNumAtualReqTransf(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction) As String

        Dim mNumero As String = ""
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT currval('" & MdlEmpresaUsu._esqEstab & ".reqtransf_id_seq'::regclass)"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao, transacao)
        dr = comm.ExecuteReader
        While dr.Read

            mNumero = dr(0).ToString
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumero
    End Function

    Public Function trazProxNumReqTransf(ByVal conexao As NpgsqlConnection) As Int64

        Dim mNumero As Int64 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT nextval('" & MdlEmpresaUsu._esqEstab & ".reqtransf_id_seq'::regclass)"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        dr = comm.ExecuteReader
        While dr.Read

            Try
                mNumero = dr(0)
            Catch ex As Exception
                mNumero = 1
            End Try
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumero
    End Function

#End Region

#Region "* * *   Manutenção do Mapa   * * *"

    Public Sub incMapa1pp(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal numMapa As String, ByVal dtEmissao As Date, ByVal dtSaida As Date, _
                          ByVal vlrTotalMapa As Double, ByVal local As String, ByVal idVeic As Int32, _
                          ByVal placaVeic As String)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "INSERT INTO " & MdlEmpresaUsu._esqEstab & ".mapa1pp( mv_mpid, mv_numero, mv_emissao, mv_saida, mv_total, " _
        & "mv_local, mv_placaveic, mv_idveic) VALUES (DEFAULT, @mv_numero, @mv_emissao, @mv_saida, " _
        & "@mv_total, @mv_local, @mv_placaveic, @mv_idveic);"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@mv_numero", numMapa)
        comm.Parameters.Add("@mv_emissao", Convert.ChangeType(dtEmissao, GetType(Date)))
        comm.Parameters.Add("@mv_saida", Convert.ChangeType(dtSaida, GetType(Date)))
        comm.Parameters.Add("@mv_total", vlrTotalMapa)
        comm.Parameters.Add("@mv_local", local)
        comm.Parameters.Add("@mv_placaveic", placaVeic)
        comm.Parameters.Add("@mv_idveic", idVeic)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub incMapa1ppr(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                         ByVal numMapa As String, ByVal dtEmissao As Date, ByVal dtSaida As Date, _
                         ByVal vlrTotalMapa As Double, ByVal local As String, ByVal idVeic As Int32, _
                          ByVal placaVeic As String)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "INSERT INTO " & MdlEmpresaUsu._esqEstab & ".mapa1ppr( mvr_mpid, mvr_numero, mvr_emissao, mvr_saida, mvr_total, " _
        & "mvr_local, mvr_placaveic, mvr_idveic) VALUES (DEFAULT, @mvr_numero, @mvr_emissao, @mvr_saida, " _
        & "@mvr_total, @mvr_local, @mvr_placaveic, @mvr_idveic);"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@mvr_numero", numMapa)
        comm.Parameters.Add("@mvr_emissao", Convert.ChangeType(dtEmissao, GetType(Date)))
        comm.Parameters.Add("@mvr_saida", Convert.ChangeType(dtSaida, GetType(Date)))
        comm.Parameters.Add("@mvr_total", vlrTotalMapa)
        comm.Parameters.Add("@mvr_local", local)
        comm.Parameters.Add("@mvr_placaveic", placaVeic)
        comm.Parameters.Add("@mvr_idveic", idVeic)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub incMapa2cc(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal mpId As Int32, ByVal numMapa As String, ByVal cod As String, _
                          ByVal nome As String, ByVal und As String, ByVal qtde As Double, _
                          ByVal vlrUnit As Double, ByVal vlrTotal As Double, ByVal pesoBruto As Double, _
                          ByVal pesoLiq As Double, ByVal codBarra As String, ByVal local As String)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "INSERT INTO " & MdlEmpresaUsu._esqEstab & ".mapa2cc(mc_id, mc_mpid, mc_numero, mc_codpr, mc_descricao, " _
        & "mc_und, mc_qtde, mc_valorunit, mc_total, mc_pesobruto, mc_pesoliq, mc_codbarra, mc_local)" _
        & "VALUES (DEFAULT, @mc_mpid, @mc_numero, @mc_codpr, @mc_descricao, @mc_und, @mc_qtde, " _
        & "@mc_valorunit, @mc_total, @mc_pesobruto, @mc_pesoliq, @mc_codbarra, @mc_local);"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@mc_mpid", mpId)
        comm.Parameters.Add("@mc_numero", numMapa)
        comm.Parameters.Add("@mc_codpr", cod)
        comm.Parameters.Add("@mc_descricao", nome)
        comm.Parameters.Add("@mc_und", und)
        comm.Parameters.Add("@mc_qtde", qtde)
        comm.Parameters.Add("@mc_valorunit", vlrUnit)
        comm.Parameters.Add("@mc_total", vlrTotal)
        comm.Parameters.Add("@mc_pesobruto", pesoBruto)
        comm.Parameters.Add("@mc_pesoliq", pesoLiq)
        comm.Parameters.Add("@mc_codbarra", codBarra)
        comm.Parameters.Add("@mc_local", local)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub incMapa2ccr(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                         ByVal mpId As Int32, ByVal numMapa As String, ByVal cod As String, _
                         ByVal nome As String, ByVal und As String, ByVal qtde As Double, _
                         ByVal vlrUnit As Double, ByVal vlrTotal As Double, ByVal pesoBruto As Double, _
                         ByVal pesoLiq As Double, ByVal codBarra As String, ByVal local As String)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "INSERT INTO " & MdlEmpresaUsu._esqEstab & ".mapa2ccr(mcr_id, mcr_mpid, mcr_numero, mcr_codpr, mcr_descricao, " _
        & "mcr_und, mcr_qtde, mcr_valorunit, mcr_total, mcr_pesobruto, mcr_pesoliq, mcr_codbarra, mcr_local)" _
        & "VALUES (DEFAULT, @mcr_mpid, @mcr_numero, @mcr_codpr, @mcr_descricao, @mcr_und, @mcr_qtde, " _
        & "@mcr_valorunit, @mcr_total, @mcr_pesobruto, @mcr_pesoliq, @mcr_codbarra, @mcr_local);"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@mcr_mpid", mpId)
        comm.Parameters.Add("@mcr_numero", numMapa)
        comm.Parameters.Add("@mcr_codpr", cod)
        comm.Parameters.Add("@mcr_descricao", nome)
        comm.Parameters.Add("@mcr_und", und)
        comm.Parameters.Add("@mcr_qtde", qtde)
        comm.Parameters.Add("@mcr_valorunit", vlrUnit)
        comm.Parameters.Add("@mcr_total", vlrTotal)
        comm.Parameters.Add("@mcr_pesobruto", pesoBruto)
        comm.Parameters.Add("@mcr_pesoliq", pesoLiq)
        comm.Parameters.Add("@mcr_codbarra", codBarra)
        comm.Parameters.Add("@mcr_local", local)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub somaQtdeMapa2ccr(ByVal conexao As NpgsqlConnection, ByVal numMapa As String, _
                        ByVal codProd As String, ByVal qtde As Double)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".mapa2ccr SET mcr_qtde = (mcr_qtde + @mcr_qtde) WHERE mcr_numero = @mcr_numero " _
        & "AND mcr_codpr = @mcr_codpr"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@mcr_numero", numMapa)
        comm.Parameters.Add("@mcr_codpr", codProd)
        comm.Parameters.Add("@mcr_qtde", qtde)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub alteraVlrTotalMapa2ccr(ByVal conexao As NpgsqlConnection, ByVal numMapa As String, _
                        ByVal codProd As String)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".mapa2ccr SET mcr_total = (mcr_valorunit * mcr_qtde) WHERE " _
        & "mcr_numero = @mcr_numero AND mcr_codpr = @mcr_codpr"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@mcr_numero", numMapa)
        comm.Parameters.Add("@mcr_codpr", codProd)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub subtraiQtdeMapa2ccr(ByVal conexao As NpgsqlConnection, ByVal numMapa As String, _
                        ByVal codProd As String, ByVal qtde As Double)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".mapa2ccr SET mcr_qtde = (mcr_qtde - @mcr_qtde) WHERE mcr_numero = @mcr_numero " _
        & "AND mcr_codpr = @mcr_codpr"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@mcr_numero", numMapa)
        comm.Parameters.Add("@mcr_codpr", codProd)
        comm.Parameters.Add("@mcr_qtde", qtde)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function trazIdMapa1pp(ByVal conexao As NpgsqlConnection, ByVal numMapa As String) As Int32

        Dim idMp As Int32 = 0
        Dim drMp As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT mv_mpid FROM " & MdlEmpresaUsu._esqEstab & ".mapa1pp WHERE mv_numero = @mv_numero"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@mv_numero", numMapa)
        drMp = comm.ExecuteReader
        While drMp.Read

            idMp = drMp(0)
        End While

        drMp.Close() : drMp = Nothing : comm = Nothing : sqlcmd = Nothing


        Return idMp
    End Function

    Public Function trazIdMapa1ppr(ByVal conexao As NpgsqlConnection, ByVal numMapa As String) As Int32

        Dim idMp As Int32 = 0
        Dim drMp As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT mvr_mpid FROM " & MdlEmpresaUsu._esqEstab & ".mapa1ppr WHERE mvr_numero = @mvr_numero"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@mvr_numero", numMapa)
        drMp = comm.ExecuteReader
        While drMp.Read

            idMp = drMp(0)
        End While

        drMp.Close() : drMp = Nothing : comm = Nothing : sqlcmd = Nothing


        Return idMp
    End Function

#End Region

#Region " * * *   Requisição de Processo   * * * "

    Public Sub inclueRequProcCli(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                                    ByVal idRequis As Int64, ByVal numRequis As String, ByVal partRequis As String, _
                                    ByVal codProdRequis As String, ByVal qtdeRequis As Double, ByVal dataRequis As Date, _
                                    ByVal descrProdRequis As String, ByVal usuarioRequis As String)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "INSERT INTO " & MdlEmpresaUsu._esqEstab & ".estm300( r_id, r_req, r_cdport, " & _
        "r_codpr, r_qtde, r_data, r_desc, r_nome) VALUES (DEFAULT, @r_req, @r_cdport, @r_codpr, @r_qtde, @r_data, " & _
        "@r_desc, @r_nome);"


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@r_req", numRequis)
        comm.Parameters.Add("@r_cdport", partRequis)
        comm.Parameters.Add("@r_codpr", codProdRequis)
        comm.Parameters.Add("@r_qtde", qtdeRequis)
        comm.Parameters.Add("@r_data", Convert.ChangeType(dataRequis, GetType(Date)))
        comm.Parameters.Add("@r_desc", descrProdRequis)
        comm.Parameters.Add("@r_nome", usuarioRequis)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function trazNumAtualReqProc(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                                        ByVal codEmpresa As String) As Int64
        Dim mNumero As Int64 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT gp_codreqproc FROM genp001 WHERE gp_geno = '" & codEmpresa & "'"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        dr = comm.ExecuteReader
        While dr.Read

            mNumero = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumero
    End Function

    Public Sub atualizaNumAtualReqProc(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                                        ByVal codEmpresa As String, ByVal codRequiProc As Int64)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE genp001 SET gp_codreqproc = (gp_codreqproc + 1) WHERE gp_geno = '" & codEmpresa & "'"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@codreqproc", codRequiProc)
        comm.ExecuteNonQuery()

        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub somaQtdeProdProcessoCli(ByVal conexao As NpgsqlConnection, ByVal codPartProcesso As String, _
                                     ByVal codProdProcesso As String, ByVal qtde As Double)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".estm400 SET gr_saldo = (gr_saldo + @gr_saldo) " & _
        "WHERE gr_cdport = @gr_cdport AND gr_codpr = @gr_codpr"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gr_cdport", codPartProcesso)
        comm.Parameters.Add("@gr_codpr", codProdProcesso)
        comm.Parameters.Add("@gr_saldo", qtde)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub somaQtdeProdProcessoCli(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                                       ByVal codPartProcesso As String, ByVal codProdProcesso As String, _
                                       ByVal qtde As Double)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".estm400 SET gr_saldo = (gr_saldo + @gr_saldo) " & _
        "WHERE gr_cdport = @gr_cdport AND gr_codpr = @gr_codpr"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gr_cdport", codPartProcesso)
        comm.Parameters.Add("@gr_codpr", codProdProcesso)
        comm.Parameters.Add("@gr_saldo", qtde)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub diminueQtdeProdProcessoCli(ByVal conexao As NpgsqlConnection, ByVal codPartProcesso As String, _
                                     ByVal codProdProcesso As String, ByVal qtde As Double)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".estm400 SET gr_saldo = (gr_saldo - @gr_saldo) " & _
        "WHERE gr_cdport = @gr_cdport AND gr_codpr = @gr_codpr"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gr_cdport", codPartProcesso)
        comm.Parameters.Add("@gr_codpr", codProdProcesso)
        comm.Parameters.Add("@gr_saldo", qtde)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub diminueQtdeProdProcessoCli(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                                          ByVal codPartProcesso As String, ByVal codProdProcesso As String, _
                                          ByVal qtde As Double)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".estm400 SET gr_saldo = (gr_saldo - @gr_saldo) " & _
        "WHERE gr_cdport = @gr_cdport AND gr_codpr = @gr_codpr"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gr_cdport", codPartProcesso)
        comm.Parameters.Add("@gr_codpr", codProdProcesso)
        comm.Parameters.Add("@gr_saldo", qtde)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function trazQtdeEstm400(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                                        ByVal codCliente As String, ByVal codProd As String) As Double
        Dim mNumero As Double = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT gr_saldo FROM " & MdlEmpresaUsu._esqEstab & ".estm400 WHERE gr_cdport = '" & codCliente & "' AND gr_codpr = '" & codProd & "'"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        dr = comm.ExecuteReader
        While dr.Read

            mNumero = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumero
    End Function


#End Region

#Region "* *  Manutenção de Comodato  * *"

    Public Sub incComodato(ByVal mTipo As String, ByVal mModelo As String, ByVal mCodPart As String, _
                        ByVal mNomePart As String, ByVal mPlaqueta As String, ByVal mObservacao As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqVinc & ".cadimobilizado(")
        sqlbuild.Append("im_codprid, im_tipo, im_modelo, im_cdport, im_portad, im_plaqueta, ")
        sqlbuild.Append("im_observ)")
        sqlbuild.Append("VALUES (DEFAULT, @im_tipo, @im_modelo, @im_cdport, @im_portad, @im_plaqueta, ")
        sqlbuild.Append("@im_observ);")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@im_tipo", mTipo) : comm.Parameters.Add("@im_modelo", mModelo)
        comm.Parameters.Add("@im_cdport", mCodPart) : comm.Parameters.Add("@im_portad", mNomePart)
        comm.Parameters.Add("@im_plaqueta", mPlaqueta) : comm.Parameters.Add("@im_observ", mObservacao)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altComodato(ByVal mCodigo As Int32, ByVal mTipo As String, ByVal mModelo As String, ByVal mCodPart As String, _
                        ByVal mNomePart As String, ByVal mPlaqueta As String, ByVal mObservacao As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqVinc & ".cadimobilizado ")
        sqlbuild.Append("SET im_tipo = @im_tipo, im_modelo = @im_modelo, im_cdport = @im_cdport, ")
        sqlbuild.Append("im_portad = @im_portad, im_plaqueta = @im_plaqueta, im_observ = @im_observ ")
        sqlbuild.Append("WHERE im_codprid = @im_codprid")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@im_codprid", mCodigo)
        comm.Parameters.Add("@im_tipo", mTipo) : comm.Parameters.Add("@im_modelo", mModelo)
        comm.Parameters.Add("@im_cdport", mCodPart) : comm.Parameters.Add("@im_portad", mNomePart)
        comm.Parameters.Add("@im_plaqueta", mPlaqueta) : comm.Parameters.Add("@im_observ", mObservacao)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

#End Region

#Region "  * * Manutenção das Unidades de Medida * *  "

    Public Sub incUnidadeMedida(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                         ByVal medida As String, ByVal descricao As String)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO medida(")
        sqlbuild.Append("m_id, medida, descricao) VALUES (DEFAULT, @medida, @descricao);")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@medida", medida)
        comm.Parameters.Add("@descricao", descricao)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altUnidadeMedida(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal id As Int32, ByVal medida As String, ByVal descricao As String)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE medida SET ")
        sqlbuild.Append("medida = @medida, descricao = @descricao WHERE m_id = @m_id")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@m_id", id)
        comm.Parameters.Add("@medida", medida)
        comm.Parameters.Add("@descricao", descricao)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delUnidadeMedida(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal id As Int32)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM medida WHERE m_id = @m_id")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@m_id", id)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function existeUnidadeMedida(ByVal conexao As NpgsqlConnection, ByVal medida As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT m_id FROM medida WHERE medida = @medida;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@medida", medida)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeDescUnidade(ByVal conexao As NpgsqlConnection, ByVal descricao As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT m_id FROM medida WHERE descricao = @descricao;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@descricao", descricao)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeDescUnidadeAlt(ByVal conexao As NpgsqlConnection, ByVal descricaoAtual As String, _
                                     ByVal descricaoAnterior As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT m_id FROM medida WHERE descricao <> @descranterior AND " & _
        "descricao = @descratual;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@descratual", descricaoAtual)
        comm.Parameters.Add("@descranterior", descricaoAnterior)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

#End Region

#Region "  * * Manutenção de Rotas * *  "

    Public Sub incRota(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                         ByVal destino As String, ByVal acresc1 As Double, _
                          ByVal acresc2 As Double, ByVal acresc3 As Double, ByVal acresc4 As Double, _
                          ByVal acresc5 As Double)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO cadrotas(")
        sqlbuild.Append("rt_rota, rt_destino, rt_acresc1, rt_acresc2, rt_acresc3, rt_acresc4, ")
        sqlbuild.Append("rt_acresc5) VALUES (DEFAULT, @rt_destino, @rt_acresc1, @rt_acresc2, ")
        sqlbuild.Append("@rt_acresc3, @rt_acresc4, @rt_acresc5);")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@rt_destino", destino)
        comm.Parameters.Add("@rt_acresc1", acresc1)
        comm.Parameters.Add("@rt_acresc2", acresc2)
        comm.Parameters.Add("@rt_acresc3", acresc3)
        comm.Parameters.Add("@rt_acresc4", acresc4)
        comm.Parameters.Add("@rt_acresc5", acresc5)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altRota(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal rota As Int32, ByVal destino As String, ByVal acresc1 As Double, _
                          ByVal acresc2 As Double, ByVal acresc3 As Double, ByVal acresc4 As Double, _
                          ByVal acresc5 As Double)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE cadrotas SET ")
        sqlbuild.Append("rt_destino = @rt_destino, rt_acresc1 = @rt_acresc1, rt_acresc2 = ")
        sqlbuild.Append("@rt_acresc2, rt_acresc3 = @rt_acresc3, rt_acresc4 = @rt_acresc4, ")
        sqlbuild.Append("rt_acresc5 = @rt_acresc5 WHERE rt_rota = @rt_rota")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@rt_rota", rota)
        comm.Parameters.Add("@rt_destino", destino)
        comm.Parameters.Add("@rt_acresc1", acresc1)
        comm.Parameters.Add("@rt_acresc2", acresc2)
        comm.Parameters.Add("@rt_acresc3", acresc3)
        comm.Parameters.Add("@rt_acresc4", acresc4)
        comm.Parameters.Add("@rt_acresc5", acresc5)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delRota(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal rota As Int32)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("DELETE FROM cadrotas WHERE rt_rota = @rt_rota")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@rt_rota", rota)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function existeRota(ByVal conexao As NpgsqlConnection, ByVal destino As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT rt_rota FROM cadrotas WHERE rt_destino = @rt_destino;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@rt_destino", destino)

        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeRota2(ByVal conexao As NpgsqlConnection, ByVal destinoAtual As String, _
                                     ByVal destinoAnterior As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT rt_rota FROM cadrotas WHERE rt_destino <> @rt_destinoanterior AND " & _
        "rt_destino = @rt_destinoatual;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@rt_destinoatual", destinoAtual)
        comm.Parameters.Add("@rt_destinoanterior", destinoAnterior)

        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

#End Region

#Region "* *  Manutenção de Movimento de Comodatos  * *"

    Public Sub incMovComodato(ByVal mCodPart As String, ByVal mCodProd As Int32, ByVal mnomeProd As String, _
                        ByVal mDtEmprestimo As Date, ByVal mDtDevolucao As Date, ByVal mMotorista As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqVinc & ".movcomodato(")
        sqlbuild.Append("mc_id, mc_cdport, mc_codpr, mc_produto, mc_dtemprestimo, mc_dtdevolucao, ")
        sqlbuild.Append("mc_motorista)")
        sqlbuild.Append("VALUES (DEFAULT, @mc_cdport, @mc_codpr, @mc_produto, @mc_dtemprestimo, @mc_dtdevolucao, ")
        sqlbuild.Append("@mc_motorista);")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@mc_cdport", mCodPart) : comm.Parameters.Add("@mc_codpr", mCodProd)
        comm.Parameters.Add("@mc_produto", mnomeProd) : comm.Parameters.Add("@mc_dtemprestimo", Convert.ChangeType(mDtEmprestimo, GetType(Date)))
        comm.Parameters.Add("@mc_dtdevolucao", Convert.ChangeType(mDtDevolucao, GetType(Date))) : comm.Parameters.Add("@mc_motorista", mMotorista)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altMovComodato(ByVal mIdMvComod As Int32, ByVal mCodPart As String, ByVal mCodProd As Int32, ByVal mnomeProd As String, _
                        ByVal mDtEmprestimo As Date, ByVal mDtDevolucao As Date, ByVal mMotorista As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqVinc & ".movcomodato ")
        sqlbuild.Append("SET mc_cdport = @mc_cdport, mc_codpr = @mc_codpr, mc_produto = @mc_produto, ")
        sqlbuild.Append("mc_dtemprestimo = @mc_dtemprestimo, mc_dtdevolucao = @mc_dtdevolucao, ")
        sqlbuild.Append("mc_motorista = @mc_motorista WHERE mc_id = @mc_id")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@mc_id", mIdMvComod)
        comm.Parameters.Add("@mc_cdport", mCodPart) : comm.Parameters.Add("@mc_codpr", mCodProd)
        comm.Parameters.Add("@mc_produto", mnomeProd) : comm.Parameters.Add("@mc_dtemprestimo", Convert.ChangeType(mDtEmprestimo, GetType(Date)))
        comm.Parameters.Add("@mc_dtdevolucao", Convert.ChangeType(mDtDevolucao, GetType(Date))) : comm.Parameters.Add("@mc_motorista", mMotorista)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delMovComodato(ByVal mIdMvComod As Int32, ByVal conexao As NpgsqlConnection, _
                              ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqVinc & ".movcomodato WHERE mc_id = @mc_id")
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@mc_id", mIdMvComod)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function existeMovComodato(ByVal mIdMovComod As Int32, ByVal mIdCodpr As Int32, _
                                      ByVal conexao As NpgsqlConnection) As Boolean
        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder
        Dim dr As NpgsqlDataReader


        sqlbuild.Append("SELECT * FROM " & MdlEmpresaUsu._esqVinc & ".movcomodato WHERE mc_codpr = @mc_codpr ")
        sqlbuild.Append("AND mc_dtdevolucao >= CURRENT_DATE AND mc_id <> @mc_id")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@mc_codpr", mIdCodpr)
        comm.Parameters.Add("@mc_id", mIdMovComod)

        dr = comm.ExecuteReader
        If dr.HasRows = True Then Return True

        dr.Close() : comm = Nothing : sqlbuild = Nothing : dr = Nothing


        Return False
    End Function

#End Region

#Region " * *  Manutenção de Participante  CADP001 * * "

    Public Sub inclueParticipante(ByVal clCadp001 As Cl_Cadp001, ByVal conexao As NpgsqlConnection, _
                                  ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO cadp001(")
        sqlbuild.Append("p_tipo, p_carac, p_dtcad, p_cod, p_portad, p_fantas, p_civil, ")
        sqlbuild.Append("p_dtnativ, p_natur, p_ident, p_cpf, p_cgc, p_insc, p_pai, p_mae, ")
        sqlbuild.Append("p_end, p_bairro, p_cid, p_uf, p_cep, p_fone, p_ltrab, p_endtr, ")
        sqlbuild.Append("p_fontr, p_cargo, p_salar, p_esposo, p_crt, p_ltrabe, p_salae, ")
        sqlbuild.Append("p_rota, p_vend, p_obs1, p_obs2, p_obs3, p_ultcomp, p_valor, p_limite, ")
        sqlbuild.Append("p_pedido, p_cdvend, p_cdcid, p_bloq, p_tb, p_consumo, p_mun, ")
        sqlbuild.Append("p_coduf, p_ctactb, p_ctaanli, p_mes, p_fax, p_prep, p_email, ")
        sqlbuild.Append("p_sexo, p_celular, p_inativo, p_usuario, p_isento, p_iddoutor, p_doutor, p_ficha) VALUES (")
        sqlbuild.Append("@p_tipo, @p_carac, @p_dtcad, @p_cod, @p_portad, @p_fantas, @p_civil, ")
        sqlbuild.Append("@p_dtnativ, @p_natur, @p_ident, @p_cpf, @p_cgc, @p_insc, @p_pai, @p_mae, ")
        sqlbuild.Append("@p_end, @p_bairro, @p_cid, @p_uf, @p_cep, @p_fone, @p_ltrab, @p_endtr, ")
        sqlbuild.Append("@p_fontr, @p_cargo, @p_salar, @p_esposo, @p_crt, @p_ltrabe, @p_salae, ")
        sqlbuild.Append("@p_rota, @p_vend, @p_obs1, @p_obs2, @p_obs3, @p_ultcomp, @p_valor, @p_limite, ")
        sqlbuild.Append("@p_pedido, @p_cdvend, @p_cdcid, @p_bloq, @p_tb, @p_consumo, @p_mun, ")
        sqlbuild.Append("@p_coduf, @p_ctactb, @p_ctaanli, @p_mes, @p_fax, @p_prep, @p_email, ")
        sqlbuild.Append("@p_sexo, @p_celular, @p_inativo, @p_usuario, @p_isento, @p_iddoutor, @p_doutor, @p_ficha);")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@p_tipo", clCadp001.pTipo)
        comm.Parameters.Add("@p_carac", clCadp001.pCarac)

        Try
            comm.Parameters.Add("@p_dtcad", Convert.ChangeType(clCadp001.pDtcad, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@p_dtcad", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@p_cod", clCadp001.pCod)
        comm.Parameters.Add("@p_portad", clCadp001.pPortad)
        comm.Parameters.Add("@p_fantas", clCadp001.pFantas)
        comm.Parameters.Add("@p_civil", clCadp001.pCivil)

        Try
            comm.Parameters.Add("@p_dtnativ", Convert.ChangeType(clCadp001.pDtnativ, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@p_dtnativ", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@p_natur", clCadp001.pNatur)
        comm.Parameters.Add("@p_ident", clCadp001.pIdent)
        comm.Parameters.Add("@p_cpf", clCadp001.pCpf)
        comm.Parameters.Add("@p_cgc", clCadp001.pCgc)
        comm.Parameters.Add("@p_insc", clCadp001.pInsc)
        comm.Parameters.Add("@p_pai", clCadp001.pPai)
        comm.Parameters.Add("@p_mae", clCadp001.pMae)
        comm.Parameters.Add("@p_end", clCadp001.pEnder)
        comm.Parameters.Add("@p_bairro", clCadp001.pBairro)
        comm.Parameters.Add("@p_cid", clCadp001.pCid)
        comm.Parameters.Add("@p_uf", clCadp001.pUf)
        comm.Parameters.Add("@p_cep", clCadp001.pCep)
        comm.Parameters.Add("@p_fone", clCadp001.pFone)
        comm.Parameters.Add("@p_ltrab", clCadp001.pLtrab)
        comm.Parameters.Add("@p_endtr", clCadp001.pEndtr)
        comm.Parameters.Add("@p_fontr", clCadp001.pFontr)
        comm.Parameters.Add("@p_cargo", clCadp001.pCargo)
        comm.Parameters.Add("@p_salar", clCadp001.pSalar)
        comm.Parameters.Add("@p_esposo", clCadp001.pEsposo)
        comm.Parameters.Add("@p_crt", clCadp001.pCrt)
        comm.Parameters.Add("@p_ltrabe", clCadp001.pLtrabe)
        comm.Parameters.Add("@p_salae", clCadp001.pSalae)
        comm.Parameters.Add("@p_rota", clCadp001.pRota)
        comm.Parameters.Add("@p_vend", clCadp001.pVend)
        comm.Parameters.Add("@p_obs1", clCadp001.pObs1)
        comm.Parameters.Add("@p_obs2", clCadp001.pObs2)
        comm.Parameters.Add("@p_obs3", clCadp001.pObs3)

        Try
            comm.Parameters.Add("@p_ultcomp", Convert.ChangeType(clCadp001.pUltcomp, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@p_ultcomp", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@p_valor", clCadp001.pValor)
        comm.Parameters.Add("@p_limite", clCadp001.pLimite)
        comm.Parameters.Add("@p_pedido", clCadp001.pPedido)
        comm.Parameters.Add("@p_cdvend", clCadp001.pCdvend)
        comm.Parameters.Add("@p_cdcid", clCadp001.pCdcid)
        comm.Parameters.Add("@p_bloq", clCadp001.pBloq)
        comm.Parameters.Add("@p_tb", clCadp001.pTb)
        comm.Parameters.Add("@p_consumo", clCadp001.pConsumo)
        comm.Parameters.Add("@p_mun", clCadp001.pMun)
        comm.Parameters.Add("@p_coduf", clCadp001.pCoduf)
        comm.Parameters.Add("@p_ctactb", clCadp001.pCtactb)
        comm.Parameters.Add("@p_ctaanli", clCadp001.pCtaanli)
        comm.Parameters.Add("@p_mes", clCadp001.pMes)
        comm.Parameters.Add("@p_fax", clCadp001.pFax)
        comm.Parameters.Add("@p_prep", clCadp001.pPrep)
        comm.Parameters.Add("@p_email", clCadp001.pEmail)
        comm.Parameters.Add("@p_sexo", clCadp001.pSexo)
        comm.Parameters.Add("@p_celular", clCadp001.pCelular)
        comm.Parameters.Add("@p_inativo", clCadp001.pInativo)
        comm.Parameters.Add("@p_usuario", clCadp001.pUsuario)
        comm.Parameters.Add("@p_isento", clCadp001.pIsento)
        comm.Parameters.Add("@p_iddoutor", clCadp001.iddoutor)
        comm.Parameters.Add("@p_doutor", clCadp001.doutor)
        comm.Parameters.Add("@p_ficha", clCadp001.ficha)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altParticipante(ByVal clCadp001 As Cl_Cadp001, ByVal codAtual As String, _
                               ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE cadp001 SET ")
        sqlbuild.Append("p_tipo = @p_tipo, p_cod = @p_cod, p_carac = @p_carac, p_dtcad = @p_dtcad, p_portad = @p_portad, ")
        sqlbuild.Append("p_fantas = @p_fantas, p_civil = @p_civil, p_dtnativ = @p_dtnativ, p_natur = @p_natur, ")
        sqlbuild.Append("p_ident = @p_ident, p_cpf = @p_cpf, p_cgc = @p_cgc, p_insc = @p_insc, p_pai = @p_pai, ")
        sqlbuild.Append("p_mae = @p_mae, p_end = @p_end, p_bairro = @p_bairro, p_cid = @p_cid, p_uf = @p_uf, ")
        sqlbuild.Append("p_cep = @p_cep, p_fone = @p_fone, p_ltrab = @p_ltrab, p_endtr = @p_endtr, p_fontr = @p_fontr, ")
        sqlbuild.Append("p_cargo = @p_cargo, p_salar = @p_salar, p_esposo = @p_esposo, p_crt = @p_crt, ")
        sqlbuild.Append("p_ltrabe = @p_ltrabe, p_salae = @p_salae, p_rota = @p_rota, p_vend = @p_vend, ")
        sqlbuild.Append("p_obs1 = @p_obs1, p_obs2 = @p_obs2, p_obs3 = @p_obs3, ")
        sqlbuild.Append("p_valor = @p_valor, p_limite = @p_limite, p_pedido = @p_pedido, p_cdvend = @p_cdvend, ")
        sqlbuild.Append("p_cdcid = @p_cdcid, p_bloq = @p_bloq, p_tb = @p_tb, p_consumo = @p_consumo, p_mun = @p_mun, ")
        sqlbuild.Append("p_coduf = @p_coduf, p_ctactb = @p_ctactb, p_ctaanli = @p_ctaanli, p_mes = @p_mes, ")
        sqlbuild.Append("p_fax = @p_fax, p_prep = @p_prep, p_email = @p_email, p_sexo = @p_sexo, p_celular = @p_celular, ")
        sqlbuild.Append("p_inativo = @p_inativo, p_isento = @p_isento, p_iddoutor = @p_iddoutor, p_doutor = @p_doutor, ")
        sqlbuild.Append("p_ficha = @p_ficha WHERE p_cod = '" & codAtual & "'")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@p_tipo", clCadp001.pTipo)
        comm.Parameters.Add("@p_carac", clCadp001.pCarac)

        Try
            comm.Parameters.Add("@p_dtcad", Convert.ChangeType(clCadp001.pDtcad, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@p_dtcad", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@p_cod", clCadp001.pCod)
        comm.Parameters.Add("@p_portad", clCadp001.pPortad)
        comm.Parameters.Add("@p_fantas", clCadp001.pFantas)
        comm.Parameters.Add("@p_civil", clCadp001.pCivil)

        Try
            comm.Parameters.Add("@p_dtnativ", Convert.ChangeType(clCadp001.pDtnativ, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@p_dtnativ", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@p_natur", clCadp001.pNatur)
        comm.Parameters.Add("@p_ident", clCadp001.pIdent)
        comm.Parameters.Add("@p_cpf", clCadp001.pCpf)
        comm.Parameters.Add("@p_cgc", clCadp001.pCgc)
        comm.Parameters.Add("@p_insc", clCadp001.pInsc)
        comm.Parameters.Add("@p_pai", clCadp001.pPai)
        comm.Parameters.Add("@p_mae", clCadp001.pMae)
        comm.Parameters.Add("@p_end", clCadp001.pEnder)
        comm.Parameters.Add("@p_bairro", clCadp001.pBairro)
        comm.Parameters.Add("@p_cid", clCadp001.pCid)
        comm.Parameters.Add("@p_uf", clCadp001.pUf)
        comm.Parameters.Add("@p_cep", clCadp001.pCep)
        comm.Parameters.Add("@p_fone", clCadp001.pFone)
        comm.Parameters.Add("@p_ltrab", clCadp001.pLtrab)
        comm.Parameters.Add("@p_endtr", clCadp001.pEndtr)
        comm.Parameters.Add("@p_fontr", clCadp001.pFontr)
        comm.Parameters.Add("@p_cargo", clCadp001.pCargo)
        comm.Parameters.Add("@p_salar", clCadp001.pSalar)
        comm.Parameters.Add("@p_esposo", clCadp001.pEsposo)
        comm.Parameters.Add("@p_crt", clCadp001.pCrt)
        comm.Parameters.Add("@p_ltrabe", clCadp001.pLtrabe)
        comm.Parameters.Add("@p_salae", clCadp001.pSalae)
        comm.Parameters.Add("@p_rota", clCadp001.pRota)
        comm.Parameters.Add("@p_vend", clCadp001.pVend)
        comm.Parameters.Add("@p_obs1", clCadp001.pObs1)
        comm.Parameters.Add("@p_obs2", clCadp001.pObs2)
        comm.Parameters.Add("@p_obs3", clCadp001.pObs3)
        'comm.Parameters.Add("@p_ultcomp", clCadp001.pultcomp)
        comm.Parameters.Add("@p_valor", clCadp001.pValor)
        comm.Parameters.Add("@p_limite", clCadp001.pLimite)
        comm.Parameters.Add("@p_pedido", clCadp001.pPedido)
        comm.Parameters.Add("@p_cdvend", clCadp001.pCdvend)
        comm.Parameters.Add("@p_cdcid", clCadp001.pCdcid)
        comm.Parameters.Add("@p_bloq", clCadp001.pBloq)
        comm.Parameters.Add("@p_tb", clCadp001.pTb)
        comm.Parameters.Add("@p_consumo", clCadp001.pConsumo)
        comm.Parameters.Add("@p_mun", clCadp001.pMun)
        comm.Parameters.Add("@p_coduf", clCadp001.pCoduf)
        comm.Parameters.Add("@p_ctactb", clCadp001.pCtactb)
        comm.Parameters.Add("@p_ctaanli", clCadp001.pCtaanli)
        comm.Parameters.Add("@p_mes", clCadp001.pMes)
        comm.Parameters.Add("@p_fax", clCadp001.pFax)
        comm.Parameters.Add("@p_prep", clCadp001.pPrep)
        comm.Parameters.Add("@p_email", clCadp001.pEmail)
        comm.Parameters.Add("@p_sexo", clCadp001.pSexo)
        comm.Parameters.Add("@p_celular", clCadp001.pCelular)
        comm.Parameters.Add("@p_inativo", clCadp001.pInativo)
        comm.Parameters.Add("@p_isento", clCadp001.pIsento)
        comm.Parameters.Add("@p_iddoutor", clCadp001.iddoutor)
        comm.Parameters.Add("@p_doutor", clCadp001.doutor)
        comm.Parameters.Add("@p_ficha", clCadp001.ficha)

        comm.ExecuteNonQuery()


        sqlbuild = Nothing : comm = Nothing
    End Sub

    Public Sub excParticipante(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                               ByVal Codigo As String)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "DELETE FROM cadp001 WHERE p_cod = '" & Codigo & "'"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Transaction = transacao

        comm.ExecuteNonQuery()


        sqlcmd = Nothing : comm = Nothing
    End Sub

    Public Sub desabilitaParticipante(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                               ByVal Codigo As String)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE cadp001 SET p_inativo = TRUE WHERE p_cod = '" & Codigo & "'"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Transaction = transacao

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub habilitaParticipante(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                               ByVal Codigo As String)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE cadp001 SET p_inativo = FALSE WHERE p_cod = '" & Codigo & "'"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Transaction = transacao

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function trazUltimoCodForn(ByVal conexao As NpgsqlConnection) As Int32

        Dim mCodForn As Int32 = 0
        Dim drForn As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT (CAST(MAX(SUBSTR(p_cod, 2, 5)) AS INTEGER)) AS ""Codigo"" FROM cadp001 " '"SELECT (CAST(MAX(SUBSTR(p_cod, 2, 5)) AS INTEGER) + 1) AS ""Codigo"" FROM cadp001"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        drForn = comm.ExecuteReader
        While drForn.Read

            mCodForn = drForn(0)
        End While

        drForn.Close() : drForn = Nothing : sqlcmd = Nothing : comm = Nothing
        If mCodForn = 0 Then mCodForn = 1


        Return mCodForn
    End Function

    Public Function trazCodMun(ByVal conexao As NpgsqlConnection, ByVal siglaEstado As String, _
                               ByVal nomeMunicipio As String) As String

        Dim mCodMun As String = ""
        Dim drForn As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT codigo FROM cadmun WHERE nome = @nome AND sigla_estado = @sigla_estado"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@nome", nomeMunicipio)
        comm.Parameters.Add("@sigla_estado", siglaEstado)
        drForn = comm.ExecuteReader
        While drForn.Read

            mCodMun = drForn(0)
        End While

        drForn.Close() : drForn = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mCodMun
    End Function

    Public Function trazCodEstado(ByVal conexao As NpgsqlConnection, ByVal siglaEstado As String) As String

        Dim mCodEstado As String = ""
        Dim drForn As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT codestado FROM cadestado WHERE sigla = @sigla "

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@sigla", siglaEstado)
        drForn = comm.ExecuteReader
        While drForn.Read

            mCodEstado = drForn(0)
        End While

        drForn.Close() : drForn = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mCodEstado
    End Function

    Public Function trazIdEstado(ByVal conexao As NpgsqlConnection, ByVal siglaEstado As String) As Int32

        Dim mIdEstado As String = 0
        Dim drForn As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT id FROM cadestado WHERE sigla = @sigla "

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@sigla", siglaEstado)
        drForn = comm.ExecuteReader
        While drForn.Read

            mIdEstado = drForn(0)
        End While

        drForn.Close() : drForn = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mIdEstado
    End Function

#End Region

#Region "   * * Manutenção de Roteiro * *   "

    Public Sub incRoteiroMapa(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                         ByVal mapa As Integer, ByVal roteiro As String, ByVal dtalteracao As Date)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".rotmapa(")
        sqlbuild.Append("rt_id, rt_mapa, rt_roteiro, rt_ateracao) ")
        sqlbuild.Append("VALUES (DEFAULT, @rt_mapa, @rt_roteiro, @rt_ateracao);")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@rt_mapa", mapa)
        comm.Parameters.Add("@rt_roteiro", roteiro)
        comm.Parameters.Add("@rt_ateracao", Convert.ChangeType(dtalteracao, GetType(Date)))

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altRoteiroMapa(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                         ByVal mapa As Integer, ByVal roteiro As String, ByVal dtalteracao As Date)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".rotmapa ")
        sqlbuild.Append("SET rt_roteiro = @rt_roteiro, rt_ateracao = @rt_ateracao ")
        sqlbuild.Append("WHERE rt_mapa = @rt_mapa")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@rt_mapa", mapa)
        comm.Parameters.Add("@rt_roteiro", roteiro)
        comm.Parameters.Add("@rt_ateracao", Convert.ChangeType(dtalteracao, GetType(Date)))

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function existeMapaRoteiro(ByVal conexao As NpgsqlConnection, ByVal mapa As Integer) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT rt_mapa FROM " & MdlEmpresaUsu._esqEstab & ".rotmapa WHERE rt_mapa = @rt_mapa;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@rt_mapa", mapa)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

#End Region

#Region "  * * Manutenção de Serviços * *  "

    Public Sub incServico(ByVal objServico As Cl_Servico, ByVal conexao As NpgsqlConnection, _
                           ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO servico(")
        sqlbuild.Append("s_id, s_descricao, s_valor) ")
        sqlbuild.Append("VALUES (DEFAULT, @s_descricao, @s_valor);")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@s_descricao", objServico.pDescricao)
        comm.Parameters.Add("@s_valor", objServico.pValor)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altServico(ByVal objServico As Cl_Servico, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE servico SET ")
        sqlbuild.Append("s_descricao = @s_descricao, s_valor = @s_valor ")
        sqlbuild.Append("WHERE s_id = @s_id ")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@s_id", objServico.pIdServico)
        comm.Parameters.Add("@s_descricao", objServico.pDescricao)
        comm.Parameters.Add("@s_valor", objServico.pValor)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delServiço(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal id As Int32)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM servico WHERE s_id = @s_id")
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@s_id", id)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

#End Region

#Region "  * * Manutenção de Municípios * *  "

    Public Sub incMunicipio(ByVal objMunicipio As Cl_Municipio, ByVal conexao As NpgsqlConnection, _
                            ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO cadmun(")
        sqlbuild.Append("id, id_estado, sigla_estado, cod_estado, codigo, nome) ")
        sqlbuild.Append("VALUES (DEFAULT, @id_estado, @sigla_estado, @cod_estado, @codigo, @nome);")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id_estado", objMunicipio.pIdEstado)
        comm.Parameters.Add("@sigla_estado", objMunicipio.pSiglaEstado)
        comm.Parameters.Add("@cod_estado", objMunicipio.pCodEstado)
        comm.Parameters.Add("@codigo", objMunicipio.pCodMun)
        comm.Parameters.Add("@nome", objMunicipio.pNomeMun)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altMunicipio(ByVal id As Int32, ByVal objMunicipio As Cl_Municipio, _
                            ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE cadmun SET ")
        sqlbuild.Append("id_estado = @id_estado, sigla_estado = @sigla_estado, cod_estado = @cod_estado, ")
        sqlbuild.Append("codigo = @codigo, nome = @nome WHERE id = @id")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", id)
        comm.Parameters.Add("@id_estado", objMunicipio.pIdEstado)
        comm.Parameters.Add("@sigla_estado", objMunicipio.pSiglaEstado)
        comm.Parameters.Add("@cod_estado", objMunicipio.pCodEstado)
        comm.Parameters.Add("@codigo", objMunicipio.pCodMun)
        comm.Parameters.Add("@nome", objMunicipio.pNomeMun)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delMunicipio(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal id As Int32)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM cadmun WHERE id = @id")
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", id)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function existeNomeServico(ByVal conexao As NpgsqlConnection, ByVal nome As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT s_id FROM servico WHERE s_descricao = @s_descricao"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@s_descricao", nome)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeNomeServicoAlt(ByVal conexao As NpgsqlConnection, ByVal nome As String, _
                                     ByVal nomeAnterior As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT s_id FROM servico WHERE s_descricao <> @nomeAnterior AND s_descricao = @nome"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@nome", nome)
        comm.Parameters.Add("@nomeAnterior", nomeAnterior)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeNomeCidade(ByVal conexao As NpgsqlConnection, _
                                     ByVal siglaEstado As String, ByVal nome As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT id FROM cadmun WHERE sigla_estado = @sigla_estado AND nome = @nome;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@sigla_estado", siglaEstado)
        comm.Parameters.Add("@nome", nome)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeNomeCidadeAlt(ByVal conexao As NpgsqlConnection, _
                                     ByVal siglaEstado As String, ByVal nome As String, _
                                     ByVal nomeAnterior As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT id FROM cadmun WHERE sigla_estado = @sigla_estado AND " & _
        "nome <> @nomeAnterior AND nome = @nome"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@sigla_estado", siglaEstado)
        comm.Parameters.Add("@nome", nome)
        comm.Parameters.Add("@nomeAnterior", nomeAnterior)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeCodigoCidade(ByVal conexao As NpgsqlConnection, _
                                     ByVal codCidade As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT id FROM cadmun WHERE codigo = @codigo"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@codigo", codCidade)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeCodigoCidadeAlt(ByVal conexao As NpgsqlConnection, _
                                     ByVal codCidade As String, ByVal codCidadeAnt As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT id FROM cadmun WHERE codigo <> @codigo AND codigo = @codigoAnt"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@codigo", codCidade)
        comm.Parameters.Add("@codigoAnt", codCidadeAnt)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

#End Region

#Region "  * * Manutenção da tabela de preços * *  "

    Public Sub deleteRegistrosTabelaPrecos(ByVal strConnection As String, ByVal esqVinculo As String, _
                                 ByVal codVinculo As Integer)

        Dim connection As New NpgsqlConnection(strConnection)
        Dim transacao As NpgsqlTransaction
        Dim commInc As New NpgsqlCommand
        Dim sqlbuildInclui As New StringBuilder

        Dim dr As NpgsqlDataReader
        Dim codProduto As String = "", precoProduto As Double
        Dim descrCondPagto As String = "", colTblPreco As Integer = 0, colTblRotas As Integer = 0
        Dim idRota As Integer = 0

        Try
            connection.Open()
            transacao = connection.BeginTransaction
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return
        End Try


        'Inclue na tabela de preços...
        sqlbuildInclui.Append("DELETE FROM " & esqVinculo & ".precorota")
        commInc.Transaction = transacao
        commInc = New NpgsqlCommand(sqlbuildInclui.ToString, connection)

        commInc.ExecuteNonQuery()

        sqlbuildInclui.Remove(0, sqlbuildInclui.ToString.Length) : commInc.CommandText = ""
        transacao.Commit() : transacao = Nothing : sqlbuildInclui = Nothing : commInc = Nothing
        connection.Close() : connection.ClearAllPools() : connection = Nothing
    End Sub

    Public Sub preencheTodaTabelaPrecos(ByVal strConnection As String, ByVal esqVinculo As String, _
                                 ByVal codVinculo As Integer)

        Dim connection As New NpgsqlConnection(strConnection)
        Dim connectionAlterar As New NpgsqlConnection(strConnection)
        Dim transacao As NpgsqlTransaction
        Dim commInc As New NpgsqlCommand
        Dim commSelec As New NpgsqlCommand
        Dim sqlbuildInclui As New StringBuilder
        Dim sqlbuildSelec As New StringBuilder

        Dim strBuilderProduto As New StringBuilder
        Dim strBuilderRotas As New StringBuilder

        Dim marrayProduto As Array, marrayProdutoAux As Array
        Dim marrayRotas As Array, marrayRotasAux As Array

        Dim mIndiceProduto As Integer, mIndiceRotas As Integer

        Dim dr As NpgsqlDataReader
        Dim codProduto As String = "", precoProduto As Double
        Dim descrCondPagto As String = "", colTblPreco As Integer = 0, colTblRotas As Integer = 0
        Dim idRota As Integer = 0

        Try
            connection.Open()
            connectionAlterar.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return
        End Try

        '##################################################################################
        'Traz Todos os PRODUTOS do vínculo, que estão no ESTLOJA01 ...
        sqlbuildSelec.Append("SELECT DISTINCT e.e_codig FROM " & esqVinculo & ".est0001 e ORDER BY e.e_codig ")
        commSelec = New NpgsqlCommand(sqlbuildSelec.ToString, connection)
        dr = commSelec.ExecuteReader
        While dr.Read

            strBuilderProduto.Append(dr(0).ToString & "?")
        End While
        dr.Close() : commSelec.CommandText = "" : sqlbuildSelec.Remove(0, sqlbuildSelec.ToString.Length)



        '##################################################################################
        'Traz Todas as ROTAS ...
        sqlbuildSelec.Append("SELECT rt_rota FROM cadrotas ORDER BY rt_rota")
        commSelec = New NpgsqlCommand(sqlbuildSelec.ToString, connection)
        dr = commSelec.ExecuteReader
        While dr.Read

            strBuilderRotas.Append(dr(0).ToString & "?")
        End While
        dr.Close() : commSelec.CommandText = "" : sqlbuildSelec.Remove(0, sqlbuildSelec.ToString.Length)



        transacao = connectionAlterar.BeginTransaction
        '##################################################################################
        ' Percorre todos os PRODUTOS do vínculo ...
        marrayProduto = Split(strBuilderProduto.ToString, "?")
        For mIndiceProduto = 0 To marrayProduto.Length - 2

            marrayProdutoAux = Split(marrayProduto(mIndiceProduto).ToString, "|")
            codProduto = marrayProdutoAux(0).ToString

            Try

                ' Percorre todas as ROTAS...
                marrayRotas = Split(strBuilderRotas.ToString, "?")
                For mIndiceRotas = 0 To marrayRotas.Length - 2

                    marrayRotasAux = Split(marrayRotas(mIndiceRotas).ToString, "|")
                    idRota = CInt(marrayRotasAux(0).ToString)


                    'Inclue na tabela de preços...
                    sqlbuildInclui.Append("INSERT INTO " & esqVinculo & ".precorota(")
                    sqlbuildInclui.Append("pr_id, pr_codpr, pr_preco1, pr_preco2, pr_preco3, pr_preco4, ")
                    sqlbuildInclui.Append("pr_preco5, pr_preco6, pr_preco7, pr_rota) ")
                    sqlbuildInclui.Append("VALUES (DEFAULT, @pr_codpr, @pr_preco1, @pr_preco2, @pr_preco3, ")
                    sqlbuildInclui.Append("@pr_preco4, @pr_preco5, @pr_preco6, @pr_preco7, @pr_rota) ")

                    commInc.Transaction = transacao
                    commInc = New NpgsqlCommand(sqlbuildInclui.ToString, connectionAlterar)

                    ' Prepara Paramentros
                    commInc.Parameters.Add("@pr_codpr", codProduto)
                    commInc.Parameters.Add("@pr_rota", idRota)
                    commInc.Parameters.Add("@pr_preco1", 0.0)
                    commInc.Parameters.Add("@pr_preco2", 0.0)
                    commInc.Parameters.Add("@pr_preco3", 0.0)
                    commInc.Parameters.Add("@pr_preco4", 0.0)
                    commInc.Parameters.Add("@pr_preco5", 0.0)
                    commInc.Parameters.Add("@pr_preco6", 0.0)
                    commInc.Parameters.Add("@pr_preco7", 0.0)

                    commInc.ExecuteNonQuery()

                    sqlbuildInclui.Remove(0, sqlbuildInclui.ToString.Length)
                    commInc.CommandText = ""



                Next

            Catch ex As Exception
                MsgBox("ERRO::" & ex.Message)

            End Try

        Next
        strBuilderProduto.Remove(0, strBuilderProduto.Length)
        strBuilderRotas.Remove(0, strBuilderRotas.Length)

        connection.Close() : connection = Nothing
        transacao.Commit() : transacao = Nothing
        connectionAlterar.Close() : connectionAlterar.ClearAllPools() : connectionAlterar = Nothing

    End Sub

    Public Sub atualTodaTabelaPrecos(ByVal strConnection As String, ByVal esqVinculo As String, _
                                 ByVal codVinculo As Integer, ByVal loja As String)

        Dim connection As New NpgsqlConnection(strConnection)
        Dim connectionAlterar As New NpgsqlConnection(strConnection)
        Dim transacao As NpgsqlTransaction
        Dim commAlt As New NpgsqlCommand
        Dim commSelec As New NpgsqlCommand
        Dim sqlbuildAltera As New StringBuilder
        Dim sqlbuildSelec As New StringBuilder

        Dim strBuilderProduto As New StringBuilder
        Dim strBuilderCondPagto As New StringBuilder
        Dim strBuilderRotas As New StringBuilder

        Dim marrayProduto As Array, marrayProdutoAux As Array
        Dim marrayCondPagto As Array, marrayCondPagtoAux As Array
        Dim marrayRotas As Array, marrayRotasAux As Array

        Dim mIndiceProduto As Integer, mIndiceCondPagto As Integer, mIndiceRotas As Integer

        Dim dr As NpgsqlDataReader
        Dim codProduto As String = "", precoProduto As Double, acrescimo As Double, precoAtualProd As Double
        Dim descrCondPagto As String = "", colTblPreco As Integer = 0, colTblRotas As Integer = 0
        Dim idRota As Integer = 0

        connection.Open()
        connectionAlterar.Open()

        '##################################################################################
        'Traz Todos os PRODUTOS do vínculo, que estão no ESTLOJA01 ...
        sqlbuildSelec.Append("SELECT DISTINCT e.e_codig, (SELECT DISTINCT el.e_pvenda FROM estloja01 el ")
        sqlbuildSelec.Append("WHERE el.e_idvinculo = @e_idvinculo AND el.e_codig = e.e_codig AND ")
        sqlbuildSelec.Append("el.e_loja = @e_loja AND el.e_pvenda > 0 LIMIT 1) FROM " & esqVinculo & ".est0001 e ORDER BY e.e_codig ")
        commSelec = New NpgsqlCommand(sqlbuildSelec.ToString, connection)
        ' Prepara Paramentros
        commSelec.Parameters.Add("@e_idvinculo", codVinculo)
        commSelec.Parameters.Add("@e_loja", loja)
        dr = commSelec.ExecuteReader
        While dr.Read

            If IsNumeric(dr(1)) Then

                strBuilderProduto.Append(dr(0).ToString & "|" & dr(1) & "?")
            End If
        End While
        dr.Close() : commSelec.CommandText = "" : sqlbuildSelec.Remove(0, sqlbuildSelec.ToString.Length)



        '##################################################################################
        'Traz Todas as CONDIÇÕES ...
        sqlbuildSelec.Append("SELECT c.cpg_descricao, c.cpg_colpreco, c.cpg_colrotas FROM condpagto c ")
        sqlbuildSelec.Append("ORDER BY c.cpg_colpreco ASC")
        commSelec = New NpgsqlCommand(sqlbuildSelec.ToString, connection)
        dr = commSelec.ExecuteReader
        While dr.Read

            strBuilderCondPagto.Append(dr(0).ToString & "|" & dr(1) & "|" & dr(2) & "?")
        End While
        dr.Close() : commSelec.CommandText = "" : sqlbuildSelec.Remove(0, sqlbuildSelec.ToString.Length)



        '##################################################################################
        'Traz Todas as ROTAS ...
        sqlbuildSelec.Append("SELECT rt_rota FROM cadrotas ORDER BY rt_rota")
        commSelec = New NpgsqlCommand(sqlbuildSelec.ToString, connection)
        dr = commSelec.ExecuteReader
        While dr.Read

            strBuilderRotas.Append(dr(0).ToString & "?")
        End While
        dr.Close() : commSelec.CommandText = "" : sqlbuildSelec.Remove(0, sqlbuildSelec.ToString.Length)



        transacao = connectionAlterar.BeginTransaction
        '##################################################################################
        ' Percorre todos os PRODUTOS do vínculo...
        marrayProduto = Split(strBuilderProduto.ToString, "?")
        For mIndiceProduto = 0 To marrayProduto.Length - 2

            marrayProdutoAux = Split(marrayProduto(mIndiceProduto).ToString, "|")
            codProduto = marrayProdutoAux(0).ToString

            Try
                precoProduto = CDbl(marrayProdutoAux(1).ToString)


                ' Percorre todas as CONDIÇÕES de Pagamento...
                marrayCondPagto = Split(strBuilderCondPagto.ToString, "?")
                For mIndiceCondPagto = 0 To marrayCondPagto.Length - 2

                    marrayCondPagtoAux = Split(marrayCondPagto(mIndiceCondPagto).ToString, "|")
                    descrCondPagto = marrayCondPagtoAux(0).ToString
                    colTblPreco = marrayCondPagtoAux(1).ToString
                    colTblRotas = marrayCondPagtoAux(2).ToString


                    ' Percorre todas as ROTAS...
                    marrayRotas = Split(strBuilderRotas.ToString, "?")
                    For mIndiceRotas = 0 To marrayRotas.Length - 2

                        marrayRotasAux = Split(marrayRotas(mIndiceRotas).ToString, "|")
                        idRota = CInt(marrayRotasAux(0).ToString)


                        'Traz o ACRÉSCIMO da ROTA...
                        sqlbuildSelec.Append("Select rt.rt_acresc" & colTblRotas & " FROM cadrotas rt RIGHT JOIN ")
                        sqlbuildSelec.Append("condpagto c ON c.cpg_descricao = @cpg_descricao WHERE rt.rt_rota = @rota")
                        commSelec = New NpgsqlCommand(sqlbuildSelec.ToString, connection)

                        ' Prepara Paramentros
                        commSelec.Parameters.Add("@cpg_descricao", descrCondPagto)
                        commSelec.Parameters.Add("@rota", idRota)
                        dr = commSelec.ExecuteReader

                        While dr.Read

                            acrescimo = dr(0)

                            precoAtualProd = precoProduto + ((precoProduto * acrescimo) / 100)
                            'Altera a tabela de preços...
                            sqlbuildAltera.Append("UPDATE " & esqVinculo & ".precorota SET pr_preco" & colTblPreco & " = ")
                            sqlbuildAltera.Append("@precoatual ")
                            sqlbuildAltera.Append("WHERE pr_codpr = @pr_codpr AND pr_rota = @pr_rota")

                            commAlt.Transaction = transacao
                            commAlt = New NpgsqlCommand(sqlbuildAltera.ToString, connectionAlterar)

                            ' Prepara Paramentros
                            commAlt.Parameters.Add("@precoatual", precoAtualProd)
                            commAlt.Parameters.Add("@pr_codpr", codProduto)
                            commAlt.Parameters.Add("@pr_rota", idRota)

                            commAlt.ExecuteNonQuery()

                            sqlbuildAltera.Remove(0, sqlbuildAltera.ToString.Length)
                            commAlt.CommandText = ""

                        End While
                        dr.Close() : commSelec.CommandText = ""
                        sqlbuildSelec.Remove(0, sqlbuildSelec.ToString.Length)
                        sqlbuildAltera.Remove(0, sqlbuildAltera.ToString.Length)


                    Next

                Next
            Catch ex As Exception
                MsgBox("ERRO::" & ex.Message)

            End Try

        Next
        strBuilderProduto.Remove(0, strBuilderProduto.Length)
        strBuilderRotas.Remove(0, strBuilderRotas.Length)
        strBuilderCondPagto.Remove(0, strBuilderCondPagto.Length)

        connection.Close() : connection = Nothing
        transacao.Commit() : transacao = Nothing
        connectionAlterar.Close() : connectionAlterar.ClearAllPools() : connectionAlterar = Nothing

        MsgBox("Processo terminado com sucesso", MsgBoxStyle.Exclamation)
    End Sub

    Public Function trazPrecoTblRota(ByVal codProd As String, ByVal idRota As Integer, _
                                     ByVal coluna As Integer, ByVal vinculo As String, _
                                     ByVal conexao As NpgsqlConnection) As Double

        Dim mPrecoProd As Double = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT pr_preco" & coluna & " FROM " & vinculo & ".precorota WHERE " & _
        "pr_codpr = @pr_codpr AND pr_rota = " & idRota

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@pr_codpr", codProd)
        dr = comm.ExecuteReader
        While dr.Read

            mPrecoProd = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mPrecoProd
    End Function

    Public Function trazColunaTblPreco(ByVal descrCondicao As String, ByVal conexao As NpgsqlConnection) As Int32

        Dim mColuna As Int32 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT cpg_colpreco FROM condpagto WHERE cpg_descricao = '" & descrCondicao & "'"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        dr = comm.ExecuteReader
        While dr.Read

            mColuna = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mColuna
    End Function

#End Region

#Region "* * *  Manutenção CadRegistro  * * *"

    Public Sub updateCadreg(ByVal conexao As NpgsqlConnection, ByVal codcli As Int32, _
                           ByVal codprod As Int32, ByVal ctanalitica As String, _
                           ByVal ctareduz As String, ByVal gp_vendedor As String, _
                           ByVal gp_codrequis As Int32, ByVal gp_codmapa As Int32, _
                           ByVal gp_numpedidomp As Int32)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE cadreg SET gp_codcli = @gp_codcli, gp_codprod = @gp_codprod, " _
        & "ctanalitica = @ctanalitica, ctareduz = @ctareduz, gp_vendedor = @gp_vendedor "
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_codcli", codcli)
        comm.Parameters.Add("@gp_codprod", codprod)
        comm.Parameters.Add("@ctanalitica", ctanalitica)
        comm.Parameters.Add("@ctareduz", ctareduz)
        comm.Parameters.Add("@gp_vendedor", gp_vendedor)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub updateCadregCodcli(ByVal conexao As NpgsqlConnection, ByVal codcli As Int32)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE cadreg SET gp_codcli = @gp_codcli"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_codcli", codcli)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub updateCodprodVinculo(ByVal conexao As NpgsqlConnection, ByVal codprod As Int32)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE vinculo SET v_codprod = @v_codprod WHERE v_codvinc = " & MdlEmpresaUsu._vinculo
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@v_codprod", codprod)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub updateCadregCodVendedor(ByVal conexao As NpgsqlConnection, ByVal codvendedor As Int32)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE cadreg SET gp_vendedor = @gp_vendedor "
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_vendedor", codvendedor)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub updateGenp001CodRequis(ByVal conexao As NpgsqlConnection, ByVal codRequis As Int32, _
                                     ByVal geno As String)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE genp001 SET gp_codrequis = @gp_codrequis WHERE gp_geno = @gp_geno"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_codrequis", codRequis)
        comm.Parameters.Add("@gp_geno", geno)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub updateGenp001CodMapa(ByVal conexao As NpgsqlConnection, ByVal codMapa As Int32, _
                                   ByVal geno As String)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE genp001 SET gp_codmapa = @gp_codmapa WHERE gp_geno = @gp_geno"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_codmapa", codMapa)
        comm.Parameters.Add("@gp_geno", geno)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub updateGenp001MapaPedido(ByVal conexao As NpgsqlConnection, ByVal numMapa As Int32, _
                                   ByVal geno As String)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE genp001 SET gp_mapapedido = @gp_mapapedido WHERE gp_geno = @gp_geno"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_mapapedido", numMapa)
        comm.Parameters.Add("@gp_geno", geno)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub updateGenp001NumPedidoMp(ByVal conexao As NpgsqlConnection, ByVal numpedidomp As Int32, _
                                       ByVal geno As String)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE genp001 SET gp_numpedidomp = @gp_numpedidomp WHERE gp_geno = @gp_geno"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_numpedidomp", numpedidomp)
        comm.Parameters.Add("@gp_geno", geno)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function trazProxCodForn(ByVal conexao As NpgsqlConnection) As Int32
        Dim mCodForn As Int32 = 0
        Dim drForn As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT (gp_codcli + 1) AS ""Codigo"" FROM cadreg " '"SELECT (CAST(MAX(SUBSTR(p_cod, 2, 5)) AS INTEGER) + 1) AS ""Codigo"" FROM cadp001"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        drForn = comm.ExecuteReader
        While drForn.Read

            mCodForn = drForn(0)
        End While

        drForn.Close() : drForn = Nothing : comm = Nothing : sqlcmd = Nothing
        If mCodForn = 0 Then mCodForn = 1


        Return mCodForn
    End Function

    Public Function trazProxCodProd(ByVal conexao As NpgsqlConnection) As Int32
        Dim mCodProd As Int32 = 0
        Dim drProd As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT (v_codprod + 1) AS ""Codigo"" FROM vinculo WHERE v_codvinc = " & MdlEmpresaUsu._vinculo
        '"SELECT (CAST(MAX(SUBSTR(p_cod, 2, 5)) AS INTEGER) + 1) AS ""Codigo"" FROM cadp001"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        drProd = comm.ExecuteReader
        While drProd.Read

            mCodProd = drProd(0)
        End While

        drProd.Close() : drProd = Nothing : comm = Nothing : sqlcmd = Nothing
        If mCodProd = 0 Then mCodProd = 1


        Return mCodProd
    End Function

    Public Function trazProxCodVendedor(ByVal conexao As NpgsqlConnection) As Int32
        Dim mCodVendedor As Int32 = 0
        Dim drVendedor As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT (gp_vendedor + 1) AS ""Codigo"" FROM cadreg " '"SELECT (CAST(MAX(SUBSTR(p_cod, 2, 5)) AS INTEGER) + 1) AS ""Codigo"" FROM cadp001"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        drVendedor = comm.ExecuteReader
        While drVendedor.Read
            mCodVendedor = drVendedor(0)
        End While

        drVendedor.Close() : drVendedor = Nothing : comm = Nothing : sqlcmd = Nothing
        If mCodVendedor = 0 Then mCodVendedor = 1


        Return mCodVendedor
    End Function

    Public Function trazProxCodRequis(ByVal geno As String, ByVal conexao As NpgsqlConnection) As Int32
        Dim mCodRequis As Int32 = 0
        Dim drRequis As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT (gp_codrequis + 1) AS ""Codigo"" FROM genp001 WHERE gp_geno = @gp_geno" '"SELECT (CAST(MAX(SUBSTR(p_cod, 2, 5)) AS INTEGER) + 1) AS ""Codigo"" FROM cadp001"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_geno", geno)
        drRequis = comm.ExecuteReader
        While drRequis.Read

            mCodRequis = drRequis(0)
        End While

        drRequis.Close() : drRequis = Nothing : comm = Nothing : sqlcmd = Nothing
        If mCodRequis = 0 Then mCodRequis = 1


        Return mCodRequis
    End Function

    Public Function trazProxCodMapa(ByVal geno As String, ByVal conexao As NpgsqlConnection) As Int32
        Dim mCodRequis As Int32 = 0
        Dim drMp As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT (gp_codmapa + 1) AS ""Codigo"" FROM genp001 WHERE gp_geno = @gp_geno" '"SELECT (CAST(MAX(SUBSTR(p_cod, 2, 5)) AS INTEGER) + 1) AS ""Codigo"" FROM cadp001"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_geno", geno)
        drMp = comm.ExecuteReader
        While drMp.Read

            mCodRequis = drMp(0)
        End While

        drMp.Close() : drMp = Nothing : comm = Nothing : sqlcmd = Nothing
        If mCodRequis = 0 Then mCodRequis = 1


        Return mCodRequis
    End Function

    Public Function trazProxMapaPedido(ByVal geno As String, ByVal conexao As NpgsqlConnection) As Int32

        Dim mCodigo As Int32 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT (gp_mapapedido + 1) AS ""Codigo"" FROM genp001 WHERE gp_geno = @gp_geno" '"SELECT (CAST(MAX(SUBSTR(p_cod, 2, 5)) AS INTEGER) + 1) AS ""Codigo"" FROM cadp001"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_geno", geno)
        dr = comm.ExecuteReader
        While dr.Read

            mCodigo = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing
        If mCodigo = 0 Then mCodigo = 1


        Return mCodigo
    End Function

    Public Function trazProxNumPedidoMp(ByVal geno As String, ByVal conexao As NpgsqlConnection) As Int32
        Dim mCodRequis As Int32 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT (gp_numpedidomp + 1) AS ""Numero"" FROM genp001 WHERE gp_geno = @gp_geno" '"SELECT (CAST(MAX(SUBSTR(p_cod, 2, 5)) AS INTEGER) + 1) AS ""Codigo"" FROM cadp001"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_geno", geno)
        dr = comm.ExecuteReader
        While dr.Read

            mCodRequis = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing
        If mCodRequis = 0 Then mCodRequis = 1


        Return mCodRequis
    End Function

    Public Function trazproxNumCobcxa(ByVal conexao As NpgsqlConnection, vbanco As Integer) As Int64
        Dim mnumero As Int64 = 0
        Dim drCob As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT (crt_nossonumero) AS ""Nnumero"" FROM cadcarteira where crt_banco=" & vbanco

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        drCob = comm.ExecuteReader
        While drCob.Read

            mnumero = Convert.ToInt64(drCob(0))
        End While

        drCob.Close() : drCob = Nothing : comm = Nothing : sqlcmd = Nothing
        If mnumero = 0 Then mnumero = 1


        Return (mnumero)
    End Function

#End Region

#Region "*  *  *   Manutenção Orcamento   *  *  *"

    ' Inclusão de registro de cabeçalho do Orçamento
    Public Sub incOrcamento_Orca1(ByVal nt_id As Int64, ByVal orca As String, ByVal geno As String, ByVal codigo As String, ByVal dtemis As Date, ByVal dtsai As Date, ByVal TPemiss As Boolean, ByVal cfop As String, _
                         ByVal vendedor As String, ByVal cidade As String, ByVal itens As Integer, ByVal rota As Integer, ByVal peso As Double, ByVal x As String, ByVal y As String, ByVal parc As Integer, _
                         ByVal volume As Integer, ByVal tipo2 As String, ByVal auto As String, ByVal auto2 As String, ByVal cod1 As Integer, ByVal cod2 As Integer, ByVal cod3 As Integer, _
                         ByVal cod4 As Integer, ByVal cod5 As Integer, ByVal cod6 As Integer, ByVal cod7 As Integer, ByVal mapa As String, ByVal sit As String, ByVal uf As String, _
                         ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".tb_orca1(nt_orca, nt_geno, nt_codig, nt_dtemis, nt_dtsai,nt_emiss, nt_cfop, ")
        sqlbuild.Append("nt_vend, nt_cid, nt_itens, nt_rota, nt_peso, nt_x, nt_y, nt_parc,nt_cod1, nt_cod2, nt_volum, nt_tipo2, ")
        sqlbuild.Append("nt_auto, nt_auto2, nt_cod3, nt_cod4, nt_cod5, nt_cod6, nt_cod7, nt_id, nt_mapa, nt_sit, nt_uf) VALUES ")
        sqlbuild.Append("(@nt_orca, ") 'TRIM(to_char((SELECT currval('" & MdlEmpresaUsu._esqEstab & ".tb_orca1_nt_id_seq'::regclass)), '00000000'))
        sqlbuild.Append("@nt_geno, @nt_codig, @nt_dtemis, @nt_dtsai, @nt_emiss, @nt_cfop, @nt_vend, @nt_cid, @nt_itens, @nt_rota, ")
        sqlbuild.Append("@nt_peso, @nt_x, @nt_y, @nt_parc, @nt_cod1, @nt_cod2, @nt_volum, @nt_tipo2, @nt_auto, @nt_auto2, @nt_cod3, ")
        sqlbuild.Append("@nt_cod4, @nt_cod5, @nt_cod6, @nt_cod7, @nt_id, @nt_mapa, @nt_sit, @nt_uf)") 'DEFAULT


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_orca", orca) : comm.Parameters.Add("@nt_geno", geno)
        comm.Parameters.Add("@nt_codig", codigo) : comm.Parameters.Add("@nt_dtemis", Convert.ChangeType(dtemis, GetType(Date)))
        comm.Parameters.Add("@nt_dtsai", Convert.ChangeType(dtsai, GetType(Date))) : comm.Parameters.Add("@nt_emiss", TPemiss)
        comm.Parameters.Add("@nt_cfop", cfop) : comm.Parameters.Add("@nt_vend", vendedor)
        comm.Parameters.Add("@nt_cid", cidade) : comm.Parameters.Add("@nt_itens", itens)
        comm.Parameters.Add("@nt_rota", rota) : comm.Parameters.Add("@nt_peso", peso)
        comm.Parameters.Add("@nt_x", x) : comm.Parameters.Add("@nt_y", y)
        comm.Parameters.Add("@nt_parc", parc) : comm.Parameters.Add("@nt_volum", volume)
        comm.Parameters.Add("@nt_tipo2", tipo2) : comm.Parameters.Add("@nt_auto", auto)
        comm.Parameters.Add("@nt_auto2", auto2) : comm.Parameters.Add("@nt_cod1", cod1)
        comm.Parameters.Add("@nt_cod2", cod2) : comm.Parameters.Add("@nt_cod3", cod3)
        comm.Parameters.Add("@nt_cod4", cod4) : comm.Parameters.Add("@nt_cod5", cod5)
        comm.Parameters.Add("@nt_cod6", cod6) : comm.Parameters.Add("@nt_cod7", cod7)
        comm.Parameters.Add("@nt_mapa", mapa) : comm.Parameters.Add("@nt_sit", sit)
        comm.Parameters.Add("@nt_uf", uf) : comm.Parameters.Add("@nt_id", nt_id)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function trazNumAtualOrcamento(ByVal conexao As NpgsqlConnection) As String
        Dim mNumero As String = ""
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT currval('" & MdlEmpresaUsu._esqEstab & ".tb_orca1_nt_id_seq'::regclass)"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        dr = comm.ExecuteReader
        While dr.Read

            mNumero = dr(0).ToString
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumero
    End Function

    Public Function trazNumAtualOrcamento(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction) As String
        Dim mNumero As String = ""
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT currval('" & MdlEmpresaUsu._esqEstab & ".tb_orca1_nt_id_seq'::regclass)"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao, transacao)
        dr = comm.ExecuteReader
        While dr.Read

            mNumero = dr(0).ToString
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumero
    End Function

    Public Function trazProxNumOrcamento(ByVal conexao As NpgsqlConnection) As String
        Dim mNumero As String = ""
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT nextval('" & MdlEmpresaUsu._esqEstab & ".tb_orca1_nt_id_seq'::regclass)"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        dr = comm.ExecuteReader
        While dr.Read

            mNumero = dr(0).ToString
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumero
    End Function

    'Inclusão dos Itens do Orcamento
    Public Sub incOrcamento_Orca2(ByVal geno As String, ByVal orca As String, ByVal codpr As String, ByVal und As String, ByVal qtde As Double, ByVal PcoVenda As Double, _
                        ByVal alqdesc As Double, ByVal vldesc As Double, ByVal pcoUnitario As Double, ByVal PcoTotal As Double, ByVal alqicm As Double, _
                        ByVal baseicm As Double, ByVal basesub As Double, ByVal alqsub As Double, ByVal vlsub As Double, ByVal dtemis As Date, _
                        ByVal Rota As Integer, ByVal Supervisor As String, ByVal Vendedor As String, ByVal lin As Integer, ByVal grupo As Integer, _
                        ByVal alqcom As Double, ByVal Comissao As Double, ByVal mapa As Int32, ByVal Indice_1 As Int32, ByVal indiceAuto As Int64, _
                        ByVal CodCli As String, ByVal LojaEstoq As String, ByVal Pesobruto As Double, ByVal Pesoliquido As Double, _
                        ByVal cdBarra As String, ByVal outrasDesp As Double, ByVal vlicms As Double, ByVal idGrade As Integer, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".tb_orca2(no_orca, no_codpr, no_und, no_qtde, no_prunit,no_prtot, ")
        sqlbuild.Append("no_alqicm,no_dtemis, no_rota, no_vend, no_lin, no_alqcom, no_comis, no_mapa, ")
        sqlbuild.Append("no_supervisor, no_basesub, no_alqsub, no_vlsub, no_idorca1, no_id, no_grupo, ")
        sqlbuild.Append("no_cdport, no_alqdesc, no_vldesc, no_pruvenda, no_filial,no_geno, no_pesobruto, ")
        sqlbuild.Append("no_pesoliquido, no_baseicm, no_cdbarra, no_outrasdesp, no_vlicms, no_idgrade) VALUES (@no_orca, @no_codpr, ")
        sqlbuild.Append("@no_und, @no_qtde, @no_prunit, @no_prtot, @no_alqicm, @no_dtemis, @no_rota, @no_vend, ")
        sqlbuild.Append("@no_lin, @no_alqcom, @no_comis, @no_mapa,@no_supervisor, @no_basesub,@no_alqsub, ")
        sqlbuild.Append("@no_vlsub, @no_idorca1, Default, @no_grupo, @no_cdport, @no_alqdesc, @no_vldesc, ")
        sqlbuild.Append("@no_pruvenda, @no_filial,@no_geno, @no_pesobruto, @no_pesoliquido, @no_baseicm, ")
        sqlbuild.Append("@no_cdbarra, @no_outrasdesp, @no_vlicms, @no_idgrade)")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@no_orca", orca)
        comm.Parameters.Add("@no_codpr", codpr)
        comm.Parameters.Add("@no_und", und)
        comm.Parameters.Add("@no_qtde", qtde)
        comm.Parameters.Add("@no_prunit", pcoUnitario)
        comm.Parameters.Add("@no_prtot", PcoTotal)
        comm.Parameters.Add("@no_baseicm", baseicm)
        comm.Parameters.Add("@no_alqicm", alqicm)
        comm.Parameters.Add("@no_dtemis", Convert.ChangeType(dtemis, GetType(Date)))
        comm.Parameters.Add("@no_rota", Rota)
        comm.Parameters.Add("@no_vend", Vendedor)
        comm.Parameters.Add("@no_lin", lin)
        comm.Parameters.Add("@no_alqcom", alqcom)
        comm.Parameters.Add("@no_comis", Comissao)
        comm.Parameters.Add("@no_mapa", mapa)
        comm.Parameters.Add("@no_supervisor", Supervisor)
        comm.Parameters.Add("@no_basesub", basesub)
        comm.Parameters.Add("@no_alqsub", alqsub)
        comm.Parameters.Add("@no_vlsub", vlsub)
        comm.Parameters.Add("@no_idorca1", Indice_1)
        ' comm.Parameters.Add("@no_idpk", )   * Indice Automatico
        comm.Parameters.Add("@no_grupo", grupo)
        comm.Parameters.Add("@no_cdport", CodCli)
        comm.Parameters.Add("@no_alqdesc", alqdesc)
        comm.Parameters.Add("@no_vldesc", vldesc)
        comm.Parameters.Add("@no_pruvenda", PcoVenda)
        comm.Parameters.Add("@no_filial", LojaEstoq)
        comm.Parameters.Add("@no_geno", geno)
        comm.Parameters.Add("@no_pesobruto", Pesobruto)
        comm.Parameters.Add("@no_pesoliquido", Pesoliquido)
        comm.Parameters.Add("@no_cdbarra", cdBarra)
        comm.Parameters.Add("@no_outrasdesp", outrasDesp)
        comm.Parameters.Add("@no_vlicms", vlicms)
        comm.Parameters.Add("@no_idgrade", idGrade)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    'Inclusão dos totais do Orcamento
    Public Sub incOrcamento_Orca4(ByVal tipo As String, ByVal nume As String, ByVal tprod As Double, ByVal aliss As Double, _
                        ByVal vliss As Double, ByVal vlser As Double, ByVal basec As Double, ByVal icms As Double, _
                        ByVal bsub As Double, ByVal icsub As Double, ByVal tpro2 As Double, ByVal frete As Double, _
                        ByVal segu As Double, ByVal outros As Double, ByVal ipi As Double, ByVal tgeral As Double, _
                        ByVal pgto As String, ByVal peso As Double, ByVal desc As Double, ByVal tipo2 As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder



        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".tb_orca4(n4_id, n4_tipo, n4_nume, n4_tprod, n4_aliss, n4_vliss, n4_vlser, ")
        sqlbuild.Append("n4_basec, n4_icms, n4_bsub, n4_icsub, n4_tpro2, n4_frete, n4_segu, n4_outros, n4_ipi, ")
        sqlbuild.Append("n4_tgeral, n4_pgto, n4_peso, n4_desc, n4_tipo2) ")
        sqlbuild.Append("VALUES (DEFAULT, @n4_tipo, @n4_nume, @n4_tprod, @n4_aliss, @n4_vliss, @n4_vlser, ")
        sqlbuild.Append("@n4_basec, @n4_icms, @n4_bsub, @n4_icsub, @n4_tpro2, @n4_frete, @n4_segu, @n4_outros, ")
        sqlbuild.Append("@n4_ipi, @n4_tgeral, @n4_pgto, @n4_peso, @n4_desc, @n4_tipo2)")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_tipo", tipo) : comm.Parameters.Add("@n4_nume", nume)
        comm.Parameters.Add("@n4_tprod", tprod) : comm.Parameters.Add("@n4_aliss", aliss)
        comm.Parameters.Add("@n4_vliss", vliss) : comm.Parameters.Add("@n4_vlser", vlser)
        comm.Parameters.Add("@n4_basec", basec) : comm.Parameters.Add("@n4_icms", icms)
        comm.Parameters.Add("@n4_bsub", bsub) : comm.Parameters.Add("@n4_icsub", icsub)
        comm.Parameters.Add("@n4_tpro2", tpro2) : comm.Parameters.Add("@n4_frete", frete)
        comm.Parameters.Add("@n4_segu", segu) : comm.Parameters.Add("@n4_outros", outros)
        comm.Parameters.Add("@n4_ipi", ipi) : comm.Parameters.Add("@n4_tgeral", tgeral)
        comm.Parameters.Add("@n4_pgto", pgto) : comm.Parameters.Add("@n4_peso", peso)
        comm.Parameters.Add("@n4_desc", desc) : comm.Parameters.Add("@n4_tipo2", tipo2)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    ' Alteração do registro de cabeçalho do Pedido
    Public Sub altOrcamento_Orca1(ByVal orca As String, ByVal geno As String, ByVal codigo As String, ByVal dtemis As Date, ByVal dtsai As Date, ByVal TPemiss As Boolean, ByVal cfop As String, _
                         ByVal vendedor As String, ByVal cidade As String, ByVal itens As Integer, ByVal rota As Integer, ByVal peso As Double, ByVal x As String, ByVal y As String, ByVal parc As Integer, _
                         ByVal volume As Integer, ByVal tipo2 As String, ByVal auto As String, ByVal auto2 As String, ByVal cod1 As Integer, ByVal cod2 As Integer, ByVal cod3 As Integer, _
                         ByVal cod4 As Integer, ByVal cod5 As Integer, ByVal cod6 As Integer, ByVal cod7 As Integer, ByVal mapa As String, ByVal sit As String, ByVal uf As String, _
                         ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".tb_orca1 SET nt_codig = @nt_codig, ")
        sqlbuild.Append("nt_dtemis = @nt_dtemis, nt_dtsai = @nt_dtsai, nt_emiss = @nt_emiss, nt_cfop = @nt_cfop, ")
        sqlbuild.Append("nt_vend = @nt_vend, nt_cid = @nt_cid, nt_itens = @nt_itens, nt_rota = @nt_rota, ")
        sqlbuild.Append("nt_peso = @nt_peso, nt_x = @nt_x, nt_y = @nt_y, nt_parc = @nt_parc, nt_cod1 = @nt_cod1, ")
        sqlbuild.Append("nt_cod2 = @nt_cod2, nt_volum = @nt_volum, nt_tipo2 = @nt_tipo2, nt_auto = @nt_auto, ")
        sqlbuild.Append("nt_auto2 = @nt_auto2, nt_cod3 = @nt_cod3, nt_cod4 = @nt_cod4, nt_cod5 = @nt_cod5, ")
        sqlbuild.Append("nt_cod6 = @nt_cod6, nt_cod7 = @nt_cod7, nt_mapa = @nt_mapa, nt_sit = @nt_sit, nt_uf = @nt_uf ")
        sqlbuild.Append("WHERE nt_orca = @nt_orca")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_orca", orca) 'comm.Parameters.Add("@nt_geno", geno)
        comm.Parameters.Add("@nt_codig", codigo) : comm.Parameters.Add("@nt_dtemis", Convert.ChangeType(dtemis, GetType(Date)))
        comm.Parameters.Add("@nt_dtsai", Convert.ChangeType(dtsai, GetType(Date))) : comm.Parameters.Add("@nt_emiss", TPemiss)
        comm.Parameters.Add("@nt_cfop", cfop) : comm.Parameters.Add("@nt_vend", vendedor)
        comm.Parameters.Add("@nt_cid", cidade) : comm.Parameters.Add("@nt_itens", itens)
        comm.Parameters.Add("@nt_rota", rota) : comm.Parameters.Add("@nt_peso", peso)
        comm.Parameters.Add("@nt_x", x) : comm.Parameters.Add("@nt_y", y)
        comm.Parameters.Add("@nt_parc", parc) : comm.Parameters.Add("@nt_volum", volume)
        comm.Parameters.Add("@nt_tipo2", tipo2) : comm.Parameters.Add("@nt_auto", auto)
        comm.Parameters.Add("@nt_auto2", auto2) : comm.Parameters.Add("@nt_cod1", cod1)
        comm.Parameters.Add("@nt_cod2", cod2) : comm.Parameters.Add("@nt_cod3", cod3)
        comm.Parameters.Add("@nt_cod4", cod4) : comm.Parameters.Add("@nt_cod5", cod5)
        comm.Parameters.Add("@nt_cod6", cod6) : comm.Parameters.Add("@nt_cod7", cod7)
        comm.Parameters.Add("@nt_mapa", mapa) : comm.Parameters.Add("@nt_sit", sit)
        comm.Parameters.Add("@nt_uf", uf)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delOrcamento_Orca2(ByVal pedido As String, ByVal conexao As NpgsqlConnection, _
                               ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".tb_orca2 WHERE no_orca = @no_orca")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@no_orca", pedido)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delProdutoOrcamento_Orca2(ByVal pedido As String, ByVal codProduto As String, _
                            ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".tb_orca2 WHERE no_orca = @no_orca AND ")
        sqlbuild.Append("no_codpr = @no_codpr")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@no_orca", pedido)
        comm.Parameters.Add("@no_codpr", codProduto)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altOrcamento_Orca4(ByVal tipo As String, ByVal nume As String, ByVal tprod As Double, ByVal aliss As Double, _
                            ByVal vliss As Double, ByVal vlser As Double, ByVal basec As Double, ByVal icms As Double, _
                            ByVal bsub As Double, ByVal icsub As Double, ByVal tpro2 As Double, ByVal frete As Double, _
                            ByVal segu As Double, ByVal outros As Double, ByVal ipi As Double, ByVal tgeral As Double, _
                            ByVal pgto As String, ByVal peso As Double, ByVal desc As Double, ByVal tipo2 As String, _
                            ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".tb_orca4 SET n4_tipo = @n4_tipo, ")
        sqlbuild.Append("n4_tprod = @n4_tprod, n4_aliss = @n4_aliss, n4_vliss = @n4_vliss, n4_vlser = @n4_vlser, ")
        sqlbuild.Append("n4_basec = @n4_basec, n4_icms = @n4_icms, n4_bsub = @n4_bsub, n4_icsub = @n4_icsub, ")
        sqlbuild.Append("n4_tpro2 = @n4_tpro2, n4_frete = @n4_frete, n4_segu = @n4_segu, n4_outros = @n4_outros, ")
        sqlbuild.Append("n4_ipi = @n4_ipi, n4_tgeral = @n4_tgeral, n4_pgto = @n4_pgto, n4_peso = @n4_peso, ")
        sqlbuild.Append("n4_desc = @n4_desc, n4_tipo2 = @n4_tipo2 WHERE n4_nume = @n4_nume")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_tipo", tipo) : comm.Parameters.Add("@n4_nume", nume)
        comm.Parameters.Add("@n4_tprod", tprod) : comm.Parameters.Add("@n4_aliss", aliss)
        comm.Parameters.Add("@n4_vliss", vliss) : comm.Parameters.Add("@n4_vlser", vlser)
        comm.Parameters.Add("@n4_basec", basec) : comm.Parameters.Add("@n4_icms", icms)
        comm.Parameters.Add("@n4_bsub", bsub) : comm.Parameters.Add("@n4_icsub", icsub)
        comm.Parameters.Add("@n4_tpro2", tpro2) : comm.Parameters.Add("@n4_frete", frete)
        comm.Parameters.Add("@n4_segu", segu) : comm.Parameters.Add("@n4_outros", outros)
        comm.Parameters.Add("@n4_ipi", ipi) : comm.Parameters.Add("@n4_tgeral", tgeral)
        comm.Parameters.Add("@n4_pgto", pgto) : comm.Parameters.Add("@n4_peso", peso)
        comm.Parameters.Add("@n4_desc", desc) : comm.Parameters.Add("@n4_tipo2", tipo2)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub alteraPedidoOrcamento_Orca1(ByVal numOrcamento As String, ByVal numPedido As String, _
                                      ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".tb_orca1 SET nt_pedido = @nt_pedido WHERE nt_orca = @nt_orca"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@nt_orca", numOrcamento)
        comm.Parameters.Add("@nt_pedido", numPedido)

        comm.ExecuteNonQuery()
    End Sub

#End Region

#Region "  * *  Manutenção de Movimentos de Telecomunicações, Energia e Entradas de Terceiros * * *  "

    Public Sub IncServComunicacao(ByVal numero As String, ByVal serie As String, ByVal subserie As String, ByVal emissao As Date, _
                                  ByVal dtentrada As Date, ByVal cdport As String, ByVal fone As String, ByVal mesano As String, _
                                  ByVal vencto As Date, ByVal classe As String, ByVal vlservico As Double, ByVal outdesp As Double, _
                                  ByVal abatim As Double, ByVal tgeral As Double, ByVal cfop As String, ByVal cst As String, _
                                  ByVal bcalc As Double, ByVal aliq As Double, ByVal icmcred As Double, ByVal isento As Double, _
                                  ByVal outros As Double, ByVal Conexao As String)

        Try
            Dim conn As New NpgsqlConnection(Conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".servcomunica(fn_id, fn_numero, fn_serie, fn_subserie, fn_emissao, ")
            sqlbuild.Append("fn_dtentrada,fn_cdport, fn_fone, fn_mesano, fn_vencto, fn_classe, fn_vlservico, ")
            sqlbuild.Append("fn_outdesp, fn_abatim, fn_tgeral, fn_cfop, fn_cst, fn_bcalc,")
            sqlbuild.Append("fn_aliq, fn_icmcred, fn_isento, fn_outros)")
            sqlbuild.Append("VALUES (Dafault, @fn_numero, @fn_serie, @fn_subserie, @fn_emissao, @fn_dtentrada,")
            sqlbuild.Append("@fn_cdport, @fn_fone, @fn_mesano, @fn_vencto, @fn_classe, @fn_vlservico, ")
            sqlbuild.Append("@fn_outdesp, @fn_abatim, @fn_tgeral, @fn_cfop, @fn_cst, @fn_bcalc,")
            sqlbuild.Append("@fn_aliq, @fn_icmcred, @fn_isento, @fn_outros)")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            'comm.Parameters.Add("@fn_id", )
            comm.Parameters.Add("@fn_numero", numero)
            comm.Parameters.Add("@fn_serie", serie)
            comm.Parameters.Add("@fn_subserie", subserie)
            comm.Parameters.Add("@fn_emissao", Convert.ChangeType(emissao, GetType(Date)))
            comm.Parameters.Add("@fn_dtentrada", Convert.ChangeType(dtentrada, GetType(Date)))
            comm.Parameters.Add("@fn_cdport", cdport)
            comm.Parameters.Add("@fn_fone", fone)
            comm.Parameters.Add("@fn_mesano", mesano)
            comm.Parameters.Add("@fn_vencto", Convert.ChangeType(vencto, GetType(Date)))
            comm.Parameters.Add("@fn_classe", classe)
            comm.Parameters.Add("@fn_vlservico", vlservico)
            comm.Parameters.Add("@fn_outdesp", outdesp)
            comm.Parameters.Add("@fn_abatim", abatim)
            comm.Parameters.Add("@fn_tgeral", tgeral)
            comm.Parameters.Add("@fn_cfop", cfop)
            comm.Parameters.Add("@fn_cst", cst)
            comm.Parameters.Add("@fn_bcalc", bcalc)
            comm.Parameters.Add("@fn_aliq", aliq)
            comm.Parameters.Add("@fn_icmcred", icmcred)
            comm.Parameters.Add("@fn_isento", isento)
            comm.Parameters.Add("@fn_outros", outros)

            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()
            _transacao.Commit()
            ' Fecha conexão
            conn.Close()
        Catch ex As NpgsqlException
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Public Sub IncServComLanca(ByVal numero As String, ByVal codserv As Integer, ByVal qtde As Integer, ByVal vlunit As Double, ByVal total As Double, _
                               ByVal desconto As Double, ByVal liquido As Double, ByVal cst As String, ByVal trib As Double, ByVal bcalc As Double, _
                               ByVal natcred As String, ByVal cstpis As String, ByVal credpis As Double, ByVal ufcoleta As String, ByVal codmun As String, _
                               ByVal observ As String, ByVal complem As String, ByVal conexao As String)

        Try

            Dim conn As New NpgsqlConnection(conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".servcomlanca(@fnl_id, @fnl_numero, @fnl_codserv, @fnl_qtde,")
            sqlbuild.Append("@fnl_vlunit, @fnl_total, @fnl_desconto, @fnl_liquido, @fnl_cst, ")
            sqlbuild.Append("@fnl_trib, @fnl_bcalc, @fnl_natcred, @fnl_cstpis, @fnl_credpis,")
            sqlbuild.Append("@fnl_ufcoleta, @fnl_codmun, @fnl_observ, @fnl_complem)")
            sqlbuild.Append("VALUES (fnl_id, fnl_numero, fnl_codserv, fnl_qtde, fnl_vlunit, fnl_total, ")
            sqlbuild.Append("fnl_desconto, fnl_liquido, fnl_cst, fnl_trib, fnl_bcalc, fnl_natcred, ")
            sqlbuild.Append("fnl_cstpis, fnl_credpis, fnl_ufcoleta, fnl_codmun, fnl_observ, nl_complem )")


            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            comm.Parameters.Add("@fnl_numero", numero)
            comm.Parameters.Add("@fnl_codserv", codserv)
            comm.Parameters.Add("@fnl_qtde ", qtde)
            comm.Parameters.Add("@fnl_vlunit", vlunit)
            comm.Parameters.Add("@fnl_total", total)
            comm.Parameters.Add("@fnl_desconto", desconto)
            comm.Parameters.Add("@fnl_liquido", liquido)
            comm.Parameters.Add("@fnl_cst", cst)
            comm.Parameters.Add("@fnl_trib", trib)
            comm.Parameters.Add("@fnl_bcalc", bcalc)
            comm.Parameters.Add("@fnl_natcred", natcred)
            comm.Parameters.Add("@fnl_cstpis", cstpis)
            comm.Parameters.Add("@fnl_credpis", credpis)
            comm.Parameters.Add("@fnl_ufcoleta", ufcoleta)
            comm.Parameters.Add("@fnl_codmun", codmun)
            comm.Parameters.Add("@fnl_observ", observ)
            comm.Parameters.Add("@fnl_complem", complem)

            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()
            _transacao.Commit()
            ' Fecha conexão
            conn.Close()
        Catch ex As NpgsqlException
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub IncServErnegia(ByVal numero As String, ByVal serie As String, ByVal subserie As String, ByVal emissao As Date, ByVal dtentrada As Date, _
                              ByVal mesano As String, ByVal vencto As Date, ByVal cliente As String, ByVal classe As Integer, ByVal inscr As String, _
                              ByVal vlConsumo As Double, ByVal consumo As String, ByVal tipo As String, ByVal tensao As String, ByVal taxapub As Double, ByVal outdesp As Double, _
                              ByVal abatim As Double, ByVal tgeral As Double, ByVal cfop As String, ByVal cst As String, ByVal bcalc As Double, ByVal aliq As Double, _
                              ByVal icmcred As Double, ByVal isento As Double, ByVal outros As Double, ByVal conexao As String)

        Try
            Dim conn As New NpgsqlConnection(conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".servenergia(en_id, en_numero, en_serie, en_subserie, ")
            sqlbuild.Append("en_emissao, en_dtentrada,en_mesano, en_vencto, en_cliente, en_classe, ")
            sqlbuild.Append("en_inscr, en_consumo, en_tipo, en_tensao, en_vlconsumo, en_taxapub, en_outdesp, en_abatim, ")
            sqlbuild.Append("en_tgeral, en_cfop, en_cst, en_bcalc, en_aliq, en_icmcred, en_isento, en_outros)")
            sqlbuild.Append("VALUES (Default, @en_numero, @en_serie, @en_subserie, @en_emissao, @en_dtentrada, ")
            sqlbuild.Append("@en_mesano, @en_vencto, @en_cliente, @en_classe, @en_inscr, @en_consumo, ")
            sqlbuild.Append("@en_tipo, @en_tensao, @en_vlconsumo, @en_taxapub, @en_outdesp, @en_abatim, @en_tgeral,")
            sqlbuild.Append("@en_cfop, @en_cst, @en_bcalc, @en_aliq, @en_icmcred, @en_isento, @en_outros)")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            comm.Parameters.Add("@en_numero", numero)
            comm.Parameters.Add("@en_serie", serie)
            comm.Parameters.Add("@en_subserie", subserie)
            comm.Parameters.Add("@en_emissao", Convert.ChangeType(emissao, GetType(Date)))
            comm.Parameters.Add("@en_dtentrada", Convert.ChangeType(dtentrada, GetType(Date)))
            comm.Parameters.Add("@en_mesano", mesano)
            comm.Parameters.Add("@en_vencto", Convert.ChangeType(vencto, GetType(Date)))
            comm.Parameters.Add("@en_cliente", cliente)
            comm.Parameters.Add("@en_classe", classe) 'tamanho maximo no banco é 8
            comm.Parameters.Add("@en_inscr", inscr)
            comm.Parameters.Add("@en_consumo", consumo)
            comm.Parameters.Add("@en_tipo", tipo)
            comm.Parameters.Add("@en_tensao", tensao)
            comm.Parameters.Add("@en_vlconsumo", vlConsumo)
            comm.Parameters.Add("@en_taxapub", taxapub)
            comm.Parameters.Add("@en_outdesp", outdesp)
            comm.Parameters.Add("@en_abatim", abatim)
            comm.Parameters.Add("@en_tgeral", tgeral)
            comm.Parameters.Add("@en_cfop", cfop)
            comm.Parameters.Add("@en_cst", Trim(cst).Substring(0, 2)) 'tamanho maximo no banco é 8
            comm.Parameters.Add("@en_bcalc", bcalc)
            comm.Parameters.Add("@en_aliq", aliq)
            comm.Parameters.Add("@en_icmcred", icmcred)
            comm.Parameters.Add("@en_isento", isento)
            comm.Parameters.Add("@en_outros", outros)

            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()
            _transacao.Commit()
            ' Fecha conexão
            conn.Close()
            MsgBox("Registro incluido com sucesso!", MsgBoxStyle.Exclamation, "GENOV")
        Catch ex As NpgsqlException
            Try
                _transacao.Rollback()
                MsgBox("Erro na Tabela ", ex.Message, MsgBoxStyle.Exclamation)
            Catch exErroRollback As Exception
                MsgBox("Erro na Tabela ", exErroRollback.Message, MsgBoxStyle.Exclamation)
            End Try

        Catch ex As Exception
            Try
                _transacao.Rollback()
                MsgBox("Erro na Tabela ", ex.Message, MsgBoxStyle.Exclamation)
            Catch exErroRollback As Exception
                MsgBox("Erro na Tabela ", exErroRollback.Message, MsgBoxStyle.Exclamation)
            End Try

        End Try

    End Sub

    Public Sub IncServEnerglanca(ByVal conexao As String)

        Try
            Dim conn As New NpgsqlConnection(conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".servenerlanca(enl_id, enl_idservenergia, enl_ufcoleta, enl_codmun, ")
            sqlbuild.Append("enl_observ, enl_complem) VALUES (@enl_id, @enl_idservenergia, ")
            sqlbuild.Append("@enl_ufcoleta, @enl_codmun, @enl_observ, @enl_complem)")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()
            _transacao.Commit()
            ' Fecha conexão
            conn.Close()
        Catch ex As NpgsqlException
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Public Sub deleteServErnegia(ByVal id As Integer, ByVal conexao As String)

        Try
            Dim conn As New NpgsqlConnection(conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".servenergia WHERE en_id = @en_id")
            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            comm.Parameters.Add("@en_id", id)

            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' deleta Registro
            comm.ExecuteNonQuery()
            _transacao.Commit()
            ' Fecha conexão
            conn.Close()
            MsgBox("Registro excluido com sucesso!", MsgBoxStyle.Exclamation, "GENOV")
        Catch ex As NpgsqlException
            Try
                _transacao.Rollback()
                MsgBox("Erro na Tabela ", ex.Message, MsgBoxStyle.Exclamation)
            Catch exErroRollback As Exception
                MsgBox("Erro na Tabela ", exErroRollback.Message, MsgBoxStyle.Exclamation)
            End Try

        Catch ex As Exception
            Try
                _transacao.Rollback()
                MsgBox("Erro na Tabela ", ex.Message, MsgBoxStyle.Exclamation)
            Catch exErroRollback As Exception
                MsgBox("Erro na Tabela ", exErroRollback.Message, MsgBoxStyle.Exclamation)
            End Try

        End Try

    End Sub

    Public Sub deleteServEnerglanca(ByVal id As Integer, ByVal conexao As String)

        Try
            Dim conn As New NpgsqlConnection(conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".servenerlanca WHERE enl_idservenergia = @enl_idservenergia")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            comm.Parameters.Add("@enl_idservenergia", id)

            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' Deleta Registro 
            comm.ExecuteNonQuery()
            _transacao.Commit()
            ' Fecha conexão
            conn.Close()
        Catch ex As NpgsqlException
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Public Sub AtualizaServErnegia(ByVal numero As String, ByVal serie As String, ByVal subserie As String, ByVal emissao As Date, ByVal dtentrada As Date, _
                              ByVal mesano As String, ByVal vencto As Date, ByVal cliente As String, ByVal classe As Integer, ByVal inscr As String, _
                              ByVal vlConsumo As Double, ByVal consumo As String, ByVal tipo As String, ByVal tensao As String, ByVal taxapub As Double, ByVal outdesp As Double, _
                              ByVal abatim As Double, ByVal tgeral As Double, ByVal cfop As String, ByVal cst As String, ByVal bcalc As Double, ByVal aliq As Double, _
                              ByVal icmcred As Double, ByVal isento As Double, ByVal outros As Double, ByVal id As Integer, ByVal conexao As String)

        Try
            Dim conn As New NpgsqlConnection(conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".servenergia ")
            sqlbuild.Append("SET en_numero=@en_numero, en_serie=@en_serie, en_subserie=@en_subserie, en_emissao=@en_emissao, ")
            sqlbuild.Append("en_dtentrada=@en_dtentrada, en_mesano=@en_mesano, en_vencto=@en_vencto, en_cliente=@en_cliente, ")
            sqlbuild.Append("en_classe=@en_classe, en_inscr=@en_inscr, en_consumo=@en_consumo, en_tipo=@en_tipo, ")
            sqlbuild.Append("en_tensao=@en_tensao, en_taxapub=@en_taxapub, en_outdesp=@en_outdesp, en_abatim=@en_abatim, ")
            sqlbuild.Append("en_tgeral=@en_tgeral, en_cfop=@en_cfop, en_cst=@en_cst, en_bcalc=@en_bcalc, en_aliq=@en_aliq, ")
            sqlbuild.Append("en_icmcred=@en_icmcred, en_isento=@en_isento, en_outros=@en_outros, en_vlconsumo=@en_vlconsumo ")
            sqlbuild.Append("WHERE en_id = @en_id")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            comm.Parameters.Add("@en_id", id)
            comm.Parameters.Add("@en_numero", numero)
            comm.Parameters.Add("@en_serie", serie)
            comm.Parameters.Add("@en_subserie", subserie)
            comm.Parameters.Add("@en_emissao", Convert.ChangeType(emissao, GetType(Date)))
            comm.Parameters.Add("@en_dtentrada", Convert.ChangeType(dtentrada, GetType(Date)))
            comm.Parameters.Add("@en_mesano", mesano)
            comm.Parameters.Add("@en_vencto", Convert.ChangeType(vencto, GetType(Date)))
            comm.Parameters.Add("@en_cliente", cliente)
            comm.Parameters.Add("@en_classe", classe) 'tamanho maximo no banco é 8
            comm.Parameters.Add("@en_inscr", inscr)
            comm.Parameters.Add("@en_consumo", consumo)
            comm.Parameters.Add("@en_tipo", tipo)
            comm.Parameters.Add("@en_tensao", tensao)
            comm.Parameters.Add("@en_vlconsumo", vlConsumo)
            comm.Parameters.Add("@en_taxapub", taxapub)
            comm.Parameters.Add("@en_outdesp", outdesp)
            comm.Parameters.Add("@en_abatim", abatim)
            comm.Parameters.Add("@en_tgeral", tgeral)
            comm.Parameters.Add("@en_cfop", cfop)
            comm.Parameters.Add("@en_cst", Trim(cst).Substring(0, 2)) 'tamanho maximo no banco é 8
            comm.Parameters.Add("@en_bcalc", bcalc)
            comm.Parameters.Add("@en_aliq", aliq)
            comm.Parameters.Add("@en_icmcred", icmcred)
            comm.Parameters.Add("@en_isento", isento)
            comm.Parameters.Add("@en_outros", outros)

            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()
            _transacao.Commit()
            ' Fecha conexão
            conn.Close()
            MsgBox("Registro Alterado com sucesso!", MsgBoxStyle.Exclamation, "GENOV")
        Catch ex As NpgsqlException
            Try
                _transacao.Rollback()
                MsgBox("Erro na Tabela ", ex.Message, MsgBoxStyle.Exclamation)
            Catch exErroRollback As Exception
                MsgBox("Erro na Tabela ", exErroRollback.Message, MsgBoxStyle.Exclamation)
            End Try

        Catch ex As Exception
            Try
                _transacao.Rollback()
                MsgBox("Erro na Tabela ", ex.Message, MsgBoxStyle.Exclamation)
            Catch exErroRollback As Exception
                MsgBox("Erro na Tabela ", exErroRollback.Message, MsgBoxStyle.Exclamation)
            End Try

        End Try

    End Sub

    Public Sub IncNfEntradaTerc(ByVal numero As String, ByVal fornecedor As String, ByVal Estabelecimento As String, ByVal serie As String, _
                           ByVal especie As String, ByVal dtEmissao As Date, ByVal dtentrada As Date, ByVal tipo As String, _
                           ByVal chave As String, ByVal CFOP As String, ByVal totalProdutos As Decimal, ByVal BcICMS As Decimal, _
                           ByVal alqICMS As Decimal, ByVal vlICMS As Decimal, ByVal BcSubs As Decimal, ByVal vlSubs As Decimal, _
                           ByVal alqIPI As Decimal, ByVal vlIPI As Decimal, ByVal vlIpiIsento As Decimal, ByVal vlIpiOutros As Decimal, _
                           ByVal vlFrete As Decimal, ByVal vlOutros As Decimal, ByVal vlSeguro As Decimal, ByVal vlDesconto As Decimal, _
                           ByVal vlOutrasDesp As Decimal, ByVal vlTotGeral As Decimal, ByVal UF As String, ByVal pagamento As String, _
                           ByVal observacao As String, ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".nota4ff(")
        sqlbuild.Append("n4_tipo, n4_numer, n4_tprod, n4_basec, n4_icms, n4_bsub, n4_icsub, n4_frete, ")
        sqlbuild.Append("n4_segu, n4_outros, n4_ipi, n4_tgeral, n4_dtemis, n4_dtent, n4_cdport, ")
        sqlbuild.Append("n4_cdfisc, n4_aliq, n4_serie, n4_espec, n4_alqipi, n4_ipisent, n4_ipoutro, n4_uf, ")
        sqlbuild.Append("n4_chave, n4_desc, n4_outrasdesp, n4_estab, n4_pagamento, n4_obs)")
        sqlbuild.Append("VALUES (@n4_tipo, @n4_numer, @n4_tprod, @n4_basec, @n4_icms, @n4_bsub, @n4_icsub, @n4_frete, ")
        sqlbuild.Append("@n4_segu, @n4_outros, @n4_ipi, @n4_tgeral, @n4_dtemis, @n4_dtent, @n4_cdport, ")
        sqlbuild.Append("@n4_cdfisc, @n4_aliq, @n4_serie, @n4_espec, @n4_alqipi, @n4_ipisent, @n4_ipoutro, @n4_uf, ")
        sqlbuild.Append("@n4_chave, @n4_desc, @n4_outrasdesp, @n4_estab, @n4_pagamento, @n4_obs);")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@n4_tipo", "E")
        comm.Parameters.Add("@n4_numer", numero)
        comm.Parameters.Add("@n4_tprod", totalProdutos)
        comm.Parameters.Add("@n4_basec", BcICMS)
        comm.Parameters.Add("@n4_icms", vlICMS)
        comm.Parameters.Add("@n4_bsub", BcSubs)
        comm.Parameters.Add("@n4_icsub", vlSubs)
        comm.Parameters.Add("@n4_frete", vlFrete)
        comm.Parameters.Add("@n4_segu", vlSeguro)
        comm.Parameters.Add("@n4_outros", vlOutros)
        comm.Parameters.Add("@n4_ipi", vlIPI)
        comm.Parameters.Add("@n4_tgeral", vlTotGeral)
        comm.Parameters.Add("@n4_dtemis", Convert.ChangeType(dtEmissao, GetType(Date)))
        comm.Parameters.Add("@n4_dtent", Convert.ChangeType(dtentrada, GetType(Date)))
        comm.Parameters.Add("@n4_cdport", fornecedor)
        comm.Parameters.Add("@n4_cdfisc", CFOP)
        comm.Parameters.Add("@n4_aliq", alqICMS)
        comm.Parameters.Add("@n4_serie", serie)
        comm.Parameters.Add("@n4_espec", especie)
        comm.Parameters.Add("@n4_alqipi", alqIPI)
        comm.Parameters.Add("@n4_ipisent", vlIpiIsento)
        comm.Parameters.Add("@n4_ipoutro", vlIpiOutros)
        comm.Parameters.Add("@n4_uf", UF)
        comm.Parameters.Add("@n4_chave", chave)
        comm.Parameters.Add("@n4_desc", vlDesconto)
        comm.Parameters.Add("@n4_outrasdesp", vlOutrasDesp)
        comm.Parameters.Add("@n4_estab", Estabelecimento)
        comm.Parameters.Add("@n4_pagamento", pagamento)
        comm.Parameters.Add("@n4_obs", observacao)


        comm.Transaction = transaction
        ' Inclui Registros 
        comm.ExecuteNonQuery()


    End Sub

    Public Sub deleteNfEntradaTerc(ByVal id As Integer, ByVal numero As String, ByVal codforn As String, ByVal conexao As String)

        Try
            Dim conn As New NpgsqlConnection(conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            'sqlbuild.Append("DELETE FROM nota4ff WHERE en_id = @en_id")
            sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".nota4ff WHERE n4_numer = @n4_numer AND n4_cdport = @n4_cdport")
            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            'comm.Parameters.Add("@en_id", id)
            comm.Parameters.Add("@n4_numer", numero)
            comm.Parameters.Add("@cdport", codforn)

            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' deleta Registro
            comm.ExecuteNonQuery()
            _transacao.Commit()
            ' Fecha conexão
            conn.Close()
            MsgBox("Registro excluido com sucesso!", MsgBoxStyle.Exclamation, "GENOV")
        Catch ex As NpgsqlException
            Try
                _transacao.Rollback()
                MsgBox("Erro na Tabela ", ex.Message, MsgBoxStyle.Exclamation)
            Catch exErroRollback As Exception
                MsgBox("Erro na Tabela ", exErroRollback.Message, MsgBoxStyle.Exclamation)
            End Try

        Catch ex As Exception
            Try
                _transacao.Rollback()
                MsgBox("Erro na Tabela ", ex.Message, MsgBoxStyle.Exclamation)
            Catch exErroRollback As Exception
                MsgBox("Erro na Tabela ", exErroRollback.Message, MsgBoxStyle.Exclamation)
            End Try

        End Try

    End Sub

    Public Sub AtualNfEntradaTerc(ByVal idN4ff As Int32, ByVal numero As String, ByVal fornecedor As String, ByVal Estabelecimento As String, ByVal serie As String, _
                           ByVal especie As String, ByVal dtEmissao As Date, ByVal dtentrada As Date, ByVal tipo As String, _
                           ByVal chave As String, ByVal CFOP As String, ByVal totalProdutos As Decimal, ByVal BcICMS As Decimal, _
                           ByVal alqICMS As Decimal, ByVal vlICMS As Decimal, ByVal BcSubs As Decimal, ByVal vlSubs As Decimal, _
                           ByVal alqIPI As Decimal, ByVal vlIPI As Decimal, ByVal vlIpiIsento As Decimal, ByVal vlIpiOutros As Decimal, _
                           ByVal vlFrete As Decimal, ByVal vlOutros As Decimal, ByVal vlSeguro As Decimal, ByVal vlDesconto As Decimal, _
                           ByVal vlOutrasDesp As Decimal, ByVal vlTotGeral As Decimal, ByVal UF As String, ByVal pagamento As String, _
                           ByVal observacao As String, ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)


        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".nota4ff ")
        sqlbuild.Append("SET n4_numer=@n4_numer, n4_tprod=@n4_tprod, n4_basec=@n4_basec, n4_icms=@n4_icms, ")
        sqlbuild.Append("n4_bsub=@n4_bsub, n4_icsub=@n4_icsub, n4_frete=@n4_frete, n4_segu=@n4_segu, ")
        sqlbuild.Append("n4_outros=@n4_outros, n4_ipi=@n4_ipi, n4_tgeral=@n4_tgeral, n4_dtemis=@n4_dtemis, ")
        sqlbuild.Append("n4_dtent=@n4_dtent, n4_cdport=@n4_cdport, n4_cdfisc=@n4_cdfisc, n4_aliq=@n4_aliq, ")
        sqlbuild.Append("n4_serie=@n4_serie, n4_ipisent=@n4_ipisent, n4_ipoutro=@n4_ipoutro, n4_uf=@n4_uf, ")
        sqlbuild.Append("n4_espec=@n4_espec, n4_alqipi=@n4_alqipi, n4_chave=@n4_chave, n4_desc=@n4_desc, ")
        sqlbuild.Append("n4_estab=@n4_estab, n4_pagamento=@n4_pagamento, n4_obs=@n4_obs, ")
        sqlbuild.Append("n4_outrasdesp=@n4_outrasdesp WHERE n4_id=@n4_id ")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@n4_id", idN4ff)
        comm.Parameters.Add("@n4_numer", numero)
        comm.Parameters.Add("@n4_tprod", totalProdutos)
        comm.Parameters.Add("@n4_basec", BcICMS)
        comm.Parameters.Add("@n4_icms", vlICMS)
        comm.Parameters.Add("@n4_bsub", BcSubs)
        comm.Parameters.Add("@n4_icsub", vlSubs)
        comm.Parameters.Add("@n4_frete", vlFrete)
        comm.Parameters.Add("@n4_segu", vlSeguro)
        comm.Parameters.Add("@n4_outros", vlOutros)
        comm.Parameters.Add("@n4_ipi", vlIPI)
        comm.Parameters.Add("@n4_tgeral", vlTotGeral)
        comm.Parameters.Add("@n4_dtemis", Convert.ChangeType(dtEmissao, GetType(Date)))
        comm.Parameters.Add("@n4_dtent", Convert.ChangeType(dtentrada, GetType(Date)))
        comm.Parameters.Add("@n4_cdport", fornecedor)
        comm.Parameters.Add("@n4_cdfisc", CFOP)
        comm.Parameters.Add("@n4_aliq", alqICMS)
        comm.Parameters.Add("@n4_serie", serie)
        comm.Parameters.Add("@n4_espec", especie)
        comm.Parameters.Add("@n4_alqipi", alqIPI)
        comm.Parameters.Add("@n4_ipisent", vlIpiIsento)
        comm.Parameters.Add("@n4_ipoutro", vlIpiOutros)
        comm.Parameters.Add("@n4_uf", UF)
        comm.Parameters.Add("@n4_chave", chave)
        comm.Parameters.Add("@n4_desc", vlDesconto)
        comm.Parameters.Add("@n4_outrasdesp", vlOutrasDesp)
        comm.Parameters.Add("@n4_estab", Estabelecimento)
        comm.Parameters.Add("@n4_pagamento", pagamento)
        comm.Parameters.Add("@n4_obs", observacao)


        comm.Transaction = transaction
        ' Inclui Registros 
        comm.ExecuteNonQuery()

    End Sub

    Public Sub incItensNfEntradasTerc(ByVal mIdN4ff As Integer, ByVal mNumeroNF As String, ByVal mCodForn As String, ByVal mCodProd As String, ByVal mNomeProd As String, _
                                ByVal mNcmProd As String, ByVal mCfopProd As String, ByVal mUndProd As String, ByVal mDtEntProd As Date, ByVal mDtUsuProd As Date, _
                                ByVal mCstProd As String, ByVal mCsosnProd As String, ByVal mQtdeProd As Decimal, ByVal mVlUnitComprProd As Decimal, _
                                ByVal mVlPercDesc As Decimal, ByVal mVlDesc As Decimal, ByVal mVlTotProd As Decimal, ByVal mVlUnitProd As Decimal, _
                                ByVal mVlBrutoProd As Decimal, ByVal mVlPercRedProd As Decimal, ByVal mVlBcIcmsProd As Decimal, ByVal mVlAlqIcmsProd As Decimal, _
                                ByVal mVlIcmsProd As Decimal, ByVal mVlBcSubsProd As Decimal, ByVal mVlAlqSubsProd As Decimal, ByVal mVlSubsProd As Decimal, _
                                ByVal mVlAlqIpiProd As Decimal, ByVal mVlIpiProd As Decimal, ByVal mVlPercFretProd As Decimal, _
                                ByVal mVlFretProd As Decimal, ByVal mVlSeguroProd As Decimal, ByVal mVlDespProd As Decimal, ByVal mVlOutrosProd As Decimal, _
                                ByVal mVlCustoProd As Decimal, ByVal mVlPercLucroProd As Decimal, ByVal mVlSurgeridoProd As Decimal, _
                                ByVal mEstab As String, ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".nota2ff( ")
        sqlbuild.Append("nc_idn4ff, nc_tipo, nc_numer, nc_codpr, nc_produt, nc_cst, nc_und, ")
        sqlbuild.Append("nc_qtde, nc_prunit, nc_prtot, nc_alqicm, nc_alqipi, nc_vlipi, ")
        sqlbuild.Append("nc_vlicm, nc_prucom, nc_desc, nc_icmsub, nc_cdport, nc_data, ")
        sqlbuild.Append("nc_dtusu, nc_vlicsub, nc_vlsub, nc_cfop, nc_vldesc, nc_alqnot, ")
        sqlbuild.Append("nc_basesub, nc_bscalc, nc_frete, nc_seguro, nc_totbruto, nc_outrasdesp, nc_estab) ")
        sqlbuild.Append("VALUES (@nc_idn4ff, @nc_tipo, @nc_numer, @nc_codpr, @nc_produt, @nc_cst, @nc_und, ")
        sqlbuild.Append("@nc_qtde, @nc_prunit, @nc_prtot, @nc_alqicm, @nc_alqipi, @nc_vlipi, ")
        sqlbuild.Append("@nc_vlicm, @nc_prucom, @nc_desc, @nc_icmsub, @nc_cdport, @nc_data, ")
        sqlbuild.Append("@nc_dtusu, @nc_vlicsub, @nc_vlsub, @nc_cfop, @nc_vldesc, @nc_alqnot, @nc_basesub, ")
        sqlbuild.Append("@nc_bscalc, @nc_frete, @nc_seguro, @nc_totbruto, @nc_outrasdesp, @nc_estab); ")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Parameters.Add("@nc_idn4ff", mIdN4ff)
        comm.Parameters.Add("@nc_tipo", "E")
        comm.Parameters.Add("@nc_numer", mNumeroNF)
        comm.Parameters.Add("@nc_codpr", mCodProd)
        comm.Parameters.Add("@nc_produt", mNomeProd)
        comm.Parameters.Add("@nc_cst", mCstProd)
        comm.Parameters.Add("@nc_und", mUndProd)
        comm.Parameters.Add("@nc_qtde", mQtdeProd)
        comm.Parameters.Add("@nc_prunit", mVlUnitProd) 'mVlUnitProd
        comm.Parameters.Add("@nc_prtot", mVlTotProd)
        comm.Parameters.Add("@nc_alqicm", mVlAlqIcmsProd)
        comm.Parameters.Add("@nc_alqipi", mVlAlqIpiProd)
        comm.Parameters.Add("@nc_vlipi", mVlIpiProd)
        comm.Parameters.Add("@nc_vlicm", mVlIcmsProd)
        comm.Parameters.Add("@nc_prucom", mVlUnitComprProd)
        comm.Parameters.Add("@nc_desc", mVlPercDesc)
        comm.Parameters.Add("@nc_icmsub", mVlAlqSubsProd)
        comm.Parameters.Add("@nc_cdport", mCodForn)
        comm.Parameters.Add("@nc_data", Convert.ChangeType(mDtEntProd, GetType(Date)))
        comm.Parameters.Add("@nc_dtusu", Convert.ChangeType(mDtUsuProd, GetType(Date)))
        comm.Parameters.Add("@nc_vlicsub", mVlSubsProd)
        comm.Parameters.Add("@nc_vlsub", mVlSubsProd)
        comm.Parameters.Add("@nc_cfop", mCfopProd)
        comm.Parameters.Add("@nc_vldesc", mVlDesc)
        comm.Parameters.Add("@nc_alqnot", mVlAlqIcmsProd)
        comm.Parameters.Add("@nc_basesub", mVlBcSubsProd)
        comm.Parameters.Add("@nc_bscalc", mVlBcIcmsProd)
        comm.Parameters.Add("@nc_frete", mVlFretProd)
        comm.Parameters.Add("@nc_seguro", mVlSeguroProd)
        comm.Parameters.Add("@nc_estab", mEstab)
        comm.Parameters.Add("@nc_totbruto", mVlBrutoProd)
        comm.Parameters.Add("@nc_outrasdesp", mVlDespProd)


        comm.Transaction = transaction
        ' Inclui Registros 
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub AtuilItensNfEntrTerc(ByVal mIdn2ff As Int32, ByVal mIdN4ff As Int32, ByVal mNumeroNF As String, ByVal mCodForn As String, ByVal mCodProd As String, ByVal mNomeProd As String, _
                                ByVal mNcmProd As String, ByVal mCfopProd As String, ByVal mUndProd As String, ByVal mDtEntProd As Date, ByVal mDtUsuProd As Date, _
                                ByVal mCstProd As String, ByVal mCsosnProd As String, ByVal mQtdeProd As Decimal, ByVal mVlUnitComprProd As Decimal, _
                                ByVal mVlPercDesc As Decimal, ByVal mVlDesc As Decimal, ByVal mVlTotProd As Decimal, ByVal mVlUnitProd As Decimal, _
                                ByVal mVlBrutoProd As Decimal, ByVal mVlPercRedProd As Decimal, ByVal mVlBcIcmsProd As Decimal, ByVal mVlAlqIcmsProd As Decimal, _
                                ByVal mVlIcmsProd As Decimal, ByVal mVlBcSubsProd As Decimal, ByVal mVlAlqSubsProd As Decimal, ByVal mVlSubsProd As Decimal, _
                                ByVal mVlAlqIpiProd As Decimal, ByVal mVlIpiProd As Decimal, ByVal mVlPercFretProd As Decimal, _
                                ByVal mVlFretProd As Decimal, ByVal mVlSeguroProd As Decimal, ByVal mVlDespProd As Decimal, ByVal mVlOutrosProd As Decimal, _
                                ByVal mVlCustoProd As Decimal, ByVal mVlPercLucroProd As Decimal, ByVal mVlSurgeridoProd As Decimal, _
                                ByVal mEstab As String, ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".nota2ff SET ")
        sqlbuild.Append("nc_numer=@nc_numer, nc_codpr=@nc_codpr, nc_produt=@nc_produt, nc_cst=@nc_cst, ")
        sqlbuild.Append("nc_und=@nc_und, nc_qtde=@nc_qtde, nc_prunit=@nc_prunit, nc_prtot=@nc_prtot, ")
        sqlbuild.Append("nc_alqicm=@nc_alqicm, nc_alqipi=@nc_alqipi, nc_vlipi=@nc_vlipi, nc_vlicm=@nc_vlicm, ")
        sqlbuild.Append("nc_prucom=@nc_prucom, nc_desc=@nc_desc, nc_icmsub=@nc_icmsub, nc_cdport=@nc_cdport, ")
        sqlbuild.Append("nc_data=@nc_data, nc_dtusu=@nc_dtusu, nc_vlicsub=@nc_vlicsub, nc_vlsub=@nc_vlsub, ")
        sqlbuild.Append("nc_cfop=@nc_cfop, nc_vldesc=@nc_vldesc, nc_alqnot=@nc_alqnot, nc_basesub=@nc_basesub, ")
        sqlbuild.Append("nc_bscalc=@nc_bscalc,  nc_frete=@nc_frete,  nc_seguro=@nc_seguro, nc_totbruto=@nc_totbruto, ")
        sqlbuild.Append("nc_outrasdesp=@nc_outrasdesp, nc_estab=@nc_estab ")
        sqlbuild.Append("WHERE nc_id = @nc_id AND nc_idn4ff = @nc_idn4ff")
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Parameters.Add("@nc_id", mIdn2ff)
        comm.Parameters.Add("@nc_idn4ff", mIdN4ff)
        comm.Parameters.Add("@nc_numer", mNumeroNF)
        comm.Parameters.Add("@nc_codpr", mCodProd)
        comm.Parameters.Add("@nc_produt", mNomeProd)
        comm.Parameters.Add("@nc_cst", mCstProd)
        comm.Parameters.Add("@nc_und", mUndProd)
        comm.Parameters.Add("@nc_qtde", mQtdeProd)
        comm.Parameters.Add("@nc_prunit", mVlUnitProd) 'mVlUnitProd
        comm.Parameters.Add("@nc_prtot", mVlTotProd)
        comm.Parameters.Add("@nc_alqicm", mVlAlqIcmsProd)
        comm.Parameters.Add("@nc_alqipi", mVlAlqIpiProd)
        comm.Parameters.Add("@nc_vlipi", mVlIpiProd)
        comm.Parameters.Add("@nc_vlicm", mVlIcmsProd)
        comm.Parameters.Add("@nc_prucom", mVlUnitComprProd)
        comm.Parameters.Add("@nc_desc", mVlPercDesc)
        comm.Parameters.Add("@nc_icmsub", mVlAlqSubsProd)
        comm.Parameters.Add("@nc_cdport", mCodForn)
        comm.Parameters.Add("@nc_data", Convert.ChangeType(mDtEntProd, GetType(Date)))
        comm.Parameters.Add("@nc_dtusu", Convert.ChangeType(mDtUsuProd, GetType(Date)))
        comm.Parameters.Add("@nc_vlicsub", mVlSubsProd)
        comm.Parameters.Add("@nc_vlsub", mVlSubsProd)
        comm.Parameters.Add("@nc_cfop", mCfopProd)
        comm.Parameters.Add("@nc_vldesc", mVlDesc)
        comm.Parameters.Add("@nc_alqnot", mVlAlqIcmsProd)
        comm.Parameters.Add("@nc_basesub", mVlBcSubsProd)
        comm.Parameters.Add("@nc_bscalc", mVlBcIcmsProd)
        comm.Parameters.Add("@nc_frete", mVlFretProd)
        comm.Parameters.Add("@nc_seguro", mVlSeguroProd)
        comm.Parameters.Add("@nc_estab", mEstab)
        comm.Parameters.Add("@nc_totbruto", mVlBrutoProd)
        comm.Parameters.Add("@nc_outrasdesp", mVlDespProd)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    'INICIO do Tratamento dos Resumo dos Itens da NFe Entradas de Terceiros....
    Public Sub IncResEntrTercALQ(ByVal idN4ff As Int64, ByVal numero As String, ByVal aliqICMS As Decimal, _
                                 ByVal totProd As Decimal, ByVal totDesc As Decimal, ByVal totFrete As Decimal, _
                                 ByVal totSeguro As Decimal, ByVal totOutrasDesp As Decimal, ByVal bcalcICMS As Decimal, _
                                 ByVal vlICMS As Decimal, ByVal vlIsento As Decimal, ByVal vlOutras As Decimal, _
                                 ByVal vlIPI As Decimal, ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".resn4ff01(")
        sqlbuild.Append("r4_id, r4_idn4f, r4_numero, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, ")
        sqlbuild.Append("r4_toutrasdesp, r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral) ")
        sqlbuild.Append("VALUES (DEFAULT, @r4_idn4f, @r4_numero, @r4_aliq, @r4_tprod, @r4_tdesc, @r4_tfrete, ")
        sqlbuild.Append("@r4_tseguro, @r4_toutrasdesp, @r4_bcalc, @r4_icms, @r4_isento, @r4_outras, @r4_ipi, ")
        sqlbuild.Append("@r4_tgeral);")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_idn4f", idN4ff)
        comm.Parameters.Add("@r4_numero", numero)
        comm.Parameters.Add("@r4_aliq", aliqICMS)
        comm.Parameters.Add("@r4_tprod", totProd)
        comm.Parameters.Add("@r4_bcalc", bcalcICMS)
        comm.Parameters.Add("@r4_icms", vlICMS)
        comm.Parameters.Add("@r4_isento", vlIsento)
        comm.Parameters.Add("@r4_outras", vlOutras)
        comm.Parameters.Add("@r4_ipi", vlIPI)
        comm.Parameters.Add("@r4_tdesc", totDesc)
        comm.Parameters.Add("@r4_tfrete", totFrete)
        comm.Parameters.Add("@r4_tseguro", totSeguro)
        comm.Parameters.Add("@r4_toutrasdesp", totOutrasDesp)
        comm.Parameters.Add("@r4_tgeral", ((totProd + vlIsento + vlOutras + vlIPI + _
                                           totFrete + totSeguro + totOutrasDesp) - totDesc))


        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub AtualResEntrTercALQ(ByVal idRs4ff01 As Int64, ByVal idN4ff As Int64, ByVal numero As String, ByVal aliqICMS As Decimal, _
                                 ByVal totProd As Decimal, ByVal totDesc As Decimal, ByVal totFrete As Decimal, _
                                 ByVal totSeguro As Decimal, ByVal totOutrasDesp As Decimal, ByVal bcalcICMS As Decimal, _
                                 ByVal vlICMS As Decimal, ByVal vlIsento As Decimal, ByVal vlOutras As Decimal, _
                                 ByVal vlIPI As Decimal, ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".resn4ff01 SET ")
        sqlbuild.Append("r4_numero=@r4_numero, r4_aliq=@r4_aliq, r4_tprod=@r4_tprod, r4_tdesc=@r4_tdesc, ")
        sqlbuild.Append("r4_tfrete=@r4_tfrete, r4_tseguro=@r4_tseguro, r4_toutrasdesp=@r4_toutrasdesp, ")
        sqlbuild.Append("r4_bcalc=@r4_bcalc, r4_icms=@r4_icms, r4_isento=@r4_isento, r4_outras=@r4_outras, ")
        sqlbuild.Append("r4_ipi=@r4_ipi, r4_tgeral=@r4_tgeral WHERE r4_id=@r4_id AND r4_idn4f=@r4_idn4f")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_id", idRs4ff01)
        comm.Parameters.Add("@r4_idn4f", idN4ff)
        comm.Parameters.Add("@r4_numero", numero)
        comm.Parameters.Add("@r4_aliq", aliqICMS)
        comm.Parameters.Add("@r4_tprod", totProd)
        comm.Parameters.Add("@r4_bcalc", bcalcICMS)
        comm.Parameters.Add("@r4_icms", vlICMS)
        comm.Parameters.Add("@r4_isento", vlIsento)
        comm.Parameters.Add("@r4_outras", vlOutras)
        comm.Parameters.Add("@r4_ipi", vlIPI)
        comm.Parameters.Add("@r4_tdesc", totDesc)
        comm.Parameters.Add("@r4_tfrete", totFrete)
        comm.Parameters.Add("@r4_tseguro", totSeguro)
        comm.Parameters.Add("@r4_toutrasdesp", totOutrasDesp)
        comm.Parameters.Add("@r4_tgeral", ((totProd + vlIsento + vlOutras + vlIPI + _
                                           totFrete + totSeguro + totOutrasDesp) - totDesc))

        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub delResEntrTercALQ(ByVal idN4ff As Int64, ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".resn4ff01 WHERE r4_idn4f=@r4_idn4f")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_idn4f", idN4ff)

        comm.Transaction = _transacao
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub IncResEntrTercCfopAlq(ByVal idN4ff As Int64, ByVal numero As String, ByVal cfop As String, _
                                ByVal aliqICMS As Decimal, ByVal totProd As Decimal, ByVal totDesc As Decimal, _
                                ByVal totFrete As Decimal, ByVal totSeguro As Decimal, ByVal totOutrasDesp As Decimal, _
                                ByVal bcalcICMS As Decimal, ByVal vlICMS As Decimal, ByVal vlIsento As Decimal, _
                                ByVal vlOutras As Decimal, ByVal vlIPI As Decimal, ByVal conexao As NpgsqlConnection, _
                                ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".resn4ff02(")
        sqlbuild.Append("r4_id, r4_idn4f, r4_numero, r4_cfop, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, ")
        sqlbuild.Append("r4_tseguro, r4_toutrasdesp, r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, ")
        sqlbuild.Append(" r4_tgeral) ")
        sqlbuild.Append("VALUES (DEFAULT, @r4_idn4f, @r4_numero, @r4_cfop, @r4_aliq, @r4_tprod, ")
        sqlbuild.Append("@r4_tdesc, @r4_tfrete, @r4_tseguro, @r4_toutrasdesp, @r4_bcalc, @r4_icms, ")
        sqlbuild.Append("@r4_isento, @r4_outras, @r4_ipi, @r4_tgeral);")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_idn4f", idN4ff)
        comm.Parameters.Add("@r4_numero", numero)
        comm.Parameters.Add("@r4_cfop", cfop)
        comm.Parameters.Add("@r4_aliq", aliqICMS)
        comm.Parameters.Add("@r4_tprod", totProd)
        comm.Parameters.Add("@r4_bcalc", bcalcICMS)
        comm.Parameters.Add("@r4_icms", vlICMS)
        comm.Parameters.Add("@r4_isento", vlIsento)
        comm.Parameters.Add("@r4_outras", vlOutras)
        comm.Parameters.Add("@r4_ipi", vlIPI)
        comm.Parameters.Add("@r4_tdesc", totDesc)
        comm.Parameters.Add("@r4_tfrete", totFrete)
        comm.Parameters.Add("@r4_tseguro", totSeguro)
        comm.Parameters.Add("@r4_toutrasdesp", totOutrasDesp)
        comm.Parameters.Add("@r4_tgeral", ((totProd + vlIsento + vlOutras + vlIPI + _
                                           totFrete + totSeguro + totOutrasDesp) - totDesc))

        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub delResEntrTercCfopALQ(ByVal idN4ff As Int32, ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".resn4ff02 WHERE r4_idn4f=@r4_idn4f")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_idn4f", idN4ff)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub IncResEntrTercCstCfopAlq(ByVal idN4ff As Int64, ByVal numero As String, ByVal cst As String, _
                                ByVal cfop As String, ByVal aliqICMS As Decimal, ByVal totProd As Decimal, _
                                ByVal totDesc As Decimal, ByVal totFrete As Decimal, ByVal totSeguro As Decimal, _
                                ByVal totOutrasDesp As Decimal, ByVal bcalcICMS As Decimal, ByVal vlICMS As Decimal, _
                                ByVal vlIsento As Decimal, ByVal vlOutras As Decimal, ByVal vlIPI As Decimal, _
                                ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".resn4ff03(")
        sqlbuild.Append("r4_id, r4_idn4f, r4_numero, r4_cst, r4_cfop, r4_aliq, r4_tprod, r4_tdesc, ")
        sqlbuild.Append("r4_tfrete, r4_tseguro, r4_toutrasdesp, r4_bcalc, r4_icms, r4_isento, r4_outras, ")
        sqlbuild.Append("r4_ipi, r4_tgeral) ")
        sqlbuild.Append("VALUES (DEFAULT, @r4_idn4f, @r4_numero, @r4_cst, @r4_cfop, @r4_aliq, @r4_tprod, ")
        sqlbuild.Append("@r4_tdesc, @r4_tfrete, @r4_tseguro, @r4_toutrasdesp, @r4_bcalc, @r4_icms, @r4_isento, ")
        sqlbuild.Append("@r4_outras, @r4_ipi, @r4_tgeral);")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_idn4f", idN4ff)
        comm.Parameters.Add("@r4_numero", numero)
        comm.Parameters.Add("@r4_cst", cst)
        comm.Parameters.Add("@r4_cfop", cfop)
        comm.Parameters.Add("@r4_aliq", aliqICMS)
        comm.Parameters.Add("@r4_tprod", totProd)
        comm.Parameters.Add("@r4_bcalc", bcalcICMS)
        comm.Parameters.Add("@r4_icms", vlICMS)
        comm.Parameters.Add("@r4_isento", vlIsento)
        comm.Parameters.Add("@r4_outras", vlOutras)
        comm.Parameters.Add("@r4_ipi", vlIPI)
        comm.Parameters.Add("@r4_tdesc", totDesc)
        comm.Parameters.Add("@r4_tfrete", totFrete)
        comm.Parameters.Add("@r4_tseguro", totSeguro)
        comm.Parameters.Add("@r4_toutrasdesp", totOutrasDesp)
        comm.Parameters.Add("@r4_tgeral", ((totProd + vlIsento + vlOutras + vlIPI + _
                                           totFrete + totSeguro + totOutrasDesp) - totDesc))

        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub delResEntrTercCstCfopALQ(ByVal idN4ff As Int32, ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".resn4ff03 WHERE r4_idn4f=@r4_idn4f")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_idn4f", idN4ff)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub
    'FIM do Tratamento dos Resumo dos Itens da NFe Entradas de Terceiros....

    Public Sub IncContas_a_Pagar(ByVal idN4FF As Int64, ByVal Estabelecimento As String, ByVal fornecedor As String, ByVal tipoBL As String, _
                        ByVal numeroFat As String, ByVal numFical As String, ByVal serie As String, ByVal txtDesc As Decimal, _
                        ByVal numeroDuplic As String, ByVal dtEmissao As Date, ByVal dtVecimento As Date, ByVal vlDuplicata As Decimal, _
                        ByVal carteira As String, ByVal dtPagamento As Date, ByVal vlJuros As Decimal, ByVal vlDesconto As Decimal, _
                        ByVal banco As Integer, ByVal historico As String, ByVal situacao As String, ByVal Status As Boolean, _
                        ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO fatp001(")
        sqlbuild.Append("d_id, d_idn4ff, d_geno, d_portad, d_tipo, d_nfat, d_nfisc, d_serie, ")
        sqlbuild.Append("d_txdesc, d_duplic, d_emiss, d_vencto, d_valor, d_cartei, ")
        sqlbuild.Append("d_juros, d_desc, d_banco, d_hist, d_sit, d_stat)")
        sqlbuild.Append("VALUES (DEFAULT, @d_idn4ff, @d_geno, @d_portad, @d_tipo, @d_nfat, @d_nfisc, @d_serie, ")
        sqlbuild.Append("@d_txdesc, @d_duplic, @d_emiss, @d_vencto, @d_valor, @d_cartei, ")
        sqlbuild.Append("@d_juros, @d_desc, @d_banco, @d_hist, @d_sit, @d_stat);")

        comm.Transaction = transaction
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@d_idn4ff", idN4FF)
        comm.Parameters.Add("@d_geno", Estabelecimento)
        comm.Parameters.Add("@d_portad", fornecedor)
        comm.Parameters.Add("@d_tipo", tipoBL)
        comm.Parameters.Add("@d_nfat", numeroFat)
        comm.Parameters.Add("@d_nfisc", numFical)
        comm.Parameters.Add("@d_serie", serie)
        comm.Parameters.Add("@d_txdesc", txtDesc)
        comm.Parameters.Add("@d_duplic", numeroDuplic)
        comm.Parameters.Add("@d_emiss", Convert.ChangeType(dtEmissao, GetType(Date)))
        comm.Parameters.Add("@d_vencto", Convert.ChangeType(dtVecimento, GetType(Date)))
        comm.Parameters.Add("@d_valor", vlDuplicata)
        comm.Parameters.Add("@d_cartei", carteira)
        'comm.Parameters.Add("@d_dtpaga", dtPagamento)
        comm.Parameters.Add("@d_juros", vlJuros)
        comm.Parameters.Add("@d_desc", vlDesconto)
        comm.Parameters.Add("@d_banco", banco)
        comm.Parameters.Add("@d_hist", historico)
        comm.Parameters.Add("@d_sit", situacao)
        comm.Parameters.Add("@d_stat", Status)


        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub


#End Region

#Region " * * *  Manutenção em Cadastro de Produtos * * *  "

    Public Sub incProduto(ByVal Produto As Cl_Est0001, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqVinc & ".est0001(")
        sqlbuild.Append("e_codig, e_produt, e_cdport, e_und, e_clf, e_cst, e_cfv, e_linha, ")
        sqlbuild.Append("e_grupo, e_locacao, e_codsubs, e_estmin, e_comer, e_qtde, e_pcusto, ")
        sqlbuild.Append("e_pvenda, e_com1, e_com2, e_peso, e_prom, e_reduz, e_vprom, e_qtdfisc, ")
        sqlbuild.Append("e_inventa, e_pcustom, e_pcustoa, e_prepo, e_pcomp, e_dtcomp, ")
        sqlbuild.Append("e_dtvend, e_pvend15, e_pvend30, e_agreg1, e_agreg2, e_deposito, ")
        sqlbuild.Append("e_empcre, e_empdeb, e_promi, e_valid, e_status, e_fixo, e_ptran, ")
        sqlbuild.Append("e_ipi, e_letra, e_icmsub, e_pis, e_icms, e_filial1, e_filial2, ")
        sqlbuild.Append("e_bonif, e_ncm, e_produt2, e_pcstent, e_pcstsai, e_ccstent, e_ccstsai, ")
        sqlbuild.Append("e_pbcalc, e_cdforte, e_fortcof, e_cdbarra, e_embalag, e_pesobruto, e_pesoliq, ")
        sqlbuild.Append("e_consumo, e_imobilizado, e_servico, e_inativo, e_materiaprima, e_balanca, e_qtdxund, ")
        sqlbuild.Append("e_pauta, e_classe, e_tipo, e_grade, e_dtinicialpromocao, e_dtfinalpromocao, e_dtinicialbonific, ")
        sqlbuild.Append("e_dtfinalbonific, e_quotapromocao, e_bonificquantidade, e_bonificvalor, e_qtdebonifcliente, e_origem, ")
        sqlbuild.Append("e_aplicacao, e_cstipi, e_produt3, e_idimagem) VALUES (")
        sqlbuild.Append("@e_codig, @e_produt, @e_cdport, @e_und, @e_clf, @e_cst, @e_cfv, @e_linha, ")
        sqlbuild.Append("@e_grupo, @e_locacao, @e_codsubs, @e_estmin, @e_comer, @e_qtde, @e_pcusto, ")
        sqlbuild.Append("@e_pvenda, @e_com1, @e_com2, @e_peso, @e_prom, @e_reduz, @e_vprom, @e_qtdfisc, ")
        sqlbuild.Append("@e_inventa, @e_pcustom, @e_pcustoa, @e_prepo, @e_pcomp, @e_dtcomp, ") '
        sqlbuild.Append("@e_dtvend, @e_pvend15, @e_pvend30, @e_agreg1, @e_agreg2, @e_deposito, ")
        sqlbuild.Append("@e_empcre, @e_empdeb, @e_promi, @e_valid, @e_status, @e_fixo, @e_ptran, ")
        sqlbuild.Append("@e_ipi, @e_letra, @e_icmsub, @e_pis, @e_icms, @e_filial1, @e_filial2, ")
        sqlbuild.Append("@e_bonif, @e_ncm, @e_produt2, @e_pcstent, @e_pcstsai, @e_ccstent, @e_ccstsai, ")
        sqlbuild.Append("@e_pbcalc, @e_cdforte, @e_fortcof, @e_cdbarra, @e_embalag, @e_pesobruto, ")
        sqlbuild.Append("@e_pesoliq, @e_consumo, @e_imobilizado, @e_servico, @e_inativo, @e_materiaprima, ")
        sqlbuild.Append("@e_balanca, @e_qtdxund, @e_pauta, @e_classe, @e_tipo,  @e_grade, @e_dtinicialpromocao, ")
        sqlbuild.Append("@e_dtfinalpromocao, @e_dtinicialbonific, @e_dtfinalbonific, @e_quotapromocao, @e_bonificquantidade, ")
        sqlbuild.Append("@e_bonificvalor, @e_qtdebonifcliente, @e_origem, @e_aplicacao, @e_cstipi, @e_produt3, @e_idimagem); ")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@e_codig", Produto.pCodig) : comm.Parameters.Add("@e_produt", Produto.pProdut)
        comm.Parameters.Add("@e_cdport", Produto.pCdport) : comm.Parameters.Add("@e_und", Produto.pUnd)
        comm.Parameters.Add("@e_clf", Produto.pClf) : comm.Parameters.Add("@e_cst", Produto.pCst)
        comm.Parameters.Add("@e_cfv", Produto.pCfv) : comm.Parameters.Add("@e_linha", Produto.pLinha)
        comm.Parameters.Add("@e_grupo", Produto.pGrupo) : comm.Parameters.Add("@e_locacao", Produto.pLocacao)
        comm.Parameters.Add("@e_codsubs", Produto.pCodsubs) : comm.Parameters.Add("@e_estmin", Produto.pEstmin)
        comm.Parameters.Add("@e_comer", Produto.pComer) : comm.Parameters.Add("@e_qtde", Produto.pQtde)
        comm.Parameters.Add("@e_pcusto", Produto.pPcusto) : comm.Parameters.Add("@e_pvenda", Produto.pPvenda)
        comm.Parameters.Add("@e_com1", Produto.pCom1) : comm.Parameters.Add("@e_com2", Produto.pCom1) : comm.Parameters.Add("@e_peso", Produto.pPeso)
        comm.Parameters.Add("@e_prom", Produto.pProm) : comm.Parameters.Add("@e_reduz", Produto.pReduz)
        comm.Parameters.Add("@e_vprom", Produto.pVprom) : comm.Parameters.Add("@e_qtdfisc", Produto.pQtdfisc)
        comm.Parameters.Add("@e_inventa", Produto.pInventa) : comm.Parameters.Add("@e_pcustom", Produto.pPcustom)
        comm.Parameters.Add("@e_pcustoa", Produto.pPcustoa) : comm.Parameters.Add("@e_prepo", Produto.pPrepo)
        comm.Parameters.Add("@e_pcomp", Produto.pPcomp)

        Try
            comm.Parameters.Add("@e_dtcomp", Convert.ChangeType(Produto.pDtcomp, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_dtcomp", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@e_pvend15", Produto.pPvend15)

        Try
            comm.Parameters.Add("@e_dtvend", Convert.ChangeType(Produto.pDtvend, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_dtvend", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@e_pvend30", Produto.pPvend30) : comm.Parameters.Add("@e_agreg1", Produto.pAgreg1)
        comm.Parameters.Add("@e_agreg2", Produto.pAgreg2) : comm.Parameters.Add("@e_deposito", Produto.pDeposito)
        comm.Parameters.Add("@e_empcre", Produto.pEmpcre) : comm.Parameters.Add("@e_empdeb", Produto.pEmpdeb)
        comm.Parameters.Add("@e_promi", Produto.pPromi)

        'trata a data de validade
        Try
            comm.Parameters.Add("@e_valid", Convert.ChangeType(Produto.pValid, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_valid", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@e_status", Produto.pStatus) : comm.Parameters.Add("@e_fixo", Produto.pFixo)
        comm.Parameters.Add("@e_ptran", Produto.pPtran) : comm.Parameters.Add("@e_ipi", Produto.pIpi) : comm.Parameters.Add("@e_letra", Produto.pLetra)
        comm.Parameters.Add("@e_icmsub", Produto.pIcmsub) : comm.Parameters.Add("@e_pis", Produto.pPis) : comm.Parameters.Add("@e_icms", Produto.pIcms)
        comm.Parameters.Add("@e_filial1", Produto.pFilial1) : comm.Parameters.Add("@e_filial2", Produto.pFilial2)
        comm.Parameters.Add("@e_bonif", Produto.pBonif) : comm.Parameters.Add("@e_ncm", Produto.pNcm)
        comm.Parameters.Add("@e_produt2", Produto.pProdut2) : comm.Parameters.Add("@e_pcstent", Produto.pPcstent)
        comm.Parameters.Add("@e_pcstsai", Produto.pPcstsai) : comm.Parameters.Add("@e_ccstent", Produto.pCcstent)
        comm.Parameters.Add("@e_ccstsai", Produto.pCcstsai) : comm.Parameters.Add("@e_pbcalc", Produto.pPbcalc)
        comm.Parameters.Add("@e_cdforte", Produto.pCdforte) : comm.Parameters.Add("@e_fortcof", Produto.pFortcof)
        comm.Parameters.Add("@e_embalag", Produto.pEmbalag) : comm.Parameters.Add("@e_cdbarra", Produto.pCdbarra)
        comm.Parameters.Add("@e_pesobruto", Produto.pPesobruto) : comm.Parameters.Add("@e_pesoliq", Produto.pPesoliq)
        comm.Parameters.Add("@e_consumo", Produto.pConsumo) : comm.Parameters.Add("@e_imobilizado", Produto.pImobilizado)
        comm.Parameters.Add("@e_servico", Produto.pServico) : comm.Parameters.Add("@e_inativo", Produto.pInativo)
        comm.Parameters.Add("@e_materiaprima", Produto.pMateriaprima) : comm.Parameters.Add("@e_balanca", Produto.pBalanca)
        comm.Parameters.Add("@e_qtdxund", Produto.pQtdxUnd) : comm.Parameters.Add("@e_pauta", Produto.pPauta)
        comm.Parameters.Add("@e_classe", Produto.pClasse) : comm.Parameters.Add("@e_tipo", Produto.pTipo)
        comm.Parameters.Add("@e_grade", Produto.pGrade) : comm.Parameters.Add("@e_origem", Produto.pOrigem)
        comm.Parameters.Add("@e_aplicacao", Produto.pAplicacao) : comm.Parameters.Add("@e_produt3", Produto.pProdut3)

        Try
            comm.Parameters.Add("@e_dtinicialpromocao", Convert.ChangeType(Produto.pDtinicialpromocao, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_dtinicialpromocao", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        Try
            comm.Parameters.Add("@e_dtfinalpromocao", Convert.ChangeType(Produto.pDtfinalpromocao, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_dtfinalpromocao", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        Try
            comm.Parameters.Add("@e_dtinicialbonific", Convert.ChangeType(Produto.pDtinicialbonific, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_dtinicialbonific", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        Try
            comm.Parameters.Add("@e_dtfinalbonific", Convert.ChangeType(Produto.pDtfinalbonific, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_dtfinalbonific", NpgsqlTypes.NpgsqlDbType.Date)
        End Try
        comm.Parameters.Add("@e_quotapromocao", Produto.pQuotaPromocao)
        comm.Parameters.Add("@e_bonificquantidade", Produto.pBonificquantidade)
        comm.Parameters.Add("@e_bonificvalor", Produto.pBonificvalor)
        comm.Parameters.Add("@e_qtdebonifcliente", Produto.pQtdebonifcliente)
        comm.Parameters.Add("@e_cstipi", Produto.pCstIpi)
        comm.Parameters.Add("@e_idimagem", Produto.pIdImagem)


        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incImagemProduto(ByVal Imagem As Cl_ImagemProdutos, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqVinc & ".imagemprodutos(")
        sqlbuild.Append("img_id, img_nome, img_imagem) VALUES (@id, @nome, lo_import('" & Imagem.pImagem & "'));")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@id", Imagem.pId) : comm.Parameters.Add("@nome", Imagem.pNome)
        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub


    Public Sub altProduto(ByVal Produto As Cl_Est0001, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqVinc & ".est0001 SET ")
        sqlbuild.Append("e_produt = @e_produt, e_cdport = @e_cdport, e_und = @e_und, e_clf = @e_clf, ")
        sqlbuild.Append("e_cst = @e_cst, e_cfv = @e_cfv, e_linha = @e_linha, e_grupo = @e_grupo, e_locacao = @e_locacao, ")
        sqlbuild.Append("e_codsubs = @e_codsubs, e_estmin = @e_estmin, e_comer = @e_comer, e_qtde = @e_qtde, ")
        sqlbuild.Append("e_pcusto = @e_pcusto, e_pvenda = @e_pvenda, e_com1 = @e_com1, e_com2 = @e_com2, e_peso = @e_peso, ")
        sqlbuild.Append("e_prom = @e_prom, e_reduz = @e_reduz, e_vprom = @e_vprom, e_qtdfisc = @e_qtdfisc, ")
        sqlbuild.Append("e_inventa = @e_inventa, e_pcustom = @e_pcustom, e_pcustoa = @e_pcustoa, e_prepo = @e_prepo, ")
        sqlbuild.Append("e_pcomp = @e_pcomp, e_pvend15 = @e_pvend15, e_pvend30 = @e_pvend30, e_agreg1 = @e_agreg1, ")
        sqlbuild.Append("e_agreg2 = @e_agreg2, e_deposito = @e_deposito, e_empcre = @e_empcre, e_empdeb = @e_empdeb, ")
        sqlbuild.Append("e_promi = @e_promi, e_valid = @e_valid, e_status = @e_status, e_fixo = @e_fixo, e_ptran = @e_ptran, ")
        sqlbuild.Append("e_ipi = @e_ipi, e_letra = @e_letra, e_icmsub = @e_icmsub, e_pis = @e_pis, e_icms = @e_icms, ")
        sqlbuild.Append("e_filial1 = @e_filial1, e_filial2 = @e_filial2, e_bonif = @e_bonif, e_ncm = @e_ncm, ")
        sqlbuild.Append("e_produt2 = @e_produt2, e_pcstent = @e_pcstent, e_pcstsai = @e_pcstsai, e_ccstent = @e_ccstent, ")
        sqlbuild.Append("e_ccstsai = @e_ccstsai, e_pbcalc = @e_pbcalc, e_cdforte = @e_cdforte, e_fortcof = @e_fortcof, ")
        sqlbuild.Append("e_cdbarra = @e_cdbarra, e_embalag = @e_embalag, e_pesobruto = @e_pesobruto, e_pesoliq = @e_pesoliq, ")
        sqlbuild.Append("e_consumo = @e_consumo, e_imobilizado = @e_imobilizado, e_servico = @e_servico, ")
        sqlbuild.Append("e_inativo = @e_inativo, e_materiaprima = @e_materiaprima, e_balanca = @e_balanca, ")
        sqlbuild.Append("e_qtdxund = @e_qtdxund, e_pauta = @e_pauta, e_classe = @e_classe, e_tipo = @e_tipo, ")
        sqlbuild.Append("e_grade = @e_grade, e_dtinicialpromocao = @e_dtinicialpromocao, e_dtfinalpromocao = @e_dtfinalpromocao, ")
        sqlbuild.Append("e_dtinicialbonific = @e_dtinicialbonific, e_dtfinalbonific = @e_dtfinalbonific, e_quotapromocao = @e_quotapromocao, ")
        sqlbuild.Append("e_bonificquantidade = @e_bonificquantidade, e_bonificvalor = @e_bonificvalor, e_qtdebonifcliente = @e_qtdebonifcliente, ")
        sqlbuild.Append("e_origem = @e_origem, e_aplicacao = @e_aplicacao, e_cstipi = @e_cstipi, e_produt3 = @e_produt3, e_idimagem = @e_idimagem WHERE e_codig = '" & Produto.pCodig & "'")
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@e_produt", Produto.pProdut)
        comm.Parameters.Add("@e_cdport", Produto.pCdport) : comm.Parameters.Add("@e_und", Produto.pUnd)
        comm.Parameters.Add("@e_clf", Produto.pClf) : comm.Parameters.Add("@e_cst", Produto.pCst)
        comm.Parameters.Add("@e_cfv", Produto.pCfv) : comm.Parameters.Add("@e_linha", Produto.pLinha)
        comm.Parameters.Add("@e_grupo", Produto.pGrupo) : comm.Parameters.Add("@e_locacao", Produto.pLocacao)
        comm.Parameters.Add("@e_codsubs", Produto.pCodsubs) : comm.Parameters.Add("@e_estmin", Produto.pEstmin)
        comm.Parameters.Add("@e_comer", Produto.pComer) : comm.Parameters.Add("@e_qtde", Produto.pQtde)
        comm.Parameters.Add("@e_pcusto", Produto.pPcusto) : comm.Parameters.Add("@e_pvenda", Produto.pPvenda)
        comm.Parameters.Add("@e_com1", Produto.pCom1) : comm.Parameters.Add("@e_com2", Produto.pCom1) : comm.Parameters.Add("@e_peso", Produto.pPeso)
        comm.Parameters.Add("@e_prom", Produto.pProm) : comm.Parameters.Add("@e_reduz", Produto.pReduz)
        comm.Parameters.Add("@e_vprom", Produto.pVprom) : comm.Parameters.Add("@e_qtdfisc", Produto.pQtdfisc)
        comm.Parameters.Add("@e_inventa", Produto.pInventa) : comm.Parameters.Add("@e_pcustom", Produto.pPcustom)
        comm.Parameters.Add("@e_pcustoa", Produto.pPcustoa) : comm.Parameters.Add("@e_prepo", Produto.pPrepo)
        comm.Parameters.Add("@e_pcomp", Produto.pPcomp) 'comm.Parameters.Add("@e_dtcomp", Convert.ChangeType(dtcomp))
        comm.Parameters.Add("@e_pvend15", Produto.pPvend15) ' : comm.Parameters.Add("@e_dtvend", dtvend)
        comm.Parameters.Add("@e_pvend30", Produto.pPvend30) : comm.Parameters.Add("@e_agreg1", Produto.pAgreg1)
        comm.Parameters.Add("@e_agreg2", Produto.pAgreg2) : comm.Parameters.Add("@e_deposito", Produto.pDeposito)
        comm.Parameters.Add("@e_empcre", Produto.pEmpcre) : comm.Parameters.Add("@e_empdeb", Produto.pEmpdeb)
        comm.Parameters.Add("@e_promi", Produto.pPromi)

        'trata a data de validade
        Try
            comm.Parameters.Add("@e_valid", Convert.ChangeType(Produto.pValid, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_valid", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@e_status", Produto.pStatus) : comm.Parameters.Add("@e_fixo", Produto.pFixo)
        comm.Parameters.Add("@e_ptran", Produto.pPtran) : comm.Parameters.Add("@e_ipi", Produto.pIpi) : comm.Parameters.Add("@e_letra", Produto.pLetra)
        comm.Parameters.Add("@e_icmsub", Produto.pIcmsub) : comm.Parameters.Add("@e_pis", Produto.pPis) : comm.Parameters.Add("@e_icms", Produto.pIcms)
        comm.Parameters.Add("@e_filial1", Produto.pFilial1) : comm.Parameters.Add("@e_filial2", Produto.pFilial2)
        comm.Parameters.Add("@e_bonif", Produto.pBonif) : comm.Parameters.Add("@e_ncm", Produto.pNcm)
        comm.Parameters.Add("@e_produt2", Produto.pProdut2) : comm.Parameters.Add("@e_pcstent", Produto.pPcstent)
        comm.Parameters.Add("@e_pcstsai", Produto.pPcstsai) : comm.Parameters.Add("@e_ccstent", Produto.pCcstent)
        comm.Parameters.Add("@e_ccstsai", Produto.pCcstsai) : comm.Parameters.Add("@e_pbcalc", Produto.pPbcalc)
        comm.Parameters.Add("@e_cdforte", Produto.pCdforte) : comm.Parameters.Add("@e_fortcof", Produto.pFortcof)
        comm.Parameters.Add("@e_embalag", Produto.pEmbalag) : comm.Parameters.Add("@e_cdbarra", Produto.pCdbarra)
        comm.Parameters.Add("@e_pesobruto", Produto.pPesobruto) : comm.Parameters.Add("@e_pesoliq", Produto.pPesoliq)
        comm.Parameters.Add("@e_consumo", Produto.pConsumo) : comm.Parameters.Add("@e_imobilizado", Produto.pImobilizado)
        comm.Parameters.Add("@e_servico", Produto.pServico) : comm.Parameters.Add("@e_inativo", Produto.pInativo)
        comm.Parameters.Add("@e_materiaprima", Produto.pMateriaprima) : comm.Parameters.Add("@e_balanca", Produto.pBalanca)
        comm.Parameters.Add("@e_qtdxund", Produto.pQtdxUnd) : comm.Parameters.Add("@e_pauta", Produto.pPauta)
        comm.Parameters.Add("@e_classe", Produto.pClasse) : comm.Parameters.Add("@e_tipo", Produto.pTipo)
        comm.Parameters.Add("@e_grade", Produto.pGrade) : comm.Parameters.Add("@e_origem", Produto.pOrigem)
        comm.Parameters.Add("@e_aplicacao", Produto.pAplicacao)

        Try
            comm.Parameters.Add("@e_dtinicialpromocao", Convert.ChangeType(Produto.pDtinicialpromocao, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_dtinicialpromocao", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        Try
            comm.Parameters.Add("@e_dtfinalpromocao", Convert.ChangeType(Produto.pDtfinalpromocao, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_dtfinalpromocao", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        Try
            comm.Parameters.Add("@e_dtinicialbonific", Convert.ChangeType(Produto.pDtinicialbonific, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_dtinicialbonific", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        Try
            comm.Parameters.Add("@e_dtfinalbonific", Convert.ChangeType(Produto.pDtfinalbonific, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@e_dtfinalbonific", NpgsqlTypes.NpgsqlDbType.Date)
        End Try
        comm.Parameters.Add("@e_quotapromocao", Produto.pQuotaPromocao)
        comm.Parameters.Add("@e_bonificquantidade", Produto.pBonificquantidade)
        comm.Parameters.Add("@e_bonificvalor", Produto.pBonificvalor)
        comm.Parameters.Add("@e_qtdebonifcliente", Produto.pQtdebonifcliente)
        comm.Parameters.Add("@e_cstipi", Produto.pCstIpi) : comm.Parameters.Add("@e_produt3", Produto.pProdut3)
        comm.Parameters.Add("@e_idimagem", Produto.pIdImagem)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altImagemProduto(ByVal Imagem As Cl_ImagemProdutos, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqVinc & ".imagemprodutos SET ")
        sqlbuild.Append("img_nome = @nome, img_imagem = lo_import('" & Imagem.pImagem & "') WHERE img_id = @id")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@id", Imagem.pId) : comm.Parameters.Add("@nome", Imagem.pNome)
        comm.Parameters.Add("@imagem", Imagem.pImagem)
        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function trazProxIdImagemProd(ByVal conexao As NpgsqlConnection) As String
        Dim mNumero As String = ""
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT nextval('" & MdlEmpresaUsu._esqVinc & ".imagemprodutos_ig_id_seq'::regclass)"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        dr = comm.ExecuteReader
        While dr.Read

            mNumero = dr(0).ToString
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumero
    End Function

    Public Sub excProduto(ByVal Codigo As Integer, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "Delete from Produtos where p_codigo=@p_codigo"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        ' Exclui Definitivamente o fornecedor
        conexao.Open()
        comm.Parameters.Add("@p_codigo", Codigo)
        transacao = conexao.BeginTransaction
        comm.Transaction = transacao

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub atualizaEstNCM(ByVal ncm As String, ByVal cfops As String, ByVal pisEnt As String, ByVal cofinsEnt As String, _
                              ByVal pisSaid As String, ByVal cofinsSaid As String, ByVal natPis As String, _
                              ByVal natCofins As String, ByVal descricao As String, ByVal conexao As NpgsqlConnection)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE estncm SET ncm_cfop = @ncm_cfop, ncm_pisent = @ncm_pisent, ncm_cofinsent = @ncm_cofinsent, " & _
        "ncm_pissaid = @ncm_pissaid, ncm_cofinssaid = @ncm_cofinssaid, ncm_natpis = @ncm_natpis, ncm_natcofins = @ncm_natcofins, " & _
        "ncm_descricao = @ncm_descricao WHERE ncm_ncm = @ncm_ncm;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@ncm_ncm", ncm)
        comm.Parameters.Add("@ncm_cfop", cfops)
        comm.Parameters.Add("@ncm_pisent", pisEnt)
        comm.Parameters.Add("@ncm_cofinsent", cofinsEnt)
        comm.Parameters.Add("@ncm_pissaid", pisSaid)
        comm.Parameters.Add("@ncm_cofinssaid", cofinsSaid)
        comm.Parameters.Add("@ncm_natpis", natPis)
        comm.Parameters.Add("@ncm_natcofins", natCofins)
        comm.Parameters.Add("@ncm_descricao", descricao)
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub incluiEstNCM(ByVal ncm As String, ByVal cfops As String, ByVal pisEnt As String, ByVal cofinsEnt As String, _
                            ByVal pisSaid As String, ByVal cofinsSaid As String, ByVal natPis As String, _
                            ByVal natCofins As String, ByVal descricao As String, ByVal conexao As NpgsqlConnection)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "INSERT INTO estncm (ncm_ncm, ncm_cfop, ncm_pisent, ncm_cofinsent, ncm_pissaid, ncm_cofinssaid, " & _
        "ncm_natpis, ncm_natcofins, ncm_descricao) VALUES (@ncm_ncm, @ncm_cfop, @ncm_pisent, @ncm_cofinsent, @ncm_pissaid, " & _
        "@ncm_cofinssaid, @ncm_natpis, @ncm_natcofins, @ncm_descricao);"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@ncm_ncm", ncm)
        comm.Parameters.Add("@ncm_cfop", cfops)
        comm.Parameters.Add("@ncm_pisent", pisEnt)
        comm.Parameters.Add("@ncm_cofinsent", cofinsEnt)
        comm.Parameters.Add("@ncm_pissaid", pisSaid)
        comm.Parameters.Add("@ncm_cofinssaid", cofinsSaid)
        comm.Parameters.Add("@ncm_natpis", natPis)
        comm.Parameters.Add("@ncm_natcofins", natCofins)
        comm.Parameters.Add("@ncm_descricao", descricao)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub deletaEstNCM(ByVal ncm As String, ByVal conexao As NpgsqlConnection)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "DELETE FROM estncm WHERE ncm_ncm = @ncm_ncm;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@ncm_ncm", ncm)
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function existEstNCM(ByVal ncm As String, ByVal conexao As NpgsqlConnection) As Boolean
        Dim existNCM As Boolean = True
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT ncm_ncm FROM estncm WHERE ncm_ncm = @ncm_ncm;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@ncm_ncm", ncm)

        dr = comm.ExecuteReader
        If dr.HasRows = False Then existNCM = False

        dr.Close() : comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return existNCM
    End Function

    Public Sub importProd(ByVal Codigo As Integer, ByVal CodBarra As String, ByVal CodNcm As String, ByVal Produto As String, _
        ByVal CodForn As String, ByVal Und As String, ByVal Embalagem As String, ByVal ClFisc As String, ByVal CodSubs As String, _
        ByVal CodVF As Integer, ByVal Grupo As Integer, ByVal Balanca As String, ByVal Situacao As String, ByVal DTAlterada As Date, _
        ByVal Promocao As String, ByVal PCompra As Decimal, ByVal PCompraAntes As Decimal, ByVal Pcusto As Decimal, _
        ByVal PCustoAntes As Decimal, ByVal Margem As Decimal, ByVal MargemAntes As Decimal, ByVal Pauta As Decimal, _
        ByVal VlPromocao As Decimal, ByVal Pvenda As Decimal, ByVal Saldo As Decimal, ByVal Inventario As Decimal, _
        ByVal QtdFiscal As Decimal, ByVal SldFilial01 As Decimal, ByVal SldFilial02 As Decimal, ByVal SldFilial03 As Decimal, _
        ByVal SldFilial04 As Decimal, ByVal DtComp As Date, ByVal DtVenda As Date, ByVal QtUnid As Integer, _
        ByVal QtdeUnd As Integer, ByVal IsentoPis As String, ByVal Linha As Integer, ByVal conexao As String)

        Try
            Dim conn As New NpgsqlConnection(conexao)
            Dim comm As New NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            sqlbuild.Append("INSERT INTO produtos(p_codigo, p_codbarra, p_ncm, p_produto,p_codforn,")
            sqlbuild.Append("p_und, p_embalagem,p_clfisc, p_subst, p_vlrfiscal, p_grupo, p_balanca,p_sit, ")
            sqlbuild.Append("p_dtaltera, p_promocao, p_pcocompra, p_pcompantes, p_pcocusto, p_pcustoantes, ")
            sqlbuild.Append("p_margem, p_margemantes, p_pcopauta, p_vlpromocao, p_pcovenda,p_saldo, ")
            sqlbuild.Append("p_inventario, p_qtdfiscal, p_sldfilia01, p_sldfilia02,p_sldfilia03, p_sldfilia04, ")
            sqlbuild.Append("p_dtcomp, p_dtvend, p_qtunid, p_qtdeund, p_pc,p_linha) VALUES ( @p_codigo, @p_codbarra, ")
            sqlbuild.Append("@p_ncm, @p_produto, @p_codforn, @p_und, @p_embalagem, @p_clfisc, @p_subst, ")
            sqlbuild.Append("@p_vlrfiscal, @p_grupo,  @p_balanca, @p_sit, @p_dtaltera, @p_promocao, @p_pcocompra, ")
            sqlbuild.Append("@p_pcompantes, @p_pcocusto, @p_pcustoantes, @p_margem, @p_margemantes, ")
            sqlbuild.Append("@p_pcopauta, @p_vlpromocao, @p_pcovenda,@p_saldo, @p_inventario,@p_qtdfiscal, ")
            sqlbuild.Append("@p_sldfilia01, @p_sldfilia02,@p_sldfilia03, @p_sldfilia04, @p_dtcomp, @p_dtvend, ")
            sqlbuild.Append("@p_qtunid, @p_qtdeund, @p_pc, @p_linha)")


            ' Abre Conexao--- 
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            comm = New NpgsqlCommand(sqlbuild.ToString, conn)

            ' Prepara Paramentros
            comm.Parameters.Add("@p_codigo", Codigo)
            comm.Parameters.Add("@p_codbarra", CodBarra)
            comm.Parameters.Add("@p_ncm", CodNcm.ToString)
            comm.Parameters.Add("@p_produto", Produto.ToString)
            comm.Parameters.Add("@p_codforn", CodForn.ToString)
            comm.Parameters.Add("@p_und", Und.ToString)
            comm.Parameters.Add("@p_embalagem", Embalagem.ToString)
            comm.Parameters.Add("@p_clfisc", ClFisc.ToString)
            comm.Parameters.Add("@p_subst", CodSubs.ToString)
            comm.Parameters.Add("@p_vlrfiscal", Convert.ToInt16(CodVF))
            comm.Parameters.Add("@p_grupo", Convert.ToInt16(Grupo))
            comm.Parameters.Add("@p_balanca", Balanca.ToString)
            comm.Parameters.Add("@p_sit", Situacao.ToString)
            comm.Parameters.Add("@p_dtaltera", Convert.ChangeType(DTAlterada, GetType(Date)))
            comm.Parameters.Add("@p_promocao", Promocao.ToString)
            comm.Parameters.Add("@p_pcocompra", PCompra)
            comm.Parameters.Add("@p_pcompantes", PCompraAntes)
            comm.Parameters.Add("@p_pcocusto", Pcusto)
            comm.Parameters.Add("@p_pcustoantes", PCustoAntes)
            comm.Parameters.Add("@p_margem", Margem)
            comm.Parameters.Add("@p_margemantes", MargemAntes)
            comm.Parameters.Add("@p_pcopauta", Pauta)
            comm.Parameters.Add("@p_vlpromocao", VlPromocao)
            comm.Parameters.Add("@p_pcovenda", Pvenda)
            comm.Parameters.Add("@p_saldo", Saldo)
            comm.Parameters.Add("@p_inventario", Inventario)
            comm.Parameters.Add("@p_qtdfiscal", QtdFiscal)
            comm.Parameters.Add("@p_sldfilia01", SldFilial01)
            comm.Parameters.Add("@p_sldfilia02", SldFilial02)
            comm.Parameters.Add("@p_sldfilia03", SldFilial03)
            comm.Parameters.Add("@p_sldfilia04", SldFilial04)
            comm.Parameters.Add("@p_dtcomp", Convert.ChangeType(DtComp, GetType(Date)))
            comm.Parameters.Add("@p_dtvend", Convert.ChangeType(DtVenda, GetType(Date)))
            comm.Parameters.Add("@p_qtunid", Convert.ToInt32(QtUnid))
            comm.Parameters.Add("@p_qtdeund", Convert.ToInt32(QtdeUnd))
            comm.Parameters.Add("@p_pc", IsentoPis)
            comm.Parameters.Add("@p_linha", Linha)

            comm.ExecuteNonQuery()

            _transacao.Commit()
            conn.Close()
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Produto :" & Codigo.ToString & "-" & Produto.ToString & ex.Message.ToString)

        End Try

    End Sub

    Public Sub insertProdFornecedorXML(ByVal cnpjForn As String, ByVal codigForn As String, ByVal undForn As String, _
                                    ByVal codigLoja As String, ByVal undLoja As String, ByVal conexao As NpgsqlConnection, _
                                    ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "INSERT INTO estforn(cnpjforn, codigforn, codigloja, undforn, undloja) "
        sqlcmd += "VALUES (@cnpjforn, @codigforn, @codigloja, @undforn, @undloja);"
        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@cnpjforn", cnpjForn)
        comm.Parameters.Add("@codigforn", codigForn)
        comm.Parameters.Add("@codigloja", codigLoja)
        comm.Parameters.Add("@undforn", undForn)
        comm.Parameters.Add("@undloja", undLoja)

        comm.Transaction = transacao
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub updateProdFornecedorXML(ByVal cnpjForn As String, ByVal novoCodigForn As String, ByVal novoUndForn As String, _
                                    ByVal novoCodigLoja As String, ByVal novoUndLoja As String, ByVal antigoCodigLoja As String, _
                                    ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand

        Dim sqlcmd As String = "UPDATE estforn SET cnpjforn = @cnpjforn, codigforn = @novocodigforn, codigloja = @novocodigloja, "
        sqlcmd += "undforn = @novoundforn, undloja = @novoundloja WHERE cnpjforn = @cnpjforn AND codigloja = @antigocodigloja ;"
        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@cnpjforn", cnpjForn)
        comm.Parameters.Add("@novocodigforn", novoCodigForn)
        comm.Parameters.Add("@novocodigloja", novoCodigLoja)
        comm.Parameters.Add("@novoundforn", novoUndForn)
        comm.Parameters.Add("@novoundloja", novoUndLoja)
        comm.Parameters.Add("@antigocodigloja", antigoCodigLoja)

        comm.Transaction = transacao
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function existRelacionProdFornXML(ByVal cnpjForn As String, ByVal codigForn As String, ByVal codigLoja As String, _
                               ByVal conexao As NpgsqlConnection) As Boolean

        Dim mexit As Boolean = False
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT cnpjforn FROM estforn WHERE cnpjforn = @cnpjforn AND codigforn = @codigforn AND "
        sqlcmd += "codigloja = @codigloja ;"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@cnpjforn", cnpjForn)
        comm.Parameters.Add("@codigforn", codigForn)
        comm.Parameters.Add("@codigloja", codigLoja)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexit = True

        dr.Close() : conexao.ClearAllPools()
        comm = Nothing : dr = Nothing


        Return mexit
    End Function

    Public Function alterouRelacionProdFornXML(ByVal cnpjForn As String, ByVal codigForn As String, ByVal codigLoja As String, _
                                ByVal conexao As NpgsqlConnection) As Boolean

        Dim mexit As Boolean = False
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT cnpjforn FROM estforn WHERE cnpjforn = @cnpjforn AND codigforn = @codigforn AND "
        sqlcmd += "codigloja <> @codigloja ;"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@cnpjforn", cnpjForn)
        comm.Parameters.Add("@codigforn", codigForn)
        comm.Parameters.Add("@codigloja", codigLoja)
        dr = comm.ExecuteReader
        If dr.HasRows Then

            mexit = True : comm = Nothing : dr = Nothing
            Return mexit
        End If
        dr.Close()
        comm.CommandText = ""

        sqlcmd = "SELECT cnpjforn FROM estforn WHERE cnpjforn = @cnpjforn AND codigloja = @codigloja AND "
        sqlcmd += "codigforn <> @codigforn ;"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@cnpjforn", cnpjForn)
        comm.Parameters.Add("@codigforn", codigForn)
        comm.Parameters.Add("@codigloja", codigLoja)

        dr = comm.ExecuteReader
        If dr.HasRows Then

            mexit = True
        End If
        dr.Close() : comm = Nothing : dr = Nothing

        Return mexit
    End Function

    Public Function pegaRelacionProdFornXML(ByVal cnpjForn As String, ByVal codigForn As String, _
                                           ByVal conexao As NpgsqlConnection) As String

        Dim mCodigProd As String = ""
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT codigloja FROM estforn WHERE cnpjforn = @cnpjforn AND codigforn = @codigforn"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@cnpjforn", cnpjForn)
        comm.Parameters.Add("@codigforn", codigForn)

        dr = comm.ExecuteReader
        While dr.Read

            mCodigProd = dr(0).ToString
        End While
        dr.Close() : comm.CommandText = "" : comm = Nothing : dr = Nothing


        Return mCodigProd
    End Function

#End Region

#Region "  *  * Financeiro  Pagamento/Recebimento  * *  "

#Region " * *  Manutenção em Duplicatas Contas a Pagar * *  "

    Public Sub incPagamentoFatp001(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                ByVal qtdeParcelas As Int16, ByVal CodGeno As String, ByVal CodForn As String, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As String, ByVal Juros As Decimal, _
                ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, ByVal Banco As String, ByVal Tarifa As Decimal, _
                ByVal Outros As Decimal, ByVal Historico As String)

        Try
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder


            sqlbuild.Append("INSERT INTO fatp001( d_id, d_idn4ff, d_geno, d_portad, d_tipo, d_nfat, ")
            sqlbuild.Append("d_duplic, d_emiss, d_vencto, d_valor, d_dtpaga, d_juros, d_desc, ")
            sqlbuild.Append("d_banco, d_hist, d_sit, d_outros, d_sitanterior, d_parcelas, d_caixa) ")
            sqlbuild.Append("VALUES (Default, 0, @d_geno, @d_portad, @d_tipo, @d_nfat, ")
            sqlbuild.Append("@d_duplic, @d_emiss, @d_vencto, @d_valor, @d_dtpaga, @d_juros, ")
            sqlbuild.Append("@d_desc, @d_banco, @d_hist, @d_sit, @d_outros, @d_sitanterior, @d_parcelas, @d_caixa) ")

            comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
            comm.Parameters.Add("@d_geno", CodGeno)
            comm.Parameters.Add("@d_portad", CodForn)
            comm.Parameters.Add("@d_tipo", Tipo)
            comm.Parameters.Add("@d_nfat", Fatura)
            comm.Parameters.Add("@d_duplic", Documento)
            comm.Parameters.Add("@d_emiss", Convert.ChangeType(DtEmissao, GetType(Date)))
            comm.Parameters.Add("@d_vencto", Convert.ChangeType(DtVencto, GetType(Date)))
            comm.Parameters.Add("@d_valor", Valor)
            comm.Parameters.Add("@d_parcelas", qtdeParcelas)


            Try
                comm.Parameters.Add("@d_dtpaga", Convert.ChangeType(DtPaga, GetType(Date)))
            Catch ex As Exception
                comm.Parameters.Add("@d_dtpaga", NpgsqlTypes.NpgsqlDbType.Date)
            End Try

            comm.Parameters.Add("@d_juros", Juros)
            comm.Parameters.Add("@d_desc", Descontos)
            comm.Parameters.Add("@d_sit", Situacao)
            comm.Parameters.Add("@d_banco", Banco)
            comm.Parameters.Add("@d_hist", Historico)
            comm.Parameters.Add("@d_outros", Outros)
            comm.Parameters.Add("@d_sitanterior", Situacao)
            comm.Parameters.Add("@d_caixa", MdlUsuarioLogando._codcaixa)

            comm.Transaction = transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()

        Catch ex As NpgsqlException
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub altPagamentoFatp001(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, ByVal ID As Int64, _
                ByVal CodGeno As String, ByVal CodForn As String, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As String, ByVal Juros As Decimal, _
                ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, ByVal Banco As String, ByVal Tarifa As Decimal, _
                ByVal Outros As Decimal, ByVal Historico As String)

        Try
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder


            sqlbuild.Append("UPDATE fatp001 SET d_geno  =  @d_geno, d_portad = @d_portad, d_tipo = @d_tipo, d_nfat = @d_nfat, ")
            sqlbuild.Append("d_duplic = @d_duplic, d_emiss = @d_emiss, d_vencto = @d_vencto, d_valor = @d_valor, ")
            sqlbuild.Append("d_dtpaga = @d_dtpaga, d_juros = @d_juros, d_desc = @d_desc, d_banco = @d_banco, d_hist = @d_hist, ")
            sqlbuild.Append("d_sit = @d_sit, d_outros = @d_outros, d_sitanterior = @d_sitanterior, d_caixa = @d_caixa WHERE d_id = @d_id")

            comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
            comm.Parameters.Add("@d_id", ID)
            comm.Parameters.Add("@d_geno", CodGeno)
            comm.Parameters.Add("@d_portad", CodForn)
            comm.Parameters.Add("@d_tipo", Tipo)
            comm.Parameters.Add("@d_nfat", Fatura)
            comm.Parameters.Add("@d_duplic", Documento)
            comm.Parameters.Add("@d_emiss", Convert.ChangeType(DtEmissao, GetType(Date)))
            comm.Parameters.Add("@d_vencto", Convert.ChangeType(DtVencto, GetType(Date)))
            comm.Parameters.Add("@d_valor", Valor)

            Try
                comm.Parameters.Add("@d_dtpaga", Convert.ChangeType(DtPaga, GetType(Date)))
            Catch ex As Exception
                comm.Parameters.Add("@d_dtpaga", NpgsqlTypes.NpgsqlDbType.Date)
            End Try

            comm.Parameters.Add("@d_juros", Juros)
            comm.Parameters.Add("@d_desc", Descontos)
            comm.Parameters.Add("@d_sit", Situacao)
            comm.Parameters.Add("@d_banco", Banco)
            comm.Parameters.Add("@d_hist", Historico)
            comm.Parameters.Add("@d_outros", Outros)
            comm.Parameters.Add("@d_sitanterior", Situacao)
            comm.Parameters.Add("@d_caixa", MdlUsuarioLogando._codcaixa)

            comm.Transaction = transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()

        Catch ex As NpgsqlException
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub altPagamentoFatp001All(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, ByVal Fatura As String, _
                                     ByVal Valor As Decimal, ByVal Tipo As String)

        Try
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder


            sqlbuild.Append("UPDATE fatp001 SET d_valor = @d_valor, d_tipo = @d_tipo, d_caixa = @d_caixa WHERE d_nfat = @d_nfat AND d_sit = 'N' ")

            comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
            comm.Parameters.Add("@d_tipo", Tipo)
            comm.Parameters.Add("@d_nfat", Fatura)
            comm.Parameters.Add("@d_valor", Valor)
            comm.Parameters.Add("@d_caixa", MdlUsuarioLogando._codcaixa)


            comm.Transaction = transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()

        Catch ex As NpgsqlException
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub incDuplicatas(ByVal Codigo As Integer, ByVal CodForn As Integer, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As Date, ByVal Juros As Decimal, _
                ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, ByVal Banco As Integer, ByVal Tarifa As Decimal, _
                ByVal Outros As Decimal, ByVal Historico As String, ByVal Conexao As String)

        Try
            Dim conn As New NpgsqlConnection(Conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            sqlbuild.Append("INSERT INTO pagamentos( p_codigo, p_codforn, p_nfatura, ")
            sqlbuild.Append("p_documento, p_emissao, p_vencto, p_valor, p_dtpaga, p_juros, ")
            sqlbuild.Append("p_descontos, p_situacao, p_tipo,p_banco, p_tarifa, p_outros, ")
            sqlbuild.Append("p_historico) VALUES (Default, @p_codforn, @p_nfatura, ")
            sqlbuild.Append("@p_documento, @p_emissao, @p_vencto, @p_valor, @p_dtpaga, ")
            sqlbuild.Append("@p_juros, @p_descontos, @p_situacao, @p_tipo, @p_banco, ")
            sqlbuild.Append("@p_tarifa, @p_outros, @p_historico)")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            comm.Parameters.Add("@p_codforn", CodForn)
            comm.Parameters.Add("@p_nfatura", Fatura)
            comm.Parameters.Add("@p_documento", Documento)
            comm.Parameters.Add("@p_emissao", Convert.ChangeType(DtEmissao, GetType(Date)))
            comm.Parameters.Add("@p_vencto", Convert.ChangeType(DtVencto, GetType(Date)))
            comm.Parameters.Add("@p_valor", Valor)
            comm.Parameters.Add("@p_dtpaga", Convert.ChangeType(DtPaga, GetType(Date)))
            comm.Parameters.Add("@p_juros", Juros)
            comm.Parameters.Add("@p_descontos", Descontos)
            comm.Parameters.Add("@p_situacao", Situacao)
            comm.Parameters.Add("@p_tipo", Tipo)
            comm.Parameters.Add("@p_banco", Banco)
            comm.Parameters.Add("@p_tarifa", Tarifa)
            comm.Parameters.Add("@p_outros", Outros)
            comm.Parameters.Add("@p_historico", Historico)

            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()
            _transacao.Commit()
            ' Fecha conexão
            conn.Close()
        Catch ex As NpgsqlException
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub altDuplicatas(ByVal Codigo As Integer, ByVal CodForn As Integer, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As Date, ByVal Juros As Decimal, _
                ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, ByVal Banco As Integer, ByVal Tarifa As Decimal, _
                ByVal Outros As Decimal, ByVal Historico As String, ByVal Conexao As String)

        Try
            Dim conn As New NpgsqlConnection(Conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            sqlbuild.Append("UPDATE pagamentos SET p_codigo=@p_codigo, p_codforn=@p_codforn,")
            sqlbuild.Append("p_nfatura=@p_nfatura, p_documento=@p_documento, p_emissao=@p_emissao,")
            sqlbuild.Append("p_vencto=@p_vencto, p_valor=@p_valor, p_dtpaga=@p_dtpaga,")
            sqlbuild.Append("p_juros=@p_juros, p_descontos=@p_descontos, ")
            sqlbuild.Append("p_situacao=@p_situacao, p_tipo=@p_tipo, p_banco=@p_banco,")
            sqlbuild.Append("p_tarifa=@p_tarifa, p_outros=@p_outros, p_historico=@p_historico ")
            sqlbuild.Append("WHERE p_codigo=@p_codigo")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            comm.Parameters.Add("@p_codigo", Codigo)
            comm.Parameters.Add("@p_codforn", CodForn)
            comm.Parameters.Add("@p_nfatura", Fatura)
            comm.Parameters.Add("@p_documento", Documento)
            comm.Parameters.Add("@p_emissao", Convert.ChangeType(DtEmissao, GetType(Date)))
            comm.Parameters.Add("@p_vencto", Convert.ChangeType(DtVencto, GetType(Date)))
            comm.Parameters.Add("@p_valor", Valor)
            comm.Parameters.Add("@p_dtpaga", Convert.ChangeType(DtPaga, GetType(Date)))
            comm.Parameters.Add("@p_juros", Juros)
            comm.Parameters.Add("@p_descontos", Descontos)
            comm.Parameters.Add("@p_situacao", Situacao)
            comm.Parameters.Add("@p_tipo", Tipo)
            comm.Parameters.Add("@p_banco", Banco)
            comm.Parameters.Add("@p_tarifa", Tarifa)
            comm.Parameters.Add("@p_outros", Outros)
            comm.Parameters.Add("@p_historico", Historico)
            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' Altera Registros
            comm.ExecuteNonQuery()
            _transacao.Commit()
            ' Fecha conexão
            conn.Close()
        Catch ex As NpgsqlException
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

#End Region

#Region " * *  Manutenção em Duplicatas contas a Receber * *  "

    Public Sub altRecebimentoFatd001(ByVal Geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, ByVal ID As Int64, _
                ByVal CodGeno As String, ByVal CodForn As String, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As String, ByVal Juros As Decimal, _
                ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, ByVal Banco As String, ByVal Tarifa As Decimal, _
                ByVal taxa As Double, ByVal vlrTaxa As Double, ByVal Doutor As String, ByVal Hora As String, ByVal Protetico As Cl_Doutor, _
                ByVal TpAtendimento As Cl_TpAtendimento, ByVal Historico As String)

        Try
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder


            sqlbuild.Append("UPDATE " & Geno.pEsquemaestab & ".fatd001 SET f_geno = @f_geno, f_portad = @f_portad, f_tipo = @f_tipo, f_nfat = @f_nfat, ")
            sqlbuild.Append("f_duplic = @f_duplic, f_emiss = @f_emiss, f_vencto = @f_vencto, f_valor = @f_valor, ")
            sqlbuild.Append("f_dtpaga = @f_dtpaga, f_juros = @f_juros, f_desc = @f_desc, f_banco = @f_banco, f_hist = @f_hist, ")
            sqlbuild.Append("f_sit = @f_sit, f_outros = @f_outros, f_sitanterior = @f_sitanterior, f_caixa = @f_caixa, f_txcobrada = @f_txcobrada, ")
            sqlbuild.Append("f_vltxcobrada = @f_vltxcobrada, f_doutor = @f_doutor, f_hora = @f_hora, f_protetico = @f_protetico, f_iniciaisprot = @f_iniciaisprot, ")
            sqlbuild.Append("f_tpatend_id = @f_tpatend_id, f_tpatend = @f_tpatend WHERE f_idx = @f_id")

            comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
            comm.Parameters.Add("@f_id", ID)
            comm.Parameters.Add("@f_geno", CodGeno)
            comm.Parameters.Add("@f_portad", CodForn)
            comm.Parameters.Add("@f_tipo", Tipo)
            comm.Parameters.Add("@f_nfat", Fatura)
            comm.Parameters.Add("@f_duplic", Documento)
            comm.Parameters.Add("@f_emiss", Convert.ChangeType(DtEmissao, GetType(Date)))
            comm.Parameters.Add("@f_vencto", Convert.ChangeType(DtVencto, GetType(Date)))
            comm.Parameters.Add("@f_valor", Valor)

            Try
                comm.Parameters.Add("@f_dtpaga", Convert.ChangeType(DtPaga, GetType(Date)))
            Catch ex As Exception
                comm.Parameters.Add("@f_dtpaga", NpgsqlTypes.NpgsqlDbType.Date)
            End Try

            comm.Parameters.Add("@f_juros", Juros)
            comm.Parameters.Add("@f_desc", Descontos)
            comm.Parameters.Add("@f_sit", Situacao)
            comm.Parameters.Add("@f_banco", Banco)
            comm.Parameters.Add("@f_hist", Historico)
            comm.Parameters.Add("@f_txcobrada", taxa)
            comm.Parameters.Add("@f_vltxcobrada", vlrTaxa)
            comm.Parameters.Add("@f_sitanterior", Situacao)
            comm.Parameters.Add("@f_doutor", Doutor)
            comm.Parameters.Add("@f_hora", Hora)
            comm.Parameters.Add("@f_protetico", Protetico.Nome)
            comm.Parameters.Add("@f_iniciaisprot", Protetico.Iniciais)
            comm.Parameters.Add("@f_caixa", MdlUsuarioLogando._codcaixa)
            comm.Parameters.Add("@f_tpatend_id", TpAtendimento.tpa_id)
            comm.Parameters.Add("@f_tpatend", TpAtendimento.tpa_atendimento)

            comm.Transaction = transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()

        Catch ex As NpgsqlException
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub altRecebimentoFatd001All(ByVal Geno As Cl_Geno, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, ByVal Fatura As String, _
                                     ByVal Valor As Decimal, ByVal taxa As Double, ByVal vlrTaxa As Double, ByVal Tipo As String)

        Try
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder


            sqlbuild.Append("UPDATE " & Geno.pEsquemaestab & ".fatd001 SET f_valor = @f_valor, f_tipo = @f_tipo, f_caixa = @f_caixa, f_txcobrada = @f_txcobrada, ")
            sqlbuild.Append("f_vltxcobrada = @f_vltxcobrada WHERE f_nfat = @f_nfat AND f_sit = 'N' ")

            comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
            comm.Parameters.Add("@f_tipo", Tipo)
            comm.Parameters.Add("@f_nfat", Fatura)
            comm.Parameters.Add("@f_valor", Valor)
            comm.Parameters.Add("@f_txcobrada", taxa)
            comm.Parameters.Add("@f_vltxcobrada", vlrTaxa)
            comm.Parameters.Add("@f_caixa", MdlUsuarioLogando._codcaixa)


            comm.Transaction = transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()

        Catch ex As NpgsqlException
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Public Sub incDuplicatasR(ByVal qtdeParcelas As Int16, ByVal geno001 As Cl_Geno, ByVal CodCli As String, ByVal tipo As String, ByVal Fatura As String, _
                ByVal NotaFiscal As String, ByVal Serie As String, ByVal txdesc As Double, ByVal Documento As String, ByVal Emissao As Date, _
                ByVal Vencto As Date, ByVal Valor As Double, ByVal Carteira As String, ByVal Dtpaga As Date, ByVal Juros As Double, _
                ByVal desconto As Double, ByVal Banco As Integer, ByVal Historico As String, ByVal Doutor As String, ByVal Hora As String, ByVal hvencto As String, _
                ByVal taxa As Double, ByVal vlrTaxa As Double, ByVal Instr1 As String, ByVal Instr2 As String, ByVal Instr3 As String, ByVal Situacao As String, _
                ByVal status As Boolean, ByVal Loja As String, ByVal ftidx As Integer, ByVal Contactb As String, ByVal Contared As String, _
                ByVal NNumero As String, ByVal Impressao As String, ByVal Transmissao As String, ByVal Protetico As Cl_Doutor, ByVal TpAtendimento As Cl_TpAtendimento, _
                ByVal Conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Try
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".fatd001(f_geno, f_portad, f_tipo, f_nfat, f_nfisc, f_serie, f_txdesc, ")
            sqlbuild.Append("f_duplic, f_emiss, f_vencto, f_valor, f_cartei,  f_juros, f_desc, f_banco, f_hist, f_hvenc, ")
            sqlbuild.Append("f_codi1,f_codi2, f_codi3, f_sit, f_stat, f_loja, f_ftidx, f_ctactb, f_ctareduz,f_nnumero, ")
            sqlbuild.Append("f_imp, f_mtransm, f_parcelas, f_txcobrada, f_vltxcobrada, f_doutor, f_hora, f_protetico, f_iniciaisprot, f_tpatend_id, f_tpatend) VALUES ")
            sqlbuild.Append("(@f_geno, @f_portad, @f_tipo,@f_nfat, @f_nfisc, ")
            sqlbuild.Append("@f_serie, @f_txdesc, @f_duplic, @f_emiss, @f_vencto, @f_valor,@f_cartei, @f_juros,@f_desc, ")
            sqlbuild.Append("@f_banco, @f_hist, @f_hvenc, @f_codi1, @f_codi2, @f_codi3, @f_sit, @f_stat, ")
            sqlbuild.Append("@f_loja, default, @f_ctactb, @f_ctareduz,@f_nnumero, @f_imp, @f_mtransm, @f_parcelas, @f_txcobrada, @f_vltxcobrada, ")
            sqlbuild.Append("@f_doutor, @f_hora, @f_protetico, @f_iniciaisprot, @f_tpatend_id, @f_tpatend)")

            comm = New NpgsqlCommand(sqlbuild.ToString, Conexao)
            comm.Parameters.Add("@f_geno", geno001.pCodig)
            comm.Parameters.Add("@f_portad", CodCli)
            comm.Parameters.Add("@f_tipo", tipo)
            comm.Parameters.Add("@f_nfat", Fatura)
            comm.Parameters.Add("@f_nfisc", NotaFiscal)
            comm.Parameters.Add("@f_serie", Serie)
            comm.Parameters.Add("@f_txdesc", txdesc)
            comm.Parameters.Add("@f_duplic", Documento)
            comm.Parameters.Add("@f_emiss", Convert.ChangeType(Emissao, GetType(Date)))
            comm.Parameters.Add("@f_vencto", Convert.ChangeType(Vencto, GetType(Date)))
            comm.Parameters.Add("@f_valor", Valor)
            comm.Parameters.Add("@f_cartei", Carteira)
            ' comm.Parameters.Add("@f_dtpaga", Dtpaga)
            comm.Parameters.Add("@f_juros", Juros)
            comm.Parameters.Add("@f_desc", desconto)
            comm.Parameters.Add("@f_banco", Banco)
            comm.Parameters.Add("@f_hist", Historico)
            comm.Parameters.Add("@f_hvenc", hvencto)
            comm.Parameters.Add("@f_codi1", Instr1)
            comm.Parameters.Add("@f_codi2", Instr2)
            comm.Parameters.Add("@f_codi3", Instr3)
            comm.Parameters.Add("@f_sit", Situacao)
            comm.Parameters.Add("@f_stat", status)
            comm.Parameters.Add("@f_loja", Loja)
            '  comm.Parameters.Add("@f_ftidx", ftidx)
            comm.Parameters.Add("@f_ctactb", Contactb)
            comm.Parameters.Add("@f_ctareduz", Contared)
            comm.Parameters.Add("@f_nnumero", NNumero)
            comm.Parameters.Add("@f_imp", Impressao)
            comm.Parameters.Add("@f_mtransm", Transmissao)
            comm.Parameters.Add("@f_parcelas", qtdeParcelas)
            comm.Parameters.Add("@f_txcobrada", taxa)
            comm.Parameters.Add("@f_vltxcobrada", vlrTaxa)
            comm.Parameters.Add("@f_doutor", Doutor)
            comm.Parameters.Add("@f_hora", Hora)
            comm.Parameters.Add("@f_protetico", Protetico.Nome)
            comm.Parameters.Add("@f_iniciaisprot", Protetico.Iniciais)
            comm.Parameters.Add("@f_tpatend_id", TpAtendimento.tpa_id)
            comm.Parameters.Add("@f_tpatend", TpAtendimento.tpa_atendimento)


            ' Abre Conexão
            comm.Transaction = transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()
        Catch ex As NpgsqlException
            _transacao.Rollback()
            MsgBox("Erro na Tabela Fatd001 ", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela Fatd001 ", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub altDuplicatasR(ByVal Codigo As Integer, ByVal CodCli As Integer, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As Date, ByVal Juros As Decimal, _
                ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, ByVal Banco As Integer, ByVal Tarifa As Decimal, _
                ByVal Outros As Decimal, ByVal Historico As String, ByVal Conexao As String)

        Try
            Dim conn As New NpgsqlConnection(Conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder

            sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".pagamentos SET r_codigo=@r_codigo, r_codcli=@r_codcli,")
            sqlbuild.Append("r_nfatura=@r_nfatura, r_documento=@r_documento, r_emissao=@r_emissao,")
            sqlbuild.Append("r_vencto=@r_vencto, r_valor=@r_valor, r_dtpaga=@r_dtpaga,")
            sqlbuild.Append("r_juros=@r_juros, r_descontos=@r_descontos, ")
            sqlbuild.Append("r_situacao=@r_situacao, r_tipo=@r_tipo, r_banco=@r_banco,")
            sqlbuild.Append("r_tarifa=@r_tarifa, r_outros=@r_outros, r_historico=@r_historico ")
            sqlbuild.Append("WHERE r_codigo=@r_codigo")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            comm.Parameters.Add("@r_codigo", Codigo)
            comm.Parameters.Add("@r_codcli", CodCli)
            comm.Parameters.Add("@r_nfatura", Fatura)
            comm.Parameters.Add("@r_documento", Documento)
            comm.Parameters.Add("@r_emissao", Convert.ChangeType(DtEmissao, GetType(Date)))
            comm.Parameters.Add("@r_vencto", Convert.ChangeType(DtVencto, GetType(Date)))
            comm.Parameters.Add("@r_valor", Valor)
            comm.Parameters.Add("@r_dtpaga", Convert.ChangeType(DtPaga, GetType(Date)))
            comm.Parameters.Add("@r_juros", Juros)
            comm.Parameters.Add("@r_descontos", Descontos)
            comm.Parameters.Add("@r_situacao", Situacao)
            comm.Parameters.Add("@r_tipo", Tipo)
            comm.Parameters.Add("@r_banco", Banco)
            comm.Parameters.Add("@r_tarifa", Tarifa)
            comm.Parameters.Add("@r_outros", Outros)
            comm.Parameters.Add("@r_historico", Historico)
            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' Altera Registros
            comm.ExecuteNonQuery()
            _transacao.Commit()
            ' Fecha conexão
            conn.Close()
        Catch ex As NpgsqlException
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub IncDuplicatas_Parciais(ByVal geno As String, ByVal portador As String, ByVal tipo As String, ByVal nfatura As String, _
                                      ByVal nfiscal As String, ByVal serie As String, ByVal txdesc As Double, ByVal Documento As String, _
                                      ByVal emissao As Date, ByVal vencto As Date, ByVal valor As Double, ByVal carteira As String, _
                                      ByVal dtpaga As Date, ByVal juros As Double, ByVal desconto As Double, ByVal Banco As Integer, _
                                      ByVal historico As String, ByVal hvenc As String, ByVal protesto As Double, ByVal outros As Double, _
                                      ByVal situacao As String, ByVal status As Boolean, ByVal loja As String, ByVal Indice_2 As Int64, _
                                      ByVal ctactb As String, ByVal ctareduz As String, ByVal nnumero As String, ByVal vendedor As String, _
                                      ByVal conexao As String)
        Try

            Dim conn As New NpgsqlConnection(conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder


            sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".fatdp02(f_geno, f_portad, f_tipo, f_nfat, f_nfisc,f_serie,f_txdesc, ")
            sqlbuild.Append("f_duplic, f_emiss, f_vencto, f_valor, f_cartei, f_dtpaga, f_juros,f_desc, f_banco,")
            sqlbuild.Append("f_hist, f_hvenc, f_protest, f_outros, f_sit,f_stat, f_loja, f_ftidx,f_ctactb, ")
            sqlbuild.Append("f_ctareduz, f_nnumero, f_vend) VALUES (@f_geno, @f_portad, @f_tipo,@f_nfat, @f_nfisc, ")
            sqlbuild.Append("@f_serie, @f_txdesc,@f_duplic, @f_emiss, @f_vencto, @f_valor, @f_cartei,@f_dtpaga, ")
            sqlbuild.Append("@f_juros,@f_desc, @f_banco, @f_hist, @f_hvenc, @f_protest,@f_outros, @f_sit, ")
            sqlbuild.Append("@f_stat, @f_loja, Default, @f_ctactb, @f_ctareduz, @f_nnumero, @f_vend)")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            comm.Parameters.Add("@f_geno", geno)
            comm.Parameters.Add("@f_portad", portador)
            comm.Parameters.Add("@f_tipo", tipo)
            comm.Parameters.Add("@f_nfat", nfatura)
            comm.Parameters.Add("@f_nfisc", nfiscal)
            comm.Parameters.Add("@f_serie", serie)
            comm.Parameters.Add("@f_txdesc", txdesc)
            comm.Parameters.Add("@f_duplic", Documento)
            comm.Parameters.Add("@f_emiss", Convert.ChangeType(emissao, GetType(Date)))
            comm.Parameters.Add("@f_vencto", Convert.ChangeType(vencto, GetType(Date)))
            comm.Parameters.Add("@f_valor", valor)
            comm.Parameters.Add("@f_cartei", carteira)
            comm.Parameters.Add("@f_dtpaga", Convert.ChangeType(dtpaga, GetType(Date)))
            comm.Parameters.Add("@f_juros", juros)
            comm.Parameters.Add("@f_desc", desconto)
            comm.Parameters.Add("@f_banco", Banco)
            comm.Parameters.Add("@f_hist", historico)
            comm.Parameters.Add("@f_hvenc", hvenc)
            comm.Parameters.Add("@f_protest", protesto)
            comm.Parameters.Add("@f_outros", outros)
            comm.Parameters.Add("@f_sit", situacao)
            comm.Parameters.Add("@f_stat", status)
            comm.Parameters.Add("@f_loja", loja)
            ' comm.Parameters.Add("@f_ftidx", Indice_2) indice automatico
            comm.Parameters.Add("@f_ctactb", ctactb)
            comm.Parameters.Add("@f_ctareduz", ctareduz)
            comm.Parameters.Add("@f_nnumero", nnumero)
            comm.Parameters.Add("@f_vend", vendedor)

            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()
            _transacao.Commit()

            ' Fecha conex
            conn.Close()
        Catch ex As NpgsqlException
            _transacao.Rollback()
            MsgBox("Erro na Tabela Recebimento Parcial ", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela Recebimento Parcial ", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Public Sub IncPagamentos_Parciais(ByVal geno As String, ByVal portador As String, ByVal tipo As String, ByVal nfatura As String, _
                                      ByVal nfiscal As String, ByVal serie As String, ByVal txdesc As Double, ByVal Documento As String, _
                                      ByVal emissao As Date, ByVal vencto As Date, ByVal valor As Double, ByVal carteira As String, _
                                      ByVal dtpaga As Date, ByVal juros As Double, ByVal desconto As Double, ByVal Banco As Integer, _
                                      ByVal historico As String, ByVal hvenc As String, ByVal protesto As Double, ByVal outros As Double, _
                                      ByVal situacao As String, ByVal status As Boolean, ByVal loja As String, ByVal Indice_2 As Int64, _
                                      ByVal ctactb As String, ByVal ctareduz As String, ByVal nnumero As String, ByVal vendedor As String, _
                                      ByVal conexao As String)
        Try

            Dim conn As New NpgsqlConnection(conexao)
            Dim comm As NpgsqlCommand
            Dim sqlbuild As New StringBuilder


            sqlbuild.Append("INSERT INTO fatp002(d_geno, d_portad, d_tipo, d_nfat, d_nfisc,d_serie,d_txdesc, ")
            sqlbuild.Append("d_duplic, d_emiss, d_vencto, d_valor, d_cartei, d_dtpaga, d_juros,d_desc, d_banco,")
            sqlbuild.Append("d_hist, d_hvenc, d_protest, d_outros, d_sit,d_stat, d_loja, d_ftidx,d_ctactb, ")
            sqlbuild.Append("d_ctareduz, d_nnumero, d_vend) VALUES (@d_geno, @d_portad, @d_tipo,@d_nfat, @d_nfisc, ")
            sqlbuild.Append("@d_serie, @d_txdesc,@d_duplic, @d_emiss, @d_vencto, @d_valor, @d_cartei,@d_dtpaga, ")
            sqlbuild.Append("@d_juros,@d_desc, @d_banco, @d_hist, @d_hvenc, @d_protest,@d_outros, @d_sit, ")
            sqlbuild.Append("@d_stat, @d_loja, Default, @d_ctactb, @d_ctareduz, @d_nnumero, @d_vend)")

            comm = New NpgsqlCommand(sqlbuild.ToString, conn)
            comm.Parameters.Add("@d_geno", geno)
            comm.Parameters.Add("@d_portad", portador)
            comm.Parameters.Add("@d_tipo", tipo)
            comm.Parameters.Add("@d_nfat", nfatura)
            comm.Parameters.Add("@d_nfisc", nfiscal)
            comm.Parameters.Add("@d_serie", serie)
            comm.Parameters.Add("@d_txdesc", txdesc)
            comm.Parameters.Add("@d_duplic", Documento)
            comm.Parameters.Add("@d_emiss", Convert.ChangeType(emissao, GetType(Date)))
            comm.Parameters.Add("@d_vencto", Convert.ChangeType(vencto, GetType(Date)))
            comm.Parameters.Add("@d_valor", valor)
            comm.Parameters.Add("@d_cartei", carteira)
            comm.Parameters.Add("@d_dtpaga", Convert.ChangeType(dtpaga, GetType(Date)))
            comm.Parameters.Add("@d_juros", juros)
            comm.Parameters.Add("@d_desc", desconto)
            comm.Parameters.Add("@d_banco", Banco)
            comm.Parameters.Add("@d_hist", historico)
            comm.Parameters.Add("@d_hvenc", hvenc)
            comm.Parameters.Add("@d_protest", protesto)
            comm.Parameters.Add("@d_outros", outros)
            comm.Parameters.Add("@d_sit", situacao)
            comm.Parameters.Add("@d_stat", status)
            comm.Parameters.Add("@d_loja", loja)
            ' comm.Parameters.Add("@d_ftidx", Indice_2) indice automatico
            comm.Parameters.Add("@d_ctactb", ctactb)
            comm.Parameters.Add("@d_ctareduz", ctareduz)
            comm.Parameters.Add("@d_nnumero", nnumero)
            comm.Parameters.Add("@d_vend", vendedor)

            ' Abre Conexão
            conn.Open()
            _transacao = conn.BeginTransaction()
            comm.Transaction = _transacao
            ' Inclui Registros 
            comm.ExecuteNonQuery()
            _transacao.Commit()

            ' Fecha conex
            conn.Close()
        Catch ex As NpgsqlException
            _transacao.Rollback()
            MsgBox("Erro na Tabela Pagamento Parcial ", ex.Message.ToString, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            _transacao.Rollback()
            MsgBox("Erro na Tabela Pagamento Parcial ", ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try

    End Sub

#End Region

#End Region

#Region "***  Manutenção da NFe Entrada (Nota4ff, Nota2ff)  ***"

    Public Sub incNota2ff(ByVal nota2ff As Cl_Nota2ff, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".nota2ff ")
        sqlbuild.Append("(nc_idn4ff, nc_tipo, nc_numer, nc_codpr, nc_produt, nc_cf, ")
        sqlbuild.Append("nc_cst, nc_und, nc_qtde, nc_prunit, nc_prtot, nc_alqicm, nc_alqipi, ")
        sqlbuild.Append("nc_vlipi, nc_vlicm, nc_prucom, nc_desc, nc_icmsub, nc_tp, nc_cdport, ")
        sqlbuild.Append("nc_data, nc_usu, nc_dtusu, nc_hora, nc_vlicsub, nc_vlsub, nc_cfop, ")
        sqlbuild.Append("nc_vldesc, nc_alqnot, nc_basesub, nc_bscalc, nc_frete, nc_seguro, ")
        sqlbuild.Append("nc_estab, nc_totbruto, nc_outrasdesp) ")
        sqlbuild.Append("VALUES (@nc_idn4ff, @nc_tipo, @nc_numer, @nc_codpr, @nc_produt, @nc_cf, ")
        sqlbuild.Append("@nc_cst, @nc_und, @nc_qtde, @nc_prunit, @nc_prtot, @nc_alqicm, @nc_alqipi, ")
        sqlbuild.Append("@nc_vlipi, @nc_vlicm, @nc_prucom, @nc_desc, @nc_icmsub, @nc_tp, @nc_cdport, ")
        sqlbuild.Append("@nc_data, @nc_usu, @nc_dtusu, @nc_hora, @nc_vlicsub, @nc_vlsub, @nc_cfop, ")
        sqlbuild.Append("@nc_vldesc, @nc_alqnot, @nc_basesub, @nc_bscalc, @nc_frete, @nc_seguro, ")
        sqlbuild.Append("@nc_estab, @nc_totbruto, @nc_outrasdesp) ")



        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@nc_idn4ff", nota2ff.nc_idn4ff)
        comm.Parameters.Add("@nc_tipo", nota2ff.nc_tipo)
        comm.Parameters.Add("@nc_numer", nota2ff.nc_numer)
        comm.Parameters.Add("@nc_codpr", nota2ff.nc_codpr)
        comm.Parameters.Add("@nc_produt", nota2ff.nc_produt)
        comm.Parameters.Add("@nc_cf", nota2ff.nc_cf)
        comm.Parameters.Add("@nc_cst", nota2ff.nc_cst)
        comm.Parameters.Add("@nc_und", nota2ff.nc_und)
        comm.Parameters.Add("@nc_qtde", nota2ff.nc_qtde)
        comm.Parameters.Add("@nc_prunit", nota2ff.nc_prunit)
        comm.Parameters.Add("@nc_prtot", nota2ff.nc_prtot)
        comm.Parameters.Add("@nc_alqicm", nota2ff.nc_alqicm)
        comm.Parameters.Add("@nc_alqipi", nota2ff.nc_alqipi)
        comm.Parameters.Add("@nc_vlipi", nota2ff.nc_vlipi)

        Try
            comm.Parameters.Add("@nc_data", Convert.ChangeType(nota2ff.nc_data, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@nc_data", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        Try
            comm.Parameters.Add("@nc_dtusu", Convert.ChangeType(nota2ff.nc_dtusu, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@nc_dtusu", NpgsqlTypes.NpgsqlDbType.Date)
        End Try

        comm.Parameters.Add("@nc_vlicm", nota2ff.nc_vlicm)
        comm.Parameters.Add("@nc_prucom", nota2ff.nc_prucom)
        comm.Parameters.Add("@nc_desc", nota2ff.nc_desc)
        comm.Parameters.Add("@nc_icmsub", nota2ff.nc_icmsub)
        comm.Parameters.Add("@nc_tp", nota2ff.nc_tp)
        comm.Parameters.Add("@nc_cdport", nota2ff.nc_cdport)
        comm.Parameters.Add("@nc_data", Convert.ChangeType(nota2ff.nc_data, GetType(Date)))
        comm.Parameters.Add("@nc_usu", nota2ff.nc_usu)
        comm.Parameters.Add("@nc_hora", nota2ff.nc_hora)
        comm.Parameters.Add("@nc_vlicsub", nota2ff.nc_vlicsub)
        comm.Parameters.Add("@nc_vlsub", nota2ff.nc_vlsub)
        comm.Parameters.Add("@nc_cfop", nota2ff.nc_cfop)
        comm.Parameters.Add("@nc_vldesc", nota2ff.nc_vldesc)
        comm.Parameters.Add("@nc_alqnot", nota2ff.nc_alqnot)
        comm.Parameters.Add("@nc_basesub", nota2ff.nc_basesub)
        comm.Parameters.Add("@nc_bscalc", nota2ff.nc_bscalc)
        comm.Parameters.Add("@nc_frete", nota2ff.nc_frete)
        comm.Parameters.Add("@nc_seguro", nota2ff.nc_seguro)
        comm.Parameters.Add("@nc_estab", nota2ff.nc_estab)
        comm.Parameters.Add("@nc_totbruto", nota2ff.nc_totbruto)
        comm.Parameters.Add("@nc_outrasdesp", nota2ff.nc_outrasdesp)


        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delNota4ff(ByVal nota4ff As Cl_Nota4ff, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".nota4ff ")
        sqlbuild.Append("WHERE n4_numer = @n4_numer AND n4_cdport = @n4_cdport")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_numer", nota4ff.n4_numer)
        comm.Parameters.Add("@n4_cdport", nota4ff.n4_cdport)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delNota4ff(ByVal nota4ff As Cl_Nota4ff, ByVal geno001 As Cl_Geno, _
                          ByVal strconexao As String)

        Dim conexao As New NpgsqlConnection(strconexao)
        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        conexao.Open()

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".nota4ff ")
        sqlbuild.Append("WHERE n4_numer = @n4_numer AND n4_cdport = @n4_cdport")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@n4_numer", nota4ff.n4_numer)
        comm.Parameters.Add("@n4_cdport", nota4ff.n4_cdport)

        comm.ExecuteNonQuery()

        conexao.Close()
        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delNota2ff(ByVal nota2ff As Cl_Nota2ff, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".nota2ff ")
        sqlbuild.Append("WHERE nc_numer = @nc_numer AND nc_cdport = @nc_cdport")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@nc_numer", nota2ff.nc_numer)
        comm.Parameters.Add("@nc_cdport", nota2ff.nc_cdport)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delNota2ff(ByVal nota2ff As Cl_Nota2ff, ByVal geno001 As Cl_Geno, _
                          ByVal strconexao As String)

        Dim conexao As New NpgsqlConnection(strconexao)
        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        conexao.Open()

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".nota2ff ")
        sqlbuild.Append("WHERE nc_numer = @nc_numer AND nc_cdport = @nc_cdport")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@nc_numer", nota2ff.nc_numer)
        comm.Parameters.Add("@nc_cdport", nota2ff.nc_cdport)

        comm.ExecuteNonQuery()
        conexao.Close()
        comm = Nothing : sqlbuild = Nothing
    End Sub

    'INICIO do Tratamento dos Resumo dos Itens da NFe de Entradas....
    Public Sub IncResEntradaALQ(ByVal resn4ff01 As Cl_ResN4ff01, ByVal geno001 As Cl_Geno, _
                                  ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".resn4ff01(")
        sqlbuild.Append("r4_id, r4_idn4f, r4_numero, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, ")
        sqlbuild.Append("r4_toutrasdesp, r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral) ")
        sqlbuild.Append("VALUES (DEFAULT, @r4_idn4f, @r4_numero, @r4_aliq, @r4_tprod, @r4_tdesc, @r4_tfrete, ")
        sqlbuild.Append("@r4_tseguro, @r4_toutrasdesp, @r4_bcalc, @r4_icms, @r4_isento, @r4_outras, @r4_ipi, ")
        sqlbuild.Append("@r4_tgeral);")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_idn4f", resn4ff01.r4_idn4f)
        comm.Parameters.Add("@r4_numero", resn4ff01.r4_numero)
        comm.Parameters.Add("@r4_aliq", resn4ff01.r4_aliq)
        comm.Parameters.Add("@r4_tprod", resn4ff01.r4_tprod)
        comm.Parameters.Add("@r4_bcalc", resn4ff01.r4_bcalc)
        comm.Parameters.Add("@r4_icms", resn4ff01.r4_icms)
        comm.Parameters.Add("@r4_isento", resn4ff01.r4_isento)
        comm.Parameters.Add("@r4_outras", resn4ff01.r4_outras)
        comm.Parameters.Add("@r4_ipi", resn4ff01.r4_ipi)
        comm.Parameters.Add("@r4_tdesc", resn4ff01.r4_tdesc)
        comm.Parameters.Add("@r4_tfrete", resn4ff01.r4_tfrete)
        comm.Parameters.Add("@r4_tseguro", resn4ff01.r4_tseguro)
        comm.Parameters.Add("@r4_toutrasdesp", resn4ff01.r4_toutrasdesp)
        comm.Parameters.Add("@r4_tgeral", resn4ff01.r4_tgeral)
        'total geral...
        '((resn4dd01.totProd + resn4dd01.vlIsento + vlOutras + vlIPI + _
        '                                   totFrete + totSeguro + totOutrasDesp) - totDesc)


        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub delResEntradaALQ(ByVal resn4ff01 As Cl_ResN4ff01, ByVal geno001 As Cl_Geno, _
                                  ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".resn4ff01 WHERE r4_idn4f = " & resn4ff01.r4_idn4f)

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        'comm.Parameters.Add("@r4_idn4f", resn4ff01.r4_idn4f)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub IncResEntradaCfopALQ(ByVal resn4ff02 As Cl_ResN4ff02, ByVal geno001 As Cl_Geno, _
                                 ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".resn4ff02(")
        sqlbuild.Append("r4_id, r4_idn4f, r4_numero, r4_cfop, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, ")
        sqlbuild.Append("r4_toutrasdesp, r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral) ")
        sqlbuild.Append("VALUES (DEFAULT, @r4_idn4f, @r4_numero, @r4_cfop, @r4_aliq, @r4_tprod, @r4_tdesc, @r4_tfrete, ")
        sqlbuild.Append("@r4_tseguro, @r4_toutrasdesp, @r4_bcalc, @r4_icms, @r4_isento, @r4_outras, @r4_ipi, ")
        sqlbuild.Append("@r4_tgeral);")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_idn4f", resn4ff02.r4_idn4f)
        comm.Parameters.Add("@r4_numero", resn4ff02.r4_numero)
        comm.Parameters.Add("@r4_cfop", resn4ff02.r4_cfop)
        comm.Parameters.Add("@r4_aliq", resn4ff02.r4_aliq)
        comm.Parameters.Add("@r4_tprod", resn4ff02.r4_tprod)
        comm.Parameters.Add("@r4_bcalc", resn4ff02.r4_bcalc)
        comm.Parameters.Add("@r4_icms", resn4ff02.r4_icms)
        comm.Parameters.Add("@r4_isento", resn4ff02.r4_isento)
        comm.Parameters.Add("@r4_outras", resn4ff02.r4_outras)
        comm.Parameters.Add("@r4_ipi", resn4ff02.r4_ipi)
        comm.Parameters.Add("@r4_tdesc", resn4ff02.r4_tdesc)
        comm.Parameters.Add("@r4_tfrete", resn4ff02.r4_tfrete)
        comm.Parameters.Add("@r4_tseguro", resn4ff02.r4_tseguro)
        comm.Parameters.Add("@r4_toutrasdesp", resn4ff02.r4_toutrasdesp)
        comm.Parameters.Add("@r4_tgeral", resn4ff02.r4_tgeral)
        'total geral...
        '((resn4dd01.totProd + resn4dd01.vlIsento + vlOutras + vlIPI + _
        '                                   totFrete + totSeguro + totOutrasDesp) - totDesc)


        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub delResEntradaCfopALQ(ByVal resn4ff02 As Cl_ResN4ff02, ByVal geno001 As Cl_Geno, _
                                  ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".resn4ff02 WHERE r4_idn4f = " & resn4ff02.r4_idn4f)

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        'comm.Parameters.Add("@r4_idn4f", resn4ff02.r4_idn4f)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub IncResEntradaCstCfopALQ(ByVal resn4ff03 As Cl_ResN4ff03, ByVal geno001 As Cl_Geno, _
                                 ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".resn4ff03(")
        sqlbuild.Append("r4_id, r4_idn4f, r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, ")
        sqlbuild.Append("r4_toutrasdesp, r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral) ")
        sqlbuild.Append("VALUES (DEFAULT, @r4_idn4f, @r4_numero, @r4_cfop, @r4_cst, @r4_aliq, @r4_tprod, @r4_tdesc, @r4_tfrete, ")
        sqlbuild.Append("@r4_tseguro, @r4_toutrasdesp, @r4_bcalc, @r4_icms, @r4_isento, @r4_outras, @r4_ipi, ")
        sqlbuild.Append("@r4_tgeral);")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_idn4f", resn4ff03.r4_idn4f)
        comm.Parameters.Add("@r4_numero", resn4ff03.r4_numero)
        comm.Parameters.Add("@r4_cfop", resn4ff03.r4_cfop)
        comm.Parameters.Add("@r4_cst", resn4ff03.r4_cst)
        comm.Parameters.Add("@r4_aliq", resn4ff03.r4_aliq)
        comm.Parameters.Add("@r4_tprod", resn4ff03.r4_tprod)
        comm.Parameters.Add("@r4_bcalc", resn4ff03.r4_bcalc)
        comm.Parameters.Add("@r4_icms", resn4ff03.r4_icms)
        comm.Parameters.Add("@r4_isento", resn4ff03.r4_isento)
        comm.Parameters.Add("@r4_outras", resn4ff03.r4_outras)
        comm.Parameters.Add("@r4_ipi", resn4ff03.r4_ipi)
        comm.Parameters.Add("@r4_tdesc", resn4ff03.r4_tdesc)
        comm.Parameters.Add("@r4_tfrete", resn4ff03.r4_tfrete)
        comm.Parameters.Add("@r4_tseguro", resn4ff03.r4_tseguro)
        comm.Parameters.Add("@r4_toutrasdesp", resn4ff03.r4_toutrasdesp)
        comm.Parameters.Add("@r4_tgeral", resn4ff03.r4_tgeral)
        'total geral...
        '((resn4dd01.totProd + resn4dd01.vlIsento + vlOutras + vlIPI + _
        '                                   totFrete + totSeguro + totOutrasDesp) - totDesc)


        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub delResEntradaCstCfopALQ(ByVal resn4ff03 As Cl_ResN4ff03, ByVal geno001 As Cl_Geno, _
                                  ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".resn4ff03 WHERE r4_idn4f = " & resn4ff03.r4_idn4f)

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        'comm.Parameters.Add("@r4_idn4f", resn4ff03.r4_idn4f)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub
    'FIM do Tratamento dos Resumo dos Itens da NFe Saídas....


#End Region

#Region "* *  *   Manutenção da NFe (Nota1pp, Nota2cc, Nota4dd)   *  * *"

    Public Sub incNota1pp(ByVal nota1pp As Cl_Nota1pp, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".nota1pp(")
        sqlbuild.Append("tipo_nt, nt_tipo, nt_nume, nt_serie, nt_natur, nt_cfop, nt_geno, ")
        sqlbuild.Append("nt_codig, nt_dtemis, nt_dtsai, nt_emiss, nt_cnpj, nt_insc, nt_uf, ")
        sqlbuild.Append("nt_x, nt_y, nt_lote, nt_chave, nt_hrweb, nt_webrec, nt_proto, ")
        sqlbuild.Append("nt_status, nt_xml, nt_orca, nt_mapa, nt_indoper, nt_inddest, nt_refchave, ")
        sqlbuild.Append("nt_refcnpj, nt_refserie, nt_refnumero, nt_refuf, nt_indpres, nt_finnfe) VALUES (@tipo_nt, @nt_tipo, ")
        sqlbuild.Append("@nt_nume, @nt_serie, @nt_natur, @nt_cfop, @nt_geno, @nt_codig, ")
        sqlbuild.Append("@nt_dtemis, @nt_dtsai, @nt_emiss, @nt_cnpj, @nt_insc, @nt_uf, ")
        sqlbuild.Append("@nt_x, @nt_y, @nt_lote, @nt_chave, @nt_hrweb, @nt_webrec, @nt_proto, ")
        sqlbuild.Append("@nt_status, @nt_xml, @nt_orca, @nt_mapa, @nt_indoper, @nt_inddest, ")
        sqlbuild.Append("@nt_refchave, @nt_refcnpj, @nt_refserie, @nt_refnumero, @nt_refuf, @nt_indpres, @nt_finnfe)")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@tipo_nt", nota1pp.pTipo_nt)
        comm.Parameters.Add("@nt_tipo", nota1pp.pNt_tipo)
        comm.Parameters.Add("@nt_nume", nota1pp.pNt_nume)
        comm.Parameters.Add("@nt_serie", nota1pp.pNt_serie)
        comm.Parameters.Add("@nt_natur", nota1pp.pNt_natur)
        comm.Parameters.Add("@nt_cfop", nota1pp.pNt_cfop)
        comm.Parameters.Add("@nt_geno", nota1pp.pNt_geno)
        comm.Parameters.Add("@nt_codig", nota1pp.pNt_codig)
        Try
            comm.Parameters.Add("@nt_dtemis", Convert.ChangeType(nota1pp.pNt_dtemis, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@nt_dtemis", NpgsqlTypes.NpgsqlDbType.Date)
        End Try
        Try
            comm.Parameters.Add("@nt_dtsai", Convert.ChangeType(nota1pp.pNt_dtsai, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@nt_dtsai", NpgsqlTypes.NpgsqlDbType.Date)
        End Try
        comm.Parameters.Add("@nt_emiss", nota1pp.pNt_emiss)
        comm.Parameters.Add("@nt_cnpj", nota1pp.pNt_cnpj)
        comm.Parameters.Add("@nt_insc", nota1pp.pNt_insc)
        comm.Parameters.Add("@nt_uf", nota1pp.pNt_uf)
        comm.Parameters.Add("@nt_x", nota1pp.pNt_x)
        comm.Parameters.Add("@nt_y", nota1pp.pNt_y)
        comm.Parameters.Add("@nt_lote", nota1pp.pNt_lote)
        comm.Parameters.Add("@nt_chave", nota1pp.pNt_chave)
        comm.Parameters.Add("@nt_hrweb", nota1pp.pNt_hrweb)
        comm.Parameters.Add("@nt_webrec", nota1pp.pNt_webrec)
        comm.Parameters.Add("@nt_proto", nota1pp.pNt_proto)
        comm.Parameters.Add("@nt_status", nota1pp.pNt_status)
        comm.Parameters.Add("@nt_xml", nota1pp.pNt_xml)
        comm.Parameters.Add("@nt_orca", nota1pp.pNt_orca)
        comm.Parameters.Add("@nt_mapa", nota1pp.pNt_Mapa)
        comm.Parameters.Add("@nt_indoper", nota1pp.pNt_indOper)
        comm.Parameters.Add("@nt_inddest", nota1pp.pNt_indDest)
        comm.Parameters.Add("@nt_refchave", nota1pp.pNt_refChave)
        comm.Parameters.Add("@nt_refcnpj", nota1pp.pNt_refCnpj)
        comm.Parameters.Add("@nt_refserie", nota1pp.pNt_refSerie)
        comm.Parameters.Add("@nt_refnumero", nota1pp.pNt_refNumero)
        comm.Parameters.Add("@nt_refuf", nota1pp.pNt_refUf)
        comm.Parameters.Add("@nt_indpres", nota1pp.pNt_indPres)
        comm.Parameters.Add("@nt_finnfe", nota1pp.pNt_finNFe)


        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incNota1pp(ByVal nota1pp As Cl_Nota1pp, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".nota1pp(")
        sqlbuild.Append("tipo_nt, nt_tipo, nt_nume, nt_serie, nt_natur, nt_cfop, nt_geno, ")
        sqlbuild.Append("nt_codig, nt_dtemis, nt_dtsai, nt_emiss, nt_cnpj, nt_insc, nt_uf, ")
        sqlbuild.Append("nt_x, nt_y, nt_lote, nt_chave, nt_hrweb, nt_webrec, nt_proto, ")
        sqlbuild.Append("nt_status, nt_xml, nt_orca, nt_mapa, nt_indoper, nt_inddest, nt_refchave, ")
        sqlbuild.Append("nt_refcnpj, nt_refserie, nt_refnumero, nt_refuf, nt_indpres, nt_finnfe) VALUES (@tipo_nt, @nt_tipo, ")
        sqlbuild.Append("@nt_nume, @nt_serie, @nt_natur, @nt_cfop, @nt_geno, @nt_codig, ")
        sqlbuild.Append("@nt_dtemis, @nt_dtsai, @nt_emiss, @nt_cnpj, @nt_insc, @nt_uf, ")
        sqlbuild.Append("@nt_x, @nt_y, @nt_lote, @nt_chave, @nt_hrweb, @nt_webrec, @nt_proto, ")
        sqlbuild.Append("@nt_status, @nt_xml, @nt_orca, @nt_mapa, @nt_indoper, @nt_inddest, ")
        sqlbuild.Append("@nt_refchave, @nt_refcnpj, @nt_refserie, @nt_refnumero, @nt_refuf, @nt_indpres, @nt_finnfe)")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@tipo_nt", nota1pp.pTipo_nt)
        comm.Parameters.Add("@nt_tipo", nota1pp.pNt_tipo)
        comm.Parameters.Add("@nt_nume", nota1pp.pNt_nume)
        comm.Parameters.Add("@nt_serie", nota1pp.pNt_serie)
        comm.Parameters.Add("@nt_natur", nota1pp.pNt_natur)
        comm.Parameters.Add("@nt_cfop", nota1pp.pNt_cfop)
        comm.Parameters.Add("@nt_geno", nota1pp.pNt_geno)
        comm.Parameters.Add("@nt_codig", nota1pp.pNt_codig)
        Try
            comm.Parameters.Add("@nt_dtemis", Convert.ChangeType(nota1pp.pNt_dtemis, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@nt_dtemis", NpgsqlTypes.NpgsqlDbType.Date)
        End Try
        Try
            comm.Parameters.Add("@nt_dtsai", Convert.ChangeType(nota1pp.pNt_dtsai, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@nt_dtsai", NpgsqlTypes.NpgsqlDbType.Date)
        End Try
        comm.Parameters.Add("@nt_emiss", nota1pp.pNt_emiss)
        comm.Parameters.Add("@nt_cnpj", nota1pp.pNt_cnpj)
        comm.Parameters.Add("@nt_insc", nota1pp.pNt_insc)
        comm.Parameters.Add("@nt_uf", nota1pp.pNt_uf)
        comm.Parameters.Add("@nt_x", nota1pp.pNt_x)
        comm.Parameters.Add("@nt_y", nota1pp.pNt_y)
        comm.Parameters.Add("@nt_lote", nota1pp.pNt_lote)
        comm.Parameters.Add("@nt_chave", nota1pp.pNt_chave)
        comm.Parameters.Add("@nt_hrweb", nota1pp.pNt_hrweb)
        comm.Parameters.Add("@nt_webrec", nota1pp.pNt_webrec)
        comm.Parameters.Add("@nt_proto", nota1pp.pNt_proto)
        comm.Parameters.Add("@nt_status", nota1pp.pNt_status)
        comm.Parameters.Add("@nt_xml", nota1pp.pNt_xml)
        comm.Parameters.Add("@nt_orca", nota1pp.pNt_orca)
        comm.Parameters.Add("@nt_mapa", nota1pp.pNt_Mapa)
        comm.Parameters.Add("@nt_indoper", nota1pp.pNt_indOper)
        comm.Parameters.Add("@nt_inddest", nota1pp.pNt_indDest)
        comm.Parameters.Add("@nt_refchave", nota1pp.pNt_refChave)
        comm.Parameters.Add("@nt_refcnpj", nota1pp.pNt_refCnpj)
        comm.Parameters.Add("@nt_refserie", nota1pp.pNt_refSerie)
        comm.Parameters.Add("@nt_refnumero", nota1pp.pNt_refNumero)
        comm.Parameters.Add("@nt_refuf", nota1pp.pNt_refUf)
        comm.Parameters.Add("@nt_indpres", nota1pp.pNt_indPres)
        comm.Parameters.Add("@nt_finnfe", nota1pp.pNt_finNFe)


        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altSeqCCeNota1pp(ByVal numeroNota1pp As String, ByVal seqCCe As Integer, ByVal esquemaLoja As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & esquemaLoja & ".nota1pp SET ")
        sqlbuild.Append("nt_seqcce = @nt_seqcce WHERE nt_nume = @nt_nume")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_seqcce", seqCCe) : comm.Parameters.Add("@nt_nume", numeroNota1pp)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub altTipoNt_Nota1pp(ByVal numeroNota1pp As String, ByVal tipo As String, ByVal esquemaLoja As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & esquemaLoja & ".nota1pp SET ")
        sqlbuild.Append("tipo_nt = @tipo_nt WHERE nt_nume = @nt_nume")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@tipo_nt", tipo) : comm.Parameters.Add("@nt_nume", numeroNota1pp)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub altChaveNota1pp(ByVal numeroNota1pp As String, ByVal chaveNFe As String, ByVal esquemaLoja As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & esquemaLoja & ".nota1pp SET ")
        sqlbuild.Append("nt_chave = @nt_chave WHERE nt_nume = @nt_nume")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_chave", chaveNFe) : comm.Parameters.Add("@nt_nume", numeroNota1pp)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub altXmlNota1pp(ByVal numeroNota1pp As String, ByVal xml As StringBuilder, ByVal esquemaLoja As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & esquemaLoja & ".nota1pp SET ")
        sqlbuild.Append("nt_xml = @nt_xml WHERE nt_nume = @nt_nume")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_xml", xml.ToString) : comm.Parameters.Add("@nt_nume", numeroNota1pp)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub altLoteNota1pp(ByVal numeroNota1pp As String, ByVal lote As String, ByVal esquemaLoja As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & esquemaLoja & ".nota1pp SET ")
        sqlbuild.Append("nt_lote = @nt_lote WHERE nt_nume = @nt_nume")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_lote", lote) : comm.Parameters.Add("@nt_nume", numeroNota1pp)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub altNota1ppIdLote(ByVal numeroNota1pp As String, ByVal idLote As Int64, ByVal esquemaLoja As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & esquemaLoja & ".nota1pp SET ")
        sqlbuild.Append("nt_idlote = @nt_idlote WHERE nt_nume = @nt_nume")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_idlote", idLote) : comm.Parameters.Add("@nt_nume", numeroNota1pp)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub altNota1ppLoteErro(ByVal numeroNota1pp As String, ByVal LoteErro As Boolean, ByVal esquemaLoja As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & esquemaLoja & ".nota1pp SET ")
        sqlbuild.Append("nt_loteerro = @nt_loteerro WHERE nt_nume = @nt_nume")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_loteerro", LoteErro) : comm.Parameters.Add("@nt_nume", numeroNota1pp)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub altNota1ppStrLote(ByVal numeroNota1pp As String, ByVal strLote As String, ByVal esquemaLoja As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & esquemaLoja & ".nota1pp SET ")
        sqlbuild.Append("t_lotestrerro = @t_lotestrerro WHERE nt_nume = @nt_nume")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@t_lotestrerro", strLote) : comm.Parameters.Add("@nt_nume", numeroNota1pp)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub altHrwebNota1pp(ByVal numeroNota1pp As String, ByVal hrweb As String, ByVal esquemaLoja As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & esquemaLoja & ".nota1pp SET ")
        sqlbuild.Append("nt_hrweb = @nt_hrweb WHERE nt_nume = @nt_nume")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_hrweb", hrweb) : comm.Parameters.Add("@nt_nume", numeroNota1pp)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub altWebrecNota1pp(ByVal numeroNota1pp As String, ByVal webrec As String, ByVal esquemaLoja As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & esquemaLoja & ".nota1pp SET ")
        sqlbuild.Append("nt_webrec = @nt_webrec WHERE nt_nume = @nt_nume")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_webrec", webrec) : comm.Parameters.Add("@nt_nume", numeroNota1pp)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub altProtoNota1pp(ByVal numeroNota1pp As String, ByVal proto As String, ByVal esquemaLoja As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & esquemaLoja & ".nota1pp SET ")
        sqlbuild.Append("nt_proto = @nt_proto WHERE nt_nume = @nt_nume")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_proto", proto) : comm.Parameters.Add("@nt_nume", numeroNota1pp)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub altStatusNota1pp(ByVal numeroNota1pp As String, ByVal status As String, ByVal esquemaLoja As String, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & esquemaLoja & ".nota1pp SET ")
        sqlbuild.Append("nt_status = @nt_status WHERE nt_nume = @nt_nume")

        comm = New NpgsqlCommand(sqlbuild.ToString, oConn)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_status", status) : comm.Parameters.Add("@nt_nume", numeroNota1pp)

        comm.ExecuteNonQuery()

        oConn.Close()
        comm = Nothing : sqlbuild = Nothing : oConn = Nothing
    End Sub

    Public Sub incNota2cc(ByVal nota2cc As Cl_Nota2cc, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".nota2cc(")
        sqlbuild.Append("nc_tipo, nc_numer, nc_codpr, nc_produt, nc_cf, nc_cst, nc_und, nc_qtde, ")
        sqlbuild.Append("nc_prunit, nc_prtot, nc_alqicm, nc_alqipi, nc_vlipi, nc_vlicm, nc_dtemis, ")
        sqlbuild.Append("nc_cdport, nc_unipi, nc_vlsubs, nc_cfop, nc_bcalc, nc_basesub, nc_frete, ")
        sqlbuild.Append("nc_segur, nc_vldesc, nc_isento, nc_ntid, nc_csosn, nc_vltrib, nc_alqsub, ")
        sqlbuild.Append("nc_ncm, nc_indtot, nc_desc, nc_descpac, nc_voutro, nc_seqitem, nc_reduz, nc_alqreduz, ")
        sqlbuild.Append("nc_cstpis, nc_cstcofins, nc_cstipi) ")
        sqlbuild.Append("VALUES (@nc_tipo, @nc_numer, @nc_codpr, @nc_produt, @nc_cf, @nc_cst, ")
        sqlbuild.Append("@nc_und, @nc_qtde, @nc_prunit, @nc_prtot, @nc_alqicm, @nc_alqipi, ")
        sqlbuild.Append("@nc_vlipi, @nc_vlicm, @nc_dtemis, @nc_cdport, @nc_unipi, @nc_vlsubs, ")
        sqlbuild.Append("@nc_cfop, @nc_bcalc, @nc_basesub, @nc_frete, @nc_segur, @nc_vldesc, ")
        sqlbuild.Append("@nc_isento, @nc_ntid, @nc_csosn, @nc_vltrib, @nc_alqsub, @nc_ncm, @nc_indtot, ")
        sqlbuild.Append("@nc_desc, @nc_descpac, @nc_voutro, @nc_seqitem, @nc_reduz, @nc_alqreduz, ")
        sqlbuild.Append("@nc_cstpis, @nc_cstcofins, @nc_cstipi) ")


        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@nc_tipo", nota2cc.pNc_tipo)
        comm.Parameters.Add("@nc_numer", nota2cc.pNc_numer)
        comm.Parameters.Add("@nc_codpr", nota2cc.pNc_codpr)
        comm.Parameters.Add("@nc_produt", nota2cc.pNc_produt)
        comm.Parameters.Add("@nc_cf", nota2cc.pNc_cf)
        comm.Parameters.Add("@nc_cst", nota2cc.pNc_cst)
        comm.Parameters.Add("@nc_und", nota2cc.pNc_und)
        comm.Parameters.Add("@nc_qtde", nota2cc.pNc_qtde)
        comm.Parameters.Add("@nc_prunit", nota2cc.pNc_prunit)
        comm.Parameters.Add("@nc_prtot", nota2cc.pNc_prtot)
        comm.Parameters.Add("@nc_alqicm", nota2cc.pNc_alqicm)
        comm.Parameters.Add("@nc_alqipi", nota2cc.pNc_alqipi)
        comm.Parameters.Add("@nc_vlipi", nota2cc.pNc_vlipi)
        comm.Parameters.Add("@nc_vlicm", nota2cc.pNc_vlicm)
        Try
            comm.Parameters.Add("@nc_dtemis", Convert.ChangeType(nota2cc.pNc_dtemis, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@nc_dtemis", NpgsqlTypes.NpgsqlDbType.Date)
        End Try
        comm.Parameters.Add("@nc_cdport", nota2cc.pNc_cdport)
        comm.Parameters.Add("@nc_unipi", nota2cc.pNc_unipi)
        comm.Parameters.Add("@nc_vlsubs", nota2cc.pNc_vlsubs)
        comm.Parameters.Add("@nc_cfop", nota2cc.pNc_cfop)
        comm.Parameters.Add("@nc_bcalc", nota2cc.pNc_bcalc)
        comm.Parameters.Add("@nc_basesub", nota2cc.pNc_basesub)
        comm.Parameters.Add("@nc_frete", nota2cc.pNc_frete)
        comm.Parameters.Add("@nc_segur", nota2cc.pNc_segur)
        comm.Parameters.Add("@nc_vldesc", nota2cc.pNc_vldesc)
        comm.Parameters.Add("@nc_isento", nota2cc.pNc_isento)
        comm.Parameters.Add("@nc_ntid", nota2cc.pNc_ntid)
        comm.Parameters.Add("@nc_csosn", nota2cc.pNc_csosn)
        comm.Parameters.Add("@nc_vltrib", nota2cc.pNc_vltrib)
        comm.Parameters.Add("@nc_alqsub", nota2cc.pNc_alqsub)
        comm.Parameters.Add("@nc_ncm", nota2cc.pNc_ncm)
        comm.Parameters.Add("@nc_indtot", nota2cc.pNc_indtot)
        comm.Parameters.Add("@nc_desc", nota2cc.pNc_desc)
        comm.Parameters.Add("@nc_descpac", nota2cc.pNc_descpac)
        comm.Parameters.Add("@nc_voutro", nota2cc.pNc_voutro)
        comm.Parameters.Add("@nc_seqitem", nota2cc.pNc_seqitem)
        comm.Parameters.Add("@nc_reduz", nota2cc.pNc_reduz)
        comm.Parameters.Add("@nc_alqreduz", nota2cc.pNc_alqreduz)
        comm.Parameters.Add("@nc_cstpis", nota2cc.pNc_cstpis)
        comm.Parameters.Add("@nc_cstcofins", nota2cc.pNc_cstcofins)
        comm.Parameters.Add("@nc_cstipi", nota2cc.pNc_cstipi)


        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incNota2cc(ByVal nota2cc As Cl_Nota2cc, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".nota2cc(")
        sqlbuild.Append("nc_tipo, nc_numer, nc_codpr, nc_produt, nc_cf, nc_cst, nc_und, nc_qtde, ")
        sqlbuild.Append("nc_prunit, nc_prtot, nc_alqicm, nc_alqipi, nc_vlipi, nc_vlicm, nc_dtemis, ")
        sqlbuild.Append("nc_cdport, nc_unipi, nc_vlsubs, nc_cfop, nc_bcalc, nc_basesub, nc_frete, ")
        sqlbuild.Append("nc_segur, nc_vldesc, nc_isento, nc_ntid, nc_csosn, nc_vltrib, nc_alqsub, ")
        sqlbuild.Append("nc_ncm, nc_indtot, nc_desc, nc_descpac, nc_voutro, nc_seqitem, nc_reduz, nc_alqreduz, ")
        sqlbuild.Append("nc_cstpis, nc_cstcofins, nc_cstipi) ")
        sqlbuild.Append("VALUES (@nc_tipo, @nc_numer, @nc_codpr, @nc_produt, @nc_cf, @nc_cst, ")
        sqlbuild.Append("@nc_und, @nc_qtde, @nc_prunit, @nc_prtot, @nc_alqicm, @nc_alqipi, ")
        sqlbuild.Append("@nc_vlipi, @nc_vlicm, @nc_dtemis, @nc_cdport, @nc_unipi, @nc_vlsubs, ")
        sqlbuild.Append("@nc_cfop, @nc_bcalc, @nc_basesub, @nc_frete, @nc_segur, @nc_vldesc, ")
        sqlbuild.Append("@nc_isento, @nc_ntid, @nc_csosn, @nc_vltrib, @nc_alqsub, @nc_ncm, @nc_indtot, ")
        sqlbuild.Append("@nc_desc, @nc_descpac, @nc_voutro, @nc_seqitem, @nc_reduz, @nc_alqreduz, ")
        sqlbuild.Append("@nc_cstpis, @nc_cstcofins, @nc_cstipi) ")


        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@nc_tipo", nota2cc.pNc_tipo)
        comm.Parameters.Add("@nc_numer", nota2cc.pNc_numer)
        comm.Parameters.Add("@nc_codpr", nota2cc.pNc_codpr)
        comm.Parameters.Add("@nc_produt", nota2cc.pNc_produt)
        comm.Parameters.Add("@nc_cf", nota2cc.pNc_cf)
        comm.Parameters.Add("@nc_cst", nota2cc.pNc_cst)
        comm.Parameters.Add("@nc_und", nota2cc.pNc_und)
        comm.Parameters.Add("@nc_qtde", nota2cc.pNc_qtde)
        comm.Parameters.Add("@nc_prunit", nota2cc.pNc_prunit)
        comm.Parameters.Add("@nc_prtot", nota2cc.pNc_prtot)
        comm.Parameters.Add("@nc_alqicm", nota2cc.pNc_alqicm)
        comm.Parameters.Add("@nc_alqipi", nota2cc.pNc_alqipi)
        comm.Parameters.Add("@nc_vlipi", nota2cc.pNc_vlipi)
        comm.Parameters.Add("@nc_vlicm", nota2cc.pNc_vlicm)
        Try
            comm.Parameters.Add("@nc_dtemis", Convert.ChangeType(nota2cc.pNc_dtemis, GetType(Date)))
        Catch ex As Exception
            comm.Parameters.Add("@nc_dtemis", NpgsqlTypes.NpgsqlDbType.Date)
        End Try
        comm.Parameters.Add("@nc_cdport", nota2cc.pNc_cdport)
        comm.Parameters.Add("@nc_unipi", nota2cc.pNc_unipi)
        comm.Parameters.Add("@nc_vlsubs", nota2cc.pNc_vlsubs)
        comm.Parameters.Add("@nc_cfop", nota2cc.pNc_cfop)
        comm.Parameters.Add("@nc_bcalc", nota2cc.pNc_bcalc)
        comm.Parameters.Add("@nc_basesub", nota2cc.pNc_basesub)
        comm.Parameters.Add("@nc_frete", nota2cc.pNc_frete)
        comm.Parameters.Add("@nc_segur", nota2cc.pNc_segur)
        comm.Parameters.Add("@nc_vldesc", nota2cc.pNc_vldesc)
        comm.Parameters.Add("@nc_isento", nota2cc.pNc_isento)
        comm.Parameters.Add("@nc_ntid", nota2cc.pNc_ntid)
        comm.Parameters.Add("@nc_csosn", nota2cc.pNc_csosn)
        comm.Parameters.Add("@nc_vltrib", nota2cc.pNc_vltrib)
        comm.Parameters.Add("@nc_alqsub", nota2cc.pNc_alqsub)
        comm.Parameters.Add("@nc_ncm", nota2cc.pNc_ncm)
        comm.Parameters.Add("@nc_indtot", nota2cc.pNc_indtot)
        comm.Parameters.Add("@nc_desc", nota2cc.pNc_desc)
        comm.Parameters.Add("@nc_descpac", nota2cc.pNc_descpac)
        comm.Parameters.Add("@nc_voutro", nota2cc.pNc_voutro)
        comm.Parameters.Add("@nc_seqitem", nota2cc.pNc_seqitem)
        comm.Parameters.Add("@nc_reduz", nota2cc.pNc_reduz)
        comm.Parameters.Add("@nc_alqreduz", nota2cc.pNc_alqreduz)
        comm.Parameters.Add("@nc_cstpis", nota2cc.pNc_cstpis)
        comm.Parameters.Add("@nc_cstcofins", nota2cc.pNc_cstcofins)
        comm.Parameters.Add("@nc_cstipi", nota2cc.pNc_cstipi)


        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incNota4dd(ByVal nota4dd As Cl_Nota4dd, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".nota4dd(")
        sqlbuild.Append("n4_tipo, n4_numer, n4_tprod, n4_aliss, n4_vliss, n4_vlser, n4_basec, ")
        sqlbuild.Append("n4_icms, n4_bsub, n4_icsub, n4_tpro2, n4_frete, n4_segu, n4_outros, ")
        sqlbuild.Append("n4_ipi, n4_tgeral, n4_pgto, n4_outras, n4_isento, n4_pis, n4_cofins, ")
        sqlbuild.Append("n4_desc, n4_vlpis, n4_vlcofins, n4_idn1pp, n4_peso, n4_totalimp, n4_totaltrib, n4_icmsdeson) ")
        sqlbuild.Append("VALUES (@n4_tipo, @n4_numer, @n4_tprod, @n4_aliss, @n4_vliss, @n4_vlser, @n4_basec, ")
        sqlbuild.Append("@n4_icms, @n4_bsub, @n4_icsub, @n4_tpro2, @n4_frete, @n4_segu, @n4_outros, ")
        sqlbuild.Append("@n4_ipi, @n4_tgeral, @n4_pgto, @n4_outras, @n4_isento, @n4_pis, @n4_cofins, ")
        sqlbuild.Append("@n4_desc, @n4_vlpis, @n4_vlcofins, @n4_idn1pp, @n4_peso, @n4_totalimp, @n4_totaltrib, @n4_icmsdeson) ")


        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_tipo", nota4dd.pN4_tipo)
        comm.Parameters.Add("@n4_numer", nota4dd.pN4_numer)
        comm.Parameters.Add("@n4_tprod", nota4dd.pN4_tprod)
        comm.Parameters.Add("@n4_aliss", nota4dd.pN4_aliss)
        comm.Parameters.Add("@n4_vliss", nota4dd.pN4_vliss)
        comm.Parameters.Add("@n4_vlser", nota4dd.pN4_vlser)
        comm.Parameters.Add("@n4_basec", nota4dd.pN4_basec)
        comm.Parameters.Add("@n4_icms", nota4dd.pN4_icms)
        comm.Parameters.Add("@n4_bsub", nota4dd.pN4_bsub)
        comm.Parameters.Add("@n4_icsub", nota4dd.pN4_icsub)
        comm.Parameters.Add("@n4_tpro2", nota4dd.pN4_tpro2)
        comm.Parameters.Add("@n4_frete", nota4dd.pN4_frete)
        comm.Parameters.Add("@n4_segu", nota4dd.pN4_segu)
        comm.Parameters.Add("@n4_outros", nota4dd.pN4_outros)
        comm.Parameters.Add("@n4_ipi", nota4dd.pN4_ipi)
        comm.Parameters.Add("@n4_tgeral", nota4dd.pN4_tgeral)
        comm.Parameters.Add("@n4_pgto", nota4dd.pN4_pgto)
        comm.Parameters.Add("@n4_outras", nota4dd.pN4_outras)
        comm.Parameters.Add("@n4_isento", nota4dd.pN4_isento)
        comm.Parameters.Add("@n4_pis", nota4dd.pN4_pis)
        comm.Parameters.Add("@n4_cofins", nota4dd.pN4_cofins)
        comm.Parameters.Add("@n4_desc", nota4dd.pN4_desc)
        comm.Parameters.Add("@n4_vlpis", nota4dd.pN4_vlpis)
        comm.Parameters.Add("@n4_vlcofins", nota4dd.pN4_vlcofins)
        comm.Parameters.Add("@n4_idn1pp", nota4dd.pN4_idn1pp)
        comm.Parameters.Add("@n4_peso", nota4dd.pN4_peso)
        comm.Parameters.Add("@n4_totalimp", nota4dd.pN4_totalimp)
        comm.Parameters.Add("@n4_totaltrib", nota4dd.pN4_totaltrib)
        comm.Parameters.Add("@n4_icmsdeson", nota4dd.pN4_icmsdeson)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incNota4dd(ByVal nota4dd As Cl_Nota4dd, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".nota4dd(")
        sqlbuild.Append("n4_tipo, n4_numer, n4_tprod, n4_aliss, n4_vliss, n4_vlser, n4_basec, ")
        sqlbuild.Append("n4_icms, n4_bsub, n4_icsub, n4_tpro2, n4_frete, n4_segu, n4_outros, ")
        sqlbuild.Append("n4_ipi, n4_tgeral, n4_pgto, n4_outras, n4_isento, n4_pis, n4_cofins, ")
        sqlbuild.Append("n4_desc, n4_vlpis, n4_vlcofins, n4_idn1pp, n4_peso, n4_totalimp, n4_totaltrib, n4_icmsdeson) ")
        sqlbuild.Append("VALUES (@n4_tipo, @n4_numer, @n4_tprod, @n4_aliss, @n4_vliss, @n4_vlser, @n4_basec, ")
        sqlbuild.Append("@n4_icms, @n4_bsub, @n4_icsub, @n4_tpro2, @n4_frete, @n4_segu, @n4_outros, ")
        sqlbuild.Append("@n4_ipi, @n4_tgeral, @n4_pgto, @n4_outras, @n4_isento, @n4_pis, @n4_cofins, ")
        sqlbuild.Append("@n4_desc, @n4_vlpis, @n4_vlcofins, @n4_idn1pp, @n4_peso, @n4_totalimp, @n4_totaltrib, @n4_icmsdeson) ")


        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_tipo", nota4dd.pN4_tipo)
        comm.Parameters.Add("@n4_numer", nota4dd.pN4_numer)
        comm.Parameters.Add("@n4_tprod", nota4dd.pN4_tprod)
        comm.Parameters.Add("@n4_aliss", nota4dd.pN4_aliss)
        comm.Parameters.Add("@n4_vliss", nota4dd.pN4_vliss)
        comm.Parameters.Add("@n4_vlser", nota4dd.pN4_vlser)
        comm.Parameters.Add("@n4_basec", nota4dd.pN4_basec)
        comm.Parameters.Add("@n4_icms", nota4dd.pN4_icms)
        comm.Parameters.Add("@n4_bsub", nota4dd.pN4_bsub)
        comm.Parameters.Add("@n4_icsub", nota4dd.pN4_icsub)
        comm.Parameters.Add("@n4_tpro2", nota4dd.pN4_tpro2)
        comm.Parameters.Add("@n4_frete", nota4dd.pN4_frete)
        comm.Parameters.Add("@n4_segu", nota4dd.pN4_segu)
        comm.Parameters.Add("@n4_outros", nota4dd.pN4_outros)
        comm.Parameters.Add("@n4_ipi", nota4dd.pN4_ipi)
        comm.Parameters.Add("@n4_tgeral", nota4dd.pN4_tgeral)
        comm.Parameters.Add("@n4_pgto", nota4dd.pN4_pgto)
        comm.Parameters.Add("@n4_outras", nota4dd.pN4_outras)
        comm.Parameters.Add("@n4_isento", nota4dd.pN4_isento)
        comm.Parameters.Add("@n4_pis", nota4dd.pN4_pis)
        comm.Parameters.Add("@n4_cofins", nota4dd.pN4_cofins)
        comm.Parameters.Add("@n4_desc", nota4dd.pN4_desc)
        comm.Parameters.Add("@n4_vlpis", nota4dd.pN4_vlpis)
        comm.Parameters.Add("@n4_vlcofins", nota4dd.pN4_vlcofins)
        comm.Parameters.Add("@n4_idn1pp", nota4dd.pN4_idn1pp)
        comm.Parameters.Add("@n4_peso", nota4dd.pN4_peso)
        comm.Parameters.Add("@n4_totalimp", nota4dd.pN4_totalimp)
        comm.Parameters.Add("@n4_totaltrib", nota4dd.pN4_totaltrib)
        comm.Parameters.Add("@n4_icmsdeson", nota4dd.pN4_icmsdeson)


        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incNota5tt(ByVal nota5tt As Cl_Nota5tt, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".nota5tt(")
        sqlbuild.Append("t_tipo, t_numer, t_codp, t_placa, t_uf, t_tpfret, t_qtde, t_espec, ")
        sqlbuild.Append("t_marca, t_pesob, t_pesol, t_antt, t_id1pp) ")
        sqlbuild.Append("VALUES (@t_tipo, @t_numer, @t_codp, @t_placa, @t_uf, @t_tpfret, @t_qtde, @t_espec, ")
        sqlbuild.Append("@t_marca, @t_pesob, @t_pesol, @t_antt, @t_id1pp) ")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@t_tipo", nota5tt.pT_tipo)
        comm.Parameters.Add("@t_numer", nota5tt.pT_numer)
        comm.Parameters.Add("@t_codp", nota5tt.pT_codp)
        comm.Parameters.Add("@t_placa", nota5tt.pT_placa)
        comm.Parameters.Add("@t_uf", nota5tt.pT_uf)
        comm.Parameters.Add("@t_tpfret", nota5tt.pT_tpfret)
        comm.Parameters.Add("@t_qtde", nota5tt.pT_qtde)
        comm.Parameters.Add("@t_espec", nota5tt.pT_espec)
        comm.Parameters.Add("@t_marca", nota5tt.pT_marca)
        comm.Parameters.Add("@t_pesob", nota5tt.pT_pesob)
        comm.Parameters.Add("@t_pesol", nota5tt.pT_pesol)
        comm.Parameters.Add("@t_antt", nota5tt.pT_antt)
        comm.Parameters.Add("@t_id1pp", nota5tt.pT_id1pp)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incNota5tt(ByVal nota5tt As Cl_Nota5tt, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".nota5tt(")
        sqlbuild.Append("t_tipo, t_numer, t_codp, t_placa, t_uf, t_tpfret, t_qtde, t_espec, ")
        sqlbuild.Append("t_marca, t_pesob, t_pesol, t_antt, t_id1pp) ")
        sqlbuild.Append("VALUES (@t_tipo, @t_numer, @t_codp, @t_placa, @t_uf, @t_tpfret, @t_qtde, @t_espec, ")
        sqlbuild.Append("@t_marca, @t_pesob, @t_pesol, @t_antt, @t_id1pp) ")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@t_tipo", nota5tt.pT_tipo)
        comm.Parameters.Add("@t_numer", nota5tt.pT_numer)
        comm.Parameters.Add("@t_codp", nota5tt.pT_codp)
        comm.Parameters.Add("@t_placa", nota5tt.pT_placa)
        comm.Parameters.Add("@t_uf", nota5tt.pT_uf)
        comm.Parameters.Add("@t_tpfret", nota5tt.pT_tpfret)
        comm.Parameters.Add("@t_qtde", nota5tt.pT_qtde)
        comm.Parameters.Add("@t_espec", nota5tt.pT_espec)
        comm.Parameters.Add("@t_marca", nota5tt.pT_marca)
        comm.Parameters.Add("@t_pesob", nota5tt.pT_pesob)
        comm.Parameters.Add("@t_pesol", nota5tt.pT_pesol)
        comm.Parameters.Add("@t_antt", nota5tt.pT_antt)
        comm.Parameters.Add("@t_id1pp", nota5tt.pT_id1pp)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incNota6hh(ByVal nota6hh As Cl_Nota6hh, ByVal conexao As NpgsqlConnection, _
                          ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".nota6hh(")
        sqlbuild.Append("c_tipo, c_numer, c_compl1, c_compl2, c_compl3, c_compl4, c_compl5, ")
        sqlbuild.Append("c_compl6, c_compl7, c_compl8, c_compl9, c_idn1pp) ")
        sqlbuild.Append("VALUES (@c_tipo, @c_numer, @c_compl1, @c_compl2, @c_compl3, @c_compl4, @c_compl5, ")
        sqlbuild.Append("@c_compl6, @c_compl7, @c_compl8, @c_compl9, @c_idn1pp) ")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@c_tipo", nota6hh.pC_tipo)
        comm.Parameters.Add("@c_numer", nota6hh.pC_numer)
        comm.Parameters.Add("@c_compl1", nota6hh.pC_compl1)
        comm.Parameters.Add("@c_compl2", nota6hh.pC_compl2)
        comm.Parameters.Add("@c_compl3", nota6hh.pC_compl3)
        comm.Parameters.Add("@c_compl4", nota6hh.pC_compl4)
        comm.Parameters.Add("@c_compl5", nota6hh.pC_compl5)
        comm.Parameters.Add("@c_compl6", nota6hh.pC_compl6)
        comm.Parameters.Add("@c_compl7", nota6hh.pC_compl7)
        comm.Parameters.Add("@c_compl8", nota6hh.pC_compl8)
        comm.Parameters.Add("@c_compl9", nota6hh.pC_compl9)
        comm.Parameters.Add("@c_idn1pp", nota6hh.pC_idn1pp)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incNota6hh(ByVal nota6hh As Cl_Nota6hh, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".nota6hh(")
        sqlbuild.Append("c_tipo, c_numer, c_compl1, c_compl2, c_compl3, c_compl4, c_compl5, ")
        sqlbuild.Append("c_compl6, c_compl7, c_compl8, c_compl9, c_idn1pp) ")
        sqlbuild.Append("VALUES (@c_tipo, @c_numer, @c_compl1, @c_compl2, @c_compl3, @c_compl4, @c_compl5, ")
        sqlbuild.Append("@c_compl6, @c_compl7, @c_compl8, @c_compl9, @c_idn1pp) ")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        ' Prepara Paramentros
        comm.Parameters.Add("@c_tipo", nota6hh.pC_tipo)
        comm.Parameters.Add("@c_numer", nota6hh.pC_numer)
        comm.Parameters.Add("@c_compl1", nota6hh.pC_compl1)
        comm.Parameters.Add("@c_compl2", nota6hh.pC_compl2)
        comm.Parameters.Add("@c_compl3", nota6hh.pC_compl3)
        comm.Parameters.Add("@c_compl4", nota6hh.pC_compl4)
        comm.Parameters.Add("@c_compl5", nota6hh.pC_compl5)
        comm.Parameters.Add("@c_compl6", nota6hh.pC_compl6)
        comm.Parameters.Add("@c_compl7", nota6hh.pC_compl7)
        comm.Parameters.Add("@c_compl8", nota6hh.pC_compl8)
        comm.Parameters.Add("@c_compl9", nota6hh.pC_compl9)
        comm.Parameters.Add("@c_idn1pp", nota6hh.pC_idn1pp)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function trazIdNota1pp(ByVal conexao As NpgsqlConnection, ByVal numNFe As String) As Int32
        Dim id As Int32 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT nt_id FROM " & MdlEmpresaUsu._esqEstab & ".nota1pp WHERE nt_nume = @nt_nume"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@nt_nume", numNFe)
        dr = comm.ExecuteReader
        While dr.Read

            id = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return id
    End Function

    Public Sub delNota1pp(ByVal nota1pp As Cl_Nota1pp, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".nota1pp WHERE nt_nume = @nt_nume ")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        comm.Parameters.Add("@nt_nume", nota1pp.pNt_nume)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delNota2cc(ByVal nota2cc As Cl_Nota2cc, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".nota2cc WHERE nc_numer = @nc_numer ")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        comm.Parameters.Add("@nc_numer", nota2cc.pNc_numer)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delNota4dd(ByVal nota4dd As Cl_Nota4dd, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".nota4dd WHERE n4_numer = @n4_numer ")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        comm.Parameters.Add("@n4_numer", nota4dd.pN4_numer)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delNota5tt(ByVal nota5tt As Cl_Nota5tt, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".nota5tt WHERE t_numer = @t_numer ")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        comm.Parameters.Add("@t_numer", nota5tt.pT_numer)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delNota6hh(ByVal nota6hh As Cl_Nota6hh, ByVal geno001 As Cl_Geno, _
                          ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".nota6hh WHERE c_numer = @c_numer ")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        comm.Transaction = transacao
        comm.Parameters.Add("@c_numer", nota6hh.pC_numer)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
    End Sub

    'INICIO do Tratamento dos Resumo dos Itens da NFe de Saídas....
    Public Sub IncResSaidaALQ(ByVal resn4dd01 As Cl_ResN4dd01, ByVal geno001 As Cl_Geno, _
                                  ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".resn4dd01(")
        sqlbuild.Append("r4_id, r4_idn1pp, r4_numero, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, ")
        sqlbuild.Append("r4_toutrasdesp, r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral) ")
        sqlbuild.Append("VALUES (DEFAULT, @r4_idn1pp, @r4_numero, @r4_aliq, @r4_tprod, @r4_tdesc, @r4_tfrete, ")
        sqlbuild.Append("@r4_tseguro, @r4_toutrasdesp, @r4_bcalc, @r4_icms, @r4_isento, @r4_outras, @r4_ipi, ")
        sqlbuild.Append("@r4_tgeral);")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_idn1pp", resn4dd01.r4_idn1pp)
        comm.Parameters.Add("@r4_numero", resn4dd01.r4_numero)
        comm.Parameters.Add("@r4_aliq", resn4dd01.r4_aliq)
        comm.Parameters.Add("@r4_tprod", resn4dd01.r4_tprod)
        comm.Parameters.Add("@r4_bcalc", resn4dd01.r4_bcalc)
        comm.Parameters.Add("@r4_icms", resn4dd01.r4_icms)
        comm.Parameters.Add("@r4_isento", resn4dd01.r4_isento)
        comm.Parameters.Add("@r4_outras", resn4dd01.r4_outras)
        comm.Parameters.Add("@r4_ipi", resn4dd01.r4_ipi)
        comm.Parameters.Add("@r4_tdesc", resn4dd01.r4_tdesc)
        comm.Parameters.Add("@r4_tfrete", resn4dd01.r4_tfrete)
        comm.Parameters.Add("@r4_tseguro", resn4dd01.r4_tseguro)
        comm.Parameters.Add("@r4_toutrasdesp", resn4dd01.r4_toutrasdesp)
        comm.Parameters.Add("@r4_tgeral", resn4dd01.r4_tgeral)
        'total geral...
        '((resn4dd01.totProd + resn4dd01.vlIsento + vlOutras + vlIPI + _
        '                                   totFrete + totSeguro + totOutrasDesp) - totDesc)


        comm.Transaction = transaction
        comm.ExecuteNonQuery()
        
        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub delResSaidaALQ(ByVal resn4dd01 As Cl_ResN4dd01, ByVal geno001 As Cl_Geno, _
                                  ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".resn4dd01 WHERE r4_numero=@r4_numero")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_numero", resn4dd01.r4_numero)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub IncResSaidaCfopALQ(ByVal resn4dd02 As Cl_ResN4dd02, ByVal geno001 As Cl_Geno, _
                                 ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".resn4dd02(")
        sqlbuild.Append("r4_id, r4_idn1pp, r4_numero, r4_cfop, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, ")
        sqlbuild.Append("r4_toutrasdesp, r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral) ")
        sqlbuild.Append("VALUES (DEFAULT, @r4_idn1pp, @r4_numero, @r4_cfop, @r4_aliq, @r4_tprod, @r4_tdesc, @r4_tfrete, ")
        sqlbuild.Append("@r4_tseguro, @r4_toutrasdesp, @r4_bcalc, @r4_icms, @r4_isento, @r4_outras, @r4_ipi, ")
        sqlbuild.Append("@r4_tgeral);")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_idn1pp", resn4dd02.r4_idn1pp)
        comm.Parameters.Add("@r4_numero", resn4dd02.r4_numero)
        comm.Parameters.Add("@r4_cfop", resn4dd02.r4_cfop)
        comm.Parameters.Add("@r4_aliq", resn4dd02.r4_aliq)
        comm.Parameters.Add("@r4_tprod", resn4dd02.r4_tprod)
        comm.Parameters.Add("@r4_bcalc", resn4dd02.r4_bcalc)
        comm.Parameters.Add("@r4_icms", resn4dd02.r4_icms)
        comm.Parameters.Add("@r4_isento", resn4dd02.r4_isento)
        comm.Parameters.Add("@r4_outras", resn4dd02.r4_outras)
        comm.Parameters.Add("@r4_ipi", resn4dd02.r4_ipi)
        comm.Parameters.Add("@r4_tdesc", resn4dd02.r4_tdesc)
        comm.Parameters.Add("@r4_tfrete", resn4dd02.r4_tfrete)
        comm.Parameters.Add("@r4_tseguro", resn4dd02.r4_tseguro)
        comm.Parameters.Add("@r4_toutrasdesp", resn4dd02.r4_toutrasdesp)
        comm.Parameters.Add("@r4_tgeral", resn4dd02.r4_tgeral)
        'total geral...
        '((resn4dd01.totProd + resn4dd01.vlIsento + vlOutras + vlIPI + _
        '                                   totFrete + totSeguro + totOutrasDesp) - totDesc)


        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub delResSaidaCfopALQ(ByVal resn4dd02 As Cl_ResN4dd02, ByVal geno001 As Cl_Geno, _
                                  ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".resn4dd02 WHERE r4_numero=@r4_numero")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_numero", resn4dd02.r4_numero)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub IncResSaidaCstCfopALQ(ByVal resn4dd03 As Cl_ResN4dd03, ByVal geno001 As Cl_Geno, _
                                 ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & geno001.pEsquemaestab & ".resn4dd03(")
        sqlbuild.Append("r4_id, r4_idn1pp, r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, ")
        sqlbuild.Append("r4_toutrasdesp, r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral) ")
        sqlbuild.Append("VALUES (DEFAULT, @r4_idn1pp, @r4_numero, @r4_cfop, @r4_cst, @r4_aliq, @r4_tprod, @r4_tdesc, @r4_tfrete, ")
        sqlbuild.Append("@r4_tseguro, @r4_toutrasdesp, @r4_bcalc, @r4_icms, @r4_isento, @r4_outras, @r4_ipi, ")
        sqlbuild.Append("@r4_tgeral);")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_idn1pp", resn4dd03.r4_idn1pp)
        comm.Parameters.Add("@r4_numero", resn4dd03.r4_numero)
        comm.Parameters.Add("@r4_cfop", resn4dd03.r4_cfop)
        comm.Parameters.Add("@r4_cst", resn4dd03.r4_cst)
        comm.Parameters.Add("@r4_aliq", resn4dd03.r4_aliq)
        comm.Parameters.Add("@r4_tprod", resn4dd03.r4_tprod)
        comm.Parameters.Add("@r4_bcalc", resn4dd03.r4_bcalc)
        comm.Parameters.Add("@r4_icms", resn4dd03.r4_icms)
        comm.Parameters.Add("@r4_isento", resn4dd03.r4_isento)
        comm.Parameters.Add("@r4_outras", resn4dd03.r4_outras)
        comm.Parameters.Add("@r4_ipi", resn4dd03.r4_ipi)
        comm.Parameters.Add("@r4_tdesc", resn4dd03.r4_tdesc)
        comm.Parameters.Add("@r4_tfrete", resn4dd03.r4_tfrete)
        comm.Parameters.Add("@r4_tseguro", resn4dd03.r4_tseguro)
        comm.Parameters.Add("@r4_toutrasdesp", resn4dd03.r4_toutrasdesp)
        comm.Parameters.Add("@r4_tgeral", resn4dd03.r4_tgeral)
        'total geral...
        '((resn4dd01.totProd + resn4dd01.vlIsento + vlOutras + vlIPI + _
        '                                   totFrete + totSeguro + totOutrasDesp) - totDesc)


        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub

    Public Sub delResSaidaCstCfopALQ(ByVal resn4dd03 As Cl_ResN4dd03, ByVal geno001 As Cl_Geno, _
                                  ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & geno001.pEsquemaestab & ".resn4dd03 WHERE r4_numero=@r4_numero")

        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@r4_numero", resn4dd03.r4_numero)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()

        comm = Nothing
        sqlbuild = Nothing
    End Sub
    'FIM do Tratamento dos Resumo dos Itens da NFe Saídas....


#End Region

#Region "  * * Manutenção do CUPOM FISCAL Cup... * *  "

    ' Inclusão de registro de cabeçalho do CUPOM
    Public Sub incPedidoCup1ppx(ByVal cp_orca As String, ByVal cp_geno As String, ByVal cp_codig As String, _
                        ByVal cp_dtemis As Date, ByVal cp_dtsai As Date, ByVal cp_cfop As String, _
                        ByVal cp_vend As String, ByVal cp_cid As String, ByVal cp_itens As Integer, _
                        ByVal cp_rota As Integer, ByVal cp_y As String, ByVal cp_uf As String, _
                        ByVal cp_pgto As String, ByVal cp_tipo As String, ByVal conexao As NpgsqlConnection, _
                        ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".cup1pp(")
        sqlbuild.Append("cp_id, cp_orca, cp_geno, cp_codig, cp_dtemis, cp_dtsai, cp_cfop, ")
        sqlbuild.Append("cp_vend, cp_cid, cp_itens, cp_rota, cp_y, cp_uf, cp_pgto, cp_tipo) ")
        sqlbuild.Append("VALUES (DEFAULT, @cp_orca, @cp_geno, @cp_codig, @cp_dtemis, @cp_dtsai, ")
        sqlbuild.Append("@cp_cfop, @cp_vend, @cp_cid, @cp_itens, @cp_rota, @cp_y, @cp_uf, @cp_pgto, ")
        sqlbuild.Append("@cp_tipo) ")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cp_orca", cp_orca) : comm.Parameters.Add("@cp_geno", cp_geno)
        comm.Parameters.Add("@cp_codig", cp_codig) : comm.Parameters.Add("@cp_dtemis", Convert.ChangeType(cp_dtemis, GetType(Date)))
        comm.Parameters.Add("@cp_dtsai", Convert.ChangeType(cp_dtsai, GetType(Date))) : comm.Parameters.Add("@cp_cfop", cp_cfop)
        comm.Parameters.Add("@cp_vend", cp_vend) : comm.Parameters.Add("@cp_cid", cp_cid)
        comm.Parameters.Add("@cp_itens", cp_itens) : comm.Parameters.Add("@cp_rota", cp_rota)
        comm.Parameters.Add("@cp_y", cp_y) : comm.Parameters.Add("@cp_uf", cp_uf)
        comm.Parameters.Add("@cp_pgto", cp_pgto) : comm.Parameters.Add("@cp_tipo", cp_tipo)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    'Inclusão dos Itens do CUPOM
    Public Sub incPedidoCup2ccx(ByVal no_orca As String, ByVal no_codpr As String, ByVal no_produt As String, _
                        ByVal no_und As String, ByVal no_qtde As Double, ByVal no_prunit As Double, _
                        ByVal no_prtot As Double, ByVal no_prtotd As Double, ByVal no_alqicm As Double, _
                        ByVal no_dtemis As Date, ByVal no_vend As String, ByVal no_com As Double, _
                        ByVal no_cst As String, ByVal no_desc As Double, ByVal no_ncupom As String, _
                        ByVal no_usu As String, ByVal no_clf As String, ByVal no_cfv As Integer, _
                        ByVal no_grupo As Integer, ByVal no_tp As String, ByVal conexao As NpgsqlConnection, _
                        ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".cup2cc(")
        sqlbuild.Append("no_id, no_orca, no_codpr, no_produt, no_und, no_qtde, no_prunit, no_prtot, ")
        sqlbuild.Append("no_prtotd, no_alqicm, no_dtemis, no_vend, no_com, no_cst, no_desc, ")
        sqlbuild.Append("no_ncupom, no_usu, no_clf, no_cfv, no_grupo, no_tp) ")
        sqlbuild.Append("VALUES (DEFAULT, @no_orca, @no_codpr, @no_produt, @no_und, @no_qtde, ")
        sqlbuild.Append("@no_prunit, @no_prtot, @no_prtotd, @no_alqicm, @no_dtemis, @no_vend, @no_com, ")
        sqlbuild.Append("@no_cst, @no_desc, @no_ncupom, @no_usu, @no_clf, @no_cfv, @no_grupo, @no_tp) ")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@no_orca", no_orca)
        comm.Parameters.Add("@no_codpr", no_codpr)
        comm.Parameters.Add("@no_produt", no_produt)
        comm.Parameters.Add("@no_und", no_und)
        comm.Parameters.Add("@no_qtde", no_qtde)
        comm.Parameters.Add("@no_prunit", no_prunit)
        comm.Parameters.Add("@no_prtot", no_prtot)
        comm.Parameters.Add("@no_prtotd", no_prtotd)
        comm.Parameters.Add("@no_alqicm", no_alqicm)
        comm.Parameters.Add("@no_dtemis", Convert.ChangeType(no_dtemis, GetType(Date)))
        comm.Parameters.Add("@no_vend", no_vend)
        comm.Parameters.Add("@no_com", no_com)
        comm.Parameters.Add("@no_cst", no_cst)
        comm.Parameters.Add("@no_desc", no_desc)
        comm.Parameters.Add("@no_ncupom", no_ncupom)
        comm.Parameters.Add("@no_usu", no_usu)
        comm.Parameters.Add("@no_clf", no_clf)
        comm.Parameters.Add("@no_cfv", no_cfv)
        comm.Parameters.Add("@no_grupo", no_grupo)
        comm.Parameters.Add("@no_tp", no_tp)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    'Inclusão dos totais do CUPOM
    Public Sub incPedidoCup4ddx(ByVal n4_tipo As String, ByVal n4_nume As String, ByVal n4_tprod As Double, _
                        ByVal n4_aliss As Double, ByVal n4_vliss As Double, ByVal n4_vlser As Double, _
                        ByVal n4_basec As Double, ByVal n4_icms As Double, ByVal n4_bsub As Double, _
                        ByVal n4_icsub As Double, ByVal n4_ipi As Double, ByVal n4_tgeral As Double, _
                        ByVal n4_desc As Double, ByVal conexao As NpgsqlConnection, _
                        ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".cup4dd(")
        sqlbuild.Append("n4_id, n4_tipo, n4_nume, n4_tprod, n4_aliss, n4_vliss, n4_vlser, ")
        sqlbuild.Append("n4_basec, n4_icms, n4_bsub, n4_icsub, n4_ipi, n4_tgeral, n4_desc) ")
        sqlbuild.Append("VALUES (DEFAULT, @n4_tipo, @n4_nume, @n4_tprod, @n4_aliss, @n4_vliss, @n4_vlser, ")
        sqlbuild.Append("@n4_basec, @n4_icms, @n4_bsub, @n4_icsub, @n4_ipi, @n4_tgeral, @n4_desc)")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_tipo", n4_tipo) : comm.Parameters.Add("@n4_nume", n4_nume)
        comm.Parameters.Add("@n4_tprod", n4_tprod) : comm.Parameters.Add("@n4_aliss", n4_aliss)
        comm.Parameters.Add("@n4_vliss", n4_vliss) : comm.Parameters.Add("@n4_vlser", n4_vlser)
        comm.Parameters.Add("@n4_basec", n4_basec) : comm.Parameters.Add("@n4_icms", n4_icms)
        comm.Parameters.Add("@n4_bsub", n4_bsub) : comm.Parameters.Add("@n4_icsub", n4_icsub)
        comm.Parameters.Add("@n4_ipi", n4_ipi) : comm.Parameters.Add("@n4_tgeral", n4_tgeral)
        comm.Parameters.Add("@n4_desc", n4_desc)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    ' Inclusão de registro de cabeçalho do CUPOM
    Public Sub incPedidoCup1pp(ByVal cp_orca As String, ByVal cp_tipo As String, _
                               ByVal idImpressora As Integer, _
                               ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".cup1pp(")
        sqlbuild.Append("cp_orca, cp_geno, cp_codig, cp_dtemis, cp_dtsai, cp_cfop, cp_vend, ")
        sqlbuild.Append("cp_cid, cp_itens, cp_rota, cp_y, cp_uf, cp_pgto, cp_tipo, cp_idcdcaixa) ")
        sqlbuild.Append("SELECT nt_orca, nt_geno, nt_codig, CURRENT_DATE, CURRENT_DATE, nt_cfop, ")
        sqlbuild.Append("nt_vend, nt_cid, nt_itens, nt_rota, nt_y, nt_uf, nt_tipo2, @tipo, @cp_idcdcaixa ")
        sqlbuild.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp WHERE nt_orca = @nt_orca")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_orca", cp_orca) : comm.Parameters.Add("@tipo", cp_tipo)
        comm.Parameters.Add("@cp_idcdcaixa", idImpressora)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altTipoCup1pp(ByVal cp_tipo As String, ByVal cp_orca As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".cup1pp SET cp_tipo = ")
        sqlbuild.Append("@cp_tipo WHERE cp_orca = @cp_orca")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cp_orca", cp_orca) : comm.Parameters.Add("@cp_tipo", cp_tipo)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    'Inclusão dos Itens do CUPOM
    Public Sub incPedidoCup2cc(ByVal no_orca As String, ByVal no_prtotd As Double, ByVal no_ncupom As String, _
                        ByVal no_usu As String, ByVal no_tp As String, ByVal idImpressora As Integer, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".cup2cc(")
        sqlbuild.Append("no_orca, no_codpr, no_produt, no_und, no_qtde, no_prunit, no_prtot, ")
        sqlbuild.Append("no_prtotd, no_alqicm, no_dtemis, no_vend, no_com, no_desc, no_ncupom, ")
        sqlbuild.Append("no_usu, no_clf, no_cfv, no_grupo, no_tp, no_cst, no_idcdcaixa) ")
        sqlbuild.Append("SELECT no_orca, no_codpr, e_produt, no_und, no_qtde, no_prunit, no_prtot, ")
        sqlbuild.Append("@no_prtotd, no_alqicm, CURRENT_DATE, no_vend, no_comis, no_vldesc, @numcupom, ")
        sqlbuild.Append("@no_usu, e_clf, e_cfv, no_grupo, @no_tp, e_cst, @no_idcdcaixa FROM " & MdlEmpresaUsu._esqEstab)
        sqlbuild.Append(".orca2cc LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 ON e_codig = no_codpr ")
        sqlbuild.Append("WHERE no_orca = @no_orca")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@no_orca", no_orca)
        comm.Parameters.Add("@no_prtotd", no_prtotd)
        comm.Parameters.Add("@numcupom", no_ncupom)
        comm.Parameters.Add("@no_usu", no_usu)
        comm.Parameters.Add("@no_tp", no_tp)
        comm.Parameters.Add("@no_idcdcaixa", idImpressora)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altNumCupomCup2cc(ByVal no_ncupom As String, ByVal no_ncupomAnterior As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".cup2cc SET ")
        sqlbuild.Append("no_ncupom = @no_ncupom WHERE no_ncupom = @no_ncupomant")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@no_ncupom", no_ncupom) : comm.Parameters.Add("@no_ncupomant", no_ncupomAnterior)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    'Inclusão dos totais do CUPOM
    Public Sub incPedidoCup4dd(ByVal n4_tipo As String, ByVal n4_nume As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".cup4dd(")
        sqlbuild.Append("n4_tipo, n4_nume, n4_tprod, n4_aliss, n4_vliss, n4_vlser, n4_basec, ")
        sqlbuild.Append("n4_icms, n4_bsub, n4_icsub, n4_ipi, n4_tgeral, n4_desc) ")
        sqlbuild.Append("SELECT @n4_tipo, n4_nume, n4_tprod, n4_aliss, n4_vliss, n4_vlser, n4_basec, ")
        sqlbuild.Append("n4_icms, n4_bsub, n4_icsub, n4_ipi, n4_tgeral, n4_desc FROM " & MdlEmpresaUsu._esqEstab)
        sqlbuild.Append(".orca4dd WHERE n4_nume = @n4_nume")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_nume", n4_nume) : comm.Parameters.Add("@n4_tipo", n4_tipo)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altTipoCup4dd(ByVal n4_tipo As String, ByVal n4_nume As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".cup4dd SET ")
        sqlbuild.Append("n4_tipo = @n4_tipo WHERE n4_nume = @n4_nume")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_nume", n4_nume) : comm.Parameters.Add("@n4_tipo", n4_tipo)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    'Inclusão informações do cupom...
    Public Sub incPedidoCup6hh(ByVal c_tipo As String, ByVal c_numer As String, _
                        ByVal c_compl1 As String, ByVal c_compl2 As String, _
                        ByVal c_compl3 As String, ByVal c_compl4 As String, _
                        ByVal c_compl5 As String, ByVal c_compl6 As String, _
                        ByVal c_compl7 As String, ByVal conexao As NpgsqlConnection, _
                        ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".cup6hh(")
        sqlbuild.Append("c_tipo, c_numer, c_compl1, c_compl2, c_compl3, c_compl4, c_compl5, ")
        sqlbuild.Append("c_compl6, c_compl7) ")
        sqlbuild.Append("VALUES (@c_tipo, @c_numer, @c_compl1, @c_compl2, @c_compl3, @c_compl4, ")
        sqlbuild.Append("@c_compl5, @c_compl6, @c_compl7) ")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@c_numer", c_numer) : comm.Parameters.Add("@c_tipo", c_tipo)
        comm.Parameters.Add("@c_compl1", c_compl1) : comm.Parameters.Add("@c_compl2", c_compl2)
        comm.Parameters.Add("@c_compl3", c_compl3) : comm.Parameters.Add("@c_compl4", c_compl4)
        comm.Parameters.Add("@c_compl5", c_compl5) : comm.Parameters.Add("@c_compl6", c_compl6)
        comm.Parameters.Add("@c_compl7", c_compl7)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    'Iclusão Redução Z
    Public Sub incCup5zz(ByVal cz_tipo As String, ByVal cz_subtipo As String, _
                        ByVal cz_dtemis As Date, ByVal cz_nserie As String, _
                        ByVal cz_nordem As String, ByVal cz_modelo As String, _
                        ByVal cz_cooinicial As String, ByVal cz_coofinal As String, _
                        ByVal cz_crz As String, ByVal cz_cro As String, _
                        ByVal cz_tvendbruta As Double, ByVal cz_tgeral As Double, _
                        ByVal cz_idcdcaixa As String, ByVal conexao As NpgsqlConnection, _
                        ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".cup5zz(")
        sqlbuild.Append("cz_tipo, cz_subtipo, cz_dtemis, cz_nserie, cz_nordem, cz_modelo, cz_cooinicial, ")
        sqlbuild.Append("cz_coofinal, cz_crz, cz_cro, cz_tvendbruta, cz_tgeral, cz_idcdcaixa) ")
        sqlbuild.Append("VALUES (@cz_tipo, @cz_subtipo, @cz_dtemis, @cz_nserie, @cz_nordem, @cz_modelo, ")
        sqlbuild.Append("@cz_cooinicial, @cz_coofinal, @cz_crz, @cz_cro, @cz_tvendbruta, @cz_tgeral, ")
        sqlbuild.Append("@cz_idcdcaixa) ")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cz_tipo", cz_tipo) : comm.Parameters.Add("@cz_subtipo", cz_subtipo)
        comm.Parameters.Add("@cz_dtemis", Convert.ChangeType(cz_dtemis, GetType(Date))) : comm.Parameters.Add("@cz_nserie", cz_nserie)
        comm.Parameters.Add("@cz_nordem", cz_nordem) : comm.Parameters.Add("@cz_modelo", cz_modelo)
        comm.Parameters.Add("@cz_cooinicial", cz_cooinicial) : comm.Parameters.Add("@cz_coofinal", cz_coofinal)
        comm.Parameters.Add("@cz_crz", cz_crz) : comm.Parameters.Add("@cz_cro", cz_cro)
        comm.Parameters.Add("@cz_tvendbruta", cz_tvendbruta) : comm.Parameters.Add("@cz_tgeral", cz_tgeral)
        comm.Parameters.Add("@cz_idcdcaixa", cz_idcdcaixa)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altTipoCup6hh(ByVal c_tipo As String, ByVal c_numer As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".cup6hh SET ")
        sqlbuild.Append("c_tipo = @c_tipo WHERE c_numer = @c_numer")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@c_tipo", c_tipo) : comm.Parameters.Add("@c_numer", c_numer)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delPedidoCup2cc(ByVal pedido As String, ByVal conexao As NpgsqlConnection, _
                               ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc WHERE no_orca = @no_orca")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@no_orca", pedido)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delPedidoCup4dd(ByVal pedido As String, ByVal geno As String, _
                                         ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM orca4dd WHERE n4_nume = @n4_nume AND n4_geno = @n4_geno")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_nume", pedido)
        comm.Parameters.Add("@n4_geno", geno)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altPedidoCup4dd(ByVal tipo As String, ByVal nume As String, ByVal tprod As Double, ByVal aliss As Double, _
                        ByVal vliss As Double, ByVal vlser As Double, ByVal basec As Double, ByVal icms As Double, _
                        ByVal bsub As Double, ByVal icsub As Double, ByVal tpro2 As Double, ByVal frete As Double, _
                        ByVal segu As Double, ByVal outros As Double, ByVal ipi As Double, ByVal tgeral As Double, _
                        ByVal pgto As String, ByVal peso As Double, ByVal desc As Double, ByVal tipo2 As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca4dd SET n4_tipo = @n4_tipo, ")
        sqlbuild.Append("n4_tprod = @n4_tprod, n4_aliss = @n4_aliss, n4_vliss = @n4_vliss, n4_vlser = @n4_vlser, ")
        sqlbuild.Append("n4_basec = @n4_basec, n4_icms = @n4_icms, n4_bsub = @n4_bsub, n4_icsub = @n4_icsub, ")
        sqlbuild.Append("n4_tpro2 = @n4_tpro2, n4_frete = @n4_frete, n4_segu = @n4_segu, n4_outros = @n4_outros, ")
        sqlbuild.Append("n4_ipi = @n4_ipi, n4_tgeral = @n4_tgeral, n4_pgto = @n4_pgto, n4_peso = @n4_peso, ")
        sqlbuild.Append("n4_desc = @n4_desc, n4_tipo2 = @n4_tipo2 WHERE n4_nume = @n4_nume")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_tipo", tipo) : comm.Parameters.Add("@n4_nume", nume)
        comm.Parameters.Add("@n4_tprod", tprod) : comm.Parameters.Add("@n4_aliss", aliss)
        comm.Parameters.Add("@n4_vliss", vliss) : comm.Parameters.Add("@n4_vlser", vlser)
        comm.Parameters.Add("@n4_basec", basec) : comm.Parameters.Add("@n4_icms", icms)
        comm.Parameters.Add("@n4_bsub", bsub) : comm.Parameters.Add("@n4_icsub", icsub)
        comm.Parameters.Add("@n4_tpro2", tpro2) : comm.Parameters.Add("@n4_frete", frete)
        comm.Parameters.Add("@n4_segu", segu) : comm.Parameters.Add("@n4_outros", outros)
        comm.Parameters.Add("@n4_ipi", ipi) : comm.Parameters.Add("@n4_tgeral", tgeral)
        comm.Parameters.Add("@n4_pgto", pgto) : comm.Parameters.Add("@n4_peso", peso)
        comm.Parameters.Add("@n4_desc", desc) : comm.Parameters.Add("@n4_tipo2", tipo2)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

#End Region

#Region "  *  *  *   Movimento de Pedidos de Venda (Orca1,Orca2,Orca4)  *  *   * "

    ' Inclusão de registro de cabeçalho do Pedido
    Public Sub incPedido_Orca1(ByVal orca As String, ByVal geno As String, ByVal codigo As String, ByVal dtemis As Date, ByVal dtsai As Date, ByVal TPemiss As Boolean, ByVal cfop As String, _
                         ByVal vendedor As String, ByVal cidade As String, ByVal itens As Integer, ByVal rota As Integer, ByVal peso As Double, ByVal x As String, ByVal y As String, ByVal parc As Integer, _
                         ByVal volume As Integer, ByVal tipo2 As String, ByVal auto As String, ByVal auto2 As String, ByVal cod1 As Integer, ByVal cod2 As Integer, ByVal cod3 As Integer, _
                         ByVal cod4 As Integer, ByVal cod5 As Integer, ByVal cod6 As Integer, ByVal cod7 As Integer, ByVal mapa As String, ByVal sit As String, ByVal uf As String, ByVal tipoSelecao As Int16, _
                         ByVal entrada As Double, ByVal descrCondicao As String, ByVal parcelas As Integer, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".orca1pp(nt_idx, nt_orca, nt_geno, nt_codig, nt_dtemis, nt_dtsai,nt_emiss, nt_cfop, ")
        sqlbuild.Append("nt_vend, nt_cid, nt_itens, nt_rota, nt_peso, nt_x, nt_y, nt_parc,nt_cod1, nt_cod2, ")
        sqlbuild.Append("nt_volum, nt_tipo2, nt_auto, nt_auto2, nt_cod3, nt_cod4, nt_cod5, nt_cod6, nt_cod7, ")
        sqlbuild.Append("nt_mapa, nt_sit, nt_uf, nt_tiposelecao, nt_entrada, nt_descrcondpagto, nt_qtdparcelas) VALUES (@nt_idx, @nt_orca, @nt_geno, @nt_codig,@nt_dtemis, @nt_dtsai, ")
        sqlbuild.Append("@nt_emiss, @nt_cfop,@nt_vend, @nt_cid, @nt_itens, @nt_rota, @nt_peso,@nt_x, @nt_y, @nt_parc, @nt_cod1, ")
        sqlbuild.Append("@nt_cod2, @nt_volum, @nt_tipo2, @nt_auto, @nt_auto2, @nt_cod3, @nt_cod4, @nt_cod5, @nt_cod6, ")
        sqlbuild.Append("@nt_cod7, @nt_mapa, @nt_sit, @nt_uf, @nt_tiposelecao, @nt_entrada, @nt_descrcondpagto, @nt_qtdparcelas)")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@nt_idx", Convert.ToInt64(orca))
        comm.Parameters.Add("@nt_orca", orca) : comm.Parameters.Add("@nt_geno", geno)
        comm.Parameters.Add("@nt_codig", codigo) : comm.Parameters.Add("@nt_dtemis", Convert.ChangeType(dtemis, GetType(Date)))
        comm.Parameters.Add("@nt_dtsai", Convert.ChangeType(dtsai, GetType(Date))) : comm.Parameters.Add("@nt_emiss", TPemiss)
        comm.Parameters.Add("@nt_cfop", cfop) : comm.Parameters.Add("@nt_vend", vendedor)
        comm.Parameters.Add("@nt_cid", cidade) : comm.Parameters.Add("@nt_itens", itens)
        comm.Parameters.Add("@nt_rota", rota) : comm.Parameters.Add("@nt_peso", peso)
        comm.Parameters.Add("@nt_x", x) : comm.Parameters.Add("@nt_y", y)
        comm.Parameters.Add("@nt_parc", parc) : comm.Parameters.Add("@nt_volum", volume)
        comm.Parameters.Add("@nt_tipo2", tipo2) : comm.Parameters.Add("@nt_auto", auto)
        comm.Parameters.Add("@nt_auto2", auto2) : comm.Parameters.Add("@nt_cod1", cod1)
        comm.Parameters.Add("@nt_cod2", cod2) : comm.Parameters.Add("@nt_cod3", cod3)
        comm.Parameters.Add("@nt_cod4", cod4) : comm.Parameters.Add("@nt_cod5", cod5)
        comm.Parameters.Add("@nt_cod6", cod6) : comm.Parameters.Add("@nt_cod7", cod7)
        comm.Parameters.Add("@nt_mapa", mapa) : comm.Parameters.Add("@nt_sit", sit)
        comm.Parameters.Add("@nt_uf", uf) : comm.Parameters.Add("@nt_tiposelecao", tipoSelecao)
        comm.Parameters.Add("@nt_entrada", entrada) : comm.Parameters.Add("@nt_descrcondpagto", descrCondicao)
        comm.Parameters.Add("@nt_qtdparcelas", parcelas)


        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incPedido_Orca1Temporaria(ByVal orca As String, ByVal geno As String, ByVal codigo As String, ByVal dtemis As Date, ByVal dtsai As Date, ByVal TPemiss As Boolean, ByVal cfop As String, _
                         ByVal vendedor As String, ByVal cidade As String, ByVal itens As Integer, ByVal rota As Integer, ByVal peso As Double, ByVal x As String, ByVal y As String, ByVal parc As Integer, _
                         ByVal volume As Integer, ByVal tipo2 As String, ByVal auto As String, ByVal auto2 As String, ByVal cod1 As Integer, ByVal cod2 As Integer, ByVal cod3 As Integer, _
                         ByVal cod4 As Integer, ByVal cod5 As Integer, ByVal cod6 As Integer, ByVal cod7 As Integer, ByVal mapa As String, ByVal sit As String, ByVal tipoSelecao As Int16, ByVal conexao As NpgsqlConnection, _
                         ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO orca1pp(nt_orca, nt_geno, nt_codig, nt_dtemis, nt_dtsai,nt_emiss, nt_cfop, ")
        sqlbuild.Append("nt_vend, nt_cid, nt_itens, nt_rota, nt_peso, nt_x, nt_y, nt_parc,nt_cod1, nt_cod2, ")
        sqlbuild.Append("nt_volum, nt_tipo2, nt_auto, nt_auto2, nt_cod3, nt_cod4, nt_cod5, nt_cod6, nt_cod7, ")
        sqlbuild.Append("nt_idx, nt_mapa, nt_sit, nt_tiposelecao) VALUES (@nt_orca, @nt_geno, @nt_codig,@nt_dtemis, @nt_dtsai, ")
        sqlbuild.Append("@nt_emiss, @nt_cfop,@nt_vend, @nt_cid, @nt_itens, @nt_rota, @nt_peso,@nt_x, @nt_y, ")
        sqlbuild.Append("@nt_parc, @nt_cod1, @nt_cod2, @nt_volum, @nt_tipo2, @nt_auto, @nt_auto2, @nt_cod3,")
        sqlbuild.Append("@nt_cod4, @nt_cod5, @nt_cod6, @nt_cod7, Default, @nt_mapa, @nt_sit, @nt_tiposelecao)")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_orca", orca) : comm.Parameters.Add("@nt_geno", geno)
        comm.Parameters.Add("@nt_codig", codigo) : comm.Parameters.Add("@nt_dtemis", Convert.ChangeType(dtemis, GetType(Date)))
        comm.Parameters.Add("@nt_dtsai", Convert.ChangeType(dtsai, GetType(Date))) : comm.Parameters.Add("@nt_emiss", TPemiss)
        comm.Parameters.Add("@nt_cfop", cfop) : comm.Parameters.Add("@nt_vend", vendedor)
        comm.Parameters.Add("@nt_cid", cidade) : comm.Parameters.Add("@nt_itens", itens)
        comm.Parameters.Add("@nt_rota", rota) : comm.Parameters.Add("@nt_peso", peso)
        comm.Parameters.Add("@nt_x", x) : comm.Parameters.Add("@nt_y", y)
        comm.Parameters.Add("@nt_parc", parc) : comm.Parameters.Add("@nt_volum", volume)
        comm.Parameters.Add("@nt_tipo2", tipo2) : comm.Parameters.Add("@nt_auto", auto)
        comm.Parameters.Add("@nt_auto2", auto2) : comm.Parameters.Add("@nt_cod1", cod1)
        comm.Parameters.Add("@nt_cod2", cod2) : comm.Parameters.Add("@nt_cod3", cod3)
        comm.Parameters.Add("@nt_cod4", cod4) : comm.Parameters.Add("@nt_cod5", cod5)
        comm.Parameters.Add("@nt_cod6", cod6) : comm.Parameters.Add("@nt_cod7", cod7)
        comm.Parameters.Add("@nt_mapa", mapa) : comm.Parameters.Add("@nt_sit", sit)
        comm.Parameters.Add("@nt_tiposelecao", tipoSelecao)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    'Inclusão dos Itens do Pedido
    Public Sub incPedido_Orca2(ByVal geno As String, ByVal orca As String, ByVal codpr As String, ByVal und As String, ByVal qtde As Double, ByVal PcoVenda As Double, _
                        ByVal alqdesc As Double, ByVal vldesc As Double, ByVal pcoUnitario As Double, ByVal PcoTotal As Double, ByVal alqicm As Double, _
                        ByVal baseicm As Double, ByVal basesub As Double, ByVal alqsub As Double, ByVal vlsub As Double, ByVal dtemis As Date, _
                        ByVal Rota As Integer, ByVal Supervisor As String, ByVal Vendedor As String, ByVal lin As Integer, ByVal grupo As Integer, _
                        ByVal alqcom As Double, ByVal Comissao As Double, ByVal mapa As Int32, ByVal Indice_1 As Int32, ByVal indiceAuto As Int64, _
                        ByVal CodCli As String, ByVal LojaEstoq As String, ByVal Pesobruto As Double, ByVal Pesoliquido As Double, _
                        ByVal cdBarra As String, ByVal outrasDesp As Double, ByVal vlicms As Double, ByVal idGrade As Integer, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".orca2cc(no_orca, no_codpr, no_und, no_qtde, no_prunit,no_prtot, ")
        sqlbuild.Append("no_alqicm,no_dtemis, no_rota, no_vend, no_lin, no_alqcom, no_comis, no_mapa, ")
        sqlbuild.Append("no_supervisor, no_basesub, no_alqsub, no_vlsub, no_idxo1, no_idpk,no_grupo, ")
        sqlbuild.Append("no_cdport, no_alqdesc, no_vldesc, no_pruvenda, no_filial,no_geno, no_pesobruto, ")
        sqlbuild.Append("no_pesoliquido, no_baseicm, no_cdbarra, no_outrasdesp, no_vlicms, no_idgrade) VALUES (@no_orca, @no_codpr, ")
        sqlbuild.Append("@no_und, @no_qtde, @no_prunit,@no_prtot, @no_alqicm, @no_dtemis, @no_rota, @no_vend, ")
        sqlbuild.Append("@no_lin, @no_alqcom, @no_comis, @no_mapa,@no_supervisor, @no_basesub,@no_alqsub, ")
        sqlbuild.Append("@no_vlsub, @no_idxo1, Default, @no_grupo, @no_cdport, @no_alqdesc, @no_vldesc, ")
        sqlbuild.Append("@no_pruvenda, @no_filial,@no_geno, @no_pesobruto, @no_pesoliquido, @no_baseicm, ")
        sqlbuild.Append("@no_cdbarra, @no_outrasdesp, @no_vlicms, @no_idgrade)")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@no_orca", orca)
        comm.Parameters.Add("@no_codpr", codpr)
        comm.Parameters.Add("@no_und", und)
        comm.Parameters.Add("@no_qtde", qtde)
        comm.Parameters.Add("@no_prunit", pcoUnitario)
        comm.Parameters.Add("@no_prtot", PcoTotal)
        comm.Parameters.Add("@no_baseicm", baseicm)
        comm.Parameters.Add("@no_alqicm", alqicm)
        comm.Parameters.Add("@no_dtemis", Convert.ChangeType(dtemis, GetType(Date)))
        comm.Parameters.Add("@no_rota", Rota)
        comm.Parameters.Add("@no_vend", Vendedor)
        comm.Parameters.Add("@no_lin", lin)
        comm.Parameters.Add("@no_alqcom", alqcom)
        comm.Parameters.Add("@no_comis", Comissao)
        comm.Parameters.Add("@no_mapa", mapa)
        comm.Parameters.Add("@no_supervisor", Supervisor)
        comm.Parameters.Add("@no_basesub", basesub)
        comm.Parameters.Add("@no_alqsub", alqsub)
        comm.Parameters.Add("@no_vlsub", vlsub)
        comm.Parameters.Add("@no_idxo1", Indice_1)
        ' comm.Parameters.Add("@no_idpk", )   * Indice Automatico
        comm.Parameters.Add("@no_grupo", grupo)
        comm.Parameters.Add("@no_cdport", CodCli)
        comm.Parameters.Add("@no_alqdesc", alqdesc)
        comm.Parameters.Add("@no_vldesc", vldesc)
        comm.Parameters.Add("@no_pruvenda", PcoVenda)
        comm.Parameters.Add("@no_filial", LojaEstoq)
        comm.Parameters.Add("@no_geno", geno)
        comm.Parameters.Add("@no_pesobruto", Pesobruto)
        comm.Parameters.Add("@no_pesoliquido", Pesoliquido)
        comm.Parameters.Add("@no_cdbarra", cdBarra)
        comm.Parameters.Add("@no_outrasdesp", outrasDesp)
        comm.Parameters.Add("@no_vlicms", vlicms)
        comm.Parameters.Add("@no_idgrade", idGrade)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incPedido_Orca2Temporaria(ByVal geno As String, ByVal orca As String, ByVal codpr As String, ByVal und As String, ByVal qtde As Double, ByVal PcoVenda As Double, _
                        ByVal alqdesc As Double, ByVal vldesc As Double, ByVal pcoUnitario As Double, ByVal PcoTotal As Double, ByVal alqicm As Double, _
                        ByVal baseicm As Double, ByVal basesub As Double, ByVal alqsub As Double, ByVal vlsub As Double, ByVal dtemis As Date, _
                        ByVal Rota As Integer, ByVal Supervisor As String, ByVal Vendedor As String, ByVal lin As Integer, ByVal grupo As Integer, _
                        ByVal alqcom As Double, ByVal Comissao As Double, ByVal mapa As Int32, ByVal Indice_1 As Int32, ByVal indiceAuto As Int64, _
                        ByVal CodCli As String, ByVal LojaEstoq As String, ByVal Pesobruto As Double, ByVal Pesoliquido As Double, _
                        ByVal cdBarra As String, ByVal outrasDesp As Double, ByVal vlicms As Double, ByVal idGrade As Integer, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO orca2cc(no_orca, no_codpr, no_und, no_qtde, no_prunit,no_prtot, ")
        sqlbuild.Append("no_alqicm,no_dtemis, no_rota, no_vend, no_lin, no_alqcom, no_comis, no_mapa, ")
        sqlbuild.Append("no_supervisor, no_basesub, no_alqsub, no_vlsub, no_idxo1, no_idpk,no_grupo, ")
        sqlbuild.Append("no_cdport, no_alqdesc, no_vldesc, no_pruvenda, no_filial,no_geno, no_pesobruto, ")
        sqlbuild.Append("no_pesoliquido, no_baseicm, no_cdbarra, no_outrasdesp, no_vlicms, no_idgrade) VALUES (@no_orca, @no_codpr, ")
        sqlbuild.Append("@no_und, @no_qtde, @no_prunit,@no_prtot, @no_alqicm, @no_dtemis, @no_rota, @no_vend, ")
        sqlbuild.Append("@no_lin, @no_alqcom, @no_comis, @no_mapa,@no_supervisor, @no_basesub,@no_alqsub, ")
        sqlbuild.Append("@no_vlsub, @no_idxo1, Default, @no_grupo, @no_cdport, @no_alqdesc, @no_vldesc, ")
        sqlbuild.Append("@no_pruvenda, @no_filial,@no_geno, @no_pesobruto, @no_pesoliquido, @no_baseicm, ")
        sqlbuild.Append("@no_cdbarra, @no_outrasdesp, @no_vlicms, @no_idgrade)")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@no_orca", orca)
        comm.Parameters.Add("@no_codpr", codpr)
        comm.Parameters.Add("@no_und", und)
        comm.Parameters.Add("@no_qtde", qtde)
        comm.Parameters.Add("@no_prunit", pcoUnitario)
        comm.Parameters.Add("@no_prtot", PcoTotal)
        comm.Parameters.Add("@no_baseicm", baseicm)
        comm.Parameters.Add("@no_alqicm", alqicm)
        comm.Parameters.Add("@no_dtemis", Convert.ChangeType(dtemis, GetType(Date)))
        comm.Parameters.Add("@no_rota", Rota)
        comm.Parameters.Add("@no_vend", Vendedor)
        comm.Parameters.Add("@no_lin", lin)
        comm.Parameters.Add("@no_alqcom", alqcom)
        comm.Parameters.Add("@no_comis", Comissao)
        comm.Parameters.Add("@no_mapa", mapa)
        comm.Parameters.Add("@no_supervisor", Supervisor)
        comm.Parameters.Add("@no_basesub", basesub)
        comm.Parameters.Add("@no_alqsub", alqsub)
        comm.Parameters.Add("@no_vlsub", vlsub)
        comm.Parameters.Add("@no_idxo1", Indice_1)
        ' comm.Parameters.Add("@no_idpk", )   * Indice Automatico
        comm.Parameters.Add("@no_grupo", grupo)
        comm.Parameters.Add("@no_cdport", CodCli)
        comm.Parameters.Add("@no_alqdesc", alqdesc)
        comm.Parameters.Add("@no_vldesc", vldesc)
        comm.Parameters.Add("@no_pruvenda", PcoVenda)
        comm.Parameters.Add("@no_filial", LojaEstoq)
        comm.Parameters.Add("@no_geno", geno)
        comm.Parameters.Add("@no_pesobruto", Pesobruto)
        comm.Parameters.Add("@no_pesoliquido", Pesoliquido)
        comm.Parameters.Add("@no_cdbarra", cdBarra)
        comm.Parameters.Add("@no_outrasdesp", outrasDesp)
        comm.Parameters.Add("@no_vlicms", vlicms)
        comm.Parameters.Add("@no_idgrade", idGrade)


        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub excluiPedido_Orca2Temporaria(ByVal geno As String, ByVal orca As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM orca2cc WHERE no_orca = @no_orca AND no_geno = @no_geno ")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        comm.Parameters.Add("@no_orca", orca)
        comm.Parameters.Add("@no_geno", geno)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    'Inclusão dos totais do Pedido
    Public Sub incPedido_Orca4(ByVal tipo As String, ByVal nume As String, ByVal tprod As Double, ByVal aliss As Double, _
                        ByVal vliss As Double, ByVal vlser As Double, ByVal basec As Double, ByVal icms As Double, _
                        ByVal bsub As Double, ByVal icsub As Double, ByVal tpro2 As Double, ByVal frete As Double, _
                        ByVal segu As Double, ByVal outros As Double, ByVal ipi As Double, ByVal tgeral As Double, _
                        ByVal pgto As String, ByVal peso As Double, ByVal desc As Double, ByVal tipo2 As String, _
                        ByVal comis As Double, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder



        sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".orca4dd(n4_id, n4_tipo, n4_nume, n4_tprod, n4_aliss, n4_vliss, n4_vlser, ")
        sqlbuild.Append("n4_basec, n4_icms, n4_bsub, n4_icsub, n4_tpro2, n4_frete, n4_segu, n4_outros, n4_ipi, ")
        sqlbuild.Append("n4_tgeral, n4_pgto, n4_peso, n4_desc, n4_tipo2, n4_comis) ")
        sqlbuild.Append("VALUES (DEFAULT, @n4_tipo, @n4_nume, @n4_tprod, @n4_aliss, @n4_vliss, @n4_vlser, ")
        sqlbuild.Append("@n4_basec, @n4_icms, @n4_bsub, @n4_icsub, @n4_tpro2, @n4_frete, @n4_segu, @n4_outros, ")
        sqlbuild.Append("@n4_ipi, @n4_tgeral, @n4_pgto, @n4_peso, @n4_desc, @n4_tipo2, @n4_comis)")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_tipo", tipo) : comm.Parameters.Add("@n4_nume", nume)
        comm.Parameters.Add("@n4_tprod", tprod) : comm.Parameters.Add("@n4_aliss", aliss)
        comm.Parameters.Add("@n4_vliss", vliss) : comm.Parameters.Add("@n4_vlser", vlser)
        comm.Parameters.Add("@n4_basec", basec) : comm.Parameters.Add("@n4_icms", icms)
        comm.Parameters.Add("@n4_bsub", bsub) : comm.Parameters.Add("@n4_icsub", icsub)
        comm.Parameters.Add("@n4_tpro2", tpro2) : comm.Parameters.Add("@n4_frete", frete)
        comm.Parameters.Add("@n4_segu", segu) : comm.Parameters.Add("@n4_outros", outros)
        comm.Parameters.Add("@n4_ipi", ipi) : comm.Parameters.Add("@n4_tgeral", tgeral)
        comm.Parameters.Add("@n4_pgto", pgto) : comm.Parameters.Add("@n4_peso", peso)
        comm.Parameters.Add("@n4_desc", desc) : comm.Parameters.Add("@n4_tipo2", tipo2)
        comm.Parameters.Add("@n4_comis", comis)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub incPedido_Orca4Temporaria(ByVal tipo As String, ByVal nume As String, ByVal tprod As Double, ByVal aliss As Double, _
                        ByVal vliss As Double, ByVal vlser As Double, ByVal basec As Double, ByVal icms As Double, _
                        ByVal bsub As Double, ByVal icsub As Double, ByVal tpro2 As Double, ByVal frete As Double, _
                        ByVal segu As Double, ByVal outros As Double, ByVal ipi As Double, ByVal tgeral As Double, _
                        ByVal pgto As String, ByVal peso As Double, ByVal desc As Double, ByVal tipo2 As String, _
                        ByVal geno As String, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder



        sqlbuild.Append("INSERT INTO orca4dd(n4_id, n4_tipo, n4_nume, n4_tprod, n4_aliss, n4_vliss, n4_vlser, ")
        sqlbuild.Append("n4_basec, n4_icms, n4_bsub, n4_icsub, n4_tpro2, n4_frete, n4_segu, n4_outros, n4_ipi, ")
        sqlbuild.Append("n4_tgeral, n4_pgto, n4_peso, n4_desc, n4_tipo2, n4_geno) ")
        sqlbuild.Append("VALUES (DEFAULT, @n4_tipo, @n4_nume, @n4_tprod, @n4_aliss, @n4_vliss, @n4_vlser, ")
        sqlbuild.Append("@n4_basec, @n4_icms, @n4_bsub, @n4_icsub, @n4_tpro2, @n4_frete, @n4_segu, @n4_outros, ")
        sqlbuild.Append("@n4_ipi, @n4_tgeral, @n4_pgto, @n4_peso, @n4_desc, @n4_tipo2, @n4_geno)")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_tipo", tipo) : comm.Parameters.Add("@n4_nume", nume)
        comm.Parameters.Add("@n4_tprod", tprod) : comm.Parameters.Add("@n4_aliss", aliss)
        comm.Parameters.Add("@n4_vliss", vliss) : comm.Parameters.Add("@n4_vlser", vlser)
        comm.Parameters.Add("@n4_basec", basec) : comm.Parameters.Add("@n4_icms", icms)
        comm.Parameters.Add("@n4_bsub", bsub) : comm.Parameters.Add("@n4_icsub", icsub)
        comm.Parameters.Add("@n4_tpro2", tpro2) : comm.Parameters.Add("@n4_frete", frete)
        comm.Parameters.Add("@n4_segu", segu) : comm.Parameters.Add("@n4_outros", outros)
        comm.Parameters.Add("@n4_ipi", ipi) : comm.Parameters.Add("@n4_tgeral", tgeral)
        comm.Parameters.Add("@n4_pgto", pgto) : comm.Parameters.Add("@n4_peso", peso)
        comm.Parameters.Add("@n4_desc", desc) : comm.Parameters.Add("@n4_tipo2", tipo2)
        comm.Parameters.Add("@n4_geno", geno)


        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    ' Alteração do registro de cabeçalho do Pedido
    Public Sub altPedido_Orca1(ByVal orca As String, ByVal geno As String, ByVal codigo As String, ByVal dtemis As Date, ByVal dtsai As Date, ByVal TPemiss As Boolean, ByVal cfop As String, _
                         ByVal vendedor As String, ByVal cidade As String, ByVal itens As Integer, ByVal rota As Integer, ByVal peso As Double, ByVal x As String, ByVal y As String, ByVal parc As Integer, _
                         ByVal volume As Integer, ByVal tipo2 As String, ByVal auto As String, ByVal auto2 As String, ByVal cod1 As Integer, ByVal cod2 As Integer, ByVal cod3 As Integer, _
                         ByVal cod4 As Integer, ByVal cod5 As Integer, ByVal cod6 As Integer, ByVal cod7 As Integer, ByVal mapa As String, ByVal sit As String, ByVal uf As String, _
                         ByVal entrada As Double, ByVal descrCondicao As String, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca1pp SET nt_codig = @nt_codig, ")
        sqlbuild.Append("nt_dtemis = @nt_dtemis, nt_dtsai = @nt_dtsai, nt_emiss = @nt_emiss, nt_cfop = @nt_cfop, ")
        sqlbuild.Append("nt_vend = @nt_vend, nt_cid = @nt_cid, nt_itens = @nt_itens, nt_rota = @nt_rota, ")
        sqlbuild.Append("nt_peso = @nt_peso, nt_x = @nt_x, nt_y = @nt_y, nt_parc = @nt_parc, nt_cod1 = @nt_cod1, ")
        sqlbuild.Append("nt_cod2 = @nt_cod2, nt_volum = @nt_volum, nt_tipo2 = @nt_tipo2, nt_auto = @nt_auto, ")
        sqlbuild.Append("nt_auto2 = @nt_auto2, nt_cod3 = @nt_cod3, nt_cod4 = @nt_cod4, nt_cod5 = @nt_cod5, ")
        sqlbuild.Append("nt_cod6 = @nt_cod6, nt_cod7 = @nt_cod7, nt_mapa = @nt_mapa, nt_sit = @nt_sit, nt_uf = @nt_uf, ")
        sqlbuild.Append("nt_entrada = @nt_entrada, nt_descrcondpagto = @nt_descrcondpagto WHERE nt_orca = @nt_orca")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_orca", orca) 'comm.Parameters.Add("@nt_geno", geno)
        comm.Parameters.Add("@nt_codig", codigo) : comm.Parameters.Add("@nt_dtemis", Convert.ChangeType(dtemis, GetType(Date)))
        comm.Parameters.Add("@nt_dtsai", Convert.ChangeType(dtsai, GetType(Date))) : comm.Parameters.Add("@nt_emiss", TPemiss)
        comm.Parameters.Add("@nt_cfop", cfop) : comm.Parameters.Add("@nt_vend", vendedor)
        comm.Parameters.Add("@nt_cid", cidade) : comm.Parameters.Add("@nt_itens", itens)
        comm.Parameters.Add("@nt_rota", rota) : comm.Parameters.Add("@nt_peso", peso)
        comm.Parameters.Add("@nt_x", x) : comm.Parameters.Add("@nt_y", y)
        comm.Parameters.Add("@nt_parc", parc) : comm.Parameters.Add("@nt_volum", volume)
        comm.Parameters.Add("@nt_tipo2", tipo2) : comm.Parameters.Add("@nt_auto", auto)
        comm.Parameters.Add("@nt_auto2", auto2) : comm.Parameters.Add("@nt_cod1", cod1)
        comm.Parameters.Add("@nt_cod2", cod2) : comm.Parameters.Add("@nt_cod3", cod3)
        comm.Parameters.Add("@nt_cod4", cod4) : comm.Parameters.Add("@nt_cod5", cod5)
        comm.Parameters.Add("@nt_cod6", cod6) : comm.Parameters.Add("@nt_cod7", cod7)
        comm.Parameters.Add("@nt_mapa", mapa) : comm.Parameters.Add("@nt_sit", sit)
        comm.Parameters.Add("@nt_uf", uf) : comm.Parameters.Add("@nt_entrada", entrada)
        comm.Parameters.Add("@nt_descrcondpagto", descrCondicao)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altSituacaoPedido_Orca1(ByVal orca As String, ByVal sit As Integer, _
                                       ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca1pp SET nt_sit = @nt_sit ")
        sqlbuild.Append("WHERE nt_orca = @nt_orca")


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_orca", orca)
        comm.Parameters.Add("@nt_sit", sit)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altSituacaoPedido_Orca1(ByVal orca As String, ByVal sit As Integer, _
                                       ByVal strConexao As String)

        Dim oConnBD As NpgsqlConnection = New NpgsqlConnection(strConexao)

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca1pp SET nt_sit = @nt_sit ")
        sqlbuild.Append("WHERE nt_orca = @nt_orca")


        comm = New NpgsqlCommand(sqlbuild.ToString, oConnBD)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_orca", orca)
        comm.Parameters.Add("@nt_sit", sit)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlbuild = Nothing
        oConnBD.ClearAllPools() : oConnBD.Close() : oConnBD.Dispose() : oConnBD = Nothing


    End Sub

    Public Sub delItemPedido_Orca2Temporaria(ByVal pedido As String, ByVal geno As String, _
            ByVal codProd As String, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM orca2cc WHERE no_orca = @no_orca AND no_geno = @no_geno AND no_codpr = @no_codpr")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@no_orca", pedido)
        comm.Parameters.Add("@no_geno", geno)
        comm.Parameters.Add("@no_codpr", codProd)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delPedido_Orca2(ByVal pedido As String, ByVal conexao As NpgsqlConnection, _
                               ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc WHERE no_orca = @no_orca")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@no_orca", pedido)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delProdutoPedido_Orca2(ByVal pedido As String, ByVal codProduto As String, _
                            ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc WHERE no_orca = @no_orca AND ")
        sqlbuild.Append("no_codpr = @no_codpr")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@no_orca", pedido)
        comm.Parameters.Add("@no_codpr", codProduto)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delPedido_Orca2Temporaria(ByVal pedido As String, ByVal geno As String, _
                                         ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM orca2cc WHERE no_orca = @no_orca AND no_geno = @no_geno")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@no_orca", pedido)
        comm.Parameters.Add("@no_geno", geno)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delPedido_Orca1Temporaria(ByVal pedido As String, ByVal geno As String, _
                                         ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM orca1pp WHERE nt_orca = @nt_orca AND nt_geno = @nt_geno")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@nt_orca", pedido)
        comm.Parameters.Add("@nt_geno", geno)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delPedido_Orca4Temporaria(ByVal pedido As String, ByVal geno As String, _
                                         ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM orca4dd WHERE n4_nume = @n4_nume AND n4_geno = @n4_geno")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_nume", pedido)
        comm.Parameters.Add("@n4_geno", geno)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altPedido_Orca4(ByVal tipo As String, ByVal nume As String, ByVal tprod As Double, ByVal aliss As Double, _
                        ByVal vliss As Double, ByVal vlser As Double, ByVal basec As Double, ByVal icms As Double, _
                        ByVal bsub As Double, ByVal icsub As Double, ByVal tpro2 As Double, ByVal frete As Double, _
                        ByVal segu As Double, ByVal outros As Double, ByVal ipi As Double, ByVal tgeral As Double, _
                        ByVal pgto As String, ByVal peso As Double, ByVal desc As Double, ByVal tipo2 As String, _
                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder


        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca4dd SET n4_tipo = @n4_tipo, ")
        sqlbuild.Append("n4_tprod = @n4_tprod, n4_aliss = @n4_aliss, n4_vliss = @n4_vliss, n4_vlser = @n4_vlser, ")
        sqlbuild.Append("n4_basec = @n4_basec, n4_icms = @n4_icms, n4_bsub = @n4_bsub, n4_icsub = @n4_icsub, ")
        sqlbuild.Append("n4_tpro2 = @n4_tpro2, n4_frete = @n4_frete, n4_segu = @n4_segu, n4_outros = @n4_outros, ")
        sqlbuild.Append("n4_ipi = @n4_ipi, n4_tgeral = @n4_tgeral, n4_pgto = @n4_pgto, n4_peso = @n4_peso, ")
        sqlbuild.Append("n4_desc = @n4_desc, n4_tipo2 = @n4_tipo2 WHERE n4_nume = @n4_nume")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_tipo", tipo) : comm.Parameters.Add("@n4_nume", nume)
        comm.Parameters.Add("@n4_tprod", tprod) : comm.Parameters.Add("@n4_aliss", aliss)
        comm.Parameters.Add("@n4_vliss", vliss) : comm.Parameters.Add("@n4_vlser", vlser)
        comm.Parameters.Add("@n4_basec", basec) : comm.Parameters.Add("@n4_icms", icms)
        comm.Parameters.Add("@n4_bsub", bsub) : comm.Parameters.Add("@n4_icsub", icsub)
        comm.Parameters.Add("@n4_tpro2", tpro2) : comm.Parameters.Add("@n4_frete", frete)
        comm.Parameters.Add("@n4_segu", segu) : comm.Parameters.Add("@n4_outros", outros)
        comm.Parameters.Add("@n4_ipi", ipi) : comm.Parameters.Add("@n4_tgeral", tgeral)
        comm.Parameters.Add("@n4_pgto", pgto) : comm.Parameters.Add("@n4_peso", peso)
        comm.Parameters.Add("@n4_desc", desc) : comm.Parameters.Add("@n4_tipo2", tipo2)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altPedido_Orca4Corte(ByVal nume As String, ByVal tprod As Double, ByVal aliss As Double, _
                        ByVal vliss As Double, ByVal vlser As Double, ByVal basec As Double, ByVal icms As Double, _
                        ByVal bsub As Double, ByVal icsub As Double, ByVal tpro2 As Double, ByVal frete As Double, _
                        ByVal segu As Double, ByVal outros As Double, ByVal ipi As Double, ByVal tgeral As Double, _
                        ByVal peso As Double, ByVal desc As Double, ByVal conexao As NpgsqlConnection, _
                        ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder



        sqlbuild.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca4dd SET n4_tprod = @n4_tprod, ")
        sqlbuild.Append("n4_aliss = @n4_aliss, n4_vliss = @n4_vliss, n4_vlser = @n4_vlser, n4_basec = @n4_basec, ")
        sqlbuild.Append("n4_icms = @n4_icms, n4_bsub = @n4_bsub, n4_icsub = @n4_icsub, n4_tpro2 = @n4_tpro2, ")
        sqlbuild.Append("n4_frete = @n4_frete, n4_segu = @n4_segu, n4_outros = @n4_outros, n4_ipi = @n4_ipi, ")
        sqlbuild.Append("n4_tgeral = @n4_tgeral, n4_peso = @n4_peso, n4_desc = @n4_desc ")
        sqlbuild.Append("WHERE n4_nume = @n4_nume")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@n4_nume", nume)
        comm.Parameters.Add("@n4_tprod", tprod) : comm.Parameters.Add("@n4_aliss", aliss)
        comm.Parameters.Add("@n4_vliss", vliss) : comm.Parameters.Add("@n4_vlser", vlser)
        comm.Parameters.Add("@n4_basec", basec) : comm.Parameters.Add("@n4_icms", icms)
        comm.Parameters.Add("@n4_bsub", bsub) : comm.Parameters.Add("@n4_icsub", icsub)
        comm.Parameters.Add("@n4_tpro2", tpro2) : comm.Parameters.Add("@n4_frete", frete)
        comm.Parameters.Add("@n4_segu", segu) : comm.Parameters.Add("@n4_outros", outros)
        comm.Parameters.Add("@n4_ipi", ipi) : comm.Parameters.Add("@n4_tgeral", tgeral)
        comm.Parameters.Add("@n4_peso", peso) : comm.Parameters.Add("@n4_desc", desc)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub somaQtdeOrca2cc(ByVal numPedido As String, ByVal codProduto As String, _
                               ByVal quantidade As Double, ByVal conexao As NpgsqlConnection, _
                        ByVal transacao As NpgsqlTransaction)

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As New NpgsqlCommand

        sql.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca2cc SET no_qtde = (no_qtde + @qtde) ")
        sql.Append("WHERE no_orca = @no_orca AND no_codpr = @codpr")

        cmd.Transaction = transacao
        cmd = New NpgsqlCommand(sql.ToString, conexao)
        cmd.Parameters.Add("@no_orca", numPedido)
        cmd.Parameters.Add("@codpr", codProduto)
        cmd.Parameters.Add("@qtde", quantidade)

        cmd.ExecuteNonQuery()


        cmd = Nothing : sql = Nothing
    End Sub

    Public Sub subtraiQtdeOrca2cc(ByVal numPedido As String, ByVal codProduto As String, _
                               ByVal quantidade As Double, ByVal conexao As NpgsqlConnection, _
                        ByVal transacao As NpgsqlTransaction)

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As New NpgsqlCommand

        sql.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca2cc SET no_qtde = (no_qtde - @qtde) ")
        sql.Append("WHERE no_orca = @no_orca AND no_codpr = @codpr")

        cmd.Transaction = transacao
        cmd = New NpgsqlCommand(sql.ToString, conexao)
        cmd.Parameters.Add("@no_orca", numPedido)
        cmd.Parameters.Add("@codpr", codProduto)
        cmd.Parameters.Add("@qtde", quantidade)

        cmd.ExecuteNonQuery()


        cmd = Nothing : sql = Nothing
    End Sub

    Public Sub atualizaDiminuiPrtotOrca2cc(ByVal numPedido As String, ByVal codProduto As String, _
                               ByVal quantidade As Double, ByVal conexao As NpgsqlConnection, _
                        ByVal transacao As NpgsqlTransaction)

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As New NpgsqlCommand

        sql.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca2cc SET no_prtot = Round((no_prtot - (no_prunit * @qtde)), 2) ")
        sql.Append("WHERE no_orca = @no_orca AND no_codpr = @codpr")

        cmd.Transaction = transacao
        cmd = New NpgsqlCommand(sql.ToString, conexao)
        cmd.Parameters.Add("@no_orca", numPedido)
        cmd.Parameters.Add("@codpr", codProduto)
        cmd.Parameters.Add("@qtde", quantidade)

        cmd.ExecuteNonQuery()


        cmd = Nothing : sql = Nothing
    End Sub

    Public Sub atualizaDiminuiBaseSubOrca2cc(ByVal numPedido As String, ByVal codProduto As String, _
                               ByVal quantidade As Double, ByVal conexao As NpgsqlConnection, _
                        ByVal transacao As NpgsqlTransaction)

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As New NpgsqlCommand

        sql.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca2cc SET no_basesub = Round((no_basesub - (no_prunit * @qtde)), 2) ")
        sql.Append("WHERE no_orca = @no_orca AND no_codpr = @codpr")

        cmd.Transaction = transacao
        cmd = New NpgsqlCommand(sql.ToString, conexao)
        cmd.Parameters.Add("@no_orca", numPedido)
        cmd.Parameters.Add("@codpr", codProduto)
        cmd.Parameters.Add("@qtde", quantidade)

        cmd.ExecuteNonQuery()


        cmd = Nothing : sql = Nothing
    End Sub

    Public Sub atualizaSomaPrtotOrca2cc(ByVal numPedido As String, ByVal codProduto As String, _
                               ByVal quantidade As Double, ByVal conexao As NpgsqlConnection, _
                        ByVal transacao As NpgsqlTransaction)

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As New NpgsqlCommand

        sql.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca2cc SET no_prtot = Round((no_prtot + (no_prunit * @qtde)), 2) ")
        sql.Append("WHERE no_orca = @no_orca AND no_codpr = @codpr")

        cmd.Transaction = transacao
        cmd = New NpgsqlCommand(sql.ToString, conexao)
        cmd.Parameters.Add("@no_orca", numPedido)
        cmd.Parameters.Add("@codpr", codProduto)
        cmd.Parameters.Add("@qtde", quantidade)

        cmd.ExecuteNonQuery()


        cmd = Nothing : sql = Nothing
    End Sub

    Public Sub atualizaColunaOrca2cc(ByVal numPedido As String, ByVal codProduto As String, _
                               ByVal nomeColuna As String, ByVal valorColuna As Double, _
                               ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As New NpgsqlCommand

        sql.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca2cc SET " & nomeColuna & " = @valorColuna ")
        sql.Append("WHERE no_orca = @no_orca AND no_codpr = @codpr")

        cmd.Transaction = transacao
        cmd = New NpgsqlCommand(sql.ToString, conexao)
        cmd.Parameters.Add("@no_orca", numPedido)
        cmd.Parameters.Add("@codpr", codProduto)
        cmd.Parameters.Add("@valorColuna", valorColuna)

        cmd.ExecuteNonQuery()


        cmd = Nothing : sql = Nothing
    End Sub

    Public Sub atualizaColunaCorteOrca2cc(ByVal numPedido As String, ByVal codProduto As String, _
                                     ByVal valorColuna As Boolean, ByVal conexao As NpgsqlConnection, _
                                     ByVal transacao As NpgsqlTransaction)

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As New NpgsqlCommand

        sql.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca2cc SET no_corte = @valorColuna ")
        sql.Append("WHERE no_orca = @no_orca AND no_codpr = @codpr")

        cmd.Transaction = transacao
        cmd = New NpgsqlCommand(sql.ToString, conexao)
        cmd.Parameters.Add("@no_orca", numPedido)
        cmd.Parameters.Add("@codpr", codProduto)
        cmd.Parameters.Add("@valorColuna", valorColuna)

        cmd.ExecuteNonQuery()


        cmd = Nothing : sql = Nothing
    End Sub

    Public Function trazProxNumPedido(ByVal geno As String, ByVal conexao As NpgsqlConnection) As String
        Dim mNumPedido As String = ""
        Dim drRequis As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT gp_orca FROM genp001 WHERE gp_geno = '" & geno & "'" '"SELECT (CAST(MAX(SUBSTR(p_cod, 2, 5)) AS INTEGER) + 1) AS ""Codigo"" FROM cadp001"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        drRequis = comm.ExecuteReader
        While drRequis.Read

            mNumPedido = drRequis(0).ToString
        End While

        drRequis.Close() : drRequis = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumPedido
    End Function

    '"SELECT setval('loja1.orca1pp_nt_idx_seq'::regclass, 41)"
    '"SELECT currval('" & MdlEmpresaUsu._esqEstab & ".tb_orca1_nt_id_seq'::regclass)"
    '"SELECT nextval('" & MdlEmpresaUsu._esqEstab & ".tb_orca1_nt_id_seq'::regclass)"
    Public Function trazProxNumPedido(ByVal conexao As NpgsqlConnection) As String
        Dim mNumPedido As String = ""
        Dim drRequis As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT nextval('" & MdlEmpresaUsu._esqEstab & ".orca1pp_nt_idx_seq'::regclass)"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        drRequis = comm.ExecuteReader
        While drRequis.Read

            mNumPedido = drRequis(0).ToString
        End While

        drRequis.Close() : drRequis = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mNumPedido
    End Function


    Public Sub updateGenp001NumPedido(ByVal geno As String, ByVal numpedido As String, _
                                      ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE genp001 SET gp_orca = @gp_orca WHERE gp_geno = @gp_geno"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@gp_orca", numpedido)
        comm.Parameters.Add("@gp_geno", geno)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub updateMapaOrca1pp(ByVal numpedido As String, ByVal numMapa As String, _
                                      ByVal strConexao As String)

        Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(strConexao)
        Dim transacao As NpgsqlTransaction

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        transacao = oConnBDMETROSYS.BeginTransaction

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".orca1pp SET nt_mapa = @nt_mapa WHERE nt_orca = @nt_orca"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, oConnBDMETROSYS)
        comm.Parameters.Add("@nt_orca", numpedido)
        comm.Parameters.Add("@nt_mapa", numMapa)

        comm.ExecuteNonQuery()


        transacao.Commit() : oConnBDMETROSYS.Close() : oConnBDMETROSYS = Nothing
        transacao = Nothing
    End Sub

    Public Sub updateNt_X_Orca1pp(ByVal numpedido As String, ByVal nt_x As String, _
                                      ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".orca1pp SET nt_x = @nt_x WHERE nt_orca = @nt_orca"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@nt_orca", numpedido)
        comm.Parameters.Add("@nt_x", nt_x)

        comm.ExecuteNonQuery()
    End Sub

    Public Sub updateMapaOrca2cc(ByVal numpedido As String, ByVal numMapa As String, _
                                      ByVal strConexao As String)

        Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(strConexao)
        Dim transacao As NpgsqlTransaction

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        transacao = oConnBDMETROSYS.BeginTransaction

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqEstab & ".orca2cc SET no_mapa = @no_mapa WHERE no_orca = @no_orca"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, oConnBDMETROSYS)
        comm.Parameters.Add("@no_orca", numpedido)
        comm.Parameters.Add("@no_mapa", numMapa)

        comm.ExecuteNonQuery()


        transacao.Commit() : oConnBDMETROSYS.Close() : oConnBDMETROSYS = Nothing
        transacao = Nothing
    End Sub

    Public Sub devolveQtdsDoOrca2cc(ByVal no_orca As String, ByVal e_loja As String, _
                                    ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtde = (e_qtde + no_qtde), e_qtdfisc = "
        sqlcmd += "(e_qtdfisc + no_qtde) FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc WHERE "
        sqlcmd += "no_orca = @no_orca AND no_codpr = e_codig AND e_loja = @e_loja"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@no_orca", no_orca)
        comm.Parameters.Add("@e_loja", e_loja)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub diminuiQtdFiscComOrca2cc(ByVal no_orca As String, ByVal e_loja As String, _
                                    ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtdfisc = (e_qtdfisc - no_qtde) FROM "
        sqlcmd += MdlEmpresaUsu._esqEstab & ".orca2cc WHERE "
        sqlcmd += "no_orca = @no_orca AND no_codpr = e_codig AND e_loja = @e_loja"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@no_orca", no_orca)
        comm.Parameters.Add("@e_loja", e_loja)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function trazIdOrca1pp(ByVal conexao As NpgsqlConnection, ByVal numPedido As String) As Int64
        Dim id As Int32 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT MAX(nt_idx) FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp WHERE nt_orca = @nt_orca"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@nt_orca", numPedido)
        dr = comm.ExecuteReader
        While dr.Read

            id = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return id
    End Function

    Public Function trazIdNote4f(ByVal conexao As NpgsqlConnection, ByVal numDocumento As String) As Int64
        Dim id As Int32 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT MAX(n4_id) FROM " & MdlEmpresaUsu._esqEstab & ".note4ff WHERE n4_numer = @n4_numer"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@n4_numer", numDocumento)
        dr = comm.ExecuteReader
        While dr.Read

            id = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return id
    End Function

    Public Function trazIdNota4ff(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                                  ByVal numero As String, ByVal geno001 As Cl_Geno) As Int64
        Dim id As Int32 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT MAX(n4_id) FROM " & geno001.pEsquemaestab & ".nota4ff WHERE n4_numer = @n4_numer"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Transaction = transacao
        comm.Parameters.Add("@n4_numer", numero)
        dr = comm.ExecuteReader
        While dr.Read

            id = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return id
    End Function

    Public Function trazIdOrca1ppTemporaria(ByVal conexao As NpgsqlConnection, ByVal numPedido As String, _
                                            ByVal codGeno As String) As Int64
        Dim id As Int32 = 0
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT MAX(nt_idx) FROM orca1pp WHERE nt_orca = @nt_orca AND nt_geno = @nt_geno"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@nt_orca", numPedido)
        comm.Parameters.Add("@nt_geno", codGeno)
        dr = comm.ExecuteReader
        While dr.Read

            id = dr(0)
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return id
    End Function

    Public Function trazVendedorOrca1Temporaria(ByVal conexao As NpgsqlConnection, ByVal numPedido As String, _
                                            ByVal codGeno As String) As String
        Dim codvendedor As String = ""
        Dim dr As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT nt_vend FROM orca1pp WHERE nt_orca = @nt_orca AND nt_geno = @nt_geno"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@nt_orca", numPedido)
        comm.Parameters.Add("@nt_geno", codGeno)
        dr = comm.ExecuteReader
        While dr.Read

            codvendedor = dr(0).ToString
        End While

        dr.Close() : dr = Nothing : comm = Nothing : sqlcmd = Nothing


        Return codvendedor
    End Function

    Public Function existePedidoOrca1Temporaria(ByVal conexao As NpgsqlConnection, ByVal numPedido As String, _
                                            ByVal codGeno As String) As Boolean
        Dim existPedido As Boolean
        Dim drPedido As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT nt_idx FROM orca1pp WHERE nt_orca = @nt_orca AND nt_geno = @nt_geno"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@nt_orca", numPedido)
        comm.Parameters.Add("@nt_geno", codGeno)
        drPedido = comm.ExecuteReader

        existPedido = drPedido.HasRows

        drPedido.Close() : drPedido = Nothing : comm = Nothing : sqlcmd = Nothing


        Return existPedido
    End Function

#End Region

#Region "Funcoes de Controles e Validações "

    Public Function SoNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890,.", Chr(Keyascii)) = 0 Then
            SoNumeros = 0
        Else
            SoNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoNumeros = Keyascii
            Case 13
                SoNumeros = Keyascii
            Case 32
                SoNumeros = Keyascii
        End Select
    End Function

    Public Function SoNumerov(ByVal Keyascii As Short) As Short
        If InStr("1234567890,", Chr(Keyascii)) = 0 Then
            SoNumerov = 0
        Else
            SoNumerov = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoNumerov = Keyascii
            Case 13
                SoNumerov = Keyascii
            Case 32
                SoNumerov = Keyascii
        End Select
    End Function

    Public Shared Function ValidaCPF(ByVal CPF As String) As Boolean
        Dim i, a, n1, n2 As Integer

        ' CPF = CPF.Replace(".", "").Replace(",", "").Replace("/", "").Replace("-", "")
        CPF = CPF.Trim

        If CPF = "" OrElse _
          CPF.Trim.Length <> 11 OrElse _
          CPF = "11111111111" OrElse _
          CPF = "22222222222" OrElse _
          CPF = "33333333333" OrElse _
          CPF = "44444444444" OrElse _
          CPF = "55555555555" OrElse _
          CPF = "66666666666" OrElse _
          CPF = "77777777777" OrElse _
          CPF = "88888888888" OrElse _
          CPF = "99999999999" Then
            Return False
        End If

        For a = 0 To 1
            n1 = 0
            For i = 1 To 9 + a
                n1 = n1 + Val(Mid(CPF, i, 1)) * (11 + a - i)
            Next
            n2 = 11 - (n1 - (Int(n1 / 11) * 11))
            If n2 = 10 Or n2 = 11 Then n2 = 0
            If n2 <> Val(Mid(CPF, 10 + a, 1)) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Shared Function ValidaCNPJ(ByVal CGC As String) As Boolean
        Dim RecebeCNPJ As String
        Dim Numero(14) As Integer
        Dim Soma, Resultado1, Resultado2 As Integer

        RecebeCNPJ = CGC.Trim

        If RecebeCNPJ.Length <> 14 Or _
        RecebeCNPJ = "00000000000000" Or _
        RecebeCNPJ = "11111111111111" Or _
        RecebeCNPJ = "22222222222222" Or _
        RecebeCNPJ = "33333333333333" Or _
        RecebeCNPJ = "44444444444444" Or _
        RecebeCNPJ = "55555555555555" Or _
        RecebeCNPJ = "66666666666666" Or _
        RecebeCNPJ = "77777777777777" Or _
        RecebeCNPJ = "88888888888888" Or _
        RecebeCNPJ = "99999999999999" Then
            Return False
        Else
            Numero(1) = CInt(Mid(RecebeCNPJ, 1, 1))
            Numero(2) = CInt(Mid(RecebeCNPJ, 2, 1))
            Numero(3) = CInt(Mid(RecebeCNPJ, 3, 1))
            Numero(4) = CInt(Mid(RecebeCNPJ, 4, 1))
            Numero(5) = CInt(Mid(RecebeCNPJ, 5, 1))
            Numero(6) = CInt(Mid(RecebeCNPJ, 6, 1))
            Numero(7) = CInt(Mid(RecebeCNPJ, 7, 1))
            Numero(8) = CInt(Mid(RecebeCNPJ, 8, 1))
            Numero(9) = CInt(Mid(RecebeCNPJ, 9, 1))
            Numero(10) = CInt(Mid(RecebeCNPJ, 10, 1))
            Numero(11) = CInt(Mid(RecebeCNPJ, 11, 1))
            Numero(12) = CInt(Mid(RecebeCNPJ, 12, 1))
            Numero(13) = CInt(Mid(RecebeCNPJ, 13, 1))
            Numero(14) = CInt(Mid(RecebeCNPJ, 14, 1))

            Soma = Numero(1) * 5 + Numero(2) * 4 + Numero(3) * 3 + Numero(4) * 2 + Numero(5) * 9 + Numero(6) * 8 + Numero(7) * 7 + Numero(8) * 6 + Numero(9) * 5 + Numero(10) * 4 + Numero(11) * 3 + Numero(12) * 2
            Soma = Soma - (11 * (Int(Soma / 11)))

            If Soma = 0 Or Soma = 1 Then
                Resultado1 = 0
            Else
                Resultado1 = 11 - Soma
            End If

            If Resultado1 = Numero(13) Then
                Soma = Numero(1) * 6 + Numero(2) * 5 + Numero(3) * 4 + Numero(4) * 3 + Numero(5) * 2 + Numero(6) * 9 + Numero(7) * 8 + Numero(8) * 7 + Numero(9) * 6 + Numero(10) * 5 + Numero(11) * 4 + Numero(12) * 3 + Numero(13) * 2
                Soma = Soma - (11 * (Int(Soma / 11)))

                If Soma = 0 Or Soma = 1 Then
                    Resultado2 = 0
                Else
                    Resultado2 = 11 - Soma
                End If

                If Resultado2 = Numero(14) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function

    Public Function ValidaChaveNFE(ByVal Chave As String)

        'Pausa para explicação
        'Dim Vetor(4) As Integer Define um array com 5 elementos iniciados com zero
        'Dim Vetor As Integer = new Integer(4) {} Define um array com 5 elementos iniciados com zero
        'Dim Vetor() As Integer = {1, 2, 3, 4, 5} Define um array com 5 elementos e atribui valores a cada elemento
        'Dim Vetor As Integer = new Integer(4) { 0, 1, 2, 3, 4} Define um array com 5 elementos e atribui valores a cada elemento
        'Redim Vetor(10) Redimensiona o array Vetor para 11 elementos
        'ReDim Preserve Vetor(10) Redimensiona o array Vetor para 11 elementos


        'Vetor que irá receber os dígitos da chave
        Dim Numero(42) As Integer

        'Vetor com o peso de cada um dos dígitos
        Dim pesos() As Integer = {4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2}

        Dim soma As Integer = 0
        Dim i As Integer
        Dim resultado1 As Integer
        'Atribuindo ao vetor cada valor da chave até o indice 43.

        For i = 0 To Numero.Length - 1
            Numero(i) = CInt(Chave.Substring(i, 1))
        Next

        'Multiplica os valors da chave pelo seu peso e soma o resultado.

        For i = 0 To Numero.Length - 1
            soma = soma + (Numero(i) * pesos(i))
        Next

        'Efetua o resto da divisão

        soma = soma - (11 * (Int(soma / 11)))

        'Como regra da validação se o resultado for 0 ou 1 o digito verificador tem que ser igual a 0

        If soma = 0 Or soma = 1 Then
            resultado1 = 0
        Else
            'Se for maior que 1 tem que diminuir de 11;
            resultado1 = 11 - soma
        End If


        'Verifica se o resultado é igual ao ultimo digito e retorna true ou false

        If resultado1 = CInt(Chave.Substring(43, 1)) Then
            Return True
        Else
            Return False
        End If

        'Fim da Função
    End Function

    ' Função p/ retornar a quantidade de String p/ formatar Formulario de Impressão
    Public Function Exibe_Str(ByVal text As String, ByVal StrTot As Integer) As String
        Dim StrCampo As String
        Dim TotStr As Integer
        '             4
        TotStr = Len(text)
        'If TotStr = StrTot Then
        '    StrTot = StrTot + 1
        'End If
        If TotStr > StrTot Then            ' Verifica se Total de String lida é Maior que Parâmetros
            TotStr = StrTot                ' em case positivo equipara quantidades
            text = Mid(text, 1, StrTot)    ' e abstrai string excedentes
        End If
        '             4                  6        4 = 2
        StrCampo = text + Space(StrTot - TotStr)

        Return (StrCampo)
    End Function

#End Region

#Region "  *  *  *  Entrada de Mercadorias   *  *  *   "
    '       
    Public Sub Reg_EntradaSimples(ByVal id As Integer, ByVal Codforne As String, ByVal Numero As String, ByVal DTemissao As Date, _
                        ByVal DTentrada As Date, ByVal TotProduto As Double, ByVal BaseCalculo As Double, ByVal Alqicms As Double, _
                        ByVal Vlicms As Double, ByVal TotGeral As Double, ByVal tipo As String, ByVal Loja As String, _
                        ByVal Natureza As String, ByVal Transaction As NpgsqlTransaction, ByVal conexao As NpgsqlConnection)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        Try
            'conexao.Open()
            sqlbuild.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".note4ff(n4_id,n4_cdforn, n4_numer, n4_dtemis, n4_dtentrada,")
            sqlbuild.Append("n4_totproduto,n4_basecalculo, n4_alqicms, n4_vlicms, n4_totgeral,n4_tipo,n4_loja,n4_tipomov)")
            sqlbuild.Append("VALUES (Default,@n4_cdforn, @n4_numer, @n4_dtemis, @n4_dtentrada, @n4_totproduto, ")
            sqlbuild.Append("@n4_basecalculo,@n4_alqicms, @n4_vlicms, @n4_totgeral,@n4_tipo,@n4_loja,@n4_tipomov )")

            comm = New NpgsqlCommand(sqlbuild.ToString, conexao)

            'comm.Parameters.Add("n4_id", )
            comm.Parameters.Add("n4_cdforn", Codforne)
            comm.Parameters.Add("n4_numer", Numero)
            comm.Parameters.Add("n4_dtemis", Convert.ChangeType(DTemissao, GetType(Date)))
            comm.Parameters.Add("n4_dtentrada", Convert.ChangeType(DTentrada, GetType(Date)))
            comm.Parameters.Add("n4_totproduto", TotProduto)
            comm.Parameters.Add("n4_basecalculo", BaseCalculo)
            comm.Parameters.Add("n4_alqicms", Alqicms)
            comm.Parameters.Add("n4_vlicms", Vlicms)
            comm.Parameters.Add("n4_totgeral", TotGeral)
            comm.Parameters.Add("n4_tipo", tipo)
            comm.Parameters.Add("n4_loja", Loja)
            comm.Parameters.Add("n4_tipomov", Natureza)
            comm.Transaction = Transaction
            comm.ExecuteNonQuery()

            ' conexao.Close()
            ' conexao.Dispose()
            comm = Nothing : sqlbuild = Nothing

        Catch ex As NpgsqlException
            Transaction.Rollback()
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            Transaction.Rollback()
            MsgBox(ex.Message.ToString)

        End Try


    End Sub

    Public Sub Reg_ItemSimples(ByVal IdProd As Integer, ByVal CodProd As String, ByVal Tamanho As String, ByVal Codcor As String, _
                    ByVal CodBarras As String, ByVal Qtde As Double, ByVal vlproduto As Double, ByVal Desconto As Double, _
                    ByVal Vlunitario As Double, ByVal Total As Double, ByVal Taxag As Double, ByVal Custo As Double, _
                    ByVal Lucro As Double, ByVal PcoSugerido As Double, ByVal Tipo As String, ByVal Natureza As String, _
                    ByVal Numero As String, ByVal Indice_N4 As Integer, ByVal Transaction As NpgsqlTransaction, _
                    ByVal Conex As NpgsqlConnection)


        Dim comm2 As NpgsqlCommand
        Dim sqlbuild2 As New StringBuilder
        Try
            Conex.Open()
            sqlbuild2.Append("INSERT INTO loja1.note2ff(nc_idprod, nc_codpr, nc_tm, nc_codcor, nc_cdbarra, nc_qtde, ")
            sqlbuild2.Append("nc_vlproduto,nc_desconto, nc_vlunitario, nc_total, nc_taxag, nc_custo,nc_lucro, ")
            sqlbuild2.Append("nc_pcosugerido, nc_tipo, nc_natur, nc_numer, nc_idbig4) ")
            sqlbuild2.Append("VALUES (Default, @nc_codpr, @nc_tm, @nc_codcor, @nc_cdbarra,@nc_qtde, ")
            sqlbuild2.Append("@nc_vlproduto,@nc_desconto, @nc_vlunitario, @nc_total, @nc_taxag, @nc_custo,")
            sqlbuild2.Append("@nc_lucro,@nc_pcosugerido, @nc_tipo, @nc_natur,@nc_numer, @nc_idbig4)")

            comm2 = New NpgsqlCommand(sqlbuild2.ToString, Conex)
            ' comm2.Parameters.Add("nc_idprod", )
            comm2.Parameters.Add("nc_codpr", CodProd)
            comm2.Parameters.Add("nc_tm ", Tamanho)
            comm2.Parameters.Add("nc_codcor", Codcor)
            comm2.Parameters.Add("nc_cdbarra ", CodBarras)
            comm2.Parameters.Add("nc_qtde ", Qtde)
            comm2.Parameters.Add("nc_vlproduto", vlproduto)
            comm2.Parameters.Add("nc_desconto", Desconto)
            comm2.Parameters.Add("nc_vlunitario", Vlunitario)
            comm2.Parameters.Add("nc_total", Total)
            comm2.Parameters.Add("nc_taxag", Taxag)
            comm2.Parameters.Add("nc_custo", Custo)
            comm2.Parameters.Add("nc_lucro", Lucro)
            comm2.Parameters.Add("nc_pcosugerido", PcoSugerido)
            comm2.Parameters.Add("nc_tipo", Tipo)
            comm2.Parameters.Add("nc_natur ", Natureza)
            comm2.Parameters.Add("nc_numer", Numero)
            comm2.Parameters.Add("nc_idbig4", Indice_N4)

            comm2.Transaction = Transaction
            comm2.ExecuteNonQuery()

            Conex.Close()
            'Conexao.Dispose()
            comm2 = Nothing : sqlbuild2 = Nothing

        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
#End Region

#Region "  *  *   Custo das Mercadorias   *  *   "

    Public Function Calcula_CustoProd(ByVal PrecoCompra As Double, ByVal QtdeComprada As Double, ByVal Ipi As Double, ByVal Frete As Double, ByVal Despesa As Double, _
                                      ByVal Icmsub As Double, ByVal Icms As Double, ByVal Seguro As Double, ByVal Outras As Double) As Double
        Dim mpCusto, mUniIPi, MuniFrete, mUniIcms, mUniSub, mUniOutras, mUniSeguro, mUniDesp As Double
        If Ipi > 0 Then mUniIPi = Round((Ipi / QtdeComprada), 2)
        If Icmsub > 0 Then mUniSub = Round((Icmsub / QtdeComprada), 2)
        If Frete > 0 Then MuniFrete = Round((Frete / QtdeComprada), 2)
        If Outras > 0 Then mUniOutras = Round((Outras / QtdeComprada), 2)
        If Seguro > 0 Then mUniSeguro = Round((Seguro / QtdeComprada), 2)
        If Icms > 0 Then mUniIcms = Round((Icms / QtdeComprada), 2)
        If Despesa > 0 Then mUniDesp = Round((Despesa / QtdeComprada), 2)
        mpCusto = PrecoCompra + mUniIPi + MuniFrete + mUniDesp + mUniIcms + mUniSub + mUniOutras + mUniSeguro 'e_pcusto

        Return mpCusto
    End Function

    '                       antes update     e_qtde                     e_pcusto                     
    Public Function Calcula_CustoMedio(ByVal Saldo_Atu As Double, ByVal CustoAtual As Double, ByVal QtdeCompra As Double, ByVal CustoCompra As Double) As Double
        Dim mCusto_Ant, mCusto_Atu, McustoFin As Double
        mCusto_Ant = (Saldo_Atu * CustoAtual)
        mCusto_Atu = (QtdeCompra * CustoCompra)
        McustoFin = (mCusto_Ant + mCusto_Atu) / (Saldo_Atu + QtdeCompra) 'e_pcustom
        Return McustoFin
    End Function

#End Region

#Region "  *  *   Controle Estoque   *  *   "

    Public Sub altSomandoQtdsProdEstoque(ByVal codproduto As String, ByVal codLoja As String, ByVal novaqtd As Double, _
                                      ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)
        Dim erronoproduto As String = ""
        Dim comm As New NpgsqlCommand

        ' Altera a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtdfisc = (e_qtdfisc + @e_qtdfisc), e_qtde = (e_qtde + @e_qtde) " & _
        "WHERE e_loja = @e_loja AND e_codig = @e_codig"

        comm.Transaction = transaction
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@e_loja", codLoja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtdfisc", novaqtd)
        comm.Parameters.Add("@e_qtde", novaqtd)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub altDiminuindoQtdsProdEstoque(ByVal codproduto As String, ByVal codLoja As String, ByVal novaqtd As Double, _
                                      ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)
        Dim erronoproduto As String = ""
        Dim comm As New NpgsqlCommand

        ' Altera a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtdfisc = (e_qtdfisc - @e_qtdfisc), e_qtde = (e_qtde - @e_qtde) " & _
        "WHERE e_loja = @e_loja AND e_codig = @e_codig"

        comm.Transaction = transaction
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@e_loja", codLoja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtdfisc", novaqtd)
        comm.Parameters.Add("@e_qtde", novaqtd)

        comm.ExecuteNonQuery()

        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub altualizaQtdsProdEstoq(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtd As Double, _
                                          ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtdfisc = @e_qtdfisc, e_qtde = @e_qtde " & _
        "WHERE e_loja = @e_loja AND e_codig = @e_codig"

        comm.Transaction = transaction
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtdfisc", novaqtd)
        comm.Parameters.Add("@e_qtde", novaqtd)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub subtraiQtdFiscProdEstloja(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtdFisc As Double, _
                                          ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtdfisc = (e_qtdfisc - @e_qtdfisc) WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"

        comm.Transaction = transaction
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtdfisc", novaqtdFisc)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub subtraiQtdFiscProdEstloja(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtdFisc As Double, _
                                          ByVal strconexao As String)

        Dim conexao As New NpgsqlConnection(strconexao)
        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexao no ""somaQtdFiscProd"" :: " & ex.Message)
            Return
        End Try
        Dim transaction As NpgsqlTransaction
        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtdfisc = (e_qtdfisc - @e_qtdfisc) WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"

        comm.Transaction = transaction
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtdfisc", novaqtdFisc)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub somaQtdFiscProdEstloja(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtdFisc As Double, _
                                          ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtdfisc = (e_qtdfisc + @e_qtdfisc) WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtdfisc", novaqtdFisc)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub somaQtdFiscProdEstloja(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtdFisc As Double, _
                                          ByVal strconexao As String)

        Dim conexao As New NpgsqlConnection(strconexao)
        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexao no ""somaQtdFiscProd"" :: " & ex.Message)
            Return
        End Try
        Dim transaction As NpgsqlTransaction
        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtdfisc = (e_qtdfisc + @e_qtdfisc) WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtdfisc", novaqtdFisc)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub substitueQtdFiscProd(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtdFisc As Double, _
                                          ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtdfisc = @e_qtdfisc WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtdfisc", novaqtdFisc)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub subtraiQtdeProdEstloja(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtde As Double, _
                                          ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtde = (e_qtde - @e_qtde) WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtde", novaqtde)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub subtraiQtdeProdEstloja(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtde As Double, _
                                          ByVal strconexao As String)

        Dim conexao As New NpgsqlConnection(strconexao)
        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexao no ""somaQtdFiscProd"" :: " & ex.Message)
            Return
        End Try
        Dim transaction As NpgsqlTransaction
        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtde = (e_qtde - @e_qtde) WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtde", novaqtde)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub somaQtdeProdEstloja(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtde As Double, _
                                          ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtde = (e_qtde + @e_qtde) WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Transaction = transaction
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtde", novaqtde)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub somaQtdeProdEstloja(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtde As Double, _
                                          ByVal strconexao As String)

        Dim conexao As New NpgsqlConnection(strconexao)
        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexao no ""somaQtdFiscProd"" :: " & ex.Message)
            Return
        End Try
        Dim transaction As NpgsqlTransaction
        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtde = (e_qtde + @e_qtde) WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Transaction = transaction
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtde", novaqtde)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub substitueQtdeProd(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtde As Double, _
                                          ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtde = @e_qtde WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtde", novaqtde)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub somaQtdeProd_entradaSimples(ByVal CodForn As String, ByVal codproduto As String, ByVal codloja As String, ByVal novaqtde As Double, _
                            ByVal DtCompra As Date, ByVal PcoCompra As Double, ByVal PcoCusto As Double, ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtde = (e_qtde + @e_qtde), e_qtdfisc =(e_qtdfisc + @e_qtdfisc), e_dtcomp=@e_dtcomp, e_pcomp=@e_pcomp, e_pcusto=@e_pcusto, e_cdport=@e_cdport WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"
        conexao.Open()
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Transaction = transaction
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtde", novaqtde)
        comm.Parameters.Add("@e_qtdfisc", novaqtde)
        comm.Parameters.Add("@e_dtcomp", Convert.ChangeType(DtCompra, GetType(Date)))
        comm.Parameters.Add("@e_pcomp", PcoCompra)
        comm.Parameters.Add("@e_pcusto", PcoCusto)
        comm.Parameters.Add("@e_cdport", CodForn)

        comm.ExecuteNonQuery()
        conexao.Close()

        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub subtraiQtdeProd_entradaSimples(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtde As Double, _
                            ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtde = (e_qtde - @e_qtde), e_qtdfisc =(e_qtdfisc - @e_qtdfisc) WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"
        conexao.Open()
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Transaction = transaction
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtde", novaqtde)
        comm.Parameters.Add("@e_qtdfisc", novaqtde)

        comm.ExecuteNonQuery()
        conexao.Close()

        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub subtraiQtdeProdFisc_entradaSimples(ByVal codproduto As String, ByVal codloja As String, ByVal novaqtde As Double, _
                            ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtdfisc =(e_qtdfisc - @e_qtdfisc) WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"
        conexao.Open()
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Transaction = transaction
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtdfisc", novaqtde)

        comm.ExecuteNonQuery()
        conexao.Close()

        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub somaQtdeProdFisc_entradaSimples(ByVal CodForn As String, ByVal codproduto As String, ByVal codloja As String, ByVal novaqtde As Double, _
                            ByVal DtCompra As Date, ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand

        ' Substitue a quantidade do produto e atualiza somente o Fiscal
        Dim sqlcmd As String = "UPDATE estloja01 SET e_qtdfisc =(e_qtdfisc + @e_qtdfisc)  WHERE " & _
        "e_loja = @e_loja AND e_codig = @e_codig"
        conexao.Open()
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Transaction = transaction
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtdfisc", novaqtde)

        comm.ExecuteNonQuery()
        conexao.Close()

        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub altPcustoaEstoque(ByVal codproduto As String, ByVal codloja As String, ByVal pcustoanterior As Double, _
                                 ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)
        Dim comm As New NpgsqlCommand

        ' Altera o Preco de Custo Anterior do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_pcustoa = @e_pcustoa WHERE e_loja = @e_loja AND "
        sqlcmd += "e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_pcustoa", pcustoanterior)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub altPcustoEstoque(ByVal codproduto As String, ByVal codloja As String, ByVal pcusto As Double, _
                                     ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)
        Dim comm As New NpgsqlCommand

        ' Altera p Preço de custo do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_pcusto = @e_pcusto WHERE e_loja = @e_loja AND "
        sqlcmd += "e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_pcusto", pcusto)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub altPcustomEstoque(ByVal codproduto As String, ByVal codloja As String, ByVal pcustomedio As Double, _
                                      ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)
        Dim comm As New NpgsqlCommand

        ' Altera o Preço de custo médio do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_pcustom = @e_pcustom WHERE "
        sqlcmd += "e_loja = @e_loja AND e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_pcustom", pcustomedio)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub altPcompEstoque(ByVal codproduto As String, ByVal codloja As String, ByVal pcomp As Double, _
                                    ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)
        Dim comm As New NpgsqlCommand

        ' Altera o Preço de compra do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_pcomp = @e_pcomp WHERE "
        sqlcmd += "e_loja = @e_loja AND e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_pcomp", pcomp)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Sub altDtcompEstoque(ByVal codproduto As String, ByVal codloja As String, ByVal dtcomp As Date, _
                                     ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)
        Dim comm As New NpgsqlCommand

        ' Altera a Data de compra do produto
        Dim sqlcmd As String = "UPDATE estloja01 SET e_dtcomp = @e_dtcomp WHERE "
        sqlcmd += "e_loja = @e_loja AND e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_dtcomp", Convert.ChangeType(dtcomp, GetType(Date)))

        comm.Transaction = transaction
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function pegaQtdeEstoque(ByVal codproduto As String, ByVal codloja As String, _
                                    ByVal conexao As NpgsqlConnection) As Double
        Dim mqtde As Double = 0.0

        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader

        Dim sqlcmd As String = "SELECT e_qtde FROM estloja01 WHERE "
        sqlcmd += "e_loja = @e_loja AND e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        dr = comm.ExecuteReader

        While dr.Read

            mqtde = CDbl(dr(0).ToString)
        End While

        dr.Close() : comm = Nothing : dr = Nothing : sqlcmd = Nothing
        


        Return mqtde
    End Function

    Public Sub subtraiQtdProdEst0001(ByVal codproduto As String, ByVal novaqtd As Double, _
                                      ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)
        Dim erronoproduto As String = ""
        Dim comm As New NpgsqlCommand

        ' Altera a quantidade do produto
        Dim sqlcmd As String = "UPDATE " & MdlEmpresaUsu._esqVinc & ".est0001 SET e_qtdfisc = (e_qtdfisc - @e_qtdfisc), e_qtde = (e_qtde - @e_qtde) " & _
        "WHERE e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)

        comm.Parameters.Add("@e_codig", codproduto)
        comm.Parameters.Add("@e_qtdfisc", novaqtd)
        comm.Parameters.Add("@e_qtde", novaqtd)

        comm.Transaction = transaction
        comm.ExecuteNonQuery()


        comm = Nothing : sqlcmd = Nothing
    End Sub

    Public Function pegaQtdfiscEstoque(ByVal codproduto As String, ByVal codloja As String, _
                                       ByVal conexao As NpgsqlConnection) As Double
        Dim mqtdfisc As Double = 0.0

        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader

        Dim sqlcmd As String = "SELECT e_qtdfisc FROM estloja01 WHERE "
        sqlcmd += "e_loja = @e_loja AND e_codig = @e_codig"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        dr = comm.ExecuteReader
        While dr.Read

            mqtdfisc = dr(0)
        End While

        dr.Close() : comm = Nothing : sqlcmd = Nothing : dr = Nothing
        


        Return mqtdfisc
    End Function

    Public Function pegaPcustoaEstoque(ByVal codproduto As String, ByVal codloja As String, _
                                       ByVal conexao As NpgsqlConnection) As Double
        Dim mpcustoa As Double = 0.0

        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader

        Dim sqlcmd As String = "SELECT e_pcustoa FROM estloja01 WHERE "
        sqlcmd += "e_loja = @e_loja AND e_codig = @e_codig"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        dr = comm.ExecuteReader
        While dr.Read

            mpcustoa = dr(0)
        End While
        dr.Close() : comm = Nothing : sqlcmd = Nothing : dr = Nothing
        


        Return mpcustoa
    End Function

    Public Function pegaPcustoEstoque(ByVal codproduto As String, ByVal codloja As String, _
                                      ByVal conexao As NpgsqlConnection) As Double
        Dim mpcusto As Double = 0.0

        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader

        Dim sqlcmd As String = "SELECT e_pcusto FROM estloja01 WHERE "
        sqlcmd += "e_loja = @e_loja AND e_codig = @e_codig"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        dr = comm.ExecuteReader
        While dr.Read

            mpcusto = CDbl(dr(0).ToString)
        End While
        dr.Close() : comm = Nothing : sqlcmd = Nothing : dr = Nothing
        


        Return mpcusto
    End Function

    Public Function pegaPcustomEstoque(ByVal codproduto As String, ByVal codloja As String, _
                                       ByVal conexao As NpgsqlConnection) As Double
        Dim mpcustom As Double = 0.0

        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader

        Dim sqlcmd As String = "SELECT e_pcusto FROM estloja01 WHERE "
        sqlcmd += "e_loja = @e_loja AND e_codig = @e_codig"

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@e_loja", codloja)
        comm.Parameters.Add("@e_codig", codproduto)
        dr = comm.ExecuteReader
        While dr.Read

            mpcustom = dr(0)
        End While

        dr.Close() : comm = Nothing : sqlcmd = Nothing : dr = Nothing
        


        Return mpcustom
    End Function

#End Region

#Region "  *  *  *  Boleto Bancario/Carteira   *  *  *  "


    Public Sub Crud_Carteira(ByVal Sit As String, ByVal crt_id As Integer, ByVal Crt As Cl_Carteira, ByVal conexao As NpgsqlConnection, ByVal transaction As NpgsqlTransaction)

        Dim comm As NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        Try
            conexao.Open()
            If Sit = "I" Then
                sqlbuild.Append("INSERT INTO cadcarteira(crt_id, crt_loja, crt_contrato, crt_banco, crt_agencia, crt_conta,crt_digito, crt_carteira,")
                sqlbuild.Append("crt_nossonumero, crt_instrucao1, crt_instrucao2,crt_instrucao3, crt_instrucao4, crt_instrucao5, crt_agenciadigito) ")
                sqlbuild.Append("VALUES (Default, @crt_loja, @crt_contrato, @crt_banco, @crt_agencia, @crt_conta,@crt_digito, @crt_carteira, ")
                sqlbuild.Append("@crt_nossonumero, @crt_instrucao1, @crt_instrucao2, @crt_instrucao3, @crt_instrucao4, @crt_instrucao5, @crt_agenciadigito) ")

                comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
            Else

                sqlbuild.Append("UPDATE cadcarteira SET crt_loja=@crt_loja, crt_contrato=@crt_contrato, crt_banco=@crt_banco,")
                sqlbuild.Append("crt_agencia=@crt_agencia,crt_conta=@crt_conta, crt_digito=@crt_digito, crt_carteira=@crt_carteira,  ")
                sqlbuild.Append("crt_nossonumero=@crt_nossonumero,crt_instrucao1=@crt_instrucao1, crt_instrucao2=@crt_instrucao2,")
                sqlbuild.Append("crt_instrucao3=@crt_instrucao3, crt_instrucao4=@crt_instrucao4,crt_instrucao5=@crt_instrucao5, ")
                sqlbuild.Append("crt_agenciadigito=@crt_agenciadigito WHERE crt_id=@crt_id")

                comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
                comm.Parameters.Add("@crt_id", crt_id)
            End If

            comm.Parameters.Add("@crt_loja", Crt.pLoja)
            comm.Parameters.Add("@crt_contrato", Crt.pContrato)
            comm.Parameters.Add("@crt_banco", Crt.pbanco)
            comm.Parameters.Add("@crt_agencia", Crt.pagencia)
            comm.Parameters.Add("@crt_conta", Crt.pconta)
            comm.Parameters.Add("@crt_digito", Crt.pdigito)
            comm.Parameters.Add("@crt_carteira", Crt.pcarteira)
            comm.Parameters.Add("@crt_nossonumero", Crt.pnossonumero)
            comm.Parameters.Add("@crt_instrucao1", Crt.pinstrucao1)
            comm.Parameters.Add("@crt_instrucao2", Crt.pinstrucao2)
            comm.Parameters.Add("@crt_instrucao3", Crt.pinstrucao3)
            comm.Parameters.Add("@crt_instrucao4", Crt.pinstrucao4)
            comm.Parameters.Add("@crt_instrucao5", Crt.pinstrucao5)
            comm.Parameters.Add("@crt_agenciadigito", Crt.pagenciadigito)

            comm.Transaction = transaction
            comm.ExecuteNonQuery()

            conexao.Close()
            conexao.Dispose()

            comm = Nothing
            sqlbuild = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)

        End Try

    End Sub

#End Region

End Class
