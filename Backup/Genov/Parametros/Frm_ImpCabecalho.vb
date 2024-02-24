Imports System.Data
Imports System.Data.OleDb
Imports System.Text
Imports Npgsql
Imports system.IO


Public Class Frm_ImpCabecalho

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oConn As New OleDbConnection()
        Dim oDr As OleDbDataReader
        Dim C As New ClienteImport
        ' Variaveis para Importação :
        'Dim vnt_x, vnt_y, vnt_orca, vnt_geno, vnt_codig As String
        Dim vnt_portad, vnt_cid, vnt_vend, vnt_cfop, vnt_natureza As String
        Dim vnt_dtemis, vnt_dtsai As Date
        Dim vnt_emiss As Boolean
        Dim vnt_itens, vnt_cod1, vnt_cod2, vnt_cod3, vnt_cod4, vnt_rota As Integer
        Dim vnt_peso, vnt_volum, vnt_desc As Decimal
        Dim vnt_tipo2, vnt_usuario, vnt_supervisor, vnt_auto2, vnt_obs As String
        oConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\dados;Extended Properties=dBASE IV;"
        oConn.Open()
        Dim oCmd As OleDbCommand = oConn.CreateCommand()
        oCmd.CommandText = "SELECT * FROM c:\dados\orca1pp.dbf"
        Dim dt As New DataTable()

        ' *********************************************************
        ' *    Rotina para Recebimento dos Dados em PostgreSql    *
        ' *********************************************************
        Dim Conex As NpgsqlConnection
        Dim oDa As NpgsqlDataAdapter
        Dim oCmdB As NpgsqlCommandBuilder
        Dim cmd As NpgsqlCommand
        Dim tbGeno As New DataTable
        Conex = New NpgsqlConnection("Server=localhost;Port=5432;UserId=postgres;Password=servnet;Database=SBDGENOV")
        Dim msql As StringBuilder = New StringBuilder

        ' ** Criando String SQL para inserção no Banco **
        msql.Append("INSERT INTO tb_orca1pp(nt_x, nt_y, nt_orca, nt_geno, nt_codig, nt_portad,")
        msql.Append("nt_cid, nt_vend,nt_dtemis, nt_dtsai, nt_emiss, nt_cfop, nt_natureza,")
        msql.Append("nt_itens, nt_rota, nt_peso, nt_cod1,nt_cod2, nt_cod3, nt_cod4, nt_volum,")
        msql.Append("nt_tipo2, nt_desc, nt_usuario, nt_supervisor, nt_auto2, nt_obs)")
        msql.Append("VALUES (@nt_x,@nt_y,@nt_orca,@nt_geno,@nt_codig,@nt_portad,")
        msql.Append("@nt_cid, @nt_vend,@nt_dtemis, @nt_dtsai, @nt_emiss, @nt_cfop, @nt_natureza,")
        msql.Append("@nt_itens, @nt_rota, @nt_peso, @nt_cod1,@nt_cod2, @nt_cod3, @nt_cod4, @nt_volum,")
        msql.Append("@nt_tipo2, @nt_desc, @nt_usuario, @nt_supervisor, @nt_auto2, @nt_obs)")

        '   "Parametrizando comandos/variaveis"
        cmd = New NpgsqlCommand(msql.ToString, Conex)
        cmd.Parameters.Add("@nt_x", C.nt_x.ToString)
        cmd.Parameters.Add("@nt_y", C.nt_y.ToString)
        cmd.Parameters.Add("@nt_x", C.nt_orca.ToString)
        cmd.Parameters.Add("@nt_geno", C.nt_geno.ToString)
        cmd.Parameters.Add("@nt_codig", C.nt_codig.ToString)
        cmd.Parameters.Add("@nt_portad", vnt_portad.ToString)
        cmd.Parameters.Add("@nt_cid", vnt_cid.ToString)
        cmd.Parameters.Add("@nt_vend", vnt_vend.ToString)
        cmd.Parameters.Add("@nt_dtemis", vnt_dtemis.ToString)
        cmd.Parameters.Add("@nt_dtsai", vnt_dtsai.ToString)
        cmd.Parameters.Add("@nt_emiss", vnt_emiss)
        cmd.Parameters.Add("@nt_cfop", vnt_cfop.ToString)
        cmd.Parameters.Add("@nt_natureza", vnt_natureza.ToString)
        cmd.Parameters.Add("@nt_itens", vnt_itens.ToString)
        cmd.Parameters.Add("@nt_rota", vnt_rota.ToString)
        cmd.Parameters.Add("@nt_peso", vnt_peso.ToString)
        cmd.Parameters.Add("@nt_cod1", vnt_cod1.ToString)
        cmd.Parameters.Add("@nt_cod2", vnt_cod2.ToString)
        cmd.Parameters.Add("@nt_cod3", vnt_cod3.ToString)
        cmd.Parameters.Add("@nt_cod4", vnt_cod4.ToString)
        cmd.Parameters.Add("@nt_volum", vnt_volum.ToString)
        cmd.Parameters.Add("@nt_tipo2", vnt_tipo2.ToString)
        cmd.Parameters.Add("@nt_desc", vnt_desc.ToString)
        cmd.Parameters.Add("@nt_usuario", vnt_usuario.ToString)
        cmd.Parameters.Add("@nt_supervisor", vnt_supervisor.ToString)
        cmd.Parameters.Add("@nt_auto2", vnt_auto2.ToString)
        cmd.Parameters.Add("@nt_obs", vnt_obs.ToString)


        ' http://www.macoratti.net/vbn_prn2.htm
        dt.Load(oCmd.ExecuteReader())
        Try
            While oDr.Read()

                cmd.ExecuteNonQuery()
            End While

        Catch erro As Exception
            MsgBox("Erro " & vbCrLf & erro.ToString, MsgBoxStyle.Critical, "Erro")

        End Try
        oConn.Close()

        'DataGridView1.DataSource = dt
    End Sub
End Class