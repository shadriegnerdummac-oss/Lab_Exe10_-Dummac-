Imports System.IO
Public Class Form1
    Dim numfile As String = "n.txt"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Using writer As New StreamWriter(numfile, True)
                writer.WriteLine(NumericUpDown1.Value.ToString())
            End Using
            MessageBox.Show("Data Written Succesfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim numfile As String = "n.txt"
        ListBox1.Items.Clear()
        Try
            Using reader As New StreamReader(numfile)
                Dim line As String
                line = reader.ReadLine()
                While (line IsNot Nothing)
                    ListBox1.Items.Add(line)
                    line = reader.ReadLine()
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click
        Dim numbers As New List(Of Decimal)

        Try
            Using reader As New StreamReader(numfile)
                Dim line As String
                Do While reader.Peek() >= 0
                    line = reader.ReadLine()
                    If Decimal.TryParse(line, numbers.LastOrDefault) Then
                        numbers.Add(CDec(line))
                    Else
                        MessageBox.Show($"Invalid number format found: {line}. Skipping.")
                    End If
                Loop
            End Using

            Dim sortedNumbers = numbers.OrderBy(Function(x) x).ToList()

            ListBox1.Items.Clear()
            For Each number As Decimal In sortedNumbers
                ListBox1.Items.Add(number.ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
