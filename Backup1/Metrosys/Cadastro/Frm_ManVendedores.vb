Imports System
Imports System.Text
Imports System.IO
Imports Npgsql

Public Class Frm_ManVendedores

    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private _clVendedor As New Cl_Vendedor
    Private Const _valorZERO As Integer = 0
    Public _alterando As Boolean = False, _incluindo As Boolean = False
    Private _ufCorrenteCbo As String = ""

    'ultilizados para o DataGridView
    Private _oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Private _cmdVendedor As New NpgsqlCommand
    Private _sqlVendedor As New StringBuilder
    Private _drVendedor As NpgsqlDataReader
    Private _idVendedor As Int32 = _valorZERO
    Private _senhaVendedor As String = ""
    Private _tipoComissao As String = ""


    Private Sub Frm_ManVendedores_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

        End Select


    End Sub

    Private Sub Frm_ManVendedores_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub btn_buscaImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscaImg.Click

        'Abre Janela para a procura de imagens...
        Try
            openFileD_img.Title = "Arquivos de Imagem"
            openFileD_img.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF"
            openFileD_img.ShowDialog()
            openFileD_img.CheckFileExists = True : openFileD_img.CheckPathExists = True
            If Not openFileD_img.FileName.Equals(Nothing) Then Me.txt_localfoto.Text = openFileD_img.FileName

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)

        End Try



    End Sub

    Private Sub txt_localfoto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_localfoto.TextChanged

        Try
            pct_foto.ImageLocation = Me.txt_localfoto.Text
        Catch ex As Exception
        End Try


    End Sub

    Private Sub limpaCamposVendedor()

        Me.txt_codVendedor.Text = "" : Me.txt_nome.Text = "" : Me.txt_endereco.Text = ""
        Me.cbo_uf.SelectedIndex = -1 : Me.cbo_cidade.SelectedIndex = -1
        Me.txt_bairro.Text = "" : Me.msk_fone.Text = "" : Me.msk_celular.Text = ""
        Me.txt_rota.Text = "0" : Me.cbo_supervisor.SelectedIndex = -1

        Me.chk_comissionado.Checked = False : Me.rdb_nenhum.Checked = False : Me.rdb_produto.Checked = False
        Me.rdb_liquidez.Checked = False : Me.rdb_total.Checked = False : Me.txt_alqcomis.Text = "0,00"
        cbo_tipo.SelectedIndex = -1

        Me.txt_mensag1.Text = "" : Me.txt_mensag2.Text = "" : Me.txt_mensag3.Text = ""
        Me.msk_senha.Text = "" : Me.txt_localfoto.Text = "" : Me.lbl_mensagem01.Text = ""
        Me.lbl_mensagem02.Text = "" : Me.txt_descMax.Text = "0,00"
        Me.cbo_dispositivo.SelectedIndex = 0

        _idVendedor = _valorZERO


    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click
        Try
            If (_incluindo = True) OrElse (_alterando = True) Then

                If MessageBox.Show("Operação em aberto! Ela será Subistituída!", "METROSYS", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    _incluindo = True : _alterando = False : tbc_vendedores.SelectTab(1) : limpaCamposVendedor()
                    _clVendedor.zeraValores()
                    Me.txt_nome.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True

                End If
            Else
                _incluindo = True : _alterando = False : tbc_vendedores.SelectTab(1) : limpaCamposVendedor()
                _clVendedor.zeraValores()
                Me.txt_nome.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True

            End If

        Catch ex As Exception
            lbl_mensagem01.Text = "ERRO:: " & ex.Message & "!"

        End Try



    End Sub

    Private Sub preencheDgrd_Vendedor(ByVal pesquisa As String)

        Dim nomeCampo As String = ""
        lbl_mensagem01.Text = "" : nomeCampo = "v_nome"

        Try
            If _oConnBDMETROSYS.State = ConnectionState.Closed Then _oConnBDMETROSYS.Open()
        Catch ex As Exception
            lbl_mensagem01.Text = "ERRO:: " & ex.Message & "!" : Return

        End Try

        If _oConnBDMETROSYS.State = ConnectionState.Open Then
            Dim nome, codigo, endereco, uf, cidade, fone, celular, supervisor As String
            Dim id As Int32 = _valorZERO
            supervisor = ""

            Try
                _sqlVendedor.Append("SELECT v_id, v_codigo, v_nome, v_endereco, v_uf, v_cidade, v_bairro, ") '6
                _sqlVendedor.Append("v_fone, v_celular, v_comissionado, v_tipocomissao, v_alqcomiss, ") '11
                _sqlVendedor.Append("v_mensagem, v_rota, v_supervisor, v_senha, v_foto ") '16
                _sqlVendedor.Append("FROM cadvendedor WHERE ") '4
                _sqlVendedor.Append("UPPER(" & nomeCampo & ") LIKE '" & pesquisa & "%' ORDER BY v_nome ASC")
                _cmdVendedor = New NpgsqlCommand(_sqlVendedor.ToString, _oConnBDMETROSYS)
                _drVendedor = _cmdVendedor.ExecuteReader

                dtg_vendedores.Rows.Clear()
                While _drVendedor.Read
                    id = _drVendedor(0)
                    codigo = _drVendedor(1)
                    nome = _drVendedor(2).ToString
                    endereco = _drVendedor(3).ToString
                    uf = _drVendedor(4)
                    cidade = _drVendedor(5)
                    fone = _drVendedor(7)
                    celular = _drVendedor(8)

                    dtg_vendedores.Rows.Add(id, codigo, nome, endereco, uf, cidade, fone, celular)

                End While

                _drVendedor.Close()
            Catch ex As Exception
                lbl_mensagem01.Text = "ERRO:: " & ex.Message & "!"

            End Try

            _cmdVendedor.CommandText = ""
            _sqlVendedor.Remove(0, _sqlVendedor.ToString.Length)
            _oConnBDMETROSYS.ClearPool()

            'LIMPA OBJETOS DA MEMORIA...
            nome = Nothing : codigo = Nothing : endereco = Nothing : uf = Nothing : cidade = Nothing
            fone = Nothing : celular = Nothing : supervisor = Nothing : id = Nothing
        End If



    End Sub

    Private Sub Frm_ManVendedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cbo_uf.Items.Add("AC") : Me.cbo_uf.Items.Add("AL") : Me.cbo_uf.Items.Add("AP")
        Me.cbo_uf.Items.Add("AM") : Me.cbo_uf.Items.Add("BA") : Me.cbo_uf.Items.Add("CE")
        Me.cbo_uf.Items.Add("DF") : Me.cbo_uf.Items.Add("ES") : Me.cbo_uf.Items.Add("EX")
        Me.cbo_uf.Items.Add("GO") : Me.cbo_uf.Items.Add("MA") : Me.cbo_uf.Items.Add("MT")
        Me.cbo_uf.Items.Add("MS") : Me.cbo_uf.Items.Add("MG") : Me.cbo_uf.Items.Add("PA")
        Me.cbo_uf.Items.Add("PB") : Me.cbo_uf.Items.Add("PE") : Me.cbo_uf.Items.Add("PI")
        Me.cbo_uf.Items.Add("RJ") : Me.cbo_uf.Items.Add("RN") : Me.cbo_uf.Items.Add("RS")
        Me.cbo_uf.Items.Add("RD") : Me.cbo_uf.Items.Add("RR") : Me.cbo_uf.Items.Add("SC")
        Me.cbo_uf.Items.Add("SP") : Me.cbo_uf.Items.Add("SE") : Me.cbo_uf.Items.Add("TO")
        Me.cbo_uf.Sorted = True

        limpaCamposVendedor()
        preencheDgrd_Vendedor("%")


    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _alterando = True : _incluindo = False : tbc_vendedores.SelectTab(1) : limpaCamposVendedor()
                _clVendedor.zeraValores()
                _idVendedor = dtg_vendedores.CurrentRow.Cells(0).Value : trazVendedorSelecionado()
                txt_nome.Focus() : tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True

            End If
        Else
            _alterando = True : _incluindo = False : tbc_vendedores.SelectTab(1) : limpaCamposVendedor()
            _clVendedor.zeraValores()
            _idVendedor = dtg_vendedores.CurrentRow.Cells(0).Value : trazVendedorSelecionado()
            txt_nome.Focus() : tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True

        End If



    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", MessageBoxButtons.YesNo, _
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                tbc_vendedores.SelectTab(0) : limpaCamposVendedor() : tbp_manutencao.Text = "Vendedor"
                _clVendedor.zeraValores()
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False
                Me.dtg_vendedores.Rows.Clear() : Me.dtg_vendedores.Refresh() : preencheDgrd_Vendedor("%")

            End If
        End If



    End Sub

    Private Sub trazVendedorSelecionado()

        Try
            If _oConnBDMETROSYS.State = ConnectionState.Closed Then _oConnBDMETROSYS.Open()
        Catch ex As Exception
            lbl_mensagem01.Text = "ERRO:: " & ex.Message & "!" : Return

        End Try

        If _oConnBDMETROSYS.State = ConnectionState.Open Then
            Dim grupo As Integer = _valorZERO, pcomp As Double = _valorZERO, me_qtdfisc As Double = _valorZERO

            Try
                _sqlVendedor.Append("SELECT v_id, v_codigo, v_nome, v_endereco, v_uf, v_cidade, v_bairro, ") '6
                _sqlVendedor.Append("v_fone, v_celular, v_comissionado, v_tipocomissao, v_alqcomiss, ") '11
                _sqlVendedor.Append("v_mensagem, v_rota, v_supervisor, v_senha, v_foto, v_local, v_descmax, v_tipo, ") '19
                _sqlVendedor.Append("v_dispositivo FROM cadvendedor WHERE v_id = @v_id")

                _cmdVendedor = New NpgsqlCommand(_sqlVendedor.ToString, _oConnBDMETROSYS)
                _cmdVendedor.Parameters.Add("@v_id", _idVendedor)
                _drVendedor = _cmdVendedor.ExecuteReader

                While _drVendedor.Read

                    Me.txt_codVendedor.Text = _drVendedor(1).ToString
                    Me.txt_nome.Text = _drVendedor(2).ToString
                    Me.txt_endereco.Text = _drVendedor(3).ToString

                    'Trata a UF e preenche o cbo_cidade...
                    Try
                        Me.cbo_uf.SelectedIndex = _clFuncoes.trazIndexUF(_drVendedor(4).ToString, Me.cbo_uf)

                        If _ufCorrenteCbo.Equals("") Then

                            If cbo_uf.SelectedIndex >= _valorZERO Then

                                Me.cbo_cidade = _clFuncoes.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
                                _ufCorrenteCbo = Me.cbo_uf.Text
                            End If

                        ElseIf cbo_uf.SelectedIndex > _valorZERO And Not _ufCorrenteCbo.Equals(cbo_uf.Text) Then

                            Me.cbo_cidade = _clFuncoes.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
                            _ufCorrenteCbo = Me.cbo_uf.Text

                        End If

                    Catch ex As Exception
                        Me.cbo_uf.SelectedIndex = -1

                    End Try


                    'Trata o município...
                    Try
                        Me.cbo_cidade.SelectedIndex = _clFuncoes.trazIndexMUN(_drVendedor(5).ToString, Me.cbo_cidade)
                    Catch ex As Exception
                        Me.cbo_cidade.SelectedIndex = -1

                    End Try

                    Me.txt_bairro.Text = _drVendedor(6).ToString
                    Me.msk_fone.Text = _drVendedor(7).ToString
                    Me.msk_celular.Text = _drVendedor(8).ToString

                    'Tratamento da Comisão do Vendedor...
                    Select Case _drVendedor(10).ToString
                        Case "N"
                            rdb_nenhum.Checked = True

                        Case "P"
                            rdb_produto.Checked = True

                        Case "L"
                            rdb_liquidez.Checked = True

                        Case "T"
                            rdb_total.Checked = True

                    End Select
                    Me.chk_comissionado.Checked = _drVendedor(9)

                    Me.txt_alqcomis.Text = _drVendedor(11)
                    Me.txt_mensag1.Text = _drVendedor(12)
                    Me.txt_rota.Text = _drVendedor(13)
                    Me.msk_senha.Text = _drVendedor(15)
                    Me.cbo_tipo.SelectedIndex = _clFuncoes.trazIndexCboTipoVendedor(_drVendedor(19), cbo_tipo)
                    Me.cbo_dispositivo.SelectedIndex = _clFuncoes.trazIndexCboDispositivoVendedor(_drVendedor(20), cbo_dispositivo)
                    _local = _drVendedor(17).ToString
                    Me.txt_descMax.Text = Format(_drVendedor(18), "##,#0.00")


                End While

            Catch ex As Exception
                lbl_mensagem01.Text = "ERRO:: " & ex.Message & "!"

            End Try


            grupo = Nothing : pcomp = Nothing : me_qtdfisc = Nothing : _cmdVendedor.CommandText = ""
            _sqlVendedor.Remove(0, _sqlVendedor.ToString.Length) : _oConnBDMETROSYS.ClearPool()
            _oConnBDMETROSYS.Close()
        End If



    End Sub

    Private Sub cbo_uf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_uf.GotFocus

        If Not Me.cbo_uf.DroppedDown Then Me.cbo_uf.DroppedDown = True

    End Sub

    Private Sub cbo_cidade_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_cidade.GotFocus

        If Not Me.cbo_cidade.DroppedDown Then Me.cbo_cidade.DroppedDown = True

    End Sub

    Private Sub cbo_supervisor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_supervisor.GotFocus

        If Not Me.cbo_supervisor.DroppedDown Then Me.cbo_supervisor.DroppedDown = True

    End Sub

    Private Function verificaVendedor() As Boolean

        If Me.txt_codVendedor.Text.Equals("") Then

            lbl_mensagem02.Text = "Favor informe o LOCAL para o Vendedor !"
            txt_codVendedor.Focus() : txt_codVendedor.SelectAll() : Return False
        End If

        If txt_nome.Text.Equals("") Then

            lbl_mensagem02.Text = "Favor informe o NOME do Vendedor !"
            txt_nome.Focus() : txt_nome.SelectAll() : Return False
        End If

        If txt_endereco.Text.Equals("") Then

            lbl_mensagem02.Text = "Favor informe o ENDERECO do Vendedor !"
            txt_endereco.Focus() : txt_endereco.SelectAll() : Return False
        End If

        If cbo_uf.SelectedIndex < _valorZERO Then

            lbl_mensagem02.Text = "Favor informe o ESTADO do Vendedor !"
            cbo_uf.Focus() : cbo_uf.SelectAll() : Return False
        End If

        If cbo_cidade.SelectedIndex < _valorZERO Then

            lbl_mensagem02.Text = "Favor informe a CIDADE do Vendedor !"
            cbo_cidade.Focus() : cbo_cidade.SelectAll() : Return False
        End If

        If txt_bairro.Text.Equals("") Then

            lbl_mensagem02.Text = "Favor informe o BAIRRO do Vendedor !"
            txt_bairro.Focus() : txt_bairro.SelectAll() : Return False
        End If

        'Ainda não tá feito a tabela...
        'If cbo_supervisor.SelectedIndex < _valorZERO Then
        '    False = False
        '    lbl_mensagem02.Text = "Favor informe o SUPERVISOR do Vendedor !"
        '    cbo_supervisor.Focus()
        '    cbo_supervisor.SelectAll()
        '    Return False
        'End If


        If IsNumeric(txt_alqcomis.Text) = False Then

            lbl_mensagem02.Text = "O Campo de Aliq. Comissão deve ser NUMERICO !"
            txt_alqcomis.Focus() : txt_alqcomis.SelectAll() : Return False

        Else

            If (chk_comissionado.Checked = True) AndAlso (CDbl(txt_alqcomis.Text) <= 0) Then

                lbl_mensagem02.Text = "Para um Vendedor Comissionado a ""Aliq. Comissão"" deve ser MAIOR que ZERO !"
                txt_alqcomis.Focus() : txt_alqcomis.SelectAll() : Return False

            End If
        End If

        If cbo_tipo.SelectedIndex < _valorZERO Then

            lbl_mensagem02.Text = "Favor informe o TIPO do Vendedor !"
            cbo_tipo.Focus() : Return False
        End If



        Return True
    End Function

    Private Sub inclueVendedor(ByVal codigo As String, ByVal nome As String, ByVal endereco As String, _
                          ByVal uf As String, ByVal cidade As String, ByVal bairro As String, _
                          ByVal fone As String, ByVal celular As String, ByVal comissionado As Boolean, _
                          ByVal tipocomissao As String, ByVal alqcomiss As Double, ByVal descMax As Double, _
                          ByVal mensagem As String, ByVal rota As Integer, ByVal supervisor As String, _
                          ByVal senha As String, ByVal foto As Object, ByVal local As String, _
                          ByVal tipo As Integer)

        local = MdlUsuarioLogando._local
        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        If supervisor = Nothing Then supervisor = ""

        _clVendedor.pCodigo = codigo
        _clVendedor.pNome = nome
        _clVendedor.pEndereco = endereco
        _clVendedor.pUf = uf
        _clVendedor.pCidade = cidade
        _clVendedor.pBairro = bairro
        _clVendedor.pFone = fone
        _clVendedor.pCelular = celular
        _clVendedor.pComissionado = comissionado
        _clVendedor.pTipocomissao = tipocomissao
        _clVendedor.pAlqcomiss = alqcomiss
        _clVendedor.pDescMAx = descMax
        _clVendedor.pRota = rota
        _clVendedor.pSupervisor = supervisor
        _clVendedor.pSenha = senha
        _clVendedor.pFoto = foto
        _clVendedor.pLocal = local
        _clVendedor.pTipo = tipo

        Try
            _clVendedor.dispositivo = Mid(cbo_dispositivo.SelectedItem.ToString, 1, 1)
        Catch ex As Exception
        End Try

        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            transacao = conection.BeginTransaction
            _clBD.incVendedor(_clVendedor, conection, transacao)
            transacao.Commit() : conection.ClearPool()


            If MessageBox.Show("Vendedor salvo com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                limpaCamposVendedor() : conection.Close() : Me.txt_nome.Focus()

            Else
                limpaCamposVendedor() : _incluindo = False : _alterando = False
                conection.ClearPool() : conection.Close() : Me.dtg_vendedores.Rows.Clear()
                Me.dtg_vendedores.Refresh() : Me.txt_pesquisa.Text = ""
                preencheDgrd_Vendedor("%") : Me.txt_pesquisa.Focus() : tbc_vendedores.SelectTab(0)

            End If

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try

        Finally
            transacao = Nothing : conection = Nothing
        End Try



    End Sub

    Private Sub alteraVendedor(ByVal codigo As String, ByVal nome As String, ByVal endereco As String, _
                          ByVal uf As String, ByVal cidade As String, ByVal bairro As String, _
                          ByVal fone As String, ByVal celular As String, ByVal comissionado As Boolean, _
                          ByVal tipocomissao As String, ByVal alqcomiss As Double, ByVal descMax As Double, _
                          ByVal mensagem As String, ByVal rota As Integer, ByVal supervisor As String, _
                          ByVal senha As String, ByVal foto As Object, ByVal local As String, _
                          ByVal tipo As Integer)

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        If supervisor = Nothing Then supervisor = ""

        _clVendedor.pCodigo = codigo
        _clVendedor.pNome = nome
        _clVendedor.pEndereco = endereco
        _clVendedor.pUf = uf
        _clVendedor.pCidade = cidade
        _clVendedor.pBairro = bairro
        _clVendedor.pFone = fone
        _clVendedor.pCelular = celular
        _clVendedor.pComissionado = comissionado
        _clVendedor.pTipocomissao = tipocomissao
        _clVendedor.pAlqcomiss = alqcomiss
        _clVendedor.pDescMAx = descMax
        _clVendedor.pRota = rota
        _clVendedor.pSupervisor = supervisor
        _clVendedor.pSenha = senha
        _clVendedor.pFoto = foto
        _clVendedor.pLocal = local
        _clVendedor.pTipo = tipo

        Try
            _clVendedor.dispositivo = Mid(cbo_dispositivo.SelectedItem.ToString, 1, 1)
        Catch ex As Exception
        End Try

        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            transacao = conection.BeginTransaction
            _clBD.altVendedor(_clVendedor, conection, transacao, _idVendedor)
            transacao.Commit() : conection.ClearPool()

            MsgBox("Vendedor salvo com sucesso", MsgBoxStyle.Exclamation)
            limpaCamposVendedor() : _incluindo = False : _alterando = False : conection.Close()
            tbc_vendedores.SelectTab(0) : Me.dtg_vendedores.Rows.Clear() : Me.dtg_vendedores.Refresh()
            Me.txt_pesquisa.Text = "" : preencheDgrd_Vendedor("%") : Me.txt_pesquisa.Focus()

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try

        Finally
            transacao = Nothing : conection = Nothing
        End Try



    End Sub

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        If Me.txt_codVendedor.Text.Equals("") Then

            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try

                Try
                    conection.Open()
                Catch ex As Exception
                    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                    Return

                End Try

                Me.txt_codVendedor.Text = "V" & String.Format("{0:D5}", _clBD.trazProxCodVendedor(conection))
                _clBD.updateCadregCodVendedor(conection, Convert.ToInt32(Mid(Me.txt_codVendedor.Text, 2, 5)))
                conection.ClearPool() : conection.Close()

            Catch ex As Exception
            End Try


            conection = Nothing
        End If


        _tipoComissao = ""
        If rdb_nenhum.Checked Then _tipoComissao = "N"
        If rdb_produto.Checked Then _tipoComissao = "P"
        If rdb_total.Checked Then _tipoComissao = "T"
        If rdb_liquidez.Checked Then _tipoComissao = "L"


        Dim mensagems As String = Trim(txt_mensag1.Text & " " & txt_mensag2.Text & " " & txt_mensag3.Text)
        Dim tipo As Integer = 1
        If cbo_tipo.SelectedIndex >= _valorZERO Then tipo = CInt(Mid(cbo_tipo.SelectedItem, 1, 1))
        If verificaVendedor() Then

            If _incluindo = True Then

                inclueVendedor(Me.txt_codVendedor.Text, Me.txt_nome.Text, Me.txt_endereco.Text, _
                               cbo_uf.SelectedItem, cbo_cidade.SelectedItem, Me.txt_bairro.Text, _
                      msk_fone.Text, msk_celular.Text, chk_comissionado.Checked, _tipoComissao, _
                      txt_alqcomis.Text, txt_descMax.Text, mensagems, txt_rota.Text, cbo_supervisor.SelectedItem, _
                      msk_senha.Text, txt_localfoto.Text, MdlUsuarioLogando._local, tipo)

                _clVendedor.zeraValores()
            ElseIf _alterando = True Then

                alteraVendedor(Me.txt_codVendedor.Text, Me.txt_nome.Text, Me.txt_endereco.Text, _
                               cbo_uf.SelectedItem, cbo_cidade.SelectedItem, Me.txt_bairro.Text, _
                               msk_fone.Text, msk_celular.Text, chk_comissionado.Checked, _tipoComissao, _
                               txt_alqcomis.Text, txt_descMax.Text, mensagems, txt_rota.Text, cbo_supervisor.SelectedItem, _
                               msk_senha.Text, txt_localfoto.Text, _local, tipo)

                _clVendedor.zeraValores()
            End If
        End If



    End Sub

    Private Sub cbo_uf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_uf.Leave

        If _ufCorrenteCbo.Equals("") Then

            If cbo_uf.SelectedIndex >= _valorZERO Then

                Me.cbo_cidade = _clFuncoes.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
                _ufCorrenteCbo = Me.cbo_uf.Text

            End If
        ElseIf cbo_uf.SelectedIndex > _valorZERO And Not _ufCorrenteCbo.Equals(cbo_uf.Text) Then

            Me.cbo_cidade = _clFuncoes.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
            _ufCorrenteCbo = Me.cbo_uf.Text

        End If



    End Sub

    Private Sub chk_comissionado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_comissionado.CheckedChanged

        If chk_comissionado.Checked Then

            rdb_nenhum.Checked = False : rdb_nenhum.Enabled = False
            rdb_produto.Checked = False : rdb_produto.Enabled = True
            rdb_liquidez.Checked = False : rdb_liquidez.Enabled = True
            rdb_total.Checked = True : rdb_total.Enabled = True
            txt_alqcomis.ReadOnly = False : txt_alqcomis.Text = "0,00"

        Else

            rdb_nenhum.Checked = True : rdb_nenhum.Enabled = True
            rdb_produto.Checked = False : rdb_produto.Enabled = False
            rdb_liquidez.Checked = False : rdb_liquidez.Enabled = False
            rdb_total.Checked = False : rdb_total.Enabled = False
            txt_alqcomis.ReadOnly = True : txt_alqcomis.Text = "0,00"

        End If


    End Sub

    Private Sub txt_alqcomis_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_alqcomis.KeyPress, txt_descMax.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_rota_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rota.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_alqcomis_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_alqcomis.Leave

        If IsNumeric(txt_alqcomis.Text) Then
            Me.txt_alqcomis.Text = Format(CDec(Me.txt_alqcomis.Text), "###,##0.00")
        Else
            Me.txt_alqcomis.Text = Format(0, "###,##0.00")

        End If


    End Sub

    Private Sub txt_descMax_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descMax.Leave

        If IsNumeric(txt_descMax.Text) Then
            Me.txt_descMax.Text = Format(CDec(Me.txt_descMax.Text), "###,##0.00")
        Else
            Me.txt_descMax.Text = Format(0, "###,##0.00")

        End If


    End Sub

    Private Sub cbo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo.GotFocus
        If Not Me.cbo_tipo.DroppedDown Then Me.cbo_tipo.DroppedDown = True
    End Sub

End Class