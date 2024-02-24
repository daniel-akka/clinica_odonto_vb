Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.DateTime
Imports System.Math
Imports Npgsql
Public Class Frm_Dup_Registro
    Public Shared _frmREf As New Frm_Dup_Registro
    Dim _BuscaForn As New Frm_buscaForn
    Dim _formBusca As Boolean = False
    Dim cl_BD As New Cl_bdMetrosys
    Dim agora As Date = Now
    Dim cl_funcoes As New Funcoes
    Public mbUf, mbCNPJ As String
    Public _mPesquisaForn As Boolean = False 'Serve para configura os campos CodFornec e NomeFornec
    Protected _conexao As String = MdlConexaoBD.conectionPadrao


    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown
        If Not Me.txt_codPart.Text.Equals("") Then
            If Me.txt_codPart.TextLength > 5 AndAlso e.KeyCode = Keys.Enter Then 'Se retornar nada
                If trazFornecedor(Me.txt_codPart.Text) Then


                    'Aqui tenta chamar a Busca do Produto...
                    Try
                       
                        Me.txt_nomePart.Focus()
                        Me.txt_nomePart.SelectAll()

                        Return
                    Catch ex As Exception
                    End Try


                End If
            End If
        End If

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            If Me.txt_codPart.Text.Equals("") Then


                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try

                    _formBusca = False
                    _frmREf = Me
                    _BuscaForn.set_frmRef(Me)
                    _BuscaForn.ShowDialog(Me)
                    _formBusca = False
                    If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus()

                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()

                Catch ex As Exception
                End Try


            End If
        End If

    End Sub
    Public Function trazFornecedor(ByVal codFornec As String) As Boolean
        Dim nomeCampo As String = ""
        Dim nomeCampoCgc As String = ""
        Dim nomeCampoCpf As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(cl_BD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        Dim pesquisa As String = codFornec.ToUpper

        Try
            If oConnBDGENOV.State = ConnectionState.Closed Then
                oConnBDGENOV.Open()
            End If
        Catch ex As Exception
        End Try

        If oConnBDGENOV.State = ConnectionState.Open Then
            Dim codigo, nome, cpf_cnpj, inscricao, UF As String

            Try
                SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc,p_uf FROM cadp001 WHERE ") ' 5
                SqlParticipante.Append("p_cod = '" & pesquisa & "' ORDER BY p_portad ASC")
                CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDGENOV)
                drParticipante = CmdParticipante.ExecuteReader

                If drParticipante.HasRows = False Then
                    Return False
                Else
                    While drParticipante.Read
                        codigo = drParticipante(0).ToString
                        nome = drParticipante(1).ToString
                        If Not drParticipante(2).ToString.Equals("") Then 'se tiver CNPJ...
                            cpf_cnpj = drParticipante(2).ToString
                        Else
                            cpf_cnpj = drParticipante(3).ToString
                        End If
                        inscricao = drParticipante(4).ToString
                        UF = drParticipante(5).ToString

                    End While
                    Me.txt_nomePart.Text = nome
                    Me.mbCNPJ = cpf_cnpj
                    Me.mbUf = UF

                End If

            Catch ex As Exception
            End Try

            CmdParticipante.CommandText = ""
            SqlParticipante.Remove(0, SqlParticipante.ToString.Length)
        End If

        Return True
    End Function

    Private Sub Frm_Dup_Registro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Close()

    End Sub

    Private Sub Frm_Dup_Registro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Dup_Registro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.msk_emissao.Text = agora
        Me.txt_desconto.Text = "0,00"
        Me.txt_juros.Text = "0,00"
        Me.txt_outros.Text = "0,00"
        Me.txt_protesto.Text = "0,00"
        Me.txt_valor.Text = "0,00"
        Me.txt_situacao.Text = "N"
        Me.Msk_dtpaga.Enabled = False
        Me.txt_juros.Enabled = False
        Me.txt_protesto.Enabled = False
    End Sub

    Private Sub txt_fatura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_fatura.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(cl_BD.SoNumerov(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_fatura_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fatura.Leave
        Dim mfat As Integer
        mfat = Convert.ToInt32(Me.txt_fatura.Text)
        Me.txt_fatura.Text = String.Format("{0:D9}", mfat)
        Me.txt_documento.Text = Me.txt_fatura.Text & "A"
    End Sub

    Private Sub txt_valor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valor.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(cl_BD.SoNumerov(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        Me.lbl_mensagem.Text = ""
    End Sub

    Private Sub txt_juros_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_juros.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(cl_BD.SoNumerov(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_desconto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_desconto.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(cl_BD.SoNumerov(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_tarifa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_protesto.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(cl_BD.SoNumerov(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_outros_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_outros.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(cl_BD.SoNumerov(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_salvar.Click
        Dim mteste As Boolean = True
        If txt_valor.Text = "0,00" Then
            Me.lbl_mensagem.Text = "Erro: Digite Valor do Documento !"
            mteste = False
            Me.txt_valor.Focus()
        End If
        If Not IsDate(msk_emissao.Text) Then
            Me.lbl_mensagem.Text = "Erro: Digite Data de Emissao !"
            mteste = False
            Me.msk_emissao.Focus()
        End If
        If Not IsDate(Msk_vencto.Text) Then
            Me.lbl_mensagem.Text = "Erro: Digite Data de Vencimento !"
            mteste = False
            Me.msk_emissao.Focus()
        End If
        If mteste = True Then
            Try
                'cl_BD.incDuplicatasR("G0001", txt_codPart.Text, Me.Cbo_tipo.SelectedItem, txt_fatura.Text, txt_fatura.Text, " ", 0.0, _
                '                     txt_documento.Text, DateValue(msk_emissao.Text), DateValue(Msk_vencto.Text), CDbl(Me.txt_valor.Text), _
                '                      "00", DateValue(Now), CDbl(txt_juros.Text), CDbl(txt_desconto.Text), CInt(Mid(Cbo_Banco.SelectedItem, 1, 3)), _
                '                      txt_historico.Text, Space(5), CDbl(txt_protesto.Text), txt_outros.Text, "00", "00", "00", txt_situacao.Text, _
                '                      False, "01", 1, Space(5), Space(5), Space(5), "N", "N", conexao)

                lbl_mensagem.Text = "Registro Incluido c/ Sucesso !"
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

        End If
    End Sub

    Private Sub msk_emissao_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_emissao.Leave
        ' agora = DateValue(msk_emissao.Text)
        Try
            Me.Msk_vencto.Text = DateValue(msk_emissao.Text).AddDays(30)
        Catch ex As Exception
            Me.lbl_mensagem.Text = "Digite Data de Emissao !"
        End Try

    End Sub

    Private Sub Cbo_tipo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_tipo.Leave
        If Me.Cbo_tipo.SelectedIndex = 0 Or Cbo_tipo.SelectedIndex = 2 Or Me.Cbo_tipo.SelectedIndex >= 4 Then
            Me.Cbo_Banco.SelectedIndex = 0
        End If
        
    End Sub

    Private Sub txt_desconto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_desconto.Leave
        Me.lbl_mensagem.Text = ""
    End Sub
End Class