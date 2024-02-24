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
    Dim _geno001 As New Cl_Geno
    Dim _fornecedor As New Cl_Cadp001
    Dim _BuscaForn As New Frm_ClienteFornResp
    Dim _alfabeto() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", _
                              "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Z"}
    Dim _cont As Integer = 1
    Public Shared _frmREf As New Frm_CadPagamento

    Protected _conexao As String = MdlConexaoBD.conectionPadrao
    Public _Incluindo As Boolean = True
    Public _idPagamento As Int64 = 0

    'Atributos do Participante...
    Public mbUf As String = "", mbCNPJ As String = ""
    Public _codPart As String = "", _nomePart As String = ""

    Dim agora As Date = Now
    Dim _dtPagaAux As Date = Nothing


    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            If Not Me.txt_codPart.Text.Equals("") Then

                If Me.txt_codPart.TextLength > 5 Then 'Se retornar nada

                    If _clFuncoes.trazCadp001(Me.txt_codPart.Text, _fornecedor) Then

                        'Aqui tenta chamar a Busca do Produto...
                        Try

                            Me.txt_nomePart.Focus()
                            Me.txt_nomePart.SelectAll()

                            Return
                        Catch ex As Exception
                        End Try


                    End If
                End If

                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try

                    _frmREf = Me
                    _BuscaForn.set_frmRef(Me)
                    _BuscaForn.ShowDialog(Me)
                    If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus() : Return

                    _clFuncoes.trazCadp001(Me.txt_codPart.Text, _fornecedor)
                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()

                Catch ex As Exception
                End Try

            Else

                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try

                    _frmREf = Me
                    _BuscaForn.set_frmRef(Me)
                    _BuscaForn.ShowDialog(Me)
                    If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus() : Return

                    _clFuncoes.trazCadp001(Me.txt_codPart.Text, _fornecedor)
                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()

                Catch ex As Exception
                End Try

            End If
        End If

    End Sub

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

        lbl_NomeSys.Text = Application.ProductName
        cbo_loja = _clFuncoes.PreenchComboLoja5Dig(cbo_loja, MdlConexaoBD.conectionPadrao)
        cbo_loja.SelectedIndex = _clFuncoes.trazIndexCboLoja5dig(MdlEmpresaUsu._codigo, cbo_loja)
        Cbo_Banco = _clFuncoes.PreenchComboBancos(Cbo_Banco, MdlConexaoBD.conectionPadrao)

        zeraValores()
        If _Incluindo = False Then
            TrazValoresPagamento()
        End If
    End Sub

    Sub TrazValoresPagamento()

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection = Nothing : Return

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Dim condicao As String = ""


        Try

            sql.Append("SELECT d_parcelas, d_portad, d_nfat, d_duplic, d_emiss, d_vencto, d_valor, ") '6
            sql.Append("d_juros, d_desc, d_sit, d_tipo, d_banco, d_outros, d_hist ")
            sql.Append("FROM fatp001 WHERE d_id = @d_id") '25

            cmd = New NpgsqlCommand(sql.ToString, conection)
            cmd.Parameters.Add("@d_id", _idPagamento)
            dr = cmd.ExecuteReader

            While dr.Read

                txt_qtdeParcelas.Text = dr(0)
                _clFuncoes.trazCadp001(dr(1).ToString, _fornecedor)
                txt_codPart.Text = _fornecedor.pCod : txt_nomePart.Text = _fornecedor.pPortad
                txt_fatura.Text = dr(2).ToString
                txt_documento.Text = dr(3).ToString
                dtp_emissao.Value = dr(4)
                dtp_vencto.Value = dr(5)
                txt_valor.Text = Format(dr(6), "###,##0.00")
                txt_juros.Text = Format(dr(7), "###,##0.00")
                txt_desconto.Text = Format(dr(8), "###,##0.00")
                txt_situacao.Text = dr(9).ToString
                Cbo_tipo.SelectedIndex = _clFuncoes.trazIndexComboBox(dr(10).ToString, 2, Cbo_tipo)
                Cbo_Banco.SelectedIndex = _clFuncoes.trazIndexComboBox(dr(11).ToString.PadLeft(3, "000"), 3, Cbo_Banco)
                txt_outros.Text = Format(dr(12), "###,##0.00")
                txt_historico.Text = dr(13).ToString

            End While

            conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        cmd.CommandText = "" : sql.Remove(0, sql.ToString.Length)
        conection = Nothing : cmd = Nothing
        dr = Nothing : sql = Nothing

    End Sub

    Private Sub zeraValores()

        Me.txt_fatura.Text = ""
        Me.txt_documento.Text = ""
        Me.txt_desconto.Text = "0,00"
        Me.txt_juros.Text = "0,00"
        Me.txt_outros.Text = "0,00"
        Me.txt_valor.Text = "0,00"
        Me.txt_situacao.Text = "N"
        Me.msk_dtpaga.Enabled = False : Me.msk_dtpaga.Text = ""
        Me.txt_juros.Enabled = False
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
            If Me.txt_documento.Text.Equals("") Then
                Me.txt_documento.Text = Me.txt_fatura.Text & _clFuncoes.returnLetraAlfabetoPosi(_cont)
            End If
        Catch ex As Exception
        End Try


    End Sub

    Function ValidaCampos() As Boolean

        lbl_mensagem.Text = ""
        If Me.txt_fatura.Text.Equals("") Then
            Me.lbl_mensagem.Text = "Erro: Digite o numero da Fatura !"
            Return False
            Me.txt_fatura.Focus()
        End If
        If CDbl(txt_valor.Text) <= 0 Then
            Me.lbl_mensagem.Text = "Erro: Digite Valor do Documento !"
            Return False
            Me.txt_valor.Focus()
        End If
        If Not IsDate(dtp_emissao.Value) Then
            Me.lbl_mensagem.Text = "Erro: Digite Data de Emissao !"
            Return False
            Me.dtp_emissao.Focus()
        End If
        If Not IsDate(dtp_vencto.Value) Then
            Me.lbl_mensagem.Text = "Erro: Digite Data de Vencimento !"
            Return False
            Me.dtp_vencto.Focus()
        End If
        If Cbo_tipo.SelectedIndex < 0 Then
            Me.lbl_mensagem.Text = "Erro: Selecione o Tipo de Pagamento !"
            Return False
            Me.dtp_vencto.Focus()
        End If

        If Cbo_Banco.SelectedIndex < 0 Then
            Me.lbl_mensagem.Text = "Erro: Selecione o Tipo de Banco !"
            Return False
            Me.dtp_vencto.Focus()
        End If

        Return True
    End Function

    Private Sub Btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_salvar.Click

        If ValidaCampos = False Then Return

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

            Try
                _dtPagaAux = Convert.ChangeType(msk_dtpaga.Text, GetType(Date))
            Catch ex As Exception
                _dtPagaAux = Nothing
            End Try

            If _Incluindo Then
                inclueRegistro(conexao, transacao, _geno001.pCodig, Me.txt_codPart.Text, Me.txt_fatura.Text, _
                           Me.txt_documento.Text, dtp_emissao.Value, dtp_vencto.Value, Me.txt_valor.Text, _
                           _dtPagaAux, Me.txt_juros.Text, Me.txt_desconto.Text, Me.txt_situacao.Text, _
                           Me.Cbo_tipo.SelectedItem, Me.Cbo_Banco.SelectedItem, 0, _
                           Me.txt_outros.Text, Me.txt_historico.Text)

                transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                txt_qtdeParcelas.ReadOnly = True : Me.dtp_vencto.Focus() : Me.dtp_vencto.Select()

                If _cont <= CInt(Me.txt_qtdeParcelas.Text) Then

                    _cont += 1

                    If _cont <= CInt(Me.txt_qtdeParcelas.Text) Then

                        Me.txt_documento.Text = Me.txt_fatura.Text & _clFuncoes.returnLetraAlfabetoPosi(_cont)
                        Try
                            Me.dtp_vencto.Value = DateValue(dtp_vencto.Text).AddDays(CInt(txt_prazoVenc.Text))
                        Catch ex As Exception
                            MsgBox("Informe uma Data de Vencimento para Incluir a PRÓXIMA Parcela", MsgBoxStyle.Exclamation)
                        End Try
                    End If
                End If


            Else
                'Alterando...

                If MessageBox.Show("Deseja afetar somente o VALOR e o TIPO das demais outras parcelas Normais?!", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                    alterandoRegistroAll(conexao, transacao, _geno001.pCodig, Me.txt_codPart.Text, Me.txt_fatura.Text, _
                           Me.txt_documento.Text, dtp_emissao.Value, dtp_vencto.Value, Me.txt_valor.Text, _
                           _dtPagaAux, Me.txt_juros.Text, Me.txt_desconto.Text, Me.txt_situacao.Text, _
                           Me.Cbo_tipo.SelectedItem, Me.Cbo_Banco.SelectedItem, 0, _
                           Me.txt_outros.Text, Me.txt_historico.Text)

                    transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                    MsgBox("Registros Atualizados com Sucesso", MsgBoxStyle.Exclamation, "METROSYS")
                    Me.Close()
                Else

                    alterandoRegistro(conexao, transacao, _geno001.pCodig, Me.txt_codPart.Text, Me.txt_fatura.Text, _
                           Me.txt_documento.Text, dtp_emissao.Value, dtp_vencto.Value, Me.txt_valor.Text, _
                           _dtPagaAux, Me.txt_juros.Text, Me.txt_desconto.Text, Me.txt_situacao.Text, _
                           Me.Cbo_tipo.SelectedItem, Me.Cbo_Banco.SelectedItem, 0, _
                           Me.txt_outros.Text, Me.txt_historico.Text)

                    transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                    MsgBox("Registro Atualizado com Sucesso", MsgBoxStyle.Exclamation, "METROSYS")
                    Me.Close()
                End If


            End If

            Select Case (_cont - 1)
                Case Is < CInt(Me.txt_qtdeParcelas.Text)
                    lbl_mensagem.Text = (_cont - 1) & " Parcela Incluida com Sucesso !"
                Case Is = CInt(Me.txt_qtdeParcelas.Text)
                    MsgBox("Registro Efetuado com Sucesso", MsgBoxStyle.Exclamation, "METROSYS")
                    conexao.Close()
                    Me.Close()
            End Select


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

    End Sub

    Private Sub inclueRegistro(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                ByVal CodGeno As String, ByVal CodForn As String, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As Date, _
                ByVal Juros As Decimal, ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, _
                ByVal Banco As String, ByVal Tarifa As Decimal, ByVal Outros As Decimal, ByVal Historico As String)

        Tipo = Tipo.Substring(0, 2)
        Banco = Banco.Substring(0, 3)


        _clBD.incPagamentoFatp001(conexao, transacao, CInt(txt_qtdeParcelas.Text), CodGeno, CodForn, Fatura, Documento, DtEmissao, DtVencto, _
                                  Valor, "", Juros, Descontos, Situacao, Tipo, Banco, Tarifa, Outros, Historico)

    End Sub


    Private Sub alterandoRegistro(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                ByVal CodGeno As String, ByVal CodForn As String, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As Date, _
                ByVal Juros As Decimal, ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, _
                ByVal Banco As String, ByVal Tarifa As Decimal, ByVal Outros As Decimal, ByVal Historico As String)

        Tipo = Tipo.Substring(0, 2)
        Banco = Banco.Substring(0, 3)

        _clBD.altPagamentoFatp001(conexao, transacao, _idPagamento, CodGeno, CodForn, Fatura, Documento, DtEmissao, DtVencto, _
                                  Valor, "", Juros, Descontos, Situacao, Tipo, Banco, Tarifa, Outros, Historico)

    End Sub

    Private Sub alterandoRegistroAll(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                ByVal CodGeno As String, ByVal CodForn As String, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As Date, _
                ByVal Juros As Decimal, ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, _
                ByVal Banco As String, ByVal Tarifa As Decimal, ByVal Outros As Decimal, ByVal Historico As String)

        Tipo = Tipo.Substring(0, 2)
        Banco = Banco.Substring(0, 3)

        _clBD.altPagamentoFatp001All(conexao, transacao, Fatura, Valor, Tipo)

    End Sub

    Private Sub msk_emissao_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_emissao.Leave
        ' agora = DateValue(msk_emissao.Text)
        Try
            Me.dtp_vencto.Text = DateValue(dtp_emissao.Text).AddDays(CInt(txt_prazoVenc.Text))
        Catch ex As Exception
            Me.lbl_mensagem.Text = "Informe a Data de Emissao !"
        End Try

    End Sub

    Private Sub Cbo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_tipo.GotFocus
        If Cbo_tipo.DroppedDown = False Then Cbo_tipo.DroppedDown = True
    End Sub

    Private Sub Cbo_tipo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_tipo.Leave
        If Cbo_tipo.SelectedIndex > -1 Then
            Me.Cbo_Banco.SelectedIndex = 0
        End If

    End Sub

    Private Sub txt_desconto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_desconto.Leave

        lbl_mensagem.Text = ""
        If Me.txt_desconto.Text.Equals("") Then Me.txt_desconto.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_desconto.Text) Then

            Me.txt_desconto.Text = Format(CDec(Me.txt_desconto.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Desconto não é numérico !" : Me.txt_desconto.Focus() : Me.txt_desconto.SelectAll()
        End If

    End Sub

    Private Sub txt_valor_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valor.KeyPress, txt_outros.KeyPress, txt_juros.KeyPress, txt_desconto.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True

    End Sub

    Private Sub txt_valor_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valor.Leave

        lbl_mensagem.Text = ""
        If Me.txt_valor.Text.Equals("") Then Me.txt_valor.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valor.Text) Then

            Me.txt_valor.Text = Format(CDec(Me.txt_valor.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Valor não é numérico !" : Me.txt_valor.Focus() : Me.txt_valor.SelectAll()
        End If

    End Sub

    Private Sub txt_juros_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_juros.Leave

        lbl_mensagem.Text = ""
        If Me.txt_juros.Text.Equals("") Then Me.txt_juros.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_juros.Text) Then

            Me.txt_juros.Text = Format(CDec(Me.txt_juros.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "Juros não é numérico !" : Me.txt_juros.Focus() : Me.txt_juros.SelectAll()
        End If

    End Sub

    Private Sub txt_outros_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_outros.Leave

        lbl_mensagem.Text = ""
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

    Private Sub TextBoxSoNumeros_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtdeParcelas.KeyPress, txt_prazoVenc.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_qtdeParcelas_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtdeParcelas.Leave, txt_prazoVenc.Leave

        lbl_mensagem.Text = ""
        If Me.txt_qtdeParcelas.Text.Equals("") Then Me.txt_qtdeParcelas.Text = "1"
        If IsNumeric(Me.txt_qtdeParcelas.Text) Then
            If CDbl(Me.txt_qtdeParcelas.Text) <= 0 Then Me.txt_qtdeParcelas.Text = "1"

        Else
            lbl_mensagem.Text = "Valor não é numérico !" : Me.txt_qtdeParcelas.Focus() : Me.txt_qtdeParcelas.SelectAll()
        End If

    End Sub

    Private Sub cbo_loja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_loja.SelectedIndexChanged

        Try
            _clFuncoes.trazGenoSelecionado(Mid(cbo_loja.SelectedItem.ToString, 1, 5), _geno001)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

End Class