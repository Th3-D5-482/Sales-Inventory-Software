﻿Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Laptop
    Public executed As Boolean = False
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If (IsFormValid()) Then
            qry = "Insert into Laptops values ('" & TextBox6.Text & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & TextBox5.Text & "')"
            Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(qry))
            If (logincorrect) Then
                MsgBox("Laptop Added Sucessfully", MsgBoxStyle.Information)
                Clr()
            Else
                MsgBox("Record Not Saved", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Function IsFormValid() As Boolean
        If (TextBox6.Text = 20) Then
            MsgBox("ProID is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (ComboBox1.SelectedIndex = -1) Then
            MsgBox("Product Catetory is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
            TextBox5.Clear()
        ElseIf (TextBox3.Text.Trim() = String.Empty) Then
            MsgBox("Product Name is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        ElseIf (TextBox5.Text.Trim() = String.Empty) Then
            MsgBox("Product Quantity is Required", MsgBoxStyle.Critical)
            Clr()
            Return False
        End If
        Return True
    End Function
    Public Sub Clr()
        TextBox6.Text = "20"
        ComboBox1.Text = "Laptops"
        TextBox3.Clear()
        TextBox5.Clear()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If (IsFormValid()) Then
            qry = "Update Laptops set ProID ='" & TextBox6.Text & "',ProCat ='" & ComboBox1.Text & "' ,ProName ='" & TextBox3.Text & "' ,ProQuantity ='" & TextBox5.Text & "'where ProID ='" & Convert.ToInt32(TextBox6.Text) & "'"
            Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
            If (isupdatetrue) Then
                MsgBox("Laptop Updated Sucessfully", MsgBoxStyle.Information)
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
                qry = "Delete from Laptops where ProID ='" & Convert.ToInt32(TextBox6.Text) & "'"
                Dim wantToDelete As Boolean = Convert.ToBoolean(InsertData(qry))
                If (wantToDelete) Then
                    MsgBox("Laptop Deleted Sucessfully", MsgBoxStyle.Information)
                    btnAdd.Enabled = True
                    TextBox6.Enabled = True
                    'MasterShifu()
                    Clr()
                Else
                    MsgBox("Record Not Deleted", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub
    Private Sub MasterShifu()
        If (IsFormValid2()) Then
            qry = "Delete from Buy where ProID ='" & Convert.ToInt32(TextBox6.Text) & "'"
            Dim wantToDelete As Boolean = Convert.ToBoolean(InsertData(qry))
            qry = "Delete from Supplier2 where PID ='" & Convert.ToInt32(TextBox6.Text) & "'"
            Dim BellaCiao As Boolean = Convert.ToBoolean(InsertData(qry))
            qry = "Delete from Sales where ProID ='" & Convert.ToInt32(TextBox6.Text) & "'"
            Dim orange7 As Boolean = Convert.ToBoolean(InsertData(qry))
            qry = "Delete from Company2 where PID ='" & Convert.ToInt32(TextBox6.Text) & "'"
            Dim kong As Boolean = Convert.ToInt32(InsertData(qry))
        End If
    End Sub
    Private Function IsFormValid2() As Boolean
        If (TextBox6.Text.Trim() = String.Empty) Then
            MsgBox("Product ID is Required", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("Select count(*) from Laptops where ProID = @ProID", con)
        cmd.Parameters.AddWithValue("@ProID", TextBox1.Text)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
            Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
            Dim sql As String = "Select ProID,ProCat,ProName,ProQuantity from Laptops where ProID ='" & Convert.ToInt32(TextBox1.Text) & "'"
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
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        btnAdd.Enabled = True
        BindGD()
    End Sub
    Public Sub BindGD()
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
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox6.Enabled = False
        btnAdd.Enabled = False
        i = DataGridView1.CurrentRow.Index
        If (i >= 0) Then
            TextBox6.Text = DataGridView1.Item(0, i).Value
            ComboBox1.Text = DataGridView1.Item(1, i).Value
            TextBox3.Text = DataGridView1.Item(2, i).Value
            TextBox5.Text = DataGridView1.Item(3, i).Value
        End If
    End Sub

    Private Sub Laptop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = "Laptops"
        TextBox6.Text = "20"
        BindGD()
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        TextBox6.Enabled = True
        btnAdd.Enabled = True
        Clr()
        ComboBox1.Items.Add("Laptop")
    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text.Length > 3 Then
            TextBox6.Text = TextBox6.Text.Substring(0, 3)
            TextBox6.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length > 3 Then
            TextBox1.Text = TextBox1.Text.Substring(0, 3)
            TextBox1.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles TextBox6.Leave
        If TextBox6.Text.Length < 3 Then
            MsgBox("Enter 3 Digits", MsgBoxStyle.Information)
            TextBox6.Text = "20"
        Else
            Sparky()
        End If
    End Sub
    Private Function Sparky() As Boolean
        Dim ak As String
        ak = TextBox6.Text
        Dim r1 As String = TextBox6.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(20, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 20 Then
                    Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    con.Open()
                    Dim cmd As New SqlCommand("Select count(*) from Laptops where ProID = @ProID", con)
                    cmd.Parameters.AddWithValue("@ProID", TextBox6.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MsgBox("Product ID already Exist", vbOKOnly + MsgBoxStyle.Information)
                        TextBox6.Text = "20"
                    Else
                        If executed = False Then
                            MsgBox("Prodouct ID Not Found", MsgBoxStyle.Information)
                            Dim Result As DialogResult = MsgBox("Do you want to Purchase this item? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                            If Result = DialogResult.Yes Then
                                executed = True
                                Me.Close()
                                Dim f As New buy()
                                f.TopLevel = False
                                f.Visible = True
                                My.Forms.DashboardForm.Panel3.Controls.Add(f)
                                MsgBox("Please Enter the Purchase Details", MsgBoxStyle.Information)
                                f.TextBox3.Text = ak
                            Else
                                MsgBox("Product ID is Required", MsgBoxStyle.Critical)
                            End If
                        End If
                    End If
                    Return True
                    con.Close()
                Else
                    MsgBox("Invalid Product ID", MsgBoxStyle.Information)
                    TextBox6.Text = "20"
                    Return False
                End If
            End If
        Else
            MsgBox("Product ID is Required", MsgBoxStyle.Critical)
            TextBox6.Text = "20"
        End If
        Return True
    End Function
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Dim s As New DashboardForm()
        My.Forms.DashboardForm.Panel3.Controls.Clear()
        Dim f As New Stock()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Dim r1 As String = TextBox1.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(20, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 20 Then
                Else
                    MsgBox("Invalid Product ID", MsgBoxStyle.Critical)
                    TextBox1.Clear()
                End If
            End If
        Else
            MsgBox("Product Id is Required", MsgBoxStyle.Critical)
            TextBox1.Clear()
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
End Class