Imports System.Text
Imports Npgsql

Public Class Frm_cadAutomovel

    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private _clAutomovel As New Cl_Automovel

    Private Const _valorZERO As Integer = 0
    Private _alterando As Boolean = False, _incluindo As Boolean = False
    Public Shared _frmRef As New Frm_cadAutomovel
    Dim _BuscaCli As New Frm_BuscaCli
    Public _privilegio As Boolean = False

    'ultilizados para o DataGridView
    Private _oConnBDHEMOSIS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Private _cmdAutomovel As New NpgsqlCommand
    Private _sqlAutomovel As New StringBuilder
    Private _drAutomovel As NpgsqlDataReader


    Private Sub Frm_cadAutomovel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                preencheDtg_Automovels()

        End Select



    End Sub

    Private Sub Frm_cadAutomovel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Frm_cadAutomovel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Dtg_automovel.Rows.Clear() : Me.Dtg_automovel.Refresh()
        preencheDtg_Automovels()


    End Sub

    Private Sub preencheDtg_Automovels()

        Try
            If _oConnBDHEMOSIS.State = ConnectionState.Closed Then _oConnBDHEMOSIS.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim idAutomovel, Fornecedor, placa, descricao As String

        Try

            _sqlAutomovel.Append("SELECT au.aut_id, au.aut_placa, au.aut_descricao, cadp.p_portad ") ' 3
            _sqlAutomovel.Append("FROM cadautomovel au ")
            _sqlAutomovel.Append("JOIN cadp001 cadp ON au.aut_fornecedor = cadp.p_cod ")
            _cmdAutomovel = New NpgsqlCommand(_sqlAutomovel.ToString, _oConnBDHEMOSIS)
            _drAutomovel = _cmdAutomovel.ExecuteReader

            Dtg_automovel.Rows.Clear()
            Dtg_automovel.Refresh()
            While _drAutomovel.Read
                idAutomovel = _drAutomovel(0).ToString
                placa = _drAutomovel(1).ToString
                descricao = _drAutomovel(2).ToString
                Fornecedor = _drAutomovel(3).ToString


                Dtg_automovel.Rows.Add(idAutomovel, placa, descricao, Fornecedor)

            End While

            Dtg_automovel.Refresh()
            _drAutomovel.Close()
        Catch ex As Exception
            MsgBox("ERRO ao trazer Movimento:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")

        Finally
            'LIMPA OBJETO DA MEMORIA..
            idAutomovel = Nothing : Fornecedor = Nothing : placa = Nothing : descricao = Nothing

        End Try

        _cmdAutomovel.CommandText = ""
        _sqlAutomovel.Remove(0, _sqlAutomovel.ToString.Length)
        _oConnBDHEMOSIS.ClearPool()


    End Sub

    Private Sub limpaCamposAutomovel()

        txt_codAutomovel.Text = "" : txt_placa.Text = "" : txt_codPart.Text = ""
        txt_nomePart.Text = "" : txt_descricao.Text = ""

    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        If Not txt_codAutomovel.Text.Equals("") Then 'Se tiver operação executando, então...
            If MessageBox.Show("Operação em aberto! Ela será Subistituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False : _clAutomovel.zeraValores()
                tbc_Automovels.SelectTab(1) : limpaCamposAutomovel()
                tbp_cadAutomovel.Text = "Incluindo"
                btn_salvar.Enabled = True

            End If
        Else

            _incluindo = True : _alterando = False : _clAutomovel.zeraValores()
            tbc_Automovels.SelectTab(1) : limpaCamposAutomovel() : txt_codAutomovel.Focus()
            tbp_cadAutomovel.Text = "Incluindo"
            btn_salvar.Enabled = True

        End If



    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If Not txt_codAutomovel.Text.Equals("") Then
            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _clAutomovel.zeraValores() : tbc_Automovels.SelectTab(0) : limpaCamposAutomovel()
                tbp_cadAutomovel.Text = "Cadastro"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False

            End If

        Else

            _clAutomovel.zeraValores() : tbc_Automovels.SelectTab(0) : limpaCamposAutomovel()
            tbp_cadAutomovel.Text = "Cadastro"
            _incluindo = False : _alterando = False : btn_salvar.Enabled = False

        End If


    End Sub

    Private Sub trazAutomovelSelecionado()

        Dim idAutomovel As String = ""
        idAutomovel = Dtg_automovel.CurrentRow.Cells(0).Value

        Try
            If _oConnBDHEMOSIS.State = ConnectionState.Closed Then _oConnBDHEMOSIS.Open()

        Catch ex As Exception
            MsgBox("ERRO ao ABRIR CONEXÃO:: ", MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim codigo, nome, placa, codPart, nomePart, descricao As String

        Try
            _sqlAutomovel.Append("SELECT aut_id, aut_placa, aut_descricao, aut_fornecedor, cadp.p_portad ") '4
            _sqlAutomovel.Append("FROM cadautomovel LEFT JOIN cadp001 cadp ON aut_fornecedor = cadp.p_cod ")
            _sqlAutomovel.Append("WHERE aut_id = @aut_id")
            _cmdAutomovel = New NpgsqlCommand(_sqlAutomovel.ToString, _oConnBDHEMOSIS)
            _cmdAutomovel.Parameters.Add("@aut_id", idAutomovel)
            _drAutomovel = _cmdAutomovel.ExecuteReader

            While _drAutomovel.Read
                codigo = String.Format("{0:D5}", _drAutomovel(0))
                nomePart = _drAutomovel(4).ToString
                _clAutomovel.pPlaca = _drAutomovel(1).ToString
                _clAutomovel.pDescricao = _drAutomovel(2).ToString
                _clAutomovel.pCodPart = _drAutomovel(3).ToString

                txt_codAutomovel.Text = codigo
                txt_placa.Text = _clAutomovel.pPlaca
                txt_codPart.Text = _clAutomovel.pCodPart
                txt_nomePart.Text = nomePart
                txt_descricao.Text = _clAutomovel.pDescricao

            End While
            _drAutomovel.Close()

        Catch ex As Exception
            MsgBox("Erro ao trazer Automovel:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")

        Finally
            'LIMPA OBJETOS DA MEMORIA...
            codigo = Nothing : nome = Nothing : placa = Nothing : codPart = Nothing
            nomePart = Nothing : descricao = Nothing

        End Try

        _cmdAutomovel.CommandText = ""
        _sqlAutomovel.Remove(0, _sqlAutomovel.ToString.Length)
        _oConnBDHEMOSIS.ClearPool()


    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If Not txt_codAutomovel.Text.Equals("") Then 'Se tiver operação executando, então...
            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _alterando = True : _incluindo = False : tbc_Automovels.SelectTab(1)
                _clAutomovel.zeraValores()
                limpaCamposAutomovel() : trazAutomovelSelecionado() : txt_codAutomovel.Focus()
                tbp_cadAutomovel.Text = "Alterando" : btn_salvar.Enabled = True

            Else
                txt_codAutomovel.Focus()
                btn_salvar.Enabled = True

            End If
        Else

            _alterando = True : _incluindo = False : tbc_Automovels.SelectTab(1)
            _clAutomovel.zeraValores()
            limpaCamposAutomovel() : trazAutomovelSelecionado() : txt_codAutomovel.Focus()
            tbp_cadAutomovel.Text = "Alterando" : btn_salvar.Enabled = True

        End If



    End Sub

    Private Function verifCamposAutomovel() As Boolean

        Dim mCamposOK As Boolean = True

        If Trim(Me.txt_placa.Text).Equals("") Then
            lbl_mensagem.Text = "Informe o Modelo do Automovel !"
            mCamposOK = False
            Return mCamposOK

        End If

        If Trim(Me.txt_codPart.Text).Equals("") Then
            lbl_mensagem.Text = "Código do Fornecedor em branco !"
            mCamposOK = False
            Return mCamposOK

        End If

        If Trim(Me.txt_nomePart.Text).Equals("") Then
            lbl_mensagem.Text = "Nome do Fornecedor em branco !"
            mCamposOK = False
            Return mCamposOK

        End If



        Return mCamposOK
    End Function

    Private Sub salvaProdutoIcluindo(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)


        _clAutomovel.pPlaca = txt_placa.Text : _clAutomovel.pCodPart = txt_codPart.Text
        _clAutomovel.pDescricao = txt_descricao.Text

        _clBD.incAutomovel(_clAutomovel, conection, transacao)



    End Sub

    Private Sub salvaProdutoAlterando(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        Dim mId As Int32 = _valorZERO


        mId = Convert.ToInt32(Me.txt_codAutomovel.Text)
        _clAutomovel.pPlaca = txt_placa.Text : _clAutomovel.pCodPart = txt_codPart.Text : _clAutomovel.pDescricao = txt_descricao.Text

        _clBD.altAutomovel(mId, _clAutomovel, conection, transacao)


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
            transacao.Commit()

            If MessageBox.Show("Automovel salvo com sucesso! Deseja continuar incluindo?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                _clAutomovel.zeraValores()
                txt_placa.Text = "" : txt_codPart.Text = "" : txt_nomePart.Text = ""
                conection.ClearPool() : conection.Close() : transacao = Nothing
                conection = Nothing : _incluindo = True : _alterando = False

            Else
                _clAutomovel.zeraValores()
                tbc_Automovels.SelectTab(0) : limpaCamposAutomovel()
                preencheDtg_Automovels() : conection.ClearPool() : conection.Close()
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False
                transacao = Nothing : conection = Nothing

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
            transacao.Commit()

            MsgBox("Automovel salvo com sucesso", MsgBoxStyle.Exclamation)
            _clAutomovel.zeraValores()
            tbc_Automovels.SelectTab(0) : limpaCamposAutomovel()
            preencheDtg_Automovels() : conection.ClearPool() : conection.Close()
            _incluindo = False : _alterando = False : btn_salvar.Enabled = False
            transacao = Nothing : conection = Nothing

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try
        End Try



    End Sub

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        If verifCamposAutomovel() = True Then
            If _incluindo = True Then

                btn_salvar_Click_Incluindo()

            ElseIf _alterando = True Then

                btn_salvar_Click_Alterando()

            End If

        End If


    End Sub

    Public Function trazFornecedor(ByVal codCli As String) As Boolean

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
                drParticipante.Close()
                Me.txt_nomePart.Text = nome

            End If

        Catch ex As Exception
        End Try

        CmdParticipante.CommandText = ""
        SqlParticipante.Remove(_valorZERO, SqlParticipante.ToString.Length)
        'LIMPA OBJETOS DA MEMORIA...
        codigo = Nothing : nome = Nothing : cpf_cnpj = Nothing : inscricao = Nothing : UF = Nothing
        CmdParticipante = Nothing : SqlParticipante = Nothing : drParticipante = Nothing
        oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close() : oConnBDMETROSYS = Nothing


        Return True
    End Function

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown

        If Not Me.txt_codPart.Text.Equals("") Then

            If Me.txt_codPart.TextLength > 5 AndAlso e.KeyCode = Keys.Enter Then 'Se retornar nada

                If trazFornecedor(Me.txt_codPart.Text) Then

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