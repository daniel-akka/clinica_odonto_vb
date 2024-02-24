Imports Npgsql
Imports System.IO
Imports System.Threading

Public Class Frm_Backup

    Dim clFuncoes As New ClFuncoes
    'Dim readThread As New Thread(AddressOf backup)

    Public Sub Cria_arqxml()

        SaveFileDialog1.Filter = "Backup (*.backup))|*.backup"
        'OpenFileDialog1
        Me.txt_implocal.Text = SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName <> "" Then Me.txt_implocal.Text = SaveFileDialog1.FileName

    End Sub

    Private Sub btn_implocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_implocal.Click
        Cria_arqxml()
    End Sub

    Private Sub btn_importar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_importar.Click
        'C:/Arquivos de programas/PostgreSQL/9.3/bin\pg_dump.exe --host localhost --port 5432 --username "postgres" --no-password  --format tar --blobs --verbose --file "C:\DiscoNet\Instalar\backup-metrosys\BDCASSIO-TESTE.backup" "BDMETROSYS"

        If Me.txt_implocal.Text.Equals("") = False Then
            backup()
        Else
            MsgBox("Informe primeiro o local onde o arquivo será salvo!")
        End If
    End Sub

    Private Sub backup()

        Try

            If Me.txt_implocal.Text.Equals("") Then
                MsgBox("Selecione o local onde o arquivo será salvo")
                Me.txt_implocal.Focus() : Return
            End If

            Dim fs As FileStream
            Try
                fs = New FileStream("\wged\Backup.bat", FileMode.Create, FileAccess.ReadWrite)

            Catch ex As Exception
                Try
                    File.Delete("\wged\Backup.bat")
                    fs = New FileStream("\wged\Backup.bat", FileMode.Create, FileAccess.ReadWrite)

                Catch ex1 As Exception
                    fs = New FileStream("\wged\Backup.bat", FileMode.Create, FileAccess.ReadWrite)
                End Try

            End Try

            Dim sw As New StreamWriter(fs)
            Dim comando As String = ""
            comando = "SET PGPASSWORD=Servnet" & vbNewLine & _
            "C:\""Arquivos de programas""\PostgreSQL\9.3\bin\pg_dump.exe -i -h " & clFuncoes.trazIpServidorBD("\wged\MetroSys\configBD.sys") & " -p 5432 -U postgres -F t -b -v -f """ & _
            Me.txt_implocal.Text & """ """ & clFuncoes.trazNomeBancoServidorBD("\wged\MetroSys\configBD.sys") & """ " '& clFuncoes.trazNomeBancoServidorBD("") & """""

            sw.WriteLine(comando)
            sw.Close()
            sw.Dispose()

            'Shell("\wged\Backup.bat", AppWinStyle.Hide)
            Dim process As Process
            process.Start("\wged\Backup.bat")
            'System.Threading.Thread.Sleep(100)


        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
        End Try
       
        
    End Sub

    Private Sub Frm_Backup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Frm_Backup_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        Try
            File.Delete("\wged\Backup.bat")
        Catch ex As Exception
        End Try
    End Sub

End Class