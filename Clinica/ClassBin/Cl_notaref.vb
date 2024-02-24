Public Class Cl_notaref
    Public refid As Int64, refnumero, reftipo, refchave, refcoduf, refaamm, refcnpj, refmod, refserie, refecf, refcoo, nt1pp As String

    Sub New()
        Me.refid = 0 : Me.refnumero = "" : Me.reftipo = "" : Me.refchave = "" : Me.refcoduf = "" : Me.refaamm = ""
        Me.refcnpj = "" : Me.refmod = "" : Me.refserie = "" : Me.refecf = "" : Me.refcoo = "" : Me.nt1pp = ""
    End Sub

    Sub New(id As Int64, numero As String, tipo As String, chave As String, coduf As String, aamm As String, cnpj As String, _
            rmod As String, serie As String, ecf As String, coo As String, Optional ByVal nt_numer As String = "")
        Me.refid = id : Me.refnumero = numero : Me.reftipo = tipo : Me.refchave = chave : Me.refcoduf = coduf : Me.refaamm = aamm
        Me.refcnpj = cnpj : Me.refmod = rmod : Me.refserie = serie : Me.refecf = ecf : Me.refcoo = coo : Me.nt1pp = nt_numer
    End Sub


    ' #####    INFORMAÇÕES !

    'reftipo:
    'NFe; CTe; 01/1A; CP

    'refmod:
    'No caso de cupom:
    '"2B", quando se tratar de Cupom Fiscal emitido por máquina registradora (não ECF),
    '"2C", quando se tratar de Cupom Fiscal PDV;
    '"2D", quando se tratar de Cupom Fiscal (emitido por ECF)';


End Class
