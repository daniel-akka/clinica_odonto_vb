Imports System.IO

Public Class Cl_EscreveArquivo
    Inherits StreamWriter

    Public contLinhasArquivo As Integer 'contador para o total de linhas do arquivo
    Public qtdLinhasPorPagina As Integer
    Public contLinhasPorPagina As Integer
    Public qtdSaltosLinhaNextPag As Integer 'quantidade de quebras de linha pra proxima pagina
    Public paginaAtual As Integer
    Public nextPag, chamaEvento As Boolean
    Public Event SaltandoLinhasEvento()


    Public Sub New(ByVal stream As Stream)

        MyBase.New(stream)
        Me.contLinhasArquivo = 0
        Me.qtdLinhasPorPagina = 0
        Me.contLinhasPorPagina = 0
        Me.qtdSaltosLinhaNextPag = 0
        Me.paginaAtual = 1
        Me.nextPag = False
    End Sub

    Public Sub EscreveLn(ByVal linha As String)


        MyBase.WriteLine(linha)
        Me.contLinhasArquivo += 1

        If Me.qtdLinhasPorPagina > 0 Then

            Me.contLinhasPorPagina += 1
            If Me.contLinhasPorPagina = qtdLinhasPorPagina Then 'Verifica se já chegou no limite de linhas por pagina

                Me.SaltandoLinhas(qtdSaltosLinhaNextPag)
                Me.nextPag = True
                Me.paginaAtual += 1
                Me.contLinhasPorPagina = 0
                If chamaEvento Then RaiseEvent SaltandoLinhasEvento()

            Else
                Me.nextPag = False
            End If
        End If

    End Sub

    Public Sub SaltandoLinhas(ByVal quantidadeSaltos As Integer)

        For i As Integer = 1 To quantidadeSaltos

            MyBase.WriteLine("")
            Me.contLinhasArquivo += 1
        Next
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
