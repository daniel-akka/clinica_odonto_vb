Imports System
Imports System.Data
Imports System.IO
Imports System.Drawing.Printing
Imports System.Text
Imports Npgsql

Public Class Frm_RestauraParticipante

    Private Const _valorZERO As Integer = 0
    Public Shared _FrmRef As New Frm_RestauraParticipante
    Private _ufCorrenteCbo As String = ""
    Private _clFunc As New ClFuncoes
    Private _clBD As New Cl_bdMetrosys


    Private Sub btn_inclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim IncPort As New Frm_MCadastroInc
        IncPort.btn_incluir.Enabled = True : IncPort.btn_alterar.Enabled = False
        IncPort.ShowDialog()
        consultaBD()

    End Sub

    Private Sub Frm_RestauraParticipante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                consultaBD()

        End Select



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
            sqlPart.Remove(_valorZERO, sqlPart.ToString.Length)
            sqlPart.Append("SELECT p_cod AS ""CODIGO"", p_portad AS ""NOME/RAZAO"", p_fantas AS ""FANTASIA"", ") '2
            sqlPart.Append("p_cpf AS ""CPF"", p_cgc AS ""CNPJ"", p_end AS ""ENDER"", p_bairro AS ""BAIRRO"", ") '6
            sqlPart.Append("p_cid AS ""CIDADE"", p_uf AS ""UF"" ") '8
            sqlPart.Append("FROM cadp001 WHERE p_inativo = TRUE ")


            If Me.rdb_cnpj_cpf.Checked = True Then

                nomeCampo = "p_cgc" : nomeCampoAux = "p_cpf"
            Else

                nomeCampo = "p_portad"
            End If

            If Not nomeCampoAux.Equals("") Then 'se for CPF ou CNPJ, entao...

                If Not Trim(Me.txt_pesquisa.Text).Equals("") Then

                    sqlPart.Append("AND " & nomeCampo & " LIKE '" & Me.txt_pesquisa.Text & "%' OR " & nomeCampoAux & " LIKE '" & Me.txt_pesquisa.Text & "%' ") ' 

                End If
            Else

                If Not Trim(Me.txt_pesquisa.Text).Equals("") Then

                    sqlPart.Append("AND UPPER(" & nomeCampo & ") LIKE '" & Me.txt_pesquisa.Text & "%' ") 'ORDER BY p_portad ASC
                End If
            End If



            If Not nomeCampoAux.Equals("") Then 'se for CPF ou CNPJ, entao...

                sqlPart.Append("ORDER BY p_portad ASC")
            Else

                sqlPart.Append("ORDER BY p_portad ASC") 'ORDER BY p_portad ASC
            End If



            daPart = New NpgsqlDataAdapter(sqlPart.ToString, oConnBDGENOV) : dtPart = New DataTable
            daPart.Fill(dtPart) : Me.dtg_portadores.DataSource = dtPart : Me.dtg_portadores.Refresh()

            If Me.dtg_portadores.Rows.Count > _valorZERO Then

                Me.dtg_portadores.Columns(_valorZERO).Width = 65 'Codigo
                Me.dtg_portadores.Columns(1).Width = 250 'Portad
                Me.dtg_portadores.Columns(2).Width = 200 'fantasia
                Me.dtg_portadores.Columns(3).Width = 80 'dtcad
            End If

            lbl_registros.Text = Me.dtg_portadores.Rows.Count

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

    Private Sub Frm_RestauraParticipante_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        consultaBD()

    End Sub

    Private Sub rdb_cnpj_cpf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_cnpj_cpf.CheckedChanged, rdb_nome.CheckedChanged

        If rdb_cnpj_cpf.Checked = True Then

            Me.lbl_pesquisa.Text = "CNPJ/CPF:" : Me.txt_pesquisa.SetBounds(219, 20, 119, 23)
            Me.txt_pesquisa.MaxLength = 20 : Me.txt_pesquisa.Text = ""
            consultaBD()

        End If


        If rdb_nome.Checked = True Then

            Me.lbl_pesquisa.Text = "NOME:" : Me.txt_pesquisa.SetBounds(190, 20, 320, 23)
            Me.txt_pesquisa.MaxLength = 65 : Me.txt_pesquisa.Text = ""
            consultaBD()

        End If



    End Sub


    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        consultaBD()

    End Sub

    Private Sub executaRestaura()

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
            Dim mCodigoPart As String = Me.dtg_portadores.CurrentRow.Cells(_valorZERO).Value.ToString
            _clBD.habilitaParticipante(conection, transacao, mCodigoPart)
            mCodigoPart = Nothing : transacao.Commit()

            MsgBox("Participante Restaurado com sucesso", MsgBoxStyle.Exclamation)
            conection.Close() : consultaBD()

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


    Private Sub btn_restaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_restaurar.Click


        Try
            If dtg_portadores.CurrentRow.IsNewRow = False Then

                executaRestaura()

            Else
                MsgBox("Selecione um Participante!", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
        End Try
        
    End Sub

End Class