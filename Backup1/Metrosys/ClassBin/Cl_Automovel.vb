Public Class Cl_Automovel

    Private placa As String, codPart As String, descricao As String

    Public Sub New()
        Me.placa = "" : Me.codPart = "" : Me.descricao = ""
    End Sub

#Region "   * *  Metodos Set e Get  * *   "

    Public Property pPlaca() As String
        Get
            Return Me.placa
        End Get
        Set(ByVal value As String)
            Me.placa = value
        End Set
    End Property

    Public Property pCodPart() As String
        Get
            Return Me.codPart
        End Get
        Set(ByVal value As String)
            Me.codPart = value
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

    Public Sub zeraValores()
        Me.placa = "" : Me.codPart = "" : Me.descricao = ""
    End Sub

End Class
