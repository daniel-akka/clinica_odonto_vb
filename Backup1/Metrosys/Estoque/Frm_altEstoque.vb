Imports Npgsql
Imports System.Text
Imports System.Data
Imports System.Math

Public Class Frm_altEstoque

    Private Const _valorZERO As Integer = 0
    Private _clBD As New Cl_bdMetrosys
    Private _clFuncoes As New ClFuncoes
    Private _local As String = Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2)
    Private _localAux As String = Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2)
    Private _codProd As String = "", _codPart As String = ""
    Private _alterando As Boolean = False, _incluindo As Boolean = False
    Private _idVinculo As Int16 = MdlEmpresaUsu._vinculo
    Public Shared _frmRef As New Frm_altEstoque
    Public _privilegio As Boolean = False, _privilegioGerente As Boolean = False
    Public _nomeGerente As String = "", _usuarioPrivilegio As String = ""
    Public _privilegioLojas As Boolean = False



    Private Sub Frm_altEstoque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim frmLoginGerente As New FrmLoginGerente
        _frmRef = Me
        frmLoginGerente.set_frmRef(Me)
        frmLoginGerente.ShowDialog()

        If _privilegioGerente = False Then Me.Close() : Me.Dispose()

        preencheDtg_Produto()

        cbo_loja = _clFuncoes.PreenchComboLojaVinculo(_idVinculo, cbo_loja, MdlConexaoBD.conectionPadrao)
        cbo_vinculo = _clFuncoes.PreenchComboVinculo(cbo_vinculo, MdlConexaoBD.conectionPadrao)

        cbo_vinculo.SelectedIndex = _clFuncoes.trazIndexCboVinculo(_idVinculo, cbo_vinculo)

    End Sub

    Private Sub Frm_altEstoque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                executeF5()

            Case Keys.F2
                executeF2()

            Case Keys.F3
                executeF3()

        End Select
    End Sub

    Private Sub executeF5()

        preencheDtg_Produto()
    End Sub

    Private Sub executeF2()

        If dtg_produto.CurrentRow.IsNewRow = False Then

            _codProd = dtg_produto.CurrentRow.Cells(_valorZERO).Value
            _codPart = dtg_produto.CurrentRow.Cells(4).Value
            tbc_produtos.SelectTab(1)


            If cbo_loja.SelectedIndex < _valorZERO Then

                cbo_loja.SelectedIndex = _valorZERO
                _local = Mid(cbo_loja.SelectedItem, 1, 2)

                trazProdutoSelecionado()
                preencheDtg_Saldos(_codProd)
            Else

                _local = Mid(cbo_loja.SelectedItem, 1, 2)
                trazProdutoSelecionado()
                preencheDtg_Saldos(_codProd)
            End If

            _incluindo = True : _alterando = False : Btn_salvar.Enabled = True
        End If

    End Sub

    Private Sub executeF3()

        If dtg_produto.CurrentRow.IsNewRow = False Then

            _codProd = dtg_produto.CurrentRow.Cells(_valorZERO).Value
            tbc_produtos.SelectTab(1)


            If cbo_loja.SelectedIndex < _valorZERO Then

                cbo_loja.SelectedIndex = _valorZERO
                _local = Mid(cbo_loja.SelectedItem, 1, 2)

                trazProdutoSelecionado()
                preencheDtg_Saldos(_codProd)
            Else

                _local = Mid(cbo_loja.SelectedItem, 1, 2)
                trazProdutoSelecionado()
                preencheDtg_Saldos(_codProd)
            End If

            _alterando = True : _incluindo = False : Btn_salvar.Enabled = True
        End If

    End Sub

    Private Sub Frm_altEstoque_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub preencheDtg_Produto()

        Dim nomeCampo As String = ""
        Dim pesquisa As String = (Me.txt_pesquisa.Text).ToUpper
        Me.lbl_mensagem01.Text = ".  "

        If Me.rdb_barra.Checked = True Then

            nomeCampo = "e_cdbarra"
        ElseIf Me.Rdb_codigo.Checked = True Then
            nomeCampo = "e_codig"
        Else
            nomeCampo = "e_produt"
        End If

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim da As NpgsqlDataAdapter
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader

        Try

            oConnBDMETROSYS.Open()
        Catch ex As Exception
            Me.lbl_mensagem01.Text = "Erro:: " & ex.Message & " !"
        End Try


        Dim codigo, nome, qtdEstoque, undMedida, codPart As String

        Try

            SqlProduto.Append("SELECT e.e_codig, e.e_produt, el.e_qtde, e.e_und, e.e_cdport, el.e_qtdfisc ") ' 5
            SqlProduto.Append("FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN estloja01 el ON e.e_codig = el.e_codig WHERE ")
            SqlProduto.Append("e.e_materiaprima = " & Me.chk_MPrima.Checked & " AND ")
            SqlProduto.Append("el.e_loja = '" & _local & "' AND el.e_idvinculo = " & _idVinculo & " AND ")
            If Me.rdb_barra.Checked = True Then
                SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE @pesquisa ORDER BY e.e_produt ASC")
            ElseIf Rdb_codigo.Checked = True Then
                SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE @pesquisa ORDER BY e.e_produt ASC")
            Else
                SqlProduto.Append("UPPER(e." & nomeCampo & ") LIKE @pesquisa ORDER BY e.e_produt ASC")
            End If


            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDMETROSYS)

            If Me.rdb_barra.Checked = True Then

                CmdProduto.Parameters.Add("@pesquisa", pesquisa & "%")
            ElseIf Rdb_codigo.Checked = True Then

                CmdProduto.Parameters.Add("@pesquisa", "%" & pesquisa)
            Else
                CmdProduto.Parameters.Add("@pesquisa", pesquisa & "%")
            End If

            da = New NpgsqlDataAdapter(SqlProduto.ToString, oConnBDMETROSYS)
            drProduto = CmdProduto.ExecuteReader
            dtg_produto.Rows.Clear()
            While drProduto.Read
                codigo = drProduto(_valorZERO).ToString
                nome = drProduto(1).ToString
                Try
                    qtdEstoque = CDbl(drProduto(2))
                Catch ex As Exception
                    qtdEstoque = "0,00"
                End Try

                undMedida = drProduto(3).ToString
                codPart = drProduto(4).ToString

                dtg_produto.Rows.Add(codigo, nome, Format(CDbl(qtdEstoque), "###,##0.00"), undMedida, codPart)

            End While

            drProduto.Close()
        Catch ex As Exception
            Me.lbl_mensagem01.Text = "Erro:: " & ex.Message & " !"

        Finally

            CmdProduto.CommandText = ""
            SqlProduto.Remove(0, SqlProduto.ToString.Length)
            da = Nothing : CmdProduto = Nothing : SqlProduto = Nothing
            drProduto = Nothing : oConnBDMETROSYS.ClearAllPools()
            If oConnBDMETROSYS.State = ConnectionState.Open Then oConnBDMETROSYS.Close()
            oConnBDMETROSYS = Nothing
        End Try



    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        preencheDtg_Produto()

    End Sub

    Private Sub chk_MPrima_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_MPrima.CheckedChanged

        preencheDtg_Produto()

    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        executeF3()

    End Sub

    Private Sub trazProdutoSelecionado()

        Dim codProduto As String = ""
        codProduto = dtg_produto.CurrentRow.Cells(0).Value

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS") : Return
        End Try


        Dim mcodig As String, mprodut As String, mund As String
        Dim mqtde As Double, mpcusto As Double, mpvenda As Double, mvprom As Double
        Dim mqtdfisc As Double, minventa As Double, mpcustom As Double, mpcustoa As Double
        Dim mpcomp As Double, mdtcomp As String, mdtvend As String, mpvend15 As Double, mpvend30 As Double
        Dim mpcompa As Double

        mcodig = "" : mprodut = "" : mund = "" : mdtcomp = "" : mdtvend = ""

        mqtde = _valorZERO : mpcusto = _valorZERO : mpvenda = _valorZERO
        mvprom = _valorZERO : mqtdfisc = _valorZERO : minventa = _valorZERO
        mpcustom = _valorZERO : mpcustoa = _valorZERO : mpcomp = _valorZERO
        mpvend15 = _valorZERO : mpvend30 = _valorZERO : mpcompa = _valorZERO


        Try
            SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_und, el.e_dtvend, e.e_dtcomp, el.e_qtde, ") '18
            SqlProduto.Append("el.e_qtdfisc, el.e_pvenda, el.e_pcusto, el.e_vprom, el.e_pcomp, el.e_pcustoa, ") '24
            SqlProduto.Append("el.e_pcustom, el.e_pcompa, el.e_pvend15, el.e_pvend30, el.e_inventa ") '30
            SqlProduto.Append("FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN estloja01 el ON e.e_codig = el.e_codig WHERE ")
            SqlProduto.Append("el.e_codig = '" & _codProd & "' AND el.e_loja = '" & _local & "' AND el.e_idvinculo = " & _idVinculo)

            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDMETROSYS)
            drProduto = CmdProduto.ExecuteReader

            While drProduto.Read

                mcodig = drProduto(0).ToString : mprodut = drProduto(1).ToString
                mund = drProduto(2).ToString
                'Date
                mdtcomp = drProduto(3).ToString : mdtvend = drProduto(4).ToString

                mqtde = drProduto(5) : mqtdfisc = drProduto(6)
                mpvenda = drProduto(7) : mpcusto = drProduto(8)
                mvprom = drProduto(9) : mpcomp = drProduto(10)
                mpcustoa = drProduto(11) : mpcustom = drProduto(12)
                mpcompa = drProduto(13) : mpvend15 = drProduto(14)
                mpvend30 = drProduto(15) : minventa = drProduto(16)


                txt_codigo.Text = mcodig
                txt_descricao.Text = mprodut
                txt_und.Text = mund

                Try
                    Me.Msk_dtcomp.Text = Format(CDate(mdtcomp), "ddMMyyyy")
                Catch ex As Exception
                    Me.Msk_dtcomp.Text = ""
                End Try

                Try
                    Me.msk_dtvenda.Text = Format(CDate(mdtvend), "ddMMyyyy")
                Catch ex As Exception
                    Me.msk_dtvenda.Text = ""
                End Try

                txt_qtde.Text = Format(mqtde, "###,##0.00")
                txt_qtdeFisc.Text = Format(mqtdfisc, "###,##0.00")
                txt_pvenda.Text = Format(mpvenda, "###,##0.00")
                txt_pcusto.Text = Format(mpcusto, "###,##0.00")
                txt_vpromocao.Text = Format(mvprom, "###,##0.00")
                txt_pcompra.Text = Format(mpcomp, "###,##0.00")
                txt_pcustoa.Text = Format(mpcustoa, "###,##0.00")
                txt_pcustom.Text = Format(mpcustom, "###,##0.00")
                txt_pcompa.Text = Format(mpcompa, "###,##0.00")
                txt_pvend15.Text = Format(mpvend15, "###,##0.00")
                txt_pvend30.Text = Format(mpvend30, "###,##0.00")
                txt_inventa.Text = Format(minventa, "###,##0.00")


            End While

            drProduto.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")

        Finally

            CmdProduto.CommandText = "" : SqlProduto.Remove(0, SqlProduto.ToString.Length)
            drProduto = Nothing : CmdProduto = Nothing : oConnBDMETROSYS.ClearAllPools()
            If oConnBDMETROSYS.State = ConnectionState.Open Then oConnBDMETROSYS.Close()
            oConnBDMETROSYS = Nothing
        End Try

        



    End Sub

    Private Sub trazProdutoSelecionadoLoja()

        Dim oConnBDMETROSYS As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim CmdProduto As New NpgsqlCommand
        Dim SqlProduto As New StringBuilder
        Dim drProduto As NpgsqlDataReader

        Try
            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS") : Return
        End Try


        Dim mcodig As String, mprodut As String, mund As String
        Dim mqtde As Double, mpcusto As Double, mpvenda As Double, mvprom As Double
        Dim mqtdfisc As Double, minventa As Double, mpcustom As Double, mpcustoa As Double
        Dim mpcomp As Double, mdtcomp As Date, mdtvend As Date, mpvend15 As Double, mpvend30 As Double
        Dim mpcompa As Double, mvalid As Date

        mcodig = "" : mprodut = "" : mund = ""

        mqtde = _valorZERO : mpcusto = _valorZERO : mpvenda = _valorZERO
        mvprom = _valorZERO : mqtdfisc = _valorZERO : minventa = _valorZERO
        mpcustom = _valorZERO : mpcustoa = _valorZERO : mpcomp = _valorZERO
        mpvend15 = _valorZERO : mpvend30 = _valorZERO : mpcompa = _valorZERO


        Try
            SqlProduto.Append("SELECT e.e_codig, e.e_produt, e.e_und, el.e_dtvend, e.e_dtcomp, el.e_qtde, ") '5
            SqlProduto.Append("el.e_qtdfisc, el.e_pvenda, el.e_pcusto, el.e_vprom, el.e_pcomp, el.e_pcustoa, ") '11
            SqlProduto.Append("el.e_pcustom, el.e_pcompa, el.e_pvend15, el.e_pvend30, el.e_inventa, el.e_valid ") '17
            SqlProduto.Append("FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN estloja01 el ON e.e_codig = el.e_codig WHERE ")
            SqlProduto.Append("el.e_codig = '" & _codProd & "' AND el.e_loja = '" & _localAux & "' AND el.e_idvinculo = " & _idVinculo)

            CmdProduto = New NpgsqlCommand(SqlProduto.ToString, oConnBDMETROSYS)
            drProduto = CmdProduto.ExecuteReader

            While drProduto.Read

                mcodig = drProduto(0).ToString : mprodut = drProduto(1).ToString
                mund = drProduto(2).ToString

                Try
                    'Date
                    mdtcomp = drProduto(3).ToString
                Catch ex As Exception
                End Try

                Try
                    'Date
                    mdtvend = drProduto(4).ToString
                Catch ex As Exception
                End Try


                mqtde = drProduto(5) : mqtdfisc = drProduto(6)
                mpvenda = drProduto(7) : mpcusto = drProduto(8)
                mvprom = drProduto(9) : mpcomp = drProduto(10)
                mpcustoa = drProduto(11) : mpcustom = drProduto(12)
                mpcompa = drProduto(13) : mpvend15 = drProduto(14)
                mpvend30 = drProduto(15) : minventa = drProduto(16)

                Try
                    'Date
                    mvalid = CDate(drProduto(17))
                Catch ex As Exception
                End Try


                txt_codigo.Text = mcodig
                txt_descricao.Text = mprodut
                txt_und.Text = mund

                Try
                    Me.Msk_dtcomp.Text = CDate(mdtcomp.ToString("d"))
                    If IsDate(Me.Msk_dtcomp.Text) Then
                        Me.Msk_dtcomp.Text = Format(mdtcomp, "ddMMyyyy")
                    Else
                        Me.Msk_dtcomp.Text = ""
                    End If

                Catch ex As Exception
                    Me.Msk_dtcomp.Text = ""
                End Try

                Try
                    Me.msk_dtvenda.Text = CDate(mdtvend.ToString("d"))
                    If IsDate(Me.msk_dtvenda.Text) Then
                        Me.msk_dtvenda.Text = Format(mdtcomp, "ddMMyyyy")
                    Else
                        Me.msk_dtvenda.Text = ""
                    End If

                Catch ex As Exception
                    Me.msk_dtvenda.Text = ""
                End Try

                txt_qtde.Text = Format(mqtde, "###,##0.00")
                txt_qtdeFisc.Text = Format(mqtdfisc, "###,##0.00")
                txt_pvenda.Text = Format(mpvenda, "###,##0.00")
                txt_pcusto.Text = Format(mpcusto, "###,##0.00")
                txt_vpromocao.Text = Format(mvprom, "###,##0.00")
                txt_pcompra.Text = Format(mpcomp, "###,##0.00")
                txt_pcustoa.Text = Format(mpcustoa, "###,##0.00")
                txt_pcustom.Text = Format(mpcustom, "###,##0.00")
                txt_pcompa.Text = Format(mpcompa, "###,##0.00")
                txt_pvend15.Text = Format(mpvend15, "###,##0.00")
                txt_pvend30.Text = Format(mpvend30, "###,##0.00")
                txt_inventa.Text = Format(minventa, "###,##0.00")

                Try
                    Me.msk_valid.Text = CDate(mvalid.ToString("d"))
                    If IsDate(Me.msk_valid.Text) Then
                        Me.msk_valid.Text = Format(mvalid, "ddMMyyyy")
                    Else
                        Me.msk_valid.Text = ""
                    End If

                Catch ex As Exception
                    Me.msk_dtvenda.Text = ""
                End Try


            End While

            drProduto.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical, "METROSYS")

        Finally

            CmdProduto.CommandText = "" : SqlProduto.Remove(0, SqlProduto.ToString.Length)
            drProduto = Nothing : CmdProduto = Nothing : oConnBDMETROSYS.ClearAllPools()
            If oConnBDMETROSYS.State = ConnectionState.Open Then oConnBDMETROSYS.Close()
            oConnBDMETROSYS = Nothing
        End Try



    End Sub

    Private Sub preencheDtg_Saldos(ByVal codProduto As String)

        Dim oConnBDMETROSYS As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim daSaldos As NpgsqlDataAdapter
        Dim CmdProduto As New NpgsqlCommand
        Dim cmdSaldos As New NpgsqlCommand
        Dim sqlSaldos As New StringBuilder
        Dim drSaldos As NpgsqlDataReader

        Try

            oConnBDMETROSYS.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message) : Return
        End Try


        Dim codigo, sldAtual, pcoVenda As String

        Try

            sqlSaldos.Append("SELECT el.e_loja, el.e_qtde, el.e_pvenda ")
            sqlSaldos.Append("FROM " & MdlEmpresaUsu._esqVinc & ".est0001 e JOIN estloja01 el ON e.e_codig ")
            sqlSaldos.Append("= el.e_codig WHERE el.e_codig = @e_codig AND el.e_idvinculo = " & _idVinculo)
            CmdProduto = New NpgsqlCommand(sqlSaldos.ToString, oConnBDMETROSYS)

            CmdProduto.Parameters.Add("@e_codig", codProduto)

            daSaldos = New NpgsqlDataAdapter(sqlSaldos.ToString, oConnBDMETROSYS)
            drSaldos = CmdProduto.ExecuteReader
            dtg_saldos.Rows.Clear()
            While drSaldos.Read
                codigo = drSaldos(0).ToString
                sldAtual = Format(CDbl(drSaldos(1)), "###,##0.00")
                pcoVenda = Format(drSaldos(2), "###,##0.00")

                dtg_saldos.Rows.Add(codigo, sldAtual, pcoVenda)

            End While

            dtg_saldos.Refresh()
            drSaldos.Close()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message) : Return

        Finally

            CmdProduto.CommandText = "" : sqlSaldos.Remove(0, sqlSaldos.ToString.Length)
            daSaldos.Dispose() : drSaldos = Nothing : cmdSaldos = Nothing : oConnBDMETROSYS.ClearAllPools()
            If oConnBDMETROSYS.State = ConnectionState.Open Then oConnBDMETROSYS.Close()
            oConnBDMETROSYS = Nothing
        End Try



    End Sub

    Private Sub salvaProdutoIcluindo(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        Dim mcodig As String, mcdport As String, mlocacao As String
        Dim mqtde As Double, mpcusto As Double, mpvenda As Double, mvprom As Double
        Dim mqtdfisc As Double, minventa As Double, mpcustom As Double, mpcustoa As Double
        Dim mpcompa As Double, mpcomp As Double, mdtcomp As String, mdtvend As String
        Dim mpvend15 As Double, mpvend30 As Double, mvalid As Date


        mcodig = "" : mdtcomp = "" : mdtvend = "" : mlocacao = ""
        mqtde = _valorZERO : mpcusto = _valorZERO : mpvenda = _valorZERO : mvprom = _valorZERO
        mqtdfisc = _valorZERO : minventa = _valorZERO : mpcustom = _valorZERO : mpcustoa = _valorZERO
        mpcomp = _valorZERO : mpvend15 = _valorZERO : mpvend30 = _valorZERO

        mcodig = txt_codigo.Text : mcdport = _codPart : mlocacao = Me.txt_locacao.Text
        mqtde = Format(CDbl(txt_qtde.Text), "###,##0.00")
        mqtdfisc = Format(CDbl(txt_qtdeFisc.Text), "###,##0.00")
        mpvenda = Format(CDbl(txt_pvenda.Text), "###,##0.00")
        mpcusto = Format(CDbl(txt_pcusto.Text), "###,##0.00")
        mvprom = Format(CDbl(txt_vpromocao.Text), "###,##0.00")
        mpcomp = Format(CDbl(txt_pcompra.Text), "###,##0.00")
        mpcustoa = Format(CDbl(txt_pcustoa.Text), "###,##0.00")
        mpcustom = Format(CDbl(txt_pcustom.Text), "###,##0.00")
        mpcompa = Format(CDbl(txt_pcompa.Text), "###,##0.00")
        mpvend15 = Format(CDbl(txt_pvend15.Text), "###,##0.00")
        mpvend30 = Format(CDbl(txt_pvend30.Text), "###,##0.00")
        minventa = Format(CDbl(txt_inventa.Text), "###,##0.00")

        Try
            mvalid = CDate(Me.msk_valid.Text)
        Catch ex As Exception
        End Try


        _clBD.incEstloja(_local, MdlEmpresaUsu._vinculo, mcodig, mcdport, mqtde, mpcusto, mpvenda, mvprom, _
                         mqtdfisc, minventa, mpcustom, mpcustoa, mpcomp, mdtcomp, mdtvend, mpvend15, mpvend30, _
                         mpcustoa, mlocacao, mvalid, conection, transacao)


    End Sub

    Private Sub salvaProdutoAlterando(ByRef conection As NpgsqlConnection, ByRef transacao As NpgsqlTransaction)

        Dim mcodig As String, mlocacao As String, mNomeGerente As String, mNomeEstoquista As String
        Dim mqtde As Double, mpcusto As Double, mpvenda As Double, mvprom As Double
        Dim mqtdfisc As Double, minventa As Double, mpcustom As Double, mpcustoa As Double
        Dim mpcompa As Double, mpcomp As Double, mdtcomp As String, mdtvend As String
        Dim mpvend15 As Double, mpvend30 As Double, mvalid As Date


        mcodig = "" : mlocacao = "" : mNomeGerente = "" : mNomeEstoquista = "" : mlocacao = Me.txt_locacao.Text
        mqtde = _valorZERO : mpcusto = _valorZERO : mpvenda = _valorZERO : mvprom = _valorZERO
        mqtdfisc = _valorZERO : minventa = _valorZERO : mpcustom = _valorZERO : mpcustoa = _valorZERO
        mpcomp = _valorZERO : mpvend15 = _valorZERO : mpvend30 = _valorZERO

        mcodig = txt_codigo.Text
        mqtde = Format(CDbl(txt_qtde.Text), "###,##0.00")
        mqtdfisc = Format(CDbl(txt_qtdeFisc.Text), "###,##0.00")
        mpvenda = Format(CDbl(txt_pvenda.Text), "###,##0.00")
        mpcusto = Format(CDbl(txt_pcusto.Text), "###,##0.00")
        mvprom = Format(CDbl(txt_vpromocao.Text), "###,##0.00")
        mpcomp = Format(CDbl(txt_pcompra.Text), "###,##0.00")
        mpcustoa = Format(CDbl(txt_pcustoa.Text), "###,##0.00")
        mpcustom = Format(CDbl(txt_pcustom.Text), "###,##0.00")
        mpcompa = Format(CDbl(txt_pcompa.Text), "###,##0.00")
        mpvend15 = Format(CDbl(txt_pvend15.Text), "###,##0.00")
        mpvend30 = Format(CDbl(txt_pvend30.Text), "###,##0.00")
        minventa = Format(CDbl(txt_inventa.Text), "###,##0.00")

        Try
            mvalid = CDate(Me.msk_valid.Text)
        Catch ex As Exception
        End Try

        If Me._nomeGerente.Equals("") = False Then

            mNomeGerente = Trim((Me._nomeGerente & " " & DateTime.Now))
        End If

        If Me._usuarioPrivilegio.Equals("") = False Then

            mNomeEstoquista = Trim((Me._usuarioPrivilegio & " " & DateTime.Now))
        End If

        _clBD.altEstlojaSaldos(_local, mcodig, mqtde, mpcusto, mpvenda, mvprom, mqtdfisc, _
                        minventa, mpcustom, mpcustoa, mpcomp, mpvend15, mpvend30, _
                        mpcompa, mlocacao, mNomeGerente, mNomeEstoquista, mvalid, conection, transacao)

    End Sub

    Private Sub btn_salvar_Click_Incluindo()

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
            If _clBD.existeProdEstloja01(_codProd, _local, conection) Then

                MsgBox("Produto já existe nesta LOJA, não precisa incluir", MsgBoxStyle.Exclamation)
                conection.Close() : conection = Nothing : transacao = Nothing
                Return
            End If

            transacao = conection.BeginTransaction

            salvaProdutoIcluindo(conection, transacao)

            transacao.Commit() : conection.ClearAllPools()

            If MessageBox.Show("Produto salvo com sucesso! Deseja continuar incluido?", "METROSYS", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False
                Btn_salvar.Enabled = True
                txt_descricao.Text = ""
                txt_codigo.Text = String.Format("{0:D5}", _clBD.trazProxCodProd(conection))
                txt_codigo.Focus()
                conection.Close() : transacao = Nothing : conection = Nothing
            Else

                _incluindo = False : _alterando = False
                Btn_salvar.Enabled = False
                tbc_produtos.SelectTab(0)

                zeraValoresProduto()

                preencheDtg_Produto()
                txt_pesquisa.Focus()
                conection.Close() : transacao = Nothing : conection = Nothing
            End If

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()
                conection.Close() : conection.ClearAllPools() : transacao = Nothing : conection = Nothing
            Catch ex1 As Exception
                conection.Close() : conection.ClearAllPools() : transacao = Nothing : conection = Nothing
            End Try
        End Try


    End Sub

    Private Sub btn_salvar_Click_Alterando()

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            conection.Open()
            transacao = conection.BeginTransaction

            salvaProdutoAlterando(conection, transacao)

            transacao.Commit() : conection.ClearAllPools()

            MsgBox("Produto salvo com sucesso", MsgBoxStyle.Exclamation)

            _incluindo = False : _alterando = False
            Btn_salvar.Enabled = False
            tbc_produtos.SelectTab(0)

            zeraValoresProduto()
            preencheDtg_Produto()
            txt_pesquisa.Focus()


        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()
            Catch ex1 As Exception
            End Try

        Finally

            If conection.State = ConnectionState.Open Then conection.Close()
            transacao = Nothing : conection = Nothing
        End Try


    End Sub

    Private Sub Btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_salvar.Click

        If verifCamposProduto() = True Then

            If _incluindo = True Then

                btn_salvar_Click_Incluindo()
            ElseIf _alterando = True Then

                btn_salvar_Click_Alterando()
            End If
        End If


    End Sub

    Private Function verifCamposProduto() As Boolean

        lbl_mensagem02.Text = ""
        'CodProd
        If Trim(txt_codigo.Text).Equals("") Then
            lbl_mensagem02.Text = "Codigo do Produto em Branco !"
            Return False
        End If

        'Nome Prod
        If Trim(txt_descricao.Text).Equals("") Then
            lbl_mensagem02.Text = "Descricao do Produto em Branco !"
            Return False
        End If

        ''Validade Prod
        'If IsDate(Trim(msk_valid.Text).Equals("")) = False Then
        '    lbl_mensagem02.Text = "Validade do Produto não é Data !"
        '    Return False
        'End If

        'qtde
        If Not IsNumeric(txt_qtde.Text) Then
            lbl_mensagem02.Text = "Quantidade Real não é número !"
            Return False
        ElseIf CDbl(txt_qtde.Text) < _valorZERO Then
            lbl_mensagem02.Text = "Quantidade Real deve ser maior ou igual a ZERO !"
            Return False
        End If

        'qtdefisc
        If Not IsNumeric(txt_qtdeFisc.Text) Then
            lbl_mensagem02.Text = "Quantidade Fiscal não é número !"
            Return False
        ElseIf CDbl(txt_qtdeFisc.Text) < _valorZERO Then
            lbl_mensagem02.Text = "Quantidade Fiscal deve ser maior ou igual a ZERO !"
            Return False
        End If

        'pvenda
        If Not IsNumeric(txt_pvenda.Text) Then
            lbl_mensagem02.Text = "Preço de Venda não é número !"
            Return False
        ElseIf CDbl(txt_pvenda.Text) < _valorZERO Then
            lbl_mensagem02.Text = "Preço de Venda deve ser maior ou igual a ZERO !"
            Return False
        End If

        'pcusto
        If Not IsNumeric(txt_pcusto.Text) Then
            lbl_mensagem02.Text = "Preço de Custo não é número !"
            Return False
        ElseIf CDbl(txt_pcusto.Text) < _valorZERO Then
            lbl_mensagem02.Text = "Preço de Custo deve ser maior ou igual a ZERO !"
            Return False
        End If

        'vprom
        If Not IsNumeric(txt_vpromocao.Text) Then
            lbl_mensagem02.Text = "Valor da Promoção não é número !"
            Return False
        ElseIf CDbl(txt_vpromocao.Text) < _valorZERO Then
            lbl_mensagem02.Text = "Valor da Promoção deve ser maior ou igual a ZERO !"
            Return False
        End If

        'pcompa
        If Not IsNumeric(txt_pcompra.Text) Then
            lbl_mensagem02.Text = "Preço de Compra não é número !"
            Return False
        ElseIf CDbl(txt_pcompra.Text) < _valorZERO Then
            lbl_mensagem02.Text = "Preço de Compra deve ser maior ou igual a ZERO !"
            Return False
        End If

        'pcustoa
        If Not IsNumeric(txt_pcustoa.Text) Then
            lbl_mensagem02.Text = "Preço de Custo Anterior não é número !"
            Return False
        ElseIf CDbl(txt_pcustoa.Text) < _valorZERO Then
            lbl_mensagem02.Text = "Preço de Custo Anterior deve ser maior ou igual a ZERO !"
            Return False
        End If

        'pcustom
        If Not IsNumeric(txt_pcustom.Text) Then
            lbl_mensagem02.Text = "Preço de Custo Médio não é número !"
            Return False
        ElseIf CDbl(txt_pcustom.Text) < _valorZERO Then
            lbl_mensagem02.Text = "Preço de Custo Médio deve ser maior ou igual a ZERO !"
            Return False
        End If

        'pcompa
        If Not IsNumeric(txt_pcompa.Text) Then
            lbl_mensagem02.Text = "Preço de Compra Anterior não é número !"
            Return False
        ElseIf CDbl(txt_pcompa.Text) < _valorZERO Then
            lbl_mensagem02.Text = "Preço de Compra Anterior deve ser maior ou igual a ZERO !"
            Return False
        End If

        'pvend15
        If Not IsNumeric(txt_pvend15.Text) Then
            lbl_mensagem02.Text = "Preço de Venda 15 não é número !"
            Return False
        ElseIf CDbl(txt_pvend15.Text) < _valorZERO Then
            lbl_mensagem02.Text = "Preço de Venda 15 deve ser maior ou igual a ZERO !"
            Return False
        End If

        'pvend30
        If Not IsNumeric(txt_pvend30.Text) Then
            lbl_mensagem02.Text = "Preço de Venda 30 não é número !"
            Return False
        ElseIf CDbl(txt_pvend30.Text) < _valorZERO Then
            lbl_mensagem02.Text = "Preço de Venda 30 deve ser maior ou igual a ZERO !"
            Return False
        End If

        'inventa
        If Not IsNumeric(txt_inventa.Text) Then
            lbl_mensagem02.Text = "Valor do Inventário não é número !"
            Return False
        ElseIf CDbl(txt_inventa.Text) < _valorZERO Then
            lbl_mensagem02.Text = "Valor do Inventário deve ser maior ou igual a ZERO !"
            Return False
        End If



        Return True
    End Function

    Private Sub zeraValoresProduto()

        Me.txt_codigo.Text = ""
        Me.txt_descricao.Text = ""
        Me.txt_und.Text = ""
        Me.Msk_dtcomp.Text = ""
        Me.msk_dtvenda.Text = ""
        Me.txt_qtde.Text = "0,00"
        Me.txt_qtdeFisc.Text = "0,00"
        Me.txt_pvenda.Text = "0,00"
        Me.txt_pcusto.Text = "0,00"
        Me.txt_vpromocao.Text = "0,00"
        Me.txt_pcompra.Text = "0,00"
        Me.txt_pcustoa.Text = "0,00"
        Me.txt_pcustom.Text = "0,00"
        Me.txt_pcompa.Text = "0,00"
        Me.txt_pvend15.Text = "0,00"
        Me.txt_pvend30.Text = "0,00"
        Me.txt_inventa.Text = "0,00"
        Me.msk_valid.Text = ""
        Me.lbl_mensagem02.Text = ""
        Me.cbo_loja.SelectedIndex = -1
        Me.dtg_saldos.Rows.Clear()
        Me.dtg_saldos.Refresh()

    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        executeF2()

    End Sub

    Private Sub cbo_loja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_loja.GotFocus

        If Me.cbo_loja.DroppedDown = False Then Me.cbo_loja.DroppedDown = True
    End Sub

    Private Sub cbo_loja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_loja.SelectedIndexChanged

        If Me.cbo_loja.SelectedIndex < _valorZERO Then Return
        If Me.cbo_loja.SelectedIndex >= _valorZERO Then _local = Trim(Mid(Me.cbo_loja.SelectedItem, 1, 2))
        If Me.cbo_loja.SelectedIndex >= _valorZERO Then _localAux = Trim(Mid(Me.cbo_loja.SelectedItem, 1, 2))
        trazProdutoSelecionadoLoja()

        If _privilegio Then

            Me.txt_locacao.ReadOnly = False
            camposSoLeitura()
        Else

            Me.txt_locacao.ReadOnly = True
            camposAtivos()
            If _localAux.Equals(Mid(MdlUsuarioLogando._local, MdlUsuarioLogando._local.Length - 1, 2)) = False Then

                If _privilegioLojas = False Then

                    camposSoLeitura()
                End If
            End If
        End If



    End Sub

    Private Sub camposSoLeitura()

        txt_qtde.ReadOnly = True
        txt_qtdeFisc.ReadOnly = True
        txt_pvenda.ReadOnly = True
        txt_pcusto.ReadOnly = True
        txt_vpromocao.ReadOnly = True
        txt_pcompra.ReadOnly = True
        txt_pcustoa.ReadOnly = True
        txt_pcustom.ReadOnly = True
        txt_pcompa.ReadOnly = True
        txt_pvend15.ReadOnly = True
        txt_pvend30.ReadOnly = True
        txt_inventa.ReadOnly = True

    End Sub

    Private Sub camposAtivos()

        txt_qtde.ReadOnly = False
        txt_qtdeFisc.ReadOnly = False
        txt_pvenda.ReadOnly = False
        txt_pcusto.ReadOnly = False
        txt_vpromocao.ReadOnly = False
        txt_pcompra.ReadOnly = False
        txt_pcustoa.ReadOnly = False
        txt_pcustom.ReadOnly = False
        txt_pcompa.ReadOnly = False
        txt_pvend15.ReadOnly = False
        txt_pvend30.ReadOnly = False
        txt_inventa.ReadOnly = False

    End Sub

    Private Sub txt_senhaGerente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If MessageBox.Show("Deseja realmente Cancelar está Operação?", "METROSYS", _
        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

            tbc_produtos.SelectTab(0)
            Me.zeraValoresProduto()
            tbp_cadPrincipal.Text = "Cadastro"
            _incluindo = False : _alterando = False
            Btn_salvar.Enabled = False
        End If



    End Sub

    Private Sub cbo_vinculo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_vinculo.SelectedIndexChanged

        _idVinculo = (Trim(Mid(cbo_vinculo.SelectedItem, 1, 2)) \ 1)
        preencheDtg_Produto()

    End Sub


    Private Sub btn_locacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_locacao.Click

        Dim frmPrivilegio As New FrmLoginPrivilegio
        frmPrivilegio.set_frmRef(Me)
        frmPrivilegio.ShowDialog()

        If _privilegio Then

            Me.txt_locacao.ReadOnly = False : Me.btn_locacao.Enabled = False
            camposSoLeitura()
        End If
    End Sub

    Private Sub txt_qtde_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtde.KeyPress

        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_qtdeFisc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_qtdeFisc.KeyPress

        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_pvenda_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pvenda.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_pcusto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pcusto.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_promocao_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_vpromocao.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_pcompra_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pcompra.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_pcustoa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pcustoa.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_pcustom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pcustom.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_pcompa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pcompa.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_pvend15_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pvend15.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_pvend30_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pvend30.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_inventa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_inventa.KeyPress
        'permite só numeros com virgulas
        If _clFuncoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True
    End Sub

    Private Sub txt_qtde_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtde.Leave

        lbl_mensagem02.Text = ""

        If Me.txt_qtde.Text.Equals("") Then Me.txt_qtde.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_qtde.Text) Then

            If CDec(Me.txt_qtde.Text) < _valorZERO Then

                lbl_mensagem02.Text = "QUANTIDADE deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_qtde.Text = Format(CDec(Me.txt_qtde.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_qtdeFisc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_qtdeFisc.Leave

        lbl_mensagem02.Text = ""

        If Me.txt_qtdeFisc.Text.Equals("") Then Me.txt_qtdeFisc.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_qtdeFisc.Text) Then

            If CDec(Me.txt_qtdeFisc.Text) < _valorZERO Then

                lbl_mensagem02.Text = "QUANTIDADE deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_qtdeFisc.Text = Format(CDec(Me.txt_qtdeFisc.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_pvenda_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pvenda.Leave

        lbl_mensagem02.Text = ""

        If Me.txt_pvenda.Text.Equals("") Then Me.txt_pvenda.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pvenda.Text) Then

            If CDec(Me.txt_pvenda.Text) < _valorZERO Then

                lbl_mensagem02.Text = "QUANTIDADE deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pvenda.Text = Format(CDec(Me.txt_pvenda.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_pcusto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pcusto.Leave

        lbl_mensagem02.Text = ""

        If Me.txt_pcusto.Text.Equals("") Then Me.txt_pcusto.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pcusto.Text) Then

            If CDec(Me.txt_pcusto.Text) < _valorZERO Then

                lbl_mensagem02.Text = "QUANTIDADE deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pcusto.Text = Format(CDec(Me.txt_pcusto.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_vpromocao_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vpromocao.Leave

        lbl_mensagem02.Text = ""

        If Me.txt_vpromocao.Text.Equals("") Then Me.txt_vpromocao.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_vpromocao.Text) Then

            If CDec(Me.txt_vpromocao.Text) < _valorZERO Then

                lbl_mensagem02.Text = "QUANTIDADE deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_vpromocao.Text = Format(CDec(Me.txt_vpromocao.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_pcompra_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pcompra.Leave

        lbl_mensagem02.Text = ""

        If Me.txt_pcompra.Text.Equals("") Then Me.txt_pcompra.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pcompra.Text) Then

            If CDec(Me.txt_pcompra.Text) < _valorZERO Then

                lbl_mensagem02.Text = "QUANTIDADE deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pcompra.Text = Format(CDec(Me.txt_pcompra.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_pcustoa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pcustoa.Leave

        lbl_mensagem02.Text = ""

        If Me.txt_pcustoa.Text.Equals("") Then Me.txt_pcustoa.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pcustoa.Text) Then

            If CDec(Me.txt_pcustoa.Text) < _valorZERO Then

                lbl_mensagem02.Text = "QUANTIDADE deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pcustoa.Text = Format(CDec(Me.txt_pcustoa.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_pcustom_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pcustom.Leave

        lbl_mensagem02.Text = ""

        If Me.txt_pcustom.Text.Equals("") Then Me.txt_pcustom.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pcustom.Text) Then

            If CDec(Me.txt_pcustom.Text) < _valorZERO Then

                lbl_mensagem02.Text = "QUANTIDADE deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pcustom.Text = Format(CDec(Me.txt_pcustom.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_pcompa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pcompa.Leave

        lbl_mensagem02.Text = ""

        If Me.txt_pcompa.Text.Equals("") Then Me.txt_pcompa.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pcompa.Text) Then

            If CDec(Me.txt_pcompa.Text) < _valorZERO Then

                lbl_mensagem02.Text = "QUANTIDADE deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pcompa.Text = Format(CDec(Me.txt_pcompa.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_pvend15_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pvend15.Leave

        lbl_mensagem02.Text = ""

        If Me.txt_pvend15.Text.Equals("") Then Me.txt_pvend15.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pvend15.Text) Then

            If CDec(Me.txt_pvend15.Text) < _valorZERO Then

                lbl_mensagem02.Text = "QUANTIDADE deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pvend15.Text = Format(CDec(Me.txt_pvend15.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_pvend30_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pvend30.Leave

        lbl_mensagem02.Text = ""

        If Me.txt_pvend30.Text.Equals("") Then Me.txt_pvend30.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_pvend30.Text) Then

            If CDec(Me.txt_pvend30.Text) < _valorZERO Then

                lbl_mensagem02.Text = "QUANTIDADE deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_pvend30.Text = Format(CDec(Me.txt_pvend30.Text), "###,##0.00")

        End If

    End Sub

    Private Sub txt_inventa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_inventa.Leave

        lbl_mensagem02.Text = ""

        If Me.txt_inventa.Text.Equals("") Then Me.txt_inventa.Text = Format(0.0, "###,##0.00")
        If IsNumeric(Me.txt_inventa.Text) Then

            If CDec(Me.txt_inventa.Text) < _valorZERO Then

                lbl_mensagem02.Text = "QUANTIDADE deve ser maior ou igual a ZERO !"
                Return
            End If
            Me.txt_inventa.Text = Format(CDec(Me.txt_inventa.Text), "###,##0.00")

        End If

    End Sub

    Private Sub btn_proximaAba01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proximaAba01.Click

        tbc_produtos.SelectTab(2)
    End Sub

End Class