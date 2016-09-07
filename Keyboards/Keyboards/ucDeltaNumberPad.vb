'Imports System.Windows.Forms.Application
Public Class ucDeltaNumberPad
    Inherits System.Windows.Forms.Form
    Dim btn(15) As Button
    Dim lbl(2) As Label
    Dim StrCursorPos As Int16
    Dim Loaded As Boolean = False

    Public Sub ListenForData()
        MessageBox.Show("DataReceived")
    End Sub
    Friend WithEvents ucKeyPad1 As Keyboards.ucKeyPad

    Private Sub InitializeComponent()
        Me.ucKeyPad1 = New Keyboards.ucKeyPad()
        Me.SuspendLayout()
        '
        'ucKeyPad1
        '
        Me.ucKeyPad1.Location = New System.Drawing.Point(0, 1)
        Me.ucKeyPad1.Name = "ucKeyPad1"
        Me.ucKeyPad1.Size = New System.Drawing.Size(500, 500)
        Me.ucKeyPad1.TabIndex = 0
        '
        'ucDeltaNumberPad
        '
        Me.ClientSize = New System.Drawing.Size(503, 501)
        Me.Controls.Add(Me.ucKeyPad1)
        Me.Name = "ucDeltaNumberPad"
        Me.ResumeLayout(False)

    End Sub
End Class