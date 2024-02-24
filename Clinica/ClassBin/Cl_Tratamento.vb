Public Class Cl_Tratamento

    Public t_id As Int64
    Public t_codcliente, t_tratamento, t_ficha, t_dentista As String
    Public t_qtde, t_valor, t_total As Double

    Sub New()
        Me.t_id = 0 : Me.t_codcliente = "" : Me.t_tratamento = ""
        Me.t_qtde = 0.0 : Me.t_valor = 0.0 : Me.t_total = 0.0 : Me.t_ficha = "" : Me.t_dentista = ""
    End Sub

    Sub ZeraValores()
        Me.t_id = 0 : Me.t_codcliente = "" : Me.t_tratamento = ""
        Me.t_qtde = 0.0 : Me.t_valor = 0.0 : Me.t_total = 0.0 : Me.t_ficha = "" : Me.t_dentista = ""
    End Sub

End Class
