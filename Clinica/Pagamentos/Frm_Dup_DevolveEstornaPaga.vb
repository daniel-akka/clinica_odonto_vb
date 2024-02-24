Imports System.Windows.Forms.OpenFileDialog
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.DateTime
Imports System.Math
Imports Npgsql

Public Class Frm_Dup_DevolveEstornaPaga

    Dim agora As Date = Now
    Dim mSituacao, mSit As String
    Dim _clFuncoes As New ClFuncoes
    Dim _clBD As New Cl_bdMetrosys
    Dim _geno001 As New Cl_Geno


    Private Sub Frm_Dup_DevolveEstornaPaga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Close()
    End Sub

    Private Sub Frm_Dup_DevolveEstornaPaga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Dup_DevolveEstornaPaga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.msk_data.Text = agora
        Me.txt_valor.Text = "0,00"
        cbo_loja = _clFuncoes.PreenchComboLoja5Dig(cbo_loja, MdlConexaoBD.conectionPadrao)
        cbo_loja.SelectedIndex = _clFuncoes.trazIndexCboLoja5dig(MdlEmpresaUsu._codigo, cbo_loja)
        Try
            If cbo_loja.SelectedIndex > -1 Then txt_documento.Focus()
        Catch ex As Exception
        End Try

    End Sub

    Function ValidaCampos() As Boolean

        If cbo_loja.SelectedIndex < 0 Then
            MessageBox.Show("Selecione uma LOJA !", "Estorno ou Devolução ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_loja.Focus() : Return False
        End If

        If Me.txt_documento.Text.Equals("") Then
            MessageBox.Show("Digit o NUMERO p/ Documento !", "Estorno ou Devolução ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_documento.Focus() : Return False
        End If

        If cbo_tipo.SelectedIndex < 0 Then
            MessageBox.Show("Selecione um TIPO p/ Documento !", "Estorno ou Devolução ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_tipo.Focus() : Return False
        End If

        If IsDate(msk_data.Text) = False Then
            MessageBox.Show("Informe uma DATA p/ Documento !", "Estorno ou Devolução ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.msk_data.Focus() : Return False
        End If

        Return True
    End Function

    Function DescrSit(ByVal mSituacao As String) As String

        Select Case mSituacao
            Case "L"
                Return "Liquidado"
            Case "E"
                Return "Estornado"
            Case "D"
                Return "Devolvido"
            Case "N"
                Return "Normal"
        End Select

        Return ""
    End Function

    Private Sub btn_registrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_registrar.Click

        If ValidaCampos() = False Then Return

        Select Case mSit
            Case "L", "E", "D"

                '0- Estorno 1- Devolução
                If cbo_tipo.SelectedIndex = 1 Then
                    MessageBox.Show("Documento """ & DescrSit(mSit) & """ não pode ser Devolvido! ", "Erro no Tipo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    cbo_tipo.Focus() : Return
                Else

                    If mSit <> "L" Then
                        MessageBox.Show("Documento """ & DescrSit(mSit) & """ não pode ser Estornado! ", "Erro no Tipo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        cbo_tipo.Focus() : Return
                    End If
                End If

        End Select


        Select Case cbo_tipo.SelectedIndex
            Case 0
                Estorno_Dev_Dup(Me.txt_documento.Text, 0)
                MessageBox.Show("Estorno Efetivado !", "Estorno", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

            Case 1
                Estorno_Dev_Dup(Me.txt_documento.Text, 1)
                MessageBox.Show("Devolução Efetivada !", "DEvolução", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

        End Select

    End Sub

    Private Sub Estorno_Dev_Dup(ByVal mDocumento As String, ByVal IndiceX As Integer)

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim oCmd As NpgsqlCommand
        Dim Desconto, Juros As Double
        Dim Mconsulta As Boolean = False
        Dim strSQL As New StringBuilder

        Try

            strSQL.Append("UPDATE fatp001 SET ")
            strSQL.Append("d_dtpaga=@d_dtpaga, d_juros=@d_juros, d_desc=@d_desc, d_sit=@d_sit, d_sitanterior = @d_sitanterior ")
            strSQL.Append("WHERE d_duplic='" & mDocumento.ToString & "' and d_geno='" & _geno001.pCodig & "'")

            oCmd = New NpgsqlCommand(strSQL.ToString, oConn)
            Juros = 0.0 : Desconto = 0.0

            oCmd.Parameters.Add("@d_dtpaga", Convert.ChangeType(MdlConexaoBD.dataServidor, GetType(Date)))
            oCmd.Parameters.Add("@d_juros", Juros)
            oCmd.Parameters.Add("@d_desc", Desconto)
            oCmd.Parameters.Add("@d_sitanterior", mSit)
            If IndiceX = 0 Then
                oCmd.Parameters.Add("@d_sit", "E")
            Else
                oCmd.Parameters.Add("@d_sit", "D")
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

        If cbo_loja.SelectedIndex < 0 Then
            MessageBox.Show("Selecione uma Loja !", " Seleção Loja ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_loja.Focus()
        End If

    End Sub

    Private Sub txt_documento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_documento.Leave

        If txt_documento.Text.Equals("") = False Then

            Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim Sqlcomm As StringBuilder = New StringBuilder
            Dim DrDup As NpgsqlDataReader

            Sqlcomm.Append("Select F.d_geno,F.d_duplic,F.d_valor,F.d_portad,C.p_portad,C.p_cod ,F.d_vencto, F.d_sit FROM fatp001 F, Cadp001 C WHERE ") '5
            Sqlcomm.Append("F.d_duplic='" & Me.txt_documento.Text & "' AND F.d_portad=C.p_cod AND F.d_geno='" & _geno001.pCodig & "'")
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

                    Try
                        Me.msk_vencto.Text = Format(Convert.ChangeType(DrDup(6), GetType(Date)), "ddMMyyy")
                    Catch ex As Exception
                        Me.msk_vencto.Text = ""
                    End Try

                    mSit = DrDup(7).ToString
                    mSituacao = DescrSit(mSit)
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

    Private Sub cbo_loja_GotFocus(sender As Object, e As EventArgs) Handles cbo_loja.GotFocus
        If cbo_loja.DroppedDown = False Then cbo_loja.DroppedDown = True
    End Sub

    Private Sub cbo_loja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_loja.SelectedIndexChanged

        Try
            If cbo_loja.SelectedIndex > -1 Then

                If _clFuncoes.trazGenoSelecionado(cbo_loja.SelectedItem.ToString.Substring(0, 5), _geno001) = False Then
                    MsgBox("Loja não encontrada!")
                End If
            End If

        Catch ex As Exception
            MsgBox("Loja não encontrada! " & ex.Message)
        End Try

    End Sub

    Private Sub cbo_tipo_GotFocus(sender As Object, e As EventArgs) Handles cbo_tipo.GotFocus
        If cbo_tipo.DroppedDown = False Then cbo_tipo.DroppedDown = True
    End Sub

End Class