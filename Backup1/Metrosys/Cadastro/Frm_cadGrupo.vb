Imports System
Imports System.Text
Imports Npgsql

Public Class Frm_cadGrupo

    Private _valorZERO As Integer = 0
    Private _alterando As Boolean = False, _incluindo As Boolean = False
    Private _idGrupo As Int32 = _valorZERO
    Private _descricaoAnterior As String = ""
    Dim _clFuncoes As New ClFuncoes
    Dim _clBD As New Cl_bdMetrosys
    Dim clGrupo As New Cl_Grupo


    Private Sub Frm_cadGrupo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                preencheDtg_Grupo()

        End Select


    End Sub

    Private Sub Frm_cadGrupo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub limpaCamposGrupo()

        txt_grupo.Text = "" : txt_descricao.Text = "" : lbl_mesagem2.Text = ""
    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        clGrupo.zeraValores()
        _incluindo = True : _alterando = False : tbc_grupos.SelectTab(1) : limpaCamposGrupo()
        Me.txt_grupo.Text = _clBD.trazNovoGrupo(MdlConexaoBD.conectionPadrao)
        tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True : _idGrupo = _valorZERO

    End Sub

    Private Sub txt_abreveatura_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_grupo.KeyPress

        'permite só letras...
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_descricao_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descricao.KeyPress

        'permite só letras...
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub preencheDtg_Grupo()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdGrupos As New NpgsqlCommand
        Dim sqlGrupos As New StringBuilder
        Dim drGrupos As NpgsqlDataReader

        Dim grupo As String = "", descricao As String = ""
        Dim id As Int32 = _valorZERO

        Try

            sqlGrupos.Append("SELECT eg_id, eg_grupo, eg_descri FROM estg003 ORDER BY eg_grupo ASC") '3
            cmdGrupos = New NpgsqlCommand(sqlGrupos.ToString, oConnBDMETROSYS)
            drGrupos = cmdGrupos.ExecuteReader

            Dtg_Grupos.Rows.Clear()
            If drGrupos.HasRows = False Then Return
            While drGrupos.Read
                id = drGrupos(0)
                grupo = drGrupos(1).ToString
                descricao = drGrupos(2).ToString

                Dtg_Grupos.Rows.Add(id, grupo, descricao)

            End While

            Dtg_Grupos.Refresh() : drGrupos.Close()
            oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT dos GRUPOS:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmdGrupos.CommandText = "" : sqlGrupos.Remove(0, sqlGrupos.ToString.Length)

        'Limpa Objetos de Memoria...
        descricao = Nothing : id = Nothing : oConnBDMETROSYS = Nothing : cmdGrupos = Nothing
        sqlGrupos = Nothing : drGrupos = Nothing



    End Sub

    Private Sub Frm_cadGrupo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        preencheDtg_Grupo()
    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        clGrupo.zeraValores()
        _alterando = True : _incluindo = False : tbc_Grupos.SelectTab(1) : limpaCamposGrupo()
        _idGrupo = Dtg_Grupos.CurrentRow.Cells(0).Value : trazGrupoSelecionado()
        tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True

    End Sub

    Private Sub trazGrupoSelecionado()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdGrupos As New NpgsqlCommand
        Dim sqlGrupos As New StringBuilder
        Dim drGrupos As NpgsqlDataReader

        Try
            sqlGrupos.Append("SELECT eg_id, eg_grupo, eg_descri FROM estg003 WHERE eg_id = @eg_id")
            cmdGrupos = New NpgsqlCommand(sqlGrupos.ToString, oConnBDMETROSYS)
            cmdGrupos.Parameters.AddWithValue("@eg_id", _idGrupo)

            drGrupos = cmdGrupos.ExecuteReader

            While drGrupos.Read

                clGrupo.pGrupo = drGrupos(1)
                clGrupo.pDescricao = drGrupos(2).ToString

                Me.txt_grupo.Text = clGrupo.pGrupo
                Me.txt_descricao.Text = clGrupo.pDescricao
                _descricaoAnterior = clGrupo.pDescricao

            End While
            drGrupos.Close() : oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()

        Catch ex As Exception
            MsgBox("ERRO no SELECT dos GRUPOS:: ", MsgBoxStyle.Exclamation)
            Return

        End Try

        cmdGrupos.CommandText = "" : sqlGrupos.Remove(0, sqlGrupos.ToString.Length)
        drGrupos = Nothing : sqlGrupos = Nothing : cmdGrupos = Nothing : oConnBDMETROSYS = Nothing


    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click

        'If Me.Dtg_Grupos.CurrentRow.IsNewRow = False Then

        '    _idUnidade = CInt(Me.Dtg_Grupos.CurrentRow.Cells(0).Value)
        '    If MessageBox.Show("Deseja realmente Deletar esta UNIDADE?", "METROSYS", _
        '    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then


        '        Dim transacao As NpgsqlTransaction
        '        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        '        Try
        '            Try
        '                conection.Open()
        '            Catch ex As Exception
        '                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
        '                Return

        '            End Try

        '            transacao = conection.BeginTransaction

        '            _clBD.delUnidadeMedida(conection, transacao, _idUnidade)

        '            transacao.Commit() : conection.ClearPool() : conection.Close()

        '            MsgBox("UNIDADE DE MEDIDA Deletada com Sucesso!", MsgBoxStyle.Exclamation)
        '        Catch ex As Exception
        '            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
        '            Try
        '                transacao.Rollback()

        '            Catch ex1 As Exception
        '            End Try

        '        Finally
        '            transacao = Nothing : conection = Nothing
        '        End Try



        '        limpaCamposCond() : tbp_manutencao.Text = "Condições"
        '        _incluindo = False : _alterando = False : btn_salvar.Enabled = False
        '        Me.Dtg_Grupos.Rows.Clear() : Me.Dtg_Grupos.Refresh() : preencheDtg_Grupo()
        '        _idUnidade = _valorZERO

        '    End If
        'End If


    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                clGrupo.zeraValores()
                tbc_Grupos.SelectTab(0) : limpaCamposGrupo() : tbp_manutencao.Text = "Grupos"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False
                Me.Dtg_Grupos.Rows.Clear() : Me.Dtg_Grupos.Refresh() : preencheDtg_Grupo()
                _idGrupo = _valorZERO


            End If
        End If


    End Sub

    Private Function verificaCampos() As Boolean

        lbl_mesagem2.Text = ""

        If Trim(Me.txt_descricao.Text).Equals("") Then

            lbl_mesagem2.Text = "Informe a DESCRIÇÃO DO GRUPO Por Favor!"
            Return False
        End If

        Return True

    End Function

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        If verificaCampos() Then

            If Trim(Me.txt_grupo.Text).Equals("") = False Then

                Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Try
                    conection.Open()
                Catch ex As Exception
                    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                    Return

                End Try

                If _incluindo = True Then

                    If (_clBD.existeGrupo(conection, Me.txt_grupo.Text) = False) AndAlso _
                    (_clBD.existeDescGrupo(conection, Me.txt_descricao.Text) = False) Then

                        conection.ClearAllPools() : conection.Close()
                        inclueGrupo(Me.txt_grupo.Text, Me.txt_descricao.Text)

                    Else

                        conection.ClearAllPools() : conection.Close()
                        MsgBox("Esse GRUPO já existe! Informe outro GRUPO", MsgBoxStyle.Exclamation)
                    End If


                ElseIf _alterando = True Then


                    If _clBD.existeDescGrupoAlt(conection, Me.txt_descricao.Text, _descricaoAnterior) = False Then

                        conection.ClearAllPools() : conection.Close()
                        alteraGrupo(Me.txt_grupo.Text, Me.txt_descricao.Text)
                    Else

                        conection.ClearAllPools() : conection.Close()
                        MsgBox("Esse GRUPO já existe! Informe outro GRUPO", MsgBoxStyle.Exclamation)
                    End If
                End If
                conection = Nothing


            End If
        End If



    End Sub

    Private Sub inclueGrupo(ByVal grupo As Integer, ByVal descricao As String)

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

            clGrupo.pGrupo = grupo
            clGrupo.pDescricao = descricao

            _clBD.incGrupo(conection, transacao, clGrupo)

            transacao.Commit() : conection.ClearPool()

            If MessageBox.Show("GRUPO salvo com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                limpaCamposGrupo() : conection.Close() : Me.txt_grupo.Focus() : clGrupo.zeraValores()
                Me.txt_grupo.Text = _clBD.trazNovoGrupo(MdlConexaoBD.conectionPadrao)

            Else

                limpaCamposGrupo() : _incluindo = False : _alterando = False : conection.Close()
                tbc_grupos.SelectTab(0) : Me.Dtg_Grupos.Rows.Clear() : Me.Dtg_Grupos.Refresh()
                preencheDtg_Grupo() : clGrupo.zeraValores() : tbp_manutencao.Text = "Grupos"

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

    Private Sub alteraGrupo(ByVal grupo As Integer, ByVal descricao As String)

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

            clGrupo.pGrupo = grupo
            clGrupo.pDescricao = descricao

            _clBD.altGrupo(conection, transacao, _idGrupo, clGrupo)

            transacao.Commit() : conection.ClearPool()

            MsgBox("GRUPO salvo com sucesso", MsgBoxStyle.Exclamation)
            limpaCamposGrupo() : _incluindo = False : _alterando = False : conection.Close()
            tbc_grupos.SelectTab(0) : Me.Dtg_Grupos.Rows.Clear() : Me.Dtg_Grupos.Refresh()
            preencheDtg_Grupo() : _idGrupo = _valorZERO


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

End Class