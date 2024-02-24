Imports System.IO

Public Class Cl_EscreveArquivo
    Inherits StreamWriter

    Public contLinhasArquivo As Integer 'contador para o total de linhas do arquivo
    Public qtdLinhasPorPagina As Integer
    Public contLinhasPorPagina As Integer
    Public qtdSaltosLinhaNextPag As Integer 'quantidade de quebras de linha pra proxima pagina
    Public paginaAtual, qtdeRegistros, contRegistros As Integer
    Public qtdeLinhasInfoFinal As String 'Quantidade de linhas das informações finais
    Public aindaTemItens As Boolean = True 'Informa se ainda tem itens a serem impressos
    Public nextPag, chamaEvento, chamaEventoAntesSaltos, contarRegistros As Boolean

    'Controlar a Impressao
    Public conteudoArquivo As String = ""
    Public qtdeSaltosNextPagImpressao As Int16 = 0
    Public strInicioLinha As String = ""


    'Eventos:
    Public Event SaltandoLinhasEvento()
    Public Event EventoAntesSalto()


    Public Sub New(ByVal stream As Stream)

        MyBase.New(stream)
        Me.contLinhasArquivo = 0
        Me.qtdLinhasPorPagina = 0
        Me.contLinhasPorPagina = 0
        Me.qtdSaltosLinhaNextPag = 0
        Me.paginaAtual = 1
        Me.nextPag = False
        Me.conteudoArquivo = ""
    End Sub

    Public Sub EscreveLn(ByVal linha As String)

        linha = strInicioLinha & linha
        MyBase.WriteLine(linha) : Me.conteudoArquivo += linha & vbNewLine
        Me.contLinhasArquivo += 1

        If Me.qtdLinhasPorPagina > 0 Then

            Me.contLinhasPorPagina += 1
            If Me.contLinhasPorPagina = qtdLinhasPorPagina Then 'Verifica se já chegou no limite de linhas por pagina

                If Me.contarRegistros Then

                    If (Me.contRegistros < Me.qtdeRegistros) Then

                        If chamaEventoAntesSaltos Then RaiseEvent EventoAntesSalto()
                        Me.SaltandoLinhas(qtdSaltosLinhaNextPag) : Me.SaltandoLinhasTela(Me.qtdeSaltosNextPagImpressao)
                        Me.nextPag = True
                        Me.paginaAtual += 1
                        Me.contLinhasPorPagina = 0
                        If chamaEvento Then RaiseEvent SaltandoLinhasEvento()
                    End If


                Else
                    If chamaEventoAntesSaltos Then RaiseEvent EventoAntesSalto()
                    Me.SaltandoLinhas(qtdSaltosLinhaNextPag) : Me.SaltandoLinhasTela(Me.qtdeSaltosNextPagImpressao)
                    Me.nextPag = True
                    Me.paginaAtual += 1
                    Me.contLinhasPorPagina = 0
                    If chamaEvento Then RaiseEvent SaltandoLinhasEvento()

                End If


            Else
                Me.nextPag = False
            End If
        End If

    End Sub

    Public Sub EscreveLnAux(ByVal linha As String)

        linha = strInicioLinha & linha
        MyBase.WriteLine(linha) : Me.conteudoArquivo += linha & vbNewLine
        Me.contLinhasArquivo += 1

    End Sub

    Public Sub SaltandoLinhas(ByVal quantidadeSaltos As Integer)

        For i As Integer = 1 To quantidadeSaltos

            MyBase.WriteLine("") : Me.contLinhasArquivo += 1
        Next
    End Sub

    Public Sub SaltandoLinhasTela(ByVal quantidadeSaltos As Integer)

        'Saltos na Impressao na Tela
        If Me.qtdeSaltosNextPagImpressao > 0 Then

            For i As Integer = 1 To quantidadeSaltos

                Me.conteudoArquivo += vbNewLine
            Next
        End If

    End Sub


    Public Sub SaltandoLinhasComEscreveLn(ByVal quantidadeSaltos As Integer)

        For i As Integer = 1 To quantidadeSaltos

            Me.EscreveLn("") 
        Next

    End Sub

    Public Sub SaltandoLinhas() Handles Me.SaltandoLinhasEvento
        'Só para chamar um método de cabeçalho do arquivo assim que saltar para próxima pagina
    End Sub

End Class
