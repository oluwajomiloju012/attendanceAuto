Imports AForge.Video
Imports AForge.Video.DirectShow
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class studentRecordMain

    Private captureDevices As FilterInfoCollection
    Private captureDevice As VideoCaptureDevice
    Private currentFrame As Bitmap


    Private Sub Guna2Button4_Click(sender As System.Object, e As System.EventArgs) Handles studentSave.Click
        Dim answer As DialogResult
        If fullnameTxt.Text = "" Then
            MessageBox.Show("Name field can't be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf emailTxt.Text = "" Then
            MessageBox.Show("Email field can't be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim email As String
            email = emailTxt.Text
            ' Check if email ends with @gmail.com
        ElseIf Not emailTxt.Text.EndsWith("@gmail.com") Then
            MessageBox.Show("Email must be a valid Gmail address (e.g., user@gmail.com).", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf numberTxt.Text = "" Then
            MessageBox.Show("Phone number field can't be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf gendercombobox.SelectedValue Is Nothing OrElse statuscombobox.SelectedValue Is Nothing OrElse programmeCombobox.SelectedValue Is Nothing Then
            MessageBox.Show("Please select Gender, Status, and Programme before saving.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            If combobox.Text = "SELECT STUDENT" Then
                answer = MessageBox.Show("Are you sure you want to save?", "Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (answer = DialogResult.Yes) Then
                    If functions.RegistrationemailCheckstudent(emailTxt.Text) Then
                        MessageBox.Show("Email Address already Exist, Kindly Enter a new Email Address to Continue!", "Auto System Application", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    ElseIf numberTxt.Text.Length <> 11 Then
                        MessageBox.Show("Mobile number must be exactly 11 digits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        numberTxt.Focus()
                        Return
                    Else
                        functions.insertUser()
                    End If
                End If
            Else
                answer = MessageBox.Show("Are you sure you want to update?", "Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If answer = DialogResult.Yes Then
                    If functions.UpdateemailCheckstudent(emailTxt.Text) Then
                        MessageBox.Show("Email Address is already Exist, Kindly Enter a new Email Address to Continue!", "Auto System Application", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        functions.updateUser()
                    End If
                End If
            End If

            fullnameTxt.Text = ""
            emailTxt.Text = ""
            numberTxt.Text = ""
            gendercombobox.Text = "Select gender"
            statuscombobox.Text = "Select status"
            programmeCombobox.Text = "Select programme"
            pictureBox.Image = Nothing

        End If


    End Sub

    Private Sub fullnameTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles fullnameTxt.KeyPress
        ' Allow space
        If e.KeyChar = " " Then
            Return
        End If

        ' Allow only letters
        If Not Char.IsLetter(e.KeyChar) AndAlso Not e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("This field allows only letters", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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

    Private Sub numberTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles numberTxt.KeyPress
        ' Allow control keys (e.g., Backspace, Delete, etc.)
        If Char.IsControl(e.KeyChar) Then
            Return
        End If


        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("This field allows only numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Limit to 11 digits
        If numberTxt.Text.Length >= 11 Then
            e.Handled = True
            MessageBox.Show("Phone number cannot exceed 11 digits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
    End Sub

    Private Sub Guna2Button5_Click(sender As System.Object, e As System.EventArgs) Handles Guna2Button5.Click
        fullnameTxt.Text = ""
        emailTxt.Text = ""
        numberTxt.Text = ""
        gendercombobox.Text = "Select gender"
        statuscombobox.Text = "Select status"
        programmeCombobox.Text = "Select programme"
        combobox.Text = "SELECT STUDENT"
        pictureBox.Image = Nothing
        captureDevice.SignalToStop()
    End Sub

    Private Sub studentRecordMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadStudentComboboxes()
        realCount.Text = GetRecordCount()
        getUserIds()


    End Sub
    


    Private Sub fetchBtn_Click(sender As System.Object, e As System.EventArgs) Handles fetchBtn.Click
        fetchUser()
    End Sub

    Private Sub Guna2Button3_Click(sender As System.Object, e As System.EventArgs) Handles Guna2Button3.Click
        Try
            If captureDevice IsNot Nothing AndAlso captureDevice.IsRunning Then
                RemoveHandler captureDevice.NewFrame, AddressOf CaptureDevice_NewFrame
                captureDevice.SignalToStop()
                captureDevice.WaitForStop()
            End If
        Catch ex As Exception
            MessageBox.Show("Error stopping camera: " & ex.Message)
        End Try
    End Sub

    Private Sub viewRecord_Click(sender As System.Object, e As System.EventArgs) Handles viewRecord.Click
        viewStudentRecord.Show()
        Me.Close()
        overlay.Show()
    End Sub

    Private Sub closeBtn_Click(sender As System.Object, e As System.EventArgs) Handles closeBtn.Click
        dashBoard.Show()
        Me.Close()
        overlay.Close()
    End Sub

    Private Sub CaptureDevice_NewFrame(sender As Object, eventArgs As NewFrameEventArgs)
        currentFrame = CType(eventArgs.Frame.Clone(), Bitmap)
        pictureBox.Image = CType(currentFrame.Clone(), Bitmap)
    End Sub

    Private Sub pictureBox_Click(sender As System.Object, e As System.EventArgs) Handles pictureBox.Click
        Try
            captureDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)

            If captureDevices.Count > 0 Then
                captureDevice = New VideoCaptureDevice(captureDevices(0).MonikerString)
                AddHandler captureDevice.NewFrame, AddressOf CaptureDevice_NewFrame
                captureDevice.Start()
            Else
                MessageBox.Show("No camera detected on this system.", "Camera Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error initializing camera: " & ex.Message)
        End Try
    End Sub

   
    
End Class