Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class DashboardForm
    Public q As String
    Dim currentTime As DateTime = DateTime.Now
    Dim timeString As String = currentTime.ToString
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel3.Controls.Clear()
        Dim f As New Stock()
        f.TopLevel = False
        f.Visible = True
        Panel3.Controls.Add(f)
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim data As String = " "
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim query As String = "Select UserType from Audit order by ID asc"
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Using command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    data = reader("UserType").ToString()
                End While
            End Using
        End Using
        If (data = "Admin") Then
            Panel3.Controls.Clear()
            Dim c As New Registration()
            c.TopLevel = False
            c.Visible = True
            Panel3.Controls.Add(c)
        Else
            MsgBox("Only Admin Can Access the Employee Registration", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = My.Forms.LoginForm.LoginUser
        Panel3.Controls.Clear()
        Dim f As New Loading()
        f.TopLevel = False
        f.Visible = True
        Panel3.Controls.Add(f)
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        EditUser()
    End Sub
    Public Sub EditUser()
        Dim r As New LoginForm
        q = "Insert into Audit values ('" & r.LoginUser & "','" & r.LoginPass & "','" & r.UserType & "','OUT','" & DateTime.Now & "','" & timeString & "')"
        Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(q))
        If (logincorrect) Then
            MsgBox("Log Out Successful", MsgBoxStyle.Information)
            Me.Close()
            LoginForm.Show()
        Else
            MsgBox("Log Out Failed", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim data As String = " "
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim query As String = "Select UserType from Audit order by ID asc"
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Using command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    data = reader("UserType").ToString()
                End While
            End Using
        End Using
        If (data = "Admin") Then
            Panel3.Controls.Clear()
            Dim c As New LogManager()
            c.TopLevel = False
            c.Visible = True
            Panel3.Controls.Add(c)
        Else
            MsgBox("Only Admin Can Access the Log Manager", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel3.Controls.Clear()
        Dim c As New P_and_S
        c.TopLevel = False
        c.Visible = True
        Panel3.Controls.Add(c)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel3.Controls.Clear()
        Dim c As New Payment()
        c.TopLevel = False
        c.Visible = True
        Panel3.Controls.Add(c)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel3.Controls.Clear()
        Dim c As New Sales()
        c.TopLevel = False
        c.Visible = True
        Panel3.Controls.Add(c)
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
        EditUser()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim data As String = " "
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim query As String = "Select UserType from Audit order by ID asc"
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Using command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    data = reader("UserType").ToString()
                End While
            End Using
        End Using
        If (data = "Admin") Then
            Panel3.Controls.Clear()
            Dim c As New Report5()
            c.TopLevel = False
            c.Visible = True
            Panel3.Controls.Add(c)
        Else
            MsgBox("Only Admin Can Access the Report", MsgBoxStyle.Information)
        End If
    End Sub
End Class