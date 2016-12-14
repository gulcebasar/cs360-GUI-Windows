Class MainWindow 

    Private Sub start_Click(sender As Object, e As RoutedEventArgs) Handles start.Click
        Me.start.Visibility = Windows.Visibility.Hidden
        Me.startLabel.Visibility = Windows.Visibility.Hidden
        Me.dataGrid.Visibility = Windows.Visibility.Visible
    End Sub

    Private Sub visiblechanged(sender As Object, e As DependencyPropertyChangedEventArgs) Handles dataGrid.IsVisibleChanged
        Dim lines As New List(Of Lines)

        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\temp\oscourses\360-p6.txt")
        Dim stringReader As String
        Do Until fileReader.EndOfStream
            stringReader = fileReader.ReadLine()
            Dim substrings() As String = stringReader.Split(""""c)
            Dim substrings2() As String = substrings(2).Split(","c)
            lines.Add(New Lines(("""" + substrings(1) + """"), CInt(substrings2(1)), CInt(substrings2(2)), CInt(substrings2(3))))
        Loop
        fileReader.Close()

        Dim line As Lines
        For Each line In lines
            Me.dataGrid.Items.Add(line)
        Next
    End Sub

    Public Class Lines
        Public Property name As String
        Public Property num1 As Integer
        Public Property num2 As Integer
        Public Property num3 As Integer

        Public Sub New(ByVal nName As String,
                       ByVal nNum1 As Integer,
                       ByVal nNum2 As Integer,
                       ByVal nNum3 As Integer)
            name = nName
            num1 = nNum1
            num2 = nNum2
            num3 = nNum3
        End Sub
    End Class
End Class
