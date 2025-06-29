Imports System.Data.SqlClient

Public Class Report5
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
        Dim f As New Loading()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub
    Private Sub Report5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShadowMonster()
        ShadowMonster1()
        ShadowMonster2()
        ShadowMonster3()
        ShadowMonster4()
        ShadowMonster5()
    End Sub
    Private Sub ShadowMonster5()
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim connection As SqlConnection = New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        connection.Open()
        Dim command As SqlCommand = New SqlCommand("Select Count(*) from Sales where ProCat ='Laptops'", connection)
        Dim count As String = command.ExecuteScalar().ToString()
        Label12.Text = count
        connection.Close()
    End Sub
    Private Sub ShadowMonster4()
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim connection As SqlConnection = New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        connection.Open()
        Dim command As SqlCommand = New SqlCommand("Select Count(*) from Buy where ProCat ='Laptops'", connection)
        Dim count As String = command.ExecuteScalar().ToString()
        Label10.Text = count
        connection.Close()
    End Sub
    Private Sub ShadowMonster3()
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim connection As SqlConnection = New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        connection.Open()
        Dim command As SqlCommand = New SqlCommand("Select Count(*) from Sales where ProCat ='Phones'", connection)
        Dim count As String = command.ExecuteScalar().ToString()
        Label8.Text = count
        connection.Close()
    End Sub
    Private Sub ShadowMonster2()
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim connection As SqlConnection = New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        connection.Open()
        Dim command As SqlCommand = New SqlCommand("Select Count(*) from Buy where ProCat ='Phones'", connection)
        Dim count As String = command.ExecuteScalar().ToString()
        Label5.Text = count
        connection.Close()
    End Sub
    Private Sub ShadowMonster1()
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim connection As SqlConnection = New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        connection.Open()
        Dim command As SqlCommand = New SqlCommand("Select Count(*) from Laptops where ProCat ='Laptops'", connection)
        Dim count As String = command.ExecuteScalar().ToString()
        Label3.Text = count
        connection.Close()
    End Sub
    Public Sub ShadowMonster()
        Dim connectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim connection As SqlConnection = New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        connection.Open()
        Dim command As SqlCommand = New SqlCommand("Select Count(*) from Phones where ProCat ='Phones'", connection)
        Dim count As String = command.ExecuteScalar().ToString()
        Label2.Text = count
        connection.Close()
    End Sub
    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        Me.Close()
        Dim f As New ReportDel()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
        Dim obj As New Report5
        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select ProID,ProCat,ProName,ProQuantity from Phones order by ID asc"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Using command As New SqlCommand(sql, connection)
                Using adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable("Phones")
                    adapter.Fill(dt)
                    f.DataGridView1.DataSource = dt
                    f.DataGridView1.Refresh()
                End Using
            End Using
        End Using
    End Sub
    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        Me.Close()
        Dim f As New ReportDel()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select ProID,ProCat,ProName,ProQuantity from Laptops order by ID asc"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Using command As New SqlCommand(sql, connection)
                Using adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable("Laptops")
                    adapter.Fill(dt)
                    f.DataGridView1.DataSource = dt
                    f.DataGridView1.Refresh()
                End Using
            End Using
        End Using
    End Sub
    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        Me.Close()
        Dim f As New ReportDel()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select PurID,EID,SID,PayID,ProID,ProCat,ProName,ProPrice,ProQuantity,Units,TPrice from Buy where ProCat ='Phones' order by ID asc"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Using command As New SqlCommand(sql, connection)
                Using adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable("Buy")
                    adapter.Fill(dt)
                    f.DataGridView1.DataSource = dt
                    f.DataGridView1.Refresh()
                End Using
            End Using
        End Using
    End Sub
    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        Me.Close()
        Dim f As New ReportDel()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select SalID,EID,CID,PayID,ProID,ProCat,ProName,ProPrice,ProQuantity,Units,DisPer,DisAmt,TPrice,RCash,Change from Sales where ProCat ='Phones 'order by ID asc"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Using command As New SqlCommand(sql, connection)
                Using adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable("Sales")
                    adapter.Fill(dt)
                    f.DataGridView1.DataSource = dt
                    f.DataGridView1.Refresh()
                End Using
            End Using
        End Using
    End Sub
    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles Panel6.Click
        Me.Close()
        Dim f As New ReportDel()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select PurID,EID,SID,PayID,ProID,ProCat,ProName,ProPrice,ProQuantity,Units,TPrice from Buy where ProCat ='Laptops' order by ID asc"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Using command As New SqlCommand(sql, connection)
                Using adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable("Buy")
                    adapter.Fill(dt)
                    f.DataGridView1.DataSource = dt
                    f.DataGridView1.Refresh()
                End Using
            End Using
        End Using
    End Sub
    Private Sub Panel7_Click(sender As Object, e As EventArgs) Handles Panel7.Click
        Me.Close()
        Dim f As New ReportDel()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select SalID,EID,CID,PayID,ProID,ProCat,ProName,ProPrice,ProQuantity,Units,DisPer,DisAmt,TPrice,RCash,Change from Sales where ProCat ='Laptops' order by ID asc"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Using command As New SqlCommand(sql, connection)
                Using adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable("Sales")
                    adapter.Fill(dt)
                    f.DataGridView1.DataSource = dt
                    f.DataGridView1.Refresh()
                End Using
            End Using
        End Using
    End Sub
End Class