Imports Npgsql
Imports System.IO
Imports System.Text
Imports System.Math
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog

Public Class Cl_AgendamentosR

    Public _Agend1 As New Cl_Agendamento1
    Public _Agend2 As New Cl_Agendamento2
    Public _Cliente As New Cl_Cadp001
    Public _Geno As New Cl_Geno

    Private _clFuncoes As New ClFuncoes
    Public _dataInicial, _dataFinal As String
    Dim _sw As Cl_EscreveArquivo

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

        ''relaciona o objeto pd ao procedimento rptGravaTotaisNF
        'AddHandler pdRelatorio.PrintPage, AddressOf rptGravaRelatorio

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos.BeginPrint, AddressOf InicializaRelatorio
        AddHandler pdRelatPedidos.PrintPage, AddressOf pdRelatPedidos_PrintPage

        AddHandler pdRelatConsulta.BeginPrint, AddressOf InicializaRelatorio
        AddHandler pdRelatConsulta.PrintPage, AddressOf pdRelatConsulta_PrintPage
    End Sub

    Public Sub executaF6()
        executaEspelhoNF_R("", "\wged\relatorios\Agendamento.TXT")
    End Sub

    Sub GravaCabecalhoConsulta()

        _sw.EscreveLn(_clFuncoes.Centraliza_Str("CONSULTA", 100))
        _sw.EscreveLn(vbNewLine)
        _sw.EscreveLn(_clFuncoes.Exibe_StrEsquerda("Empresa: " & _Geno.pGeno, 55) & _clFuncoes.Exibe_StrDireita("Período: " & _dataInicial & " A " & _dataFinal, 40))
        _sw.EscreveLn("")
        _sw.EscreveLn(" Cod.    Cliente.                             Dentista                  Dt. Agenda Canc  TOTAL ")
        '            xxxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx  xxxxxxxxxZxxxxxxxxxZzzzzz xxxxxxxxxZ    x  999,999.99  
        _sw.EscreveLn("-------------------------------------------------------------------------------------------------")

    End Sub

    Sub GravCabecalhoConsulta02()

        _sw.EscreveLn("                    C O N T I N U A C A O . . .        FOLHA: " & String.Format("{0:D3}", _sw.paginaAtual))
        _sw.EscreveLn("+-----------------------------------------------------------------------------------------------+")
        _sw.EscreveLn(vbNewLine)
        _sw.EscreveLn(" Cod.    Cliente.                             Dentista                  Dt. Agenda Canc  TOTAL ")
        '            xxxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx  xxxxxxxxxZxxxxxxxxxZzzzzz xxxxxxxxxZ  xxx 9,999,999.99  
        _sw.EscreveLn("-------------------------------------------------------------------------------------------------")

    End Sub

    Sub GravRodapeConsulta()

        _sw.EscreveLnAux("")
        _sw.EscreveLnAux("+-----------------------------------------------------------------------------------------------+")
        _sw.EscreveLnAux(" *** CONTINUACAO DA CONSULTA TRANSPORTADO PARA FOLHA SEGUINTE **  ")
        _sw.EscreveLnAux("+-----------------------------------------------------------------------------------------------+")

    End Sub

    Public Sub ExecutaF11(consulta As String, dataInicial As String, dataFinal As String)

        'Grava informações dos Agendamentos no arquivo de saida...
        Dim unidadePC As String = "", arqSaida As String = "\wged\relatorios\AgendamentoC.TXT"
        Dim mArqTemp As String = "\wged\tmp\TEMP_AgendamentoC.TMP"
        Dim fs As New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Dim mContPaginas As Integer = 0, mContQuebrasPag As Integer = 0
        Dim dtAtual As String = Format(Date.Now, "dd/MM/yyyy")
        Dim codEstab As String = Mid(_Geno.pCodig, _Geno.pCodig.Length - 1, 2)

        _dataInicial = dataInicial
        _dataFinal = dataFinal

        _sw = New Cl_EscreveArquivo(fs)
        _sw.chamaEvento = True
        _sw.contarRegistros = True
        _sw.chamaEventoAntesSaltos = True
        'relaciona o objeto ao procedimento:
        AddHandler _sw.SaltandoLinhasEvento, AddressOf GravCabecalhoConsulta02
        AddHandler _sw.EventoAntesSalto, AddressOf GravRodapeConsulta
        _sw.qtdLinhasPorPagina = 75
        _sw.qtdSaltosLinhaNextPag = 11


        _PrintFont1 = New Font("Lucida Console", 9)

        GravaCabecalhoConsulta()
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
            Dim mCodAgend, mNomeCli, Doutor, strLinha, dtagenda, cancelado As String
            Dim mVlTotConsulta As Double
            Dim mSomaTotProd As Double
            strLinha = "" : Doutor = ""
            Dim mCont1, mCont2, index, mContRegImpressos, mQtdeTotRegConsulta As Integer

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


                mCodAgend = String.Format("{0:D7}", drItem(0))
                mNomeCli = drItem(1).ToString
                Doutor = drItem(2).ToString
                dtagenda = Format(drItem(3), "dd/MM/yyyy")
                mVlTotConsulta = drItem(4)
                cancelado = "N"
                If drItem(5) Then cancelado = "S"

                mSomaTotProd += mVlTotConsulta

                strLinha = " " & _clFuncoes.Exibe_StrEsquerda(mCodAgend, 7) & " " & _
                _clFuncoes.Exibe_StrEsquerda(mNomeCli, 35) & " " & _
                _clFuncoes.Exibe_StrEsquerda(Doutor, 25) & " " & _
                _clFuncoes.Exibe_StrEsquerda(dtagenda, 10) & "   " & _
                _clFuncoes.Centraliza_Str(cancelado, 1) & " " & _
                _clFuncoes.Exibe_StrDireita(Format(mVlTotConsulta, "###,##0.00"), 9)

                s.contRegistros += 1
                s.EscreveLn(_clFuncoes.Exibe_Str(strLinha, 100))
                mContRegImpressos += 1
                If mQtdeTotRegConsulta = 0 Then mQtdeTotRegConsulta = drItem(6) : s.qtdeRegistros = mQtdeTotRegConsulta
                If mContRegImpressos = mQtdeTotRegConsulta Then s.aindaTemItens = False

                mContItens += 1 : mContItensPg += 1
                mCont1 -= 1 : mCont2 -= 1


            End While
            drItem.Close()

            If (s.qtdLinhasPorPagina - s.contLinhasPorPagina) > 25 Then
                s.SaltandoLinhasComEscreveLn(20)
            End If


            If mSomaTotProd > _valorZERO Then

                '                      1        2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.EscreveLn("+-----------------------------------------------------------------------------------------------+")
                strLinha = _clFuncoes.Exibe_StrEsquerda(" TOTAIS ---> ", 25) & _clFuncoes.Exibe_StrDireita(mContItens, 5)
                If mContItens > 1 Then
                    strLinha += " - Registros"
                Else
                    strLinha += " - Registro "
                End If
                strLinha = _clFuncoes.Exibe_StrEsquerda(strLinha, 48)
                strLinha += _clFuncoes.Exibe_StrDireita("| " & _clFuncoes.Exibe_StrDireita(Format(Round(mSomaTotProd, 2), "#,###,##0.00"), 12) & " |", 49)
                s.EscreveLn(_clFuncoes.Exibe_Str(strLinha, 100))
                s.EscreveLn("+-----------------------------------------------------------------------------------------------+")


                s.EscreveLn("")
            End If

            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodAgend = Nothing
            mNomeCli = Nothing : mVlTotConsulta = Nothing

            oConn.ClearAllPools() : oConn.Close() : oConn = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) do Agendamento", MsgBoxStyle.Exclamation)
            Return

        End Try



    End Sub

    Private Sub executaRelatorio1(ByVal s As Cl_EscreveArquivo, ByVal loja As String, ByVal numeroOrcamento As String, ByVal dtEmissao As String, ByVal codClient As String, ByVal nomeClient As String, ByVal condicao As String, ByVal codVendedor As String, ByVal idOrca1 As Int32, ByRef shouldReturn As Boolean)

        shouldReturn = False
        s.WriteLine("")

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Loja
        _mConsulta.Append("SELECT g_geno, g_ender, g_fone, g_uf, g_cid FROM geno001 WHERE g_codig = '" & loja & "'")
        Dim lShouldReturn1 As Boolean
        _clFuncoes.GravCabLojAgendMatricial(_mConsulta.ToString, s, loja, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Cliente
        _mConsulta.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
        _mConsulta.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & codClient & "'")
        Dim lShouldReturn2 As Boolean
        _clFuncoes.GravCabCliAgendMatricial(_mConsulta.ToString, s, codClient, numeroOrcamento, dtEmissao, codVendedor, condicao, loja, _Agend1, lShouldReturn2)
        If lShouldReturn2 Then shouldReturn = True : Return

        'Agendamento
        s.WriteLine("-------------------------------------------------------------------------------------")
        s.WriteLine(_clFuncoes.Centraliza_Str("AGENDAMENTO Nº " & String.Format("{0:D8}", _Agend1.a_id), 85) & vbNewLine)


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'itens
        _mConsulta.Append("SELECT a2_codserv, a2_descrserv, a2_valor, a2_qtde, a2_total FROM " & _Geno.pEsquemaestab & ".tb_agend2 WHERE ") '10
        _mConsulta.Append("a2_id1 = " & _Agend1.a_id)
        Dim lShouldReturn3 As Boolean
        _clFuncoes.GravServicosAgendMatricial(_mConsulta.ToString, s, numeroOrcamento, idOrca1, codClient, nomeClient, lShouldReturn3)
        If lShouldReturn3 Then shouldReturn = True : Return

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

    Private Sub VisuConteArqSalvo1()

        Try
            ' Especifica as configurações da pagina atual
            pdRelatPedidos.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatPedidos.DefaultPageSettings.Margins.Top = 12
            pdRelatPedidos.DefaultPageSettings.Margins.Right = 12
            pdRelatPedidos.DefaultPageSettings.Margins.Left = 10
            pdRelatPedidos.DefaultPageSettings.Margins.Bottom = 8
            '========================================================

            'Orientação em Paisagem...
            Select Case MdlRelatorioTelas._tl_movorcamento
                Case 1 'Impressora Matricial
                    pdRelatPedidos.DefaultPageSettings.Landscape = True
                Case 2 'Impressora Laiser
                    pdRelatPedidos.DefaultPageSettings.Landscape = False
                Case Else
                    pdRelatPedidos.DefaultPageSettings.Landscape = True
            End Select
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando AGENDAMENTO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatPedidos
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

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
            pdRelatConsulta.DefaultPageSettings.Landscape = False
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando CONSULTA"

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

    Private Sub executaEspelhoNF_R(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações dos Agendamentos no arquivo de saida...
        Dim mArqTemp As String = "\wged\tmp\TEMP_Agendamento.TMP"
        Dim fs As New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Dim mContPaginas As Integer = 0, mContQuebrasPag As Integer = 0
        Dim dtAtual As String = Format(Date.Now, "dd/MM/yyyy")
        Dim codEstab As String = Mid(_Geno.pCodig, _Geno.pCodig.Length - 1, 2)


        Dim s As New Cl_EscreveArquivo(fs)
        _PrintFont1 = New Font("Lucida Console", 9)
        Dim strLinha As String = ""
        Dim loja As String = _Geno.pCodig
        Dim numeroOrcamento As String = String.Format("{0:D8}", _Agend1.a_id)
        Dim dtEmissao As String = Format(_Agend1.a_dtemis, "dd/MM/yyyy")
        Dim codClient As String = _Cliente.pCod
        Dim nomeClient As String = _Cliente.pPortad
        Dim condicao As String = ""
        Dim codVendedor As String = ""
        Dim idOrca1 As Int32 = _Agend1.a_id

        Select Case MdlRelatorioTelas._tl_movorcamento

            Case 1 'Impressora Matricial
                Dim lShouldReturn As Boolean
                executaRelatorio1(s, loja, numeroOrcamento, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
                If lShouldReturn Then Return

            Case 2 'Impressora Laiser
                Dim lShouldReturn As Boolean
                executaRelatorio1(s, loja, numeroOrcamento, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
                If lShouldReturn Then Return

            Case Else
                Dim lShouldReturn As Boolean
                executaRelatorio1(s, loja, numeroOrcamento, dtEmissao, codClient, nomeClient, condicao, codVendedor, idOrca1, lShouldReturn)
                If lShouldReturn Then Return

        End Select


        'Deleta o arquivo temporário...
        s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        s.Dispose()
        Try
            File.Delete(mArqTemp)
        Catch ex As Exception
        End Try


        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo1()


        'Try
        '    GeraRelatorio(s)
        'Catch ex As Exception
        '    MsgBox("Deu erro ao gravar os totais da Nota", MsgBoxStyle.Exclamation)
        '    Return

        'End Try

        _StringToPrint = ""


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

    Private Sub rptGravaRelatorio(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintPageEventArgs)

        'Asssumindo as Margens definidas pela impressora padrão
        Dim margemEsq As Single = Relatorio.MarginBounds.Left
        Dim margemSup As Single = Relatorio.MarginBounds.Top
        Dim margemDir As Single = Relatorio.MarginBounds.Right
        Dim margemInf As Single = Relatorio.MarginBounds.Bottom

        Dim drawFormat As New StringFormat
        drawFormat.FormatFlags = StringFormatFlags.LineLimit

        'Trabalhando com Fontes
        Dim fonteNormalBold, fonteTituloNormal, fonteTituloNBold, fonteNormal As Font

        fonteTituloNormal = New Font("Times New Roman", 13)
        fonteTituloNBold = New Font("Times New Roman", 13, FontStyle.Bold)
        fonteNormalBold = New Font("Times New Roman", 12, FontStyle.Bold)
        fonteNormal = New Font("Times New Roman", 12)

        Dim linhadeimpressao As New SizeF(Relatorio.MarginBounds.Width, fonteNormal.Height)
        Dim caracteres As Integer = 0
        Dim strLinha As String = ""
        Dim strLinhaX As String = "", strLinhaXAux As String = ""
        Dim linhas As Integer
        Dim posicaoN As Integer = 0
        Dim carac As String = ""
        Dim numCaracAux As Integer = 0
        Dim IsNumeroDuplic As Boolean = False
        Dim linhaAtual As Int16 = 0

        ' Este é o controle de página, assim eu vou saber quando tenho que ir para
        ' a próxima página, se necessário.
        Dim y As Integer = Relatorio.MarginBounds.Top + 140

        Dim posicaoLinha As Double = 0
        Dim contador As Integer = 8


        ' Empresa: AC CONSTRUCOES PICOS LTDA                          Ender.: RUA CENTRAL, S/N
        ' Cidade: SUSSUAPARA                         UF: PI Fone: 8934153008  Data: 25/05/2015
        ' Cliente: ADAILDO PERIERA DA SILVA          CPF: 305.049.963-04             Pag.: 001
        '-------------------------------------------------------------------------------------
        '                                ORÇAMENTO Nº 00000011                               

        'posicaoLinha = margemSup + (linhaAtual * fonteNormal.GetHeight(Relatorio.Graphics))

        'Cabecalho...
        strLinha = "Empresa: " & _clFuncoes.Exibe_StrEsquerda(_Geno.pGeno, 40)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemEsq, 60, New StringFormat())
        strLinha = "Ender.: " & _clFuncoes.Exibe_StrDireita(_Geno.pEnder, 40)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir, 60, New StringFormat())

        strLinha = "Cidade: " & _clFuncoes.Exibe_StrEsquerda(_Geno.pCid, 30) & "UF: " & _clFuncoes.Exibe_StrEsquerda(_Geno.pUf, 5)
        strLinha += "Fone: " & _clFuncoes.Exibe_StrEsquerda(_Geno.pFone, 12)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemEsq, 85, New StringFormat())
        strLinha = _clFuncoes.Exibe_StrDireita("Data: " & Format(Date.Now, "dd/MM/yyyy"), 17)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir, 85, New StringFormat())

        strLinha = "Cliente: " & _clFuncoes.Exibe_StrEsquerda(_Cliente.pPortad, 40) & "CPF.: "
        strLinha += _clFuncoes.Exibe_StrEsquerda(String.Format("{0:000\.000\.000\-00}", Convert.ToInt64(_Cliente.pCpf)), 15)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemEsq, 110, New StringFormat())
        strLinha = _clFuncoes.Exibe_StrEsquerda("Pag. 001", 10)
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, margemDir, 110, New StringFormat())

        Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, 130, margemDir, 130)


        ''Título...
        'Relatorio.Graphics.DrawString("R$ ", fonteReal, Brushes.Black, margemDir - 100, 200, New StringFormat())
        'Relatorio.Graphics.DrawString(Me.txt_valor.Text, fonteReal_, Brushes.Black, margemDir - 70, 199, New StringFormat())

        'posicaoLinha = (margemSup) + (contador * fonteNormal.GetHeight(Relatorio.Graphics)) \ 1


        'strLinha = "Recebi de " & _Cliente.pPortad & ", a importância de " & "R$ " & _
        'Me.txt_valor.Text & " (" & _clFunc.NumeroToExtenso(Me.txt_valor.Text) & "), referente ao pagamento " & _
        '"parcial do documento Nº " & Me.txt_documento.Text & " vencimento em " & Me.msk_vencto.Text & "." & _
        'vbNewLine


        'While strLinha.Length > 0


        '    ' Obtenho o número de caracteres que vou conseguir imprimir na linha
        '    ' que eu especifiquei o tamanho. No caso, é a variável caracteres que
        '    ' me importa aqui abaixo.
        '    Relatorio.Graphics.MeasureString(strLinha, fonteNormal, linhadeimpressao, StringFormat.GenericDefault, caracteres, linhas)


        '    strLinhaX = strLinha.Substring(0, caracteres)
        '    For indice As Integer = 1 To 3

        '        carac = strLinha.Substring(0, caracteres)
        '        carac = carac.Substring(carac.Length - indice, 1)
        '        IsNumeroDuplic = False
        '        If IsNumeric(carac) Then IsNumeroDuplic = True
        '        If _clFunc.IsVogal(carac) AndAlso (indice > 1) Then

        '            strLinhaX = strLinha.Substring(0, caracteres - (indice - 1)) & "-"
        '            strLinhaXAux = strLinhaX & strLinha.Substring(caracteres - (indice - 1))
        '            strLinha = strLinhaXAux
        '            Exit For

        '        ElseIf carac.Equals(" ") Then

        '            If indice > 1 Then
        '                strLinhaX = strLinha.Substring(0, caracteres - (indice - 1))
        '                strLinhaXAux += strLinhaX & strLinha.Substring(caracteres - (indice - 1))
        '            Else
        '                strLinhaX = strLinha.Substring(0, caracteres)
        '                strLinhaXAux = strLinhaX & strLinha.Substring(caracteres - 1)
        '            End If
        '            strLinha = strLinhaXAux
        '            Exit For
        '        ElseIf _clFunc.IsVogal(carac) Then
        '            Exit For
        '        End If

        '    Next

        '    posicaoN = InStr(strLinha.Substring(0, strLinhaX.Length), "Nº ", CompareMethod.Text)
        '    If posicaoN > 0 Then 'Achou o Nº__________

        '        If (caracteres - (posicaoN + 2)) >= 10 Then

        '            If IsNumeroDuplic Then
        '                ''impressão do texto
        '                ' aí então eu imprimo os caracteres que cabem na linha, fazendo o substring abaixo
        '                Relatorio.Graphics.DrawString(strLinhaX.Substring(0, posicaoN + 2), fonteNormal, Brushes.Black, Relatorio.MarginBounds.Left, y)
        '                Relatorio.Graphics.DrawString(strLinhaX.Substring(posicaoN + 2, 10), fonteNormal_, Brushes.Black, (Relatorio.MarginBounds.Left + (posicaoN * 6.8)), y) ' + ((posicaoN + 1) * 7)

        '                If (posicaoN + 20) < caracteres Then

        '                    Relatorio.Graphics.DrawString(strLinhaX.Substring(posicaoN + 12), fonteNormal, Brushes.Black, (Relatorio.MarginBounds.Left + ((posicaoN + 13) * 6.8)), y) ' + ((posicaoN + 13) * 7)
        '                End If

        '            Else

        '                ''impressão do texto
        '                ' aí então eu imprimo os caracteres que cabem na linha, fazendo o substring abaixo
        '                Relatorio.Graphics.DrawString(strLinha.Substring(0, strLinhaX.Length), fonteNormal, Brushes.Black, Relatorio.MarginBounds.Left, y)
        '            End If
        '        End If

        '    Else

        '        ''impressão do texto
        '        ' aí então eu imprimo os caracteres que cabem na linha, fazendo o substring abaixo
        '        Relatorio.Graphics.DrawString(strLinha.Substring(0, strLinhaX.Length), fonteNormal, Brushes.Black, Relatorio.MarginBounds.Left, y)
        '    End If


        ' meu controle de altura de página é incrementado com o tamanho de uma linha
        y += fonteNormal.Height

        '' aí eu vejo se já extrapolei o tamanho para a próxima linha ou não
        'If y > Relatorio.MarginBounds.Height Then Exit While

        '    'posicaoN = InStr(strLinhaX, vbNewLine, CompareMethod.Text)
        '    'If posicaoN > 0 Then

        '    'Else

        '    '    ' Retiro os caracteres impressos da variável para imprimir o resto.
        '    '    strLinha = strLinha.Substring(caracteres)
        '    'End If

        '    Try
        '        ' Retiro os caracteres impressos da variável para imprimir o resto.
        '        strLinha = strLinha.Substring(strLinhaX.Length)
        '    Catch ex As Exception
        '    End Try


        'End While

        'y += (30 + fonteNormal.Height)
        '' Recarrego o resto da string com o resto.
        'strLinha = _clFunc.primeiraLetraMaiusculaPalavra(_Geno.pCid) & " (" & _Geno.pUf & "), " & Date.Now.Day & " de " & _clFunc.returnMesExtenso(Date.Now.Month) & " de " & Date.Now.Year
        'Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, Relatorio.MarginBounds.Left + 300, y)

        'y += (20 + fonteNormal.Height)
        'Relatorio.Graphics.DrawString("______________________________________", fonteNormal, Brushes.Black, Relatorio.MarginBounds.Left + 300, y)
        'y += (2 + fonteNormal.Height)
        'Relatorio.Graphics.DrawString("(Assinatura)", fonteNormal, Brushes.Black, Relatorio.MarginBounds.Left + 400, y)


        Relatorio.PageSettings.PrinterSettings.PrintToFile = True
        Relatorio.HasMorePages = False : _pgAtualImpressao = 1

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
        e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 40, 100, New StringFormat())


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
