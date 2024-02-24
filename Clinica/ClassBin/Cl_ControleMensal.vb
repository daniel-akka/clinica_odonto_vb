Public Class Cl_ControleMensal
    Public c_id As Int64
    Public c_data As Date
    Public c_vlrbruto, c_vlrdespesas, c_vlrliquido, c_Vlrcartao As Double
    Public c_loja As String '2 digitos 01, 02, 03
    Public c_dentista, c_tipoatendimento As String

    Public DAO As Cl_ControleMensalDAO

    Sub New()
        Me.c_id = 0
        Me.c_data = Nothing
        Me.c_vlrbruto = 0.0 : Me.c_vlrdespesas = 0.0 : Me.c_vlrliquido = 0.0 : Me.c_Vlrcartao = 0.0
        Me.c_loja = "" : Me.c_dentista = "" : Me.c_tipoatendimento = ""

        Me.DAO = New Cl_ControleMensalDAO
    End Sub

    Public Sub zeraValores()
        Me.c_id = 0
        Me.c_data = Nothing
        Me.c_vlrbruto = 0.0 : Me.c_vlrdespesas = 0.0 : Me.c_vlrliquido = 0.0 : Me.c_Vlrcartao = 0.0
        Me.c_loja = "" : Me.c_dentista = "" : Me.c_tipoatendimento = ""
    End Sub

End Class
