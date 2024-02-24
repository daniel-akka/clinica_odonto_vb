Imports System.Drawing.Printing
Imports System.Text
Imports System.IO
Imports System.Math
Imports System.Data
Imports System.Data.DataColumnCollection
Imports System.Data.DataRow
Imports Npgsql
Public Class Frm_Relatorio_002
    Public Const ArqTemp As String = "C:\wged\TEMP.TMP"
    Public Const ArqMov As String = "C:\wged\Listagem.txt"
    'Protected Const conexao As String = _
    '"Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDGENOV"
    Private PrintPageSettings As New PageSettings

    Private StringToPrint, _StringToPrint As String
    Private PrintFont As New Font("Lucida Console", 9) 'Stencil
    Public _CLFun As New ClFuncoes
    Public Shared _frmRef As New Frm_Relatorio_002
    Dim _BuscaCli As New Frm_BuscaCli


    Public Function trazCliente(ByVal codCli As String) As Boolean

        Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdParticipante As New NpgsqlCommand
        Dim SqlParticipante As New StringBuilder
        Dim drParticipante As NpgsqlDataReader

        Dim pesquisa As String = codCli.ToUpper

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        Dim codigo, nome, cpf_cnpj, inscricao, UF As String
        codigo = "" : nome = "" : cpf_cnpj = "" : inscricao = "" : UF = ""

        Try
            SqlParticipante.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc,p_uf FROM cadp001 WHERE ") ' 5
            SqlParticipante.Append("p_cod = '" & pesquisa & "' ORDER BY p_portad ASC")
            CmdParticipante = New NpgsqlCommand(SqlParticipante.ToString, oConnBDMETROSYS)
            drParticipante = CmdParticipante.ExecuteReader

            If drParticipante.HasRows = False Then
                Return False
            Else

                While drParticipante.Read

                    codigo = drParticipante(0).ToString
                    nome = drParticipante(1).ToString
                End While
                Me.txt_nomePart.Text = nome : drParticipante.Close()
            End If

        Catch ex As Exception
        End Try

        CmdParticipante.CommandText = ""
        SqlParticipante.Remove(0, SqlParticipante.ToString.Length)

        'LIMPA OBJETOS DA MEMORIA...
        codigo = Nothing : nome = Nothing : cpf_cnpj = Nothing : inscricao = Nothing : UF = Nothing
        oConnBDMETROSYS.ClearPool() : oConnBDMETROSYS.Close() : oConnBDMETROSYS = Nothing
        CmdParticipante = Nothing : SqlParticipante = Nothing


        Return True
    End Function

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown


        If Not Me.txt_codPart.Text.Equals("") Then
            If Me.txt_codPart.TextLength > 5 AndAlso e.KeyCode = Keys.Enter Then 'Se retornar nada
                If trazCliente(Me.txt_codPart.Text) Then

                    Dim lShouldReturn As Boolean
                    Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing

                End If
            End If
        End If

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            If Me.txt_codPart.Text.Equals("") Then
                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    _frmRef = Me : _BuscaCli.set_frmRef(Me) : _BuscaCli.ShowDialog(Me)
                    If Me.txt_codPart.Text.Equals("") Then Me.txt_codPart.Focus()

                    Dim lShouldReturn As Boolean
                    Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()
                    If lShouldReturn Then Return
                    lShouldReturn = Nothing

                Catch ex As Exception
                End Try

            End If
        End If



    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Dim opcao As Integer
        opcao = cbo_relatorio.SelectedIndex
        Select Case opcao
            Case 0
                relatorio_Preco_Saldo()
            Case 1
            Case 2
                relatorio_Preco_Grupo()
            Case 3
                relatorio_Preco_EstoqueMinimo()
        End Select
    End Sub
    Private Sub relatorio_Preco_Saldo()
        Dim fs As FileStream
        Dim s As StreamWriter
        fs = New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
        s = New StreamWriter(fs)

        Dim vlinha As Integer
        Dim tot_geral As Double
        s.BaseStream.Seek(0, SeekOrigin.End)

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim DrEst As NpgsqlDataReader
        '
        ' SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_cdport, el.e_qtde, e.e_und, e.e_ncm, ") ' 5
        ''SqlProduto.Append("e.e_cst, e.e_cfv, e.e_grupo, e.e_reduz, el.e_qtdfisc, el.e_pcusto, el.e_pcomp, ") ' 12
        ''SqlProduto.Append("e.e_clf, el.e_pvenda FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN ")
        ''SqlProduto.Append("estloja01 el ON e.e_codig = el.e_codig WHERE ")
        ''SqlProduto.Append("e.e_materiaprima = " & Me.chk_MPrima.Checked & " AND ")
        ''SqlProduto.Append("el.e_loja = '" & _local & "' AND ")
        ''If Me.rdb_barra.Checked = True Then
        ''    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE @pesquisa ORDER BY e.e_produt ASC")
        ''ElseIf Rdb_codigo.Checked = True Then
        ''    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE @pesquisa ORDER BY e.e_produt ASC")
        ''Else
        ''    SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE @pesquisa ORDER BY e.e_produt ASC")
        ''End If
        '
        Sqlcomm.Append("SELECT e.e_codig, e.e_produt, e.e_und, e.e_embalag, el.e_pvenda, ") '4
        Sqlcomm.Append("el.e_qtde, e.e_codsubs,e.e_clf,e.e_cfv,e.e_pcstent,e.e_pcstsai,e.e_ccstent,e.e_ccstsai, e.e_dtcomp FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e ")
        Sqlcomm.Append("JOIN estloja01 el ON e.e_codig = el.e_codig where el.e_loja = '" & Mid(_local, 4, 2) & "' and el.e_qtde >0 order by e.e_produt ")
        Dim daP As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
        Dim dsP As DataSet = New DataSet()

        Dim cmd As NpgsqlCommand = New NpgsqlCommand(Sqlcomm.ToString, conn)
        cmd.CommandText = Sqlcomm.ToString
        ' Criar datatable para leitura dos dados
        Dim dtProd As DataTable = New DataTable
        Dim vCodig, vProdut, vUnd, vEmbalag, vcodsub, vClf, VSaldo, vPvenda As String
        Dim vCfv As String = ""


        ' adicionando colunas

        Try
            If File.Exists(ArqMov) Then
                File.Delete(ArqMov)
            End If
            's.WriteLine(Chr(27) & Chr(15))
            's.WriteLine(Chr(27) & "0")
            s.WriteLine(" ")
            s.WriteLine(Exibe_cabecalho("TABELA DE PRECOS C/ SALDO EM " & CStr(DateValue(Now))))
            s.WriteLine(Exibe_cabefirma(MdlEmpresaUsu._fantasia))
            s.WriteLine(Exibe_cabefirma(MdlEmpresaUsu._endereco & " - " & MdlEmpresaUsu._bairro))
            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine("-------------------------------------------------------------------------------")
            s.WriteLine("CODIGO       PRODUTOS                       UND EMBALAGEM    SALDO      PRECO  ")
            '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxZ xxx xxxxxxxxxx 999,999.99 999,999.99   
            s.WriteLine("-------------------------------------------------------------------------------")

            conn.Open()
            dtProd.Load(cmd.ExecuteReader())   ' Carrega o datatable para memoria
            DrEst = cmd.ExecuteReader          ' Executa leitura do commando
            While (DrEst.Read())               ' Ler Registros Selecionado no Paramentro
                vCodig = Exibe_Str(DrEst(0).ToString, 6)
                vProdut = Exibe_Str(DrEst(1).ToString, 35)
                vUnd = Exibe_Str(DrEst(2).ToString, 3)
                vEmbalag = Exibe_Str(DrEst(3).ToString, 10)
                vcodsub = Exibe_Str(DrEst(6).ToString, 2)
                vClf = Exibe_Str(DrEst(7).ToString, 2)
                VSaldo = Exibe_Num(DrEst(5), 10)
                vPvenda = Exibe_Num(DrEst(4), 10)
                tot_geral = tot_geral + (VSaldo * vPvenda)
                vlinha = vlinha + 1
                If vlinha >= 80 Then
                    s.WriteLine(" ")
                    s.WriteLine(Exibe_cabecalho("TABELA DE PRECOS C/ SALDO EM " & CStr(DateValue(Now))))
                    s.WriteLine(Exibe_cabefirma(MdlEmpresaUsu._fantasia))
                    s.WriteLine(Exibe_cabefirma(MdlEmpresaUsu._endereco & " - " & MdlEmpresaUsu._bairro))
                    s.WriteLine("------------------------------------------------------------------------------")
                    s.WriteLine("CODIGO       PRODUTOS                       UND EMBALAGEM    SALDO     PRECO  ")
                    s.WriteLine("------------------------------------------------------------------------------")
                    vlinha = 1
                End If

                s.WriteLine(CStr(vCodig) & " " & vProdut & " " & vUnd & " " & vEmbalag & " " & VSaldo & vPvenda)

            End While

            s.WriteLine("   ")
            s.WriteLine("   ")
            s.WriteLine("   ")
            s.WriteLine(Exibe_cabecalho("TOTAL GERAL DO ESTOQUE R$ ----->" & Exibe_Num(Round(tot_geral, 2), 14)))
            ' s.WriteLine(Exibe_Num(tot_geral, 10))
            ' 
            conn.Close()
            s.Close()
            fs.Close()
            conn.Close()
            File.Copy(ArqTemp, ArqMov)
            StringToPrint = LerOArquivoSalvo(ArqMov)
            _StringToPrint = StringToPrint  ' novo
            StringToPrint = _StringToPrint
            Try
                ' Especifica as configurações da pagina atual
                PrintDocument1.DefaultPageSettings = PrintPageSettings
                'Configurando margens
                PrintDocument1.DefaultPageSettings.Margins.Top = 12
                PrintDocument1.DefaultPageSettings.Margins.Right = 10
                PrintDocument1.DefaultPageSettings.Margins.Left = 40
                PrintDocument1.DefaultPageSettings.Margins.Bottom = 8
                ' Especifica documento para a caixa de dialogo de visualização de impressão
                ' e mostra
                'StringToPrint = RichTextBox1.Text

                PrintPreviewDialog1.Document = PrintDocument1

                PrintPreviewDialog1.ShowDialog()

            Catch ex As Exception
                ' Exibe mensagem de erro
                MessageBox.Show(ex.Message.ToString)

            End Try
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            s.Close()
            fs.Close()
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub relatorio_Preco_Grupo()
        Dim fs As FileStream
        Dim s As StreamWriter
        fs = New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
        s = New StreamWriter(fs)

        Dim vlinha As Integer
        Dim tot_geral As Double
        s.BaseStream.Seek(0, SeekOrigin.End)

        Dim dtProd As DataTable = New DataTable
        Dim vCodig, vProdut, vUnd, vGrupo, XGrupo, vcodsub, vClf, VSaldo, vPvenda, GrupoAux As String
        Dim MGrupo, xPos As Integer

        XGrupo = cbo_grupo.SelectedItem
        xPos = XGrupo.IndexOf("-") : MGrupo = Mid(XGrupo, 1, xPos)
        GrupoAux = RTrim(Mid(XGrupo, xPos + 2, Len(XGrupo) - xPos))
        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim DrEst As NpgsqlDataReader
        If chk_zerados.CheckState = CheckState.Unchecked Then
            Sqlcomm.Append("SELECT e.e_codig, e.e_produt, e.e_und, e.e_grupo, el.e_pvenda, ") '4
            Sqlcomm.Append("el.e_qtde, e.e_codsubs,e.e_clf,e.e_cfv,e.e_pcstent,e.e_pcstsai,e.e_ccstent,e.e_ccstsai, e.e_dtcomp FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e ")
            Sqlcomm.Append("JOIN estloja01 el ON e.e_codig = el.e_codig where el.e_loja = '" & Mid(_local, 4, 2) & "' and el.e_qtde >0 and e.e_grupo=" & CDec(MGrupo) & " order by e.e_produt ")
        Else
            Sqlcomm.Append("SELECT e.e_codig, e.e_produt, e.e_und, e.e_grupo, el.e_pvenda, ") '4
            Sqlcomm.Append("el.e_qtde, e.e_codsubs,e.e_clf,e.e_cfv,e.e_pcstent,e.e_pcstsai,e.e_ccstent,e.e_ccstsai, e.e_dtcomp FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e ")
            Sqlcomm.Append("JOIN estloja01 el ON e.e_codig = el.e_codig where el.e_loja = '" & Mid(_local, 4, 2) & "' and el.e_qtde = 0 and e.e_grupo=" & CDec(MGrupo) & " order by e.e_produt ")
        End If
        Dim daP As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
        Dim dsP As DataSet = New DataSet()

        Dim cmd As NpgsqlCommand = New NpgsqlCommand(Sqlcomm.ToString, conn)
        cmd.CommandText = Sqlcomm.ToString
        ' Criar datatable para leitura dos dados

        Dim vCfv As String = ""


        ' adicionando colunas

        Try
            If File.Exists(ArqMov) Then
                File.Delete(ArqMov)
            End If
            's.WriteLine(Chr(27) & Chr(15))
            's.WriteLine(Chr(27) & "0")
            s.WriteLine(" ")
            s.WriteLine(Exibe_cabecalho("TABELA DE PRECOS DO GRUPO" & CStr(GrupoAux) & " C/ SALDO EM " & CStr(DateValue(Now))))
            s.WriteLine(Exibe_cabefirma(MdlEmpresaUsu._fantasia))
            s.WriteLine(Exibe_cabefirma(MdlEmpresaUsu._endereco & " - " & MdlEmpresaUsu._bairro))
            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine("-------------------------------------------------------------------------------")
            s.WriteLine("CODIGO       PRODUTOS                       UND   GRUPO      SALDO      PRECO  ")
            '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxZ xxx xxxxxxxxxx 999,999.99 999,999.99   
            s.WriteLine("-------------------------------------------------------------------------------")

            conn.Open()
            dtProd.Load(cmd.ExecuteReader())   ' Carrega o datatable para memoria
            DrEst = cmd.ExecuteReader          ' Executa leitura do commando
            While (DrEst.Read())               ' Ler Registros Selecionado no Paramentro
                vCodig = Exibe_Str(DrEst(0).ToString, 6)
                vProdut = Exibe_Str(DrEst(1).ToString, 35)
                vUnd = Exibe_Str(DrEst(2).ToString, 3)
                vGrupo = Exibe_Str(DrEst(3).ToString, 10)
                vcodsub = Exibe_Str(DrEst(6).ToString, 2)
                vClf = Exibe_Str(DrEst(7).ToString, 2)
                VSaldo = Exibe_Num(DrEst(5), 10)
                vPvenda = Exibe_Num(DrEst(4), 10)
                tot_geral = tot_geral + (VSaldo * vPvenda)
                vlinha = vlinha + 1
                If vlinha >= 80 Then
                    s.WriteLine(" ")
                    s.WriteLine(Exibe_cabecalho("TABELA DE PRECOS DO GRUPO" & CStr(GrupoAux) & " C/ SALDO EM " & CStr(DateValue(Now))))
                    s.WriteLine(Exibe_cabefirma(MdlEmpresaUsu._fantasia))
                    s.WriteLine(Exibe_cabefirma(MdlEmpresaUsu._endereco & " - " & MdlEmpresaUsu._bairro))
                    s.WriteLine("------------------------------------------------------------------------------")
                    s.WriteLine("CODIGO       PRODUTOS                       UND   GRUPO      SALDO     PRECO  ")
                    s.WriteLine("------------------------------------------------------------------------------")
                    vlinha = 1
                End If

                s.WriteLine(CStr(vCodig) & " " & vProdut & " " & vUnd & " " & vGrupo & " " & VSaldo & vPvenda)

            End While

            s.WriteLine("   ")
            s.WriteLine("   ")
            s.WriteLine("   ")
            s.WriteLine(Exibe_cabecalho("TOTAL GERAL DO ESTOQUE R$ ----->" & Exibe_Num(Round(tot_geral, 2), 14)))
            ' s.WriteLine(Exibe_Num(tot_geral, 10))
            ' 
            conn.Close()
            s.Close()
            fs.Close()
            conn.Close()
            File.Copy(ArqTemp, ArqMov)
            StringToPrint = LerOArquivoSalvo(ArqMov)
            _StringToPrint = StringToPrint

            Try
                ' Especifica as configurações da pagina atual
                PrintDocument1.DefaultPageSettings = PrintPageSettings
                'Configurando margens
                PrintDocument1.DefaultPageSettings.Margins.Top = 12
                PrintDocument1.DefaultPageSettings.Margins.Right = 12
                PrintDocument1.DefaultPageSettings.Margins.Left = 40
                PrintDocument1.DefaultPageSettings.Margins.Bottom = 8
                ' Especifica documento para a caixa de dialogo de visualização de impressão
                ' e mostra
                'StringToPrint = RichTextBox1.Text
                PrintPreviewDialog1.Document = PrintDocument1
                PrintPreviewDialog1.ShowDialog()

            Catch ex As Exception
                ' Exibe mensagem de erro
                MessageBox.Show(ex.Message.ToString)

            End Try
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            s.Close()
            fs.Close()
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub relatorio_Preco_EstoqueMinimo()
        Dim fs As FileStream
        Dim s As StreamWriter
        fs = New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
        s = New StreamWriter(fs)

        Dim vlinha As Integer
        Dim tot_geral As Double
        s.BaseStream.Seek(0, SeekOrigin.End)

        Dim dtProd As DataTable = New DataTable
        Dim vCodig, vProdut, vUnd, vGrupo, XGrupo, vcodsub, vClf, VSaldo, vPvenda, vMinimo, GrupoAux As String
        Dim MGrupo, xPos As Integer

        XGrupo = cbo_grupo.SelectedItem
        xPos = XGrupo.IndexOf("-") : MGrupo = Mid(XGrupo, 1, xPos)
        GrupoAux = RTrim(Mid(XGrupo, xPos + 2, Len(XGrupo) - xPos))
        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim DrEst As NpgsqlDataReader
        If chk_zerados.CheckState = CheckState.Unchecked Then
            Sqlcomm.Append("SELECT e.e_codig, e.e_produt, e.e_und, e.e_grupo, el.e_pvenda, ") '4
            Sqlcomm.Append("el.e_qtde, e.e_estmin,e.e_clf,e.e_cfv,e.e_pcstent,e.e_pcstsai,e.e_ccstent,e.e_ccstsai, e.e_dtcomp FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e ")
            Sqlcomm.Append("JOIN estloja01 el ON e.e_codig = el.e_codig where el.e_loja = '" & Mid(_local, 4, 2) & "' and el.e_qtde < e.e_estmin and e.e_grupo=" & CDec(MGrupo) & " order by e.e_produt ")
        Else
            Sqlcomm.Append("SELECT e.e_codig, e.e_produt, e.e_und, e.e_grupo, el.e_pvenda, ") '4
            Sqlcomm.Append("el.e_qtde, e.e_estmin,e.e_clf,e.e_cfv,e.e_pcstent,e.e_pcstsai,e.e_ccstent,e.e_ccstsai, e.e_dtcomp FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e ")
            Sqlcomm.Append("JOIN estloja01 el ON e.e_codig = el.e_codig where el.e_loja = '" & Mid(_local, 4, 2) & "' and el.e_qtde < e.e_estmin and e.e_grupo=" & CDec(MGrupo) & " order by e.e_produt ")
        End If
        Dim daP As NpgsqlDataAdapter = New NpgsqlDataAdapter(Sqlcomm.ToString, conn)
        Dim dsP As DataSet = New DataSet()

        Dim cmd As NpgsqlCommand = New NpgsqlCommand(Sqlcomm.ToString, conn)
        cmd.CommandText = Sqlcomm.ToString
        ' Criar datatable para leitura dos dados

        Dim vCfv As String = ""


        ' adicionando colunas

        Try
            If File.Exists(ArqMov) Then
                File.Delete(ArqMov)
            End If
            's.WriteLine(Chr(27) & Chr(15))
            's.WriteLine(Chr(27) & "0")
            s.WriteLine(" ")
            s.WriteLine(Exibe_cabecalho("PRODUTOS DO GRUPO" & CStr(GrupoAux) & " C/ SALDO ABAIXO DO MINIMO EM " & CStr(DateValue(Now))))
            s.WriteLine(Exibe_cabefirma(MdlEmpresaUsu._fantasia))
            s.WriteLine(Exibe_cabefirma(MdlEmpresaUsu._endereco & " - " & MdlEmpresaUsu._bairro))
            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine("-------------------------------------------------------------------------------")
            s.WriteLine("CODIGO       PRODUTOS                       UND   MINIMO     SALDO      PRECO  ")
            '            xxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxZ xxx 999,999.99 999,999.99 999,999.99   
            s.WriteLine("-------------------------------------------------------------------------------")

            conn.Open()
            dtProd.Load(cmd.ExecuteReader())   ' Carrega o datatable para memoria
            DrEst = cmd.ExecuteReader          ' Executa leitura do commando
            While (DrEst.Read())               ' Ler Registros Selecionado no Paramentro
                vCodig = Exibe_Str(DrEst(0).ToString, 6)
                vProdut = Exibe_Str(DrEst(1).ToString, 35)
                vUnd = Exibe_Str(DrEst(2).ToString, 3)
                vMinimo = Exibe_Num(DrEst(6).ToString, 10)
                VSaldo = Exibe_Num(DrEst(5), 10)
                vPvenda = Exibe_Num(DrEst(4), 10)
                tot_geral = tot_geral + (VSaldo * vPvenda)
                vlinha = vlinha + 1
                If vlinha >= 85 Then
                    s.WriteLine(" ")
                    s.WriteLine(Exibe_cabecalho("PRODUTOS DO GRUPO" & CStr(GrupoAux) & " C/ SALDO ABAIXO DO MINIMO EM " & CStr(DateValue(Now))))
                    s.WriteLine(Exibe_cabefirma(MdlEmpresaUsu._fantasia))
                    s.WriteLine(Exibe_cabefirma(MdlEmpresaUsu._endereco & " - " & MdlEmpresaUsu._bairro))
                    s.WriteLine("------------------------------------------------------------------------------")
                    s.WriteLine("CODIGO       PRODUTOS                       UND  MINIMO      SALDO     PRECO  ")
                    s.WriteLine("------------------------------------------------------------------------------")
                    vlinha = 1
                End If

                s.WriteLine(CStr(vCodig) & " " & vProdut & " " & vUnd & " " & vMinimo & " " & VSaldo & vPvenda)

            End While

            s.WriteLine("   ")
            s.WriteLine("   ")
            s.WriteLine("   ")
            s.WriteLine(Exibe_cabecalho("TOTAL GERAL DO ESTOQUE R$ ----->" & Exibe_Num(Round(tot_geral, 2), 14)))
            ' s.WriteLine(Exibe_Num(tot_geral, 10))
            ' 
            conn.Close()
            s.Close()
            fs.Close()
            conn.Close()
            File.Copy(ArqTemp, ArqMov)
            StringToPrint = LerOArquivoSalvo(ArqMov)
            _StringToPrint = StringToPrint

            Try
                ' Especifica as configurações da pagina atual
                PrintDocument1.DefaultPageSettings = PrintPageSettings
                'Configurando margens
                PrintDocument1.DefaultPageSettings.Margins.Top = 12
                PrintDocument1.DefaultPageSettings.Margins.Right = 12
                PrintDocument1.DefaultPageSettings.Margins.Left = 40
                PrintDocument1.DefaultPageSettings.Margins.Bottom = 8
                ' Especifica documento para a caixa de dialogo de visualização de impressão
                ' e mostra
                'StringToPrint = RichTextBox1.Text
                PrintPreviewDialog1.Document = PrintDocument1
                PrintPreviewDialog1.ShowDialog()

            Catch ex As Exception
                ' Exibe mensagem de erro
                MessageBox.Show(ex.Message.ToString)

            End Try
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            s.Close()
            fs.Close()
            MsgBox(ex.Message.ToString)
        End Try


    End Sub


    Private Function LerOArquivoSalvo(ByVal arqSaida As String) As String
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

        Return _StringToPrint
    End Function

    Public Function Exibe_cabecalho(ByVal strCab As String) As String
        Dim StrCampo As String
        Dim TotStr, totMed As Integer

        TotStr = Len(Text)
        totMed = (79 - TotStr) / 2
        StrCampo = Space(totMed) + RTrim(strCab) + Space(totMed)
        Return (StrCampo)
    End Function

    Public Function Exibe_cabefirma(ByVal strCab As String) As String
        Dim StrCampo As String
        Dim TotStr, totMed As Integer

        TotStr = Len(Text)
        totMed = (79 - TotStr)
        StrCampo = RTrim(strCab) + Space(totMed)
        Return (StrCampo)
    End Function

    ' Função p/ retornar a quantidade de String p/ formatar Formulario de Impressão
    Public Function Exibe_Str(ByVal text As String, ByVal StrTot As Integer) As String
        Dim StrCampo As String
        Dim TotStr As Integer
        '             4
        TotStr = Len(text)
        'If TotStr = StrTot Then
        '    StrTot = StrTot + 1
        'End If
        If TotStr > StrTot Then            ' Verifica se Total de String lida é Maior que Parâmetros
            TotStr = StrTot                ' em case positivo equipara quantidades
            text = Mid(text, 1, StrTot)    ' e abstrai string excedentes
        End If
        '             4                  6        4 = 2
        StrCampo = text + Space(StrTot - TotStr)

        Return (StrCampo)
    End Function

    ' Função p/ retornar a quantidade de String tipo Moeda p/ formatar Formulario de Impressão
    Public Function Exibe_Num(ByVal text As Double, ByVal StrTot As Integer) As String
        Dim StrCampo, StrCampo1 As String
        Dim TotStr As Integer
        ' Formata campo e converte p/ String c/ LImite do campo
        StrCampo1 = CStr(Format(text, "###,##0.00"))

        TotStr = Len(StrCampo1)            ' Calcula a quantidade de String
        StrCampo = Space(StrTot - TotStr) + LTrim(StrCampo1)

        Return (StrCampo)
    End Function

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim NumChars As Integer
        Dim NumLines As Integer
        Dim StringforPage As String
        Dim Strformat As New StringFormat

        Dim recdraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, _
                                      e.MarginBounds.Width, e.MarginBounds.Height)
        Dim SizeMeassure As New SizeF(e.MarginBounds.Width, _
                                      e.MarginBounds.Height - PrintFont.GetHeight(e.Graphics))

        Strformat.Trimming = StringTrimming.Word
        e.Graphics.MeasureString(StringToPrint, PrintFont, SizeMeassure, Strformat, NumChars, NumLines)
        StringforPage = StringToPrint.Substring(0, NumChars)
        ' Imprime a string na pagina atual
        e.Graphics.DrawString(StringforPage, PrintFont, Brushes.Black, recdraw, Strformat)
        ' Se Hover mais texto, indica que há mais paginas

        If NumChars < StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            StringToPrint = StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False
            StringToPrint = _StringToPrint

        End If

    End Sub

    Private Sub Frm_Relatorio_002_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            If File.Exists(ArqTemp) Then
                'File.Delete(ArqTemp)
                's.Dispose()
                'fs.Dispose()
                's.Close()
                'fs.Close()
            End If
            Me.Close()
        End If

    End Sub

    Private Sub Frm_Relatorio_002_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Relatorio_002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cbo_grupo = _CLFun.PreenchComboGrupos(cbo_grupo, MdlConexaoBD.conectionPadrao)
        Me.lbl_fornecedor.Visible = False
        Me.txt_codPart.Visible = False
        Me.txt_nomePart.Visible = False
        Me.lbl_grupo.Visible = False
        Me.cbo_grupo.Visible = False
        Me.chk_zerados.Visible = False
    End Sub

    Private Sub cbo_relatorio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_relatorio.SelectedIndexChanged
        If cbo_relatorio.SelectedIndex = 6 Then
            Me.lbl_fornecedor.Visible = True
            Me.txt_codPart.Visible = True
            Me.txt_nomePart.Visible = True
            Me.lbl_grupo.Visible = False
            Me.cbo_grupo.Visible = False
            Me.chk_zerados.Visible = False
            Me.txt_codPart.Focus()
        End If
        If cbo_relatorio.SelectedIndex = 2 Or cbo_relatorio.SelectedIndex = 3 Then
            Me.lbl_fornecedor.Visible = False
            Me.txt_codPart.Visible = False
            Me.txt_nomePart.Visible = False
            Me.lbl_grupo.Visible = True
            Me.cbo_grupo.Visible = True
            Me.chk_zerados.Visible = True
            Me.cbo_grupo.Focus()
        End If
    End Sub
End Class