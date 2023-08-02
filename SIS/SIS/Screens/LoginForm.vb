Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class LoginForm
    Public LoginUser As String
    Public LoginPass As String
    Public UserType As String
    Public q As String
    Dim currentTime As DateTime = DateTime.Now
    Dim timeString As String = currentTime.ToString("hh:mm:ss tt")
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If (IsFormValid()) Then
            Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            con.Open()
            Dim cmd As New SqlCommand("Select count(*) from Employee where UserName = @UserName and Password = @Password and UserType = @UserType", con)
            cmd.Parameters.AddWithValue("@UserName", TextBox1.Text)
            cmd.Parameters.AddWithValue("@Password", TextBox2.Text)
            cmd.Parameters.AddWithValue("@UserType", ComboBox1.Text)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            If count > 0 Then
                LoginUser = TextBox1.Text
                LoginPass = TextBox2.Text
                UserType = ComboBox1.Text
                MadTitan()
                EditUser()
                DashboardForm.Show()
                Me.Close()
            Else
                MsgBox("Invalid Login", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Sub MadTitan()
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        connection.Open()
        Dim query As String = "Alter DataBase Scoped Configuration Set Identity_Cache = off"
        Dim command As New SqlCommand(query, connection)
        connection.Close()
    End Sub
    Private Sub EditUser()
        If (IsFormValid()) Then
            q = "Insert into Audit values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','IN','" & Date.Now & "','" & timeString & "')"
            Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(q))
            If (logincorrect) Then
                MsgBox("Login Successful", MsgBoxStyle.Information)
            Else
                MsgBox("Login Failed", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        btnLogin.Enabled = True
    End Sub

    Private Function IsFormValid() As Boolean
        If (TextBox1.Text.Trim() = String.Empty) Then
            MsgBox("User Name is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox2.Text.Trim() = String.Empty) Then
            MsgBox("Password is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (ComboBox1.SelectedIndex = -1) Then
            MsgBox("User Type is Required", MsgBoxStyle.Critical)
        End If
        Return True
    End Function
    Private Sub Clr()
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
    Private Sub loginform_load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "Coder"
        TextBox2.Text = "123"
        ComboBox1.Text = "admin"
    End Sub
End Class