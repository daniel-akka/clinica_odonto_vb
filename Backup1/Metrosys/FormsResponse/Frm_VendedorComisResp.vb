Public Class Frm_VendedorComisResp

    Dim funcoes As New ClFuncoes
    Private _formRequest As New Object

    Public Sub set_frmRef(ByRef frmRef As Form)
        _formRequest = frmRef
    End Sub

    Private Sub Frm_VendedorComisRespp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Frm_VendedorComisResp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbo_vendedores = funcoes.PreenchComboVendedoresNomeFull(cbo_vendedores, MdlConexaoBD.conectionPadrao)
        txt_alqAVista.Text = Format(MdlEmpresaUsu.alqComisAVista, "#,#00.00")
        txt_alqEntrada.Text = Format(MdlEmpresaUsu.alqComisAVista, "#,#00.00")
        txt_alqAPrazo.Text = Format(MdlEmpresaUsu.alqComisAPrazo, "#,#00.00")

        cbo_vendedores.SelectedIndex = 0
        cbo_vendedores.Focus()
    End Sub

    Private Sub cbo_vendedores_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_vendedores.GotFocus
        If cbo_vendedores.DroppedDown = False Then cbo_vendedores.DroppedDown = True
    End Sub

    Private Sub Frm_VendedorComisResp_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            _formRequest._frmREf.codVendedorRef = cbo_vendedores.SelectedItem.ToString.Substring(0, 6)
            _formRequest._frmREf.nomeVendedorRef = cbo_vendedores.SelectedItem.ToString.Substring(8)
            _formRequest._frmREf.alqComisAVistaRef = CDbl(txt_alqAVista.Text)
            _formRequest._frmREf.alqComisEntradaRef = CDbl(txt_alqEntrada.Text)
            _formRequest._frmREf.alqComisAPrazoRef = CDbl(txt_alqAPrazo.Text)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub txt_alqEntrada_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_alqEntrada.KeyPress
        'permite só numeros virgula
        If funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_alqEntrada_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqEntrada.Leave


        If Me.txt_alqEntrada.Text.Equals("") Then Me.txt_alqEntrada.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_alqEntrada.Text) Then
            If CDec(Me.txt_alqEntrada.Text) < 0 Then
                MsgBox("Entrada deve ser maior ou igual a ZERO !")
                Return

            End If
            Me.txt_alqEntrada.Text = Format(CDec(Me.txt_alqEntrada.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_alqAPrazo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_alqAPrazo.KeyPress
        'permite só numeros virgula
        If funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_alqAPrazo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqAPrazo.Leave


        If Me.txt_alqAPrazo.Text.Equals("") Then Me.txt_alqAPrazo.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_alqAPrazo.Text) Then
            If CDec(Me.txt_alqAPrazo.Text) < 0 Then
                MsgBox("A Prazo deve ser maior ou igual a ZERO !")
                Return

            End If
            Me.txt_alqAPrazo.Text = Format(CDec(Me.txt_alqAPrazo.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_alqAVista_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_alqAVista.KeyPress
        'permite só numeros virgula
        If funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_alqAVista_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqAVista.Leave


        If Me.txt_alqAVista.Text.Equals("") Then Me.txt_alqAVista.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_alqAVista.Text) Then
            If CDec(Me.txt_alqAVista.Text) < 0 Then
                MsgBox("A Vista deve ser maior ou igual a ZERO !")
                Return

            End If
            Me.txt_alqAVista.Text = Format(CDec(Me.txt_alqAVista.Text), "###,##0.00")

        End If

    End Sub

End Class