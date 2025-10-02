Public Class InClassExampleForm
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click
        Call SomeRandomBullshit()
        'If ValueTextBox.Text <> "" And IsNumeric(ValueTextBox.Text) Then
        '    If SuffixComboBox.SelectedItem.ToString = "T (tera)" Then
        '        EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ 12} T")
        '    ElseIf SuffixComboBox.SelectedItem.ToString = "G (giga)" Then
        '        EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ 9} G")
        '    ElseIf SuffixComboBox.SelectedItem.ToString = "M (mega)" Then
        '        EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ 6} M")
        '    ElseIf SuffixComboBox.SelectedItem.ToString = "K (kilo)" Then
        '        EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ 3} k")
        '    ElseIf SuffixComboBox.SelectedItem.ToString = "(None)" Then
        '        EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ 0}")
        '    ElseIf SuffixComboBox.SelectedItem.ToString = "m (mil)" Then
        '        EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ -3} m")
        '    ElseIf SuffixComboBox.SelectedItem.ToString = "u (micro)" Then
        '        EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ -6} k")
        '    ElseIf SuffixComboBox.SelectedItem.ToString = "n (nano)" Then
        '        EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ -9} u")
        '    ElseIf SuffixComboBox.SelectedItem.ToString = "p (pico)" Then
        '        EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ -12} p")
        '    End If
        'End If
    End Sub

    Public Sub SomeRandomBullshit()
        If ValueTextBox.Text <> "" And IsNumeric(ValueTextBox.Text) Then
            If (CDec(ValueTextBox.Text) / 10 ^ 12) >= 1 And (CDec(ValueTextBox.Text) / 10 ^ 12) < 999 Then
                EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ 12} T")
            ElseIf (CDec(ValueTextBox.Text) / 10 ^ 9) >= 1 And (CDec(ValueTextBox.Text) / 10 ^ 9) < 999 Then
                EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ 9} G")
            ElseIf (CDec(ValueTextBox.Text) / 10 ^ 6) >= 1 And (CDec(ValueTextBox.Text) / 10 ^ 6) < 999 Then
                EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ 6} M")
            ElseIf (CDec(ValueTextBox.Text) / 10 ^ 3) >= 1 And (CDec(ValueTextBox.Text) / 10 ^ 3) < 999 Then
                EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ 3} k")
            ElseIf (CDec(ValueTextBox.Text) / 10 ^ 0) >= 1 And (CDec(ValueTextBox.Text) / 10 ^ 0) < 999 Then
                EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ 0}")
            ElseIf (CDec(ValueTextBox.Text) / 10 ^ -3) >= 1 And (CDec(ValueTextBox.Text) / 10 ^ -3) < 999 Then
                EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ -3} m")
            ElseIf (CDec(ValueTextBox.Text) / 10 ^ -6) >= 1 And (CDec(ValueTextBox.Text) / 10 ^ -6) < 999 Then
                EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ -6} u")
            ElseIf (CDec(ValueTextBox.Text) / 10 ^ -9) >= 1 And (CDec(ValueTextBox.Text) / 10 ^ -9) < 999 Then
                EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ -9} n")
            ElseIf (CDec(ValueTextBox.Text) / 10 ^ -12) >= 1 And (CDec(ValueTextBox.Text) / 10 ^ -12) < 999 Then
                EngineeringTextBox.Text = ($"{CDec(ValueTextBox.Text) / 10 ^ -12} p")
            End If
        End If
    End Sub

End Class
