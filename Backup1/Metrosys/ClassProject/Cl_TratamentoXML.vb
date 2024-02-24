Imports System.Text
Imports GenoNFeXml
Imports System.IO

Public Class Cl_TratamentoXML

    Public gerar As New GeraXml
    Public Arqxml As String = "\wged\tmp\NFE001.txt"
    Public ArqTemp As String = "\wged\tmp\NFE002.txt"
    Public xmlPath As String = "\wged\tmp\MyData.xml"

    Public fsxml As FileStream
    Public s As StreamWriter
    Public mcfop As String = "", mtipoPag As String = ""

    'Tratamento para gerar chave NFe
    Public codUf As String, AnoMes As String, cgc As String, modelo As String
    Public serie As String, numeroNfe As String, cont As String, seqNfe As String, seqNFeInt As Int64, digito As Int16
    Public chaveSemDigitoFinal As String, chaveNFe, anoMesPath As String


    'Tratamento de Retorno do xml...
    Public xmlArquivo As New StringBuilder
    Public strXmlRetorno As String = "", strArqErroRetorno As String = "", strXmlLoteRecebido As String = "", strXmlProcRec As String = ""
    Public numLotRetorno As String = "", strXmlStatus As String = "", strXmlMotivo As String = "", strXmlProcRecAux As String = ""
    Public strXmlProtocolo As String = ""
    Public strXmlRec As String = "", strXmlHora As String = ""
    Public strAux1 As String = "", strAux2 As String = ""
    Public xposinicio, xposfim, xposdif, xposAux As Integer

End Class
