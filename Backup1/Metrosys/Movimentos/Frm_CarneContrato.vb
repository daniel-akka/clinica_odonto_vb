Imports System.Text
Imports System.IO
Imports System.DateTime
Imports System.Data.DataTable
Imports System.Data.DataColumn
Imports System.Drawing.Printing
Imports System.Math
Imports Npgsql

Public Class Frm_CarneContrato


    Private Const _valorZERO As Integer = 0
    Dim transacao As NpgsqlTransaction
    Dim _clFunc As New ClFuncoes

    Public numeros, Xfuncao As New Cl_bdMetrosys
    Dim Mdias As Integer = 30
    Dim Mdata As Date = Now
    Dim XData As String
    Public Duplicata As String

    Public C_CodCli As String
    Public C_CodVendedor As String
    Public C_emissao As Date
    Public C_QtdeParcelas As Int16
    Public C_Entrada As Double

    ' *******************************************************************************
    ' ****  Vetores auxiliares de Gravação do Numero, vencimento e Valor do Carne  **
    ' ** Não sera utilizado o array 0, somente a artir do 1
    Dim NumCarne(21) As String
    Dim VlrCarne(21) As Double
    Dim Vencto(21) As String
    '   *******************************************************************************

    Private nomeCliente, endCliente As String
    Private codLoja As String = MdlEmpresaUsu._codigo
    Private mQtdPaginas As Integer = 0

    'variáveis para carne
    Dim mParcela1OK, mParcela2OK, mParcela3OK, mParcela4OK, mParcela5OK As Boolean
    Dim mParcela6OK, mParcela7OK, mParcela8OK, mParcela9OK, mParcela10OK As Boolean
    Dim mParcela11OK, mParcela12OK, mParcela13OK, mParcela14OK, mParcela15OK As Boolean
    Dim mParcela16OK, mParcela17OK, mParcela18OK, mParcela19OK, mParcela20OK As Boolean
    Dim mproximaPaginaOk As Boolean
    Dim _mStrConsulta As String = "", _StringToPrint As String = ""

    'objetos para impressão
    Dim MostrarCaixaImpressoras As Boolean = False
    Private _PrintFont As New Font("Lucida Console", 8) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _sImpressao As StreamWriter
    Private _dtAdaptPrint As NpgsqlDataAdapter


    Public Property MC_QtdeParcelas() As Int16
        Get
            Return Me.C_QtdeParcelas
        End Get
        Set(ByVal value As Int16)
            Me.C_QtdeParcelas = value
        End Set
    End Property

    Public Property MC_Entrada() As Double
        Get
            Return Me.C_Entrada
        End Get
        Set(ByVal value As Double)
            Me.C_Entrada = value
        End Set
    End Property

    Public Property MEmissao() As Date
        Get
            Return Me.C_emissao
        End Get
        Set(ByVal value As Date)
            Me.C_emissao = value
        End Set
    End Property

    Public Property MCodCli() As String
        Get
            Return Me.C_CodCli
        End Get
        Set(ByVal value As String)
            Me.C_CodCli = value
        End Set
    End Property

    Public Property MDuplicata() As String
        Get
            Return Me.Duplicata
        End Get
        Set(ByVal value As String)
            Me.Duplicata = value
        End Set
    End Property

    Public Property MC_CodVendedor() As String
        Get
            Return Me.C_CodVendedor
        End Get
        Set(ByVal value As String)
            Me.C_CodVendedor = value
        End Set
    End Property


    Private Sub Frm_CarneContrato_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Frm_CarneContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_CarneContrato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        nomeCliente = _clFunc.trazColunaCadp001(C_CodCli, "p_portad", MdlConexaoBD.conectionPadrao)
        endCliente = _clFunc.trazColunaCadp001(C_CodCli, "p_end", MdlConexaoBD.conectionPadrao)

        If _clFunc.existNumCarne(lbl_contrato.Text & "A", MdlEmpresaUsu._esqEstab, MdlConexaoBD.conectionPadrao) Then
            Me.btn_gravar.Enabled = False
            Me.lbl_mensagem.Text = "Carnê já Gravado no Banco!"
        End If

        'Me.txt_entrada.Text = Format(Convert.ToDouble(0.0), "##,##0.00")
        Me.txt_qtde.Text = MC_QtdeParcelas
        Me.txt_entrada.Text = Format(MC_Entrada, "##,##0.00")
        Me.txt_qtde.Focus()


        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorio.BeginPrint, AddressOf InicializaRelatorio

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler pdRelatorio.PrintPage, AddressOf rptGravaTotaisNF

    End Sub

    Private Sub txt_entrada_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_entrada.GotFocus
        If CDec(Me.txt_qtde.Text) = 0 Or Me.txt_qtde.Text = "" Then
            MessageBox.Show("Quantidade de parcelas não Informada, Redigite !", "   Parcelas ", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Me.txt_qtde.Focus()
        End If
    End Sub

    Private Sub txt_entrada_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_entrada.Leave
        Dim vlParcelas As Double = 0.0
        Dim vlultima As Double = 0.0
        Dim vldiferenca As Double = 0.0
        Dim StrVar(10) As String

        'vlParcelas = Convert.ToInt32(CDbl(Me.txt_total.Text - CDbl(Me.txt_entrada.Text)) / Convert.ToInt16(Me.txt_qtde.Text)) * 100
        vlParcelas = Round(CDbl(Me.txt_total.Text - CDbl(Me.txt_entrada.Text)) / Convert.ToInt16(Me.txt_qtde.Text), 2) * 100
        vlParcelas = (vlParcelas / 100)
        vldiferenca = vlParcelas * (Convert.ToInt16(Me.txt_qtde.Text) - 1)
        vlultima = CDbl(Me.txt_total.Text - CDbl(Me.txt_entrada.Text)) - vldiferenca
        ' lbl_mensagem.Text = Me.txt_total.Text & " -  " & Me.txt_entrada.Text & "  -  " & Str(vldiferenca)
        If Convert.ToInt16(txt_qtde.Text) = 1 Then
            Try
                Me.txt_valor1.Text = Convert.ToInt32(CDbl(Me.txt_total.Text - CDbl(Me.txt_entrada.Text)))
                Me.txt_valor1.Text = Format(Convert.ToDouble(Me.txt_valor1.Text), "##,##0.00")
                Mdata = Now.AddDays(Mdias)
                Me.msk_vencto1.Text = Data_fixa(Mdata, Now.Day)
                Me.txt_num1.Text = lbl_contrato.Text + "A"
                'Auxiliar
                NumCarne(0) = txt_num1.Text : VlrCarne(0) = txt_valor1.Text : Vencto(0) = msk_vencto1.Text
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try

        Else
            If Convert.ToInt32(txt_qtde.Text) < 21 Then
                recebe_parcelas(vlParcelas, vlultima, Convert.ToInt16(Me.txt_qtde.Text))
            Else
                lbl_mensagem.Text = "Quantidade de Parcelas Ultrapassou limite, Redigite !"
                'MessageBox.Show("Quantidade de Parcelas Ultrapassou limite, Redigite !", "Erro Parcelas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ' Me.txt_qtde.Focus()
            End If
        End If
        Me.txt_valor1.Focus()


        lbl_mensagem.Text = ""
        If Me.txt_entrada.Text.Equals("") Then Me.txt_entrada.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_entrada.Text) Then
            If CDec(Me.txt_entrada.Text) < _valorZERO Then
                lbl_mensagem.Text = "Entrada deve ser maior ou igual a ZERO !"
                Return

            End If
            Me.txt_entrada.Text = Format(CDec(Me.txt_entrada.Text), "###,##0.00")

        End If

    End Sub

    Private Sub zeraPercelas()

        mParcela1OK = False : mParcela2OK = False : mParcela3OK = False : mParcela4OK = False
        mParcela5OK = False : mParcela6OK = False : mParcela7OK = False : mParcela8OK = False
        mParcela9OK = False : mParcela10OK = False : mParcela11OK = False : mParcela12OK = False
        mParcela13OK = False : mParcela14OK = False : mParcela15OK = False : mParcela16OK = False
        mParcela17OK = False : mParcela18OK = False : mParcela19OK = False : mParcela20OK = False
        mproximaPaginaOk = False

    End Sub

    Private Sub Recebe_vetoresAuxilia_ate_10()
        ' Vetores Auxiliares
        NumCarne(0) = txt_num1.Text : VlrCarne(0) = txt_valor1.Text : Vencto(0) = msk_vencto1.Text
        NumCarne(1) = txt_num2.Text : VlrCarne(1) = txt_valor2.Text : Vencto(1) = msk_vencto2.Text
        NumCarne(2) = txt_num3.Text : VlrCarne(2) = txt_valor3.Text : Vencto(2) = msk_vencto3.Text
        NumCarne(3) = txt_num4.Text : VlrCarne(3) = txt_valor4.Text : Vencto(3) = msk_vencto4.Text
        NumCarne(4) = txt_num5.Text : VlrCarne(4) = txt_valor5.Text : Vencto(4) = msk_vencto5.Text
        NumCarne(5) = txt_num6.Text : VlrCarne(5) = txt_valor6.Text : Vencto(5) = msk_vencto6.Text
        NumCarne(6) = txt_num7.Text : VlrCarne(6) = txt_valor7.Text : Vencto(6) = msk_vencto7.Text
        NumCarne(7) = txt_num8.Text : VlrCarne(7) = txt_valor8.Text : Vencto(7) = msk_vencto8.Text
        NumCarne(8) = txt_num9.Text : VlrCarne(8) = txt_valor9.Text : Vencto(8) = msk_vencto9.Text
        NumCarne(9) = txt_num10.Text : VlrCarne(9) = txt_valor10.Text : Vencto(9) = msk_vencto10.Text
    End Sub

    Private Sub Recebe_VetoresAuxiliar_ate_15()
        ' Vetores Auxiliares
        NumCarne(0) = txt_num1.Text : VlrCarne(0) = txt_valor1.Text : Vencto(0) = msk_vencto1.Text
        NumCarne(1) = txt_num2.Text : VlrCarne(1) = txt_valor2.Text : Vencto(1) = msk_vencto2.Text
        NumCarne(2) = txt_num3.Text : VlrCarne(2) = txt_valor3.Text : Vencto(2) = msk_vencto3.Text
        NumCarne(3) = txt_num4.Text : VlrCarne(3) = txt_valor4.Text : Vencto(3) = msk_vencto4.Text
        NumCarne(4) = txt_num5.Text : VlrCarne(4) = txt_valor5.Text : Vencto(4) = msk_vencto5.Text
        NumCarne(5) = txt_num6.Text : VlrCarne(5) = txt_valor6.Text : Vencto(5) = msk_vencto6.Text
        NumCarne(6) = txt_num7.Text : VlrCarne(6) = txt_valor7.Text : Vencto(6) = msk_vencto7.Text
        NumCarne(7) = txt_num8.Text : VlrCarne(7) = txt_valor8.Text : Vencto(7) = msk_vencto8.Text
        NumCarne(8) = txt_num9.Text : VlrCarne(8) = txt_valor9.Text : Vencto(8) = msk_vencto9.Text
        NumCarne(9) = txt_num10.Text : VlrCarne(9) = txt_valor10.Text : Vencto(9) = msk_vencto10.Text

        NumCarne(10) = txt_num11.Text : VlrCarne(10) = txt_valor11.Text : Vencto(10) = msk_vencto11.Text
        NumCarne(11) = txt_num12.Text : VlrCarne(11) = txt_valor12.Text : Vencto(11) = msk_vencto12.Text
        NumCarne(12) = txt_num13.Text : VlrCarne(12) = txt_valor13.Text : Vencto(12) = msk_vencto13.Text
        NumCarne(13) = txt_num14.Text : VlrCarne(13) = txt_valor14.Text : Vencto(13) = msk_vencto14.Text
        NumCarne(14) = txt_num15.Text : VlrCarne(14) = txt_valor15.Text : Vencto(14) = msk_vencto15.Text
    End Sub

    Private Sub recebe_parcelas(ByVal ValorParc As Double, ByVal ValorUltima As Double, ByVal Parcelas As Integer)
        ' Mascara do Valor de entrada
        ValorParc = Format(Convert.ToDouble(ValorParc), "##,##0.00")
        ValorUltima = Format(Convert.ToDouble(ValorUltima), "##,##0.00")
        Mdata = Now.AddDays(Mdias)
        Select Case Parcelas
            Case 1
                Me.txt_valor1.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.msk_vencto1.Text = Data_fixa(Mdata, Now.Day)
                ' Vetores Auxiliares
                NumCarne(1) = txt_num1.Text : VlrCarne(1) = txt_valor1.Text : Vencto(1) = msk_vencto1.Text
            Case 2
                Me.txt_valor1.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor2.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")
                Me.msk_vencto1.Text = Data_fixa(Mdata, Now.Day) : Me.msk_vencto2.Text = Data_fixa(Mdata.AddDays(Mdias), (Now.Day))
                ' Numero do carne
                Me.txt_num1.Text = lbl_contrato.Text + "A" : Me.txt_num2.Text = lbl_contrato.Text + "B"
                ' Vetores Auxiliares
                NumCarne(0) = txt_num1.Text : VlrCarne(0) = txt_valor1.Text : Vencto(0) = msk_vencto1.Text
                NumCarne(1) = txt_num2.Text : VlrCarne(1) = txt_valor2.Text : Vencto(1) = msk_vencto2.Text
            Case 3
                Me.txt_valor1.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor2.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor3.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")
                'Vencimento
                Me.msk_vencto1.Text = Data_fixa(Mdata, Now.Day) : Me.msk_vencto2.Text = Data_fixa(Mdata.AddDays(Mdias), (Now.Day)) : Me.msk_vencto3.Text = Data_fixa(Mdata.AddDays(Mdias + 30), (Now.Day))
                ' Numero do carne
                Me.txt_num1.Text = lbl_contrato.Text + "A" : Me.txt_num2.Text = lbl_contrato.Text + "B" : Me.txt_num3.Text = lbl_contrato.Text + "C"
                ' Vetores Auxiliares
                NumCarne(0) = txt_num1.Text : VlrCarne(0) = txt_valor1.Text : Vencto(0) = msk_vencto1.Text
                NumCarne(1) = txt_num2.Text : VlrCarne(1) = txt_valor2.Text : Vencto(1) = msk_vencto2.Text
                NumCarne(2) = txt_num3.Text : VlrCarne(2) = txt_valor3.Text : Vencto(2) = msk_vencto3.Text

            Case 4
                Me.txt_valor1.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor2.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor3.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor4.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")
                ' Vencimento
                Me.msk_vencto1.Text = Data_fixa(Mdata, Now.Day) : Me.msk_vencto2.Text = Data_fixa(Mdata.AddDays(Mdias), (Now.Day)) : Me.msk_vencto3.Text = Data_fixa(Mdata.AddDays(Mdias + 30), (Now.Day))
                Me.msk_vencto4.Text = Data_fixa(Mdata.AddDays(Mdias + 60), (Now.Day))
                ' Numero do carne
                Me.txt_num1.Text = lbl_contrato.Text + "A" : Me.txt_num2.Text = lbl_contrato.Text + "B" : Me.txt_num3.Text = lbl_contrato.Text + "C"
                Me.txt_num4.Text = lbl_contrato.Text + "D"
                ' Vetores Auxiliares
                NumCarne(0) = txt_num1.Text : VlrCarne(0) = txt_valor1.Text : Vencto(0) = msk_vencto1.Text
                NumCarne(1) = txt_num2.Text : VlrCarne(1) = txt_valor2.Text : Vencto(1) = msk_vencto2.Text
                NumCarne(2) = txt_num3.Text : VlrCarne(2) = txt_valor3.Text : Vencto(2) = msk_vencto3.Text
                NumCarne(3) = txt_num4.Text : VlrCarne(3) = txt_valor4.Text : Vencto(3) = msk_vencto4.Text
            Case 5
                Me.txt_valor1.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor2.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor3.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor4.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor5.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")
                ' Vencimentos
                Me.msk_vencto1.Text = Data_fixa(Mdata, Now.Day) : Me.msk_vencto2.Text = Data_fixa(Mdata.AddDays(Mdias), (Now.Day)) : Me.msk_vencto3.Text = Data_fixa(Mdata.AddDays(Mdias + 30), (Now.Day))
                Me.msk_vencto4.Text = Data_fixa(Mdata.AddDays(Mdias + 60), (Now.Day)) : Me.msk_vencto5.Text = Data_fixa(Mdata.AddDays(Mdias + 90), (Now.Day))
                ' Numero do carne
                Me.txt_num1.Text = lbl_contrato.Text + "A" : Me.txt_num2.Text = lbl_contrato.Text + "B" : Me.txt_num3.Text = lbl_contrato.Text + "C"
                Me.txt_num4.Text = lbl_contrato.Text + "D" : Me.txt_num5.Text = lbl_contrato.Text + "E"
                ' Vetores Auxiliares
                NumCarne(0) = txt_num1.Text : VlrCarne(0) = txt_valor1.Text : Vencto(0) = msk_vencto1.Text
                NumCarne(1) = txt_num2.Text : VlrCarne(1) = txt_valor2.Text : Vencto(1) = msk_vencto2.Text
                NumCarne(2) = txt_num3.Text : VlrCarne(2) = txt_valor3.Text : Vencto(2) = msk_vencto3.Text
                NumCarne(3) = txt_num4.Text : VlrCarne(3) = txt_valor4.Text : Vencto(3) = msk_vencto4.Text
                NumCarne(4) = txt_num5.Text : VlrCarne(4) = txt_valor5.Text : Vencto(4) = msk_vencto5.Text
            Case 6
                Me.txt_valor1.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor2.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor3.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor4.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor5.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor6.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")
                ' Vencimentos
                Me.msk_vencto1.Text = Data_fixa(Mdata, Now.Day) : Me.msk_vencto2.Text = Data_fixa(Mdata.AddDays(Mdias), (Now.Day)) : Me.msk_vencto3.Text = Data_fixa(Mdata.AddDays(Mdias + 30), (Now.Day))
                Me.msk_vencto4.Text = Data_fixa(Mdata.AddDays(Mdias + 60), (Now.Day)) : Me.msk_vencto5.Text = Data_fixa(Mdata.AddDays(Mdias + 90), (Now.Day))
                Me.msk_vencto6.Text = Data_fixa(Mdata.AddDays(Mdias + 120), (Now.Day))
                ' Numero do carne
                Me.txt_num1.Text = lbl_contrato.Text + "A" : Me.txt_num2.Text = lbl_contrato.Text + "B" : Me.txt_num3.Text = lbl_contrato.Text + "C"
                Me.txt_num4.Text = lbl_contrato.Text + "D" : Me.txt_num5.Text = lbl_contrato.Text + "E" : Me.txt_num6.Text = lbl_contrato.Text + "F"
                ' Vetores Auxiliares
                NumCarne(0) = txt_num1.Text : VlrCarne(0) = txt_valor1.Text : Vencto(0) = msk_vencto1.Text
                NumCarne(1) = txt_num2.Text : VlrCarne(1) = txt_valor2.Text : Vencto(1) = msk_vencto2.Text
                NumCarne(2) = txt_num3.Text : VlrCarne(2) = txt_valor3.Text : Vencto(2) = msk_vencto3.Text
                NumCarne(3) = txt_num4.Text : VlrCarne(3) = txt_valor4.Text : Vencto(3) = msk_vencto4.Text
                NumCarne(4) = txt_num5.Text : VlrCarne(4) = txt_valor5.Text : Vencto(4) = msk_vencto5.Text
                NumCarne(5) = txt_num6.Text : VlrCarne(5) = txt_valor6.Text : Vencto(5) = msk_vencto6.Text

            Case 7
                Me.txt_valor1.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor2.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor3.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor4.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor5.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor6.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor7.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")
                '
                ' Vencimentos
                Me.msk_vencto1.Text = Data_fixa(Mdata, Now.Day) : Me.msk_vencto2.Text = Data_fixa(Mdata.AddDays(Mdias), (Now.Day)) : Me.msk_vencto3.Text = Data_fixa(Mdata.AddDays(Mdias + 30), (Now.Day))
                Me.msk_vencto4.Text = Data_fixa(Mdata.AddDays(Mdias + 60), (Now.Day)) : Me.msk_vencto5.Text = Data_fixa(Mdata.AddDays(Mdias + 90), (Now.Day))
                Me.msk_vencto6.Text = Data_fixa(Mdata.AddDays(Mdias + 120), (Now.Day)) : Me.msk_vencto7.Text = Data_fixa(Mdata.AddDays(Mdias + 150), (Now.Day))
                ' Numero do carne
                Me.txt_num1.Text = lbl_contrato.Text + "A" : Me.txt_num2.Text = lbl_contrato.Text + "B" : Me.txt_num3.Text = lbl_contrato.Text + "C"
                Me.txt_num4.Text = lbl_contrato.Text + "D" : Me.txt_num5.Text = lbl_contrato.Text + "E" : Me.txt_num6.Text = lbl_contrato.Text + "F"
                Me.txt_num7.Text = lbl_contrato.Text + "G"
                ' Vetores Auxiliares
                NumCarne(0) = txt_num1.Text : VlrCarne(0) = txt_valor1.Text : Vencto(0) = msk_vencto1.Text
                NumCarne(1) = txt_num2.Text : VlrCarne(1) = txt_valor2.Text : Vencto(1) = msk_vencto2.Text
                NumCarne(2) = txt_num3.Text : VlrCarne(2) = txt_valor3.Text : Vencto(2) = msk_vencto3.Text
                NumCarne(3) = txt_num4.Text : VlrCarne(3) = txt_valor4.Text : Vencto(3) = msk_vencto4.Text
                NumCarne(4) = txt_num5.Text : VlrCarne(4) = txt_valor5.Text : Vencto(4) = msk_vencto5.Text
                NumCarne(5) = txt_num6.Text : VlrCarne(5) = txt_valor6.Text : Vencto(5) = msk_vencto6.Text
                NumCarne(6) = txt_num7.Text : VlrCarne(6) = txt_valor7.Text : Vencto(6) = msk_vencto7.Text
            Case 8
                Me.txt_valor1.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor2.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor3.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor4.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor5.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor6.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor7.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor8.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")
                '
                ' Vencimentos
                Me.msk_vencto1.Text = Data_fixa(Mdata, Now.Day) : Me.msk_vencto2.Text = Data_fixa(Mdata.AddDays(Mdias), (Now.Day)) : Me.msk_vencto3.Text = Data_fixa(Mdata.AddDays(Mdias + 30), (Now.Day))
                Me.msk_vencto4.Text = Data_fixa(Mdata.AddDays(Mdias + 60), (Now.Day)) : Me.msk_vencto5.Text = Data_fixa(Mdata.AddDays(Mdias + 90), (Now.Day))
                Me.msk_vencto6.Text = Data_fixa(Mdata.AddDays(Mdias + 120), (Now.Day)) : Me.msk_vencto7.Text = Data_fixa(Mdata.AddDays(Mdias + 150), (Now.Day))
                Me.msk_vencto8.Text = Data_fixa(Mdata.AddDays(Mdias + 180), (Now.Day))
                ' Numero do carne
                Me.txt_num1.Text = lbl_contrato.Text + "A" : Me.txt_num2.Text = lbl_contrato.Text + "B" : Me.txt_num3.Text = lbl_contrato.Text + "C"
                Me.txt_num4.Text = lbl_contrato.Text + "D" : Me.txt_num5.Text = lbl_contrato.Text + "E" : Me.txt_num6.Text = lbl_contrato.Text + "F"
                Me.txt_num7.Text = lbl_contrato.Text + "G" : Me.txt_num8.Text = lbl_contrato.Text + "H"
                ' Vetores Auxiliares
                NumCarne(0) = txt_num1.Text : VlrCarne(0) = txt_valor1.Text : Vencto(0) = msk_vencto1.Text
                NumCarne(1) = txt_num2.Text : VlrCarne(1) = txt_valor2.Text : Vencto(1) = msk_vencto2.Text
                NumCarne(2) = txt_num3.Text : VlrCarne(2) = txt_valor3.Text : Vencto(2) = msk_vencto3.Text
                NumCarne(3) = txt_num4.Text : VlrCarne(3) = txt_valor4.Text : Vencto(3) = msk_vencto4.Text
                NumCarne(4) = txt_num5.Text : VlrCarne(4) = txt_valor5.Text : Vencto(4) = msk_vencto5.Text
                NumCarne(5) = txt_num6.Text : VlrCarne(5) = txt_valor6.Text : Vencto(5) = msk_vencto6.Text
                NumCarne(6) = txt_num7.Text : VlrCarne(6) = txt_valor7.Text : Vencto(6) = msk_vencto7.Text
                NumCarne(7) = txt_num8.Text : VlrCarne(7) = txt_valor8.Text : Vencto(7) = msk_vencto8.Text

            Case 9
                Me.txt_valor1.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor2.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor3.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor4.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor5.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor6.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor7.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor8.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor9.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")
                '
                ' Vencimentos
                Me.msk_vencto1.Text = Data_fixa(Mdata, Now.Day) : Me.msk_vencto2.Text = Data_fixa(Mdata.AddDays(Mdias), (Now.Day)) : Me.msk_vencto3.Text = Data_fixa(Mdata.AddDays(Mdias + 30), (Now.Day))
                Me.msk_vencto4.Text = Data_fixa(Mdata.AddDays(Mdias + 60), (Now.Day)) : Me.msk_vencto5.Text = Data_fixa(Mdata.AddDays(Mdias + 90), (Now.Day))
                Me.msk_vencto6.Text = Data_fixa(Mdata.AddDays(Mdias + 120), (Now.Day)) : Me.msk_vencto7.Text = Data_fixa(Mdata.AddDays(Mdias + 150), (Now.Day))
                Me.msk_vencto8.Text = Data_fixa(Mdata.AddDays(Mdias + 180), (Now.Day)) : Me.msk_vencto9.Text = Data_fixa(Mdata.AddDays(Mdias + 210), (Now.Day))
                ' Numero do carne
                Me.txt_num1.Text = lbl_contrato.Text + "A" : Me.txt_num2.Text = lbl_contrato.Text + "B" : Me.txt_num3.Text = lbl_contrato.Text + "C"
                Me.txt_num4.Text = lbl_contrato.Text + "D" : Me.txt_num5.Text = lbl_contrato.Text + "E" : Me.txt_num6.Text = lbl_contrato.Text + "F"
                Me.txt_num7.Text = lbl_contrato.Text + "G" : Me.txt_num8.Text = lbl_contrato.Text + "H" : Me.txt_num9.Text = lbl_contrato.Text + "I"
                ' Vetores Auxiliares
                NumCarne(0) = txt_num1.Text : VlrCarne(0) = txt_valor1.Text : Vencto(0) = msk_vencto1.Text
                NumCarne(1) = txt_num2.Text : VlrCarne(1) = txt_valor2.Text : Vencto(1) = msk_vencto2.Text
                NumCarne(2) = txt_num3.Text : VlrCarne(2) = txt_valor3.Text : Vencto(2) = msk_vencto3.Text
                NumCarne(3) = txt_num4.Text : VlrCarne(3) = txt_valor4.Text : Vencto(3) = msk_vencto4.Text
                NumCarne(4) = txt_num5.Text : VlrCarne(4) = txt_valor5.Text : Vencto(4) = msk_vencto5.Text
                NumCarne(5) = txt_num6.Text : VlrCarne(5) = txt_valor6.Text : Vencto(5) = msk_vencto6.Text
                NumCarne(6) = txt_num7.Text : VlrCarne(6) = txt_valor7.Text : Vencto(6) = msk_vencto7.Text
                NumCarne(7) = txt_num8.Text : VlrCarne(7) = txt_valor8.Text : Vencto(7) = msk_vencto8.Text
                NumCarne(8) = txt_num9.Text : VlrCarne(8) = txt_valor9.Text : Vencto(8) = msk_vencto9.Text
            Case 10
                Me.txt_valor1.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor2.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor3.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor4.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor5.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor6.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor7.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor8.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor9.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor10.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")
                '
                ' Vencimentos
                Me.msk_vencto1.Text = Data_fixa(Mdata, Now.Day) : Me.msk_vencto2.Text = Data_fixa(Mdata.AddDays(Mdias), (Now.Day)) : Me.msk_vencto3.Text = Data_fixa(Mdata.AddDays(Mdias + 30), (Now.Day))
                Me.msk_vencto4.Text = Data_fixa(Mdata.AddDays(Mdias + 60), (Now.Day)) : Me.msk_vencto5.Text = Data_fixa(Mdata.AddDays(Mdias + 90), (Now.Day))
                Me.msk_vencto6.Text = Data_fixa(Mdata.AddDays(Mdias + 120), (Now.Day)) : Me.msk_vencto7.Text = Data_fixa(Mdata.AddDays(Mdias + 150), (Now.Day))
                Me.msk_vencto8.Text = Data_fixa(Mdata.AddDays(Mdias + 180), (Now.Day)) : Me.msk_vencto9.Text = Data_fixa(Mdata.AddDays(Mdias + 210), (Now.Day))
                Me.msk_vencto10.Text = Data_fixa(Mdata.AddDays(Mdias + 240), (Now.Day))
                ' Numero do carne
                Me.txt_num1.Text = lbl_contrato.Text + "A" : Me.txt_num2.Text = lbl_contrato.Text + "B" : Me.txt_num3.Text = lbl_contrato.Text + "C"
                Me.txt_num4.Text = lbl_contrato.Text + "D" : Me.txt_num5.Text = lbl_contrato.Text + "E" : Me.txt_num6.Text = lbl_contrato.Text + "F"
                Me.txt_num7.Text = lbl_contrato.Text + "G" : Me.txt_num8.Text = lbl_contrato.Text + "H" : Me.txt_num9.Text = lbl_contrato.Text + "I"
                Me.txt_num10.Text = lbl_contrato.Text + "J"
                ' Vetores Auxiliares
                NumCarne(0) = txt_num1.Text : VlrCarne(0) = txt_valor1.Text : Vencto(0) = msk_vencto1.Text
                NumCarne(1) = txt_num2.Text : VlrCarne(1) = txt_valor2.Text : Vencto(1) = msk_vencto2.Text
                NumCarne(2) = txt_num3.Text : VlrCarne(2) = txt_valor3.Text : Vencto(2) = msk_vencto3.Text
                NumCarne(3) = txt_num4.Text : VlrCarne(3) = txt_valor4.Text : Vencto(3) = msk_vencto4.Text
                NumCarne(4) = txt_num5.Text : VlrCarne(4) = txt_valor5.Text : Vencto(4) = msk_vencto5.Text
                NumCarne(5) = txt_num6.Text : VlrCarne(5) = txt_valor6.Text : Vencto(5) = msk_vencto6.Text
                NumCarne(6) = txt_num7.Text : VlrCarne(6) = txt_valor7.Text : Vencto(6) = msk_vencto7.Text
                NumCarne(7) = txt_num8.Text : VlrCarne(7) = txt_valor8.Text : Vencto(7) = msk_vencto8.Text
                NumCarne(8) = txt_num9.Text : VlrCarne(8) = txt_valor9.Text : Vencto(8) = msk_vencto9.Text
                NumCarne(9) = txt_num10.Text : VlrCarne(9) = txt_valor10.Text : Vencto(9) = msk_vencto10.Text
            Case 11
                Recebe_Parcela_ate_10(ValorParc)
                Recebe_NumeroCarne_ate_10()
                Me.txt_valor11.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")

                'Vencimentos
                Recebe_vencto_ate_10()
                Me.msk_vencto11.Text = Data_fixa(Mdata.AddDays(Mdias + 270), (Now.Day))
                ' Numero do carne
                Me.txt_num11.Text = lbl_contrato.Text + "K"
                ' Vetores Auxiliares
                Recebe_vetoresAuxilia_ate_10()
                NumCarne(10) = txt_num11.Text : VlrCarne(10) = txt_valor11.Text : Vencto(10) = msk_vencto11.Text
            Case 12
                Recebe_Parcela_ate_10(ValorParc)
                Me.txt_valor11.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor12.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")

                'Vencimentos
                Recebe_vencto_ate_10()
                Me.msk_vencto11.Text = Data_fixa(Mdata.AddDays(Mdias + 270), (Now.Day)) : Me.msk_vencto12.Text = Data_fixa(Mdata.AddDays(Mdias + 300), (Now.Day))
                ' Numero do carne
                Recebe_NumeroCarne_ate_10()
                Me.txt_num11.Text = lbl_contrato.Text + "K" : Me.txt_num12.Text = lbl_contrato.Text + "L"
                ' Vetores Auxiliares
                Recebe_vetoresAuxilia_ate_10()
                NumCarne(10) = txt_num11.Text : VlrCarne(10) = txt_valor11.Text : Vencto(10) = msk_vencto11.Text
                NumCarne(11) = txt_num12.Text : VlrCarne(11) = txt_valor12.Text : Vencto(11) = msk_vencto12.Text
            Case 13
                Recebe_Parcela_ate_10(ValorParc)
                Me.txt_valor11.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor12.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor13.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")

                'Vencimentos
                Recebe_vencto_ate_10()
                Me.msk_vencto11.Text = Data_fixa(Mdata.AddDays(Mdias + 270), (Now.Day)) : Me.msk_vencto12.Text = Data_fixa(Mdata.AddDays(Mdias + 300), (Now.Day))
                Me.msk_vencto13.Text = Data_fixa(Mdata.AddDays(Mdias + 330), (Now.Day))
                ' Numero do carne
                Recebe_NumeroCarne_ate_10()
                Me.txt_num11.Text = lbl_contrato.Text + "K" : Me.txt_num12.Text = lbl_contrato.Text + "L" : Me.txt_num13.Text = lbl_contrato.Text + "M"
                ' Vetores Auxiliares
                Recebe_vetoresAuxilia_ate_10()
                NumCarne(10) = txt_num11.Text : VlrCarne(10) = txt_valor11.Text : Vencto(10) = msk_vencto11.Text
                NumCarne(11) = txt_num12.Text : VlrCarne(11) = txt_valor12.Text : Vencto(11) = msk_vencto12.Text
                NumCarne(12) = txt_num13.Text : VlrCarne(12) = txt_valor13.Text : Vencto(12) = msk_vencto13.Text
            Case 14

                Recebe_Parcela_ate_10(ValorParc)
                Me.txt_valor11.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor12.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor13.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor14.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")

                'Vencimentos
                Recebe_vencto_ate_10()
                Me.msk_vencto11.Text = Data_fixa(Mdata.AddDays(Mdias + 270), (Now.Day)) : Me.msk_vencto12.Text = Data_fixa(Mdata.AddDays(Mdias + 300), (Now.Day))
                Me.msk_vencto13.Text = Data_fixa(Mdata.AddDays(Mdias + 330), (Now.Day)) : Me.msk_vencto14.Text = Data_fixa(Mdata.AddDays(Mdias + 360), (Now.Day))
                ' Numero do carne
                Recebe_NumeroCarne_ate_10()
                Me.txt_num11.Text = lbl_contrato.Text + "K" : Me.txt_num12.Text = lbl_contrato.Text + "L" : Me.txt_num13.Text = lbl_contrato.Text + "M"
                Me.txt_num14.Text = lbl_contrato.Text + "N"
                ' Vetores Auxiliares
                Recebe_vetoresAuxilia_ate_10()
                NumCarne(10) = txt_num11.Text : VlrCarne(10) = txt_valor11.Text : Vencto(10) = msk_vencto11.Text
                NumCarne(11) = txt_num12.Text : VlrCarne(11) = txt_valor12.Text : Vencto(11) = msk_vencto12.Text
                NumCarne(12) = txt_num13.Text : VlrCarne(12) = txt_valor13.Text : Vencto(12) = msk_vencto13.Text
                NumCarne(13) = txt_num14.Text : VlrCarne(13) = txt_valor14.Text : Vencto(13) = msk_vencto14.Text
            Case 15
                Recebe_Parcela_ate_10(ValorParc)
                Me.txt_valor11.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor12.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor13.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor14.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor15.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")

                'Vencimentos
                Recebe_vencto_ate_10()
                Me.msk_vencto11.Text = Data_fixa(Mdata.AddDays(Mdias + 270), (Now.Day)) : Me.msk_vencto12.Text = Data_fixa(Mdata.AddDays(Mdias + 300), (Now.Day))
                Me.msk_vencto13.Text = Data_fixa(Mdata.AddDays(Mdias + 330), (Now.Day)) : Me.msk_vencto14.Text = Data_fixa(Mdata.AddDays(Mdias + 360), (Now.Day))
                Me.msk_vencto15.Text = Data_fixa(Mdata.AddDays(Mdias + 390), (Now.Day))
                ' Numero do carne
                Recebe_NumeroCarne_ate_10()
                Me.txt_num11.Text = lbl_contrato.Text + "K" : Me.txt_num12.Text = lbl_contrato.Text + "L" : Me.txt_num13.Text = lbl_contrato.Text + "M"
                Me.txt_num14.Text = lbl_contrato.Text + "N" : Me.txt_num15.Text = lbl_contrato.Text + "O"
                ' Vetores Auxiliares
                Recebe_vetoresAuxilia_ate_10()
                NumCarne(10) = txt_num11.Text : VlrCarne(10) = txt_valor11.Text : Vencto(10) = msk_vencto11.Text
                NumCarne(11) = txt_num12.Text : VlrCarne(11) = txt_valor12.Text : Vencto(11) = msk_vencto12.Text
                NumCarne(12) = txt_num13.Text : VlrCarne(12) = txt_valor13.Text : Vencto(12) = msk_vencto13.Text
                NumCarne(13) = txt_num14.Text : VlrCarne(13) = txt_valor14.Text : Vencto(13) = msk_vencto14.Text
                NumCarne(14) = txt_num15.Text : VlrCarne(14) = txt_valor15.Text : Vencto(14) = msk_vencto15.Text
            Case 16
                Recebe_Parcela_ate_10(ValorParc)
                Me.txt_valor11.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor12.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor13.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor14.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor15.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor16.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")

                'Vencimentos
                Recebe_vencto_ate_10()
                Me.msk_vencto11.Text = Data_fixa(Mdata.AddDays(Mdias + 270), (Now.Day)) : Me.msk_vencto12.Text = Data_fixa(Mdata.AddDays(Mdias + 300), (Now.Day))
                Me.msk_vencto13.Text = Data_fixa(Mdata.AddDays(Mdias + 330), (Now.Day)) : Me.msk_vencto14.Text = Data_fixa(Mdata.AddDays(Mdias + 360), (Now.Day))
                Me.msk_vencto15.Text = Data_fixa(Mdata.AddDays(Mdias + 390), (Now.Day)) : Me.msk_vencto16.Text = Data_fixa(Mdata.AddDays(Mdias + 410), (Now.Day))
                ' Numero do carne
                Recebe_NumeroCarne_ate_10()
                Me.txt_num11.Text = lbl_contrato.Text + "K" : Me.txt_num12.Text = lbl_contrato.Text + "L" : Me.txt_num13.Text = lbl_contrato.Text + "M"
                Me.txt_num14.Text = lbl_contrato.Text + "N" : Me.txt_num15.Text = lbl_contrato.Text + "O" : Me.txt_num16.Text = lbl_contrato.Text + "P"
                ' Vetores Auxiliares
                Recebe_VetoresAuxiliar_ate_15()
                NumCarne(15) = txt_num16.Text : VlrCarne(15) = txt_valor16.Text : Vencto(15) = msk_vencto16.Text
            Case 17
                Recebe_Parcela_ate_10(ValorParc)
                Me.txt_valor11.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor12.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor13.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor14.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor15.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor16.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor17.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")

                'Vencimentos
                Recebe_vencto_ate_10()
                Me.msk_vencto11.Text = Data_fixa(Mdata.AddDays(Mdias + 270), (Now.Day)) : Me.msk_vencto12.Text = Data_fixa(Mdata.AddDays(Mdias + 300), (Now.Day))
                Me.msk_vencto13.Text = Data_fixa(Mdata.AddDays(Mdias + 330), (Now.Day)) : Me.msk_vencto14.Text = Data_fixa(Mdata.AddDays(Mdias + 360), (Now.Day))
                Me.msk_vencto15.Text = Data_fixa(Mdata.AddDays(Mdias + 390), (Now.Day)) : Me.msk_vencto16.Text = Data_fixa(Mdata.AddDays(Mdias + 410), (Now.Day))
                Me.msk_vencto17.Text = Data_fixa(Mdata.AddDays(Mdias + 440), (Now.Day))
                ' Numero do carne
                Recebe_NumeroCarne_ate_10()
                Me.txt_num11.Text = lbl_contrato.Text + "K" : Me.txt_num12.Text = lbl_contrato.Text + "L" : Me.txt_num13.Text = lbl_contrato.Text + "M"
                Me.txt_num14.Text = lbl_contrato.Text + "N" : Me.txt_num15.Text = lbl_contrato.Text + "O" : Me.txt_num16.Text = lbl_contrato.Text + "P"
                Me.txt_num17.Text = lbl_contrato.Text + "Q"
                ' Vetores Auxiliares
                Recebe_VetoresAuxiliar_ate_15()
                NumCarne(15) = txt_num16.Text : VlrCarne(15) = txt_valor16.Text : Vencto(15) = msk_vencto16.Text
                NumCarne(16) = txt_num17.Text : VlrCarne(16) = txt_valor17.Text : Vencto(16) = msk_vencto17.Text
            Case 18
                Recebe_Parcela_ate_10(ValorParc)
                Me.txt_valor11.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor12.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor13.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor14.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor15.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor16.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor17.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor18.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")

                'Vencimentos
                Recebe_vencto_ate_10()
                Me.msk_vencto11.Text = Data_fixa(Mdata.AddDays(Mdias + 270), (Now.Day)) : Me.msk_vencto12.Text = Data_fixa(Mdata.AddDays(Mdias + 300), (Now.Day))
                Me.msk_vencto13.Text = Data_fixa(Mdata.AddDays(Mdias + 330), (Now.Day)) : Me.msk_vencto14.Text = Data_fixa(Mdata.AddDays(Mdias + 360), (Now.Day))
                Me.msk_vencto15.Text = Data_fixa(Mdata.AddDays(Mdias + 390), (Now.Day)) : Me.msk_vencto16.Text = Data_fixa(Mdata.AddDays(Mdias + 410), (Now.Day))
                Me.msk_vencto17.Text = Data_fixa(Mdata.AddDays(Mdias + 440), (Now.Day)) : Me.msk_vencto18.Text = Data_fixa(Mdata.AddDays(Mdias + 470), (Now.Day))
                ' Numero do carne
                Recebe_NumeroCarne_ate_10()
                Me.txt_num11.Text = lbl_contrato.Text + "K" : Me.txt_num12.Text = lbl_contrato.Text + "L" : Me.txt_num13.Text = lbl_contrato.Text + "M"
                Me.txt_num14.Text = lbl_contrato.Text + "N" : Me.txt_num15.Text = lbl_contrato.Text + "O" : Me.txt_num16.Text = lbl_contrato.Text + "P"
                Me.txt_num17.Text = lbl_contrato.Text + "Q" : Me.txt_num18.Text = lbl_contrato.Text + "R"
                ' Vetores Auxiliares
                Recebe_VetoresAuxiliar_ate_15()
                NumCarne(15) = txt_num16.Text : VlrCarne(15) = txt_valor16.Text : Vencto(15) = msk_vencto16.Text
                NumCarne(16) = txt_num17.Text : VlrCarne(16) = txt_valor17.Text : Vencto(16) = msk_vencto17.Text
                NumCarne(17) = txt_num18.Text : VlrCarne(17) = txt_valor18.Text : Vencto(17) = msk_vencto18.Text
            Case 19
                Recebe_Parcela_ate_10(ValorParc)
                Me.txt_valor11.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor12.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor13.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor14.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor15.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor16.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor17.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor18.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor19.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")
                'Vencimentos
                Recebe_vencto_ate_10()
                Me.msk_vencto11.Text = Data_fixa(Mdata.AddDays(Mdias + 270), (Now.Day)) : Me.msk_vencto12.Text = Data_fixa(Mdata.AddDays(Mdias + 300), (Now.Day))
                Me.msk_vencto13.Text = Data_fixa(Mdata.AddDays(Mdias + 330), (Now.Day)) : Me.msk_vencto14.Text = Data_fixa(Mdata.AddDays(Mdias + 360), (Now.Day))
                Me.msk_vencto15.Text = Data_fixa(Mdata.AddDays(Mdias + 390), (Now.Day)) : Me.msk_vencto16.Text = Data_fixa(Mdata.AddDays(Mdias + 410), (Now.Day))
                Me.msk_vencto17.Text = Data_fixa(Mdata.AddDays(Mdias + 440), (Now.Day)) : Me.msk_vencto18.Text = Data_fixa(Mdata.AddDays(Mdias + 470), (Now.Day))
                Me.msk_vencto19.Text = Data_fixa(Mdata.AddDays(Mdias + 500), (Now.Day))
                ' Numero do carne
                Recebe_NumeroCarne_ate_10()
                Me.txt_num11.Text = lbl_contrato.Text + "K" : Me.txt_num12.Text = lbl_contrato.Text + "L" : Me.txt_num13.Text = lbl_contrato.Text + "M"
                Me.txt_num14.Text = lbl_contrato.Text + "N" : Me.txt_num15.Text = lbl_contrato.Text + "O" : Me.txt_num16.Text = lbl_contrato.Text + "P"
                Me.txt_num17.Text = lbl_contrato.Text + "Q" : Me.txt_num18.Text = lbl_contrato.Text + "R" : Me.txt_num19.Text = lbl_contrato.Text + "S"
                ' Vetores Auxiliares
                Recebe_VetoresAuxiliar_ate_15()
                NumCarne(15) = txt_num16.Text : VlrCarne(15) = txt_valor16.Text : Vencto(15) = msk_vencto16.Text
                NumCarne(16) = txt_num17.Text : VlrCarne(16) = txt_valor17.Text : Vencto(16) = msk_vencto17.Text
                NumCarne(17) = txt_num18.Text : VlrCarne(17) = txt_valor18.Text : Vencto(17) = msk_vencto18.Text
                NumCarne(18) = txt_num19.Text : VlrCarne(18) = txt_valor19.Text : Vencto(18) = msk_vencto19.Text
            Case 20
                Recebe_Parcela_ate_10(ValorParc)
                Me.txt_valor11.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor12.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor13.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor14.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor15.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor16.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor17.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor18.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
                Me.txt_valor19.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor20.Text = Format(Convert.ToDouble(ValorUltima), "##,##0.00")

                'Vencimentos
                Recebe_vencto_ate_10()
                Me.msk_vencto11.Text = Data_fixa(Mdata.AddDays(Mdias + 270), (Now.Day)) : Me.msk_vencto12.Text = Data_fixa(Mdata.AddDays(Mdias + 300), (Now.Day))
                Me.msk_vencto13.Text = Data_fixa(Mdata.AddDays(Mdias + 330), (Now.Day)) : Me.msk_vencto14.Text = Data_fixa(Mdata.AddDays(Mdias + 360), (Now.Day))
                Me.msk_vencto15.Text = Data_fixa(Mdata.AddDays(Mdias + 390), (Now.Day)) : Me.msk_vencto16.Text = Data_fixa(Mdata.AddDays(Mdias + 410), (Now.Day))
                Me.msk_vencto17.Text = Data_fixa(Mdata.AddDays(Mdias + 440), (Now.Day)) : Me.msk_vencto18.Text = Data_fixa(Mdata.AddDays(Mdias + 470), (Now.Day))
                Me.msk_vencto19.Text = Data_fixa(Mdata.AddDays(Mdias + 500), (Now.Day)) : Me.msk_vencto20.Text = Data_fixa(Mdata.AddDays(Mdias + 530), (Now.Day))
                ' Numero do carne
                Recebe_NumeroCarne_ate_10()
                Me.txt_num11.Text = lbl_contrato.Text + "K" : Me.txt_num12.Text = lbl_contrato.Text + "L" : Me.txt_num13.Text = lbl_contrato.Text + "M"
                Me.txt_num14.Text = lbl_contrato.Text + "N" : Me.txt_num15.Text = lbl_contrato.Text + "O" : Me.txt_num16.Text = lbl_contrato.Text + "P"
                Me.txt_num17.Text = lbl_contrato.Text + "Q" : Me.txt_num18.Text = lbl_contrato.Text + "R" : Me.txt_num19.Text = lbl_contrato.Text + "S"
                Me.txt_num20.Text = lbl_contrato.Text + "T"
                ' Vetores Auxiliares
                Recebe_VetoresAuxiliar_ate_15()
                NumCarne(15) = txt_num16.Text : VlrCarne(15) = txt_valor16.Text : Vencto(15) = msk_vencto16.Text
                NumCarne(16) = txt_num17.Text : VlrCarne(16) = txt_valor17.Text : Vencto(16) = msk_vencto17.Text
                NumCarne(17) = txt_num18.Text : VlrCarne(17) = txt_valor18.Text : Vencto(17) = msk_vencto18.Text
                NumCarne(18) = txt_num19.Text : VlrCarne(18) = txt_valor19.Text : Vencto(18) = msk_vencto19.Text
                NumCarne(19) = txt_num20.Text : VlrCarne(19) = txt_valor20.Text : Vencto(19) = msk_vencto20.Text
        End Select
    End Sub

    Private Sub Recebe_Parcela_ate_10(ByVal ValorParc As Double)
        ValorParc = Format(Convert.ToDouble(ValorParc), "##,##0.00")
        Me.txt_valor1.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor2.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor3.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
        Me.txt_valor4.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor5.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor6.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
        Me.txt_valor7.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor8.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00") : Me.txt_valor9.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
        Me.txt_valor10.Text = Format(Convert.ToDouble(ValorParc), "##,##0.00")
    End Sub

    Private Sub Recebe_vencto_ate_10()
        Me.msk_vencto1.Text = Data_fixa(Mdata, Now.Day) : Me.msk_vencto2.Text = Data_fixa(Mdata.AddDays(Mdias), (Now.Day)) : Me.msk_vencto3.Text = Data_fixa(Mdata.AddDays(Mdias + 30), (Now.Day))
        Me.msk_vencto4.Text = Data_fixa(Mdata.AddDays(Mdias + 60), (Now.Day)) : Me.msk_vencto5.Text = Data_fixa(Mdata.AddDays(Mdias + 90), (Now.Day))
        Me.msk_vencto6.Text = Data_fixa(Mdata.AddDays(Mdias + 120), (Now.Day)) : Me.msk_vencto7.Text = Data_fixa(Mdata.AddDays(Mdias + 150), (Now.Day))
        Me.msk_vencto8.Text = Data_fixa(Mdata.AddDays(Mdias + 180), (Now.Day)) : Me.msk_vencto9.Text = Data_fixa(Mdata.AddDays(Mdias + 210), (Now.Day))
        Me.msk_vencto10.Text = Data_fixa(Mdata.AddDays(Mdias + 240), (Now.Day))

    End Sub

    Private Sub Recebe_NumeroCarne_ate_10()
        Me.txt_num1.Text = lbl_contrato.Text + "A" : Me.txt_num2.Text = lbl_contrato.Text + "B" : Me.txt_num3.Text = lbl_contrato.Text + "C"
        Me.txt_num4.Text = lbl_contrato.Text + "D" : Me.txt_num5.Text = lbl_contrato.Text + "E" : Me.txt_num6.Text = lbl_contrato.Text + "F"
        Me.txt_num7.Text = lbl_contrato.Text + "G" : Me.txt_num8.Text = lbl_contrato.Text + "H" : Me.txt_num9.Text = lbl_contrato.Text + "I"
        Me.txt_num10.Text = lbl_contrato.Text + "J"
    End Sub

    Private Sub limpa_Parcelas()
        Me.txt_valor1.Text = "" : Me.txt_valor2.Text = "" : Me.txt_valor3.Text = ""
        Me.txt_valor4.Text = "" : Me.txt_valor5.Text = "" : Me.txt_valor6.Text = ""
        Me.txt_valor7.Text = "" : Me.txt_valor8.Text = "" : Me.txt_valor9.Text = "" : Me.txt_valor10.Text = ""

        Me.txt_valor11.Text = "" : Me.txt_valor12.Text = ""
        Me.txt_valor13.Text = "" : Me.txt_valor14.Text = "" : Me.txt_valor15.Text = ""
        Me.txt_valor16.Text = "" : Me.txt_valor17.Text = "" : Me.txt_valor18.Text = ""
        Me.txt_valor19.Text = "" : Me.txt_valor20.Text = ""

    End Sub

    Private Sub Limpa_vencimentos()
        Me.msk_vencto1.Text = "" : Me.msk_vencto2.Text = "" : Me.msk_vencto3.Text = "" : Me.msk_vencto4.Text = ""
        Me.msk_vencto5.Text = "" : Me.msk_vencto6.Text = "" : Me.msk_vencto7.Text = "" : Me.msk_vencto8.Text = ""
        Me.msk_vencto9.Text = "" : Me.msk_vencto10.Text = ""

        Me.msk_vencto11.Text = "" : Me.msk_vencto12.Text = "" : Me.msk_vencto13.Text = "" : Me.msk_vencto14.Text = ""
        Me.msk_vencto15.Text = "" : Me.msk_vencto16.Text = "" : Me.msk_vencto17.Text = "" : Me.msk_vencto18.Text = ""
        Me.msk_vencto19.Text = "" : Me.msk_vencto20.Text = ""

    End Sub
    Private Sub Limpa_NumeroCarne()
        Me.txt_num1.Text = "" : Me.txt_num2.Text = "" : Me.txt_num3.Text = ""
        Me.txt_num4.Text = "" : Me.txt_num5.Text = "" : Me.txt_num6.Text = ""
        Me.txt_num7.Text = "" : Me.txt_num8.Text = "" : Me.txt_num9.Text = ""
        Me.txt_num10.Text = ""
        Me.txt_num11.Text = "" : Me.txt_num12.Text = "" : Me.txt_num13.Text = ""
        Me.txt_num14.Text = "" : Me.txt_num15.Text = "" : Me.txt_num16.Text = ""
        Me.txt_num17.Text = "" : Me.txt_num18.Text = "" : Me.txt_num19.Text = ""
        Me.txt_num20.Text = ""

    End Sub
    Private Sub txt_entrada_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_entrada.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(numeros.SoNumerov(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_qtde_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtde.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(numeros.SoNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_qtde_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtde.Leave
        limpa_Parcelas()
        Limpa_vencimentos()
        Limpa_NumeroCarne()
    End Sub
    Private Function Data_fixa(ByVal C_DataVenc As Date, ByVal C_DiaFixo As Integer) As Date
        Dim XDataFixa, XDiaFixo, mDtAux1 As String
        Dim mDiaAdd As Integer = 0
        Try
            XDiaFixo = String.Format("{0:D2}", C_DiaFixo)
            XDataFixa = XDiaFixo + Mid(CStr(C_DataVenc), 3, 8)
            Try
                Return CDate(XDataFixa)
            Catch ex As Exception

                mDtAux1 = Format(DateSerial(C_DataVenc.Year, C_DataVenc.Month + 1, 0), "dd/MM/yyyy")
                mDiaAdd = 1 '(CDate(mDtAux1).Day - XDataFixa.Day)
                C_DataVenc = CDate(mDtAux1).AddDays(mDiaAdd)
                'XDiaFixo = String.Format("{0:D2}", C_DiaFixo)
                'XDataFixa = XDiaFixo + Mid(CStr(C_DataVenc), 3, 8)
                Return CDate(C_DataVenc)

            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            Return CDate(XDataFixa)
        End Try

    End Function

    Private Sub btn_gravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gravar.Click

        Dim x, t As Integer
        ' Variaveis Auxiliar de Totais
        Dim StrValor, StrTGeral As Double
        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            'VlrCarne(0) = CDbl(txt_valor1.Text)
            'VlrCarne(1) = CDbl(txt_valor2.Text)
            '' VlrCarne(2) = CDbl(txt_valor3.Text)

            'For t = 1 To Convert.ToInt16(txt_qtde.Text)
            '    StrValor = StrValor + CDbl(VlrCarne(t - 1))
            'Next

            'StrTGeral = StrValor + CDbl(txt_entrada.Text)
            'If StrTGeral <> CDbl(txt_total.Text) Then
            '    MessageBox.Show("Atenção ! Valor Total de Carne foi Alterado, Favor Corrigir !", " Erro Totais ", MessageBoxButtons.OK, MessageBoxIcon.Question)
            'Else
            For x = 1 To (Convert.ToInt16(txt_qtde.Text))
                Xfuncao.IncCarne_a_Receber(MdlEmpresaUsu._codigo, MCodCli, "CR", lbl_contrato.Text, lbl_contrato.Text, "", 0.0, NumCarne(x - 1), DateValue(MEmissao), _
                      DateValue(Vencto(x - 1)), CDbl(VlrCarne(x - 1)), "00", Now, 0.0, 0.0, "000", "", "", 0.0, 0.0, "", "", "", "N", False, MdlEmpresaUsu._codigo, 0, "", "", _
                      "", "", "", C_CodVendedor, 0.0, 0.0, 0.0, conexao, transacao)
            Next
            Me.lbl_mensagem.Text = "Carnês Incluidos com Sucesso !"
            Me.btn_gravar.Enabled = False
            'End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub btn_imprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprime.Click

        executaEspelhoNF_R("", "\wged\relatorios\carne.txt")

    End Sub


#Region "   * *  Tratamentos para impressão  * *   "

    Private Sub executaEspelhoNF_R(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\relatorios\TEMPcarne.TMP"
        Dim fs As New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)
        Dim s As New StreamWriter(fs)

        Dim mContPaginas As Integer = _valorZERO, mContQuebrasPag As Integer = _valorZERO
        Dim strLinha As String = ""
        Dim dtAtual As String = Format(Date.Now, "dd/MM/yyyy")
        Dim codEstab As String = Mid(MdlUsuarioLogando._local, _
                                     MdlUsuarioLogando._local.Length - 1, 2)


        _PrintFont = New Font("Lucida Console", 7) '126 Quebras de Linha padrao para esta configuração

        'Totais
        Dim lShouldReturn As Boolean
        executaEspelhoNF_RExtracted(arqSaida, mArqTemp, fs, s, mContPaginas, mContQuebrasPag, dtAtual, codEstab, lShouldReturn)
        If lShouldReturn Then Return

        'Ler o Arquivo salvo...
        executaEspelhoNF_RExtracted1(arqSaida, mArqTemp, fs, s)

        MostrarCaixaImpressoras = False
        _StringToPrint = ""



    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdRelatorio.PrintPage
        Dim NumChars As Integer
        Dim NumLines As Integer
        Dim StringforPage As String
        Dim Strformat As New StringFormat

        Dim recdraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, _
                                      e.MarginBounds.Width, e.MarginBounds.Height)

        Dim SizeMeassure As New SizeF(e.MarginBounds.Width, _
                                      e.MarginBounds.Height - _PrintFont.GetHeight(e.Graphics))

        Strformat.Trimming = StringTrimming.Word
        e.Graphics.MeasureString(_StringToPrint, _PrintFont, SizeMeassure, Strformat, NumChars, NumLines)
        StringforPage = _StringToPrint.Substring(_valorZERO, NumChars)

        ' Imprime a string na pagina atual
        e.Graphics.DrawString(StringforPage, _PrintFont, Brushes.Black, recdraw, Strformat)


        'For i As Integer = 1 To mQtdPaginas
        '    e.HasMorePages = True
        'Next

        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then

            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else

            e.HasMorePages = False

        End If

    End Sub

    Private Sub executaEspelhoNF_RExtracted(ByVal arqSaida As String, ByVal mArqTemp As String, ByVal fs As FileStream, ByRef s As StreamWriter, ByVal mContPaginas As Integer, ByVal mContQuebrasPag As Integer, ByVal dtAtual As String, ByVal codEstab As String, ByRef shouldReturn As Boolean)

        shouldReturn = False
        'Totais
        Try
            Dim mConsultaAtual As String = "" 'ConsulFornec() & ConsulEspec() & ConsulPeriodos()
            gravaTotaisNF_R(s, mContPaginas, mConsultaAtual, mContQuebrasPag, codEstab, dtAtual)

        Catch ex As Exception
            MsgBox("Deu erro ao gravar os totais da Nota", MsgBoxStyle.Exclamation)
            shouldReturn = True : Return

        End Try



    End Sub

    Private Sub executaEspelhoNF_RExtracted1(ByVal arqSaida As String, ByVal mArqTemp As String, ByVal fs As FileStream, ByVal s As StreamWriter)

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

    Private Sub gravaTotaisNF_R(ByRef s As StreamWriter, ByRef mContPaginas As Integer, _
                                ByVal ConsultaAtual As String, ByRef mContQuebrasPag As Integer, _
                                ByVal codEstab As String, ByVal dtAtual As String)

        Dim strLinha As String = ""
        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlNF As New StringBuilder
        Dim cmdNF, cmdPrint As NpgsqlCommand
        Dim drNF As NpgsqlDataReader
        Dim numero, dtEntrada, cfop, uf, fornecedor As String
        Dim bcIcms, icms, IPI, bcSubs, totNota As Decimal
        Dim somaBcIcms, somaIcms, somaIPI, somaBcSubs, somaTotNota As Decimal
        Dim mContRegistros As Integer = _valorZERO

        somaBcIcms = _valorZERO : somaIcms = _valorZERO : somaIPI = _valorZERO : somaBcSubs = _valorZERO
        somaTotNota = _valorZERO : bcIcms = _valorZERO : icms = _valorZERO : IPI = _valorZERO
        bcSubs = _valorZERO : totNota = _valorZERO : numero = "" : dtEntrada = "" : cfop = "" : uf = ""
        fornecedor = ""

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
                .Text = "Relatório de Notas"

                'exibe a janela de visualização para o usuário
                .ShowDialog()


            End With

            objPrintPreview = Nothing : _leitorTabela.Close()
            mContQuebrasPag = _valorZERO : cmdNF.CommandText = ""

        Catch ex As Exception
        End Try

        sqlNF.Remove(_valorZERO, sqlNF.ToString.Length)
        oConnBDGENOV.ClearPool()

        'LIMPA OBJETOS DA MEMÓRIA...
        cmdNF = Nothing : sqlNF = Nothing : numero = Nothing : dtEntrada = Nothing : cfop = Nothing
        fornecedor = Nothing : uf = Nothing : bcIcms = Nothing : icms = Nothing : IPI = Nothing
        bcSubs = Nothing : totNota = Nothing : somaBcIcms = Nothing : somaIcms = Nothing
        somaIPI = Nothing : somaBcSubs = Nothing : cmdPrint = Nothing : somaTotNota = Nothing
        oConnBDGENOV.Close() : oConnBDGENOV = Nothing



    End Sub

    Private Sub rptGravaTotaisNF(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintPageEventArgs)

        'Asssumindo as Margens definidas pela impressora padrão
        Dim margemEsq As Single = Relatorio.MarginBounds.Left
        Dim margemSup As Single = Relatorio.MarginBounds.Top
        Dim margemDir As Single = Relatorio.MarginBounds.Right
        Dim margemInf As Single = Relatorio.MarginBounds.Bottom

        margemDir -= 700 : margemEsq += 700 : margemInf += 40

        'Trabalhando com Fontes
        Dim mFonte, mFonteValor As Font
        mFonte = New Font("Times New Roman", 9, FontStyle.Bold)
        mFonteValor = New Font("Times New Roman", 9, FontStyle.Bold)

        Dim mParcelas As Integer = Me.txt_qtde.Text
        Dim mLinhaAtualLetras As Double = 0
        Dim mLinhaAtualImagem As Integer = 0
        Dim mNumImpressCorrente As Integer = 0
        Dim mLinhaDoTrassado As Integer = 285

        Dim extImagem As String = MdlEmpresaUsu.genp001.imagemCarne

        mQtdPaginas = 0
        '# PARCELA NUMERO 1
        If (Me.txt_num1.Text.Equals("") = False) AndAlso (mParcela1OK = False) Then

            mQtdPaginas += 1
            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num1.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto1.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor1.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto1.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num1.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor1.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela1OK = True
        End If


        '# PARCELA NUMERO 2
        If (Me.txt_num2.Text.Equals("") = False) AndAlso (mParcela2OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num2.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto2.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor2.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto2.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num2.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor2.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela2OK = True
        End If


        '# PARCELA NUMERO 3
        If (Me.txt_num3.Text.Equals("") = False) AndAlso (mParcela3OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num3.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto3.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor3.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto3.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num3.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor3.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela3OK = True
        End If


        '# PARCELA NUMERO 4
        If (Me.txt_num4.Text.Equals("") = False) AndAlso (mParcela4OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num4.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto4.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor4.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto4.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num4.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor4.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela4OK = True
        End If


        '# PARCELA NUMERO 5
        If (Me.txt_num5.Text.Equals("") = False) AndAlso (mParcela5OK = False) Then

            If mproximaPaginaOk = False Then

                mproximaPaginaOk = True
                Relatorio.HasMorePages = True ': pdRelatorio.
                Return
            End If

            mQtdPaginas += 1
            mLinhaAtualImagem = 0 : mLinhaAtualLetras = 0 : mLinhaDoTrassado = 285 ' : mNumImpressCorrente = 0

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num5.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto5.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor5.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto5.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num5.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor5.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mproximaPaginaOk = False : mParcela5OK = True

        End If


        '# PARCELA NUMERO 6
        If (Me.txt_num6.Text.Equals("") = False) AndAlso (mParcela6OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num6.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto6.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor6.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto6.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num6.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor6.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela6OK = True
        End If


        '# PARCELA NUMERO 7
        If (Me.txt_num7.Text.Equals("") = False) AndAlso (mParcela7OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num7.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto7.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor7.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto7.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num7.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor7.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela7OK = True
        End If


        '# PARCELA NUMERO 8
        If (Me.txt_num8.Text.Equals("") = False) AndAlso (mParcela8OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num8.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto8.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor8.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto8.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num8.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor8.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela8OK = True
        End If



        '# PARCELA NUMERO 9
        If (Me.txt_num9.Text.Equals("") = False) AndAlso (mParcela9OK = False) Then

            If mproximaPaginaOk = False Then

                mproximaPaginaOk = True
                Relatorio.HasMorePages = True
                Return
            End If
            mQtdPaginas += 1
            mLinhaAtualImagem = 0 : mLinhaAtualLetras = 0 : mLinhaDoTrassado = 285 ' : mNumImpressCorrente = 0

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num9.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto9.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor9.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto9.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num9.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor9.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela9OK = True : mproximaPaginaOk = False
        End If


        '# PARCELA NUMERO 10
        If (Me.txt_num10.Text.Equals("") = False) AndAlso (mParcela10OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num10.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto10.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor10.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto10.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num10.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor10.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela10OK = True
        End If


        '# PARCELA NUMERO 11
        If (Me.txt_num11.Text.Equals("") = False) AndAlso (mParcela11OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num11.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto11.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor11.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto11.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num11.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor11.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela11OK = True
        End If



        '# PARCELA NUMERO 12
        If (Me.txt_num12.Text.Equals("") = False) AndAlso (mParcela12OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num12.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto12.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor12.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto12.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num12.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor12.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela12OK = True
        End If



        '# PARCELA NUMERO 13
        If (Me.txt_num13.Text.Equals("") = False) AndAlso (mParcela13OK = False) Then


            If mproximaPaginaOk = False Then

                mproximaPaginaOk = True
                Relatorio.HasMorePages = True
                Return
            End If
            mQtdPaginas += 1
            mLinhaAtualImagem = 0 : mLinhaAtualLetras = 0 : mLinhaDoTrassado = 285 ' : mNumImpressCorrente = 0
            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num13.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto13.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor13.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto13.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num13.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor13.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela13OK = True : mproximaPaginaOk = False
        End If


        '# PARCELA NUMERO 14
        If (Me.txt_num14.Text.Equals("") = False) AndAlso (mParcela14OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num14.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto14.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor14.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto14.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num14.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor14.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela14OK = True
        End If


        '# PARCELA NUMERO 15
        If (Me.txt_num15.Text.Equals("") = False) AndAlso (mParcela15OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num15.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto15.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor15.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto15.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num15.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor15.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela15OK = True
        End If



        '# PARCELA NUMERO 16
        If (Me.txt_num16.Text.Equals("") = False) AndAlso (mParcela16OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num16.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto16.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor16.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto16.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num16.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor16.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela16OK = True
        End If


        '# PARCELA NUMERO 17
        If (Me.txt_num17.Text.Equals("") = False) AndAlso (mParcela17OK = False) Then


            If mproximaPaginaOk = False Then

                mproximaPaginaOk = True
                Relatorio.HasMorePages = True
                Return
            End If
            mQtdPaginas += 1
            mLinhaAtualImagem = 0 : mLinhaAtualLetras = 0 : mLinhaDoTrassado = 285 ' : mNumImpressCorrente = 0
            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num17.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto17.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor17.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto17.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num17.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor17.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela17OK = True : mproximaPaginaOk = False
        End If


        '# PARCELA NUMERO 18
        If (Me.txt_num18.Text.Equals("") = False) AndAlso (mParcela18OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num18.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto18.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor18.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto18.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num18.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor18.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela18OK = True
        End If


        '# PARCELA NUMERO 19
        If (Me.txt_num19.Text.Equals("") = False) AndAlso (mParcela19OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num19.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto19.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor19.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto19.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num19.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor19.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela19OK = True
        End If


        '# PARCELA NUMERO 20
        If (Me.txt_num20.Text.Equals("") = False) AndAlso (mParcela20OK = False) Then

            mNumImpressCorrente += 1
            Try
                Relatorio.Graphics.DrawImage(Image.FromFile("\wged\Metrosys\Imagens\" & "modelo_carne." & extImagem), 145, (30 + mLinhaAtualImagem))
            Catch ex As Exception
            End Try


            'impressão das colunas Lado Esquerdo...
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemDir + 245, (80 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(_clFunc.Exibe_Str((C_CodCli & " - " & nomeCliente).ToString, 22), mFonte, Brushes.Black, margemDir + 185, (115 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num20.Text, mFonte, Brushes.Black, margemDir + 235, (145 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto20.Text, mFonte, Brushes.Black, margemDir + 235, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor20.Text, mFonte, Brushes.Black, margemDir + 205, (208 + mLinhaAtualLetras), New StringFormat())


            ''impressão das colunas Lado Direito...
            Relatorio.Graphics.DrawString(nomeCliente, mFonte, Brushes.Black, margemEsq - 335, (48 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(endCliente, mFonte, Brushes.Black, margemEsq - 335, (67 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(codLoja, mFonte, Brushes.Black, margemEsq - 305, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodCli, mFonte, Brushes.Black, margemEsq - 230, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(C_CodVendedor, mFonte, Brushes.Black, margemEsq - 130, (143 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.msk_vencto20.Text, mFonte, Brushes.Black, margemEsq - 285, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_num20.Text, mFonte, Brushes.Black, margemEsq - 130, (175 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawString(Me.txt_valor20.Text, mFonte, Brushes.Black, margemEsq - 130, (207 + mLinhaAtualLetras), New StringFormat())
            Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, mLinhaDoTrassado, margemDir, mLinhaDoTrassado)

            mLinhaAtualImagem += 275 : mLinhaAtualLetras += 275 : mLinhaDoTrassado += 275
            mParcela20OK = True
        End If

        Relatorio.HasMorePages = False




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

    Private Sub PrintPreviewDialog1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles PrintPreviewDialog1.FormClosed

        zeraPercelas()
    End Sub

    Private Sub pdRelatorio_BeginPrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdRelatorio.BeginPrint
        zeraPercelas()
    End Sub

End Class