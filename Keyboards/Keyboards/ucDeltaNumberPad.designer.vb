<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeltaNumberPad
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
        Me.ucKeyPad1 = New Keyboards.ucKeyPad()
        Me.SuspendLayout()
        '
        'ucKeyPad1
        '
        Me.ucKeyPad1.Location = New System.Drawing.Point(0, 0)
        Me.ucKeyPad1.Name = "ucKeyPad1"
        Me.ucKeyPad1.Size = New System.Drawing.Size(500, 500)
        Me.ucKeyPad1.TabIndex = 0
        '
        'DeltaNumberPad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(492, 466)
        Me.ControlBox = False
        Me.Controls.Add(Me.ucKeyPad1)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(300, 370)
        Me.Name = "DeltaNumberPad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Delta Numeric Entry"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucKeyPad1 As Keyboards.ucKeyPad
End Class
