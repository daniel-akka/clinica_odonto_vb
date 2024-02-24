Public Class Cl_Est0001

    Dim codig As String, produt As String, cdport As String
    Dim und As String, clf As String, cst As Integer
    Dim cfv, linha, grupo, tipo As Integer
    Dim locacao As String, codsubs As String, estmin As Double
    Dim comer As String, qtde As Double, pcusto As Double
    Dim pvenda As Double, com1 As Double, com2 As Double
    Dim peso As Double, prom As String, reduz As Double
    Dim vprom As Double, qtdfisc As Double, inventa As Double
    Dim pcustom As Double, pcustoa As Double, prepo As Double
    Dim pcomp As Double, dtcomp, dtvend As Date
    Dim pvend15 As Double, pvend30 As Double, agreg1 As Double
    Dim agreg2 As Double, deposito As Double, empcre As Double
    Dim empdeb As Double, promi As String, valid As Date
    Dim status As String, fixo As String, ptran As Double
    Dim ipi As Double, letra As String, icmsub As Double
    Dim pis As Double, icms As Double, filial1 As Double
    Dim filial2 As Double, bonif As Double, ncm As String
    Dim produt2 As String, pcstent As String, ccstent As String
    Dim pcstsai As String, ccstsai As String, pbcalc As String
    Dim cdforte As String, fortcof As String, cdbarra As String
    Dim embalag As String, pesobruto As Double, pesoliq As Double
    Dim consumo As Boolean, imobilizado As Boolean, servico As Boolean
    Dim inativo As Boolean, materiaprima As Boolean, qtdxUnd As Double
    Dim balanca As String, pauta As Double, classe As String, grade As String
    Dim dtinicialpromocao, dtfinalpromocao, dtinicialbonific, dtfinalbonific As Date
    Dim qtdebonifcliente As Integer, bonificquantidade, bonificvalor As Boolean
    Dim quotapromocao As Double
    Dim origem As Int16
    Dim aplicacao, cstipi, produt3 As String
    Dim idImagem As Int64


    Public Sub New()

        Me.codig = "" : Me.produt = "" : Me.cdport = "" : Me.und = "" : Me.clf = ""
        Me.cst = 0 : Me.cfv = 0 : Me.linha = 0 : Me.grupo = 0 : Me.locacao = "" : Me.codsubs = ""
        Me.estmin = 0.0 : Me.comer = "" : Me.qtde = 0.0 : Me.pcusto = 0.0 : Me.pvenda = 0.0
        Me.com1 = 0.0 : Me.com2 = 0.0 : Me.peso = 0.0 : Me.prom = "" : Me.reduz = 0.0 : Me.vprom = 0.0
        Me.qtdfisc = 0.0 : Me.inventa = 0.0 : Me.pcustom = 0.0 : Me.pcustoa = 0.0
        Me.prepo = 0.0 : Me.pcomp = 0.0 : Me.dtcomp = Nothing : Me.dtvend = Nothing
        Me.pvend15 = 0.0 : Me.pvend30 = 0 : Me.agreg1 = 0.0 : Me.agreg2 = 0.0 : Me.deposito = 0.0
        Me.empcre = 0.0 : Me.empdeb = 0.0 : Me.promi = "" : Me.valid = Nothing
        Me.status = "" : Me.fixo = "" : Me.ptran = 0.0 : Me.ipi = 0.0 : Me.letra = ""
        Me.icmsub = 0.0 : Me.pis = 0.0 : Me.icms = 0.0 : Me.filial1 = 0.0 : Me.filial2 = 0.0
        Me.bonif = 0.0 : Me.ncm = "" : Me.produt2 = "" : Me.pcstent = "" : Me.ccstent = ""
        Me.pcstsai = "" : Me.ccstsai = "" : Me.pbcalc = "" : Me.cdforte = ""
        Me.fortcof = "" : Me.cdbarra = "" : Me.embalag = "" : Me.pesobruto = 0.0
        Me.pesoliq = 0.0 : Me.consumo = False : Me.imobilizado = False : Me.servico = False
        Me.inativo = False : Me.materiaprima = False : Me.qtdxUnd = 0.0 : Me.balanca = ""
        Me.pauta = 0.0 : Me.classe = "" : Me.tipo = 0 : Me.grade = "N"
        Me.dtinicialpromocao = Nothing : Me.dtfinalpromocao = Nothing : Me.dtinicialbonific = Nothing
        Me.dtfinalbonific = Nothing : Me.quotapromocao = 0.0 : Me.bonificquantidade = False : Me.bonificvalor = False
        Me.qtdebonifcliente = 0 : Me.origem = 0 : Me.aplicacao = "" : Me.cstipi = "" : Me.produt3 = ""
        Me.idImagem = 0

    End Sub

    Public Sub zeraValores()

        Me.codig = "" : Me.produt = "" : Me.cdport = "" : Me.und = "" : Me.clf = ""
        Me.cst = 0 : Me.cfv = 0 : Me.linha = 0 : Me.grupo = 0 : Me.locacao = "" : Me.codsubs = ""
        Me.estmin = 0.0 : Me.comer = "" : Me.qtde = 0.0 : Me.pcusto = 0.0 : Me.pvenda = 0.0
        Me.com1 = 0.0 : Me.com2 = 0.0 : Me.peso = 0.0 : Me.prom = "" : Me.reduz = 0.0 : Me.vprom = 0.0
        Me.qtdfisc = 0.0 : Me.inventa = 0.0 : Me.pcustom = 0.0 : Me.pcustoa = 0.0
        Me.prepo = 0.0 : Me.pcomp = 0.0 : Me.dtcomp = Nothing : Me.dtvend = Nothing
        Me.pvend15 = 0.0 : Me.pvend30 = 0 : Me.agreg1 = 0.0 : Me.agreg2 = 0.0 : Me.deposito = 0.0
        Me.empcre = 0.0 : Me.empdeb = 0.0 : Me.promi = "" : Me.valid = Nothing
        Me.status = "" : Me.fixo = "" : Me.ptran = 0.0 : Me.ipi = 0.0 : Me.letra = ""
        Me.icmsub = 0.0 : Me.pis = 0.0 : Me.icms = 0.0 : Me.filial1 = 0.0 : Me.filial2 = 0.0
        Me.bonif = 0.0 : Me.ncm = "" : Me.produt2 = "" : Me.pcstent = "" : Me.ccstent = ""
        Me.pcstsai = "" : Me.ccstsai = "" : Me.pbcalc = "" : Me.cdforte = ""
        Me.fortcof = "" : Me.cdbarra = "" : Me.embalag = "" : Me.pesobruto = 0.0
        Me.pesoliq = 0.0 : Me.consumo = False : Me.imobilizado = False : Me.servico = False
        Me.inativo = False : Me.materiaprima = False : Me.qtdxUnd = 0.0 : Me.balanca = ""
        Me.pauta = 0.0 : Me.classe = "" : Me.tipo = 0 : Me.grade = "N"
        Me.dtinicialpromocao = Nothing : Me.dtfinalpromocao = Nothing : Me.dtinicialbonific = Nothing
        Me.dtfinalbonific = Nothing : Me.quotapromocao = 0.0 : Me.bonificquantidade = False : Me.bonificvalor = False
        Me.qtdebonifcliente = 0 : Me.origem = 0 : Me.aplicacao = "" : Me.cstipi = "" : Me.produt3 = ""
        Me.idImagem = 0

    End Sub

#Region "  * * Metodos Set e Get * *  "

    Property pCodig() As String
        Get
            Return Me.codig
        End Get
        Set(ByVal value As String)
            Me.codig = value
        End Set
    End Property

    Property pProdut() As String
        Get
            Return Me.produt
        End Get
        Set(ByVal value As String)
            Me.produt = value
        End Set
    End Property

    Property pCdport() As String
        Get
            Return Me.cdport
        End Get
        Set(ByVal value As String)
            Me.cdport = value
        End Set
    End Property

    Property pUnd() As String
        Get
            Return Me.und
        End Get
        Set(ByVal value As String)
            Me.und = value
        End Set
    End Property

    Property pClf() As String
        Get
            Return Me.clf
        End Get
        Set(ByVal value As String)
            Me.clf = value
        End Set
    End Property

    Property pCst() As Integer
        Get
            Return Me.cst
        End Get
        Set(ByVal value As Integer)
            Me.cst = value
        End Set
    End Property

    Property pCfv() As Integer
        Get
            Return Me.cfv
        End Get
        Set(ByVal value As Integer)
            Me.cfv = value
        End Set
    End Property

    Property pLinha() As Integer
        Get
            Return Me.linha
        End Get
        Set(ByVal value As Integer)
            Me.linha = value
        End Set
    End Property

    Property pGrupo() As Integer
        Get
            Return Me.grupo
        End Get
        Set(ByVal value As Integer)
            Me.grupo = value
        End Set
    End Property

    Property pLocacao() As String
        Get
            Return Me.locacao
        End Get
        Set(ByVal value As String)
            Me.locacao = value
        End Set
    End Property

    Property pCodsubs() As String
        Get
            Return Me.codsubs
        End Get
        Set(ByVal value As String)
            Me.codsubs = value
        End Set
    End Property

    Property pEstmin() As Double
        Get
            Return Me.estmin
        End Get
        Set(ByVal value As Double)
            Me.estmin = value
        End Set
    End Property

    Property pComer() As String
        Get
            Return Me.comer
        End Get
        Set(ByVal value As String)
            Me.comer = value
        End Set
    End Property

    Property pQtde() As Double
        Get
            Return Me.qtde
        End Get
        Set(ByVal value As Double)
            Me.qtde = value
        End Set
    End Property

    Property pPcusto() As Double
        Get
            Return Me.pcusto
        End Get
        Set(ByVal value As Double)
            Me.pcusto = value
        End Set
    End Property

    Property pPvenda() As Double
        Get
            Return Me.pvenda
        End Get
        Set(ByVal value As Double)
            Me.pvenda = value
        End Set
    End Property

    Property pCom1() As Double
        Get
            Return Me.com1
        End Get
        Set(ByVal value As Double)
            Me.com1 = value
        End Set
    End Property

    Property pCom2() As Double
        Get
            Return Me.com2
        End Get
        Set(ByVal value As Double)
            Me.com2 = value
        End Set
    End Property

    Property pPeso() As Double
        Get
            Return Me.peso
        End Get
        Set(ByVal value As Double)
            Me.peso = value
        End Set
    End Property

    Property pProm() As String
        Get
            Return Me.prom
        End Get
        Set(ByVal value As String)
            Me.prom = value
        End Set
    End Property

    Property pReduz() As Double
        Get
            Return Me.reduz
        End Get
        Set(ByVal value As Double)
            Me.reduz = value
        End Set
    End Property

    Property pVprom() As Double
        Get
            Return Me.vprom
        End Get
        Set(ByVal value As Double)
            Me.vprom = value
        End Set
    End Property

    Property pQtdfisc() As Double
        Get
            Return Me.qtdfisc
        End Get
        Set(ByVal value As Double)
            Me.qtdfisc = value
        End Set
    End Property

    Property pInventa() As Double
        Get
            Return Me.inventa
        End Get
        Set(ByVal value As Double)
            Me.inventa = value
        End Set
    End Property

    Property pPcustom() As Double
        Get
            Return Me.pcustom
        End Get
        Set(ByVal value As Double)
            Me.pcustom = value
        End Set
    End Property

    Property pPcustoa() As Double
        Get
            Return Me.pcustoa
        End Get
        Set(ByVal value As Double)
            Me.pcustoa = value
        End Set
    End Property

    Property pPrepo() As Double
        Get
            Return Me.prepo
        End Get
        Set(ByVal value As Double)
            Me.prepo = value
        End Set
    End Property

    Property pPcomp() As Double
        Get
            Return Me.pcomp
        End Get
        Set(ByVal value As Double)
            Me.pcomp = value
        End Set
    End Property

    Property pDtcomp() As Date
        Get
            Return Me.dtcomp
        End Get
        Set(ByVal value As Date)
            Me.dtcomp = value
        End Set
    End Property

    Property pDtvend() As Date
        Get
            Return Me.dtvend
        End Get
        Set(ByVal value As Date)
            Me.dtvend = value
        End Set
    End Property

    Property pPvend15() As Double
        Get
            Return Me.pvend15
        End Get
        Set(ByVal value As Double)
            Me.pvend15 = value
        End Set
    End Property

    Property pPvend30() As Double
        Get
            Return Me.pvend30
        End Get
        Set(ByVal value As Double)
            Me.pvend30 = value
        End Set
    End Property

    Property pAgreg1() As Double
        Get
            Return Me.agreg1
        End Get
        Set(ByVal value As Double)
            Me.agreg1 = value
        End Set
    End Property

    Property pAgreg2() As Double
        Get
            Return Me.agreg2
        End Get
        Set(ByVal value As Double)
            Me.agreg2 = value
        End Set
    End Property

    Property pDeposito() As Double
        Get
            Return Me.deposito
        End Get
        Set(ByVal value As Double)
            Me.deposito = value
        End Set
    End Property

    Property pEmpcre() As Double
        Get
            Return Me.empcre
        End Get
        Set(ByVal value As Double)
            Me.empcre = value
        End Set
    End Property

    Property pEmpdeb() As Double
        Get
            Return Me.empdeb
        End Get
        Set(ByVal value As Double)
            Me.empdeb = value
        End Set
    End Property

    Property pPromi() As String
        Get
            Return Me.promi
        End Get
        Set(ByVal value As String)
            Me.promi = value
        End Set
    End Property

    Property pValid() As Date
        Get
            Return Me.valid
        End Get
        Set(ByVal value As Date)
            Me.valid = value
        End Set
    End Property

    Property pStatus() As String
        Get
            Return Me.status
        End Get
        Set(ByVal value As String)
            Me.status = value
        End Set
    End Property

    Property pFixo() As String
        Get
            Return Me.fixo
        End Get
        Set(ByVal value As String)
            Me.fixo = value
        End Set
    End Property

    Property pPtran() As Double
        Get
            Return Me.ptran
        End Get
        Set(ByVal value As Double)
            Me.ptran = value
        End Set
    End Property

    Property pIpi() As Double
        Get
            Return Me.ipi
        End Get
        Set(ByVal value As Double)
            Me.ipi = value
        End Set
    End Property

    Property pLetra() As String
        Get
            Return Me.letra
        End Get
        Set(ByVal value As String)
            Me.letra = value
        End Set
    End Property

    Property pIcmsub() As Double
        Get
            Return Me.icmsub
        End Get
        Set(ByVal value As Double)
            Me.icmsub = value
        End Set
    End Property

    Property pPis() As Double
        Get
            Return Me.pis
        End Get
        Set(ByVal value As Double)
            Me.pis = value
        End Set
    End Property

    Property pIcms() As Double
        Get
            Return Me.icms
        End Get
        Set(ByVal value As Double)
            Me.icms = value
        End Set
    End Property

    Property pFilial1() As Double
        Get
            Return Me.filial1
        End Get
        Set(ByVal value As Double)
            Me.filial1 = value
        End Set
    End Property

    Property pFilial2() As Double
        Get
            Return Me.filial2
        End Get
        Set(ByVal value As Double)
            Me.filial2 = value
        End Set
    End Property

    Property pBonif() As Double
        Get
            Return Me.bonif
        End Get
        Set(ByVal value As Double)
            Me.bonif = value
        End Set
    End Property

    Property pNcm() As String
        Get
            Return Me.ncm
        End Get
        Set(ByVal value As String)
            Me.ncm = value
        End Set
    End Property

    Property pProdut2() As String
        Get
            Return Me.produt2
        End Get
        Set(ByVal value As String)
            Me.produt2 = value
        End Set
    End Property

    Property pPcstent() As String
        Get
            Return Me.pcstent
        End Get
        Set(ByVal value As String)
            Me.pcstent = value
        End Set
    End Property

    Property pCcstent() As String
        Get
            Return Me.ccstent
        End Get
        Set(ByVal value As String)
            Me.ccstent = value
        End Set
    End Property

    Property pPcstsai() As String
        Get
            Return Me.pcstsai
        End Get
        Set(ByVal value As String)
            Me.pcstsai = value
        End Set
    End Property

    Property pCcstsai() As String
        Get
            Return Me.ccstsai
        End Get
        Set(ByVal value As String)
            Me.ccstsai = value
        End Set
    End Property

    Property pPbcalc() As String
        Get
            Return Me.pbcalc
        End Get
        Set(ByVal value As String)
            Me.pbcalc = value
        End Set
    End Property

    Property pCdforte() As String
        Get
            Return Me.cdforte
        End Get
        Set(ByVal value As String)
            Me.cdforte = value
        End Set
    End Property

    Property pFortcof() As String
        Get
            Return Me.fortcof
        End Get
        Set(ByVal value As String)
            Me.fortcof = value
        End Set
    End Property

    Property pCdbarra() As String
        Get
            Return Me.cdbarra
        End Get
        Set(ByVal value As String)
            Me.cdbarra = value
        End Set
    End Property

    Property pEmbalag() As String
        Get
            Return Me.embalag
        End Get
        Set(ByVal value As String)
            Me.embalag = value
        End Set
    End Property

    Property pPesobruto() As Double
        Get
            Return Me.pesobruto
        End Get
        Set(ByVal value As Double)
            Me.pesobruto = value
        End Set
    End Property

    Property pPesoliq() As Double
        Get
            Return Me.pesoliq
        End Get
        Set(ByVal value As Double)
            Me.pesoliq = value
        End Set
    End Property

    Property pConsumo() As Boolean
        Get
            Return Me.consumo
        End Get
        Set(ByVal value As Boolean)
            Me.consumo = value
        End Set
    End Property

    Property pImobilizado() As Boolean
        Get
            Return Me.imobilizado
        End Get
        Set(ByVal value As Boolean)
            Me.imobilizado = value
        End Set
    End Property

    Property pServico() As Boolean
        Get
            Return Me.servico
        End Get
        Set(ByVal value As Boolean)
            Me.servico = value
        End Set
    End Property

    Property pInativo() As Boolean
        Get
            Return Me.inativo
        End Get
        Set(ByVal value As Boolean)
            Me.inativo = value
        End Set
    End Property

    Property pMateriaprima() As Boolean
        Get
            Return Me.materiaprima
        End Get
        Set(ByVal value As Boolean)
            Me.materiaprima = value
        End Set
    End Property

    Property pQtdxUnd() As Double
        Get
            Return Me.qtdxUnd
        End Get
        Set(ByVal value As Double)
            Me.qtdxUnd = value
        End Set
    End Property

    Property pBalanca() As String
        Get
            Return Me.balanca
        End Get
        Set(ByVal value As String)
            Me.balanca = value
        End Set
    End Property

    Property pPauta() As Double
        Get
            Return Me.pauta
        End Get
        Set(ByVal value As Double)
            Me.pauta = value
        End Set
    End Property

    Property pClasse() As String
        Get
            Return Me.classe
        End Get
        Set(ByVal value As String)
            Me.classe = value
        End Set
    End Property

    Property pTipo() As Integer
        Get
            Return Me.tipo
        End Get
        Set(ByVal value As Integer)
            Me.tipo = value
        End Set
    End Property

    Property pGrade() As String
        Get
            Return Me.grade
        End Get
        Set(ByVal value As String)
            Me.grade = value
        End Set
    End Property

    Property pDtinicialpromocao() As Date
        Get
            Return Me.dtinicialpromocao
        End Get
        Set(ByVal value As Date)
            Me.dtinicialpromocao = value
        End Set
    End Property

    Property pDtfinalpromocao() As Date
        Get
            Return Me.dtfinalpromocao
        End Get
        Set(ByVal value As Date)
            Me.dtfinalpromocao = value
        End Set
    End Property

    Property pDtinicialbonific() As Date
        Get
            Return Me.dtinicialbonific
        End Get
        Set(ByVal value As Date)
            Me.dtinicialbonific = value
        End Set
    End Property

    Property pDtfinalbonific() As Date
        Get
            Return Me.dtfinalbonific
        End Get
        Set(ByVal value As Date)
            Me.dtfinalbonific = value
        End Set
    End Property

    Property pQuotaPromocao() As Double
        Get
            Return Me.quotapromocao
        End Get
        Set(ByVal value As Double)
            Me.quotapromocao = value
        End Set
    End Property

    Property pBonificquantidade() As Boolean
        Get
            Return Me.bonificquantidade
        End Get
        Set(ByVal value As Boolean)
            Me.bonificquantidade = value
        End Set
    End Property

    Property pBonificvalor() As Boolean
        Get
            Return Me.bonificvalor
        End Get
        Set(ByVal value As Boolean)
            Me.bonificvalor = value
        End Set
    End Property

    Property pQtdebonifcliente() As Integer
        Get
            Return Me.qtdebonifcliente
        End Get
        Set(ByVal value As Integer)
            Me.qtdebonifcliente = value
        End Set
    End Property

    Property pOrigem() As Int16
        Get
            Return Me.origem
        End Get
        Set(ByVal value As Int16)
            Me.origem = value
        End Set
    End Property

    Property pAplicacao() As String
        Get
            Return Me.aplicacao
        End Get
        Set(ByVal value As String)
            Me.aplicacao = value
        End Set
    End Property

    Property pCstIpi() As String
        Get
            Return Me.cstipi
        End Get
        Set(ByVal value As String)
            Me.cstipi = value
        End Set
    End Property

    Property pProdut3() As String
        Get
            Return Me.produt3
        End Get
        Set(ByVal value As String)
            Me.produt3 = value
        End Set
    End Property

    Property pIdImagem() As Int64
        Get
            Return Me.idImagem
        End Get
        Set(ByVal value As Int64)
            Me.idImagem = value
        End Set
    End Property

#End Region


End Class
