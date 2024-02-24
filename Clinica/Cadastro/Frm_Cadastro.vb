Imports System
Imports System.Data
Imports System.IO

Public Class Frm_Cadastro
    Dim s As String
    Dim operador As [Enum]
    Dim xoper As New Cl_bdMetrosys.opera


    Private Sub Frm_Cadastro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Cadastro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cbo_uf.Items.Add("AC")
        Me.cbo_uf.Items.Add("AL")
        Me.cbo_uf.Items.Add("AP")
        Me.cbo_uf.Items.Add("AM")
        Me.cbo_uf.Items.Add("BA")
        Me.cbo_uf.Items.Add("CE")
        Me.cbo_uf.Items.Add("DF")
        Me.cbo_uf.Items.Add("ES")
        Me.cbo_uf.Items.Add("EX")
        Me.cbo_uf.Items.Add("GO")
        Me.cbo_uf.Items.Add("MA")
        Me.cbo_uf.Items.Add("MT")
        Me.cbo_uf.Items.Add("MS")
        Me.cbo_uf.Items.Add("MG")
        Me.cbo_uf.Items.Add("PA")
        Me.cbo_uf.Items.Add("PB")
        Me.cbo_uf.Items.Add("PE")
        Me.cbo_uf.Items.Add("PI")
        Me.cbo_uf.Items.Add("RJ")
        Me.cbo_uf.Items.Add("RN")
        Me.cbo_uf.Items.Add("RS")
        Me.cbo_uf.Items.Add("RD")
        Me.cbo_uf.Items.Add("RR")
        Me.cbo_uf.Items.Add("SC")
        Me.cbo_uf.Items.Add("SP")
        Me.cbo_uf.Items.Add("SE")
        Me.cbo_uf.Items.Add("TO")
        Me.cbo_uf.Sorted = True

        Me.msk_UltCompra.Enabled = False
        Me.msk_valor.Enabled = False
        Me.txt_pedido.Enabled = False
        AlfaMaiuscula()
        Me.RdBCli.Checked = True
        Me.RdBFisica.Checked = True
        Me.txt_RazaoSocial.Focus()

    End Sub

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub RdBFisica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBFisica.CheckedChanged
        If Me.RdBFisica.Checked = True Then
            Me.txt_insc.Enabled = False
            Me.msk_cnpj.Enabled = False
            Me.msk_txtcpf.Enabled = True
            Me.txt_ident.Enabled = True
        End If
    End Sub

    Private Sub RdBJuridica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBJuridica.CheckedChanged
        If Me.RdBJuridica.Checked = True Then
            Me.txt_insc.Enabled = True
            Me.msk_cnpj.Enabled = True
            Me.msk_txtcpf.Enabled = False
            Me.txt_ident.Enabled = False
        End If
    End Sub
    Private Sub AlfaMaiuscula()
        Me.txt_RazaoSocial.CharacterCasing = CharacterCasing.Upper
        Me.txt_insc.CharacterCasing = CharacterCasing.Upper
        Me.txt_Fantasia.CharacterCasing = CharacterCasing.Upper
        Me.txt_endereco.CharacterCasing = CharacterCasing.Upper
        Me.txt_bairro.CharacterCasing = CharacterCasing.Upper
        Me.txt_cidade.CharacterCasing = CharacterCasing.Upper
        Me.txt_preposto.CharacterCasing = CharacterCasing.Upper
        Me.txt_ident.CharacterCasing = CharacterCasing.Upper
        Me.txt_obs1.CharacterCasing = CharacterCasing.Upper
        Me.txt_obs2.CharacterCasing = CharacterCasing.Upper
        Me.txt_obs3.CharacterCasing = CharacterCasing.Upper
        Me.txt_RazaoSocial.Modified = True
    End Sub

    Private Function Testa_controle() As Boolean
        Try
            If Me.cbo_uf.SelectedIndex = -1 Then
                MessageBox.Show(Me.cbo_uf.SelectedItem.ToString, "Item Selecionado ")
            End If
            If Me.RdBFisica.Checked = False And Me.RdBJuridica.Checked = False Then
                MessageBox.Show("Erro Caracteristica", "Fisica ou Juridica ")

            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("Item não selecionado ", "Erro UF")
            Me.txt_Fantasia.Focus()
            Return False
        End Try
    End Function
#Region "Configura Eventos e Teclas "

    Private Sub txt_RazaoSocial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_RazaoSocial.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If Me.RdBFisica.Checked = False And Me.RdBJuridica.Checked = False Then
                MessageBox.Show("Fisica ou Juridica ? ", " Erro Caracteristica ", MessageBoxButtons.OK, MessageBoxIcon.Question)
            End If
            Me.txt_Fantasia.Focus()
        End If
        If (e.KeyCode = Keys.Up) Then
            Me.dtp_cadastro.Focus()
        End If
    End Sub

    Private Sub txt_Fantasia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Fantasia.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Me.msk_nascativ.Focus()
        End If
        If (e.KeyCode = Keys.Up) Then
            Me.txt_RazaoSocial.Focus()
        End If
    End Sub

    Private Sub dtp_nascativ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            Me.txt_endereco.Focus()
        End If
        If (e.KeyCode = Keys.Up) Then
            Me.txt_Fantasia.Focus()
        End If
    End Sub
    Private Sub txt_endereco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_endereco.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Me.txt_cidade.Focus()
        End If
        If (e.KeyCode = Keys.Up) Then
            Me.msk_nascativ.Focus()
        End If
    End Sub

    Private Sub txt_cidade_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cidade.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.txt_endereco.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.cbo_uf.Focus()
        End If

    End Sub

    Private Sub cbo_uf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_uf.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.txt_cidade.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.txt_bairro.Focus()
        End If

    End Sub

    Private Sub txt_bairro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_bairro.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.cbo_uf.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.msk_cep.Focus()
        End If
    End Sub

    Private Sub msk_cep_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_cep.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.txt_bairro.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.msk_txtfone.Focus()
        End If
    End Sub

    Private Sub msk_txtfone_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_txtfone.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.msk_cep.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.msk_txtfax.Focus()
        End If
    End Sub

    Private Sub msk_txtfax_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_txtfax.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.msk_txtfone.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.msk_celular.Focus()
        End If
    End Sub

    Private Sub msk_celular_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_celular.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.msk_txtfax.Focus()
        End If
        
    End Sub

    Private Sub txt_vendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyCode = Keys.Up) Then
            Me.msk_celular.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.txt_preposto.Focus()
        End If
    End Sub

    Private Sub txt_preposto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_preposto.KeyDown
        If Me.RdBFisica.Checked = True Then
            If (e.KeyCode = Keys.Enter) Then
                Me.txt_ident.Focus()
            End If
        Else
            If (e.KeyCode = Keys.Enter) Then
                Me.msk_cnpj.Focus()
            End If
        End If

    End Sub

    Private Sub txt_ident_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ident.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.txt_preposto.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.msk_txtcpf.Focus()
        End If
    End Sub

    Private Sub msk_txtcpf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_txtcpf.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.txt_ident.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.msk_limite.Focus()
        End If
    End Sub

    Private Sub msk_cnpj_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_cnpj.KeyDown
        If Me.RdBJuridica.Checked = True Then
            If (e.KeyCode = Keys.Up) Then
                Me.txt_preposto.Focus()
            End If
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.txt_insc.Focus()
        End If
    End Sub

    Private Sub txt_insc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_insc.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.msk_cnpj.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.msk_limite.Focus()
        End If
    End Sub

    Private Sub msk_limite_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_limite.KeyDown
        If Me.RdBFisica.Checked = True Then
            If (e.KeyCode = Keys.Up) Then
                Me.msk_txtcpf.Focus()
            End If
        Else
            If (e.KeyCode = Keys.Up) Then
                Me.txt_insc.Focus()
            End If
        End If
        If (e.KeyCode = Keys.Enter) Then
            HorizontalAlignment.Right.ToString()
            Me.chk_consumo.Focus()
        End If
    End Sub

    Private Sub chk_consumo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chk_consumo.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.msk_limite.Focus()
        End If

        If (e.KeyCode = Keys.Enter) Then
            Me.chk_bloqueio.Focus()
        End If
    End Sub

    Private Sub chk_bloqueio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chk_bloqueio.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.chk_consumo.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.chk_etiqueta.Focus()
        End If
    End Sub

    Private Sub chk_etiqueta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chk_etiqueta.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.chk_bloqueio.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.txt_obs1.Focus()
        End If
    End Sub

    Private Sub txt_obs1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_obs1.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.chk_etiqueta.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.txt_obs2.Focus()
        End If
    End Sub

    Private Sub txt_obs2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_obs2.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.txt_obs1.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.txt_obs3.Focus()
        End If
    End Sub

    Private Sub txt_obs3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_obs3.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.txt_obs2.Focus()
        End If

    End Sub

    Private Sub grp_caracteristica_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grp_caracteristica.KeyDown
        If (e.KeyCode = Keys.Up) Then
            Me.grp_Tipo.Focus()
        End If
        If (e.KeyCode = Keys.Enter) Then
            Me.dtp_cadastro.Focus()
        End If
    End Sub

    Private Sub dtp_cadastro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp_cadastro.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Me.txt_RazaoSocial.Focus()
        End If
    End Sub
#End Region

    
End Class