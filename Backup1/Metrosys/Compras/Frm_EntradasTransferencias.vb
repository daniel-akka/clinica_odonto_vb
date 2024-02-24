Imports Npgsql
Imports System.Text
Imports System.Math

Public Class Frm_EntradasTransferencias

    'Objetos p/ Persistência:
    Dim _nota4ff As New Cl_Nota4ff
    Dim _nota2ff As New Cl_Nota2ff

    'Objetos Auxiliares:
    Dim _geno As New Cl_Geno
    Dim _genoFilial As New Cl_Geno
    Dim _genp001 As New Cl_Genp001
    Dim _genp001Filial As New Cl_Genp001
    Dim _clFuncoes As New ClFuncoes
    Dim _clBD As New Cl_bdMetrosys
    Public Shared _frmREf As New Frm_EntradasTransferencias

    'Resumo da Entrada:
    Dim resn4ff01 As New Cl_ResN4ff01
    Dim resn4ff02 As New Cl_ResN4ff02
    Dim resn4ff03 As New Cl_ResN4ff03
    Dim dtgItensResumo As New DataGridView
    'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
    'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14

    'Forms Response:
    Dim frmBuscaNome As New Frm_NomeResp
    Dim frmBuscaCnpjCpf As New Frm_CnpjCpfResp
    Dim frmBuscaNumeroNFe As New Frm_numeroNFeResp
    Dim frmBuscaDataPeriodo As New Frm_DataPeriodoResp
    Dim _tipoConsultaAtual As String = "nome"

    'Variaveis de Referencia:
    Public nomeRef, cnpjCpfRef, numeroNFeRef As String
    Public dataInicialRef, dataFinalRef As Date

    'Variaveis Auxiliares:
    Dim codLoja As String = Mid(MdlEmpresaUsu._codigo, 4, 2)
    Dim codLojaFilial As String = ""
    Dim _numeroNFeEntrada As String = ""
    Dim _cdPortNFeEntrada As String = ""
    Dim _numeroNFeSaida As String = ""
    Dim _cdPortNFeSaida As String = ""
    Dim _cfopNFeSaida As String = ""


    Private Sub Frm_EntradasTransferencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbo_estabelecimento = _clFuncoes.PreenchComboLojaVinculo(cbo_estabelecimento, MdlConexaoBD.conectionPadrao)
        cbo_filial = _clFuncoes.PreenchComboLojaVinculo(cbo_filial, MdlConexaoBD.conectionPadrao)
        cbo_estabelecimento.SelectedIndex = _clFuncoes.trazIndexCboLoja(codLoja, cbo_estabelecimento)
        cboEstabLeave() : nomeRef = ""
        executaF5()


        'INICIO do Tratamento do DataGridView Resumo

        'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
        'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
        dtgItensResumo.Columns.Add("r4_numero", "r4_numero") : dtgItensResumo.Columns.Add("r4_cfop", "r4_cfop")
        dtgItensResumo.Columns.Add("r4_cst", "r4_cst") : dtgItensResumo.Columns.Add("r4_aliq", "r4_aliq")
        dtgItensResumo.Columns.Add("r4_tprod", "r4_tprod") : dtgItensResumo.Columns.Add("r4_tdesc", "r4_tdesc")
        dtgItensResumo.Columns.Add("r4_tfrete", "r4_tfrete") : dtgItensResumo.Columns.Add("r4_tseguro", "r4_tseguro")
        dtgItensResumo.Columns.Add("r4_toutrasdesp", "r4_toutrasdesp") : dtgItensResumo.Columns.Add("r4_bcalc", "r4_bcalc")
        dtgItensResumo.Columns.Add("r4_icms", "r4_icms") : dtgItensResumo.Columns.Add("r4_isento", "r4_isento")
        dtgItensResumo.Columns.Add("r4_outras", "r4_outras") : dtgItensResumo.Columns.Add("r4_ipi", "r4_ipi")
        dtgItensResumo.Columns.Add("r4_tgeral", "r4_tgeral")

        'FIM do Tratamento do DataGridView Resumo


    End Sub

#Region " ***  Funções Auxiliares  *** "

    Private Sub executaF5()
        preencheDtgNotasEntradas(_tipoConsultaAtual)
    End Sub

    Private Sub executaF2()
        tbc_entrTransf.SelectTab(1) : cbo_filial.Focus()
    End Sub

    Private Sub executaDel()

        If dtg_notasEntrada.CurrentRow.IsNewRow = False Then


            _numeroNFeEntrada = dtg_notasEntrada.CurrentRow.Cells(1).Value.ToString
            _cdPortNFeEntrada = dtg_notasEntrada.CurrentRow.Cells(7).Value.ToString

            If MessageBox.Show("Deseja realmente Excluir essa Nota """ & _numeroNFeEntrada & """ ?", "METROSYS", MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If deletarNFeEntrada() Then
                    MsgBox("Nota de Entrada Deletada com Sucesso!")
                    executaF5()
                Else
                    MsgBox("Erro ao Deletar Nota de Entrada!", MsgBoxStyle.Critical)
                End If

            End If
            

        Else
            MsgBox("Selecione um Registro para Excluir!")
        End If

    End Sub

    Private Function deletarNFeEntrada() As Boolean

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim Ok As Boolean = True

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try

        Try
            transacao = conexao.BeginTransaction

            deletandoNFeEntrada(conexao, transacao, Ok)

            transacao.Commit() : conexao.ClearAllPools() : conexao.Close()

        Catch ex As NpgsqlException

            transacao.Rollback()
            MsgBox(ex.Message.ToString)
            Ok = False
        Catch ex As Exception

            Try
                transacao.Rollback()
            Catch ex2 As Exception
            End Try
            Ok = False
        Finally
            conexao = Nothing : transacao = Nothing

        End Try


        Return Ok
    End Function

    Private Sub deletandoNFeEntrada(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, ByRef ok As Boolean)


        'variáveis para conexão:
        Dim mCmd As NpgsqlCommand
        Dim mDr As NpgsqlDataReader
        Dim mSql As New StringBuilder
        Dim mCmdAux As NpgsqlCommand
        Dim mconexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            mconexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            ok = False
            Return
        End Try


        _nota2ff.zeraValores() : _nota4ff.zeraValores()
        _nota4ff.n4_numer = _numeroNFeEntrada
        _nota4ff.n4_cdport = _cdPortNFeEntrada
        _nota2ff.nc_numer = _numeroNFeEntrada
        _nota2ff.nc_cdport = _cdPortNFeEntrada
        resn4ff01.r4_idn4f = _clBD.trazIdNota4ff(conexao, transacao, _numeroNFeEntrada, _geno)
        resn4ff02.r4_idn4f = resn4ff01.r4_idn4f
        resn4ff03.r4_idn4f = resn4ff01.r4_idn4f

        mSql.Remove(0, mSql.ToString.Length)
        mSql.Append("SELECT nc_numer, nc_codpr, nc_qtde ")
        mSql.Append("FROM " & _geno.pEsquemaestab & ".nota2ff WHERE nc_numer = '" & _numeroNFeEntrada & "' AND nc_cdport = '" & _cdPortNFeEntrada & "'")

        mCmdAux = New NpgsqlCommand(mSql.ToString, mconexao)
        mDr = mCmdAux.ExecuteReader

        While mDr.Read

            _nota2ff.nc_numer = mDr(0).ToString
            _nota2ff.nc_codpr = mDr(1).ToString
            _nota2ff.nc_qtde = mDr(2)


            _clBD.subtraiQtdeProdEstloja(_nota2ff.nc_codpr, codLoja, _nota2ff.nc_qtde, conexao, transacao)
            _clBD.subtraiQtdFiscProdEstloja(_nota2ff.nc_codpr, codLoja, _nota2ff.nc_qtde, conexao, transacao)

        End While
        mDr.Close()
        mconexao.ClearAllPools() : mconexao.Close() : mconexao = Nothing



        _clBD.delResEntradaCstCfopALQ(resn4ff03, _geno, conexao, transacao)
        _clBD.delResEntradaCfopALQ(resn4ff02, _geno, conexao, transacao)
        _clBD.delResEntradaALQ(resn4ff01, _geno, conexao, transacao)
        _clBD.delNota2ff(_nota2ff, _geno, conexao, transacao)
        _clBD.delNota4ff(_nota4ff, _geno, conexao, transacao)

    End Sub

    Private Sub preencheDtgNotasEntradas(ByVal tipoConsulta As String)

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim cmd As NpgsqlCommand
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao abrir conexão:: " & ex.Message) : Return
        End Try

        Try


            Sqlcomm.Append("SELECT n4.n4_id, n4.n4_numer, n4.n4_dtemis, n4.n4_dtent, cad.p_portad, n4.n4_tgeral, r_cdfis || ' - ' || r_natureza, n4.n4_cdport  ") '7
            Sqlcomm.Append("FROM cadnatu, " & _geno.pEsquemaestab & ".nota4ff n4 LEFT JOIN cadp001 cad ON cad.p_cod = n4.n4_cdport WHERE ")
            Sqlcomm.Append("r_cdfis = Substr(n4.n4_cdfisc, 1, 1) || '.' || Substr(n4.n4_cdfisc, 2, 3) ")


            Select Case tipoConsulta
                Case "nome"
                    Sqlcomm.Append("AND cad.p_portad LIKE @p_portad ")
                    Sqlcomm.Append("ORDER BY n4.n4_numer DESC, n4.n4_dtent ASC")
                Case "numero"
                    Sqlcomm.Append("AND n4.n4_numer = @nt_nume ")
                    Sqlcomm.Append("ORDER BY n4.n4_numer DESC, n4.n4_dtent ASC")
                Case "cnpjcpf"
                    Sqlcomm.Append("AND cad.p_cgc = @p_cnpjcpf OR cad.p_cpf = @p_cnpjcpf ")
                    Sqlcomm.Append("ORDER BY n4.n4_numer DESC, n4.n4_dtent ASC")
                Case "data"
                    Sqlcomm.Append("AND n4.n4_dtent BETWEEN @dtinical AND @dtfinal ")
                    Sqlcomm.Append("ORDER BY n4.n4_dtent ASC")
            End Select

            'Sqlcomm.Append("desc limit 34")

            cmd = New NpgsqlCommand(Sqlcomm.ToString, conn)

            Select Case tipoConsulta
                Case "nome"
                    cmd.Parameters.Add("@p_portad", nomeRef & "%")
                Case "numero"
                    cmd.Parameters.Add("@nt_nume", numeroNFeRef)
                Case "cnpjcpf"
                    cmd.Parameters.Add("@p_cnpjcpf", cnpjCpfRef)
                Case "data"
                    cmd.Parameters.Add("@dtinical", dataInicialRef)
                    cmd.Parameters.Add("@dtfinal", dataFinalRef)
            End Select

            dr = cmd.ExecuteReader

            Me.dtg_notasEntrada.Rows.Clear() : Me.dtg_notasEntrada.Refresh()
            While dr.Read

                dtg_notasEntrada.Rows.Add(dr(0), dr(1).ToString, Format(CDate(dr(2)), "dd/MM/yyyy"), Format(CDate(dr(3)), "dd/MM/yyyy"), _
                                     dr(4).ToString, Format(dr(5), "###,##0.00"), dr(6).ToString, dr(7).ToString)
            End While
            dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length) : cmd.CommandText = "" : conn.ClearAllPools()
            conn.Close() : dr = Nothing : Sqlcomm = Nothing : cmd = Nothing : conn = Nothing
            Me.dtg_notasEntrada.Refresh()
        Catch ex As Exception
            MsgBox("ERRO na consulta:: " & ex.Message) : Return
        End Try

    End Sub

    Private Sub preencheDtgNotasSaidaFilial()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim cmd As NpgsqlCommand
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao abrir conexão:: " & ex.Message) : Return
        End Try

        Try


            Sqlcomm.Append("SELECT nt.nt_id, nt.nt_nume, nt.nt_dtemis, cad.p_portad, n4.n4_tgeral, nt.nt_cfop || ' - ' || nt.nt_natur, nt.nt_codig, ") '6
            Sqlcomm.Append("nt.nt_cfop FROM " & _genoFilial.pEsquemaestab & ".nota4dd n4, " & _genoFilial.pEsquemaestab & ".nota1pp nt LEFT ")
            Sqlcomm.Append("JOIN cadp001 cad ON cad.p_cod = nt.nt_codig WHERE n4.n4_numer = nt.nt_nume AND ")
            Sqlcomm.Append("(Substr(nt.nt_cfop, 3, 3) = '151' OR Substr(nt.nt_cfop, 3, 3) = '152' OR Substr(nt.nt_cfop, 3, 3) = '409') ")
            Sqlcomm.Append("ORDER BY nt.nt_nume DESC, nt.nt_dtemis ASC LIMIT 34")

            cmd = New NpgsqlCommand(Sqlcomm.ToString, conn)
            dr = cmd.ExecuteReader

            Me.dtg_notasSaidaFilial.Rows.Clear() : Me.dtg_notasSaidaFilial.Refresh()
            While dr.Read

                dtg_notasSaidaFilial.Rows.Add(dr(0), dr(1).ToString, Format(CDate(dr(2)), "dd/MM/yyyy"), _
                                     dr(3).ToString, Format(dr(4), "###,##0.00"), dr(5).ToString, dr(6).ToString, _
                                     dr(7).ToString)
            End While
            dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length) : cmd.CommandText = "" : conn.ClearAllPools()
            conn.Close() : dr = Nothing : Sqlcomm = Nothing : cmd = Nothing : conn = Nothing
            Me.dtg_notasSaidaFilial.Refresh()
        Catch ex As Exception
            MsgBox("ERRO na consulta:: " & ex.Message) : Return
        End Try

    End Sub

    Private Function transferenciaNFe() As Boolean

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim Ok As Boolean = True

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try

        Try
            transacao = conexao.BeginTransaction

            importandoDadosNFe(conexao, transacao, Ok)

            transacao.Commit() : conexao.ClearAllPools() : conexao.Close()

        Catch ex As NpgsqlException

            transacao.Rollback()
            MsgBox(ex.Message.ToString)
            Ok = False
        Catch ex As Exception

            Try
                transacao.Rollback()
            Catch ex2 As Exception
            End Try
            Ok = False
        Finally
            conexao = Nothing : transacao = Nothing

        End Try


        Return Ok
    End Function

    Private Sub importandoDadosNFe(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, ByRef ok As Boolean)


        'variáveis para conexão:
        Dim mCmd As NpgsqlCommand
        Dim mDr As NpgsqlDataReader
        Dim mSql As New StringBuilder
        Dim mCmdAux As NpgsqlCommand
        Dim mconexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            mconexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            ok = False
            Return
        End Try

        'variáveis auxiliares:
        Dim mcfop As String = Mid(_cfopNFeSaida, _cfopNFeSaida.Length - 2, 3)
        Dim mdigCfop As String = "1"


        'Tratamento CFOP REGISTRO
        Select Case Mid(_cfopNFeSaida, 1, 1)
            Case "5" 'Vem de DENTRO do estado

                mdigCfop = "1"
                Select Case mcfop
                    Case "409"
                        mcfop = "1409"
                    Case "151", "152"
                        mcfop = "1152"
                End Select

            Case "6" 'Vem de FORA do estado

                mdigCfop = "2"
                Select Case mcfop
                    Case "409"
                        mcfop = "2409"
                    Case "151", "152"
                        mcfop = "2152"
                End Select

        End Select


        _cdPortNFeSaida = _clFuncoes.trazCodPartCadp001(_genoFilial.pCgc, "p_cgc", MdlConexaoBD.conectionPadrao)


        'Incluindo no NOTA4FF apartir das INFORMAÇÕES DO NOTA1PP e NOTA4DD...
        mSql.Append("INSERT INTO " & _geno.pEsquemaestab & ".nota4ff(")
        mSql.Append("n4_tipo, n4_numer, n4_tprod, n4_aliss, n4_vliss, n4_vlser, n4_basec, n4_icms, n4_bsub, ")
        mSql.Append("n4_icsub, n4_tpro2, n4_frete, n4_segu, n4_outros, n4_ipi, n4_tgeral, n4_pgto, ")
        mSql.Append("n4_dtemis, n4_dtent, n4_cdport, n4_isento, n4_cdfisc, n4_aliq, n4_hist, ")
        mSql.Append("n4_serie, n4_espec, n4_antec, n4_alqipi, n4_ipisent, n4_ipoutro, n4_sete, ")
        mSql.Append("n4_doze, n4_deze7, n4_vint5, n4_uf, n4_serx, n4_docum, n4_valor, n4_tipo2, ")
        mSql.Append("n4_x, n4_chave, n4_desc, n4_estab, n4_pagamento, n4_obs, n4_outrasdesp, n4_fechamento) ")
        mSql.Append("SELECT 'E', nt_nume, n4_tprod, n4_aliss, n4_vliss, n4_vlser, n4_basec, ")
        mSql.Append("n4_icms, n4_bsub, n4_icsub, n4_tpro2, n4_frete, n4_segu, 0, n4_ipi, n4_tgeral, ")
        mSql.Append("n4_pgto, nt_dtemis, CURRENT_DATE, '" & _cdPortNFeSaida & "', n4_isento, " & mcfop & ", 0, '', nt_serie, ")
        mSql.Append("'', 0, 0, 0, 0, 0, 0, 0, 0, nt_uf, 0, '', 0, 0, '', nt_chave, n4_desc, '01', ")
        mSql.Append("1, 'IMPORTADA PELO METROSYS', n4_outros, false FROM " & _genoFilial.pEsquemaestab & ".nota1pp ")
        mSql.Append("LEFT JOIN " & _genoFilial.pEsquemaestab & ".nota4dd ON n4_numer = nt_nume WHERE nt_nume = '" & _numeroNFeSaida & "'")


        mCmd = New NpgsqlCommand(mSql.ToString, conexao)
        mCmd.Transaction = transacao
        mCmd.ExecuteNonQuery()


        _nota2ff.zeraValores()
        _nota2ff.nc_idn4ff = _clBD.trazIdNota4ff(conexao, transacao, _numeroNFeSaida, _geno)


        mSql.Remove(0, mSql.ToString.Length)
        mSql.Append("SELECT nc_tipo, nc_numer, nc_codpr, nc_produt, nc_cf, nc_cst, nc_und, nc_qtde, nc_prunit, ") '8
        mSql.Append("nc_prtot, nc_alqicm, nc_alqipi, nc_vlipi, nc_vlicm, nc_dtemis, nc_cdport, nc_unipi, ") '16
        mSql.Append("nc_vlsubs, nc_cfop, nc_bcalc, nc_basesub, nc_frete, nc_segur, nc_vldesc, nc_isento, ") '24
        mSql.Append("nc_id, nc_ntid, nc_csosn, nc_vltrib, nc_alqsub, nc_ncm, nc_indtot, nc_desc, nc_descpac, ") '33
        mSql.Append("nc_voutro, nc_seqitem, nc_reduz, nc_alqreduz, nc_cstpis, nc_cstcofins, nc_cstipi ") '40
        mSql.Append("FROM " & _genoFilial.pEsquemaestab & ".nota2cc WHERE nc_numer = '" & _numeroNFeSaida & "'")

        mCmdAux = New NpgsqlCommand(mSql.ToString, mconexao)
        mDr = mCmdAux.ExecuteReader

        While mDr.Read

            _nota2ff.nc_tp = 0
            _nota2ff.nc_tipo = "E"
            _nota2ff.nc_numer = _numeroNFeSaida
            _nota2ff.nc_codpr = mDr(2).ToString
            _nota2ff.nc_produt = Mid(mDr(3).ToString, 1, 55)
            _nota2ff.nc_cf = mDr(4).ToString
            _nota2ff.nc_cst = mDr(5).ToString
            _nota2ff.nc_und = mDr(6).ToString
            _nota2ff.nc_cdport = _cdPortNFeSaida
            _nota2ff.nc_usu = Mid(MdlUsuarioLogando._usuarioLogin, 1, 5)
            _nota2ff.nc_hora = Mid(DateTime.Now.Hour.ToString, 1, 5)

            Select Case Mid(mDr(18).ToString, mDr(18).ToString.Length - 2, 3)
                Case "409"
                    _nota2ff.nc_cfop = mdigCfop & "409"
                Case "151", "152"
                    _nota2ff.nc_cfop = mdigCfop & "152"
            End Select

            _nota2ff.nc_estab = codLoja


            _nota2ff.nc_qtde = mDr(7)
            _nota2ff.nc_prunit = mDr(8)
            _nota2ff.nc_prtot = mDr(9)
            _nota2ff.nc_alqicm = mDr(10)
            _nota2ff.nc_alqipi = mDr(11)
            _nota2ff.nc_vlipi = mDr(12)
            _nota2ff.nc_vlicm = mDr(13)
            _nota2ff.nc_prucom = 0.0
            _nota2ff.nc_vlicsub = mDr(29)
            _nota2ff.nc_vlsub = mDr(17)
            _nota2ff.nc_desc = mDr(32)
            _nota2ff.nc_icmsub = mDr(29)
            _nota2ff.nc_vldesc = mDr(23)
            _nota2ff.nc_alqnot = mDr(10)
            _nota2ff.nc_basesub = mDr(20)
            _nota2ff.nc_bscalc = mDr(19)
            _nota2ff.nc_frete = mDr(21)
            _nota2ff.nc_seguro = mDr(22)
            _nota2ff.nc_totbruto = mDr(10)
            _nota2ff.nc_outrasdesp = mDr(33)
            _nota2ff.nc_data = MdlConexaoBD.dataServidor
            _nota2ff.nc_dtusu = MdlConexaoBD.dataServidor

            _clBD.incNota2ff(_nota2ff, _geno, conexao, transacao)
            _clBD.somaQtdeProdEstloja(_nota2ff.nc_codpr, codLoja, _nota2ff.nc_qtde, conexao, transacao)
            _clBD.somaQtdFiscProdEstloja(_nota2ff.nc_codpr, codLoja, _nota2ff.nc_qtde, conexao, transacao)

            'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
            'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
            dtgItensResumo.Rows.Add(_nota2ff.nc_numer, _nota2ff.nc_cfop, _nota2ff.nc_cst, Round(_nota2ff.nc_alqicm, 2), _
                                    Round((_nota2ff.nc_prunit * _nota2ff.nc_qtde), 2), Round(_nota2ff.nc_vldesc, 2), _
                                    Round(_nota2ff.nc_frete, 2), Round(_nota2ff.nc_seguro, 2), Round(_nota2ff.nc_outrasdesp, 2), _
                                    Round(_nota2ff.nc_bscalc, 2), Round(_nota2ff.nc_vlicm, 2), 0.0, _
                                    0.0, Round(_nota2ff.nc_vlipi, 2), Round(_nota2ff.nc_prtot, 2))
            _nota2ff.zeraValoresNFe01()


        End While
        mDr.Close()
        mconexao.ClearAllPools() : mconexao.Close() : mconexao = Nothing


        'INCIO do armazenamento dos Resumos...
        resn4ff01.r4_idn4f = _nota2ff.nc_idn4ff : resn4ff01.r4_numero = _numeroNFeSaida
        resn4ff02.r4_idn4f = _nota2ff.nc_idn4ff : resn4ff02.r4_numero = _numeroNFeSaida
        resn4ff03.r4_idn4f = _nota2ff.nc_idn4ff : resn4ff03.r4_numero = _numeroNFeSaida
        _clFuncoes.incResumAlqEntrada(False, dtgItensResumo, resn4ff01, _geno, _clBD, conexao, transacao)
        _clFuncoes.incResumCfopAlqEntrada(False, dtgItensResumo, resn4ff02, _geno, _clBD, conexao, transacao)
        _clFuncoes.incResumCstCfopAlqEntrada(False, dtgItensResumo, resn4ff03, _geno, _clBD, conexao, transacao)
        'FIM do armazenamento dos Resumos

    End Sub

#End Region

    Private Sub Frm_EntradasTransferencias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                If tbc_entrTransf.SelectedIndex = 0 Then executaF5()
            Case Keys.F2
                If tbc_entrTransf.SelectedIndex = 0 Then executaF2()
            Case Keys.P
                If tbc_entrTransf.SelectedIndex = 0 Then Me.tsb_opcoes.ShowDropDown()
            Case Keys.Delete
                If tbc_entrTransf.SelectedIndex = 0 Then executaDel()
        End Select

    End Sub

    Private Sub Frm_EntradasTransferencias_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub cbo_estabelecimento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.GotFocus
        If cbo_estabelecimento.DroppedDown = False Then cbo_estabelecimento.DroppedDown = True
    End Sub

    Private Sub opt_nome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_nome.Click

        _frmREf = Me
        frmBuscaNome.set_frmRef(Me)
        frmBuscaNome.ShowDialog()
        preencheDtgNotasEntradas("nome")
        _tipoConsultaAtual = "nome" : Me.sstrip.Focus()

    End Sub

    Private Sub opt_CnpjCpf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_CnpjCpf.Click

        _frmREf = Me
        frmBuscaCnpjCpf.set_frmRef(Me)
        frmBuscaCnpjCpf.ShowDialog()
        preencheDtgNotasEntradas("cnpjcpf")
        _tipoConsultaAtual = "cnpjcpf" : Me.sstrip.Focus()

    End Sub

    Private Sub opt_data_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_data.Click

        _frmREf = Me
        frmBuscaDataPeriodo.set_frmRef(Me)
        frmBuscaDataPeriodo.ShowDialog()
        preencheDtgNotasEntradas("data")
        _tipoConsultaAtual = "data" : Me.sstrip.Focus()

    End Sub

    Private Sub opt_numero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_numero.Click

        _frmREf = Me
        frmBuscaNumeroNFe.set_frmRef(Me)
        frmBuscaNumeroNFe.ShowDialog()
        preencheDtgNotasEntradas("numero")
        _tipoConsultaAtual = "numero" : Me.sstrip.Focus()

    End Sub

    Private Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged

        Try
            codLoja = ""
            codLoja = cbo_estabelecimento.SelectedItem.ToString.Substring(0, 2)
            cboEstabLeave()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbo_estabelecimento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.Leave
        'cboEstabLeave()
    End Sub

    Private Sub cboEstabLeave()

        If codLoja.Equals("") Then

            MsgBox("Selecione uma Loja Por Favor !")
            cbo_estabelecimento.Focus()
            codLoja = MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2)
            cbo_estabelecimento.SelectedIndex = _clFuncoes.trazIndexCboLoja(codLoja, cbo_estabelecimento)
            Return

        Else
            _clFuncoes.trazGenoSelecionado("G00" & codLoja, _geno)
            _clFuncoes.trazGenpSelecionado("G00" & codLoja, _genp001)
        End If

    End Sub

    Private Sub cbo_filial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_filial.GotFocus
        If cbo_filial.DroppedDown = False Then cbo_filial.DroppedDown = True
    End Sub

    Private Sub cbo_filial_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_filial.SelectedIndexChanged

        lbl_mensagem02.Text = ""
        If Mid(cbo_filial.SelectedItem.ToString, 1, 2).Equals(codLoja) Then
            lbl_mensagem02.Text = "A Filial não pode ser a mesma do Destino !"
            Me.cbo_filial.Focus() : Return
        End If

        Try
            codLojaFilial = ""
            codLojaFilial = cbo_filial.SelectedItem.ToString.Substring(0, 2)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub tbc_entrTransf_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbc_entrTransf.SelectedIndexChanged

        If tbc_entrTransf.SelectedIndex = 1 Then txt_empresaDestino.Text = _geno.pGeno

    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        preencheDtgNotasSaidaFilial()
    End Sub

    Private Sub cbo_filial_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_filial.Leave
        cboEstabLeaveFilial()
    End Sub

    Private Sub cboEstabLeaveFilial()

        If codLojaFilial.Equals("") Then

            MsgBox("Selecione uma Loja Por Favor !")
            cbo_filial.Focus()
            codLojaFilial = MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2)
            cbo_filial.SelectedIndex = _clFuncoes.trazIndexCboLoja(codLojaFilial, cbo_filial)
            Return

        Else
            _clFuncoes.trazGenoSelecionado("G00" & codLojaFilial, _genoFilial)
            _clFuncoes.trazGenpSelecionado("G00" & codLojaFilial, _genp001Filial)
        End If

    End Sub

    Private Sub btn_transferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_transferir.Click

        lbl_mensagem02.Text = ""
        Try
            If dtg_notasSaidaFilial.CurrentRow.IsNewRow = False Then

                _numeroNFeSaida = dtg_notasSaidaFilial.CurrentRow.Cells(1).Value.ToString
                _cdPortNFeSaida = dtg_notasSaidaFilial.CurrentRow.Cells(6).Value.ToString
                _cfopNFeSaida = dtg_notasSaidaFilial.CurrentRow.Cells(7).Value.ToString
                If MessageBox.Show("Deseja Transferir a Nota """ & _numeroNFeSaida & """ ?", "TRANSFERÊNCIA", MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    If verificaNFeSaida() Then

                        If transferenciaNFe() Then

                            MsgBox("Transferência Realizada com Sucesso!")
                            tbc_entrTransf.SelectTab(0)
                            executaF5()
                            Me.dtg_notasSaidaFilial.Rows.Clear() : Me.dtg_notasSaidaFilial.Refresh()
                        Else
                            MsgBox("Erro ao Transferir a NOTA!", MsgBoxStyle.Critical)
                        End If
                    End If
                End If


            End If

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        End Try
        

    End Sub

    Private Function verificaNFeSaida() As Boolean

        lbl_mensagem02.Text = ""
        If _clFuncoes.existNFeNota4ff(_numeroNFeSaida, _cdPortNFeSaida, _geno.pEsquemaestab, MdlConexaoBD.conectionPadrao) Then

            lbl_mensagem02.Text = "Já Existe Essa NF-e na Filial de Destino !"
            Return False
        End If

        Return True
    End Function

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click
        executaDel()
    End Sub

    Private Sub sstrip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sstrip.Click
        Me.tsb_opcoes.ShowDropDown()
    End Sub

    Private Sub sstrip_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles sstrip.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter, Keys.Tab
            Case Else
                Me.tsb_opcoes.ShowDropDown()
        End Select

    End Sub
End Class