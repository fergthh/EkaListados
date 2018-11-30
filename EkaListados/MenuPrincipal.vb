Imports EkaListados

Public Class MenuPrincipal
    Private Sub LsiatdoDeHorasPorClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LsiatdoDeHorasPorClienteToolStripMenuItem.Click
        _Abrir(New ListadoHorasPorCliente)
    End Sub

    Private Sub _Abrir(frm As Form)
        frm.Show(Me)
    End Sub

End Class