Imports EkaListados

Public Class ListadoHorasPorCliente : Implements IAyudaSocios, IAyudaOpciones, IAyudaClientes

    Dim WControlSocios As Control = Nothing

    Public Sub _ProcesarAyudaSocios(Codigo As Object, Descripcion As Object) Implements IAyudaSocios._ProcesarAyudaSocios
        Select Case WControlSocios.Name
            Case txtResponsable.Name

                txtResponsable.Text = Codigo
                lblDescResponsable.Text = Trim(Descripcion)

            Case txtOrigen.Name

                txtOrigen.Text = Codigo
                lblDescOrigen.Text = Trim(Descripcion)

            Case Else
                Exit Sub
        End Select
    End Sub

    Public Sub _ProcesarAyudaOpciones(indice As Object) Implements IAyudaOpciones._ProcesarAyudaOpciones

        Dim frm As Form = Nothing
        WControlSocios = Nothing

        Select Case indice

            Case 0 ' Clientes
                frm = New AyudaClientes
            Case 1 ' Responsables
                frm = New AyudaSocios
                WControlSocios = txtResponsable
            Case 2 ' Origen
                frm = New AyudaSocios
                WControlSocios = txtOrigen
        End Select

        If frm Is Nothing Then Exit Sub

        frm.Show(Me)

    End Sub

    Public Sub _ProcesarAyudaClientes(Codigo As Object, Descripcion As Object) Implements IAyudaClientes._ProcesarAyudaClientes
        txtDesdeCliente.Text = Codigo
        txtHastaCliente.Text = Codigo
        txtDesdeCliente.Focus()
    End Sub

    Private Sub ListadoHorasPorCliente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtDesdeCliente.Focus()
    End Sub

    Private Sub ListadoHorasPorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _Limpiar()
    End Sub

    Private Sub _Limpiar()

        For Each c As Control In {lblDescOrigen, txtDesdeAsunto, txtDesdeCliente, txtDesdeFecha, txtHastaAsunto, txtHastaCliente, txtHastaFecha, txtOrigen, txtResponsable, lblDescResponsable}
            c.Text = ""
        Next

        Dim _date As Date = Date.Now
        Dim primerdia = New Date(_date.Year, _date.Month, 1)
        Dim ultimodia = primerdia.AddMonths(1).AddDays(-1)

        txtDesdeFecha.Text = primerdia.ToString("dd/MM/yyyy")
        txtHastaFecha.Text = ultimodia.ToString("dd/MM/yyyy")

        txtDesdeAsunto.Text = "0"
        txtHastaAsunto.Text = "9999"

        For Each c As ComboBox In {cmbTipoI, cmbTipoII}
            c.SelectedIndex = 0
        Next

        WControlSocios = txtResponsable

    End Sub

    Private Sub txtDesdeCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesdeCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesdeCliente.Text) = "" Then : Exit Sub : End If

            txtHastaCliente.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesdeCliente.Text = ""
        End If

    End Sub

    Private Sub txtHastaCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHastaCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHastaCliente.Text) = "" Then : Exit Sub : End If

            txtDesdeFecha.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHastaCliente.Text = ""
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

            txtDesdeAsunto.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHastaFecha.Text = ""
        End If

    End Sub

    Private Sub txtDesdeAsunto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesdeAsunto.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtDesdeAsunto.Text) = "" Then : Exit Sub : End If

            txtHastaAsunto.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesdeAsunto.Text = ""
        End If

    End Sub

    Private Sub txtHastaAsunto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHastaAsunto.KeyDown

        If e.KeyData = Keys.Enter Then
            '   If Trim(txtHastaAsunto.Text) = "" Then : Exit Sub : End If

            txtResponsable.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHastaAsunto.Text = ""
        End If

    End Sub

    Private Sub txtResponsable_KeyDown(sender As Object, e As KeyEventArgs) Handles txtResponsable.KeyDown

        If e.KeyData = Keys.Enter Then

            lblDescResponsable.Text = ""

            If Trim(txtResponsable.Text) <> "" Then

                Dim WResp As DataRow = GetSingle("SELECT Descripcion FROM Socios WHERE Codigo = '" & txtResponsable.Text & "'")

                If WResp Is Nothing Then Exit Sub

                lblDescResponsable.Text = OrDefault(WResp.Item("Descripcion"), "")

            End If

            txtOrigen.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtResponsable.Text = ""
        End If

    End Sub

    Private Sub txtOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrigen.KeyDown

        If e.KeyData = Keys.Enter Then

            lblDescOrigen.Text = ""

            If Trim(txtOrigen.Text) <> "" Then

                Dim WResp As DataRow = GetSingle("SELECT Descripcion FROM Socios WHERE Codigo = '" & txtOrigen.Text & "'")

                If WResp Is Nothing Then Exit Sub

                lblDescOrigen.Text = OrDefault(WResp.Item("Descripcion"), "")

            End If

            cmbTipoI.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtOrigen.Text = ""
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

        With New AyudaOpciones({"Clientes", "Responsables", "Origen"})
            .Show(Me)
        End With

    End Sub

    Private Sub txtResponsable_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtResponsable.MouseDoubleClick
        Dim frm As New AyudaSocios
        WControlSocios = txtResponsable
        frm.Show(Me)
    End Sub

    Private Sub txtOrigen_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtOrigen.MouseDoubleClick
        Dim frm As New AyudaSocios
        WControlSocios = txtOrigen
        frm.Show(Me)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub txtDesdeCliente_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtHastaCliente.MouseDoubleClick, txtDesdeCliente.MouseDoubleClick
        Dim frm As New AyudaClientes
        frm.Show(Me)
    End Sub

    Private Sub btnPantalla_Click(sender As Object, e As EventArgs) Handles btnPantalla.Click
        Dim WDia, WMes, WAnio, WDesde, WHasta, WImpreDesde, WImpreHasta, WTitulo,
            WDesdeSocio, WHastaSocio, WDesdeSocioII, WHastaSocioII, WDesdeTipo, WHastaTipo As String

        WDia = txtDesdeFecha.Text.Substring(0, 2)
        WMes = txtDesdeFecha.Text.Substring(3, 2)
        WAnio = txtDesdeFecha.Text.Substring(6, 4)
        WDesde = ordenaFecha(txtDesdeFecha.Text)
        WHasta = ordenaFecha(txtHastaFecha.Text)

        WImpreDesde = String.Format("{0}/{1}/{2}", WDia, WMes, WAnio)
        WImpreHasta = String.Format("{0}/{1}/{2}", WDia, WMes, WAnio)

        WTitulo = String.Format("Desde el {0} al {1}", WImpreDesde, WImpreHasta)

        Dim WCliente As DataRow = GetSingle("SELECT Provincia FROM Cliente WHERE Cliente = '" & txtDesdeCliente.Text & "'")

        If WCliente IsNot Nothing Then
            If OrDefault(WCliente.Item("Provincia"), 0) = 24 Then
                WImpreDesde = String.Format("{0}/{1}/{2}", WMes, WDia, WAnio)
                WImpreHasta = String.Format("{0}/{1}/{2}", WDia, WMes, WAnio)
                WTitulo = String.Format("Period from {0} to {1}", WImpreDesde, WImpreHasta)
            End If
        End If

        ExecuteNonQueries("UPDATE Empresa SET Impre1 = '" & WTitulo & "' WHERE Codigo = '1'")

        If Val(txtDesdeCliente.Text) = 0 Then txtDesdeCliente.Text = "0"
        If Val(txtHastaCliente.Text) = 0 Then txtHastaCliente.Text = "0"
        If Val(txtDesdeAsunto.Text) = 0 Then txtDesdeAsunto.Text = "0"
        If Val(txtHastaAsunto.Text) = 0 Then txtHastaAsunto.Text = "0"

        WDesdeSocio = txtResponsable.Text
        WHastaSocio = WDesdeSocio
        WDesdeSocioII = txtOrigen.Text
        WHastaSocioII = WDesdeSocioII

        If Val(txtResponsable.Text) = 0 Then
            WDesdeSocio = "0"
            WHastaSocio = "9999"
        End If

        If Val(txtOrigen.Text) = 0 Then
            WDesdeSocioII = "0"
            WHastaSocioII = "9999"
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

        Dim rpt As New ListaHorasclientetarea
        Dim frm As New VistaPrevia

        With frm
            .Reporte = rpt
            .Formula = "{Planilla.OrdFecha} IN '" & WDesde & "' To '" & WHasta & "' AND {Planilla.Cliente} IN " & txtDesdeCliente.Text & " To " & txtHastaCliente.Text & "" _
                    & " AND {Planilla.Asunto} IN " & txtDesdeAsunto.Text & " To " & txtHastaAsunto.Text & " AND {Planilla.TipoHora} IN '" & WDesdeTipo & "' To '" & WHastaTipo & "'" _
                    & " AND {Cliente.Socio} IN " & WDesdeSocio & " To " & WHastaSocio & "" _
                    & " AND {Cliente.SocioII} IN " & WDesdeSocioII & " To " & WHastaSocioII & ""
            .Mostrar()
        End With

    End Sub
End Class