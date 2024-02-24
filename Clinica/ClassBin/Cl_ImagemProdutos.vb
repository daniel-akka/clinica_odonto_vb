Public Class Cl_ImagemProdutos
    Dim id As Int64
    Dim nome As String
    Dim imagem As String 'Caminho da Imagem para Importar
    'Dim caminhoImagem As String

    Public Sub New()

        Me.id = 0 : Me.nome = "" : Me.imagem = ""
    End Sub

    Public Sub zeraValores()

       Me.id = 0 : Me.nome = "" : Me.imagem = ""
    End Sub

#Region "  * * Metodos Set e Get * *  "

    Public Property pId() As Int64
        Get
            Return Me.id
        End Get
        Set(ByVal value As Int64)
            Me.id = value
        End Set
    End Property

    Public Property pNome() As String
        Get
            Return Me.nome
        End Get
        Set(ByVal value As String)
            Me.nome = value
        End Set
    End Property

    Public Property pImagem() As String
        Get
            Return Me.imagem
        End Get
        Set(ByVal value As String)
            Me.imagem = value
        End Set
    End Property

#End Region

End Class
