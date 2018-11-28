Module Helper

    Private Const VALIDA_CUIT = "54327654321"

    Public Function OrDefault(ByVal valor As Object, ByVal WDefault As Object)

        If valor Is Nothing OrElse IsDBNull(valor) Then Return WDefault

        Return valor

    End Function

    Public Function getNombrePC() As String
        Return My.Computer.Name
    End Function

    Public Function ordenaFecha(ByVal fecha As DBNull)
        Return 0
    End Function

    Public Function ordenaFecha(ByVal fecha As String)

        Dim txtOrdenaFecha As String

        If Trim(fecha).Length = 10 Then
            txtOrdenaFecha = Right$(fecha, 4) + Mid$(fecha, 4, 2) + Left$(fecha, 2)
        Else
            txtOrdenaFecha = "0"
        End If

        Return txtOrdenaFecha

    End Function

    Public Function DesOrdenaFecha(ByVal fecha As String, Optional ByVal separador As String = "/")

        Dim txtOrdenaFecha As String

        txtOrdenaFecha = Right$(fecha, 2) & separador & Mid$(fecha, 5, 2) & separador & Left$(fecha, 4)

        Return txtOrdenaFecha

    End Function

    Public Function ceros(ByVal campoii As String, ByVal largoii As Integer)

        Return campoii.Trim.PadLeft(largoii, "0")

    End Function

    Public Function formatonumerico(ByVal valor As DBNull, Optional ByVal decimales As Integer = 2)
        Return formatonumerico(0, decimales)
    End Function

    Public Function formatonumerico(ByVal valor As String, Optional ByVal decimales As Integer = 2)
        Dim _valor As Double = 0
        Dim formato = "########0."

        valor = IIf(Trim(valor) = "", "0", Trim(valor))

        valor = valor.Replace(".", ",")

        ' Redondeamos a los decimales indicados con "." como separador de decimales.
        _valor = FormatNumber(CDbl(valor), decimales)

        For i = 1 To decimales - 1
            formato &= "#"
        Next

        formato &= "0"

        Return formatonumerico(_valor, formato, ".")

    End Function

    Public Function formatonumerico(ByVal valor As Double, ByVal formato As String, ByVal formatoII As String)

        Dim txtnumero As String

        txtnumero = Format(valor, formato)
        If formatoII = "." Then
            txtnumero = txtnumero.Replace(",", ".")
        End If

        Return txtnumero

    End Function

    Public Function CuitValido(ByVal cuit As String) As Boolean
        Dim valido As Boolean = False
        Dim suma As Integer = 0
        cuit = Trim(cuit).Replace("-", "")

        If cuit.Length = 11 Then
            For i = 1 To 11
                suma = suma + (Val(Mid(cuit, i, 1)) * Val(Mid(VALIDA_CUIT, i, 1)))
            Next

            If suma > 0 Then
                valido = suma Mod 11 = 0
            End If
        End If

        Return valido
    End Function

    Public Function CaculoRetencionGanancia(ByVal varTipoprv As Integer, ByVal varAcumulaNeto As Double, ByVal varAcuNeto As Double, ByVal varAcuRetenido As Double, ByVal varAcuAnticipo As Double,
                                        ByVal varAcuBruto As Double, ByVal varAcuIva As Double)

        Dim varRetencion, varBase As Double
        Dim varMinimo As Double
        Dim varAcumuladPago As Double
        Dim varAuxi, varTasa, varTope, varTope1, varSum As Double
        Dim varParametro(100) As Double
        Dim varTasa1(100) As Double

        varParametro(0) = 0
        varParametro(1) = 2000
        varParametro(2) = 4000
        varParametro(3) = 8000
        varParametro(4) = 14000
        varParametro(5) = 24000
        varParametro(6) = 1000000

        varTasa1(1) = 0.1
        varTasa1(2) = 0.14
        varTasa1(3) = 0.18
        varTasa1(4) = 0.22
        varTasa1(5) = 0.26
        varTasa1(6) = 0.28

        varRetencion = 0

        If varTipoprv = 1 Or varTipoprv = 2 Or varTipoprv = 3 Or varTipoprv = 6 Or varTipoprv = 7 Then

            varBase = varAcuNeto

            Select Case varTipoprv
                Case 1
                    varMinimo = 100000
                Case 2
                    varMinimo = 7500
                Case 3
                    varMinimo = 5000
                Case 6
                    varMinimo = 30000
                Case 7
                    varMinimo = 30000
            End Select

            varAcumuladPago = varAcumulaNeto + varBase
            varAuxi = varAcumuladPago - varMinimo

            If varAuxi <= 0 Then
                varAuxi = 0
                varRetencion = 0
            End If

            varTasa = 0.02
            If varTipoprv = 1 Then
                varTasa = 0.02
            End If
            If varTipoprv = 3 Then
                varTasa = 0.06
            End If
            If varTipoprv = 7 Then
                varTasa = 0.0025
            End If

            Select Case varTipoprv
                Case 2
                    varRetencion = 0
                    varTope = 0
                    varTope1 = 0

                    For da = 0 To 5
                        If varAuxi >= varParametro(da) And varAuxi < varParametro(da + 1) Then
                            varTope1 = varAuxi
                            varTope = varParametro(da)
                            varSum = varTope1 - varTope
                            varSum = varSum * varTasa1(da + 1)
                            varRetencion = varRetencion + varSum
                        End If
                        If varAuxi >= varParametro(da + 1) Then
                            varTope1 = varParametro(da + 1)
                            varTope = varParametro(da)
                            varSum = varTope1 - varTope
                            varSum = varSum * varTasa1(da + 1)
                            varRetencion = varRetencion + varSum
                        End If
                    Next da

                Case Else
                    varRetencion = varAuxi * varTasa

            End Select

            varRetencion = varRetencion - varAcuRetenido

            If varRetencion < 20 Then
                varRetencion = 0
            Else
                If varRetencion > varAcumulaNeto Then
                    varRetencion = 0
                End If
            End If

        End If

        Return formatonumerico(varRetencion)

    End Function

    Public Function CaculoRetencionIngresosBrutos(ByVal varTipoIb As Integer, ByVal varPorceIb As Double, ByVal varAcumulaNeto As Double)

        Dim varRete As Double
        Dim varAcumulaIb As Double

        If varTipoIb = 0 Or varTipoIb = 1 Then
            varRete = varAcumulaNeto * (varPorceIb / 100)
            varAcumulaIb = varAcumulaIb + varRete
        End If

        Return formatonumerico(varAcumulaIb)
    End Function


    Public Function CaculoRetencionIngresosBrutosCaba(ByVal varTipoIbCaba As Integer, ByVal varPorceIbCaba As Double, ByVal varAcumulaNeto As Double)

        Dim varRete As Double
        Dim varAcumulaIb As Double

        varAcumulaIb = 0.0
        varRete = 0.0

        If varTipoIbCaba = 3 Or varTipoIbCaba = 4 Or varPorceIbCaba <> 0 Then
            If varTipoIbCaba <> 2 Then
                If varAcumulaNeto >= 300 Then
                    If varPorceIbCaba <> 0 Then
                        varRete = varAcumulaNeto * (varPorceIbCaba / 100)
                    Else
                        If varTipoIbCaba = 3 Then
                            varRete = varAcumulaNeto * (3 / 100)
                        Else
                            varRete = varAcumulaNeto * (4.5 / 100)
                        End If
                    End If
                End If
                varAcumulaIb = varAcumulaIb + varRete
            End If
        End If

        Return formatonumerico(varAcumulaIb)
    End Function

    ' El parametro opcional es por si se decide utilizar con el evento TypeValidationCompleted (Ej: e.Cancel = _ValidarFecha(txtFecha.Text, e.IsValidInput) )
    ' Retorna FALSE en caso de que no sea una fecha válida.
    Public Function _ValidarFecha(ByVal fecha As String, Optional ByVal valido As Boolean = True) As Boolean
        Dim valida As Boolean = True

        ' Controlamos que tenga digitos.
        If Trim(fecha.Replace("/", "")) <> "" Then

            ' Controlamos que el formato sea valido. (Tanto 03/04/2000 como 3/4/2000, son tomados como formatos validos. En cambio, no lo es 03/04/00.)
            If Not _FormatoValidoFecha(fecha) Then

                valida = False

            Else
                If Not valido Then ' Por si se lo utiliza con el evento TypeValidationCompleted u otra funcion con validacion adicional.
                    valida = False
                End If

                ' Controlamos que el año en caso de ser bisiesto, la fecha no se refiera al 29 de Febrero.
                If Not Date.IsLeapYear(Val(Mid(fecha, 7, 4))) And Val(Mid(fecha, 1, 2)) = 29 And Val(Mid(fecha, 4, 2)) = 2 Then
                    valida = False
                End If
            End If
        End If

        Return valida
    End Function

    Public Function _FormatoValidoFecha(ByVal fecha As String) As Boolean
        Dim _Fecha As String() = fecha.Split("/")
        ' Se normaliza la fecha (Ej: 3/04/2000 => 03/04/2000 ó 3/4/2000 => 03/04/2000) y se controla que tenga los ocho digitos obligatoriamente.
        'Return Trim(_Normalizarfecha(Trim(fecha))).Replace("/", "").Length = 8
        Try
            _Fecha(0) = Val(_Fecha(0)).ToString() ' 03 => 3, 12 => 12
            _Fecha(1) = Val(_Fecha(1)).ToString() ' 04 => 4, 12 => 12
            _Fecha(2) = Val(_Fecha(2)).ToString() ' 2000 => 2000, 0201 => 201

            fecha = Date.ParseExact(fecha, "d/M/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo).ToString("dd/MM/yyyy")

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function _Normalizarfecha(ByVal fecha As String) As String
        Dim xfecha As String = ""
        Dim _temp As String = fecha
        Dim _Fecha As String() = fecha.Split("/")

        Try
            _Fecha(0) = Val(_Fecha(0)).ToString() ' 03 => 3, 12 => 12
            _Fecha(1) = Val(_Fecha(1)).ToString() ' 04 => 4, 12 => 12
            _Fecha(2) = Val(_Fecha(2)).ToString() ' 2000 => 2000, 0201 => 201

            xfecha = String.Join("/", _Fecha) ' 3/4/2000, 12/12/201

            ' En la primera (3/4/2001), se parsearia y devolveria: 03/04/2000. En el segundo caso lanzaria una excepcion ya que la fecha (12/12/201), no es un formato de fecha posible.
            xfecha = Date.ParseExact(fecha, "d/M/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo).ToString("dd/MM/yyyy")
        Catch ex As Exception
            ' En caso de excepcion, se retorna el mismo valor que se introdujo sin cambios.
            xfecha = _temp
        End Try

        Return xfecha
    End Function

End Module