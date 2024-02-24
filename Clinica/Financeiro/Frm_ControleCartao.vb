Imports Npgsql
Imports System.Text
Imports System.Math

Public Class Frm_ControleCartao

    Dim _Geno1, _Geno2 As New Cl_Geno
    Dim _CCartao As New Cl_ControleCartao
    Dim _clFuncoes As New ClFuncoes
    Dim _LojaPesq As String = ""
    Public Shared _frmREf As New Frm_ControleCartao
    Public nomeRef As String = ""

    Private Sub Frm_ControleCartao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_NomeSys.Text = Application.ProductName


        cbo_empresa1 = _clFuncoes.PreenchComboLoja2Dig(cbo_empresa1, MdlConexaoBD.conectionPadrao)
        cbo_empresa2 = _clFuncoes.PreenchComboLoja2Dig(cbo_empresa2, MdlConexaoBD.conectionPadrao)
        cbo_empresa1.SelectedIndex = 0 : cbo_empresa2.SelectedIndex = 0

        executaF5()

    End Sub


    Private Sub Frm_ControleCartao_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F3
                ExecutaF3()
            Case Keys.F5
                executaF5()
            Case Keys.Delete
                ExecutaDel()
        End Select

    End Sub

    Private Sub txt_vlrCartao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_vlrCartao.KeyPress
        'permite só numeros com virgula:
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_vlrCartao_Leave(sender As Object, e As EventArgs) Handles txt_vlrCartao.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlrCartao.Text.Equals("") Then Me.txt_vlrCartao.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vlrCartao.Text) Then
            If CDec(Me.txt_vlrCartao.Text) < 0 Then
                lbl_mensagem.Text = """Valor Cartão"" deve ser maior ou igual a ZERO !"
                Return

            End If
            Me.txt_vlrCartao.Text = Format(CDec(Me.txt_vlrCartao.Text), "###,##0.00")

        Else
            lbl_mensagem.Text = """Valor Cartão"" deve ser NUMÉRICO !"
            Return
        End If


    End Sub

    Function ValidaVlrCartao() As Boolean
        lbl_mensagem.Text = ""
        If IsNumeric(Me.txt_vlrCartao.Text) Then
            If CDec(Me.txt_vlrCartao.Text) < 0 Then
                lbl_mensagem.Text = """Valor Cartão"" deve ser maior ou igual a ZERO !"
                Return False

            End If

        Else
            lbl_mensagem.Text = """Valor Cartão"" deve ser NUMÉRICO !"
            Return False
        End If

        Return True
    End Function

    Private Sub Frm_ControleCartao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Function ValidaValores() As Boolean

        If ValidaVlrCartao() = False Then Return False

        Return True
    End Function

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        If ValidaValores() = False Then Return
        Try

            If _CCartao.cc_id > 0 Then
                If MessageBox.Show("Registro em Alteração! Deseja DESFAZER a Alteração e Incluir?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                    Windows.Forms.DialogResult.No Then
                    Return
                End If
            End If
            Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            _CCartao.cc_id = 0
            _CCartao.cc_loja = Mid(cbo_empresa2.SelectedItem.ToString, 1, 2)
            _CCartao.cc_data = dtp_data.Value
            _CCartao.cc_vlrcartao = txt_vlrCartao.Text


            If _CCartao.DAO.existeControleCartao_por_Data_Loja(_CCartao.cc_data, _CCartao.cc_loja) Then
                If MessageBox.Show("Já contém um registro lançao nessa ""Data""!. Deseja continuar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                    Windows.Forms.DialogResult.No Then
                    Return
                End If
            End If

            _CCartao.DAO.IncControleCartao(_CCartao, conexao)
            MsgBox("Registro Incluido com Sucesso ! ")

            ZeraValores()
            cbo_empresa2.Focus()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If ValidaValores() = False Then Return
        Try
            If _CCartao.cc_id <= 0 Then
                MsgBox("Registro não Selecionado para Alteração! Por Favor Selecionar um Registro ou Clique em Incluir!", MsgBoxStyle.Exclamation)
                Return
            End If
            Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            _CCartao.cc_loja = Mid(cbo_empresa2.SelectedItem.ToString, 1, 2)
            _CCartao.cc_data = dtp_data.Value
            _CCartao.cc_vlrcartao = txt_vlrCartao.Text

            _CCartao.DAO.altControleCartao(_CCartao, conexao)
            MsgBox("Registro Alterado com Sucesso ! ")

            ZeraValores()
            cbo_empresa2.Focus()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Sub ZeraValores()

        Try
            cbo_empresa2.SelectedIndex = 0
        Catch ex As Exception
        End Try


        Me.txt_vlrCartao.Text = "0,00"
        _CCartao.zeraValores()

    End Sub

    Private Sub cbo_empresa1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_empresa1.SelectedIndexChanged

        Try
            If cbo_empresa1.SelectedIndex >= 0 Then
                _LojaPesq = Mid(cbo_empresa1.SelectedItem.ToString, 1, 2)
                _clFuncoes.trazGenoSelecionado("G00" & _LojaPesq, _Geno1)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbo_empresa2_GotFocus(sender As Object, e As EventArgs) Handles cbo_empresa2.GotFocus
        If cbo_empresa1.DroppedDown = False Then cbo_empresa2.DroppedDown = True
    End Sub

    Private Sub cbo_empresa2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_empresa2.SelectedIndexChanged

        Try
            If cbo_empresa2.SelectedIndex >= 0 Then
                _clFuncoes.trazGenoSelecionado("G00" & Mid(cbo_empresa2.SelectedItem.ToString, 1, 2), _Geno2)
            End If
        Catch ex As Exception
        End Try

    End Sub

#Region "*   Pesquisa *"

    Function TrazConsultaCMensal() As String
        Dim Sqlcomm As StringBuilder = New StringBuilder

        Sqlcomm.Append("SELECT cc_id, cc_loja, to_char(cc_data, 'dd/MM/yyyy'), cc_vlrcartao FROM controle_cartao ") '5
        Sqlcomm.Append("WHERE cc_loja = '" & _LojaPesq & "' ")

        If IsDate(dtp_inicial.Text) AndAlso IsDate(dtp_final.Text) Then
            Sqlcomm.Append("AND (cc_data BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "') ")
        End If

        Sqlcomm.Append("ORDER BY cc_data ASC LIMIT 10000")


        Return Sqlcomm.ToString
    End Function

    Private Sub executaF5()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim consulta As String

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão:: " & ex.Message)
        End Try

        consulta = TrazConsultaCMensal()

        comm = New NpgsqlCommand(consulta, conn)
        dr = comm.ExecuteReader

        Try
            dtg_controleCartao.Rows.Clear() : dtg_controleCartao.Refresh()

            While dr.Read

                Dim mlinha As String() = {dr(0), dr(1).ToString, dr(2).ToString, Format(dr(3), "###,##0.00")}
                dtg_controleCartao.Rows.Add(mlinha)
            End While
            dtg_controleCartao.Refresh()

            SomaValores()
            conn.Close()
            conn = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Sub SomaValores()

        Dim mTotCartao As Double

        Try
            For Each row As DataGridViewRow In dtg_controleCartao.Rows
                If row.IsNewRow = False Then
                    mTotCartao += CDbl(row.Cells(3).Value)
                End If
            Next
        Catch ex As Exception
            mTotCartao = 0
        End Try

        txt_totValores.Text = Format(Round(mTotCartao, 2), "###,##0.00")
    End Sub

#End Region

    Private Sub dtg_controleMensal_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtg_controleCartao.RowsAdded

        dtg_controleCartao.Rows(e.RowIndex).Cells(1).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
        dtg_controleCartao.Rows(e.RowIndex).Cells(2).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
        dtg_controleCartao.Rows(e.RowIndex).Cells(3).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
        'dtg_controleMensal.Rows(e.RowIndex).Cells(4).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)

    End Sub

    Private Sub dtp_inicial_ValueChanged(sender As Object, e As EventArgs) Handles dtp_inicial.ValueChanged, dtp_final.ValueChanged
        executaF5()
    End Sub

    Private Sub cbo_dentistas_SelectedIndexChanged(sender As Object, e As EventArgs)
        executaF5()
    End Sub

    Private Sub btn_Editar_Click(sender As Object, e As EventArgs) Handles btn_Editar.Click
        ExecutaF3()
    End Sub

    Sub ExecutaF3()

        Try
            If dtg_controleCartao.CurrentRow.IsNewRow = False Then

                Dim id As Int64 = dtg_controleCartao.CurrentRow.Cells(0).Value

                _CCartao = _CCartao.DAO.trazControleCartao_por_ID(id)
                preenchCamposCCartao()
                tbc_CMensal.SelectTab(1)

            End If
        Catch ex As Exception
            MsgBox("Error ao Preparar Edição:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Sub ExecutaDel()

        Try
            If dtg_controleCartao.CurrentRow.IsNewRow = False Then

                If MessageBox.Show("Deseja Realmente Deletar esse Registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


                    Dim id As Int64 = dtg_controleCartao.CurrentRow.Cells(0).Value

                    _CCartao = _CCartao.DAO.trazControleCartao_por_ID(id)
                    _CCartao.DAO.delControleCartao(_CCartao, MdlConexaoBD.conectionPadrao)
                    MsgBox("Registro Deletado com Sucesso")
                    executaF5()
                End If
                
            End If
        Catch ex As Exception
            MsgBox("Error ao Preparar Edição:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Sub preenchCamposCCartao()

        Try
            cbo_empresa2.SelectedIndex = _clFuncoes.trazIndexComboBox(_CCartao.cc_loja, _CCartao.cc_loja.Length, cbo_empresa2)
        Catch ex As Exception
        End Try

        dtp_data.Value = _CCartao.cc_data
        txt_vlrCartao.Text = Format(_CCartao.cc_vlrcartao, "###,##0.00")

    End Sub

End Class