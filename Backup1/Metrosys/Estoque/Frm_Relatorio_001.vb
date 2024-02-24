Imports System.Drawing.Printing
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Data.DataColumnCollection
Imports System.Data.DataRow
Imports Npgsql


Public Class Frm_Relatorio_001
    Public Const ArqTemp As String = "c:\wged\TEMP.TMP"
    Public Const ArqMov As String = "c:\wged\Listagem.txt"
    Protected Const conexao As String = _
    "Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDGENOV"
    Private PrintPageSettings As New PageSettings
    Dim fs As New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
    Dim s As New StreamWriter(fs)
    
    Private StringToPrint As String
    Private PrintFont As New Font("Lucida Console", 9) 'Stencil

    Private Sub Frm_Relatorio_001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Relatorio_001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_open.Click
        Dim FilePath As String
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt"
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName <> "" Then
            FilePath = OpenFileDialog1.FileName
            Try
                Dim MyfileStream As New FileStream(FilePath, FileMode.Open)
                RichTextBox1.LoadFile(MyfileStream, RichTextBoxStreamType.PlainText)
                MyfileStream.Close()
                StringToPrint = RichTextBox1.Text
                btn_print.Enabled = True

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub

    Private Sub btn_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print.Click
        Try
            PrintDocument1.DefaultPageSettings = PrintPageSettings
            StringToPrint = RichTextBox1.Text
            PrintDialog1.Document = PrintDocument1

            Dim result As DialogResult = PrintDialog1.ShowDialog()
            If result = DialogResult.OK Then
                PrintDocument1.Print()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
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
            StringToPrint = RichTextBox1.Text

        End If

    End Sub

    Private Sub btn_gerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gerar.Click
        ''Dim fs As New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
        ''Dim s As New StreamWriter(fs)
        Dim vlinha As Integer
        Dim tot_geral As Double
        s.BaseStream.Seek(0, SeekOrigin.End)


        Dim conn As New Npgsql.NpgsqlConnection(conexao)
        Dim Sqlcomm As StringBuilder = New StringBuilder
        Dim DrEst As NpgsqlDataReader

        Sqlcomm.Append("SELECT e_codig, e_produt, e_und, e_embalag, e_pvenda, ") '4
        Sqlcomm.Append("e_qtde, e_codsubs,e_clf,e_cfv,e_pcstent,e_pcstsai,e_ccstent,e_ccstsai, e_dtcomp FROM est0001 where e_qtde >0 order by e_produt ")
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
            s.WriteLine(Exibe_cabecalho("RELATORIO DE ESTOQUE ATUAL"))
            s.WriteLine(Exibe_cabefirma("JOSINO COUTINHO DA SILVA"))
            s.WriteLine(Exibe_cabefirma("AV.AIRTON SENNA,658 - IPUEIRAS"))
            '                      1        2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine("-------------------------------------------------------------------------------")
            s.WriteLine("CODIGO       PORTADORES                     UND EMBALAGEM    SALDO      PRECO  ")
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
                If vlinha >= 85 Then
                    s.WriteLine(" ")
                    s.WriteLine(Exibe_cabecalho("RELATORIO DE ESTOQUE ATUAL"))
                    s.WriteLine(Exibe_cabefirma("JOSINO COUTINHO DA SILVA"))
                    s.WriteLine(Exibe_cabefirma("AV.AIRTON SENNA,658 - IPUEIRAS"))
                    s.WriteLine("------------------------------------------------------------------------------")
                    s.WriteLine("CODIGO       PORTADORES                     UND EMBALAGEM    SALDO     PRECO  ")
                    s.WriteLine("------------------------------------------------------------------------------")
                    vlinha = 1
                End If

                s.WriteLine(CStr(vCodig) & " " & vProdut & " " & vUnd & " " & vEmbalag & " " & VSaldo & vPvenda)
                's.WriteLine(CStr(vCodig) & "   " & vProdut) ' & " " & vUnd & " " & vEmbalag & " " & VSaldo & " " & vPvenda)
                's.WriteLine(" ")
                's.WriteLine(" ")
                's.WriteLine("              R$ " & vPvenda)
            End While
          
            s.WriteLine("   ")
            s.WriteLine("   ")
            s.WriteLine("   ")
            s.WriteLine(Exibe_cabecalho("TOTAL GERAL DO ESTOQUE R$ ----->" & Exibe_Num(tot_geral, 10)))
            ' s.WriteLine(Exibe_Num(tot_geral, 10))
            ' 
            conn.Close()
            s.Close()
            fs.Close()
            conn.Close()

            File.Copy(ArqTemp, ArqMov)
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            s.Close()
            fs.Close()
            MsgBox(ex.Message.ToString)
        End Try
        

    End Sub

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

    
    Private Sub btn_pagesetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pagesetup.Click
        Try
            ' Carrrega as configurações de pagina e exibe a caixa de diálogo de
            ' configuração de pagina
            'PageSetupDialog1.PageSettings = PrintPageSettings
            'PageSetupDialog1.PageSettings.Margins.Top = 30
            'PageSetupDialog1.PageSettings.Margins.Right = 30
            'PageSetupDialog1.PageSettings.Margins.Left = 20
            'PageSetupDialog1.PageSettings.Margins.Bottom = 20
            'PageSetupDialog1.ShowDialog()
        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try
    End Sub

    Private Sub btn_prtpreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_prtpreview.Click
        Try
            ' Especifica as configurações da pagina atual
            PrintDocument1.DefaultPageSettings = PrintPageSettings
            'Configurando margens
            PrintDocument1.DefaultPageSettings.Margins.Top = 12
            PrintDocument1.DefaultPageSettings.Margins.Right = 12
            PrintDocument1.DefaultPageSettings.Margins.Left = 8
            PrintDocument1.DefaultPageSettings.Margins.Bottom = 8
            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            StringToPrint = RichTextBox1.Text
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try
    End Sub

    Private Sub btn_imprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprime.Click

    End Sub
End Class