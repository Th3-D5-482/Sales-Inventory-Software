﻿Public Class P_and_S
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
        Dim s As New DashboardForm()
        My.Forms.DashboardForm.Panel3.Controls.Clear()
        Dim f As New Supplier()
        f.TopLevel = False
        f.Visible = True
        My.Forms.DashboardForm.Panel3.Controls.Add(f)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Dim s As New DashboardForm()
        My.Forms.DashboardForm.Panel3.Controls.Clear()
        Dim f As New Buy()
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
End Class