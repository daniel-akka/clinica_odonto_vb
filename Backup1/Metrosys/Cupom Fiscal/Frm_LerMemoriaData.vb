Imports Npgsql

Public Class Frm_LerMemoriaData
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Dim ECF As New ClsFuncoes_ECF.total2
    Dim _mac As String
    Dim _tipoImpressora As Integer
    Private Const _valorZERO As Integer = 0

    Private Sub btn_confirma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirma.Click

        If verificaCampos() Then

            Dim iRetorno As Integer
            
            'Traz o tipo da Impressora Fiscal...
            Select Case _tipoImpressora

                Case 1 ' 1 - Bematech
                    iRetorno = Bematech_FI_LeituraMemoriaFiscalData(dtp_periodoInicial.Text, dtp_periodoFinal.Text)

                Case 2 ' 2 - Daruma
                    iRetorno = Daruma_FI_LeituraMemoriaFiscalData(dtp_periodoInicial.Text, dtp_periodoFinal.Text)

                Case 3 ' 3 - Zanthus


                Case 4 ' 4 - Elgin


                Case 5 ' 5 - Dataregis


                Case 6 ' 6 - EcfOutras


                Case 7 ' 7 - NaoFiscal


            End Select


        End If



    End Sub

    Private Sub Frm_LerMemoriaData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        _mac = _clFuncoes.EnderecoMac()

        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Me.Close()
        End Try

        Try

            'Sem o localhost está configurado para imprimir Cupom Fiscal...
            If _clBD.existeMacImpressora(conection, _mac) Then

                _tipoImpressora = _clFuncoes.trazTipoImpressora(_mac, MdlConexaoBD.conectionPadrao)

            Else
                btn_confirma.Enabled = False
            End If
            conection.ClearPool() : conection.Close()
        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)

        Finally
            conection = Nothing
        End Try


    End Sub

    Private Function verificaCampos() As Boolean

        If IsDate(dtp_periodoInicial.Text) = False Then

            MsgBox("Data Inicial inválida", MsgBoxStyle.Exclamation) : dtp_periodoInicial.Focus()
            Return False
        End If

        If IsDate(dtp_periodoFinal.Text) = False Then

            MsgBox("Data Final inválida", MsgBoxStyle.Exclamation) : dtp_periodoFinal.Focus()
            Return False
        End If

        Return True
    End Function
End Class