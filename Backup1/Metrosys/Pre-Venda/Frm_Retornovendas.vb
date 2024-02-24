Imports Npgsql
Imports System.Text
Imports System.Data
Imports System.Math

Public Class Frm_Retornovendas
    Private Const _valorZERO As Integer = 0
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private _idMp As Int32 = _valorZERO
    Private _numMapaAtual As String = "", _codProdutoRetorno As String = ""
    Private _vlrPedenciasPart As Double = _valorZERO
    Public _buscaForn As New Frm_BuscaPartR
    Public Shared _frmREf As New Frm_Retornovendas
    Dim _JaComitado As Boolean = False

    Public mbUf As String = "", mbCNPJ As String = ""
    Public _codPart As String = "", _nomePart As String = ""

    Private Sub Frm_Retornovendas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F2
                executaF2()

            Case Keys.F4
                executaF4()

            Case Keys.F7
                executaF7()

        End Select


    End Sub

    Private Sub txt_numPedido_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numPedido.KeyPress, txt_numMapa.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_numPedido_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numPedido.Leave

        If IsNumeric(txt_numPedido.Text) Then txt_numPedido.Text = String.Format("{0:D10}", Convert.ToInt32(txt_numPedido.Text))

    End Sub

    Private Sub txt_numMapa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numMapa.Leave

        If IsNumeric(txt_numMapa.Text) Then

            txt_numMapa.Text = String.Format("{0:D10}", Convert.ToInt32(txt_numMapa.Text))
            If trazMapaBD(txt_numMapa.Text) Then lbl_mensagem.Text = ""

        End If


    End Sub

    Private Sub Frm_Retornovendas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        msk_dtEntrega.Text = Format(Date.Now, "ddMMyyyy")

        If Not MdlUsuarioLogando._local.Equals("") Then
            Me.cbo_local.Items.Clear()
            Me.cbo_local.Refresh()
            Me.cbo_local.Items.Add(MdlUsuarioLogando._local.Substring(3, 2))
            Me.cbo_local.Refresh()
        End If


    End Sub

    Private Sub Frm_Retornovendas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub addItemsMapaGrid(ByVal codProd As String, ByVal nomeProd As String, _
                            ByVal qtdeProd As Double, ByVal vlrUnitProd As Double, _
                            ByVal vlrTotalItem As Double, ByVal undProd As String, _
                            ByVal pesoLiqProd As Double, ByVal pesoBrutoProd As Double, _
                            ByVal codBarra As String)

        Try
            Dim mlinha As String() = {codProd, nomeProd, Format(qtdeProd, "###,##0.00"), _
                                  Format(vlrUnitProd, "###,##0.00"), _
                                  Format(vlrTotalItem, "###,##0.00"), undProd, pesoLiqProd, _
                                  pesoBrutoProd, codBarra}
            'Adicionando Linha
            Me.dtg_mapa.Rows.Add(mlinha)
            Me.dtg_mapa.Refresh()

        Catch ex As Exception
            MsgBox("ERRO no procedimento ""AddItemsMapa"":: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        End Try


    End Sub

    Private Sub addItemsRetornoGrid(ByVal codPart As String, ByVal nomePart As String, _
                            ByVal cnpj_cpf As String, ByVal codProd As String, _
                            ByVal nomeProd As String, ByVal qtdeProd As Double, _
                            ByVal vlrUnitProd As Double, ByVal vlrTotalItem As Double)

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

        Dim mlinha As String() = {codPart, nomePart, cnpj_cpf, codProd, nomeProd, Format(qtdeProd, "###,##0.00"), _
                                  Format(vlrUnitProd, "###,##0.00"), Format(vlrTotalItem, "###,##0.00")}
        'Adicionando Linha
        Me.dtg_retornVendas.Rows.Add(mlinha)
        Me.dtg_retornVendas.Refresh()

        _clBD.subtraiQtdeMapa2ccr(conection, _numMapaAtual, codProd, qtdeProd)
        _clBD.alteraVlrTotalMapa2ccr(conection, _numMapaAtual, codProd)
        conection.ClearPool() : conection.Close() : conection = Nothing

        atualizaGridMapaBD(_numMapaAtual)


    End Sub

    Public Function trazMapaBD(ByVal numMapa As String) As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim cmdMapa As New NpgsqlCommand
        Dim sqlMapa As New StringBuilder
        Dim drMapa As NpgsqlDataReader
        Dim nomeCampo As String = ""

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("Deu ERRO ao Abrir Conexão para Trazer o Mapa:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        If oConnBDGENOV.State = ConnectionState.Open Then

            Try
                sqlMapa.Append("SELECT mcr_mpid, mcr_numero, mcr_codpr, mcr_descricao, mcr_und, ") '4
                sqlMapa.Append("mcr_qtde, mcr_valorunit, mcr_total, mcr_pesobruto, mcr_pesoliq, ") '9
                sqlMapa.Append("mcr_codbarra, mcr_local FROM " & MdlEmpresaUsu._esqEstab & ".mapa2ccr WHERE mcr_numero = @mcr_numero ")
                sqlMapa.Append("ORDER BY mcr_descricao ASC ")
                cmdMapa = New NpgsqlCommand(sqlMapa.ToString, oConnBDGENOV)
                cmdMapa.Parameters.Add("@mcr_numero", numMapa)
                drMapa = cmdMapa.ExecuteReader

                If drMapa.HasRows = False Then

                    lbl_mensagem.Text = "Mapa não existe !"
                    txt_numMapa.Text = _numMapaAtual
                    Return False

                Else

                    If dtg_mapa.Rows.Count > _valorZERO Then
                        If numMapa <> _numMapaAtual Then

                            If MessageBox.Show("O processo do Mapa atual será substituído! Deseja continuar?", "METROSYS", MessageBoxButtons.YesNo, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                                Return False

                            Else
                                dtg_retornVendas.Rows.Clear() : dtg_retornVendas.Refresh()
                                dtg_mapa.Rows.Clear() : dtg_mapa.Refresh()

                            End If

                        Else
                            Return False

                        End If
                    End If


                End If


                While drMapa.Read

                    If drMapa(5) > _valorZERO Then
                        _idMp = drMapa(0) : _numMapaAtual = drMapa(1).ToString

                        addItemsMapaGrid(drMapa(2).ToString, drMapa(3).ToString, drMapa(5), drMapa(6), _
                                         drMapa(7), drMapa(4).ToString, drMapa(9), drMapa(8), drMapa(10).ToString)

                    End If
                End While
                drMapa.Close() : oConnBDGENOV.ClearPool()

                cmdMapa.CommandText = ""
                sqlMapa.Remove(_valorZERO, sqlMapa.ToString.Length)

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return False
            End Try

        End If

        If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
        'Libera Objetos da Memória RAM...
        oConnBDGENOV = Nothing : cmdMapa = Nothing : sqlMapa = Nothing : drMapa = Nothing
        nomeCampo = Nothing



        Return True
    End Function

    Public Function atualizaGridMapaBD(ByVal numMapa As String) As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim cmdMapa As New NpgsqlCommand
        Dim sqlMapa As New StringBuilder
        Dim drMapa As NpgsqlDataReader
        Dim nomeCampo As String = ""

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        If oConnBDGENOV.State = ConnectionState.Open Then

            Try
                sqlMapa.Append("SELECT mcr_mpid, mcr_numero, mcr_codpr, mcr_descricao, mcr_und, ") '4
                sqlMapa.Append("mcr_qtde, mcr_valorunit, mcr_total, mcr_pesobruto, mcr_pesoliq, ") '9
                sqlMapa.Append("mcr_codbarra, mcr_local FROM " & MdlEmpresaUsu._esqEstab & ".mapa2ccr WHERE mcr_numero = @mcr_numero")
                cmdMapa = New NpgsqlCommand(sqlMapa.ToString, oConnBDGENOV)
                cmdMapa.Parameters.Add("@mcr_numero", numMapa)
                drMapa = cmdMapa.ExecuteReader

                If drMapa.HasRows Then dtg_mapa.Rows.Clear() : dtg_mapa.Refresh()

                While drMapa.Read
                    _idMp = drMapa(0) : _numMapaAtual = drMapa(1).ToString

                    addItemsMapaGrid(drMapa(2).ToString, drMapa(3).ToString, drMapa(5), drMapa(6), _
                                     drMapa(7), drMapa(4).ToString, drMapa(9), drMapa(8), drMapa(10).ToString)


                End While
                drMapa.Close() : oConnBDGENOV.ClearPool()

                cmdMapa.CommandText = ""
                sqlMapa.Remove(_valorZERO, sqlMapa.ToString.Length)

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return False

            End Try

        End If

        If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
        'Libera Objetos da Memória RAM...
        oConnBDGENOV = Nothing : cmdMapa = Nothing : sqlMapa = Nothing : drMapa = Nothing
        nomeCampo = Nothing



        Return True
    End Function

    Private Sub txt_numMapa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_numMapa.KeyDown

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            If IsNumeric(txt_numMapa.Text) Then

                txt_numMapa.Text = String.Format("{0:D10}", Convert.ToInt32(txt_numMapa.Text))
                If trazMapaBD(txt_numMapa.Text) Then lbl_mensagem.Text = ""

            End If
        End If

    End Sub

    Private Function verificaCamposCliente() As Boolean

        Dim mNaoDeuErro As Boolean = True
        lbl_mensagem.Text = ""

        If cbo_local.SelectedIndex < _valorZERO Then
            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe um Local para este Lançamento !"
            txt_codPart.Focus()
            Return mNaoDeuErro

        End If


        If _codPart.Equals("") Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe um Cliente !"
            txt_codPart.Focus()
            Return mNaoDeuErro

        ElseIf Not _codPart.Equals(txt_codPart.Text) Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Cliente não confere ! Busque novamente o Cliente, por favor !"
            txt_codPart.Focus()
            Return mNaoDeuErro

        End If

        If cbo_formPgto.SelectedIndex < _valorZERO Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe uma Forma de pagamento !"
            cbo_formPgto.Focus()
            Return mNaoDeuErro

        End If

        If cbo_especPgto.SelectedIndex < _valorZERO Then
            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe uma Espécie de pagamento !"
            cbo_especPgto.Focus()
            Return mNaoDeuErro

        End If

        If cbo_naturezaPgto.SelectedIndex < _valorZERO Then
            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe uma Natureza de pagamento !"
            cbo_naturezaPgto.Focus()
            Return mNaoDeuErro

        End If



        Return mNaoDeuErro
    End Function

    Private Function verificaCamposItem() As Boolean

        Dim mNaoDeuErro As Boolean = True
        lbl_mensagem.Text = ""

        'Se não for informado o nome ou a quantidade ou o valor unitario do Produto
        'é por que não foi informado um produto.
        If txt_nomeProd.Equals("") OrElse (CDbl(txt_qtdeProdMp.Text) = 0) OrElse _
        (CDbl(txt_vlrUnitProdMp.Text) = 0) Then

            mNaoDeuErro = False
            lbl_mensagem.Text = "Informe um Produto !"
            Return mNaoDeuErro

        End If

        If IsNumeric(txt_qtdeProdRetorno.Text) Then

            If CDbl(txt_qtdeProdRetorno.Text) <= _valorZERO Then

                mNaoDeuErro = False
                lbl_mensagem.Text = "Informe um valor para Quantidade !"
                txt_qtdeProdRetorno.Focus()
                Return mNaoDeuErro

            ElseIf CDbl(txt_qtdeProdRetorno.Text) > CDbl(txt_qtdeProdMp.Text) Then

                mNaoDeuErro = False
                lbl_mensagem.Text = "Quantidade Maior que a Disponível !"
                txt_qtdeProdRetorno.Focus()
                Return mNaoDeuErro

            End If

        Else

            mNaoDeuErro = False
            lbl_mensagem.Text = "Quantidade Informada inválida !"
            txt_qtdeProdRetorno.Focus()
            Return mNaoDeuErro

        End If

        'Verifica pelo Código, se Produto já existe no Grid...
        For Each row As DataGridViewRow In Me.dtg_retornVendas.Rows

            If Not row.IsNewRow Then
                If row.Cells(3).Value.Equals(_codProdutoRetorno) Then

                    mNaoDeuErro = False
                    lbl_mensagem.Text = "Produto já exite no Retorno !"
                    Return mNaoDeuErro

                End If
            End If

        Next



        Return mNaoDeuErro
    End Function

    Private Sub zeraValoresItem()

        txt_nomeProd.Text = "" : txt_vlrUnitProdMp.Text = "0,00" : txt_qtdeProdMp.Text = "0,00"
        txt_qtdeProdRetorno.Text = "0,00"


    End Sub

    Private Sub zeraValoresPart()

        txt_codPart.Text = "" : _codPart = "" : _nomePart = "" : _vlrPedenciasPart = _valorZERO
        grp_financeiro.Visible = False : txt_nomePart.Text = "" : cbo_formPgto.SelectedIndex = -1
        cbo_especPgto.SelectedIndex = -1 : cbo_naturezaPgto.SelectedIndex = -1


    End Sub

    Private Sub dtg_mapa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_mapa.Click

        Try
            _codProdutoRetorno = dtg_mapa.CurrentRow.Cells(0).Value
            txt_nomeProd.Text = dtg_mapa.CurrentRow.Cells(1).Value
            txt_qtdeProdMp.Text = dtg_mapa.CurrentRow.Cells(2).Value
            txt_vlrUnitProdMp.Text = dtg_mapa.CurrentRow.Cells(3).Value

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try


    End Sub

    Public Function trazFornecedor(ByVal codFornec As String) As Boolean

        Dim nomeCampo As String = "", nomeCampoCgc As String = "", nomeCampoCpf As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        Dim pesquisa As String = codFornec.ToUpper

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try


        Dim codigo, nome, cpf_cnpj, inscricao, UF As String
        codigo = "" : nome = "" : cpf_cnpj = "" : inscricao = "" : UF = ""

        Try
            SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc,p_uf FROM cadp001 WHERE ") ' 5
            SqlParticipante.Append("p_cod = '" & pesquisa & "' ORDER BY p_portad ASC")
            CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDGENOV)
            drParticipante = CmdParticipante.ExecuteReader

            If drParticipante.HasRows = False Then
                Return False
            Else
                While drParticipante.Read
                    codigo = drParticipante(_valorZERO).ToString
                    nome = drParticipante(1).ToString
                    If Not drParticipante(2).ToString.Equals("") Then 'se tiver CNPJ...
                        cpf_cnpj = drParticipante(2).ToString
                    Else
                        cpf_cnpj = drParticipante(3).ToString
                    End If
                    inscricao = drParticipante(4).ToString : UF = drParticipante(5).ToString

                End While
                drParticipante.Close()
                _codPart = codigo : Me.txt_nomePart.Text = nome
                _nomePart = nome : Me.mbCNPJ = cpf_cnpj : Me.mbUf = UF

            End If

        Catch ex As Exception
        End Try

        codigo = Nothing : nome = Nothing : cpf_cnpj = Nothing : inscricao = Nothing
        UF = Nothing

        oConnBDGENOV.ClearPool() : CmdParticipante.CommandText = ""
        SqlParticipante.Remove(_valorZERO, SqlParticipante.ToString.Length)
        If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()

        'Libera Objetos da Memória RAM...
        nomeCampo = Nothing : nomeCampoCgc = Nothing : nomeCampoCpf = Nothing : oConnBDGENOV = Nothing
        CmdParticipante = Nothing : SqlParticipante = Nothing : drParticipante = Nothing



        Return True
    End Function

    'Função que traz o valor das pendências...
    Private Sub txt_codPart_KeyDownExtracted()
        Me.txt_nomePart.Focus()
        Me.txt_nomePart.SelectAll()

        Try
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            conection.Open()
            _vlrPedenciasPart = _clBD.vlrPendenciasPartFatd001(conection, _codPart)

            If _vlrPedenciasPart <= _valorZERO Then
                Me.txt_vlrFinanceiro.Text = Format(_vlrPedenciasPart, "###,##0.00")
                Me.grp_financeiro.Visible = False : Me.txt_vlrFinanceiro.Visible = False

            End If

            conection.ClearPool() : conection.Close() : conection = Nothing
        Catch ex As Exception
            MsgBox("Erro na de Trazer VlrPendências:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSY")
        End Try



    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown

        If Not Me.txt_codPart.Text.Equals("") Then

            If (Me.txt_codPart.TextLength > 5) AndAlso (e.KeyCode = Keys.Enter) Then 'Se retornar nada

                If trazFornecedor(Me.txt_codPart.Text) Then

                    'Função que traz o valor das pendências...
                    txt_codPart_KeyDownExtracted()

                End If
            End If
        End If

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

            If Me.txt_codPart.Text.Equals("") Then
                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    _frmREf = Me
                    _buscaForn.ShowDialog(Me)
                    If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus()

                    'Função que traz o valor das pendências...
                    txt_codPart_KeyDownExtracted()

                Catch ex As Exception
                End Try

            End If
        End If



    End Sub

    Private Sub cbo_formPgto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_formPgto.GotFocus

        If Not (Me.cbo_formPgto.DroppedDown) Then Me.cbo_formPgto.DroppedDown = True

    End Sub

    Private Sub cbo_especPgto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_especPgto.GotFocus

        If Not (Me.cbo_especPgto.DroppedDown) Then Me.cbo_especPgto.DroppedDown = True

    End Sub

    Private Sub cbo_naturezaPgto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_naturezaPgto.GotFocus

        If Not (Me.cbo_naturezaPgto.DroppedDown) Then Me.cbo_naturezaPgto.DroppedDown = True

    End Sub

    Private Sub executaF2()

        If verificaCamposCliente() AndAlso verificaCamposItem() Then

            Try
                Dim mCodProd, mNomeProd As String
                Dim mQtdeProd As Double = _valorZERO
                Dim mVlrUnitProd As Double = _valorZERO
                Dim mVlrTotalItem As Double = _valorZERO

                mCodProd = dtg_mapa.CurrentRow.Cells(0).Value
                mNomeProd = dtg_mapa.CurrentRow.Cells(1).Value
                mVlrUnitProd = CDbl(txt_vlrUnitProdMp.Text)
                mQtdeProd = CDbl(txt_qtdeProdRetorno.Text)
                mVlrTotalItem = Round((CDbl(txt_vlrUnitProdMp.Text) * CDbl(txt_qtdeProdRetorno.Text)), 2)

                addItemsRetornoGrid(txt_codPart.Text, txt_nomePart.Text, mbCNPJ, mCodProd, mNomeProd, _
                                    mQtdeProd, mVlrUnitProd, mVlrTotalItem)

                Me.txt_vlrTotalRetorno.Text = Format(somaVlrTotalItensGridRetorno, "###,##0.00")

                If txt_numPedido.Text.Equals("") Then

                    Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    If conection.State = ConnectionState.Closed Then conection.Open()
                    Me.txt_numPedido.Text = String.Format("{0:D10}", _clBD.trazProxNumPedidoMp(MdlEmpresaUsu._codigo, conection))
                    conection.Close()
                    conection = Nothing

                End If

                'Libera Objetos da Memória RAM...
                mCodProd = Nothing : mNomeProd = Nothing : mQtdeProd = Nothing : mVlrUnitProd = Nothing
                mVlrTotalItem = Nothing

                zeraValoresItem()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try

        End If



    End Sub

    Private Sub Btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_novo.Click

        executaF2()

    End Sub

    Private Function somaVlrTotalItensGridRetorno() As Double

        Dim mVlrTotalItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_retornVendas.Rows

            If Not row.IsNewRow Then mVlrTotalItens += row.Cells(7).Value

        Next


        mVlrTotalItens = Round(mVlrTotalItens, 2)
        Return mVlrTotalItens
    End Function

    Private Sub txt_qtdeProdVend_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtdeProdRetorno.Leave

        lbl_mensagem.Text = ""
        If Me.txt_qtdeProdRetorno.Text.Equals("") Then Me.txt_qtdeProdRetorno.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_qtdeProdRetorno.Text) Then

            If CDec(Me.txt_qtdeProdRetorno.Text) <= _valorZERO Then

                lbl_mensagem.Text = "Quantidade deve ser maior que ZERO !"
                Return

            End If
            Me.txt_qtdeProdRetorno.Text = Format(CDec(Me.txt_qtdeProdRetorno.Text), "###,##0.00")

        End If


    End Sub

    Private Sub txt_qtdeProdVend_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtdeProdRetorno.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_numPedido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numPedido.TextChanged

        If Trim(Me.txt_numPedido.Text) <> "" Then

            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            conection.Open()
            _clBD.updateGenp001NumPedidoMp(conection, Convert.ToInt32(Trim(Me.txt_numPedido.Text)), MdlEmpresaUsu._codigo)
            conection.ClearPool() : conection.Close() : conection = Nothing

        End If


    End Sub

    Private Sub DeleteItemGridR()

        Try
            If Not Me.dtg_retornVendas.CurrentRow.IsNewRow Then

                Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Try
                    conection.Open()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return
                End Try

                'Remove Linha
                Dim codigoProduto As String = dtg_retornVendas.CurrentRow.Cells(3).Value
                Dim qtdeProduto As Double = dtg_retornVendas.CurrentRow.Cells(5).Value

                Me.dtg_retornVendas.Rows.Remove(Me.dtg_retornVendas.CurrentRow)
                Me.dtg_retornVendas.Refresh()

                _clBD.somaQtdeMapa2ccr(conection, _numMapaAtual, codigoProduto, qtdeProduto)
                _clBD.alteraVlrTotalMapa2ccr(conection, _numMapaAtual, codigoProduto)
                conection.ClearPool() : conection.Close() : conection = Nothing

                atualizaGridMapaBD(_numMapaAtual)

                codigoProduto = Nothing : qtdeProduto = Nothing
            End If

        Catch ex As Exception
            MsgBox("Deu ERRO ao Deletar este Item " & ex.Message, MsgBoxStyle.Exclamation)
        End Try



    End Sub

    Private Sub executaF4()

        If Me.dtg_retornVendas.Rows.Count > _valorZERO Then

            If MessageBox.Show("Deseja realmente Deletar esse Item?", "METROSYS", MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Me.DeleteItemGridR()
                Me.txt_vlrTotalRetorno.Text = Format(somaVlrTotalItensGridRetorno, "###,##0.00")
                zeraValoresItem()

            End If
        End If



    End Sub

    Private Sub Btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_excluir.Click

        executaF4()

    End Sub

    Private Sub inclueRetornoMpRegistro(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim numPedido As String = Me.txt_numPedido.Text
        Dim numMapa As String = Me.txt_numMapa.Text, dtEntrega As Date = CDate(Me.msk_dtEntrega.Text)
        Dim codPart As String = Me.txt_codPart.Text
        Dim formaPgto As String = cbo_formPgto.Text.Substring(0, 2)
        Dim especPgto As String = cbo_especPgto.Text.Substring(0, 2)
        Dim naturezaPgto As String = cbo_naturezaPgto.Text.Substring(0, 2)
        Dim vlrTotalRetornoMp As Double = CDbl(Me.txt_vlrTotalRetorno.Text)
        Dim loja As String = cbo_local.SelectedItem

        _clBD.incRetorno1pp(conexao, transacao, numPedido, numMapa, dtEntrega, codPart, _
                            formaPgto, especPgto, naturezaPgto, vlrTotalRetornoMp, loja)

        'Libera Objetos da Memória RAM...
        numPedido = Nothing : numMapa = Nothing : dtEntrega = Nothing : codPart = Nothing : loja = Nothing
        formaPgto = Nothing : especPgto = Nothing : naturezaPgto = Nothing : vlrTotalRetornoMp = Nothing



    End Sub

    Private Sub inclueRetornoMpItens(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim rtId As Int32 = _valorZERO, numPedido As String = Me.txt_numPedido.Text
        Dim codPart As String = "", codProd As String = "", nomeProd As String = ""
        Dim qtdeProd As Double = _valorZERO, vlrUnitProd As Double = _valorZERO
        Dim vlrTotalProd As Double = _valorZERO
        Dim loja As String = cbo_local.SelectedItem

        rtId = _clBD.trazIdRetorno1pp(conexao, numPedido)
        For Each row As DataGridViewRow In Me.dtg_retornVendas.Rows
            If Not row.IsNewRow Then

                codPart = row.Cells(0).Value
                codProd = row.Cells(3).Value
                nomeProd = row.Cells(4).Value
                qtdeProd = row.Cells(5).Value
                vlrUnitProd = row.Cells(6).Value
                vlrTotalProd = row.Cells(7).Value

                _clBD.incRetorno2cc(conexao, transacao, rtId, numPedido, codPart, codProd, nomeProd, _
                                    qtdeProd, vlrUnitProd, vlrTotalProd, loja)

            End If
        Next

        'Libera Objetos da Memória RAM...
        rtId = Nothing : numPedido = Nothing : codPart = Nothing : codProd = Nothing : loja = Nothing
        nomeProd = Nothing : qtdeProd = Nothing : vlrUnitProd = Nothing : vlrTotalProd = Nothing



    End Sub

    Private Sub financeiro(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Select Case cbo_formPgto.SelectedIndex
            Case 1 ' A prazo

                'Se a Natureza for Venda...
                If cbo_naturezaPgto.SelectedIndex = 0 Then

                    If MessageBox.Show("Deseja baixar AUTOMATICAMENTE no financeiro?", "METROSYS", MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        'Se o Participante tiver Pendências: então baixa todas as pendência (Situação Liquidada) e 
                        'depois inclui a nova pendência agregando o valor das antigas. 
                        'Senão: inclui a nova pendência.
                        If _vlrPedenciasPart > _valorZERO Then

                            _clBD.atualTodasSitPartFatd001(conexao, transacao, _codPart, "L", CDate(Me.msk_dtEntrega.Text))
                            incFinanceiro(conexao, transacao)

                        Else
                            incFinanceiro(conexao, transacao)
                        End If

                    Else
                        incFinanceiro(conexao, transacao) : transacao.Commit() : _JaComitado = True
                        _frmREf = Me
                        Dim mBaixaManualRMp As New Frm_BaixaFinancRMp
                        mBaixaManualRMp.ShowDialog()
                        mBaixaManualRMp = Nothing

                    End If

                End If

        End Select



    End Sub

    Private Sub incFinanceiro(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim f_geno As String = "", f_portad As String = "", f_tipo As String = ""
        Dim f_nfat As String = "", f_nfisc As String = "", f_serie As String = ""
        Dim f_txdesc As Double = _valorZERO, f_duplic As String = "", f_emiss As Date
        Dim f_vencto As Date, f_valor As Double, f_cartei As String = ""
        Dim f_juros As Double, f_desc As Double
        Dim f_banco As Double, f_hist As String = "", f_hvenc As String = ""
        Dim f_protest As Double, f_outros As Double, f_codi1 As String = ""
        Dim f_codi2 As String = "", f_codi3 As String = "", f_sit As String = ""
        Dim f_stat As Boolean, f_loja As String = ""
        Dim f_ctactb As String = "", f_ctareduz As String = "", f_nnumero As String = ""
        Dim f_imp As String = "", f_mtransm As String = ""

        f_portad = _codPart
        f_tipo = _clFuncoes.fatd001_ftipoRetornMp(cbo_especPgto.SelectedItem.ToString.Substring(0, 2))
        f_nfat = String.Format("{0:D9}", Convert.ToInt32(txt_numPedido.Text))
        f_duplic = f_nfat & "A"
        f_emiss = CDate(msk_dtEntrega.Text)
        f_vencto = CDate(Format(DateSerial(f_emiss.Year, f_emiss.Month, f_emiss.Day + 30), "dd/MM/yyyy"))

        f_valor = Round(_vlrPedenciasPart + CDbl(txt_vlrTotalRetorno.Text), 2)

        f_cartei = "00"
        f_juros = _valorZERO : f_desc = _valorZERO : f_banco = _valorZERO

        f_hist = "" : f_hvenc = ""
        f_protest = _valorZERO : f_outros = _valorZERO
        f_codi1 = "" : f_codi2 = "" : f_codi3 = ""
        f_sit = "N"
        f_stat = False
        f_loja = cbo_local.SelectedItem
        f_ctactb = ""
        f_geno = "G00" & cbo_local.SelectedItem
        f_ctareduz = "" : f_nnumero = "" : f_imp = "" : f_mtransm = ""

        _clBD.incFatd001RetornoMp(conexao, transacao, f_geno, f_portad, f_tipo, f_nfat, f_nfisc, f_serie, _
                                  f_txdesc, f_duplic, f_emiss, f_vencto, f_valor, f_cartei, _
                                  f_juros, f_desc, f_banco, f_hist, f_hvenc, f_protest, f_outros, _
                                  f_codi1, f_codi2, f_codi3, f_sit, f_stat, f_loja, f_ctactb, _
                                  f_ctareduz, f_nnumero, f_imp, f_mtransm)


        'Libera Objetos da Memória RAM...
        f_geno = Nothing : f_portad = Nothing : f_tipo = Nothing : f_nfat = Nothing
        f_nfisc = Nothing : f_serie = Nothing : f_txdesc = Nothing : f_duplic = Nothing
        f_emiss = Nothing : f_vencto = Nothing : f_valor = Nothing : f_cartei = Nothing
        f_juros = Nothing : f_desc = Nothing : f_banco = Nothing : f_hist = Nothing
        f_hvenc = Nothing : f_protest = Nothing : f_outros = Nothing : f_codi1 = Nothing
        f_codi2 = Nothing : f_codi3 = Nothing : f_sit = Nothing : f_stat = Nothing
        f_loja = Nothing : f_ctactb = Nothing : f_ctareduz = Nothing : f_nnumero = Nothing
        f_imp = Nothing : f_mtransm = Nothing



    End Sub

    Private Function inclueRetornoMp() As Boolean

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim tudoOK As Boolean = True

        Try
            conexao.Open()

            Try
                transacao = conexao.BeginTransaction

                inclueRetornoMpRegistro(conexao, transacao)
                inclueRetornoMpItens(conexao, transacao)
                financeiro(conexao, transacao)

                If _JaComitado = False Then transacao.Commit()
                conexao.ClearAllPools() : _JaComitado = False
            Catch ex As Exception
                Try
                    transacao.Rollback()
                    tudoOK = False
                Catch ex2 As Exception
                    tudoOK = False

                End Try
            End Try

        Catch ex As Exception
            tudoOK = False
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)

        Finally

            If conexao.State = ConnectionState.Open Then conexao.Close()
            conexao = Nothing : transacao = Nothing
        End Try



        Return tudoOK
    End Function

    Private Function inclueRMpdevolucao() As Boolean

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim tudoOK As Boolean = True

        Try
            conexao.Open()

            Try
                transacao = conexao.BeginTransaction

                devolveEstoque(conexao, transacao)
                inclueRetornoMpRegistro(conexao, transacao)
                inclueRetornoMpItens(conexao, transacao)

                transacao.Commit() : conexao.ClearAllPools()


            Catch ex As Exception
                Try
                    transacao.Rollback()
                    tudoOK = False
                Catch ex2 As Exception
                    tudoOK = False

                End Try
            End Try

        Catch ex As Exception
            tudoOK = False
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)

        Finally

            If conexao.State = ConnectionState.Open Then conexao.Close()
            conexao = Nothing : transacao = Nothing
        End Try



        Return tudoOK
    End Function

    Private Function devolveEstoque(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction) As Boolean

        Dim codigoProduto As String = ""
        Dim qtdeProduto As Double = _valorZERO

        For Each row As DataGridViewRow In Me.dtg_retornVendas.Rows

            If Not row.IsNewRow Then

                codigoProduto = row.Cells(3).Value : qtdeProduto = row.Cells(5).Value

                _clBD.somaQtdFiscProdEstloja(codigoProduto, cbo_local.SelectedItem, qtdeProduto, conexao, transacao)
                _clBD.somaQtdeProdEstloja(codigoProduto, cbo_local.SelectedItem, qtdeProduto, conexao, transacao)

            End If
        Next
        codigoProduto = Nothing = qtdeProduto = Nothing



        Return True
    End Function

    Private Sub executaF7()

        'Se tiver algum lançamento no Drig de Retorno de Vendas, verifica se os campos do cliente
        'estão corretos...
        If dtg_retornVendas.Rows.Count > _valorZERO Then

            If verificaCamposCliente() Then

                If MessageBox.Show("Deseja realmente Finalizar esse Pedido?", "METROSYS", MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    'Se a Natureza for Devolucao...
                    If Me.cbo_naturezaPgto.SelectedIndex = 2 Then


                        If inclueRMpdevolucao() Then

                            MsgBox("Retorno Gravado com Sucesso", MsgBoxStyle.Exclamation)
                            txt_numPedido.Text = "" : dtg_mapa.Rows.Clear() : dtg_mapa.Refresh()
                            zeraValoresPart() : zeraValoresItem() : dtg_retornVendas.Rows.Clear()
                            dtg_retornVendas.Refresh() : txt_numPedido.Text = "" : txt_numPedido.Focus()
                            Me.txt_vlrTotalRetorno.Text = Format(somaVlrTotalItensGridRetorno, "###,##0.00")

                        End If

                    Else


                        If inclueRetornoMp() Then

                            MsgBox("Retorno Gravado com Sucesso", MsgBoxStyle.Exclamation)
                            txt_numPedido.Text = "" : dtg_mapa.Rows.Clear() : dtg_mapa.Refresh()
                            zeraValoresPart() : zeraValoresItem() : dtg_retornVendas.Rows.Clear()
                            dtg_retornVendas.Refresh() : txt_numPedido.Text = "" : txt_numPedido.Focus()
                            Me.txt_vlrTotalRetorno.Text = Format(somaVlrTotalItensGridRetorno, "###,##0.00")

                        End If
                    End If

                End If
            End If
        End If



    End Sub

    Private Sub btn_finalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalizar.Click

        executaF7()

    End Sub

    Private Sub msk_dtEntrega_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles msk_dtEntrega.GotFocus

        msk_dtEntrega.SelectAll()

    End Sub

    Private Sub cbo_naturezaPgto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_naturezaPgto.SelectedIndexChanged

        Select Case Me.cbo_naturezaPgto.SelectedIndex
            Case 0 'Se a natureza for Venda entao verifica se o Participante tem pendências ou não

                If _vlrPedenciasPart > _valorZERO Then

                    Me.txt_vlrFinanceiro.Text = Format(_vlrPedenciasPart, "###,##0.00")
                    Me.grp_financeiro.Visible = True : Me.txt_vlrFinanceiro.Visible = True

                Else

                    Me.txt_vlrFinanceiro.Text = Format(_valorZERO, "###,##0.00")
                    Me.grp_financeiro.Visible = False : Me.txt_vlrFinanceiro.Visible = False
                End If

            Case 1
                Me.txt_vlrFinanceiro.Text = Format(_valorZERO, "###,##0.00")
                Me.grp_financeiro.Visible = False : Me.txt_vlrFinanceiro.Visible = False

        End Select


    End Sub

    Private Sub cbo_local_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_local.GotFocus

        If Not (Me.cbo_local.DroppedDown) Then Me.cbo_local.DroppedDown = True

    End Sub

    Private Sub addTodosItensCboNatureza()

        cbo_naturezaPgto.Items.Add("01 - Venda") : cbo_naturezaPgto.Items.Add("02 - Troca")
        cbo_naturezaPgto.Items.Add("03 - Devolucao") : cbo_naturezaPgto.Items.Add("04 - Outros")
        cbo_naturezaPgto.Refresh()


    End Sub

    Private Sub cbo_formPgto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_formPgto.SelectedIndexChanged

        lbl_mensagem.Text = ""
        Select Case cbo_formPgto.SelectedIndex
            Case 2 'Caso a Forma de Pagamento for Outros, Set a Especie e talvez Adiciona a Natureza "TROCA"
                cbo_especPgto.SelectedIndex = 5

                If cbo_naturezaPgto.Items.Count < 4 Then

                    cbo_naturezaPgto.Items.Clear() : addTodosItensCboNatureza()

                End If

            Case 1 'Caso a Forma de Pagamento for A Prazo, Set a Especie e talvez Remove a Natureza "TROCA"
                cbo_especPgto.SelectedIndex = -1

                If cbo_naturezaPgto.Items.Count = 4 Then '(cbo_naturezaPgto.Items.Count > 2) AndAlso (

                    cbo_naturezaPgto.Items.RemoveAt(1) : cbo_naturezaPgto.Items.RemoveAt(1)
                    cbo_naturezaPgto.SelectedIndex = -1

                ElseIf cbo_naturezaPgto.Items.Count = 3 Then

                    cbo_naturezaPgto.Items.RemoveAt(1)

                End If

                If cbo_especPgto.SelectedIndex = _valorZERO Then lbl_mensagem.Text = "Dinheiro não pode quando a Forma de Pagamento for A Prazo !"


            Case Else 'Se for A Vista...

                cbo_especPgto.SelectedIndex = -1
                cbo_naturezaPgto.Items.Clear() : addTodosItensCboNatureza()
                cbo_naturezaPgto.Items.RemoveAt(2) : cbo_naturezaPgto.Refresh()


        End Select



    End Sub

    Private Sub devolveQtdFiscEstloja01()

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Dim codigoProduto As String = ""
        Dim qtdeProduto As Double = _valorZERO

        conection.Open()
        transacao = conection.BeginTransaction

        For Each row As DataGridViewRow In Me.dtg_retornVendas.Rows
            If Not row.IsNewRow Then
                codigoProduto = row.Cells(3).Value
                qtdeProduto = row.Cells(5).Value

                _clBD.somaQtdFiscProdEstloja(codigoProduto, cbo_local.SelectedItem, qtdeProduto, conection, transacao)
                _clBD.somaQtdeMapa2ccr(conection, _numMapaAtual, codigoProduto, qtdeProduto)
                _clBD.alteraVlrTotalMapa2ccr(conection, _numMapaAtual, codigoProduto)

            End If
        Next

        transacao.Commit() : conection.ClearPool() : conection.Close()
        conection = Nothing : transacao = Nothing : codigoProduto = Nothing : qtdeProduto = Nothing


    End Sub

    Private Sub Frm_Retornovendas_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If dtg_retornVendas.Rows.Count > _valorZERO Then

            If MessageBox.Show("Deseja realmente Sair?", "METROSYS", MessageBoxButtons.YesNo, _
               MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Try
                    devolveQtdFiscEstloja01()

                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                    e.Cancel = True

                End Try

            Else
                e.Cancel = True

            End If
        End If



    End Sub

    Private Sub cbo_especPgto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_especPgto.SelectedIndexChanged

        Select Case cbo_especPgto.SelectedIndex
            Case 0
                If cbo_formPgto.SelectedIndex = 1 Then lbl_mensagem.Text = "Dinheiro não pode quando a Forma de Pagamento for A Prazo !"
            Case Else
                lbl_mensagem.Text = ""
        End Select


    End Sub

    Private Sub cbo_formPgto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_formPgto.Leave

        If (cbo_especPgto.SelectedIndex = _valorZERO) AndAlso (cbo_formPgto.SelectedIndex = 1) Then
            MsgBox("Dinheiro não pode quando a Forma de Pagamento for A Prazo ", MsgBoxStyle.Exclamation)
            cbo_formPgto.Focus()

        End If

    End Sub

    Private Sub cbo_especPgto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_especPgto.Leave

        If (cbo_especPgto.SelectedIndex = _valorZERO) AndAlso (cbo_formPgto.SelectedIndex = 1) Then
            MsgBox("Dinheiro não pode quando a Forma de Pagamento for A Prazo ", MsgBoxStyle.Exclamation)
            cbo_especPgto.Focus()

        End If

    End Sub

    Private Sub cbo_local_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_local.Leave

        lbl_mensagem.Text = ""
        If Me.cbo_local.SelectedIndex < _valorZERO Then

            lbl_mensagem.Text = "Informe o local da entrada do Retorno !"
            Return

        End If

    End Sub

End Class