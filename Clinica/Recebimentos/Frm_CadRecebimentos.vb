Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.DateTime
Imports System.Math
Imports Npgsql

Public Class Frm_CadRecebimentos

    Dim _Geno As New Cl_Geno
    Dim _DentistaDAO As New Cl_DoutorDAO
    Dim _Dentista As New Cl_Doutor
    Dim _Protetico As New Cl_Doutor
    Dim _ProteticoDAO As New Cl_DoutorDAO
    Public _TpAtendimento As New Cl_TpAtendimento

    Dim _clFuncoes As New ClFuncoes
    Dim _clBD As New Cl_bdMetrosys
    Dim _geno001 As New Cl_Geno
    Dim _fornecedor As New Cl_Cadp001
    Dim _BuscaForn As New Frm_ClienteFornResp
    Dim _alfabeto() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", _
                              "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Z"}
    Dim _cont As Integer = 1
    Public Shared _frmREf As New Frm_CadRecebimentos

    Protected _conexao As String = MdlConexaoBD.conectionPadrao
    Public _Incluindo As Boolean = True
    Public _idRecebimento As Int64 = 0

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

    Private Sub Frm_CadRecebimentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Close()

    End Sub

    Private Sub Frm_CadRecebimentos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_CadRecebimentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        cbo_loja = _clFuncoes.PreenchComboLoja5Dig(cbo_loja, MdlConexaoBD.conectionPadrao)
        cbo_loja.SelectedIndex = _clFuncoes.trazIndexCboLoja5dig(MdlEmpresaUsu._codigo, cbo_loja)
        Cbo_Banco = _clFuncoes.PreenchComboBancos(Cbo_Banco, MdlConexaoBD.conectionPadrao)
        _clFuncoes.trazGenoSelecionado(MdlEmpresaUsu._codigo, _Geno)
        cbo_dentistas = _DentistaDAO.PreenchComboDoutores(_Geno, cbo_dentistas, MdlConexaoBD.conectionPadrao)
        cbo_protetico = _ProteticoDAO.PreenchComboProtetico(_Geno, cbo_protetico, MdlConexaoBD.conectionPadrao)
        cbo_tpAtendimento = _TpAtendimento.DAO.PreenchComboTpAtendimento(cbo_tpAtendimento, MdlConexaoBD.conectionPadrao)

        Try
            cbo_dentistas.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Try
            cbo_tpAtendimento.SelectedIndex = 0
        Catch ex As Exception
        End Try

        zeraValores()

        If _Incluindo Then

            Dim mId As Int64 = _clBD.trazProxIdFatd001(_geno001, MdlConexaoBD.conectionPadrao)
            txt_fatura.Text = String.Format("{0:D9}", mId)
            Try
                Dim mfat As Integer
                mfat = Convert.ToInt32(Me.txt_fatura.Text)
                Me.txt_fatura.Text = String.Format("{0:D9}", mfat)
                If Me.txt_documento.Text.Equals("") Then
                    Me.txt_documento.Text = Me.txt_fatura.Text & _clFuncoes.returnLetraAlfabetoPosi(_cont)
                End If
            Catch ex As Exception
            End Try


        Else

            TrazValoresRecebimento()
        End If


    End Sub

    Sub TrazValoresRecebimento()

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

            sql.Append("SELECT f_parcelas, f_portad, f_nfat, f_duplic, f_emiss, f_vencto, f_valor, ") '6
            sql.Append("f_juros, f_desc, f_sit, f_tipo, f_banco, f_outros, f_hist, f_txcobrada, f_vltxcobrada, f_doutor, f_hora, f_protetico, f_tpatend ") '19
            sql.Append("FROM " & _geno001.pEsquemaestab & ".fatd001 WHERE f_idx = @f_idx")

            cmd = New NpgsqlCommand(sql.ToString, conection)
            cmd.Parameters.Add("@f_idx", _idRecebimento)
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
                txt_historico.Text = dr(13).ToString
                txt_taxa.Text = Format(dr(14), "###,##0.00")
                txt_vlrTaxa.Text = Format(dr(15), "###,##0.00")
                If dr(16).ToString.Equals("") = False Then
                    cbo_dentistas.SelectedIndex = _clFuncoes.trazIndexComboBox(dr(16).ToString, dr(16).ToString.Length, cbo_dentistas)
                End If
                txt_hora.Text = dr(17).ToString

                If dr(18).ToString.Equals("") = False Then
                    cbo_protetico.SelectedIndex = _clFuncoes.trazIndexComboBox(dr(18).ToString, dr(18).ToString.Length, cbo_protetico)
                End If

                If dr(19).ToString.Equals("") = False Then
                    cbo_tpAtendimento.SelectedIndex = _clFuncoes.trazIndexComboBox(dr(19).ToString, dr(19).ToString.Length, cbo_tpAtendimento)
                End If

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
        Me.txt_taxa.Text = "0,00"
        Me.txt_vlrTaxa.Text = "0,00"
        Me.txt_valor.Text = "0,00"
        Me.txt_situacao.Text = "N"
        Me.msk_dtpaga.Enabled = False : Me.msk_dtpaga.Text = ""
        Me.txt_juros.Enabled = False
        Cbo_tipo.SelectedIndex = 0
        If _Incluindo = False Then
            Me.lbl_parcelas.Visible = False : Me.txt_qtdeParcelas.Visible = False
        End If

    End Sub

    Private Sub txt_fatura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_fatura.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True

    End Sub

    Private Sub txt_fatura_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fatura.Leave

        If txt_documento.Text.Equals("") = False Then Return
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
                           Me.Cbo_tipo.SelectedItem, Me.Cbo_Banco.SelectedItem, Me.txt_taxa.Text, Me.txt_vlrTaxa.Text, _
                          Me.txt_historico.Text)

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
                           Me.Cbo_tipo.SelectedItem, Me.Cbo_Banco.SelectedItem, Me.txt_taxa.Text, Me.txt_vlrTaxa.Text, _
                           Me.txt_historico.Text)

                    transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                    MsgBox("Registros Atualizados com Sucesso", MsgBoxStyle.Exclamation, "METROSYS")
                    Me.Close()
                Else

                    alterandoRegistro(conexao, transacao, _geno001.pCodig, Me.txt_codPart.Text, Me.txt_fatura.Text, _
                           Me.txt_documento.Text, dtp_emissao.Value, dtp_vencto.Value, Me.txt_valor.Text, _
                           _dtPagaAux, Me.txt_juros.Text, Me.txt_desconto.Text, Me.txt_situacao.Text, _
                           Me.Cbo_tipo.SelectedItem, Me.Cbo_Banco.SelectedItem, Me.txt_taxa.Text, Me.txt_vlrTaxa.Text, _
                           Me.txt_historico.Text)

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


    Private Sub alterandoRegistro(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                ByVal CodGeno As String, ByVal CodForn As String, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As Date, _
                ByVal Juros As Decimal, ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, _
                ByVal Banco As String, ByVal taxa As Double, ByVal vlrTaxa As Double, ByVal Historico As String)

        Dim doutor As String = "", hora As String = ""
        doutor = _Dentista.Nome
        hora = txt_hora.Text
        Tipo = Tipo.Substring(0, 2)
        Banco = Banco.Substring(0, 3)
        

        _clBD.altRecebimentoFatd001(_geno001, conexao, transacao, _idRecebimento, CodGeno, CodForn, Fatura, Documento, DtEmissao, DtVencto, _
                                  Valor, "", Juros, Descontos, Situacao, Tipo, Banco, taxa, vlrTaxa, 0, doutor, hora, _Protetico, _TpAtendimento, Historico)

    End Sub

    Private Sub alterandoRegistroAll(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                ByVal CodGeno As String, ByVal CodForn As String, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As Date, _
                ByVal Juros As Decimal, ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, _
                ByVal Banco As String, ByVal taxa As Double, ByVal vlrTaxa As Double, ByVal Historico As String)

        Dim doutor As String = "", hora As String = ""
        doutor = _Dentista.Nome
        hora = txt_hora.Text
        Tipo = Tipo.Substring(0, 2)
        Banco = Banco.Substring(0, 3)


        _clBD.altRecebimentoFatd001All(_geno001, conexao, transacao, Fatura, Valor, taxa, vlrTaxa, Tipo)

    End Sub


    Private Sub inclueRegistro(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                ByVal CodGeno As String, ByVal CodForn As String, ByVal Fatura As String, ByVal Documento As String, _
                ByVal DtEmissao As Date, ByVal DtVencto As Date, ByVal Valor As Decimal, ByVal DtPaga As Date, _
                ByVal Juros As Decimal, ByVal Descontos As Decimal, ByVal Situacao As String, ByVal Tipo As String, _
                ByVal Banco As String, ByVal taxa As Double, ByVal vlrTaxa As Double, ByVal Historico As String)

        Dim doutor As String = "", hora As String = ""
        doutor = _Dentista.Nome

        hora = txt_hora.Text
        Tipo = Tipo.Substring(0, 2)
        Banco = Banco.Substring(0, 3)

        _clBD.incDuplicatasR(CInt(txt_qtdeParcelas.Text), _geno001, CodForn, Tipo, Fatura, Fatura, "000", 0.0, Documento, DtEmissao, DtVencto, Valor, "00", _
                          DtPaga, Juros, Descontos, Banco, Historico, doutor, hora, "", taxa, vlrTaxa, "99", "01", "05", Situacao, _
                          False, Mid(MdlEmpresaUsu._codigo, 3, 3), 0, "", "", "", "", "", _Protetico, _TpAtendimento, conexao, transacao)

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

    Private Sub txt_valor_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valor.KeyPress, txt_juros.KeyPress, txt_desconto.KeyPress, txt_taxa.KeyPress, txt_vlrTaxa.KeyPress
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

    Private Sub txt_taxa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_taxa.Leave

        lbl_mensagem.Text = ""
        If Me.txt_taxa.Text.Equals("") Then Me.txt_taxa.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_taxa.Text) Then

            Me.txt_taxa.Text = Format(CDec(Me.txt_taxa.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "TAXA não é numérico !" : Me.txt_taxa.Focus() : Me.txt_taxa.SelectAll()
        End If

    End Sub

    Private Sub txt_vlrTaxa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vlrTaxa.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlrTaxa.Text.Equals("") Then Me.txt_vlrTaxa.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vlrTaxa.Text) Then

            Me.txt_vlrTaxa.Text = Format(CDec(Me.txt_vlrTaxa.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = "VALOR TAXA não é numérico !" : Me.txt_vlrTaxa.Focus() : Me.txt_vlrTaxa.SelectAll()
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

    Private Sub cbo_dentistas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_dentistas.SelectedIndexChanged

        Try
            If cbo_dentistas.SelectedIndex > -1 Then
                _DentistaDAO.trazDoutorLojaNome(cbo_dentistas.SelectedItem.ToString, _Geno, _Dentista)
            End If
        Catch ex As Exception
            _Dentista.zeraValores()
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If _Incluindo Then
            Me.txt_hora.Text = Mid(TimeString, 1, 5)
            Me.txt_hora.Refresh()
        End If

    End Sub

    Private Sub txt_hora_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_hora.KeyPress
        'permite só numeros:
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub cbo_protetico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_protetico.SelectedIndexChanged

        Try
            If cbo_protetico.SelectedIndex > 0 Then
                _ProteticoDAO.trazDoutorLojaNome(cbo_protetico.SelectedItem.ToString, _Geno, _Protetico)
            Else
                _Protetico.zeraValores()
            End If
        Catch ex As Exception
            _Protetico.zeraValores()
        End Try

    End Sub

    Private Sub cbo_tpAtendimento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tpAtendimento.SelectedIndexChanged

        Try
            If cbo_tpAtendimento.SelectedIndex > -1 Then
                _TpAtendimento.DAO.trazTpAtendimentoDescr(cbo_tpAtendimento.SelectedItem.ToString, _TpAtendimento)
            Else
                _TpAtendimento.ZeraValores()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txt_hora_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txt_hora.MaskInputRejected
        Timer1.Stop()
        txt_hora.ReadOnly = False
        txt_hora.SelectAll()
    End Sub
End Class
