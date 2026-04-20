Public Class viewStudentRecord

    Private Sub closeBtn_Click(sender As System.Object, e As System.EventArgs) Handles closeBtn.Click
        Me.Close()
        studentRecordMain.Show()
    End Sub

    Private Sub Guna2Button1_Click(sender As System.Object, e As System.EventArgs) Handles backBtn.Click
        Me.Close()
        studentRecordMain.Show()
    End Sub

    Private Sub viewStudentRecord_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        functions.studentRecord()
        countNo.Text = GetRecordCount()
    End Sub
End Class