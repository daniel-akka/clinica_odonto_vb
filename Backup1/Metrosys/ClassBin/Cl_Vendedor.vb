Public Class Cl_Vendedor

    Dim codigo As String
    Dim nome As String
    Dim endereco As String
    Dim uf As String
    Dim cidade As String
    Dim bairro As String
    Dim fone As String
    Dim celular As String
    Dim comissionado As Boolean
    Dim tipocomissao As String
    Dim alqcomiss As Double
    Dim descMax As Double
    Dim mensagem As String
    Dim rota As Integer
    Dim supervisor As String
    Dim senha As String
    Dim foto As Object
    Dim local As String
    Dim tipo As Integer
    Public x As Boolean
    Public dispositivo As Int16

    Public Sub New()

        Me.codigo = "" : Me.nome = "" : Me.endereco = "" : Me.uf = "" : Me.cidade = ""
        Me.bairro = "" : Me.fone = "" : Me.celular = "" : Me.comissionado = False : Me.tipocomissao = "N"
        Me.alqcomiss = 0.0 : Me.descMax = 0.0 : Me.mensagem = "" : Me.rota = 0 : Me.supervisor = ""
        Me.senha = "" : Me.foto = Nothing : Me.local = "" : Me.tipo = 0 : Me.x = False : Me.dispositivo = 0
    End Sub

    Public Sub zeraValores()

        Me.codigo = "" : Me.nome = "" : Me.endereco = "" : Me.uf = "" : Me.cidade = ""
        Me.bairro = "" : Me.fone = "" : Me.celular = "" : Me.comissionado = False : Me.tipocomissao = "N"
        Me.alqcomiss = 0.0 : Me.descMax = 0.0 : Me.mensagem = "" : Me.rota = 0 : Me.supervisor = ""
        Me.senha = "" : Me.foto = Nothing : Me.local = "" : Me.tipo = 0 : Me.x = False : Me.dispositivo = 0
    End Sub

#Region "  * * Metodos Set e Get * *  "

    Public Property pNome() As String
        Get
            Return Me.nome
        End Get
        Set(ByVal value As String)
            Me.nome = value
        End Set
    End Property

    Public Property pCodigo() As String
        Get
            Return Me.codigo
        End Get
        Set(ByVal value As String)
            Me.codigo = value
        End Set
    End Property

    Public Property pEndereco() As String
        Get
            Return Me.endereco
        End Get
        Set(ByVal value As String)
            Me.endereco = value
        End Set
    End Property

    Public Property pUf() As String
        Get
            Return Me.uf
        End Get
        Set(ByVal value As String)
            Me.uf = value
        End Set
    End Property

    Public Property pCidade() As String
        Get
            Return Me.cidade
        End Get
        Set(ByVal value As String)
            Me.cidade = value
        End Set
    End Property

    Public Property pBairro() As String
        Get
            Return Me.bairro
        End Get
        Set(ByVal value As String)
            Me.bairro = value
        End Set
    End Property

    Public Property pFone() As String
        Get
            Return Me.fone
        End Get
        Set(ByVal value As String)
            Me.fone = value
        End Set
    End Property

    Public Property pCelular() As String
        Get
            Return Me.celular
        End Get
        Set(ByVal value As String)
            Me.celular = value
        End Set
    End Property

    Public Property pComissionado() As Boolean
        Get
            Return Me.comissionado
        End Get
        Set(ByVal value As Boolean)
            Me.comissionado = value
        End Set
    End Property

    Public Property pTipocomissao() As String
        Get
            Return Me.tipocomissao
        End Get
        Set(ByVal value As String)
            Me.tipocomissao = value
        End Set
    End Property

    Public Property pAlqcomiss() As Double
        Get
            Return Me.alqcomiss
        End Get
        Set(ByVal value As Double)
            Me.alqcomiss = value
        End Set
    End Property

    Public Property pDescMAx() As Double
        Get
            Return Me.descMax
        End Get
        Set(ByVal value As Double)
            Me.descMax = value
        End Set
    End Property

    Public Property pMensagem() As String
        Get
            Return Me.mensagem
        End Get
        Set(ByVal value As String)
            Me.mensagem = value
        End Set
    End Property

    Public Property pRota() As Integer
        Get
            Return Me.rota
        End Get
        Set(ByVal value As Integer)
            Me.rota = value
        End Set
    End Property

    Public Property pSupervisor() As String
        Get
            Return Me.supervisor
        End Get
        Set(ByVal value As String)
            Me.supervisor = value
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

    Public Property pFoto() As Object
        Get
            Return Me.foto
        End Get
        Set(ByVal value As Object)
            Me.foto = value
        End Set
    End Property

    Public Property pLocal() As String
        Get
            Return Me.local
        End Get
        Set(ByVal value As String)
            Me.local = value
        End Set
    End Property

    Public Property pTipo() As Integer
        Get
            Return Me.tipo
        End Get
        Set(ByVal value As Integer)
            Me.tipo = value
        End Set
    End Property

#End Region


End Class
