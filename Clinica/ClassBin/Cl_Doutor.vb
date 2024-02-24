Public Class Cl_Doutor

    Public Id As Int64, Nome, Telefone, Iniciais As String
    Public Comissao As Double
    Public Desabilitado, Protetico As Boolean

    Public Sub New()
        Me.Id = 0 : Me.Nome = "" : Me.Telefone = "" : Me.Iniciais = "" : Me.Comissao = 0.0 : Me.Desabilitado = False : Me.Protetico = False
    End Sub

    Public Sub New(ByVal mId As Int64, ByVal mNome As String, ByVal mTelefone As String, ByVal mComissao As Double)
        Me.Id = mId : Me.Nome = mNome : Me.Telefone = mTelefone : Me.Comissao = mComissao : Me.Desabilitado = False
    End Sub

    Public Sub zeraValores()
        Me.Id = 0 : Me.Nome = "" : Me.Telefone = "" : Me.Iniciais = "" : Me.Comissao = 0.0 : Me.Desabilitado = False : Me.Protetico = False
    End Sub

End Class
