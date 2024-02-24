Public Class Cl_DentistaOutras

    Public do_id As Int64, do_loja, do_nome, do_telefone, do_iniciais As String
    Public do_comissao As Double
    Public do_desabilitado, do_protetico As Boolean

    Public DAO As Cl_DentistaOutrasDAO

    Public Sub New()
        Me.do_id = 0 : Me.do_nome = "" : Me.do_telefone = "" : Me.do_iniciais = "" : Me.do_comissao = 0.0 : Me.do_desabilitado = False : Me.do_protetico = False
        Me.DAO = New Cl_DentistaOutrasDAO
    End Sub

    Public Sub New(ByVal mId As Int64, ByVal mNome As String, ByVal mTelefone As String, ByVal mComissao As Double)
        Me.do_id = mId : Me.do_nome = mNome : Me.do_telefone = mTelefone : Me.do_comissao = mComissao : Me.do_desabilitado = False
        Me.DAO = New Cl_DentistaOutrasDAO
    End Sub

    Public Sub zeraValores()
        Me.do_id = 0 : Me.do_nome = "" : Me.do_telefone = "" : Me.do_iniciais = "" : Me.do_comissao = 0.0 : Me.do_desabilitado = False : Me.do_protetico = False
    End Sub

End Class
