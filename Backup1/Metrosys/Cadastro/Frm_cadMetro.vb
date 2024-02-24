Imports System
Imports Npgsql
Imports System.Data
Imports System.Text
Imports System.Math
Imports System.Text.RegularExpressions

Public Class Frm_cadMetro

    Dim _clBD As New Cl_bdMetrosys
    Dim _clFuncoes As New ClFuncoes
    Private _clGeno As New Cl_Geno
    Private _clGenp As New Cl_Genp001

    Private Const _vlrZERO As Integer = 0
    Private _ufCorrenteCbo As String = ""
    Private _alterando As Boolean = False, _incluindo As Boolean = False
    Private _alteraConfiguracoes As Boolean = False

    Public Shared _frmRef As New Frm_cadMetro
    Public _privilegio As Boolean = False
    Dim frmLoginGeral As New Frm_LoginGeral

    Private Sub Frm_cadGeno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.tbp_config1.Parent = Nothing 'Oculta Tab Page Config1
        Me.tbp_config2.Parent = Nothing 'Oculta Tab Page Config2
        Me.tbp_dispositivos.Parent = Nothing 'Oculta Tab Page Config Dispositivos

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
        cbo_esqEstab = _clFuncoes.PreenchComboEsquemaLojas(cbo_esqEstab, MdlConexaoBD.conectionPadrao)
        cbo_esqVinc = _clFuncoes.PreenchComboEsquemaVinc(cbo_esqVinc, MdlConexaoBD.conectionPadrao)

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
                executaF5()

        End Select

    End Sub

    Private Sub executaF5()

        preencheDtg_Geno()

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

            sqlGeno.Append("SELECT v_id, v_codvinc, v_descricao, v_usuario, v_codprod FROM vinculo ORDER BY v_codvinc ASC") ' 4
            cmdGeno = New NpgsqlCommand(sqlGeno.ToString, conection)
            drGeno = cmdGeno.ExecuteReader
            dtg_vinculos.Rows.Clear() : dtg_vinculos.Refresh()
            While drGeno.Read

                Try
                    dtg_vinculos.Rows.Add(drGeno(0).ToString, drGeno(1).ToString, drGeno(2).ToString, _
                                         drGeno(3).ToString, drGeno(4).ToString)
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
            txt_razaosocial.Focus() : txt_razaosocial.SelectAll()
            Return mNaoDeuErro

        End If


        If Trim(Me.txt_endereco.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o ENDEREÇO do Estabelecimento !"
            txt_endereco.Focus() : txt_endereco.SelectAll()
            Return mNaoDeuErro
        End If

        If Trim(Me.txt_bairro.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o BAIRRO do Estabelecimento !"
            txt_bairro.Focus() : txt_bairro.SelectAll()
            Return mNaoDeuErro
        End If

        If Me.cbo_uf.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe a UF do Estabelecimento !"
            cbo_uf.Focus()
            Return mNaoDeuErro
        End If

        If Me.cbo_cidade.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe a CIDADE do Paricipante !"
            cbo_cidade.Focus()
            Return mNaoDeuErro
        End If

        If Trim(Me.msk_cep.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o CEP do Estabelecimento !"
            msk_cep.Focus() : msk_cep.SelectAll()
            Return mNaoDeuErro
        End If


        If _clBD.existCNPJGeno001(_clFuncoes.RemoverCaracter(Me.msk_cnpj.Text), Me.txt_codigo.Text, MdlConexaoBD.conectionPadrao) Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "CNPJ já existe em outro Estabelecimento !"
            msk_cnpj.Focus() : msk_cnpj.SelectAll()
            Return mNaoDeuErro
        End If

        If Trim(Me.msk_cnpj.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o CNPJ do Estabelecimento !"
            msk_cnpj.Focus() : msk_cnpj.SelectAll()
            Return mNaoDeuErro

        ElseIf Not _clBD.ValidaCNPJ(_clFuncoes.RemoverCaracter(Me.msk_cnpj.Text)) Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "CNPJ Incorreto !" : msk_cnpj.Focus() : msk_cnpj.SelectAll() : Return mNaoDeuErro

        End If


        If _clBD.existInscricaoGeno001(txt_inscricao.Text, Me.txt_codigo.Text, MdlConexaoBD.conectionPadrao) Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "INSCRIÇÂO já existe em outro Estabelecimento !"
            txt_inscricao.Focus() : txt_inscricao.SelectAll()
            Return mNaoDeuErro
        End If


        If Trim(Me.txt_inscricao.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe a INSCRIÇÂO do Estabelecimento !"
            txt_inscricao.Focus() : txt_inscricao.SelectAll()
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

        If Trim(Me.msk_fone.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe um Telefone da Estabelecimento !"
            msk_fone.Focus() : msk_fone.SelectAll()
            Return mNaoDeuErro
        End If

        If cbo_crt.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe um CRT do Estabelecimento !"
            cbo_crt.Focus()
            Return mNaoDeuErro
        End If

        If cbo_vinculo.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o VÍNCULO do Estabelecimento !"
            cbo_vinculo.Focus()
            Return mNaoDeuErro
        End If

        If cbo_esqEstab.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o Esquema de Estabelecimento desta Loja !"
            cbo_esqEstab.Focus()
            Return mNaoDeuErro
        End If

        If cbo_esqVinc.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Informe o Esquema de Vinculo desta Loja !"
            cbo_esqVinc.Focus()
            Return mNaoDeuErro
        End If

        If Trim(Me.txt_codigo.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem02.Text = "Código do Estabelecimento não informado !"
            txt_codigo.Focus() : txt_codigo.SelectAll()
            Return mNaoDeuErro
        End If


        Return mNaoDeuErro
    End Function

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If Not txt_codigo.Text.Equals("") Then

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                tbc_geno.SelectTab(0)
                limpaCamposGeno()
                tbp_cadPrincipal.Text = "Cadastro"
                _incluindo = False : _alterando = False
                Btn_salvar.Enabled = False
            End If
        Else

            tbc_geno.SelectTab(0)
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
        chk_retencao.Checked = False
        txt_GenoPis.Text = "0,00" : txt_GenoCofins.Text = "0,00"
        txt_GenoCSLL.Text = "0,00" : txt_GenoIRenda.Text = "0,00"
        txt_GenoSN.Text = "0,00"

    End Sub

    Private Sub limpaCamposVinculo()

        lbl_idVinculo.Text = ""
        txt_codVinculo.Text = ""
        txt_descricaoVinc.Text = ""
        txt_seqCodProd.Text = ""
    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click


        If Not txt_codigo.Text.Equals("") Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Substituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False
                tbc_geno.SelectTab(1)
                limpaCamposGeno()
                txt_codigo.Focus()
                tbp_cadPrincipal.Text = "Cadastro"
                Btn_salvar.Enabled = True
            End If
        Else

            _incluindo = True : _alterando = False
            tbc_geno.SelectTab(1)
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
                tbc_geno.SelectTab(1)
                limpaCamposGeno()
                trazGenoSelecionado()
                txt_codigo.Focus()
                tbc_geno.Text = "Alterando"
                Btn_salvar.Enabled = True
            Else

                txt_codigo.Focus()
                Btn_salvar.Enabled = True
            End If

        Else

            _alterando = True : _incluindo = False
            tbc_geno.SelectTab(1)
            limpaCamposGeno()
            trazGenoSelecionado()
            txt_codigo.Focus()
            tbc_geno.Text = "Alterando"
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


        Try


            sqlGeno.Append("SELECT g_codig, g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, ") '7
            sqlGeno.Append("g_insc, g_fone, g_fax, g_mun, g_coduf, g_email, g_razaosocial, ") '14
            sqlGeno.Append("g_loja, g_cnae, g_crt, g_vinculo, g_esquemaestab, g_esquemavinc, g_retencao, ") '21
            sqlGeno.Append("g_pis, g_cofins, g_csll, g_irenda, g_sn ") '26
            sqlGeno.Append("FROM geno001 WHERE g_codig = '" & codGeno & "'")

            cmdGeno = New NpgsqlCommand(sqlGeno.ToString, conection)
            drGeno = cmdGeno.ExecuteReader

            While drGeno.Read

                _clGeno.pCodig = drGeno(0).ToString : _clGeno.pGeno = drGeno(1).ToString
                _clGeno.pEnder = drGeno(2).ToString : _clGeno.pCid = drGeno(3).ToString
                _clGeno.pUf = drGeno(4).ToString : _clGeno.pCep = drGeno(5).ToString
                _clGeno.pBair = drGeno(6).ToString : _clGeno.pCgc = drGeno(7).ToString
                _clGeno.pInsc = drGeno(8).ToString : _clGeno.pFone = drGeno(9).ToString
                _clGeno.pFax = drGeno(10).ToString : _clGeno.pMun = drGeno(11).ToString
                _clGeno.pCoduf = drGeno(12).ToString : _clGeno.pEmail = drGeno(13).ToString
                _clGeno.pRazaosocial = drGeno(14).ToString : _clGeno.pRetencao = drGeno(21)
                _clGeno.pMun = drGeno(11).ToString : _clGeno.pCnae = drGeno(16).ToString
                _clGeno.pCrt = drGeno(17).ToString : _clGeno.pVinculo = drGeno(18).ToString
                _clGeno.pEsquemaestab = drGeno(19).ToString : _clGeno.pEsquemavinc = drGeno(20).ToString
                _clGeno.pPis = drGeno(22) : _clGeno.pCofins = drGeno(23)
                _clGeno.pCsll = drGeno(24) : _clGeno.pIRenda = drGeno(25)
                _clGeno.pSn = drGeno(26)


                txt_codigo.Text = _clGeno.pCodig : txt_razaosocial.Text = _clGeno.pRazaosocial
                txt_fantasia.Text = _clGeno.pGeno : txt_endereco.Text = _clGeno.pEnder
                txt_bairro.Text = _clGeno.pBair
                cbo_uf.SelectedIndex = _clFuncoes.trazIndexUF(_clGeno.pUf, Me.cbo_uf)
                cbo_cidade = _clFuncoes.PreenchComboMunicipios(_clGeno.pUf, cbo_cidade, MdlConexaoBD.conectionPadrao)
                cbo_cidade.SelectedIndex = _clFuncoes.trazIndexMUN(_clGeno.pCid, Me.cbo_cidade)
                msk_cep.Text = _clGeno.pCep : txt_codmun.Text = _clGeno.pMun
                txt_Coduf.Text = _clGeno.pCoduf : msk_cnpj.Text = _clGeno.pCgc
                txt_inscricao.Text = _clGeno.pInsc : txt_email.Text = _clGeno.pEmail
                msk_fone.Text = _clGeno.pFone : msk_fax.Text = _clGeno.pFax
                txt_cnaeFiscal.Text = _clGeno.pCnae
                Me.chk_retencao.Checked = _clGeno.pRetencao
                cbo_crt.SelectedIndex = _clFuncoes.trazIndexCboCRT(_clGeno.pCrt, cbo_crt)
                cbo_vinculo.SelectedIndex = _clFuncoes.trazIndexCboVinculo(_clGeno.pVinculo, cbo_vinculo)
                cbo_esqEstab.SelectedIndex = _clFuncoes.trazIndexCboEsquema(_clGeno.pEsquemaestab, cbo_esqEstab)
                cbo_esqVinc.SelectedIndex = _clFuncoes.trazIndexCboEsquema(_clGeno.pEsquemavinc, cbo_esqVinc)
                txt_GenoPis.Text = Format(_clGeno.pPis, "#,##0.00") : txt_GenoCofins.Text = Format(_clGeno.pCofins, "###,##0.00")
                txt_GenoCSLL.Text = Format(_clGeno.pCsll, "###,##0.00") : txt_GenoIRenda.Text = Format(_clGeno.pIRenda, "###,##0.00")
                txt_GenoSN.Text = Format(_clGeno.pSn, "###,##0.00")

                _clGeno.zeraValores()

            End While

            drGeno.Close() : conection.ClearPool() : conection.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
        End Try

        cmdGeno.CommandText = "" : sqlGeno.Remove(0, sqlGeno.ToString.Length)
        conection = Nothing : cmdGeno = Nothing : drGeno = Nothing : sqlGeno = Nothing




    End Sub

    Private Sub trazGenpSelecionado()

        Dim codGeno As String = ""
        codGeno = dtg_produto.CurrentRow.Cells(0).Value.ToString

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearAllPools() : conection = Nothing : Return

        End Try

        Dim cmdGenp As New NpgsqlCommand
        Dim sqlGenp As New StringBuilder
        Dim drGenp As NpgsqlDataReader


        Try

            sqlGenp.Append("SELECT gp_requis, gp_sai, gp_fat, gp_data, gp_icms, gp_icmse, gp_alqiss, ") '6
            sqlGenp.Append("gp_serv, gp_orca, gp_palm, gp_txreduz, gp_icmred, gp_txcob, gp_txipi, ") '13
            sqlGenp.Append("gp_txga, gp_txesvei, gp_serie, gp_contf, gp_amb, gp_prazo, gp_seqnfe, ") '20
            sqlGenp.Append("gp_mensag, gp_pis, gp_confin, gp_alqsub, gp_carencia, gp_codprod, ") '26
            sqlGenp.Append("gp_codrequis, gp_codmapa, gp_numpedidomp, gp_mapapedido, gp_canc_pedauto, ") '31
            sqlGenp.Append("gp_grade, gp_codreqproc, gp_tipocondpagto, gp_cpfvalidar, gp_tptransfentrada, ") '36
            sqlGenp.Append("gp_tptransfsaida, gp_comisavista, gp_comisaprazo, gp_envioxml, gp_lotxml, ") '41
            sqlGenp.Append("gp_retornoxml, gp_enviadoxml, gp_imagemcarne, gp_sldfiscalnegativo, gp_aplicacao, ") '46
            sqlGenp.Append("gp_tabletenvio, gp_tabletretorno, gp_tabletpathimg, gp_ftptablet, gp_usuarioftptablet, ") '51
            sqlGenp.Append("gp_senhaftptablet, gp_palmenvio, gp_palmretorno, gp_ftppalm, gp_usuarioftppalm, ") '56
            sqlGenp.Append("gp_senhaftppalm, gp_pauta, gp_descontonfe FROM genp001 WHERE gp_geno = @gp_geno")
            

            cmdGenp = New NpgsqlCommand(sqlGenp.ToString, conection)
            cmdGenp.Parameters.Add("@gp_geno", codGeno)
            drGenp = cmdGenp.ExecuteReader

            If drGenp.HasRows = False Then 'Se NÃO existir as configurações da empresa na tabela Genp001

                _clGeno.zeraValores()
                _clGenp.pGeno = codGeno
                Me.txt_geno.Text = _clGenp.pGeno : Me.txt_nomeGeno.Text = dtg_produto.CurrentRow.Cells(1).Value.ToString

                txt_requis.Text = _clGenp.pRequis : txt_sai.Text = _clGenp.pSai
                txt_fat.Text = _clGenp.pFat : txt_icms.Text = _clGenp.pIcms
                txt_icmse.Text = _clGenp.pIcmse : txt_alqiss.Text = _clGenp.pAlqiss
                txt_serv.Text = _clGenp.pServ : txt_orca.Text = _clGenp.pOrca
                txt_palm.Text = _clGenp.pPalm : txt_txreduz.Text = _clGenp.pTxreduz
                txt_icmred.Text = _clGenp.pIcmred : txt_txcob.Text = _clGenp.pTxcob
                txt_txipi.Text = _clGenp.pTxipi : txt_txga.Text = _clGenp.pTxga
                txt_txesvei.Text = _clGenp.pTxesvei : txt_serie.Text = _clGenp.pSerie
                txt_contf.Text = _clGenp.pContf : txt_amb.Text = _clGenp.pAmb
                txt_prazo.Text = _clGenp.pPrazo : txt_seqNFe.Text = _clGenp.pSeqnfe
                lbl_mensag.Text = _clGenp.pMensag : txt_pis.Text = _clGenp.pPis
                txt_confin.Text = _clGenp.pConfin : txt_alqsub.Text = _clGenp.pAlqsub
                txt_carencia.Text = _clGenp.pCarencia : chk_codprod.Checked = _clGenp.pCodprod
                txt_codrequis.Text = _clGenp.pCodrequis : txt_codmapa.Text = _clGenp.pCodmapa
                txt_numpedidomp.Text = _clGenp.pNumpedidomp : txt_mapapedido.Text = _clGenp.pMapapedido
                chk_cancpedauto.Checked = _clGenp.pCanc_pedauto : chk_grade.Checked = _clGenp.pGrade
                txt_codreqproc.Text = _clGenp.pCodreqproc : txt_tipocondpagto.Text = _clGenp.pTipocondpagto
                chk_cpf.Checked = _clGenp.pConfirmCPF
                txt_tpTransfEntrada.Text = _clGenp.pTptransfentrada : txt_tpTransfSaida.Text = _clGenp.pTptransfsaida
                txt_comisAVista.Text = _clGenp.pComisavista : txt_comisAPrazo.Text = _clGenp.pComisaprazo
                chk_pauta.Checked = _clGenp.pauta : chk_descontonfe.Checked = _clGenp.descontonfe

                zeraValoresConfiguracao2()
                zeraValoresConfigDispositivos()

                _alteraConfiguracoes = False
            End If

            While drGenp.Read

                _clGeno.zeraValores()
                _clGenp.pGeno = codGeno
                _clGenp.pRequis = drGenp(0).ToString : _clGenp.pSai = drGenp(1).ToString
                _clGenp.pFat = drGenp(2).ToString
                Try
                    _clGenp.pData = CDate(drGenp(3).ToString)
                Catch ex As Exception
                    _clGenp.pData = Nothing
                End Try

                'Configurações 1...
                _clGenp.pIcms = drGenp(4).ToString : _clGenp.pIcmse = drGenp(5).ToString
                _clGenp.pAlqiss = drGenp(6).ToString : _clGenp.pServ = drGenp(7).ToString
                _clGenp.pOrca = drGenp(8).ToString : _clGenp.pPalm = drGenp(9).ToString
                _clGenp.pTxreduz = drGenp(10).ToString : _clGenp.pIcmred = drGenp(11).ToString
                _clGenp.pTxcob = drGenp(12).ToString : _clGenp.pTxipi = drGenp(13).ToString
                _clGenp.pTxga = drGenp(14).ToString : _clGenp.pTxesvei = drGenp(15).ToString
                _clGenp.pSerie = drGenp(16).ToString : _clGenp.pContf = drGenp(17).ToString
                _clGenp.pAmb = drGenp(18).ToString : _clGenp.pPrazo = drGenp(19).ToString
                _clGenp.pSeqnfe = drGenp(20).ToString : _clGenp.pMensag = drGenp(21).ToString
                _clGenp.pPis = drGenp(22).ToString : _clGenp.pConfin = drGenp(23).ToString
                _clGenp.pAlqsub = drGenp(24).ToString : _clGenp.pCarencia = drGenp(25).ToString
                _clGenp.pCodprod = drGenp(26).ToString : _clGenp.pCodrequis = drGenp(27).ToString
                _clGenp.pCodmapa = drGenp(28).ToString : _clGenp.pNumpedidomp = drGenp(29).ToString
                _clGenp.pMapapedido = drGenp(30).ToString : _clGenp.pCanc_pedauto = drGenp(31).ToString
                _clGenp.pTipocondpagto = drGenp(34).ToString : _clGenp.pConfirmCPF = drGenp(35)
                _clGenp.pTptransfentrada = drGenp(36).ToString : _clGenp.pTptransfsaida = drGenp(37).ToString
                _clGenp.pComisavista = drGenp(38) : _clGenp.pComisaprazo = drGenp(39)
                _clGenp.sldfiscalnegativo = drGenp(45) : _clGenp.aplicacao = drGenp(46)
                _clGenp.pauta = drGenp(58) : _clGenp.descontonfe = drGenp(59)


                'Configurações 2...
                _clGenp.pathEnvioXML = drGenp(40).ToString : _clGenp.pathLotXML = drGenp(41).ToString
                _clGenp.pathRetornoXML = drGenp(42).ToString : _clGenp.pathEnviadoXML = drGenp(43).ToString
                _clGenp.imagemCarne = drGenp(44).ToString

                'Config. Dispositivos...
                _clGenp.pathEnvioTablet = drGenp(47).ToString : _clGenp.pathRetornoTablet = drGenp(48).ToString
                _clGenp.pathImgTablet = drGenp(49).ToString : _clGenp.ftpTablet = drGenp(50).ToString
                _clGenp.usuarioFtpTablet = drGenp(51).ToString
                _clGenp.senhaFtpTablet = drGenp(52).ToString : _clGenp.pathEnvioPalm = drGenp(53).ToString
                _clGenp.pathRetornoPalm = drGenp(54).ToString : _clGenp.ftpPalm = drGenp(55).ToString
                _clGenp.usuarioFtpPalm = drGenp(56).ToString : _clGenp.senhaFtpPalm = drGenp(57).ToString


                'Configurações 1...
                txt_requis.Text = _clGenp.pRequis : txt_sai.Text = _clGenp.pSai
                txt_fat.Text = _clGenp.pFat : txt_icms.Text = Format(_clGenp.pIcms, "#,##0.00")
                txt_icmse.Text = Format(_clGenp.pIcmse, "#,##0.00") : txt_alqiss.Text = Format(_clGenp.pAlqiss, "#,##0.00")
                txt_serv.Text = _clGenp.pServ : txt_orca.Text = _clGenp.pOrca
                txt_palm.Text = _clGenp.pPalm : txt_txreduz.Text = Format(_clGenp.pTxreduz, "#,##0.00")
                txt_icmred.Text = Format(_clGenp.pIcmred, "#,##0.00") : txt_txcob.Text = _clGenp.pTxcob
                txt_txipi.Text = Format(_clGenp.pTxipi, "#,##0.00") : txt_txga.Text = Format(_clGenp.pTxga, "#,##0.00")
                txt_txesvei.Text = Format(_clGenp.pTxesvei, "#,##0.00") : txt_serie.Text = _clGenp.pSerie
                txt_contf.Text = _clGenp.pContf : txt_amb.Text = _clGenp.pAmb
                txt_prazo.Text = _clGenp.pPrazo : txt_seqNFe.Text = _clGenp.pSeqnfe
                lbl_mensag.Text = _clGenp.pMensag : txt_pis.Text = Format(_clGenp.pPis, "#,##0.00")
                txt_confin.Text = Format(_clGenp.pConfin, "#,##0.00") : txt_alqsub.Text = Format(_clGenp.pAlqsub, "#,##0.00")
                txt_carencia.Text = _clGenp.pCarencia : chk_codprod.Checked = _clGenp.pCodprod
                txt_codrequis.Text = _clGenp.pCodrequis : txt_codmapa.Text = _clGenp.pCodmapa
                txt_numpedidomp.Text = _clGenp.pNumpedidomp : txt_mapapedido.Text = _clGenp.pMapapedido
                chk_cancpedauto.Checked = _clGenp.pCanc_pedauto : chk_grade.Checked = _clGenp.pGrade
                txt_codreqproc.Text = _clGenp.pCodreqproc : txt_tipocondpagto.Text = _clGenp.pTipocondpagto
                chk_cpf.Checked = _clGenp.pConfirmCPF
                txt_tpTransfEntrada.Text = _clGenp.pTptransfentrada : txt_tpTransfSaida.Text = _clGenp.pTptransfsaida
                txt_comisAVista.Text = _clGenp.pComisavista : txt_comisAPrazo.Text = _clGenp.pComisaprazo
                chk_sldfiscalnegativo.Checked = _clGenp.sldfiscalnegativo : chk_aplicacao.Checked = _clGenp.aplicacao
                chk_pauta.Checked = _clGenp.pauta : chk_descontonfe.Checked = _clGenp.descontonfe
                txt_geno.Text = _clGenp.pGeno
                txt_nomeGeno.Text = dtg_produto.CurrentRow.Cells(1).Value.ToString


                'Configurações 2...
                txt_pathXmlEnvio.Text = _clGenp.pathEnvioXML : txt_pathXmlLote.Text = _clGenp.pathLotXML
                txt_pathXmlRetorno.Text = _clGenp.pathRetornoXML : txt_pathXmlEnviado.Text = _clGenp.pathEnviadoXML
                txt_ImagemCarne.Text = _clGenp.imagemCarne


                'Config. Dispositivos...
                txt_pathTabletEnvio.Text = _clGenp.pathEnvioTablet : txt_pathTabletRetorno.Text = _clGenp.pathRetornoTablet
                txt_pathImgTablet.Text = _clGenp.pathImgTablet : txt_ftpTablet.Text = _clGenp.ftpTablet
                txt_usuarioFtpTablet.Text = _clGenp.usuarioFtpTablet : txt_senhaFtpTablet.Text = _clGenp.senhaFtpTablet
                txt_pathPalmEnvio.Text = _clGenp.pathEnvioPalm : txt_pathPalmRetorno.Text = _clGenp.pathRetornoPalm
                txt_ftpPalm.Text = _clGenp.ftpPalm : txt_usuarioFtpPalm.Text = _clGenp.usuarioFtpPalm
                txt_senhaFtpPalm.Text = _clGenp.senhaFtpPalm


                _alteraConfiguracoes = True
            End While


            drGenp.Close() : conection.ClearPool() : conection.Close()
        Catch ex As Exception

            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")
            _clGeno.zeraValores() : tbc_geno.SelectTab(0) : tbp_config1.Parent = Nothing : tbp_config2.Parent = Nothing

        End Try

        cmdGenp.CommandText = "" : sqlGenp.Remove(0, sqlGenp.ToString.Length)
        conection = Nothing : cmdGenp = Nothing : drGenp = Nothing : sqlGenp = Nothing




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

                btn_salvar_Click_Incluindo() : executaF5()
            ElseIf _alterando = True Then
                btn_salvar_Click_Alterando() : executaF5()
            End If
        End If


    End Sub

    Private Sub btn_salvar_Click_Incluindo()

        Dim transacao As NpgsqlTransaction
        Try
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            conection.Open()
            transacao = conection.BeginTransaction
            salvaGenoIncluindo(conection, transacao)

            If _clFuncoes.existCaixaNaLoja(_clGeno.pCodig, MdlConexaoBD.conectionPadrao) = False Then
                _clBD.incCaixaNaLoja(_clGeno.pCodig, "001", "CAIXA", conection, transacao)
            End If

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
                tbc_geno.SelectTab(0)

                limpaCamposGeno() : preencheDtg_Geno() : txt_pesquisa.Focus()
                conection.ClearAllPools() : conection.Close() : transacao = Nothing : conection = Nothing
            End If
            _clGeno.zeraValores()


        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()
            Catch ex1 As Exception
            End Try
        End Try


    End Sub

    Private Sub salvaGenoIncluindo(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        _clGeno.pCodig = txt_codigo.Text
        _clGeno.pRazaosocial = txt_razaosocial.Text
        _clGeno.pGeno = txt_fantasia.Text
        _clGeno.pEnder = txt_endereco.Text
        _clGeno.pBair = txt_bairro.Text
        _clGeno.pUf = Me.cbo_uf.SelectedItem
        _clGeno.pCid = Me.cbo_cidade.SelectedItem
        _clGeno.pCep = _clFuncoes.RemoverCaracter(msk_cep.Text)
        _clGeno.pMun = txt_codmun.Text
        _clGeno.pCoduf = txt_Coduf.Text
        _clGeno.pCgc = _clFuncoes.RemoverCaracter(msk_cnpj.Text)
        _clGeno.pInsc = txt_inscricao.Text
        _clGeno.pEmail = txt_email.Text
        _clGeno.pFone = _clFuncoes.RemoverCaracter(msk_fone.Text)
        _clGeno.pFax = _clFuncoes.RemoverCaracter(msk_fax.Text)
        _clGeno.pCnae = txt_cnaeFiscal.Text
        _clGeno.pCrt = Mid(cbo_crt.SelectedItem, 1, 1)
        _clGeno.pRetencao = Me.chk_retencao.Checked
        If cbo_vinculo.SelectedIndex >= _vlrZERO Then _clGeno.pVinculo = Mid(cbo_vinculo.SelectedItem, 1, 1)
        If cbo_esqEstab.SelectedIndex >= _vlrZERO Then _clGeno.pEsquemaestab = cbo_esqEstab.SelectedItem
        If cbo_esqVinc.SelectedIndex >= _vlrZERO Then _clGeno.pEsquemavinc = cbo_esqVinc.SelectedItem
        _clGeno.pPis = Round(CDbl(txt_GenoPis.Text), 2) : _clGeno.pCofins = Round(CDbl(txt_GenoCofins.Text), 2)
        _clGeno.pCsll = Round(CDbl(txt_GenoCSLL.Text), 2) : _clGeno.pIRenda = Round(CDbl(txt_GenoIRenda.Text), 2)
        _clGeno.pSn = Round(CDbl(txt_GenoSN.Text), 2)


        _clBD.incGeno001(_clGeno, conection, transacao)

    End Sub

    Private Sub btn_salvar_Click_Alterando()

        Dim transacao As NpgsqlTransaction
        Try
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            If conection.State = ConnectionState.Closed Then conection.Open()
            transacao = conection.BeginTransaction
            salvaGenoAlterando(conection, transacao)

            If _clFuncoes.existCaixaNaLoja(_clGeno.pCodig, MdlConexaoBD.conectionPadrao) = False Then
                _clBD.incCaixaNaLoja(_clGeno.pCodig, "001", "CAIXA", conection, transacao)
            End If

            transacao.Commit()

            MsgBox("Estabelecimento salvo com sucesso", MsgBoxStyle.Exclamation)

            _incluindo = False : _alterando = False
            Btn_salvar.Enabled = False
            tbc_geno.SelectTab(0)

            limpaCamposGeno() : preencheDtg_Geno() : txt_pesquisa.Focus()
            conection.ClearAllPools() : conection.Close() : transacao = Nothing : conection = Nothing
            _clGeno.zeraValores()

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()
            Catch ex1 As Exception
            End Try
        End Try


    End Sub

    Private Sub salvaGenoAlterando(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        _clGeno.pCodig = txt_codigo.Text
        _clGeno.pRazaosocial = txt_razaosocial.Text
        _clGeno.pGeno = txt_fantasia.Text
        _clGeno.pEnder = txt_endereco.Text
        _clGeno.pBair = txt_bairro.Text
        _clGeno.pUf = Me.cbo_uf.SelectedItem
        _clGeno.pCid = Me.cbo_cidade.SelectedItem
        _clGeno.pCep = _clFuncoes.RemoverCaracter(msk_cep.Text)
        _clGeno.pMun = txt_codmun.Text
        _clGeno.pCoduf = txt_Coduf.Text
        _clGeno.pCgc = _clFuncoes.RemoverCaracter(msk_cnpj.Text)
        _clGeno.pInsc = txt_inscricao.Text
        _clGeno.pEmail = txt_email.Text
        _clGeno.pFone = _clFuncoes.RemoverCaracter(msk_fone.Text)
        _clGeno.pFax = _clFuncoes.RemoverCaracter(msk_fax.Text)
        _clGeno.pCnae = txt_cnaeFiscal.Text
        _clGeno.pCrt = Mid(cbo_crt.SelectedItem, 1, 1)
        _clGeno.pRetencao = Me.chk_retencao.Checked
        If cbo_vinculo.SelectedIndex >= _vlrZERO Then _clGeno.pVinculo = Mid(cbo_vinculo.SelectedItem, 1, 1)
        If cbo_esqEstab.SelectedIndex >= _vlrZERO Then _clGeno.pEsquemaestab = cbo_esqEstab.SelectedItem
        If cbo_esqVinc.SelectedIndex >= _vlrZERO Then _clGeno.pEsquemavinc = cbo_esqVinc.SelectedItem
        _clGeno.pPis = Round(CDbl(txt_GenoPis.Text), 2) : _clGeno.pCofins = Round(CDbl(txt_GenoCofins.Text), 2)
        _clGeno.pCsll = Round(CDbl(txt_GenoCSLL.Text), 2) : _clGeno.pIRenda = Round(CDbl(txt_GenoIRenda.Text), 2)
        _clGeno.pSn = Round(CDbl(txt_GenoSN.Text), 2)


        _clBD.altGeno001(_clGeno, conection, transacao)

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
                    txt_seqCodProd.Text = dtg_vinculos.CurrentRow.Cells(4).Value
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
            txt_seqCodProd.Text = dtg_vinculos.CurrentRow.Cells(4).Value
            txt_codVinculo.Focus()
        End If
    End Sub

    Private Sub cbo_uf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_uf.GotFocus
        If Me.cbo_uf.DroppedDown = False Then cbo_uf.DroppedDown = True
    End Sub

    Private Sub cbo_crt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_crt.GotFocus
        If Me.cbo_crt.DroppedDown = False Then cbo_crt.DroppedDown = True
    End Sub

    Private Sub cbo_vinculo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_vinculo.GotFocus
        If Me.cbo_vinculo.DroppedDown = False Then cbo_vinculo.DroppedDown = True
    End Sub

    Private Sub cbo_esqEstab_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_esqEstab.GotFocus
        If Me.cbo_esqEstab.DroppedDown = False Then cbo_esqEstab.DroppedDown = True
    End Sub

    Private Sub cbo_esqVinc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_esqVinc.GotFocus
        If Me.cbo_esqVinc.DroppedDown = False Then cbo_esqVinc.DroppedDown = True
    End Sub

    Private Sub btn_configuracao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_configuracao.Click

        _frmRef = Me
        frmLoginGeral.set_frmRef(Me)
        frmLoginGeral.ShowDialog(Me)

        If _privilegio Then

            trazGenpSelecionado()
            Me.tbp_config1.Parent = Me.tbc_geno : Me.tbp_config2.Parent = Me.tbc_geno : Me.tbp_dispositivos.Parent = Me.tbc_geno
            tbc_geno.SelectTab(3)
        Else
            Me.tbp_config1.Parent = Nothing : Me.tbp_config2.Parent = Nothing : Me.tbp_dispositivos.Parent = Nothing
        End If

    End Sub

    Private Sub txt_requis_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_requis.KeyPress, txt_sai.KeyPress, txt_fat.KeyPress, txt_serv.KeyPress, txt_orca.KeyPress, txt_palm.KeyPress, txt_seqNFe.KeyPress, txt_prazo.KeyPress, txt_carencia.KeyPress, txt_codrequis.KeyPress, txt_codmapa.KeyPress, txt_numpedidomp.KeyPress, txt_mapapedido.KeyPress, txt_codreqproc.KeyPress, txt_tipocondpagto.KeyPress, txt_tpTransfSaida.KeyPress, txt_tpTransfEntrada.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_requis_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_requis.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_requis.Text)
            Me.txt_requis.Text = String.Format("{0:D8}", mnumero)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_requis.Text = String.Format("{0:D8}", 0)
        End Try

    End Sub

    Private Sub txt_sai_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_sai.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_sai.Text)
            Me.txt_sai.Text = String.Format("{0:D9}", mnumero)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_sai.Text = String.Format("{0:D9}", 0)
        End Try

    End Sub

    Private Sub txt_fat_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fat.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_fat.Text)
            Me.txt_fat.Text = String.Format("{0:D8}", mnumero)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_fat.Text = String.Format("{0:D8}", 0)
        End Try

    End Sub

    Private Sub txt_icms_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_icms.KeyPress, txt_icmse.KeyPress, txt_alqiss.KeyPress, txt_txreduz.KeyPress, txt_icmred.KeyPress, txt_txcob.KeyPress, txt_txipi.KeyPress, txt_txesvei.KeyPress, txt_txga.KeyPress, txt_pis.KeyPress, txt_confin.KeyPress, txt_alqsub.KeyPress, txt_comisAVista.KeyPress, txt_comisAPrazo.KeyPress, txt_GenoPis.KeyPress, txt_GenoSN.KeyPress, txt_GenoIRenda.KeyPress, txt_GenoCSLL.KeyPress, txt_GenoCofins.KeyPress
        'permite só numeros e virgula
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_icms_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_icms.Leave

        If Me.txt_icms.Text.Equals("") Then Me.txt_icms.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_icms.Text) Then

            Me.txt_icms.Text = Format(CDec(Me.txt_icms.Text), "###,##0.00")
        Else
            MsgBox("ICMS INTERNO não é numérico !") : Me.txt_icms.Focus() : Me.txt_icms.SelectAll()
        End If

    End Sub

    Private Sub txt_icmse_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_icmse.Leave

        If Me.txt_icmse.Text.Equals("") Then Me.txt_icmse.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_icmse.Text) Then

            Me.txt_icmse.Text = Format(CDec(Me.txt_icmse.Text), "###,##0.00")
        Else
            MsgBox("ICMS EXTERNO não é numérico !") : Me.txt_icmse.Focus() : Me.txt_icmse.SelectAll()
        End If

    End Sub

    Private Sub txt_alqiss_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqiss.Leave

        If Me.txt_alqiss.Text.Equals("") Then Me.txt_alqiss.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_alqiss.Text) Then

            Me.txt_alqiss.Text = Format(CDec(Me.txt_alqiss.Text), "###,##0.00")
        Else
            MsgBox("Aliquota ISS não é numérico !") : Me.txt_alqiss.Focus() : Me.txt_alqiss.SelectAll()
        End If

    End Sub

    Private Sub txt_serv_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_serv.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_serv.Text)
            Me.txt_serv.Text = String.Format("{0:D8}", mnumero)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_serv.Text = String.Format("{0:D8}", 0)
        End Try

    End Sub

    Private Sub txt_orca_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_orca.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_orca.Text)
            Me.txt_orca.Text = String.Format("{0:D8}", mnumero)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_orca.Text = String.Format("{0:D8}", 0)
        End Try

    End Sub

    Private Sub txt_palm_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_palm.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_palm.Text)
            Me.txt_palm.Text = String.Format("{0:D8}", mnumero)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_palm.Text = String.Format("{0:D8}", 0)
        End Try

    End Sub

    Private Sub txt_txreduz_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_txreduz.Leave

        If Me.txt_txreduz.Text.Equals("") Then Me.txt_txreduz.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_txreduz.Text) Then

            Me.txt_txreduz.Text = Format(CDec(Me.txt_txreduz.Text), "###,##0.00")
        Else
            MsgBox("Taxa de Redução não é numérico !") : Me.txt_txreduz.Focus() : Me.txt_txreduz.SelectAll()
        End If

    End Sub

    Private Sub txt_icmred_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_icmred.Leave

        If Me.txt_icmred.Text.Equals("") Then Me.txt_icmred.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_icmred.Text) Then

            Me.txt_icmred.Text = Format(CDec(Me.txt_icmred.Text), "###,##0.00")
        Else
            MsgBox("ICMS Redução não é numérico !") : Me.txt_icmred.Focus() : Me.txt_icmred.SelectAll()
        End If

    End Sub

    Private Sub txt_txcob_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_txcob.Leave

        If Me.txt_txcob.Text.Equals("") Then Me.txt_txcob.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_txcob.Text) Then

            Me.txt_txcob.Text = Format(CDec(Me.txt_txcob.Text), "###,##0.00")
        Else
            MsgBox("Taxa Cobrança não é numérico !") : Me.txt_txcob.Focus() : Me.txt_txcob.SelectAll()
        End If

    End Sub

    Private Sub txt_txipi_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_txipi.Leave

        If Me.txt_txipi.Text.Equals("") Then Me.txt_txipi.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_txipi.Text) Then

            Me.txt_txipi.Text = Format(CDec(Me.txt_txipi.Text), "###,##0.00")
        Else
            MsgBox("Taxa IPI não é numérico !") : Me.txt_txipi.Focus() : Me.txt_txipi.SelectAll()
        End If

    End Sub

    Private Sub txt_txga_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_txga.Leave

        If Me.txt_txga.Text.Equals("") Then Me.txt_txga.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_txga.Text) Then

            Me.txt_txga.Text = Format(CDec(Me.txt_txga.Text), "###,##0.00")
        Else
            MsgBox("Taxa GA não é numérico !") : Me.txt_txga.Focus() : Me.txt_txga.SelectAll()
        End If

    End Sub

    Private Sub txt_txesvei_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_txesvei.Leave

        If Me.txt_txesvei.Text.Equals("") Then Me.txt_txesvei.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_txesvei.Text) Then

            Me.txt_txesvei.Text = Format(CDec(Me.txt_txesvei.Text), "###,##0.00")
        Else
            MsgBox("Taxa Esvei não é numérico !") : Me.txt_txesvei.Focus() : Me.txt_txesvei.SelectAll()
        End If

    End Sub

    Private Sub txt_prazo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_prazo.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_prazo.Text)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_prazo.Text = "0"
        End Try

    End Sub

    Private Sub txt_seqNFe_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_seqNFe.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_seqNFe.Text)
            Me.txt_seqNFe.Text = String.Format("{0:D9}", mnumero)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_seqNFe.Text = String.Format("{0:D9}", 0)
        End Try

    End Sub

    Private Sub txt_pis_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pis.Leave

        If Me.txt_pis.Text.Equals("") Then Me.txt_pis.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pis.Text) Then

            Me.txt_pis.Text = Format(CDec(Me.txt_pis.Text), "###,##0.00")
        Else
            MsgBox("PIS não é numérico !") : Me.txt_pis.Focus() : Me.txt_pis.SelectAll()
        End If

    End Sub

    Private Sub txt_confin_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_confin.Leave

        If Me.txt_confin.Text.Equals("") Then Me.txt_confin.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_confin.Text) Then

            Me.txt_confin.Text = Format(CDec(Me.txt_confin.Text), "###,##0.00")
        Else
            MsgBox("Confin não é numérico !") : Me.txt_confin.Focus() : Me.txt_confin.SelectAll()
        End If

    End Sub

    Private Sub txt_comisAVista_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_comisAVista.Leave

        If Me.txt_comisAVista.Text.Equals("") Then Me.txt_comisAVista.Text = Format(0.0, "##0.00")
        If IsNumeric(Me.txt_comisAVista.Text) Then

            Me.txt_comisAVista.Text = Format(CDec(Me.txt_comisAVista.Text), "##0.00")
        Else
            MsgBox("Comissão A Vista não é numérico !") : Me.txt_comisAVista.Focus() : Me.txt_comisAVista.SelectAll()
        End If

    End Sub

    Private Sub txt_comisAPrazo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_comisAPrazo.Leave

        If Me.txt_comisAPrazo.Text.Equals("") Then Me.txt_comisAPrazo.Text = Format(0.0, "##0.00")
        If IsNumeric(Me.txt_comisAPrazo.Text) Then

            Me.txt_comisAPrazo.Text = Format(CDec(Me.txt_comisAPrazo.Text), "##0.00")
        Else
            MsgBox("Comissão A Prazo não é numérico !") : Me.txt_comisAPrazo.Focus() : Me.txt_comisAPrazo.SelectAll()
        End If

    End Sub

    Private Sub txt_alqsub_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqsub.Leave

        If Me.txt_alqsub.Text.Equals("") Then Me.txt_alqsub.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_alqsub.Text) Then

            Me.txt_alqsub.Text = Format(CDec(Me.txt_alqsub.Text), "###,##0.00")
        Else
            MsgBox("Aliquota da Substituição não é numérico !") : Me.txt_alqsub.Focus() : Me.txt_alqsub.SelectAll()
        End If

    End Sub

    Private Sub txt_carencia_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_carencia.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_carencia.Text)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_carencia.Text = "0"
        End Try

    End Sub

    Private Sub txt_codrequis_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codrequis.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_codrequis.Text)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_codrequis.Text = "0"
        End Try

    End Sub

    Private Sub txt_codmapa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codmapa.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_codmapa.Text)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_codmapa.Text = "0"
        End Try

    End Sub

    Private Sub txt_numpedidomp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numpedidomp.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_numpedidomp.Text)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_numpedidomp.Text = "0"
        End Try

    End Sub

    Private Sub txt_mapapedido_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mapapedido.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_mapapedido.Text)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_mapapedido.Text = "0"
        End Try

    End Sub

    Private Sub txt_codreqproc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codreqproc.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt32(Me.txt_codreqproc.Text)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_codreqproc.Text = "0"
        End Try

    End Sub

    Private Sub txt_tipocondpagto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tipocondpagto.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt16(Me.txt_tipocondpagto.Text)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_tipocondpagto.Text = "1"
        End Try

    End Sub

    Private Sub txt_tpTransfEntrada_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tpTransfEntrada.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt16(Me.txt_tpTransfEntrada.Text)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_tpTransfEntrada.Text = "1"
        End Try

    End Sub

    Private Sub txt_tpTransfSaida_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tpTransfSaida.Leave

        Try
            Dim mnumero As Integer
            mnumero = Convert.ToInt16(Me.txt_tpTransfSaida.Text)
            mnumero = Nothing
        Catch ex As Exception
            Me.txt_tpTransfSaida.Text = "1"
        End Try

    End Sub

    Private Sub btn_salvaConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvaConfig.Click


        If _alteraConfiguracoes Then 'se for para salvar alterando...

            salvaConfiguracoesAlterando()

            zeraValoresConfiguracao1()
            Me.tbp_config1.Parent = Nothing : Me.tbp_config2.Parent = Nothing : Me.tbp_dispositivos.Parent = Nothing
            tbc_geno.SelectTab(0)
            _alteraConfiguracoes = False
        Else

            salvaConfiguracoesIncluindo()

            zeraValoresConfiguracao1()
            Me.tbp_config1.Parent = Nothing : Me.tbp_config2.Parent = Nothing : Me.tbp_dispositivos.Parent = Nothing
            tbc_geno.SelectTab(0)
            _alteraConfiguracoes = False
        End If



    End Sub

    Private Sub salvaConfiguracoesIncluindo()

        Dim transacao As NpgsqlTransaction
        Try
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            conection.Open()
            transacao = conection.BeginTransaction
            salvaGenpIncluindo(conection, transacao)
            transacao.Commit()

            preencheDtg_Geno() : txt_pesquisa.Focus()
            conection.ClearAllPools() : conection.Close() : transacao = Nothing : conection = Nothing
            _clGenp.zeraValores()

            MsgBox("Configurações Salvas com sucesso!")

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()
            Catch ex1 As Exception
            End Try
        End Try

    End Sub

    Private Sub salvaGenpIncluindo(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        'Configurações 1...
        _clGenp.pRequis = txt_requis.Text : _clGenp.pSai = txt_sai.Text
        _clGenp.pFat = txt_fat.Text : _clGenp.pIcms = Round(CDbl(txt_icms.Text), 2)
        _clGenp.pIcmse = Round(CDbl(txt_icmse.Text), 2) : _clGenp.pAlqiss = Round(CDbl(txt_alqiss.Text), 2)
        _clGenp.pServ = Round(CDbl(txt_serv.Text), 2) : _clGenp.pOrca = txt_orca.Text
        _clGenp.pPalm = txt_palm.Text : _clGenp.pTxreduz = Round(CDbl(txt_txreduz.Text), 2)
        _clGenp.pIcmred = Round(CDbl(txt_icmred.Text), 2) : txt_txcob.Text = _clGenp.pTxcob
        _clGenp.pTxipi = Round(CDbl(txt_txipi.Text), 2) : _clGenp.pTxga = Round(CDbl(txt_txga.Text), 2)
        _clGenp.pTxesvei = txt_txesvei.Text : _clGenp.pSerie = txt_serie.Text
        _clGenp.pContf = txt_contf.Text : _clGenp.pAmb = txt_amb.Text
        _clGenp.pPrazo = txt_prazo.Text : _clGenp.pSeqnfe = txt_seqNFe.Text
        _clGenp.pMensag = lbl_mensag.Text : _clGenp.pPis = Round(CDbl(txt_pis.Text), 2)
        _clGenp.pConfin = Round(CDbl(txt_confin.Text), 2) : _clGenp.pAlqsub = Round(CDbl(txt_alqsub.Text), 2)
        _clGenp.pCarencia = txt_carencia.Text : _clGenp.pCodprod = chk_codprod.Checked
        _clGenp.pCodrequis = txt_codrequis.Text : _clGenp.pCodmapa = txt_codmapa.Text
        _clGenp.pNumpedidomp = txt_numpedidomp.Text : _clGenp.pMapapedido = txt_mapapedido.Text
        _clGenp.pCanc_pedauto = chk_cancpedauto.Checked : _clGenp.pGrade = chk_grade.Checked
        _clGenp.pCodreqproc = txt_codreqproc.Text : _clGenp.pTipocondpagto = txt_tipocondpagto.Text
        _clGenp.pData = Date.Now
        _clGenp.pConfirmCPF = chk_cpf.Checked
        _clGenp.pTptransfentrada = txt_tpTransfEntrada.Text : _clGenp.pTptransfsaida = txt_tpTransfSaida.Text
        _clGenp.pComisavista = txt_comisAVista.Text : _clGenp.pComisaprazo = txt_comisAPrazo.Text
        _clGenp.imagemCarne = txt_ImagemCarne.Text
        _clGenp.sldfiscalnegativo = chk_sldfiscalnegativo.Checked : _clGenp.aplicacao = chk_aplicacao.Checked
        _clGenp.pauta = chk_pauta.Checked : _clGenp.descontonfe = chk_descontonfe.Checked


        'Configurações 2...
        _clGenp.pathEnvioXML = txt_pathXmlEnvio.Text : _clGenp.pathLotXML = txt_pathXmlLote.Text
        _clGenp.pathRetornoXML = txt_pathXmlRetorno.Text : _clGenp.pathEnviadoXML = txt_pathXmlEnviado.Text

        'Config. Dispositivos...
        _clGenp.pathEnvioTablet = txt_pathTabletEnvio.Text : _clGenp.pathRetornoTablet = txt_pathTabletRetorno.Text
        _clGenp.pathImgTablet = txt_pathImgTablet.Text : _clGenp.ftpTablet = txt_ftpTablet.Text
        _clGenp.usuarioFtpTablet = txt_usuarioFtpTablet.Text : _clGenp.senhaFtpTablet = txt_senhaFtpTablet.Text
        _clGenp.pathEnvioPalm = txt_pathPalmEnvio.Text : _clGenp.pathRetornoPalm = txt_pathPalmRetorno.Text
        _clGenp.ftpPalm = txt_ftpPalm.Text : _clGenp.usuarioFtpPalm = txt_usuarioFtpPalm.Text
        _clGenp.senhaFtpPalm = txt_senhaFtpPalm.Text

        _clBD.incGenp001(_clGenp, conection, transacao)

    End Sub

    Private Sub salvaConfiguracoesAlterando()

        Dim transacao As NpgsqlTransaction
        Try
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            conection.Open()
            transacao = conection.BeginTransaction
            salvaGenpAlterando(conection, transacao)
            transacao.Commit()


            preencheDtg_Geno() : txt_pesquisa.Focus()
            conection.ClearAllPools() : conection.Close() : transacao = Nothing : conection = Nothing
            _clGenp.zeraValores()

            MsgBox("Configurações Salvas com sucesso!")

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()
            Catch ex1 As Exception
            End Try
        End Try

    End Sub

    Private Sub salvaGenpAlterando(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        'Configurações 1...
        _clGenp.pRequis = txt_requis.Text : _clGenp.pSai = txt_sai.Text
        _clGenp.pFat = txt_fat.Text : _clGenp.pIcms = Round(CDbl(txt_icms.Text), 2)
        _clGenp.pIcmse = Round(CDbl(txt_icmse.Text), 2) : _clGenp.pAlqiss = Round(CDbl(txt_alqiss.Text), 2)
        _clGenp.pServ = Round(CDbl(txt_serv.Text), 2) : _clGenp.pOrca = txt_orca.Text
        _clGenp.pPalm = txt_palm.Text : _clGenp.pTxreduz = Round(CDbl(txt_txreduz.Text), 2)
        _clGenp.pIcmred = Round(CDbl(txt_icmred.Text), 2) : txt_txcob.Text = _clGenp.pTxcob
        _clGenp.pTxipi = Round(CDbl(txt_txipi.Text), 2) : _clGenp.pTxga = Round(CDbl(txt_txga.Text), 2)
        _clGenp.pTxesvei = txt_txesvei.Text : _clGenp.pSerie = txt_serie.Text
        _clGenp.pContf = txt_contf.Text : _clGenp.pAmb = txt_amb.Text
        _clGenp.pPrazo = txt_prazo.Text : _clGenp.pSeqnfe = txt_seqNFe.Text
        _clGenp.pMensag = lbl_mensag.Text : _clGenp.pPis = Round(CDbl(txt_pis.Text), 2)
        _clGenp.pConfin = Round(CDbl(txt_confin.Text), 2) : _clGenp.pAlqsub = Round(CDbl(txt_alqsub.Text), 2)
        _clGenp.pCarencia = txt_carencia.Text : _clGenp.pCodprod = chk_codprod.Checked
        _clGenp.pCodrequis = txt_codrequis.Text : _clGenp.pCodmapa = txt_codmapa.Text
        _clGenp.pNumpedidomp = txt_numpedidomp.Text : _clGenp.pMapapedido = txt_mapapedido.Text
        _clGenp.pCanc_pedauto = chk_cancpedauto.Checked : _clGenp.pGrade = chk_grade.Checked
        _clGenp.pCodreqproc = txt_codreqproc.Text : _clGenp.pTipocondpagto = txt_tipocondpagto.Text
        _clGenp.pConfirmCPF = chk_cpf.Checked
        _clGenp.pTptransfentrada = txt_tpTransfEntrada.Text : _clGenp.pTptransfsaida = txt_tpTransfSaida.Text
        _clGenp.pComisavista = txt_comisAVista.Text : _clGenp.pComisaprazo = txt_comisAPrazo.Text
        _clGenp.sldfiscalnegativo = chk_sldfiscalnegativo.Checked : _clGenp.aplicacao = chk_aplicacao.Checked
        _clGenp.pauta = chk_pauta.Checked : _clGenp.descontonfe = chk_descontonfe.Checked


        'Configurações 2...
        _clGenp.pathEnvioXML = txt_pathXmlEnvio.Text : _clGenp.pathLotXML = txt_pathXmlLote.Text
        _clGenp.pathRetornoXML = txt_pathXmlRetorno.Text : _clGenp.pathEnviadoXML = txt_pathXmlEnviado.Text
        _clGenp.imagemCarne = txt_ImagemCarne.Text

        'Config. Dispositivos...
        _clGenp.pathEnvioTablet = txt_pathTabletEnvio.Text : _clGenp.pathRetornoTablet = txt_pathTabletRetorno.Text
        _clGenp.pathImgTablet = txt_pathImgTablet.Text : _clGenp.ftpTablet = txt_ftpTablet.Text
        _clGenp.usuarioFtpTablet = txt_usuarioFtpTablet.Text : _clGenp.senhaFtpTablet = txt_senhaFtpTablet.Text
        _clGenp.pathEnvioPalm = txt_pathPalmEnvio.Text : _clGenp.pathRetornoPalm = txt_pathPalmRetorno.Text
        _clGenp.ftpPalm = txt_ftpPalm.Text : _clGenp.usuarioFtpPalm = txt_usuarioFtpPalm.Text
        _clGenp.senhaFtpPalm = txt_senhaFtpPalm.Text

        _clBD.altGenp001(_clGenp, conection, transacao)

    End Sub

    Private Sub btn_cancConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancConfig.Click

        If MessageBox.Show("Deseja realmente Cancelar?", "METROSYS", MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            zeraValoresConfiguracao1()
            Me.tbp_config1.Parent = Nothing : Me.tbp_config2.Parent = Nothing : Me.tbp_dispositivos.Parent = Nothing
            tbc_geno.SelectTab(0)
            _alteraConfiguracoes = False
        End If

    End Sub

    Private Sub zeraValoresConfiguracao1()

        txt_geno.Text = "" : txt_nomeGeno.Text = ""
        txt_requis.Text = "" : txt_sai.Text = ""
        txt_fat.Text = ""
        txt_icms.Text = "0" : txt_icmse.Text = "0"
        txt_alqiss.Text = "0" : txt_serv.Text = ""
        txt_orca.Text = "100" : txt_palm.Text = ""
        txt_txreduz.Text = "0" : txt_icmred.Text = "0"
        txt_txcob.Text = "0" : txt_txipi.Text = "0"
        txt_txga.Text = "0" : txt_txesvei.Text = "0"
        txt_serie.Text = "1" : txt_contf.Text = ""
        txt_amb.Text = "" : txt_prazo.Text = "0"
        txt_seqNFe.Text = "" : txt_pis.Text = "0"
        txt_confin.Text = "0" : txt_alqsub.Text = "0"
        txt_carencia.Text = "0"
        chk_codprod.Checked = True
        txt_codrequis.Text = "0" : txt_codmapa.Text = "0"
        txt_numpedidomp.Text = "0" : txt_mapapedido.Text = "0"
        chk_cancpedauto.Checked = False
        chk_grade.Checked = False
        txt_codreqproc.Text = "0" : lbl_mensag.Text = ""
        chk_cpf.Checked = True
        txt_tpTransfEntrada.Text = "0" : txt_tpTransfSaida.Text = "0"
        txt_comisAVista.Text = "0" : txt_comisAPrazo.Text = "0"
        chk_sldfiscalnegativo.Checked = False : chk_aplicacao.Checked = False
        chk_pauta.Checked = False : chk_descontonfe.Checked = False

    End Sub

    Private Sub zeraValoresConfiguracao2()

        txt_pathXmlEnvio.Text = ""
        txt_pathXmlLote.Text = ""
        txt_pathXmlRetorno.Text = ""
        txt_pathXmlEnviado.Text = ""
        txt_ImagemCarne.Text = "jpg"

    End Sub

    Private Sub zeraValoresConfigDispositivos()

        txt_pathTabletEnvio.Text = ""
        txt_pathTabletRetorno.Text = ""
        txt_pathImgTablet.Text = ""
        txt_ftpTablet.Text = ""
        txt_usuarioFtpTablet.Text = ""
        txt_senhaFtpTablet.Text = ""

        txt_pathPalmEnvio.Text = ""
        txt_pathPalmRetorno.Text = ""
        txt_ftpPalm.Text = ""
        txt_usuarioFtpPalm.Text = ""
        txt_senhaFtpPalm.Text = ""

    End Sub

    Private Sub txt_GenoPis_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_GenoPis.Leave

        If Me.txt_GenoPis.Text.Equals("") Then Me.txt_GenoPis.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_GenoPis.Text) Then

            Me.txt_GenoPis.Text = Format(CDec(Me.txt_GenoPis.Text), "###,##0.00")
        Else
            MsgBox("Pis do Metro não é numérico !") : Me.txt_GenoPis.Focus() : Me.txt_GenoPis.SelectAll()
        End If

    End Sub

    Private Sub txt_GenoCofins_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_GenoCofins.Leave

        If Me.txt_GenoCofins.Text.Equals("") Then Me.txt_GenoCofins.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_GenoCofins.Text) Then

            Me.txt_GenoCofins.Text = Format(CDec(Me.txt_GenoCofins.Text), "###,##0.00")
        Else
            MsgBox("Cofins do Metro não é numérico !") : Me.txt_GenoCofins.Focus() : Me.txt_GenoCofins.SelectAll()
        End If

    End Sub

    Private Sub txt_GenoCSLL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_GenoCSLL.Leave

        If Me.txt_GenoCSLL.Text.Equals("") Then Me.txt_GenoCSLL.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_GenoCSLL.Text) Then

            Me.txt_GenoCSLL.Text = Format(CDec(Me.txt_GenoCSLL.Text), "###,##0.00")
        Else
            MsgBox("CSLL do Metro não é numérico !") : Me.txt_GenoCSLL.Focus() : Me.txt_GenoCSLL.SelectAll()
        End If

    End Sub

    Private Sub txt_GenoIRenda_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_GenoIRenda.Leave

        If Me.txt_GenoIRenda.Text.Equals("") Then Me.txt_GenoIRenda.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_GenoIRenda.Text) Then

            Me.txt_GenoIRenda.Text = Format(CDec(Me.txt_GenoIRenda.Text), "###,##0.00")
        Else
            MsgBox("IRenda do Metro não é numérico !") : Me.txt_GenoIRenda.Focus() : Me.txt_GenoIRenda.SelectAll()
        End If

    End Sub

    Private Sub txt_GenoSN_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_GenoSN.Leave

        If Me.txt_GenoSN.Text.Equals("") Then Me.txt_GenoSN.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_GenoSN.Text) Then

            Me.txt_GenoSN.Text = Format(CDec(Me.txt_GenoSN.Text), "###,##0.00")
        Else
            MsgBox("SN do Metro não é numérico !") : Me.txt_GenoSN.Focus() : Me.txt_GenoSN.SelectAll()
        End If

    End Sub


    Private Sub btn_proximaAba01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proximaAba01.Click
        tbc_geno.SelectTab(4)
    End Sub

    Private Sub btn_xmlEnvio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_xmlEnvio.Click
        pastaXmlEnvio()
    End Sub

    Private Sub bt_xmlLote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_xmlLote.Click
        pastaXmlLote()
    End Sub

    Private Sub btn_xmlRetorno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_xmlRetorno.Click
        pastaXmlRetorno()
    End Sub

    Private Sub btn_xmlEnviado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_xmlEnviado.Click
        pastaXmlEnviado()
    End Sub

    Private Sub pastaXmlEnvio()

        Try
            OpenFolder.ShowDialog()
            If OpenFolder.SelectedPath <> "" Then Me.txt_pathXmlEnvio.Text = OpenFolder.SelectedPath
        Catch ex As Exception
            Me.txt_pathXmlEnvio.Text = ""
        End Try

    End Sub

    Private Sub pastaXmlLote()

        Try
            OpenFolder.ShowDialog()
            If OpenFolder.SelectedPath <> "" Then Me.txt_pathXmlLote.Text = OpenFolder.SelectedPath
        Catch ex As Exception
            Me.txt_pathXmlLote.Text = ""
        End Try

    End Sub

    Private Sub pastaXmlRetorno()

        Try
            OpenFolder.ShowDialog()
            If OpenFolder.SelectedPath <> "" Then Me.txt_pathXmlRetorno.Text = OpenFolder.SelectedPath
        Catch ex As Exception
            Me.txt_pathXmlRetorno.Text = ""
        End Try

    End Sub

    Private Sub pastaXmlEnviado()

        Try
            OpenFolder.ShowDialog()
            If OpenFolder.SelectedPath <> "" Then Me.txt_pathXmlEnviado.Text = OpenFolder.SelectedPath
        Catch ex As Exception
            Me.txt_pathXmlEnviado.Text = ""
        End Try

    End Sub

    Private Sub txt_ImagemCarne_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ImagemCarne.LostFocus
        txt_ImagemCarne.Text = Trim(txt_ImagemCarne.Text)

        If (txt_ImagemCarne.Text <> "bmp") AndAlso (txt_ImagemCarne.Text <> "jpg") Then
            MsgBox("Extenção da Imagem do Carne deve ser ""bmp"" ou ""jpg"" !")
            tbc_geno.SelectTab(4) : txt_ImagemCarne.Focus() : txt_ImagemCarne.SelectAll() : Return
        End If

    End Sub

    Private Sub btn_TabletEnvio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_TabletEnvio.Click
        pastaTabletEnvio()
    End Sub

    Private Sub btn_TabletRetorno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_TabletRetorno.Click, btn_ImgTablet.Click
        pastaTabletRetorno()
    End Sub

    Private Sub btn_PalmEnvio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PalmEnvio.Click
        pastaPalmEnvio()
    End Sub

    Private Sub btn_PalmRetorno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PalmRetorno.Click
        pastaPalmRetorno()
    End Sub

    Private Sub pastaTabletEnvio()

        Try
            OpenFolder.ShowDialog()
            If OpenFolder.SelectedPath <> "" Then Me.txt_pathTabletEnvio.Text = OpenFolder.SelectedPath
        Catch ex As Exception
            Me.txt_pathTabletEnvio.Text = ""
        End Try

    End Sub

    Private Sub pastaTabletRetorno()

        Try
            OpenFolder.ShowDialog()
            If OpenFolder.SelectedPath <> "" Then Me.txt_pathTabletRetorno.Text = OpenFolder.SelectedPath
        Catch ex As Exception
            Me.txt_pathTabletRetorno.Text = ""
        End Try

    End Sub

    Private Sub pastaPalmEnvio()

        Try
            OpenFolder.ShowDialog()
            If OpenFolder.SelectedPath <> "" Then Me.txt_pathPalmEnvio.Text = OpenFolder.SelectedPath
        Catch ex As Exception
            Me.txt_pathPalmEnvio.Text = ""
        End Try

    End Sub

    Private Sub pastaPalmRetorno()

        Try
            OpenFolder.ShowDialog()
            If OpenFolder.SelectedPath <> "" Then Me.txt_pathPalmRetorno.Text = OpenFolder.SelectedPath
        Catch ex As Exception
            Me.txt_pathPalmRetorno.Text = ""
        End Try

    End Sub

End Class