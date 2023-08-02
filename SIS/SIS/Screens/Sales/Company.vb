Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Company
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Enabled = False
        btnAdd.Enabled = False
        i = DataGridView1.CurrentRow.Index
        If (i >= 0) Then
            TextBox1.Text = DataGridView1.Item(0, i).Value
            TextBox2.Text = DataGridView1.Item(1, i).Value
            TextBox3.Text = DataGridView1.Item(2, i).Value
            TextBox4.Text = DataGridView1.Item(3, i).Value
            TextBox5.Text = DataGridView1.Item(4, i).Value
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If (IsFormValid()) Then
            qry = "Insert into Company values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
            Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(qry))
            If (logincorrect) Then
                MsgBox("Company Added Sucessfully", MsgBoxStyle.Information)
                Clr()
            Else
                MsgBox("Record Not Saved", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Function IsFormValid() As Boolean
        If (TextBox1.Text = 40) Then
            MsgBox("Company ID is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox2.Text.Trim() = String.Empty) Then
            MsgBox("Company Name is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox3.Text.Trim() = String.Empty) Then
            MsgBox("Company Address is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox4.Text.Trim() = String.Empty) Then
            MsgBox("Company PhoneNo is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox5.Text.Trim() = String.Empty) Then
            MsgBox("Company EmailID is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        End If
        Return True
        If (Sparky()) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub Clr()
        TextBox1.Text = "40"
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Text = Nothing
        TextBox5.Clear()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If (IsFormValid()) Then
            qry = "Update Company set CID ='" & TextBox1.Text & "',CName ='" & TextBox2.Text & "' ,CAddress ='" & TextBox3.Text & "',CPhoneNo ='" & TextBox4.Text & "' ,CEmail ='" & TextBox5.Text & "'where CID ='" & Convert.ToInt32(TextBox1.Text) & "'"
            Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
            If (isupdatetrue) Then
                MsgBox("Company Updated Sucessfully", MsgBoxStyle.Information)
                btnAdd.Enabled = True
                Clr()
            Else
                MsgBox("Record Not Updated", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As Integer = MsgBox("Do you really want to delete the record. ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
        If result = DialogResult.Yes Then
            If (IsFormValid2()) Then
                qry = "Delete from Company where CID ='" & Convert.ToInt32(TextBox1.Text) & "'"
                Dim wantToDelete As Boolean = Convert.ToBoolean(InsertData(qry))
                If (wantToDelete) Then
                    MsgBox("Company Deleted Sucessfully", MsgBoxStyle.Information)
                    btnAdd.Enabled = True
                    TextBox1.Enabled = True
                    Clr()
                Else
                    MsgBox("Record Not Deleted", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub
    Private Function IsFormValid2() As Boolean
        If (TextBox1.Text.Trim() = String.Empty) Then
            MsgBox("Comapany ID is Required", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("Select count(*) from Company where CID = @CID", con)
        cmd.Parameters.AddWithValue("@CID", TextBox9.Text)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
            Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
            Dim sql As String = "Select CID,CName,CAddress,CPhoneNo,CEmail from Company where CID ='" & Convert.ToInt32(TextBox9.Text) & "'"
            Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                connection.Open()
                Using command As New SqlCommand(sql, connection)
                    Using adapter As New SqlDataAdapter(command)
                        Dim dt As New DataTable("Company")
                        adapter.Fill(dt)
                        DataGridView1.DataSource = dt
                        DataGridView1.Refresh()
                    End Using
                End Using
            End Using
        Else
            MsgBox("ID Not Found", MsgBoxStyle.Information)
        End If
        con.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        btnAdd.Enabled = True
        BindGD()
    End Sub
    Public Sub BindGD()
        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select CID,CName,CAddress,CPhoneNo,CEmail from Company order by ID asc"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Using command As New SqlCommand(sql, connection)
                Using adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable("Company")
                    adapter.Fill(dt)
                    DataGridView1.DataSource = dt
                    DataGridView1.Refresh()
                End Using
            End Using
        End Using
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        TextBox1.Enabled = True
        btnAdd.Enabled = True
        Clr()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length > 3 Then
            TextBox1.Text = TextBox1.Text.Substring(0, 3)
            TextBox1.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Text.Length > 10 Then
            TextBox4.Text = TextBox4.Text.Substring(0, 10)
            TextBox4.SelectionStart = 10
            MsgBox("Only 10 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text.Length > 3 Then
            TextBox9.Text = TextBox9.Text.Substring(0, 3)
            TextBox9.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        If Not IsValidEmail(TextBox5.Text) Then
            MsgBox("Invalid Email ID", MsgBoxStyle.Information)
        End If
    End Sub
    Private Function IsValidEmail(email As String) As Boolean
        Dim emailRegex As String = "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        Dim isValid As Boolean = Regex.IsMatch(email, emailRegex)
        Return isValid
    End Function

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text.Length < 3 Then
            MsgBox("Enter 3 Digits", MsgBoxStyle.Information)
            TextBox1.Text = "40"
        Else
            Sparky()
        End If
    End Sub
    Private Function Sparky() As Boolean
        Dim r1 As String = TextBox1.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(40, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 40 Then
                    Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    con.Open()
                    Dim cmd As New SqlCommand("Select count(*) from Company where CID = @CID", con)
                    cmd.Parameters.AddWithValue("@CID", TextBox1.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MsgBox("ID already Exist", vbOKOnly + MsgBoxStyle.Information)
                        TextBox1.Text = "40"
                    End If
                    Return True
                    con.Close()
                Else
                    MsgBox("Invalid Company ID", MsgBoxStyle.Information)
                    TextBox1.Text = "40"
                    Return False
                End If
            End If
        Else
            MsgBox("Company ID is Required", MsgBoxStyle.Critical)
            TextBox1.Text = "40"
        End If
        Return True
    End Function

    Private Sub Company_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "40"
        BindGD()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Dim s As New DashboardForm()
        My.Forms.DashboardForm.Panel3.Controls.Clear()
        Dim f As New Sales()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub
    Private Sub TextBox9_Leave(sender As Object, e As EventArgs) Handles TextBox9.Leave
        Dim r1 As String = TextBox9.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(40, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 40 Then
                Else
                    MsgBox("Invalid Comapny ID", MsgBoxStyle.Information)
                    TextBox9.Clear()
                End If
            End If
        Else
            MsgBox("Company ID is Required", MsgBoxStyle.Critical)
            TextBox9.Clear()
        End If
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Dim s As New DashboardForm()
        My.Forms.DashboardForm.Panel3.Controls.Clear()
        Dim f As New Loading()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        If TextBox4.Text.Length < 10 Then
            MsgBox("Enter 10 Digits", MsgBoxStyle.Information)
            TextBox4.Text = Nothing
        End If
    End Sub
End Class