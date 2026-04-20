Public Class viewAdminRecord

    Private Sub Guna2Button1_Click(sender As System.Object, e As System.EventArgs) Handles backBtn.Click
        adminRecordMain.Show()
        Me.Close()
    End Sub

    Private Sub closeBtn_Click(sender As System.Object, e As System.EventArgs) Handles closeBtn.Click
        adminRecordMain.Show()
        Me.Close()
        overlay.Close()
    End Sub

    Private Sub viewAdminRecord_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        functions.adminRecord()
        viewAdminCount.Text = GetAdminCount()
    End Sub
End Class