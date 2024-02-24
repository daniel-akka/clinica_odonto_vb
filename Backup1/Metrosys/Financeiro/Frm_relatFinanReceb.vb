Imports Npgsql
Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Math
Imports System.Drawing.Printing

Public Class Frm_relatFinanReceb
    Private Const _valorZERO As Integer = 0
    Private Mlojas As String
    Public Shared _frmRef As New Frm_Dup_PosicaoPortador
    Dim _BuscaCli As New Frm_BuscaCli
    Private _clFuncoes As New ClFuncoes

    'objetos para impressão
    Dim _sw As Cl_EscreveArquivo
    Dim _StringToPrint As String = "", _stringToPrintAux As String = "", _strLinha As String = ""
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

        executaRelatorio("", "\wged\consultaFinancRec.txt")
    End Sub

    Private Sub executaRelatorio(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPconsultaFinancRec.TMP"
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


        _sw = New Cl_EscreveArquivo(fs)
        _sw.chamaEvento = True
        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler _sw.SaltandoLinhasEvento, AddressOf gravaCabecalho
        _sw.qtdSaltosLinhaNextPag = 3
        Select Case cbo_opcoes.SelectedIndex
            Case 0, 4
                _sw.qtdLinhasPorPagina = 63
                _PrintFont = New Font("Lucida Console", 9)
            Case Else
                _sw.qtdLinhasPorPagina = 99
                _PrintFont = New Font("Lucida Console", 8)
        End Select

        'CABEÇALHO
        gravaCabecalho()

        'FINANCEIRO
        gravaFinanceiro()

        'Deleta o arquivo temporário...
        _sw.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        _sw.Dispose()
        File.Delete(mArqTemp)

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo()

        _sw = Nothing
        _StringToPrint = ""
    End Sub

    Private Sub gravaCabecalho()

        'titulo
        Try
            'vbCrLf, vbCr, vbLf, vbNewLine = quebra de linha
            _sw.SaltandoLinhasComEscreveLn(2)
            '8 caracteres
            Select Case cbo_opcoes.SelectedIndex

                Case 0, 4
                    _strLinha = "RELATÓRIO (" & cbo_opcoes.SelectedItem & ")"
                    If cbo_opcoes.SelectedIndex = _valorZERO Then

                        _strLinha += "  " & dtp_inicial.Text & " A " & dtp_final.Text
                    End If

                    _strLinha = _clFuncoes.Centraliza_Str(_strLinha, 134)
                    _strLinha = _strLinha.Substring(0, _strLinha.Length - 16)
                    _strLinha += "Data: " & Format(Date.Now, "dd/MM/yyyy")

                    _sw.EscreveLn(_strLinha)
                    _strLinha = "" : _strLinha = Mid(cbo_loja.SelectedItem, 5, cbo_loja.SelectedItem.ToString.Length)
                    _strLinha = _clFuncoes.Exibe_StrEsquerda(_strLinha, 101)
                    _strLinha += _clFuncoes.Exibe_StrDireita("Pg. " & Format(_sw.paginaAtual, "000"), 33)
                    _sw.EscreveLn(_strLinha) : _sw.EscreveLn("")

                Case 9
                    Dim mvendedor As String = ""
                    If cbo_vendedor.SelectedIndex >= _valorZERO Then mvendedor = cbo_vendedor.SelectedItem
                    _strLinha = _clFuncoes.Centraliza_Str("RELATÓRIO (" & cbo_opcoes.SelectedItem & ")  " & mvendedor, 105)
                    _strLinha = _strLinha.Substring(0, _strLinha.Length - 16)
                    _strLinha += "Data: " & Format(Date.Now, "dd/MM/yyyy")

                    _sw.WriteLine(_strLinha)
                    _strLinha = "" : _strLinha = Mid(cbo_loja.SelectedItem, 5, cbo_loja.SelectedItem.ToString.Length)
                    _strLinha = _clFuncoes.Exibe_StrEsquerda(_strLinha, 82)
                    _strLinha += _clFuncoes.Exibe_StrDireita("Pg. " & Format(_sw.paginaAtual, "000"), 23)
                    _sw.EscreveLn(_strLinha) : _sw.EscreveLn("")


                Case Else
                    Dim mcateira As String = ""
                    If cbo_carteira.SelectedIndex >= _valorZERO Then mcateira = cbo_carteira.SelectedItem
                    _strLinha = _clFuncoes.Centraliza_Str("RELATÓRIO (" & cbo_opcoes.SelectedItem & ")  " & mcateira, 112)
                    _strLinha = _strLinha.Substring(0, _strLinha.Length - 16)
                    _strLinha += "Data: " & Format(Date.Now, "dd/MM/yyyy")

                    _sw.EscreveLn(_strLinha)
                    _strLinha = "" : _strLinha = Mid(cbo_loja.SelectedItem, 5, cbo_loja.SelectedItem.ToString.Length)
                    _strLinha = _clFuncoes.Exibe_StrEsquerda(_strLinha, 89)
                    _strLinha += _clFuncoes.Exibe_StrDireita("Pg. " & Format(_sw.paginaAtual, "000"), 23)
                    _sw.EscreveLn(_strLinha) : _sw.EscreveLn("")

            End Select


        Catch ex As Exception
        End Try

        gravaFinanceiroExtracted()

    End Sub

    Private Sub gravaFinanceiroExtracted()

        Select Case cbo_opcoes.SelectedIndex

            Case 0, 4
                '                     1         2         3         4         5         6         7         8         9         0         1         2         3         4         5
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                _sw.EscreveLn(" -------------------------------------------------------------------------------------------------------------------------------------")
                _sw.EscreveLn("  Loja Portador                      TP SIT Banco Documento  DtEmiss    DtVencto   DtPaga      Juros   ValorR$   ParcialR$  DtParcial ")
                '              xxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxx xx  x  xxxxx xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ  xxxxx xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ
                _sw.EscreveLn("  -----------------------------------------------------------------------------------------------------------------------------------")

            Case 9
                '                     1         2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                _sw.EscreveLn(" ---------------------------------------------------------------------------------------------------------")
                _sw.EscreveLn("  Loja Portador                       TP SIT Banco Documento  DtEmiss    DtVencto   DtPaga        ValorR$ ")
                '              xxxx xxxxxxxxxZxxxxxxxxxxZxxxxxxxxx xx  x  xxxxx xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ
                _sw.EscreveLn("  -------------------------------------------------------------------------------------------------------")

            Case Else
                '                     1         2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                _sw.EscreveLn(" ---------------------------------------------------------------------------------------------------------------")
                _sw.EscreveLn("  Loja Portador                       TP SIT Banco Documento  DtEmiss    DtVencto   DtPaga     Juros    ValorR$ ")
                '              xxxx xxxxxxxxxZxxxxxxxxxxZxxxxxxxxx xx  x  xxxxx xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ xxxxxxxxxZ xxxxx xxxxxxxxxZ
                _sw.EscreveLn("  -------------------------------------------------------------------------------------------------------------")

        End Select


    End Sub

    Private Sub gravaFinanceiro()

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim nomeCampo As String = "", nomeCampoAux As String = "", mfone As String = ""
        Dim mContItens As Integer = _valorZERO

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try


        Dim sqlFinan As New StringBuilder
        Dim cmdFinan As NpgsqlCommand
        Dim drFinan As NpgsqlDataReader

        Dim mSomaValores As Double = 0.0
        Dim mLoja, mTP, mSit, mBanco, mDocumento, mDtemiss, mDtVencto, mDtPagNormal, mJuros As String
        Dim mValor, mParcial, mDtPaga, mPortador As String

        Try


            Select Case Me.cbo_opcoes.SelectedIndex

                Case 0 'Doc. Pagos no Período
                    sqlFinan.Append("SELECT Ft.f_geno AS ""Loja"", Ft.f_tipo AS ""TP"", Ft.f_sit AS ""SIT"", ") '2
                    sqlFinan.Append("Ft.f_banco AS ""Banco"", Ft.f_duplic AS ""Documento"", Ft.f_emiss AS ""DtEmissão"", ") '5
                    sqlFinan.Append("Ft.f_vencto AS ""DtVencto"", Ft.f_dtpaga AS ""DtPaga"", Ft.f_juros AS ""Juros R$"", ") '8
                    sqlFinan.Append("Ft.f_valor AS ""Valor R$"", Pc.f_valor AS ""Parcial R$"", Pc.f_dtpaga AS ""DtPaga "", cad.p_portad AS ""Portador"" ") '12
                    sqlFinan.Append("FROM cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft LEFT OUTER JOIN ")
                    sqlFinan.Append(MdlEmpresaUsu._esqEstab & ".fatdp02 Pc ON ft.f_duplic = Pc.f_duplic WHERE cad.p_cod = Ft.f_portad AND Ft.f_sit = 'L' AND Ft.f_dtpaga BETWEEN '" & Format(CDate(dtp_inicial.Text), "dd/MM/yyyy") & "' AND '" & Format(CDate(dtp_final.Text), "dd/MM/yyyy") & "' ")

                    If Me.cbo_tipo.SelectedIndex > _valorZERO Then

                        Dim mtipo As String = Mid(Me.cbo_tipo.SelectedItem, 1, 2)
                        sqlFinan.Append("AND Ft.f_tipo = '" & mtipo.ToUpper & "' ")
                        mtipo = Nothing
                    End If


                Case 1 'Doc. Vencidas por Carteira
                    sqlFinan.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlFinan.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"", ") '6
                    sqlFinan.Append("f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", f_valor AS ""Valor R$"", cad.p_portad AS ""Portador"" ") '10
                    sqlFinan.Append("FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft LEFT JOIN cadp001 cad ON cad.p_cod = f_portad WHERE Ft.f_vencto < CURRENT_DATE AND f_sit = 'N' AND f_cartei = '" & Mid(Me.cbo_carteira.SelectedItem, 1, 2) & "' ORDER BY Ft.f_vencto ASC") '

                Case 2 'Doc. a Vencer por Período
                    sqlFinan.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlFinan.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"", ") '6
                    sqlFinan.Append("f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", f_valor AS ""Valor R$"", cad.p_portad AS ""Portador"" ") '10
                    sqlFinan.Append("FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft LEFT JOIN cadp001 cad ON cad.p_cod = f_portad WHERE f_sit = 'N' AND Ft.f_vencto > CURRENT_DATE AND (Ft.f_vencto BETWEEN '" & Format(CDate(dtp_inicial.Text), "dd/MM/yyyy") & "' AND '" & Format(CDate(dtp_final.Text), "dd/MM/yyyy") & "') ")


                Case 3 'Doc. Incluidas por Dia
                    sqlFinan.Append("SELECT Ft.f_geno AS ""Loja"", Ft.f_tipo AS ""TP"", Ft.f_sit AS ""SIT"", ") '2
                    sqlFinan.Append("Ft.f_banco AS ""Banco"", Ft.f_duplic AS ""Documento"", Ft.f_emiss AS ""DtEmissão"", ") '5
                    sqlFinan.Append("Ft.f_vencto AS ""DtVencto"", Ft.f_dtpaga AS ""DtPaga"", Ft.f_juros AS ""Juros R$"", ") '8
                    sqlFinan.Append("Ft.f_valor AS ""Valor R$"", Pc.f_valor AS ""Parcial R$"", Pc.f_dtpaga AS ""DtPaga "", cad.p_portad AS ""Portador"" ") '12
                    sqlFinan.Append("FROM cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft LEFT OUTER JOIN ")
                    sqlFinan.Append(MdlEmpresaUsu._esqEstab & ".fatdp02 Pc ON ft.f_duplic = Pc.f_duplic WHERE cad.p_cod = Ft.f_portad AND ")
                    sqlFinan.Append("Ft.f_emiss = '" & Format(Date.Now, "dd/MM/yyyy") & "' OR Ft.f_dtpaga = '" & Format(Date.Now, "dd/MM/yyyy") & "' ")

                Case 4 'Dupl.Pagas - Pendente
                    sqlFinan.Append("SELECT Ft.f_geno AS ""Loja"", Ft.f_tipo AS ""TP"", Ft.f_sit AS ""SIT"", ") '2
                    sqlFinan.Append("Ft.f_banco AS ""Banco"", Ft.f_duplic AS ""Documento"", Ft.f_emiss AS ""DtEmissão"", ") '5
                    sqlFinan.Append("Ft.f_vencto AS ""DtVencto"", Ft.f_dtpaga AS ""DtPaga"", Ft.f_juros AS ""Juros R$"", ") '8
                    sqlFinan.Append("Ft.f_valor AS ""Valor R$"", Pc.f_valor AS ""Parcial R$"", Pc.f_dtpaga AS ""DtPaga "", cad.p_portad AS ""Portador"" ") '12
                    sqlFinan.Append("FROM cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE cad.p_cod = Ft.f_portad AND f_sit = 'N' AND f_cartei = '01' AND (Ft.f_dtpaga BETWEEN '" & Format(CDate(dtp_inicial.Text), "dd/MM/yyyy") & "' AND '" & Format(CDate(dtp_final.Text), "dd/MM/yyyy") & "') ")


                    If Me.cbo_tipo.SelectedIndex > _valorZERO Then

                        Dim mtipo As String = Mid(Me.cbo_tipo.SelectedItem, 1, 2)
                        sqlFinan.Append("AND Ft.f_tipo = '" & mtipo.ToUpper & "' ")
                        mtipo = Nothing
                    End If


                Case 5 'Vencidas Alfabética
                    sqlFinan.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlFinan.Append("f_banco AS ""Banco"", f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"", ") '6
                    sqlFinan.Append("f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", f_valor AS ""Valor R$"", cad.p_portad AS ""Portador"" ") '10
                    sqlFinan.Append("FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft LEFT JOIN cadp001 cad ON cad.p_cod = f_portad WHERE f_sit = 'N' AND f_vencto < CURRENT_DATE ORDER BY f_duplic ASC")

                    'Case 6 'Gera Fatura
                    '    sqlFinan.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    '    sqlFinan.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    '    'sqlFinan.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_geno = '" & Mlojas & "' AND f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'N' AND f_vencto < CURRENT_DATE ") '

                    'Case 7 'Emite Bloquete
                    '    sqlFinan.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    '    sqlFinan.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    '    'sqlFinan.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_geno = '" & Mlojas & "' AND f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'N' AND f_vencto < CURRENT_DATE ") '

                    'Case 8 'Emite Duplicatas
                    '    sqlFinan.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    '    sqlFinan.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"",f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", ") '5
                    '    'sqlFinan.Append("f_valor AS ""Valor R$"" FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft WHERE f_geno = '" & Mlojas & "' AND f_portad = '" & RTrim(txt_codPart.Text) & "' AND f_sit = 'N' AND f_vencto < CURRENT_DATE ") '

                Case 9 'Vencidas por Vendedor
                    sqlFinan.Append("SELECT f_geno AS ""Loja"", f_tipo AS ""TP"", f_sit AS ""SIT"", ") '2
                    sqlFinan.Append("f_banco AS ""Banco"",f_duplic AS ""Documento"", f_emiss AS ""DtEmissão"", f_vencto AS ""DtVencto"", ") '6
                    sqlFinan.Append("f_dtpaga AS ""DtPaga"", f_juros AS ""Juros R$ "", f_valor AS ""Valor R$"", cad.p_portad AS ""Portador"" ") '10
                    sqlFinan.Append("FROM " & MdlEmpresaUsu._esqEstab & ".fatd001 Ft LEFT JOIN cadp001 cad ON cad.p_cod = f_portad WHERE f_sit = 'N' AND f_vencto < CURRENT_DATE AND f_vend = '" & Mid(cbo_vendedor.SelectedItem, 1, 6) & "' ORDER BY cad.p_portad ASC")

                Case 10 'Comissao por Vendedor


            End Select


            Select Case cbo_tipo.SelectedIndex

                Case 1 'CH - Cheque
                    sqlFinan.Append("AND Ft.f_tipo = 'CH' ")

                Case 2 'BL - Boleto
                    sqlFinan.Append("AND Ft.f_tipo = 'BL' ")

                Case 3 'NP - N.Promissoria
                    sqlFinan.Append("AND Ft.f_tipo = 'NP' ")

                Case 4 'CR - Carnê
                    sqlFinan.Append("AND Ft.f_tipo = 'CR' ")

                Case 5 'CT - Cartão
                    sqlFinan.Append("AND Ft.f_tipo = 'CT' ")

            End Select



            Select Case cbo_opcoes.SelectedIndex
                Case 0, 4 'Doc. Pagos no Período
                    sqlFinan.Append("ORDER BY Ft.f_emiss")

                Case 1 'Doc. Vencidas por Carteira
                    sqlFinan.Append("ORDER BY Ft.f_vencto ASC")

                Case 2 'Doc. a Vencer por Período
                    sqlFinan.Append("ORDER BY Ft.f_vencto")

                Case 5 'Vencidas Alfabética
                    sqlFinan.Append("ORDER BY f_duplic ASC")
                    
                Case 9 'Vencidas por Vendedor
                    sqlFinan.Append("ORDER BY cad.p_portad ASC")

            End Select



            cmdFinan = New NpgsqlCommand(sqlFinan.ToString, oConnBD)
            drFinan = cmdFinan.ExecuteReader

            While drFinan.Read

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

                    Case 0, 4
                        _strLinha = "  " & _clFuncoes.Exibe_Str(mLoja, 4) & " " & _clFuncoes.Exibe_StrEsquerda(mPortador, 29) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mTP, 2) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(" " & mSit & " ", 3) & " " & _clFuncoes.Exibe_StrEsquerda(mBanco, 5) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mDocumento, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtemiss, 10) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mDtVencto, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtPagNormal, 10) & "  " & _
                        _clFuncoes.Exibe_StrEsquerda(mJuros, 6) & " " & _clFuncoes.Exibe_StrDireita(mValor, 10) & " " & _
                        _clFuncoes.Exibe_StrDireita(mParcial, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtPaga, 10)

                        _sw.EscreveLn(_clFuncoes.Exibe_Str(_strLinha, 134))


                    Case 9
                        _strLinha = "  " & _clFuncoes.Exibe_Str(mLoja, 4) & " " & _clFuncoes.Exibe_StrEsquerda(mPortador, 29) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mTP, 2) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(" " & mSit & " ", 3) & " " & _clFuncoes.Exibe_StrEsquerda(mBanco, 5) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mDocumento, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtemiss, 10) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mDtVencto, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtPagNormal, 10) & "  " & _
                        _clFuncoes.Exibe_StrDireita(mValor, 10)

                        _sw.EscreveLn(_clFuncoes.Exibe_Str(_strLinha, 105))


                    Case Else
                        _strLinha = "  " & _clFuncoes.Exibe_Str(mLoja, 4) & " " & _clFuncoes.Exibe_StrEsquerda(mPortador, 29) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mTP, 2) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(" " & mSit & " ", 3) & " " & _clFuncoes.Exibe_StrEsquerda(mBanco, 5) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mDocumento, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtemiss, 10) & " " & _
                        _clFuncoes.Exibe_StrEsquerda(mDtVencto, 10) & " " & _clFuncoes.Exibe_StrEsquerda(mDtPagNormal, 10) & "  " & _
                        _clFuncoes.Exibe_StrEsquerda(mJuros, 6) & " " & _clFuncoes.Exibe_StrDireita(mValor, 10)

                        _sw.EscreveLn(_clFuncoes.Exibe_Str(_strLinha, 111))


                End Select

                mSomaValores += mValor
                mContItens += 1
            End While
            drFinan.Close()


        Catch ex As Exception
            Try
                drFinan.Close()

            Catch ex01 As Exception
            End Try
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        sqlFinan.Remove(_valorZERO, sqlFinan.ToString.Length) : oConnBD.ClearPool() : oConnBD.Close()

        'LIMPA OS OBJETOS DE MEMORIA...
        drFinan = Nothing : cmdFinan = Nothing : sqlFinan = Nothing : drFinan = Nothing
        oConnBD = Nothing


        If mContItens > _valorZERO Then

            _sw.EscreveLn("")
            _strLinha = "  TOTAIS --->     " & _clFuncoes.Exibe_StrDireita(mContItens, 3)
            If mContItens > 1 Then
                _strLinha += " - Registros"
            Else
                _strLinha += " - Registro"
            End If
            

            Select Case cbo_opcoes.SelectedIndex

                Case 0, 4
                    '                       1         2         3         4         5         6         7         8         9         0         1         2         3         4         5
                    '              123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                    _strLinha += _clFuncoes.Exibe_StrDireita(Format(Round(mSomaValores, 2), "###,##0.00"), 79)
                    _sw.EscreveLn(_clFuncoes.Exibe_Str(_strLinha, 115))
                    _sw.EscreveLn("  -----------------------------------------------------------------------------------------------------------------------------------")

                Case 9
                    '                       1         2         3         4         5         6         7         8         9         0         1         2
                    '              123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                    _strLinha += _clFuncoes.Exibe_StrDireita(Format(Round(mSomaValores, 2), "###,##0.00"), 79)
                    _sw.EscreveLn(_clFuncoes.Exibe_Str(_strLinha, 115))
                    _sw.EscreveLn("  -------------------------------------------------------------------------------------------------------")

                Case Else
                    '                       1         2         3         4         5         6         7         8         9         0         1         2
                    '              123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                    _strLinha += _clFuncoes.Exibe_StrDireita(Format(Round(mSomaValores, 2), "###,##0.00"), 78)
                    _sw.EscreveLn(_clFuncoes.Exibe_Str(_strLinha, 115))
                    _sw.EscreveLn("  -------------------------------------------------------------------------------------------------------------")

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