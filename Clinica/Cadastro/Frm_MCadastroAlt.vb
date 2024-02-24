Imports System
Imports System.Data
Imports Npgsql
Imports System.Text.RegularExpressions

Public Class Frm_MCadastroAlt

    Private Const _vlrZERO As Integer = 0
    Dim _clFunc As New ClFuncoes
    Dim _clBD As New Cl_bdMetrosys
    Dim clCadp001 As New Cl_Cadp001
    Dim _codAtual As String = ""

    Private _ufCorrenteCbo As String = ""
    Private _mtipo As String = "C"
    Private _MenuCadatro As New Frm_MenuCadastro


    Dim _clDoutorDAO As New Cl_DoutorDAO
    Dim _Geno As New Cl_Geno
    Public _Doutor As New Cl_Doutor
    Dim mContFicha As Int16 = 0

    Dim _clTratamento As New Cl_Tratamento
    Dim _clTratamentoDAO As New Cl_TratamentoDAO

    Private Sub Frm_MCadastroAlt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If (e.KeyCode = Keys.Escape) Then Me.Close()

    End Sub

    Private Sub Frm_MCadastroAlt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub cbo_cidade_KeyDown(sender As Object, e As KeyEventArgs) Handles cbo_cidade.KeyDown

        Try
            If cbo_cidade.SelectedIndex > -1 Then
                enviaTecla(sender, e, "TAB")
            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub enviaTecla(ByRef sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs, ByVal tecla As String)

        If e.KeyCode = Keys.Enter Then
            e.Handled = True : SendKeys.Send("{" & tecla.ToUpper & "}")
        End If

    End Sub

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub RdBFisica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBFisica.CheckedChanged

        If Me.RdBFisica.Checked = True Then

            Me.txt_insc.Enabled = False : Me.msk_cnpj.Enabled = False : Me.msk_cpf.Enabled = True
            Me.txt_ident.Enabled = True : Me.cbo_sexo.SelectedIndex = -1 : Me.cbo_sexo.Enabled = True
            Me.lbl_RazaoSocial.Text = "Nome:" : Me.lbl_RazaoSocial.SetBounds(163, 19, 38, 13)
            Me.txt_Fantasia.Enabled = False

        End If


    End Sub

    Private Sub RdBJuridica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBJuridica.CheckedChanged

        If Me.RdBJuridica.Checked = True Then

            Me.txt_insc.Enabled = True : Me.msk_cnpj.Enabled = True : Me.msk_cpf.Enabled = False
            Me.txt_ident.Enabled = False : Me.cbo_sexo.SelectedIndex = 2 : Me.cbo_sexo.Enabled = False
            Me.lbl_RazaoSocial.Text = "RazãoSocial:" : Me.lbl_RazaoSocial.SetBounds(132, 19, 70, 13)
            Me.txt_Fantasia.Enabled = True

        End If


    End Sub

    Private Sub AlfaMaiuscula()

        Me.txt_RazaoSocialNome.CharacterCasing = CharacterCasing.Upper
        Me.txt_insc.CharacterCasing = CharacterCasing.Upper
        Me.txt_Fantasia.CharacterCasing = CharacterCasing.Upper
        Me.txt_endereco.CharacterCasing = CharacterCasing.Upper
        Me.txt_bairro.CharacterCasing = CharacterCasing.Upper
        Me.txt_ident.CharacterCasing = CharacterCasing.Upper
        Me.txt_RazaoSocialNome.Modified = True

    End Sub

    Private Function Testa_controle() As Boolean

        Try
            If Me.cbo_uf.SelectedIndex = -1 Then MessageBox.Show(Me.cbo_uf.SelectedItem.ToString, "Item Selecionado ")
            If Me.RdBFisica.Checked = False And Me.RdBJuridica.Checked = False Then MessageBox.Show("Erro Caracteristica", "Fisica ou Juridica ")
            Return True

        Catch ex As Exception
            MessageBox.Show("Item não selecionado ", "Erro UF")
            Me.txt_Fantasia.Focus() : Return False

        End Try



    End Function

    Private Sub cbo_uf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_uf.GotFocus

        If Not (cbo_uf.DroppedDown) Then cbo_uf.DroppedDown = True

    End Sub

    Private Sub cbo_uf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_uf.Leave

        If _ufCorrenteCbo.Equals("") Then

            If cbo_uf.SelectedIndex >= _vlrZERO Then

                Me.cbo_cidade = _clFunc.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
                _ufCorrenteCbo = Me.cbo_uf.Text

            End If
        ElseIf cbo_uf.SelectedIndex > _vlrZERO And Not _ufCorrenteCbo.Equals(cbo_uf.Text) Then

            Me.cbo_cidade = _clFunc.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
            _ufCorrenteCbo = Me.cbo_uf.Text

        End If



    End Sub

    Private Sub setValoresPart()

        Me.txt_codigo.Text = _MenuCadatro._FrmRef.clCadp001.pCod
        _codAtual = _MenuCadatro._FrmRef.clCadp001.pCod
        Me.txt_RazaoSocialNome.Text = _MenuCadatro._FrmRef.clCadp001.pPortad

        If _MenuCadatro._FrmRef.clCadp001.pTipo.Equals("C") Then RdBCli.Checked = True
        If _MenuCadatro._FrmRef.clCadp001.pTipo.Equals("F") Then RdBForn.Checked = True

        If _MenuCadatro._FrmRef.clCadp001.pCarac.Equals("F") Then
            RdBFisica.Checked = True
        Else
            RdBJuridica.Checked = True
        End If

        txt_ficha.Text = _MenuCadatro._FrmRef.clCadp001.ficha

        Try
            dtp_cadastro.Text = Format(Convert.ChangeType(_MenuCadatro._FrmRef.clCadp001.pDtcad, GetType(Date)), "ddMMyyyy")
        Catch ex As Exception
        End Try


        Me.txt_Fantasia.Text = _MenuCadatro._FrmRef.clCadp001.pFantas
        Try
            Me.msk_nascativ.Text = Format(Convert.ChangeType(_MenuCadatro._FrmRef.clCadp001.pDtnativ, GetType(Date)), "ddMMyyyy")
        Catch ex As Exception
        End Try

        Me.txt_endereco.Text = _MenuCadatro._FrmRef.clCadp001.pEnder

        Me.cbo_uf.SelectedIndex = trazIndexUF(_MenuCadatro._FrmRef.clCadp001.pUf, cbo_uf)
        If cbo_uf.SelectedIndex >= 0 Then

            Me.cbo_cidade = _clFunc.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
            cbo_cidade.Refresh()
            cbo_cidade.SelectedIndex = trazIndexMUN(_MenuCadatro._FrmRef.clCadp001.pCid, cbo_cidade)
            _ufCorrenteCbo = cbo_uf.Text

        End If

        Me.txt_bairro.Text = _MenuCadatro._FrmRef.clCadp001.pBairro : Me.msk_cep.Text = _MenuCadatro._FrmRef.clCadp001.pCep
        Me.msk_fone.Text = _MenuCadatro._FrmRef.clCadp001.pFone
        Me.txt_ident.Text = _MenuCadatro._FrmRef.clCadp001.pIdent : Me.msk_cpf.Text = _MenuCadatro._FrmRef.clCadp001.pCpf
        Me.msk_cnpj.Text = _MenuCadatro._FrmRef.clCadp001.pCgc : Me.txt_insc.Text = _MenuCadatro._FrmRef.clCadp001.pInsc
        Me.txt_codmun.Text = _MenuCadatro._FrmRef.clCadp001.pMun : Me.txt_email.Text = _MenuCadatro._FrmRef.clCadp001.pEmail
        Me.cbo_sexo.SelectedIndex = trazIndexSexo(_MenuCadatro._FrmRef.clCadp001.pSexo, Me.cbo_sexo)


    End Sub

    Private Sub setValoresTratamento()

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR conexao com ""Tratamento"":: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As String
        Dim dr As NpgsqlDataReader


        Try

            sql = "SELECT t_tratamento, t_dentista, t_qtde, t_valor FROM tratamento WHERE t_codcliente = '" & Me.txt_codigo.Text & "'"
            cmd = New NpgsqlCommand(sql.ToString, oConn)

            dr = cmd.ExecuteReader

            dtg_tratamento.Rows.Clear()
            If dr.HasRows = False Then Return
            While dr.Read
                dtg_tratamento.Rows.Add(dr(0).ToString, dr(1).ToString, Format(dr(2), "#,##0.00"), Format(dr(3), "#,##0.00"))
            End While

            dtg_tratamento.Refresh() : dr.Close()
            oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT dos Tratamentos:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmd.CommandText = ""
        sql.Remove(0, sql.ToString.Length)

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmd = Nothing
        sql = Nothing : dr = Nothing

    End Sub

    Public Function trazIndexUF(ByVal mUF As String, ByVal mCboUF As Object) As Integer

        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = _vlrZERO To mCboUF.Items.Count - 1

            If mUF.Equals(Trim(mCboUF.Items.Item(index).ToString.Substring(_vlrZERO, 2))) Then
                indiceCfop = index
                Exit For

            End If
        Next



        Return indiceCfop
    End Function

    Public Function trazIndexMUN(ByVal mMUN As String, ByVal mCboMUN As Object) As Integer

        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = _vlrZERO To mCboMUN.Items.Count - 1

            If mMUN.Equals(Trim(mCboMUN.Items.Item(index).ToString)) Then
                indiceCfop = index
                Exit For

            End If
        Next



        Return indiceCfop
    End Function

    Public Function trazIndexSexo(ByVal mSexo As String, ByVal mCboSexo As Object) As Integer

        Dim index As Integer : Dim indicesexo As Integer = -1
        For index = _vlrZERO To mCboSexo.Items.Count - 1

            If mSexo.Equals(Trim(mCboSexo.Items.Item(index).ToString)) Then
                indicesexo = index
                Exit For

            End If
        Next



        Return indicesexo
    End Function

    Private Sub Frm_MCadastro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        mContFicha = 0

        Me.cbo_uf.Items.Add("AC") : Me.cbo_uf.Items.Add("AL") : Me.cbo_uf.Items.Add("AP")
        Me.cbo_uf.Items.Add("AM") : Me.cbo_uf.Items.Add("BA") : Me.cbo_uf.Items.Add("CE")
        Me.cbo_uf.Items.Add("DF") : Me.cbo_uf.Items.Add("ES") : Me.cbo_uf.Items.Add("EX")
        Me.cbo_uf.Items.Add("GO") : Me.cbo_uf.Items.Add("MA") : Me.cbo_uf.Items.Add("MT")
        Me.cbo_uf.Items.Add("MS") : Me.cbo_uf.Items.Add("MG") : Me.cbo_uf.Items.Add("PA")
        Me.cbo_uf.Items.Add("PB") : Me.cbo_uf.Items.Add("PE") : Me.cbo_uf.Items.Add("PI")
        Me.cbo_uf.Items.Add("RJ") : Me.cbo_uf.Items.Add("RN") : Me.cbo_uf.Items.Add("RS")
        Me.cbo_uf.Items.Add("RO") : Me.cbo_uf.Items.Add("RR") : Me.cbo_uf.Items.Add("SC")
        Me.cbo_uf.Items.Add("SP") : Me.cbo_uf.Items.Add("SE") : Me.cbo_uf.Items.Add("TO")
        Me.cbo_uf.Items.Add("PR")

        Me.cbo_uf.Sorted = True : Me.RdBCli.Checked = True
        AlfaMaiuscula() : Me.RdBFisica.Checked = True : Me.txt_RazaoSocialNome.Focus()

        _clFunc.trazGenoSelecionado(MdlEmpresaUsu._codigo, _Geno)

        cbo_doutores = _clDoutorDAO.PreenchComboDoutores(_Geno, cbo_doutores, MdlConexaoBD.conectionPadrao)
        cbo_dentistaTrat = _clDoutorDAO.PreenchComboDoutores(_Geno, cbo_dentistaTrat, MdlConexaoBD.conectionPadrao)
        cbo_doutores.SelectedIndex = _clFunc.trazIndexComboBox(_Doutor.Nome, _Doutor.Nome.Length, cbo_doutores)

        'setValoresPart() deve ficar sempre no final do FormLoad...
        setValoresPart()
        setValoresTratamento()

    End Sub

    Private Sub txt_RazaoSocial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_RazaoSocialNome.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            If Me.RdBFisica.Checked = False And Me.RdBJuridica.Checked = False Then
                MessageBox.Show("Fisica ou Juridica ? ", " Erro Caracteristica ", MessageBoxButtons.OK, MessageBoxIcon.Question)

            End If
        End If



    End Sub

    Private Sub btn_proximaAba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proximaAba.Click

        tbc_participante.SelectTab(1)

    End Sub

    Private Function verificaParticipante()

        Dim mNaoDeuErro As Boolean = True
        lbl_mensagem.Text = ""


        If mContFicha < 1 Then
            If _clFunc.existFichaCadp001(txt_ficha.Text, Me.txt_codigo.Text, MdlConexaoBD.conectionPadrao) Then

                mNaoDeuErro = False : lbl_mensagem.Text = "FICHA Já Existe !  Deseja Alterar assim mesmo?!"
                lbl_mensagem.Text = "FICHA Já Existe !  Deseja Alterar assim mesmo?!" : Return mNaoDeuErro
            End If
        End If
        

        If (Me.RdBCli.Checked = False) AndAlso (Me.RdBForn.Checked = False) Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Selecione um tipo de Participante !"
            lbl_mensagem.Text = "Selecione um tipo de Participante !" : Return mNaoDeuErro
        End If

        If (Me.RdBFisica.Checked = False) AndAlso (Me.RdBJuridica.Checked = False) Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Selecione a característica do Participante !"
            lbl_mensagem.Text = "Selecione a característica do Participante !" : Return mNaoDeuErro
        End If


        If Trim(Me.txt_codigo.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Código do Participante não informado !"
            lbl_mensagem.Text = "Código do Participante não informado !" : Return mNaoDeuErro
        End If


        If Trim(Me.txt_RazaoSocialNome.Text).Equals("") Then

            If RdBFisica.Checked = True Then

                mNaoDeuErro = False : lbl_mensagem.Text = "Informe a Razao Social do Participante !"
                lbl_mensagem.Text = "Informe a Razao Social do Participante !" : Return mNaoDeuErro

            ElseIf RdBJuridica.Checked = True Then

                mNaoDeuErro = False : lbl_mensagem.Text = "Informe o Nome do Participante !"
                lbl_mensagem.Text = "Informe o Nome do Participante !" : Return mNaoDeuErro

            End If
        End If

        If Trim(Me.txt_endereco.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Informe o ENDEREÇO do Participante !"
            lbl_mensagem.Text = "Informe o ENDEREÇO do Participante !" : Return mNaoDeuErro
        End If

        If Me.cbo_uf.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Informe a UF do Participante !"
            lbl_mensagem.Text = "Informe a UF do Participante !" : Return mNaoDeuErro
        End If

        If Me.cbo_cidade.SelectedIndex < _vlrZERO Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Informe a CIDADE do Participante !"
            lbl_mensagem.Text = "Informe a CIDADE do Participante !" : Return mNaoDeuErro
        End If

        If Trim(Me.txt_bairro.Text).Equals("") Then

            mNaoDeuErro = False : lbl_mensagem.Text = "Informe o BAIRRO do Participante !"
            lbl_mensagem.Text = "Informe o BAIRRO do Participante !" : Return mNaoDeuErro
        End If


        If Me.RdBFisica.Checked Then


            If MdlEmpresaUsu.cpfvalidar Then

                If Trim(Me.msk_cpf.Text).Equals("") Then


                    mNaoDeuErro = False : lbl_mensagem.Text = "Informe o CPF do Participante !"
                    lbl_mensagem.Text = "Informe o CPF do Participante !" : Return mNaoDeuErro

                Else

                    If Not _clBD.ValidaCPF(_clFunc.RemoverCaracter2(Me.msk_cpf.Text)) Then

                        lbl_mensagem.Text = "CPF Incorreto !" : lbl_mensagem.Text = "CPF Incorreto !"
                        mNaoDeuErro = False : Return mNaoDeuErro

                    ElseIf _clFunc.existCpfCadp001(_clFunc.RemoverCaracter2(Me.msk_cpf.Text), Me.txt_codigo.Text, _
                                                MdlConexaoBD.conectionPadrao) Then

                        mNaoDeuErro = False : lbl_mensagem.Text = "CPF Já Existe !"
                        lbl_mensagem.Text = "CPF Já Existe !" : Return mNaoDeuErro
                    End If

                End If

            End If

        End If


        If Me.RdBJuridica.Checked Then

            If Trim(Me.msk_cnpj.Text).Equals("") Then

                mNaoDeuErro = False : lbl_mensagem.Text = "Informe o CNPJ do Participante !"
                lbl_mensagem.Text = "Informe o CNPJ do Participante !" : Return mNaoDeuErro

            ElseIf Not _clBD.ValidaCNPJ(_clFunc.RemoverCaracter2(Me.msk_cnpj.Text)) Then

                lbl_mensagem.Text = "CNPJ Incorreto !" : lbl_mensagem.Text = "CNPJ Incorreto !"

            ElseIf _clFunc.existCnpjCadp001(_clFunc.RemoverCaracter2(Me.msk_cnpj.Text), Me.txt_codigo.Text, _
                                        MdlConexaoBD.conectionPadrao) Then

                mNaoDeuErro = False : lbl_mensagem.Text = "CNPJ Já Existe !"
                lbl_mensagem.Text = "CNPJ Já Existe !" : Return mNaoDeuErro

            End If

        End If



        Return mNaoDeuErro
    End Function

    Private Sub salvaParticipanteAlterando(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)


        'Preechendo objetos para CADP001
        clCadp001.pTipo = _mtipo
        If Me.RdBFisica.Checked Then
            clCadp001.pCarac = "F"
        Else
            clCadp001.pCarac = "J"
        End If

        Try
            clCadp001.pDtcad = Convert.ChangeType(Trim(dtp_cadastro.Text), GetType(Date))
        Catch ex As Exception
        End Try

        clCadp001.pCod = Trim(Me.txt_codigo.Text)
        clCadp001.pPortad = Trim(txt_RazaoSocialNome.Text)
        clCadp001.pFantas = Trim(txt_Fantasia.Text)

        Try
            clCadp001.pDtnativ = Convert.ChangeType(Trim(msk_nascativ.Text), GetType(Date))
        Catch ex As Exception
        End Try

        clCadp001.pEnder = Trim(txt_endereco.Text)
        clCadp001.pUf = Trim(Me.cbo_uf.SelectedItem) : clCadp001.pCid = Trim(Me.cbo_cidade.SelectedItem) : clCadp001.pBairro = Trim(txt_bairro.Text)
        clCadp001.pCep = Trim(msk_cep.Text)
        clCadp001.pCelular = ""
        If IsNumeric(msk_fone.Text) Then clCadp001.pFone = Trim(msk_fone.Text)

        clCadp001.pVend = "" : clCadp001.pCdvend = ""

        clCadp001.pRota = 0

        clCadp001.pIdent = Trim(txt_ident.Text) : clCadp001.pCpf = Trim(_clFunc.RemoverCaracter2(msk_cpf.Text))
        clCadp001.pCgc = Trim(_clFunc.RemoverCaracter2(msk_cnpj.Text)) : clCadp001.pInsc = Trim(txt_insc.Text)
        clCadp001.pPrep = "" : clCadp001.pFax = "" : clCadp001.pSexo = cbo_sexo.SelectedItem
        clCadp001.pEmail = txt_email.Text : clCadp001.pMun = txt_codmun.Text : clCadp001.pCoduf = _clBD.trazCodEstado(conection, clCadp001.pUf)
        clCadp001.pCoduf = Trim(clCadp001.pCoduf)
        clCadp001.pConsumo = "N"
        clCadp001.ficha = txt_ficha.Text

        clCadp001.iddoutor = _Doutor.Id
        clCadp001.doutor = _Doutor.Nome

        'Chamando a fução de gravar as informações do fornecedor...
        _clBD.altParticipante(clCadp001, _codAtual, conection, transacao)


        'Tratamento:
        Try


            _clTratamento.t_codcliente = Me.txt_codigo.Text
            _clTratamento.t_ficha = Me.txt_ficha.Text

            _clTratamentoDAO.DelTratamento(_clTratamento, conection, transacao)
            For Each row As DataGridViewRow In dtg_tratamento.Rows

                If row.IsNewRow = False Then

                    _clTratamento.t_tratamento = row.Cells(0).Value.ToString
                    _clTratamento.t_dentista = row.Cells(1).Value.ToString
                    _clTratamento.t_qtde = row.Cells(2).Value
                    _clTratamento.t_valor = row.Cells(3).Value
                    _clTratamentoDAO.IncTratamento(_clTratamento, conection, transacao)

                End If
            Next
        Catch ex As NullReferenceException
        End Try
        

    End Sub

    Private Sub btn_salvar_Click_Alterando()

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            transacao = conection.BeginTransaction
            salvaParticipanteAlterando(conection, transacao)
            transacao.Commit()

            MsgBox("Participante salvo com sucesso", MsgBoxStyle.Exclamation)
            conection.Close()
            transacao = Nothing : conection = Nothing
            clCadp001.zeraValores()
            Me.Close()

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try

        End Try



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
        conection.Close() : conection = Nothing



    End Sub

    Private Sub msk_cpf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_cpf.Leave

        lbl_mensagem.Text = "" : lbl_mensagem.Text = ""

        If _clBD.ValidaCPF(Me.msk_cpf.Text) = False Then

            lbl_mensagem.Text = "CPF Incorreto !" : lbl_mensagem.Text = "CPF Incorreto !"
        End If



    End Sub

    Private Sub msk_cnpj_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_cnpj.Leave

        lbl_mensagem.Text = "" : lbl_mensagem.Text = ""

        If _clBD.ValidaCNPJ(_clFunc.RemoverCaracter2(Me.msk_cnpj.Text)) = False Then

            lbl_mensagem.Text = "CNPJ Incorreto !" : lbl_mensagem.Text = "CNPJ Incorreto !"
        End If



    End Sub

    Private Sub msk_cep_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_cep.Leave

        lbl_mensagem.Text = "" : lbl_mensagem.Text = ""

        ' Pattern ou mascara de verificação do Cpf
        Dim pattern As String = "^\d{5}\-?\d{3}$"

        If Not Regex.Match(Me.msk_cep.Text, pattern).Success Then

            lbl_mensagem.Text = "CEP Incorreto !" : lbl_mensagem.Text = "CEP Incorreto !"
        End If



    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If RdBCli.Checked = True Then _mtipo = "C"
        If RdBForn.Checked = True Then _mtipo = "F"

        If verificaParticipante() Then

            btn_salvar_Click_Alterando()

        End If



    End Sub

    Private Sub cbo_cidade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cidade.Click

        cbo_cidade.SelectAll()

    End Sub

    Private Sub RdBCli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBForn.CheckedChanged, RdBCli.CheckedChanged

        If RdBCli.Checked = True Then Me.txt_codigo.Text = "C" & Mid(Me.txt_codigo.Text, 2, 5)
        If RdBForn.Checked = True Then Me.txt_codigo.Text = "F" & Mid(Me.txt_codigo.Text, 2, 5)

    End Sub

    Private Sub cbo_doutores_GotFocus(sender As Object, e As EventArgs) Handles cbo_doutores.GotFocus
        If cbo_doutores.DroppedDown = False Then cbo_doutores.DroppedDown = True
    End Sub

    Private Sub cbo_doutores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_doutores.SelectedIndexChanged

        Try
            If cbo_doutores.SelectedIndex > -1 Then
                _clDoutorDAO.trazDoutorLojaNome(cbo_doutores.SelectedItem.ToString, _Geno, _Doutor)
                cbo_dentistaTrat.SelectedIndex = _clFunc.trazIndexComboBox(_Doutor.Nome, _Doutor.Nome.Length, cbo_dentistaTrat)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbo_sexo_GotFocus(sender As Object, e As EventArgs) Handles cbo_sexo.GotFocus
        If cbo_doutores.DroppedDown = False Then cbo_doutores.DroppedDown = True
    End Sub

    Private Sub cbo_dentistaTrat_GotFocus(sender As Object, e As EventArgs) Handles cbo_dentistaTrat.GotFocus
        If cbo_dentistaTrat.DroppedDown = False Then cbo_dentistaTrat.DroppedDown = True
    End Sub

    Private Sub txt_qtdeTrat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_valorTrat.KeyPress, txt_qtdeTrat.KeyPress
        'permite só numeros virgula
        If _clFunc.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_qtdeTrat_Leave(sender As Object, e As EventArgs) Handles txt_qtdeTrat.Leave

        lbl_mensagem.Text = ""
        If txt_qtdeTrat.Text.Equals("") Then txt_qtdeTrat.Text = "0,00"
        If IsNumeric(txt_qtdeTrat.Text) Then
            txt_qtdeTrat.Text = Format(CDbl(txt_qtdeTrat.Text), "##0.00")
        Else
            lbl_mensagem.Text = "Qtde do Tratamento deve ser Numerico !" : txt_qtdeTrat.Focus() : txt_qtdeTrat.SelectAll() : Return
        End If

    End Sub

    Private Sub txt_valorTrat_Leave(sender As Object, e As EventArgs) Handles txt_valorTrat.Leave

        lbl_mensagem.Text = ""
        If txt_valorTrat.Text.Equals("") Then txt_valorTrat.Text = "0,00"
        If IsNumeric(txt_valorTrat.Text) Then
            txt_valorTrat.Text = Format(CDbl(txt_valorTrat.Text), "##0.00")
        Else
            lbl_mensagem.Text = "Qtde do Tratamento deve ser Numerico !" : txt_valorTrat.Focus() : txt_valorTrat.SelectAll() : Return
        End If

    End Sub

    Private Sub btn_incTrat_Click(sender As Object, e As EventArgs) Handles btn_incTrat.Click

        lbl_mensagem.Text = ""
        If Trim(txt_tratamento.Text).Equals("") Then
            lbl_mensagem.Text = "Informe um nome de tratamento pra Inluir !"
            txt_tratamento.Focus()
            Return
        End If

        dtg_tratamento.Rows.Add(txt_tratamento.Text, cbo_dentistaTrat.Text, txt_qtdeTrat.Text, txt_valorTrat.Text)

    End Sub

    Private Sub btn_delTrat_Click(sender As Object, e As EventArgs) Handles btn_delTrat.Click

        Try

            If dtg_tratamento.CurrentRow.IsNewRow = False Then

                If MessageBox.Show("Deseja Realmente Deletar esse Tratamento?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                    dtg_tratamento.Rows.RemoveAt(dtg_tratamento.CurrentRow.Index)
                    dtg_tratamento.Refresh()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class