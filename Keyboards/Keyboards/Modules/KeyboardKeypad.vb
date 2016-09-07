Module KeyboardKeypad
    'Keyboard & Keypad Variables
    Public g_min As Double
    Public g_max As Double
    Public g_intonly As Boolean
    Public g_caption As String
    Public g_checkminmax As Boolean
    Public g_txtPasswordChar As String
    Public g_strNumericEntry As String
    Public g_strDataEntry As String
    Public g_strDataEntryCaption As String
    Public g_dblDataEntry As Double
    Public g_DeltaKeyboardValue As String
    Public g_DeltaNumberPadValue As Single
    Public g_KeyboardEntry As String
    Public WithEvents DeltaKeyBoardChild As DeltaKeyboard
    Public WithEvents DeltaNumberPadChild As DeltaNumberPad

    Public Function PopKeyBoard(ByRef old_string As String, ByRef Password_Character As Boolean) As String
        Dim Result As DialogResult
        Try
            g_strDataEntry = old_string
            DeltaKeyBoardChild = New DeltaKeyboard(g_strDataEntry, Password_Character)
            Result = DeltaKeyBoardChild.ShowDialog
            Return g_DeltaKeyboardValue
        Catch ex As Exception
            Return vbNullString
        End Try
    End Function

    Public Function PopKeyPad(ByRef old_Number As Double, ByRef Show_MinMax As Boolean, ByRef Min As Double, ByRef Max As Double, ByRef Ints_Only As Boolean, ByRef Caption As String, ByRef Password_Character As String) As Object
        'Dim Result As DialogResult
        'Try
        '    g_strDataEntry = CStr(old_Number)
        '    'g_txtPasswordChar = Password_Character
        '    g_checkminmax = Show_MinMax
        '    g_min = Min
        '    g_max = Max
        '    g_intonly = Ints_Only
        '    g_caption = Caption
        '    DeltaNumberPadChild = New DeltaNumberPad(g_strDataEntry, g_checkminmax, g_intonly, g_min, g_max, Password_Character)
        '    Result = DeltaNumberPadChild.ShowDialog
        '    Return g_DeltaNumberPadValue
        'Catch ex As Exception
        '    Return vbNullString
        'End Try
    End Function

End Module
