Imports System.data
Imports System.Text
Imports System.IO
Imports Npgsql

Public Class Frm_Gcadgeno1

    Dim Conex As NpgsqlConnection
    Dim oDa As NpgsqlDataAdapter
    Dim oCmdB As NpgsqlCommandBuilder
    Dim tbGeno As New DataTable
    Public mode As String = "A"

    Private Sub Frm_Gcadgeno1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If (e.KeyCode = Keys.Escape) Then
            Conex.Close()
            Me.txt_codigo.Text = ""
            Me.Close()

        End If


    End Sub

    Private Sub Frm_Gcadgeno1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.txt_razaosocial.Focus()
            Conex = New NpgsqlConnection(ModuloConexaoBD.conectionPadrao)
            Dim sql As StringBuilder = New StringBuilder
            sql.Append("SELECT g_codig,g_razaosocial,g_geno,g_ender,g_bairro,g_cid, ")
            sql.Append("g_uf, g_cep, g_cgc, g_insc, g_email, g_fone, g_fax, g_aidf,")
            sql.Append("g_iniform, g_fimform, g_codmun,g_coduf, g_loja FROM Geno001 order by g_codig")
            oDa = New Npgsql.NpgsqlDataAdapter(sql.ToString, Conex)
            oCmdB = New Npgsql.NpgsqlCommandBuilder(oDa)
            oDa.Fill(tbGeno)

            Me.BindingSource1.DataSource = tbGeno
            Me.BindingNavigator1.BindingSource = Me.BindingSource1
            VinculaDados()
            sql = Nothing

        Catch ex As NpgsqlException
            MessageBox.Show("Erro na Abertura da Tabela Geno001 " & ex.ToString, "Erro de Tabela", MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show("Erro na Abertura da Tabela Geno001 ", "Erro de Tabela", MessageBoxButtons.OK)

        End Try



    End Sub

    Private Sub VinculaDados()

        Me.txt_codigo.DataBindings.Add("Text", Me.BindingSource1, "g_codig")
        Me.txt_razaosocial.DataBindings.Add("Text", Me.BindingSource1, "g_razaosocial")
        Me.txt_fantasia.DataBindings.Add("Text", Me.BindingSource1, "g_geno")
        Me.txt_endereco.DataBindings.Add("Text", Me.BindingSource1, "g_ender")
        Me.txt_bairro.DataBindings.Add("Text", Me.BindingSource1, "g_bairro")
        Me.txt_cidade.DataBindings.Add("Text", Me.BindingSource1, "g_cid")
        Me.txt_uf.DataBindings.Add("Text", Me.BindingSource1, "g_uf")
        Me.msk_cep.DataBindings.Add("Text", Me.BindingSource1, "g_cep")
        Me.msk_cnpj.DataBindings.Add("Text", Me.BindingSource1, "g_cgc")
        Me.txt_inscricao.DataBindings.Add("Text", Me.BindingSource1, "g_insc")
        Me.txt_email.DataBindings.Add("Text", Me.BindingSource1, "g_email")
        Me.msk_fone.DataBindings.Add("Text", Me.BindingSource1, "g_fone")
        Me.msk_fax.DataBindings.Add("Text", Me.BindingSource1, "g_fax")
        Me.txt_Coduf.DataBindings.Add("Text", Me.BindingSource1, "g_coduf")
        Me.txt_forminicio.DataBindings.Add("Text", Me.BindingSource1, "g_iniform")
        Me.txt_formfinal.DataBindings.Add("Text", Me.BindingSource1, "g_fimform")
        Me.txt_codmun.DataBindings.Add("Text", Me.BindingSource1, "g_codmun")
        Me.txt_loja.DataBindings.Add("Text", Me.BindingSource1, "g_loja")


    End Sub

    Private Sub tsb_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_salvar.Click

        Try
            Me.BindingSource1.EndEdit()
            tbGeno = Me.BindingSource1.DataSource
            Me.oDa.Update(tbGeno.DataSet)
            tbGeno.AcceptChanges()
            Me.lbl_mensagem.Text = "Alteração Realizada com Sucesso !"

        Catch ex As System.IO.IOException
            MsgBox(ex.ToString & "Um Erro Ocorrrido")
            tbGeno.RejectChanges()

        Catch ex As Npgsql.NpgsqlException
            MessageBox.Show(ex.ToString)
            tbGeno.RejectChanges()

        Catch ex As Exception
            MessageBox.Show("ERRO:: " & ex.Message) ', "Gravação ", MessageBoxButtons.OK)
            tbGeno.RejectChanges()

        End Try
        mode = "A"



    End Sub



    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        If mode = "I" Then
            Conex = New NpgsqlConnection(ModuloConexaoBD.conectionPadrao)
            Dim msql As StringBuilder = New StringBuilder
            msql.Append("SELECT g_codig,g_razaosocial,g_geno,g_ender,g_bairro,g_cid, ")
            msql.Append("g_uf, g_cep, g_cgc, g_insc, g_email, g_fone, g_fax, g_aidf,")
            msql.Append("g_iniform, g_fimform, g_codmun,g_coduf, g_loja FROM Geno001 where g_codig=@pesq")

            Dim cmd As NpgsqlCommand = New NpgsqlCommand(msql.ToString, Conex)
            cmd.Parameters.Add("@pesq", Me.txt_codigo.Text.ToString)

            Try
                Conex.Open()
                Dim dr As NpgsqlDataReader = cmd.ExecuteReader
                Dim achaReg As Boolean = dr.Read

                If achaReg = True Then
                    MsgBox("Codigo de Empresa ja Existente, Tente Outro !")
                    Me.txt_codigo.Focus()

                Else

                    Me.txt_loja.Text = Mid(Me.txt_codigo.Text, 3, 3)
                    Me.txt_razaosocial.Focus()
                    Conex.Close()

                End If

            Catch ex As NpgsqlException
                MsgBox("Erro Critico " & ex.Message, MsgBoxStyle.Critical)
                Conex.Close()

            Catch ex As Exception
                MsgBox("Erro Critico " & ex.Message, MsgBoxStyle.Critical)
                Conex.Close()

            End Try
        End If



    End Sub

    Private Sub txt_codigo_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyDown

        If (e.KeyCode = Keys.Enter) Then Me.txt_razaosocial.Focus()

    End Sub

    Private Sub txt_codmun_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codmun.LostFocus

        If Not IsNumeric(Me.txt_codmun.Text) Then
            MsgBox("Favor Digite Somente Numeros !", MsgBoxStyle.Information)
            Me.txt_codmun.Text = ""
            Me.txt_codmun.Focus()

        End If


    End Sub

    'Private Sub txt_bairro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_bairro.KeyDown

    '    Select Case e.KeyCode
    '        Case Keys.Up
    '            Me.txt_endereco.Focus()

    '        Case Keys.Enter
    '            Me.txt_cidade.Focus()

    '    End Select



    'End Sub
    'Private Sub txt_cidade_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cidade.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.txt_bairro.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.txt_uf.Focus()
    '    End If
    'End Sub

    'Private Sub txt_uf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_uf.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.txt_cidade.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.msk_cep.Focus()
    '    End If
    'End Sub
    'Private Sub msk_cep_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_cep.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.txt_uf.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.txt_codmun.Focus()
    '    End If
    'End Sub
    'Private Sub txt_codmun_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codmun.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.msk_cep.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.msk_cnpj.Focus()
    '    End If
    'End Sub


    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click

        mode = "I"

    End Sub

    'Private Sub msk_cnpj_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_cnpj.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.txt_codmun.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.txt_inscricao.Focus()
    '    End If
    'End Sub

    'Private Sub txt_inscricao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_inscricao.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.msk_cnpj.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.txt_email.Focus()
    '    End If
    'End Sub

    'Private Sub txt_email_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_email.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.txt_inscricao.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.msk_fone.Focus()
    '    End If
    'End Sub

    'Private Sub msk_fone_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_fone.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.txt_email.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.msk_fax.Focus()
    '    End If
    'End Sub

    'Private Sub msk_fax_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_fax.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.msk_fone.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.txt_Coduf.Focus()
    '    End If
    'End Sub



    'Private Sub txt_forminicio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_forminicio.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.txt_Coduf.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.txt_formfinal.Focus()
    '    End If
    'End Sub

    'Private Sub txt_formfinal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_formfinal.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.txt_forminicio.Focus()
    '    End If

    'End Sub

    'Private Sub txt_razaosocial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_razaosocial.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.txt_fantasia.Focus()
    '    End If
    'End Sub

    'Private Sub txt_fantasia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_fantasia.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.txt_razaosocial.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.txt_endereco.Focus()
    '    End If
    'End Sub

    'Private Sub txt_endereco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_endereco.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.txt_fantasia.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.txt_bairro.Focus()
    '    End If
    'End Sub

    'Private Sub txt_Coduf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Coduf.KeyDown
    '    If (e.KeyCode = Keys.Up) Then
    '        Me.msk_fax.Focus()
    '    End If
    '    If (e.KeyCode = Keys.Enter) Then
    '        Me.txt_forminicio.Focus()
    '    End If
    'End Sub

    Private Sub Frm_Gcadgeno1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

End Class