Imports CrystalDecisions.CrystalReports.Engine
Imports EkaListados

Public Class ListadoControlHoras : Implements IAyudaOpciones, IAyudaClientes, IAyudaEmpleados

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

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAño.KeyPress, txtCliente.KeyPress, txtDesdeEmpleado.KeyPress, txtHastaEmpleado.KeyPress, txtMes.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
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

        For Each c As Control In {txtDesdeEmpleado, txtHastaEmpleado, txtCliente, lblDescCliente}
            c.Text = ""
        Next

        Dim _date As Date = Date.Now

        txtMes.Text = _date.Month
        txtAño.Text = _date.Year

        WControlSocios = txtCliente

    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown, txtAño.KeyDown

        If e.KeyData = Keys.Enter Then

            lblDescCliente.Text = ""

            If Trim(txtCliente.Text) <> "" Then

                Dim WCliente As DataRow = GetSingle("SELECT Razon As Descripcion FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

                If WCliente Is Nothing Then Exit Sub

                lblDescCliente.Text = OrDefault(WCliente.Item("Descripcion"), "")

            End If

            txtMes.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
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

        'Try

        Me.Cursor = Cursors.WaitCursor

            With _GenerarReporte()
                .Mostrar()
            End With


            'Catch ex As SinDatosControlHorasExcepcion

            '    MsgBox(ex.Message, MsgBoxStyle.Exclamation)

            'Catch ex As Exception

            '    MsgBox(ex.Message, MsgBoxStyle.Critical)

            'End Try

            Me.Cursor = Cursors.Default

    End Sub

    Private Function _GenerarReporte() As VistaPrevia
        Dim WDia, WMes, WAnio, WDesdeFecha, WHastaFecha, WImpreDesde, WImpreHasta, WTitulo, WTituloII,
                    WDesdeSocio, WHastaSocio, WDesdeTipo, WHastaTipo As String

        WMes = txtMes.Text.PadLeft(2, "0")
        WAnio = txtAño.Text.PadLeft(4, "0")

        Dim _fecha As String = String.Format("{0}/{1}/{2}", "01", WMes, WAnio)

        Dim WDiaSemana As Integer = Weekday(Date.ParseExact(_fecha, "dd/MM/yyyy", Nothing))
        Dim WUltimoDia As Integer = Date.ParseExact(_fecha, "dd/MM/yyyy", Nothing).AddMonths(1).AddDays(-1).Day

        WImpreDesde = String.Format("{0}/{1}/{2}", "01", WMes, WAnio)
        WImpreHasta = String.Format("{0}/{1}/{2}", WUltimoDia.ToString.PadLeft(2, "0"), WMes, WAnio)

        WDesdeFecha = ordenaFecha(WImpreDesde)
        WHastaFecha = ordenaFecha(WImpreHasta)

        WTitulo = String.Format("Desde el {0} al {1}", WImpreDesde, WImpreHasta)
        WTituloII = ""

        Dim WCliente As DataRow = GetSingle("SELECT Razon FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

        If WCliente IsNot Nothing Then
            WTituloII = OrDefault(WCliente.Item("Razon"), "").ToString.Trim
        End If

        If Val(txtDesdeEmpleado.Text) = 0 Then txtDesdeEmpleado.Text = "0"
        If Val(txtHastaEmpleado.Text) = 0 Then txtHastaEmpleado.Text = "0"
        If Val(txtCliente.Text) = 0 Then txtCliente.Text = "0"

        If Val(txtCliente.Text) = 0 Then
            WDesdeSocio = "0"
            WHastaSocio = "9999"
        End If


        '
        ' Calculamos el Calendario.
        '
        Dim ZDia(100) As String
        Dim ZDiaII(100) As String
        Dim ZVector(100) As String
        Dim ZLugar As Integer = 0


        For j = 1 To WDiaSemana - 1
            ZLugar += 1
            ZDia(ZLugar) = ""
        Next

        For i = 1 To 31

            WDia = i.ToString.PadLeft(2, "0")

            ZLugar += 1
            ZDia(ZLugar) = i
            ZDiaII(i) = ZLugar
            ZVector(ZLugar) = IIf(Val(WDia) <= WUltimoDia, WDia, "")

        Next

        '
        ' Buscamos la informacion en planilla de todos los abogados.
        '
        Dim WSqls As New List(Of String)

        WSqls.Add("DELETE FROM ControlHoras")

        For i = Val(txtDesdeEmpleado.Text) To Val(txtHastaEmpleado.Text)
            Dim ZHoras(100) As Double
            Dim ZHorasImpre(100) As String

            Dim WNombre = ""

            Dim WPlanillas As DataTable = Nothing

            WPlanillas = GetAll("SELECT p.Cliente, p.Fecha, p.Minutos, p.MinutosII, a.Nombre FROM Planilla p LEFT OUTER JOIN Abogado a ON a.Codigo = p.Abogado WHERE p.Abogado = '" & i & "' AND p.OrdFecha BETWEEN '" & WDesdeFecha & "' AND '" & WHastaFecha & "'")

            If WPlanillas.Rows.Count = 0 Then Continue For

            For Each WPlanilla As DataRow In WPlanillas.Rows
                With WPlanilla

                    If Val(txtCliente.Text) = 0 Or OrDefault(.Item("Cliente"), 0) = Val(txtCliente.Text) Then
                        Dim ZDiaCarga As Integer = Val(OrDefault(.Item("Fecha"), "00/00/0000").ToString.Substring(0, 2))

                        ZHoras(ZDiaII(ZDiaCarga)) += OrDefault(.Item("Minutos"), 0) + OrDefault(.Item("MinutosII"), 0)

                        WNombre = OrDefault(.Item("Nombre"), "")
                    End If

                End With
            Next

            For j = 1 To 42

                ZHorasImpre(j) = Trim(Str(ZHoras(j)))

                If ZHoras(j) <> 0 Then

                    Dim WHoraI As Integer = Math.Truncate(ZHoras(j) / 60)
                    Dim WHoraII As Double = ZHoras(j) / 60

                    Dim WDife As Double = 0

                    WDife = (WHoraII - WHoraI) * 100

                    If WDife = 0 Then ZHorasImpre(j) = WHoraI

                    If WDife > 0 And WDife <= 25 Then ZHorasImpre(j) = WHoraI & ".15"

                    If WDife > 25 And WDife <= 50 Then ZHorasImpre(j) = WHoraI & ".30"

                    If WDife > 50 Then ZHorasImpre(j) = WHoraI & ".45"

                End If

            Next

            Dim WRenglon = 0


            For x = 1 To 42 Step 7

                Dim ZSql As String = ""

                Dim WCodigo As String = i
                Dim WClave As String = WCodigo & x.ToString.PadLeft(2, "0")

                WRenglon += 1

                ZSql = String.Format("INSERT INTO ControlHoras (Clave, Abogado, Renglon, Nombre, Impre1, Horas1, Impre2, Horas2, Impre3, Horas3, Impre4, Horas4, Impre5, Horas5, Impre6, Horas6, Impre7, Horas7, Titulo1, Titulo2)" _
                                     & " VALUES ('{0}', '{1}', '{2}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}')",
                                    WClave, i, WRenglon, "", Trim(WNombre).ToUpper, ZVector(x), ZHorasImpre(x), ZVector(x + 1), ZHorasImpre(x + 1), ZVector(x + 2), ZHorasImpre(x + 2), ZVector(x + 3), ZHorasImpre(x + 3), ZVector(x + 4), ZHorasImpre(x + 4), ZVector(x + 5), ZHorasImpre(x + 5), ZVector(x + 6), ZHorasImpre(x + 6), WTitulo, Trim(WTituloII).ToUpper)

                WSqls.Add(ZSql)

            Next

        Next

        ExecuteNonQueries(WSqls.ToArray)

        'Dim WControlHorasCheck As DataRow = GetSingle("SELECT TOP 1 Clave FROM ControlHoras")

        'If WControlHorasCheck Is Nothing Then Throw New SinDatosControlHorasExcepcion("No se encontraron datos para mostrar/imprimir")

        Dim rpt As New controlhoras
        Dim frm As New VistaPrevia

        With frm
            .Reporte = rpt
        End With

        Return frm

    End Function

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            With _GenerarReporte()
                .Imprimir()
            End With


        Catch ex As SinDatosControlHorasExcepcion

            MsgBox(ex.Message, MsgBoxStyle.Exclamation)

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub txtHastaEmpleado_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtHastaEmpleado.MouseDoubleClick, txtDesdeEmpleado.MouseDoubleClick
        Dim frm As New AyudaEmpleados
        frm.Show(Me)
    End Sub

    Public Sub _ProcesarAyudaEmpleados(Codigo As Object, Descripcion As Object) Implements IAyudaEmpleados._ProcesarAyudaEmpleados
        txtDesdeEmpleado.Text = Codigo
        txtHastaEmpleado.Text = Codigo
        txtCliente.Focus()
    End Sub

    Private Sub txtDesdeEmpleado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesdeEmpleado.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesdeEmpleado.Text) = "" Then : Exit Sub : End If

            txtHastaEmpleado.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesdeEmpleado.Text = ""
        End If

    End Sub

    Private Sub txtHastaEmpleado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHastaEmpleado.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHastaEmpleado.Text) = "" Then : Exit Sub : End If

            txtCliente.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHastaEmpleado.Text = ""
        End If

    End Sub

    Private Sub txtMes_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMes.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtMes.Text) = "" Then : Exit Sub : End If

            txtAño.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtMes.Text = ""
        End If

    End Sub
End Class