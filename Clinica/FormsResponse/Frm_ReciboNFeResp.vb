Public Class Frm_ReciboNFeResp
    Dim frmGeraNFe As New Frm_GeraNotasFiscais

    Public Sub setFormulario(ByRef frmGNFe As Frm_GeraNotasFiscais)
        Me.frmGeraNFe = frmGNFe
    End Sub

    Private Sub Frm_ReciboNFe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txt_numeroNFe.Text = frmGeraNFe.clImpressaoRecibo._documento
        txt_numeroNFe.Focus() : txt_numeroNFe.SelectAll()

    End Sub

    Private Sub txt_valor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_valor.KeyPress
        'permite só numeros com virgula
        If MdlERRO._clFunc.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_valor_Leave(sender As Object, e As EventArgs) Handles txt_valor.Leave

        If Me.txt_valor.Text.Equals("") Then Me.txt_valor.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valor.Text) Then
            If CDec(Me.txt_valor.Text) <= 0 Then
                MsgBox("Valor deve ser maior que ZERO !")
                Me.txt_numeroNFe.Focus()

            End If
            Me.txt_valor.Text = Format(CDec(Me.txt_valor.Text), "###,##0.00")

        End If

    End Sub

    Private Sub Frm_ReciboNFeResp_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Frm_ReciboNFeResp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_ReciboNFeResp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmGeraNFe.clImpressaoRecibo._valor = txt_valor.Text
    End Sub

End Class