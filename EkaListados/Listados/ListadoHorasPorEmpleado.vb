Imports CrystalDecisions.CrystalReports.Engine
Imports EkaListados

Public Class ListadoHorasPorEmpleado : Implements IAyudaOpciones, IAyudaClientes, IAyudaEmpleados

    Dim WControlSocios As Control = Nothing

    Public Sub _ProcesarAyudaOpciones(indice As Object) Implements IAyudaOpciones._ProcesarAyudaOpciones

        Dim frm As Form = Nothing
        WControlSocios = Nothing

        Select Case indice

            Case 0 ' Clientes
                frm = New AyudaClientes
            Case 1 ' Responsables
                frm = New AyudaEmpleados
        End Select

        If frm Is Nothing Then Exit Sub

        frm.Show(Me)

    End Sub

    Public Sub _ProcesarAyudaClientes(Codigo As Object, Descripcion As Object) Implements IAyudaClientes._ProcesarAyudaClientes
        txtCliente.Text = Codigo
        lblDescCliente.Text = Trim(Descripcion)
    End Sub

    Private Sub ListadoHorasPorCliente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtDesdeEmpleado.Focus()
    End Sub

    Private Sub ListadoHorasPorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _Limpiar()
    End Sub

    Private Sub _Limpiar()

        For Each c As Control In {txtDesdeEmpleado, txtDesdeFecha, txtHastaEmpleado, txtHastaFecha, txtCliente, lblDescCliente}
            c.Text = ""
        Next

        Dim _date As Date = Date.Now
        Dim primerdia = New Date(_date.Year, _date.Month, 1)
        Dim ultimodia = primerdia.AddMonths(1).AddDays(-1)

        txtDesdeFecha.Text = primerdia.ToString("dd/MM/yyyy")
        txtHastaFecha.Text = ultimodia.ToString("dd/MM/yyyy")

        For Each c As ComboBox In {cmbTipoI, cmbTipoII}
            c.SelectedIndex = 0
        Next

        WControlSocios = txtCliente

    End Sub

    Private Sub txtDesdeCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesdeEmpleado.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesdeEmpleado.Text) = "" Then : Exit Sub : End If

            txtHastaEmpleado.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesdeEmpleado.Text = ""
        End If

    End Sub

    Private Sub txtHastaCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHastaEmpleado.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHastaEmpleado.Text) = "" Then : Exit Sub : End If

            txtDesdeFecha.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHastaEmpleado.Text = ""
        End If

    End Sub

    Private Sub txtDesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesdeFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtDesdeFecha.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not _ValidarFecha(txtDesdeFecha.Text) Then Exit Sub

            txtHastaFecha.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesdeFecha.Text = ""
        End If

    End Sub

    Private Sub txtHastaFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHastaFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtDesdeFecha.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not _ValidarFecha(txtHastaFecha.Text) Then Exit Sub

            txtCliente.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHastaFecha.Text = ""
        End If

    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then

            lblDescCliente.Text = ""

            If Trim(txtCliente.Text) <> "" Then

                Dim WCliente As DataRow = GetSingle("SELECT Razon As Descripcion FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

                If WCliente Is Nothing Then Exit Sub

                lblDescCliente.Text = OrDefault(WCliente.Item("Descripcion"), "")

            End If

            cmbTipoI.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

    End Sub

    Private Sub cmbTipoI_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoI.KeyDown

        If e.KeyData = Keys.Enter Then

            cmbTipoII.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            cmbTipoI.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnConsultas_Click(sender As Object, e As EventArgs) Handles btnConsultas.Click

        With New AyudaOpciones({"Clientes", "Empleados"})
            .Show(Me)
        End With

    End Sub

    Private Sub txtCliente_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtCliente.MouseDoubleClick
        Dim frm As New AyudaClientes
        frm.Show(Me)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnPantalla_Click(sender As Object, e As EventArgs) Handles btnPantalla.Click
        With _GenerarReporte()
            .Mostrar()
        End With
    End Sub

    Private Function _GenerarReporte() As VistaPrevia
        Dim WDia, WMes, WAnio, WDesdeFecha, WHastaFecha, WImpreDesde, WImpreHasta, WTitulo,
                    WDesdeSocio, WHastaSocio, WDesdeTipo, WHastaTipo As String

        WDia = txtDesdeFecha.Text.Substring(0, 2)
        WMes = txtDesdeFecha.Text.Substring(3, 2)
        WAnio = txtDesdeFecha.Text.Substring(6, 4)
        WDesdeFecha = ordenaFecha(txtDesdeFecha.Text)
        WHastaFecha = ordenaFecha(txtHastaFecha.Text)

        WImpreDesde = String.Format("{0}/{1}/{2}", WDia, WMes, WAnio)
        WImpreHasta = String.Format("{0}/{1}/{2}", WDia, WMes, WAnio)

        WTitulo = String.Format("Desde el {0} al {1}", WImpreDesde, WImpreHasta)

        Dim WCliente As DataRow = GetSingle("SELECT Provincia FROM Cliente WHERE Cliente = '" & txtDesdeEmpleado.Text & "'")

        If WCliente IsNot Nothing Then
            If OrDefault(WCliente.Item("Provincia"), 0) = 24 Then
                WImpreDesde = String.Format("{0}/{1}/{2}", WMes, WDia, WAnio)
                WImpreHasta = String.Format("{0}/{1}/{2}", WDia, WMes, WAnio)
                WTitulo = String.Format("Period from {0} to {1}", WImpreDesde, WImpreHasta)
            End If
        End If

        ExecuteNonQueries("UPDATE Empresa SET Impre1 = '" & WTitulo & "' WHERE Codigo = '1'")

        If Val(txtDesdeEmpleado.Text) = 0 Then txtDesdeEmpleado.Text = "0"
        If Val(txtHastaEmpleado.Text) = 0 Then txtHastaEmpleado.Text = "0"
        If Val(txtCliente.Text) = 0 Then txtCliente.Text = "0"

        If Val(txtCliente.Text) = 0 Then
            WDesdeSocio = "0"
            WHastaSocio = "9999"
        End If

        WDesdeTipo = ""
        WHastaTipo = ""
        Select Case cmbTipoII.SelectedIndex
            Case 0
                WHastaTipo = "Z"
            Case 1
                WDesdeTipo = ""
                WHastaTipo = ""
            Case Else
                WDesdeTipo = "E"
                WHastaTipo = "E"
        End Select

        Dim rpt As ReportDocument
        Dim frm As New VistaPrevia

        Select Case cmbTipoI.SelectedIndex
            Case 0
                rpt = New listahoraspersonaltarea
            Case 1
                rpt = New listaleo
            Case 2
                rpt = New listahoraspersonaltareaii
            Case 3
                rpt = New listahoraspersonaltareaiv
            Case 4
                rpt = New listahoraspersonaltareanuevo
            Case Else
                rpt = New listaleonuevo
        End Select

        With frm
            .Reporte = rpt
            .Formula = "{Planilla.OrdFecha} IN '" & WDesdeFecha & "' To '" & WHastaFecha & "' AND {Planilla.Cliente} IN " & txtCliente.Text & " To " & txtCliente.Text & "" _
                        & " AND {Planilla.Abogado} IN " & txtDesdeEmpleado.Text & " To " & txtHastaEmpleado.Text & " AND {Planilla.TipoHora} IN '" & WDesdeTipo & "' To '" & WHastaTipo & "'"
        End With

        Return frm

    End Function

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        With _GenerarReporte()
            .Imprimir()
        End With
    End Sub

    Private Sub txtHastaEmpleado_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtHastaEmpleado.MouseDoubleClick, txtDesdeEmpleado.MouseDoubleClick
        Dim frm As New AyudaEmpleados
        frm.Show(Me)
    End Sub

    Public Sub _ProcesarAyudaEmpleados(Codigo As Object, Descripcion As Object) Implements IAyudaEmpleados._ProcesarAyudaEmpleados
        txtDesdeEmpleado.Text = Codigo
        txtHastaEmpleado.Text = Codigo
        txtDesdeFecha.Focus()
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHastaEmpleado.KeyPress, txtDesdeEmpleado.KeyPress, txtCliente.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class