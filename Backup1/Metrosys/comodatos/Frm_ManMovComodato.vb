Imports System.Text
Imports Npgsql

Public Class Frm_ManMovComodato

    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private Const _valorZERO As Integer = 0
    Private _alterando As Boolean = False, _incluindo As Boolean = False
    Public Shared _frmRef As New Frm_ManMovComodato
    Dim _BuscaProd As New Frm_BuscaProdComo
    Dim _BuscaCli As New Frm_BuscaCli
    Public _privilegio As Boolean = False
    Private _idMovComodato As Int32 = _valorZERO

    'ultilizados para o DataGridView
    Private _oConnBDHEMOSIS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Private _cmdComodato As New NpgsqlCommand
    Private _sqlComodato As New StringBuilder
    Private _drComodato As NpgsqlDataReader

    Private Sub Frm_ManComodato_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                preencheDtg_MovComodatos("")

        End Select


    End Sub

    Private Sub Frm_ManComodato_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Frm_ManComodato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Dtg_MovComodatos.Rows.Clear()
        Me.Dtg_MovComodatos.Refresh()
        preencheDtg_MovComodatos("")
        btn_salvar.Enabled = False

    End Sub

    Private Sub preencheDtg_MovComodatos(ByVal consulta As String)

        Dim codTipoComodato As String = Mid(cbo_tipo.SelectedItem, 1, 2)

        Try
            If _oConnBDHEMOSIS.State = ConnectionState.Closed Then _oConnBDHEMOSIS.Open()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        If _oConnBDHEMOSIS.State = ConnectionState.Open Then
            Dim idComodato, cliente, produto, plaqueta As String
            Dim dtEmprestimo As Date

            Try

                _sqlComodato.Append("SELECT mv.mc_id, mv.mc_cdport, cad.p_portad, mv.mc_codpr, mv.mc_produto, ") '4
                _sqlComodato.Append("mv.mc_dtemprestimo, mv.mc_dtdevolucao, mv.mc_motorista, ci.im_plaqueta ") '8
                _sqlComodato.Append("FROM " & MdlEmpresaUsu._esqVinc & ".cadimobilizado ci, " & MdlEmpresaUsu._esqVinc)
                _sqlComodato.Append(".movcomodato mv LEFT JOIN cadp001 cad ON ")
                _sqlComodato.Append("mv.mc_cdport = cad.p_cod WHERE mv.mc_codpr = ci.im_codprid ")
                _sqlComodato.Append(consulta)

                Select Case Me.cbo_tipo.SelectedIndex
                    Case 1 'nome do cliente
                        _sqlComodato.Append("AND UPPER(cad.p_portad) LIKE @pesquisa ")
                        _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)
                        _cmdComodato.Parameters.Add("@pesquisa", Me.txt_pesquisa.Text & "%")

                    Case 2 'codigo do produto
                        If IsNumeric(Me.txt_pesquisa.Text) Then
                            _sqlComodato.Append("AND mc_codpr = @pesquisa ")
                            _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)
                            _cmdComodato.Parameters.Add("@pesquisa", Me.txt_pesquisa.Text)

                        Else
                            _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)

                        End If


                    Case 3 'plaqueta do produto
                        _sqlComodato.Append("AND UPPER(ci.im_plaqueta) LIKE @pesquisa ")
                        _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)
                        _cmdComodato.Parameters.Add("@pesquisa", Me.txt_pesquisa.Text & "%")

                    Case 4 'Data de emprestimo
                        _sqlComodato.Append("ORDER BY mc_dtemprestimo ASC")
                        _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)

                    Case Else
                        _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)

                End Select


                _drComodato = _cmdComodato.ExecuteReader

                Dtg_MovComodatos.Rows.Clear()
                Dtg_MovComodatos.Refresh()
                While _drComodato.Read
                    idComodato = _drComodato(0).ToString
                    cliente = _drComodato(2).ToString
                    produto = _drComodato(4).ToString
                    plaqueta = _drComodato(8).ToString
                    dtEmprestimo = _drComodato(5)

                    Dtg_MovComodatos.Rows.Add(idComodato, cliente, produto, plaqueta, _
                                              Format(dtEmprestimo, "dd/MM/yyyy"))

                End While

                Dtg_MovComodatos.Refresh()
                _drComodato.Close() : _oConnBDHEMOSIS.ClearPool()
            Catch ex As Exception
                MsgBox("ERRO ao trazer Movimento:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")

            Finally
                idComodato = Nothing : cliente = Nothing : produto = Nothing : plaqueta = Nothing
                dtEmprestimo = Nothing

            End Try

            _cmdComodato.CommandText = ""
            _sqlComodato.Remove(0, _sqlComodato.ToString.Length)
        End If



    End Sub

    Private Sub limpaCamposComodato()

        txt_codPart.Text = "" : txt_nomePart.Text = "" : txt_codProd.Text = ""
        txt_nomeProd.Text = "" : txt_motorista.Text = "" : dtp_dtEmprestimo.Text = ""
        dtp_dtDevolucao.Text = "" : _idMovComodato = _valorZERO

    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Subistituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False : tbc_comodatos.SelectTab(1)
                limpaCamposComodato() : tbp_cadComodato.Text = "Incluindo"
                btn_salvar.Enabled = True

            End If
        Else

            _incluindo = True : _alterando = False : tbc_comodatos.SelectTab(1)
            limpaCamposComodato() : txt_codPart.Focus()
            tbp_cadComodato.Text = "Incluindo" : btn_salvar.Enabled = True

        End If



    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                tbc_comodatos.SelectTab(0) : limpaCamposComodato() : tbp_cadComodato.Text = "Cadastro"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False

            End If

        Else

            tbc_comodatos.SelectTab(0) : limpaCamposComodato() : tbp_cadComodato.Text = "Cadastro"
            _incluindo = False : _alterando = False : btn_salvar.Enabled = False
        End If



    End Sub

    Private Sub trazMovComodSelecionado()

        _idMovComodato = Convert.ToInt32(Dtg_MovComodatos.CurrentRow.Cells(0).Value)

        Try

            If _oConnBDHEMOSIS.State = ConnectionState.Closed Then _oConnBDHEMOSIS.Open()

        Catch ex As Exception
            MsgBox("ERRO ao ABRIR Connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")

        End Try

        If _oConnBDHEMOSIS.State = ConnectionState.Open Then
            Dim codPart, nomePart, nomeProd, dtEmprestimo, dtDevolucao, motorista As String
            Dim codProd As Int32 = _valorZERO

            Try


                _sqlComodato.Append("SELECT mc_id, mc_cdport, cad.p_portad, mc_codpr, mc_produto, mc_dtemprestimo, ") '5
                _sqlComodato.Append("mc_dtdevolucao, mc_motorista FROM " & MdlEmpresaUsu._esqVinc & ".movcomodato LEFT JOIN ")
                _sqlComodato.Append("cadp001 cad ON mc_cdport = cad.p_cod WHERE mc_id = @mc_id")
                _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)
                _cmdComodato.Parameters.Add("@mc_id", _idMovComodato)
                _drComodato = _cmdComodato.ExecuteReader

                While _drComodato.Read
                    codPart = _drComodato(1).ToString
                    nomePart = _drComodato(2).ToString
                    codProd = _drComodato(3)
                    nomeProd = _drComodato(4).ToString
                    motorista = _drComodato(7).ToString

                    Try
                        dtEmprestimo = Format(CDate(_drComodato(5)), "dd/MM/yyyy")
                    Catch ex As Exception
                        dtEmprestimo = ""
                    End Try

                    Try
                        dtDevolucao = Format(CDate(_drComodato(6)), "dd/MM/yyyy")
                    Catch ex As Exception
                        dtDevolucao = ""
                    End Try



                    txt_codPart.Text = codPart
                    txt_nomePart.Text = nomePart
                    txt_codProd.Text = String.Format("{0:D5}", codProd)
                    txt_nomeProd.Text = nomeProd
                    dtp_dtEmprestimo.Text = dtEmprestimo
                    dtp_dtDevolucao.Text = dtDevolucao
                    txt_motorista.Text = motorista

                End While
                _drComodato.Close() : _oConnBDHEMOSIS.ClearPool()

            Catch ex As Exception
                MsgBox("ERRO em MOVIMENTO DE COMODATOS", MsgBoxStyle.Exclamation, "METROSYS")

            End Try


            _cmdComodato.CommandText = ""
            _sqlComodato.Remove(0, _sqlComodato.ToString.Length)

            'Limpa Objetos da Memória...
            codPart = Nothing : nomePart = Nothing : codProd = Nothing : nomeProd = Nothing
            dtEmprestimo = Nothing : dtDevolucao = Nothing : motorista = Nothing
        End If



    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If (_alterando = True) OrElse (_incluindo = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _alterando = True : _incluindo = False : tbc_comodatos.SelectTab(1)
                limpaCamposComodato() : trazMovComodSelecionado()
                txt_codPart.Focus() : tbp_cadComodato.Text = "Alterando" : btn_salvar.Enabled = True

            Else
                txt_codPart.Focus() : btn_salvar.Enabled = True

            End If
        Else

            _alterando = True : _incluindo = False : tbc_comodatos.SelectTab(1)
            limpaCamposComodato() : trazMovComodSelecionado() : txt_codPart.Focus()
            tbp_cadComodato.Text = "Alterando" : btn_salvar.Enabled = True

        End If



    End Sub

    Private Function verifCamposComodato() As Boolean

        Dim mCamposOK As Boolean = True


        If Trim(Me.txt_codPart.Text).Equals("") Then
            lbl_mensagem.Text = "Código do Cliente em branco !"
            mCamposOK = False
            Return mCamposOK

        End If

        If Trim(Me.txt_nomePart.Text).Equals("") Then
            lbl_mensagem.Text = "Nome do Cliente em branco !"
            mCamposOK = False
            Return mCamposOK
        End If

        If Trim(Me.txt_codProd.Text).Equals("") Then
            lbl_mensagem.Text = "Código do Produto em branco !"
            mCamposOK = False
            Return mCamposOK

        End If

        If Trim(Me.txt_nomeProd.Text).Equals("") Then
            lbl_mensagem.Text = "Nome do Produto em branco !"
            mCamposOK = False
            Return mCamposOK

        End If

        If Trim(Me.txt_motorista.Text).Equals("") Then
            lbl_mensagem.Text = "Nome do Motorista em branco !"
            mCamposOK = False
            Return mCamposOK
        End If

        If Not IsDate(dtp_dtDevolucao.Text) Then
            lbl_mensagem.Text = "Data de Devolução não é Data !"
            mCamposOK = False
            Return mCamposOK

        End If

        If Not IsDate(dtp_dtEmprestimo.Text) Then
            lbl_mensagem.Text = "Data de Emprestimo não é Data !"
            mCamposOK = False
            Return mCamposOK

        End If



        Return mCamposOK
    End Function

    Private Sub salvaProdutoIcluindo(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        Dim mcdport As String, mcodpr As Int32, mproduto As String, mmotorista As String
        Dim mdtemprestimo As Date, mdtdevolucao As Date

        mcdport = "" : mcodpr = _valorZERO : mproduto = "" : mmotorista = ""

        mcdport = txt_codPart.Text
        mcodpr = Convert.ToInt32(txt_codProd.Text)
        mproduto = txt_nomeProd.Text
        mdtemprestimo = CDate(dtp_dtEmprestimo.Text)
        mdtdevolucao = CDate(dtp_dtDevolucao.Text)
        mmotorista = txt_motorista.Text

        _clBD.incMovComodato(mcdport, mcodpr, mproduto, mdtemprestimo, mdtdevolucao, mmotorista, _
                             conection, transacao)


        'Limpa Objetos da Memória...
        mcdport = Nothing : mcodpr = Nothing : mproduto = Nothing : mmotorista = Nothing
        mdtemprestimo = Nothing : mdtdevolucao = Nothing


    End Sub

    Private Sub salvaProdutoAlterando(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        Dim mcdport As String, mcodpr As Int32, mproduto As String, mmotorista As String
        Dim mdtemprestimo As Date, mdtdevolucao As Date

        mcdport = "" : mcodpr = _valorZERO : mproduto = "" : mmotorista = ""

        mcdport = txt_codPart.Text
        mcodpr = Convert.ToInt32(txt_codProd.Text)
        mproduto = txt_nomeProd.Text
        mdtemprestimo = CDate(dtp_dtEmprestimo.Text)
        mdtdevolucao = CDate(dtp_dtDevolucao.Text)
        mmotorista = txt_motorista.Text

        _clBD.altMovComodato(_idMovComodato, mcdport, mcodpr, mproduto, mdtemprestimo, mdtdevolucao, _
                             mmotorista, conection, transacao)


        'Limpa Objetos da Memória...
        mcdport = Nothing : mcodpr = Nothing : mproduto = Nothing : mmotorista = Nothing
        mdtemprestimo = Nothing : mdtdevolucao = Nothing


    End Sub

    Private Sub btn_salvar_Click_Incluindo()

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                conection = Nothing
                Return

            End Try

            transacao = conection.BeginTransaction

            If _clBD.existeMovComodato(_valorZERO, Convert.ToInt32(Me.txt_codProd.Text), conection) Then
                MsgBox("Produto já existe em um movimento", MsgBoxStyle.Exclamation)
                conection = Nothing : transacao = Nothing
                Return

            Else
                salvaProdutoIcluindo(conection, transacao)
            End If

            transacao.Commit() : conection.ClearPool()

            If MessageBox.Show("Movimento salvo com sucesso! Deseja continuar incluindo?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                txt_codProd.Text = "" : txt_nomeProd.Text = ""
                txt_codPart.Text = "" : txt_nomePart.Text = ""
            Else
                tbc_comodatos.SelectTab(0) : limpaCamposComodato() : preencheDtg_MovComodatos("")
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False


            End If

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try

        Finally

            If conection.State = ConnectionState.Open Then conection.Close()
            transacao = Nothing : conection = Nothing
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

            If _clBD.existeMovComodato(_idMovComodato, Convert.ToInt32(Me.txt_codProd.Text), conection) Then
                MsgBox("Produto já existe em um movimento", MsgBoxStyle.Exclamation)
                conection = Nothing : transacao = Nothing
                Return

            Else
                salvaProdutoAlterando(conection, transacao)
            End If

            transacao.Commit() : conection.ClearPool()

            MsgBox("Movimento salvo com sucesso", MsgBoxStyle.Exclamation)

            _incluindo = False : _alterando = False : btn_salvar.Enabled = False
            tbc_comodatos.SelectTab(0) : limpaCamposComodato() : preencheDtg_MovComodatos("")


        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try

        Finally

            If conection.State = ConnectionState.Open Then conection.Close()
            transacao = Nothing : conection = Nothing
        End Try



    End Sub

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        If verifCamposComodato() = True Then

            If _incluindo = True Then

                btn_salvar_Click_Incluindo()

            ElseIf _alterando = True Then

                btn_salvar_Click_Alterando()

            End If
        End If



    End Sub

    Public Function trazCliente(ByVal codCli As String) As Boolean

        Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        Dim pesquisa As String = codCli.ToUpper

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        Dim codigo, nome, cpf_cnpj, inscricao, UF As String
        codigo = "" : nome = "" : cpf_cnpj = "" : inscricao = "" : UF = ""


        Try
            SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc,p_uf FROM cadp001 WHERE ") ' 5
            SqlParticipante.Append("p_cod = '" & pesquisa & "' ORDER BY p_portad ASC")
            CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDMETROSYS)
            drParticipante = CmdParticipante.ExecuteReader

            If drParticipante.HasRows = False Then
                Return False
            Else
                While drParticipante.Read
                    codigo = drParticipante(_valorZERO).ToString
                    nome = drParticipante(1).ToString

                End While
                Me.txt_nomePart.Text = nome
                drParticipante.Close() : oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()

            End If

        Catch ex As Exception
            MsgBox("ERRO no Select do Cliente:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        CmdParticipante.CommandText = ""
        SqlParticipante.Remove(_valorZERO, SqlParticipante.ToString.Length)

        'Limpa Objetos da Memoria...
        codigo = Nothing : nome = Nothing : cpf_cnpj = Nothing : inscricao = Nothing : UF = Nothing
        drParticipante = Nothing : CmdParticipante = Nothing : SqlParticipante = Nothing
        oConnBDMETROSYS = Nothing



        Return True
    End Function

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown

        If Not Me.txt_codPart.Text.Equals("") Then

            If (Me.txt_codPart.TextLength > 5) AndAlso (e.KeyCode = Keys.Enter) Then 'Se retornar nada

                If trazCliente(Me.txt_codPart.Text) Then

                    Dim lShouldReturn As Boolean
                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing

                End If
            End If
        End If

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

            If Me.txt_codPart.Text.Equals("") Then
                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    _frmRef = Me
                    _BuscaCli.set_frmRef(Me)
                    _BuscaCli.ShowDialog(Me)
                    If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus()

                    Dim lShouldReturn As Boolean
                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing

                Catch ex As Exception
                End Try

            End If
        End If



    End Sub

    Public Function trazItenBD(ByVal codIten As String) As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        Dim codigo, nome As String
        Try
            SqlProduto.Append("SELECT im_codprid, im_tipo, im_portad FROM " & MdlEmpresaUsu._esqVinc & ".cadimobilizado ") ' 5
            SqlProduto.Append("WHERE im_codprid = @im_codprid ORDER BY im_portad ASC")
            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDGENOV)
            CmdProduto.Parameters.Add("@im_codprid", Me.txt_codProd.Text)

            drProduto = CmdProduto.ExecuteReader

            If drProduto.HasRows = False Then Return False
            While drProduto.Read
                codigo = drProduto(_valorZERO).ToString

                Select Case drProduto(1).ToString
                    Case "00"
                        nome = ""
                    Case "01"
                        nome = "Freezer"
                    Case "02"
                        nome = "Outros"
                    Case Else
                        nome = ""
                End Select


                Me.txt_codProd.Text = codigo : Me.txt_nomeProd.Text = nome
            End While

            drProduto.Close() : oConnBDGENOV.ClearPool() : oConnBDGENOV.Close()
        Catch ex As Exception
            MsgBox("ERRO no Select do Produto:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        CmdProduto.CommandText = ""
        SqlProduto.Remove(_valorZERO, SqlProduto.ToString.Length)


        'Limpa Objetos da Memoria...
        codigo = Nothing : nome = Nothing : drProduto = Nothing : CmdProduto = Nothing
        SqlProduto = Nothing : oConnBDGENOV = Nothing



        Return True
    End Function

    Private Sub txt_codProd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codProd.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

            If Me.txt_codProd.Text.Equals("") Then
                'Aqui tenta chamar a Busca do Produto...
                Try
                    _frmRef = Me
                    _BuscaProd.set_frmRef(Me)
                    _BuscaProd.ShowDialog(Me)

                    If Me.txt_codProd.Text.Equals("") Then
                        Me.txt_codProd.Focus()
                    Else
                        Me.txt_codProd.Text = String.Format("{0:D5}", Convert.ToInt32(Me.txt_codProd.Text))
                    End If

                Catch ex As Exception
                End Try

            Else

                If trazItenBD(Me.txt_codProd.Text) = False Then
                    'Aqui tenta chamar a Busca do Produto...
                    Try
                        _frmRef = Me
                        _BuscaProd.set_frmRef(Me)
                        _BuscaProd.ShowDialog(Me)
                        If Me.txt_codProd.Text.Equals("") Then
                            Me.txt_codProd.Focus()
                        Else
                            Me.txt_codProd.Text = String.Format("{0:D5}", Convert.ToInt32(Me.txt_codProd.Text))
                        End If

                    Catch ex As Exception
                    End Try

                Else

                    If Me.txt_codProd.Text.Equals("") Then
                        Me.txt_codProd.Focus()
                    Else
                        Me.txt_codProd.Text = String.Format("{0:D5}", Convert.ToInt32(Me.txt_codProd.Text))
                    End If

                End If


            End If
        End If



    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        preencheDtg_MovComodatos("")

    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click

        If MessageBox.Show("Deseja realmente excluir esse movimento?", "METROSYS", MessageBoxButtons.YesNo, _
        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

            Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim transaction As NpgsqlTransaction
            Try
                connection.Open()
                transaction = connection.BeginTransaction

                _clBD.delMovComodato(Dtg_MovComodatos.CurrentRow.Cells(0).Value, connection, transaction)

                transaction.Commit() : connection.ClearPool()

                preencheDtg_MovComodatos("")
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")

            Finally

                If connection.State = ConnectionState.Open Then connection.Close()
                connection = Nothing : transaction = Nothing
            End Try
        End If



    End Sub

    Private Sub cbo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tipo.SelectedIndexChanged

        Select Case cbo_tipo.SelectedIndex
            Case 4 'Caso for Data de Emprestimo...
                preencheDtg_MovComodatos("")

        End Select


    End Sub

End Class