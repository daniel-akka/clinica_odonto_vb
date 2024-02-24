Imports System
Imports System.IO

Public Module ClsFuncoes_ECF
    Public total As String
    'Variaveis Globais usadas no ECF
    Public Int_Ack, Int_St1, Int_St2 As Integer
    Public iACK, iST1, iST2, iRET, iValue, Int_Retorno As Integer
    Public Str_Informacao As String
    Public Int_Informacao As Integer
    Public shortValue As Short
    Public sRetorno As String
    Public sBuffer, sBuffer2 As String

    Public Class total2
        Public totalcupom As total_geral

        Public Class total_geral
            Public mx_total As String

        End Class
    End Class

    Public Function calc_oito(ByVal codbarra As String) As String
        ' Função para calculo do 8º Digito do Codigo de Barras Internacional
        Dim mTamanho, t, mcod, m128, msoma As Integer
        Dim mcalc As Integer
        Dim mdig As Integer
        Dim m_Ean8 As String = "3131313"  ' Produto p/ Calculo de Digitos
        '                       7860264X    Exemplo de Código c/ 07 Digitos    
        msoma = 0
        For t = 7 To 1 Step -1
            mcod = Convert.ToInt16(Mid(codbarra, t, 1))
            m128 = Convert.ToInt16(Mid(m_Ean8, t, 1))
            mcalc = mcod * m128
            msoma = msoma + mcalc
        Next
        mTamanho = Len(RTrim(Convert.ToString(msoma)))
        mdig = 10 - Mid(RTrim(Convert.ToString(msoma)), mTamanho)
        If mdig = 10 Then
            mdig = 0
        End If
        Return RTrim(codbarra) & LTrim(Str(mdig)) ' Retorna Codigo de Barra com 8 digitos 
        '                                           Padrão EAN-8

    End Function

    Public Function calc_doze(ByVal codbarra As String) As String
        ' Função para calciulo do 13º Digito do Codigo de Barras Nacional
        Dim mTamanho, t, mcod, m128, msoma As Integer
        Dim mcalc As Integer
        Dim mdig As Integer
        Dim m_Ean128 As String = "131313131313"  ' Produto p/ Calculo de Digitos
        '                         789652623429X    Exemplo de Codigo c/ 12 Digitos    
        msoma = 0
        For t = 12 To 1 Step -1
            mcod = Convert.ToInt16(Mid(codbarra, t, 1))
            m128 = Convert.ToInt16(Mid(m_Ean128, t, 1))
            mcalc = mcod * m128
            msoma = msoma + mcalc
        Next
        mTamanho = Len(RTrim(Convert.ToString(msoma)))
        mdig = 10 - Mid(RTrim(Convert.ToString(msoma)), mTamanho)
        If mdig = 10 Then
            mdig = 0
        End If
        Return RTrim(codbarra) & LTrim(Str(mdig)) ' Retorna Codigo de Barra com 13 digitos 
        '                              Padrão EAN-128

    End Function

    ' Funções do Cupom Fiscal 
#Region " * * Funções de Controle da ECF - Bematech  *  *  "


    Public Declare Function Bematech_FI_AbreCupom Lib "BEMAFI32.DLL" (ByVal CGC_CPF As String) As Integer

    Public Declare Function Bematech_FI_VendeItem Lib "BEMAFI32.DLL" (ByVal Codigo As String, ByVal Descricao As String, ByVal Aliquota As String, ByVal TipoQuantidade As String, ByVal Quantidade As String, ByVal CasasDecimais As Integer, ByVal ValorUnitario As String, ByVal TipoDesconto As String, ByVal Desconto As String) As Integer

    Public Declare Function Bematech_FI_CancelaItemAnterior Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_CancelaItemGenerico Lib "BEMAFI32.DLL" (ByVal NumeroItem As String) As Integer

    Public Declare Function Bematech_FI_CancelaCupom Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_FechaCupomResumido Lib "BEMAFI32.DLL" (ByVal FormaPagamento As String, ByVal Mensagem As String) As Integer

    Public Declare Function Bematech_FI_FechaCupom Lib "BEMAFI32.DLL" (ByVal FormaPagamento As String, ByVal DiscontoAcrecimo As String, ByVal TipoDescontoAcrecimo As String, ByVal ValorAcrecimoDesconto As String, ByVal ValorPago As String, ByVal Mensagem As String) As Integer

    Public Declare Function Bematech_FI_VendeItemDepartamento Lib "BEMAFI32.DLL" (ByVal Codigo As String, ByVal Descricao As String, ByVal Aliquota As String, ByVal ValorUnitario As String, ByVal Quantidade As String, ByVal Acrescimo As String, ByVal Desconto As String, ByVal IndiceDepartamento As String, ByVal UnidadeMedida As String) As Integer

    Public Declare Function Bematech_FI_AumentaDescricaoItem Lib "BEMAFI32.DLL" (ByVal Descricao As String) As Integer

    Public Declare Function Bematech_FI_UsaUnidadeMedida Lib "BEMAFI32.DLL" (ByVal UnidadeMedida As String) As Integer

    Public Declare Function Bematech_FI_EstornoFormasPagamento Lib "BEMAFI32.DLL" (ByVal FormaOrigem As String, ByVal FormaDestino As String, ByVal Valor As String) As Integer

    Public Declare Function Bematech_FI_IniciaFechamentoCupom Lib "BEMAFI32.DLL" (ByVal AcrescimoDesconto As String, ByVal TipoAcrescimoDesconto As String, ByVal ValorAcrescimoDesconto As String) As Integer

    Public Declare Function Bematech_FI_EfetuaFormaPagamento Lib "BEMAFI32.DLL" (ByVal FormaPagamento As String, ByVal ValorFormaPagamento As String) As Integer

    Public Declare Function Bematech_FI_EfetuaFormaPagamentoDescricaoForma Lib "BEMAFI32.DLL" (ByVal FormaPagamento As String, ByVal ValorFormaPagamento As String, ByVal DescricaoOpcional As String) As Integer

    Public Declare Function Bematech_FI_TerminaFechamentoCupom Lib "BEMAFI32.DLL" (ByVal Mensagem As String) As Integer

    ' Funções dos Relatórios Fiscais 
    Public Declare Function Bematech_FI_LeituraX Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_LeituraXSerial Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_ReducaoZ Lib "BEMAFI32.DLL" (ByVal Data As String, ByVal Hora As String) As Integer

    Public Declare Function Bematech_FI_GeraRegistrosSpedMFD Lib "BEMAFI32.DLL" (ByVal cOrigem As String, ByVal cDestino As String, ByVal cDataInicial As String, _
                                                                                 ByVal cDataFinal As String, ByVal cPerfil As String, ByVal cCfop As String, _
                                                                                 ByVal cCodObsLancFiscal As String, ByVal cAliquotaPis As String, _
                                                                                 ByVal cAliquotaCofins As String) As Integer

    Public Declare Function Bematech_FI_RelatorioGerencial Lib "BEMAFI32.DLL" (ByVal cTexto As String) As Integer

    Public Declare Function Bematech_FI_RelatorioGerencialTEF Lib "BEMAFI32.DLL" (ByVal cTexto As String) As Integer

    Public Declare Function Bematech_FI_FechaRelatorioGerencial Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_LeituraMemoriaFiscalData Lib "BEMAFI32.DLL" (ByVal cDataInicial As String, ByVal cDataFinal As String) As Integer

    Public Declare Function Bematech_FI_LeituraMemoriaFiscalReducao Lib "BEMAFI32.DLL" (ByVal cReducaoInicial As String, ByVal cReducaoFinal As String) As Integer

    Public Declare Function Bematech_FI_LeituraMemoriaFiscalSerialData Lib "BEMAFI32.DLL" (ByVal cDataInicial As String, ByVal cDataFinal As String) As Integer

    Public Declare Function Bematech_FI_LeituraMemoriaFiscalSerialReducao Lib "BEMAFI32.DLL" (ByVal cReducaoInicial As String, ByVal cReducaoFinal As String) As Integer

    ' Funções de Informação da Impressora 
    Public Declare Function Bematech_FI_NumeroSerie Lib "BEMAFI32.DLL" (ByVal NumeroSerie As String) As Integer

    Public Declare Function Bematech_FI_SubTotal Lib "BEMAFI32.DLL" (ByVal SubTotal As String) As Integer

    Public Declare Function Bematech_FI_NumeroCupom Lib "BEMAFI32.DLL" (ByVal NumeroCupom As String) As Integer

    Public Declare Function Bematech_FI_VersaoFirmware Lib "BEMAFI32.DLL" (ByVal VersaoFirmware As String) As Integer

    Public Declare Function Bematech_FI_CGC_IE Lib "BEMAFI32.DLL" (ByVal CGC As String, ByVal IE As String) As Integer

    Public Declare Function Bematech_FI_GrandeTotal Lib "BEMAFI32.DLL" (ByVal GrandeTotal As String) As Integer

    Public Declare Function Bematech_FI_Cancelamentos Lib "BEMAFI32.DLL" (ByVal ValorCancelamentos As String) As Integer

    Public Declare Function Bematech_FI_Descontos Lib "BEMAFI32.DLL" (ByVal ValorDescontos As String) As Integer

    Public Declare Function Bematech_FI_NumeroOperacoesNaoFiscais Lib "BEMAFI32.DLL" (ByVal NumeroOperacoes As String) As Integer

    Public Declare Function Bematech_FI_NumeroCuponsCancelados Lib "BEMAFI32.DLL" (ByVal NumeroCancelamentos As String) As Integer

    Public Declare Function Bematech_FI_NumeroIntervencoes Lib "BEMAFI32.DLL" (ByVal NumeroIntervencoes As String) As Integer

    Public Declare Function Bematech_FI_NumeroReducoes Lib "BEMAFI32.DLL" (ByVal NumeroReducoes As String) As Integer

    Public Declare Function Bematech_FI_NumeroSubstituicoesProprietario Lib "BEMAFI32.DLL" (ByVal NumeroSubstituicoes As String) As Integer

    Public Declare Function Bematech_FI_UltimoItemVendido Lib "BEMAFI32.DLL" (ByVal NumeroItem As String) As Integer

    Public Declare Function Bematech_FI_ClicheProprietario Lib "BEMAFI32.DLL" (ByVal Cliche As String) As Integer

    Public Declare Function Bematech_FI_NumeroCaixa Lib "BEMAFI32.DLL" (ByVal NumeroCaixa As String) As Integer

    Public Declare Function Bematech_FI_NumeroLoja Lib "BEMAFI32.DLL" (ByVal NumeroLoja As String) As Integer

    Public Declare Function Bematech_FI_SimboloMoeda Lib "BEMAFI32.DLL" (ByVal SimboloMoeda As String) As Integer

    Public Declare Function Bematech_FI_MinutosLigada Lib "BEMAFI32.DLL" (ByVal Minutos As String) As Integer

    Public Declare Function Bematech_FI_MinutosImprimindo Lib "BEMAFI32.DLL" (ByVal Minutos As String) As Integer

    Public Declare Function Bematech_FI_VerificaModoOperacao Lib "BEMAFI32.DLL" (ByVal Modo As String) As Integer

    Public Declare Function Bematech_FI_VerificaEpromConectada Lib "BEMAFI32.DLL" (ByVal Flag As String) As Integer

    Public Declare Function Bematech_FI_FlagsFiscais Lib "BEMAFI32.DLL" (ByRef Flag As Integer) As Integer

    Public Declare Function Bematech_FI_ValorPagoUltimoCupom Lib "BEMAFI32.DLL" (ByVal ValorCupom As String) As Integer

    Public Declare Function Bematech_FI_DataHoraImpressora Lib "BEMAFI32.DLL" (ByVal Data As String, ByVal Hora As String) As Integer

    Public Declare Function Bematech_FI_ContadoresTotalizadoresNaoFiscais Lib "BEMAFI32.DLL" (ByVal Contadores As String) As Integer

    Public Declare Function Bematech_FI_VerificaTotalizadoresNaoFiscais Lib "BEMAFI32.DLL" (ByVal Totalizadores As String) As Integer

    Public Declare Function Bematech_FI_DataHoraReducao Lib "BEMAFI32.DLL" (ByVal Data As String, ByVal Hora As String) As Integer

    Public Declare Function Bematech_FI_DataMovimento Lib "BEMAFI32.DLL" (ByVal Data As String) As Integer

    Public Declare Function Bematech_FI_VerificaTruncamento Lib "BEMAFI32.DLL" (ByVal Flag As String) As Integer

    Public Declare Function Bematech_FI_Acrescimos Lib "BEMAFI32.DLL" (ByVal ValorAcrescimos As String) As Integer

    Public Declare Function Bematech_FI_ContadorBilhetePassagem Lib "BEMAFI32.DLL" (ByVal ContadorPassagem As String) As Integer

    Public Declare Function Bematech_FI_VerificaAliquotasIss Lib "BEMAFI32.DLL" (ByVal AliquotasIss As String) As Integer

    Public Declare Function Bematech_FI_VerificaFormasPagamento Lib "BEMAFI32.DLL" (ByVal Formas As String) As Integer

    Public Declare Function Bematech_FI_VerificaRecebimentoNaoFiscal Lib "BEMAFI32.DLL" (ByVal Recebimentos As String) As Integer

    Public Declare Function Bematech_FI_VerificaDepartamentos Lib "BEMAFI32.DLL" (ByVal Departamentos As String) As Integer

    Public Declare Function Bematech_FI_VerificaTipoImpressora Lib "BEMAFI32.DLL" (ByRef TipoImpressora As String) As Integer

    Public Declare Function Bematech_FI_VerificaTotalizadoresParciais Lib "BEMAFI32.DLL" (ByVal cTotalizadores As String) As Integer

    Public Declare Function Bematech_FI_RetornoAliquotas Lib "BEMAFI32.DLL" (ByVal cAliquotas As String) As Integer

    Public Declare Function Bematech_FI_DadosUltimaReducao Lib "BEMAFI32.DLL" (ByVal DadosReducao As String) As Integer

    Public Declare Function Bematech_FI_MonitoramentoPapel Lib "BEMAFI32.DLL" (ByRef Linhas As String) As Integer

    Public Declare Function Bematech_FI_ValorFormaPagamento Lib "BEMAFI32.DLL" (ByVal FormaPagamento As String, ByVal Valor As String) As Integer

    Public Declare Function Bematech_FI_ValorTotalizadorNaoFiscal Lib "BEMAFI32.DLL" (ByVal Totalizador As String, ByVal Valor As String) As Integer

    ' Funções de Autenticação 
    Public Declare Function Bematech_FI_Autenticacao Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_ProgramaCaracterAutenticacao Lib "BEMAFI32.DLL" (ByVal Parametros As String) As Integer

    ' Funções de Gaveta de Dinheiro 
    Public Declare Function Bematech_FI_AcionaGaveta Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_VerificaEstadoGaveta Lib "BEMAFI32.DLL" (ByRef EstadoGaveta As Integer) As Integer

    ' Funções das Operações Não Fiscais 
    Public Declare Function Bematech_FI_RecebimentoNaoFiscal Lib "BEMAFI32.DLL" (ByVal IndiceTotalizador As String, ByVal Valor As String, ByVal FormaPagamento As String) As Integer

    Public Declare Function Bematech_FI_AbreComprovanteNaoFiscalVinculado Lib "BEMAFI32.DLL" (ByVal FormaPagamento As String, ByVal Valor As String, ByVal NumeroCupom As String) As Integer

    Public Declare Function Bematech_FI_UsaComprovanteNaoFiscalVinculado Lib "BEMAFI32.DLL" (ByVal Texto As String) As Integer

    Public Declare Function Bematech_FI_UsaComprovanteNaoFiscalVinculadoTEF Lib "BEMAFI32.DLL" (ByVal Texto As String) As Integer

    Public Declare Function Bematech_FI_FechaComprovanteNaoFiscalVinculado Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_Sangria Lib "BEMAFI32.DLL" (ByVal Valor As String) As Integer

    Public Declare Function Bematech_FI_Suprimento Lib "BEMAFI32.DLL" (ByVal Valor As String, ByVal FormaPagamento As String) As Integer

    ' Outras Funções 
    Public Declare Function Bematech_FI_ResetaImpressora Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_AbrePortaSerial Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_VerificaEstadoImpressora Lib "BemaFi32.dll" (ByRef ACK As Integer, ByRef ST1 As Integer, ByRef ST2 As Integer) As Integer

    Public Declare Function Bematech_FI_RetornoImpressora Lib "BEMAFI32.DLL" (ByRef ACK As Integer, ByRef ST1 As Integer, ByRef ST2 As Integer) As Integer

    Public Declare Function Bematech_FI_FechaPortaSerial Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_VerificaImpressoraLigada Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_MapaResumo Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_RelatorioTipo60Analitico Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_RelatorioTipo60Mestre Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_ImprimeConfiguracoesImpressora Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_ImprimeDepartamentos Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_AberturaDoDia Lib "BEMAFI32.DLL" (ByVal Valor As String, ByVal FormaPagamento As String) As Integer

    Public Declare Function Bematech_FI_FechamentoDoDia Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_ImpressaoCarne Lib "BEMAFI32.DLL" (ByVal Titulo As String, ByVal Percelas As String, ByVal Datas As Integer, ByVal Quantidade As Integer, ByVal Texto As String, ByVal Cliente As String, ByVal RG_CPF As String, ByVal Cupom As String, ByVal Vias As Integer, ByVal Assina As Integer) As Integer

    Public Declare Function Bematech_FI_InfoBalanca Lib "BEMAFI32.DLL" (ByVal Porta As String, ByVal Modelo As Integer, ByVal Peso As String, ByVal PrecoKilo As String, ByVal Total As String) As Integer

    Public Declare Function Bematech_FI_DadosSintegra Lib "BEMAFI32.DLL" (ByVal DataInicial As String, ByVal DataFinal As String) As Integer

    Public Declare Function Bematech_FI_IniciaModoTEF Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_FinalizaModoTEF Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_VersaoDll Lib "BEMAFI32.DLL" (ByVal Versao As String) As Integer

    Public Declare Function Bematech_FI_RegistrosTipo60 Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_LeArquivoRetorno Lib "BEMAFI32.DLL" (ByVal Retorno As String) As Integer
    ' Funções da Impressora Fiscal MFD 
    Public Declare Function Bematech_FI_AbreCupomMFD Lib "BEMAFI32.DLL" (ByVal CGC As String, ByVal Nome As String, ByVal Endereco As String) As Integer

    Public Declare Function Bematech_FI_CancelaCupomMFD Lib "BEMAFI32.DLL" (ByVal CGC As String, ByVal Nome As String, ByVal Endereco As String) As Integer

    Public Declare Function Bematech_FI_ProgramaFormaPagamentoMFD Lib "BEMAFI32.DLL" (ByVal FormaPagto As String, ByVal OperacaoTef As String) As Integer

    Public Declare Function Bematech_FI_EfetuaFormaPagamentoMFD Lib "BEMAFI32.DLL" (ByVal FormaPagamento As String, ByVal ValorFormaPagamento As String, ByVal Parcelas As String, ByVal DescricaoFormaPagto As String) As Integer

    Public Declare Function Bematech_FI_CupomAdicionalMFD Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_AcrescimoDescontoItemMFD Lib "BEMAFI32.DLL" (ByVal Item As String, ByVal AcrescimoDesconto As String, ByVal TipoAcrescimoDesconto As String, ByVal ValorAcrescimoDesconto As String) As Integer

    Public Declare Function Bematech_FI_NomeiaRelatorioGerencialMFD Lib "BEMAFI32.DLL" (ByVal Indice As String, ByVal Descricao As String) As Integer

    Public Declare Function Bematech_FI_AutenticacaoMFD Lib "BEMAFI32.DLL" (ByVal Linhas As String, ByVal Texto As String) As Integer

    Public Declare Function Bematech_FI_AbreComprovanteNaoFiscalVinculadoMFD Lib "BEMAFI32.DLL" (ByVal FormaPagamento As String, ByVal Valor As String, ByVal NumeroCupom As String, ByVal CGC As String, ByVal Nome As String, ByVal Endereco As String) As Integer

    Public Declare Function Bematech_FI_ReimpressaoNaoFiscalVinculadoMFD Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_AbreRecebimentoNaoFiscalMFD Lib "BEMAFI32.DLL" (ByVal CGC As String, ByVal Nome As String, ByVal Endereco As String) As Integer

    Public Declare Function Bematech_FI_EfetuaRecebimentoNaoFiscalMFD Lib "BEMAFI32.DLL" (ByVal IndiceTotalizador As String, ByVal ValorRecebimento As String) As Integer

    Public Declare Function Bematech_FI_IniciaFechamentoRecebimentoNaoFiscalMFD Lib "BEMAFI32.DLL" (ByVal AcrescimoDesconto As String, ByVal TipoAcrescimoDesconto As String, ByVal ValorAcrescimo As String, ByVal ValorDesconto As String) As Integer

    Public Declare Function Bematech_FI_FechaRecebimentoNaoFiscalMFD Lib "BEMAFI32.DLL" (ByVal Mensagem As String) As Integer

    Public Declare Function Bematech_FI_CancelaRecebimentoNaoFiscalMFD Lib "BEMAFI32.DLL" (ByVal CGC As String, ByVal Nome As String, ByVal Endereco As String) As Integer

    Public Declare Function Bematech_FI_AbreRelatorioGerencialMFD Lib "BEMAFI32.DLL" (ByVal Indice As String) As Integer

    Public Declare Function Bematech_FI_UsaRelatorioGerencialMFD Lib "BEMAFI32.DLL" (ByVal Texto As String) As Integer

    Public Declare Function Bematech_FI_UsaRelatorioGerencialMFDTEF Lib "BEMAFI32.DLL" (ByVal Texto As String) As Integer

    Public Declare Function Bematech_FI_SegundaViaNaoFiscalVinculadoMFD Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_EstornoNaoFiscalVinculadoMFD Lib "BEMAFI32.DLL" (ByVal CGC As String, ByVal Nome As String, ByVal Endereco As String) As Integer

    Public Declare Function Bematech_FI_NumeroSerieMFD Lib "BEMAFI32.DLL" (ByVal NumeroSerie As String) As Integer

    Public Declare Function Bematech_FI_VersaoFirmwareMFD Lib "BEMAFI32.DLL" (ByVal VersaoFirmware As String) As Integer

    Public Declare Function Bematech_FI_CNPJMFD Lib "BEMAFI32.DLL" (ByVal CNPJ As String) As Integer

    Public Declare Function Bematech_FI_InscricaoEstadualMFD Lib "BEMAFI32.DLL" (ByVal InscricaoEstadual As String) As Integer

    Public Declare Function Bematech_FI_InscricaoMunicipalMFD Lib "BEMAFI32.DLL" (ByVal InscricaoMunicipal As String) As Integer

    Public Declare Function Bematech_FI_TempoOperacionalMFD Lib "BEMAFI32.DLL" (ByVal TempoOperacional As String) As Integer

    Public Declare Function Bematech_FI_MinutosEmitindoDocumentosFiscaisMFD Lib "BEMAFI32.DLL" (ByVal Minutos As String) As Integer

    Public Declare Function Bematech_FI_ContadoresTotalizadoresNaoFiscaisMFD Lib "BEMAFI32.DLL" (ByVal Contadores As String) As Integer

    Public Declare Function Bematech_FI_VerificaTotalizadoresNaoFiscaisMFD Lib "BEMAFI32.DLL" (ByVal Totalizadores As String) As Integer

    Public Declare Function Bematech_FI_VerificaFormasPagamentoMFD Lib "BEMAFI32.DLL" (ByVal FormasPagamento As String) As Integer

    Public Declare Function Bematech_FI_VerificaRecebimentoNaoFiscalMFD Lib "BEMAFI32.DLL" (ByVal Recebimentos As String) As Integer

    Public Declare Function Bematech_FI_VerificaRelatorioGerencialMFD Lib "BEMAFI32.DLL" (ByVal Relatorios As String) As Integer

    Public Declare Function Bematech_FI_ContadorComprovantesCreditoMFD Lib "BEMAFI32.DLL" (ByVal Comprovantes As String) As Integer

    Public Declare Function Bematech_FI_ContadorOperacoesNaoFiscaisCanceladasMFD Lib "BEMAFI32.DLL" (ByVal OperacoesCanceladas As String) As Integer

    Public Declare Function Bematech_FI_ContadorRelatoriosGerenciaisMFD Lib "BEMAFI32.DLL" (ByVal Relatorios As String) As Integer

    Public Declare Function Bematech_FI_ContadorCupomFiscalMFD Lib "BEMAFI32.DLL" (ByVal CuponsEmitidos As String) As Integer

    Public Declare Function Bematech_FI_ContadorFitaDetalheMFD Lib "BEMAFI32.DLL" (ByVal ContadorFita As String) As Integer

    Public Declare Function Bematech_FI_ComprovantesNaoFiscaisNaoEmitidosMFD Lib "BEMAFI32.DLL" (ByVal Comprovantes As String) As Integer

    Public Declare Function Bematech_FI_NumeroSerieMemoriaMFD Lib "BEMAFI32.DLL" (ByVal NumeroSerieMFD As String) As Integer

    Public Declare Function Bematech_FI_ReducoesRestantesMFD Lib "BEMAFI32.DLL" (ByVal Reducoes As String) As Integer

    Public Declare Function Bematech_FI_MarcaModeloTipoMFD Lib "BEMAFI32.DLL" (ByVal Marca As String, ByVal Modelo As String, ByVal Tipo As String) As Integer

    Public Declare Function Bematech_FI_VerificaTotalizadoresParciaisMFD Lib "BEMAFI32.DLL" (ByVal Totalizadores As String) As Integer

    Public Declare Function Bematech_FI_DadosUltimaReducaoMFD Lib "BEMAFI32.DLL" (ByVal DadosReducao As String) As Integer

    Public Declare Function Bematech_FI_LeituraMemoriaFiscalDataMFD Lib "BEMAFI32.DLL" (ByVal DataInicial As String, ByVal DataFinal As String, ByVal FlagLeitura As String) As Integer

    Public Declare Function Bematech_FI_LeituraMemoriaFiscalReducaoMFD Lib "BEMAFI32.DLL" (ByVal ReducaoInicial As String, ByVal ReducaoFinal As String, ByVal FlagLeitura As String) As Integer

    Public Declare Function Bematech_FI_LeituraMemoriaFiscalSerialDataMFD Lib "BEMAFI32.DLL" (ByVal DataInicial As String, ByVal DataFinal As String, ByVal FlagLeitura As String) As Integer

    Public Declare Function Bematech_FI_LeituraMemoriaFiscalSerialReducaoMFD Lib "BEMAFI32.DLL" (ByVal ReducaoInicial As String, ByVal ReducaoFinal As String, ByVal FlagLeitura As String) As Integer

    Public Declare Function Bematech_FI_LeituraChequeMFD Lib "BEMAFI32.DLL" (ByVal CodigoCMC7 As String) As Integer

    Public Declare Function Bematech_FI_ImprimeChequeMFD Lib "BEMAFI32.DLL" (ByVal NumeroBanco As String, ByVal Valor As String, ByVal Favorecido As String, ByVal Cidade As String, ByVal Data As String, ByVal Mensagem As String, ByVal ImpressaoVerso As String, ByVal Linhas As String) As Integer

    Public Declare Function Bematech_FI_HabilitaDesabilitaRetornoEstendidoMFD Lib "BEMAFI32.DLL" (ByVal FlagRetorno As String) As Integer

    Public Declare Function Bematech_FI_RetornoImpressoraMFD Lib "BEMAFI32.DLL" (ByRef ACK As Integer, ByRef ST1 As Integer, ByRef ST2 As Integer, ByRef ST3 As Integer) As Integer

    Public Declare Function Bematech_FI_AbreBilhetePassagemMFD Lib "BEMAFI32.DLL" (ByVal Embarque As String, ByVal Destino As String, ByVal Linha As String, ByVal Agencia As String, ByVal Data As String, ByVal Hora As String, ByVal Poltrona As String, ByVal Plataforma As String, ByVal TipoPassagem As String, ByVal RGCliente As String, ByVal NomeCliente As String, ByVal EnderecoCliente As String, ByVal UFDetino As String) As Integer

    Public Declare Function Bematech_FI_CancelaAcrescimoDescontoItemMFD Lib "BEMAFI32.DLL" (ByVal cFlag As String, ByVal cItem As String) As Integer

    Public Declare Function Bematech_FI_SubTotalizaCupomMFD Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_SubTotalizaRecebimentoMFD Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_TotalLivreMFD Lib "BEMAFI32.DLL" (ByVal cMemoriaLivre As String) As Integer

    Public Declare Function Bematech_FI_TamanhoTotalMFD Lib "BEMAFI32.DLL" (ByVal cTamMFD As String) As Integer

    Public Declare Function Bematech_FI_AcrescimoDescontoSubtotalRecebimentoMFD Lib "BEMAFI32.DLL" (ByVal cFlag As String, ByVal cTipo As String, ByVal cValor As String) As Integer

    Public Declare Function Bematech_FI_AcrescimoDescontoSubtotalMFD Lib "BEMAFI32.DLL" (ByVal cFlag As String, ByVal cTipo As String, ByVal cValor As String) As Integer

    Public Declare Function Bematech_FI_CancelaAcrescimoDescontoSubtotalMFD Lib "BEMAFI32.DLL" (ByVal cFlag As String) As Integer

    Public Declare Function Bematech_FI_CancelaAcrescimoDescontoSubtotalRecebimentoMFD Lib "BEMAFI32.DLL" (ByVal cFlag As String) As Integer

    Public Declare Function Bematech_FI_TotalizaCupomMFD Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_TotalizaRecebimentoMFD Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_PercentualLivreMFD Lib "BEMAFI32.DLL" (ByVal cMemoriaLivre As String) As Integer

    Public Declare Function Bematech_FI_DataHoraUltimoDocumentoMFD Lib "BEMAFI32.DLL" (ByVal cDataHora As String) As Integer

    Public Declare Function Bematech_FI_MapaResumoMFD Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_RelatorioTipo60AnaliticoMFD Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_ValorFormaPagamentoMFD Lib "BEMAFI32.DLL" (ByVal FormaPagamento As String, ByVal Valor As String) As Integer

    Public Declare Function Bematech_FI_ValorTotalizadorNaoFiscalMFD Lib "BEMAFI32.DLL" (ByVal Totalizador As String, ByVal Valor As String) As Integer

    Public Declare Function Bematech_FI_MarcaModeloTipoImpressoraMFD Lib "BEMAFI32.DLL" (ByVal Marca As String, ByVal Modelo As String, ByVal Tipo As String) As Integer

    Public Declare Function Bematech_FI_VerificaEstadoImpressoraMFD Lib "BemaFi32.dll" (ByRef ACK As Integer, ByRef ST1 As Integer, ByRef ST2 As Integer, ByRef ST3 As Integer) As Integer

    Public Declare Function Bematech_FI_IniciaFechamentoCupomMFD Lib "BEMAFI32.DLL" (ByVal AcrescimoDesconto As String, ByVal TipoAcrescimoDesconto As String, ByVal ValorAcrescimo As String, ByVal ValorDesconto As String) As Integer

    Public Declare Function Bematech_FI_RelatorioSintegraMFD Lib "BEMAFI32.DLL" (ByVal Relatorios As Integer, ByVal Arquivo As String, ByVal Mes As String, ByVal cAno As String, ByVal RazaoSocial As String, ByVal Endereco As String, ByVal Numero As String, ByVal Complemento As String, ByVal Bairro As String, ByVal Cidade As String, ByVal CEP As String, ByVal Telefone As String, ByVal Fax As String, ByVal Contato As String) As Integer

    Public Declare Function Bematech_FI_GeraRelatorioSintegraMFD Lib "BEMAFI32.DLL" (ByVal Relatorios As Integer, ByVal ArquivoOrigem As String, ByVal ArquivoDestino As String, ByVal Mes As String, ByVal cAno As String, ByVal RazaoSocial As String, ByVal Endereco As String, ByVal Numero As String, ByVal Complemento As String, ByVal Bairro As String, ByVal Cidade As String, ByVal CEP As String, ByVal Telefone As String, ByVal Fax As String, ByVal Contato As String) As Integer

    Public Declare Function Bematech_FI_CancelaItemNaoFiscalMFD Lib "BEMAFI32.DLL" (ByVal NumeroItem As String) As Integer

    Public Declare Function Bematech_FI_AcrescimoItemNaoFiscalMFD Lib "BEMAFI32.DLL" (ByVal NumeroItem As String, ByVal AcrescimoDesconto As String, ByVal TipoAcrescimoDesconto As String, ByVal ValorAcrescimoDesconto As String) As Integer

    Public Declare Function Bematech_FI_CancelaAcrescimoNaoFiscalMFD Lib "BEMAFI32.DLL" (ByVal NumeroItem As String, ByVal AcrescimoDesconto As String) As Integer

    Public Declare Function Bematech_FI_TerminaFechamentoCupomCodigoBarrasMFD Lib "BEMAFI32.DLL" (ByVal cMensagem As String, ByVal cTipoCodigo As String, ByVal cCodigo As String, ByVal iAltura As Integer, ByVal iLargura As Integer, ByVal iPosicaoCaracteres As Integer, ByVal iFonte As Integer, ByVal iMargem As Integer, ByVal iCorrecaoErros As Integer, ByVal iColunas As Integer) As Integer

    Public Declare Function Bematech_FI_ImprimeClicheMFD Lib "BEMAFI32.DLL" () As Integer

    Public Declare Function Bematech_FI_ImprimeInformacaoChequeMFD Lib "BEMAFI32.DLL" (ByVal Posicao As Integer, ByVal Linhas As Integer, ByVal Mensagem As String) As Integer

    Public Declare Function Bematech_FI_DownloadMF Lib "BEMAFI32.DLL" (ByVal Arquivo As String) As Integer

    Public Declare Function Bematech_FI_DownloadMFD Lib "BEMAFI32.DLL" (ByVal Arquivo As String, ByVal TipoDownload As String, ByVal ParametroInicial As String, ByVal ParametroFinal As String, ByVal UsuarioECF As String) As Integer

    Public Declare Function Bematech_FI_FormatoDadosMFD Lib "BEMAFI32.DLL" (ByVal ArquivoOrigem As String, ByVal ArquivoDestino As String, ByVal TipoFormato As String, ByVal TipoDownload As String, ByVal ParametroInicial As String, ByVal ParametroFinal As String, ByVal UsuarioECF As String) As Integer

    ' Função para Configuração dos Códigos de Barras 
    Public Declare Function Bematech_FI_ConfiguraCodigoBarrasMFD Lib "BEMAFI32.DLL" (ByVal Altura As Integer, ByVal Largura As Integer, ByVal PosicaoCaracteres As Integer, ByVal Fonte As Integer, ByVal Margem As Integer) As Integer

    ' Funções para Impressão dos Códigos de Barras 
    Public Declare Function Bematech_FI_CodigoBarrasUPCAMFD Lib "BEMAFI32.DLL" (ByVal Codigo As String) As Integer

    Public Declare Function Bematech_FI_CodigoBarrasUPCEMFD Lib "BEMAFI32.DLL" (ByVal Codigo As String) As Integer

    Public Declare Function Bematech_FI_CodigoBarrasEAN13MFD Lib "BEMAFI32.DLL" (ByVal Codigo As String) As Integer

    Public Declare Function Bematech_FI_CodigoBarrasEAN8MFD Lib "BEMAFI32.DLL" (ByVal Codigo As String) As Integer

    Public Declare Function Bematech_FI_CodigoBarrasCODE39MFD Lib "BEMAFI32.DLL" (ByVal Codigo As String) As Integer

    Public Declare Function Bematech_FI_CodigoBarrasCODE93MFD Lib "BEMAFI32.DLL" (ByVal Codigo As String) As Integer

    Public Declare Function Bematech_FI_CodigoBarrasCODE128MFD Lib "BEMAFI32.DLL" (ByVal Codigo As String) As Integer

    Public Declare Function Bematech_FI_CodigoBarrasITFMFD Lib "BEMAFI32.DLL" (ByVal Codigo As String) As Integer

    Public Declare Function Bematech_FI_CodigoBarrasCODABARMFD Lib "BEMAFI32.DLL" (ByVal Codigo As String) As Integer

    Public Declare Function Bematech_FI_CodigoBarrasISBNMFD Lib "BEMAFI32.DLL" (ByVal Codigo As String) As Integer

    Public Declare Function Bematech_FI_CodigoBarrasMSIMFD Lib "BEMAFI32.DLL" (ByVal Codigo As String) As Integer

    Public Declare Function Bematech_FI_CodigoBarrasPLESSEYMFD Lib "BEMAFI32.DLL" (ByVal Codigo As String) As Integer

    Public Declare Function Bematech_FI_CodigoBarrasPDF417MFD Lib "BEMAFI32.DLL" (ByVal NivelCorrecaoErros As Integer, ByVal Altura As Integer, ByVal Largura As Integer, ByVal Colunas As Integer, ByVal Codigo As String) As Integer

#End Region

    'Declaracoes de Metodos de Acesso ao ECF
#Region "  Declaracoes de Metodos de Acesso ao FS318   "


    '**********************************************************************************************************************'
    '                                                                                                                      '
    '                                                       FS318                                                          '
    '                                                                                                                      '
    '**********************************************************************************************************************'

    Public Declare Function Daruma_FIR_ProgramaAliquota Lib "Daruma32.dll" (ByVal Valor_Aliquota As String, ByVal Tipo_Aliquota As Integer) As Integer
    Public Declare Function Daruma_FIR_NomeiaTotalizadorNaoSujeitoIcms Lib "Daruma32.dll" (ByVal Indice_do_Totalizador As Integer, ByVal Nome_do_Totalizador As String) As Integer
    Public Declare Function Daruma_FIR_ProgramaFormasPagamento Lib "Daruma32.dll" (ByVal Descricao_das_Formas_Pagamento As String) As Integer
    Public Declare Function Daruma_FIR_ProgramaOperador Lib "Daruma32.dll" (ByVal Nome_do_Operador As String) As Integer
    Public Declare Function Daruma_FIR_ProgramaArredondamento Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_ProgramaTruncamento Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_LinhasEntreCupons Lib "Daruma32.dll" (ByVal Linhas_Entre_Cupons As Integer) As Integer
    Public Declare Function Daruma_FIR_EspacoEntreLinhas Lib "Daruma32.dll" (ByVal Espaco_Entre_Linhas As Integer) As Integer
    Public Declare Function Daruma_FIR_ProgramaHorarioVerao Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_EqualizaFormasPgto Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_ProgramaVinculados Lib "Daruma32.dll" (ByVal Vinculado As String) As Integer
    Public Declare Function Daruma_FIR_ProgFormasPagtoSemVincular Lib "Daruma32.dll" (ByVal Descricao_da_Forma_Pagamento As String) As Integer
    Public Declare Function Daruma_FIR_ProgramaMsgTaxaServico Lib "Daruma32.dll" (ByVal Mensagem_da_Taxa_de_Servico As String) As Integer
    Public Declare Function Daruma_FIR_AdicionaProdutoCardapio Lib "Daruma32.dll" (ByVal Codigo As String, ByVal Valor_Unitario As String, ByVal Aliquota As String, ByVal Descricao As String) As Integer
    Public Declare Function Daruma_FIR_CfgEspacamentoCupons Lib "Daruma32.dll" (ByVal DistanciaCupons As String) As Integer
    Public Declare Function Daruma_FIR_CfgHoraMinReducaoZ Lib "Daruma32.dll" (ByVal Hora_Min_para_ReducaoZ As String) As Integer
    Public Declare Function Daruma_FIR_CfgLimiarNearEnd Lib "Daruma32.dll" (ByVal NumeroLinhas As String) As Integer
    Public Declare Function Daruma_FIR_CfgHorarioVerao Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FIR_CfgLegProdutos Lib "Daruma32.dll" (ByVal Flag As String) As Integer

    'Cupom
    Public Declare Function Daruma_FIR_AbreCupom Lib "Daruma32.dll" (ByVal Numero_da_Mesa As String) As Integer
    Public Declare Function Daruma_FIR_AbreCupomRestaurante Lib "Daruma32.dll" (ByVal Numero_da_Mesa As String) As Integer
    Public Declare Function Daruma_FIR_AbreCupomBalcao Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_VendeItem Lib "Daruma32.dll" (ByVal Mesa As String, ByVal Codigo As String, ByVal Descricao As String, ByVal Aliquota As String, ByVal Quantidade As String, ByVal Valor_Unitario As String, ByVal Acrescimo_ou_Desconto As String, ByVal Valor_do_Acrescimo_ou_Desconto As String) As Integer
    Public Declare Function Daruma_FIR_VendeItemBalcao Lib "Daruma32.dll" (ByVal Codigo As String, ByVal Quantidade As String, ByVal Acrescimo_ou_Desconto As String, ByVal Valor_do_Acrescimo_ou_Desconto As String) As Integer
    Public Declare Function Daruma_FIR_RegistrarVenda Lib "Daruma32.dll" (ByVal Numero_da_Mesa As String, ByVal Codigo As String, ByVal Quantidade As String, ByVal Acrescimo_ou_Desconto As String, ByVal Valor_do_Acrescimo_ou_Desconto As String) As Integer
    Public Declare Function Daruma_FIR_RegistroVendaSerial Lib "Daruma32.dll" (ByVal Numero_da_Mesa As String) As Integer
    Public Declare Function Daruma_FIR_FechaCupomRestauranteResumido Lib "Daruma32.dll" (ByVal Descricao_da_Forma_de_Pagamento As String, ByVal Mensagem_Promocional As String) As Integer
    Public Declare Function Daruma_FIR_IniciaFechamentoCupom Lib "Daruma32.dll" (ByVal Acrescimo_ou_Desconto As String, ByVal Tipo_do_Acrescimo_ou_Desconto As String, ByVal Valor_do_Acrescimo_ou_Desconto As String) As Integer
    Public Declare Function Daruma_FIR_IniciaFechamentoCupomComServico Lib "Daruma32.dll" (ByVal Acrescimo_ou_Desconto As String, ByVal Tipo_do_Acrescimo_ou_Desconto As String, ByVal Valor_do_Acrescimo_ou_Desconto As String, ByVal Indicador_da_Operacao As String, ByVal Taxa_de_Servico As String) As Integer
    Public Declare Function Daruma_FIR_EfetuaFormaPagamento Lib "Daruma32.dll" (ByVal Descricao_da_Forma_Pagamento As String, ByVal Valor_da_Forma_Pagamento As String) As Integer
    Public Declare Function Daruma_FIR_EfetuaFormaPagamentoDescricaoForma Lib "Daruma32.dll" (ByVal Descricao_da_Forma_Pagamento As String, ByVal Valor_da_Forma_Pagamento As String, ByVal Texto_Livre As String) As Integer
    Public Declare Function Daruma_FIR_IdentificaConsumidor Lib "Daruma32.dll" (ByVal Nome_do_Consumidor As String, ByVal Endereco As String, ByVal CPF_ou_CNPJ As String) As Integer
    Public Declare Function Daruma_FIR_FechaCupomResumido Lib "Daruma32.dll" (ByVal Descricao_da_Forma_de_Pagamento As String, ByVal Mensagem_Promocional As String) As Integer
    Public Declare Function Daruma_FIR_TerminaFechamentoCupom Lib "Daruma32.dll" (ByVal Mensagem_Promocional As String) As Integer
    Public Declare Function Daruma_FIR_TerminaFechamentoCupomID Lib "Daruma32.dll" (ByVal Mensagem_Promocional As String, ByVal Nome_do_Cliente As String, ByVal Endereco_do_Cliente As String, ByVal Documento_do_Cliente As String) As Integer
    Public Declare Function Daruma_FIR_FechaCupomRestaurante Lib "Daruma32.dll" (ByVal Forma_de_Pagamento As String, ByVal Acrescimo_ou_Desconto As String, ByVal Tipo_Acrescimo_ou_Desconto As String, ByVal Valor_Acrescimo_ou_Desconto As String, ByVal Valor_Pago As String, ByVal Mensagem_Promocional As String) As Integer
    Public Declare Function Daruma_FIR_CancelaItem Lib "Daruma32.dll" (ByVal Mesa As String, ByVal Codigo As String, ByVal Descricao As String, ByVal Aliquota As String, ByVal Quantidade As String, ByVal Valor_Unitario As String, ByVal Acrescimo_ou_Desconto As String, ByVal Valor_do_Acrescimo_ou_Desconto As String) As Integer
    Public Declare Function Daruma_FIR_CancelaItemBalcao Lib "Daruma32.dll" (ByVal Codigo_do_Item As String) As Integer
    Public Declare Function Daruma_FIR_CancelaCupom Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_CancelarVenda Lib "Daruma32.dll" (ByVal Numero_da_Mesa As String, ByVal Codigo As String, ByVal Quantidade As String, ByVal Acrescimo_ou_Desconto As String, ByVal Valor_do_Acrescimo_ou_Desconto As String) As Integer

    Public Declare Function Daruma_FIR_TranferirVenda Lib "Daruma32.dll" (ByVal Numero_da_Mesa_Origem As String, ByVal Numero_da_Mesa_Destino As String, ByVal Codigo As String, ByVal Quantidade As String, ByVal Acrescimo_ou_Desconto As String, ByVal Valor_do_Acrescimo_ou_Desconto As String) As Integer
    Public Declare Function Daruma_FIR_TransfereItem Lib "Daruma32.dll" (ByVal Mesa_Origem As String, ByVal Mesa_Destino As String, ByVal Codigo As String, ByVal Descricao As String, ByVal Aliquota As String, ByVal Quantidade As String, ByVal Valor_Unitario As String, ByVal Acrescimo_ou_Desconto As String, ByVal Desconto_Percentual As String) As Integer
    Public Declare Function Daruma_FIR_TranferirMesa Lib "Daruma32.dll" (ByVal Mesa_Origem As String, ByVal Mesa_Destino As String) As Integer
    Public Declare Function Daruma_FIR_ConferenciaMesa Lib "Daruma32.dll" (ByVal Numero_da_Mesa As String, ByVal Mensagem_Promocional As String) As Integer
    Public Declare Function Daruma_FIR_LimparMesa Lib "Daruma32.dll" (ByVal Numero_da_Mesa As String) As Integer
    Public Declare Function Daruma_FIR_ImprimePrimeiroCupomDividido Lib "Daruma32.dll" (ByVal Numero_da_Mesa As String, ByVal Quantidade_Divisoria As String) As Integer
    Public Declare Function Daruma_FIR_RestanteCupomDividido Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_AumentaDescricaoItem Lib "Daruma32.dll" (ByVal Descricao_Extendida As String) As Integer
    Public Declare Function Daruma_FIR_UsaUnidadeMedida Lib "Daruma32.dll" (ByVal Unidade_Medida As String) As Integer
    Public Declare Function Daruma_FIR_EmitirCupomAdicional Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_EstornoFormasPagamento Lib "Daruma32.dll" (ByVal Forma_de_Origem As String, ByVal Nova_Forma As String, ByVal Valor_Total_Pago As String) As Integer

    Public Declare Function Daruma_FIR_AbreComprovanteNaoFiscalVinculado Lib "Daruma32.dll" (ByVal Forma_de_Pagamento As String, ByVal Valor_Pago As String, ByVal Numero_do_Cupom As String) As Integer
    Public Declare Function Daruma_FIR_UsaComprovanteNaoFiscalVinculado Lib "Daruma32.dll" (ByVal Texto_Livre As String) As Integer
    Public Declare Function Daruma_FIR_FechaComprovanteNaoFiscalVinculado Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_RelatorioGerencial Lib "Daruma32.dll" (ByVal Texto_Livre As String) As Integer
    Public Declare Function Daruma_FIR_AbreRelatorioGerencial Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_EnviarTextoCNF Lib "Daruma32.dll" (ByVal Texto_Livre As String) As Integer
    Public Declare Function Daruma_FIR_FechaRelatorioGerencial Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_RecebimentoNaoFiscal Lib "Daruma32.dll" (ByVal Indice_do_Totalizador As String, ByVal Valor_do_Recebimento As String, ByVal Forma_de_Pagamento As String) As Integer
    Public Declare Function Daruma_FIR_AbreRecebimentoNaoFiscal Lib "Daruma32.dll" (ByVal Indice_do_Totalizador As String, ByVal Acrescimo_ou_Desconto As String, ByVal Tipo_Acrescimo_ou_Desconto As String, ByVal Valor_Acrescimo_ou_Desconto As String, ByVal Valor_do_Recebimento As String, ByVal Texto_Livre As String) As Integer
    Public Declare Function Daruma_FIR_EfetuaFormaPagamentoNaoFiscal Lib "Daruma32.dll" (ByVal Forma_de_Pagamento As String, ByVal Valor_da_Forma_Pagamento As String, ByVal Texto_Livre As String) As Integer
    Public Declare Function Daruma_FIR_Sangria Lib "Daruma32.dll" (ByVal Valor_da_Sangria As String) As Integer
    Public Declare Function Daruma_FIR_Suprimento Lib "Daruma32.dll" (ByVal Valor_do_Suprimento As String, ByVal Forma_de_Pagamento As String) As Integer
    Public Declare Function Daruma_FIR_FundoCaixa Lib "Daruma32.dll" (ByVal Valor_do_Fundo_Caixa As String, ByVal Forma_de_Pagamento As String) As Integer
    Public Declare Function Daruma_FIR_LeituraX Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_ReducaoZ Lib "Daruma32.dll" (ByVal Data As String, ByVal Hora As String) As Integer
    Public Declare Function Daruma_FIR_ReducaoZAjustaDataHora Lib "Daruma32.dll" (ByVal Data As String, ByVal Hora As String) As Integer
    Public Declare Function Daruma_FIR_RelatorioMesasAbertas Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_RelatorioMesasAbertasSerial Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_LeituraMemoriaFiscalData Lib "Daruma32.dll" (ByVal Data_Inicial As String, ByVal Data_Final As String) As Integer
    Public Declare Function Daruma_FIR_LeituraMemoriaFiscalReducao Lib "Daruma32.dll" (ByVal Reducao_Inicial As String, ByVal Reducao_Final As String) As Integer
    Public Declare Function Daruma_FIR_LeituraMemoriaFiscalSerialData Lib "Daruma32.dll" (ByVal Data_Inicial As String, ByVal Data_Final As String) As Integer
    Public Declare Function Daruma_FIR_LeituraMemoriaFiscalSerialReducao Lib "Daruma32.dll" (ByVal Reducao_Inicial As String, ByVal Reducao_Final As String) As Integer
    Public Declare Function Daruma_FIR_LeituraMemoriaTrabalho Lib "Daruma32.dll" () As Integer

    Public Declare Function Daruma_FIR_StatusCupomFiscal Lib "Daruma32.dll" (ByVal StatusCupomFiscal As String) As Integer
    Public Declare Function Daruma_FIR_StatusRelatorioGerencial Lib "Daruma32.dll" (ByVal StatusRelGerencial As String) As Integer
    Public Declare Function Daruma_FIR_StatusComprovanteNaoFiscalVinculado Lib "Daruma32.dll" (ByVal StatusCNFV As String) As Integer
    Public Declare Function Daruma_FIR_StatusComprovanteNaoFiscalNaoVinculado Lib "Daruma32.dll" (ByVal StatusCNFNV As String) As Integer
    Public Declare Function Daruma_FIR_VerificaImpressoraLigada Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_VerificaTotalizadoresParciais Lib "Daruma32.dll" (ByVal Totalizadores As String) As Integer
    Public Declare Function Daruma_FIR_VerificaModoOperacao Lib "Daruma32.dll" (ByVal Modo As String) As Integer
    Public Declare Function Daruma_FIR_VerificaTotalizadoresNaoFiscais Lib "Daruma32.dll" (ByVal Totalizadores As String) As Integer
    Public Declare Function Daruma_FIR_VerificaTotalizadoresNaoFiscaisEx Lib "Daruma32.dll" (ByVal Totalizadores As String) As Integer
    Public Declare Function Daruma_FIR_VerificaTruncamento Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FIR_VerificaAliquotasIss Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FIR_VerificaIndiceAliquotasIss Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FIR_VerificaRecebimentoNaoFiscal Lib "Daruma32.dll" (ByVal Recebimentos As String) As Integer
    Public Declare Function Daruma_FIR_VerificaTipoImpressora Lib "Daruma32.dll" (ByRef TipoImpressora As Integer) As Integer
    Public Declare Function Daruma_FIR_VerificaStatusCheque Lib "Daruma32.dll" (ByVal StatusCheque As Integer) As Integer
    Public Declare Function Daruma_FIR_VerificaModeloECF Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_VerificaDescricaoFormasPagamento Lib "Daruma32.dll" (ByVal Descricao As String) As Integer
    Public Declare Function Daruma_FIR_VerificaXPendente Lib "Daruma32.dll" (ByVal XPendente As String) As Integer
    Public Declare Function Daruma_FIR_VerificaZPendente Lib "Daruma32.dll" (ByVal ZPendente As String) As Integer
    Public Declare Function Daruma_FIR_VerificaDiaAberto Lib "Daruma32.dll" (ByVal DiaAberto As String) As Integer
    Public Declare Function Daruma_FIR_VerificaHorarioVerao Lib "Daruma32.dll" (ByVal HoraioVerao As String) As Integer
    Public Declare Function Daruma_FIR_VerificaFormasPagamento Lib "Daruma32.dll" (ByVal Formas As String) As Integer
    Public Declare Function Daruma_FIR_VerificaFormasPagamentoEx Lib "Daruma32.dll" (ByVal FormasEx As String) As Integer
    Public Declare Function Daruma_FIR_VerificaEpromConectada Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FIR_VerificaEstadoImpressora Lib "Daruma32.dll" (ByRef ACK As Integer, ByRef ST1 As Integer, ByRef ST2 As Integer) As Integer

    Public Declare Function Daruma_FIR_ClicheProprietario Lib "Daruma32.dll" (ByVal Cliche As String) As Integer
    Public Declare Function Daruma_FIR_ClicheProprietarioEx Lib "Daruma32.dll" (ByVal ClicheEx As String) As Integer
    Public Declare Function Daruma_FIR_NumeroCaixa Lib "Daruma32.dll" (ByVal NumeroCaixa As String) As Integer
    Public Declare Function Daruma_FIR_NumeroLoja Lib "Daruma32.dll" (ByVal NumeroLoja As String) As Integer
    Public Declare Function Daruma_FIR_NumeroSerie Lib "Daruma32.dll" (ByVal NumeroSerie As String) As Integer
    Public Declare Function Daruma_FIR_VersaoFirmware Lib "Daruma32.dll" (ByVal VersaoFirmware As String) As Integer
    Public Declare Function Daruma_FIR_CGC_IE Lib "Daruma32.dll" (ByVal CGC As String, ByVal IE As String) As Integer
    Public Declare Function Daruma_FIR_LerAliquotasComIndice Lib "Daruma32.dll" (ByVal AliquotasComIndice As String) As Integer
    Public Declare Function Daruma_FIR_NumeroCupom Lib "Daruma32.dll" (ByVal NumeroCupom As String) As Integer
    Public Declare Function Daruma_FIR_COO Lib "Daruma32.dll" (ByVal Inicial As String, ByVal Final As String) As Integer
    Public Declare Function Daruma_FIR_MinutosLigada Lib "Daruma32.dll" (ByVal Minutos As String) As Integer
    Public Declare Function Daruma_FIR_NumeroSubstituicoesProprietario Lib "Daruma32.dll" (ByVal NumeroSubstituicoes As String) As Integer
    Public Declare Function Daruma_FIR_NumeroIntervencoes Lib "Daruma32.dll" (ByVal NumeroIntervencoes As String) As Integer
    Public Declare Function Daruma_FIR_NumeroReducoes Lib "Daruma32.dll" (ByVal NumeroReducoes As String) As Integer
    Public Declare Function Daruma_FIR_NumeroCuponsCancelados Lib "Daruma32.dll" (ByVal NumeroCancelamentos As String) As Integer
    Public Declare Function Daruma_FIR_NumeroOperacoesNaoFiscais Lib "Daruma32.dll" (ByVal NumeroOperacoes As String) As Integer
    Public Declare Function Daruma_FIR_DataHoraImpressora Lib "Daruma32.dll" (ByVal Data As String, ByVal Hora As String) As Integer
    Public Declare Function Daruma_FIR_DataHoraReducao Lib "Daruma32.dll" (ByVal Data As String, ByVal Hora As String) As Integer
    Public Declare Function Daruma_FIR_DataMovimento Lib "Daruma32.dll" (ByVal Data As String) As Integer
    Public Declare Function Daruma_FIR_ContadoresTotalizadoresNaoFiscais Lib "Daruma32.dll" (ByVal Contadores As String) As Integer

    Public Declare Function Daruma_FIR_VendaBruta Lib "Daruma32.dll" (ByVal VendaBruta As String) As Integer
    Public Declare Function Daruma_FIR_GrandeTotal Lib "Daruma32.dll" (ByVal GrandeTotal As String) As Integer
    Public Declare Function Daruma_FIR_Descontos Lib "Daruma32.dll" (ByVal ValorDescontos As String) As Integer
    Public Declare Function Daruma_FIR_Acrescimos Lib "Daruma32.dll" (ByVal ValorAcrescimos As String) As Integer
    Public Declare Function Daruma_FIR_Cancelamentos Lib "Daruma32.dll" (ByVal ValorCancelamentos As String) As Integer
    Public Declare Function Daruma_FIR_DadosUltimaReducao Lib "Daruma32.dll" (ByVal DadosReducao As String) As Integer
    Public Declare Function Daruma_FIR_SubTotal Lib "Daruma32.dll" (ByVal SubTotal As String) As Integer
    Public Declare Function Daruma_FIR_RetornoAliquotas Lib "Daruma32.dll" (ByVal Aliquotas As String) As Integer
    Public Declare Function Daruma_FIR_ValorPagoUltimoCupom Lib "Daruma32.dll" (ByVal ValorCupom As String) As Integer
    Public Declare Function Daruma_FIR_ValorPagoUltimoCupomFormatado Lib "Daruma32.dll" (ByVal ValorCupom As String) As Integer
    Public Declare Function Daruma_FIR_ValorFormaPagamento Lib "Daruma32.dll" (ByVal FormaPagamento As String, ByVal Valor As String) As Integer
    Public Declare Function Daruma_FIR_ValorTotalizadorNaoFiscal Lib "Daruma32.dll" (ByVal Totalizador As String, ByVal Valor As String) As Integer
    Public Declare Function Daruma_FIR_UltimoItemVendido Lib "Daruma32.dll" (ByVal NumeroItem As String) As Integer
    Public Declare Function Daruma_FIR_UltimoItemVendidoValor Lib "Daruma32.dll" (ByVal NumeroItem As String) As Integer
    Public Declare Function Daruma_FIR_UltimaFormaPagamento Lib "Daruma32.dll" (ByVal Descricao_da_Forma As String, ByVal Valor_da_Forma As String) As Integer
    Public Declare Function Daruma_FIR_TipoUltimoDocumento Lib "Daruma32.dll" (ByVal TipoUltimoDoc As String) As Integer

    Public Declare Function Daruma_FIR_MapaResumo Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_RelatorioTipo60Analitico Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_RelatorioTipo60Mestre Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_FlagsFiscais Lib "Daruma32.dll" (ByRef Flag As Integer) As Integer
    Public Declare Function Daruma_FIR_PalavraStatus Lib "Daruma32.dll" (ByVal PalavraStatus As String) As Integer
    Public Declare Function Daruma_FIR_PalavraStatusBinario Lib "Daruma32.dll" (ByVal PalavraStatusBinario As String) As Integer
    Public Declare Function Daruma_FIR_SimboloMoeda Lib "Daruma32.dll" (ByVal SimboloMoeda As String) As Integer
    Public Declare Function Daruma_FIR_RetornoImpressora Lib "Daruma32.dll" (ByRef ACK As Integer, ByRef ST1 As Integer, ByRef ST2 As Integer) As Integer
    Public Declare Function Daruma_FIR_RetornaErroExtendido Lib "Daruma32.dll" (ByVal ErroExtendido As String) As Integer
    Public Declare Function Daruma_FIR_RetornaAcrescimoNF Lib "Daruma32.dll" (ByVal AcrescimoNF As String) As Integer
    Public Declare Function Daruma_FIR_RetornaCFCancelados Lib "Daruma32.dll" (ByVal CFCancelados As String) As Integer
    Public Declare Function Daruma_FIR_RetornaCNFCancelados Lib "Daruma32.dll" (ByVal CNFCancelados As String) As Integer
    Public Declare Function Daruma_FIR_RetornaCLX Lib "Daruma32.dll" (ByVal CLX As String) As Integer
    Public Declare Function Daruma_FIR_RetornaCNFNV Lib "Daruma32.dll" (ByVal CNFNV As String) As Integer
    Public Declare Function Daruma_FIR_RetornaCNFV Lib "Daruma32.dll" (ByVal CNFV As String) As Integer
    Public Declare Function Daruma_FIR_RetornaCRO Lib "Daruma32.dll" (ByVal CRO As String) As Integer
    Public Declare Function Daruma_FIR_RetornaCRZ Lib "Daruma32.dll" (ByVal CRZ As String) As Integer
    Public Declare Function Daruma_FIR_RetornaCRZRestante Lib "Daruma32.dll" (ByVal CRZRestante As String) As Integer
    Public Declare Function Daruma_FIR_RetornaCancelamentoNF Lib "Daruma32.dll" (ByVal CancelamentoNF As String) As Integer
    Public Declare Function Daruma_FIR_RetornaDescontoNF Lib "Daruma32.dll" (ByVal DescontoNF As String) As Integer
    Public Declare Function Daruma_FIR_RetornaGNF Lib "Daruma32.dll" (ByVal GNF As String) As Integer
    Public Declare Function Daruma_FIR_RetornaTempoImprimindo Lib "Daruma32.dll" (ByVal TempoImprimindo As String) As Integer
    Public Declare Function Daruma_FIR_RetornaTempoLigado Lib "Daruma32.dll" (ByVal TempoLigado As String) As Integer
    Public Declare Function Daruma_FIR_RetornaTotalPagamentos Lib "Daruma32.dll" (ByVal TotalPagamentos As String) As Integer
    Public Declare Function Daruma_FIR_RetornaTroco Lib "Daruma32.dll" (ByVal Troco As String) As Integer
    Public Declare Function Daruma_FIR_RetornaZeros Lib "Daruma32.dll" (ByVal Zeros As String) As Integer
    Public Declare Function Daruma_FIR_RetornaValorComprovanteNaoFiscal Lib "Daruma32.dll" (ByVal Indice_CNF As String, ByVal Informacao As String) As Integer
    Public Declare Function Daruma_FIR_RetornaIndiceComprovanteNaoFiscal Lib "Daruma32.dll" (ByVal DescricaoRegistrCNF As String, ByVal RefIndice As String) As Integer
    Public Declare Function Daruma_FIR_RetornaRegistradoresNaoFiscais Lib "Daruma32.dll" (ByVal RegistrNaoFiscais As String) As Integer
    Public Declare Function Daruma_FIR_RetornaRegistradoresFiscais Lib "Daruma32.dll" (ByVal RegistrFiscais As String) As Integer

    Public Declare Function Daruma_FIR_VerificaDocAutenticacao Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_Autenticacao Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_AutenticacaoStr Lib "Daruma32.dll" (ByVal Autenticacao_Str As String) As Integer
    Public Declare Function Daruma_FIR_VerificaEstadoGaveta Lib "Daruma32.dll" (ByRef Estado_Gaveta As Integer) As Integer
    Public Declare Function Daruma_FIR_VerificaEstadoGavetaStr Lib "Daruma32.dll" (ByVal Estado_Gaveta As String) As Integer
    Public Declare Function Daruma_FIR_AcionaGaveta Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_AbrePortaSerial Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_FechaPortaSerial Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_AberturaDoDia Lib "Daruma32.dll" (ByVal Valor_do_Suprimento As String, ByVal Forma_de_Pagamento As String) As Integer
    Public Declare Function Daruma_FIR_FechamentoDoDia Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_ImprimeConfiguracoesImpressora Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_RegistraNumeroSerie Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_VerificaNumeroSerie Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_RetornaSerialCriptografado Lib "Daruma32.dll" (ByVal SerialCriptografado As String, ByVal NumeroSerial As String) As Integer
    Public Declare Function Daruma_FIR_ConfiguraHorarioVerao Lib "Daruma32.dll" (ByVal DataEntrada As String, ByVal DataSaida As String, ByVal Controle As String) As Integer
    Public Declare Function Daruma_FIR_ZeraCardapio Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_ImprimeCardapio Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIR_CardapioSerial Lib "Daruma32.dll" () As Integer


    ''''''''''''''''''''''''''


#End Region

#Region "  Declaracoes de Metodos de Acesso ao ECF  "

    '**********************************************************************************************************************'
    '                                                                                                                      '
    '                                                       MFD                                                          '
    '                                                                                                                      '
    '**********************************************************************************************************************'
    'Função Codigo de barras da MFD

    Public Declare Function Daruma_FIMFD_ImprimeCodigoBarras Lib "Daruma32.dll" (ByVal Tipo As String, ByVal Codigo As String, ByVal Largura As String, ByVal Altura As String, ByVal Posicao As String) As Integer
    Public Declare Function Daruma_FIMFD_DownloadDaMFD Lib "Daruma32.dll" (ByVal CoInicial As String, ByVal CoFinal As String) As Integer
    Public Declare Function Daruma_FIMFD_CasasDecimaisProgramada Lib "Daruma32.dll" (ByVal Quantidade As String, ByVal Valor As String) As Integer
    Public Declare Function Daruma_FIMFD_IndicePrimeiroVinculado Lib "Daruma32.dll" (ByVal Indice As String) As Integer
    Public Declare Function Daruma_FIMFD_RetornaInformacao Lib "Daruma32.dll" (ByVal Indice As String, ByVal Valor As String) As Integer
    Public Declare Function Daruma_FIMFD_TerminaFechamentoCupomCodigoBarras Lib "Daruma32.dll" (ByVal Mensagem As String, ByVal Tipo As String, ByVal Codigo As String, ByVal Largura As String, ByVal Altura As String, ByVal Posicao As String) As Integer
    Public Declare Function Daruma_FIMFD_SinalSonoro Lib "Daruma32.dll" (ByVal NumeroBeeps As String) As Integer
    Public Declare Function Daruma_FIMFD_StatusCupomFiscal Lib "Daruma32.dll" (ByVal StsCF_MFD As String) As Integer
    Public Declare Function Daruma_FIMFD_ProgramaRelatoriosGerenciais Lib "Daruma32.dll" (ByVal NomeRelatorio As String) As Integer
    Public Declare Function Daruma_FIMFD_VerificaRelatoriosGerenciais Lib "Daruma32.dll" (ByVal Relatorios As String) As Integer
    Public Declare Function Daruma_FIMFD_AbreRelatorioGerencial Lib "Daruma32.dll" (ByVal NomeRelatorio As String) As Integer
    Public Declare Function Daruma_FIMFD_EmitirCupomAdicional Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIMFD_AcionarGuilhotina Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FIMFD_EqualizarVelocidade Lib "Daruma32.dll" (ByVal EqualizaVelocidade As String) As Integer
    Public Declare Function Daruma_FIMFD_AbreRecebimentoNaoFiscal Lib "Daruma32.dll" (ByVal CPF As String, ByVal Nome As String, ByVal Endereco As String) As Integer
    Public Declare Function Daruma_FIMFD_RecebimentoNaoFiscal Lib "Daruma32.dll" (ByVal DescricaoTotalizador As String, ByVal AcresDesc As String, ByVal TipoAcresDesc As String, ByVal ValorAcresDesc As String, ByVal ValorRecebimento As String) As Integer
    Public Declare Function Daruma_FIMFD_IniciaFechamentoNaoFiscal Lib "Daruma32.dll" (ByVal AcresDesc As String, ByVal TipoAcresDesc As String, ByVal ValorAcresDesc As String) As Integer
    Public Declare Function Daruma_FIMFD_EfetuaFormaPagamentoNaoFiscal Lib "Daruma32.dll" (ByVal FormaPgto As String, ByVal Valor As String, ByVal Observacao As String) As Integer
    Public Declare Function Daruma_FIMFD_TerminaFechamentoNaoFiscal Lib "Daruma32.dll" (ByVal MsgPromo As String) As Integer
    Public Declare Function Daruma_FIMFD_ProgramarGuilhotina Lib "Daruma32.dll" (ByVal Separacao_entre_Documentos As String, ByVal Linhas_para_Acionamento_Guilhotina As String, ByVal Status_da_Guilhotina As String, ByVal Impressao_Antecipada_Cliche As String) As Integer




    '**********************************************************************************************************************'
    '                                                                                                                      '
    '                                                       FS345                                                          '
    '                                                                                                                      '
    '**********************************************************************************************************************'

    'Metodos de Verificacao

    Public Declare Function Daruma_FI_ResetaImpressora Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_LeituraXSerial Lib "Daruma32.dll" () As Integer

    'Metodos Cupom
    Public Declare Function Daruma_FI_AbreCupom Lib "Daruma32.dll" (ByVal CPF_ou_CNPJ As String) As Integer
    Public Declare Function Daruma_FI_VendeItem Lib "Daruma32.dll" (ByVal Codigo As String, ByVal Descricao As String, ByVal Aliquota As String, ByVal TipoQuantidade As String, ByVal Quantidade As String, ByVal CasasDecimais As Integer, ByVal ValorUnitario As String, ByVal TipoDesconto As String, ByVal Desconto As String) As Integer
    Public Declare Function Daruma_FI_VendeItemDepartamento Lib "Daruma32.dll" (ByVal Codigo As String, ByVal Descricao As String, ByVal Aliquota As String, ByVal ValorUnitario As String, ByVal Quantidade As String, ByVal Acrescimo As String, ByVal Desconto As String, ByVal IndiceDepartamento As String, ByVal UnidadeMedida As String) As Integer
    Public Declare Function Daruma_FI_VendeItemTresDecimais Lib "Daruma32.dll" (ByVal Codigo As String, ByVal Descricao As String, ByVal Aliquota As String, ByVal Quantidade As String, ByVal ValorUnitario As String, ByVal Desconto_ou_Acrescimo As String, ByVal Percentual_Desconto_ou_Acrescimo As String) As Integer
    Public Declare Function Daruma_FI_FechaCupomResumido Lib "Daruma32.dll" (ByVal FormaPagamento As String, ByVal Mensagem As String) As Integer
    Public Declare Function Daruma_FI_IniciaFechamentoCupom Lib "Daruma32.dll" (ByVal AcrescimoDesconto As String, ByVal TipoAcrescimoDesconto As String, ByVal ValorAcrescimoDesconto As String) As Integer
    Public Declare Function Daruma_FI_EfetuaFormaPagamento Lib "Daruma32.dll" (ByVal FormaPagamento As String, ByVal ValorFormaPagamento As String) As Integer
    Public Declare Function Daruma_FI_EfetuaFormaPagamentoDescricaoForma Lib "Daruma32.dll" (ByVal FormaPagamento As String, ByVal ValorFormaPagamento As String, ByVal TextoLivre As String) As Integer
    Public Declare Function Daruma_FI_IdentificaConsumidor Lib "Daruma32.dll" (ByVal NomeConsumidor As String, ByVal Endereco As String, ByVal CPF_ou_CNPJ As String) As Integer
    Public Declare Function Daruma_FI_TerminaFechamentoCupom Lib "Daruma32.dll" (ByVal Mensagem As String) As Integer
    Public Declare Function Daruma_FI_FechaCupom Lib "Daruma32.dll" (ByVal FormaPagamento As String, ByVal AcrescimoDesconto As String, ByVal TipoAcrescimoDesconto As String, ByVal ValorAcrecimoDesconto As String, ByVal ValorPago As String, ByVal Mensagem As String) As Integer
    Public Declare Function Daruma_FI_CancelaItemAnterior Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_CancelaItemGenerico Lib "Daruma32.dll" (ByVal NumeroItem As String) As Integer
    Public Declare Function Daruma_FI_CancelaCupom Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_AumentaDescricaoItem Lib "Daruma32.dll" (ByVal Descricao As String) As Integer
    Public Declare Function Daruma_FI_UsaUnidadeMedida Lib "Daruma32.dll" (ByVal UnidadeMedida As String) As Integer
    Public Declare Function Daruma_FI_EmitirCupomAdicional Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_EstornoFormasPagamento Lib "Daruma32.dll" (ByVal FormaOrigem As String, ByVal FormaDestino As String, ByVal Valor As String) As Integer

    'Metodos para Recebimentos e Relatorios
    Public Declare Function Daruma_FI_AbreComprovanteNaoFiscalVinculado Lib "Daruma32.dll" (ByVal FormaPagamento As String, ByVal Valor As String, ByVal NumeroCupom As String) As Integer
    Public Declare Function Daruma_FI_UsaComprovanteNaoFiscalVinculado Lib "Daruma32.dll" (ByVal Texto As String) As Integer
    Public Declare Function Daruma_FI_FechaComprovanteNaoFiscalVinculado Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_RelatorioGerencial Lib "Daruma32.dll" (ByVal Texto As String) As Integer
    Public Declare Function Daruma_FI_AbreRelatorioGerencial Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_EnviarTextoCNF Lib "Daruma32.dll" (ByVal Texto As String) As Integer
    Public Declare Function Daruma_FI_FechaRelatorioGerencial Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_RecebimentoNaoFiscal Lib "Daruma32.dll" (ByVal DescricaoTotalizador As String, ByVal ValorRecebimento As String, ByVal FormaPagamento As String) As Integer
    Public Declare Function Daruma_FI_AbreRecebimentoNaoFiscal Lib "Daruma32.dll" (ByVal DescricaoTotalizador As String, ByVal AcrescimoDesconto As String, ByVal TipoAcrescimoDesconto As String, ByVal ValorAcrescimoDesconto As String, ByVal ValorRecebimento As String, ByVal TextoLivreto As String) As Integer
    Public Declare Function Daruma_FI_EfetuaFormaPagamentoNaoFiscal Lib "Daruma32.dll" (ByVal FormaPagamento As String, ByVal ValorFormaPagamento As String, ByVal ObsLivre As String) As Integer
    Public Declare Function Daruma_FI_Sangria Lib "Daruma32.dll" (ByVal Valor As String) As Integer
    Public Declare Function Daruma_FI_Suprimento Lib "Daruma32.dll" (ByVal Valor As String, ByVal FormaPagamento As String) As Integer
    Public Declare Function Daruma_FI_FundoCaixa Lib "Daruma32.dll" (ByVal ValorPagamento As String, ByVal FormaPagamento As String) As Integer
    Public Declare Function Daruma_FI_LeituraX Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_ReducaoZ Lib "Daruma32.dll" (ByVal Data As String, ByVal Hora As String) As Integer
    Public Declare Function Daruma_FI_ReducaoZAjustaDataHora Lib "Daruma32.dll" (ByVal Data As String, ByVal Hora As String) As Integer
    Public Declare Function Daruma_FI_LeituraMemoriaFiscalData Lib "Daruma32.dll" (ByVal DataInicial As String, ByVal DataFinal As String) As Integer
    Public Declare Function Daruma_FI_LeituraMemoriaFiscalReducao Lib "Daruma32.dll" (ByVal ReducaoInicial As String, ByVal ReducaoFinal As String) As Integer
    Public Declare Function Daruma_FI_LeituraMemoriaFiscalSerialData Lib "Daruma32.dll" (ByVal DataInicial As String, ByVal DataFinal As String) As Integer
    Public Declare Function Daruma_FI_LeituraMemoriaFiscalSerialReducao Lib "Daruma32.dll" (ByVal ReducaoInicial As String, ByVal ReducaoFinal As String) As Integer

    'Metodos Modo Gaveta, Autentica e Outras
    Public Declare Function Daruma_FI_VerificaDocAutenticacao Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_Autenticacao Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_AutenticacaoStr Lib "Daruma32.dll" (ByVal AtenticacaoStr As String) As Integer
    Public Declare Function Daruma_FI_VerificaEstadoGaveta Lib "Daruma32.dll" (ByRef EstadoGaveta As Integer) As Integer
    Public Declare Function Daruma_FI_VerificaEstadoGavetaStr Lib "Daruma32.dll" (ByVal EstadoGaveta As String) As Integer
    Public Declare Function Daruma_FI_AcionaGaveta Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_AbrePortaSerial Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_FechaPortaSerial Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_AberturaDoDia Lib "Daruma32.dll" (ByVal Valor As String, ByVal FormaPagamento As String) As Integer
    Public Declare Function Daruma_FI_FechamentoDoDia Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_ImprimeConfiguracoesImpressora Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_RegistraNumeroSerie Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_VerificaNumeroSerie Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_RetornaSerialCriptografado Lib "Daruma32.dll" (ByVal SerialCriptografado As String, ByVal NumeroSerial As String) As Integer
    Public Declare Function Daruma_FI_ConfiguraHorarioVerao Lib "Daruma32.dll" (ByVal DataEntrada As String, ByVal DataSaida As String, ByVal Controle As String) As Integer
    Public Declare Function Daruma_FI_GeraCriptografia Lib "Daruma32.dll" (ByVal Str_Input As String, ByVal Str_Output As String) As Integer
    'Metodos Prog e Config
    Public Declare Function Daruma_FI_ProgramaAliquota Lib "Daruma32.dll" (ByVal Aliquota As String, ByVal ICMS_ou_ISS As Integer) As Integer
    Public Declare Function Daruma_FI_NomeiaTotalizadorNaoSujeitoIcms Lib "Daruma32.dll" (ByVal Indice As Integer, ByVal Totalizador As String) As Integer
    Public Declare Function Daruma_FI_ProgramaFormasPagamento Lib "Daruma32.dll" (ByVal DescricaoFormasPgto As String) As Integer
    Public Declare Function Daruma_FI_ProgramaOperador Lib "Daruma32.dll" (ByVal NomeOperador As String) As Integer
    Public Declare Function Daruma_FI_ProgramaArredondamento Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_ProgramaTruncamento Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_LinhasEntreCupons Lib "Daruma32.dll" (ByVal Linhas As Integer) As Integer
    Public Declare Function Daruma_FI_EspacoEntreLinhas Lib "Daruma32.dll" (ByVal Dots As Integer) As Integer
    Public Declare Function Daruma_FI_ProgramaHorarioVerao Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_EqualizaFormasPgto Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_ProgramaVinculados Lib "Daruma32.dll" (ByVal Descricao As String) As Integer
    Public Declare Function Daruma_FI_ProgFormasPagtoSemVincular Lib "Daruma32.dll" (ByVal Descricao As String) As Integer

    'Metodos de Configuracao do ECF
    Public Declare Function Daruma_FI_CfgFechaAutomaticoCupom Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FI_CfgRedZAutomatico Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FI_CfgLeituraXAuto Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FI_CfgImpEstGavVendas Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FI_CfgCalcArredondamento Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FI_CfgHorarioVerao Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FI_CfgSensorAut Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FI_CfgCupomAdicional Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FI_CfgPermMensPromCNF Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FI_CfgEspacamentoCupons Lib "Daruma32.dll" (ByVal DistanciaCupons As String) As Integer
    Public Declare Function Daruma_FI_CfgHoraMinReducaoZ Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FI_CfgLimiarNearEnd Lib "Daruma32.dll" (ByVal NumeroLinhas As String) As Integer
    Public Declare Function Daruma_FI_CfgLegProdutos Lib "Daruma32.dll" (ByVal Flag As String) As Integer

    'Metodos para Configuracao do Registry
    Public Declare Function Daruma_Registry_AplMensagem1 Lib "Daruma32.dll" (ByVal Str_AplMensagem_1 As String) As Integer
    Public Declare Function Daruma_Registry_AplMensagem2 Lib "Daruma32.dll" (ByVal Str_AplMensagem_2 As String) As Integer
    Public Declare Function Daruma_Registry_AlteraRegistry Lib "Daruma32.dll" (ByVal NomeChave As String, ByVal ValorChave As String) As Integer
    Public Declare Function Daruma_Registry_Velocidade Lib "Daruma32.dll" (ByVal VelocidadeDaPortaSerial As String) As Integer
    Public Declare Function Daruma_Registry_Porta Lib "Daruma32.dll" (ByVal NomePorta As String) As Integer
    Public Declare Function Daruma_Registry_Path Lib "Daruma32.dll" (ByVal Path As String) As Integer
    Public Declare Function Daruma_Registry_Status Lib "Daruma32.dll" (ByVal Status As String) As Integer
    Public Declare Function Daruma_Registry_StatusFuncao Lib "Daruma32.dll" (ByVal StatusFuncao As String) As Integer
    Public Declare Function Daruma_Registry_Retorno Lib "Daruma32.dll" (ByVal Retorno As String) As Integer
    Public Declare Function Daruma_Registry_ControlePorta Lib "Daruma32.dll" (ByVal ControlePorta As String) As Integer
    Public Declare Function Daruma_Registry_ModoGaveta Lib "Daruma32.dll" (ByVal ModoGaveta As String) As Integer
    Public Declare Function Daruma_Registry_Log Lib "Daruma32.dll" (ByVal Log As String) As Integer
    Public Declare Function Daruma_Registry_NomeLog Lib "Daruma32.dll" (ByVal NomeLog As String) As Integer
    Public Declare Function Daruma_Registry_Separador Lib "Daruma32.dll" (ByVal Separador As String) As Integer
    Public Declare Function Daruma_Registry_SeparaMsgPromo Lib "Daruma32.dll" (ByVal SeparaMsgPromo As String) As Integer
    Public Declare Function Daruma_Registry_ZAutomatica Lib "Daruma32.dll" (ByVal ZAutomatica As String) As Integer
    Public Declare Function Daruma_Registry_XAutomatica Lib "Daruma32.dll" (ByVal XAutomatica As String) As Integer
    Public Declare Function Daruma_Registry_VendeItemUmaLinha Lib "Daruma32.dll" (ByVal VendeItem1Lin13Dig As String) As Integer
    Public Declare Function Daruma_Registry_Default Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_Registry_RetornaValor Lib "Daruma32.dll" (ByVal Produto As String, ByVal Chave As String, ByVal Valor As String) As Integer
    Public Declare Function Daruma_Registry_TerminalServer Lib "Daruma32.dll" (ByVal TerminalServer As String) As Integer
    Public Declare Function Daruma_Registry_ErroExtendidoOk Lib "Daruma32.dll" (ByVal ValorErro As String) As Integer
    Public Declare Function Daruma_Registry_AbrirDiaFiscal Lib "Daruma32.dll" (ByVal AbrirDiaFiscal As String) As Integer
    Public Declare Function Daruma_Registry_VendaAutomatica Lib "Daruma32.dll" (ByVal VendaAutomatica As String) As Integer
    Public Declare Function Daruma_Registry_IgnorarPoucoPapel Lib "Daruma32.dll" (ByVal IgnorarPoucoPapel As String) As Integer
    Public Declare Function Daruma_Registry_ImprimeRegistry Lib "Daruma32.dll" (ByVal Produto As String) As Integer
    Public Declare Function Daruma_Registry_PCExpanionLogin Lib "Daruma32.dll" (ByVal Flag_Login As String) As Integer
    Public Declare Function Daruma_Registry_TEF_NumeroLinhasImpressao Lib "Daruma32.dll" (ByVal NumeroLinhasImpressao As String) As Integer
    Public Declare Function Daruma_Registry_MFD_ArredondaValor Lib "Daruma32.dll" (ByVal ArredondaValor As String) As Integer
    Public Declare Function Daruma_Registry_MFDValorFinal Lib "Daruma32.dll" (ByVal ValorFinal As String) As Integer
    Public Declare Function Daruma_Registry_MFD_ArredondaQuantidade Lib "Daruma32.dll" (ByVal ArredondaQuantidade As String) As Integer
    Public Declare Function Daruma_Registry_MFD_ProgramarSinalSonoro Lib "Daruma32.dll" (ByVal NomeChave As String, ByVal Valor As String) As Integer
    Public Declare Function Daruma_Registry_MFD_LeituraMFCompleta Lib "Daruma32.dll" (ByVal Valor As String) As Integer
    Public Declare Function Daruma_Registry_NumeroSerieNaoFormatado Lib "Daruma32.dll" (ByVal Formatado As String) As Integer
    Public Declare Function Daruma_Registry_CupomAdicionalDll Lib "Daruma32.dll" (ByVal AdicionalDll As String) As Integer
    Public Declare Function Daruma_Registry_CupomAdicionalDllConfig Lib "Daruma32.dll" (ByVal ConfigAdicionalDll As String) As Integer
    Public Declare Function Daruma_Registry_LogTamMaxMB Lib "Daruma32.dll" (ByVal LogTamMaxMB As String) As Integer
    Public Declare Function Daruma_Registry_SintegraSeparador Lib "Daruma32.dll" (ByVal Separador As String) As Integer
    Public Declare Function Daruma_Registry_SintegraPath Lib "Daruma32.dll" (ByVal Path As String) As Integer


    'Metodos de Status
    Public Declare Function Daruma_FI_StatusCupomFiscal Lib "Daruma32.dll" (ByVal StsCF As String) As Integer
    Public Declare Function Daruma_FI_StatusRelatorioGerencial Lib "Daruma32.dll" (ByVal StsGerencial As String) As Integer
    Public Declare Function Daruma_FI_StatusComprovanteNaoFiscalVinculado Lib "Daruma32.dll" (ByVal StsCNFV As String) As Integer
    Public Declare Function Daruma_FI_StatusComprovanteNaoFiscalNaoVinculado Lib "Daruma32.dll" (ByVal StsCNFV As String) As Integer
    Public Declare Function Daruma_FI_VerificaImpressoraLigada Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_VerificaTotalizadoresParciais Lib "Daruma32.dll" (ByVal Totalizadores_Parciais As String) As Integer
    Public Declare Function Daruma_FI_VerificaModoOperacao Lib "Daruma32.dll" (ByVal Modo As String) As Integer
    Public Declare Function Daruma_FI_VerificaTotalizadoresNaoFiscais Lib "Daruma32.dll" (ByVal Totalizadores As String) As Integer
    Public Declare Function Daruma_FI_VerificaTotalizadoresNaoFiscaisEx Lib "Daruma32.dll" (ByVal Totalizadores As String) As Integer
    Public Declare Function Daruma_FI_VerificaTruncamento Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FI_VerificaAliquotasIss Lib "Daruma32.dll" (ByVal AliquotasIss As String) As Integer
    Public Declare Function Daruma_FI_VerificaRecebimentoNaoFiscal Lib "Daruma32.dll" (ByVal Recebimentos As String) As Integer
    Public Declare Function Daruma_FI_VerificaTipoImpressora Lib "Daruma32.dll" (ByRef TipoImpressora As Integer) As Integer
    Public Declare Function Daruma_FI_VerificaIndiceAliquotasIss Lib "Daruma32.dll" (ByVal AliquotaIss As String) As Integer
    Public Declare Function Daruma_FI_VerificaModeloECF Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_VerificaDescricaoFormasPagamento Lib "Daruma32.dll" (ByVal Descricao As String) As Integer
    Public Declare Function Daruma_FI_VerificaXPendente Lib "Daruma32.dll" (ByVal XPendente As String) As Integer
    Public Declare Function Daruma_FI_VerificaZPendente Lib "Daruma32.dll" (ByVal ZPendente As String) As Integer
    Public Declare Function Daruma_FI_VerificaDiaAberto Lib "Daruma32.dll" (ByVal DiaAberto As String) As Integer
    Public Declare Function Daruma_FI_VerificaHorarioVerao Lib "Daruma32.dll" (ByVal HorarioVerao As String) As Integer
    Public Declare Function Daruma_FI_VerificaFormasPagamento Lib "Daruma32.dll" (ByVal FormasPagto As String) As Integer
    Public Declare Function Daruma_FI_VerificaFormasPagamentoEx Lib "Daruma32.dll" (ByVal FormasPagtoEx As String) As Integer
    Public Declare Function Daruma_FI_VerificaEpromConectada Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_FI_VerificaEstadoImpressora Lib "Daruma32.dll" (ByRef ACK As Integer, ByRef ST1 As Integer, ByRef ST2 As Integer) As Integer

    'Metodos de Informacao do ECF e Contadores
    Public Declare Function Daruma_FI_RetornarVersaoDLL Lib "Daruma32.dll" (ByVal Versao As String) As Integer
    Public Declare Function Daruma_FI_ClicheProprietario Lib "Daruma32.dll" (ByVal Cliche As String) As Integer
    Public Declare Function Daruma_FI_ClicheProprietarioEx Lib "Daruma32.dll" (ByVal ClicheProprietarioEx As String) As Integer
    Public Declare Function Daruma_FI_NumeroCaixa Lib "Daruma32.dll" (ByVal NumeroCaixa As String) As Integer
    Public Declare Function Daruma_FI_NumeroLoja Lib "Daruma32.dll" (ByVal NumeroLoja As String) As Integer
    Public Declare Function Daruma_FI_NumeroSerie Lib "Daruma32.dll" (ByVal NumeroSerie As String) As Integer
    Public Declare Function Daruma_FI_VersaoFirmware Lib "Daruma32.dll" (ByVal VersaoFirmware As String) As Integer
    Public Declare Function Daruma_FI_CGC_IE Lib "Daruma32.dll" (ByVal CGC As String, ByVal IE As String) As Integer
    Public Declare Function Daruma_FI_LerAliquotasComIndice Lib "Daruma32.dll" (ByVal AliquotasComIndice As String) As Integer
    Public Declare Function Daruma_FI_NumeroCupom Lib "Daruma32.dll" (ByVal NumeroCupom As String) As Integer
    Public Declare Function Daruma_FI_COO Lib "Daruma32.dll" (ByVal Coo_Inicial As String, ByVal COO_Final As String) As Integer
    Public Declare Function Daruma_FI_MinutosImprimindo Lib "Daruma32.dll" (ByVal Minutos As String) As Integer
    Public Declare Function Daruma_FI_MinutosLigada Lib "Daruma32.dll" (ByVal Minutos As String) As Integer
    Public Declare Function Daruma_FI_NumeroSubstituicoesProprietario Lib "Daruma32.dll" (ByVal NumeroSubstituicoes As String) As Integer
    Public Declare Function Daruma_FI_NumeroIntervencoes Lib "Daruma32.dll" (ByVal NumeroIntervencoes As String) As Integer
    Public Declare Function Daruma_FI_NumeroReducoes Lib "Daruma32.dll" (ByVal NumeroReducoes As String) As Integer
    Public Declare Function Daruma_FI_NumeroCuponsCancelados Lib "Daruma32.dll" (ByVal NumeroCancelamentos As String) As Integer
    Public Declare Function Daruma_FI_NumeroOperacoesNaoFiscais Lib "Daruma32.dll" (ByVal NumeroOperacoes As String) As Integer
    Public Declare Function Daruma_FI_DataHoraImpressora Lib "Daruma32.dll" (ByVal Data As String, ByVal Hora As String) As Integer
    Public Declare Function Daruma_FI_DataHoraReducao Lib "Daruma32.dll" (ByVal Data As String, ByVal Hora As String) As Integer
    Public Declare Function Daruma_FI_DataMovimento Lib "Daruma32.dll" (ByVal Data As String) As Integer
    Public Declare Function Daruma_FI_ContadoresTotalizadoresNaoFiscais Lib "Daruma32.dll" (ByVal Contadores As String) As Integer

    'Metodos Totalizadores Gerais
    Public Declare Function Daruma_FI_VendaBruta Lib "Daruma32.dll" (ByVal VendaBruta As String) As Integer
    Public Declare Function Daruma_FI_VendaBrutaAcumulada Lib "Daruma32.dll" (ByVal VendaBrutaAcumulada As String) As Integer
    Public Declare Function Daruma_FI_GrandeTotal Lib "Daruma32.dll" (ByVal GrandeTotal As String) As Integer
    Public Declare Function Daruma_FI_Descontos Lib "Daruma32.dll" (ByVal ValorDescontos As String) As Integer
    Public Declare Function Daruma_FI_Acrescimos Lib "Daruma32.dll" (ByVal ValorAcrescimos As String) As Integer
    Public Declare Function Daruma_FI_Cancelamentos Lib "Daruma32.dll" (ByVal ValorCancelamentos As String) As Integer
    Public Declare Function Daruma_FI_DadosUltimaReducao Lib "Daruma32.dll" (ByVal DadosReducao As String) As Integer
    Public Declare Function Daruma_FI_SubTotal Lib "Daruma32.dll" (ByVal SubTotal As String) As Integer
    Public Declare Function Daruma_FI_Troco Lib "Daruma32.dll" (ByVal Troco As String) As Integer
    Public Declare Function Daruma_FI_SaldoAPagar Lib "Daruma32.dll" (ByVal Saldo As String) As Integer
    Public Declare Function Daruma_FI_RetornoAliquotas Lib "Daruma32.dll" (ByVal cAliquotas As String) As Integer
    Public Declare Function Daruma_FI_ValorPagoUltimoCupom Lib "Daruma32.dll" (ByVal ValorCupom As String) As Integer
    Public Declare Function Daruma_FI_ValorFormaPagamento Lib "Daruma32.dll" (ByVal FormaPagamento As String, ByVal ValorForma As String) As Integer
    Public Declare Function Daruma_FI_ValorTotalizadorNaoFiscal Lib "Daruma32.dll" (ByVal Totalizador As String, ByVal ValorTotalizador As String) As Integer
    Public Declare Function Daruma_FI_UltimoItemVendido Lib "Daruma32.dll" (ByVal NumeroItem As String) As Integer
    Public Declare Function Daruma_FI_UltimaFormaPagamento Lib "Daruma32.dll" (ByVal FormaPagamento As String, ByVal ValorForma As String) As Integer
    Public Declare Function Daruma_FI_TipoUltimoDocumento Lib "Daruma32.dll" (ByVal TipoUltimoDoc As String) As Integer

    'Metodos Relatorios Fiscais e Relatorios
    Public Declare Function Daruma_FI_MapaResumo Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_RelatorioTipo60Analitico Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_RelatorioTipo60Mestre Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI_FlagsFiscais Lib "Daruma32.dll" (ByRef Flag As Integer) As Integer
    Public Declare Function Daruma_FI_PalavraStatus Lib "Daruma32.dll" (ByVal PalavraStatus As String) As Integer
    Public Declare Function Daruma_FI_PalavraStatusBinario Lib "Daruma32.dll" (ByVal PalavraStatusBinario As String) As Integer
    Public Declare Function Daruma_FI_SimboloMoeda Lib "Daruma32.dll" (ByVal SimboloMoeda As String) As Integer
    Public Declare Function Daruma_FI_RetornoImpressora Lib "Daruma32.dll" (ByRef ACK As Integer, ByRef ST1 As Integer, ByRef ST2 As Integer) As Integer
    Public Declare Function Daruma_FI_RetornaErroExtendido Lib "Daruma32.dll" (ByVal ErroExtendido As String) As Integer
    Public Declare Function Daruma_FI_RetornaAcrescimoNF Lib "Daruma32.dll" (ByVal AcrescimoNF As String) As Integer
    Public Declare Function Daruma_FI_RetornaCFCancelados Lib "Daruma32.dll" (ByVal CNCancelados As String) As Integer
    Public Declare Function Daruma_FI_RetornaCNFCancelados Lib "Daruma32.dll" (ByVal CNFCancelados As String) As Integer
    Public Declare Function Daruma_FI_RetornaCLX Lib "Daruma32.dll" (ByVal RetornaCLX As String) As Integer
    Public Declare Function Daruma_FI_RetornaCNFNV Lib "Daruma32.dll" (ByVal RetornaCNFNV As String) As Integer
    Public Declare Function Daruma_FI_RetornaCNFV Lib "Daruma32.dll" (ByVal RetornaCNFV As String) As Integer
    Public Declare Function Daruma_FI_RetornaDescricaoCNFV Lib "Daruma32.dll" (ByVal RetornaCNFV As String) As Integer
    Public Declare Function Daruma_FI_RetornaCRO Lib "Daruma32.dll" (ByVal RetornaCRO As String) As Integer
    Public Declare Function Daruma_FI_RetornaCRZ Lib "Daruma32.dll" (ByVal RetornaCRZ As String) As Integer
    Public Declare Function Daruma_FI_RetornaCRZRestante Lib "Daruma32.dll" (ByVal RetornaCRZRestante As String) As Integer
    Public Declare Function Daruma_FI_RetornaCancelamentoNF Lib "Daruma32.dll" (ByVal CancelamentoNF As String) As Integer
    Public Declare Function Daruma_FI_RetornaDescontoNF Lib "Daruma32.dll" (ByVal DescontoNF As String) As Integer
    Public Declare Function Daruma_FI_RetornaGNF Lib "Daruma32.dll" (ByVal RetornaGNF As String) As Integer
    Public Declare Function Daruma_FI_RetornaTempoImprimindo Lib "Daruma32.dll" (ByVal TempoImprimindo As String) As Integer
    Public Declare Function Daruma_FI_RetornaTempoLigado Lib "Daruma32.dll" (ByVal TempoLigado As String) As Integer
    Public Declare Function Daruma_FI_RetornaTotalPagamentos Lib "Daruma32.dll" (ByVal TotalPagamentos As String) As Integer
    Public Declare Function Daruma_FI_RetornaTroco Lib "Daruma32.dll" (ByVal Troco As String) As Integer
    Public Declare Function Daruma_FI_RetornaValorComprovanteNaoFiscal Lib "Daruma32.dll" (ByVal IndiceRegistrCNF As String, ByVal Ref_Valor As String) As Integer
    Public Declare Function Daruma_FI_RetornaIndiceComprovanteNaoFiscal Lib "Daruma32.dll" (ByVal DescricaoRegistrCNF As String, ByVal Ref_Indice As String) As Integer
    Public Declare Function Daruma_FI_RetornaRegistradoresNaoFiscais Lib "Daruma32.dll" (ByVal RegistrNaoFiscais As String) As Integer
    Public Declare Function Daruma_FI_RetornaRegistradoresFiscais Lib "Daruma32.dll" (ByVal RegistradoresFiscais As String) As Integer

    'Metodos TEF
    Public Declare Function Daruma_TEF_EsperarArquivo Lib "Daruma32.dll" (ByVal PathArquivo As String, ByVal Tempo As String, ByVal Travar As String) As Integer
    Public Declare Function Daruma_TEF_ImprimirResposta Lib "Daruma32.dll" (ByVal PathArquivo As String, ByVal Forma As String, ByVal Travar As String) As Integer
    Public Declare Function Daruma_TEF_ImprimirRespostaCartao Lib "Daruma32.dll" (ByVal PathArquivo As String, ByVal Forma As String, ByVal Travar As String, ByVal ValorPagamento As String) As Integer
    Public Declare Function Daruma_TEF_FechaRelatorio Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_TEF_SetFocus Lib "Daruma32.dll" (ByVal TituloJanela As String) As Integer
    Public Declare Function Daruma_TEF_TravarTeclado Lib "Daruma32.dll" (ByVal Travar As String) As Integer

    'Metodos FIB
    Public Declare Function Daruma_FIB_AbreBilhetePassagem Lib "Daruma32.dll" (ByVal Origem As String, ByVal Destino As String, ByVal UF As String, ByVal Percurso As String, ByVal Prestadora As String, ByVal Plataforma As String, ByVal Poltrona As String, ByVal Modalidade As String, ByVal Categoria As String, ByVal DataEmbarque As String, ByVal PassRg As String, ByVal PassNome As String, ByVal PassEndereco As String) As Integer
    Public Declare Function Daruma_FIB_VendeItem Lib "Daruma32.dll" (ByVal Descricao As String, ByVal St As String, ByVal Valor As String, ByVal DescontoAcrescimo As String, ByVal TipoDesconto As String, ByVal ValorDesconto As String) As Integer


#End Region

#Region "  Declaracoes de Metodos da Impressora Não Fiscal (DS300)  "
    'Metodos da Impressora Dual Não Fiscal (DS300/348) 

    '********************************************************************************************************************* '
    '                                                                                                                      '
    '                                                       DUAL                                                           '
    '                                                                                                                      '
    '********************************************************************************************************************* '

    'Metodos para Registry
    Public Declare Function Daruma_Registry_DUAL_Enter Lib "Daruma32.dll" (ByVal Enter As String) As Integer
    Public Declare Function Daruma_Registry_DUAL_Espera Lib "Daruma32.dll" (ByVal Espera As String) As Integer
    Public Declare Function Daruma_Registry_DUAL_ModoEscrita Lib "Daruma32.dll" (ByVal ModoEscrita As String) As Integer
    Public Declare Function Daruma_Registry_DUAL_Porta Lib "Daruma32.dll" (ByVal Porta As String) As Integer
    Public Declare Function Daruma_Registry_DUAL_Tabulacao Lib "Daruma32.dll" (ByVal Tabulacao As String) As Integer
    Public Declare Function Daruma_Registry_DUAL_Termica Lib "Daruma32.dll" (ByVal Flag As String) As Integer
    Public Declare Function Daruma_Registry_DUAL_Velocidade Lib "Daruma32.dll" (ByVal Velocidade As String) As Integer

    'Metodos para Status
    Public Declare Function Daruma_DUAL_VerificaStatus Lib "Daruma32.dll" () As Integer  'Verificar Status
    Public Declare Function Daruma_DUAL_VerificaDocumento Lib "Daruma32.dll" () As Integer 'Verifica Documento
    Public Declare Function Daruma_DUAL_StatusGaveta Lib "Daruma32.dll" () As Integer  'Verificar Status Gaveta

    'Metodos para Autenticacao a Impressao
    Public Declare Function Daruma_DUAL_ImprimirArquivo Lib "Daruma32.dll" (ByVal Str_Path As String) As Integer 'Imprimir arquivo
    Public Declare Function Daruma_DUAL_ImprimirTexto Lib "Daruma32.dll" (ByVal TextoLivre As String, ByVal TamanhoTexto As Integer) As Integer 'Imprimir Texto Livre
    Public Declare Function Daruma_DUAL_Autenticar Lib "Daruma32.dll" (ByVal NumVias As String, ByVal Texto As String, ByVal TempoAguardar As String) As Integer 'Autenticar
    Public Declare Function Daruma_DUAL_AcionaGaveta Lib "Daruma32.dll" () As Integer  'AcionaGaveta
    Public Declare Function Daruma_DUAL_EnviarBMP Lib "Daruma32.dll" (ByVal Path As String) As Integer  'Envia o logotipo
    Public Declare Function Daruma_DUAL_VerificarGuilhotina Lib "Daruma32.dll" () As Integer  'Devolve no inteiro retornado se a Guilhotina esta Habilitada
    Public Declare Function Daruma_DUAL_ConfigurarGuilhotina Lib "Daruma32.dll" (ByVal Int_Flag As Integer, ByVal Int_LinhasAcionamento As Integer) As Integer  'Configura a Guilhotina na DUAL nao Fiscal

#End Region

#Region "  Declaracoes de Metodos de Acesso ao TA1000  "

    '********************************************************************************************************************* '
    '                                                                                                                      '
    '                                                     TA1000                                                           '
    '                                                                                                                      '
    '********************************************************************************************************************* '

    'Metodos para Registry
    Public Declare Function Daruma_Registry_TA1000_Porta Lib "Daruma32.dll" (ByVal Porta As String) As Integer
    Public Declare Function Daruma_Registry_TA1000_PathProdutos Lib "Daruma32.dll" (ByVal PathProdutos As String) As Integer
    Public Declare Function Daruma_Registry_TA1000_PathUsuarios Lib "Daruma32.dll" (ByVal PathUsuarios As String) As Integer
    Public Declare Function Daruma_Registry_TA1000_NumeroItensEnviados Lib "Daruma32.dll" (ByVal NumeroItensEnviados As String) As Integer
    Public Declare Function Daruma_Registry_TA1000_PathRelatorios Lib "Daruma32.dll" (ByVal PathRelatorios As String) As Integer

    Public Declare Function Daruma_TA1000_CadastrarProdutos Lib "Daruma32.dll" (ByVal Descricao As String, ByVal Codigo As String, ByVal DecimaisPreco As String, ByVal DecimaisQuantidade As String, ByVal Preco As String, ByVal DescontoAcrescimo As String, ByVal ValorDescontoAcrescimo As String, ByVal UnidadeMedida As String, ByVal Aliquota As String, ByVal ProximoProduto As String, ByVal ProdutoAnterior As String, ByVal Estoque As String) As Integer
    Public Declare Function Daruma_TA1000_LerProdutos Lib "Daruma32.dll" (ByVal Indice As Integer, ByVal Descricao As String, ByVal Codigo As String, ByVal DecimaisPreco As String, ByVal DecimaisQuantidade As String, ByVal Preco As String, ByVal DescontoAcrescimo As String, ByVal ValorDescontoAcrescimo As String, ByVal UnidadeMedida As String, ByVal Aliquota As String, ByVal ProximoProduto As String, ByVal ProdutoAnterior As String, ByVal Estoque As String) As Integer
    Public Declare Function Daruma_TA1000_ConsultarProdutos Lib "Daruma32.dll" (ByVal Descricao As String, ByVal Codigo As String, ByVal DecimaisPreco As String, ByVal DecimaisQuantidade As String, ByVal Preco As String, ByVal DescontoAcrescimo As String, ByVal ValorDescontoAcrescimo As String, ByVal UnidadeMedida As String, ByVal Aliquota As String, ByVal ProximoProduto As String, ByVal ProdutoAnterior As String, ByVal Estoque As String) As Integer
    Public Declare Function Daruma_TA1000_AlterarProdutos Lib "Daruma32.dll" (ByVal Codigo_Consultar As String, ByVal Descricao As String, ByVal Codigo As String, ByVal DecimaisPreco As String, ByVal DecimaisQuantidade As String, ByVal Preco As String, ByVal DescontoAcrescimo As String, ByVal ValorDescontoAcrescimo As String, ByVal UnidadeMedida As String, ByVal Aliquota As String, ByVal ProximoProduto As String, ByVal ProdutoAnterior As String, ByVal Estoque As String) As Integer
    Public Declare Function Daruma_TA1000_EliminarProdutos Lib "Daruma32.dll" (ByVal Codigo As String) As Integer
    Public Declare Function Daruma_TA1000_EnviarBancoProdutos Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_TA1000_ReceberBancoProdutos Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_TA1000_ReceberProdutosVendidos Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_TA1000_ZerarProdutos Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_TA1000_ZerarProdutosVendidos Lib "Daruma32.dll" () As Integer

    Public Declare Function Daruma_TA1000_EnviarBancoUsuarios Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_TA1000_ReceberBancoUsuarios Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_TA1000_ZerarUsuarios Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_TA1000_CadastrarUsuarios Lib "Daruma32.dll" (ByVal Nome As String, ByVal CPF As String, ByVal CodigoConvenio As String, ByVal CodigoUsuario As String, ByVal UsuarioAnterior As String, ByVal ProximoUsuario As String) As Integer
    Public Declare Function Daruma_TA1000_ConsultarUsuarios Lib "Daruma32.dll" (ByVal Codigo_Consultar As String, ByVal Nome As String, ByVal CPF As String, ByVal CodigoConvenio As String, ByVal CodigoUsuario As String, ByVal UsuarioAnterior As String, ByVal ProximoUsuario As String) As Integer
    Public Declare Function Daruma_TA1000_AlterarUsuarios Lib "Daruma32.dll" (ByVal Codigo_Consultar As String, ByVal Nome As String, ByVal CPF As String, ByVal CodigoConvenio As String, ByVal CodigoUsuario As String, ByVal UsuarioAnterior As String, ByVal ProximoUsuario As String) As Integer
    Public Declare Function Daruma_TA1000_EliminarUsuarios Lib "Daruma32.dll" (ByVal Codigo As String) As Integer
    Public Declare Function Daruma_TA1000_LeStatusTransferencia Lib "Daruma32.dll" () As Integer

#End Region

#Region " Declaracoes de Metodos de Acesso FS2000  "
    'Metodos da Impressora FS2000 

    '**********************************************************************************************************************'
    '                                                                                                                      '
    '                                                       FS2000                                                         '
    '                                                                                                                      '
    '**********************************************************************************************************************'

    'Metodos exclusivos
    Public Declare Function Daruma_Registry_FS2000_CupomAdicional Lib "Daruma32.dll" (ByVal CupomAdicional As String) As Integer
    Public Declare Function Daruma_Registry_FS2000_TempoEsperaCheque Lib "Daruma32.dll" (ByVal TempodeEspera As String) As Integer
    Public Declare Function Daruma_FI2000_DescontoSobreItemVendido Lib "Daruma32.dll" (ByVal NumeroItem As String, ByVal TipoDesconto As String, ByVal ValorDesconto As String) As Integer
    Public Declare Function Daruma_FI2000_AcrescimosICMSISS Lib "Daruma32.dll" (ByVal AcrescICMS As String, ByVal AcrescISS As String) As Integer
    Public Declare Function Daruma_FI2000_CancelamentosICMSISS Lib "Daruma32.dll" (ByVal CancelICMS As String, ByVal CancelISS As String) As Integer
    Public Declare Function Daruma_FI2000_DescontosICMSISS Lib "Daruma32.dll" (ByVal DescICMS As String, ByVal DescISS As String) As Integer
    Public Declare Function Daruma_FI2000_LeituraInformacaoUltimosCNF Lib "Daruma32.dll" (ByVal UltimosCNF As String) As Integer
    Public Declare Function Daruma_FI2000_LeituraInformacaoUltimoDoc Lib "Daruma32.dll" (ByVal TipoUltimoDoc As String, ByVal ValorUltimoDoc As String) As Integer
    Public Declare Function Daruma_FI2000_VerificaRelatorioGerencial Lib "Daruma32.dll" (ByVal Gerencial As String) As Integer
    Public Declare Function Daruma_FI2000_CriaRelatorioGerencial Lib "Daruma32.dll" (ByVal NomeGerencial As String) As Integer
    Public Declare Function Daruma_FI2000_AbreRelatorioGerencial Lib "Daruma32.dll" (ByVal Indice As String) As Integer
    Public Declare Function Daruma_FI2000_CancelamentoCNFV Lib "Daruma32.dll" (ByVal COO_CNFV As String) As Integer
    Public Declare Function Daruma_FI2000_SegundaViaCNFVinculado Lib "Daruma32.dll" () As Integer

    'Metodos para cheques
    Public Declare Function Daruma_FI2000_StatusCheque Lib "Daruma32.dll" (ByVal StatusCheque As String) As Integer
    Public Declare Function Daruma_FI2000_ImprimirCheque Lib "Daruma32.dll" (ByVal Banco As String, ByVal Cidade As String, ByVal Data As String, ByVal Favorecido As String, ByVal Valor As String, ByVal PosicaoCheque As String) As Integer
    Public Declare Function Daruma_FI2000_ImprimirVersoCheque Lib "Daruma32.dll" (ByVal VersoCheque As String) As Integer
    Public Declare Function Daruma_FI2000_LiberarCheque Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI2000_LeituraCodigoMICR Lib "Daruma32.dll" (ByVal CodigoMICR As String) As Integer
    Public Declare Function Daruma_FI2000_CancelarCheque Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI2000_LeituraTabelaCheque Lib "Daruma32.dll" (ByVal TabelaCheque As String) As Integer
    Public Declare Function Daruma_FI2000_CarregarCheque Lib "Daruma32.dll" () As Integer
    Public Declare Function Daruma_FI2000_CorrigirGeometriaCheque Lib "Daruma32.dll" (ByVal NumeroBanco As String, ByVal GeometriaCheque As String) As Integer
#End Region

#Region " Funções que tratam os Retornos da Impressora  "
    'Retornos da FISCAL
    Public Sub Daruma_MostrarRetorno()
        Dim Int_RetornoMetodo As Integer
        Dim Int_RetornoExtendido As Integer
        Dim Str_ErroExtendido As String

        Int_Ack = 0
        Int_St1 = 0
        Int_St2 = 0
        Int_RetornoMetodo = Daruma_FI_RetornoImpressora(Int_Ack, Int_St1, Int_St2)

        Str_ErroExtendido = Space(4)
        Int_RetornoExtendido = Daruma_FI_RetornaErroExtendido(Str_ErroExtendido)

        MsgBox("Retorno do Metodo = " + CStr(Int_Retorno) + Chr(13) + Chr(10) _
               + "Ack = " + CStr(Int_Ack) + Chr(13) + Chr(10) _
               + "St1 = " + CStr(Int_St1) + Chr(13) + Chr(10) _
               + "St2 = " + CStr(Int_St2) + Chr(13) + Chr(10) _
               + "Erro Extendido = " + Str_ErroExtendido.ToString, , "Daruma Framework Retorno do Metodo")

    End Sub
    'Retornos da DUAL  
    Public Sub Retorno_DUAL()

        If Int_Retorno = 1 Then
            MsgBox("1(um) - Impressora OK!", vbInformation, "Daruma Framework")
        End If

        If Int_Retorno = -50 Then
            MsgBox("-50 - Impressora OFF-LINE!", vbCritical, "Daruma Framework")
        End If

        If Int_Retorno = -51 Then
            MsgBox("-51 - Impressora Sem Papel!", vbCritical, "Daruma Framework")
        End If

        If Int_Retorno = -27 Then
            MsgBox("-27 - Erro Generico!", vbCritical, "Daruma Framework")
        End If

        If Int_Retorno = 0 Then
            MsgBox("0 - Impressora Desligada!", vbCritical, "Daruma Framework")
        End If

    End Sub

    'Retornos do TA1000
    Public Sub Retorno_TA1000()

        If Int_Retorno = 1 Then
            MsgBox("1(um) - Metodo Executado com Sucesso!", vbInformation, "Daruma Framework")
        Else
            MsgBox(CStr(Int_Retorno) + "   Erro Generico!", vbCritical, "Daruma Framework")
        End If
    End Sub

#End Region

#Region " * *  Funções da Balanca Toledo  * * "

    Public Declare Function PegaPeso Lib "P05.DLL" (ByVal OpcaoEscrita As Long, ByVal Peso As String, ByVal Diretorio As String) As Long

    Public Declare Function AbrePorta Lib "P05.DLL" (ByVal Porta As Long, ByVal BaudRate As Long, ByVal DataBits As Long, ByVal Paridade As Long) As Long

    Public Declare Function FechaPorta Lib "P05.DLL" () As Long

#End Region

End Module


