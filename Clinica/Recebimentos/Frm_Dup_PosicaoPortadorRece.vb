Imports System
Imports System.Data
Imports System.Text
Imports System.Math
Imports Npgsql
Imports System.IO
Imports System.Drawing.Printing

Public Class Frm_Dup_PosicaoPortadorRece

    Private Const _valorZERO As Integer = 0
    Private Mlojas As String
    Public Shared _frmRef As New Frm_Dup_PosicaoPortadorRece
    Dim _BuscaCli As New Frm_ClienteFornResp
    Private _clFuncoes As New ClFuncoes

    'objetos para impressão
    Dim _StringToPrint As String = "", _stringToPrintAux As String = ""
    Private _PrintFont As New Font("Lucida Console", 8) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _sImpressao As StreamWriter
    Private _leitorTabelaImprimir As NpgsqlDataReader
    Dim MostrarCaixaImpressoras As Boolean = False


    Private Sub Frm_Dup_PosicaoPortador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                executaF5()

        End Select



    End Sub

    Private Sub Frm_Dup_PosicaoPortador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")

        End If


    End Sub

    Private Sub executaF5()

        If txt_codPart.Text = "" Then

            MessageBox.Show("Digite Codigo de Cliente/Portador !", "Posição p/ Portador ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_codPart.Focus()

        ElseIf cbo_opcoes.SelectedIndex = -1 Then

            MessageBox.Show("Selecione uma opção p/ Pesquisa !", "Posição p/ Portador ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cbo_opcoes.Focus()

        ElseIf cbo_opcoes.SelectedIndex >= 0 Then

            consultaBD(txt_codPart.Text, Me.cbo_opcoes.SelectedIndex)

        End If



    End Sub

    Private Sub btn_pesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pesquisa.Click

        executaF5()

    End Sub

    Private Function somaVlrTotalDuplicGrid() As Double

        Dim mVlrTotalItens As Double = _valorZERO
        For Each row As DataGridViewRow In Me.dtg_posicaoport.Rows

            If Not row.IsNewRow Then mVlrTotalItens += row.Cells(9).Value

        Next



        mVlrTotalItens = Round(mVlrTotalItens, 2)
        Return mVlrTotalItens
    End Function

    Function tratamentoData() As String
        Dim resultado As String = ""


        'Tratamento do período de Incio e Fim:
        If rdb_emiss.Checked Then

            If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                resultado = "AND f_emiss BETWEEN '" & Me.Msk_inicio.Text & "' "
                resultado += "AND '" & Me.msk_fim.Text & "' "

            End If
        ElseIf rdb_pagamento.Checked Then

            If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                resultado = "AND f_dtpaga BETWEEN '" & Me.Msk_inicio.Text & "' "
                resultado = "AND '" & Me.msk_fim.Text & "' "

            End If

        ElseIf rdb_vencimento.Checked Then

            If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                resultado = "AND f_vencto BETWEEN '" & Me.Msk_inicio.Text & "' "
                resultado = "AND '" & Me.msk_fim.Text & "' "

            End If
        End If

        Return resultado
    End Function

    Function tratamentoDataAlias() As String
        Dim resultado As String = ""


        'Tratamento do período de Incio e Fim:
        If rdb_emiss.Checked Then

            If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                resultado = "AND Ft.f_emiss BETWEEN '" & Me.Msk_inicio.Text & "' "
                resultado += "AND '" & Me.msk_fim.Text & "' "

            End If
        ElseIf rdb_pagamento.Checked Then

            If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                resultado = "AND Ft.f_dtpaga BETWEEN '" & Me.Msk_inicio.Text & "' "
                resultado += "AND '" & Me.msk_fim.Text & "' "

            End If

        ElseIf rdb_vencimento.Checked Then

            If IsDate(Msk_inicio.Text) AndAlso IsDate(msk_fim.Text) Then
                resultado = "AND Ft.f_vencto BETWEEN '" & Me.Msk_inicio.Text & "' "
                resultado += "AND '" & Me.msk_fim.Text & "' "

            End If
        End If

        Return resultado
    End Function

    Private Sub consultaBD(ByVal CodPort As String, ByVal IndiceX As Integer)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlPart As New StringBuilder
        Dim daPart As NpgsqlDataAdapter
        Dim cmdPart As NpgsqlCommand
        Dim dtPart As New DataTable

        Dim cmdTot As StringBuilder = New StringBuilder    '
        Dim daTot As New NpgsqlDataAdapter '
        Dim drTot As NpgsqlDataReader
        Dim DsTot As DataSet = New DataSet   '

        Try
            '9 dgGrid
            '  0 - Em Aberto 1 - Quitados 2 - Devolvidos 3 - Todos 4 - Vencidos

            Select Case IndiceX

                Case 0
                    sqlPart.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlPart.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    sqlPart.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'N' AND f_geno = '" & Mlojas & "' ") '
                    sqlPart.Append(tratamentoData())

                    'cmdTot.Append("SELECT sum(f_valor) FROM fatd001 where f_geno='G00" & Frm_Dup_ManDuplicatas.Frm_ManDuplicadas.cbo_loja.SelectedItem & "' and f_portad='" & RTrim(txt_codPart.Text) & "' and f_sit='N' or f_sit='D' ")

                Case 1
                    sqlPart.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlPart.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    sqlPart.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_geno = '" & Mlojas & "' AND f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'L' ") '
                    sqlPart.Append(tratamentoData())

                Case 2
                    sqlPart.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlPart.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    sqlPart.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_geno = '" & Mlojas & "' AND f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'D' ") '
                    sqlPart.Append(tratamentoData())

                    'cmdTot.Append("SELECT sum(f_valor) FROM fatd001 where  f_geno='G00" & Frm_Dup_ManDuplicatas.Frm_ManDuplicadas.cbo_loja.SelectedItem & "' and  f_portad='" & RTrim(txt_codPart.Text) & "' and f_sit='N' or f_sit='D'")

                Case 3
                    sqlPart.Append("SELECT Ft.f_geno AS ""Loja"", Ft.f_tipo AS ""TP"", Ft.f_sit AS ""SIT"", ") '2
                    sqlPart.Append("Ft.f_banco AS ""Banco"", Ft.f_duplic AS ""Documento"", Ft.f_emiss AS ""DtEmissão"", ") '5
                    sqlPart.Append("Ft.f_vencto AS ""DtVencto"", Ft.f_dtpaga AS ""DtPaga"", Ft.f_juros AS ""Juros R$"", ") '8
                    sqlPart.Append("Ft.f_valor AS ""Valor R$"", Pc.f_valor AS ""Parcial R$"", Pc.f_dtpaga AS ""DtPaga "" ") '10
                    sqlPart.Append("FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft LEFT OUTER JOIN ")
                    sqlPart.Append(MdlEmpresaUsu._esqEstab & ".fatdp02 Pc ON ft.f_duplic = Pc.f_duplic WHERE ")
                    sqlPart.Append("Ft.f_geno = '" & Mlojas & "' AND Ft.f_portad = '" & Trim(Me.txt_codPart.Text) & "' ")
                    sqlPart.Append(tratamentoDataAlias())

                    cmdTot.Append("SELECT sum(f_valor) FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 where f_geno='G00" & Frm_Dup_ManDuplicatas.Frm_ManDuplicadas.cbo_loja.SelectedItem & "' and f_portad='" & RTrim(txt_codPart.Text) & "' and f_sit='N' or f_sit='D'")


                    Dim cmdSq As NpgsqlCommand = New NpgsqlCommand(cmdTot.ToString, oConnBDGENOV)
                    cmdSq.CommandText = cmdTot.ToString
                    Dim DtTot As DataTable = New DataTable

                    Try
                        DtTot.Load(cmdSq.ExecuteReader())
                        drTot = cmdSq.ExecuteReader()

                        While (drTot.Read())

                            Try
                                Me.lbl_totais.Text = Format(CDbl(drTot(0)), "##,##0.00")

                            Catch ex As Exception
                                Me.lbl_totais.Text = "0,00"
                            End Try
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message.ToString)
                    End Try
                    cmdSq = Nothing : DtTot = Nothing

                Case 4
                    sqlPart.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlPart.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    sqlPart.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_geno = '" & Mlojas & "' AND f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'N' AND f_vencto < CURRENT_DATE ") '
                    sqlPart.Append(tratamentoData())

                Case 5
                    sqlPart.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlPart.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    sqlPart.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_geno = '" & Mlojas & "' AND f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'E' ") '
                    sqlPart.Append(tratamentoData())

            End Select

            If cbo_tipo.SelectedIndex > 0 Then
                sqlPart.Append("AND Ft.f_tipo = '" & Mid(cbo_tipo.SelectedItem.ToString, 1, 2) & "' ")
            End If

            sqlPart.Append("ORDER BY Ft.f_emiss")

            cmdPart = New NpgsqlCommand(sqlPart.ToString, oConnBDGENOV)
            daPart = New NpgsqlDataAdapter(sqlPart.ToString, oConnBDGENOV)
            daTot = New NpgsqlDataAdapter(cmdTot.ToString, oConnBDGENOV) '

            dtPart = New DataTable : daPart.Fill(dtPart)

            Me.dtg_posicaoport.AlternatingRowsDefaultCellStyle.BackColor = Color.MediumAquamarine
            Me.dtg_posicaoport.DataSource = dtPart
            Me.dtg_posicaoport.Columns(_valorZERO).Visible = True 'Codigo


            Me.dtg_posicaoport.Columns(_valorZERO).Width = 50 'Loja
            Me.dtg_posicaoport.Columns(1).Width = 35  'Tipo
            Me.dtg_posicaoport.Columns(2).Width = 25  'Sit
            Me.dtg_posicaoport.Columns(3).Width = 40  'Banco
            Me.dtg_posicaoport.Columns(4).Width = 79  'documento
            Me.dtg_posicaoport.Columns(5).Width = 78  'dtemissao
            Me.dtg_posicaoport.Columns(6).Width = 79  'dtvencimento
            Me.dtg_posicaoport.Columns(7).Width = 78  'dtpaga
            Me.dtg_posicaoport.Columns(8).Width = 95 'Juros
            Me.dtg_posicaoport.Columns(8).DefaultCellStyle.Format = "###,##0.00"
            Me.dtg_posicaoport.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dtg_posicaoport.Columns(9).Width = 95 'total
            Me.dtg_posicaoport.Columns(9).DefaultCellStyle.Format = "###,##0.00"
            Me.dtg_posicaoport.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            If IndiceX = 3 Then
                Me.dtg_posicaoport.Columns(10).Width = 95 'total
                Me.dtg_posicaoport.Columns(10).DefaultCellStyle.Format = "###,##0.00"
                Me.dtg_posicaoport.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

            lbl_totais.Text = "0,00"
            If Me.cbo_opcoes.SelectedIndex <> 3 Then
                lbl_totais.Text = Format(somaVlrTotalDuplicGrid(), "###,##0.00")
            End If

            cmdPart.CommandText = ""
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        sqlPart.Remove(_valorZERO, sqlPart.ToString.Length)

        'LIMPA OBJETOS DA MEMÓRIA...
        daPart = Nothing : cmdPart = Nothing : sqlPart = Nothing : dtPart = Nothing
        cmdTot = Nothing : daTot = Nothing : drTot = Nothing : DsTot = Nothing
        Me.dtg_posicaoport.Focus() : oConnBDGENOV.Close() : oConnBDGENOV = Nothing



    End Sub

    Private Sub cbo_opcoes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_opcoes.GotFocus

        If Not cbo_opcoes.DroppedDown Then cbo_opcoes.DroppedDown = True

    End Sub

    Private Sub cbo_opcoes_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_opcoes.Leave

        Me.lbl_totais.Text = "0,00"

    End Sub

    Public Function trazCliente(ByVal codCli As String) As Boolean

        Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        Dim pesquisa As String = codCli.ToUpper

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        Dim codigo, nome, cpf_cnpj, inscricao, UF As String
        codigo = "" : nome = "" : cpf_cnpj = "" : inscricao = "" : UF = ""

        Try
            SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc,p_uf FROM cadp001 WHERE ") ' 5
            SqlParticipante.Append("p_cod = '" & pesquisa & "' ORDER BY p_portad ASC")
            CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDMETROSYS)
            drParticipante = CmdParticipante.ExecuteReader

            If drParticipante.HasRows = False Then
                Return False
            Else

                While drParticipante.Read

                    codigo = drParticipante(_valorZERO).ToString
                    nome = drParticipante(1).ToString
                End While
                Me.txt_nomePart.Text = nome : drParticipante.Close()
            End If

        Catch ex As Exception
        End Try

        CmdParticipante.CommandText = ""
        SqlParticipante.Remove(_valorZERO, SqlParticipante.ToString.Length)

        'LIMPA OBJETOS DA MEMORIA...
        codigo = Nothing : nome = Nothing : cpf_cnpj = Nothing : inscricao = Nothing : UF = Nothing
        oConnBDMETROSYS.Close() : oConnBDMETROSYS = Nothing
        CmdParticipante = Nothing : SqlParticipante = Nothing


        Return True
    End Function

    Private Sub txt_cdport_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown


        If Not Me.txt_codPart.Text.Equals("") Then
            If Me.txt_codPart.TextLength > 5 AndAlso e.KeyCode = Keys.Enter Then 'Se retornar nada
                If trazCliente(Me.txt_codPart.Text) Then

                    Dim lShouldReturn As Boolean
                    Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing

                End If
            End If
        End If

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            If Me.txt_codPart.Text.Equals("") Then
                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    _frmRef = Me : _BuscaCli.set_frmRef(Me) : _BuscaCli.ShowDialog(Me)
                    If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus()

                    Dim lShouldReturn As Boolean
                    Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing

                Catch ex As Exception
                End Try

            End If
        End If



    End Sub

    Private Sub Frm_Dup_PosicaoPortador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        lbl_NomeSys.Text = Application.ProductName
        If Frm_Dup_ManDuplicatas.Frm_ManDuplicadas._loja00.Equals("") Then

            Mlojas = MdlEmpresaUsu._codigo
        Else
            Mlojas = "G00" & Frm_Dup_ManDuplicatas.Frm_ManDuplicadas._loja00
        End If

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler PrintDocument1.BeginPrint, AddressOf InicializaRelatorio
    End Sub

    Private Sub btn_relatorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_relatorio.Click

        executaF6()

    End Sub

    Private Sub executaF6()

        If (Me.dtg_posicaoport.Rows.Count > _valorZERO) Then

            executaRelatorio("", "\wged\relatorios\consultaPosiPort.txt")
        End If


    End Sub

    Private Sub executaRelatorio(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\tmp\TEMPconsultaPosiPort.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Truncate, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\wged\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        Dim s As New StreamWriter(fs)
        _PrintFont = New Font("Lucida Console", 10)
        Dim strLinha As String = ""


        'titulo
        Try
            'vbCrLf, vbCr, vbLf, vbNewLine = quebra de linha
            s.Write(vbNewLine & vbNewLine)
            '8 caracteres
            If cbo_opcoes.SelectedIndex = 3 Then

                strLinha = _clFuncoes.Centraliza_Str("POSIÇÃO POR PORTADOR (" & cbo_opcoes.SelectedItem & ")", 106)
            Else

                strLinha = _clFuncoes.Centraliza_Str("POSIÇÃO POR PORTADOR (" & cbo_opcoes.SelectedItem & ")", 85)
            End If

            s.WriteLine(strLinha & vbNewLine)

            's.WriteLine(_clFuncoes.Exibe_Str(Me.txt_nomePart.Text, 100))

        Catch ex As Exception
        End Try

        Try
            'Cliente
            GravCabecalhoCliente(s, Me.txt_codPart.Text)
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

        'Duplicadas
        gravaDuplicadas(s)


        'Deleta o arquivo temporário...
        s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        s.Dispose()
        File.Delete(mArqTemp)

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo()

        _StringToPrint = ""
    End Sub

    Private Sub GravCabecalhoCliente(ByVal s As StreamWriter, ByVal codCliente As String)

        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlClient As New StringBuilder
            Dim cmdClient As NpgsqlCommand
            Dim drClient As NpgsqlDataReader

            'Traz dados do CLIENTE do Pedido...
            sqlClient.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
            sqlClient.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codCliente & "'")

            cmdClient = New NpgsqlCommand(sqlClient.ToString, oConnBDGENOV)
            drClient = cmdClient.ExecuteReader

            Dim nomeClient, cnpjCliente, cpfCliente, enderecoCli, ufClient, cidClient, bairroClient As String
            Dim foneClient, faxClient, celularCliente, nomeFantasCli, inscrCliente As String

            nomeClient = "" : cnpjCliente = "" : cpfCliente = "" : enderecoCli = "" : ufClient = "" : cidClient = ""
            bairroClient = "" : foneClient = "" : faxClient = "" : celularCliente = "" : nomeFantasCli = ""
            inscrCliente = ""

            While drClient.Read

                nomeClient = drClient(_valorZERO).ToString : cnpjCliente = drClient(1).ToString
                cpfCliente = drClient(2).ToString : enderecoCli = drClient(3).ToString
                cidClient = drClient(4).ToString : ufClient = drClient(5).ToString
                bairroClient = drClient(6).ToString : foneClient = drClient(7).ToString
                faxClient = drClient(8).ToString : celularCliente = drClient(9).ToString
                nomeFantasCli = drClient(10).ToString : inscrCliente = drClient(11).ToString

            End While
            drClient.Close()

            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890

            If cbo_opcoes.SelectedIndex = 3 Then

                'NOME DO CLIENTE...
                strLinha = " " & _clFuncoes.Exibe_StrEsquerda("Nome: " & nomeClient, 64) & " "
                If cnpjCliente.Equals("") Then
                    strLinha += _clFuncoes.Exibe_StrEsquerda("CPF: " & cpfCliente, 18) & " "
                Else
                    strLinha += _clFuncoes.Exibe_StrEsquerda("CNPJ: " & cnpjCliente, 18) & " "
                End If
                strLinha += _clFuncoes.Exibe_StrDireita("Emis: " & Format(Date.Now, "dd/MM/yyyy"), 20) & " "
                s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 106))

                'ENDEREÇO E BAIRRO...
                strLinha = " " & _clFuncoes.Exibe_StrEsquerda("End.: " & enderecoCli, 54) & " "
                strLinha += _clFuncoes.Exibe_StrDireita("Bairro: " & bairroClient, 49) & " "
                s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 106))

                'CIDADE E ESTADO...
                strLinha = " " & _clFuncoes.Exibe_StrEsquerda("Cidade: " & cidClient, 53) & " "
                strLinha += _clFuncoes.Exibe_StrEsquerda("UF: " & ufClient, 6) & " "
                strLinha += _clFuncoes.Exibe_StrDireita("Pg. " & "001", 43) & " " '6
                s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 106))

            Else

                'NOME DO CLIENTE...
                strLinha = " " & _clFuncoes.Exibe_StrEsquerda("Nome: " & nomeClient, 43) & " "
                If cnpjCliente.Equals("") Then
                    strLinha += _clFuncoes.Exibe_StrEsquerda("CPF: " & cpfCliente, 18) & " "
                Else
                    strLinha += _clFuncoes.Exibe_StrEsquerda("CNPJ: " & cnpjCliente, 18) & " "
                End If
                strLinha += _clFuncoes.Exibe_StrDireita("Emis: " & Format(Date.Now, "dd/MM/yyyy"), 20) & " "
                s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 85))

                'ENDEREÇO E BAIRRO...
                strLinha = " " & _clFuncoes.Exibe_StrEsquerda("End.: " & enderecoCli, 43) & " "
                strLinha += _clFuncoes.Exibe_StrDireita("Bairro: " & bairroClient, 39) & " "
                s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 85))

                'CIDADE E ESTADO...
                strLinha = " " & _clFuncoes.Exibe_StrEsquerda("Cidade: " & cidClient, 53) & " "
                strLinha += _clFuncoes.Exibe_StrEsquerda("UF: " & ufClient, 6) & " "
                strLinha += _clFuncoes.Exibe_StrDireita("Pg. " & "001", 22) & " " '6
                s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 85))
            End If



            sqlClient = Nothing : cmdClient = Nothing : drClient = Nothing
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho do Cliente:: " & ex.Message, MsgBoxStyle.Exclamation)
            Return

        End Try



    End Sub

    Private Sub gravaDuplicadasExtracted(ByVal s As StreamWriter)

        Select Case cbo_opcoes.SelectedIndex

            Case 3
                '                     1         2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("----------------------------------------------------------------------------------------------------------")
                s.WriteLine("  LOJA  TP SIT BANCO DOCUMENTO  DtEmiss    DtVencto   DtPaga      Juros   ValorR$   ParcialR$  DtParcial ")
                '              xxxxx xx  x  xxxxx xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ  xxxxx xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ
                s.WriteLine("  ------------------------------------------------------------------------------------------------------")

            Case Else
                '                     1         2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("-------------------------------------------------------------------------------------")
                s.WriteLine("  LOJA  TP SIT BANCO DOCUMENTO  DtEmiss    DtVencto   DtPaga      Juros   ValorR$ ")
                '              xxxxx xx  x  xxxxx xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ  xxxxx xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ
                s.WriteLine("  --------------------------------------------------------------------------------")

        End Select


    End Sub

    Private Sub gravaDuplicadas(ByVal s As StreamWriter)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim nomeCampo As String = "", nomeCampoAux As String = "", mfone As String = ""
        Dim strLinha As String = "", mContItens As Integer = _valorZERO

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try


        Dim sqlPart As New StringBuilder
        Dim cmdPart As NpgsqlCommand
        Dim drPart As NpgsqlDataReader

        'Dim cmdTot As StringBuilder = New StringBuilder
        'Dim daTot As New NpgsqlDataAdapter
        'Dim drTot As NpgsqlDataReader
        'Dim DsTot As DataSet = New DataSet

        Dim mContPg As Integer = 1
        Dim mContRegistrosPg As Integer
        Dim mLoja, mTP, mSit, mBanco, mDocumento, mDtemiss, mDtVencto, mDtPagNormal, mJuros As String
        Dim mValor, mParcial, mDtPaga As String

        Try
            Select Case Me.cbo_opcoes.SelectedIndex

                Case 0
                    sqlPart.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlPart.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    sqlPart.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'N' AND f_geno = '" & Mlojas & "' ") '
                    sqlPart.Append(tratamentoData())

                    'cmdTot.Append("SELECT sum(f_valor) FROM fatd001 where f_geno='G00" & Frm_Dup_ManDuplicatas.Frm_ManDuplicadas.cbo_loja.SelectedItem & "' and f_portad='" & RTrim(txt_codPart.Text) & "' and f_sit='N' or f_sit='D' ")

                Case 1
                    sqlPart.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlPart.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    sqlPart.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_geno = '" & Mlojas & "' AND f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'L' ") '
                    sqlPart.Append(tratamentoData())

                Case 2
                    sqlPart.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlPart.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    sqlPart.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_geno = '" & Mlojas & "' AND f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'D' ") '
                    sqlPart.Append(tratamentoData())

                    'cmdTot.Append("SELECT sum(f_valor) FROM fatd001 where  f_geno='G00" & Frm_Dup_ManDuplicatas.Frm_ManDuplicadas.cbo_loja.SelectedItem & "' and  f_portad='" & RTrim(txt_codPart.Text) & "' and f_sit='N' or f_sit='D'")

                Case 3
                    sqlPart.Append("SELECT Ft.f_geno AS ""Loja"", Ft.f_tipo AS ""TP"", Ft.f_sit AS ""SIT"", ") '2
                    sqlPart.Append("Ft.f_banco AS ""Banco"", Ft.f_duplic AS ""Documento"", Ft.f_emiss AS ""DtEmissão"", ") '5
                    sqlPart.Append("Ft.f_vencto AS ""DtVencto"", Ft.f_dtpaga AS ""DtPaga"", Ft.f_juros AS ""Juros R$"", ") '
                    sqlPart.Append("Ft.f_valor AS ""Valor R$"", Pc.f_valor AS ""Parcial R$"", Pc.f_dtpaga AS ""DtPaga "" ")
                    sqlPart.Append("FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft LEFT OUTER JOIN ")
                    sqlPart.Append(MdlEmpresaUsu._esqEstab & ".fatdp02 Pc ON ft.f_duplic = Pc.f_duplic WHERE ")
                    sqlPart.Append("Ft.f_geno = '" & Mlojas & "' AND Ft.f_portad = '" & Trim(Me.txt_codPart.Text) & "' ")
                    sqlPart.Append(tratamentoDataAlias())

                Case 4
                    sqlPart.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlPart.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    sqlPart.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_geno = '" & Mlojas & "' AND f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'N' AND f_vencto < CURRENT_DATE ") '
                    sqlPart.Append(tratamentoData())

                Case 5
                    sqlPart.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlPart.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    sqlPart.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_geno = '" & Mlojas & "' AND f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'E' ") '
                    sqlPart.Append(tratamentoData())

            End Select


           If cbo_tipo.SelectedIndex > 0 Then
                sqlPart.Append("AND Ft.f_tipo = '" & Mid(cbo_tipo.SelectedItem.ToString, 1, 2) & "' ")
            End If

            sqlPart.Append("ORDER BY Ft.f_emiss")

            cmdPart = New NpgsqlCommand(sqlPart.ToString, oConnBDGENOV)
            drPart = cmdPart.ExecuteReader

            If drPart.HasRows = True Then

                gravaDuplicadasExtracted(s)
            End If

            While drPart.Read

                Select Case cbo_opcoes.SelectedIndex

                    Case 3
                        If (mContPg = 1) AndAlso (mContRegistrosPg = 45) Then

                            s.Write(vbNewLine & vbNewLine & vbNewLine)

                            mContPg += 1
                            Select Case cbo_opcoes.SelectedIndex

                                Case 3
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                                 Pg.: " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                                Case Else
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                   " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                            End Select

                            gravaDuplicadasExtracted(s)
                            mContRegistrosPg = 0

                        ElseIf (mContRegistrosPg = 49) Then

                            s.Write(vbNewLine & vbNewLine & vbNewLine)

                            mContPg += 1
                            Select Case cbo_opcoes.SelectedIndex

                                Case 3
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                                 Pg.: " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                                Case Else
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                   " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                            End Select

                            gravaDuplicadasExtracted(s)
                            mContRegistrosPg = 0
                        End If

                    Case Else
                        If (mContPg = 1) AndAlso (mContRegistrosPg = 66) Then

                            s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)

                            mContPg += 1
                            Select Case cbo_opcoes.SelectedIndex

                                Case 3
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                                 Pg.: " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                                Case Else
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                   " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                            End Select

                            gravaDuplicadasExtracted(s)
                            mContRegistrosPg = 0

                        ElseIf (mContRegistrosPg = 69) Then

                            s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)

                            mContPg += 1

                            Select Case cbo_opcoes.SelectedIndex

                                Case 3
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                                 Pg.: " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                                Case Else
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                   " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                            End Select

                            gravaDuplicadasExtracted(s)
                            mContRegistrosPg = 0
                        End If

                End Select

                mLoja = drPart(0).ToString
                mTP = drPart(1).ToString
                mSit = drPart(2).ToString
                mBanco = drPart(3).ToString
                mDocumento = drPart(4).ToString
                Try
                    mDtemiss = Format(Convert.ChangeType(drPart(5), GetType(Date)), "dd/MM/yyyy")
                Catch ex As Exception
                    mDtemiss = ""
                End Try

                Try
                    mDtVencto = Format(Convert.ChangeType(drPart(6), GetType(Date)), "dd/MM/yyyy")
                Catch ex As Exception
                    mDtVencto = ""
                End Try

                Try
                    mDtPagNormal = Format(Convert.ChangeType(drPart(7), GetType(Date)), "dd/MM/yyyy")
                Catch ex As Exception
                    mDtPagNormal = ""
                End Try

                mJuros = drPart(8).ToString
                mValor = Format(drPart(9), "###,##0.00")

                mParcial = "" : mDtPaga = ""
                Try

                    mParcial = Format(drPart(10), "###,##0.00")
                    Try
                        mDtPaga = Format(Convert.ChangeType(drPart(11), GetType(Date)), "dd/MM/yyyy")
                    Catch ex As Exception
                        mDtPaga = ""
                    End Try
                Catch ex As Exception
                End Try


                strLinha = "  " & _clFuncoes.Exibe_Str(mLoja, 5) & " " & _clFuncoes.Exibe_StrEsquerda(mTP, 2) & " " & _
                _clFuncoes.Exibe_StrEsquerda(" " & mSit & " ", 3) & " " & _clFuncoes.Exibe_StrEsquerda(mBanco, 5) & " " & _
                _clFuncoes.Exibe_StrEsquerda(mDocumento, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtemiss, 10) & " " & _
                _clFuncoes.Exibe_StrEsquerda(mDtVencto, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtPagNormal, 10) & "  " & _
                _clFuncoes.Exibe_StrEsquerda(mJuros, 5) & " " & _clFuncoes.Exibe_StrDireita(mValor, 10) & " " & _
                _clFuncoes.Exibe_StrDireita(mParcial, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtPaga, 10)

                s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 104))

                mContItens += 1 : mContRegistrosPg += 1
            End While
            drPart.Close()


        Catch ex As Exception
            Try
                drPart.Close()

            Catch ex01 As Exception
            End Try
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        sqlPart.Remove(_valorZERO, sqlPart.ToString.Length) : oConnBDGENOV.Close()

        'LIMPA OS OBJETOS DE MEMORIA...
        drPart = Nothing : cmdPart = Nothing : sqlPart = Nothing : drPart = Nothing
        oConnBDGENOV = Nothing


        If mContItens > _valorZERO Then

            s.WriteLine("")
            strLinha = "  TOTAIS --->     " & _clFuncoes.Exibe_StrDireita(mContItens, 3)
            If mContItens > 1 Then
                strLinha += " - Registros"
            Else
                strLinha += " - Registro"
            End If

            If cbo_opcoes.SelectedIndex <> 3 Then
                strLinha += _clFuncoes.Exibe_StrDireita(lbl_totais.Text, 49)
            End If
            s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 115))

            Select Case cbo_opcoes.SelectedIndex

                Case 3
                    '                     1         2         3         4         5         6         7         8         9         0         1         2
                    '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                    s.WriteLine("  ------------------------------------------------------------------------------------------------------")

                Case Else
                    '                     1         2         3         4         5         6         7         8         9         0         1         2
                    '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                    s.WriteLine("  --------------------------------------------------------------------------------")

            End Select

        End If



    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim NumChars As Integer
        Dim NumLines As Integer
        Dim StringforPage As String
        Dim Strformat As New StringFormat

        Dim recdraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, _
                                      e.MarginBounds.Width, e.MarginBounds.Height)
        Dim SizeMeassure As New SizeF(e.MarginBounds.Width, _
                                      e.MarginBounds.Height - _PrintFont.GetHeight(e.Graphics))

        Strformat.Trimming = StringTrimming.Word

        e.Graphics.MeasureString(_StringToPrint, _PrintFont, SizeMeassure, Strformat, NumChars, NumLines)
        StringforPage = _StringToPrint.Substring(_valorZERO, NumChars)

        ' Imprime a string na pagina atual
        e.Graphics.DrawString(StringforPage, _PrintFont, Brushes.Black, recdraw, Strformat)


        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False '_stringToPrintAux = _StringToPrint

        End If


    End Sub

    Private Sub LerOArquivoSalvo(ByVal arqSaida As String)
        'Ler o Arquivo salvo...
        Dim FilePath As String = arqSaida
        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrint = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream.Dispose() : MyfileStream = Nothing
            'File.Delete(arqSaida)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub VisuConteArqSalvo()

        Try
            ' Especifica as configurações da pagina atual
            PrintDocument1.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            PrintDocument1.DefaultPageSettings.Margins.Top = 12
            PrintDocument1.DefaultPageSettings.Margins.Right = 12
            PrintDocument1.DefaultPageSettings.Margins.Left = 10
            PrintDocument1.DefaultPageSettings.Margins.Bottom = 8

            Select Case cbo_opcoes.SelectedIndex

                Case 3
                    PrintDocument1.DefaultPageSettings.Landscape = True
                Case Else
                    PrintDocument1.DefaultPageSettings.Landscape = False
            End Select

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando RELATORIO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : _StringToPrint = "" : MostrarCaixaImpressoras = False

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub InicializaRelatorio(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintEventArgs)

        _StringToPrint = _stringToPrintAux
        If MostrarCaixaImpressoras Then

            Dim Impressora As New PrintDialog
            Impressora.AllowCurrentPage = True : Impressora.AllowSomePages = True
            If Impressora.ShowDialog() = DialogResult.Cancel Then

                Relatorio.Cancel = True

            Else

                Try

                    PrintDocument1.PrinterSettings = Impressora.PrinterSettings
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
        End If
        MostrarCaixaImpressoras = True



    End Sub

    Private Sub cbo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo.GotFocus

        If Not cbo_tipo.DroppedDown Then cbo_tipo.DroppedDown = True

    End Sub

End Class