Imports Npgsql
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Math

Public Class Frm_CadServico

    Dim _clFuncoes As New ClFuncoes
    Private _incluindo As Boolean = True
    Dim _operacao As Boolean = False
    Private _idServico As Int32 = 0
    Private _descricaoAnterior As String = ""
    Private _codEstado As String = "", _idEstado As Integer = 0
    Dim _clBD As New Cl_bdMetrosys
    Dim _clServico As New Cl_Servico

    Private Sub txt_valor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_valor.KeyPress
        'permite só numeros com vírgula
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_valor_Leave(sender As Object, e As EventArgs) Handles txt_valor.Leave

        lbl_mensagem.Text = ""
        If Me.txt_valor.Text.Equals("") Then Me.txt_valor.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valor.Text) Then
            If CDec(Me.txt_valor.Text) <= 0 Then
                lbl_mensagem.Text = "Valor deve ser maior que ZERO !"
                Return

            End If
            Me.txt_valor.Text = Format(CDec(Me.txt_valor.Text), "###,##0.00")

        End If

    End Sub

    Private Sub Frm_CadServico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        preencheDtg_Servicos()

    End Sub

    Private Sub Frm_CadServico_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Frm_CadServico_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                preencheDtg_Servicos()

        End Select


    End Sub

    Private Sub limpaCamposServiço()

        txt_descricao.Text = ""
        txt_valor.Text = "0,00"
        lbl_mensagem.Text = ""

    End Sub

    Private Sub preencheDtg_Servicos()

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdMunicipios As New NpgsqlCommand
        Dim sqlMunicipios As New StringBuilder
        Dim drMunicipios As NpgsqlDataReader


        Try

            sqlMunicipios.Append("SELECT s_id, s_descricao, s_valor FROM servico ") '3
            sqlMunicipios.Append("WHERE s_descricao LIKE @s_descricao ORDER BY s_descricao ASC")
            cmdMunicipios = New NpgsqlCommand(sqlMunicipios.ToString, oConn)
            cmdMunicipios.Parameters.Add("@s_descricao", Me.txt_pesquisa.Text & "%")
            drMunicipios = cmdMunicipios.ExecuteReader

            dtg_servicos.Rows.Clear()
            If drMunicipios.HasRows = False Then Return
            While drMunicipios.Read
                dtg_servicos.Rows.Add(drMunicipios(0), drMunicipios(1).ToString, Format(drMunicipios(2), "###,##0.00"))
            End While

            dtg_servicos.Refresh() : drMunicipios.Close()
            oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT dos SERVICOS:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmdMunicipios.CommandText = ""
        sqlMunicipios.Remove(0, sqlMunicipios.ToString.Length)

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmdMunicipios = Nothing
        sqlMunicipios = Nothing : drMunicipios = Nothing



    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        preencheDtg_Servicos()

    End Sub

    Private Function verificaCampos() As Boolean


        Try

            lbl_mensagem.Text = ""

            If Trim(txt_descricao.Text).Equals("") Then

                lbl_mensagem.Text = "Por Favor Informar o nome do SERVIÇO !"
                txt_descricao.Focus() : txt_descricao.SelectAll()
                Return False
            End If

            If IsNumeric(txt_valor.Text) = False Then
                lbl_mensagem.Text = "Valor DEVE ser NUMÉRICO !"
                txt_valor.Focus() : txt_valor.SelectAll()
                Return False
            End If

            If CDbl(txt_valor.Text) <= 0 Then
                lbl_mensagem.Text = "Valor DEVE ser Maior que ZERO !"
                txt_valor.Focus() : txt_valor.SelectAll()
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try


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


                If _clBD.existeNomeServico(connection, txt_descricao.Text) Then

                    lbl_mensagem.Text = "O NOME deste Serviço já existe !"
                    txt_descricao.Focus() : txt_descricao.SelectAll()
                    Return
                End If

                inclueMunicipio(_clServico.pIdServico, Me.txt_descricao.Text, Me.txt_valor.Text)

            Else

                If _clBD.existeNomeServicoAlt(connection, txt_descricao.Text, _descricaoAnterior) Then

                    lbl_mensagem.Text = "O NOME deste Serviço já existe !"
                    txt_descricao.Focus() : txt_descricao.SelectAll()
                    Return
                End If

                alteraMunicipio(_clServico.pIdServico, Me.txt_descricao.Text, Me.txt_valor.Text)

            End If

            connection.Close() : connection = Nothing

        End If



    End Sub

    Private Sub inclueMunicipio(ByVal idServico As Int64, ByVal nomeServico As String, ByVal valor As Double)

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            _clServico.pIdServico = idServico
            _clServico.pDescricao = nomeServico
            _clServico.pValor = valor

            transacao = conection.BeginTransaction

            _clBD.incServico(_clServico, conection, transacao)

            transacao.Commit()

            If MessageBox.Show("SERVIÇO salvo com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                limpaCamposServiço() : conection.Close() : txt_descricao.Focus()

            Else

                limpaCamposServiço() : _incluindo = False : conection.Close()
                tbc_municipios.SelectTab(0) : Me.dtg_servicos.Rows.Clear() : Me.dtg_servicos.Refresh()
                preencheDtg_Servicos()

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

    Private Sub alteraMunicipio(ByVal idServico As Int64, ByVal nomeServico As String, ByVal valor As Double)

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            _clServico.pIdServico = idServico
            _clServico.pDescricao = nomeServico
            _clServico.pValor = valor

            transacao = conection.BeginTransaction

            _clBD.altServico(_clServico, conection, transacao)

            transacao.Commit()

            MsgBox("SERVIÇO salvo com sucesso!", MsgBoxStyle.Exclamation)
            limpaCamposServiço() : _incluindo = False : conection.Close()
            tbc_municipios.SelectTab(0) : Me.dtg_servicos.Rows.Clear() : Me.dtg_servicos.Refresh()
            preencheDtg_Servicos()


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

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click


        If tbp_manutencao.Text.Equals("Serviço") Then

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _clServico.zeraValores()
                tbc_municipios.SelectTab(0) : limpaCamposServiço() : tbp_manutencao.Text = "Serviço"
                _incluindo = True : btn_salvar.Enabled = False
                Me.dtg_servicos.Rows.Clear() : Me.dtg_servicos.Refresh() : preencheDtg_Servicos()

            End If
        End If


    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click


        If _operacao Then

            If MessageBox.Show("Operação em aberto! Ela será Subistituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _clServico.zeraValores()
                _incluindo = True : tbc_municipios.SelectTab(1) : limpaCamposServiço()
                tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True

            End If

        Else
            _clServico.zeraValores()
            _incluindo = True : tbc_municipios.SelectTab(1) : limpaCamposServiço()
            tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True

        End If



    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If _operacao Then 'Se tiver operação executando, então...


            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _clServico.zeraValores()
                _incluindo = False : tbc_municipios.SelectTab(1) : limpaCamposServiço()
                _clServico.pIdServico = dtg_servicos.CurrentRow.Cells(0).Value : _clFuncoes.trazServicoSelecionado(_clServico.pIdServico, _clServico)
                txt_descricao.Text = _clServico.pDescricao
                _descricaoAnterior = _clServico.pDescricao
                txt_valor.Text = Format(_clServico.pValor, "###,##0.00")
                tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True

            End If

        Else
            _clServico.zeraValores()
            _incluindo = False : tbc_municipios.SelectTab(1) : limpaCamposServiço()
            _clServico.pIdServico = dtg_servicos.CurrentRow.Cells(0).Value : _clFuncoes.trazServicoSelecionado(_clServico.pIdServico, _clServico)
            txt_descricao.Text = _clServico.pDescricao
            _descricaoAnterior = _clServico.pDescricao
            txt_valor.Text = Format(_clServico.pValor, "###,##0.00")
            tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True

        End If



    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click


        Try


            If Me.dtg_servicos.CurrentRow.IsNewRow = False Then

                _clServico.zeraValores()
                _clServico.pIdServico = CInt(Me.dtg_servicos.CurrentRow.Cells(0).Value)
                If MessageBox.Show("Deseja realmente Deletar este SERVIÇO?", "METROSYS", _
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

                        _clBD.delServiço(conection, transacao, _clServico.pIdServico)

                        transacao.Commit() : conection.Close()

                        MsgBox("SERVIÇO Deletado com Sucesso!", MsgBoxStyle.Exclamation)
                    Catch ex As Exception
                        MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                        Try
                            transacao.Rollback()

                        Catch ex1 As Exception
                        End Try

                    Finally
                        transacao = Nothing : conection = Nothing
                    End Try



                    limpaCamposServiço() : tbp_manutencao.Text = "Serviço"
                    _incluindo = True : btn_salvar.Enabled = False
                    Me.dtg_servicos.Rows.Clear() : Me.dtg_servicos.Refresh() : preencheDtg_Servicos()
                    _clServico.zeraValores()

                End If
            End If

        Catch ex As Exception
        End Try


    End Sub

    Private Sub dtg_servicos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtg_servicos.RowsAdded

        dtg_servicos.Rows(e.RowIndex).Cells(1).Style.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
        dtg_servicos.Rows(e.RowIndex).Cells(2).Style.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)

    End Sub
End Class