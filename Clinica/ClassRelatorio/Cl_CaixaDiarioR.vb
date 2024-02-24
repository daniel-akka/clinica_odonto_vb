Imports Npgsql
Imports System.IO
Imports System.Text
Imports System.Math
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog

Public Class Cl_CaixaDiarioR

    Public _Geno As New Cl_Geno
    Public _dataInicial, _dataFinal As String
    Private _clFuncoes As New ClFuncoes
    Private _sw As Cl_EscreveArquivo

    'objetos para impressão
    Private MostrarCaixaImpressoras As Boolean = False
    Private _PrintFont, _PrintFont1 As New Font("Lucida Console", 8) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _StringToPrint As String = "", _stringToPrintAux As String = ""
    Private _mConsulta As New StringBuilder
    Private _sImpressao As StreamWriter
    Private _dtAdaptPrint As NpgsqlDataAdapter
    Private PrintPreviewDialog1 As New PrintPreviewDialog
    Private pdRelatorio, pdRelatPedidos, pdRelatConsulta As New PrintDocument
    Private PrintDialog1 As New PrintDialog

    Sub New()

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos.BeginPrint, AddressOf InicializaRelatorio
        AddHandler pdRelatPedidos.PrintPage, AddressOf pdRelatPedidos_PrintPage

        AddHandler pdRelatConsulta.BeginPrint, AddressOf InicializaRelatorio
        AddHandler pdRelatConsulta.PrintPage, AddressOf pdRelatConsulta_PrintPage
    End Sub

    Sub GravCabecalhoConsulta()

        _sw.EscreveLn(_clFuncoes.Centraliza_Str("PESQUISA", 110))
        _sw.EscreveLn(vbNewLine & vbNewLine)
        _sw.EscreveLn(_clFuncoes.Exibe_StrEsquerda("Empresa: " & _Geno.pGeno, 67) & _clFuncoes.Exibe_StrDireita("Período: " & _dataInicial & " A " & _dataFinal, 40))
        _sw.EscreveLn(vbNewLine)
        _sw.EscreveLn(" Tipo:      Cliente:                            Dentista:           Descr.:                      TOTAL ")
        '               x    xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx  xxxxxxxxxZxxxxxxxxxZ xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZ 99,999.99  
        _sw.EscreveLn("-----------------------------------------------------------------------------------------------------------")

    End Sub

    Sub GravCabecalhoConsulta02()

        _sw.EscreveLn("                    C O N T I N U A C A O . . .        FOLHA: " & String.Format("{0:D3}", _sw.paginaAtual))
        _sw.EscreveLn("+---------------------------------------------------------------------------------------------------------+")
        _sw.EscreveLn(vbNewLine)
        _sw.EscreveLn(" Tipo:      Cliente:                            Dentista:           Descr.:                      TOTAL ")
        '               x    xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx  xxxxxxxxxZxxxxxxxxxZ xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZ 99,999.99  
        _sw.EscreveLn("-----------------------------------------------------------------------------------------------------------")

    End Sub

    Sub GravRodapeConsulta()

        _sw.EscreveLnAux("")
        _sw.EscreveLnAux("+---------------------------------------------------------------------------------------------------------+")
        _sw.EscreveLnAux(" *** CONTINUACAO DA PESQUISA TRANSPORTADO PARA FOLHA SEGUINTE **  ")
        _sw.EscreveLnAux("+---------------------------------------------------------------------------------------------------------+")
       
    End Sub

    Public Sub ExecutaF6(consulta As String)

        'Grava informações dos Agendamentos no arquivo de saida...
        Dim unidadePC As String = "", arqSaida As String = "\wged\relatorios\CaixaDiarioR.TXT"
        Dim mArqTemp As String = "\wged\tmp\TEMP_CaixaDiarioR.TMP"
        Dim fs As New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Dim mContPaginas As Integer = 0, mContQuebrasPag As Integer = 0
        Dim dtAtual As String = Format(Date.Now, "dd/MM/yyyy")
        Dim codEstab As String = Mid(_Geno.pCodig, _Geno.pCodig.Length - 1, 2)


        _sw = New Cl_EscreveArquivo(fs)
        _sw.chamaEvento = True
        _sw.contarRegistros = True
        _sw.chamaEventoAntesSaltos = True
        'relaciona o objeto ao procedimento:
        AddHandler _sw.SaltandoLinhasEvento, AddressOf GravCabecalhoConsulta02
        AddHandler _sw.EventoAntesSalto, AddressOf GravRodapeConsulta
        _sw.qtdLinhasPorPagina = 42
        _sw.qtdSaltosLinhaNextPag = 11

        _PrintFont1 = New Font("Lucida Console", 10)

        GravCabecalhoConsulta()
        GravaConsulta(consulta, _sw)

        'Deleta o arquivo temporário...
        _sw.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        _sw.Dispose()
        Try
            File.Delete(mArqTemp)
        Catch ex As Exception
        End Try


        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvoConsulta()

    End Sub

    Public Sub GravaConsulta(ByVal consulta As String, ByRef s As Cl_EscreveArquivo)

        Dim _valorZERO As Int16 = 0
        Try
            Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mCodAgend, mNomeCli, Doutor, strLinha, mTipo, mDescricao As String
            Dim mVlTotConsulta As Double
            Dim mSomaTotProd As Double
            strLinha = "" : Doutor = ""
            Dim mCont1, mCont2, index, mContRegImpressos, mQtdeTotalRegistros As Integer

            Try
                oConn.Open()

            Catch ex As Exception
            End Try

            Dim sqlItem As New StringBuilder
            Dim cmdItem As NpgsqlCommand
            Dim drItem As NpgsqlDataReader
            Dim mContItens As Integer = _valorZERO, mContItensPg As Integer = _valorZERO, mContPg As Integer = _valorZERO


            sqlItem.Append(consulta)

            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConn)
            drItem = cmdItem.ExecuteReader


            mSomaTotProd = _valorZERO
            mContPg = 1
            While drItem.Read


                mTipo = drItem(0).ToString
                mNomeCli = drItem(1).ToString
                Doutor = drItem(2).ToString
                mDescricao = drItem(3).ToString
                mVlTotConsulta = drItem(4)

                mSomaTotProd += mVlTotConsulta

                strLinha = "   " & mTipo & "    " & _
                _clFuncoes.Exibe_StrEsquerda(mNomeCli, 35) & "  " & _
                _clFuncoes.Exibe_StrEsquerda(Doutor, 20) & " " & _
                _clFuncoes.Exibe_StrEsquerda(mDescricao, 30) & " " & _
                _clFuncoes.Exibe_StrDireita(Format(mVlTotConsulta, "###,##0.00"), 9)

                s.contRegistros += 1
                s.EscreveLn(_clFuncoes.Exibe_Str(strLinha, 110))
                mContRegImpressos += 1
                If mQtdeTotalRegistros = 0 Then mQtdeTotalRegistros = drItem(5) : s.qtdeRegistros = mQtdeTotalRegistros
                If mContRegImpressos = mQtdeTotalRegistros Then s.aindaTemItens = False

            End While
            drItem.Close()

            If (_sw.qtdLinhasPorPagina - _sw.contLinhasPorPagina) > 15 Then
                _sw.SaltandoLinhasComEscreveLn(10)
            End If


            If mSomaTotProd > _valorZERO Then

                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.EscreveLn("+---------------------------------------------------------------------------------------------------------+")
                strLinha = _clFuncoes.Exibe_StrEsquerda(" TOTAIS ---> ", 25) & _clFuncoes.Exibe_StrDireita(mContRegImpressos, 5)
                If mContRegImpressos > 1 Then
                    strLinha += " - Registros"
                Else
                    strLinha += " - Registro "
                End If
                strLinha = _clFuncoes.Exibe_StrEsquerda(strLinha, 58)
                strLinha += _clFuncoes.Exibe_StrDireita("| " & _clFuncoes.Exibe_StrDireita(Format(Round(mSomaTotProd, 2), "#,###,##0.00"), 12) & " |", 49)
                s.EscreveLn(_clFuncoes.Exibe_Str(strLinha, 110))
                s.EscreveLn("+---------------------------------------------------------------------------------------------------------+")


                s.EscreveLn("")
            End If

            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodAgend = Nothing
            mNomeCli = Nothing : mVlTotConsulta = Nothing

            oConn.ClearAllPools() : oConn.Close() : oConn = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar Regitros da Consulta", MsgBoxStyle.Exclamation)
            Return

        End Try



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

    Private Sub VisuConteArqSalvoConsulta()

        Try
            ' Especifica as configurações da pagina atual
            pdRelatConsulta.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatConsulta.DefaultPageSettings.Margins.Top = 12
            pdRelatConsulta.DefaultPageSettings.Margins.Right = 12
            pdRelatConsulta.DefaultPageSettings.Margins.Left = 5
            pdRelatConsulta.DefaultPageSettings.Margins.Bottom = 5
            '========================================================


            'Orientação do papel...
            pdRelatConsulta.DefaultPageSettings.Landscape = True
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando PESQUISA"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatConsulta
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub GeraRelatorio(ByRef s As StreamWriter)

        Dim strLinha As String = ""
        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try


        Try

            'IMPRESSÃO COM GRAFICOS     ...............................
            'cria uma nova instância do objeto PrintPreviewDialog
            Dim objPrintPreview As New PrintPreviewDialog
            objPrintPreview = PrintPreviewDialog1

            'define algumas propriedades do obejto
            With objPrintPreview

                'indica qual o documento vai ser visualizado
                .Document = pdRelatorio
                '.Document.OriginAtMargins = True
                .WindowState = FormWindowState.Maximized
                .PrintPreviewControl.Zoom = 1   'maxima a visualização
                .Text = "AGENDAMENTO"

                'exibe a janela de visualização para o usuário
                .ShowDialog()


            End With

            objPrintPreview = Nothing : _leitorTabela.Close()

        Catch ex As Exception
        End Try



        'LIMPA OBJETOS DA MEMÓRIA...
        oConn.Close() : oConn = Nothing



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

    Private Sub pdRelatPedidos_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

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

        ' Imprime a string na pagina atual
        'e.Graphics.DrawLine(Pens.Black, 200, 400, 200, 400)
        e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 80, 100, New StringFormat())


        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False '_stringToPrintAux = _StringToPrint

        End If



    End Sub

    Private Sub pdRelatConsulta_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

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

        ' Imprime a string na pagina atual
        'e.Graphics.DrawLine(Pens.Black, 200, 400, 200, 400)
        e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 100, 70, New StringFormat())


        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False '_stringToPrintAux = _StringToPrint

        End If



    End Sub


End Class
