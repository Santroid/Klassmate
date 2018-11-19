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
        Me.RegisterLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.ForgotPasswordLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.EmailLoginTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordLoginTextBox = New System.Windows.Forms.TextBox()
        Me.LoginButton = New System.Windows.Forms.Button()
        Me.CancelLoginButton = New System.Windows.Forms.Button()
        Me.IDLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HWCounterLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'RegisterLinkLabel
        '
        Me.RegisterLinkLabel.AutoSize = True
        Me.RegisterLinkLabel.Location = New System.Drawing.Point(42, 186)
        Me.RegisterLinkLabel.Name = "RegisterLinkLabel"
        Me.RegisterLinkLabel.Size = New System.Drawing.Size(64, 26)
        Me.RegisterLinkLabel.TabIndex = 3
        Me.RegisterLinkLabel.TabStop = True
        Me.RegisterLinkLabel.Text = "¿Es nuevo?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Regístrese"
        Me.RegisterLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ForgotPasswordLinkLabel
        '
        Me.ForgotPasswordLinkLabel.AutoSize = True
        Me.ForgotPasswordLinkLabel.Location = New System.Drawing.Point(133, 186)
        Me.ForgotPasswordLinkLabel.Name = "ForgotPasswordLinkLabel"
        Me.ForgotPasswordLinkLabel.Size = New System.Drawing.Size(119, 13)
        Me.ForgotPasswordLinkLabel.TabIndex = 4
        Me.ForgotPasswordLinkLabel.TabStop = True
        Me.ForgotPasswordLinkLabel.Text = "¿Olvidó su contraseña?"
        Me.ForgotPasswordLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'EmailLoginTextBox
        '
        Me.EmailLoginTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailLoginTextBox.Location = New System.Drawing.Point(45, 109)
        Me.EmailLoginTextBox.Name = "EmailLoginTextBox"
        Me.EmailLoginTextBox.Size = New System.Drawing.Size(195, 20)
        Me.EmailLoginTextBox.TabIndex = 5
        Me.EmailLoginTextBox.Text = "Correo"
        '
        'PasswordLoginTextBox
        '
        Me.PasswordLoginTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLoginTextBox.Location = New System.Drawing.Point(45, 147)
        Me.PasswordLoginTextBox.Name = "PasswordLoginTextBox"
        Me.PasswordLoginTextBox.Size = New System.Drawing.Size(195, 20)
        Me.PasswordLoginTextBox.TabIndex = 6
        Me.PasswordLoginTextBox.Text = "Contraseña"
        '
        'LoginButton
        '
        Me.LoginButton.Location = New System.Drawing.Point(45, 236)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(90, 34)
        Me.LoginButton.TabIndex = 7
        Me.LoginButton.Text = "Acceder"
        Me.LoginButton.UseVisualStyleBackColor = True
        '
        'CancelLoginButton
        '
        Me.CancelLoginButton.Location = New System.Drawing.Point(150, 236)
        Me.CancelLoginButton.Name = "CancelLoginButton"
        Me.CancelLoginButton.Size = New System.Drawing.Size(90, 34)
        Me.CancelLoginButton.TabIndex = 8
        Me.CancelLoginButton.Text = "Limpiar"
        Me.CancelLoginButton.UseVisualStyleBackColor = True
        '
        'IDLabel
        '
        Me.IDLabel.AutoSize = True
        Me.IDLabel.Location = New System.Drawing.Point(139, 286)
        Me.IDLabel.Name = "IDLabel"
        Me.IDLabel.Size = New System.Drawing.Size(50, 13)
        Me.IDLabel.TabIndex = 9
        Me.IDLabel.Text = "Label_ID"
        Me.IDLabel.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(211, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 39)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "ate"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(72, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 39)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "lass"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Castellar", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LimeGreen
        Me.Label2.Location = New System.Drawing.Point(134, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 77)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "M"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Castellar", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 77)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "K"
        '
        'HWCounterLabel
        '
        Me.HWCounterLabel.AutoSize = True
        Me.HWCounterLabel.Location = New System.Drawing.Point(42, 286)
        Me.HWCounterLabel.Name = "HWCounterLabel"
        Me.HWCounterLabel.Size = New System.Drawing.Size(89, 13)
        Me.HWCounterLabel.TabIndex = 14
        Me.HWCounterLabel.Text = "HWCounterLabel"
        Me.HWCounterLabel.Visible = False
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 319)
        Me.Controls.Add(Me.HWCounterLabel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.IDLabel)
        Me.Controls.Add(Me.CancelLoginButton)
        Me.Controls.Add(Me.LoginButton)
        Me.Controls.Add(Me.PasswordLoginTextBox)
        Me.Controls.Add(Me.EmailLoginTextBox)
        Me.Controls.Add(Me.ForgotPasswordLinkLabel)
        Me.Controls.Add(Me.RegisterLinkLabel)
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Klassmate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RegisterLinkLabel As LinkLabel
    Friend WithEvents ForgotPasswordLinkLabel As LinkLabel
    Friend WithEvents EmailLoginTextBox As TextBox
    Friend WithEvents PasswordLoginTextBox As TextBox
    Friend WithEvents LoginButton As Button
    Friend WithEvents CancelLoginButton As Button
    Friend WithEvents IDLabel As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents HWCounterLabel As Label
End Class
