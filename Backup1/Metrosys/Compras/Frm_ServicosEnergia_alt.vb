Imports Npgsql
Imports System.Text

Public Class Frm_ServicosEnergia_alt
    Private funcoes As New ClFuncoes
    Private id_servenergia As Integer
    Private numeroNF As String
    Private _erro As Boolean = False
    Private _msgErro As String = ""

    Private Sub Frm_ServicosEnergia_alt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        id_servenergia = Frm_ManEnergia._frmREfManEnergia.dgEnergia.CurrentRow.Cells(5).Value.ToString \ 1
        numeroNF = Frm_ManEnergia._frmREfManEnergia.dgEnergia.CurrentRow.Cells(1).Value.ToString
        Me.preencheForm()

    End Sub

    Public Sub preencheForm()
        Dim oConnBDGENOV As New NpgsqlConnection(_conexao)

        Try

            oConnBDGENOV.Open()
        Catch ex As Exception

            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return
        End Try


        Dim sqlEnergia As New StringBuilder
        Dim cmdEnergia As NpgsqlCommand
        Dim daEnergia As NpgsqlDataAdapter
        Dim drEnergia As NpgsqlDataReader
        Dim dsEnergia As New DataTable

        Try
            sqlEnergia.Append("SELECT en_serie, en_subserie, en_numero, en_emissao, en_dtentrada, en_cliente, SUBSTR(cad.p_portad, 1, 60), ")
            sqlEnergia.Append("en_mesano, en_vencto, en_classe, en_inscr, en_consumo, en_tipo, en_tensao, en_vlconsumo, en_taxapub, ")
            sqlEnergia.Append("en_outdesp, en_abatim, en_tgeral, en_cfop, en_cst, en_bcalc, en_aliq, en_icmcred, ")
            sqlEnergia.Append("en_isento, en_outros FROM " & MdlEmpresaUsu._esqEstab & ".servenergia LEFT JOIN cadp001 cad ON ")
            sqlEnergia.Append("cad.p_cod = en_cliente WHERE en_id = " & id_servenergia)
            cmdEnergia = New NpgsqlCommand(sqlEnergia.ToString, oConnBDGENOV)
            drEnergia = cmdEnergia.ExecuteReader

            Dim mSerie, mSubserie, mNumero, mDtemissao, mDtEntrada, mCodPart, mNomePart, mMesano, mDtVenc As String
            Dim mNumClient, mClasse, mInscricao, mConsumo, mTpligacao, mTensao, mVlcomsumo, mTxiluminacao As String
            Dim mOutrasdep, mAbatimento, mVltotal, mCfop, mCst, mBcicms, mAliquota, mIcmscredito, mIsento As String
            Dim mOutras, mCfopCbo, mCstCbo As String

            While drEnergia.Read
                mSerie = drEnergia(0)
                mSubserie = drEnergia(1)
                mNumero = drEnergia(2)
                mDtemissao = drEnergia(3)
                mDtEntrada = drEnergia(4)
                mCodPart = drEnergia(5)
                mNomePart = drEnergia(6)
                mMesano = drEnergia(7)
                mDtVenc = drEnergia(8)
                mClasse = drEnergia(9)
                mNumClient = drEnergia(10)
                mInscricao = drEnergia(10)
                mConsumo = drEnergia(11)
                mTpligacao = drEnergia(12)
                mTensao = drEnergia(13)
                mVlcomsumo = drEnergia(14)
                mTxiluminacao = drEnergia(15)
                mOutrasdep = drEnergia(16)
                mAbatimento = drEnergia(17)
                mVltotal = drEnergia(18)
                mCfop = drEnergia(19)
                mCst = drEnergia(20)
                mBcicms = drEnergia(21)
                mAliquota = drEnergia(22)
                mIcmscredito = drEnergia(23)
                mIsento = drEnergia(24)
                mOutras = drEnergia(25)

                Me.txt_serie.Text = mSerie
                Me.txt_subSerie.Text = mSubserie
                Me.txt_numero.Text = mNumero
                Me.msk_emissao.Text = mDtemissao
                Me.msk_dtentrada.Text = mDtEntrada
                Me.txt_codPart.Text = mCodPart
                Me.txt_nomePart.Text = mNomePart
                Me.msk_mesano.Text = mMesano
                Me.msk_vencto.Text = mDtVenc
                Me.txt_cliente.Text = mNumClient
                Me.cbo_classe.SelectedIndex = (mClasse \ 1) - 1
                Me.txt_inscricao.Text = mInscricao
                Me.txt_consumo.Text = mConsumo
                Me.cbo_tpligacao.SelectedIndex = (mTpligacao \ 1) - 1
                Me.cbo_tensao.SelectedIndex = (mTensao \ 1) - 1
                Me.txt_vlconsumo.Text = mVlcomsumo
                Me.txt_txiluminacao.Text = mTxiluminacao
                Me.txt_outdesp.Text = mOutrasdep
                Me.txt_abatimento.Text = mAbatimento
                Me.txt_tgeral.Text = mVltotal
                Me.txt_bcalc.Text = mBcicms
                Me.txt_aliq.Text = mAliquota
                Me.txt_icmscred.Text = mIcmscredito
                Me.txt_isento.Text = mIsento
                Me.txt_outras.Text = mOutras

                Dim index As Integer
                For index = 0 To Me.cbo_cfop.Items.Count - 1
                    mCfopCbo = Me.cbo_cfop.Items.Item(index).ToString.Substring(0, 1) & Me.cbo_cfop.Items.Item(index).ToString.Substring(2, 3)
                    If mCfopCbo.Equals(mCfop) Then
                        Me.cbo_cfop.SelectedIndex = index
                        Exit For
                    End If
                Next

                For index = 0 To Me.cbo_cst.Items.Count - 1
                    mCstCbo = Me.cbo_cst.Items.Item(index).ToString.Substring(0, 2)
                    If mCstCbo.Equals(mCst) Then
                        Me.cbo_cst.SelectedIndex = index
                        Exit For
                    End If
                Next

                index = Nothing
                mCfopCbo = Nothing
                mCstCbo = Nothing
            End While
            drEnergia.Close() : oConnBDGENOV.ClearPool()

            mSerie = Nothing : mSubserie = Nothing : mNumero = Nothing : mDtemissao = Nothing
            mDtEntrada = Nothing : mCodPart = Nothing : mNomePart = Nothing : mMesano = Nothing
            mDtVenc = Nothing : mClasse = Nothing : mNumClient = Nothing : mInscricao = Nothing
            mConsumo = Nothing : mTpligacao = Nothing : mTensao = Nothing : mVlcomsumo = Nothing
            mTxiluminacao = Nothing : mOutrasdep = Nothing : mAbatimento = Nothing
            mVltotal = Nothing : mCfop = Nothing : mCst = Nothing : mBcicms = Nothing
            mAliquota = Nothing : mIcmscredito = Nothing : mIsento = Nothing : mOutras = Nothing
            cmdEnergia.CommandText = ""

        Catch ex As Exception

        Finally

            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
        End Try

        sqlEnergia.Remove(0, sqlEnergia.ToString.Length)
        dsEnergia.Clear()
        'daEnergia.Dispose()

        oConnBDGENOV = Nothing : daEnergia = Nothing : cmdEnergia = Nothing
        sqlEnergia = Nothing : dsEnergia = Nothing



    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        If Me.validaValoresAlt() = True Then

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
            FuncoesBD.AtualizaServErnegia(numero, serie, subserie, emissao, dtentrada, mesano, vencto, cliente, classe, inscr, _
                                     vlConsumo, consumo, tipo, tensao, taxapub, outdesp, abatim, tgeral, cfop, cst, bcalc, aliq, _
                                     icmcred, isento, outros, id_servenergia, _conexao)

            Frm_ManEnergia.dgEnergia.Focus()
            Me.Close()
            FuncoesBD = Nothing
        End If

    End Sub

    Private Function validaValoresAlt() As Boolean
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

        ElseIf Not Me.txt_numero.Text.Equals(numeroNF) Then
            If funcoes.existNfEnergia_Tabela(Me.txt_numero.Text, Me.txt_codPart.Text, _conexao) = True Then
                MsgBox("Esta Nota já existe no Banco de Dados!", MsgBoxStyle.Exclamation, "GENOV")
                valoresOK = False
                Me.txt_numero.BackColor = Color.Red
                Me.txt_numero.Focus()
                Me.txt_numero.SelectAll()
                Return valoresOK

            End If

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
                    If existCFOP_Tabela(cfop) = False Then
                        combOK = False
                    End If
                End If
                cfop = Nothing
            End If

        ElseIf comboBox.Equals(Me.cbo_cst) Then
            If Me.cbo_cst.SelectedIndex < 0 Then 'selecionou nenhum item
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

        If oConnMunicipios.State = ConnectionState.Open Then
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
            CmdMunicipios = Nothing
            SqlCmdMunicipios = Nothing
            drMunicipios = Nothing
        End If

        oConnMunicipios = Nothing
        If _erro = False Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
