Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class Frm_CorteCargas

    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes, _clBD As New Cl_bdMetrosys


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_prodCorte.CellContentClick

    End Sub

    Private Sub btn_pesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pesquisar.Click

        If verificaProdMapa() Then

            preecheDtgProdCorte()
        End If
    End Sub

    Private Function verificaProdMapa() As Boolean

        If IsNumeric(Me.txt_numMapa.Text) = False Then

            MsgBox("NUMERO do mapa deve ser NUMERO INTEIRO", MsgBoxStyle.Exclamation)
            Me.txt_numMapa.Focus() : Me.txt_numMapa.SelectAll() : Return False
        End If

        If IsNumeric(Me.txt_codProduto.Text) = False Then

            MsgBox("CÓDIGO do produto deve ser NUMERO INTEIRO", MsgBoxStyle.Exclamation)
            Me.txt_codProduto.Focus() : Me.txt_codProduto.SelectAll() : Return False
        End If

        Return True
    End Function

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click

        Me.Close()
    End Sub

    Private Sub txt_numMapa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numMapa.Leave

        If IsNumeric(Me.txt_numMapa.Text) Then

            Me.txt_numMapa.Text = String.Format("{0:D8}", CInt(Me.txt_numMapa.Text))
        Else
            MsgBox("NUMERO do mapa deve ser NUMERO INTEIRO", MsgBoxStyle.Exclamation)
            Me.txt_numMapa.Focus() : Me.txt_numMapa.SelectAll() : Return
        End If


    End Sub

    Private Sub txt_numMapa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numMapa.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_codProduto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codProduto.Leave

        If IsNumeric(Me.txt_codProduto.Text) Then

            Me.txt_codProduto.Text = String.Format("{0:D5}", CInt(Me.txt_codProduto.Text))
        Else
            MsgBox("CÓDIGO do produto deve ser NUMERO INTEIRO", MsgBoxStyle.Exclamation)
            Me.txt_codProduto.Focus() : Me.txt_codProduto.SelectAll() : Return
        End If


    End Sub

    Private Sub txt_codProduto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codProduto.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub Frm_CorteCargas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()
        End Select


    End Sub

    Private Sub preecheDtgProdCorte()

        Dim conn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mCmd As New NpgsqlCommand
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim mDr As NpgsqlDataReader

        Dim mProdCortado As Boolean = False
        Dim mNumPedido, mData, mProduto As String
        Dim mQtde, mTotal As Double
        Dim mNumMapa As Integer = CInt(Me.txt_numMapa.Text)
        Dim mCodProd As String = String.Format("{0:D5}", CInt(Me.txt_codProduto.Text))
        Dim mIndiceLinha As Integer = 0

        conn.Open()

        Sqlcomm.Append("SELECT n2.no_orca, n2.no_dtemis, e.e_codig || ' - ' || e.e_produt, n2.no_qtde, n2.no_prtot, n2.no_corte FROM ") '5
        Sqlcomm.Append(MdlEmpresaUsu._esqEstab & ".orca2cc n2 LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 e ON ")
        Sqlcomm.Append("n2.no_codpr = e.e_codig WHERE n2.no_mapa = @mapa AND n2.no_codpr = @codpr ORDER BY n2.no_dtemis ASC")
        mCmd = New NpgsqlCommand(Sqlcomm.ToString, conn)
        mCmd.Parameters.Add("@mapa", mNumMapa)
        mCmd.Parameters.Add("@codpr", mCodProd)


        mDr = mCmd.ExecuteReader
        dtg_prodCorte.Rows.Clear() : dtg_prodCorte.Refresh()

        While mDr.Read

            mNumPedido = mDr(0).ToString
            mData = Format(mDr(1), "dd/MM/yyyy")
            mProduto = mDr(2).ToString
            mQtde = mDr(3)
            mTotal = mDr(4)
            mProdCortado = mDr(5)

            dtg_prodCorte.Rows.Add(mNumPedido, mData, mProduto, Format(mQtde, "###,##0.00"), _
                                   Format(mTotal, "###,##0.00"))

            If mProdCortado Then

                dtg_prodCorte.Refresh()
                mIndiceLinha = indexLinhaPedido(mNumPedido)
                If mIndiceLinha >= _valorZERO Then

                    dtg_prodCorte.Rows(mIndiceLinha).DefaultCellStyle.BackColor = Color.Bisque
                    dtg_prodCorte.Rows(mIndiceLinha).DefaultCellStyle.Font = _
                    New Font(Me.dtg_prodCorte.DefaultCellStyle.Font, FontStyle.Strikeout)
                End If
            End If
            

        End While
        dtg_prodCorte.Refresh()
        mDr.Close() : conn.ClearAllPools() : conn.Close() : conn = Nothing
        mCmd = Nothing : mDr = Nothing : Sqlcomm = Nothing



    End Sub

    Private Function indexLinhaPedido(ByVal numPedido As String) As Integer

        'Verifica se Produto já existe no Grid...
        For Each row As DataGridViewRow In Me.dtg_prodCorte.Rows

            If Not row.IsNewRow Then
                If row.Cells(0).Value.Equals(numPedido) Then

                    Return row.Index

                End If
            End If
        Next

        Return -1
    End Function

    Private Sub dtg_prodCorte_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtg_prodCorte.CellDoubleClick

        Me.txt_qtdeAtual.Text = Me.dtg_prodCorte.CurrentRow.Cells(3).Value
        Me.lbl_numPedido.Text = Me.dtg_prodCorte.CurrentRow.Cells(0).Value
        Me.txt_qtdeCorte.Text = "0" : Return

    End Sub

    Private Sub dtg_prodCorte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtg_prodCorte.KeyDown

        Me.txt_qtdeAtual.Text = Me.dtg_prodCorte.CurrentRow.Cells(3).Value
        Me.lbl_numPedido.Text = Me.dtg_prodCorte.CurrentRow.Cells(0).Value
        Me.txt_qtdeCorte.Text = "0" : Return

    End Sub

    Private Sub btn_cortar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cortar.Click

        If IsNumeric(Me.txt_qtdeCorte.Text) Then


            If CDbl(Me.txt_qtdeCorte.Text) > _valorZERO Then

                If rdb_diminuir.Checked Then


                    Select Case CDbl(Me.txt_qtdeCorte.Text)

                        Case Is > CDbl(Me.txt_qtdeAtual.Text)
                            MsgBox("QUANTIDADE de Corte deve ser MENOR ou IGUAL que a QUANTIDADE ATUAL", MsgBoxStyle.Exclamation) : Return

                        Case Is = CDbl(Me.txt_qtdeAtual.Text)
                            If MessageBox.Show("Quantidade ficará ZERADA e o Produto será excluído! Deseja continuar?", _
                            "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = _
                            Windows.Forms.DialogResult.Yes Then

                                ' Faz corte produto zerado
                                corteProdutoZerado()
                            End If

                        Case Else
                            'Faz o CORTE...
                            corteProdutoDiminuir()

                    End Select

                Else
                    'Faz o CORTE...
                    corteProdutoAumentar()

                End If
                


            Else

                MsgBox("QUANTIDADE deve ser maior que ZERO", MsgBoxStyle.Exclamation) : Return
            End If

        Else

            MsgBox("QUANTIDADE para corte deve ser NUMÉRICO", MsgBoxStyle.Exclamation) : Return
        End If


    End Sub

    Private Sub corteProdutoDiminuir()

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return

        End Try

        Dim mLoja As String = ""
        Dim malqicms, malqcom, mcomis, mbasesub, malqsub, mvlcims As Double
        Dim mvlsub, malqdesc, mvldesc, mbaseicms, moutrasdesp, mprecoVenda As Double
        Dim mvlqtde, mvlunit, mvltotal, mpesobruto, mpesoliq As Double

        Try
            transacao = conexao.BeginTransaction

            mLoja = _clFuncoes.trazValorColunaOrca2cc("no_filial", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)
            _clBD.somaQtdeProdEstloja(Me.txt_codProduto.Text, mLoja, CDbl(Me.txt_qtdeCorte.Text), conexao, transacao)
            _clBD.subtraiQtdeOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, CDbl(Me.txt_qtdeCorte.Text), _
                              conexao, transacao)

            transacao.Commit() : conexao.ClearAllPools() : transacao = conexao.BeginTransaction

            'Tratamento dos valores do produto...
            malqicms = Round(CDbl(_clFuncoes.trazValorColunaOrca2cc("no_alqicm", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)), 2)
            mvlunit = Round(CDbl(_clFuncoes.trazValorColunaOrca2cc("no_prunit", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)), 2)
            mvlqtde = Round(CDbl(_clFuncoes.trazValorColunaOrca2cc("no_qtde", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)), 2)
            malqsub = Round(CDbl(_clFuncoes.trazValorColunaOrca2cc("no_alqsub", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)), 2)
            malqdesc = Round(CDbl(_clFuncoes.trazValorColunaOrca2cc("no_alqdesc", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)), 2)
            mprecoVenda = Round(CDbl(_clFuncoes.trazValorColunaOrca2cc("no_pruvenda", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)), 2)


            mvltotal = Round((mvlqtde * mvlunit), 2)
            If malqdesc > _valorZERO Then

                mvldesc = Round((mvltotal * malqdesc) / 100, 2)
                mvltotal -= mvldesc
            Else

                If mvlunit < mprecoVenda Then

                    mvldesc = Round((mprecoVenda - mvlunit) * mvlqtde, 2)
                End If
            End If


            If malqicms > _valorZERO Then

                mbaseicms = mvltotal
                If malqsub > _valorZERO Then

                    mbasesub = mvltotal
                    mvlsub = Round((mbasesub * (malqsub / 100)), 2)
                    'mvltotal = Round(mvltotal + mvlsub, 2)
                End If

                mvlcims = Round((mbaseicms * (malqicms / 100)), 2)
            End If

            mpesobruto = CDbl(_clFuncoes.trazValorColunaEst0001("e_pesobruto", Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao))
            mpesobruto = Round(mpesobruto * mvlqtde, 2)
            mpesoliq = CDbl(_clFuncoes.trazValorColunaEst0001("e_pesoliq", Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao))
            mpesoliq = Round(mpesoliq * mvlqtde, 2)

            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_prtot", mvltotal, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_baseicm", mbaseicms, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_vlicms", mvlcims, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_basesub", mbasesub, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_vlsub", mvlsub, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_pesobruto", mpesobruto, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_pesoliquido", mpesoliq, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_alqdesc", malqdesc, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_vldesc", mvldesc, conexao, transacao)
            _clBD.atualizaColunaCorteOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, True, conexao, transacao)

            transacao.Commit() : conexao.ClearAllPools() : transacao = conexao.BeginTransaction

            alteraOrca4(conexao, transacao)


            transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
            MsgBox("CORTE Efetuado c/ Sucesso", MsgBoxStyle.Exclamation, "METROSYS")

            Dim mIndiceLinha As Integer = indexLinhaPedido(Me.lbl_numPedido.Text)
            If mIndiceLinha >= _valorZERO Then


                dtg_prodCorte.Rows(mIndiceLinha).Cells(3).Value = Format(mvlqtde, "###,##0.00")
                dtg_prodCorte.Rows(mIndiceLinha).Cells(4).Value = Format(mvltotal, "###,##0.00")
                dtg_prodCorte.Rows(mIndiceLinha).DefaultCellStyle.BackColor = Color.Bisque
                dtg_prodCorte.Rows(mIndiceLinha).DefaultCellStyle.Font = _
                New Font(Me.dtg_prodCorte.DefaultCellStyle.Font, FontStyle.Strikeout)
                dtg_prodCorte.Rows(mIndiceLinha).Selected = False

            End If
            Me.dtg_prodCorte.Refresh() : Me.txt_qtdeCorte.Text = "0,00" : Me.txt_qtdeAtual.Text = "0,00"
            Me.lbl_numPedido.Text = ""

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

    Private Sub corteProdutoAumentar()

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return

        End Try

        Dim mLoja As String = ""
        Dim malqicms, malqcom, mcomis, mbasesub, malqsub, mvlcims As Double
        Dim mvlsub, malqdesc, mvldesc, mbaseicms, moutrasdesp, mprecoVenda As Double
        Dim mvlqtde, mvlunit, mvltotal, mpesobruto, mpesoliq As Double

        Try
            transacao = conexao.BeginTransaction


            mLoja = _clFuncoes.trazValorColunaOrca2cc("no_filial", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)
            _clBD.subtraiQtdeProdEstloja(Me.txt_codProduto.Text, mLoja, CDbl(Me.txt_qtdeCorte.Text), conexao, transacao)
            _clBD.somaQtdeOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, CDbl(Me.txt_qtdeCorte.Text), _
                              conexao, transacao)

            transacao.Commit() : conexao.ClearAllPools() : transacao = conexao.BeginTransaction

            'Tratamento dos valores do produto...
            malqicms = Round(CDbl(_clFuncoes.trazValorColunaOrca2cc("no_alqicm", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)), 2)
            mvlunit = Round(CDbl(_clFuncoes.trazValorColunaOrca2cc("no_prunit", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)), 2)
            mvlqtde = Round(CDbl(_clFuncoes.trazValorColunaOrca2cc("no_qtde", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)), 2)
            malqsub = Round(CDbl(_clFuncoes.trazValorColunaOrca2cc("no_alqsub", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)), 2)
            malqdesc = Round(CDbl(_clFuncoes.trazValorColunaOrca2cc("no_alqdesc", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)), 2)
            mprecoVenda = Round(CDbl(_clFuncoes.trazValorColunaOrca2cc("no_pruvenda", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)), 2)


            mvltotal = Round((mvlqtde * mvlunit), 2)
            If malqdesc > _valorZERO Then

                mvldesc = Round((mvltotal * malqdesc) / 100, 2)
                mvltotal -= mvldesc
            Else

                If mvlunit < mprecoVenda Then

                    mvldesc = Round((mprecoVenda - mvlunit) * mvlqtde, 2)
                End If
            End If


            If malqicms > _valorZERO Then

                mbaseicms = mvltotal
                If malqsub > _valorZERO Then

                    mbasesub = mvltotal
                    mvlsub = Round((mbasesub * (malqsub / 100)), 2)
                    'mvltotal = Round(mvltotal + mvlsub, 2)
                End If

                mvlcims = Round((mbaseicms * (malqicms / 100)), 2)
            End If

            mpesobruto = CDbl(_clFuncoes.trazValorColunaEst0001("e_pesobruto", Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao))
            mpesobruto = Round(mpesobruto * mvlqtde, 2)
            mpesoliq = CDbl(_clFuncoes.trazValorColunaEst0001("e_pesoliq", Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao))
            mpesoliq = Round(mpesoliq * mvlqtde, 2)

            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_prtot", mvltotal, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_baseicm", mbaseicms, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_vlicms", mvlcims, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_basesub", mbasesub, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_vlsub", mvlsub, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_pesobruto", mpesobruto, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_pesoliquido", mpesoliq, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_alqdesc", malqdesc, conexao, transacao)
            _clBD.atualizaColunaOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, "no_vldesc", mvldesc, conexao, transacao)
            _clBD.atualizaColunaCorteOrca2cc(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, True, conexao, transacao)

            transacao.Commit() : conexao.ClearAllPools() : transacao = conexao.BeginTransaction

            alteraOrca4(conexao, transacao)

            transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
            MsgBox("CORTE Efetuado c/ Sucesso", MsgBoxStyle.Exclamation, "METROSYS")

            Dim mIndiceLinha As Integer = indexLinhaPedido(Me.lbl_numPedido.Text)
            If mIndiceLinha >= _valorZERO Then


                dtg_prodCorte.Rows(mIndiceLinha).Cells(3).Value = Format(mvlqtde, "###,##0.00")
                dtg_prodCorte.Rows(mIndiceLinha).Cells(4).Value = Format(mvltotal, "###,##0.00")
                dtg_prodCorte.Rows(mIndiceLinha).DefaultCellStyle.BackColor = Color.Bisque
                dtg_prodCorte.Rows(mIndiceLinha).DefaultCellStyle.Font = _
                New Font(Me.dtg_prodCorte.DefaultCellStyle.Font, FontStyle.Strikeout)
                dtg_prodCorte.Rows(mIndiceLinha).Selected = False

            End If
            Me.dtg_prodCorte.Refresh() : Me.txt_qtdeCorte.Text = "0,00" : Me.txt_qtdeAtual.Text = "0,00"
            Me.lbl_numPedido.Text = ""

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

    Private Sub corteProdutoZerado()

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return

        End Try

        Dim mLoja As String = ""

        Try
            transacao = conexao.BeginTransaction

            mLoja = _clFuncoes.trazValorColunaOrca2cc("no_filial", Me.lbl_numPedido.Text, Me.txt_codProduto.Text, MdlConexaoBD.conectionPadrao)
            _clBD.somaQtdeProdEstloja(Me.txt_codProduto.Text, mLoja, CDbl(Me.txt_qtdeCorte.Text), conexao, transacao)
            _clBD.delProdutoPedido_Orca2(Me.lbl_numPedido.Text, Me.txt_codProduto.Text, conexao, transacao)

            transacao.Commit() : conexao.ClearAllPools() : transacao = conexao.BeginTransaction

            alteraOrca4(conexao, transacao)

            transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
            MsgBox("CORTE Efetuado c/ Sucesso", MsgBoxStyle.Exclamation, "METROSYS")

            Dim mIndiceLinha As Integer = indexLinhaPedido(Me.lbl_numPedido.Text)
            If mIndiceLinha >= _valorZERO Then

                dtg_prodCorte.Rows.Remove(dtg_prodCorte.Rows(mIndiceLinha))
            End If
            Me.dtg_prodCorte.Refresh() : Me.txt_qtdeCorte.Text = "0,00" : Me.txt_qtdeAtual.Text = "0,00"
            Me.lbl_numPedido.Text = ""

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

    Private Sub alteraOrca4(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim nume As String = ""
        Dim tprod, aliss, vliss, vlser, basec, icms, bsub, icsub, tpro2, frete As Double
        Dim segu, outros, ipi, tgeral, peso, desc As Double

        nume = Me.lbl_numPedido.Text

        tprod = _clFuncoes.trazSomaTprodOrca2cc(nume, MdlConexaoBD.conectionPadrao)
        tpro2 = tprod
        basec = _clFuncoes.trazSomaColunaOrca2cc("no_baseicm", nume, MdlConexaoBD.conectionPadrao)
        icms = _clFuncoes.trazSomaColunaOrca2cc("no_vlicms", nume, MdlConexaoBD.conectionPadrao)
        bsub = _clFuncoes.trazSomaColunaOrca2cc("no_basesub", nume, MdlConexaoBD.conectionPadrao)
        icsub = _clFuncoes.trazSomaColunaOrca2cc("no_vlsub", nume, MdlConexaoBD.conectionPadrao)
        tgeral = _clFuncoes.trazSomaColunaOrca2cc("no_prtot", nume, MdlConexaoBD.conectionPadrao)
        peso = _clFuncoes.trazSomaColunaOrca2cc("no_pesobruto", nume, MdlConexaoBD.conectionPadrao)
        desc = _clFuncoes.trazSomaColunaOrca2cc("no_vldesc", nume, MdlConexaoBD.conectionPadrao)
        tgeral = Round((tgeral + icsub), 2)

        _clBD.altPedido_Orca4Corte(nume, tprod, aliss, vliss, vlser, basec, icms, bsub, icsub, tpro2, _
                              frete, segu, outros, ipi, tgeral, peso, desc, conexao, transacao)

    End Sub

    Private Sub Frm_CorteCargas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub txt_qtdeCorte_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtdeCorte.Leave

        If Me.txt_qtdeCorte.Text.Equals("") Then Me.txt_qtdeCorte.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_qtdeCorte.Text) Then

            If CDec(Me.txt_qtdeCorte.Text) <= _valorZERO Then

                MsgBox("Quantidade de Corte deve ser maior que ZERO", MsgBoxStyle.Exclamation)
                Return

            End If
            Me.txt_qtdeCorte.Text = Format(CDec(Me.txt_qtdeCorte.Text), "###,##0.00")

        End If


    End Sub

End Class