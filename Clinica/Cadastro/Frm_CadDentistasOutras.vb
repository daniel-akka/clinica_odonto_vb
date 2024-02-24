Imports System.Data
Imports System.Math
Imports System.Text
Imports Npgsql

Public Class Frm_CadDentistasOutras

    Dim _clFuncoes As New ClFuncoes
    Private _incluindo As Boolean = True
    Dim _operacao As Boolean = False
    Private _idDentista As Int32 = 0
    Private _descricaoAnterior As String = ""
    Dim _local2Dig As String = ""
    Dim _clDentistaDAO As New Cl_DentistaOutrasDAO
    Dim _clDentista As New Cl_DentistaOutras
    Dim _Geno As New Cl_Geno

    Private Sub Frm_CadDentistasOutras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        cbo_loja = _clFunc.PreenchComboLoja2DigOutras(cbo_loja, MdlConexaoBD.conectionPadrao, MdlEmpresaUsu._codigo)
        Try
            cbo_loja.SelectedIndex = 0
        Catch ex As Exception
        End Try

        ZeraValores()
        DesHabilitaCampos()
        ExecuteF5()

    End Sub

    Private Sub Frm_CadDentistasOutras_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                ExecuteF5()
            Case Keys.F2
                ExecuteF2()
            Case Keys.F3
                ExecuteF3()
            Case Keys.Delete
                ExecuteDel()
        End Select


    End Sub

    Private Sub Frm_CadDentistasOutras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If

    End Sub

    Sub ZeraValores()
        Me.txt_Id.Text = "" : Me.txt_Nome.Text = "" : Me.msk_Telefone.Text = "" : txt_comiss.Text = "0,00"
        _idDentista = 0 : _descricaoAnterior = ""
        Me.txt_iniciais.Text = "" : Me.chk_protetico.Checked = False
    End Sub

    Sub HabilitaCampos()
        Me.txt_Nome.ReadOnly = False : Me.msk_Telefone.ReadOnly = False : txt_comiss.ReadOnly = False : Me.btn_salvar.Enabled = True
        Me.txt_iniciais.ReadOnly = False : Me.chk_protetico.Enabled = True
    End Sub

    Sub DesHabilitaCampos()
        Me.txt_Nome.ReadOnly = True : Me.msk_Telefone.ReadOnly = True : txt_comiss.ReadOnly = True : Me.btn_salvar.Enabled = False
        Me.txt_iniciais.ReadOnly = True : Me.chk_protetico.Enabled = False
    End Sub

    Private Sub preencheDtg_DentistaOes()

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader


        Try

            sql.Append("SELECT do_id, do_nome, do_telefone, do_comissao FROM dentistas_outras ") '3
            sql.Append("WHERE do_loja = '" & _local2Dig & "' AND do_desabilitado = false AND do_nome LIKE @d_nome ORDER BY do_nome ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConn)
            cmd.Parameters.Add("@d_nome", Me.txt_pesquisa.Text & "%")
            dr = cmd.ExecuteReader

            dtg_doutores.Rows.Clear()
            If dr.HasRows = False Then Return
            While dr.Read
                dtg_doutores.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, Format(dr(3), "##0.00"))
            End While

            dtg_doutores.Refresh() : dr.Close()
            oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT dos DENTISTA:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmd.CommandText = ""
        sql.Remove(0, sql.ToString.Length)

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmd = Nothing
        sql = Nothing : dr = Nothing



    End Sub

    Sub ExecuteF5()
        preencheDtg_DentistaOes()
    End Sub

    Sub ExecuteF2()

        _incluindo = True : ZeraValores()
        HabilitaCampos() : _clDentista.zeraValores()
        Me.txt_Nome.Focus()

    End Sub

    Sub ExecuteF3()

        _incluindo = False : ZeraValores()
        HabilitaCampos() : _clDentista.zeraValores()
        Try
            If dtg_doutores.CurrentRow.IsNewRow = False Then
                _clDentista.do_id = dtg_doutores.CurrentRow.Cells(0).Value
                _clDentistaDAO.trazDentistaOLoja(_clDentista.do_id, _Geno, _clDentista)

                _idDentista = _clDentista.do_id
                _descricaoAnterior = _clDentista.do_nome

                txt_Id.Text = _clDentista.do_id
                txt_Nome.Text = _clDentista.do_nome
                msk_Telefone.Text = _clDentista.do_telefone
                txt_comiss.Text = Format(_clDentista.do_comissao, "##0.00")
                txt_iniciais.Text = _clDentista.do_iniciais
                chk_protetico.Checked = _clDentista.do_protetico

            End If
        Catch ex As Exception
        End Try
        Me.txt_Nome.Focus() : Me.txt_Nome.SelectAll()

    End Sub

    Sub ExecuteDel()

        Try

            If dtg_doutores.CurrentRow.IsNewRow = False Then

                If MessageBox.Show("Deseja Realmente Deletar esse Dentista ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                    ZeraValores() : DesHabilitaCampos() : _clDentista.zeraValores()
                    _clDentista.do_id = dtg_doutores.CurrentRow.Cells(0).Value


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
                        _clDentistaDAO.desabilitaDentistaO(_clDentista, _Geno, conection, transacao)
                        transacao.Commit() : conection.Close()
                        ExecuteF5()
                        MsgBox("DENTISTA Deletado com Sucesso!", MsgBoxStyle.Exclamation)
                    Catch ex As Exception
                        MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                        Try
                            transacao.Rollback()

                        Catch ex1 As Exception
                        End Try

                    Finally
                        transacao = Nothing : conection = Nothing
                    End Try



                End If

            End If
        Catch ex As Exception
        End Try


    End Sub

    Private Sub txt_pesquisa_TextChanged(sender As Object, e As EventArgs) Handles txt_pesquisa.TextChanged
        ExecuteF5()
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        ExecuteDel()
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
        ExecuteF3()
    End Sub

    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        ExecuteF2()
    End Sub

    Private Sub btn_salvar_Click(sender As Object, e As EventArgs) Handles btn_salvar.Click

        Try
            _clDentista.do_id = Me.txt_Id.Text
        Catch ex As Exception
            _clDentista.do_id = 0
        End Try

        _clDentista.do_loja = _local2Dig
        _clDentista.do_nome = Me.txt_Nome.Text
        _clDentista.do_comissao = CDbl(Me.txt_comiss.Text)
        _clDentista.do_telefone = _clFuncoes.RemoverCaracterTelefone(Me.msk_Telefone.Text)
        _clDentista.do_iniciais = txt_iniciais.Text
        _clDentista.do_protetico = chk_protetico.Checked

        If _clDentistaDAO.ValidaDentistaO(_clDentista, _incluindo) = False Then Return

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If _incluindo Then


                If _clDentistaDAO.existeNomeDentistaO(txt_Nome.Text, _Geno, connection) Then

                    MsgBox("O NOME deste Dentista já existe !")
                    txt_Nome.Focus() : txt_Nome.SelectAll()
                    Return
                End If

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _clDentistaDAO.IncDentistaO(_clDentista, _Geno, connection, transacao)
                transacao.Commit()

            Else

                If _clDentistaDAO.existeNomeDentistaOAlt(_descricaoAnterior, txt_Nome.Text, _Geno, connection) Then

                    MsgBox("O NOME deste Dentista já existe !")
                    txt_Nome.Focus() : txt_Nome.SelectAll()
                    Return
                End If

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _clDentistaDAO.altDentistaO(_clDentista, _Geno, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("DENTISTA Salvo com Sucesso", MsgBoxStyle.Exclamation)
            ZeraValores()
            DesHabilitaCampos()
            _clDentista.zeraValores()
            ExecuteF5() : txt_pesquisa.Focus()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.Close() : connection = Nothing
        End Try



    End Sub

    Private Sub txt_comiss_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_comiss.KeyPress
        'permite só numeros com virgula:
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_comiss_Leave(sender As Object, e As EventArgs) Handles txt_comiss.Leave

        If Me.txt_comiss.Text.Equals("") Then Me.txt_comiss.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_comiss.Text) Then
            Me.txt_comiss.Text = Format(CDec(Me.txt_comiss.Text), "###,##0.00")
        Else
            MsgBox("Comissão deve ser Numérico") : txt_comiss.Focus() : txt_comiss.SelectAll() : Return
        End If

    End Sub

    Private Sub cbo_loja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_loja.SelectedIndexChanged

        Try

            If cbo_loja.SelectedIndex > -1 Then
                _local2Dig = Mid(cbo_loja.SelectedItem.ToString, 1, 2)
                _clFuncoes.trazGenoSelecionado("G00" & _local2Dig, _Geno)
            End If
        Catch ex As Exception
        End Try

    End Sub

End Class