Imports System.Drawing.Printing
Imports System.Windows.Forms.OpenFileDialog
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.DateTime
Imports System.Math
Imports Npgsql

Public Class Frm_PagamentoIndividual

    Dim agora As Date = Now
    ' Protected Const conexao As String = _
    '"Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDMETROSYS"
    Dim mCarencia, mDias As Integer
    Dim mTaxa, mJuros, mDesconto, mSubTotalAux As Double
    Dim mCdport, mGeno, MTipo As String
    Dim mSit As String = "N"
    Dim mEmissao As Date
    Dim cl_bd As New Cl_bdMetrosys
    Dim _clFunc As New ClFuncoes
    Dim _geno001 As New Cl_Geno
    Dim _cliente As New Cl_Cadp001
    Private Const _valorZERO As Integer = 0
    Dim _valorTiradoSubTotal As Double = 0
    Dim _idPagamento As Int64 = 0

    'objetos empresa...
    Dim _endereco, _cidade, _uf, _cep As String

    'objetos para impressão
    Dim MostrarCaixaImpressoras As Boolean = False
    Private _PrintFont As New Font("Lucida Console", 8) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _StringToPrint As String = ""
    Private _sImpressao As StreamWriter
    Private _dtAdaptPrint As NpgsqlDataAdapter

    Public formManDuplicRecebimento As New Frm_ManPagamentos

    Private Sub Frm_PagamentoIndividual_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()

            Case Keys.F6
                executaF6()

        End Select

    End Sub

    Private Sub Frm_PagamentoIndividual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_PagamentoIndividual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        lbl_NomeSys.Text = Application.ProductName
        Me.msk_dtpaga.Text = agora
        Me.txt_juros.Text = "0,00"
        Me.txt_subtotal.Text = "0,00"
        Me.txt_totgeral.Text = "0,00"
        Me.txt_valor.Text = "0,00"
        Me.txt_desconto.Text = "0,00"
        Me.txt_atrazo.Text = "0"

        Me.cbo_loja = _clFunc.PreenchComboLoja5Dig(cbo_loja, MdlConexaoBD.conectionPadrao)
        Me.cbo_loja.SelectedIndex = _clFunc.trazIndexCboLoja5dig(MdlEmpresaUsu._codigo, cbo_loja)

        'Me.txt_documento.Text = "880000001A" : Me.txt_valor.Text = "540,00" : Me.msk_vencto.Text = "10/05/2013"

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorio.PrintPage, AddressOf rptGravaTotaisNF

        Try
            _idPagamento = formManDuplicRecebimento.IdPagamento
            If formManDuplicRecebimento.IdPagamento > 0 Then

                Me.cbo_loja.SelectedIndex = _clFunc.trazIndexCboLoja5dig(formManDuplicRecebimento.lojaDuplic, cbo_loja)
                Me.txt_documento.Text = formManDuplicRecebimento.numDuplicata
                trazValoresDocumento()
                Me.txt_valor.Text = Format(formManDuplicRecebimento.valorDuplicata, "###,##0.00")

            End If
        Catch ex As Exception
        End Try


    End Sub

    Private Sub trazValoresDocumento()

        If txt_documento.Text <> "" Then

            Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim Sqlcomm As StringBuilder = New StringBuilder
            Dim DrDup As NpgsqlDataReader

            Sqlcomm.Append("SELECT F.d_geno,F.d_duplic,F.d_valor,F.d_portad,C.p_portad,C.p_cod ,F.d_vencto,F.d_tipo,F.d_emiss, F.d_sit FROM ")
            If _idPagamento > 0 Then
                Sqlcomm.Append("fatp001 F LEFT JOIN Cadp001 C ON C.p_cod = F.d_portad  WHERE F.d_id = " & formManDuplicRecebimento.IdPagamento & "") '5
            Else
                Sqlcomm.Append("fatp001 F LEFT JOIN Cadp001 C ON C.p_cod = F.d_portad  WHERE ") '5
                Sqlcomm.Append("F.d_duplic='" & Me.txt_documento.Text & "' AND F.d_geno='" & _geno001.pCodig & "' LIMIT 1")
            End If

            Dim daDup As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
            Dim dsDup As DataSet = New DataSet()

            Dim cmd As NpgsqlCommand = New NpgsqlCommand(Sqlcomm.ToString, conn)
            cmd.CommandText = Sqlcomm.ToString
            Dim dtDup As DataTable = New DataTable
            Dim mVencto As Date
            Dim mdif, mJurosdia As Double
            Dim mExisteRow As Boolean = False

            Try
                conn.Open()
                dtDup.Load(cmd.ExecuteReader())    ' Carrega o datatable para memoria
                DrDup = cmd.ExecuteReader          ' Executa leitura do commando
                If DrDup.HasRows Then mCdport = "" : mExisteRow = True
                While (DrDup.Read())
                    mCdport = DrDup(5) : mGeno = DrDup(0) : MTipo = DrDup(7) : mEmissao = DrDup(8)
                    mSit = DrDup(9).ToString
                    Me.txt_portad.Text = DrDup(4).ToString
                    Me.txt_subtotal.Text = Format(CDbl(DrDup(2)), "##,##0.00")
                    Me.txt_totgeral.Text = DrDup(2).ToString  ' SOMA COM JUROS
                    mVencto = DrDup(6)
                    mDias = DateDiff(DateInterval.Day, DateValue(mVencto), Now) ' Calcula a diferença em dias entre data atual e Vencimento
                    If mDias <= 5 Then mDias = 0
                    Me.txt_atrazo.Text = mDias.ToString                 ' Calcula dias de Atrazo superior a carência
                    Me.msk_vencto.Text = DateValue(mVencto)
                    mdif = (Convert.ToInt64(CDbl(Me.txt_subtotal.Text) * mTaxa))    ' Calcula Valor de Juros Ao Mês
                    Try
                        mJurosdia = (Convert.ToInt64(mdif / 30)) / 100                            ' Calcula Vlr. Juros ao Dia
                    Catch ex As Exception
                        mJurosdia = 0.0
                    End Try

                    mJuros = (mJurosdia * mDias)                        ' Calcular Total de Juros Acumulados
                    Me.txt_juros.Text = Format(mJuros, "##,##0.00")
                    Me.txt_totgeral.Text = CDbl(Me.txt_subtotal.Text) + mJuros ' Atualiza Valor + Juros Acumulados
                    Me.txt_totgeral.Text = Format(CDbl(txt_totgeral.Text), "##,##0.00")
                End While
                If mExisteRow Then _clFunc.trazCadp001(mCdport, _cliente)
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        Else
            MessageBox.Show("Digite Numero do Documento ", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txt_documento.Focus()

        End If

    End Sub

    Private Sub txt_valor_Leave(sender As Object, e As EventArgs) Handles txt_valor.Leave

        If Me.txt_valor.Text.Equals("") Then Me.txt_valor.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valor.Text) Then

            Me.txt_valor.Text = Format(CDec(Me.txt_valor.Text), "###,##0.00")
        End If

    End Sub

    Private Sub executaF6()

        executaEspelhoNd_R("", "\wged\relatorios\reciboPagIndividual.TXT")
    End Sub

    Private Sub txt_valor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valor.KeyPress
        'permite só numeros com virgulas
        If _clFunc.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Function ValidaValores() As Boolean

        If txt_documento.Text = "" Then
            MessageBox.Show("Informe Número do Cocumento !", "Baixa Individual ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_documento.Focus() : Return False
        End If

        If txt_valor.Text = "0,00" Then
            MessageBox.Show("Informe Valor Pago !", "Baixa Individual ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_valor.Focus() : Me.txt_valor.SelectAll() : Return False
        End If

        If CDbl(txt_valor.Text) > CDbl(txt_totgeral.Text) Then

            MessageBox.Show("Valor Pago MAIOR que o Total Geral!  Verifique Os ""Juros"" ou O ""Desconto""", "Baixa Individual ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txt_valor.Focus() : Me.txt_valor.SelectAll() : Return False

        End If


        Return True
    End Function

    Private Sub btn_baixar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_baixar.Click


        mJuros = Round(CDbl(Me.txt_juros.Text), 2)
        mDesconto = Round(CDbl(Me.txt_desconto.Text), 2)


        If ValidaValores() = False Then Return


        '  *******************
        '  Baixando Duplicata 
        '  *******************

        Try

            If txt_valor.Text <> "0,00" Then

                If MessageBox.Show("Confirma Baixa de Documento !", "Quitação ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    If CDbl(Me.txt_valor.Text) >= CDbl(Me.txt_subtotal.Text) Then

                        Baixa_dupIndividual_Total(RTrim(txt_documento.Text), "T", DateValue(Me.msk_dtpaga.Text), mJuros, mDesconto, CDbl(txt_valor.Text), _
                                    CDbl(Me.txt_subtotal.Text), MdlConexaoBD.conectionPadrao)
                        MessageBox.Show("Quitacao Efetuada !", "Baixa ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If formManDuplicRecebimento.IdPagamento > 0 Then Me.Close()

                        ' Limpa_campos de baixa
                        _cliente.zeraValores()
                        Me.txt_documento.Text = "" : Me.txt_subtotal.Text = "0,00" : Me.txt_totgeral.Text = "0,00"
                        Me.txt_portad.Text = "" : Me.txt_juros.Text = "0,00" : Me.txt_valor.Text = "0,00"
                        Me.txt_atrazo.Text = "0"

                    ElseIf CDbl(Me.txt_valor.Text) < CDbl(Me.txt_subtotal.Text) Then

                        cl_bd.IncPagamentos_Parciais(_geno001.pCodig, mCdport, MTipo, Mid(txt_documento.Text, 1, 9), Mid(txt_documento.Text, 1, 9), "", _
                        0.0, Me.txt_documento.Text, mEmissao, DateValue(msk_vencto.Text), CDbl(txt_valor.Text), "00", _
                        DateValue(msk_dtpaga.Text), 0.0, 0.0, 0, "PGTO PARCIAL", "", 0.0, 0.0, "L", False, Mid(cbo_loja.SelectedItem, 1, 2), _
                        0, "", "", "", "", conectionPadrao)
                        Baixa_dupIndividual_Parcial(mCdport, txt_documento.Text, (CDbl(txt_subtotal.Text) - CDbl(txt_valor.Text)), MdlConexaoBD.conectionPadrao)
                        MessageBox.Show("Baixa Parcial Efetuada !", "Baixa Parcial ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If formManDuplicRecebimento.IdPagamento > 0 Then Me.Close()

                        executaF6()

                        ' Limpa campos de baixa Parcial
                        _cliente.zeraValores()
                        Me.txt_documento.Text = "" : Me.txt_subtotal.Text = "0,00" : Me.txt_totgeral.Text = "0,00"
                        Me.txt_portad.Text = "" : Me.txt_juros.Text = "0,00" : Me.txt_valor.Text = "0,00"
                        Me.txt_atrazo.Text = "0"


                    Else
                        Me.txt_documento.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub Baixa_dupIndividual_Total(ByVal Ndupl As String, ByVal TipoPgto As String, ByVal DTPaga As Date, ByVal Juros As Double, _
                      ByVal Desconto As Double, ByVal ValorPago As Double, ByVal ValorDup As Double, ByVal conexao As String)

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim oCmd As NpgsqlCommand
        Dim Mconsulta As Boolean = False

        Dim strSQL As New StringBuilder
        Try
            strSQL.Append("UPDATE fatp001 SET ")
            strSQL.Append("d_dtpaga = @d_dtpaga, d_juros = @d_juros, d_desc = @d_desc, d_sit = @d_sit, d_sitanterior = @d_sitanterior WHERE ")
            If _idPagamento > 0 Then
                strSQL.Append("d_id=" & _idPagamento & "")
            Else
                strSQL.Append("d_duplic='" & Ndupl.ToString & "' and d_geno='" & _geno001.pCodig & "'")
            End If

            oCmd = New NpgsqlCommand(strSQL.ToString, oConn)
            'Juros = 0.0 : Desconto = 0.0
            ValorPago = Round((Juros - Desconto) + ValorDup, 2)
            If ValorPago > ValorDup Then
                Juros = Round(ValorPago - ValorDup, 2)
            ElseIf ValorPago <= ValorDup Then
                Juros = 0.0 : Desconto = 0.0
            End If

            oCmd.Parameters.Add("@d_dtpaga", Convert.ChangeType(DTPaga, GetType(Date)))
            oCmd.Parameters.Add("@d_juros", Juros)
            oCmd.Parameters.Add("@d_desc", Desconto)
            oCmd.Parameters.Add("@d_sit", "L")
            oCmd.Parameters.Add("@d_sitanterior", mSit)

            oConn.Open()
            oCmd.CommandText = strSQL.ToString
            oCmd.ExecuteNonQuery()
            oConn.Close()
        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try


    End Sub

    Private Sub Baixa_dupIndividual_Parcial(ByVal CdPort As String, ByVal Ndupl As String, ByVal SaldoConta As Double, ByVal conexao As String)

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim oCmd As NpgsqlCommand
        Dim Mconsulta As Boolean = False

        Dim strSQL As New StringBuilder
        Try
            strSQL.Append("UPDATE fatp001 SET d_valor=@d_valor WHERE ")
            If _idPagamento > 0 Then
                strSQL.Append("d_id=" & _idPagamento & "")
            Else
                strSQL.Append("d_geno='" & _geno001.pCodig & "' AND d_portad=d_portad AND d_duplic='" & Ndupl.ToString & "'")
            End If

            oCmd = New NpgsqlCommand(strSQL.ToString, oConn)

            oCmd.Parameters.Add("@d_valor", SaldoConta)
            oCmd.Parameters.Add("@d_portad", CdPort)

            oConn.Open()
            oCmd.CommandText = strSQL.ToString
            oCmd.ExecuteNonQuery()
            oConn.Close()
        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try
    End Sub

    Private Sub txt_documento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_documento.Leave

        trazValoresDocumento()
    End Sub

    Private Sub cbo_loja_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_loja.Leave

        If cbo_loja.SelectedIndex = -1 Then

            MessageBox.Show("Selecione Loja !", "Loja ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.cbo_loja.Focus()
        Else

            Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Dim Sqlcomm As StringBuilder = New StringBuilder
            Dim DrCont As NpgsqlDataReader

            Sqlcomm.Append("SELECT gp_geno, gp_txcob, gp_carencia FROM genp001 WHERE gp_geno='" & _geno001.pCodig & "'") '5
            Dim daCont As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
            Dim dsContp As DataSet = New DataSet()

            Dim cmd As NpgsqlCommand = New NpgsqlCommand(Sqlcomm.ToString, conn)
            cmd.CommandText = Sqlcomm.ToString
            Dim dtCont As DataTable = New DataTable

            Try
                conn.Open()
                dtCont.Load(cmd.ExecuteReader())   ' Carrega o datatable para memoria
                DrCont = cmd.ExecuteReader          ' Executa leitura do commando
                While (DrCont.Read())
                    mTaxa = CDbl(DrCont(1))
                    mCarencia = Convert.ToInt32(DrCont(2))

                End While
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If


    End Sub

    Private Sub executaEspelhoNd_RExtracted(ByRef s As StreamWriter, ByRef shouldReturn As Boolean)

        shouldReturn = False
        'Totais
        Try
            gravaTotaisNd_R(s)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar os totais da Nota", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Private Sub executaEspelhoNd_RExtracted1(ByVal arqSaida As String, ByVal mArqTemp As String, ByVal fs As FileStream, ByVal s As StreamWriter)

        Dim FilePath As String = arqSaida

        s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)

        Catch ex As Exception
        End Try
        s.Dispose() : File.Delete(mArqTemp) : mArqTemp = Nothing : fs = Nothing : s = Nothing

        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrint = MyfileStream.ReadToEnd : MyfileStream.Close()
            MyfileStream.Dispose() : MyfileStream = Nothing

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub executaEspelhoNd_RExtracted2()

        Try

            ' Especifica as configurações da pagina atual
            pdRelatorio.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            pdRelatorio.DefaultPageSettings.Margins.Top = 12 'cima
            pdRelatorio.DefaultPageSettings.Margins.Right = 11 'direita
            pdRelatorio.DefaultPageSettings.Margins.Left = 11 'esquerda
            pdRelatorio.DefaultPageSettings.Margins.Bottom = 8 'baixo

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "RECIBO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = pdRelatorio
            PrintPreviewDialog1.ShowDialog()

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub executaEspelhoNd_R(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\tmp\TEMPreciboIndividual.TMP"
        Dim fs As New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)
        Dim s As New StreamWriter(fs)

        Dim mContPaginas As Integer = _valorZERO, mContQuebrasPag As Integer = _valorZERO
        Dim strLinha As String = ""
        Dim dtAtual As String = Format(Date.Now, "dd/MM/yyyy")
        Dim codEstab As String = Mid(MdlUsuarioLogando._local, _
                                     MdlUsuarioLogando._local.Length - 1, 2)


        _PrintFont = New Font("Lucida Console", 7) '126 Quebras de Linha padrao para esta configuração

        'CABEÇALHO
        Dim lShouldReturn1 As Boolean
        GravCabecalhoLoja(s, Mid(Me.cbo_loja.SelectedItem, 1, 2), lShouldReturn1)
        If lShouldReturn1 Then Return

        'TEXTO
        Dim lShouldReturn As Boolean
        executaEspelhoNd_RExtracted(s, lShouldReturn)
        If lShouldReturn Then Return

        'Ler o Arquivo salvo...
        executaEspelhoNd_RExtracted1(arqSaida, mArqTemp, fs, s)

        '_stringToPrintAux = "" : MostrarCaixaImpressoras = False
        'Visualiza o conteúdo do arquivo salvo em TEXTO...
        'executaEspelhoNd_RExtracted2()
        _StringToPrint = ""



    End Sub

    Private Sub GravCabecalhoLoja(ByVal s As StreamWriter, ByVal loja As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        Try
            Dim strLinha As String = ""
            'Traz os dados do Fornecedor da nota...
            Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try
                oConnBDGENOV.Open()
            Catch ex As Exception
            End Try

            'Traz dados do Cliente da Nota...
            Dim sqlLoja As New StringBuilder
            Dim cmdLoja As NpgsqlCommand
            Dim drLoja As NpgsqlDataReader

            sqlLoja.Append("SELECT g_geno, g_ender, g_fone, g_uf, g_cid, g_cep ")
            sqlLoja.Append("FROM geno001 WHERE g_codig = '" & _geno001.pCodig & "'")

            cmdLoja = New NpgsqlCommand(sqlLoja.ToString, oConnBDGENOV)
            drLoja = cmdLoja.ExecuteReader

            While drLoja.Read

                _endereco = drLoja(1).ToString : _cidade = drLoja(4).ToString
                _uf = drLoja(3).ToString : _cep = drLoja(5).ToString
            End While
            drLoja.Close() : cmdLoja = Nothing : sqlLoja = Nothing : drLoja = Nothing


            If oConnBDGENOV.State = ConnectionState.Open Then oConnBDGENOV.Close()
            oConnBDGENOV = Nothing
        Catch ex As Exception
            MsgBox("Deu erro ao gravar o Cabeçalho da Loja:: " & ex.Message, MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Private Sub gravaTotaisNd_R(ByRef s As StreamWriter)

        Dim strLinha As String = ""
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()
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
                .Text = "RECIBO"

                'exibe a janela de visualização para o usuário
                .ShowDialog()


            End With

            objPrintPreview = Nothing : _leitorTabela.Close()

        Catch ex As Exception
        End Try

        

        'LIMPA OBJETOS DA MEMÓRIA...
        oConnBDGENOV.Close() : oConnBDGENOV = Nothing



    End Sub

    Private Sub rptGravaTotaisNF(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintPageEventArgs)

        'Asssumindo as Margens definidas pela impressora padrão
        Dim margemEsq As Single = Relatorio.MarginBounds.Left
        Dim margemSup As Single = Relatorio.MarginBounds.Top
        Dim margemDir As Single = Relatorio.MarginBounds.Right
        Dim margemInf As Single = Relatorio.MarginBounds.Bottom

        Dim drawFormat As New StringFormat
        drawFormat.FormatFlags = StringFormatFlags.LineLimit

        'Trabalhando com Fontes
        Dim fonteCabecalho, fonteTitulo, fonteReal, fonteReal_, fonteNormal_, fonteNormal, fonteInfo As Font

        fonteTitulo = New Font("Times New Roman", 13, FontStyle.Bold)
        fonteCabecalho = New Font("Times New Roman", 12)
        fonteReal = New Font("Times New Roman", 13, FontStyle.Bold)
        fonteReal_ = New Font("Times New Roman", 13, FontStyle.Underline)
        fonteNormal_ = New Font("Times New Roman", 11, FontStyle.Underline)
        fonteNormal = New Font("Times New Roman", 11)
        fonteInfo = New Font("Times New Roman", 9)

        Dim linhadeimpressao As New SizeF(Relatorio.MarginBounds.Width, fonteNormal.Height)
        Dim caracteres As Integer = 0
        Dim strLinha As String = "", strLinhaXAux As String = ""
        Dim strLinhaX As String = ""
        Dim linhas As Integer
        Dim posicaoN As Integer = 0
        Dim carac As String = ""
        Dim numCaracAux As Integer = 0
        Dim IsNumeroDuplic As Boolean = False

        ' Este é o controle de página, assim eu vou saber quando tenho que ir para
        ' a próxima página, se necessário.
        Dim y As Integer = Relatorio.MarginBounds.Top + 140

        Dim posicaoLinha As Double = 0
        Dim contador As Integer = 8

        'Cabecalho...
        Relatorio.Graphics.DrawString(_cliente.pPortad, fonteTitulo, Brushes.Black, margemEsq + 180, 70, New StringFormat())
        Relatorio.Graphics.DrawString("Endereço: " & _cliente.pEnder, fonteCabecalho, Brushes.Black, margemEsq + 180, 90, New StringFormat())
        Relatorio.Graphics.DrawString("Cidade: " & _cliente.pCid & " - " & _cliente.pUf, fonteCabecalho, Brushes.Black, margemEsq + 180, 110, New StringFormat())
        Relatorio.Graphics.DrawString("CEP: " & _cliente.pCep, fonteCabecalho, Brushes.Black, margemEsq + 180, 130, New StringFormat())


        'Título...
        Relatorio.Graphics.DrawString("R$ ", fonteReal, Brushes.Black, margemDir - 100, 200, New StringFormat())
        Relatorio.Graphics.DrawString(Me.txt_valor.Text, fonteReal_, Brushes.Black, margemDir - 70, 199, New StringFormat())

        posicaoLinha = (margemSup) + (contador * fonteNormal.GetHeight(Relatorio.Graphics)) \ 1


        strLinha = "Recebi de " & _geno001.pGeno & ", a importância de " & "R$ " & _
        Me.txt_valor.Text & " (" & _clFunc.NumeroToExtenso(Me.txt_valor.Text) & "), referente ao pagamento " & _
        "parcial do documento Nº " & Me.txt_documento.Text & " vencimento em " & Me.msk_vencto.Text & "." & _
        vbNewLine


        While strLinha.Length > 0


            ' Obtenho o número de caracteres que vou conseguir imprimir na linha
            ' que eu especifiquei o tamanho. No caso, é a variável caracteres que
            ' me importa aqui abaixo.
            Relatorio.Graphics.MeasureString(strLinha, fonteNormal, linhadeimpressao, StringFormat.GenericDefault, caracteres, linhas)

            strLinhaX = strLinha.Substring(0, caracteres)
            For indice As Integer = 1 To 3

                carac = strLinha.Substring(0, caracteres)
                carac = carac.Substring(carac.Length - indice, 1)
                IsNumeroDuplic = False
                If IsNumeric(carac) Then IsNumeroDuplic = True
                If _clFunc.IsVogal(carac) AndAlso (indice > 1) Then

                    strLinhaX = strLinha.Substring(0, caracteres - (indice - 1)) & "-"
                    strLinhaXAux = strLinhaX & strLinha.Substring(caracteres - (indice - 1))
                    strLinha = strLinhaXAux
                    Exit For

                ElseIf carac.Equals(" ") Then

                    If indice > 1 Then
                        strLinhaX = strLinha.Substring(0, caracteres - (indice - 1))
                        strLinhaXAux += strLinhaX & strLinha.Substring(caracteres - (indice - 1))
                    Else
                        strLinhaX = strLinha.Substring(0, caracteres)
                        strLinhaXAux = strLinhaX & strLinha.Substring(caracteres - 1)
                    End If
                    strLinha = strLinhaXAux
                    Exit For
                ElseIf _clFunc.IsVogal(carac) Then
                    Exit For
                End If

            Next


            posicaoN = InStr(strLinha.Substring(0, caracteres), "Nº ", CompareMethod.Text)
            If posicaoN > 0 Then 'Achou o Nº__________

                If (caracteres - (posicaoN + 2)) >= 10 Then

                    If IsNumeroDuplic Then
                        ''impressão do texto
                        ' aí então eu imprimo os caracteres que cabem na linha, fazendo o substring abaixo
                        Relatorio.Graphics.DrawString(strLinhaX.Substring(0, posicaoN + 2), fonteNormal, Brushes.Black, Relatorio.MarginBounds.Left, y)
                        Relatorio.Graphics.DrawString(strLinhaX.Substring(posicaoN + 2, 10), fonteNormal_, Brushes.Black, (Relatorio.MarginBounds.Left + (posicaoN * 6.8)), y) ' + ((posicaoN + 1) * 7)

                        If (posicaoN + 20) < caracteres Then

                            Relatorio.Graphics.DrawString(strLinhaX.Substring(posicaoN + 12), fonteNormal, Brushes.Black, (Relatorio.MarginBounds.Left + ((posicaoN + 13) * 6.8)), y) ' + ((posicaoN + 13) * 7)
                        End If

                    Else

                        ''impressão do texto
                        ' aí então eu imprimo os caracteres que cabem na linha, fazendo o substring abaixo
                        Relatorio.Graphics.DrawString(strLinha.Substring(0, strLinhaX.Length), fonteNormal, Brushes.Black, Relatorio.MarginBounds.Left, y)
                    End If
                End If
           
            Else


                ''impressão do texto
                ' aí então eu imprimo os caracteres que cabem na linha, fazendo o substring abaixo
                Relatorio.Graphics.DrawString(strLinha.Substring(0, strLinhaX.Length), fonteNormal, Brushes.Black, Relatorio.MarginBounds.Left, y)
            End If


            ' meu controle de altura de página é incrementado com o tamanho de uma linha
            y += fonteNormal.Height

            ' aí eu vejo se já extrapolei o tamanho para a próxima linha ou não
            If y > Relatorio.MarginBounds.Height Then Exit While

            'posicaoN = InStr(strLinhaX, vbNewLine, CompareMethod.Text)
            'If posicaoN > 0 Then

            'Else

            '    ' Retiro os caracteres impressos da variável para imprimir o resto.
            '    strLinha = strLinha.Substring(caracteres)
            'End If

            Try
                ' Retiro os caracteres impressos da variável para imprimir o resto.
                strLinha = strLinha.Substring(strLinhaX.Length)
            Catch ex As Exception
            End Try

        End While

        y += (30 + fonteNormal.Height)
        ' Recarrego o resto da string com o resto.
        strLinha = _clFunc.primeiraLetraMaiusculaPalavra(_cliente.pCid) & " (" & _cliente.pUf & "), " & Date.Now.Day & " de " & _clFunc.returnMesExtenso(Date.Now.Month) & " de " & Date.Now.Year
        Relatorio.Graphics.DrawString(strLinha, fonteNormal, Brushes.Black, Relatorio.MarginBounds.Left + 300, y)

        y += (20 + fonteNormal.Height)
        Relatorio.Graphics.DrawString("______________________________________", fonteNormal, Brushes.Black, Relatorio.MarginBounds.Left + 300, y)
        y += (2 + fonteNormal.Height)
        Relatorio.Graphics.DrawString("(Assinatura)", fonteNormal, Brushes.Black, Relatorio.MarginBounds.Left + 400, y)


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

    Private Sub txt_desconto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_desconto.KeyPress
        'permite só numeros com virgulas
        If _clFunc.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_desconto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desconto.KeyDown

        If e.KeyCode = Keys.Enter Then

            If IsNumeric(Me.txt_desconto.Text) Then

                Me.txt_totgeral.Text = Format(Round((CDbl(Me.txt_subtotal.Text) + CDbl(Me.txt_juros.Text)) - CDec(Me.txt_desconto.Text), 2), "###,##0.00")

            End If
        End If

    End Sub

    Private Sub txt_desconto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_desconto.LostFocus

        If Me.txt_desconto.Text.Equals("") Then Me.txt_desconto.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_desconto.Text) Then

            Me.txt_desconto.Text = Format(CDec(Me.txt_desconto.Text), "###,##0.00")
            Me.txt_totgeral.Text = Format(Round((CDbl(Me.txt_subtotal.Text) + CDbl(Me.txt_juros.Text)) - CDec(Me.txt_desconto.Text), 2), "###,##0.00")

        End If

    End Sub

    Private Sub cbo_loja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_loja.SelectedIndexChanged
      
        Try
            If cbo_loja.SelectedIndex > -1 Then

                If _clFunc.trazGenoSelecionado(cbo_loja.SelectedItem.ToString.Substring(0, 5), _geno001) = False Then
                    MsgBox("Loja não encontrada!")
                End If
            End If

        Catch ex As Exception
            MsgBox("Loja não encontrada! " & ex.Message) : Me.Close()
        End Try

    End Sub

    Private Sub txt_juros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_juros.KeyPress
        'permite só numeros com virgulas
        If _clFunc.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_juros_Leave(sender As Object, e As EventArgs) Handles txt_juros.Leave

        If Me.txt_juros.Text.Equals("") Then Me.txt_juros.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_juros.Text) Then

            Me.txt_juros.Text = Format(CDec(Me.txt_juros.Text), "###,##0.00")
            Me.txt_totgeral.Text = Format(Round(CDbl(txt_totgeral.Text) + CDbl(txt_juros.Text), 2), "###,##0.00")
        Else
            MsgBox("Campo de Juros DEVE ser Maior que ZERO", MsgBoxStyle.Exclamation) : txt_juros.Focus() : txt_juros.SelectAll() : Return
        End If

    End Sub

End Class