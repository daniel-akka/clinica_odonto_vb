Imports Npgsql
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Data
Imports System.Math
Imports System.Xml.Xsl
Imports System.Data.DataRow
Imports System.Drawing.Printing
Imports System.Data.DataColumnCollection

Public Class Frm_GeraOrcamento

    'Protected Const conexao As String = _
    ' "Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDGENOV"
    'Dim mMxml As New GenoNFeXml
    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes, _clBD As New Cl_bdMetrosys
    Public Shared _frmRefGeraOrcamento As New Frm_GeraOrcamento
    Public _numOrcamento As String = "", _numOrcamentoTemp As String = ""
    Public _mapaPedido As Integer = 0
    Private _selecionCurrentText As Integer = 0
    Dim _mConsulta As New StringBuilder

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

    Private Sub Frm_GeraOrcamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

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

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        Dim Form_orcamento As New Frm_Orcamento
        Form_orcamento.Show()
        Form_orcamento = Nothing
        executaF5()

    End Sub


    Private Sub Frm_GeraOrcamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _numOrcamentoTemp = ""

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

            Sqlcomm.Append("Select n1.nt_id, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".tb_orca1 n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".tb_orca4 n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca order by n1.nt_dtemis ")
        Else

            Sqlcomm.Append("Select n1.nt_id, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".tb_orca1 n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".tb_orca4 n4 where n1.nt_vend = '" & MdlUsuarioLogando._codvendedor & "' AND n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca order by n1.nt_dtemis ")
        End If
        'Sqlcomm.Append("desc limit 34")

        Dim daPed As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
        Dim dsPed As DataSet = New DataSet()

        Try
            'configurajanelaProdPesq()
            daPed.Fill(dsPed, "tb_orca1")
            conn.Open()

            Me.dtg_pedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.dtg_pedidos.DataSource = dsPed.Tables("tb_orca1").DefaultView
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

            Sqlcomm.Append("Select n1.nt_id, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"", n1.nt_vend AS ""Vendedor"" ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".tb_orca1 n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".tb_orca4 n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca order by n1.nt_dtemis ")
        Else

            Sqlcomm.Append("Select n1.nt_id, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"", n1.nt_vend AS ""Vendedor"" ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".tb_orca1 n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".tb_orca4 n4 where n1.nt_vend = '" & MdlUsuarioLogando._codvendedor & "' AND n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca order by n1.nt_dtemis ")
        End If
        'Sqlcomm.Append("desc limit 34")

        cmd = New NpgsqlCommand(Sqlcomm.ToString, conn)
        dr = cmd.ExecuteReader

        Me.dtg_pedidos.Rows.Clear() : Me.dtg_pedidos.Refresh()
        While dr.Read

            dtg_pedidos.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, Format(CDate(dr(3)), "dd/MM/yyyy"), _
                                 dr(4).ToString, dr(5).ToString, dr(6).ToString, dr(7).ToString, _
                                 Format(CDbl(dr(8)), "###,##0.00"), dr(9).ToString)
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

            Sqlcomm.Append("Select n1.nt_id, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"", n1.nt_vend AS ""Vendedor"" ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".tb_orca1 n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".tb_orca4 n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca ")
        Else

            Sqlcomm.Append("Select n1.nt_id, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"", n1.nt_vend AS ""Vendedor"" ") '12
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".tb_orca1 n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".tb_orca4 n4 where n1.nt_vend = '" & MdlUsuarioLogando._codvendedor & "' AND n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca ")
        End If
        'Sqlcomm.Append("desc limit 34")

        If pesquisa2.Equals("") Then ' combo selecionado 0 ou 1

            Select Case cbo_opcoes.SelectedIndex

                Case 0
                    Sqlcomm.Append("AND n1.nt_orca LIKE @pesquisa ") '12
                Case 2
                    Sqlcomm.Append("AND UPPER(cad.p_portad) LIKE @pesquisa ") '12
            End Select

        Else ' combo selecionado 2
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


            Case 1
                cmd.Parameters.Add("@pesquisa", CDate(pesquisa))
                cmd.Parameters.Add("@pesquisa2", CDate(pesquisa2))

            Case 2
                If Trim(pesquisa).Equals("") Then
                    cmd.Parameters.Add("@pesquisa", "%")
                Else
                    cmd.Parameters.Add("@pesquisa", pesquisa.ToUpper & "%")
                End If

        End Select
        dr = cmd.ExecuteReader

        Me.dtg_pedidos.Rows.Clear() : Me.dtg_pedidos.Refresh()
        While dr.Read

            dtg_pedidos.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, Format(CDate(dr(3)), "dd/MM/yyyy"), _
                                 dr(4).ToString, dr(5).ToString, dr(6).ToString, dr(7).ToString, _
                                 Format(CDbl(dr(8)), "###,##0.00"), dr(9).ToString)
        End While
        dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length) : cmd.CommandText = "" : conn.ClearAllPools()
        conn.Close() : dr = Nothing : Sqlcomm = Nothing : cmd = Nothing : conn = Nothing
        Me.dtg_pedidos.Refresh()

    End Sub

    Private Sub executaF6()

        If (Me.dtg_pedidos.Rows.Count > _valorZERO) AndAlso (Me.dtg_pedidos.SelectedCells.Count > 0) Then

            executaRelatorioOrcamento("", "\wged\consultaOrcamento.txt")
        End If

    End Sub

    Private Sub executaRelatorio1(ByVal s As StreamWriter, ByVal loja As String, ByVal numeroOrcamento As String, ByVal dtEmissao As String, ByVal codClient As String, ByVal nomeClient As String, ByVal condicao As String, ByVal codVendedor As String, ByVal idOrca1 As Int32, ByRef shouldReturn As Boolean)

        shouldReturn = False
        s.WriteLine("")

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Loja
        _mConsulta.Append("SELECT g_geno, g_ender, g_fone, g_uf, g_cid FROM geno001 WHERE g_codig = '" & loja & "'")
        Dim lShouldReturn1 As Boolean
        _clFuncoes.GravCabLojOrcamentoMatricial(_mConsulta.ToString, s, loja, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Cliente
        _mConsulta.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
        _mConsulta.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codClient & "'")
        Dim lShouldReturn2 As Boolean
        _clFuncoes.GravCabCliOrcamentoMatricial(_mConsulta.ToString, s, codClient, numeroOrcamento, dtEmissao, codVendedor, condicao, loja, lShouldReturn2)
        If lShouldReturn2 Then shouldReturn = True : Return

        'Orçamento
        s.WriteLine("-------------------------------------------------------------------------------------")
        s.WriteLine(_clFuncoes.Centraliza_Str("ORÇAMENTO Nº " & numeroOrcamento, 85) & vbNewLine)


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'itens
        _mConsulta.Append("SELECT o2.no_codpr, o2.no_qtde, o2.no_und, e.e_produt, o2.no_prunit, o2.no_prtot, o2.no_filial, el.e_locacao, o2.no_vldesc, o2.no_pesobruto, o2.no_vlsub ") '10
        _mConsulta.Append("FROM estloja01 el, " & MdlEmpresaUsu._esqEstab & ".tb_orca2 o2 LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 ")
        _mConsulta.Append("e ON e.e_codig = o2.no_codpr WHERE no_idorca1 = " & idOrca1 & " AND el.e_loja = o2.no_filial AND el.e_codig = o2.no_codpr")
        Dim lShouldReturn3 As Boolean
        _clFuncoes.GravItensOrcamentoMatricial(_mConsulta.ToString, s, numeroOrcamento, idOrca1, codClient, nomeClient, lShouldReturn3)
        If lShouldReturn3 Then shouldReturn = True : Return

    End Sub

    Private Sub executaRelatorio2(ByVal s As StreamWriter, ByVal loja As String, ByVal numeroOrcamento As String, ByVal dtEmissao As String, ByVal codClient As String, ByVal nomeClient As String, ByVal condicao As String, ByVal codVendedor As String, ByVal idOrca1 As Int32, ByRef shouldReturn As Boolean)

        shouldReturn = False
        s.WriteLine("")

        'Loja
        Dim lShouldReturn1 As Boolean
        'GravCabecalhoLoja(s, loja, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return

        'Cliente
        Dim lShouldReturn2 As Boolean
        'GravCabecalhoCliente(s, codClient, numeroOrcamento, dtEmissao, codVendedor, condicao, loja, lShouldReturn2)
        If lShouldReturn2 Then shouldReturn = True : Return

        'Orçamento
        s.WriteLine("-------------------------------------------------------------------------------------")
        s.WriteLine(_clFuncoes.Centraliza_Str("ORÇAMENTO Nº " & numeroOrcamento, 85) & vbNewLine)


        'itens
        Dim lShouldReturn3 As Boolean
        'GravItensArq(s, numeroOrcamento, idOrca1, codClient, nomeClient, lShouldReturn3)
        If lShouldReturn3 Then shouldReturn = True : Return

    End Sub

    Private Sub executaRelatorioOrcamento(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPconsultaOrca.TMP"
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
        _PrintFont1 = New Font("Lucida Console", 9)
        Dim strLinha As String = ""
        Dim loja As String = Me.dtg_pedidos.CurrentRow.Cells(1).Value
        Dim numeroOrcamento As String = Me.dtg_pedidos.CurrentRow.Cells(2).Value
        Dim dtEmissao As String = Me.dtg_pedidos.CurrentRow.Cells(3).Value
        Dim codClient As String = Me.dtg_pedidos.CurrentRow.Cells(4).Value
        Dim nomeClient As String = Me.dtg_pedidos.CurrentRow.Cells(5).Value
        Dim condicao As String = ""
        Dim codVendedor As String = Me.dtg_pedidos.CurrentRow.Cells(9).Value
        Dim idOrca1 As Int32 = Me.dtg_pedidos.CurrentRow.Cells(0).Value

        Select Case MdlRelatorioTelas._tl_movorcamento

            Case 1 'Impressora Matricial
                Dim lShouldReturn As Boolean
                executaRelatorio1(s, loja, numeroOrcamento, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
                If lShouldReturn Then Return

            Case 2 'Impressora Laiser
                Dim lShouldReturn As Boolean
                'executaRelatorio2(s, loja, numeroOrcamento, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
                If lShouldReturn Then Return

            Case Else
                Dim lShouldReturn As Boolean
                executaRelatorio1(s, loja, numeroOrcamento, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
                If lShouldReturn Then Return

        End Select


        'Deleta o arquivo temporário...
        s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        s.Dispose()
        Try
            File.Delete(mArqTemp)
        Catch ex As Exception
        End Try


        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo1()

        _StringToPrint = ""
    End Sub

    Private Sub executaEspelhoPedido2(ByVal unidadePC As String, ByVal arqSaida As String)

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
        Dim strLinha As String = ""
        Dim loja As String = Me.dtg_pedidos.CurrentRow.Cells(1).Value
        Dim numeroPedido As String = Me.dtg_pedidos.CurrentRow.Cells(2).Value
        Dim dtEmissao As String = Me.dtg_pedidos.CurrentRow.Cells(3).Value
        Dim codClient As String = Me.dtg_pedidos.CurrentRow.Cells(4).Value
        Dim nomeClient As String = Me.dtg_pedidos.CurrentRow.Cells(5).Value
        Dim condicao As String = Me.dtg_pedidos.CurrentRow.Cells(9).Value
        Dim codVendedor As String = Me.dtg_pedidos.CurrentRow.Cells(10).Value
        Dim idOrca1 As Int32 = Me.dtg_pedidos.CurrentRow.Cells(0).Value


        s1.WriteLine("")

        'Loja
        Dim lShouldReturn1 As Boolean
        GravCabecalhoLoja2(s1, loja, lShouldReturn1)
        If lShouldReturn1 Then Return

        'Cliente
        Dim lShouldReturn2 As Boolean
        GravCabecalhoCliente2(s1, codClient, numeroPedido, dtEmissao, codVendedor, condicao, loja, lShouldReturn2)
        If lShouldReturn2 Then Return

        'itens
        Dim lShouldReturn3 As Boolean
        GravItensArq2(s2, numeroPedido, idOrca1, codClient, nomeClient, lShouldReturn3)
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

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo2()

        _StringToPrint = ""
    End Sub

    Private Sub GravCabecalhoLoja2(ByVal s As StreamWriter, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlLoja As New StringBuilder
            Dim cmdLoja As NpgsqlCommand
            Dim drLoja As NpgsqlDataReader

            sqlLoja.Append("SELECT g_geno, g_ender, g_fone, g_uf, g_cid ")
            sqlLoja.Append("FROM geno001 WHERE g_codig = '" & loja & "'")

            cmdLoja = New NpgsqlCommand(sqlLoja.ToString, oConnBDGENOV)
            drLoja = cmdLoja.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja As String

            nomeLoja = "" : ufLoja = "" : enderLoja = "" : cidLoja = "" : foneLoja = ""
            While drLoja.Read

                nomeLoja = drLoja(_valorZERO).ToString : enderLoja = drLoja(1).ToString
                foneLoja = drLoja(2).ToString : ufLoja = drLoja(3).ToString : cidLoja = drLoja(4).ToString

            End While
            drLoja.Close() : cmdLoja = Nothing : sqlLoja = Nothing : drLoja = Nothing


            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = "    " & _clFuncoes.Exibe_StrEsquerda(nomeLoja, 16) & " - "
            strLinha += _clFuncoes.Exibe_StrEsquerda(enderLoja, 23) & " - "
            strLinha += _clFuncoes.Exibe_StrDireita("Fone:" & foneLoja, 15) & "  "
            strLinha += _clFuncoes.Exibe_StrDireita(cidLoja, 8) & "-"
            strLinha += _clFuncoes.Exibe_StrDireita(ufLoja, 2)

            s.WriteLine(_clFuncoes.Exibe_StrEsquerda(strLinha, 80))

            oConnBDGENOV.ClearPool() : If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Private Sub GravCabecalhoCliente2(ByVal s As StreamWriter, ByVal codCliente As String, _
                                     ByVal numPedido As String, ByVal dtEmiss As String, _
                                     ByVal codVendedor As String, ByVal condicao As String, _
                                      ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlClient As New StringBuilder
            Dim cmdClient As NpgsqlCommand
            Dim drClient As NpgsqlDataReader

            'Traz dados do CLIENTE do Pedido...
            sqlClient.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
            sqlClient.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codCliente & "'")

            cmdClient = New NpgsqlCommand(sqlClient.ToString, oConnBDGENOV)
            drClient = cmdClient.ExecuteReader

            Dim nomeClient, cnpjCliente, cpfCliente, enderecoCli, ufClient, cidClient, bairroClient As String
            Dim foneClient, faxClient, celularCliente, nomeFantasCli, inscrCliente As String

            nomeClient = "" : cnpjCliente = "" : cpfCliente = "" : enderecoCli = "" : ufClient = "" : cidClient = ""
            bairroClient = "" : foneClient = "" : faxClient = "" : celularCliente = "" : nomeFantasCli = ""
            inscrCliente = ""

            While drClient.Read

                nomeClient = drClient(_valorZERO).ToString : cnpjCliente = drClient(1).ToString
                cpfCliente = drClient(2).ToString : enderecoCli = drClient(3).ToString
                cidClient = drClient(4).ToString : ufClient = drClient(5).ToString
                bairroClient = drClient(6).ToString : foneClient = drClient(7).ToString
                faxClient = drClient(8).ToString : celularCliente = drClient(9).ToString
                nomeFantasCli = drClient(10).ToString : inscrCliente = drClient(11).ToString

            End While
            drClient.Close()

            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine("+------------------------------------------------------------------------------+")
            'NOME DO CLIENTE...
            strLinha = "| " & _clFuncoes.Exibe_StrEsquerda("Cliente: " & nomeClient, 60) & " |               |"
            s.WriteLine(_clFuncoes.Exibe_cabecalho(strLinha, 4, 80))

            'NOME FANTASIA...
            strLinha = "| " & _clFuncoes.Exibe_StrEsquerda("Nome Fantasia: " & nomeFantasCli, 60) & " | P E D I D O   |"
            s.WriteLine(_clFuncoes.Exibe_cabecalho(strLinha, 4, 80))

            'ENDEREÇO E BAIRRO...
            strLinha = "| " & _clFuncoes.Exibe_StrEsquerda("End.: " & enderecoCli, 32) & " "
            strLinha += _clFuncoes.Exibe_StrEsquerda("Bairro: " & bairroClient, 27) & " "
            strLinha += "|  " & numPedido & "     |"
            s.WriteLine(_clFuncoes.Exibe_cabecalho(strLinha, 4, 80))

            'CIDADE E ESTADO...
            strLinha = "| " & _clFuncoes.Exibe_StrEsquerda("Cidade: " & enderecoCli, 53) & " "
            strLinha += _clFuncoes.Exibe_StrEsquerda("UF: " & ufClient, 6) & " "
            strLinha += "|" & _clFuncoes.Exibe_StrEsquerda("Emis:" & Format(CDate(dtEmiss), "dd/MM/yyyy"), 15) & "|"
            s.WriteLine(_clFuncoes.Exibe_cabecalho(strLinha, 4, 80))

            'CNPJ/CPF e INSCRICÃO...
            If Not cnpjCliente.Equals("") Then

                strLinha = "| " & _clFuncoes.Exibe_StrEsquerda("CNPJ: " & String.Format("{0:00\.000\.000\/0000\-00}", Convert.ToInt64(cnpjCliente)), 30) & " "

            Else
                strLinha = "| " & _clFuncoes.Exibe_StrEsquerda("CPF: " & String.Format("{0:000\.000\.000\-00}", Convert.ToInt64(cpfCliente)), 30) & " "

            End If
            strLinha += _clFuncoes.Exibe_StrEsquerda("INSC.EST.: ", 29) & " "
            strLinha += "|--Condicoes----|"
            s.WriteLine(_clFuncoes.Exibe_cabecalho(strLinha, 4, 80))


            'FONE e VENDEDOR...
            If Not foneClient.Equals("") Then

                strLinha = "| " & _clFuncoes.Exibe_StrEsquerda("F/Fax: " & foneClient & "/" & faxClient, 30) & " "

            Else
                strLinha = "| " & _clFuncoes.Exibe_StrEsquerda("F/Fax: " & celularCliente & "/" & faxClient, 30) & " "

            End If
            strLinha += _clFuncoes.Exibe_StrEsquerda("Vd: " & Mid(codVendedor, codVendedor.Length - 1, 2) & "-" & _
            _clFuncoes.trazNomeVendedor(Mid(codVendedor, codVendedor.Length - 3, 4), loja, MdlConexaoBD.conectionPadrao), 29) & " "
            strLinha += "| " & _clFuncoes.Exibe_StrEsquerda( _
            _clFuncoes.trazNomeCondicoesPgtoRelatorio(condicao), 14) & "|"
            s.WriteLine(_clFuncoes.Exibe_cabecalho(strLinha, 4, 80))


            sqlClient = Nothing : cmdClient = Nothing : drClient = Nothing
            oConnBDGENOV.ClearPool() : If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho do Cliente:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Private Sub GravItensArq2(ByVal s As StreamWriter, ByVal numPedido As String, ByVal idOrca1 As Int32, _
                             ByVal codCliente As String, ByVal nomeCliente As String, ByRef shouldReturn As Boolean)
        shouldReturn = False
        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mCodProd, mNomeProd, undProd, strLinha, mfilial, mlocacao As String
            Dim mQtdeProd, mVlProd, mVlTotProd As Double
            Dim mSomaTotProd, mSomaBrutoProd, mSomaDescProd, mSomaVolBrutProd As Double
            strLinha = "" : undProd = ""
            Dim mCont1, mCont2, index As Integer

            Try
                oConnBDGENOV.Open()

            Catch ex As Exception
            End Try

            Dim sqlItem As New StringBuilder
            Dim cmdItem As NpgsqlCommand
            Dim drItem As NpgsqlDataReader
            Dim mContItens As Integer = _valorZERO, mContItensPg As Integer = _valorZERO, mContPg As Integer = _valorZERO

            'SELECT no_orca, no_codpr, no_produt, no_und, no_qtde, no_prunit, no_prtot, 
            'no_alqicm, no_dtemis, no_rota, no_vend, no_lin, no_alqcom, no_comis, 
            'no_mapa, no_supervisor, no_basesub, no_alqsub, no_vlsub, no_idxo1, 
            'no_idpk, no_grupo, no_cdport, no_alqdesc, no_vldesc, no_pruvenda, 
            'no_filial, no_pesobruto, no_pesoliquido, no_geno
            'FROM tb_orca2 WHERE no_orca = '11055165'

            sqlItem.Append("SELECT o2.no_codpr, o2.no_qtde, o2.no_und, e.e_produt, o2.no_prunit, o2.no_prtot, o2.no_filial, el.e_locacao, o2.no_vldesc, o2.no_pesobruto, o2.no_vlsub ") '10
            sqlItem.Append("FROM estloja01 el, " & MdlEmpresaUsu._esqEstab & ".tb_orca2 o2 LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 ")
            sqlItem.Append("e ON e.e_codig = o2.no_codpr WHERE no_idxo1 = " & idOrca1 & " AND el.e_loja = o2.no_filial AND el.e_codig = o2.no_codpr")


            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
            drItem = cmdItem.ExecuteReader

            If drItem.HasRows = True Then
                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("|--------------------------------------------------------------------------------------------------|")
                s.WriteLine("|COD.   | LOJA | LOCAÇÃO  | QUANT. | UND | DESCRICÃO DO PRODUTO               | V.BRUTO |  TOTAL   |")
                '             xxxxxx | xx   |xxxxxxxxxZ|9,999.99| xxx |xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxx|99,999.99|999,999.99|  
                s.WriteLine("|--------------------------------------------------------------------------------------------------|")

                mCont1 = 23
            End If

            mSomaTotProd = _valorZERO
            mContPg = 1
            While drItem.Read


                If mContPg = 1 AndAlso mContItensPg = 23 Then

                    s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                    s.WriteLine(" *** CONTINUACAO DO PEDIDO TRANSPORTADO PARA FOLHA SEGUINTE **  ")
                    s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                    'Quebra 10 Linhas para passar para a próxima folha...
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)


                    mContPg += 1
                    s.WriteLine("                    C O N T I N U A C A O . . .                                       FOLHA: " & String.Format("{0:D3}", mContPg))
                    s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                    s.WriteLine(_clFuncoes.Exibe_StrEsquerda("| Cliente : " & codCliente & "-" & nomeCliente, 84) & " |PED: " & numPedido & "|")
                    s.WriteLine("|--------------------------------------------------------------------------------------------------|")
                    s.WriteLine("|COD.   | LOJA | LOCAÇÃO  | QUANT. | UND | DESCRICÃO DO PRODUTO               | V.BRUTO |  TOTAL   |")
                    '             xxxxxx | xx   |xxxxxxxxxZ|9,999.99| xxx |xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxx|99,999.99|999,999.99|  
                    s.WriteLine("|--------------------------------------------------------------------------------------------------|")

                    mContItensPg = _valorZERO


                ElseIf mContPg > 1 AndAlso mContItensPg = 28 Then

                    s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                    s.WriteLine(" *** CONTINUACAO DO PEDIDO TRANSPORTADO PARA FOLHA SEGUINTE **  ")
                    s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                    'Quebra 10 Linhas para passar para a próxima folha...
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)


                    mContPg += 1
                    s.WriteLine("                    C O N T I N U A C A O . . .                                       FOLHA: " & String.Format("{0:D3}", mContPg))
                    s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                    s.WriteLine(_clFuncoes.Exibe_StrEsquerda("| Cliente : " & codCliente & "-" & nomeCliente, 84) & " |PED: " & numPedido & "|")
                    s.WriteLine("|--------------------------------------------------------------------------------------------------|")
                    s.WriteLine("|COD.   | LOJA | LOCAÇÃO  | QUANT. | UND | DESCRICÃO DO PRODUTO               | V.BRUTO |  TOTAL   |")
                    '             xxxxxx | xx   |xxxxxxxxxZ|9,999.99| xxx |xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxx|99,999.99|999,999.99|  
                    s.WriteLine("|--------------------------------------------------------------------------------------------------|")

                    mContItensPg = _valorZERO
                    mCont2 = 25

                End If

                mCodProd = drItem(0).ToString
                mQtdeProd = drItem(1).ToString
                undProd = drItem(2).ToString
                mNomeProd = drItem(3).ToString
                mVlProd = drItem(4) : If drItem(10) > 0 Then mVlProd = drItem(4) + Round(drItem(10) / mQtdeProd, 2)
                mVlTotProd = drItem(5) + drItem(10)
                mfilial = drItem(6).ToString
                mlocacao = drItem(7).ToString

                mSomaTotProd += mVlTotProd
                mSomaBrutoProd += Round((mVlProd * mQtdeProd), 2)
                mSomaDescProd += drItem(8)
                mSomaVolBrutProd += drItem(9)

                strLinha = "|" & _clFuncoes.Exibe_Str(mCodProd, 6) & " | " & _
                _clFuncoes.Exibe_Str(mfilial, 4) & " |" & _
                _clFuncoes.Exibe_Str(mlocacao, 10) & "|" & _
                _clFuncoes.Exibe_StrDireita(Format(mQtdeProd, "#,##0.00"), 8) & "| " & _
                _clFuncoes.Exibe_Str(undProd, 3) & " |" & _clFuncoes.Exibe_StrEsquerda(mNomeProd, 36) & "|" & _
                _clFuncoes.Exibe_StrDireita(Format(mVlProd, "##,##0.00"), 9) & "|" & _
                _clFuncoes.Exibe_StrDireita(Format(mVlTotProd, "###,##0.00"), 10) & "|"

                s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 100))
                mContItens += 1 : mContItensPg += 1
                mCont1 -= 1 : mCont2 -= 1

            End While
            drItem.Close()

            For index = 0 To mCont1 - 1
                s.WriteLine("|       |      |          |        |     |                                    |         |          |")
            Next

            For index = 0 To mCont2 - 1
                s.WriteLine("|       |      |          |        |     |                                    |         |          |")
            Next


            If mSomaTotProd > _valorZERO Then

                s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                s.WriteLine("|        N§ Documento  |   Valor    |   Resumo   |   P E S O    |   SUB-TOTAL.. R$  |" & _clFuncoes.Exibe_StrDireita(Format(Round(mSomaBrutoProd, 2), "###,##0.00"), 14) & "|")
                s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                s.WriteLine("|                      |            |  itens:    |    A VISTA   |   DESCONTOS.. R$  |" & _clFuncoes.Exibe_StrDireita(Format(Round(mSomaDescProd, 2), "###,##0.00"), 14) & "|")
                s.WriteLine("|                      |            |            |              |----------------------------------|")
                s.WriteLine("|                      |            |  Vol:      |" & _clFuncoes.Exibe_StrDireita(Format(Round(mSomaVolBrutProd, 2), "#,##0.00"), 8) & " (Kg) |   T O T A L . R$  |" & _clFuncoes.Exibe_StrDireita(Format(Round(mSomaTotProd, 2), "###,##0.00"), 14) & "|")
                s.WriteLine("+--------------------------------------------------------------------------------------------------+")

                's.WriteLine("|                                                                                                  |")
                'strLinha = _clFuncoes.Exibe_StrDireita("| TOTAIS --->", 25) & _clFuncoes.Exibe_StrEsquerda(mContItens, 5)
                'If mContItens > 1 Then
                '    strLinha += " - Itens"
                'Else
                '    strLinha += " - Iten "
                'End If
                'strLinha += _clFuncoes.Exibe_StrEsquerda(Format(mSomaTotProd, "###,##0.00"), 59) & "  |" '106 CARACTERES
                's.WriteLine(_clFuncoes.Exibe_Str(strLinha, 100))

                ''                      1        2         3         4         5         6         7         8                    9         0         1         2
                ''            12345678901234567890123456789012345678901234567890123456789012345678901234567890           1234567890123456789012345678901234567890
                's.WriteLine("+--------------------------------------------------------------------------------------------------+")
                s.WriteLine("")
            End If

            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
            mNomeProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing


            oConnBDGENOV.ClearPool() : If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) do Mapa::" & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

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

    Private Sub VisuConteArqSalvo1()

        Try
            ' Especifica as configurações da pagina atual
            pdRelatPedidos.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatPedidos.DefaultPageSettings.Margins.Top = 12
            pdRelatPedidos.DefaultPageSettings.Margins.Right = 12
            pdRelatPedidos.DefaultPageSettings.Margins.Left = 10
            pdRelatPedidos.DefaultPageSettings.Margins.Bottom = 8
            '========================================================

            'Orientação em Paisagem...
            Select Case MdlRelatorioTelas._tl_movorcamento
                Case 1 'Impressora Matricial
                    pdRelatPedidos.DefaultPageSettings.Landscape = True
                Case 2 'Impressora Laiser
                    pdRelatPedidos.DefaultPageSettings.Landscape = False
                Case Else
                    pdRelatPedidos.DefaultPageSettings.Landscape = True
            End Select
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando ORÇAMENTO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatPedidos
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False

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
            'pdRelatPedidos2.DefaultPageSettings.Landscape = True
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando ORÇAMENTO"

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
            e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, recdraw, Strformat)

            '_stringToPrintAux = _StringToPrint
        End If
        _cabecalho = False


        e.Graphics.MeasureString(_StringToPrintItens, _PrintFont2, SizeMeassure2, Strformat, NumChars2, NumLines2)
        StringforPage = _StringToPrintItens.Substring(_valorZERO, NumChars2)

        ' Imprime a string na pagina atual
        'e.Graphics.DrawString(StringforPage, _PrintFont2, Brushes.Black, recdraw, Strformat)
        e.Graphics.DrawString(StringforPage, _PrintFont2, Brushes.Black, e.MarginBounds.Left, 137, Strformat)

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
        'e.Graphics.DrawLine(Pens.Black, 200, 400, 200, 400)
        e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 80, 100, New StringFormat())


        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False '_stringToPrintAux = _StringToPrint

        End If



    End Sub

    Private Sub InicializaRelatorio(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintEventArgs)

        _StringToPrint = _stringToPrintAux
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

    Private Sub atualizaOrcamento(ByRef shouldReturn As Boolean)

        shouldReturn = False
        _numOrcamento = dtg_pedidos.CurrentRow.Cells(2).Value
        _frmRefGeraOrcamento = Me
        Dim frmOrcamento As New Frm_OrcamentoAlt
        frmOrcamento.ShowDialog()
        frmOrcamento.Dispose() : frmOrcamento = Nothing
        _numOrcamento = "" : _mapaPedido = 0
        executaF5()


    End Sub

    Private Sub btn_altera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_altera.Click

        If dtg_pedidos.CurrentRow.IsNewRow = False Then

            Dim mcodvendedor As String = dtg_pedidos.CurrentRow.Cells(9).Value.ToString

            If mcodvendedor.Equals(MdlUsuarioLogando._codvendedor) Then

                Dim lShouldReturn As Boolean
                atualizaOrcamento(lShouldReturn)
                If lShouldReturn Then Return
                lShouldReturn = Nothing

            ElseIf MdlUsuarioLogando._usuarioPrivilegio Then

                Dim lShouldReturn As Boolean
                atualizaOrcamento(lShouldReturn)
                If lShouldReturn Then Return
                lShouldReturn = Nothing

            Else

                _mapaPedido = 0
                MsgBox("Vendedor não pode alterar este pedido", MsgBoxStyle.Exclamation)
                Return
            End If
            _mapaPedido = 0

            mcodvendedor = Nothing


        End If



    End Sub


    Private Sub cbo_opcoes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_opcoes.SelectedIndexChanged

        Select Case cbo_opcoes.SelectedIndex

            Case 0 ' Numero do Orcamento

                msk_pesquisa.SetBounds(171, 21, 78, 21)
                msk_pesquisa.Text = "" : msk_pesquisa.Mask = ""
                msk_periodoFinal.Visible = False : lbl_periodo.Visible = False
                msk_periodoFinal.Text = "" : msk_periodoFinal.Mask = ""

            Case 1 'Data
                msk_pesquisa.SetBounds(171, 21, 78, 21)
                msk_pesquisa.Text = "" : msk_pesquisa.Mask = "00/00/0000"
                msk_periodoFinal.Visible = True : lbl_periodo.Visible = True
                msk_periodoFinal.SetBounds(279, 21, 78, 21)
                'lbl_periodo.SetBounds(320, 600, 15, 13)
                msk_periodoFinal.Text = ""
                msk_periodoFinal.Mask = "00/00/0000"


            Case 2 'Cliente
                msk_pesquisa.SetBounds(165, 21, 225, 21)
                msk_pesquisa.Text = "" : msk_pesquisa.Mask = ""
                msk_periodoFinal.Visible = False : lbl_periodo.Visible = False
                msk_periodoFinal.Text = "" : msk_periodoFinal.Mask = ""

        End Select

    End Sub

    Private Sub btn_busca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_busca.Click

        lbl_opcao.Visible = True : cbo_opcoes.Visible = True : msk_pesquisa.Visible = True : lbl_periodo.Visible = False
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

                    Try
                        msk_pesquisa.Text = Format(CDate(msk_pesquisa.Text), "dd/MM/yyyy")
                        msk_periodoFinal.Text = Format(CDate(msk_periodoFinal.Text), "dd/MM/yyyy")
                    Catch ex As Exception
                    End Try

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

                        If IsDate(msk_pesquisa.Text) = False Then MsgBox("Data Inicial não é uma data válida", MsgBoxStyle.Exclamation) : Return
                        If IsDate(msk_periodoFinal.Text) = False Then MsgBox("Data Final não é uma data válida", MsgBoxStyle.Exclamation) : Return
                        If IsDate(msk_pesquisa.Text) AndAlso IsDate(msk_periodoFinal.Text) Then
                            msk_periodoFinal.Refresh()
                            If CDate(msk_periodoFinal.Text) < CDate(msk_pesquisa.Text) Then

                                MsgBox("Data Final MENOR que a data Inicial", MsgBoxStyle.Exclamation) : Return
                            End If
                        End If

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
                'permite só letras
                If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

            Case Else
                'permite só numeros
                If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

        End Select


    End Sub

    Private Sub converteOrcamento(ByRef shouldReturn As Boolean)

        shouldReturn = False

        Try

            _mapaPedido = 0
            _numOrcamento = dtg_pedidos.CurrentRow.Cells(2).Value
            _frmRefGeraOrcamento = Me
            Dim frmOrcamentoCop As New Frm_OrcaConvPedido
            frmOrcamentoCop.ShowDialog()
            frmOrcamentoCop.Dispose() : frmOrcamentoCop = Nothing
            _numOrcamento = "" : _mapaPedido = 0
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try



    End Sub

    Private Sub btn_convertOrca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_convertOrca.Click

        If dtg_pedidos.CurrentRow.IsNewRow = False Then

            Dim mcodvendedor As String = dtg_pedidos.CurrentRow.Cells(9).Value.ToString
            _numOrcamento = dtg_pedidos.CurrentRow.Cells(2).Value.ToString

            If mcodvendedor.Equals(MdlUsuarioLogando._codvendedor) Then

                Dim lShouldReturn As Boolean
                converteOrcamento(lShouldReturn)
                If lShouldReturn Then Return
                lShouldReturn = Nothing

            ElseIf MdlUsuarioLogando._usuarioPrivilegio Then

                Dim lShouldReturn As Boolean
                converteOrcamento(lShouldReturn)
                If lShouldReturn Then Return
                lShouldReturn = Nothing

            Else

                _mapaPedido = 0
                MsgBox("Vendedor não pode alterar este pedido", MsgBoxStyle.Exclamation)
                Return
            End If
            mcodvendedor = Nothing


        End If


    End Sub

End Class