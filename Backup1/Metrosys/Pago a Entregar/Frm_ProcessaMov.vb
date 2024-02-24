Imports Npgsql
Imports System.Text
Imports System.IO
Imports System.DateTime

Public Class Frm_ProcessaMov

    Dim Hoje As Date = Now
    Dim _quantidadePedidos As Integer = 0
    Dim _contador As Integer = 0

    Private Sub Frm_ProcessaMov_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then Me.Close()
    End Sub

    Private Sub Frm_ProcessaMov_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_ProcessaMov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtp_inicial.Focus()
    End Sub

    Private Sub btn_iniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_iniciar.Click

        Dim conn As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Sqlcomm As New StringBuilder
        Dim cmd1 As NpgsqlCommand
        Dim dr1 As NpgsqlDataReader

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message) : Return
        End Try

        'Pega a quantidade de pedidos movimentados durante o período...
        Sqlcomm.Append("SELECT count(nt_orca) FROM loja1.orca1pp WHERE nt_tiposelecao = 1 AND nt_emiss ")
        Sqlcomm.Append("= False AND nt_dtemis BETWEEN '" & Me.dtp_inicial.Text & "' AND '" & Me.dtp_final.Text & "'")
        cmd1 = New NpgsqlCommand(Sqlcomm.ToString, conn)
        dr1 = cmd1.ExecuteReader : _quantidadePedidos = 0

        While dr1.Read

            Try
                _quantidadePedidos = dr1(0)
            Catch ex As Exception
                dr1.Close() : dr1 = Nothing : cmd1 = Nothing : Sqlcomm = Nothing
                conn.ClearPool() : conn.Close() : conn = Nothing

                MsgBox("Não Há Movimento nesse período", MsgBoxStyle.Exclamation)
                Return
            End Try
        End While
        dr1.Close() : cmd1.CommandText = "" : Sqlcomm.Remove(0, Sqlcomm.ToString.Length)
        conn.ClearPool()

        pgb_movimento.Value = 0
        pgb_movimento.Step = 1
        If _quantidadePedidos > 59 Then pgb_movimento.Step = 10
        pgb_movimento.Maximum = _quantidadePedidos


        Dim conn2 As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Sql2 As New StringBuilder
        Dim cmd2 As NpgsqlCommand
        Dim dr2 As NpgsqlDataReader
        Dim pedido As String = "", primeiroVendedor As String = "", primeiroUsuario As String = ""
        Dim participante As String = ""
        Dim i As Integer
        Dim mExiste As Boolean = False
        Dim arrayDeProdPart As Array
        Dim strProdutosPart As New StringBuilder

        Dim conn3 As New Npgsql.NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim Sql3 As New StringBuilder
        Dim cmd3 As New NpgsqlCommand
        Dim transacao As NpgsqlTransaction

        Try
            conn2.Open() : conn3.Open() : transacao = conn3.BeginTransaction
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message) : Return
        End Try

        'Pega os valores dos pedidos no período...
        Sqlcomm.Append("SELECT nt_orca, nt_codig, nt_vend, nt_auto FROM loja1.orca1pp WHERE nt_tiposelecao ")
        Sqlcomm.Append("= 1 AND nt_emiss = False AND nt_dtemis BETWEEN '" & Me.dtp_inicial.Text & "' AND '")
        Sqlcomm.Append(Me.dtp_final.Text & "' ORDER BY nt_codig, nt_orca ASC")
        cmd1 = New NpgsqlCommand(Sqlcomm.ToString, conn)
        dr1 = cmd1.ExecuteReader : _quantidadePedidos = 0

        While dr1.Read


            pedido = dr1(0).ToString

            'Altera status do pedido para processado...
            Sql3.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".orca1pp ")
            Sql3.Append("SET nt_emiss = TRUE WHERE nt_orca = '" & pedido & "'")
            cmd3.Transaction = transacao
            cmd3 = New NpgsqlCommand(Sql3.ToString, conn3)
            cmd3.ExecuteNonQuery()
            Sql3.Remove(0, Sql3.ToString.Length) : cmd3.CommandText = "" : conn3.ClearPool()


            'Se for outro Participante, então pega os valores dos produtos do novo participante...
            If participante.Equals(dr1(1).ToString) = False Then

                participante = dr1(1).ToString
                primeiroVendedor = dr1(2).ToString
                primeiroUsuario = dr1(3).ToString


                'Pega os produtos já processados do CLIENTE em ESTM400...
                Sql2.Append("SELECT DISTINCT gr_codpr FROM " & MdlEmpresaUsu._esqEstab & ".estm400 WHERE ")
                Sql2.Append("gr_cdport = '" & participante & "' ORDER BY gr_codpr ASC")

                cmd2 = New NpgsqlCommand(Sql2.ToString, conn2)
                dr2 = cmd2.ExecuteReader

                strProdutosPart.Append("")
                While dr2.Read

                    strProdutosPart.Append(dr2(0).ToString & "?")
                End While
                dr2.Close() : cmd2.CommandText = "" : Sql2.Remove(0, Sql2.ToString.Length)
                conn2.ClearPool()


                'Pega os valores do produto do cliente no período...
                Sql2.Append("SELECT DISTINCT o2.no_codpr, ( SELECT Sum(o3.no_qtde) FROM loja1.orca2cc o3 WHERE ")
                Sql2.Append("o3.no_cdport = '" & participante & "' AND o3.no_codpr = o2.no_codpr AND ")
                Sql2.Append("o3.no_dtemis BETWEEN '" & Me.dtp_inicial.Text & "' AND '" & Me.dtp_final.Text & "' ")
                Sql2.Append("AND o1.nt_tiposelecao = 1 AND o1.nt_emiss = False ) AS ""Qtde"", ")
                Sql2.Append("est.e_und, est.e_produt FROM " & MdlEmpresaUsu._esqEstab & ".orca1pp o1, ")
                Sql2.Append(MdlEmpresaUsu._esqEstab & ".orca2cc o2 RIGHT JOIN vinc1.est0001 est ")
                Sql2.Append("ON est.e_codig = o2.no_codpr AND est.e_inativo = False WHERE ")
                Sql2.Append("o2.no_cdport = '" & participante & "' AND o2.no_dtemis BETWEEN '" & Me.dtp_inicial.Text & "' ")
                Sql2.Append("AND '" & Me.dtp_final.Text & "' AND o1.nt_tiposelecao = 1 AND o1.nt_emiss = False ")
                Sql2.Append("ORDER BY o2.no_codpr ASC")

                cmd2 = New NpgsqlCommand(Sql2.ToString, conn2)
                dr2 = cmd2.ExecuteReader

                While dr2.Read


                    'Verifica a existência dos produtos já processados do CLIENTE em ESTM400...
                    mExiste = False
                    arrayDeProdPart = Split(strProdutosPart.ToString, "?")
                    If arrayDeProdPart.Length > 0 Then

                        For i = 0 To arrayDeProdPart.Length - 2

                            If dr2(0).ToString.Equals(arrayDeProdPart(i).ToString) Then

                                mExiste = True
                                Exit For
                            End If
                        Next
                    End If


                    If mExiste Then ' Se existir produto no ESTM400, então Altera. Senão existir Inclui...


                        Sql3.Append("UPDATE " & MdlEmpresaUsu._esqEstab & ".estm400 ")
                        Sql3.Append("SET gr_descri = '" & dr2(3).ToString & "', gr_und = '" & dr2(2).ToString & "', ")
                        Sql3.Append("gr_saldo = (gr_saldo + " & dr2(1) & "), gr_pedido = '" & pedido & "', ")
                        Sql3.Append("gr_usu = '" & primeiroVendedor & "' WHERE ")
                        Sql3.Append("gr_cdport = '" & participante & "' AND gr_codpr = '" & dr2(0).ToString & "'")
                        cmd3.Transaction = transacao
                        cmd3 = New NpgsqlCommand(Sql3.ToString, conn3)
                        cmd3.ExecuteNonQuery()

                    Else

                        Sql3.Append("INSERT INTO " & MdlEmpresaUsu._esqEstab & ".estm400(")
                        Sql3.Append("gr_cdport, gr_codpr, gr_descri, gr_und, gr_saldo, gr_pedido, gr_usu) ")
                        Sql3.Append("VALUES (@gr_cdport, @gr_codpr, @gr_descri, @gr_und, @gr_saldo, @gr_pedido, @gr_usu)")
                        cmd3.Transaction = transacao
                        cmd3 = New NpgsqlCommand(Sql3.ToString, conn3)
                        'Parametros
                        cmd3.Parameters.Add("@gr_cdport", participante)
                        cmd3.Parameters.Add("@gr_codpr", dr2(0).ToString)
                        cmd3.Parameters.Add("@gr_descri", dr2(3).ToString)
                        cmd3.Parameters.Add("@gr_und", dr2(2).ToString)
                        cmd3.Parameters.Add("@gr_saldo", dr2(1))
                        cmd3.Parameters.Add("@gr_pedido", pedido)
                        cmd3.Parameters.Add("@gr_usu", primeiroVendedor)
                        cmd3.ExecuteNonQuery()

                    End If
                    Sql3.Remove(0, Sql3.ToString.Length) : cmd3.CommandText = "" : conn3.ClearPool()

                End While
                dr2.Close() : cmd2.CommandText = "" : Sql2.Remove(0, Sql2.ToString.Length)
                strProdutosPart.Remove(0, strProdutosPart.ToString.Length) : conn2.ClearPool()

            End If

            pgb_movimento.PerformStep()

        End While
        dr1.Close() : cmd1.CommandText = "" : Sqlcomm.Remove(0, Sqlcomm.ToString.Length)
        transacao.Commit() : conn.ClearPool() : conn2.ClearAllPools() : conn3.ClearAllPools()
        conn.Close() : conn2.Close() : conn3.Close()
        transacao = Nothing : conn = Nothing : conn2 = Nothing : conn3 = Nothing

        MsgBox("Processo completado com sucesso!")
        Me.Close()

    End Sub

End Class