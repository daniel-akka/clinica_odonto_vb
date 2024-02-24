Imports Npgsql
Imports System.Text
Imports System.Data
Imports System.DateTime
Imports System.Math

Public Class Frm_RequMatPrima

    Private Const INT_mValorZERO As Integer = 0
    Private _CodProdEditando As String = ""
    Private _indexProdEditando As Integer = -1
    Public Shared _frmREf As New Frm_RequMatPrima
    Dim _BuscaProd As New Frm_BuscaProdMp
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private _local As String = Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2)
    Public local_Ref As String = _local
    Public _qtdFisc As Double = INT_mValorZERO


    Private Sub txt_quantidade_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_quantidade.GotFocus

        txt_quantidade.SelectAll()

    End Sub

    Private Sub txt_quantidade_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_quantidade.Leave

        If Me.txt_quantidade.Text.Equals("") Then Me.txt_quantidade.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_quantidade.Text) Then

            If CDec(Me.txt_quantidade.Text) <= INT_mValorZERO Then

                MsgBox("Quantidade deve ser maior que ZERO", MsgBoxStyle.Exclamation)
                txt_quantidade.Focus() : Return

            End If
            Me.txt_quantidade.Text = Format(CDec(Me.txt_quantidade.Text), "###,##0.00")

        End If



    End Sub

    Private Sub Frm_RequMatPrima_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_quantidade.Text = "0,00"
        Me.msk_data.Text = Format(Date.Now, "ddMMyyyy")
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        If conection.State = ConnectionState.Closed Then conection.Open()
        Me.txt_requisicao.Text = String.Format("{0:D12}", _clBD.trazProxCodRequis(MdlEmpresaUsu._codigo, conection))
        Me.lbl_usuario.Text = MdlUsuarioLogando._usuarioLogin
        conection = Nothing


    End Sub

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click

        If Me.dtg_lancamento.RowCount > 0 Then

            If MessageBox.Show("Deseja realmente Sair? O Processo será Abortado!", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Me.Close()

            End If
        Else
            Me.Close()

        End If



    End Sub

    Private Sub btn_finalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalizar.Click

        If MessageBox.Show("Deseja realmente Gravar essa Requisição?", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If inclueDtg_Lancamento() Then

                MsgBox("Requisição Gravada com Sucesso", MsgBoxStyle.Exclamation)
                Me.Close()

            End If
        End If



    End Sub

    Private Function inclueDtg_Lancamento() As Boolean

        Dim mNumRequisicao As String = Me.txt_requisicao.Text
        Dim mDataRequisicao As Date = CDate(Me.msk_data.Text)
        Dim mCodProdRequis As String = "", mQtdeRequisicao As Double = 0
        Dim mUsuarioRequis As String = Me.lbl_usuario.Text
        Dim mqtdFisc As Double = INT_mValorZERO
        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim tudoOK As Boolean = True

        Try
            conexao.Open()
        Catch ex As Exception
            tudoOK = False
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)

        End Try

        Try
            transacao = conexao.BeginTransaction

            Try


                For Each row As DataGridViewRow In Me.dtg_lancamento.Rows

                    If Not row.IsNewRow Then

                        mCodProdRequis = row.Cells(0).Value
                        mQtdeRequisicao = row.Cells(3).Value
                        _clBD.inclueRequisicao(conexao, transacao, mNumRequisicao, mDataRequisicao, _
                        mCodProdRequis, mQtdeRequisicao, mUsuarioRequis)
                        mqtdFisc = _clBD.pegaQtdfiscEstoque(mCodProdRequis, _local, conexao)

                        If (mqtdFisc - mQtdeRequisicao) < INT_mValorZERO Then
                            MsgBox("Produto com quantidade insuficiente no estoque! Codigo:: " & mCodProdRequis, _
                                  MsgBoxStyle.Exclamation)

                            dtg_lancamento.Rows(row.Index).DefaultCellStyle.BackColor = Color.Aquamarine
                            dtg_lancamento.Refresh() : tudoOK = False : Exit For

                        End If

                        _clBD.subtraiQtdeProdEstloja(mCodProdRequis, _local, mQtdeRequisicao, conexao, transacao)
                        '_clBD.subtraiQtdFiscProd(mCodProdRequis, _local, mQtdeRequisicao, conexao, transacao)
                    End If
                Next


                If tudoOK = True Then

                    _clBD.updateGenp001CodRequis(conexao, String.Format("{0:D12}", CInt(mNumRequisicao)), MdlEmpresaUsu._codigo)
                    transacao.Commit()

                End If
                conexao.ClearAllPools()

            Catch ex1 As Exception
                Try
                    transacao.Rollback() : tudoOK = False
                Catch ex2 As Exception
                    tudoOK = False
                End Try
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
            tudoOK = False

        Finally

            'LIMPA OBJETOS DA MEMÓRIA...
            conexao.Close() : conexao = Nothing : transacao = Nothing
            mNumRequisicao = Nothing : mDataRequisicao = Nothing : mCodProdRequis = Nothing
            mQtdeRequisicao = Nothing : mUsuarioRequis = Nothing : mqtdFisc = Nothing


        End Try



        Return tudoOK
    End Function

    Private Sub addItemGrid()

        Dim mlinha As String() = {txt_codProd.Text, msk_data.Text, txt_nomeProd.Text, txt_quantidade.Text}

        'Adicionando Linha
        Me.dtg_lancamento.Rows.Add(mlinha)
        Me.dtg_lancamento.Refresh()
        If Me.dtg_lancamento.RowCount > INT_mValorZERO Then Me.msk_data.ReadOnly = True
        mlinha = Nothing



    End Sub

    Private Sub addItemEditadoGrid()

        Dim mlinha As String() = {txt_codProd.Text, msk_data.Text, txt_nomeProd.Text, txt_quantidade.Text}

        'Adicionando Linha
        Me.dtg_lancamento.Rows(_indexProdEditando).SetValues(mlinha)
        Me.dtg_lancamento.Refresh()
        If Me.dtg_lancamento.RowCount > INT_mValorZERO Then Me.msk_data.ReadOnly = True
        mlinha = Nothing



    End Sub

    Private Function verifCampos() As Boolean

        Dim mNaoDeuErro As Boolean = True
        If Not IsDate(msk_data.Text) Then

            mNaoDeuErro = False
            MsgBox("Data inválida!", MsgBoxStyle.Exclamation)
            msk_data.Focus()

        End If

        If txt_codProd.Text.Equals("") Then

            mNaoDeuErro = False
            MsgBox("Informar o Código do Produto", MsgBoxStyle.Exclamation)
            txt_codProd.Focus()

        End If

        If Not IsNumeric(txt_quantidade.Text) OrElse CDbl(txt_quantidade.Text) <= 0 Then

            mNaoDeuErro = False
            MsgBox("Informe a quantidade para o Produto", MsgBoxStyle.Exclamation)
            txt_quantidade.Focus()

        End If

        If CDbl(txt_quantidade.Text) > CDbl(lbl_qtdeFisc.Text) Then

            mNaoDeuErro = False
            MsgBox("Quantidade é maior do que a disponível no Estoque", MsgBoxStyle.Exclamation)
            txt_quantidade.Focus()

        End If



        Return mNaoDeuErro
    End Function

    Private Sub btn_lanca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lanca.Click

        If verifCampos() Then

            If _CodProdEditando.Equals("") Then

                addItemGrid()

            Else
                addItemEditadoGrid()

            End If


            If Me.dtg_lancamento.RowCount > INT_mValorZERO Then

                Me.msk_data.ReadOnly = True : Me.txt_codProd.Focus()

            Else
                Me.msk_data.Focus()

            End If
            txt_codProd.Text = "" : txt_nomeProd.Text = "" : lbl_qtdeFisc.Text = "0,00"

        End If



    End Sub

    Private Sub DeleteItemGrid()

        Try

            If Me.dtg_lancamento.Enabled = True Then

                'Remove Linha
                Me.dtg_lancamento.Rows(dtg_lancamento.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
                Me.dtg_lancamento.Rows.Remove(Me.dtg_lancamento.CurrentRow)
                Me.dtg_lancamento.Refresh()
                If dtg_lancamento.RowCount <= INT_mValorZERO Then Me.msk_data.ReadOnly = False

            End If

        Catch ex As Exception
            MsgBox("Deu ERRO ao Deletar este Item " & ex.Message, MsgBoxStyle.Exclamation)

        End Try



    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click

        If MessageBox.Show("Deseja realmente Deletar esse Item?", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.DeleteItemGrid()

        End If



    End Sub

    Private Sub txt_quantidade_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_quantidade.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = INT_mValorZERO Then e.Handled = True

    End Sub

    Public Function trazItenBD(ByVal codIten As String) As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        Dim codigo, nome, qtdEstoque As String


        Try
            SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_qtdfisc FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e ") ' 3
            SqlProduto.Append("WHERE e.e_codig = '" & Me.txt_codProd.Text & "' ORDER BY e_produt ASC")

            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDGENOV)
            drProduto = CmdProduto.ExecuteReader

            If drProduto.HasRows = False Then Return False
            While drProduto.Read

                codigo = drProduto(INT_mValorZERO).ToString : nome = drProduto(1).ToString
                qtdEstoque = drProduto(2).ToString
                Me.txt_codProd.Text = codigo : Me.txt_nomeProd.Text = nome

            End While
            drProduto.Close() : oConnBDGENOV.ClearPool()


        Catch ex As Exception
            MsgBox("ERRO no SELECT do Produto:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        CmdProduto.CommandText = ""
        SqlProduto.Remove(INT_mValorZERO, SqlProduto.ToString.Length)
        oConnBDGENOV.Close()

        'LIMPA OBJETOS DA MEMÓRIA...
        oConnBDGENOV = Nothing : CmdProduto = Nothing : SqlProduto = Nothing : drProduto = Nothing
        codigo = Nothing : nome = Nothing : qtdEstoque = Nothing



        Return True
    End Function

    Private Sub txt_codProd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codProd.GotFocus

        txt_codProd.SelectAll()

    End Sub

    Private Sub txt_codProd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codProd.KeyDown

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then


            If Me.txt_codProd.Text.Equals("") Then

                'Aqui tenta chamar a Busca do Produto...
                Try
                    _frmREf = Me : _BuscaProd.set_frmRef(Me) : _BuscaProd.ShowDialog(Me)
                    lbl_qtdeFisc.Text = Format(_qtdFisc, "###,##0.00")
                    If Me.txt_codProd.Text.Equals("") Then Me.txt_codProd.Focus()

                Catch ex As Exception
                End Try

            Else


                If trazItenBD(Me.txt_codProd.Text) = False Then

                    'Aqui tenta chamar a Busca do Produto...
                    Try
                        _frmREf = Me : _BuscaProd.set_frmRef(Me) : _BuscaProd.ShowDialog(Me)
                        lbl_qtdeFisc.Text = Format(_qtdFisc, "###,##0.00")
                        If Me.txt_codProd.Text.Equals("") Then Me.txt_codProd.Focus()

                    Catch ex As Exception
                    End Try

                End If
            End If
        End If



    End Sub

    Private Sub msk_data_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles msk_data.GotFocus

        Me.msk_data.SelectAll()

    End Sub

    Private Sub Frm_RequMatPrima_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")

        End If



    End Sub

    Private Sub txt_nomeProd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nomeProd.GotFocus

        txt_nomeProd.SelectAll()

    End Sub

    Private Sub dtg_lancamento_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_lancamento.DoubleClick

        If Not dtg_lancamento.CurrentRow.IsNewRow Then

            Me._indexProdEditando = dtg_lancamento.CurrentRow.Index
            Me._CodProdEditando = dtg_lancamento.CurrentRow.Cells(0).Value
            Me.msk_data.Text = dtg_lancamento.CurrentRow.Cells(1).Value
            Me.txt_codProd.Text = dtg_lancamento.CurrentRow.Cells(0).Value
            Me.txt_nomeProd.Text = dtg_lancamento.CurrentRow.Cells(2).Value
            Me.txt_quantidade.Text = dtg_lancamento.CurrentRow.Cells(3).Value
            dtg_lancamento.CurrentRow.DefaultCellStyle.BackColor = Color.White

        End If


    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If Not dtg_lancamento.CurrentRow.IsNewRow Then

            Me._indexProdEditando = dtg_lancamento.CurrentRow.Index
            Me._CodProdEditando = dtg_lancamento.CurrentRow.Cells(0).Value
            Me.msk_data.Text = dtg_lancamento.CurrentRow.Cells(1).Value
            Me.txt_codProd.Text = dtg_lancamento.CurrentRow.Cells(0).Value
            Me.txt_nomeProd.Text = dtg_lancamento.CurrentRow.Cells(2).Value
            Me.txt_quantidade.Text = dtg_lancamento.CurrentRow.Cells(3).Value
            dtg_lancamento.CurrentRow.DefaultCellStyle.BackColor = Color.White

        End If



    End Sub

    Private Sub dtg_lancamento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtg_lancamento.KeyDown

        Select Case e.KeyCode
            Case Keys.Delete
                If MessageBox.Show("Deseja realmente Deletar esse Item?", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Me.DeleteItemGrid()

                End If


            Case Keys.F2
                If Not dtg_lancamento.CurrentRow.IsNewRow Then

                    Me._indexProdEditando = dtg_lancamento.CurrentRow.Index
                    Me._CodProdEditando = dtg_lancamento.CurrentRow.Cells(0).Value
                    Me.msk_data.Text = dtg_lancamento.CurrentRow.Cells(1).Value
                    Me.txt_codProd.Text = dtg_lancamento.CurrentRow.Cells(0).Value
                    Me.txt_nomeProd.Text = dtg_lancamento.CurrentRow.Cells(2).Value
                    Me.txt_quantidade.Text = dtg_lancamento.CurrentRow.Cells(3).Value
                    dtg_lancamento.CurrentRow.DefaultCellStyle.BackColor = Color.White

                End If

        End Select



    End Sub

    Private Sub Frm_RequMatPrima_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                If Me.dtg_lancamento.RowCount > 0 Then

                    If MessageBox.Show("Deseja realmente Sair? O Processo será Abortado!", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Me.Close()

                    End If
                Else
                    Me.Close()

                End If


        End Select



    End Sub

End Class