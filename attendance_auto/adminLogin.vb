Public Class adminLogin

    Private Sub closeBtn_Click(sender As System.Object, e As System.EventArgs) Handles closeBtn.Click
        logins.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button1_Click(sender As System.Object, e As System.EventArgs) Handles loginBtn.Click
        getLoginDetails()
        emailTxt.Text = ""
        passwordTxt.Text = ""


    End Sub

    Private Sub Guna2HtmlLabel3_Click(sender As System.Object, e As System.EventArgs) Handles Guna2HtmlLabel3.Click
        forgotPassword.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2HtmlLabel8_Click(sender As System.Object, e As System.EventArgs) Handles Guna2HtmlLabel8.Click
        adminBiometrics.Show()
        Me.Hide()

    End Sub

    Private Sub Guna2PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles Guna2PictureBox2.Click
        adminBiometrics.Show()
        Me.Hide()
    End Sub

    Private Sub emailTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles emailTxt.KeyPress
        If Char.IsControl(e.KeyChar) Then
            Return
        End If


        If Char.IsLetterOrDigit(e.KeyChar) Then
            Return
        End If

        '  one dot 
        If e.KeyChar = "." AndAlso Not emailTxt.Text.Contains(".") Then
            Return
        End If

        '
        If e.KeyChar = "@" AndAlso Not emailTxt.Text.Contains("@") Then
            Return
        End If

        ' Block all other characters
        e.Handled = True
        MessageBox.Show("Only letters, numbers, one '@', and one '.' are allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Guna2HtmlLabel6_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class