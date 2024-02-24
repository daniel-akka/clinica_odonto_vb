Public Class Cl_Agendamento2

    Public a2_id, a2_id1, a2_codserv As Int64
    Public a2_descrserv As String
    Public a2_dtemis As Date
    Public a2_valor, a2_qtde, a2_total As Double
  

    Sub New()

        Me.a2_id = 0 : Me.a2_id1 = 0 : Me.a2_codserv = 0 : Me.a2_descrserv = ""
        Me.a2_dtemis = Nothing : Me.a2_valor = 0.0
    End Sub

    Sub New(Id As Int64, IdRegistro As Int64, Codig As Int64, Descricao As String, DtEmiss As Date, Valor As Double)

        Me.a2_id = Id : Me.a2_id1 = IdRegistro : Me.a2_codserv = Codig : Me.a2_descrserv = Descricao
        Me.a2_dtemis = DtEmiss : Me.a2_valor = Valor : Me.a2_qtde = 0 : Me.a2_total = 0
    End Sub

    Public Sub ZeraValores()

        Me.a2_id = 0 : Me.a2_id1 = 0 : Me.a2_codserv = 0 : Me.a2_descrserv = ""
        Me.a2_dtemis = Nothing : Me.a2_valor = 0.0 : Me.a2_qtde = 0 : Me.a2_total = 0
    End Sub
End Class
