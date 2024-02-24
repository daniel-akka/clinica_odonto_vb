Public Class Cl_PisConfPadrao
    Public id As Int64, descroperacao, pisent, cofent, pissaid, cofsaid, natpis, natcof, cfops As String

    Sub New(p_id As Int64, p_descroperacao As String, p_pisent As String, p_cofent As String, p_pissaid As String, p_cofsaid As String, _
            p_natpis As String, p_natcof As String, p_cfops As String)

        Me.id = p_id : Me.descroperacao = p_descroperacao : Me.pisent = p_pisent : Me.cofent = p_cofent : Me.pissaid = p_pissaid : Me.cofsaid = p_cofsaid
        Me.natpis = p_natpis : Me.natcof = p_natcof : Me.cfops = p_cfops
    End Sub

    Sub New()
        Me.id = 0 : Me.descroperacao = "" : Me.pisent = "" : Me.cofent = "" : Me.pissaid = "" : Me.cofsaid = ""
        Me.natpis = "" : Me.natcof = "" : Me.cfops = ""
    End Sub

    Sub ZeraValores()
        Me.id = 0 : Me.descroperacao = "" : Me.pisent = "" : Me.cofent = "" : Me.pissaid = "" : Me.cofsaid = ""
        Me.natpis = "" : Me.natcof = "" : Me.cfops = ""
    End Sub

End Class
