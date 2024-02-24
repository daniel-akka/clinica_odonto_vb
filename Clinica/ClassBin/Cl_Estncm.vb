Public Class Cl_Estncm
    Public ncm_id As Int64, ncm_ncm, ncm_cfop, ncm_pisent, ncm_cofinsent, ncm_pissaid, ncm_cofinssaid, ncm_natpis, ncm_natcofins, ncm_descricao As String

    Sub New()
        Me.ncm_id = 0 : Me.ncm_ncm = "" : Me.ncm_cfop = "" : Me.ncm_pisent = "" : Me.ncm_cofinsent = "" : Me.ncm_pissaid = "" : Me.ncm_cofinssaid = ""
        Me.ncm_natpis = "" : Me.ncm_natcofins = "" : Me.ncm_descricao = ""
    End Sub

    Sub ZeraValores()
        Me.ncm_id = 0 : Me.ncm_ncm = "" : Me.ncm_cfop = "" : Me.ncm_pisent = "" : Me.ncm_cofinsent = "" : Me.ncm_pissaid = "" : Me.ncm_cofinssaid = ""
        Me.ncm_natpis = "" : Me.ncm_natcofins = "" : Me.ncm_descricao = ""
    End Sub

End Class
