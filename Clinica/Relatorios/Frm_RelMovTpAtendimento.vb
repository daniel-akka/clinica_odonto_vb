Imports Npgsql
Imports System.Math

Public Class Frm_RelMovTpAtendimento
    Dim TpAtendimento As New Cl_TpAtendimento
    Dim geno01 As New Cl_Geno
    Dim clFunc As New ClFuncoes

    Private Sub Frm_RelMovTpAtendimento_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub Frm_RelMovTpAtendimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_NomeSys.Text = Application.ProductName

        cbo_tipoAtendimento = TpAtendimento.DAO.PreenchComboTpAtendementoPesq(cbo_tipoAtendimento, MdlConexaoBD.conectionPadrao)

        clFunc.trazGenoSelecionado(MdlEmpresaUsu._codigo, geno01)
    End Sub

    Private Sub cbo_tipoAtendimento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tipoAtendimento.SelectedIndexChanged
        preenchDtg_TpAtendimento()
    End Sub

    Private Sub dtp_inicial_ValueChanged(sender As Object, e As EventArgs) Handles dtp_inicial.ValueChanged, dtp_final.ValueChanged
        preenchDtg_TpAtendimento()
    End Sub

    Function TrazConsultaTpAtend() As String
        Dim Sqlcomm As String = ""

        If cbo_tipoAtendimento.SelectedIndex > 0 Then
            Sqlcomm = "SELECT DISTINCT t.tpa_atendimento, ((SELECT Count(c2.cx_tpatend) FROM " & geno01.pEsquemaestab & ".caixadiario c2 WHERE "
            Sqlcomm += "c2.cx_tpatend = t.tpa_atendimento AND (c2.cx_data BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "')) + "
            Sqlcomm += "(SELECT Count(f2.f_tpatend) FROM " & geno01.pEsquemaestab & ".fatd001 f2 WHERE f2.f_tpatend = t.tpa_atendimento "
            Sqlcomm += "AND (f2.f_dtpaga BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "'))) As ""qtde"", "

            Sqlcomm += "(SELECT Sum(c2.cx_valor) FROM " & geno01.pEsquemaestab & ".caixadiario c2 WHERE "
            Sqlcomm += "c2.cx_tpatend = t.tpa_atendimento AND (c2.cx_data BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "')) As ""VlrCX"", "
            Sqlcomm += "(SELECT Sum(f2.f_valor) FROM " & geno01.pEsquemaestab & ".fatd001 f2 WHERE f2.f_tpatend = t.tpa_atendimento "
            Sqlcomm += "AND (f2.f_dtpaga BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "')) As ""VlrFD"" "
            Sqlcomm += "FROM tpantendimento t WHERE t.tpa_atendimento = '" & cbo_tipoAtendimento.SelectedItem.ToString & "' "
        Else

            Sqlcomm = "SELECT DISTINCT t.tpa_atendimento, ((SELECT Count(c2.cx_tpatend) FROM " & geno01.pEsquemaestab & ".caixadiario c2 WHERE "
            Sqlcomm += "c2.cx_tpatend = t.tpa_atendimento AND (c2.cx_data BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "')) + "
            Sqlcomm += "(SELECT Count(f2.f_tpatend) FROM " & geno01.pEsquemaestab & ".fatd001 f2 WHERE f2.f_tpatend = t.tpa_atendimento "
            Sqlcomm += "AND (f2.f_dtpaga BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "'))) As ""qtde"", "
            Sqlcomm += "(SELECT Sum(c2.cx_valor) FROM " & geno01.pEsquemaestab & ".caixadiario c2 WHERE "
            Sqlcomm += "c2.cx_tpatend = t.tpa_atendimento AND (c2.cx_data BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "')) As ""VlrCX"", "
            Sqlcomm += "(SELECT Sum(f2.f_valor) FROM " & geno01.pEsquemaestab & ".fatd001 f2 WHERE f2.f_tpatend = t.tpa_atendimento "
            Sqlcomm += "AND (f2.f_dtpaga BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "')) As ""VlrFD"" FROM tpantendimento t "
        End If
        
        Sqlcomm += "ORDER BY t.tpa_atendimento ASC"


        Return Sqlcomm
    End Function

    Private Sub preenchDtg_TpAtendimento()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim consulta As String

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão:: " & ex.Message)
        End Try

        consulta = TrazConsultaTpAtend()

        comm = New NpgsqlCommand(consulta, conn)
        dr = comm.ExecuteReader

        Try

            Dim mvlrCX, mvlrFD As Double
            dtg_tipoAtendimento.Rows.Clear() : dtg_tipoAtendimento.Refresh()
            Dim usuario As String = ""
            While dr.Read

                If dr(1) > 0 Then
                    Try
                        mvlrCX = dr(2)
                    Catch ex As Exception
                        mvlrCX = 0
                    End Try

                    Try
                        mvlrFD = dr(3)
                    Catch ex As Exception
                        mvlrFD = 0
                    End Try
                    Dim mlinha As String() = {dr(0).ToString, dr(1), Format(Round(mvlrCX + mvlrFD, 2), "###,##0.00")}
                    dtg_tipoAtendimento.Rows.Add(mlinha)
                End If
                
            End While
            dtg_tipoAtendimento.Refresh()

            conn.Close()
            conn = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

End Class