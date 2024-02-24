Imports System.Drawing.Printing
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class Frm_ManCargas

    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes, _clBD As New Cl_bdMetrosys
    Dim _ufCorrenteCbo As String = ""

    'objetos para impressão...
    Dim MostrarCaixaImpressoras As Boolean = False
    Dim _StringToPrint As String = "", _stringToPrintAux As String = ""
    Private _PrintFont1 As New Font("Lucida Console", 10) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _sImpressao As StreamWriter
    Dim _cabecalho As Boolean = True
    Private _leitorTabelaImprimir As NpgsqlDataReader


    Private Sub btn_NovoMapa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NovoMapa.Click

        If txt_numMapa.Text.Equals("") Then


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
                txt_numMapa.Text = String.Format("{0:D8}", _clBD.trazProxMapaPedido(MdlEmpresaUsu._codigo, conexao))
                _clBD.updateGenp001MapaPedido(conexao, CInt(Me.txt_numMapa.Text), MdlEmpresaUsu._codigo)
                transacao.Commit() : conexao.ClearAllPools()

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

                If conexao.State = ConnectionState.Open Then conexao.Close()
                conexao = Nothing : transacao = Nothing
            End Try


            preecheDtgPedidos()
        End If



    End Sub

    Private Sub preecheDtgPedidos()

        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mCmd As New NpgsqlCommand
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim mDr As NpgsqlDataReader

        Dim mChecked As Boolean = False
        Dim mNumPedido, mData, mParticipante, mcid, muf As String
        Dim mValor As Double

        conn.Open()

        Sqlcomm.Append("SELECT n1.nt_idx, n1.nt_x, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"", n1.nt_codig AS ""Codigo"", cad.p_portad AS ""Cliente"", n4.n4_tgeral AS ""Valor R$"", n1.nt_cid, n1.nt_uf ") '9
        Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 WHERE n1.nt_codig = cad.p_cod AND n4.n4_nume = n1.nt_orca AND n1.nt_sit < 3 AND (n1.nt_mapa = 0 OR n1.nt_mapa = @nt_mapa) ORDER BY n1.nt_dtemis ")

        'Sqlcomm.Append("desc limit 34")
        mCmd = New NpgsqlCommand(Sqlcomm.ToString, conn)

        If IsNumeric(txt_numMapa.Text) Then
            mCmd.Parameters.Add("@nt_mapa", CInt(txt_numMapa.Text))
        Else
            mCmd.Parameters.Add("@nt_mapa", 0)
        End If

        mDr = mCmd.ExecuteReader
        dtg_pedidos.Rows.Clear() : dtg_pedidos.Refresh()

        While mDr.Read

            mChecked = True
            If Trim(mDr(1).ToString).Equals("") Then mChecked = False

            mNumPedido = mDr(2).ToString
            mData = Format(mDr(3), "dd/MM/yyyy")
            mParticipante = mDr(4).ToString & " - " & mDr(5).ToString
            mValor = mDr(6)
            mcid = mDr(7).ToString
            muf = mDr(8).ToString

            dtg_pedidos.Rows.Add(mDr(0), mChecked, mNumPedido, mData, mParticipante, muf, mcid, _
                                 Format(mValor, "###,##0.00"))

        End While
        mDr.Close() : conn.ClearAllPools() : conn.Close() : conn = Nothing
        mCmd = Nothing : mDr = Nothing : Sqlcomm = Nothing



    End Sub

    Private Sub preecheDtgPedidosEstado()

        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mCmd As New NpgsqlCommand
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim mDr As NpgsqlDataReader

        Dim mChecked As Boolean = False
        Dim mNumPedido, mData, mParticipante, mcid, muf As String
        Dim mValor As Double

        conn.Open()

        Sqlcomm.Append("SELECT n1.nt_idx, n1.nt_x, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"", n1.nt_codig AS ""Codigo"", cad.p_portad AS ""Cliente"", n4.n4_tgeral AS ""Valor R$"", n1.nt_cid, n1.nt_uf ") '9
        Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 WHERE n1.nt_codig=cad.p_cod AND n4.n4_nume=n1.nt_orca AND n1.nt_sit < 3 AND ")
        If Trim(cbo_uf.SelectedItem).Equals("") = False Then Sqlcomm.Append("n1.nt_uf = @nt_uf AND ")
        Sqlcomm.Append("(n1.nt_mapa = @nt_mapa OR n1.nt_mapa = 0) ORDER BY n1.nt_dtemis ")

        'Sqlcomm.Append("desc limit 34")
        mCmd = New NpgsqlCommand(Sqlcomm.ToString, conn)

        If IsNumeric(txt_numMapa.Text) Then
            mCmd.Parameters.Add("@nt_mapa", CInt(txt_numMapa.Text))
        Else
            mCmd.Parameters.Add("@nt_mapa", 0)
        End If

        If Trim(cbo_uf.SelectedItem).Equals("") = False Then mCmd.Parameters.Add("@nt_uf", cbo_uf.SelectedItem)

        mDr = mCmd.ExecuteReader
        dtg_pedidos.Rows.Clear() : dtg_pedidos.Refresh()

        While mDr.Read

            mChecked = True
            If Trim(mDr(1).ToString).Equals("") Then mChecked = False

            mNumPedido = mDr(2).ToString
            mData = Format(mDr(3), "dd/MM/yyyy")
            mParticipante = mDr(4).ToString & " - " & mDr(5).ToString
            mValor = mDr(6)
            mcid = mDr(7).ToString
            muf = mDr(8).ToString

            dtg_pedidos.Rows.Add(mDr(0), mChecked, mNumPedido, mData, mParticipante, muf, mcid, _
                                 Format(mValor, "###,##0.00"))


        End While
        mDr.Close() : conn.ClearAllPools() : conn.Close() : conn = Nothing
        mCmd = Nothing : mDr = Nothing : Sqlcomm = Nothing


    End Sub

    Private Sub preecheDtgPedidosCidade()

        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mCmd As New NpgsqlCommand
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim mDr As NpgsqlDataReader

        Dim mChecked As Boolean = False
        Dim mNumPedido, mData, mParticipante, mcid, muf As String
        Dim mValor As Double

        conn.Open()

        Sqlcomm.Append("SELECT n1.nt_idx, n1.nt_x, n1.nt_orca AS ""Pedido"", n1.nt_dtemis AS ""Emissão"", n1.nt_codig AS ""Codigo"", cad.p_portad AS ""Cliente"", n4.n4_tgeral AS ""Valor R$"", n1.nt_cid, n1.nt_uf ") '9
        Sqlcomm.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd n4 WHERE n1.nt_codig = cad.p_cod AND n4.n4_nume = n1.nt_orca AND n1.nt_sit < 3 AND ")
        If Trim(cbo_uf.SelectedItem).Equals("") = False Then Sqlcomm.Append("n1.nt_uf = @nt_uf AND ")
        If Trim(cbo_cidade.SelectedItem).Equals("") = False Then Sqlcomm.Append("n1.nt_cid = @nt_cid AND ")
        Sqlcomm.Append("(n1.nt_mapa = @nt_mapa OR n1.nt_mapa = 0) ORDER BY n1.nt_dtemis ")

        'Sqlcomm.Append("desc limit 34")
        mCmd = New NpgsqlCommand(Sqlcomm.ToString, conn)

        If IsNumeric(txt_numMapa.Text) Then
            mCmd.Parameters.Add("@nt_mapa", CInt(txt_numMapa.Text))
        Else
            mCmd.Parameters.Add("@nt_mapa", 0)
        End If

        If Trim(cbo_uf.SelectedItem).Equals("") = False Then mCmd.Parameters.Add("@nt_uf", cbo_uf.SelectedItem)
        If Trim(cbo_cidade.SelectedItem).Equals("") = False Then mCmd.Parameters.Add("@nt_cid", cbo_cidade.SelectedItem)

        mDr = mCmd.ExecuteReader
        dtg_pedidos.Rows.Clear() : dtg_pedidos.Refresh()

        While mDr.Read

            mChecked = True
            If Trim(mDr(1).ToString).Equals("") Then mChecked = False

            mNumPedido = mDr(2).ToString
            mData = Format(mDr(3), "dd/MM/yyyy")
            mParticipante = mDr(4).ToString & " - " & mDr(5).ToString
            mValor = mDr(6)
            mcid = mDr(7).ToString
            muf = mDr(8).ToString

            dtg_pedidos.Rows.Add(mDr(0), mChecked, mNumPedido, mData, mParticipante, muf, mcid, _
                                 Format(mValor, "###,##0.00"))


        End While
        mDr.Close() : conn.ClearAllPools() : conn.Close() : conn = Nothing
        mCmd = Nothing : mDr = Nothing : Sqlcomm = Nothing



    End Sub

    Private Sub Frm_ManCargas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                If txt_numMapa.Text.Equals("") = False Then executaF5()

        End Select


    End Sub

    Private Sub executaF5()
        preecheDtgPedidos()
    End Sub

    Private Sub dtg_pedidos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_pedidos.CellClick

        If e.ColumnIndex = 1 Then ' SE cliquei na coluna Marcar...

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

                If dtg_pedidos.CurrentCell.Value Then

                    dtg_pedidos.CurrentCell.Value = False ' : dtg_pedidos.Refresh()

                    _clBD.updateMapaOrca1pp(dtg_pedidos.CurrentRow.Cells(2).Value, 0, MdlConexaoBD.conectionPadrao)
                    _clBD.updateMapaOrca2cc(dtg_pedidos.CurrentRow.Cells(2).Value, 0, MdlConexaoBD.conectionPadrao)
                    _clBD.updateNt_X_Orca1pp(dtg_pedidos.CurrentRow.Cells(2).Value, "", conexao, transacao)

                    txt_totPedidos.Text = trazQuantPedidos(CInt(txt_numMapa.Text), MdlConexaoBD.conectionPadrao)

                    txt_pesoBruto.Text = Format(Round(trazPesoBrutoPedido(CInt(txt_numMapa.Text), MdlConexaoBD.conectionPadrao), 2), _
                    "###,##0.00")

                    txt_valorTotal.Text = Format(Round(trazValorTotalDosPedidos(CInt(txt_numMapa.Text), _
                                        MdlConexaoBD.conectionPadrao), 2), "###,##0.00")

                Else
                    dtg_pedidos.CurrentCell.Value = True ' : dtg_pedidos.Refresh()

                    _clBD.updateMapaOrca1pp(dtg_pedidos.CurrentRow.Cells(2).Value, CInt(txt_numMapa.Text), MdlConexaoBD.conectionPadrao)
                    _clBD.updateMapaOrca2cc(dtg_pedidos.CurrentRow.Cells(2).Value, CInt(txt_numMapa.Text), MdlConexaoBD.conectionPadrao)
                    _clBD.updateNt_X_Orca1pp(dtg_pedidos.CurrentRow.Cells(2).Value, "X", conexao, transacao)

                    txt_totPedidos.Text = trazQuantPedidos(CInt(txt_numMapa.Text), MdlConexaoBD.conectionPadrao)

                    txt_pesoBruto.Text = Format(Round(trazPesoBrutoPedido(CInt(txt_numMapa.Text), MdlConexaoBD.conectionPadrao), 2), _
                    "###,##0.00")

                    txt_valorTotal.Text = Format(Round(trazValorTotalDosPedidos(CInt(txt_numMapa.Text), _
                                        MdlConexaoBD.conectionPadrao), 2), "###,##0.00")
                End If

                transacao.Commit() : conexao.ClearAllPools()

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

                If conexao.State = ConnectionState.Open Then conexao.Close()
                conexao = Nothing : transacao = Nothing
            End Try

        End If


    End Sub

    
    Private Sub Frm_ManCargas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        msk_data.Text = Format(Date.Now, "dd/MM/yyyy")

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos.BeginPrint, AddressOf InicializaRelatorio
    End Sub

    Private Function trazPesoBrutoPedido(ByVal numMapa As String, ByVal strConexao As String) As Double

        Dim mpesobruto As Double
        Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(strConexao)

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return ""

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT Sum(no_pesobruto) FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc WHERE no_mapa = @no_mapa")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDMETROSYS)
        cmd.Parameters.Add("@no_mapa", numMapa)
        dr = cmd.ExecuteReader

        While dr.Read

            Try
                mpesobruto = dr(0)
            Catch ex As Exception
                mpesobruto = 0
            End Try
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDMETROSYS.ClearAllPools() : oConnBDMETROSYS.Close() : oConnBDMETROSYS = Nothing


        Return mpesobruto
    End Function

    Private Function trazQuantPedidos(ByVal numMapa As String, ByVal strConexao As String) As Double

        Dim mpesobruto As Double
        Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(strConexao)

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return ""

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT Count(nt_peso) FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp WHERE nt_mapa = @nt_mapa")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDMETROSYS)
        cmd.Parameters.Add("@nt_mapa", numMapa)
        dr = cmd.ExecuteReader

        While dr.Read

            Try
                mpesobruto = dr(0)
            Catch ex As Exception
                mpesobruto = 0
            End Try
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDMETROSYS.ClearAllPools() : oConnBDMETROSYS.Close() : oConnBDMETROSYS = Nothing


        Return mpesobruto
    End Function

    Private Function trazValorTotalDosPedidos(ByVal numMapa As String, ByVal strConexao As String) As Double

        Dim mvlrTotalPedidos As Double
        Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(strConexao)

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return ""

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT Sum(n4.n4_tgeral) AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp n1, ")
        sql.Append("" & MdlEmpresaUsu._esqEstab & ".orca4dd n4 WHERE n4.n4_nume = n1.nt_orca AND n1.nt_mapa = @nt_mapa")

        cmd = New NpgsqlCommand(sql.ToString, oConnBDMETROSYS)
        cmd.Parameters.Add("@nt_mapa", numMapa)
        dr = cmd.ExecuteReader

        While dr.Read

            Try
                mvlrTotalPedidos = dr(0)
            Catch ex As Exception
                mvlrTotalPedidos = 0.0
            End Try
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDMETROSYS.ClearAllPools() : oConnBDMETROSYS.Close() : oConnBDMETROSYS = Nothing


        Return mvlrTotalPedidos
    End Function

    Private Sub cbo_uf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_uf.GotFocus

        If cbo_uf.DroppedDown = False Then cbo_uf.DroppedDown = True
    End Sub

    Private Sub cbo_uf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_uf.Leave

        preecheDtgPedidosEstado()

        If _ufCorrenteCbo.Equals("") Then

            If cbo_uf.SelectedIndex >= _valorZERO Then

                Me.cbo_cidade = _clFuncoes.PreenchComboMunicipios(Me.cbo_uf.SelectedItem, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
                _ufCorrenteCbo = Me.cbo_uf.SelectedItem

            End If
        ElseIf (cbo_uf.SelectedIndex > _valorZERO) And Not _ufCorrenteCbo.Equals(cbo_uf.Text) Then

            Me.cbo_cidade = _clFuncoes.PreenchComboMunicipios(Me.cbo_uf.SelectedItem, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
            _ufCorrenteCbo = Me.cbo_uf.SelectedItem

        End If


    End Sub

    Private Sub cbo_cidade_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cidade.Leave

        preecheDtgPedidosCidade()
    End Sub

    Private Sub Frm_ManCargas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub btn_gerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gerar.Click

        'txt_numMapa.Text = "00000019"
        If verificaCarga() Then

            executaEspelhoPedido("", "\wged\mapaPedido.txt")
        End If


    End Sub

    Private Sub gravaRoteiroMapa()

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

            If _clBD.existeMapaRoteiro(conexao, CInt(Me.txt_numMapa.Text)) Then

                _clBD.altRoteiroMapa(conexao, transacao, CInt(Me.txt_numMapa.Text), Me.txt_roteiro.Text, _
                                     CDate(Me.msk_data.Text))
            Else
                _clBD.incRoteiroMapa(conexao, transacao, CInt(Me.txt_numMapa.Text), Me.txt_roteiro.Text, _
                                     CDate(Me.msk_data.Text))
            End If

            transacao.Commit() : conexao.ClearAllPools()
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

            If conexao.State = ConnectionState.Open Then conexao.Close()
            conexao = Nothing : transacao = Nothing
        End Try


    End Sub

    Private Function verificaCarga() As Boolean

        If Me.txt_numMapa.Equals("") Then MsgBox("Mapa não existe", MsgBoxStyle.Exclamation) : Return False

        If Trim(Me.txt_roteiro.Text).Equals("") Then
            MsgBox("Informe o Roteiro por favor", MsgBoxStyle.Exclamation) : Return False
        End If

        Return True
    End Function

    Private Sub executaEspelhoPedido(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPmapaPedi.TMP"
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
        _PrintFont1 = New Font("Lucida Console", 11)
        Dim strLinha As String = ""
        Dim mapa As String = Me.txt_numMapa.Text
        Dim dtEmissao As String = msk_data.Text

        s.WriteLine("")
        s.WriteLine(" Mapa: " & mapa & _clFuncoes.Centraliza_Str("MANIFESTO DE CARGA", 48) & "Data: " & dtEmissao)
        s.WriteLine(" Roteiro: " & _clFuncoes.Exibe_StrEsquerda(txt_roteiro.Text, 58) & " Folha: " & "001")


        'itens
        Dim lShouldReturn3 As Boolean
        GravItensArq(s, lShouldReturn3)
        If lShouldReturn3 Then Return


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

    Private Sub GravItensArq(ByVal s As StreamWriter, ByRef shouldReturn As Boolean)
        shouldReturn = False
        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mCodProd, mNomeProd, undProd, strLinha As String
            Dim mQtdeProd, mVlProd, mVlTotProd, mPesoBruto As Double
            Dim mSomaTotProd, mSomaQtdeProd, mSomaVolBrutProd As Double
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


            sqlItem.Append("SELECT DISTINCT n2.no_codpr, e.e_produt, n2.no_und, (SELECT sum(n22.no_qtde) FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc n22 ")
            sqlItem.Append("WHERE n2.no_codpr = n22.no_codpr AND n22.no_mapa = @mapa) AS ""QTDE"", (SELECT sum(n222.no_pesobruto) FROM ")
            sqlItem.Append(MdlEmpresaUsu._esqEstab & ".orca2cc n222 WHERE n2.no_codpr = n222.no_codpr AND n222.no_mapa = @mapa) AS ""PESO"", ")
            sqlItem.Append("(SELECT sum(n2222.no_prtot) FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc n2222 WHERE n2.no_codpr = n2222.no_codpr AND ")
            sqlItem.Append("n2222.no_mapa = @mapa) AS ""PRTOT"" FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc n2 LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 e ON n2.no_codpr = ")
            sqlItem.Append("e.e_codig WHERE n2.no_mapa = @mapa ORDER BY e.e_produt ASC")

            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
            cmdItem.Parameters.Add("@mapa", CInt(txt_numMapa.Text))
            drItem = cmdItem.ExecuteReader

            If drItem.HasRows = True Then
                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("+------------------------------------------------------------------------------+")
                s.WriteLine("|COD.  |DESCRICÃO DO PRODUTO               |UND| QUANT. |  PESO   |   TOTAL    |")
                '             xxxxxx|xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx|xxx|9,999.99|99,999.99|  999,999.99|  
                s.WriteLine("|------------------------------------------------------------------------------|")
                mCont1 = 20

            End If

            mSomaTotProd = _valorZERO
            mContPg = 1
            While drItem.Read

                If mContItensPg = 64 Then
                    mContPg += 1
                    s.WriteLine("+------------------------------------------------------------------------------+")
                    s.WriteLine("")
                    s.WriteLine("")
                    s.WriteLine(" Mapa: " & txt_numMapa.Text & _clFuncoes.Centraliza_Str("MANIFESTO DE CARGA", 48) & "Data: " & msk_data.Text)
                    s.WriteLine(" Roteiro: " & _clFuncoes.Exibe_StrEsquerda(txt_roteiro.Text, 58) & " Folha: " & String.Format("{0:D3}", mContPg))
                    '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                    s.WriteLine("+------------------------------------------------------------------------------+")
                    s.WriteLine("|COD.  |DESCRICÃO DO PRODUTO               |UND| QUANT. |  PESO   |   TOTAL    |")
                    '             xxxxxx|xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx|xxx|9,999.99|99,999.99|  999,999.99|  
                    s.WriteLine("|------------------------------------------------------------------------------|")
                    mContItensPg = 0
                End If

                mCodProd = drItem(0).ToString
                mNomeProd = drItem(1).ToString
                undProd = drItem(2).ToString
                mQtdeProd = drItem(3)
                mPesoBruto = drItem(4)
                mVlTotProd = drItem(5)


                mSomaTotProd += mVlTotProd
                mSomaQtdeProd += mQtdeProd
                mSomaVolBrutProd += mPesoBruto

                strLinha = "|" & _clFuncoes.Exibe_Str(mCodProd, 6) & "|" & _
                _clFuncoes.Exibe_StrEsquerda(mNomeProd, 35) & "|" & _
                _clFuncoes.Exibe_Str(undProd, 3) & "|" & _
                _clFuncoes.Exibe_StrDireita(Format(mQtdeProd, "#,##0.00"), 8) & "|" & _
                _clFuncoes.Exibe_StrDireita(Format(mPesoBruto, "#,##0.00"), 9) & "|" & _
                _clFuncoes.Exibe_StrDireita(Format(mVlTotProd, "###,##0.00"), 12) & "|"
                s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 80))

                mContItens += 1 : mContItensPg += 1

            End While
            drItem.Close()


            If mSomaTotProd > _valorZERO Then


                s.WriteLine("|                                                                              |")
                strLinha = _clFuncoes.Exibe_StrEsquerda("| TOTAIS --->", 25) & _clFuncoes.Exibe_StrDireita(mContItens, 5)
                If mContItens > 1 Then
                    strLinha += " - Itens"
                Else
                    strLinha += " - Iten"
                End If
                '_clFuncoes.Exibe_StrEsquerda(Format(mSomaQtdeProd, "###,##0.00"), 18) & _
                strLinha += _clFuncoes.Exibe_StrDireita(Format(mSomaVolBrutProd, "###,##0.00"), 28) & _
                _clFuncoes.Exibe_StrDireita(Format(mSomaTotProd, "###,##0.00"), 13) & "|" '106 CARACTERES
                s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 80))

                '                      1        2         3         4         5         6         7         8                    9         0         1         2
                '            12345678901234567890123456789012345678901234567890123456789012345678901234567890           1234567890123456789012345678901234567890
                s.WriteLine("+------------------------------------------------------------------------------+")
                s.WriteLine("")
            End If

            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
            mNomeProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing
            oConnBDGENOV.ClearAllPools()
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing

        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) do Mapa", MsgBoxStyle.Exclamation)
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

            'Orientação em Paisagem...
            pdRelatPedidos.DefaultPageSettings.Landscape = False
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando CARGA"

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
        e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, recdraw, Strformat)


        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False ': _stringToPrintAux = _StringToPrint

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

End Class