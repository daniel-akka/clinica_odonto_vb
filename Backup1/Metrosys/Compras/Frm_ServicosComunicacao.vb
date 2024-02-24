Imports System.Text
Imports System.IO
Imports System.Data
Imports System.DateTime
Imports System.Data.DataColumnCollection
Imports System.Data.DataRow
Imports Npgsql
Public Class Frm_ServicosComunicacao
    Public Shared ServcomuREf As New Frm_ServicosComunicacao
    Protected _conexao As String = MdlConexaoBD.conectionPadrao
    Dim agora As Date = Now
    Dim DTHora As DateTime = DateTime.Now
    Dim Xtel, xnum As New Cl_bdMetrosys

    Private Sub btn_sai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sai.Click
        Me.Close()
    End Sub

    Private Sub btn_sai_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btn_sai.KeyDown
        Me.Close()
    End Sub

    Private Sub Frm_ServicosComunicacao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If (e.KeyCode = Keys.Escape) Then

            Me.Close()
        End If
    End Sub

    Private Sub Frm_ServicosComunicacao_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_ServicosComunicacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.msk_emissao.Text = Date.Now
        Me.msk_vencto.Text = Date.Now
        Me.msk_dtentrada.Text = Date.Now
        Me.msk_mesano.Text = Mid(msk_emissao.Text, 4, 7).ToString
        Me.txt_vlservico.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_outdesp.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_abatimento.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_total.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_aliq.Text = Format(Convert.ToDouble(0.0), "#0.00")
        Me.txt_bcalc.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_icmscred.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_isento.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_outras.Text = Format(Convert.ToDouble(0.0), "##,##0.00")

    End Sub

    Private Sub btn_inclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inclui.Click

        Xtel.IncServComunicacao(txt_numero.Text, txt_serie.Text, txt_subserie.Text, DateValue(Me.msk_emissao.Text), DateValue(msk_dtentrada.Text), _
                                txt_pcod.Text, msk_fone.Text, msk_mesano.Text, DateValue(msk_vencto.Text), txt_classe.Text, _
                                Convert.ToDouble(txt_vlservico.Text), Convert.ToDouble(txt_outdesp.Text), Convert.ToDouble(txt_abatimento.Text), _
                                Convert.ToDouble(txt_total.Text), Mid(Me.cbo_cfop.SelectedItem.ToString, 1, 4), Mid(Me.cbo_cfop.SelectedItem, 1, 2), _
                                Convert.ToDouble(txt_bcalc.Text), txt_aliq.Text, Convert.ToDouble(txt_icmscred.Text), Convert.ToDouble(txt_isento.Text), _
                                Convert.ToDouble(txt_outras.Text), _conexao)

    End Sub

    Private Sub txt_pcod_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pcod.LostFocus

        If (Me.txt_pcod.Text) = "" Then

            ServcomuREf = Me
            Dim BuscaForn As New Frm_buscaFornecedor
            BuscaForn.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub txt_pcod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pcod.TextChanged

    End Sub
End Class