Imports System.Drawing.Printing
Imports System.Text
Imports System.Data
Imports System.Math
Imports System.IO
Imports Npgsql

Public Class Frm_ManifestoCarga

    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes, _clBD As New Cl_bdMetrosys

    'Inicio da Criação dos Objetos...
    Private _NFeSaida As New Cl_NFeSaida
    Private geno001 As New Cl_Geno
    Private genp001 As New Cl_Genp001
    Private cliTranportador As New Cl_Cadp001
    Private _xml As New Cl_TratamentoXML

    'Resumo da Saida:
    Private dtgItensResumo As New DataGridView
    'sequencia do GridView = r4_numero, r4_cfop, r4_cst, r4_aliq, r4_tprod, r4_tdesc, r4_tfrete, r4_tseguro, r4_toutrasdesp,    - 8
    'r4_bcalc, r4_icms, r4_isento, r4_outras, r4_ipi, r4_tgeral     - 14

    'objetos para impressão...
    Private MostrarCaixaImpressoras As Boolean = False
    Private _StringToPrint As String = "", _stringToPrintAux As String = ""
    Private _PrintFont1 As New Font("Lucida Console", 10) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _sImpressao As StreamWriter
    Private _cabecalho As Boolean = True
    Private _leitorTabelaImprimir As NpgsqlDataReader


    Private Sub Frm_ManifestoCarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatManifCarga.BeginPrint, AddressOf InicializaRelatorio
    End Sub

    Private Sub Frm_ManifestoCarga_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

    Private Sub Frm_ManifestoCarga_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub txt_numMapa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numMapa.Leave

        If IsNumeric(Me.txt_numMapa.Text) Then

            Me.txt_numMapa.Text = String.Format("{0:D8}", CInt(Me.txt_numMapa.Text))
            Me.txt_roteiro.Text = _clFuncoes.trazRoteiroMapa(CInt(Me.txt_numMapa.Text), MdlConexaoBD.conectionPadrao)
        Else

            MsgBox("NUMERO do mapa deve ser NUMERO INTEIRO", MsgBoxStyle.Exclamation)
            Me.txt_numMapa.Focus() : Me.txt_numMapa.SelectAll() : Return
        End If


    End Sub

    Private Sub txt_numMapa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numMapa.KeyPress

        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click

        gravaRoteiroMapa()
        executaEspelhoPedido("", "\wged\relatorios\manifestoCarga.txt")

    End Sub

    Private Sub gravaRoteiroMapa()

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return

        End Try

        Try
            transacao = conexao.BeginTransaction

            If _clBD.existeMapaRoteiro(conexao, CInt(Me.txt_numMapa.Text)) Then

                _clBD.altRoteiroMapa(conexao, transacao, CInt(Me.txt_numMapa.Text), Me.txt_roteiro.Text, _
                                     Date.Now)
            Else
                _clBD.incRoteiroMapa(conexao, transacao, CInt(Me.txt_numMapa.Text), Me.txt_roteiro.Text, _
                                     Date.Now)
            End If

            transacao.Commit() : conexao.ClearAllPools()
        Catch ex As NpgsqlException

            transacao.Rollback()
            MsgBox(ex.Message.ToString)
        Catch ex As Exception


            Try
                transacao.Rollback()
            Catch ex2 As Exception
                MsgBox(ex2.Message.ToString)
            End Try

            MsgBox(ex.Message.ToString)
        Finally

            If conexao.State = ConnectionState.Open Then conexao.Close()
            conexao = Nothing : transacao = Nothing
        End Try


    End Sub

    Private Sub executaEspelhoPedido(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\relatorios\manifestoCarga.TMP"
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
        _PrintFont1 = New Font("Lucida Console", 11)
        Dim strLinha As String = ""
        Dim mapa As String = Me.txt_numMapa.Text
        Dim dtEmissao As String = Format(Date.Now, "dd/MM/yyyy")
        Dim mRoteiro As String = Me.txt_roteiro.Text
        Dim mPagina As Integer = 1

        'Titulo
        GravTitulo(s, mapa, mRoteiro, dtEmissao, mPagina)

        'itens
        Dim lShouldReturn3 As Boolean
        GravManifestoCarga(s, mapa, mRoteiro, dtEmissao, mPagina, lShouldReturn3)
        If lShouldReturn3 Then Return


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

    Private Sub GravTitulo(ByVal s As StreamWriter, ByVal mapa As String, ByVal Roteiro As String, _
                           ByVal dtEmissao As String, ByRef mPagina As Integer)

        s.WriteLine("")
        s.WriteLine(" Mapa: " & mapa & _clFuncoes.Centraliza_Str("MANIFESTO DE CARGA", 48) & "Data: " & dtEmissao)
        s.WriteLine(" Roteiro: " & _clFuncoes.Exibe_StrEsquerda(Roteiro, 58) & _clFuncoes.Exibe_StrDireita(" Folha: " & String.Format("{0:D3}", mPagina), 11))
        's.WriteLine("")
        s.WriteLine("+------------------------------------------------------------------------------+")
        s.WriteLine("|   PEDIDO   | NOME DO CLIENTE                |    VALOR   |TIPO|   CONDIÇÃO   |")
        s.WriteLine("+------------------------------------------------------------------------------+")
        's.WriteLine("")

    End Sub

    Private Sub GravManifestoCarga(ByVal s As StreamWriter, ByVal mapa As String, ByVal Roteiro As String, _
                            ByVal dtEmissao As String, ByRef mPagina As Integer, ByRef shouldReturn As Boolean)
        shouldReturn = False
        Try
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim oConn2 As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim mNumPedido, mNomePart, mTipo, mCondicao, strLinha As String
            Dim mVlTotal As Double
            Dim strTotalGeral As String
            Dim mSomaTotGeral, mSomaVlrTotCid As Double
            strLinha = "" : mTipo = "" : mCondicao = ""
            Dim mCont1, mCont2, index As Integer


            Try
                oConnBDGENOV.Open()
                oConn2.Open()
            Catch ex As Exception
            End Try

            Dim sql1, sql2 As New StringBuilder
            Dim cmd1, cmd2 As NpgsqlCommand
            Dim dr1, dr2 As NpgsqlDataReader
            Dim mContItens As Integer = _valorZERO, mContItensPg As Integer = _valorZERO, mContPg As Integer = _valorZERO


            sql1.Append("SELECT DISTINCT nt_cid FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp LEFT JOIN ")
            sql1.Append(MdlEmpresaUsu._esqEstab & ".orca2cc ON no_orca = nt_orca WHERE no_mapa = @mapa ORDER BY nt_cid ASC")
            cmd1 = New NpgsqlCommand(sql1.ToString, oConnBDGENOV)
            cmd1.Parameters.Add("@mapa", CInt(txt_numMapa.Text))
            dr1 = cmd1.ExecuteReader


            mSomaTotGeral = _valorZERO
            mContPg = 1
            While dr1.Read


                mContItensPg += 1
                sql2.Append("SELECT DISTINCT nt_orca, cad.p_portad, o4.n4_tgeral, nt_tipo2, nt_cod1, nt_cod2, ") '5
                sql2.Append("nt_cod3, nt_cod4, nt_cod5, nt_cod6, nt_cod7 FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp, ") '10
                sql2.Append("cadp001 cad, " & MdlEmpresaUsu._esqEstab & ".orca4dd o4, " & MdlEmpresaUsu._esqEstab & ".orca2cc ")
                sql2.Append("WHERE no_orca = nt_orca AND cad.p_cod = nt_codig AND o4.n4_nume = nt_orca AND nt_cid = ")
                sql2.Append("@cidade AND no_mapa = @mapa")

                cmd2 = New NpgsqlCommand(sql2.ToString, oConn2)
                cmd2.Parameters.Add("@cidade", dr1(0).ToString)
                cmd2.Parameters.Add("@mapa", CInt(txt_numMapa.Text))
                dr2 = cmd2.ExecuteReader


                'Titulo
                If (mCont1 + 1) >= 66 Then mPagina += 1 : GravTitulo(s, mapa, Roteiro, dtEmissao, mPagina) : mCont1 = 0

                s.WriteLine(" " & dr1(0).ToString & ":") : mCont1 += 1

                'Titulo
                If mCont1 = 66 Then mPagina += 1 : GravTitulo(s, mapa, Roteiro, dtEmissao, mPagina) : mCont1 = 0


                While dr2.Read


                    mNumPedido = dr2(0).ToString
                    mNomePart = dr2(1).ToString
                    mVlTotal = dr2(2)
                    mTipo = dr2(3).ToString
                    mCondicao = formaDescricao(dr2(4), dr2(5), dr2(6), dr2(7), dr2(8), dr2(9), dr2(10))

                    strLinha = _clFuncoes.Exibe_Str(mNumPedido, 8) & " - " & _
                    _clFuncoes.Exibe_StrEsquerda(mNomePart, 31) & " - " & _
                    _clFuncoes.Exibe_StrDireita(Format(mVlTotal, "###,##0.00"), 10) & " - " & _
                    _clFuncoes.Exibe_StrDireita(mTipo, 2) & " - " & _
                    _clFuncoes.Exibe_StrEsquerda(mCondicao, 14)

                    'Titulo
                    If (mCont1 + 1) >= 66 Then mPagina += 1 : GravTitulo(s, mapa, Roteiro, dtEmissao, mPagina) : mCont1 = 0

                    s.WriteLine("   " & _clFuncoes.Exibe_Str(strLinha, 80)) : mCont1 += 1

                    'Titulo
                    If mCont1 >= 66 Then mPagina += 1 : GravTitulo(s, mapa, Roteiro, dtEmissao, mPagina) : mCont1 = 0


                    mSomaVlrTotCid += mVlTotal
                    mSomaTotGeral += mVlTotal
                    mContItens += 1 : mContItensPg += 1
                    mCont2 += 1
                End While

                strLinha = mCont2
                If mCont2 > 1 Then
                    strLinha += " - Pedidos"
                Else
                    strLinha += " - Pedido "
                End If

                'Titulo
                If (mCont1 + 2) >= 66 Then mPagina += 1 : GravTitulo(s, mapa, Roteiro, dtEmissao, mPagina) : mCont1 = 0

                s.WriteLine("                                               ------------                     ")
                strLinha += _clFuncoes.Exibe_StrDireita(Format(mSomaVlrTotCid, "###,##0.00"), 33)
                mSomaVlrTotCid = 0 : mCont2 = 0
                s.WriteLine("              " & strLinha & vbNewLine) : mCont1 += 2

                'Titulo
                If mCont1 >= 66 Then mPagina += 1 : GravTitulo(s, mapa, Roteiro, dtEmissao, mPagina) : mCont1 = 0

                dr2.Close() : cmd2.CommandText = "" : sql2.Remove(0, sql2.ToString.Length)

            End While
            dr1.Close()

            If mSomaTotGeral > _valorZERO Then


                If (mCont1 + 2) >= 66 Then

                    'Titulo
                    s.WriteLine(vbNewLine)
                    mPagina += 1 : GravTitulo(s, mapa, Roteiro, dtEmissao, mPagina) : mCont1 = 0
                Else
                    s.WriteLine(vbNewLine)
                End If


                strLinha = _clFuncoes.Exibe_StrDireita("TOTAL GERAL", 20)
                strTotalGeral = "                          " & _
                _clFuncoes.Exibe_StrDireita(Format(mSomaTotGeral, "#,###,##0.00"), 12) & "       "
                Dim mLabel As New RichTextBox

                mLabel.Text = strTotalGeral
                mLabel.SelectAll()
                mLabel.SelectionFont = New Font("Lucida Console", 10, FontStyle.Underline)
                strLinha += mLabel.Text
                s.WriteLine(_clFuncoes.Exibe_Str(strLinha, 80))
                mLabel = Nothing 'mfont = Nothing : 

            End If

            oConn2.ClearAllPools() : oConn2.Close()
            oConnBDGENOV.ClearAllPools() : oConnBDGENOV.Close()
            cmd1 = Nothing : sql1 = Nothing : dr1 = Nothing : mNumPedido = Nothing
            mNomePart = Nothing : mVlTotal = Nothing : oConnBDGENOV = Nothing : oConn2 = Nothing
            dr2 = Nothing : sql2 = Nothing : cmd2 = Nothing


        Catch ex As Exception
            MsgBox("Deu erro ao gravar o(s) iten(s) do Mapa", MsgBoxStyle.Exclamation)
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
            'PrintDocument1 = New 

            ' Especifica as configurações da pagina atual
            pdRelatManifCarga.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatManifCarga.DefaultPageSettings.Margins.Top = 12
            pdRelatManifCarga.DefaultPageSettings.Margins.Right = 12
            pdRelatManifCarga.DefaultPageSettings.Margins.Left = 10
            pdRelatManifCarga.DefaultPageSettings.Margins.Bottom = 8

            'Orientação em Paisagem...
            pdRelatManifCarga.DefaultPageSettings.Landscape = False
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando CARGA"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatManifCarga
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub pdRelatPedidos_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdRelatManifCarga.PrintPage

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
        StringforPage = _StringToPrint.Substring(_valorZERO, NumChars)

        ' Imprime a string na pagina atual
        e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, recdraw, Strformat)


        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False : _stringToPrintAux = _StringToPrint

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

                    pdRelatManifCarga.PrinterSettings = Impressora.PrinterSettings
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
        End If
        MostrarCaixaImpressoras = True



    End Sub

    Private Function formaDescricao(ByVal cond1 As String, ByVal cond2 As String, ByVal cond3 As String, _
                              ByVal cond4 As String, ByVal cond5 As String, ByVal cond6 As String, _
                              ByVal cond7 As String) As String

        Dim descricao As String = ""

        If CInt(cond1) > _valorZERO Then descricao += cond1
        If CInt(cond2) > _valorZERO Then descricao += "/" & cond2
        If CInt(cond3) > _valorZERO Then descricao += "/" & cond3
        If CInt(cond4) > _valorZERO Then descricao += "/" & cond4
        If CInt(cond5) > _valorZERO Then descricao += "/" & cond5
        If CInt(cond6) > _valorZERO Then descricao += "/" & cond6
        If CInt(cond7) > _valorZERO Then descricao += "/" & cond7
        If descricao.Equals("") Then descricao = "0"


        Return descricao
    End Function

    Private Sub btn_NFe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NFe.Click

    End Sub

End Class