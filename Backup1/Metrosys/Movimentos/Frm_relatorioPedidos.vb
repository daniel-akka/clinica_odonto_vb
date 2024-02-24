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

Public Class Frm_relatorioPedidos

    'Protected Const conexao As String = _
    ' "Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDGENOV"
    'Dim mMxml As New GenoNFeXml
    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes, _clBD As New Cl_bdMetrosys
    Public Shared _frmRefGeraPedidos As New Frm_relatorioPedidos
    Public _numPedido As String = "", _numPedidoTemp As String = ""
    Public _mapaPedido As Integer = 0
    Dim _mConsulta As New StringBuilder

    'Variáveis para o Carnê...
    Private linhaAtual As Integer = -1
    Private mcell, MCod_Cli As String
    Private mTotal As Double
    Private mPedido, MCliente As String


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

    'Objetos para Pedido temporário...
    Dim _arqNumPedido As String = "\wged\numpedido.TXT"

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click
        Me.Close()
    End Sub

    Private Sub Frm_relatorioPedidos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F2
                ' Venda no Pedido 
                Dim Formped As New Frm_PedidoProntEntrega
                Formped.Show()
            Case Keys.F3
                ' Altera Pedido 
            Case Keys.F4
                ' Exclui Pedido 
            Case Keys.F5
                executaF5()
        End Select


    End Sub

    Private Sub Frm_relatorioPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        executaF5()

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos.BeginPrint, AddressOf InicializaRelatorio

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos2.BeginPrint, AddressOf InicializaRelatorio2

    End Sub

    Private Sub btn_imprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprime.Click
        'Aqui....
        executaF6()

    End Sub

    Private Sub executaF5()

        preecheDtgPedidos2()

    End Sub

    Private Sub preecheDtgPedidos()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Sqlcomm As StringBuilder = New StringBuilder

        If MdlUsuarioLogando._usuarioPrivilegio Then 'verifica se usuário tem privilégio...

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca order AND n1.nt_dtemis = CURRENT_DATE by n1.nt_dtemis ")
        Else

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_vend = '" & MdlUsuarioLogando._codvendedor & "' AND n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca AND n1.nt_dtemis = CURRENT_DATE order by n1.nt_dtemis ")
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

            conn.ClearPool() : conn.Close()
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

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca AND n1.nt_dtemis = CURRENT_DATE order by n1.nt_dtemis ")
        Else

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_vend = '" & MdlUsuarioLogando._codvendedor & "' AND n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca AND n1.nt_dtemis = CURRENT_DATE order by n1.nt_dtemis ")
        End If
        'Sqlcomm.Append("desc limit 34")

        cmd = New NpgsqlCommand(Sqlcomm.ToString, conn)
        dr = cmd.ExecuteReader

        Me.dtg_pedidos.Rows.Clear() : Me.dtg_pedidos.Refresh()
        While dr.Read

            dtg_pedidos.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, Format(CDate(dr(3)), "dd/MM/yyyy"), _
                                 dr(4).ToString, dr(5).ToString, dr(6).ToString, dr(7).ToString, _
                                 Format(CDbl(dr(8)), "###,##0.00"), dr(9).ToString, dr(10).ToString, dr(11), dr(12))
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

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca ")
        Else

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_vend = '" & MdlUsuarioLogando._codvendedor & "' AND n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca ")
        End If
        'Sqlcomm.Append("desc limit 34")

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
        Sqlcomm.Append("order by n1.nt_dtemis ")

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
                cmd.Parameters.Add("@pesquisa", CDate(pesquisa))
                cmd.Parameters.Add("@pesquisa2", CDate(pesquisa2))

        End Select
        dr = cmd.ExecuteReader

        Me.dtg_pedidos.Rows.Clear() : Me.dtg_pedidos.Refresh()
        While dr.Read

            dtg_pedidos.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, Format(CDate(dr(3)), "dd/MM/yyyy"), _
                                 dr(4).ToString, dr(5).ToString, dr(6).ToString, dr(7).ToString, _
                                 Format(CDbl(dr(8)), "###,##0.00"), dr(9).ToString, dr(10).ToString, dr(11), dr(12))
        End While
        dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length) : cmd.CommandText = "" : conn.ClearAllPools()
        conn.Close() : dr = Nothing : Sqlcomm = Nothing : cmd = Nothing : conn = Nothing
        Me.dtg_pedidos.Refresh()

    End Sub

    Private Sub executaF6()

        If (Me.dtg_pedidos.Rows.Count > _valorZERO) AndAlso (Me.dtg_pedidos.SelectedCells.Count > 0) Then

            executaEspelhoPedido("", "\wged\RelatorioPedi.txt")

        End If

    End Sub

    Private Sub executaEspelhoPedidoExtracted1(ByVal s As StreamWriter, ByVal loja As String, ByVal numeroPedido As String, ByVal dtEmissao As String, ByVal codClient As String, ByVal nomeClient As String, ByVal condicao As String, ByVal codVendedor As String, ByVal idOrca1 As Int32, ByRef shouldReturn As Boolean)

        shouldReturn = False

        s.WriteLine("")

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Loja
        _mConsulta.Append("SELECT g_geno, g_ender, g_fone, g_uf, g_cid FROM geno001 WHERE g_codig = '" & loja & "'")
        Dim lShouldReturn1 As Boolean
        _clFuncoes.GravCabLojPedidoRelatorioMatricial(_mConsulta.ToString, s, loja, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return


        '_mConsulta.Remove(0, _mConsulta.ToString.Length)
        ''Cliente
        ''Traz dados do CLIENTE do Pedido...
        '_mConsulta.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
        '_mConsulta.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codClient & "'")
        'Dim lShouldReturn2 As Boolean
        '_clFuncoes.GravCabCliPedidoMatricial(_mConsulta.ToString, s, codClient, numeroPedido, dtEmissao, codVendedor, condicao, loja, lShouldReturn2)
        'If lShouldReturn2 Then shouldReturn = True : Return


        GravTotaisPedidoRelatorioMatricial(s)
        '_mConsulta.Remove(0, _mConsulta.ToString.Length)
        ''itens
        '_mConsulta.Append("SELECT o2.no_codpr, o2.no_qtde, o2.no_und, e.e_produt, o2.no_prunit, o2.no_prtot, o2.no_filial, el.e_locacao, o2.no_vldesc, o2.no_pesobruto, o2.no_vlsub, o2.no_pruvenda ") '11
        '_mConsulta.Append("FROM estloja01 el, " & MdlEmpresaUsu._esqEstab & ".orca2cc o2 LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 ")
        '_mConsulta.Append("e ON e.e_codig = o2.no_codpr WHERE no_idxo1 = " & idOrca1 & " AND el.e_loja = o2.no_filial AND el.e_codig = o2.no_codpr")
        'Dim lShouldReturn3 As Boolean
        '_clFuncoes.GravItensPedidoMatricial(_mConsulta.ToString, s, numeroPedido, idOrca1, codClient, nomeClient, lShouldReturn3)
        'If lShouldReturn3 Then shouldReturn = True : Return

    End Sub

    'Grava Totais
    Public Sub GravTotaisPedidoRelatorioMatricial(ByVal s As StreamWriter)

        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mPedido, mEmissao, mCliente, mVendedor, mTipo, strLinha, strValoresTipo As String
            Dim mCont1, mCont2, index, i As Integer
            Dim mTotal, mSomaTotal, mSomaVlTipo As Double
            Dim mTipos() As String = {"AV", "NP", "CT", "CH", "BL"}
            Dim mContItens As Integer = 0, mContItensPg As Integer = 0, mContPg As Integer = 0
            Dim mArrayTipo1, mArrayTipo2 As Array
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

            mContPg = 1

            mSomaTotal = 0
            For Each row As DataGridViewRow In Me.dtg_pedidos.Rows

                If row.IsNewRow = False Then



                    If mContItensPg = 30 Then

                        's.WriteLine("+------------------------------------------------------------------------------------------+")
                        's.WriteLine(" *** CONTINUACAO DO RELATORIO ***  ")
                        's.WriteLine("+------------------------------------------------------------------------------------------+")


                        mContPg += 1
                        s.WriteLine("+------------------------------------------------------------------------------------------+")
                        s.WriteLine("                    C O N T I N U A C A O . . .               FOLHA: " & String.Format("{0:D3}", mContPg))
                        s.WriteLine("--------------------------------------------------------------------------------------------")
                        s.WriteLine(" Pedido   | Emissão    | Cliente                             | Vendedor | TOTAL      | Tipo ")
                        '             xxxxxxxx | xx/xx/xxxx | xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx |  xxxxxx  | 999,999.99 | xxx
                        s.WriteLine(" ------------------------------------------------------------------------------------------")
                        mContItensPg = 6

                    End If


                    mPedido = row.Cells(2).Value.ToString
                    mEmissao = row.Cells(3).Value.ToString
                    mCliente = row.Cells(5).Value.ToString
                    mVendedor = row.Cells(10).Value.ToString
                    mTotal = row.Cells(8).Value.ToString
                    mTipo = row.Cells(9).Value.ToString
                    mSomaTotal += mTotal
                    strValoresTipo += mTipo & "|" & mTotal & "?"

                    strLinha = " " & mPedido & " | " & mEmissao & " | " & _
                    _clFuncoes.Exibe_StrEsquerda(mCliente, 35) & " |  " & _
                    mVendedor & "  | " & _clFuncoes.Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10) & " | " & _
                    mTipo


                    s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 99))
                    mContItens += 1 : mContItensPg += 1
                    mCont1 -= 1 : mCont2 -= 1

                End If
            Next


            If mSomaTotal > 0 Then
                s.WriteLine("")
                s.WriteLine(" TOTAL DE RECEBIMENTOS    " & _clFuncoes.Exibe_StrDireita(Format(Round(mSomaTotal, 2), "#,###,##0.00"), 12))
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
                        s.WriteLine(" TOTAL POR " & mTipos(index).ToString & ":" & _clFuncoes.Exibe_StrDireita(Format(Round(mSomaVlTipo, 2), "#,###,##0.00"), 15))
                    End If
                Next

                's.WriteLine(" ------------------------------------------------------------------------------------------")
                s.WriteLine(vbNewLine)
                's.WriteLine(" .     .     .     .     .     .     .     .     .     .     .     .     .     .     .     .     .")
            End If


        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) Totais do Pedido", MsgBoxStyle.Exclamation)
            Return

        End Try



    End Sub

    Private Sub GravaPedidoMatricialAlterado1(ByVal arqSaida As String, ByVal loja As String, ByVal numeroPedido As String, ByVal dtEmissao As String, ByVal codClient As String, ByVal nomeClient As String, ByVal condicao As String, ByVal codVendedor As String, ByVal idOrca1 As Int32, ByRef shouldReturn As Boolean)

        shouldReturn = False
        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp1 As String = "\wged\TEMPconsultaPed1.TMP"
        Dim mArqTemp2 As String = "\wged\TEMPconsultaPed2.TMP"
        Dim mArqTemp3 As String = "\wged\TEMPconsultaPed3.TMP"
        Dim fs1 As FileStream
        Dim fs2 As FileStream
        Dim fs3 As FileStream
        Try
            fs1 = New FileStream(mArqTemp1, FileMode.Truncate, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp1)
                fs1 = New FileStream(mArqTemp1, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs1 = New FileStream("\new1.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try

        Try
            fs2 = New FileStream(mArqTemp2, FileMode.Truncate, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp2)
                fs2 = New FileStream(mArqTemp2, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs2 = New FileStream("\new2.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try

        Try
            fs3 = New FileStream(mArqTemp3, FileMode.Truncate, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp3)
                fs3 = New FileStream(mArqTemp3, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs3 = New FileStream("\new3.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        Dim s1 As New StreamWriter(fs1)
        Dim s2 As New StreamWriter(fs2)
        Dim s3 As New StreamWriter(fs3)
        _PrintFont1 = New Font("Lucida Console", 10)


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Loja
        _mConsulta.Append("SELECT g_geno, g_ender, g_fone, g_uf, g_cid ")
        _mConsulta.Append("FROM geno001 WHERE g_codig = '" & loja & "'")
        Dim lShouldReturn1 As Boolean
        _clFuncoes.GravCabLojPediMatriAlterado1(_mConsulta.ToString, s1, loja, lShouldReturn1)
        If lShouldReturn1 Then Return

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Cliente
        'Traz dados do CLIENTE do Pedido...
        _mConsulta.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
        _mConsulta.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codClient & "'")
        Dim lShouldReturn2 As Boolean
        _clFuncoes.GravCabCliPediMatriAlterado1(_mConsulta.ToString, s1, codClient, numeroPedido, dtEmissao, codVendedor, condicao, loja, lShouldReturn2)
        If lShouldReturn2 Then Return

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'itens
        _mConsulta.Append("SELECT o2.no_codpr, o2.no_qtde, o2.no_und, e.e_produt, o2.no_prunit, o2.no_prtot, o2.no_filial, el.e_locacao, o2.no_vldesc, o2.no_pesobruto, o2.no_vlsub, o2.no_pruvenda ") '11
        _mConsulta.Append("FROM estloja01 el, " & MdlEmpresaUsu._esqEstab & ".orca2cc o2 LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 ")
        _mConsulta.Append("e ON e.e_codig = o2.no_codpr WHERE no_idxo1 = " & idOrca1 & " AND el.e_loja = o2.no_filial AND el.e_codig = o2.no_codpr")
        Dim lShouldReturn3 As Boolean
        _clFuncoes.GravItensPediMatriAlterado1(_mConsulta.ToString, s2, numeroPedido, idOrca1, codClient, nomeClient, lShouldReturn3)
        If lShouldReturn3 Then Return

        'Deleta o arquivo temporário...
        s1.Close()
        'Ler o Arquivo salvo...
        Dim FilePath As String = mArqTemp1
        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrint = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream.Dispose() : MyfileStream = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        s3.Write(_StringToPrint)

        'Deleta o arquivo temporário...
        s2.Close()

        'Ler o Arquivo salvo...
        FilePath = mArqTemp2
        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrintItens = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream.Dispose() : MyfileStream = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        s3.Write(_StringToPrintItens)

        'Deleta o arquivo temporário...
        s3.Close()
        Try
            File.Copy(mArqTemp3, arqSaida, True)
        Catch ex As Exception
        End Try
        s1.Dispose()
        File.Delete(mArqTemp1)
        s2.Dispose()
        File.Delete(mArqTemp2)
        s3.Dispose()
        File.Delete(mArqTemp3)

        'Ler o arquivo salvo
        'LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrintItens

        'Visualiza Arquivo salvo
        VisuConteArqSalvo2()


    End Sub

    Private Sub executaEspelhoPedido(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPRelatorioPedi.TMP"
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
        s.WriteLine(_clFuncoes.Centraliza_Str("FLUXO DE CAIXA   (" & Format(Date.Now, "dd/MM/yyyy") & ")", 101))
        Dim loja As String = Me.dtg_pedidos.CurrentRow.Cells(1).Value
        Dim numeroPedido As String = Me.dtg_pedidos.CurrentRow.Cells(2).Value
        Dim dtEmissao As String = Me.dtg_pedidos.CurrentRow.Cells(3).Value
        Dim codClient As String = Me.dtg_pedidos.CurrentRow.Cells(4).Value
        Dim nomeClient As String = Me.dtg_pedidos.CurrentRow.Cells(5).Value
        Dim condicao As String = Me.dtg_pedidos.CurrentRow.Cells(9).Value
        Dim codVendedor As String = Me.dtg_pedidos.CurrentRow.Cells(10).Value
        Dim idOrca1 As Int32 = Me.dtg_pedidos.CurrentRow.Cells(0).Value


        Select Case MdlRelatorioTelas._tl_movpedido

            Case 1 'Impressora Matricial
                Dim lShouldReturn As Boolean
                executaEspelhoPedidoExtracted1(s, loja, numeroPedido, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
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

            Case 3 'Impressora Matricial Relatório Alterado 1
                Try
                    'Deleta o arquivo temporário...
                    s.Close()
                Catch ex As Exception
                End Try
                Try
                    File.Copy(mArqTemp, arqSaida, True)
                Catch ex As Exception
                End Try
                Try
                    s.Dispose()
                    File.Delete(mArqTemp)
                Catch ex As Exception
                End Try


                Dim lShouldReturn1 As Boolean
                GravaPedidoMatricialAlterado1(arqSaida, loja, numeroPedido, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn1)
                If lShouldReturn1 Then Return


            Case Else
                Dim lShouldReturn As Boolean
                executaEspelhoPedidoExtracted1(s, loja, numeroPedido, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
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

        End Select


        _StringToPrint = ""
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
            Select Case MdlRelatorioTelas._tl_movpedido
                Case 1 'Impressora Matricial
                    pdRelatPedidos.DefaultPageSettings.Landscape = False
                Case 2 'Impressora Laiser
                    pdRelatPedidos.DefaultPageSettings.Landscape = False
                Case Else
                    pdRelatPedidos.DefaultPageSettings.Landscape = True
            End Select
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando PEDIDO"

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
            pdRelatPedidos2.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatPedidos2.DefaultPageSettings.Margins.Top = 12
            pdRelatPedidos2.DefaultPageSettings.Margins.Right = 12
            pdRelatPedidos2.DefaultPageSettings.Margins.Left = 10
            pdRelatPedidos2.DefaultPageSettings.Margins.Bottom = 8

            'Orientação em Paisagem...
            pdRelatPedidos2.DefaultPageSettings.Landscape = True
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando PEDIDO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatPedidos2
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False
            _StringToPrint = "" : _StringToPrintItens = ""

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub pdRelatPedidos2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdRelatPedidos2.PrintPage

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
        e.Graphics.DrawLine(Pens.Black, 200, 400, 200, 400)
        e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 15, 100, New StringFormat())


        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False : _stringToPrintAux = _StringToPrint

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

                    pdRelatPedidos2.PrinterSettings = Impressora.PrinterSettings
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
        End If
        MostrarCaixaImpressoras = True



    End Sub

    Private Sub dtg_pedidos_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dtg_pedidos.RowsAdded

        Select Case dtg_pedidos.Rows(e.RowIndex).Cells(11).Value

            Case 6
                'dtg_pedidos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Bisque
                dtg_pedidos.Rows(e.RowIndex).DefaultCellStyle.Font = _
                New Font(Me.dtg_pedidos.DefaultCellStyle.Font, FontStyle.Strikeout)

        End Select

    End Sub

    Private Sub cbo_opcoes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_opcoes.SelectedIndexChanged

        Select Case cbo_opcoes.SelectedIndex

            Case 0 ' Numero do Pedido

                msk_pesquisa.SetBounds(231, 39, 104, 21)
                msk_pesquisa.Text = "" : msk_pesquisa.Mask = ""
                msk_periodoFinal.Visible = False : lbl_periodo.Visible = False
                msk_periodoFinal.Text = "" : msk_periodoFinal.Mask = ""

            Case 1 'Data
                msk_pesquisa.SetBounds(231, 39, 77, 21)
                msk_pesquisa.Text = "" : msk_pesquisa.Mask = "00/00/0000"
                msk_periodoFinal.Visible = True : lbl_periodo.Visible = True
                msk_periodoFinal.SetBounds(370, 39, 77, 21)
                lbl_periodo.SetBounds(344, 42, 15, 13)
                msk_periodoFinal.Text = ""
                msk_periodoFinal.Mask = "00/00/0000"


            Case 2 'Cliente
                msk_pesquisa.SetBounds(231, 39, 304, 21)
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
                If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

            Case Else
                'permite só numeros com virgulas
                If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

        End Select


    End Sub


End Class