Public Class Frm_CodCaixaResp

    Public _formRequest As New Object
    Dim _clFuncoes As New ClFuncoes

    Private Sub Frm_CodCaixaResp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cbo_codCaixa = _clFuncoes.PreenchComboCodCaixa(MdlEmpresaUsu._codigo, cbo_codCaixa, MdlConexaoBD.conectionPadrao)

        If MdlUsuarioLogando._codcaixa.Equals("") = False Then
            cbo_codCaixa.SelectedIndex = _clFuncoes.trazIndexComboBox(MdlUsuarioLogando._codcaixa, 3, cbo_codCaixa)
            If cbo_codCaixa.SelectedIndex > -1 Then cbo_codCaixa.Enabled = False
        End If

        Try
            If cbo_codCaixa.Items.Count < 1 Then
                MsgBox("Não existe Cadastro de CAIXA para esta loja! Favor Cadastrar!", MsgBoxStyle.Exclamation)
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message) : Me.Close()
        End Try

    End Sub

    Public Sub set_frmRef(ByRef frmRef As Form)
        _formRequest = frmRef
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Me.Close()
    End Sub

    Private Sub Frm_CodCaixaResp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Frm_CodCaixaResp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress


        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Frm_CodCaixaResp_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing



        Try


            If cbo_codCaixa.SelectedIndex < 0 Then

                MsgBox("Informe um CAIXA Válido, Por Favor!", MsgBoxStyle.Information)
                cbo_codCaixa.Focus() : e.Cancel = True
            Else

                Try
                    _formRequest._frmREf.codCaixaRef = cbo_codCaixa.SelectedItem.ToString
                Catch ex As Exception
                End Try

            End If

        Catch ex As Exception

            Try
                _formRequest._frmREf.codCaixaRef = ""
            Catch ex2 As Exception
            End Try
        End Try
        

    End Sub

End Class