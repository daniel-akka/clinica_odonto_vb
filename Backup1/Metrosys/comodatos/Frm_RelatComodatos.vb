Imports System
Imports System.Data
Imports System.IO
Imports System.Drawing.Printing
Imports System.Text
Imports Npgsql

Public Class Frm_RelatComodatos

    Private _clBD As New Cl_bdMetrosys
    Private _clFunc As New ClFuncoes
    Private Const _valorZERO As Integer = 0
    Public _privilegio As Boolean = False
    Private _idMovComodato As Int32 = _valorZERO
    Dim _ufCorrenteCbo As String = ""

    'ultilizados para o DataGridView
    Private _oConnBDHEMOSIS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Private _cmdComodato As New NpgsqlCommand
    Private _sqlComodato As New StringBuilder
    Private _drComodato As NpgsqlDataReader

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

    Private Sub Frm_ManComodato_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                preencheDtg_MovComodatos()

        End Select


    End Sub

    Private Sub Frm_ManComodato_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Frm_ManComodato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Dtg_MovComodatos.Rows.Clear()
        Me.Dtg_MovComodatos.Refresh()
        preencheDtg_MovComodatos()

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler PrintDocument1.BeginPrint, AddressOf InicializaRelatorio
    End Sub

    Private Sub cbo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo.GotFocus

        If Not (cbo_tipo.DroppedDown) Then cbo_tipo.DroppedDown = True

    End Sub

    Private Sub cbo_uf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_uf.GotFocus

        If Not (cbo_uf.DroppedDown) Then cbo_uf.DroppedDown = True

    End Sub

    Private Sub cbo_uf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_uf.Leave

        If _ufCorrenteCbo.Equals("") Then

            If cbo_uf.SelectedIndex >= _valorZERO Then

                Me.cbo_cidade = _clFunc.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
                _ufCorrenteCbo = Me.cbo_uf.Text

            End If
        ElseIf cbo_uf.SelectedIndex > _valorZERO And Not _ufCorrenteCbo.Equals(cbo_uf.Text) Then

            Me.cbo_cidade = _clFunc.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
            _ufCorrenteCbo = Me.cbo_uf.Text

        End If



    End Sub


    Private Sub preencheDtg_MovComodatos()

        Dim codTipoComodato As String = Mid(cbo_tipo.SelectedItem, 1, 2)

        Try
            If _oConnBDHEMOSIS.State = ConnectionState.Closed Then _oConnBDHEMOSIS.Open()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        If _oConnBDHEMOSIS.State = ConnectionState.Open Then
            Dim idComodato, cliente, produto, plaqueta As String
            Dim dtEmprestimo As Date

            Try

                _sqlComodato.Remove(0, _sqlComodato.ToString.Length)
                _sqlComodato.Append("SELECT mv.mc_id, mv.mc_cdport, cad.p_portad, mv.mc_codpr, mv.mc_produto, ") '4
                _sqlComodato.Append("mv.mc_dtemprestimo, mv.mc_dtdevolucao, mv.mc_motorista, ci.im_plaqueta ") '8
                _sqlComodato.Append("FROM " & MdlEmpresaUsu._esqVinc & ".cadimobilizado ci, " & MdlEmpresaUsu._esqVinc)
                _sqlComodato.Append(".movcomodato mv LEFT JOIN cadp001 cad ON ")
                _sqlComodato.Append("mv.mc_cdport = cad.p_cod WHERE mv.mc_codpr = ci.im_codprid ")


                If cbo_uf.SelectedIndex > _valorZERO Then _sqlComodato.Append("AND cad.p_uf = '" & Me.cbo_uf.SelectedItem & "' ")
                If cbo_cidade.SelectedIndex > _valorZERO Then

                    If cbo_uf.SelectedIndex > _valorZERO Then

                        _sqlComodato.Append("AND cad.p_cid = '" & Me.cbo_cidade.SelectedItem & "' ")
                    Else

                        _sqlComodato.Append("AND cad.p_cid = '" & Me.cbo_cidade.SelectedItem & "' ")
                    End If
                End If

                Select Case Me.cbo_tipo.SelectedIndex
                    Case 0 'Freezer
                        _sqlComodato.Append("AND ci.im_tipo LIKE @im_tipo ")
                        _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)
                        _cmdComodato.Parameters.Add("@im_tipo", "01")

                    Case 1 'Outros
                        _sqlComodato.Append("AND ci.im_tipo LIKE @im_tipo ")
                        _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)
                        _cmdComodato.Parameters.Add("@im_tipo", "02")


                    Case 2 'Todos os Comodatos
                        _sqlComodato.Append("AND ci.im_tipo LIKE @im_tipo ")
                        _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)
                        _cmdComodato.Parameters.Add("@im_tipo", "%")

                    Case Else
                        _sqlComodato.Append("AND ci.im_tipo LIKE @im_tipo ")
                        _cmdComodato = New NpgsqlCommand(_sqlComodato.ToString, _oConnBDHEMOSIS)
                        _cmdComodato.Parameters.Add("@im_tipo", "%")

                End Select


                _drComodato = _cmdComodato.ExecuteReader

                Dtg_MovComodatos.Rows.Clear()
                Dtg_MovComodatos.Refresh()
                While _drComodato.Read
                    idComodato = _drComodato(0).ToString
                    cliente = _drComodato(2).ToString
                    produto = _drComodato(4).ToString
                    plaqueta = _drComodato(8).ToString
                    dtEmprestimo = _drComodato(5)

                    Dtg_MovComodatos.Rows.Add(idComodato, cliente, produto, plaqueta, _
                                              Format(dtEmprestimo, "dd/MM/yyyy"))

                End While

                Dtg_MovComodatos.Refresh()
                _drComodato.Close() : _oConnBDHEMOSIS.ClearPool()
            Catch ex As Exception
                MsgBox("ERRO ao trazer Movimento:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")

            Finally
                idComodato = Nothing : cliente = Nothing : produto = Nothing : plaqueta = Nothing
                dtEmprestimo = Nothing

            End Try

            _cmdComodato.CommandText = ""
            _sqlComodato.Remove(0, _sqlComodato.ToString.Length)
        End If



    End Sub

    Private Sub cbo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tipo.SelectedIndexChanged

        preencheDtg_MovComodatos()
    End Sub


    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        executaF6()
    End Sub

    Private Sub executaRelatorio(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPconsultaComod.TMP"
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


        'titulo
        Try
            'vbCrLf, vbCr, vbLf, vbNewLine = quebra de linha
            s.Write(vbNewLine & vbNewLine)
            '8 caracteres
            strLinha = _clFunc.Centraliza_Str("COMODATOS", 100)
            s.WriteLine(strLinha & vbNewLine)
            If cbo_uf.SelectedIndex >= 0 Then s.Write("UF: " & _clFunc.Exibe_StrEsquerda(cbo_uf.SelectedItem.ToString, 26))
            If cbo_cidade.SelectedIndex >= 0 Then s.WriteLine("CIDADE: " & _clFunc.Exibe_StrEsquerda(cbo_uf.SelectedItem.ToString, 62) & vbNewLine)

        Catch ex As Exception
        End Try


        'Participantes
        gravaComodatos(s)


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

    Private Sub gravaComodatos(ByVal s As StreamWriter)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim nomeCampo As String = "", nomeCampoAux As String = "", mfone As String = ""
        Dim strLinha As String = "", mContItens As Integer = _valorZERO

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try


        Dim sqlComodato As New StringBuilder
        Dim cmdComodato As NpgsqlCommand
        Dim drComodato As NpgsqlDataReader

        Dim idComodato, cliente, produto, plaqueta, uf, cidade As String
        Dim dtEmprestimo As Date

        Try
            sqlComodato.Remove(0, sqlComodato.ToString.Length)
            sqlComodato.Append("SELECT mv.mc_id, mv.mc_cdport, cad.p_portad, mv.mc_codpr, mv.mc_produto, ") '4
            sqlComodato.Append("mv.mc_dtemprestimo, mv.mc_dtdevolucao, mv.mc_motorista, ci.im_plaqueta ") '8
            sqlComodato.Append("FROM " & MdlEmpresaUsu._esqVinc & ".cadimobilizado ci, " & MdlEmpresaUsu._esqVinc)
            sqlComodato.Append(".movcomodato mv LEFT JOIN cadp001 cad ON ")
            sqlComodato.Append("mv.mc_cdport = cad.p_cod WHERE mv.mc_codpr = ci.im_codprid ")


            If cbo_uf.SelectedIndex > _valorZERO Then sqlComodato.Append("AND cad.p_uf = '" & Me.cbo_uf.SelectedItem & "' ")
            If cbo_cidade.SelectedIndex > _valorZERO Then

                If cbo_uf.SelectedIndex > _valorZERO Then

                    sqlComodato.Append("AND cad.p_cid = '" & Me.cbo_cidade.SelectedItem & "' ")
                Else

                    sqlComodato.Append("AND cad.p_cid = '" & Me.cbo_cidade.SelectedItem & "' ")
                End If
            End If

            Select Case Me.cbo_tipo.SelectedIndex
                Case 0 'Freezer
                    sqlComodato.Append("AND ci.im_tipo LIKE @im_tipo ")
                    cmdComodato = New NpgsqlCommand(sqlComodato.ToString, oConnBDGENOV)
                    cmdComodato.Parameters.Add("@im_tipo", "01")

                Case 1 'Outros
                    sqlComodato.Append("AND ci.im_tipo LIKE @im_tipo ")
                    cmdComodato = New NpgsqlCommand(sqlComodato.ToString, oConnBDGENOV)
                    cmdComodato.Parameters.Add("@im_tipo", "02")


                Case 2 'Todos os Comodatos
                    sqlComodato.Append("AND ci.im_tipo LIKE @im_tipo ")
                    cmdComodato = New NpgsqlCommand(sqlComodato.ToString, oConnBDGENOV)
                    cmdComodato.Parameters.Add("@im_tipo", "%")

                Case Else
                    sqlComodato.Append("AND ci.im_tipo LIKE @im_tipo ")
                    cmdComodato = New NpgsqlCommand(sqlComodato.ToString, oConnBDGENOV)
                    cmdComodato.Parameters.Add("@im_tipo", "%")

            End Select


            drComodato = cmdComodato.ExecuteReader

            If drComodato.HasRows = True Then
                '                     1         2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("-------------------------------------------------------------------------------------------------")
                s.WriteLine("  CLIENTE                                  PRODUTO              PLAQUETA             EMPRESTIMO ")
                '              xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZ xxxxxxxxxZxxxxxxxxxZ xxxxxxxxxZxxxxxxxxxZ xxxxxxxxxZ
                s.WriteLine("  ---------------------------------------------------------------------------------------------")

            End If

            While drComodato.Read

                idComodato = drComodato(0).ToString
                cliente = drComodato(2).ToString
                produto = drComodato(4).ToString
                plaqueta = drComodato(8).ToString
                dtEmprestimo = drComodato(5)

                strLinha = "  " & _clFunc.Exibe_Str(cliente, 40) & " " & _clFunc.Exibe_StrEsquerda(produto, 20) & " " & _
                _clFunc.Exibe_StrEsquerda(plaqueta, 20) & " " & _clFunc.Exibe_StrEsquerda(Format(dtEmprestimo, "dd/MM/yyyy"), 10)

                s.WriteLine(_clFunc.Exibe_Str(strLinha, 110))
                mContItens += 1
            End While
            drComodato.Close()


        Catch ex As Exception
            Try
                drComodato.Close()

            Catch ex01 As Exception
            End Try
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        sqlComodato.Remove(_valorZERO, sqlComodato.ToString.Length) : oConnBDGENOV.ClearPool() : oConnBDGENOV.Close()

        'LIMPA OS OBJETOS DE MEMORIA...
        drComodato = Nothing : cmdComodato = Nothing : sqlComodato = Nothing : drComodato = Nothing
        oConnBDGENOV = Nothing


        If mContItens > _valorZERO Then

            s.WriteLine("")
            strLinha = "  TOTAIS --->     " & _clFunc.Exibe_StrDireita(mContItens, 3)
            If mContItens > 1 Then
                strLinha += " - Comodatos"
            Else
                strLinha += " - Comodato"
            End If
            s.WriteLine(_clFunc.Exibe_Str(strLinha, 115))

            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine("  -----------------------------------------------------------------------------------------------")
            s.WriteLine("")
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
            e.HasMorePages = False ': _stringToPrintAux = _StringToPrint

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

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando COMODATOS"

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

    Private Sub executaF6()

        If (Me.Dtg_MovComodatos.Rows.Count > _valorZERO) AndAlso (Me.Dtg_MovComodatos.SelectedCells.Count > 0) Then

            executaRelatorio("", "\wged\consultaComod.txt")
        End If


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

    Private Sub cbo_uf_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_uf.SelectedIndexChanged

        preencheDtg_MovComodatos()

    End Sub

    Private Sub cbo_cidade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cidade.SelectedIndexChanged

        preencheDtg_MovComodatos()

    End Sub
End Class