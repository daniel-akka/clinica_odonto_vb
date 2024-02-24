Imports System.Text
Imports Npgsql

Public Class Frm_ManComodato

    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private Const _valorZERO As Integer = 0
    Private _alterando As Boolean = False, _incluindo As Boolean = False
    Public Shared _frmRef As New Frm_ManComodato
    Dim _BuscaCli As New Frm_BuscaCli
    Public _privilegio As Boolean = False

    'ultilizados para o DataGridView
    Private _oConnBDHEMOSIS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Private _cmdComodato As New NpgsqlCommand
    Private _sqlComodato As New StringBuilder
    Private _drComodato As NpgsqlDataReader


    Private Sub Frm_ManComodato_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape Then Me.Close()

    End Sub

    Private Sub Frm_ManComodato_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Frm_ManComodato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Dtg_Comodatos.Rows.Clear()
        Me.Dtg_Comodatos.Refresh()
        Me.cbo_tipoPesq.SelectedIndex = _valorZERO

    End Sub

    Private Sub preencheDtg_Comodatos()

        Dim codTipoComodato As String = Mid(cbo_tipoPesq.SelectedItem, 1, 2)

        Try
            If _oConnBDHEMOSIS.State = ConnectionState.Closed Then _oConnBDHEMOSIS.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim idComodato, tipo, cliente, modelo, plaqueta As String
        tipo = ""

        Try

            _sqlComodato.Append("SELECT ci.im_codprid, ci.im_tipo, ci.im_portad, ci.im_modelo, ci.im_plaqueta ") ' 4
            _sqlComodato.Append("FROM " & MdlEmpresaUsu._esqVinc & ".cadimobilizado ci ")
            '_sqlComodato.Append("FROM cadimobilizado ci JOIN cadp001 cad ON ci.im_cdport = cad.p_cod ")
            If Me.cbo_tipoPesq.SelectedIndex > _valorZERO Then _sqlComodato.Append("WHERE ci.im_tipo = @im_tipo")
            _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)
            If Me.cbo_tipoPesq.SelectedIndex > _valorZERO Then _cmdComodato.Parameters.Add("@im_tipo", codTipoComodato)

            _drComodato = _cmdComodato.ExecuteReader

            Dtg_Comodatos.Rows.Clear()
            Dtg_Comodatos.Refresh()
            While _drComodato.Read
                idComodato = _drComodato(0).ToString
                tipo = nomeTipoComodato(_drComodato(1).ToString)
                cliente = _drComodato(2).ToString
                modelo = _drComodato(3).ToString
                plaqueta = _drComodato(4).ToString


                Dtg_Comodatos.Rows.Add(idComodato, tipo, cliente, modelo, plaqueta)

            End While

            Dtg_Comodatos.Refresh() : _drComodato.Close() : _oConnBDHEMOSIS.ClearPool()
        Catch ex As Exception
            MsgBox("ERRO ao trazer Movimento:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")

        Finally
            'LIMPA OBJETO DA MEMORIA..
            idComodato = Nothing : tipo = Nothing : cliente = Nothing : modelo = Nothing : plaqueta = Nothing

        End Try

        _cmdComodato.CommandText = ""
        _sqlComodato.Remove(0, _sqlComodato.ToString.Length)



    End Sub

    Private Function nomeTipoComodato(ByVal codTipoComodato As String)

        Select Case codTipoComodato
            Case "00"
                Return ""
            Case "01"
                Return "Freezer"
            Case "02"
                Return "Outros"
            Case Else
                Return ""

        End Select



    End Function

    Private Sub limpaCamposComodato()

        txt_codComodato.Text = ""
        cbo_tipo.SelectedIndex = -1
        txt_modelo.Text = ""
        txt_codPart.Text = ""
        txt_nomePart.Text = ""
        txt_plaqueta.Text = ""
        txt_observacao.Text = ""

    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        If Not txt_codComodato.Text.Equals("") Then 'Se tiver operação executando, então...
            If MessageBox.Show("Operação em aberto! Ela será Subistituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False
                tbc_comodatos.SelectTab(1)
                limpaCamposComodato()
                tbp_cadComodato.Text = "Incluindo"
                btn_salvar.Enabled = True

            End If
        Else

            _incluindo = True : _alterando = False
            tbc_comodatos.SelectTab(1)
            limpaCamposComodato()
            txt_codComodato.Focus()
            tbp_cadComodato.Text = "Incluindo"
            btn_salvar.Enabled = True

        End If



    End Sub

    Private Sub cbo_tipoPesq_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tipoPesq.SelectedIndexChanged

        preencheDtg_Comodatos()

    End Sub

    Private Sub cbo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo.GotFocus

        If Not (cbo_tipo.DroppedDown) Then cbo_tipo.DroppedDown = True

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If Not txt_codComodato.Text.Equals("") Then
            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                tbc_comodatos.SelectTab(0)
                limpaCamposComodato()
                tbp_cadComodato.Text = "Cadastro"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False

            End If

        Else

            tbc_comodatos.SelectTab(0)
            limpaCamposComodato()
            tbp_cadComodato.Text = "Cadastro"
            _incluindo = False : _alterando = False : btn_salvar.Enabled = False

        End If


    End Sub

    Private Sub trazProdutoSelecionado()

        Dim idComodato As String = ""
        idComodato = Dtg_Comodatos.CurrentRow.Cells(0).Value

        Try
            If _oConnBDHEMOSIS.State = ConnectionState.Closed Then _oConnBDHEMOSIS.Open()

        Catch ex As Exception
            MsgBox("ERRO ao ABRIR CONEXÃO:: ", MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim codigo, nome, tipo, modelo, codPart, nomePart, plaqueta, observ As String

        Try
            _sqlComodato.Append("SELECT im_codprid, im_tipo, im_modelo, im_cdport, im_portad, im_plaqueta, ") '5
            _sqlComodato.Append("im_observ FROM " & MdlEmpresaUsu._esqVinc & ".cadimobilizado ")
            '_sqlComodato.Append("im_observ FROM cadimobilizado LEFT JOIN cadp001 cadp ON e.e_cdport = cadp.p_cod ")
            _sqlComodato.Append("WHERE im_codprid = @im_codprid")
            _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)
            _cmdComodato.Parameters.Add("@im_codprid", idComodato)
            _drComodato = _cmdComodato.ExecuteReader

            While _drComodato.Read
                codigo = String.Format("{0:D5}", _drComodato(0))
                tipo = _drComodato(1).ToString
                modelo = _drComodato(2).ToString
                codPart = _drComodato(3).ToString
                nomePart = _drComodato(4).ToString
                plaqueta = _drComodato(5).ToString
                observ = _drComodato(6).ToString


                txt_codComodato.Text = codigo
                cbo_tipo.SelectedIndex = _clFuncoes.trazIndexCboTipComodato(tipo, cbo_tipo)
                txt_modelo.Text = modelo
                txt_codPart.Text = codPart
                txt_nomePart.Text = nomePart
                txt_plaqueta.Text = plaqueta
                txt_observacao.Text = observ

            End While
            _drComodato.Close() : _oConnBDHEMOSIS.ClearPool()

        Catch ex As Exception
            MsgBox("Tabela de COMODATOS Inexistente", MsgBoxStyle.Exclamation, "METROSYS")

        Finally
            'LIMPA OBJETOS DA MEMORIA...
            codigo = Nothing : nome = Nothing : tipo = Nothing : modelo = Nothing : codPart = Nothing
            nomePart = Nothing : plaqueta = Nothing : observ = Nothing

        End Try

        _cmdComodato.CommandText = ""
        _sqlComodato.Remove(0, _sqlComodato.ToString.Length)



    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If Not txt_codComodato.Text.Equals("") Then 'Se tiver operação executando, então...
            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _alterando = True : _incluindo = False : tbc_comodatos.SelectTab(1)
                limpaCamposComodato() : trazProdutoSelecionado() : txt_codComodato.Focus()
                tbp_cadComodato.Text = "Alterando" : btn_salvar.Enabled = True

            Else
                txt_codComodato.Focus()
                btn_salvar.Enabled = True

            End If
        Else

            _alterando = True : _incluindo = False : tbc_comodatos.SelectTab(1)
            limpaCamposComodato() : trazProdutoSelecionado() : txt_codComodato.Focus()
            tbp_cadComodato.Text = "Alterando" : btn_salvar.Enabled = True

        End If



    End Sub

    Private Function verifCamposComodato() As Boolean

        Dim mCamposOK As Boolean = True

        If Me.cbo_tipo.SelectedIndex < _valorZERO Then
            lbl_mensagem.Text = "Selecione um Tipo de Comodato !"
            mCamposOK = False
            Return mCamposOK

        End If

        If Trim(Me.txt_modelo.Text).Equals("") Then
            lbl_mensagem.Text = "Informe o Modelo do Comodato !"
            mCamposOK = False
            Return mCamposOK

        End If

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

        If Trim(Me.txt_plaqueta.Text).Equals("") Then
            lbl_mensagem.Text = "Informe a plaqueta do Comodato !"
            mCamposOK = False
            Return mCamposOK

        End If



        Return mCamposOK
    End Function

    Private Sub salvaProdutoIcluindo(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)
        Dim mTipo As String, mModelo As String, mCodPart As String, mNomePart As String, mPlaqueta As String
        Dim mObservacao As String

        mTipo = "" : mModelo = "" : mCodPart = "" : mNomePart = "" : mPlaqueta = "" : mObservacao = ""

        mTipo = Mid(cbo_tipo.SelectedItem, 1, 2)
        mModelo = txt_modelo.Text
        mCodPart = txt_codPart.Text
        mNomePart = txt_nomePart.Text
        mPlaqueta = txt_plaqueta.Text
        mObservacao = txt_observacao.Text

        _clBD.incComodato(mTipo, mModelo, mCodPart, mNomePart, mPlaqueta, mObservacao, conection, transacao)


    End Sub

    Private Sub salvaProdutoAlterando(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        Dim mCodigo As Int32 = _valorZERO
        Dim mTipo As String, mModelo As String, mCodPart As String, mNomePart As String, mPlaqueta As String
        Dim mObservacao As String

        mTipo = "" : mModelo = "" : mCodPart = "" : mNomePart = "" : mPlaqueta = "" : mObservacao = ""

        mCodigo = Convert.ToInt32(Me.txt_codComodato.Text)
        mTipo = Mid(cbo_tipo.SelectedItem, 1, 2)
        mModelo = txt_modelo.Text
        mCodPart = txt_codPart.Text
        mNomePart = txt_nomePart.Text
        mPlaqueta = txt_plaqueta.Text
        mObservacao = txt_observacao.Text

        _clBD.altComodato(mCodigo, mTipo, mModelo, mCodPart, mNomePart, mPlaqueta, mObservacao, conection, transacao)



    End Sub

    Private Sub btn_salvar_Click_Incluindo()

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction

        Try

            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            transacao = conection.BeginTransaction
            salvaProdutoIcluindo(conection, transacao)
            transacao.Commit() : conection.ClearPool()

            If MessageBox.Show("Comodato salvo com sucesso! Deseja continuar incluindo?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                txt_modelo.Text = "" : txt_codPart.Text = "" : txt_nomePart.Text = "" : txt_plaqueta.Text = ""
                conection.Close() : transacao = Nothing : conection = Nothing

            Else
                tbc_comodatos.SelectTab(0)
                limpaCamposComodato()
                preencheDtg_Comodatos()
                conection.Close() : transacao = Nothing : conection = Nothing

            End If

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try
        End Try



    End Sub

    Private Sub btn_salvar_Click_Alterando()

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction

        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            transacao = conection.BeginTransaction
            salvaProdutoAlterando(conection, transacao)
            transacao.Commit() : conection.ClearPool()

            MsgBox("Comodato salvo com sucesso", MsgBoxStyle.Exclamation)
            tbc_comodatos.SelectTab(0)
            limpaCamposComodato()
            preencheDtg_Comodatos()
            conection.Close() : transacao = Nothing : conection = Nothing

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try
        End Try



    End Sub

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        If verifCamposComodato() = True Then
            If _incluindo = True Then

                btn_salvar_Click_Incluindo()
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False

            ElseIf _alterando = True Then

                btn_salvar_Click_Alterando()
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False

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
                drParticipante.Close() : oConnBDMETROSYS.ClearPool()

            End If

        Catch ex As Exception
        End Try

        CmdParticipante.CommandText = ""
        SqlParticipante.Remove(_valorZERO, SqlParticipante.ToString.Length)
        'LIMPA OBJETOS DA MEMORIA...
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
                    Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()
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
                    Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing

                Catch ex As Exception
                End Try

            End If
        End If



    End Sub

End Class