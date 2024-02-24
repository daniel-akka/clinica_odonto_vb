Imports System.Data
Imports System.Math
Imports System.Text
Imports Npgsql

Public Class Frm_TpAtendimento

    Dim _clFuncoes As New ClFuncoes
    Private _incluindo As Boolean = True
    Dim _operacao As Boolean = False
    Private _idDentista As Int32 = 0
    Private _descricaoAnterior As String = ""
    Dim _clTpAtendimento As New Cl_TpAtendimento
    Dim _Geno As New Cl_Geno

    Private Sub Frm_TpAtendimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        _clFuncoes.trazGenoSelecionado(MdlEmpresaUsu._codigo, _Geno)
        ZeraValores()
        DesHabilitaCampos()
        ExecuteF5()

    End Sub

    Private Sub Frm_TpAtendimento_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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

    Private Sub Frm_TpAtendimento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If

    End Sub

    Sub ZeraValores()
        Me.txt_Id.Text = "" : Me.txt_Descricao.Text = "" : txt_comiss.Text = "0,00"
        _idDentista = 0 : _descricaoAnterior = ""

    End Sub

    Sub HabilitaCampos()
        Me.txt_Descricao.ReadOnly = False : txt_comiss.ReadOnly = False : Me.btn_salvar.Enabled = True
    End Sub

    Sub DesHabilitaCampos()
        Me.txt_Descricao.ReadOnly = True : txt_comiss.ReadOnly = True : Me.btn_salvar.Enabled = False
    End Sub

    Private Sub preencheDtg_Doutores()

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

            sql.Append("SELECT tpa_id, tpa_atendimento, tpa_porcentage FROM tpantendimento ") '3
            sql.Append("WHERE tpa_atendimento LIKE @tpa_atendimento ORDER BY tpa_atendimento ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConn)
            cmd.Parameters.Add("@tpa_atendimento", Me.txt_pesquisa.Text & "%")
            dr = cmd.ExecuteReader

            dtg_doutores.Rows.Clear()
            If dr.HasRows = False Then Return
            While dr.Read
                dtg_doutores.Rows.Add(dr(0), dr(1).ToString, Format(dr(2), "##0.00"))
            End While

            dtg_doutores.Refresh() : dr.Close()
            oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT dos Tipos de Atendimento:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmd.CommandText = ""
        sql.Remove(0, sql.ToString.Length)

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmd = Nothing
        sql = Nothing : dr = Nothing



    End Sub

    Sub ExecuteF5()
        preencheDtg_Doutores()
    End Sub

    Sub ExecuteF2()

        _incluindo = True : ZeraValores()
        HabilitaCampos() : _clTpAtendimento.zeraValores()
        Me.txt_Descricao.Focus()

    End Sub

    Sub ExecuteF3()

        _incluindo = False : ZeraValores()
        HabilitaCampos() : _clTpAtendimento.zeraValores()
        Try
            If dtg_doutores.CurrentRow.IsNewRow = False Then
                _clTpAtendimento.tpa_id = dtg_doutores.CurrentRow.Cells(0).Value
                _clTpAtendimento.DAO.trazTpAtendimentoID(_clTpAtendimento.tpa_id, _clTpAtendimento)

                _idDentista = _clTpAtendimento.tpa_id
                _descricaoAnterior = _clTpAtendimento.tpa_atendimento

                txt_Id.Text = _clTpAtendimento.tpa_id
                txt_Descricao.Text = _clTpAtendimento.tpa_atendimento
                txt_comiss.Text = Format(_clTpAtendimento.tpa_porcentage, "##0.00")

            End If
        Catch ex As Exception
        End Try
        Me.txt_Descricao.Focus() : Me.txt_Descricao.SelectAll()

    End Sub

    Sub ExecuteDel()

        Try

            If dtg_doutores.CurrentRow.IsNewRow = False Then

                If MessageBox.Show("Deseja Realmente Deletar esse ""Tipo de Atendimento"" ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                    ZeraValores() : DesHabilitaCampos() : _clTpAtendimento.zeraValores()
                    _clTpAtendimento.tpa_id = dtg_doutores.CurrentRow.Cells(0).Value


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
                        _clTpAtendimento.DAO.delTpAtend(_clTpAtendimento, conection, transacao)
                        transacao.Commit() : conection.Close()
                        ExecuteF5()
                        MsgBox("""Tipo de Atendimento"" Deletado com Sucesso!", MsgBoxStyle.Exclamation)
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
            _clTpAtendimento.tpa_id = Me.txt_Id.Text
        Catch ex As Exception
            _clTpAtendimento.tpa_id = 0
        End Try

        _clTpAtendimento.tpa_atendimento = Me.txt_Descricao.Text
        _clTpAtendimento.tpa_porcentage = CDbl(Me.txt_comiss.Text)

        If _clTpAtendimento.DAO.ValidaTpAtend(_clTpAtendimento, _incluindo) = False Then Return

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If _incluindo Then


                If _clTpAtendimento.DAO.existDescrTpAtend(txt_Descricao.Text, connection) Then

                    MsgBox("A DESCRICAO deste ""Tipo de Atendimento"" já existe !")
                    txt_Descricao.Focus() : txt_Descricao.SelectAll()
                    Return
                End If

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _clTpAtendimento.DAO.IncTpAtend(_clTpAtendimento, connection, transacao)
                transacao.Commit()

            Else

                If _clTpAtendimento.DAO.existeNomeTpAtendAlt(_descricaoAnterior, txt_Descricao.Text, connection) Then

                    MsgBox("A DESCRICAO deste ""Tipo de Atendimento"" já existe !")
                    txt_Descricao.Focus() : txt_Descricao.SelectAll()
                    Return
                End If

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _clTpAtendimento.DAO.altTpAtend(_clTpAtendimento, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("""Tipo de Atendimento"" Salvo com Sucesso", MsgBoxStyle.Exclamation)
            ZeraValores()
            DesHabilitaCampos()
            _clTpAtendimento.zeraValores()
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

End Class