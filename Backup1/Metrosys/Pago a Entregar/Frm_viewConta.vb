Imports Npgsql
Imports System.IO
Imports System.Math
Imports System.Text
Imports System.DateTime
Imports System.Drawing.Printing

Public Class Frm_viewSaldoConta

    Private Const _valorZERO As Integer = 0
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Public _buscaForn As New Frm_BuscaForn
    Public Shared _frmREf As New Frm_viewSaldoConta
    Dim _numRequisicao As Int64 = _valorZERO

    'Atributos do Participante...
    Public mbUf As String = "", mbCNPJ As String = ""
    Public _codPart As String = "", _nomePart As String = ""

    Dim _loja As String = MdlEmpresaUsu._codigo.Substring(MdlEmpresaUsu._codigo.Length - 2, 2)

    'objetos para impressão...
    Dim _mConsulta As New StringBuilder
    Dim MostrarCaixaImpressoras As Boolean = False
    Dim _StringToPrint As String = "", _StringToPrintItens As String = "", _stringToPrintAux As String = ""
    Private _PrintFont1 As New Font("Lucida Console", 8) 'Stenci
    Private _PrintFont2 As New Font("Lucida Console", 8)
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _sImpressao As StreamWriter
    Dim _cabecalho As Boolean = True
    Private _leitorTabelaImprimir As NpgsqlDataReader


    Private Sub Frm_viewSaldoConta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatPedidos.BeginPrint, AddressOf InicializaRelatorio
    End Sub

    Private Sub Frm_viewSaldoConta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                executaF5()
            Case Keys.F6
                executaF6()
        End Select

    End Sub

    Private Sub Frm_viewSaldoConta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown


        If Not Trim(Me.txt_codPart.Text).Equals("") Then

            If (Me.txt_codPart.TextLength > 5) AndAlso (e.KeyCode = Keys.Enter) Then 'Se retornar nada

                If trazFornecedor(Me.txt_codPart.Text) Then

                    executaF5()
                End If
                Me.txt_nomePart.Focus()
                Me.txt_nomePart.SelectAll()
            End If
        Else
            Me.txt_nomePart.Text = ""
        End If

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then

            If Me.txt_codPart.Text.Equals("") Then
                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    _frmREf = Me
                    _buscaForn.set_frmRef(Me)
                    _buscaForn.ShowDialog(Me)
                    If Trim(Me.txt_codPart.Text).Equals("") Then Me.txt_codPart.Focus() : Me.txt_nomePart.Text = ""

                    If (_codPart.Equals("") = False) AndAlso (_codPart.Equals(Me.txt_codPart.Text) = False) Then

                        trazFornecedor(_codPart)
                        executaF5()
                    ElseIf _codPart.Equals("") Then

                        executaF5()
                        _codPart = Me.txt_codPart.Text
                    End If

                    Me.txt_nomePart.Focus()
                    Me.txt_nomePart.SelectAll()

                Catch ex As Exception
                End Try

            End If

        End If


    End Sub

    Public Function trazFornecedor(ByVal codFornec As String) As Boolean

        Dim nomeCampo As String = "", nomeCampoCgc As String = "", nomeCampoCpf As String = ""
        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        Dim pesquisa As String = codFornec.ToUpper

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try


        Dim codigo, nome, cpf_cnpj, inscricao, UF As String
        codigo = "" : nome = "" : cpf_cnpj = "" : inscricao = "" : UF = ""

        Try
            SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc,p_uf FROM cadp001 WHERE ") ' 5
            SqlParticipante.Append("p_cod = '" & pesquisa & "' ORDER BY p_portad ASC")
            CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDGENOV)
            drParticipante = CmdParticipante.ExecuteReader

            If drParticipante.HasRows = False Then
                Return False
            Else
                While drParticipante.Read
                    codigo = drParticipante(_valorZERO).ToString
                    nome = drParticipante(1).ToString
                    If Not drParticipante(2).ToString.Equals("") Then 'se tiver CNPJ...
                        cpf_cnpj = drParticipante(2).ToString
                    Else
                        cpf_cnpj = drParticipante(3).ToString
                    End If
                    inscricao = drParticipante(4).ToString : UF = drParticipante(5).ToString

                End While
                drParticipante.Close()
                _codPart = codigo : Me.txt_nomePart.Text = nome
                _nomePart = nome : Me.mbCNPJ = cpf_cnpj : Me.mbUf = UF

            End If

        Catch ex As Exception
        End Try

        codigo = Nothing : nome = Nothing : cpf_cnpj = Nothing : inscricao = Nothing
        UF = Nothing

        oConnBDGENOV.ClearPool() : CmdParticipante.CommandText = ""
        SqlParticipante.Remove(_valorZERO, SqlParticipante.ToString.Length)
        If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()

        'Libera Objetos da Memória RAM...
        nomeCampo = Nothing : nomeCampoCgc = Nothing : nomeCampoCpf = Nothing : oConnBDGENOV = Nothing
        CmdParticipante = Nothing : SqlParticipante = Nothing : drParticipante = Nothing



        Return True
    End Function

    Public Function trazProcessoBD() As Boolean

        Dim oConnBDGENOV As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("Deu ERRO ao Abrir Conexão para Trazer a Requisição:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try


        Try
            sql.Append("SELECT gr_cdport || ' - ' || cad.p_portad As ""Cliente"", gr_codpr || ' - ' || ")
            sql.Append("gr_descri As ""Produto"", gr_saldo FROM " & MdlEmpresaUsu._esqEstab & ".estm400 LEFT ")
            sql.Append("JOIN cadp001 cad ON gr_cdport = cad.p_cod WHERE ")

            If Trim(Me.txt_codPart.Text).Equals("") = False Then

                sql.Append("gr_cdport = '" & Trim(Me.txt_codPart.Text) & "' AND ")
            End If
            sql.Append("gr_saldo > 0 ORDER BY cad.p_portad ASC")


            cmd = New NpgsqlCommand(sql.ToString, oConnBDGENOV)
            dr = cmd.ExecuteReader

            If dr.HasRows = False Then

                MsgBox("Não existe registro(s) para esta Consulta no Banco de Dados", MsgBoxStyle.Exclamation)
                dtg_requisicao.Rows.Clear() : dtg_requisicao.Refresh()
                Return False

            Else

                dtg_requisicao.Rows.Clear() : dtg_requisicao.Refresh()
                While dr.Read

                    dtg_requisicao.Rows.Add(dr(0).ToString, dr(1).ToString, Format(CDbl(dr(2)), "###,##0.00"))
                End While
                dtg_requisicao.Refresh()

            End If

            oConnBDGENOV.ClearPool()
            cmd.CommandText = "" : sql.Remove(_valorZERO, sql.ToString.Length)

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False
        End Try


        If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
        'Libera Objetos da Memória RAM...
        oConnBDGENOV = Nothing : cmd = Nothing : sql = Nothing : dr = Nothing


        Return True
    End Function

    Private Sub executaF5()
        trazProcessoBD()
    End Sub

    Private Sub executaF6()

        executaEspelhoRequisicao("", "\wged\TEMPprocSaldoCli.txt")
    End Sub

    Private Sub executaEspelhoRequisicaoExtracted(ByVal s As StreamWriter, ByVal loja As String, ByVal numeroRequisicao As String, ByVal codClient As String, ByVal nomeClient As String, ByRef shouldReturn As Boolean)

        shouldReturn = False

        s.WriteLine(vbNewLine)

        'Título
        'Dim lShouldReturn0 As Boolean
        '_clFuncoes.GravTituloProcSaldoContaLaser(numeroRequisicao, Date.Now, s, lShouldReturn0)
        'If lShouldReturn0 Then shouldReturn = True : Return

        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'Loja
        _mConsulta.Append("SELECT g_geno, g_ender, g_fone, g_uf, g_cid FROM geno001 WHERE g_codig = '" & loja & "'")
        Dim lShouldReturn1 As Boolean
        _clFuncoes.GravCabLojProcSaldoContaLaser(_mConsulta.ToString, s, loja, lShouldReturn1)
        If lShouldReturn1 Then shouldReturn = True : Return


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        If codClient.Equals("") Then codClient = Trim(Me.txt_codPart.Text)
        'Cliente
        'Traz dados do CLIENTE do Pedido...
        _mConsulta.Append("SELECT SUBSTR(p_portad, 1, 60), p_cgc, p_cpf, p_end, p_cid, p_uf, p_bairro, p_fone, p_fax, ") '8
        _mConsulta.Append("p_celular, SUBSTR(p_fantas, 1, 60), p_insc FROM cadp001 WHERE p_cod = '" & Trim(Me.txt_codPart.Text) & "'")
        Dim lShouldReturn2 As Boolean
        _clFuncoes.GravCabCliProcSaldoContaLaser(_mConsulta.ToString, s, codClient, numeroRequisicao, lShouldReturn2)
        If lShouldReturn2 Then shouldReturn = True : Return


        _mConsulta.Remove(0, _mConsulta.ToString.Length)
        'itens
        _mConsulta.Append("SELECT gr_codpr, gr_saldo, gr_descri, gr_pedido, CURRENT_DATE, gr_usu  FROM " & MdlEmpresaUsu._esqEstab & ".estm400 ")
        _mConsulta.Append("WHERE ")

        If Trim(Me.txt_codPart.Text).Equals("") = False Then

            _mConsulta.Append("gr_cdport = '" & Trim(Me.txt_codPart.Text) & "' AND ")
        End If
        _mConsulta.Append("gr_saldo > 0 ORDER BY gr_descri ASC")
        Dim lShouldReturn3 As Boolean
        _clFuncoes.GravItensProcSaldoContaLaser(_mConsulta.ToString, s, numeroRequisicao, codClient, nomeClient, lShouldReturn3)
        If lShouldReturn3 Then shouldReturn = True : Return


    End Sub

    Private Sub executaEspelhoRequisicao(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPprocSaldoCli.TMP"
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
        _PrintFont1 = New Font("Lucida Console", 11)
        Dim strLinha As String = ""
        Dim loja As String = MdlEmpresaUsu._codigo
        Dim numeroPedido As String = ""
        Dim codClient As String = ""
        Dim nomeClient As String = ""


        Try

            numeroPedido = dtg_requisicao.CurrentRow.Cells(0).Value.ToString
            codClient = dtg_requisicao.CurrentRow.Cells(1).Value.ToString.Substring(0, 6) 'Me.txt_codPart.Text
            nomeClient = dtg_requisicao.CurrentRow.Cells(1).Value.ToString.Substring(9)
        Catch ex As Exception

            'Deleta o arquivo temporário...
            s.Close()
            Try
                File.Copy(mArqTemp, arqSaida, True)
            Catch ex1 As Exception
            End Try
            s.Dispose()
            File.Delete(mArqTemp)
            Return
        End Try

        Dim lShouldReturn As Boolean
        executaEspelhoRequisicaoExtracted(s, loja, numeroPedido, codClient, nomeClient, lShouldReturn)
        If lShouldReturn Then Return

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
            pdRelatPedidos.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatPedidos.DefaultPageSettings.Margins.Top = 12
            pdRelatPedidos.DefaultPageSettings.Margins.Right = 12
            pdRelatPedidos.DefaultPageSettings.Margins.Left = 10
            pdRelatPedidos.DefaultPageSettings.Margins.Bottom = 8
            '========================================================

            'Orientação em Paisagem...
            pdRelatPedidos.DefaultPageSettings.Landscape = False
            'Select Case MdlRelatorioTelas._tl_movpedido
            '    Case 1 'Impressora Matricial
            '        pdRelatPedidos.DefaultPageSettings.Landscape = True
            '    Case 2 'Impressora Laiser
            '        pdRelatPedidos.DefaultPageSettings.Landscape = False
            '    Case Else
            '        pdRelatPedidos.DefaultPageSettings.Landscape = True
            'End Select
            'PrintDocument1.PrinterSettings.InstalledPrinters

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando REQUISIÇÃO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatPedidos
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False
            _StringToPrint = "" : _StringToPrintItens = ""

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub pdRelatPedidos_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdRelatPedidos.PrintPage

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
        ''e.Graphics.DrawLine(Pens.Black, 200, 400, 200, 400)
        ''e.Graphics.DrawString(StringforPage, _PrintFont1, Brushes.Black, 50, 50, New StringFormat())


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

        '_StringToPrintItens = _stringToPrintAux
        If MostrarCaixaImpressoras Then

            Dim Impressora As New PrintDialog
            Impressora.AllowCurrentPage = True : Impressora.AllowSomePages = True
            If Impressora.ShowDialog() = DialogResult.Cancel Then

                Relatorio.Cancel = True

            Else

                Try

                    pdRelatPedidos.PrinterSettings = Impressora.PrinterSettings
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
        End If
        MostrarCaixaImpressoras = True



    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click

        executaF6()
    End Sub

End Class