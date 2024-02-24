
Public Class Frm_ConfirmaCompraGrade
    Private conexao As String = MdlConexaoBD.conectionPadrao
    Private Const _valorZERO As Int16 = 0
    Dim _clFuncoes As New ClFuncoes
    Public _formRequest As New Object


    Public Sub set_frmRef(ByRef frmRef As Form)

        _formRequest = frmRef
    End Sub

    Private Sub Frm_ConfirmaCompraGrade_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cbo_cores = _clFuncoes.PreenchComboCoresGrade(cbo_cores, MdlConexaoBD.conectionPadrao)
        Me.cbo_cores.SelectedIndex = _valorZERO
        Me.txt_tamanho.Focus()
    End Sub

    Private Sub Frm_ConfirmaCompraGrade_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub cbo_cores_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_cores.GotFocus
        If Not cbo_cores.DroppedDown Then cbo_cores.DroppedDown = True
    End Sub

    Private Function validaCamposOK() As Boolean

        Try
            If Trim(Me.txt_tamanho.Text).Equals("") Then
                MsgBox("Campo Tamanho deve ser Preenchido", MsgBoxStyle.Exclamation)
                Me.txt_tamanho.Focus() : Me.txt_tamanho.SelectAll()
                Return False
            End If

            If Me.cbo_cores.SelectedIndex < _valorZERO Then
                MsgBox("Por Favor, Selecione um COR", MsgBoxStyle.Exclamation)
                Me.cbo_cores.Focus()
                Return False
            End If

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try


        Return True
    End Function

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Me.Close()
    End Sub

    Private Sub Frm_ConfirmaCompraGrade_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Frm_ConfirmaCompraGrade_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If validaCamposOK() Then

            _formRequest._frmREf.tamanhoGrade_Ref = Me.txt_tamanho.Text
            _formRequest._frmREf.codCorGrade_Ref = Mid(Me.cbo_cores.SelectedItem, 1, 2)
            _formRequest._frmREf.nomeCorGrade_Ref = Mid(Me.cbo_cores.SelectedItem, 6)
            '_formRequest._frmREf.txt_nomeProd.Focus()
            '_formRequest._frmREf.Show()
        Else
            e.Cancel = True
        End If

    End Sub

End Class