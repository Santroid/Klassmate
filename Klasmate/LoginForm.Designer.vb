<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.KlassmateLoginLabel = New System.Windows.Forms.Label()
        Me.RegisterLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.ForgotPasswordLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.EmailLoginTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordLoginTextBox = New System.Windows.Forms.TextBox()
        Me.LoginButton = New System.Windows.Forms.Button()
        Me.CancelLoginButton = New System.Windows.Forms.Button()
        Me.IDLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'KlassmateLoginLabel
        '
        Me.KlassmateLoginLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.KlassmateLoginLabel.AutoSize = True
        Me.KlassmateLoginLabel.Font = New System.Drawing.Font("Microsoft Tai Le", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KlassmateLoginLabel.ForeColor = System.Drawing.Color.Blue
        Me.KlassmateLoginLabel.Location = New System.Drawing.Point(90, 9)
        Me.KlassmateLoginLabel.Name = "KlassmateLoginLabel"
        Me.KlassmateLoginLabel.Size = New System.Drawing.Size(110, 27)
        Me.KlassmateLoginLabel.TabIndex = 0
        Me.KlassmateLoginLabel.Text = "Klassmate"
        Me.KlassmateLoginLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'RegisterLinkLabel
        '
        Me.RegisterLinkLabel.AutoSize = True
        Me.RegisterLinkLabel.Location = New System.Drawing.Point(43, 136)
        Me.RegisterLinkLabel.Name = "RegisterLinkLabel"
        Me.RegisterLinkLabel.Size = New System.Drawing.Size(67, 26)
        Me.RegisterLinkLabel.TabIndex = 3
        Me.RegisterLinkLabel.TabStop = True
        Me.RegisterLinkLabel.Text = "Eres nuevo?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Registrate"
        Me.RegisterLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ForgotPasswordLinkLabel
        '
        Me.ForgotPasswordLinkLabel.AutoSize = True
        Me.ForgotPasswordLinkLabel.Location = New System.Drawing.Point(134, 136)
        Me.ForgotPasswordLinkLabel.Name = "ForgotPasswordLinkLabel"
        Me.ForgotPasswordLinkLabel.Size = New System.Drawing.Size(113, 13)
        Me.ForgotPasswordLinkLabel.TabIndex = 4
        Me.ForgotPasswordLinkLabel.TabStop = True
        Me.ForgotPasswordLinkLabel.Text = "Olvido su contraseña?"
        Me.ForgotPasswordLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'EmailLoginTextBox
        '
        Me.EmailLoginTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailLoginTextBox.Location = New System.Drawing.Point(46, 59)
        Me.EmailLoginTextBox.Name = "EmailLoginTextBox"
        Me.EmailLoginTextBox.Size = New System.Drawing.Size(195, 20)
        Me.EmailLoginTextBox.TabIndex = 5
        Me.EmailLoginTextBox.Text = "Correo"
        '
        'PasswordLoginTextBox
        '
        Me.PasswordLoginTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLoginTextBox.Location = New System.Drawing.Point(46, 97)
        Me.PasswordLoginTextBox.Name = "PasswordLoginTextBox"
        Me.PasswordLoginTextBox.Size = New System.Drawing.Size(195, 20)
        Me.PasswordLoginTextBox.TabIndex = 6
        Me.PasswordLoginTextBox.Text = "Contraseña"
        '
        'LoginButton
        '
        Me.LoginButton.Location = New System.Drawing.Point(46, 186)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(90, 34)
        Me.LoginButton.TabIndex = 7
        Me.LoginButton.Text = "Acceder"
        Me.LoginButton.UseVisualStyleBackColor = True
        '
        'CancelLoginButton
        '
        Me.CancelLoginButton.Location = New System.Drawing.Point(151, 186)
        Me.CancelLoginButton.Name = "CancelLoginButton"
        Me.CancelLoginButton.Size = New System.Drawing.Size(90, 34)
        Me.CancelLoginButton.TabIndex = 8
        Me.CancelLoginButton.Text = "Cancelar"
        Me.CancelLoginButton.UseVisualStyleBackColor = True
        '
        'IDLabel
        '
        Me.IDLabel.AutoSize = True
        Me.IDLabel.Location = New System.Drawing.Point(140, 236)
        Me.IDLabel.Name = "IDLabel"
        Me.IDLabel.Size = New System.Drawing.Size(50, 13)
        Me.IDLabel.TabIndex = 9
        Me.IDLabel.Text = "Label_ID"
        Me.IDLabel.Visible = False
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 255)
        Me.Controls.Add(Me.IDLabel)
        Me.Controls.Add(Me.CancelLoginButton)
        Me.Controls.Add(Me.LoginButton)
        Me.Controls.Add(Me.PasswordLoginTextBox)
        Me.Controls.Add(Me.EmailLoginTextBox)
        Me.Controls.Add(Me.ForgotPasswordLinkLabel)
        Me.Controls.Add(Me.RegisterLinkLabel)
        Me.Controls.Add(Me.KlassmateLoginLabel)
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Klassmate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents KlassmateLoginLabel As Label
    Friend WithEvents RegisterLinkLabel As LinkLabel
    Friend WithEvents ForgotPasswordLinkLabel As LinkLabel
    Friend WithEvents EmailLoginTextBox As TextBox
    Friend WithEvents PasswordLoginTextBox As TextBox
    Friend WithEvents LoginButton As Button
    Friend WithEvents CancelLoginButton As Button
    Friend WithEvents IDLabel As Label
End Class
