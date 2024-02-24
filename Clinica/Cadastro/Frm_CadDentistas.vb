Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class Frm_CadDentistas

    Dim _clFuncoes As New ClFuncoes
    Private _incluindo As Boolean = True
    Dim _operacao As Boolean = False
    Private _idDentista As Int32 = 0
    Private _descricaoAnterior As String = ""
    Dim _clDoutorDAO As New Cl_DoutorDAO
    Dim _clDoutor As New Cl_Doutor
    Dim _Geno As New Cl_Geno

    Private Sub Frm_CadDoutores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        _clFuncoes.trazGenoSelecionado(MdlEmpresaUsu._codigo, _Geno)
        ZeraValores()
        DesHabilitaCampos()
        ExecuteF5()

    End Sub

    Private Sub Frm_CadDoutores_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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

    Private Sub Frm_CadDoutores_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

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

            sql.Append("SELECT d_id, d_nome, d_telefone, d_comissao FROM " & _Geno.pEsquemaestab & ".doutores ") '3
            sql.Append("WHERE d_desabilitado = false AND d_nome LIKE @d_nome ORDER BY d_nome ASC")
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
                _clDoutor.Id = dtg_doutores.CurrentRow.Cells(0).Value
                _clDoutorDAO.trazDoutorLoja(_clDoutor.Id, _Geno, _clDoutor)

                _idDentista = _clDoutor.Id
                _descricaoAnterior = _clDoutor.Nome

                txt_Id.Text = _clDoutor.Id
                txt_Nome.Text = _clDoutor.Nome
                msk_Telefone.Text = _clDoutor.Telefone
                txt_comiss.Text = Format(_clDoutor.Comissao, "##0.00")
                txt_iniciais.Text = _clDoutor.Iniciais
                chk_protetico.Checked = _clDoutor.Protetico

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

                    ZeraValores() : DesHabilitaCampos() : _clDoutor.zeraValores()
                    _clDoutor.Id = dtg_doutores.CurrentRow.Cells(0).Value


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
                        _clDoutorDAO.desabilitaDoutor(_clDoutor, _Geno, conection, transacao)
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
            _clDoutor.Id = Me.txt_Id.Text
        Catch ex As Exception
            _clDoutor.Id = 0
        End Try

        _clDoutor.Nome = Me.txt_Nome.Text
        _clDoutor.Comissao = CDbl(Me.txt_comiss.Text)
        _clDoutor.Telefone = _clFuncoes.RemoverCaracterTelefone(Me.msk_Telefone.Text)
        _clDoutor.Iniciais = txt_iniciais.Text
        _clDoutor.Protetico = chk_protetico.Checked

        If _clDoutorDAO.ValidaDoutor(_clDoutor, _incluindo) = False Then Return

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If _incluindo Then


                If _clDoutorDAO.existeNomeDoutor(txt_Nome.Text, _Geno, connection) Then

                    MsgBox("O NOME deste Dentista já existe !")
                    txt_Nome.Focus() : txt_Nome.SelectAll()
                    Return
                End If

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _clDoutorDAO.IncDoutor(_clDoutor, _Geno, connection, transacao)
                transacao.Commit()

            Else

                If _clDoutorDAO.existeNomeDoutorAlt(_descricaoAnterior, txt_Nome.Text, _Geno, connection) Then

                    MsgBox("O NOME deste Dentista já existe !")
                    txt_Nome.Focus() : txt_Nome.SelectAll()
                    Return
                End If

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _clDoutorDAO.altDoutor(_clDoutor, _Geno, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("DENTISTA Salvo com Sucesso", MsgBoxStyle.Exclamation)
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