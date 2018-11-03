Imports System.Data.SqlClient

Public Class ScheduleRegisterForm

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DayCoursSRCheckedListBox.SelectedIndexChanged

    End Sub


    '/////////////////////////EL BOTON DE TERMINAR////////////////////////////////
    Private Sub SaveSRButton_Click(sender As Object, e As EventArgs) Handles SaveSRButton.Click
        'Cuando el boton de terminar en el Form de agregar horarios despues de registrarse, se esconde eso Form y se muestra la el form de inicio -Santi
        Me.Hide()
        HomeForm.Show()

        '//////////// AGREGA EL PERIODO LECTIVO A LA BASE DE DATOS -Santi /////////////////
        Dim period As Period
        period = New Period

        period.Name_Period = NamePeriodTextBox.Text
        period.StartDate_Period = StartPeriodRegisterDateTimePicker.Value
        period.EndDate_Period = EndPeriodRegisterDateTimePicker.Value
        period.Id_Period = 0

        Dim connection As SqlConnection
        Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"


        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)

        'abriendo la conexión
        connection.Open()

        Dim insertQuery

        'declaramos la sentencia de INSERT para insertar a la BD
        insertQuery = "INSERT INTO Period(namePeriod, startDate, endDate) values (@namePeriod, @startDate, @endDate)"

        command = New SqlCommand(insertQuery, connection)

        With command 'le asigna los valores a los espacios en la tabla

            '.Parameters.AddWithValue("@idStudent", )
            .Parameters.AddWithValue("@namePeriod", period.Name_Period)
            .Parameters.AddWithValue("@startDate", period.StartDate_Period)
            .Parameters.AddWithValue("@endDate", period.EndDate_Period)

        End With


        'ejecutamos la consulta
        command.ExecuteNonQuery()

        connection.Close()

        Dim selectQuery

        'declaramos la sentencia de INSERT para insertar a la BD
        selectQuery = "SELECT TOP 1 * FROM Period ORDER BY idPeriod DESC"

        command = New SqlCommand(selectQuery, connection)

        connection.Open()

        'ejecuta el lector de la base de datos
        Dim reader As SqlDataReader = command.ExecuteReader

        reader.Read()

        period.Id_Period = reader.Item("idPeriod")
        MsgBox(period.Id_Period)

        connection.Dispose()
        connection.Close()

        '\\\\\\\\\\\\\\\\\\\ TERMINA DE AGREGAR EL PERIODO LECTIVO A LA BASE DE DATOS \\\\\\\\\\\\\\\\\\\\\\\\\\


        '////// AGREGA UN CURSO A LA BASE DE DATOS /////////////
        Dim course As Course
        course = New Course

        course.Name_Course = NameCoursSRTextBox.Text
        course.Color_Course = ColorCoursSRComboBox.SelectedItem.ToString


            'aquí conectamos con la base de datos
            connection = New SqlConnection(connectionString)

        'abriendo la conexión
        connection.Open()

        'declaramos la sentencia de INSERT para insertar a la BD
        insertQuery = "INSERT INTO Subject(nameSubject, color, idPeriod ) values (@nameSubject, @color, @idPeriod)"

        command = New SqlCommand(insertQuery, connection)

        With command 'le asigna los valores a los espacios en la tabla

            '.Parameters.AddWithValue("@idStudent", )
            .Parameters.AddWithValue("@nameSubject", course.Name_Course)
            .Parameters.AddWithValue("@color", course.Color_Course.ToString)
            .Parameters.AddWithValue("@idPeriod", period.Id_Period)

        End With


        'ejecutamos la consulta
        command.ExecuteNonQuery()

        connection.Dispose()
        connection.Close()
        '\\\\\\\\\ TERMINA DE AGREGAR UN CURSO A LA BASE DE DATOS \\\\\\\\\\\\
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ TERMINA EL BOTON DE TERMINAR \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


    '////////////////// Para agregarle colores al combobox de color cuando se agrega un curso //////////////////////
    Private Sub ScheduleRegisterForm_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load

        Dim knownColors = System.Enum.GetNames(GetType(KnownColor)).
            Where(Function(kc) GetType(SystemColors).GetProperty(kc) Is Nothing _
            AndAlso kc <> KnownColor.Transparent.ToString()).
            OrderBy(Function(kc) kc)

        With ColorCoursSRComboBox
            .DrawMode = DrawMode.OwnerDrawFixed
            .IntegralHeight = False
            .MaxDropDownItems = 8
            .DataSource = knownColors.ToList
            .SelectedIndex = -1
        End With
        With ColorWorkSRComboBox
            .DrawMode = DrawMode.OwnerDrawFixed
            .IntegralHeight = False
            .MaxDropDownItems = 8
            .DataSource = knownColors.ToList
            .SelectedIndex = -1
        End With
        With ColorStudySRComboBox
            .DrawMode = DrawMode.OwnerDrawFixed
            .IntegralHeight = False
            .MaxDropDownItems = 8
            .DataSource = knownColors.ToList
            .SelectedIndex = -1
        End With

    End Sub


    '///////// Hace que se vean los colores como opciones en el combobox -Santi ///////////////////////////////
    Private Sub ColorCoursSRComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) _
        Handles ColorCoursSRComboBox.DrawItem
        Dim myComboBox As ComboBox = CType(sender, ComboBox)
        Dim mySelectedColor As Color = Color.FromName(myComboBox.Items(e.Index).ToString)
        Dim myRectangleSize As Integer = e.Bounds.Height - 3


        e.DrawBackground()

        Using myBrush As New SolidBrush(e.ForeColor)
            Using mySelectedBrush As New SolidBrush(mySelectedColor)
                e.Graphics.FillRectangle(mySelectedBrush,
                                        e.Bounds.Left + 5,
                                        e.Bounds.Top + 2,
                                        70,
                                        myRectangleSize)
                e.Graphics.DrawRectangle(New Pen(Brushes.Black),
                                        e.Bounds.Left + 5,
                                        e.Bounds.Top + 2,
                                        70,
                                        myRectangleSize)
            End Using
        End Using

    End Sub

    'Cambia el color del fondo del combobox al color escogido -Santi
    Private Sub ColorCoursSRComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColorCoursSRComboBox.SelectedIndexChanged
        If ColorCoursSRComboBox.SelectedIndex <> -1 Then

            ColorCoursSRComboBox.BackColor = Color.FromName(ColorCoursSRComboBox.SelectedItem.ToString)

        End If
    End Sub

    'Termina de agregarle colores al combobox de color cuando se agrega un curso -Santi
    '////////////////////////////////////////////////////////////////////////////////////////////////////


    '///////////////////////////////////////////////////////////////////////////////////////////////
    'Para agregarle colores al combobox de color cuando se agrega un horario de trabajo -Santi

    'Hace que se vean los colores como opciones en el combobox -Santi
    Private Sub ColorWorkSRComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) _
        Handles ColorWorkSRComboBox.DrawItem
        Dim myComboBox As ComboBox = CType(sender, ComboBox)
        Dim mySelectedColor As Color = Color.FromName(myComboBox.Items(e.Index).ToString)
        Dim myRectangleSize As Integer = e.Bounds.Height - 3


        e.DrawBackground()

        Using myBrush As New SolidBrush(e.ForeColor)
            Using mySelectedBrush As New SolidBrush(mySelectedColor)
                e.Graphics.FillRectangle(mySelectedBrush,
                                        e.Bounds.Left + 5,
                                        e.Bounds.Top + 2,
                                        70,
                                        myRectangleSize)
                e.Graphics.DrawRectangle(New Pen(Brushes.Black),
                                        e.Bounds.Left + 5,
                                        e.Bounds.Top + 2,
                                        70,
                                        myRectangleSize)
            End Using
        End Using

    End Sub

    'Cambia el color del fondo del combobox al color escogido -Santi
    Private Sub ColorWorkSRComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColorWorkSRComboBox.SelectedIndexChanged
        If ColorWorkSRComboBox.SelectedIndex <> -1 Then

            ColorWorkSRComboBox.BackColor = Color.FromName(ColorWorkSRComboBox.SelectedItem.ToString)

        End If
    End Sub

    'Termina de agregarle colores al combobox de color cuando se agrega un horario de trabajo -Santi
    '////////////////////////////////////////////////////////////////////////////////////////////////////

    '///////////////////////////////////////////////////////////////////////////////////////////////
    'Para agregarle colores al combobox de color cuando se agrega un horario de estudio -Santi

    'Hace que se vean los colores como opciones en el combobox -Santi
    Private Sub ColorStudySRComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) _
        Handles ColorStudySRComboBox.DrawItem
        Dim myComboBox As ComboBox = CType(sender, ComboBox)
        Dim mySelectedColor As Color = Color.FromName(myComboBox.Items(e.Index).ToString)
        Dim myRectangleSize As Integer = e.Bounds.Height - 3


        e.DrawBackground()

        Using myBrush As New SolidBrush(e.ForeColor)
            Using mySelectedBrush As New SolidBrush(mySelectedColor)
                e.Graphics.FillRectangle(mySelectedBrush,
                                        e.Bounds.Left + 5,
                                        e.Bounds.Top + 2,
                                        70,
                                        myRectangleSize)
                e.Graphics.DrawRectangle(New Pen(Brushes.Black),
                                        e.Bounds.Left + 5,
                                        e.Bounds.Top + 2,
                                        70,
                                        myRectangleSize)
            End Using
        End Using

    End Sub

    'Cambia el color del fondo del combobox al color escogido -Santi
    Private Sub ColorStudySRComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColorStudySRComboBox.SelectedIndexChanged
        If ColorStudySRComboBox.SelectedIndex <> -1 Then

            ColorStudySRComboBox.BackColor = Color.FromName(ColorStudySRComboBox.SelectedItem.ToString)

        End If
    End Sub
    'Termina de agregarle colores al combobox de color cuando se agrega un horario de estudio -Santi
    '////////////////////////////////////////////////////////////////////////////////////////////////////


    Private Sub AddCoursSRButton_Click(sender As Object, e As EventArgs) Handles AddCoursSRButton.Click
        '////// AGREGA UN CURSO A LA BASE DE DATOS Y LIMPIA LOS CAMPOS PARA AGREGAR OTRO /////////////
        Dim course As Course
        course = New Course

        course.Name_Course = NameCoursSRTextBox.Text
        course.Color_Course = ColorCoursSRComboBox.SelectedItem.ToString



        Dim connection As SqlConnection
        Dim command As SqlCommand

        Dim connectionString As String = "Data Source=klassmate.database.windows.net;Initial Catalog=ProjectDB;Persist Security Info=True;User ID=klassmateAdmin;Password=Contra123"


        'aquí conectamos con la base de datos
        connection = New SqlConnection(connectionString)

        'abriendo la conexión
        connection.Open()

        Dim insertQuery
        'declaramos la sentencia de INSERT para insertar a la BD
        insertQuery = "INSERT INTO Subject(nameSubject, color, idPeriod ) values (@nameSubject, @color, @idPeriod)"

        command = New SqlCommand(insertQuery, connection)

        With command 'le asigna los valores a los espacios en la tabla

            '.Parameters.AddWithValue("@idStudent", )
            .Parameters.AddWithValue("@nameSubject", course.Name_Course)
            .Parameters.AddWithValue("@color", course.Color_Course.ToString)
            '.Parameters.AddWithValue("@idPeriod", Period.Id_Period)

        End With


        'ejecutamos la consulta
        command.ExecuteNonQuery()

        connection.Dispose()
        connection.Close()
        '\\\\\\\\\ TERMINA DE AGREGAR UN CURSO A LA BASE DE DATOS \\\\\\\\\\\\
    End Sub



End Class