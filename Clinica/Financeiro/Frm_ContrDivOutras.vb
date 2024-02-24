Imports Npgsql
Imports System.Text
Imports System.Math
Imports System.IO
Imports System.Drawing.Printing

Public Class Frm_ContrDivOutras

    Dim _Geno1, _Geno2 As New Cl_Geno
    Dim _CDivOutras As New Cl_ControlDivOutros
    Dim _clFuncoes As New ClFuncoes
    Dim _DentistaOutras As New Cl_DentistaOutras
    Dim _DentistaOutrasDAO As New Cl_DentistaOutras
    Dim _DentistaOutrasImpressao As New Cl_DentistaOutras
    Dim _LojaPesq As String = ""
    Public Shared _frmREf As New Frm_ContrDivOutras
    Public nomeRef As String = ""


    'objetos para impressão:
    Dim _pathContrFrent As String = "\wged\Imagens\MapaMensal.png"
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

    'Soma totais Impressão:
    Dim mSomaBruto, mSomaDespesas, mSomaLiquido As Double


    Private Sub Frm_ContrDivOutras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_NomeSys.Text = Application.ProductName


        cbo_empresa1 = _clFuncoes.PreenchComboLoja2DigOutras(cbo_empresa1, MdlConexaoBD.conectionPadrao, MdlEmpresaUsu._codigo)
        cbo_empresa2 = _clFuncoes.PreenchComboLoja2DigOutras(cbo_empresa2, MdlConexaoBD.conectionPadrao, MdlEmpresaUsu._codigo)
        Try
            cbo_empresa1.SelectedIndex = 0 : cbo_empresa2.SelectedIndex = 0
        Catch ex As Exception
        End Try

        
        Try
            cbo_dentistas = _DentistaOutras.DAO.PreenchComboDentistaO(_Geno1, cbo_dentistas, MdlConexaoBD.conectionPadrao)
            cbo_dentistaDAO = _DentistaOutras.DAO.PreenchComboDentistaO(_Geno1, cbo_dentistaDAO, MdlConexaoBD.conectionPadrao)

            cbo_dentistas.SelectedIndex = 0
            cbo_dentistaDAO.SelectedIndex = 0
        Catch ex As Exception
        End Try

        executaF5()
        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorio.BeginPrint, AddressOf InicializaRelatorio

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorio.PrintPage, AddressOf rptGravaRDiario

        setImpressao()

    End Sub

    Sub setImpressao()

        Dim valor As Int16 = 0
        pdRelatorio.DefaultPageSettings.Landscape = True
        pdRelatorio.PrinterSettings.DefaultPageSettings.Landscape = True
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

    Private Sub Frm_ContrDivOutras_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F3
                ExecutaF3()
            Case Keys.F5
                executaF5()
            Case Keys.F6
                ExecutaF6()
            Case Keys.Delete
                ExecutaDel()
        End Select

    End Sub

    Sub ExecutaDel()

        Try
            If dtg_controleMensal.CurrentRow.IsNewRow = False Then

                If MessageBox.Show("Deseja Realmente Deletar esse Registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                    Dim id As Int64 = dtg_controleMensal.CurrentRow.Cells(0).Value

                    _CDivOutras = _CDivOutras.DAO.trazCDOutros_por_ID(id)
                    _CDivOutras.DAO.delCDOutros(_CDivOutras, MdlConexaoBD.conectionPadrao)
                    'MsgBox("Registro Deletado com Sucesso")
                    executaF5()
                End If

            End If
        Catch ex As Exception
            MsgBox("Error ao Preparar Edição:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub txt_vlrSoma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_vlrLiquido.KeyPress
        'permite só numeros com virgula:
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_vlrLiquido_Leave(sender As Object, e As EventArgs) Handles txt_vlrLiquido.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlrLiquido.Text.Equals("") Then Me.txt_vlrLiquido.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vlrLiquido.Text) Then
            Me.txt_vlrLiquido.Text = Format(CDec(Me.txt_vlrLiquido.Text), "###,##0.00")
        Else
            lbl_mensagem.Text = """Valor Líquido"" deve ser NUMÉRICO !"
            Return
        End If

    End Sub

    Function ValidaVlrLiquido() As Boolean
        lbl_mensagem.Text = ""
        If IsNumeric(Me.txt_vlrLiquido.Text) = False Then
            lbl_mensagem.Text = """Valor Líquido"" deve ser NUMÉRICO !"
            Return False
        End If

        Return True
    End Function


    Private Sub Frm_ContrDivOutras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Function ValidaValores() As Boolean

        If ValidaVlrLiquido() = False Then Return False

        Return True
    End Function

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        If ValidaValores() = False Then Return
        Try

            If _CDivOutras.cd_id > 0 Then
                If MessageBox.Show("Registro em Alteração! Deseja DESFAZER a Alteração e Incluir?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                    Windows.Forms.DialogResult.No Then
                    Return
                End If
            End If
            Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            _CDivOutras.cd_id = 0
            _CDivOutras.cd_loja = Mid(cbo_empresa2.SelectedItem.ToString, 1, 2)
            _CDivOutras.cd_dentista = _DentistaOutrasDAO.do_id
            _CDivOutras.cd_data = dtp_data.Value
            _CDivOutras.cd_vlrliquido = txt_vlrLiquido.Text


            If _CDivOutras.DAO.existeCDOutros_por_Data_Dentista_Loja(_CDivOutras.cd_data, _CDivOutras.cd_dentista, _CDivOutras.cd_loja) Then
                If MessageBox.Show("Já contém um registro lançao nessa ""Data""!. Deseja continuar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                    Windows.Forms.DialogResult.No Then
                    Return
                End If
            End If

            _CDivOutras.DAO.IncCDOutros(_CDivOutras, conexao)
            MsgBox("Registro Incluido com Sucesso ! ")

            ZeraValores()
            cbo_empresa2.Focus()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        If ValidaValores() = False Then Return
        Try
            If _CDivOutras.cd_id <= 0 Then
                MsgBox("Registro não Selecionado para Alteração! Por Favor Selecionar um Registro ou Clique em Incluir!", MsgBoxStyle.Exclamation)
                Return
            End If
            Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            _CDivOutras.cd_loja = Mid(cbo_empresa2.SelectedItem.ToString, 1, 2)
            _CDivOutras.cd_dentista = _DentistaOutrasDAO.do_id
            _CDivOutras.cd_data = dtp_data.Value
            _CDivOutras.cd_vlrliquido = txt_vlrLiquido.Text


            _CDivOutras.DAO.altCDOutros(_CDivOutras, conexao)
            MsgBox("Registro Alterado com Sucesso ! ")

            ZeraValores()
            cbo_empresa2.Focus()
            tbc_CMensal.SelectTab(0)
            executaF5()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Sub ZeraValores()

        Try
            cbo_empresa2.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Try
            cbo_dentistaDAO.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Me.txt_vlrLiquido.Text = "0,00"
        _CDivOutras.zeraValores()

    End Sub

    Private Sub cbo_empresa1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_empresa1.SelectedIndexChanged

        Try
            If cbo_empresa1.SelectedIndex >= 0 Then
                _LojaPesq = Mid(cbo_empresa1.SelectedItem.ToString, 1, 2)
                _clFuncoes.trazGenoSelecionado("G00" & _LojaPesq, _Geno1)
                cbo_dentistas = _DentistaOutras.DAO.PreenchComboDentistaO(_Geno1, cbo_dentistas, MdlConexaoBD.conectionPadrao)
                Try
                    cbo_dentistas.SelectedIndex = 0
                Catch ex As Exception
                End Try
                executaF5()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbo_empresa2_GotFocus(sender As Object, e As EventArgs) Handles cbo_empresa2.GotFocus
        If cbo_empresa1.DroppedDown = False Then cbo_empresa2.DroppedDown = True
    End Sub

    Private Sub cbo_empresa2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_empresa2.SelectedIndexChanged

        Try
            If cbo_empresa2.SelectedIndex >= 0 Then
                _clFuncoes.trazGenoSelecionado("G00" & Mid(cbo_empresa2.SelectedItem.ToString, 1, 2), _Geno2)
                cbo_dentistaDAO = _DentistaOutrasDAO.DAO.PreenchComboDentistaO(_Geno2, cbo_dentistaDAO, MdlConexaoBD.conectionPadrao)
                Try
                    cbo_dentistaDAO.SelectedIndex = 0
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try

    End Sub



#Region "*   Pesquisa *"

    Function TrazConsultaCDivOutrasImpressao(ByVal nomeDentista As String) As String
        Dim Sqlcomm As StringBuilder = New StringBuilder
        _DentistaOutrasImpressao.DAO.trazDentistaOLojaNome(nomeDentista, _Geno1, _DentistaOutrasImpressao)

        Sqlcomm.Append("SELECT cd_vlrliquido, to_char(cd_data, 'dd') FROM contr_div_outros JOIN dentistas_outras ON do_id = cd_dentista ") '5
        Sqlcomm.Append("WHERE cd_loja = '" & _LojaPesq & "' ")

        If IsDate(dtp_mes.Text) Then
            Sqlcomm.Append("AND to_char(cd_data, 'MM/yyyy') = '" & dtp_mes.Text & "' ")
        End If

        Sqlcomm.Append("AND cd_dentista = " & _DentistaOutrasImpressao.do_id & " ")
        Sqlcomm.Append("ORDER BY cd_data ASC LIMIT 1000")


        Return Sqlcomm.ToString
    End Function

    Function TrazConsultaCDivOutrasImpressao(ByVal mDentista As Cl_DentistaOutras) As String
        Dim Sqlcomm As StringBuilder = New StringBuilder

        Sqlcomm.Append("SELECT cd_vlrliquido, to_char(cd_data, 'dd') FROM contr_div_outros JOIN dentistas_outras ON do_id = cd_dentista ") '5
        Sqlcomm.Append("WHERE cd_loja = '" & _LojaPesq & "' ")

        If IsDate(dtp_mes.Text) Then
            Sqlcomm.Append("AND to_char(cd_data, 'MM/yyyy') = '" & dtp_mes.Text & "' ")
        End If

        Sqlcomm.Append("AND cd_dentista = " & mDentista.do_id & " ")
        Sqlcomm.Append("ORDER BY cd_data ASC LIMIT 1000")


        Return Sqlcomm.ToString
    End Function

    Function TrazConsultaCDivOutras() As String
        Dim Sqlcomm As StringBuilder = New StringBuilder

        Sqlcomm.Append("SELECT cd_id, to_char(cd_data, 'dd'), do_nome, cd_vlrliquido, cd_vlrsoma FROM contr_div_outros JOIN dentistas_outras ON do_id = cd_dentista ") '5
        Sqlcomm.Append("WHERE cd_loja = '" & _LojaPesq & "' ")

        If IsDate(dtp_mes.Text) Then
            Sqlcomm.Append("AND to_char(cd_data, 'MM/yyyy') = '" & dtp_mes.Text & "' ")
        End If

        If cbo_dentistas.SelectedIndex > -1 Then
            Sqlcomm.Append("AND cd_dentista = " & _DentistaOutras.do_id & " ")
        End If


        Sqlcomm.Append("ORDER BY cd_data ASC LIMIT 1000")


        Return Sqlcomm.ToString
    End Function

    Private Sub executaF5()

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim consulta As String

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão:: " & ex.Message)
        End Try

        consulta = TrazConsultaCDivOutras()

        comm = New NpgsqlCommand(consulta, conn)
        dr = comm.ExecuteReader

        Try
            dtg_controleMensal.Rows.Clear() : dtg_controleMensal.Refresh()

            While dr.Read

                Dim mlinha As String() = {dr(0), dr(1).ToString, dr(2).ToString, Format(dr(3), "###,##0.00"), Format(dr(4), "###,##0.00")}
                dtg_controleMensal.Rows.Add(mlinha)
            End While
            dtg_controleMensal.Refresh()

            SomaTotLiquidoDtg()

            conn.Close()
            conn = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

    Sub SomaTotLiquidoDtg()

        Dim mTotLiquido As Double

        Try
            For Each row As DataGridViewRow In dtg_controleMensal.Rows
                If row.IsNewRow = False Then
                    mTotLiquido += CDbl(row.Cells(3).Value)
                End If
            Next
        Catch ex As Exception
            MsgBox("ERRO ao Soma Tot. Líquido:: " & ex.Message)
            mTotLiquido = 0
        End Try
        
        txt_totLiquido.Text = Format(Round(mTotLiquido, 2), "###,##0.00")
    End Sub

#End Region

    Private Sub dtg_controleMensal_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtg_controleMensal.RowsAdded

        dtg_controleMensal.Rows(e.RowIndex).Cells(1).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
        dtg_controleMensal.Rows(e.RowIndex).Cells(2).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
        dtg_controleMensal.Rows(e.RowIndex).Cells(3).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
        'dtg_controleMensal.Rows(e.RowIndex).Cells(4).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
        'dtg_controleMensal.Rows(e.RowIndex).Cells(4).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)

    End Sub

    Private Sub dtp_inicial_ValueChanged(sender As Object, e As EventArgs) Handles dtp_mes.ValueChanged
        executaF5()
    End Sub

    Private Sub cbo_dentistas_SelectedIndexChanged(sender As Object, e As EventArgs)
        executaF5()
    End Sub

#Region "*   Impressão   *"

    Sub ExecutaF6()

        Dim frmNomeEmpresa As New Frm_NomeClinicaControleMensal
        _frmREf = Me
        frmNomeEmpresa.set_frmRef(Me)
        frmNomeEmpresa.txt_nome.Text = "CLINICA " & trazNumeroClinica(CInt(Mid(cbo_empresa1.SelectedItem.ToString, 1, 2)))
        frmNomeEmpresa.ShowDialog()

        executaEspelhoNF_R("", "\wged\relatorios\MapaMensal.txt")

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
                .Text = "Relatório de Mapa Mensal"

                'exibe a janela de visualização para o usuário
                .ShowDialog()


            End With

            objPrintPreview = Nothing : _leitorTabela.Close()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub rptGravaRDiario(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintPageEventArgs)

        'Asssumindo as Margens definidas pela impressora padrão
        Dim margemEsq As Single = Relatorio.MarginBounds.Left
        Dim margemSup As Single = Relatorio.MarginBounds.Top
        Dim margemDir As Single = Relatorio.MarginBounds.Right
        Dim margemInf As Single = Relatorio.MarginBounds.Bottom

        margemDir -= 700 : margemEsq += 700 : margemInf += 40

        'Trabalhando com Fontes
        Dim mFonteNormal, mFonteValor, mFonteDiaSemana, mFonteEmpresa, mFonteCabecalho, mFonteTotais, mFonteDoutores, mFonteProtetico As Font
        mFonteNormal = New Font("Times New Roman", 10, FontStyle.Regular)
        mFonteValor = New Font("Times New Roman", 10, FontStyle.Bold)
        mFonteDiaSemana = New Font("Times New Roman", 14, FontStyle.Bold Or FontStyle.Italic)
        mFonteCabecalho = New Font("Times New Roman", 16, FontStyle.Bold)
        mFonteEmpresa = New Font("Times New Roman", 14, FontStyle.Bold Or FontStyle.Italic)
        mFonteDoutores = New Font("Times New Roman", 11, FontStyle.Bold)
        mFonteProtetico = New Font("Times New Roman", 10, FontStyle.Bold)
        mFonteTotais = New Font("Times New Roman", 11.5, FontStyle.Bold)

        Dim mValoresFormat As New StringFormat
        mValoresFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft

        Dim posiY_aux As Int16 = -5
        Dim mLinhaAtualLetras As Double = 0, mLinhaAtualAux As Double = 0.0
        Dim mLinhaAtualImagem As Integer = 0
        Dim mNumImpressCorrente As Integer = 0
        Dim mLinhaDoTrassado As Integer = 285

        'Tratamento dias:
        Dim diaAnterior As Int16 = 1
        Dim diaAtual As Int16 = 1
        Dim diferencaDias As Int16 = 0


        Dim extImagem As String = MdlEmpresaUsu.genp001.imagemCarne
        Dim mQtdeParcelas As String = ""
        mQtdeParcelas = 0


        mQtdPaginas += 1
        mLinhaAtualLetras -= 6
        Try
            'Folha A4:
            Relatorio.Graphics.DrawImage(Image.FromFile(_pathContrFrent), -25, 50, 1185, 765)
        Catch ex As Exception
            MsgBox("Erro na Imagem: " & ex.Message) : Return
        End Try

        Relatorio.Graphics.DrawString("MAPA MENSAL / CENTRO ODONTOLÓGICO DE PICOS", mFonteCabecalho, Brushes.DarkRed, 210, 30, New StringFormat())
        Relatorio.Graphics.DrawString(nomeRef, mFonteEmpresa, Brushes.SteelBlue, 990, 33, mValoresFormat)
        Relatorio.Graphics.DrawString(dtp_mes.Text, mFonteDiaSemana, Brushes.SteelBlue, 990, 33, New StringFormat())


        '### Pega os dentistas 111
        Dim mCboDentistas As New ComboBox
        Dim x_aux As Double = 72
        Dim mCont As Int16 = 1
        mCboDentistas = _DentistaOutras.DAO.PreenchComboDentistaOSemProtetico(_Geno1, mCboDentistas, MdlConexaoBD.conectionPadrao)
        For i As Integer = 0 To mCboDentistas.Items.Count - 1
            Relatorio.Graphics.DrawString(Mid(mCboDentistas.Items(i).ToString, 1, 15), mFonteDoutores, Brushes.Black, x_aux, 57, New StringFormat())
            x_aux += 151 : mCont += 1
            If mCont > 6 Then Exit For
        Next
        '### FIM 111





        mSomaBruto = 0 : mSomaDespesas = 0 : mSomaLiquido = 0
        mLinhaAtualLetras = 223.5


        '###  INICIO DA CONEXAO COM OS DENTISTAS                222
        Dim nomeDentista As String = ""
        Dim mSomaTot As Double = 0
        Dim y_aux As Double = 101
        mCont = 1
        x_aux = 172
        diaAtual = 1 : diaAnterior = 1


        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim comm As NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim consulta As String

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir Conexão:: " & ex.Message)
        End Try

        For i As Integer = 0 To mCboDentistas.Items.Count - 1

            nomeDentista = mCboDentistas.Items(i).ToString

            
            'INICIO TRATAMENTO DA CONSULTA          222-01
            consulta = TrazConsultaCDivOutrasImpressao(nomeDentista)
            comm = New NpgsqlCommand(consulta, conn)
            dr = comm.ExecuteReader

            Try
                While dr.Read

                    diaAtual = CInt(dr(1).ToString)
                    diferencaDias = CInt(diaAtual - diaAnterior)
                    y_aux = y_aux + (21.9 * diferencaDias)

                    Relatorio.Graphics.DrawString(Format(dr(0), "###,##0.00"), mFonteValor, Brushes.Black, x_aux, y_aux, mValoresFormat) 'Liquido
                    mSomaTot += dr(0)
                    diaAnterior = diaAtual
                End While
                dr.Close()

            Catch ex As NpgsqlException
                MsgBox(ex.Message.ToString)
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            'FIM 222-01

            Relatorio.Graphics.DrawString(Format(Round(mSomaTot, 2), "###,##0.00"), mFonteTotais, Brushes.DarkRed, x_aux, 776, mValoresFormat) 'Liquido
            mSomaTot = 0

            x_aux += 150 : y_aux = 101 : mCont += 1
            diaAnterior = 1 : diaAtual = 1
            If mCont > 6 Then Exit For
        Next



        '## TRATAMENTO DO PROTÉTICO 222-02
        x_aux = 1072 : y_aux = 101 : mCont += 1
        diaAnterior = 1 : diaAtual = 1

        _DentistaOutrasImpressao.DAO.trazProteticoOLoja(_Geno1, _DentistaOutrasImpressao, 1)
        Relatorio.Graphics.DrawString(Mid(_DentistaOutrasImpressao.do_nome, 1, 15), mFonteProtetico, Brushes.DarkRed, 975, 60, New StringFormat())
        consulta = TrazConsultaCDivOutrasImpressao(_DentistaOutrasImpressao)
        comm = New NpgsqlCommand(consulta, conn)
        dr = comm.ExecuteReader

        Try
            While dr.Read

                diaAtual = CInt(dr(1).ToString)
                diferencaDias = CInt(diaAtual - diaAnterior)
                y_aux = y_aux + (21.9 * diferencaDias)

                Relatorio.Graphics.DrawString(Format(dr(0), "###,##0.00"), mFonteValor, Brushes.Black, x_aux, y_aux, mValoresFormat) 'Liquido
                mSomaTot += dr(0)
                diaAnterior = diaAtual
            End While
            dr.Close()

        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        Relatorio.Graphics.DrawString(Format(Round(mSomaTot, 2), "###,##0.00"), mFonteTotais, Brushes.DarkRed, x_aux, 776, mValoresFormat) 'Liquido
        mSomaTot = 0

        '## FIM 222-02



        Try
            conn.Close() : conn = Nothing
        Catch ex As Exception
        End Try
        '### FIM  222



        Relatorio.HasMorePages = False
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

    Private Sub btn_Editar_Click(sender As Object, e As EventArgs) Handles btn_Editar.Click
        ExecutaF3()
    End Sub

    Sub ExecutaF3()

        Try
            If dtg_controleMensal.CurrentRow.IsNewRow = False Then

                Dim id As Int64 = dtg_controleMensal.CurrentRow.Cells(0).Value

                _CDivOutras = _CDivOutras.DAO.trazCDOutros_por_ID(id)
                preenchCamposCMensal()
                tbc_CMensal.SelectTab(1)

            End If
        Catch ex As Exception
            MsgBox("Error ao Preparar Edição:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Sub preenchCamposCMensal()

        Try
            cbo_empresa2.SelectedIndex = _clFuncoes.trazIndexComboBox(_CDivOutras.cd_loja, _CDivOutras.cd_loja.Length, cbo_empresa2)
        Catch ex As Exception
        End Try

        _DentistaOutrasDAO.DAO.trazDentistaOLoja(_CDivOutras.cd_dentista, _Geno2, _DentistaOutrasDAO)
        Try
            cbo_dentistaDAO.SelectedIndex = _clFuncoes.trazIndexComboBox(_DentistaOutrasDAO.do_nome, _DentistaOutrasDAO.do_nome.Length, cbo_dentistaDAO)
        Catch ex As Exception
        End Try

        dtp_data.Value = _CDivOutras.cd_data
        txt_vlrLiquido.Text = Format(_CDivOutras.cd_vlrliquido, "###,##0.00")

    End Sub

    Function trazNumeroClinica(num As Int16) As String

        Select Case num
            Case 1
                Return "I"
            Case 2
                Return "II"
            Case 3
                Return "III"
        End Select

        Return ""
    End Function

    
    Private Sub cbo_dentistaDAO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_dentistaDAO.SelectedIndexChanged

        Try

            If cbo_dentistaDAO.SelectedIndex > -1 Then
                _DentistaOutrasDAO.DAO.trazDentistaOLojaNome(cbo_dentistaDAO.SelectedItem.ToString, _Geno2, _DentistaOutrasDAO)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbo_dentistas_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles cbo_dentistas.SelectedIndexChanged

        Try

            If cbo_dentistas.SelectedIndex > -1 Then
                _DentistaOutras.DAO.trazDentistaOLojaNome(cbo_dentistas.SelectedItem.ToString, _Geno1, _DentistaOutras)
                executaF5()
            End If
        Catch ex As Exception
        End Try

    End Sub

End Class