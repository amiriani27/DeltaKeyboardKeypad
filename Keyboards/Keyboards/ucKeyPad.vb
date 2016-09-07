Public Class ucKeyPad
    Dim btn(15) As Button
    Dim lbl(2) As Label
    Dim StrCursorPos As Int16
    Dim Loaded As Boolean = False

    Private _limitsActive As Boolean
    Private _integersOnly As Boolean
    Private _lowLimit As Double
    Private _highLimit As Double
    Private _passwordChar As String

    Public Event DataEntered()

    Private Sub ucKeyPad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim a As Int16

        Try
            'Add the Buttons to the Form (0-9, Enter, Backspace, Cancel)
            For a = 0 To 14
                btn(a) = New Button
                Me.Controls.Add(btn(a))
                AddHandler btn(a).MouseClick, AddressOf btn_MouseClick
            Next

            'Add the Labels
            For a = 0 To 1
                lbl(a) = New Label
                Me.Controls.Add(lbl(a))
            Next

            Me.Width = My.Settings.NumPadW
            Me.Height = My.Settings.NumPadH

            BuildKeys()
            Loaded = True

            DeltaNumberPadChild.Text = g_caption
            txtDataEntry.Text = ""

            txtDataEntry.SelectionStart = (txtDataEntry.Text.Length)
            StrCursorPos = txtDataEntry.Text.Length

            'Enable Decimal Point if Desired
            btn(12).Enabled = True
            If _integersOnly = True Then
                btn(12).Enabled = False
            End If

            txtDataEntry.PasswordChar = _passwordChar
        Catch ex As Exception
            
        End Try
    End Sub


    Public WriteOnly Property LastValue() As String
        Set(ByVal Value As String)
            If Value <> 0 Then
                Me.txtDataEntry.Text = Value
            End If
        End Set
    End Property


    Public WriteOnly Property LimitsActive() As Boolean
        Set(ByVal Value As Boolean)
            _limitsActive = Value
        End Set
    End Property


    Public WriteOnly Property LowLimit() As Double
        Set(ByVal Value As Double)
            _lowLimit = Value
        End Set
    End Property


    Public WriteOnly Property HighLimit() As Double
        Set(ByVal Value As Double)
            _highLimit = Value
        End Set
    End Property


    Public WriteOnly Property IntegersOnly() As Double
        Set(ByVal Value As Double)
            _integersOnly = Value
        End Set
    End Property


    Private Sub DeltaNumberPad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If _limitsActive Then
                    If txtDataEntry.Text = "" Or Val(txtDataEntry.Text) < _lowLimit Or Val(txtDataEntry.Text) > _highLimit Then
                        MsgBox("Invalid entry.  Value must be between " + Str(_lowLimit) + " and " + Str(_highLimit) + ".", MsgBoxStyle.Exclamation, "Invalid Entry")
                        Exit Sub
                    End If
                End If
                g_DeltaNumberPadValue = Me.txtDataEntry.Text
                ''Me.DialogResult = Windows.Forms.DialogResult.OK
                RaiseEvent DataEntered()
                Me.Hide()
            End If
        Catch ex As Exception
            '     g_GEM_ErrorDesc = "DeltaNumberPad.KeyDown Error: " & ex.ToString
            '     g_GEMGenericError = True
            '     g_Exception = g_GEM_ErrorDesc
            '    g_WriteErrorToFile = True
        End Try
    End Sub


    Private Sub BuildKeys()
        Try
            txtDataEntry.Left = Me.Width / 2 - txtDataEntry.Width / 2
            Dim f As Int16 = 18
            Dim a, w, y As Int16
            Dim m As Int16 = 3 'margin around each key
            Dim leftmargin As Int16 = (Me.Width - ((Me.Width / 16 * 13) + (Me.Width / 16 * 2.2)) - (3 * m)) / 2
            Me.txtDataEntry.Left = Me.Width / 2 - txtDataEntry.Width / 2
            For a = 0 To 14
                Select Case a
                    Case 0 To 2, 4 To 6, 8 To 10, 12 To 14
                        w = (Me.Width / 6) - (2 * m)   '1,2,3,4,5,6,7,8,9,0,.,±
                    Case 3, 7, 11
                        w = ((Me.Width / 6 * 2.5) - 2 * m)
                End Select
                Select Case a
                    Case 0 To 3
                        y = txtDataEntry.Bottom + 4 * m
                    Case 4 To 7
                        y = btn(0).Bottom + m '(Me.Height / 8) + m
                    Case 8 To 11
                        y = btn(4).Bottom + m '(2 * Me.Height / 8) + m
                    Case 12 To 14
                        y = btn(8).Bottom + m '(3 * Me.Height / 8) + m
                End Select
                With btn(a)
                    .Height = (Me.Height - (180 + 3 * m)) / 4 '(Me.Height / 7) - (2 * m)
                    .Width = w
                    .Top = y
                    Select Case a
                        Case 0 To 2
                            .Left = leftmargin + (a * (w + (2 * m))) + 2 * m
                        Case 4 To 6
                            .Left = leftmargin + ((a - 4) * (w + (2 * m))) + 2 * m
                        Case 8 To 10
                            .Left = leftmargin + ((a - 8) * (w + (2 * m))) + 2 * m
                        Case 12 To 14
                            .Left = leftmargin + ((a - 12) * (w + (2 * m))) + 2 * m
                        Case 3, 7, 11
                            .Left = btn(2).Right + btn(0).Width / 4
                    End Select
                    Select Case a
                        Case 0
                            .Text = "7"
                        Case 1
                            .Text = "8"
                        Case 2
                            .Text = "9"
                        Case 3
                            .Text = "Enter"
                        Case 4
                            .Text = "4"
                        Case 5
                            .Text = "5"
                        Case 6
                            .Text = "6"
                        Case 7
                            .Text = "Backspace"
                        Case 8
                            .Text = "1"
                        Case 9
                            .Text = "2"
                        Case 10
                            .Text = "3"
                        Case 11
                            .Text = "Cancel"
                        Case 12
                            .Text = "."
                        Case 13
                            .Text = "0"
                        Case 14
                            .Text = "±"
                    End Select
                    .Font = New Font(.Font.Name, f, FontStyle.Regular, .Font.Unit)
                End With
            Next
            For a = 0 To 1
                With lbl(a)
                    Select Case a
                        Case 0
                            .Top = btn(12).Bottom + 3 * m
                            .Text = "MIN: " + Str(_lowLimit)
                        Case 1
                            .Top = lbl(0).Bottom + m
                            .Text = "MAX: " + Str(_highLimit)
                    End Select
                    .Height = 30
                    .Width = 300
                    .Left = btn(12).Left
                    .Font = New Font(.Font.Name, f, FontStyle.Regular, .Font.Unit)
                    .Enabled = _limitsActive
                End With
            Next
        Catch ex As Exception
            '    g_GEM_ErrorDesc = "DeltaNumberPad.BuildKeys Error: " & ex.ToString
            '    g_GEMGenericError = True
            '    g_Exception = g_GEM_ErrorDesc
            '    g_WriteErrorToFile = True
        End Try
    End Sub


    Private Sub btn_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim b As Int16
        Dim s1, s2 As String
        Try
            For b = 0 To 60
                If sender Is btn(b) Then Exit For
            Next

            Select Case b
                Case 0 To 2, 4 To 6, 8 To 10, 13 '7,8,9,4,5,6,1,2,3,0
                    ' Me.txtDataEntry.Text += btn(b).Text
                    ' StrCursorPos = txtDataEntry.Text.Length
                    s1 = Microsoft.VisualBasic.Left(txtDataEntry.Text, txtDataEntry.SelectionStart)
                    s2 = Microsoft.VisualBasic.Right(txtDataEntry.Text, txtDataEntry.Text.Length - txtDataEntry.SelectionStart - txtDataEntry.SelectionLength)
                    s1 += btn(b).Text
                    Me.txtDataEntry.Text = s1 + s2
                    txtDataEntry.SelectionStart = s1.Length
                Case 12
                    If InStr(txtDataEntry.Text, ".") = 0 Then
                        '    Me.txtDataEntry.Text += btn(b).Text
                        '    StrCursorPos = txtDataEntry.Text.Length
                        s1 = Microsoft.VisualBasic.Left(txtDataEntry.Text, txtDataEntry.SelectionStart)
                        s2 = Microsoft.VisualBasic.Right(txtDataEntry.Text, txtDataEntry.Text.Length - txtDataEntry.SelectionStart - txtDataEntry.SelectionLength)
                        s1 += btn(b).Text
                        Me.txtDataEntry.Text = s1 + s2
                        txtDataEntry.SelectionStart = s1.Length
                    End If
                Case 14
                    If InStr(txtDataEntry.Text, "-") = 0 Then
                        txtDataEntry.Text = "-" + txtDataEntry.Text
                    Else
                        txtDataEntry.Text = Microsoft.VisualBasic.Right(txtDataEntry.Text, txtDataEntry.Text.Length - 1)
                    End If
                    txtDataEntry.SelectionStart = txtDataEntry.Text.Length
                Case 7 'backspace
                    If txtDataEntry.SelectionLength > 0 Then
                        '    s1 = Microsoft.VisualBasic.Left(txtDataEntry.Text, txtDataEntry.SelectionStart)
                        '    s2 = Microsoft.VisualBasic.Right(txtDataEntry.Text, txtDataEntry.Text.Length - txtDataEntry.SelectionStart - txtDataEntry.SelectionLength)
                        '    txtDataEntry.Text = s1 + s2
                        s1 = Microsoft.VisualBasic.Left(txtDataEntry.Text, txtDataEntry.SelectionStart)
                        s2 = Microsoft.VisualBasic.Right(txtDataEntry.Text, txtDataEntry.Text.Length - txtDataEntry.SelectionStart - txtDataEntry.SelectionLength)
                        txtDataEntry.Text = s1 + s2
                        txtDataEntry.SelectionStart = s1.Length
                    Else
                        If txtDataEntry.Text.Length > 0 And txtDataEntry.SelectionStart > 0 Then
                            '    s1 = Microsoft.VisualBasic.Left(txtDataEntry.Text, StrCursorPos - 1)
                            '    s2 = Microsoft.VisualBasic.Right(txtDataEntry.Text, txtDataEntry.Text.Length - StrCursorPos - txtDataEntry.SelectionLength)
                            '    txtDataEntry.Text = s1 + s2
                            '    StrCursorPos -= 1
                            s1 = Microsoft.VisualBasic.Left(txtDataEntry.Text, txtDataEntry.SelectionStart - 1)
                            s2 = Microsoft.VisualBasic.Right(txtDataEntry.Text, txtDataEntry.Text.Length - txtDataEntry.SelectionStart)
                            txtDataEntry.Text = s1 + s2
                            txtDataEntry.SelectionStart = s1.Length
                        End If
                    End If
                Case 3 'If Return
                    If _limitsActive Then
                        If txtDataEntry.Text = "" Or Val(txtDataEntry.Text) < _lowLimit Or Val(txtDataEntry.Text) > _highLimit Then
                            MsgBox("Invalid entry.  Value must be between " + Str(_lowLimit) + " and " + Str(_highLimit) + ".", MsgBoxStyle.Exclamation, "Invalid Entry")
                            Exit Select
                        End If
                    End If
                    g_DeltaNumberPadValue = Me.txtDataEntry.Text
                    'Me.DialogResult = Windows.Forms.DialogResult.OK
                    RaiseEvent DataEntered()
                    Me.Hide()
                Case 11
                    'Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    g_DeltaNumberPadValue = g_dblDataEntry
                    Me.Hide()
            End Select
            txtDataEntry.Select()
        Catch ex As Exception
            '    g_GEM_ErrorDesc = "DeltaNumberPad.btn_MouseClick Error: " & ex.ToString
            '    g_GEMGenericError = True
            '    g_Exception = g_GEM_ErrorDesc
            '    g_WriteErrorToFile = True
        End Try
    End Sub


    Private Sub txtDataEntry_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDataEntry.MouseClick
        StrCursorPos = txtDataEntry.SelectionStart
    End Sub


    Private Sub DeltaNumberPad_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Not Loaded Then Exit Sub
        If Loaded Then BuildKeys()
        My.Settings.NumPadH = Me.Height
        My.Settings.NumPadW = Me.Width
    End Sub
End Class
