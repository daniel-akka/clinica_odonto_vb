Imports System
Imports System.Data
Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog
Imports System.Text
Imports System.IO
Imports System.Math
Imports Npgsql

Public Class Frm_ManRetorMp
    Private Const _valorZERO As Integer = 0
    Private _clFunc As New ClFuncoes
    Dim _StringToPrint As String = "", _stringToPrintAux As String = ""
    Dim _strConsulta As String = ""

    Dim mSomaPcoCompra, mSomaPcoCusto As Double

    'objetos para impressão
    Private _PrintFont As New Font("Lucida Console", 9) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _sImpressao As StreamWriter
    Private _leitorTabelaImprimir As NpgsqlDataReader
    Dim MostrarCaixaImpressoras As Boolean = False


    Private Sub executaF2()

        Dim retornoMapas As New Frm_Retornovendas
        retornoMapas.ShowDialog()


    End Sub

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        executaF2()

    End Sub

    Private Function verificCamposConsulta() As Boolean

        lbl_mensagem.Text = ""
        'Se tiver selecionado o ver por Pedido ...
        If (cbo_verPor.SelectedIndex = 1) AndAlso Not IsNumeric(Me.txt_numero.Text) Then

            lbl_mensagem.Text = "Informe o Numero do Pedido !" : Return False

        End If

        'Se tiver selecionado o ver por Mapa ...
        If (cbo_verPor.SelectedIndex = 2) AndAlso Not IsNumeric(Me.txt_numero.Text) Then

            lbl_mensagem.Text = "Informe o Numero do Mapa !" : Return False

        End If



        Return True
    End Function

    Private Sub preparaConsulta()

        _strConsulta = ""

        'Tratamento do Cbo_verPor...
        Select Case Me.cbo_verPor.SelectedIndex
            Case 1 'Pedido

                Dim mNumPedido As String = String.Format("{0:D10}", Convert.ToInt32(Me.txt_numero.Text))
                _strConsulta = "rt_numpedido = '" & mNumPedido & "' AND "
                Me.txt_numero.Text = mNumPedido : mNumPedido = Nothing


            Case 2 'Mapa

                Dim mNumMapa As String = String.Format("{0:D10}", Convert.ToInt32(Me.txt_numero.Text))
                _strConsulta = "rt_mapa = '" & mNumMapa & "' AND "
                Me.txt_numero.Text = mNumMapa : mNumMapa = Nothing


        End Select


        'Tratamento do Cbo_Natureza...
        Select Case Me.cbo_natureza.SelectedIndex
            Case 1 'Venda - 01
                _strConsulta += "rt_naturezapgto = '01' AND "

            Case 2 'Troca - 02
                _strConsulta += "rt_naturezapgto = '02' AND "

            Case 3 'Devolucao - 03
                _strConsulta += "rt_naturezapgto = '03' AND "

            Case 4 'Outros - 04
                _strConsulta += "rt_naturezapgto = '04' AND "

        End Select



    End Sub

    Private Function trazNomeNatVenda(ByVal codNatVend As String) As String

        Dim naturezaVend As String = ""

        Select Case codNatVend
            Case "01"
                naturezaVend = "Venda"

            Case "02"
                naturezaVend = "Troca"

            Case "03"
                naturezaVend = "Devolucao"

            Case "04"
                naturezaVend = "Outros"

            Case Else
                naturezaVend = ""

        End Select



        Return naturezaVend
    End Function

    Private Sub consultaBD(ByVal dtInicio As Date, ByVal dtfinal As Date)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao abrir Connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlPart As New StringBuilder
        Dim cmdRmp As NpgsqlCommand
        Dim drRmp As NpgsqlDataReader


        Try

            Dim rt_numpedido, rt_mapa, rt_dtentegra, p_portad, rt_formapgto As String
            Dim rt_especpgto, rt_naturezapgto, rt_total, rt_loja As String, rt_id As Int32


            sqlPart.Append("SELECT rt_id AS ""ID"", rt_loja AS ""Loja"", rt_numpedido AS ""PEDIDO_MAPA"", rt_mapa ") '3
            sqlPart.Append("AS ""MAPA"", cad.p_portad AS ""CLIENTE"", rt_naturezapgto AS ""NATUREZA"", ") '5
            sqlPart.Append("to_char(rt_dtentegra, 'DD/MM/YYYY') AS ""DtEntrega"", rt_total AS ""TOTAL R$"", ") '7
            sqlPart.Append("cad.p_cod FROM " & MdlEmpresaUsu._esqEstab & ".retorno1pp LEFT JOIN cadp001 cad ON rt_codpart = cad.p_cod WHERE ")
            sqlPart.Append("rt_loja = '" & cbo_loja.SelectedItem & "' AND ")
            sqlPart.Append(_strConsulta)
            sqlPart.Append("rt_dtentegra BETWEEN '" & dtInicio & "' AND '" & dtfinal & "' ")

            cmdRmp = New NpgsqlCommand(sqlPart.ToString, oConnBDGENOV)
            drRmp = cmdRmp.ExecuteReader : Me.dtg_retornos.Rows.Clear() : Me.dtg_retornos.Refresh()

            While drRmp.Read

                rt_id = drRmp(_valorZERO) : rt_loja = drRmp(1).ToString
                rt_numpedido = drRmp(2).ToString : rt_mapa = drRmp(3).ToString
                p_portad = drRmp(4).ToString : rt_naturezapgto = trazNomeNatVenda(drRmp(5).ToString)
                rt_dtentegra = drRmp(6).ToString

                Try
                    rt_total = Format(CDbl(drRmp(7)), "###,##0.00")
                Catch ex As Exception
                    rt_total = Format(0.0, "###,##0.00")
                End Try



                dtg_retornos.Rows.Add(rt_id, rt_loja, rt_numpedido, rt_mapa, p_portad, rt_naturezapgto, _
                                   rt_dtentegra, rt_total, drRmp(8).ToString)


            End While

            drRmp.Close() : sqlPart.Remove(_valorZERO, sqlPart.ToString.Length)
            oConnBDGENOV.ClearPool() : Me.dtg_retornos.Refresh()

            'Limpa Objetos da Memória...
            rt_numpedido = Nothing : rt_mapa = Nothing : rt_dtentegra = Nothing : p_portad = Nothing
            rt_formapgto = Nothing : rt_especpgto = Nothing : rt_naturezapgto = Nothing : rt_total = Nothing
            rt_loja = Nothing : rt_id = Nothing

        Catch ex As Exception
        End Try


        sqlPart = Nothing : drRmp = Nothing : cmdRmp = Nothing : Me.dtg_retornos.Focus()
        oConnBDGENOV.Close() : oConnBDGENOV = Nothing



    End Sub

    Private Sub executaF5()

        If verificCamposConsulta() Then preparaConsulta()
        consultaBD(CDate(dtp_inicio.Text), CDate(dtp_final.Text))


    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click

        executaF5()

    End Sub

    Private Sub Frm_ManRetorMp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5

                executaF5()

            Case Keys.F2

                executaF2()


        End Select



    End Sub

    Private Sub executaIndividual(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações do(s) Retorno(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\consultaRetorno.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Catch ex As Exception

            Try
                fs.Dispose() : File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex01 As Exception
                MsgBox(ex01.Message, MsgBoxStyle.Exclamation)
            End Try

        End Try

        Dim s As New StreamWriter(fs)
        _PrintFont = New Font("Lucida Console", 9) : Dim strLinha As String = ""
        Dim loja As String = Me.dtg_retornos.CurrentRow.Cells(1).Value
        Dim codCli As String = Me.dtg_retornos.CurrentRow.Cells(8).Value
        Dim dtEntrega As String = Me.dtg_retornos.CurrentRow.Cells(6).Value
        Dim dtHoje As String = Format(Date.Now, "dd/MM/yyyy")
        Dim pedido As String = Me.dtg_retornos.CurrentRow.Cells(2).Value
        Dim mapa As String = Me.dtg_retornos.CurrentRow.Cells(3).Value


        'titulo
        Try
            s.Write(vbNewLine) : s.Write(_clFunc.Centraliza_Str("RELATÓRIO DO RETORNO", 100))
            s.Write(vbNewLine & vbNewLine)

            strLinha = _clFunc.Exibe_Str(("PEDIDO: " & pedido), 20)
            strLinha += _clFunc.Exibe_Str(("MAPA: " & mapa), 20)
            strLinha += _clFunc.Exibe_Str(("ENTREGA: " & dtEntrega), 44)
            strLinha += _clFunc.Exibe_Str(("DATA: " & dtHoje), 17)

            s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))
        Catch ex As Exception
        End Try


        'cabeçalho
        Dim lShouldReturn2 As Boolean
        GravCabecalhoIndividual(s, loja, pedido, codCli, lShouldReturn2)
        If lShouldReturn2 Then Return

        'itens
        gravaItemsIndividual(s, pedido, loja)

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

    Private Sub GravCabecalhoIndividual(ByVal s As StreamWriter, ByVal loja As String, _
                                 ByVal pedido As String, ByVal codCli As String, _
                                 ByRef shouldReturn As Boolean)

        shouldReturn = False
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try

            Dim strLinha As String = ""

            oConnBDGENOV.Open()

            'Traz dados do Estabelecimento do retorno...
            Dim sqlRetorno As New StringBuilder
            Dim cmdRetorno As NpgsqlCommand
            Dim drRetorno As NpgsqlDataReader

            sqlRetorno.Append("SELECT g_geno, g_cgc, g_insc, g_uf, g_ender, g_cid ")
            sqlRetorno.Append("FROM geno001 WHERE SUBSTR(g_codig, 3, 3) = '0" & loja & "'")

            cmdRetorno = New NpgsqlCommand(sqlRetorno.ToString, oConnBDGENOV)
            drRetorno = cmdRetorno.ExecuteReader

            Dim nomeEstab, cnpjEstab, inscEstab, ufEstab, enderEstab, cidEstab As String

            nomeEstab = "" : cnpjEstab = "" : inscEstab = "" : ufEstab = "" : enderEstab = ""
            cidEstab = ""

            While drRetorno.Read

                nomeEstab = drRetorno(_valorZERO) : cnpjEstab = drRetorno(1) : inscEstab = drRetorno(2)
                ufEstab = drRetorno(3) : enderEstab = drRetorno(4) : cidEstab = drRetorno(5)

            End While
            cmdRetorno.CommandText = "" : drRetorno.Close() : sqlRetorno.Remove(_valorZERO, sqlRetorno.ToString.Length)



            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = _clFunc.Exibe_StrEsquerda("ESTABELECIMENTO: " & nomeEstab, 70)
            strLinha += _clFunc.Exibe_StrDireita("CNPJ/CPF: " & cnpjEstab, 30)
            s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 100))
            s.WriteLine("____________________________________________________________________________________________________")


            'Traz dados do CLIENTE do retorno...
            sqlRetorno.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro ")
            sqlRetorno.Append("FROM cadp001 WHERE p_cod = '" & codCli & "'")

            cmdRetorno = New NpgsqlCommand(sqlRetorno.ToString, oConnBDGENOV)
            drRetorno = cmdRetorno.ExecuteReader

            Dim nomeClient, cnpjCpfClient, endereco, ufClient, cidClient, bairroClient As String

            nomeClient = "" : cnpjCpfClient = "" : endereco = "" : ufClient = "" : cidClient = ""
            bairroClient = ""

            While drRetorno.Read

                cnpjCpfClient = drRetorno(1).ToString
                If Trim(drRetorno(1).ToString).Equals("") Then

                    cnpjCpfClient = drRetorno(2).ToString

                End If

                nomeClient = drRetorno(_valorZERO).ToString : endereco = drRetorno(3).ToString
                ufClient = drRetorno(5).ToString : cidClient = drRetorno(4).ToString
                bairroClient = drRetorno(6).ToString

            End While
            drRetorno.Close()

            '                 1         2         3         4         5         6         7         8         9         0         1         2
            '        123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = _clFunc.Exibe_StrEsquerda("NOME: " & nomeClient, 70)
            strLinha += _clFunc.Exibe_StrDireita("CNPJ/CPF: " & cnpjCpfClient, 30)
            s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 100))

            strLinha = _clFunc.Exibe_StrEsquerda("ENDEREÇO: " & endereco, 34)
            strLinha += _clFunc.Exibe_StrEsquerda("BAIRRO: " & bairroClient, 30)
            strLinha += _clFunc.Exibe_StrEsquerda("CIDADE: " & cidClient, 30)
            strLinha += _clFunc.Exibe_StrDireita("UF: " & ufClient, 6)
            s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 100))
            s.WriteLine("____________________________________________________________________________________________________")


            oConnBDGENOV.ClearAllPools()
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            cmdRetorno = Nothing : sqlRetorno = Nothing : drRetorno = Nothing : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho do Retorno:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return
            s.Close()

        Finally
            oConnBDGENOV = Nothing
        End Try



    End Sub

    Private Sub gravaItemsIndividual(ByVal s As StreamWriter, ByVal pedido As String, _
                                     ByVal loja As String)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd As String
        Dim mQtdeProd, mVlProd, mVlTotProd As Decimal
        Dim mVlIpiProd As Decimal, mSomaTotProd As Decimal
        Dim UndIten, strLinha As String
        strLinha = "" : UndIten = ""

        Try
            oConnBDGENOV.Open()

            Dim sqlItem As New StringBuilder
            Dim cmdItem As NpgsqlCommand
            Dim drItem As NpgsqlDataReader
            Dim mContItens As Integer = _valorZERO


            sqlItem.Append("SELECT rtc_codprod, rtc_nomeprod, rtc_qtde, rtc_vlrunit, rtc_vlrtotal ") '4
            sqlItem.Append("FROM " & MdlEmpresaUsu._esqEstab & ".retorno2cc WHERE rtc_numpedido = '" & pedido & "' AND ")
            sqlItem.Append("rtc_loja = '" & loja & "'")

            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
            drItem = cmdItem.ExecuteReader

            If drItem.HasRows = True Then
                '                     1         2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                's.WriteLine("____________________________________________________________________________________________________")
                s.WriteLine("   CODIGO DESCRICÃO DO PRODUTO                                  QUANT.        V.UNIT      VL. TOTAL")
                s.WriteLine("")
                '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxxZxxxxxxxxx    99,999.99    999,999.99   9,999,999.99  
                's.WriteLine("____________________________________________________________________________________________________")

            End If

            mSomaTotProd = _valorZERO
            While drItem.Read

                mCodProd = drItem(_valorZERO).ToString : mNomeProd = drItem(1).ToString : mNcmProd = ""
                mQtdeProd = drItem(2) : mVlProd = drItem(3) : mVlTotProd = drItem(4)
                mSomaTotProd += mVlTotProd

                strLinha = "   " & _clFunc.Exibe_Str(mCodProd, 6) & " " & _clFunc.Exibe_Str(mNomeProd, 49) & _
                "  " & _clFunc.Exibe_StrDireita(Format(mQtdeProd, "###,##0.00"), 9) & "    " & _
                _clFunc.Exibe_StrDireita(Format(mVlProd, "###,##0.00"), 10) & "   " & _
                _clFunc.Exibe_StrDireita(Format(mVlTotProd, "###,##0.00"), 12) '106 CARACTERES

                s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))
                mContItens += 1
            End While
            drItem.Close()

            If mSomaTotProd > _valorZERO Then

                s.WriteLine("")
                If mContItens > 1 Then

                    strLinha = "   " & _clFunc.Exibe_StrEsquerda("TOTAIS --->     " & _
                    _clFunc.Exibe_StrDireita(mContItens, 3) & " - Itens", 38)

                Else
                    strLinha = "   " & _clFunc.Exibe_StrEsquerda("TOTAIS --->     " & _
                    _clFunc.Exibe_StrDireita(mContItens, 3) & " - Iten", 38)

                End If
                strLinha += _clFunc.Exibe_StrDireita(Format(mSomaTotProd, "###,##0.00"), 58) '106 CARACTERES
                s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))

                '                     1         2         3         4         5         6         7         8         9         0
                '            1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("____________________________________________________________________________________________________")
            End If

            oConnBDGENOV.ClearPool()
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
            mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing : mCstProd = Nothing
            mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing : mVlIpiProd = Nothing
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            s.Close()

        End Try



    End Sub

    Private Sub executaConsulta(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações do(s) Retorno(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\consultaRetorno.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Catch ex As Exception

            Try
                fs.Dispose() : File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex01 As Exception
                MsgBox(ex01.Message, MsgBoxStyle.Exclamation)
            End Try

        End Try


        Dim s As New StreamWriter(fs)
        _PrintFont = New Font("Lucida Console", 9) : Dim strLinha As String = ""
        Dim linhasPorPagina As Integer = 90 ' 90 para as configurações de impressão e Font 9
        Dim linhaAtual As Integer = _valorZERO
        Dim pg As Integer = _valorZERO


        s.Write(vbNewLine) : s.WriteLine(_clFunc.Centraliza_Str("RELATÓRIO DO RETORNO", 100))
        s.Write(vbNewLine) : linhaAtual += 3

        Dim loja As String = Me.dtg_retornos.CurrentRow.Cells(1).Value
        Dim codCli As String = Me.dtg_retornos.CurrentRow.Cells(8).Value
        Dim dtEntrega As String = Me.dtg_retornos.CurrentRow.Cells(6).Value
        Dim pedido As String = Me.dtg_retornos.CurrentRow.Cells(2).Value
        Dim mapa As String = Me.dtg_retornos.CurrentRow.Cells(3).Value


        'cabeçalho
        Dim lShouldReturn2 As Boolean
        pg += 1
        GravCabecalhoConsultaEmpresa(s, loja, pedido, codCli, pg, linhaAtual, lShouldReturn2)
        If lShouldReturn2 Then Return
        lShouldReturn2 = Nothing


        For Each row As DataGridViewRow In Me.dtg_retornos.Rows

            If Not row.IsNewRow Then


                loja = row.Cells(1).Value : codCli = row.Cells(8).Value
                dtEntrega = row.Cells(6).Value : pedido = row.Cells(2).Value
                mapa = row.Cells(3).Value

                s.WriteLine("....................................................................................................")
                'titulo
                Try
                    strLinha = _clFunc.Exibe_Str(("PEDIDO: " & pedido), 20)
                    strLinha += _clFunc.Exibe_Str(("MAPA: " & mapa), 61)
                    strLinha += _clFunc.Exibe_Str(("ENTREGA: " & dtEntrega), 21)
                    s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))

                Catch ex As Exception
                End Try


                Dim lShouldReturn3 As Boolean
                GravCabecalhoConsultaCliente(s, loja, pedido, codCli, linhaAtual, lShouldReturn3)
                If lShouldReturn3 Then Return
                lShouldReturn2 = Nothing

                'itens
                gravaItemsConsulta(s, pedido, loja, linhaAtual)

            End If
        Next


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

    Private Sub GravCabecalhoConsultaEmpresa(ByVal s As StreamWriter, ByVal loja As String, _
                                 ByVal pedido As String, ByVal codCli As String, ByRef pg As Integer, _
                                 ByRef linhaAtual As Integer, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try

            Dim strLinha As String = ""
            Dim dtHoje As String = Format(Date.Now, "dd/MM/yyyy")

            oConnBDGENOV.Open()

            'Traz dados do Estabelecimento do retorno...
            Dim sqlRetorno As New StringBuilder
            Dim cmdRetorno As NpgsqlCommand
            Dim drRetorno As NpgsqlDataReader

            sqlRetorno.Append("SELECT g_geno, g_cgc, g_insc, g_uf, g_ender, g_cid ")
            sqlRetorno.Append("FROM geno001 WHERE SUBSTR(g_codig, 3, 3) = '0" & loja & "'")

            cmdRetorno = New NpgsqlCommand(sqlRetorno.ToString, oConnBDGENOV)
            drRetorno = cmdRetorno.ExecuteReader

            Dim nomeEstab, cnpjEstab, inscEstab, ufEstab, enderEstab, cidEstab As String

            nomeEstab = "" : cnpjEstab = "" : inscEstab = "" : ufEstab = "" : enderEstab = ""
            cidEstab = ""

            While drRetorno.Read

                nomeEstab = drRetorno(_valorZERO) : cnpjEstab = drRetorno(1) : inscEstab = drRetorno(2)
                ufEstab = drRetorno(3) : enderEstab = drRetorno(4) : cidEstab = drRetorno(5)

            End While
            cmdRetorno.CommandText = "" : drRetorno.Close() : sqlRetorno.Remove(_valorZERO, sqlRetorno.ToString.Length)


            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = _clFunc.Exibe_StrEsquerda("ESTABELECIMENTO: " & nomeEstab, 100)
            s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 100))

            strLinha = _clFunc.Exibe_StrEsquerda("CNPJ/CPF: " & cnpjEstab, 70)
            strLinha += _clFunc.Exibe_StrDireita("DATA: " & dtHoje, 20)
            strLinha += _clFunc.Exibe_StrDireita("Pg. " & String.Format("{0:D3}", pg), 10)
            s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 100))
            's.WriteLine("____________________________________________________________________________________________________")
            s.WriteLine("")
            linhaAtual += 3

            oConnBDGENOV.ClearPool()
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            cmdRetorno = Nothing : sqlRetorno = Nothing : drRetorno = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho Empresa do Retorno:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return
            s.Close()

        Finally
            oConnBDGENOV = Nothing
        End Try



    End Sub

    Private Sub GravCabecalhoConsultaCliente(ByVal s As StreamWriter, ByVal loja As String, _
                                 ByVal pedido As String, ByVal codCli As String, _
                                 ByRef linhaAtual As Integer, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try

            Dim strLinha As String = ""

            oConnBDGENOV.Open()

            'Traz dados do Estabelecimento do retorno...
            Dim sqlRetorno As New StringBuilder
            Dim cmdRetorno As NpgsqlCommand
            Dim drRetorno As NpgsqlDataReader


            'Traz dados do CLIENTE do retorno...
            sqlRetorno.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro ")
            sqlRetorno.Append("FROM cadp001 WHERE p_cod = '" & codCli & "'")

            cmdRetorno = New NpgsqlCommand(sqlRetorno.ToString, oConnBDGENOV)
            drRetorno = cmdRetorno.ExecuteReader

            Dim nomeClient, cnpjCpfClient, endereco, ufClient, cidClient, bairroClient As String

            nomeClient = "" : cnpjCpfClient = "" : endereco = "" : ufClient = "" : cidClient = ""
            bairroClient = ""

            While drRetorno.Read

                cnpjCpfClient = drRetorno(1).ToString
                If Trim(drRetorno(1).ToString).Equals("") Then

                    cnpjCpfClient = drRetorno(2).ToString

                End If

                nomeClient = drRetorno(_valorZERO).ToString : endereco = drRetorno(3).ToString
                ufClient = drRetorno(5).ToString : cidClient = drRetorno(4).ToString
                bairroClient = drRetorno(6).ToString

            End While
            drRetorno.Close()

            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = _clFunc.Exibe_StrEsquerda("NOME: " & nomeClient, 70)
            strLinha += _clFunc.Exibe_StrDireita("CNPJ/CPF: " & cnpjCpfClient, 30)
            s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 100))

            strLinha = _clFunc.Exibe_StrEsquerda("ENDEREÇO: " & endereco, 33) & " "
            strLinha += _clFunc.Exibe_StrEsquerda("BAIRRO: " & bairroClient, 29) & " "
            strLinha += _clFunc.Exibe_StrEsquerda("CIDADE: " & cidClient, 29) & " "
            strLinha += _clFunc.Exibe_StrDireita("UF: " & ufClient, 6)
            s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 100))
            s.WriteLine(" __________________________________________________________________________________________________")
            linhaAtual += 3

            oConnBDGENOV.ClearPool()
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            cmdRetorno = Nothing : sqlRetorno = Nothing : drRetorno = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho Cliente do Retorno:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return
            s.Close()

        Finally
            oConnBDGENOV = Nothing
        End Try



    End Sub

    Private Sub gravaItemsConsulta(ByVal s As StreamWriter, ByVal pedido As String, _
                                     ByVal loja As String, ByRef linhaAtual As Integer)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd As String
        Dim mQtdeProd, mVlProd, mVlTotProd As Decimal
        Dim mVlIpiProd As Decimal, mSomaTotProd As Decimal
        Dim UndIten, strLinha As String
        strLinha = "" : UndIten = ""

        Try
            oConnBDGENOV.Open()

            Dim sqlItem As New StringBuilder
            Dim cmdItem As NpgsqlCommand
            Dim drItem As NpgsqlDataReader
            Dim mContItens As Integer = _valorZERO


            sqlItem.Append("SELECT rtc_codprod, rtc_nomeprod, rtc_qtde, rtc_vlrunit, rtc_vlrtotal ") '4
            sqlItem.Append("FROM " & MdlEmpresaUsu._esqEstab & ".retorno2cc WHERE rtc_numpedido = '" & pedido & "' AND ")
            sqlItem.Append("rtc_loja = '" & loja & "'")

            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
            drItem = cmdItem.ExecuteReader

            If drItem.HasRows = True Then
                '                     1         2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                's.WriteLine("____________________________________________________________________________________________________")
                s.WriteLine("   CODIGO DESCRICÃO DO PRODUTO                                QUANT.        V.UNIT      VL. TOTAL")
                s.WriteLine("")
                '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxxZxxxxxxxxx  99,999.99    999,999.99   9,999,999.99  
                's.WriteLine("____________________________________________________________________________________________________")

                linhaAtual += 2
            End If

            mSomaTotProd = _valorZERO
            While drItem.Read

                mCodProd = drItem(_valorZERO).ToString : mNomeProd = drItem(1).ToString : mNcmProd = ""
                mQtdeProd = drItem(2) : mVlProd = drItem(3) : mVlTotProd = drItem(4)
                mSomaTotProd += mVlTotProd

                strLinha = "   " & _clFunc.Exibe_Str(mCodProd, 6) & " " & _clFunc.Exibe_Str(mNomeProd, 47) & _
                "  " & _clFunc.Exibe_StrDireita(Format(mQtdeProd, "###,##0.00"), 9) & "    " & _
                _clFunc.Exibe_StrDireita(Format(mVlProd, "###,##0.00"), 10) & "   " & _
                _clFunc.Exibe_StrDireita(Format(mVlTotProd, "###,##0.00"), 12) '106 CARACTERES

                s.WriteLine(_clFunc.Exibe_Str(strLinha, 100)) : linhaAtual += 1 : mContItens += 1
            End While
            drItem.Close()

            If mSomaTotProd > _valorZERO Then

                s.WriteLine("")
                If mContItens > 1 Then

                    strLinha = "   " & _clFunc.Exibe_StrEsquerda("TOTAIS --->     " & _
                    _clFunc.Exibe_StrDireita(mContItens, 3) & " - Itens", 36)

                Else
                    strLinha = "   " & _clFunc.Exibe_StrEsquerda("TOTAIS --->     " & _
                    _clFunc.Exibe_StrDireita(mContItens, 3) & " - Iten", 36)

                End If
                strLinha += _clFunc.Exibe_StrDireita(Format(mSomaTotProd, "###,##0.00"), 58) '106 CARACTERES
                s.WriteLine(_clFunc.Exibe_Str(strLinha, 100)) : linhaAtual += 1

                '                     1         2         3         4         5         6         7         8         9         0
                '            1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                's.WriteLine(" __________________________________________________________________________________________________")
                s.WriteLine(vbNewLine) : linhaAtual += 1


            End If

            oConnBDGENOV.ClearPool()
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
            mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing : mCstProd = Nothing
            mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing : mVlIpiProd = Nothing
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            s.Close()

        End Try



    End Sub

    Private Sub executaComissao(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações do(s) Retorno(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\consultaRetorno.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

        Catch ex As Exception

            Try
                fs.Dispose() : File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex01 As Exception
                MsgBox(ex01.Message, MsgBoxStyle.Exclamation)
            End Try

        End Try

        Dim s As New StreamWriter(fs)
        _PrintFont = New Font("Lucida Console", 9) : Dim strLinha As String = ""
        Dim loja As String = Me.dtg_retornos.CurrentRow.Cells(1).Value
        Dim codCli As String = Me.dtg_retornos.CurrentRow.Cells(8).Value
        Dim dtEntrega As String = Me.dtg_retornos.CurrentRow.Cells(6).Value
        Dim dtHoje As String = Format(Date.Now, "dd/MM/yyyy")
        Dim pedido As String = Me.dtg_retornos.CurrentRow.Cells(2).Value
        Dim mapa As String = Me.dtg_retornos.CurrentRow.Cells(3).Value

        Dim mAliqComissVendedor As Double = 0
        Dim mTipoComissao As String = ""
        Dim mCodVendedor As String = ""
        Dim mNomeVendedor As String = ""
        Dim mValorTotalMapa, mValorTotalMapaR As Double
        mValorTotalMapa = 0 : mValorTotalMapaR = 0

        'Setando os valores da Comissão
        setValoresComissao(codCli, mAliqComissVendedor, mTipoComissao, mCodVendedor, mNomeVendedor)

        'titulo
        Try
            s.Write(vbNewLine) : s.Write(_clFunc.Centraliza_Str("RELATÓRIO DO RETORNO COMISSÃO  " & mCodVendedor & " - " & mNomeVendedor, 100))
            s.Write(vbNewLine & vbNewLine)

            strLinha = _clFunc.Exibe_Str(("PEDIDO: " & pedido), 20)
            strLinha += _clFunc.Exibe_Str(("MAPA: " & mapa), 20)
            strLinha += _clFunc.Exibe_Str(("ENTREGA: " & dtEntrega), 44)
            strLinha += _clFunc.Exibe_Str(("DATA: " & dtHoje), 17)

            s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))
        Catch ex As Exception
        End Try


        'cabeçalho
        Dim lShouldReturn2 As Boolean
        GravCabecalhoComissao(s, loja, pedido, codCli, lShouldReturn2)
        If lShouldReturn2 Then Return

        'itens do mapa
        gravaItemsMapaComissao(s, mapa, loja, mValorTotalMapa)

        'itens do retorno do mapa
        gravaItemsRetornoMapaComissao(s, pedido, loja, mValorTotalMapaR)

        'total da comissão
        gravaTotalComissao(s, mValorTotalMapa, mValorTotalMapaR, mAliqComissVendedor, mTipoComissao)

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

    Private Sub GravCabecalhoComissao(ByVal s As StreamWriter, ByVal loja As String, _
                                 ByVal pedido As String, ByVal codCli As String, _
                                 ByRef shouldReturn As Boolean)

        shouldReturn = False
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try

            Dim strLinha As String = ""

            oConnBDGENOV.Open()

            'Traz dados do Estabelecimento do retorno...
            Dim sqlRetorno As New StringBuilder
            Dim cmdRetorno As NpgsqlCommand
            Dim drRetorno As NpgsqlDataReader

            sqlRetorno.Append("SELECT g_geno, g_cgc, g_insc, g_uf, g_ender, g_cid ")
            sqlRetorno.Append("FROM geno001 WHERE SUBSTR(g_codig, 3, 3) = '0" & loja & "'")

            cmdRetorno = New NpgsqlCommand(sqlRetorno.ToString, oConnBDGENOV)
            drRetorno = cmdRetorno.ExecuteReader

            Dim nomeEstab, cnpjEstab, inscEstab, ufEstab, enderEstab, cidEstab As String

            nomeEstab = "" : cnpjEstab = "" : inscEstab = "" : ufEstab = "" : enderEstab = ""
            cidEstab = ""

            While drRetorno.Read

                nomeEstab = drRetorno(_valorZERO) : cnpjEstab = drRetorno(1) : inscEstab = drRetorno(2)
                ufEstab = drRetorno(3) : enderEstab = drRetorno(4) : cidEstab = drRetorno(5)

            End While
            cmdRetorno.CommandText = "" : drRetorno.Close() : sqlRetorno.Remove(_valorZERO, sqlRetorno.ToString.Length)



            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = _clFunc.Exibe_StrEsquerda("ESTABELECIMENTO: " & nomeEstab, 70)
            strLinha += _clFunc.Exibe_StrDireita("CNPJ/CPF: " & cnpjEstab, 30)
            s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 100))
            s.WriteLine("____________________________________________________________________________________________________")


            'Traz dados do CLIENTE do retorno...
            sqlRetorno.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro ")
            sqlRetorno.Append("FROM cadp001 WHERE p_cod = '" & codCli & "'")

            cmdRetorno = New NpgsqlCommand(sqlRetorno.ToString, oConnBDGENOV)
            drRetorno = cmdRetorno.ExecuteReader

            Dim nomeClient, cnpjCpfClient, endereco, ufClient, cidClient, bairroClient As String

            nomeClient = "" : cnpjCpfClient = "" : endereco = "" : ufClient = "" : cidClient = ""
            bairroClient = ""

            While drRetorno.Read

                cnpjCpfClient = drRetorno(1).ToString
                If Trim(drRetorno(1).ToString).Equals("") Then

                    cnpjCpfClient = drRetorno(2).ToString

                End If

                nomeClient = drRetorno(_valorZERO).ToString : endereco = drRetorno(3).ToString
                ufClient = drRetorno(5).ToString : cidClient = drRetorno(4).ToString
                bairroClient = drRetorno(6).ToString

            End While
            drRetorno.Close()

            '                 1         2         3         4         5         6         7         8         9         0         1         2
            '        123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            strLinha = _clFunc.Exibe_StrEsquerda("NOME: " & nomeClient, 70)
            strLinha += _clFunc.Exibe_StrDireita("CNPJ/CPF: " & cnpjCpfClient, 30)
            s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 100))

            strLinha = _clFunc.Exibe_StrEsquerda("ENDEREÇO: " & endereco, 34)
            strLinha += _clFunc.Exibe_StrEsquerda("BAIRRO: " & bairroClient, 30)
            strLinha += _clFunc.Exibe_StrEsquerda("CIDADE: " & cidClient, 30)
            strLinha += _clFunc.Exibe_StrDireita("UF: " & ufClient, 6)
            s.WriteLine(_clFunc.Exibe_cabecalho(strLinha, 4, 100))
            s.WriteLine("____________________________________________________________________________________________________")


            oConnBDGENOV.ClearAllPools()
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            cmdRetorno = Nothing : sqlRetorno = Nothing : drRetorno = Nothing : oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho do Retorno:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return
            s.Close()

        Finally
            oConnBDGENOV = Nothing
        End Try



    End Sub

    Private Sub gravaItemsMapaComissao(ByVal s As StreamWriter, ByVal mapa As String, _
                                     ByVal loja As String, ByRef valorTotalMapa As Double)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd As String
        Dim mQtdeProd, mVlProd, mVlTotProd As Decimal
        Dim mVlIpiProd As Decimal, mSomaTotProd As Decimal
        Dim UndIten, strLinha As String
        strLinha = "" : UndIten = ""

        Try
            oConnBDGENOV.Open()

            Dim sqlItem As New StringBuilder
            Dim cmdItem As NpgsqlCommand
            Dim drItem As NpgsqlDataReader
            Dim mContItens As Integer = _valorZERO


            sqlItem.Append("SELECT mc_codpr, mc_descricao, mc_qtde, mc_valorunit, mc_total, e_pcusto, e_pcomp ") '6
            sqlItem.Append("FROM " & MdlEmpresaUsu._esqEstab & ".mapa2cc JOIN estloja01 ON e_loja = '" & loja & "' AND e_codig = mc_codpr ")
            sqlItem.Append("WHERE mc_numero = '" & mapa & "' AND mc_local = '" & loja & "'")

            'sqlItem.Append("SELECT rtc_codprod, rtc_nomeprod, rtc_qtde, rtc_vlrunit, rtc_vlrtotal ") '4
            'sqlItem.Append("FROM " & MdlEmpresaUsu._esqEstab & ".retorno2cc WHERE rtc_numpedido = '" & pedido & "' AND ")
            'sqlItem.Append("rtc_loja = '" & loja & "'")

            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
            drItem = cmdItem.ExecuteReader

            If drItem.HasRows = True Then
                '                     1         2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                's.WriteLine("____________________________________________________________________________________________________")
                s.WriteLine("Itens do Mapa:")
                s.WriteLine("   CODIGO DESCRICÃO DO PRODUTO                                  QUANT.        V.UNIT      VL. TOTAL")
                s.WriteLine("")
                '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxxZxxxxxxxxx    99,999.99    999,999.99   9,999,999.99  
                's.WriteLine("____________________________________________________________________________________________________")

            End If

            mSomaTotProd = _valorZERO
            While drItem.Read

                mCodProd = drItem(_valorZERO).ToString : mNomeProd = drItem(1).ToString : mNcmProd = ""
                mQtdeProd = drItem(2) : mVlProd = drItem(3) : mVlTotProd = drItem(4)
                mSomaTotProd += Round(mVlTotProd, 2)

                'mSomaPcoCusto += Round(drItem(5) * mQtdeProd, 2)
                'mSomaPcoCompra += Round(drItem(6) * mQtdeProd, 2)

                strLinha = "   " & _clFunc.Exibe_Str(mCodProd, 6) & " " & _clFunc.Exibe_Str(mNomeProd, 49) & _
                "  " & _clFunc.Exibe_StrDireita(Format(mQtdeProd, "###,##0.00"), 9) & "    " & _
                _clFunc.Exibe_StrDireita(Format(mVlProd, "###,##0.00"), 10) & "   " & _
                _clFunc.Exibe_StrDireita(Format(mVlTotProd, "###,##0.00"), 12) '106 CARACTERES

                s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))
                mContItens += 1
            End While
            drItem.Close()

            If mSomaTotProd > _valorZERO Then

                s.WriteLine("")
                If mContItens > 1 Then

                    strLinha = "   " & _clFunc.Exibe_StrEsquerda("TOTAIS --->     " & _
                    _clFunc.Exibe_StrDireita(mContItens, 3) & " - Itens", 38)

                Else
                    strLinha = "   " & _clFunc.Exibe_StrEsquerda("TOTAIS --->     " & _
                    _clFunc.Exibe_StrDireita(mContItens, 3) & " - Iten", 38)

                End If
                valorTotalMapa = mSomaTotProd
                strLinha += _clFunc.Exibe_StrDireita(Format(mSomaTotProd, "###,##0.00"), 58) '106 CARACTERES
                s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))

                '                     1         2         3         4         5         6         7         8         9         0
                '            1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                's.WriteLine("____________________________________________________________________________________________________")
                s.WriteLine("")
            End If

            oConnBDGENOV.ClearPool()
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
            mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing : mCstProd = Nothing
            mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing : mVlIpiProd = Nothing
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            s.Close()

        End Try



    End Sub

    Private Sub gravaItemsRetornoMapaComissao(ByVal s As StreamWriter, ByVal pedido As String, _
                                     ByVal loja As String, ByRef valorTotalMapaR As Double)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mCodProd, mNomeProd, mNcmProd, mCfopProd, mCstProd As String
        Dim mQtdeProd, mVlProd, mVlTotProd As Decimal
        Dim mVlIpiProd As Decimal, mSomaTotProd As Decimal
        Dim UndIten, strLinha As String
        strLinha = "" : UndIten = ""

        Try
            oConnBDGENOV.Open()

            Dim sqlItem As New StringBuilder
            Dim cmdItem As NpgsqlCommand
            Dim drItem As NpgsqlDataReader
            Dim mContItens As Integer = _valorZERO


            sqlItem.Append("SELECT rtc_codprod, rtc_nomeprod, rtc_qtde, rtc_vlrunit, rtc_vlrtotal, e_pcusto, e_pcomp ") '6
            sqlItem.Append("FROM " & MdlEmpresaUsu._esqEstab & ".retorno2cc JOIN estloja01 ON e_loja = '" & loja & "' AND e_codig = rtc_codprod")
            sqlItem.Append(" WHERE rtc_numpedido = '" & pedido & "' AND rtc_loja = '" & loja & "'")

            cmdItem = New NpgsqlCommand(sqlItem.ToString, oConnBDGENOV)
            drItem = cmdItem.ExecuteReader

            If drItem.HasRows = True Then
                '                     1         2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                's.WriteLine("____________________________________________________________________________________________________")
                s.WriteLine(vbNewLine & "Itens do Retorno do Mapa:")
                s.WriteLine("   CODIGO DESCRICÃO DO PRODUTO                                  QUANT.        V.UNIT      VL. TOTAL")
                s.WriteLine("")
                '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxxZxxxxxxxxx    99,999.99    999,999.99   9,999,999.99  
                's.WriteLine("____________________________________________________________________________________________________")

            End If

            mSomaTotProd = _valorZERO
            While drItem.Read

                mCodProd = drItem(_valorZERO).ToString : mNomeProd = drItem(1).ToString : mNcmProd = ""
                mQtdeProd = drItem(2) : mVlProd = drItem(3) : mVlTotProd = drItem(4)
                mSomaTotProd += Round(mVlTotProd, 2)

                mSomaPcoCusto += Round(drItem(5) * mQtdeProd, 2)
                mSomaPcoCompra += Round(drItem(6) * mQtdeProd, 2)

                strLinha = "   " & _clFunc.Exibe_Str(mCodProd, 6) & " " & _clFunc.Exibe_Str(mNomeProd, 49) & _
                "  " & _clFunc.Exibe_StrDireita(Format(mQtdeProd, "###,##0.00"), 9) & "    " & _
                _clFunc.Exibe_StrDireita(Format(mVlProd, "###,##0.00"), 10) & "   " & _
                _clFunc.Exibe_StrDireita(Format(mVlTotProd, "###,##0.00"), 12) '106 CARACTERES

                s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))
                mContItens += 1
            End While
            drItem.Close()

            If mSomaTotProd > _valorZERO Then

                s.WriteLine("")
                If mContItens > 1 Then

                    strLinha = "   " & _clFunc.Exibe_StrEsquerda("TOTAIS --->     " & _
                    _clFunc.Exibe_StrDireita(mContItens, 3) & " - Itens", 38)

                Else
                    strLinha = "   " & _clFunc.Exibe_StrEsquerda("TOTAIS --->     " & _
                    _clFunc.Exibe_StrDireita(mContItens, 3) & " - Iten", 38)

                End If
                valorTotalMapaR = mSomaTotProd
                strLinha += _clFunc.Exibe_StrDireita(Format(mSomaTotProd, "###,##0.00"), 58) '106 CARACTERES
                s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))

                '                     1         2         3         4         5         6         7         8         9         0
                '            1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("                                                                                       -------------")
                's.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _")
                's.WriteLine("")
            End If

            oConnBDGENOV.ClearPool()
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            cmdItem = Nothing : sqlItem = Nothing : drItem = Nothing : mCodProd = Nothing
            mNomeProd = Nothing : mNcmProd = Nothing : mCfopProd = Nothing : mCstProd = Nothing
            mQtdeProd = Nothing : mVlProd = Nothing : mVlTotProd = Nothing : mVlIpiProd = Nothing
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            s.Close()

        End Try



    End Sub

    Private Sub setValoresComissao(ByVal codCliente As String, ByRef aliqComissao As Double, ByRef tipoComissao As String, _
                                   ByRef codVendedor As String, ByRef nomeVendedor As String)
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()

            Dim sql As New StringBuilder
            Dim cmd As NpgsqlCommand
            Dim dr As NpgsqlDataReader

            sql.Append("SELECT v_alqcomiss, v_tipocomissao, p_vend, v_nome FROM cadvendedor LEFT JOIN cadp001 ON  p_cod = '" & codCliente & "' ") '4
            sql.Append("AND p_vend = v_codigo WHERE Trim(p_vend) <> ''")
            cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
            dr = cmd.ExecuteReader

            While dr.Read

                aliqComissao = dr(0) : tipoComissao = dr(1).ToString
                codVendedor = dr(2).ToString : nomeVendedor = dr(3).ToString
            End While
            dr.Close()
            oConnBDGENOV.ClearPool()
            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            cmd = Nothing : sql = Nothing : dr = Nothing
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)

        End Try

    End Sub

    Private Sub gravaTotalComissao(ByVal s As StreamWriter, ByVal valorTotalMapa As Double, ByVal valorTotalMapaR As Double, _
                                   ByVal aliqComissao As Double, ByVal tipoComissao As String)
        Dim strLinha As String = ""
        Try

            If valorTotalMapa > _valorZERO Then

                's.WriteLine(vbNewLine)
                strLinha = "   " & _clFunc.Exibe_StrEsquerda("TOTAL PELO PCO_CUSTO --->     ", 38)
                strLinha += _clFunc.Exibe_StrDireita(Format(Round(mSomaPcoCusto, 2), "###,##0.00"), 58) '106 CARACTERES
                s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))
                strLinha = "   " & _clFunc.Exibe_StrEsquerda("TOTAL PELO PCO_COMPRA --->     ", 38)
                strLinha += _clFunc.Exibe_StrDireita(Format(Round(mSomaPcoCompra, 2), "###,##0.00"), 58) '106 CARACTERES
                s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))
                strLinha = "   " & _clFunc.Exibe_StrEsquerda("TOTAL NAO RETORNADO --->     ", 38)
                strLinha += _clFunc.Exibe_StrDireita(Format(Round((valorTotalMapa - valorTotalMapaR), 2), "###,##0.00"), 58) '106 CARACTERES
                s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))
                strLinha = "   " & _clFunc.Exibe_StrEsquerda("COMISSAO (" & Format(Round(aliqComissao, 2), "##0.00") & " %)  --->", 38)
                Try
                    Select Case tipoComissao
                        Case "T"
                            strLinha += _clFunc.Exibe_StrDireita(Format(Round(((valorTotalMapa - valorTotalMapaR) * aliqComissao) / 100, 2), "###,##0.00"), 58)
                    End Select
                Catch ex As Exception
                    strLinha += "0,00"
                End Try
                s.WriteLine(_clFunc.Exibe_Str(strLinha, 100))

                '                     1         2         3         4         5         6         7         8         9         0
                '            1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("____________________________________________________________________________________________________")
            End If

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
            s.Close()

        End Try



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
            e.HasMorePages = False : _StringToPrint = _stringToPrintAux

        End If



    End Sub

    Private Sub LerOArquivoSalvo(ByVal arqSaida As String)
        'Ler o Arquivo salvo...
        Dim FilePath As String = arqSaida
        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrint = MyfileStream.ReadToEnd : MyfileStream.Close() : MyfileStream.Dispose()
            MyfileStream = Nothing 'File.Delete(arqSaida)

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
            PrintPreviewDialog1.Text = "Vizualizando RETORNOS"

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

    Private Sub Frm_ManRetorMp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")

        End If


    End Sub

    Private Sub Frm_ManRetorMp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cbo_loja.SelectedIndex = _valorZERO

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler PrintDocument1.BeginPrint, AddressOf InicializaRelatorio
    End Sub

    Private Sub cbo_verPor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_verPor.SelectedIndexChanged

        If cbo_verPor.SelectedIndex = _valorZERO Then

            Me.txt_numero.Text = "" : Me.txt_numero.Enabled = False

        Else
            Me.txt_numero.Text = "" : Me.txt_numero.Enabled = True

        End If



    End Sub

    Private Sub txt_numero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero.KeyPress
        'permite só numeros
        If _clFunc.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub rmi_ralatIndividual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rmi_ralatIndividual.Click
        'Relatório Individual...
        If (Me.dtg_retornos.Rows.Count > _valorZERO) AndAlso (Me.dtg_retornos.SelectedCells.Count > 0) Then

             executaIndividual("", "\wged\consultaRetorno.txt")

        End If


    End Sub

    Private Sub rmi_ralatConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rmi_ralatConsulta.Click
        'Relatório da Consulta...
        If (Me.dtg_retornos.Rows.Count > _valorZERO) AndAlso (Me.dtg_retornos.SelectedCells.Count > 0) Then

            executaConsulta("", "\wged\consultaRetorno.txt")

        End If


    End Sub

    Private Sub rmi_ralatComissao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rmi_ralatComissao.Click
        'Relatório Comissao...
        If (Me.dtg_retornos.Rows.Count > _valorZERO) AndAlso (Me.dtg_retornos.SelectedCells.Count > 0) Then

            executaComissao("", "\wged\consultaRetorno.txt")

        End If


    End Sub
End Class