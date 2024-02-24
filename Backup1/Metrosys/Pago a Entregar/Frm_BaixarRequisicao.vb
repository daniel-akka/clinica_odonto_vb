Imports Npgsql
Imports System.IO
Imports System.Math
Imports System.Text
Imports System.DateTime
Imports System.Drawing.Printing

Public Class Frm_baixarrequisicao

    Private Const _valorZERO As Integer = 0
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private _idReq As Int64 = _valorZERO
    Private _codProdProcesso As String = ""
    Public _buscaForn As New Frm_BuscaForn
    Public Shared _frmREf As New Frm_baixarrequisicao
    Dim _codPartProcesso As String = ""
    Dim _numRequisicao As Int64 = _valorZERO

    'Atributos do Participante...
    Public mbUf As String = "", mbCNPJ As String = ""
    Public _codPart As String = "", _nomePart As String = ""

    Dim _loja As String = MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2)

    'objetos para impressão...
    Dim _mConsulta As New StringBuilder
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


    Private Sub Frm_baixarrequisicao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                executaF2()
            Case Keys.F4
                executaF4()
            Case Keys.F6
                'executaF6()
            Case Keys.F7
                executaF7()
        End Select


    End Sub

    Private Sub Frm_baixarrequisicao_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_baixarrequisicao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.txt_numRequisicao.Text = "000000001"
        Me.txt_numRequisicao.Focus()

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos.BeginPrint, AddressOf InicializaRelatorio

    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown

        If Me.txt_codPart.ReadOnly Then Return

        If Not Me.txt_codPart.Text.Equals("") Then

            If (Me.txt_codPart.TextLength > 5) AndAlso (e.KeyCode = Keys.Enter) Then 'Se retornar nada

                If trazFornecedor(Me.txt_codPart.Text) Then

                    trazProcessoPart(Me.txt_codPart.Text)
                End If
                Me.txt_nomePart.Focus()
                Me.txt_nomePart.SelectAll()
            End If
        End If

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

            If Me.txt_codPart.Text.Equals("") Then
                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    _frmREf = Me
                    _buscaForn.set_frmRef(Me)
                    _buscaForn.ShowDialog(Me)
                    If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus()

                    If (_codPart.Equals("") = False) AndAlso (_codPart.Equals(Me.txt_codPart.Text) = False) Then

                        If MessageBox.Show("O Processo do Cliente atual será substituído por o do novo Cliente! Deseja continuar?", "METROSYS", MessageBoxButtons.YesNo, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                            trazProcessoPart(Me.txt_codPart.Text)
                            _codPart = Me.txt_codPart.Text
                        Else
                            trazFornecedor(_codPart)
                        End If

                    ElseIf _codPart.Equals("") Then

                        trazProcessoPart(Me.txt_codPart.Text)
                        _codPart = Me.txt_codPart.Text
                    End If

                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()

                Catch ex As Exception
                End Try

            End If

        End If


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

    Public Function trazProcessoPart(ByVal codPart As String) As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("Deu ERRO ao Abrir Conexão para Trazer o Processo do Cliente:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try


        Try
            sql.Append("SELECT gr_id, gr_codpr, gr_descri, gr_saldo FROM " & MdlEmpresaUsu._esqEstab & ".estm400 ") '4 *, e.e_qtde
            sql.Append("WHERE gr_cdport = @codpart ORDER BY gr_codpr ASC ") 'LEFT JOIN estloja01 e ON e.e_codig = gr_codpr AND e.e_loja = @loja
            cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
            cmd.Parameters.Add("@codpart", Me.txt_codPart.Text)
            cmd.Parameters.Add("@loja", _loja)
            dr = cmd.ExecuteReader

            If dr.HasRows = False Then

                MsgBox("Não existe Processo(s) para este Cliente", MsgBoxStyle.Exclamation)
                dtg_processo.Rows.Clear() : dtg_processo.Refresh()
                Return False

            Else

                dtg_processo.Rows.Clear() : dtg_processo.Refresh()
                While dr.Read

                    If CDbl(dr(3)) > _valorZERO Then

                        dtg_processo.Rows.Add(dr(1).ToString, dr(2).ToString, Format(CDbl(dr(3)), "###,##0.00"))
                    End If
                End While

            End If

            oConnBDGENOV.ClearPool()
            cmd.CommandText = "" : sql.Remove(_valorZERO, sql.ToString.Length)

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False
        End Try


        If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
        'Libera Objetos da Memória RAM...
        oConnBDGENOV = Nothing : cmd = Nothing : sql = Nothing : dr = Nothing


        Return True
    End Function

    Private Sub dtg_processo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_processo.Click

        Try
            _codProdProcesso = dtg_processo.CurrentRow.Cells(0).Value.ToString
            txt_nomeProd.Text = dtg_processo.CurrentRow.Cells(1).Value.ToString
            txt_qtdeProdProcesso.Text = dtg_processo.CurrentRow.Cells(2).Value.ToString

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub executaF2()

        If verificaCamposCliente() AndAlso verificaCamposItem() Then

            Try
                Dim mCodProd, mNomeProd As String
                Dim mQtdeProd As Double = _valorZERO
                Dim mQtdeProdAux As Double
                Dim mQtdeEtoque As Double

                mCodProd = dtg_processo.CurrentRow.Cells(0).Value
                mNomeProd = dtg_processo.CurrentRow.Cells(1).Value
                mQtdeProd = CDbl(txt_qtdeProdRequisicao.Text)

                Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Dim transacao As NpgsqlTransaction
                Try
                    conexao.Open()
                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return
                End Try

                transacao = conexao.BeginTransaction

                If txt_numRequisicao.Text.Equals("") Then

                    'Numero da requisicao...
                    _numRequisicao = _clBD.trazNumAtualReqProc(conexao, transacao, MdlEmpresaUsu._codigo)
                    _clBD.atualizaNumAtualReqProc(conexao, transacao, MdlEmpresaUsu._codigo, (_numRequisicao + 1))
                    mQtdeProdAux = _clBD.trazQtdeEstm400(conexao, transacao, _codPart, mCodProd)
                    mQtdeEtoque = _clBD.pegaQtdeEstoque(mCodProd, _loja, conexao)

                    If mQtdeProd > mQtdeProdAux Then

                        transacao.Rollback() : conexao.ClearAllPools() : conexao.Close() : conexao = Nothing
                        MsgBox("QUANTIDADE não disponível para o produto """ & mCodProd & """ devido a uma outra requisicao já ter USADO")
                    Else
                        transacao.Commit() : conexao.ClearAllPools() : conexao.Close() : conexao = Nothing
                    End If

                    If mQtdeEtoque < mQtdeProd Then MsgBox("QUANTIDADE no Indisponível !")
                    Me.txt_numRequisicao.Text = String.Format("{0:D9}", _numRequisicao)
                Else


                    mQtdeProdAux = _clBD.trazQtdeEstm400(conexao, transacao, _codPart, mCodProd)
                    mQtdeEtoque = _clBD.pegaQtdeEstoque(mCodProd, _loja, conexao)

                    If mQtdeProd > mQtdeProdAux Then

                        conexao.ClearAllPools() : conexao.Close() : conexao = Nothing
                        MsgBox("QUANTIDADE não disponível para o produto """ & mCodProd & """ devido a uma outra requisicao já ter USADO")
                    Else
                        conexao.ClearAllPools() : conexao.Close() : conexao = Nothing
                    End If

                    If mQtdeEtoque < mQtdeProd Then MsgBox("QUANTIDADE no Indisponível !")

                End If

                addItemsRequisicaoGrid(mCodProd, mNomeProd, mQtdeProd)

                'Libera Objetos da Memória RAM...
                mCodProd = Nothing : mNomeProd = Nothing : mQtdeProd = Nothing

                zeraValoresItem()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try

            'trazProcessoPart(_codPart)
        End If



    End Sub

    Private Function verificaCamposCliente() As Boolean

        Dim mNaoDeuErro As Boolean = True

        If _codPart.Equals("") Then

            mNaoDeuErro = False
            MsgBox("Informe um Cliente !")
            txt_codPart.Focus()
            Return mNaoDeuErro

        ElseIf Not _codPart.Equals(txt_codPart.Text) Then

            mNaoDeuErro = False
            MsgBox("Cliente não confere ! Busque novamente o Cliente, por favor !")
            txt_codPart.Focus()
            Return mNaoDeuErro

        End If



        Return mNaoDeuErro
    End Function

    Private Function verificaCamposItem() As Boolean

        Dim mNaoDeuErro As Boolean = True

        'Se não for informado o nome ou a quantidade ou o valor unitario do Produto
        'é por que não foi informado um produto.
        If txt_nomeProd.Equals("") OrElse (CDbl(txt_qtdeProdProcesso.Text) <= 0) Then

            mNaoDeuErro = False
            MsgBox("Informe um Produto !")
            Return mNaoDeuErro

        End If

        If IsNumeric(txt_qtdeProdRequisicao.Text) Then

            If CDbl(txt_qtdeProdRequisicao.Text) <= _valorZERO Then

                mNaoDeuErro = False
                MsgBox("Informe um valor para Quantidade !")
                txt_qtdeProdRequisicao.Focus()
                Return mNaoDeuErro

            ElseIf CDbl(txt_qtdeProdRequisicao.Text) > CDbl(txt_qtdeProdProcesso.Text) Then

                mNaoDeuErro = False
                MsgBox("Quantidade Maior que a Disponível = """ & txt_qtdeProdProcesso.Text & """ !")
                txt_qtdeProdRequisicao.Focus()
                Return mNaoDeuErro

            End If

        Else

            mNaoDeuErro = False
            MsgBox("Quantidade Informada inválida !")
            txt_qtdeProdRequisicao.Focus()
            Return mNaoDeuErro

        End If

        'Verifica pelo Código, se Produto já existe no Grid...
        For Each row As DataGridViewRow In Me.dtg_requisicao.Rows

            If Not row.IsNewRow Then
                If row.Cells(0).Value.Equals(_codProdProcesso) Then

                    mNaoDeuErro = False
                    MsgBox("Produto já exite na Requisicao !")
                    Return mNaoDeuErro

                End If
            End If

        Next



        Return mNaoDeuErro
    End Function

    Private Sub zeraValoresItem()

        txt_nomeProd.Text = "" : txt_qtdeProdProcesso.Text = "0,00" : txt_qtdeProdRequisicao.Text = "0,00"

    End Sub

    Private Sub zeraValoresPart()

        txt_codPart.Text = "" : _codPart = "" : _nomePart = "" : txt_nomePart.Text = ""

    End Sub

    Private Sub addItemsRequisicaoGrid(ByVal codProd As String, _
                            ByVal nomeProd As String, ByVal qtdeProd As Double)

        
        Dim mlinha As String() = {codProd, nomeProd, Format(qtdeProd, "###,##0.00")}
        'Adicionando Linha
        Me.dtg_requisicao.Rows.Add(mlinha)
        Me.dtg_requisicao.Refresh()

        subtraiSaldoDtgProcesso(codProd, qtdeProd)
        If (CDbl(Me.txt_qtdeProdProcesso.Text) - CDbl(Me.txt_qtdeProdRequisicao.Text)) <= 0 Then

            Me.dtg_processo.Rows.Remove(Me.dtg_processo.CurrentRow)
            Me.dtg_processo.Refresh()
        End If


    End Sub

    Private Sub Btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_novo.Click

        executaF2()

    End Sub

    Private Sub executaF4()

        If Me.dtg_requisicao.Rows.Count > _valorZERO Then

            If MessageBox.Show("Deseja realmente Deletar esse Item?", "METROSYS", MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Me.DeleteItemGridR()
                zeraValoresItem()

            End If
        End If



    End Sub

    Private Sub DeleteItemGridR()

        Try
            If Not Me.dtg_requisicao.CurrentRow.IsNewRow Then

                'Remove Linha
                Dim codigoProduto As String = dtg_requisicao.CurrentRow.Cells(0).Value
                Dim qtdeProduto As Double = dtg_requisicao.CurrentRow.Cells(2).Value
                Dim nomeProduto As String = dtg_requisicao.CurrentRow.Cells(1).Value

                If existeProdDtgProcesso(codigoProduto) = False Then

                    Me.dtg_processo.Rows.Add(codigoProduto, nomeProduto, Format(qtdeProduto, "###,##0.00"))
                    Me.dtg_processo.Sort(Me.dtg_processo.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    Me.dtg_processo.Refresh()
                Else

                    somaSaldoDtgProcesso(codigoProduto, qtdeProduto)
                End If

                Me.dtg_requisicao.Rows.Remove(Me.dtg_requisicao.CurrentRow)
                Me.dtg_requisicao.Refresh()

                codigoProduto = Nothing : qtdeProduto = Nothing
            End If

        Catch ex As Exception
            MsgBox("Deu ERRO ao Deletar este Item " & ex.Message, MsgBoxStyle.Exclamation)
        End Try



    End Sub

    Private Sub Btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_excluir.Click

        executaF4()

    End Sub

    Private Sub btn_finalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalizar.Click

        executaF7()

    End Sub

    Private Sub executaF7()

        'Se tiver algum lançamento no Drig de Retorno de Vendas, verifica se os campos do cliente
        'estão corretos...
        If dtg_requisicao.Rows.Count > _valorZERO Then

            If verificaCamposCliente() Then

                If MessageBox.Show("Deseja realmente Finalizar essa Requisição?", "METROSYS", MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                    Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Dim transacao As NpgsqlTransaction
                    Dim tudoOK As Boolean = True

                    Try
                        conexao.Open()

                        Try
                            transacao = conexao.BeginTransaction

                            inclueRequisicaoItens(conexao, transacao)
                            transacao.Commit() : conexao.ClearAllPools()

                            MsgBox("Requisição Finalizada com Sucesso", MsgBoxStyle.Exclamation)
                            executaF6()

                            zeraValoresPart() : zeraValoresItem()
                            Me.txt_codPart.ReadOnly = False : Me.txt_codPart.BackColor = Color.White
                            Me.dtg_processo.Rows.Clear() : Me.dtg_processo.Refresh()
                            Me.dtg_requisicao.Rows.Clear() : Me.dtg_requisicao.Refresh()
                            Me.txt_numRequisicao.Text = ""


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


                End If
            End If
        End If



    End Sub

    Private Sub inclueRequisicaoItens(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim rqId As Int32 = _valorZERO, numRequis As String = Me.txt_numRequisicao.Text
        Dim codPart As String = "", codProd As String = "", nomeProd As String = ""
        Dim qtdeProd As Double = _valorZERO
        Dim data As Date = dtp_data.Value
        Dim usuario As String = ""

        Try
            usuario = MdlUsuarioLogando._usuarioLogin.Substring(0, 10)
        Catch ex As Exception
            usuario = MdlUsuarioLogando._usuarioLogin
        End Try

        rqId = Convert.ToInt64(numRequis)
        codPart = Me.txt_codPart.Text

        For Each row As DataGridViewRow In Me.dtg_requisicao.Rows

            If Not row.IsNewRow Then

                codProd = row.Cells(0).Value.ToString
                nomeProd = row.Cells(1).Value.ToString
                qtdeProd = CDbl(row.Cells(2).Value)

                _clBD.diminueQtdeProdProcessoCli(conexao, transacao, codPart, codProd, qtdeProd)

                _clBD.inclueRequProcCli(conexao, transacao, rqId, numRequis, codPart, codProd, qtdeProd, data, _
                                        nomeProd, usuario)

                _clBD.subtraiQtdeProdEstloja(codProd, _loja, qtdeProd, conexao, transacao)

            End If
        Next

        'Libera Objetos da Memória RAM...
        rqId = Nothing : numRequis = Nothing : codPart = Nothing : codProd = Nothing
        nomeProd = Nothing : qtdeProd = Nothing



    End Sub
    
    Private Sub dtg_requisicao_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dtg_requisicao.RowsAdded

        If Me.dtg_requisicao.Rows.Count <= 0 Then

            Me.txt_codPart.ReadOnly = False : Me.txt_codPart.BackColor = Color.White
        Else
            Me.txt_codPart.ReadOnly = True : Me.txt_codPart.BackColor = Me.txt_numRequisicao.BackColor
        End If

    End Sub

    Private Sub dtg_requisicao_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dtg_requisicao.RowsRemoved

        If Me.dtg_requisicao.Rows.Count <= 0 Then

            Me.txt_codPart.ReadOnly = False : Me.txt_codPart.BackColor = Color.White
        Else
            Me.txt_codPart.ReadOnly = True : Me.txt_codPart.BackColor = Me.txt_numRequisicao.BackColor
        End If

    End Sub

    Private Sub txt_qtdeProdRequisicao_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtdeProdRequisicao.KeyPress

        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_qtdeProdRequisicao_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtdeProdRequisicao.Leave

        If Me.txt_qtdeProdRequisicao.Text.Equals("") Then Me.txt_qtdeProdRequisicao.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_qtdeProdRequisicao.Text) Then

            If CDec(Me.txt_qtdeProdRequisicao.Text) <= _valorZERO Then

                MsgBox("Quantidade deve ser maior que ZERO !")
                Return

            End If
            Me.txt_qtdeProdRequisicao.Text = Format(CDec(Me.txt_qtdeProdRequisicao.Text), "###,##0.00")

        End If

    End Sub

    Private Sub executaF6()

        executaEspelhoRequisicao("", "\wged\consProcRequis.txt")
    End Sub

    Private Sub executaEspelhoRequisicaoExtracted(ByVal s As StreamWriter, ByVal loja As String, ByVal numeroRequisicao As String, ByVal codClient As String, ByVal nomeClient As String, ByRef shouldReturn As Boolean)

        shouldReturn = False

        s.WriteLine("")

        'Título
        Dim lShouldReturn0 As Boolean
        _clFuncoes.GravTituloProcRequisicaoLaser(numeroRequisicao, Date.Now, s, lShouldReturn0)
        If lShouldReturn0 Then shouldReturn = True : Return

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Loja
        _mConsulta.Append("SELECT g_geno, g_ender, g_fone, g_uf, g_cid FROM geno001 WHERE g_codig = '" & loja & "'")
        Dim lShouldReturn1 As Boolean
        _clFuncoes.GravCabLojProcRequisicaoLaser(_mConsulta.ToString, s, loja, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Cliente
        'Traz dados do CLIENTE do Pedido...
        _mConsulta.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
        _mConsulta.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codClient & "'")
        Dim lShouldReturn2 As Boolean
        _clFuncoes.GravCabCliProcRequisicaoLaser(_mConsulta.ToString, s, codClient, numeroRequisicao, lShouldReturn2)
        If lShouldReturn2 Then shouldReturn = True : Return


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'itens
        _mConsulta.Append("SELECT r_codpr, r_desc, r_qtde, r_data FROM " & MdlEmpresaUsu._esqEstab & ".estm300 ") '3
        _mConsulta.Append("WHERE r_req = '" & numeroRequisicao & "'")
        Dim lShouldReturn3 As Boolean
        _clFuncoes.GravItensProcRequisicaoLaser(_mConsulta.ToString, s, numeroRequisicao, codClient, nomeClient, lShouldReturn3)
        If lShouldReturn3 Then shouldReturn = True : Return

    End Sub

    Private Sub executaEspelhoRequisicao(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPconsProcRequis.TMP"
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
        _PrintFont1 = New Font("Lucida Console", 10)
        Dim strLinha As String = ""
        Dim loja As String = MdlEmpresaUsu._codigo
        Dim numeroPedido As String = Me.txt_numRequisicao.Text
        Dim codClient As String = Me.txt_codPart.Text
        Dim nomeClient As String = Me.txt_nomePart.Text


        Dim lShouldReturn As Boolean
        executaEspelhoRequisicaoExtracted(s, loja, numeroPedido, codClient, nomeClient, lShouldReturn)
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
            '        pdRelatPedidos.DefaultPageSettings.Landscape = True
            '    Case 2 'Impressora Laiser
            '        pdRelatPedidos.DefaultPageSettings.Landscape = False
            '    Case Else
            '        pdRelatPedidos.DefaultPageSettings.Landscape = True
            'End Select
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando REQUISIÇÃO"

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
        e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 50, 50, New StringFormat())


        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False : _stringToPrintAux = _StringToPrint

        End If



    End Sub

    Private Function existeProdDtgProcesso(ByVal codProd As String) As Boolean

        Dim mcodprod As String = ""

        Try
            For Each row As DataGridViewRow In Me.dtg_processo.Rows

                If row.IsNewRow = False Then

                    mcodprod = row.Cells(0).Value.ToString
                    If codProd.Equals(mcodprod) Then

                        Return True
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
        


        Return False
    End Function

    Private Function trazQtdeProdDtgProcesso(ByVal codProduto As String) As Double

        Dim mqtdeRow As Double = 0
        Dim mcodprod As String = ""

        Try

            For Each row As DataGridViewRow In Me.dtg_processo.Rows

                If row.IsNewRow = False Then

                    mcodprod = row.Cells(0).Value.ToString
                    If codProduto.Equals(mcodprod) Then

                        mqtdeRow = CDbl(row.Cells(2).Value)
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
        End Try

        

        Return mqtdeRow
    End Function

    Private Function trazIndexRowProdDtgProcesso(ByVal codProduto As String) As Integer

        Dim indexRow As Integer = 0
        Dim mcodprod As String = ""

        Try

            For Each row As DataGridViewRow In Me.dtg_processo.Rows

                If row.IsNewRow = False Then

                    mcodprod = row.Cells(0).Value.ToString
                    If codProduto.Equals(mcodprod) Then

                        indexRow = row.Index
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
        End Try



        Return indexRow
    End Function

    Private Function trazNomeProdDtgProcesso(ByVal codProduto As String) As String

        Dim mnome As String = ""
        Dim mcodprod As String = ""

        Try
            For Each row As DataGridViewRow In Me.dtg_processo.Rows

                If row.IsNewRow = False Then

                    mcodprod = row.Cells(0).Value.ToString
                    If codProduto.Equals(mcodprod) Then

                        mnome = CDbl(row.Cells(1).Value)
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
        End Try



        Return mnome
    End Function

    Private Sub subtraiSaldoDtgProcesso(ByVal codProd As String, ByVal qtde As Double)

        Dim indexRow As Integer = 0
        Dim mqtdeRow As Double

        indexRow = trazIndexRowProdDtgProcesso(codProd)
        mqtdeRow = trazQtdeProdDtgProcesso(codProd)
        Me.dtg_processo.Rows(indexRow).Cells(2).Value = Format(Round(mqtdeRow - qtde, 2), "###,##0.00")
        Me.dtg_processo.Refresh()

    End Sub

    Private Sub somaSaldoDtgProcesso(ByVal codProd As String, ByVal qtde As Double)

        Dim indexRow As Integer = 0
        Dim mqtdeRow As Double

        indexRow = trazIndexRowProdDtgProcesso(codProd)
        mqtdeRow = trazQtdeProdDtgProcesso(codProd)
        Me.dtg_processo.Rows(indexRow).Cells(2).Value = Format(Round(mqtdeRow + qtde, 2), "###,##0.00")
        Me.dtg_processo.Refresh()

    End Sub

    Private Sub InicializaRelatorio(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintEventArgs)

        '_StringToPrintItens = _stringToPrintAux
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