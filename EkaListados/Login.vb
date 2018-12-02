Public Class Login
    Private Sub Login_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim WAbogado As DataRow = GetSingle("SELECT Codigo, Clave FROM Abogado WHERE UPPER(Clave) = '" & TextBox1.Text.ToUpper.Trim & "'")

        If WAbogado IsNot Nothing Then
            AccesoAbogado.Id = WAbogado.Item("Codigo")
            MenuPrincipal.Show()
            Close()
            Exit Sub
        End If

        MsgBox("Clave Incorrecta")

        TextBox1.Focus()

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If AccesoAbogado.TipoAcceso = "1" Then
            AccesoAbogado.Id = ""
            MenuPrincipal.Show()
            Close()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(TextBox1.Text) = "" Then : Exit Sub : End If

            Button1.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            TextBox1.Text = ""
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class