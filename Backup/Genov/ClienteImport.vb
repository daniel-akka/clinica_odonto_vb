
Public Class ClienteImport

    Private vnt_x As String
    Private vnt_y As String
    Private vnt_orca As String
    Private vnt_geno As String
    Private vnt_codig As String

    Public Property nt_x() As String
        Get
            Return (vnt_x)
        End Get
        Set(ByVal value As String)
            vnt_x = value
        End Set
    End Property

    Public Property nt_y() As String
        Get
            Return (vnt_y)
        End Get
        Set(ByVal value As String)
            vnt_y = value
        End Set
    End Property

    Public Property nt_orca() As String
        Get
            Return (vnt_orca)
        End Get
        Set(ByVal value As String)
            vnt_orca = value
        End Set
    End Property

    Public Property nt_geno() As String
        Get
            Return (vnt_geno)
        End Get
        Set(ByVal value As String)
            vnt_geno = value
        End Set
    End Property

    Public Property nt_codig() As String
        Get
            Return (vnt_codig)
        End Get
        Set(ByVal value As String)
            vnt_codig = value
        End Set
    End Property

    Public Sub Grava_cliente()

    End Sub
End Class
