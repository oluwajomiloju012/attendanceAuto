Public Class studentFingerprint

    Private Sub Guna2Button2_Click(sender As System.Object, e As System.EventArgs) Handles Guna2Button2.Click
        Me.Close()
        dashBoard.Show()
        overlay.Close()
    End Sub

    Private Sub studentFingerprint_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        emailTxt.Text = studentRecordMain.emailTxt.Text

        passport.Image = studentRecordMain.pictureBox.Image

        studentCount.Text = GetRecordCount()
        getUserIds()
    End Sub
End Class