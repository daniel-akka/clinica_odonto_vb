﻿Public Class Cl_NFeSaida

    Private nt1pp As Cl_Nota1pp
    Private nt2cc As Cl_Nota2cc
    Private nt4dd As Cl_Nota4dd
    Private nt5tt As Cl_Nota5tt
    Private nt6hh As Cl_Nota6hh

    Private res01 As Cl_ResN4dd01
    Private res02 As Cl_ResN4dd02
    Private res03 As Cl_ResN4dd03

    Public notaref() As GenoNFeXml.Cl_notaref
    Public cliTranportador As Cl_Cadp001
    Public dtgItensResumo As DataGridView
    'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
    'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14


    Public Sub New()
        Me.nt1pp = New Cl_Nota1pp
        Me.nt2cc = New Cl_Nota2cc
        Me.nt4dd = New Cl_Nota4dd
        Me.nt5tt = New Cl_Nota5tt
        Me.nt6hh = New Cl_Nota6hh

        Me.res01 = New Cl_ResN4dd01
        Me.res02 = New Cl_ResN4dd02
        Me.res03 = New Cl_ResN4dd03

        Me.cliTranportador = New Cl_Cadp001
        Me.dtgItensResumo = New DataGridView
    End Sub

    Public Sub New(ByVal mNt1pp As Cl_Nota1pp, ByVal mNt2cc As Cl_Nota2cc, ByVal mNt4dd As Cl_Nota4dd, ByVal mNt5tt As Cl_Nota5tt, _
                   ByVal mNt6hh As Cl_Nota6hh, ByVal mRes01 As Cl_ResN4dd01, ByVal mRes02 As Cl_ResN4dd02, ByVal mRes03 As Cl_ResN4dd03)

        Me.nt1pp = mNt1pp : Me.nt2cc = mNt2cc : Me.nt4dd = mNt4dd : Me.nt5tt = mNt5tt : Me.nt6hh = mNt6hh

        Me.res01 = mRes01 : Me.res02 = mRes02 : Me.res03 = mRes03 : Me.cliTranportador = New Cl_Cadp001 : Me.dtgItensResumo = New DataGridView
    End Sub

    Public Sub zeraValores()

        Me.nt1pp = Nothing : Me.nt2cc = Nothing : Me.nt4dd = Nothing : Me.nt5tt = Nothing : Me.nt6hh = Nothing
        Me.res01 = Nothing : Me.res02 = Nothing : Me.res03 = Nothing : Me.dtgItensResumo = Nothing

        Me.nt1pp = New Cl_Nota1pp : Me.nt2cc = New Cl_Nota2cc : Me.nt4dd = New Cl_Nota4dd : Me.nt5tt = New Cl_Nota5tt : Me.nt6hh = New Cl_Nota6hh
        Me.res01 = New Cl_ResN4dd01 : Me.res02 = New Cl_ResN4dd02 : Me.res03 = New Cl_ResN4dd03
        Me.cliTranportador = New Cl_Cadp001 : Me.dtgItensResumo = New DataGridView
    End Sub

    Public Sub zeraValoresLote()

        Me.nt1pp = Nothing : Me.nt2cc = Nothing : Me.nt4dd = Nothing : Me.nt5tt = Nothing : Me.nt6hh = Nothing
        Me.res01 = Nothing : Me.res02 = Nothing : Me.res03 = Nothing

        Me.nt1pp = New Cl_Nota1pp : Me.nt2cc = New Cl_Nota2cc : Me.nt4dd = New Cl_Nota4dd : Me.nt5tt = New Cl_Nota5tt : Me.nt6hh = New Cl_Nota6hh
        Me.res01 = New Cl_ResN4dd01 : Me.res02 = New Cl_ResN4dd02 : Me.res03 = New Cl_ResN4dd03
        Me.cliTranportador = New Cl_Cadp001

        Try
            Me.dtgItensResumo.Rows.Clear() : Me.dtgItensResumo.Refresh()
        Catch ex As Exception
        End Try

    End Sub

    Public Property pNt1pp() As Cl_Nota1pp
        Get
            Return Me.nt1pp
        End Get
        Set(ByVal value As Cl_Nota1pp)

            Try
                Me.nt1pp = value
            Catch ex As Exception
                MdlERRO.msgErro("Erro ao Setar o atributo ""nt1pp"" da Classe ""NFe Saida"" ::" & ex.Message)
            End Try
        End Set
    End Property

    Public Property pNt2cc() As Cl_Nota2cc
        Get
            Return Me.nt2cc
        End Get
        Set(ByVal value As Cl_Nota2cc)

            Try
                Me.nt2cc = value
            Catch ex As Exception
                MdlERRO.msgErro("Erro ao Setar o atributo ""nt2cc"" da Classe ""NFe Saida"" ::" & ex.Message)
            End Try
        End Set
    End Property

    Public Property pNt4dd() As Cl_Nota4dd
        Get
            Return Me.nt4dd
        End Get
        Set(ByVal value As Cl_Nota4dd)

            Try
                Me.nt4dd = value
            Catch ex As Exception
                MdlERRO.msgErro("Erro ao Setar o atributo ""nt4dd"" da Classe ""NFe Saida"" ::" & ex.Message)
            End Try
        End Set
    End Property

    Public Property pNt5tt() As Cl_Nota5tt
        Get
            Return Me.nt5tt
        End Get
        Set(ByVal value As Cl_Nota5tt)

            Try
                Me.nt5tt = value
            Catch ex As Exception
                MdlERRO.msgErro("Erro ao Setar o atributo ""nt5tt"" da Classe ""NFe Saida"" ::" & ex.Message)
            End Try
        End Set
    End Property

    Public Property pNt6hh() As Cl_Nota6hh
        Get
            Return Me.nt6hh
        End Get
        Set(ByVal value As Cl_Nota6hh)

            Try
                Me.nt6hh = value
            Catch ex As Exception
                MdlERRO.msgErro("Erro ao Setar o atributo ""nt6hh"" da Classe ""NFe Saida"" ::" & ex.Message)
            End Try
        End Set
    End Property

    Public Property pRes01() As Cl_ResN4dd01
        Get
            Return Me.res01
        End Get
        Set(ByVal value As Cl_ResN4dd01)

            Try
                Me.res01 = value
            Catch ex As Exception
                MdlERRO.msgErro("Erro ao Setar o atributo ""res01"" da Classe ""NFe Saida"" ::" & ex.Message)
            End Try
        End Set
    End Property

    Public Property pRes02() As Cl_ResN4dd02
        Get
            Return Me.res02
        End Get
        Set(ByVal value As Cl_ResN4dd02)

            Try
                Me.res02 = value
            Catch ex As Exception
                MdlERRO.msgErro("Erro ao Setar o atributo ""res02"" da Classe ""NFe Saida"" ::" & ex.Message)
            End Try
        End Set
    End Property

    Public Property pRes03() As Cl_ResN4dd03
        Get
            Return Me.res03
        End Get
        Set(ByVal value As Cl_ResN4dd03)

            Try
                Me.res03 = value
            Catch ex As Exception
                MdlERRO.msgErro("Erro ao Setar o atributo ""res03"" da Classe ""NFe Saida"" ::" & ex.Message)
            End Try
        End Set
    End Property

End Class
