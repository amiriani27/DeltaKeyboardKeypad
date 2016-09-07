<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMultiStateIndicator
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ctlLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ctlLabel
        '
        Me.ctlLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctlLabel.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctlLabel.Location = New System.Drawing.Point(0, 0)
        Me.ctlLabel.Name = "ctlLabel"
        Me.ctlLabel.Size = New System.Drawing.Size(75, 32)
        Me.ctlLabel.TabIndex = 0
        Me.ctlLabel.Text = "Label1"
        Me.ctlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MultiStateIndicator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ctlLabel)
        Me.Name = "MultiStateIndicator"
        Me.Size = New System.Drawing.Size(75, 32)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ctlLabel As System.Windows.Forms.Label

End Class
