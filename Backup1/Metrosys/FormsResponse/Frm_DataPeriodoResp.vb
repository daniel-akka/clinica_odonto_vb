Public Class Frm_DataPeriodoResp

    Public _formRequest As New Object


    Public Sub set_frmRef(ByRef frmRef As Form)
        _formRequest = frmRef
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Me.Close()
    End Sub

    Private Sub Frm_DataPeriodo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Frm_DataPeriodo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress


        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Frm_DataPeriodo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing


        If IsDate(dtp_dataInicial.Value.ToShortDateString) = False Then

            MsgBox("Informe uma Data Inicial Válida, Por Favor!", MsgBoxStyle.Information)
            dtp_dataInicial.Focus() : e.Cancel = True

        ElseIf IsDate(dtp_dataFinal.Value.ToShortDateString) = False Then

            MsgBox("Informe uma Data Final Válida, Por Favor!", MsgBoxStyle.Information)
            dtp_dataFinal.Focus() : e.Cancel = True

        ElseIf (dtp_dataInicial.Value > dtp_dataFinal.Value) Then

            MsgBox("""Data Inicial"" deve ser MENOR ou IGUAL a ""Data Final""!", MsgBoxStyle.Information)
            dtp_dataInicial.Focus() : e.Cancel = True

        Else

            Try
                _formRequest._frmREf.dataInicialRef = dtp_dataInicial.Value
                _formRequest._frmREf.dataFinalRef = dtp_dataFinal.Value
            Catch ex As Exception
            End Try

        End If

    End Sub

End Class