Public Class settings

    Private Sub closeBtn_Click(sender As System.Object, e As System.EventArgs) Handles closeBtn.Click
        Me.Close()
        forgotPassword.Show()

    End Sub

    Private Sub otpTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles otpTxt.KeyPress
        ' Allow control keys (e.g., Backspace, Delete, etc.)
        If Char.IsControl(e.KeyChar) Then
            Return
        End If


        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("This field allows only numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If


        If otpTxt.Text.Length >= 6 Then
            e.Handled = True
            MessageBox.Show("otp cannot exceed  6 digits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As System.Object, e As System.EventArgs) Handles Guna2Button1.Click
        functions.changePassword()
    End Sub

End Class