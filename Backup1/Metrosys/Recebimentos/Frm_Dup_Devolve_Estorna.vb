Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.DateTime
Imports System.Math
Imports Npgsql
Public Class Frm_Dup_Devolve_Estorna

    Dim agora As Date = Now
    Dim mSituacao, mSit As String
    '  Protected Const conexao As String = _
    '"Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDMETROSYS"


    Private Sub Frm_Dup_Devolve_Estorna_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Close()
    End Sub

    Private Sub Frm_Dup_Devolve_Estorna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Dup_Devolve_Estorna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.msk_data.Text = agora
        Me.txt_valor.Text = "0,00"
    End Sub

    Private Sub btn_registrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_registrar.Click
        If Me.txt_documento.Text = "" Then
            MessageBox.Show("Digit o Numero p/ Documento !", "Estorno ou Devolução ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_documento.Focus()
        ElseIf cbo_tipo.SelectedIndex = -1 Then
            MessageBox.Show("Selecione um Tipo p/ Documento !", "Estorno ou Devolução ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_documento.Focus()
        End If
        If mSit = "L" Then
            '  0- Estorno 1- Devolução
            If cbo_tipo.SelectedIndex = 1 Then
                MessageBox.Show("Seleção Invalida, Documento não pode ser Devolvido !", "Erro no Tipo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                cbo_tipo.Focus()
                Return
            End If
        ElseIf mSit = "D" Then
            If cbo_tipo.SelectedIndex = 0 Then
                MessageBox.Show("Seleção Invalida, Documento não pode ser Estornado !", "Erro no Tipo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                cbo_tipo.Focus()
                Return
            End If
        End If
        If cbo_tipo.SelectedIndex = 0 Then
            Estorno_Dev_Dup(Me.txt_documento.Text, 0)
            MessageBox.Show("Estorno Efetivado !", "Estorno", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf cbo_tipo.SelectedIndex = 1 Then
            Estorno_Dev_Dup(Me.txt_documento.Text, 1)
            MessageBox.Show("DEvolução Efetivada !", "DEvolução", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Estorno_Dev_Dup(ByVal mDocumento As String, ByVal IndiceX As Integer)
        ' UPDATE fatd001 SET f_dtpaga=?, f_juros=?, f_desc=?,  f_hist=?, f_hvenc=?, f_sit=? 
        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim oCmd As NpgsqlCommand
        Dim Desconto, Juros As Double
        Dim Mconsulta As Boolean = False

        Dim strSQL As New StringBuilder
        Try
            strSQL.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".fatd001 SET ")
            strSQL.Append("f_dtpaga=default, f_juros=@f_juros, f_desc=@f_desc, f_sit=@f_sit ")
            strSQL.Append("WHERE f_duplic='" & mDocumento.ToString & "' and f_geno='G00" & cbo_loja.SelectedItem & "'")

            oCmd = New NpgsqlCommand(strSQL.ToString, oConn)
            Juros = 0.0 : Desconto = 0.0

            ' oCmd.Parameters.Add("@f_dtpaga", "")
            oCmd.Parameters.Add("@f_juros", Juros)
            oCmd.Parameters.Add("@f_desc", Desconto)
            If IndiceX = 0 Then
                oCmd.Parameters.Add("@f_sit", "N".ToString)
            Else
                oCmd.Parameters.Add("@f_sit", "D".ToString)
            End If

            oConn.Open()
            oCmd.CommandText = strSQL.ToString
            oCmd.ExecuteNonQuery()
            oConn.Close()
        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try
    End Sub

    Private Sub txt_documento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_documento.GotFocus
        If cbo_loja.SelectedIndex = -1 Then
            MessageBox.Show("Selecione uma Loja !", " Seleção Loja ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_loja.Focus()
        End If
    End Sub

    Private Sub txt_documento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_documento.Leave
        If txt_documento.Text <> "" Then
            Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim Sqlcomm As StringBuilder = New StringBuilder
            Dim DrDup As NpgsqlDataReader

            Sqlcomm.Append("Select F.f_geno,F.f_duplic,F.f_valor,F.f_portad,C.p_portad,C.p_cod ,F.f_vencto, F.f_sit from " & MdlEmpresaUsu._esqEstab & ".fatd001 F, Cadp001 C where ") '5
            Sqlcomm.Append("F.f_duplic='" & Me.txt_documento.Text & "' and F.f_portad=C.p_cod and F.f_geno='G00" & cbo_loja.SelectedItem & "'")
            Dim daDup As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
            Dim dsDup As DataSet = New DataSet()

            Dim cmd As NpgsqlCommand = New NpgsqlCommand(Sqlcomm.ToString, conn)
            cmd.CommandText = Sqlcomm.ToString
            Dim dtDup As DataTable = New DataTable

            Dim mdif, mJurosdia As Double

            Try
                conn.Open()
                dtDup.Load(cmd.ExecuteReader())    ' Carrega o datatable para memoria
                DrDup = cmd.ExecuteReader          ' Executa leitura do commando
                While (DrDup.Read())
                    Me.txt_portad.Text = DrDup(4).ToString
                    Me.txt_valor.Text = Format(CDbl(DrDup(2)), "##,##0.00")
                    Me.msk_vencto.Text = DrDup(6)
                    mSit = DrDup(7).ToString
                    If mSit = "N" Then mSituacao = "Normal"
                    If mSit = "D" Then mSituacao = "Devolvida"
                    If mSit = "L" Then mSituacao = "Liquidada"
                    Me.lbl_situacao.Text = mSituacao

                End While
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        Else
            MessageBox.Show("Digite Numero do Documento ", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txt_documento.Focus()

        End If
    End Sub
End Class