Public Class AyudaEmpleados
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim WEmpleados As DataTable = GetAll("SELECT Codigo, Nombre as Descripcion FROM Abogado ORDER BY Codigo")

        If WEmpleados.Rows.Count > 0 Then

            dgvDatos.DataSource = WEmpleados

        End If

    End Sub
    Private Sub AyudaClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtFiltrar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyUp
        Dim WTabla As DataTable = CType(dgvDatos.DataSource, DataTable)

        If WTabla IsNot Nothing Then
            WTabla.DefaultView.RowFilter = String.Format("Descripcion LIKE '%{0}%'", txtFiltrar.Text)
        End If

    End Sub

    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown

        If e.KeyData = Keys.Escape Then
            txtFiltrar.Text = ""
        End If

    End Sub

    Private Sub dgvDatos_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDatos.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WOWner As IAyudaEmpleados = CType(Me.Owner, IAyudaEmpleados)

        If WOWner IsNot Nothing Then
            With dgvDatos.CurrentRow
                Dim WCodigo = OrDefault(.Cells("Codigo").Value, "")
                Dim WDesc = OrDefault(.Cells("Descripcion").Value, "")
                WOWner._ProcesarAyudaEmpleados(WCodigo, WDesc)
            End With
        End If

        Close()

    End Sub
End Class