Public Class Cl_Grupo

    Dim grupo As Integer
    Dim descricao As String


    Public Sub New()

        Me.grupo = 0 : Me.descricao = ""
    End Sub

    Public Sub zeraValores()

        Me.grupo = 0 : Me.descricao = ""
    End Sub

#Region "  * * Metodos Set e Get * *  "

    Public Property pGrupo() As Integer
        Get
            Return Me.grupo
        End Get
        Set(ByVal value As Integer)
            Me.grupo = value
        End Set
    End Property

    Public Property pDescricao() As String
        Get
            Return Me.descricao
        End Get
        Set(ByVal value As String)
            Me.descricao = value
        End Set
    End Property

#End Region

End Class
