Public Class Frm_ManTabelaPrecos
    Dim _clBD As New Cl_bdMetrosys

    Private Sub btn_atualizarTudo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_atualizarTudo.Click

        _clBD.deleteRegistrosTabelaPrecos(MdlConexaoBD.conectionPadrao, MdlEmpresaUsu._esqVinc, MdlEmpresaUsu._vinculo)
        _clBD.preencheTodaTabelaPrecos(MdlConexaoBD.conectionPadrao, MdlEmpresaUsu._esqVinc, MdlEmpresaUsu._vinculo)
        _clBD.atualTodaTabelaPrecos(MdlConexaoBD.conectionPadrao, MdlEmpresaUsu._esqVinc, MdlEmpresaUsu._vinculo, _
                                    MdlUsuarioLogando._local.Substring(3, 2))
    End Sub
End Class