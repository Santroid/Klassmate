<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfirmationForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SiConfirmaButton = New System.Windows.Forms.Button()
        Me.NoConfirmaButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'SiConfirmaButton
        '
        Me.SiConfirmaButton.Location = New System.Drawing.Point(29, 151)
        Me.SiConfirmaButton.Name = "SiConfirmaButton"
        Me.SiConfirmaButton.Size = New System.Drawing.Size(128, 31)
        Me.SiConfirmaButton.TabIndex = 0
        Me.SiConfirmaButton.Text = "Si"
        Me.SiConfirmaButton.UseVisualStyleBackColor = True
        '
        'NoConfirmaButton
        '
        Me.NoConfirmaButton.Location = New System.Drawing.Point(215, 151)
        Me.NoConfirmaButton.Name = "NoConfirmaButton"
        Me.NoConfirmaButton.Size = New System.Drawing.Size(128, 31)
        Me.NoConfirmaButton.TabIndex = 1
        Me.NoConfirmaButton.Text = "No"
        Me.NoConfirmaButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(321, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "¿Esta seguro que desea continuar?"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(317, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Si elimina el acceso a su cuenta, no podra volver"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(278, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "a usarla y se eliminara toda su informacion"
        '
        'ConfirmationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 219)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NoConfirmaButton)
        Me.Controls.Add(Me.SiConfirmaButton)
        Me.Name = "ConfirmationForm"
        Me.Text = "ConfirmationForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SiConfirmaButton As Button
    Friend WithEvents NoConfirmaButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
