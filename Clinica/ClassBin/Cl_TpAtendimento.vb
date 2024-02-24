Public Class Cl_TpAtendimento

    Public tpa_id As Int64
    Public tpa_atendimento As String
    Public tpa_porcentage As Double

    'Objeto para Persitência:
    Public DAO As New Cl_TpAtendimentoDAO

    Sub New()
        Me.tpa_id = 0
        Me.tpa_atendimento = ""
        Me.tpa_porcentage = 0.0
    End Sub

    Public Sub ZeraValores()
        Me.tpa_id = 0
        Me.tpa_atendimento = ""
        Me.tpa_porcentage = 0.0
    End Sub

End Class
