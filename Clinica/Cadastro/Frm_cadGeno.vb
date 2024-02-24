Imports System
Imports Npgsql
Imports System.Data
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Frm_cadGeno

    Dim _clBD As New Cl_bdMetrosys
    Dim _clFuncoes As New Funcoes

    Private Const _vlrZERO As Integer = 0
    Private _ufCorrenteCbo As String = ""
    Private _alterando As Boolean = False, _incluindo As Boolean = False

    Private Sub Frm_cadGeno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cbo_uf.Items.Add("AC") : Me.cbo_uf.Items.Add("AL") : Me.cbo_uf.Items.Add("AP")
        Me.cbo_uf.Items.Add("AM") : Me.cbo_uf.Items.Add("BA") : Me.cbo_uf.Items.Add("CE")
        Me.cbo_uf.Items.Add("DF") : Me.cbo_uf.Items.Add("ES") : Me.cbo_uf.Items.Add("EX")
        Me.cbo_uf.Items.Add("GO") : Me.cbo_uf.Items.Add("MA") : Me.cbo_uf.Items.Add("MT")
        Me.cbo_uf.Items.Add("MS") : Me.cbo_uf.Items.Add("MG") : Me.cbo_uf.Items.Add("PA")
        Me.cbo_uf.Items.Add("PB") : Me.cbo_uf.Items.Add("PE") : Me.cbo_uf.Items.Add("PI")
        Me.cbo_uf.Items.Add("RJ") : Me.cbo_uf.Items.Add("RN") : Me.cbo_uf.Items.Add("RS")
        Me.cbo_uf.Items.Add("RD") : Me.cbo_uf.Items.Add("RR") : Me.cbo_uf.Items.Add("SC")
        Me.cbo_uf.Items.Add("SP") : Me.cbo_uf.Items.Add("SE") : Me.cbo_uf.Items.Add("TO")

        dtg_produto.Refresh()
        preencheDtg_Geno()
        preencheDtg_Vinculos()

        cbo_vinculo = _clFuncoes.PreenchComboVinculo(cbo_vinculo, MdlConexaoBD.conectionPadrao)
        cbo_esqEstab = _clFuncoes.PreenchComboEsquema(cbo_esqEstab, MdlConexaoBD.conectionPadrao)
        cbo_esqVinc = _clFuncoes.PreenchComboEsquema(cbo_esqVinc, MdlConexaoBD.conectionPadrao)

    End Sub

    Private Sub cbo_uf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_uf.Leave

        If _ufCorrenteCbo.Equals("") Then

            If cbo_uf.SelectedIndex >= _vlrZERO Then

                Me.cbo_cidade = _clFuncoes.PreenchComboMunicipios(Me.cbo_uf.SelectedItem, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
                _ufCorrenteCbo = Me.cbo_uf.Text
            End If

        ElseIf cbo_uf.SelectedIndex > _vlrZERO And Not _ufCorrenteCbo.Equals(cbo_uf.Text) Then

            Me.cbo_cidade = _clFuncoes.PreenchComboMunicipios(Me.cbo_uf.SelectedItem, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
            _ufCorrenteCbo = Me.cbo_uf.Text

        End If


    End Sub

    Private Sub Frm_cadGeno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                preencheDtg_Geno()

        End Select

    End Sub

    Private Sub Frm_cadGeno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub cbo_cidade_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cidade.Leave

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Me.txt_codmun.Text = _clBD.trazCodMun(conection, Me.cbo_uf.SelectedItem, Me.cbo_cidade.SelectedItem)
        Me.txt_Coduf.Text = Mid(Me.txt_codmun.Text, 1, 2)
        conection.ClearAllPools() : conection.Close() : conection = Nothing


    End Sub

    Private Sub preencheDtg_Geno()

        Dim pesquisa As String = (Me.txt_pesquisa.Text).ToUpper
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearAllPools() : conection = Nothing : Return

        End Try

        Dim cmdGeno As New NpgsqlCommand
        Dim sqlGeno As New StringBuilder
        Dim drGeno As NpgsqlDataReader


        Dim codigo, nome, cnpj, inscricao As String

        Try

            'SELECT g_codig, g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, 
            'g_insc, g_fone, g_fax, g_mun, g_coduf, g_email, g_razaosocial, 
            'g_bairro, g_aidf, g_iniform, g_fimform, g_codmun, g_loja
            'FROM geno001;

            sqlGeno.Append("SELECT g_codig, g_geno, g_cgc, g_insc FROM geno001 WHERE ") ' 5

            If Me.Rdb_cnpj.Checked = True Then
                sqlGeno.Append("UPPER(g_cgc) LIKE @pesquisa ORDER BY g_codig ASC")
            ElseIf Rdb_nome.Checked = True Then
                sqlGeno.Append("UPPER(g_geno) LIKE @pesquisa ORDER BY g_codig ASC")
            Else
                sqlGeno.Append("UPPER(g_insc) LIKE @pesquisa ORDER BY g_codig ASC")
            End If


            cmdGeno = New NpgsqlCommand(sqlGeno.ToString, conection)
            If Rdb_nome.Checked = True Then
                cmdGeno.Parameters.Add("@pesquisa", "%" & pesquisa)
            Else
                cmdGeno.Parameters.Add("@pesquisa", pesquisa & "%")
            End If


            drGeno = cmdGeno.ExecuteReader
            dtg_produto.Rows.Clear() : dtg_produto.Refresh()
            While drGeno.Read
                codigo = drGeno(0).ToString
                nome = drGeno(1).ToString
                cnpj = drGeno(2).ToString
                inscricao = drGeno(3).ToString

                Try
                    dtg_produto.Rows.Add(codigo, nome, cnpj, inscricao)
                Catch ex As Exception
                End Try


            End While

            dtg_produto.Refresh() : drGeno.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection = Nothing : Return

        End Try

        cmdGeno.CommandText = "" : sqlGeno.Remove(0, sqlGeno.ToString.Length)
        conection.ClearAllPools() : conection.Close() : conection = Nothing : cmdGeno = Nothing
        drGeno = Nothing : sqlGeno = Nothing



    End Sub

    Private Sub preencheDtg_Vinculos()

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearAllPools() : conection = Nothing : Return

        End Try

        Dim cmdGeno As New NpgsqlCommand
        Dim sqlGeno As New StringBuilder
        Dim drGeno As NpgsqlDataReader


        Try

            sqlGeno.Append("SELECT v_id, v_codvinc, v_descricao, v_usuario FROM vinculo ORDER BY v_codvinc ASC") ' 4
            cmdGeno = New NpgsqlCommand(sqlGeno.ToString, conection)
            drGeno = cmdGeno.ExecuteReader
            dtg_vinculos.Rows.Clear() : dtg_vinculos.Refresh()
            While drGeno.Read

                Try
                    dtg_vinculos.Rows.Add(drGeno(0).ToString, drGeno(1).ToString, drGeno(2).ToString, _
                                         drGeno(3).ToString)
                Catch ex As Exception
                End Try
            End While

            dtg_vinculos.Refresh() : drGeno.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection = Nothing : Return

        End Try

        cmdGeno.CommandText = "" : sqlGeno.Remove(0, sqlGeno.ToString.Length)
        conection.ClearAllPools() : conection.Close() : conection = Nothing : cmdGeno = Nothing
        drGeno = Nothing : sqlGeno = Nothing



    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        preencheDtg_Geno()

    End Sub

    Private Sub Rdb_nome_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_nome.CheckedChanged

        If Rdb_nome.Checked Then preencheDtg_Geno()

    End Sub

    Private Sub Rdb_cnpj_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_cnpj.CheckedChanged

        If Rdb_nome.Checked Then preencheDtg_Geno()

    End Sub

    Private Sub Rdb_inscricao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_inscricao.CheckedChanged

        If Rdb_nome.Checked Then preencheDtg_Geno()

    End Sub

    Private Function verificaGeno()

        Dim mNaoDeuErro As Boolean = True
        lbl_mensagem02.Text = "" : lbl_mensagem02.Text = ""

        If Trim(Me.txt_razaosocial.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe a Razao Social do Estabelecimento !"
            Return mNaoDeuErro

        End If


        If Trim(Me.txt_endereco.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o ENDEREÇO do Estabelecimento !"
            Return mNaoDeuErro
        End If

        If Me.cbo_uf.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe a UF do Estabelecimento !"
            Return mNaoDeuErro
        End If

        If Me.cbo_cidade.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe a CIDADE do Paricipante !"
            Return mNaoDeuErro
        End If

        If Trim(Me.txt_bairro.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o BAIRRO do Estabelecimento !"
            Return mNaoDeuErro
        End If

        If Trim(Me.msk_cep.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o CEP do Estabelecimento !"
            Return mNaoDeuErro
        End If

        If Trim(Me.msk_fone.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe um Telefone da Estabelecimento !"
            Return mNaoDeuErro
        End If



        If _clBD.existCNPJGeno001(_clFuncoes.RemoverCaracter(Me.msk_cnpj.Text), Me.txt_codigo.Text, MdlConexaoBD.conectionPadrao) Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "CNPJ já existe em outro Estabelecimento !"
            Return mNaoDeuErro
        End If

        If Trim(Me.msk_cnpj.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o CNPJ do Estabelecimento !"
            Return mNaoDeuErro

        ElseIf Not _clBD.ValidaCNPJ(_clFuncoes.RemoverCaracter(Me.msk_cnpj.Text)) Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "CNPJ Incorreto !" : Return mNaoDeuErro

        End If


        If _clBD.existInscricaoGeno001(txt_inscricao.Text, Me.txt_codigo.Text, MdlConexaoBD.conectionPadrao) Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "INSCRIÇÂO já existe em outro Estabelecimento !"
            Return mNaoDeuErro
        End If


        If Trim(Me.txt_inscricao.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe a INSCRIÇÂO do Estabelecimento !"
            Return mNaoDeuErro
        End If

        ' Pattern ou mascara de verificação do email
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\." _
        & "[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"

        If Trim(Me.txt_email.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o EMAIL do Estabelecimento !"
            txt_email.Focus() : txt_email.SelectAll() : Return mNaoDeuErro

        ElseIf Not Regex.Match(Me.txt_email.Text, pattern).Success Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "EMAIL Incorreto !"
            txt_email.Focus() : txt_email.SelectAll() : Return mNaoDeuErro
        End If

        If cbo_vinculo.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o VÍNCULO do Estabelecimento !"
            Return mNaoDeuErro
        End If

        If Trim(Me.txt_codigo.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Código do Estabelecimento não informado !"
            Return mNaoDeuErro
        End If


        Return mNaoDeuErro
    End Function

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If Not txt_codigo.Text.Equals("") Then

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                tbc_produtos.SelectTab(0)
                limpaCamposGeno()
                tbp_cadPrincipal.Text = "Cadastro"
                _incluindo = False : _alterando = False
                Btn_salvar.Enabled = False
            End If
        Else

            tbc_produtos.SelectTab(0)
            limpaCamposGeno()
            tbp_cadPrincipal.Text = "Cadastro"
            _incluindo = False : _alterando = False
            Btn_salvar.Enabled = False
        End If


    End Sub

    Private Sub limpaCamposGeno()

        txt_codigo.Text = "" : txt_razaosocial.Text = ""
        txt_fantasia.Text = "" : txt_endereco.Text = ""
        txt_bairro.Text = ""
        cbo_uf.SelectedIndex = -1
        cbo_cidade.SelectedIndex = -1
        msk_cep.Text = "" : txt_codmun.Text = ""
        txt_Coduf.Text = "" : msk_cnpj.Text = ""
        txt_inscricao.Text = "" : txt_email.Text = ""
        msk_fone.Text = "" : msk_fax.Text = ""
        txt_cnaeFiscal.Text = ""
        cbo_crt.SelectedIndex = -1
        cbo_vinculo.SelectedIndex = -1
        lbl_mensagem01.Text = "" : lbl_mensagem02.Text = ""
        cbo_esqEstab.SelectedIndex = -1
        cbo_esqVinc.SelectedIndex = -1

    End Sub

    Private Sub limpaCamposVinculo()

        lbl_idVinculo.Text = ""
        txt_codVinculo.Text = ""
        txt_descricaoVinc.Text = ""
    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click


        If Not txt_codigo.Text.Equals("") Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Substituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False
                tbc_produtos.SelectTab(1)
                limpaCamposGeno()
                txt_codigo.Focus()
                tbp_cadPrincipal.Text = "Cadastro"
                Btn_salvar.Enabled = True
            End If
        Else

            _incluindo = True : _alterando = False
            tbc_produtos.SelectTab(1)
            limpaCamposGeno() : txt_codigo.Focus()
            tbp_cadPrincipal.Text = "Cadastro"
            Btn_salvar.Enabled = True
        End If



    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If Not txt_codigo.Text.Equals("") Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _alterando = True : _incluindo = False
                tbc_produtos.SelectTab(1)
                limpaCamposGeno()
                trazGenoSelecionado()
                txt_codigo.Focus()
                tbc_produtos.Text = "Alterando"
                Btn_salvar.Enabled = True
            Else

                txt_codigo.Focus()
                Btn_salvar.Enabled = True
            End If

        Else

            _alterando = True : _incluindo = False
            tbc_produtos.SelectTab(1)
            limpaCamposGeno()
            trazGenoSelecionado()
            txt_codigo.Focus()
            tbc_produtos.Text = "Alterando"
            Btn_salvar.Enabled = True

        End If


    End Sub

    Private Sub trazGenoSelecionado()

        Dim codGeno As String = ""
        codGeno = dtg_produto.CurrentRow.Cells(0).Value

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearAllPools() : conection = Nothing : Return

        End Try

        Dim cmdGeno As New NpgsqlCommand
        Dim sqlGeno As New StringBuilder
        Dim drGeno As NpgsqlDataReader

        Dim mcodig, g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, g_insc As String
        Dim g_fone, g_fax, g_mun, g_coduf, g_email, g_razaosocial, g_bairro, g_aidf As String
        Dim g_codmun, g_vinculo, g_cnae, g_crt, g_esquemaestab, g_esquemavinc As String


        mcodig = "" : g_geno = "" : g_ender = "" : g_cid = "" : g_uf = "" : g_cep = "" : g_bair = ""
        g_cgc = "" : g_insc = "" : g_fone = "" : g_fax = "" : g_mun = "" : g_coduf = "" : g_email = ""
        g_razaosocial = "" : g_bairro = "" : g_aidf = "" : g_codmun = "" : g_vinculo = ""
        g_cnae = "" : g_crt = "" : g_esquemaestab = "" : g_esquemavinc = ""

        Try


            sqlGeno.Append("SELECT g_codig, g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, ") '7
            sqlGeno.Append("g_insc, g_fone, g_fax, g_mun, g_coduf, g_email, g_razaosocial, g_bairro, ") '15
            sqlGeno.Append("g_aidf, g_iniform, g_fimform, g_codmun, g_loja, g_cnae, g_crt, g_vinculo, ") '23
            sqlGeno.Append("g_esquemaestab, g_esquemavinc FROM geno001 WHERE g_codig = '" & codGeno & "'") '25

            cmdGeno = New NpgsqlCommand(sqlGeno.ToString, conection)
            drGeno = cmdGeno.ExecuteReader

            While drGeno.Read

                mcodig = drGeno(0).ToString : g_geno = drGeno(1).ToString
                g_ender = drGeno(2).ToString : g_cid = drGeno(3).ToString
                g_uf = drGeno(4).ToString : g_cep = drGeno(5).ToString
                g_bair = drGeno(6).ToString : g_cgc = drGeno(7).ToString
                g_insc = drGeno(8).ToString : g_fone = drGeno(9).ToString
                g_fax = drGeno(10).ToString : g_mun = drGeno(11).ToString
                g_coduf = drGeno(12).ToString : g_email = drGeno(13).ToString
                g_razaosocial = drGeno(14).ToString : g_bairro = drGeno(15).ToString
                g_aidf = drGeno(16).ToString : g_codmun = drGeno(11).ToString
                g_cnae = drGeno(21).ToString : g_crt = drGeno(22).ToString
                g_vinculo = drGeno(23).ToString : g_esquemaestab = drGeno(24).ToString
                : g_esquemavinc = drGeno(25).ToString


                txt_codigo.Text = mcodig : txt_razaosocial.Text = g_razaosocial
                txt_fantasia.Text = g_geno : txt_endereco.Text = g_ender
                txt_bairro.Text = g_bair
                cbo_uf.SelectedIndex = _clFuncoes.trazIndexUF(g_uf, Me.cbo_uf)
                cbo_cidade = _clFuncoes.PreenchComboMunicipios(g_uf, cbo_cidade, MdlConexaoBD.conectionPadrao)
                cbo_cidade.SelectedIndex = _clFuncoes.trazIndexMUN(g_cid, Me.cbo_cidade)
                msk_cep.Text = g_cep : txt_codmun.Text = g_codmun
                txt_Coduf.Text = g_coduf : msk_cnpj.Text = g_cgc
                txt_inscricao.Text = g_insc : txt_email.Text = g_email
                msk_fone.Text = g_fone : msk_fax.Text = g_fax
                txt_cnaeFiscal.Text = g_cnae
                cbo_crt.SelectedIndex = _clFuncoes.trazIndexCboCRT(g_crt, cbo_crt)
                cbo_vinculo.SelectedIndex = _clFuncoes.trazIndexCboVinculo(g_vinculo, cbo_vinculo)
                cbo_esqEstab.SelectedIndex = _clFuncoes.trazIndexCboEsquema(g_esquemaestab, cbo_esqEstab)
                cbo_esqVinc.SelectedIndex = _clFuncoes.trazIndexCboEsquema(g_esquemavinc, cbo_esqVinc)


            End While

            drGeno.Close() : conection.ClearPool() : conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        cmdGeno.CommandText = "" : sqlGeno.Remove(0, sqlGeno.ToString.Length)
        conection = Nothing : cmdGeno = Nothing : drGeno = Nothing : sqlGeno = Nothing




    End Sub

    Private Sub Btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_salvar.Click

        If _incluindo Then

            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            conection.Open()
            txt_codigo.Text = "G" & String.Format("{0:D4}", _clBD.trazProxCodGeno(conection))
            conection.ClearPool() : conection.Close() : conection = Nothing

        End If

        If verificaGeno() = True Then

            If _incluindo = True Then

                btn_salvar_Click_Incluindo()
            ElseIf _alterando = True Then
                btn_salvar_Click_Alterando()
            End If
        End If


    End Sub

    Private Sub btn_salvar_Click_Incluindo()

        Dim transacao As NpgsqlTransaction
        Try
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            conection.Open()
            transacao = conection.BeginTransaction
            salvaProdutoIncluindo(conection, transacao)
            transacao.Commit()

            If MessageBox.Show("Estabelecimento salvo com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False : Btn_salvar.Enabled = True
                txt_razaosocial.Text = ""
                txt_codigo.Text = ""
                txt_codigo.Focus() : conection.ClearAllPools() : conection.Close() : transacao = Nothing
                conection = Nothing
            Else

                _incluindo = False : _alterando = False
                Btn_salvar.Enabled = False
                tbc_produtos.SelectTab(0)

                limpaCamposGeno() : preencheDtg_Geno() : txt_pesquisa.Focus()
                conection.ClearAllPools() : conection.Close() : transacao = Nothing : conection = Nothing
            End If


        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()
            Catch ex1 As Exception
            End Try
        End Try


    End Sub

    Private Sub salvaProdutoIncluindo(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        Dim mcodig, g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, g_insc As String
        Dim g_fone, g_fax, g_mun, g_coduf, g_email, g_razaosocial, g_aidf As String
        Dim g_cnae, g_crt, g_esqestab, g_esqvinc As String
        Dim g_vinculo As Integer


        mcodig = "" : g_geno = "" : g_ender = "" : g_cid = "" : g_uf = "" : g_cep = "" : g_bair = ""
        g_cgc = "" : g_insc = "" : g_fone = "" : g_fax = "" : g_mun = "" : g_coduf = "" : g_email = ""
        g_razaosocial = "" : g_aidf = "" : g_cnae = "" : g_crt = "" : g_esqestab = ""
        g_esqvinc = "" : g_vinculo = _vlrZERO


        mcodig = txt_codigo.Text
        g_razaosocial = txt_razaosocial.Text
        g_geno = txt_fantasia.Text : g_ender = txt_endereco.Text
        g_bair = txt_bairro.Text
        g_uf = Me.cbo_uf.SelectedItem
        g_cid = Me.cbo_cidade.SelectedItem
        g_cep = _clFuncoes.RemoverCaracter(msk_cep.Text) : g_mun = txt_codmun.Text
        g_coduf = txt_Coduf.Text : g_cgc = _clFuncoes.RemoverCaracter(msk_cnpj.Text)
        g_insc = txt_inscricao.Text : g_email = txt_email.Text
        g_fone = _clFuncoes.RemoverCaracter(msk_fone.Text) : g_fax = _clFuncoes.RemoverCaracter(msk_fax.Text)
        g_cnae = txt_cnaeFiscal.Text
        g_crt = Mid(cbo_crt.SelectedItem, 1, 1)
        If cbo_vinculo.SelectedIndex >= _vlrZERO Then g_vinculo = Mid(cbo_vinculo.SelectedItem, 1, 1)
        If cbo_esqEstab.SelectedIndex >= _vlrZERO Then g_esqestab = cbo_esqEstab.SelectedItem
        If cbo_esqVinc.SelectedIndex >= _vlrZERO Then g_esqvinc = cbo_esqVinc.SelectedItem

        _clBD.incGeno001(mcodig, g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, _
                         g_insc, g_fone, g_fax, g_mun, g_coduf, g_email, g_razaosocial, _
                         g_aidf, g_vinculo, g_cnae, g_crt, g_esqestab, g_esqvinc, conection, transacao)

    End Sub

    Private Sub btn_salvar_Click_Alterando()

        Dim transacao As NpgsqlTransaction
        Try
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            If conection.State = ConnectionState.Closed Then conection.Open()
            transacao = conection.BeginTransaction
            salvaProdutoAlterando(conection, transacao)
            transacao.Commit()

            MsgBox("Estabelecimento salvo com sucesso", MsgBoxStyle.Exclamation)

            _incluindo = False : _alterando = False
            Btn_salvar.Enabled = False
            tbc_produtos.SelectTab(0)

            limpaCamposGeno() : preencheDtg_Geno() : txt_pesquisa.Focus()
            conection.ClearAllPools() : conection.Close() : transacao = Nothing : conection = Nothing

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()
            Catch ex1 As Exception
            End Try
        End Try


    End Sub

    Private Sub salvaProdutoAlterando(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        Dim mcodig, g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, g_insc As String
        Dim g_fone, g_fax, g_mun, g_coduf, g_email, g_razaosocial, g_aidf As String
        Dim g_cnae, g_crt, g_esqestab, g_esqvinc As String
        Dim g_vinculo As Integer


        mcodig = "" : g_geno = "" : g_ender = "" : g_cid = "" : g_uf = "" : g_cep = "" : g_bair = ""
        g_cgc = "" : g_insc = "" : g_fone = "" : g_fax = "" : g_mun = "" : g_coduf = "" : g_email = ""
        g_razaosocial = "" : g_aidf = "" : g_cnae = "" : g_crt = "" : g_crt = "" : g_esqestab = ""
        g_esqvinc = "" : g_vinculo = _vlrZERO

        mcodig = txt_codigo.Text
        g_razaosocial = txt_razaosocial.Text
        g_geno = txt_fantasia.Text : g_ender = txt_endereco.Text
        g_bair = txt_bairro.Text

        g_uf = Me.cbo_uf.SelectedItem
        g_cid = Me.cbo_cidade.SelectedItem
        g_cep = _clFuncoes.RemoverCaracter(msk_cep.Text) : g_mun = txt_codmun.Text
        g_coduf = txt_Coduf.Text : g_cgc = _clFuncoes.RemoverCaracter(msk_cnpj.Text)
        g_insc = txt_inscricao.Text : g_email = txt_email.Text
        g_fone = _clFuncoes.RemoverCaracter(msk_fone.Text) : g_fax = _clFuncoes.RemoverCaracter(msk_fax.Text)
        g_cnae = txt_cnaeFiscal.Text
        g_crt = Mid(cbo_crt.SelectedItem, 1, 1)

        If cbo_vinculo.SelectedIndex >= _vlrZERO Then g_vinculo = Mid(cbo_vinculo.SelectedItem, 1, 1)
        If cbo_esqEstab.SelectedIndex >= _vlrZERO Then g_esqestab = cbo_esqEstab.SelectedItem
        If cbo_esqVinc.SelectedIndex >= _vlrZERO Then g_esqvinc = cbo_esqVinc.SelectedItem


        _clBD.altGeno001(mcodig, g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, _
                         g_insc, g_fone, g_fax, g_mun, g_coduf, g_email, g_razaosocial, _
                         g_aidf, g_vinculo, g_cnae, g_crt, g_esqestab, g_esqvinc, conection, transacao)

    End Sub

    Private Sub btn_GravaVinc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GravaVinc.Click


        If Trim(txt_descricaoVinc.Text).Equals("") Then

            MsgBox("Por Favor Informe a descrição do VÍNCULO", MsgBoxStyle.Exclamation)
        Else


            Dim transacao As NpgsqlTransaction
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try
                conection.Open()
                transacao = conection.BeginTransaction

                If txt_codVinculo.Text.Equals("") Then

                    Dim codVinculo As Int32 = _clBD.trazProxCodVínculo(conection)
                    _clBD.incVinculo(codVinculo, txt_descricaoVinc.Text, MdlUsuarioLogando._usuarioLogin, _
                                     conection, transacao)
                    codVinculo = Nothing

                Else

                    _clBD.altVinculo(Convert.ToInt32(lbl_idVinculo.Text), txt_descricaoVinc.Text, _
                                     MdlUsuarioLogando._usuarioLogin, conection, transacao)
                End If

                transacao.Commit()
                MsgBox("VÍNCULO salvo com sucesso", MsgBoxStyle.Exclamation)

                limpaCamposVinculo() : preencheDtg_Vinculos()
                cbo_vinculo = _clFuncoes.PreenchComboVinculo(cbo_vinculo, MdlConexaoBD.conectionPadrao)
                conection.ClearAllPools() : conection.Close() : transacao = Nothing : conection = Nothing

            Catch ex As Exception
                MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                Try
                    transacao.Rollback()
                    conection.ClearAllPools() : conection.Close()
                Catch ex1 As Exception
                    conection.ClearAllPools() : conection.Close()
                End Try
            End Try

        End If
    End Sub

    Private Sub deletaVinculoF4()

        If dtg_vinculos.CurrentRow.IsNewRow = False Then


            If MessageBox.Show("Deseja realmente Deletar esse vínculo?", "METROSYS", MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim transacao As NpgsqlTransaction
                Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Try
                    conection.Open()
                    transacao = conection.BeginTransaction

                    Dim idVinculo As Int32 = dtg_vinculos.CurrentRow.Cells(0).Value
                    _clBD.delVinculo(idVinculo, conection, transacao)
                    idVinculo = Nothing

                    transacao.Commit()
                    MsgBox("VÍNCULO DELETADO com sucesso", MsgBoxStyle.Exclamation)

                    limpaCamposVinculo() : preencheDtg_Vinculos()
                    cbo_vinculo = _clFuncoes.PreenchComboVinculo(cbo_vinculo, MdlConexaoBD.conectionPadrao)
                    conection.ClearAllPools() : conection.Close() : transacao = Nothing : conection = Nothing

                Catch ex As Exception
                    MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                    Try
                        transacao.Rollback()
                    Catch ex1 As Exception
                    End Try
                End Try

            End If
        End If


    End Sub

    Private Sub dtg_vinculos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtg_vinculos.KeyDown

        Select Case e.KeyCode

            Case Keys.F4
                deletaVinculoF4()

            Case Keys.Delete
                deletaVinculoF4()

            Case Keys.Enter

                If dtg_vinculos.CurrentRow.IsNewRow = False Then

                    lbl_idVinculo.Text = dtg_vinculos.CurrentRow.Cells(0).Value
                    txt_codVinculo.Text = dtg_vinculos.CurrentRow.Cells(1).Value
                    txt_descricaoVinc.Text = dtg_vinculos.CurrentRow.Cells(2).Value
                    txt_codVinculo.Focus()
                End If
        End Select
    End Sub

    Private Sub btn_delVinc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delVinc.Click

        deletaVinculoF4()
    End Sub

    Private Sub dtg_vinculos_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtg_vinculos.MouseDoubleClick

        If dtg_vinculos.CurrentRow.IsNewRow = False Then

            lbl_idVinculo.Text = dtg_vinculos.CurrentRow.Cells(0).Value
            txt_codVinculo.Text = dtg_vinculos.CurrentRow.Cells(1).Value
            txt_descricaoVinc.Text = dtg_vinculos.CurrentRow.Cells(2).Value
            txt_codVinculo.Focus()
        End If
    End Sub
End Class