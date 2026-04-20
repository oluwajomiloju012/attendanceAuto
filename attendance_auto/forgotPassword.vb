Public Class forgotPassword

    Private Sub Guna2Button1_Click(sender As System.Object, e As System.EventArgs) Handles Guna2Button1.Click
       
        sendOTPToEmail()


    End Sub

    Private Sub Guna2CircleButton1_Click(sender As System.Object, e As System.EventArgs) Handles Guna2CircleButton1.Click
        Me.Close()
        adminLogin.Show()

    End Sub
End Class