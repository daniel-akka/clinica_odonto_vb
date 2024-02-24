Imports System.IO
Imports System.Text
Imports System.Math
Imports Npgsql
Imports System.Data
Imports System.DateTime
Public Class Frm_DespLancamento

    Public Shared LancaDespRef As Frm_DespLancamento
    Dim transacao As NpgsqlTransaction
    Dim agora As Date = Now
    Dim vds_id As Integer
    Dim Xnumeros, cl_BD As New Cl_bdMetrosys
    Dim conexao As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Public LocalEmp As String = ""


    Private Sub Frm_DespLancamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Frm_DespLancamento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_DespLancamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        Me.msk_data.Text = DateValue(agora)
        Me.txt_valor.Text = "0,00"
        Me.msk_subconta.Focus()
        cbo_loja = _clFunc.PreenchComboLoja2Dig(cbo_loja, MdlConexaoBD.conectionPadrao)
        If LocalEmp.Equals("") Then
            cbo_loja.SelectedIndex = _clFunc.trazIndexComboBox(Mid(MdlEmpresaUsu._codigo, MdlEmpresaUsu._codigo.Length - 1), 2, cbo_loja)
        Else
            cbo_loja.SelectedIndex = _clFunc.trazIndexComboBox(LocalEmp, 2, cbo_loja)
        End If
        SendKeys.Send("{TAB}")
        Me.msk_subconta.Focus()

    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click
        If cbo_loja.SelectedIndex = -1 Or txt_valor.Text = "0,00" Then
            MessageBox.Show("Favor Selecione a Loja/Valor de Lancamento ", "Erro Seleção/Valor ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbo_loja.Focus()
            Return
        End If
        If txt_valor.Text = "0,00" Then
            MessageBox.Show("Informar o Valor do Lançamento ", "Erro Valor ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_valor.Focus()
            Return
        End If
        If MessageBox.Show("Confirme Gravação ", "Gravação ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            conexao.Open()
            cl_BD.crud_DespLancamentos("I", 0, "0" & Mid(cbo_loja.SelectedItem, 1, 2), txt_conta.Text, msk_subconta.Text, msk_data.Text, _
                                  Mid(lbl_tipoplanc.Text, 1, 1), txt_historico.Text, CDbl(txt_valor.Text), transacao, conexao)
            conexao.Close()
            limpa_desplancamentos()
            lbl_mensagem.Text = "Lancamento Efetuado c/ Sucesso ! "
            cbo_loja.Focus()
        End If
    End Sub
    Private Sub limpa_desplancamentos()
        Me.txt_conta.Text = ""
        Me.msk_subconta.Text = ""
        Me.txt_descricao2.Text = ""
        Me.txt_historico.Text = ""
        Me.txt_valor.Text = "0,00"
        Me.lbl_tipoplanc.Text = "P-R"
    End Sub

    Private Sub msk_subconta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles msk_subconta.KeyPress
        'permite só numeros:
        If _clFunc.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub msk_subconta_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_subconta.Leave
        lbl_mensagem.Text = ""
        If msk_subconta.Text = "" Then
            LancaDespRef = Me
            Dim Buscaplano As New Frm_BuscaPlano
            Buscaplano.LocalEmpresa = LocalEmp
            Buscaplano.ShowDialog()
            txt_historico.Focus()

        Else

        End If
    End Sub

    Private Sub cbo_loja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_loja.GotFocus
        If cbo_loja.DroppedDown = False Then cbo_loja.DroppedDown = True
    End Sub

    Private Sub cbo_loja_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_loja.Leave
        txt_valor.Text = Format(CDec(txt_valor2.Text), "###,##0.00")
    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click
        If MessageBox.Show("Confirme Alteração ?", "  Alteração  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            conexao.Open()
            cl_BD.crud_DespLancamentos("A", MIdLanc, "0" & Mid(cbo_loja.SelectedItem, 1, 2), txt_conta.Text, msk_subconta.Text, msk_data.Text, _
                                  Mid(lbl_tipoplanc.Text, 1, 1), txt_historico.Text, CDbl(txt_valor.Text), transacao, conexao)
            conexao.Close()
            limpa_desplancamentos()
            lbl_mensagem.Text = "Lancamento Alterado c/ Sucesso ! "
            Me.Close()
        Else
            Me.cbo_loja.Focus()
        End If
    End Sub
    Public Property MIdLanc() As Integer
        Get
            Return Me.vds_id
        End Get
        Set(ByVal value As Integer)
            Me.vds_id = value
        End Set
    End Property

    Private Sub txt_valor_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valor.Leave

        lbl_mensagem.Text = ""
        If Me.txt_valor.Text.Equals("") Then Me.txt_valor.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valor.Text) Then

            If CDec(Me.txt_valor.Text) <= 0 Then

                lbl_mensagem.Text = "Valor deve ser maior que ZERO !"
                Return
            End If
            Me.txt_valor.Text = Format(CDec(Me.txt_valor.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_valor2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valor2.Leave

        If Me.txt_valor2.Text.Equals("") Then Me.txt_valor2.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valor2.Text) Then

            If CDec(Me.txt_valor2.Text) < 0 Then

                MsgBox("Valor deve ser maior que ZERO !")
                Me.txt_valor2.Focus() : Me.txt_valor2.SelectAll()
                Return
            End If
            Me.txt_valor2.Text = Format(CDec(Me.txt_valor2.Text), "###,##0.00")

        End If

    End Sub

    Private Sub msk_data_GotFocus(sender As Object, e As EventArgs) Handles msk_data.GotFocus
        Me.msk_data.SelectAll()
    End Sub

    Private Sub cbo_loja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_loja.SelectedIndexChanged

        Try
            If cbo_loja.SelectedIndex >= 0 Then
                LocalEmp = Mid(cbo_loja.SelectedItem.ToString, 1, 2)
            End If
        Catch ex As Exception
        End Try

    End Sub
End Class