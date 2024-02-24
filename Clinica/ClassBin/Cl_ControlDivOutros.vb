Public Class Cl_ControlDivOutros

    Public cd_id As Int64
    Public cd_data As Date
    Public cd_vlrliquido, cd_vlrsoma As Double
    Public cd_loja As String '2 digitos 01, 02, 03
    Public cd_dentista As Integer 'Id Dentista Outras Clínicas


    Public DAO As Cl_ContrDivOutrosDAO

    Sub New()
        Me.cd_id = 0 : Me.cd_dentista = 0
        Me.cd_data = Nothing
        Me.cd_vlrliquido = 0.0 : Me.cd_vlrsoma = 0.0
        Me.cd_loja = ""

        Me.DAO = New Cl_ContrDivOutrosDAO
    End Sub

    Public Sub zeraValores()
        Me.cd_id = 0 : Me.cd_dentista = 0
        Me.cd_data = Nothing
        Me.cd_vlrliquido = 0.0 : Me.cd_vlrsoma = 0.0
        Me.cd_loja = ""
    End Sub

End Class
