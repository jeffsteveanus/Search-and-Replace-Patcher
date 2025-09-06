Imports System
Imports System.IO

Module snr_module
    Public Function SearchAndReplaceHexInFile(filePath As String, searchHex As String, replaceHex As String, Optional patchNumber As Integer = -1) As Integer
        If Not File.Exists(filePath) Then Throw New FileNotFoundException("File not found", filePath)
        Dim data As Byte() = File.ReadAllBytes(filePath)
        Dim replacements As Integer = SearchAndReplaceHex(data, searchHex, replaceHex, patchNumber)
        If replacements > 0 Then File.WriteAllBytes(filePath, data)
        Return replacements
    End Function

    Public Function SearchAndReplaceHex(data As Byte(), searchHex As String, replaceHex As String, Optional patchNumber As Integer = -1) As Integer
        If data Is Nothing Then Throw New ArgumentNullException("data")
        Dim sBytes(), sMask(), rBytes(), rMask() As Byte
        ParseHexPattern(searchHex, sBytes, sMask)
        ParseHexPattern(replaceHex, rBytes, rMask)
        If sBytes.Length = 0 Then Throw New ArgumentException("Search pattern is empty.", "searchHex")
        If sBytes.Length <> rBytes.Length Then Throw New ArgumentException("Search and replace patterns must have the same length.")
        Dim patternLen As Integer = sBytes.Length
        If data.Length < patternLen Then Return 0
        Dim matchesSeen, patchesMade, i As Integer
        While i <= data.Length - patternLen
            Dim ok As Boolean = True
            For j As Integer = 0 To patternLen - 1
                If sMask(j) = 0 AndAlso data(i + j) <> sBytes(j) Then
                    ok = False
                    Exit For
                End If
            Next
            If ok Then
                matchesSeen += 1
                If patchNumber = -1 OrElse matchesSeen = patchNumber Then
                    For k As Integer = 0 To patternLen - 1
                        If rMask(k) = 0 Then data(i + k) = rBytes(k)
                    Next
                    patchesMade += 1
                    If patchNumber <> -1 Then Exit While
                End If
            End If
            i += 1
        End While
        Return patchesMade
    End Function

    Private Sub ParseHexPattern(pattern As String, ByRef bytesOut As Byte(), ByRef maskOut As Byte())
        If pattern Is Nothing Then pattern = ""
        Dim norm As String = pattern.Replace(",", " ").Replace(vbTab, " ").Replace(vbCr, " ").Replace(vbLf, " ").Trim()
        Dim b As New List(Of Byte)(), mk As New List(Of Byte)()
        If norm.Length = 0 Then bytesOut = New Byte() {} : maskOut = New Byte() {} : Return
        For Each tok As String In norm.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
            tok = tok.Trim()
            If tok = "??" OrElse tok = "?" Then b.Add(0) : mk.Add(1) : Continue For
            If tok.StartsWith("0x", StringComparison.OrdinalIgnoreCase) Then tok = tok.Substring(2)
            If tok.Length <> 2 OrElse Not IsHex(tok) Then Throw New ArgumentException("Invalid hex token: " & tok)
            b.Add(Convert.ToByte(tok, 16)) : mk.Add(0)
        Next
        bytesOut = b.ToArray() : maskOut = mk.ToArray()
    End Sub

    Private Function IsHex(s As String) As Boolean
        For Each c As Char In s
            If Not ((c >= "0"c AndAlso c <= "9"c) OrElse (c >= "A"c AndAlso c <= "F"c) OrElse (c >= "a"c AndAlso c <= "f"c)) Then Return False
        Next
        Return True
    End Function
End Module
