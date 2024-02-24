Public Class Cl_Agendamento1

    Public a_id, a_iddoutor As Int64
    Public a_codig, a_doutor, a_usuario, a_usuarioAlt, a_turno, a_info, a_paciente As String
    Public a_dtemis, a_dtagend As Date
    Public a_status, a_cancelado As Boolean
    Public a_valor As Double

    Sub New()

        Me.a_id = 0 : Me.a_iddoutor = 0 : Me.a_codig = "" : Me.a_doutor = ""
        Me.a_dtemis = Nothing : Me.a_dtagend = Nothing : Me.a_status = False
        Me.a_valor = 0.0 : Me.a_cancelado = False : Me.a_usuario = "" : Me.a_usuarioAlt = ""
        Me.a_turno = "" : Me.a_info = "" : Me.a_paciente = ""
    End Sub

    Sub New(Id As Int64, IdDoutor As Int64, Codig As String, Doutor As String, DtEmiss As Date, DtAgend As Date, Status As Boolean, _
            Valor As Double, Cancelado As Boolean, Usuario As String, UsuarioAlt As String, Turno As String, Info As String, Paciente As String)

        Me.a_id = Id : Me.a_iddoutor = IdDoutor : Me.a_codig = Codig : Me.a_doutor = Doutor
        Me.a_dtemis = DtEmiss : Me.a_dtagend = DtAgend : Me.a_status = Status
        Me.a_valor = Valor : Me.a_cancelado = Cancelado : Me.a_usuario = Usuario : Me.a_usuarioAlt = UsuarioAlt
        Me.a_turno = Turno : Me.a_info = Info : Me.a_paciente = Paciente
    End Sub

    Public Sub ZeraValores()

        Me.a_id = 0 : Me.a_iddoutor = 0 : Me.a_codig = "" : Me.a_doutor = ""
        Me.a_dtemis = Nothing : Me.a_dtagend = Nothing : Me.a_status = False
        Me.a_valor = 0.0 : Me.a_cancelado = False : Me.a_usuario = "" : Me.a_usuarioAlt = ""
        Me.a_turno = "" : Me.a_info = "" : Me.a_paciente = ""
    End Sub

End Class
