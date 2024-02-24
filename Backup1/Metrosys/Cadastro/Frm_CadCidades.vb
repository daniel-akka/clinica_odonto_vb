Imports System
Imports System.Text
Imports Npgsql

Public Class Frm_CadCidades

    Private _valorZERO As Integer = 0
    Private _alterando As Boolean = False, _incluindo As Boolean = False
    Private _idMunicipio As Int32 = _valorZERO
    Private _descricaoAnterior As String = "", _codCidadeAnterior As String = ""
    Private _codEstado As String = "", _uf As String = "", _idEstado As Integer = _valorZERO
    Dim _clFuncoes As New ClFuncoes
    Dim _clBD As New Cl_bdMetrosys
    Dim _clCidades As New Cl_Municipio


    Private Sub Frm_CadCidades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        preencheDtg_Municipios()

    End Sub

    Private Sub Frm_CadCidades_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub Frm_CadCidades_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                preencheDtg_Municipios()

        End Select


    End Sub

    Private Sub limpaCamposMun()

        cbo_uf.SelectedIndex = -1 : txt_descricao.Text = ""
        txt_codMunicipio.Text = "" : txt_codUF.Text = ""
        lbl_mesagem2.Text = ""

    End Sub

    Private Sub preencheDtg_Municipios()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdMunicipios As New NpgsqlCommand
        Dim sqlMunicipios As New StringBuilder
        Dim drMunicipios As NpgsqlDataReader

        Dim uf As String = "", descricao As String = "", codMun As String = ""
        Dim id As Int32 = _valorZERO

        Try

            sqlMunicipios.Append("SELECT id, sigla_estado, nome, codigo FROM cadmun ") '3
            sqlMunicipios.Append("WHERE nome LIKE @nome ORDER BY nome ASC")
            cmdMunicipios = New NpgsqlCommand(sqlMunicipios.ToString, oConnBDMETROSYS)
            cmdMunicipios.Parameters.Add("@nome", Me.txt_pesquisa.Text & "%")
            drMunicipios = cmdMunicipios.ExecuteReader

            Dtg_Municipios.Rows.Clear()
            If drMunicipios.HasRows = False Then Return
            While drMunicipios.Read
                id = drMunicipios(0)
                uf = drMunicipios(1).ToString
                descricao = drMunicipios(2).ToString
                codMun = drMunicipios(3).ToString

                Dtg_Municipios.Rows.Add(id, uf, descricao, codMun)

            End While

            Dtg_Municipios.Refresh() : drMunicipios.Close()
            oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT das CIDADES:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmdMunicipios.CommandText = ""
        sqlMunicipios.Remove(0, sqlMunicipios.ToString.Length)

        'Limpa Objetos de Memoria...
        descricao = Nothing : id = Nothing : oConnBDMETROSYS = Nothing : cmdMunicipios = Nothing
        sqlMunicipios = Nothing : drMunicipios = Nothing



    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        preencheDtg_Municipios()

    End Sub

    Private Sub cbo_uf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_uf.GotFocus

        If cbo_uf.DroppedDown = False Then cbo_uf.DroppedDown = True
    End Sub

    Private Sub cbo_uf_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_uf.SelectedIndexChanged

        If cbo_uf.SelectedIndex >= _valorZERO Then

            Try
                Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                connection.Open()
                txt_codUF.Text = _clBD.trazCodEstado(connection, cbo_uf.SelectedItem)
                _idEstado = _clBD.trazIdEstado(connection, cbo_uf.SelectedItem)
                connection.ClearPool() : connection.Close() : connection = Nothing
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            End Try

        End If



    End Sub

    Private Function verificaCampos() As Boolean

        lbl_mesagem2.Text = ""
        If cbo_uf.SelectedIndex < _valorZERO Then

            lbl_mesagem2.Text = "Por Favor Informar uma UF !"
            Return False
        End If

        If Trim(txt_descricao.Text).Equals("") Then

            lbl_mesagem2.Text = "Por Favor Informar o nome da CIDADE !"
            Return False
        End If

        If Trim(txt_descricao.Text).Equals("") Then

            lbl_mesagem2.Text = "Por Favor Informar o nome da CIDADE !"
            Return False
        End If

        If Trim(txt_codMunicipio.Text).Equals("") Then

            lbl_mesagem2.Text = "Por Favor Informar o CÓDIGO DO MUNICÍPIO !"
            Return False
        End If

        If txt_codMunicipio.Text.Length < 5 Then

            lbl_mesagem2.Text = "CÓDIGO DO MUNICÍPIO dever ter 5 Digitos !"
            Return False
        End If

        If IsNumeric(txt_codMunicipio.Text) = False Then

            lbl_mesagem2.Text = "CÓDIGO DO MUNICÍPIO dever ter SÓ NUMEROS !"
            Return False
        End If



        Return True
    End Function

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        If verificaCampos() Then

            Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If _incluindo Then


                If _clBD.existeNomeCidade(connection, cbo_uf.SelectedItem, txt_descricao.Text) Then

                    lbl_mesagem2.Text = "O NOME desta cidade já existe nessa UF !"
                    Return
                End If

                If _clBD.existeCodigoCidade(connection, (txt_codUF.Text & txt_codMunicipio.Text)) Then

                    lbl_mesagem2.Text = "O CÓDIGO desta cidade já existe nessa UF !"
                    Return
                End If

                inclueMunicipio(_idEstado, Me.txt_codUF.Text, cbo_uf.SelectedItem, Me.txt_descricao.Text, _
                              (txt_codUF.Text & txt_codMunicipio.Text))

            ElseIf _alterando Then


                If _clBD.existeNomeCidadeAlt(connection, cbo_uf.SelectedItem, _
                                             txt_descricao.Text, _descricaoAnterior) Then

                    lbl_mesagem2.Text = "O NOME desta cidade já existe nessa UF !"
                    Return
                End If

                If _clBD.existeCodigoCidadeAlt(connection, (txt_codUF.Text & txt_codMunicipio.Text), _
                                               _codCidadeAnterior) Then

                    lbl_mesagem2.Text = "O CÓDIGO desta cidade já existe nessa UF !"
                    Return
                End If

                alteraMunicipio(_idMunicipio, _idEstado, Me.txt_codUF.Text, cbo_uf.SelectedItem, _
                              Me.txt_descricao.Text, (txt_codUF.Text & txt_codMunicipio.Text))

            End If

            connection.ClearPool() : connection.Close() : connection = Nothing

        End If



    End Sub

    Private Sub inclueMunicipio(ByVal idUF As Integer, ByVal codUF As Integer, ByVal UF As String, _
                              ByVal nomeCidade As String, ByVal codCidade As Integer)

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            _clCidades.pIdEstado = idUF
            _clCidades.pCodEstado = codUF
            _clCidades.pSiglaEstado = UF
            _clCidades.pNomeMun = nomeCidade
            _clCidades.pCodMun = codCidade

            transacao = conection.BeginTransaction

            _clBD.incMunicipio(_clCidades, conection, transacao)

            transacao.Commit()

            If MessageBox.Show("CIDADE salva com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                limpaCamposMun() : conection.ClearPool() : conection.Close() : Me.cbo_uf.Focus()

            Else

                limpaCamposMun() : _incluindo = False : _alterando = False : conection.ClearPool() : conection.Close()
                tbc_municipios.SelectTab(0) : Me.Dtg_Municipios.Rows.Clear() : Me.Dtg_Municipios.Refresh()
                preencheDtg_Municipios()

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

    Private Sub alteraMunicipio(ByVal idMunicipio As Int32, ByVal idUF As Integer, ByVal codUF As Integer, _
                              ByVal UF As String, ByVal nomeCidade As String, ByVal codCidade As Integer)

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            _clCidades.pIdEstado = idUF
            _clCidades.pCodEstado = codUF
            _clCidades.pSiglaEstado = UF
            _clCidades.pNomeMun = nomeCidade
            _clCidades.pCodMun = codCidade

            transacao = conection.BeginTransaction

            _clBD.altMunicipio(idMunicipio, _clCidades, conection, transacao)

            transacao.Commit()

            MsgBox("CIDADE salva com sucesso!", MsgBoxStyle.Exclamation)
            limpaCamposMun() : _incluindo = False : _alterando = False : conection.ClearPool() : conection.Close()
            tbc_municipios.SelectTab(0) : Me.Dtg_Municipios.Rows.Clear() : Me.Dtg_Municipios.Refresh()
            preencheDtg_Municipios() : _idMunicipio = _valorZERO


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

    Private Sub txt_codMunicipio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codMunicipio.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _clCidades.zeraValores()
                tbc_municipios.SelectTab(0) : limpaCamposMun() : tbp_manutencao.Text = "Municípios"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False
                Me.Dtg_Municipios.Rows.Clear() : Me.Dtg_Municipios.Refresh() : preencheDtg_Municipios()
                _idMunicipio = _valorZERO

            End If
        End If


    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click


        If _incluindo = True OrElse _alterando = True Then

            If MessageBox.Show("Operação em aberto! Ela será Subistituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _clCidades.zeraValores()
                _incluindo = True : _alterando = False : tbc_municipios.SelectTab(1) : limpaCamposMun()
                tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True : _idMunicipio = _valorZERO

            End If

        Else
            _clCidades.zeraValores()
            _incluindo = True : _alterando = False : tbc_municipios.SelectTab(1) : limpaCamposMun()
            tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True
            _idMunicipio = _valorZERO

        End If



    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...


            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _clCidades.zeraValores()
                _alterando = True : _incluindo = False : tbc_municipios.SelectTab(1) : limpaCamposMun()
                _idMunicipio = Dtg_Municipios.CurrentRow.Cells(0).Value : trazCidadeSelecionada()
                tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True

            End If

        Else
            _clCidades.zeraValores()
            _alterando = True : _incluindo = False : tbc_municipios.SelectTab(1) : limpaCamposMun()
            _idMunicipio = Dtg_Municipios.CurrentRow.Cells(0).Value : trazCidadeSelecionada()
            tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True

        End If



    End Sub

    Private Sub trazCidadeSelecionada()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdMunicipios As New NpgsqlCommand
        Dim sqlMunicipios As New StringBuilder
        Dim drMunicipios As NpgsqlDataReader

        Try
            sqlMunicipios.Append("SELECT id, id_estado, sigla_estado, cod_estado, codigo, nome FROM cadmun WHERE id = @id")
            cmdMunicipios = New NpgsqlCommand(sqlMunicipios.ToString, oConnBDMETROSYS)
            cmdMunicipios.Parameters.Add("@id", _idMunicipio)

            drMunicipios = cmdMunicipios.ExecuteReader

            While drMunicipios.Read

                _idMunicipio = drMunicipios(0)
                _idEstado = drMunicipios(1)
                _uf = drMunicipios(2).ToString
                _codEstado = drMunicipios(3).ToString
                _codCidadeAnterior = drMunicipios(4).ToString
                _descricaoAnterior = drMunicipios(5).ToString

                cbo_uf.SelectedIndex = _clFuncoes.trazIndexUF(_uf, cbo_uf)
                Me.txt_descricao.Text = _descricaoAnterior
                Me.txt_codUF.Text = _codEstado
                Me.txt_codMunicipio.Text = Mid(_codCidadeAnterior, 3, 5)


            End While

            drMunicipios.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT das CIDADES:: ", MsgBoxStyle.Exclamation)
            Return

        End Try

        cmdMunicipios.CommandText = "" : sqlMunicipios.Remove(0, sqlMunicipios.ToString.Length)
        oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close() : oConnBDMETROSYS = Nothing
        cmdMunicipios = Nothing : drMunicipios = Nothing


    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click

        If Me.Dtg_Municipios.CurrentRow.IsNewRow = False Then

            _idMunicipio = CInt(Me.Dtg_Municipios.CurrentRow.Cells(0).Value)
            If MessageBox.Show("Deseja realmente Deletar esta CIDADE?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then


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

                    _clBD.delMunicipio(conection, transacao, _idMunicipio)

                    transacao.Commit() : conection.ClearPool() : conection.Close()

                    MsgBox("CIDADE Deletada com Sucesso!", MsgBoxStyle.Exclamation)
                Catch ex As Exception
                    MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                    Try
                        transacao.Rollback()

                    Catch ex1 As Exception
                    End Try

                Finally
                    transacao = Nothing : conection = Nothing
                End Try



                limpaCamposMun() : tbp_manutencao.Text = "Cidades"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False
                Me.Dtg_Municipios.Rows.Clear() : Me.Dtg_Municipios.Refresh() : preencheDtg_Municipios()
                _idMunicipio = _valorZERO

            End If
        End If



    End Sub
End Class