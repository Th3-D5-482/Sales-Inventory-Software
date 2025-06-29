﻿Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Sales1
    Public a1, b1, c1, d1, e1, f1, g1, h1, i1, j1, k1, l1, m1, n1, o1, p1 As String
    Dim a2b, b2a As Integer
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Dim f As New SellItems()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub

    Private Sub Sales1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindGDP()
    End Sub
    Public Sub BindGDP()
        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select SalID,EID,CID,PayID,PayType,ProID,ProCat,ProName,ProPrice,ProQuantity,Units,DisPer,DisAmt,TPrice,RCash,Change,SalDate,SalTime from Sales order by ID asc"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Using command As New SqlCommand(sql, connection)
                Using adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable("Sales")
                    adapter.Fill(dt)
                    DataGridView1.DataSource = dt
                    DataGridView1.Refresh()
                End Using
            End Using
        End Using
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Dim f As New Loading()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        My.Forms.SellItems.TextBox13.Enabled = False
        My.Forms.SellItems.btnAdd.Enabled = False
        i = DataGridView1.CurrentRow.Index
        If (i >= 0) Then
            a1 = DataGridView1.Item(0, i).Value
            b1 = DataGridView1.Item(1, i).Value
            c1 = DataGridView1.Item(2, i).Value
            d1 = DataGridView1.Item(3, i).Value
            e1 = DataGridView1.Item(4, i).Value
            f1 = DataGridView1.Item(5, i).Value
            g1 = DataGridView1.Item(6, i).Value
            h1 = DataGridView1.Item(7, i).Value
            i1 = DataGridView1.Item(8, i).Value
            j1 = DataGridView1.Item(9, i).Value
            k1 = DataGridView1.Item(10, i).Value
            l1 = DataGridView1.Item(11, i).Value
            m1 = DataGridView1.Item(12, i).Value
            n1 = DataGridView1.Item(13, i).Value
            o1 = DataGridView1.Item(14, i).Value
            p1 = DataGridView1.Item(15, i).Value
            a2b = DataGridView1.Item(9, i).Value
            b2a = DataGridView1.Item(10, i).Value
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Me.Close()
        Dim f As New SellItems()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
        MsgBox("Please Enter the Update Details", MsgBoxStyle.Information)
        f.TextBox13.Text = a1
        f.TextBox6.Text = b1
        f.TextBox1.Text = c1
        f.TextBox12.Text = d1
        f.ComboBox3.Text = e1
        f.TextBox2.Text = f1
        f.ComboBox1.Text = g1
        f.TextBox3.Text = h1
        f.TextBox4.Text = i1
        f.TextBox5.Text = j1
        f.TextBox7.Text = k1
        f.ComboBox2.Text = l1
        f.TextBox11.Text = m1
        f.TextBox10.Text = n1
        f.TextBox9.Text = o1
        f.TextBox8.Text = p1
        f.TextBox13.Enabled = False
        f.btnAdd.Enabled = False
        f.TextBox12.Enabled = False
    End Sub
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
        Dim r1 As String = TextBox1.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(80, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 80 Then
                    Thanos2()
                Else
                    MsgBox("Invalid Sales ID", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Sales ID is Required", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Function Thanos2() As Boolean
        Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("Select count(*) from Sales where SalID = @SalID", con)
        cmd.Parameters.AddWithValue("@SalID", TextBox1.Text)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
            Return True
        Else
            MsgBox("ID Not Found", MsgBoxStyle.Information)
            Return False
        End If
        Return True
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim r1 As String = TextBox1.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(80, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 80 Then
                    Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    con.Open()
                    Dim cmd As New SqlCommand("Select count(*) from Sales where SalID = @SalID", con)
                    cmd.Parameters.AddWithValue("@SalID", TextBox1.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
                        Dim sql As String = "Select SalID,EID,CID,PayID, PayType,ProID,ProCat,ProName,ProPrice,ProQuantity,Units,DisPer,DisAmt,TPrice,RCash,Change,SalDate,SalTime from Sales where SalID ='" & Convert.ToInt32(TextBox1.Text) & "'"
                        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                            connection.Open()
                            Using command As New SqlCommand(sql, connection)
                                Using adapter As New SqlDataAdapter(command)
                                    Dim dt As New DataTable("Sales")
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
                    MsgBox("ID Not Found", MsgBoxStyle.Information)
                End If
                con.Close()
            End If
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim abez As New SellItems
        abez.TextBox13.Text = a1
        Dim result As Integer = MsgBox("Do you really want to Delete the record. ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
        If result = DialogResult.Yes Then
            qry = "Delete from Sales where SalID ='" & abez.TextBox13.Text & "'"
            Dim wantToDelete As Boolean = Convert.ToBoolean(InsertData(qry))
            If (wantToDelete) Then
                MsgBox("Sales Deleted Sucessfully", MsgBoxStyle.Information)
                Savitar()
                Vibe()
            Else
                MsgBox("Record Not Deleted", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Sub Vibe()
        Dim abez As New SellItems
        If (IsFormValid3()) Then
            qry = "Delete from Company2 where PayID ='" & d1 & "'"
            Dim wantToDelete As Boolean = Convert.ToBoolean(InsertData(qry))
        End If
    End Sub
    Private Function IsFormValid3() As Boolean
        Dim abez As New SellItems
        If (d1 = String.Empty) Then
            MsgBox("Payment ID is Required", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function
    Private Sub Savitar()
        Dim f As New SellItems
        Dim r1 As String = f1
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(10, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 10 Then
                    Dim data As String = " "
                    Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
                    Dim query As String = "Select ProQuantity from Phones where ProID ='" & f1 & "'"
                    Using connection As New SqlConnection(connectionString)
                        connection.Open()
                        Using command As New SqlCommand(query, connection)
                            Dim reader As SqlDataReader = command.ExecuteReader()
                            While reader.Read()
                                data = reader("ProQuantity").ToString()
                            End While
                        End Using
                    End Using
                    Dim a As String
                    a = data + b2a
                    qry = "Update Phones set ProQuantity ='" & a & "'where ProID ='" & f1 & "'"
                    Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
                ElseIf number = 20 Then
                    Dim data As String = " "
                    Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
                    Dim query As String = "Select ProQuantity from Laptops where ProID ='" & f1 & "'"
                    Using connection As New SqlConnection(connectionString)
                        connection.Open()
                        Using command As New SqlCommand(query, connection)
                            Dim reader As SqlDataReader = command.ExecuteReader()
                            While reader.Read()
                                data = reader("ProQuantity").ToString()
                            End While
                        End Using
                    End Using
                    Dim a As String
                    a = data + b2a
                    qry = "Update Laptops set ProQuantity ='" & a & "'where ProID ='" & f1 & "'"
                    Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
                Else
                    MsgBox("Invalid Product ID", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Product ID is Required", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        BindGDP()
    End Sub
End Class