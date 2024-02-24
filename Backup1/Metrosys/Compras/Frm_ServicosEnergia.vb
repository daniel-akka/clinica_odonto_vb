Imports System.Text
Imports Npgsql

Public Class Frm_ServicosEnergia
    Dim funcoes As New ClFuncoes
    Protected _conexao As String = MdlConexaoBD.conectionPadrao
    Dim agora As Date = Now
    Dim Xtel, xnum As New Cl_bdMetrosys
    Private _InexistBD As Integer = 0
    Private _erro As Boolean = False
    Private _msgErro As String = ""
    Public Shared _frmREf As New Frm_ServicosEnergia
    Public mbUf, mbCNPJ As String
    Public mCstIten, mCfvIten, mGrupoIten As Integer
    Public mbUndProd As String
    Dim mNF_Cfop As String
    Dim _mStrConsulta As String = ""
    Dim _mCodFonecedor As String = ""
    Public _mPesquisaForn As Boolean = False
    Dim cl_BD As New Cl_bdMetrosys
    Dim cl_funcoes As New ClFuncoes
    Dim _BuscaForn As New Frm_buscaFornecedor


    Private Sub Frm_ServicosEnergia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Try
                    Frm_ManEnergia.dgEnergia.Focus()
                    Frm_ManEnergia.atualizaDgEnergia()
                    Me.Close()
                Catch ex As Exception
                End Try

            Case Keys.F2
                Me.btn_incluir.Focus()
            Case Keys.F4
                Me.btn_cancela.Focus()
            Case Keys.Enter
                e.Handled = True
                SendKeys.Send("{TAB}")
        End Select

    End Sub

    Private Sub Frm_ServicosEnergia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txt_serie.Text = "1"
        Me.msk_emissao.Text = Format(Date.Now, "ddMMyyyy")
        Me.msk_vencto.Text = Format(Date.Now, "ddMMyyyy")
        Me.msk_dtentrada.Text = Format(Date.Now, "ddMMyyyy")
        Me.msk_mesano.Text = Mid(msk_emissao.Text, 4, 7).ToString
        Me.txt_vlconsumo.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_outdesp.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_abatimento.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_tgeral.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_aliq.Text = Format(Convert.ToDouble(0.0), "#0.00")
        Me.txt_bcalc.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_icmscred.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_isento.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_outras.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_txiluminacao.Text = Format(Convert.ToDouble(0.0), "##,##0.00")

    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles msk_vencto.KeyPress, msk_mesano.KeyPress, msk_emissao.KeyPress, msk_dtentrada.KeyPress
        Me.msk_emissao.BackColor = Color.White
        Me.msk_dtentrada.BackColor = Color.White
        Me.msk_mesano.BackColor = Color.White
        Me.msk_vencto.BackColor = Color.White

        'permite só numeros
        If Char.IsLetter(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub cboMun_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMun.KeyPress
        If Char.IsLower(e.KeyChar) Then
            'Vai converter o texto para caixa alta
            cboMun.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Private Sub cboMun_LostFocus() Handles cboMun.LostFocus
        Me.txt_municipio.Text = cboMun.Text
    End Sub


    'Private Sub cbo_classe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_tpligacao.KeyDown, cbo_tensao.KeyDown, cbo_cst.KeyDown, cbo_classe.KeyDown, cbo_cfop.KeyDown
    '    If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_nomePart.KeyDown
        Select Case e.KeyCode
            Case Keys.B
                _frmREf = Me
                Dim _frm_buscaParticipante As New Frm_buscaFornecedor
                _frm_buscaParticipante.set_frmRef(Me)
                _frm_buscaParticipante.Show()
                _frm_buscaParticipante = Nothing
                'Me.Hide()
            Case Keys.Enter
                'Me.txt_nomePart.Text = _frm_buscaParticipante._nomeParticipante
            Case Keys.Tab
                'Me.txt_nomePart.Text = _frm_buscaParticipante._nomeParticipante
        End Select

    End Sub

    Private Sub txt_codPart_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codPart.LostFocus
        If (Me.txt_codPart.Text) = "" Then
            _mPesquisaForn = False
            Dim BuscaForn As New Frm_buscaFornecedor
            _frmREf = Me
            BuscaForn.set_frmRef(_frmREf)
            BuscaForn.ShowDialog()
        End If

    End Sub

    Private Sub txt_vlconsumo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_vlconsumo.LostFocus
        If IsNumeric(Me.txt_vlconsumo.Text) Then
            Me.txt_tgeral.Text = Format(Convert.ToDouble(Me.txt_vlconsumo.Text), "##,##0.00")
        End If

    End Sub

    Private Sub txt_txiluminacao_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_txiluminacao.LostFocus
        If IsNumeric(Me.txt_txiluminacao.Text) Then
            Dim Vilumim, vconsum As Double
            Vilumim = Convert.ToDouble(Me.txt_txiluminacao.Text)
            vconsum = Convert.ToDouble(Me.txt_vlconsumo.Text)
            Me.txt_tgeral.Text = Format(Convert.ToDouble(Vilumim + vconsum), "##,##0.00")
        End If

    End Sub

    Private Sub txt_outdesp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_outdesp.LostFocus
        If IsNumeric(Me.txt_outdesp.Text) Then
            Dim Vilumim, vconsum, voutdesp As Double
            Vilumim = Convert.ToDouble(Me.txt_txiluminacao.Text)
            vconsum = Convert.ToDouble(Me.txt_vlconsumo.Text)
            voutdesp = Convert.ToDouble(Me.txt_outdesp.Text)
            Me.txt_tgeral.Text = Format(Convert.ToDouble(Vilumim + vconsum + voutdesp), "###,##0.00")
        End If

    End Sub

    Private Sub cbo_cst_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_cst.LostFocus
        Dim TimOutras As Double
        If cbo_cst.SelectedIndex <= 2 Then
            Me.txt_bcalc.Text = Format(Convert.ToDouble(Me.txt_vlconsumo.Text), "###,##0.00")
            Me.txt_aliq.Text = "25,00"
        End If

        If cbo_cst.SelectedIndex >= 3 And cbo_cst.SelectedIndex <= 5 Then
            Me.txt_bcalc.Text = Format(Convert.ToDouble(0.0), "###,##0.00")
            Me.txt_aliq.Text = "0,00"
            TimOutras = "0.00"
            Me.txt_icmscred.Text = "0,00"
            txt_outras.Text = Format(Convert.ToDouble(TimOutras), "###,##0.00")
        End If

        If cbo_cst.SelectedIndex = 7 Then
            txt_isento.Text = "0,00"
            Me.txt_aliq.Text = "0,00"
            Me.txt_bcalc.Text = "0,00"
            Me.txt_icmscred.Text = "0,00"
            TimOutras = (Convert.ToDouble(txt_tgeral.Text))
            txt_outras.Text = Format(Convert.ToDouble(TimOutras), "###,##0.00")
        End If
    End Sub

    Private Sub txt_aliq_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_aliq.LostFocus
        If IsNumeric(Me.txt_aliq.Text) Then
            Dim TicmCred As Double
            If Convert.ToDouble(txt_aliq.Text) > 0.0 Then
                TicmCred = (Convert.ToDouble(txt_bcalc.Text) * Convert.ToDouble(Me.txt_aliq.Text) / 100)
                Me.txt_icmscred.Text = Format(Convert.ToDouble(TicmCred), "###,##0.00")
            End If
            If cbo_cst.SelectedIndex >= 3 And cbo_cst.SelectedIndex <= 5 Then
                Dim TimOutras As Double
                TimOutras = (Convert.ToDouble(txt_tgeral.Text) - (Convert.ToDouble(txt_bcalc.Text)))
                txt_isento.Text = Format(Convert.ToDouble(TimOutras), "###,##0.00")
            End If

        End If

    End Sub

    Private Sub txt_isento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_isento.LostFocus
        If IsNumeric(Me.txt_isento.Text) Then
            Dim TimOutras As Double
            If cbo_cst.SelectedIndex <= 2 Then
                TimOutras = (Convert.ToDouble(txt_tgeral.Text) - (Convert.ToDouble(txt_bcalc.Text)))
                txt_outras.Text = Format(Convert.ToDouble(TimOutras), "###,##0.00")
            End If
            If cbo_cst.SelectedIndex = 7 Then
                txt_isento.Text = "0,00"
                Me.txt_aliq.Text = "0,00"
                Me.txt_bcalc.Text = "0,00"
                Me.txt_icmscred.Text = "0,00"
                TimOutras = (Convert.ToDouble(txt_tgeral.Text))
                txt_outras.Text = Format(Convert.ToDouble(TimOutras), "###,##0.00")
            End If

        End If

    End Sub

    Private Sub txt_icmscred_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_icmscred.LostFocus

        If cbo_cst.SelectedIndex = 7 Then
            txt_isento.Text = "0,00"
            'Dim procID As Integer
            'procID = Shell("\install.exe", AppWinStyle.NormalFocus)
            'Argumento Comportamento
            'vbHide - Roda o programa, mas deixa escondido
            'vbNormalFocus - Roda o programa e abre a janela no tamanho normal já deixando o foco sobre o programa aberto.
            'vbNormalNoFocus - Roda o programa e abre a janela no tamanho normal, mas deixa o foco sobre o aplicativo atual.
            'vbMinimizedFocus - Abre minimizado, com o foco no programa aberto
            'vbMinimizedNoFocus - Abre minimizado, com o foco no aplicativo atual
            'vbMaximizedFocus - Abre maximizado, com o foco no programa aberto
            'vbMaximizedNoFocus - Abre maximizado, com o foco no aplicativo atual

        End If
    End Sub

    Private Sub btn_cancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancela.Click
        Frm_ManEnergia.dgEnergia.Focus()
        Frm_ManEnergia.atualizaDgEnergia()
        Me.Close()
    End Sub

    Private Sub txt_abatimento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_abatimento.LostFocus
        If IsNumeric(Me.txt_abatimento.Text) Then
            Dim Vilumim, vconsum, voutdesp, vabatim As Double
            Vilumim = Convert.ToDouble(Me.txt_txiluminacao.Text)
            vconsum = Convert.ToDouble(Me.txt_vlconsumo.Text)
            voutdesp = Convert.ToDouble(Me.txt_outdesp.Text)
            vabatim = Convert.ToDouble(Me.txt_abatimento.Text)
            Me.txt_tgeral.Text = Format(Convert.ToDouble((Vilumim + vconsum + voutdesp) - vabatim), "###,##0.00")

        End If

    End Sub

    Private Sub txt_outras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_outras.TextChanged
        If IsNumeric(Me.txt_outras.Text) AndAlso CDbl(txt_outras.Text) > 0.0 Then
            TabControl1.Enabled = True
        Else
            TabControl1.Enabled = False
        End If
    End Sub

    Private Sub txt_outras_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_outras.LostFocus
        If IsNumeric(Me.txt_outras.Text) AndAlso CDbl(txt_outras.Text) > 0.0 Then
            TabControl1.Enabled = True
        Else
            TabControl1.Enabled = False
        End If
    End Sub

    'INCLUIR...
    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click
        If Me.btn_incluir.Text.Equals("&Inclui") AndAlso validaValores() = True Then
            Dim numero As String = (Me.txt_numero.Text \ 1)
            Dim serie As String = Me.txt_serie.Text
            Dim subserie As String = Me.txt_subSerie.Text
            Dim emissao As Date = CDate(Me.msk_emissao.Text)
            Dim dtentrada As Date = CDate(Me.msk_dtentrada.Text)
            Dim mesano As String = Me.msk_mesano.Text
            Dim vencto As Date = CDate(Me.msk_vencto.Text)
            Dim cliente As String = Me.txt_codPart.Text
            Dim classe As Integer = Me.cbo_classe.Text.Substring(0, 1) \ 1
            Dim inscr As String = Me.txt_inscricao.Text
            Dim consumo As String = Me.txt_consumo.Text
            Dim tipo As Integer = Me.cbo_tpligacao.Text.Substring(0, 1)
            Dim tensao As Integer = (Me.cbo_tensao.Text.Substring(0, 2) \ 1)
            Dim vlConsumo As Double = CDbl(Me.txt_vlconsumo.Text)
            Dim taxapub As Double = CDbl(Me.txt_txiluminacao.Text)
            Dim outdesp As String = CDbl(Me.txt_outdesp.Text)
            Dim abatim As String = CDbl(Me.txt_abatimento.Text)
            Dim tgeral As Double = CDbl(Me.txt_tgeral.Text)
            Dim cfop As String = Me.cbo_cfop.Text.Substring(0, 1) & Me.cbo_cfop.Text.Substring(2, 3)
            Dim cst As String = Me.cbo_cst.Text.Substring(0, 2)
            Dim bcalc As Double = CDbl(Me.txt_bcalc.Text)
            Dim aliq As Double = CDbl(Me.txt_aliq.Text)
            Dim icmcred As Double = CDbl(Me.txt_icmscred.Text)
            Dim isento As Double = CDbl(Me.txt_isento.Text)
            Dim outros As Double = CDbl(Me.txt_outras.Text)

            'inseri ServicoEnergia
            Dim FuncoesBD As New Cl_bdMetrosys
            FuncoesBD.IncServErnegia(numero, serie, subserie, emissao, dtentrada, mesano, vencto, cliente, classe, inscr, _
                                     consumo, tipo, tensao, vlConsumo, taxapub, outdesp, abatim, tgeral, cfop, cst, bcalc, aliq, _
                                     icmcred, isento, outros, _conexao)

            Me.zeraValores()
            'Frm_ManEnergia.dgEnergia.Focus()
            'Frm_ManEnergia.atualizaDgEnergia()
            FuncoesBD = Nothing
        End If

    End Sub

    Private Function validaValores() As Boolean
        Dim valoresOK As Boolean = True

        'valida serie da nota
        If Me.txt_serie.Text = "" OrElse funcoes.existCaracEspeciais(Me.txt_serie.Text) = True Then
            valoresOK = False
            Me.txt_serie.BackColor = Color.Red
            Me.txt_serie.Focus()
            Me.txt_serie.SelectAll()
            Return valoresOK
        End If

        'valida subserie da nota
        If Me.txt_subSerie.Text <> "" Then
            If funcoes.existCaracEspeciais(Me.txt_subSerie.Text) = True Then
                valoresOK = False
                Me.txt_subSerie.BackColor = Color.Red
                Me.txt_subSerie.Focus()
                Me.txt_subSerie.SelectAll()
                Return valoresOK
            End If
        End If

        'valida numero da nota
        If Not IsNumeric(Me.txt_numero.Text) OrElse funcoes.IsInteiro(Me.txt_numero.Text) = False Then
            valoresOK = False
            Me.txt_numero.BackColor = Color.Red
            Me.txt_numero.Focus()
            Me.txt_numero.SelectAll()
            Return valoresOK

        ElseIf funcoes.existNfEnergia_Tabela(Me.txt_numero.Text, Me.txt_codPart.Text, _conexao) = True Then
            MsgBox("Esta Nota já existe no Banco de Dados!", MsgBoxStyle.Exclamation, "GENOV")
            valoresOK = False
            Me.txt_numero.BackColor = Color.Red
            Me.txt_numero.Focus()
            Me.txt_numero.SelectAll()
            Return valoresOK

        Else
            Me.txt_numero.BackColor = Color.White
        End If

        'valida datas da nota
        If Not IsDate(Me.msk_emissao.Text) Then
            valoresOK = False
            MsgBox("valor da Data de Emissão não é Data", MsgBoxStyle.Exclamation)
            Me.msk_emissao.BackColor = Color.Red
            Me.msk_emissao.Focus()
            Me.msk_emissao.SelectAll()
            Return valoresOK

        ElseIf Not IsDate(Me.msk_dtentrada.Text) Then
            MsgBox("valor da Data de Entrada não é Data", MsgBoxStyle.Exclamation)
            valoresOK = False
            Me.msk_dtentrada.BackColor = Color.Red
            Me.msk_dtentrada.Focus()
            Me.msk_dtentrada.SelectAll()
            Return valoresOK

        ElseIf CDate(Me.msk_emissao.Text) > CDate(Me.msk_dtentrada.Text) Then
            valoresOK = False
            MsgBox("Data de Emissão deve ser menor ou igual a Data de Entrada", MsgBoxStyle.Exclamation)
            Me.msk_emissao.BackColor = Color.Red
            Me.msk_emissao.Focus()
            Me.msk_emissao.SelectAll()
            Return valoresOK

        ElseIf Not IsDate(Me.msk_vencto.Text) Then
            MsgBox("valor da Data de Vencimento não é Data", MsgBoxStyle.Exclamation)
            valoresOK = False
            Me.msk_vencto.BackColor = Color.Red
            Me.msk_vencto.Focus()
            Me.msk_vencto.SelectAll()
            Return valoresOK

        ElseIf CDate(Me.msk_vencto.Text) <= CDate(Me.msk_emissao.Text) Then
            MsgBox("Data de Vencimento tem que ser maior do que a Data de Emissão", MsgBoxStyle.Exclamation)
            valoresOK = False
            Me.msk_vencto.BackColor = Color.Red
            Me.msk_vencto.Focus()
            Me.msk_vencto.SelectAll()
            Return valoresOK

        End If

        'valida Codigo Participante
        If funcoes.existPart_Tabela(Me.txt_codPart.Text, _conexao) = False Then
            valoresOK = False
            Me.txt_codPart.BackColor = Color.Red
            Me.txt_codPart.Focus()
            Me.txt_codPart.SelectAll()
            Return valoresOK
        End If

        'valida MesAno
        If Not IsDate(Me.msk_mesano.Text) Then
            valoresOK = False
            Me.msk_mesano.BackColor = Color.Red
            Me.msk_mesano.Focus()
            Me.msk_mesano.SelectAll()
            Return valoresOK
        End If

        'valida numero do cliente
        If funcoes.IsInteiro(Me.txt_cliente.Text) = False Then
            valoresOK = False
            Me.txt_cliente.BackColor = Color.Red
            Me.txt_cliente.Focus()
            Me.txt_cliente.SelectAll()
            Return valoresOK
        End If

        'verifica valor do consumo
        If Not IsNumeric(Me.txt_vlconsumo.Text) OrElse CDbl(Me.txt_vlconsumo.Text) <= 0 Then
            MsgBox("Valor do Consumo tem que ser Maior que ZERO!", MsgBoxStyle.Exclamation)
            valoresOK = False
            Me.txt_vlconsumo.BackColor = Color.Red
            Me.txt_vlconsumo.Focus()
            Me.txt_vlconsumo.SelectAll()
            Return valoresOK
        End If

        'valida todos os ComboBox...
        If verifCombBoxOK(Me.cbo_classe) = False OrElse verifCombBoxOK(Me.cbo_tpligacao) = False OrElse _
        verifCombBoxOK(Me.cbo_tensao) = False OrElse verifCombBoxOK(Me.cbo_cfop) = False OrElse _
        verifCombBoxOK(Me.cbo_cst) = False Then

            valoresOK = False
            Return valoresOK
        End If

        If verifVlrTextBox(Me.txt_txiluminacao) = False OrElse verifVlrTextBox(Me.txt_outdesp) = False OrElse _
        verifVlrTextBox(Me.txt_abatimento) = False OrElse verifVlrTextBox(Me.txt_bcalc) = False OrElse _
        verifVlrTextBox(Me.txt_aliq) = False OrElse verifVlrTextBox(Me.txt_icmscred) = False OrElse _
        verifVlrTextBox(Me.txt_isento) = False OrElse verifVlrTextBox(Me.txt_outras) = False Then
            valoresOK = False
        End If

        'verifica valor total
        If Not IsNumeric(Me.txt_tgeral.Text) OrElse CDbl(Me.txt_tgeral.Text) <= 0 Then
            valoresOK = False
            Me.txt_tgeral.BackColor = Color.Red
            Me.txt_tgeral.Focus()
            Me.txt_tgeral.SelectAll()
            Return valoresOK

        End If

        Return valoresOK
    End Function

    Private Function verifCombBoxOK(ByVal comboBox As ComboBox) As Boolean
        Dim combOK As Boolean = True

        If comboBox.Equals(Me.cbo_classe) Then
            If Me.cbo_classe.SelectedIndex < 0 Then 'selecionou nenhum item
                combOK = False
            Else

                Select Case Me.cbo_classe.Text.Substring(0, 1)
                    Case "1" 'Residencial
                    Case "2" 'Industria
                    Case "3" 'Comércio e Serviço
                    Case "4" 'Rural
                    Case "5" 'Poder Público
                    Case "6" 'Iluminação Pública
                    Case "7" 'Serviço Público
                    Case "8" 'Consumo Próprio
                    Case "9" 'Revenda
                    Case Else
                        combOK = False
                End Select
            End If

        ElseIf comboBox.Equals(Me.cbo_tpligacao) Then
            If Me.cbo_tpligacao.SelectedIndex < 0 Then 'selecionou nenhum item
                combOK = False
            Else
                Select Case Me.cbo_tpligacao.Text.Substring(0, 1)
                    Case "1" 'Monofásico
                    Case "2" 'Bifasico
                    Case "3" 'Trífasico
                    Case Else
                        combOK = False
                End Select
            End If

        ElseIf comboBox.Equals(Me.cbo_tensao) Then
            If Me.cbo_tensao.SelectedIndex < 0 Then 'selecionou nenhum item
                combOK = False
            Else
                Select Case Trim(Me.cbo_tensao.Text.Substring(0, 2))
                    Case "01" 'A-1 - 230 kV ou mais
                    Case "02" 'A-2 - 88 a 138 kV
                    Case "03" 'A-3 - 69 kV
                    Case "04" 'A-3a - 30 a 44 kV
                    Case "05" 'A-4 - 2,3 a 13,8 kV
                    Case "06" 'AS - Alta Tensão Bubterrâneo
                    Case "07" 'B-1 - Residencial
                    Case "08" 'B-1  - Residencial Baixa Renda
                    Case "09" 'B-2  - Rural
                    Case "10" 'B-2  - Cooperativa de utilização rural
                    Case "11" 'B-2  - Serviço público de irrigação
                    Case "12" 'B-3  - Demais classes
                    Case "13" 'B-4a  - Iluminação Pública - rede de distribuiçao
                    Case "14" 'B-4b  - Iluminação Pública -bulbo de lâmpada
                    Case Else
                        combOK = False
                End Select

            End If

        ElseIf comboBox.Equals(Me.cbo_cfop) Then
            If Me.cbo_cfop.SelectedIndex < 0 Then 'selecionou nenhum item
                combOK = False
            Else
                Dim cfop As String = Me.cbo_cfop.Text.Substring(0, 1) & Me.cbo_cfop.Text.Substring(2, 3)
                If funcoes.IsInteiro(cfop) = False Then
                    combOK = False
                Else
                    If existCFOP_Tabela(cfop) = False Then combOK = False
                End If
                cfop = Nothing
            End If

        ElseIf comboBox.Equals(Me.cbo_cst) Then
            If Me.cbo_cst.SelectedIndex < 0 Then
                combOK = False
            Else
                Select Case Me.cbo_cst.Text.Substring(0, 2)
                    Case "00" 'Trib. Integral
                    Case "10" 'Trib. Icms/Subst.
                    Case "20" 'Com Redução
                    Case "30" 'Isenta /Não Trib.
                    Case "40" 'Isenta
                    Case "41" 'Não Tributada
                    Case "51" 'Diferimento
                    Case "60" 'ICMS Substituto
                    Case "70" 'Redução e Icms p/ Subst.
                    Case "90" 'Outros
                    Case Else
                        combOK = False
                End Select
            End If

        End If

        If combOK = False Then
            comboBox.BackColor = Color.Red
            comboBox.SelectAll()
            comboBox.Focus()
        End If

        Return combOK
    End Function

    Private Function verifVlrTextBox(ByVal editText As TextBox) As Boolean
        If IsNumeric(editText.Text) Then
            Return True
        Else
            editText.BackColor = Color.Red
            editText.SelectAll()
            editText.Focus()
            Return False
        End If
    End Function

    Private Function existCFOP_Tabela(ByVal cfop As String) As Boolean
        Dim oConnMunicipios As NpgsqlConnection = New NpgsqlConnection(_conexao)
        Me._erro = False
        Me._msgErro = ""

        Try
            oConnMunicipios.Open()
        Catch ex As Exception
            Me._erro = True
            Me._msgErro = "Banco de Dados Inexistente!"
        End Try


        Dim CmdMunicipios As New NpgsqlCommand
        Dim SqlCmdMunicipios As New StringBuilder
        Dim drMunicipios As NpgsqlDataReader
        Dim UF As String = cboUF.Text

        Try
            SqlCmdMunicipios.Append("SELECT * FROM cadnatu WHERE r_cdfis = '" & cfop.Substring(0, 1) & "." & cfop.Substring(1, 3) & "' LIMIT 1")
            CmdMunicipios = New NpgsqlCommand(SqlCmdMunicipios.ToString, oConnMunicipios)
            drMunicipios = CmdMunicipios.ExecuteReader

            If drMunicipios.HasRows = False Then
                _erro = True
            End If

        Catch ex As Exception
            Me._erro = True
            Me._msgErro = "Tabela de CFOP Inexistente!"
        End Try

        oConnMunicipios.ClearPool() : oConnMunicipios.Close()
        CmdMunicipios = Nothing : SqlCmdMunicipios = Nothing : drMunicipios = Nothing


        oConnMunicipios = Nothing
        If _erro = False Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub txt_tgeral_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tgeral.GotFocus
        Me.txt_tgeral.BackColor = Color.White
    End Sub

    Private Sub cbo_classe_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tpligacao.LostFocus, cbo_tensao.LostFocus, cbo_cst.LostFocus, cbo_classe.LostFocus, cbo_cfop.LostFocus
        Me.cbo_classe.BackColor = Color.White
        Me.cbo_tpligacao.BackColor = Color.White
        Me.cbo_tensao.BackColor = Color.White
        Me.cbo_cfop.BackColor = Color.White
        Me.cbo_cst.BackColor = Color.White
    End Sub

    Private Sub cbo_tpligacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tpligacao.Click, cbo_tensao.Click, cbo_cst.Click, cbo_classe.Click, cbo_cfop.Click
        Me.cbo_classe.BackColor = Color.White
        Me.cbo_tpligacao.BackColor = Color.White
        Me.cbo_tensao.BackColor = Color.White
        Me.cbo_cfop.BackColor = Color.White
        Me.cbo_cst.BackColor = Color.White
    End Sub

    Private Sub cbo_tpligacao_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tpligacao.DropDown, cbo_tensao.DropDown, cbo_cst.DropDown, cbo_classe.DropDown, cbo_cfop.DropDown
        Me.cbo_classe.BackColor = Color.White
        Me.cbo_tpligacao.BackColor = Color.White
        Me.cbo_tensao.BackColor = Color.White
        Me.cbo_cfop.BackColor = Color.White
        Me.cbo_cst.BackColor = Color.White

    End Sub

    Private Sub txt_outras_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'permite só numeros
        If Char.IsLetter(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub zeraValores()
        Me.txt_serie.Text = "1"
        Me.txt_subSerie.Text = ""
        Me.txt_numero.Text = ""
        Me.txt_codPart.Text = ""
        Me.txt_nomePart.Text = ""
        Me.txt_cliente.Text = ""
        Me.msk_emissao.Text = Format(Date.Now, "ddMMyyyy")
        Me.msk_vencto.Text = Format(Date.Now, "ddMMyyyy")
        Me.msk_dtentrada.Text = Format(Date.Now, "ddMMyyyy")
        Me.msk_mesano.Text = Mid(msk_emissao.Text, 4, 7).ToString
        Me.txt_vlconsumo.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_outdesp.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_abatimento.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_tgeral.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_aliq.Text = Format(Convert.ToDouble(0.0), "#0.00")
        Me.txt_bcalc.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_icmscred.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_isento.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_outras.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_txiluminacao.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.cbo_classe.Text = ""
        Me.cbo_tpligacao.Text = ""
        Me.cbo_tensao.Text = ""
        Me.cbo_cfop.Text = ""
        Me.cbo_cst.Text = ""

        Me.txt_serie.Focus()
    End Sub

    Private Sub txt_serie_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_vlconsumo.KeyPress, txt_txiluminacao.KeyPress, txt_tgeral.KeyPress, txt_subSerie.KeyPress, txt_serie.KeyPress, txt_outras.KeyPress, txt_outdesp.KeyPress, txt_numero.KeyPress, txt_isento.KeyPress, txt_inscricao.KeyPress, txt_icmscred.KeyPress, txt_consumo.KeyPress, txt_codPart.KeyPress, txt_cliente.KeyPress, txt_bcalc.KeyPress, txt_aliq.KeyPress, txt_abatimento.KeyPress
        Me.txt_serie.BackColor = Color.White
        Me.txt_subSerie.BackColor = Color.White
        Me.txt_numero.BackColor = Color.White
        Me.txt_codPart.BackColor = Color.White
        Me.txt_cliente.BackColor = Color.White
        Me.txt_inscricao.BackColor = Color.White
        Me.txt_consumo.BackColor = Color.White
        Me.txt_vlconsumo.BackColor = Color.White
        Me.txt_txiluminacao.BackColor = Color.White
        Me.txt_outdesp.BackColor = Color.White
        Me.txt_abatimento.BackColor = Color.White
        Me.txt_tgeral.BackColor = Color.White
        Me.txt_bcalc.BackColor = Color.White
        Me.txt_aliq.BackColor = Color.White
        Me.txt_icmscred.BackColor = Color.White
        Me.txt_isento.BackColor = Color.White
        Me.txt_outras.BackColor = Color.White

    End Sub

    Private Sub cboUF_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUF.Leave
        If cboUF.SelectedIndex >= 0 Then
            Me.cboMun = cl_funcoes.PreenchComboMunicipios(Me.cboUF.Text, Me.cboMun, MdlConexaoBD.conectionPadrao)
        End If
    End Sub

End Class