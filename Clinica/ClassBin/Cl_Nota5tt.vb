Public Class Cl_Nota5tt

    Dim t_tipo, t_numer, t_codp, t_placa, t_uf, t_espec, t_marca, t_antt As String
    Dim t_tpfret, t_qtde As Integer
    Dim t_pesob, t_pesol As Double
    Dim t_id, t_id1pp As Int64

    Public Sub New()

        Me.t_tipo = "" : Me.t_numer = "" : Me.t_codp = "" : Me.t_placa = "" : Me.t_uf = "" : Me.t_espec = ""
        Me.t_marca = "" : Me.t_antt = "" : Me.t_tpfret = 0 : Me.t_qtde = 0 : Me.t_pesob = 0.0 : Me.t_pesol = 0.0
        Me.t_id = 0 : Me.t_id1pp = 0
    End Sub

    Public Sub zeraValores()

        Me.t_tipo = "" : Me.t_numer = "" : Me.t_codp = "" : Me.t_placa = "" : Me.t_uf = "" : Me.t_espec = ""
        Me.t_marca = "" : Me.t_antt = "" : Me.t_tpfret = 0 : Me.t_qtde = 0 : Me.t_pesob = 0.0 : Me.t_pesol = 0.0
        Me.t_id = 0 : Me.t_id1pp = 0
    End Sub

#Region "  * * Metodos Set e Get * *  "

    Public Property pT_tipo() As String
        Get
            Return Me.t_tipo
        End Get
        Set(ByVal value As String)
            Me.t_tipo = value
        End Set
    End Property

    Public Property pT_numer() As String
        Get
            Return Me.t_numer
        End Get
        Set(ByVal value As String)
            Me.t_numer = value
        End Set
    End Property

    Public Property pT_codp() As String
        Get
            Return Me.t_codp
        End Get
        Set(ByVal value As String)
            Me.t_codp = value
        End Set
    End Property

    Public Property pT_placa() As String
        Get
            Return Me.t_placa
        End Get
        Set(ByVal value As String)
            Me.t_placa = value
        End Set
    End Property

    Public Property pT_uf() As String
        Get
            Return Me.t_uf
        End Get
        Set(ByVal value As String)
            Me.t_uf = value
        End Set
    End Property

    Public Property pT_espec() As String
        Get
            Return Me.t_espec
        End Get
        Set(ByVal value As String)
            Me.t_espec = value
        End Set
    End Property

    Public Property pT_marca() As String
        Get
            Return Me.t_marca
        End Get
        Set(ByVal value As String)
            Me.t_marca = value
        End Set
    End Property

    Public Property pT_antt() As String
        Get
            Return Me.t_antt
        End Get
        Set(ByVal value As String)
            Me.t_antt = value
        End Set
    End Property

    Public Property pT_tpfret() As Integer
        Get
            Return Me.t_tpfret
        End Get
        Set(ByVal value As Integer)
            Me.t_tpfret = value
        End Set
    End Property

    Public Property pT_qtde() As Integer
        Get
            Return Me.t_qtde
        End Get
        Set(ByVal value As Integer)
            Me.t_qtde = value
        End Set
    End Property

    Public Property pT_pesob() As Double
        Get
            Return Me.t_pesob
        End Get
        Set(ByVal value As Double)
            Me.t_pesob = value
        End Set
    End Property

    Public Property pT_pesol() As Double
        Get
            Return Me.t_pesol
        End Get
        Set(ByVal value As Double)
            Me.t_pesol = value
        End Set
    End Property

    Public Property pT_id() As Int64
        Get
            Return Me.t_id
        End Get
        Set(ByVal value As Int64)
            Me.t_id = value
        End Set
    End Property

    Public Property pT_id1pp() As Int64
        Get
            Return Me.t_id1pp
        End Get
        Set(ByVal value As Int64)
            Me.t_id1pp = value
        End Set
    End Property

#End Region

End Class
