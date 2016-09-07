Public Class ucMultiStateIndicator

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum eSTATE
        NoState = 0
        Pass = 1
        Fail = 2
        Idle = 3
        Testing = 4
    End Enum

    Private _state As eSTATE
    Private _initText As String = ""
    Private _initBackColor As Color

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MultiStateIndicator_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ctlLabel.Text = _initText
        ctlLabel.BackColor = _initBackColor
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MultiStateIndicator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ctlLabel.Top = 0
        ctlLabel.Left = 0
        ctlLabel.Width = Me.Width
        ctlLabel.Height = Me.Height

        _initText = ctlLabel.Text
        _initBackColor = ctlLabel.BackColor
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sState"></param>
    ''' <remarks></remarks>
    Private Sub SetState(ByVal sState As eSTATE)
        If ctlLabel Is Nothing Then
            Exit Sub
        End If

        Try
            Select Case sState
                Case eSTATE.Pass
                    'ctlLabel.Text = gTranslator.GetMessage("Pass", gEnglishSelected)
                    ctlLabel.Text = "Pass"
                    ctlLabel.BackColor = Color.LightGreen
                Case eSTATE.Fail
                    'ctlLabel.Text = gTranslator.GetMessage("Fail", gEnglishSelected)
                    ctlLabel.Text = "Fail"
                    ctlLabel.BackColor = Color.Red
                Case eSTATE.Idle
                    'ctlLabel.Text = gTranslator.GetMessage("Idle", gEnglishSelected)
                    ctlLabel.Text = "Idle"
                    ctlLabel.BackColor = Color.White
                Case eSTATE.Testing
                    'ctlLabel.Text = gTranslator.GetMessage("Testing", gEnglishSelected)
                    ctlLabel.Text = "Testing"
                    ctlLabel.BackColor = Color.Yellow
                Case Else
                    'ctlLabel.Text = gTranslator.GetMessage("n/a", gEnglishSelected)
                    ctlLabel.Text = "n/a"
                    ctlLabel.BackColor = _initBackColor
            End Select
        Catch ex As Exception
            ctlLabel.Text = ""
            ctlLabel.BackColor = _initBackColor
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property State() As eSTATE
        Get
            Return _state
        End Get
        Set(ByVal value As eSTATE)
            _state = value

            SetState(_state)
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="inInteger"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetState_fromInteger(ByVal inInteger As Integer) As eSTATE
        Select Case inInteger
            Case 0
                Return eSTATE.NoState
            Case 1
                Return eSTATE.Pass
            Case 2
                Return eSTATE.Fail
            Case 3
                Return eSTATE.Idle
            Case 4
                Return eSTATE.Testing
            Case Else
                Return eSTATE.NoState
        End Select
    End Function
End Class
