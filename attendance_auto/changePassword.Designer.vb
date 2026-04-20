<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class changePassword
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.closeBtn = New Guna.UI2.WinForms.Guna2CircleButton()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Guna2GroupBox1 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.changePasswordBtn = New Guna.UI2.WinForms.Guna2Button()
        Me.confirmPasswordTxt = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.newPasswordTxt = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.oldPasswordTxt = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.closeBtn)
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel2)
        Me.Guna2Panel1.Controls.Add(Me.Guna2PictureBox1)
        Me.Guna2Panel1.Location = New System.Drawing.Point(-2, -1)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.ShadowDecoration.Parent = Me.Guna2Panel1
        Me.Guna2Panel1.Size = New System.Drawing.Size(482, 46)
        Me.Guna2Panel1.TabIndex = 2
        '
        'closeBtn
        '
        Me.closeBtn.CheckedState.Parent = Me.closeBtn
        Me.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.closeBtn.CustomImages.Parent = Me.closeBtn
        Me.closeBtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.closeBtn.Font = New System.Drawing.Font("Segoe UI Emoji", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.HoverState.Parent = Me.closeBtn
        Me.closeBtn.Location = New System.Drawing.Point(434, 2)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.closeBtn.ShadowDecoration.Parent = Me.closeBtn
        Me.closeBtn.Size = New System.Drawing.Size(41, 42)
        Me.closeBtn.TabIndex = 16
        Me.closeBtn.Text = "X"
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Segoe UI Emoji", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(53, 11)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(122, 19)
        Me.Guna2HtmlLabel2.TabIndex = 4
        Me.Guna2HtmlLabel2.Text = "Change Password"
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.Image = Global.attendance_auto.My.Resources.Resources.IMG_20250815_WA0053
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.ShadowDecoration.Parent = Me.Guna2PictureBox1
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(40, 46)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox1.TabIndex = 3
        Me.Guna2PictureBox1.TabStop = False
        '
        'Guna2GroupBox1
        '
        Me.Guna2GroupBox1.Controls.Add(Me.changePasswordBtn)
        Me.Guna2GroupBox1.Controls.Add(Me.confirmPasswordTxt)
        Me.Guna2GroupBox1.Controls.Add(Me.Guna2HtmlLabel3)
        Me.Guna2GroupBox1.Controls.Add(Me.newPasswordTxt)
        Me.Guna2GroupBox1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Guna2GroupBox1.Controls.Add(Me.oldPasswordTxt)
        Me.Guna2GroupBox1.Controls.Add(Me.Guna2HtmlLabel4)
        Me.Guna2GroupBox1.Font = New System.Drawing.Font("Segoe UI Emoji", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.Guna2GroupBox1.Location = New System.Drawing.Point(17, 59)
        Me.Guna2GroupBox1.Name = "Guna2GroupBox1"
        Me.Guna2GroupBox1.ShadowDecoration.Parent = Me.Guna2GroupBox1
        Me.Guna2GroupBox1.Size = New System.Drawing.Size(440, 321)
        Me.Guna2GroupBox1.TabIndex = 3
        Me.Guna2GroupBox1.Text = "ADMIN"
        '
        'changePasswordBtn
        '
        Me.changePasswordBtn.BorderRadius = 5
        Me.changePasswordBtn.CheckedState.Parent = Me.changePasswordBtn
        Me.changePasswordBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.changePasswordBtn.CustomImages.Parent = Me.changePasswordBtn
        Me.changePasswordBtn.FillColor = System.Drawing.Color.CornflowerBlue
        Me.changePasswordBtn.Font = New System.Drawing.Font("Segoe UI Emoji", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.changePasswordBtn.ForeColor = System.Drawing.Color.White
        Me.changePasswordBtn.HoverState.Parent = Me.changePasswordBtn
        Me.changePasswordBtn.Location = New System.Drawing.Point(268, 272)
        Me.changePasswordBtn.Name = "changePasswordBtn"
        Me.changePasswordBtn.ShadowDecoration.Parent = Me.changePasswordBtn
        Me.changePasswordBtn.Size = New System.Drawing.Size(154, 37)
        Me.changePasswordBtn.TabIndex = 23
        Me.changePasswordBtn.Text = "CHANGE PASSWORD"
        '
        'confirmPasswordTxt
        '
        Me.confirmPasswordTxt.BackColor = System.Drawing.Color.White
        Me.confirmPasswordTxt.BorderRadius = 5
        Me.confirmPasswordTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.confirmPasswordTxt.DefaultText = ""
        Me.confirmPasswordTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.confirmPasswordTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.confirmPasswordTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.confirmPasswordTxt.DisabledState.Parent = Me.confirmPasswordTxt
        Me.confirmPasswordTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.confirmPasswordTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.confirmPasswordTxt.FocusedState.Parent = Me.confirmPasswordTxt
        Me.confirmPasswordTxt.ForeColor = System.Drawing.Color.Black
        Me.confirmPasswordTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.confirmPasswordTxt.HoverState.Parent = Me.confirmPasswordTxt
        Me.confirmPasswordTxt.Location = New System.Drawing.Point(15, 225)
        Me.confirmPasswordTxt.Margin = New System.Windows.Forms.Padding(9, 2, 9, 2)
        Me.confirmPasswordTxt.Name = "confirmPasswordTxt"
        Me.confirmPasswordTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.confirmPasswordTxt.PlaceholderText = "CONFIRM PASSWORD"
        Me.confirmPasswordTxt.SelectedText = ""
        Me.confirmPasswordTxt.ShadowDecoration.Parent = Me.confirmPasswordTxt
        Me.confirmPasswordTxt.Size = New System.Drawing.Size(407, 42)
        Me.confirmPasswordTxt.TabIndex = 20
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Segoe UI Emoji", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(15, 208)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(132, 17)
        Me.Guna2HtmlLabel3.TabIndex = 19
        Me.Guna2HtmlLabel3.Text = "CONFIRM PASSWORD"
        '
        'newPasswordTxt
        '
        Me.newPasswordTxt.BackColor = System.Drawing.Color.White
        Me.newPasswordTxt.BorderRadius = 5
        Me.newPasswordTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.newPasswordTxt.DefaultText = ""
        Me.newPasswordTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.newPasswordTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.newPasswordTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.newPasswordTxt.DisabledState.Parent = Me.newPasswordTxt
        Me.newPasswordTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.newPasswordTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.newPasswordTxt.FocusedState.Parent = Me.newPasswordTxt
        Me.newPasswordTxt.ForeColor = System.Drawing.Color.Black
        Me.newPasswordTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.newPasswordTxt.HoverState.Parent = Me.newPasswordTxt
        Me.newPasswordTxt.Location = New System.Drawing.Point(15, 149)
        Me.newPasswordTxt.Margin = New System.Windows.Forms.Padding(7, 2, 7, 2)
        Me.newPasswordTxt.Name = "newPasswordTxt"
        Me.newPasswordTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.newPasswordTxt.PlaceholderText = "ENTER NEW PASSWORD"
        Me.newPasswordTxt.SelectedText = ""
        Me.newPasswordTxt.ShadowDecoration.Parent = Me.newPasswordTxt
        Me.newPasswordTxt.Size = New System.Drawing.Size(407, 42)
        Me.newPasswordTxt.TabIndex = 18
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Emoji", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(15, 132)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(103, 17)
        Me.Guna2HtmlLabel1.TabIndex = 17
        Me.Guna2HtmlLabel1.Text = "NEW PASSWORD"
        '
        'oldPasswordTxt
        '
        Me.oldPasswordTxt.BackColor = System.Drawing.Color.White
        Me.oldPasswordTxt.BorderRadius = 5
        Me.oldPasswordTxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.oldPasswordTxt.DefaultText = ""
        Me.oldPasswordTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.oldPasswordTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.oldPasswordTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.oldPasswordTxt.DisabledState.Parent = Me.oldPasswordTxt
        Me.oldPasswordTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.oldPasswordTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.oldPasswordTxt.FocusedState.Parent = Me.oldPasswordTxt
        Me.oldPasswordTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.oldPasswordTxt.HoverState.Parent = Me.oldPasswordTxt
        Me.oldPasswordTxt.Location = New System.Drawing.Point(15, 74)
        Me.oldPasswordTxt.Margin = New System.Windows.Forms.Padding(5, 2, 5, 2)
        Me.oldPasswordTxt.Name = "oldPasswordTxt"
        Me.oldPasswordTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.oldPasswordTxt.PlaceholderForeColor = System.Drawing.Color.Black
        Me.oldPasswordTxt.PlaceholderText = "ENTER OLD PASSWORD"
        Me.oldPasswordTxt.SelectedText = ""
        Me.oldPasswordTxt.ShadowDecoration.Parent = Me.oldPasswordTxt
        Me.oldPasswordTxt.Size = New System.Drawing.Size(407, 42)
        Me.oldPasswordTxt.TabIndex = 16
        '
        'Guna2HtmlLabel4
        '
        Me.Guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel4.Font = New System.Drawing.Font("Segoe UI Emoji", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel4.Location = New System.Drawing.Point(15, 57)
        Me.Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Me.Guna2HtmlLabel4.Size = New System.Drawing.Size(100, 17)
        Me.Guna2HtmlLabel4.TabIndex = 15
        Me.Guna2HtmlLabel4.Text = "OLD PASSWORD"
        '
        'changePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 396)
        Me.Controls.Add(Me.Guna2GroupBox1)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "changePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "changePassword"
        Me.TopMost = True
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2GroupBox1.ResumeLayout(False)
        Me.Guna2GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents closeBtn As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2GroupBox1 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents oldPasswordTxt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents confirmPasswordTxt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents newPasswordTxt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents changePasswordBtn As Guna.UI2.WinForms.Guna2Button
End Class
