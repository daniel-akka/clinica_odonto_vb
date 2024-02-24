Public Class Cl_CxOrcamento

    Public oc_id, oc_iddoutor As Int64
    Public oc_descricao, oc_usu, oc_status, oc_loja, oc_caixa, oc_hora, oc_codcli, oc_nomecli, oc_doutor, oc_usuarioalt As String
    Public oc_protetico, oc_driniciais As String
    Public oc_data As Date
    Public oc_valor As Double

    Public DAO As New Cl_CxOrcamentoDAO

    Sub New()

        'Inteiros:
        Me.oc_id = 0 : Me.oc_iddoutor = 0
        'Strings:
        Me.oc_descricao = "" : Me.oc_usu = "" : Me.oc_status = "" : Me.oc_loja = "" : Me.oc_caixa = ""
        Me.oc_hora = "" : Me.oc_codcli = "" : Me.oc_nomecli = "" : Me.oc_doutor = "" : Me.oc_usuarioalt = ""
        Me.oc_protetico = "" : Me.oc_driniciais = ""
        'Reais:
        Me.oc_valor = 0.0

    End Sub

    Public Sub ZeraValores()

        'Inteiros:
        Me.oc_id = 0 : Me.oc_iddoutor = 0
        'Strings:
        Me.oc_descricao = "" : Me.oc_usu = "" : Me.oc_status = "" : Me.oc_loja = "" : Me.oc_caixa = ""
        Me.oc_hora = "" : Me.oc_codcli = "" : Me.oc_nomecli = "" : Me.oc_doutor = "" : Me.oc_usuarioalt = ""
        Me.oc_protetico = "" : Me.oc_driniciais = ""
        'Reais:
        Me.oc_valor = 0.0

    End Sub

End Class
