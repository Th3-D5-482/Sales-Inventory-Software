﻿Imports System.Data.SqlClient
Public Class LogManager
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
        Dim z As New DashboardForm
        DashboardForm.BringToFront()
        DashboardForm.Visible = True
        z.Show()
        DashboardForm.Panel3.Visible = True
    End Sub
    Public Sub BindGDP()
        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select *from Audit order by ID asc"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Using command As New SqlCommand(sql, connection)
                Using adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable("Audit")
                    adapter.Fill(dt)
                    DataGridView1.DataSource = dt
                    DataGridView1.Refresh()
                End Using
            End Using
        End Using
    End Sub
    Private Sub LogManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindGDP()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Dim s As New DashboardForm()
        My.Forms.DashboardForm.Panel3.Controls.Clear()
        Dim f As New Loading()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub
End Class