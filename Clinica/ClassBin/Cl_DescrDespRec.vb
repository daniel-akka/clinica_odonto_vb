Public Class Cl_DescrDespRec

    Public d_id As Int64
    Public d_descricao As String, d_tipo As String = "D"

    Sub New()
        Me.d_id = 0
        Me.d_descricao = ""
        Me.d_tipo = "D"
    End Sub

    Public Sub ZeraValores()
        Me.d_id = 0
        Me.d_descricao = ""
        Me.d_tipo = "D"
    End Sub

End Class
