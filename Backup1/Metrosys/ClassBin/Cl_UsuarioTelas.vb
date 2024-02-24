Public Class Cl_UsuarioTelas

    Dim idUsuario As Int32
    'Cadastros
    Dim tl_Cadastros As Boolean, tl_cadcliente As Boolean, tl_cadvendedor As Boolean
    Dim tl_cadusuario As Boolean, tl_cadtitular As Boolean, tl_cadcidade As Boolean
    Dim tl_cadservico As Boolean, tl_cadgeno As Boolean, tl_cadcomodato As Boolean
    Dim tl_cadautomovel As Boolean, tl_cadgerais As Boolean, tl_cadgerente As Boolean
    'Movimentos
    Dim tl_movimentos As Boolean, tl_movpedido As Boolean, tl_movorcamento As Boolean
    Dim tl_movtransferencia As Boolean, tl_movnfe As Boolean, tl_movrequisicao As Boolean
    Dim tl_movemisspedido As Boolean, tl_movgeramapa As Boolean, tl_movpagoentregar As Boolean
    Dim btn_cancelarExcluir As Boolean, btn_carne As Boolean
    'Mapas
    Dim tl_mapas As Boolean, tl_mpvenda As Boolean, tl_mpretornovenda As Boolean
    'Cupom
    Dim tl_cupom As Boolean, tl_cpprevenda As Boolean, tl_cpvendadireta As Boolean
    Dim tl_cpconfiguracao As Boolean
    'Estoque
    Dim tl_estoque As Boolean, tl_estpesquisa As Boolean, tl_estrestaura As Boolean
    Dim tl_estimplantacao As Boolean, tl_estpedidocompras As Boolean, tl_estcompras As Boolean
    Dim tl_estatualizacao As Boolean, tl_estrelatorios As Boolean
    'Financeiro
    Dim tl_financeiro As Boolean, tl_finpagamentos As Boolean, tl_finrecebimentos As Boolean
    Dim tl_finfluxocaixa As Boolean, tl_findespesas As Boolean, tl_finchqPreDatado As Boolean
    'Manutencao
    Dim tl_manutencao As Boolean, tl_manemprestimos As Boolean, tl_mantrocas As Boolean
    Dim tl_manpalmtop As Boolean, tl_mancidadesibge As Boolean
    'Contabil
    Dim tl_contabil As Boolean, tl_ctbarqdigitais As Boolean, tl_ctblivrosfiscais As Boolean
    Dim tl_ctbcontador As Boolean, tl_ctbcfop As Boolean
    'Parametros
    Dim tl_parametros As Boolean, tl_paracontrole As Boolean, tl_paraultilitarios As Boolean
    Dim tl_parabackup As Boolean, tl_paraconfiguracao As Boolean

    Public Sub New()

        idUsuario = 0
        'Cadastros
        tl_Cadastros = False : tl_cadcliente = False : tl_cadvendedor = False : tl_cadusuario = False
        tl_cadtitular = False : tl_cadcidade = False : tl_cadservico = False : tl_cadgeno = False : tl_cadcomodato = False
        tl_cadautomovel = False : tl_cadgerais = False : tl_cadgerente = False
        'Movimentos
        tl_movimentos = False : tl_movpedido = False : tl_movorcamento = False : tl_movtransferencia = False
        tl_movnfe = False : tl_movrequisicao = False : tl_movemisspedido = False : tl_movgeramapa = False
        tl_movpagoentregar = False : btn_cancelarExcluir = False : btn_carne = False
        'Mapas
        tl_mapas = False : tl_mpvenda = False : tl_mpretornovenda = False
        'Cupom
        tl_cupom = False : tl_cpprevenda = False : tl_cpvendadireta = False : tl_cpconfiguracao = False
        'Estoque
        tl_estoque = False : tl_estpesquisa = False : tl_estrestaura = False : tl_estimplantacao = False
        tl_estpedidocompras = False : tl_estcompras = False : tl_estatualizacao = False : tl_estrelatorios = False
        'Financeiro
        tl_financeiro = False : tl_finpagamentos = False : tl_finrecebimentos = False : tl_finfluxocaixa = False
        tl_findespesas = False : tl_finchqPreDatado = False
        'Manutencao
        tl_manutencao = False : tl_manemprestimos = False : tl_mantrocas = False : tl_manpalmtop = False
        tl_mancidadesibge = False
        'Contabil
        tl_contabil = False : tl_ctbarqdigitais = False : tl_ctblivrosfiscais = False : tl_ctbcontador = False
        tl_ctbcfop = False
        'Parametros
        tl_parametros = False : tl_paracontrole = False : tl_paraultilitarios = False : tl_parabackup = False
        tl_paraconfiguracao = False

    End Sub

    Public Sub zeraValores()

        idUsuario = 0
        'Cadastros
        tl_Cadastros = False : tl_cadcliente = False : tl_cadvendedor = False : tl_cadusuario = False
        tl_cadtitular = False : tl_cadcidade = False : tl_cadservico = False : tl_cadgeno = False : tl_cadcomodato = False
        tl_cadautomovel = False : tl_cadgerais = False : tl_cadgerente = False
        'Movimentos
        tl_movimentos = False : tl_movpedido = False : tl_movorcamento = False : tl_movtransferencia = False
        tl_movnfe = False : tl_movrequisicao = False : tl_movemisspedido = False : tl_movgeramapa = False
        tl_movpagoentregar = False : btn_cancelarExcluir = False : btn_carne = False
        'Mapas
        tl_mapas = False : tl_mpvenda = False : tl_mpretornovenda = False
        'Cupom
        tl_cupom = False : tl_cpprevenda = False : tl_cpvendadireta = False : tl_cpconfiguracao = False
        'Estoque
        tl_estoque = False : tl_estpesquisa = False : tl_estrestaura = False : tl_estimplantacao = False
        tl_estpedidocompras = False : tl_estcompras = False : tl_estatualizacao = False : tl_estrelatorios = False
        'Financeiro
        tl_financeiro = False : tl_finpagamentos = False : tl_finrecebimentos = False : tl_finfluxocaixa = False
        tl_findespesas = False : tl_finchqPreDatado = False
        'Manutencao
        tl_manutencao = False : tl_manemprestimos = False : tl_mantrocas = False : tl_manpalmtop = False
        tl_mancidadesibge = False
        'Contabil
        tl_contabil = False : tl_ctbarqdigitais = False : tl_ctblivrosfiscais = False : tl_ctbcontador = False
        tl_ctbcfop = False
        'Parametros
        tl_parametros = False : tl_paracontrole = False : tl_paraultilitarios = False : tl_parabackup = False
        tl_paraconfiguracao = False

    End Sub


#Region "   * * Metodos Set e Get * *   "

    Public Property pIdUsuario() As Int32
        Get
            Return Me.idUsuario
        End Get
        Set(ByVal value As Int32)
            Me.idUsuario = value
        End Set
    End Property

    Public Property pTl_Cadastros() As Boolean
        Get
            Return Me.tl_Cadastros
        End Get
        Set(ByVal value As Boolean)
            Me.tl_Cadastros = value
        End Set
    End Property

    Public Property pTl_cadcliente() As Boolean
        Get
            Return Me.tl_cadcliente
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cadcliente = value
        End Set
    End Property

    Public Property pTl_cadvendedor() As Boolean
        Get
            Return Me.tl_cadvendedor
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cadvendedor = value
        End Set
    End Property

    Public Property pTl_cadusuario() As Boolean
        Get
            Return Me.tl_cadusuario
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cadusuario = value
        End Set
    End Property

    Public Property pTl_cadtitular() As Boolean
        Get
            Return Me.tl_cadtitular
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cadtitular = value
        End Set
    End Property

    Public Property pTl_cadcidade() As Boolean
        Get
            Return Me.tl_cadcidade
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cadcidade = value
        End Set
    End Property

    Public Property pTl_cadservico() As Boolean
        Get
            Return Me.tl_cadservico
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cadservico = value
        End Set
    End Property

    Public Property pTl_cadgeno() As Boolean
        Get
            Return Me.tl_cadgeno
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cadgeno = value
        End Set
    End Property

    Public Property pTl_cadcomodato() As Boolean
        Get
            Return Me.tl_cadcomodato
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cadcomodato = value
        End Set
    End Property

    Public Property pTl_cadautomovel() As Boolean
        Get
            Return Me.tl_cadautomovel
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cadautomovel = value
        End Set
    End Property

    Public Property pTl_cadgerais() As Boolean
        Get
            Return Me.tl_cadgerais
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cadgerais = value
        End Set
    End Property

    Public Property pTl_cadgerente() As Boolean
        Get
            Return Me.tl_cadgerente
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cadgerente = value
        End Set
    End Property

    Public Property pTl_movimentos() As Boolean
        Get
            Return Me.tl_movimentos
        End Get
        Set(ByVal value As Boolean)
            Me.tl_movimentos = value
        End Set
    End Property

    Public Property pTl_movpedido() As Boolean
        Get
            Return Me.tl_movpedido
        End Get
        Set(ByVal value As Boolean)
            Me.tl_movpedido = value
        End Set
    End Property

    Public Property pTl_movorcamento() As Boolean
        Get
            Return Me.tl_movorcamento
        End Get
        Set(ByVal value As Boolean)
            Me.tl_movorcamento = value
        End Set
    End Property

    Public Property pTl_movtransferencia() As Boolean
        Get
            Return Me.tl_movtransferencia
        End Get
        Set(ByVal value As Boolean)
            Me.tl_movtransferencia = value
        End Set
    End Property

    Public Property pTl_movnfe() As Boolean
        Get
            Return Me.tl_movnfe
        End Get
        Set(ByVal value As Boolean)
            Me.tl_movnfe = value
        End Set
    End Property

    Public Property pTl_movrequisicao() As Boolean
        Get
            Return Me.tl_movrequisicao
        End Get
        Set(ByVal value As Boolean)
            Me.tl_movrequisicao = value
        End Set
    End Property

    Public Property pTl_movemisspedido() As Boolean
        Get
            Return Me.tl_movemisspedido
        End Get
        Set(ByVal value As Boolean)
            Me.tl_movemisspedido = value
        End Set
    End Property

    Public Property pTl_movgeramapa() As Boolean
        Get
            Return Me.tl_movgeramapa
        End Get
        Set(ByVal value As Boolean)
            Me.tl_movgeramapa = value
        End Set
    End Property

    Public Property pTl_movpagoentregar() As Boolean
        Get
            Return Me.tl_movpagoentregar
        End Get
        Set(ByVal value As Boolean)
            Me.tl_movpagoentregar = value
        End Set
    End Property

    Public Property pBtn_cancelarExcluir() As Boolean
        Get
            Return Me.btn_cancelarExcluir
        End Get
        Set(ByVal value As Boolean)
            Me.btn_cancelarExcluir = value
        End Set
    End Property

    Public Property pBtn_carne() As Boolean
        Get
            Return Me.btn_carne
        End Get
        Set(ByVal value As Boolean)
            Me.btn_carne = value
        End Set
    End Property

    Public Property pTl_mapas() As Boolean
        Get
            Return Me.tl_mapas
        End Get
        Set(ByVal value As Boolean)
            Me.tl_mapas = value
        End Set
    End Property

    Public Property pTl_mpvenda() As Boolean
        Get
            Return Me.tl_mpvenda
        End Get
        Set(ByVal value As Boolean)
            Me.tl_mpvenda = value
        End Set
    End Property

    Public Property pTl_mpretornovenda() As Boolean
        Get
            Return Me.tl_mpretornovenda
        End Get
        Set(ByVal value As Boolean)
            Me.tl_mpretornovenda = value
        End Set
    End Property

    Public Property pTl_cupom() As Boolean
        Get
            Return Me.tl_cupom
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cupom = value
        End Set
    End Property

    Public Property pTl_cpprevenda() As Boolean
        Get
            Return Me.tl_cpprevenda
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cpprevenda = value
        End Set
    End Property

    Public Property pTl_cpvendadireta() As Boolean
        Get
            Return Me.tl_cpvendadireta
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cpvendadireta = value
        End Set
    End Property

    Public Property pTl_cpconfiguracao() As Boolean
        Get
            Return Me.tl_cpconfiguracao
        End Get
        Set(ByVal value As Boolean)
            Me.tl_cpconfiguracao = value
        End Set
    End Property

    Public Property pTl_estoque() As Boolean
        Get
            Return Me.tl_estoque
        End Get
        Set(ByVal value As Boolean)
            Me.tl_estoque = value
        End Set
    End Property

    Public Property pTl_estpesquisa() As Boolean
        Get
            Return Me.tl_estpesquisa
        End Get
        Set(ByVal value As Boolean)
            Me.tl_estpesquisa = value
        End Set
    End Property

    Public Property pTl_estrestaura() As Boolean
        Get
            Return Me.tl_estrestaura
        End Get
        Set(ByVal value As Boolean)
            Me.tl_estrestaura = value
        End Set
    End Property

    Public Property pTl_estimplantacao() As Boolean
        Get
            Return Me.tl_estimplantacao
        End Get
        Set(ByVal value As Boolean)
            Me.tl_estimplantacao = value
        End Set
    End Property

    Public Property pTl_estpedidocompras() As Boolean
        Get
            Return Me.tl_estpedidocompras
        End Get
        Set(ByVal value As Boolean)
            Me.tl_estpedidocompras = value
        End Set
    End Property

    Public Property pTl_estcompras() As Boolean
        Get
            Return Me.tl_estcompras
        End Get
        Set(ByVal value As Boolean)
            Me.tl_estcompras = value
        End Set
    End Property

    Public Property pTl_estatualizacao() As Boolean
        Get
            Return Me.tl_estatualizacao
        End Get
        Set(ByVal value As Boolean)
            Me.tl_estatualizacao = value
        End Set
    End Property

    Public Property pTl_estrelatorios() As Boolean
        Get
            Return Me.tl_estrelatorios
        End Get
        Set(ByVal value As Boolean)
            Me.tl_estrelatorios = value
        End Set
    End Property

    Public Property pTl_financeiro() As Boolean
        Get
            Return Me.tl_financeiro
        End Get
        Set(ByVal value As Boolean)
            Me.tl_financeiro = value
        End Set
    End Property

    Public Property pTl_finpagamentos() As Boolean
        Get
            Return Me.tl_finpagamentos
        End Get
        Set(ByVal value As Boolean)
            Me.tl_finpagamentos = value
        End Set
    End Property

    Public Property pTl_finrecebimentos() As Boolean
        Get
            Return Me.tl_finrecebimentos
        End Get
        Set(ByVal value As Boolean)
            Me.tl_finrecebimentos = value
        End Set
    End Property

    Public Property pTl_finfluxocaixa() As Boolean
        Get
            Return Me.tl_finfluxocaixa
        End Get
        Set(ByVal value As Boolean)
            Me.tl_finfluxocaixa = value
        End Set
    End Property

    Public Property pTl_findespesas() As Boolean
        Get
            Return Me.tl_findespesas
        End Get
        Set(ByVal value As Boolean)
            Me.tl_findespesas = value
        End Set
    End Property

    Public Property pTl_finchqPreDatado() As Boolean
        Get
            Return Me.tl_finchqPreDatado
        End Get
        Set(ByVal value As Boolean)
            Me.tl_finchqPreDatado = value
        End Set
    End Property

    Public Property pTl_manutencao() As Boolean
        Get
            Return Me.tl_manutencao
        End Get
        Set(ByVal value As Boolean)
            Me.tl_manutencao = value
        End Set
    End Property

    Public Property pTl_manemprestimos() As Boolean
        Get
            Return Me.tl_manemprestimos
        End Get
        Set(ByVal value As Boolean)
            Me.tl_manemprestimos = value
        End Set
    End Property

    Public Property pTl_mantrocas() As Boolean
        Get
            Return Me.tl_mantrocas
        End Get
        Set(ByVal value As Boolean)
            Me.tl_mantrocas = value
        End Set
    End Property

    Public Property pTl_manpalmtop() As Boolean
        Get
            Return Me.tl_manpalmtop
        End Get
        Set(ByVal value As Boolean)
            Me.tl_manpalmtop = value
        End Set
    End Property

    Public Property pTl_mancidadesibge() As Boolean
        Get
            Return Me.tl_mancidadesibge
        End Get
        Set(ByVal value As Boolean)
            Me.tl_mancidadesibge = value
        End Set
    End Property

    Public Property pTl_contabil() As Boolean
        Get
            Return Me.tl_contabil
        End Get
        Set(ByVal value As Boolean)
            Me.tl_contabil = value
        End Set
    End Property

    Public Property pTl_ctbarqdigitais() As Boolean
        Get
            Return Me.tl_ctbarqdigitais
        End Get
        Set(ByVal value As Boolean)
            Me.tl_ctbarqdigitais = value
        End Set
    End Property

    Public Property pTl_ctblivrosfiscais() As Boolean
        Get
            Return Me.tl_ctblivrosfiscais
        End Get
        Set(ByVal value As Boolean)
            Me.tl_ctblivrosfiscais = value
        End Set
    End Property

    Public Property pTl_ctbcontador() As Boolean
        Get
            Return Me.tl_ctbcontador
        End Get
        Set(ByVal value As Boolean)
            Me.tl_ctbcontador = value
        End Set
    End Property

    Public Property pTl_ctbcfop() As Boolean
        Get
            Return Me.tl_ctbcfop
        End Get
        Set(ByVal value As Boolean)
            Me.tl_ctbcfop = value
        End Set
    End Property

    Public Property pTl_parametros() As Boolean
        Get
            Return Me.tl_parametros
        End Get
        Set(ByVal value As Boolean)
            Me.tl_parametros = value
        End Set
    End Property

    Public Property pTl_paracontrole() As Boolean
        Get
            Return Me.tl_paracontrole
        End Get
        Set(ByVal value As Boolean)
            Me.tl_paracontrole = value
        End Set
    End Property

    Public Property pTl_paraultilitarios() As Boolean
        Get
            Return Me.tl_paraultilitarios
        End Get
        Set(ByVal value As Boolean)
            Me.tl_paraultilitarios = value
        End Set
    End Property

    Public Property pTl_parabackup() As Boolean
        Get
            Return Me.tl_parabackup
        End Get
        Set(ByVal value As Boolean)
            Me.tl_parabackup = value
        End Set
    End Property

    Public Property pTl_paraconfiguracao() As Boolean
        Get
            Return Me.tl_paraconfiguracao
        End Get
        Set(ByVal value As Boolean)
            Me.tl_paraconfiguracao = value
        End Set
    End Property

#End Region


End Class
