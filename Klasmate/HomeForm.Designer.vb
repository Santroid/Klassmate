<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HomeForm
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.AddHomePanel = New System.Windows.Forms.Panel()
        Me.HomeworkAddHomeLabel = New System.Windows.Forms.Label()
        Me.WorkAddHomeLabel = New System.Windows.Forms.Label()
        Me.StudyAddHomeLabel = New System.Windows.Forms.Label()
        Me.CourseAddHomeLabel = New System.Windows.Forms.Label()
        Me.TermAddHomeLabel = New System.Windows.Forms.Label()
        Me.OptionsHomePanel = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ExitHomeLabel = New System.Windows.Forms.Label()
        Me.ProfileEditHomeLabel = New System.Windows.Forms.Label()
        Me.ScheduleEditHomeLabel = New System.Windows.Forms.Label()
        Me.EditProfilePanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CancelEditProfileButton = New System.Windows.Forms.Button()
        Me.SaveEditProfileButton = New System.Windows.Forms.Button()
        Me.PasswordEditProfileTextBox = New System.Windows.Forms.TextBox()
        Me.EmailEditProfileTextBox = New System.Windows.Forms.TextBox()
        Me.NameEditProfileTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordEditPanelLabel = New System.Windows.Forms.Label()
        Me.EmailEditPanelLabel = New System.Windows.Forms.Label()
        Me.NameEditPanelLabel = New System.Windows.Forms.Label()
        Me.AddHomeWorkPanel = New System.Windows.Forms.Panel()
        Me.CoursAddHWPanelComboBox = New System.Windows.Forms.ComboBox()
        Me.CancelHWAddButton = New System.Windows.Forms.Button()
        Me.SaveHWAddButton = New System.Windows.Forms.Button()
        Me.DdayAddPanelDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.NameHWAddPanelTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape8 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape7 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.CourseDataGridView = New System.Windows.Forms.DataGridView()
        Me.color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nameSubject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CourseDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CourseStartTme = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CourseEndTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CourseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddHomePanel.SuspendLayout()
        Me.OptionsHomePanel.SuspendLayout()
        Me.EditProfilePanel.SuspendLayout()
        Me.AddHomeWorkPanel.SuspendLayout()
        CType(Me.CourseDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Lime
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 49)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(656, 10)
        Me.ProgressBar1.TabIndex = 0
        '
        'AddHomePanel
        '
        Me.AddHomePanel.BackColor = System.Drawing.Color.Gray
        Me.AddHomePanel.Controls.Add(Me.HomeworkAddHomeLabel)
        Me.AddHomePanel.Controls.Add(Me.WorkAddHomeLabel)
        Me.AddHomePanel.Controls.Add(Me.StudyAddHomeLabel)
        Me.AddHomePanel.Controls.Add(Me.CourseAddHomeLabel)
        Me.AddHomePanel.Controls.Add(Me.TermAddHomeLabel)
        Me.AddHomePanel.Location = New System.Drawing.Point(0, 49)
        Me.AddHomePanel.Name = "AddHomePanel"
        Me.AddHomePanel.Size = New System.Drawing.Size(134, 128)
        Me.AddHomePanel.TabIndex = 3
        Me.AddHomePanel.Visible = False
        '
        'HomeworkAddHomeLabel
        '
        Me.HomeworkAddHomeLabel.AutoSize = True
        Me.HomeworkAddHomeLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HomeworkAddHomeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.HomeworkAddHomeLabel.Location = New System.Drawing.Point(12, 99)
        Me.HomeworkAddHomeLabel.Name = "HomeworkAddHomeLabel"
        Me.HomeworkAddHomeLabel.Size = New System.Drawing.Size(35, 13)
        Me.HomeworkAddHomeLabel.TabIndex = 4
        Me.HomeworkAddHomeLabel.Text = "Tarea"
        '
        'WorkAddHomeLabel
        '
        Me.WorkAddHomeLabel.AutoSize = True
        Me.WorkAddHomeLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WorkAddHomeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.WorkAddHomeLabel.Location = New System.Drawing.Point(12, 77)
        Me.WorkAddHomeLabel.Name = "WorkAddHomeLabel"
        Me.WorkAddHomeLabel.Size = New System.Drawing.Size(95, 13)
        Me.WorkAddHomeLabel.TabIndex = 3
        Me.WorkAddHomeLabel.Text = "Horario de Trabajo"
        '
        'StudyAddHomeLabel
        '
        Me.StudyAddHomeLabel.AutoSize = True
        Me.StudyAddHomeLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.StudyAddHomeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.StudyAddHomeLabel.Location = New System.Drawing.Point(12, 55)
        Me.StudyAddHomeLabel.Name = "StudyAddHomeLabel"
        Me.StudyAddHomeLabel.Size = New System.Drawing.Size(94, 13)
        Me.StudyAddHomeLabel.TabIndex = 2
        Me.StudyAddHomeLabel.Text = "Horario de Estudio"
        '
        'CourseAddHomeLabel
        '
        Me.CourseAddHomeLabel.AutoSize = True
        Me.CourseAddHomeLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CourseAddHomeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CourseAddHomeLabel.Location = New System.Drawing.Point(12, 32)
        Me.CourseAddHomeLabel.Name = "CourseAddHomeLabel"
        Me.CourseAddHomeLabel.Size = New System.Drawing.Size(34, 13)
        Me.CourseAddHomeLabel.TabIndex = 1
        Me.CourseAddHomeLabel.Text = "Curso"
        '
        'TermAddHomeLabel
        '
        Me.TermAddHomeLabel.AutoSize = True
        Me.TermAddHomeLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TermAddHomeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TermAddHomeLabel.Location = New System.Drawing.Point(12, 10)
        Me.TermAddHomeLabel.Name = "TermAddHomeLabel"
        Me.TermAddHomeLabel.Size = New System.Drawing.Size(81, 13)
        Me.TermAddHomeLabel.TabIndex = 0
        Me.TermAddHomeLabel.Text = "Periodo Lectivo"
        '
        'OptionsHomePanel
        '
        Me.OptionsHomePanel.BackColor = System.Drawing.Color.Gray
        Me.OptionsHomePanel.Controls.Add(Me.Label6)
        Me.OptionsHomePanel.Controls.Add(Me.Label5)
        Me.OptionsHomePanel.Controls.Add(Me.ExitHomeLabel)
        Me.OptionsHomePanel.Controls.Add(Me.ProfileEditHomeLabel)
        Me.OptionsHomePanel.Controls.Add(Me.ScheduleEditHomeLabel)
        Me.OptionsHomePanel.Location = New System.Drawing.Point(701, 49)
        Me.OptionsHomePanel.Name = "OptionsHomePanel"
        Me.OptionsHomePanel.Size = New System.Drawing.Size(99, 125)
        Me.OptionsHomePanel.TabIndex = 5
        Me.OptionsHomePanel.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(3, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Generar Reporte"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(22, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Editar Tarea"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ExitHomeLabel
        '
        Me.ExitHomeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitHomeLabel.AutoSize = True
        Me.ExitHomeLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExitHomeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ExitHomeLabel.Location = New System.Drawing.Point(56, 101)
        Me.ExitHomeLabel.Name = "ExitHomeLabel"
        Me.ExitHomeLabel.Size = New System.Drawing.Size(27, 13)
        Me.ExitHomeLabel.TabIndex = 2
        Me.ExitHomeLabel.Text = "Salir"
        Me.ExitHomeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ProfileEditHomeLabel
        '
        Me.ProfileEditHomeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProfileEditHomeLabel.AutoSize = True
        Me.ProfileEditHomeLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ProfileEditHomeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ProfileEditHomeLabel.Location = New System.Drawing.Point(23, 77)
        Me.ProfileEditHomeLabel.Name = "ProfileEditHomeLabel"
        Me.ProfileEditHomeLabel.Size = New System.Drawing.Size(60, 13)
        Me.ProfileEditHomeLabel.TabIndex = 1
        Me.ProfileEditHomeLabel.Text = "Editar Perfil"
        Me.ProfileEditHomeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ScheduleEditHomeLabel
        '
        Me.ScheduleEditHomeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScheduleEditHomeLabel.AutoSize = True
        Me.ScheduleEditHomeLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ScheduleEditHomeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ScheduleEditHomeLabel.Location = New System.Drawing.Point(13, 33)
        Me.ScheduleEditHomeLabel.Name = "ScheduleEditHomeLabel"
        Me.ScheduleEditHomeLabel.Size = New System.Drawing.Size(76, 13)
        Me.ScheduleEditHomeLabel.TabIndex = 0
        Me.ScheduleEditHomeLabel.Text = "Editar Horarios"
        Me.ScheduleEditHomeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'EditProfilePanel
        '
        Me.EditProfilePanel.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.EditProfilePanel.Controls.Add(Me.Label1)
        Me.EditProfilePanel.Controls.Add(Me.CancelEditProfileButton)
        Me.EditProfilePanel.Controls.Add(Me.SaveEditProfileButton)
        Me.EditProfilePanel.Controls.Add(Me.PasswordEditProfileTextBox)
        Me.EditProfilePanel.Controls.Add(Me.EmailEditProfileTextBox)
        Me.EditProfilePanel.Controls.Add(Me.NameEditProfileTextBox)
        Me.EditProfilePanel.Controls.Add(Me.PasswordEditPanelLabel)
        Me.EditProfilePanel.Controls.Add(Me.EmailEditPanelLabel)
        Me.EditProfilePanel.Controls.Add(Me.NameEditPanelLabel)
        Me.EditProfilePanel.Location = New System.Drawing.Point(275, 126)
        Me.EditProfilePanel.Name = "EditProfilePanel"
        Me.EditProfilePanel.Size = New System.Drawing.Size(207, 254)
        Me.EditProfilePanel.TabIndex = 6
        Me.EditProfilePanel.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Editar Perfil"
        '
        'CancelEditProfileButton
        '
        Me.CancelEditProfileButton.Location = New System.Drawing.Point(107, 216)
        Me.CancelEditProfileButton.Name = "CancelEditProfileButton"
        Me.CancelEditProfileButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelEditProfileButton.TabIndex = 7
        Me.CancelEditProfileButton.Text = "Cancelar"
        Me.CancelEditProfileButton.UseVisualStyleBackColor = True
        '
        'SaveEditProfileButton
        '
        Me.SaveEditProfileButton.Location = New System.Drawing.Point(26, 216)
        Me.SaveEditProfileButton.Name = "SaveEditProfileButton"
        Me.SaveEditProfileButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveEditProfileButton.TabIndex = 6
        Me.SaveEditProfileButton.Text = "Guardar"
        Me.SaveEditProfileButton.UseVisualStyleBackColor = True
        '
        'PasswordEditProfileTextBox
        '
        Me.PasswordEditProfileTextBox.Location = New System.Drawing.Point(26, 180)
        Me.PasswordEditProfileTextBox.Name = "PasswordEditProfileTextBox"
        Me.PasswordEditProfileTextBox.Size = New System.Drawing.Size(156, 20)
        Me.PasswordEditProfileTextBox.TabIndex = 5
        '
        'EmailEditProfileTextBox
        '
        Me.EmailEditProfileTextBox.Location = New System.Drawing.Point(26, 125)
        Me.EmailEditProfileTextBox.Name = "EmailEditProfileTextBox"
        Me.EmailEditProfileTextBox.Size = New System.Drawing.Size(156, 20)
        Me.EmailEditProfileTextBox.TabIndex = 4
        '
        'NameEditProfileTextBox
        '
        Me.NameEditProfileTextBox.Location = New System.Drawing.Point(26, 73)
        Me.NameEditProfileTextBox.Name = "NameEditProfileTextBox"
        Me.NameEditProfileTextBox.Size = New System.Drawing.Size(156, 20)
        Me.NameEditProfileTextBox.TabIndex = 3
        '
        'PasswordEditPanelLabel
        '
        Me.PasswordEditPanelLabel.AutoSize = True
        Me.PasswordEditPanelLabel.Location = New System.Drawing.Point(23, 164)
        Me.PasswordEditPanelLabel.Name = "PasswordEditPanelLabel"
        Me.PasswordEditPanelLabel.Size = New System.Drawing.Size(61, 13)
        Me.PasswordEditPanelLabel.TabIndex = 2
        Me.PasswordEditPanelLabel.Text = "Contraseña"
        '
        'EmailEditPanelLabel
        '
        Me.EmailEditPanelLabel.AutoSize = True
        Me.EmailEditPanelLabel.Location = New System.Drawing.Point(23, 109)
        Me.EmailEditPanelLabel.Name = "EmailEditPanelLabel"
        Me.EmailEditPanelLabel.Size = New System.Drawing.Size(38, 13)
        Me.EmailEditPanelLabel.TabIndex = 1
        Me.EmailEditPanelLabel.Text = "Correo"
        '
        'NameEditPanelLabel
        '
        Me.NameEditPanelLabel.AutoSize = True
        Me.NameEditPanelLabel.Location = New System.Drawing.Point(23, 57)
        Me.NameEditPanelLabel.Name = "NameEditPanelLabel"
        Me.NameEditPanelLabel.Size = New System.Drawing.Size(44, 13)
        Me.NameEditPanelLabel.TabIndex = 0
        Me.NameEditPanelLabel.Text = "Nombre"
        '
        'AddHomeWorkPanel
        '
        Me.AddHomeWorkPanel.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.AddHomeWorkPanel.Controls.Add(Me.CoursAddHWPanelComboBox)
        Me.AddHomeWorkPanel.Controls.Add(Me.CancelHWAddButton)
        Me.AddHomeWorkPanel.Controls.Add(Me.SaveHWAddButton)
        Me.AddHomeWorkPanel.Controls.Add(Me.DdayAddPanelDateTimePicker)
        Me.AddHomeWorkPanel.Controls.Add(Me.NameHWAddPanelTextBox)
        Me.AddHomeWorkPanel.Controls.Add(Me.Label4)
        Me.AddHomeWorkPanel.Controls.Add(Me.Label3)
        Me.AddHomeWorkPanel.Controls.Add(Me.Label2)
        Me.AddHomeWorkPanel.Location = New System.Drawing.Point(499, 180)
        Me.AddHomeWorkPanel.Name = "AddHomeWorkPanel"
        Me.AddHomeWorkPanel.Size = New System.Drawing.Size(253, 254)
        Me.AddHomeWorkPanel.TabIndex = 7
        Me.AddHomeWorkPanel.Visible = False
        '
        'CoursAddHWPanelComboBox
        '
        Me.CoursAddHWPanelComboBox.FormattingEnabled = True
        Me.CoursAddHWPanelComboBox.Location = New System.Drawing.Point(29, 112)
        Me.CoursAddHWPanelComboBox.Name = "CoursAddHWPanelComboBox"
        Me.CoursAddHWPanelComboBox.Size = New System.Drawing.Size(194, 21)
        Me.CoursAddHWPanelComboBox.TabIndex = 10
        '
        'CancelHWAddButton
        '
        Me.CancelHWAddButton.Location = New System.Drawing.Point(148, 206)
        Me.CancelHWAddButton.Name = "CancelHWAddButton"
        Me.CancelHWAddButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelHWAddButton.TabIndex = 9
        Me.CancelHWAddButton.Text = "Cancelar"
        Me.CancelHWAddButton.UseVisualStyleBackColor = True
        '
        'SaveHWAddButton
        '
        Me.SaveHWAddButton.Location = New System.Drawing.Point(31, 206)
        Me.SaveHWAddButton.Name = "SaveHWAddButton"
        Me.SaveHWAddButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveHWAddButton.TabIndex = 8
        Me.SaveHWAddButton.Text = "Guardar"
        Me.SaveHWAddButton.UseVisualStyleBackColor = True
        '
        'DdayAddPanelDateTimePicker
        '
        Me.DdayAddPanelDateTimePicker.Location = New System.Drawing.Point(31, 165)
        Me.DdayAddPanelDateTimePicker.Name = "DdayAddPanelDateTimePicker"
        Me.DdayAddPanelDateTimePicker.Size = New System.Drawing.Size(192, 20)
        Me.DdayAddPanelDateTimePicker.TabIndex = 5
        '
        'NameHWAddPanelTextBox
        '
        Me.NameHWAddPanelTextBox.Location = New System.Drawing.Point(29, 57)
        Me.NameHWAddPanelTextBox.Name = "NameHWAddPanelTextBox"
        Me.NameHWAddPanelTextBox.Size = New System.Drawing.Size(194, 20)
        Me.NameHWAddPanelTextBox.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Fecha de Entrega"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Curso"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape8, Me.LineShape7, Me.RectangleShape3, Me.LineShape3, Me.LineShape2, Me.LineShape1, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(800, 641)
        Me.ShapeContainer1.TabIndex = 8
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape8
        '
        Me.LineShape8.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LineShape8.BorderWidth = 3
        Me.LineShape8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LineShape8.Name = "LineShape8"
        Me.LineShape8.X1 = 9
        Me.LineShape8.X2 = 36
        Me.LineShape8.Y1 = 25
        Me.LineShape8.Y2 = 25
        '
        'LineShape7
        '
        Me.LineShape7.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LineShape7.BorderWidth = 3
        Me.LineShape7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LineShape7.Name = "LineShape7"
        Me.LineShape7.X1 = 22
        Me.LineShape7.X2 = 22
        Me.LineShape7.Y1 = 10
        Me.LineShape7.Y2 = 40
        '
        'RectangleShape3
        '
        Me.RectangleShape3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RectangleShape3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RectangleShape3.FillColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RectangleShape3.FillGradientColor = System.Drawing.Color.Silver
        Me.RectangleShape3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape3.Location = New System.Drawing.Point(0, 0)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.Size = New System.Drawing.Size(42, 49)
        '
        'LineShape3
        '
        Me.LineShape3.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LineShape3.BorderWidth = 3
        Me.LineShape3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 768
        Me.LineShape3.X2 = 791
        Me.LineShape3.Y1 = 36
        Me.LineShape3.Y2 = 36
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LineShape2.BorderWidth = 3
        Me.LineShape2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 768
        Me.LineShape2.X2 = 791
        Me.LineShape2.Y1 = 24
        Me.LineShape2.Y2 = 24
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LineShape1.BorderWidth = 3
        Me.LineShape1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 768
        Me.LineShape1.X2 = 791
        Me.LineShape1.Y1 = 12
        Me.LineShape1.Y2 = 12
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BackColor = System.Drawing.Color.White
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RectangleShape1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RectangleShape1.FillColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RectangleShape1.FillGradientColor = System.Drawing.Color.Silver
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(758, -1)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(42, 49)
        '
        'CourseDataGridView
        '
        Me.CourseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CourseDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.color, Me.nameSubject, Me.CourseDays, Me.CourseStartTme, Me.CourseEndTime, Me.CourseID})
        Me.CourseDataGridView.Location = New System.Drawing.Point(3, 75)
        Me.CourseDataGridView.Name = "CourseDataGridView"
        Me.CourseDataGridView.Size = New System.Drawing.Size(653, 261)
        Me.CourseDataGridView.TabIndex = 9
        '
        'color
        '
        Me.color.DataPropertyName = "color"
        Me.color.FillWeight = 25.0!
        Me.color.HeaderText = ""
        Me.color.Name = "color"
        Me.color.Width = 25
        '
        'nameSubject
        '
        Me.nameSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nameSubject.DataPropertyName = "nameSubject"
        Me.nameSubject.HeaderText = "Nombre del Curso"
        Me.nameSubject.Name = "nameSubject"
        '
        'CourseDays
        '
        Me.CourseDays.DataPropertyName = "day"
        Me.CourseDays.HeaderText = "Dias"
        Me.CourseDays.Name = "CourseDays"
        '
        'CourseStartTme
        '
        Me.CourseStartTme.DataPropertyName = "startTime"
        Me.CourseStartTme.HeaderText = "Hora Inicio"
        Me.CourseStartTme.Name = "CourseStartTme"
        '
        'CourseEndTime
        '
        Me.CourseEndTime.DataPropertyName = "endTime"
        Me.CourseEndTime.HeaderText = "Hora Fin"
        Me.CourseEndTime.Name = "CourseEndTime"
        '
        'CourseID
        '
        Me.CourseID.DataPropertyName = "idSubject"
        Me.CourseID.HeaderText = "IDCurso"
        Me.CourseID.Name = "CourseID"
        '
        'HomeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 641)
        Me.Controls.Add(Me.OptionsHomePanel)
        Me.Controls.Add(Me.AddHomePanel)
        Me.Controls.Add(Me.AddHomeWorkPanel)
        Me.Controls.Add(Me.EditProfilePanel)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.CourseDataGridView)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "HomeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HomeForm"
        Me.AddHomePanel.ResumeLayout(False)
        Me.AddHomePanel.PerformLayout()
        Me.OptionsHomePanel.ResumeLayout(False)
        Me.OptionsHomePanel.PerformLayout()
        Me.EditProfilePanel.ResumeLayout(False)
        Me.EditProfilePanel.PerformLayout()
        Me.AddHomeWorkPanel.ResumeLayout(False)
        Me.AddHomeWorkPanel.PerformLayout()
        CType(Me.CourseDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents AddHomePanel As Panel
    Friend WithEvents HomeworkAddHomeLabel As Label
    Friend WithEvents WorkAddHomeLabel As Label
    Friend WithEvents StudyAddHomeLabel As Label
    Friend WithEvents CourseAddHomeLabel As Label
    Friend WithEvents TermAddHomeLabel As Label
    Friend WithEvents OptionsHomePanel As Panel
    Friend WithEvents ExitHomeLabel As Label
    Friend WithEvents ProfileEditHomeLabel As Label
    Friend WithEvents ScheduleEditHomeLabel As Label
    Friend WithEvents EditProfilePanel As Panel
    Friend WithEvents CancelEditProfileButton As Button
    Friend WithEvents SaveEditProfileButton As Button
    Friend WithEvents PasswordEditProfileTextBox As TextBox
    Friend WithEvents EmailEditProfileTextBox As TextBox
    Friend WithEvents NameEditProfileTextBox As TextBox
    Friend WithEvents PasswordEditPanelLabel As Label
    Friend WithEvents EmailEditPanelLabel As Label
    Friend WithEvents NameEditPanelLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents AddHomeWorkPanel As Panel
    Friend WithEvents DdayAddPanelDateTimePicker As DateTimePicker
    Friend WithEvents NameHWAddPanelTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CoursAddHWPanelComboBox As ComboBox
    Friend WithEvents CancelHWAddButton As Button
    Friend WithEvents SaveHWAddButton As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents LineShape3 As PowerPacks.LineShape
    Friend WithEvents LineShape2 As PowerPacks.LineShape
    Friend WithEvents LineShape1 As PowerPacks.LineShape
    Friend WithEvents RectangleShape1 As PowerPacks.RectangleShape
    Friend WithEvents LineShape8 As PowerPacks.LineShape
    Friend WithEvents LineShape7 As PowerPacks.LineShape
    Friend WithEvents RectangleShape3 As PowerPacks.RectangleShape
    Friend WithEvents CourseDataGridView As DataGridView
    Friend WithEvents color As DataGridViewTextBoxColumn
    Friend WithEvents nameSubject As DataGridViewTextBoxColumn
    Friend WithEvents CourseDays As DataGridViewTextBoxColumn
    Friend WithEvents CourseStartTme As DataGridViewTextBoxColumn
    Friend WithEvents CourseEndTime As DataGridViewTextBoxColumn
    Friend WithEvents CourseID As DataGridViewTextBoxColumn
End Class
