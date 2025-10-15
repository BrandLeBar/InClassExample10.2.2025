<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RLCircuitSolverForm
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
        Me.FrequencyLabel = New System.Windows.Forms.Label()
        Me.FrequencyTextBox = New System.Windows.Forms.TextBox()
        Me.VoltageTrackBar = New System.Windows.Forms.TrackBar()
        Me.VoltageLabel = New System.Windows.Forms.Label()
        Me.RgenComboBox = New System.Windows.Forms.ComboBox()
        Me.RgenLabel = New System.Windows.Forms.Label()
        Me.FrequencyComboBox = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.R1ComboBox = New System.Windows.Forms.ComboBox()
        Me.R1SuffexComboBox = New System.Windows.Forms.ComboBox()
        Me.C1ComboBox = New System.Windows.Forms.ComboBox()
        Me.C1SuffixComboBox = New System.Windows.Forms.ComboBox()
        Me.C2SuffixComboBox = New System.Windows.Forms.ComboBox()
        Me.C2ComboBox = New System.Windows.Forms.ComboBox()
        Me.L1SuffixComboBox = New System.Windows.Forms.ComboBox()
        Me.L1ComboBox = New System.Windows.Forms.ComboBox()
        Me.R1Label = New System.Windows.Forms.Label()
        Me.C1Label = New System.Windows.Forms.Label()
        Me.C2Label = New System.Windows.Forms.Label()
        Me.L1Label = New System.Windows.Forms.Label()
        Me.OutputListBox = New System.Windows.Forms.ListBox()
        Me.WindingTextBox = New System.Windows.Forms.TextBox()
        Me.WindingLabel = New System.Windows.Forms.Label()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.PolarRadioButton = New System.Windows.Forms.RadioButton()
        Me.RadioGroupBox = New System.Windows.Forms.GroupBox()
        Me.RectangularRadioButton = New System.Windows.Forms.RadioButton()
        CType(Me.VoltageTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadioGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(116, 301)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(86, 42)
        Me.ExitButton.TabIndex = 0
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'CalculateButton
        '
        Me.CalculateButton.Location = New System.Drawing.Point(27, 301)
        Me.CalculateButton.Name = "CalculateButton"
        Me.CalculateButton.Size = New System.Drawing.Size(83, 42)
        Me.CalculateButton.TabIndex = 1
        Me.CalculateButton.Text = "Calculate"
        Me.CalculateButton.UseVisualStyleBackColor = True
        '
        'FrequencyLabel
        '
        Me.FrequencyLabel.AutoSize = True
        Me.FrequencyLabel.Location = New System.Drawing.Point(2, 94)
        Me.FrequencyLabel.Name = "FrequencyLabel"
        Me.FrequencyLabel.Size = New System.Drawing.Size(74, 16)
        Me.FrequencyLabel.TabIndex = 1
        Me.FrequencyLabel.Text = "Frequency:"
        '
        'FrequencyTextBox
        '
        Me.FrequencyTextBox.Location = New System.Drawing.Point(82, 91)
        Me.FrequencyTextBox.Name = "FrequencyTextBox"
        Me.FrequencyTextBox.Size = New System.Drawing.Size(57, 22)
        Me.FrequencyTextBox.TabIndex = 0
        Me.FrequencyTextBox.Text = "1.000"
        '
        'VoltageTrackBar
        '
        Me.VoltageTrackBar.Location = New System.Drawing.Point(26, 31)
        Me.VoltageTrackBar.Name = "VoltageTrackBar"
        Me.VoltageTrackBar.Size = New System.Drawing.Size(156, 56)
        Me.VoltageTrackBar.TabIndex = 3
        '
        'VoltageLabel
        '
        Me.VoltageLabel.AutoSize = True
        Me.VoltageLabel.Location = New System.Drawing.Point(91, 12)
        Me.VoltageLabel.Name = "VoltageLabel"
        Me.VoltageLabel.Size = New System.Drawing.Size(34, 16)
        Me.VoltageLabel.TabIndex = 5
        Me.VoltageLabel.Text = "5 Vp"
        '
        'RgenComboBox
        '
        Me.RgenComboBox.FormattingEnabled = True
        Me.RgenComboBox.Items.AddRange(New Object() {"50 ", "400 "})
        Me.RgenComboBox.Location = New System.Drawing.Point(65, 119)
        Me.RgenComboBox.Name = "RgenComboBox"
        Me.RgenComboBox.Size = New System.Drawing.Size(74, 24)
        Me.RgenComboBox.TabIndex = 6
        Me.RgenComboBox.Text = "50"
        '
        'RgenLabel
        '
        Me.RgenLabel.AutoSize = True
        Me.RgenLabel.Location = New System.Drawing.Point(145, 124)
        Me.RgenLabel.Name = "RgenLabel"
        Me.RgenLabel.Size = New System.Drawing.Size(53, 16)
        Me.RgenLabel.TabIndex = 7
        Me.RgenLabel.Text = "Ω Rgen"
        '
        'FrequencyComboBox
        '
        Me.FrequencyComboBox.FormattingEnabled = True
        Me.FrequencyComboBox.Items.AddRange(New Object() {"MHz", "KHz", "Hz"})
        Me.FrequencyComboBox.Location = New System.Drawing.Point(145, 91)
        Me.FrequencyComboBox.Name = "FrequencyComboBox"
        Me.FrequencyComboBox.Size = New System.Drawing.Size(57, 24)
        Me.FrequencyComboBox.TabIndex = 8
        Me.FrequencyComboBox.Text = "KHz"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.InClassExample10._2._2025.My.Resources.Resources.AC_SeriesParallel
        Me.PictureBox1.Location = New System.Drawing.Point(208, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1142, 442)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'R1ComboBox
        '
        Me.R1ComboBox.FormattingEnabled = True
        Me.R1ComboBox.Items.AddRange(New Object() {"1", "2.2", "4.7", "10", "22", "47", "100"})
        Me.R1ComboBox.Location = New System.Drawing.Point(56, 151)
        Me.R1ComboBox.Name = "R1ComboBox"
        Me.R1ComboBox.Size = New System.Drawing.Size(83, 24)
        Me.R1ComboBox.TabIndex = 10
        Me.R1ComboBox.Text = "100.000"
        '
        'R1SuffexComboBox
        '
        Me.R1SuffexComboBox.FormattingEnabled = True
        Me.R1SuffexComboBox.Items.AddRange(New Object() {"MΩ", "KΩ", "Ω"})
        Me.R1SuffexComboBox.Location = New System.Drawing.Point(145, 151)
        Me.R1SuffexComboBox.Name = "R1SuffexComboBox"
        Me.R1SuffexComboBox.Size = New System.Drawing.Size(57, 24)
        Me.R1SuffexComboBox.TabIndex = 11
        Me.R1SuffexComboBox.Text = "Ω"
        '
        'C1ComboBox
        '
        Me.C1ComboBox.FormattingEnabled = True
        Me.C1ComboBox.Items.AddRange(New Object() {"1", "2.2", "4.7", "10", "22", "47", "100"})
        Me.C1ComboBox.Location = New System.Drawing.Point(56, 181)
        Me.C1ComboBox.Name = "C1ComboBox"
        Me.C1ComboBox.Size = New System.Drawing.Size(83, 24)
        Me.C1ComboBox.TabIndex = 12
        Me.C1ComboBox.Text = "1.000"
        '
        'C1SuffixComboBox
        '
        Me.C1SuffixComboBox.FormattingEnabled = True
        Me.C1SuffixComboBox.Items.AddRange(New Object() {"µF", "pF"})
        Me.C1SuffixComboBox.Location = New System.Drawing.Point(145, 181)
        Me.C1SuffixComboBox.Name = "C1SuffixComboBox"
        Me.C1SuffixComboBox.Size = New System.Drawing.Size(57, 24)
        Me.C1SuffixComboBox.TabIndex = 13
        Me.C1SuffixComboBox.Text = "µF"
        '
        'C2SuffixComboBox
        '
        Me.C2SuffixComboBox.FormattingEnabled = True
        Me.C2SuffixComboBox.Items.AddRange(New Object() {"µF", "pF"})
        Me.C2SuffixComboBox.Location = New System.Drawing.Point(145, 211)
        Me.C2SuffixComboBox.Name = "C2SuffixComboBox"
        Me.C2SuffixComboBox.Size = New System.Drawing.Size(57, 24)
        Me.C2SuffixComboBox.TabIndex = 15
        Me.C2SuffixComboBox.Text = "µF"
        '
        'C2ComboBox
        '
        Me.C2ComboBox.FormattingEnabled = True
        Me.C2ComboBox.Items.AddRange(New Object() {"1", "2.2", "4.7", "10", "22", "47", "100"})
        Me.C2ComboBox.Location = New System.Drawing.Point(56, 211)
        Me.C2ComboBox.Name = "C2ComboBox"
        Me.C2ComboBox.Size = New System.Drawing.Size(83, 24)
        Me.C2ComboBox.TabIndex = 14
        Me.C2ComboBox.Text = "1.000"
        '
        'L1SuffixComboBox
        '
        Me.L1SuffixComboBox.FormattingEnabled = True
        Me.L1SuffixComboBox.Items.AddRange(New Object() {"mH", "µH"})
        Me.L1SuffixComboBox.Location = New System.Drawing.Point(145, 241)
        Me.L1SuffixComboBox.Name = "L1SuffixComboBox"
        Me.L1SuffixComboBox.Size = New System.Drawing.Size(57, 24)
        Me.L1SuffixComboBox.TabIndex = 17
        Me.L1SuffixComboBox.Text = "mH"
        '
        'L1ComboBox
        '
        Me.L1ComboBox.FormattingEnabled = True
        Me.L1ComboBox.Items.AddRange(New Object() {"1", "2.2", "4.7", "10", "22", "47", "100"})
        Me.L1ComboBox.Location = New System.Drawing.Point(56, 241)
        Me.L1ComboBox.Name = "L1ComboBox"
        Me.L1ComboBox.Size = New System.Drawing.Size(83, 24)
        Me.L1ComboBox.TabIndex = 16
        Me.L1ComboBox.Text = "10.000"
        '
        'R1Label
        '
        Me.R1Label.AutoSize = True
        Me.R1Label.Location = New System.Drawing.Point(24, 154)
        Me.R1Label.Name = "R1Label"
        Me.R1Label.Size = New System.Drawing.Size(27, 16)
        Me.R1Label.TabIndex = 18
        Me.R1Label.Text = "R1:"
        '
        'C1Label
        '
        Me.C1Label.AutoSize = True
        Me.C1Label.Location = New System.Drawing.Point(24, 184)
        Me.C1Label.Name = "C1Label"
        Me.C1Label.Size = New System.Drawing.Size(26, 16)
        Me.C1Label.TabIndex = 19
        Me.C1Label.Text = "C1:"
        '
        'C2Label
        '
        Me.C2Label.AutoSize = True
        Me.C2Label.Location = New System.Drawing.Point(25, 214)
        Me.C2Label.Name = "C2Label"
        Me.C2Label.Size = New System.Drawing.Size(26, 16)
        Me.C2Label.TabIndex = 20
        Me.C2Label.Text = "C2:"
        '
        'L1Label
        '
        Me.L1Label.AutoSize = True
        Me.L1Label.Location = New System.Drawing.Point(27, 244)
        Me.L1Label.Name = "L1Label"
        Me.L1Label.Size = New System.Drawing.Size(24, 16)
        Me.L1Label.TabIndex = 21
        Me.L1Label.Text = "L1:"
        '
        'OutputListBox
        '
        Me.OutputListBox.FormattingEnabled = True
        Me.OutputListBox.ItemHeight = 16
        Me.OutputListBox.Location = New System.Drawing.Point(1182, 12)
        Me.OutputListBox.Name = "OutputListBox"
        Me.OutputListBox.Size = New System.Drawing.Size(225, 436)
        Me.OutputListBox.TabIndex = 22
        '
        'WindingTextBox
        '
        Me.WindingTextBox.Location = New System.Drawing.Point(56, 271)
        Me.WindingTextBox.Name = "WindingTextBox"
        Me.WindingTextBox.Size = New System.Drawing.Size(83, 22)
        Me.WindingTextBox.TabIndex = 23
        Me.WindingTextBox.Text = "20"
        '
        'WindingLabel
        '
        Me.WindingLabel.AutoSize = True
        Me.WindingLabel.Location = New System.Drawing.Point(145, 274)
        Me.WindingLabel.Name = "WindingLabel"
        Me.WindingLabel.Size = New System.Drawing.Size(57, 16)
        Me.WindingLabel.TabIndex = 24
        Me.WindingLabel.Text = "Ω Rwind"
        '
        'ClearButton
        '
        Me.ClearButton.Location = New System.Drawing.Point(26, 349)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(84, 41)
        Me.ClearButton.TabIndex = 25
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'PolarRadioButton
        '
        Me.PolarRadioButton.AutoSize = True
        Me.PolarRadioButton.Location = New System.Drawing.Point(6, 12)
        Me.PolarRadioButton.Name = "PolarRadioButton"
        Me.PolarRadioButton.Size = New System.Drawing.Size(60, 20)
        Me.PolarRadioButton.TabIndex = 26
        Me.PolarRadioButton.TabStop = True
        Me.PolarRadioButton.Text = "Polar"
        Me.PolarRadioButton.UseVisualStyleBackColor = True
        '
        'RadioGroupBox
        '
        Me.RadioGroupBox.Controls.Add(Me.RectangularRadioButton)
        Me.RadioGroupBox.Controls.Add(Me.PolarRadioButton)
        Me.RadioGroupBox.Location = New System.Drawing.Point(26, 396)
        Me.RadioGroupBox.Name = "RadioGroupBox"
        Me.RadioGroupBox.Size = New System.Drawing.Size(176, 94)
        Me.RadioGroupBox.TabIndex = 27
        Me.RadioGroupBox.TabStop = False
        '
        'RectangularRadioButton
        '
        Me.RectangularRadioButton.AutoSize = True
        Me.RectangularRadioButton.Location = New System.Drawing.Point(6, 38)
        Me.RectangularRadioButton.Name = "RectangularRadioButton"
        Me.RectangularRadioButton.Size = New System.Drawing.Size(101, 20)
        Me.RectangularRadioButton.TabIndex = 27
        Me.RectangularRadioButton.TabStop = True
        Me.RectangularRadioButton.Text = "Rectangular"
        Me.RectangularRadioButton.UseVisualStyleBackColor = True
        '
        'RLCircuitSolverForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1419, 502)
        Me.Controls.Add(Me.RadioGroupBox)
        Me.Controls.Add(Me.ClearButton)
        Me.Controls.Add(Me.WindingLabel)
        Me.Controls.Add(Me.WindingTextBox)
        Me.Controls.Add(Me.OutputListBox)
        Me.Controls.Add(Me.L1Label)
        Me.Controls.Add(Me.C2Label)
        Me.Controls.Add(Me.C1Label)
        Me.Controls.Add(Me.R1Label)
        Me.Controls.Add(Me.L1SuffixComboBox)
        Me.Controls.Add(Me.L1ComboBox)
        Me.Controls.Add(Me.C2SuffixComboBox)
        Me.Controls.Add(Me.C2ComboBox)
        Me.Controls.Add(Me.C1SuffixComboBox)
        Me.Controls.Add(Me.C1ComboBox)
        Me.Controls.Add(Me.R1SuffexComboBox)
        Me.Controls.Add(Me.R1ComboBox)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.FrequencyComboBox)
        Me.Controls.Add(Me.RgenLabel)
        Me.Controls.Add(Me.RgenComboBox)
        Me.Controls.Add(Me.VoltageLabel)
        Me.Controls.Add(Me.VoltageTrackBar)
        Me.Controls.Add(Me.FrequencyLabel)
        Me.Controls.Add(Me.FrequencyTextBox)
        Me.Controls.Add(Me.CalculateButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Name = "RLCircuitSolverForm"
        Me.Text = "Circuit Solver"
        CType(Me.VoltageTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadioGroupBox.ResumeLayout(False)
        Me.RadioGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ExitButton As Button
    Friend WithEvents CalculateButton As Button
    Friend WithEvents FrequencyLabel As Label
    Friend WithEvents FrequencyTextBox As TextBox
    Friend WithEvents VoltageTrackBar As TrackBar
    Friend WithEvents VoltageLabel As Label
    Friend WithEvents RgenComboBox As ComboBox
    Friend WithEvents RgenLabel As Label
    Friend WithEvents FrequencyComboBox As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents R1ComboBox As ComboBox
    Friend WithEvents R1SuffexComboBox As ComboBox
    Friend WithEvents C1ComboBox As ComboBox
    Friend WithEvents C1SuffixComboBox As ComboBox
    Friend WithEvents C2SuffixComboBox As ComboBox
    Friend WithEvents C2ComboBox As ComboBox
    Friend WithEvents L1SuffixComboBox As ComboBox
    Friend WithEvents L1ComboBox As ComboBox
    Friend WithEvents R1Label As Label
    Friend WithEvents C1Label As Label
    Friend WithEvents C2Label As Label
    Friend WithEvents L1Label As Label
    Friend WithEvents OutputListBox As ListBox
    Friend WithEvents WindingTextBox As TextBox
    Friend WithEvents WindingLabel As Label
    Friend WithEvents ClearButton As Button
    Friend WithEvents PolarRadioButton As RadioButton
    Friend WithEvents RadioGroupBox As GroupBox
    Friend WithEvents RectangularRadioButton As RadioButton
End Class
