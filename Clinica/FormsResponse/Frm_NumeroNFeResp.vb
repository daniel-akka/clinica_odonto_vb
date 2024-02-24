Public Class Frm_NumeroNFeResp

    Public _formRequest As New Object
    Dim _clFuncoes As New ClFuncoes

    Public Sub set_frmRef(ByRef frmRef As Form)
        _formRequest = frmRef
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Me.Close()
    End Sub

    Private Sub Frm_numeroNFeResp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Frm_numeroNFeResp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress


        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Frm_numeroNFeResp_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            _formRequest._frmREf.numeroNFeRef = txt_numero.Text
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txt_numero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_numero_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero.Leave

        Try
            txt_numero.Text = String.Format("{0:D9}", CInt(txt_numero.Text))
        Catch ex As Exception
            txt_numero.Text = ""
        End Try

    End Sub

    Private Sub Frm_numeroNFeResp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_numero.Text = ""
    End Sub
End Class