Public Class Cl_Nota4ff

    Public n4_id As Int64
    Public n4_tipo, n4_numer, n4_pgto, n4_cdport, n4_cdfisc, n4_hist, n4_serie, n4_espec, n4_uf As String
    Public n4_serx, n4_docum, n4_x, n4_chave, n4_estab, n4_obs As String
    Public n4_tprod, n4_aliss, n4_vliss, n4_vlser, n4_basec, n4_icms, n4_bsub, n4_icsub, n4_tpro2, n4_frete, n4_segu As Double
    Public n4_outros, n4_ipi, n4_tgeral, n4_isento, n4_aliq, n4_antec, n4_alqipi, n4_ipisent, n4_ipoutro, n4_sete As Double
    Public n4_doze, n4_deze7, n4_vint5, n4_valor, n4_tipo2, n4_desc, n4_outrasdesp As Double
    Public n4_dtemis, n4_dtent, n4_emi2 As Date
    Public n4_pagamento As Int16
    Public n4_fechamento As Boolean

    Public Sub New()

        Me.n4_id = 0 : Me.n4_tipo = "" : Me.n4_numer = "" : Me.n4_pgto = "" : Me.n4_cdport = "" : Me.n4_cdfisc = "" : Me.n4_hist = "" : Me.n4_serie = ""
        Me.n4_espec = "" : Me.n4_uf = "" : Me.n4_serx = "" : Me.n4_docum = "" : Me.n4_x = "" : Me.n4_chave = "" : Me.n4_estab = "" : Me.n4_obs = ""
        Me.n4_tprod = 0.0 : Me.n4_aliss = 0.0 : Me.n4_vliss = 0.0 : Me.n4_vlser = 0.0 : Me.n4_basec = 0.0 : Me.n4_icms = 0.0 : Me.n4_bsub = 0.0 : Me.n4_icsub = 0.0
        Me.n4_tpro2 = 0.0 : Me.n4_frete = 0.0 : Me.n4_segu = 0.0 : Me.n4_outros = 0.0 : Me.n4_ipi = 0.0 : Me.n4_tgeral = 0.0 : Me.n4_isento = 0.0 : Me.n4_aliq = 0.0
        Me.n4_antec = 0.0 : Me.n4_tipo2 = 0.0 : Me.n4_alqipi = 0.0 : Me.n4_ipisent = 0.0 : Me.n4_ipoutro = 0.0 : Me.n4_sete = 0.0 : Me.n4_doze = 0.0 : Me.n4_deze7 = 0.0
        Me.n4_vint5 = 0.0 : Me.n4_valor = 0.0 : Me.n4_desc = 0.0 : Me.n4_outrasdesp = 0.0
        Me.n4_dtemis = Nothing : Me.n4_dtent = Nothing : Me.n4_emi2 = Nothing
        Me.n4_pagamento = 0
        Me.n4_fechamento = False

    End Sub

    Public Sub zeraValores()

        Me.n4_id = 0 : Me.n4_tipo = "" : Me.n4_numer = "" : Me.n4_pgto = "" : Me.n4_cdport = "" : Me.n4_cdfisc = "" : Me.n4_hist = "" : Me.n4_serie = ""
        Me.n4_espec = "" : Me.n4_uf = "" : Me.n4_serx = "" : Me.n4_docum = "" : Me.n4_x = "" : Me.n4_chave = "" : Me.n4_estab = "" : Me.n4_obs = ""
        Me.n4_tprod = 0.0 : Me.n4_aliss = 0.0 : Me.n4_vliss = 0.0 : Me.n4_vlser = 0.0 : Me.n4_basec = 0.0 : Me.n4_icms = 0.0 : Me.n4_bsub = 0.0 : Me.n4_icsub = 0.0
        Me.n4_tpro2 = 0.0 : Me.n4_frete = 0.0 : Me.n4_segu = 0.0 : Me.n4_outros = 0.0 : Me.n4_ipi = 0.0 : Me.n4_tgeral = 0.0 : Me.n4_isento = 0.0 : Me.n4_aliq = 0.0
        Me.n4_antec = 0.0 : Me.n4_tipo2 = 0.0 : Me.n4_alqipi = 0.0 : Me.n4_ipisent = 0.0 : Me.n4_ipoutro = 0.0 : Me.n4_sete = 0.0 : Me.n4_doze = 0.0 : Me.n4_deze7 = 0.0
        Me.n4_vint5 = 0.0 : Me.n4_valor = 0.0 : Me.n4_desc = 0.0 : Me.n4_outrasdesp = 0.0
        Me.n4_dtemis = Nothing : Me.n4_dtent = Nothing : Me.n4_emi2 = Nothing
        Me.n4_pagamento = 0
        Me.n4_fechamento = False

    End Sub
   

End Class
