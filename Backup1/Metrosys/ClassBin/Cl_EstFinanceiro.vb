Public Class Cl_EstFinanceiro

    Dim id As Int64
    Dim loja, tiposaldo As String
    Dim totalcusto As Double
    Dim totalvenda As Double
    Dim data As Date
    Dim totalitens As Integer


    Public Sub New()

        Me.loja = "" : Me.totalcusto = 0.0 : Me.totalvenda = 0.0 : Me.data = Nothing : Me.totalitens = 0
        Me.id = 0 : Me.tiposaldo = "P"
    End Sub

    Public Sub zeraValores()

        Me.loja = "" : Me.totalcusto = 0.0 : Me.totalvenda = 0.0 : Me.data = Nothing : Me.totalitens = 0
        Me.id = 0 : Me.tiposaldo = "P"
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

    Public Property pLoja() As String
        Get
            Return Me.loja
        End Get
        Set(ByVal value As String)
            Me.loja = value
        End Set
    End Property

    Public Property pTotalCusto() As Double
        Get
            Return Me.totalcusto
        End Get
        Set(ByVal value As Double)
            Me.totalcusto = value
        End Set
    End Property

    Public Property pTotalVenda() As Double
        Get
            Return Me.totalvenda
        End Get
        Set(ByVal value As Double)
            Me.totalvenda = value
        End Set
    End Property

    Public Property pData() As Date
        Get
            Return Me.data
        End Get
        Set(ByVal value As Date)
            Me.data = value
        End Set
    End Property

    Public Property pTotalItens() As Integer
        Get
            Return Me.totalitens
        End Get
        Set(ByVal value As Integer)
            Me.totalitens = value
        End Set
    End Property

    Public Property pTipoSaldo() As String
        Get
            Return Me.tiposaldo
        End Get
        Set(ByVal value As String)
            Me.tiposaldo = value
        End Set
    End Property

#End Region

End Class
