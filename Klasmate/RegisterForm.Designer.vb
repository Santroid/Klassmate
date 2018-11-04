<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegisterForm
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
        Me.RegisterLabel = New System.Windows.Forms.Label()
        Me.RegisterButton = New System.Windows.Forms.Button()
        Me.CancelRegisterButton = New System.Windows.Forms.Button()
        Me.NameRegisterTextBox = New System.Windows.Forms.TextBox()
        Me.EmailRegisterTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordRegisterTextBox = New System.Windows.Forms.TextBox()
        Me.Password2RegisterTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.EmailErrorLabel = New System.Windows.Forms.Label()
        Me.PasswordErrorLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'RegisterLabel
        '
        Me.RegisterLabel.AutoSize = True
        Me.RegisterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegisterLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RegisterLabel.Location = New System.Drawing.Point(96, 9)
        Me.RegisterLabel.Name = "RegisterLabel"
        Me.RegisterLabel.Size = New System.Drawing.Size(100, 25)
        Me.RegisterLabel.TabIndex = 0
        Me.RegisterLabel.Text = "Registro"
        '
        'RegisterButton
        '
        Me.RegisterButton.Location = New System.Drawing.Point(53, 342)
        Me.RegisterButton.Name = "RegisterButton"
        Me.RegisterButton.Size = New System.Drawing.Size(75, 23)
        Me.RegisterButton.TabIndex = 5
        Me.RegisterButton.Text = "Registrar"
        Me.RegisterButton.UseVisualStyleBackColor = True
        '
        'CancelRegisterButton
        '
        Me.CancelRegisterButton.Location = New System.Drawing.Point(156, 342)
        Me.CancelRegisterButton.Name = "CancelRegisterButton"
        Me.CancelRegisterButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelRegisterButton.TabIndex = 6
        Me.CancelRegisterButton.Text = "Cancelar"
        Me.CancelRegisterButton.UseVisualStyleBackColor = True
        '
        'NameRegisterTextBox
        '
        Me.NameRegisterTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameRegisterTextBox.Location = New System.Drawing.Point(53, 81)
        Me.NameRegisterTextBox.Multiline = True
        Me.NameRegisterTextBox.Name = "NameRegisterTextBox"
        Me.NameRegisterTextBox.Size = New System.Drawing.Size(178, 20)
        Me.NameRegisterTextBox.TabIndex = 7
        '
        'EmailRegisterTextBox
        '
        Me.EmailRegisterTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailRegisterTextBox.Location = New System.Drawing.Point(53, 148)
        Me.EmailRegisterTextBox.Name = "EmailRegisterTextBox"
        Me.EmailRegisterTextBox.Size = New System.Drawing.Size(178, 20)
        Me.EmailRegisterTextBox.TabIndex = 8
        '
        'PasswordRegisterTextBox
        '
        Me.PasswordRegisterTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordRegisterTextBox.Location = New System.Drawing.Point(53, 222)
        Me.PasswordRegisterTextBox.Name = "PasswordRegisterTextBox"
        Me.PasswordRegisterTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordRegisterTextBox.Size = New System.Drawing.Size(178, 20)
        Me.PasswordRegisterTextBox.TabIndex = 9
        Me.PasswordRegisterTextBox.UseSystemPasswordChar = True
        '
        'Password2RegisterTextBox
        '
        Me.Password2RegisterTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Password2RegisterTextBox.Location = New System.Drawing.Point(53, 292)
        Me.Password2RegisterTextBox.Name = "Password2RegisterTextBox"
        Me.Password2RegisterTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Password2RegisterTextBox.Size = New System.Drawing.Size(178, 20)
        Me.Password2RegisterTextBox.TabIndex = 10
        Me.Password2RegisterTextBox.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(50, 273)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Repetir Contraseña"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(50, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Contraseña"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(50, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Correo"
        '
        'EmailErrorLabel
        '
        Me.EmailErrorLabel.AutoSize = True
        Me.EmailErrorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailErrorLabel.ForeColor = System.Drawing.Color.Red
        Me.EmailErrorLabel.Location = New System.Drawing.Point(53, 171)
        Me.EmailErrorLabel.Name = "EmailErrorLabel"
        Me.EmailErrorLabel.Size = New System.Drawing.Size(179, 13)
        Me.EmailErrorLabel.TabIndex = 15
        Me.EmailErrorLabel.Text = "¡El formato de correo no es correcto!"
        Me.EmailErrorLabel.Visible = False
        '
        'PasswordErrorLabel
        '
        Me.PasswordErrorLabel.AutoSize = True
        Me.PasswordErrorLabel.ForeColor = System.Drawing.Color.Red
        Me.PasswordErrorLabel.Location = New System.Drawing.Point(53, 315)
        Me.PasswordErrorLabel.Name = "PasswordErrorLabel"
        Me.PasswordErrorLabel.Size = New System.Drawing.Size(228, 13)
        Me.PasswordErrorLabel.TabIndex = 17
        Me.PasswordErrorLabel.Text = "¡Las contraseñenas ingresadas no son iguales!"
        Me.PasswordErrorLabel.Visible = False
        '
        'RegisterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 412)
        Me.Controls.Add(Me.PasswordErrorLabel)
        Me.Controls.Add(Me.EmailErrorLabel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Password2RegisterTextBox)
        Me.Controls.Add(Me.PasswordRegisterTextBox)
        Me.Controls.Add(Me.EmailRegisterTextBox)
        Me.Controls.Add(Me.NameRegisterTextBox)
        Me.Controls.Add(Me.CancelRegisterButton)
        Me.Controls.Add(Me.RegisterButton)
        Me.Controls.Add(Me.RegisterLabel)
        Me.Name = "RegisterForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Klassmate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RegisterLabel As Label
    Friend WithEvents RegisterButton As Button
    Friend WithEvents CancelRegisterButton As Button
    Friend WithEvents NameRegisterTextBox As TextBox
    Friend WithEvents EmailRegisterTextBox As TextBox
    Friend WithEvents PasswordRegisterTextBox As TextBox
    Friend WithEvents Password2RegisterTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents EmailErrorLabel As Label
    Friend WithEvents PasswordErrorLabel As Label
End Class
