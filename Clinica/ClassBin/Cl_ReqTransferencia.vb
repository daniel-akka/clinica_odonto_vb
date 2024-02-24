Public Class Cl_ReqTransferencia

    Private id As Int64
    Private reqnumero As String
    Private reqdata As Date
    Private reqcodprod As String
    Private reqqtde As Double
    Private requsuario As String
    Private reqcoddestino As String
    Private reqnomedestino As String

    Public Sub New()

        Me.id = 0 : Me.reqnumero = "" : Me.reqdata = Nothing : Me.reqcodprod = "" : Me.reqqtde = 0.0
        Me.requsuario = "" : Me.reqcoddestino = "" : Me.reqnomedestino = ""
    End Sub


#Region "   * *  Metodos Set e Get  * *   "

    Public Property pId() As Int64
        Get
            Return Me.id
        End Get
        Set(ByVal value As Int64)
            Me.id = value
        End Set
    End Property

    Public Property pReqNumero() As String
        Get
            Return Me.reqnumero
        End Get
        Set(ByVal value As String)
            Me.reqnumero = value
        End Set
    End Property

    Public Property pReqData() As Date
        Get
            Return Me.reqdata
        End Get
        Set(ByVal value As Date)
            Me.reqdata = value
        End Set
    End Property

    Public Property pReqCodprod() As String
        Get
            Return Me.reqcodprod
        End Get
        Set(ByVal value As String)
            Me.reqcodprod = value
        End Set
    End Property

    Public Property pReqQtde() As Double
        Get
            Return Me.reqqtde
        End Get
        Set(ByVal value As Double)
            Me.reqqtde = value
        End Set
    End Property

    Public Property pReqUsuario() As String
        Get
            Return Me.requsuario
        End Get
        Set(ByVal value As String)
            Me.requsuario = value
        End Set
    End Property

    Public Property pReqCoddestino() As String
        Get
            Return Me.reqcoddestino
        End Get
        Set(ByVal value As String)
            Me.reqcoddestino = value
        End Set
    End Property

    Public Property pReqNomedestino() As String
        Get
            Return Me.reqnomedestino
        End Get
        Set(ByVal value As String)
            Me.reqnomedestino = value
        End Set
    End Property

#End Region

    Public Sub zeraValores()

        Me.id = 0 : Me.reqnumero = "" : Me.reqdata = Nothing : Me.reqcodprod = "" : Me.reqqtde = 0.0
        Me.requsuario = "" : Me.reqcoddestino = "" : Me.reqnomedestino = ""
    End Sub

End Class
