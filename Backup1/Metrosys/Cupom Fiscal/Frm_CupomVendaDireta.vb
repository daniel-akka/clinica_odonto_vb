Imports Npgsql
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.IO.StreamWriter
Imports System.IO.StreamReader
Imports System.Text.UTF8Encoding
Imports System.Text.StringBuilder

Public Class Frm_CupomVendaDireta
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Dim ECF As New ClsFuncoes_ECF.total2
    Dim _mac As String
    Dim _idImpressora As Integer
    Dim _tipoImpressora As Integer
    Private Const _valorZERO As Integer = 0

    'Objetos para o Cliente
    Dim _nomeCli, _cpfCnpjCli, _enderecoCli, _bairroCli, _cidadeCli, _cepCli As String
    Dim _codCliente As String

    'Objetos para o ORCA1PP...
    Dim _codGeno, _cfopOrca1, _dataEmissOrca1 As String
    Dim _dtSaiOrca1, _xOrca1, _tipo2Orca1, _autoOrca1 As String
    Dim _itensOrca1, _rotaOrca1 As Integer

    'Objetos para o ORCA2CC...
    Dim _orcaOrca2, _codprOrca2, _undOrca2, _cdbarraOrca2, _descricaoProd As String
    Dim _qtdeOrca2, _prunitOrca2, _prtotOrca2, _alqicmOrca2, _basesubOrca2, _vlsubOrca2 As Double
    Dim _alqdescOrca2, _vldescOrca2, _pruvendaOrca2, _baseicmOrca2, _vlicmsOrca2 As Double
    Dim _grupoOrca2, _cfv As Integer

    'Objetos pra o CUPOM FISCAL
    Dim iRetorno As Integer
    Dim NumeroCupom As String
    Dim iACK, iST1, iST2 As Integer
    Dim _Zcodigo, _Zproduto As String
    Dim _Zaliq, _mtpquant, _me_qtde, _mdecimal, _Zvalor As Double



    Private Sub Frm_CupomVendaDireta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Frm_CupomVendaDireta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        _mac = _clFuncoes.EnderecoMac()
        _idImpressora = _clFuncoes.trazIdCDCAIXA(_mac, MdlConexaoBD.conectionPadrao)


        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Me.Close()
            End Try

            'Sem o localhost está configurado para imprimir Cupom Fiscal...
            If _clBD.existeMacImpressora(conection, _mac) Then

                _tipoImpressora = _clFuncoes.trazTipoImpressora(_mac, MdlConexaoBD.conectionPadrao)

                'Traz o tipo da Impressora Fiscal...
                Select Case _tipoImpressora

                    Case 1 ' 1 - Bematech


                    Case 2 ' 2 - Daruma


                    Case 3 ' 3 - Zanthus


                    Case 4 ' 4 - Elgin


                    Case 5 ' 5 - Dataregis


                    Case 6 ' 6 - EcfOutras


                    Case 7 ' 7 - NaoFiscal


                End Select

            Else
                btn_imprime.Enabled = False
            End If
            conection.ClearPool() : conection.Close()
        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)

        Finally
            conection = Nothing
        End Try


    End Sub

    Private Sub SairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub LXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LXToolStripMenuItem.Click

        If MessageBox.Show("Deseja Tirar Leitura X ?", "Leitura X - Supervisor ", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim iRetorno As Integer

            Dim mcoo As String
            mcoo = _clFuncoes.trazValorColunaCdCaixa("ec_ncupom", _idImpressora, MdlConexaoBD.conectionPadrao)

            Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim transacao As NpgsqlTransaction
            Try
                oConnBDMETROSYS.Open()
                transacao = oConnBDMETROSYS.BeginTransaction
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
                Return

            End Try

            _clBD.altImpressoraNumCupom(oConnBDMETROSYS, transacao, _idImpressora, CInt(mcoo) + 1)

            transacao.Commit() : transacao.Dispose()
            oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()
            oConnBDMETROSYS = Nothing : transacao = Nothing


            'Traz o tipo da Impressora Fiscal...
            Select Case _tipoImpressora

                Case 1 ' 1 - Bematech
                    iRetorno = Bematech_FI_LeituraX()

                Case 2 ' 2 - Daruma
                    iRetorno = Daruma_FI_LeituraX()

                Case 3 ' 3 - Zanthus


                Case 4 ' 4 - Elgin


                Case 5 ' 5 - Dataregis


                Case 6 ' 6 - EcfOutras


                Case 7 ' 7 - NaoFiscal

            End Select

        End If



    End Sub

    Private Sub ReduçãoZToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReduçãoZToolStripMenuItem.Click

        Dim Dataz As Date
        Dataz = Now

        If MessageBox.Show("Deseja Tirar Redução Z ? ", "Redução Z - Supervisor ", MessageBoxButtons.YesNo) = DialogResult.Yes Then

            Dim mDiaUltCupom As Date = _clFuncoes.trazDiaDoUltimoCupom(_idImpressora, MdlConexaoBD.conectionPadrao)

            If _clFuncoes.existeReducaoZ(mDiaUltCupom, _idImpressora, MdlConexaoBD.conectionPadrao) Then

                MsgBox("Já foi tirada a Redução Z", MsgBoxStyle.Exclamation) : Return
            Else

                Dim ec_caixa, ec_nfabri, modeloDoc As String
                Dim numCupomInicialDia, numCupomFinalDia, CRZ, CRO As String
                Dim tgeralZ As String
                Dim totVendaBruda, mtgeral As Double

                ec_caixa = _clFuncoes.trazValorColunaCdCaixa("ec_caixa", _idImpressora, MdlConexaoBD.conectionPadrao)
                ec_caixa = Format(CInt(ec_caixa), "000")
                ec_nfabri = _clFuncoes.trazValorColunaCdCaixa("ec_nfabri", _idImpressora, MdlConexaoBD.conectionPadrao)
                CRZ = _clFuncoes.trazValorColunaCdCaixa("ec_crz", _idImpressora, MdlConexaoBD.conectionPadrao)
                CRZ = Format(CInt(CRZ) + 1, "000000")
                CRO = _clFuncoes.trazValorColunaCdCaixa("ec_cro", _idImpressora, MdlConexaoBD.conectionPadrao)
                CRO = Format(CInt(CRO), "000")
                modeloDoc = "2D"
                numCupomInicialDia = _clFuncoes.trazValorColunaCdCaixa("ec_cooinical", _idImpressora, MdlConexaoBD.conectionPadrao)
                numCupomInicialDia = Format(CInt(numCupomInicialDia), "0000000")
                numCupomFinalDia = _clFuncoes.trazValorColunaCdCaixa("ec_ncupom", _idImpressora, MdlConexaoBD.conectionPadrao)
                numCupomFinalDia = Format(CInt(numCupomFinalDia), "0000000")
                totVendaBruda = _clFuncoes.trazTotVendBrutaDiaCup4dd(mDiaUltCupom, _idImpressora, MdlConexaoBD.conectionPadrao)
                tgeralZ = _clFuncoes.trazValorColunaCdCaixa("ec_tgeral", _idImpressora, MdlConexaoBD.conectionPadrao)
                totVendaBruda = System.Math.Round(CDbl(totVendaBruda), 2)
                mtgeral = System.Math.Round(CDbl(totVendaBruda) + CDbl(tgeralZ), 2)
                tgeralZ = mtgeral


                Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Dim transacao As NpgsqlTransaction
                Try
                    oConnBDMETROSYS.Open()
                    transacao = oConnBDMETROSYS.BeginTransaction
                Catch ex As Exception
                    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
                    Return

                End Try

                _clBD.altImpressoraTGeral(oConnBDMETROSYS, transacao, _idImpressora, mtgeral)
                _clBD.altImpressoraCRZ(oConnBDMETROSYS, transacao, _idImpressora, CInt(CRZ))
                _clBD.altImpressoraCooInicial(oConnBDMETROSYS, transacao, _idImpressora, CInt(numCupomFinalDia) + 1)
                _clBD.incCup5zz("60", "M", mDiaUltCupom, ec_nfabri, ec_caixa, modeloDoc, _
                            numCupomInicialDia, numCupomFinalDia, CRZ, CRO, totVendaBruda, CDbl(tgeralZ), _
                            _idImpressora, oConnBDMETROSYS, transacao)
                _clBD.altImpressoraNumCupom(oConnBDMETROSYS, transacao, _idImpressora, CInt(numCupomFinalDia) + 1)

                transacao.Commit() : transacao.Dispose()
                oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()
                oConnBDMETROSYS = Nothing : transacao = Nothing

                '#######   Redução Z da impressora...
                Select Case _tipoImpressora

                    Case 1 ' 1 - Bematech
                        iRetorno = Bematech_FI_ReducaoZ("", "")

                    Case 2 ' 2 - Daruma
                        iRetorno = Daruma_FI_ReducaoZ("", "")

                    Case 3 ' 3 - Zanthus


                    Case 4 ' 4 - Elgin


                    Case 5 ' 5 - Dataregis


                    Case 6 ' 6 - EcfOutras


                    Case 7 ' 7 - NaoFiscal

                End Select

            End If


        End If



    End Sub

    Private Sub LMCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LMCToolStripMenuItem.Click

        Dim mFrmLerMemoria As New Frm_LerMemoriaData
        mFrmLerMemoria.ShowDialog()
    End Sub

    Private Sub CancelaCupomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelaCupomToolStripMenuItem.Click


        If MessageBox.Show("Deseja Tirar Cancelar Cupom ?", "Cancela Cupom - Supervisor ", MessageBoxButtons.YesNo) = DialogResult.Yes Then


            Select Case _clFuncoes.trazSituacaoUltimoCupom(_idImpressora, MdlConexaoBD.conectionPadrao)

                Case "N"
                    Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Dim transacao As NpgsqlTransaction
                    Try
                        oConnBDMETROSYS.Open()
                        transacao = oConnBDMETROSYS.BeginTransaction
                    Catch ex As Exception
                        MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
                        Return

                    End Try


                    '#######   Atualiza as tabelas...
                    Try

                        Dim mpedidoUltCupom As String = _clFuncoes.trazUltPedidoCupom(_idImpressora, MdlConexaoBD.conectionPadrao)
                        Dim mnumUltimoCupom As String = _clFuncoes.trazUltimoNumCupom(_idImpressora, MdlConexaoBD.conectionPadrao)
                        Dim mNovoNumCupom As Integer = CInt(mnumUltimoCupom) ' + 1


                        _clBD.altTipoCup1pp("C", mpedidoUltCupom, oConnBDMETROSYS, transacao)
                        _clBD.altTipoCup4dd("C", mpedidoUltCupom, oConnBDMETROSYS, transacao)
                        _clBD.altTipoCup6hh("C", mpedidoUltCupom, oConnBDMETROSYS, transacao)
                        _clBD.altSituacaoPedido_Orca1(mpedidoUltCupom, 6, oConnBDMETROSYS, transacao)
                        _clBD.altNumCupomCup2cc(Format(mNovoNumCupom, "0000000"), mnumUltimoCupom, oConnBDMETROSYS, transacao)
                        _clBD.altImpressoraNumCupom(oConnBDMETROSYS, transacao, _idImpressora, CInt(mNovoNumCupom + 1))
                        _clBD.devolveQtdsDoOrca2cc(mpedidoUltCupom, Mid(MdlEmpresaUsu._codigo, MdlEmpresaUsu._codigo.Length - 1, 2), _
                                                   oConnBDMETROSYS, transacao)


                    Catch ex As Exception
                        MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
                        Return

                    End Try


                    '#######  Cancelamento do Cupom
                    Select Case _tipoImpressora

                        Case 1 ' 1 - Bematech
                            iRetorno = Bematech_FI_CancelaCupom()

                        Case 2 ' 2 - Daruma
                            iRetorno = Daruma_FI_CancelaCupom()

                        Case 3 ' 3 - Zanthus


                        Case 4 ' 4 - Elgin


                        Case 5 ' 5 - Dataregis


                        Case 6 ' 6 - EcfOutras


                        Case 7 ' 7 - NaoFiscal

                    End Select
                    transacao.Commit() : oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()
                    transacao = Nothing : oConnBDMETROSYS = Nothing

                Case "C"
                    MsgBox("Último Cupom já foi cancelado!", MsgBoxStyle.Exclamation)
                    Return


            End Select

        End If


    End Sub

    Private Sub zeraValoresCupom()

        _Zcodigo = "" : _Zproduto = ""
        _Zaliq = 0 : _Zvalor = 0 : _me_qtde = 0 : _mtpquant = 0 : _mdecimal = 0

    End Sub

    Private Sub imprimirCupom(ByVal numPedido As String)


        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction
        Try
            oConnBDMETROSYS.Open()
            transacao = oConnBDMETROSYS.BeginTransaction
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
            Return

        End Try


        '#######   Pega o numero do cupom...
        NumeroCupom = Space(7)
        'Traz o tipo da Impressora Fiscal...
        Select Case _tipoImpressora
            Case 1 ' 1 - Bematech
                iRetorno = Bematech_FI_AbreCupom("")

                If iRetorno = 1 Then
                    iRetorno = Bematech_FI_NumeroCupom(NumeroCupom)

                    If iRetorno = 1 Then
                        iRetorno = Bematech_FI_RetornoImpressora(iACK, iST1, iST2)

                        If iRetorno = 1 Then

                            iRetorno = Bematech_FI_LeArquivoRetorno(NumeroCupom)

                            If iRetorno = 1 Then NumeroCupom = Format(CInt(NumeroCupom), "0000000")
                        End If
                    End If
                End If
                


            Case 2 ' 2 - Daruma
                iRetorno = Daruma_FI_NumeroCupom(NumeroCupom)

                If iRetorno = 1 Then
                    iRetorno = Daruma_FI_NumeroCupom(NumeroCupom)

                    If iRetorno = 1 Then
                        iRetorno = Daruma_FI_RetornoImpressora(iACK, iST1, iST2)

                        'If iRetorno = 1 Then

                        '    iRetorno = Bematech_FI_LeArquivoRetorno(NumeroCupom)

                        '    If iRetorno = 1 Then vcp_numero = Format(CInt(NumeroCupom), "0000000")
                        'End If
                    End If
                End If


            Case 3 ' 3 - Zanthus


            Case 4 ' 4 - Elgin


            Case 5 ' 5 - Dataregis


            Case 6 ' 6 - EcfOutras


            Case 7 ' 7 - NaoFiscal

        End Select

        If IsNumeric(NumeroCupom) = False Then 'Verifica se deu certo trazer o numero do cupom

            MsgBox("Numero do cupom, não é numérico", MsgBoxStyle.Exclamation)
            oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()
            transacao.Dispose() : transacao = Nothing : oConnBDMETROSYS = Nothing
            Return
        End If


        Try

            '#######   Incluindo nas tabelas do Banco de Dados...
            _clBD.incPedidoCup1pp(numPedido, "N", _idImpressora, oConnBDMETROSYS, transacao)
            _clBD.incPedidoCup2cc(numPedido, 0, NumeroCupom, Mid(MdlUsuarioLogando._usuarioLogin, 1, 5), "N", _
                                   _idImpressora, oConnBDMETROSYS, transacao)
            _clBD.incPedidoCup4dd("N", numPedido, oConnBDMETROSYS, transacao)
            _clBD.incPedidoCup6hh("N", numPedido, _codCliente, _nomeCli, _enderecoCli, _cpfCnpjCli, _
                                  _bairroCli, _cidadeCli, _cepCli, oConnBDMETROSYS, transacao)

            '#######   Atualiza Tabelas...
            _clBD.altImpressoraNumCupom(oConnBDMETROSYS, transacao, _idImpressora, CInt(NumeroCupom))
            _clBD.altSituacaoPedido_Orca1(numPedido, 4, oConnBDMETROSYS, transacao)
            _clBD.diminuiQtdFiscComOrca2cc(numPedido, Mid(MdlEmpresaUsu._codigo, _
                MdlEmpresaUsu._codigo.Length - 1, 2), oConnBDMETROSYS, transacao)

        Catch ex As Exception
            oConnBDMETROSYS.ClearPool()
            If oConnBDMETROSYS.State = ConnectionState.Open Then oConnBDMETROSYS.Close()
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical) : Return

        End Try
        


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader


        '#######   Tratamento dos itens....
        Dim mtpquant, me_qtde As String
        Try

            sql.Append("SELECT no_orca, no_codpr, no_und, no_qtde, no_prunit, no_prtot, no_alqicm, ") '6
            sql.Append("no_basesub, no_vlsub, no_grupo, no_alqdesc, no_vldesc, no_pruvenda, no_baseicm, ") '13
            sql.Append("no_cdbarra, no_vlicms, e_produt, e_cfv ") '17
            sql.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 ")
            sql.Append("ON e_codig = no_codpr WHERE no_orca = @no_orca")

            cmd = New NpgsqlCommand(sql.ToString, oConnBDMETROSYS)
            cmd.Parameters.Add("@no_orca", numPedido)
            dr = cmd.ExecuteReader

            While dr.Read
                _orcaOrca2 = dr(0).ToString : _codprOrca2 = dr(1).ToString
                _undOrca2 = dr(2).ToString
                _qtdeOrca2 = dr(3) : _prunitOrca2 = dr(4)
                _prtotOrca2 = dr(5) : _alqicmOrca2 = dr(6)
                _basesubOrca2 = dr(7) : _vlsubOrca2 = dr(8)
                _grupoOrca2 = dr(9) : _alqdescOrca2 = dr(10)
                _vldescOrca2 = dr(11) : _pruvendaOrca2 = dr(12)
                _baseicmOrca2 = dr(13)
                _cdbarraOrca2 = dr(14).ToString
                _vlicmsOrca2 = dr(15)
                _descricaoProd = dr(16).ToString
                _cfv = dr(17)


                'Traz o tipo da Impressora Fiscal...
                Select Case _tipoImpressora

                    Case 1 ' 1 - Bematech
                        bematechTratamentoIten(_orcaOrca2, _codprOrca2, _descricaoProd, _undOrca2, _qtdeOrca2, _
                                _prunitOrca2, _prtotOrca2, _alqicmOrca2, _basesubOrca2, _vlsubOrca2, _
                                _grupoOrca2, _alqdescOrca2, _vldescOrca2, _pruvendaOrca2, _
                                _baseicmOrca2, _cdbarraOrca2, _vlicmsOrca2, _cfv, oConnBDMETROSYS, transacao)

                    Case 2 ' 2 - Daruma
                        darumaTratamentoIten(_orcaOrca2, _codprOrca2, _descricaoProd, _undOrca2, _qtdeOrca2, _
                               _prunitOrca2, _prtotOrca2, _alqicmOrca2, _basesubOrca2, _vlsubOrca2, _
                               _grupoOrca2, _alqdescOrca2, _vldescOrca2, _pruvendaOrca2, _
                               _baseicmOrca2, _cdbarraOrca2, _vlicmsOrca2, oConnBDMETROSYS, transacao)

                    Case 3 ' 3 - Zanthus


                    Case 4 ' 4 - Elgin


                    Case 5 ' 5 - Dataregis


                    Case 6 ' 6 - EcfOutras


                    Case 7 ' 7 - NaoFiscal

                End Select



            End While

            Dim mTotal As String = _clFuncoes.trazTotPedidoOrca4dd(numPedido, MdlConexaoBD.conectionPadrao)
            mTotal = Format(CDbl(mTotal), "###,###,###.#0")
            Dim me_tipoacresc As String
            Dim mAcreDesc As Double
            me_tipoacresc = "A" : mAcreDesc = 0.0

            '########   FECHAMENTO DO CUPOM...
            Select Case _tipoImpressora
                Case 1 ' 1 - Bematech
                    iRetorno = Bematech_FI_IniciaFechamentoCupom(me_tipoacresc, "%", mAcreDesc)
                    iRetorno = Bematech_FI_EfetuaFormaPagamento("Dinheiro", mTotal)
                    ' iRetorno = Bematech_FI_FechaCupom("Dinheiro", "A", "$", "0000", mTotal, "Obrigado, volte sempre !!!")
                    iRetorno = Bematech_FI_TerminaFechamentoCupom("OPerador:" & MdlUsuarioLogando._usuarioNome.ToUpper & "   Obrigado, Volte Sempre !!!")

                Case 2 ' 2 - Daruma
                    iRetorno = Daruma_FI_IniciaFechamentoCupom(me_tipoacresc, "%", mAcreDesc)
                    iRetorno = Daruma_FI_EfetuaFormaPagamento("Dinheiro", mTotal)
                    'iRetorno = Daruma_FI_FechaCupom("Dinheiro", "A", "$", "0000", mTotal, "Obrigado, volte sempre !!!")
                    iRetorno = Daruma_FI_TerminaFechamentoCupom("OPerador:" & MdlUsuarioLogando._usuarioNome.ToUpper & "   Obrigado, Volte Sempre !!!")

                Case 3 ' 3 - Zanthus


                Case 4 ' 4 - Elgin


                Case 5 ' 5 - Dataregis


                Case 6 ' 6 - EcfOutras


                Case 7 ' 7 - NaoFiscal

            End Select


            dr.Close() : transacao.Commit() : transacao.Dispose()
            oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()
        Catch ex As Exception
            oConnBDMETROSYS.ClearPool()
            If oConnBDMETROSYS.State = ConnectionState.Open Then oConnBDMETROSYS.Close()
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return

        End Try

        cmd.CommandText = "" : sql.Remove(0, sql.ToString.Length)
        oConnBDMETROSYS = Nothing : cmd = Nothing : sql = Nothing : dr = Nothing
        '###########################


        'oConn.Close()

    End Sub

    Private Sub bematechTratamentoIten(ByVal orca As String, ByVal codpr As String, _
                ByVal descricaoProd As String, ByVal und As String, ByVal qtde As Double, _
                ByVal prunit As Double, ByVal prtot As Double, ByVal alqicm As Double, _
                ByVal basesub As Double, ByVal vlsub As Double, ByVal grupo As Integer, _
                ByVal alqdesc As Double, ByVal vldesc As Double, ByVal prvenda As Double, _
                ByVal baseicm As Double, ByVal cdbarra As String, ByVal vlicms As Double, _
                ByVal cfv As Integer, ByVal conection As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mtpquant As String
        Dim me_qtde, me_aliq, me_prunit, me_tipodesconto, me_desconto As String
        Dim mcasasdecimais As Integer

        'Codigo
        Try
            codpr = codpr.Substring(0, 13)
            codpr = CInt(codpr)
        Catch ex As Exception
            codpr = CInt(codpr)
        End Try

        'Descricao
        Try
            descricaoProd = descricaoProd.Substring(0, 29)
        Catch ex As Exception
        End Try

        'Aliquota
        If _clFuncoes.IsInteiro(alqicm) Then

            If alqicm = 0 Then

                If cfv = 3 Then me_aliq = "FF"
                If cfv = 4 Then me_aliq = "II"
            Else

                me_aliq = CInt(alqicm).ToString.PadRight(4, "0")
            End If

        Else

            me_aliq = Format(alqicm, "##.#0")
            me_aliq = me_aliq.ToString.PadLeft(5, "0")
        End If

        'Quantidade
        If _clFuncoes.IsInteiro(_qtdeOrca2) Then

            mtpquant = "I"
            me_qtde = CInt(_qtdeOrca2) 'me_qtde = String.Format("{0:D4}", CInt(_qtdeOrca2))
        Else

            mtpquant = "F"
            me_qtde = Format(_qtdeOrca2, "###.##0")
        End If

        'Casas Decimais
        me_prunit = System.Math.Round(prvenda, 3)
        Dim marray As Array = Split(me_prunit, ",") 'Testa com virgula
        Try
            If marray.Length > 1 Then

                If marray(1).ToString.Length > 2 Then

                    mcasasdecimais = 3
                Else
                    mcasasdecimais = 2
                End If
            Else

                marray = Split(me_prunit, ".") 'Testa com ponto
                If marray.Length > 1 Then

                    If marray(1).ToString.Length > 2 Then

                        mcasasdecimais = 3
                    Else
                        mcasasdecimais = 2
                    End If
                Else
                    mcasasdecimais = 2
                End If

            End If

        Catch ex As Exception
        End Try

        'prunit += vlsub
        'Valor Unitario
        If mcasasdecimais = 2 Then
            me_prunit = Format(System.Math.Round(prvenda, 2), "#####.#0")
        Else
            me_prunit = Format(System.Math.Round(prvenda, 3), "####.##0")
        End If

        'Tipo do Desconto...
        If (alqdesc > 0) AndAlso (vldesc > 0) Then ' Se tiver valor e percentagem

            me_tipodesconto = "%"
            me_desconto = _clFuncoes.RemoverCaracter2(alqdesc.ToString)
            me_desconto = me_desconto.PadRight(4, "0")
        Else

            If alqdesc > 0 Then

                me_tipodesconto = "%"
                me_desconto = _clFuncoes.RemoverCaracter2(alqdesc.ToString)
                me_desconto = me_desconto.PadRight(4, "0")
            ElseIf vldesc > 0 Then

                me_tipodesconto = "$"
                me_desconto = Format(System.Math.Round(vldesc, 2), "#####.#0")
            Else 'Se valor e percentagem for ZERO

                me_tipodesconto = "%"
                me_desconto = "0000"
            End If
        End If

        Dim iRetorno As Integer
        iRetorno = Bematech_FI_VendeItem(codpr, descricaoProd, me_aliq, mtpquant, me_qtde, mcasasdecimais, _
                                         me_prunit, me_tipodesconto, me_desconto)


    End Sub

    Private Sub darumaTratamentoIten(ByVal orca As String, ByVal codpr As String, _
                ByVal descricaoProd As String, ByVal und As String, ByVal qtde As Double, _
                ByVal prunit As Double, ByVal prtot As Double, ByVal alqicm As Double, _
                ByVal basesub As Double, ByVal vlsub As Double, ByVal grupo As Integer, _
                ByVal alqdesc As Double, ByVal vldesc As Double, ByVal prvenda As Double, _
                ByVal baseicm As Double, ByVal cdbarra As String, ByVal vlicms As Double, _
                ByVal conection As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim mtpquant As String
        Dim me_qtde, me_aliq, me_prunit, me_tipodesconto, me_desconto As String
        Dim mcasasdecimais As Integer

        'Codigo
        Try
            codpr = codpr.Substring(0, 13)
        Catch ex As Exception
        End Try

        'Descricao
        Try
            descricaoProd = descricaoProd.Substring(0, 29)
        Catch ex As Exception
        End Try

        'Aliquota
        If _clFuncoes.IsInteiro(alqicm) Then

            me_aliq = CInt(alqicm).ToString.PadRight(4, "0")
        Else

            me_aliq = Format(alqicm, "##.#0")
            me_aliq = me_aliq.ToString.PadLeft(5, "0")
        End If

        'Quantidade
        If _clFuncoes.IsInteiro(_qtdeOrca2) Then

            mtpquant = "I"
            me_qtde = CInt(_qtdeOrca2) 'me_qtde = String.Format("{0:D4}", CInt(_qtdeOrca2))
        Else

            mtpquant = "F"
            me_qtde = Format(_qtdeOrca2, "###.##0")
        End If

        'Casas Decimais
        me_prunit = System.Math.Round(prunit, 3)
        Dim marray As Array = Split(me_prunit, ",") 'Testa com virgula
        Try
            If marray.Length > 1 Then

                If marray(1).ToString.Length > 2 Then

                    mcasasdecimais = 3
                Else
                    mcasasdecimais = 2
                End If
            Else

                marray = Split(me_prunit, ".") 'Testa com ponto
                If marray.Length > 1 Then

                    If marray(1).ToString.Length > 2 Then

                        mcasasdecimais = 3
                    Else
                        mcasasdecimais = 2
                    End If
                Else
                    mcasasdecimais = 2
                End If

            End If

        Catch ex As Exception
        End Try

        'Valor Unitario
        If mcasasdecimais = 2 Then
            me_prunit = Format(System.Math.Round(prunit, 2), "#####.#0")
        Else
            me_prunit = Format(System.Math.Round(prunit, 3), "####.##0")
        End If

        'Tipo do Desconto...
        If (alqdesc > 0) AndAlso (vldesc > 0) Then ' Se tiver valor e percentagem

            me_tipodesconto = "%"
            me_desconto = _clFuncoes.RemoverCaracter2(alqdesc.ToString)
            me_desconto = me_desconto.PadRight(4, "0")
        Else

            If alqdesc > 0 Then

                me_tipodesconto = "%"
                me_desconto = _clFuncoes.RemoverCaracter2(alqdesc.ToString)
                me_desconto = me_desconto.PadRight(4, "0")
            ElseIf vldesc > 0 Then

                me_tipodesconto = "$"
                me_desconto = Format(System.Math.Round(vldesc, 2), "#####.#0")
            Else 'Se valor e percentagem for ZERO

                me_tipodesconto = "%"
                me_desconto = "0000"
            End If
        End If

        Dim iRetorno As Integer
        iRetorno = Daruma_FI_VendeItem(codpr, descricaoProd, me_aliq, mtpquant, me_qtde, mcasasdecimais, _
                                         me_prunit, me_tipodesconto, me_desconto)



    End Sub

    Private Sub btn_imprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprime.Click

        If Me.txt_numPedido.Text.Equals("") Then Me.txt_numPedido.Text = String.Format("{0:D8}", 0) : Return
        If IsNumeric(Me.txt_numPedido.Text) Then

            If CInt(Me.txt_numPedido.Text) <= _valorZERO Then
                MsgBox("Numero do Cupom inválido", MsgBoxStyle.Exclamation)
                Return

            End If
            Me.txt_numPedido.Text = String.Format("{0:D8}", CInt(Me.txt_numPedido.Text))

        End If

        zeraValoresCupom()
        'Se o pedido existir...
        If _clFuncoes.existNumPedido(Me.txt_numPedido.Text, MdlEmpresaUsu._esqEstab, _
                                     MdlConexaoBD.conectionPadrao) Then

            Dim msit As Integer = 0
            msit = _clFuncoes.trazSituacaoPedido(Me.txt_numPedido.Text, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)

            ' Verifica status do Pedido 1-Digitado , 2-Impresso, 3-Pago, 4-ECF , 5-NFe,  6-Cancelado
            Select Case msit

                Case 4 'ECF
                    MsgBox("Este PEDIDO já foi emitido um Cupom Fiscal", MsgBoxStyle.Exclamation)

                Case 5 'NFe
                    MsgBox("Este PEDIDO já foi emitido uma NFe", MsgBoxStyle.Exclamation)

                Case 6 'Cancelado
                    MsgBox("Este PEDIDO já foi Cancelado", MsgBoxStyle.Exclamation)

                Case Else

                    If (msit > 0) AndAlso (msit < 4) Then

                        If setDadosCliente(Me.txt_numPedido.Text) = False Then Return
                        imprimirCupom(Me.txt_numPedido.Text)
                    End If


            End Select
            

        Else

            MsgBox("NUMERO do PEDIDO não existe", MsgBoxStyle.Exclamation)
        End If
        zeraValoresCupom()


    End Sub

    Private Sub txt_numPedido_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numPedido.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Function setDadosCliente(ByVal numpedido As String) As Boolean


        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
            Return False

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try

            sql.Append("SELECT cad.p_portad, cad.p_cpf, cad.p_cgc, cad.p_end, cad.p_cid, cad.p_cep, cad.p_bairro, ") '6
            sql.Append("nt_codig, nt_geno, nt_dtemis, nt_dtsai, nt_cfop, nt_itens, nt_rota, nt_x, nt_tipo2, nt_auto ") '16
            sql.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp LEFT JOIN cadp001 cad ON cad.p_cod = nt_codig ")
            sql.Append("WHERE nt_orca = @nt_orca")

            cmd = New NpgsqlCommand(sql.ToString, oConnBDMETROSYS)
            cmd.Parameters.Add("@nt_orca", numpedido)
            dr = cmd.ExecuteReader

            While dr.Read

                _nomeCli = dr(0).ToString
                _cpfCnpjCli = dr(1).ToString
                If _cpfCnpjCli.Equals("") Then _cpfCnpjCli = dr(2).ToString
                _enderecoCli = dr(3).ToString
                _cidadeCli = dr(4).ToString
                _cepCli = dr(5).ToString
                _bairroCli = dr(6).ToString
                _codCliente = dr(7).ToString

                _codGeno = dr(8).ToString
                _dataEmissOrca1 = Format(dr(9), "dd/MM/yyyy")
                _dtSaiOrca1 = Format(dr(10), "dd/MM/yyyy")
                _cfopOrca1 = dr(11).ToString
                _itensOrca1 = dr(12)
                _rotaOrca1 = dr(13)
                _xOrca1 = dr(14).ToString
                _tipo2Orca1 = dr(15).ToString
                _autoOrca1 = dr(16).ToString


            End While

            dr.Close() : oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try

        cmd.CommandText = "" : sql.Remove(0, sql.ToString.Length)
        oConnBDMETROSYS = Nothing : cmd = Nothing : sql = Nothing : dr = Nothing

        Return True
    End Function

    Private Function nomeFormaPagamento(ByVal sigla As String)

        Select Case sigla

            Case "AV"
                Return "A VISTA"

            Case ""

        End Select
    End Function

    Private Sub txt_numPedido_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numPedido.LostFocus

        If Me.txt_numPedido.Text.Equals("") Then Me.txt_numPedido.Text = String.Format("{0:D8}", 0) : Return
        If IsNumeric(Me.txt_numPedido.Text) Then
            Me.txt_numPedido.Text = String.Format("{0:D8}", CInt(Me.txt_numPedido.Text))

        End If

    End Sub
End Class