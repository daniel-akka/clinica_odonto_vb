Public Class Cl_CondPagto

    Private descricao As String
    Private cond1 As Integer
    Private cond2 As Integer
    Private cond3 As Integer
    Private cond4 As Integer
    Private cond5 As Integer
    Private cond6 As Integer
    Private cond7 As Integer
    Private colpreco As String
    Private colrotas As String
    Private qtdeparcelas As Integer
    Private intervaloparcelas As Integer
    Private acrescimo As Double
    Private tipo As Integer

    Public Sub New()

        Me.descricao = "" : Me.cond1 = 0 : Me.cond2 = 0 : Me.cond3 = 0 : Me.cond4 = 0
        Me.cond5 = 0 : Me.cond6 = 0 : Me.cond7 = 0 : Me.colpreco = "" : Me.colrotas = ""
        Me.qtdeparcelas = 0 : Me.intervaloparcelas = 0 : Me.acrescimo = 0.0 : Me.tipo = 1
    End Sub

    Public Sub zeraValores()

        Me.descricao = "" : Me.cond1 = 0 : Me.cond2 = 0 : Me.cond3 = 0 : Me.cond4 = 0
        Me.cond5 = 0 : Me.cond6 = 0 : Me.cond7 = 0 : Me.colpreco = "" : Me.colrotas = ""
        Me.qtdeparcelas = 0 : Me.intervaloparcelas = 0 : Me.acrescimo = 0.0 : Me.tipo = 1
    End Sub


#Region "   * *  Métodos Set e Get  * *   "


    Property pDescricao() As String
        Get
            Return Me.descricao
        End Get
        Set(ByVal value As String)
            Me.descricao = value
        End Set
    End Property

    Property pCond1() As Integer
        Get
            Return Me.cond1
        End Get
        Set(ByVal value As Integer)
            Me.cond1 = value
        End Set
    End Property

    Property pCond2() As Integer
        Get
            Return Me.cond2
        End Get
        Set(ByVal value As Integer)
            Me.cond2 = value
        End Set
    End Property

    Property pCond3() As Integer
        Get
            Return Me.cond3
        End Get
        Set(ByVal value As Integer)
            Me.cond3 = value
        End Set
    End Property

    Property pCond4() As Integer
        Get
            Return Me.cond4
        End Get
        Set(ByVal value As Integer)
            Me.cond4 = value
        End Set
    End Property

    Property pCond5() As Integer
        Get
            Return Me.cond5
        End Get
        Set(ByVal value As Integer)
            Me.cond5 = value
        End Set
    End Property

    Property pCond6() As Integer
        Get
            Return Me.cond6
        End Get
        Set(ByVal value As Integer)
            Me.cond6 = value
        End Set
    End Property

    Property pCond7() As Integer
        Get
            Return Me.cond7
        End Get
        Set(ByVal value As Integer)
            Me.cond7 = value
        End Set
    End Property

    Property pColpreco() As String
        Get
            Return Me.colpreco
        End Get
        Set(ByVal value As String)
            Me.colpreco = value
        End Set
    End Property

    Property pColrotas() As String
        Get
            Return Me.colrotas
        End Get
        Set(ByVal value As String)
            Me.colrotas = value
        End Set
    End Property

    Property pQtdeparcelas() As Integer
        Get
            Return Me.qtdeparcelas
        End Get
        Set(ByVal value As Integer)
            Me.qtdeparcelas = value
        End Set
    End Property

    Property pIntervaloparcelas() As Integer
        Get
            Return Me.intervaloparcelas
        End Get
        Set(ByVal value As Integer)
            Me.intervaloparcelas = value
        End Set
    End Property

    Property pAcrescimo() As Double
        Get
            Return Me.acrescimo
        End Get
        Set(ByVal value As Double)
            Me.acrescimo = value
        End Set
    End Property

    Property pTipo() As Integer
        Get
            Return Me.tipo
        End Get
        Set(ByVal value As Integer)
            Me.tipo = value
        End Set
    End Property


#End Region

End Class
