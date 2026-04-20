Public Class attendanceRecord

    Private Sub closeBtn_Click(sender As System.Object, e As System.EventArgs) Handles closeBtn.Click
        Me.Close()
        dashBoard.Show()
        overlay.Close()
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


        If e.KeyChar = "@" AndAlso Not emailTxt.Text.Contains("@") Then
            Return
        End If

        ' Block all other characters
        e.Handled = True
        MessageBox.Show("Only letters, numbers, one '@', and one '.' are allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Class