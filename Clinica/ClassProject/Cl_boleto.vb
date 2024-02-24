Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Text
Imports System.IO
Imports System.Threading
Imports BoletoNet
Imports System.Net.Mail
Imports System.Net.Mime

'Imports iTextSharp.text
'Imports iTextSharp.text.pdf
'Imports iTextSharp.text.html.simpleparser
'Imports imagePDF
Imports Npgsql
Public Class Cl_boleto
    Dim xb As BoletoBancario = New BoletoBancario

    Public Sub Gerar_boleto(ByVal MVenc As Date, Ced_CodBanco As Integer, ced_Cnpj As String, ced_emitente As String, ced_agencia As String, ced_conta As String, ced_DigAgencia As String, _
                             ced_DigConta As String, ced_CPFCNPJ As String, ced_Empresa As String, Sac_valor As Double, Sac_Carteira As String, Sac_nNumero As String, _
                             Sac_documento As String, Sac_CpfCnpj As String, Sac_Portador As String, Sac_Ender As String, Sac_Bairro As String, Sac_Cidade As String, _
                             Sac_Cep As String, Sac_UF As String, Inst1 As String, Inst2 As String, Inst3 As String, Inst4 As String, Inst5 As String)

        Dim xb As BoletoBancario = New BoletoBancario
        '
        ' *** Dados do Cedente   *****
        '
        xb.CodigoBanco = Ced_CodBanco 'Ced_CodBanco
        ' Enviar comprovante de entrega para testar o maior tamanho de boleto no Papel A4
        xb.MostrarComprovanteEntrega = True
        '                                         Ano       Mes          Dia 
        Dim vencimento As Date = New DateTime(MVenc.Year, MVenc.Month, MVenc.Day)
        Dim c As Cedente = New Cedente(ced_Cnpj, ced_emitente, ced_agencia, ced_conta) ' ?

        c.ContaBancaria.Agencia = ced_agencia
        c.ContaBancaria.DigitoAgencia = ced_DigAgencia
        c.ContaBancaria.Conta = ced_conta
        c.ContaBancaria.DigitoConta = ced_DigConta
        c.CPFCNPJ = ced_Cnpj
        c.Nome = ced_emitente

        '
        ' *** Dados do Sacado  ***
        '
        Dim vDoc As Int32 = Convert.ToInt32(Sac_documento)
        Dim b As BoletoNet.Boleto = New Boleto(vencimento, Sac_valor, Sac_Carteira, Sac_nNumero, c, New EspecieDocumento(Ced_CodBanco, 2)) 'Ced_CodBanco

        b.NumeroDocumento = Convert.ToString(vDoc)
        b.Sacado = New Sacado(Sac_CpfCnpj, Sac_Portador)
        b.Sacado.Endereco.End = Sac_Ender
        b.Sacado.Endereco.Bairro = Sac_Bairro
        b.Sacado.Endereco.Cidade = Sac_Cidade
        b.Sacado.Endereco.CEP = Sac_Cep
        b.Sacado.Endereco.UF = Sac_UF
        '
        '  São 7 instruções para testar o maior tamanho possível do formulário
        '

        Dim item1 As Instrucao_Caixa = New Instrucao_Caixa()
        item1.Descricao += (Inst1)
        b.Instrucoes.Add(item1)
        Dim item2 As Instrucao_Caixa = New Instrucao_Caixa()
        b.Instrucoes.Add(item2)
        item2.Descricao += (Inst2)
        Dim item3 As Instrucao_Caixa = New Instrucao_Caixa()
        item3.Descricao += (Inst3)
        b.Instrucoes.Add(item3)
        Dim item4 As Instrucao_Caixa = New Instrucao_Caixa()
        item4.Descricao += (Inst4)
        b.Instrucoes.Add(item4)
        Dim item5 As Instrucao_Caixa = New Instrucao_Caixa()
        item5.Descricao += (Inst5)
        b.Instrucoes.Add(item5)
        Dim item6 As Instrucao_Caixa = New Instrucao_Caixa()
        item6.Descricao += ("")
        b.Instrucoes.Add(item6)
        Dim item7 As Instrucao_Caixa = New Instrucao_Caixa()
        item7.Descricao += ("")
        b.Instrucoes.Add(item7)
        b.Aceite = "Sim"
        b.Especie = "DM"
        xb.Boleto = b
        xb.Boleto.Valida()
        Dim html As StringBuilder = New StringBuilder()
        html.Append(xb.MontaHtml())
        '  html.Append("</br></br></br></br>")
        Dim html_st As String = html.ToString
        Dim boletoPathHTML As String = System.IO.Path.Combine(System.IO.Path.GetTempPath, "Boleto.html")
        Dim f As FileStream = New FileStream(boletoPathHTML, FileMode.Create)
        Using (f)
            Dim w As StreamWriter = New StreamWriter(f, System.Text.Encoding.Default)
            w.Write(html.ToString())
            w.Close()
            f.Close()
            System.Diagnostics.Process.Start(boletoPathHTML) ' Exibe o boleto na página
        End Using
        b.NumeroDocumento = Nothing
        vencimento = Nothing
        xb.Dispose()
        xb = Nothing

        Threading.Thread.Sleep(900)

        'Dim boletoPathPDF As String = System.IO.Path.Combine(System.IO.Path.GetTempPath, "Boleto.pdf")
        'Dim imagePath As String = Image(boletoPathHTML)
        'Dim doc As Document = New Document(PageSize.A4, 46, 0, 40, 0)
        'PdfWriter.GetInstance(doc, New FileStream(boletoPathPDF, FileMode.Create))
        'doc.Open()
        'Dim gif As Image = Image.GetInstance(imagePath)
        'gif.ScaleAbsolute(494.0F, 785.0F)
        'doc.Add(gif)
        'doc.CloseDocument()
        'Dim mail As MailMessage = PrepararEmail("luiz@eportais.net") ' E-mail PARA
        'mail.Subject += " - Off-Line"
        ' '' mail.AlternateViews.Add(bb.HtmlBoletoParaEnvioEmail()) ' Não funcionou
        'Dim body As String = "<img src=""cid:logoImage""/><br><br>"
        'Dim view As AlternateView = AlternateView.CreateAlternateViewFromString(body, System.Text.Encoding.UTF8, MediaTypeNames.Text.Html)
        ''======
        ''==== Adicionar o logo no topo do e-mail
        ''======
        'Dim resource As LinkedResource = New LinkedResource("C:\temp\Logos\LogoePortaisEmail.gif")
        'resource.ContentId = "LogoImage"
        'view.LinkedResources.Add(resource)
        'mail.AlternateViews.Add(view)
        ''  mail.IsBodyHtml = True
        'Dim ArquiAttach As Attachment = New Attachment(boletoPathPDF, MediaTypeNames.Application.Octet)
        'mail.Attachments.Add(ArquiAttach)
        'EnviarEmail(mail)


    End Sub
End Class
