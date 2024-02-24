Imports System.Text
Imports GenoNFeXml
Imports System.IO

Public Class Cl_TratamentoXML

    Public clNFe As New GeraXml
    'Tratamento para gerar chave NFe:
    Public codUf As String, AnoMes As String, cgc As String, modelo As String
    Public serie As String, numeroNfe As String, cont As String, seqNfe As String, seqNFeInt As Int64, digito, tpNF As Int16
    Public chaveSemDigitoFinal As String, chaveNFe, anoMesPath As String
    Public agora As Date = Now

    'Tratamento do Arquivo:
    Public fsxml As FileStream
    Public sw As StreamWriter
    Public Arqxml As String = "\wged\tmp\NFE001.txt"
    Public ArqTemp As String = "\wged\tmp\NFE002.txt"
    Public xmlPath As String = "\wged\tmp\MyData.xml"

    'NFe Lote:
    Public fsxmlIdLote As FileStream
    Public swIdLote As StreamWriter
    Public ArqXmlLoteNFe As String = "\wged\tmp\NFeLote.xml"

    Public mcfop As String = "", mtipoPag As String = ""
    Public mAmb, mcontf, mSeqNFe As String
    Public mExisteNota1pp As Boolean = False
    Public mNumNota1ppExist As String = "", mCodPartNota1ppExist As String = ""


    'Tratamento de Retorno do xml:
    Public xmlArquivo As New StringBuilder
    Public strXmlRetorno As String = "", strArqErroRetorno As String = "", strXmlLoteRecebido As String = "", strXmlProcRec As String = ""
    Public numLotRetorno As String = "", strXmlStatus As String = "", strXmlMotivo As String = "", strXmlProcRecAux As String = ""
    Public strXmlProtocolo As String = "", xmlNomeArquivo As String = "", strArqRetorno As String = "", numReciboNFe As String = ""
    Public strXmlRec As String = "", strXmlHora As String = ""
    Public strAux1 As String = "", strAux2 As String = ""
    Public xposinicio, xposfim, xposdif, xposAux As Integer
    Public idLote As Int64 = 0

    'INICIO da Criação de Variáveis...
    'Gerais:
    Public mNFe_Cfop As String
    Public formBusca As Boolean = False
    Public codLoja As String = "" '2 Digitos
    Public tipoNFe As String = "" 'Armazenará o primeiro Dígito do Valor Cbo_TipoNFe S ou E
    Public digCFOP As String = "" 'Armazenará o primeiro Dígito do CFOP
    Public _cfop As String = "", _cst As String = ""
    Public cfopRef As String = ""
    Public alqInterna, alqExterna As Double
    Public conexao As String = MdlConexaoBD.conectionPadrao

End Class
