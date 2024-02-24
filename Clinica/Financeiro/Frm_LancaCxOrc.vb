Imports System.IO
Imports System.Math
Imports Npgsql
Imports System.Text
Imports System.Data
Imports System.DateTime

Public Class Frm_LancaCxOrc

    Dim transacao As NpgsqlTransaction
    Dim agora As Date = Now
    Dim Xnumeros, XMov As New Cl_bdMetrosys
    Dim dataAtual As DateTime = DateTime.Now
    Dim mTipo As String
    Dim _indexCboLanc As Int16
    Dim _clFuncoes As New ClFuncoes
    Public _idLancamento As Int64 = 0

    Dim _CxOrcamento As New Cl_CxOrcamento
    Dim _CxOrcamentoDAO As New Cl_CxOrcamentoDAO
    Dim _Geno As New Cl_Geno
    Dim _Cliente As New Cl_Cadp001
    Dim _Doutor As New Cl_Doutor
    Dim _DoutorDAO As New Cl_DoutorDAO
    Dim _DescricaoDAO As New Cl_DescrDespRecDAO
    Dim _Protetico As New Cl_Doutor
    Dim _ProteticoDAO As New Cl_DoutorDAO

    Dim _BuscaForn As New Frm_ClienteFornResp
    Public Shared _frmREf As New Frm_LancaCxOrc

    Private Sub Frm_LancaCxOrc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Frm_LancaCxOrc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_LancaCxOrc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        _clFuncoes.trazGenoSelecionado(MdlEmpresaUsu._codigo, _Geno)
        cbo_doutores = _DoutorDAO.PreenchComboDoutoresPesq(_Geno, cbo_doutores, MdlConexaoBD.conectionPadrao)
        cbo_protetico = _ProteticoDAO.PreenchComboProtetico(_Geno, cbo_protetico, MdlConexaoBD.conectionPadrao)
        Try
            cbo_protetico.SelectedIndex = 0
        Catch ex As Exception
        End Try

        cbo_descricao = _DescricaoDAO.PreenchComboDescricoesPorTIPO("R", cbo_descricao, MdlConexaoBD.conectionPadrao)
        Me.txt_total.Text = "0,00"
        txt_hora.Text = Mid(TimeString, 1, 5)

        If btn_alterar.Enabled Then
            TrazLancamento()
            CaulculaTotal()
            Me.txt_total.Focus() : Me.txt_total.SelectAll()
            Me.txt_hora.ReadOnly = True : Me.txt_hora.BackColor = txt_total.BackColor
        End If
    End Sub

    Sub TrazLancamento()


        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            conection.ClearAllPools() : conection = Nothing : Return

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT oc_data, '', oc_descricao, oc_valor, oc_doutor, oc_codcli, 0, oc_hora, oc_protetico, oc_nomecli FROM " & MdlEmpresaUsu._esqEstab & ".cxorcamento ")
            sql.Append("WHERE oc_id = @oc_id")
            cmd = New NpgsqlCommand(sql.ToString, conection)
            cmd.Parameters.Add("@oc_id", _idLancamento)
            dr = cmd.ExecuteReader

            While dr.Read

                msk_data.Value = dr(0)
                cbo_descricao.Text = dr(2).ToString
                txt_valor.Text = Format(dr(3), "###,##0.00")
                txt_hora.Text = dr(7).ToString

                If dr(4).ToString.Equals("") = False Then
                    _DoutorDAO.trazDoutorLojaNome(dr(4).ToString, _Geno, _Doutor)
                    cbo_doutores.SelectedIndex = _clFuncoes.trazIndexComboBox(_Doutor.Nome, _Doutor.Nome.Length, cbo_doutores)
                End If

                If dr(5).ToString.Equals("") = False Then
                    _clFuncoes.trazCadp001(dr(5).ToString, _Cliente)
                    txt_codPart.Text = _Cliente.pCod : txt_nomePart.Text = _Cliente.pPortad
                Else
                    txt_nomePart.Text = dr(9).ToString
                End If

                If dr(8).ToString.Equals("") = False Then
                    _ProteticoDAO.trazDoutorLojaNome(dr(8).ToString, _Geno, _Protetico)
                    cbo_protetico.SelectedIndex = _clFuncoes.trazIndexComboBox(_Protetico.Nome, _Protetico.Nome.Length, cbo_protetico)
                End If

            End While
            dr.Close()

        Catch ex As Exception
            MsgBox("Erro ao trazer Lançamento:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Me.Close()

        End Try

        cmd.CommandText = "" : sql.Remove(0, sql.ToString.Length) : conection.Close()
        cmd = Nothing : sql = Nothing : conection = Nothing

    End Sub

    Private Sub txt_valor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total.KeyPress, txt_valor.KeyPress

        'permite só numeros com virgula:
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Function ValidaValores() As Boolean

        Try
            If CDbl(txt_total.Text) < 0 Then
                lbl_mensagem.Text = "Valor Total DEVE ser Maior ou IGUAL a ZERO !"
                Return False
            End If
        Catch ex As Exception
            lbl_mensagem.Text = "ERRO:: " & ex.Message
            Return False
        End Try

        Return True
    End Function

    Private Sub btn_incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_incluir.Click

        If ValidaValores() = False Then Return
        Dim mCaixa As String = MdlUsuarioLogando._codcaixa
        If mCaixa.Equals("") Then mCaixa = "001"
        Try
            dataAtual = DateTime.Now
            Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            _CxOrcamento.oc_hora = txt_hora.Text
            _CxOrcamento.oc_status = "N"
            _CxOrcamento.oc_data = msk_data.Value
            _CxOrcamento.oc_descricao = cbo_descricao.Text
            _CxOrcamento.oc_valor = CDbl(txt_total.Text)
            _CxOrcamento.oc_usu = MdlUsuarioLogando._usuarioLogin
            _CxOrcamento.oc_loja = _Geno.pCodig
            _CxOrcamento.oc_caixa = MdlUsuarioLogando._codcaixa
            If _CxOrcamento.oc_caixa.Equals("") Then _CxOrcamento.oc_caixa = "001"
            _CxOrcamento.oc_iddoutor = _Doutor.Id
            _CxOrcamento.oc_doutor = _Doutor.Nome
            _CxOrcamento.oc_codcli = _Cliente.pCod
            _CxOrcamento.oc_nomecli = _Cliente.pPortad
            If _Cliente.pCod.Equals("") Then _CxOrcamento.oc_nomecli = txt_nomePart.Text
            _CxOrcamento.oc_driniciais = _Doutor.Iniciais
            _CxOrcamento.oc_protetico = _Protetico.Nome

            _CxOrcamentoDAO.IncCX_Diario(_CxOrcamento, _Geno, conexao)

            Try
                If conexao.State = ConnectionState.Open Then conexao.Close()
            Catch ex As Exception
            End Try

            limpa_lancamento()
            MsgBox("Registro Incluido com Sucesso ! ")

            ZeraValores()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Sub ZeraValores()

        Me.msk_data.Value = Date.Now
        Me.txt_total.Text = "0,00"
        txt_codPart.Text = "" : txt_nomePart.Text = ""
        cbo_descricao.Text = ""
        _Cliente.zeraValores()

    End Sub

    Private Sub limpa_lancamento()
       
        msk_data.Text = DateValue(Now)
        txt_total.Text = "0,00"
        cbo_descricao.Text = ""
    End Sub

    Private Sub txt_valor_Leave(sender As Object, e As EventArgs) Handles txt_valor.Leave

        lbl_mensagem.Text = ""
        If Me.txt_valor.Text.Equals("") Then Me.txt_valor.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_valor.Text) Then
            If CDec(Me.txt_valor.Text) < 0 Then
                lbl_mensagem.Text = "Valor deve ser Maior ou IGUAL a ZERO !"
                Return

            End If
            Me.txt_valor.Text = Format(CDec(Me.txt_valor.Text), "###,##0.00")

        End If
        CaulculaTotal()

    End Sub

    Sub DesHabilitaCamposRecebimento()
        Try
            cbo_doutores.SelectedIndex = -1
        Catch ex As Exception
        End Try

        Try
            cbo_protetico.SelectedIndex = 0
        Catch ex As Exception
        End Try

        cbo_doutores.Enabled = False : cbo_protetico.Enabled = False
        txt_codPart.Text = "" : txt_codPart.Enabled = False
        txt_nomePart.Text = "" : txt_nomePart.Enabled = False
    End Sub

    Sub HabilitaCamposRecebimento()

        Try
            cbo_doutores.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Try
            cbo_protetico.SelectedIndex = 0
        Catch ex As Exception
        End Try

        cbo_doutores.Enabled = True : cbo_protetico.Enabled = True
        txt_codPart.Text = "" : txt_codPart.Enabled = True
        txt_nomePart.Text = "" : txt_nomePart.Enabled = True
    End Sub

    Sub HabilitaCamposRecebimentoDivi()

        Try
            cbo_doutores.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Try
            cbo_protetico.SelectedIndex = 0
        Catch ex As Exception
        End Try


        cbo_doutores.Enabled = True : cbo_protetico.Enabled = False
        txt_codPart.Text = "" : txt_codPart.Enabled = True
        txt_nomePart.Text = "" : txt_nomePart.Enabled = True
    End Sub

    Sub CaulculaTotal()

        Try
            txt_total.Text = txt_valor.Text
        Catch ex As Exception
            txt_total.Text = "0,00"
        End Try

    End Sub

    Sub limpaCboDescricao()

        Try
            cbo_descricao.AutoCompleteCustomSource.Clear()
            cbo_descricao.Items.Clear()
            cbo_descricao.Refresh()
        Catch ex As Exception
        End Try


    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click

        If ValidaValores() = False Then Return
        Dim mCaixa As String = MdlUsuarioLogando._codcaixa
        If mCaixa.Equals("") Then mCaixa = "001"
        Try
            dataAtual = DateTime.Now

            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("Erro ao Abri conexao:: " & ex.Message, MsgBoxStyle.Critical) : Return
            End Try

            _CxOrcamento.oc_id = _idLancamento
            _CxOrcamento.oc_status = "A"
            _CxOrcamento.oc_data = msk_data.Value
            _CxOrcamento.oc_descricao = cbo_descricao.Text
            _CxOrcamento.oc_valor = CDbl(txt_total.Text)
            _CxOrcamento.oc_usuarioalt = MdlUsuarioLogando._usuarioLogin
            _CxOrcamento.oc_loja = _Geno.pCodig
            _CxOrcamento.oc_caixa = MdlUsuarioLogando._codcaixa
            If _CxOrcamento.oc_caixa.Equals("") Then _CxOrcamento.oc_caixa = "001"
            _CxOrcamento.oc_hora = txt_hora.Text
            _CxOrcamento.oc_iddoutor = _Doutor.Id
            _CxOrcamento.oc_doutor = _Doutor.Nome
            _CxOrcamento.oc_codcli = _Cliente.pCod
            _CxOrcamento.oc_nomecli = _Cliente.pPortad
            If _Cliente.pCod.Equals("") Then _CxOrcamento.oc_nomecli = txt_nomePart.Text
            _CxOrcamento.oc_driniciais = _Doutor.Iniciais
            _CxOrcamento.oc_protetico = _Protetico.Nome

            _CxOrcamentoDAO.altCX_Diario(_CxOrcamento, _Geno, conection)
            Try
                If conection.State = ConnectionState.Open Then conection.Close()
            Catch ex As Exception
            End Try

            limpa_lancamento()
            MsgBox("Registro Alterado com Sucesso ! ")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try


    End Sub

    Private Sub txt_codPart_KeyDownExtracted()

        _frmREf = Me
        _BuscaForn.set_frmRef(Me)
        _BuscaForn.ShowDialog(Me)
        If Me.txt_codPart.Text.Equals("") Then Me.txt_nomePart.Focus() : txt_nomePart.Text = "" : _Cliente.zeraValores() : Return

        Me.txt_nomePart.Focus() : Me.txt_nomePart.SelectAll()

        _clFuncoes.trazCadp001(Me.txt_codPart.Text, _Cliente)
    End Sub

    Private Sub txt_codPart_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codPart.KeyDown

        If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then


            If Me.txt_codpart.Text.Equals("") Then


                'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                Try
                    txt_codPart_KeyDownExtracted()

                Catch ex As Exception
                End Try

            Else  ' Consulta pelo codigo do cliente...


                If (Me.txt_codpart.TextLength > 5) AndAlso (e.KeyCode = Keys.Enter) Then 'Se retornar nada

                    If _clFuncoes.trazCadp001(Me.txt_codPart.Text, _cliente) Then

                        txt_nomePart.Text = "" : _Cliente.zeraValores()
                        Dim lShouldReturn As Boolean
                        Me.txt_nomePart.Focus()
                        Me.txt_nomePart.SelectAll()
                        If lShouldReturn Then Return
                        lShouldReturn = Nothing

                    Else


                        'Aqui tenta chamar o Formulario de Busca do Fornecedor...
                        Try
                            txt_codPart_KeyDownExtracted()

                        Catch ex As Exception
                        End Try

                    End If
                End If

            End If
        End If



    End Sub

    Private Sub cbo_doutores_GotFocus(sender As Object, e As EventArgs) Handles cbo_doutores.GotFocus
        If cbo_doutores.DroppedDown = False Then cbo_doutores.DroppedDown = True
    End Sub

    Private Sub cbo_doutores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_doutores.SelectedIndexChanged

        Try
            If cbo_doutores.SelectedIndex > 0 Then

                _DoutorDAO.trazDoutorLojaNome(cbo_doutores.SelectedItem.ToString, _Geno, _Doutor)
            Else
                _Doutor.zeraValores()
            End If
        Catch ex As Exception
            _Doutor.zeraValores()
        End Try

    End Sub

    Private Sub cbo_descricao_GotFocus(sender As Object, e As EventArgs) Handles cbo_descricao.GotFocus

        Try
            If cbo_descricao.Text.Equals("") Then
                If (cbo_descricao.DroppedDown = False) AndAlso (cbo_descricao.Items.Count > 0) Then cbo_descricao.DroppedDown = True
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If btn_alterar.Enabled = False Then
            Me.txt_hora.Text = Mid(TimeString, 1, 5)
            Me.txt_hora.Refresh()
        End If

    End Sub

    Private Sub cbo_protetico_GotFocus(sender As Object, e As EventArgs) Handles cbo_protetico.GotFocus
        If cbo_protetico.DroppedDown = False Then cbo_protetico.DroppedDown = True
    End Sub

    Private Sub cbo_protetico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_protetico.SelectedIndexChanged

        Try
            If cbo_protetico.SelectedIndex > 0 Then
                _ProteticoDAO.trazDoutorLojaNome(cbo_protetico.SelectedItem.ToString, _Geno, _Protetico, True)
            Else
                _Protetico.zeraValores()
            End If
        Catch ex As Exception
            _Protetico.zeraValores()
        End Try


    End Sub

    Private Sub txt_hora_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_hora.KeyPress
        'permite só numeros:
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txt_hora_DoubleClick(sender As Object, e As EventArgs) Handles txt_hora.DoubleClick
        Timer1.Stop()
        txt_hora.ReadOnly = False
        txt_hora.BackColor = txt_valor.BackColor
        txt_hora.SelectAll()
    End Sub

End Class