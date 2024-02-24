Public Class Cl_ControleCartao
    Public cc_id As Int64
    Public cc_loja As String
    Public cc_data As Date
    Public cc_vlrcartao As Double

    Public DAO As Cl_ControleCartaoDAO

    Sub New()
        Me.cc_id = 0
        Me.cc_loja = ""
        Me.cc_data = Nothing
        Me.cc_vlrcartao = 0.0

        DAO = New Cl_ControleCartaoDAO
    End Sub

    Public Sub ZeraValores()
        Me.cc_id = 0
        Me.cc_loja = ""
        Me.cc_data = Nothing
        Me.cc_vlrcartao = 0.0
    End Sub

End Class
