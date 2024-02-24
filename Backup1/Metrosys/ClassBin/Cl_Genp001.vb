Public Class Cl_Genp001


    Private requis As String '8 carac
    Private sai As String '9 carac
    Private fat As String '8 carac
    Private icms As Double
    Private icmse As Double
    Private alqiss As Double
    Private serv As String '8 carac
    Private orca As String '8 carac
    Private palm As String '8 carac
    Private txreduz As Double
    Private icmred As Double
    Private txcob As Double
    Private txipi As Double
    Private txga As Double
    Private txesvei As Double
    Private serie As String
    Private contf As String
    Private amb As String
    Private prazo As Integer
    Private seqnfe As String '9 carac
    Private mensag As String '60 carac
    Private pis As Double
    Private confin As Double
    Private alqsub As Double
    Private geno As String '5 carac
    Private carencia As Integer
    Private codprod As Boolean
    Private codrequis As Int64
    Private codmapa As Int64
    Private numpedidomp As Int64
    Private mapapedido As Int64
    Private canc_pedauto As Boolean
    Private grade As Boolean
    Private codreqproc As Int64
    Private data As Date
    Private tipocondpagto As Int16
    Private ConfirmCPF As Boolean
    Private tptransfentrada, tptransfsaida As String
    Private sincroniza As Boolean
    Private comisavista, comisaprazo As Double
    Public pathEnvioXML, pathLotXML, pathRetornoXML, pathEnviadoXML As String
    Public imagemCarne As String
    Public sldfiscalnegativo As Boolean
    Public aplicacao As Boolean
    Public pathEnvioTablet, pathRetornoTablet, pathImgTablet, ftpTablet, usuarioFtpTablet, senhaFtpTablet As String
    Public pathEnvioPalm, pathRetornoPalm, ftpPalm, usuarioFtpPalm, senhaFtpPalm As String
    Public pauta, descontonfe As Boolean



    Public Sub New()

        Me.requis = "00000001" : Me.sai = "000000001" : Me.fat = "00000001" : Me.icms = 17 : Me.icmse = 12
        Me.alqiss = 5 : Me.serv = "00000001" : Me.orca = "00000100" : Me.palm = "00000100" : Me.txreduz = 0
        Me.icmred = 0 : Me.txcob = 0 : Me.txipi = 10 : Me.txga = 25 : Me.txesvei = 25
        Me.serie = "005" : Me.contf = "1" : Me.amb = "1" : Me.prazo = 30 : Me.seqnfe = "000000100"
        Me.mensag = "" : Me.pis = 0.65 : Me.confin = 3 : Me.alqsub = 3.4 : Me.geno = ""
        Me.carencia = 30 : Me.codprod = True : Me.codrequis = 1 : Me.codmapa = 1
        Me.numpedidomp = 1 : Me.mapapedido = 1 : Me.canc_pedauto = False
        Me.grade = False : Me.codreqproc = 1 : Me.data = Nothing : Me.tipocondpagto = 1 : Me.ConfirmCPF = True
        Me.tptransfentrada = "1" : Me.tptransfsaida = "1" : Me.sincroniza = False : Me.comisavista = 0.0
        Me.comisaprazo = 0.0 : Me.pathEnvioXML = "" : Me.pathLotXML = "" : Me.pathRetornoXML = "" : Me.pathEnviadoXML = ""
        Me.imagemCarne = "jpg" : Me.sldfiscalnegativo = False : Me.aplicacao = False
        Me.pathEnvioTablet = "" : Me.pathRetornoTablet = "" : Me.pathEnvioPalm = "" : Me.pathRetornoPalm = ""
        Me.pauta = False : Me.descontonfe = False

    End Sub

#Region " * *  Metodos Set e Get  * * "

    Public Property pRequis() As String
        Get
            Return Me.requis
        End Get
        Set(ByVal value As String)
            Me.requis = value
        End Set
    End Property


    Public Property pSai() As String
        Get
            Return Me.sai
        End Get
        Set(ByVal value As String)
            Me.sai = value
        End Set
    End Property

    Public Property pFat() As String
        Get
            Return Me.fat
        End Get
        Set(ByVal value As String)
            Me.fat = value
        End Set
    End Property

    Public Property pIcms() As Double
        Get
            Return Me.icms
        End Get
        Set(ByVal value As Double)
            Me.icms = value
        End Set
    End Property

    Public Property pIcmse() As Double
        Get
            Return Me.icmse
        End Get
        Set(ByVal value As Double)
            Me.icmse = value
        End Set
    End Property

    Public Property pAlqiss() As Double
        Get
            Return Me.alqiss
        End Get
        Set(ByVal value As Double)
            Me.alqiss = value
        End Set
    End Property

    Public Property pServ() As String
        Get
            Return Me.serv
        End Get
        Set(ByVal value As String)
            Me.serv = value
        End Set
    End Property

    Public Property pOrca() As String
        Get
            Return Me.orca
        End Get
        Set(ByVal value As String)
            Me.orca = value
        End Set
    End Property

    Public Property pPalm() As String
        Get
            Return Me.palm
        End Get
        Set(ByVal value As String)
            Me.palm = value
        End Set
    End Property

    Public Property pTxreduz() As Double
        Get
            Return Me.txreduz
        End Get
        Set(ByVal value As Double)
            Me.txreduz = value
        End Set
    End Property

    Public Property pIcmred() As Double
        Get
            Return Me.icmred
        End Get
        Set(ByVal value As Double)
            Me.icmred = value
        End Set
    End Property

    Public Property pTxcob() As Double
        Get
            Return Me.txcob
        End Get
        Set(ByVal value As Double)
            Me.txcob = value
        End Set
    End Property

    Public Property pTxipi() As Double
        Get
            Return Me.txipi
        End Get
        Set(ByVal value As Double)
            Me.txipi = value
        End Set
    End Property

    Public Property pTxga() As Double
        Get
            Return Me.txga
        End Get
        Set(ByVal value As Double)
            Me.txga = value
        End Set
    End Property

    Public Property pTxesvei() As Double
        Get
            Return Me.txesvei
        End Get
        Set(ByVal value As Double)
            Me.txesvei = value
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

    Public Property pContf() As String
        Get
            Return Me.contf
        End Get
        Set(ByVal value As String)
            Me.contf = value
        End Set
    End Property

    Public Property pAmb() As String
        Get
            Return Me.amb
        End Get
        Set(ByVal value As String)
            Me.amb = value
        End Set
    End Property

    Public Property pPrazo() As Integer
        Get
            Return Me.prazo
        End Get
        Set(ByVal value As Integer)
            Me.prazo = value
        End Set
    End Property

    Public Property pSeqnfe() As String
        Get
            Return Me.seqnfe
        End Get
        Set(ByVal value As String)
            Me.seqnfe = value
        End Set
    End Property

    Public Property pMensag() As String
        Get
            Return Me.mensag
        End Get
        Set(ByVal value As String)
            Me.mensag = value
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

    Public Property pConfin() As Double
        Get
            Return Me.confin
        End Get
        Set(ByVal value As Double)
            Me.confin = value
        End Set
    End Property

    Public Property pAlqsub() As Double
        Get
            Return Me.alqsub
        End Get
        Set(ByVal value As Double)
            Me.alqsub = value
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

    Public Property pCarencia() As Int64
        Get
            Return Me.carencia
        End Get
        Set(ByVal value As Int64)
            Me.carencia = value
        End Set
    End Property

    Public Property pCodprod() As Boolean
        Get
            Return Me.codprod
        End Get
        Set(ByVal value As Boolean)
            Me.codprod = value
        End Set
    End Property

    Public Property pCodrequis() As Int64
        Get
            Return Me.codrequis
        End Get
        Set(ByVal value As Int64)
            Me.codrequis = value
        End Set
    End Property

    Public Property pCodmapa() As Int64
        Get
            Return Me.codmapa
        End Get
        Set(ByVal value As Int64)
            Me.codmapa = value
        End Set
    End Property

    Public Property pNumpedidomp() As Int64
        Get
            Return Me.numpedidomp
        End Get
        Set(ByVal value As Int64)
            Me.numpedidomp = value
        End Set
    End Property

    Public Property pMapapedido() As Int64
        Get
            Return Me.mapapedido
        End Get
        Set(ByVal value As Int64)
            Me.mapapedido = value
        End Set
    End Property

    Public Property pCanc_pedauto() As Boolean
        Get
            Return Me.canc_pedauto
        End Get
        Set(ByVal value As Boolean)
            Me.canc_pedauto = value
        End Set
    End Property

    Public Property pGrade() As Boolean
        Get
            Return Me.grade
        End Get
        Set(ByVal value As Boolean)
            Me.grade = value
        End Set
    End Property

    Public Property pCodreqproc() As Int64
        Get
            Return Me.codreqproc
        End Get
        Set(ByVal value As Int64)
            Me.codreqproc = value
        End Set
    End Property

    Public Property pData() As Date
        Get
            Return data
        End Get
        Set(ByVal value As Date)
            data = value
        End Set
    End Property

    Public Property pTipocondpagto() As Int16
        Get
            Return Me.tipocondpagto
        End Get
        Set(ByVal value As Int16)
            Me.tipocondpagto = value
        End Set
    End Property

    Public Property pConfirmCPF() As Boolean
        Get
            Return Me.ConfirmCPF
        End Get
        Set(ByVal value As Boolean)
            Me.ConfirmCPF = value
        End Set
    End Property

    Public Property pTptransfentrada() As String
        Get
            Return Me.tptransfentrada
        End Get
        Set(ByVal value As String)
            Me.tptransfentrada = value
        End Set
    End Property

    Public Property pTptransfsaida() As String
        Get
            Return Me.tptransfsaida
        End Get
        Set(ByVal value As String)
            Me.tptransfsaida = value
        End Set
    End Property

    Public Property pSincroniza() As Boolean
        Get
            Return Me.sincroniza
        End Get
        Set(ByVal value As Boolean)
            Me.sincroniza = value
        End Set
    End Property

    Public Property pComisavista() As Double
        Get
            Return Me.comisavista
        End Get
        Set(ByVal value As Double)
            Me.comisavista = value
        End Set
    End Property

    Public Property pComisaprazo() As Double
        Get
            Return Me.comisaprazo
        End Get
        Set(ByVal value As Double)
            Me.comisaprazo = value
        End Set
    End Property

#End Region

    Public Sub zeraValores()

        Me.requis = "00000001" : Me.sai = "000000001" : Me.fat = "00000001" : Me.icms = 17 : Me.icmse = 12
        Me.alqiss = 5 : Me.serv = "00000001" : Me.orca = "00000100" : Me.palm = "00000100" : Me.txreduz = 0
        Me.icmred = 0 : Me.txcob = 0 : Me.txipi = 10 : Me.txga = 25 : Me.txesvei = 25
        Me.serie = "005" : Me.contf = "1" : Me.amb = "1" : Me.prazo = 30 : Me.seqnfe = "000000100"
        Me.mensag = "" : Me.pis = 0.65 : Me.confin = 3 : Me.alqsub = 3.4 : Me.geno = ""
        Me.carencia = 30 : Me.codprod = True : Me.codrequis = 1 : Me.codmapa = 1
        Me.numpedidomp = 1 : Me.mapapedido = 1 : Me.canc_pedauto = False
        Me.grade = False : Me.codreqproc = 1 : Me.data = Nothing : Me.tipocondpagto = 1 : Me.ConfirmCPF = True
        Me.tptransfentrada = "1" : Me.tptransfsaida = "1" : Me.sincroniza = False : Me.comisavista = 0.0
        Me.comisaprazo = 0.0 : Me.pathEnvioXML = "" : Me.pathLotXML = "" : Me.pathRetornoXML = "" : Me.pathEnviadoXML = ""
        Me.imagemCarne = "jpg" : Me.sldfiscalnegativo = False : Me.aplicacao = False
        Me.pathEnvioTablet = "" : Me.pathRetornoTablet = "" : Me.pathEnvioPalm = "" : Me.pathRetornoPalm = ""
        Me.pauta = False : Me.descontonfe = False

    End Sub

End Class
