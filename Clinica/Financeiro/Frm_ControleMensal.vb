Imports Npgsql
Imports System.Text
Imports System.Math
Imports System.IO
Imports System.Drawing.Printing

Public Class Frm_ControleMensal

    Dim _Geno1, _Geno2 As New Cl_Geno
    Dim _CMensal As New Cl_ControleMensal
    Dim _clFuncoes As New ClFuncoes
    Public _TpAtendimento As New Cl_TpAtendimento
    Dim _DentistaDAO As New Cl_DoutorDAO
    Dim _LojaPesq As String = ""
    Public Shared _frmREf As New Frm_ControleMensal
    Public nomeRef As String = ""


    'objetos para impressão:
    Dim _pathContrFrent As String = "\wged\Imagens\ControleMensal.png"
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


    Private Sub Frm_ControleMensal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_NomeSys.Text = Application.ProductName


        cbo_empresa1 = _clFuncoes.PreenchComboLoja2Dig(cbo_empresa1, MdlConexaoBD.conectionPadrao)
        cbo_empresa2 = _clFuncoes.PreenchComboLoja2Dig(cbo_empresa2, MdlConexaoBD.conectionPadrao)
        cbo_empresa1.SelectedIndex = 0 : cbo_empresa2.SelectedIndex = 0
        cbo_tipoAtend1 = _TpAtendimento.DAO.PreenchComboTpAtendementoPesq(cbo_tipoAtend1, MdlConexaoBD.conectionPadrao)
        cbo_tipoAtend2 = _TpAtendimento.DAO.PreenchComboTpAtendimento(cbo_tipoAtend2, MdlConexaoBD.conectionPadrao)
        
        executaF5()
        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorio.BeginPrint, AddressOf InicializaRelatorio

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorio.PrintPage, AddressOf rptGravaRDiario

        setImpressao()

    End Sub

    Sub setImpressao()

        Dim valor As Int16 = 0
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

    Private Sub Frm_ControleMensal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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

                    _CMensal = _CMensal.DAO.trazCMensal_por_ID(id)
                    _CMensal.DAO.delCMensal(_CMensal, MdlConexaoBD.conectionPadrao)
                    MsgBox("Registro Deletado com Sucesso")
                    executaF5()
                End If
                
            End If
        Catch ex As Exception
            MsgBox("Error ao Preparar Edição:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub txt_vlrBruto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_vlrBruto.KeyPress, txt_vlrLiquido.KeyPress, txt_vlrDespesas.KeyPress
        'permite só numeros com virgula:
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_vlrBruto_Leave(sender As Object, e As EventArgs) Handles txt_vlrBruto.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlrBruto.Text.Equals("") Then Me.txt_vlrBruto.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vlrBruto.Text) Then
            If CDec(Me.txt_vlrBruto.Text) < 0 Then
                lbl_mensagem.Text = """Valor Bruto"" deve ser maior ou igual a ZERO !"
                Return

            End If
            Me.txt_vlrBruto.Text = Format(CDec(Me.txt_vlrBruto.Text), "###,##0.00")
            CalculaVlrLiquido()

        Else
            lbl_mensagem.Text = """Valor Bruto"" deve ser NUMÉRICO !"
            Return
        End If


    End Sub

    Function ValidaVlrBruto() As Boolean
        lbl_mensagem.Text = ""
        If IsNumeric(Me.txt_vlrBruto.Text) Then
            If CDec(Me.txt_vlrBruto.Text) < 0 Then
                lbl_mensagem.Text = """Valor Bruto"" deve ser maior ou igual a ZERO !"
                Return False

            End If

        Else
            lbl_mensagem.Text = """Valor Bruto"" deve ser NUMÉRICO !"
            Return False
        End If

        Return True
    End Function

    Function ValidaVlrDespesas() As Boolean
        lbl_mensagem.Text = ""
        If IsNumeric(Me.txt_vlrDespesas.Text) Then
            If CDec(Me.txt_vlrDespesas.Text) < 0 Then
                lbl_mensagem.Text = """Valor Despesas"" deve ser maior ou igual a ZERO !"
                Return False

            End If

        Else
            lbl_mensagem.Text = """Valor Despesas"" deve ser NUMÉRICO !"
            Return False
        End If

        Return True
    End Function

    Private Sub txt_vlrDespesas_Leave(sender As Object, e As EventArgs) Handles txt_vlrDespesas.Leave

        lbl_mensagem.Text = ""
        If Me.txt_vlrDespesas.Text.Equals("") Then Me.txt_vlrDespesas.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vlrDespesas.Text) Then
            If CDec(Me.txt_vlrDespesas.Text) < 0 Then
                lbl_mensagem.Text = """Valor Despesas"" deve ser maior ou igual a ZERO !"
                Return

            End If
            Me.txt_vlrDespesas.Text = Format(CDec(Me.txt_vlrDespesas.Text), "###,##0.00")
            CalculaVlrLiquido()

        Else
            lbl_mensagem.Text = """Valor Despesas"" deve ser NUMÉRICO !"
            Return
        End If

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

    Sub CalculaVlrLiquido()

        If IsNumeric(Me.txt_vlrBruto.Text) AndAlso IsNumeric(Me.txt_vlrDespesas.Text) Then
            Me.txt_vlrLiquido.Text = Format(Round(CDec(Me.txt_vlrBruto.Text) - CDec(txt_vlrDespesas.Text), 2), "###,##0.00")
        End If
    End Sub

    Private Sub Frm_ControleMensal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbo_tipoAtend1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tipoAtend1.SelectedIndexChanged

        Try
            If cbo_tipoAtend1.SelectedIndex = 0 Then
                chk_recusaAtend.Checked = False : chk_recusaAtend.Enabled = False
            ElseIf cbo_tipoAtend1.SelectedIndex > 0 Then
                chk_recusaAtend.Checked = False : chk_recusaAtend.Enabled = True
            End If
            executaF5()
        Catch ex As Exception
        End Try

    End Sub

    Function ValidaValores() As Boolean

        If ValidaVlrBruto() = False Then Return False
        If ValidaVlrDespesas() = False Then Return False
        If ValidaVlrLiquido() = False Then Return False

        Return True
    End Function

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        If ValidaValores() = False Then Return
        Try

            If _CMensal.c_id > 0 Then
                If MessageBox.Show("Registro em Alteração! Deseja DESFAZER a Alteração e Incluir?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                    Windows.Forms.DialogResult.No Then
                    Return
                End If
            End If
            Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            _CMensal.c_id = 0
            _CMensal.c_loja = Mid(cbo_empresa2.SelectedItem.ToString, 1, 2)
            _CMensal.c_tipoatendimento = cbo_tipoAtend2.SelectedItem.ToString
            _CMensal.c_data = dtp_data.Value
            _CMensal.c_vlrbruto = txt_vlrBruto.Text
            _CMensal.c_vlrdespesas = txt_vlrDespesas.Text
            _CMensal.c_vlrliquido = txt_vlrLiquido.Text


            If _CMensal.DAO.existeCMensal_por_Data_Tp_Loja(_CMensal.c_data, _CMensal.c_tipoatendimento, _CMensal.c_loja) Then
                If MessageBox.Show("Já contém um registro lançao nessa ""Data""!. Deseja continuar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                    Windows.Forms.DialogResult.No Then
                    Return
                End If
            End If

            _CMensal.DAO.IncCMensal(_CMensal, conexao)
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
            If _CMensal.c_id <= 0 Then
                MsgBox("Registro não Selecionado para Alteração! Por Favor Selecionar um Registro ou Clique em Incluir!", MsgBoxStyle.Exclamation)
                Return
            End If
            Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            _CMensal.c_loja = Mid(cbo_empresa2.SelectedItem.ToString, 1, 2)
            _CMensal.c_tipoatendimento = cbo_tipoAtend2.SelectedItem.ToString
            _CMensal.c_data = dtp_data.Value
            _CMensal.c_vlrbruto = txt_vlrBruto.Text
            _CMensal.c_vlrdespesas = txt_vlrDespesas.Text
            _CMensal.c_vlrliquido = txt_vlrLiquido.Text


            _CMensal.DAO.altCMensal(_CMensal, conexao)
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
            cbo_tipoAtend2.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Me.txt_vlrBruto.Text = "0,00"
        Me.txt_vlrDespesas.Text = "0,00"
        Me.txt_vlrLiquido.Text = "0,00"
        _CMensal.zeraValores()

    End Sub

    Private Sub cbo_empresa1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_empresa1.SelectedIndexChanged

        Try
            If cbo_empresa1.SelectedIndex >= 0 Then
                _LojaPesq = Mid(cbo_empresa1.SelectedItem.ToString, 1, 2)
                _clFuncoes.trazGenoSelecionado("G00" & _LojaPesq, _Geno1)
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
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbo_tipoAtend2_GotFocus(sender As Object, e As EventArgs) Handles cbo_tipoAtend2.GotFocus
        If cbo_tipoAtend2.DroppedDown = False Then cbo_tipoAtend2.DroppedDown = True
    End Sub


#Region "*   Pesquisa *"

    Function TrazConsultaCMensal() As String
        Dim Sqlcomm As StringBuilder = New StringBuilder

        Sqlcomm.Append("SELECT c_id, to_char(c_data, 'dd'), c_vlrbruto, c_vlrdespesas, c_vlrliquido, c_vlrcartao, c_dentista, c_tipoatendimento FROM controle_mensal ") '5
        Sqlcomm.Append("WHERE c_loja = '" & _LojaPesq & "' ")

        If IsDate(dtp_mes.Text) Then
            Sqlcomm.Append("AND to_char(c_data, 'MM/yyyy') = '" & dtp_mes.Text & "' ")
        End If

        If cbo_tipoAtend1.SelectedIndex > 0 Then
            Sqlcomm.Append("AND c_tipoatendimento LIKE '" & cbo_tipoAtend1.SelectedItem.ToString & "' ")
        End If


        Sqlcomm.Append("ORDER BY c_data ASC LIMIT 1000")


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

        consulta = TrazConsultaCMensal()

        comm = New NpgsqlCommand(consulta, conn)
        dr = comm.ExecuteReader

        Try
            dtg_controleMensal.Rows.Clear() : dtg_controleMensal.Refresh()

            While dr.Read

                Dim mlinha As String() = {dr(0), dr(1).ToString, Format(dr(2), "###,##0.00"), Format(dr(3), "###,##0.00"), Format(dr(4), "###,##0.00"), _
                                          Format(dr(5), "###,##0.00"), dr(6).ToString, dr(7).ToString}
                dtg_controleMensal.Rows.Add(mlinha)
            End While
            dtg_controleMensal.Refresh()

            conn.Close()
            conn = Nothing
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try



    End Sub

#End Region

    Private Sub dtg_controleMensal_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtg_controleMensal.RowsAdded

        dtg_controleMensal.Rows(e.RowIndex).Cells(1).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
        dtg_controleMensal.Rows(e.RowIndex).Cells(2).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
        dtg_controleMensal.Rows(e.RowIndex).Cells(2).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
        dtg_controleMensal.Rows(e.RowIndex).Cells(3).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
        dtg_controleMensal.Rows(e.RowIndex).Cells(4).Style.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
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

        executaEspelhoNF_R("", "\wged\relatorios\ControleMensal.txt")

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
                .Text = "Relatório de Controle Diário"

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
        Dim mFonteNormal, mFonteValor, mFonteDiaSemana, mFonteCabecalho, mFonteTotais As Font
        mFonteNormal = New Font("Times New Roman", 10, FontStyle.Regular)
        mFonteValor = New Font("Times New Roman", 12, FontStyle.Bold)
        mFonteDiaSemana = New Font("Times New Roman", 14, FontStyle.Bold)
        mFonteCabecalho = New Font("Times New Roman", 23, FontStyle.Bold Or FontStyle.Italic)
        mFonteTotais = New Font("Times New Roman", 12, FontStyle.Bold)

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
            Relatorio.Graphics.DrawImage(Image.FromFile(_pathContrFrent), -10, -20, 835, 1190)
        Catch ex As Exception
            MsgBox("Erro na Imagem: " & ex.Message) : Return
        End Try

        'Tipo Atendimento:
        Try
            If cbo_tipoAtend1.SelectedIndex > 0 Then
                Relatorio.Graphics.DrawString(cbo_tipoAtend1.SelectedItem.ToString, mFonteDiaSemana, Brushes.DarkRed, 120, 35, New StringFormat())
            End If
        Catch ex As Exception
        End Try


        'Mês do Ano:
        Relatorio.Graphics.DrawString(dtp_mes.Text, mFonteDiaSemana, Brushes.Black, 605, 105, New StringFormat())

        'Tipo:
        Try

            'If cbo_empresa1.SelectedIndex >= 0 Then
            '    Relatorio.Graphics.DrawString("CLINICA " & trazNumeroClinica(CInt(Mid(cbo_empresa1.SelectedItem.ToString, 1, 2))), mFonteCabecalho, Brushes.SteelBlue, 130, 103, New StringFormat())
            'Else
            '    Relatorio.Graphics.DrawString("CLINICA", mFonteCabecalho, Brushes.SteelBlue, 130, 103, New StringFormat())
            'End If
            Relatorio.Graphics.DrawString(nomeRef, mFonteCabecalho, Brushes.SteelBlue, 130, 94, New StringFormat())
        Catch ex As Exception
        End Try


        mSomaBruto = 0 : mSomaDespesas = 0 : mSomaLiquido = 0


        mLinhaAtualLetras = 210.5
        For Each row As DataGridViewRow In dtg_controleMensal.Rows


            If row.IsNewRow = False Then

                diaAtual = CInt(row.Cells(1).Value.ToString)
                diferencaDias = CInt(diaAtual - diaAnterior)
                mLinhaAtualAux = mLinhaAtualLetras + (28.1 * diferencaDias)

                'Imprime na parte da Frente:
                Relatorio.Graphics.DrawString(row.Cells(2).Value.ToString, mFonteValor, Brushes.Black, 285, mLinhaAtualAux, mValoresFormat) 'Bruto
                Relatorio.Graphics.DrawString(row.Cells(3).Value.ToString, mFonteValor, Brushes.Black, 450, mLinhaAtualAux, mValoresFormat) 'Despesas
                Relatorio.Graphics.DrawString(row.Cells(4).Value.ToString, mFonteValor, Brushes.Black, 630, mLinhaAtualAux, mValoresFormat) 'Liquido

                mSomaBruto += row.Cells(2).Value : mSomaDespesas += row.Cells(3).Value : mSomaLiquido += row.Cells(4).Value

                diaAnterior = diaAtual
                mLinhaAtualLetras = mLinhaAtualAux
            End If
        Next

        'Imprime Totais:
        mLinhaAtualAux = 1076.6
        Relatorio.Graphics.DrawString("Totais:", mFonteValor, Brushes.DarkRed, 115, mLinhaAtualAux, New StringFormat()) 'Bruto
        Relatorio.Graphics.DrawString(Format(Round(mSomaBruto, 2), "###,##0.00"), mFonteValor, Brushes.DarkRed, 285, mLinhaAtualAux, mValoresFormat) 'Bruto
        Relatorio.Graphics.DrawString(Format(Round(mSomaDespesas, 2), "###,##0.00"), mFonteValor, Brushes.DarkRed, 450, mLinhaAtualAux, mValoresFormat) 'Despesas
        Relatorio.Graphics.DrawString(Format(Round(mSomaLiquido, 2), "###,##0.00"), mFonteValor, Brushes.DarkRed, 630, mLinhaAtualAux, mValoresFormat) 'Liquido

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

                _CMensal = _CMensal.DAO.trazCMensal_por_ID(id)
                preenchCamposCMensal()
                tbc_CMensal.SelectTab(1)

            End If
        Catch ex As Exception
            MsgBox("Error ao Preparar Edição:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Sub preenchCamposCMensal()

        Try
            cbo_empresa2.SelectedIndex = _clFuncoes.trazIndexComboBox(_CMensal.c_loja, _CMensal.c_loja.Length, cbo_empresa2)
        Catch ex As Exception
        End Try

        Try
            cbo_tipoAtend2.SelectedIndex = _clFuncoes.trazIndexComboBox(_CMensal.c_tipoatendimento, _CMensal.c_tipoatendimento.Length, cbo_tipoAtend2)
        Catch ex As Exception
        End Try

        dtp_data.Value = _CMensal.c_data
        txt_vlrBruto.Text = Format(_CMensal.c_vlrbruto, "###,##0.00")
        txt_vlrDespesas.Text = Format(_CMensal.c_vlrdespesas, "###,##0.00")
        txt_vlrLiquido.Text = Format(_CMensal.c_vlrliquido, "###,##0.00")

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
End Class