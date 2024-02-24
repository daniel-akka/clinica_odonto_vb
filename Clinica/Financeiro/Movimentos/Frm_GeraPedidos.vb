Imports System.Drawing.Printing
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Data.DataColumnCollection
Imports System.Data.DataRow
Imports System.Xml
Imports System.Xml.Xsl
Imports Npgsql

Public Class Frm_GeraPedidos
   
    'Protected Const conexao As String = _
    ' "Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDGENOV"
    Dim mMxml As New GenoNFeXml
    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click
        Me.Close()
    End Sub

    Private Sub Frm_GeraPedidos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
        If (e.KeyCode = Keys.F2) Then
            ' Venda no Pedido 
            Dim Formped As New Frm_PedidoProtaEntrega
            Formped.Show()
        End If
        If (e.KeyCode = Keys.F3) Then
            ' Altera Pedido 
        End If
        If (e.KeyCode = Keys.F4) Then
            ' Exclui Pedido 
        End If
    End Sub

    Private Sub btn_novo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btn_novo.KeyDown
        Me.Close()
    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click
        Dim Formped As New Frm_PedidoProtaEntrega
        Formped.Show()
    End Sub

    Private Sub btn_boleto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_boleto.Click
       
        
    End Sub

    
    Private Sub Frm_GeraPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New Npgsql.NpgsqlConnection(ModuloConexaoBD.conectionPadrao)
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Sqlcomm.Append("Select n1.nt_orca AS ""Pedido"",n1.nt_dtemis AS ""Emissão"",n1.nt_codig AS ""Codigo"",cad.p_portad AS ""Cliente"",cad.p_cid AS ""Cidade"",cad.p_uf AS ""UF"" ,n4.n4_tgeral AS ""Valor R$"",n1.nt_tipo2 AS ""Tipo"",n1.nt_vend AS ""Vendedor"" ")
        Sqlcomm.Append("from orca1pp n1, cadp001 cad, orca4dd n4 where n1.nt_codig=cad.p_cod and n4.n4_nume=n1.nt_orca order by n1.nt_dtemis ")
        Sqlcomm.Append("desc limit 24")
        
        Dim daPed As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
        Dim dsPed As DataSet = New DataSet()

        Try
            'configurajanelaProdPesq()
            daPed.Fill(dsPed, "Orca1pp")
            conn.Open()

            Me.dtg_pedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            Me.dtg_pedidos.DataSource = dsPed.Tables("Orca1pp").DefaultView
            Me.dtg_pedidos.AllowUserToResizeColumns = False
            Me.dtg_pedidos.AllowUserToResizeRows = False
            Me.dtg_pedidos.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
            Me.dtg_pedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            Me.dtg_pedidos.Columns(6).DefaultCellStyle.Format = "###,##0.00"
            Me.dtg_pedidos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            conn.Close()
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class