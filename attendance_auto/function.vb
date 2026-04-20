Imports System.IO
Imports System.Runtime.InteropServices.ComTypes
Imports System.Text.RegularExpressions
Imports Guna.UI2.HtmlRenderer.Adapters
Imports MySql.Data.MySqlClient
Imports AForge.Video
Imports AForge.Video.DirectShow
Module functions
    Dim reader As MySqlDataReader
    Dim command As MySqlCommand
    Dim arrimage() As Byte
    Dim msstream As New System.IO.MemoryStream()
    Dim captureDevice As VideoCaptureDevice
    Dim captureDevices As FilterInfoCollection
    Dim currentFrame As Bitmap
   
    Function connection()
        Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=attendance_db")
        Return conn
    End Function
 

    Public Sub studentRecord()

        Try
            Dim connection As MySql.Data.MySqlClient.MySqlConnection = functions.connection

            Dim adapter As New MySqlDataAdapter("SELECT * FROM student_tab;", connection)
            Dim table As New DataTable()
            adapter.Fill(table)

            viewStudentRecord.viewingStudentRecord.Items.Clear()
            Dim sn As Integer = 1
            For Each row As DataRow In table.Rows
                Dim listItem As New ListViewItem((sn.ToString))
                listItem.SubItems.Add(row("studentId").ToString())
                listItem.SubItems.Add(row("fullName").ToString())
                listItem.SubItems.Add(row("emailAddress").ToString())
                listItem.SubItems.Add(row("phoneNumber").ToString())
                listItem.SubItems.Add(row("passport").ToString())
                listItem.SubItems.Add(row("createdTime").ToString())
                listItem.SubItems.Add(row("updatedTime").ToString())

                viewStudentRecord.viewingStudentRecord.Items.Add(listItem)
                sn = sn + 1
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub insertAdmin()
        Dim staffId = "staff" + Now.ToString("yyyyMMddss") & functions.countsId("staff")
        Try
            Dim connection = functions.connection
            connection.Open()

            Dim query As String = "INSERT INTO staff_tab ( staffId, roleId, statusId, fullName, emailAddress, phoneNumber,passport,createdTime, updatedTime) VALUES ( @staffId,@roleId, @statusId, @fullName, @emailAddress, @phoneNumber,@passport, @createdTime, @updatedTime)"
            command = New MySqlCommand(query, connection)

            command.Parameters.AddWithValue("@staffId", staffId)
            command.Parameters.AddWithValue("@roleId", adminRecordMain.rolecombobox.SelectedValue)
            command.Parameters.AddWithValue("@statusId", adminRecordMain.statuscombobox.SelectedValue)
            command.Parameters.AddWithValue("@fullName", adminRecordMain.fullnameTxt.Text)
            command.Parameters.AddWithValue("@emailAddress", adminRecordMain.emailTxt.Text)
            command.Parameters.AddWithValue("@phoneNumber", adminRecordMain.numberTxt.Text)
            command.Parameters.AddWithValue("@createdTime", Now)
            command.Parameters.AddWithValue("@updatedTime", Now)

            If adminRecordMain.pictureBox.Image IsNot Nothing Then
                ' Convert image to bytes
                Dim ms As New MemoryStream()
                adminRecordMain.pictureBox.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                Dim imgBytes As Byte() = ms.ToArray()

                ' Save to folder (optional)
                Dim folderPath As String = Path.Combine(Application.StartupPath, "CapturedImages")
                If Not Directory.Exists(folderPath) Then
                    Directory.CreateDirectory(folderPath)
                End If

                Dim filePath As String = Path.Combine(folderPath, adminRecordMain.fullnameTxt.Text.Replace(" ", "_") & ".jpg")
                adminRecordMain.pictureBox.Image.Save(filePath, Imaging.ImageFormat.Jpeg)
                command.Parameters.AddWithValue("@passport", imgBytes)



                MessageBox.Show("Image captured and saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No image to capture!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            Dim rowsAffected As Integer = command.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("USER RECORD ADDED SUCCESSFULLY", "Auto System Application", MessageBoxButtons.OK, MessageBoxIcon.Information)

                adminRecordMain.adminCount.Text = GetAdminCount()
                viewAdminRecord.viewAdminCount.Text = GetAdminCount()
                adminRecord()
                getStaffIds()
                dashBoard.totalAdmin.Text = GetAdminCount()

                adminFingerprint.Show()
                adminRecordMain.Close()

            Else
                MessageBox.Show("FAILED TO ADD USER RECORD", "Auto System Application", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("General Error: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            functions.connection.Close()
        End Try

    End Sub


    Public Sub getLoginDetails()
        Dim connection = functions.connection

        Dim email As String = adminLogin.emailTxt.Text.Trim()
        Dim password As String = adminLogin.passwordTxt.Text.Trim()
        ' Basic input validation 
        If email = "" Then
            MessageBox.Show("Please enter email.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf password = "" Then
            MessageBox.Show("Please enter password.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else
            Try
                connection.Open()
                ' Use parameterized query to prevent SQL injection 
                Dim query As String = ("SELECT fullName,passport FROM staff_tab WHERE emailAddress = @Email AND password = @Password")
                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Email", email)
                command.Parameters.AddWithValue("@Password", password)
                Dim reader As MySqlDataReader = command.ExecuteReader()
                If reader.Read Then
                    Dim fullName As String = reader("fullName").ToString()
                    MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dashBoard.Show()
                    adminLogin.Hide()
                    dashBoard.adminNameTxt.Text = "<b>" & fullName & "<b>"
                    arrimage = reader("passport")
                    msstream = New MemoryStream(arrimage)
                    dashBoard.adminPictureBox.Image = Image.FromStream(msstream)


                Else
                    ' Invalid credentials 
                    MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    reader.Close()
                End If

                connection.Close()
            Catch ex As Exception
                MessageBox.Show("Error during login: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


  

    Public Sub sendOTPToEmail()
        Dim connection = functions.connection
        Dim email As String = forgotPassword.emailTxt.Text.Trim()

        If email = "" Then
            MessageBox.Show("Please enter your registered email.", "Missing Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            connection.Open()

            ' === Check if email exists ===
            Dim query As String = "SELECT fullName FROM staff_tab WHERE emailAddress = @emailAddress"
            Dim command As New MySqlCommand(query, connection)
            command.Parameters.AddWithValue("@emailAddress", email)
            Dim reader As MySqlDataReader = command.ExecuteReader()

            If reader.Read() Then
                Dim fullName As String = reader("fullName").ToString()
                reader.Close()

                ' === Generate 6-digit OTP ===
                Dim otp As String = New Random().Next(100000, 999999).ToString()

                ' === Save OTP in database ===
                Dim updateCmd As New MySqlCommand("UPDATE staff_tab SET otp = @otp WHERE emailAddress = @emailAddress", connection)
                updateCmd.Parameters.AddWithValue("@otp", otp)
                updateCmd.Parameters.AddWithValue("@emailAddress", email)
                updateCmd.ExecuteNonQuery()

                settings.Show()
                forgotPassword.Hide()

                settings.htmlTxt.Text = "Dear <b>" & fullName & "</b>, an OTP has been sent to your registered <br>" &
                        "Email Address (" & email & ")."



            Else
                MessageBox.Show("Email not found in records.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            connection.Close()

        Catch ex As Exception
            MessageBox.Show("Error sending OTP: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub changePassword()
        Dim connection = functions.connection
        Dim otpInput As String = settings.otpTxt.Text.Trim()
        Dim newPass As String = settings.newPasswordTxt.Text.Trim()
        Dim confirmPass As String = settings.confirmPasswordTxt.Text.Trim()
        Dim email As String = forgotPassword.emailTxt.Text.Trim()

        If otpInput = "" Or newPass = "" Or confirmPass = "" Or email = "" Then
            MessageBox.Show("All fields are required.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If newPass <> confirmPass Then
            MessageBox.Show("Passwords do not match.", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using connection
                connection.Open()

                ' === Step 1: Get OTP from the database ===
                Dim getOtpCmd As New MySqlCommand("SELECT otp FROM staff_tab WHERE emailAddress=@Email", connection)
                getOtpCmd.Parameters.AddWithValue("@Email", email)

                Dim dbOtpObj As Object = getOtpCmd.ExecuteScalar()

                If dbOtpObj Is Nothing Then
                    MessageBox.Show("Email address not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim dbOtp As Integer = Convert.ToInt32(dbOtpObj)

                ' === Step 2: Compare OTP ===
                If dbOtp = Val(otpInput) Then

                    ' === Step 3: Update password and reset OTP ===
                    Dim updateCmd As New MySqlCommand("UPDATE staff_tab SET password=@Password, otp=0, updatedTime=NOW() WHERE emailAddress=@Email", connection)
                    updateCmd.Parameters.AddWithValue("@Password", newPass)
                    updateCmd.Parameters.AddWithValue("@Email", email)
                    updateCmd.ExecuteNonQuery()

                    MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    settings.Hide()
                    adminLogin.Show()
                Else
                    MessageBox.Show("Invalid OTP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("General error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub getStaffIds()
        Dim DT As New DataTable
        Dim connection = functions.connection

        connection.Open()
        command = New MySqlCommand(" SELECT staffId, fullName from staff_tab ", connection)
        DT.Load(command.ExecuteReader)
        connection.Close()

        Dim defaultRow As DataRow = DT.NewRow()
        defaultRow("staffId") = 0
        defaultRow("fullName") = "SELECT STAFF"

        DT.Rows.InsertAt(defaultRow, 0)

        adminRecordMain.adminCombobox.DataSource = DT
        adminRecordMain.adminCombobox.DisplayMember = "fullName"
        adminRecordMain.adminCombobox.ValueMember = "staffId"
        adminRecordMain.adminCombobox.SelectedValue = 0


    End Sub
    Public Sub loadAdminComboboxes()

        Try


            Dim roleTable As New DataTable()
            roleTable.Columns.Add("Value", GetType(Integer))
            roleTable.Columns.Add("Text", GetType(String))

            roleTable.Rows.Add(0, "Select role")
            roleTable.Rows.Add(1, "student")
            roleTable.Rows.Add(2, "Staff")
            roleTable.Rows.Add(3, "Admin")

            adminRecordMain.rolecombobox.DataSource = roleTable
            adminRecordMain.rolecombobox.DisplayMember = "Text"
            adminRecordMain.rolecombobox.ValueMember = "Value"
            adminRecordMain.rolecombobox.SelectedIndex = 0


            Dim statusTable As New DataTable()
            statusTable.Columns.Add("Value", GetType(Integer))
            statusTable.Columns.Add("Text", GetType(String))

            statusTable.Rows.Add(0, "Select status")
            statusTable.Rows.Add(1, "Active")
            statusTable.Rows.Add(2, "Suspended")

            adminRecordMain.statuscombobox.DataSource = statusTable
            adminRecordMain.statuscombobox.DisplayMember = "Text"
            adminRecordMain.statuscombobox.ValueMember = "Value"
            adminRecordMain.statuscombobox.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub adminRecord()
        Try
            Dim connection As MySql.Data.MySqlClient.MySqlConnection = functions.connection

            Dim adapter As New MySqlDataAdapter("SELECT * FROM staff_tab;", connection)
            Dim table As New DataTable()
            adapter.Fill(table)

            viewAdminRecord.viewingAdminRecord.Items.Clear()
            Dim sn As Integer = 1
            For Each row As DataRow In table.Rows
                Dim listItem As New ListViewItem((sn.ToString))
                listItem.SubItems.Add(row("staffId").ToString())
                listItem.SubItems.Add(row("fullName").ToString())
                listItem.SubItems.Add(row("emailAddress").ToString())
                listItem.SubItems.Add(row("phoneNumber").ToString())
                listItem.SubItems.Add(row("passport").ToString())
                listItem.SubItems.Add(row("createdTime").ToString())
                listItem.SubItems.Add(row("updatedTime").ToString())

                viewAdminRecord.viewingAdminRecord.Items.Add(listItem)
                sn = sn + 1
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Function GetAdminCount() As Integer
        Dim recordCount As Integer

        Dim connection = functions.connection
        Dim query As String

        query = "SELECT COUNT(*) FROM staff_tab"
        connection.Open()
        command = New MySqlCommand(query, connection)
        recordCount = Convert.ToInt32(command.ExecuteScalar())
        connection.Close()

        Return recordCount
    End Function
    Public Sub fetchAdmin()
        If adminRecordMain.adminCombobox.Text = "SELECT STAFF" Then
            MessageBox.Show("SELECT AN ACCOUNT", "Auto System Application", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                Dim connection = functions.connection
                connection.Open()
                command = New MySqlCommand("SELECT * FROM staff_tab WHERE staffId=@staffId", connection)
                command.Parameters.AddWithValue("@staffId", adminRecordMain.adminCombobox.SelectedValue)
                reader = command.ExecuteReader
                reader.Read()

                adminRecordMain.adminCombobox.Text = reader("staffId")
                adminRecordMain.fullnameTxt.Text = reader("fullName")
                adminRecordMain.emailTxt.Text = reader("emailAddress")
                adminRecordMain.numberTxt.Text = reader("phoneNumber")
                adminRecordMain.rolecombobox.SelectedValue = reader("roleId")
                adminRecordMain.statuscombobox.SelectedValue = reader("statusId")
                arrimage = reader("passport")
                msstream = New MemoryStream(arrimage)
                adminRecordMain.pictureBox.Image = Image.FromStream(msstream)

            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message)
            End Try
            connection.Close()
        End If
    End Sub
    Public Sub insertUser()
        Dim studentId = "student" + Now.ToString("yyyyMMddss") & functions.countsId("student")
        Try
            Dim connection = functions.connection
            connection.Open()

            Dim query As String = "INSERT INTO student_tab ( studentId, genderId, statusId, roleId, fullName, emailAddress, phoneNumber, programmeId, passport, createdTime, updatedTime) VALUES ( @studentId,@genderId, @statusId, @roleId, @fullName, @emailAddress, @phoneNumber, @programmeId, @passport, @createdTime, @updatedTime)"
            command = New MySqlCommand(query, connection)

            command.Parameters.AddWithValue("@studentId", studentId)
            command.Parameters.AddWithValue("@genderId", studentRecordMain.gendercombobox.SelectedValue)
            command.Parameters.AddWithValue("@statusId", studentRecordMain.statuscombobox.SelectedValue)
            command.Parameters.AddWithValue("@roleId", 1)
            command.Parameters.AddWithValue("@fullName", studentRecordMain.fullnameTxt.Text)
            command.Parameters.AddWithValue("@emailAddress", studentRecordMain.emailTxt.Text)
            command.Parameters.AddWithValue("@phoneNumber", studentRecordMain.numberTxt.Text)
            command.Parameters.AddWithValue("@programmeId", studentRecordMain.programmeCombobox.SelectedValue)
            command.Parameters.AddWithValue("@createdTime", Now)
            command.Parameters.AddWithValue("@updatedTime", Now)

            If studentRecordMain.pictureBox.Image IsNot Nothing Then
                ' Convert image to bytes
                Dim ms As New MemoryStream()
                studentRecordMain.pictureBox.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                Dim imgBytes As Byte() = ms.ToArray()

                ' Save to folder (optional)
                Dim folderPath As String = Path.Combine(Application.StartupPath, "CapturedImages")
                If Not Directory.Exists(folderPath) Then
                    Directory.CreateDirectory(folderPath)
                End If

                Dim filePath As String = Path.Combine(folderPath, studentRecordMain.fullnameTxt.Text.Replace(" ", "_") & ".jpg")
                studentRecordMain.pictureBox.Image.Save(filePath, Imaging.ImageFormat.Jpeg)
                command.Parameters.AddWithValue("@passport", imgBytes)



                MessageBox.Show("Image captured and saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No image to capture!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            Dim rowsAffected As Integer = command.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("USER RECORD ADDED SUCCESSFULLY", "Auto System Application", MessageBoxButtons.OK, MessageBoxIcon.Information)

                studentRecordMain.realCount.Text = GetRecordCount()
                viewStudentRecord.countNo.Text = GetRecordCount()
                studentRecord()
                getUserIds()
                dashBoard.totalStudent.Text = GetRecordCount()

                studentFingerprint.Show()
                studentRecordMain.Close()


            Else
                MessageBox.Show("FAILED TO ADD USER RECORD", "Auto System Application", MessageBoxButtons.OK, MessageBoxIcon.Error)



            End If

        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("General Error: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            functions.connection.Close()
        End Try

    End Sub
    Public Sub updateUser()
        Try
            Dim connection = functions.connection
            connection.Open()

            Dim query As String = "UPDATE student_tab SET fullName=@fullName, emailAddress=@emailAddress, phoneNumber=@phoneNumber, genderId=@genderId, statusId=@statusId, roleId=@roleId, programmeId=@programmeId, passport=@passport WHERE studentId=@studentId"


            command = New MySqlCommand(query, connection)


            command.Parameters.AddWithValue("@studentId", studentRecordMain.combobox.SelectedValue)
            command.Parameters.AddWithValue("@genderId", studentRecordMain.gendercombobox.SelectedValue)
            command.Parameters.AddWithValue("@statusId", studentRecordMain.statuscombobox.SelectedValue)
            command.Parameters.AddWithValue("@roleId", 1)
            command.Parameters.AddWithValue("@fullName", studentRecordMain.fullnameTxt.Text)
            command.Parameters.AddWithValue("@emailAddress", studentRecordMain.emailTxt.Text)
            command.Parameters.AddWithValue("@phoneNumber", studentRecordMain.numberTxt.Text)
            command.Parameters.AddWithValue("@programmeId", studentRecordMain.programmeCombobox.SelectedValue)
            command.Parameters.AddWithValue("@updatedTime", Now)


            If studentRecordMain.pictureBox.Image IsNot Nothing Then

                ' Convert to bytes
                Dim ms As New MemoryStream()
                studentRecordMain.pictureBox.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                Dim imgBytes As Byte() = ms.ToArray()


                Dim folderPath As String = Path.Combine(Application.StartupPath, "CapturedImages")
                If Not Directory.Exists(folderPath) Then Directory.CreateDirectory(folderPath)

                Dim filePath As String = Path.Combine(folderPath, studentRecordMain.fullnameTxt.Text.Replace(" ", "_") & ".jpg")
                studentRecordMain.pictureBox.Image.Save(filePath, Imaging.ImageFormat.Jpeg)

                command.Parameters.AddWithValue("@passport", imgBytes)
            Else

                command.Parameters.Add("@passport", MySqlDbType.Blob).Value = DBNull.Value
            End If


            Dim rowsAffected As Integer = command.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("USER RECORD UPDATED SUCCESSFULLY", "Auto System Application",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

                studentRecordMain.realCount.Text = GetRecordCount()
                viewStudentRecord.countNo.Text = GetRecordCount()
                studentRecord()
                getUserIds()

            Else
                MessageBox.Show("FAILED TO UPDATE USER RECORD", "Auto System Application",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("General Error: " & ex.Message, "System Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            functions.connection.Close()
        End Try
    End Sub

    Public Sub fetchUser()
        If studentRecordMain.combobox.Text = "SELECT STUDENT" Then
            MessageBox.Show("SELECT AN ACCOUNT", "Auto System Application", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                Dim connection = functions.connection
                connection.Open()
                command = New MySqlCommand("SELECT * FROM student_tab WHERE studentId=@studentId", connection)
                command.Parameters.AddWithValue("@studentId", studentRecordMain.combobox.SelectedValue)
                reader = command.ExecuteReader
                reader.Read()

                studentRecordMain.combobox.Text = reader("studentId")
                studentRecordMain.fullnameTxt.Text = reader("fullName")
                studentRecordMain.emailTxt.Text = reader("emailAddress")
                studentRecordMain.numberTxt.Text = reader("phoneNumber")
                studentRecordMain.gendercombobox.SelectedValue = reader("genderId")
                studentRecordMain.statuscombobox.SelectedValue = reader("statusId")
                studentRecordMain.programmeCombobox.SelectedValue = reader("programmeId")
                arrimage = reader("passport")
                msstream = New MemoryStream(arrimage)
                studentRecordMain.pictureBox.Image = Image.FromStream(msstream)

            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message)
            End Try
            connection.Close()
        End If
    End Sub

    Function countsId(ByVal countId As String)
        Dim connection = functions.connection

        connection.Open()
        command = New MySqlCommand("UPDATE counter_tab SET counterValue=counterValue+1 WHERE counterId=@counterId", connection)
        command.Parameters.AddWithValue("@counterId", countId)
        reader = command.ExecuteReader
        connection.Close()

        connection.Open()
        command = New MySqlCommand("SELECT counterValue FROM counter_tab WHERE counterId=@counterId", connection)
        command.Parameters.AddWithValue("@counterId", countId)
        reader = command.ExecuteReader
        reader.Read()
        Dim countValue = reader("counterValue")
        connection.Close()
        Return countValue
    End Function
    Function GetRecordCount() As Integer
        Dim recordCount As Integer

        Dim connection = functions.connection
        Dim query As String

        query = "SELECT COUNT(*) FROM student_tab"
        connection.Open()
        command = New MySqlCommand(query, connection)
        recordCount = Convert.ToInt32(command.ExecuteScalar())
        connection.Close()

        Return recordCount
    End Function
    Public Sub getUserIds()
        Dim DT As New DataTable
        Dim connection = functions.connection

        connection.Open()
        command = New MySqlCommand(" SELECT studentId, fullName from student_tab ", connection)
        DT.Load(command.ExecuteReader)
        connection.Close()

        Dim defaultRow As DataRow = DT.NewRow()
        defaultRow("studentId") = 0
        defaultRow("fullName") = "SELECT STUDENT"

        DT.Rows.InsertAt(defaultRow, 0)

        studentRecordMain.combobox.DataSource = DT
        studentRecordMain.combobox.DisplayMember = "fullName"
        studentRecordMain.combobox.ValueMember = "studentId"
        studentRecordMain.combobox.SelectedValue = 0


    End Sub

    Public Sub loadStudentComboboxes()

        Try


            Dim genderTable As New DataTable()
            genderTable.Columns.Add("Value", GetType(Integer))
            genderTable.Columns.Add("Text", GetType(String))

            genderTable.Rows.Add(0, "Select gender")
            genderTable.Rows.Add(1, "Female")
            genderTable.Rows.Add(2, "Male")
            genderTable.Rows.Add(3, "Other")

            studentRecordMain.gendercombobox.DataSource = genderTable
            studentRecordMain.gendercombobox.DisplayMember = "Text"
            studentRecordMain.gendercombobox.ValueMember = "Value"
            studentRecordMain.gendercombobox.SelectedIndex = 0


            Dim statusTable As New DataTable()
            statusTable.Columns.Add("Value", GetType(Integer))
            statusTable.Columns.Add("Text", GetType(String))

            statusTable.Rows.Add(0, "Select status")
            statusTable.Rows.Add(1, "Active")
            statusTable.Rows.Add(2, "Suspended")

            studentRecordMain.statuscombobox.DataSource = statusTable
            studentRecordMain.statuscombobox.DisplayMember = "Text"
            studentRecordMain.statuscombobox.ValueMember = "Value"
            studentRecordMain.statuscombobox.SelectedIndex = 0


            Dim programmeTable As New DataTable()
            programmeTable.Columns.Add("Value", GetType(Integer))
            programmeTable.Columns.Add("Text", GetType(String))

            programmeTable.Rows.Add(0, "Select programme")
            programmeTable.Rows.Add(1, "Diploma")
            programmeTable.Rows.Add(2, "Student Industrial Work Experience Scheme (SIWES)")
            programmeTable.Rows.Add(3, "Industrial Training (IT)")
            programmeTable.Rows.Add(4, "National Youth Service Corps (NYSC)")

            studentRecordMain.programmeCombobox.DataSource = programmeTable
            studentRecordMain.programmeCombobox.DisplayMember = "Text"
            studentRecordMain.programmeCombobox.ValueMember = "Value"
            studentRecordMain.programmeCombobox.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Function RegistrationemailCheckstudent(ByVal email As String)
        Dim connection = functions.connection

        connection.Open()
        command = New MySqlCommand("SELECT * FROM student_tab WHERE emailAddress=@emailAddress", connection)
        command.Parameters.AddWithValue("@emailAddress", email)
        reader = command.ExecuteReader
        Dim validateEmail = reader.Read()
        connection.Close()
        Return validateEmail
    End Function
    Function UpdateemailCheckstudent(ByVal email As String)
        Dim connection = functions.connection

        connection.Open()
        command = New MySqlCommand("SELECT * FROM student_tab WHERE emailAddress=@emailAddress AND studentId!=@studentId", connection)
        command.Parameters.AddWithValue("@emailAddress", email)
        command.Parameters.AddWithValue("@studentId", studentRecordMain.combobox.SelectedValue)
        reader = command.ExecuteReader
        Dim validateEmail = reader.Read()
        connection.Close()
        Return validateEmail
    End Function
    Function RegistrationemailCheckadmin(ByVal email As String)
        Dim connection = functions.connection

        connection.Open()
        command = New MySqlCommand("SELECT * FROM staff_tab WHERE emailAddress=@emailAddress", connection)
        command.Parameters.AddWithValue("@emailAddress", email)
        reader = command.ExecuteReader
        Dim validateEmail = reader.Read()
        connection.Close()
        Return validateEmail
    End Function
    Function UpdateemailCheckadmin(ByVal email As String)
        Dim connection = functions.connection

        connection.Open()
        command = New MySqlCommand("SELECT * FROM staff_tab WHERE emailAddress=@emailAddress AND staffId!=@staffId", connection)
        command.Parameters.AddWithValue("@emailAddress", email)
        command.Parameters.AddWithValue("@staffId", adminRecordMain.adminCombobox.SelectedValue)
        reader = command.ExecuteReader
        Dim validateEmail = reader.Read()
        connection.Close()
        Return validateEmail
    End Function
    Public Sub updateAdmin()
        Try
            Dim connection = functions.connection
            connection.Open()

            Dim query As String = "UPDATE staff_tab SET fullName=@fullName, emailAddress=@emailAddress, phoneNumber=@phoneNumber,  statusId=@statusId, roleId=@roleId,  passport=@passport WHERE staffId=@staffId"
             

            command = New MySqlCommand(query, connection)


            command.Parameters.AddWithValue("@staffId", adminRecordMain.adminCombobox.SelectedValue)
            command.Parameters.AddWithValue("@roleId", adminRecordMain.rolecombobox.SelectedValue)
            command.Parameters.AddWithValue("@statusId", adminRecordMain.statuscombobox.SelectedValue)
            command.Parameters.AddWithValue("@fullName", adminRecordMain.fullnameTxt.Text)
            command.Parameters.AddWithValue("@emailAddress", adminRecordMain.emailTxt.Text)
            command.Parameters.AddWithValue("@phoneNumber", adminRecordMain.numberTxt.Text)
            command.Parameters.AddWithValue("@updatedTime", Now)

            If adminRecordMain.pictureBox.Image IsNot Nothing Then


                Dim ms As New MemoryStream()
                adminRecordMain.pictureBox.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                Dim imgBytes As Byte() = ms.ToArray()


                Dim folderPath As String = Path.Combine(Application.StartupPath, "CapturedImages")
                If Not Directory.Exists(folderPath) Then
                    Directory.CreateDirectory(folderPath)
                End If

                Dim filePath As String = Path.Combine(folderPath, adminRecordMain.fullnameTxt.Text.Replace(" ", "_") & ".jpg")
                adminRecordMain.pictureBox.Image.Save(filePath, Imaging.ImageFormat.Jpeg)

                command.Parameters.AddWithValue("@passport", imgBytes)

            Else
                ' Do not overwrite passport — keep original in database
                command.Parameters.Add("@passport", MySqlDbType.Blob).Value = DBNull.Value
            End If


            Dim rowsAffected As Integer = command.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("ADMIN RECORD UPDATED SUCCESSFULLY", "Auto System Application", MessageBoxButtons.OK, MessageBoxIcon.Information)

                adminRecordMain.adminCount.Text = GetAdminCount()
                viewAdminRecord.viewAdminCount.Text = GetAdminCount()
                adminRecord()
                getStaffIds()

            Else
                MessageBox.Show("FAILED TO UPDATE ADMIN RECORD", "Auto System Application",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("General Error: " & ex.Message, "System Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            functions.connection.Close()
        End Try
    End Sub

End Module
