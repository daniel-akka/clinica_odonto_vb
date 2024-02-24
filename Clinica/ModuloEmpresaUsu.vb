Module ModuloEmpresaUsu

    'Colunas do Geno001
    Public _codigo As String = ""
    Public _razaoSocialNome As String = ""
    Public _fantasia As String = ""
    Public _endereco As String = ""
    Public _bairro As String = ""
    Public _cidade As String = ""
    Public _cep As String = ""
    Public _uf As String = ""
    Public _cnpj As String = ""
    Public _inscEstadual As String = ""
    

    'Colunas do Genp001
    Public _alqIcmsInterno As Double
    Public _alqIcmsExterno As Double
    Public _alqIpi As Double
    Public _alqPis As Double
    Public _alqCofins As Double
    Public _alqSubst As Double
    Public _taxaCobranca As Double
    Public _carencia As Integer
    Public _serieNFe As String
    Public _ambienteNFe As String
    Public _codProd As Boolean 'Define coluna de código de barra ou código interno no pedido, TRUE(Cod Interno)
    

End Module
