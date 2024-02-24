Public Class Cl_Nota2cc

    Dim nc_tipo, nc_numer, nc_codpr, nc_produt, nc_cf, nc_cst, nc_und, nc_cdport, nc_cfop, nc_csosn, nc_ncm As String
    Dim nc_qtde, nc_prunit, nc_prtot, nc_alqicm, nc_alqipi, nc_vlipi, nc_vlicm, nc_unipi, nc_alqsub, nc_descpac As Double
    Dim nc_vlsubs, nc_bcalc, nc_basesub, nc_frete, nc_segur, nc_vldesc, nc_isento, nc_vltrib, nc_desc, nc_voutro As Double
    Dim nc_reduz, nc_alqreduz, nc_pruvenda As Double
    Dim nc_dtemis As Date
    Dim nc_id, nc_ntid As Int64
    Dim nc_indtot As Integer
    Dim nc_seqitem As Int16
    Dim nc_cstpis, nc_cstcofins, nc_cstipi As String


    Public Sub New()

        Me.nc_tipo = "" : Me.nc_numer = "" : Me.nc_codpr = "" : Me.nc_produt = "" : Me.nc_cf = ""
        Me.nc_cst = "" : Me.nc_und = "" : Me.nc_cdport = "" : Me.nc_cfop = "" : Me.nc_csosn = "" : Me.nc_ncm = ""
        Me.nc_qtde = 0.0 : Me.nc_prunit = 0.0 : Me.nc_prtot = 0.0 : Me.nc_alqicm = 0.0 : Me.nc_alqipi = 0.0
        Me.nc_vlipi = 0.0 : Me.nc_vlicm = 0.0 : Me.nc_unipi = 0.0 : Me.nc_vlsubs = 0.0 : Me.nc_bcalc = 0.0
        Me.nc_basesub = 0.0 : Me.nc_frete = 0.0 : Me.nc_segur = 0.0 : Me.nc_vldesc = 0.0 : Me.nc_isento = 0.0
        Me.nc_vltrib = 0.0 : Me.nc_dtemis = Nothing : Me.nc_id = 0 : Me.nc_ntid = 0 : Me.nc_alqsub = 0.0
        Me.nc_indtot = 0 : Me.nc_descpac = 0.0 : Me.nc_desc = 0.0 : Me.nc_voutro = 0.0 : Me.nc_seqitem = 0
        Me.nc_reduz = 0.0 : Me.nc_alqreduz = 0.0 : Me.nc_cstpis = "" : Me.nc_cstcofins = "" : Me.nc_cstipi = ""
        Me.nc_pruvenda = 0.0
    End Sub

    Public Sub zeraValores()

        Me.nc_tipo = "" : Me.nc_numer = "" : Me.nc_codpr = "" : Me.nc_produt = "" : Me.nc_cf = ""
        Me.nc_cst = "" : Me.nc_und = "" : Me.nc_cdport = "" : Me.nc_cfop = "" : Me.nc_csosn = "" : Me.nc_ncm = ""
        Me.nc_qtde = 0.0 : Me.nc_prunit = 0.0 : Me.nc_prtot = 0.0 : Me.nc_alqicm = 0.0 : Me.nc_alqipi = 0.0
        Me.nc_vlipi = 0.0 : Me.nc_vlicm = 0.0 : Me.nc_unipi = 0.0 : Me.nc_vlsubs = 0.0 : Me.nc_bcalc = 0.0
        Me.nc_basesub = 0.0 : Me.nc_frete = 0.0 : Me.nc_segur = 0.0 : Me.nc_vldesc = 0.0 : Me.nc_isento = 0.0
        Me.nc_vltrib = 0.0 : Me.nc_dtemis = Nothing : Me.nc_id = 0 : Me.nc_ntid = 0 : Me.nc_alqsub = 0.0
        Me.nc_indtot = 0 : Me.nc_descpac = 0.0 : Me.nc_desc = 0.0 : Me.nc_voutro = 0.0 : Me.nc_seqitem = 0
        Me.nc_reduz = 0.0 : Me.nc_alqreduz = 0.0 : Me.nc_cstpis = "" : Me.nc_cstcofins = "" : Me.nc_cstipi = ""
        Me.nc_pruvenda = 0.0
    End Sub

    Public Sub zeraValoresNFe01()

        Me.nc_codpr = "" : Me.nc_produt = "" : Me.nc_cf = ""
        Me.nc_cst = "" : Me.nc_und = "" : Me.nc_cfop = "" : Me.nc_csosn = "" : Me.nc_ncm = ""
        Me.nc_qtde = 0.0 : Me.nc_prunit = 0.0 : Me.nc_prtot = 0.0 : Me.nc_alqicm = 0.0 : Me.nc_alqipi = 0.0
        Me.nc_vlipi = 0.0 : Me.nc_vlicm = 0.0 : Me.nc_unipi = 0.0 : Me.nc_vlsubs = 0.0 : Me.nc_bcalc = 0.0
        Me.nc_basesub = 0.0 : Me.nc_frete = 0.0 : Me.nc_segur = 0.0 : Me.nc_vldesc = 0.0 : Me.nc_isento = 0.0
        Me.nc_vltrib = 0.0 : Me.nc_id = 0 : Me.nc_alqsub = 0.0 : Me.nc_descpac = 0.0 : Me.nc_desc = 0.0 : Me.nc_voutro = 0.0
        Me.nc_reduz = 0.0 : Me.nc_alqreduz = 0.0 : Me.nc_cstpis = "" : Me.nc_cstcofins = "" : Me.nc_cstipi = ""
        Me.nc_pruvenda = 0.0
    End Sub

#Region "  * * Metodos Set e Get * *  "

    Public Property pNc_tipo() As String
        Get
            Return Me.nc_tipo
        End Get
        Set(ByVal value As String)
            Me.nc_tipo = value
        End Set
    End Property

    Public Property pNc_numer() As String
        Get
            Return Me.nc_numer
        End Get
        Set(ByVal value As String)
            Me.nc_numer = value
        End Set
    End Property

    Public Property pNc_codpr() As String
        Get
            Return Me.nc_codpr
        End Get
        Set(ByVal value As String)
            Me.nc_codpr = value
        End Set
    End Property

    Public Property pNc_produt() As String
        Get
            Return Me.nc_produt
        End Get
        Set(ByVal value As String)
            Me.nc_produt = value
        End Set
    End Property

    Public Property pNc_cf() As String
        Get
            Return Me.nc_cf
        End Get
        Set(ByVal value As String)
            Me.nc_cf = value
        End Set
    End Property

    Public Property pNc_cst() As String
        Get
            Return Me.nc_cst
        End Get
        Set(ByVal value As String)
            Me.nc_cst = value
        End Set
    End Property

    Public Property pNc_und() As String
        Get
            Return Me.nc_und
        End Get
        Set(ByVal value As String)
            Me.nc_und = value
        End Set
    End Property

    Public Property pNc_cdport() As String
        Get
            Return Me.nc_cdport
        End Get
        Set(ByVal value As String)
            Me.nc_cdport = value
        End Set
    End Property

    Public Property pNc_cfop() As String
        Get
            Return Me.nc_cfop
        End Get
        Set(ByVal value As String)
            Me.nc_cfop = value
        End Set
    End Property

    Public Property pNc_csosn() As String
        Get
            Return Me.nc_csosn
        End Get
        Set(ByVal value As String)
            Me.nc_csosn = value
        End Set
    End Property

    Public Property pNc_qtde() As Double
        Get
            Return Me.nc_qtde
        End Get
        Set(ByVal value As Double)
            Me.nc_qtde = value
        End Set
    End Property

    Public Property pNc_prunit() As Double
        Get
            Return Me.nc_prunit
        End Get
        Set(ByVal value As Double)
            Me.nc_prunit = value
        End Set
    End Property

    Public Property pNc_prtot() As Double
        Get
            Return Me.nc_prtot
        End Get
        Set(ByVal value As Double)
            Me.nc_prtot = value
        End Set
    End Property

    Public Property pNc_alqicm() As Double
        Get
            Return Me.nc_alqicm
        End Get
        Set(ByVal value As Double)
            Me.nc_alqicm = value
        End Set
    End Property

    Public Property pNc_alqipi() As Double
        Get
            Return Me.nc_alqipi
        End Get
        Set(ByVal value As Double)
            Me.nc_alqipi = value
        End Set
    End Property

    Public Property pNc_vlipi() As Double
        Get
            Return Me.nc_vlipi
        End Get
        Set(ByVal value As Double)
            Me.nc_vlipi = value
        End Set
    End Property

    Public Property pNc_vlicm() As Double
        Get
            Return Me.nc_vlicm
        End Get
        Set(ByVal value As Double)
            Me.nc_vlicm = value
        End Set
    End Property

    Public Property pNc_unipi() As Double
        Get
            Return Me.nc_unipi
        End Get
        Set(ByVal value As Double)
            Me.nc_unipi = value
        End Set
    End Property

    Public Property pNc_alqsub() As Double
        Get
            Return Me.nc_alqsub
        End Get
        Set(ByVal value As Double)
            Me.nc_alqsub = value
        End Set
    End Property

    Public Property pNc_vlsubs() As Double
        Get
            Return Me.nc_vlsubs
        End Get
        Set(ByVal value As Double)
            Me.nc_vlsubs = value
        End Set
    End Property

    Public Property pNc_bcalc() As Double
        Get
            Return Me.nc_bcalc
        End Get
        Set(ByVal value As Double)
            Me.nc_bcalc = value
        End Set
    End Property

    Public Property pNc_basesub() As Double
        Get
            Return Me.nc_basesub
        End Get
        Set(ByVal value As Double)
            Me.nc_basesub = value
        End Set
    End Property

    Public Property pNc_frete() As Double
        Get
            Return Me.nc_frete
        End Get
        Set(ByVal value As Double)
            Me.nc_frete = value
        End Set
    End Property

    Public Property pNc_segur() As Double
        Get
            Return Me.nc_segur
        End Get
        Set(ByVal value As Double)
            Me.nc_segur = value
        End Set
    End Property

    Public Property pNc_vldesc() As Double
        Get
            Return Me.nc_vldesc
        End Get
        Set(ByVal value As Double)
            Me.nc_vldesc = value
        End Set
    End Property

    Public Property pNc_isento() As Double
        Get
            Return Me.nc_isento
        End Get
        Set(ByVal value As Double)
            Me.nc_isento = value
        End Set
    End Property

    Public Property pNc_vltrib() As Double
        Get
            Return Me.nc_vltrib
        End Get
        Set(ByVal value As Double)
            Me.nc_vltrib = value
        End Set
    End Property

    Public Property pNc_dtemis() As Date
        Get
            Return Me.nc_dtemis
        End Get
        Set(ByVal value As Date)
            Me.nc_dtemis = value
        End Set
    End Property

    Public Property pNc_id() As Int64
        Get
            Return Me.nc_id
        End Get
        Set(ByVal value As Int64)
            Me.nc_id = value
        End Set
    End Property

    Public Property pNc_ntid() As Int64
        Get
            Return Me.nc_ntid
        End Get
        Set(ByVal value As Int64)
            Me.nc_ntid = value
        End Set
    End Property

    Public Property pNc_ncm() As String
        Get
            Return Me.nc_ncm
        End Get
        Set(ByVal value As String)
            Me.nc_ncm = value
        End Set
    End Property

    Public Property pNc_indtot() As Integer
        Get
            Return Me.nc_indtot
        End Get
        Set(ByVal value As Integer)
            Me.nc_indtot = value
        End Set
    End Property

    Public Property pNc_descpac() As Double
        Get
            Return Me.nc_descpac
        End Get
        Set(ByVal value As Double)
            Me.nc_descpac = value
        End Set
    End Property

    Public Property pNc_desc() As Double
        Get
            Return Me.nc_desc
        End Get
        Set(ByVal value As Double)
            Me.nc_desc = value
        End Set
    End Property

    Public Property pNc_voutro() As Double
        Get
            Return Me.nc_voutro
        End Get
        Set(ByVal value As Double)
            Me.nc_voutro = value
        End Set
    End Property

    Public Property pNc_seqitem() As Int16
        Get
            Return Me.nc_seqitem
        End Get
        Set(ByVal value As Int16)
            Me.nc_seqitem = value
        End Set
    End Property

    Public Property pNc_reduz() As Double
        Get
            Return Me.nc_reduz
        End Get
        Set(ByVal value As Double)
            Me.nc_reduz = value
        End Set
    End Property

    Public Property pNc_alqreduz() As Double
        Get
            Return Me.nc_alqreduz
        End Get
        Set(ByVal value As Double)
            Me.nc_alqreduz = value
        End Set
    End Property

    Public Property pNc_cstpis() As String
        Get
            Return Me.nc_cstpis
        End Get
        Set(ByVal value As String)
            Me.nc_cstpis = value
        End Set
    End Property

    Public Property pNc_cstcofins() As String
        Get
            Return Me.nc_cstcofins
        End Get
        Set(ByVal value As String)
            Me.nc_cstcofins = value
        End Set
    End Property

    Public Property pNc_cstipi() As String
        Get
            Return Me.nc_cstipi
        End Get
        Set(ByVal value As String)
            Me.nc_cstipi = value
        End Set
    End Property

    Public Property pNc_pruvenda() As Double
        Get
            Return Me.nc_pruvenda
        End Get
        Set(ByVal value As Double)
            Me.nc_pruvenda = value
        End Set
    End Property

#End Region


End Class
