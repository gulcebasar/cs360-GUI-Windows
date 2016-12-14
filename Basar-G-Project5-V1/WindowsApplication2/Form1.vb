Public Class Form1

    Private Property filename As String
    
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Rows.Add({" """" ", "", "", ""})
    End Sub

    Private Sub readFile()
        RichTextBox1.LoadFile(Me.filename, RichTextBoxStreamType.PlainText)

        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(Me.filename)
        Dim stringReader As String

        Do Until fileReader.EndOfStream
            stringReader = fileReader.ReadLine()
            Dim substrings() As String = stringReader.Split(","c)
            Dim substrings2() As String = substrings(3).Split(";"c)
            DataGridView1.Rows.Add({substrings(0), substrings(1), substrings(2), substrings2(0)})
        Loop
        fileReader.Close()

    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) _
   Handles ToolStripComboBox1.SelectedIndexChanged
        If Me.ToolStripComboBox1.SelectedIndex = 0 Then
            Me.SplitContainer1.Panel2Collapsed = True

            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
        Else
            Me.SplitContainer1.Panel2Collapsed = False

            Button1.Enabled = True
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Clear()

        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim cell As DataGridViewCellCollection = row.Cells
            RichTextBox1.AppendText(cell(0).Value + "," + cell(1).Value + "," + cell(2).Value + "," + cell(3).Value + ";" + Environment.NewLine)
        Next

        RichTextBox1.SaveFile(Me.filename, RichTextBoxStreamType.PlainText)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ToolStripComboBox1.SelectedIndex = 0

        Dim dialog1 As New Dialog()
        dialog1.ShowDialog()
        Me.filename = dialog1.TextBox1.Text

        readFile()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For Each row As DataGridViewRow In DataGridView1.SelectedRows
            DataGridView1.Rows.Remove(row)
        Next
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Button3.Enabled = True
    End Sub
End Class
