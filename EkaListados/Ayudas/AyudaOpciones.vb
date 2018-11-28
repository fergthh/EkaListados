Public Class AyudaOpciones

    Sub New(ParamArray WOpciones As Object())

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        lstOpciones.Items.Clear()

        For Each item As Object In WOpciones
            lstOpciones.Items.Add(item)
        Next

    End Sub

    Private Sub AyudaOpciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AyudaOpciones_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If lstOpciones.Items.Count > 0 Then
            lstOpciones.SetSelected(0, True)
        End If
    End Sub

    Private Sub lstOpciones_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstOpciones.MouseDoubleClick
        If lstOpciones.SelectedIndex < 0 Then Exit Sub

        Dim WOwner As IAyudaOpciones = CType(Owner, IAyudaOpciones)

        If WOwner IsNot Nothing Then
            WOwner._ProcesarAyudaOpciones(lstOpciones.SelectedIndex)
        End If

        Close()

    End Sub
End Class