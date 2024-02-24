Public Class Cl_Nota4dd

    Dim n4_tipo, n4_numer, n4_pgto As String
    Dim n4_tprod, n4_aliss, n4_vliss, n4_vlser, n4_basec, n4_icms, n4_bsub As Double
    Dim n4_icsub, n4_tpro2, n4_frete, n4_segu, n4_outros, n4_ipi, n4_tgeral As Double
    Dim n4_outras, n4_isento, n4_pis, n4_cofins, n4_desc, n4_vlpis, n4_vlcofins As Double
    Dim n4_peso, n4_totalimp, n4_totaltrib, n4_pesoliquido, n4_pesobruto, n4_icmsdeson As Double
    Dim n4_id, n4_idn1pp As Int64

    Public Sub New()

        Me.n4_tipo = "" : Me.n4_numer = "" : Me.n4_pgto = "" : Me.n4_tprod = 0.0 : Me.n4_aliss = 0.0
        Me.n4_vliss = 0.0 : Me.n4_vlser = 0.0 : Me.n4_basec = 0.0 : Me.n4_icms = 0.0 : Me.n4_bsub = 0.0
        Me.n4_icsub = 0.0 : Me.n4_tpro2 = 0.0 : Me.n4_frete = 0.0 : Me.n4_segu = 0.0 : Me.n4_outros = 0.0
        Me.n4_ipi = 0.0 : Me.n4_tgeral = 0.0 : Me.n4_outras = 0.0 : Me.n4_isento = 0.0 : Me.n4_pis = 0.0
        Me.n4_cofins = 0.0 : Me.n4_desc = 0.0 : Me.n4_vlpis = 0.0 : Me.n4_vlcofins = 0.0 : Me.n4_peso = 0.0
        Me.n4_totalimp = 0.0 : Me.n4_totaltrib = 0.0 : Me.n4_id = 0 : Me.n4_idn1pp = 0
        Me.n4_pesoliquido = 0.0 : Me.n4_pesobruto = 0.0 : Me.n4_icmsdeson = 0.0
    End Sub

    Public Sub zeraValores()

        Me.n4_tipo = "" : Me.n4_numer = "" : Me.n4_pgto = "" : Me.n4_tprod = 0.0 : Me.n4_aliss = 0.0
        Me.n4_vliss = 0.0 : Me.n4_vlser = 0.0 : Me.n4_basec = 0.0 : Me.n4_icms = 0.0 : Me.n4_bsub = 0.0
        Me.n4_icsub = 0.0 : Me.n4_tpro2 = 0.0 : Me.n4_frete = 0.0 : Me.n4_segu = 0.0 : Me.n4_outros = 0.0
        Me.n4_ipi = 0.0 : Me.n4_tgeral = 0.0 : Me.n4_outras = 0.0 : Me.n4_isento = 0.0 : Me.n4_pis = 0.0
        Me.n4_cofins = 0.0 : Me.n4_desc = 0.0 : Me.n4_vlpis = 0.0 : Me.n4_vlcofins = 0.0 : Me.n4_peso = 0.0
        Me.n4_totalimp = 0.0 : Me.n4_totaltrib = 0.0 : Me.n4_id = 0 : Me.n4_idn1pp = 0
        Me.n4_pesoliquido = 0.0 : Me.n4_pesobruto = 0.0 : Me.n4_icmsdeson = 0.0
    End Sub

#Region "  * * Metodos Set e Get * *  "

    Public Property pN4_tipo() As String
        Get
            Return Me.n4_tipo
        End Get
        Set(ByVal value As String)
            Me.n4_tipo = value
        End Set
    End Property

    Public Property pN4_numer() As String
        Get
            Return Me.n4_numer
        End Get
        Set(ByVal value As String)
            Me.n4_numer = value
        End Set
    End Property

    Public Property pN4_pgto() As String
        Get
            Return Me.n4_pgto
        End Get
        Set(ByVal value As String)
            Me.n4_pgto = value
        End Set
    End Property

    Public Property pN4_tprod() As Double
        Get
            Return Me.n4_tprod
        End Get
        Set(ByVal value As Double)
            Me.n4_tprod = value
        End Set
    End Property

    Public Property pN4_aliss() As Double
        Get
            Return Me.n4_aliss
        End Get
        Set(ByVal value As Double)
            Me.n4_aliss = value
        End Set
    End Property

    Public Property pN4_vliss() As Double
        Get
            Return Me.n4_vliss
        End Get
        Set(ByVal value As Double)
            Me.n4_vliss = value
        End Set
    End Property

    Public Property pN4_vlser() As Double
        Get
            Return Me.n4_vlser
        End Get
        Set(ByVal value As Double)
            Me.n4_vlser = value
        End Set
    End Property

    Public Property pN4_basec() As Double
        Get
            Return Me.n4_basec
        End Get
        Set(ByVal value As Double)
            Me.n4_basec = value
        End Set
    End Property

    Public Property pN4_icms() As Double
        Get
            Return Me.n4_icms
        End Get
        Set(ByVal value As Double)
            Me.n4_icms = value
        End Set
    End Property

    Public Property pN4_bsub() As Double
        Get
            Return Me.n4_bsub
        End Get
        Set(ByVal value As Double)
            Me.n4_bsub = value
        End Set
    End Property

    Public Property pN4_icsub() As Double
        Get
            Return Me.n4_icsub
        End Get
        Set(ByVal value As Double)
            Me.n4_icsub = value
        End Set
    End Property

    Public Property pN4_tpro2() As Double
        Get
            Return Me.n4_tpro2
        End Get
        Set(ByVal value As Double)
            Me.n4_tpro2 = value
        End Set
    End Property

    Public Property pN4_frete() As Double
        Get
            Return Me.n4_frete
        End Get
        Set(ByVal value As Double)
            Me.n4_frete = value
        End Set
    End Property

    Public Property pN4_segu() As Double
        Get
            Return Me.n4_segu
        End Get
        Set(ByVal value As Double)
            Me.n4_segu = value
        End Set
    End Property

    Public Property pN4_outros() As Double
        Get
            Return Me.n4_outros
        End Get
        Set(ByVal value As Double)
            Me.n4_outros = value
        End Set
    End Property

    Public Property pN4_ipi() As Double
        Get
            Return Me.n4_ipi
        End Get
        Set(ByVal value As Double)
            Me.n4_ipi = value
        End Set
    End Property

    Public Property pN4_tgeral() As Double
        Get
            Return Me.n4_tgeral
        End Get
        Set(ByVal value As Double)
            Me.n4_tgeral = value
        End Set
    End Property

    Public Property pN4_outras() As Double
        Get
            Return Me.n4_outras
        End Get
        Set(ByVal value As Double)
            Me.n4_outras = value
        End Set
    End Property

    Public Property pN4_isento() As Double
        Get
            Return Me.n4_isento
        End Get
        Set(ByVal value As Double)
            Me.n4_isento = value
        End Set
    End Property

    Public Property pN4_pis() As Double
        Get
            Return Me.n4_pis
        End Get
        Set(ByVal value As Double)
            Me.n4_pis = value
        End Set
    End Property

    Public Property pN4_cofins() As Double
        Get
            Return Me.n4_cofins
        End Get
        Set(ByVal value As Double)
            Me.n4_cofins = value
        End Set
    End Property

    Public Property pN4_desc() As Double
        Get
            Return Me.n4_desc
        End Get
        Set(ByVal value As Double)
            Me.n4_desc = value
        End Set
    End Property

    Public Property pN4_vlpis() As Double
        Get
            Return Me.n4_vlpis
        End Get
        Set(ByVal value As Double)
            Me.n4_vlpis = value
        End Set
    End Property

    Public Property pN4_vlcofins() As Double
        Get
            Return Me.n4_vlcofins
        End Get
        Set(ByVal value As Double)
            Me.n4_vlcofins = value
        End Set
    End Property

    Public Property pN4_peso() As Double
        Get
            Return Me.n4_peso
        End Get
        Set(ByVal value As Double)
            Me.n4_peso = value
        End Set
    End Property

    Public Property pN4_totalimp() As Double
        Get
            Return Me.n4_totalimp
        End Get
        Set(ByVal value As Double)
            Me.n4_totalimp = value
        End Set
    End Property

    Public Property pN4_totaltrib() As Double
        Get
            Return Me.n4_totaltrib
        End Get
        Set(ByVal value As Double)
            Me.n4_totaltrib = value
        End Set
    End Property

    Public Property pN4_id() As Int64
        Get
            Return Me.n4_id
        End Get
        Set(ByVal value As Int64)
            Me.n4_id = value
        End Set
    End Property

    Public Property pN4_idn1pp() As Int64
        Get
            Return Me.n4_idn1pp
        End Get
        Set(ByVal value As Int64)
            Me.n4_idn1pp = value
        End Set
    End Property

    Public Property pN4_pesoliquido() As Double
        Get
            Return Me.n4_pesoliquido
        End Get
        Set(ByVal value As Double)
            Me.n4_pesoliquido = value
        End Set
    End Property

    Public Property pN4_pesobruto() As Double
        Get
            Return Me.n4_pesobruto
        End Get
        Set(ByVal value As Double)
            Me.n4_pesobruto = value
        End Set
    End Property

    Public Property pN4_icmsdeson() As Double
        Get
            Return Me.n4_icmsdeson
        End Get
        Set(ByVal value As Double)
            Me.n4_icmsdeson = value
        End Set
    End Property

#End Region


End Class
