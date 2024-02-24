Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class Frm_CadDespesasReceitas

    Dim _clFuncoes As New ClFuncoes
    Private _incluindo As Boolean = True
    Dim _operacao As Boolean = False
    Private _idDescricao As Int32 = 0
    Private _descricaoAnterior As String = ""
    Dim _clDoutorDAO As New Cl_DescrDespRecDAO
    Dim _clDoutor As New Cl_DescrDespRec
    Dim _Tipo As String = "D" 'Despesa

    Private Sub Frm_CadDespesasReceitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        ZeraValores()
        DesHabilitaCampos()
        ExecuteF5()

    End Sub

    Private Sub Frm_CadDespesasReceitas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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

    Private Sub Frm_CadDespesasReceitas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If

    End Sub

    Sub ZeraValores()
        Me.txt_Id.Text = "" : Me.txt_Nome.Text = "" : Me.cbo_tipo.SelectedIndex = 0
        _idDescricao = 0 : _descricaoAnterior = ""
    End Sub

    Sub HabilitaCampos()
        Me.txt_Nome.ReadOnly = False : Me.cbo_tipo.SelectedIndex = 0 : Me.btn_salvar.Enabled = True
    End Sub

    Sub DesHabilitaCampos()
        Me.btn_salvar.Enabled = False
    End Sub

    Private Sub preencheDtg_Doutores()

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

            sqlMunicipios.Append("SELECT d_id, d_descricao, d_tipo FROM descr_desp_rec ") '3
            sqlMunicipios.Append("WHERE d_descricao LIKE @d_descricao ORDER BY d_descricao ASC")
            cmdMunicipios = New NpgsqlCommand(sqlMunicipios.ToString, oConn)
            cmdMunicipios.Parameters.Add("@d_descricao", Me.txt_pesquisa.Text & "%")
            drMunicipios = cmdMunicipios.ExecuteReader

            dtg_doutores.Rows.Clear()
            If drMunicipios.HasRows = False Then Return
            While drMunicipios.Read
                dtg_doutores.Rows.Add(drMunicipios(0), drMunicipios(1).ToString, drMunicipios(2).ToString)
            End While

            dtg_doutores.Refresh() : drMunicipios.Close()
            oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT de Consulta:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmdMunicipios.CommandText = ""
        sqlMunicipios.Remove(0, sqlMunicipios.ToString.Length)

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmdMunicipios = Nothing
        sqlMunicipios = Nothing : drMunicipios = Nothing



    End Sub

    Sub ExecuteF5()
        preencheDtg_Doutores()
    End Sub

    Sub ExecuteF2()

        _incluindo = True : ZeraValores()
        HabilitaCampos() : _clDoutor.zeraValores()
        Me.txt_Nome.Focus()

    End Sub

    Sub ExecuteF3()

        _incluindo = False : ZeraValores()
        HabilitaCampos() : _clDoutor.zeraValores()
        Try
            If dtg_doutores.CurrentRow.IsNewRow = False Then
                _clDoutor.d_id = dtg_doutores.CurrentRow.Cells(0).Value
                _clDoutorDAO.trazDescricaoPorId(_clDoutor.d_id, _clDoutor)

                _idDescricao = _clDoutor.d_id
                _descricaoAnterior = _clDoutor.d_descricao

                txt_Id.Text = _clDoutor.d_id
                txt_Nome.Text = _clDoutor.d_descricao

            End If
        Catch ex As Exception
        End Try
        Me.txt_Nome.Focus() : Me.txt_Nome.SelectAll()

    End Sub

    Sub ExecuteDel()

        Try

            If dtg_doutores.CurrentRow.IsNewRow = False Then

                If MessageBox.Show("Deseja Realmente Deletar esse Registro ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                    ZeraValores() : DesHabilitaCampos() : _clDoutor.zeraValores()
                    _clDoutor.d_id = dtg_doutores.CurrentRow.Cells(0).Value


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
                        _clDoutorDAO.delDoutor(_clDoutor, conection, transacao)
                        transacao.Commit() : conection.Close()

                        MsgBox("Registro Deletado com Sucesso!", MsgBoxStyle.Exclamation)
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
            _clDoutor.d_id = Me.txt_Id.Text
        Catch ex As Exception
            _clDoutor.d_id = 0
        End Try

        _clDoutor.d_descricao = Me.txt_Nome.Text
        _clDoutor.d_tipo = _Tipo

        If _clDoutorDAO.ValidaDescricao(_clDoutor, _incluindo) = False Then Return

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If _incluindo Then


                If _clDoutorDAO.existeNomeDescr(txt_Nome.Text, connection) Then

                    MsgBox("O Descricao já existe !")
                    txt_Nome.Focus() : txt_Nome.SelectAll()
                    Return
                End If

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _clDoutorDAO.IncDescrDespRec(_clDoutor, connection, transacao)
                transacao.Commit()

            Else

                If _clDoutorDAO.existeNomeDescrAlt(_descricaoAnterior, txt_Nome.Text, connection) Then

                    MsgBox("O Descricao já existe !")
                    txt_Nome.Focus() : txt_Nome.SelectAll()
                    Return
                End If

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _clDoutorDAO.altDescrDespRec(_clDoutor, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Registro Salvo com Sucesso", MsgBoxStyle.Exclamation)
            ZeraValores()
            DesHabilitaCampos()
            _clDoutor.zeraValores()
            ExecuteF5() : txt_pesquisa.Focus()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.Close() : connection = Nothing
        End Try



    End Sub

    Private Sub cbo_tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tipo.SelectedIndexChanged

        Try

            Select Case cbo_tipo.SelectedIndex
                Case 0
                    _Tipo = "D"
                Case 1
                    _Tipo = "R"

            End Select

        Catch ex As Exception
        End Try

    End Sub

End Class