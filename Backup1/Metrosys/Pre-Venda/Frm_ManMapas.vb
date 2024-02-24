Imports System
Imports System.Data
Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog
Imports System.Text
Imports System.IO
Imports Npgsql

Public Class Frm_ManMapas
    Private Const _valorZERO As Integer = 0
    Private cl_funcoes As New ClFuncoes

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


    Private Shared Sub executaF2()

        Dim mapasVendas As New Frm_MapaPrevenda
        mapasVendas.ShowDialog()


    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        executaF2()

    End Sub

    Private Sub consultaBD(ByVal dtInicio As Date, ByVal dtfinal As Date)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao abrir Connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlPart As New StringBuilder
        Dim daPart As NpgsqlDataAdapter
        Dim dtPart As New DataTable


        Try
            sqlPart.Append("SELECT mv_mpid AS ""ID"", mv_local AS ""Loja"", mv_numero AS ""MAPAS"", mv_emissao AS ""DTEMISSÃO"", ") '3
            sqlPart.Append("mv_saida AS ""DtSAIDA"", mv_total AS ""TOTAL R$"", mv_placaveic AS ""VEÍCULO"" ") '5

            Select Case cbo_opcoes.SelectedIndex
                Case 0 'Todos
                    sqlPart.Append("FROM " & MdlEmpresaUsu._esqEstab & ".mapa1pp where mv_local='" & cbo_loja.SelectedItem & "' ")
                    sqlPart.Append("ORDER BY mv_emissao DESC")

                Case 1 'Os Dez últimos
                    sqlPart.Append("FROM " & MdlEmpresaUsu._esqEstab & ".mapa1pp where mv_emissao >='" & dtInicio & "' and mv_emissao <='" & dtfinal & "' and mv_local='" & cbo_loja.SelectedItem & "' ")
                    sqlPart.Append("ORDER BY mv_emissao DESC LIMIT 10")

                Case 2 'Por período
                    sqlPart.Append("FROM " & MdlEmpresaUsu._esqEstab & ".mapa1pp where mv_emissao >='" & dtInicio & "' and mv_emissao <='" & dtfinal & "' and mv_local='" & cbo_loja.SelectedItem & "' ")
                    sqlPart.Append("AND mv_placaveic = '" & Me.txt_placaVeic.Text & "' ORDER BY mv_emissao DESC")

            End Select


            daPart = New NpgsqlDataAdapter(sqlPart.ToString, oConnBDGENOV)
            dtPart = New DataTable : daPart.Fill(dtPart)


            Me.dtg_mapas.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine
            Me.dtg_mapas.DataSource = dtPart 'dsPart.Tables("Nota4ff")
            Me.dtg_mapas.Columns(_valorZERO).Visible = False 'Codigo
            Me.dtg_mapas.Columns(_valorZERO).Width = 8 'Codigo
            Me.dtg_mapas.Columns(1).Width = 50 'loja
            Me.dtg_mapas.Columns(2).Width = 90 'mapa
            Me.dtg_mapas.Columns(3).Width = 90 'data
            Me.dtg_mapas.Columns(4).Width = 90 'data
            Me.dtg_mapas.Columns(5).Width = 100 'total
            Me.dtg_mapas.Columns(5).DefaultCellStyle.BackColor = Color.Aquamarine
            Me.dtg_mapas.Columns(5).DefaultCellStyle.Format = "###,##0.00"
            Me.dtg_mapas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Me.dtg_mapas.Columns(6).Width = 90 'data


            sqlPart.Remove(_valorZERO, sqlPart.ToString.Length)
        Catch ex As Exception
        End Try

        oConnBDGENOV.ClearPool()
        daPart = Nothing : sqlPart = Nothing : dtPart = Nothing : Me.dtg_mapas.Focus()
        oConnBDGENOV.Close() : oConnBDGENOV = Nothing



    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click

        consultaBD(CDate(dtp_inicio.Text), CDate(dtp_final.Text))

    End Sub

    Private Sub Frm_ManMapas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                consultaBD(Me.dtp_inicio.Text, Me.dtp_final.Text)

            Case Keys.F2

                executaF2()

            Case Keys.F6

                executaF6()


        End Select



    End Sub

    Private Sub executaEspelhoNota(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPconsultaMp.TMP"
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
        _PrintFont = New Font("Lucida Console", 9)
        Dim strLinha As String = ""
        Dim dtSaida As String = Me.dtg_mapas.CurrentRow.Cells(4).Value
        Dim dtEmissao As String = Me.dtg_mapas.CurrentRow.Cells(3).Value
        Dim numeroMapa As String = Me.dtg_mapas.CurrentRow.Cells(2).Value


        'titulo
        Try
            'vbCrLf, vbCr, vbLf, vbNewLine = quebra de linha
            s.Write(vbNewLine & vbNewLine)
            '8 caracteres
            strLinha = cl_funcoes.Exibe_Str(("MAPA: " & numeroMapa), 20)
            '9 caracteres
            strLinha += cl_funcoes.Exibe_StrDireita(("SAIDA: " & dtSaida), 30)
            '9 caracteres
            strLinha += cl_funcoes.Exibe_StrDireita(("DATA: " & Format(Date.Now, "dd/MM/yyyy")), 27)

            s.WriteLine(cl_funcoes.Exibe_Str(strLinha, 120))
        Catch ex As Exception
        End Try


        'cabeçalho
        Dim lShouldReturn2 As Boolean
        GravCabecalhoArq(s, dtSaida, dtEmissao, numeroMapa, lShouldReturn2)
        If lShouldReturn2 Then Return

        'itens
        Dim lShouldReturn1 As Boolean
        GravItensArq(arqSaida, mArqTemp, fs, s, lShouldReturn1)
        If lShouldReturn1 Then Return


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

    Private Sub gravaItemsNota(ByVal s As StreamWriter, ByVal idMp As Int32)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd As String
        Dim mQtdeProd, mVlProd, mVlTotProd As Decimal
        Dim mVlIpiProd As Decimal, mSomaTotProd As Decimal
        Dim UndIten, strLinha As String
        strLinha = "" : UndIten = ""

        Try
            oConnBDGENOV.Open()

        Catch ex As Exception
        End Try

        Dim sqlItem As New StringBuilder
        Dim cmdItem As NpgsqlCommand
        Dim drItem As NpgsqlDataReader
        Dim mContItens As Integer = _valorZERO

        sqlItem.Append("SELECT mc_id, mc_mpid, mc_numero, mc_codpr, mc_descricao, mc_und, mc_qtde, ") '6
        sqlItem.Append("mc_valorunit, mc_total, mc_pesobruto, mc_pesoliq, mc_codbarra, ") '11
        sqlItem.Append("mc_local ") '12
        sqlItem.Append("FROM " & MdlEmpresaUsu._esqEstab & ".mapa2cc WHERE mc_mpid = " & idMp)

        cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
        drItem = cmdItem.ExecuteReader

        If drItem.HasRows = True Then
            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine("------------------------------------------------------------------------------")
            s.WriteLine("CODIGO DESCRICÃO DO PRODUTO                   QUANT.    V.BRUTO    VL. TOTAL")
            '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx 99,999.99 999,999.99 9,999,999.99  
            s.WriteLine("------------------------------------------------------------------------------")

        End If

        mSomaTotProd = _valorZERO
        While drItem.Read
            mCodProd = drItem(3)
            mNomeProd = drItem(4)
            mNcmProd = ""
            mQtdeProd = drItem(6)
            mVlProd = drItem(7)
            mVlTotProd = (drItem(8))
            mSomaTotProd += mVlTotProd

            strLinha = cl_funcoes.Exibe_Str(mCodProd, 6) & " " & cl_funcoes.Exibe_Str(mNomeProd, 35) & " " & _
            cl_funcoes.Exibe_StrDireita(Format(mQtdeProd, "###,##0.00"), 9) _
            & " " & cl_funcoes.Exibe_StrDireita(Format(mVlProd, "###,##0.00"), 10) & " " & _
            cl_funcoes.Exibe_StrDireita(Format(mVlTotProd, "###,##0.00"), 12) '106 CARACTERES

            s.WriteLine(cl_funcoes.Exibe_Str(strLinha, 110))
            mContItens += 1
        End While
        drItem.Close() : oConnBDGENOV.ClearPool()


        If mSomaTotProd > _valorZERO Then

            s.WriteLine("")
            strLinha = "TOTAIS --->     " & cl_funcoes.Exibe_StrDireita(mContItens, 3)
            If mContItens > 1 Then
                strLinha += " - Itens"
            Else
                strLinha += " - Iten"
            End If
            strLinha += cl_funcoes.Exibe_StrDireita(Format(mSomaTotProd, "###,##0.00"), 49) '106 CARACTERES
            s.WriteLine(cl_funcoes.Exibe_Str(strLinha, 115))

            '                      1        2         3         4         5         6         7         8                    9         0         1         2
            '            12345678901234567890123456789012345678901234567890123456789012345678901234567890           1234567890123456789012345678901234567890
            s.WriteLine("------------------------------------------------------------------------------")
            s.WriteLine("")
        End If

        If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
        cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
        mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing : mCstProd = Nothing
        mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing : mVlIpiProd = Nothing
        oConnBDGENOV = Nothing



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
            e.HasMorePages = False ': _stringToPrintAux = _StringToPrint

        End If



    End Sub

    Private Sub GravItensArq(ByVal arqSaida As String, ByVal mArqTemp As String, ByVal fs As FileStream, ByVal s As StreamWriter, ByRef shouldReturn As Boolean)
        shouldReturn = False
        Try
            Dim idMp As Int32 = CInt(Me.dtg_mapas.CurrentRow.Cells(_valorZERO).Value)
            gravaItemsNota(s, idMp)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) do Mapa", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try

        mArqTemp = Nothing : fs = Nothing : s = Nothing



    End Sub

    Private Sub gravaCabecalhoNota(ByVal s As StreamWriter, ByVal mapa As String, _
                ByVal codEstab As String, ByVal dtSaida As String, ByVal dtEmiss As String)

        If codEstab.Length = 2 Then codEstab = "0" & codEstab
        If codEstab.Length > 3 Then codEstab = Mid(codEstab, codEstab.Length - 2, 3)

        Dim strLinha As String = ""
        s.WriteLine("")
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

        sqlClient.Append("SELECT g_geno, g_cgc, g_insc, g_uf, g_ender, g_cid ")
        sqlClient.Append("FROM geno001 WHERE SUBSTR(g_codig, 3, 3) = '" & codEstab & "'")

        cmdClient = New NpgsqlCommand(sqlClient.ToString, oConnBDGENOV)
        drClient = cmdClient.ExecuteReader

        Dim nomeClient, cnpjClient, inscClient, ufClient, enderClient, cidClient As String

        nomeClient = "" : cnpjClient = "" : inscClient = "" : ufClient = ""
        enderClient = "" : cidClient = ""
        While drClient.Read
            nomeClient = drClient(_valorZERO) : cnpjClient = drClient(1) : inscClient = drClient(2)
            ufClient = drClient(3) : enderClient = drClient(4) : cidClient = drClient(5)
        End While
        drClient.Close() : oConnBDGENOV.ClearPool()
        cmdClient = Nothing : sqlClient = Nothing : drClient = Nothing : oConnBDGENOV = Nothing


        '                      1        2         3         4         5         6         7         8         9         0         1         2
        '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
        strLinha = cl_funcoes.Exibe_StrEsquerda(nomeClient, 58)
        strLinha += "Veículo: " & cl_funcoes.Exibe_StrDireita( _
        Me.dtg_mapas.CurrentRow.Cells(6).Value.ToString, 10)
        s.Write(cl_funcoes.Exibe_StrEsquerda(strLinha, 120) & vbNewLine)

        '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxZ xxx xxxxxxxxxx 999,999.99 999,999.99   
        's.WriteLine("--------------------------------------------------------------------------------------------------------------------")

    End Sub

    Private Sub GravCabecalhoArq(ByVal s As StreamWriter, ByVal dtEntrada As String, ByVal dtEmissao As String, _
                                 ByVal mapa As String, ByRef shouldReturn As Boolean)
        shouldReturn = False
        Try
            Dim codEstab As String = Me.dtg_mapas.CurrentRow.Cells(1).Value
            gravaCabecalhoNota(s, mapa, codEstab, dtEntrada, dtEmissao)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Nota", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

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
            PrintPreviewDialog1.Text = "Vizualizando MAPAS"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False

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

    Private Sub executaF6()

        If (Me.dtg_mapas.Rows.Count > _valorZERO) AndAlso (Me.dtg_mapas.SelectedCells.Count > 0) Then

            executaEspelhoNota("", "\wged\TEMPconsultaMp.txt")

        End If

    End Sub

    Private Sub btn_relatorios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_relatorios.Click

        executaF6()

    End Sub

    Private Sub Frm_ManMapas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbo_loja.SelectedIndex = _valorZERO
        cbo_opcoes.SelectedIndex = _valorZERO

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler PrintDocument1.BeginPrint, AddressOf InicializaRelatorio
    End Sub

End Class