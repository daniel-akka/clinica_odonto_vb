Imports Npgsql
Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Math
Imports System.Drawing.Printing

Public Class Frm_relatFinanPaga

    Private Const _valorZERO As Integer = 0
    Private Mlojas As String
    Public Shared _frmRef As New Frm_Dup_PosicaoPortador
    Dim _BuscaCli As New Frm_BuscaCli
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


    Private Sub Frm_relatFinanReceb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cbo_carteira = _clFuncoes.PreenchComboCarteira(Me.cbo_carteira, MdlConexaoBD.conectionPadrao)
        Me.cbo_loja = _clFuncoes.PreenchComboLoja(cbo_loja, MdlConexaoBD.conectionPadrao)
        Me.cbo_loja.SelectedIndex = _clFuncoes.trazIndexCboLoja(Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2), cbo_loja)
        Me.cbo_loja.Enabled = False
        Me.cbo_vendedor = _clFuncoes.PreenchComboVendedores(Me.cbo_vendedor, MdlConexaoBD.conectionPadrao)

        'If MdlUsuarioLogando._usuarioPrivilegio = True Then Me.cbo_loja.Enabled = True

        'cbo_tipo.SelectedIndex = _valorZERO
        'cbo_tipo.SetBounds(73, 16, 181, 24)

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler PrintDocument1.BeginPrint, AddressOf InicializaRelatorio
    End Sub

    Private Sub Frm_relatFinanReceb_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

    Private Sub pbox_impressora_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbox_impressora.MouseEnter

        pbox_impressora.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub pbox_impressora_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbox_impressora.MouseLeave

        pbox_impressora.BorderStyle = BorderStyle.None
        pbox_impressora.Refresh()
    End Sub

    Private Sub pbox_impressora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbox_impressora.Click

        executaF6()
    End Sub

    Private Sub pbox_impressora_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbox_impressora.MouseDown

        pbox_impressora.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub pbox_impressora_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbox_impressora.MouseUp

        pbox_impressora.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub cbo_loja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_loja.GotFocus

        If Not cbo_loja.DroppedDown Then cbo_loja.DroppedDown = True
    End Sub

    Private Sub cbo_opcoes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_opcoes.GotFocus

        If Not cbo_opcoes.DroppedDown Then cbo_opcoes.DroppedDown = True
    End Sub

    Private Sub cbo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo.GotFocus

        If Not cbo_tipo.DroppedDown Then cbo_tipo.DroppedDown = True
    End Sub

    Private Sub executaF6()

        executaRelatorio("", "\wged\consultaFinPag.txt")
    End Sub

    Private Sub executaRelatorio(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPconsultaFinPag.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Truncate, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        Dim s As New StreamWriter(fs)
        Dim strLinha As String = ""

        Select Case cbo_opcoes.SelectedIndex
            Case 0 Or (cbo_opcoes.SelectedIndex = 4)
                _PrintFont = New Font("Lucida Console", 9)
            Case Else
                _PrintFont = New Font("Lucida Console", 8)
        End Select

        'titulo
        Try
            'vbCrLf, vbCr, vbLf, vbNewLine = quebra de linha
            s.Write(vbNewLine & vbNewLine)
            '8 caracteres
            Select Case cbo_opcoes.SelectedIndex

                Case 0 Or (cbo_opcoes.SelectedIndex = 4)
                    strLinha = "RELATÓRIO (" & cbo_opcoes.SelectedItem & ")"
                    If cbo_opcoes.SelectedIndex = _valorZERO Then

                        strLinha += "  " & dtp_inicial.Text & " A " & dtp_final.Text
                    End If

                    strLinha = _clFuncoes.Centraliza_Str(strLinha, 134)
                    strLinha = strLinha.Substring(0, strLinha.Length - 16)
                    strLinha += "Data: " & Format(Date.Now, "dd/MM/yyyy")

                    s.WriteLine(strLinha)
                    strLinha = "" : strLinha = Mid(cbo_loja.SelectedItem, 5, cbo_loja.SelectedItem.ToString.Length)
                    strLinha = _clFuncoes.Exibe_StrEsquerda(strLinha, 101)
                    strLinha += _clFuncoes.Exibe_StrDireita("Pg. 001", 33)
                    s.WriteLine(strLinha & vbNewLine)

                Case 9
                    Dim mvendedor As String = ""
                    If cbo_vendedor.SelectedIndex >= _valorZERO Then mvendedor = cbo_vendedor.SelectedItem
                    strLinha = _clFuncoes.Centraliza_Str("RELATÓRIO (" & cbo_opcoes.SelectedItem & ")  " & mvendedor, 105)
                    strLinha = strLinha.Substring(0, strLinha.Length - 16)
                    strLinha += "Data: " & Format(Date.Now, "dd/MM/yyyy")

                    s.WriteLine(strLinha)
                    strLinha = "" : strLinha = Mid(cbo_loja.SelectedItem, 5, cbo_loja.SelectedItem.ToString.Length)
                    strLinha = _clFuncoes.Exibe_StrEsquerda(strLinha, 82)
                    strLinha += _clFuncoes.Exibe_StrDireita("Pg. 001", 23)
                    s.WriteLine(strLinha & vbNewLine)


                Case Else
                    Dim mcateira As String = ""
                    If cbo_carteira.SelectedIndex >= _valorZERO Then mcateira = cbo_carteira.SelectedItem
                    strLinha = _clFuncoes.Centraliza_Str("RELATÓRIO (" & cbo_opcoes.SelectedItem & ")  " & mcateira, 112)
                    strLinha = strLinha.Substring(0, strLinha.Length - 16)
                    strLinha += "Data: " & Format(Date.Now, "dd/MM/yyyy")

                    s.WriteLine(strLinha)
                    strLinha = "" : strLinha = Mid(cbo_loja.SelectedItem, 5, cbo_loja.SelectedItem.ToString.Length)
                    strLinha = _clFuncoes.Exibe_StrEsquerda(strLinha, 89)
                    strLinha += _clFuncoes.Exibe_StrDireita("Pg. 001", 23)
                    s.WriteLine(strLinha & vbNewLine)

            End Select


        Catch ex As Exception
        End Try

        'Financeiro
        gravaFinanceiro(s)

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

    Private Sub gravaFinanceiroExtracted(ByVal s As StreamWriter)

        Select Case cbo_opcoes.SelectedIndex

            Case 0 Or (cbo_opcoes.SelectedIndex = 4)
                '                     1         2         3         4         5         6         7         8         9         0         1         2         3         4         5
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine(" -------------------------------------------------------------------------------------------------------------------------------------")
                s.WriteLine("  Loja Portador                      TP SIT Banco Documento  DtEmiss    DtVencto   DtPaga      Juros   ValorR$   ParcialR$  DtParcial ")
                '              xxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxx xx  x  xxxxx xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ  xxxxx xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ
                s.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------------")

            Case 9
                '                     1         2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine(" ---------------------------------------------------------------------------------------------------------")
                s.WriteLine("  Loja Portador                       TP SIT Banco Documento  DtEmiss    DtVencto   DtPaga        ValorR$ ")
                '              xxxx xxxxxxxxxZxxxxxxxxxxZxxxxxxxxx xx  x  xxxxx xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ
                s.WriteLine("  -------------------------------------------------------------------------------------------------------")

            Case Else
                '                     1         2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine(" ---------------------------------------------------------------------------------------------------------------")
                s.WriteLine("  Loja Portador                       TP SIT Banco Documento  DtEmiss    DtVencto   DtPaga     Juros    ValorR$ ")
                '              xxxx xxxxxxxxxZxxxxxxxxxxZxxxxxxxxx xx  x  xxxxx xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ xxxxx xxxxxxxxxZ
                s.WriteLine("  -------------------------------------------------------------------------------------------------------------")

        End Select


    End Sub

    Private Sub gravaFinanceiro(ByVal s As StreamWriter)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim nomeCampo As String = "", nomeCampoAux As String = "", mfone As String = ""
        Dim strLinha As String = "", mContItens As Integer = _valorZERO

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try


        Dim sqlFinan As New StringBuilder
        Dim cmdFinan As NpgsqlCommand
        Dim drFinan As NpgsqlDataReader

        Dim mGeno As String = "G00" & cbo_loja.SelectedItem.ToString.Substring(0, 2)
        Dim mContPg As Integer = 1
        Dim mContRegistrosPg As Integer
        Dim mLoja, mTP, mSit, mBanco, mDocumento, mDtemiss, mDtVencto, mDtPagNormal, mJuros As String
        Dim mValor, mParcial, mDtPaga, mPortador As String

        Try


            Select Case Me.cbo_opcoes.SelectedIndex

                Case 0 'Doc. Pagos no Período

                    sqlFinan.Append("SELECT Ft.d_geno AS ""Loja"", Ft.d_tipo AS ""TP"", Ft.d_sit AS ""SIT"", ") '2
                    sqlFinan.Append("Ft.d_banco AS ""Banco"", Ft.d_duplic AS ""Documento"", Ft.d_emiss AS ""DtEmissão"", ") '5
                    sqlFinan.Append("Ft.d_vencto AS ""DtVencto"", Ft.d_dtpaga AS ""DtPaga"", Ft.d_juros AS ""Juros R$"", ") '8
                    sqlFinan.Append("Ft.d_valor AS ""Valor R$"", Pc.d_valor AS ""Parcial R$"", Pc.d_dtpaga AS ""DtPaga "", cad.p_portad AS ""Portador"" ") '12
                    sqlFinan.Append("FROM cadp001 cad, fatp001 Ft LEFT OUTER JOIN fatp002 Pc ON Pc.d_geno = '" & mGeno & "' AND ft.d_duplic = Pc.d_duplic ")
                    sqlFinan.Append("WHERE cad.p_cod = Ft.d_portad AND Ft.d_sit = 'L' AND Ft.d_dtpaga BETWEEN '" & Format(CDate(dtp_inicial.Text), "dd/MM/yyyy") & "' AND '" & Format(CDate(dtp_final.Text), "dd/MM/yyyy") & "' ")

                    If Me.cbo_tipo.SelectedIndex > _valorZERO Then

                        Dim mtipo As String = Mid(Me.cbo_tipo.SelectedItem, 1, 2)
                        sqlFinan.Append("AND Ft.d_tipo = '" & mtipo.ToUpper & "' ")
                        mtipo = Nothing
                    End If
                    sqlFinan.Append("ORDER BY Ft.d_emiss")


                    '### Documentos Liquidados e Pagos Parcialmente
                    'sqlFinan.Append("SELECT Ft.d_geno AS ""Loja"", Ft.d_tipo AS ""TP"", Ft.d_sit AS ""SIT"", ") '2
                    'sqlFinan.Append("Ft.d_banco AS ""Banco"", Ft.d_duplic AS ""Documento"", Ft.d_emiss AS ""DtEmissão"", ") '5
                    'sqlFinan.Append("Ft.d_vencto AS ""DtVencto"", Ft.d_dtpaga AS ""DtPaga"", Ft.d_juros AS ""Juros R$"", ") '8
                    'sqlFinan.Append("Ft.d_valor AS ""Valor R$"", Pc.d_valor AS ""Parcial R$"", Pc.d_dtpaga AS ""DtPaga "", cad.p_portad AS ""Portador"" ") '12
                    'sqlFinan.Append("FROM cadp001 cad, fatp001 Ft LEFT OUTER JOIN fatp002 Pc ON Pc.d_geno = '" & mGeno & "' AND ft.d_duplic = Pc.d_duplic ")
                    'sqlFinan.Append("WHERE (cad.p_cod = Ft.d_portad AND EXISTS (SELECT f2.d_duplic FROM fatp002 f2 WHERE f2.d_geno = Ft.d_geno AND f2.d_duplic = Ft.d_duplic)) OR ")
                    'sqlFinan.Append("(cad.p_cod = Ft.d_portad AND Ft.d_sit = 'L' AND Ft.d_dtpaga BETWEEN '" & Format(CDate(dtp_inicial.Text), "dd/MM/yyyy") & "' AND '" & Format(CDate(dtp_final.Text), "dd/MM/yyyy") & "' ")

                    'If Me.cbo_tipo.SelectedIndex > _valorZERO Then

                    '    Dim mtipo As String = Mid(Me.cbo_tipo.SelectedItem, 1, 2)
                    '    sqlFinan.Append("AND Ft.d_tipo = '" & mtipo.ToUpper & "' ")
                    '    mtipo = Nothing
                    'End If
                    'sqlFinan.Append(") ORDER BY Ft.d_emiss")

                Case 1 'Doc. Vencidas por Carteira
                    sqlFinan.Append("SELECT d_  geno AS ""Loja"", d_tipo AS ""TP"", d_sit AS ""SIT"", ") '2
                    sqlFinan.Append("d_banco AS ""Banco"",d_duplic AS ""Documento"", d_emiss AS ""DtEmissão"", d_vencto AS ""DtVencto"", ") '6
                    sqlFinan.Append("d_dtpaga AS ""DtPaga"", d_juros AS ""Juros R$ "", d_valor AS ""Valor R$"", cad.p_portad AS ""Portador"" ") '10
                    sqlFinan.Append("FROM fatp001 Ft LEFT JOIN cadp001 cad ON cad.p_cod = d_portad WHERE Ft.d_vencto < CURRENT_DATE AND d_sit = 'N' AND d_cartei = '" & Mid(Me.cbo_carteira.SelectedItem, 1, 2) & "' ORDER BY Ft.d_vencto ASC") '

                Case 2 'Doc. a Vencer por Período
                    sqlFinan.Append("SELECT d_geno AS ""Loja"", d_tipo AS ""TP"", d_sit AS ""SIT"", ") '2
                    sqlFinan.Append("d_banco AS ""Banco"",d_duplic AS ""Documento"", d_emiss AS ""DtEmissão"", d_vencto AS ""DtVencto"", ") '6
                    sqlFinan.Append("d_dtpaga AS ""DtPaga"", d_juros AS ""Juros R$ "", d_valor AS ""Valor R$"", cad.p_portad AS ""Portador"" ") '10
                    sqlFinan.Append("FROM fatp001 Ft LEFT JOIN cadp001 cad ON cad.p_cod = d_portad WHERE d_sit = 'N' AND Ft.d_vencto > CURRENT_DATE AND Ft.d_vencto BETWEEN '" & Format(CDate(dtp_inicial.Text), "dd/MM/yyyy") & "' AND '" & Format(CDate(dtp_final.Text), "dd/MM/yyyy") & "' ")


                Case 3 'Doc. Incluidas por Dia
                    sqlFinan.Append("SELECT Ft.d_geno AS ""Loja"", Ft.d_tipo AS ""TP"", Ft.d_sit AS ""SIT"", ") '2
                    sqlFinan.Append("Ft.d_banco AS ""Banco"", Ft.d_duplic AS ""Documento"", Ft.d_emiss AS ""DtEmissão"", ") '5
                    sqlFinan.Append("Ft.d_vencto AS ""DtVencto"", Ft.d_dtpaga AS ""DtPaga"", Ft.d_juros AS ""Juros R$"", ") '8
                    sqlFinan.Append("Ft.d_valor AS ""Valor R$"", Pc.d_valor AS ""Parcial R$"", Pc.d_dtpaga AS ""DtPaga "", cad.p_portad AS ""Portador"" ") '12
                    sqlFinan.Append("FROM cadp001 cad, fatp001 Ft LEFT OUTER JOIN ")
                    sqlFinan.Append("fatp002 Pc ON ft.d_duplic = Pc.d_duplic WHERE cad.p_cod = Ft.d_portad AND ")
                    sqlFinan.Append("Ft.d_emiss = '" & Format(Date.Now, "dd/MM/yyyy") & "' OR Ft.d_dtpaga = '" & Format(Date.Now, "dd/MM/yyyy") & "'")

                Case 4 'Dupl.Pagas - Pendente
                    sqlFinan.Append("SELECT Ft.d_geno AS ""Loja"", Ft.d_tipo AS ""TP"", Ft.d_sit AS ""SIT"", ") '2
                    sqlFinan.Append("Ft.d_banco AS ""Banco"", Ft.d_duplic AS ""Documento"", Ft.d_emiss AS ""DtEmissão"", ") '5
                    sqlFinan.Append("Ft.d_vencto AS ""DtVencto"", Ft.d_dtpaga AS ""DtPaga"", Ft.d_juros AS ""Juros R$"", ") '8
                    sqlFinan.Append("Ft.d_valor AS ""Valor R$"", Pc.d_valor AS ""Parcial R$"", Pc.d_dtpaga AS ""DtPaga "", cad.p_portad AS ""Portador"" ") '12
                    sqlFinan.Append("FROM cadp001 cad, fatp001 Ft WHERE cad.p_cod = Ft.d_portad AND d_sit = 'N' AND d_cartei = '01' AND Ft.d_dtpaga BETWEEN '" & Format(CDate(dtp_inicial.Text), "dd/MM/yyyy") & "' AND '" & Format(CDate(dtp_final.Text), "dd/MM/yyyy") & "' ")


                    If Me.cbo_tipo.SelectedIndex > _valorZERO Then

                        Dim mtipo As String = Mid(Me.cbo_tipo.SelectedItem, 1, 2)
                        sqlFinan.Append("AND Ft.d_tipo = '" & mtipo.ToUpper & "' ")
                        mtipo = Nothing
                    End If
                    sqlFinan.Append("ORDER BY Ft.d_emiss")

                Case 5 'Vencidas Alfabética
                    sqlFinan.Append("SELECT d_geno AS ""Loja"", d_tipo AS ""TP"", d_sit AS ""SIT"", ") '2
                    sqlFinan.Append("d_banco AS ""Banco"", d_duplic AS ""Documento"", d_emiss AS ""DtEmissão"", d_vencto AS ""DtVencto"", ") '6
                    sqlFinan.Append("d_dtpaga AS ""DtPaga"", d_juros AS ""Juros R$ "", d_valor AS ""Valor R$"", cad.p_portad AS ""Portador"" ") '10
                    sqlFinan.Append("FROM fatp001 Ft LEFT JOIN cadp001 cad ON cad.p_cod = d_portad WHERE d_sit = 'N' AND d_vencto < CURRENT_DATE ORDER BY d_duplic ASC")

                    'Case 6 'Gera Fatura
                    '    sqlFinan.Append("SELECT d_geno AS ""Loja"", d_tipo AS ""TP"", d_sit AS ""SIT"", ") '2
                    '    sqlFinan.Append("d_banco AS ""Banco"",d_duplic AS ""Documento"", d_emiss AS ""DtEmissão"", d_vencto AS ""DtVencto"",d_dtpaga AS ""DtPaga"", d_juros AS ""Juros R$ "", ") '5
                    '    'sqlFinan.Append("d_valor AS ""Valor R$"" FROM fatp001 Ft WHERE d_geno = '" & Mlojas & "' AND d_portad = '" & RTrim(txt_codPart.Text) & "' AND d_sit = 'N' AND d_vencto < CURRENT_DATE ") '

                    'Case 7 'Emite Bloquete
                    '    sqlFinan.Append("SELECT d_geno AS ""Loja"", d_tipo AS ""TP"", d_sit AS ""SIT"", ") '2
                    '    sqlFinan.Append("d_banco AS ""Banco"",d_duplic AS ""Documento"", d_emiss AS ""DtEmissão"", d_vencto AS ""DtVencto"",d_dtpaga AS ""DtPaga"", d_juros AS ""Juros R$ "", ") '5
                    '    'sqlFinan.Append("d_valor AS ""Valor R$"" FROM fatp001 Ft WHERE d_geno = '" & Mlojas & "' AND d_portad = '" & RTrim(txt_codPart.Text) & "' AND d_sit = 'N' AND d_vencto < CURRENT_DATE ") '

                    'Case 8 'Emite Duplicatas
                    '    sqlFinan.Append("SELECT d_geno AS ""Loja"", d_tipo AS ""TP"", d_sit AS ""SIT"", ") '2
                    '    sqlFinan.Append("d_banco AS ""Banco"",d_duplic AS ""Documento"", d_emiss AS ""DtEmissão"", d_vencto AS ""DtVencto"",d_dtpaga AS ""DtPaga"", d_juros AS ""Juros R$ "", ") '5
                    '    'sqlFinan.Append("d_valor AS ""Valor R$"" FROM fatp001 Ft WHERE d_geno = '" & Mlojas & "' AND d_portad = '" & RTrim(txt_codPart.Text) & "' AND d_sit = 'N' AND d_vencto < CURRENT_DATE ") '

                Case 9 'Vencidas por Vendedor
                    sqlFinan.Append("SELECT d_geno AS ""Loja"", d_tipo AS ""TP"", d_sit AS ""SIT"", ") '2
                    sqlFinan.Append("d_banco AS ""Banco"",d_duplic AS ""Documento"", d_emiss AS ""DtEmissão"", d_vencto AS ""DtVencto"", ") '6
                    sqlFinan.Append("d_dtpaga AS ""DtPaga"", d_juros AS ""Juros R$ "", d_valor AS ""Valor R$"", cad.p_portad AS ""Portador"" ") '10
                    sqlFinan.Append("FROM fatp001 Ft LEFT JOIN cadp001 cad ON cad.p_cod = d_portad WHERE d_sit = 'N' AND d_vencto < CURRENT_DATE AND d_vend = '" & Mid(cbo_vendedor.SelectedItem, 1, 6) & "' ORDER BY cad.p_portad ASC")

                Case 10 'Comissao por Vendedor


            End Select


            'Select Case cbo_tipo.SelectedIndex

            '    Case 1 'CH - Cheque
            '        sqlFinan.Append("AND Ft.d_tipo = 'CH' ")

            '    Case 2 'BL - Boleto
            '        sqlFinan.Append("AND Ft.d_tipo = 'BL' ")

            '    Case 3 'NP - N.Promissoria
            '        sqlFinan.Append("AND Ft.d_tipo = 'NP' ")

            '    Case 4 'CR - Carnê
            '        sqlFinan.Append("AND Ft.d_tipo = 'CR' ")

            '    Case 5 'CT - Cartão
            '        sqlFinan.Append("AND Ft.d_tipo = 'CT' ")

            'End Select

            'sqlFinan.Append("ORDER BY Ft.d_emiss")

            cmdFinan = New NpgsqlCommand(sqlFinan.ToString, oConnBDGENOV)
            drFinan = cmdFinan.ExecuteReader

            If drFinan.HasRows = True Then

                gravaFinanceiroExtracted(s)
            End If

            While drFinan.Read

                Select Case cbo_opcoes.SelectedIndex

                    Case 0 Or (cbo_opcoes.SelectedIndex = 4)
                        If (mContPg = 1) AndAlso (mContRegistrosPg = 45) Then

                            s.Write(vbNewLine & vbNewLine & vbNewLine)

                            mContPg += 1
                            Select Case cbo_opcoes.SelectedIndex

                                Case 0 Or (cbo_opcoes.SelectedIndex = 4)
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                                 Pg.: " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                                Case Else
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                   " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                            End Select

                            gravaFinanceiroExtracted(s)
                            mContRegistrosPg = 0

                        ElseIf (mContRegistrosPg = 49) Then

                            s.Write(vbNewLine & vbNewLine & vbNewLine)

                            mContPg += 1
                            Select Case cbo_opcoes.SelectedIndex

                                Case 0 Or (cbo_opcoes.SelectedIndex = 4)
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                                 Pg.: " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                                Case Else
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                   " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                            End Select

                            gravaFinanceiroExtracted(s)
                            mContRegistrosPg = 0
                        End If

                    Case Else
                        If (mContPg = 1) AndAlso (mContRegistrosPg = 66) Then

                            s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)

                            mContPg += 1
                            Select Case cbo_opcoes.SelectedIndex

                                Case 0 Or (cbo_opcoes.SelectedIndex = 4)
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                                 Pg.: " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                                Case Else
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                   " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                            End Select

                            gravaFinanceiroExtracted(s)
                            mContRegistrosPg = 0

                        ElseIf (mContRegistrosPg = 69) Then

                            s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)

                            mContPg += 1

                            Select Case cbo_opcoes.SelectedIndex

                                Case 0 Or (cbo_opcoes.SelectedIndex = 4)
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                                 Pg.: " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                                Case Else
                                    s.WriteLine("                    C O N T I N U A C A O . . .                                   " & String.Format("{0:D3}", mContPg))
                                    s.WriteLine("")

                            End Select

                            gravaFinanceiroExtracted(s)
                            mContRegistrosPg = 0
                        End If

                End Select

                mLoja = drFinan(0).ToString : mLoja = mLoja.Replace("G", "")
                mTP = drFinan(1).ToString
                mSit = drFinan(2).ToString
                mBanco = drFinan(3).ToString
                mDocumento = drFinan(4).ToString

                Try
                    mPortador = drFinan(12).ToString.Substring(0, 29)
                Catch ex As Exception

                    Try
                        mPortador = drFinan(12).ToString
                    Catch ex2 As Exception

                        Try
                            mPortador = drFinan(10).ToString.Substring(0, 29)
                        Catch ex3 As Exception
                            mPortador = drFinan(10).ToString
                        End Try
                    End Try
                End Try

                Try
                    mDtemiss = Format(CDate(drFinan(5).ToString), "dd/MM/yyyy")
                Catch ex As Exception
                    mDtemiss = ""
                End Try

                Try
                    mDtVencto = Format(CDate(drFinan(6).ToString), "dd/MM/yyyy")
                Catch ex As Exception
                    mDtVencto = ""
                End Try

                Try
                    mDtPagNormal = Format(CDate(drFinan(7).ToString), "dd/MM/yyyy")
                Catch ex As Exception
                    mDtPagNormal = ""
                End Try

                Try
                    mJuros = Format(CDbl(drFinan(8).ToString), "##0.00")
                Catch ex As Exception
                    mJuros = "0,00"
                End Try

                mValor = Format(drFinan(9), "###,##0.00")

                mParcial = "" : mDtPaga = ""
                Try

                    mParcial = Format(drFinan(10), "###,##0.00")
                    Try
                        mDtPaga = Format(CDate(drFinan(11)), "dd/MM/yyyy")
                    Catch ex As Exception
                        mDtPaga = ""
                    End Try
                Catch ex As Exception
                End Try


                Select Case cbo_opcoes.SelectedIndex

                    Case 0 Or (cbo_opcoes.SelectedIndex = 4)
                        strLinha = "  " & _clFuncoes.Exibe_Str(mLoja, 4) & " " & _clFuncoes.Exibe_StrEsquerda(mPortador, 29) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mTP, 2) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(" " & mSit & " ", 3) & " " & _clFuncoes.Exibe_StrEsquerda(mBanco, 5) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mDocumento, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtemiss, 10) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mDtVencto, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtPagNormal, 10) & "  " & _
                        _clFuncoes.Exibe_StrEsquerda(mJuros, 6) & " " & _clFuncoes.Exibe_StrDireita(mValor, 10) & " " & _
                        _clFuncoes.Exibe_StrDireita(mParcial, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtPaga, 10)

                        s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 134))


                    Case 9
                        strLinha = "  " & _clFuncoes.Exibe_Str(mLoja, 4) & " " & _clFuncoes.Exibe_StrEsquerda(mPortador, 29) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mTP, 2) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(" " & mSit & " ", 3) & " " & _clFuncoes.Exibe_StrEsquerda(mBanco, 5) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mDocumento, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtemiss, 10) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mDtVencto, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtPagNormal, 10) & "  " & _
                        _clFuncoes.Exibe_StrDireita(mValor, 10)

                        s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 105))


                    Case Else
                        strLinha = "  " & _clFuncoes.Exibe_Str(mLoja, 4) & " " & _clFuncoes.Exibe_StrEsquerda(mPortador, 29) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mTP, 2) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(" " & mSit & " ", 3) & " " & _clFuncoes.Exibe_StrEsquerda(mBanco, 5) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mDocumento, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtemiss, 10) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mDtVencto, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtPagNormal, 10) & "  " & _
                        _clFuncoes.Exibe_StrEsquerda(mJuros, 6) & " " & _clFuncoes.Exibe_StrDireita(mValor, 10)

                        s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 111))


                End Select


                mContItens += 1 : mContRegistrosPg += 1
            End While
            drFinan.Close()


        Catch ex As Exception
            Try
                drFinan.Close()

            Catch ex01 As Exception
            End Try
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        sqlFinan.Remove(_valorZERO, sqlFinan.ToString.Length) : oConnBDGENOV.ClearPool() : oConnBDGENOV.Close()

        'LIMPA OS OBJETOS DE MEMORIA...
        drFinan = Nothing : cmdFinan = Nothing : sqlFinan = Nothing : drFinan = Nothing
        oConnBDGENOV = Nothing


        If mContItens > _valorZERO Then

            s.WriteLine("")
            strLinha = "  TOTAIS --->     " & _clFuncoes.Exibe_StrDireita(mContItens, 3)
            If mContItens > 1 Then
                strLinha += " - Registros"
            Else
                strLinha += " - Registro"
            End If
            s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 115))

            Select Case cbo_opcoes.SelectedIndex

                Case 0 Or (cbo_opcoes.SelectedIndex = 4)
                    '                     1         2         3         4         5         6         7         8         9         0         1         2         3         4         5
                    '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                    s.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------------")

                Case 9
                    '                     1         2         3         4         5         6         7         8         9         0         1         2
                    '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                    s.WriteLine("  -------------------------------------------------------------------------------------------------------")

                Case Else
                    '                     1         2         3         4         5         6         7         8         9         0         1         2
                    '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                    s.WriteLine("  -------------------------------------------------------------------------------------------------------------")

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

                Case 0 Or (cbo_opcoes.SelectedIndex = 4)
                    PrintDocument1.DefaultPageSettings.Landscape = True 'Modo Paisagem
                Case Else
                    PrintDocument1.DefaultPageSettings.Landscape = False 'Modo Retrato
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

    Private Sub cbo_opcoes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_opcoes.SelectedIndexChanged

        Select Case cbo_opcoes.SelectedIndex

            Case 1
                'cbo_tipo.SetBounds(73, 16, 137, 24) : lbl_carteira.Visible = True
                'cbo_carteira.Visible = True : cbo_carteira.SelectedIndex = _valorZERO
                cbo_carteira.Enabled = True : cbo_carteira.SelectedIndex = _valorZERO
                cbo_vendedor.Enabled = False : cbo_vendedor.SelectedIndex = -1

            Case 9
                'cbo_tipo.SetBounds(73, 16, 181, 24) : lbl_carteira.Visible = False
                'cbo_carteira.Visible = False : cbo_carteira.SelectedIndex = -1
                cbo_carteira.Enabled = False : cbo_carteira.SelectedIndex = -1
                cbo_vendedor.Enabled = True : cbo_vendedor.SelectedIndex = _valorZERO

            Case Else
                'cbo_tipo.SetBounds(73, 16, 181, 24) : lbl_carteira.Visible = False
                'cbo_carteira.Visible = False : cbo_carteira.SelectedIndex = -1
                cbo_carteira.Enabled = False : cbo_carteira.SelectedIndex = -1
                cbo_vendedor.Enabled = False : cbo_vendedor.SelectedIndex = -1
        End Select

    End Sub

    Private Sub cbo_carteira_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_carteira.GotFocus

        If Not cbo_carteira.DroppedDown Then cbo_carteira.DroppedDown = True
    End Sub

    Private Sub cbo_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_vendedor.GotFocus

        If Not cbo_vendedor.DroppedDown Then cbo_vendedor.DroppedDown = True
    End Sub

End Class