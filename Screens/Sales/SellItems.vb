﻿Imports System.CodeDom.Compiler
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class SellItems
    Public executed As Boolean = False
    Public executed1 As Boolean = False
    Dim currentTime As DateTime = DateTime.Now
    Dim timeString As String = currentTime.ToString("hh:mm:ss tt")
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
        If TextBox2.Text.Length > 3 Then
            TextBox2.Text = TextBox2.Text.Substring(0, 3)
            TextBox2.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub
    Private Function Thanos2() As Boolean
        Dim ak As String
        ak = TextBox2.Text
        Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("Select count(*) from Phones where ProID = @ProID", con)
        cmd.Parameters.AddWithValue("@ProID", TextBox2.Text)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
        Else
            If executed = False Then
                MsgBox("Product ID Not Found", MsgBoxStyle.Information)
                Dim Result As DialogResult = MsgBox("Do you want to Purchase this Item ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If Result = DialogResult.Yes Then
                    executed = True
                    executed1 = True
                    Me.Close()
                    Dim f As New buy()
                    f.TopLevel = False
                    f.Visible = True
                    My.Forms.DashboardForm.Panel3.Controls.Add(f)
                    MsgBox("Please Enter the Purchase Details", MsgBoxStyle.Information)
                    f.TextBox3.Text = ak
                Else
                    MsgBox("Invalid Product ID", MsgBoxStyle.Critical)
                    TextBox2.Clear()
                End If
            End If
            If executed1 = False Then
                Dim Result1 As DialogResult = MsgBox("Do you want to Add this Item to Phones?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If Result1 = DialogResult.Yes Then
                    executed1 = True
                    Me.Close()
                    Dim f As New Phones()
                    f.TopLevel = False
                    f.Visible = True
                    My.Forms.DashboardForm.Panel3.Controls.Add(f)
                    MsgBox("Please Enter the Phones Details", MsgBoxStyle.Information)
                    f.TextBox6.Text = ak
                Else
                    MsgBox("Invalid Product ID", MsgBoxStyle.Critical)
                    TextBox2.Clear()
                End If
            End If
        End If
        Return True
        con.Close()
    End Function
    Private Function Thanos3() As Boolean
        Dim ak As String
        ak = TextBox2.Text
        Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("Select count(*) from Laptops where ProID = @ProID", con)
        cmd.Parameters.AddWithValue("@ProID", TextBox2.Text)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
        Else
            If executed = False Then
                MsgBox("Product ID Not Found", MsgBoxStyle.Information)
                Dim result As DialogResult = MsgBox("Do you want to Purchase this Item ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If result = DialogResult.Yes Then
                    executed = True
                    executed1 = True
                    Me.Close()
                    Dim f As New buy()
                    f.TopLevel = False
                    f.Visible = True
                    My.Forms.DashboardForm.Panel3.Controls.Add(f)
                    MsgBox("Please Enter the Purchase Details", MsgBoxStyle.Information)
                    f.TextBox3.Text = ak
                Else
                    MsgBox("Invalid Product ID", MsgBoxStyle.Critical)
                    TextBox2.Clear()
                End If
                executed = True
            End If
            If executed1 = True Then
                Dim Result1 As DialogResult = MsgBox("Do you want to Add this Item to Laptops?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If Result1 = DialogResult.Yes Then
                    executed1 = True
                    Me.Close()
                    Dim f As New Laptop()
                    f.TopLevel = False
                    f.Visible = True
                    My.Forms.DashboardForm.Panel3.Controls.Add(f)
                    MsgBox("Please Enter the Laptops Details", MsgBoxStyle.Information)
                    executed1 = True
                    f.TextBox6.Text = ak
                Else
                    MsgBox("Invalid Product ID", MsgBoxStyle.Critical)
                    TextBox2.Clear()
                End If
            End If
        End If
        Return True
        con.Close()
    End Function
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length > 3 Then
            TextBox1.Text = TextBox1.Text.Substring(0, 3)
            TextBox1.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text.Length < 3 Then
            MsgBox("Enter 3 Digits", MsgBoxStyle.Information)
            TextBox1.Text = "40"
        Else
            Sparky()
        End If
    End Sub
    Private Function Sparky() As Boolean
        Dim ak As String
        ak = TextBox1.Text
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
                    Else
                        If executed = False Then
                            MsgBox("Company ID Not Found", MsgBoxStyle.Information)
                            Dim Result As DialogResult = MsgBox("Do you want to add this Item ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                            If Result = DialogResult.Yes Then
                                executed = True
                                Me.Close()
                                Dim f As New Company()
                                f.TopLevel = False
                                f.Visible = True
                                My.Forms.DashboardForm.Panel3.Controls.Add(f)
                                MsgBox("Please Enter the Company Details", MsgBoxStyle.Information)
                                f.TextBox1.Text = ak
                            Else
                                MsgBox("Invalid Comapny ID", MsgBoxStyle.Critical)
                                TextBox1.Text = "40"
                            End If
                        End If
                        Return False
                    End If
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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Dim s As New DashboardForm()
        My.Forms.DashboardForm.Panel3.Controls.Clear()
        Dim f As New Sales()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub
    Private Sub SellItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "40"
        TextBox12.Text = "60"
        TextBox13.Text = "80"
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select EID from Employee where UserName ='" & My.Forms.DashboardForm.Label2.Text & "'"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Dim command As New SqlCommand(sql, connection)
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read()
                TextBox6.Text = reader("EID").ToString()
            End While
        End Using
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If (ComboBox1.SelectedItem = "Phones") Then
            Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
            Dim sql As String = "Select ProID,ProCat,ProName,ProQuantity from Phones order by ID asc"
            Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                connection.Open()
                Using command As New SqlCommand(sql, connection)
                    Using adapter As New SqlDataAdapter(command)
                        Dim dt As New DataTable("Phones")
                        adapter.Fill(dt)
                        DataGridView1.DataSource = dt
                        DataGridView1.Refresh()
                    End Using
                End Using
            End Using
        ElseIf (ComboBox1.SelectedItem = "Laptops") Then
            Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
            Dim sql As String = "Select ProID,ProCat,ProName,ProQuantity from Laptops order by ID asc"
            Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                connection.Open()
                Using command As New SqlCommand(sql, connection)
                    Using adapter As New SqlDataAdapter(command)
                        Dim dt As New DataTable("Laptops")
                        adapter.Fill(dt)
                        DataGridView1.DataSource = dt
                        DataGridView1.Refresh()
                    End Using
                End Using
            End Using
        End If
    End Sub
    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox9_Leave(sender As Object, e As EventArgs) Handles TextBox9.Leave
        Try
            If String.IsNullOrWhiteSpace(TextBox9.Text) Then
                Throw New Exception("Received Cash is Required")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Dim r1 As String = TextBox9.Text
        If r1.Length >= 0 Then
            Dim a, b As String
            Dim c As Integer
            a = Val(TextBox10.Text)
            Dim num As Integer = Integer.Parse(a)
            b = Val(TextBox9.Text)
            Dim num1 As Integer = Integer.Parse(b)
            c = num1 - num
            TextBox8.Text = c
            If (num1 < num) Then
                MsgBox("The Received Cash is Less than the Total Price", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Received Cash is Required", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub ComboBox2_Leave(sender As Object, e As EventArgs) Handles ComboBox2.Leave
        Dim aq, bq As String
        Dim cq As Integer
        If (ComboBox2.SelectedItem = "5%") Then
            aq = TextBox4.Text
            bq = TextBox7.Text
            cq = (aq * bq) * 5 / 100
            TextBox11.Text = cq
            TextBox10.Text = (aq * bq) - cq
        ElseIf (ComboBox2.SelectedItem = "10%") Then
            aq = (TextBox4.Text)
            bq = TextBox7.Text
            cq = (aq * bq) * 10 / 100
            TextBox11.Text = cq
            TextBox10.Text = (aq * bq) - cq
        ElseIf (ComboBox2.SelectedItem = "15%") Then
            aq = TextBox4.Text
            bq = TextBox7.Text
            cq = (aq * bq) * 15 / 100
            TextBox11.Text = cq
            TextBox10.Text = (aq * bq) - cq
        ElseIf (ComboBox2.SelectedItem = "20%") Then
            aq = TextBox4.Text
            bq = TextBox7.Text
            cq = (aq * bq) * 20 / 100
            TextBox11.Text = cq
            TextBox10.Text = (aq * bq) - cq
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If (IsFormValid()) Then
            qry = "Insert into Sales values ('" & TextBox13.Text & "','" & TextBox6.Text & "','" & TextBox1.Text & "','" & TextBox12.Text & "','" & ComboBox3.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox7.Text & "','" & ComboBox2.Text & "','" & TextBox11.Text & "','" & TextBox10.Text & "','" & TextBox9.Text & "','" & TextBox8.Text & "','" & Date.Now & "','" & timeString & "')"
            Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(qry))
            If (logincorrect) Then
                MsgBox("Product Sold Sucessfully", MsgBoxStyle.Information)
                Hulk()
                WakandaForever()
                Clr()
            Else
                MsgBox("Record Not Saved", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Sub WakandaForever()
        If (IsFormValid()) Then
            qry = "Insert into Company2 values ('" & TextBox12.Text & "','" & TextBox13.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox3.Text & "','" & TextBox10.Text & "','" & Date.Now & "','" & timeString & "')"
            Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(qry))
        End If
        Me.Close()
        Dim f As New Company2()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
        MsgBox("Payment Added Sucessfully", MsgBoxStyle.Information)
    End Sub
    Private Sub Hulk()
        Dim r1 As String = TextBox2.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(20, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 10 Then
                    Dim a As String
                    a = Integer.Parse(TextBox5.Text) - TextBox7.Text
                    qry = "Update Phones set ProQuantity ='" & a & "'where ProID ='" & Convert.ToInt32(TextBox2.Text) & "'"
                    Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
                ElseIf number = 20 Then
                    Dim a As String
                    a = Integer.Parse(TextBox5.Text) - TextBox7.Text
                    qry = "Update Laptops set ProQuantity ='" & a & "'where ProID ='" & Convert.ToInt32(TextBox2.Text) & "'"
                    Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
                Else
                    MsgBox("Invalid Product ID", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Product ID is Required", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Function IsFormValid2() As Boolean
        If (TextBox2.Text.Trim() = String.Empty) Then
            MsgBox("Product ID is Required", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function
    Private Function IsFormValid() As Boolean
        If (ComboBox1.SelectedIndex = -1) Then
            MsgBox("Product Category is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox2.Text.Trim() = String.Empty) Then
            MsgBox("Product ID is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox1.Text = 40) Then
            MsgBox("Company ID is Required", MsgBoxStyle.Critical)
            Return False
        ElseIf (TextBox7.Text.Trim() = String.Empty) Then
            MsgBox("Units is Required", MsgBoxStyle.Critical)
            Return False
        ElseIf (TextBox9.Text.Trim() = String.Empty) Then
            MsgBox("Received Cash is Required", MsgBoxStyle.Critical)
            Return False
        ElseIf (ComboBox2.SelectedIndex = -1) Then
            MsgBox("Discount Percentage is Required", MsgBoxStyle.Critical)
            Return False
        ElseIf (TextBox12.Text = 60) Then
            MsgBox("Payment ID is Required", MsgBoxStyle.Critical)
            Return False
        ElseIf (ComboBox3.SelectedIndex = -1) Then
            MsgBox("Payment Type is Required", MsgBoxStyle.Critical)
            Return False
        ElseIf (TextBox13.Text = 80) Then
            MsgBox("Sales ID is Required", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function
    Public Sub Clr()
        TextBox13.Text = "80"
        ComboBox1.Text = Nothing
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox1.Text = "40"
        TextBox7.Clear()
        TextBox10.Clear()
        TextBox9.Clear()
        TextBox8.Clear()
        ComboBox2.Text = Nothing
        TextBox11.Clear()
        TextBox12.Text = "60"
        ComboBox3.Text = Nothing
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (TextBox2.Text.Substring(0, 2) = "10") Then
            Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            con.Open()
            Dim cmd As New SqlCommand("Select count(*) from Phones where ProID = @ProID", con)
            cmd.Parameters.AddWithValue("@ProID", TextBox2.Text)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            If count > 0 Then
                Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
                Dim sql As String = "Select ProID,ProCat,ProName,ProQuantity from Phones where ProID ='" & Convert.ToInt32(TextBox2.Text) & "'"
                Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    connection.Open()
                    Using command As New SqlCommand(sql, connection)
                        Using adapter As New SqlDataAdapter(command)
                            Dim dt As New DataTable("Phones")
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
        ElseIf (TextBox2.Text.Substring(0, 2) = 20) Then
            Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            con.Open()
            Dim cmd As New SqlCommand("Select count(*) from Laptops where ProID = @ProID", con)
            cmd.Parameters.AddWithValue("@ProID", TextBox2.Text)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            If count > 0 Then
                Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
                Dim sql As String = "Select ProID,ProCat,ProName,ProQuantity from Laptops where ProID ='" & Convert.ToInt32(TextBox2.Text) & "'"
                Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    connection.Open()
                    Using command As New SqlCommand(sql, connection)
                        Using adapter As New SqlDataAdapter(command)
                            Dim dt As New DataTable("Laptops")
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
        Else
            MsgBox("Invalid Product ID", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub TextBox7_Leave(sender As Object, e As EventArgs) Handles TextBox7.Leave
        Try
            If String.IsNullOrWhiteSpace(TextBox7.Text) Then
                Throw New Exception("Units is Required")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Light()
    End Sub
    Private Sub TextBox2_Leave_1(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If TextBox2.Text.Length < 3 Then
            MsgBox("Enter 3 Digits", MsgBoxStyle.Information)
            TextBox2.Text = Nothing
        Else
            Dim r1 As String = TextBox2.Text
            If r1.Length >= 2 Then
                Dim firstTwoDigits As String = r1.Substring(0, 2)
                If Integer.TryParse(10, Nothing) Then
                    Dim number As Integer = Integer.Parse(firstTwoDigits)
                    If number = 10 Then
                        Thanos2()
                    ElseIf number = 20 Then
                        Thanos3()
                    Else
                        MsgBox("Invaid Product ID", MsgBoxStyle.Information)
                        TextBox2.Clear()
                    End If
                End If
            Else
                If (executed = False And executed1 = False) Then
                    MsgBox("Product ID is Required", MsgBoxStyle.Critical)
                    TextBox2.Clear()
                End If
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        btnAdd.Enabled = True
        TextBox13.Enabled = True
        TextBox12.Enabled = True
        Clr()
    End Sub
    Private Function Light() As Boolean
        Dim edd, edd2 As String
        edd = Val(TextBox5.Text)
        Dim num2 As Integer = Integer.Parse(edd)
        edd2 = Val(TextBox7.Text)
        Dim num3 As Integer = Integer.Parse(edd2)
        If (num2 = 0) Then
            MsgBox("Product Cannot be Sold", MsgBoxStyle.Information)
            TextBox7.Clear()
        ElseIf (num2 < num3) Then
            MsgBox("Units are Greater than the Number of Quantity Available", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Dim s As New DashboardForm()
        My.Forms.DashboardForm.Panel3.Controls.Clear()
        Dim f As New Loading()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub
    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged
        If TextBox12.Text.Length > 3 Then
            TextBox12.Text = TextBox12.Text.Substring(0, 3)
            TextBox12.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub TextBox12_Leave(sender As Object, e As EventArgs) Handles TextBox12.Leave
        If TextBox12.Text.Length < 3 Then
            MsgBox("Enter 3 Digits", MsgBoxStyle.Information)
            TextBox12.Text = "60"
        Else
            Batman()
        End If
    End Sub
    Private Function Batman() As Boolean
        Dim r1 As String = TextBox12.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(60, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 60 Then
                    Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    con.Open()
                    Dim cmd As New SqlCommand("Select count(*) from Company2 where PayID = @PayID", con)
                    cmd.Parameters.AddWithValue("@PayID", TextBox12.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MsgBox("Payment ID already Exist", vbOKOnly + MsgBoxStyle.Information)
                        TextBox12.Text = "60"
                    End If
                    Return True
                    con.Close()
                Else
                    MsgBox("Invalid Payment ID", MsgBoxStyle.Information)
                    TextBox12.Text = "60"
                    Return False
                End If
            End If
        Else
            MsgBox("Payment ID is Required", MsgBoxStyle.Critical)
            TextBox12.Text = "60"
        End If
        Return True
    End Function
    Private Sub TextBox2_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text.Length > 3 Then
            TextBox2.Text = TextBox2.Text.Substring(0, 3)
            TextBox2.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Dim f As New Sales1()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (IsFormValid()) Then
            qry = "Update Sales set SalID ='" & TextBox13.Text & "',EID ='" & TextBox6.Text & "',CID ='" & TextBox1.Text & "',PayID ='" & TextBox12.Text & "',PayType ='" & ComboBox3.Text & "',ProID ='" & TextBox2.Text & "',ProCat ='" & ComboBox1.Text & "',ProName ='" & TextBox3.Text & "',ProPrice ='" & TextBox4.Text & "',ProQuantity ='" & TextBox5.Text & "',Units ='" & TextBox7.Text & "',DisPer ='" & ComboBox2.Text & "',DisAmt ='" & TextBox11.Text & "',TPrice ='" & TextBox10.Text & "',RCash ='" & TextBox9.Text & "',Change ='" & TextBox8.Text & "' where SalID ='" & Convert.ToInt32(TextBox13.Text) & "'"
            Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
            If (isupdatetrue) Then
                MsgBox("Sell Items Updated Sucessfully", MsgBoxStyle.Information)
                btnAdd.Enabled = True
                TextBox13.Enabled = True
                TextBox12.Enabled = True
                Hulk()
                Thinker()
                Clr()
            Else
                MsgBox("Record Not Updated", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Sub Thinker()
        If (IsFormValid()) Then
            qry = "Update Company2 set PayID='" & TextBox12.Text & "',SalID ='" & TextBox13.Text & "',CID ='" & TextBox1.Text & "',PID ='" & TextBox2.Text & "',PayType ='" & ComboBox3.Text & "',Amt ='" & TextBox10.Text & "' where PayID ='" & Convert.ToInt32(TextBox12.Text) & "'"
            Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
        End If
    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox13.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        If TextBox13.Text.Length > 3 Then
            TextBox13.Text = TextBox13.Text.Substring(0, 3)
            TextBox13.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub TextBox13_Leave(sender As Object, e As EventArgs) Handles TextBox13.Leave
        If TextBox13.Text.Length < 3 Then
            MsgBox("Enter 3 Digits", MsgBoxStyle.Information)
            TextBox13.Text = "80"
        Else
            Voldemort()
        End If
    End Sub
    Private Function Voldemort() As Boolean
        Dim r1 As String = TextBox13.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(80, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 80 Then
                    Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    con.Open()
                    Dim cmd As New SqlCommand("Select count(*) from Sales where SalID = @SalID", con)
                    cmd.Parameters.AddWithValue("@SalID", TextBox13.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MsgBox("Sales ID already Exist", vbOKOnly + MsgBoxStyle.Information)
                        TextBox13.Text = "80"
                    End If
                    Return True
                    con.Close()
                Else
                    MsgBox("Invalid Sales ID", MsgBoxStyle.Information)
                    TextBox13.Text = "80"
                    Return False
                End If
            End If
        Else
            MsgBox("Sales ID is Required", MsgBoxStyle.Critical)
            TextBox13.Text = "80"
        End If
        Return True
    End Function
    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        Try
            If String.IsNullOrWhiteSpace(TextBox4.Text) Then
                Throw New Exception("Product Price is Required")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Dim bca As String = Val(TextBox4.Text)
        Dim blue4 As Integer = Integer.Parse(bca)
        Dim data As String = " "
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim query As String = "Select TPrice from Buy where ProID ='" & TextBox2.Text & "'"
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Using command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    data = reader("TPrice").ToString()
                End While
            End Using
        End Using
        'Dim data1 As String = Val(data)
        'Dim blue5 As Integer = Integer.Parse(data1)
        'If (blue5 < blue4) Then
        'Else
        '    MsgBox("Selling Price is Less than Purchasing Price", MsgBoxStyle.Information)
        '    TextBox4.Clear()
        'End If
    End Sub
    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub DataGridView1_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        i = DataGridView1.CurrentRow.Index
        If (i >= 0) Then
            TextBox2.Text = DataGridView1.Item(0, i).Value
            ComboBox1.Text = DataGridView1.Item(1, i).Value
            TextBox3.Text = DataGridView1.Item(2, i).Value
            TextBox5.Text = DataGridView1.Item(3, i).Value
        End If
    End Sub
End Class