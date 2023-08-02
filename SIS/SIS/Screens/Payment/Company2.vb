Imports System.CodeDom.Compiler
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Company2
    Public executed As Boolean = False
    Dim a1, b1, c1, d1, e1 As String
    Dim a2b As Integer
    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub Company2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindGD()
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim con As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("Select count(*) from Company2 where PurID = @PurID", con)
        cmd.Parameters.AddWithValue("@PurID", TextBox9.Text)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
            Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
            Dim sql As String = "Select PayID,SalID,CID,PID,PayType,Amt,PayDate,PayTime from Company2 where PurID ='" & Convert.ToInt32(TextBox9.Text) & "'"
            Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
                connection.Open()
                Using command As New SqlCommand(sql, connection)
                    Using adapter As New SqlDataAdapter(command)
                        Dim dt As New DataTable("Company2")
                        adapter.Fill(dt)
                        DataGridView1.DataSource = dt
                        DataGridView1.Refresh()
                    End Using
                End Using
            End Using
        Else
            MsgBox("Product ID Not Found", MsgBoxStyle.Information)
        End If
        con.Close()
    End Sub
    Public Sub BindGD()
        Dim ConnectionString As String = "Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True"
        Dim sql As String = "Select PayID,SalID,CID,PID,PayType,Amt, PayDate,PayTime from Company2 order by ID asc"
        Using connection As New SqlConnection("Data Source=THEDS482\SQLEXPRESS;Initial Catalog=SIS482;Integrated Security=True")
            connection.Open()
            Using command As New SqlCommand(sql, connection)
                Using adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable("Company2")
                    adapter.Fill(dt)
                    DataGridView1.DataSource = dt
                    DataGridView1.Refresh()
                End Using
            End Using
        End Using
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        i = DataGridView1.CurrentRow.Index
        If (i >= 0) Then
            a1 = DataGridView1.Item(0, i).Value
            b1 = DataGridView1.Item(1, i).Value
            c1 = DataGridView1.Item(2, i).Value
            d1 = DataGridView1.Item(3, i).Value
            e1 = DataGridView1.Item(4, i).Value
            a2b = DataGridView1.Item(1, i).Value
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Me.Close()
        Dim f As New Sales1()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
        MsgBox("Please Enter the Update Details", MsgBoxStyle.Information)
        f.TextBox1.Text = a2b
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Me.Close()
        Dim f As New Sales1()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
        MsgBox("Please Delete the Details", MsgBoxStyle.Information)
        f.TextBox1.Text = a2b
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text.Length > 3 Then
            TextBox9.Text = TextBox9.Text.Substring(0, 3)
            TextBox9.SelectionStart = 3
            MsgBox("Only 3 Digits Allowed", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Dim s As New DashboardForm()
        My.Forms.DashboardForm.Panel3.Controls.Clear()
        Dim f As New Payment()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub
    Private Sub TextBox9_Leave(sender As Object, e As EventArgs) Handles TextBox9.Leave
        Dim r1 As String = TextBox9.Text
        If r1.Length >= 2 Then
            Dim firstTwoDigits As String = r1.Substring(0, 2)
            If Integer.TryParse(60, Nothing) Then
                Dim number As Integer = Integer.Parse(firstTwoDigits)
                If number = 60 Then
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