Public Class Cl_Usuario

    Dim id As Int64
    Dim local As String
    Dim nome As String
    Dim login As String
    Dim senha As String
    Dim privilegio As Boolean
    Dim bloqueado As Boolean
    Dim dataNascimento As Date
    Dim codvendedor As String
    Dim cargo As Integer
    Dim codcaixa As String

    Public Sub New()

        Me.local = "" : Me.nome = "" : Me.login = "" : Me.senha = "" : Me.privilegio = False
        Me.bloqueado = False : Me.dataNascimento = Nothing : Me.codvendedor = "" : Me.cargo = 0
        Me.id = 0 : Me.codcaixa = ""
    End Sub

    Public Sub zeraValores()

        Me.local = "" : Me.nome = "" : Me.login = "" : Me.senha = "" : Me.privilegio = False
        Me.bloqueado = False : Me.dataNascimento = Nothing : Me.codvendedor = "" : Me.cargo = 0
        Me.id = 0 : Me.codcaixa = ""
    End Sub

#Region "  * * Metodos Set e Get * *  "

    Public Property pLocal() As String
        Get
            Return Me.local
        End Get
        Set(ByVal value As String)
            Me.local = value
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

    Public Property pLogin() As String
        Get
            Return Me.login
        End Get
        Set(ByVal value As String)
            Me.login = value
        End Set
    End Property

    Public Property pSenha() As String
        Get
            Return Me.senha
        End Get
        Set(ByVal value As String)
            Me.senha = value
        End Set
    End Property

    Public Property pPrivilegio() As Boolean
        Get
            Return Me.privilegio
        End Get
        Set(ByVal value As Boolean)
            Me.privilegio = value
        End Set
    End Property

    Public Property pBloqueado() As Boolean
        Get
            Return Me.bloqueado
        End Get
        Set(ByVal value As Boolean)
            Me.bloqueado = value
        End Set
    End Property

    Public Property pDataNascimento() As Date
        Get
            Return Me.dataNascimento
        End Get
        Set(ByVal value As Date)
            Me.dataNascimento = value
        End Set
    End Property

    Public Property pCodVendedor() As String
        Get
            Return Me.codvendedor
        End Get
        Set(ByVal value As String)
            Me.codvendedor = value
        End Set
    End Property

    Public Property pCargo() As Integer
        Get
            Return Me.cargo
        End Get
        Set(ByVal value As Integer)
            Me.cargo = value
        End Set
    End Property

    Public Property pId() As Int64
        Get
            Return Me.id
        End Get
        Set(ByVal value As Int64)
            Me.id = value
        End Set
    End Property

    Public Property pCodCaixa() As String
        Get
            Return Me.codcaixa
        End Get
        Set(ByVal value As String)
            Me.codcaixa = value
        End Set
    End Property

#End Region

End Class
