Public Class Cl_Nota2ff

    Public nc_id, nc_idn4ff As Int64
    Public nc_tp As Int16
    Public nc_tipo, nc_numer, nc_codpr, nc_produt, nc_cf, nc_cst, nc_und, nc_cdport, nc_usu, nc_hora, nc_cfop, nc_estab As String
    Public nc_qtde, nc_prunit, nc_prtot, nc_alqicm, nc_alqipi, nc_vlipi, nc_vlicm, nc_prucom, nc_vlicsub, nc_vlsub As Double
    Public nc_desc, nc_icmsub, nc_vldesc, nc_alqnot, nc_basesub, nc_bscalc, nc_frete, nc_seguro, nc_totbruto, nc_outrasdesp As Double
    Public nc_data, nc_dtusu As Date

    Public Sub New()

        Me.nc_id = 0 : Me.nc_idn4ff = 0 : Me.nc_tp = 0
        Me.nc_tipo = "" : Me.nc_numer = "" : Me.nc_codpr = "" : Me.nc_produt = "" : Me.nc_cf = "" : Me.nc_cst = "" : Me.nc_und = "" : Me.nc_cdport = ""
        Me.nc_usu = "" : Me.nc_hora = "" : Me.nc_cfop = "" : Me.nc_estab = ""
        Me.nc_qtde = 0.0 : Me.nc_prunit = 0.0 : Me.nc_prtot = 0.0 : Me.nc_alqicm = 0.0 : Me.nc_alqipi = 0.0 : Me.nc_vlipi = 0.0 : Me.nc_vlicm = 0.0
        Me.nc_prucom = 0.0 : Me.nc_vlicsub = 0.0 : Me.nc_vlsub = 0.0 : Me.nc_desc = 0.0 : Me.nc_icmsub = 0.0 : Me.nc_vldesc = 0.0 : Me.nc_alqnot = 0.0
        Me.nc_basesub = 0.0 : Me.nc_bscalc = 0.0 : Me.nc_frete = 0.0 : Me.nc_seguro = 0.0 : Me.nc_totbruto = 0.0 : Me.nc_outrasdesp = 0.0
        Me.nc_data = Nothing : Me.nc_dtusu = Nothing

    End Sub

    Public Sub zeraValores()

        Me.nc_id = 0 : Me.nc_idn4ff = 0 : Me.nc_tp = 0
        Me.nc_tipo = "" : Me.nc_numer = "" : Me.nc_codpr = "" : Me.nc_produt = "" : Me.nc_cf = "" : Me.nc_cst = "" : Me.nc_und = "" : Me.nc_cdport = ""
        Me.nc_usu = "" : Me.nc_hora = "" : Me.nc_cfop = "" : Me.nc_estab = ""
        Me.nc_qtde = 0.0 : Me.nc_prunit = 0.0 : Me.nc_prtot = 0.0 : Me.nc_alqicm = 0.0 : Me.nc_alqipi = 0.0 : Me.nc_vlipi = 0.0 : Me.nc_vlicm = 0.0
        Me.nc_prucom = 0.0 : Me.nc_vlicsub = 0.0 : Me.nc_vlsub = 0.0 : Me.nc_desc = 0.0 : Me.nc_icmsub = 0.0 : Me.nc_vldesc = 0.0 : Me.nc_alqnot = 0.0
        Me.nc_basesub = 0.0 : Me.nc_bscalc = 0.0 : Me.nc_frete = 0.0 : Me.nc_seguro = 0.0 : Me.nc_totbruto = 0.0 : Me.nc_outrasdesp = 0.0
        Me.nc_data = Nothing : Me.nc_dtusu = Nothing

    End Sub

    Public Sub zeraValoresNFe01()

        Me.nc_codpr = "" : Me.nc_produt = "" : Me.nc_cf = ""
        Me.nc_cst = "" : Me.nc_und = "" : Me.nc_cfop = ""
        Me.nc_qtde = 0.0 : Me.nc_prunit = 0.0 : Me.nc_prtot = 0.0 : Me.nc_alqicm = 0.0 : Me.nc_alqipi = 0.0
        Me.nc_vlipi = 0.0 : Me.nc_vlicm = 0.0 : Me.nc_vlsub = 0.0 : Me.nc_bscalc = 0.0
        Me.nc_basesub = 0.0 : Me.nc_frete = 0.0 : Me.nc_seguro = 0.0 : Me.nc_vldesc = 0.0
        Me.nc_id = 0 : Me.nc_icmsub = 0.0 : Me.nc_outrasdesp = 0.0 : Me.nc_desc = 0.0
    End Sub

End Class
