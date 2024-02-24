Public Class Cl_Geno

    Private codig As String '5 carac
    Private geno As String '45 carac
    Private ender As String '34 carac
    Private cid As String '30 carac
    Private uf As String '2 carac
    Private cep As String '8 carac
    Private bair As String '25 carac
    Private cgc As String '14 carac
    Private insc As String '14 carac
    Private fone As String '10 carac
    Private fax As String '10 carac
    Private mun As String '7 carac
    Private coduf As String '2 carac
    Private email As String '50 carac
    Private razaosocial As String '45 carac
    Private aidf As String
    Private cnae As String '7 carac
    Private crt As String '1 carac
    Private vinculo As Integer
    Private esquemaestab As String '6 carac
    Private esquemavinc As String '6 carac
    Private retencao As Boolean
    Private pis, cofins, csll, irenda, sn As Double
    Private ativEmpresa As Int16, blBancoPadrao As String, blOptPadrao As Int16


    Public Sub New()

        Me.codig = "" : Me.geno = "" : Me.ender = "" : Me.cid = "" : Me.uf = ""
        Me.cep = "" : Me.bair = "" : Me.cgc = "" : Me.insc = "" : Me.fone = ""
        Me.fax = "" : Me.mun = "" : Me.coduf = "" : Me.email = "" : Me.razaosocial = ""
        Me.aidf = "" : Me.cnae = "" : Me.crt = "" : Me.vinculo = 0 : Me.esquemaestab = ""
        Me.esquemavinc = "" : Me.retencao = False : Me.pis = 0.0 : Me.cofins = 0.0
        Me.csll = 0.0 : Me.irenda = 0.0 : Me.sn = 0.0 : Me.ativEmpresa = 0 : Me.blBancoPadrao = "000" : Me.blOptPadrao = 0
    End Sub

#Region " * *  Metodos Set e Get  * * "

    Public Property pCodig() As String
        Get
            Return Me.codig
        End Get
        Set(ByVal value As String)
            Me.codig = value
        End Set
    End Property

    Public Property pGeno() As String
        Get
            Return Me.geno
        End Get
        Set(ByVal value As String)
            Me.geno = value
        End Set
    End Property

    Public Property pEnder() As String
        Get
            Return Me.ender
        End Get
        Set(ByVal value As String)
            Me.ender = value
        End Set
    End Property

    Public Property pCid() As String
        Get
            Return Me.cid
        End Get
        Set(ByVal value As String)
            Me.cid = value
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

    Public Property pCep() As String
        Get
            Return Me.cep
        End Get
        Set(ByVal value As String)
            Me.cep = value
        End Set
    End Property

    Public Property pBair() As String
        Get
            Return Me.bair
        End Get
        Set(ByVal value As String)
            Me.bair = value
        End Set
    End Property

    Public Property pCgc() As String
        Get
            Return Me.cgc
        End Get
        Set(ByVal value As String)
            Me.cgc = value
        End Set
    End Property

    Public Property pInsc() As String
        Get
            Return Me.insc
        End Get
        Set(ByVal value As String)
            Me.insc = value
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

    Public Property pFax() As String
        Get
            Return Me.fax
        End Get
        Set(ByVal value As String)
            Me.fax = value
        End Set
    End Property

    Public Property pMun() As String
        Get
            Return Me.mun
        End Get
        Set(ByVal value As String)
            Me.mun = value
        End Set
    End Property

    Public Property pCoduf() As String
        Get
            Return Me.coduf
        End Get
        Set(ByVal value As String)
            Me.coduf = value
        End Set
    End Property

    Public Property pEmail() As String
        Get
            Return Me.email
        End Get
        Set(ByVal value As String)
            Me.email = value
        End Set
    End Property

    Public Property pRazaosocial() As String
        Get
            Return Me.razaosocial
        End Get
        Set(ByVal value As String)
            Me.razaosocial = value
        End Set
    End Property

    Public Property pAidf() As String
        Get
            Return Me.aidf
        End Get
        Set(ByVal value As String)
            Me.aidf = value
        End Set
    End Property

    Public Property pCnae() As String
        Get
            Return Me.cnae
        End Get
        Set(ByVal value As String)
            Me.cnae = value
        End Set
    End Property

    Public Property pCrt() As String
        Get
            Return Me.crt
        End Get
        Set(ByVal value As String)
            Me.crt = value
        End Set
    End Property

    Public Property pVinculo() As Integer
        Get
            Return Me.vinculo
        End Get
        Set(ByVal value As Integer)
            Me.vinculo = value
        End Set
    End Property

    Public Property pEsquemaestab() As String
        Get
            Return Me.esquemaestab
        End Get
        Set(ByVal value As String)
            Me.esquemaestab = value
        End Set
    End Property

    Public Property pEsquemavinc() As String
        Get
            Return Me.esquemavinc
        End Get
        Set(ByVal value As String)
            Me.esquemavinc = value
        End Set
    End Property

    Public Property pRetencao() As Boolean
        Get
            Return Me.retencao
        End Get
        Set(ByVal value As Boolean)
            Me.retencao = value
        End Set
    End Property

    Public Property pPis() As Double
        Get
            Return Me.pis
        End Get
        Set(ByVal value As Double)
            Me.pis = value
        End Set
    End Property

    Public Property pCofins() As Double
        Get
            Return Me.cofins
        End Get
        Set(ByVal value As Double)
            Me.cofins = value
        End Set
    End Property

    Public Property pCsll() As Double
        Get
            Return Me.csll
        End Get
        Set(ByVal value As Double)
            Me.csll = value
        End Set
    End Property

    Public Property pIRenda() As Double
        Get
            Return Me.irenda
        End Get
        Set(ByVal value As Double)
            Me.irenda = value
        End Set
    End Property

    Public Property pSn() As Double
        Get
            Return Me.sn
        End Get
        Set(ByVal value As Double)
            Me.sn = value
        End Set
    End Property

    Public Property pAtivEmpresa() As Int16
        Get
            Return Me.ativEmpresa
        End Get
        Set(ByVal value As Int16)
            Me.ativEmpresa = value
        End Set
    End Property

    Public Property pBlBancoPadrao() As String
        Get
            Return Me.blBancoPadrao
        End Get
        Set(ByVal value As String)
            Me.blBancoPadrao = value
        End Set
    End Property

    Public Property pBlOptPadrao() As Int16
        Get
            Return Me.blOptPadrao
        End Get
        Set(ByVal value As Int16)
            Me.blOptPadrao = value
        End Set
    End Property

#End Region

    Public Sub zeraValores()

        Me.codig = "" : Me.geno = "" : Me.ender = "" : Me.cid = "" : Me.uf = ""
        Me.cep = "" : Me.bair = "" : Me.cgc = "" : Me.insc = "" : Me.fone = ""
        Me.fax = "" : Me.mun = "" : Me.coduf = "" : Me.email = "" : Me.razaosocial = ""
        Me.aidf = "" : Me.cnae = "" : Me.crt = "" : Me.vinculo = 0 : Me.esquemaestab = ""
        Me.esquemavinc = "" : Me.retencao = False : Me.pis = 0.0 : Me.cofins = 0.0
        Me.csll = 0.0 : Me.irenda = 0.0 : Me.sn = 0.0 : Me.ativEmpresa = 0 : Me.blBancoPadrao = "000" : Me.blOptPadrao = 0
    End Sub

End Class
