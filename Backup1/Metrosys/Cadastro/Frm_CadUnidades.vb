Imports System
Imports System.Text
Imports Npgsql

Public Class Frm_CadUnidades

    Private _valorZERO As Integer = 0
    Private _alterando As Boolean = False, _incluindo As Boolean = False
    Private _idUnidade As Int32 = _valorZERO
    Private _descricaoAnterior As String = ""
    Dim _clFuncoes As New ClFuncoes
    Dim _clBD As New Cl_bdMetrosys


    Private Sub Frm_CadUnidades_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                preencheDtg_Unidades()

        End Select


    End Sub

    Private Sub Frm_CadUnidades_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub limpaCamposUnidades()

        txt_abreveatura.Text = "" : txt_descricao.Text = ""
    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        If _incluindo = True OrElse _alterando = True Then

            If MessageBox.Show("Operação em aberto! Ela será Subistituída!", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False : tbc_unidades.SelectTab(1) : limpaCamposUnidades()
                tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True : _idUnidade = _valorZERO

            End If

        Else
            _incluindo = True : _alterando = False : tbc_unidades.SelectTab(1) : limpaCamposUnidades()
            tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True
            _idUnidade = _valorZERO

        End If



    End Sub

    Private Sub txt_abreveatura_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_abreveatura.KeyPress

        'permite só letras...
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_descricao_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descricao.KeyPress

        'permite só letras...
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub preencheDtg_Unidades()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdUnidades As New NpgsqlCommand
        Dim sqlUnidades As New StringBuilder
        Dim drUnidades As NpgsqlDataReader

        Dim abreveatura As String = "", descricao As String = ""
        Dim id As Int32 = _valorZERO

        Try

            sqlUnidades.Append("SELECT m_id, medida, descricao FROM medida ORDER BY medida ASC") '3
            cmdUnidades = New NpgsqlCommand(sqlUnidades.ToString, oConnBDMETROSYS)
            drUnidades = cmdUnidades.ExecuteReader

            Dtg_Unidades.Rows.Clear()
            If drUnidades.HasRows = False Then Return
            While drUnidades.Read
                id = drUnidades(0)
                abreveatura = drUnidades(1).ToString
                descricao = drUnidades(2).ToString

                Dtg_Unidades.Rows.Add(id, abreveatura, descricao)

            End While

            Dtg_Unidades.Refresh() : drUnidades.Close()
            oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT das Unidades:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmdUnidades.CommandText = "" : sqlUnidades.Remove(0, sqlUnidades.ToString.Length)

        'Limpa Objetos de Memoria...
        descricao = Nothing : id = Nothing : oConnBDMETROSYS = Nothing : cmdUnidades = Nothing
        sqlUnidades = Nothing : drUnidades = Nothing



    End Sub

    Private Sub Frm_CadUnidades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        preencheDtg_Unidades()
    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Subistituída?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _alterando = True : _incluindo = False : tbc_unidades.SelectTab(1) : limpaCamposUnidades()
                _idUnidade = Dtg_Unidades.CurrentRow.Cells(0).Value : trazUnidadeSelecionada()
                tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True


            End If

        Else
            _alterando = True : _incluindo = False : tbc_unidades.SelectTab(1) : limpaCamposUnidades()
            _idUnidade = Dtg_Unidades.CurrentRow.Cells(0).Value : trazUnidadeSelecionada()
            tbp_manutencao.Text = "Alterando" : btn_salvar.Enabled = True

        End If



    End Sub

    Private Sub trazUnidadeSelecionada()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmdUnidades As New NpgsqlCommand
        Dim sqlUnidades As New StringBuilder
        Dim drUnidades As NpgsqlDataReader

        Try
            sqlUnidades.Append("SELECT m_id, medida, descricao FROM medida WHERE m_id = @m_id")
            cmdUnidades = New NpgsqlCommand(sqlUnidades.ToString, oConnBDMETROSYS)
            cmdUnidades.Parameters.Add("@m_id", _idUnidade)

            drUnidades = cmdUnidades.ExecuteReader

            While drUnidades.Read

                Me.txt_abreveatura.Text = drUnidades(1).ToString
                _descricaoAnterior = drUnidades(2).ToString

                Me.txt_descricao.Text = _descricaoAnterior

            End While
            drUnidades.Close() : oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close()

        Catch ex As Exception
            MsgBox("ERRO no SELECT das UNIDADES:: ", MsgBoxStyle.Exclamation)
            Return

        End Try

        cmdUnidades.CommandText = "" : sqlUnidades.Remove(0, sqlUnidades.ToString.Length)
        drUnidades = Nothing : sqlUnidades = Nothing : cmdUnidades = Nothing : oConnBDMETROSYS = Nothing


    End Sub

    Private Sub btn_excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excluir.Click

        If Me.Dtg_Unidades.CurrentRow.IsNewRow = False Then

            _idUnidade = CInt(Me.Dtg_Unidades.CurrentRow.Cells(0).Value)
            If MessageBox.Show("Deseja realmente Deletar esta UNIDADE?", "METROSYS", _
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

                    _clBD.delUnidadeMedida(conection, transacao, _idUnidade)

                    transacao.Commit() : conection.ClearPool() : conection.Close()

                    MsgBox("UNIDADE DE MEDIDA Deletada com Sucesso!", MsgBoxStyle.Exclamation)
                Catch ex As Exception
                    MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                    Try
                        transacao.Rollback()

                    Catch ex1 As Exception
                    End Try

                Finally
                    transacao = Nothing : conection = Nothing
                End Try



                limpaCamposUnidades() : tbp_manutencao.Text = "Condições"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False
                Me.Dtg_Unidades.Rows.Clear() : Me.Dtg_Unidades.Refresh() : preencheDtg_Unidades()
                _idUnidade = _valorZERO

            End If
        End If


    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                tbc_unidades.SelectTab(0) : limpaCamposUnidades() : tbp_manutencao.Text = "Unidades"
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False
                Me.Dtg_Unidades.Rows.Clear() : Me.Dtg_Unidades.Refresh() : preencheDtg_Unidades()
                _idUnidade = _valorZERO

            End If
        End If


    End Sub

    Private Function verificaCampos() As Boolean

        lbl_mesagem2.Text = ""

        If Trim(Me.txt_abreveatura.Text).Equals("") Then

            lbl_mesagem2.Text = "Informe a UNIDADE Por Favor!"
            Return False
        End If

        If Trim(Me.txt_descricao.Text).Equals("") Then

            lbl_mesagem2.Text = "Informe a DESCRIÇÃO DA UNIDADE Por Favor!"
            Return False
        End If

        Return True

    End Function

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        If verificaCampos() Then

            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            If _incluindo = True Then

                If (_clBD.existeUnidadeMedida(conection, Me.txt_abreveatura.Text) = False) AndAlso _
                (_clBD.existeDescUnidade(conection, Me.txt_descricao.Text) = False) Then

                    conection.ClearAllPools() : conection.Close()
                    inclueUnidade(Me.txt_abreveatura.Text, Me.txt_descricao.Text)

                Else

                    conection.ClearAllPools() : conection.Close()
                    MsgBox("Essa UNIDADE DE MEDIDA já existe! Informe outra UNIDADE", MsgBoxStyle.Exclamation)
                End If


            ElseIf _alterando = True Then


                If _clBD.existeDescUnidadeAlt(conection, Me.txt_descricao.Text, _descricaoAnterior) = False Then

                    conection.ClearAllPools() : conection.Close()
                    alteraUnidade(Me.txt_abreveatura.Text, Me.txt_descricao.Text)
                Else

                    conection.ClearAllPools() : conection.Close()
                    MsgBox("Essa UNIDADE DE MEDIDA já existe! Informe outra UNIDADE", MsgBoxStyle.Exclamation)
                End If
            End If
            conection = Nothing

        End If



    End Sub

    Private Sub inclueUnidade(ByVal medida As String, ByVal descricao As String)

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

            _clBD.incUnidadeMedida(conection, transacao, medida, descricao)

            transacao.Commit() : conection.ClearPool()

            If MessageBox.Show("UNIDADE salva com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                limpaCamposUnidades() : conection.Close() : Me.txt_abreveatura.Focus()

            Else

                limpaCamposUnidades() : _incluindo = False : _alterando = False : conection.Close()
                tbc_unidades.SelectTab(0) : Me.Dtg_Unidades.Rows.Clear() : Me.Dtg_Unidades.Refresh()
                preencheDtg_Unidades()

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

    Private Sub alteraUnidade(ByVal medida As String, ByVal descricao As String)

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

            _clBD.altUnidadeMedida(conection, transacao, _idUnidade, medida, descricao)

            transacao.Commit() : conection.ClearPool()

            MsgBox("UNIDADE salva com sucesso", MsgBoxStyle.Exclamation)
            limpaCamposUnidades() : _incluindo = False : _alterando = False : conection.Close()
            tbc_unidades.SelectTab(0) : Me.Dtg_Unidades.Rows.Clear() : Me.Dtg_Unidades.Refresh()
            preencheDtg_Unidades() : _idUnidade = _valorZERO


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