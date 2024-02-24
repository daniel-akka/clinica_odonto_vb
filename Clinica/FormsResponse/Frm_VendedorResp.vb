Public Class Frm_VendedorResp

    Dim funcoes As New ClFuncoes
    Private _formRequest As New Object

    Public Sub set_frmRef(ByRef frmRef As Form)
        _formRequest = frmRef
    End Sub

    Private Sub Frm_VendedorResp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Frm_VendedorResp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_vendedores = funcoes.PreenchComboVendedoresNomeFull(cbo_vendedores, MdlConexaoBD.conectionPadrao)
        cbo_vendedores.SelectedIndex = 0
        cbo_vendedores.Focus()
    End Sub

    Private Sub cbo_vendedores_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_vendedores.GotFocus
        If cbo_vendedores.DroppedDown = False Then cbo_vendedores.DroppedDown = True
    End Sub

    Private Sub Frm_VendedorResp_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            _formRequest._frmREf.codVendedorRef = cbo_vendedores.SelectedItem.ToString.Substring(0, 6)
            _formRequest._frmREf.nomeVendedorRef = cbo_vendedores.SelectedItem.ToString.Substring(8)
        Catch ex As Exception
        End Try

    End Sub

End Class