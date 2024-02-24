Public Class Cl_Nota1pp

    Dim tipo_nt, nt_tipo, nt_nume, nt_serie, nt_natur, nt_cfop, nt_geno As String
    Dim nt_codig, nt_cnpj, nt_insc, nt_uf, nt_x, nt_y, nt_lote As String
    Dim nt_chave, nt_hrweb, nt_webrec, nt_proto, nt_status, nt_xml, nt_orca As String
    Dim nt_dtemis, nt_dtsai As Date
    Dim nt_emiss As Boolean
    Dim nt_id As Int64
    Dim nt_seqcce As Integer

    Public Sub New()

        Me.tipo_nt = "" : Me.nt_tipo = "" : Me.nt_nume = "" : Me.nt_serie = "" : Me.nt_natur = ""
        Me.nt_cfop = "" : Me.nt_geno = "" : Me.nt_codig = "" : Me.nt_cnpj = "" : Me.nt_insc = ""
        Me.nt_uf = "" : Me.nt_x = "" : Me.nt_y = "" : Me.nt_lote = "" : Me.nt_chave = ""
        Me.nt_hrweb = "" : Me.nt_webrec = "" : Me.nt_proto = "" : Me.nt_status = "" : Me.nt_xml = ""
        Me.nt_orca = "" : Me.nt_dtemis = Nothing : Me.nt_dtsai = Nothing : Me.nt_emiss = False : Me.nt_id = 0
        Me.nt_seqcce = 0

    End Sub

    Public Sub zeraValores()

        Me.tipo_nt = "" : Me.nt_tipo = "" : Me.nt_nume = "" : Me.nt_serie = "" : Me.nt_natur = ""
        Me.nt_cfop = "" : Me.nt_geno = "" : Me.nt_codig = "" : Me.nt_cnpj = "" : Me.nt_insc = ""
        Me.nt_uf = "" : Me.nt_x = "" : Me.nt_y = "" : Me.nt_lote = "" : Me.nt_chave = ""
        Me.nt_hrweb = "" : Me.nt_webrec = "" : Me.nt_proto = "" : Me.nt_status = "" : Me.nt_xml = ""
        Me.nt_orca = "" : Me.nt_dtemis = Nothing : Me.nt_dtsai = Nothing : Me.nt_emiss = False : Me.nt_id = 0
        Me.nt_seqcce = 0
    End Sub

#Region "  * * Metodos Set e Get * *  "

    Public Property pTipo_nt() As String
        Get
            Return Me.tipo_nt
        End Get
        Set(ByVal value As String)
            Me.tipo_nt = value
        End Set
    End Property

    Public Property pNt_tipo() As String
        Get
            Return Me.nt_tipo
        End Get
        Set(ByVal value As String)
            Me.nt_tipo = value
        End Set
    End Property

    Public Property pNt_nume() As String
        Get
            Return Me.nt_nume
        End Get
        Set(ByVal value As String)
            Me.nt_nume = value
        End Set
    End Property

    Public Property pNt_serie() As String
        Get
            Return Me.nt_serie
        End Get
        Set(ByVal value As String)
            Me.nt_serie = value
        End Set
    End Property

    Public Property pNt_natur() As String
        Get
            Return Me.nt_natur
        End Get
        Set(ByVal value As String)
            Me.nt_natur = value
        End Set
    End Property

    Public Property pNt_cfop() As String
        Get
            Return Me.nt_cfop
        End Get
        Set(ByVal value As String)
            Me.nt_cfop = value
        End Set
    End Property

    Public Property pNt_geno() As String
        Get
            Return Me.nt_geno
        End Get
        Set(ByVal value As String)
            Me.nt_geno = value
        End Set
    End Property

    Public Property pNt_codig() As String
        Get
            Return Me.nt_codig
        End Get
        Set(ByVal value As String)
            Me.nt_codig = value
        End Set
    End Property

    Public Property pNt_cnpj() As String
        Get
            Return Me.nt_cnpj
        End Get
        Set(ByVal value As String)
            Me.nt_cnpj = value
        End Set
    End Property

    Public Property pNt_insc() As String
        Get
            Return Me.nt_insc
        End Get
        Set(ByVal value As String)
            Me.nt_insc = value
        End Set
    End Property

    Public Property pNt_uf() As String
        Get
            Return Me.nt_uf
        End Get
        Set(ByVal value As String)
            Me.nt_uf = value
        End Set
    End Property

    Public Property pNt_x() As String
        Get
            Return Me.nt_x
        End Get
        Set(ByVal value As String)
            Me.nt_x = value
        End Set
    End Property

    Public Property pNt_y() As String
        Get
            Return Me.nt_y
        End Get
        Set(ByVal value As String)
            Me.nt_y = value
        End Set
    End Property

    Public Property pNt_lote() As String
        Get
            Return Me.nt_lote
        End Get
        Set(ByVal value As String)
            Me.nt_lote = value
        End Set
    End Property

    Public Property pNt_chave() As String
        Get
            Return Me.nt_chave
        End Get
        Set(ByVal value As String)
            Me.nt_chave = value
        End Set
    End Property

    Public Property pNt_hrweb() As String
        Get
            Return Me.nt_hrweb
        End Get
        Set(ByVal value As String)
            Me.nt_hrweb = value
        End Set
    End Property

    Public Property pNt_webrec() As String
        Get
            Return Me.nt_webrec
        End Get
        Set(ByVal value As String)
            Me.nt_webrec = value
        End Set
    End Property

    Public Property pNt_proto() As String
        Get
            Return Me.nt_proto
        End Get
        Set(ByVal value As String)
            Me.nt_proto = value
        End Set
    End Property

    Public Property pNt_status() As String
        Get
            Return Me.nt_status
        End Get
        Set(ByVal value As String)
            Me.nt_status = value
        End Set
    End Property

    Public Property pNt_xml() As String
        Get
            Return Me.nt_xml
        End Get
        Set(ByVal value As String)
            Me.nt_xml = value
        End Set
    End Property

    Public Property pNt_orca() As String
        Get
            Return Me.nt_orca
        End Get
        Set(ByVal value As String)
            Me.nt_orca = value
        End Set
    End Property

    Public Property pNt_dtemis() As Date
        Get
            Return Me.nt_dtemis
        End Get
        Set(ByVal value As Date)
            Me.nt_dtemis = value
        End Set
    End Property

    Public Property pNt_dtsai() As Date
        Get
            Return Me.nt_dtsai
        End Get
        Set(ByVal value As Date)
            Me.nt_dtsai = value
        End Set
    End Property

    Public Property pNt_emiss() As Boolean
        Get
            Return Me.nt_emiss
        End Get
        Set(ByVal value As Boolean)
            Me.nt_emiss = value
        End Set
    End Property

    Public Property pNt_id() As Int64
        Get
            Return Me.nt_id
        End Get
        Set(ByVal value As Int64)
            Me.nt_id = value
        End Set
    End Property

    Public Property pNt_seqCCe() As Integer
        Get
            Return Me.nt_seqcce
        End Get
        Set(ByVal value As Integer)
            Me.nt_seqcce = value
        End Set
    End Property

#End Region


End Class
