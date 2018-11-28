﻿Imports System.Configuration
Imports System.Data.SqlClient

Module Query

    Public Function GetSingle(ByVal q As String) As DataRow

        Dim tabla As New DataTable

        Dim reader As SqlDataReader = ExecuteQueryRead(q)
        tabla.Load(reader)

        If tabla.Rows.Count > 0 Then Return tabla.Rows(0)

        Return Nothing

    End Function

    Public Function GetAll(ByVal q As String) As DataTable

        Dim tabla As New DataTable

        Dim reader As SqlDataReader = ExecuteQueryRead(q)
        tabla.Load(reader)

        Return tabla

    End Function

    Public Function ExecuteQueryRead(ByVal q As String) As SqlDataReader

        Dim cn As New SqlConnection
        Dim cm As New SqlCommand
        Dim dr As SqlDataReader

        cn.ConnectionString = ConfigurationManager.ConnectionStrings("CS").ToString
        cn.Open()

        cm.Connection = cn
        cm.CommandText = q

        dr = cm.ExecuteReader

        Return dr

    End Function

    Public Sub ExecuteNonQueries(ParamArray q As String())
        Dim trans As SqlTransaction = Nothing
        Try
            Using cn As New SqlConnection
                cn.ConnectionString = ConfigurationManager.ConnectionStrings("CS").ToString
                cn.Open()
                trans = cn.BeginTransaction

                Using cm As New SqlCommand()

                    cm.Connection = cn
                    cm.Transaction = trans

                    For Each _q As String In q
                        cm.CommandText = _q
                        cm.ExecuteNonQuery()
                    Next

                    trans.Commit()
                End Using
            End Using

        Catch ex As Exception
            If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Module
