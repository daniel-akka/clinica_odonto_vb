Imports System
Imports System.Data
Imports System.IO
Imports System.Drawing.Printing
Imports System.Text
Imports Npgsql
Imports System.Linq

Public Class Frm_MenuCadastro

    Private Const _valorZERO As Integer = 0
    Public Shared _FrmRef As New Frm_MenuCadastro
    Private _ufCorrenteCbo As String = ""
    Private _clFunc As New ClFuncoes
    Private _clBD As New Cl_bdMetrosys
    Public clCadp001 As New Cl_Cadp001
    Dim _clDoutorDAO As New Cl_DoutorDAO
    Dim _Geno As New Cl_Geno

    'objetos para impressão
    Dim _s As Cl_EscreveArquivo
    Dim _StringToPrint As String = "", _stringToPrintAux As String = ""
    Private _PrintFont As New Font("Lucida Console", 8) 'Stenci
    Private _PrintPageSettings As New PageSettings
    Private _leitorTabela As NpgsqlDataReader
    Private _pgAtualImpressao As Integer = 1
    Private _tituloConsulta As String = ""
    Private _sImpressao As StreamWriter
    Private _leitorTabelaImprimir As NpgsqlDataReader
    Dim MostrarCaixaImpressoras As Boolean = False

    'LINQ:
    Dim _pacientes As List(Of Cl_Cadp001)


    Private Sub btn_inclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inclui.Click

        Dim IncPort As New Frm_MCadastroInc
        IncPort.btn_incluir.Enabled = True : IncPort.btn_alterar.Enabled = False
        IncPort.ShowDialog() : IncPort.Dispose()

        _pacientes = GetPacientes()
        preencheGridLINQ()


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

                If Not dtgClientes.CurrentRow.IsNewRow Then
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
                executaF5()

            Case Keys.F9
                executaF9()

            Case Keys.F6
                executaF6()

            Case Keys.F1
                executaF1()

        End Select



    End Sub

    Private Sub btn_altera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_altera.Click

        If Not dtgClientes.CurrentRow.IsNewRow Then

            setObjetosPart() : _FrmRef = Me
            Dim AltPort As New Frm_MCadastroAlt
            _clDoutorDAO.trazDoutorLoja(clCadp001.iddoutor, _Geno, AltPort._Doutor)
            AltPort.btn_incluir.Enabled = False : AltPort.btn_alterar.Enabled = True
            AltPort.ShowDialog() : AltPort.Dispose() : clCadp001.zeraValores()

            _pacientes = GetPacientes()
            preencheGridLINQ()

        Else
            lbl_mensagem.Text = "Selecione um Participante !"
        End If



    End Sub

    Private Sub setObjetosPart()

        clCadp001.pCod = dtgClientes.CurrentRow.Cells(_valorZERO).Value.ToString
        _clFunc.trazCadp001Full(clCadp001.pCod, clCadp001)
    End Sub

    Private Sub consultaBD()

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim nomeCampo As String = "", nomeCampoAux As String = ""

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim sqlPart As New StringBuilder
        Dim cmdPart As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        Try
            sqlPart.Remove(0, sqlPart.ToString.Length)
            sqlPart.Append("SELECT p_cod AS ""CODIGO"", p_ficha AS ""FICHA"", p_portad AS ""NOME/RAZAO"", p_doutor AS ""DENTISTA"", ") '2
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

            If chk_simPeriodo.Checked Then
                sqlPart.Append("AND (p_dtcad BETWEEN '" & dtp_inicial.Text & "' AND '" & dtp_final.Text & "') ")
            End If

            Try
                If cbo_doutores.SelectedIndex > 0 Then
                    sqlPart.Append("AND p_doutor = '" & cbo_doutores.SelectedItem.ToString & "' ")
                End If
            Catch ex As Exception
            End Try


            'Primeira verificação...
            If RdBCli.Checked = True Then

                sqlPart.Append("AND p_tipo = 'C' ")

            ElseIf RdBForn.Checked = True Then

                sqlPart.Append("AND p_tipo = 'F' ")
            End If


            'Segunda verificação...
            If rdb_nao.Checked = False Then

                If Me.rdb_cnpj_cpf.Checked = True Then

                    nomeCampo = "p_cgc" : nomeCampoAux = "p_cpf"

                ElseIf Me.rdb_codigo.Checked = True Then

                    nomeCampo = "p_cod"

                ElseIf Me.rdb_ficha.Checked = True Then

                    nomeCampo = "p_ficha"
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

                    sqlPart.Append("ORDER BY p_portad ASC ")

                Else

                    If rdb_codigo.Checked = True Then
                        sqlPart.Append("ORDER BY p_cod ASC ") 'ORDER BY p_cod ASC

                    Else
                        sqlPart.Append("ORDER BY p_portad ASC ") 'ORDER BY p_portad ASC

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

            If chk_todos.Checked = False Then sqlPart.Append("LIMIT 100")

            cmdPart = New NpgsqlCommand(sqlPart.ToString, oConnBD)
            dr = cmdPart.ExecuteReader
            Me.dtgClientes.Rows.Clear() : Me.dtgClientes.Refresh()

            Dim cpfMask As String = ""
            Try
                While dr.Read

                    cpfMask = ""
                    If Trim(dr(5).ToString).Equals("") = False Then

                        Try
                            cpfMask = Format(Convert.ToInt64(dr(5).ToString), "000\.000\.000\-00")
                        Catch ex As Exception
                            cpfMask = dr(5).ToString
                        End Try

                    End If
                    dtgClientes.Rows.Add(dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, cpfMask, dr(4).ToString)
                End While
            Catch ex As Exception
            End Try

            dtgClientes.Refresh()
            dr.Close()

            lbl_registros.Text = Me.dtgClientes.Rows.Count
        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        sqlPart.Remove(_valorZERO, sqlPart.ToString.Length)

        'LIMPA OS OBJETOS DE MEMORIA...
        cmdPart = Nothing : sqlPart = Nothing : dr = Nothing
        oConnBD = Nothing



    End Sub

    Private Sub Frm_MenuCadastro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbl_NomeSys.Text = Application.ProductName
        rdb_nome.Checked = True

        _clFunc.trazGenoSelecionado(MdlEmpresaUsu._codigo, _Geno)

        cbo_doutores = _clDoutorDAO.PreenchComboDoutoresPesq(_Geno, cbo_doutores, MdlConexaoBD.conectionPadrao)

        'consultaBD()
        _pacientes = GetPacientes()
        preencheGridLINQ()

        'relaciona o objeto pd ao procedimento rptGravaTotaisNF
        AddHandler PrintDocument1.BeginPrint, AddressOf InicializaRelatorio


    End Sub

#Region "LINQ ..."

    Private Function GetPacientes() As List(Of Cl_Cadp001)

        Return consultaBD_LINQ()
    End Function

    Private Function consultaBD_LINQ() As List(Of Cl_Cadp001)

        Dim oConnBD As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim nomeCampo As String = "", nomeCampoAux As String = ""
        Dim listCli As New List(Of Cl_Cadp001)

        Try
            oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return Nothing

        End Try

        Dim sqlPart As New StringBuilder
        Dim cmdPart As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        Try

            sqlPart.Remove(0, sqlPart.ToString.Length)
            sqlPart.Append("SELECT p_id, p_cod AS ""CODIGO"", p_ficha AS ""FICHA"", p_portad AS ""NOME/RAZAO"", p_doutor AS ""DENTISTA"", ") '4
            sqlPart.Append("TO_CHAR(p_dtcad, 'dd/MM/yyyy') AS ""DtCADASTRO"", p_cpf AS ""CPF"", p_cgc AS ""CNPJ"", ") '7
            sqlPart.Append("p_tipo AS ""TIPO"", p_carac AS ""CARAC"", p_bairro AS ""BAIRRO"", p_cid AS ""CIDADE"", p_uf AS ""UF"", ") '12
            sqlPart.Append("p_fone AS ""FONE"", p_celular AS ""CELULAR"", p_end ") '15
            sqlPart.Append("FROM cadp001 WHERE p_inativo = FALSE;") '55

            cmdPart = New NpgsqlCommand(sqlPart.ToString, oConnBD)
            cmdPart.CommandTimeout = 1024
            dr = cmdPart.ExecuteReader

            Dim cpfMask As String = ""
            Try

                While dr.Read

                    cpfMask = ""
                    If IsNumeric(Trim(dr(5).ToString)) Then cpfMask = Format(Convert.ToInt64(dr(5).ToString), "000\.000\.000\-00")

                    listCli.Add(New Cl_Cadp001(dr(0), dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(6).ToString, dr(5).ToString, _
                                               dr(8).ToString, dr(9).ToString, "", "", Nothing, "", "", dr(7).ToString, "", dr(15).ToString, dr(10).ToString, _
                                               dr(11).ToString, dr(12).ToString, "", dr(13).ToString, dr(14).ToString))


                End While


            Catch ex As Exception
            End Try

            'dtgClientes.Refresh()
            dr.Close()

            'lbl_registros.Text = Me.dtgClientes.Rows.Count

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        sqlPart.Remove(_valorZERO, sqlPart.ToString.Length)

        'LIMPA OS OBJETOS DE MEMORIA...
        cmdPart = Nothing : sqlPart = Nothing : dr = Nothing
        oConnBD = Nothing


        Return listCli

    End Function

    Sub preencheGridLINQ()

        Try
            dtgClientes.Rows.Clear()
            Dim cpfmask As String = ""
            For Each p As Cl_Cadp001 In _pacientes

                'MASK CPF:
                cpfmask = ""
                If Trim(p.pCpf).Equals("") = False Then

                    Try
                        cpfmask = Format(Convert.ToInt64(p.pCpf), "000\.000\.000\-00")
                    Catch ex As Exception
                        cpfmask = p.pCpf
                    End Try

                End If

                dtgClientes.Rows.Add(p.pCod, p.ficha, p.pPortad, p.doutor, cpfmask, Format(p.pDtcad, "dd/MM/yyyy"))

            Next
        Catch ex As Exception
        End Try
        dtgClientes.Refresh()
        lbl_registros.Text = dtgClientes.Rows.Count

    End Sub

    Sub preencheGrid_Filtros()

        Try
            dtgClientes.Rows.Clear()
            Dim pacientesFiltrados = From pa In _pacientes

            Try
                'DATA:
                If chk_simPeriodo.Checked Then

                    preencheGrid_FiltrosAuxComData(pacientesFiltrados)

                Else

                    preencheGrid_FiltrosAuxSemData(pacientesFiltrados)

                End If



                Dim cpfmask As String = ""
                For Each p As Cl_Cadp001 In pacientesFiltrados

                    'MASK CPF:
                    cpfmask = ""
                    If Trim(p.pCpf).Equals("") = False Then

                        Try
                            cpfmask = Format(Convert.ToInt64(p.pCpf), "000\.000\.000\-00")
                        Catch ex As Exception
                            cpfmask = p.pCpf
                        End Try

                    End If

                    dtgClientes.Rows.Add(p.pCod, p.ficha, p.pPortad, p.doutor, cpfmask, Format(p.pDtcad, "dd/MM/yyyy"))

                Next
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            End Try
            
        Catch ex As Exception
        End Try
        dtgClientes.Refresh()
        lbl_registros.Text = Me.dtgClientes.Rows.Count

    End Sub

    Sub preencheGrid_FiltrosAuxComData(ByRef pacientesFiltros As Object)

        Dim mtipo As String = QueryTipo()
        Dim muf As String = QueryUF()
        Dim mcidade As String = QueryCidade()
        Dim mdoutores As String = QueryDoutores()

        'NOME:
        If rdb_nome.Checked Then

            ' Return customers that are grouped based on country.
            pacientesFiltros = From pa In _pacientes
            Where pa.pPortad.StartsWith(txt_pesquisa.Text) And (pa.pDtcad >= dtp_inicial.Value And pa.pDtcad <= dtp_final.Value) And
            pa.pTipo.Contains(mtipo) And pa.pUf.Contains(muf) And pa.doutor.Contains(mdoutores) And
            pa.pUf.Contains(muf) And pa.pCid.Contains(mcidade)
            Order By pa.pPortad


        ElseIf rdb_codigo.Checked Then

            pacientesFiltros = From pa In _pacientes
            Where pa.pCod.StartsWith(txt_pesquisa.Text) And (pa.pDtcad >= dtp_inicial.Value And pa.pDtcad <= dtp_final.Value) And
            pa.pTipo.Contains(mtipo) And pa.pUf.Contains(muf) And pa.doutor.Contains(mdoutores) And
            pa.pUf.Contains(muf) And pa.pCid.Contains(mcidade)
            Order By pa.pPortad

        ElseIf rdb_ficha.Checked Then

            pacientesFiltros = From pa In _pacientes
            Where pa.ficha.StartsWith(txt_pesquisa.Text) And (pa.pDtcad >= dtp_inicial.Value And pa.pDtcad <= dtp_final.Value) And
            pa.pTipo.Contains(mtipo) And pa.pUf.Contains(muf) And pa.doutor.Contains(mdoutores) And
            pa.pUf.Contains(muf) And pa.pCid.Contains(mcidade)
            Order By pa.pPortad

        ElseIf rdb_cnpj_cpf.Checked Then

            pacientesFiltros = From pa In _pacientes
            Where (pa.pCpf.StartsWith(txt_pesquisa.Text) Or pa.pCgc.StartsWith(txt_pesquisa.Text)) And
            (pa.pDtcad >= dtp_inicial.Value And pa.pDtcad <= dtp_final.Value) And
            pa.pTipo.Contains(mtipo) And pa.pUf.Contains(muf) And pa.doutor.Contains(mdoutores) And
            pa.pUf.Contains(muf) And pa.pCid.Contains(mcidade)
            Order By pa.pPortad

        End If

    End Sub

    Sub preencheGrid_FiltrosAuxSemData(ByRef pacientesFiltros As Object)

        Dim mtipo As String = QueryTipo()
        Dim muf As String = QueryUF()
        Dim mcidade As String = QueryCidade()
        Dim mdoutores As String = QueryDoutores()

        'NOME:
        If rdb_nome.Checked Then

            ' Return customers that are grouped based on country.
            pacientesFiltros = From pa In _pacientes
            Where pa.pPortad.StartsWith(txt_pesquisa.Text) And pa.pTipo.Contains(mtipo) And
            pa.pUf.Contains(muf) And pa.doutor.Contains(mdoutores) And pa.pUf.Contains(muf) And pa.pCid.Contains(mcidade)
            Order By pa.pPortad


        ElseIf rdb_codigo.Checked Then

            pacientesFiltros = From pa In _pacientes
            Where pa.pCod.StartsWith(txt_pesquisa.Text) And pa.pTipo.Contains(mtipo) And
            pa.pUf.Contains(muf) And pa.doutor.Contains(mdoutores) And pa.pUf.Contains(muf) And pa.pCid.Contains(mcidade)
            Order By pa.pPortad

        ElseIf rdb_ficha.Checked Then

            pacientesFiltros = From pa In _pacientes
            Where pa.ficha.StartsWith(txt_pesquisa.Text) And pa.pTipo.Contains(mtipo) And
            pa.pUf.Contains(muf) And pa.doutor.Contains(mdoutores) And pa.pUf.Contains(muf) And pa.pCid.Contains(mcidade)
            Order By pa.pPortad

        ElseIf rdb_cnpj_cpf.Checked Then

            pacientesFiltros = From pa In _pacientes
            Where (pa.pCpf.StartsWith(txt_pesquisa.Text) Or pa.pCgc.StartsWith(txt_pesquisa.Text)) And pa.pTipo.Contains(mtipo) And
            pa.pUf.Contains(muf) And pa.doutor.Contains(mdoutores) And pa.pUf.Contains(muf) And pa.pCid.Contains(mcidade)
            Order By pa.pPortad

        End If


    End Sub

    Function QueryTipo() As String

        Dim tipo As String = ""

        If RdBCli.Checked Then tipo = "C"
        If RdBForn.Checked Then tipo = "F"

        Return tipo
    End Function

    Function QueryUF() As String

        Dim uf As String = ""

        If cbo_uf.SelectedIndex > 0 Then uf = cbo_uf.SelectedItem.ToString

        Return uf
    End Function

    Function QueryCidade() As String
        Dim cidade As String = ""

        If (cbo_uf.SelectedIndex > 0) AndAlso (cbo_cidade.SelectedIndex >= 0) Then
            cidade = cbo_cidade.SelectedItem.ToString
        End If

        Return cidade
    End Function

    Function QueryDoutores() As String
        Dim doutores As String = ""

        If (cbo_doutores.SelectedIndex > 0) Then
            doutores = cbo_doutores.SelectedItem.ToString
        End If

        Return doutores
    End Function

    Function condicoes(p As List(Of Cl_Cadp001)) As Boolean

        Return False
    End Function
#End Region

    Private Sub rdb_cnpj_cpf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_cnpj_cpf.CheckedChanged, rdb_codigo.CheckedChanged, rdb_nome.CheckedChanged, rdb_nao.CheckedChanged, rdb_ficha.CheckedChanged

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

        If rdb_ficha.Checked = True Then

            Me.lbl_pesquisa.Text = "FICHA:" : Me.txt_pesquisa.SetBounds(260, 23, 65, 23)
            Me.txt_pesquisa.MaxLength = 7 : Me.txt_pesquisa.Text = ""
            consultaBD()

        End If

        If rdb_nome.Checked = True Then

            Me.lbl_pesquisa.Text = "NOME:" : Me.txt_pesquisa.SetBounds(258, 23, 345, 23)
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

        'consultaBD()
        preencheGrid_Filtros()

    End Sub

    Private Sub cbo_uf_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_uf.SelectedIndexChanged

        'consultaBD()
        preencheGrid_Filtros()

    End Sub

    Private Sub cbo_cidade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cidade.SelectedIndexChanged

        'consultaBD()
        preencheGrid_Filtros()

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
            Dim mCodigoPart As String = Me.dtgClientes.CurrentRow.Cells(_valorZERO).Value.ToString
            _clBD.desabilitaParticipante(conection, transacao, mCodigoPart)
            mCodigoPart = Nothing : transacao.Commit()

            MsgBox("Cliente Deletado com sucesso", MsgBoxStyle.Exclamation)
            conection.Close()

            _pacientes = GetPacientes()
            preencheGridLINQ()

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


        _s = New Cl_EscreveArquivo(fs)
        _s.chamaEvento = True
        AddHandler _s.SaltandoLinhasEvento, AddressOf GravCabecalhoPg
        _PrintFont = New Font("Lucida Console", 9)
        Dim strLinha As String = ""
        _s.qtdLinhasPorPagina = 89
        _s.qtdSaltosLinhaNextPag = 2


        'titulo
        Try
            'vbCrLf, vbCr, vbLf, vbNewLine = quebra de linha
            _s.SaltandoLinhasComEscreveLn(2)
            '8 caracteres
            strLinha = _clFunc.Centraliza_Str("CLIENTES", 100)
            _s.EscreveLn(strLinha & vbNewLine)
        Catch ex As Exception
        End Try


        'Participantes
        gravaParticipantes(_s)


        'Deleta o arquivo temporário...
        _s.Close()
        Try
            File.Copy(mArqTemp, arqSaida, True)
        Catch ex As Exception
        End Try
        _s.Dispose()
        File.Delete(mArqTemp)

        'Ler o arquivo salvo
        LerOArquivoSalvo(arqSaida)
        _stringToPrintAux = _StringToPrint

        'Visualiza o conteúdo do arquivo salvo...
        VisuConteArqSalvo()

        _StringToPrint = ""
    End Sub

    Private Sub GravCabecalhoPg()

        _s.EscreveLn("                                                                                      Pag.  " & _s.paginaAtual.ToString.PadLeft(4, "0"))
        _s.EscreveLn("-----------------------------------------------------------------------------------------------------")
        _s.EscreveLn("  FICHA      NOME                                          ENDEREÇO                       TELEFONE ")
        '              xxxxxxxxxZ xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZ xxxxxxxxxZ 
        _s.EscreveLn("  -------------------------------------------------------------------------------------------------")

    End Sub

    Private Sub gravaParticipantes(ByRef s As Cl_EscreveArquivo)

        Dim nomeCampo As String = "", nomeCampoAux As String = "", mfone As String = ""
        Dim strLinha As String = "", mContItens As Integer = _valorZERO

        Try

            Dim pacientesFiltrados = From pa In _pacientes

            Try
                'DATA:
                If chk_simPeriodo.Checked Then

                    preencheGrid_FiltrosAuxComData(pacientesFiltrados)

                Else

                    preencheGrid_FiltrosAuxSemData(pacientesFiltrados)

                End If




                If _pacientes.Count > 0 Then
                    '                     1         2         3         4         5         6         7         8         9         0         1         2
                    '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                    s.EscreveLn("-----------------------------------------------------------------------------------------------------")
                    s.EscreveLn("  FICHA      NOME                                          ENDEREÇO                       TELEFONE ")
                    '              xxxxxxxxxZ xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxxxxxxZxxxxx xxxxxxxxxZxxxxxxxxxZxxxxxxxxxZ xxxxxxxxxZ 
                    s.EscreveLn("  -------------------------------------------------------------------------------------------------")

                End If

                Dim cpfmask As String = ""
                For Each p As Cl_Cadp001 In pacientesFiltrados

                    mfone = p.pFone
                    If mfone.Equals("") Then mfone = p.pCelular

                    strLinha = "  " & _clFunc.Exibe_StrEsquerda(p.ficha, 10) & " " & _clFunc.Exibe_Str(p.pPortad, 45) & " " & _
                        _clFunc.Exibe_Str(p.pEnder, 30) & " " & _clFunc.Exibe_StrDireita(mfone, 10)

                    s.EscreveLn(_clFunc.Exibe_Str(strLinha, 110))
                    mContItens += 1

                Next

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            End Try

        Catch ex As Exception
        End Try

        If mContItens > _valorZERO Then

            s.EscreveLn("")
            strLinha = "  TOTAIS --->     " & _clFunc.Exibe_StrDireita(mContItens, 5)
            If mContItens > 1 Then
                strLinha += " - Clientes"
            Else
                strLinha += " - Cliente"
            End If
            s.EscreveLn(_clFunc.Exibe_Str(strLinha, 115))

            '                     1         2         3         4         5         6         7         8         9         0         1         2
            '            123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            s.EscreveLn("  -------------------------------------------------------------------------------------------------")
            s.EscreveLn("")
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
            PrintPreviewDialog1.Text = "Vizualizando Consulta CADASTRO"

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

        If (Me.dtgClientes.Rows.Count > _valorZERO) AndAlso (Me.dtgClientes.SelectedCells.Count > 0) Then

            executaRelatorio("", "\wged\TEMPconsultaPart.txt")

            executaF5()
        End If


    End Sub

    Sub executaF5()
        preencheGrid_Filtros()
    End Sub

    Sub executaF9()
        _pacientes = GetPacientes()
        preencheGrid_Filtros()
    End Sub

    Private Sub btn_relatorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_relatorio.Click

        executaF6()

    End Sub

    Private Sub RdBCli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbNd.CheckedChanged, RdBForn.CheckedChanged, RdBCli.CheckedChanged

        preencheGrid_Filtros()

    End Sub

    Private Sub btn_restaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_restaurar.Click

        executaF1()
    End Sub

    Private Sub executaF1()

        Dim mfrmRestauraPart As New Frm_RestauraParticipante
        mfrmRestauraPart.ShowDialog()
        mfrmRestauraPart = Nothing
        _pacientes = GetPacientes()
        preencheGridLINQ()

    End Sub


    Private Sub chk_todos_CheckedChanged(sender As Object, e As EventArgs) Handles chk_todos.CheckedChanged

        If chk_todos.Checked Then
            _pacientes = GetPacientes()
            preencheGridLINQ()
        Else
            preencheGrid_Filtros()
        End If

    End Sub

    Private Sub dtgClientes_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgClientes.RowsAdded


        If dtgClientes.Rows(e.RowIndex).Cells(4).Value.ToString.Equals("") Then 'Se não tiver preechido o cpf
            dtgClientes.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If

    End Sub

    Private Sub chk_simPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles chk_simPeriodo.CheckedChanged
        preencheGrid_Filtros()
    End Sub

    Private Sub dtp_final_ValueChanged(sender As Object, e As EventArgs) Handles dtp_inicial.ValueChanged, dtp_final.ValueChanged
        If chk_simPeriodo.Checked Then preencheGrid_Filtros()
    End Sub

    Private Sub cbo_doutores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_doutores.SelectedIndexChanged
        preencheGrid_Filtros()
    End Sub
End Class