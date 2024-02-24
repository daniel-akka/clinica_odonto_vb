Imports System.Xml
Imports System.Text
Imports System.IO
Imports Npgsql


Public Class GenoNFeXml
    'Private ArqTemp As String = "C:\wged\NFE002.txt"
    'Private xmlPath As String = "C:\MyData.xml"
    'Dim fsxml As New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
    'Dim s As New StreamWriter(fsxml)

    
    Public Sub Cria_GenoXml()
        ' Cria um novo ficheiro XML com a codificação UTF8
        'Dim xmlw As New XmlTextWriter(xmlPath, System.Text.Encoding.UTF8)
        'xmlw.Formatting = Formatting.Indented
        's.BaseStream.Seek(0, SeekOrigin.End)

        ''xmlw.WriteStartDocument()
        's.WriteLine("<?xml version=" & "1.0" & " encoding=" & "UTF-8" & " ?>")
        's.WriteLine("<NFe xmlns=" & "http://www.portalfiscal.inf.br/nfe" & ">")

        'xmlw.WriteComment(xmlGrupo_A("22", "10234501", "VENDA DE MERCADORIAS", "0", "55", "1", "121", _
        '               "25/01/2012", "26/01/2012", "1", "2208007", "1", "1", "8", "1", "1", "0", "6"))

        'xmlGrupo_A("22", "10234501", "VENDA DE MERCADORIAS", "0", "55", "1", "121", _
        '          "25/01/2012", "26/01/2012", "1", "2208007", "1", "1", "8", "1", "1", "0", "6")

        's.Close()
        'fsxml.Close()
    End Sub

    Public Function DataInvertidaNFe(ByVal Mdata As String) As String
        Dim str, straux As String
        Dim array As Array
        str = CStr(Mdata)
        straux = CStr(Mdata)
        array = Split(str, "/")
        If array.Length > 1 Then
            If array(0).ToString.Length > 1 And array(1).ToString.Length > 1 Then
                str = Mid(str, 7, 4) & "-" & Mid(str, 4, 2) & "-" & Mid(str, 1, 2)
            ElseIf array(0).ToString.Length = 1 And array(1).ToString.Length > 1 Then
                str = Mid(str, 6, 4) & Mid(str, 3, 2) & "0" & Mid(str, 1, 1)
            ElseIf array(0).ToString.Length > 1 And array(1).ToString.Length = 1 Then
                str = Mid(str, 6, 4) & "0" & Mid(str, 4, 1) & Mid(str, 1, 2)
            Else
                str = Mid(str, 5, 4) & "0" & Mid(str, 3, 1) & "0" & Mid(str, 1, 1)
            End If

            Return str
        Else
            str = ""
            Return str

        End If

    End Function
End Class
