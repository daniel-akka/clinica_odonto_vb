Imports System.Text
Imports System.IO
Imports Npgsql
Imports GenoNFeXml

Public Class Frm_CancelamentoNFe

    Dim _clFuncoes As New ClFuncoes
    Dim cl_BD As New Cl_bdMetrosys
    Dim clNFe As New GeraXml
    Dim frmGeraNF As New Frm_GeraNotasFiscais

    'Cancelamento
    Private xmlPath As String = "\wged\MyDataCanc.xml"
    Private ArqTemp As String = "\wged\NFeCanc.txt"
    Dim fsxml As FileStream
    Dim s As StreamWriter

    'Tratamento de Retorno do xml...
    Dim xmlArquivo As New StringBuilder
    Dim strXmlRetorno As String = "", strArqErroRetorno As String = "", strXmlLoteRecebido As String = "", strXmlProcRec As String = ""
    Dim numLotRetorno As String = "", strXmlStatus As String = "", strXmlMotivo As String = "", strXmlProcRecAux As String = ""
    Dim strXmlProtocolo As String = ""
    Dim strXmlRec As String = "", strXmlHora As String = ""
    Dim strAux1 As String = "", strAux2 As String = ""
    Dim xposinicio, xposfim, xposdif, xposAux As Integer

    Public Sub setFrmGeraNotasFiscais(ByVal frm As Frm_GeraNotasFiscais)
        Me.frmGeraNF = frm
    End Sub

    Private Sub Frm_CancelamentoNFe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_chaveNFe.Text = frmGeraNF.nota1pp.pNt_chave
        txt_protocoloNFe.Text = Me.frmGeraNF.nota1pp.pNt_proto
    End Sub

    Private Sub Frm_CancelamentoNFe_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub Frm_CancelamentoNFe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

    Private Function verificaCanc() As Boolean
        lbl_mensagem.Text = ""
        If txt_chaveNFe.Text.Equals("") Then
            lbl_mensagem.Text = "Erro:: Chave em Branco !" : Return False
        End If

        If Trim(txt_protocoloNFe.Text).Equals("") Then
            lbl_mensagem.Text = "Erro:: Protocolo em Branco !" : Return False
        End If

        Return True
    End Function

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click


        If verificaCanc() Then

            Try
                fsxml = New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
                s = New StreamWriter(fsxml)

                clNFe.Cancela_EventoNFe(frmGeraNF.nota1pp.pNt_nume, frmGeraNF.nota1pp.pNt_chave, frmGeraNF.nota1pp.pNt_proto, frmGeraNF.seqNfe, _
                                        frmGeraNF.geno001.pCoduf, MdlEmpresaUsu._cnpj, MdlEmpresaUsu._ambienteNFe, s)
                s.Close()
                fsxml.Close()

                Try
                    xmlPath = frmGeraNF.genp001.pathEnvioXML & "\" & frmGeraNF.nota1pp.pNt_chave & "-env-canc.xml"
                    File.Copy(ArqTemp, xmlPath, True)
                Catch ex As Exception
                    MsgBox("ERRO ao copiar o XML para """ & xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
                End Try

                buscaArquivosXML()

            Catch ex As Exception
                lbl_mensagem.Text = "ERRO:: " & ex.Message
                Me.Refresh()
                fsxml = Nothing : s = Nothing
            End Try

        End If

    End Sub

    Private Sub txt_protocoloNFe_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_protocoloNFe.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub buscaArquivosXML()


        Me.lbl_mensagem.Text = "Iniciando Cancelamento da NFe..."
        Me.Refresh()
        System.Threading.Thread.Sleep(2000)
        strXmlRetorno = _clFuncoes.lerXmlRetornoCanc(frmGeraNF.nota1pp.pNt_chave, frmGeraNF.genp001)


        If strXmlRetorno.Equals("") Then 'Se retornou nada...
            System.Threading.Thread.Sleep(500)
            strArqErroRetorno = _clFuncoes.lerArqErroRetornoCanc(frmGeraNF.nota1pp.pNt_chave, frmGeraNF.genp001)
            Me.rtb_mensagem.Text = strArqErroRetorno : Me.Refresh()
        Else


            'Tratamento do CANC.XML...
            xposAux = strXmlRetorno.IndexOf("</cStat>") + 10
            strXmlRetorno = strXmlRetorno.Substring(xposAux)
            strAux1 = "<cStat>"
            strAux2 = "</cStat>"
            xposinicio = strXmlRetorno.IndexOf("<cStat>") : xposfim = strXmlRetorno.IndexOf("</cStat>")
            xposdif = (xposfim - xposinicio) - strAux1.Length

            Try
                strXmlStatus = Mid(strXmlRetorno, xposinicio + strAux2.Length, xposdif)
            Catch ex As Exception
                MsgBox("ERRO ao Ler Xml Retorno <cStat> """ & xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
                Return
            End Try

            xposAux = strXmlRetorno.IndexOf("</xMotivo>") + 15
            strXmlRetorno = strXmlRetorno.Substring(xposAux)
            strAux1 = "<xMotivo>"
            strAux2 = "</xMotivo>"
            xposinicio = strXmlRetorno.IndexOf("<xMotivo>") : xposfim = strXmlRetorno.IndexOf("</xMotivo>")
            xposdif = (xposfim - xposinicio) - strAux1.Length
            Try
                strXmlMotivo = Mid(strXmlRetorno, xposinicio + strAux2.Length, xposdif)
            Catch ex As Exception
                MsgBox("ERRO ao Ler Xml Retorno <xMotivo> """ & xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
                Return
            End Try

            Me.lbl_mensagem.Text = strXmlStatus & " - " & strXmlMotivo & " !"
            Me.Refresh()

            Select Case strXmlStatus
                Case "135", "136", "155"
                    cl_BD.altTipoNt_Nota1pp(frmGeraNF.nota1pp.pNt_nume, "C", MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altStatusNota1pp(frmGeraNF.nota1pp.pNt_nume, strXmlStatus, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    btn_cancelar.Enabled = True
            End Select

            cl_BD.altProtoNota1pp(frmGeraNF.nota1pp.pNt_nume, Me.txt_protocoloNFe.Text, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
        End If


    End Sub


End Class