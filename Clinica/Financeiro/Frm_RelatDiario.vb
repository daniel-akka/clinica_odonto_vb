Imports Npgsql
Imports System.IO
Imports System.Math
Imports System.Drawing.Printing

Public Class Frm_RelatDiario

    Dim _clFuncoes As New ClFuncoes
    Dim _DentistaDAO As New Cl_DoutorDAO
    Dim _Dentista As New Cl_Doutor
    Dim _geno As New Cl_Geno

    'Variáveis Totais:
    Dim _qtdeFichasAtendDr, _qtdeFichasAtendProt, _qtdeOrcamentos As Int16
    Dim _valorFichasAtendDr, _valorDivDr, _valorDivProt, _valorFichasAtendProt As Double
    Dim _iniciaisProt As String = "", iniciaisDr As String = ""
    
    'objetos para impressão:
    Dim _pathContrFrent As String = "\wged\Imagens\ControleDiarioFrente.png"
    Dim _pathContrTras As String = "\wged\Imagens\ControleDiarioTras.png"
    Dim _StringToPrint As String = ""
    Dim MostrarCaixaImpressoras As Boolean = False
    Private _PrintFont As New Font("Lucida Console", 8) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _sImpressao As StreamWriter
    Private _dtAdaptPrint As NpgsqlDataAdapter
    Dim mQtdRegistros As Int16 = 0
    Dim mIndexGrid As Int16 = 0
    Dim mQtdPaginas As Int16 = 0


    Private Sub Frm_RelatDiario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        _clFuncoes.trazGenoSelecionado(MdlEmpresaUsu._codigo, _geno)
        txt_nomeEmpresa.Text = _geno.pGeno
        txt_diaSemana.Text = _clFuncoes.returnDiaSemana(dtp_dia.Value.DayOfWeek.ToString)
        cbo_dentistas = _DentistaDAO.PreenchComboDoutores(_geno, cbo_dentistas, MdlConexaoBD.conectionPadrao)


        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorio.BeginPrint, AddressOf InicializaRelatorio

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorio.PrintPage, AddressOf rptGravaRDiario

        setImpressao()

    End Sub

    Sub setImpressao()

        Dim valor As Int16 = 0
        pdRelatorio.DefaultPageSettings.Margins.Left = valor
        pdRelatorio.DefaultPageSettings.Margins.Top = valor
        pdRelatorio.DefaultPageSettings.Margins.Right = valor
        pdRelatorio.DefaultPageSettings.Margins.Bottom = valor

        pdRelatorio.PrinterSettings.DefaultPageSettings.Margins.Left = valor
        pdRelatorio.PrinterSettings.DefaultPageSettings.Margins.Top = valor
        pdRelatorio.PrinterSettings.DefaultPageSettings.Margins.Right = valor
        pdRelatorio.PrinterSettings.DefaultPageSettings.Margins.Bottom = valor

        PrintDialog1.PrinterSettings = pdRelatorio.PrinterSettings


    End Sub

    Private Sub dtp_dia_ValueChanged(sender As Object, e As EventArgs) Handles dtp_dia.ValueChanged
        txt_diaSemana.Text = _clFuncoes.returnDiaSemana(dtp_dia.Value.DayOfWeek.ToString)
    End Sub

    Private Sub Frm_RelatDiario_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                ExecutaF5()
            Case Keys.F6
                ExecutaF6()
        End Select

    End Sub

    Private Sub cbo_dentistas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_dentistas.SelectedIndexChanged

        Try
            If cbo_dentistas.SelectedIndex > -1 Then
                _DentistaDAO.trazDoutorLojaNome(cbo_dentistas.SelectedItem.ToString, _geno, _Dentista)
            End If
        Catch ex As Exception
            _Dentista.zeraValores()
        End Try

    End Sub

    Private Sub btn_pesquisa_Click(sender As Object, e As EventArgs) Handles btn_pesquisa.Click
        ExecutaF5()
    End Sub

    Sub ZeraVariaveisTotais()
        _qtdeFichasAtendDr = 0 : _qtdeFichasAtendProt = 0 : _qtdeOrcamentos = 0
        _valorFichasAtendDr = 0 : _valorFichasAtendProt = 0 : _valorDivDr = 0 : _valorDivProt = 0
        _iniciaisProt = "" : iniciaisDr = ""
    End Sub

    Sub ExecutaF5()

        dtg_caixaDiario.Rows.Clear() : dtg_caixaDiario.Refresh()
        ZeraVariaveisTotais()
        If cbo_dentistas.SelectedIndex > -1 Then
            preenchDtg_CaixaDiarios()
        End If

    End Sub

    Sub ExecutaF6()

        mQtdRegistros = 0 : mIndexGrid = 0 : mQtdPaginas = 0
        executaEspelhoNF_R("", "\wged\relatorios\caixadiario.txt")

    End Sub

    Function TrazConsultaLanca_Orca() As String
        Dim Sqlcomm As String = ""

        Sqlcomm = "SELECT cx_nomecli AS ""Cliente"", cad.p_ficha AS ""Ficha"", cx_orcamento AS ""Orc"", cx_driniciais AS ""Dr(a)"", "
        Sqlcomm += "cx_hora AS ""Hora"", (SELECT d_iniciais FROM " & _geno.pEsquemaestab & ".doutores WHERE d_protetico = true AND "
        Sqlcomm += "d_nome = cx_protetico LIMIT 1) AS ""Prot"", 0.00 AS ""vlrOrc"", cx_valor AS ""vlrFicha"", 'DN' AS ""tp"", cx_tipo AS ""TIPO"" FROM "
        Sqlcomm += _geno.pEsquemaestab & ".caixadiario LEFT OUTER JOIN cadp001 cad ON cad.p_cod = cx_codcli WHERE cx_doutor = '" & _Dentista.Nome & "' "
        Sqlcomm += "AND (cx_tipo = 'R' OR cx_tipo = 'RA') "

        If IsDate(dtp_dia.Text) Then
            Sqlcomm += "AND cx_data = '" & dtp_dia.Text & "' "
        End If


        Sqlcomm += "UNION "
        Sqlcomm += "SELECT oc_nomecli AS ""Cliente"", cad.p_ficha AS ""Ficha"", true AS ""Orc"", oc_driniciais AS ""Dr(a)"", "
        Sqlcomm += "oc_hora AS ""Hora"", (SELECT d_iniciais FROM " & _geno.pEsquemaestab & ".doutores WHERE d_protetico = true AND "
        Sqlcomm += "d_nome = oc_protetico LIMIT 1) AS ""Prot"", oc_valor AS ""vlrOrc"", 0.00 AS ""vlrFicha"", 'OC' AS ""tp"", 'O' AS ""TIPO"" FROM "
        Sqlcomm += _geno.pEsquemaestab & ".cxorcamento LEFT OUTER JOIN cadp001 cad ON cad.p_cod = oc_codcli WHERE oc_doutor = '" & _Dentista.Nome & "' "

        If IsDate(dtp_dia.Text) Then
            Sqlcomm += "AND oc_data = '" & dtp_dia.Text & "' "
        End If


        Sqlcomm += "UNION "
        Sqlcomm += "SELECT cad.p_portad AS ""Cliente"", cad.p_ficha AS ""Ficha"", false AS ""Orc"", (SELECT d_iniciais FROM "
        Sqlcomm += _geno.pEsquemaestab & ".doutores WHERE d_nome = f_doutor LIMIT 1) AS ""Dr(a)"", "
        Sqlcomm += "f_hora AS ""Hora"", (SELECT d_iniciais FROM " & _geno.pEsquemaestab & ".doutores WHERE d_protetico = true AND "
        Sqlcomm += "d_nome = f_protetico LIMIT 1) AS ""Prot"", 0.00 AS ""vlrOrc"", f_valor AS ""vlrFicha"", 'CT' AS ""tp"", 'CT' AS ""TIPO"" FROM "
        Sqlcomm += _geno.pEsquemaestab & ".fatd001 LEFT OUTER JOIN cadp001 cad ON cad.p_cod = f_portad WHERE f_doutor = '" & _Dentista.Nome & "' AND f_sit = 'L' "

        If IsDate(dtp_dia.Text) Then
            Sqlcomm += "AND f_dtpaga = '" & dtp_dia.Text & "' "
        End If



        Sqlcomm += "ORDER BY ""Hora"" ASC LIMIT 41"


        Return Sqlcomm
    End Function

    Private Sub preenchDtg_CaixaDiarios()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim consulta As String

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão:: " & ex.Message)
        End Try

        consulta = TrazConsultaLanca_Orca()

        comm = New NpgsqlCommand(consulta, conn)
        dr = comm.ExecuteReader

        Try
            dtg_caixaDiario.Rows.Clear() : dtg_caixaDiario.Refresh()
            Dim usuario As String = ""
            While dr.Read
                Dim mlinha As String() = {dr(0).ToString, dr(1).ToString, dr(2), dr(3).ToString, dr(4).ToString, dr(5).ToString, _
                                          Format(dr(6), "###,##0.00"), Format(dr(7), "###,##0.00"), dr(8).ToString, dr(9).ToString}
                dtg_caixaDiario.Rows.Add(mlinha)
            End While
            dtg_caixaDiario.Refresh()

            chamaSomaTotais()
            SomaDivisoriaDr()
            SomaDivisoriaProt()
            conn.Close()
            conn = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

#Region " ** SOMAS **"

    Sub chamaSomaTotais()
        SomaTGeral()
        SomaTDinheiro()
        SomaTCartao()
        SomaTOrcamento()
    End Sub


    Sub SomaTGeral()
        Dim mSoma As Double

        For Each row As DataGridViewRow In dtg_caixaDiario.Rows
            If row.IsNewRow = False Then
                mSoma += row.Cells(6).Value
                mSoma += row.Cells(7).Value
            End If
        Next

        txt_totalGeral.Text = Format(Round(mSoma, 2), "###,##0.00")
    End Sub

    Sub SomaTDinheiro()
        Dim mSoma As Double

        For Each row As DataGridViewRow In dtg_caixaDiario.Rows
            If row.IsNewRow = False Then

                If row.Cells(8).Value.ToString.Equals("DN") Then mSoma += row.Cells(7).Value
            End If
        Next

        txt_totDinheiro.Text = Format(Round(mSoma, 2), "###,##0.00")
    End Sub

    Sub SomaTCartao()
        Dim mSoma As Double

        For Each row As DataGridViewRow In dtg_caixaDiario.Rows
            If row.IsNewRow = False Then
                If row.Cells(8).Value.ToString.Equals("CT") Then mSoma += row.Cells(7).Value
            End If
        Next

        txt_totCartao.Text = Format(Round(mSoma, 2), "###,##0.00")
    End Sub

    Sub SomaTOrcamento()
        Dim mSoma As Double

        For Each row As DataGridViewRow In dtg_caixaDiario.Rows
            If row.IsNewRow = False Then
                mSoma += row.Cells(6).Value
            End If
        Next

        txt_totOrca.Text = Format(Round(mSoma, 2), "###,##0.00")
    End Sub

    Sub SomaDivisoriaDr()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim consulta As String

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão:: " & ex.Message)
        End Try

        consulta = "SELECT Sum(cx_valor) FROM " & _geno.pEsquemaestab & ".caixadiario WHERE cx_data = '" & dtp_dia.Text & "' AND "
        consulta += "cx_tipo = 'D' AND cx_doutor = '" & _Dentista.Nome & "'"

        comm = New NpgsqlCommand(consulta, conn)
        dr = comm.ExecuteReader

        Try
            While dr.Read

                Try
                    txt_totDivDentista.Text = Format(dr(0), "###,##0.00")
                Catch ex As Exception
                    txt_totDivDentista.Text = "0,00"
                End Try

            End While

            conn.Close()
            conn = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Sub SomaDivisoriaProt()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim consulta As String

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão:: " & ex.Message)
        End Try

        consulta = "SELECT Sum(cx_valor) FROM " & _geno.pEsquemaestab & ".caixadiario WHERE cx_data = '" & dtp_dia.Text & "' AND "
        consulta += "cx_tipo = 'D' AND cx_doutor_old = '" & _Dentista.Nome & "' AND cx_driniciais = '" & _iniciaisProt & "'"

        comm = New NpgsqlCommand(consulta, conn)
        dr = comm.ExecuteReader

        Try
            While dr.Read

                Try
                    txt_totDivProt.Text = Format(dr(0), "###,##0.00")
                Catch ex As Exception
                    txt_totDivProt.Text = "0,00"
                End Try

            End While

            conn.Close()
            conn = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

#End Region

#Region "** Impressão **"

    Sub Imprimir()

        Try


            'IMPRESSÃO COM GRAFICOS     ...............................

            'cria uma nova instância do objeto PrintPreviewDialog
            Dim objPrintPreview As New PrintPreviewDialog
            objPrintPreview = PrintPreviewDialog1

            'define algumas propriedades do obejto
            With objPrintPreview

                'indica qual o documento vai ser visualizado
                .Document = pdRelatorio
                .WindowState = FormWindowState.Maximized
                .PrintPreviewControl.Zoom = 1   'maxima a visualização
                .Text = "Relatório de Controle Diário"

                'exibe a janela de visualização para o usuário
                .ShowDialog()


            End With

            objPrintPreview = Nothing : _leitorTabela.Close()

        Catch ex As Exception
        End Try

    End Sub


    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdRelatorio.PrintPage
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
        StringforPage = _StringToPrint.Substring(0, NumChars)

        ' Imprime a string na pagina atual
        e.Graphics.DrawString(StringforPage, _PrintFont, Brushes.Black, -10, recdraw.Top, Strformat)


        'For i As Integer = 1 To mQtdPaginas
        '    e.HasMorePages = True
        'Next

        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then

            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else

            e.HasMorePages = False

        End If

    End Sub

    Private Sub executaEspelhoNF_R(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\relatorios\TEMPcxdiario.TMP"
        Dim fs As New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)
        Dim s As New StreamWriter(fs)

        Dim mContPaginas As Integer = 0, mContQuebrasPag As Integer = 0
        Dim strLinha As String = ""
        Dim dtAtual As String = Format(Date.Now, "dd/MM/yyyy")
        Dim codEstab As String = Mid(MdlUsuarioLogando._local, _
                                     MdlUsuarioLogando._local.Length - 1, 2)


        _PrintFont = New Font("Lucida Console", 7) '126 Quebras de Linha padrao para esta configuração

        'Totais
        Dim lShouldReturn As Boolean
        Imprimir()
        If lShouldReturn Then Return

        ''Ler o Arquivo salvo...
        'executaEspelhoNF_RExtracted1(arqSaida, mArqTemp, fs, s)

        MostrarCaixaImpressoras = False
        _StringToPrint = ""
        s.Close()
        fs.Dispose()

    End Sub

    Private Sub rptGravaRDiario(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintPageEventArgs)

        'Asssumindo as Margens definidas pela impressora padrão
        Dim margemEsq As Single = Relatorio.MarginBounds.Left
        Dim margemSup As Single = Relatorio.MarginBounds.Top
        Dim margemDir As Single = Relatorio.MarginBounds.Right
        Dim margemInf As Single = Relatorio.MarginBounds.Bottom

        margemDir -= 700 : margemEsq += 700 : margemInf += 40

        'Trabalhando com Fontes
        Dim mFonteNormal, mFonteValor, mFonteDiaSemana, mFonteCabecalho, mFonteTotais, mFonteNota As Font
        mFonteNormal = New Font("Times New Roman", 9, FontStyle.Regular)
        mFonteValor = New Font("Times New Roman", 9, FontStyle.Bold)
        mFonteDiaSemana = New Font("Times New Roman", 13, FontStyle.Bold)
        mFonteCabecalho = New Font("Times New Roman", 12, FontStyle.Bold)
        mFonteTotais = New Font("Times New Roman", 12, FontStyle.Bold)
        mFonteNota = New Font("Times New Roman", 8.5, FontStyle.Bold)

        Dim mValoresFormat As New StringFormat
        mValoresFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft

        Dim posiY_aux As Int16 = -5
        Dim mLinhaAtualLetras As Double = 0
        Dim mLinhaAtualImagem As Integer = 0
        Dim mNumImpressCorrente As Integer = 0
        Dim mLinhaDoTrassado As Integer = 285

        Dim cor_valor As System.Drawing.SolidBrush = New SolidBrush(Color.Black)

        Dim extImagem As String = MdlEmpresaUsu.genp001.imagemCarne
        Dim mQtdeParcelas As String = ""
        mQtdeParcelas = 0


        mQtdPaginas += 1
        mLinhaAtualLetras -= 6
        If mQtdPaginas = 1 Then

            Try
                'Folha A4:
                Relatorio.Graphics.DrawImage(Image.FromFile(_pathContrFrent), -10, -5, 835, 1190)
            Catch ex As Exception
                MsgBox("Erro na Imagem: " & ex.Message) : Return
            End Try

            'Dia Semana:
            If txt_diaSemana.Text.Length > 7 Then
                Relatorio.Graphics.DrawString(txt_diaSemana.Text, mFonteDiaSemana, Brushes.Black, posiY_aux + 640, (48 + mLinhaAtualLetras), New StringFormat())
            Else
                Relatorio.Graphics.DrawString(txt_diaSemana.Text, mFonteDiaSemana, Brushes.Black, posiY_aux + 670, (48 + mLinhaAtualLetras), New StringFormat())
            End If

            'Cabeçalho:
            Relatorio.Graphics.DrawString(txt_nomeEmpresa.Text, mFonteCabecalho, Brushes.Black, posiY_aux + 160, (77 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(dtp_dia.Text, mFonteCabecalho, Brushes.Black, posiY_aux + 675, (77 + mLinhaAtualLetras), New StringFormat())
        Else

            Try
                'Folha A4:
                Relatorio.Graphics.DrawImage(Image.FromFile(_pathContrTras), -10, 0, 835, 1190)
            Catch ex As Exception
                MsgBox("Erro na Imagem: " & ex.Message) : Return
            End Try
        End If


        mLinhaAtualLetras = 120.5
        For Each row As DataGridViewRow In dtg_caixaDiario.Rows

            If row.IsNewRow = False Then

                cor_valor = Brushes.Black
                If Trim(row.Cells(5).Value.ToString).Equals("") = False Then
                    cor_valor = Brushes.Red
                End If
                If row.Cells(8).Value.ToString.ToUpper.Equals("CT") Then
                    cor_valor = Brushes.Green
                End If



                If mIndexGrid = 0 Then
                    'Imprime na parte da Frente:
                    Relatorio.Graphics.DrawString(Mid(row.Cells(0).Value.ToString, 1, 34), mFonteNormal, Brushes.Black, posiY_aux + 70, mLinhaAtualLetras, New StringFormat())
                    Relatorio.Graphics.DrawString(Mid(row.Cells(1).Value.ToString, 1, 10), mFonteNormal, Brushes.Black, posiY_aux + 380, mLinhaAtualLetras, New StringFormat())
                    If row.Cells(2).Value Then
                        Relatorio.Graphics.DrawString("X", mFonteNormal, Brushes.Black, posiY_aux + 463, mLinhaAtualLetras, New StringFormat())
                    End If
                    Relatorio.Graphics.DrawString(Mid(row.Cells(3).Value.ToString, 1, 6), mFonteNormal, Brushes.Black, posiY_aux + 493, mLinhaAtualLetras, New StringFormat())
                    Relatorio.Graphics.DrawString(Mid(row.Cells(4).Value.ToString, 1, 5), mFonteNormal, Brushes.Black, posiY_aux + 560, mLinhaAtualLetras, New StringFormat())
                    Relatorio.Graphics.DrawString(Mid(row.Cells(5).Value.ToString, 1, 4), mFonteNormal, Brushes.Black, posiY_aux + 610, mLinhaAtualLetras, New StringFormat())
                    Try
                        If CDbl(row.Cells(6).Value) > 0 Then
                            Relatorio.Graphics.DrawString(row.Cells(6).Value.ToString, mFonteValor, Brushes.Black, posiY_aux + 718, mLinhaAtualLetras, mValoresFormat)
                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        If CDbl(row.Cells(7).Value) > 0 Then

                            If Trim(row.Cells(9).Value.ToString).Equals("RA") Then
                                Relatorio.Graphics.DrawString(row.Cells(7).Value.ToString & "*", mFonteValor, cor_valor, posiY_aux + 800, mLinhaAtualLetras, mValoresFormat)
                            Else
                                Relatorio.Graphics.DrawString(row.Cells(7).Value.ToString, mFonteValor, cor_valor, posiY_aux + 800, mLinhaAtualLetras, mValoresFormat)
                            End If

                        Else
                            If Trim(row.Cells(9).Value.ToString).Equals("RA") Then
                                Relatorio.Graphics.DrawString("*", mFonteValor, cor_valor, posiY_aux + 800, mLinhaAtualLetras, mValoresFormat)
                            End If
                        End If
                    Catch ex As Exception
                    End Try


                Else

                    If row.Index > mIndexGrid Then
                        'Imprime na parte de Trás:

                    End If
                End If

                mLinhaAtualLetras += 21
                mQtdRegistros += 1
                If mQtdRegistros = 48 Then mIndexGrid = row.Index : mQtdPaginas += 1 : Exit For
            End If



        Next

        '***************************************              TOTAIS           ****************************************
        Dim mvalorAux As String = ""
        mLinhaAtualLetras = 1025

        'Geral...
        Relatorio.Graphics.DrawString(dtg_caixaDiario.Rows.Count, mFonteTotais, Brushes.Black, posiY_aux + 195, mLinhaAtualLetras, New StringFormat())
        Relatorio.Graphics.DrawString(txt_totalGeral.Text, mFonteTotais, Brushes.Black, posiY_aux + 330, mLinhaAtualLetras, mValoresFormat)

        'Orça...
        mLinhaAtualLetras += 27
        Relatorio.Graphics.DrawString(_qtdeOrcamentos, mFonteTotais, Brushes.Black, posiY_aux + 195, mLinhaAtualLetras, New StringFormat())
        Relatorio.Graphics.DrawString(txt_totOrca.Text, mFonteTotais, Brushes.Black, posiY_aux + 330, mLinhaAtualLetras, mValoresFormat)

        'Fichas Atendidas Dentista...
        mLinhaAtualLetras += 27
        Relatorio.Graphics.DrawString(_qtdeFichasAtendDr, mFonteTotais, Brushes.Black, posiY_aux + 195, mLinhaAtualLetras, New StringFormat())
        mvalorAux = Format(Round(CDbl(txt_totalGeral.Text) - CDbl(txt_totOrca.Text), 2), "###,##0.00")
        Relatorio.Graphics.DrawString(mvalorAux, mFonteTotais, Brushes.Black, posiY_aux + 330, mLinhaAtualLetras, mValoresFormat)
        Relatorio.Graphics.DrawString(txt_totDivDentista.Text, mFonteTotais, Brushes.Black, posiY_aux + 440, mLinhaAtualLetras, mValoresFormat)
        Relatorio.Graphics.DrawString(Mid(_Dentista.Iniciais, 1, 4), mFonteTotais, Brushes.Black, posiY_aux + 460, mLinhaAtualLetras, New StringFormat())

        'Fichas Atendidas Protetico...
        mLinhaAtualLetras += 27
        Relatorio.Graphics.DrawString(_qtdeFichasAtendProt, mFonteTotais, Brushes.Black, posiY_aux + 195, mLinhaAtualLetras, New StringFormat())
        Relatorio.Graphics.DrawString(Format(Round(_valorFichasAtendProt, 2), "###,##0.00"), mFonteTotais, Brushes.Black, posiY_aux + 330, mLinhaAtualLetras, mValoresFormat)
        Relatorio.Graphics.DrawString(txt_totDivProt.Text, mFonteTotais, Brushes.Black, posiY_aux + 440, mLinhaAtualLetras, mValoresFormat)
        Relatorio.Graphics.DrawString(Mid(_iniciaisProt, 1, 4), mFonteTotais, Brushes.Black, posiY_aux + 460, mLinhaAtualLetras, New StringFormat())

        'Info:
        Relatorio.Graphics.DrawString("*  Valor pago anteriormente!", mFonteNota, Brushes.Black, posiY_aux + 25, mLinhaAtualLetras + 25, New StringFormat())

        If dtg_caixaDiario.Rows.Count > 48 Then
            Relatorio.HasMorePages = True

        Else
            Relatorio.HasMorePages = False
        End If
        mQtdPaginas = 0




    End Sub

    Private Sub InicializaRelatorio(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintEventArgs)

        If MostrarCaixaImpressoras Then


            Dim Impressora As New PrintDialog
            Impressora.AllowCurrentPage = True : Impressora.AllowSomePages = True
            If Impressora.ShowDialog() = DialogResult.Cancel Then

                Relatorio.Cancel = True

            Else

                Try

                    pdRelatorio.PrinterSettings = Impressora.PrinterSettings
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
        End If
        MostrarCaixaImpressoras = True



    End Sub

#End Region

    Private Sub btn_Relatorio_Click(sender As Object, e As EventArgs) Handles btn_Relatorio.Click

        ExecutaF6()

    End Sub

    Private Sub dtg_caixaDiario_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtg_caixaDiario.RowsAdded

        If dtg_caixaDiario.Rows(e.RowIndex).Cells(2).Value Then 'Se for Orçamento...
            _qtdeOrcamentos += 1
        Else
            _qtdeFichasAtendDr += 1
            _valorFichasAtendDr += CDbl(dtg_caixaDiario.Rows(e.RowIndex).Cells(7).Value)
            If Trim(dtg_caixaDiario.Rows(e.RowIndex).Cells(5).Value.ToString).Equals("") = False Then
                _qtdeFichasAtendProt += 1
                _valorFichasAtendProt += CDbl(dtg_caixaDiario.Rows(e.RowIndex).Cells(7).Value)
                If _iniciaisProt.Equals("") Then _iniciaisProt = dtg_caixaDiario.Rows(e.RowIndex).Cells(5).Value.ToString
            End If

        End If

    End Sub

    Private Sub txt_totDivDentista_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_totDivProt.KeyPress, txt_totDivDentista.KeyPress
        'permite só numeros com virgula:
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub


    Private Sub txt_totDivProt_Leave(sender As Object, e As EventArgs) Handles txt_totDivProt.Leave

        If Me.txt_totDivProt.Text.Equals("") Then Me.txt_totDivProt.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_totDivProt.Text) Then
            If CDec(Me.txt_totDivProt.Text) < 0 Then
                MsgBox("Valor Div. do Protético deve ser Maior ou Igual a ZERO !")
                txt_totDivProt.Focus()
                Return

            End If
            Me.txt_totDivProt.Text = Format(CDec(Me.txt_totDivProt.Text), "###,##0.00")

        Else
            MsgBox("Valor Div. do Protético não é Numérico !")
            txt_totDivProt.Focus() : txt_totDivProt.SelectAll()
            Return

        End If


    End Sub

    Private Sub txt_totDivDentista_Leave(sender As Object, e As EventArgs) Handles txt_totDivDentista.Leave

        If Me.txt_totDivDentista.Text.Equals("") Then Me.txt_totDivDentista.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_totDivDentista.Text) Then
            If CDec(Me.txt_totDivDentista.Text) < 0 Then
                MsgBox("Valor Div. Dentista deve ser Maior ou Igual a ZERO !")
                txt_totDivDentista.Focus()
                Return

            End If
            Me.txt_totDivDentista.Text = Format(CDec(Me.txt_totDivDentista.Text), "###,##0.00")

        Else
            MsgBox("Valor Div. Dentista não é Numérico !")
            txt_totDivDentista.Focus() : txt_totDivDentista.SelectAll()
            Return

        End If


    End Sub

End Class