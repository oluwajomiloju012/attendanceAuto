Public Class changePassword

   
    Private Sub closeBtn_Click(sender As System.Object, e As System.EventArgs) Handles closeBtn.Click
        dashBoard.Show()
        Me.Close()
        overlay.Close()
    End Sub
End Class