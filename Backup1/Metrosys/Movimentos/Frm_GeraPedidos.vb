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

Public Class Frm_GeraPedidos
   
    'Protected Const conexao As String = _
    ' "Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDGENOV"
    'Dim mMxml As New GenoNFeXml
    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes, _clBD As New Cl_bdMetrosys
    Public Shared _frmRefGeraPedidos As New Frm_GeraPedidos
    Public _numPedido As String = "", _numPedidoTemp As String = ""
    Public _mapaPedido As Integer = 0
    Dim _mConsulta As New StringBuilder

    'Variáveis para o Carnê...
    Private linhaAtual As Integer = -1
    Private mcell, MCod_Cli, MDuplicata As String
    Private MEmissao As Date
    Private mTotal As Double
    Private mPedido, MCliente, MCodVendedor As String
    Private MEntrada As Double
    Private MQtdeParcelas As Int16


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


    Private Sub Frm_GeraPedidos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

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

        Dim Formped As New Frm_PedidoProntEntrega
        Formped.ShowDialog() : Formped.Dispose()
        preecheDtgPedidos2()
    End Sub

    Private Sub Frm_GeraPedidos_LoadVerificaPedido()

        Select Case MessageBox.Show("Deseja terminar o Pedido Temporário " & _numPedidoTemp & "? Caso NÃO deseje, o pedido será EXCLUÍDO!", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Case Windows.Forms.DialogResult.Yes

                _numPedido = _numPedidoTemp
                _frmRefGeraPedidos = Me
                Dim frmPedidoProntEntrega As New Frm_PedidoProntEntregAlt
                frmPedidoProntEntrega.ShowDialog()
                frmPedidoProntEntrega.Dispose() : frmPedidoProntEntrega = Nothing
                _numPedido = "" : _numPedidoTemp = ""

            Case Windows.Forms.DialogResult.No

                File.Delete(_arqNumPedido)
                deletaPedidoDasTabelasTemporarias(_numPedidoTemp, MdlUsuarioLogando._local)

        End Select


    End Sub

    Private Sub Frm_GeraPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim mstr As String = _clFuncoes.DiscoLocal

        _numPedidoTemp = ""
        'Verifica se existe algum pedido temporário...
        If File.Exists(_arqNumPedido) Then

            'Ler o Arquivo salvo...
            Dim FilePath As String = _arqNumPedido
            Try
                Dim MyfileStream As New IO.StreamReader(FilePath)
                _numPedidoTemp = Trim(MyfileStream.ReadToEnd)
                MyfileStream.Close() : MyfileStream.Dispose() : MyfileStream = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try

                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                Return
            End Try

            'Primeiro ver se existe esse pedido na tabela temporária...
            If _clBD.existePedidoOrca1Temporaria(conection, _numPedidoTemp, MdlUsuarioLogando._local) Then

                Dim mVendedor As String = _clBD.trazVendedorOrca1Temporaria(conection, _numPedidoTemp, MdlUsuarioLogando._local)

                Select Case MessageBox.Show("Deseja terminar o Pedido Temporário " & _numPedidoTemp & "? Caso NÃO deseje o pedido será Cancelado!", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    Case Windows.Forms.DialogResult.Yes

                        'Segundo verifica de o vendedor corrente pode continuar o pedido...
                        If mVendedor.Equals(MdlUsuarioLogando._codvendedor) Then

                            _numPedido = _numPedidoTemp
                            _frmRefGeraPedidos = Me
                            Dim frmPedidoProntEntrega As New Frm_PedidoProntEntregAlt
                            frmPedidoProntEntrega.ShowDialog()
                            frmPedidoProntEntrega.Dispose() : frmPedidoProntEntrega = Nothing
                            _numPedido = "" : _numPedidoTemp = ""

                        ElseIf MdlUsuarioLogando._usuarioPrivilegio Then

                            _numPedido = _numPedidoTemp
                            _frmRefGeraPedidos = Me
                            Dim frmPedidoProntEntrega As New Frm_PedidoProntEntregAlt
                            frmPedidoProntEntrega.ShowDialog()
                            frmPedidoProntEntrega.Dispose() : frmPedidoProntEntrega = Nothing
                            _numPedido = "" : _numPedidoTemp = ""

                        Else

                            MsgBox("Vendedor não pode alterar este pedido", MsgBoxStyle.Exclamation)
                            conection.ClearPool() : conection.Close() : Me.Close()
                        End If


                    Case Windows.Forms.DialogResult.No

                        File.Delete(_arqNumPedido)
                        Dim transacao As NpgsqlTransaction
                        transacao = conection.BeginTransaction
                        cancelaPedidoTEMP(_numPedidoTemp, MdlUsuarioLogando._local, conection, transacao)

                        Try
                            transacao.Commit() : transacao.Dispose() : transacao = Nothing
                        Catch ex As Exception
                        End Try
                        deletaPedidoDasTabelasTemporarias(_numPedidoTemp, MdlUsuarioLogando._local)

                End Select



            End If
            conection.ClearPool() : conection.Close() : conection = Nothing

        End If

        executaF5()

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos.BeginPrint, AddressOf InicializaRelatorio

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos2.BeginPrint, AddressOf InicializaRelatorio2

        verificaCargoUsuario(MdlUsuarioLogando._cargo)

    End Sub

    Private Sub verificaCargoUsuario(ByVal cargo As Integer)

        If MdlTelasAcesso._usuarioTelas.pBtn_cancelarExcluir = False Then
            Me.btn_exclui.Enabled = False : Me.btn_cancelar.Enabled = False
        End If

        Me.btn_carne.Enabled = MdlTelasAcesso._usuarioTelas.pBtn_carne

        Select Case cargo

            Case 1 '1;"VENDEDOR"
                btn_pagar.Enabled = False
                btn_carne.Enabled = False
                btn_boleto.Enabled = False
                btn_np.Enabled = False

            Case 2 '2;"GERENTE"
                Me.btn_exclui.Enabled = True : Me.btn_cancelar.Enabled = True
                Me.btn_carne.Enabled = True

            Case 3 '3;"SUPERVISOR"
                Me.btn_exclui.Enabled = True : Me.btn_cancelar.Enabled = True
                Me.btn_carne.Enabled = True

            Case 4 '4;"CAIXA"
                btn_novo.Enabled = False
                btn_altera.Enabled = False
                btn_exclui.Enabled = False
                btn_cancelar.Enabled = False
                btn_copiar.Enabled = False

            Case 5 '5;"ESTOQUISTA"

        End Select
    End Sub

    Private Sub cancelaPedidoTEMP(ByVal numPedido As String, ByVal loja As String, _
                                        ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim cmdPedido As New NpgsqlCommand
        Dim sqlPedido As New StringBuilder
        Dim drPedido As NpgsqlDataReader

        'Tratamento do Registro do Pedido - ORCA1PP..................................................
        Dim nt_orca, nt_geno, nt_codig, nt_cfop, nt_vend, nt_cid, nt_x, nt_y As String
        Dim nt_tipo2, nt_auto, nt_auto2, nt_descrcondpagto As String
        Dim nt_dtemis, nt_dtsai As Date
        Dim nt_emiss As Boolean = False
        Dim itens, nt_rota, nt_parc, nt_cod1, nt_cod2, nt_cod3, nt_cod4, nt_cod5, nt_tiposelecao As Integer
        Dim nt_cod6, nt_cod7, nt_mapa, nt_sit, mProxNumPedido, nt_itens, nt_parcelas As Integer
        Dim nt_peso, nt_volum, nt_entrada As Double
        Dim mbUF As String = ""

        numPedido = String.Format("{0:D8}", Convert.ToInt64(numPedido))

        nt_orca = "" : nt_geno = "" : nt_codig = "" : nt_cfop = "" : nt_vend = "" : nt_cid = "" : nt_x = ""
        nt_y = "" : nt_tipo2 = "" : nt_auto = "" : nt_auto2 = ""
        nt_rota = 0 : nt_parc = 0 : nt_cod1 = 0 : nt_cod2 = 0 : nt_cod3 = 0 : nt_cod4 = 0 : nt_cod5 = 0
        nt_cod6 = 0 : nt_cod7 = 0 : nt_mapa = 0 : nt_sit = 0 : nt_itens = 0 : nt_peso = 0 : nt_volum = 0

        Try

            sqlPedido.Append("SELECT nt_orca, nt_geno, nt_codig, nt_dtemis, nt_dtsai, nt_emiss, nt_cfop, ") '6
            sqlPedido.Append("nt_vend, nt_cid, nt_itens, nt_rota, nt_peso, nt_x, nt_y, nt_parc, nt_cod1, ") '15
            sqlPedido.Append("nt_cod2, nt_volum, nt_tipo2, nt_auto, nt_auto2, nt_cod3, nt_cod4, nt_cod5, ") '23
            sqlPedido.Append("nt_cod6, nt_cod7, nt_mapa, nt_sit, cad.p_uf, nt_tiposelecao, nt_entrada, nt_descrcondpagto, nt_qtdparcelas ") '32
            sqlPedido.Append("FROM orca1pp LEFT JOIN cadp001 cad ON cad.p_cod = nt_codig ")
            sqlPedido.Append("WHERE nt_orca = @nt_orca AND nt_geno = @nt_geno")

            cmdPedido = New NpgsqlCommand(sqlPedido.ToString, conexao)
            cmdPedido.Parameters.Add("@nt_orca", numPedido)
            cmdPedido.Parameters.Add("@nt_geno", loja)
            drPedido = cmdPedido.ExecuteReader

            nt_sit = 6 '6-Cancelado
            While drPedido.Read

                nt_orca = drPedido(0).ToString
                nt_geno = drPedido(1).ToString
                nt_codig = drPedido(2).ToString
                nt_dtemis = drPedido(3) : nt_dtsai = drPedido(4) : nt_emiss = drPedido(5)
                nt_cfop = drPedido(6).ToString
                nt_vend = drPedido(7).ToString
                nt_cid = drPedido(8).ToString
                nt_itens = drPedido(9) : nt_rota = drPedido(10) : nt_peso = drPedido(11)
                nt_x = drPedido(12).ToString
                nt_y = drPedido(13).ToString
                nt_parc = drPedido(14) : nt_cod1 = drPedido(15) : nt_cod2 = drPedido(16)
                nt_volum = drPedido(17)
                nt_tipo2 = drPedido(18).ToString
                nt_auto = drPedido(19).ToString
                nt_auto2 = drPedido(20).ToString
                nt_cod3 = drPedido(21) : nt_cod4 = drPedido(22) : nt_cod5 = drPedido(23)
                nt_cod6 = drPedido(24) : nt_cod7 = drPedido(25) : nt_mapa = drPedido(26)
                mbUF = drPedido(28).ToString
                nt_tiposelecao = drPedido(29)
                nt_entrada = drPedido(30)
                nt_descrcondpagto = drPedido(31).ToString
                nt_parcelas = drPedido(32)

            End While

            drPedido.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        drPedido.Close()
        cmdPedido.CommandText = "" : sqlPedido.Remove(0, sqlPedido.ToString.Length)
        conexao.ClearPool() 'cmdPedido = Nothing : sqlPedido = Nothing

        'Inclue ou altera registro do pedido....
        If nt_orca.Equals("") Then ' Se não existir tabela temporária....

            _clBD.altSituacaoPedido_Orca1(numPedido, nt_sit, conexao, transacao)
        Else

            _clBD.incPedido_Orca1(nt_orca, nt_geno, nt_codig, nt_dtemis, nt_dtsai, nt_emiss, nt_cfop, _
                              nt_vend, nt_cid, nt_itens, nt_rota, nt_peso, nt_x, nt_y, nt_parc, _
                              nt_volum, nt_tipo2, nt_auto, nt_auto2, nt_cod1, nt_cod2, nt_cod3, _
                              nt_cod4, nt_cod5, nt_cod6, nt_cod7, nt_mapa, nt_sit, mbUF, nt_tiposelecao, _
                              nt_entrada, nt_descrcondpagto, nt_parcelas, conexao, transacao)
        End If

        transacao.Commit() : conexao.ClearPool() : transacao = conexao.BeginTransaction


        'Tratamento do .Orca4dd...
        If nt_orca.Equals("") = False Then 'Se existir tabela temporária...

            'Inseri no .Orca4dd apartir das tabelas temporárias...
            sqlPedido.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".orca4dd(")
            sqlPedido.Append("n4_tipo, n4_nume, n4_tprod, n4_aliss, n4_vliss, n4_vlser, n4_basec, ")
            sqlPedido.Append("n4_icms, n4_bsub, n4_icsub, n4_tpro2, n4_frete, n4_segu, n4_outros, ")
            sqlPedido.Append("n4_ipi, n4_tgeral, n4_pgto, n4_peso, n4_desc, n4_tipo2, n4_ido1pp)")
            sqlPedido.Append("SELECT 'P', n1.nt_orca, (SELECT sum(n2.no_qtde * n2.no_prunit) FROM orca2cc n2 WHERE ")
            sqlPedido.Append("n2.no_orca = n1.nt_orca AND n2.no_geno = @no_geno), 0, 0, 0, (SELECT sum(n22.no_baseicm) FROM orca2cc n22 WHERE ")
            sqlPedido.Append("n22.no_orca = n1.nt_orca AND n22.no_geno = @no_geno), (SELECT sum(n222.no_vlicms) FROM orca2cc n222 WHERE ")
            sqlPedido.Append("n222.no_orca = n1.nt_orca AND n222.no_geno = @no_geno), (SELECT sum(n3.no_basesub) FROM orca2cc n3 WHERE ")
            sqlPedido.Append("n3.no_orca = n1.nt_orca AND n3.no_geno = @no_geno), (SELECT sum(n33.no_vlsub) FROM orca2cc n33 WHERE ")
            sqlPedido.Append("n33.no_orca = n1.nt_orca AND n33.no_geno = @no_geno), (SELECT sum(n333.no_qtde * n333.no_prunit) FROM orca2cc n333 WHERE ")
            sqlPedido.Append("n333.no_orca = n1.nt_orca AND n333.no_geno = @no_geno), 0, 0, 0, 0, (SELECT sum(n4.no_prtot + n4.no_vlsub) FROM ")
            sqlPedido.Append("orca2cc n4 WHERE n4.no_orca = n1.nt_orca AND n4.no_geno = @no_geno), 0, (SELECT sum(n44.no_pesobruto) FROM ")
            sqlPedido.Append("orca2cc n44 WHERE n44.no_orca = n1.nt_orca AND n44.no_geno = @no_geno), (SELECT sum(n444.no_vldesc) FROM ")
            sqlPedido.Append("orca2cc n444 WHERE n444.no_orca = n1.nt_orca AND n444.no_geno = @no_geno), 0, n1.nt_idx FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1 WHERE n1.nt_orca = @nt_orca ORDER BY ")
            sqlPedido.Append("n1.nt_idx")

            cmdPedido.Transaction = transacao
            cmdPedido = New NpgsqlCommand(sqlPedido.ToString, conexao)
            cmdPedido.Parameters.Add("@nt_orca", numPedido)
            cmdPedido.Parameters.Add("@nt_geno", loja)
            cmdPedido.Parameters.Add("@no_geno", Mid(loja, loja.Length - 1, 2))

            cmdPedido.ExecuteNonQuery()

        End If
        transacao.Commit() : conexao.ClearPool() ' : transacao = conexao.BeginTransaction
        cmdPedido.CommandText = "" : sqlPedido.Remove(0, sqlPedido.ToString.Length)



        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transaction As NpgsqlTransaction
        Dim drItens As NpgsqlDataReader
        Dim cmdItens As New NpgsqlCommand
        Try

            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            Return
        End Try

        'Tratamento do Orca2cc...
        If nt_orca.Equals("") Then ' Se não existir tabela temporária....


            'Pega Quantidade da loja_.orca2cc
            Dim mcodProd As String = "", mCodLoja As String = ""
            Dim mqtde As Double
            Dim midGrade As Integer = 0

            Try

                transaction = conection.BeginTransaction
                sqlPedido.Append("SELECT no_codpr, no_qtde, no_filial, no_idgrade FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc ")
                sqlPedido.Append("WHERE no_orca = @no_orca")
                cmdItens = New NpgsqlCommand(sqlPedido.ToString, conexao)
                cmdItens.Parameters.Add("@no_orca", numPedido)
                drItens = cmdItens.ExecuteReader

                While drItens.Read


                    mcodProd = drItens(0).ToString
                    mqtde = drItens(1)
                    mCodLoja = drItens(2).ToString
                    midGrade = drItens(3)

                    _clBD.somaQtdeProdEstloja(mcodProd, mCodLoja, mqtde, conection, transaction)
                    If midGrade > 0 Then _clBD.atualizaQtdeGradeSomandoId(conection, transacao, mqtde, midGrade)

                End While

                transaction.Commit() : conection.ClearAllPools()
                drItens.Close() : conection.Close()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
            End Try

            cmdItens.CommandText = "" : sqlPedido.Remove(0, sqlPedido.ToString.Length)
            conexao.ClearPool()

        Else


            'Pega Quantidade da orca2cc
            Dim mcodProd As String = "", mCodLoja As String = ""
            Dim mqtde As Double
            Dim midGrade As Integer = 0

            Try

                transaction = conection.BeginTransaction
                sqlPedido.Append("SELECT no_codpr, no_qtde, no_filial, no_idgrade FROM orca2cc ")
                sqlPedido.Append("WHERE no_orca = @no_orca AND no_geno = @no_geno")
                cmdItens = New NpgsqlCommand(sqlPedido.ToString, conexao)
                cmdItens.Parameters.Add("@no_orca", numPedido)
                cmdItens.Parameters.Add("@no_geno", Mid(loja, loja.Length - 1, 2))
                drItens = cmdItens.ExecuteReader

                While drItens.Read


                    mcodProd = drItens(0).ToString
                    mqtde = drItens(1)
                    mCodLoja = drItens(2).ToString
                    midGrade = drItens(3)

                    _clBD.somaQtdeProdEstloja(mcodProd, mCodLoja, mqtde, conection, transaction)
                    If midGrade > 0 Then _clBD.atualizaQtdeGradeSomandoId(conection, transacao, mqtde, midGrade)
                End While

                transaction.Commit() : conection.ClearAllPools()
                drItens.Close() : conection.Close()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
            End Try

            cmdItens.CommandText = "" : sqlPedido.Remove(0, sqlPedido.ToString.Length)
            conexao.ClearPool()

        End If
        conexao.ClearPool() ' : transacao.Commit() : transacao = conexao.BeginTransaction
        cmdPedido = Nothing : sqlPedido = Nothing : drPedido = Nothing

    End Sub

    Private Sub finalizaPedidoCancelando()

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return

        End Try

        Try
            transacao = conexao.BeginTransaction

            'incluiRegistroPedido(conexao, transacao)
            'incluiDtg_itens(conexao, transacao)
            'inclueOrca4(conexao, transacao)


            transacao.Commit() : conexao.ClearPool() : conexao.Close()
            MsgBox("Pedido Cancelado c/ Sucesso", MsgBoxStyle.Exclamation, "METROSYS")

        Catch ex As NpgsqlException

            transacao.Rollback()
            MsgBox(ex.Message.ToString)
        Catch ex As Exception


            Try
                transacao.Rollback()
            Catch ex2 As Exception
                MsgBox(ex2.Message.ToString)
            End Try

            MsgBox(ex.Message.ToString)
        Finally
            conexao = Nothing : transacao = Nothing

        End Try



    End Sub

    Private Sub deletaPedidoDasTabelasTemporarias(ByVal numpedido As String, ByVal codGeno As String)

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim mloja As String = Mid(codGeno, codGeno.Length - 1, 2)

        Try

            conection.Open()
            transacao = conection.BeginTransaction

            _clBD.delPedido_Orca2Temporaria(numpedido, mloja, conection, transacao)
            _clBD.delPedido_Orca4Temporaria(numpedido, codGeno, conection, transacao)
            _clBD.delPedido_Orca1Temporaria(numpedido, codGeno, conection, transacao)

            transacao.Commit() : conection.ClearAllPools() : conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            transacao = Nothing : conection = Nothing

        End Try

    End Sub

    Private Sub btn_imprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprime.Click
        'Aqui....
        executaF6()

    End Sub

    Private Sub executaF5()

        If cbo_opcoes.Visible Then

            preecheDtgPedidosPesquisa(msk_pesquisa.Text, msk_pesq2PeriodoFinal.Text)
        Else
            preecheDtgPedidos2()
        End If

    End Sub

    Private Sub preecheDtgPedidos()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Sqlcomm As StringBuilder = New StringBuilder

        If MdlUsuarioLogando._usuarioPrivilegio Then 'verifica se usuário tem privilégio...

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa, n1.nt_entrada, TRIM(SUBSTR(n1.nt_descrcondpagto, 1, 2)) ") '14
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca AND n1.nt_dtemis = CURRENT_DATE order by n1.nt_dtemis ")
        Else

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa, n1.nt_entrada, TRIM(SUBSTR(n1.nt_descrcondpagto, 1, 2)) ") '14
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

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa, n1.nt_entrada, TRIM(SUBSTR(n1.nt_descrcondpagto, 1, 2)) ") '14
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca AND n1.nt_dtemis = CURRENT_DATE order by n1.nt_dtemis ")
        Else

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa, n1.nt_entrada, TRIM(SUBSTR(n1.nt_descrcondpagto, 1, 2)) ") '14
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_vend = '" & MdlUsuarioLogando._codvendedor & "' AND n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca  AND n1.nt_dtemis = CURRENT_DATE order by n1.nt_dtemis ")
        End If
        'Sqlcomm.Append("desc limit 34")

        cmd = New NpgsqlCommand(Sqlcomm.ToString, conn)
        dr = cmd.ExecuteReader

        Me.dtg_pedidos.Rows.Clear() : Me.dtg_pedidos.Refresh()
        While dr.Read

            Try
                dtg_pedidos.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, Format(CDate(dr(3)), "dd/MM/yyyy"), _
                                 dr(4).ToString, dr(5).ToString, dr(6).ToString, dr(7).ToString, _
                                 Format(CDbl(dr(8)), "###,##0.00"), dr(9), dr(10).ToString, dr(11), dr(12), dr(13), dr(14))
            Catch ex As Exception
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

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa, n1.nt_entrada, TRIM(SUBSTR(n1.nt_descrcondpagto, 1, 2)) ") '14
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca ")
        Else

            Sqlcomm.Append("Select n1.nt_idx, n1.nt_geno, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"", n1.nt_vend AS ""Vendedor"", n1.nt_sit, n1.nt_mapa, n1.nt_entrada, TRIM(SUBSTR(n1.nt_descrcondpagto, 1, 2)) ") '14
            Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 where n1.nt_vend = '" & MdlUsuarioLogando._codvendedor & "' AND n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca ")
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

            Try
                dtg_pedidos.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, Format(CDate(dr(3)), "dd/MM/yyyy"), _
                                 dr(4).ToString, dr(5).ToString, dr(6).ToString, dr(7).ToString, _
                                 Format(CDbl(dr(8)), "###,##0.00"), dr(9), dr(10).ToString, dr(11), dr(12), dr(13), dr(14))
            Catch ex As Exception
            End Try
        End While
        dr.Close() : Sqlcomm.Remove(0, Sqlcomm.ToString.Length) : cmd.CommandText = "" : conn.ClearAllPools()
        conn.Close() : dr = Nothing : Sqlcomm = Nothing : cmd = Nothing : conn = Nothing
        Me.dtg_pedidos.Refresh()

    End Sub

    Private Sub executaF6()

        If (Me.dtg_pedidos.Rows.Count > _valorZERO) AndAlso (Me.dtg_pedidos.SelectedCells.Count > 0) Then

            executaEspelhoPedido("", "\wged\consultaPedido.txt")

        End If

    End Sub

    Private Sub executaEspelhoPedidoExtracted1(ByVal s As StreamWriter, ByVal loja As String, ByVal numeroPedido As String, ByVal dtEmissao As String, ByVal codClient As String, ByVal nomeClient As String, ByVal condicao As String, ByVal codVendedor As String, ByVal idOrca1 As Int32, ByRef shouldReturn As Boolean)

        shouldReturn = False

        s.WriteLine("")

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Loja
        _mConsulta.Append("SELECT g_geno, g_ender, g_fone, g_uf, g_cid FROM geno001 WHERE g_codig = '" & loja & "'")
        Dim lShouldReturn1 As Boolean
        _clFuncoes.GravCabLojPedidoMatricial(_mConsulta.ToString, s, loja, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Cliente
        'Traz dados do CLIENTE do Pedido...
        _mConsulta.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
        _mConsulta.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codClient & "'")
        Dim lShouldReturn2 As Boolean
        _clFuncoes.GravCabCliPedidoMatricial(_mConsulta.ToString, s, codClient, numeroPedido, dtEmissao, codVendedor, condicao, loja, lShouldReturn2)
        If lShouldReturn2 Then shouldReturn = True : Return


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'itens
        _mConsulta.Append("SELECT o2.no_codpr, o2.no_qtde, o2.no_und, e.e_produt, o2.no_prunit, o2.no_prtot, o2.no_filial, el.e_locacao, o2.no_vldesc, o2.no_pesobruto, o2.no_vlsub, o2.no_pruvenda ") '11
        _mConsulta.Append("FROM estloja01 el, " & MdlEmpresaUsu._esqEstab & ".orca2cc o2 LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 ")
        _mConsulta.Append("e ON e.e_codig = o2.no_codpr WHERE no_idxo1 = " & idOrca1 & " AND el.e_loja = o2.no_filial AND el.e_codig = o2.no_codpr")
        Dim lShouldReturn3 As Boolean
        _clFuncoes.GravItensPedidoMatricial(_mConsulta.ToString, s, numeroPedido, idOrca1, codClient, nomeClient, lShouldReturn3)
        If lShouldReturn3 Then shouldReturn = True : Return

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
        Dim mArqTemp As String = "\wged\TEMPconsultaPedi.TMP"
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
        _PrintFont1 = New Font("Lucida Console", 11) 'Sans Serif
        Dim strLinha As String = ""
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
        e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 30, 100, New StringFormat())


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

    Private Sub atualizaPedido(ByVal msituacao As Integer, ByRef shouldReturn As Boolean)

        shouldReturn = False
        If msituacao < 3 Then 'Se a situação do pedido for 1-Digitado , 2-Impresso...

            _numPedido = dtg_pedidos.CurrentRow.Cells(2).Value
            _mapaPedido = CInt(dtg_pedidos.CurrentRow.Cells(12).Value)
            _frmRefGeraPedidos = Me
            Dim frmPedidoProntEntrega As New Frm_PedidoProntEntregAlt
            frmPedidoProntEntrega.ShowDialog()
            frmPedidoProntEntrega.Dispose() : frmPedidoProntEntrega = Nothing
            _numPedido = "" : _mapaPedido = 0
            executaF5()

        Else

            Select Case msituacao 'Caso a situação do pedido for 3 - ECF , 4-NFe...

                Case 3
                    MsgBox("Já foi emitido o CUPOM FISCAL para este pedido", MsgBoxStyle.Exclamation)
                    shouldReturn = True : Return

                Case 4
                    MsgBox("Já foi emitido a NFe para este pedido", MsgBoxStyle.Exclamation)
                    shouldReturn = True : Return
            End Select
        End If



    End Sub

    Private Sub btn_altera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_altera.Click

        If dtg_pedidos.CurrentRow.IsNewRow = False Then

            Dim msituacao As Integer = CInt(dtg_pedidos.CurrentRow.Cells(11).Value)
            Dim mcodvendedor As String = dtg_pedidos.CurrentRow.Cells(10).Value.ToString

            If msituacao < 3 Then

                If mcodvendedor.Equals(MdlUsuarioLogando._codvendedor) Then

                    Dim lShouldReturn As Boolean
                    atualizaPedido(msituacao, lShouldReturn)
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing

                ElseIf MdlUsuarioLogando._usuarioPrivilegio Then

                    Dim lShouldReturn As Boolean
                    atualizaPedido(msituacao, lShouldReturn)
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing

                Else

                    _mapaPedido = 0
                    MsgBox("Vendedor não pode alterar este pedido", MsgBoxStyle.Exclamation)
                    Return
                End If
                _mapaPedido = 0

                msituacao = Nothing : mcodvendedor = Nothing
            End If


        End If



    End Sub

    Private Sub dtg_pedidos_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dtg_pedidos.RowsAdded

        Select Case dtg_pedidos.Rows(e.RowIndex).Cells(11).Value

            Case 6
                'dtg_pedidos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Bisque
                dtg_pedidos.Rows(e.RowIndex).DefaultCellStyle.Font = _
                New Font(Me.dtg_pedidos.DefaultCellStyle.Font, FontStyle.Strikeout)

        End Select

    End Sub


    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        'Cancelamento do pedido...
        If Me.dtg_pedidos.CurrentRow.IsNewRow = False Then 'se não linha é nova linha


            If CInt(Me.dtg_pedidos.CurrentRow.Cells(11).Value) < 3 Then 'Verifica status do Pedido 1-Digitado , 2-Impresso, 3-Pago, 4- ECF , 5-NFe,  6-Cancelado


                If MessageBox.Show("Deseja realmente cancelar esse pedido?", "METROSYS", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Dim transacao As NpgsqlTransaction
                    Dim mnumPedido As String = Me.dtg_pedidos.CurrentRow.Cells(2).Value
                    Dim nt_sit As Integer = 6

                    Try

                        conection.Open()
                    Catch ex As Exception
                        MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical) : Return
                    End Try

                    Try

                        transacao = conection.BeginTransaction
                        cancelaPedidoTEMP(mnumPedido, MdlUsuarioLogando._local, conection, transacao)


                        Try
                            transacao.Commit()
                            conection.ClearPool()
                        Catch ex As Exception
                        End Try

                        MsgBox("Pedido Cancelado com sucesso", MsgBoxStyle.Exclamation)
                        executaF5()
                    Catch ex As Exception
                        MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                    Finally

                        If conection.State = ConnectionState.Open Then conection.Close()
                        conection = Nothing : transacao = Nothing
                    End Try


                End If
            End If
        End If


    End Sub

    Private Sub cbo_opcoes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_opcoes.SelectedIndexChanged

        Select Case cbo_opcoes.SelectedIndex

            Case 0 ' Numero do Pedido

                msk_pesquisa.SetBounds(227, 597, 104, 21)
                msk_pesquisa.Text = "" : msk_pesquisa.Mask = ""
                msk_pesq2PeriodoFinal.Visible = False : lbl_periodo.Visible = False
                msk_pesq2PeriodoFinal.Text = "" : msk_pesq2PeriodoFinal.Mask = ""

            Case 1 'Data
                msk_pesquisa.SetBounds(227, 597, 77, 21)
                msk_pesquisa.Text = "" : msk_pesquisa.Mask = "00/00/0000"
                msk_pesq2PeriodoFinal.Visible = True : lbl_periodo.Visible = True
                msk_pesq2PeriodoFinal.SetBounds(350, 597, 77, 21)
                lbl_periodo.SetBounds(320, 600, 15, 13)
                msk_pesq2PeriodoFinal.Text = ""
                msk_pesq2PeriodoFinal.Mask = "00/00/0000"


            Case 2 'Cliente
                msk_pesquisa.SetBounds(227, 597, 304, 21)
                msk_pesquisa.Text = "" : msk_pesquisa.Mask = ""
                msk_pesq2PeriodoFinal.Visible = False : lbl_periodo.Visible = False
                msk_pesq2PeriodoFinal.Text = "" : msk_pesq2PeriodoFinal.Mask = ""

        End Select

    End Sub

    Private Sub btn_busca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_busca.Click

        lbl_opcao.Visible = True : cbo_opcoes.Visible = True : msk_pesquisa.Visible = True
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

                    If IsDate(Me.msk_pesq2PeriodoFinal.Text) = False Then

                        MsgBox("Data FINAL não é DATA", MsgBoxStyle.Exclamation)
                        Me.msk_pesq2PeriodoFinal.Focus() : Me.msk_pesq2PeriodoFinal.SelectAll() : Return False
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

    Private Sub msk_pesquisa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_pesquisa.KeyDown, msk_pesq2PeriodoFinal.KeyDown

        If e.KeyCode = Keys.Enter Then

            If verificaCamposPesquisa() Then


                Select Case cbo_opcoes.SelectedIndex

                    Case 0 ' Numero do Pedido

                        preecheDtgPedidosPesquisa(Me.msk_pesquisa.Text, Me.msk_pesq2PeriodoFinal.Text)
                    Case 1 'Data
                        preecheDtgPedidosPesquisa(Me.msk_pesquisa.Text, Me.msk_pesq2PeriodoFinal.Text)

                    Case 2 'Cliente
                        preecheDtgPedidosPesquisa(Me.msk_pesquisa.Text, Me.msk_pesq2PeriodoFinal.Text)

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

    Private Sub copiaPedido(ByVal situacao As Integer, ByRef shouldReturn As Boolean)

        shouldReturn = False

        Try
            _numPedido = dtg_pedidos.CurrentRow.Cells(2).Value
            _mapaPedido = CInt(dtg_pedidos.CurrentRow.Cells(12).Value)
            If _clFuncoes.existItemOrca2ccLoja(_numPedido, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao) Then

                _frmRefGeraPedidos = Me
                Dim frmPedidoProntEntrega As New Frm_PedidoProntEntregaCop
                frmPedidoProntEntrega.ShowDialog()
                frmPedidoProntEntrega.Dispose() : frmPedidoProntEntrega = Nothing
                executaF5()
            Else

                MsgBox("Este Pedido não contém Iten(s)", MsgBoxStyle.Exclamation)
            End If
            _numPedido = "" : _mapaPedido = 0
            
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        


    End Sub
 
    Private Sub btn_copiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_copiar.Click

        If dtg_pedidos.CurrentRow.IsNewRow = False Then

            Dim msituacao As Integer = CInt(dtg_pedidos.CurrentRow.Cells(11).Value)
            Dim mcodvendedor As String = dtg_pedidos.CurrentRow.Cells(10).Value.ToString

            If msituacao = 6 Then

                Dim lShouldReturn As Boolean
                copiaPedido(msituacao, lShouldReturn)
                If lShouldReturn Then Return
                lShouldReturn = Nothing

                _mapaPedido = 0
                msituacao = Nothing : mcodvendedor = Nothing
            Else

                _mapaPedido = 0
                MsgBox("Pedido deve estar Cancelado para COPIAR", MsgBoxStyle.Exclamation)
                Return
            End If


        End If


    End Sub

    Private Sub btn_carne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_carne.Click

        If linhaAtual > -1 Then

            Try
                Dim Carne As New Frm_CarneContrato
                Carne.txt_total.Text = Format(mTotal, "###,##0.00")
                Carne.txt_cliente.Text = MCliente
                Carne.lbl_contrato.Text = mPedido
                Carne.C_CodCli = MCod_Cli
                Carne.C_CodVendedor = MCodVendedor
                Carne.Duplicata = MDuplicata
                Carne.C_emissao = MEmissao
                Carne.MC_Entrada = MEntrada
                Carne.MC_QtdeParcelas = MQtdeParcelas
                Carne.ShowDialog()
                Carne.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        Else
            MessageBox.Show("Por Favor, Selecione um Registro !", "Erro Seleção ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub dtg_pedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_pedidos.Click

        Try
            linhaAtual = Convert.ToInt32(Me.dtg_pedidos.CurrentRow.Index)
            mTotal = Me.dtg_pedidos.CurrentRow.Cells(8).Value.ToString()
            MCliente = Me.dtg_pedidos.CurrentRow.Cells(5).Value.ToString()
            mPedido = Me.dtg_pedidos.CurrentRow.Cells(2).Value.ToString()
            MCod_Cli = Me.dtg_pedidos.CurrentRow.Cells(4).Value.ToString()
            MDuplicata = Me.dtg_pedidos.CurrentRow.Cells(2).Value.ToString()
            MCodVendedor = Me.dtg_pedidos.CurrentRow.Cells(10).Value.ToString()
            MEmissao = CDate(Me.dtg_pedidos.CurrentRow.Cells(3).Value.ToString)
            MEntrada = CDbl(Me.dtg_pedidos.CurrentRow.Cells(13).Value.ToString)
            Try
                MQtdeParcelas = CInt(Me.dtg_pedidos.CurrentRow.Cells(14).Value.ToString)
            Catch ex As Exception
                MQtdeParcelas = 0
            End Try
            
        Catch ex As Exception
            'MsgBox("ERRO:: " & ex.Message)
        End Try
        

    End Sub

    Private Sub btn_pagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pagar.Click


        'Pagar Pedido...
        If Me.dtg_pedidos.CurrentRow.IsNewRow = False Then 'se não linha é nova linha

            If CInt(Me.dtg_pedidos.CurrentRow.Cells(11).Value) < 3 Then 'Verifica status do Pedido 1-Digitado , 2-Impresso, 3-Pago, 4- ECF , 5-NFe, 6-Cancelado

                _numPedido = Me.dtg_pedidos.CurrentRow.Cells(2).Value.ToString()
                _clBD.altSituacaoPedido_Orca1(_numPedido, 3, MdlConexaoBD.conectionPadrao)
                MsgBox("Pedido pago com Sucesso!")
                executaF5()
            ElseIf (CInt(Me.dtg_pedidos.CurrentRow.Cells(11).Value) >= 3) And (CInt(Me.dtg_pedidos.CurrentRow.Cells(11).Value) < 6) Then

                MsgBox("Pedido já foi PAGO!", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Pedido cancelado não pode ser PAGO!", MsgBoxStyle.Exclamation)
            End If
        End If


    End Sub
End Class