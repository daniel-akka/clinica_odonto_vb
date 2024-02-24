
Public Class NotaFiscalEntrada

    'Todas as informações contidas nesta classe é baseada no Layout do SpedFiscal e AC_FORTES INFORMATICA

    ' Atributos
    Private numero_ As String
    Private indicadorOperacao_ As Integer '0-Entrada; 1-Saida
    Private serie_ As String
    Private indicadorEmissao_ As Integer '0-Emissao Propria; 1-Terceiros
    Private especieNF_ As String ' Valores válidos Abaixo:
    'ACT    Autorização de Carregamento de Transportes
    'BPA    Bilhete de Passagem Aquaviário
    'BPF    Bilhete de Passagem Ferroviário
    'BPNB   Bilhete de Passagem e Nota de Bagagem
    'BPR    Bilhete de Passagem Rodoviário
    'CA     Conhecimento Aéreo
    'CF     Cupom Fiscal
    'CTA    Conhecimento de Transporte Avulso
    'CTAC   Conhecimento de Transporte Aquaviário de Cargas
    'CTFC   Conhecimento de Transporte Ferroviário de Cargas
    'CTRC   Conhecimento de Transporte Rodoviário de Cargas
    'CTE    Conhecimento de Transporte Eletrônico
    'DT     Despacho de Transporte
    'MC     Manifesto de Cargas
    'MRE    Mapa Resumo ECF
    'NF1    Nota Fiscal - Modelo 1
    'NF1A   Nota Fiscal - Modelo 1A
    'NFA    Nota Fiscal Avulsa
    'NFE    Nota Fiscal Eletrônica
    'NFCEE  Nota Fiscal - Conta de Energia Elétrica
    'NFP    Nota Fiscal de Produtor
    'NFF    Nota Fiscal Fatura
    'NFSC   Nota Fiscal de Serviço de Comunicação
    'NFST   Nota Fiscal de Serviço de Transporte
    'NFSTC  Nota Fiscal de Serviço de Telecomunicação
    'NFVC   Nota Fiscal de Venda a Consumidor
    'OCC    Ordem de Coleta de Cargas
    'RMD    Resumo de Movimento Diário
    Private codigoModelo_ As String 'Valores válidos Abaixo:
    '01 Nota Fiscal
    '1B Nota Fiscal Avulsa
    '02 Nota Fiscal de Venda a Consumidor
    '2D Cupom Fiscal
    '2E Cupom Fiscal Bilhete de Passagem
    '04 Nota Fiscal de Produtor
    '06 Nota Fiscal/Conta de Energia Elétrica
    '07 Nota Fiscal de Serviço de Transporte
    '08 Conhecimento de Transporte Rodoviário de Cargas
    '8B Conhecimento de Transporte de Cargas Avulso
    '09 Conhecimento de Transporte Aquaviário de Cargas
    '10 Conhecimento Aéreo
    '11 Conhecimento de Transporte Ferroviário de Cargas
    '13 Bilhete de Passagem Rodoviário
    '14 Bilhete de Passagem Aquaviário
    '15 Bilhete de Passagem e Nota de Bagagem
    '17 Despacho de Transporte
    '16 Bilhete de Passagem Ferroviário
    '18 Resumo de Movimento Diário
    '20 Ordem de Coleta de Cargas
    '21 Nota Fiscal de Serviço de Comunicação
    '22 Nota Fiscal de Serviço de Telecomunicação
    '23 GNRE
    '24 Autorização de Carregamento e Transporte
    '25 Manifesto de Carga
    '26 Conhecimento de Transporte Multimodal de Cargas
    '27 Nota Fiscal De Transporte Ferroviário De Carga
    '28 Nota Fiscal/Conta de Fornecimento de Gás Canalizado
    '29 Nota Fiscal/Conta De Fornecimento D'água Canalizada
    '55 Nota Fiscal Eletrônica
    Private codigoSituacao_ As String ' Valores válidos Abaixo:
    '00 	Documento regular
    '01 	Documento regular extemporâneo
    '02 	Documento cancelado
    '03 	Documento cancelado extemporâneo
    '04 	NFe denegada
    '05 	NFe - Numeração inutilizada
    '06 	Documento Fiscal Complementar
    '07 	Documento Fiscal Complementar extemporâneo.
    '08 	Documento Fiscal emitido com base em Regime Especial ou Norma Específica

    ' Os valores "04" e "05" do CodigoSituacao só são possíveis para NF-e de emissão própria.
    Private tipoPagamento_ As Integer ' 0-À vista; 1-A prazo;9-Sem Pagamento
    Private vlrTotalProdutos_ As Double
    Private vlrTotalServicos_ As Double
    Private vlrTotalFrete_ As Double
    Private vlrTotalSeguro_ As Double
    Private vlrTotalDesconto_ As Double
    Private vlrTotalIPI_ As Double
    Private vlrTotalBCalcIcms_ As Double
    Private vlrTotalIcms_ As Double
    Private vlrTotalBCalcIcmsST_ As Double
    Private vlrTotalIcmsST_ As Double
    Private vlrOutrasDespesas_ As Double
    Private vlrTotalPIS_ As Double
    Private vlrTotalCOFINS_ As Double
    Private vlrTotalPisST_ As Double
    Private vlrTotalCofinsST_ As Double
    Private vlrTotalNF_ As Double
    Private DataEmissao_ As Date
    Private DataEntradaSaida_ As Date
    Private chaveEletronica_ As String
    Private tipoFrete_ As Integer '0- Por conta do emitente; 1- Por conta do destinatário/remetente; 2- Por conta de terceiros; 9- Sem cobrança de frete 
    Private codigoFornecedor_ As String
    Private CfopNf_ As String


#Region "Altera os Atributos da Classe..."

    'Aqui Altera todos os valores
    Public Sub setValues(ByVal numero As String, ByVal indicadorOperacao As Integer, ByVal serie As String, ByVal indicadorEmissao As Integer, _
            ByVal especieNF As Integer, ByVal codigoModelo As String, ByVal codigoSituacao As String, ByVal tipoPagamento As Integer, _
            ByVal vlrTotalProdutos As Double, ByVal vlrTotalServicos As Double, ByVal vlrTotalFrete As Double, ByVal vlrTotalSeguro As Double, _
            ByVal vlrTotalDesconto As Double, ByVal vlrTotalIPI As Double, ByVal vlrTotalBCalcIcms As Double, ByVal vlrTotalIcms As Double, _
            ByVal vlrTotalBCalcIcmsST As Double, ByVal vlrTotalIcmsST As Double, ByVal vlrOutrasDespesas As Double, ByVal vlrTotalPIS As Double, _
            ByVal vlrTotalCOFINS As Double, ByVal vlrTotalPisST As Double, ByVal vlrTotalCofinsST As Double, ByVal vlrTotalNF As Double, _
            ByVal DataEntradaSaida As Date, ByVal DataEmissao As Date, ByVal chaveEletronica As String, ByVal tipoFrete As Integer, _
            ByVal cfop As String)

        Me.numero_ = numero
        Me.indicadorOperacao_ = indicadorOperacao
        Me.serie_ = serie
        Me.indicadorEmissao_ = indicadorEmissao
        Me.especieNF_ = especieNF
        Me.codigoModelo_ = codigoModelo
        Me.codigoSituacao_ = codigoSituacao
        Me.tipoPagamento_ = tipoPagamento
        Me.vlrTotalProdutos_ = vlrTotalProdutos
        Me.vlrTotalServicos_ = vlrTotalServicos
        Me.vlrTotalFrete_ = vlrTotalFrete
        Me.vlrTotalSeguro_ = vlrTotalSeguro
        Me.vlrTotalDesconto_ = vlrTotalDesconto
        Me.vlrTotalIPI_ = vlrTotalIPI
        Me.vlrTotalBCalcIcms_ = vlrTotalBCalcIcms
        Me.vlrTotalIcms_ = vlrTotalIcms
        Me.vlrTotalBCalcIcmsST_ = vlrTotalBCalcIcmsST
        Me.vlrTotalIcmsST_ = vlrTotalIcmsST
        Me.vlrOutrasDespesas_ = vlrOutrasDespesas
        Me.vlrTotalPIS_ = vlrTotalPIS
        Me.vlrTotalCOFINS_ = vlrTotalCOFINS
        Me.vlrTotalPisST_ = vlrTotalPisST
        Me.vlrTotalCofinsST_ = vlrTotalCofinsST
        Me.vlrTotalNF_ = vlrTotalNF
        Me.DataEntradaSaida_ = DataEntradaSaida
        Me.DataEmissao_ = DataEmissao
        Me.chaveEletronica_ = chaveEletronica
        Me.tipoFrete_ = tipoFrete
        Me.CfopNf_ = cfop

    End Sub

    Public Sub setnumero_(ByVal numero As String)
        Me.numero_ = numero
    End Sub

    Public Sub setindicadorOperacao_(ByVal indicadorOperacao As Integer)
        Me.indicadorOperacao_ = indicadorOperacao
    End Sub

    Public Sub setserie_(ByVal serie As String)
        Me.serie_ = serie
    End Sub

    Public Sub setindicadorEmissao_(ByVal indicadorEmissao As Integer)
        Me.indicadorEmissao_ = indicadorEmissao
    End Sub

    Public Sub setespecieNF_(ByVal especieNF As String)
        Me.especieNF_ = especieNF
    End Sub

    Public Sub setcodigoModelo_(ByVal codigoModelo As String)
        Me.codigoModelo_ = codigoModelo
    End Sub

    Public Sub setcodigoSituacao_(ByVal codigoSituacao As String)
        Me.codigoSituacao_ = codigoSituacao
    End Sub

    Public Sub settipoPagamento_(ByVal tipoPagamento As Integer)
        Me.tipoPagamento_ = tipoPagamento
    End Sub

    Public Sub setvlrTotalProdutos_(ByVal vlrTotalProdutos As Double)
        Me.vlrTotalProdutos_ = vlrTotalProdutos
    End Sub

    Public Sub setvlrTotalServicos_(ByVal vlrTotalServicos As Double)
        Me.vlrTotalServicos_ = vlrTotalServicos
    End Sub

    Public Sub setvlrTotalFrete_(ByVal vlrTotalFrete As Double)
        Me.vlrTotalFrete_ = vlrTotalFrete
    End Sub

    Public Sub setvlrTotalSeguro_(ByVal vlrTotalSeguro As Double)
        Me.vlrTotalSeguro_ = vlrTotalSeguro
    End Sub

    Public Sub setvlrTotalDesconto_(ByVal vlrTotalDesconto As Double)
        Me.vlrTotalDesconto_ = vlrTotalDesconto
    End Sub

    Public Sub setvlrTotalIPI_(ByVal vlrTotalIPI As Double)
        Me.vlrTotalIPI_ = vlrTotalIPI
    End Sub

    Public Sub setvlrTotalBCalcIcms_(ByVal vlrTotalBCalcIcms As Double)
        Me.vlrTotalBCalcIcms_ = vlrTotalBCalcIcms
    End Sub

    Public Sub setvlrTotalIcms_(ByVal vlrTotalIcms As Double)
        Me.vlrTotalIcms_ = vlrTotalIcms
    End Sub

    Public Sub setvlrTotalBCalcIcmsST_(ByVal vlrTotalBCalcIcmsST As Double)
        Me.vlrTotalBCalcIcmsST_ = vlrTotalBCalcIcmsST
    End Sub

    Public Sub setvlrTotalIcmsST_(ByVal vlrTotalIcmsST As Double)
        Me.vlrTotalIcmsST_ = vlrTotalIcmsST
    End Sub

    Public Sub setvlrOutrasDespesas_(ByVal vlrOutrasDespesas As Double)
        Me.vlrOutrasDespesas_ = vlrOutrasDespesas
    End Sub

    Public Sub setvlrTotalPIS_(ByVal vlrTotalPIS As Double)
        Me.vlrTotalPIS_ = vlrTotalPIS
    End Sub

    Public Sub setvlrTotalCOFINS_(ByVal vlrTotalCOFINS As Double)
        Me.vlrTotalCOFINS_ = vlrTotalCOFINS
    End Sub

    Public Sub setvlrTotalPisST_(ByVal vlrTotalPisST As Double)
        Me.vlrTotalPisST_ = vlrTotalPisST
    End Sub

    Public Sub setvlrTotalCofinsST_(ByVal vlrTotalCofinsST As Double)
        Me.vlrTotalCofinsST_ = vlrTotalCofinsST
    End Sub

    Public Sub setvlrTotalNF_(ByVal vlrTotalNF As Double)
        Me.vlrTotalNF_ = vlrTotalNF
    End Sub

    Public Sub setDataEntradaSaida_(ByVal DataEntradaSaida As Date)
        Me.DataEntradaSaida_ = DataEntradaSaida
    End Sub

    Public Sub setDataEmissao_(ByVal DataEmissao As Date)
        Me.DataEmissao_ = DataEmissao
    End Sub

    Public Sub setchaveEletronica_(ByVal chaveEletronica As String)
        Me.chaveEletronica_ = chaveEletronica
    End Sub

    Public Sub settipoFrete_(ByVal tipoFrete As Integer)
        Me.tipoFrete_ = tipoFrete
    End Sub

    Public Sub setCfopNf_(ByVal Cfop As String)
        Me.CfopNf_ = Cfop
    End Sub

#End Region

#Region "Obtem os Atributos da Classe..."

    Public Function getnumero_() As String
        Return Me.numero_
    End Function

    Public Function getindicadorOperacao_() As Integer
        Return Me.indicadorOperacao_
    End Function

    Public Function getserie_() As String
        Return Me.serie_
    End Function

    Public Function getindicadorEmissao_() As Integer
        Return Me.indicadorEmissao_
    End Function

    Public Function getespecieNF_() As String
        Return Me.especieNF_
    End Function

    Public Function getcodigoModelo_() As String
        Return Me.codigoModelo_
    End Function

    Public Function getcodigoSituacao_() As String
        Return Me.codigoSituacao_
    End Function

    Public Function gettipoPagamento_() As Integer
        Return Me.tipoPagamento_
    End Function

    Public Function getvlrTotalProdutos_() As Double
        Return Me.vlrTotalProdutos_
    End Function

    Public Function getvlrTotalServicos_() As Double
        Return Me.vlrTotalServicos_
    End Function

    Public Function getvlrTotalFrete_() As Double
        Return Me.vlrTotalFrete_
    End Function

    Public Function getvlrTotalSeguro_() As Double
        Return Me.vlrTotalSeguro_
    End Function

    Public Function getvlrTotalDesconto_() As Double
        Return Me.vlrTotalDesconto_
    End Function

    Public Function getvlrTotalIPI_() As Double
        Return Me.vlrTotalIPI_
    End Function

    Public Function getvlrTotalBCalcIcms_() As Double
        Return Me.vlrTotalBCalcIcms_
    End Function

    Public Function getvlrTotalIcms_() As Double
        Return Me.vlrTotalIcms_
    End Function

    Public Function getvlrTotalBCalcIcmsST_() As Double
        Return Me.vlrTotalBCalcIcmsST_
    End Function

    Public Function getvlrTotalIcmsST_() As Double
        Return Me.vlrTotalIcmsST_
    End Function

    Public Function getvlrOutrasDespesas_() As Double
        Return Me.vlrOutrasDespesas_
    End Function

    Public Function getvlrTotalPIS_() As Double
        Return Me.vlrTotalPIS_
    End Function

    Public Function getvlrTotalCOFINS_() As Double
        Return Me.vlrTotalCOFINS_
    End Function

    Public Function getvlrTotalPisST_() As Double
        Return Me.vlrTotalPisST_
    End Function

    Public Function getvlrTotalCofinsST_() As Double
        Return Me.vlrTotalCofinsST_
    End Function

    Public Function getvlrTotalNF_() As Double
        Return Me.vlrTotalNF_
    End Function

    Public Function getDataEntradaSaida_() As Date
        Return Me.DataEntradaSaida_
    End Function

    Public Function getDataEmissao_() As Date
        Return Me.DataEmissao_
    End Function

    Public Function getchaveEletronica_() As String
        Return Me.chaveEletronica_
    End Function

    Public Function gettipoFrete_() As Integer
        Return Me.tipoFrete_
    End Function

    Public Function getCfopNf_() As String
        Return Me.CfopNf_
    End Function

#End Region

End Class


