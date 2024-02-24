Imports Npgsql
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports System.Math

Public Class ClFuncoes
    Dim _erro As Boolean
    Dim _msgErro As String
    Public estabelecimento As String = "01"

    Public Function RemoverCaracter(ByVal Valor As String) As String
        Dim Remover As String, i As Byte, Temp As String
        Remover = "()*/-+.,"
        Temp = Valor
        For i = 1 To Valor.Length
            Temp = Replace(Temp, Mid(Remover, i, 1), "")
        Next
        RemoverCaracter = Temp
    End Function

    Public Function RemoverCaracterTelefone(ByVal Valor As String) As String
        Dim Remover As String, i As Byte, Temp As String
        Remover = "()*/-+., "
        Temp = Valor
        For i = 1 To Valor.Length
            Temp = Replace(Temp, Mid(Remover, i, 1), "")
        Next
        RemoverCaracterTelefone = Temp
    End Function

    Public Function RemoverCaracter2(ByVal Valor As String) As String
        Dim Remover As String, i As Byte, Temp As String
        Remover = "()*/-+.,"
        Temp = Valor
        For i = 1 To Remover.Length
            Temp = Replace(Temp, Mid(Remover, i, 1), "")
        Next

        Return Temp
    End Function

    Public Function formataCNPJ_CPF(ByVal cnpj_cpf As String) As String

        Try

            If cnpj_cpf.Length = 14 Then
                cnpj_cpf = Format(Convert.ToInt64(cnpj_cpf), "00\.000\.000\/0000\-00")
            ElseIf cnpj_cpf.Length = 11 Then
                cnpj_cpf = Format(Convert.ToInt64(cnpj_cpf), "000\.000\.000\-00")
            End If
        Catch ex As Exception
        End Try


        Return cnpj_cpf
    End Function

    Public Function formataFone(ByVal fone As String) As String

        Try

            If fone.Length = 10 Then
                fone = Format(Convert.ToInt64(fone), "\(00\) 0000\-0000")
            ElseIf fone.Length = 8 Then
                fone = Format(Convert.ToInt64(fone), "0000\-0000")
            End If
        Catch ex As Exception
        End Try


        Return fone
    End Function

    Public Function returnDiaSemana(ByVal diaIngles As String) As String

        Select Case diaIngles.ToUpper
            Case "MONDAY"
                Return "SEGUNDA-FEIRA"
            Case "TUESDAY"
                Return "TERÇA-FEIRA"
            Case "WEDNESDAY"
                Return "QUARTA-FEIRA"
            Case "THURSDAY"
                Return "QUINTA-FEIRA"
            Case "FRIDAY"
                Return "SEXTA-FEIRA"
            Case "SATURDAY"
                Return "SÁBADO"
            Case "SUNDAY"
                Return "DOMINGO"
        End Select

        Return diaIngles.ToUpper
    End Function

    Public Function repeteCaracteresPagina(ByVal caracter As String, ByVal qtdeRepeticao As Integer) As String
        Dim retorno As String = ""

        For i As Integer = 1 To qtdeRepeticao
            retorno += caracter
        Next

        Return retorno
    End Function

    Public Function SoNumeros(ByVal Keyascii As Short) As Short

        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoNumeros = 0
        Else
            SoNumeros = Keyascii
        End If

        Select Case Keyascii
            Case 8
                SoNumeros = Keyascii
            Case 13
                SoNumeros = Keyascii
            Case 32
                SoNumeros = Keyascii
        End Select

    End Function

    Public Function SoNumerosPonto(ByVal Keyascii As Short) As Short

        If InStr("1234567890.", Chr(Keyascii)) = 0 Then

            SoNumerosPonto = 0

        Else
            SoNumerosPonto = Keyascii
        End If

        Select Case Keyascii
            Case 8
                SoNumerosPonto = Keyascii
            Case 13
                SoNumerosPonto = Keyascii
            Case 32
                SoNumerosPonto = Keyascii
        End Select

    End Function

    Public Function SoNumerosVirgula(ByVal Keyascii As Short) As Short

        If InStr("1234567890,", Chr(Keyascii)) = 0 Then

            SoNumerosVirgula = 0

        Else
            SoNumerosVirgula = Keyascii
        End If

        Select Case Keyascii
            Case 8
                SoNumerosVirgula = Keyascii
            Case 13
                SoNumerosVirgula = Keyascii
            Case 32
                SoNumerosVirgula = Keyascii
        End Select

    End Function

    Public Function SoNumerosVirgulaNegativo(ByVal Keyascii As Short) As Short

        If InStr("1234567890-,", Chr(Keyascii)) = 0 Then

            SoNumerosVirgulaNegativo = 0

        Else
            SoNumerosVirgulaNegativo = Keyascii
        End If

        Select Case Keyascii
            Case 8
                SoNumerosVirgulaNegativo = Keyascii
            Case 13
                SoNumerosVirgulaNegativo = Keyascii
            Case 32
                SoNumerosVirgulaNegativo = Keyascii
        End Select

    End Function

    Public Function SoLetras(ByVal KeyAscii As Integer) As Integer

        'Transformar letras minusculas em Maiúsculas
        KeyAscii = Asc(UCase(Chr(KeyAscii)))

        ' Intercepta um código ASCII recebido e admite somente letras
        If InStr("AÃÁBCÇDEÉÊFGHIÍJKLMNOPQRSTUÚVWXYZ", Chr(KeyAscii)) = 0 Then
            SoLetras = 0
        Else
            SoLetras = KeyAscii
        End If

        ' teclas adicionais permitidas
        If KeyAscii = 8 Then SoLetras = KeyAscii ' Backspace
        If KeyAscii = 13 Then SoLetras = KeyAscii ' Enter
        If KeyAscii = 32 Then SoLetras = KeyAscii ' Espace

    End Function

    Public Function IsVogal(ByVal vogal As String) As Boolean

        Select Case vogal.ToLower
            Case "a", "e", "i", "o", "u"
                Return True
            Case Else
                Return False
        End Select

    End Function

    Public Function fatd001_ftipoRetornMp(ByVal codTipo As String) As String

        '01 - Dinheiro
        '02 - Cheque
        '03 - NP
        '04 - Boleto
        '05 - Cartao Credito
        '06 - Outros

        Select Case codTipo
            Case "01"
                Return "AV"
            Case "02"
                Return "CH"
            Case "03"
                Return "NP"
            Case "04"
                Return "BL"
            Case "05"
                Return "CT"
            Case "06"
                Return "CR"
            Case "07"
                Return "OT"
        End Select

    End Function

    Public Function returnMesExtenso(ByVal mes As Integer) As String
        Dim meses() As String = {"janeiro", "fevereiro", "março", "abril", "maio", _
                               "junho", "julho", "agosto", "setembro", "outubro", _
                               "novembro", "dezembro"}


        Return meses((mes - 1)).ToString
    End Function

    Public Function returnLetraAlfabetoPosi(ByVal posicao As Int16) As String
        Dim alfabeto() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", _
                               "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Dim letra As String = ""
        Try
            letra = alfabeto(posicao - 1).ToString
        Catch ex As Exception
        End Try

        Return letra
    End Function

    Public Function returnNumPosicaoLetraAlfab(ByVal Letra As String) As Integer

        Select Case Letra.ToUpper
            Case "A"
                Return 1
            Case "B"
                Return 2
            Case "C"
                Return 3
            Case "D"
                Return 4
            Case "E"
                Return 5
            Case "F"
                Return 6
            Case "G"
                Return 7
            Case "H"
                Return 8
            Case "I"
                Return 9
            Case "J"
                Return 10
            Case "K"
                Return 11
            Case "L"
                Return 12
            Case "M"
                Return 13
            Case "N"
                Return 14
            Case "O"
                Return 15
            Case "P"
                Return 16
            Case "Q"
                Return 17
            Case "R"
                Return 18
            Case "S"
                Return 19
            Case "T"
                Return 20
            Case "U"
                Return 21
            Case "V"
                Return 22
            Case "W"
                Return 23
            Case "X"
                Return 24
            Case "Y"
                Return 25
            Case "Z"
                Return 26
            Case Else
                Return 0
        End Select


    End Function

    Public Function primeiraLetraMaiusculaPalavra(ByVal str As String) As String

      
        Try

            If str.Length > 0 Then

                If str.Length > 1 Then

                    str = Mid(str, 1, 1).ToUpper & Mid(str, 2).ToLower
                Else
                    str = Mid(str, 1, 1).ToUpper
                End If
            End If
        Catch ex As Exception
            str = ""
        End Try

        Return str
    End Function

    Public Function returnZeroDireita(ByVal str As String, ByVal tamanho As Integer) As String
        Dim mzeros As String = ""
        Dim i, quantZeros As Integer

        If str.Length > tamanho Then
            str = str.Substring((str.Length - tamanho), tamanho)

        ElseIf str.Length < tamanho Then

            quantZeros = (tamanho - str.Length)
            For i = 0 To quantZeros - 1

                mzeros = mzeros & "0"
            Next
            str = mzeros & str
        End If


        Return str
    End Function

    Public Function existCaracEspeciais(ByVal str As String) As Boolean
        Dim existCaracEspec As Boolean = False
        Dim indice As Integer
        Dim comAcentos As String = "!#$%¨&*@()-?:{}][.,;|\/+'""ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç "

        For indice = 0 To comAcentos.Length - 1

            If InStr(str, comAcentos.Substring(indice, 1)) > 0 Then

                existCaracEspec = True
                Exit For
            End If
        Next

        Return existCaracEspec
    End Function

    ''' <summary>
    ''' Função principal que recolhe o valor e chama as duas funções
    ''' auxiliares para a parte inteira e para a parte decimal
    ''' </summary>
    ''' <param name="number">Número a converter para extenso (Reais)</param>
    ''' 
    Public Function NumeroToExtenso(ByVal number As Decimal) As String
        Dim cent As Integer
        Try
            ' se for =0 retorna 0 reais
            If number = 0 Then
                Return "Zero Reais"
            End If
            ' Verifica a parte decimal, ou seja, os centavos
            cent = Decimal.Round((number - Int(number)) * 100, MidpointRounding.ToEven)
            ' Verifica apenas a parte inteira
            number = Int(number)
            ' Caso existam centavos
            If cent > 0 Then
                ' Caso seja 1 não coloca "Reais" mas sim "Real"
                If number = 1 Then
                    Return "Um Real e " + getDecimal(cent) + "centavos"
                    ' Caso o valor seja inferior a 1 Real
                ElseIf number = 0 Then
                    Return getDecimal(cent) + "centavos"
                Else
                    Return getInteger(number) + "Reais e " + getDecimal(cent) + "centavos"
                End If
            Else
                ' Caso seja 1 não coloca "Reais" mas sim "Real"
                If number = 1 Then
                    Return "Um Real"
                Else
                    Return getInteger(number) + "Reais"
                End If
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Função auxiliar - Parte decimal a converter
    ''' </summary>
    ''' <param name="number">Parte decimal a converter</param>
    Public Function getDecimal(ByVal number As Byte) As String
        Try
            Select Case number
                Case 0
                    Return ""
                Case 1 To 19
                    Dim strArray() As String = _
                       {"Um", "Dois", "Três", "Quatro", "Cinco", "Seis", _
                        "Sete", "Oito", "Nove", "Dez", "Onze", _
                        "Doze", "Treze", "Quatorze", "Quinze", _
                        "Dezesseis", "Dezessete", "Dezoito", "Dezenove"}
                    Return strArray(number - 1) + " "
                Case 20 To 99
                    Dim strArray() As String = _
                        {"Vinte", "Trinta", "Quarenta", "Cinquenta", _
                        "Sessenta", "Setenta", "Oitenta", "Noventa"}
                    If (number Mod 10) = 0 Then
                        Return strArray(number \ 10 - 2) + " "
                    Else
                        Return strArray(number \ 10 - 2) + " e " + getDecimal(number Mod 10) + " "
                    End If
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Função auxiliar - Parte inteira a converter
    ''' </summary>
    ''' <param name="number">Parte inteira a converter</param>
    Public Function getInteger(ByVal number As Decimal) As String
        Try
            number = Int(number)
            Select Case number
                Case Is < 0
                    Return "-" & getInteger(-number)
                Case 0
                    Return ""
                Case 1 To 19
                    Dim strArray() As String = _
                        {"Um", "Dois", "Três", "Quatro", "Cinco", "Seis", _
                        "Sete", "Oito", "Nove", "Dez", "Onze", "Doze", _
                        "Treze", "Quatorze", "Quinze", "Dezesseis", _
                        "Dezessete", "Dezoito", "Dezenove"}
                    Return strArray(number - 1) + " "
                Case 20 To 99
                    Dim strArray() As String = _
                        {"Vinte", "Trinta", "Quarenta", "Cinquenta", _
                        "Sessenta", "Setenta", "Oitenta", "Noventa"}
                    If (number Mod 10) = 0 Then
                        Return strArray(number \ 10 - 2)
                    Else
                        Return strArray(number \ 10 - 2) + " e " + getInteger(number Mod 10)
                    End If
                Case 100
                    Return "Cem"
                Case 101 To 999
                    Dim strArray() As String = _
                           {"Cento", "Duzentos", "Trezentos", "Quatrocentos", "Quinhentos", _
                           "Seiscentos", "Setecentos", "Oitocentos", "Novecentos"}
                    If (number Mod 100) = 0 Then
                        Return strArray(number \ 100 - 1) + " "
                    Else
                        Return strArray(number \ 100 - 1) + " e " + getInteger(number Mod 100)
                    End If
                Case 1000 To 1999
                    Select Case (number Mod 1000)
                        Case 0
                            Return "Mil"
                        Case Is <= 100
                            Return "Mil e " + getInteger(number Mod 1000)
                        Case Else
                            Return "Mil, " + getInteger(number Mod 1000)
                    End Select
                Case 2000 To 999999
                    Select Case (number Mod 1000)
                        Case 0
                            Return getInteger(number \ 1000) & "Mil"
                        Case Is <= 100
                            Return getInteger(number \ 1000) & "Mil e " & getInteger(number Mod 1000)
                        Case Else
                            Return getInteger(number \ 1000) & "Mil, " & getInteger(number Mod 1000)
                    End Select
                Case 1000000 To 1999999
                    Select Case (number Mod 1000000)
                        Case 0
                            Return "Um Milhão"
                        Case Is <= 100
                            Return getInteger(number \ 1000000) + "Milhão e " & getInteger(number Mod 1000000)
                        Case Else
                            Return getInteger(number \ 1000000) + "Milhão, " & getInteger(number Mod 1000000)
                    End Select
                Case 2000000 To 999999999
                    Select Case (number Mod 1000000)
                        Case 0
                            Return getInteger(number \ 1000000) + " Milhões"
                        Case Is <= 100
                            Return getInteger(number \ 1000000) + "Milhões e " & getInteger(number Mod 1000000)
                        Case Else
                            Return getInteger(number \ 1000000) + "Milhões, " & getInteger(number Mod 1000000)
                    End Select
                Case 1000000000 To 1999999999
                    Select Case (number Mod 1000000000)
                        Case 0
                            Return "Um Bilhão"
                        Case Is <= 100
                            Return getInteger(number \ 1000000000) + "Bilhão e " + getInteger(number Mod 1000000000)
                        Case Else
                            Return getInteger(number \ 1000000000) + "Bilhão, " + getInteger(number Mod 1000000000)
                    End Select
                Case Else
                    Select Case (number Mod 1000000000)
                        Case 0
                            Return getInteger(number \ 1000000000) + " Bilhões"
                        Case Is <= 100
                            Return getInteger(number \ 1000000000) + "Bilhões e " + getInteger(number Mod 1000000000)
                        Case Else
                            Return getInteger(number \ 1000000000) + "Bilhões, " + getInteger(number Mod 1000000000)
                    End Select
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function trazSigla_UF(ByVal codUF As String, ByVal conexao As String) As String

        Dim nomeloja As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return ""

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sqlEstab As New StringBuilder
        Dim cmdEstab As NpgsqlCommand
        Dim drEstab As NpgsqlDataReader

        sqlEstab.Append("SELECT sigla FROM cadestado WHERE codestado = '" & codUF & "'")

        cmdEstab = New NpgsqlCommand(sqlEstab.ToString, oConnBDGENOV)
        drEstab = cmdEstab.ExecuteReader

        Dim UF As String
        UF = ""

        While drEstab.Read
            UF = drEstab(0).ToString
        End While
        drEstab.Close() : cmdEstab = Nothing : sqlEstab = Nothing : drEstab = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return UF
    End Function

    Public Function trazCodUF(ByVal siglaUF As String, ByVal conexao As String) As String

        Dim nomeloja As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return ""

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sqlEstab As New StringBuilder
        Dim cmdEstab As NpgsqlCommand
        Dim drEstab As NpgsqlDataReader

        sqlEstab.Append("SELECT codestado FROM cadestado WHERE sigla = '" & siglaUF & "'")

        cmdEstab = New NpgsqlCommand(sqlEstab.ToString, oConnBDGENOV)
        drEstab = cmdEstab.ExecuteReader

        Dim UF As String
        UF = ""

        While drEstab.Read
            UF = drEstab(0).ToString
        End While
        drEstab.Close() : cmdEstab = Nothing : sqlEstab = Nothing : drEstab = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return UF
    End Function

    Public Function trazNomeLoja(ByVal codLoja As String, ByVal conexao As String) As String

        Dim nomeloja As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return ""

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sqlEstab As New StringBuilder
        Dim cmdEstab As NpgsqlCommand
        Dim drEstab As NpgsqlDataReader

        sqlEstab.Append("SELECT g_geno, g_cgc, g_insc, g_uf, g_ender, g_cid ")
        sqlEstab.Append("FROM geno001 WHERE g_codig = '" & codLoja & "'")

        cmdEstab = New NpgsqlCommand(sqlEstab.ToString, oConnBDGENOV)
        drEstab = cmdEstab.ExecuteReader

        Dim nomeEstab As String ', cnpjEstab, inscEstab, ufEstab, enderEstab, cidEstab As String

        nomeEstab = "" ': cnpjEstab = "" : inscEstab = "" : ufEstab = "" : enderEstab = "" : cidEstab = ""

        While drEstab.Read

            nomeEstab = drEstab(0).ToString ' : cnpjEstab = drEstab(1) : inscEstab = drEstab(2)
            'ufEstab = drEstab(3) : enderEstab = drEstab(4) : cidEstab = drEstab(5)
            nomeloja = nomeEstab
        End While
        drEstab.Close() : cmdEstab = Nothing : sqlEstab = Nothing : drEstab = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return nomeloja
    End Function

    Public Function trazNomeImagemProduto(ByVal id As Int64, ByVal conexao As String) As String

        Dim nomeImagem As String = ""
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return ""

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT img_nome FROM " & MdlEmpresaUsu._esqVinc & ".imagemprodutos WHERE img_id = " & id)
        cmd = New NpgsqlCommand(sql.ToString, oConn)
        dr = cmd.ExecuteReader


        While dr.Read
            nomeImagem = dr(0).ToString
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConn.ClearAllPools() : oConn.Close() : oConn = Nothing


        Return nomeImagem
    End Function

    Public Function trazRoteiroMapa(ByVal mapa As Integer, ByVal conexao As String) As String

        Dim roteiro As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return ""

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT rt_roteiro FROM " & MdlEmpresaUsu._esqEstab & ".rotmapa ")
        sql.Append("WHERE rt_mapa = " & mapa)

        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        dr = cmd.ExecuteReader

        While dr.Read

            roteiro = dr(0).ToString
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return roteiro
    End Function

    'Para a certo deve trazer os 4 últimos caracteres do codigo do vendedor...
    Public Function trazNomeVendedor(ByVal codVendedor As String, ByVal codLoja As String, _
                                     ByVal conexao As String) As String

        Dim nomeVendedor As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return ""

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sqlEstab As New StringBuilder
        Dim cmdEstab As NpgsqlCommand
        Dim drEstab As NpgsqlDataReader

        sqlEstab.Append("SELECT v_nome FROM cadvendedor WHERE SUBSTR(v_codigo, 3, 4) = '" & codVendedor & "' AND ")
        sqlEstab.Append("v_local = '" & codLoja & "'")

        cmdEstab = New NpgsqlCommand(sqlEstab.ToString, oConnBDGENOV)
        drEstab = cmdEstab.ExecuteReader

        While drEstab.Read

            nomeVendedor = drEstab(0).ToString

        End While
        drEstab.Close() : cmdEstab = Nothing : sqlEstab = Nothing : drEstab = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return nomeVendedor
    End Function

    'Para da certo deve trazer os 4 últimos caracteres do codigo do vendedor...
    Public Function trazComissionadoVendedor(ByVal codVendedor As String, ByVal codLoja As String, _
                                     ByVal conexao As String) As Boolean

        Dim v_comissionado As Boolean
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sqlEstab As New StringBuilder
        Dim cmdEstab As NpgsqlCommand
        Dim drEstab As NpgsqlDataReader

        sqlEstab.Append("SELECT v_comissionado FROM cadvendedor WHERE SUBSTR(v_codigo, 3, 4) = '" & codVendedor & "' AND ")
        sqlEstab.Append("v_local = '" & codLoja & "'")

        cmdEstab = New NpgsqlCommand(sqlEstab.ToString, oConnBDGENOV)
        drEstab = cmdEstab.ExecuteReader

        While drEstab.Read

            v_comissionado = drEstab(0)
        End While
        drEstab.Close() : cmdEstab = Nothing : sqlEstab = Nothing : drEstab = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing



        Return v_comissionado
    End Function

    'Para da certo deve trazer os 4 últimos caracteres do codigo do vendedor...
    Public Function trazTipoComissaoVendedor(ByVal codVendedor As String, ByVal codLoja As String, _
                                     ByVal conexao As String) As String

        Dim v_tipocomissao As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return ""

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sqlEstab As New StringBuilder
        Dim cmdEstab As NpgsqlCommand
        Dim drEstab As NpgsqlDataReader

        sqlEstab.Append("SELECT v_tipocomissao FROM cadvendedor WHERE SUBSTR(v_codigo, 3, 4) = '" & codVendedor & "' AND ")
        sqlEstab.Append("v_local = '" & codLoja & "'")

        cmdEstab = New NpgsqlCommand(sqlEstab.ToString, oConnBDGENOV)
        drEstab = cmdEstab.ExecuteReader

        While drEstab.Read

            v_tipocomissao = drEstab(0).ToString
        End While
        drEstab.Close() : cmdEstab = Nothing : sqlEstab = Nothing : drEstab = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_tipocomissao
    End Function

    Public Function trazTipoImpressora(ByVal Endereco_mac As String, ByVal conexao As String) As Integer

        Dim v_tipoImpressora As Integer
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return ""

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT ec_tipo FROM cdcaixa WHERE ec_regmac = @ec_regmac")

        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@ec_regmac", Endereco_mac)
        dr = cmd.ExecuteReader

        While dr.Read

            v_tipoImpressora = dr(0)
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_tipoImpressora
    End Function

    'Para da certo deve trazer os 4 últimos caracteres do codigo do vendedor...
    Public Function trazAlqComissVendedor(ByVal codVendedor As String, ByVal codLoja As String, _
                                     ByVal conexao As String) As Double

        Dim v_alqcomiss As Double
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sqlEstab As New StringBuilder
        Dim cmdEstab As NpgsqlCommand
        Dim drEstab As NpgsqlDataReader

        sqlEstab.Append("SELECT v_alqcomiss FROM cadvendedor WHERE SUBSTR(v_codigo, 3, 4) = '" & codVendedor & "' AND ")
        sqlEstab.Append("v_local = '" & codLoja & "'")

        cmdEstab = New NpgsqlCommand(sqlEstab.ToString, oConnBDGENOV)
        drEstab = cmdEstab.ExecuteReader

        While drEstab.Read

            v_alqcomiss = drEstab(0)
        End While
        drEstab.Close() : cmdEstab = Nothing : sqlEstab = Nothing : drEstab = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_alqcomiss
    End Function

    Public Function trazCom1Produto(ByVal esqVinculo As String, ByVal codproduto As String, ByVal conexao As String) As Double

        Dim mCom1 As Double = 0.0

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader

        Dim sqlcmd As String = "SELECT e_com1 FROM " & esqVinculo & ".est0001 WHERE e_codig = @e_codig"
        comm = New NpgsqlCommand(sqlcmd.ToString, oConnBDGENOV)

        comm.Parameters.Add("@e_codig", codproduto)
        dr = comm.ExecuteReader

        While dr.Read

            mCom1 = CDbl(dr(0).ToString)
        End While
        dr.Close() : comm = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return mCom1
    End Function

    Public Function trazSomaColunaOrca2cc(ByVal nomeColuna As String, ByVal numPedido As String, _
                                     ByVal conexao As String) As Double

        Dim v_ValorColuna As Double
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT sum(" & nomeColuna & ") FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc ")
        sql.Append("WHERE no_orca = @no_orca")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@no_orca", numPedido)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0)
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return Round(v_ValorColuna, 2)
    End Function

    Public Function trazValorColunaOrca2cc(ByVal nomeColuna As String, ByVal numPedido As String, _
                                     ByVal codProd As String, ByVal conexao As String) As String

        Dim v_ValorColuna As String
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT " & nomeColuna & " FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc ")
        sql.Append("WHERE no_orca = @no_orca AND no_codpr = @no_codpr")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@no_orca", numPedido)
        cmd.Parameters.Add("@no_codpr", codProd)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0)
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazValorColunaEst0001(ByVal nomeColuna As String, ByVal codProd As String, _
                                           ByVal conexao As String) As String

        Dim v_ValorColuna As String
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT " & nomeColuna & " FROM " & MdlEmpresaUsu._esqVinc & ".est0001 ")
        sql.Append("WHERE e_codig = @e_codig")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@e_codig", codProd)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0)
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazValorColunaEstloja01(ByVal nomeColuna As String, ByVal codProd As String, _
                                            ByVal loja As String, ByVal conexao As String) As String

        Dim v_ValorColuna As String
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT " & nomeColuna & " FROM estloja01 WHERE e_codig = @e_codig AND e_loja = @e_loja")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@e_codig", codProd)
        cmd.Parameters.Add("@e_loja", loja)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0)
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazSomaTprodOrca2cc(ByVal numPedido As String, ByVal conexao As String) As Double

        Dim v_ValorColuna As Double
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT sum((no_prunit * no_qtde)) FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc ")
        sql.Append("WHERE no_orca = @no_orca")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@no_orca", numPedido)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0)
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return Round(v_ValorColuna, 2)
    End Function

    Public Function trazSomaValorParcialFatdp02(ByVal numDuplicada As String, ByVal codParticipante As String, _
                                                ByVal conexao As String) As Double

        Dim v_ValorColuna As Double
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader


        sql.Append("SELECT sum(f_valor) FROM " & MdlEmpresaUsu._esqEstab & ".fatdp02 ")
        sql.Append("WHERE f_duplic = @f_duplic AND f_portad = @f_portad")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@f_duplic", numDuplicada)
        cmd.Parameters.Add("@f_portad", codParticipante)
        dr = cmd.ExecuteReader

        While dr.Read

            Try
                v_ValorColuna = dr(0)
            Catch ex As Exception
                v_ValorColuna = 0
            End Try
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return Round(v_ValorColuna, 2)
    End Function

    Public Function trazSomaValorFatd001(ByVal numDuplicada As String, ByVal codParticipante As String, _
                                                ByVal conexao As String) As Double

        Dim v_ValorColuna As Double
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader


        sql.Append("SELECT sum(f_valor) FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 ")
        sql.Append("WHERE f_duplic = @f_duplic AND f_portad = @f_portad")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@f_duplic", numDuplicada)
        cmd.Parameters.Add("@f_portad", codParticipante)
        dr = cmd.ExecuteReader

        While dr.Read

            Try
                v_ValorColuna = dr(0)
            Catch ex As Exception
                v_ValorColuna = 0
            End Try
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return Round(v_ValorColuna, 2)
    End Function

    Public Function trazTotPedidoOrca4dd(ByVal numPedido As String, ByVal conexao As String) As Double

        Dim v_ValorColuna As Double
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try


        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT n4_tgeral FROM " & MdlEmpresaUsu._esqEstab & ".orca4dd ")
        sql.Append("WHERE n4_nume = @n4_nume")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@n4_nume", numPedido)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0)
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return Round(v_ValorColuna, 2)
    End Function

    Public Function trazQtdeItensOrca2cc(ByVal numPedido As String, ByVal conexao As String) As Double

        Dim v_ValorColuna As Double
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try


        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT SUM(no_qtde) FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc ")
        sql.Append("WHERE no_orca = @no_orca")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@no_orca", numPedido)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0)
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return Round(v_ValorColuna, 2)
    End Function

    Public Function trazCountItensOrca2cc(ByVal numPedido As String, ByVal conexao As String) As Double

        Dim v_ValorColuna As Double
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try


        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT Count(no_qtde) FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc ")
        sql.Append("WHERE no_orca = @no_orca")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@no_orca", numPedido)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0)
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return Round(v_ValorColuna, 2)
    End Function

    Public Function trazColunaCadp001(ByVal codCliente As String, ByVal coluna As String, _
                                      ByVal conexao As String) As String

        Dim v_ValorColuna As String
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try


        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT " & coluna & " FROM cadp001 WHERE p_cod = @p_cod")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@p_cod", codCliente)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0).ToString
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazVlrColunaGenp001(ByVal codLoja As String, ByVal nomeColuna As String, _
                                      ByVal conexao As String) As String

        Dim v_ValorColuna As String
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try


        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT " & nomeColuna & " FROM genp001 WHERE gp_geno = @gp_geno")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@gp_geno", codLoja)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0).ToString
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazVlrColunaNota1pp(ByVal numeroNota1pp As String, ByVal esquemaLoja As String, ByVal nomeColuna As String, _
                                      ByVal conexao As String) As String

        Dim v_ValorColuna As String
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try


        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT " & nomeColuna & " FROM " & esquemaLoja & ".nota1pp WHERE nt_nume = @nt_nume")
        cmd = New NpgsqlCommand(sql.ToString, oConn)
        cmd.Parameters.Add("@nt_nume", numeroNota1pp)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0).ToString
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConn.ClearAllPools() : oConn.Close() : oConn = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazQtdeEstloja01(ByVal codProd As String, ByVal loja As String, _
                                      ByVal conexao As String) As Double

        Dim v_ValorColuna As Double
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try


        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT e_qtde FROM estloja01 WHERE e_codig = @e_codig AND e_loja = @e_loja")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@e_codig", codProd)
        cmd.Parameters.Add("@e_loja", loja)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0)
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return Round(v_ValorColuna, 2)
    End Function

    Public Function trazQtdFiscEstloja01(ByVal codProd As String, ByVal loja As String, _
                                      ByVal conexao As String) As Double

        Dim v_ValorColuna As Double
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try


        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT e_qtdfisc FROM estloja01 WHERE e_codig = @e_codig AND e_loja = @e_loja")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@e_codig", codProd)
        cmd.Parameters.Add("@e_loja", loja)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0)
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return Round(v_ValorColuna, 2)
    End Function

    Public Function trazTotVendBrutaDiaCup4dd(ByVal dia As Date, ByVal idImpressora As Integer, _
                                              ByVal conexao As String) As Double

        Dim v_ValorColuna As Double
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader


        sql.Append("SELECT Sum(c4.n4_tgeral) FROM " & MdlEmpresaUsu._esqEstab & ".cup1pp c1 LEFT JOIN ")
        sql.Append(MdlEmpresaUsu._esqEstab & ".cup4dd c4 ON c4.n4_nume = c1.cp_orca WHERE ")
        sql.Append("c1.cp_dtemis = @cp_dtemis AND c1.cp_idcdcaixa = @cp_idcdcaixa")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@cp_dtemis", Convert.ChangeType(dia, GetType(Date)))
        cmd.Parameters.Add("@cp_idcdcaixa", idImpressora)
        dr = cmd.ExecuteReader

        While dr.Read

            Try
                v_ValorColuna = dr(0)
            Catch ex As Exception
            End Try
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazUltimoNumCupom(ByVal idImpressora As Integer, ByVal conexao As String) As String

        Dim v_ValorColuna As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT c2.no_ncupom, c1.cp_tipo FROM " & MdlEmpresaUsu._esqEstab & ".cup2cc c2, ")
        sql.Append(MdlEmpresaUsu._esqEstab & ".cup1pp c1 GROUP BY c2.no_ncupom, c1.cp_tipo, c1.cp_orca, ")
        sql.Append("c2.no_orca HAVING c2.no_orca = c1.cp_orca AND c2.no_idcdcaixa = @no_idcdcaixa = AND ")
        sql.Append("c2.no_ncupom = (SELECT Max(no_ncupom) ")
        sql.Append("FROM " & MdlEmpresaUsu._esqEstab & ".cup2cc)")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@no_idcdcaixa", idImpressora)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0).ToString
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazCupomInicialDia(ByVal data As Date, ByVal idImpressora As Integer, _
                                        ByVal conexao As String) As String

        Dim v_ValorColuna As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT Min(c2.no_ncupom) FROM " & MdlEmpresaUsu._esqEstab & ".cup2cc c2 ")
        sql.Append("WHERE c2.no_dtemis = @no_dtemis AND c2.no_idcdcaixa = @no_idcdcaixa")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@no_dtemis", Convert.ChangeType(data, GetType(Date)))
        cmd.Parameters.Add("@no_idcdcaixa", idImpressora)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0).ToString
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazCupomFinalDia(ByVal data As Date, ByVal idImpressora As Integer, _
                                        ByVal conexao As String) As String

        Dim v_ValorColuna As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT Max(c2.no_ncupom) FROM " & MdlEmpresaUsu._esqEstab & ".cup2cc c2 ")
        sql.Append("WHERE c2.no_dtemis = @no_dtemis AND c2.no_idcdcaixa = @no_idcdcaixa")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@no_dtemis", Convert.ChangeType(data, GetType(Date)))
        cmd.Parameters.Add("@no_idcdcaixa", idImpressora)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0).ToString
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazUltPedidoCupom(ByVal idImpressora As Integer, ByVal conexao As String) As String

        Dim v_ValorColuna As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT c1.cp_orca FROM " & MdlEmpresaUsu._esqEstab & ".cup2cc c2, ")
        sql.Append(MdlEmpresaUsu._esqEstab & ".cup1pp c1 WHERE c2.no_orca = c1.cp_orca AND ")
        sql.Append("c2.no_idcdcaixa = @no_idcdcaixa AND c2.no_ncupom = (SELECT Max(no_ncupom) ")
        sql.Append("FROM " & MdlEmpresaUsu._esqEstab & ".cup2cc) LIMIT 1")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@no_idcdcaixa", idImpressora)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0).ToString
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazSituacaoUltimoCupom(ByVal idImpressora As Integer, ByVal conexao As String) As String

        Dim v_ValorColuna As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return 0.0

        End Try


        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT c1.cp_tipo FROM " & MdlEmpresaUsu._esqEstab & ".cup2cc c2, ")
        sql.Append(MdlEmpresaUsu._esqEstab & ".cup1pp c1 WHERE c2.no_orca = c1.cp_orca AND ")
        sql.Append("c1.cp_idcdcaixa = @cp_idcdcaixa AND c2.no_ncupom = (SELECT Max(no_ncupom) ")
        sql.Append("FROM " & MdlEmpresaUsu._esqEstab & ".cup2cc) LIMIT 1")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@cp_idcdcaixa", idImpressora)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0).ToString
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazDiaDoUltimoCupom(ByVal idImpressora As Integer, ByVal conexao As String) As Date

        Dim v_ValorColuna As Date
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return v_ValorColuna
        End Try

        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT Max(c2.no_dtemis) FROM " & MdlEmpresaUsu._esqEstab & ".cup2cc c2 ")
        sql.Append("GROUP BY c2.no_dtemis, c2.no_ncupom, c2.no_idcdcaixa HAVING c2.no_idcdcaixa = ")
        sql.Append("@no_idcdcaixa AND c2.no_ncupom = (SELECT Max(no_ncupom) ")
        sql.Append("FROM " & MdlEmpresaUsu._esqEstab & ".cup2cc) LIMIT 1")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@no_idcdcaixa", idImpressora)
        dr = cmd.ExecuteReader

        While dr.Read

            Try
                v_ValorColuna = Convert.ChangeType(dr(0), GetType(Date))
            Catch ex As Exception
            End Try
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function CX_FechadoNoDia(ByVal codCaixa As String, ByVal dataDia As Date, ByVal conexao As String) As Boolean

        Dim cxFechado As Boolean = False
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return cxFechado
        End Try

        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT cx_data FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario  ")
        sql.Append("WHERE cx_data = '" & Format(dataDia, "dd/MM/yyyy") & "' AND cx_tipo = 'S' AND cx_loja = '" & MdlEmpresaUsu._codigo & "' ")
        sql.Append("AND cx_caixa = '" & codCaixa & "' ")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        dr = cmd.ExecuteReader

        If dr.HasRows Then cxFechado = True

        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return cxFechado
    End Function

    Public Function CX_AbertoNoDia(ByVal codCaixa As String, ByVal dataDia As Date, ByVal conexao As String) As Boolean

        Dim cxAberto As Boolean = False
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return cxAberto
        End Try

        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT cx_data FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario  ")
        sql.Append("WHERE cx_data = '" & Format(dataDia, "dd/MM/yyyy") & "' AND cx_tipo = 'A' AND cx_loja = '" & MdlEmpresaUsu._codigo & "' ")
        sql.Append("AND cx_caixa = '" & codCaixa & "' ")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        dr = cmd.ExecuteReader

        If dr.HasRows Then cxAberto = True

        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return cxAberto
    End Function

    Public Function trazVlrUltimoFechamentoCX(ByVal dataDia As Date, ByVal conexao As String) As Double

        Dim v_VlrUltminoFech As Double
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return v_VlrUltminoFech
        End Try

        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT DISTINCT Max(cx_data), cx_valor FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario GROUP BY cx_valor, cx_data, cx_tipo ")
        sql.Append("HAVING cx_data < '" & Format(dataDia, "dd/MM/yyyy") & "' AND cx_tipo = 'S'")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        dr = cmd.ExecuteReader

        While dr.Read

            Try
                v_VlrUltminoFech = dr(1)
            Catch ex As Exception
                v_VlrUltminoFech = 0.0
            End Try
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_VlrUltminoFech
    End Function

    Public Function sldDoDia(ByVal dataDia As Date) As Double

        Dim _mConsulta As String
        'Variáveis Totais...
        Dim mSaldoDoDia As Double = 0.0
        Dim mFatura, mCodCliente, mNomeCliente, mDtEmiss, mDtVencimento, mDescrPagto, mFaturaLetra, mParcelas As String
        Dim mPosiParcela As Integer = 0, mDiasAtrazo As Integer = 0
        Dim mValor As Double = 0.0, mSomaValorDupliNorm As Double = 0.0, mSomaValorDupliParc As Double = 0.0
        Dim mJuros As Double = 0.0, mSomaJurosNorm As Double = 0.0, mSomaJurosParc As Double = 0.0
        Dim mTotal As Double = 0.0, mSomaTotalDuplic As Double = 0.0, mSomaTotalReceitas As Double = 0.0
        Dim mData As String = Format(dataDia, "dd/MM/yyyy")
        Dim mStrLinha As String = "", mStrLinhaAux As String = ""

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return 0.0
        End Try


        'Duplicatas de Recebimento Normais........
        _mConsulta = "SELECT f_portad, cad.p_portad, f_duplic, Substr(f_duplic, Length(f_duplic)), f_emiss, f_vencto, '', " & _
        "f_valor, f_juros, ((f_valor + f_juros) - f_desc) As ""total"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 " & _
        "LEFT JOIN cadp001 cad ON cad.p_cod = f_portad WHERE f_dtpaga = '" & mData & "' AND (f_sit <> 'E' OR f_sitanterior = 'L')"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            mCodCliente = dr(0).ToString
            mNomeCliente = dr(1).ToString
            mFatura = dr(2).ToString
            mFaturaLetra = dr(3).ToString
            mDtEmiss = Format(Convert.ChangeType(dr(4), GetType(Date)), "dd/MM/yyyy")
            mDtVencimento = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            mDescrPagto = dr(6).ToString
            mPosiParcela = returnNumPosicaoLetraAlfab(mFaturaLetra)

            mDiasAtrazo = dataDia.Subtract(Convert.ChangeType(mDtVencimento, GetType(Date))).Days


            Try
                mValor = dr(7)
                mSomaValorDupliNorm += mValor
            Catch ex As Exception
            End Try

            Try
                mJuros = dr(8)
                mSomaJurosNorm += mJuros
            Catch ex As Exception
            End Try

            Try
                mTotal = Round(dr(9), 2)
                mSomaTotalDuplic += mTotal
                mSomaTotalReceitas += mTotal
            Catch ex As Exception
            End Try


            mParcelas = "00"


            '| Codigo |       Cliente      | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo |
            '|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|
            '|00001904987303|VERA LUCIA ALV|31802/02   |11/09/2013|11/11/2013|02|11| 140|    43,60|    0,40|     44,00|        |        |         |
            mStrLinha = "| " & mCodCliente & " | " & Exibe_StrEsquerda(mNomeCliente, 18) & " |"
            mStrLinha += Exibe_StrEsquerda(mFatura, 10) & " |" & mDtEmiss & "|" & mDtVencimento & "|"
            mStrLinha += Format(mPosiParcela, "00") & "|" & mParcelas & "|" & Exibe_StrDireita(mDiasAtrazo, 4) & "|"
            mStrLinha += Exibe_StrDireita(Format(mValor, "##,##0.00"), 9) & "|"
            mStrLinha += Exibe_StrDireita(Format(mJuros, "#,##0.00"), 8) & "|"
            mStrLinha += Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10)
            mStrLinha += "|        |        |         |"

            mValor = 0.0 : mJuros = 0.0 : mTotal = 0.0 : mDiasAtrazo = 0
        End While
        dr.Close()



        'Duplicatas de recebimento Parciais...
        _mConsulta = "SELECT f_portad, cad.p_portad, f_duplic, Substr(f_duplic, Length(f_duplic)), f_emiss, f_vencto, '', " & _
        "f_valor, f_juros, ((f_valor + f_juros) - f_desc) As ""total"" FROM " & MdlEmpresaUsu._esqEstab & ".fatdp02 " & _
        "LEFT JOIN cadp001 cad ON cad.p_cod = f_portad WHERE f_dtpaga = '" & mData & "'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            mCodCliente = dr(0).ToString
            mNomeCliente = dr(1).ToString
            mFatura = dr(2).ToString
            mFaturaLetra = dr(3).ToString
            mDtEmiss = Format(Convert.ChangeType(dr(4), GetType(Date)), "dd/MM/yyyy")
            mDtVencimento = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            mDescrPagto = dr(6).ToString
            mPosiParcela = returnNumPosicaoLetraAlfab(mFaturaLetra)

            mDiasAtrazo = dataDia.Subtract(Convert.ChangeType(mDtVencimento, GetType(Date))).Days


            Try
                mValor = dr(7)
                mSomaValorDupliParc += mValor
            Catch ex As Exception
            End Try

            Try
                mJuros = dr(8)
                mSomaJurosParc += mJuros
            Catch ex As Exception
            End Try

            Try
                mTotal = Round(dr(9), 2)
                mSomaTotalDuplic += mTotal
                mSomaTotalReceitas += mTotal
            Catch ex As Exception
            End Try


            mParcelas = "0s0"

            '| Codigo |       Cliente      | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo |
            '|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|
            '|00001904987303|VERA LUCIA ALV|31802/02   |11/09/2013|11/11/2013|02|11| 140|    43,60|    0,40|     44,00|        |        |         |
            mStrLinha = "| " & mCodCliente & " | " & Exibe_StrEsquerda(mNomeCliente, 18) & " |"
            mStrLinha += Exibe_StrEsquerda(mFatura & "*", 11) & "|" & mDtEmiss & "|" & mDtVencimento & "|"
            mStrLinha += Format(mPosiParcela, "00") & "|" & mParcelas & "|" & Exibe_StrDireita(mDiasAtrazo, 4) & "|"
            mStrLinha += Exibe_StrDireita(Format(mValor, "##,##0.00"), 9) & "|"
            mStrLinha += Exibe_StrDireita(Format(mJuros, "#,##0.00"), 8) & "|"
            mStrLinha += Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10)
            mStrLinha += "|        |        |         |"

            mValor = 0.0 : mJuros = 0.0 : mTotal = 0.0 : mDiasAtrazo = 0
        End While
        dr.Close()





        'Recebimento de Vendas A Vista....
        Dim mAvista As Double = 0.0, mSomaAvista As Double = 0.0


        'Recebimento de Entradas....
        Dim mEntrada As Double = 0.0, mSomaEntrada As Double = 0.0
        Dim mAPrazo As Double = 0.0, mSomaAPrazo As Double = 0.0


        'Pagamento de Duplicatas...
        Dim codCliente, portad, nfat, duplic, nfisc, emiss, vencto, mLetra, numParcelaStr As String
        Dim valor, juros, desc, total, mSomaTotalDespesas As Double
        Dim mNumParcela As Integer
        Dim mStrBDespCred As New StringBuilder
        _mConsulta = "SELECT d_portad, cad.p_portad, d_duplic, Substr(d_duplic, Length(d_duplic)), d_nfisc, d_emiss, d_vencto, d_valor, d_juros, d_desc, " & _
        "((d_valor + d_juros) - d_desc) As ""total"", d_nfat FROM fatp001 LEFT JOIN cadp001 cad ON cad.p_cod = d_portad " & _
        "WHERE d_geno = '" & MdlEmpresaUsu._codigo & "' AND d_dtpaga = '" & mData & "' AND (d_sit <> 'E' OR d_sitanterior = 'L') ORDER BY d_duplic ASC"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            codCliente = dr(0).ToString
            portad = dr(1).ToString
            duplic = dr(2).ToString
            mLetra = dr(3).ToString
            nfisc = dr(4).ToString
            emiss = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            vencto = Format(Convert.ChangeType(dr(6), GetType(Date)), "dd/MM/yyyy")
            mNumParcela = returnNumPosicaoLetraAlfab(mLetra)
            numParcelaStr = Format(mNumParcela, "00")
            nfat = dr(11).ToString
            duplic = nfat & "/" & numParcelaStr

            Try
                total = dr(10)
                mSomaTotalDespesas += total
            Catch ex As Exception
            End Try


            '| Codigo |             Fornecedor              |  Duplicata  | N. Fiscal|  Emissao |Vencimento|  Valor   |
            mStrLinha = "| " & Exibe_StrEsquerda(codCliente, 6) & " | " & Exibe_StrEsquerda(portad, 35) & " |"
            mStrLinha += Exibe_StrDireita(duplic, 12) & " |" & Exibe_StrDireita(nfisc, 9) & " |" & emiss & "|" & vencto & "|"
            mStrLinha += Exibe_StrDireita(Format(total, "###,##0.00"), 10) & "|"


            mStrBDespCred.Append(duplic & "|" & total & "?")

            mValor = 0.0 : mJuros = 0.0 : mTotal = 0.0 : mDiasAtrazo = 0
        End While
        dr.Close()



        'Pagamento Parcial de Duplicatas...
        _mConsulta = "SELECT d_portad, cad.p_portad, d_duplic, Substr(d_duplic, Length(d_duplic)), d_emiss, d_vencto, '', " & _
        "d_valor, d_juros, ((d_valor + d_juros) - d_desc) As ""total"" FROM fatp002 " & _
        "LEFT JOIN cadp001 cad ON cad.p_cod = d_portad WHERE d_geno = '" & MdlEmpresaUsu._codigo & "' AND d_dtpaga = '" & mData & "'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            mCodCliente = dr(0).ToString
            mNomeCliente = dr(1).ToString
            mFatura = dr(2).ToString
            mFaturaLetra = dr(3).ToString
            mDtEmiss = Format(Convert.ChangeType(dr(4), GetType(Date)), "dd/MM/yyyy")
            mDtVencimento = Format(Convert.ChangeType(dr(5), GetType(Date)), "dd/MM/yyyy")
            mDescrPagto = dr(6).ToString
            mPosiParcela = returnNumPosicaoLetraAlfab(mFaturaLetra)

            mDiasAtrazo = dataDia.Subtract(Convert.ChangeType(mDtVencimento, GetType(Date))).Days


            Try
                mValor = dr(7)
                mSomaValorDupliParc += mValor
            Catch ex As Exception
            End Try

            Try
                mJuros = dr(8)
                mSomaJurosParc += mJuros
            Catch ex As Exception
            End Try

            Try
                mTotal = Round(dr(9), 2)
                mSomaTotalDespesas += mTotal
            Catch ex As Exception
            End Try


            '| Codigo |       Cliente      | Documento |  Emissao |Vencimento| N| P|Dias|  Valor  | Juros  |   Total  | Avista |Entrada |  APrazo |
            '|--------+--------------------+-----------+----------+----------+--+--+----+---------+--------+----------+--------+--------+---------|
            '|00001904987303|VERA LUCIA ALV|31802/02   |11/09/2013|11/11/2013|02|11| 140|    43,60|    0,40|     44,00|        |        |         |
            mStrLinha = "| " & mCodCliente & " | " & Exibe_StrEsquerda(mNomeCliente, 18) & " |"
            mStrLinha += Exibe_StrEsquerda(mFatura & "*", 11) & "|" & mDtEmiss & "|" & mDtVencimento & "|"
            mStrLinha += Format(mPosiParcela, "00") & "|" & mParcelas & "|" & Exibe_StrDireita(mDiasAtrazo, 4) & "|"
            mStrLinha += Exibe_StrDireita(Format(mValor, "##,##0.00"), 9) & "|"
            mStrLinha += Exibe_StrDireita(Format(mJuros, "#,##0.00"), 8) & "|"
            mStrLinha += Exibe_StrDireita(Format(mTotal, "###,##0.00"), 10)
            mStrLinha += "|        |        |         |"


            mValor = 0.0 : mJuros = 0.0 : mTotal = 0.0 : mDiasAtrazo = 0
        End While
        dr.Close()



        'Despesas e Creditos do CAIXA...
        Dim sldAnteriorCX As Double

        _mConsulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND cx_data = '" & mData & "' AND cx_tipo = 'A'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                sldAnteriorCX = dr(0)
                mSomaTotalReceitas += sldAnteriorCX
            Catch ex As Exception
                sldAnteriorCX = 0
            End Try


            '|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|ABERTURA      |001|ABERTURA DO CAIXA                              |"
            mStrLinha += Exibe_StrDireita(Format(sldAnteriorCX, "###,##0.00"), 12) & "|             |"

        End While
        dr.Close()

        'Recebimentos lançados manualmente:
        Dim mtotDespManual, mtotRecebManual As Double
        _mConsulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND cx_data = '" & mData & "' AND cx_tipo = 'R'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mtotRecebManual = dr(0)
                mSomaTotalReceitas += mtotRecebManual
            Catch ex As Exception
                mtotRecebManual = 0
            End Try


            '|   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|LANCAMENTO    |500|RECEBIMENTOS DO DIA [Manual]                   |"
            mStrLinha += Exibe_StrDireita(Format(mtotRecebManual, "###,##0.00"), 12) & "|             |"


        End While
        dr.Close()


        'Pagamentos feitos Manualmente
        _mConsulta = "SELECT Sum(cx_valor) FROM " & MdlEmpresaUsu._esqEstab & ".caixadiario WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' " & _
        "AND cx_data = '" & mData & "' AND cx_tipo = 'P'"
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        While dr.Read

            Try
                mtotDespManual = dr(0)
                mSomaTotalDespesas += mtotDespManual
            Catch ex As Exception
                mtotDespManual = 0
            End Try


            '            |   Data   |   Documento  | T |                   Historico                   |  Credito   |  Despesas   |
            mStrLinha = "|" & mData & "|LANCAMENTO    |001|PAGAMENTOS DO DIA [Manual]                     |            |"
            mStrLinha += Exibe_StrDireita(Format(mtotDespManual, "###,##0.00"), 13) & "|"


        End While
        dr.Close()



        mSaldoDoDia = Round(mSomaTotalReceitas - mSomaTotalDespesas, 2)
        Try
            oConnBD.ClearAllPools()
            oConnBD.Close() : oConnBD = Nothing
        Catch ex As Exception
        End Try


        Return mSaldoDoDia
    End Function

    Public Function existeReducaoZ(ByVal data As Date, ByVal idImpressora As Integer, _
                                   ByVal conexao As String) As Boolean

        Dim v_ValorColuna As Boolean = False
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return v_ValorColuna
        End Try

        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT cz_dtemis FROM " & MdlEmpresaUsu._esqEstab & ".cup5zz ")
        sql.Append("WHERE cz_dtemis = @cz_dtemis AND cz_idcdcaixa = @cz_idcdcaixa")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@cz_dtemis", Convert.ChangeType(data, GetType(Date)))
        cmd.Parameters.Add("@cz_idcdcaixa", idImpressora)
        dr = cmd.ExecuteReader

        If dr.HasRows Then v_ValorColuna = True

        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazIdCDCAIXA(ByVal regMAC As String, ByVal conexao As String) As Integer

        Dim v_ValorColuna As Integer
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return v_ValorColuna
        End Try

        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT ec_id FROM cdcaixa WHERE ec_regmac = @ec_regmac")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@ec_regmac", regMAC)
        dr = cmd.ExecuteReader

        While dr.Read

            v_ValorColuna = dr(0)
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function trazValorColunaCdCaixa(ByVal nomeColuna As String, ByVal idCdcaixa As Integer, _
                                            ByVal conexao As String) As String

        Dim v_ValorColuna As String
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return v_ValorColuna

        End Try

        'Traz ESTABELECIMENTO CORRENTE...
        Dim sql As New StringBuilder
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql.Append("SELECT " & nomeColuna & " FROM cdcaixa WHERE ec_id = @ec_id")
        cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
        cmd.Parameters.Add("@ec_id", idCdcaixa)
        dr = cmd.ExecuteReader

        While dr.Read

            Try
                v_ValorColuna = dr(0)
            Catch ex As Exception
            End Try
        End While
        dr.Close() : cmd = Nothing : sql = Nothing : dr = Nothing
        oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing


        Return v_ValorColuna
    End Function

    Public Function IsInteiro(ByVal inteiro As String) As Boolean
        Dim _isInteiro As Boolean = True
        Dim indice As Integer
        Dim comAcentos As String = ".,"

        For indice = 0 To comAcentos.Length - 1

            If InStr(inteiro, comAcentos.Substring(indice, 1)) > 0 Then

                _isInteiro = False
                Exit For
            End If
        Next

        Return _isInteiro
    End Function

    Public Function trazIpServidorBD(ByVal caminhoArqConfigBD As String) As String
        Dim sr As StreamReader = New StreamReader(caminhoArqConfigBD, System.Text.Encoding.Default)
        Dim mIP, mLinha As String
        mIP = "" : mLinha = ""

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            mIP = mLinha '   Por padrão o Endereço IP do Banco DEVE ficar na primeira linha
            Exit Do
        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()

        Return mIP
    End Function

    Public Function trazNomeBancoServidorBD(ByVal caminhoArqConfigBD As String) As String
        Dim sr As StreamReader = New StreamReader(caminhoArqConfigBD, System.Text.Encoding.Default)
        Dim mBanco, mLinha As String
        Dim mContLinha As Integer = 0
        mBanco = "" : mLinha = ""

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            mContLinha += 1
            If mContLinha = 2 Then mBanco = mLinha '   Por padrão o Nome do Banco DEVE ficar na Segunda Linha
        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()

        Return mBanco
    End Function

    Public Function trazNomeCondicoesPgtoRelatorio(ByVal condicao As String) As String

        Select Case condicao
            Case "AV"
                Return "A VISTA"

            Case "NP"
                Return "NOTA PROM."

            Case "CH"
                Return "CHEQUE"

            Case "BL"
                Return "BOLETO"

            Case "CT"
                Return "CARTAO"

            Case "CR"
                Return "CARNE"

        End Select



        Return condicao
    End Function

    Public Function trazIndexUF(ByVal mUF As String, ByVal mCboUF As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboUF.Items.Count - 1

            If mUF.Equals(Trim(mCboUF.Items.Item(index).ToString.Substring(0, 2))) Then

                indiceCfop = index
                Exit For
            End If
        Next


        Return indiceCfop
    End Function

    Public Function trazIndexMUN(ByVal mMUN As String, ByVal mCboMUN As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboMUN.Items.Count - 1

            If mMUN.Equals(Trim(mCboMUN.Items.Item(index).ToString)) Then

                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboVendedor(ByVal mV_codigo As String, ByVal mCboVend As Object) As Integer
        Dim index As Integer : Dim indiceVend As Integer = -1
        For index = 0 To mCboVend.Items.Count - 1

            If mV_codigo.Equals(Trim(mCboVend.Items.Item(index).ToString.Substring(0, 6))) Then
                indiceVend = index
                Exit For
            End If
        Next

        Return indiceVend
    End Function

    Public Function EnderecoMac() As String

        'Dim end_Mac As String = ""
        'Dim mc As System.Management.ManagementClass
        'Dim mo As System.Management.ManagementBaseObject

        'mc = New Management.ManagementClass("Win32_NetworkAdapterConfiguration")
        'Dim moc As Management.ManagementObjectCollection = mc.GetInstances

        Dim mc As New System.Management.ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As System.Management.ManagementObjectCollection = mc.GetInstances()
        Dim end_Mac As String = [String].Empty
        For Each mo As System.Management.ManagementObject In moc

            If end_Mac = [String].Empty Then
                ' only return MAC Address from first card
                If CBool(mo("IPEnabled")) = True Then
                    end_Mac = Replace(mo("MacAddress").ToString(), ":", "-")
                End If
            End If
            mo.Dispose()
        Next


        Return end_Mac

    End Function

    Public Function DiscoLocal() As String

        Dim end_Mac As String = ""
        'Dim mc As Management.ManagementClass
        ''Dim mo As System.Management.ManagementBaseObject
        ''System.Management.
        'mc = New Management.ManagementClass("Win32_LogicalDisk")
        'Dim properties As Management.PropertyDataCollection
        'properties = mc.SystemProperties

        ''Dim moc As Management.ManagementObjectCollection = mc.GetInstances

        'For Each mo As Management.PropertyData In properties

        '    end_Mac += mo.Name & vbNewLine
        'Next


        'Dim fso As Object
        'Dim Drv As Object
        'Dim driveserial As String = ""
        ''Cria um objeto FileSystemObject
        'fso = CreateObject("Scripting.FileSystemObject")

        ''Atribui a letra do drive atual se nada for especificado
        'Drv = fso.GetDrive(fso.GetDriveName())

        'With Drv
        '    If .IsReady Then
        '        driveserial = Abs(.SerialNumber)
        '    Else '"Drive não esta pronto!"
        '        driveserial = -1
        '    End If
        'End With

        ''libera objetos
        'Drv = Nothing
        'fso = Nothing

        'end_Mac = driveserial


        Return end_Mac

    End Function

    Public Function trazIndexCboTipoVendedor(ByVal mV_tipo As String, ByVal mCboVend As Object) As Integer
        Dim index As Integer : Dim indiceVend As Integer = -1
        For index = 0 To mCboVend.Items.Count - 1

            If mV_tipo.Equals(Trim(mCboVend.Items.Item(index).ToString.Substring(0, 1))) Then
                indiceVend = index
                Exit For
            End If
        Next

        Return indiceVend
    End Function

    Public Function trazIndexCboDispositivoVendedor(ByVal mV_tipo As String, ByVal mCboVend As Object) As Integer
        Dim index As Integer : Dim indiceVend As Integer = -1
        For index = 0 To mCboVend.Items.Count - 1

            If mV_tipo.Equals(Trim(mCboVend.Items.Item(index).ToString.Substring(0, 1))) Then
                indiceVend = index
                Exit For
            End If
        Next

        Return indiceVend
    End Function

    Public Function trazIndexCboTipComodato(ByVal mCodTipo As String, ByVal mCboTipComodato As Object) As Integer
        Dim index As Integer : Dim indiceVend As Integer = -1
        For index = 0 To mCboTipComodato.Items.Count - 1

            If mCodTipo.Equals(Trim(mCboTipComodato.Items.Item(index).ToString.Substring(0, 2))) Then
                indiceVend = index
                Exit For
            End If
        Next

        Return indiceVend
    End Function

    Public Function trazIndexCboUND(ByVal mUND As String, ByVal mCboUND As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboUND.Items.Count - 1

            If mUND.Equals(Trim(mCboUND.Items.Item(index).ToString.Substring(0, 4))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboGRUPO(ByVal mGRUPO As String, ByVal mCboGRUPO As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboGRUPO.Items.Count - 1

            If mGRUPO.Equals(Trim(mCboGRUPO.Items.Item(index).ToString.Substring(0, 2))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboOrigem(ByVal mOrigen As String, ByVal mCboOrigen As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboOrigen.Items.Count - 1

            If mOrigen.Equals(Trim(mCboOrigen.Items.Item(index).ToString.Substring(0, 1))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexComboBox(ByVal mBusca As String, ByVal qtdCaracteres As Int16, ByVal mComboBox As Object) As Integer
        Dim index As Integer : Dim indice As Integer = -1

        For index = 0 To mComboBox.Items.Count - 1

            If Trim(mBusca).Equals(Trim(Mid(mComboBox.Items.Item(index).ToString, 1, qtdCaracteres))) Then
                indice = index
                Exit For
            End If

        Next

        Return indice
    End Function

    Public Function trazIndexCboTipoProd(ByVal mTipo As String, ByVal mCboTIPO As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboTIPO.Items.Count - 1

            If mTipo.Equals(Trim(mCboTIPO.Items.Item(index).ToString.Substring(0, 2))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboCST(ByVal mCST As String, ByVal mCboCST As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1

        Try
            mCST = Format(CInt(mCST), "00")
        Catch ex As Exception
        End Try

        For index = 0 To mCboCST.Items.Count - 1

            Try
                If mCST.Equals(Trim(mCboCST.Items.Item(index).ToString.Substring(0, 2)).ToString) Then

                    indiceCfop = index
                    Exit For
                End If
            Catch ex As Exception
            End Try

        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboCFV(ByVal mCFV As String, ByVal mCboCFV As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboCFV.Items.Count - 1

            If mCFV.Equals(Trim(mCboCFV.Items.Item(index).ToString)) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboCRT(ByVal mCRT As String, ByVal mCboCRT As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboCRT.Items.Count - 1

            If mCRT.Equals(Trim(mCboCRT.Items.Item(index).ToString.Substring(0, 1))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboVinculo(ByVal mVinculo As String, ByVal mCboVinculo As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboVinculo.Items.Count - 1

            If mVinculo.Equals(Trim(mCboVinculo.Items.Item(index).ToString.Substring(0, 2))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboEsquema(ByVal mEsquema As String, ByVal mCboVinculo As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboVinculo.Items.Count - 1

            If mEsquema.Equals(Trim(mCboVinculo.Items.Item(index).ToString)) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboLoja2dig(ByVal mloja2Dig As String, ByVal mCboLoja As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboLoja.Items.Count - 1

            If mloja2Dig.Equals(Trim(mCboLoja.Items.Item(index).ToString.Substring(0, 2))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboCargoUsuario(ByVal mCargo As String, ByVal mCboLoja As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboLoja.Items.Count - 1

            If mCargo.Equals(Trim(mCboLoja.Items.Item(index).ToString.Substring(0, 2))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboCaixa(ByVal mCaixa As String, ByVal mCboLoja As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboLoja.Items.Count - 1

            If mCaixa.Equals(Trim(mCboLoja.Items.Item(index).ToString.Substring(0, 3))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboLoja5dig(ByVal mloja As String, ByVal mCboLoja As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboLoja.Items.Count - 1

            If mloja.Equals(Trim(mCboLoja.Items.Item(index).ToString.Substring(0, 6))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboCoresGrade(ByVal mCodCor As String, ByVal mCboCoresGrade As Object) As Integer
        Dim index As Integer : Dim indiceCor As Integer = -1
        For index = 0 To mCboCoresGrade.Items.Count - 1

            If mCodCor.Equals(Trim(mCboCoresGrade.Items.Item(index).ToString.Substring(0, 2))) Then
                indiceCor = index
                Exit For
            End If
        Next

        Return indiceCor
    End Function

    Public Function trazNomeCorCboCoresGrade(ByVal mCodCor As String, ByVal mCboCoresGrade As Object) As String
        Dim index As Integer : Dim nomeCor As String = ""
        For index = 0 To mCboCoresGrade.Items.Count - 1

            If mCodCor.Equals(Trim(mCboCoresGrade.Items.Item(index).ToString.Substring(0, 2))) Then
                nomeCor = Trim(mCboCoresGrade.Items.Item(index).ToString.Substring(5))
                Exit For
            End If
        Next

        Return nomeCor
    End Function

    Public Function trazIndexCboImpressora(ByVal mTipoImpressora As String, ByVal mCboImpressora As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboImpressora.Items.Count - 1

            If mTipoImpressora.Equals(Trim(mCboImpressora.Items.Item(index).ToString.Substring(0, 1))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboRota(ByVal mRota As String, ByVal mCboRota As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboRota.Items.Count - 1

            If mRota.Equals(Trim(mCboRota.Items.Item(index).ToString)) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboFormPagto(ByVal mFormPagto As String, ByVal mCboFormPagto As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboFormPagto.Items.Count - 1

            If mFormPagto.Equals(Trim(mCboFormPagto.Items.Item(index).ToString)) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboAtivEmpresa(ByVal mAtivEmpresa As String, ByVal mCboAtivEmpresa As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboAtivEmpresa.Items.Count - 1

            If mAtivEmpresa.Equals(Trim(mCboAtivEmpresa.Items.Item(index).ToString.Substring(0, 1))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboBancos(ByVal mBanco As String, ByVal mCboBanco As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboBanco.Items.Count - 1

            If mBanco.Equals(Trim(mCboBanco.Items.Item(index).ToString.Substring(0, 3))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexCboBlOptPadrao(ByVal mBlOptPadrao As String, ByVal mCboBlOptPadrao As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboBlOptPadrao.Items.Count - 1

            If mBlOptPadrao.Equals(Trim(mCboBlOptPadrao.Items.Item(index).ToString.Substring(0, 1))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function tratamentoCfopItemSaidas(ByVal mCFV As Integer, ByVal CfopNota As String, ByVal mIdSubst As Integer) As String

        CfopNota = CfopNota.Replace(".", "")
        Dim digitoCfop As String = Mid(CfopNota, 1, 1)
        Dim mCfopRetorno As String = ""

        Select Case mCFV 'Situação do Produto: 1 - Tributado; 3 - Imposto Pago; 4 - Isento
            Case 1 'Tributado ........
                mCfopRetorno = Mid(CfopNota, 1, 1) & Mid(CfopNota, 2, 3)

            Case 3 'Imposto Pago .......

                mCfopRetorno = Mid(CfopNota, 1, 1) & Mid(CfopNota, 2, 3)
                Select Case digitoCfop
                    Case "5" 'Dentro

                        Select Case CfopNota
                            Case "5102" 'Venda de Mercadoria
                                mCfopRetorno = "5405"

                            Case "5202" 'Devolucao de Venda
                                mCfopRetorno = "5411"

                            Case "5152" 'Transferencia
                                mCfopRetorno = "5409"

                        End Select

                    Case "6" 'Fora

                        Select Case CfopNota
                            Case "6102" 'Venda de Mercadoria
                                mCfopRetorno = "6404"

                            Case "6202" 'Devolucao de Venda
                                mCfopRetorno = "6411"

                            Case "6152" 'Transferencia
                                mCfopRetorno = "6409"


                        End Select

                End Select


            Case 4 'Isento ......
                mCfopRetorno = Mid(CfopNota, 1, 1) & Mid(CfopNota, 2, 3)

        End Select


        Return mCfopRetorno
    End Function

    Public Function tratamentoCfopItemEntradas(ByVal CfopNota As String, ByVal cst As String) As String

        CfopNota = CfopNota.Replace(".", "")
        Dim digitoCfop As String = Mid(CfopNota, 1, 1)
        Dim mCfopRetorno As String = Mid(CfopNota, 1, 1) & Mid(CfopNota, 2, 3)

        Select Case cst 'Situação do Produto: 1 - Tributado; 3 - Imposto Pago; 4 - Isento
            Case "00" 'Tributado ........
                mCfopRetorno = Mid(CfopNota, 1, 1) & Mid(CfopNota, 2, 3)

            Case "60" 'Imposto Pago .......

                mCfopRetorno = Mid(CfopNota, 1, 1) & Mid(CfopNota, 2, 3)
                Select Case digitoCfop
                    Case "1" 'Dentro

                        Select Case CfopNota
                            Case "1102" 'Venda de Mercadoria
                                mCfopRetorno = "1405"

                            Case "1202" 'Devolucao de Venda
                                mCfopRetorno = "1411"

                            Case "1152" 'Transferencia
                                mCfopRetorno = "1409"

                        End Select

                    Case "2" 'Fora

                        Select Case CfopNota
                            Case "2102" 'Venda de Mercadoria
                                mCfopRetorno = "2404"

                            Case "2202" 'Devolucao de Venda
                                mCfopRetorno = "2411"

                            Case "2152" 'Transferencia
                                mCfopRetorno = "2409"


                        End Select

                End Select


            Case "40" 'Isento ......
                mCfopRetorno = Mid(CfopNota, 1, 1) & Mid(CfopNota, 2, 3)

        End Select


        Return mCfopRetorno
    End Function

    Public Function tratamentoCfopItemSaidas(ByVal CfopNota As String, ByVal cst As String) As String

        CfopNota = CfopNota.Replace(".", "")
        Dim digitoCfop As String = Mid(CfopNota, 1, 1)
        Dim mCfopRetorno As String = Mid(CfopNota, 1, 1) & Mid(CfopNota, 2, 3)

        Select Case cst 'Situação do Produto: 1 - Tributado; 3 - Imposto Pago; 4 - Isento
            Case "00" 'Tributado ........
                mCfopRetorno = Mid(CfopNota, 1, 1) & Mid(CfopNota, 2, 3)

            Case "60" 'Imposto Pago .......

                mCfopRetorno = Mid(CfopNota, 1, 1) & Mid(CfopNota, 2, 3)
                Select Case digitoCfop
                    Case "5" 'Dentro

                        Select Case CfopNota
                            Case "5102" 'Venda de Mercadoria
                                mCfopRetorno = "5405"

                            Case "5202" 'Devolucao de Venda
                                mCfopRetorno = "5411"

                            Case "5152" 'Transferencia
                                mCfopRetorno = "5409"

                        End Select

                    Case "6" 'Fora

                        Select Case CfopNota
                            Case "6102" 'Venda de Mercadoria
                                mCfopRetorno = "6404"

                            Case "6202" 'Devolucao de Venda
                                mCfopRetorno = "6411"

                            Case "6152" 'Transferencia
                                mCfopRetorno = "6409"


                        End Select

                End Select


            Case "40" 'Isento ......
                mCfopRetorno = Mid(CfopNota, 1, 1) & Mid(CfopNota, 2, 3)

        End Select


        Return mCfopRetorno
    End Function

    Public Function trazIndexCboCondPagto(ByVal mCondPagto As String, ByVal mCboCondPagto As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboCondPagto.Items.Count - 1

            If mCondPagto.Equals(Trim(mCboCondPagto.Items.Item(index).ToString)) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Sub AlteraConfigBD(ByVal caminhoArqConfigBD As String, ByVal IP As String, ByVal nomeBD As String)
        Dim fs As New FileStream(caminhoArqConfigBD, FileMode.Truncate, FileAccess.ReadWrite)
        Dim sr As New StreamWriter(fs)
        sr.WriteLine(IP & vbNewLine & nomeBD)
        sr.Close()
    End Sub

    Public Function trazSincronizaBD(ByVal mac As String, ByVal conexao As String) As Boolean

        Dim sincroniza As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        Dim sql As String = ""
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql = "SELECT s_sincroniza FROM sincronizacao WHERE s_mac = '" & mac & "'"
        cmd = New NpgsqlCommand(sql, oConn)
        Try
            dr = cmd.ExecuteReader

            If dr.HasRows Then

                While dr.Read
                    sincroniza = dr(0)
                End While
                dr.Close()

            Else
                dr.Close()

                sql = "INSERT INTO sincronizacao VALUES (DEFAULT, '" & mac & "', True)"
                cmd = New NpgsqlCommand(sql, oConn)
                Try
                    cmd.ExecuteNonQuery()
                    sincroniza = True
                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                    sincroniza = False
                End Try


            End If
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        End Try

        cmd = Nothing : sql = Nothing : dr = Nothing

        oConn.Close() : oConn = Nothing


        Return sincroniza
    End Function

    Public Sub atualizaSincronizacaoBD(ByVal sincroniza As Boolean, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return
        End Try

        Dim sql As String = ""
        Dim cmd As NpgsqlCommand

        sql = "UPDATE sincronizacao SET s_sincroniza = " & sincroniza
        cmd = New NpgsqlCommand(sql, oConn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        cmd = Nothing : sql = Nothing
        oConn.Close() : oConn = Nothing


    End Sub

    Public Sub atualizaSincronizacaoGenp001(ByVal sincroniza As Boolean, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return
        End Try

        Dim sql As String = ""
        Dim cmd As NpgsqlCommand

        sql = "UPDATE genp001 SET gp_sincroniza = " & sincroniza & " WHERE gp_geno = '" & MdlEmpresaUsu._codigo & "'"
        cmd = New NpgsqlCommand(sql, oConn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        cmd = Nothing : sql = Nothing
        oConn.Close() : oConn = Nothing


    End Sub

    Public Function existPart_Tabela(ByVal participante As String, ByVal conexao As String) As Boolean

        Dim oConnMunicipios As NpgsqlConnection = New NpgsqlConnection(conexao)
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

            Try
                SqlCmdMunicipios.Append("SELECT * FROM cadp001 WHERE p_cod = '" & participante & "' LIMIT 1")
                CmdMunicipios = New NpgsqlCommand(SqlCmdMunicipios.ToString, oConnMunicipios)
                drMunicipios = CmdMunicipios.ExecuteReader

                If drMunicipios.HasRows = False Then
                    _erro = True
                End If
                drMunicipios.Close()
            Catch ex As Exception
                Me._erro = True
                Me._msgErro = "Tabela de Clientes Inexistente!"
            End Try

            oConnMunicipios.ClearAllPools() : oConnMunicipios.Close()
            CmdMunicipios = Nothing : SqlCmdMunicipios = Nothing : drMunicipios = Nothing
        End If

        oConnMunicipios = Nothing
        If _erro = False Then
            _erro = Nothing
            _msgErro = Nothing
            Return True
        Else
            _erro = Nothing
            _msgErro = Nothing
            Return False
        End If

    End Function

    Public Function existCnpjCadp001(ByVal cnpj As String, ByVal conexao As String) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Dim mExiste As Boolean = False

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        Dim Cmd As New NpgsqlCommand
        Dim Sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            Sql.Append("SELECT * FROM cadp001 WHERE p_cgc <> '' AND p_cgc = '" & cnpj & "' LIMIT 1")

            Cmd = New NpgsqlCommand(Sql.ToString, oConn)
            dr = Cmd.ExecuteReader
            If dr.HasRows Then mExiste = True

            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        oConn.ClearAllPools() : oConn.Close() : Cmd = Nothing : Sql = Nothing : dr = Nothing
        oConn = Nothing


        Return mExiste
    End Function

    Public Function existCnpjCadp001(ByVal cnpj As String, ByVal codParticipante As String, ByVal conexao As String) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Dim mExiste As Boolean = False

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        Dim Cmd As New NpgsqlCommand
        Dim Sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            Sql.Append("SELECT * FROM cadp001 WHERE p_cod <> '" & codParticipante & "' AND p_cgc <> '' AND p_cgc = '" & cnpj & "' LIMIT 1")

            Cmd = New NpgsqlCommand(Sql.ToString, oConn)
            dr = Cmd.ExecuteReader
            If dr.HasRows Then mExiste = True

            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        oConn.ClearAllPools() : oConn.Close() : Cmd = Nothing : Sql = Nothing : dr = Nothing
        oConn = Nothing


        Return mExiste
    End Function

    Public Function existCpfCadp001(ByVal cpf As String, ByVal conexao As String) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Dim mExiste As Boolean = False

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        Dim Cmd As New NpgsqlCommand
        Dim Sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            Sql.Append("SELECT * FROM cadp001 WHERE p_cpf <> '' AND p_cpf = '" & cpf & "' LIMIT 1")

            Cmd = New NpgsqlCommand(Sql.ToString, oConn)
            dr = Cmd.ExecuteReader
            If dr.HasRows Then mExiste = True

            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        oConn.ClearAllPools() : oConn.Close() : Cmd = Nothing : Sql = Nothing : dr = Nothing
        oConn = Nothing


        Return mExiste

    End Function

    Public Function existCpfCadp001(ByVal cpf As String, ByVal codParticipante As String, ByVal conexao As String) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Dim mExiste As Boolean = False

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        Dim Cmd As New NpgsqlCommand
        Dim Sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            Sql.Append("SELECT * FROM cadp001 WHERE p_cod <> '" & codParticipante & "' AND p_cpf <> '' AND p_cpf = '" & cpf & "' LIMIT 1")

            Cmd = New NpgsqlCommand(Sql.ToString, oConn)
            dr = Cmd.ExecuteReader
            If dr.HasRows Then mExiste = True

            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        oConn.ClearAllPools() : oConn.Close() : Cmd = Nothing : Sql = Nothing : dr = Nothing
        oConn = Nothing


        Return mExiste
    End Function

    Public Function existFichaCadp001(ByVal ficha As String, ByVal conexao As String) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Dim mExiste As Boolean = False

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        Dim Cmd As New NpgsqlCommand
        Dim Sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            Sql.Append("SELECT * FROM cadp001 WHERE p_ficha <> '' AND p_ficha = '" & ficha & "' LIMIT 1")

            Cmd = New NpgsqlCommand(Sql.ToString, oConn)
            dr = Cmd.ExecuteReader
            If dr.HasRows Then mExiste = True

            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        oConn.ClearAllPools() : oConn.Close() : Cmd = Nothing : Sql = Nothing : dr = Nothing
        oConn = Nothing


        Return mExiste

    End Function

    Public Function existFichaCadp001(ByVal ficha As String, ByVal codParticipante As String, ByVal conexao As String) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Dim mExiste As Boolean = False

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        Dim Cmd As New NpgsqlCommand
        Dim Sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            Sql.Append("SELECT * FROM cadp001 WHERE p_cod <> '" & codParticipante & "' AND p_ficha <> '' AND p_ficha = '" & ficha & "' LIMIT 1")

            Cmd = New NpgsqlCommand(Sql.ToString, oConn)
            dr = Cmd.ExecuteReader
            If dr.HasRows Then mExiste = True

            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        oConn.ClearAllPools() : oConn.Close() : Cmd = Nothing : Sql = Nothing : dr = Nothing
        oConn = Nothing


        Return mExiste
    End Function


    Public Function existInscricaoCadp001(ByVal inscricao As String, ByVal conexao As String) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Dim mExiste As Boolean = False

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        Dim Cmd As New NpgsqlCommand
        Dim Sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            Sql.Append("SELECT * FROM cadp001 WHERE p_insc <> '' AND p_insc = '" & inscricao & "' LIMIT 1")

            Cmd = New NpgsqlCommand(Sql.ToString, oConn)
            dr = Cmd.ExecuteReader
            If dr.HasRows Then mExiste = True

            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        oConn.ClearAllPools() : oConn.Close() : Cmd = Nothing : Sql = Nothing : dr = Nothing
        oConn = Nothing


        Return mExiste
    End Function

    Public Function existIdentidadeCadp001(ByVal identidade As String, ByVal conexao As String) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Dim mExiste As Boolean = False

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        Dim Cmd As New NpgsqlCommand
        Dim Sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            Sql.Append("SELECT * FROM cadp001 WHERE p_ident <> '' AND p_ident = '" & identidade & "' LIMIT 1")

            Cmd = New NpgsqlCommand(Sql.ToString, oConn)
            dr = Cmd.ExecuteReader
            If dr.HasRows Then mExiste = True

            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return True
        End Try

        oConn.ClearAllPools() : oConn.Close() : Cmd = Nothing : Sql = Nothing : dr = Nothing
        oConn = Nothing


        Return mExiste
    End Function

    Public Function existCaixaNaLoja(ByVal codLoja As String, ByVal conexao As String) As Boolean

        Dim mexiste As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT * FROM caixa WHERE cx_loja = @cx_loja")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@cx_loja", codLoja)
            dr = Cmd.ExecuteReader

            If dr.HasRows Then mexiste = True

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : mexiste = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return mexiste
    End Function

    Public Function existNumPedido(ByVal numpedido As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As Boolean

        Dim mexiste As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT nt_orca FROM " & esquemaEstab & ".orca1pp WHERE nt_orca = @nt_orca")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@nt_orca", numpedido)
            dr = Cmd.ExecuteReader

            If dr.HasRows Then mexiste = True

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : mexiste = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return mexiste
    End Function

    Public Function existNumCarne(ByVal numpedido As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As Boolean

        Dim mexiste As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT f_duplic FROM " & esquemaEstab & ".fatd001 WHERE f_duplic = @f_duplic AND f_tipo = 'CR'")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@f_duplic", numpedido)
            dr = Cmd.ExecuteReader

            If dr.HasRows Then mexiste = True

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : mexiste = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return mexiste
    End Function

    Public Function existNumNotaPromissoria(ByVal numpedido As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As Boolean

        Dim mexiste As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT f_duplic FROM " & esquemaEstab & ".fatd001 WHERE f_duplic = @f_duplic AND f_tipo = 'NP'")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@f_duplic", numpedido)
            dr = Cmd.ExecuteReader

            If dr.HasRows Then mexiste = True

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : mexiste = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return mexiste
    End Function

    Public Function existPedidoNota1pp(ByVal numpedido As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As Boolean

        Dim mexiste As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT nt_orca FROM " & esquemaEstab & ".nota1pp WHERE nt_orca = @nt_orca")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@nt_orca", numpedido)
            dr = Cmd.ExecuteReader

            If dr.HasRows Then mexiste = True

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : mexiste = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return mexiste
    End Function

    Public Function existMapaOrca1pp(ByVal numMapa As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As Boolean

        Dim mexiste As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT nt_mapa FROM " & esquemaEstab & ".orca1pp WHERE nt_mapa = @nt_mapa LIMIT 1")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@nt_mapa", numMapa)
            dr = Cmd.ExecuteReader

            If dr.HasRows Then mexiste = True

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : mexiste = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return mexiste
    End Function

    Public Function existMapaNota1pp(ByVal numMapa As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As Boolean

        Dim mexiste As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT nt_mapa FROM " & esquemaEstab & ".nota1pp WHERE nt_mapa = @nt_mapa LIMIT 1")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@nt_mapa", numMapa)
            dr = Cmd.ExecuteReader

            If dr.HasRows Then mexiste = True

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : mexiste = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return mexiste
    End Function

    Public Function existNota1ppMapaOrca(ByVal numMapa As Int64, ByVal numOrca As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As Boolean

        Dim mexiste As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT nt_mapa FROM " & esquemaEstab & ".nota1pp WHERE nt_mapa = @nt_mapa AND nt_orca = @nt_orca LIMIT 1")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@nt_mapa", numMapa)
            Cmd.Parameters.Add("@nt_orca", numOrca)
            dr = Cmd.ExecuteReader

            If dr.HasRows Then mexiste = True

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : mexiste = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return mexiste
    End Function

    Public Function erroMapaOrcaNota1pp(ByVal numMapa As Int64, ByVal numOrca As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As Boolean

        Dim erro As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT nt_loteerro FROM " & esquemaEstab & ".nota1pp WHERE nt_mapa = @nt_mapa AND nt_orca = @nt_orca LIMIT 1")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@nt_mapa", numMapa)
            Cmd.Parameters.Add("@nt_orca", numOrca)
            dr = Cmd.ExecuteReader


            While dr.Read
                erro = dr(0)
            End While

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : erro = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return erro
    End Function

    Public Function trazNt_numeNota1ppMapaOrca(ByVal numMapa As Int64, ByVal numOrca As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As String

        Dim numer As String = ""
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT nt_nume FROM " & esquemaEstab & ".nota1pp WHERE nt_mapa = @nt_mapa AND nt_orca = @nt_orca LIMIT 1")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@nt_mapa", numMapa)
            Cmd.Parameters.Add("@nt_orca", numOrca)
            dr = Cmd.ExecuteReader


            While dr.Read
                numer = dr(0).ToString
            End While

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : numer = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return numer
    End Function

    Public Function trazNt_chaveNota1ppMapaOrca(ByVal numMapa As Int64, ByVal numOrca As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As String

        Dim numer As String = ""
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT nt_chave FROM " & esquemaEstab & ".nota1pp WHERE nt_mapa = @nt_mapa AND nt_orca = @nt_orca LIMIT 1")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@nt_mapa", numMapa)
            Cmd.Parameters.Add("@nt_orca", numOrca)
            dr = Cmd.ExecuteReader


            While dr.Read
                numer = dr(0).ToString
            End While

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : numer = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return numer
    End Function

    Public Function existNFeNota4ff(ByVal numero As String, ByVal cdport As String, _
                                    ByVal esquemaEstab As String, ByVal conexao As String) As Boolean

        Dim mexiste As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT n4_numer FROM " & esquemaEstab & ".nota4ff WHERE n4_numer = @n4_numer AND n4_cdport = @n4_cdport")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@n4_numer", numero)
            Cmd.Parameters.Add("@n4_cdport", cdport)
            dr = Cmd.ExecuteReader

            If dr.HasRows Then mexiste = True

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : mexiste = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return mexiste
    End Function

    Public Function trazValorColunaOrca1pp(ByVal numOrca As String, ByVal nomeColuna As String, _
                                           ByVal esquemaEstab As String, ByVal conexao As String) As String

        Dim valor As String = ""
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return valor
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT " & nomeColuna & " FROM " & esquemaEstab & ".orca1pp WHERE nt_orca = @nt_orca")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@nt_orca", numOrca)
            dr = Cmd.ExecuteReader

            While dr.Read
                valor = dr(0).ToString
            End While

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : valor = ""

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return valor
    End Function

    Public Function trazCodPagamentoNFe(ByVal tipoPagamento As String, ByVal natureza As String) As String

        Select Case natureza

            Case "51" OrElse "5"

            Case "5102"

                Select Case tipoPagamento
                    Case "AV"
                        Return "0"
                    Case "NP"
                        Return "1"
                    Case "BL"
                        Return "0"
                    Case Else
                        Return ""
                End Select

        End Select


    End Function

    Public Function trazNumNota1ppPorPedido(ByVal numpedido As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As String

        Dim numero As String = ""
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return numero
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT nt_nume FROM " & esquemaEstab & ".nota1pp WHERE nt_orca = @nt_orca")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@nt_orca", numpedido)
            dr = Cmd.ExecuteReader

            While dr.Read
                numero = dr(0).ToString
            End While

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : numero = ""

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return numero
    End Function

    Public Function trazCodPartNota1ppPorPedido(ByVal numpedido As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As String

        Dim codPart As String = ""
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return codPart
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT nt_codig FROM " & esquemaEstab & ".nota1pp WHERE nt_orca = @nt_orca")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@nt_orca", numpedido)
            dr = Cmd.ExecuteReader

            While dr.Read
                codPart = dr(0).ToString
            End While

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : codPart = ""

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return codPart
    End Function

    Public Function trazCodPartCadp001(ByVal valor As String, ByVal coluna As String, ByVal conexao As String) As String

        Dim codPart As String = ""
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return codPart
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT p_cod FROM Cadp001 WHERE " & coluna & " = @valor")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@valor", valor)
            dr = Cmd.ExecuteReader

            While dr.Read
                codPart = dr(0).ToString
            End While

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : codPart = ""

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return codPart
    End Function

    Public Function existItemOrca2ccLoja(ByVal numpedido As String, ByVal esquemaEstab As String, _
                                   ByVal conexao As String) As Boolean

        Dim mexiste As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return False
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT no_orca FROM " & esquemaEstab & ".orca2cc WHERE no_orca = @no_orca LIMIT 1")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@no_orca", numpedido)
            dr = Cmd.ExecuteReader

            If dr.HasRows Then mexiste = True

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : mexiste = False

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return mexiste
    End Function

    Public Function trazSituacaoPedido(ByVal numpedido As String, ByVal local As String, _
                                   ByVal conexao As String) As Integer

        Dim msituacao As Integer = 0
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            oConn = Nothing : Return 0
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT nt_sit FROM " & local & ".orca1pp WHERE nt_orca = @nt_orca")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            Cmd.Parameters.Add("@nt_orca", numpedido)
            dr = Cmd.ExecuteReader

            While dr.Read

                msituacao = dr(0)
            End While

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : msituacao = 0

        End Try

        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing
        oConn = Nothing



        Return msituacao
    End Function

    Public Function existCFOP_Tabela(ByVal cfop As String, ByVal conexao As String) As Boolean
        Dim oConnMunicipios As NpgsqlConnection = New NpgsqlConnection(conexao)
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

            Try
                SqlCmdMunicipios.Append("SELECT * FROM cadnatu WHERE r_cdfis = '" & cfop.Substring(0, 1) & "." & cfop.Substring(1, 3) & "' LIMIT 1")
                CmdMunicipios = New NpgsqlCommand(SqlCmdMunicipios.ToString, oConnMunicipios)
                drMunicipios = CmdMunicipios.ExecuteReader

                If drMunicipios.HasRows = False Then _erro = True

            Catch ex As Exception
                Me._erro = True
                Me._msgErro = "Tabela de CFOP Inexistente!"
            End Try

            oConnMunicipios.ClearAllPools() : oConnMunicipios.Close()
            CmdMunicipios = Nothing : SqlCmdMunicipios = Nothing : drMunicipios = Nothing
        End If

        oConnMunicipios = Nothing
        If _erro = False Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function trazServicoSelecionado(ByVal id As Int64, ByRef servico As Cl_Servico) As Boolean

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection p/ Buscar SERVIÇO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            oConn.ClearAllPools() : oConn = Nothing : Return False

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader


        Try

            sql.Append("SELECT s_id, s_descricao, s_valor FROM servico WHERE s_id = @s_id")
            cmd = New NpgsqlCommand(sql.ToString, oConn)
            cmd.Parameters.Add("@s_id", id)

            dr = cmd.ExecuteReader

            While dr.Read

                servico.pIdServico = dr(0)
                servico.pDescricao = dr(1).ToString
                servico.pValor = dr(2)

            End While


            dr.Close() : oConn.Close()
        Catch ex As Exception

            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
            servico.zeraValores() : Return False
        End Try

        cmd.CommandText = "" : sql.Remove(0, sql.ToString.Length)
        oConn = Nothing : cmd = Nothing : dr = Nothing : sql = Nothing



        Return True

    End Function

    Public Function trazGenoSelecionado(ByVal codGeno As String, ByRef geno001 As Cl_Geno) As Boolean

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection p/ Buscar Geno001:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearAllPools() : conection = Nothing : Return False

        End Try

        Dim cmdGeno As New NpgsqlCommand
        Dim sqlGeno As New StringBuilder
        Dim drGeno As NpgsqlDataReader


        Try

            '          SELECT g_codig, g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, 
            '     g_insc, g_fone, g_fax, g_mun, g_coduf, g_email, g_razaosocial, 
            '     g_bairro, g_aidf, g_iniform, g_fimform, g_codmun, g_loja, g_cnae, 
            '     g_crt, g_vinculo, g_id, g_esquemaestab, g_esquemavinc, g_retencao, 
            '     g_pis, g_cofins, g_csll, g_irenda, g_sn, g_ativempresa, g_bl_bancopadrao, 
            '     g_bl_optpadrao
            'FROM geno001;
            sqlGeno.Append("SELECT g_codig, g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, ") '7
            sqlGeno.Append("g_insc, g_fone, g_fax, g_mun, g_coduf, g_email, g_razaosocial, ") '14
            sqlGeno.Append("g_loja, g_cnae, g_crt, g_vinculo, g_esquemaestab, g_esquemavinc, g_retencao, ") '21
            sqlGeno.Append("g_pis, g_cofins, g_csll, g_irenda, g_sn, g_ativempresa, g_bl_bancopadrao, g_bl_optpadrao ") '29
            sqlGeno.Append("FROM geno001 WHERE g_codig = '" & codGeno & "'") '24

            cmdGeno = New NpgsqlCommand(sqlGeno.ToString, conection)
            drGeno = cmdGeno.ExecuteReader

            While drGeno.Read

                geno001.pCodig = drGeno(0).ToString : geno001.pGeno = drGeno(1).ToString
                geno001.pEnder = drGeno(2).ToString : geno001.pCid = drGeno(3).ToString
                geno001.pUf = drGeno(4).ToString : geno001.pCep = drGeno(5).ToString
                geno001.pBair = drGeno(6).ToString : geno001.pCgc = drGeno(7).ToString
                geno001.pInsc = drGeno(8).ToString : geno001.pFone = drGeno(9).ToString
                geno001.pFax = drGeno(10).ToString : geno001.pMun = drGeno(11).ToString
                geno001.pCoduf = drGeno(12).ToString : geno001.pEmail = drGeno(13).ToString
                geno001.pRazaosocial = drGeno(14).ToString : geno001.pRetencao = drGeno(21)
                geno001.pMun = drGeno(11).ToString : geno001.pCnae = drGeno(16).ToString
                geno001.pCrt = drGeno(17).ToString : geno001.pVinculo = drGeno(18).ToString
                geno001.pEsquemaestab = drGeno(19).ToString : geno001.pEsquemavinc = drGeno(20).ToString
                geno001.pPis = drGeno(22) : geno001.pCofins = drGeno(23)
                geno001.pCsll = drGeno(24) : geno001.pIRenda = drGeno(25)
                geno001.pSn = drGeno(26) : geno001.pAtivEmpresa = drGeno(27)
                geno001.pBlBancoPadrao = drGeno(28).ToString : geno001.pBlOptPadrao = drGeno(29)

            End While

            drGeno.Close() : conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
            Return False
        End Try

        cmdGeno.CommandText = "" : sqlGeno.Remove(0, sqlGeno.ToString.Length)
        conection = Nothing : cmdGeno = Nothing : drGeno = Nothing : sqlGeno = Nothing



        Return True
    End Function

    Public Function trazGenpSelecionado(ByVal codGenp As String, ByRef genp001 As Cl_Genp001) As Boolean

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection p/ Buscar Genp001:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearAllPools() : conection = Nothing : Return False

        End Try

        Dim cmdGenp As New NpgsqlCommand
        Dim sqlGenp As New StringBuilder
        Dim drGenp As NpgsqlDataReader


        Try

            sqlGenp.Append("SELECT gp_requis, gp_sai, gp_fat, gp_data, gp_icms, gp_icmse, gp_alqiss, ") '6
            sqlGenp.Append("gp_serv, gp_orca, gp_palm, gp_txreduz, gp_icmred, gp_txcob, gp_txipi, ") '13
            sqlGenp.Append("gp_txga, gp_txesvei, gp_serie, gp_contf, gp_amb, gp_prazo, gp_seqnfe, ") '20
            sqlGenp.Append("gp_mensag, gp_pis, gp_confin, gp_alqsub, gp_carencia, gp_codprod, ") '26
            sqlGenp.Append("gp_codrequis, gp_codmapa, gp_numpedidomp, gp_mapapedido, gp_canc_pedauto, ") '31
            sqlGenp.Append("gp_grade, gp_codreqproc, gp_tipocondpagto, gp_cpfvalidar, gp_tptransfentrada, ") '36
            sqlGenp.Append("gp_tptransfsaida, gp_comisavista, gp_comisaprazo, gp_envioxml, gp_lotxml, ") '41
            sqlGenp.Append("gp_retornoxml, gp_enviadoxml, gp_imagemcarne, gp_sldfiscalnegativo, gp_aplicacao ") '46
            sqlGenp.Append("FROM genp001 WHERE gp_geno = @gp_geno")

            cmdGenp = New NpgsqlCommand(sqlGenp.ToString, conection)
            cmdGenp.Parameters.Add("@gp_geno", codGenp)
            drGenp = cmdGenp.ExecuteReader


            While drGenp.Read

                geno001.zeraValores()
                genp001.pGeno = codGenp
                genp001.pRequis = drGenp(0).ToString : genp001.pSai = drGenp(1).ToString
                genp001.pFat = drGenp(2).ToString
                Try
                    genp001.pData = Convert.ChangeType(drGenp(3), GetType(Date))
                Catch ex As Exception
                    genp001.pData = Nothing
                End Try
                genp001.pIcms = drGenp(4).ToString : genp001.pIcmse = drGenp(5).ToString
                genp001.pAlqiss = drGenp(6).ToString : genp001.pServ = drGenp(7).ToString
                genp001.pOrca = drGenp(8).ToString : genp001.pPalm = drGenp(9).ToString
                genp001.pTxreduz = drGenp(10).ToString : genp001.pIcmred = drGenp(11).ToString
                genp001.pTxcob = drGenp(12).ToString : genp001.pTxipi = drGenp(13).ToString
                genp001.pTxga = drGenp(14).ToString : genp001.pTxesvei = drGenp(15).ToString
                genp001.pSerie = drGenp(16).ToString : genp001.pContf = drGenp(17).ToString
                genp001.pAmb = drGenp(18).ToString : genp001.pPrazo = drGenp(19).ToString
                genp001.pSeqnfe = drGenp(20).ToString : genp001.pMensag = drGenp(21).ToString
                genp001.pPis = drGenp(22).ToString : genp001.pConfin = drGenp(23).ToString
                genp001.pAlqsub = drGenp(24) : genp001.pCarencia = drGenp(25).ToString
                genp001.pCodprod = drGenp(26).ToString : genp001.pCodrequis = drGenp(27).ToString
                genp001.pCodmapa = drGenp(28).ToString : genp001.pNumpedidomp = drGenp(29).ToString
                genp001.pMapapedido = drGenp(30).ToString : genp001.pCanc_pedauto = drGenp(31).ToString
                genp001.pTipocondpagto = drGenp(34).ToString : genp001.pConfirmCPF = drGenp(35)
                genp001.pTptransfentrada = drGenp(36).ToString : genp001.pTptransfsaida = drGenp(37).ToString
                genp001.pComisavista = drGenp(38) : genp001.pComisaprazo = drGenp(39)

                genp001.pathEnvioXML = drGenp(40).ToString
                genp001.pathLotXML = drGenp(41).ToString
                genp001.pathRetornoXML = drGenp(42).ToString
                genp001.pathEnviadoXML = drGenp(43).ToString
                genp001.imagemCarne = drGenp(44).ToString
                genp001.sldfiscalnegativo = drGenp(45)
                genp001.aplicacao = drGenp(46)

            End While


            drGenp.Close() : conection.Close()
        Catch ex As Exception

            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
            geno001.zeraValores() : Return False
        End Try

        cmdGenp.CommandText = "" : sqlGenp.Remove(0, sqlGenp.ToString.Length)
        conection = Nothing : cmdGenp = Nothing : drGenp = Nothing : sqlGenp = Nothing



        Return True
    End Function

    Public Function trazCadp001(ByVal codFornecedor As String, ByRef cadp001 As Cl_Cadp001) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        codFornecedor = codFornecedor.ToUpper

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão p/ Buscar Cliente:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try
            SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc, p_uf, p_end, p_cid, p_cep, p_fone, p_consumo, ") ' 10
            SqlParticipante.Append("p_isento, p_mun, p_coduf, p_carac, p_email, p_bairro, p_rota ") '17
            SqlParticipante.Append("FROM cadp001 WHERE p_cod = '" & codFornecedor & "' ORDER BY p_portad ASC")
            CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConn)
            drParticipante = CmdParticipante.ExecuteReader

            If drParticipante.HasRows = False Then
                Return False

            Else

                While drParticipante.Read

                    cadp001.pCod = drParticipante(0).ToString
                    cadp001.pPortad = drParticipante(1).ToString
                    cadp001.pCgc = drParticipante(2).ToString
                    cadp001.pCpf = drParticipante(3).ToString
                    cadp001.pInsc = drParticipante(4).ToString
                    cadp001.pUf = drParticipante(5).ToString
                    cadp001.pEnder = drParticipante(6).ToString
                    cadp001.pCid = drParticipante(7).ToString
                    cadp001.pCep = drParticipante(8).ToString
                    cadp001.pFone = drParticipante(9).ToString
                    cadp001.pConsumo = drParticipante(10).ToString
                    cadp001.pIsento = drParticipante(11)
                    cadp001.pMun = drParticipante(12).ToString
                    cadp001.pCoduf = drParticipante(13).ToString
                    cadp001.pCarac = drParticipante(14).ToString
                    cadp001.pEmail = drParticipante(15).ToString
                    cadp001.pBairro = drParticipante(16).ToString
                    cadp001.pRota = drParticipante(17)

                End While
                drParticipante.Close()


            End If

        Catch ex As Exception
            MsgBox("ERRO::" & ex.Message)
            Return False
        End Try

        CmdParticipante.CommandText = "" : SqlParticipante.Remove(0, SqlParticipante.ToString.Length)
        CmdParticipante = Nothing : SqlParticipante = Nothing : drParticipante = Nothing
        oConn.Close() : oConn = Nothing



        Return True
    End Function

    Public Function trazCadp001Full(ByVal codFornecedor As String, ByRef cadp001 As Cl_Cadp001) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        codFornecedor = codFornecedor.ToUpper

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão p/ Buscar Cliente:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False

        End Try


        Try

            SqlParticipante.Append("SELECT p_tipo, p_carac, p_dtcad, p_cod, p_portad, p_fantas, p_civil, ") '6
            SqlParticipante.Append("p_dtnativ, p_natur, p_ident, p_cpf, p_cgc, p_insc, p_pai, p_mae, ") '14
            SqlParticipante.Append("p_end, p_bairro, p_cid, p_uf, p_cep, p_fone, p_ltrab, p_endtr, ") '22
            SqlParticipante.Append("p_fontr, p_cargo, p_salar, p_esposo, p_crt, p_ltrabe, p_salae, ") '29
            SqlParticipante.Append("p_rota, p_vend, p_obs1, p_obs2, p_obs3, p_ultcomp, p_valor, p_limite, ") '37
            SqlParticipante.Append("p_pedido, p_cdvend, p_cdcid, p_bloq, p_tb, p_consumo, p_mun, ") '44
            SqlParticipante.Append("p_coduf, p_ctactb, p_ctaanli, p_mes, p_fax, p_prep, p_email, ") '51
            SqlParticipante.Append("p_sexo, p_celular, p_inativo, p_usuario, p_isento, p_id, p_iddoutor, ") '58
            SqlParticipante.Append("p_doutor, p_ficha FROM cadp001 WHERE p_cod = '" & codFornecedor & "' LIMIT 1")
            CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConn)
            drParticipante = CmdParticipante.ExecuteReader

            If drParticipante.HasRows = False Then
                Return False

            Else

                While drParticipante.Read

                    cadp001.pTipo = drParticipante(0).ToString
                    cadp001.pCarac = drParticipante(1).ToString
                    Try
                        cadp001.pDtcad = drParticipante(2)
                    Catch ex As Exception
                        cadp001.pDtcad = Nothing
                    End Try
                    cadp001.pCod = drParticipante(3).ToString
                    cadp001.pPortad = drParticipante(4).ToString
                    cadp001.pFantas = drParticipante(5).ToString
                    cadp001.pCivil = drParticipante(6).ToString
                    Try
                        cadp001.pDtnativ = drParticipante(7)
                    Catch ex As Exception
                        cadp001.pDtnativ = Nothing
                    End Try
                    cadp001.pNatur = drParticipante(8).ToString
                    cadp001.pIdent = drParticipante(9).ToString
                    cadp001.pCpf = drParticipante(10).ToString
                    cadp001.pCgc = drParticipante(11).ToString
                    cadp001.pInsc = drParticipante(12).ToString
                    cadp001.pPai = drParticipante(13).ToString
                    cadp001.pMae = drParticipante(14).ToString
                    cadp001.pEnder = drParticipante(15).ToString
                    cadp001.pBairro = drParticipante(16).ToString
                    cadp001.pCid = drParticipante(17).ToString
                    cadp001.pUf = drParticipante(18).ToString
                    cadp001.pCep = drParticipante(19).ToString
                    cadp001.pFone = drParticipante(20).ToString
                    cadp001.pLtrab = drParticipante(21).ToString
                    cadp001.pEndtr = drParticipante(22).ToString
                    cadp001.pFontr = drParticipante(23).ToString
                    cadp001.pCargo = drParticipante(24).ToString
                    cadp001.pSalar = drParticipante(25)
                    cadp001.pEsposo = drParticipante(26).ToString
                    cadp001.pCrt = drParticipante(27).ToString
                    cadp001.pLtrabe = drParticipante(28).ToString
                    cadp001.pSalae = drParticipante(29)
                    cadp001.pRota = drParticipante(30)
                    cadp001.pVend = drParticipante(31).ToString
                    cadp001.pObs1 = drParticipante(32).ToString
                    cadp001.pObs2 = drParticipante(33).ToString
                    cadp001.pObs3 = drParticipante(34).ToString
                    Try
                        cadp001.pUltcomp = drParticipante(35)
                    Catch ex As Exception
                        cadp001.pUltcomp = Nothing
                    End Try
                    cadp001.pValor = drParticipante(36)
                    cadp001.pLimite = drParticipante(37)
                    cadp001.pPedido = drParticipante(38).ToString
                    cadp001.pCdvend = drParticipante(39).ToString
                    cadp001.pCdcid = drParticipante(40).ToString
                    cadp001.pBloq = drParticipante(41).ToString
                    cadp001.pTb = drParticipante(42).ToString
                    cadp001.pConsumo = drParticipante(43).ToString
                    cadp001.pMun = drParticipante(44).ToString
                    cadp001.pCoduf = drParticipante(45).ToString
                    cadp001.pCtactb = drParticipante(46).ToString
                    cadp001.pCtaanli = drParticipante(47).ToString
                    cadp001.pMes = drParticipante(48)
                    cadp001.pFax = drParticipante(49).ToString
                    cadp001.pPrep = drParticipante(50).ToString
                    cadp001.pEmail = drParticipante(51).ToString
                    cadp001.pSexo = drParticipante(52).ToString
                    cadp001.pCelular = drParticipante(53).ToString
                    cadp001.pInativo = drParticipante(54)
                    cadp001.pUsuario = drParticipante(55).ToString
                    cadp001.pIsento = drParticipante(56)
                    cadp001.Id = drParticipante(57)
                    cadp001.iddoutor = drParticipante(58).ToString
                    cadp001.doutor = drParticipante(59).ToString
                    cadp001.ficha = drParticipante(60).ToString

                End While
                drParticipante.Close()


            End If

        Catch ex As Exception
            MsgBox("ERRO::" & ex.Message)
            Return False
        End Try

        CmdParticipante.CommandText = "" : SqlParticipante.Remove(0, SqlParticipante.ToString.Length)
        CmdParticipante = Nothing : SqlParticipante = Nothing : drParticipante = Nothing
        oConn.Close() : oConn = Nothing



        Return True
    End Function

    Public Function trazProdutoBD(ByVal codIten As String, ByRef produto As Cl_Est0001, _
                               ByVal geno001 As Cl_Geno) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao abrir conexão p/ buscar Produto:: " & ex.Message, MsgBoxStyle.Exclamation) : Return False
        End Try


        Try
            SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, el.e_qtde, e.e_und, e.e_ncm, ") ' 5
            SqlProduto.Append("e.e_cst, e.e_cfv, e.e_grupo, e.e_reduz, el.e_qtdfisc, el.e_pcusto, el.e_pcomp, ") ' 12
            SqlProduto.Append("e.e_clf, el.e_pvenda, e.e_pesobruto, e.e_pesoliq, e.e_cdbarra, e.e_linha, ") ' 18
            SqlProduto.Append("e.e_dtinicialpromocao, e.e_dtfinalpromocao, e.e_quotapromocao, e.e_grade, e.e_tipo, e.e_ipi, ") '24
            SqlProduto.Append("e.e_cstipi, e.e_produt2, e.e_produt3, e.e_reduz, e.e_pauta ") '29
            SqlProduto.Append("FROM " & geno001.pEsquemavinc & ".est0001 e JOIN estloja01 el ON e.e_codig = el.e_codig WHERE ")
            SqlProduto.Append("el.e_loja = '" & geno001.pCodig.Substring(geno001.pCodig.Length - 2, 2) & "' AND ")

            If MdlEmpresaUsu._codProd Then

                SqlProduto.Append("el.e_codig = '" & codIten & "' ORDER BY e_produt ASC")

            Else
                SqlProduto.Append("e.e_cdbarra = '" & codIten & "' ORDER BY e_produt ASC")
            End If


            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConn)
            drProduto = CmdProduto.ExecuteReader

            If drProduto.HasRows = False Then

                drProduto.Close()
                SqlProduto.Remove(0, SqlProduto.ToString.Length) : CmdProduto.CommandText = ""

                SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, el.e_qtde, e.e_und, e.e_ncm, ") ' 5
                SqlProduto.Append("e.e_cst, e.e_cfv, e.e_grupo, e.e_reduz, el.e_qtdfisc, el.e_pcusto, el.e_pcomp, ") ' 12
                SqlProduto.Append("e.e_clf, el.e_pvenda, e.e_pesobruto, e.e_pesoliq, e.e_cdbarra, e.e_linha, ") ' 18
                SqlProduto.Append("e.e_dtinicialpromocao, e.e_dtfinalpromocao, e.e_quotapromocao, e.e_grade, e.e_tipo, e.e_ipi, ") '24
                SqlProduto.Append("e.e_cstipi, e.e_produt2, e.e_produt3, e.e_reduz, e.e_pauta ") '29
                SqlProduto.Append("FROM " & geno001.pEsquemavinc & ".est0001 e JOIN estloja01 el ON e.e_codig = el.e_codig WHERE ")
                SqlProduto.Append("el.e_loja = '" & geno001.pCodig.Substring(geno001.pCodig.Length - 2, 2) & "' AND ")

                If MdlEmpresaUsu._codProd Then 'Reverte As Consultas:
                    SqlProduto.Append("e.e_cdbarra = '" & codIten & "' ORDER BY e_produt ASC")
                Else
                    SqlProduto.Append("el.e_codig = '" & codIten & "' ORDER BY e_produt ASC")
                End If
                CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConn)
                drProduto = CmdProduto.ExecuteReader

            End If

            If drProduto.HasRows = False Then Return False

            While drProduto.Read

                produto.pCodig = drProduto(0).ToString : produto.pProdut = drProduto(1).ToString
                produto.pCdport = drProduto(2).ToString : produto.pQtde = drProduto(3).ToString
                produto.pUnd = drProduto(4).ToString : produto.pNcm = drProduto(5).ToString
                produto.pCst = drProduto(6) : produto.pCfv = drProduto(7) : produto.pGrupo = drProduto(8)
                produto.pReduz = drProduto(9) : produto.pQtdfisc = drProduto(10).ToString
                produto.pPcustoa = drProduto(11).ToString : produto.pPvenda = drProduto(12).ToString
                produto.pClf = drProduto(13).ToString


                produto.pCdbarra = drProduto(17).ToString
                produto.pLinha = drProduto(18).ToString
                produto.pPcomp = drProduto(12)
                produto.pPvenda = drProduto(14)
                produto.pPesobruto = drProduto(15)
                produto.pPesoliq = drProduto(16)
                produto.pGrade = drProduto(22).ToString
                produto.pTipo = drProduto(23)
                produto.pIpi = drProduto(24)
                produto.pCstIpi = drProduto(25).ToString
                produto.pProdut2 = drProduto(26).ToString
                produto.pProdut3 = drProduto(27).ToString
                produto.pReduz = drProduto(28)
                produto.pPauta = drProduto(29)

                Try
                    produto.pDtinicialpromocao = drProduto(19).ToString
                Catch ex As Exception
                    produto.pDtinicialpromocao = Nothing
                End Try

                Try
                    produto.pDtfinalpromocao = drProduto(20).ToString
                Catch ex As Exception
                    produto.pDtfinalpromocao = Nothing
                End Try

                Try
                    produto.pVprom = drProduto(21).ToString
                Catch ex As Exception
                    produto.pVprom = Nothing
                End Try


            End While
            drProduto.Close() : drProduto = Nothing

        Catch ex As Exception
            MsgBox("Tabela de PRODUTOS ERRO:: " & ex.Message, MsgBoxStyle.Exclamation) : Return False

        End Try

        CmdProduto.CommandText = "" : SqlProduto.Remove(0, SqlProduto.ToString.Length)
        oConn.Close()
        CmdProduto = Nothing : SqlProduto = Nothing : oConn = Nothing


        Return True
    End Function

    Public Function existSaldoEstoque(ByVal data As Date, ByVal loja As String, ByVal tiposaldo As String, _
                                      ByVal conexao As String) As Boolean

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)
        Dim mExiste As Boolean = False
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão:: ", MsgBoxStyle.Critical)
            oConn = Nothing : Return True
        End Try

        Dim Cmd As New NpgsqlCommand
        Dim SqlCmd As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmd.Append("SELECT ef_loja FROM estfinanceiro WHERE ef_data = '" & Format(data, "dd/MM/yyyy") & "' AND ef_loja = '" & loja & "' ")
            SqlCmd.Append("AND ef_tiposaldo = '" & tiposaldo & "'")
            Cmd = New NpgsqlCommand(SqlCmd.ToString, oConn)
            dr = Cmd.ExecuteReader

            If dr.HasRows Then mExiste = True

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

        oConn.ClearAllPools() : oConn.Close()
        Cmd = Nothing : SqlCmd = Nothing : dr = Nothing : oConn = Nothing


        Return mExiste

    End Function

    Public Function returnDgEnergia(ByRef dgEnerg As DataGridView, ByVal conexao As String) As DataGridView
        Dim dgEnergia As New DataGridView
        dgEnergia = dgEnerg
        Dim oConnBDGENOV As New NpgsqlConnection(conexao)
        Me._erro = False
        Me._msgErro = ""

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception

            Me._erro = True
            Me._msgErro = "Banco de Dados Inexistente!"
        End Try

        If oConnBDGENOV.State = ConnectionState.Open Then
            Dim sqlEnergia As New StringBuilder
            Dim cmdEnergia As NpgsqlCommand
            Dim daEnergia As NpgsqlDataAdapter
            Dim drEnergia As NpgsqlDataReader
            Dim dsEnergia As New DataSet

            Try
                sqlEnergia.Append("SELECT * FROM servenergia")

                cmdEnergia = New NpgsqlCommand(sqlEnergia.ToString, oConnBDGENOV)
                daEnergia = New NpgsqlDataAdapter(sqlEnergia.ToString, oConnBDGENOV)
                drEnergia = cmdEnergia.ExecuteReader

                dgEnergia.Rows.Clear()
                daEnergia.Fill(dsEnergia, "servenergia")
                dgEnerg.DataSource = dsEnergia

                dsEnergia.Clear()
                Me._erro = False
                cmdEnergia.CommandText = ""
                sqlEnergia.Remove(0, sqlEnergia.ToString.Length)
                dsEnergia.Clear() : daEnergia.Dispose()
                oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close()
            Catch ex As Exception
                Me._erro = True
                Me._msgErro = "Tabela de SERVENERGIA Inexistente!"
            End Try

            daEnergia = Nothing : cmdEnergia = Nothing : sqlEnergia = Nothing : dsEnergia = Nothing
        End If

        Return dgEnerg
    End Function

    Public Function existNfEnergia_Tabela(ByVal numero As String, ByVal codPart As String, ByVal conexao As String) As Boolean
        Dim oConnMunicipios As NpgsqlConnection = New NpgsqlConnection(conexao)
        Me._erro = True
        Me._msgErro = ""

        Try
            oConnMunicipios.Open()
        Catch ex As Exception
            Me._erro = True
            Me._msgErro = "Banco de Dados Inexistente!"
        End Try


        Dim CmdMunicipios As New NpgsqlCommand
        Dim SqlCmdMunicipios As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            SqlCmdMunicipios.Append("SELECT * FROM servenergia WHERE en_numero = '" & numero & "' AND en_cliente = '")
            SqlCmdMunicipios.Append(codPart & "'")
            CmdMunicipios = New NpgsqlCommand(SqlCmdMunicipios.ToString, oConnMunicipios)
            dr = CmdMunicipios.ExecuteReader

            If dr.HasRows = True Then

                _erro = False
            End If

        Catch ex As Exception
            Me._erro = True
            Me._msgErro = "Tabela de Clientes Inexistente!"
        End Try

        dr.Close() : oConnMunicipios.ClearAllPools() : oConnMunicipios.Close()
        CmdMunicipios = Nothing : SqlCmdMunicipios = Nothing : dr = Nothing


        oConnMunicipios = Nothing
        If _erro = False Then
            _erro = Nothing
            _msgErro = Nothing
            Return True
        Else

            Return False
        End If
    End Function

    'INICIO de Tratamento do Resumo dos Itens na saída...
    'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
    'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
    Private Function ReturnAlqGridView(ByVal dtgItens As DataGridView) As Array

        Dim mStrBuildAlq As New StringBuilder
        Dim mArray As Array
        Dim i As Integer
        Dim mExitAlq As Boolean = False

        mStrBuildAlq.Append("")
        'Percorre o GridView
        For Each row As DataGridViewRow In dtgItens.Rows

            If Not row.IsNewRow Then

                Try
                    mArray = Split(mStrBuildAlq.ToString, "|")
                    mExitAlq = False
                    For i = 0 To mArray.Length - 1

                        If CDec(row.Cells(3).Value).ToString.Equals(mArray(i).ToString) Then

                            mExitAlq = True
                            Exit For

                        End If
                    Next
                    If mExitAlq = False Then mStrBuildAlq.Append(CDec(row.Cells(3).Value) & "|")

                Catch ex As Exception
                End Try

            End If
        Next
        mArray = Nothing : mExitAlq = Nothing : i = Nothing



        Return Split(mStrBuildAlq.ToString, "|")
    End Function

    Private Function ReturnCfopAlqGridView(ByVal dtgItens As DataGridView) As Array

        Dim mStrBuild As New StringBuilder
        Dim mArray As Array
        Dim i As Integer
        Dim mExitAlq As Boolean = False
        Dim CFOP_ALQ As String

        mStrBuild.Append("")
        'Percorre o GridView
        For Each row As DataGridViewRow In dtgItens.Rows

            If Not row.IsNewRow Then

                Try
                    CFOP_ALQ = row.Cells(1).Value & "/" & CDec(row.Cells(3).Value)
                    mArray = Split(mStrBuild.ToString, "|")
                    mExitAlq = False

                    For i = 0 To mArray.Length - 1

                        If CFOP_ALQ.Equals(mArray(i).ToString) Then
                            mExitAlq = True
                            Exit For

                        End If
                    Next
                    If mExitAlq = False Then mStrBuild.Append(CFOP_ALQ & "|")

                Catch ex As Exception
                End Try

            End If
        Next
        mArray = Nothing : mExitAlq = Nothing : i = Nothing : CFOP_ALQ = Nothing



        Return Split(mStrBuild.ToString, "|")
    End Function

    Private Function ReturnCstCfopAlqGridView(ByVal dtgItens As DataGridView) As Array

        Dim mStrBuild As New StringBuilder
        Dim mArray As Array
        Dim i As Integer
        Dim mExitAlq As Boolean = False
        Dim CST_CFOP_ALQ As String

        mStrBuild.Append("")
        'Percorre o GridView
        For Each row As DataGridViewRow In dtgItens.Rows

            If Not row.IsNewRow Then

                Try
                    CST_CFOP_ALQ = row.Cells(2).Value & "/" & row.Cells(1).Value & "/" & CDec(row.Cells(3).Value)
                    mArray = Split(mStrBuild.ToString, "|")
                    mExitAlq = False

                    For i = 0 To mArray.Length - 1
                        If CST_CFOP_ALQ.Equals(mArray(i).ToString) Then

                            mExitAlq = True : Exit For

                        End If
                    Next
                    If mExitAlq = False Then mStrBuild.Append(CST_CFOP_ALQ & "|")

                Catch ex As Exception
                End Try

            End If
        Next
        mArray = Nothing : mExitAlq = Nothing : i = Nothing : CST_CFOP_ALQ = Nothing



        Return Split(mStrBuild.ToString, "|")
    End Function

    Public Sub incResumAlqSaida(ByVal editaNota As Boolean, ByVal dtgItens As DataGridView, ByVal resn4dd01 As Cl_ResN4dd01, _
                                 ByVal geno001 As Cl_Geno, ByVal clBD As Cl_bdMetrosys, ByVal oConn As NpgsqlConnection, _
                                 ByVal transacao As NpgsqlTransaction)

        Dim mAliquotas As Array = ReturnAlqGridView(dtgItens)
        Dim strALQ As String = ""
        Dim i As Integer
        Dim mExistAlq As Boolean = False

        For i = 0 To mAliquotas.Length - 1

            mExistAlq = False

            'Percorre o GridView
            For Each row As DataGridViewRow In dtgItens.Rows

                If Not row.IsNewRow Then

                    strALQ = CDec(row.Cells(3).Value)
                    If mAliquotas(i).Equals(strALQ) Then

                        mExistAlq = True

                        'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
                        'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
                        resn4dd01.r4_tprod += CDec(row.Cells(4).Value) : resn4dd01.r4_tdesc += CDec(row.Cells(5).Value)
                        resn4dd01.r4_tfrete += CDec(row.Cells(6).Value) : resn4dd01.r4_tseguro += CDec(row.Cells(7).Value)
                        resn4dd01.r4_toutrasdesp += CDec(row.Cells(8).Value) : resn4dd01.r4_aliq = CDec(row.Cells(3).Value)
                        resn4dd01.r4_bcalc += CDec(row.Cells(9).Value) : resn4dd01.r4_icms += CDec(row.Cells(10).Value)
                        resn4dd01.r4_outras += CDec(row.Cells(12).Value) : resn4dd01.r4_ipi += CDec(row.Cells(13).Value)

                        'CST
                        If row.Cells(2).Value.Equals("30") OrElse _
                        row.Cells(2).Value.Equals("40") Then

                            resn4dd01.r4_isento += CDec(row.Cells(11).Value)

                        Else
                            resn4dd01.r4_isento += 0.0

                        End If

                    End If
                End If
            Next 'fim For GridView


            resn4dd01.r4_tgeral = Round(((resn4dd01.r4_tprod + resn4dd01.r4_isento + resn4dd01.r4_outras + resn4dd01.r4_ipi + resn4dd01.r4_tfrete + _
                                          resn4dd01.r4_tseguro + resn4dd01.r4_toutrasdesp) - resn4dd01.r4_tdesc), 2)

            If mExistAlq = True Then 'Grava o Resumo das Aliquotas no resn4ff01

                If editaNota = False Then 'Se a nota não estiver no processo de edição, então inclui

                    clBD.IncResSaidaALQ(resn4dd01, geno001, oConn, transacao)

                Else

                    Try
                        clBD.delResSaidaALQ(resn4dd01, geno001, oConn, transacao)
                        clBD.IncResSaidaALQ(resn4dd01, geno001, oConn, transacao)

                    Catch ex As Exception
                    End Try

                End If
            End If

            resn4dd01.zeraValoresNFe()
        Next 'fim For Aliquotas

        'LIMPA OBJETOS DA MEMÓRIA...
        mAliquotas = Nothing : i = Nothing : strALQ = Nothing : resn4dd01 = Nothing : geno001 = Nothing : clBD = Nothing



    End Sub

    Public Sub incResumCfopAlqSaida(ByVal editaNota As Boolean, ByVal dtgItens As DataGridView, ByVal resn4dd02 As Cl_ResN4dd02, _
                                 ByVal geno001 As Cl_Geno, ByVal clBD As Cl_bdMetrosys, ByVal oConn As NpgsqlConnection, _
                                 ByVal transacao As NpgsqlTransaction)

        Dim mCfopAlq As Array = ReturnCfopAlqGridView(dtgItens)
        Dim i As Integer
        Dim strCFOP_ALQ As String
        Dim mExistCfopAlq As Boolean = False


        For i = 0 To mCfopAlq.Length - 1

            mExistCfopAlq = False

            'Percorre o GridView
            For Each row As DataGridViewRow In dtgItens.Rows


                If Not row.IsNewRow Then

                    strCFOP_ALQ = row.Cells(1).Value & "/" & CDec(row.Cells(3).Value)
                    If mCfopAlq(i).Equals(strCFOP_ALQ) Then

                        'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
                        'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
                        mExistCfopAlq = True : resn4dd02.r4_cfop = row.Cells(1).Value.ToString
                        resn4dd02.r4_tprod += CDec(row.Cells(4).Value) : resn4dd02.r4_tdesc += CDec(row.Cells(5).Value)
                        resn4dd02.r4_tfrete += CDec(row.Cells(6).Value) : resn4dd02.r4_tseguro += CDec(row.Cells(7).Value)
                        resn4dd02.r4_toutrasdesp += CDec(row.Cells(8).Value) : resn4dd02.r4_aliq = CDec(row.Cells(3).Value)
                        resn4dd02.r4_bcalc += CDec(row.Cells(9).Value) : resn4dd02.r4_icms += CDec(row.Cells(10).Value)
                        resn4dd02.r4_outras += CDec(row.Cells(12).Value) : resn4dd02.r4_ipi += CDec(row.Cells(13).Value)

                        'CST
                        If row.Cells(2).Value.Equals("30") OrElse _
                        row.Cells(2).Value.Equals("40") Then

                            resn4dd02.r4_isento += CDec(row.Cells(11).Value)

                        Else
                            resn4dd02.r4_isento += 0.0

                        End If

                    End If
                End If
            Next 'fim For GridView

            resn4dd02.r4_tgeral = Round(((resn4dd02.r4_tprod + resn4dd02.r4_isento + resn4dd02.r4_outras + resn4dd02.r4_ipi + resn4dd02.r4_tfrete + _
                                          resn4dd02.r4_tseguro + resn4dd02.r4_toutrasdesp) - resn4dd02.r4_tdesc), 2)

            If mExistCfopAlq = True Then 'Grava o Resumo dos CFOP/Aliquotas no resn4ff02
                If editaNota = False Then 'Se a nota não estiver no processo de edição, então inclui

                    clBD.IncResSaidaCfopALQ(resn4dd02, geno001, oConn, transacao)

                Else

                    Try
                        clBD.delResSaidaCfopALQ(resn4dd02, geno001, oConn, transacao)
                        clBD.IncResSaidaCfopALQ(resn4dd02, geno001, oConn, transacao)

                    Catch ex As Exception
                    End Try

                End If
            End If

            resn4dd02.zeraValoresNFe()
        Next 'fim For Aliquotas

        'LIMPA OBJETOS DA MEMÓRIA...
        mCfopAlq = Nothing : i = Nothing : strCFOP_ALQ = Nothing : mExistCfopAlq = Nothing : resn4dd02 = Nothing : geno001 = Nothing : clBD = Nothing



    End Sub

    Public Sub incResumCstCfopAlqSaida(ByVal editaNota As Boolean, ByVal dtgItens As DataGridView, ByVal resn4dd03 As Cl_ResN4dd03, _
                                 ByVal geno001 As Cl_Geno, ByVal clBD As Cl_bdMetrosys, ByVal oConn As NpgsqlConnection, _
                                 ByVal transacao As NpgsqlTransaction)

        Dim mCstCfopAlq As Array = ReturnCstCfopAlqGridView(dtgItens)
        Dim i As Integer
        Dim strCST_CFOP_ALQ As String
        Dim mExistCstCfopAlq As Boolean = False

        For i = 0 To mCstCfopAlq.Length - 1

            mExistCstCfopAlq = False

            'Percorre o GridView
            For Each row As DataGridViewRow In dtgItens.Rows


                If Not row.IsNewRow Then

                    strCST_CFOP_ALQ = row.Cells(2).Value & "/" & row.Cells(1).Value & "/" & CDec(row.Cells(3).Value)
                    If mCstCfopAlq(i).Equals(strCST_CFOP_ALQ) Then

                        'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
                        'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
                        mExistCstCfopAlq = True : resn4dd03.r4_cfop = row.Cells(1).Value.ToString : resn4dd03.r4_cst = row.Cells(2).Value.ToString
                        resn4dd03.r4_tprod += CDec(row.Cells(4).Value) : resn4dd03.r4_tdesc += CDec(row.Cells(5).Value)
                        resn4dd03.r4_tfrete += CDec(row.Cells(6).Value) : resn4dd03.r4_tseguro += CDec(row.Cells(7).Value)
                        resn4dd03.r4_toutrasdesp += CDec(row.Cells(8).Value) : resn4dd03.r4_aliq = CDec(row.Cells(3).Value)
                        resn4dd03.r4_bcalc += CDec(row.Cells(9).Value) : resn4dd03.r4_icms += CDec(row.Cells(10).Value)
                        resn4dd03.r4_outras += CDec(row.Cells(12).Value) : resn4dd03.r4_ipi += CDec(row.Cells(13).Value)

                        'CST
                        If row.Cells(2).Value.Equals("30") OrElse _
                        row.Cells(2).Value.Equals("40") Then

                            resn4dd03.r4_isento += CDec(row.Cells(11).Value)

                        Else
                            resn4dd03.r4_isento += 0.0

                        End If

                    End If
                End If
            Next 'fim For GridView

            resn4dd03.r4_tgeral = Round(((resn4dd03.r4_tprod + resn4dd03.r4_isento + resn4dd03.r4_outras + resn4dd03.r4_ipi + resn4dd03.r4_tfrete + _
                                          resn4dd03.r4_tseguro + resn4dd03.r4_toutrasdesp) - resn4dd03.r4_tdesc), 2)

            If mExistCstCfopAlq = True Then 'Grava o Resumo dos CST/CFOP/Aliquotas no resn4ff03

                If editaNota = False Then 'Se a nota não estiver no processo de edição, então inclui

                    clBD.IncResSaidaCstCfopALQ(resn4dd03, geno001, oConn, transacao)

                Else

                    Try
                        clBD.delResSaidaCstCfopALQ(resn4dd03, geno001, oConn, transacao)
                        clBD.IncResSaidaCstCfopALQ(resn4dd03, geno001, oConn, transacao)

                    Catch ex As Exception
                    End Try

                End If
            End If

            resn4dd03.zeraValoresNFe()
        Next 'fim For Aliquotas

        'LIMPA OBJETOS DA MEMÓRIA...
        mCstCfopAlq = Nothing : i = Nothing : strCST_CFOP_ALQ = Nothing : mExistCstCfopAlq = Nothing
        resn4dd03 = Nothing : geno001 = Nothing : clBD = Nothing



    End Sub

    'FIM de Tratamento do Resumo dos Itens na saída


    'INICIO de Tratamento do Resumo dos Itens na Entrada
    Public Sub incResumAlqEntrada(ByVal editaNota As Boolean, ByVal dtgItens As DataGridView, ByVal resn4ff01 As Cl_ResN4ff01, _
                                 ByVal geno001 As Cl_Geno, ByVal clBD As Cl_bdMetrosys, ByVal oConn As NpgsqlConnection, _
                                 ByVal transacao As NpgsqlTransaction)

        Dim mAliquotas As Array = ReturnAlqGridView(dtgItens)
        Dim strALQ As String = ""
        Dim i As Integer
        Dim mExistAlq As Boolean = False

        For i = 0 To mAliquotas.Length - 1

            mExistAlq = False

            'Percorre o GridView
            For Each row As DataGridViewRow In dtgItens.Rows

                If Not row.IsNewRow Then

                    strALQ = CDec(row.Cells(3).Value)
                    If mAliquotas(i).Equals(strALQ) Then

                        mExistAlq = True

                        'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
                        'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
                        resn4ff01.r4_tprod += CDec(row.Cells(4).Value) : resn4ff01.r4_tdesc += CDec(row.Cells(5).Value)
                        resn4ff01.r4_tfrete += CDec(row.Cells(6).Value) : resn4ff01.r4_tseguro += CDec(row.Cells(7).Value)
                        resn4ff01.r4_toutrasdesp += CDec(row.Cells(8).Value) : resn4ff01.r4_aliq = CDec(row.Cells(3).Value)
                        resn4ff01.r4_bcalc += CDec(row.Cells(9).Value) : resn4ff01.r4_icms += CDec(row.Cells(10).Value)
                        resn4ff01.r4_outras += CDec(row.Cells(12).Value) : resn4ff01.r4_ipi += CDec(row.Cells(13).Value)

                        'CST
                        If row.Cells(2).Value.Equals("30") OrElse _
                        row.Cells(2).Value.Equals("40") Then

                            resn4ff01.r4_isento += CDec(row.Cells(11).Value)

                        Else
                            resn4ff01.r4_isento += 0.0

                        End If

                    End If
                End If
            Next 'fim For GridView


            resn4ff01.r4_tgeral = Round(((resn4ff01.r4_tprod + resn4ff01.r4_isento + resn4ff01.r4_outras + resn4ff01.r4_ipi + resn4ff01.r4_tfrete + _
                                          resn4ff01.r4_tseguro + resn4ff01.r4_toutrasdesp) - resn4ff01.r4_tdesc), 2)

            If mExistAlq = True Then 'Grava o Resumo das Aliquotas no resn4ff01

                If editaNota = False Then 'Se a nota não estiver no processo de edição, então inclui

                    clBD.IncResEntradaALQ(resn4ff01, geno001, oConn, transacao)

                Else

                    Try
                        clBD.delResEntradaALQ(resn4ff01, geno001, oConn, transacao)
                        clBD.IncResEntradaALQ(resn4ff01, geno001, oConn, transacao)

                    Catch ex As Exception
                    End Try

                End If
            End If

            resn4ff01.zeraValoresNFe()
        Next 'fim For Aliquotas

        'LIMPA OBJETOS DA MEMÓRIA...
        mAliquotas = Nothing : i = Nothing : strALQ = Nothing : resn4ff01 = Nothing : geno001 = Nothing : clBD = Nothing



    End Sub

    Public Sub incResumCfopAlqEntrada(ByVal editaNota As Boolean, ByVal dtgItens As DataGridView, ByVal resn4ff02 As Cl_ResN4ff02, _
                                 ByVal geno001 As Cl_Geno, ByVal clBD As Cl_bdMetrosys, ByVal oConn As NpgsqlConnection, _
                                 ByVal transacao As NpgsqlTransaction)

        Dim mCfopAlq As Array = ReturnCfopAlqGridView(dtgItens)
        Dim i As Integer
        Dim strCFOP_ALQ As String
        Dim mExistCfopAlq As Boolean = False


        For i = 0 To mCfopAlq.Length - 1

            mExistCfopAlq = False

            'Percorre o GridView
            For Each row As DataGridViewRow In dtgItens.Rows


                If Not row.IsNewRow Then

                    strCFOP_ALQ = row.Cells(1).Value & "/" & CDec(row.Cells(3).Value)
                    If mCfopAlq(i).Equals(strCFOP_ALQ) Then

                        'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
                        'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
                        mExistCfopAlq = True : resn4ff02.r4_cfop = row.Cells(1).Value.ToString
                        resn4ff02.r4_tprod += CDec(row.Cells(4).Value) : resn4ff02.r4_tdesc += CDec(row.Cells(5).Value)
                        resn4ff02.r4_tfrete += CDec(row.Cells(6).Value) : resn4ff02.r4_tseguro += CDec(row.Cells(7).Value)
                        resn4ff02.r4_toutrasdesp += CDec(row.Cells(8).Value) : resn4ff02.r4_aliq = CDec(row.Cells(3).Value)
                        resn4ff02.r4_bcalc += CDec(row.Cells(9).Value) : resn4ff02.r4_icms += CDec(row.Cells(10).Value)
                        resn4ff02.r4_outras += CDec(row.Cells(12).Value) : resn4ff02.r4_ipi += CDec(row.Cells(13).Value)

                        'CST
                        If row.Cells(2).Value.Equals("30") OrElse _
                        row.Cells(2).Value.Equals("40") Then

                            resn4ff02.r4_isento += CDec(row.Cells(11).Value)

                        Else
                            resn4ff02.r4_isento += 0.0

                        End If

                    End If
                End If
            Next 'fim For GridView

            resn4ff02.r4_tgeral = Round(((resn4ff02.r4_tprod + resn4ff02.r4_isento + resn4ff02.r4_outras + resn4ff02.r4_ipi + resn4ff02.r4_tfrete + _
                                          resn4ff02.r4_tseguro + resn4ff02.r4_toutrasdesp) - resn4ff02.r4_tdesc), 2)

            If mExistCfopAlq = True Then 'Grava o Resumo dos CFOP/Aliquotas no resn4ff02
                If editaNota = False Then 'Se a nota não estiver no processo de edição, então inclui

                    clBD.IncResEntradaCfopALQ(resn4ff02, geno001, oConn, transacao)

                Else

                    Try
                        clBD.delResEntradaCfopALQ(resn4ff02, geno001, oConn, transacao)
                        clBD.IncResEntradaCfopALQ(resn4ff02, geno001, oConn, transacao)

                    Catch ex As Exception
                    End Try

                End If
            End If

            resn4ff02.zeraValoresNFe()
        Next 'fim For Aliquotas

        'LIMPA OBJETOS DA MEMÓRIA...
        mCfopAlq = Nothing : i = Nothing : strCFOP_ALQ = Nothing : mExistCfopAlq = Nothing : resn4ff02 = Nothing : geno001 = Nothing : clBD = Nothing



    End Sub

    Public Sub incResumCstCfopAlqEntrada(ByVal editaNota As Boolean, ByVal dtgItens As DataGridView, ByVal resn4ff03 As Cl_ResN4ff03, _
                                 ByVal geno001 As Cl_Geno, ByVal clBD As Cl_bdMetrosys, ByVal oConn As NpgsqlConnection, _
                                 ByVal transacao As NpgsqlTransaction)

        Dim mCstCfopAlq As Array = ReturnCstCfopAlqGridView(dtgItens)
        Dim i As Integer
        Dim strCST_CFOP_ALQ As String
        Dim mExistCstCfopAlq As Boolean = False

        For i = 0 To mCstCfopAlq.Length - 1

            mExistCstCfopAlq = False

            'Percorre o GridView
            For Each row As DataGridViewRow In dtgItens.Rows


                If Not row.IsNewRow Then

                    strCST_CFOP_ALQ = row.Cells(2).Value & "/" & row.Cells(1).Value & "/" & CDec(row.Cells(3).Value)
                    If mCstCfopAlq(i).Equals(strCST_CFOP_ALQ) Then

                        'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
                        'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14
                        mExistCstCfopAlq = True : resn4ff03.r4_cfop = row.Cells(1).Value.ToString : resn4ff03.r4_cst = row.Cells(2).Value.ToString
                        resn4ff03.r4_tprod += CDec(row.Cells(4).Value) : resn4ff03.r4_tdesc += CDec(row.Cells(5).Value)
                        resn4ff03.r4_tfrete += CDec(row.Cells(6).Value) : resn4ff03.r4_tseguro += CDec(row.Cells(7).Value)
                        resn4ff03.r4_toutrasdesp += CDec(row.Cells(8).Value) : resn4ff03.r4_aliq = CDec(row.Cells(3).Value)
                        resn4ff03.r4_bcalc += CDec(row.Cells(9).Value) : resn4ff03.r4_icms += CDec(row.Cells(10).Value)
                        resn4ff03.r4_outras += CDec(row.Cells(12).Value) : resn4ff03.r4_ipi += CDec(row.Cells(13).Value)

                        'CST
                        If row.Cells(2).Value.Equals("30") OrElse _
                        row.Cells(2).Value.Equals("40") Then

                            resn4ff03.r4_isento += CDec(row.Cells(11).Value)

                        Else
                            resn4ff03.r4_isento += 0.0

                        End If

                    End If
                End If
            Next 'fim For GridView

            resn4ff03.r4_tgeral = Round(((resn4ff03.r4_tprod + resn4ff03.r4_isento + resn4ff03.r4_outras + resn4ff03.r4_ipi + resn4ff03.r4_tfrete + _
                                          resn4ff03.r4_tseguro + resn4ff03.r4_toutrasdesp) - resn4ff03.r4_tdesc), 2)

            If mExistCstCfopAlq = True Then 'Grava o Resumo dos CST/CFOP/Aliquotas no resn4ff03

                If editaNota = False Then 'Se a nota não estiver no processo de edição, então inclui

                    clBD.IncResEntradaCstCfopALQ(resn4ff03, geno001, oConn, transacao)

                Else

                    Try
                        clBD.delResEntradaCstCfopALQ(resn4ff03, geno001, oConn, transacao)
                        clBD.IncResEntradaCstCfopALQ(resn4ff03, geno001, oConn, transacao)

                    Catch ex As Exception
                    End Try

                End If
            End If

            resn4ff03.zeraValoresNFe()
        Next 'fim For Aliquotas

        'LIMPA OBJETOS DA MEMÓRIA...
        mCstCfopAlq = Nothing : i = Nothing : strCST_CFOP_ALQ = Nothing : mExistCstCfopAlq = Nothing
        resn4ff03 = Nothing : geno001 = Nothing : clBD = Nothing



    End Sub
    'FIM de Tratamento do Resumo dos Itens na Entrada

#Region "Funções para preencher COMBOBOX"

    Public Function PreenchComboCfopEntradas(ByVal ufEstab As String, ByVal ufFornec As String, ByVal cboCFOP As Object, _
                                      ByVal strConection As String) As ComboBox
        Dim oConnCFOP As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnCFOP.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCFOP
        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            If ufFornec.Equals(ufEstab) Then
                sql.Append("SELECT r_cdfis, r_natureza FROM cadnatu WHERE SUBSTR(r_cdfis, 1, 1) = '1' ORDER BY r_cdfis")
                cmd = New NpgsqlCommand(sql.ToString, oConnCFOP)
                dr = cmd.ExecuteReader
            Else
                sql.Append("SELECT r_cdfis, r_natureza FROM cadnatu WHERE SUBSTR(r_cdfis, 1, 1) = '2' ORDER BY r_cdfis")
                cmd = New NpgsqlCommand(sql.ToString, oConnCFOP)
                dr = cmd.ExecuteReader
            End If

            If dr.HasRows = True Then
                cboCFOP.AutoCompleteCustomSource.Clear()
                cboCFOP.Items.Clear()
                cboCFOP.Refresh()
                While dr.Read
                    cboCFOP.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboCFOP.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboCFOP.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCFOP
        End Try
        dr.Close() : oConnCFOP.ClearAllPools() : oConnCFOP.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnCFOP = Nothing
        Return cboCFOP
    End Function

    Public Function PreenchComboCfopSaidas(ByVal ufEstab As String, ByVal ufFornec As String, ByVal cboCFOP As Object, _
                                      ByVal strConection As String) As ComboBox
        Dim oConnCFOP As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnCFOP.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCFOP
        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            If ufFornec.Equals(ufEstab) Then
                sql.Append("SELECT r_cdfis, r_natureza FROM cadnatu WHERE SUBSTR(r_cdfis, 1, 1) = '5' ORDER BY r_cdfis")
                cmd = New NpgsqlCommand(sql.ToString, oConnCFOP)
                dr = cmd.ExecuteReader
            Else
                sql.Append("SELECT r_cdfis, r_natureza FROM cadnatu WHERE SUBSTR(r_cdfis, 1, 1) = '6' OR SUBSTR(r_cdfis, 1, 1) = '7' ORDER BY r_cdfis")
                cmd = New NpgsqlCommand(sql.ToString, oConnCFOP)
                dr = cmd.ExecuteReader
            End If

            If dr.HasRows = True Then
                cboCFOP.AutoCompleteCustomSource.Clear()
                cboCFOP.Items.Clear()
                cboCFOP.Refresh()
                While dr.Read
                    cboCFOP.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboCFOP.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboCFOP.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCFOP
        End Try
        dr.Close() : oConnCFOP.ClearAllPools() : oConnCFOP.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnCFOP = Nothing
        Return cboCFOP
    End Function

    Public Function PreenchComboBancos(ByVal cboBancos As Object, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboBancos
        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT bc_codigo, bc_nome FROM bancos ORDER BY bc_codigo ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboBancos.AutoCompleteCustomSource.Clear()
                cboBancos.Items.Clear()
                cboBancos.Refresh()
                While dr.Read

                    cboBancos.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboBancos.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboBancos.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboBancos
        End Try
        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboBancos
    End Function

    Public Function PreenchComboUF(ByVal cbo_uf As ComboBox) As ComboBox
        cbo_uf.Items.Add("AC") : cbo_uf.Items.Add("AL") : cbo_uf.Items.Add("AP")
        cbo_uf.Items.Add("AM") : cbo_uf.Items.Add("BA") : cbo_uf.Items.Add("CE")
        cbo_uf.Items.Add("DF") : cbo_uf.Items.Add("ES") : cbo_uf.Items.Add("EX")
        cbo_uf.Items.Add("GO") : cbo_uf.Items.Add("MA") : cbo_uf.Items.Add("MT")
        cbo_uf.Items.Add("MS") : cbo_uf.Items.Add("MG") : cbo_uf.Items.Add("PA")
        cbo_uf.Items.Add("PB") : cbo_uf.Items.Add("PE") : cbo_uf.Items.Add("PI")
        cbo_uf.Items.Add("RJ") : cbo_uf.Items.Add("RN") : cbo_uf.Items.Add("RS")
        cbo_uf.Items.Add("RO") : cbo_uf.Items.Add("RR") : cbo_uf.Items.Add("SC")
        cbo_uf.Items.Add("SP") : cbo_uf.Items.Add("SE") : cbo_uf.Items.Add("TO")
        cbo_uf.Items.Add("PR")

        Return cbo_uf
    End Function

    Public Function PreenchComboGrupos(ByVal cboGrupos As Object, ByVal strConection As String) As ComboBox
        Dim oConnGrupo As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnGrupo.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboGrupos
        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT eg_grupo || ' - ' || eg_descri  FROM estg003 ORDER BY eg_grupo ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnGrupo)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboGrupos.AutoCompleteCustomSource.Clear()
                cboGrupos.Items.Clear()
                cboGrupos.Refresh()
                While dr.Read
                    cboGrupos.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboGrupos.Items.Add(dr(0).ToString)
                End While

                cboGrupos.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboGrupos
        End Try

        dr.Close() : oConnGrupo.ClearAllPools() : oConnGrupo.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnGrupo = Nothing
        Return cboGrupos
    End Function

    Public Function PreenchComboCarteira(ByVal cboCart As Object, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCart
        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT fc_cod, fc_desc FROM fatc002 ORDER BY fc_cod ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboCart.AutoCompleteCustomSource.Clear()
                cboCart.Items.Clear()
                cboCart.Refresh()
                While dr.Read

                    cboCart.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboCart.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboCart.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCart
        End Try
        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboCart
    End Function

    Public Function PreenchComboCargoUsuario(ByVal cboLoja As Object, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja
        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT cg_sequencia, cg_cargo FROM cargos ORDER BY cg_sequencia ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboLoja.AutoCompleteCustomSource.Clear()
                cboLoja.Items.Clear()
                cboLoja.Refresh()
                While dr.Read
                    cboLoja.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboLoja.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboLoja.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja
        End Try
        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboLoja
    End Function

    Public Function PreenchComboCaixa(ByVal cboLoja As Object, ByVal strConection As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja
        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            If Trim(MdlEmpresaUsu._codigo).Equals("") Then
                sql.Append("SELECT cx_codcaixa, cx_funcao, cx_loja FROM caixa ORDER BY cx_codcaixa ASC")
            Else
                sql.Append("SELECT cx_codcaixa, cx_funcao FROM caixa WHERE cx_loja = '" & MdlEmpresaUsu._codigo & "' ORDER BY cx_codcaixa ASC")
            End If

            cmd = New NpgsqlCommand(sql.ToString, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboLoja.AutoCompleteCustomSource.Clear()
                cboLoja.Items.Clear()
                cboLoja.Refresh()
                While dr.Read

                    If Trim(MdlEmpresaUsu._codigo).Equals("") Then

                        cboLoja.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString & " -> " & dr(2).ToString)
                        cboLoja.Items.Add(dr(0).ToString & " - " & dr(1).ToString & " -> " & dr(2).ToString)
                    Else

                        cboLoja.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                        cboLoja.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                    End If

                End While

                cboLoja.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja
        End Try
        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboLoja
    End Function

    Public Function PreenchComboGrupoContas(ByVal cboGrupo As Object, ByVal strConection As String, ByVal esqEstab As String) As ComboBox
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboGrupo
        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT ds_grupo || ' - '  || ds_descricao FROM " & esqEstab & ".desp001 WHERE ds_tipo = 'G' ORDER BY ds_grupo ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboGrupo.AutoCompleteCustomSource.Clear()
                cboGrupo.Items.Clear()
                cboGrupo.Refresh()

                cboGrupo.AutoCompleteCustomSource.Add("")
                cboGrupo.Items.Add("")
                While dr.Read
                    cboGrupo.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboGrupo.Items.Add(dr(0).ToString)
                End While

                cboGrupo.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboGrupo
        End Try
        dr.Close() : oConn.ClearAllPools() : oConn.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConn = Nothing
        Return cboGrupo
    End Function

    Public Function PreenchComboLoja2Dig(ByVal cboLoja2Dig As Object, ByVal strConection As String) As ComboBox
        Dim oConnLoja As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnLoja.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja2Dig
        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT SUBSTR(g_codig, 4, 2), g_geno FROM geno001 ORDER BY g_codig ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnLoja)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboLoja2Dig.AutoCompleteCustomSource.Clear()
                cboLoja2Dig.Items.Clear()
                cboLoja2Dig.Refresh()
                While dr.Read
                    cboLoja2Dig.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboLoja2Dig.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboLoja2Dig.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja2Dig
        End Try
        dr.Close() : oConnLoja.ClearAllPools() : oConnLoja.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnLoja = Nothing
        Return cboLoja2Dig
    End Function

    Public Function PreenchComboLoja5Dig(ByVal cboLoja As Object, ByVal strConection As String) As ComboBox
        Dim oConnLoja As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnLoja.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja
        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT g_codig, g_geno FROM geno001 ORDER BY g_codig ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnLoja)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboLoja.AutoCompleteCustomSource.Clear()
                cboLoja.Items.Clear()
                cboLoja.Refresh()
                While dr.Read

                    cboLoja.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboLoja.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboLoja.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja
        End Try

        dr.Close() : oConnLoja.ClearAllPools() : oConnLoja.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnLoja = Nothing
        Return cboLoja
    End Function

    Public Function PreenchComboLoja2DigOutras(ByVal cboLoja2Dig As Object, ByVal strConection As String, ByVal codLojaAtual As String) As ComboBox
        Dim oConnLoja As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnLoja.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja2Dig
        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT SUBSTR(g_codig, 4, 2), g_geno FROM geno001 WHERE g_codig <> '" & codLojaAtual & "' ORDER BY g_codig ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnLoja)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboLoja2Dig.AutoCompleteCustomSource.Clear()
                cboLoja2Dig.Items.Clear()
                cboLoja2Dig.Refresh()
                While dr.Read
                    cboLoja2Dig.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboLoja2Dig.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboLoja2Dig.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja2Dig
        End Try
        dr.Close() : oConnLoja.ClearAllPools() : oConnLoja.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnLoja = Nothing
        Return cboLoja2Dig
    End Function

    Public Function PreenchComboLojaVinculo(ByVal cboLoja2Dig As Object, ByVal strConection As String) As ComboBox
        Dim oConnLoja As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnLoja.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja2Dig
        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT SUBSTR(g_codig, 4, 2), g_geno FROM geno001 WHERE g_esquemavinc = '" & MdlEmpresaUsu._esqVinc & "' ORDER BY g_codig ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnLoja)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboLoja2Dig.AutoCompleteCustomSource.Clear()
                cboLoja2Dig.Items.Clear()
                cboLoja2Dig.Refresh()
                While dr.Read
                    cboLoja2Dig.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboLoja2Dig.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboLoja2Dig.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja2Dig
        End Try
        dr.Close() : oConnLoja.ClearAllPools() : oConnLoja.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnLoja = Nothing
        Return cboLoja2Dig
    End Function

    Public Function PreenchComboLoja2Vinculo(ByVal cboLoja As Object, ByVal strConection As String) As ComboBox
        Dim oConnLoja As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnLoja.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja
        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT g_codig, g_geno FROM geno001 WHERE g_esquemavinc = '" & MdlEmpresaUsu._esqVinc & "' ORDER BY g_codig ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnLoja)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboLoja.AutoCompleteCustomSource.Clear()
                cboLoja.Items.Clear()
                cboLoja.Refresh()
                While dr.Read

                    cboLoja.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboLoja.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboLoja.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja
        End Try

        dr.Close() : oConnLoja.ClearAllPools() : oConnLoja.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnLoja = Nothing
        Return cboLoja
    End Function

    Public Function PreenchComboAliqProd(ByVal cboAliquota As Object, ByVal strConection As String) As ComboBox
        Dim oConnLoja As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnLoja.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboAliquota
        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT alq_tipo || ' - ' || 'Interna ' || alq_interna || '; Externa ' || alq_externa FROM aliquotas ORDER BY alq_tipo ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnLoja)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboAliquota.AutoCompleteCustomSource.Clear()
                cboAliquota.Items.Clear()
                cboAliquota.Refresh()
                While dr.Read
                    cboAliquota.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboAliquota.Items.Add(dr(0).ToString)
                End While

                cboAliquota.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboAliquota
        End Try
        dr.Close() : oConnLoja.ClearAllPools() : oConnLoja.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnLoja = Nothing
        Return cboAliquota
    End Function

    Public Function PreenchComboLojaVinculo(ByVal codVinculo As Int16, ByVal cboLoja As Object, _
                                            ByVal strConection As String) As ComboBox
        Dim oConnLoja As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnLoja.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja
        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT SUBSTR(g_codig, 4, 2), g_geno FROM geno001 WHERE g_vinculo = ")
            sql.Append("@g_vinculo ORDER BY g_codig ASC")

            cmd = New NpgsqlCommand(sql.ToString, oConnLoja)
            cmd.Parameters.Add("@g_vinculo", codVinculo)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboLoja.AutoCompleteCustomSource.Clear()
                cboLoja.Items.Clear()
                cboLoja.Refresh()
                While dr.Read
                    cboLoja.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboLoja.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboLoja.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboLoja
        End Try
        dr.Close() : oConnLoja.ClearAllPools() : oConnLoja.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing



        oConnLoja = Nothing
        Return cboLoja
    End Function

    Public Function PreenchComboMunicipios(ByVal uf As String, ByVal cboMun As Object, _
                                           ByVal strConection As String) As ComboBox

        Dim oConnMunicipios As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnMunicipios.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboMun
        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT nome FROM cadmun WHERE sigla_estado = '" & uf & "' ORDER BY nome ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnMunicipios)
            dr = cmd.ExecuteReader
            Dim sstr As String = sql.ToString
            If dr.HasRows = True Then
                cboMun.AutoCompleteCustomSource.Clear()
                cboMun.Items.Clear()
                cboMun.Refresh()
                While dr.Read

                    cboMun.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboMun.Items.Add(dr(0).ToString)
                End While

                cboMun.Refresh()
                cboMun.SelectedIndex = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        dr.Close() : oConnMunicipios.ClearAllPools() : oConnMunicipios.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnMunicipios = Nothing
        Return cboMun
    End Function

    Public Function PreenchComboVendedores(ByVal cboVendedores As Object, ByVal strConection As String) As ComboBox
        Dim oConnVendedor As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnVendedor.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboVendedores
        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT v_codigo, SUBSTR(v_nome, 1, 10) FROM cadvendedor ORDER BY v_codigo ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnVendedor)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboVendedores.AutoCompleteCustomSource.Clear()
                cboVendedores.Items.Clear()
                cboVendedores.Refresh()
                While dr.Read
                    cboVendedores.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboVendedores.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboVendedores.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboVendedores
        End Try

        dr.Close() : oConnVendedor.ClearAllPools() : oConnVendedor.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnVendedor = Nothing
        Return cboVendedores
    End Function

    Public Function PreenchComboVendedoresNomeFull(ByVal cboVendedores As Object, ByVal strConection As String) As ComboBox
        Dim oConnVendedor As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnVendedor.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboVendedores
        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT v_codigo, v_nome FROM cadvendedor ORDER BY v_codigo ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnVendedor)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboVendedores.AutoCompleteCustomSource.Clear()
                cboVendedores.Items.Clear()
                cboVendedores.Refresh()
                While dr.Read
                    cboVendedores.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboVendedores.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboVendedores.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboVendedores
        End Try

        dr.Close() : oConnVendedor.ClearAllPools() : oConnVendedor.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnVendedor = Nothing
        Return cboVendedores
    End Function

    Public Function PreenchComboCoresGrade(ByVal cboCores As Object, ByVal strConection As String) As ComboBox
        Dim oConnCores As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnCores.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCores
        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT cr_seq, SUBSTR(cr_cor, 1, 10) FROM cadcores ORDER BY cr_seq ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnCores)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                cboCores.AutoCompleteCustomSource.Clear()
                cboCores.Items.Clear()
                cboCores.Refresh()
                While dr.Read
                    cboCores.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboCores.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                End While

                cboCores.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCores
        End Try

        dr.Close() : oConnCores.ClearAllPools() : oConnCores.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnCores = Nothing
        Return cboCores
    End Function

    Public Function PreenchComboCodCaixa(ByVal codLoja5Dig As String, ByVal cboCaixa As Object, ByVal strConection As String) As ComboBox
        Dim oConnCaixa As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnCaixa.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCaixa

        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT cx_codcaixa FROM caixa WHERE cx_loja = '" & codLoja5Dig & "' ORDER BY cx_codcaixa")
            cmd = New NpgsqlCommand(sql.ToString, oConnCaixa)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboCaixa.AutoCompleteCustomSource.Clear()
                cboCaixa.Items.Clear() : cboCaixa.Refresh()
                While dr.Read

                    cboCaixa.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboCaixa.Items.Add(dr(0).ToString)
                End While

                cboCaixa.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCaixa
        End Try

        dr.Close() : oConnCaixa.ClearAllPools() : oConnCaixa.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnCaixa = Nothing
        Return cboCaixa
    End Function

    Public Function PreenchComboPlacaVeic(ByVal cboPlacaVeic As Object, ByVal strConection As String) As ComboBox
        Dim oConnPlacaVeic As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnPlacaVeic.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboPlacaVeic

        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT aut_id, aut_placa FROM cadautomovel ORDER BY aut_id ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnPlacaVeic)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboPlacaVeic.AutoCompleteCustomSource.Clear()
                cboPlacaVeic.Items.Clear() : cboPlacaVeic.Refresh()
                While dr.Read

                    cboPlacaVeic.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                    cboPlacaVeic.Items.Add(dr(0).ToString & " | " & dr(1).ToString)
                End While

                cboPlacaVeic.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboPlacaVeic
        End Try

        dr.Close() : oConnPlacaVeic.ClearAllPools() : oConnPlacaVeic.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnPlacaVeic = Nothing
        Return cboPlacaVeic
    End Function

    Public Function PreenchComboPlacaVeicNFe(ByVal cboPlacaVeic As Object, ByVal strConection As String) As ComboBox
        Dim oConnPlacaVeic As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnPlacaVeic.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboPlacaVeic

        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT aut_placa FROM cadautomovel ORDER BY aut_placa ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnPlacaVeic)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboPlacaVeic.AutoCompleteCustomSource.Clear()
                cboPlacaVeic.Items.Clear() : cboPlacaVeic.Refresh()
                While dr.Read

                    cboPlacaVeic.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboPlacaVeic.Items.Add(dr(0).ToString)
                End While

                cboPlacaVeic.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboPlacaVeic
        End Try

        dr.Close() : oConnPlacaVeic.ClearAllPools() : oConnPlacaVeic.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnPlacaVeic = Nothing
        Return cboPlacaVeic
    End Function

    Public Function PreenchComboCondPagto1(ByVal cboCondpagto As Object, ByVal strConection As String) As ComboBox

        Dim oConnCondpagto As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnCondpagto.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCondpagto
        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT cpg_descricao FROM condpagto WHERE cpg_tipo = 1 ORDER BY LENGTH(cpg_descricao), cpg_descricao ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnCondpagto)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboCondpagto.AutoCompleteCustomSource.Clear()
                cboCondpagto.Items.Clear()
                cboCondpagto.Refresh()
                While dr.Read
                    cboCondpagto.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboCondpagto.Items.Add(dr(0).ToString)
                End While


                cboCondpagto.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCondpagto
        End Try

        dr.Close() : oConnCondpagto.ClearAllPools() : oConnCondpagto.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing
        oConnCondpagto = Nothing



        Return cboCondpagto
    End Function

    Public Function PreenchComboCondPagto2(ByVal cboCondpagto As Object, ByVal strConection As String) As ComboBox

        Dim oConnCondpagto As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnCondpagto.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCondpagto
        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT cpg_descricao FROM condpagto WHERE cpg_tipo = 2 ORDER BY LENGTH(cpg_descricao), cpg_descricao ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnCondpagto)
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then

                cboCondpagto.AutoCompleteCustomSource.Clear()
                cboCondpagto.Items.Clear()
                cboCondpagto.Refresh()
                While dr.Read
                    cboCondpagto.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboCondpagto.Items.Add(dr(0).ToString)
                End While


                cboCondpagto.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboCondpagto
        End Try

        dr.Close() : oConnCondpagto.ClearAllPools() : oConnCondpagto.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing
        oConnCondpagto = Nothing



        Return cboCondpagto
    End Function

    Public Function PreenchComboVinculo(ByVal cboVinculo As Object, ByVal strConection As String) As ComboBox

        Dim oConnVinculo As NpgsqlConnection = New NpgsqlConnection(strConection)
        Try
            oConnVinculo.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboVinculo
        End Try

        If oConnVinculo.State = ConnectionState.Open Then
            Dim Cmd As New NpgsqlCommand
            Dim Sql As New StringBuilder
            Dim dr As NpgsqlDataReader

            Try

                Sql.Append("SELECT v_codvinc, v_descricao FROM vinculo ORDER BY v_codvinc ASC")
                Cmd = New NpgsqlCommand(Sql.ToString, oConnVinculo)
                dr = Cmd.ExecuteReader

                If dr.HasRows = True Then
                    cboVinculo.AutoCompleteCustomSource.Clear()
                    cboVinculo.Items.Clear()
                    cboVinculo.Refresh()
                    While dr.Read
                        cboVinculo.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString)
                        cboVinculo.Items.Add(dr(0).ToString & " - " & dr(1).ToString)
                    End While

                    cboVinculo.SelectedIndex = -1
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return cboVinculo
            End Try
            dr.Close() : oConnVinculo.ClearAllPools() : oConnVinculo.Close()
            Cmd = Nothing : Sql = Nothing : dr = Nothing
        End If

        oConnVinculo = Nothing
        Return cboVinculo
    End Function

    Public Function PreenchComboEsquema(ByVal cboVinculo As Object, ByVal strConection As String) As ComboBox

        Dim oConnVinculo As NpgsqlConnection = New NpgsqlConnection(strConection)
        Try
            oConnVinculo.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboVinculo
        End Try

        If oConnVinculo.State = ConnectionState.Open Then
            Dim Cmd As New NpgsqlCommand
            Dim Sql As New StringBuilder
            Dim dr As NpgsqlDataReader

            Try

                Sql.Append("SELECT schema_name FROM information_schema.schemata WHERE ")
                Sql.Append("SUBSTR(information_schema.schemata.schema_name, 1, 3) <> 'pg_' AND ")
                Sql.Append("SUBSTR(information_schema.schemata.schema_name, 1, 3) <> 'inf' AND ")
                Sql.Append("SUBSTR(information_schema.schemata.schema_name, 1, 3) <> 'pub' ")
                Cmd = New NpgsqlCommand(Sql.ToString, oConnVinculo)
                dr = Cmd.ExecuteReader

                If dr.HasRows = True Then
                    cboVinculo.AutoCompleteCustomSource.Clear()
                    cboVinculo.Items.Clear()
                    cboVinculo.Refresh()
                    While dr.Read
                        cboVinculo.AutoCompleteCustomSource.Add(dr(0).ToString)
                        cboVinculo.Items.Add(dr(0).ToString)
                    End While

                    cboVinculo.SelectedIndex = -1
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                oConnVinculo.ClearAllPools() : oConnVinculo.Close() : Return cboVinculo
            End Try

            dr.Close() : oConnVinculo.ClearAllPools() : oConnVinculo.Close()
            Cmd = Nothing : Sql = Nothing : dr = Nothing
        End If


        oConnVinculo = Nothing
        Return cboVinculo
    End Function

    Public Function PreenchComboEsquemaLojas(ByVal cboVinculo As Object, ByVal strConection As String) As ComboBox

        Dim oConnVinculo As NpgsqlConnection = New NpgsqlConnection(strConection)
        Try
            oConnVinculo.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboVinculo
        End Try

        If oConnVinculo.State = ConnectionState.Open Then
            Dim Cmd As New NpgsqlCommand
            Dim Sql As New StringBuilder
            Dim dr As NpgsqlDataReader

            Try

                Sql.Append("SELECT schema_name FROM information_schema.schemata WHERE ")
                Sql.Append("SUBSTR(information_schema.schemata.schema_name, 1, 3) <> 'pg_' AND ")
                Sql.Append("SUBSTR(information_schema.schemata.schema_name, 1, 3) <> 'inf' AND ")
                Sql.Append("SUBSTR(information_schema.schemata.schema_name, 1, 3) <> 'pub' AND ")
                Sql.Append("SUBSTR(information_schema.schemata.schema_name, 1, 4) = 'loja' ")
                Sql.Append("ORDER BY SUBSTR(information_schema.schemata.schema_name, 1, 4) ASC")

                Cmd = New NpgsqlCommand(Sql.ToString, oConnVinculo)
                dr = Cmd.ExecuteReader

                If dr.HasRows = True Then
                    cboVinculo.AutoCompleteCustomSource.Clear()
                    cboVinculo.Items.Clear()
                    cboVinculo.Refresh()
                    While dr.Read
                        cboVinculo.AutoCompleteCustomSource.Add(dr(0).ToString)
                        cboVinculo.Items.Add(dr(0).ToString)
                    End While

                    cboVinculo.SelectedIndex = -1
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                oConnVinculo.ClearAllPools() : oConnVinculo.Close() : Return cboVinculo
            End Try

            dr.Close() : oConnVinculo.ClearAllPools() : oConnVinculo.Close()
            Cmd = Nothing : Sql = Nothing : dr = Nothing
        End If


        oConnVinculo = Nothing
        Return cboVinculo
    End Function

    Public Function PreenchComboEsquemaVinc(ByVal cboVinculo As Object, ByVal strConection As String) As ComboBox

        Dim oConnVinculo As NpgsqlConnection = New NpgsqlConnection(strConection)
        Try
            oConnVinculo.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboVinculo
        End Try

        If oConnVinculo.State = ConnectionState.Open Then
            Dim Cmd As New NpgsqlCommand
            Dim Sql As New StringBuilder
            Dim dr As NpgsqlDataReader

            Try

                Sql.Append("SELECT schema_name FROM information_schema.schemata WHERE ")
                Sql.Append("SUBSTR(information_schema.schemata.schema_name, 1, 3) <> 'pg_' AND ")
                Sql.Append("SUBSTR(information_schema.schemata.schema_name, 1, 3) <> 'inf' AND ")
                Sql.Append("SUBSTR(information_schema.schemata.schema_name, 1, 3) <> 'pub' AND ")
                Sql.Append("SUBSTR(information_schema.schemata.schema_name, 1, 4) = 'vinc' ")
                Sql.Append("ORDER BY SUBSTR(information_schema.schemata.schema_name, 1, 4) ASC")
                Cmd = New NpgsqlCommand(Sql.ToString, oConnVinculo)
                dr = Cmd.ExecuteReader

                If dr.HasRows = True Then
                    cboVinculo.AutoCompleteCustomSource.Clear()
                    cboVinculo.Items.Clear()
                    cboVinculo.Refresh()
                    While dr.Read
                        cboVinculo.AutoCompleteCustomSource.Add(dr(0).ToString)
                        cboVinculo.Items.Add(dr(0).ToString)
                    End While

                    cboVinculo.SelectedIndex = -1
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                oConnVinculo.ClearAllPools() : oConnVinculo.Close() : Return cboVinculo
            End Try

            dr.Close() : oConnVinculo.ClearAllPools() : oConnVinculo.Close()
            Cmd = Nothing : Sql = Nothing : dr = Nothing
        End If


        oConnVinculo = Nothing
        Return cboVinculo
    End Function

    Public Function PreenchComboRotas(ByVal cboRotas As Object, ByVal strConection As String) As ComboBox

        Dim oConnection As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboRotas
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim Sql As New StringBuilder
        Dim Dr As NpgsqlDataReader

        Try

            Sql.Append("SELECT rt_rota, rt_destino FROM cadrotas ORDER BY rt_rota ASC")
            Cmd = New NpgsqlCommand(Sql.ToString, oConnection)
            Dr = Cmd.ExecuteReader

            If Dr.HasRows = True Then

                cboRotas.AutoCompleteCustomSource.Clear()
                cboRotas.Items.Clear() : cboRotas.Refresh()
                While Dr.Read
                    cboRotas.AutoCompleteCustomSource.Add(Dr(0).ToString & " | " & Dr(1).ToString)
                    cboRotas.Items.Add(Dr(0).ToString & "  |  " & Dr(1).ToString)
                End While


                cboRotas.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboRotas
        End Try
        Dr.Close() : oConnection.ClearAllPools() : oConnection.Close()
        Cmd = Nothing : Sql = Nothing : Dr = Nothing
        oConnection = Nothing


        Return cboRotas
    End Function

    Public Function PreenchComboRotas2Dig(ByVal cboRotas As Object, ByVal strConection As String) As ComboBox

        Dim oConnection As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboRotas
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim Sql As New StringBuilder
        Dim Dr As NpgsqlDataReader

        Try

            Sql.Append("SELECT rt_rota, rt_destino FROM cadrotas ORDER BY rt_rota ASC")
            Cmd = New NpgsqlCommand(Sql.ToString, oConnection)
            Dr = Cmd.ExecuteReader

            If Dr.HasRows = True Then

                cboRotas.AutoCompleteCustomSource.Clear()
                cboRotas.Items.Clear() : cboRotas.Refresh()
                While Dr.Read
                    cboRotas.AutoCompleteCustomSource.Add(Format(Dr(0), "00") & " | " & Dr(1).ToString)
                    cboRotas.Items.Add(Format(Dr(0), "00") & "  |  " & Dr(1).ToString)
                End While


                cboRotas.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboRotas
        End Try
        Dr.Close() : oConnection.ClearAllPools() : oConnection.Close()
        Cmd = Nothing : Sql = Nothing : Dr = Nothing
        oConnection = Nothing


        Return cboRotas
    End Function

    Public Function PreenchComboGerente(ByVal cboGerente As Object, ByVal strConection As String) As ComboBox

        Dim oConnection As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboGerente
        End Try


        Dim Cmd As New NpgsqlCommand
        Dim Sql As New StringBuilder
        Dim Dr As NpgsqlDataReader

        Try

            Sql.Append("SELECT gr_gerente FROM cadgerente ORDER BY cadgerente ASC")
            Cmd = New NpgsqlCommand(Sql.ToString, oConnection)
            Dr = Cmd.ExecuteReader

            If Dr.HasRows = True Then

                cboGerente.AutoCompleteCustomSource.Clear()
                cboGerente.Items.Clear() : cboGerente.Refresh()
                While Dr.Read

                    cboGerente.AutoCompleteCustomSource.Add(Dr(0).ToString)
                    cboGerente.Items.Add(Dr(0).ToString)
                End While


                cboGerente.SelectedIndex = -1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboGerente
        End Try
        Dr.Close() : oConnection.ClearAllPools() : oConnection.Close()
        Cmd = Nothing : Sql = Nothing : Dr = Nothing
        oConnection = Nothing


        Return cboGerente
    End Function

#End Region

#Region "Funções de Impressão..."

    Public Function Exibe_cabecalho(ByVal strCab As String, ByVal espacoInicial As Integer, _
                                    ByVal totalFinal As Integer) As String
        Dim StrCampo As String
        Dim TotStr, totFinal As Integer

        TotStr = Len(strCab)
        totFinal = (totalFinal - (TotStr + espacoInicial)) / 2
        If totFinal >= 0 Then
            StrCampo = Space(espacoInicial) + RTrim(strCab) + Space(totFinal)
        Else
            StrCampo = Mid(strCab, 1, 100)
        End If

        Return (StrCampo)
    End Function

    Public Function Exibe_cabefirma(ByVal strCab As String) As String
        Dim StrCampo As String
        Dim TotStr, totMed As Integer

        TotStr = Len(strCab)
        totMed = (79 - TotStr)
        StrCampo = RTrim(strCab) + Space(totMed)
        Return (StrCampo)
    End Function
    ' Função p/ retornar a quantidade de String p/ formatar Formulario de Impressão a direita
    Public Function Exibe_Str(ByVal text As String, ByVal StrTot As Integer) As String
        Dim StrCampo As String
        Dim TotStr As Integer
        '             4
        TotStr = Len(text)
        'If TotStr = StrTot Then
        '    StrTot = StrTot + 1
        'End If
        If TotStr > StrTot Then            ' Verifica se Total de String lida é Maior que Parâmetros
            TotStr = StrTot                ' em case positivo equipara quantidades
            text = Mid(text, 1, StrTot)    ' e abstrai string excedentes
        End If
        '             4                  6        4 = 2
        StrCampo = text + Space(StrTot - TotStr)

        Return (StrCampo)
    End Function

    ' Função p/ retornar a quantidade de String p/ formatar Formulario de Impressão a direita
    Public Function Exibe_StrEsquerda(ByVal text As String, ByVal StrTot As Integer) As String
        Dim StrCampo As String
        Dim TotStr As Integer
        '             4
        TotStr = Len(text)
        'If TotStr = StrTot Then
        '    StrTot = StrTot + 1
        'End If
        If TotStr > StrTot Then            ' Verifica se Total de String lida é Maior que Parâmetros
            TotStr = StrTot                ' em case positivo equipara quantidades
            text = Mid(text, 1, StrTot)    ' e abstrai string excedentes
        End If
        '             4                  6        4 = 2
        StrCampo = text + Space(StrTot - TotStr)

        Return (StrCampo)
    End Function

    ' Função p/ retornar a quantidade de String p/ formatar Formulario de Impressão a esquerda
    Public Function Exibe_StrDireita(ByVal text As String, ByVal StrTot As Integer) As String
        Dim StrCampo As String
        Dim TotStr As Integer
        '             4
        TotStr = Len(text)
        'If TotStr = StrTot Then
        '    StrTot = StrTot + 1
        'End If
        If TotStr > StrTot Then            ' Verifica se Total de String lida é Maior que Parâmetros
            TotStr = StrTot                ' em case positivo equipara quantidades
            text = Mid(text, 1, StrTot)    ' e abstrai string excedentes
        End If
        '             4                  6        4 = 2
        StrCampo = Space(StrTot - TotStr) + text

        Return (StrCampo)
    End Function

    ' Função p/ retornar a quantidade de String p/ formatar Formulario de Impressão a esquerda
    Public Function Centraliza_Str(ByVal text As String, ByVal TotCaracPagina As Integer) As String
        Dim StrCampo As String
        Dim TotStr, mediaCaracIni, mediaCaracFin, TotEspaco As Integer

        '             4
        TotStr = text.Length
        TotEspaco = (TotCaracPagina - TotStr)
        mediaCaracIni = (TotEspaco \ 2)
        mediaCaracFin = (TotEspaco - mediaCaracIni)

        '             4                  6        4 = 2
        StrCampo = Space(mediaCaracIni) & text & Space(mediaCaracFin)

        Return (StrCampo.ToUpper)
    End Function

    ' Função p/ retornar a quantidade de String p/ formatar Formulario de Impressão a esquerda
    Public Function Centraliza_StrTrataLeft(ByVal text As String, ByVal TotCaracPagina As Integer, ByVal left As Integer) As String
        Dim StrCampo As String
        Dim TotStr, mediaCaracIni, mediaCaracFin, TotEspaco As Integer

        '             4
        TotStr = text.Length
        TotEspaco = (TotCaracPagina - TotStr)
        mediaCaracIni = (TotEspaco \ 2)
        mediaCaracFin = (TotEspaco - mediaCaracIni)

        '             4                  6        4 = 2
        If left > mediaCaracIni Then
            StrCampo = Space(mediaCaracIni) & text & Space(mediaCaracFin)
        Else
            StrCampo = Space((mediaCaracIni - left)) & text & Space(mediaCaracFin)
        End If


        Return (StrCampo.ToUpper)
    End Function

    Public Function Centraliza_StrTrataRight(ByVal text As String, ByVal TotCaracPagina As Integer, ByVal right As Integer) As String
        Dim StrCampo As String
        Dim TotStr, mediaCaracIni, mediaCaracFin, TotEspaco As Integer

        '             4
        TotStr = text.Length
        TotEspaco = (TotCaracPagina - TotStr)
        mediaCaracIni = (TotEspaco \ 2)
        mediaCaracFin = (TotEspaco - mediaCaracIni)

        '             4                  6        4 = 2
        If right > mediaCaracFin Then
            StrCampo = Space(mediaCaracIni) & text & Space(mediaCaracFin)
        Else
            StrCampo = Space(mediaCaracIni) & text & Space((mediaCaracFin - right))
        End If


        Return (StrCampo.ToUpper)
    End Function

    Public Function Centraliza_StrTrataLeftRight(ByVal text As String, ByVal TotCaracPagina As Integer, _
                                                 ByVal left As Integer, ByVal right As Integer) As String
        Dim StrCampo As String
        Dim TotStr, mediaCaracIni, mediaCaracFin, TotEspaco As Integer

        '             4
        TotStr = text.Length
        TotEspaco = (TotCaracPagina - TotStr)
        mediaCaracIni = (TotEspaco \ 2)
        mediaCaracFin = (TotEspaco - mediaCaracIni)

        '             4                  6        4 = 2
        If (left > mediaCaracIni) AndAlso (right > mediaCaracFin) Then

            StrCampo = Space(mediaCaracIni) & text & Space(mediaCaracFin)

        ElseIf left > mediaCaracIni Then

            StrCampo = Space(mediaCaracIni) & text & Space((mediaCaracFin - right))

        ElseIf right > mediaCaracFin Then

            StrCampo = Space((mediaCaracIni - left)) & text & Space(mediaCaracFin)

        Else
            StrCampo = Space((mediaCaracIni - left)) & text & Space((mediaCaracFin - right))
        End If


        Return (StrCampo.ToUpper)
    End Function

    ' Função p/ retornar a quantidade de String tipo Moeda p/ formatar Formulario de Impressão
    Public Function Exibe_Num(ByVal text As Double, ByVal StrTot As Integer) As String
        Dim StrCampo, StrCampo1 As String
        Dim TotStr As Integer
        ' Formata campo e converte p/ String c/ LImite do campo
        StrCampo1 = CStr(Format(text, "###,##0.00"))

        TotStr = Len(StrCampo1)            ' Calcula a quantidade de String
        StrCampo = Space(StrTot - TotStr) + LTrim(StrCampo1)

        Return (StrCampo)
    End Function

#End Region

#Region "Funções de Relatório"

    ' ######################################################################################
    '       RELATÓRIO PARA * ORÇAMENTO * (IMPRESSORA MATRICIAL)
    'Cabeçalho da Loja
    Public Sub GravCabLojOrcamentoMatricial(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlLoja As New StringBuilder
            Dim cmdLoja As NpgsqlCommand
            Dim drLoja As NpgsqlDataReader

            sqlLoja.Append(consulta)

            cmdLoja = New NpgsqlCommand(sqlLoja.ToString, oConnBDGENOV)
            drLoja = cmdLoja.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja As String

            nomeLoja = "" : ufLoja = "" : enderLoja = "" : cidLoja = "" : foneLoja = ""
            While drLoja.Read

                nomeLoja = drLoja(0).ToString : enderLoja = drLoja(1).ToString
                foneLoja = drLoja(2).ToString : ufLoja = drLoja(3).ToString : cidLoja = drLoja(4).ToString

            End While
            drLoja.Close() : cmdLoja = Nothing : sqlLoja = Nothing : drLoja = Nothing


            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = " Empresa: " & Exibe_StrEsquerda(nomeLoja, 36) & " " '47
            strLinha += Exibe_StrDireita("Ender.: " & enderLoja, 38) & " " '31
            s.EscreveLn(Exibe_Str(strLinha, 85))

            strLinha = " Cidade: " & Exibe_StrEsquerda(cidLoja, 34) & " " '38
            strLinha += "UF: " & Exibe_StrEsquerda(ufLoja, 2) & " " '7
            strLinha += Exibe_StrEsquerda("Fone: " & foneLoja, 16) & " " '17
            strLinha += Exibe_StrDireita("Data: " & Format(Date.Now, "dd/MM/yyyy"), 17) '17
            s.EscreveLn(Exibe_Str(strLinha, 85))


            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Cabeçalho do Cliente
    Public Sub GravCabCliOrcamentoMatricial(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal codCliente As String, _
                                     ByVal numPedido As String, ByVal dtEmiss As String, _
                                     ByVal codVendedor As String, ByVal condicao As String, _
                                      ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlClient As New StringBuilder
            Dim cmdClient As NpgsqlCommand
            Dim drClient As NpgsqlDataReader

            'Traz dados do CLIENTE do Pedido...
            sqlClient.Append(consulta)

            cmdClient = New NpgsqlCommand(sqlClient.ToString, oConnBDGENOV)
            drClient = cmdClient.ExecuteReader

            Dim nomeClient, cnpjCliente, cpfCliente, enderecoCli, ufClient, cidClient, bairroClient As String
            Dim foneClient, faxClient, celularCliente, nomeFantasCli, inscrCliente As String

            nomeClient = "" : cnpjCliente = "" : cpfCliente = "" : enderecoCli = "" : ufClient = "" : cidClient = ""
            bairroClient = "" : foneClient = "" : faxClient = "" : celularCliente = "" : nomeFantasCli = ""
            inscrCliente = ""

            While drClient.Read

                nomeClient = drClient(0).ToString : cnpjCliente = drClient(1).ToString
                cpfCliente = drClient(2).ToString : enderecoCli = drClient(3).ToString
                cidClient = drClient(4).ToString : ufClient = drClient(5).ToString
                bairroClient = drClient(6).ToString : foneClient = drClient(7).ToString
                faxClient = drClient(8).ToString : celularCliente = drClient(9).ToString
                nomeFantasCli = drClient(10).ToString : inscrCliente = drClient(11).ToString

            End While
            drClient.Close() : drClient = Nothing

            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            's.WriteLine("+------------------------------------------------------------------------------+")
            'NOME DO CLIENTE...
            strLinha = " " & Exibe_StrEsquerda("Cliente: " & nomeClient, 42) & " " '54
            'CNPJ/CPF e INSCRICÃO...
            If Not cnpjCliente.Equals("") Then

                strLinha += Exibe_StrEsquerda("CNPJ: " & String.Format("{0:00\.000\.000\/0000\-00}", Convert.ToInt64(cnpjCliente)), 30) & " " '31
            Else

                strLinha += Exibe_StrEsquerda("CPF: " & String.Format("{0:000\.000\.000\-00}", Convert.ToInt64(cpfCliente)), 30) & " " '31
            End If
            strLinha += Exibe_StrDireita("Pag.: " & "001", 10) & " " '31
            s.EscreveLn(Exibe_Str(strLinha, 85))


            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho do Cliente:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Grava Itens
    Public Sub GravItensOrcamentoMatricial(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal numOrcamento As String, ByVal idOrca1 As String, _
                             ByVal codCliente As String, ByVal nomeCliente As String, ByRef shouldReturn As Boolean)
        shouldReturn = False
        Dim _valorZERO As Int16 = 0
        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mCodProd, mNomeProd, undProd, strLinha As String
            Dim mQtdeProd, mVlProd, mVlTotProd As Double
            Dim mSomaTotProd, mSomaBrutoProd, mSomaDescProd, mSomaVolBrutProd As Double
            strLinha = "" : undProd = ""
            Dim mCont1, mCont2, index As Integer

            Try
                oConnBDGENOV.Open()

            Catch ex As Exception
            End Try

            Dim sqlItem As New StringBuilder
            Dim cmdItem As NpgsqlCommand
            Dim drItem As NpgsqlDataReader
            Dim mContItens As Integer = _valorZERO, mContItensPg As Integer = _valorZERO, mContPg As Integer = _valorZERO


            sqlItem.Append(consulta)

            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
            drItem = cmdItem.ExecuteReader

            If drItem.HasRows = True Then
                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                's.WriteLine("-------------------------------------------------------------------------------------")
                'SELECT o2.no_codpr, o2.no_qtde, o2.no_und, el.s_descricao, o2.no_prunit, o2.no_prtot, o2.no_filial, '', o2.no_vldesc, o2.no_pesobruto, o2.no_vlsub ") '10
                s.EscreveLn("Cod.   Descrição.                                 Qtde       Valor             TOTAL ")
                '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZ  999.99      999.99        9,999,999.99  
                s.EscreveLn("-------------------------------------------------------------------------------------")

                mCont1 = 27
            End If

            mSomaTotProd = _valorZERO
            mContPg = 1
            While drItem.Read


                If mContPg = 1 AndAlso mContItensPg = 47 Then

                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    s.EscreveLn(" *** CONTINUACAO DO ORÇAMENTO TRANSPORTADO PARA FOLHA SEGUINTE **  ")
                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    'Quebra 10 Linhas para passar para a próxima folha...
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)



                    mContPg += 1
                    s.EscreveLn("                    C O N T I N U A C A O . . .        FOLHA: " & String.Format("{0:D3}", mContPg))
                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    s.EscreveLn(Exibe_StrEsquerda("| Cliente : " & codCliente & "-" & nomeCliente, 69) & " |ORÇ: " & numOrcamento & "|")
                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    s.EscreveLn("")
                    s.EscreveLn("Cod.   Descrição.                                 Qtde       Valor             TOTAL ")
                    '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZ  999.99      999.99        9,999,999.99  
                    s.EscreveLn("-------------------------------------------------------------------------------------")

                    mContItensPg = _valorZERO


                ElseIf mContPg > 1 AndAlso mContItensPg = 50 Then

                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    s.EscreveLn(" *** CONTINUACAO DO ORÇAMENTO TRANSPORTADO PARA FOLHA SEGUINTE **  ")
                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    'Quebra 10 Linhas para passar para a próxima folha...
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)



                    mContPg += 1
                    s.EscreveLn("                    C O N T I N U A C A O . . .        FOLHA: " & String.Format("{0:D3}", mContPg))
                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    s.EscreveLn(Exibe_StrEsquerda("| Cliente : " & codCliente & "-" & nomeCliente, 69) & " |ORÇ: " & numOrcamento & "|")
                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    s.EscreveLn("")
                    s.EscreveLn("Cod.   Descrição.                                 Qtde       Valor             TOTAL ")
                    '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZ  999.99      999.99        9,999,999.99  
                    s.EscreveLn("-------------------------------------------------------------------------------------")

                    mContItensPg = _valorZERO
                    mCont2 = 30

                End If

                mCodProd = drItem(0).ToString
                mQtdeProd = drItem(1)
                undProd = drItem(2).ToString
                mNomeProd = drItem(3).ToString
                mVlProd = drItem(4) : If drItem(10) > 0 Then mVlProd = drItem(4) + Round(drItem(10) / mQtdeProd, 2)
                mVlTotProd = drItem(5)

                mSomaTotProd += mVlTotProd
                mSomaBrutoProd += Round((mVlProd * mQtdeProd), 2)
                mSomaDescProd += drItem(8)
                mSomaVolBrutProd += drItem(9)

                strLinha = Exibe_StrEsquerda(mCodProd, 6) & " " & _
                Exibe_StrEsquerda(mNomeProd, 40) & " " & _
                Exibe_StrDireita(Format(mQtdeProd, "##0.00"), 6) & "  " & _
                Exibe_StrDireita(Format(mVlProd, "#,##0.00"), 10) & "  " & _
                Exibe_StrDireita(Format(mVlTotProd, "#,###,##0.00"), 16)

                s.EscreveLn(Exibe_Str(strLinha, 85))
                mContItens += 1 : mContItensPg += 1
                mCont1 -= 1 : mCont2 -= 1

                'mContItens += 27 : mContItensPg += 27
                'mCont1 -= 27 : mCont2 -= 27

                'mContItens += 30 : mContItensPg += 30
                'mCont1 -= 30 : mCont2 -= 30
            End While
            drItem.Close()

            If (37 - mContItensPg) > 22 Then
                For index = 1 To 20
                    s.EscreveLn("")
                Next
            End If


            If mSomaTotProd > _valorZERO Then

                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.EscreveLn("------------------------------------------------------------------------------------+")
                strLinha = Exibe_StrEsquerda(" TOTAIS ---> ", 25) & Exibe_StrDireita(mContItens, 5)
                If mContItens > 1 Then
                    strLinha += " - Serviços"
                Else
                    strLinha += " - Serviço "
                End If
                strLinha = Exibe_StrEsquerda(strLinha, 40)
                strLinha += Exibe_StrDireita("| " & Exibe_StrDireita(Format(Round(mSomaTotProd, 2), "#,###,##0.00"), 12) & " |", 46)
                s.EscreveLn(Exibe_Str(strLinha, 85))
                s.EscreveLn("------------------------------------------------------------------------------------+")


                s.EscreveLn("")
            End If

            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
            mNomeProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing

            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) do Orçamento", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub
    ' ######################################################################################



    ' ######################################################################################
    '       RELATÓRIO PARA * AGENDAMENTO * (IMPRESSORA MATRICIAL)
    'Cabeçalho da Loja
    Public Sub GravCabLojAgendMatricial(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlLoja As New StringBuilder
            Dim cmdLoja As NpgsqlCommand
            Dim drLoja As NpgsqlDataReader

            sqlLoja.Append(consulta)

            cmdLoja = New NpgsqlCommand(sqlLoja.ToString, oConnBDGENOV)
            drLoja = cmdLoja.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja As String

            nomeLoja = "" : ufLoja = "" : enderLoja = "" : cidLoja = "" : foneLoja = ""
            While drLoja.Read

                nomeLoja = drLoja(0).ToString : enderLoja = drLoja(1).ToString
                foneLoja = drLoja(2).ToString : ufLoja = drLoja(3).ToString : cidLoja = drLoja(4).ToString

            End While
            drLoja.Close() : cmdLoja = Nothing : sqlLoja = Nothing : drLoja = Nothing


            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = " Empresa: " & Exibe_StrEsquerda(nomeLoja, 36) & " " '47
            strLinha += Exibe_StrDireita("Ender.: " & enderLoja, 38) & " " '31
            s.EscreveLn(Exibe_Str(strLinha, 85))

            strLinha = " Cidade: " & Exibe_StrEsquerda(cidLoja, 34) & " " '38
            strLinha += "UF: " & Exibe_StrEsquerda(ufLoja, 2) & " " '7
            strLinha += Exibe_StrEsquerda("Fone: " & foneLoja, 16) & " " '17
            strLinha += Exibe_StrDireita("Data: " & Format(Date.Now, "dd/MM/yyyy"), 17) '17
            s.EscreveLn(Exibe_Str(strLinha, 85))


            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Cabeçalho do Cliente
    Public Sub GravCabCliAgendMatricial(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal codCliente As String, _
                                     ByVal numPedido As String, ByVal dtEmiss As String, _
                                     ByVal codVendedor As String, ByVal condicao As String, _
                                      ByVal loja As String, ByVal Agend As Cl_Agendamento1, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlClient As New StringBuilder
            Dim cmdClient As NpgsqlCommand
            Dim drClient As NpgsqlDataReader

            'Traz dados do CLIENTE do Pedido...
            sqlClient.Append(consulta)

            cmdClient = New NpgsqlCommand(sqlClient.ToString, oConnBDGENOV)
            drClient = cmdClient.ExecuteReader

            Dim nomeClient, cnpjCliente, cpfCliente, enderecoCli, ufClient, cidClient, bairroClient As String
            Dim foneClient, faxClient, celularCliente, nomeFantasCli, inscrCliente As String

            nomeClient = "" : cnpjCliente = "" : cpfCliente = "" : enderecoCli = "" : ufClient = "" : cidClient = ""
            bairroClient = "" : foneClient = "" : faxClient = "" : celularCliente = "" : nomeFantasCli = ""
            inscrCliente = ""

            While drClient.Read

                nomeClient = drClient(0).ToString : cnpjCliente = drClient(1).ToString
                cpfCliente = drClient(2).ToString : enderecoCli = drClient(3).ToString
                cidClient = drClient(4).ToString : ufClient = drClient(5).ToString
                bairroClient = drClient(6).ToString : foneClient = drClient(7).ToString
                faxClient = drClient(8).ToString : celularCliente = drClient(9).ToString
                nomeFantasCli = drClient(10).ToString : inscrCliente = drClient(11).ToString

            End While
            drClient.Close() : drClient = Nothing

            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            's.WriteLine("+------------------------------------------------------------------------------+")
            'NOME DO CLIENTE...
            strLinha = " " & Exibe_StrEsquerda("Cliente: " & nomeClient, 42) & " " '54
            'DOUTOR
            If Agend.a_doutor.Equals("") = False Then
                strLinha += Exibe_StrEsquerda("Dentista: " & Agend.a_doutor, 30) & " " '31
            Else
                strLinha += Exibe_StrEsquerda("", 30) & " " '31
            End If
            strLinha += Exibe_StrDireita("Pag.: " & "001", 10) & " " '31
            s.EscreveLn(Exibe_Str(strLinha, 85))


            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho do Cliente:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Grava Itens
    Public Sub GravServicosAgendMatricial(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal numOrcamento As String, ByVal idOrca1 As String, _
                             ByVal codCliente As String, ByVal nomeCliente As String, ByRef shouldReturn As Boolean)
        shouldReturn = False
        Dim _valorZERO As Int16 = 0
        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mCodProd, mNomeProd, undProd, strLinha As String
            Dim mQtdeProd, mVlProd, mVlTotProd As Double
            Dim mSomaTotProd, mSomaBrutoProd, mSomaDescProd, mSomaVolBrutProd As Double
            strLinha = "" : undProd = ""
            Dim mCont1, mCont2, index As Integer

            Try
                oConnBDGENOV.Open()

            Catch ex As Exception
            End Try

            Dim sqlItem As New StringBuilder
            Dim cmdItem As NpgsqlCommand
            Dim drItem As NpgsqlDataReader
            Dim mContItens As Integer = _valorZERO, mContItensPg As Integer = _valorZERO, mContPg As Integer = _valorZERO


            sqlItem.Append(consulta)

            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
            drItem = cmdItem.ExecuteReader

            If drItem.HasRows = True Then
                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                's.WriteLine("-------------------------------------------------------------------------------------")
                s.EscreveLn("Cod.   Descrição.                                       Qtde.     Valor        TOTAL ")
                '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxx 99.99  9,999.99 9,999,999.99  
                s.EscreveLn("-------------------------------------------------------------------------------------")

                mCont1 = 27
            End If

            mSomaTotProd = _valorZERO
            mContPg = 1
            While drItem.Read


                If mContPg = 1 AndAlso mContItensPg = 27 Then

                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    s.EscreveLn(" *** CONTINUACAO DO ORÇAMENTO TRANSPORTADO PARA FOLHA SEGUINTE **  ")
                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    'Quebra 10 Linhas para passar para a próxima folha...
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)



                    mContPg += 1
                    s.EscreveLn("                    C O N T I N U A C A O . . .        FOLHA: " & String.Format("{0:D3}", mContPg))
                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    s.EscreveLn(Exibe_StrEsquerda("| Cliente : " & codCliente & "-" & nomeCliente, 69) & " |AG: " & numOrcamento & "|")
                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    s.EscreveLn("")
                    s.EscreveLn("Cod.   Descrição.                                       Qtde.     Valor        TOTAL ")
                    '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxx 99.99  9,999.99 9,999,999.99  
                    s.EscreveLn("-------------------------------------------------------------------------------------")

                    mContItensPg = _valorZERO


                ElseIf mContPg > 1 AndAlso mContItensPg = 30 Then

                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    s.EscreveLn(" *** CONTINUACAO DO ORÇAMENTO TRANSPORTADO PARA FOLHA SEGUINTE **  ")
                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    'Quebra 10 Linhas para passar para a próxima folha...
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)



                    mContPg += 1
                    s.EscreveLn("                    C O N T I N U A C A O . . .        FOLHA: " & String.Format("{0:D3}", mContPg))
                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    s.EscreveLn(Exibe_StrEsquerda("| Cliente : " & codCliente & "-" & nomeCliente, 69) & " |AG: " & numOrcamento & "|")
                    s.EscreveLn("+-----------------------------------------------------------------------------------+")
                    s.EscreveLn("")
                    s.EscreveLn("Cod.   Descrição.                                       Qtde.     Valor        TOTAL ")
                    '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxx 999.99  9,999.99 9,999,999.99  
                    s.EscreveLn("-------------------------------------------------------------------------------------")

                    mContItensPg = _valorZERO
                    mCont2 = 30

                End If

                mCodProd = String.Format("{0:D5}", drItem(0))
                mNomeProd = drItem(1).ToString
                mVlProd = drItem(2)
                mQtdeProd = drItem(3)
                mVlTotProd = drItem(4)

                mSomaTotProd += mVlTotProd


                strLinha = Exibe_StrEsquerda(mCodProd, 6) & " " & _
                Exibe_StrEsquerda(mNomeProd, 47) & " " & _
                Exibe_StrDireita(Format(mQtdeProd, "##0.00"), 6) & "  " & _
                Exibe_StrDireita(Format(mVlProd, "#,##0.00"), 8) & "  " & _
                Exibe_StrDireita(Format(mVlTotProd, "#,###,##0.00"), 12)

                s.EscreveLn(Exibe_Str(strLinha, 85))
                mContItens += 1 : mContItensPg += 1
                mCont1 -= 1 : mCont2 -= 1


            End While
            drItem.Close()

            For index = 0 To mCont1 - 1
                s.EscreveLn("")
            Next

            For index = 0 To mCont2 - 1
                s.EscreveLn("")
            Next


            If mSomaTotProd > _valorZERO Then

                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.EscreveLn("------------------------------------------------------------------------------------+")
                strLinha = Exibe_StrEsquerda(" TOTAIS ---> ", 25) & Exibe_StrDireita(mContItens, 5)
                If mContItens > 1 Then
                    strLinha += " - Serviços"
                Else
                    strLinha += " - Serviço "
                End If
                strLinha = Exibe_StrEsquerda(strLinha, 40)
                strLinha += Exibe_StrDireita("| " & Exibe_StrDireita(Format(Round(mSomaTotProd, 2), "#,###,##0.00"), 12) & " |", 46)
                s.EscreveLn(Exibe_Str(strLinha, 85))
                s.EscreveLn("------------------------------------------------------------------------------------+")


                s.EscreveLn("")
            End If

            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
            mNomeProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing

            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) do Agendamento", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub
    ' ######################################################################################




    ' ######################################################################################
    '       RELATÓRIO PARA * PEDIDO * (IMPRESSORA MATRICIAL)
    'Cabeçalho da Loja
    Public Sub GravCabLojPedidoMatricial(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlLoja As New StringBuilder
            Dim cmdLoja As NpgsqlCommand
            Dim drLoja As NpgsqlDataReader

            sqlLoja.Append(consulta)

            cmdLoja = New NpgsqlCommand(sqlLoja.ToString, oConnBDGENOV)
            drLoja = cmdLoja.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja As String

            nomeLoja = "" : ufLoja = "" : enderLoja = "" : cidLoja = "" : foneLoja = ""
            While drLoja.Read

                nomeLoja = drLoja(0).ToString : enderLoja = drLoja(1).ToString
                foneLoja = drLoja(2).ToString : ufLoja = drLoja(3).ToString : cidLoja = drLoja(4).ToString

            End While
            drLoja.Close() : cmdLoja = Nothing : sqlLoja = Nothing : drLoja = Nothing


            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = "    " & Exibe_StrEsquerda(nomeLoja, 16) & " - "
            strLinha += Exibe_StrEsquerda(enderLoja, 23) & " - "
            strLinha += Exibe_StrDireita("Fone:" & foneLoja, 15) & "  "
            strLinha += Exibe_StrDireita(cidLoja, 8) & "-"
            strLinha += Exibe_StrDireita(ufLoja, 2)

            s.EscreveLn(Exibe_StrEsquerda(strLinha, 80))

            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Cabeçalho do Cliente
    Public Sub GravCabCliPedidoMatricial(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal codCliente As String, _
                                     ByVal numPedido As String, ByVal dtEmiss As String, _
                                     ByVal codVendedor As String, ByVal condicao As String, _
                                      ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlClient As New StringBuilder
            Dim cmdClient As NpgsqlCommand
            Dim drClient As NpgsqlDataReader

            'Traz dados do CLIENTE do Pedido...
            sqlClient.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
            sqlClient.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codCliente & "'")

            cmdClient = New NpgsqlCommand(sqlClient.ToString, oConnBDGENOV)
            drClient = cmdClient.ExecuteReader

            Dim nomeClient, cnpjCliente, cpfCliente, enderecoCli, ufClient, cidClient, bairroClient As String
            Dim foneClient, faxClient, celularCliente, nomeFantasCli, inscrCliente As String

            nomeClient = "" : cnpjCliente = "" : cpfCliente = "" : enderecoCli = "" : ufClient = "" : cidClient = ""
            bairroClient = "" : foneClient = "" : faxClient = "" : celularCliente = "" : nomeFantasCli = ""
            inscrCliente = ""

            While drClient.Read

                nomeClient = drClient(0).ToString : cnpjCliente = drClient(1).ToString
                cpfCliente = drClient(2).ToString : enderecoCli = drClient(3).ToString
                cidClient = drClient(4).ToString : ufClient = drClient(5).ToString
                bairroClient = drClient(6).ToString : foneClient = drClient(7).ToString
                faxClient = drClient(8).ToString : celularCliente = drClient(9).ToString
                nomeFantasCli = drClient(10).ToString : inscrCliente = drClient(11).ToString

            End While
            drClient.Close()

            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.EscreveLn("+------------------------------------------------------------------------------+")
            'NOME DO CLIENTE...
            strLinha = "| " & Exibe_StrEsquerda("Cliente: " & nomeClient, 60) & " |               |"
            s.EscreveLn(Exibe_cabecalho(strLinha, 4, 80))

            'NOME FANTASIA...
            strLinha = "| " & Exibe_StrEsquerda("Nome Fantasia: " & nomeFantasCli, 60) & " | P E D I D O   |"
            s.EscreveLn(Exibe_cabecalho(strLinha, 4, 80))

            'ENDEREÇO E BAIRRO...
            strLinha = "| " & Exibe_StrEsquerda("End.: " & enderecoCli, 32) & " "
            strLinha += Exibe_StrEsquerda("Bairro: " & bairroClient, 27) & " "
            strLinha += "|  " & numPedido & "     |"
            s.EscreveLn(Exibe_cabecalho(strLinha, 4, 80))

            'CIDADE E ESTADO...
            strLinha = "| " & Exibe_StrEsquerda("Cidade: " & cidClient, 53) & " "
            strLinha += Exibe_StrEsquerda("UF: " & ufClient, 6) & " "
            strLinha += "|" & Exibe_StrEsquerda("Emis:" & Format(Convert.ChangeType(dtEmiss, GetType(Date)), "dd/MM/yyyy"), 15) & "|"
            s.EscreveLn(Exibe_cabecalho(strLinha, 4, 80))

            'CNPJ/CPF e INSCRICÃO...
            If Not cnpjCliente.Equals("") Then

                strLinha = "| " & Exibe_StrEsquerda("CNPJ: " & String.Format("{0:00\.000\.000\/0000\-00}", Convert.ToInt64(cnpjCliente)), 30) & " "

            Else
                strLinha = "| " & Exibe_StrEsquerda("CPF: " & String.Format("{0:000\.000\.000\-00}", Convert.ToInt64(cpfCliente)), 30) & " "

            End If
            strLinha += Exibe_StrEsquerda("INSC.EST.: ", 29) & " "
            strLinha += "|--Condicoes----|"
            s.EscreveLn(Exibe_cabecalho(strLinha, 4, 80))


            'FONE e VENDEDOR...
            If Not foneClient.Equals("") Then

                strLinha = "| " & Exibe_StrEsquerda("F/Fax: " & foneClient & "/" & faxClient, 30) & " "

            Else
                strLinha = "| " & Exibe_StrEsquerda("F/Fax: " & celularCliente & "/" & faxClient, 30) & " "

            End If
            strLinha += Exibe_StrEsquerda("Vd: " & Mid(codVendedor, codVendedor.Length - 1, 2) & "-" & _
            trazNomeVendedor(Mid(codVendedor, codVendedor.Length - 3, 4), loja, MdlConexaoBD.conectionPadrao), 29) & " "
            strLinha += "| " & Exibe_StrEsquerda( _
            trazNomeCondicoesPgtoRelatorio(condicao), 14) & "|"
            s.EscreveLn(Exibe_cabecalho(strLinha, 4, 80))

            sqlClient = Nothing : cmdClient = Nothing : drClient = Nothing
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho do Cliente:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    'Grava Itens
    Public Sub GravItensPedidoMatricial(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal numPedido As String, ByVal idOrca1 As Int32, _
                             ByVal codCliente As String, ByVal nomeCliente As String, ByRef shouldReturn As Boolean)
        shouldReturn = False
        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mCodProd, mNomeProd, undProd, strLinha As String
            Dim mQtdeProd, mVlProd, mVlBrutoProd, mVlTotProd, mVlTotBrutoProd As Double
            Dim mSomaTotProd, mSomaBrutoProd, mSomaDescProd, mSomaVolProd As Double
            strLinha = "" : undProd = ""
            Dim mCont1, mCont2, index As Integer


            Try
                oConnBDGENOV.Open()

            Catch ex As Exception
            End Try

            Dim sqlItem As New StringBuilder
            Dim cmdItem As NpgsqlCommand
            Dim drItem As NpgsqlDataReader
            Dim mContItens As Integer = 0, mContItensPg As Integer = 0, mContPg As Integer = 0

            'SELECT no_orca, no_codpr, no_produt, no_und, no_qtde, no_prunit, no_prtot, 
            'no_alqicm, no_dtemis, no_rota, no_vend, no_lin, no_alqcom, no_comis, 
            'no_mapa, no_supervisor, no_basesub, no_alqsub, no_vlsub, no_idxo1, 
            'no_idpk, no_grupo, no_cdport, no_alqdesc, no_vldesc, no_pruvenda, 
            'no_filial, no_pesobruto, no_pesoliquido, no_geno
            'FROM orca2cc WHERE no_orca = '11055165'

            'sqlItem.Append("SELECT o2.no_codpr, o2.no_qtde, o2.no_und, e.e_produt, o2.no_prunit, o2.no_prtot ") '5
            'sqlItem.Append("FROM " & MdlEmpresaUsu._esqEstab & ".orca2cc o2 LEFT JOIN " & MdlEmpresaUsu._esqVinc & ".est0001 e ON e.e_codig = o2.no_codpr ")
            'sqlItem.Append("WHERE no_idxo1 = " & idOrca1)

            sqlItem.Append(consulta)

            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)

            Dim daItem As New NpgsqlDataAdapter(cmdItem)
            Dim dsItem As New DataSet
            daItem.Fill(dsItem, MdlEmpresaUsu._esqEstab & ".orca2cc")
            s.qtdeRegistros = dsItem.Tables(MdlEmpresaUsu._esqEstab & ".orca2cc").Rows.Count
            dsItem = Nothing : daItem = Nothing

            drItem = cmdItem.ExecuteReader

            If drItem.HasRows = True Then
                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.EscreveLn("|------------------------------------------------------------------------------|")
                s.EscreveLn("|COD.  |QUANT.  |UND|DESCRICÃO DO PRODUTO               |V.BRUTO |   TOTAL     |")
                '             xxxxxx|9,999.99|xxx|xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx|9,999.99|   999,999.99|  
                s.EscreveLn("|------------------------------------------------------------------------------|")
                mCont1 = 20

            End If

            mSomaTotProd = 0
            mContPg = 1


            While drItem.Read


                mCodProd = drItem(0).ToString
                mQtdeProd = drItem(1)
                undProd = drItem(2).ToString
                mNomeProd = drItem(3).ToString
                mVlProd = drItem(11) : If drItem(10) > 0 Then mVlProd = drItem(11) + Round(drItem(10) / mQtdeProd, 2)
                mVlTotProd = drItem(5) + drItem(10)
                mVlBrutoProd = drItem(4)
                mVlTotBrutoProd = Round((mVlBrutoProd * mQtdeProd), 2)

                mSomaTotProd += mVlTotProd
                mSomaBrutoProd += mVlTotBrutoProd
                mSomaDescProd += drItem(8)
                mSomaVolProd += drItem(9)

                strLinha = "|" & Exibe_Str(mCodProd, 6) & "|" & _
                Exibe_StrDireita(Format(mQtdeProd, "#,##0.00"), 8) & "|" & _
                Exibe_Str(undProd, 3) & "|" & Exibe_StrEsquerda(mNomeProd, 35) & "|" & _
                Exibe_StrDireita(Format(mVlProd, "#,##0.00"), 8) & "|" & _
                Exibe_StrDireita(Format(mVlTotProd, "###,##0.00"), 13) & "|"

                s.contRegistros += 1
                s.EscreveLn(Exibe_Str(strLinha, 80))
                mContItens += 1 : mContItensPg += 1
                mCont1 -= 1 : mCont2 -= 1


            End While

            drItem.Close()

            mCont1 = (s.qtdLinhasPorPagina - s.contLinhasPorPagina)
            mCont2 = s.qtdeLinhasInfoFinal + 1
            If mCont1 < mCont2 Then mCont2 = 1
            For index = 0 To mCont1 - mCont2
                s.EscreveLn("|      |        |   |                                   |        |             |")
            Next

            'For index = 0 To mCont2 - 1
            '    s.EscreveLn("|      |        |   |                                   |        |             |")
            'Next



            If mSomaTotProd > 0 Then

                s.EscreveLn("+------------------------------------------------------------------------------+")
                s.EscreveLn("| N§ Documento | Valor | Resumo |   P E S O   |  SUB-TOTAL.. R$ |" & Exibe_StrDireita(Format(Round(mSomaBrutoProd, 2), "###,##0.00"), 14) & "|")
                s.EscreveLn("+------------------------------------------------------------------------------+")
                s.EscreveLn("|              |       | itens: |   A VISTA   |  DESCONTOS.. R$ |" & Exibe_StrDireita(Format(Round(mSomaDescProd, 2), "###,##0.00"), 14) & "|")
                s.EscreveLn("|              |       |        |             |--------------------------------|")
                s.EscreveLn("|              |       | Vol:   |" & Exibe_StrDireita(Format(Round(mSomaVolProd, 2), "#,##0.00"), 8) & " (Kg)|  T O T A L.. R$ |" & Exibe_StrDireita(Format(Round(mSomaTotProd, 2), "###,##0.00"), 14) & "|")
                s.EscreveLn("+------------------------------------------------------------------------------+")


                's.EscreveLn("|                                                                              |")
                'strLinha = Exibe_StrDireita("| TOTAIS --->", 25) & Exibe_StrEsquerda(mContItens, 5)
                'If mContItens > 1 Then
                '    strLinha += " - Itens"
                'Else
                '    strLinha += " - Iten"
                'End If
                'strLinha += Exibe_StrEsquerda(Format(mSomaTotProd, "###,##0.00"), 42) & "|" '106 CARACTERES
                's.EscreveLn(Exibe_Str(strLinha, 80))

                ''                      1        2         3         4         5         6         7         8                    9         0         1         2
                ''            12345678901234567890123456789012345678901234567890123456789012345678901234567890           1234567890123456789012345678901234567890
                's.EscreveLn("+------------------------------------------------------------------------------+")
                's.EscreveLn("")
            End If

            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
            mNomeProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing

            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing

        Catch ex As Exception
            MsgBox("RELATORIO:: Deu erro ao gravar o(s) iten(s) do Mapa", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub
    ' ######################################################################################



    ' ######################################################################################
    '       RELATÓRIO PARA * PEDIDO * (IMPRESSORA MATRICIAL ) ALTERADO 1
    'Cabeçalho da loja
    Public Sub GravCabLojPediMatriAlterado1(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlLoja As New StringBuilder
            Dim cmdLoja As NpgsqlCommand
            Dim drLoja As NpgsqlDataReader

            sqlLoja.Append(consulta)

            cmdLoja = New NpgsqlCommand(sqlLoja.ToString, oConnBDGENOV)
            drLoja = cmdLoja.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja As String

            nomeLoja = "" : ufLoja = "" : enderLoja = "" : cidLoja = "" : foneLoja = ""
            While drLoja.Read

                nomeLoja = drLoja(0).ToString : enderLoja = drLoja(1).ToString
                foneLoja = drLoja(2).ToString : ufLoja = drLoja(3).ToString : cidLoja = drLoja(4).ToString

            End While
            drLoja.Close() : cmdLoja = Nothing : sqlLoja = Nothing : drLoja = Nothing


            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = "    " & Exibe_StrEsquerda(nomeLoja, 16) & " - "
            strLinha += Exibe_StrEsquerda(enderLoja, 23) & " - "
            strLinha += Exibe_StrDireita("Fone:" & foneLoja, 15) & "  "
            strLinha += Exibe_StrDireita(cidLoja, 8) & "-"
            strLinha += Exibe_StrDireita(ufLoja, 2)

            s.WriteLine(Exibe_StrEsquerda(strLinha, 80))

            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try


    End Sub
    'Cabeçalho do Cliente
    Public Sub GravCabCliPediMatriAlterado1(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal codCliente As String, _
                                     ByVal numPedido As String, ByVal dtEmiss As String, _
                                     ByVal codVendedor As String, ByVal condicao As String, _
                                      ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlClient As New StringBuilder
            Dim cmdClient As NpgsqlCommand
            Dim drClient As NpgsqlDataReader

            'Traz dados do CLIENTE do Pedido...
            sqlClient.Append(consulta)

            cmdClient = New NpgsqlCommand(sqlClient.ToString, oConnBDGENOV)
            drClient = cmdClient.ExecuteReader

            Dim nomeClient, cnpjCliente, cpfCliente, enderecoCli, ufClient, cidClient, bairroClient As String
            Dim foneClient, faxClient, celularCliente, nomeFantasCli, inscrCliente As String

            nomeClient = "" : cnpjCliente = "" : cpfCliente = "" : enderecoCli = "" : ufClient = "" : cidClient = ""
            bairroClient = "" : foneClient = "" : faxClient = "" : celularCliente = "" : nomeFantasCli = ""
            inscrCliente = ""

            While drClient.Read

                nomeClient = drClient(0).ToString : cnpjCliente = drClient(1).ToString
                cpfCliente = drClient(2).ToString : enderecoCli = drClient(3).ToString
                cidClient = drClient(4).ToString : ufClient = drClient(5).ToString
                bairroClient = drClient(6).ToString : foneClient = drClient(7).ToString
                faxClient = drClient(8).ToString : celularCliente = drClient(9).ToString
                nomeFantasCli = drClient(10).ToString : inscrCliente = drClient(11).ToString

            End While
            drClient.Close()

            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine("+------------------------------------------------------------------------------+")
            'NOME DO CLIENTE...
            strLinha = "| " & Exibe_StrEsquerda("Cliente: " & nomeClient, 60) & " |               |"
            s.WriteLine(Exibe_cabecalho(strLinha, 4, 80))

            'NOME FANTASIA...
            strLinha = "| " & Exibe_StrEsquerda("Nome Fantasia: " & nomeFantasCli, 60) & " | P E D I D O   |"
            s.WriteLine(Exibe_cabecalho(strLinha, 4, 80))

            'ENDEREÇO E BAIRRO...
            strLinha = "| " & Exibe_StrEsquerda("End.: " & enderecoCli, 32) & " "
            strLinha += Exibe_StrEsquerda("Bairro: " & bairroClient, 27) & " "
            strLinha += "|  " & numPedido & "     |"
            s.WriteLine(Exibe_cabecalho(strLinha, 4, 80))

            'CIDADE E ESTADO...
            strLinha = "| " & Exibe_StrEsquerda("Cidade: " & enderecoCli, 53) & " "
            strLinha += Exibe_StrEsquerda("UF: " & ufClient, 6) & " "
            strLinha += "|" & Exibe_StrEsquerda("Emis:" & Format(Convert.ChangeType(dtEmiss, GetType(Date)), "dd/MM/yyyy"), 15) & "|"
            s.WriteLine(Exibe_cabecalho(strLinha, 4, 80))

            'CNPJ/CPF e INSCRICÃO...
            If Not cnpjCliente.Equals("") Then

                strLinha = "| " & Exibe_StrEsquerda("CNPJ: " & String.Format("{0:00\.000\.000\/0000\-00}", Convert.ToInt64(cnpjCliente)), 30) & " "

            Else
                strLinha = "| " & Exibe_StrEsquerda("CPF: " & String.Format("{0:000\.000\.000\-00}", Convert.ToInt64(cpfCliente)), 30) & " "

            End If
            strLinha += Exibe_StrEsquerda("INSC.EST.: ", 29) & " "
            strLinha += "|--Condicoes----|"
            s.WriteLine(Exibe_cabecalho(strLinha, 4, 80))


            'FONE e VENDEDOR...
            If Not foneClient.Equals("") Then

                strLinha = "| " & Exibe_StrEsquerda("F/Fax: " & foneClient & "/" & faxClient, 30) & " "

            Else
                strLinha = "| " & Exibe_StrEsquerda("F/Fax: " & celularCliente & "/" & faxClient, 30) & " "

            End If
            strLinha += Exibe_StrEsquerda("Vd: " & Mid(codVendedor, codVendedor.Length - 1, 2) & "-" & _
            trazNomeVendedor(Mid(codVendedor, codVendedor.Length - 3, 4), loja, MdlConexaoBD.conectionPadrao), 29) & " "
            strLinha += "| " & Exibe_StrEsquerda( _
            trazNomeCondicoesPgtoRelatorio(condicao), 14) & "|"
            s.WriteLine(Exibe_cabecalho(strLinha, 4, 80))


            sqlClient = Nothing : cmdClient = Nothing : drClient = Nothing
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho do Cliente:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try


    End Sub
    'Grava Itens
    Public Sub GravItensPediMatriAlterado1(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal numPedido As String, ByVal idOrca1 As Int32, _
                             ByVal codCliente As String, ByVal nomeCliente As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Dim _valorZERO As Int16 = 0
        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mCodProd, mNomeProd, undProd, strLinha, mfilial, mlocacao As String
            Dim mQtdeProd, mVlProd, mVlTotProd As Double
            Dim mSomaTotProd, mSomaBrutoProd, mSomaDescProd, mSomaVolBrutProd As Double
            strLinha = "" : undProd = ""
            Dim mCont1, mCont2, index As Integer

            Try
                oConnBDGENOV.Open()

            Catch ex As Exception
            End Try

            Dim sqlItem As New StringBuilder
            Dim cmdItem As NpgsqlCommand
            Dim drItem As NpgsqlDataReader
            Dim mContItens As Integer = _valorZERO, mContItensPg As Integer = _valorZERO, mContPg As Integer = _valorZERO


            sqlItem.Append(consulta)


            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
            drItem = cmdItem.ExecuteReader

            If drItem.HasRows = True Then
                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("|--------------------------------------------------------------------------------------------------|")
                s.WriteLine("|COD.   | LOJA | LOCAÇÃO  | QUANT. | UND | DESCRICÃO DO PRODUTO               | V.BRUTO |  TOTAL   |")
                '             xxxxxx | xx   |xxxxxxxxxZ|9,999.99| xxx |xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxx|99,999.99|999,999.99|  
                s.WriteLine("|--------------------------------------------------------------------------------------------------|")

                mCont1 = 23
            End If

            mSomaTotProd = _valorZERO
            mContPg = 1
            While drItem.Read


                If mContPg = 1 AndAlso mContItensPg = 23 Then

                    s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                    s.WriteLine(" *** CONTINUACAO DO PEDIDO TRANSPORTADO PARA FOLHA SEGUINTE **  ")
                    s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                    'Quebra 10 Linhas para passar para a próxima folha...
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)


                    mContPg += 1
                    s.WriteLine("                    C O N T I N U A C A O . . .                                       FOLHA: " & String.Format("{0:D3}", mContPg))
                    s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                    s.WriteLine(Exibe_StrEsquerda("| Cliente : " & codCliente & "-" & nomeCliente, 84) & " |PED: " & numPedido & "|")
                    s.WriteLine("|--------------------------------------------------------------------------------------------------|")
                    s.WriteLine("|COD.   | LOJA | LOCAÇÃO  | QUANT. | UND | DESCRICÃO DO PRODUTO               | V.BRUTO |  TOTAL   |")
                    '             xxxxxx | xx   |xxxxxxxxxZ|9,999.99| xxx |xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxx|99,999.99|999,999.99|  
                    s.WriteLine("|--------------------------------------------------------------------------------------------------|")

                    mContItensPg = _valorZERO


                ElseIf mContPg > 1 AndAlso mContItensPg = 28 Then

                    s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                    s.WriteLine(" *** CONTINUACAO DO PEDIDO TRANSPORTADO PARA FOLHA SEGUINTE **  ")
                    s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                    'Quebra 10 Linhas para passar para a próxima folha...
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)


                    mContPg += 1
                    s.WriteLine("                    C O N T I N U A C A O . . .                                       FOLHA: " & String.Format("{0:D3}", mContPg))
                    s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                    s.WriteLine(Exibe_StrEsquerda("| Cliente : " & codCliente & "-" & nomeCliente, 84) & " |PED: " & numPedido & "|")
                    s.WriteLine("|--------------------------------------------------------------------------------------------------|")
                    s.WriteLine("|COD.   | LOJA | LOCAÇÃO  | QUANT. | UND | DESCRICÃO DO PRODUTO               | V.BRUTO |  TOTAL   |")
                    '             xxxxxx | xx   |xxxxxxxxxZ|9,999.99| xxx |xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxx|99,999.99|999,999.99|  
                    s.WriteLine("|--------------------------------------------------------------------------------------------------|")

                    mContItensPg = _valorZERO
                    mCont2 = 25

                End If

                mCodProd = drItem(0).ToString
                mQtdeProd = drItem(1).ToString
                undProd = drItem(2).ToString
                mNomeProd = drItem(3).ToString
                mVlProd = drItem(4) : If drItem(10) > 0 Then mVlProd = drItem(4) + Round(drItem(10) / mQtdeProd, 2)
                mVlTotProd = drItem(5) + drItem(10)
                mfilial = drItem(6).ToString
                mlocacao = drItem(7).ToString

                mSomaTotProd += mVlTotProd
                mSomaBrutoProd += Round((mVlProd * mQtdeProd), 2)
                mSomaDescProd += drItem(8)
                mSomaVolBrutProd += drItem(9)

                strLinha = "|" & Exibe_Str(mCodProd, 6) & " | " & _
                Exibe_Str(mfilial, 4) & " |" & _
                Exibe_Str(mlocacao, 10) & "|" & _
                Exibe_StrDireita(Format(mQtdeProd, "#,##0.00"), 8) & "| " & _
                Exibe_Str(undProd, 3) & " |" & Exibe_StrEsquerda(mNomeProd, 36) & "|" & _
                Exibe_StrDireita(Format(mVlProd, "##,##0.00"), 9) & "|" & _
                Exibe_StrDireita(Format(mVlTotProd, "###,##0.00"), 10) & "|"

                s.WriteLine(Exibe_Str(strLinha, 100))
                mContItens += 1 : mContItensPg += 1
                mCont1 -= 1 : mCont2 -= 1

            End While
            drItem.Close()

            For index = 0 To mCont1 - 1
                s.WriteLine("|       |      |          |        |     |                                    |         |          |")
            Next

            For index = 0 To mCont2 - 1
                s.WriteLine("|       |      |          |        |     |                                    |         |          |")
            Next


            If mSomaTotProd > _valorZERO Then

                s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                s.WriteLine("|        N§ Documento  |   Valor    |   Resumo   |   P E S O    |   SUB-TOTAL.. R$  |" & Exibe_StrDireita(Format(Round(mSomaBrutoProd, 2), "###,##0.00"), 14) & "|")
                s.WriteLine("+--------------------------------------------------------------------------------------------------+")
                s.WriteLine("|                      |            |  itens:    |    A VISTA   |   DESCONTOS.. R$  |" & Exibe_StrDireita(Format(Round(mSomaDescProd, 2), "###,##0.00"), 14) & "|")
                s.WriteLine("|                      |            |            |              |----------------------------------|")
                s.WriteLine("|                      |            |  Vol:      |" & Exibe_StrDireita(Format(Round(mSomaVolBrutProd, 2), "#,##0.00"), 8) & " (Kg) |   T O T A L . R$  |" & Exibe_StrDireita(Format(Round(mSomaTotProd, 2), "###,##0.00"), 14) & "|")
                s.WriteLine("+--------------------------------------------------------------------------------------------------+")

                's.WriteLine("|                                                                                                  |")
                'strLinha = Exibe_StrDireita("| TOTAIS --->", 25) & Exibe_StrEsquerda(mContItens, 5)
                'If mContItens > 1 Then
                '    strLinha += " - Itens"
                'Else
                '    strLinha += " - Iten "
                'End If
                'strLinha += Exibe_StrEsquerda(Format(mSomaTotProd, "###,##0.00"), 59) & "  |" '106 CARACTERES
                's.WriteLine(Exibe_Str(strLinha, 100))

                ''                      1        2         3         4         5         6         7         8                    9         0         1         2
                ''            12345678901234567890123456789012345678901234567890123456789012345678901234567890           1234567890123456789012345678901234567890
                's.WriteLine("+--------------------------------------------------------------------------------------------------+")
                s.WriteLine("")
            End If

            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
            mNomeProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing


            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) do Pedido::" & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try


    End Sub
    ' ######################################################################################



    ' ######################################################################################
    '       RELATÓRIO PARA * REQUISIÇÃO_PROCESSO * (IMPRESSORA LASER)
    'Titulo do Processo
    Public Sub GravTituloProcRequisicaoLaser(ByVal numRequisicao As String, ByVal dataHoje As Date, ByRef s As Cl_EscreveArquivo, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""

            '                    1         2         3         4         5         6         7         8         9         0         1         2
            '           123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = "                     Requisição Nº " & numRequisicao
            strLinha += "                        Data: " & Format(dataHoje, "dd/MM/yyyy")
            s.WriteLine(Exibe_Str(strLinha, 85))
            s.WriteLine("")


        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Titulo da Requisição:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub
    'Cabeçalho da Loja
    Public Sub GravCabLojProcRequisicaoLaser(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlLoja As New StringBuilder
            Dim cmdLoja As NpgsqlCommand
            Dim drLoja As NpgsqlDataReader

            sqlLoja.Append(consulta)

            cmdLoja = New NpgsqlCommand(sqlLoja.ToString, oConnBDGENOV)
            drLoja = cmdLoja.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja As String

            nomeLoja = "" : ufLoja = "" : enderLoja = "" : cidLoja = "" : foneLoja = ""
            While drLoja.Read

                nomeLoja = drLoja(0).ToString : enderLoja = drLoja(1).ToString
                foneLoja = drLoja(2).ToString : ufLoja = drLoja(3).ToString : cidLoja = drLoja(4).ToString

            End While
            drLoja.Close() : cmdLoja = Nothing : sqlLoja = Nothing : drLoja = Nothing


            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = " Empr.: " & loja.Substring(loja.Length - 2, 2) & " - " & Exibe_StrEsquerda(nomeLoja, 34) & " " '47
            strLinha += Exibe_StrDireita("Ender.: " & enderLoja, 36) & " " '37
            s.WriteLine(Exibe_Str(strLinha, 85))

            'strLinha = " Cidade: " & Exibe_StrDireita(cidLoja, 34) & " " '38
            'strLinha += "UF: " & Exibe_StrDireita(ufLoja, 2) & " " '7
            'strLinha += Exibe_StrDireita("Fone: " & foneLoja, 16) & " " '17
            'strLinha += Exibe_StrEsquerda("Data: " & Format(Date.Now, "dd/MM/yyyy"), 17) '17
            's.WriteLine(Exibe_Str(strLinha, 85))


            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub
    'Cabeçalho do Cliente
    Public Sub GravCabCliProcRequisicaoLaser(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, _
                                             ByVal codCliente As String, ByVal numRequisicao As String, _
                                             ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlClient As New StringBuilder
            Dim cmdClient As NpgsqlCommand
            Dim drClient As NpgsqlDataReader

            'Traz dados do CLIENTE do Pedido...
            sqlClient.Append(consulta)

            cmdClient = New NpgsqlCommand(sqlClient.ToString, oConnBDGENOV)
            drClient = cmdClient.ExecuteReader

            Dim nomeClient, cnpjCliente, cpfCliente, enderecoCli, ufClient, cidClient, bairroClient As String
            Dim foneClient, faxClient, celularCliente, nomeFantasCli, inscrCliente As String

            nomeClient = "" : cnpjCliente = "" : cpfCliente = "" : enderecoCli = "" : ufClient = "" : cidClient = ""
            bairroClient = "" : foneClient = "" : faxClient = "" : celularCliente = "" : nomeFantasCli = ""
            inscrCliente = ""

            While drClient.Read

                nomeClient = drClient(0).ToString : cnpjCliente = drClient(1).ToString
                cpfCliente = drClient(2).ToString : enderecoCli = drClient(3).ToString
                cidClient = drClient(4).ToString : ufClient = drClient(5).ToString
                bairroClient = drClient(6).ToString : foneClient = drClient(7).ToString
                faxClient = drClient(8).ToString : celularCliente = drClient(9).ToString
                nomeFantasCli = drClient(10).ToString : inscrCliente = drClient(11).ToString

            End While
            drClient.Close() : drClient = Nothing

            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            's.WriteLine("+------------------------------------------------------------------------------+")
            'NOME DO CLIENTE...
            strLinha = " " & Exibe_StrEsquerda("Cliente: " & nomeClient, 72) & " " '54
            'CNPJ/CPF e INSCRICÃO...
            'If Not cnpjCliente.Equals("") Then

            '    strLinha += Exibe_StrDireita("CNPJ: " & String.Format("{0:00\.000\.000\/0000\-00}", Convert.ToInt64(cnpjCliente)), 30) & " " '31
            'Else

            '    strLinha += Exibe_StrDireita("CPF: " & String.Format("{0:000\.000\.000\-00}", Convert.ToInt64(cpfCliente)), 30) & " " '31
            'End If
            strLinha += Exibe_StrDireita("Pag.: " & "001", 10) & " " '31
            s.WriteLine(Exibe_Str(strLinha, 85))
            s.WriteLine("+-----------------------------------------------------------------------------------+")

            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho do Cliente:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub
    'Grava Itens
    Public Sub GravItensProcRequisicaoLaser(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal numRequisicao As String, _
                             ByVal codCliente As String, ByVal nomeCliente As String, ByRef shouldReturn As Boolean)
        shouldReturn = False
        Dim _valorZERO As Int16 = 0
        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mCodProd, mNomeProd, data, strLinha As String
            Dim mQtdeProd, mVlProd, mVlTotProd As Double
            Dim mSomaTotProd, mSomaBrutoProd, mSomaDescProd, mSomaVolBrutProd As Double
            strLinha = "" : data = ""
            Dim mCont1, mCont2, index As Integer

            Try
                oConnBDGENOV.Open()

            Catch ex As Exception
            End Try

            Dim sqlItem As New StringBuilder
            Dim cmdItem As NpgsqlCommand
            Dim drItem As NpgsqlDataReader
            Dim mContItens As Integer = _valorZERO, mContItensPg As Integer = _valorZERO, mContPg As Integer = _valorZERO


            sqlItem.Append(consulta)

            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
            drItem = cmdItem.ExecuteReader

            If drItem.HasRows = True Then
                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                's.WriteLine("-------------------------------------------------------------------------------------")
                s.WriteLine("| Cod.   | Descrição.                                     |    Qtde    |  Data      |")
                '              xxxxxx   xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxx   99,999.99    dd/MM/yyyy  
                s.WriteLine("+-----------------------------------------------------------------------------------+")

                mCont1 = 60
            End If

            mSomaTotProd = _valorZERO
            mContPg = 1
            While drItem.Read


                If mContPg = 1 AndAlso mContItensPg = 60 Then

                    's.WriteLine("+-----------------------------------------------------------------------------------+")
                    's.WriteLine(" *** CONTINUACAO DA REQUISIÇÃO TRANSPORTADO PARA FOLHA SEGUINTE **  ")
                    's.WriteLine("+-----------------------------------------------------------------------------------+")
                    s.Write(vbNewLine & vbNewLine & vbNewLine)
                    'Quebra 10 Linhas para passar para a próxima folha...
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)



                    mContPg += 1
                    s.WriteLine("                    C O N T I N U A C A O . . .        FOLHA: " & String.Format("{0:D3}", mContPg))
                    s.WriteLine("+-----------------------------------------------------------------------------------+")
                    s.WriteLine(Exibe_StrEsquerda("| Cliente : " & nomeCliente, 69) & " |REQ: " & numRequisicao & "|")
                    s.WriteLine("+-----------------------------------------------------------------------------------+")
                    s.WriteLine("")
                    s.WriteLine("| Cod.   | Descrição.                                     |    Qtde    |  Data      |")
                    '              xxxxxx   xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxx   99,999.99    dd/MM/yyyy  
                    s.WriteLine("+-----------------------------------------------------------------------------------+")

                    mContItensPg = _valorZERO


                ElseIf mContPg > 1 AndAlso mContItensPg = 63 Then

                    s.WriteLine("+-----------------------------------------------------------------------------------+")
                    s.WriteLine(" *** CONTINUACAO DO ORÇAMENTO TRANSPORTADO PARA FOLHA SEGUINTE **  ")
                    s.WriteLine("+-----------------------------------------------------------------------------------+")
                    'Quebra 10 Linhas para passar para a próxima folha...
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)



                    mContPg += 1
                    s.WriteLine("                    C O N T I N U A C A O . . .        FOLHA: " & String.Format("{0:D3}", mContPg))
                    s.WriteLine("+-----------------------------------------------------------------------------------+")
                    s.WriteLine(Exibe_StrEsquerda("| Cliente : " & nomeCliente, 69) & " |REQ: " & numRequisicao & "|")
                    s.WriteLine("+-----------------------------------------------------------------------------------+")
                    s.WriteLine("")
                    s.WriteLine("| Cod.   | Descrição.                                     |    Qtde    |  Data      |")
                    '              xxxxxx   xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxx   99,999.99    dd/MM/yyyy  
                    s.WriteLine("+-----------------------------------------------------------------------------------+")

                    mContItensPg = _valorZERO
                    mCont2 = 63

                End If

                mCodProd = drItem(0).ToString
                mNomeProd = drItem(1).ToString
                mQtdeProd = drItem(2)
                data = Format(Convert.ChangeType(drItem(3), GetType(Date)), "dd/MM/yyyy")


                strLinha = "| " & Exibe_StrEsquerda(mCodProd, 6) & " | " & _
                Exibe_StrEsquerda(mNomeProd, 46) & " | " & _
                Exibe_StrDireita(Format(mQtdeProd, "##,##0.00"), 9) & "  | " & _
                Exibe_StrDireita(data, 10) & " |"

                s.WriteLine(Exibe_Str(strLinha, 85))
                mContItens += 1 : mContItensPg += 1
                mCont1 -= 1 : mCont2 -= 1

                'mContItens += 27 : mContItensPg += 27
                'mCont1 -= 27 : mCont2 -= 27

                'mContItens += 30 : mContItensPg += 30
                'mCont1 -= 30 : mCont2 -= 30
            End While
            drItem.Close()

            For index = 0 To mCont1 - 1
                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("|        |                                                |            |            |")
            Next

            For index = 0 To mCont2 - 1
                s.WriteLine("|        |                                                |            |            |")
            Next


            If mContItens > _valorZERO Then

                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                's.WriteLine("------------------------------------------------------------------------------------+")
                'strLinha = Exibe_StrDireita(" TOTAIS ---> ", 25) & Exibe_StrEsquerda(mContItens, 5)
                'If mContItens > 1 Then
                '    strLinha += " - Itens"
                'Else
                '    strLinha += " - Iten "
                'End If
                'strLinha += Exibe_StrEsquerda("| " & Exibe_StrEsquerda(Format(Round(mSomaTotProd, 2), "#,###,##0.00"), 12) & " |", 47)
                's.WriteLine(Exibe_Str(strLinha, 85))
                s.WriteLine("+-----------------------------------------------------------------------------------+")
                s.WriteLine(vbNewLine & vbNewLine)
                s.WriteLine("                                            ___________________________________      ")
                s.WriteLine("                                                         GERENTE")

                's.WriteLine("|                                                                              |")
                'strLinha = Exibe_StrDireita("| TOTAIS --->", 25) & Exibe_StrEsquerda(mContItens, 5)
                'If mContItens > 1 Then
                '    strLinha += " - Itens"
                'Else
                '    strLinha += " - Iten"
                'End If
                'strLinha += Exibe_StrEsquerda(Format(mSomaTotProd, "###,##0.00"), 42) & "|" '106 CARACTERES
                's.WriteLine(Exibe_Str(strLinha, 80))

                ''                      1        2         3         4         5         6         7         8                    9         0         1         2
                ''            12345678901234567890123456789012345678901234567890123456789012345678901234567890           1234567890123456789012345678901234567890
                's.WriteLine("+------------------------------------------------------------------------------+")
                s.WriteLine("")
            End If

            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
            mNomeProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing

            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) da Requisição", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub
    ' ######################################################################################



    ' ######################################################################################
    '       RELATÓRIO PARA * PROCESSO - SALDO DA CONTA * (IMPRESSORA LASER)
    'Titulo do Processo
    Public Sub GravTituloProcSaldoContaLaser(ByVal numRequisicao As String, ByVal dataHoje As Date, ByRef s As Cl_EscreveArquivo, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""

            '                    1         2         3         4         5         6         7         8         9         0         1         2
            '           123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = "                     Requisição Nº " & numRequisicao
            strLinha += "                        Data: " & Format(dataHoje, "dd/MM/yyyy")
            s.WriteLine(Exibe_Str(strLinha, 85))
            s.WriteLine("")


        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Titulo da Requisição:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub
    'Cabeçalho da Loja
    Public Sub GravCabLojProcSaldoContaLaser(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlLoja As New StringBuilder
            Dim cmdLoja As NpgsqlCommand
            Dim drLoja As NpgsqlDataReader

            sqlLoja.Append(consulta)

            cmdLoja = New NpgsqlCommand(sqlLoja.ToString, oConnBDGENOV)
            drLoja = cmdLoja.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja As String

            nomeLoja = "" : ufLoja = "" : enderLoja = "" : cidLoja = "" : foneLoja = ""
            While drLoja.Read

                nomeLoja = drLoja(0).ToString : enderLoja = drLoja(1).ToString
                foneLoja = drLoja(2).ToString : ufLoja = drLoja(3).ToString : cidLoja = drLoja(4).ToString

            End While
            drLoja.Close() : cmdLoja = Nothing : sqlLoja = Nothing : drLoja = Nothing


            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine(" +--------------------------------------------------------------------------+")
            strLinha = Exibe_StrEsquerda(" | Emitente...: " & loja.Substring(loja.Length - 2, 2) & " - " & nomeLoja, 50) & " " '47
            strLinha += Exibe_StrEsquerda("* * SALDO CLIENTE * *", 25) & "|" 'Exibe_StrEsquerda("Ender.: " & enderLoja, 36) & " " '37
            s.WriteLine(Exibe_Str(strLinha, 85))

            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub
    'Cabeçalho do Cliente
    Public Sub GravCabCliProcSaldoContaLaser(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, _
                                             ByVal codCliente As String, ByVal numRequisicao As String, _
                                             ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlClient As New StringBuilder
            Dim cmdClient As NpgsqlCommand
            Dim drClient As NpgsqlDataReader

            'Traz dados do CLIENTE do Pedido...
            sqlClient.Append(consulta)

            cmdClient = New NpgsqlCommand(sqlClient.ToString, oConnBDGENOV)
            drClient = cmdClient.ExecuteReader

            Dim nomeClient, cnpjCliente, cpfCliente, enderecoCli, ufClient, cidClient, bairroClient As String
            Dim foneClient, faxClient, celularCliente, nomeFantasCli, inscrCliente As String

            nomeClient = "" : cnpjCliente = "" : cpfCliente = "" : enderecoCli = "" : ufClient = "" : cidClient = ""
            bairroClient = "" : foneClient = "" : faxClient = "" : celularCliente = "" : nomeFantasCli = ""
            inscrCliente = ""

            While drClient.Read

                nomeClient = drClient(0).ToString : cnpjCliente = drClient(1).ToString
                cpfCliente = drClient(2).ToString : enderecoCli = drClient(3).ToString
                cidClient = drClient(4).ToString : ufClient = drClient(5).ToString
                bairroClient = drClient(6).ToString : foneClient = drClient(7).ToString
                faxClient = drClient(8).ToString : celularCliente = drClient(9).ToString
                nomeFantasCli = drClient(10).ToString : inscrCliente = drClient(11).ToString

            End While
            drClient.Close() : drClient = Nothing

            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '             123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            's.WriteLine("+--------------------------------------------------------------------------+")
            'NOME DO CLIENTE...
            strLinha = Exibe_StrEsquerda(" | Destino...: " & nomeClient, 76) & "|" '77
            'CNPJ/CPF e INSCRICÃO...
            'If Not cnpjCliente.Equals("") Then

            '    strLinha += Exibe_StrDireita("CNPJ: " & String.Format("{0:00\.000\.000\/0000\-00}", Convert.ToInt64(cnpjCliente)), 30) & " " '31
            'Else

            '    strLinha += Exibe_StrDireita("CPF: " & String.Format("{0:000\.000\.000\-00}", Convert.ToInt64(cpfCliente)), 30) & " " '31
            'End If
            'strLinha += Exibe_StrDireita("Pag.: " & "001", 10) & " " '31
            s.WriteLine(Exibe_Str(strLinha, 85))
            s.WriteLine(" +--------------------------------------------------------------------------+")

            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho do Cliente:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub
    'Grava Itens
    Public Sub GravItensProcSaldoContaLaser(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal numRequisicao As String, _
                             ByVal codCliente As String, ByVal nomeCliente As String, ByRef shouldReturn As Boolean)
        shouldReturn = False
        Dim _valorZERO As Int16 = 0
        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mCodProd, mNomeProd, data, strLinha, oper, pedido As String
            Dim mQtdeProd, mVlProd, mVlTotProd As Double
            strLinha = "" : data = "" : oper = "" : pedido = ""
            Dim mCont1, mCont2, index, mQuebraLinha As Integer

            Try
                oConnBDGENOV.Open()

            Catch ex As Exception
            End Try

            Dim sqlItem As New StringBuilder
            Dim cmdItem As NpgsqlCommand
            Dim drItem As NpgsqlDataReader
            Dim mContItens As Integer = _valorZERO, mContItensPg As Integer = _valorZERO, mContPg As Integer = _valorZERO


            sqlItem.Append(consulta)

            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
            drItem = cmdItem.ExecuteReader

            If drItem.HasRows = True Then
                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                's.WriteLine("-------------------------------------------------------------------------------------")
                s.WriteLine(" Codigo---Saldo--------Descrição---------------Pedido--------Data-----OPER--")
                '             xxxxx| ##,###,###| xxxxxxxxxZxxxxxxxxxZxxxxxxx| xxxxxxxx| dd/MM/yyyy| xxxxx  
                s.WriteLine(" +--------------------------------------------------------------------------+")

                mCont1 = 60
            End If

            mContPg = 1
            mContItens = 0
            While drItem.Read

                If (mContPg = 1) AndAlso (mContItensPg >= 39 AndAlso mContItensPg <= 44) Then mQuebraLinha -= 1

                If mContPg = 1 AndAlso mContItensPg = 44 Then

                    s.WriteLine(" +--------------------------------------------------------------------------+")
                    s.WriteLine(" *** CONTINUACAO DA REQUISIÇÃO TRANSPORTADO PARA FOLHA SEGUINTE **  ")
                    s.WriteLine(" +--------------------------------------------------------------------------+")
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)




                    mContPg += 1
                    s.WriteLine("                C O N T I N U A C A O . . .        FOLHA: " & String.Format("{0:D3}", mContPg))
                    s.WriteLine(" +--------------------------------------------------------------------------+")
                    s.WriteLine(Exibe_StrEsquerda("| Cliente : " & nomeCliente, 79) & "|")
                    s.WriteLine(" +--------------------------------------------------------------------------+")
                    s.WriteLine(" Codigo---Saldo--------Descrição---------------Pedido--------Data-----OPER--")
                    '             xxxxx| ##,###,###| xxxxxxxxxZxxxxxxxxxZxxxxxxx| xxxxxxxx| dd/MM/yyyy| xxxxx  
                    s.WriteLine(" +--------------------------------------------------------------------------+")

                    mContItensPg = _valorZERO


                ElseIf mContPg > 1 AndAlso mContItensPg = 46 Then

                    s.WriteLine(" +--------------------------------------------------------------------------+")
                    s.WriteLine(" *** CONTINUACAO DA REQUISIÇÃO TRANSPORTADO PARA FOLHA SEGUINTE **  ")
                    s.WriteLine(" +--------------------------------------------------------------------------+")
                    s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)



                    mContPg += 1
                    s.WriteLine("                C O N T I N U A C A O . . .        FOLHA: " & String.Format("{0:D3}", mContPg))
                    s.WriteLine(" +-----------------------------------------------------------------------------------+")
                    s.WriteLine(Exibe_StrEsquerda("| Cliente : " & nomeCliente, 79) & "|")
                    s.WriteLine(" +-----------------------------------------------------------------------------------+")
                    s.WriteLine(" Codigo---Saldo--------Descrição---------------Pedido--------Data-----OPER--")
                    '             xxxxx| ##,###,###| xxxxxxxxxZxxxxxxxxxZxxxxxxx| xxxxxxxx| dd/MM/yyyy| xxxxx  
                    s.WriteLine(" +--------------------------------------------------------------------------+")

                    mContItensPg = _valorZERO
                    mCont2 = 63

                End If

                mCodProd = drItem(0).ToString
                If mCodProd.Length > 5 Then mCodProd.Substring(mCodProd.Length - 5, 5)
                mNomeProd = drItem(2).ToString
                If mCodProd.Length > 27 Then mNomeProd.Substring(0, 27)
                mQtdeProd = drItem(1)
                pedido = drItem(3).ToString
                data = Format(Convert.ChangeType(drItem(4), GetType(Date)), "dd/MM/yyyy")
                oper = drItem(5).ToString
                If oper.Length > 5 Then oper.Substring(0, 5)


                strLinha = " " & Exibe_StrEsquerda(mCodProd, 5) & "| " & _
                Exibe_StrDireita(Format(mQtdeProd, "#,##0.000"), 9) & " | " & _
                Exibe_StrEsquerda(mNomeProd, 27) & "| " & _
                Exibe_StrDireita(pedido, 8) & "| " & _
                Exibe_StrDireita(data, 10) & "| " & _
                Exibe_StrDireita(oper, 5) & "|"

                s.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))

                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))

                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))

                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))

                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85))
                's.WriteLine(Exibe_Str(strLinha, 85)) 47

                mContItens += 1 : mContItensPg += 1

                'mCont1 -= 1 : mCont2 -= 1
                'mContItens += 27 : mContItensPg += 27
                'mCont1 -= 27 : mCont2 -= 27

                'mContItens += 30 : mContItensPg += 30
                'mCont1 -= 30 : mCont2 -= 30
            End While
            drItem.Close()

            'For index = 0 To mCont1 - 1
            '    '                      1        2         3         4         5         6         7         8         9         0         1         2
            '    '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            '    s.WriteLine("|        |                                                |            |            |")
            'Next

            'For index = 0 To mCont2 - 1
            '    s.WriteLine("|        |                                                |            |            |")
            'Next


            If mContItens > _valorZERO Then

                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine(" +--------------------------------------------------------------------------+")
                strLinha = Exibe_StrEsquerda(" | TOTAIS ITENS..... :       " & Format(mContItens, "##,##0.00"), 76) & "|"
                s.WriteLine(strLinha)
                s.WriteLine(" +--------------------------------------------------------------------------+")
                s.WriteLine(vbNewLine & vbNewLine)
                s.WriteLine("      ______________________________       ______________________________")
                s.WriteLine("            Cliente (Ciente)                          GERENTE")

                ''                      1        2         3         4         5         6         7         8                    9         0         1         2
                ''            12345678901234567890123456789012345678901234567890123456789012345678901234567890           1234567890123456789012345678901234567890
                's.WriteLine("+------------------------------------------------------------------------------+")
                s.WriteLine("")
            End If

            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
            mNomeProd = Nothing : mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing

            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) da Requisição", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub
    ' ######################################################################################




    ' ######################################################################################
    '       RELATÓRIO DE PEDIDO * (IMPRESSORA MATRICIAL)
    'Cabeçalho da Loja
    Public Sub GravCabLojPedidoRelatorioMatricial(ByVal consulta As String, ByRef s As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlLoja As New StringBuilder
            Dim cmdLoja As NpgsqlCommand
            Dim drLoja As NpgsqlDataReader

            sqlLoja.Append(consulta)

            cmdLoja = New NpgsqlCommand(sqlLoja.ToString, oConnBDGENOV)
            drLoja = cmdLoja.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja As String

            nomeLoja = "" : ufLoja = "" : enderLoja = "" : cidLoja = "" : foneLoja = ""
            While drLoja.Read

                nomeLoja = drLoja(0).ToString : enderLoja = drLoja(1).ToString
                foneLoja = drLoja(2).ToString : ufLoja = drLoja(3).ToString : cidLoja = drLoja(4).ToString

            End While
            drLoja.Close() : cmdLoja = Nothing : sqlLoja = Nothing : drLoja = Nothing


            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = "" & Exibe_StrEsquerda(nomeLoja, 16) '& " - "
            'strLinha += Exibe_StrEsquerda(enderLoja, 23) & " - "
            'strLinha += Exibe_StrDireita("Fone:" & foneLoja, 15) & "  "
            'strLinha += Exibe_StrDireita(cidLoja, 8) & "-"
            'strLinha += Exibe_StrDireita(ufLoja, 2)

            s.WriteLine(Exibe_StrEsquerda(strLinha, 80))

            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    ' ######################################################################################


#End Region


#Region "Funções para Tratamento do XML - NFe"

    Public Function lerLoteRetornoErro(ByVal arqXml As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & arqXml & ".ERR"

        While xmlSTR.Equals("") AndAlso mCont <= 20 'Ler 10 segundos

            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            mCont += 1
            If xmlSTR.Equals("") Then Threading.Thread.Sleep(500) 'Passa 1/2 segundos para ler novamente

        End While

        Return xmlSTR
    End Function

    Public Function lerXmlLoteRetornoErro(ByVal chave As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & chave & "-nfe.err"

        While xmlSTR.Equals("") AndAlso mCont <= 20 'Ler 10 segundos

            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            mCont += 1
            If xmlSTR.Equals("") Then Threading.Thread.Sleep(500) 'Passa 1/2 segundos para ler novamente

        End While

        Return xmlSTR
    End Function

    Public Function lerXmlRetorno(ByVal numChaveNFe As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & numChaveNFe & "-num-lot.xml"

        While xmlSTR.Equals("") AndAlso mCont <= 40 'Ler 20 segundos

            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            mCont += 1
            If xmlSTR.Equals("") Then Threading.Thread.Sleep(500) 'Passa 1/2 segundos para ler novamente

        End While

        Return xmlSTR
    End Function

    Public Function lerArqErroRetorno(ByVal numChaveNFe As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & numChaveNFe & "-nfe.err"
        xmlSTR = LerArquivoSalvo(caminhoArquivo)

        Return xmlSTR
    End Function

    Public Function lerXmlLoteRecebido(ByVal numLote As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & numLote & "-rec.xml"

        While xmlSTR.Equals("") AndAlso mCont <= 20 'Ler 10 segundos

            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            If xmlSTR.Equals("") Then
                Threading.Thread.Sleep(500) 'Passa 1/2 segundos para ler novamente
            End If

            mCont += 1
        End While


        Return xmlSTR
    End Function

    Public Function lerXmlLoteRecebido2(ByRef erro As Boolean, ByVal numLote As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & numLote & "-rec.xml"
        erro = False

        While xmlSTR.Equals("") AndAlso mCont <= 40 'Ler 20 segundos

            caminhoArquivo = genp001.pathRetornoXML & "\" & numLote & "-rec.xml"
            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            If xmlSTR.Equals("") Then
                caminhoArquivo = genp001.pathRetornoXML & "\" & numLote & "-rec.err"
                xmlSTR = LerArquivoSalvo(caminhoArquivo)
                If xmlSTR.Equals("") = False Then erro = True
                Threading.Thread.Sleep(500) 'Passa 1/2 segundos para ler novamente
            End If

            mCont += 1
        End While


        Return xmlSTR
    End Function

    Public Function lerXmlLoteRecebidoErr(ByVal numLote As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & numLote & "-rec.err"

        While xmlSTR.Equals("") AndAlso mCont <= 6 'Ler 3 segundos

            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            mCont += 1
            If xmlSTR.Equals("") Then Threading.Thread.Sleep(500) 'Passa 1/2 segundos para ler novamente

        End While


        Return xmlSTR
    End Function

    Public Function lerXmlRecebidoNFeProc(ByRef erro As Boolean, ByVal numRecibo As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & numRecibo & "-pro-rec.xml"
        erro = False

        While xmlSTR.Equals("") AndAlso mCont <= 40 'Ler 20 segundos
            caminhoArquivo = genp001.pathRetornoXML & "\" & numRecibo & "-pro-rec.xml"
            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            If xmlSTR.Equals("") Then
                caminhoArquivo = genp001.pathRetornoXML & "\" & numRecibo & "-pro-rec.err"
                xmlSTR = LerArquivoSalvo(caminhoArquivo)
                If xmlSTR.Equals("") = False Then erro = True
                Threading.Thread.Sleep(500) 'Passa 1/2 segundos para ler novamente
            End If

            mCont += 1
        End While


        Return xmlSTR
    End Function

    Public Function lerXmlEnviado(ByVal AnoMes As String, ByVal chaveNFe As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathEnviadoXML & "\Autorizados\" & AnoMes & "\" & chaveNFe & "-procNFe.xml"

        While xmlSTR.Equals("") AndAlso mCont <= 20 'Ler 10 segundos

            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            mCont += 1
            If xmlSTR.Equals("") Then Threading.Thread.Sleep(500) 'Passa 1 segundo para ler novamente

        End While

        Return xmlSTR
    End Function

    Public Function lerXmlNumLoteNFe(ByVal chaveNFe As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & chaveNFe & "-num-lot.xml"

        While xmlSTR.Equals("") AndAlso mCont <= 6 'Ler 6 segundos

            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            mCont += 1
            If xmlSTR.Equals("") Then Threading.Thread.Sleep(1000) 'Passa 1 segundo para ler novamente

        End While


        Return xmlSTR
    End Function

    Public Function lerXmlIdLoteErro(ByVal nomeArq As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & nomeArq & "-montar-lote.err"

        While xmlSTR.Equals("") AndAlso mCont <= 6 'Ler 3 segundos

            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            mCont += 1
            If xmlSTR.Equals("") Then Threading.Thread.Sleep(500) 'Passa 1/2 segundos para ler novamente

        End While


        Return xmlSTR
    End Function

    Public Function lerXmlProRec(ByVal recibo As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & recibo & "-pro-rec.xml"

        While xmlSTR.Equals("") AndAlso mCont <= 16 'Ler 8 segundos

            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            mCont += 1
            If xmlSTR.Equals("") Then Threading.Thread.Sleep(500) 'Passa 1/2 segundo para ler novamente

        End While

        Return xmlSTR
    End Function

    Public Function LerArquivoSalvo(ByVal arqSaida As String) As String

        'Ler o Arquivo salvo...
        Dim FilePath As String = arqSaida
        Dim arquivoSTR As String = ""

        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            arquivoSTR = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream.Dispose() : MyfileStream = Nothing
        Catch ex As Exception
            arquivoSTR = ""
        End Try


        Return arquivoSTR
    End Function



    'CANCELAMENTO ####################
    Public Function lerXmlRetornoCanc(ByVal numChaveNFe As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & numChaveNFe & "-ret-env-canc.xml"

        While xmlSTR.Equals("") AndAlso mCont <= 40 'Ler 20 segundos

            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            mCont += 1
            If xmlSTR.Equals("") Then Threading.Thread.Sleep(500) 'Passa 1/2 segundos para ler novamente

        End While

        Return xmlSTR
    End Function

    Public Function lerArqErroRetornoCanc(ByVal numChaveNFe As String, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & numChaveNFe & "-env-canc.err"
        xmlSTR = LerArquivoSalvo(caminhoArquivo)

        Return xmlSTR
    End Function


    'CARTA DE CORREÇÃO ####################
    Public Function lerXmlRetornoCCe(ByVal numChaveNFe As String, ByVal seqCCe As Integer, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim mCont As Integer = 0
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & numChaveNFe & "-" & Format(seqCCe, "00") & "-ret-env-cce.xml"

        While xmlSTR.Equals("") AndAlso mCont <= 40 'Ler 20 segundos

            xmlSTR = LerArquivoSalvo(caminhoArquivo)
            mCont += 1
            If xmlSTR.Equals("") Then Threading.Thread.Sleep(500) 'Passa 1/2 segundos para ler novamente

        End While

        Return xmlSTR
    End Function

    Public Function lerArqErroRetornoCCe(ByVal numChaveNFe As String, ByVal seqCCe As Integer, ByVal genp001 As Cl_Genp001) As String

        Dim xmlSTR As String = ""
        Dim caminhoArquivo As String = genp001.pathRetornoXML & "\" & numChaveNFe & "-" & Format(seqCCe, "00") & "-env-cce.err"
        xmlSTR = LerArquivoSalvo(caminhoArquivo)

        Return xmlSTR
    End Function

#End Region

End Class
