Public Class SinDatosControlHorasExcepcion : Inherits Exception
    Sub New(Optional ByVal msg As String = "")
        MyBase.New(msg)
    End Sub
End Class
