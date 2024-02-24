Public Class Cl_Nota6hh

    Dim c_tipo, c_numer, c_compl1, c_compl2, c_compl3, c_compl4, c_compl5, c_compl6, c_compl7, c_compl8, c_compl9 As String
    Dim c_id, c_idn1pp As Int64

    Public Sub New()

        Me.c_tipo = "" : Me.c_numer = "" : Me.c_compl1 = "" : Me.c_compl2 = "" : Me.c_compl3 = "" : Me.c_compl4 = ""
        Me.c_compl5 = "" : Me.c_compl6 = "" : Me.c_compl7 = "" : Me.c_compl8 = "" : Me.c_compl9 = ""
        Me.c_id = 0 : Me.c_idn1pp = 0
    End Sub

    Public Sub zeraValores()

        Me.c_tipo = "" : Me.c_numer = "" : Me.c_compl1 = "" : Me.c_compl2 = "" : Me.c_compl3 = "" : Me.c_compl4 = ""
        Me.c_compl5 = "" : Me.c_compl6 = "" : Me.c_compl7 = "" : Me.c_compl8 = "" : Me.c_compl9 = ""
        Me.c_id = 0 : Me.c_idn1pp = 0
    End Sub

#Region "  * * Metodos Set e Get * *  "

    Public Property pC_tipo() As String
        Get
            Return Me.c_tipo
        End Get
        Set(ByVal value As String)
            Me.c_tipo = value
        End Set
    End Property

    Public Property pC_numer() As String
        Get
            Return Me.c_numer
        End Get
        Set(ByVal value As String)
            Me.c_numer = value
        End Set
    End Property

    Public Property pC_compl1() As String
        Get
            Return Me.c_compl1
        End Get
        Set(ByVal value As String)
            Me.c_compl1 = value
        End Set
    End Property

    Public Property pC_compl2() As String
        Get
            Return Me.c_compl2
        End Get
        Set(ByVal value As String)
            Me.c_compl2 = value
        End Set
    End Property

    Public Property pC_compl3() As String
        Get
            Return Me.c_compl3
        End Get
        Set(ByVal value As String)
            Me.c_compl3 = value
        End Set
    End Property

    Public Property pC_compl4() As String
        Get
            Return Me.c_compl4
        End Get
        Set(ByVal value As String)
            Me.c_compl4 = value
        End Set
    End Property

    Public Property pC_compl5() As String
        Get
            Return Me.c_compl5
        End Get
        Set(ByVal value As String)
            Me.c_compl5 = value
        End Set
    End Property

    Public Property pC_compl6() As String
        Get
            Return Me.c_compl6
        End Get
        Set(ByVal value As String)
            Me.c_compl6 = value
        End Set
    End Property

    Public Property pC_compl7() As String
        Get
            Return Me.c_compl7
        End Get
        Set(ByVal value As String)
            Me.c_compl7 = value
        End Set
    End Property

    Public Property pC_compl8() As String
        Get
            Return Me.c_compl8
        End Get
        Set(ByVal value As String)
            Me.c_compl8 = value
        End Set
    End Property

    Public Property pC_compl9() As String
        Get
            Return Me.c_compl9
        End Get
        Set(ByVal value As String)
            Me.c_compl9 = value
        End Set
    End Property

    Public Property pC_id() As Int64
        Get
            Return Me.c_id
        End Get
        Set(ByVal value As Int64)
            Me.c_id = value
        End Set
    End Property

    Public Property pC_idn1pp() As Int64
        Get
            Return Me.c_idn1pp
        End Get
        Set(ByVal value As Int64)
            Me.c_idn1pp = value
        End Set
    End Property

#End Region

End Class
