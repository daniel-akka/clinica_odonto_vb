Imports System.Windows.Forms.ProgressBar
Imports System.Windows.Forms.SaveFileDialog
Imports System.Data
Imports System.IO
Imports System.Text
Imports GenoSintegra32DLL
Imports Npgsql
Imports Npgsql.NpgsqlTransaction
Public Class Frm_Sintegra

    Public Const ArqTemp As String = "\TEMP.TMP"
    Protected Const conexao As String = _
    "Server=localhost;Port=5432;UserId=postgres;Password=Servnet;Database=BDGENOV_JC"

    Dim CT_TOTAL As Integer
    Dim STRBUILD_reg90 As New StringBuilder
    Dim fs As New FileStream(ArqTemp, FileMode.Create, FileAccess.ReadWrite)
    Dim s As New StreamWriter(fs)
    Dim i As Integer

    Dim agora As Date = Now
    Dim DTHora As DateTime = DateTime.Now
    
    Dim sint As New GenoSintegraDll
    Dim cl As New Cl_bdMetrosys

    '  ***  Variaveis de uso em todo o processo de Registros  ***
    '
    Public vg_geno, vg_ender, vg_cid, vg_uf, vg_cep, vg_bairro, vg_cnpj, vg_insc As String
    Public vg_fone, vg_fax, vg_codmun, vg_coduf, vg_email, mfin As String

    Private Sub Frm_Sintegra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub btn_sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sair.Click
        Me.Close()
    End Sub

    Private Sub btn_gerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gerar.Click
        Dim mCampo As String
        Dim ArqMov As String = Me.txt_arquivo.Text
        ' Criando conexão
        Dim conn As New Npgsql.NpgsqlConnection(conexao)
        ' instanciando as consultas
        Dim Sqlcom As StringBuilder = New StringBuilder
        Dim comm As NpgsqlCommand = New NpgsqlCommand
        Dim DaGeno As NpgsqlDataAdapter = New NpgsqlDataAdapter(comm)
        Dim CodEstab As String
        CodEstab = String.Format("{0:D2}", cbo_estabelecimento.SelectedIndex + 1)

        Sqlcom.Append("SELECT g_geno, g_ender, g_cid, g_uf, g_cep, g_bair, g_cgc, ") '6
        Sqlcom.Append("g_insc, g_fone, g_fax, g_mun, g_coduf, g_email FROM geno001 ") ' 12
        Sqlcom.Append("where g_codig=" & "'G00" & CodEstab.ToString & "'")

        comm = New NpgsqlCommand(Sqlcom.ToString, conn)
        ' comm.Parameters.Add("@q_numero", Me.Txt_nquarto.Text)
        comm.CommandText = Sqlcom.ToString
        Dim DrGeno As NpgsqlDataReader
        Dim DtGeno As DataTable = New DataTable

        ' Variaveis para leira do banco Geno
        
        'Dim mper1, mper2 As Date
        'If File(ArqMov) Then

        'End If
        mfin = "1"
        Try
            conn.Open()
            DtGeno.Load(comm.ExecuteReader())
            DrGeno = comm.ExecuteReader()
            While (DrGeno.Read())
                vg_geno = DrGeno(0)
                vg_ender = DrGeno(1)
                vg_cid = DrGeno(2)
                vg_uf = DrGeno(3)
                vg_cep = DrGeno(4)
                vg_bairro = DrGeno(5)
                vg_cnpj = DrGeno(6)
                vg_insc = DrGeno(7)
                vg_fone = DrGeno(8)
                vg_fax = DrGeno(9)
                vg_codmun = DrGeno(10)
                vg_coduf = DrGeno(11)

            End While
            If chk_retificacao.Checked = True Then
                mfin = "2"
            End If
            mCampo = sint.Registro10(Exibe_campo(vg_cnpj, 14), Exibe_campo(vg_insc, 14), Exibe_campo(vg_geno, 35), Exibe_campo(vg_cid, 30), vg_uf, _
                                     Exibe_campo(vg_fax, 10), DateValue(msk_dtinicial.Text), DateValue(msk_dtfinal.Text), "3", "3", mfin)
            s.WriteLine(mCampo)
            mCampo = sint.Registro11(Exibe_campo(vg_ender, 34), Exibe_campo(" ", 5), Exibe_campo(vg_bairro, 22), Exibe_campo(vg_bairro, 15), Exibe_campo(vg_cep, 8), _
                                     Exibe_campo(Me.txt_responsavel.Text, 28), Exibe_campo("00" & vg_fone, 12))
            s.WriteLine(mCampo)

            ' Registro de Entradas Totais
            Reg50E(conexao)
            Reg50S(conexao)
            'mCampo = sint
            'conn.Close()
            s.Close()
            fs.Close()
            File.Delete(ArqMov)
            File.Copy(ArqTemp, ArqMov, True)
            MessageBox.Show("Arquivo Gerado c/ Sucesso ! " & ArqMov, "Gerando Arquivo ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Reg50E(ByVal conexao As String)
        Dim mcont As Integer
        Dim mCampo As String
        Dim strDataInicio, strDataFim As String
        Dim m_DataInicio, m_DataFim As Date
        ' Criando conexão
        Dim conn As New Npgsql.NpgsqlConnection(conexao)
        Dim conPort As New Npgsql.NpgsqlConnection(conexao)
        ' instanciando as consultas
        Dim SqlcomN4 As StringBuilder = New StringBuilder
        Dim comm As NpgsqlCommand = New NpgsqlCommand
        Dim DaGeno As NpgsqlDataAdapter = New NpgsqlDataAdapter(comm)

        ' Iniciando as variaveis
        strDataInicio = Me.msk_dtinicial.Text '"#1/3/2009#" 
        strDataFim = Me.msk_dtfinal.Text '"#30/3/2009#"
        m_DataInicio = DateValue(Me.msk_dtinicial.Text)
        m_DataFim = DateValue(Me.msk_dtfinal.Text)
        ' If mcont > 1 Then STRBUILD_reg90.Append("50" & String.Format("{0:D8}", mcont) & "?")

        SqlcomN4.Append("SELECT nt4.n4_numer, nt4.n4_tprod, nt4.n4_basec, nt4.n4_icms, ") '-3
        SqlcomN4.Append("nt4.n4_bsub, nt4.n4_icsub, nt4.n4_tpro2, nt4.n4_frete, nt4.n4_segu, ") '-8
        SqlcomN4.Append("nt4.n4_outros, nt4.n4_ipi, nt4.n4_tgeral, nt4.n4_isento, nt4.n4_vliss, ") '-13
        SqlcomN4.Append("nt4.n4_chave, nt4.n4_dtemis, nt4.n4_uf, nt4.n4_espec, nt4.n4_serie, ") '-18
        SqlcomN4.Append("nt4.n4_tipo, nt4.n4_cdfisc, nt4.n4_dtent, nt4.n4_cdport, nt4.n4_antec, ") '-23
        SqlcomN4.Append("nt4.n4_aliq ,nt4.n4_ipisent, nt4.n4_ipoutro, nt4.n4_sete, nt4.n4_doze, ") ' -28
        SqlcomN4.Append("nt4.n4_deze7, nt4.n4_vint5 FROM NOTA4FF nt4 WHERE nt4.n4_espec = 'NF' ") ' -30
        SqlcomN4.Append("AND nt4.n4_dtent BETWEEN ' " & strDataInicio & "' AND '" & strDataFim & "';")

        comm = New NpgsqlCommand(SqlcomN4.ToString, conn)
        ' comm.Parameters.Add("@q_numero", Me.Txt_nquarto.Text)
        comm.CommandText = SqlcomN4.ToString

        Dim DrN4F As NpgsqlDataReader
        Dim DtN4F As DataTable = New DataTable


        ' ***************************************
        ' Conexao p/ pesquisar Clientes
        Dim SqlcomPort As StringBuilder = New StringBuilder
        Dim comPort As NpgsqlCommand = New NpgsqlCommand
        Dim DaPort As NpgsqlDataAdapter = New NpgsqlDataAdapter(comPort)
        Dim x As Integer = 0
        Dim DrPort As NpgsqlDataReader
        Dim DtPort As DataTable = New DataTable

        '
        '  ******* Variaveis Auxiliares  **********
        ' 
        Dim vn4_tprod, vn4_basec, vn4_icms, vn4_bsub, vn4_icmsub, vn4_frete, vn4_segu, vn4_outros As Double
        Dim vn4_ipi, vn4_tgeral, vn4_isento, vn4_vliss, vn4_aliq, vn4_sete, vn4_doze, vn4_deze7, vn4_vint5 As Double
        Dim vn4_cdport, vn4_cdfisc, vn4_numer, vn4_uf, vn4_serie, vn4_especie, mtpemit, msit, vn4_chave, modelo As String
        Dim vp_cpf, vp_cgc, vp_insc, vp_uf, mcnpj As String
        vp_insc = "" : mcnpj = "" : vp_cgc = "" : vp_cpf = ""
        Dim vn4_dtemis, vn4_dtent As Date
        Dim mn4_isento As Double = 0.0

        Try

            ProgressBar1.Value = 0

            conn.Open()
            DtN4F.Load(comm.ExecuteReader())
            DrN4F = comm.ExecuteReader()
            While (DrN4F.Read())
                vn4_numer = DrN4F(0)
                vn4_tprod = DrN4F(1)
                vn4_basec = DrN4F(2)
                vn4_icms = DrN4F(3)
                vn4_bsub = DrN4F(4)
                vn4_icmsub = DrN4F(5)
                vn4_frete = DrN4F(7)
                vn4_segu = DrN4F(8)
                vn4_outros = DrN4F(9)
                vn4_ipi = DrN4F(10)
                vn4_tgeral = DrN4F(11)
                vn4_isento = DrN4F(12)
                vn4_vliss = DrN4F(13)
                vn4_chave = DrN4F(14)
                vn4_dtemis = DrN4F(15)
                vn4_uf = DrN4F(16)
                vn4_especie = DrN4F(17)
                vn4_serie = DrN4F(18)
                vn4_cdfisc = DrN4F(20)
                vn4_dtent = DrN4F(21)
                vn4_cdport = DrN4F(22)
                vn4_aliq = DrN4F(24)
                vn4_sete = DrN4F(27)
                vn4_doze = DrN4F(28)
                vn4_deze7 = DrN4F(29)
                vn4_vint5 = DrN4F(30)
                modelo = "01"
                If vn4_chave <> "" Then
                    modelo = "55"
                End If

                msit = "N"
                mtpemit = "T"

                SqlcomPort.Append("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc,p_uf FROM cadp001 WHERE p_cod ='" & vn4_cdport.ToString & "'")
                comPort = New NpgsqlCommand(SqlcomPort.ToString, conPort)
                x = Len("SELECT p_cod, p_portad, p_cgc, p_cpf, p_insc,p_uf FROM cadp001 WHERE p_cod =") + 8
                comPort.CommandText = SqlcomPort.ToString

                Try
                    conPort.Open()
                    DtPort.Load(comPort.ExecuteReader())
                    DrPort = comPort.ExecuteReader()
                    While (DrPort.Read())
                        vp_cgc = DrPort(2)
                        vp_cpf = DrPort(3)
                        vp_insc = DrPort(4)
                        vp_uf = DrPort(5)
                    End While
                    mcnpj = vp_cgc
                    If vp_cgc = "" Then
                        mcnpj = "000" & vp_cpf
                        vp_insc = "ISENTO" & Space(8)
                    End If
                    conPort.Close()

                    ' Remove(limpa) informações do Selec(SQL) de Fornecedores, para proxima consulta
                    SqlcomPort.Remove(0, SqlcomPort.ToString.Length)
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                End Try

                'obs: Verificar existencia de mais de uma aliquota na mesma 
                '     nota e cálculo do registro de isentos

                If vn4_aliq = 0.0 And (vn4_outros) > 0.0 Then
                    Dim mn4_outros As Double = vn4_outros
                    Dim mn4_tgeral As Double = 0.0
                    mn4_tgeral = vn4_outros
                    mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                                              cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
                                              vn4_sete, vn4_icms, mn4_isento, mn4_outros, vn4_aliq, msit)

                    s.WriteLine(mCampo)
                    mcont = mcont + 1
                End If

                ' Aliquotas entre 1 e 7 %
                If vn4_aliq > 0.0 And vn4_aliq < 7.0 Then
                    Dim mn4_outros As Double = 0.0
                    Dim mn4_tgeral As Double = 0.0
                    mn4_tgeral = vn4_basec
                    mn4_isento = vn4_isento
                    mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                                              cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
                                              vn4_basec, vn4_icms, mn4_isento, mn4_outros, vn4_aliq, msit)

                    s.WriteLine(mCampo)
                    mn4_isento = 0.0
                    mcont = mcont + 1
                End If

                If vn4_aliq = 7.0 Then
                    Dim mn4_outros As Double = 0.0
                    Dim mn4_tgeral As Double = 0.0
                    mn4_tgeral = vn4_sete
                    mn4_isento = vn4_isento
                    mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                                              cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
                                              vn4_sete, vn4_icms, mn4_isento, mn4_outros, vn4_aliq, msit)
                    s.WriteLine(mCampo)
                    mn4_isento = 0.0
                    mcont = mcont + 1
                End If

                If vn4_aliq = 12.0 Then
                    Dim mn4_outros As Double = 0.0
                    Dim mn4_tgeral As Double = 0.0
                    mn4_tgeral = vn4_doze
                    mn4_isento = vn4_isento
                    mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                                              cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
                                              vn4_doze, vn4_icms, mn4_isento, mn4_outros, vn4_aliq, msit)
                    s.WriteLine(mCampo)
                    mn4_isento = 0.0
                    mcont = mcont + 1
                End If

                If vn4_aliq = 17.0 Then
                    Dim mn4_outros As Double = 0.0
                    Dim mn4_tgeral As Double = 0.0
                    mn4_tgeral = vn4_deze7
                    mn4_isento = vn4_isento
                    mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                                              cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
                                              vn4_deze7, vn4_icms, mn4_isento, mn4_outros, vn4_aliq, msit)
                    s.WriteLine(mCampo)
                    mn4_isento = 0.0
                    mcont = mcont + 1
                End If

                If vn4_aliq = 25.0 Then
                    Dim mn4_outros As Double = 0.0
                    Dim mn4_tgeral As Double = 0.0
                    mn4_tgeral = vn4_vint5
                    mn4_isento = vn4_isento
                    mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                                              cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
                                              vn4_vint5, vn4_icms, mn4_isento, mn4_outros, vn4_aliq, msit)
                    s.WriteLine(mCampo)
                    mn4_isento = 0.0
                    mcont = mcont + 1
                End If
                ' Aliquotas maiores que 25$
                If vn4_aliq > 25.0 Then
                    Dim mn4_outros As Double = 0.0
                    Dim mn4_tgeral As Double = 0.0
                    mn4_tgeral = vn4_basec
                    mn4_isento = vn4_isento
                    mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                                              cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
                                              vn4_basec, vn4_icms, mn4_isento, mn4_outros, vn4_aliq, msit)

                    s.WriteLine(mCampo)
                    mn4_isento = 0.0
                    mcont = mcont + 1
                End If

                ' Padrão
                'mCampo = sint.Registro50(vg_cnpj, cl.Exibe_Str(vg_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                '                         cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, vn4_tgeral, _
                '                         vn4_basec, vn4_icms, vn4_isento, vn4_outros, vn4_aliq, msit)
                i = i + 1
                ProgressBar1.Value = i

            End While
            conn.Close()
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub Reg50S(ByVal conexao As String)
        Dim mcont As Integer
        Dim mCampo As String
        Dim strDataInicio, strDataFim As String
        Dim m_DataInicio, m_DataFim As Date
        ' Criando conexão
        Dim conN4S As New Npgsql.NpgsqlConnection(conexao)

        ' instanciando as consultas
        Dim SqlcomN4S As StringBuilder = New StringBuilder
        Dim comN4S As NpgsqlCommand = New NpgsqlCommand
        Dim DaN4S As NpgsqlDataAdapter = New NpgsqlDataAdapter(comN4S)

        ' Iniciando as variaveis
        strDataInicio = Me.msk_dtinicial.Text '"#1/3/2009#" 
        strDataFim = Me.msk_dtfinal.Text '"#30/3/2009#"
        m_DataInicio = DateValue(Me.msk_dtinicial.Text)
        m_DataFim = DateValue(Me.msk_dtfinal.Text)

        SqlcomN4S.Append("SELECT DISTINCT nt4.n4_numer, nt4.n4_tprod, nt4.n4_basec, nt4.n4_icms, ") ' 3
        SqlcomN4S.Append("nt4.n4_bsub, nt4.n4_icsub, nt4.n4_tpro2, nt4.n4_frete, nt4.n4_segu, ") ' 8
        SqlcomN4S.Append("nt4.n4_outros, nt4.n4_ipi, nt4.n4_tgeral, nt4.n4_outras, nt4.n4_isento, ") '13
        SqlcomN4S.Append("nt4.n4_desc, nt1.nt_chave, nt1.nt_cfop, nt1.nt_insc, nt1.nt_tipo, ") '18
        SqlcomN4S.Append("nt1.nt_serie, nt1.nt_dtemis, nt1.nt_codig, nt4.n4_vliss, nt1.tipo_nt, ") '23
        SqlcomN4S.Append("nt1.nt_uf, nt1.nt_dtsai, cad.p_uf, cad.p_cgc, cad.p_cpf, cad.p_insc, ") '29
        SqlcomN4S.Append("nt4.n4_sete, nt4.n4_doze, nt4.n4_deze7, nt4.n4_vint5, nt4.n4_icmsete, ") '34
        SqlcomN4S.Append("nt4.n4_icm12x, nt4.n4_icm17, nt4.n4_icvint5 FROM NOTA4DD nt4, NOTA1PP nt1 LEFT ") '37
        SqlcomN4S.Append("JOIN CADP001 cad ON cad.p_cod = nt1.nt_codig WHERE nt1.nt_nume ")
        SqlcomN4S.Append("= nt4.n4_numer AND nt1.nt_tipo <> 'E' AND nt1.nt_dtsai BETWEEN '")
        SqlcomN4S.Append(strDataInicio & "' AND '" & strDataFim & "' ")

        comN4S = New NpgsqlCommand(SqlcomN4S.ToString, conN4S)
        comN4S.CommandText = SqlcomN4S.ToString

        Dim DrN4S As NpgsqlDataReader
        Dim DtN4S As DataTable = New DataTable

        '
        '  ******* Variaveis Auxiliares  **********
        ' 
        Dim vn4_tprod, vn4_basec, vn4_icms, vn4_bsub, vn4_icmsub, vn4_frete, vn4_segu, vn4_outros, vn4_outras, vn4_desc As Double
        Dim vn4_ipi, vn4_tgeral, vn4_isento, vn4_vliss, vn4_aliq, vn4_sete, vn4_doze, vn4_deze7, vn4_vint5 As Double
        Dim vn4_cdport, vn4_cdfisc, vn4_numer, vn4_uf, vn4_serie, vn4_especie, mtpemit, msit, vn4_chave, modelo As String
        '
        ' ****  Variaveis acumuladoras de Icms p/ Aliquotas  ***
        '
        Dim vn4_icm7, vn4_icm12x, vn4_icm17, vn4_icm25 As Double
        Dim vp_cpf, vp_cgc, vp_insc, vp_uf, mcnpj As String
        Dim vn4_dtemis, vn4_dtsai As Date
        Dim mn4_isento As Double = 0.0

        Try

            conN4S.Open()
            DtN4S.Load(comN4S.ExecuteReader())
            DrN4S = comN4S.ExecuteReader()
            While (DrN4S.Read())
                vn4_numer = DrN4S(0)
                If vn4_numer = "019121" Then
                    mn4_isento = 0.0
                End If
                vn4_tprod = DrN4S(1)
                vn4_basec = DrN4S(2)
                vn4_icms = DrN4S(3)
                vn4_bsub = DrN4S(4)
                vn4_icmsub = DrN4S(5)
                vn4_frete = DrN4S(7)
                vn4_segu = DrN4S(8)
                vn4_outros = DrN4S(9)
                vn4_ipi = DrN4S(10)
                vn4_tgeral = DrN4S(11)
                ' Continuação
                vn4_outras = DrN4S(12) ' Total de produtos c/ Imposto Pago
                vn4_isento = DrN4S(13)
                vn4_desc = DrN4S(14)
                vn4_vliss = DrN4S(22)
                vn4_chave = DrN4S(15)
                vn4_dtemis = DrN4S(20)
                vn4_uf = DrN4S(24)  ' UF das Notas
                vp_uf = DrN4S(26)   ' UF do Cadastro
                vn4_especie = "NF"
                vn4_serie = DrN4S(19)
                vn4_cdfisc = Mid(DrN4S(16), 1, 1) & Mid(DrN4S(16), 3, 3)
                vn4_dtsai = DrN4S(25)
                vn4_cdport = DrN4S(21)
                vp_cpf = DrN4S(28)
                vp_cgc = DrN4S(27)
                vp_insc = DrN4S(29)
                vn4_sete = DrN4S(30)
                vn4_doze = DrN4S(31)
                vn4_deze7 = DrN4S(32)
                vn4_vint5 = DrN4S(33)
                vn4_icm7 = DrN4S(34)
                vn4_icm12x = DrN4S(35)
                vn4_icm17 = DrN4S(36)
                vn4_icm25 = DrN4S(37)
                modelo = "01"
                If vn4_chave <> "" Then
                    modelo = "55"
                End If
                mcnpj = vp_cgc
                If vp_cgc = "" Then
                    mcnpj = "000" & vp_cpf
                    vp_insc = "ISENTO"
                    If Len(mcnpj) < 4 Then
                        mcnpj = "00000000000000"
                    End If
                End If

                msit = "N"
                mtpemit = "P"
       
        'obs: Verificar existencia de mais de uma aliquota na mesma 
        '     nota e cálculo do registro de isentos


        If (vn4_outras) > 0.0 Then
            Dim mn4_outros As Double = vn4_outras
            Dim mn4_tgeral As Double = 0.0
                    Dim mn4_cdfisc As String
            mn4_tgeral = vn4_outras
            If vg_uf <> vp_uf Then
               mn4_cdfisc = "6405"
            Else
               mn4_cdfisc = "5405"
            End If
            mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vp_uf, modelo, _
                                              cl.Exibe_Str(vn4_serie, 3), vn4_numer, mn4_cdfisc, mtpemit, mn4_tgeral, _
                                              0.0, 0.0, mn4_isento, mn4_outros, 0.0, msit)

            s.WriteLine(mCampo)
            mcont = mcont + 1
        End If

        ' Aliquotas entre 1 e 7 %
                'If vn4_aliq > 0.0 And vn4_aliq < 7.0 Then
                '    Dim mn4_outros As Double = 0.0
                '    Dim mn4_tgeral As Double = 0.0
                '    mn4_tgeral = vn4_basec
                '    mn4_isento = vn4_isento
                '    mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                '                              cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
                '                              vn4_basec, vn4_icms, mn4_isento, mn4_outros, vn4_aliq, msit)

                '    s.WriteLine(mCampo)
                '    mn4_isento = 0.0
                '    mcont = mcont + 1
                'End If
         ' Aliquotas  7 %
         If vn4_sete > 0.0 Then
             Dim mn4_outros As Double = 0.0
             Dim mn4_tgeral As Double = 0.0
             vn4_aliq = 7.0
             mn4_tgeral = vn4_sete
             mn4_isento = vn4_isento
             If vn4_icm7 = 0.0 Then
                vn4_icm7 = (Convert.ToInt32(vn4_sete * 7.00)/100)
             End If
             mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                                              cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
                                              vn4_sete, vn4_icm7, mn4_isento, mn4_outros, vn4_aliq, msit)
             s.WriteLine(mCampo)
             mn4_isento = 0.0
             mcont = mcont + 1
        End If

        ' Aliquotas entre 12 %
        If vn4_doze > 0.0 Then
            Dim mn4_outros As Double = 0.0
            Dim mn4_tgeral As Double = 0.0
            vn4_aliq = 12.0
            mn4_tgeral = vn4_doze
            mn4_isento = vn4_isento
            If vn4_icm12x = 0.0 Then
               vn4_icm12x = (Convert.ToInt32(vn4_doze * 12.0) / 100)
            End If
            mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                                      cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
                                      vn4_doze, vn4_icm12x, mn4_isento, mn4_outros, vn4_aliq, msit)
            s.WriteLine(mCampo)
            mn4_isento = 0.0
            mcont = mcont + 1
        End If

        ' Aliquotas entre 17 %
        If vn4_deze7 > 0.0 Then
            Dim mn4_outros As Double = 0.0
            Dim mn4_tgeral As Double = 0.0
            vn4_aliq = 17.0
            mn4_tgeral = vn4_deze7
            mn4_isento = vn4_isento
            If vn4_icm17 = 0.0 Then
               vn4_icm17 = (Convert.ToInt32(vn4_deze7 * 17.0) / 100)
            End If
            mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                                      cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
                                      vn4_deze7, vn4_icm17, mn4_isento, mn4_outros, vn4_aliq, msit)
            s.WriteLine(mCampo)
            mn4_isento = 0.0
            mcont = mcont + 1
        End If

        ' Aliquotas entre 25 %
        If vn4_vint5 > 0.0 Then
            Dim mn4_outros As Double = 0.0
            Dim mn4_tgeral As Double = 0.0
            vn4_aliq = 25.0
            mn4_tgeral = vn4_vint5
            mn4_isento = vn4_isento
            If vn4_icm25 = 0.0 Then
               vn4_icm25 = (Convert.ToInt32(vn4_vint5 * 25.0) / 100)
            End If
            mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
                                      cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
                                      vn4_vint5, vn4_icm25, mn4_isento, mn4_outros, vn4_aliq, msit)
            s.WriteLine(mCampo)
            mn4_isento = 0.0
            mcont = mcont + 1
       End If

        ' Aliquotas maiores que 25$
        'If vn4_aliq > 25.0 Then
        '    Dim mn4_outros As Double = 0.0
        '    Dim mn4_tgeral As Double = 0.0
        '    mn4_tgeral = vn4_basec
        '    mn4_isento = vn4_isento
        '    mCampo = sint.Registro50(mcnpj, cl.Exibe_Str(vp_insc, 14), DateValue(vn4_dtemis), vn4_uf, modelo, _
        '                              cl.Exibe_Str(vn4_serie, 3), vn4_numer, vn4_cdfisc, mtpemit, mn4_tgeral, _
        '                              vn4_basec, vn4_icms, mn4_isento, mn4_outros, vn4_aliq, msit)

        '    s.WriteLine(mCampo)
        '    mn4_isento = 0.0
        '    mcont = mcont + 1
        'End If
               
            End While


          conN4S.Close()
        Catch ex As NpgsqlException
            MsgBox(ex.Message.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub progres_bar()
        Dim i As Integer
        ProgressBar1.Value = 0
        For i = 0 To 100

            Dim j As Integer
            For j = 0 To 10000000
            Next j

            ProgressBar1.Value = i
            Label1.Text = i.ToString + "/100"
        Next i

    End Sub
    Private Sub Reg90(ByVal conexao As String)
        Dim marray As Array = Split(STRBUILD_reg90.ToString, "?")
        Dim qtd As Integer = marray.Length - 1
        Dim i As Integer

        For i = 0 To marray.Length - 1
            'marray(i).ToString & "" & qtd
        Next


    End Sub

    Public Function Exibe_campo(ByVal text As String, ByVal StrTot As Integer) As String
        Dim StrCampo As String
        Dim TotStr As Integer
        '             4
        TotStr = Len(text)
        'If TotStr = StrTot Then
        '    StrTot = StrTot + 1
        'End If
        If TotStr > StrTot Then            ' Verifica se Total de String lida é Maior que Parâmetros
            TotStr = StrTot                ' em case positivo equipara quantidades
            text = Mid(text, 1, StrTot)    ' e abstrai string excedentes
        End If
        '             4                  6        4 = 2
        StrCampo = text + Space(StrTot - TotStr)

        Return (StrCampo)
    End Function

    Public Function Exibe_Moeda(ByVal Moeda As Double, ByVal Strtot As Integer) As String
        Dim StrCampo As String
        Dim TotStr As Integer
        TotStr = (Moeda * 100)
        StrCampo = String.Format("{0:D13}", TotStr)

        Return (StrCampo)
    End Function

    Public Function Exibe_Aliq(ByVal Aliquota As Double, ByVal Strtot As Integer) As String
        Dim StrCampo As String
        Dim TotStr As Integer
        TotStr = (Aliquota * 100)
        StrCampo = String.Format("{0:D5}", TotStr)

        Return (StrCampo)
    End Function
    Private Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        If cbo_estabelecimento.SelectedIndex <> -1 Then
            Dim X As Integer
            X = Len(cbo_estabelecimento.SelectedItem)
            Me.txt_razaosocial.Text = Mid(cbo_estabelecimento.SelectedItem, 4, X - 3)
        End If
    End Sub

    Private Sub Frm_Sintegra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        msk_dtinicial.Text = agora
        msk_dtfinal.Text = agora
        ProgressBar1.Maximum = 200
        
    End Sub

    
    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click
        If Me.txt_arquivo.Text = "" Then
            Cria_arq()
        End If
    End Sub

    Public Sub Cria_arq()
        SaveFileDialog1.Filter = "Text files (*.txt)|*.txt"
        Me.txt_arquivo.Text = SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName <> "" Then
            FileOpen(1, SaveFileDialog1.FileName, OpenMode.Output)
            PrintLine(1, txt_arquivo.Text)        ' Copiando texto para o disco
            FileClose(1)

            Me.txt_arquivo.Text = SaveFileDialog1.FileName
        End If
    End Sub
    
    Private Sub Frm_Sintegra_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class