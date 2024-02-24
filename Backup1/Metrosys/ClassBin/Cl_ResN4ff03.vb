Public Class Cl_ResN4ff03

    Public r4_id, r4_idn4f As Int64
    Public r4_numero, r4_cfop, r4_cst As String 'CFOP 4 digitos, CST 2 digitos
    Public r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp As Double
    Public r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral As Double

    Public Sub New()

        Me.r4_id = 0 : Me.r4_idn4f = 0 : Me.r4_numero = "" : Me.r4_cfop = "" : Me.r4_cst = "" : Me.r4_aliq = 0.0 : Me.r4_tprod = 0.0
        Me.r4_tdesc = 0.0 : Me.r4_tfrete = 0.0 : Me.r4_tseguro = 0.0 : Me.r4_toutrasdesp = 0.0 : Me.r4_bcalc = 0.0 : Me.r4_icms = 0.0
        Me.r4_isento = 0.0 : Me.r4_outras = 0.0 : Me.r4_ipi = 0.0 : Me.r4_tgeral = 0.0
    End Sub

    Public Sub zeraValores()

        Me.r4_id = 0 : Me.r4_idn4f = 0 : Me.r4_numero = "" : Me.r4_cfop = "" : Me.r4_cst = "" : Me.r4_aliq = 0.0 : Me.r4_tprod = 0.0
        Me.r4_tdesc = 0.0 : Me.r4_tfrete = 0.0 : Me.r4_tseguro = 0.0 : Me.r4_toutrasdesp = 0.0 : Me.r4_bcalc = 0.0 : Me.r4_icms = 0.0
        Me.r4_isento = 0.0 : Me.r4_outras = 0.0 : Me.r4_ipi = 0.0 : Me.r4_tgeral = 0.0
    End Sub

    Public Sub zeraValoresNFe()

        Me.r4_tprod = 0.0 : Me.r4_tdesc = 0.0 : Me.r4_tfrete = 0.0 : Me.r4_tseguro = 0.0 : Me.r4_toutrasdesp = 0.0
        Me.r4_bcalc = 0.0 : Me.r4_icms = 0.0 : Me.r4_isento = 0.0 : Me.r4_outras = 0.0 : Me.r4_ipi = 0.0 : Me.r4_tgeral = 0.0
    End Sub

End Class
