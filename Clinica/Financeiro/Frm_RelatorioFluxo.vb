Imports System.Drawing.Printing
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Data.DataColumnCollection
Imports System.Data.DataRow
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Math
Imports Npgsql


Public Class Frm_RelatorioFluxo

    'Protected Const conexao As String = _
    ' "Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDGENOV"
    'Dim mMxml As New GenoNFeXml
    Private Const _valorZERO As Integer = 0
    Private _funcoes As New ClFuncoes, _clBD As New Cl_bdMetrosys
    Dim frmBuscaData As New Frm_DataDoDiaResp
    Dim frmBuscaDataPeriodo As New Frm_DataPeriodoResp
    Dim frmBuscaVendedor As New Frm_VendedorComisResp
    Dim frmBuscaCodCaixa As New Frm_CodCaixaResp
    Public Shared _frmRefGeraPedidos As New Frm_RelatorioFluxo
    Public Shared _frmREf As New Frm_RelatorioFluxo
    Public _numPedido As String = "", _numPedidoTemp As String = ""
    Public _mapaPedido As Integer = 0
    Dim _mConsulta As String = ""
    Dim mLoja As String = Mid(MdlEmpresaUsu._codigo, MdlEmpresaUsu._codigo.Length - 1)

    Dim _tipoComisVendedor As String = ""
    Dim _alqComisVendedor As Double

    'Referencias...
    Public dataDoDiaRef, dataInicialRef, dataFinalRef As New Date
    Public codVendedorRef As String = "", nomeVendedorRef As String = ""
    Public alqComisAVistaRef As Double, alqComisEntradaRef As Double, alqComisAPrazoRef As Double
    Public codCaixaRef As String = ""

    Dim _contLinhasRelatorio As Integer = 0
    Dim _local As String = MdlUsuarioLogando._local.Substring(MdlUsuarioLogando._local.Length - 2)
    Dim sw As Cl_EscreveArquivo

    'Variáveis para o Carnê...
    Private linhaAtual As Integer = -1
    Private mcell, MCod_Cli As String
    Private mTotal As Double
    Private mPedido, MCliente As String

    'Objeto Estoque Financeiro...
    Private objEstFinanceiro As New Cl_EstFinanceiro

    'objetos para impressão...
    Dim MostrarCaixaImpressoras As Boolean = False
    Dim _StringToPrint As String = "", _StringToPrintItens As String = "", _stringToPrintAux As String = ""
    Private _PrintFont1 As New Font("Lucida Console", 8) 'Stenci
    Private _PrintFont2 As New Font("Lucida Console", 8)
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _sImpressao As StreamWriter
    Dim _cabecalho As Boolean = True
    Private _leitorTabelaImprimir As NpgsqlDataReader
    Dim _StrAuxDiarioDupliReceb As String = "               "

    'Objetos para Pedido temporário...
    Dim _arqNumPedido As String = "\wged\relatorios\numpedido.TXT"

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click
        Me.Close()
    End Sub

    Private Sub Frm_RelatorioFluxo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F2
                ' Venda no Pedido 
                
            Case Keys.F3
                ' Altera Pedido 
            Case Keys.F4
                ' Exclui Pedido 
            Case Keys.F5
                executaF5()
        End Select


    End Sub

    Private Sub Frm_RelatorioFluxo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        executaF5()
        cbo_tiporelatorio.SelectedIndex = 0

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos.BeginPrint, AddressOf InicializaRelatorio

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorios.BeginPrint, AddressOf InicializaRelatorio2


    End Sub

    Private Sub btn_imprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprime.Click
        'Aqui....
        _StringToPrint = ""
        _stringToPrintAux = ""
        executaF6()

    End Sub

    Private Sub executaF5()

        preecheDtgPedidos2()

    End Sub

    Private Sub preecheDtgPedidos()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Sqlcomm As StringBuilder = New StringBuilder

        If MdlUsuarioLogando._usuarioPrivilegio Then 'verifica se usuário tem privilégio...

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa, n1.nt_entrada, n1.nt_tiposelecao ") '14
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca AND (n1.nt_tiposelecao <> 1 AND n1.nt_tiposelecao <> 2) AND n1.nt_dtemis = CURRENT_DATE order by n1.nt_dtemis ")
        Else

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa, n1.nt_entrada, n1.nt_tiposelecao ") '14
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_vend = '" & MdlUsuarioLogando._codvendedor & "' AND n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca AND (n1.nt_tiposelecao <> 1 AND n1.nt_tiposelecao <> 2) AND n1.nt_dtemis = CURRENT_DATE order by n1.nt_dtemis ")
        End If
        'Sqlcomm.Append("desc limit 34")

        Dim daPed As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
        Dim dsPed As DataSet = New DataSet()

        Try
            'configurajanelaProdPesq()
            daPed.Fill(dsPed, "Orca1pp")
            conn.Open()

            Me.dtg_pedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.dtg_pedidos.DataSource = dsPed.Tables("Orca1pp").DefaultView
            Me.dtg_pedidos.AllowUserToResizeColumns = False
            Me.dtg_pedidos.AllowUserToResizeRows = False
            Me.dtg_pedidos.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
            Me.dtg_pedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            Me.dtg_pedidos.Columns(0).Visible = False
            Me.dtg_pedidos.Columns(11).Visible = False
            Me.dtg_pedidos.Columns(12).Visible = False
            Me.dtg_pedidos.Columns(8).DefaultCellStyle.Format = "###,##0.00"
            Me.dtg_pedidos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            conn.Close()
            conn = Nothing : daPed = Nothing : dsPed = Nothing : Sqlcomm = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Private Sub preecheDtgPedidos2()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim cmd As NpgsqlCommand
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao abrir conexão:: " & ex.Message) : Return
        End Try


        If MdlUsuarioLogando._usuarioPrivilegio Then 'verifica se usuário tem privilégio...

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa, n1.nt_entrada, n1.nt_tiposelecao ") '14
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca AND (n1.nt_tiposelecao <> 1 AND n1.nt_tiposelecao <> 2) AND n1.nt_dtemis = CURRENT_DATE ORDER BY n1.nt_dtemis, n1.nt_orca DESC ")
        Else

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa, n1.nt_entrada, n1.nt_tiposelecao ") '14
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_vend = '" & MdlUsuarioLogando._codvendedor & "' AND n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca AND (n1.nt_tiposelecao <> 1 AND n1.nt_tiposelecao <> 2) AND n1.nt_dtemis = CURRENT_DATE ORDER BY n1.nt_dtemis, n1.nt_orca DESC ")
        End If
        'Sqlcomm.Append("desc limit 34")

        cmd = New NpgsqlCommand(Sqlcomm.ToString, conn)
        dr = cmd.ExecuteReader
        Dim mEntrada, mTgeral As Double
        Me.dtg_pedidos.Rows.Clear() : Me.dtg_pedidos.Refresh()
        While dr.Read

            Try
                mEntrada = dr(13)
            Catch ex As Exception
                mEntrada = 0
            End Try

            Try
                mTgeral = dr(8)
            Catch ex As Exception
                mTgeral = 0
            End Try

                Try
                dtg_pedidos.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, Format(Convert.ChangeType(dr(3), GetType(Date)), "dd/MM/yyyy"), _
                                 dr(4).ToString, dr(5).ToString, dr(6).ToString, dr(7).ToString, _
                                 Format(mTgeral, "###,##0.00"), dr(9).ToString, dr(10).ToString, dr(11), dr(12), Format(CDbl(mEntrada), "###,##0.00"))
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End While
        dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length) : cmd.CommandText = "" : conn.ClearAllPools()
        conn.Close() : dr = Nothing : Sqlcomm = Nothing : cmd = Nothing : conn = Nothing
        Me.dtg_pedidos.Refresh()

    End Sub

    Private Sub preecheDtgPedidosPesquisa(ByVal pesquisa As String, ByVal pesquisa2 As String)

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim cmd As NpgsqlCommand
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao abrir conexão:: " & ex.Message) : Return
        End Try


        If MdlUsuarioLogando._usuarioPrivilegio Then 'verifica se usuário tem privilégio...

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa, n1.nt_entrada, n1.nt_tiposelecao ") '14
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca AND (n1.nt_tiposelecao <> 1 AND n1.nt_tiposelecao <> 2) ")
        Else

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa, n1.nt_entrada, n1.nt_tiposelecao ") '14
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_vend = '" & MdlUsuarioLogando._codvendedor & "' AND n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca AND (n1.nt_tiposelecao <> 1 AND n1.nt_tiposelecao <> 2) ")
        End If

        If pesquisa2.Equals("") Then ' combo selecionado 0 ou 2

            Select Case cbo_opcoes.SelectedIndex

                Case 0
                    Sqlcomm.Append("AND n1.nt_orca LIKE @pesquisa ") '12
                Case 2
                    Sqlcomm.Append("AND UPPER(cad.p_portad) LIKE @pesquisa ") '12
            End Select

        Else ' combo selecionado 1
            Sqlcomm.Append("AND n1.nt_dtemis BETWEEN @pesquisa AND @pesquisa2 ") '12
        End If
        Sqlcomm.Append("ORDER BY n1.nt_dtemis, n1.nt_orca DESC LIMIT 5000")

        cmd = New NpgsqlCommand(Sqlcomm.ToString, conn)

        Select Case cbo_opcoes.SelectedIndex

            Case 0
                Try
                    pesquisa = String.Format("{0:D8}", CInt(pesquisa))
                    cmd.Parameters.Add("@pesquisa", pesquisa)
                Catch ex As Exception
                    cmd.Parameters.Add("@pesquisa", "%")
                End Try

            Case 2
                If Trim(pesquisa).Equals("") Then
                    cmd.Parameters.Add("@pesquisa", "%")
                Else
                    cmd.Parameters.Add("@pesquisa", pesquisa.ToUpper & "%")
                End If

            Case 1
                cmd.Parameters.Add("@pesquisa", Convert.ChangeType(pesquisa, GetType(Date)))
                cmd.Parameters.Add("@pesquisa2", Convert.ChangeType(pesquisa2, GetType(Date)))

        End Select
        dr = cmd.ExecuteReader

        Dim mEntrada, mTgeral As Double
        Me.dtg_pedidos.Rows.Clear() : Me.dtg_pedidos.Refresh()
        While dr.Read

            Try
                mEntrada = dr(13)
            Catch ex As Exception
                mEntrada = 0
            End Try

            Try
                mTgeral = dr(8)
            Catch ex As Exception
                mTgeral = 0
            End Try

            Try
                dtg_pedidos.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, Format(Convert.ChangeType(dr(3), GetType(Date)), "dd/MM/yyyy"), _
                                 dr(4).ToString, dr(5).ToString, dr(6).ToString, dr(7).ToString, _
                                 Format(mTgeral, "###,##0.00"), dr(9).ToString, dr(10).ToString, dr(11), dr(12), Format(mEntrada, "###,##0.00"))
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End While
        dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length) : cmd.CommandText = "" : conn.ClearAllPools()
        conn.Close() : dr = Nothing : Sqlcomm = Nothing : cmd = Nothing : conn = Nothing
        Me.dtg_pedidos.Refresh()


    End Sub

    Private Sub executaF6()

        Select Case cbo_tiporelatorio.SelectedIndex
            Case 0 'Simples
                If (Me.dtg_pedidos.Rows.Count > _valorZERO) AndAlso (Me.dtg_pedidos.SelectedCells.Count > 0) Then
                    executaEspelho("", "\wged\relatorios\RelatorioFluxoPedi.txt")
                End If

            Case 1 'Analítico
                If (Me.dtg_pedidos.Rows.Count > _valorZERO) AndAlso (Me.dtg_pedidos.SelectedCells.Count > 0) Then
                    executaEspelho2("", "\wged\relatorios\RelatorioFluxoPedi.txt")
                End If

            Case 2 'Arquivo
                _frmREf = Me
                frmBuscaData.set_frmRef(Me)
                frmBuscaData.ShowDialog(Me)

                executaRelatorioFluxoArquivo("", "\wged\relatorios\RelatorioFluxoArquivo.txt")

            Case 3 'Movimento Caixa

                _frmREf = Me
                frmBuscaDataPeriodo.set_frmRef(Me)
                frmBuscaDataPeriodo.ShowDialog(Me)

                _frmREf = Me
                frmBuscaCodCaixa.set_frmRef(Me)
                frmBuscaCodCaixa.ShowDialog(Me)

                executaRelatorioMovimentoCaixa("", "\wged\relatorios\RelatorioMovimentoCaixa.txt")

            Case 4 ' Movimento Diário por Período
                _frmREf = Me
                frmBuscaDataPeriodo.set_frmRef(Me)
                frmBuscaDataPeriodo.ShowDialog(Me)

                executaRelatorioDiarioPeriodo("", "\wged\relatorios\RelatorioDiarioP.txt")

            Case 5 ' Movimento Diário por Dia
                _frmREf = Me
                frmBuscaData.set_frmRef(Me)
                frmBuscaData.ShowDialog(Me)

                executaRelatorioDiario("", "\wged\relatorios\RelatorioDiario.txt")

        End Select


    End Sub


#Region "Relatórios:"

#Region "   Movimento Diário por Período"


    Private Sub executaRelatorioDiario1Periodo(ByRef sw As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False

        'Variáveis Totais...
        Dim mFatura, mCodCliente, mNomeCliente, mDtEmiss, mDtVencimento, mDescrPagto, mFaturaLetra, mParcelas As String
        Dim mPosiParcela As Integer = 0, mDiasAtrazo As Integer = 0
        Dim mValor As Double = 0.0, mSomaValorDupliNorm As Double = 0.0, mSomaValorDupliParc As Double = 0.0
        Dim mJuros As Double = 0.0, mSomaJurosNorm As Double = 0.0, mSomaJurosParc As Double = 0.0
        Dim mTotal As Double = 0.0, mSomaTotalDuplic As Double = 0.0, mSomaTotalReceitas As Double = 0.0
        Dim mDataInicial As String = Format(dataInicialRef, "dd/MM/yyyy")
        Dim mDataFinal As String = Format(dataFinalRef, "dd/MM/yyyy")
        Dim mStrLinha As String = "", mStrLinhaAux As String = ""
        Dim mCaixa As String = ""

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try

        'Loja Cabeçalho #########################################
        _mConsulta = "SELECT g_geno, g_ender FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        GravCabLojDiario1Periodo(_mConsulta.ToString, sw, loja, mDataInicial, mDataFinal, oConnBD, lShouldReturn1)


        'Duplicatas de Recebimento Normais........
        _mConsulta = "SELECT f_portad, cad.p_portad, f_duplic, Substr(f_duplic, Length(f_duplic)), f_emiss, f_vencto, '', " & _
        "f_valor, f_juros, ((f_valor + f_juros) - f_desc) As ""total"", f_parcelas, f_caixa FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 " & _
        "LEFT JOIN cadp001 cad ON cad.p_cod = f_portad WHERE (f_dtpaga BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND (f_sit <> 'E' OR f_sitanterior = 'L')"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            mCodCliente = dr(0).ToString
            mNomeCliente = dr(1).ToString
            mFatura = dr(2).ToString
            mFaturaLetra = dr(3).ToString
            mDtEmiss = Format(Convert.ChangeType(dr(4), GetType(Date)), "dd/MM/yyyy")
            mDtVencimento = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            mDescrPagto = dr(6).ToString
            mPosiParcela = _funcoes.returnNumPosicaoLetraAlfab(mFaturaLetra)

            mDiasAtrazo = dataDoDiaRef.Subtract(Convert.ChangeType(mDtVencimento, GetType(Date))).Days


            Try
                mValor = dr(7)
                mSomaValorDupliNorm += mValor
            Catch ex As Exception
            End Try

            Try
                mJuros = dr(8)
                mSomaJurosNorm += mJuros
            Catch ex As Exception
            End Try

            Try
                mTotal = Round(dr(9), 2)
                mSomaTotalDuplic += mTotal
                mSomaTotalReceitas += mTotal
            Catch ex As Exception
            End Try


            mParcelas = dr(10).ToString.PadLeft(2, "0")
            mCaixa = dr(11).ToString
            'mCaixa = _clFunc.Centraliza_Str(mCaixa, 7)


            '| Codigo |       Cliente      | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo | Caixa |
            '|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|
            '|00001904987303|VERA LUCIA ALV|31802/02   |11/09/2013|11/11/2013|02|11| 140|    43,60|    0,40|     44,00|        |        |         |       |
            mStrLinha = "| " & mCodCliente & " | " & _funcoes.Exibe_StrEsquerda(mNomeCliente, 18) & "|"
            mStrLinha += _funcoes.Exibe_StrEsquerda(mFatura, 10) & " |" & mDtEmiss & "|" & mDtVencimento & "|"
            mStrLinha += Format(mPosiParcela, "00") & "|" & mParcelas & "|" & _funcoes.Exibe_StrDireita(mDiasAtrazo, 4) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mValor, "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mJuros, "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10)
            mStrLinha += "|        |        |         |" & mCaixa & "|"

            sw.EscreveLn(mStrLinha)

            mValor = 0.0 : mJuros = 0.0 : mTotal = 0.0 : mDiasAtrazo = 0
        End While
        dr.Close()



        'Duplicatas de recebimento Parciais...
        _mConsulta = "SELECT f_portad, cad.p_portad, f_duplic, Substr(f_duplic, Length(f_duplic)), f_emiss, f_vencto, '', " & _
        "f_valor, f_juros, ((f_valor + f_juros) - f_desc) As ""total"", f_caixa FROM " & MdlEmpresaUsu._esqEstab & ".fatdp02 " & _
        "LEFT JOIN cadp001 cad ON cad.p_cod = f_portad WHERE f_dtpaga BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            mCodCliente = dr(0).ToString
            mNomeCliente = dr(1).ToString
            mFatura = dr(2).ToString
            mFaturaLetra = dr(3).ToString
            mDtEmiss = Format(Convert.ChangeType(dr(4), GetType(Date)), "dd/MM/yyyy")
            mDtVencimento = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            mDescrPagto = dr(6).ToString
            mPosiParcela = _funcoes.returnNumPosicaoLetraAlfab(mFaturaLetra)

            mDiasAtrazo = dataDoDiaRef.Subtract(Convert.ChangeType(mDtVencimento, GetType(Date))).Days


            Try
                mValor = dr(7)
                mSomaValorDupliParc += mValor
            Catch ex As Exception
            End Try

            Try
                mJuros = dr(8)
                mSomaJurosParc += mJuros
            Catch ex As Exception
            End Try

            Try
                mTotal = Round(dr(9), 2)
                mSomaTotalDuplic += mTotal
                mSomaTotalReceitas += mTotal
            Catch ex As Exception
            End Try


            mParcelas = "00"
            mCaixa = dr(10).ToString
            'mCaixa = _clFunc.Centraliza_Str(mCaixa, 7)


            '| Codigo |       Cliente      | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo | Caixa |
            '|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|
            '|00001904987303|VERA LUCIA ALV|31802/02   |11/09/2013|11/11/2013|02|11| 140|    43,60|    0,40|     44,00|        |        |         |
            mStrLinha = "| " & mCodCliente & " | " & _funcoes.Exibe_StrEsquerda(mNomeCliente, 18) & "|"
            mStrLinha += _funcoes.Exibe_StrEsquerda(mFatura & "*", 11) & "|" & mDtEmiss & "|" & mDtVencimento & "|"
            mStrLinha += Format(mPosiParcela, "00") & "|" & mParcelas & "|" & _funcoes.Exibe_StrDireita(mDiasAtrazo, 4) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mValor, "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mJuros, "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10)
            mStrLinha += "|        |        |         |" & mCaixa & "|"

            sw.EscreveLn(mStrLinha)

            mValor = 0.0 : mJuros = 0.0 : mTotal = 0.0 : mDiasAtrazo = 0
        End While
        dr.Close()





        'Recebimento de Vendas A Vista....
        Dim mAvista As Double = 0.0, mSomaAvista As Double = 0.0


        'Recebimento de Entradas....
        Dim mEntrada As Double = 0.0, mSomaEntrada As Double = 0.0
        Dim mAPrazo As Double = 0.0, mSomaAPrazo As Double = 0.0
        _mConsulta = "SELECT DISTINCT ON (e_id) e_id, f_portad, cad.p_portad, f_nfat, f_emiss, f_vencto, e_entrada, f_parcelas " & _
        "FROM cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".entradafatd LEFT JOIN " & MdlEmpresaUsu._esqEstab & ".fatd001 " & _
        "ON Cast(f_nfat As Bigint) = e_duplicata WHERE cad.p_cod = f_portad AND (e_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "')"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            mCodCliente = dr(1).ToString
            mNomeCliente = dr(2).ToString
            mFatura = dr(3).ToString
            mDtEmiss = Format(Convert.ChangeType(dr(4), GetType(Date)), "dd/MM/yyyy")
            mDtVencimento = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            Try
                mParcelas = Format(CInt(dr(7)), "00")
            Catch ex As Exception
                mParcelas = "01"
            End Try


            Try
                mEntrada = dr(6)
                mSomaEntrada += mEntrada
                mSomaTotalReceitas += mEntrada
            Catch ex As Exception
            End Try



            '| Codigo |       Cliente      | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo |
            '|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|
            '|00001904987303|VERA LUCIA ALV|31802/02   |11/09/2013|11/11/2013|02|11| 140|    43,60|    0,40|     44,00|        |        |         |
            mStrLinha = "| " & mCodCliente & " | " & _funcoes.Exibe_StrEsquerda(mNomeCliente, 18) & "|"
            mStrLinha += _funcoes.Exibe_StrEsquerda("P-" & mFatura, 11) & "|" & mDtEmiss & "|          |"
            mStrLinha += "EN|" & mParcelas & "|    |         |        |          |        |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mEntrada, "#,##0.00"), 8) & "|         |"

            sw.EscreveLn(mStrLinha)

            mAvista = 0.0 : mAPrazo = 0.0
        End While
        dr.Close()



        If (sw.contLinhasPorPagina + 3) > sw.qtdLinhasPorPagina Then
            sw.SaltandoLinhasComEscreveLn(sw.qtdLinhasPorPagina - sw.contLinhasPorPagina)
            sw.EscreveLn("|-------------------------------------------------------------------------+---------+--------+----------+--------+--------+---------|")
            mStrLinha = "|                                                    Total do dia         |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliNorm + mSomaValorDupliParc, 2), "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaJurosNorm + mSomaJurosParc, 2), "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalDuplic, 2), "###,##0.00"), 10) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaAvista, 2), "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaEntrada, 2), "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaAPrazo, 2), "##,##0.00"), 9) & "|"
            sw.EscreveLn(mStrLinha)
            sw.EscreveLn("+===================================================================================================================================+")

        Else

            sw.EscreveLn("|-------------------------------------------------------------------------+---------+--------+----------+--------+--------+---------|")
            mStrLinha = "|                                                    Total do dia         |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliNorm + mSomaValorDupliParc, 2), "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaJurosNorm + mSomaJurosParc, 2), "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalDuplic, 2), "###,##0.00"), 10) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaAvista, 2), "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaEntrada, 2), "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaAPrazo, 2), "##,##0.00"), 9) & "|"
            sw.EscreveLn(mStrLinha)
            sw.EscreveLn("+===================================================================================================================================+")

        End If


        sw.strInicioLinha = _StrAuxDiarioDupliReceb
        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        RemoveHandler sw.SaltandoLinhasEvento, AddressOf GravCabLojDiario1
        AddHandler sw.SaltandoLinhasEvento, AddressOf GravCabLojDiarioPagDuplicPeriodo
        sw.SaltandoLinhasComEscreveLn(sw.qtdLinhasPorPagina - sw.contLinhasPorPagina)





        'Pagamento de Duplicatas...
        Dim codCliente, portad, nfat, duplic, nfisc, emiss, vencto, mLetra, numParcelaStr As String
        Dim valor, juros, desc, total, mSomaTotalDespesas As Double
        Dim mNumParcela As Integer
        Dim mStrBDespCred As New StringBuilder
        _mConsulta = "SELECT d_portad, cad.p_portad, d_duplic, Substr(d_duplic, Length(d_duplic)), d_nfisc, d_emiss, d_vencto, d_valor, d_juros, d_desc, " & _
        "((d_valor + d_juros) - d_desc) As ""total"", d_nfat, d_caixa FROM fatp001 LEFT JOIN cadp001 cad ON cad.p_cod = d_portad " & _
        "WHERE d_geno = '" & MdlEmpresaUsu._codigo & "' AND (d_dtpaga BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND " & _
        "(d_sit <> 'E' OR d_sitanterior = 'L') ORDER BY d_duplic ASC"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            codCliente = dr(0).ToString
            portad = dr(1).ToString
            duplic = dr(2).ToString
            mLetra = dr(3).ToString
            nfisc = dr(4).ToString
            emiss = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            vencto = Format(Convert.ChangeType(dr(6), GetType(Date)), "dd/MM/yyyy")
            mNumParcela = _funcoes.returnNumPosicaoLetraAlfab(mLetra)
            numParcelaStr = Format(mNumParcela, "00")
            nfat = dr(11).ToString
            duplic = nfat & "/" & numParcelaStr

            Try
                total = dr(10)
                mSomaTotalDespesas += total
            Catch ex As Exception
            End Try
            mCaixa = dr(12).ToString
            mCaixa = _clFunc.Centraliza_Str(mCaixa, 7)



            '| Codigo |             Fornecedor              |  Duplicata  | N. Fiscal|  Emissao |Vencimento|  Valor   |
            mStrLinha = "| " & _funcoes.Exibe_StrEsquerda(codCliente, 6) & " | " & _funcoes.Exibe_StrEsquerda(portad, 48) & " |"
            mStrLinha += _funcoes.Exibe_StrDireita(duplic, 12) & " |" & _funcoes.Exibe_StrDireita(nfisc, 9) & " |" & emiss & "|" & vencto & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(total, "###,##0.00"), 10) & "|" & mCaixa & "|"

            sw.EscreveLn(mStrLinha)

            mStrBDespCred.Append(duplic & "|" & total & "?")

            mValor = 0.0 : mJuros = 0.0 : mTotal = 0.0 : mDiasAtrazo = 0
        End While
        dr.Close()



        'Pagamento Parcial de Duplicatas...
        _mConsulta = "SELECT d_portad, cad.p_portad, d_duplic, Substr(d_duplic, Length(d_duplic)), d_emiss, d_vencto, '', " & _
        "d_valor, d_juros, ((d_valor + d_juros) - d_desc) As ""total"", d_caixa FROM fatp002 " & _
        "LEFT JOIN cadp001 cad ON cad.p_cod = d_portad WHERE d_geno = '" & MdlEmpresaUsu._codigo & "' AND d_dtpaga BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            mCodCliente = dr(0).ToString
            mNomeCliente = dr(1).ToString
            mFatura = dr(2).ToString
            mFaturaLetra = dr(3).ToString
            mDtEmiss = Format(Convert.ChangeType(dr(4), GetType(Date)), "dd/MM/yyyy")
            mDtVencimento = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            mDescrPagto = dr(6).ToString
            mPosiParcela = _funcoes.returnNumPosicaoLetraAlfab(mFaturaLetra)

            mDiasAtrazo = dataDoDiaRef.Subtract(Convert.ChangeType(mDtVencimento, GetType(Date))).Days


            Try
                mValor = dr(7)
                mSomaValorDupliParc += mValor
            Catch ex As Exception
            End Try

            Try
                mJuros = dr(8)
                mSomaJurosParc += mJuros
            Catch ex As Exception
            End Try

            Try
                mTotal = Round(dr(9), 2)
                mSomaTotalDespesas += mTotal
            Catch ex As Exception
            End Try
            mCaixa = dr(10).ToString
            mCaixa = _clFunc.Centraliza_Str(mCaixa, 7)


            '| Codigo |       Cliente      | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo |
            '|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|
            '|00001904987303|VERA LUCIA ALV|31802/02   |11/09/2013|11/11/2013|02|11| 140|    43,60|    0,40|     44,00|        |        |         |
            mStrLinha = "| " & mCodCliente & " | " & _funcoes.Exibe_StrEsquerda(mNomeCliente, 48) & " |"
            mStrLinha += _funcoes.Exibe_StrEsquerda(mFatura & "*", 11) & "|" & mDtEmiss & "|" & mDtVencimento & "|"
            mStrLinha += Format(mPosiParcela, "00") & "|" & mParcelas & "|" & _funcoes.Exibe_StrDireita(mDiasAtrazo, 4) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mValor, "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mJuros, "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10)
            mStrLinha += "|        |        |         |" & mCaixa & "|"

            sw.EscreveLn(mStrLinha)

            mValor = 0.0 : mJuros = 0.0 : mTotal = 0.0 : mDiasAtrazo = 0
        End While
        dr.Close()

        sw.EscreveLn("+=====================================================================================================================+")





        sw.strInicioLinha = "       "
        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        RemoveHandler sw.SaltandoLinhasEvento, AddressOf GravCabLojDiarioPagDuplicPeriodo
        AddHandler sw.SaltandoLinhasEvento, AddressOf GravaCabDespCreditoPeriodo
        sw.SaltandoLinhasComEscreveLn(sw.qtdLinhasPorPagina - sw.contLinhasPorPagina)


        'Despesas e Creditos do CAIXA por caixa...
        Dim sldAnteriorCX As Double
        Dim mData As String = "", mDescricao As String = ""

        'Consulta de Abertura do CAIXA:
        _mConsulta = "SELECT Sum(cx_valor), cx_data, cx_caixa FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario GROUP BY cx_valor, cx_data, " & _
        "cx_loja, cx_caixa, cx_tipo HAVING cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND cx_data = (SELECT Max(cx_data) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_tipo = 'A' AND cx_data BETWEEN '" & _
        mDataInicial & "' AND '" & mDataFinal & "') AND cx_tipo = 'A' ORDER BY cx_data"
        '04/07/2015') '" & mDataInicial & "' AND '" & mDataFinal & "') AND cx_tipo = 'A' ORDER BY cx_data"
        'If MdlUsuarioLogando._codcaixa.Equals("") = False Then _mConsulta += "AND cx_caixa = '" & MdlUsuarioLogando._codcaixa & "' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                sldAnteriorCX += 0 'dr(0)
                mSomaTotalReceitas += 0 'dr(0)
            Catch ex As Exception
                sldAnteriorCX = 0
            End Try

            Try
                mData = Format(Convert.ChangeType(dr(1), GetType(Date)), "dd/MM/yyyy")
            Catch ex As Exception
                mData = "          "
            End Try


            '|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |                    |
            mStrLinha = "|" & mData & "|ABERTURA      |001| ULTIMA ABERTURA DO CAIXA  -  " & dr(2).ToString & "                            |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(sldAnteriorCX, "###,##0.00"), 12) & "|             |"

            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()

        'Recebimentos lançados manualmente:
        Dim mtotDespManual, mtotRecebManual As Double
        _mConsulta = "SELECT cx_valor, cx_data, cx_caixa, cx_descricao FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND (cx_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND cx_tipo = 'R' "
        'If MdlUsuarioLogando._codcaixa.Equals("") = False Then _mConsulta += "AND cx_caixa = '" & MdlUsuarioLogando._codcaixa & "' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mtotRecebManual += dr(0)
                mSomaTotalReceitas += dr(0)
            Catch ex As Exception
                mtotRecebManual = 0
            End Try

            mDescricao = "R: " & Mid(dr(3).ToString, 1, 57)

            Try
                mData = Format(Convert.ChangeType(dr(1), GetType(Date)), "dd/MM/yyyy")
            Catch ex As Exception
                mData = "          "
            End Try

            '|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|LANCAMENTO    |500|" & _clFunc.Exibe_StrEsquerda(mDescricao, 61) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(dr(0), "###,##0.00"), 12) & "|             |"

            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()


        'Pagamentos feitos Manualmente
        _mConsulta = "SELECT cx_valor, cx_data, cx_caixa, cx_descricao FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND (cx_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND cx_tipo = 'P' "
        'If MdlUsuarioLogando._codcaixa.Equals("") = False Then _mConsulta += "AND cx_caixa = '" & MdlUsuarioLogando._codcaixa & "' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mtotDespManual += dr(0)
                mSomaTotalDespesas += dr(0)
            Catch ex As Exception
                mtotDespManual = 0
            End Try


            mDescricao = "P: " & Mid(dr(3).ToString, 1, 57)

            Try
                mData = Format(Convert.ChangeType(dr(1), GetType(Date)), "dd/MM/yyyy")
            Catch ex As Exception
                mData = "          "
            End Try

            '|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|LANCAMENTO    |001|" & _clFunc.Exibe_StrEsquerda(mDescricao, 61) & "|"
            mStrLinha += "            |" & _funcoes.Exibe_StrDireita(Format(dr(0), "###,##0.00"), 13) & "|"

            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()


        'Divisorias feitos Manualmente
        _mConsulta = "SELECT cx_valor, cx_data, cx_caixa, cx_descricao FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND (cx_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND cx_tipo = 'D' "
        'If MdlUsuarioLogando._codcaixa.Equals("") = False Then _mConsulta += "AND cx_caixa = '" & MdlUsuarioLogando._codcaixa & "' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mtotDespManual += dr(0)
                mSomaTotalDespesas += dr(0)
            Catch ex As Exception
                mtotDespManual = 0
            End Try


            mDescricao = "D: " & Mid(dr(3).ToString, 1, 57)

            Try
                mData = Format(Convert.ChangeType(dr(1), GetType(Date)), "dd/MM/yyyy")
            Catch ex As Exception
                mData = "          "
            End Try

            '|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|LANCAMENTO    |888|" & _clFunc.Exibe_StrEsquerda(mDescricao, 61) & "|"
            mStrLinha += "            |" & _funcoes.Exibe_StrDireita(Format(dr(0), "###,##0.00"), 13) & "|"

            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()

        sw.EscreveLn("+======================================================================================================================+")
        sw.EscreveLn("|-------------------------------------------------------------------------------------------+------------+-------------|")
        mStrLinha = "|                             Total De Credito/Despesas ..........                          |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(sldAnteriorCX + Round(mtotRecebManual, 2), "###,##0.00"), 12) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita("-" & Format(Round(mtotDespManual, 2), "###,##0.00"), 13) & "|"
        sw.EscreveLn(mStrLinha)
        sw.EscreveLn("+======================================================================================================================+")





        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        RemoveHandler sw.SaltandoLinhasEvento, AddressOf GravaCabDespCreditoPeriodo
        AddHandler sw.SaltandoLinhasEvento, AddressOf GravaCabDespCreditoOUTROS
        sw.SaltandoLinhasComEscreveLn(sw.qtdLinhasPorPagina - sw.contLinhasPorPagina)


        'Despesas e Creditos do Plano de Contas...  ################
        Dim mValorAux As Double = 0.0, mTotalRecebOUTROS As Double = 0.0, mTotalDespOUTROS As Double = 0.0
        'Despesas:
        _mConsulta = "SELECT Sum(dm_valor) FROM " & MdlEmpresaUsu._esqEstab & ".despm002 WHERE dm_firma = '0" & mLoja & "' AND " & _
        "(dm_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND dm_tipo = 'P' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mValorAux = dr(0)
                mSomaTotalDespesas += mValorAux
                mTotalDespOUTROS += mValorAux
            Catch ex As Exception
                mValorAux = 0
            End Try


            '|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|DESPESAS      | P |PAGAMENTOS EFETUADOS                           |"
            mStrLinha += "            |" & _funcoes.Exibe_StrDireita(Format(mValorAux, "###,##0.00"), 12) & " |"

            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()


        'Recebimentos:
        _mConsulta = "SELECT Sum(dm_valor) FROM " & MdlEmpresaUsu._esqEstab & ".despm002 WHERE dm_firma = '0" & mLoja & "' AND " & _
        "(dm_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND dm_tipo = 'R' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mValorAux = dr(0)
                mSomaTotalReceitas += mValorAux
                mTotalRecebOUTROS += mValorAux
            Catch ex As Exception
                mValorAux = 0
            End Try


            '|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|RECEITAS      | R |RECEBIMENTOS EFETUADOS                         |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mValorAux, "###,##0.00"), 12) & "|             |"

            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()
        sw.EscreveLn("|-----------------------------------------------------------------------------+------------+-------------|")
        mStrLinha = "|                             Total De Credito/Despesas ..........            |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mTotalRecebOUTROS, 2), "###,##0.00"), 12) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita("-" & Format(Round(mTotalDespOUTROS, 2), "###,##0.00"), 13) & "|"
        sw.EscreveLn(mStrLinha)
        sw.EscreveLn("+========================================================================================================+")





        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        RemoveHandler sw.SaltandoLinhasEvento, AddressOf GravaCabDespCreditoOUTROS
        sw.chamaEvento = False
        sw.SaltandoLinhasComEscreveLn(sw.qtdLinhasPorPagina - sw.contLinhasPorPagina)


        'FINALIZANDO   ......................................
        'mSomaTotalDespesas += Round(mtotDespManual, 2)
        Dim mDiaAnterior As Date = DateSerial(dataDoDiaRef.Year, dataDoDiaRef.Month, dataDoDiaRef.Day - 1)
        sw.EscreveLn("             ******************************************************************************")
        mStrLinha = "             * S A L D O  D I A   A N T E R I O R  (  Período  ) "
        mStrLinha += "  << " & _funcoes.Exibe_StrDireita(Format(sldAnteriorCX, "###,##0.00"), 13) & " >>    *"
        sw.EscreveLn(mStrLinha)
        sw.EscreveLn("             ******************************************************************************")
        'Loja Cabeçalho #########################################
        _mConsulta = "SELECT g_geno, g_ender FROM geno001 WHERE g_codig = '" & loja & "'"
        GravCabSLDAnteriorPeriodo(_mConsulta.ToString, sw, loja, mData, oConnBD, lShouldReturn1)
        sw.EscreveLn("")
        sw.EscreveLn("")
        sw.EscreveLn("                                  RESUMO DO MOVIMENTO NO CAIXA")
        sw.EscreveLn("")
        sw.EscreveLn("       +===========================================================================================+")
        sw.EscreveLn("       |         Descricao do Movimento        |    Valor     |     Juros    |  Total do Movimento |")
        sw.EscreveLn("       |---------------------------------------+--------------+--------------+---------------------|")

        mStrLinha = "       | Recebimento de Duplicatas       [+]   |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliNorm, 2), "#,###,##0.00"), 14) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaJurosNorm, 2), "#,###,##0.00"), 14) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliNorm + mSomaJurosNorm, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        mStrLinha = "       | Recebimento de Avista           [+]   |              |              |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaAvista, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        mStrLinha = "       | Recebimento de Entrada          [+]   |              |              |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaEntrada, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        mStrLinha = "       | Recebimento Parcial Duplicatas  [+]   |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliParc, 2), "#,###,##0.00"), 14) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaJurosParc, 2), "#,###,##0.00"), 14) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliParc + mSomaJurosParc, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        sw.EscreveLn("       | Recebimento de Outras Lojas     [+]   |          0,00|          0,00|                 0,00|")
        sw.EscreveLn("       | Estorno de Duplicatas           [-]   |          0,00|          0,00|                 0,00|")
        sw.EscreveLn("       |---------------------------------------+--------------+--------------+---------------------|")

        mStrLinha = "       | Sub Total do Caixa              [=]   |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliNorm + mSomaValorDupliParc, 2), "#,###,##0.00"), 14) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaJurosNorm + mSomaJurosParc, 2), "#,###,##0.00"), 14) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalDuplic + mSomaAvista + mSomaEntrada, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        sw.EscreveLn("       |-------------------------------------------------------------------------------------------|")
        sw.EscreveLn("       | Entrada Pedidos Renegociados    [+]                                 |                 0,00|")
        sw.EscreveLn("       |-------------------------------------------------------------------------------------------|")

        mStrLinha = "       | Despesas no Caixa               [-]                                 |"
        mStrLinha += _funcoes.Exibe_StrDireita("-" & Format(Round(mSomaTotalDespesas, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        mStrLinha = "       | Credito  no Caixa               [+]                                 |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalReceitas, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        sw.EscreveLn("       |---------------------------------------------------------------------+---------------------|")
        mStrLinha = "       | Total do Caixa                  [=]                                 |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalReceitas - mSomaTotalDespesas, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        sw.EscreveLn("       |-------------------------------------------------------------------------------------------|")
        sw.EscreveLn("       |                                                                                           |")
        sw.EscreveLn("       +===========================================================================================+")
        mStrLinha = "       | Total Venda A Prazo             [=]                                 |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaAPrazo, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        sw.EscreveLn("       | Total A Prazo Regenociado       [=]                                 |                 0,00|")
        sw.EscreveLn("       | Total Venda Cancelada           [=]                                 |                 0,00|")
        sw.EscreveLn("       | Total Venda MR                  [=]                                 |                 0,00|")
        sw.EscreveLn("       +===========================================================================================+")
        sw.EscreveLn("")
        sw.EscreveLn("")
        sw.EscreveLn("             ******************************************************************************")
        sw.EscreveLn("             *              T O T A L   D O   C A I X A            << " & _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalReceitas - mSomaTotalDespesas, 2), "#,###,##0.00"), 13) & " >>    *")
        sw.EscreveLn("             ******************************************************************************")
        sw.EscreveLn("")



        Try
            oConnBD.ClearAllPools()
            oConnBD.Close() : oConnBD = Nothing
        Catch ex As Exception
        End Try

    End Sub

    Private Sub executaRelatorioDiarioPeriodo(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\tmp\TEMPRelatorioDiarioP.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\wged\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        sw = New Cl_EscreveArquivo(fs)
        sw.chamaEvento = True
        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler sw.SaltandoLinhasEvento, AddressOf GravCabLojDiario1
        sw.qtdLinhasPorPagina = 56
        sw.qtdSaltosLinhaNextPag = 0
        _PrintFont1 = New Font("Lucida Console", 9.3) 'Sans Serif


        'Ajuda a contar caracteres da pagina...
        ''                      1         2         3         4         5         6         7         8         9         0         1         2         3         4         5
        ''             123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        'sw.EscreveLn("+====================================================================================================================================+")

        Dim loja As String = MdlUsuarioLogando._local

        'Relatório 1º .........................................
        Try

            Dim lShouldReturn As Boolean
            executaRelatorioDiario1Periodo(sw, loja, lShouldReturn)
            If lShouldReturn Then Return
        Catch ex As Exception

            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception

                Try
                    fs = New FileStream("\wged\new.TMP", FileMode.Create, FileAccess.ReadWrite)
                Catch ex2 As Exception
                End Try

            End Try
        End Try


        'Deleta o arquivo temporário...
        sw.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        sw.Dispose()
        File.Delete(mArqTemp)

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuContRelatorioDiario()
        _StringToPrint = ""

    End Sub

    Public Sub GravCabLojDiario1Periodo(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, ByVal loja As String, _
                                           ByVal dataInicial As String, ByVal dataFinal As String, ByVal oConnBD As NpgsqlConnection, _
                                           ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = "", strAux2 As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja, cnpjLoja As String

            nomeLoja = "" : enderLoja = "" : foneLoja = "" : ufLoja = "" : cidLoja = "" : cnpjLoja = ""
            While dr.Read

                nomeLoja = dr(0).ToString : enderLoja = dr(1).ToString
                'foneLoja = dr(2).ToString : ufLoja = dr(3).ToString
                'cidLoja = dr(4).ToString : cnpjLoja = dr(5).ToString
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            '                      1         2         3         4         5         6         7         8         9         0         1         2         3
            '             12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234
            sw.EscreveLn("+===================================================================================================================================+")
            strAux = _funcoes.Exibe_StrEsquerda("|" & _local & " - " & nomeLoja, 68) & " "
            strAux += _funcoes.Exibe_StrEsquerda("Data Emissao.: " & Format(Date.Now, "dd/MM/yyyy"), 48) & " "
            strAux += _funcoes.Exibe_StrEsquerda("Pagina .: " & String.Format("{0:D3}", sw.paginaAtual), 14) & "|"
            sw.EscreveLn(strAux)
            sw.EscreveLn("|                                                                    " & _funcoes.Exibe_StrEsquerda("Data do Caixa: " & Format(Convert.ChangeType(dataInicial, GetType(Date)), "dd/MM/yyyy") & " A " & Format(Convert.ChangeType(dataFinal, GetType(Date)), "dd/MM/yyyy"), 63) & "|")
            sw.EscreveLn("|                                                                                                                                   |")
            sw.EscreveLn("|                        Relatorio de Caixa Diario Receber                                                                          |")
            sw.EscreveLn("|                                                                         |-----------------------------+---------------------------|")
            sw.EscreveLn("|                                                                         |       R E C E B I D O       |  V E N D A S  D O  D I A  |")
            sw.EscreveLn("|--------+-------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|---|")
            sw.EscreveLn("| Codigo |       Cliente     | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo | CX|")
            sw.EscreveLn("|--------+-------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|---|")


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Public Sub GravaCabDespCreditoPeriodo()

        '106 caracteres...
        sw.EscreveLn("+======================================================================================================================+")
        sw.EscreveLn("|                      C R E D I T O / D E S P E S A S       N O      C A I X A            *Lancamentos manuais        |")
        sw.EscreveLn("|                                                                                                                      |")
        sw.EscreveLn("|----------+--------------+---+-------------------------------------------------------------+------------+-------------|")
        sw.EscreveLn("|   Data   |   Documento  | T |                   Historico                                 |  Credito   |  Despesas   |")
        sw.EscreveLn("|----------+--------------+---+-------------------------------------------------------------+------------+-------------|")

    End Sub

    Public Sub GravCabLojDiarioPagDuplicPeriodo()

        Dim mData As String = Format(dataDoDiaRef, "dd/MM/yyyy")
        Dim loja As String = MdlUsuarioLogando._local

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try
        sw.strInicioLinha = "      "
        'Loja Cabeçalho #########################################
        _mConsulta = "SELECT g_geno, g_ender FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        GravCabLojDiarioPagDuplicPeriodo(_mConsulta.ToString, sw, loja, dataInicialRef, dataFinalRef, oConnBD, lShouldReturn1)


    End Sub

    Public Sub GravCabLojDiarioPagDuplicPeriodo(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, ByVal loja As String, _
                                           ByVal dataInicial As String, ByVal dataFinal As String, ByVal oConnBD As NpgsqlConnection, _
                                           ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = "", strAux2 As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja, cnpjLoja As String

            nomeLoja = "" : enderLoja = "" : foneLoja = "" : ufLoja = "" : cidLoja = "" : cnpjLoja = ""
            While dr.Read

                nomeLoja = dr(0).ToString : enderLoja = dr(1).ToString
                'foneLoja = dr(2).ToString : ufLoja = dr(3).ToString
                'cidLoja = dr(4).ToString : cnpjLoja = dr(5).ToString
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            '                      1         2         3         4         5         6         7         8         9         0         1         2         3
            '             12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234
            sw.EscreveLn("+=====================================================================================================================+")
            strAux = _funcoes.Exibe_StrEsquerda("|" & _local & " - " & nomeLoja, 45) & " "
            strAux += _funcoes.Exibe_StrEsquerda("Data do Caixa.: " & Format(Convert.ChangeType(dataInicial, GetType(Date)), "dd/MM/yyyy") & " A " & Format(Convert.ChangeType(dataFinal, GetType(Date)), "dd/MM/yyyy"), 41) & " |-----------------------------|"
            sw.EscreveLn(strAux)
            sw.EscreveLn("|                                                                                       |  PAGAMENTO DE DUPLICATAS    |")
            sw.EscreveLn("|--------+--------------------------------------------------+-------------+----------+----------+----------+----------|-------|")
            sw.EscreveLn("| Codigo |             Fornecedor                           |  Duplicata  | N. Fiscal|  Emissao |Vencimento|  Valor   | Caixa |")
            sw.EscreveLn("|--------+--------------------------------------------------+-------------+----------+----------+----------+----------|-------|")


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Cabeçalho da Loja DUPLICATAS:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Public Sub GravCabSLDAnteriorPeriodo(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, ByVal loja As String, _
                                           ByVal dataRelatorio As String, ByVal oConnBD As NpgsqlConnection, _
                                           ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = "", strAux2 As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja, cnpjLoja As String

            nomeLoja = "" : enderLoja = "" : foneLoja = "" : ufLoja = "" : cidLoja = "" : cnpjLoja = ""
            While dr.Read

                nomeLoja = dr(0).ToString : enderLoja = dr(1).ToString
                'foneLoja = dr(2).ToString : ufLoja = dr(3).ToString
                'cidLoja = dr(4).ToString : cnpjLoja = dr(5).ToString
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            '                      1         2         3         4         5         6         7         8         9         0         1         2         3
            '             12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234
            strAux = _funcoes.Exibe_StrEsquerda("        Empresa.: " & _local & " - " & nomeLoja, 59) & " "
            strAux += _funcoes.Exibe_StrDireita("Data do Caixa: " & Format(Convert.ChangeType(dataInicialRef, GetType(Date)), "dd/MM/yyyy") & " A " & Format(Convert.ChangeType(dataFinalRef, GetType(Date)), "dd/MM/yyyy"), 38)
            sw.EscreveLn(strAux)


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

#End Region

#Region "   Movimento Diário por Dia"

    Private Sub VisuContRelatorioDiario()

        Try

            ' Especifica as configurações da pagina atual
            pdRelatPedidos.DefaultPageSettings = _PrintPageSettings

            'Configurando margens 39 = 1cm
            pdRelatPedidos.DefaultPageSettings.Margins.Top = 59
            pdRelatPedidos.DefaultPageSettings.Margins.Right = 20
            pdRelatPedidos.DefaultPageSettings.Margins.Left = 39
            pdRelatPedidos.DefaultPageSettings.Margins.Bottom = 40

            'Orientação em Retrato...
            pdRelatPedidos.DefaultPageSettings.Landscape = True
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando RELATÓRIO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatPedidos
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False
            _StringToPrint = "" : _StringToPrintItens = ""

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Public Sub GravCabLojDiario1()

        Dim mData As String = Format(dataDoDiaRef, "dd/MM/yyyy")
        Dim loja As String = MdlUsuarioLogando._local

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try

        'Loja Cabeçalho #########################################
        ', g_fone, g_uf, g_cid, g_cgc
        'Caracteres na Pagin 134
        'sw.WriteLine("+=================================[Continua na Proxima Pagina...]================================================+")
        'sw.SaltandoLinhas(4)
        _mConsulta = "SELECT g_geno, g_ender FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        GravCabLojDiario1(_mConsulta.ToString, sw, loja, mData, oConnBD, lShouldReturn1)


    End Sub

    'Cabeçalho da Loja Movimento Diario...
    Public Sub GravCabLojDiario1(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, ByVal loja As String, _
                                           ByVal dataRelatorio As String, ByVal oConnBD As NpgsqlConnection, _
                                           ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = "", strAux2 As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja, cnpjLoja As String

            nomeLoja = "" : enderLoja = "" : foneLoja = "" : ufLoja = "" : cidLoja = "" : cnpjLoja = ""
            While dr.Read

                nomeLoja = dr(0).ToString : enderLoja = dr(1).ToString
                'foneLoja = dr(2).ToString : ufLoja = dr(3).ToString
                'cidLoja = dr(4).ToString : cnpjLoja = dr(5).ToString
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            '                      1         2         3         4         5         6         7         8         9         0         1         2         3
            '             12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234
            sw.EscreveLn("+====================================================================================================================================+")
            strAux = _funcoes.Exibe_StrEsquerda("|" & _local & " - " & nomeLoja, 68) & " "
            strAux += _funcoes.Exibe_StrEsquerda("Data Emissao.: " & Format(Date.Now, "dd/MM/yyyy"), 49) & " "
            strAux += _funcoes.Exibe_StrEsquerda("Pagina .: " & String.Format("{0:D3}", sw.paginaAtual), 14) & "|"
            sw.EscreveLn(strAux)
            sw.EscreveLn("|                                                                    " & _funcoes.Exibe_StrEsquerda("Data do Caixa: " & Format(Convert.ChangeType(dataRelatorio, GetType(Date)), "dd/MM/yyyy"), 64) & "|")
            sw.EscreveLn("|                                                                                                                                    |")
            sw.EscreveLn("|                        Relatorio de Caixa Diario Receber                                                                           |")
            sw.EscreveLn("|                                                                          |-----------------------------+---------------------------|")
            sw.EscreveLn("|                                                                          |       R E C E B I D O       |  V E N D A S  D O  D I A  |")
            sw.EscreveLn("|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|---|")
            sw.EscreveLn("| Codigo |       Cliente      | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo | CX|")
            sw.EscreveLn("|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|---|")


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Public Sub GravCabLojDiarioPagDuplic()

        Dim mData As String = Format(dataDoDiaRef, "dd/MM/yyyy")
        Dim loja As String = MdlUsuarioLogando._local

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try

        'Loja Cabeçalho #########################################
        _mConsulta = "SELECT g_geno, g_ender FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        GravCabLojDiarioPagDuplic(_mConsulta.ToString, sw, loja, mData, oConnBD, lShouldReturn1)


    End Sub

    Public Sub GravCabLojDiarioPagDuplic(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, ByVal loja As String, _
                                           ByVal dataRelatorio As String, ByVal oConnBD As NpgsqlConnection, _
                                           ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = "", strAux2 As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja, cnpjLoja As String

            nomeLoja = "" : enderLoja = "" : foneLoja = "" : ufLoja = "" : cidLoja = "" : cnpjLoja = ""
            While dr.Read

                nomeLoja = dr(0).ToString : enderLoja = dr(1).ToString
                'foneLoja = dr(2).ToString : ufLoja = dr(3).ToString
                'cidLoja = dr(4).ToString : cnpjLoja = dr(5).ToString
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            '                      1         2         3         4         5         6         7         8         9         0         1         2         3
            '             12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234
            sw.EscreveLn("+========================================================================================================+")
            strAux = _funcoes.Exibe_StrEsquerda("|" & _local & " - " & nomeLoja, 45) & " "
            strAux += _funcoes.Exibe_StrEsquerda("Data do Caixa.: " & Format(Date.Now, "dd/MM/yyyy"), 28) & " |-----------------------------|"
            sw.EscreveLn(strAux)
            sw.EscreveLn("|                                                                          |  PAGAMENTO DE DUPLICATAS    |")
            sw.EscreveLn("|--------+-------------------------------------+-------------+----------+----------+----------+----------|-------|")
            sw.EscreveLn("| Codigo |             Fornecedor              |  Duplicata  | N. Fiscal|  Emissao |Vencimento|  Valor   | Caixa |")
            sw.EscreveLn("|--------+-------------------------------------+-------------+----------+----------+----------+----------|-------|")


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Cabeçalho da Loja DUPLICATAS:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Public Sub GravaCabDespCredito()

        '106 caracteres...
        sw.EscreveLn("+========================================================================================================+")
        sw.EscreveLn("|                      C R E D I T O / D E S P E S A S       N O      C A I X A     *Lancamentos manuais |")
        sw.EscreveLn("|                                                                                                        |")
        sw.EscreveLn("|----------+--------------+---+-----------------------------------------------+------------+-------------|")
        sw.EscreveLn("|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |")
        sw.EscreveLn("|----------+--------------+---+-----------------------------------------------+------------+-------------|")

    End Sub

    Public Sub GravaCabDespCreditoOUTROS()

        '106 caracteres...
        sw.EscreveLn("+========================================================================================================+")
        sw.EscreveLn("|                    C R E D I T O / D E S P E S A S     A D I C I O N A I S     *Lancamentos adicionais |")
        sw.EscreveLn("|                                                                                                        |")
        sw.EscreveLn("|----------+--------------+---+-----------------------------------------------+------------+-------------|")
        sw.EscreveLn("|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |")
        sw.EscreveLn("|----------+--------------+---+-----------------------------------------------+------------+-------------|")

    End Sub

    'Cabeçalho...
    Public Sub GravCabSLDAnterior(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, ByVal loja As String, _
                                           ByVal dataRelatorio As String, ByVal oConnBD As NpgsqlConnection, _
                                           ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = "", strAux2 As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja, cnpjLoja As String

            nomeLoja = "" : enderLoja = "" : foneLoja = "" : ufLoja = "" : cidLoja = "" : cnpjLoja = ""
            While dr.Read

                nomeLoja = dr(0).ToString : enderLoja = dr(1).ToString
                'foneLoja = dr(2).ToString : ufLoja = dr(3).ToString
                'cidLoja = dr(4).ToString : cnpjLoja = dr(5).ToString
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            '                      1         2         3         4         5         6         7         8         9         0         1         2         3
            '             12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234
            strAux = _funcoes.Exibe_StrEsquerda("        Empresa.: " & _local & " - " & nomeLoja, 67) & " "
            strAux += _funcoes.Exibe_StrDireita("Data do Caixa: " & Format(Convert.ChangeType(dataRelatorio, GetType(Date)), "dd/MM/yyyy"), 30)
            sw.EscreveLn(strAux)


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Private Sub executaRelatorioDiario1(ByRef sw As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False

        'Variáveis Totais...
        Dim mFatura, mCodCliente, mNomeCliente, mDtEmiss, mDtVencimento, mDescrPagto, mFaturaLetra, mParcelas As String
        Dim mPosiParcela As Integer = 0, mDiasAtrazo As Integer = 0
        Dim mValor As Double = 0.0, mSomaValorDupliNorm As Double = 0.0, mSomaValorDupliParc As Double = 0.0
        Dim mJuros As Double = 0.0, mSomaJurosNorm As Double = 0.0, mSomaJurosParc As Double = 0.0, mSomaValorDuplNorm As Double = 0.0
        Dim mTotal As Double = 0.0, mSomaTotalDuplic As Double = 0.0, mSomaTotalReceitas As Double = 0.0
        Dim mData As String = Format(dataDoDiaRef, "dd/MM/yyyy")
        Dim mStrLinha As String = "", mStrLinhaAux As String = ""
        Dim mCaixa As String = ""

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try

        'Loja Cabeçalho #########################################
        _mConsulta = "SELECT g_geno, g_ender FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        GravCabLojDiario1(_mConsulta.ToString, sw, loja, mData, oConnBD, lShouldReturn1)


        'Duplicatas de Recebimento........
        _mConsulta = "SELECT f_portad, cad.p_portad, f_duplic, Substr(f_duplic, Length(f_duplic)), f_emiss, f_vencto, '', " & _
        "f_valor, f_juros, ((f_valor + f_juros) - f_desc) As ""total"", f_parcelas, f_caixa FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 " & _
        "LEFT JOIN cadp001 cad ON cad.p_cod = f_portad WHERE f_dtpaga = '" & mData & "' AND f_sit = 'L'" '(f_sit <> 'E' OR f_sitanterior = 'L')
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            mCodCliente = dr(0).ToString
            mNomeCliente = dr(1).ToString
            mFatura = dr(2).ToString
            mFaturaLetra = dr(3).ToString
            mDtEmiss = Format(Convert.ChangeType(dr(4), GetType(Date)), "dd/MM/yyyy")
            mDtVencimento = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            mDescrPagto = dr(6).ToString
            mPosiParcela = _funcoes.returnNumPosicaoLetraAlfab(mFaturaLetra)

            mDiasAtrazo = dataDoDiaRef.Subtract(Convert.ChangeType(mDtVencimento, GetType(Date))).Days


            Try
                mValor = dr(7)
                mSomaValorDupliNorm += mValor
            Catch ex As Exception
            End Try

            Try
                mJuros = dr(8)
                mSomaJurosNorm += mJuros
            Catch ex As Exception
            End Try

            Try
                mTotal = Round(dr(9), 2)
                mSomaTotalDuplic += mTotal
                mSomaTotalReceitas += mTotal
            Catch ex As Exception
            End Try


            mParcelas = dr(10).ToString.PadLeft(2, "0")
            mCaixa = dr(11).ToString
            'mCaixa = _clFunc.Centraliza_Str(mCaixa, 7)


            '| Codigo |       Cliente      | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo | Caixa |
            '|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|
            '|00001904987303|VERA LUCIA ALV|31802/02   |11/09/2013|11/11/2013|02|11| 140|    43,60|    0,40|     44,00|        |        |         |       |
            mStrLinha = "| " & mCodCliente & " | " & _funcoes.Exibe_StrEsquerda(mNomeCliente, 18) & " |"
            mStrLinha += _funcoes.Exibe_StrEsquerda(mFatura, 10) & " |" & mDtEmiss & "|" & mDtVencimento & "|"
            mStrLinha += Format(mPosiParcela, "00") & "|" & mParcelas & "|" & _funcoes.Exibe_StrDireita(mDiasAtrazo, 4) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mValor, "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mJuros, "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10)
            mStrLinha += "|        |        |         |" & mCaixa & "|"

            sw.EscreveLn(mStrLinha)

            mValor = 0.0 : mJuros = 0.0 : mTotal = 0.0 : mDiasAtrazo = 0
        End While
        dr.Close()



        'Duplicatas de recebimento Parciais...
        _mConsulta = "SELECT f_portad, cad.p_portad, f_duplic, Substr(f_duplic, Length(f_duplic)), f_emiss, f_vencto, '', " & _
        "f_valor, f_juros, ((f_valor + f_juros) - f_desc) As ""total"", f_caixa FROM " & MdlEmpresaUsu._esqEstab & ".fatdp02 " & _
        "LEFT JOIN cadp001 cad ON cad.p_cod = f_portad WHERE f_dtpaga = '" & mData & "'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            mCodCliente = dr(0).ToString
            mNomeCliente = dr(1).ToString
            mFatura = dr(2).ToString
            mFaturaLetra = dr(3).ToString
            mDtEmiss = Format(Convert.ChangeType(dr(4), GetType(Date)), "dd/MM/yyyy")
            mDtVencimento = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            mDescrPagto = dr(6).ToString
            mPosiParcela = _funcoes.returnNumPosicaoLetraAlfab(mFaturaLetra)

            mDiasAtrazo = dataDoDiaRef.Subtract(Convert.ChangeType(mDtVencimento, GetType(Date))).Days


            Try
                mValor = dr(7)
                mSomaValorDupliParc += mValor
            Catch ex As Exception
            End Try

            Try
                mJuros = dr(8)
                mSomaJurosParc += mJuros
            Catch ex As Exception
            End Try

            Try
                mTotal = Round(dr(9), 2)
                mSomaTotalDuplic += mTotal
                mSomaTotalReceitas += mTotal
            Catch ex As Exception
            End Try


            mParcelas = "00"
            mCaixa = dr(10).ToString
            'mCaixa = _clFunc.Centraliza_Str(mCaixa, 7)


            '| Codigo |       Cliente      | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo | Caixa |
            '|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|
            '|00001904987303|VERA LUCIA ALV|31802/02   |11/09/2013|11/11/2013|02|11| 140|    43,60|    0,40|     44,00|        |        |         |
            mStrLinha = "| " & mCodCliente & " | " & _funcoes.Exibe_StrEsquerda(mNomeCliente, 18) & " |"
            mStrLinha += _funcoes.Exibe_StrEsquerda(mFatura & "*", 11) & "|" & mDtEmiss & "|" & mDtVencimento & "|"
            mStrLinha += Format(mPosiParcela, "00") & "|" & mParcelas & "|" & _funcoes.Exibe_StrDireita(mDiasAtrazo, 4) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mValor, "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mJuros, "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10)
            mStrLinha += "|        |        |         |" & mCaixa & "|"

            sw.EscreveLn(mStrLinha)

            mValor = 0.0 : mJuros = 0.0 : mTotal = 0.0 : mDiasAtrazo = 0
        End While
        dr.Close()





        'Recebimento de Vendas A Vista....
        Dim mAvista As Double = 0.0, mSomaAvista As Double = 0.0


        'Recebimento de Entradas....
        Dim mEntrada As Double = 0.0, mSomaEntrada As Double = 0.0
        Dim mAPrazo As Double = 0.0, mSomaAPrazo As Double = 0.0
        _mConsulta = "SELECT DISTINCT ON (e_id) e_id, f_portad, cad.p_portad, f_nfat, f_emiss, f_vencto, e_entrada, f_parcelas " & _
        "FROM cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".entradafatd LEFT JOIN " & MdlEmpresaUsu._esqEstab & ".fatd001 " & _
        "ON Cast(f_nfat As Bigint) = e_duplicata WHERE cad.p_cod = f_portad AND e_data = '" & mData & "'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            mCodCliente = dr(1).ToString
            mNomeCliente = dr(2).ToString
            mFatura = dr(3).ToString
            mDtEmiss = Format(Convert.ChangeType(dr(4), GetType(Date)), "dd/MM/yyyy")
            mDtVencimento = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            Try
                mParcelas = Format(CInt(dr(7)), "00")
            Catch ex As Exception
                mParcelas = "01"
            End Try


            Try
                mEntrada = dr(6)
                mSomaEntrada += mEntrada
                mSomaTotalReceitas += mEntrada
            Catch ex As Exception
            End Try



            '| Codigo |       Cliente      | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo |
            '|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|
            '|00001904987303|VERA LUCIA ALV|31802/02   |11/09/2013|11/11/2013|02|11| 140|    43,60|    0,40|     44,00|        |        |         |
            mStrLinha = "| " & mCodCliente & " | " & _funcoes.Exibe_StrEsquerda(mNomeCliente, 18) & " |"
            mStrLinha += _funcoes.Exibe_StrEsquerda("P-" & mFatura, 11) & "|" & mDtEmiss & "|          |"
            mStrLinha += "EN|" & mParcelas & "|    |         |        |          |        |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mEntrada, "#,##0.00"), 8) & "|         |"

            sw.EscreveLn(mStrLinha)

            mAvista = 0.0 : mAPrazo = 0.0
        End While
        dr.Close()



        If (sw.contLinhasPorPagina + 3) > sw.qtdLinhasPorPagina Then
            sw.SaltandoLinhasComEscreveLn(sw.qtdLinhasPorPagina - sw.contLinhasPorPagina)
            sw.EscreveLn("|--------------------------------------------------------------------------+---------+--------+----------+--------+--------+---------|")
            mStrLinha = "|                                                     Total do dia         |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliNorm + mSomaValorDupliParc, 2), "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaJurosNorm + mSomaJurosParc, 2), "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalDuplic, 2), "###,##0.00"), 10) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaAvista, 2), "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaEntrada, 2), "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaAPrazo, 2), "##,##0.00"), 9) & "|"
            sw.EscreveLn(mStrLinha)
            sw.EscreveLn("+====================================================================================================================================+")

        Else

            sw.EscreveLn("|--------------------------------------------------------------------------+---------+--------+----------+--------+--------+---------|")
            mStrLinha = "|                                                     Total do dia         |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliNorm + mSomaValorDupliParc, 2), "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaJurosNorm + mSomaJurosParc, 2), "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalDuplic, 2), "###,##0.00"), 10) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaAvista, 2), "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaEntrada, 2), "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaAPrazo, 2), "##,##0.00"), 9) & "|"
            sw.EscreveLn(mStrLinha)
            sw.EscreveLn("+====================================================================================================================================+")

        End If


        sw.strInicioLinha = _StrAuxDiarioDupliReceb
        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        RemoveHandler sw.SaltandoLinhasEvento, AddressOf GravCabLojDiario1
        AddHandler sw.SaltandoLinhasEvento, AddressOf GravCabLojDiarioPagDuplic
        sw.SaltandoLinhasComEscreveLn(sw.qtdLinhasPorPagina - sw.contLinhasPorPagina)





        'Pagamento de Duplicatas...
        Dim codCliente, portad, nfat, duplic, nfisc, emiss, vencto, mLetra, numParcelaStr As String
        Dim valor, juros, desc, total, mSomaTotalDespesas As Double
        Dim mNumParcela As Integer
        Dim mStrBDespCred As New StringBuilder
        _mConsulta = "SELECT d_portad, cad.p_portad, d_duplic, Substr(d_duplic, Length(d_duplic)), d_nfisc, d_emiss, d_vencto, d_valor, d_juros, d_desc, " & _
        "((d_valor + d_juros) - d_desc) As ""total"", d_nfat, d_caixa FROM fatp001 LEFT JOIN cadp001 cad ON cad.p_cod = d_portad " & _
        "WHERE d_geno = '" & MdlEmpresaUsu._codigo & "' AND d_dtpaga = '" & mData & "' AND d_sit = 'L' ORDER BY d_duplic ASC" '(d_sit <> 'E' OR d_sitanterior = 'L')
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            codCliente = dr(0).ToString
            portad = dr(1).ToString
            duplic = dr(2).ToString
            mLetra = dr(3).ToString
            nfisc = dr(4).ToString
            emiss = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            vencto = Format(Convert.ChangeType(dr(6), GetType(Date)), "dd/MM/yyyy")
            mNumParcela = _funcoes.returnNumPosicaoLetraAlfab(mLetra)
            numParcelaStr = Format(mNumParcela, "00")
            nfat = dr(11).ToString
            duplic = nfat & "/" & numParcelaStr

            Try
                total = dr(10)
                mSomaTotalDespesas += total
            Catch ex As Exception
            End Try
            mCaixa = dr(12).ToString
            mCaixa = _clFunc.Centraliza_Str(mCaixa, 7)



            '| Codigo |             Fornecedor              |  Duplicata  | N. Fiscal|  Emissao |Vencimento|  Valor   |
            mStrLinha = "| " & _funcoes.Exibe_StrEsquerda(codCliente, 6) & " | " & _funcoes.Exibe_StrEsquerda(portad, 35) & " |"
            mStrLinha += _funcoes.Exibe_StrDireita(duplic, 12) & " |" & _funcoes.Exibe_StrDireita(nfisc, 9) & " |" & emiss & "|" & vencto & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(total, "###,##0.00"), 10) & "|" & mCaixa & "|"

            sw.EscreveLn(mStrLinha)

            mStrBDespCred.Append(duplic & "|" & total & "?")

            mValor = 0.0 : mJuros = 0.0 : mTotal = 0.0 : mDiasAtrazo = 0
        End While
        dr.Close()



        'Pagamento Parcial de Duplicatas...
        _mConsulta = "SELECT d_portad, cad.p_portad, d_duplic, Substr(d_duplic, Length(d_duplic)), d_emiss, d_vencto, '', " & _
        "d_valor, d_juros, ((d_valor + d_juros) - d_desc) As ""total"", d_caixa FROM fatp002 " & _
        "LEFT JOIN cadp001 cad ON cad.p_cod = d_portad WHERE d_geno = '" & MdlEmpresaUsu._codigo & "' AND d_dtpaga = '" & mData & "'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            mCodCliente = dr(0).ToString
            mNomeCliente = dr(1).ToString
            mFatura = dr(2).ToString
            mFaturaLetra = dr(3).ToString
            mDtEmiss = Format(Convert.ChangeType(dr(4), GetType(Date)), "dd/MM/yyyy")
            mDtVencimento = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            mDescrPagto = dr(6).ToString
            mPosiParcela = _funcoes.returnNumPosicaoLetraAlfab(mFaturaLetra)

            mDiasAtrazo = dataDoDiaRef.Subtract(Convert.ChangeType(mDtVencimento, GetType(Date))).Days


            Try
                mValor = dr(7)
                mSomaValorDupliParc += mValor
            Catch ex As Exception
            End Try

            Try
                mJuros = dr(8)
                mSomaJurosParc += mJuros
            Catch ex As Exception
            End Try

            Try
                mTotal = Round(dr(9), 2)
                mSomaTotalDespesas += mTotal
            Catch ex As Exception
            End Try
            mCaixa = dr(10).ToString
            mCaixa = _clFunc.Centraliza_Str(mCaixa, 7)


            '| Codigo |       Cliente      | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo |
            '|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|
            '|00001904987303|VERA LUCIA ALV|31802/02   |11/09/2013|11/11/2013|02|11| 140|    43,60|    0,40|     44,00|        |        |         |
            mStrLinha = "| " & mCodCliente & " | " & _funcoes.Exibe_StrEsquerda(mNomeCliente, 18) & " |"
            mStrLinha += _funcoes.Exibe_StrEsquerda(mFatura & "*", 11) & "|" & mDtEmiss & "|" & mDtVencimento & "|"
            mStrLinha += Format(mPosiParcela, "00") & "|" & mParcelas & "|" & _funcoes.Exibe_StrDireita(mDiasAtrazo, 4) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mValor, "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mJuros, "#,##0.00"), 8) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10)
            mStrLinha += "|        |        |         |" & mCaixa & "|"

            sw.EscreveLn(mStrLinha)

            mValor = 0.0 : mJuros = 0.0 : mTotal = 0.0 : mDiasAtrazo = 0
        End While
        dr.Close()

        sw.EscreveLn("+========================================================================================================+")






        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        RemoveHandler sw.SaltandoLinhasEvento, AddressOf GravCabLojDiarioPagDuplic
        AddHandler sw.SaltandoLinhasEvento, AddressOf GravaCabDespCredito
        sw.SaltandoLinhasComEscreveLn(sw.qtdLinhasPorPagina - sw.contLinhasPorPagina)


        'Despesas e Creditos do CAIXA por caixa...
        Dim sldAnteriorCX As Double

        _mConsulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND cx_data = '" & mData & "' AND cx_tipo = 'A' "
        'If MdlUsuarioLogando._codcaixa.Equals("") = False Then _mConsulta += "AND cx_caixa = '" & MdlUsuarioLogando._codcaixa & "' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                sldAnteriorCX = dr(0)
                mSomaTotalReceitas += sldAnteriorCX
            Catch ex As Exception
                sldAnteriorCX = 0
            End Try


            '|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|ABERTURA      |001|ABERTURA DO CAIXA                              |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(sldAnteriorCX, "###,##0.00"), 12) & "|             |"

            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()

        'Recebimentos lançados manualmente:
        Dim mtotDespManual, mtotRecebManual As Double
        _mConsulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND cx_data = '" & mData & "' AND cx_tipo = 'R' "
        'If MdlUsuarioLogando._codcaixa.Equals("") = False Then _mConsulta += "AND cx_caixa = '" & MdlUsuarioLogando._codcaixa & "' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mtotRecebManual = dr(0)
                mSomaTotalReceitas += mtotRecebManual
            Catch ex As Exception
                mtotRecebManual = 0
            End Try


            '|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|LANCAMENTO    |500|RECEBIMENTOS DO DIA [Manual]                   |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mtotRecebManual, "###,##0.00"), 12) & "|             |"

            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()


        'Pagamentos feitos Manualmente
        _mConsulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND cx_data = '" & mData & "' AND cx_tipo = 'P' "
        'If MdlUsuarioLogando._codcaixa.Equals("") = False Then _mConsulta += "AND cx_caixa = '" & MdlUsuarioLogando._codcaixa & "' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mtotDespManual += dr(0)
                mSomaTotalDespesas += dr(0)
            Catch ex As Exception
                mtotDespManual = 0
                Exit While
            End Try


            '            |   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|LANCAMENTO    |001|PAGAMENTOS DO DIA [Manual]                     |            |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(dr(0), "###,##0.00"), 13) & "|"

            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()



        'Divisórias feitos Manualmente
        _mConsulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND cx_data = '" & mData & "' AND cx_tipo = 'D' "
        'If MdlUsuarioLogando._codcaixa.Equals("") = False Then _mConsulta += "AND cx_caixa = '" & MdlUsuarioLogando._codcaixa & "' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mtotDespManual += dr(0)
                mSomaTotalDespesas += dr(0)
            Catch ex As Exception
                mtotDespManual = 0
                Exit While
            End Try


            '            |   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|LANCAMENTO    |888|DIVISORIAS DO DIA [Manual]                     |            |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(dr(0), "###,##0.00"), 13) & "|"

            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()



        sw.EscreveLn("|-----------------------------------------------------------------------------+------------+-------------|")
        mStrLinha = "|                             Total De Credito/Despesas ..........            |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(sldAnteriorCX + Round(mtotRecebManual, 2), "###,##0.00"), 12) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita("-" & Format(Round(mtotDespManual, 2), "###,##0.00"), 13) & "|"
        sw.EscreveLn(mStrLinha)
        sw.EscreveLn("+========================================================================================================+")




        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        RemoveHandler sw.SaltandoLinhasEvento, AddressOf GravaCabDespCredito
        AddHandler sw.SaltandoLinhasEvento, AddressOf GravaCabDespCreditoOUTROS
        sw.SaltandoLinhasComEscreveLn(sw.qtdLinhasPorPagina - sw.contLinhasPorPagina)


        'Despesas e Creditos do Plano de Contas...  ################
        Dim mValorAux As Double = 0.0, mTotalRecebOUTROS As Double = 0.0, mTotalDespOUTROS As Double = 0.0
        'Despesas:
        _mConsulta = "SELECT Sum(dm_valor) FROM " & MdlEmpresaUsu._esqEstab & ".despm002 WHERE dm_firma = '0" & mLoja & "' AND " & _
        "dm_data = '" & mData & "' AND dm_tipo = 'P' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mValorAux = dr(0)
                mSomaTotalDespesas += mValorAux
                mTotalDespOUTROS += mValorAux
            Catch ex As Exception
                mValorAux = 0
            End Try


            '|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|DESPESAS      | P |PAGAMENTOS EFETUADOS                           |"
            mStrLinha += "            |" & _funcoes.Exibe_StrDireita(Format(mValorAux, "###,##0.00"), 12) & " |"

            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()


        'Recebimentos:
        _mConsulta = "SELECT Sum(dm_valor) FROM " & MdlEmpresaUsu._esqEstab & ".despm002 WHERE dm_firma = '0" & mLoja & "' AND " & _
        "dm_data = '" & mData & "' AND dm_tipo = 'R' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mValorAux = dr(0)
                mSomaTotalReceitas += mValorAux
                mTotalRecebOUTROS += mValorAux
            Catch ex As Exception
                mValorAux = 0
            End Try


            '|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|RECEITAS      | R |RECEBIMENTOS EFETUADOS                         |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mValorAux, "###,##0.00"), 12) & "|             |"

            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()
        sw.EscreveLn("|-----------------------------------------------------------------------------+------------+-------------|")
        mStrLinha = "|                             Total De Credito/Despesas ..........            |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mTotalRecebOUTROS, 2), "###,##0.00"), 12) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita("-" & Format(Round(mTotalDespOUTROS, 2), "###,##0.00"), 13) & "|"
        sw.EscreveLn(mStrLinha)
        sw.EscreveLn("+========================================================================================================+")




        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        RemoveHandler sw.SaltandoLinhasEvento, AddressOf GravaCabDespCreditoOUTROS
        sw.chamaEvento = False
        sw.SaltandoLinhasComEscreveLn(sw.qtdLinhasPorPagina - sw.contLinhasPorPagina)


        'FINALIZANDO   ......................................
        'mSomaTotalDespesas += Round(mtotDespManual, 2)
        Dim mDiaAnterior As Date = DateSerial(dataDoDiaRef.Year, dataDoDiaRef.Month, dataDoDiaRef.Day - 1)
        sw.EscreveLn("             ******************************************************************************")
        mStrLinha = "             * S A L D O  D I A   A N T E R I O R  ( " & Format(mDiaAnterior, "dd/MM/yyyy") & " )"
        mStrLinha += "  << " & _funcoes.Exibe_StrDireita(Format(sldAnteriorCX, "###,##0.00"), 13) & " >>    *"
        sw.EscreveLn(mStrLinha)
        sw.EscreveLn("             ******************************************************************************")
        'Loja Cabeçalho #########################################
        _mConsulta = "SELECT g_geno, g_ender FROM geno001 WHERE g_codig = '" & loja & "'"
        GravCabSLDAnterior(_mConsulta.ToString, sw, loja, mData, oConnBD, lShouldReturn1)
        sw.EscreveLn("")
        sw.EscreveLn("")
        sw.EscreveLn("                                  RESUMO DO MOVIMENTO NO CAIXA")
        sw.EscreveLn("")
        sw.EscreveLn("       +===========================================================================================+")
        sw.EscreveLn("       |         Descricao do Movimento        |    Valor     |     Juros    |  Total do Movimento |")
        sw.EscreveLn("       |---------------------------------------+--------------+--------------+---------------------|")

        mStrLinha = "       | Recebimento de Duplicatas       [+]   |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliNorm, 2), "#,###,##0.00"), 14) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaJurosNorm, 2), "#,###,##0.00"), 14) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliNorm + mSomaJurosNorm, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        mStrLinha = "       | Recebimento de Avista           [+]   |              |              |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaAvista, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        mStrLinha = "       | Recebimento de Entrada          [+]   |              |              |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaEntrada, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        mStrLinha = "       | Recebimento Parcial Duplicatas  [+]   |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliParc, 2), "#,###,##0.00"), 14) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaJurosParc, 2), "#,###,##0.00"), 14) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliParc + mSomaJurosParc, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        sw.EscreveLn("       | Recebimento de Outras Lojas     [+]   |          0,00|          0,00|                 0,00|")
        sw.EscreveLn("       | Estorno de Duplicatas           [-]   |          0,00|          0,00|                 0,00|")
        sw.EscreveLn("       |---------------------------------------+--------------+--------------+---------------------|")

        mStrLinha = "       | Sub Total do Caixa              [=]   |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaValorDupliNorm + mSomaValorDupliParc, 2), "#,###,##0.00"), 14) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaJurosNorm + mSomaJurosParc, 2), "#,###,##0.00"), 14) & "|"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalDuplic + mSomaAvista + mSomaEntrada, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        sw.EscreveLn("       |-------------------------------------------------------------------------------------------|")
        sw.EscreveLn("       | Entrada Pedidos Renegociados    [+]                                 |                 0,00|")
        sw.EscreveLn("       |-------------------------------------------------------------------------------------------|")

        mStrLinha = "       | Despesas no Caixa               [-]                                 |"
        mStrLinha += _funcoes.Exibe_StrDireita("-" & Format(Round(mSomaTotalDespesas, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        mStrLinha = "       | Credito  no Caixa               [+]                                 |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalReceitas, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        sw.EscreveLn("       |---------------------------------------------------------------------+---------------------|")
        mStrLinha = "       | Total do Caixa                  [=]                                 |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalReceitas - mSomaTotalDespesas, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        sw.EscreveLn("       |-------------------------------------------------------------------------------------------|")
        sw.EscreveLn("       |                                                                                           |")
        sw.EscreveLn("       +===========================================================================================+")
        mStrLinha = "       | Total Venda A Prazo             [=]                                 |"
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaAPrazo, 2), "#,###,##0.00"), 21) & "|"
        sw.EscreveLn(mStrLinha)

        sw.EscreveLn("       | Total A Prazo Regenociado       [=]                                 |                 0,00|")
        sw.EscreveLn("       | Total Venda Cancelada           [=]                                 |                 0,00|")
        sw.EscreveLn("       | Total Venda MR                  [=]                                 |                 0,00|")
        sw.EscreveLn("       +===========================================================================================+")
        sw.EscreveLn("")
        sw.EscreveLn("")
        sw.EscreveLn("             ******************************************************************************")
        sw.EscreveLn("             *              T O T A L   D O   C A I X A            << " & _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalReceitas - mSomaTotalDespesas, 2), "#,###,##0.00"), 13) & " >>    *")
        sw.EscreveLn("             ******************************************************************************")
        sw.EscreveLn("")



        Try
            oConnBD.ClearAllPools()
            oConnBD.Close() : oConnBD = Nothing
        Catch ex As Exception
        End Try

    End Sub

    Private Sub executaRelatorioDiario(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\tmp\TEMPRelatorioDiario.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\wged\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        sw = New Cl_EscreveArquivo(fs)
        sw.chamaEvento = True
        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler sw.SaltandoLinhasEvento, AddressOf GravCabLojDiario1
        sw.qtdLinhasPorPagina = 56
        sw.qtdSaltosLinhaNextPag = 0
        _PrintFont1 = New Font("Lucida Console", 9.3) 'Sans Serif


        'Ajuda a contar caracteres da pagina...
        ''                      1         2         3         4         5         6         7         8         9         0         1         2         3         4         5
        ''             123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        'sw.EscreveLn("+====================================================================================================================================+")

        Dim loja As String = MdlUsuarioLogando._local

        'Relatório 1º .........................................
        Try

            Dim lShouldReturn As Boolean
            executaRelatorioDiario1(sw, loja, lShouldReturn)
            If lShouldReturn Then Return
        Catch ex As Exception

            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception

                Try
                    fs = New FileStream("\wged\new.TMP", FileMode.Create, FileAccess.ReadWrite)
                Catch ex2 As Exception
                End Try

            End Try
        End Try


        'Deleta o arquivo temporário...
        sw.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        sw.Dispose()
        File.Delete(mArqTemp)

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuContRelatorioDiario()
        _StringToPrint = ""

    End Sub

#End Region

#Region "   Vendedor"

    Private Sub VisuContRelatorioVendedor()

        Try

            ' Especifica as configurações da pagina atual
            pdRelatPedidos.DefaultPageSettings = _PrintPageSettings

            'Configurando margens 39 = 1cm
            pdRelatPedidos.DefaultPageSettings.Margins.Top = 59
            pdRelatPedidos.DefaultPageSettings.Margins.Right = 40
            pdRelatPedidos.DefaultPageSettings.Margins.Left = 59
            pdRelatPedidos.DefaultPageSettings.Margins.Bottom = 40

            'Orientação em Retrato...
            pdRelatPedidos.DefaultPageSettings.Landscape = True
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando RELATÓRIO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatPedidos
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False
            _StringToPrint = "" : _StringToPrintItens = ""

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Public Sub GravCabLojVendedor()

        Dim mDataInicial As String = Format(dataInicialRef, "dd/MM/yyyy")
        Dim mDataFinal As String = Format(dataFinalRef, "dd/MM/yyyy")
        Dim loja As String = MdlUsuarioLogando._local

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try

        'Loja Cabeçalho #########################################
        ', g_fone, g_uf, g_cid, g_cgc
        'Caracteres na Pagin 114
        sw.WriteLine("+=================================[Continua na Proxima Pagina...]================================================+")
        sw.SaltandoLinhas(4)
        sw.EscreveLn("+================================================================================================================+")
        _mConsulta = "SELECT g_geno, g_ender FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        GravCabLojVendedor(_mConsulta.ToString, sw, loja, mDataInicial, mDataFinal, oConnBD, lShouldReturn1)


    End Sub

    'Cabeçalho da Loja Movimento Caixa...
    Public Sub GravCabLojVendedor(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, ByVal loja As String, _
                                           ByVal dataInicial As String, ByVal dataFinal As String, _
                                           ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = "", strAux2 As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja, cnpjLoja As String

            nomeLoja = "" : enderLoja = "" : foneLoja = "" : ufLoja = "" : cidLoja = "" : cnpjLoja = ""
            While dr.Read

                nomeLoja = dr(0).ToString : enderLoja = dr(1).ToString
                'foneLoja = dr(2).ToString : ufLoja = dr(3).ToString
                'cidLoja = dr(4).ToString : cnpjLoja = dr(5).ToString
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            '                      1         2         3         4         5         6         7         8         9         0         1         2
            '             123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strAux = _funcoes.Exibe_StrEsquerda("|Empresa.: " & _local & " - " & _funcoes.Exibe_StrEsquerda(nomeLoja, 50), 60)
            strAux += _funcoes.Exibe_StrDireita("Emissao.: " & Format(MdlConexaoBD.dataServidor, "dd/MM/yyyy") & "    ", 41)
            strAux += _funcoes.Exibe_StrDireita("Pagina.: " & _funcoes.Exibe_StrDireita(sw.paginaAtual, 3) & "|", 13)
            sw.EscreveLn(_funcoes.Exibe_Str(strAux, 114))
            sw.EscreveLn("|                                                                                                                |")
            strAux = _funcoes.Exibe_StrEsquerda("|Vendedor: " & codVendedorRef & " - " & _funcoes.Exibe_StrEsquerda(nomeVendedorRef, 50), 60)
            strAux += _funcoes.Exibe_StrDireita("Periodo de: " & dataInicial & " a " & dataFinal & " |", 54)
            sw.EscreveLn(_funcoes.Exibe_Str(strAux, 114))
            sw.EscreveLn("|                                                                                                                |")
            sw.EscreveLn("|" & _funcoes.Centraliza_Str("Relatorio de Comissoes de Vendedores", 112) & "|")
            sw.EscreveLn("|                                                                          +-------------------------------------|")
            sw.EscreveLn("|                                                                          |   V   E   N   D   A   S   |MR/Cance.|")
            sw.EscreveLn("|--------+--------+----------------------------------------------------------------+---------+---------+---------|")
            sw.EscreveLn("| Pedido | Codigo | Cliente                             |  Emissao | N| P| Avista  | Entrada |  APrazo |  Valor  |")
            sw.EscreveLn("|--------+--------+-------------------------------------+----------+--+--+---------+---------+---------+---------|")



            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Private Sub executaRelatorioVendedor1(ByRef sw As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False

        'Variáveis Totais...
        Dim mPedido, mCodCliente, mNomeCliente, mDtEmiss, mDescrPagto, mTipoPedido As String
        Dim mParcelas, mTipo As String
        Dim mAvista As Double = 0.0, mSomaAvista As Double = 0.0, mComisAVista As Double = 0.0
        Dim mEntrada As Double = 0.0, mSomaEntrada As Double = 0.0, mComisEntrada As Double = 0.0
        Dim mAPrazo As Double = 0.0, mSomaAPrazo As Double = 0.0, mComisAPrazo As Double = 0.0
        Dim mSomaComis As Double = 0.0
        Dim mAVistaStr, mEntradaStr, mAPrazoStr As String
        Dim mDataInicial As String = Format(dataInicialRef, "dd/MM/yyyy")
        Dim mDataFinal As String = Format(dataFinalRef, "dd/MM/yyyy")
        Dim mStrLinha As String = "", mStrLinhaAux As String = ""

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try

        'Loja Cabeçalho #########################################
        sw.EscreveLn("+================================================================================================================+")
        _mConsulta = "SELECT g_geno, g_ender FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        GravCabLojVendedor(_mConsulta.ToString, sw, loja, mDataInicial, mDataFinal, oConnBD, lShouldReturn1)


        _mConsulta = "SELECT nt_orca, nt_codig, cad.p_portad, nt_dtemis, nt_descrcondpagto, nt_tipo2, nt_entrada, n4_tgeral, n4_comis " & _
        "FROM " & MdlEmpresaUsu._esqEstab & ".orca4dd, " & MdlEmpresaUsu._esqEstab & ".orca1pp LEFT JOIN cadp001 cad ON " & _
        "cad.p_cod = nt_codig WHERE nt_orca = n4_nume AND nt_vend = '" & codVendedorRef & "' AND (nt_sit BETWEEN 3 AND 5) " & _
        "AND (nt_dtemis BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND (nt_tiposelecao <> 1 AND nt_tiposelecao <> 2) ORDER BY nt_dtemis"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            mPedido = dr(0).ToString
            mCodCliente = dr(1).ToString
            mNomeCliente = dr(2).ToString
            mDtEmiss = Format(Convert.ChangeType(dr(3), GetType(Date)), "dd/MM/yyyy")
            mDescrPagto = dr(4).ToString
            mTipoPedido = dr(5).ToString

            If mTipoPedido.Equals("AV") Then

                mTipo = "01"
                mParcelas = "01"

                Try
                    mAvista = dr(7)
                    mSomaAvista += mAvista
                    mComisAVista += dr(8)
                    mAVistaStr = Format(mAvista, "##,##0.00")
                Catch ex As Exception
                    mAvista = 0
                    mAVistaStr = Format(mAvista, "##,##0.00")
                End Try
                mEntradaStr = "" : mAPrazoStr = ""

            Else


                mAVistaStr = ""

                Try
                    mEntrada = dr(6)
                    mSomaEntrada += mEntrada
                    If mEntrada > 0 Then
                        mEntradaStr = Format(mEntrada, "##,##0.00")
                    Else
                        mEntradaStr = ""
                    End If

                Catch ex As Exception
                    mEntrada = 0
                    mEntradaStr = ""
                End Try


                If mEntrada > 0 Then
                    mTipo = "EN"
                Else
                    mTipo = "00"
                End If



                If MdlEmpresaUsu.tipoCondPagto = 1 Then
                    Dim marray As Array = Split(mDescrPagto, "/")
                    mParcelas = Format(marray.Length, "00")

                Else

                    Try
                        mParcelas = Format(CInt(Trim(Mid(mDescrPagto, 1, 2))), "00")
                    Catch ex As Exception
                        mParcelas = "01"
                    End Try

                End If

                Try
                    mAPrazo = dr(7)
                    mAPrazo = Round((mAPrazo - mEntrada), 2)
                    mSomaAPrazo += mAPrazo
                    mComisAPrazo += dr(8)
                    mAPrazoStr = Format(mAPrazo, "##,##0.00")
                Catch ex As Exception
                    mAPrazo = 0.0
                    mAPrazoStr = Format(mAPrazo, "##,##0.00")
                End Try


            End If


            mStrLinha = "|" & _funcoes.Exibe_Str(mPedido, 8) & "| " & _funcoes.Exibe_Str(mCodCliente, 6) & " | "
            mStrLinha += _funcoes.Exibe_StrEsquerda(mNomeCliente, 36) & "|" & mDtEmiss & "|" & mTipo & "|" & mParcelas & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(mAVistaStr, 9) & "|" & _funcoes.Exibe_StrDireita(mEntradaStr, 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(mAPrazoStr, 9) & "|" & _funcoes.Exibe_StrDireita("", 9) & "|"
            sw.EscreveLn(mStrLinha)

            mAvista = 0 : mEntrada = 0 : mAPrazo = 0
        End While
        dr.Close()

        If (sw.contLinhasPorPagina + 3) >= sw.qtdLinhasPorPagina Then
            sw.SaltandoLinhasComEscreveLn(3)

            mStrLinha = "| Total Vendido no Periodo.........                                      |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaAvista, "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaEntrada, "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaAPrazo, "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita("", 9) & "|"
            sw.EscreveLn(mStrLinha)
            sw.EscreveLn("+========================================(Fim do Relatorio)======================================================+")

        Else

            sw.chamaEvento = False
            sw.EscreveLn("|------------------------------------------------------------------------+---------+---------+---------+---------|")
            mStrLinha = "| Total Vendido no Periodo.........                                      |"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaAvista, "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaEntrada, "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaAPrazo, "##,##0.00"), 9) & "|"
            mStrLinha += _funcoes.Exibe_StrDireita("", 9) & "|"
            sw.EscreveLn(mStrLinha)
            sw.EscreveLn("+========================================(Fim do Relatorio)======================================================+")

        End If

        If (sw.contLinhasPorPagina + 15) >= sw.qtdLinhasPorPagina Then
            sw.SaltandoLinhasComEscreveLn(15)
        End If

        sw.EscreveLn("")
        sw.EscreveLn("")
        sw.EscreveLn(_funcoes.Centraliza_Str("RESUMO DE VENDAS E COMISSOES", 114))
        sw.EscreveLn("                  +=====================================================================+")
        sw.EscreveLn("                  |         Descricao         |  Valor Vendido  |Comis. %|Valor Comissao|")
        sw.EscreveLn("                  |---------------------------+-----------------+--------+--------------|")
        mStrLinha = "                  | Venda Avista          [+] |" & _funcoes.Exibe_StrDireita(Format(mSomaAvista, "###,##0.00"), 17)
        mStrLinha += "|" & _funcoes.Exibe_StrDireita(Format(alqComisAVistaRef, "#,##0.00"), 8)
        Try
            mStrLinha += "|" & _funcoes.Exibe_StrDireita(Format(Round((mSomaAvista * alqComisAVistaRef) / 100, 2), "###,##0.00"), 14) & "|"
            mSomaComis += Round((mSomaAvista * alqComisAVistaRef) / 100, 2)
        Catch ex As Exception
            mStrLinha += "|" & _funcoes.Exibe_StrDireita(Format(0.0, "###,##0.00"), 14) & "|"
        End Try
        sw.EscreveLn(mStrLinha)


        mStrLinha = "                  | Venda Com Entrada     [+] |" & _funcoes.Exibe_StrDireita(Format(mSomaEntrada, "###,##0.00"), 17)
        mStrLinha += "|" & _funcoes.Exibe_StrDireita(Format(alqComisEntradaRef, "#,##0.00"), 8)
        Try
            mStrLinha += "|" & _funcoes.Exibe_StrDireita(Format(Round((mSomaEntrada * alqComisEntradaRef) / 100, 2), "###,##0.00"), 14) & "|"
            mSomaComis += Round((mSomaEntrada * alqComisEntradaRef) / 100, 2)
        Catch ex As Exception
            mStrLinha += "|" & _funcoes.Exibe_StrDireita(Format(0.0, "###,##0.00"), 14) & "|"
        End Try
        sw.EscreveLn(mStrLinha)


        mStrLinha = "                  | Venda APrazo          [+] |" & _funcoes.Exibe_StrDireita(Format(mSomaAPrazo, "###,##0.00"), 17)
        mStrLinha += "|" & _funcoes.Exibe_StrDireita(Format(alqComisAPrazoRef, "#,##0.00"), 8)
        Try
            mStrLinha += "|" & _funcoes.Exibe_StrDireita(Format(Round((mSomaAPrazo * alqComisAPrazoRef) / 100, 2), "###,##0.00"), 14) & "|"
            mSomaComis += Round((mSomaAPrazo * alqComisAPrazoRef) / 100, 2)
        Catch ex As Exception
            mStrLinha += "|" & _funcoes.Exibe_StrDireita(Format(0.0, "###,##0.00"), 14) & "|"
        End Try
        sw.EscreveLn(mStrLinha)

        sw.EscreveLn("                  | Venda Cancelada/MR    [-] |             0,00|    0,00|          0,00|")
        sw.EscreveLn("                  |---------------------------+-----------------+--------+--------------|")
        sw.EscreveLn("                  | Total Geral                                          |" & _funcoes.Exibe_StrDireita(Format(mSomaComis, "###,##0.00"), 14) & "|")
        sw.EscreveLn("                  +=====================================================================+")




        Try
            oConnBD.ClearAllPools()
            oConnBD.Close() : oConnBD = Nothing
        Catch ex As Exception
        End Try

    End Sub

    Private Sub executaRelatorioVendedor(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPRelatorioVendedor.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\wged\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        sw = New Cl_EscreveArquivo(fs)
        sw.chamaEvento = True
        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler sw.SaltandoLinhasEvento, AddressOf GravCabLojVendedor
        sw.qtdLinhasPorPagina = 60
        sw.qtdSaltosLinhaNextPag = 0
        _PrintFont1 = New Font("Lucida Console", 10) 'Sans Serif

        'Ajuda a contar caracteres da pagina...
        ''                      1         2         3         4         5         6         7         8         9         0         1         2         3         4         5
        ''             123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        'sw.EscreveLn("===========================================================================================================================")

        Dim loja As String = MdlUsuarioLogando._local
        'Relatório 1º .........................................
        Try

            Dim lShouldReturn As Boolean
            executaRelatorioVendedor1(sw, loja, lShouldReturn)
            If lShouldReturn Then Return
        Catch ex As Exception

            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception

                Try
                    fs = New FileStream("\wged\new.TMP", FileMode.Create, FileAccess.ReadWrite)
                Catch ex2 As Exception
                End Try

            End Try
        End Try


        'Deleta o arquivo temporário...
        sw.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        sw.Dispose()
        File.Delete(mArqTemp)

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuContRelatorioVendedor()
        _StringToPrint = ""

    End Sub

#End Region

#Region "   Movimento do Caixa"

    Private Sub VisuContRelatorioMovCaixa()

        Try

            ' Especifica as configurações da pagina atual
            pdRelatPedidos.DefaultPageSettings = _PrintPageSettings

            'Configurando margens 39 = 1cm
            pdRelatPedidos.DefaultPageSettings.Margins.Top = 59
            pdRelatPedidos.DefaultPageSettings.Margins.Right = 40
            pdRelatPedidos.DefaultPageSettings.Margins.Left = 59
            pdRelatPedidos.DefaultPageSettings.Margins.Bottom = 40

            'Orientação em Paisagem...
            pdRelatPedidos.DefaultPageSettings.Landscape = True
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando RELATÓRIO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatPedidos
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False
            _StringToPrint = "" : _StringToPrintItens = ""

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    'Cabeçalho da Loja Movimento Caixa...
    Public Sub GravCabLojMovCaixaMatricial(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, ByVal loja As String, _
                                           ByVal dataInicial As String, ByVal dataFinal As String, _
                                           ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = "", strAux2 As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja, cnpjLoja As String

            nomeLoja = "" : enderLoja = "" : foneLoja = "" : ufLoja = "" : cidLoja = "" : cnpjLoja = ""
            While dr.Read

                nomeLoja = dr(0).ToString : enderLoja = dr(1).ToString
                'foneLoja = dr(2).ToString : ufLoja = dr(3).ToString
                'cidLoja = dr(4).ToString : cnpjLoja = dr(5).ToString
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strAux = _funcoes.Exibe_StrEsquerda(" Empresa: " & _local & "- " & _funcoes.Exibe_StrEsquerda(nomeLoja, 40), 60)
            strAux += _funcoes.Exibe_StrDireita("Caixa de: " & dataInicial & " ate " & dataFinal, 40)
            sw.EscreveLn(_funcoes.Exibe_Str(strAux, 100))


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Private Sub executaRelatorioMovCaixa1(ByRef sw As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False

        'Variáveis Totais...
        Dim mSomaValor As Double = 0.0, mSomaJuros As Double = 0.0, mSomaTotal As Double = 0.0
        Dim mTotaisValor As Double = 0, mTotaisJuros As Double = 0, mTotaisGerais As Double = 0
        Dim mSomaReceitas As Double = 0.0, mSomaDepesas As Double = 0.0
        Dim mTotalCX As Double = 0.0
        Dim mDataInicial As String = Format(dataInicialRef, "dd/MM/yyyy")
        Dim mDataFinal As String = Format(dataFinalRef, "dd/MM/yyyy")
        Dim mStrLinha As String = "", mStrLinhaAux As String = ""

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try

        'Loja #########################################
        ', g_fone, g_uf, g_cid, g_cgc
        _mConsulta = "SELECT g_geno, g_ender FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        GravCabLojMovCaixaMatricial(_mConsulta.ToString, sw, loja, mDataInicial, mDataFinal, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return

        'sw.EscreveLn(_clFuncoes.repeteCaracteresPagina("-", 100))
        'sw.EscreveLn("       +" & _clFuncoes.repeteCaracteresPagina("=", 91) & "+")

        sw.EscreveLn("")
        sw.EscreveLn("")
        sw.EscreveLn(_funcoes.Centraliza_Str("RESUMO DO MOVIMENTO NO CAIXA", 100))
        sw.EscreveLn("")
        '                      1         2         3         4         5         6         7         8         9         0         1         2
        sw.EscreveLn("       +===========================================================================================+")
        sw.EscreveLn("       |         Descricao do Movimento        |    Valor     |     Juros    |  Total do Movimento |")
        sw.EscreveLn("       |---------------------------------------+--------------+--------------+---------------------|")

        '       | Recebimento de Duplicatas       [+]   |          0,00|          0,00|                 0,00|
        _mConsulta = "SELECT CAST( CAST( (SELECT Sum(f_valor) FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 WHERE f_caixa = '" & codCaixaRef & "' AND f_sit = 'L' AND f_dtpaga BETWEEN '" & _
        mDataInicial & "' AND '" & mDataFinal & "') AS Numeric(15,2)) As Double Precision) As ""Valor"", CAST( CAST( (SELECT Sum(f_juros) " & _
        "FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 WHERE f_caixa = '" & codCaixaRef & "' AND f_sit = 'L' AND f_dtpaga BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AS " & _
        "Numeric(15,2)) As Double Precision) As ""Juros"" "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        mSomaValor = 0.0 : mSomaJuros = 0.0 : mSomaTotal = 0.0
        While dr.Read


            Try
                mSomaValor = dr(0)
            Catch ex As Exception
                mSomaValor = 0
            End Try

            Try
                mSomaJuros = dr(1)
            Catch ex As Exception
                mSomaJuros = 0
            End Try

            mSomaTotal = Round((mSomaValor + mSomaJuros), 2)
            mSomaReceitas += mSomaTotal
        End While
        dr.Close()
        mStrLinha = "       | Recebimento de Duplicatas       [+]   | "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaValor, "##,###,##0.00"), 13) & "| "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaJuros, "##,###,##0.00"), 13) & "| "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaTotal, "##,###,##0.00"), 20) & "|"
        sw.EscreveLn(mStrLinha)

        mTotaisValor += mSomaValor : mTotaisJuros += mSomaJuros : mTotaisGerais += mSomaTotal




        mSomaValor = 0.0 : mSomaJuros = 0.0 : mSomaTotal = 0.0

        mTotaisGerais += mSomaTotal


        mTotaisGerais += mSomaTotal




        '       | Recebimento Parcial Duplicatas  [+]   |          0,00|          0,00|                 0,00|
        _mConsulta = "SELECT CAST( CAST( (SELECT Sum(f_valor) FROM " & MdlEmpresaUsu._esqEstab & ".fatdp02 WHERE f_caixa = '" & codCaixaRef & "' AND f_dtpaga BETWEEN '" & _
        mDataInicial & "' AND '" & mDataFinal & "') AS Numeric(15,2)) As Double Precision) As ""Valor"", CAST( CAST( (SELECT Sum(f_juros) " & _
        "FROM " & MdlEmpresaUsu._esqEstab & ".fatdp02 WHERE f_caixa = '" & codCaixaRef & "' AND f_dtpaga BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AS " & _
        "Numeric(15,2)) As Double Precision) As ""Juros"""
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        mSomaValor = 0.0 : mSomaJuros = 0.0 : mSomaTotal = 0.0
        While dr.Read


            Try
                mSomaValor = dr(0)
            Catch ex As Exception
                mSomaValor = 0
            End Try

            Try
                mSomaJuros = dr(1)
            Catch ex As Exception
                mSomaJuros = 0
            End Try

            mSomaReceitas += Round(mSomaValor + mSomaJuros, 2)
        End While
        dr.Close()
        mSomaTotal = Round((mSomaValor + mSomaJuros), 2)
        mStrLinha = "       | Recebimento Parcial Duplicatas  [+]   | "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaValor, "##,###,##0.00"), 13) & "| "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaJuros, "##,###,##0.00"), 13) & "| "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaValor, "##,###,##0.00"), 20) & "|"
        sw.EscreveLn(mStrLinha)

        mTotaisValor += mSomaValor : mTotaisJuros += mSomaJuros : mTotaisGerais += mSomaTotal

        'Recebimento de Lançamento Manual:
        Dim mSomaRecebManual As Double

        _mConsulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND (cx_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND cx_tipo = 'R' AND cx_caixa = '" & codCaixaRef & "'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mSomaRecebManual = dr(0)
                mTotaisGerais += mSomaRecebManual
            Catch ex As Exception
                mSomaRecebManual = 0
            End Try


            mSomaReceitas += Round(mSomaRecebManual, 2)

            mStrLinha = "       | Recebimento Lancado Manual      [+]   |              |              |" & _funcoes.Exibe_StrDireita(Format(mSomaRecebManual, "###,##0.00"), 21) & "|"
            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()


        '| Recebimento de Outras Lojas     [+]   |          0,00|          0,00|                 0,00|
        mStrLinha = "       | Recebimento de Outras Lojas     [+]   |              |              |                 0,00|"
        sw.EscreveLn(mStrLinha)



        'Abertura do Caixa Lançamento Manual:
        Dim mSomaAberturaCX As Double

        _mConsulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND (cx_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND cx_tipo = 'A' AND cx_caixa = '" & codCaixaRef & "'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mSomaAberturaCX = dr(0)
                mTotaisGerais += mSomaAberturaCX
            Catch ex As Exception
                mSomaAberturaCX = 0
            End Try

            mSomaReceitas += Round(mSomaAberturaCX, 2)
            mStrLinha = "       | Abertura de CAIXA               [+]   |              |              |" & _funcoes.Exibe_StrDireita(Format(mSomaAberturaCX, "###,##0.00"), 21) & "|"
            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()


        'Pagamento do Caixa Lançamento Manual:
        Dim mSomaPagamentoCX As Double

        _mConsulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND (cx_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND cx_tipo = 'P' AND cx_caixa = '" & codCaixaRef & "'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mSomaPagamentoCX = dr(0)
                mTotaisGerais += mSomaPagamentoCX
            Catch ex As Exception
                mSomaPagamentoCX = 0
            End Try

            mSomaDepesas += Round(mSomaPagamentoCX, 2) '                |
            mStrLinha = "       | Pagamento do CAIXA              [-]   |              |              |" & _funcoes.Exibe_StrDireita(Format(mSomaPagamentoCX, "###,##0.00"), 21) & "|"
            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()


        'Divisória do Caixa Lançamento Manual:
        Dim mSomaDivisoriaCX As Double

        _mConsulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND (cx_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND cx_tipo = 'D' AND cx_caixa = '" & codCaixaRef & "'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mSomaDivisoriaCX = dr(0)
                mTotaisGerais += mSomaDivisoriaCX
            Catch ex As Exception
                mSomaDivisoriaCX = 0
            End Try

            mSomaDepesas += Round(mSomaDivisoriaCX, 2) '                |
            mStrLinha = "       | Divisória do CAIXA              [-]   |              |              |" & _funcoes.Exibe_StrDireita(Format(mSomaDivisoriaCX, "###,##0.00"), 21) & "|"
            sw.EscreveLn(mStrLinha)
        End While
        dr.Close()




        'Despesas e Creditos do Plano de Contas...  ################
        Dim mValorAux As Double = 0.0, mTotalRecebOUTROS As Double = 0.0, mTotalDespOUTROS As Double = 0.0
        'Despesas:
        _mConsulta = "SELECT Sum(dm_valor) FROM " & MdlEmpresaUsu._esqEstab & ".despm002 WHERE dm_firma = '0" & mLoja & "' AND " & _
        "(dm_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND dm_tipo = 'P' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mValorAux = dr(0)
                mSomaDepesas += Round(mValorAux, 2)
            Catch ex As Exception
                mValorAux = 0
            End Try

        End While
        dr.Close()


        'Recebimentos:
        _mConsulta = "SELECT Sum(dm_valor) FROM " & MdlEmpresaUsu._esqEstab & ".despm002 WHERE dm_firma = '0" & mLoja & "' AND " & _
        "(dm_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND dm_tipo = 'R' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mValorAux = dr(0)
                mSomaReceitas += Round(mValorAux, 2)
            Catch ex As Exception
                mValorAux = 0
            End Try

        End While
        dr.Close()




        '| Estorno de Duplicatas           [-]   |          0,00|          0,00|                 0,00|
        mStrLinha = "       | Estorno de Duplicatas           [-]   |          0,00|          0,00|                 0,00|"
        sw.EscreveLn(mStrLinha)
        mStrLinha = "       |---------------------------------------+--------------+--------------+---------------------|"
        sw.EscreveLn(mStrLinha)



        '| Sub Total do Caixa              [=]   |          0,00|          0,00|                 0,00|
        'mSomaReceitas = Round(mTotaisGerais, 2)
        mStrLinha = "       | Sub Total do Caixa              [=]   | "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mTotaisValor, 2), "##,###,##0.00"), 13) & "| "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mTotaisJuros, 2), "##,###,##0.00"), 13) & "| "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mTotaisGerais, 2), "##,###,##0.00"), 20) & "|"
        sw.EscreveLn(mStrLinha)
        mStrLinha = "       |---------------------------------------------------------------------+---------------------|"
        sw.EscreveLn(mStrLinha)



        '| Sub Total do Caixa              [=]   |          0,00|          0,00|                 0,00|
        '| Entrada Pedidos Renegociados    [+]   |                             | 
        mStrLinha = "       | Entrada Pedidos Renegociados    [+]   |                             | "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(0.0, "##,###,##0.00"), 20) & "| "
        sw.EscreveLn(mStrLinha)
        mStrLinha = "       |---------------------------------------------------------------------+---------------------|"
        sw.EscreveLn(mStrLinha)


        'PAGAMENTOS DE DUPLICATAS:
        _mConsulta = "SELECT CAST( CAST( (SELECT Sum(d_valor) FROM fatp001 WHERE d_geno = " & _
        "'" & MdlEmpresaUsu._codigo & "' AND d_caixa = '" & codCaixaRef & "' AND d_sit = 'L' AND (d_dtpaga BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "')) AS " & _
        "Numeric(15,2)) As Double Precision) As ""Despesas"""
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        mSomaValor = 0.0 : mSomaJuros = 0.0 : mSomaTotal = 0.0
        While dr.Read


            Try
                mSomaValor = dr(0)
                mSomaTotal += mSomaValor
            Catch ex As Exception
                mSomaValor = 0
            End Try

            Try
                mSomaValor += dr(1)
                mSomaTotal += mSomaValor
            Catch ex As Exception
            End Try

            mSomaDepesas += Round(mSomaValor, 2)
        End While
        dr.Close()


        'PAGAMENTO DUPLICATAS PARCIAL:
        _mConsulta = "SELECT Sum(d_valor) FROM fatp002 WHERE d_geno = '" & MdlEmpresaUsu._codigo & "' AND d_caixa = '" & codCaixaRef & "' AND " & _
        "d_dtpaga BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "' "
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read


            Try
                mSomaValor = dr(0)
                mSomaTotal += mSomaValor
            Catch ex As Exception
                mSomaValor = 0
            End Try

            mSomaDepesas += Round(mSomaValor, 2)
        End While
        dr.Close()



        mStrLinha = "       | Despesas no Caixa               [-]                                 | "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaDepesas, 2), "##,###,##0.00"), 20) & "| "
        sw.EscreveLn(mStrLinha)

        mStrLinha = "       | Credito  no Caixa               [+]                                 | "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaReceitas, 2), "##,###,##0.00"), 20) & "| "
        sw.EscreveLn(mStrLinha)
        mStrLinha = "       |---------------------------------------------------------------------+---------------------|"
        sw.EscreveLn(mStrLinha)
        mTotalCX = Round((mSomaReceitas - mSomaDepesas), 2)


        mStrLinha = "       | Total do Caixa                  [=]                                 | "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(mTotalCX, "##,###,##0.00"), 20) & "| "
        sw.EscreveLn(mStrLinha)
        mStrLinha = "       |-------------------------------------------------------------------------------------------|"
        sw.EscreveLn(mStrLinha)
        mStrLinha = "       |                                                                                           |"
        sw.EscreveLn(mStrLinha)
        mStrLinha = "       +===========================================================================================+"
        sw.EscreveLn(mStrLinha)
        mStrLinha = "       | Total Venda A Prazo             [=]                                 | "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(Round(mSomaTotal, 2), "##,###,##0.00"), 20) & "| "
        sw.EscreveLn(mStrLinha)
        mStrLinha = "       | Total A Prazo Regenociado       [=]                                 | "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(0.0, "##,###,##0.00"), 20) & "| "
        sw.EscreveLn(mStrLinha)


        mSomaValor = 0.0 : mSomaJuros = 0.0 : mSomaTotal = 0.0
        '_mConsulta = "SELECT CAST( CAST( (SELECT Sum(n4_tgeral) FROM " & MdlEmpresaUsu._esqEstab & ".orca4dd JOIN " & MdlEmpresaUsu._esqEstab & _
        '".orca1pp ON nt_orca = n4_nume WHERE (nt_dtemis BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND " & _
        '"nt_sit = 6 AND (nt_tiposelecao <> 1 AND nt_tiposelecao <> 2)) AS Numeric(15,2)) As Double Precision) As ""Valor"""
        'comm = New NpgsqlCommand(_mConsulta, oConnBD)
        'dr = comm.ExecuteReader


        'While dr.Read


        '    Try
        '        mSomaTotal = dr(0)
        '    Catch ex As Exception
        '        mSomaTotal = 0
        '    End Try

        'End While
        'dr.Close()
        mStrLinha = "       | Total Venda Cancelada           [=]                                 | "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(mSomaTotal, "##,###,##0.00"), 20) & "| "
        sw.EscreveLn(mStrLinha)


        mStrLinha = "       | Total Venda MR                  [=]                                 | "
        mStrLinha += _funcoes.Exibe_StrDireita(Format(0.0, "##,###,##0.00"), 20) & "| "
        sw.EscreveLn(mStrLinha)
        mStrLinha = "       +===========================================================================================+"
        sw.EscreveLn(mStrLinha)
        sw.EscreveLn("")



        Try
            oConnBD.ClearAllPools()
            oConnBD.Close() : oConnBD = Nothing
        Catch ex As Exception
        End Try

    End Sub

    Private Sub executaRelatorioMovimentoCaixa(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPRelatorioMovimentoCaixa.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\wged\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        sw = New Cl_EscreveArquivo(fs)
        sw.qtdLinhasPorPagina = 111
        sw.qtdSaltosLinhaNextPag = 2
        _PrintFont1 = New Font("Lucida Console", 10) 'Sans Serif

        'Ajuda a contar caracteres da pagina...
        ''                      1         2         3         4         5         6         7         8         9         0         1         2         3         4         5
        ''             123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        'sw.EscreveLn("===========================================================================================================================")

        Dim loja As String = MdlUsuarioLogando._local
        'Relatório 1º .........................................
        Try

            Dim lShouldReturn As Boolean
            executaRelatorioMovCaixa1(sw, loja, lShouldReturn)
            If lShouldReturn Then Return
        Catch ex As Exception

            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception

                Try
                    fs = New FileStream("\wged\new.TMP", FileMode.Create, FileAccess.ReadWrite)
                Catch ex2 As Exception
                End Try

            End Try
        End Try


        'Deleta o arquivo temporário...
        sw.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        sw.Dispose()
        File.Delete(mArqTemp)

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuContRelatorioMovCaixa()
        _StringToPrint = ""

    End Sub

#End Region

#End Region

    Private Sub executaEspelhoExtracted1(ByVal s As StreamWriter, ByVal loja As String, ByVal numeroPedido As String, ByVal dtEmissao As String, ByVal codClient As String, ByVal nomeClient As String, ByVal condicao As String, ByVal codVendedor As String, ByVal idOrca1 As Int32, ByRef shouldReturn As Boolean)

        shouldReturn = False

        s.WriteLine("")

        _mConsulta = ""
        'Loja
        _mConsulta = "SELECT g_geno, g_ender, g_fone, g_uf, g_cid FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        _funcoes.GravCabLojPedidoRelatorioMatricial(_mConsulta.ToString, s, loja, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return


        '_mConsulta = ""
        ''Cliente
        ''Traz dados do CLIENTE do Pedido...
        '_mConsulta = "SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
        '_mConsulta = "p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codClient & "'")
        'Dim lShouldReturn2 As Boolean
        '_clFuncoes.GravCabCliPedidoMatricial(_mConsulta.ToString, s, codClient, numeroPedido, dtEmissao, codVendedor, condicao, loja, lShouldReturn2)
        'If lShouldReturn2 Then shouldReturn = True : Return


        GravTotaisPedidoRelatorioMatricial(s)
        '_mConsulta = ""
        ''itens
        '_mConsulta = "SELECT o2.no_codpr, o2.no_qtde, o2.no_und, e.e_produt, o2.no_prunit, o2.no_prtot, o2.no_filial, el.e_locacao, o2.no_vldesc, o2.no_pesobruto, o2.no_vlsub, o2.no_pruvenda ") '11
        '_mConsulta = "FROM estloja01 el, " & MdlEmpresaUsu._esqEstab & ".orca2cc o2 LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 ")
        '_mConsulta = "e ON e.e_codig = o2.no_codpr WHERE no_idxo1 = " & idOrca1 & " AND el.e_loja = o2.no_filial AND el.e_codig = o2.no_codpr")
        'Dim lShouldReturn3 As Boolean
        '_clFuncoes.GravItensPedidoMatricial(_mConsulta.ToString, s, numeroPedido, idOrca1, codClient, nomeClient, lShouldReturn3)
        'If lShouldReturn3 Then shouldReturn = True : Return

    End Sub

    Private Sub executaEspelho2Extracted1(ByVal s As StreamWriter, ByVal loja As String, ByVal numeroPedido As String, ByVal dtEmissao As String, ByVal codClient As String, ByVal nomeClient As String, ByVal condicao As String, ByVal codVendedor As String, ByVal idOrca1 As Int32, ByRef shouldReturn As Boolean)

        shouldReturn = False

        s.WriteLine("")

        _mConsulta = ""
        'Loja
        _mConsulta = "SELECT g_geno, g_ender, g_fone, g_uf, g_cid FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        _funcoes.GravCabLojPedidoRelatorioMatricial(_mConsulta.ToString, s, loja, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return

        GravTotaisPedidoRelatorioMatricial2(s)

    End Sub

    'Grava Totais
    Public Sub GravTotaisPedidoRelatorioMatricial(ByVal s As StreamWriter)

        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mPedido, mEmissao, mCliente, mVendedor, mTipo, strLinha, strValoresTipo As String
            Dim mCont1, mCont2, index, i As Integer
            Dim mTotal, mSomaTotal, mSomaVlTipo, mSomaEntradas, mEntrada As Double
            Dim mTipos() As String = {"Entr.", "AV", "NP", "CT", "CH", "BL"}
            Dim mContItens As Integer = 0, mContItensPg As Integer = 0, mContPg As Integer = 0
            Dim mArrayTipo1, mArrayTipo2 As Array
            Dim mSomaAvista As Double = 0
            Dim mSomaAbertura, mSomaFechamento As Double
            strValoresTipo = ""



            If Me.dtg_pedidos.RowCount > 0 Then
                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("--------------------------------------------------------------------------------------------")
                s.WriteLine(" Pedido   | Emissão    | Cliente                             | Vendedor | TOTAL      | Tipo ")
                '             xxxxxxxx | xx/xx/xxxx | xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx |  xxxxxx  | 999,999.99 | xxx
                s.WriteLine(" ------------------------------------------------------------------------------------------")
                mCont1 = 20

            End If

            mContItensPg = 6
            mContPg = 1
            mSomaTotal = 0
            mSomaAvista = 0
            For Each row As DataGridViewRow In Me.dtg_pedidos.Rows

                If (row.IsNewRow = False) AndAlso (row.Cells(11).Value.ToString.Equals("6") = False) Then



                    If mContItensPg = 30 Then

                        's.WriteLine("+------------------------------------------------------------------------------------------+")
                        's.WriteLine(" *** CONTINUACAO DO RELATORIO ***  ")
                        's.WriteLine("+------------------------------------------------------------------------------------------+")
                        ''Quebra 10 Linhas para passar para a próxima folha...
                        's.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)



                        mContPg += 1
                        s.WriteLine("+------------------------------------------------------------------------------------------+")
                        s.WriteLine("                    C O N T I N U A C A O . . .               FOLHA: " & String.Format("{0:D3}", mContPg))
                        s.WriteLine("--------------------------------------------------------------------------------------------")
                        s.WriteLine(" Pedido   | Emissão    | Cliente                             | Vendedor | TOTAL      | Tipo ")
                        '             xxxxxxxx | xx/xx/xxxx | xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx |  xxxxxx  | 999,999.99 | xxx
                        s.WriteLine(" ------------------------------------------------------------------------------------------")
                        mContItensPg = 6

                    End If


                    'Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"", n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit ") '9
                    mPedido = row.Cells(2).Value.ToString
                    mEmissao = row.Cells(3).Value.ToString
                    mCliente = row.Cells(5).Value.ToString
                    mVendedor = row.Cells(10).Value.ToString
                    mTotal = row.Cells(8).Value.ToString
                    mTipo = row.Cells(9).Value.ToString
                    Try
                        mEntrada = 0
                        mEntrada = CDbl(row.Cells(13).Value)
                        mSomaEntradas += mEntrada
                    Catch ex As Exception
                        mEntrada = 0
                    End Try
                    mSomaTotal += mTotal

                    strValoresTipo += mTipo & "|" & mTotal & "?"
                    If mTipo.Equals("AV") Then mSomaAvista += mTotal
                    If mEntrada > 0 Then strValoresTipo += "Entr.|" & mEntrada & "?"

                    strLinha = " " & mPedido & " | " & mEmissao & " | " & _
                    _funcoes.Exibe_StrEsquerda(mCliente, 35) & " |  " & _
                    mVendedor & "  | " & _funcoes.Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10) & " | " & _
                    mTipo


                    s.WriteLine(_funcoes.Exibe_Str(strLinha, 99))
                    mContItens += 1 : mContItensPg += 1
                    mCont1 -= 1 : mCont2 -= 1

                End If
            Next


            If mSomaTotal > 0 Then
                s.WriteLine("")
                s.WriteLine(" TOTAL DE VENDAS    " & _funcoes.Exibe_StrDireita(Format(Round(mSomaTotal, 2), "#,###,##0.00"), 12))
                s.WriteLine("")

                For index = 0 To mTipos.Length - 1

                    mSomaVlTipo = 0
                    mArrayTipo1 = Split(strValoresTipo, "?")
                    For i = 0 To mArrayTipo1.Length - 2

                        mArrayTipo2 = Split(mArrayTipo1(i).ToString, "|")
                        If mArrayTipo2(0).ToString.Equals(mTipos(index).ToString) Then

                            mSomaVlTipo += CDbl(mArrayTipo2(1).ToString)
                        End If
                    Next

                    If mSomaVlTipo > 0 Then
                        If mTipos(index).ToString.Equals("Entr.") Then
                            s.WriteLine(_funcoes.Exibe_StrEsquerda(" TOTAL " & mTipos(index).ToString & ":", 17) & _funcoes.Exibe_StrDireita(Format(Round(mSomaVlTipo, 2), "#,###,##0.00"), 15))
                        Else
                            s.WriteLine(_funcoes.Exibe_StrEsquerda(" TOTAL POR " & mTipos(index).ToString & ":", 17) & _funcoes.Exibe_StrDireita(Format(Round(mSomaVlTipo, 2), "#,###,##0.00"), 15))
                        End If
                    End If
                Next

                's.WriteLine(" ------------------------------------------------------------------------------------------")
                s.WriteLine(vbNewLine)
                's.WriteLine(" .     .     .     .     .     .     .     .     .     .     .     .     .     .     .     .     .")
            End If


            Dim con As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim cmd As NpgsqlCommand
            Dim sql As New StringBuilder
            Dim dr As NpgsqlDataReader
            Dim mSomaPagamentos, mSomaRecebimentos As Double
            mSomaPagamentos = 0 : mSomaRecebimentos = 0

            Try
                con.Open()

                sql.Append("SELECT cx_data, cx_descricao, cx_valor, cx_grupo, cx_tipo FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario ")
                If cbo_opcoes.SelectedIndex = 1 Then
                    sql.Append("WHERE cx_data BETWEEN '" & msk_pesquisa.Text & "' AND '" & msk_periodoFinal.Text & "'")
                End If
                sql.Append("ORDER BY cx_data, cx_grupo ASC")

                cmd = New NpgsqlCommand(sql.ToString, con)
                dr = cmd.ExecuteReader

                s.WriteLine("")
                If dr.HasRows Then s.WriteLine(" RESUMO EXTRA CAIXA")
                While dr.Read


                    strLinha = Format(Convert.ChangeType(dr(0), GetType(Date)), "dd/MM/yyyy") & "  "
                    strLinha += _funcoes.Exibe_StrEsquerda(dr(1).ToString, 40)
                    Select Case dr(4).ToString
                        Case "R" 'RECEBIMENTO
                            strLinha += _funcoes.Exibe_StrDireita("(" & Format(dr(2), "###,##0.00") & ")", 33)
                            mSomaRecebimentos += dr(2)
                        Case "P" 'PAGAMENTO
                            strLinha += _funcoes.Exibe_StrDireita(Format(dr(2), "###,##0.00"), 32)
                            mSomaPagamentos += dr(2)
                        Case "A" 'ABERTURA
                            strLinha += _funcoes.Exibe_StrDireita(Format(dr(2), "###,##0.00"), 32)
                            mSomaAbertura += dr(2)
                        Case "S" 'SALDO FECHAMENTO
                            strLinha += _funcoes.Exibe_StrDireita(Format(dr(2), "###,##0.00"), 32)
                            mSomaFechamento += dr(2)

                    End Select

                    s.WriteLine(strLinha)
                End While


                s.WriteLine("")
                If mSomaPagamentos > 0 Then
                    s.WriteLine(_funcoes.Exibe_StrEsquerda(" TOTAL DE PAGAMENTOS  ", 26) & _funcoes.Exibe_StrDireita(Format(mSomaPagamentos, "###,##0.00"), 17))
                End If

                If mSomaRecebimentos > 0 Then
                    s.WriteLine(_funcoes.Exibe_StrEsquerda(" TOTAL DE RECEBIMENTOS  ", 26) & _funcoes.Exibe_StrDireita(Format(mSomaRecebimentos, "###,##0.00"), 17))
                End If

                s.WriteLine(_funcoes.Exibe_StrEsquerda(" SALDO ATUAL DO CAIXA   -----------------> ", 43) & _funcoes.Exibe_StrEsquerda(Format(Round((mSomaAvista + mSomaRecebimentos + mSomaEntradas + mSomaAbertura) - (mSomaPagamentos + mSomaFechamento), 2), "###,##0.00"), 12))


                s.WriteLine(" ------------------------------------------------------------------------------------------")
            Catch ex As Exception
            End Try

            con.Close()
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) Totais do Pedido", MsgBoxStyle.Exclamation)
            Return

        End Try



    End Sub

    Public Sub GravTotaisPedidoRelatorioMatricial2(ByVal s As StreamWriter)

        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mPedido, mEmissao, mCliente, mVendedor, mTipo, strLinha, strValoresTipo As String
            Dim mCont1, mCont2, index, i As Integer
            Dim mTotal, mSomaTotal, mSomaVlTipo, mSomaEntradas, mEntrada As Double
            Dim mTipos() As String = {"Entr.", "AV", "NP", "CT", "CH", "BL"}
            Dim mContItens As Integer = 0, mContItensPg As Integer = 0, mContPg As Integer = 0
            Dim mArrayTipo1, mArrayTipo2 As Array
            Dim mSomaAvista As Double = 0
            Dim mSomaAbertura, mSomaFechamento As Double
            strValoresTipo = ""



            If Me.dtg_pedidos.RowCount > 0 Then
                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("--------------------------------------------------------------------------------------------")
                s.WriteLine(" Pedido   | Emissão    | Cliente                             | Vendedor | TOTAL      | Tipo ")
                '             xxxxxxxx | xx/xx/xxxx | xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx |  xxxxxx  | 999,999.99 | xxx
                s.WriteLine(" ------------------------------------------------------------------------------------------")
                mCont1 = 20

            End If

            mContItensPg = 6
            mContPg = 1
            mSomaTotal = 0
            mSomaAvista = 0
            For Each row As DataGridViewRow In Me.dtg_pedidos.Rows

                If (row.IsNewRow = False) AndAlso (row.Cells(11).Value.ToString.Equals("6") = False) Then



                    If mContItensPg = 30 Then

                        's.WriteLine("+------------------------------------------------------------------------------------------+")
                        's.WriteLine(" *** CONTINUACAO DO RELATORIO ***  ")
                        's.WriteLine("+------------------------------------------------------------------------------------------+")
                        ''Quebra 10 Linhas para passar para a próxima folha...
                        's.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)



                        mContPg += 1
                        s.WriteLine("+------------------------------------------------------------------------------------------+")
                        s.WriteLine("                    C O N T I N U A C A O . . .               FOLHA: " & String.Format("{0:D3}", mContPg))
                        s.WriteLine("--------------------------------------------------------------------------------------------")
                        s.WriteLine(" Pedido   | Emissão    | Cliente                             | Vendedor | TOTAL      | Tipo ")
                        '             xxxxxxxx | xx/xx/xxxx | xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx |  xxxxxx  | 999,999.99 | xxx
                        s.WriteLine(" ------------------------------------------------------------------------------------------")
                        mContItensPg = 6

                    End If


                    'Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"", n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit ") '9
                    mPedido = row.Cells(2).Value.ToString
                    mEmissao = row.Cells(3).Value.ToString
                    mCliente = row.Cells(5).Value.ToString
                    mVendedor = row.Cells(10).Value.ToString
                    mTotal = row.Cells(8).Value.ToString
                    mTipo = row.Cells(9).Value.ToString
                    Try
                        mEntrada = 0
                        mEntrada = CDbl(row.Cells(13).Value)
                        mSomaEntradas += mEntrada
                    Catch ex As Exception
                        mEntrada = 0
                    End Try
                    mSomaTotal += mTotal

                    strValoresTipo += mTipo & "|" & mTotal & "?"
                    If mTipo.Equals("AV") Then mSomaAvista += mTotal
                    If mEntrada > 0 Then strValoresTipo += "Entr.|" & mEntrada & "?"

                    strLinha = " " & mPedido & " | " & mEmissao & " | " & _
                    _funcoes.Exibe_StrEsquerda(mCliente, 35) & " |  " & _
                    mVendedor & "  | " & _funcoes.Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10) & " | " & _
                    mTipo


                    s.WriteLine(_funcoes.Exibe_Str(strLinha, 99))
                    mContItens += 1 : mContItensPg += 1
                    mCont1 -= 1 : mCont2 -= 1

                End If
            Next


            If mSomaTotal > 0 Then
                s.WriteLine("")
                s.WriteLine(" TOTAL DE VENDAS    " & _funcoes.Exibe_StrDireita(Format(Round(mSomaTotal, 2), "#,###,##0.00"), 12))
                s.WriteLine("")

                For index = 0 To mTipos.Length - 1

                    mSomaVlTipo = 0
                    mArrayTipo1 = Split(strValoresTipo, "?")
                    For i = 0 To mArrayTipo1.Length - 2

                        mArrayTipo2 = Split(mArrayTipo1(i).ToString, "|")
                        If mArrayTipo2(0).ToString.Equals(mTipos(index).ToString) Then

                            mSomaVlTipo += CDbl(mArrayTipo2(1).ToString)
                        End If
                    Next

                    If mSomaVlTipo > 0 Then
                        If mTipos(index).ToString.Equals("Entr.") Then
                            s.WriteLine(_funcoes.Exibe_StrEsquerda(" TOTAL " & mTipos(index).ToString & ":", 17) & _funcoes.Exibe_StrDireita(Format(Round(mSomaVlTipo, 2), "#,###,##0.00"), 15))
                        Else
                            s.WriteLine(_funcoes.Exibe_StrEsquerda(" TOTAL POR " & mTipos(index).ToString & ":", 17) & _funcoes.Exibe_StrDireita(Format(Round(mSomaVlTipo, 2), "#,###,##0.00"), 15))
                        End If

                    End If
                Next

                's.WriteLine(" ------------------------------------------------------------------------------------------")
                s.WriteLine(vbNewLine)
                's.WriteLine(" .     .     .     .     .     .     .     .     .     .     .     .     .     .     .     .     .")
            End If


            Dim con As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim cmd As NpgsqlCommand
            Dim sql As New StringBuilder
            Dim dr As NpgsqlDataReader
            Dim mSomaPagamentos, mSomaRecebimentos As Double
            mSomaPagamentos = 0 : mSomaRecebimentos = 0

            Try
                con.Open()

                sql.Append("SELECT cx_data, cx_descricao, cx_valor, cx_grupo, cx_tipo FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario ")
                If cbo_opcoes.SelectedIndex = 1 Then
                    sql.Append("WHERE cx_data BETWEEN '" & msk_pesquisa.Text & "' AND '" & msk_periodoFinal.Text & "'")
                End If
                sql.Append("ORDER BY cx_data, cx_grupo ASC")

                cmd = New NpgsqlCommand(sql.ToString, con)
                dr = cmd.ExecuteReader

                s.WriteLine("")
                If dr.HasRows Then s.WriteLine(" RESUMO EXTRA CAIXA")
                While dr.Read


                    strLinha = Format(Convert.ChangeType(dr(0), GetType(Date)), "dd/MM/yyyy") & "  "
                    strLinha += _funcoes.Exibe_StrEsquerda(dr(1).ToString, 40)

                    Select Case dr(4).ToString
                        Case "R" 'Recebimento...
                            strLinha += _funcoes.Exibe_StrDireita("(" & Format(dr(2), "###,##0.00") & ")", 33)
                            mSomaRecebimentos += dr(2)
                        Case "P" 'Pagamento...
                            strLinha += _funcoes.Exibe_StrDireita(Format(dr(2), "###,##0.00"), 32)
                            mSomaPagamentos += dr(2)
                        Case "A" 'ABERTURA
                            strLinha += _funcoes.Exibe_StrDireita(Format(dr(2), "###,##0.00"), 32)
                            mSomaAbertura += dr(2)
                        Case "S" 'SALDO FECHAMENTO
                            strLinha += _funcoes.Exibe_StrDireita(Format(dr(2), "###,##0.00"), 32)
                            mSomaFechamento += dr(2)
                    End Select

                    s.WriteLine(strLinha)
                End While


                s.WriteLine("")
                If mSomaPagamentos > 0 Then
                    s.WriteLine(_funcoes.Exibe_StrEsquerda(" TOTAL DE PAGAMENTOS  ", 26) & _funcoes.Exibe_StrDireita(Format(mSomaPagamentos, "###,##0.00"), 17))
                End If

                If mSomaRecebimentos > 0 Then
                    s.WriteLine(_funcoes.Exibe_StrEsquerda(" TOTAL DE RECEBIMENTOS  ", 26) & _funcoes.Exibe_StrDireita(Format(mSomaRecebimentos, "###,##0.00"), 17))
                End If

                s.WriteLine(_funcoes.Exibe_StrEsquerda(" SALDO ATUAL DO CAIXA   -----------------> ", 43) & _funcoes.Exibe_StrEsquerda(Format(Round((mSomaAvista + mSomaRecebimentos + mSomaEntradas + mSomaAbertura) - (mSomaPagamentos + mSomaFechamento), 2), "###,##0.00"), 12))
                s.WriteLine(" ==========================================================================================")







                '                                   *******   CONTAS RECEBIDAS   *******
                s.WriteLine("----------------------------------------------------------------------------------------------------------")
                s.WriteLine("                       *******   CONTAS RECEBIDAS   *******")
                s.WriteLine("NOME DO CLIENTE                Principal   Juros   Descont                                             ")
                s.WriteLine("----------------------------------------------------------------------------------------------------------")
                s.Write("")


            Catch ex As Exception
            End Try

            con.Close()
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) Totais do Pedido", MsgBoxStyle.Exclamation)
            Return

        End Try



    End Sub

    Private Sub executaEspelho(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPRelatorioFluxoPedi.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Truncate, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        Dim s As New StreamWriter(fs)
        _PrintFont1 = New Font("Lucida Console", 10) 'Sans Serif
        Dim strLinha As String = ""
        s.WriteLine(_funcoes.Centraliza_Str("FLUXO DE CAIXA   (" & Format(Date.Now, "dd/MM/yyyy") & ")", 101))
        Dim loja As String = Me.dtg_pedidos.CurrentRow.Cells(1).Value
        Dim numeroPedido As String = Me.dtg_pedidos.CurrentRow.Cells(2).Value
        Dim dtEmissao As String = Me.dtg_pedidos.CurrentRow.Cells(3).Value
        Dim codClient As String = Me.dtg_pedidos.CurrentRow.Cells(4).Value
        Dim nomeClient As String = Me.dtg_pedidos.CurrentRow.Cells(5).Value
        Dim condicao As String = Me.dtg_pedidos.CurrentRow.Cells(9).Value
        Dim codVendedor As String = Me.dtg_pedidos.CurrentRow.Cells(10).Value
        Dim idOrca1 As Int32 = Me.dtg_pedidos.CurrentRow.Cells(0).Value


        Dim lShouldReturn As Boolean
        executaEspelhoExtracted1(s, loja, numeroPedido, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
        If lShouldReturn Then Return

        'Deleta o arquivo temporário...
        s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        s.Dispose()
        File.Delete(mArqTemp)

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo()
        _StringToPrint = ""

    End Sub

    Private Sub executaEspelho2(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPRelatorioFluxoPedi.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Truncate, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        Dim s As New StreamWriter(fs)
        _PrintFont1 = New Font("Lucida Console", 8) 'Sans Serif
        Dim strLinha As String = ""
        s.WriteLine(_funcoes.Centraliza_Str("FLUXO DE CAIXA ANALÍTICO   (" & Format(Date.Now, "dd/MM/yyyy") & ")", 101))
        Dim loja As String = Me.dtg_pedidos.CurrentRow.Cells(1).Value
        Dim numeroPedido As String = Me.dtg_pedidos.CurrentRow.Cells(2).Value
        Dim dtEmissao As String = Me.dtg_pedidos.CurrentRow.Cells(3).Value
        Dim codClient As String = Me.dtg_pedidos.CurrentRow.Cells(4).Value
        Dim nomeClient As String = Me.dtg_pedidos.CurrentRow.Cells(5).Value
        Dim condicao As String = Me.dtg_pedidos.CurrentRow.Cells(9).Value
        Dim codVendedor As String = Me.dtg_pedidos.CurrentRow.Cells(10).Value
        Dim idOrca1 As Int32 = Me.dtg_pedidos.CurrentRow.Cells(0).Value

        Dim lShouldReturn As Boolean
        executaEspelho2Extracted1(s, loja, numeroPedido, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
        If lShouldReturn Then Return

        'Deleta o arquivo temporário...
        s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        s.Dispose()
        File.Delete(mArqTemp)

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo()
        _StringToPrint = ""

    End Sub


    'Recebimento das Duplicatas...
    Public Sub GravRecebDuplicatasMatricial(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, ByVal loja As String, _
                                           ByVal dataInicial As String, ByVal dataFinal As String, _
                                           ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = "", strAux2 As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja, cnpjLoja As String

            nomeLoja = "" : enderLoja = "" : foneLoja = "" : ufLoja = "" : cidLoja = "" : cnpjLoja = ""
            While dr.Read

                nomeLoja = dr(0).ToString : enderLoja = dr(1).ToString
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strAux = _funcoes.Exibe_StrEsquerda(" Empresa: " & _local & "- " & _funcoes.Exibe_StrEsquerda(nomeLoja, 40), 60)
            strAux += _funcoes.Exibe_StrDireita("Caixa de: " & dataInicial & " A " & dataFinal, 40)
            sw.EscreveLn(_funcoes.Exibe_Str(strAux, 100))


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Recebimento das Duplicatas:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub


    Private Sub executaRelatorioFluxoArquivo(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPRelatorioFluxoArquivo.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        sw = New Cl_EscreveArquivo(fs)
        sw.chamaEvento = True
        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler sw.SaltandoLinhasEvento, AddressOf gravaCabecalhoFluxoArquivo
        sw.qtdLinhasPorPagina = 111
        sw.qtdSaltosLinhaNextPag = 2
        _PrintFont1 = New Font("Lucida Console", 7) 'Sans Serif

        'Ajuda a contar caracteres da pagina...
        ''                      1         2         3         4         5         6         7         8         9         0         1         2         3         4         5
        ''             123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        'sw.EscreveLn("===========================================================================================================================")

        Dim loja As String = MdlUsuarioLogando._local
        'Relatório 1º .........................................
        Try

            Dim lShouldReturn As Boolean
            executaRelatorioArquivo1(sw, loja, lShouldReturn)
            If lShouldReturn Then Return
        Catch ex As Exception

            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try
        End Try


        'Relatório 2º .........................................
        Try

            sw.SaltandoLinhasComEscreveLn(sw.qtdLinhasPorPagina - sw.contLinhasPorPagina)
            Dim lShouldReturn As Boolean
            executaRelatorioArquivo2(sw, loja, lShouldReturn)
            If lShouldReturn Then Return
        Catch ex As Exception

            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try
        End Try


        'Relatório 3º .........................................
        Try

            sw.SaltandoLinhasComEscreveLn(sw.qtdLinhasPorPagina - sw.contLinhasPorPagina)
            Dim lShouldReturn As Boolean
            executaRelatorioArquivo3(sw, loja, lShouldReturn)
            If lShouldReturn Then Return
        Catch ex As Exception

            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try
        End Try


        'Deleta o arquivo temporário...
        sw.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        sw.Dispose()
        File.Delete(mArqTemp)

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuContRelatorioArquivo()
        _StringToPrint = ""

    End Sub

    Private Sub gravaCabecalhoFluxoArquivo()

        'Variáveis Totais...
        Dim loja As String = MdlUsuarioLogando._local
        Dim mData As String = Format(dataDoDiaRef, "dd/MM/yyyy")
        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try


        'Loja #########################################
        _mConsulta = "SELECT g_geno, g_ender, g_fone, g_uf, g_cid, g_cgc FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        GravCabLojFluxoArquivoLaser(_mConsulta.ToString, sw, loja, oConnBD, lShouldReturn1)
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 123))
        oConnBD.Close() : oConnBD.Dispose()


    End Sub

    Private Sub executaRelatorioArquivo1(ByRef sw As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False

        'Variáveis Totais...
        Dim mTotaisVendidos As Double = 0, mTotaisAvista As Double = 0, mTotaisCheque As Double = 0
        Dim mTotalCreditos As Double = 0, mTotalDebitos As Double = 0, mTotalDireitos As Double = 0
        Dim mData As String = Format(dataDoDiaRef, "dd/MM/yyyy")

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try

        sw.EscreveLn("")
        'Loja #########################################
        _mConsulta = "SELECT g_geno, g_ender, g_fone, g_uf, g_cid, g_cgc FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        GravCabLojFluxoArquivoLaser(_mConsulta.ToString, sw, loja, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return

        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 123))

        'Traz Soma do Total Duplicatas Geral e as Entradas dos Pedidos ############################
        _mConsulta = "SELECT Sum(n4_tgeral), (SELECT Sum(o1.nt_entrada) FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp o1 " & _
        "WHERE o1.nt_dtemis = '" & mData & "' AND o1.nt_sit BETWEEN 3 AND 5 AND (o1.nt_tiposelecao <> 1 AND o1.nt_tiposelecao <> 2)) " & _
        "FROM " & MdlEmpresaUsu._esqEstab & ".orca4dd JOIN " & MdlEmpresaUsu._esqEstab & ".orca1pp ON nt_orca = n4_nume " & _
        "WHERE nt_dtemis = '" & mData & "' AND nt_sit BETWEEN 3 AND 5 AND (nt_tiposelecao <> 1 AND nt_tiposelecao <> 2)"

        GravEntradasCXFluxoArquivoLaser(_mConsulta.ToString, sw, mTotaisVendidos, mTotaisAvista, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return


        'Traz Soma das Duplicatas Recebidas...
        _mConsulta = "SELECT (SELECT Sum(n4_tgeral) FROM " & MdlEmpresaUsu._esqEstab & ".orca4dd JOIN " & MdlEmpresaUsu._esqEstab & _
        ".orca1pp ON nt_orca = n4_nume WHERE nt_dtemis = '" & mData & "' AND nt_tipo2 = 'NP' AND " & _
        "nt_sit BETWEEN 3 AND 5 AND (nt_tiposelecao <> 1 AND nt_tiposelecao <> 2)) AS ""SomaNP"", " & _
        "(SELECT Sum(n4_tgeral) FROM " & MdlEmpresaUsu._esqEstab & ".orca4dd JOIN " & MdlEmpresaUsu._esqEstab & _
        ".orca1pp ON nt_orca = n4_nume WHERE nt_dtemis = '" & mData & "' AND nt_tipo2 = 'CT' AND " & _
        "nt_sit BETWEEN 3 AND 5 AND (nt_tiposelecao <> 1 AND nt_tiposelecao <> 2)) AS ""SomaCT"", " & _
        "(SELECT Sum(n4_tgeral) FROM " & MdlEmpresaUsu._esqEstab & ".orca4dd JOIN " & MdlEmpresaUsu._esqEstab & _
        ".orca1pp ON nt_orca = n4_nume WHERE nt_dtemis = '" & mData & "' AND nt_tipo2 = 'CR' AND " & _
        "nt_sit BETWEEN 3 AND 5 AND (nt_tiposelecao <> 1 AND nt_tiposelecao <> 2)) AS ""SomaCR"", " & _
        "(SELECT Sum(n4_tgeral) FROM " & MdlEmpresaUsu._esqEstab & ".orca4dd JOIN " & MdlEmpresaUsu._esqEstab & _
        ".orca1pp ON nt_orca = n4_nume WHERE nt_dtemis = '" & mData & "' AND nt_tipo2 = 'CH' AND " & _
        "nt_sit BETWEEN 3 AND 5 AND (nt_tiposelecao <> 1 AND nt_tiposelecao <> 2)) AS ""SomaCH"" "
        GravDuplicatasCXFluxoArquivoLaser(_mConsulta.ToString, sw, mTotaisVendidos, mTotaisCheque, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return

        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 86))
        sw.EscreveLn(_funcoes.Exibe_StrEsquerda("TOTAL VENDIDO", 15) & _funcoes.Exibe_StrDireita(Format(Round(mTotaisVendidos, 2), "##,###,##0.00"), 20))
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 86))
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 86))


        'RESUMO DO ESTOQUE... #############################################
        sw.EscreveLn("RESUMO DE ESTOQUE")
        'Resumo do Estoque...
        _mConsulta = "SELECT (SELECT Count(n4_numer) FROM " & MdlEmpresaUsu._esqEstab & ".nota4ff WHERE n4_dtent = '" & _
        mData & "') AS ""Compr_Produ"", (SELECT Count(em_codigo) FROM " & MdlEmpresaUsu._esqVinc & ".estmov WHERE " & _
        "em_data = '" & mData & "' AND em_loja = '" & MdlUsuarioLogando._local & "' AND em_tipomov = 'A') AS ""ACERT_ESTOQ"", " & _
        "(SELECT Count(nt_nume) FROM " & MdlEmpresaUsu._esqEstab & ".nota1pp WHERE nt_dtemis = '" & mData & "' " & _
        "AND nt_tipo = 'E' AND (SUBSTR(nt_cfop, 3, 3) = '201' OR SUBSTR(nt_cfop, 3, 3) = '202') AND tipo_nt <> 'C') " & _
        "AS ""DEV_VENDA"", "
        If MdlEmpresaUsu.tpTransfEntrada.Equals("1") Then 'Entrada Normal

            _mConsulta += "(SELECT Count(n4_numer) FROM " & MdlEmpresaUsu._esqEstab & ".nota4ff WHERE n4_dtent = " & _
           "'" & mData & "' AND (SUBSTR(n4_cdfisc, 2, 3) = '151' OR SUBSTR(n4_cdfisc, 2, 3) = '152')) AS ""TRANSF_RECEB"", "
        ElseIf MdlEmpresaUsu.tpTransfEntrada.Equals("2") Then 'Entrada Simples

            _mConsulta += "(SELECT Count(n4_numer) FROM " & MdlEmpresaUsu._esqEstab & ".note4ff WHERE n4_dtentrada = " & _
           "'" & mData & "' AND n4_tipomov <> 'T') AS ""TRANSF_RECEB"", "
        Else
            _mConsulta += "0 AS ""TRANSF_RECEB"", "
        End If

        _mConsulta += "(SELECT Count(nt_nume) FROM " & MdlEmpresaUsu._esqEstab & _
                ".nota1pp WHERE nt_dtemis = '" & mData & "' AND nt_tipo = 'S' AND (SUBSTR(nt_cfop, 3, 3) = '201' OR " & _
                "SUBSTR(nt_cfop, 3, 3) = '202') AND tipo_nt <> 'C') AS ""DEV_COMPRA"", 0 AS ""ACERT_EST_MENOS"", " & _
                "(SELECT Count(nt_orca) FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp WHERE nt_dtemis = '" & mData & "' " & _
                "AND nt_sit < 6) AS ""VENDAS"", "
        If MdlEmpresaUsu.tpTransfEntrada.Equals("1") Then 'Saida Normal

            _mConsulta += "(SELECT DISTINCT(nt_nume) FROM " & MdlEmpresaUsu._esqEstab & ".nota1pp " & _
                "WHERE nt_dtemis = '" & mData & "' AND (SUBSTR(nt_cfop, 3, 3) = '151' OR SUBSTR(nt_cfop, 3, 3) = '152')) " & _
                "AS ""TRANSF_ENVIADA"""
        ElseIf MdlEmpresaUsu.tpTransfEntrada.Equals("2") Then 'Saida por Requisição

            _mConsulta += "(SELECT Count(DISTINCT(reqnumero)) FROM " & MdlEmpresaUsu._esqEstab & ".reqtransf " & _
                "WHERE reqdata = '" & mData & "') AS ""TRANSF_ENVIADA"""
        Else
            _mConsulta += "0 AS ""TRANSF_ENVIADA"", "
        End If

        GravResumoEstoqueFluxoArquivoLaser(_mConsulta.ToString, sw, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return


        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 86))


        'Saldos Estoques ###############################################
        _mConsulta = ""
        GravSaldosEstoqueFluxoArquivoLaser(_mConsulta.ToString, sw, mTotaisVendidos, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("=", 86))


        'SALDO ANTERIOR $$ #################################################
        GravSaldoAntDinheiroCXFluxoArquivoLaser(_mConsulta, sw, mTotaisVendidos, mTotaisAvista, mTotaisCheque, _
                                                mTotalCreditos, mTotalDebitos, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 86))


        'TOTAIS SALDOS... ##############################################
        GravTotaisSaldosCXFluxoArquivoLaser(sw, mTotalCreditos, mTotalDebitos, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("=", 86))


        'TOTAIS DUPLICATAS... ##############################################
        _mConsulta = "SELECT (SELECT Sum(f_valor) FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 WHERE (f_tipo = 'NP' " & _
        "OR f_tipo = 'CR')) As ""Duplicatas"", (SELECT Sum(f_valor) FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 WHERE " & _
        "f_tipo = 'CH') As ""Cheque"""
        GravSaldosDuplicatasFluxoArquivoLaser(_mConsulta, sw, mTotalDireitos, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 86))


        'TOTAIS DIREITOS... ##############################################
        _mConsulta = "SELECT Sum(d_valor) FROM fatp001 WHERE d_geno = '" & MdlEmpresaUsu._codigo & "' AND d_sit <> 'L'"
        GravTotaisDireitosFluxoArquivoLaser(_mConsulta, sw, mTotalDireitos, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("=", 86))
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 123))


        ''CONTAS RECEBIDAS... ############################################
        sw.EscreveLn(_funcoes.Centraliza_Str("*******  CONTAS RECEBIDAS  *******", 123))
        sw.EscreveLn("NOME DO CLIENTE                         Principal      Juros     Desconto")
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 123))
        _mConsulta = "SELECT c.p_portad AS ""Cliente"", c.p_cod AS ""Codigo"", Ft.f_tipo AS ""TP"", Ft.f_sit AS ""SIT"", " & _
        "Ft.f_cartei AS ""Carteira"", Ft.f_dtpaga AS ""DtPaga"", Ft.f_valor AS ""Valor R$"", Ft.f_desc AS ""Desconto"", " & _
        "Ft.f_juros AS ""Juros R$"", Substr(Ft.f_hvenc, 1, 5) AS ""HoraPag"", Pc.f_valor AS ""VlrParcial R$"", " & _
        "Pc.f_dtpaga AS ""DtPagParcial"", Substr(Pc.f_hvenc, 1, 5) AS ""HoraPagParcial"" FROM cadp001 c, " & _
        MdlEmpresaUsu._esqEstab & ".fatd001 Ft LEFT OUTER JOIN " & MdlEmpresaUsu._esqEstab & ".fatdp02 Pc ON ft.f_duplic = Pc.f_duplic " & _
        "WHERE (Ft.f_portad = c.p_cod OR Pc.f_portad = c.p_cod) AND (Ft.f_dtpaga = '" & mData & "' OR Pc.f_dtpaga = '" & mData & "') AND " & _
        "(Ft.f_tipo <> 'CH' OR Pc.f_tipo <> 'CH')"
        GravContasRecebidasFluxoArquivoLaser(_mConsulta, sw, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return

        Try
            oConnBD.ClearAllPools()
            oConnBD.Close() : oConnBD = Nothing
        Catch ex As Exception
        End Try

    End Sub

    Private Sub executaRelatorioArquivo2(ByRef sw As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False

        'Variáveis Totais...
        Dim strAux As String = ""

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mData As String = Format(dataDoDiaRef, "dd/MM/yyyy")
        Dim mDataHoje As String = Format(Date.Now, "dd/MM/yyyy")

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try


        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 123))
        sw.EscreveLn(_funcoes.Centraliza_Str("****** LANCAMENTOS DO CAIXA ******", 123))
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 123))

        'LANÇAMENTOS DO CAIXA #########################################
        'Traz Soma do Total Duplicatas Geral e as Entradas dos Pedidos ############################
        _mConsulta = "SELECT cx_valor, cx_hora, cx_usu, cx_descricao, cx_tipo FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario " & _
        "WHERE cx_data = '" & mData & "' AND cx_caixa = '" & MdlUsuarioLogando._codcaixa & "' AND " & _
        "cx_loja = '" & MdlEmpresaUsu._codigo & "'"

        Dim lShouldReturn1 As Boolean
        GravLacamentosCXFluxoArquivoLaser(_mConsulta.ToString, sw, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return


        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 123))
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 123))
        sw.EscreveLn(_funcoes.Centraliza_Str("** PRODUTOS IDENTIFICADOS VENDIDOS **", 123))
        strAux = "NOME DO PRODUTO"
        sw.EscreveLn(strAux & _funcoes.Centraliza_StrTrataLeft("CODIGO IDENTIFICADOR SUBITEM D_COMPRA", 123, strAux.Length))
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("=", 123))
        sw.EscreveLn(_funcoes.Centraliza_Str("* SALDO IRREGULARES DE PRODUTOS IDENTIFICADOS *", 123))
        strAux = _funcoes.Exibe_StrEsquerda("NOME DO PRODUTO", 45) & " "
        strAux += _funcoes.Exibe_StrEsquerda("CODIGO", 6) & " "
        strAux += _funcoes.Exibe_StrDireita("SALDO", 10) & " "
        strAux += _funcoes.Exibe_StrDireita("IDENT", 10) & " "
        strAux += _funcoes.Exibe_StrDireita("DIFER", 10)
        sw.EscreveLn(strAux)


        _mConsulta = "SELECT DISTINCT o.no_codpr, e.e_produt, el.e_qtde As ""EstoqueAtual"", " & _
        "(SELECT Sum(o1.no_qtde) FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc o1 WHERE o1.no_codpr = o.no_codpr AND " & _
        "o1.no_dtemis = '" & mDataHoje & "') As ""QtdeVendida"" FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc o, " & _
        MdlEmpresaUsu._esqVinc & ".est0001 e JOIN estloja01 el ON el.e_codig = e.e_codig AND el.e_loja = '" & _local & _
        "' GROUP BY no_codpr, e.e_produt, el.e_qtde, no_qtde, el.e_codig, e.e_codig, el.e_loja, no_dtemis, " & _
        "el.e_qtde HAVING no_codpr = e.e_codig AND no_dtemis = '" & mDataHoje & "' ORDER BY e.e_produt ASC"

        GravProdutosIdentFluxoArquivoLaser(_mConsulta.ToString, sw, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return

        If (sw.contLinhasPorPagina + 2) <= sw.qtdLinhasPorPagina Then
            sw.EscreveLn(_funcoes.repeteCaracteresPagina("=", 123))
        End If


    End Sub

    Private Sub executaRelatorioArquivo3(ByRef sw As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False

        'Variáveis Totais...
        Dim strAux As String = ""

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mData As String = Format(dataDoDiaRef, "dd/MM/yyyy")
        Dim mDataHoje As String = Format(Date.Now, "dd/MM/yyyy")

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try

        '             00000000  #,###,##0.00   ###,##0.00   ###,##0.00 0                      
        sw.EscreveLn("NUMERO           VALOR   VLR.ENTRADA    DESCONTO PDV CUPOM/NF OPERCAO    PAGAMENTO")

        _mConsulta = "SELECT nt.nt_orca, n4.n4_tgeral, nt.nt_entrada, n4.n4_desc, 0, 0, nt.nt_tipo2, nt.nt_tiposelecao, " & _
        "cad.p_portad FROM cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca1pp nt JOIN " & MdlEmpresaUsu._esqEstab & ".orca4dd " & _
        "n4 ON n4.n4_nume = nt.nt_orca WHERE nt.nt_codig = cad.p_cod AND nt.nt_dtemis = '" & mData & "' AND (nt.nt_tiposelecao <> 1 AND nt.nt_tiposelecao <> 2)"
        Dim lShouldReturn1 As Boolean
        GravPedidosFluxoArquivoLaser(_mConsulta.ToString, sw, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 123))


        sw.EscreveLn(_funcoes.Exibe_StrEsquerda("CLIENTES", 30) & "   QUANT_VEND  VALOR_VENDAS")

        _mConsulta = "SELECT DISTINCT nt.nt_codig, cad.p_portad, (SELECT Sum(o2.no_qtde) FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc o2 " & _
        "WHERE o2.no_cdport = nt.nt_codig AND o2.no_dtemis = '" & mData & "') As ""Qtde_Vendida"", (SELECT Sum(o2.no_prtot) " & _
        "FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc o2 WHERE o2.no_cdport = nt.nt_codig AND o2.no_dtemis = '" & mData & "') As " & _
        """Valor_Vendas"" FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp nt JOIN cadp001 cad ON cad.p_cod = nt.nt_codig WHERE " & _
        "nt.nt_dtemis = '" & mData & "' AND (nt_tiposelecao <> 1 AND nt_tiposelecao <> 2)"
        GravClientesPedidosFluxoArquivoLaser(_mConsulta.ToString, sw, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 123))


        sw.EscreveLn(_funcoes.Exibe_StrEsquerda("PRODUTOS", 32) & "REFERENCIA     SUBITEM  QUANT_VEND VALOR_VENDAS   % VEND")

        _mConsulta = "SELECT DISTINCT o.no_codpr, e.e_produt, (SELECT Sum(o2.no_qtde) FROM " & MdlEmpresaUsu._esqEstab & _
        ".orca2cc o2 WHERE o2.no_codpr = o.no_codpr AND o2.no_dtemis = '" & mData & "') As ""Qtde_Vendida"", " & _
        "(SELECT Sum(o2.no_prtot) FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc o2 WHERE o2.no_codpr = o.no_codpr AND " & _
        "o2.no_dtemis = '" & mData & "') As ""Qtde_Vendida"", " & _
        "(SELECT Sum(o2.no_comis) FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc o2 WHERE o2.no_codpr = o.no_codpr AND " & _
        "o2.no_dtemis = '" & mData & "') As ""Comissao_Vendida"" FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc o LEFT JOIN " & _
        MdlEmpresaUsu._esqVinc & ".est0001 e ON e.e_codig = o.no_codpr WHERE o.no_dtemis = '" & mData & "'"
        GravProdutosPedidosFluxoArquivoLaser(_mConsulta.ToString, sw, oConnBD, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return
        sw.EscreveLn(_funcoes.repeteCaracteresPagina("-", 123))
        sw.SaltandoLinhasComEscreveLn(3)
        sw.EscreveLn("   ______________________________   ______________________________")
        sw.EscreveLn("           REALIZADO POR                    CONFERIDO POR")


    End Sub

    'Cabeçalho da Loja...
    Public Sub GravCabLojFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, ByVal loja As String, _
                                           ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = "", strAux2 As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja, cnpjLoja As String

            nomeLoja = "" : enderLoja = "" : foneLoja = "" : ufLoja = "" : cidLoja = "" : cnpjLoja = ""
            While dr.Read

                nomeLoja = dr(0).ToString : enderLoja = dr(1).ToString
                foneLoja = dr(2).ToString : ufLoja = dr(3).ToString
                cidLoja = dr(4).ToString : cnpjLoja = dr(5).ToString
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            Try
                strAux = ("Usuar:" & MdlUsuarioLogando._usuarioLogin.ToUpper).Substring(0, 13)
            Catch ex As Exception
                strAux = ("Usuar:" & MdlUsuarioLogando._usuarioLogin.ToUpper).Substring(0)
            End Try

            sw.EscreveLn(_funcoes.Centraliza_StrTrataRight(Trim(nomeLoja & "(" & "0" & _local & ")"), 123, strAux.Length) & strAux)


            cnpjLoja = _funcoes.formataCNPJ_CPF(cnpjLoja)
            foneLoja = _funcoes.formataFone(foneLoja)
            strLinha = "CNPJ " & Trim(_funcoes.Exibe_StrEsquerda(cnpjLoja, 19)) & "  "
            strLinha += "Fone " & Trim(_funcoes.Exibe_Str(foneLoja, 15))
            strAux = "Pag: " & sw.paginaAtual
            strAux2 = Date.Now.Hour & ":" & Date.Now.Second & " hs"
            sw.EscreveLn(strAux & _funcoes.Centraliza_StrTrataLeftRight(Trim(strLinha), 123, strAux.Length, strAux2.Length) & strAux2)


            strLinha = cidLoja & " " & ufLoja & ", " & dataDoDiaRef.ToLongDateString
            strAux = "CAIXA"
            strAux2 = Format(Date.Now, "dd/MM/yyyy")
            sw.EscreveLn(strAux & _funcoes.Centraliza_StrTrataLeftRight(Trim(strLinha), 123, strAux.Length, strAux2.Length) & strAux2)


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Entradas do CAIXA no DIA...
    Public Sub GravEntradasCXFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, _
                                               ByRef totaisVendidos As Double, ByRef totaisAvista As Double, _
                                               ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader
            Dim mTotalGeral, mEntradasPedido As Double

            mTotalGeral = 0 : mEntradasPedido = 0
            While dr.Read

                Try
                    mTotalGeral = dr(0) : mEntradasPedido = dr(1)
                Catch ex As Exception
                    mTotalGeral = 0 : mEntradasPedido = 0
                End Try
            End While
            dr.Close() : cmd = Nothing : dr = Nothing

            totaisVendidos += Round((mTotalGeral + mEntradasPedido), 2)
            totaisAvista = Round((mTotalGeral + mEntradasPedido), 2)
            strLinha = Format(Round((mTotalGeral + mEntradasPedido), 2), "##,###,##0.00")
            sw.EscreveLn(_funcoes.Exibe_StrEsquerda("Dinheiro", 13) & _funcoes.Exibe_StrDireita(strLinha, 22))


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Entradas dos Pedidos:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Entradas do CAIXA, Duplicatas no DIA...
    Public Sub GravDuplicatasCXFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, _
                                                 ByRef totaisVendidos As Double, ByRef totaisCheque As Double, _
                                                 ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim mTotalDuplicadas, mTotalNP, mTotalCT, mTotalCR, mTotalCH As Double

            mTotalDuplicadas = 0 : mTotalNP = 0 : mTotalCT = 0 : mTotalCR = 0 : mTotalCH = 0
            While dr.Read

                Try
                    mTotalNP = dr(0)
                Catch ex As Exception
                    mTotalNP = 0
                End Try

                Try
                    mTotalCT = dr(1)
                Catch ex As Exception
                    mTotalCT = 0
                End Try

                Try
                    mTotalCR = dr(2)
                Catch ex As Exception
                    mTotalCR = 0
                End Try

                Try
                    mTotalCH = dr(3)
                Catch ex As Exception
                    mTotalCH = 0
                End Try

                mTotalDuplicadas = Round((mTotalNP + mTotalCT + mTotalCR + mTotalCH), 2)
            End While
            dr.Close() : cmd.CommandText = ""
            totaisCheque = Round(mTotalCH, 2)



            Dim mTotDuplicNP, mTotDuplicCR As Double
            Dim mStrDias As String = "", mStrDiasValor As String = "", mStrDiasAux As String = "", mStrLinhasAux As String = ""
            Dim mArrayDias, mArrayDiasAux, mArrayDiasAux2 As Array
            Dim index As Integer = 0, mDiferencaDias As Integer = 0, index2 As Integer = 0
            Dim mDtEmissao, mDtVencimento As Date
            Dim mExist As Boolean = False
            Dim mValor As Double = 0, mSomaValorDias As Double = 0
            consulta = "SELECT f_tipo, f_emiss, f_vencto, f_valor FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 WHERE f_emiss = '" & Format(dataDoDiaRef, "dd/MM/yyyy") & "' ORDER BY f_tipo"
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            While dr.Read
                mValor = 0
                mExist = False

                Try
                    mDtEmissao = dr(1)
                Catch ex As Exception
                    mDtEmissao = Nothing
                End Try

                Try
                    mDtVencimento = dr(2)
                Catch ex As Exception
                    mDtVencimento = Nothing
                End Try
                mValor = dr(3)

                mDiferencaDias = mDtVencimento.Subtract(mDtEmissao).Days
                If dr(0).ToString.Equals("NP") Then

                    mArrayDias = Split(mStrDias, "?")
                    For index = 0 To mArrayDias.Length - 2

                        If mArrayDias(index).ToString.Equals("NP|" & mDiferencaDias) Then

                            mExist = True
                            Exit For
                        End If
                    Next

                    If mExist = False Then mStrDias += "NP|" & mDiferencaDias & "?"
                    mStrDiasValor += "NP|" & mDiferencaDias & "|" & mValor & "?"


                ElseIf dr(0).ToString.Equals("CR") Then

                    mArrayDias = Split(mStrDias, "?")
                    For index = 0 To mArrayDias.Length - 2

                        If mArrayDias(0).ToString.Equals("CR|" & mDiferencaDias) Then

                            mExist = True
                            Exit For
                        End If
                    Next

                    If mExist = False Then mStrDias += "CR|" & mDiferencaDias & "?"
                    mStrDiasValor += "CR|" & mDiferencaDias & "|" & mValor & "?"
                End If



            End While
            dr.Close() : cmd = Nothing : dr = Nothing

            totaisVendidos += Round(mTotalDuplicadas, 2)
            strLinha = Format(Round(mTotalDuplicadas, 2), "##,###,##0.00")
            sw.EscreveLn(_funcoes.Exibe_StrEsquerda("Duplicadas", 13) & _funcoes.Exibe_StrDireita(strLinha, 22))

            'Tratamento do NP...
            strLinha = Format(Round(mTotalNP, 2), "##,###,##0.00")
            sw.EscreveLn(_funcoes.Exibe_StrDireita("NP:    ", 13) & _funcoes.Exibe_StrDireita(strLinha, 22))
            mArrayDias = Split(mStrDias, "?")
            mArrayDiasAux = Split(mStrDiasValor, "?")
            For index = 0 To mArrayDias.Length - 2 'NP|dias

                mArrayDiasAux2 = Split(mArrayDias(index).ToString, "|")
                mStrLinhasAux = mArrayDiasAux2(1).ToString & " ->"
                For index2 = 0 To mArrayDiasAux.Length - 2

                    mArrayDiasAux2 = Split(mArrayDiasAux(index2).ToString, "|")
                    mStrDiasAux = "NP|" & mArrayDiasAux2(1).ToString 'NP|dias
                    If mArrayDias(index).ToString.Equals(mStrDiasAux) Then

                        Try
                            mSomaValorDias += CDbl(mArrayDiasAux2(2).ToString)
                        Catch ex As Exception
                            mSomaValorDias += 0
                        End Try
                    End If
                Next

                If mSomaValorDias > 0 Then
                    strLinha = Format(Round(mSomaValorDias, 2), "##,###,##0.00")
                    sw.EscreveLn(_funcoes.Exibe_StrDireita(mStrLinhasAux, 13) & _funcoes.Exibe_StrDireita(strLinha, 22))
                End If


            Next

            'Tratamento do CR...
            strLinha = Format(Round(mTotalCR, 2), "##,###,##0.00")
            sw.EscreveLn(_funcoes.Exibe_StrDireita("CR:    ", 13) & _funcoes.Exibe_StrDireita(strLinha, 22))
            mArrayDias = Split(mStrDias, "?")
            mArrayDiasAux = Split(mStrDiasValor, "?")
            For index = 0 To mArrayDias.Length - 2 'CR|dias

                mArrayDiasAux2 = Split(mArrayDias(index).ToString, "|")
                mStrLinhasAux = mArrayDiasAux2(1).ToString & " ->"
                mSomaValorDias = 0
                For index2 = 0 To mArrayDiasAux.Length - 2

                    mArrayDiasAux2 = Split(mArrayDiasAux(index2).ToString, "|")
                    mStrDiasAux = "CR|" & mArrayDiasAux2(1).ToString 'CR|dias
                    If mArrayDias(index).ToString.Equals(mStrDiasAux) Then

                        Try
                            mSomaValorDias += CDbl(mArrayDiasAux2(2).ToString)
                        Catch ex As Exception
                            mSomaValorDias += 0
                        End Try
                    End If
                Next

                If mSomaValorDias > 0 Then
                    strLinha = Format(Round(mSomaValorDias, 2), "##,###,##0.00")
                    sw.EscreveLn(_funcoes.Exibe_StrDireita(mStrLinhasAux, 13) & _funcoes.Exibe_StrDireita(strLinha, 22))
                End If


            Next

            totaisVendidos += Round((mTotalCT + mTotalCH), 2)
            strLinha = Format(Round(mTotalCT, 2), "##,###,##0.00")
            sw.EscreveLn(_funcoes.Exibe_StrEsquerda("CARTAO ->", 13) & _funcoes.Exibe_StrDireita(strLinha, 22))
            strLinha = Format(Round(mTotalCH, 2), "##,###,##0.00")
            sw.EscreveLn(_funcoes.Exibe_StrEsquerda("CHEQUE ->", 13) & _funcoes.Exibe_StrDireita(strLinha, 22))
            oConnBD.ClearAllPools()


        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Entradas das Duplicatas:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Entradas do Resumo de Estoque...
    Public Sub GravResumoEstoqueFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, _
                                               ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strLinhaAux As String = ""

            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader
            Dim mSomaComprProducao, mSomaAcertoEstoque, mSomaDevolucaoVendas, mSomaTransfRecebidas As Integer
            Dim mSomaDevolucaoCompras, mSomaAcertoEstoque2, mSomaVendas, mSomaTransfEnviadas As Integer

            mSomaComprProducao = 0 : mSomaAcertoEstoque = 0 : mSomaDevolucaoVendas = 0 : mSomaTransfRecebidas = 0
            mSomaDevolucaoCompras = 0 : mSomaAcertoEstoque2 = 0 : mSomaVendas = 0 : mSomaTransfEnviadas = 0
            While dr.Read

                Try

                    mSomaComprProducao = dr(0)
                    mSomaAcertoEstoque = dr(1)
                    mSomaDevolucaoVendas = dr(2)
                    mSomaTransfRecebidas = dr(3)
                    mSomaDevolucaoCompras = dr(4)
                    mSomaAcertoEstoque2 = dr(5)
                    mSomaVendas = dr(6)
                    mSomaTransfEnviadas = dr(7)
                Catch ex As Exception
                End Try
            End While
            dr.Close() : cmd = Nothing : dr = Nothing

            strLinha = _funcoes.Exibe_StrEsquerda("Compras/Producao (+)", 20) & _funcoes.Exibe_StrDireita(mSomaComprProducao, 7)
            strLinhaAux = _funcoes.Exibe_StrDireita("Devolucao Compras(-)", 28) & _funcoes.Exibe_StrDireita(mSomaComprProducao, 7)
            sw.EscreveLn(strLinha & strLinhaAux)

            strLinha = _funcoes.Exibe_StrEsquerda("Acerto Estoque   (+)", 20) & _funcoes.Exibe_StrDireita(mSomaComprProducao, 7)
            strLinhaAux = _funcoes.Exibe_StrDireita("Acerto Estoque   (-)", 28) & _funcoes.Exibe_StrDireita(mSomaComprProducao, 7)
            sw.EscreveLn(strLinha & strLinhaAux)

            strLinha = _funcoes.Exibe_StrEsquerda("Devolução Vendas (+)", 20) & _funcoes.Exibe_StrDireita(mSomaComprProducao, 7)
            strLinhaAux = _funcoes.Exibe_StrDireita("Vendas           (-)", 28) & _funcoes.Exibe_StrDireita(mSomaComprProducao, 7)
            sw.EscreveLn(strLinha & strLinhaAux)

            strLinha = _funcoes.Exibe_StrEsquerda("Transf.Recebidas (+)", 20) & _funcoes.Exibe_StrDireita(mSomaComprProducao, 7)
            strLinhaAux = _funcoes.Exibe_StrDireita("Transf.Enviadas  (-)", 28) & _funcoes.Exibe_StrDireita(mSomaComprProducao, 7)
            sw.EscreveLn(strLinha & strLinhaAux)


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Resumo do Estoque:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Soma dos Saldos de Estoque...
    Public Sub GravSaldosEstoqueFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, ByVal totaisVendidos As Double, _
                                               ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strLinhaAux As String = ""
            Dim mExisteSaldo As Boolean = False
            Dim mData As Date
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            mExisteSaldo = _funcoes.existSaldoEstoque(MdlConexaoBD.dataServidor, _local, "P", MdlConexaoBD.conectionPadrao)

            consulta = "SELECT CAST( Sum(round(CAST((el.e_qtde * el.e_pvenda) AS Numeric(15,2)), 2)) As Double Precision) As ""Soma_PVenda"", " & _
            "CAST( Sum(round(CAST((el.e_qtde * el.e_pcusto) AS Numeric(15,2)), 2)) As Double Precision) As ""Soma_PCusto"", " & _
            "Count(el.e_codig) AS ""Qtde_Itens"" FROM estloja01 el LEFT JOIN " & _
            MdlEmpresaUsu._esqVinc & ".est0001 e ON e.e_codig = el.e_codig WHERE el.e_loja = '" & _local & "' AND el.e_qtde > 0"
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim mSomaPVenda, mSomaPCusto, mSomaVendPrCompra, mSomaLucroVendas As Double
            Dim mSomaItens As Integer
            Dim mQtdeEstornadas As Integer = 0
            mSomaItens = 0 : mSomaPCusto = 0 : mSomaPVenda = 0 : mSomaVendPrCompra = 0 : mSomaLucroVendas = 0

            While dr.Read

                mSomaPVenda = dr(0)
                mSomaPCusto = dr(1)
                mSomaItens = dr(2)
            End While
            dr.Close() : cmd.CommandText = ""


            'Seta Objeto Estoque Financeiro POSITIVO...
            objEstFinanceiro.pData = MdlConexaoBD.dataServidor
            objEstFinanceiro.pLoja = _local
            objEstFinanceiro.pTotalVenda = mSomaPVenda
            objEstFinanceiro.pTotalCusto = mSomaPCusto
            objEstFinanceiro.pTotalItens = mSomaItens
            objEstFinanceiro.pTipoSaldo = "P"

            Try

                If mExisteSaldo Then

                    _clBD.altEstFinanceiroPorDataLoja(objEstFinanceiro, oConnBD)
                Else
                    _clBD.incEstFinanceiro(objEstFinanceiro, oConnBD)
                End If
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            End Try

            strLinha = _funcoes.Exibe_StrEsquerda("Saldo do Estoque", 17) & _funcoes.Exibe_StrDireita(Format(mSomaPVenda, "###,###,##0.00"), 18)
            strLinhaAux = _funcoes.Exibe_StrDireita("Unidades:", 12) & _funcoes.Exibe_StrDireita(mSomaItens, 8)
            sw.EscreveLn(strLinha & strLinhaAux)


            mExisteSaldo = _funcoes.existSaldoEstoque(MdlConexaoBD.dataServidor, _local, "N", MdlConexaoBD.conectionPadrao)

            consulta = "SELECT CAST( Sum(round(CAST((Abs(el.e_qtde) * el.e_pvenda) AS Numeric(15,2)), 2)) As Double Precision) As ""Soma_PVenda"", " & _
            "CAST( Sum(round(CAST((Abs(el.e_qtde) * el.e_pcusto) AS Numeric(15,2)), 2)) As Double Precision) As ""Soma_PCusto"", " & _
            "Count(el.e_codig) AS ""Qtde_Itens"" FROM estloja01 el LEFT JOIN " & _
            MdlEmpresaUsu._esqVinc & ".est0001 e ON e.e_codig = el.e_codig WHERE el.e_loja = '" & _local & "' AND el.e_qtde < 0"
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader
            mSomaItens = 0 : mSomaPVenda = 0 : mSomaPCusto = 0

            If dr.HasRows Then

                While dr.Read

                    mSomaItens = dr(2)
                    Try
                        mSomaPVenda = dr(0)
                    Catch ex As Exception
                    End Try
                    Try
                        mSomaPCusto = dr(1)
                    Catch ex As Exception
                    End Try

                End While
            End If
            dr.Close() : cmd.CommandText = ""


            'Seta Objeto Estoque Financeiro NEGATIVO...
            objEstFinanceiro.pData = MdlConexaoBD.dataServidor
            objEstFinanceiro.pLoja = _local
            objEstFinanceiro.pTotalVenda = mSomaPVenda
            objEstFinanceiro.pTotalCusto = mSomaPCusto
            objEstFinanceiro.pTotalItens = mSomaItens
            objEstFinanceiro.pTipoSaldo = "N"

            Try

                If mExisteSaldo Then

                    _clBD.altEstFinanceiroPorDataLoja(objEstFinanceiro, oConnBD)
                Else
                    _clBD.incEstFinanceiro(objEstFinanceiro, oConnBD)
                End If
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            End Try

            strLinha = _funcoes.Exibe_StrEsquerda("Saldos Negativos", 17) & _funcoes.Exibe_StrDireita(Format(mSomaPVenda, "###,###,##0.00"), 18)
            strLinhaAux = _funcoes.Exibe_StrDireita("Unidades:", 12) & _funcoes.Exibe_StrDireita(mSomaItens, 8)
            sw.EscreveLn(strLinha & strLinhaAux)



            'Tratamento da Data Anterior POSITIVO...
            mData = dataDoDiaRef
            mData = DateSerial(dataDoDiaRef.Year, dataDoDiaRef.Month, dataDoDiaRef.Day - 1)
            consulta = "SELECT ef_totalvenda, ef_totalcusto, ef_totalitens FROM estfinanceiro WHERE ef_data = '" & Format(mData, "dd/MM/yyyy") & "' " & _
            "AND ef_loja = '" & _local & "' AND ef_tiposaldo = 'P'"
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader
            mSomaPVenda = 0 : mSomaPCusto = 0 : mSomaItens = 0

            If dr.HasRows Then

                While dr.Read
                    mSomaPVenda = dr(0) : mSomaPCusto = dr(1) : mSomaItens = dr(2)
                End While
            Else


                mData = DateSerial(dataDoDiaRef.Year, dataDoDiaRef.Month, dataDoDiaRef.Day - 2)
                consulta = "SELECT ef_totalvenda, ef_totalcusto, ef_totalitens FROM estfinanceiro WHERE ef_data = '" & Format(mData, "dd/MM/yyyy") & "' " & _
                "AND ef_loja = '" & _local & "' AND ef_tiposaldo = 'P'"
                cmd = New NpgsqlCommand(consulta, oConnBD)
                dr = cmd.ExecuteReader
                If dr.HasRows Then

                    While dr.Read
                        mSomaPVenda = dr(0) : mSomaPCusto = dr(1) : mSomaItens = dr(2)
                    End While
                Else


                    mData = DateSerial(dataDoDiaRef.Year, dataDoDiaRef.Month, dataDoDiaRef.Day - 3)
                    consulta = "SELECT ef_totalvenda, ef_totalcusto, ef_totalitens FROM estfinanceiro WHERE ef_data = '" & Format(mData, "dd/MM/yyyy") & "' " & _
                    "AND ef_loja = '" & _local & "' AND ef_tiposaldo = 'P'"
                    cmd = New NpgsqlCommand(consulta, oConnBD)
                    dr = cmd.ExecuteReader
                    If dr.HasRows Then

                        While dr.Read

                            mSomaPVenda = dr(0) : mSomaPCusto = dr(1) : mSomaItens = dr(2)
                        End While
                    End If
                End If
            End If
            dr.Close() : cmd.CommandText = ""

            strLinha = _funcoes.Exibe_StrEsquerda("Saldo Anterior(+)", 17) & _funcoes.Exibe_StrDireita(Format(mSomaPVenda, "###,###,##0.00"), 18)
            strLinhaAux = _funcoes.Exibe_StrDireita("Unidades:", 12) & _funcoes.Exibe_StrDireita(mSomaItens, 8)
            sw.EscreveLn(strLinha & strLinhaAux)



            'Saldo Anterior NEGATIVO...
            'mData = DateSerial(dataDoDia_Ref.Year, dataDoDia_Ref.Month, dataDoDia_Ref.Day - 3)
            consulta = "SELECT ef_totalvenda, ef_totalcusto, ef_totalitens FROM estfinanceiro WHERE ef_data = '" & Format(mData, "dd/MM/yyyy") & "' " & _
            "AND ef_loja = '" & _local & "' AND ef_tiposaldo = 'N'"
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader
            If dr.HasRows Then

                While dr.Read

                    mSomaPVenda = dr(0) : mSomaPCusto = dr(1) : mSomaItens = dr(2)
                End While
            End If
            dr.Close() : cmd.CommandText = ""

            strLinha = _funcoes.Exibe_StrEsquerda("Saldo Anterior(-)", 17) & _funcoes.Exibe_StrDireita(Format(mSomaPVenda, "###,###,##0.00"), 18)
            strLinhaAux = _funcoes.Exibe_StrDireita("Unidades:", 12) & _funcoes.Exibe_StrDireita(mSomaItens, 8)
            sw.EscreveLn(strLinha & strLinhaAux)



            consulta = "SELECT Sum(no_qtde) FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc RIGHT JOIN loja1.orca1pp ON nt_orca = no_orca " & _
            "WHERE nt_sit = 6 AND nt_dtemis = '" & dataDoDiaRef & "'"
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader
            mQtdeEstornadas = 0
            If dr.HasRows Then

                While dr.Read

                    Try
                        mQtdeEstornadas = dr(0)
                    Catch ex As Exception
                    End Try
                End While
            End If
            dr.Close() : cmd.CommandText = ""
            strLinha = _funcoes.Exibe_StrEsquerda("Quantidades Estornadas  (+)", 28) & _funcoes.Exibe_StrDireita(mQtdeEstornadas, 7)
            sw.EscreveLn(strLinha)



            consulta = " SELECT Sum((no_qtde * e_pcomp)) FROM estloja01, " & MdlEmpresaUsu._esqEstab & ".orca2cc RIGHT JOIN " & MdlEmpresaUsu._esqEstab & ".orca1pp " & _
            "ON nt_orca = no_orca WHERE no_codpr = e_codig AND e_loja = '" & _local & "' AND nt_sit BETWEEN 3 AND 5 AND nt_dtemis = '" & Format(dataDoDiaRef, "dd/MM/yyyy") & "'"
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader
            mSomaVendPrCompra = 0
            If dr.HasRows Then

                While dr.Read

                    Try
                        mSomaVendPrCompra = dr(0)
                    Catch ex As Exception
                    End Try
                End While
            End If
            strLinha = _funcoes.Exibe_StrEsquerda("Venda Prc_Compra", 17) & _funcoes.Exibe_StrDireita(Format(mSomaVendPrCompra, "###,###,##0.00"), 18)
            sw.EscreveLn(strLinha)


            mSomaPVenda = Round((totaisVendidos - mSomaVendPrCompra), 2)
            strLinha = _funcoes.Exibe_StrEsquerda("Lucro das Vendas", 17) & _funcoes.Exibe_StrDireita(Format(mSomaPVenda, "###,###,##0.00"), 18)
            sw.EscreveLn(strLinha)

            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Saldo do Estoque:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'SALDO ANTERIOR CAIXA...
    Public Sub GravSaldoAntDinheiroCXFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, _
                                               ByVal totaisVendidos As Double, ByVal totaisAvista As Double, _
                                               ByVal totaisCheque As Double, ByRef totalCreditos As Double, _
                                               ByRef totalDebitos As Double, ByVal oConnBD As NpgsqlConnection, _
                                               ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strLinhaAux As String = ""
            Dim mData As Date
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader
            Dim mTotalSaldoAnterior, mTotalSaldoDia, mTotalContasRetiradas, mTotalContasRecebidas, mTotalCheques, mSaldoCaixa As Double
            mTotalSaldoAnterior = 0 : mTotalSaldoDia = 0 : mTotalContasRetiradas = 0 : mTotalCheques = 0 : mSaldoCaixa = 0
            mTotalContasRecebidas = 0


            'Tratamento da Data Anterior...
            mData = dataDoDiaRef
            mData = DateSerial(dataDoDiaRef.Year, dataDoDiaRef.Month, dataDoDiaRef.Day - 1)
            consulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_data = '" & Format(mData, "dd/MM/yyyy") & "' " & _
            "AND cx_tipo = 'S'"
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            If dr.HasRows Then

                While dr.Read

                    Try
                        mTotalSaldoAnterior = dr(0)
                    Catch ex As Exception
                    End Try
                End While
            Else


                mData = DateSerial(dataDoDiaRef.Year, dataDoDiaRef.Month, dataDoDiaRef.Day - 2)
                consulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_data = '" & Format(mData, "dd/MM/yyyy") & "' " & _
                "AND cx_tipo = 'S'"
                cmd = New NpgsqlCommand(consulta, oConnBD)
                dr = cmd.ExecuteReader
                If dr.HasRows Then

                    While dr.Read

                        Try
                            mTotalSaldoAnterior = dr(0)
                        Catch ex As Exception
                        End Try
                    End While
                Else


                    mData = DateSerial(dataDoDiaRef.Year, dataDoDiaRef.Month, dataDoDiaRef.Day - 3)
                    consulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_data = '" & Format(mData, "dd/MM/yyyy") & "' " & _
                    "AND cx_tipo = 'S'"
                    cmd = New NpgsqlCommand(consulta, oConnBD)
                    dr = cmd.ExecuteReader
                    If dr.HasRows Then

                        While dr.Read

                            Try
                                mTotalSaldoAnterior = dr(0)
                            Catch ex As Exception
                            End Try
                        End While
                    End If
                End If
            End If
            dr.Close() : cmd.CommandText = ""

            strLinha = _funcoes.Exibe_StrEsquerda("SALDO ANTERIOR", 17) & _funcoes.Exibe_StrDireita(Format(mTotalSaldoAnterior, "###,###,##0.00"), 18)
            strLinha += " (+)"
            sw.EscreveLn(strLinha)
            sw.EscreveLn("")


            sw.EscreveLn("DINHEIRO")
            strLinha = _funcoes.Exibe_StrEsquerda("  Vendas a Vista", 17) & _funcoes.Exibe_StrDireita(Format(totaisAvista, "###,###,##0.00"), 18)
            strLinha += " (+)"
            sw.EscreveLn(strLinha)



            mData = dataDoDiaRef
            consulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_data = '" & Format(mData, "dd/MM/yyyy") & "' " & _
            "AND cx_tipo = 'S'"
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            If dr.HasRows Then

                While dr.Read

                    Try
                        mTotalSaldoDia = dr(0)
                    Catch ex As Exception
                    End Try
                End While
            End If
            dr.Close() : cmd.CommandText = ""



            mData = dataDoDiaRef
            consulta = "SELECT (SELECT Sum(f1.f_valor) FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 f1 WHERE f1.f_dtpaga = '" & Format(mData, "dd/MM/yyyy") & _
            "' AND f1.f_tipo <> 'CH') As ""PagLiquidado"", (SELECT Sum(f2.f_valor) FROM " & MdlEmpresaUsu._esqEstab & ".fatdp02 f2 WHERE f2.f_dtpaga = '" & _
            Format(mData, "dd/MM/yyyy") & "' AND f2.f_tipo <> 'CH') As ""PagParcial"""
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            If dr.HasRows Then

                While dr.Read

                    Try
                        mTotalContasRecebidas = dr(0)
                    Catch ex As Exception
                    End Try
                End While
            End If
            dr.Close() : cmd.CommandText = ""

            mData = dataDoDiaRef
            consulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_data = '" & Format(mData, "dd/MM/yyyy") & "' " & _
            "AND cx_tipo = 'P'"
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            If dr.HasRows Then

                While dr.Read

                    Try
                        mTotalContasRetiradas = dr(0)
                    Catch ex As Exception
                    End Try
                End While
            End If
            dr.Close() : cmd.CommandText = ""


            strLinha = _funcoes.Exibe_StrDireita("Contas Recebidas", 16) & _funcoes.Exibe_StrDireita(Format(mTotalContasRecebidas, "###,###,##0.00"), 19)
            strLinha += " (+)"
            sw.EscreveLn(strLinha)
            strLinha = _funcoes.Exibe_StrDireita("Suprimentos", 16) & _funcoes.Exibe_StrDireita(Format(mTotalSaldoDia, "###,###,##0.00"), 19)
            strLinha += " (+)"
            sw.EscreveLn(strLinha)
            strLinha = _funcoes.Exibe_StrDireita("Retiradas", 16) & _funcoes.Exibe_StrDireita(Format(mTotalContasRetiradas, "###,###,##0.00"), 19)
            strLinha += " (-)"
            sw.EscreveLn(strLinha)
            sw.EscreveLn("")



            sw.EscreveLn("CHEQUE")
            strLinha = _funcoes.Exibe_StrDireita("a Vista", 16) & _funcoes.Exibe_StrDireita(Format(0.0, "###,###,##0.00"), 19)
            strLinha += " (+)"
            sw.EscreveLn(strLinha)
            strLinha = _funcoes.Exibe_StrDireita("a Prazo", 16) & _funcoes.Exibe_StrDireita(Format(totaisCheque, "###,###,##0.00"), 19)
            strLinha += " (+)"
            sw.EscreveLn(strLinha)
            sw.EscreveLn("")

            totalCreditos = (totaisAvista + mTotalContasRecebidas + mTotalSaldoDia)
            totalDebitos = mTotalContasRetiradas
            mSaldoCaixa = Round((totaisAvista + mTotalContasRecebidas + mTotalSaldoDia) - mTotalContasRetiradas, 2)
            strLinha = _funcoes.Exibe_StrDireita("SALDO DO CAIXA", 16) & _funcoes.Exibe_StrDireita(Format(mSaldoCaixa, "###,###,##0.00"), 19)
            sw.EscreveLn(strLinha)


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar os SALDOS de CAIXA da LOJA:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Totais Saldos...
    Public Sub GravTotaisSaldosCXFluxoArquivoLaser(ByRef sw As Cl_EscreveArquivo, ByVal totaisCreditos As Double, _
                                                   ByVal totaisDebitos As Double, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""

            strLinha = _funcoes.Exibe_StrEsquerda("Total Creditos", 16) & _funcoes.Exibe_StrDireita(Format(totaisCreditos, "###,###,##0.00"), 19)
            sw.EscreveLn(strLinha)
            strLinha = _funcoes.Exibe_StrEsquerda("Total Debitos", 16) & _funcoes.Exibe_StrDireita(Format(totaisDebitos, "###,###,##0.00"), 19)
            sw.EscreveLn(strLinha)
            strLinha = _funcoes.Exibe_StrEsquerda("Resultado do Dia", 16) & _funcoes.Exibe_StrDireita(Format(Round(totaisCreditos - totaisDebitos, 2), "###,###,##0.00"), 19)
            sw.EscreveLn(strLinha)

        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar os Totais dos Saldos:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Saldos Duplicatas...
    Public Sub GravSaldosDuplicatasFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, _
                                                     ByRef totalDireitos As Double, ByVal oConnBD As NpgsqlConnection, _
                                                     ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim mSomaDuplicatas As Double = 0, mSomaCheques As Double = 0

            While dr.Read

                Try
                    mSomaDuplicatas = dr(0)
                Catch ex As Exception
                End Try
                Try
                    mSomaCheques = dr(1)
                Catch ex As Exception
                End Try

            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            totalDireitos = Round(mSomaDuplicatas + mSomaCheques, 2)
            strLinha = _funcoes.Exibe_StrEsquerda("Saldo Duplicatas", 17) & _funcoes.Exibe_StrDireita(Format(mSomaDuplicatas, "###,###,##0.00"), 18)
            sw.EscreveLn(strLinha)
            strLinha = _funcoes.Exibe_StrEsquerda("Saldo Cheques", 17) & _funcoes.Exibe_StrDireita(Format(mSomaCheques, "###,###,##0.00"), 18)
            sw.EscreveLn(strLinha)


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Saldo das Duplicatas:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Totais Direitos...
    Public Sub GravTotaisDireitosFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, _
                                                     ByVal totalDireitos As Double, ByVal oConnBD As NpgsqlConnection, _
                                                     ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim mSomaContasPagar As Double = 0

            While dr.Read

                Try
                    mSomaContasPagar = dr(0)
                Catch ex As Exception
                End Try
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            strLinha = _funcoes.Exibe_StrEsquerda("TOTAL DIREITOS", 17) & _funcoes.Exibe_StrDireita(Format(totalDireitos, "###,###,##0.00"), 18)
            sw.EscreveLn(strLinha)
            strLinha = _funcoes.Exibe_StrEsquerda("CONTAS A PAGAR", 17) & _funcoes.Exibe_StrDireita(Format(mSomaContasPagar, "###,###,##0.00"), 18)
            sw.EscreveLn(strLinha)


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar os Saldo Direitos:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'CONTAS RECEBIDAS...
    Public Sub GravContasRecebidasFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, _
                                                    ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = ""

            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader
            Dim mSomaTotalRecebidas As Double = 0, mSomaDinheiro As Double = 0, mContRegistros As Integer = 0
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim mNomeCliente As String = "", mCodCliente As String = "", mTipo As String = "", mSit As String = ""
            Dim mCarteira As String = "", mDataPaga As String = "", mValor As Double = 0, mDesc As Double = 0
            Dim mJuros As Double = 0, mHoraPaga As String = "", mValorParcial As Double = 0
            Dim mDtPagParcial As String = "", mHoraPagParcial As String = ""

            While dr.Read

                mValor = 0 : mValorParcial = 0
                'Principal...
                mNomeCliente = dr(0).ToString
                mCodCliente = dr(1).ToString
                mTipo = dr(2).ToString
                mSit = dr(3).ToString
                mCarteira = dr(4).ToString
                Try
                    mDataPaga = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
                Catch ex As Exception
                    mDataPaga = ""
                End Try
                Try
                    mValor = dr(6)
                Catch ex As Exception
                    mValor = 0
                End Try

                Try
                    mDesc = dr(7)
                Catch ex As Exception
                    mDesc = 0
                End Try

                Try
                    mJuros = dr(8)
                Catch ex As Exception
                    mJuros = 0
                End Try

                mHoraPaga = dr(9).ToString



                'Parcial...
                Try
                    mValorParcial = dr(10)
                Catch ex As Exception
                    mValorParcial = 0
                End Try

                Try
                    mDtPagParcial = Format(Convert.ChangeType(dr(11), GetType(Date)), "dd/MM/yyyy")
                Catch ex As Exception
                    mDtPagParcial = ""
                End Try

                mHoraPagParcial = dr(12).ToString


                strLinha = _funcoes.Exibe_Str(mNomeCliente.ToUpper, 30) & " " & mCodCliente
                If mValorParcial > 0 Then

                    strLinha += _funcoes.Exibe_StrDireita(Format(mValorParcial, "###,##0.00"), 12) & _
                    _funcoes.Exibe_StrDireita(Format(mJuros, "##,##0.00"), 11) & _
                    _funcoes.Exibe_StrDireita(Format(mDesc, "##,##0.00"), 13) & _
                    _funcoes.Exibe_StrDireita("LP", 7) & _
                    _funcoes.Exibe_StrDireita(mCarteira, 5) & _
                    _funcoes.Exibe_StrDireita(mHoraPagParcial, 11)
                    mSomaTotalRecebidas += mValorParcial

                Else

                    strLinha += _funcoes.Exibe_StrDireita(Format(mValor, "###,##0.00"), 12) & _
                    _funcoes.Exibe_StrDireita(Format(mJuros, "##,##0.00"), 11) & _
                    _funcoes.Exibe_StrDireita(Format(mDesc, "##,##0.00"), 13) & _
                    _funcoes.Exibe_StrDireita("L", 7) & _
                    _funcoes.Exibe_StrDireita(mCarteira, 5) & _
                    _funcoes.Exibe_StrDireita(mHoraPaga, 11)
                    mSomaTotalRecebidas += mValor

                End If
                sw.EscreveLn(strLinha)
                mContRegistros += 1


            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            sw.EscreveLn("")
            strLinha = _funcoes.Exibe_StrEsquerda("Total Recebidas:", 20) & _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalRecebidas, 2), "##,###,##0.00"), 15)
            sw.EscreveLn(strLinha)
            strLinha = _funcoes.Exibe_StrEsquerda("Dinheiro       :", 20) & _funcoes.Exibe_StrDireita(Format(Round(mSomaTotalRecebidas, 2), "##,###,##0.00"), 15)
            strLinha += _funcoes.Exibe_StrDireita("0,00 (", 10) & _funcoes.Exibe_StrDireita(mContRegistros & ")", 6)
            sw.EscreveLn(strLinha)


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar as Contas Recebidas: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'LANÇAMENTOS DO CAIXA...
    Public Sub GravLacamentosCXFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, _
                                                    ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = ""

            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader
            Dim mSomaTotalRecebidas As Double = 0, mSomaDinheiro As Double = 0, mContRegistros As Integer = 0
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim mDescricao As String = "", mUsuario As String = "", mTipo As String = ""
            Dim mValor As Double = 0, mHora As String = "", mDescrTipo As String = ""

            If dr.HasRows Then sw.EscreveLn("0   CAIXA")
            While dr.Read

                mHora = dr(1).ToString
                mUsuario = dr(2).ToString
                mDescricao = dr(3).ToString
                mTipo = dr(4).ToString
                Try
                    mValor = dr(0)
                Catch ex As Exception
                    mValor = 0
                End Try

                strAux = "C"
                If mTipo.Equals("P") Then strAux = "D"
                If mTipo.Equals("R") OrElse mTipo.Equals("S") Then strAux = "C"
                strLinha = _funcoes.Exibe_StrEsquerda(strAux, 2) & " " & _funcoes.Exibe_StrDireita(Format(mValor, "###,##0.00"), 11) & " "
                strLinha += _funcoes.Exibe_StrDireita(mHora, 9) & " " & _funcoes.Exibe_StrDireita(mUsuario, 11) & " "
                If strAux.Equals("C") Then
                    strLinha += _funcoes.Exibe_StrEsquerda("SUPRIMENTO", 11) & " | "
                Else
                    strLinha += _funcoes.Exibe_StrEsquerda("RETIRADAS", 11) & " | "
                End If
                strLinha += _funcoes.Exibe_StrEsquerda(mDescricao, 36)

                sw.EscreveLn(strLinha)
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar os Lançamentos do Caixa: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'PRODUTOS IDENTIFICADOS...
    Public Sub GravProdutosIdentFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, _
                                                    ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = ""

            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader
            Dim mSomaTotalRecebidas As Double = 0, mSomaDinheiro As Double = 0, mContRegistros As Integer = 0
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim mDescricao As String = "", mCodProd As String = "", mSaldoAnterior As Double = 0
            Dim mQtdeVendida As Double = 0, mDiferenca As Double = 0

            While dr.Read

                mCodProd = dr(0).ToString
                mDescricao = dr(1).ToString
                Try
                    mDiferenca = dr(2)
                Catch ex As Exception
                    mDiferenca = 0
                End Try

                Try
                    mQtdeVendida = dr(3)
                Catch ex As Exception
                    mQtdeVendida = 0
                End Try

                mSaldoAnterior = mDiferenca + mQtdeVendida

                strLinha = _funcoes.Exibe_StrEsquerda(mDescricao, 45) & " "
                strLinha += _funcoes.Exibe_StrEsquerda(mCodProd, 6) & " "
                strLinha += _funcoes.Exibe_StrDireita(Format(mSaldoAnterior, "###,##0.00"), 10) & " "
                strLinha += _funcoes.Exibe_StrDireita(Format(mQtdeVendida, "###,##0.00"), 10) & " "
                strLinha += _funcoes.Exibe_StrDireita(Format(mDiferenca, "###,##0.00"), 10)

                sw.EscreveLn(strLinha)
            End While
            dr.Close() : cmd = Nothing : dr = Nothing

            sw.EscreveLn("")
            sw.EscreveLn("*Saldo Referente a Data do Relatorio " & Format(Date.Now, "dd/MM/yyyy"))


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar os Produtos Identificados: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Public Sub GravPedidosFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, _
                                                    ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = ""

            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader
            Dim mSomaTotalRecebidas As Double = 0, mSomaDinheiro As Double = 0, mContRegistros As Integer = 0
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            'nt.nt_orca, n4.n4_tgeral, nt.nt_entrada, n4.n4_desc, 0, 0, nt.nt_tipo2, cad.p_portad
            Dim mPedido As String = "", mValorEntrada As Double = 0, mTipo As String = ""
            Dim mValor As Double = 0, mDesconto As Double = 0, mTipoOperacao As Integer = 0, mOperacao As String = ""
            Dim mPagamento As String = "", mCliente As String = ""

            While dr.Read

                mPedido = dr(0).ToString

                Try
                    mDesconto = dr(3)
                Catch ex As Exception
                    mDesconto = 0
                End Try

                mValorEntrada = dr(2)
                mTipo = dr(6).ToString
                mCliente = dr(8).ToString
                mTipoOperacao = dr(7)
                Select Case mTipoOperacao
                    Case 0 'Venda 
                        mOperacao = "Venda"
                    Case 1 'A Entregar
                        mOperacao = "A Entregar"
                    Case 2 'Devolução
                        mOperacao = "Devolucao"
                    Case 3 'Bonificação
                        mOperacao = "Bonificacao"

                End Select

                Try
                    mValor = (dr(1) + mDesconto)
                Catch ex As Exception
                    mValor = 0
                End Try

                strLinha = mPedido & " " & _funcoes.Exibe_StrDireita(Format(mValor, "#,###,##0.00"), 13) & " " & _
                _funcoes.Exibe_StrDireita(Format(mValorEntrada, "#,###,##0.00"), 13) & " " & _
                _funcoes.Exibe_StrDireita(Format(mDesconto, "###,##0.00"), 11) & " " & _
                _funcoes.Exibe_StrEsquerda(dr(4), 3) & " " & _
                _funcoes.Exibe_StrDireita(dr(5), 8) & " " & _
                _funcoes.Exibe_StrEsquerda(mOperacao, 10) & " "
                If mTipo.Equals("AV") Then
                    strLinha += _funcoes.Exibe_StrEsquerda("Dinheiro", 11) & " "
                Else
                    strLinha += _funcoes.Exibe_StrEsquerda("Duplicatas", 11) & " "
                    strLinha += mCliente
                End If


                sw.EscreveLn(strLinha)
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar os Pedidos da Loja: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Public Sub GravClientesPedidosFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, _
                                                    ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = ""

            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader
            Dim mSomaTotalRecebidas As Double = 0, mSomaDinheiro As Double = 0, mContRegistros As Integer = 0
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim mValorVendas As Double = 0, mQtdeVendida As Double = 0, mCliente As String = ""

            While dr.Read

                mCliente = dr(1).ToString

                Try
                    mQtdeVendida = dr(2)
                Catch ex As Exception
                    mQtdeVendida = 0
                End Try

                Try
                    mValorVendas = dr(3)
                Catch ex As Exception
                    mValorVendas = 0
                End Try

                strLinha = _funcoes.Exibe_StrEsquerda(mCliente, 29) & " " & _
                _funcoes.Exibe_StrDireita(Format(mQtdeVendida, "###,##0.00"), 13) & " " & _
                _funcoes.Exibe_StrDireita(Format(mValorVendas, "#,###,##0.00"), 13) & " "


                sw.EscreveLn(strLinha)
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar os Clientes Pedidos da Loja: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Public Sub GravProdutosPedidosFluxoArquivoLaser(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, _
                                                    ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = ""

            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader
            Dim mSomaTotalRecebidas As Double = 0, mSomaDinheiro As Double = 0, mContRegistros As Integer = 0
            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim mValorVendas As Double = 0, mQtdeVendida As Double = 0, mProduto As String = ""
            Dim mValorComissao As Double = 0

            While dr.Read

                mProduto = dr(1).ToString

                Try
                    mQtdeVendida = dr(2)
                Catch ex As Exception
                    mQtdeVendida = 0
                End Try

                Try
                    mValorVendas = dr(3)
                Catch ex As Exception
                    mValorVendas = 0
                End Try

                Try
                    mValorComissao = dr(4)
                Catch ex As Exception
                    mValorComissao = 0
                End Try

                strLinha = _funcoes.Exibe_StrEsquerda(mProduto, 31) & " " & _
                "                      " & _
                _funcoes.Exibe_StrDireita(Format(mQtdeVendida, "###,##0.00"), 12) & " " & _
                _funcoes.Exibe_StrDireita(Format(mValorVendas, "#,###,##0.00"), 12) & " " & _
                _funcoes.Exibe_StrDireita(Format(mValorComissao, "#,##0.00"), 8)


                sw.EscreveLn(strLinha)
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar os Clientes Pedidos da Loja: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Public Sub GravTotaisPedidoRelatorioMatricial3(ByVal s As StreamWriter)

        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mPedido, mEmissao, mCliente, mVendedor, mTipo, strLinha, strValoresTipo As String
            Dim mCont1, mCont2, index, i As Integer
            Dim mTotal, mSomaTotal, mSomaVlTipo, mSomaEntradas, mEntrada As Double
            Dim mTipos() As String = {"Entr.", "AV", "NP", "CT", "CH", "BL"}
            Dim mContItens As Integer = 0, mContItensPg As Integer = 0, mContPg As Integer = 0
            Dim mArrayTipo1, mArrayTipo2 As Array
            Dim mSomaAvista As Double = 0
            Dim mSomaAbertura, mSomaFechamento As Double
            strValoresTipo = ""



            If Me.dtg_pedidos.RowCount > 0 Then
                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("--------------------------------------------------------------------------------------------")
                s.WriteLine(" Pedido   | Emissão    | Cliente                             | Vendedor | TOTAL      | Tipo ")
                '             xxxxxxxx | xx/xx/xxxx | xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx |  xxxxxx  | 999,999.99 | xxx
                s.WriteLine(" ------------------------------------------------------------------------------------------")
                mCont1 = 20

            End If

            mContItensPg = 6
            mContPg = 1
            mSomaTotal = 0
            mSomaAvista = 0
            For Each row As DataGridViewRow In Me.dtg_pedidos.Rows

                If row.IsNewRow = False Then



                    If mContItensPg = 30 Then

                        's.WriteLine("+------------------------------------------------------------------------------------------+")
                        's.WriteLine(" *** CONTINUACAO DO RELATORIO ***  ")
                        's.WriteLine("+------------------------------------------------------------------------------------------+")
                        ''Quebra 10 Linhas para passar para a próxima folha...
                        's.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)



                        mContPg += 1
                        s.WriteLine("+------------------------------------------------------------------------------------------+")
                        s.WriteLine("                    C O N T I N U A C A O . . .               FOLHA: " & String.Format("{0:D3}", mContPg))
                        s.WriteLine("--------------------------------------------------------------------------------------------")
                        s.WriteLine(" Pedido   | Emissão    | Cliente                             | Vendedor | TOTAL      | Tipo ")
                        '             xxxxxxxx | xx/xx/xxxx | xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx |  xxxxxx  | 999,999.99 | xxx
                        s.WriteLine(" ------------------------------------------------------------------------------------------")
                        mContItensPg = 6

                    End If


                    'Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"", n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit ") '9
                    mPedido = row.Cells(2).Value.ToString
                    mEmissao = row.Cells(3).Value.ToString
                    mCliente = row.Cells(5).Value.ToString
                    mVendedor = row.Cells(10).Value.ToString
                    mTotal = row.Cells(8).Value.ToString
                    mTipo = row.Cells(9).Value.ToString
                    Try
                        mEntrada = 0
                        mEntrada = CDbl(row.Cells(13).Value)
                        mSomaEntradas += mEntrada
                    Catch ex As Exception
                        mEntrada = 0
                    End Try
                    mSomaTotal += mTotal

                    strValoresTipo += mTipo & "|" & mTotal & "?"
                    If mTipo.Equals("AV") Then mSomaAvista += mTotal
                    If mEntrada > 0 Then strValoresTipo += "Entr.|" & mEntrada & "?"

                    strLinha = " " & mPedido & " | " & mEmissao & " | " & _
                    _funcoes.Exibe_StrEsquerda(mCliente, 35) & " |  " & _
                    mVendedor & "  | " & _funcoes.Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10) & " | " & _
                    mTipo


                    s.WriteLine(_funcoes.Exibe_Str(strLinha, 99))
                    mContItens += 1 : mContItensPg += 1
                    mCont1 -= 1 : mCont2 -= 1

                End If
            Next


            If mSomaTotal > 0 Then
                s.WriteLine("")
                s.WriteLine(" TOTAL DE VENDAS    " & _funcoes.Exibe_StrDireita(Format(Round(mSomaTotal, 2), "#,###,##0.00"), 12))
                s.WriteLine("")

                For index = 0 To mTipos.Length - 1

                    mSomaVlTipo = 0
                    mArrayTipo1 = Split(strValoresTipo, "?")
                    For i = 0 To mArrayTipo1.Length - 2

                        mArrayTipo2 = Split(mArrayTipo1(i).ToString, "|")
                        If mArrayTipo2(0).ToString.Equals(mTipos(index).ToString) Then

                            mSomaVlTipo += CDbl(mArrayTipo2(1).ToString)
                        End If
                    Next

                    If mSomaVlTipo > 0 Then
                        If mTipos(index).ToString.Equals("Entr.") Then
                            s.WriteLine(_funcoes.Exibe_StrEsquerda(" TOTAL " & mTipos(index).ToString & ":", 17) & _funcoes.Exibe_StrDireita(Format(Round(mSomaVlTipo, 2), "#,###,##0.00"), 15))
                        Else
                            s.WriteLine(_funcoes.Exibe_StrEsquerda(" TOTAL POR " & mTipos(index).ToString & ":", 17) & _funcoes.Exibe_StrDireita(Format(Round(mSomaVlTipo, 2), "#,###,##0.00"), 15))
                        End If

                    End If
                Next

                's.WriteLine(" ------------------------------------------------------------------------------------------")
                s.WriteLine(vbNewLine)
                's.WriteLine(" .     .     .     .     .     .     .     .     .     .     .     .     .     .     .     .     .")
            End If


            Dim con As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim cmd As NpgsqlCommand
            Dim sql As New StringBuilder
            Dim dr As NpgsqlDataReader
            Dim mSomaPagamentos, mSomaRecebimentos As Double
            mSomaPagamentos = 0 : mSomaRecebimentos = 0

            Try
                con.Open()

                sql.Append("SELECT cx_data, cx_descricao, cx_valor, cx_grupo, cx_tipo FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario ")
                If cbo_opcoes.SelectedIndex = 1 Then
                    sql.Append("WHERE cx_data BETWEEN '" & msk_pesquisa.Text & "' AND '" & msk_periodoFinal.Text & "'")
                End If
                sql.Append("ORDER BY cx_data, cx_grupo ASC")

                cmd = New NpgsqlCommand(sql.ToString, con)
                dr = cmd.ExecuteReader

                s.WriteLine("")
                If dr.HasRows Then s.WriteLine(" RESUMO EXTRA CAIXA")
                While dr.Read


                    strLinha = Format(Convert.ChangeType(dr(0), GetType(Date)), "dd/MM/yyyy") & "  "
                    strLinha += _funcoes.Exibe_StrEsquerda(dr(1).ToString, 40)
                    Select Case dr(4).ToString
                        Case "R" 'RECEBIMENTO
                            strLinha += _funcoes.Exibe_StrDireita("(" & Format(dr(2), "###,##0.00") & ")", 33)
                            mSomaRecebimentos += dr(2)
                        Case "P" 'PAGAMENTO
                            strLinha += _funcoes.Exibe_StrDireita(Format(dr(2), "###,##0.00"), 32)
                            mSomaPagamentos += dr(2)
                        Case "A" 'ABERTURA
                            strLinha += _funcoes.Exibe_StrDireita(Format(dr(2), "###,##0.00"), 32)
                            mSomaAbertura += dr(2)
                        Case "S" 'SALDO FECHAMENTO
                            strLinha += _funcoes.Exibe_StrDireita(Format(dr(2), "###,##0.00"), 32)
                            mSomaFechamento += dr(2)

                    End Select

                    s.WriteLine(strLinha)
                End While




                s.WriteLine("")
                If mSomaPagamentos > 0 Then
                    s.WriteLine(_funcoes.Exibe_StrEsquerda(" TOTAL DE PAGAMENTOS  ", 26) & _funcoes.Exibe_StrDireita(Format(mSomaPagamentos, "###,##0.00"), 17))
                End If

                If mSomaRecebimentos > 0 Then
                    s.WriteLine(_funcoes.Exibe_StrEsquerda(" TOTAL DE RECEBIMENTOS  ", 26) & _funcoes.Exibe_StrDireita(Format(mSomaRecebimentos, "###,##0.00"), 17))
                End If

                s.WriteLine(_funcoes.Exibe_StrEsquerda(" SALDO ATUAL DO CAIXA   -----------------> ", 43) & _funcoes.Exibe_StrEsquerda(Format(Round((mSomaAvista + mSomaRecebimentos + mSomaEntradas + mSomaAbertura) - (mSomaPagamentos + mSomaFechamento), 2), "###,##0.00"), 12))
                s.WriteLine(" ==========================================================================================")







                '                                   *******   CONTAS RECEBIDAS   *******
                s.WriteLine("----------------------------------------------------------------------------------------------------------")
                s.WriteLine("                       *******   CONTAS RECEBIDAS   *******")
                s.WriteLine("NOME DO CLIENTE                Principal   Juros   Descont                                             ")
                s.WriteLine("----------------------------------------------------------------------------------------------------------")
                s.Write("")


            Catch ex As Exception
            End Try

            con.Close()
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) Totais do Pedido", MsgBoxStyle.Exclamation)
            Return

        End Try



    End Sub

    Private Sub LerOArquivoSalvo(ByVal arqSaida As String)
        'Ler o Arquivo salvo...
        Dim FilePath As String = arqSaida
        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrint = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream.Dispose() : MyfileStream = Nothing
            'File.Delete(arqSaida)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub VisuConteArqSalvo()

        Try
            'PrintDocument1 = New 

            ' Especifica as configurações da pagina atual
            pdRelatPedidos.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatPedidos.DefaultPageSettings.Margins.Top = 12
            pdRelatPedidos.DefaultPageSettings.Margins.Right = 12
            pdRelatPedidos.DefaultPageSettings.Margins.Left = 10
            pdRelatPedidos.DefaultPageSettings.Margins.Bottom = 8
            '========================================================

            'Orientação em Paisagem...
            pdRelatPedidos.DefaultPageSettings.Landscape = False
            'Select Case MdlRelatorioTelas._tl_movpedido
            '    Case 1 'Impressora Matricial
            '        pdRelatPedidos.DefaultPageSettings.Landscape = False
            '    Case 2 'Impressora Laiser
            '        pdRelatPedidos.DefaultPageSettings.Landscape = False
            '    Case Else
            '        pdRelatPedidos.DefaultPageSettings.Landscape = True
            'End Select
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando RELATÓRIO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatPedidos
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False
            _StringToPrint = "" : _StringToPrintItens = ""

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub VisuConteArqSalvo2()

        Try

            ' Especifica as configurações da pagina atual
            pdRelatorios.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatorios.DefaultPageSettings.Margins.Top = 12
            pdRelatorios.DefaultPageSettings.Margins.Right = 12
            pdRelatorios.DefaultPageSettings.Margins.Left = 10
            pdRelatorios.DefaultPageSettings.Margins.Bottom = 8

            'Orientação em Paisagem...
            pdRelatorios.DefaultPageSettings.Landscape = True
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando PEDIDO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatorios
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False
            _StringToPrint = "" : _StringToPrintItens = ""

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub VisuContRelatorioArquivo()

        Try

            ' Especifica as configurações da pagina atual
            pdRelatPedidos.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatPedidos.DefaultPageSettings.Margins.Top = 50
            pdRelatPedidos.DefaultPageSettings.Margins.Right = 40
            pdRelatPedidos.DefaultPageSettings.Margins.Left = 40
            pdRelatPedidos.DefaultPageSettings.Margins.Bottom = 25

            'Orientação em Retrato...
            pdRelatPedidos.DefaultPageSettings.Landscape = False
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando RELATÓRIO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatPedidos
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False
            _StringToPrint = "" : _StringToPrintItens = ""

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub


#Region "...IMPRESSÃO..."

    Private Sub pdRelatPedidos2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdRelatorios.PrintPage

        Dim NumChars As Integer
        Dim NumLines As Integer
        Dim NumChars2 As Integer = 100000
        Dim NumLines2 As Integer = 100
        Dim StringforPage As String
        Dim Strformat As New StringFormat

        Dim recdraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, _
                                      e.MarginBounds.Width, e.MarginBounds.Height)
        Dim SizeMeassure As New SizeF(e.MarginBounds.Width, _
                                      e.MarginBounds.Height - _PrintFont1.GetHeight(e.Graphics))

        Dim SizeMeassure2 As New SizeF(e.MarginBounds.Width, _
                                      e.MarginBounds.Height - _PrintFont2.GetHeight(e.Graphics))

        Strformat.Trimming = StringTrimming.Word

        If _cabecalho Then

            e.Graphics.MeasureString(_StringToPrint, _PrintFont1, SizeMeassure, Strformat, NumChars, NumLines)
            StringforPage = _StringToPrint.Substring(_valorZERO, NumChars)

            ' Imprime a string na pagina atual
            e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, (recdraw.X + 80), (recdraw.Y + 100), Strformat)

            '_stringToPrintAux = _StringToPrint
        End If
        _cabecalho = False


        e.Graphics.MeasureString(_StringToPrintItens, _PrintFont2, SizeMeassure2, Strformat, NumChars2, NumLines2)
        StringforPage = _StringToPrintItens.Substring(_valorZERO, NumChars2)

        ' Imprime a string na pagina atual
        e.Graphics.DrawString(StringforPage, _PrintFont2, Brushes.Black, (recdraw.X + 80), (recdraw.Y + 213), Strformat)
        'e.Graphics.DrawString(StringforPage, _PrintFont2, Brushes.Black, 80, 227, Strformat) 'e.MarginBounds.Left

        ' Se Hover mais texto, indica que há mais paginas
        If NumChars2 < _StringToPrintItens.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrintItens = _StringToPrintItens.Substring(NumChars2)
            e.HasMorePages = True

        Else
            e.HasMorePages = False '_stringToPrintAux += _StringToPrintItens

        End If



    End Sub

    Private Sub pdRelatPedidos_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdRelatPedidos.PrintPage

        Dim NumChars As Integer
        Dim NumLines As Integer
        Dim StringforPage As String
        Dim Strformat As New StringFormat

        Dim recdraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, _
                                      e.MarginBounds.Width, e.MarginBounds.Height)
        Dim SizeMeassure As New SizeF(e.MarginBounds.Width, _
                                      e.MarginBounds.Height - _PrintFont1.GetHeight(e.Graphics))

        Strformat.Trimming = StringTrimming.Word

        e.Graphics.MeasureString(_StringToPrint, _PrintFont1, SizeMeassure, Strformat, NumChars, NumLines)
        StringforPage = _StringToPrint.Substring(_valorZERO, NumChars)

        ' Imprime a string na pagina atual
        Select Case Me.cbo_tiporelatorio.SelectedIndex
            Case 0 'sintático
                e.Graphics.DrawLine(Pens.Black, 200, 400, 200, 400)
                e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 17, 100, New StringFormat())
            Case 1 'Analítico
                e.Graphics.DrawLine(Pens.Black, 200, 400, 200, 400)
                e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 35, 100, New StringFormat())
            Case 2 'Arquivo
                'e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 17, 100, New StringFormat())
                e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, recdraw, Strformat)
            Case 3 'Movimento Caixa
                'e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 17, 100, New StringFormat())
                e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, recdraw, Strformat)
            Case 4 'Vendedor
                e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, recdraw, Strformat)

            Case 5 'Diario
                e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 30, 100, Strformat)

            Case 6 'Baixas Mensal
                e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, recdraw, Strformat)
        End Select


        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False : _StringToPrint = _stringToPrintAux

        End If



    End Sub

    Private Sub InicializaRelatorio(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintEventArgs)

        _StringToPrintItens = _stringToPrintAux
        If MostrarCaixaImpressoras Then

            Dim Impressora As New PrintDialog
            Impressora.AllowCurrentPage = True : Impressora.AllowSomePages = True
            If Impressora.ShowDialog() = DialogResult.Cancel Then

                Relatorio.Cancel = True

            Else

                Try

                    pdRelatPedidos.PrinterSettings = Impressora.PrinterSettings
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
        End If
        MostrarCaixaImpressoras = True



    End Sub

    Private Sub InicializaRelatorio2(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintEventArgs)

        _cabecalho = True
        _StringToPrintItens = _stringToPrintAux
        If MostrarCaixaImpressoras Then

            Dim Impressora As New PrintDialog
            Impressora.AllowCurrentPage = True : Impressora.AllowSomePages = True
            If Impressora.ShowDialog() = DialogResult.Cancel Then

                Relatorio.Cancel = True

            Else

                Try

                    pdRelatorios.PrinterSettings = Impressora.PrinterSettings
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
        End If
        MostrarCaixaImpressoras = True



    End Sub

#End Region


    Private Sub dtg_pedidos_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dtg_pedidos.RowsAdded

        Select Case dtg_pedidos.Rows(e.RowIndex).Cells(11).Value

            Case 6
                'dtg_pedidos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Bisque
                dtg_pedidos.Rows(e.RowIndex).DefaultCellStyle.Font = _
                New Font(Me.dtg_pedidos.DefaultCellStyle.Font, FontStyle.Strikeout)

            Case Else
                dtg_pedidos.Rows(e.RowIndex).DefaultCellStyle.Font = Me.dtg_pedidos.DefaultCellStyle.Font
                dtg_pedidos.Rows(e.RowIndex).Cells(8).Style.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)

        End Select

    End Sub

    Private Sub cbo_opcoes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_opcoes.SelectedIndexChanged

        Select Case cbo_opcoes.SelectedIndex

            Case 0 ' Numero do Pedido

                msk_pesquisa.SetBounds(243, 17, 104, 22)
                msk_pesquisa.Text = "" : msk_pesquisa.Mask = ""
                msk_periodoFinal.Visible = False : lbl_periodo.Visible = False
                msk_periodoFinal.Text = "" : msk_periodoFinal.Mask = ""

            Case 1 'Data
                msk_pesquisa.SetBounds(243, 17, 77, 21)
                msk_pesquisa.Text = "" : msk_pesquisa.Mask = "00/00/0000"
                msk_periodoFinal.Visible = True : lbl_periodo.Visible = True
                msk_periodoFinal.Text = ""
                msk_periodoFinal.Mask = "00/00/0000"


            Case 2 'Cliente
                msk_pesquisa.SetBounds(243, 17, 304, 21)
                msk_pesquisa.Text = "" : msk_pesquisa.Mask = ""
                msk_periodoFinal.Visible = False : lbl_periodo.Visible = False
                msk_periodoFinal.Text = "" : msk_periodoFinal.Mask = ""

        End Select

    End Sub

    Private Sub btn_busca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_busca.Click

        preecheDtgPedidosPesquisa(Me.msk_pesquisa.Text, Me.msk_periodoFinal.Text)
        'lbl_opcao.Visible = True : cbo_opcoes.Visible = True : msk_pesquisa.Visible = True
    End Sub

    Private Function verificaCamposPesquisa() As Boolean

        If cbo_opcoes.SelectedIndex >= _valorZERO Then


            Select Case cbo_opcoes.SelectedIndex

                Case 0 ' Numero do Pedido

                    If IsNumeric(Me.msk_pesquisa.Text) = False Then

                        If Trim(Me.msk_pesquisa.Text).Equals("") = False Then

                            MsgBox("Numero pedido não é numérico", MsgBoxStyle.Exclamation)
                            Me.msk_pesquisa.Focus() : Me.msk_pesquisa.SelectAll() : Return False
                        End If
                    End If

                Case 1 'Data
                    If IsDate(Me.msk_pesquisa.Text) = False Then

                        MsgBox("Data INICIAL não é DATA", MsgBoxStyle.Exclamation)
                        Me.msk_pesquisa.Focus() : Me.msk_pesquisa.SelectAll() : Return False
                    End If

                    If IsDate(Me.msk_periodoFinal.Text) = False Then

                        MsgBox("Data FINAL não é DATA", MsgBoxStyle.Exclamation)
                        Me.msk_periodoFinal.Focus() : Me.msk_periodoFinal.SelectAll() : Return False
                    End If

                Case 2 'Cliente
                    'If Trim(Me.msk_pesquisa.Text).Equals("") Then

                    '    MsgBox("Informe o nome do cliente", MsgBoxStyle.Exclamation)
                    '    Me.msk_pesquisa.Focus() : Me.msk_pesquisa.SelectAll() : Return False
                    'End If

            End Select
        End If

        Return True
    End Function

    Private Sub msk_pesquisa_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles msk_pesquisa.GotFocus
        msk_pesquisa.SelectAll()
    End Sub

    Private Sub msk_periodoFinal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles msk_periodoFinal.GotFocus
        msk_periodoFinal.SelectAll()
    End Sub

    Private Sub msk_pesquisa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_pesquisa.KeyDown, msk_periodoFinal.KeyDown

        If e.KeyCode = Keys.Enter Then

            If verificaCamposPesquisa() Then


                Select Case cbo_opcoes.SelectedIndex

                    Case 0 ' Numero do Pedido

                        preecheDtgPedidosPesquisa(Me.msk_pesquisa.Text, Me.msk_periodoFinal.Text)
                    Case 1 'Data
                        preecheDtgPedidosPesquisa(Me.msk_pesquisa.Text, Me.msk_periodoFinal.Text)

                    Case 2 'Cliente
                        preecheDtgPedidosPesquisa(Me.msk_pesquisa.Text, Me.msk_periodoFinal.Text)

                End Select

            End If
        End If

    End Sub

    Private Sub msk_pesquisa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles msk_pesquisa.KeyPress

        Select Case cbo_opcoes.SelectedIndex

            Case 2 'Nome do cliente...
                e.KeyChar = CChar(e.KeyChar.ToString.ToUpper)
                'permite só numeros com virgulas
                If _funcoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

            Case Else
                'permite só numeros com virgulas
                If _funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

        End Select


    End Sub


End Class