Imports System.Drawing.Printing
Imports Npgsql
Imports System.IO

Public Class Cl_ImpressaoRecibo

    'objetos para impressão
    Public MostrarCaixaImpressoras As Boolean = False
    Public _PrintFont As New Font("Lucida Console", 8) 'Stenci
    Public _PrintPageSettings As New PageSettings
    Public _leitorTabela As NpgsqlDataReader
    Public _pgAtualImpressao As Integer = 1
    Public _tituloConsulta As String = ""
    Public _StringToPrint As String = ""
    Public _sImpressao As StreamWriter
    Public _dtAdaptPrint As NpgsqlDataAdapter
    Public _nomeLoja As String = "", _endereco As String = "", _cidade As String = "", _cep As String = "", _uf As String = ""
    Public _valor As String = "", _documento As String = "", _vencimento As String = ""
    Public _Cliente As New Cl_Cadp001

End Class
