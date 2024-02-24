Imports Npgsql
Imports System.Text
Imports System.Data
Imports System.IO
Imports System.Drawing.Printing
Public Class Frm_ManRequisicao
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New Funcoes
    Private Const INT_mValorZERO As Integer = 0

    'objetos para impressão
    Dim _StringToPrint As String = ""
    Private _PrintFont As New Font("Lucida Console", 8) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _sImpressao As StreamWriter
    Private _leitorTabelaImprimir As NpgsqlDataReader


    Private Sub btn_registro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_registro.Click
        Dim Lanca As New Frm_Requisicao
        Lanca.ShowDialog()
        preencheDtgRequis()
    End Sub

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click
        Me.Close()
    End Sub

    Private Sub Frm_ManLancamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Frm_ManLancamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        msk_dataInicial.Text = Format(Date.Now, "01MMyyyy")
        msk_dataFinal.Text = Format(Date.Now, "ddMMyyyy")
        preencheDtgRequis()
    End Sub

    Private Sub preencheDtgRequis()

        Dim conexao As New NpgsqlConnection(ModuloConexaoBD.conectionPadrao)
        Try
            If conexao.State = ConnectionState.Closed Then conexao.Open()
        Catch ex As Exception
        End Try

        If conexao.State = ConnectionState.Open Then
            Dim sqlRequisicao As New StringBuilder
            Dim cmdRequisicao As NpgsqlCommand
            Dim daRequisicao As NpgsqlDataAdapter
            Dim drRequisicao As NpgsqlDataReader
            Dim mStrLinha As String = ""

            Try
                sqlRequisicao.Append("SELECT DISTINCT(reqnumero, reqdata, requsuario) FROM requisicao ")
                sqlRequisicao.Append("WHERE reqdata BETWEEN '" & msk_dataInicial.Text & "' AND ")
                sqlRequisicao.Append("'" & msk_dataFinal.Text & "'")
                cmdRequisicao = New NpgsqlCommand(sqlRequisicao.ToString, conexao)
                drRequisicao = cmdRequisicao.ExecuteReader

                dtg_requisicao.Rows.Clear()
                dtg_requisicao.Refresh()
                While drRequisicao.Read
                    mStrLinha = drRequisicao(0).ToString.Remove(0, 1)
                    mStrLinha = mStrLinha.Remove(mStrLinha.Length - 1, 1)
                    Dim mlinha As String() = Split(mStrLinha, ",")
                    'Adicionando Linha
                    Me.dtg_requisicao.Rows.Add(mlinha(0).ToString, _
                    Format(CDate(mlinha(1).ToString), "dd/MM/yyyy"), mlinha(2).ToString)
                    dtg_requisicao.Refresh()
                    mlinha = Nothing
                End While


                cmdRequisicao.CommandText = ""
            Catch ex As Exception
            End Try

            sqlRequisicao.Remove(INT_mValorZERO, sqlRequisicao.ToString.Length)

            daRequisicao = Nothing
            cmdRequisicao = Nothing
            sqlRequisicao = Nothing
            Me.dtg_requisicao.Focus()
            conexao.Close()
            conexao = Nothing

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
        StringforPage = _StringToPrint.Substring(INT_mValorZERO, NumChars)
        ' Imprime a string na pagina atual
        e.Graphics.DrawString(StringforPage, _PrintFont, Brushes.Black, recdraw, Strformat)
        ' Se Hover mais texto, indica que há mais paginas

        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    Private Sub executaRelatRequisicao(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        'Dim mArqTemp As String = unidadePC & ":\TEMPconsulta.TMP"
        Dim mArqTemp As String = "\wged\TEMPconsulta.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)
        Catch ex As Exception
            File.Delete(mArqTemp)
            fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)
        End Try

        Dim s As New StreamWriter(fs)
        _PrintFont = New Font("Lucida Console", 10)
        Dim strLinha As String = "REQUISICAO", numRequis As String = dtg_requisicao.CurrentRow.Cells(0).Value
        Dim dataRequis As String = dtg_requisicao.CurrentRow.Cells(1).Value
        Dim usuarioRequis As String = dtg_requisicao.CurrentRow.Cells(2).Value

        'titulo
        s.Write(vbNewLine & vbNewLine)
        s.WriteLine(_clFuncoes.Centraliza_Str(strLinha, 88))
        s.Write(vbNewLine & vbNewLine)

        'cabeçalho
        Dim lShouldReturn2 As Boolean
        GravCabecalhoArq(s, lShouldReturn2, numRequis, dataRequis, usuarioRequis)
        If lShouldReturn2 Then Return

        'itens
        Dim lShouldReturn1 As Boolean
        GravItensArq(arqSaida, mArqTemp, fs, s, lShouldReturn1)
        If lShouldReturn1 Then Return

        '12 linhas a mais...
        gravaAssinatura(s)

        'Fecha o arquivo .......................................
        s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        s.Dispose()
        File.Delete(mArqTemp)
        mArqTemp = Nothing : fs = Nothing : s = Nothing
        '.......................................................

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo()

        _StringToPrint = ""
    End Sub

    Private Sub LerOArquivoSalvo(ByVal arqSaida As String)
        'Ler o Arquivo salvo...
        Dim FilePath As String = arqSaida
        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrint = MyfileStream.ReadToEnd
            MyfileStream.Close()
            MyfileStream.Dispose()
            MyfileStream = Nothing
            File.Delete(arqSaida)
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
            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando Requisição"
            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try
    End Sub

    Private Sub GravItensArq(ByVal arqSaida As String, ByVal mArqTemp As String, ByVal fs As FileStream, ByVal s As StreamWriter, ByRef shouldReturn As Boolean)
        shouldReturn = False
        Try
            Dim numRequis As String = CInt(Me.dtg_requisicao.CurrentRow.Cells(INT_mValorZERO).Value)
            gravaItemsNota(s, numRequis)
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) da Nota", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return
        End Try

    End Sub

    Private Sub GravCabecalhoArq(ByVal s As StreamWriter, ByRef shouldReturn As Boolean, _
                                 ByVal numRequis As String, ByVal dataRequis As String, _
                                 ByVal usuarioRequis As String)
        shouldReturn = False
        Try
            s.Write("Requisição: " & numRequis & "   Data: " & dataRequis & "   Usuario: " & usuarioRequis)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Nota", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return
        End Try
    End Sub

    Private Sub gravaItemsNota(ByVal s As StreamWriter, ByVal numRequis As String)

        Dim oConnBDGENOV As New NpgsqlConnection(ModuloConexaoBD.conectionPadrao)
        Dim mCodProd, mNomeProd As String
        Dim mQtdeProd As Double
        Dim mSomaQtdeProd As Double
        Dim UndProd, strLinha As String
        strLinha = ""
        UndProd = ""
        numRequis = String.Format("{0:D12}", CInt(numRequis))

        Try
            If oConnBDGENOV.State = ConnectionState.Closed Then
                oConnBDGENOV.Open()
            End If
        Catch ex As Exception
        End Try

        Dim sqlItem As New StringBuilder
        Dim cmdItem As NpgsqlCommand
        Dim drItem As NpgsqlDataReader
        Dim mContItens As Integer = INT_mValorZERO

        sqlItem.Append("SELECT r.reqnumero, r.reqdata, e.e_produt, r.reqqtde FROM requisicao r ")
        sqlItem.Append("LEFT JOIN est0001 e ON e.e_codig = r.reqcodprod WHERE r.reqnumero = ")
        sqlItem.Append("'" & numRequis & "'")

        cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
        drItem = cmdItem.ExecuteReader

        If drItem.HasRows = True Then
            s.Write(vbNewLine)
            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine("--------------------------------------------------------------------------------------------")
            s.WriteLine("PRODUTO                                                     QUANTIDADE ")
            '            xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZ999,999.99  
            s.WriteLine("--------------------------------------------------------------------------------------------")
            s.WriteLine("")
        End If

        While drItem.Read
            mNomeProd = drItem(2)
            mQtdeProd = drItem(3)

            strLinha = _clFuncoes.Exibe_StrDireita(mNomeProd, 60) & _
            _clFuncoes.Exibe_StrDireita(Format(mQtdeProd, "###,##0.00"), 20)
            s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 110))
            mContItens += 1
        End While

        If mContItens > INT_mValorZERO Then
            s.WriteLine("")
            strLinha = "TOTAIS --->          " & _clFuncoes.Exibe_StrEsquerda(mContItens, 3)
            If mContItens > 1 Then
                strLinha += " - Itens"
            Else
                strLinha += " - Iten"
            End If
            strLinha = _clFuncoes.Exibe_Str(strLinha, 65)
            s.WriteLine(strLinha)
            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine("--------------------------------------------------------------------------------------------")
            s.WriteLine("")
        End If

        cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
        mNomeProd = Nothing : mQtdeProd = Nothing : mContItens = Nothing

    End Sub

    Private Sub gravaAssinatura(ByVal s As StreamWriter)

        s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)
        s.Write(vbNewLine & vbNewLine & vbNewLine & vbNewLine & vbNewLine)
        '                      1        2         3         4         5         6         7         8         9         0         1         2
        '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        s.WriteLine("   ----------------------------------              ------------------------------------")
        s.WriteLine("       (Assinatura do Gerente)                           (Assinatura do Estoquista)")
        '            xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZ999,999.99  

    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        'Código para impressão...
        If Me.dtg_requisicao.Rows.Count > INT_mValorZERO AndAlso Me.dtg_requisicao.SelectedCells.Count > 0 Then
            executaRelatRequisicao("", "\wged\TEMPconsulta.txt")
        End If
    End Sub

    Private Sub msk_dataInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_dataInicial.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsDate(msk_dataInicial.Text) Then preencheDtgRequis()
        End Select
    End Sub

    Private Sub msk_dataFinal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles msk_dataFinal.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsDate(msk_dataFinal.Text) Then preencheDtgRequis()
        End Select
    End Sub

    Private Sub msk_dataInicial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dataInicial.Click
        Me.msk_dataInicial.SelectAll()
    End Sub

    Private Sub msk_dataFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dataFinal.Click
        Me.msk_dataFinal.SelectAll()
    End Sub
End Class