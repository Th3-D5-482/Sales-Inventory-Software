Imports System.Data.SqlClient
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Public Class buy
    Public executed As Boolean = False
    Dim currentTime As DateTime = DateTime.Now
    Dim timeString As String = currentTime.ToString("hh:mm:ss tt")
    Private Sub btnadd_click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If (isformvalid()) Then
            qry = "Insert into Buy values ('" & TextBox11.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox5.Text & "','" & ComboBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox10.Text & "','" & TextBox8.Text & "','" & Date.Now & "','" & timeString & "')"
            Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(qry))
            If (logincorrect) Then
                MsgBox("Purchase Added Sucessfully", MsgBoxStyle.Information)
                Exlir()
                WakandaForever()
                clr()
            Else
                MsgBox("Record not Saved", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Sub WakandaForever()
        If (isformvalid()) Then
            qry = "Insert into Supplier2 values ('" & TextBox5.Text & "','" & TextBox11.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox2.Text & "','" & TextBox8.Text & "','" & Date.Now & "','" & timeString & "')"
            Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(qry))
        End If
        Me.Close()
        Dim f As New Supplier2()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
        MsgBox("Payment Sucessfully Added", MsgBoxStyle.Information)
    End Sub
    Private Function Exlir() As Boolean
        Dim r1 As String = TextBox3.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(10, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 10 Then
                    Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    con.Open()
                    Dim cmd As New SqlCommand("Select count(*) from Phones where ProID = @ProID", con)
                    cmd.Parameters.AddWithValue("@ProID", TextBox3.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        Hulk()
                        Return True
                    Else
                        qry = "Insert into Phones values ('" & TextBox3.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & TextBox10.Text & "')"
                        Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(qry))
                    End If
                    con.Close()
                ElseIf number = 20 Then
                    Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    con.Open()
                    Dim cmd As New SqlCommand("Select count(*) from Laptops where ProID = @ProID", con)
                    cmd.Parameters.AddWithValue("@ProID", TextBox3.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        Hulk()
                        Return True
                    Else
                        qry = "Insert into Laptops values ('" & TextBox3.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & TextBox10.Text & "')"
                        Dim logincorrect As Boolean = Convert.ToBoolean(InsertData(qry))
                    End If
                    con.Close()
                Else
                    MsgBox("Invalid Product ID", MsgBoxStyle.Information)
                    Return False
                End If
            End If
        Else
            MsgBox("Product ID is Required", MsgBoxStyle.Critical)
        End If
        Return True
        Return True
    End Function
    Private Sub Hulk()
        Dim r1 As String = TextBox3.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(20, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 10 Then
                    Dim a As String
                    a = Integer.Parse(TextBox7.Text) + TextBox10.Text
                    qry = "Update Phones set ProQuantity ='" & a & "'where ProID ='" & Convert.ToInt32(TextBox3.Text) & "'"
                    Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
                ElseIf number = 20 Then
                    Dim a As String
                    a = Integer.Parse(TextBox7.Text) + TextBox10.Text
                    qry = "Update Laptops set ProQuantity ='" & a & "'where ProID ='" & Convert.ToInt32(TextBox3.Text) & "'"
                    Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
                Else
                    MsgBox("Invalid Product ID", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Product ID is Required", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Function isformvalid() As Boolean
        If (TextBox2.Text = 30) Then
            MsgBox("Supplier ID is required", MsgBoxStyle.Critical)
            clr()
            Return False
        ElseIf (TextBox3.Text.Trim() = String.Empty) Then
            MsgBox("Product ID is required", MsgBoxStyle.Critical)
            clr()
            Return False
        ElseIf (ComboBox1.SelectedIndex = -1) Then
            MsgBox("Product Category is required", MsgBoxStyle.Critical)
            clr()
            Return False
        ElseIf (TextBox4.Text.Trim() = String.Empty) Then
            MsgBox("Product Name is required", MsgBoxStyle.Critical)
            clr()
            Return False
        ElseIf (TextBox6.Text.Trim() = String.Empty) Then
            MsgBox("Product Price is required", MsgBoxStyle.Critical)
            clr()
            Return False
        ElseIf (TextBox5.Text = 50) Then
            MsgBox("Payment ID is Required", MsgBoxStyle.Critical)
            clr()
            Return False
        ElseIf (TextBox11.Text = 70) Then
            MsgBox("Purchase ID is Required", MsgBoxStyle.Critical)
            clr()
            Return False
        ElseIf (ComboBox2.SelectedIndex = -1) Then
            MsgBox("Payment Type is Required", MsgBoxStyle.Critical)
            clr()
            Return False
        End If
        Return True
    End Function
    Public Sub clr()
        TextBox2.Text = "30"
        TextBox5.Text = "50"
        TextBox3.Clear()
        ComboBox1.Text = Nothing
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox10.Clear()
        TextBox8.Clear()
        TextBox11.Text = "70"
        ComboBox2.Text = Nothing
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If (isformvalid()) Then
            qry = "Update Buy set PurID ='" & TextBox11.Text & "',EID ='" & TextBox1.Text & "',SID ='" & TextBox2.Text & "',PayID ='" & TextBox5.Text & "',PayType ='" & ComboBox2.Text & "',ProID ='" & TextBox3.Text & "',ProCat ='" & ComboBox1.Text & "',ProName ='" & TextBox4.Text & "',ProPrice ='" & TextBox6.Text & "',ProQuantity ='" & TextBox7.Text & "',Units ='" & TextBox10.Text & "',TPrice ='" & TextBox8.Text & "' where PurID='" & Convert.ToInt32(TextBox11.Text) & "'"
            Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
            If (isupdatetrue) Then
                MsgBox("Purchase Updated Sucessfully", MsgBoxStyle.Information)
                btnAdd.Enabled = True
                Hulk()
                Thinker()
                clr()
            Else
                MsgBox("Record Not Updated", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Sub Thinker()
        If (isformvalid()) Then
            qry = "Update Supplier2 set PayID='" & TextBox5.Text & "',PurID ='" & TextBox11.Text & "',SID ='" & TextBox2.Text & "',PID ='" & TextBox3.Text & "',PayType ='" & ComboBox2.Text & "',Amt ='" & TextBox8.Text & "' where PayID ='" & Convert.ToInt32(TextBox5.Text) & "'"
            Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As Integer = MsgBox("Do you really want to Delete the record. ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
        If result = DialogResult.Yes Then
            If (IsFormValid2()) Then
                qry = "Delete from Buy where PurID ='" & Convert.ToInt32(TextBox11.Text) & "'"
                Dim wantToDelete As Boolean = Convert.ToBoolean(InsertData(qry))
                If (wantToDelete) Then
                    MsgBox("Purchase Deleted Sucessfully", MsgBoxStyle.Information)
                    btnAdd.Enabled = True
                    TextBox11.Enabled = True
                    Savitar()
                    Vibe()
                    QuickSilver()
                    clr()
                Else
                    MsgBox("Record Not Deleted", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub
    Private Sub QuickSilver()
        Dim r1 As String = TextBox3.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(10, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 10 Then
                    Dim data As String = " "
                    Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
                    Dim query As String = "Select ProQuantity from Phones where ProID ='" & TextBox3.Text & "'"
                    Using connection As New SqlConnection(connectionString)
                        connection.Open()
                        Using command As New SqlCommand(query, connection)
                            Dim reader As SqlDataReader = command.ExecuteReader()
                            While reader.Read()
                                data = reader("ProQuantity").ToString()
                            End While
                        End Using
                    End Using
                    Dim data1 As String = Val(data)
                    Dim blue5 As Integer = Integer.Parse(data1)
                    If (blue5 = 0) Then
                        If (IsFormValid4()) Then
                            qry = "Delete from Phones where ProID ='" & Convert.ToInt32(TextBox3.Text) & "'"
                            Dim wantToDelete As Boolean = Convert.ToBoolean(InsertData(qry))
                        End If
                    End If
                ElseIf number = 20 Then
                    Dim data As String = " "
                    Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
                    Dim query As String = "Select ProQuantity from Laptops where ProID ='" & TextBox3.Text & "'"
                    Using connection As New SqlConnection(connectionString)
                        connection.Open()
                        Using command As New SqlCommand(query, connection)
                            Dim reader As SqlDataReader = command.ExecuteReader()
                            While reader.Read()
                                data = reader("ProQuantity").ToString()
                            End While
                        End Using
                    End Using
                    Dim data1 As String = Val(data)
                    Dim blue5 As Integer = Integer.Parse(data1)
                    If (blue5 = 0) Then
                        If (IsFormValid4()) Then
                            qry = "Delete from Laptops whre ProID ='" & Convert.ToBoolean(TextBox3.Text) & "'"
                            Dim wantToDelete As Boolean = Convert.ToBoolean(InsertData(qry))
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Function IsFormValid4() As Boolean
        If (TextBox3.Text.Trim() = String.Empty) Then
            MsgBox("Product ID is Required", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function
    Private Sub Vibe()
        If (IsFormValid3()) Then
            qry = "Delete from Supplier2 where PayID ='" & Convert.ToInt32(TextBox5.Text) & "'"
            Dim wantToDelete As Boolean = Convert.ToBoolean(InsertData(qry))
        End If
    End Sub
    Private Function IsFormValid3() As Boolean
        If (TextBox5.Text.Trim() = String.Empty) Then
            MsgBox("Payment ID is Required", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function
    Private Sub Savitar()
        Dim r1 As String = TextBox3.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(10, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 10 Then
                    Dim data As String = " "
                    Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
                    Dim query As String = "Select ProQuantity from Phones where ProID = '" & Convert.ToInt32(TextBox3.Text) & "'"
                    Using connection As New SqlConnection(connectionString)
                        connection.Open()
                        Using command As New SqlCommand(query, connection)
                            Dim reader As SqlDataReader = command.ExecuteReader()
                            While reader.Read()
                                data = reader("ProQuantity").ToString()
                            End While
                        End Using
                    End Using
                    If (data > 0) Then
                        Dim a As String
                        a = data - TextBox10.Text
                        qry = "Update Phones set ProQuantity ='" & a & "'where ProID ='" & Convert.ToInt32(TextBox3.Text) & "'"
                        Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
                    End If
                ElseIf number = 20 Then
                    Dim data As String = " "
                    Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
                    Dim query As String = "Select ProQuantity from Laptops where ProID = '" & Convert.ToInt32(TextBox3.Text) & "'"
                    Using connection As New SqlConnection(connectionString)
                        connection.Open()
                        Using command As New SqlCommand(query, connection)
                            Dim reader As SqlDataReader = command.ExecuteReader()
                            While reader.Read()
                                data = reader("ProQuantity").ToString()
                            End While
                        End Using
                    End Using
                    If (data > 0) Then
                        Dim a As Integer
                        a = data - TextBox10.Text
                        qry = "Update Laptops set ProQuantity ='" & a & "'where ProID ='" & Convert.ToInt32(TextBox3.Text) & "'"
                        Dim isupdatetrue As Boolean = Convert.ToBoolean(InsertData(qry))
                    End If
                Else
                    MsgBox("Invalid Product ID", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Product ID is Required", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Function IsFormValid2() As Boolean
        If (TextBox11.Text.Trim() = String.Empty) Then
            MsgBox("Purchase ID is Required", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim r1 As String = TextBox9.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(70, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 70 Then
                    Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    con.Open()
                    Dim cmd As New SqlCommand("Select count(*) from Buy where PurID = @PurID", con)
                    cmd.Parameters.AddWithValue("@PurID", TextBox9.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
                        Dim sql As String = "Select PurID,EID,SID,PayID,PayType,ProID,ProCat,ProName,ProPrice,ProQuantity,Units,TPrice,PurDate,PurTime from Buy where PurID ='" & Convert.ToInt32(TextBox9.Text) & "'"
                        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                            connection.Open()
                            Using command As New SqlCommand(sql, connection)
                                Using adapter As New SqlDataAdapter(command)
                                    Dim dt As New DataTable("Buy")
                                    adapter.Fill(dt)
                                    DataGridView1.DataSource = dt
                                    DataGridView1.Refresh()
                                End Using
                            End Using
                        End Using
                    Else
                        MsgBox("Purchase ID Not Found", MsgBoxStyle.Information)
                    End If
                    con.Close()
                Else
                    MsgBox("Purchase ID Not Found", MsgBoxStyle.Information)
                End If
                con.Close()
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        btnAdd.Enabled = True
        BindGD()
    End Sub
    Public Sub BindGD()
        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select PurID,EID,SID,PayID,PayType,ProID,ProCat,ProName,ProPrice,ProQuantity,Units,TPrice,PurDate,PurTime from Buy order by ID asc"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Using command As New SqlCommand(sql, connection)
                Using adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable("Buy")
                    adapter.Fill(dt)
                    DataGridView1.DataSource = dt
                    DataGridView1.Refresh()
                End Using
            End Using
        End Using
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox11.Enabled = False
        btnAdd.Enabled = False
        TextBox5.Enabled = False
        i = DataGridView1.CurrentRow.Index
        If (i >= 0) Then
            TextBox11.Text = DataGridView1.Item(0, i).Value
            TextBox1.Text = DataGridView1.Item(1, i).Value
            TextBox2.Text = DataGridView1.Item(2, i).Value
            TextBox5.Text = DataGridView1.Item(3, i).Value
            ComboBox2.Text = DataGridView1.Item(4, i).Value
            TextBox3.Text = DataGridView1.Item(5, i).Value
            ComboBox1.Text = DataGridView1.Item(6, i).Value
            TextBox4.Text = DataGridView1.Item(7, i).Value
            TextBox6.Text = DataGridView1.Item(8, i).Value
            TextBox7.Text = DataGridView1.Item(9, i).Value
            TextBox10.Text = DataGridView1.Item(10, i).Value
            TextBox8.Text = DataGridView1.Item(11, i).Value
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        TextBox11.Enabled = True
        btnAdd.Enabled = True
        TextBox5.Enabled = True
        clr()
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text.Length > 3 Then
            TextBox2.Text = TextBox2.Text.Substring(0, 3)
            TextBox2.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text.Length > 3 Then
            TextBox3.Text = TextBox3.Text.Substring(0, 3)
            TextBox3.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text.Length > 3 Then
            TextBox9.Text = TextBox9.Text.Substring(0, 3)
            TextBox9.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed ", MsgBoxStyle.Information)
        End If
    End Sub
    Private Function Sparky() As Boolean
        Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("Select count(*) from Employee where EID = @EID", con)
        cmd.Parameters.AddWithValue("@EID", TextBox1.Text)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
            Return True
        Else
            MsgBox(" Employee ID Not Found", MsgBoxStyle.Information)
            Return False
        End If
        con.Close()
    End Function
    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If TextBox2.Text.Length < 3 Then
            MsgBox("Enter 3 Digits", MsgBoxStyle.Information)
            TextBox2.Text = "30"
        Else
            Sparky1()
        End If
    End Sub
    Private Function Sparky1() As Boolean
        Dim ak As String
        ak = TextBox2.Text
        Dim r1 As String = TextBox2.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(30, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 30 Then
                    Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    con.Open()
                    Dim cmd As New SqlCommand("Select count(*) from Supplier where SID = @SID", con)
                    cmd.Parameters.AddWithValue("@SID", TextBox2.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        Return True
                    Else
                        If executed = False Then
                            MsgBox("Supplier ID Not Found", MsgBoxStyle.Information)
                            Dim Result As DialogResult = MsgBox("Do you want to add this Item ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                            If Result = DialogResult.Yes Then
                                executed = True
                                Me.Close()
                                Dim f As New Supplier()
                                f.TopLevel = False
                                f.Visible = True
                                My.Forms.DashboardForm.Panel3.Controls.Add(f)
                                MsgBox("Please Enter the Suppliers Details", MsgBoxStyle.Information)
                                f.TextBox1.Text = ak
                            Else
                                MsgBox("Invalid Supplier ID", MsgBoxStyle.Critical)
                                TextBox2.Text = "30"
                            End If
                        End If
                        Return False
                    End If
                    con.Close()
                Else
                    MsgBox("Invalid Supplier ID", MsgBoxStyle.Information)
                    TextBox2.Text = "30"
                    Return False
                End If
            End If
        Else
            MsgBox("Supplier ID Is Required", MsgBoxStyle.Critical)
            TextBox2.Text = "30"
        End If
        Return True
    End Function
    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        If TextBox3.Text.Length < 3 Then
            MsgBox("Enter 3 Digits", MsgBoxStyle.Information)
            TextBox3.Text = Nothing
        Else
            Dim r1 As String = TextBox3.Text
            If r1.Length >= 2 Then
                Dim firstTwoDigits As String = r1.Substring(0, 2)
                If Integer.TryParse(10, Nothing) Then
                    Dim number As Integer = Integer.Parse(firstTwoDigits)
                    If number = 10 Then
                        Sparky2()
                        ComboBox1.Text = "Phones"
                        TextBox7.Text = 0
                        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
                        Dim sql As String = "Select ProName, ProQuantity from Phones where ProID ='" & TextBox3.Text & "' "
                        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                            connection.Open()
                            Dim command As New SqlCommand(sql, connection)
                            Dim reader As SqlDataReader = command.ExecuteReader()
                            While reader.Read()
                                TextBox4.Text = reader("ProName").ToString()
                                TextBox7.Text = reader("ProQuantity").ToString()
                            End While
                        End Using
                    ElseIf number = 20 Then
                        Sparky3()
                        ComboBox1.Text = "Laptops"
                        TextBox7.Text = 0
                        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
                        Dim sql As String = "Select ProName,ProQuantity from Laptops where ProID ='" & TextBox3.Text & "' "
                        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                            connection.Open()
                            Dim command As New SqlCommand(sql, connection)
                            Dim reader As SqlDataReader = command.ExecuteReader()
                            While reader.Read()
                                TextBox4.Text = reader("ProName").ToString()
                                TextBox7.Text = reader("ProQuantity").ToString()
                            End While
                        End Using
                    Else
                        MsgBox("Invalid Product ID", MsgBoxStyle.Information)
                        TextBox3.Clear()
                    End If
                End If
            Else
                MsgBox("Product ID is Required", MsgBoxStyle.Critical)
                TextBox3.Clear()
            End If
        End If
    End Sub
    Private Function Sparky2() As Boolean
        Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("Select count(*) from Phones where ProID = @ProID", con)
        cmd.Parameters.AddWithValue("@ProID", TextBox3.Text)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
            Return True
        Else
            MsgBox("Product ID Not Found", MsgBoxStyle.Information)
            Dim Result As DialogResult = MsgBox("Do you want to Purchase this Item ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            If Result = DialogResult.Yes Then
                TextBox4.Clear()
                TextBox7.Clear()
                Return True
            Else
                MsgBox("Product ID Required", MsgBoxStyle.Critical)
                TextBox3.Clear()
                Return False
            End If
        End If
        con.Close()
    End Function
    Private Function Sparky3() As Boolean
        Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("Select count(*) from Laptops where ProID = @ProID", con)
        cmd.Parameters.AddWithValue("@ProID", TextBox3.Text)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
            Return True
        Else
            MsgBox("Product ID Not Found", MsgBoxStyle.Information)
            Dim Result As DialogResult = MsgBox("Do you want to Purchase this Item ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            If Result = DialogResult.Yes Then
                TextBox4.Clear()
                TextBox7.Clear()
                Return True
            Else
                MsgBox("Product ID Required", MsgBoxStyle.Critical)
                TextBox3.Clear()
                Return False
            End If
        End If
        con.Close()
    End Function
    Private Sub buy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = "30"
        TextBox5.Text = "50"
        TextBox11.Text = "70"
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select EID from Employee where UserName ='" & My.Forms.DashboardForm.Label2.Text & "'"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Dim command As New SqlCommand(sql, connection)
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read()
                TextBox1.Text = reader("EID").ToString()
            End While
        End Using
        BindGD()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Dim s As New DashboardForm()
        My.Forms.DashboardForm.Panel3.Controls.Clear()
        Dim f As New P_and_S()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
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
    Private Sub TextBox9_Leave(sender As Object, e As EventArgs) Handles TextBox9.Leave
        Dim r1 As String = TextBox9.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(70, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 70 Then
                    Thanos2()
                Else
                    MsgBox("Invalid Purchase ID", MsgBoxStyle.Information)
                    TextBox9.Clear()
                End If
            End If
        Else
            MsgBox("Purchase ID is Required", MsgBoxStyle.Critical)
            TextBox9.Clear()
        End If
    End Sub
    Private Function Thanos2() As Boolean
        Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("Select count(*) from Buy where PurID = @PurID", con)
        cmd.Parameters.AddWithValue("@PurID", TextBox9.Text)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
            Return True
        Else
            MsgBox("Purchase ID Not Found", MsgBoxStyle.Information)
            TextBox9.Clear()
            Return False
        End If
        Return True
    End Function
    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text.Length > 3 Then
            TextBox5.Text = TextBox5.Text.Substring(0, 3)
            TextBox5.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        If TextBox5.Text.Length < 3 Then
            MsgBox("Enter 3 Digits", MsgBoxStyle.Information)
            TextBox5.Text = "70"
        Else
            Batman()
        End If
    End Sub
    Private Function Batman() As Boolean
        Dim r1 As String = TextBox5.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(50, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 50 Then
                    Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    con.Open()
                    Dim cmd As New SqlCommand("Select count(*) from Supplier2 where PayID = @PayID", con)
                    cmd.Parameters.AddWithValue("@PayID", TextBox5.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MsgBox("Payment ID already Exist", vbOKOnly + MsgBoxStyle.Information)
                        TextBox5.Text = "50"
                    End If
                    Return True
                    con.Close()
                Else
                    MsgBox("Invalid Payment ID", MsgBoxStyle.Information)
                    TextBox5.Text = "50"
                    Return False
                End If
            End If
        Else
            MsgBox("Payment ID is Required", MsgBoxStyle.Critical)
            TextBox5.Text = "50"
        End If
        Return True
    End Function
    Private Sub TextBox10_Leave(sender As Object, e As EventArgs) Handles TextBox10.Leave
        Try
            If String.IsNullOrWhiteSpace(TextBox10.Text) Then
                Throw New Exception("Units is Required")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Light()
    End Sub
    Private Function Light() As Boolean
        Dim edd, edd2 As String
        edd = Val(TextBox7.Text)
        Dim num2 As Integer = Integer.Parse(edd)
        edd2 = Val(TextBox10.Text)
        Dim num3 As Integer = Integer.Parse(edd2)
        If (num2 = 0) Then
            Dim a, b As String
            Dim c As Integer
            a = Val(TextBox6.Text)
            Dim num As Integer = Integer.Parse(a)
            b = Val(TextBox10.Text)
            Dim num1 As Integer = Integer.Parse(b)
            c = num * num1
            TextBox8.Text = c
        Else
            Dim a, b As String
                Dim c As Integer
                a = Val(TextBox6.Text)
                Dim num As Integer = Integer.Parse(a)
                b = Val(TextBox10.Text)
                Dim num1 As Integer = Integer.Parse(b)
                c = num * num1
                TextBox8.Text = c
            End If
        Return True
        Return True
    End Function
    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        If TextBox11.Text.Length > 3 Then
            TextBox11.Text = TextBox11.Text.Substring(0, 3)
            TextBox11.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub TextBox11_Leave(sender As Object, e As EventArgs) Handles TextBox11.Leave
        If TextBox11.Text.Length < 3 Then
            MsgBox("Enter 3 Digits", MsgBoxStyle.Information)
            TextBox11.Text = "70"
        Else
            BackinTime()
        End If
    End Sub
    Private Function BackinTime() As Boolean
        Dim r1 As String = TextBox11.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(70, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 70 Then
                    Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                    con.Open()
                    Dim cmd As New SqlCommand("Select count(*) from Buy where PurID = @PurID", con)
                    cmd.Parameters.AddWithValue("@PurID", TextBox11.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MsgBox("Purchase ID already Exist", vbOKOnly + MsgBoxStyle.Information)
                        TextBox11.Text = "70"
                    End If
                    Return True
                    con.Close()
                Else
                    MsgBox("Invalid Purchase ID", MsgBoxStyle.Information)
                    TextBox11.Text = "70"
                    Return False
                End If
            End If
        Else
            MsgBox("Purchase ID is Required", MsgBoxStyle.Critical)
            TextBox11.Text = "70"
        End If
        Return True
    End Function
    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class