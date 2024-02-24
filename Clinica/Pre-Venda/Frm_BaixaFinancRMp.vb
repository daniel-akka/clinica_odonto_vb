Imports Npgsql
Imports System.Text
Imports System.Data
Imports System.Math

Public Class Frm_BaixaFinancRMp
    Private Const _valorZERO As Integer = 0
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Dim _NumDocumento As String = "", _CodLoja As String = "", _NomeParticipante As String = ""
    Dim _CodigoParticipante As String = "", _dataPagamento As String = ""
    Dim _valorPago As Double, _valorDocumento As Double, _valorCorrente As Double
    Dim _dtEmiss As String = "", _tipo As String = ""


    Private Sub Frm_BaixaFinancRMp_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If btn_finalizar.Enabled = True Then e.Cancel = True

    End Sub

    Private Function verificaCamposRDbAnterior()

        If txt_documento.Text.Equals("") = False Then


            'If CDbl(txt_valorPago.Text) <= _valorZERO Then

            '    MsgBox("Informe um valor Pago", MsgBoxStyle.Exclamation, "METROSYS")
            '    txt_valorPago.Focus() : Return False

            'End If

        Else

            MsgBox("Informe o numero do Documento", MsgBoxStyle.Exclamation, "METROSYS")
            txt_documento.Focus() : Return False
        End If


        If IsNumeric(txt_valorPago.Text) Then


            If CDbl(txt_valorPago.Text) <= _valorZERO Then

                MsgBox("Informe um valor Pago", MsgBoxStyle.Exclamation, "METROSYS")
                txt_valorPago.Focus() : Return False
            End If

        Else

            MsgBox("Valor Pago inválido", MsgBoxStyle.Exclamation, "METROSYS")
            txt_valorPago.Focus() : Return False
        End If


        If IsNumeric(txt_valorDesconto.Text) Then


            If CDbl(txt_valorDesconto.Text) < _valorZERO Then

                MsgBox("Valor Desconto deve ser MAIOR ou IGUAL a ZERO", MsgBoxStyle.Exclamation, "METROSYS")
                txt_valorDesconto.Focus() : Return False

            End If

        Else

            MsgBox("Valor Desconto inválido", MsgBoxStyle.Exclamation, "METROSYS")
            txt_valorDesconto.Focus() : Return False
        End If


        If IsNumeric(txt_juros.Text) Then


            If CDbl(txt_juros.Text) < _valorZERO Then

                MsgBox("Valor Acréscimo deve ser MAIOR ou IGUAL a ZERO", MsgBoxStyle.Exclamation, "METROSYS")
                txt_juros.Focus() : Return False

            End If

        Else

            MsgBox("Valor Acréscimo inválido", MsgBoxStyle.Exclamation, "METROSYS")
            txt_juros.Focus() : Return False
        End If



        Return True
    End Function

    Private Function verificaCamposRDbAtual()

        If IsNumeric(txt_valorPago.Text) Then


            If CDbl(txt_valorPago.Text) <= _valorZERO Then

                MsgBox("Informe um valor Pago", MsgBoxStyle.Exclamation, "METROSYS")
                txt_valorPago.Focus() : Return False
            End If

        Else

            MsgBox("Valor Pago inválido", MsgBoxStyle.Exclamation, "METROSYS")
            txt_valorPago.Focus() : Return False
        End If


        If IsNumeric(txt_valorDesconto.Text) Then


            If CDbl(txt_valorDesconto.Text) < _valorZERO Then

                MsgBox("Valor Desconto deve ser MAIOR ou IGUAL a ZERO", MsgBoxStyle.Exclamation, "METROSYS")
                txt_valorDesconto.Focus() : Return False
            End If

        Else

            MsgBox("Valor Desconto inválido", MsgBoxStyle.Exclamation, "METROSYS")
            txt_valorDesconto.Focus() : Return False
        End If


        If IsNumeric(txt_juros.Text) Then


            If CDbl(txt_juros.Text) < _valorZERO Then

                MsgBox("Valor Acréscimo deve ser MAIOR ou IGUAL a ZERO", MsgBoxStyle.Exclamation, "METROSYS")
                txt_juros.Focus() : Return False

            End If

        Else

            MsgBox("Valor Acréscimo inválido", MsgBoxStyle.Exclamation, "METROSYS")
            txt_juros.Focus() : Return False
        End If



        Return True
    End Function

    Private Sub btn_baixar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_baixar.Click


        If RDbContAtual.Checked Then
            verificaCamposRDbAtual()
        Else
            verificaCamposRDbAnterior()
        End If


        '  *******************
        '  Baixando Duplicata 
        '  *******************
        Dim mValorDuplic As Double = CDbl(Me.txt_valorPago.Text)
        mValorDuplic = Round((mValorDuplic + CDbl(Me.txt_valorDesconto.Text)), 2)

        Try

            If CDbl(txt_valorPago.Text) > 0 Then

                If MessageBox.Show("Confirma Baixa de Documento !", "Quitação ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    If mValorDuplic >= _valorCorrente Then

                        Dim mValorFinal As Double = _clFuncoes.trazSomaValorParcialFatdp02(Me.txt_documento.Text, _CodigoParticipante, MdlConexaoBD.conectionPadrao)
                        mValorFinal = Round((mValorFinal + _valorCorrente), 2)
                        Baixa_dupIndividual_Total(RTrim(Me.txt_documento.Text), "T", DateValue(Me.dtp_dataPagamento.Text), CDbl(Me.txt_juros.Text), 0.0, CDbl(Me.txt_valorPago.Text), _
                                    mValorFinal, MdlConexaoBD.conectionPadrao)
                        MessageBox.Show("Quitacao Efetuada !", "Baixa ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ' Limpa_campos de baixa
                        Me.txt_documento.Text = "" : _valorCorrente = 0
                        Me.txt_juros.Text = "0,00" : Me.txt_valorPago.Text = "0,00"

                    Else

                        _clBD.IncDuplicatas_Parciais("G00" & _CodLoja, _CodigoParticipante, _tipo, Mid(txt_documento.Text, 1, 9), Mid(txt_documento.Text, 1, 9), "", _
                        0.0, Me.txt_documento.Text, _dtEmiss, DateValue(dtp_dataPagamento.Text), CDbl(txt_valorPago.Text), "00", _
                        DateValue(dtp_dataPagamento.Text), 0.0, 0.0, 0, "PGTO PARCIAL", "", 0.0, 0.0, "L", False, "000", _
                        0, "", "", "", "", conectionPadrao)
                        Baixa_dupIndividual_Parcial(_CodigoParticipante, txt_documento.Text, (_valorCorrente - CDbl(txt_valorPago.Text)), MdlConexaoBD.conectionPadrao)
                        MessageBox.Show("Baixa Parcial Efetuada !", "Baixa Parcial ", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Limpa campos de baixa Parcial
                        Me.txt_documento.Text = "" : _valorCorrente = 0
                        Me.txt_juros.Text = "0,00" : Me.txt_valorPago.Text = "0,00"

                    End If

                    Me.txt_documento.Focus()
                End If
            End If

            preencheDtgDocumento()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        btn_baixar.Enabled = False : Me.Close()

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDbContAtual.CheckedChanged

        Me.txt_documento.ReadOnly = True
        btn_baixar.Enabled = True
        Me.txt_documento.Text = _NumDocumento & "A"
        Me.txt_valorPago.Text = "0,00" : Me.txt_valorDesconto.Text = "0,00"
        Me.txt_juros.Text = "0,00" : Me.txt_nomeCliente.Text = _NomeParticipante
        preencheDtgDocumento()
    End Sub

    Private Sub RDbContAnterior_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDbContAnterior.CheckedChanged

        Me.txt_documento.ReadOnly = True
        Me.txt_documento.Text = "" : Me.txt_valorPago.Text = "0,00" : Me.txt_valorDesconto.Text = "0,00"
        Me.txt_juros.Text = "0,00" : Me.txt_nomeCliente.Text = _NomeParticipante
        preencheDtgDocumento()
    End Sub

    Private Sub txt_documento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_documento.KeyPress
        'permite só numeros
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_valorPago_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valorPago.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_valorDesconto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valorDesconto.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_acrescimo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_juros.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_documento.Click

        Me.txt_documento.SelectAll()

    End Sub

    Private Sub txt_valorPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valorPago.Click

        Me.txt_valorPago.SelectAll()

    End Sub

    Private Sub txt_valorDesconto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valorDesconto.Click

        Me.txt_valorDesconto.SelectAll()

    End Sub

    Private Sub txt_acrescimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_juros.Click

        Me.txt_juros.SelectAll()

    End Sub

    Private Sub Frm_BaixaFinancRMp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub txt_valorPago_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valorPago.Leave


        Me.txt_juros.ReadOnly = False : Me.txt_valorDesconto.ReadOnly = False
        If IsNumeric(Me.txt_valorPago.Text) Then

            Me.txt_valorPago.Text = Format(CDec(Me.txt_valorPago.Text), "###,##0.00")

            If CDbl(Me.txt_valorPago.Text) > _valorCorrente Then

                If CDbl(Me.txt_juros.Text) = 0 Then

                    Me.txt_juros.Text = Format(Round((CDec(Me.txt_valorPago.Text) - _valorCorrente), 2), "###,##0.00")
                End If
                Me.txt_valorDesconto.ReadOnly = True

            ElseIf (CDbl(Me.txt_valorPago.Text) < _valorCorrente) AndAlso (CDbl(Me.txt_valorPago.Text) > 0) Then

                If CDbl(Me.txt_valorDesconto.Text) = 0 Then

                    Me.txt_valorDesconto.Text = Format(Round((_valorCorrente - CDec(Me.txt_valorPago.Text)), 2), "###,##0.00")
                End If
                Me.txt_juros.ReadOnly = True
            End If

        Else
            Me.txt_valorPago.Text = Format(0.0, "###,##0.00")
        End If



    End Sub

    Private Sub txt_valorDesconto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valorDesconto.Leave

        If IsNumeric(Me.txt_valorDesconto.Text) Then

            Me.txt_valorDesconto.Text = Format(CDec(Me.txt_valorDesconto.Text), "###,##0.00")

        Else
            Me.txt_valorDesconto.Text = Format(0.0, "###,##0.00")
        End If



    End Sub

    Private Sub txt_acrescimo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_juros.Leave

        If IsNumeric(Me.txt_juros.Text) Then

            Me.txt_juros.Text = Format(CDec(Me.txt_juros.Text), "###,##0.00")

        Else
            Me.txt_juros.Text = Format(0.0, "###,##0.00")
        End If



    End Sub

    Private Sub btn_finalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalizar.Click

        btn_finalizar.Enabled = False : Me.Close()

    End Sub

    Private Sub Frm_BaixaFinancRMp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        '_NumDocumento = String.Format("{0:D9}", Convert.ToInt32(_frmRetorVendas._frmREf.txt_numPedido.Text))
        '_CodLoja = _frmRetorVendas._frmREf.cbo_local.SelectedItem
        '_CodigoParticipante = _frmRetorVendas._frmREf.txt_codPart.Text
        '_NomeParticipante = _frmRetorVendas._frmREf.txt_nomePart.Text
        RDbContAtual.Checked = False : RDbContAtual.Checked = True

    End Sub

    Private Sub preencheDtgDocumento()

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlPart As New StringBuilder
        Dim drPart As NpgsqlDataReader
        Dim cmdPart As NpgsqlCommand

        Try
            If RDbContAtual.Checked Then

                sqlPart.Append("SELECT cad.p_portad, ft.f_tipo, ft.f_sit, ft.f_duplic, to_char(ft.f_emiss, 'dd/MM/yyyy'), ") '
                sqlPart.Append("to_char(ft.f_vencto, 'dd/MM/yyyy'), ft.f_valor FROM " & MdlEmpresaUsu._esqEstab & ".") '5
                sqlPart.Append("fatd001 ft LEFT JOIN cadp001 cad ON cad.p_cod = ft.f_portad WHERE ft.f_portad = '")
                sqlPart.Append(_CodigoParticipante & "' AND ft.f_nfat = '" & _NumDocumento & "' AND ft.f_geno = 'G00" & _CodLoja & "' ORDER BY ft.f_emiss") '

                cmdPart = New NpgsqlCommand(sqlPart.ToString, oConnBDGENOV)
                drPart = cmdPart.ExecuteReader

                Me.dtg_documentos.Rows.Clear() : Me.dtg_documentos.Refresh()
                Me.dtg_documentos.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque

                While drPart.Read

                    dtg_documentos.Rows.Add(drPart(0).ToString, drPart(1).ToString, drPart(2).ToString, _
                                            drPart(3).ToString, drPart(4).ToString, drPart(5).ToString, _
                                            drPart(6).ToString)
                    _valorCorrente = Round(drPart(6), 2)
                    _dtEmiss = drPart(4).ToString
                    _tipo = drPart(1).ToString
                End While
                drPart.Close() : dtg_documentos.Refresh() : cmdPart.CommandText = ""
            Else

                sqlPart.Append("SELECT cad.p_portad, ft.f_tipo, ft.f_sit, ft.f_duplic, to_char(ft.f_emiss, 'dd/MM/yyyy'), ") '
                sqlPart.Append("to_char(ft.f_vencto, 'dd/MM/yyyy'), ft.f_valor FROM " & MdlEmpresaUsu._esqEstab & ".") '5
                sqlPart.Append("fatd001 ft LEFT JOIN cadp001 cad ON cad.p_cod = ft.f_portad WHERE ft.f_portad = '")
                sqlPart.Append(_CodigoParticipante & "' AND ft.f_sit = 'N' AND ft.f_geno = 'G00" & _CodLoja & "' ORDER BY ft.f_emiss") '

                cmdPart = New NpgsqlCommand(sqlPart.ToString, oConnBDGENOV)
                drPart = cmdPart.ExecuteReader

                Me.dtg_documentos.Rows.Clear() : Me.dtg_documentos.Refresh()
                Me.dtg_documentos.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque

                While drPart.Read

                    dtg_documentos.Rows.Add(drPart(0).ToString, drPart(1).ToString, drPart(2).ToString, _
                                            drPart(3).ToString, drPart(4).ToString, drPart(5).ToString, _
                                            drPart(6).ToString)
                End While
                drPart.Close() : dtg_documentos.Refresh() : cmdPart.CommandText = ""
            End If

            
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        sqlPart.Remove(_valorZERO, sqlPart.ToString.Length)

        'LIMPA OBJETOS DA MEMÓRIA...
        cmdPart = Nothing : sqlPart = Nothing : drPart = Nothing : Me.dtg_documentos.Focus()
        oConnBDGENOV.Close() : oConnBDGENOV = Nothing



    End Sub

    Private Sub Baixa_dupIndividual_Total(ByVal Ndupl As String, ByVal TipoPgto As String, ByVal DTPaga As Date, ByVal Juros As Double, _
                      ByVal Desconto As Double, ByVal ValorPago As Double, ByVal ValorDup As Double, ByVal conexao As String)

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim oCmd As NpgsqlCommand
        Dim Mconsulta As Boolean = False

        Dim strSQL As New StringBuilder
        Try
            strSQL.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".fatd001 SET ")
            strSQL.Append("f_dtpaga=@f_dtpaga, f_juros=@f_juros, f_desc=@f_desc, f_sit=@f_sit, f_valor = @f_valor ")
            strSQL.Append("WHERE f_duplic='" & Ndupl & "' and f_geno='G00" & _CodLoja & "'")

            oCmd = New NpgsqlCommand(strSQL.ToString, oConn)
            Juros = 0.0 : Desconto = 0.0
            If ValorPago > ValorDup Then
                Juros = Round((ValorPago - ValorDup), 2)
            ElseIf ValorPago = ValorDup Then
                Juros = 0.0 : Desconto = 0.0
            Else
                Desconto = Round((ValorDup - ValorPago), 2)
            End If
            oCmd.Parameters.Add("@f_dtpaga", Convert.ChangeType(DTPaga, GetType(Date)))
            oCmd.Parameters.Add("@f_juros", Juros)
            oCmd.Parameters.Add("@f_desc", Desconto)
            oCmd.Parameters.Add("@f_sit", "L".ToString)
            oCmd.Parameters.Add("@f_valor", ValorDup)

            oConn.Open()
            oCmd.CommandText = strSQL.ToString
            oCmd.ExecuteNonQuery()
            oConn.Close()
        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try


    End Sub

    Private Sub Baixa_dupIndividual_Parcial(ByVal CdPort As String, ByVal Ndupl As String, ByVal SaldoConta As Double, ByVal conexao As String)

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim oCmd As NpgsqlCommand
        Dim Mconsulta As Boolean = False

        Dim strSQL As New StringBuilder
        Try
            strSQL.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".fatd001 SET ")
            strSQL.Append("f_valor=@f_valor WHERE f_geno='G00" & _CodLoja & "' and f_portad=f_portad and ")
            strSQL.Append("f_duplic='" & Ndupl.ToString & "'")

            oCmd = New NpgsqlCommand(strSQL.ToString, oConn)

            oCmd.Parameters.Add("@f_valor", SaldoConta)
            oCmd.Parameters.Add("@f_portad", CdPort)

            oConn.Open()
            oCmd.CommandText = strSQL.ToString
            oCmd.ExecuteNonQuery()
            oConn.Close()
        Catch ex As Exception
            MsgBox("Erro " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro")
        End Try
    End Sub

    Private Sub dtg_documentos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtg_documentos.DoubleClick

        If dtg_documentos.CurrentRow.IsNewRow = False Then

            Me.txt_documento.Text = dtg_documentos.CurrentRow.Cells(3).Value.ToString
            _valorCorrente = dtg_documentos.CurrentRow.Cells(6).Value.ToString
            _dtEmiss = dtg_documentos.CurrentRow.Cells(4).Value.ToString
            _tipo = dtg_documentos.CurrentRow.Cells(1).Value.ToString
        End If

    End Sub

End Class