Public Class Cl_Grade

    Dim id As Int64
    Dim codig, tm, cor, loja As String
    Dim qtde As Double


    Public Sub New()

        Me.id = 0 : Me.codig = "" : Me.tm = "" : Me.cor = "" : Me.loja = "" : Me.qtde = 0
    End Sub

    Public Sub zeraValores()

        Me.id = 0 : Me.codig = "" : Me.tm = "" : Me.cor = "" : Me.loja = "" : Me.qtde = 0
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

    Public Property pCodig() As String
        Get
            Return Me.codig
        End Get
        Set(ByVal value As String)
            Me.codig = value
        End Set
    End Property

    Public Property pTm() As String
        Get
            Return Me.tm
        End Get
        Set(ByVal value As String)
            Me.tm = value
        End Set
    End Property

    Public Property pCor() As String
        Get
            Return Me.cor
        End Get
        Set(ByVal value As String)
            Me.cor = value
        End Set
    End Property

    Public Property pLoja() As String
        Get
            Return Me.loja
        End Get
        Set(ByVal value As String)
            Me.loja = value
        End Set
    End Property

    Public Property pQtde() As Double
        Get
            Return Me.qtde
        End Get
        Set(ByVal value As Double)
            Me.qtde = value
        End Set
    End Property

#End Region

End Class
