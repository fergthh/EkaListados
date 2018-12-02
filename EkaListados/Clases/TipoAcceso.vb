Module AccesoAbogado
    Private _TipoAcceso As String

    Public ReadOnly Property TipoAcceso() As String
        Get
            Return My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Environment\ControlHorasAcceso", "TipoAcceso", 0)
        End Get
    End Property

    Public Property Id() As String

End Module
