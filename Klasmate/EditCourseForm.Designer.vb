﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditCourseForm
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
        Me.EditCourseComboBox = New System.Windows.Forms.ComboBox()
        Me.IdUserLabel = New System.Windows.Forms.Label()
        Me.DTLabel = New System.Windows.Forms.Label()
        Me.DTDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.JIDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.VILabel = New System.Windows.Forms.Label()
        Me.VIDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.SILabel = New System.Windows.Forms.Label()
        Me.SIDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.MTLabel = New System.Windows.Forms.Label()
        Me.MTDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.KTLabel = New System.Windows.Forms.Label()
        Me.KTDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.LTLabel = New System.Windows.Forms.Label()
        Me.LTDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.DILabel = New System.Windows.Forms.Label()
        Me.DIDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.JTLabel = New System.Windows.Forms.Label()
        Me.JTDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.VTLabel = New System.Windows.Forms.Label()
        Me.VTDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.STLabel = New System.Windows.Forms.Label()
        Me.STDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.MILabel = New System.Windows.Forms.Label()
        Me.MIDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.KILabel = New System.Windows.Forms.Label()
        Me.KIDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.LILabel = New System.Windows.Forms.Label()
        Me.LIDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.CancelECFButton = New System.Windows.Forms.Button()
        Me.DeleteCourseButton = New System.Windows.Forms.Button()
        Me.SaveCourseButton = New System.Windows.Forms.Button()
        Me.ColorCoursSRComboBox = New System.Windows.Forms.ComboBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NameCoursSRTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DayCoursSRCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'EditCourseComboBox
        '
        Me.EditCourseComboBox.FormattingEnabled = True
        Me.EditCourseComboBox.Location = New System.Drawing.Point(214, 15)
        Me.EditCourseComboBox.Margin = New System.Windows.Forms.Padding(2)
        Me.EditCourseComboBox.Name = "EditCourseComboBox"
        Me.EditCourseComboBox.Size = New System.Drawing.Size(174, 21)
        Me.EditCourseComboBox.TabIndex = 198
        '
        'IdUserLabel
        '
        Me.IdUserLabel.AutoSize = True
        Me.IdUserLabel.Location = New System.Drawing.Point(141, 39)
        Me.IdUserLabel.Name = "IdUserLabel"
        Me.IdUserLabel.Size = New System.Drawing.Size(38, 13)
        Me.IdUserLabel.TabIndex = 197
        Me.IdUserLabel.Text = "IdUser"
        Me.IdUserLabel.Visible = False
        '
        'DTLabel
        '
        Me.DTLabel.AutoSize = True
        Me.DTLabel.Enabled = False
        Me.DTLabel.Location = New System.Drawing.Point(406, 162)
        Me.DTLabel.Name = "DTLabel"
        Me.DTLabel.Size = New System.Drawing.Size(28, 13)
        Me.DTLabel.TabIndex = 196
        Me.DTLabel.Text = "D.T."
        '
        'DTDateTimePicker
        '
        Me.DTDateTimePicker.Enabled = False
        Me.DTDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTDateTimePicker.Location = New System.Drawing.Point(436, 160)
        Me.DTDateTimePicker.Name = "DTDateTimePicker"
        Me.DTDateTimePicker.ShowUpDown = True
        Me.DTDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.DTDateTimePicker.TabIndex = 195
        Me.DTDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'JIDateTimePicker
        '
        Me.JIDateTimePicker.Enabled = False
        Me.JIDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.JIDateTimePicker.Location = New System.Drawing.Point(36, 167)
        Me.JIDateTimePicker.Name = "JIDateTimePicker"
        Me.JIDateTimePicker.ShowUpDown = True
        Me.JIDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.JIDateTimePicker.TabIndex = 194
        Me.JIDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'VILabel
        '
        Me.VILabel.AutoSize = True
        Me.VILabel.Enabled = False
        Me.VILabel.Location = New System.Drawing.Point(141, 169)
        Me.VILabel.Name = "VILabel"
        Me.VILabel.Size = New System.Drawing.Size(23, 13)
        Me.VILabel.TabIndex = 193
        Me.VILabel.Text = "V.I."
        '
        'VIDateTimePicker
        '
        Me.VIDateTimePicker.Enabled = False
        Me.VIDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.VIDateTimePicker.Location = New System.Drawing.Point(171, 167)
        Me.VIDateTimePicker.Name = "VIDateTimePicker"
        Me.VIDateTimePicker.ShowUpDown = True
        Me.VIDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.VIDateTimePicker.TabIndex = 192
        Me.VIDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'SILabel
        '
        Me.SILabel.AutoSize = True
        Me.SILabel.Enabled = False
        Me.SILabel.Location = New System.Drawing.Point(274, 167)
        Me.SILabel.Name = "SILabel"
        Me.SILabel.Size = New System.Drawing.Size(23, 13)
        Me.SILabel.TabIndex = 191
        Me.SILabel.Text = "S.I."
        '
        'SIDateTimePicker
        '
        Me.SIDateTimePicker.Enabled = False
        Me.SIDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.SIDateTimePicker.Location = New System.Drawing.Point(302, 167)
        Me.SIDateTimePicker.Name = "SIDateTimePicker"
        Me.SIDateTimePicker.ShowUpDown = True
        Me.SIDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.SIDateTimePicker.TabIndex = 190
        Me.SIDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'MTLabel
        '
        Me.MTLabel.AutoSize = True
        Me.MTLabel.Enabled = False
        Me.MTLabel.Location = New System.Drawing.Point(272, 134)
        Me.MTLabel.Name = "MTLabel"
        Me.MTLabel.Size = New System.Drawing.Size(29, 13)
        Me.MTLabel.TabIndex = 189
        Me.MTLabel.Text = "M.T."
        '
        'MTDateTimePicker
        '
        Me.MTDateTimePicker.Enabled = False
        Me.MTDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.MTDateTimePicker.Location = New System.Drawing.Point(302, 134)
        Me.MTDateTimePicker.Name = "MTDateTimePicker"
        Me.MTDateTimePicker.ShowUpDown = True
        Me.MTDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.MTDateTimePicker.TabIndex = 188
        Me.MTDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'KTLabel
        '
        Me.KTLabel.AutoSize = True
        Me.KTLabel.Enabled = False
        Me.KTLabel.Location = New System.Drawing.Point(141, 137)
        Me.KTLabel.Name = "KTLabel"
        Me.KTLabel.Size = New System.Drawing.Size(27, 13)
        Me.KTLabel.TabIndex = 187
        Me.KTLabel.Text = "K.T."
        '
        'KTDateTimePicker
        '
        Me.KTDateTimePicker.Enabled = False
        Me.KTDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.KTDateTimePicker.Location = New System.Drawing.Point(171, 134)
        Me.KTDateTimePicker.Name = "KTDateTimePicker"
        Me.KTDateTimePicker.ShowUpDown = True
        Me.KTDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.KTDateTimePicker.TabIndex = 186
        Me.KTDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'LTLabel
        '
        Me.LTLabel.AutoSize = True
        Me.LTLabel.Enabled = False
        Me.LTLabel.Location = New System.Drawing.Point(10, 137)
        Me.LTLabel.Name = "LTLabel"
        Me.LTLabel.Size = New System.Drawing.Size(26, 13)
        Me.LTLabel.TabIndex = 185
        Me.LTLabel.Text = "L.T."
        '
        'LTDateTimePicker
        '
        Me.LTDateTimePicker.Enabled = False
        Me.LTDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.LTDateTimePicker.Location = New System.Drawing.Point(36, 134)
        Me.LTDateTimePicker.Name = "LTDateTimePicker"
        Me.LTDateTimePicker.ShowUpDown = True
        Me.LTDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.LTDateTimePicker.TabIndex = 184
        Me.LTDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'DILabel
        '
        Me.DILabel.AutoSize = True
        Me.DILabel.Enabled = False
        Me.DILabel.Location = New System.Drawing.Point(406, 137)
        Me.DILabel.Name = "DILabel"
        Me.DILabel.Size = New System.Drawing.Size(24, 13)
        Me.DILabel.TabIndex = 183
        Me.DILabel.Text = "D.I."
        '
        'DIDateTimePicker
        '
        Me.DIDateTimePicker.Enabled = False
        Me.DIDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DIDateTimePicker.Location = New System.Drawing.Point(436, 137)
        Me.DIDateTimePicker.Name = "DIDateTimePicker"
        Me.DIDateTimePicker.ShowUpDown = True
        Me.DIDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.DIDateTimePicker.TabIndex = 182
        Me.DIDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'JTLabel
        '
        Me.JTLabel.AutoSize = True
        Me.JTLabel.Enabled = False
        Me.JTLabel.Location = New System.Drawing.Point(9, 193)
        Me.JTLabel.Name = "JTLabel"
        Me.JTLabel.Size = New System.Drawing.Size(25, 13)
        Me.JTLabel.TabIndex = 181
        Me.JTLabel.Text = "J.T."
        '
        'JTDateTimePicker
        '
        Me.JTDateTimePicker.Enabled = False
        Me.JTDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.JTDateTimePicker.Location = New System.Drawing.Point(36, 193)
        Me.JTDateTimePicker.Name = "JTDateTimePicker"
        Me.JTDateTimePicker.ShowUpDown = True
        Me.JTDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.JTDateTimePicker.TabIndex = 180
        Me.JTDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'VTLabel
        '
        Me.VTLabel.AutoSize = True
        Me.VTLabel.Enabled = False
        Me.VTLabel.Location = New System.Drawing.Point(141, 195)
        Me.VTLabel.Name = "VTLabel"
        Me.VTLabel.Size = New System.Drawing.Size(27, 13)
        Me.VTLabel.TabIndex = 179
        Me.VTLabel.Text = "V.T."
        '
        'VTDateTimePicker
        '
        Me.VTDateTimePicker.Enabled = False
        Me.VTDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.VTDateTimePicker.Location = New System.Drawing.Point(171, 193)
        Me.VTDateTimePicker.Name = "VTDateTimePicker"
        Me.VTDateTimePicker.ShowUpDown = True
        Me.VTDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.VTDateTimePicker.TabIndex = 178
        Me.VTDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'STLabel
        '
        Me.STLabel.AutoSize = True
        Me.STLabel.Enabled = False
        Me.STLabel.Location = New System.Drawing.Point(274, 193)
        Me.STLabel.Name = "STLabel"
        Me.STLabel.Size = New System.Drawing.Size(27, 13)
        Me.STLabel.TabIndex = 177
        Me.STLabel.Text = "S.T."
        '
        'STDateTimePicker
        '
        Me.STDateTimePicker.Enabled = False
        Me.STDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.STDateTimePicker.Location = New System.Drawing.Point(302, 193)
        Me.STDateTimePicker.Name = "STDateTimePicker"
        Me.STDateTimePicker.ShowUpDown = True
        Me.STDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.STDateTimePicker.TabIndex = 176
        Me.STDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'MILabel
        '
        Me.MILabel.AutoSize = True
        Me.MILabel.Enabled = False
        Me.MILabel.Location = New System.Drawing.Point(274, 111)
        Me.MILabel.Name = "MILabel"
        Me.MILabel.Size = New System.Drawing.Size(25, 13)
        Me.MILabel.TabIndex = 175
        Me.MILabel.Text = "M.I."
        '
        'MIDateTimePicker
        '
        Me.MIDateTimePicker.Enabled = False
        Me.MIDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.MIDateTimePicker.Location = New System.Drawing.Point(302, 111)
        Me.MIDateTimePicker.Name = "MIDateTimePicker"
        Me.MIDateTimePicker.ShowUpDown = True
        Me.MIDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.MIDateTimePicker.TabIndex = 174
        Me.MIDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'KILabel
        '
        Me.KILabel.AutoSize = True
        Me.KILabel.Enabled = False
        Me.KILabel.Location = New System.Drawing.Point(141, 115)
        Me.KILabel.Name = "KILabel"
        Me.KILabel.Size = New System.Drawing.Size(23, 13)
        Me.KILabel.TabIndex = 173
        Me.KILabel.Text = "K.I."
        '
        'KIDateTimePicker
        '
        Me.KIDateTimePicker.Enabled = False
        Me.KIDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.KIDateTimePicker.Location = New System.Drawing.Point(171, 111)
        Me.KIDateTimePicker.Name = "KIDateTimePicker"
        Me.KIDateTimePicker.ShowUpDown = True
        Me.KIDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.KIDateTimePicker.TabIndex = 172
        Me.KIDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'LILabel
        '
        Me.LILabel.AutoSize = True
        Me.LILabel.Enabled = False
        Me.LILabel.Location = New System.Drawing.Point(10, 115)
        Me.LILabel.Name = "LILabel"
        Me.LILabel.Size = New System.Drawing.Size(25, 13)
        Me.LILabel.TabIndex = 171
        Me.LILabel.Text = "L. I."
        '
        'LIDateTimePicker
        '
        Me.LIDateTimePicker.Enabled = False
        Me.LIDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.LIDateTimePicker.Location = New System.Drawing.Point(36, 111)
        Me.LIDateTimePicker.Name = "LIDateTimePicker"
        Me.LIDateTimePicker.ShowUpDown = True
        Me.LIDateTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.LIDateTimePicker.TabIndex = 170
        Me.LIDateTimePicker.Value = New Date(2018, 11, 4, 0, 0, 0, 0)
        '
        'CancelECFButton
        '
        Me.CancelECFButton.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelECFButton.Location = New System.Drawing.Point(342, 252)
        Me.CancelECFButton.Name = "CancelECFButton"
        Me.CancelECFButton.Size = New System.Drawing.Size(138, 31)
        Me.CancelECFButton.TabIndex = 169
        Me.CancelECFButton.Text = "Cancelar"
        Me.CancelECFButton.UseVisualStyleBackColor = True
        '
        'DeleteCourseButton
        '
        Me.DeleteCourseButton.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteCourseButton.Location = New System.Drawing.Point(194, 252)
        Me.DeleteCourseButton.Name = "DeleteCourseButton"
        Me.DeleteCourseButton.Size = New System.Drawing.Size(143, 31)
        Me.DeleteCourseButton.TabIndex = 168
        Me.DeleteCourseButton.Text = "Eliminar curso"
        Me.DeleteCourseButton.UseVisualStyleBackColor = True
        '
        'SaveCourseButton
        '
        Me.SaveCourseButton.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveCourseButton.Location = New System.Drawing.Point(14, 252)
        Me.SaveCourseButton.Name = "SaveCourseButton"
        Me.SaveCourseButton.Size = New System.Drawing.Size(174, 31)
        Me.SaveCourseButton.TabIndex = 167
        Me.SaveCourseButton.Text = "Guardar cambios"
        Me.SaveCourseButton.UseVisualStyleBackColor = True
        '
        'ColorCoursSRComboBox
        '
        Me.ColorCoursSRComboBox.FormattingEnabled = True
        Me.ColorCoursSRComboBox.Location = New System.Drawing.Point(380, 68)
        Me.ColorCoursSRComboBox.Name = "ColorCoursSRComboBox"
        Me.ColorCoursSRComboBox.Size = New System.Drawing.Size(100, 21)
        Me.ColorCoursSRComboBox.TabIndex = 166
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(212, 54)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(98, 13)
        Me.label1.TabIndex = 165
        Me.label1.Text = "  L  K  M  J  V  S  D"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(180, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 164
        Me.Label7.Text = "Días"
        '
        'NameCoursSRTextBox
        '
        Me.NameCoursSRTextBox.Location = New System.Drawing.Point(54, 68)
        Me.NameCoursSRTextBox.Name = "NameCoursSRTextBox"
        Me.NameCoursSRTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NameCoursSRTextBox.TabIndex = 163
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(335, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 162
        Me.Label6.Text = "Color"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 161
        Me.Label5.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(10, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 20)
        Me.Label4.TabIndex = 159
        Me.Label4.Text = "Editar cursos"
        '
        'DayCoursSRCheckedListBox
        '
        Me.DayCoursSRCheckedListBox.CheckOnClick = True
        Me.DayCoursSRCheckedListBox.ColumnWidth = 13
        Me.DayCoursSRCheckedListBox.FormattingEnabled = True
        Me.DayCoursSRCheckedListBox.Items.AddRange(New Object() {"", "", "", "", "", "", ""})
        Me.DayCoursSRCheckedListBox.Location = New System.Drawing.Point(216, 70)
        Me.DayCoursSRCheckedListBox.MultiColumn = True
        Me.DayCoursSRCheckedListBox.Name = "DayCoursSRCheckedListBox"
        Me.DayCoursSRCheckedListBox.Size = New System.Drawing.Size(98, 19)
        Me.DayCoursSRCheckedListBox.TabIndex = 199
        '
        'EditCourseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 301)
        Me.Controls.Add(Me.DayCoursSRCheckedListBox)
        Me.Controls.Add(Me.EditCourseComboBox)
        Me.Controls.Add(Me.IdUserLabel)
        Me.Controls.Add(Me.DTLabel)
        Me.Controls.Add(Me.DTDateTimePicker)
        Me.Controls.Add(Me.JIDateTimePicker)
        Me.Controls.Add(Me.VILabel)
        Me.Controls.Add(Me.VIDateTimePicker)
        Me.Controls.Add(Me.SILabel)
        Me.Controls.Add(Me.SIDateTimePicker)
        Me.Controls.Add(Me.MTLabel)
        Me.Controls.Add(Me.MTDateTimePicker)
        Me.Controls.Add(Me.KTLabel)
        Me.Controls.Add(Me.KTDateTimePicker)
        Me.Controls.Add(Me.LTLabel)
        Me.Controls.Add(Me.LTDateTimePicker)
        Me.Controls.Add(Me.DILabel)
        Me.Controls.Add(Me.DIDateTimePicker)
        Me.Controls.Add(Me.JTLabel)
        Me.Controls.Add(Me.JTDateTimePicker)
        Me.Controls.Add(Me.VTLabel)
        Me.Controls.Add(Me.VTDateTimePicker)
        Me.Controls.Add(Me.STLabel)
        Me.Controls.Add(Me.STDateTimePicker)
        Me.Controls.Add(Me.MILabel)
        Me.Controls.Add(Me.MIDateTimePicker)
        Me.Controls.Add(Me.KILabel)
        Me.Controls.Add(Me.KIDateTimePicker)
        Me.Controls.Add(Me.LILabel)
        Me.Controls.Add(Me.LIDateTimePicker)
        Me.Controls.Add(Me.CancelECFButton)
        Me.Controls.Add(Me.DeleteCourseButton)
        Me.Controls.Add(Me.SaveCourseButton)
        Me.Controls.Add(Me.ColorCoursSRComboBox)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.NameCoursSRTextBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "EditCourseForm"
        Me.Text = "Editar Cursos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EditCourseComboBox As ComboBox
    Friend WithEvents IdUserLabel As Label
    Friend WithEvents DTLabel As Label
    Friend WithEvents DTDateTimePicker As DateTimePicker
    Friend WithEvents JIDateTimePicker As DateTimePicker
    Friend WithEvents VILabel As Label
    Friend WithEvents VIDateTimePicker As DateTimePicker
    Friend WithEvents SILabel As Label
    Friend WithEvents SIDateTimePicker As DateTimePicker
    Friend WithEvents MTLabel As Label
    Friend WithEvents MTDateTimePicker As DateTimePicker
    Friend WithEvents KTLabel As Label
    Friend WithEvents KTDateTimePicker As DateTimePicker
    Friend WithEvents LTLabel As Label
    Friend WithEvents LTDateTimePicker As DateTimePicker
    Friend WithEvents DILabel As Label
    Friend WithEvents DIDateTimePicker As DateTimePicker
    Friend WithEvents JTLabel As Label
    Friend WithEvents JTDateTimePicker As DateTimePicker
    Friend WithEvents VTLabel As Label
    Friend WithEvents VTDateTimePicker As DateTimePicker
    Friend WithEvents STLabel As Label
    Friend WithEvents STDateTimePicker As DateTimePicker
    Friend WithEvents MILabel As Label
    Friend WithEvents MIDateTimePicker As DateTimePicker
    Friend WithEvents KILabel As Label
    Friend WithEvents KIDateTimePicker As DateTimePicker
    Friend WithEvents LILabel As Label
    Friend WithEvents LIDateTimePicker As DateTimePicker
    Friend WithEvents CancelECFButton As Button
    Friend WithEvents DeleteCourseButton As Button
    Friend WithEvents SaveCourseButton As Button
    Friend WithEvents ColorCoursSRComboBox As ComboBox
    Friend WithEvents label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents NameCoursSRTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DayCoursSRCheckedListBox As CheckedListBox
End Class
