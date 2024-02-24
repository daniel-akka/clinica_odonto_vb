Public Class Cl_NFeEntrada

    Private nt4ff As Cl_Nota4ff
    Private nt2ff As Cl_Nota2ff

    Public Property pNt4ff() As Cl_Nota4ff
        Get
            Return Me.nt4ff
        End Get
        Set(ByVal value As Cl_Nota4ff)

            Try
                Me.nt4ff = value
            Catch ex As Exception
                MsgBox("Erro ao Setar o atributo ""nt4ff"" da Classe ""NFe Entrada"" ::" & ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End Set
    End Property

    Public Property pNt2ff() As Cl_Nota2ff
        Get
            Return Me.nt2ff
        End Get
        Set(ByVal value As Cl_Nota2ff)

            Try
                Me.nt2ff = value
            Catch ex As Exception
                MsgBox("Erro ao Setar o atributo ""nt2ff"" da Classe ""NFe Entrada"" ::" & ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End Set
    End Property

End Class
