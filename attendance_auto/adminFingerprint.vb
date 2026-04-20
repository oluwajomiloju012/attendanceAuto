Public Class adminFingerprint

   
   
    Private Sub Guna2Button2_Click(sender As System.Object, e As System.EventArgs) Handles Guna2Button2.Click
        Me.Close()
        overlay.Close()
        dashBoard.Show()
    End Sub

    Private Sub adminFingerprint_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        emailTxt.Text = adminRecordMain.emailTxt.Text

        passport.Image = adminRecordMain.pictureBox.Image

        adminCount.Text = GetAdminCount()
        getStaffIds()

    End Sub
End Class