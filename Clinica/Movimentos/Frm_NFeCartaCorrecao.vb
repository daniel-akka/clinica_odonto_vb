Imports System.Text
Imports System.IO
Imports Npgsql
Imports GenoNFeXml

Public Class Frm_NFeCartaCorrecao

    Dim _clFuncoes As New ClFuncoes
    Dim cl_BD As New Cl_bdMetrosys
    Dim clNFe As New GeraXml
    Dim frmGeraNF As New Frm_GeraNotasFiscais

    'Correção...
    Private xmlPath As String = "\wged\MyDataCCe.xml"
    Private ArqTemp As String = "\wged\NFeCCe.txt"
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

    Private Sub Frm_NFeCartaCorrecao_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

    Private Sub btn_enviacce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviacce.Click

        Try
            fsxml = New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
            s = New StreamWriter(fsxml)

            frmGeraNF.nota1pp.pNt_seqCCe += 1
            clNFe.CartaEletronica_cce(frmGeraNF.nota1pp.pNt_nume, frmGeraNF.nota1pp.pNt_chave, txt_mensagem.Text, frmGeraNF.seqNfe, _
                                    frmGeraNF.geno001.pCoduf, MdlEmpresaUsu._cnpj, MdlEmpresaUsu._ambienteNFe, frmGeraNF.nota1pp.pNt_seqCCe, s)
            s.Close()
            fsxml.Close()

            Try
                xmlPath = frmGeraNF.genp001.pathEnvioXML & "\" & frmGeraNF.nota1pp.pNt_chave & "-" & Format(frmGeraNF.nota1pp.pNt_seqCCe, "00") & "-env-cce.xml"
                File.Copy(ArqTemp, xmlPath, True)
            Catch ex As Exception
                MsgBox("ERRO ao copiar o XML para """ & xmlPath & """ :: " & ex.Message, MsgBoxStyle.Exclamation)
                Return
            End Try

            buscaArquivosXML()

        Catch ex As Exception
            lbl_mensagem.Text = "ERRO:: " & ex.Message
            Me.Refresh()
            fsxml = Nothing : s = Nothing
        End Try

    End Sub

    Private Sub buscaArquivosXML()


        Me.lbl_mensagem.Text = "Iniciando Carta de Correção da NFe..."
        Me.Refresh()
        System.Threading.Thread.Sleep(500)
        strXmlRetorno = _clFuncoes.lerXmlRetornoCCe(frmGeraNF.nota1pp.pNt_chave, frmGeraNF.nota1pp.pNt_seqCCe, frmGeraNF.genp001)


        If strXmlRetorno.Equals("") Then 'Se retornou nada...
            System.Threading.Thread.Sleep(500)
            strArqErroRetorno = _clFuncoes.lerArqErroRetornoCCe(frmGeraNF.nota1pp.pNt_chave, frmGeraNF.nota1pp.pNt_seqCCe, frmGeraNF.genp001)
            Me.rtb_mensagem.Text = strArqErroRetorno : Me.Refresh()
        Else


            'Tratamento do CCe.XML...
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
                Case "135", "136"
                    cl_BD.altStatusNota1pp(frmGeraNF.nota1pp.pNt_nume, strXmlStatus, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    cl_BD.altSeqCCeNota1pp(frmGeraNF.nota1pp.pNt_nume, frmGeraNF.nota1pp.pNt_seqCCe, MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao)
                    btn_enviacce.Enabled = False
            End Select


        End If


    End Sub

End Class