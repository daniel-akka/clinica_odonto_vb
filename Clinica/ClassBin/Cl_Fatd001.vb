Public Class Cl_Fatd001

    Private geno As String
    Private portad As String
    Private tipo As String
    Private nfat As String
    Private nfisc As String
    Private serie As String
    Private txdesc As String
    Private duplic As String
    Private emiss As Date
    Private vencto As Date
    Private valor As Double
    Private cartei As String
    Private dtpaga As Date
    Private juros As Double
    Private desc As Double
    Private banco As Integer
    Private hist As String
    Private hvenc As String
    Private protest As Double
    Private outros As Double
    Private codi1 As String
    Private codi2 As String
    Private codi3 As String
    Private sit As String
    Private stat As Boolean
    Private loja As String
    Private ctactb As String
    Private ctareduz As String
    Private nnumero As String
    Private imp As String
    Private mtransm As String
    Private vend As String
    Private valorpago As Double
    Private valordevido As Double
    Private vlcomis As Double

    Public Sub New()
        Me.geno = "" : Me.portad = "" : Me.tipo = "" : Me.nfat = "" : Me.nfisc = "" : Me.serie = "" : Me.txdesc = "" : Me.duplic = ""
        Me.valor = 0.0 : Me.cartei = "" : Me.juros = 0.0 : Me.desc = 0.0 : Me.banco = 0 : Me.hist = ""
        Me.hvenc = "" : Me.protest = 0.0 : Me.outros = 0.0 : Me.codi1 = "" : Me.codi2 = "" : Me.codi3 = "" : Me.sit = "" : Me.stat = False
        Me.loja = "" : Me.ctactb = "" : Me.ctareduz = "" : Me.nnumero = "" : Me.imp = "" : Me.mtransm = "" : Me.vend = ""
        Me.valorpago = 0.0 : Me.valordevido = 0.0 : Me.vlcomis = 0.0
    End Sub

    Public Sub ZeraValores()
        Me.geno = "" : Me.portad = "" : Me.tipo = "" : Me.nfat = "" : Me.nfisc = "" : Me.serie = "" : Me.txdesc = "" : Me.duplic = ""
        Me.valor = 0.0 : Me.cartei = "" : Me.juros = 0.0 : Me.desc = 0.0 : Me.banco = 0 : Me.hist = ""
        Me.hvenc = "" : Me.protest = 0.0 : Me.outros = 0.0 : Me.codi1 = "" : Me.codi2 = "" : Me.codi3 = "" : Me.sit = "" : Me.stat = False
        Me.loja = "" : Me.ctactb = "" : Me.ctareduz = "" : Me.nnumero = "" : Me.imp = "" : Me.mtransm = "" : Me.vend = ""
        Me.valorpago = 0.0 : Me.valordevido = 0.0 : Me.vlcomis = 0.0
    End Sub

#Region "    * *  Metodos Set e Get  * * "

    Public Property ft_Geno() As String
        Get
            Return Me.geno
        End Get
        Set(ByVal value As String)
            Me.geno = value
        End Set
    End Property

    Public Property ft_portad() As String
        Get
            Return Me.portad
        End Get
        Set(ByVal value As String)
            Me.portad = value
        End Set
    End Property
    Public Property ft_Tipo() As String
        Get
            Return Me.tipo
        End Get
        Set(ByVal value As String)
            Me.tipo = value
        End Set
    End Property

    Public Property ft_Nfat() As String
        Get
            Return Me.nfat
        End Get
        Set(ByVal value As String)
            Me.nfat = value
        End Set
    End Property

    Public Property ft_Nfisc() As String
        Get
            Return Me.nfisc
        End Get
        Set(ByVal value As String)
            Me.nfisc = value
        End Set
    End Property

    Public Property ft_Serie() As String
        Get
            Return Me.serie
        End Get
        Set(ByVal value As String)
            Me.serie = value
        End Set
    End Property

    Public Property ft_Txdesc() As Double
        Get
            Return Me.txdesc
        End Get
        Set(ByVal value As Double)
            Me.txdesc = value
        End Set
    End Property

    Public Property ft_Duplic() As String
        Get
            Return Me.duplic
        End Get
        Set(ByVal value As String)
            Me.duplic = value
        End Set
    End Property


    Public Property ft_Emiss() As Date
        Get
            Return Me.emiss
        End Get
        Set(ByVal value As Date)
            Me.emiss = value
        End Set
    End Property

    Public Property ft_Vencto() As Date
        Get
            Return Me.vencto
        End Get
        Set(ByVal value As Date)
            Me.vencto = value
        End Set
    End Property

    Public Property ft_Valor() As Double
        Get
            Return Me.valor
        End Get
        Set(ByVal value As Double)
            Me.valor = value
        End Set
    End Property

    Public Property ft_Cartei() As String
        Get
            Return Me.cartei
        End Get
        Set(ByVal value As String)
            Me.cartei = value
        End Set
    End Property

    Public Property ft_dtpaga() As Date
        Get
            Return Me.dtpaga
        End Get
        Set(ByVal value As Date)
            Me.dtpaga = value
        End Set
    End Property

    Public Property ft_juros() As Double
        Get
            Return Me.juros
        End Get
        Set(ByVal value As Double)
            Me.juros = value
        End Set
    End Property


    Public Property ft_desc() As Double
        Get
            Return Me.desc
        End Get
        Set(ByVal value As Double)
            Me.desc = value
        End Set
    End Property
    Public Property ft_banco() As Integer
        Get
            Return Me.banco
        End Get
        Set(ByVal value As Integer)
            Me.banco = value
        End Set
    End Property

    Public Property ft_hist() As String
        Get
            Return Me.hist
        End Get
        Set(ByVal value As String)
            Me.hist = value
        End Set
    End Property

    Public Property ft_hvenc() As String
        Get
            Return Me.hvenc
        End Get
        Set(ByVal value As String)
            Me.hvenc = value
        End Set
    End Property

    Public Property ft_protest() As Double
        Get
            Return Me.protest
        End Get
        Set(ByVal value As Double)
            Me.protest = value
        End Set
    End Property
    Public Property ft_outros() As Double
        Get
            Return Me.outros
        End Get
        Set(ByVal value As Double)
            Me.outros = value
        End Set
    End Property

    Public Property ft_codi1() As String
        Get
            Return Me.codi1
        End Get
        Set(ByVal value As String)
            Me.codi1 = value
        End Set
    End Property
    Public Property ft_codi2() As String
        Get
            Return Me.codi2
        End Get
        Set(ByVal value As String)
            Me.codi2 = value
        End Set
    End Property
    Public Property ft_codi3() As String
        Get
            Return Me.codi3
        End Get
        Set(ByVal value As String)
            Me.codi3 = value
        End Set
    End Property

    Public Property ft_sit() As String
        Get
            Return Me.sit
        End Get
        Set(ByVal value As String)
            Me.sit = value
        End Set
    End Property
    Public Property ft_stat() As Boolean
        Get
            Return Me.stat
        End Get
        Set(ByVal value As Boolean)
            Me.stat = value
        End Set
    End Property
    Public Property ft_loja() As String
        Get
            Return Me.loja
        End Get
        Set(ByVal value As String)
            Me.loja = value
        End Set
    End Property
    Public Property ft_ctactb() As String
        Get
            Return Me.ctactb
        End Get
        Set(ByVal value As String)
            Me.ctactb = value
        End Set
    End Property

    Public Property ft_ctareduz() As String
        Get
            Return Me.ctareduz
        End Get
        Set(ByVal value As String)
            Me.ctareduz = value
        End Set
    End Property

    Public Property ft_nnumero() As String
        Get
            Return Me.nnumero
        End Get
        Set(ByVal value As String)
            Me.nnumero = value
        End Set
    End Property

    Public Property ft_imp() As String
        Get
            Return Me.imp
        End Get
        Set(ByVal value As String)
            Me.imp = value
        End Set
    End Property

    Public Property ft_mtransm() As String
        Get
            Return Me.mtransm
        End Get
        Set(ByVal value As String)
            Me.mtransm = value
        End Set
    End Property

    Public Property ft_vend() As String
        Get
            Return Me.vend
        End Get
        Set(ByVal value As String)
            Me.vend = value
        End Set
    End Property

    Public Property ft_valorpago() As Double
        Get
            Return Me.valorpago
        End Get
        Set(ByVal value As Double)
            Me.valorpago = value
        End Set
    End Property

    Public Property ft_valordevido() As Double
        Get
            Return Me.valordevido
        End Get
        Set(ByVal value As Double)
            Me.valordevido = value
        End Set
    End Property

    Public Property ft_vlcomis() As Double
        Get
            Return Me.vlcomis
        End Get
        Set(ByVal value As Double)
            Me.vlcomis = value
        End Set
    End Property
#End Region

End Class

