Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FilePathTxt.Text = Environment.CurrentDirectory + "\file.exe"
    End Sub
    Private Sub BrowseBtn_Click(sender As Object, e As EventArgs) Handles BrowseBtn.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select a file"
            ofd.Filter = "All Files (*.*)|*.*"
            If ofd.ShowDialog() = DialogResult.OK Then
                FilePathTxt.Text = ofd.FileName
            End If
        End Using
    End Sub

    Private Sub PatchBtn_Click(sender As Object, e As EventArgs) Handles PatchBtn.Click
        Dim filePath As String = FilePathTxt.Text.Trim()
        If String.IsNullOrEmpty(filePath) OrElse Not IO.File.Exists(filePath) Then
            MessageBox.Show("Please select a valid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If BackupChk.Checked Then
            Dim backupPath As String = filePath & ".BAK"
            If Not IO.File.Exists(backupPath) Then
                IO.File.Copy(filePath, backupPath)
            End If
        End If

        ' -------------------------------------
        ' Hex Patten List to Search
        ' -------------------------------------
        Dim searchPatterns As String() = {
            "41 4E 44 52 4F 49 44 21",
            "69 67 6E 6F 72 65",
            "61 6E 64 72 6F 69 64 62 6F 6F 74"
        }
        ' -------------------------------------
        ' Hex Patten List to Replace
        ' -------------------------------------
        Dim replacePatterns As String() = {
            "42 49 4E 52 ?? ?? ?? 3F",
            "65 ?? ?? ?? ?? ??",
            "62 69 6E ?? ?? ?? ?? ?? ?? ?? ??"
        }

        If searchPatterns.Length <> replacePatterns.Length Then
            MessageBox.Show("Pattern count mismatch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim data As Byte() = IO.File.ReadAllBytes(filePath)
            Dim totalPatched As Integer = 0
            For i As Integer = 0 To searchPatterns.Length - 1
                totalPatched += snr_module.SearchAndReplaceHex(data, searchPatterns(i), replacePatterns(i), -1)
            Next
            If totalPatched > 0 Then
                IO.File.WriteAllBytes(filePath, data)
                MessageBox.Show("Patch Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Patch Failed. File may already be patched or version not supported.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Patch Failed: " & ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Class
