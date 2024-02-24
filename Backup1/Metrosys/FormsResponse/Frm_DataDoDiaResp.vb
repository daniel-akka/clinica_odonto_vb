Public Class Frm_DataDoDiaResp

    Public _formRequest As New Object


    Public Sub set_frmRef(ByRef frmRef As Form)
        _formRequest = frmRef
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Me.Close()
    End Sub

    Private Sub Frm_Data_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Frm_Data_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress


        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Frm_Data_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing


        If IsDate(dtp_dataDoDia.Value.ToShortDateString) = False Then

            MsgBox("Informe uma Data Válida, Por Favor!", MsgBoxStyle.Information)
            dtp_dataDoDia.Focus() : e.Cancel = True
        Else

            Try
                _formRequest._frmREf.dataDoDiaRef = dtp_dataDoDia.Value
            Catch ex As Exception
            End Try

        End If

    End Sub

End Class