﻿Public Class MenuPrincipal
    Private Sub LsiatdoDeHorasPorClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LsiatdoDeHorasPorClienteToolStripMenuItem.Click
        _Abrir(New ListadoHorasPorCliente)
    End Sub

    Private Sub _Abrir(frm As Form)
        frm.Show(Me)
    End Sub

    Private Sub ListadoDeHorasPorEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeHorasPorEmpleadoToolStripMenuItem.Click
        _Abrir(New ListadoHorasPorEmpleado)
    End Sub

    Private Sub ListadoDeControlPorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeControlPorToolStripMenuItem.Click
        _Abrir(New ListadoControlHoras)
    End Sub

    Private Sub CerrarSistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSistemaToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub MenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.LsiatdoDeHorasPorClienteToolStripMenuItem.Enabled = True
        Me.ListadoDeControlPorToolStripMenuItem.Enabled = True

        If AccesoAbogado.TipoAcceso = "0" Then
            Me.LsiatdoDeHorasPorClienteToolStripMenuItem.Enabled = False
            Me.ListadoDeControlPorToolStripMenuItem.Enabled = False
        End If

    End Sub
End Class