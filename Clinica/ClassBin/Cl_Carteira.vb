Public Class Cl_Carteira

    Private loja As String
    Private contrato As String
    Private banco As Integer
    Private agencia As Integer
    Private conta As Integer
    Private digito As String
    Private carteira As String
    Private agenciadigito As String
    Private nossonumero As String
    Private instrucao1 As String
    Private instrucao2 As String
    Private instrucao3 As String
    Private instrucao4 As String
    Private instrucao5 As String

    Public Sub New()
        loja = "" : contrato = "" : banco = 0 : agencia = 0 : conta = 0 : digito = "" : carteira = ""
        agenciadigito = "" : nossonumero = "" : instrucao1 = "" : instrucao2 = "" : instrucao3 = ""
        instrucao4 = "" : instrucao5 = ""
    End Sub

    Public Sub zeraValores()
        loja = "" : contrato = "" : banco = 0 : agencia = 0 : conta = 0 : digito = "" : carteira = ""
        agenciadigito = "" : nossonumero = "" : instrucao1 = "" : instrucao2 = "" : instrucao3 = ""
        instrucao4 = "" : instrucao5 = ""
    End Sub

#Region "  *  *  *    Metodos Set e Get    *  *  *"

    Public Property pLoja() As String
        Get
            Return Me.loja
        End Get
        Set(ByVal value As String)
            Me.loja = value
        End Set
    End Property

    Public Property pContrato() As String
        Get
            Return Me.contrato
        End Get
        Set(ByVal value As String)
            Me.contrato = value
        End Set
    End Property

    Public Property pbanco() As Integer
        Get
            Return Me.banco
        End Get
        Set(ByVal value As Integer)
            Me.banco = value
        End Set
    End Property

    Public Property pagencia() As Integer
        Get
            Return Me.agencia
        End Get
        Set(ByVal value As Integer)
            Me.agencia = value
        End Set
    End Property

    Public Property pconta() As Integer
        Get
            Return Me.conta
        End Get
        Set(ByVal value As Integer)
            Me.conta = value
        End Set
    End Property

    Public Property pdigito() As String
        Get
            Return Me.digito
        End Get
        Set(ByVal value As String)
            Me.digito = value
        End Set
    End Property

    Public Property pcarteira() As String
        Get
            Return Me.carteira
        End Get
        Set(ByVal value As String)
            Me.carteira = value
        End Set
    End Property

    Public Property pagenciadigito() As String
        Get
            Return Me.agenciadigito
        End Get
        Set(ByVal value As String)
            Me.agenciadigito = value
        End Set
    End Property

    Public Property pnossonumero() As String
        Get
            Return Me.nossonumero
        End Get
        Set(ByVal value As String)
            Me.nossonumero = value
        End Set
    End Property

    Public Property pinstrucao1() As String
        Get
            Return Me.instrucao1
        End Get
        Set(ByVal value As String)
            Me.instrucao1 = value
        End Set
    End Property

    Public Property pinstrucao2() As String
        Get
            Return Me.instrucao2
        End Get
        Set(ByVal value As String)
            Me.instrucao2 = value
        End Set
    End Property

    Public Property pinstrucao3() As String
        Get
            Return Me.instrucao3
        End Get
        Set(ByVal value As String)
            Me.instrucao3 = value
        End Set
    End Property

    Public Property pinstrucao4() As String
        Get
            Return Me.instrucao4
        End Get
        Set(ByVal value As String)
            Me.instrucao4 = value
        End Set
    End Property

    Public Property pinstrucao5() As String
        Get
            Return Me.instrucao5
        End Get
        Set(ByVal value As String)
            Me.instrucao5 = value
        End Set
    End Property
#End Region

End Class
