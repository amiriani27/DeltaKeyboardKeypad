<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.lblString = New System.Windows.Forms.Label()
        Me.lblNumber = New System.Windows.Forms.Label()
        Me.txtString = New System.Windows.Forms.TextBox()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ucLabel = New Keyboards.ucMultiStateIndicator()
        Me.SuspendLayout()
        '
        'lblString
        '
        Me.lblString.AutoSize = True
        Me.lblString.Location = New System.Drawing.Point(45, 34)
        Me.lblString.Name = "lblString"
        Me.lblString.Size = New System.Drawing.Size(34, 13)
        Me.lblString.TabIndex = 0
        Me.lblString.Text = "String"
        '
        'lblNumber
        '
        Me.lblNumber.AutoSize = True
        Me.lblNumber.Location = New System.Drawing.Point(45, 58)
        Me.lblNumber.Name = "lblNumber"
        Me.lblNumber.Size = New System.Drawing.Size(44, 13)
        Me.lblNumber.TabIndex = 1
        Me.lblNumber.Text = "Number"
        '
        'txtString
        '
        Me.txtString.Location = New System.Drawing.Point(95, 31)
        Me.txtString.Name = "txtString"
        Me.txtString.Size = New System.Drawing.Size(150, 20)
        Me.txtString.TabIndex = 2
        '
        'txtNumber
        '
        Me.txtNumber.Location = New System.Drawing.Point(95, 55)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(150, 20)
        Me.txtNumber.TabIndex = 3
        Me.txtNumber.Text = "1.234"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(321, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 33)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(220, 89)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(70, 33)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ucLabel
        '
        Me.ucLabel.Location = New System.Drawing.Point(308, 89)
        Me.ucLabel.Name = "ucLabel"
        Me.ucLabel.Size = New System.Drawing.Size(104, 39)
        Me.ucLabel.State = Keyboards.ucMultiStateIndicator.eSTATE.Idle
        Me.ucLabel.TabIndex = 4
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 204)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ucLabel)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.txtString)
        Me.Controls.Add(Me.lblNumber)
        Me.Controls.Add(Me.lblString)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblString As System.Windows.Forms.Label
    Friend WithEvents lblNumber As System.Windows.Forms.Label
    Friend WithEvents txtString As System.Windows.Forms.TextBox
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents ucLabel As Keyboards.ucMultiStateIndicator
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
