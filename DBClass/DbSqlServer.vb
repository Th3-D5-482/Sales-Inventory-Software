﻿Imports System.Data
Imports System.Data.SqlClient
Module DbSqlServer
    Public con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public dt As DataTable
    Public qry As String
    Public i As Integer
    Public Function InsertData(ByVal qr As String) As Integer
        cmd = New SqlCommand(qr, con)
        con.Open()
        i = cmd.ExecuteNonQuery()
        con.Close()
        Return i
    End Function
End Module
