Imports System
Imports System.Data
Imports System.IO
Imports System.Drawing.Printing
Imports System.Text
Imports Npgsql

Public Class Frm_MenuCadastro

    Private Const _valorZERO As Integer = 0
    Public Shared _FrmRef As New Frm_MenuCadastro
    Private _ufCorrenteCbo As String = ""
    Private _clFunc As New ClFuncoes
    Private _clBD As New Cl_bdMetrosys
    Public clCadp001 As New Cl_Cadp001

    'objetos para impressão
    Dim _StringToPrint As String = "", _stringToPrintAux As String = ""
    Private _PrintFont As New Font("Lucida Console", 8) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _sImpressao As StreamWriter
    Private _leitorTabelaImprimir As NpgsqlDataReader
    Dim MostrarCaixaImpressoras As Boolean = False


    Private Sub btn_inclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inclui.Click

        Dim IncPort As New Frm_MCadastroInc
        IncPort.btn_incluir.Enabled = True : IncPort.btn_alterar.Enabled = False
        IncPort.ShowDialog() : consultaBD() : IncPort.Dispose()

    End Sub

    Private Sub Frm_MenuCadastro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F2
                Dim IncPort As New Frm_MCadastroInc
                IncPort.btn_incluir.Enabled = True : IncPort.btn_alterar.Enabled = False
                IncPort.ShowDialog() : consultaBD() : IncPort.Dispose()

            Case Keys.F3

                If Not dtgPortadores.CurrentRow.IsNewRow Then
                    setObjetosPart() : _FrmRef = Me
                    Dim AltPort As New Frm_MCadastroAlt
                    AltPort.btn_incluir.Enabled = False : AltPort.btn_alterar.Enabled = True
                    AltPort.ShowDialog() : consultaBD() : AltPort.Dispose() : clCadp001.zeraValores()

                Else
                    lbl_mensagem.Text = "Selecione um fornecedor !"
                End If

            Case Keys.F4
                If MessageBox.Show("Deseja realmente excluir este Participante?", "METROSYS", MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                    executaF4()

                End If

            Case Keys.F5
                consultaBD()

            Case Keys.F6
                executaF6()

            Case Keys.F1
                executaF1()

        End Select



    End Sub

    Private Sub btn_altera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_altera.Click

        If Not dtgPortadores.CurrentRow.IsNewRow Then

            setObjetosPart() : _FrmRef = Me
            Dim AltPort As New Frm_MCadastroAlt
            AltPort.btn_incluir.Enabled = False : AltPort.btn_alterar.Enabled = True
            AltPort.ShowDialog() : consultaBD() : AltPort.Dispose() : clCadp001.zeraValores()
        Else
            lbl_mensagem.Text = "Selecione um fornecedor !"
        End If



    End Sub

    Private Sub setObjetosPart()

        clCadp001.pCod = dtgPortadores.CurrentRow.Cells(_valorZERO).Value.ToString : clCadp001.pPortad = dtgPortadores.CurrentRow.Cells(1).Value.ToString
        clCadp001.pFantas = dtgPortadores.CurrentRow.Cells(2).Value.ToString

        Try
            clCadp001.pDtcad = CDate(dtgPortadores.CurrentRow.Cells(3).Value.ToString)
        Catch ex As Exception
        End Try

        clCadp001.pCpf = dtgPortadores.CurrentRow.Cells(4).Value.ToString : clCadp001.pCgc = dtgPortadores.CurrentRow.Cells(5).Value.ToString
        clCadp001.pInsc = dtgPortadores.CurrentRow.Cells(6).Value.ToString : clCadp001.pTipo = dtgPortadores.CurrentRow.Cells(7).Value.ToString
        clCadp001.pCarac = dtgPortadores.CurrentRow.Cells(8).Value.ToString : clCadp001.pCivil = dtgPortadores.CurrentRow.Cells(9).Value.ToString

        Try
            clCadp001.pDtnativ = CDate(dtgPortadores.CurrentRow.Cells(10).Value.ToString)
        Catch ex As Exception
        End Try

        clCadp001.pNatur = dtgPortadores.CurrentRow.Cells(11).Value.ToString
        clCadp001.pIdent = dtgPortadores.CurrentRow.Cells(12).Value.ToString : clCadp001.pPai = dtgPortadores.CurrentRow.Cells(13).Value.ToString
        clCadp001.pMae = dtgPortadores.CurrentRow.Cells(14).Value.ToString : clCadp001.pEnder = dtgPortadores.CurrentRow.Cells(15).Value.ToString
        clCadp001.pBairro = dtgPortadores.CurrentRow.Cells(16).Value.ToString : clCadp001.pCid = dtgPortadores.CurrentRow.Cells(17).Value.ToString
        clCadp001.pUf = dtgPortadores.CurrentRow.Cells(18).Value.ToString : clCadp001.pCep = dtgPortadores.CurrentRow.Cells(19).Value.ToString
        clCadp001.pFone = dtgPortadores.CurrentRow.Cells(20).Value.ToString : clCadp001.pLtrab = dtgPortadores.CurrentRow.Cells(21).Value.ToString
        clCadp001.pEndtr = dtgPortadores.CurrentRow.Cells(22).Value.ToString : clCadp001.pFontr = dtgPortadores.CurrentRow.Cells(23).Value.ToString
        clCadp001.pCargo = dtgPortadores.CurrentRow.Cells(24).Value.ToString : clCadp001.pSalar = dtgPortadores.CurrentRow.Cells(25).Value.ToString
        clCadp001.pEsposo = dtgPortadores.CurrentRow.Cells(26).Value.ToString : clCadp001.pCrt = dtgPortadores.CurrentRow.Cells(27).Value.ToString
        clCadp001.pLtrabe = dtgPortadores.CurrentRow.Cells(28).Value.ToString : clCadp001.pSalae = dtgPortadores.CurrentRow.Cells(29).Value.ToString

        Try
            clCadp001.pRota = Convert.ToInt16(dtgPortadores.CurrentRow.Cells(30).Value.ToString)
        Catch ex As Exception
        End Try

        clCadp001.pVend = dtgPortadores.CurrentRow.Cells(31).Value.ToString
        clCadp001.pObs1 = dtgPortadores.CurrentRow.Cells(32).Value.ToString : clCadp001.pObs2 = dtgPortadores.CurrentRow.Cells(33).Value.ToString
        clCadp001.pObs3 = dtgPortadores.CurrentRow.Cells(34).Value.ToString

        Try
            clCadp001.pUltcomp = Convert.ToDateTime(dtgPortadores.CurrentRow.Cells(35).Value.ToString)
        Catch ex As Exception
        End Try

        clCadp001.pValor = dtgPortadores.CurrentRow.Cells(36).Value.ToString : clCadp001.pLimite = dtgPortadores.CurrentRow.Cells(37).Value.ToString
        clCadp001.pPedido = dtgPortadores.CurrentRow.Cells(38).Value.ToString : clCadp001.pCdvend = dtgPortadores.CurrentRow.Cells(39).Value.ToString
        clCadp001.pCdcid = dtgPortadores.CurrentRow.Cells(40).Value.ToString : clCadp001.pBloq = dtgPortadores.CurrentRow.Cells(41).Value
        clCadp001.pTb = dtgPortadores.CurrentRow.Cells(42).Value.ToString : clCadp001.pConsumo = dtgPortadores.CurrentRow.Cells(43).Value.ToString
        clCadp001.pMun = dtgPortadores.CurrentRow.Cells(44).Value.ToString : clCadp001.pCoduf = dtgPortadores.CurrentRow.Cells(45).Value.ToString
        clCadp001.pCtactb = dtgPortadores.CurrentRow.Cells(46).Value.ToString : clCadp001.pCtaanli = dtgPortadores.CurrentRow.Cells(47).Value.ToString
        clCadp001.pMes = dtgPortadores.CurrentRow.Cells(48).Value.ToString : clCadp001.pFax = dtgPortadores.CurrentRow.Cells(49).Value.ToString.ToString
        clCadp001.pPrep = dtgPortadores.CurrentRow.Cells(50).Value.ToString : clCadp001.pEmail = dtgPortadores.CurrentRow.Cells(51).Value.ToString
        clCadp001.pSexo = dtgPortadores.CurrentRow.Cells(52).Value.ToString : clCadp001.pCelular = dtgPortadores.CurrentRow.Cells(53).Value.ToString
        clCadp001.pInativo = dtgPortadores.CurrentRow.Cells(54).Value : clCadp001.pUsuario = dtgPortadores.CurrentRow.Cells(55).Value.ToString
        clCadp001.pIsento = dtgPortadores.CurrentRow.Cells(56).Value




    End Sub

    Private Sub consultaBD()

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim nomeCampo As String = "", nomeCampoAux As String = ""

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlPart As New StringBuilder
        Dim cmdPart As NpgsqlCommand
        Dim daPart As NpgsqlDataAdapter
        Dim dtPart As New DataTable

        Try
            sqlPart.Remove(0, sqlPart.ToString.Length)
            sqlPart.Append("SELECT p_cod AS ""CODIGO"", p_portad AS ""NOME/RAZAO"", p_fantas AS ""FANTASIA"", ") '2
            sqlPart.Append("TO_CHAR(p_dtcad, 'dd/MM/yyyy') AS ""DtCADASTRO"", p_cpf AS ""CPF"", p_cgc AS ""CNPJ"", ") '5
            sqlPart.Append("p_insc AS ""INSC"", p_tipo AS ""TIPO"", p_carac AS ""CARAC"", p_civil AS ""CIVIL"", ") '9
            sqlPart.Append("TO_CHAR(p_dtnativ, 'dd/MM/yyyy') AS ""DtNATIV"", p_natur AS ""NATUR"", p_ident AS ""IDENT"", ") '12
            sqlPart.Append("p_pai AS ""PAI"", p_mae AS ""MAE"", p_end AS ""ENDER"", ") '15
            sqlPart.Append("p_bairro AS ""BAIRRO"", p_cid AS ""CIDADE"", p_uf AS ""UF"", p_cep AS ""CEP"", ") '19
            sqlPart.Append("p_fone AS ""FONE"", p_ltrab, p_endtr AS ""ENDTR"", p_fontr AS ""FONETR"", ") '23
            sqlPart.Append("p_cargo AS ""CARGO"", p_salar AS ""SALARIO"", p_esposo AS ""ESPOSO(A)"", ") '26
            sqlPart.Append("p_crt AS ""CRT"", p_ltrabe, p_salae AS ""SALARIO"", ") '29
            sqlPart.Append("p_rota AS ""ROTA"", p_vend AS ""VENDEDOR"", p_obs1, p_obs2, p_obs3, ") '34
            sqlPart.Append("p_ultcomp AS ""ULT.COMP"", p_valor AS ""VALOR"", p_limite AS ""LIMITE"", ") '37
            sqlPart.Append("p_pedido AS ""PEDIDO"", p_cdvend AS ""CdVEND"", p_cdcid, p_bloq, ") '41
            sqlPart.Append("p_tb, p_consumo, p_mun, p_coduf, p_ctactb, p_ctaanli, ") '47
            sqlPart.Append("p_mes, p_fax, p_prep, p_email AS ""EMAIL"", ") '51
            sqlPart.Append("p_sexo AS ""SEXO"", p_celular AS ""CELULAR"", ") '53
            sqlPart.Append("p_inativo AS ""INATIVO"", p_usuario AS ""USUARIO"", p_isento AS ""ISENTO""  FROM cadp001 ") '56
            sqlPart.Append("WHERE p_inativo = FALSE ") '55


            'Primeira verificação...
            If RdBCli.Checked = True Then

                sqlPart.Append("AND p_tipo = 'C' ")

            ElseIf RdBForn.Checked = True Then

                sqlPart.Append("AND p_tipo = 'F' ")

            ElseIf RdBTransp.Checked = True Then

                sqlPart.Append("AND p_tipo = 'T' ")
            End If


            'Segunda verificação...
            If rdb_nao.Checked = False Then

                If Me.rdb_cnpj_cpf.Checked = True Then

                    nomeCampo = "p_cgc" : nomeCampoAux = "p_cpf"

                ElseIf Me.rdb_codigo.Checked = True Then

                    nomeCampo = "p_cod"

                Else

                    nomeCampo = "p_portad"
                End If

                If Not nomeCampoAux.Equals("") Then 'se for CPF ou CNPJ, entao...

                    If Not Trim(Me.txt_pesquisa.Text).Equals("") Then

                        sqlPart.Append("AND " & nomeCampo & " LIKE '" & Me.txt_pesquisa.Text & "%' OR " & nomeCampoAux & " LIKE '" & Me.txt_pesquisa.Text & "%' ") ' 

                    End If

                Else


                    If rdb_codigo.Checked = True Then

                        If Not Trim(Me.txt_pesquisa.Text).Equals("") Then

                            sqlPart.Append("AND UPPER(" & nomeCampo & ") LIKE  '" & Me.txt_pesquisa.Text & "%' ") 'ORDER BY p_cod ASC

                        End If

                    Else

                        If Not Trim(Me.txt_pesquisa.Text).Equals("") Then

                            sqlPart.Append("AND UPPER(" & nomeCampo & ") LIKE '" & Me.txt_pesquisa.Text & "%' ") 'ORDER BY p_portad ASC

                        End If
                    End If
                End If


                If cbo_uf.SelectedIndex > _valorZERO Then


                    If Not Trim(Me.txt_pesquisa.Text).Equals("") Then

                        sqlPart.Append("AND p_uf = '" & Me.cbo_uf.SelectedItem & "' ")

                    Else
                        sqlPart.Append("AND p_uf = '" & Me.cbo_uf.SelectedItem & "' ")

                    End If


                    If cbo_cidade.SelectedIndex > _valorZERO Then

                        sqlPart.Append("AND p_cid = '" & Me.cbo_cidade.SelectedItem & "' ")

                    End If
                End If


                If Not nomeCampoAux.Equals("") Then 'se for CPF ou CNPJ, entao...

                    sqlPart.Append("ORDER BY p_portad ASC")

                Else

                    If rdb_codigo.Checked = True Then
                        sqlPart.Append("ORDER BY p_cod ASC") 'ORDER BY p_cod ASC

                    Else
                        sqlPart.Append("ORDER BY p_portad ASC") 'ORDER BY p_portad ASC

                    End If
                End If



            Else 'se não for as opções do radio button

                If cbo_uf.SelectedIndex > _valorZERO Then sqlPart.Append("WHERE p_uf = '" & Me.cbo_uf.SelectedItem & "' ")
                If cbo_cidade.SelectedIndex > _valorZERO Then

                    If cbo_uf.SelectedIndex > _valorZERO Then

                        sqlPart.Append("AND p_cid = '" & Me.cbo_cidade.SelectedItem & "' ")

                    Else

                        sqlPart.Append("WHERE p_cid = '" & Me.cbo_cidade.SelectedItem & "' ")
                    End If
                End If


            End If

            daPart = New NpgsqlDataAdapter(sqlPart.ToString, oConnBDGENOV) : dtPart = New DataTable
            daPart.Fill(dtPart) : Me.dtgPortadores.DataSource = dtPart : Me.dtgPortadores.Refresh()

            If Me.dtgPortadores.Rows.Count > _valorZERO Then

                Me.dtgPortadores.Columns(_valorZERO).Width = 65 'Codigo
                Me.dtgPortadores.Columns(1).Width = 250 'Portad
                Me.dtgPortadores.Columns(2).Width = 200 'fantasia
                Me.dtgPortadores.Columns(3).Width = 80 'dtcad
                Me.dtgPortadores.Columns(4).Width = 110 'cpf
                Me.dtgPortadores.Columns(5).Width = 110 'cgc
                Me.dtgPortadores.Columns(6).Width = 90 'insc
                Me.dtgPortadores.Columns(7).Width = 40 'tipo
                Me.dtgPortadores.Columns(8).Width = 80 'carac
                Me.dtgPortadores.Columns(9).Width = 70 'civil
                Me.dtgPortadores.Columns(10).Width = 90 : Me.dtgPortadores.Columns(11).Width = 90
                Me.dtgPortadores.Columns(12).Width = 90 : Me.dtgPortadores.Columns(13).Width = 90
                Me.dtgPortadores.Columns(14).Width = 90 : Me.dtgPortadores.Columns(15).Width = 90
                Me.dtgPortadores.Columns(16).Width = 90 : Me.dtgPortadores.Columns(17).Width = 80
                Me.dtgPortadores.Columns(18).Width = 90 : Me.dtgPortadores.Columns(19).Width = 70
                Me.dtgPortadores.Columns(20).Width = 70

            End If

            lbl_registros.Text = Me.dtgPortadores.Rows.Count
            oConnBDGENOV.ClearPool() : oConnBDGENOV.ClearPool()
        Catch ex As Exception
            Try
                dtPart.Clear()

            Catch ex01 As Exception
            End Try

            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        sqlPart.Remove(_valorZERO, sqlPart.ToString.Length)

        'LIMPA OS OBJETOS DE MEMORIA...
        daPart = Nothing : cmdPart = Nothing : sqlPart = Nothing : dtPart = Nothing
        oConnBDGENOV = Nothing



    End Sub

    Private Sub Frm_MenuCadastro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        consultaBD()

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler PrintDocument1.BeginPrint, AddressOf InicializaRelatorio
    End Sub

    Private Sub rdb_cnpj_cpf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_cnpj_cpf.CheckedChanged, rdb_codigo.CheckedChanged, rdb_nome.CheckedChanged, rdb_nao.CheckedChanged

        Me.txt_pesquisa.ReadOnly = False
        If rdb_cnpj_cpf.Checked = True Then

            Me.lbl_pesquisa.Text = "CNPJ ou CPF:" : Me.txt_pesquisa.SetBounds(302, 23, 119, 23)
            Me.txt_pesquisa.MaxLength = 20 : Me.txt_pesquisa.Text = ""
            consultaBD()

        End If

        If rdb_codigo.Checked = True Then

            Me.lbl_pesquisa.Text = "CODIGO:" : Me.txt_pesquisa.SetBounds(269, 23, 65, 23)
            Me.txt_pesquisa.MaxLength = 7 : Me.txt_pesquisa.Text = ""
            consultaBD()

        End If

        If rdb_nome.Checked = True Then

            Me.lbl_pesquisa.Text = "NOME:" : Me.txt_pesquisa.SetBounds(258, 23, 400, 23)
            Me.txt_pesquisa.MaxLength = 65 : Me.txt_pesquisa.Text = ""
            consultaBD()

        End If

        If rdb_nao.Checked = True Then

            Me.txt_pesquisa.ReadOnly = True
            consultaBD()

        End If


    End Sub

    Private Sub cbo_uf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_uf.GotFocus

        If Not (cbo_uf.DroppedDown) Then cbo_uf.DroppedDown = True

    End Sub

    Private Sub cbo_uf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_uf.Leave

        If _ufCorrenteCbo.Equals("") Then

            If cbo_uf.SelectedIndex >= _valorZERO Then

                Me.cbo_cidade = _clFunc.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
                _ufCorrenteCbo = Me.cbo_uf.Text

            End If
        ElseIf cbo_uf.SelectedIndex > _valorZERO And Not _ufCorrenteCbo.Equals(cbo_uf.Text) Then

            Me.cbo_cidade = _clFunc.PreenchComboMunicipios(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
            _ufCorrenteCbo = Me.cbo_uf.Text

        End If



    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        consultaBD()

    End Sub

    Private Sub cbo_uf_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_uf.SelectedIndexChanged

        consultaBD()

    End Sub

    Private Sub cbo_cidade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cidade.SelectedIndexChanged

        consultaBD()

    End Sub

    Private Sub executaF4()

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                Return

            End Try

            transacao = conection.BeginTransaction
            Dim mCodigoPart As String = Me.dtgPortadores.CurrentRow.Cells(_valorZERO).Value.ToString
            _clBD.desabilitaParticipante(conection, transacao, mCodigoPart)
            mCodigoPart = Nothing : transacao.Commit()

            MsgBox("Participante Deletado com sucesso", MsgBoxStyle.Exclamation)
            conection.ClearPool() : conection.Close() : consultaBD()

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try
        Finally
            transacao = Nothing : conection = Nothing
        End Try



    End Sub

    Private Sub btn_exclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exclui.Click

        If MessageBox.Show("Deseja realmente excluir este Participante?", "METROSYS", MessageBoxButtons.YesNo, _
           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            executaF4()

        End If



    End Sub

    Private Sub executaRelatorio(ByVal unidadePC As String, ByVal arqSaida As String)

        'Grava informações da(s) Nota(s) no arquivo de saida...
        Dim mArqTemp As String = "\wged\TEMPconsultaPart.TMP"
        Dim fs As FileStream
        Try
            fs = New FileStream(mArqTemp, FileMode.Truncate, FileAccess.ReadWrite)

        Catch ex As Exception
            Try
                File.Delete(mArqTemp)
                fs = New FileStream(mArqTemp, FileMode.Create, FileAccess.ReadWrite)

            Catch ex1 As Exception
                fs = New FileStream("\new.TMP", FileMode.Create, FileAccess.ReadWrite)
            End Try

        End Try


        Dim s As New StreamWriter(fs)
        _PrintFont = New Font("Lucida Console", 9)
        Dim strLinha As String = ""


        'titulo
        Try
            'vbCrLf, vbCr, vbLf, vbNewLine = quebra de linha
            s.Write(vbNewLine & vbNewLine)
            '8 caracteres
            strLinha = _clFunc.Centraliza_Str("PARTICIPANTES", 100)
            s.WriteLine(strLinha & vbNewLine)
        Catch ex As Exception
        End Try


        'Participantes
        gravaParticipantes(s)


        'Deleta o arquivo temporário...
        s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        s.Dispose()
        File.Delete(mArqTemp)

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo()

        _StringToPrint = ""
    End Sub

    Private Sub gravaParticipantes(ByVal s As StreamWriter)

        Dim oConnBDGENOV As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim nomeCampo As String = "", nomeCampoAux As String = "", mfone As String = ""
        Dim strLinha As String = "", mContItens As Integer = _valorZERO

        Try
            oConnBDGENOV.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try


        Dim sqlPart As New StringBuilder
        Dim cmdPart As NpgsqlCommand
        Dim drPart As NpgsqlDataReader

        Try
            sqlPart.Append("SELECT p_portad AS ""NOME"", p_end AS ""ENDERECO"", p_fone AS ""FONE"", ") '2
            sqlPart.Append("p_celular AS ""CELULAR"" FROM cadp001 WHERE p_inativo = FALSE ") '3


            'Primeira verificação...
            If RdBCli.Checked = True Then

                sqlPart.Append("AND p_tipo = 'C' ")

            ElseIf RdBForn.Checked = True Then

                sqlPart.Append("AND p_tipo = 'F' ")

            ElseIf RdBTransp.Checked = True Then

                sqlPart.Append("AND p_tipo = 'T' ")
            End If


            'Segunda verificação...
            If rdb_nao.Checked = False Then

                If Me.rdb_cnpj_cpf.Checked = True Then

                    nomeCampo = "p_cgc" : nomeCampoAux = "p_cpf"

                ElseIf Me.rdb_codigo.Checked = True Then

                    nomeCampo = "p_cod"

                Else

                    nomeCampo = "p_portad"
                End If

                If Not nomeCampoAux.Equals("") Then 'se for CPF ou CNPJ, entao...

                    If Not Trim(Me.txt_pesquisa.Text).Equals("") Then

                        sqlPart.Append("AND " & nomeCampo & " LIKE '" & Me.txt_pesquisa.Text & "%' OR " & nomeCampoAux & " LIKE '" & Me.txt_pesquisa.Text & "%' ") ' 

                    End If

                Else


                    If rdb_codigo.Checked = True Then

                        If Not Trim(Me.txt_pesquisa.Text).Equals("") Then

                            sqlPart.Append("AND UPPER(" & nomeCampo & ") LIKE  '" & Me.txt_pesquisa.Text & "%' ") 'ORDER BY p_cod ASC

                        End If

                    Else

                        If Not Trim(Me.txt_pesquisa.Text).Equals("") Then

                            sqlPart.Append("AND UPPER(" & nomeCampo & ") LIKE '" & Me.txt_pesquisa.Text & "%' ") 'ORDER BY p_portad ASC

                        End If
                    End If
                End If


                If cbo_uf.SelectedIndex > _valorZERO Then


                    If Not Trim(Me.txt_pesquisa.Text).Equals("") Then

                        sqlPart.Append("AND p_uf = '" & Me.cbo_uf.SelectedItem & "' ")

                    Else
                        sqlPart.Append("AND p_uf = '" & Me.cbo_uf.SelectedItem & "' ")

                    End If


                    If cbo_cidade.SelectedIndex > _valorZERO Then

                        sqlPart.Append("AND p_cid = '" & Me.cbo_cidade.SelectedItem & "' ")
                    End If
                End If


                If Not nomeCampoAux.Equals("") Then 'se for CPF ou CNPJ, entao...

                    sqlPart.Append("ORDER BY p_portad ASC")

                Else

                    If rdb_codigo.Checked = True Then
                        sqlPart.Append("ORDER BY p_cod ASC") 'ORDER BY p_cod ASC

                    Else

                        sqlPart.Append("ORDER BY p_portad ASC") 'ORDER BY p_portad ASC
                    End If
                End If



            Else 'se não for as opções do radio button

                If cbo_uf.SelectedIndex > _valorZERO Then sqlPart.Append("WHERE p_uf = '" & Me.cbo_uf.SelectedItem & "' ")
                If cbo_cidade.SelectedIndex > _valorZERO Then

                    If cbo_uf.SelectedIndex > _valorZERO Then

                        sqlPart.Append("AND p_cid = '" & Me.cbo_cidade.SelectedItem & "' ")

                    Else

                        sqlPart.Append("WHERE p_cid = '" & Me.cbo_cidade.SelectedItem & "' ")
                    End If
                End If


            End If

            cmdPart = New NpgsqlCommand(sqlPart.ToString, oConnBDGENOV) : drPart = cmdPart.ExecuteReader

            If drPart.HasRows = True Then
                '                     1         2         3         4         5         6         7         8         9         0         1         2
                '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                s.WriteLine("-----------------------------------------------------------------------------------------------------")
                s.WriteLine("  NOME                                          ENDEREÇO                                   TELEFONE ")
                '              xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZ xxxxxxxxxZ 
                s.WriteLine("  -------------------------------------------------------------------------------------------------")

            End If

            While drPart.Read

                mfone = drPart(3).ToString
                If mfone.Equals("") Then mfone = drPart(2).ToString

                strLinha = "  " & _clFunc.Exibe_Str(drPart(0).ToString, 45) & " " & _clFunc.Exibe_Str(drPart(1).ToString, 40) & " " & _
                _clFunc.Exibe_StrDireita(mfone, 10)

                s.WriteLine(_clFunc.Exibe_Str(strLinha, 110))
                mContItens += 1
            End While
            drPart.Close()

            lbl_registros.Text = Me.dtgPortadores.Rows.Count
        Catch ex As Exception
            Try
                drPart.Close()

            Catch ex01 As Exception
            End Try
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        sqlPart.Remove(_valorZERO, sqlPart.ToString.Length) : oConnBDGENOV.ClearPool() : oConnBDGENOV.Close()

        'LIMPA OS OBJETOS DE MEMORIA...
        drPart = Nothing : cmdPart = Nothing : sqlPart = Nothing : drPart = Nothing
        oConnBDGENOV = Nothing


        If mContItens > _valorZERO Then

            s.WriteLine("")
            strLinha = "  TOTAIS --->     " & _clFunc.Exibe_StrDireita(mContItens, 3)
            If mContItens > 1 Then
                strLinha += " - Participantes"
            Else
                strLinha += " - Participante"
            End If
            s.WriteLine(_clFunc.Exibe_Str(strLinha, 115))

            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.WriteLine("  -------------------------------------------------------------------------------------------------")
            s.WriteLine("")
        End If



    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

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

        ' Se Hover mais texto, indica que há mais paginas
        If NumChars < _StringToPrint.Length Then
            ' Subtrais texto da string que foi impressa
            _StringToPrint = _StringToPrint.Substring(NumChars)
            e.HasMorePages = True

        Else
            e.HasMorePages = False ': _stringToPrintAux = _StringToPrint

        End If



    End Sub

    Private Sub LerOArquivoSalvo(ByVal arqSaida As String)
        'Ler o Arquivo salvo...
        Dim FilePath As String = arqSaida
        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            _StringToPrint = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream.Dispose() : MyfileStream = Nothing
            'File.Delete(arqSaida)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub VisuConteArqSalvo()

        Try
            ' Especifica as configurações da pagina atual
            PrintDocument1.DefaultPageSettings = _PrintPageSettings

            'Configurando margens
            PrintDocument1.DefaultPageSettings.Margins.Top = 12
            PrintDocument1.DefaultPageSettings.Margins.Right = 12
            PrintDocument1.DefaultPageSettings.Margins.Left = 10
            PrintDocument1.DefaultPageSettings.Margins.Bottom = 8

            'Configurando vizualização
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.Text = "Vizualizando CADASTRO"

            ' Especifica documento para a caixa de dialogo de visualização de impressão
            ' e mostra
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
            _stringToPrintAux = "" : MostrarCaixaImpressoras = False

        Catch ex As Exception
            ' Exibe mensagem de erro
            MessageBox.Show(ex.Message.ToString)

        End Try



    End Sub

    Private Sub InicializaRelatorio(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintEventArgs)

        _StringToPrint = _stringToPrintAux
        If MostrarCaixaImpressoras Then

            Dim Impressora As New PrintDialog
            Impressora.AllowCurrentPage = True : Impressora.AllowSomePages = True
            If Impressora.ShowDialog() = DialogResult.Cancel Then

                Relatorio.Cancel = True

            Else

                Try

                    PrintDocument1.PrinterSettings = Impressora.PrinterSettings
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If
        End If
        MostrarCaixaImpressoras = True



    End Sub

    Private Sub executaF6()

        If (Me.dtgPortadores.Rows.Count > _valorZERO) AndAlso (Me.dtgPortadores.SelectedCells.Count > 0) Then

            executaRelatorio("", "\wged\TEMPconsultaPart.txt")

        End If


    End Sub

    Private Sub btn_relatorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_relatorio.Click

        executaF6()

    End Sub

    Private Sub RdBCli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBTransp.CheckedChanged, RdbNd.CheckedChanged, RdBForn.CheckedChanged, RdBCli.CheckedChanged

        consultaBD()

    End Sub

    Private Sub btn_restaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_restaurar.Click

        executaF1()
    End Sub

    Private Sub executaF1()
        Dim mfrmRestauraPart As New Frm_RestauraParticipante
        mfrmRestauraPart.ShowDialog()
        mfrmRestauraPart = Nothing
    End Sub

    
End Class