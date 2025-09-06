<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.FilePathTxt = New System.Windows.Forms.TextBox()
        Me.BrowseBtn = New System.Windows.Forms.Button()
        Me.BackupChk = New System.Windows.Forms.CheckBox()
        Me.PatchBtn = New System.Windows.Forms.Button()
        Me.FilePathGrp = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FilePathGrp.SuspendLayout()
        Me.SuspendLayout()
        '
        'FilePathTxt
        '
        Me.FilePathTxt.Location = New System.Drawing.Point(6, 21)
        Me.FilePathTxt.Name = "FilePathTxt"
        Me.FilePathTxt.ReadOnly = True
        Me.FilePathTxt.Size = New System.Drawing.Size(235, 22)
        Me.FilePathTxt.TabIndex = 1
        '
        'BrowseBtn
        '
        Me.BrowseBtn.Location = New System.Drawing.Point(256, 21)
        Me.BrowseBtn.Name = "BrowseBtn"
        Me.BrowseBtn.Size = New System.Drawing.Size(81, 25)
        Me.BrowseBtn.TabIndex = 2
        Me.BrowseBtn.Text = "Browse"
        Me.BrowseBtn.UseVisualStyleBackColor = True
        '
        'BackupChk
        '
        Me.BackupChk.AutoSize = True
        Me.BackupChk.Checked = True
        Me.BackupChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BackupChk.Location = New System.Drawing.Point(12, 81)
        Me.BackupChk.Name = "BackupChk"
        Me.BackupChk.Size = New System.Drawing.Size(103, 21)
        Me.BackupChk.TabIndex = 3
        Me.BackupChk.Text = "Backup File"
        Me.BackupChk.UseVisualStyleBackColor = True
        '
        'PatchBtn
        '
        Me.PatchBtn.Location = New System.Drawing.Point(268, 79)
        Me.PatchBtn.Name = "PatchBtn"
        Me.PatchBtn.Size = New System.Drawing.Size(81, 29)
        Me.PatchBtn.TabIndex = 4
        Me.PatchBtn.Text = "Patch"
        Me.PatchBtn.UseVisualStyleBackColor = True
        '
        'FilePathGrp
        '
        Me.FilePathGrp.Controls.Add(Me.FilePathTxt)
        Me.FilePathGrp.Controls.Add(Me.BrowseBtn)
        Me.FilePathGrp.Location = New System.Drawing.Point(12, 12)
        Me.FilePathGrp.Name = "FilePathGrp"
        Me.FilePathGrp.Size = New System.Drawing.Size(347, 61)
        Me.FilePathGrp.TabIndex = 5
        Me.FilePathGrp.TabStop = False
        Me.FilePathGrp.Text = "File Path:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Search And Replace by Jeff Steveanus"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 148)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FilePathGrp)
        Me.Controls.Add(Me.PatchBtn)
        Me.Controls.Add(Me.BackupChk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search and Replace Patcher"
        Me.TopMost = True
        Me.FilePathGrp.ResumeLayout(False)
        Me.FilePathGrp.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FilePathTxt As TextBox
    Friend WithEvents BrowseBtn As Button
    Friend WithEvents BackupChk As CheckBox
    Friend WithEvents PatchBtn As Button
    Friend WithEvents FilePathGrp As GroupBox
    Friend WithEvents Label1 As Label
End Class
