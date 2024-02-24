Imports Npgsql
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Math
Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog

Public Class Frm_Agendamentos

    Private Const _valorZERO As Integer = 0
    Dim xcont As Integer = 0
    Dim _clBD As New Cl_bdMetrosys
    Dim _clFuncoes As New ClFuncoes
    Public _servico As New Cl_Servico
    Dim _clDoutorDAO As New Cl_DoutorDAO
    Dim _Geno As New Cl_Geno
    Dim _cadp001 As New Cl_Cadp001
    Dim _agend1 As New Cl_Agendamento1
    Dim _agend2 As New Cl_Agendamento2
    Dim _clAgendDAO As New Cl_AgendamentosDAO
    Dim _Doutor As New Cl_Doutor
    Dim _formBusca As Boolean = False
    Dim _BuscaForn As New Frm_ClienteFornResp
    Dim _numOrcamentoAtual As Int64 = 0
    Dim _numPedidoOK As Boolean = False
    Public _mPesquisaForn As Boolean = False 'Serve para configura os campos CodFornec e NomeFornec
    Public Shared _frmREf As New Frm_Agendamentos
    Dim _BuscaProd As New Frm_ServicoResp
    Dim _mConsulta As New StringBuilder
    Dim _editandoProduto As Boolean = False

    'Impressão:
    Private _clienteImpr As New Cl_Cadp001
    Private _agend1Impr As New Cl_Agendamento1
    Private _AgendRelatorio As New Cl_AgendamentosR

    'Objetos auxiliares para editar o produto...
    Private _qtdeAnteriorProd As Double
    Private _codProdEditando As String = ""
    Private _indexProdEditando As Integer
    Private _aliqDescProdEditado, _vlrProdEditado, _vlDescProdEditado As Double

    'OBJETOS AUXILIAR DO CLIENTE...
    Public _Cliente As New Cl_Cadp001

    'Variaveis:
    Dim _turno As String = "M"

    'OBJETOS AUXILIAR DA GRADE...
    Public codCorGrade_Ref, nomeCorGrade_Ref, tamanhoGrade_Ref As String

    'Objetos para salvar o pedido...
    Dim _arqNumPedido As String = "\wged\relatorios\numpedido.TXT"
    Dim _fsnumpedido As FileStream
    Dim _snumpedido As StreamWriter

    'Objetos para tratar o Gerente...
    Dim _vlrMaxDesconto As Double = 0.0
    Dim _nomeGerente As String = ""

    'Objetos para tratar o vendedor...
    Dim _descVendedor As Double = 0.0

    Dim _consumo As String = "S"


    Private Sub Frm_Agendamentos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F6
                'executaRelatorioAgendamento("", "\wged\relatorios\orcamento.txt")
        End Select

    End Sub

    Private Sub Frm_Agendamentos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Agendamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txt_operador.Text = MdlUsuarioLogando._usuarioNome
        cbo_local = _clFuncoes.PreenchComboLoja2Dig(cbo_local, MdlConexaoBD.conectionPadrao)
        Me.cbo_local.SelectedIndex = _clFuncoes.trazIndexCboLoja2dig(Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2), cbo_local)

        cbo_doutores = _clDoutorDAO.PreenchComboDoutores(_Geno, cbo_doutores, MdlConexaoBD.conectionPadrao)

        If MdlUsuarioLogando._usuarioPrivilegio = True Then Me.cbo_local.Enabled = True

    End Sub

    Private Sub txt_codPart_KeyDownExtracted()

        _formBusca = True : _mPesquisaForn = False : _frmREf = Me
        _BuscaForn.set_frmRef(Me)
        _BuscaForn.ShowDialog(Me)
        _formBusca = False
        If Me.txt_codpart.Text.Equals("") Then Me.txt_codpart.Focus() : Return

        Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()

        _clFuncoes.trazCadp001(Me.txt_codpart.Text, _cadp001)
    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codpart.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then


            If Me.txt_codpart.Text.Equals("") Then


                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    txt_codPart_KeyDownExtracted()

                Catch ex As Exception
                End Try

            Else  ' Consulta pelo codigo do cliente...


                If (Me.txt_codpart.TextLength > 5) AndAlso (e.KeyCode = Keys.Enter) Then 'Se retornar nada

                    If _clFuncoes.trazCadp001(Me.txt_codpart.Text, _cadp001) Then

                        Dim lShouldReturn As Boolean
                        Me.txt_nomePart.Focus()
                        Me.txt_nomePart.SelectAll()
                        If lShouldReturn Then Return
                        lShouldReturn = Nothing

                    Else


                        'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                        Try
                            txt_codPart_KeyDownExtracted()

                        Catch ex As Exception
                        End Try

                    End If
                End If

            End If
        End If



    End Sub

    Private Function verificaRegistroPedido() As Boolean

        lbl_mensagem.Text = ""

        'Verifica se foi selecionado alguma Loja...
        If cbo_local.SelectedIndex < _valorZERO Then

            lbl_mensagem.Text = "Selecione uma LOJA !" : cbo_local.Focus() : Return False

        End If

        'Verifica se foi informado alguma Data para o Pedido...
        If Not IsDate(dtp_agendamento.Text) Then

            lbl_mensagem.Text = "Informe alguma DATA para o Pedido !" : dtp_agendamento.Focus() : Return False

        End If

        'Verifica se foi informado algum Cliente...
        If Trim(Me.txt_codpart.Text).Equals("") AndAlso Trim(Me.txt_nomePart.Text).Equals("") Then

            lbl_mensagem.Text = "Informe um CLIENTE para o Pedido !" : dtp_agendamento.Focus() : Return False

        End If


        Return True
    End Function

    Private Sub limpaCamposRegistroProd()

        Me.cbo_local.Enabled = False
        If MdlUsuarioLogando._usuarioPrivilegio = True Then Me.cbo_local.Enabled = True
        'Me.cbo_vendedor.Enabled = False
    End Sub

    Private Sub zeraTudo()
        dtp_agendamento.Value = Date.Now 'cbo_local.SelectedIndex = -1 : 

        'Zera dados cliente...
        Me.txt_codpart.Text = "" : Me.txt_nomePart.Text = ""
        Me.cbo_informacao.Text = ""

        lbl_mensagem.Text = "" : _qtdeAnteriorProd = _valorZERO : _codProdEditando = ""
        _indexProdEditando = _valorZERO


    End Sub

    Private Sub incluiRegistroAgendamento(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        _agend1.a_id = Me.txt_orcamento.Text
        _agend1.a_iddoutor = _Doutor.Id
        _agend1.a_codig = Me.txt_codpart.Text : _agend1.a_paciente = Me.txt_nomePart.Text
        _agend1.a_doutor = _Doutor.Nome
        _agend1.a_dtemis = Date.Now : _agend1.a_dtagend = dtp_agendamento.Value : _agend1.a_status = False
        _agend1.a_valor = 0 : _agend1.a_cancelado = False
        _agend1.a_usuario = txt_operador.Text
        _agend1.a_turno = _turno
        _agend1.a_info = cbo_informacao.Text

        _clAgendDAO.IncAgendamento1(_agend1, _Geno, conexao, transacao)


    End Sub

    Sub TrazNumAgendamento()

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return
        End Try

        transacao = conexao.BeginTransaction

        'Numero do orçamento...
        _numOrcamentoAtual = _clAgendDAO.trazProxNumAgendamento1(conexao, _Geno)
        Me.txt_orcamento.Text = String.Format("{0:D7}", _numOrcamentoAtual)
        transacao.Commit() : conexao.ClearAllPools() : conexao.Close() : conexao = Nothing
        _numPedidoOK = True

    End Sub

    Private Sub btn_finalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalizar.Click

        TrazNumAgendamento()

        If verificaRegistroPedido() Then

            If MessageBox.Show("Deseja Finalizar Registros ?", "Finalizar ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Me.cbo_informacao.Focus()
            Else


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

                    incluiRegistroAgendamento(conexao, transacao)

                    transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                    MsgBox("Registro Efetuado c/ Sucesso", MsgBoxStyle.Exclamation, "METROSYS")

                    'executaF6()
                    Me.txt_orcamento.Text = ""

                    zeraTudo() : Me.cbo_local.Focus() : _numPedidoOK = False

                Catch ex As NpgsqlException

                    transacao.Rollback()
                    MsgBox(ex.Message.ToString)

                    If Mid(ex.Message.ToUpper, 1, 12).Equals("ERRO: 23505") Then
                        TrazNumAgendamento()
                    End If
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


            End If
        End If



    End Sub

    Private Sub cbo_local_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_local.GotFocus

        If Not cbo_local.DroppedDown Then cbo_local.DroppedDown = True
    End Sub

    Sub executaF6()

        _clFuncoes.trazCadp001(txt_codpart.Text, _clienteImpr)
        _clAgendDAO.trazAgendamento1(Convert.ToInt64(Me.txt_orcamento.Text), _Geno, _agend1Impr)

        _AgendRelatorio._Geno = _Geno
        _AgendRelatorio._Cliente = _clienteImpr
        _AgendRelatorio._Agend1 = _agend1Impr
        _AgendRelatorio.executaF6()
    End Sub

    Private Sub txt_pedido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_orcamento.TextChanged

        If Me.txt_orcamento.Text.Equals("") Then Me._numPedidoOK = False

    End Sub

    Private Sub Frm_Agendamentos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing


        If MessageBox.Show("Deseja Realmente Sair?", "METROSYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
            = Windows.Forms.DialogResult.No Then

            e.Cancel = True
        End If

    End Sub

    Private Sub cbo_local_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_local.SelectedIndexChanged

        Try
            _clFuncoes.trazGenoSelecionado("G00" & Mid(cbo_local.SelectedItem.ToString, 1, 2), _Geno)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cbo_doutores_GotFocus(sender As Object, e As EventArgs) Handles cbo_doutores.GotFocus
        If cbo_doutores.DroppedDown = False Then cbo_doutores.DroppedDown = True
    End Sub

    Private Sub cbo_doutores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_doutores.SelectedIndexChanged

        Try
            If cbo_doutores.SelectedIndex > -1 Then
                _clDoutorDAO.trazDoutorLojaNome(cbo_doutores.SelectedItem.ToString, _Geno, _Doutor)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdb_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_manha.CheckedChanged, rdb_tarde.CheckedChanged, rdb_noite.CheckedChanged

        If rdb_manha.Checked Then _turno = "M"
        If rdb_tarde.Checked Then _turno = "T"
        If rdb_noite.Checked Then _turno = "N"
    End Sub

End Class