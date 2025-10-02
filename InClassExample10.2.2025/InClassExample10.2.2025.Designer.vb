<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InClassExampleForm
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
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.CalculateButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.EngineeringLabel = New System.Windows.Forms.Label()
        Me.EngineeringTextBox = New System.Windows.Forms.TextBox()
        Me.SuffixComboBox = New System.Windows.Forms.ComboBox()
        Me.ValueLabel = New System.Windows.Forms.Label()
        Me.ValueTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(629, 327)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(159, 111)
        Me.ExitButton.TabIndex = 0
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'CalculateButton
        '
        Me.CalculateButton.Location = New System.Drawing.Point(450, 327)
        Me.CalculateButton.Name = "CalculateButton"
        Me.CalculateButton.Size = New System.Drawing.Size(173, 111)
        Me.CalculateButton.TabIndex = 1
        Me.CalculateButton.Text = "Calculate"
        Me.CalculateButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.EngineeringLabel)
        Me.GroupBox1.Controls.Add(Me.EngineeringTextBox)
        Me.GroupBox1.Controls.Add(Me.SuffixComboBox)
        Me.GroupBox1.Controls.Add(Me.ValueLabel)
        Me.GroupBox1.Controls.Add(Me.ValueTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 100)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'EngineeringLabel
        '
        Me.EngineeringLabel.AutoSize = True
        Me.EngineeringLabel.Location = New System.Drawing.Point(302, 75)
        Me.EngineeringLabel.Name = "EngineeringLabel"
        Me.EngineeringLabel.Size = New System.Drawing.Size(82, 16)
        Me.EngineeringLabel.TabIndex = 4
        Me.EngineeringLabel.Text = "Engineering:"
        '
        'EngineeringTextBox
        '
        Me.EngineeringTextBox.Location = New System.Drawing.Point(390, 72)
        Me.EngineeringTextBox.Name = "EngineeringTextBox"
        Me.EngineeringTextBox.Size = New System.Drawing.Size(100, 22)
        Me.EngineeringTextBox.TabIndex = 3
        '
        'SuffixComboBox
        '
        Me.SuffixComboBox.FormattingEnabled = True
        Me.SuffixComboBox.Items.AddRange(New Object() {"T (tera)", "G (giga)", "M (mega)", "K (kilo)", "(None)", "m (mil)", "u (micro)", "n (nano)", "p (pico)"})
        Me.SuffixComboBox.Location = New System.Drawing.Point(442, 21)
        Me.SuffixComboBox.Name = "SuffixComboBox"
        Me.SuffixComboBox.Size = New System.Drawing.Size(121, 24)
        Me.SuffixComboBox.TabIndex = 2
        '
        'ValueLabel
        '
        Me.ValueLabel.AutoSize = True
        Me.ValueLabel.Location = New System.Drawing.Point(285, 24)
        Me.ValueLabel.Name = "ValueLabel"
        Me.ValueLabel.Size = New System.Drawing.Size(45, 16)
        Me.ValueLabel.TabIndex = 1
        Me.ValueLabel.Text = "Value:"
        '
        'ValueTextBox
        '
        Me.ValueTextBox.Location = New System.Drawing.Point(336, 21)
        Me.ValueTextBox.Name = "ValueTextBox"
        Me.ValueTextBox.Size = New System.Drawing.Size(100, 22)
        Me.ValueTextBox.TabIndex = 0
        '
        'InClassExampleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CalculateButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Name = "InClassExampleForm"
        Me.Text = "Pretty Numbers"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ExitButton As Button
    Friend WithEvents CalculateButton As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ValueLabel As Label
    Friend WithEvents ValueTextBox As TextBox
    Friend WithEvents SuffixComboBox As ComboBox
    Friend WithEvents EngineeringLabel As Label
    Friend WithEvents EngineeringTextBox As TextBox
End Class
