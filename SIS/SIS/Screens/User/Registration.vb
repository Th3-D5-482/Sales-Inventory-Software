Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Registration
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (IsFormValid() And Electro() And IsValidEmail(TextBox3.Text) And Sparky()) Then
            qry = "Insert into Employee values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox5.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & ComboBox1.Text & "')"
            Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(qry))
            If (logincorrect) Then
                MsgBox("Account Created Sucessfully", MsgBoxStyle.Information)
                Clr()
            Else
                MsgBox("Account Not Created", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Function Electro() As Boolean
        Dim a As String
        Dim b As String
        a = TextBox6.Text
        b = TextBox7.Text
        If (a = b) Then
            Return True
        Else
            MsgBox("Retyped Password Is InCorrect", MsgBoxStyle.Information)
            Return False
        End If
    End Function
    Private Sub Clr()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox5.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        ComboBox1.Text = Nothing
    End Sub
    Private Function IsFormValid() As Boolean
        If (TextBox1.Text.Trim() = String.Empty) Then
            MsgBox("Employee ID is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox2.Text.Trim() = String.Empty) Then
            MsgBox("Employee Name is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox5.Text.Trim() = String.Empty) Then
            MsgBox("Employee Phone Number is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox3.Text.Trim() = String.Empty) Then
            MsgBox("Employee Email ID is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox4.Text.Trim = String.Empty) Then
            MsgBox("User Name is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox6.Text.Trim() = String.Empty) Then
            MsgBox("Password is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox7.Text.Trim() = String.Empty) Then
            MsgBox("ReType Password is Required", MsgBoxStyle.Critical)
            Clr()
        ElseIf (ComboBox1.SelectedIndex = -1) Then
            MsgBox("UserType is Required", MsgBoxStyle.Critical)
            Clr()
        End If
        Return True
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Clr()
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text.Length > 10 Then
            TextBox5.Text = TextBox5.Text.Substring(0, 10)
            TextBox5.SelectionStart = 10
            MsgBox("Only 10 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        If Not IsValidEmail(TextBox3.Text) Then
            MsgBox("Invalid Email Address", MsgBoxStyle.Information)
        End If
    End Sub
    Private Function IsValidEmail(email As String) As Boolean
        Dim emailRegex As String = "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        Dim isValid As Boolean = Regex.IsMatch(email, emailRegex)
        Return isValid
    End Function
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length > 3 Then
            TextBox1.Text = TextBox1.Text.Substring(0, 3)
            TextBox1.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub TextBox7_Leave(sender As Object, e As EventArgs) Handles TextBox7.Leave
        Electro()
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Sparky()
    End Sub
    Private Function Sparky() As Boolean
        Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("Select count(*) from Employee where EID = @EID", con)
        cmd.Parameters.AddWithValue("@EID", TextBox1.Text)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
            MsgBox("ID already Exist", vbOKOnly + MsgBoxStyle.Information)
            TextBox1.Clear()
        End If
        Return True
        con.Close()
    End Function
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Dim s As New DashboardForm()
        My.Forms.DashboardForm.Panel3.Controls.Clear()
        Dim f As New Loading()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Dim s As New DashboardForm()
        My.Forms.DashboardForm.Panel3.Controls.Clear()
        Dim f As New ViewE()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        If TextBox5.Text.Length < 10 Then
            MsgBox("Enter 10 Digits", MsgBoxStyle.Information)
            TextBox5.Text = Nothing
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class