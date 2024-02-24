Public Class Cl_Servico

    Private idServico As Int64
    Private valor As Double, descricao As String

    Public Sub New()

        Me.idServico = 0 : Me.valor = 0 : Me.descricao = ""
    End Sub

#Region "   * *  Metodos Set e Get  * *   "

    Public Property pIdServico() As Int64
        Get
            Return Me.idServico
        End Get
        Set(ByVal value As Int64)
            Me.idServico = value
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
        Me.idServico = 0 : Me.valor = 0 : Me.descricao = ""
    End Sub

End Class
