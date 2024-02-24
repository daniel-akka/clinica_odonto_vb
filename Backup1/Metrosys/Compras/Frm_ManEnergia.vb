Imports Npgsql
Imports System.Text

Public Class Frm_ManEnergia
    Private _clFunc As New ClFuncoes
    Public Shared _frmREfManEnergia As New Frm_ManEnergia


    Private Sub btn_inclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inclui.Click

        Dim CadEnerg As New Frm_ServicosEnergia
        CadEnerg.Show()

    End Sub

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click

        Me.Close()

    End Sub

    Private Sub Frm_ManEnergia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F2
                Dim CadEnerg As New Frm_ServicosEnergia
                CadEnerg.Show()

            Case Keys.F3
                Dim ServEnergAlt As New Frm_ServicosEnergia_alt
                _frmREfManEnergia = Me : ServEnergAlt.Show()

            Case Keys.Escape
                Me.Close()

            Case Keys.F7
                Me.atualizaDgEnergia()

            Case Keys.F4
                Me.excluirNfEnergia()

        End Select

        If e.Alt AndAlso e.KeyCode = Keys.B Then Me.cbo_consulta.Focus()



    End Sub

    Private Sub Frm_ManEnergia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Preenche DataGridView
        Me.cbo_consulta.SelectedIndex = 0
        If Me.cbo_consulta.SelectedIndex < 0 Then
            Me.preencheDgEnergia()

        Else
            Me.busca10ultimasNotas()

        End If



    End Sub

    Private Sub Frm_ManEnergia_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.GotFocus

        Me.preencheDgEnergia()

    End Sub

    Private Sub btn_altera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_altera.Click

        If Me.dgEnergia.CurrentRow.Selected = True Then
            _frmREfManEnergia = Me
            Dim ServEnergAlt As New Frm_ServicosEnergia_alt
            ServEnergAlt.Show()

        Else
            MsgBox("Selecione um registro, por favor", MsgBoxStyle.Exclamation)

        End If



    End Sub

    Public Sub preencheDgEnergia()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try



        Dim sqlEnergia As New StringBuilder
        Dim cmdEnergia As NpgsqlCommand
        Dim drEnergia As NpgsqlDataReader

        Try
            sqlEnergia.Append("SELECT en_id, to_char(en_dtentrada, 'dd/MM/yyyy'), en_numero, en_cliente, ")
            sqlEnergia.Append("SUBSTR(cad.p_portad, 1, 60), to_char(en_vencto, 'dd/MM/yyyy'), en_consumo ")
            sqlEnergia.Append("FROM " & MdlEmpresaUsu._esqEstab & ".servenergia ")
            sqlEnergia.Append("LEFT JOIN cadp001 cad ON cad.p_cod = en_cliente ORDER BY en_dtentrada DESC")
            cmdEnergia = New NpgsqlCommand(sqlEnergia.ToString, oConnBDMETROSYS)
            drEnergia = cmdEnergia.ExecuteReader

            Me.dgEnergia.Rows.Clear()
            Dim id, dtEntrada, numero, codPart, nomePart, dtVenc, consumo, participante As String

            While drEnergia.Read
                id = drEnergia(0) \ 1
                dtEntrada = drEnergia(1)
                numero = drEnergia(2)
                codPart = drEnergia(3)
                nomePart = drEnergia(4)
                dtVenc = drEnergia(5)
                consumo = drEnergia(6)
                participante = codPart & " - " & nomePart

                Me.dgEnergia.Rows.Add(dtEntrada, numero, Trim(participante), dtVenc, consumo, id)
            End While

            dgEnergia.Refresh() : drEnergia.Close() : oConnBDMETROSYS.ClearPool()
            cmdEnergia.CommandText = "" : sqlEnergia.Remove(0, sqlEnergia.ToString.Length)

            'Limpa objetos da Memória...
            id = Nothing : dtEntrada = Nothing : numero = Nothing : codPart = Nothing : nomePart = Nothing
            dtVenc = Nothing : consumo = Nothing : participante = Nothing
        Catch ex As Exception
            MsgBox("ERRO no SELECT da ENERGIA:: " & ex.Message, MsgBoxStyle.Critical)

        End Try

        oConnBDMETROSYS.Close() : cmdEnergia = Nothing : sqlEnergia = Nothing : drEnergia = Nothing
        oConnBDMETROSYS = Nothing



    End Sub

    Public Sub atualizaDgEnergia()

        executaConsulta()

    End Sub

    Public Sub busca10ultimasNotas()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try



        Dim sqlEnergia As New StringBuilder
        Dim cmdEnergia As NpgsqlCommand
        Dim drEnergia As NpgsqlDataReader

        Try
            sqlEnergia.Append("SELECT en_id, to_char(en_dtentrada, 'dd/MM/yyyy'), en_numero, en_cliente, ")
            sqlEnergia.Append("SUBSTR(cad.p_portad, 1, 60), to_char(en_vencto, 'dd/MM/yyyy'), en_consumo ")
            sqlEnergia.Append("FROM " & MdlEmpresaUsu._esqEstab & ".servenergia ")
            sqlEnergia.Append("LEFT JOIN cadp001 cad ON cad.p_cod = en_cliente ORDER BY en_dtentrada DESC LIMIT 10")
            cmdEnergia = New NpgsqlCommand(sqlEnergia.ToString, oConnBDMETROSYS)
            drEnergia = cmdEnergia.ExecuteReader

            Me.dgEnergia.Rows.Clear()
            Dim id, dtEntrada, numero, codPart, nomePart, dtVenc, consumo, participante As String

            While drEnergia.Read
                id = drEnergia(0) \ 1
                dtEntrada = drEnergia(1)
                numero = drEnergia(2)
                codPart = drEnergia(3)
                nomePart = drEnergia(4)
                dtVenc = drEnergia(5)
                consumo = drEnergia(6)
                participante = codPart & " - " & nomePart

                Me.dgEnergia.Rows.Add(dtEntrada, numero, Trim(participante), dtVenc, consumo, id)
            End While

            dgEnergia.Refresh() : drEnergia.Close() : oConnBDMETROSYS.ClearPool()
            cmdEnergia.CommandText = "" : sqlEnergia.Remove(0, sqlEnergia.ToString.Length)

            'Limpa objetos da Memória...
            id = Nothing : dtEntrada = Nothing : numero = Nothing : codPart = Nothing
            nomePart = Nothing : dtVenc = Nothing : consumo = Nothing : participante = Nothing

        Catch ex As Exception
            MsgBox("ERRO no SELECT da ENERGIA:: " & ex.Message, MsgBoxStyle.Critical)

        End Try

        oConnBDMETROSYS.Close() : cmdEnergia = Nothing : sqlEnergia = Nothing : Me.dgEnergia.Focus()
        oConnBDMETROSYS = Nothing



    End Sub

    Public Sub buscaNFHoje()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try



        Dim sqlEnergia As New StringBuilder
        Dim cmdEnergia As NpgsqlCommand
        Dim drEnergia As NpgsqlDataReader

        Try
            sqlEnergia.Append("SELECT en_id, to_char(en_dtentrada, 'dd/MM/yyyy'), en_numero, en_cliente, ")
            sqlEnergia.Append("SUBSTR(cad.p_portad, 1, 60), to_char(en_vencto, 'dd/MM/yyyy'), en_consumo ")
            sqlEnergia.Append("FROM " & MdlEmpresaUsu._esqEstab & ".servenergia ")
            sqlEnergia.Append("LEFT JOIN cadp001 cad ON cad.p_cod = en_cliente WHERE en_dtentrada = CURRENT_DATE ORDER BY en_dtentrada DESC ")
            cmdEnergia = New NpgsqlCommand(sqlEnergia.ToString, oConnBDMETROSYS)
            drEnergia = cmdEnergia.ExecuteReader

            Me.dgEnergia.Rows.Clear()
            Dim id, dtEntrada, numero, codPart, nomePart, dtVenc, consumo, participante As String

            While drEnergia.Read
                id = drEnergia(0) \ 1
                dtEntrada = drEnergia(1)
                numero = drEnergia(2)
                codPart = drEnergia(3)
                nomePart = drEnergia(4)
                dtVenc = drEnergia(5)
                consumo = drEnergia(6)
                participante = codPart & " - " & nomePart

                Me.dgEnergia.Rows.Add(dtEntrada, numero, Trim(participante), dtVenc, consumo, id)
            End While


            dgEnergia.Refresh() : drEnergia.Close() : oConnBDMETROSYS.ClearPool()
            cmdEnergia.CommandText = "" : sqlEnergia.Remove(0, sqlEnergia.ToString.Length)

            'Limpa objetos da Memória...
            id = Nothing : dtEntrada = Nothing : numero = Nothing : codPart = Nothing : nomePart = Nothing
            dtVenc = Nothing : consumo = Nothing : participante = Nothing


        Catch ex As Exception
            MsgBox("ERRO no SELECT da ENERGIA:: " & ex.Message, MsgBoxStyle.Critical)

        End Try

        oConnBDMETROSYS.Close() : cmdEnergia = Nothing : sqlEnergia = Nothing : Me.dgEnergia.Focus()
        oConnBDMETROSYS = Nothing



    End Sub

    Public Sub buscaNFPersonalizado()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try



        Dim sqlEnergia As New StringBuilder
        Dim cmdEnergia As NpgsqlCommand
        Dim drEnergia As NpgsqlDataReader

        Try
            sqlEnergia.Append("SELECT en_id, to_char(en_dtentrada, 'dd/MM/yyyy'), en_numero, en_cliente, ")
            sqlEnergia.Append("SUBSTR(cad.p_portad, 1, 60), to_char(en_vencto, 'dd/MM/yyyy'), en_consumo ")
            sqlEnergia.Append("FROM " & MdlEmpresaUsu._esqEstab & ".servenergia ")
            sqlEnergia.Append("LEFT JOIN cadp001 cad ON cad.p_cod = en_cliente WHERE en_dtentrada BETWEEN '")
            sqlEnergia.Append(Me.msk_dtInicio.Text & "' AND '" & Me.msk_dtFim.Text & "' ORDER BY en_dtentrada ASC ")
            cmdEnergia = New NpgsqlCommand(sqlEnergia.ToString, oConnBDMETROSYS)
            drEnergia = cmdEnergia.ExecuteReader

            Me.dgEnergia.Rows.Clear()
            Dim id, dtEntrada, numero, codPart, nomePart, dtVenc, consumo, participante As String

            While drEnergia.Read
                id = drEnergia(0) \ 1
                dtEntrada = drEnergia(1)
                numero = drEnergia(2)
                codPart = drEnergia(3)
                nomePart = drEnergia(4)
                dtVenc = drEnergia(5)
                consumo = drEnergia(6)
                participante = codPart & " - " & nomePart

                Me.dgEnergia.Rows.Add(dtEntrada, numero, Trim(participante), dtVenc, consumo, id)
            End While


            dgEnergia.Refresh() : drEnergia.Close() : oConnBDMETROSYS.ClearPool()
            cmdEnergia.CommandText = "" : sqlEnergia.Remove(0, sqlEnergia.ToString.Length)

            'Limpa objetos da Memória...
            id = Nothing : dtEntrada = Nothing : numero = Nothing : codPart = Nothing : nomePart = Nothing
            dtVenc = Nothing : consumo = Nothing : participante = Nothing

        Catch ex As Exception
            MsgBox("ERRO no SELECT da ENERGIA:: " & ex.Message, MsgBoxStyle.Critical)

        End Try


        oConnBDMETROSYS.Close() : cmdEnergia = Nothing : sqlEnergia = Nothing : Me.dgEnergia.Focus()
        oConnBDMETROSYS = Nothing



    End Sub

    Public Sub buscaNFUltimoMes()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try



        Dim sqlEnergia As New StringBuilder
        Dim cmdEnergia As NpgsqlCommand
        Dim drEnergia As NpgsqlDataReader


        Try
            sqlEnergia.Append("SELECT en_id, to_char(en_dtentrada, 'dd/MM/yyyy'), en_numero, en_cliente, ")
            sqlEnergia.Append("SUBSTR(cad.p_portad, 1, 60), to_char(en_vencto, 'dd/MM/yyyy'), en_consumo ")
            sqlEnergia.Append("FROM " & MdlEmpresaUsu._esqEstab & ".servenergia ")
            sqlEnergia.Append("LEFT JOIN cadp001 cad ON cad.p_cod = en_cliente WHERE en_dtentrada BETWEEN ")
            sqlEnergia.Append("date_trunc('month',CURRENT_DATE - INTERVAL '1 month')::date AND CURRENT_DATE ")
            sqlEnergia.Append("ORDER BY en_dtentrada ASC ")
            cmdEnergia = New NpgsqlCommand(sqlEnergia.ToString, oConnBDMETROSYS)
            drEnergia = cmdEnergia.ExecuteReader

            Me.dgEnergia.Rows.Clear()
            Dim id, dtEntrada, numero, codPart, nomePart, dtVenc, consumo, participante As String

            While drEnergia.Read
                id = drEnergia(0) \ 1
                dtEntrada = drEnergia(1)
                numero = drEnergia(2)
                codPart = drEnergia(3)
                nomePart = drEnergia(4)
                dtVenc = drEnergia(5)
                consumo = drEnergia(6)
                participante = codPart & " - " & nomePart

                Me.dgEnergia.Rows.Add(dtEntrada, numero, Trim(participante), dtVenc, consumo, id)
            End While


            dgEnergia.Refresh() : drEnergia.Close() : oConnBDMETROSYS.ClearPool()
            cmdEnergia.CommandText = "" : sqlEnergia.Remove(0, sqlEnergia.ToString.Length)

            'Limpa objetos da Memória...
            id = Nothing : dtEntrada = Nothing : numero = Nothing : codPart = Nothing : nomePart = Nothing
            dtVenc = Nothing : consumo = Nothing : participante = Nothing

        Catch ex As Exception
            MsgBox("ERRO no SELECT da ENERGIA:: " & ex.Message, MsgBoxStyle.Critical)

        End Try

        oConnBDMETROSYS.Close() : cmdEnergia = Nothing : sqlEnergia = Nothing : Me.dgEnergia.Focus()
        oConnBDMETROSYS = Nothing



    End Sub

    Public Sub buscaNFUltimoAno()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try



        Dim sqlEnergia As New StringBuilder
        Dim cmdEnergia As NpgsqlCommand
        Dim drEnergia As NpgsqlDataReader


        Try
            sqlEnergia.Append("SELECT en_id, to_char(en_dtentrada, 'DD/MM/YYYY'), en_numero, en_cliente, ")
            sqlEnergia.Append("SUBSTR(cad.p_portad, 1, 60), to_char(en_vencto, 'DD/MM/YYYY'), en_consumo ")
            sqlEnergia.Append("FROM " & MdlEmpresaUsu._esqEstab & ".servenergia ")
            sqlEnergia.Append("LEFT JOIN cadp001 cad ON cad.p_cod = en_cliente WHERE en_dtentrada BETWEEN ")
            sqlEnergia.Append("date_trunc('year',CURRENT_DATE - INTERVAL '1 year')::date AND CURRENT_DATE ")
            sqlEnergia.Append("ORDER BY en_dtentrada ASC ")
            cmdEnergia = New NpgsqlCommand(sqlEnergia.ToString, oConnBDMETROSYS)
            drEnergia = cmdEnergia.ExecuteReader

            Me.dgEnergia.Rows.Clear()
            Dim id, dtEntrada, numero, codPart, nomePart, dtVenc, consumo, participante As String

            While drEnergia.Read
                id = drEnergia(0) \ 1
                dtEntrada = drEnergia(1)
                numero = drEnergia(2)
                codPart = drEnergia(3)
                nomePart = drEnergia(4)
                dtVenc = drEnergia(5)
                consumo = drEnergia(6)
                participante = codPart & " - " & nomePart

                Me.dgEnergia.Rows.Add(dtEntrada, numero, Trim(participante), dtVenc, consumo, id)
            End While


            dgEnergia.Refresh() : drEnergia.Close() : oConnBDMETROSYS.ClearPool()
            cmdEnergia.CommandText = "" : sqlEnergia.Remove(0, sqlEnergia.ToString.Length)

            'Limpa objetos da Memória...
            id = Nothing : dtEntrada = Nothing : numero = Nothing : codPart = Nothing : nomePart = Nothing
            dtVenc = Nothing : consumo = Nothing : participante = Nothing

        Catch ex As Exception
            MsgBox("ERRO no SELECT da ENERGIA:: " & ex.Message, MsgBoxStyle.Critical)

        End Try


        oConnBDMETROSYS.Close() : cmdEnergia = Nothing : sqlEnergia = Nothing : Me.dgEnergia.Focus()
        oConnBDMETROSYS = Nothing



    End Sub

    Private Sub btn_exclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exclui.Click

        Me.excluirNfEnergia()

    End Sub

    Private Sub btn_atualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_atualiza.Click

        Me.atualizaDgEnergia()

    End Sub

    Private Sub excluirNfEnergia()

        If MessageBox.Show("Deseja realmente Excluir a Nota de Energia Selecionada?", "Genov", _
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim id As String = Me.dgEnergia.CurrentRow.Cells(5).Value.ToString
            Dim funcoesBD As New Cl_bdMetrosys
            funcoesBD.deleteServErnegia(id, MdlConexaoBD.conectionPadrao)
            funcoesBD.deleteServEnerglanca(id, MdlConexaoBD.conectionPadrao)
            funcoesBD = Nothing : atualizaDgEnergia()

        End If



    End Sub

    Private Sub cbo_consulta_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_consulta.SelectedValueChanged

        Me.executaConsulta()

    End Sub

    Public Sub executaConsulta()

        If cbo_consulta.SelectedIndex >= 0 Then
            Select Case cbo_consulta.SelectedIndex
                Case 0 'As últimas 10 Notas
                    Me.msk_dtInicio.Enabled = False : Me.msk_dtFim.Enabled = False
                    Me.msk_dtInicio.Text = "" : Me.msk_dtFim.Text = ""
                    Me.busca10ultimasNotas() : Me.dgEnergia.Focus()

                Case 1 'Notas da data atual
                    Me.msk_dtInicio.Enabled = False : Me.msk_dtFim.Enabled = False
                    Me.msk_dtInicio.Text = "" : Me.msk_dtFim.Text = ""
                    Me.buscaNFHoje() : Me.dgEnergia.Focus()

                Case 2 'Notas apartir do ultimo mes
                    Me.msk_dtInicio.Enabled = False : Me.msk_dtFim.Enabled = False
                    Me.msk_dtInicio.Text = "" : Me.msk_dtFim.Text = ""
                    Me.buscaNFUltimoMes() : Me.dgEnergia.Focus()

                Case 3 'Notas apartir do ultimo ano
                    Me.msk_dtInicio.Enabled = False : Me.msk_dtFim.Enabled = False
                    Me.msk_dtInicio.Text = "" : Me.msk_dtFim.Text = ""
                    Me.buscaNFUltimoAno() : Me.dgEnergia.Focus()

                Case 4 'data personalizada
                    Me.msk_dtInicio.Enabled = True : Me.msk_dtFim.Enabled = True
                    Me.msk_dtInicio.Focus() : Me.msk_dtInicio.SelectAll()

                    'valida as datas
                    If IsDate(Me.msk_dtInicio.Text) AndAlso IsDate(Me.msk_dtFim.Text) Then
                        Me.buscaNFPersonalizado()
                        If Me.dgEnergia.RowCount >= 1 Then Me.dgEnergia.Focus()

                    End If

            End Select

        End If



    End Sub

    Private Sub msk_dtFim_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_dtFim.KeyDown

        If e.KeyCode = Keys.Enter Then

            If Trim(Me.msk_dtInicio.Text).Length = 10 AndAlso Trim(Me.msk_dtFim.Text).Length = 10 Then


                If IsDate(Me.msk_dtInicio.Text) AndAlso IsDate(Me.msk_dtFim.Text) Then
                    Me.buscaNFPersonalizado()

                ElseIf Not IsDate(Me.msk_dtInicio.Text) Then
                    Me.msk_dtInicio.BackColor = Color.Red : Me.msk_dtInicio.Focus() : Me.msk_dtInicio.SelectAll()
                    MsgBox("Intervalo de data inicial inválida", MsgBoxStyle.Exclamation) : Return

                ElseIf Not IsDate(Me.msk_dtFim.Text) Then
                    Me.msk_dtFim.BackColor = Color.Red : Me.msk_dtFim.Focus() : Me.msk_dtFim.SelectAll()
                    MsgBox("Intervalo de data final inválida", MsgBoxStyle.Exclamation) : Return

                End If
            End If


            If IsDate(Me.msk_dtFim.Text) AndAlso IsDate(Me.msk_dtInicio.Text) AndAlso _
            (Me.dgEnergia.RowCount >= 1) Then
                Me.dgEnergia.Focus()

            End If
        End If



    End Sub

    Private Sub msk_dtInicio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_dtInicio.KeyDown

        If e.KeyCode = Keys.Enter Then

            If (Trim(Me.msk_dtInicio.Text).Length = 10) AndAlso (Trim(Me.msk_dtFim.Text).Length = 10) Then


                If IsDate(Me.msk_dtInicio.Text) AndAlso IsDate(Me.msk_dtFim.Text) Then
                    Me.buscaNFPersonalizado()

                ElseIf Not IsDate(Me.msk_dtInicio.Text) Then
                    Me.msk_dtInicio.BackColor = Color.Red : Me.msk_dtInicio.Focus() : Me.msk_dtInicio.SelectAll()
                    MsgBox("Intervalo de data inicial inválida", MsgBoxStyle.Exclamation) : Return

                ElseIf Not IsDate(Me.msk_dtFim.Text) Then
                    Me.msk_dtFim.BackColor = Color.Red : Me.msk_dtFim.Focus() : Me.msk_dtFim.SelectAll()
                    MsgBox("Intervalo de data final inválida", MsgBoxStyle.Exclamation) : Return

                End If
            End If

            Me.msk_dtFim.Focus() : Me.msk_dtFim.SelectAll()


            If IsDate(Me.msk_dtFim.Text) AndAlso IsDate(Me.msk_dtInicio.Text) AndAlso _
            (Me.dgEnergia.RowCount >= 1) Then
                Me.dgEnergia.Focus()

            End If
        End If



    End Sub

    Private Sub msk_dtInicio_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_dtInicio.KeyUp, msk_dtFim.KeyUp

        Me.msk_dtInicio.BackColor = Color.White : Me.msk_dtFim.BackColor = Color.White

    End Sub

    Private Sub dgEnergia_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles dgEnergia.SortCompare

        Dim DataValida As DateTime
        'VERIFICA SE COLUNA É DO TIPO DATA PARA FAZER A COMPARAÇÃO
        'CASO A COLUNA NÃO SEJA UMA DATA VALIDA COMPARA STRING
        If DateTime.TryParse(e.CellValue1, DataValida) = False Then

            e.SortResult = System.String.Compare(e.CellValue2, e.CellValue1)

        Else


            If DateTime.TryParse(e.CellValue1, DataValida) = False Then

                e.SortResult = -1

            Else
                e.SortResult = System.DateTime.Compare(CType(e.CellValue2, _
                Date), CType(e.CellValue1, Date))

            End If
        End If



        e.Handled = True
    End Sub

End Class