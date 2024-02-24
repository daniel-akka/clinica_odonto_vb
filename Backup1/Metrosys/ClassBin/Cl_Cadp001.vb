Public Class Cl_Cadp001

    Private tipo As String, carac As String, dtcad As Date, cod As String
    Private portad As String, fantas As String, civil As String
    Private dtnativ As Date, natur As String, ident As String
    Private cpf As String, cgc As String, insc As String
    Private pai As String, mae As String, ender As String
    Private bairro As String, cid As String, uf As String
    Private cep As String, fone As String, ltrab As String
    Private endtr As String, fontr As String, cargo As String
    Private salar As Double
    Private esposo As String, crt As String, ltrabe As String
    Private salae As Double
    Private rota As Int32
    Private vend As String, obs1 As String, obs2 As String
    Private obs3 As String, ultcomp As DateTime
    Private valor As Double
    Private limite As Double
    Private pedido As String, cdvend As String, cdcid As String
    Private bloq As String, tb As String, consumo As String
    Private mun As String, coduf As String, ctactb As String
    Private ctaanli As String, mes As Int16, fax As String
    Private prep As String, email As String, sexo As String, celular As String
    Private inativo As Boolean
    Private usuario As String
    Private isento As Boolean



    Public Sub New()

        Me.tipo = "" : Me.carac = "" : Me.dtcad = Nothing : Me.cod = "" : Me.portad = ""
        Me.fantas = "" : Me.civil = "" : Me.dtnativ = Nothing : Me.natur = "" : Me.ident = ""
        Me.cpf = "" : Me.cgc = "" : Me.insc = "" : Me.pai = "" : Me.mae = "" : Me.ender = ""
        Me.bairro = "" : Me.cid = "" : Me.uf = "" : Me.cep = "" : Me.fone = ""
        Me.ltrab = "" : Me.endtr = "" : Me.fontr = "" : Me.cargo = ""
        Me.salar = 0.0 : Me.esposo = "" : Me.crt = "" : Me.ltrabe = ""
        Me.salae = 0.0 : Me.rota = 0 : Me.vend = "" : Me.obs1 = "" : Me.obs2 = ""
        Me.obs3 = "" : Me.ultcomp = Nothing : Me.valor = 0.0 : Me.limite = 0.0
        Me.pedido = "" : Me.cdvend = "" : Me.cdcid = "" : Me.bloq = "" : Me.tb = ""
        Me.consumo = "" : Me.mun = "" : Me.coduf = "" : Me.ctactb = "" : Me.ctaanli = ""
        Me.mes = 0 : Me.fax = "" : Me.prep = "" : Me.email = "" : Me.sexo = ""
        Me.celular = "" : Me.inativo = False : Me.usuario = "" : Me.isento = False

    End Sub

    Public Sub zeraValores()

        Me.tipo = "" : Me.carac = "" : Me.dtcad = Nothing : Me.cod = "" : Me.portad = ""
        Me.fantas = "" : Me.civil = "" : Me.dtnativ = Nothing : Me.natur = "" : Me.ident = ""
        Me.cpf = "" : Me.cgc = "" : Me.insc = "" : Me.pai = "" : Me.mae = "" : Me.ender = ""
        Me.bairro = "" : Me.cid = "" : Me.uf = "" : Me.cep = "" : Me.fone = ""
        Me.ltrab = "" : Me.endtr = "" : Me.fontr = "" : Me.cargo = ""
        Me.salar = 0.0 : Me.esposo = "" : Me.crt = "" : Me.ltrabe = ""
        Me.salae = 0.0 : Me.rota = 0 : Me.vend = "" : Me.obs1 = "" : Me.obs2 = ""
        Me.obs3 = "" : Me.ultcomp = Nothing : Me.valor = 0.0 : Me.limite = 0.0
        Me.pedido = "" : Me.cdvend = "" : Me.cdcid = "" : Me.bloq = "" : Me.tb = ""
        Me.consumo = "" : Me.mun = "" : Me.coduf = "" : Me.ctactb = "" : Me.ctaanli = ""
        Me.mes = 0 : Me.fax = "" : Me.prep = "" : Me.email = "" : Me.sexo = ""
        Me.celular = "" : Me.inativo = False : Me.usuario = "" : Me.isento = False

    End Sub

#Region "   * *  Metodos Set e Get  * *   "

    Public Property pTipo() As String
        Get
            Return Me.tipo
        End Get
        Set(ByVal value As String)
            Me.tipo = value
        End Set
    End Property

    Public Property pCarac() As String
        Get
            Return Me.carac
        End Get
        Set(ByVal value As String)
            Me.carac = value
        End Set
    End Property

    Public Property pDtcad() As Date
        Get
            Return Me.dtcad
        End Get
        Set(ByVal value As Date)
            Me.dtcad = value
        End Set
    End Property

    Public Property pCod() As String
        Get
            Return Me.cod
        End Get
        Set(ByVal value As String)
            Me.cod = value
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

    Public Property pFantas() As String
        Get
            Return Me.fantas
        End Get
        Set(ByVal value As String)
            Me.fantas = value
        End Set
    End Property

    Public Property pCivil() As String
        Get
            Return Me.civil
        End Get
        Set(ByVal value As String)
            Me.civil = value
        End Set
    End Property

    Public Property pDtnativ() As Date
        Get
            Return Me.dtnativ
        End Get
        Set(ByVal value As Date)
            Me.dtnativ = value
        End Set
    End Property

    Public Property pNatur() As String
        Get
            Return Me.natur
        End Get
        Set(ByVal value As String)
            Me.natur = value
        End Set
    End Property

    Public Property pIdent() As String
        Get
            Return Me.ident
        End Get
        Set(ByVal value As String)
            Me.ident = value
        End Set
    End Property

    Public Property pCpf() As String
        Get
            Return Me.cpf
        End Get
        Set(ByVal value As String)
            Me.cpf = value
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

    Public Property pPai() As String
        Get
            Return Me.pai
        End Get
        Set(ByVal value As String)
            Me.pai = value
        End Set
    End Property

    Public Property pMae() As String
        Get
            Return Me.mae
        End Get
        Set(ByVal value As String)
            Me.mae = value
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

    Public Property pBairro() As String
        Get
            Return Me.bairro
        End Get
        Set(ByVal value As String)
            Me.bairro = value
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

    Public Property pFone() As String
        Get
            Return Me.fone
        End Get
        Set(ByVal value As String)
            Me.fone = value
        End Set
    End Property

    Public Property pLtrab() As String
        Get
            Return Me.ltrab
        End Get
        Set(ByVal value As String)
            Me.ltrab = value
        End Set
    End Property

    Public Property pEndtr() As String
        Get
            Return Me.endtr
        End Get
        Set(ByVal value As String)
            Me.endtr = value
        End Set
    End Property

    Public Property pFontr() As String
        Get
            Return Me.fontr
        End Get
        Set(ByVal value As String)
            Me.fontr = value
        End Set
    End Property

    Public Property pCargo() As String
        Get
            Return Me.cargo
        End Get
        Set(ByVal value As String)
            Me.cargo = value
        End Set
    End Property

    Public Property pSalar() As Double
        Get
            Return Me.salar
        End Get
        Set(ByVal value As Double)
            Me.salar = value
        End Set
    End Property

    Public Property pEsposo() As String
        Get
            Return Me.esposo
        End Get
        Set(ByVal value As String)
            Me.esposo = value
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

    Public Property pLtrabe() As String
        Get
            Return Me.ltrabe
        End Get
        Set(ByVal value As String)
            Me.ltrabe = value
        End Set
    End Property

    Public Property pSalae() As Double
        Get
            Return Me.salae
        End Get
        Set(ByVal value As Double)
            Me.salae = value
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

    Public Property pVend() As String
        Get
            Return Me.vend
        End Get
        Set(ByVal value As String)
            Me.vend = value
        End Set
    End Property

    Public Property pObs1() As String
        Get
            Return Me.obs1
        End Get
        Set(ByVal value As String)
            Me.obs1 = value
        End Set
    End Property

    Public Property pObs2() As String
        Get
            Return Me.obs2
        End Get
        Set(ByVal value As String)
            Me.obs2 = value
        End Set
    End Property

    Public Property pObs3() As String
        Get
            Return Me.obs3
        End Get
        Set(ByVal value As String)
            Me.obs3 = value
        End Set
    End Property

    Public Property pUltcomp() As DateTime
        Get
            Return Me.ultcomp
        End Get
        Set(ByVal value As DateTime)
            Me.ultcomp = value
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

    Public Property pLimite() As Double
        Get
            Return Me.limite
        End Get
        Set(ByVal value As Double)
            Me.limite = value
        End Set
    End Property

    Public Property pPedido() As String
        Get
            Return Me.pedido
        End Get
        Set(ByVal value As String)
            Me.pedido = value
        End Set
    End Property

    Public Property pCdvend() As String
        Get
            Return Me.cdvend
        End Get
        Set(ByVal value As String)
            Me.cdvend = value
        End Set
    End Property

    Public Property pCdcid() As String
        Get
            Return Me.cdcid
        End Get
        Set(ByVal value As String)
            Me.cdcid = value
        End Set
    End Property

    Public Property pBloq() As String
        Get
            Return Me.bloq
        End Get
        Set(ByVal value As String)
            Me.bloq = value
        End Set
    End Property

    Public Property pTb() As String
        Get
            Return Me.tb
        End Get
        Set(ByVal value As String)
            Me.tb = value
        End Set
    End Property

    Public Property pConsumo() As String
        Get
            Return Me.consumo
        End Get
        Set(ByVal value As String)
            Me.consumo = value
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

    Public Property pCtactb() As String
        Get
            Return Me.ctactb
        End Get
        Set(ByVal value As String)
            Me.ctactb = value
        End Set
    End Property

    Public Property pCtaanli() As String
        Get
            Return Me.ctaanli
        End Get
        Set(ByVal value As String)
            Me.ctaanli = value
        End Set
    End Property

    Public Property pMes() As Int16
        Get
            Return Me.mes
        End Get
        Set(ByVal value As Int16)
            Me.mes = value
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

    Public Property pPrep() As String
        Get
            Return Me.prep
        End Get
        Set(ByVal value As String)
            Me.prep = value
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

    Public Property pSexo() As String
        Get
            Return Me.sexo
        End Get
        Set(ByVal value As String)
            Me.sexo = value
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

    Public Property pInativo() As Boolean
        Get
            Return Me.inativo
        End Get
        Set(ByVal value As Boolean)
            Me.inativo = value
        End Set
    End Property

    Public Property pUsuario() As String
        Get
            Return Me.usuario
        End Get
        Set(ByVal value As String)
            Me.usuario = value
        End Set
    End Property

    Public Property pIsento() As String
        Get
            Return Me.isento
        End Get
        Set(ByVal value As String)
            Me.isento = value
        End Set
    End Property

#End Region

End Class
