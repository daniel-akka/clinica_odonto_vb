Imports Npgsql
Imports System.IO
Imports System.Text
Imports System.Math
Imports System.Drawing.Printing

Public Class Frm_RelatorioDesp

    Private _funcoes As New ClFuncoes
    Dim frmBuscaDataPeriodo As New Frm_DataPeriodoResp
    Public Shared _frmREf As New Frm_RelatorioDesp
    Dim _Geno As New Cl_Geno

    Dim _mConsulta As String = ""
    Dim _local As String = MdlUsuarioLogando._local.Substring(MdlUsuarioLogando._local.Length - 2)
    Dim sw As Cl_EscreveArquivo

    'Referencias...
    Public dataInicialRef, dataFinalRef As New Date

    'objetos para impressão...
    Dim MostrarCaixaImpressoras As Boolean = False
    Dim _StringToPrint As String = "", _stringToPrintAux As String = ""
    Private _PrintFont1 As New Font("Lucida Console", 8) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Dim _cabecalho As Boolean = True

    Private Sub Frm_RelatorioDesp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F6
                executaF6()
        End Select

    End Sub

    Private Sub Frm_RelatorioDesp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Frm_RelatorioDesp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        cbo_empresa = _clFunc.PreenchComboLoja2Dig(cbo_empresa, MdlConexaoBD.conectionPadrao)
        cbo_empresa.SelectedIndex = _clFunc.trazIndexComboBox(_local, _local.Length, cbo_empresa)
        cbo_opcoesRelatorio.SelectedIndex = 0


        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorios.BeginPrint, AddressOf InicializaRelatorio

    End Sub

    Private Sub cbo_opcoesRelatorio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_opcoesRelatorio.GotFocus
        If cbo_opcoesRelatorio.DroppedDown = False Then cbo_opcoesRelatorio.DroppedDown = True
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        executaF6()
    End Sub

    Private Sub executaF6()

        Select Case cbo_opcoesRelatorio.SelectedIndex

            Case 0 'Baixa Mensal - Pagamentos
                executaRelatorioBaixasMensal("", "\wged\RelatorioBaixasMensal.txt")

            Case 1 'Baixa paríodo - Pagamentos
                _frmREf = Me
                frmBuscaDataPeriodo.set_frmRef(Me)
                frmBuscaDataPeriodo.ShowDialog(Me)

                executaRelatorioBaixasMensal("", "\wged\RelatorioBaixasMensal.txt")

            Case Else

                If cbo_opcoesRelatorio.SelectedIndex < 0 Then
                    MsgBox("Selecione uma Opção para Imprimir", MsgBoxStyle.Exclamation)
                    cbo_opcoesRelatorio.Focus()
                End If

        End Select


    End Sub

#Region "Relatórios:"

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

#Region " ** Baixa Mensal - Pagamentos ** "

    Public Sub GravCabLojBaixasMensal()

        Dim mDataInicial As String = Format(dataInicialRef, "dd/MM/yyyy")
        Dim mDataFinal As String = Format(dataFinalRef, "dd/MM/yyyy")
        Dim loja As String = MdlUsuarioLogando._local

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try


        '                      1         2         3         4         5         6         7         8         9         0         1         2
        '             123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        sw.EscreveLn("+========================================================================================+")
        _mConsulta = "SELECT g_geno, g_ender FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        GravCabLojBaixasMensal(_mConsulta.ToString, sw, loja, mDataInicial, mDataFinal, oConnBD, lShouldReturn1)


    End Sub

    Public Sub GravCabLojBaixasMensal(ByVal consulta As String, ByRef sw As Cl_EscreveArquivo, ByVal loja As String, _
                                           ByVal dataInicial As String, ByVal dataFinal As String, _
                                           ByVal oConnBD As NpgsqlConnection, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = "", strAux As String = "", strAux2 As String = ""

            'Traz dados da LOJA do Usuario Logado...
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            cmd = New NpgsqlCommand(consulta, oConnBD)
            dr = cmd.ExecuteReader

            Dim nomeLoja, ufLoja, enderLoja, cidLoja, foneLoja, cnpjLoja As String

            nomeLoja = "" : enderLoja = "" : foneLoja = "" : ufLoja = "" : cidLoja = "" : cnpjLoja = ""
            While dr.Read

                nomeLoja = dr(0).ToString : enderLoja = dr(1).ToString
            End While
            dr.Close() : cmd = Nothing : dr = Nothing


            '                      1         2         3         4         5         6         7         8         9         0         1         2
            '             123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            '             ====[RELP029]=============================================================================
            strAux = _funcoes.Exibe_StrEsquerda("| Empresa.: " & _local & " - " & _funcoes.Exibe_StrEsquerda(nomeLoja, 50), 60)
            strAux += _funcoes.Exibe_StrDireita("Pag.: " & String.Format("{0:D3}", sw.paginaAtual) & " |", 30)
            sw.EscreveLn(_funcoes.Exibe_Str(strAux, 90))

            strAux = "|" & _funcoes.Exibe_StrDireita("Emissao.: " & Format(MdlConexaoBD.dataServidor, "dd/MM/yyyy") & " |", 89)
            sw.EscreveLn(_funcoes.Exibe_Str(strAux, 90))

            Select Case cbo_opcoesRelatorio.SelectedIndex
                Case 0
                    sw.EscreveLn("| " & _funcoes.Exibe_StrEsquerda("Periodo: " & dtp_mesAno.Text, 86) & " |")
                Case 1
                    sw.EscreveLn("| " & _funcoes.Exibe_StrEsquerda("Periodo: " & dataInicial & " a " & dataFinal, 86) & " |")
            End Select


            sw.EscreveLn("|               Duplicatas Pagas Por Centro de Custo e Data de Pagamento                 |")
            sw.EscreveLn("|                                                                                        |")
            sw.EscreveLn("|      Conta          Historico                      Data             Valor              |")
            sw.EscreveLn("|----------------------------------------------------------------------------------------|")



            oConnBD.ClearAllPools()
        Catch ex As Exception
            MsgBox("RELATORIO - Erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Private Sub executaRelatBaixasMensal1(ByRef sw As Cl_EscreveArquivo, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False

        'Variáveis Totais...
        Dim ds_local, ds_grupo, ds_subgrupo, ds_tipo, ds_descricao, ds_descricao2, ds_historico As String
        Dim ds_data As String, ds_grupoAux As String
        Dim ds_valor As Double = 0.0, mSomads_valor As Double = 0.0, mSomaTotaldsValor As Double = 0.0
        Dim ds_countSubgrupo As Integer = 0, ds_countSubgrupoAux As Integer = 0
        Dim mDataInicial As String = Format(dataInicialRef, "dd/MM/yyyy")
        Dim mDataFinal As String = Format(dataFinalRef, "dd/MM/yyyy")
        Dim mDataMensal As String = dtp_mesAno.Text
        Dim mStrLinha As String = "", mStrLinhaAux As String = ""
        Dim mLoja As String = Mid(loja, loja.Length - 2)

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexao:: ", MsgBoxStyle.Critical)
            Return
        End Try

        'Loja Cabeçalho #########################################
        sw.EscreveLn("+========================================================================================+")
        _mConsulta = "SELECT g_geno, g_ender FROM geno001 WHERE g_codig = '" & loja & "'"
        Dim lShouldReturn1 As Boolean
        GravCabLojBaixasMensal(_mConsulta.ToString, sw, loja, mDataInicial, mDataFinal, oConnBD, lShouldReturn1)



        Select Case cbo_opcoesRelatorio.SelectedIndex
            Case 0
                _mConsulta = "(SELECT d1.ds_grupo, d1.ds_descricao, '' As ""dm_tipo"", '' AS ""dm_subgrupo"",  d1.ds_descricao2, '' AS ""dm_historico"", " & _
                   "'' As ""dm_data"", 0.00 As ""dm_valor"", 0 As ""Count"" FROM " & MdlEmpresaUsu._esqEstab & ".desp001 d1 WHERE " & _
                   "d1.ds_local = '" & mLoja & "' AND d1.ds_descricao <> '' AND EXISTS(SELECT " & _
                   "dd1.dm_grupo FROM " & MdlEmpresaUsu._esqEstab & ".despm002 dd1 WHERE dd1.dm_firma = '" & mLoja & "' AND " & _
                   "d1.ds_grupo = dd1.dm_grupo AND to_char(dd1.dm_data, 'MM/yyyy') = '" & mDataMensal & "')) " & _
                   "UNION ALL (SELECT ds_grupo, ds_descricao, dm_tipo, dm_subgrupo, ds_descricao2, dm_historico, " & _
                   "To_Char(dm_data, 'dd/MM/yyyy'), dm_valor, (Select Count(d2.dm_grupo) FROM " & MdlEmpresaUsu._esqEstab & ".despm002 d2 WHERE " & _
                   "d2.dm_firma = '" & mLoja & "' AND " & _
                   "ds_grupo = d2.dm_grupo AND to_char(d2.dm_data, 'MM/yyyy') = '" & mDataMensal & "' AND d2.dm_tipo = 'P') As ""Count"" FROM " & _
                   MdlEmpresaUsu._esqEstab & ".desp001 JOIN " & _
                   MdlEmpresaUsu._esqEstab & ".despm002 ON ds_local = dm_firma AND ds_grupo = dm_grupo WHERE ds_local = '" & mLoja & "' AND " & _
                   "ds_subgrupo = dm_subgrupo AND to_char(dm_data, 'MM/yyyy') = '" & mDataMensal & "' AND dm_tipo = 'P') ORDER BY ds_grupo ASC, " & _
                   "ds_descricao DESC, dm_tipo, dm_subgrupo ASC"

            Case 1

                _mConsulta = "(SELECT d1.ds_grupo, d1.ds_descricao, '' As ""dm_tipo"", '' AS ""dm_subgrupo"",  d1.ds_descricao2, '' AS ""dm_historico"", " & _
                   "'' As ""dm_data"", 0.00 As ""dm_valor"", 0 As ""Count"" FROM " & MdlEmpresaUsu._esqEstab & ".desp001 d1 WHERE " & _
                   "d1.ds_local = '" & mLoja & "' AND d1.ds_descricao <> '' AND EXISTS(SELECT " & _
                   "dd1.dm_grupo FROM " & MdlEmpresaUsu._esqEstab & ".despm002 dd1 WHERE dd1.dm_firma = '" & mLoja & "' AND " & _
                   "d1.ds_grupo = dd1.dm_grupo AND (dd1.dm_data BETWEEN '" & mDataInicial & "' AND '" & _
                   mDataFinal & "'))) UNION ALL (SELECT ds_grupo, ds_descricao, dm_tipo, dm_subgrupo, ds_descricao2, dm_historico, " & _
                   "To_Char(dm_data, 'dd/MM/yyyy'), dm_valor, (Select Count(d2.dm_grupo) FROM " & MdlEmpresaUsu._esqEstab & ".despm002 d2 WHERE " & _
                   "d2.dm_firma = '" & mLoja & "' AND " & _
                   "ds_grupo = d2.dm_grupo AND (d2.dm_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND d2.dm_tipo = 'P') As ""Count"" FROM " & _
                   MdlEmpresaUsu._esqEstab & ".desp001 JOIN " & MdlEmpresaUsu._esqEstab & ".despm002 ON ds_local = dm_firma AND ds_grupo = dm_grupo WHERE " & _
                   "ds_local = '" & mLoja & "' AND ds_subgrupo = dm_subgrupo " & _
                   "AND (dm_data BETWEEN '" & mDataInicial & "' AND '" & mDataFinal & "') AND dm_tipo = 'P') ORDER BY ds_grupo ASC, ds_descricao DESC, dm_tipo, dm_subgrupo ASC"

        End Select
       
        comm = New NpgsqlCommand(_mConsulta, oConnBD)
        dr = comm.ExecuteReader

        ds_grupoAux = ""
        While dr.Read

            If (sw.contLinhasPorPagina + 4) >= sw.qtdLinhasPorPagina Then
                sw.SaltandoLinhasComEscreveLn(4)
            End If


            ds_grupo = dr(0).ToString
            ds_descricao = dr(1).ToString
            ds_tipo = dr(2).ToString
            ds_subgrupo = dr(3).ToString
            ds_descricao2 = dr(4).ToString
            ds_historico = dr(5).ToString
            If ds_historico.Equals("") Then ds_historico = ds_descricao2
            ds_data = dr(6).ToString
            ds_countSubgrupo = dr(8)
            Try
                ds_valor = dr(7)
            Catch ex As Exception
                ds_valor = 0.0
            End Try


            If ds_grupo.Equals(ds_grupoAux) Then

                If Trim(ds_descricao).Equals("") = False Then

                    mStrLinha = "|  " & _funcoes.Exibe_Str(ds_grupo, 3) & " " & _funcoes.Exibe_StrEsquerda(ds_descricao, 82) & "|"
                    sw.EscreveLn(mStrLinha)

                Else

                    ds_countSubgrupoAux += 1
                    If ds_countSubgrupoAux = ds_countSubgrupo Then

                        mSomads_valor += ds_valor
                        mStrLinha = "|     " & _funcoes.Exibe_StrEsquerda(ds_subgrupo, 13) & " " & _funcoes.Exibe_StrEsquerda(ds_historico, 30) & " "
                        mStrLinha += ds_data & " " & _funcoes.Exibe_StrDireita(Format(ds_valor, "###,##0.00"), 13) & " " & _
                        _funcoes.Exibe_StrDireita(Format(Round(mSomads_valor, 2), "###,##0.00"), 13) & "|"
                        sw.EscreveLn(mStrLinha)
                        sw.EscreveLn("|                                                                                        |")
                        mSomaTotaldsValor += ds_valor : mSomads_valor = 0.0 : ds_countSubgrupoAux = 0

                    Else

                        mStrLinha = "|     " & _funcoes.Exibe_StrEsquerda(ds_subgrupo, 13) & " " & _funcoes.Exibe_StrEsquerda(ds_historico, 30) & " "
                        mStrLinha += ds_data & " " & _funcoes.Exibe_StrDireita(Format(ds_valor, "###,##0.00"), 13) & "              |"
                        sw.EscreveLn(mStrLinha)
                        mSomads_valor += ds_valor : mSomaTotaldsValor += ds_valor

                    End If


                End If

            Else


                If Trim(ds_descricao).Equals("") = False Then

                    mStrLinha = "|  " & _funcoes.Exibe_Str(ds_grupo, 3) & " " & _funcoes.Exibe_StrEsquerda(ds_descricao, 82) & "|"
                    sw.EscreveLn(mStrLinha)

                Else

                    ds_countSubgrupoAux += 1
                    If ds_countSubgrupoAux = ds_countSubgrupo Then

                        mSomads_valor += ds_valor
                        mStrLinha = "|     " & _funcoes.Exibe_StrEsquerda(ds_subgrupo, 13) & " " & _funcoes.Exibe_StrEsquerda(ds_historico, 30) & " "
                        mStrLinha += ds_data & " " & _funcoes.Exibe_StrDireita(Format(ds_valor, "###,##0.00"), 13) & " " & _
                        _funcoes.Exibe_StrDireita(Format(Round(mSomads_valor, 2), "###,##0.00"), 13) & "|"
                        sw.EscreveLn(mStrLinha)
                        sw.EscreveLn("|                                                                                        |")
                        mSomaTotaldsValor += ds_valor : mSomads_valor = 0.0 : ds_countSubgrupoAux = 0

                    Else

                        mStrLinha = "|     " & _funcoes.Exibe_StrEsquerda(ds_subgrupo, 13) & " " & _funcoes.Exibe_StrEsquerda(ds_historico, 30) & " "
                        mStrLinha += ds_data & " " & _funcoes.Exibe_StrDireita(Format(ds_valor, "###,##0.00"), 13) & "              |"
                        sw.EscreveLn(mStrLinha)
                        mSomads_valor += ds_valor : mSomaTotaldsValor += ds_valor

                    End If

                End If

            End If


            ds_grupoAux = ds_grupo
        End While
        dr.Close()




        sw.EscreveLn("|                                                                                        |")
        sw.EscreveLn("| Total de Pagamentos  R$  " & _funcoes.Exibe_StrEsquerda(Format(mSomaTotaldsValor, "###,##0.00"), 62) & "|")
        sw.EscreveLn("+----------------------------------------------------------------------------------------+")



        Try
            oConnBD.ClearAllPools()
            oConnBD.Close() : oConnBD = Nothing
        Catch ex As Exception
        End Try

    End Sub

    Private Sub executaRelatorioBaixasMensal(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPRelatorioBaixasMensal.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\wged\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try



        sw = New Cl_EscreveArquivo(fs)
        sw.chamaEvento = True

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler sw.SaltandoLinhasEvento, AddressOf GravCabLojBaixasMensal
        sw.qtdLinhasPorPagina = 83
        sw.qtdSaltosLinhaNextPag = 0
        _PrintFont1 = New Font("Lucida Console", 9.2) 'Sans Serif
        'sw.SaltandoLinhasComEscreveLn(83)
        'sw.EscreveLn("SALTANDO ......................")


        'Ajuda a contar caracteres da pagina...
        ''                      1         2         3         4         5         6         7         8         9         0         1         2
        ''             123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        'sw.EscreveLn("============================================================================================")


        Dim loja As String = _Geno.pCodig
        'Relatório 1º .........................................
        Try

            Dim lShouldReturn As Boolean
            executaRelatBaixasMensal1(sw, loja, lShouldReturn)
            If lShouldReturn Then Return
        Catch ex As Exception

            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception

                Try
                    fs = New FileStream("\wged\new.TMP", FileMode.Create, FileAccess.ReadWrite)
                Catch ex2 As Exception
                End Try

            End Try
        End Try


        'Deleta o arquivo temporário...
        sw.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        sw.Dispose()
        File.Delete(mArqTemp)

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuContRelatorioBaixasMensal()
        _StringToPrint = ""

    End Sub

    Private Sub VisuContRelatorioBaixasMensal()

        Try

            ' Especifica as configurações da pagina atual
            pdRelatorios.DefaultPageSettings = _PrintPageSettings

            'Configurando margens 39 = 1cm
            pdRelatorios.DefaultPageSettings.Margins.Top = 59
            pdRelatorios.DefaultPageSettings.Margins.Right = 40
            pdRelatorios.DefaultPageSettings.Margins.Left = 59
            pdRelatorios.DefaultPageSettings.Margins.Bottom = 40

            'Orientação em Paisagem...
            pdRelatorios.DefaultPageSettings.Landscape = False
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando RELATÓRIO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatorios
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False
            _StringToPrint = ""

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

#End Region


#End Region

#Region " **** IMPRESSÃO  **** "

    Private Sub pdRelatorios_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdRelatorios.PrintPage

        Dim NumChars As Integer
        Dim NumLines As Integer
        Dim StringforPage As String
        Dim Strformat As New StringFormat

        Dim recdraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, _
                                      e.MarginBounds.Width, e.MarginBounds.Height)
        Dim SizeMeassure As New SizeF(e.MarginBounds.Width, _
                                      e.MarginBounds.Height - _PrintFont1.GetHeight(e.Graphics))

        Strformat.Trimming = StringTrimming.Word

        e.Graphics.MeasureString(_StringToPrint, _PrintFont1, SizeMeassure, Strformat, NumChars, NumLines)
        StringforPage = _StringToPrint.Substring(0, NumChars)
        e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, recdraw, Strformat)


        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False : _StringToPrint = _stringToPrintAux

        End If



    End Sub

    Private Sub InicializaRelatorio(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintEventArgs)

        If MostrarCaixaImpressoras Then

            Dim Impressora As New PrintDialog
            Impressora.AllowCurrentPage = True : Impressora.AllowSomePages = True
            If Impressora.ShowDialog() = DialogResult.Cancel Then

                Relatorio.Cancel = True

            Else

                Try

                    pdRelatorios.PrinterSettings = Impressora.PrinterSettings
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
        End If
        MostrarCaixaImpressoras = True



    End Sub

#End Region
   
    Private Sub cbo_empresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_empresa.SelectedIndexChanged

        Try
            If cbo_empresa.SelectedIndex >= 0 Then
                _local = Mid(cbo_empresa.SelectedItem.ToString, 1, 2)
                _clFunc.trazGenoSelecionado("G00" & _local, _Geno)
            End If
        Catch ex As Exception
        End Try

    End Sub

End Class