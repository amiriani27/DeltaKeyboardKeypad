Public Class frmMain
    Dim iTemp As Integer

    Private Sub txtNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumber.Click
        Dim Description As String
        Dim OldValue As String
        Dim NewValue As String
        Dim Min As Double
        Dim Max As Double
        Dim Ints_Only As Boolean
        Dim Check_Limits As Boolean
        Ints_Only = True
        Check_Limits = True
        Check_Limits = False
        OldValue = Val(txtNumber.Text)
        g_dblDataEntry = OldValue
        Description = "ADI Inspection Timeout"

        g_caption = Description & _
        " ( Old Value: " & Format(g_dblDataEntry, "#00") & " Seconds before Alarm)"
        Min = 1
        Max = 600
        'PopKeyPad(0, Check_Limits, Min, Max, Ints_Only, g_caption, "")
        
        ''Dim frmKeyPad As New ucDeltaNumberPad

        ''frmKeyPad.ucKeyPad1.LimitsActive = True
        ''frmKeyPad.ucKeyPad1.LowLimit = Min
        ''frmKeyPad.ucKeyPad1.HighLimit = Max
        ''frmKeyPad.ucKeyPad1.IntegersOnly = True

        ''frmKeyPad.Show()

        g_dblDataEntry = Val(g_DeltaNumberPadValue) '0.1.5

        'NewValue = Format(Val((g_dblDataEntry)), "#00")

        txtNumber.Text = g_dblDataEntry
    End Sub

    Private Sub txtString_Click(sender As System.Object, e As System.EventArgs) Handles txtString.Click
        g_strDataEntryCaption = "Enter the New Recipe Name"
        g_strDataEntry = txtString.Text
        PopKeyBoard(g_strDataEntry, False)

        txtString.Text = g_DeltaKeyboardValue

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ucLabel.State = iTemp
        iTemp += 1

        If iTemp > 4 Then iTemp = 0
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        
    End Sub
End Class
