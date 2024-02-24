Imports System.Windows.Forms
Imports System.IO
Imports System.Data.OleDb
Imports MetroSys
Imports Npgsql

Public Class Form_importaProdutos

    Dim Ximp As New Cl_bdMetrosys
    Protected Const conexao As String = _
    "Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDGENOV"
    Dim msub() As String = {"00", "10", "20", "30", "40", "41", "50", "51", "60", "70", "90"}


    Private Sub btn_iniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_iniciar.Click
        ' Variaveis p/ Exportação
        ' 00 - Trib. Integral
        ' 10 - Trib. Icms/Subst.
        ' 20 - Com Redução
        ' 30 - Isenta /Não Trib.
        ' 40 - Isenta
        ' 41 - Não Tributada
        ' 51 - Diferimento
        ' 60 - ICMS Substituto
        ' 70 - Redução e Icms p/ Subst.
        ' 90 - Outros
        Dim t, x As Integer
        Dim strarr() As String
        Dim vForn As String
        Dim Vsub(11) As String
        Dim vcod As Integer
        Dim vcodbar As String
        Dim vProduto As String = Space(50)
        Dim mProduto As String = Space(50)
        Dim vund, vEmbalagem, vDTcad As String
        Dim vQtunit, vVF, vQtdeund, vGrupo, vlinha As Integer
        Dim vpeso, vpreco, vpreco2 As Decimal
        Dim vCST, vCLF, vbalan, vPis As String
        ' Vsub(0) = "00"
        Vsub(1) = "00"
        Vsub(2) = "10"
        Vsub(3) = "20"
        Vsub(4) = "30"
        Vsub(5) = "40"
        Vsub(6) = "41"
        Vsub(7) = "50"
        Vsub(8) = "51"
        Vsub(9) = "60"
        Vsub(10) = "70"
        Vsub(11) = "90"

        Dim oConn As New OleDbConnection()
        oConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\demos\importa;Extended Properties=dBASE 5.0;"
        Dim dr As OleDbDataReader
        Dim xcont As Integer = 0
        Dim Mconsulta As Boolean = False
        oConn.Open()
        Dim oCmd As OleDbCommand = oConn.CreateCommand()
        oCmd.CommandText = "SELECT * FROM \demos\importa\ESTOQUE1.DBF "
        Dim dt As DataTable = New DataTable
        Dim mcomp As String = ""


        Try
            dt.Load(oCmd.ExecuteReader())
            dr = oCmd.ExecuteReader()
            While dr.Read()
                vcod = 0
                vcod = dr(0)
                vForn = dr(16)
                vcodbar = dr(3).ToString
                mProduto = dr(1).ToString
                vund = dr(5).ToString
                vEmbalagem = dr(2).ToString
                vPis = dr(12)
                If vPis = "" Or vPis = " " Then
                    vPis = "N"
                End If
                vbalan = "N"
                If vund = "KG" Then
                    vbalan = "S"
                End If
                vDTcad = Now
                vQtunit = dr(6)
                vQtdeund = dr(7)
                vVF = dr(11)  ' Tribut. 17% se = 1
                vCLF = "00"
                vCST = Vsub(1)
                If vVF = 2 Then
                    vVF = 1  ' Tribut. 12%
                    vCST = Vsub(1)
                    vCLF = "02"
                End If
                If vVF = 3 Then
                    vCST = Vsub(9)  ' Imposto pgoS
                    vCLF = "00"
                End If
                If vVF = 4 Then
                    vCST = Vsub(5) ' Isenta
                    vCLF = "00"
                End If
                If vVF = 5 Then
                    vVF = 1
                    vCST = Vsub(5)
                    vCLF = "05"  ' aliquota 25%
                End If
                If vVF > 5 Then
                    vVF = 1
                    vCST = Vsub(0)
                    vCLF = "00"  ' aliquota 25%
                End If
                vpeso = Convert.ToDouble(dr(8))
                vpreco = Convert.ToDouble(dr(15))
                vpreco2 = Convert.ToDouble(dr(15))
                'If Len(dr(1)) < 5 Then
                '    vbalan = "S"
                'End If
                vlinha = 0
                ' Eliminação de caracteres especiasi
                '
                strarr = mProduto.Split("º")
                For t = 0 To strarr.Length - 1
                    vProduto = strarr(t)  ' Posição do caracter Especial -1
                    Exit For
                Next
                xcont = xcont + 1
                x = Len(vProduto) ' Tamanho da string inicial
                vProduto = vProduto & Mid(mProduto, x + 2, Len(mProduto) - x) ' Concatena string
                Ximp.importProd(Convert.ToInt32(vcod), vcodbar, "00000", Mid(vProduto, 1, 49), vForn, vund, vEmbalagem, _
                    vCLF, vCST, vVF, vGrupo, vbalan, "A", Now, "N", 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, _
                    Convert.ToDecimal(dr(15)), 0.0, Convert.ToDecimal(dr(15)), 0.0, 0.0, 0.0, _
                    0.0, 0.0, 0.0, 0.0, Now, Now, Convert.ToInt32(vQtunit), Convert.ToInt32(vQtdeund), vPis, vlinha, conexao)

                lbl_contagem.Text = Format(Convert.ToInt32(xcont), "###,##0")
            End While
            lbl_mensagem.Text = "Fim de Exportação !"
        Catch ex As Exception
            lbl_mensagem.Text = ex.ToString
            MsgBox("Erro " & vcod & "-" & vProduto & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try
        oConn.Close()
        If Mconsulta = False Then
            'limpa_dados
            MessageBox.Show("Variavel de referencia Não Encontrada ", "Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click
        Me.Close()
    End Sub
End Class