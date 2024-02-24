Public Class Frm_NFeReferenciadaResp

    Private _nota1pp As Cl_Nota1pp
    Dim _msgErro As String = ""
    Private _clFuncoes As New ClFuncoes
    Private _clNotaRef(1) As GenoNFeXml.Cl_notaref
    Private notarefAux As New GenoNFeXml.Cl_notaref
    Public frmRef As New Object

    Public Sub setNota1pp(ByRef nt1pp As Cl_Nota1pp)
        _nota1pp = nt1pp
    End Sub

    Public Sub setFrmRef(ByRef frmRequest As Form)
        frmRef = frmRequest
    End Sub

    Private Sub Frm_NFeReferenciadaResp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_NFeReferenciadaResp_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                executaF2()
            Case Keys.F4
                executaF4()
        End Select

    End Sub

    Private Sub Frm_NFeReferenciadaResp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cbo_uf = _clFuncoes.PreenchComboUF(cbo_uf)
            cbo_TipoDoc.SelectedIndex = 0
        Catch ex As Exception
        End Try
        
    End Sub

    Private Sub txt_chaveNFe_Leave(sender As Object, e As EventArgs) Handles txt_chaveNFe.Leave

        'Cnpj:
        _nota1pp.pNt_refCnpj = txt_chaveNFe.Text.Substring(6, 14)
        txt_Cnpj.Text = _nota1pp.pNt_refCnpj

        'Serie:
        _nota1pp.pNt_refSerie = txt_chaveNFe.Text.Substring(22, 3)
        txt_serie.Text = _nota1pp.pNt_refSerie

        'Numero:
        _nota1pp.pNt_refNumero = txt_chaveNFe.Text.Substring(25, 9)
        txt_numeroNFe.Text = _nota1pp.pNt_refNumero

        'UF:
        cbo_uf.SelectedIndex = _clFuncoes.trazIndexComboBox(_clFuncoes.trazSigla_UF(txt_chaveNFe.Text.Substring(0, 2), MdlConexaoBD.conectionPadrao), 2, cbo_uf)
        _nota1pp.pNt_refUf = txt_chaveNFe.Text.Substring(0, 2)

        'AAMM:
        _nota1pp.pNt_refAAMM = txt_chaveNFe.Text.Substring(2, 4)
        txt_aamm.Text = _nota1pp.pNt_refAAMM

        'MODELO:
        _nota1pp.pNt_refMOD = txt_chaveNFe.Text.Substring(19, 2)
        txt_modelo.Text = _nota1pp.pNt_refMOD

        'Modelo Documento:
        _nota1pp.pNt_refModDoc = cbo_TipoDoc.SelectedItem.ToString



    End Sub

    Private Sub txt_CnpjCpf_Leave(sender As Object, e As EventArgs) Handles txt_Cnpj.Leave
        txt_Cnpj.Mask = "99.999.999/9999-99"
    End Sub

    Private Function ErrorValores() As Boolean

        If MessageBox.Show(_msgErro, "METROSYS", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            limpaValoresRef()
        Else
            Return False
        End If

        Return True
    End Function

    Private Sub FrmClosingExtracted1()

        _msgErro = ""
        'Chave NFe:
        If (IsNumeric(txt_chaveNFe.Text) = False) OrElse (txt_chaveNFe.TextLength <> 44) Then
            _msgErro = "Chave da NFe está incorreta! Nota NÃO será emitida! Deseja continuar?"
            ErrorValores() : Return
        End If

    End Sub

    Private Sub FrmClosingExtracted2()

        _msgErro = ""
        'Cnpj:
        If (IsNumeric(_clFuncoes.RemoverCaracter2(txt_Cnpj.Text)) = False) OrElse (_clFuncoes.RemoverCaracter2(txt_Cnpj.Text).Length <> 14) Then
            _msgErro = "CNPJ da NFe está incorreto! Nota NÃO será emitida! Deseja continuar?"
            ErrorValores() : Return
        End If

        'Serie:
        If (IsNumeric(txt_serie.Text) = False) OrElse (txt_serie.TextLength <> 3) Then
            _msgErro = "Serie da NFe está incorreta! Nota NÃO será emitida! Deseja continuar?"
            ErrorValores() : Return
        End If

        'Mumero:
        If (IsNumeric(txt_numeroNFe.Text) = False) OrElse (txt_numeroNFe.TextLength <> 9) Then
            _msgErro = "Numero da NFe está incorreto! Nota NÃO será emitida! Deseja continuar?"
            ErrorValores() : Return
        End If

        'UF:
        If cbo_uf.SelectedIndex < 0 Then
            _msgErro = "UF da NFe não informada! Nota NÃO será emitida! Deseja continuar?"
            ErrorValores() : Return
        End If

        'Ano/Mes:
        If txt_aamm.Text.Equals("") Then
            _msgErro = "Ano/Mes não informado! Nota NÃO será emitida! Deseja continuar?"
            ErrorValores() : Return
        End If

        'Modelo:
        If txt_modelo.Text.Equals("") Then
            _msgErro = "Modelo Incorreto! Nota NÃO será emitida! Deseja continuar?"
            ErrorValores() : Return
        End If

    End Sub

    Private Sub FrmClosingExtracted3()

        _msgErro = ""
        'Modelo:
        If txt_modelo.Text.Equals("") Then
            _msgErro = "Modelo Incorreto! Nota NÃO será emitida! Deseja continuar?"
            ErrorValores() : Return
        End If

        'ECF:
        If IsNumeric(txt_ecf.Text) = False Then
            _msgErro = "ECF Incorreto! Nota NÃO será emitida! Deseja continuar?"
            ErrorValores() : Return
        End If

        'COO:
        If IsNumeric(txt_coo.Text) = False Then
            _msgErro = "COO Incorreto! Nota NÃO será emitida! Deseja continuar?"
            ErrorValores() : Return
        End If

    End Sub

    Private Sub txt_chaveNFe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_numeroNFe.KeyPress, txt_Cnpj.KeyPress, txt_chaveNFe.KeyPress, txt_serie.KeyPress, txt_aamm.KeyPress, txt_ecf.KeyPress, txt_coo.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Sub limpaValoresRef()
        _nota1pp.pNt_refChave = "" : _nota1pp.pNt_refUf = "" : _nota1pp.pNt_refSerie = "" : _nota1pp.pNt_refNumero = ""
    End Sub

    Sub setValoresNFeRef()

        _nota1pp.pNt_refModDoc = cbo_TipoDoc.SelectedItem

        notarefAux.refchave = txt_chaveNFe.Text
        notarefAux.reftipo = cbo_TipoDoc.SelectedItem
        notarefAux.refcnpj = _clFuncoes.RemoverCaracter2(txt_Cnpj.Text)
        notarefAux.refserie = txt_serie.Text
        notarefAux.refnumero = txt_numeroNFe.Text
        notarefAux.refmod = txt_modelo.Text
        notarefAux.refaamm = txt_aamm.Text
        notarefAux.refecf = txt_ecf.Text
        notarefAux.refcoo = txt_coo.Text
        Try
            notarefAux.refcoduf = _clFuncoes.trazCodUF(cbo_uf.SelectedItem, MdlConexaoBD.conectionPadrao)
        Catch ex As Exception
        End Try



    End Sub

    Private Sub cbo_ModDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_TipoDoc.SelectedIndexChanged


        '0 = NFe
        '1 = CP
        '2 = 1
        '3 = 1A
        '4 = CTe
        Try
            Select Case cbo_TipoDoc.SelectedIndex
                Case 0, 4
                    txt_ecf.Text = "" : txt_coo.Text = "" : grb_cp.Enabled = False
                    desabilitaValoresNF() : txt_chaveNFe.Enabled = True
                Case 1
                    desabilitaValoresNF()
                    txt_ecf.Text = "" : txt_coo.Text = "" : grb_cp.Enabled = True
                    txt_modelo.Enabled = True
                Case 2, 3
                    txt_ecf.Text = "" : txt_coo.Text = "" : grb_cp.Enabled = False
                    habilitaValoresNF()
                    txt_chaveNFe.Enabled = False
            End Select
        Catch ex As Exception
        End Try
        

    End Sub

    Sub habilitaValoresNF()
        txt_chaveNFe.Text = "" : txt_numeroNFe.Text = ""
        txt_modelo.Text = "" : txt_serie.Text = "" : txt_Cnpj.Text = "" : txt_aamm.Text = ""

        txt_chaveNFe.Enabled = True : cbo_uf.Enabled = True : txt_numeroNFe.Enabled = True
        txt_modelo.Enabled = True : txt_serie.Enabled = True : txt_Cnpj.Enabled = True : txt_aamm.Enabled = True

        cbo_uf.SelectedIndex = 0
    End Sub

    Sub desabilitaValoresNF()
        txt_chaveNFe.Text = "" : txt_numeroNFe.Text = ""
        txt_modelo.Text = "" : txt_serie.Text = "" : txt_Cnpj.Text = "" : txt_aamm.Text = ""

        txt_chaveNFe.Enabled = False : cbo_uf.Enabled = False : txt_numeroNFe.Enabled = False
        txt_modelo.Enabled = False : txt_serie.Enabled = False : txt_Cnpj.Enabled = False : txt_aamm.Enabled = False

        cbo_uf.SelectedIndex = 0
    End Sub

    Private Sub Frm_NFeReferenciadaResp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        '                        3                      7  
        'numero, tipo, modelo, chave, uf, cnpj, serie, coo, ecf, aamm 
        If dtg_notaReferenciada.Rows.Count > 0 Then
            ReDim Preserve _clNotaRef(dtg_notaReferenciada.Rows.Count - 1)

            Dim mcont As Int16 = 0
            For Each row As DataGridViewRow In dtg_notaReferenciada.Rows

                If row.IsNewRow = False Then

                    _clNotaRef(row.Index) = New GenoNFeXml.Cl_notaref(0, row.Cells(0).Value.ToString, row.Cells(1).Value.ToString, row.Cells(3).Value.ToString, _
                                                           row.Cells(4).Value.ToString, row.Cells(9).Value.ToString, row.Cells(5).Value.ToString, _
                                                           row.Cells(2).Value.ToString, row.Cells(6).Value.ToString, row.Cells(8).Value.ToString, _
                                                           row.Cells(7).Value.ToString)
                End If
            Next
            frmRef._NFeS.notaref = _clNotaRef
        End If

    End Sub

    Private Sub btn_incluir_Click(sender As Object, e As EventArgs) Handles btn_incluir.Click

        executaF2()

    End Sub

    Sub depoisIncluirGrid()

        Select Case cbo_TipoDoc.SelectedItem
            Case "NFe", "CTe"
                txt_chaveNFe.Text = "" : txt_chaveNFe.Focus()
                txt_numeroNFe.Text = "" : txt_serie.Text = "" : txt_modelo.Text = "" : txt_Cnpj.Text = "" : txt_aamm.Text = ""
            Case "01", "1A"
                txt_numeroNFe.Text = "" : txt_serie.Text = "" : txt_modelo.Text = "" : txt_Cnpj.Text = "" : txt_aamm.Text = ""
                txt_numeroNFe.Focus()
            Case "CP"
                txt_ecf.Text = "" : txt_coo.Text = ""
                txt_ecf.Focus()
        End Select


    End Sub

    Sub executaF2()

        '0 = NFe
        '1 = CP
        '2 = 1
        '3 = 1A
        '4 = CTe
        Select Case cbo_TipoDoc.SelectedIndex
            Case 0, 4
                FrmClosingExtracted1()
            Case 1
                FrmClosingExtracted3()
            Case 2, 3
                FrmClosingExtracted2()
        End Select

        If _msgErro.Equals("") Then addRowGrid()
        tratamentoTipo()
        depoisIncluirGrid()

    End Sub

    Sub addRowGrid()

        setValoresNFeRef()

        '                        3                      7  
        'numero, tipo, modelo, chave, uf, cnpj, serie, coo, ecf, aamm
        Dim mLinha As String()
        mLinha = {notarefAux.refnumero, notarefAux.reftipo, notarefAux.refmod, notarefAux.refchave, notarefAux.refcoduf, notarefAux.refcnpj, _
                  notarefAux.refserie, notarefAux.refcoo, notarefAux.refecf, notarefAux.refaamm}

        Me.dtg_notaReferenciada.Rows.Add(mLinha)
        Me.dtg_notaReferenciada.Refresh()
    End Sub

    Sub executaF4()

        If MessageBox.Show("Deseja realmente deletar essa Linha?", "Metrosys", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
            = Windows.Forms.DialogResult.Yes Then

            Me.dtg_notaReferenciada.Rows.RemoveAt(Me.dtg_notaReferenciada.CurrentRow.Index)
            Me.dtg_notaReferenciada.Refresh() : tratamentoTipo()
        End If

    End Sub

    Sub tratamentoTipo()
        If dtg_notaReferenciada.Rows.Count > 0 Then
            cbo_TipoDoc.Enabled = False
        Else
            cbo_TipoDoc.Enabled = True
        End If

    End Sub

    Private Sub btn_deletar_Click(sender As Object, e As EventArgs) Handles btn_deletar.Click
        executaF4()
    End Sub

End Class