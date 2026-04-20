Public Class dashBoard

   
    Private Sub Guna2Button2_Click(sender As System.Object, e As System.EventArgs) Handles Guna2Button2.Click
        overlay.Show()
        adminRecordMain.Show()
    End Sub

    Private Sub logoutBtn_Click(sender As System.Object, e As System.EventArgs) Handles logoutBtn.Click

        Dim result As DialogResult = MessageBox.Show("ARE YOU SURE YOU WANT TO LOG OUT", "AUTO SYSTEM APPLICATION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            adminLogin.Show()

            Me.Close()
        End If

    End Sub

    Private Sub Guna2Button1_Click(sender As System.Object, e As System.EventArgs) Handles Guna2Button1.Click
        logins.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button3_Click(sender As System.Object, e As System.EventArgs) Handles Guna2Button3.Click
        overlay.Show()
        studentRecordMain.Show()


    End Sub

    Private Sub Guna2Button4_Click(sender As System.Object, e As System.EventArgs) Handles Guna2Button4.Click
        overlay.Show()
        attendanceRecord.Show()
    End Sub


    Private Sub Guna2Button5_Click(sender As System.Object, e As System.EventArgs) Handles Guna2Button5.Click
        overlay.Show()
        changePassword.Show()

    End Sub


    Private Sub dashBoard_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        ' Display current date and time
        dateTxt.Text = DateTime.Now.ToString("dddd, dd MMM yyyy")

        ' Display current date and time in dd/MM/yyyy HH:mm:ss format
        lastloginTxt.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")

        countTimeTxt.Text = DateTime.Now.ToString(" HH:mm:ss tt")

        totalStudent.Text = GetRecordCount()
        totalAdmin.Text = GetAdminCount()
        

    End Sub

    Private Sub Guna2DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs)


    End Sub
End Class