Public Class Cl_CaixaDiario

    Public cx_id, cx_iddoutor, cx_tpatend_id As Int64
    Public cx_tipo, cx_grupo, cx_descricao, cx_usu, cx_status, cx_loja, cx_caixa, cx_hora, cx_codcli, cx_nomecli, cx_doutor, cx_usuarioalt, cx_idduplreceb As String
    Public cx_tipopag, cx_protetico, cx_driniciais, cx_tpatend As String
    Public cx_data As Date
    Public cx_valor, cx_comissdoutor As Double
    Public cx_confirmar, cx_recebido, cx_orcamento As Boolean
    Public cx_doutor_old As String


    Sub New()

        'Inteiros:
        Me.cx_id = 0 : Me.cx_iddoutor = 0 : Me.cx_tpatend_id = 0
        'Strings:
        Me.cx_tipo = "" : Me.cx_grupo = "" : Me.cx_descricao = "" : Me.cx_usu = "" : Me.cx_status = "" : Me.cx_loja = "" : Me.cx_caixa = ""
        Me.cx_hora = "" : Me.cx_codcli = "" : Me.cx_nomecli = "" : Me.cx_doutor = "" : Me.cx_usuarioalt = "" : Me.cx_idduplreceb = ""
        Me.cx_tipopag = "DN" : Me.cx_protetico = "" : Me.cx_driniciais = "" : Me.cx_doutor_old = "" : Me.cx_tpatend = ""
        'Reais:
        Me.cx_valor = 0.0 : Me.cx_comissdoutor = 0.0
        'Boolean:
        Me.cx_confirmar = False : Me.cx_recebido = False : Me.cx_orcamento = False

    End Sub

    Public Sub ZeraValores()

        'Inteiros:
        Me.cx_id = 0 : Me.cx_iddoutor = 0 : Me.cx_tpatend_id = 0
        'Strings:
        Me.cx_tipo = "" : Me.cx_grupo = "" : Me.cx_descricao = "" : Me.cx_usu = "" : Me.cx_status = "" : Me.cx_loja = "" : Me.cx_caixa = ""
        Me.cx_hora = "" : Me.cx_codcli = "" : Me.cx_nomecli = "" : Me.cx_doutor = "" : Me.cx_usuarioalt = "" : Me.cx_idduplreceb = ""
        Me.cx_tipopag = "DN" : Me.cx_protetico = "" : Me.cx_driniciais = "" : Me.cx_doutor_old = "" : Me.cx_tpatend = ""
        'Reais:
        Me.cx_valor = 0.0 : Me.cx_comissdoutor = 0.0
        'Boolean:
        Me.cx_confirmar = False : Me.cx_recebido = False : Me.cx_orcamento = False

    End Sub

End Class
