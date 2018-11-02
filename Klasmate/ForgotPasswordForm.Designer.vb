<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForgotPasswordForm
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
        Me.EmailForgotPassTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SendNewPassButton = New System.Windows.Forms.Button()
        Me.CancelForgotPassButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'EmailForgotPassTextBox
        '
        Me.EmailForgotPassTextBox.Location = New System.Drawing.Point(71, 99)
        Me.EmailForgotPassTextBox.Name = "EmailForgotPassTextBox"
        Me.EmailForgotPassTextBox.Size = New System.Drawing.Size(156, 20)
        Me.EmailForgotPassTextBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(293, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Si olvido su contraseña, una nueva se le enviara a su correo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(22, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(314, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Recuperacion de contraseña"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(71, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Correo:"
        '
        'SendNewPassButton
        '
        Me.SendNewPassButton.Location = New System.Drawing.Point(71, 135)
        Me.SendNewPassButton.Name = "SendNewPassButton"
        Me.SendNewPassButton.Size = New System.Drawing.Size(75, 23)
        Me.SendNewPassButton.TabIndex = 4
        Me.SendNewPassButton.Text = "Enviar"
        Me.SendNewPassButton.UseVisualStyleBackColor = True
        '
        'CancelForgotPassButton
        '
        Me.CancelForgotPassButton.Location = New System.Drawing.Point(152, 135)
        Me.CancelForgotPassButton.Name = "CancelForgotPassButton"
        Me.CancelForgotPassButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelForgotPassButton.TabIndex = 5
        Me.CancelForgotPassButton.Text = "Cancelar"
        Me.CancelForgotPassButton.UseVisualStyleBackColor = True
        '
        'ForgotPasswordForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 206)
        Me.Controls.Add(Me.CancelForgotPassButton)
        Me.Controls.Add(Me.SendNewPassButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.EmailForgotPassTextBox)
        Me.Name = "ForgotPasswordForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Klassmate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EmailForgotPassTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SendNewPassButton As Button
    Friend WithEvents CancelForgotPassButton As Button
End Class
