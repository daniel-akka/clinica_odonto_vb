Public Class Cl_Fatp001

    Private geno As String '5 carac
    Private portad As String '6 carac
    Private tipo As String '3 carac
    Private nfat As String '9 carac
    Private nfisc As String '9 carac
    Private serie As String '3 carac
    Private txdesc As Double
    Private duplic As String '12 carac
    Private emiss As Date
    Private vencto As Date
    Private valor As Double
    Private cartei As String '2 carac
    Private dtpaga As Date
    Private juros As Double
    Private desc As Double
    Private hist As String '36 carac
    Private sit As String '1 carac
    Private stat As Boolean
    Private banco As String '3 carac
    Private outros As Double


    Public Sub New()

        Me.geno = "" : Me.portad = "" : Me.tipo = "" : Me.nfat = "" : Me.nfisc = ""
        Me.serie = "" : Me.txdesc = 0 : Me.duplic = "" : Me.valor = 0 : Me.cartei = ""
        Me.juros = 0 : Me.desc = 0 : Me.hist = "" : Me.sit = "" : Me.stat = False
        Me.banco = "" : Me.outros = 0
    End Sub


#Region " * *  Metodos Set e Get  * * "

    Public Property pGeno() As String
        Get
            Return Me.geno
        End Get
        Set(ByVal value As String)
            Me.geno = value
        End Set
    End Property

    Public Property pPortad() As String
        Get
            Return Me.portad
        End Get
        Set(ByVal value As String)
            Me.portad = value
        End Set
    End Property

    Public Property pTipo() As String
        Get
            Return Me.tipo
        End Get
        Set(ByVal value As String)
            Me.tipo = value
        End Set
    End Property

    Public Property pNfat() As String
        Get
            Return Me.nfat
        End Get
        Set(ByVal value As String)
            Me.nfat = value
        End Set
    End Property

    Public Property pNfisc() As String
        Get
            Return Me.nfisc
        End Get
        Set(ByVal value As String)
            Me.nfisc = value
        End Set
    End Property

    Public Property pSerie() As String
        Get
            Return Me.serie
        End Get
        Set(ByVal value As String)
            Me.serie = value
        End Set
    End Property

    Public Property pTxdesc() As Double
        Get
            Return Me.txdesc
        End Get
        Set(ByVal value As Double)
            Me.txdesc = value
        End Set
    End Property

    Public Property pDuplic() As String
        Get
            Return Me.duplic
        End Get
        Set(ByVal value As String)
            Me.duplic = value
        End Set
    End Property

    Public Property pEmiss() As Date
        Get
            Return Me.emiss
        End Get
        Set(ByVal value As Date)
            Me.emiss = value
        End Set
    End Property

    Public Property pVencto() As Date
        Get
            Return Me.vencto
        End Get
        Set(ByVal value As Date)
            Me.vencto = value
        End Set
    End Property

    Public Property pValor() As Double
        Get
            Return Me.valor
        End Get
        Set(ByVal value As Double)
            Me.valor = value
        End Set
    End Property

    Public Property pCartei() As String
        Get
            Return Me.cartei
        End Get
        Set(ByVal value As String)
            Me.cartei = value
        End Set
    End Property

    Public Property pDtpaga() As Date
        Get
            Return Me.dtpaga
        End Get
        Set(ByVal value As Date)
            Me.dtpaga = value
        End Set
    End Property

    Public Property pJuros() As Double
        Get
            Return Me.juros
        End Get
        Set(ByVal value As Double)
            Me.juros = value
        End Set
    End Property

    Public Property pDesc() As Double
        Get
            Return Me.desc
        End Get
        Set(ByVal value As Double)
            Me.desc = value
        End Set
    End Property

    Public Property pHist() As String
        Get
            Return Me.hist
        End Get
        Set(ByVal value As String)
            Me.hist = value
        End Set
    End Property

    Public Property pSit() As String
        Get
            Return Me.sit
        End Get
        Set(ByVal value As String)
            Me.sit = value
        End Set
    End Property

    Public Property pStat() As Boolean
        Get
            Return Me.stat
        End Get
        Set(ByVal value As Boolean)
            Me.stat = value
        End Set
    End Property

    Public Property pBanco() As String
        Get
            Return Me.banco
        End Get
        Set(ByVal value As String)
            Me.banco = value
        End Set
    End Property

    Public Property pOutros() As Double
        Get
            Return Me.outros
        End Get
        Set(ByVal value As Double)
            Me.outros = value
        End Set
    End Property

#End Region

    Public Sub zeraValores()

        Me.geno = "" : Me.portad = "" : Me.tipo = "" : Me.nfat = "" : Me.nfisc = "" : Me.serie = ""
        Me.txdesc = 0 : Me.duplic = "" : Me.valor = 0 : Me.cartei = "" : Me.juros = 0 : Me.desc = 0
        Me.hist = "" : Me.sit = "" : Me.stat = False : Me.banco = "" : Me.outros = 0 : Me.emiss = Nothing
        Me.vencto = Nothing : Me.dtpaga = Nothing
    End Sub

End Class
