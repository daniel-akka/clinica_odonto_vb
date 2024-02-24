Imports System.Text
Imports Npgsql

Public Class Frm_CfopResp

    Public _formRequest As New Object
    Dim funcoes As New ClFuncoes
    Dim digCFOP As String = ""

    Public Sub set_frmRef(ByRef frmRef As Form)
        _formRequest = frmRef
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Me.Close()
    End Sub

    Private Sub Frm_CfopResp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Frm_CfopResp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress


        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Frm_CfopResp_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            _formRequest.cfopRef = dtg_cfop.CurrentRow.Cells(0).Value.ToString
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Frm_CfopResp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            If _formRequest.cfopRef.Equals("") Then
                digCFOP = ""
            Else
                digCFOP = Mid(_formRequest.cfopRef, 1, 1)
            End If

            preencheDtg_Cfop()
        Catch ex As Exception
        End Try

    End Sub

    'Private Sub txt_cfop_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cfop.KeyPress

    '    'permite só numeros
    '    If funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    'End Sub

    Private Sub txt_cfop_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cfop.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter

                If dtg_cfop.RowCount = 1 Then
                    dtg_cfop.Focus() : Me.Close()
                End If
            Case Keys.Down
                dtg_cfop.Focus()
        End Select
    End Sub

    Private Sub preencheDtg_Cfop()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdGrupos As New NpgsqlCommand
        Dim sqlGrupos As New StringBuilder
        Dim drGrupos As NpgsqlDataReader

        Dim mcfop As String = "", mdescricao As String = ""

        Try

            sqlGrupos.Append("SELECT r_cdfis, r_natureza FROM cadnatu WHERE ")
            If digCFOP.Equals("") Then
                sqlGrupos.Append("r_natureza LIKE '%" & Me.txt_cfop.Text & "' ORDER BY r_cdfis ASC")
            Else
                sqlGrupos.Append("Substr(r_cdfis, 1, 1) = '" & digCFOP & "' AND ")
                sqlGrupos.Append("r_cdfis LIKE '" & Me.txt_cfop.Text & "%' ORDER BY r_cdfis ASC")

            End If
            cmdGrupos = New NpgsqlCommand(sqlGrupos.ToString, oConnBDMETROSYS)
            drGrupos = cmdGrupos.ExecuteReader

            dtg_cfop.Rows.Clear()
            If drGrupos.HasRows = False Then Return
            While drGrupos.Read
                mcfop = drGrupos(0).ToString
                mdescricao = drGrupos(1).ToString

                dtg_cfop.Rows.Add(mcfop, mdescricao)

            End While

            dtg_cfop.Refresh() : drGrupos.Close()
            oConnBDMETROSYS.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT dos CFOPs:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmdGrupos.CommandText = "" : sqlGrupos.Remove(0, sqlGrupos.ToString.Length)

        'Limpa Objetos de Memoria...
        mdescricao = Nothing : oConnBDMETROSYS = Nothing : cmdGrupos = Nothing
        sqlGrupos = Nothing : drGrupos = Nothing



    End Sub

    Private Sub txt_cfop_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cfop.TextChanged

        preencheDtg_Cfop()

    End Sub

    Private Sub dtg_cfop_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtg_cfop.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                Me.Close()
        End Select

    End Sub
End Class