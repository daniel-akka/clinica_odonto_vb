Imports Npgsql
Public Class ItemNFeEntrada

    Private codigo_ As String
    Private numeroNFe_ As String
    Private codigoParticipante_ As String
    Private sequencia_ As Integer
    Private descricao_ As String
    Private cfop_ As String
    Private cfopTransferencia_ As String
    Private csta_ As String 'Codigo da Situacao Tributaria "Tabela A", valores abaixo:
    '0 Nacional
    '1 Estrangeira (Importação Direta)
    '2 Estrangeira (Adquirida no Mercado Interno)
    Private cstb_ As String 'Codigo da Situacao Tributaria "Tabela B", valores abaixo:
    '00 Tributada Integralmente
    '10 Tributada e com Cobrança de ICMS Substituição Tributária
    '20 Tributada com Redução de Base de Cálculo
    '30 Isenta ou Não Tributada e com Cobrança de ICMS Substituição Tributária
    '40 Isenta
    '41 Não Tributada
    '50 Suspensão
    '51 Diferimento
    '60 ICMS Cobrado Anteriormente por Substituição Tributária
    '70 Com Redução de Base de Cálculo e Cobrança do ICMS por Substituição Tributária
    '90 Outras
    Private quantidade_ As Double
    Private unidadeMedida_ As String
    Private valorBruto_ As Double
    Private valorIPI_ As Double
    Private aliquotaIPI_ As Double
    Private baseCalcIPI_ As Double
    Private cstIPI_ As String 'valores validos:
    '00 Entrada com recuperação de crédito
    '01 Entrada tributada com alíquota zero
    '02 Entradas Isentas
    '03 Entrada Não-Incidência
    '04 Entrada Imune
    '05 Entrada com Suspensão
    '49 Outras Entradas
    '50 Saídas Tributadas
    '51 Saídas Tributadas com Alíquota Zero
    '52 Saídas Isentas
    '53 Saídas Não-Tributadas
    '54 Saídas Imunes
    '55 Saídas com Suspensão
    '99 Outras Saídas
    Private valorFrete_ As Double
    Private valorSeguro_ As Double
    Private valorDesconto_ As Double
    Private tipoTributacao_ As Integer ' Valores validos:
    '1 Com Débito/Crédito
    '2 Isentas/Não-Tributadas
    '3 Outras
    Private baseCalcIcms_ As Double
    Private aliquotaIcms_ As Double
    Private valorIcms_ As Double
    Private baseCalcIcmsST_ As Double
    Private valorIcmsST_ As Double
    Private cstPIS_ As String
    Private cstCOFINS_ As String 'valores validos abaixo:
    '01 Operação Tributável - Base de Cálculo = Valor da Operação Alíquota Normal (Cumula
    '02 Operação Tributável - Base de Calculo = Valor da Operação (Alíquota Diferenciada)
    '03 Operação Tributável - Base de Calculo = Quantidade Vendida x Alíquota por Unidade 
    '04 Operação Tributável - Tributação Monofásica - (Alíquota Zero)
    '05 Operação Tributável - (Substituição Tributária)
    '06 Operação Tributável -  Alíquota Zero
    '07 Operação Isenta da Contribuição
    '08 Operação Sem Incidência da Contribuição
    '09 Operação com Suspensão da Contribuição
    '49 Outras Operações de Saída
    '50 Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Me
    '51 Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não Tributada n
    '52 Operação com Direito a Crédito - Vinculada Exclusivamente a Receita de Exportação
    '53 Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não Tributadas no
    '54 Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno
    '55 Operação com Direito a Crédito - Vinculada a Receitas Não-Tributadas no Mercado Int
    '56 Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não Tributadas no
    '60 Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tribu
    '61 Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-
    '62 Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Ex
    '63 Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tri
    '64 Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Merca
    '65 Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no M
    '66 Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tri
    '67 Crédito Presumido - Outras Operações
    '70 Operação de Aquisição sem Direito a Crédito
    '71 Operação de Aquisição com Isenção
    '72 Operação de Aquisição com Suspensão
    '73 Operação de Aquisição a Alíquota Zero
    '74 Operação de Aquisição sem Incidência da Contribuição
    '75 Operação de Aquisição por Substituição Tributária
    '98 Outras Operações de Entrada
    '99 Outras Operações
    Private baseCalcPIS_ As Double
    Private baseCalcCOFINS_ As Double
    Private valorTotal_ As Double


#Region "Altera os Atributos dessa Classe..."

    'Aqui altera todos os atributos
    Public Sub setValues(ByVal codigo As String, ByVal numeroNFe As String, ByVal codigoParticipante As String, ByVal sequencia As Integer, _
        ByVal descricao As String, ByVal cfop As String, ByVal cfopTransferencia As String, ByVal csta As String, ByVal cstb As String, _
        ByVal quantidade As Double, ByVal unidadeMedida As String, ByVal valorBruto As Double, ByVal valorIPI As Double, ByVal aliquotaIPI As Double, _
        ByVal baseCalcIPI As Double, ByVal cstIPI As String, ByVal valorFrete As Double, ByVal valorSeguro As Double, ByVal valorDesconto As Double, _
        ByVal tipoTributacao As Integer, ByVal baseCalcIcms As Double, ByVal aliquotaIcms As Double, ByVal valorIcms As Double, ByVal baseCalcIcmsST As Double, _
        ByVal valorIcmsST As Double, ByVal cstPIS As String, ByVal cstCOFINS As String, ByVal baseCalcPIS As Double, ByVal baseCalcCOFINS As Double, _
        ByVal valorTotal As Double)

        Me.codigo_ = codigo
        Me.numeroNFe_ = numeroNFe
        Me.codigoParticipante_ = codigoParticipante
        Me.sequencia_ = sequencia
        Me.descricao_ = descricao
        Me.cfop_ = cfop
        Me.cfopTransferencia_ = cfopTransferencia
        Me.csta_ = csta
        Me.cstb_ = cstb
        Me.quantidade_ = quantidade
        Me.unidadeMedida_ = unidadeMedida
        Me.valorBruto_ = valorBruto
        Me.valorIPI_ = valorIPI
        Me.aliquotaIPI_ = aliquotaIPI
        Me.baseCalcIPI_ = baseCalcIPI
        Me.cstIPI_ = cstIPI
        Me.valorFrete_ = valorFrete
        Me.valorSeguro_ = valorSeguro
        Me.valorDesconto_ = valorDesconto
        Me.tipoTributacao_ = tipoTributacao
        Me.baseCalcIcms_ = baseCalcIcms
        Me.aliquotaIcms_ = aliquotaIcms
        Me.valorIcms_ = valorIcms
        Me.baseCalcIcmsST_ = baseCalcIcmsST
        Me.valorIcmsST_ = valorIcmsST
        Me.cstPIS_ = cstPIS
        Me.cstCOFINS_ = cstCOFINS
        Me.baseCalcPIS_ = baseCalcPIS
        Me.baseCalcCOFINS_ = baseCalcCOFINS
        Me.valorTotal_ = valorTotal

    End Sub

    Public Sub getcodigo_(ByVal codigo As String)
        Me.codigo_ = codigo
    End Sub

    Public Sub setnumeroNFe_(ByVal numeroNFe As String)
        Me.numeroNFe_ = numeroNFe
    End Sub

    Public Sub setcodigoParticipante_(ByVal codigoParticipante As String)
        Me.codigoParticipante_ = codigoParticipante
    End Sub

    Public Sub setsequencia_(ByVal sequencia As Integer)
        Me.sequencia_ = sequencia
    End Sub

    Public Sub setdescricao_(ByVal descricao As String)
        Me.descricao_ = descricao
    End Sub

    Public Sub setcfop_(ByVal cfop As String)
        Me.cfop_ = cfop
    End Sub

    Public Sub setcfopTransferencia_(ByVal cfopTransferencia As String)
        Me.cfopTransferencia_ = cfopTransferencia
    End Sub

    Public Sub setcsta_(ByVal csta As String)
        Me.csta_ = csta
    End Sub

    Public Sub setcstb_(ByVal cstb As String)
        Me.cstb_ = cstb
    End Sub

    Public Sub setquantidade_(ByVal quantidade As Double)
        Me.quantidade_ = quantidade
    End Sub

    Public Sub setunidadeMedida_(ByVal unidadeMedida As String)
        Me.unidadeMedida_ = unidadeMedida
    End Sub

    Public Sub setvalorBruto_(ByVal valorBruto As Double)
        Me.valorBruto_ = valorBruto
    End Sub

    Public Sub setvalorIPI_(ByVal valorIPI As Double)
        Me.valorIPI_ = valorIPI
    End Sub

    Public Sub setaliquotaIPI_(ByVal aliquotaIPI As Double)
        Me.aliquotaIPI_ = aliquotaIPI
    End Sub

    Public Sub setbaseCalcIPI_(ByVal baseCalcIPI As Double)
        Me.baseCalcIPI_ = baseCalcIPI
    End Sub

    Public Sub setcstIPI_(ByVal cstIPI As String)
        Me.cstIPI_ = cstIPI
    End Sub

    Public Sub setvalorFrete_(ByVal valorFrete As Double)
        Me.valorFrete_ = valorFrete
    End Sub

    Public Sub setvalorSeguro_(ByVal valorSeguro As Double)
        Me.valorSeguro_ = valorSeguro
    End Sub

    Public Sub setvalorDesconto_(ByVal valorDesconto As Double)
        Me.valorDesconto_ = valorDesconto
    End Sub

    Public Sub settipoTributacao_(ByVal tipoTributacao As Integer)
        Me.tipoTributacao_ = tipoTributacao
    End Sub

    Public Sub setbaseCalcIcms_(ByVal baseCalcIcms As Double)
        Me.baseCalcIcms_ = baseCalcIcms
    End Sub

    Public Sub setaliquotaIcms_(ByVal aliquotaIcms As Double)
        Me.aliquotaIcms_ = aliquotaIcms
    End Sub

    Public Sub setvalorIcms_(ByVal valorIcms As Double)
        Me.valorIcms_ = valorIcms
    End Sub

    Public Sub setbaseCalcIcmsST_(ByVal baseCalcIcms As Double)
        Me.baseCalcIcms_ = baseCalcIcms
    End Sub

    Public Sub setvalorIcmsST_(ByVal valorIcmsST As Double)
        Me.valorIcmsST_ = valorIcmsST
    End Sub

    Public Sub setcstPIS_(ByVal cstPIS As String)
        Me.cstPIS_ = cstPIS
    End Sub

    Public Sub setcstCOFINS_(ByVal cstCOFINS As String)
        Me.cstCOFINS_ = cstCOFINS
    End Sub

    Public Sub setbaseCalcPIS_(ByVal baseCalcPIS As Double)
        Me.baseCalcPIS_ = baseCalcPIS
    End Sub

    Public Sub setbaseCalcCOFINS_(ByVal baseCalcCOFINS As Double)
        Me.baseCalcCOFINS_ = baseCalcCOFINS
    End Sub

    Public Sub setvalorTotal_(ByVal valorTotal As Double)
        Me.valorTotal_ = valorTotal
    End Sub

#End Region

#Region "Obtem os Atributos dessa Classe..."

    Public Function getcodigo_() As String
        Return Me.codigo_
    End Function

    Public Function getnumeroNFe_() As String
        Return Me.numeroNFe_
    End Function

    Public Function getcodigoParticipante_() As String
        Return Me.codigoParticipante_
    End Function

    Public Function getsequencia_() As Integer
        Return Me.sequencia_
    End Function

    Public Function getdescricao_() As String
        Return Me.descricao_
    End Function

    Public Function getcfop_() As String
        Return Me.cfop_
    End Function

    Public Function getcfopTransferencia_() As String
        Return Me.cfopTransferencia_
    End Function

    Public Function getcsta_() As String
        Return Me.csta_
    End Function

    Public Function getcstb_() As String
        Return Me.cstb_
    End Function

    Public Function getquantidade_() As Double
        Return Me.quantidade_
    End Function

    Public Function getunidadeMedida_() As String
        Return Me.unidadeMedida_
    End Function

    Public Function getvalorBruto_() As Double
        Return Me.valorBruto_
    End Function

    Public Function getvalorIPI_() As Double
        Return Me.valorIPI_
    End Function

    Public Function getaliquotaIPI_() As Double
        Return Me.aliquotaIPI_
    End Function

    Public Function getbaseCalcIPI_() As Double
        Return Me.baseCalcIPI_
    End Function

    Public Function getcstIPI_() As String
        Return Me.cstIPI_
    End Function

    Public Function getvalorFrete_() As Double
        Return Me.valorFrete_
    End Function

    Public Function getvalorSeguro_() As Double
        Return Me.valorSeguro_
    End Function

    Public Function getvalorDesconto_() As Double
        Return Me.valorDesconto_
    End Function

    Public Function gettipoTributacao_() As Integer
        Return Me.tipoTributacao_
    End Function

    Public Function getbaseCalcIcms_() As Double
        Return Me.baseCalcIcms_
    End Function

    Public Function getaliquotaIcms_() As Double
        Return Me.aliquotaIcms_
    End Function

    Public Function getvalorIcms_() As Double
        Return Me.valorIcms_
    End Function

    Public Function getbaseCalcIcmsST_() As Double
        Return Me.baseCalcIcms_
    End Function

    Public Function getvalorIcmsST_() As Double
        Return Me.valorIcmsST_
    End Function

    Public Function getcstPIS_() As String
        Return Me.cstPIS_
    End Function

    Public Function getcstCOFINS_() As String
        Return Me.cstCOFINS_
    End Function

    Public Function getbaseCalcPIS_() As Double
        Return Me.baseCalcPIS_
    End Function

    Public Function getbaseCalcCOFINS_() As Double
        Return Me.baseCalcCOFINS_
    End Function

    Public Function getvalorTotal_() As Double
        Return Me.valorTotal_
    End Function

#End Region

End Class
