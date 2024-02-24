Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.DateTime
Imports System.Math
Imports Npgsql

Public Class Frm_CadPagamento

    Dim _clFuncoes As New ClFuncoes
    Dim _clBD As New Cl_bdMetrosys
    Dim _BuscaForn As New Frm_BuscaForn
    Dim _alfabeto() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", _
                              "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Z"}
    Dim _cont As Integer = 1
    Public Shared _frmREf As New Frm_CadPagamento

    Protected _conexao As String = MdlConexaoBD.conectionPadrao
    Public _Incluindo As Boolean = True

    'Atributos do Participante...
    Public mbUf As String = "", mbCNPJ As String = ""
    Public _codPart As String = "", _nomePart As String = ""

    Dim agora As Date = Now


    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown

        If Not Me.txt_codPart.Text.Equals("") Then

            If Me.txt_codPart.TextLength > 5 AndAlso e.KeyCode = Keys.Enter Then 'Se retornar nada

                If trazFornecedor(Me.txt_codPart.Text) Then


                    'Aqui tenta chamar a Busca do Produto...
                    Try

                        Me.txt_nomePart.Focus()
                        Me.txt_nomePart.SelectAll()

                        Return
                    Catch ex As Exception
                    End Try


                End If
            End If
        End If

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            If Me.txt_codPart.Text.Equals("") Then


                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try

                    _frmREf = Me
                    _BuscaForn.set_frmRef(Me)
                    _BuscaForn.ShowDialog(Me)
                    If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus()

                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()

                Catch ex As Exception
                End Try


            End If
        End If

    End Sub

    Public Function trazFornecedor(ByVal codFornec As String) As Boolean

        Dim nomeCampo As String = ""
        Dim nomeCampoCgc As String = ""
        Dim nomeCampoCpf As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        Dim pesquisa As String = codFornec.ToUpper

        Try
            If oConnBDGENOV.State = ConnectionState.Closed Then
                oConnBDGENOV.Open()
            End If
        Catch ex As Exception
        End Try

        If oConnBDGENOV.State = ConnectionState.Open Then
            Dim codigo, nome, cpf_cnpj, inscricao, UF As String

            Try
                SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc, p_uf FROM cadp001 WHERE ") ' 5
                SqlParticipante.Append("p_cod = '" & pesquisa & "' ORDER BY p_portad ASC")
                CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDGENOV)
                drParticipante = CmdParticipante.ExecuteReader

                If drParticipante.HasRows = False Then
                    Return False
                Else
                    While drParticipante.Read
                        codigo = drParticipante(0).ToString
                        nome = drParticipante(1).ToString
                        If Not drParticipante(2).ToString.Equals("") Then 'se tiver CNPJ...
                            cpf_cnpj = drParticipante(2).ToString
                        Else
                            cpf_cnpj = drParticipante(3).ToString
                        End If
                        inscricao = drParticipante(4).ToString
                        UF = drParticipante(5).ToString

                    End While
                    Me.txt_nomePart.Text = nome
                    Me.mbCNPJ = cpf_cnpj
                    Me.mbUf = UF

                End If

            Catch ex As Exception
            End Try

            CmdParticipante.CommandText = ""
            SqlParticipante.Remove(0, SqlParticipante.ToString.Length)
        End If

        Return True
    End Function

    Private Sub Frm_Dup_Registro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Close()

    End Sub

    Private Sub Frm_Dup_Registro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Dup_Registro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        zeraValores()
    End Sub

    Private Sub zeraValores()

        cbo_loja = _clFuncoes.PreenchComboLoja(cbo_loja, MdlConexaoBD.conectionPadrao)
        Cbo_Banco = _clFuncoes.PreenchComboBancos(Cbo_Banco, MdlConexaoBD.conectionPadrao)
        Me.txt_fatura.Text = ""
        Me.txt_documento.Text = ""
        Me.txt_desconto.Text = "0,00"
        Me.txt_juros.Text = "0,00"
        Me.txt_outros.Text = "0,00"
        Me.txt_protesto.Text = "0,00"
        Me.txt_valor.Text = "0,00"
        Me.txt_situacao.Text = "N"
        Me.dtp_dtpaga.Enabled = False : Me.dtp_dtpaga.Text = ""
        Me.txt_juros.Enabled = False
        Me.txt_protesto.Enabled = False
        Cbo_tipo.SelectedIndex = -1
        If _Incluindo = False Then
            Me.lbl_parcelas.Visible = False : Me.txt_qtdeParcelas.Visible = False
        End If

    End Sub

    Private Sub txt_fatura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_fatura.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True

    End Sub

    Private Sub txt_fatura_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fatura.Leave

        Try
            Dim mfat As Integer
            mfat = Convert.ToInt32(Me.txt_fatura.Text)
            Me.txt_fatura.Text = String.Format("{0:D9}", mfat)
            Me.txt_documento.Text = Me.txt_fatura.Text & "A"
        Catch ex As Exception
        End Try
        

    End Sub

    Private Sub Btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_salvar.Click

        Dim mteste As Boolean = True
        If Me.txt_fatura.Text.Equals("") Then
            Me.lbl_mensagem.Text = "Erro: Digite o numero da Fatura !"
            mteste = False
            Me.txt_fatura.Focus()
        End If
        If CDbl(txt_valor.Text) <= 0 Then
            Me.lbl_mensagem.Text = "Erro: Digite Valor do Documento !"
            mteste = False
            Me.txt_valor.Focus()
        End If
        If Not IsDate(dtp_emissao.Value) Then
            Me.lbl_mensagem.Text = "Erro: Digite Data de Emissao !"
            mteste = False
            Me.dtp_emissao.Focus()
        End If
        If Not IsDate(dtp_vencto.Value) Then
            Me.lbl_mensagem.Text = "Erro: Digite Data de Vencimento !"
            mteste = False
            Me.dtp_vencto.Focus()
        End If
        If Cbo_tipo.SelectedIndex <= 0 Then
            Me.lbl_mensagem.Text = "Erro: Selecione o Tipo de Pagamento !"
            mteste = False
            Me.dtp_vencto.Focus()
        End If
        

        If mteste = True Then

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

                If _Incluindo Then
                    inclueRegistro(conexao, transacao, cbo_loja.SelectedItem, Me.txt_codPart.Text, Me.txt_fatura.Text, _
                               Me.txt_documento.Text, dtp_emissao.Value, dtp_vencto.Value, Me.txt_valor.Text, _
                               Me.dtp_dtpaga.Value, Me.txt_juros.Text, Me.txt_desconto.Text, Me.txt_situacao.Text, _
                               Me.Cbo_tipo.SelectedItem, Me.Cbo_Banco.SelectedItem, Me.txt_protesto.Text, _
                               Me.txt_outros.Text, Me.txt_historico.Text)

                    transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                    txt_qtdeParcelas.ReadOnly = True : Me.dtp_vencto.Focus() : Me.dtp_vencto.Select()

                    If _cont <= CInt(Me.txt_qtdeParcelas.Text) Then

                        _cont += 1
                        Me.txt_documento.Text = Me.txt_fatura.Text & _alfabeto((_cont - 1)).ToString
                        Try
                            Me.dtp_vencto.Text = DateValue(dtp_vencto.Text).AddDays(30)
                        Catch ex As Exception
                            Me.lbl_mensagem.Text = "Informe a Data de Emissao !"
                        End Try
                    End If


                Else
                    'Alterando...

                    transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                    zeraValores() : cbo_loja.Focus()
                End If


                MsgBox("Registro Efetuado com Sucesso", MsgBoxStyle.Exclamation, "METROSYS")



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
            If txt_qtdeParcelas.Text = "" Then txt_qtdeParcelas.Text = "1"
            If (_Incluindo = False) OrElse (_cont > CInt(txt_qtdeParcelas.Text)) Then Me.Close()


        End If
    End Sub

    Private Sub inclueRegistro(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                ByVal CodGeno As String, ByVal CodForn As String, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As Date, _
                ByVal Juros As Decimal, ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, _
                ByVal Banco As String, ByVal Tarifa As Decimal, ByVal Outros As Decimal, ByVal Historico As String)

        CodGeno = "G00" & CodGeno.Substring(0, 2)
        Tipo = Tipo.Substring(0, 2)
        Banco = Banco.Substring(0, 3)

        _clBD.incPagamentoFatp001(conexao, transacao, CodGeno, CodForn, Fatura, Documento, DtEmissao, DtVencto, _
                                  Valor, "", Juros, Descontos, Situacao, Tipo, Banco, Tarifa, Outros, Historico)

    End Sub

    Private Sub msk_emissao_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_emissao.Leave
        ' agora = DateValue(msk_emissao.Text)
        Try
            Me.dtp_vencto.Text = DateValue(dtp_emissao.Text).AddDays(30)
        Catch ex As Exception
            Me.lbl_mensagem.Text = "Informe a Data de Emissao !"
        End Try

    End Sub

    Private Sub Cbo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_tipo.GotFocus
        If Cbo_tipo.DroppedDown = False Then Cbo_tipo.DroppedDown = True
    End Sub

    Private Sub Cbo_tipo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_tipo.Leave
        If Me.Cbo_tipo.SelectedIndex = 0 Or Cbo_tipo.SelectedIndex = 2 Or Me.Cbo_tipo.SelectedIndex >= 4 Then
            Me.Cbo_Banco.SelectedIndex = 0
        End If

    End Sub

    Private Sub txt_desconto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_desconto.Leave

        If Me.txt_desconto.Text.Equals("") Then Me.txt_desconto.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_desconto.Text) Then

            Me.txt_desconto.Text = Format(CDec(Me.txt_desconto.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Desconto não é numérico !" : Me.txt_desconto.Focus() : Me.txt_desconto.SelectAll()
        End If

    End Sub

    Private Sub txt_valor_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valor.KeyPress, txt_outros.KeyPress, txt_juros.KeyPress, txt_desconto.KeyPress, txt_protesto.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True

    End Sub

    Private Sub txt_valor_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valor.Leave

        If Me.txt_valor.Text.Equals("") Then Me.txt_valor.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valor.Text) Then

            Me.txt_valor.Text = Format(CDec(Me.txt_valor.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Valor não é numérico !" : Me.txt_valor.Focus() : Me.txt_valor.SelectAll()
        End If

    End Sub

    Private Sub txt_juros_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_juros.Leave

        If Me.txt_juros.Text.Equals("") Then Me.txt_juros.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_juros.Text) Then

            Me.txt_juros.Text = Format(CDec(Me.txt_juros.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Juros não é numérico !" : Me.txt_juros.Focus() : Me.txt_juros.SelectAll()
        End If

    End Sub

    Private Sub txt_protesto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_protesto.Leave

        If Me.txt_protesto.Text.Equals("") Then Me.txt_protesto.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_protesto.Text) Then

            Me.txt_protesto.Text = Format(CDec(Me.txt_protesto.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Protesto não é numérico !" : Me.txt_protesto.Focus() : Me.txt_protesto.SelectAll()
        End If

    End Sub

    Private Sub txt_outros_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_outros.Leave

        If Me.txt_outros.Text.Equals("") Then Me.txt_outros.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_outros.Text) Then

            Me.txt_outros.Text = Format(CDec(Me.txt_outros.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Outros não é numérico !" : Me.txt_outros.Focus() : Me.txt_outros.SelectAll()
        End If

    End Sub

    Private Sub cbo_loja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_loja.GotFocus
        If cbo_loja.DroppedDown = False Then cbo_loja.DroppedDown = True
    End Sub

    Private Sub Cbo_Banco_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Banco.GotFocus
        If Cbo_Banco.DroppedDown = False Then Cbo_Banco.DroppedDown = True
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtdeParcelas.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_qtdeParcelas_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtdeParcelas.Leave

        lbl_mensagem.Text = ""
        If Me.txt_qtdeParcelas.Text.Equals("") Then Me.txt_qtdeParcelas.Text = "1"
        If IsNumeric(Me.txt_qtdeParcelas.Text) Then
            If CDbl(Me.txt_qtdeParcelas.Text) <= 0 Then Me.txt_qtdeParcelas.Text = "1"

        Else
            lbl_mensagem.Text = "Valor não é numérico !" : Me.txt_qtdeParcelas.Focus() : Me.txt_qtdeParcelas.SelectAll()
        End If

    End Sub

End Class