
Imports Microsoft.Win32

Public Class Inicio

    Private WTipoAcceso As String

    Private Sub Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        My.Computer.Registry.CurrentUser.CreateSubKey("Environment\ControlHorasAcceso")

        'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Environment\ControlHorasAcceso\", "TipoAcceso", 0)

        WTipoAcceso = Registry.GetValue("HKEY_CURRENT_USER\Environment\ControlHorasAcceso", "TipoAcceso", 0)

        Button1.Text = IIf(Val(WTipoAcceso) = 1, "Inhabilitar Acceso Total", "Conceder Acceso Total")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Val(WTipoAcceso) = 0 Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Environment\ControlHorasAcceso\", "TipoAcceso", 1)
        Else
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Environment\ControlHorasAcceso\", "TipoAcceso", 0)
        End If

        WTipoAcceso = Registry.GetValue("HKEY_CURRENT_USER\Environment\ControlHorasAcceso", "TipoAcceso", 0)

        Button1.Text = IIf(Val(WTipoAcceso) = 1, "Inhabilitar Acceso Total", "Conceder Acceso Total")

    End Sub
End Class