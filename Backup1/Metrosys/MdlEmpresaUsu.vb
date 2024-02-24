Module MdlEmpresaUsu

    'Colunas do Geno001
    Public geno001 As New Cl_Geno
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
    Public _esqEstab As String = ""
    Public _esqVinc As String = ""
    Public _vinculo As Int16
    Public _crt As String
    Public _retencao As Boolean


    'Colunas do Genp001
    Public genp001 As New Cl_Genp001
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
    Public _cancPedidoAuto As Boolean 'Cancelamento automático do pedido
    Public grade As Boolean
    Public tipoCondPagto As Int16 = 1
    Public cpfvalidar As Boolean
    Public tpTransfEntrada As String
    Public tpTransfSaida As String
    Public sincroniza As Boolean = False
    Public alqComisAVista As Double
    Public alqComisAPrazo As Double


End Module
