Public Class DeltaKeyboard
    Inherits System.Windows.Forms.Form
    Dim CapsEn As Boolean = False
    Dim CapsLockEn As Boolean = False
    Dim btn(60) As Button
    Dim StrCursorPos As Int16
    Dim loaded As Boolean = False
    Public Sub New(ByVal initialValue As String, ByVal Use_Password_Char As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ValueFromParent = initialValue
        PasswordEntry = Use_Password_Char
    End Sub
    Public WriteOnly Property ValueFromParent() As String
        Set(ByVal Value As String)
            Me.txtDataEntry.Text = Value
        End Set
    End Property
    Public WriteOnly Property PasswordEntry() As Boolean
        Set(ByVal value As Boolean)
            txtDataEntry.UseSystemPasswordChar = value
        End Set
    End Property

    Private Sub DeltaKeyboard_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Text = g_strDataEntryCaption
    End Sub

    Private Sub DeltaKeyboard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                g_DeltaKeyboardValue = Me.txtDataEntry.Text
                Me.DialogResult = Windows.Forms.DialogResult.OK
                g_KeyboardEntry = True
                Me.Close()
            End If
        Catch ex As Exception
            '    g_GEM_ErrorDesc = "DeltaKeyboard.KeyDown Error: " & ex.ToString
            '    g_GEMGenericError = True
            '    g_Exception = g_GEM_ErrorDesc
            '    g_WriteErrorToFile = True
        End Try
    End Sub

    Private Sub DeltaKeyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As Int16
        ' Try
        For a = 0 To 58
            btn(a) = New Button
            Me.Controls.Add(btn(a))
            AddHandler btn(a).MouseClick, AddressOf btn_MouseClick
        Next
        Me.Width = My.Settings.KeybrdW
        Me.Height = My.Settings.KeybrdH
        BuildKeys()
        loaded = True
        txtDataEntry.SelectionStart = (txtDataEntry.Text.Length)
        StrCursorPos = txtDataEntry.Text.Length
        'Catch ex As Exception
        '    g_GEM_ErrorDesc = "DeltaKeyboard.Load Error: " & ex.ToString
        '    g_GEMGenericError = True
        '    g_Exception = g_GEM_ErrorDesc
        '    g_WriteErrorToFile = True
        'End Try
    End Sub
    Private Sub BuildKeys()
        Dim f As Int16 = 14
        Dim a, w, y As Int16
        Dim h As Int16
        Dim m As Int16 = 3 'margin around each key
        Dim kw As Double = (Me.Width - (8 * m)) / 15.2
        Dim leftmargin As Int16 = 2 * m '(Me.Width - (2 * m)) / 2
        Try
            txtDataEntry.Width = Me.Width - 36
            For a = 0 To 58
                Select Case a
                    'Row widths need to add up to 15.2 (e.g. 13 standard keys plus 2.2x on the Backspace key on top row)
                    Case 0 To 12, 15 To 26, 29 To 39, 42 To 51
                        w = kw - (2 * m) '(Me.Width / kw) - (2 * m)   '`,1,2,3,4,5,6,7,8,9,0,-,=, all standard keys
                    Case 13
                        w = kw * 2.2 - (2 * m) '(Me.Width / kw * 2.2) - (2 * m)   'Backspace
                    Case 14 'start of row 2
                        w = kw * 1.6 - (2 * m) 'Tab
                    Case 27
                        w = (kw * 1.6) - (2 * m) '\
                    Case 28
                        w = (kw * 1.7) - (2 * m) 'Caps
                    Case 40
                        w = (kw * 2.5) - (2 * m) 'Enter
                    Case 41
                        w = (kw * 2.5) - (2 * m) 'Left Shift
                    Case 52
                        w = (kw * 2.7) - (2 * m) 'Delete
                    Case 53 To 55, 57
                        w = (kw * 1.2) - (2 * m) 'Ctrl, Windows, Alt, Alt, Windows, Scroll Select, Ctrl
                    Case 56
                        w = (kw * 6.8) - (2 * m) + m 'Space
                    Case 58
                        w = (kw * 3.6) - (2 * m) + m 'Space
                End Select
                h = (Me.Height - txtDataEntry.Bottom - (4 * m)) / 5
                Select Case a
                    Case 0 To 13
                        y = txtDataEntry.Bottom + (2 * m)
                    Case 14 To 27
                        y = btn(0).Bottom + (2 * m)
                    Case 28 To 40
                        y = btn(14).Bottom + (2 * m) '(3 * Me.Height / 7) + m
                    Case 41 To 52
                        y = btn(28).Bottom + (2 * m) '(4 * Me.Height / 7) + m
                    Case 53 To 58
                        y = btn(41).Bottom + (2 * m) '(5 * Me.Height / 7) + m
                End Select
                With btn(a)

                    .Height = h - (4 * m) '(Me.Height / 7) - (2 * m)
                    .Width = w
                    .Top = y
                    Select Case a
                        Case 0 To 12
                            .Left = leftmargin + (a * (w + (2 * m))) + m
                        Case 13
                            .Left = btn(12).Right + m + m
                        Case 14
                            .Left = leftmargin + m
                        Case 15 To 26
                            .Left = btn(14).Right + m + ((a - 15) * (w + (2 * m))) + m
                        Case 27
                            .Left = btn(26).Right + m + m
                        Case 28
                            .Left = leftmargin + m
                        Case 29 To 39
                            .Left = btn(28).Right + m + m + ((a - 29) * (w + (2 * m)))
                        Case 40
                            .Left = btn(39).Right + m + m
                        Case 41
                            .Left = leftmargin + m
                        Case 42 To 51
                            .Left = btn(41).Right + m + m + ((a - 42) * (w + (2 * m)))
                        Case 52
                            .Left = btn(51).Right + m + m
                        Case 53 To 55
                            .Left = leftmargin + m + ((a - 53) * (w + (2 * m)))
                        Case 56 To 58
                            .Left = btn(a - 1).Right + m + m
                    End Select
                    If a = 27 Then  'Tweak width of \ key
                        .Width = btn(13).Right - btn(a - 1).Right - (2 * m)
                    End If
                    If a = 40 Then  'Tweak width of ENTER key
                        .Width = btn(13).Right - btn(a - 1).Right - (2 * m)
                    End If
                    If a = 52 Then  'Tweak width of DELETE key
                        .Width = btn(13).Right - btn(a - 1).Right - (2 * m)
                    End If
                    If a = 58 Then  'Tweak width of CANCEL key
                        .Width = btn(13).Right - btn(a - 1).Right - (2 * m)
                    End If
                    UpdateKey(a)
                    .Font = New Font(.Font.Name, f, FontStyle.Regular, .Font.Unit)
                End With
            Next
        Catch ex As Exception
            '      g_GEM_ErrorDesc = "DeltaKeyboard.BuildKeys Error: " & ex.ToString
            '      g_GEMGenericError = True
            '      g_Exception = g_GEM_ErrorDesc
            '      g_WriteErrorToFile = True
        End Try
    End Sub
    Private Sub UpdateKey(ByVal a As Int16)
        Try
            With btn(a)
                If CapsEn Or CapsLockEn Then
                    Select Case a
                        Case 0
                            .Text = "~"
                        Case 1
                            .Text = "!"
                        Case 2
                            .Text = "@"
                        Case 3
                            .Text = "#"
                        Case 4
                            .Text = "$"
                        Case 5
                            .Text = "%"
                        Case 6
                            .Text = "^"
                        Case 7
                            .Text = "&"
                        Case 8
                            .Text = "*"
                        Case 9
                            .Text = "("
                        Case 10
                            .Text = ")"
                        Case 11
                            .Text = "_"
                        Case 12
                            .Text = "+"
                        Case 13
                            .Text = "BKSP"
                        Case 14
                            .Text = "Tab"
                        Case 15
                            .Text = "Q"
                        Case 16
                            .Text = "W"
                        Case 17
                            .Text = "E"
                        Case 18
                            .Text = "R"
                        Case 19
                            .Text = "T"
                        Case 20
                            .Text = "Y"
                        Case 21
                            .Text = "U"
                        Case 22
                            .Text = "I"
                        Case 23
                            .Text = "O"
                        Case 24
                            .Text = "P"
                        Case 25
                            .Text = "{"
                        Case 26
                            .Text = "}"
                        Case 27
                            .Text = "|"
                        Case 28
                            .Text = "Caps"
                            If CapsLockEn Then
                                .BackColor = Color.Lime
                            Else
                                .BackColor = System.Drawing.SystemColors.ControlDark
                            End If
                        Case 29
                            .Text = "A"
                        Case 30
                            .Text = "S"
                        Case 31
                            .Text = "D"
                        Case 32
                            .Text = "F"
                        Case 33
                            .Text = "G"
                        Case 34
                            .Text = "H"
                        Case 35
                            .Text = "J"
                        Case 36
                            .Text = "K"
                        Case 37
                            .Text = "L"
                        Case 38
                            .Text = ":"
                        Case 39
                            .Text = """"
                        Case 40
                            .Text = "Enter" 'vbCr
                        Case 41
                            .Text = "Shift"
                            If CapsEn Then
                                .BackColor = Color.Lime
                            Else
                                .BackColor = System.Drawing.SystemColors.ControlDark
                            End If
                        Case 42
                            .Text = "Z"
                        Case 43
                            .Text = "X"
                        Case 44
                            .Text = "C"
                        Case 45
                            .Text = "V"
                        Case 46
                            .Text = "B"
                        Case 47
                            .Text = "N"
                        Case 48
                            .Text = "M"
                        Case 49
                            .Text = "<"
                        Case 50
                            .Text = ">"
                        Case 51
                            .Text = "?"
                        Case 52
                            .Text = "Delete"
                        Case 53
                            .Text = "Ctrl"
                        Case 54
                            .Text = " "
                        Case 55
                            .Text = "Alt"
                        Case 56
                            .Text = "Space"
                        Case 57
                            .Text = "Alt"
                        Case 58
                            .Text = "CANCEL"
                    End Select
                Else
                    Select Case a
                        Case 0
                            .Text = "'"
                        Case 1 To 9
                            .Text = a
                        Case 10
                            .Text = "0"
                        Case 11
                            .Text = "-"
                        Case 12
                            .Text = "="
                        Case 13
                            .Text = "BKSP"
                        Case 14
                            .Text = "Tab"
                        Case 15
                            .Text = "q"
                        Case 16
                            .Text = "w"
                        Case 17
                            .Text = "e"
                        Case 18
                            .Text = "r"
                        Case 19
                            .Text = "t"
                        Case 20
                            .Text = "y"
                        Case 21
                            .Text = "u"
                        Case 22
                            .Text = "i"
                        Case 23
                            .Text = "o"
                        Case 24
                            .Text = "p"
                        Case 25
                            .Text = "["
                        Case 26
                            .Text = "]"
                        Case 27
                            .Text = "\"
                        Case 28
                            .Text = "Caps"
                            If CapsLockEn Then
                                .BackColor = Color.Lime
                            Else
                                .BackColor = System.Drawing.SystemColors.ControlDark
                            End If
                        Case 29
                            .Text = "a"
                        Case 30
                            .Text = "s"
                        Case 31
                            .Text = "d"
                        Case 32
                            .Text = "f"
                        Case 33
                            .Text = "g"
                        Case 34
                            .Text = "h"
                        Case 35
                            .Text = "j"
                        Case 36
                            .Text = "k"
                        Case 37
                            .Text = "l"
                        Case 38
                            .Text = ";"
                        Case 39
                            .Text = "'"
                        Case 40
                            .Text = "Enter" 'vbCr
                        Case 41
                            .Text = "Shift"
                            If CapsEn Then
                                .BackColor = Color.Lime
                            Else
                                .BackColor = System.Drawing.SystemColors.ControlDark
                            End If
                        Case 42
                            .Text = "z"
                        Case 43
                            .Text = "x"
                        Case 44
                            .Text = "c"
                        Case 45
                            .Text = "v"
                        Case 46
                            .Text = "b"
                        Case 47
                            .Text = "n"
                        Case 48
                            .Text = "m"
                        Case 49
                            .Text = ","
                        Case 50
                            .Text = "."
                        Case 51
                            .Text = "/"
                        Case 52
                            .Text = "Delete"
                        Case 53
                            .Text = "Ctrl"
                        Case 54
                            .Text = " "
                        Case 55
                            .Text = "Alt"
                        Case 56
                            .Text = "Space"
                        Case 57
                            .Text = "Alt"
                        Case 58
                            .Text = "CANCEL"
                    End Select
                End If
            End With
        Catch ex As Exception
            '    g_GEM_ErrorDesc = "DeltaKeyboard.UpdateKey Error: " & ex.ToString
            '    g_GEMGenericError = True
            '    g_Exception = g_GEM_ErrorDesc
            '   g_WriteErrorToFile = True
        End Try
    End Sub
    Private Sub btn_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim a As Int16
        Dim b As Int16
        Dim length As Int16
        '        Dim e1 As KeyEventArgs
        '       e1 = New KeyEventArgs(Keys.Delete)
        Dim s1 As String
        Dim s2 As String
        'Dim pos As Int16 = txtDataEntry.Text

        Try
            For b = 0 To 58
                If sender Is btn(b) Then Exit For
            Next
            s1 = ""
            Select Case b
                Case 0 To 12, 15 To 27, 29 To 39, 42 To 51
                    s1 = Microsoft.VisualBasic.Left(txtDataEntry.Text, txtDataEntry.SelectionStart)
                    s2 = Microsoft.VisualBasic.Right(txtDataEntry.Text, txtDataEntry.Text.Length - txtDataEntry.SelectionStart - txtDataEntry.SelectionLength)
                    s1 += btn(b).Text
                    Me.txtDataEntry.Text = s1 + s2
                    txtDataEntry.SelectionStart = s1.Length
                Case 56
                    s1 = Microsoft.VisualBasic.Left(txtDataEntry.Text, txtDataEntry.SelectionStart)
                    s2 = Microsoft.VisualBasic.Right(txtDataEntry.Text, txtDataEntry.Text.Length - txtDataEntry.SelectionStart)
                    s1 += " "
                    Me.txtDataEntry.Text = s1 + s2
                    txtDataEntry.SelectionStart = s1.Length
                Case 13 'backspace
                    If txtDataEntry.SelectionLength > 0 Then
                        s1 = Microsoft.VisualBasic.Left(txtDataEntry.Text, txtDataEntry.SelectionStart)
                        s2 = Microsoft.VisualBasic.Right(txtDataEntry.Text, txtDataEntry.Text.Length - txtDataEntry.SelectionStart - txtDataEntry.SelectionLength)
                        txtDataEntry.Text = s1 + s2
                        txtDataEntry.SelectionStart = s1.Length
                    Else
                        If txtDataEntry.Text.Length > 0 And txtDataEntry.SelectionStart > 0 Then
                            s1 = Microsoft.VisualBasic.Left(txtDataEntry.Text, txtDataEntry.SelectionStart - 1)
                            s2 = Microsoft.VisualBasic.Right(txtDataEntry.Text, txtDataEntry.Text.Length - txtDataEntry.SelectionStart)
                            txtDataEntry.Text = s1 + s2
                            txtDataEntry.SelectionStart = s1.Length
                        End If
                    End If
                Case 52 'Delete
                    If txtDataEntry.SelectionLength > 0 Then
                        s1 = Microsoft.VisualBasic.Left(txtDataEntry.Text, txtDataEntry.SelectionStart)
                        s2 = Microsoft.VisualBasic.Right(txtDataEntry.Text, txtDataEntry.Text.Length - txtDataEntry.SelectionStart - txtDataEntry.SelectionLength)
                        txtDataEntry.Text = s1 + s2
                        txtDataEntry.SelectionStart = s1.Length
                    Else
                        If txtDataEntry.Text.Length > 0 Then
                            s1 = Microsoft.VisualBasic.Left(txtDataEntry.Text, txtDataEntry.SelectionStart)
                            length = txtDataEntry.Text.Length - txtDataEntry.SelectionStart - txtDataEntry.SelectionLength - 1
                            If length < 0 Then length = 0
                            s2 = Microsoft.VisualBasic.Right(txtDataEntry.Text, length)
                            txtDataEntry.Text = s1 + s2
                            txtDataEntry.SelectionStart = s1.Length
                        End If
                    End If
                Case 40 'If Return
                    g_DeltaKeyboardValue = Me.txtDataEntry.Text
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    g_KeyboardEntry = True
                    Me.Close()
                Case 58 'if cancel
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    g_KeyboardEntry = True
                    Me.Close()
            End Select
            txtDataEntry.Select()

            If sender Is btn(41) Then
                CapsEn = Not CapsEn
                For a = 0 To 58
                    UpdateKey(a)
                Next
            ElseIf sender Is btn(28) Then
                CapsLockEn = Not CapsLockEn
                CapsEn = False
                For a = 0 To 58
                    UpdateKey(a)
                Next
            Else
                CapsEn = False
                For a = 0 To 58
                    UpdateKey(a)
                Next
            End If
        Catch ex As Exception
            '    g_GEM_ErrorDesc = "DeltaKeyboard.btn_MouseClick Error: " & ex.ToString
            '    g_GEMGenericError = True
            '    g_Exception = g_GEM_ErrorDesc
            '    g_WriteErrorToFile = True
        End Try

    End Sub

    Private Sub txtDataEntry_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDataEntry.MouseClick
         StrCursorPos = txtDataEntry.SelectionStart
    End Sub

    Private Sub DeltaKeyboard_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Not loaded Then Exit Sub
        BuildKeys()
        My.Settings.KeybrdH = Me.Height
        My.Settings.KeybrdW = Me.Width
    End Sub
End Class