Imports System.Globalization

Public Class InClassExampleForm

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click
        Dim vgen, rgen, f, r1, c1, c2, l1, rw As Decimal
        Dim zl1, xc1, xc2, zeq, zt, it, vrgen, vr1, vc1, vpara, ic2, il1, pt As (Decimal, Decimal)
        If IsUserInputValid() = True Then
            vgen = CDec(VoltageTrackBar.Value)
            If RgenComboBox.SelectedIndex = 0 Then
                rgen = 50
            ElseIf RgenComboBox.SelectedIndex = 1 Then
                rgen = 400
            End If
            f = UnconvertFromEngineering(CDec(FrequencyTextBox.Text), FrequencyComboBox.SelectedItem)
            r1 = UnconvertFromEngineering(CDec(R1ComboBox.SelectedItem), R1SuffexComboBox.SelectedItem)
            c1 = UnconvertFromEngineering(CDec(C1ComboBox.SelectedItem), C1SuffixComboBox.SelectedItem)
            c2 = UnconvertFromEngineering(CDec(C2ComboBox.SelectedItem), C2SuffixComboBox.SelectedItem)
            l1 = UnconvertFromEngineering(CDec(L1ComboBox.SelectedItem), L1SuffixComboBox.SelectedItem)
            rw = CDec(WindingTextBox.Text)
            zl1 = SolveZl(rw, l1, f)
            xc1 = (SolveXc(c1, f), -90)
            xc2 = (SolveXc(c2, f), -90)
            zeq = SolveZeq(zl1, xc2)
            zt = SolveZt((r1 + rgen, 0), xc1, zeq)
            it = (vgen / zt.Item1, -1 * zt.Item2)
            vrgen = (it.Item1 * rgen, it.Item2)
            vr1 = (it.Item1 * r1, it.Item2)
            vc1 = (it.Item1 * xc1.Item1, it.Item2 + xc1.Item2)
            vpara = (it.Item1 * zeq.Item1, it.Item2 + zeq.Item2)
            ic2 = (vpara.Item1 / xc2.Item1, vpara.Item2 - xc2.Item2)
            il1 = (vpara.Item1 / zl1.Item1, vpara.Item2 - zl1.Item2)
            pt = (CDec(VoltageTrackBar.Value) * it.Item1, 0.000)
            If PolarRadioButton.Checked Then
                OutputListBox.Items.Add($"Xc1={ConvertToEngineering(xc1.Item1)}Ω{ChrW(8736)}{ConvertToEngineering(xc1.Item2)}°")
                OutputListBox.Items.Add($"Zl1(pol)={ConvertToEngineering(zl1.Item1)}Ω{ChrW(8736)}{ConvertToEngineering(zl1.Item2)}°")
                OutputListBox.Items.Add($"Zeq(pol)={ConvertToEngineering(zeq.Item1)}Ω{ChrW(8736)}{ConvertToEngineering(zeq.Item2)}°")
                OutputListBox.Items.Add($"Zt(pol)={ConvertToEngineering(zt.Item1)}Ω{ChrW(8736)}{ConvertToEngineering(zt.Item2)}°")
                OutputListBox.Items.Add($"It(pol)={ConvertToEngineering(it.Item1)}A{ChrW(8736)}{ConvertToEngineering(it.Item2)}°")
                OutputListBox.Items.Add($"Vrgen(pol)={ConvertToEngineering(vrgen.Item1)}V{ChrW(8736)}{ConvertToEngineering(vrgen.Item2)}°")
                OutputListBox.Items.Add($"Vr1(pol)={ConvertToEngineering(vr1.Item1)}V{ChrW(8736)}{ConvertToEngineering(vr1.Item2)}°")
                OutputListBox.Items.Add($"Vc1(pol)={ConvertToEngineering(vc1.Item1)}V{ChrW(8736)}{ConvertToEngineering(vc1.Item2)}°")
                OutputListBox.Items.Add($"Vc2(pol)={ConvertToEngineering(vpara.Item1)}V{ChrW(8736)}{ConvertToEngineering(vpara.Item2)}°")
                OutputListBox.Items.Add($"Vl1(pol)={ConvertToEngineering(vpara.Item1)}V{ChrW(8736)}{ConvertToEngineering(vpara.Item2)}°")
                OutputListBox.Items.Add($"Ic2(pol)={ConvertToEngineering(ic2.Item1)}A{ChrW(8736)}{ConvertToEngineering(ic2.Item2)}°")
                OutputListBox.Items.Add($"Il1(pol)={ConvertToEngineering(il1.Item1)}A{ChrW(8736)}{ConvertToEngineering(il1.Item2)}°")
                OutputListBox.Items.Add($"Pt(pol)={ConvertToEngineering(pt.Item1)}W{ChrW(8736)}{ConvertToEngineering(pt.Item2)}°")
            ElseIf RectangularRadioButton.Checked Then
                OutputListBox.Items.Add($"Zl1(rec)={ConvertToEngineering(PolarToRectangular(zl1.Item1, zl1.Item2).Item1)} + j{ConvertToEngineering(PolarToRectangular(zl1.Item1, zl1.Item2).Item2)}")
            End If
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles VoltageTrackBar.Scroll
        VoltageLabel.Text = ($"{VoltageTrackBar.Value} V")
    End Sub

    Private Sub InClassExampleForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetDefaults()
    End Sub

    Sub SetDefaults()
        FrequencyComboBox.SelectedIndex = 1
        RgenComboBox.SelectedIndex = 0
        R1ComboBox.SelectedIndex = 6
        R1SuffexComboBox.SelectedIndex = 2
        C1ComboBox.SelectedIndex = 0
        C1SuffixComboBox.SelectedIndex = 0
        C2ComboBox.SelectedIndex = 0
        C2SuffixComboBox.SelectedIndex = 0
        L1ComboBox.SelectedIndex = 3
        L1SuffixComboBox.SelectedIndex = 0
        WindingTextBox.Text = 20
        FrequencyTextBox.Text = 1
        VoltageTrackBar.Value = 5
        PolarRadioButton.Checked = True
    End Sub

    Function IsUserInputValid() As Boolean
        Dim result As Boolean = False
        Dim message As String = ""

        If FrequencyTextBox.Text = "" Or IsNumeric(FrequencyTextBox.Text) = False Then
            message = "Frequency must be a number"
        ElseIf CDec(FrequencyTextBox.Text) < 1 Or CDec(UnconvertFromEngineering(CDec(FrequencyTextBox.Text), FrequencyComboBox.SelectedItem)) > 1000000 Then
            message = "Frequency must be between 1 - 1MHz"
        Else
            result = True
        End If

        If RgenComboBox.Text = "" Then
            message += ($"{vbNewLine}Rgen must be a number")
        ElseIf CDec(RgenComboBox.Text) < 250 Then
            RgenComboBox.SelectedIndex = 0
        ElseIf CDec(RgenComboBox.Text) >= 250 Then
            RgenComboBox.SelectedIndex = 1
        Else
            result = True
        End If

        If CDec(WindingTextBox.Text) < 1 Or CDec(WindingTextBox.Text) > 1000 Then
            message += "Winding resistance must be between 1 - 1KΩ"
        Else
            result = True
        End If

        If message <> "" Then
            result = False
            MsgBox(message)
        End If

        Return result
    End Function

    Function SolveZeq(zl1 As (Decimal, Decimal), xc2 As (Decimal, Decimal)) As (Decimal, Decimal)
        Dim zeq As (Decimal, Decimal)
        Dim yl1 As Decimal = 1 / zl1.Item1
        Dim bc2 As Decimal = 1 / xc2.Item1
        Dim yl1Phase As Decimal = -1 * zl1.Item2
        Dim bc2Phase As Decimal = -1 * xc2.Item2
        Dim real1 As Decimal = PolarToRectangular(yl1, yl1Phase).Item1
        Dim imaginary1 As Decimal = PolarToRectangular(yl1, yl1Phase).Item2
        Dim real2 As Decimal = PolarToRectangular(bc2, bc2Phase).Item1
        Dim imaginary2 As Decimal = PolarToRectangular(bc2, bc2Phase).Item2
        Dim totalRectangular As (Decimal, Decimal) = (real1 + real2, imaginary1 + imaginary2)
        Dim totalPolar As (Decimal, Decimal) = RectangularToPolar(totalRectangular.Item1, totalRectangular.Item2)
        zeq = (1 / totalPolar.Item1, -1 * totalPolar.Item2)
        Return zeq
    End Function

    Function ConvertToEngineering(unconvertedItem As String)
        Dim finalValue As String
        If unconvertedItem <> "" And IsNumeric(unconvertedItem) Then
            If (CDec(unconvertedItem) / 10 ^ 12) >= 1 And (CDec(unconvertedItem) / 10 ^ 12) < 1000 Then
                If CDec((CDec(unconvertedItem) / 10 ^ 12).ToString("0.000")) = 1000.0 Then
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ 15).ToString("0.000")} P")
                Else
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ 12).ToString("0.000")} T")
                End If
            ElseIf (CDec(unconvertedItem) / 10 ^ 9) >= 1 And (CDec(unconvertedItem) / 10 ^ 9) < 1000 Then
                If CDec((CDec(unconvertedItem) / 10 ^ 9).ToString("0.000")) = 1000.0 Then
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ 12).ToString("0.000")} T")
                Else
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ 9).ToString("0.000")} G")
                End If
            ElseIf (CDec(unconvertedItem) / 10 ^ 6) >= 1 And (CDec(unconvertedItem) / 10 ^ 6) < 1000 Then
                If CDec((CDec(unconvertedItem) / 10 ^ 6).ToString("0.000")) = 1000.0 Then
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ 9).ToString("0.000")} G")
                Else
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ 6).ToString("0.000")} M")
                End If
            ElseIf (CDec(unconvertedItem) / 10 ^ 3) >= 1 And (CDec(unconvertedItem) / 10 ^ 3) < 1000 Then
                If CDec(CDec(unconvertedItem) / 10 ^ 3).ToString("0.000") = 1000.0 Then
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ 6).ToString("0.000")} M")
                Else
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ 3).ToString("0.000")} k")
                End If
            ElseIf (CDec(unconvertedItem) / 10 ^ 0) >= 1 And (CDec(unconvertedItem) / 10 ^ 0) < 1000 Then
                If CDec((CDec(unconvertedItem) / 10 ^ 0).ToString("0.000")) = 1000.0 Then
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ 3).ToString("0.000")} k")
                Else
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ 0).ToString("0.000")}")
                End If
            ElseIf (CDec(unconvertedItem) / 10 ^ -3) >= 1 And (CDec(unconvertedItem) / 10 ^ -3) < 1000 Then
                If CDec((CDec(unconvertedItem) / 10 ^ -3).ToString("0.000")) = 1000.0 Then
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ 0).ToString("0.000")}")
                Else
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ -3).ToString("0.000")} m")
                End If
            ElseIf (CDec(unconvertedItem) / 10 ^ -6) >= 1 And (CDec(unconvertedItem) / 10 ^ -6) < 1000 Then
                If CDec((CDec(unconvertedItem) / 10 ^ -6).ToString("0.000")) = 1000.0 Then
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ -3).ToString("0.000")} m")
                Else
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ -6).ToString("0.000")} u")
                End If
            ElseIf (CDec(unconvertedItem) / 10 ^ -9) >= 1 And (CDec(unconvertedItem) / 10 ^ -9) < 1000 Then
                If CDec((CDec(unconvertedItem) / 10 ^ -9).ToString("0.000")) = 1000.0 Then
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ -6).ToString("0.000")} u")
                Else
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ -9).ToString("0.000")} n")
                End If
            ElseIf (CDec(unconvertedItem) / 10 ^ -12) >= 1 And (CDec(unconvertedItem) / 10 ^ -12) < 1000 Then
                If CDec((CDec(unconvertedItem) / 10 ^ -12).ToString("0.000")) = 1000.0 Then
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ -9).ToString("0.000")} n")
                Else
                    finalValue = ($"{(CDec(unconvertedItem) / 10 ^ -12).ToString("0.000")} p")
                End If
            ElseIf CDec(unconvertedItem) <= -0 Then
                finalValue = ($"{CDec(unconvertedItem).ToString("0.000")}")
            Else
                MsgBox("Number is either too big or too small.")
            End If
        End If
        Return finalValue
    End Function

    Function SolveXc(capacitance As Decimal, frequency As Decimal) As Decimal
        Dim result As Decimal
        result = 1 / (2 * Math.PI * capacitance * frequency)
        Return result
    End Function

    Function SolveZl(windingResistance As Decimal, inductance As Decimal, frequency As Decimal) As (Decimal, Decimal)
        Dim result As (Decimal, Decimal)
        result = RectangularToPolar(windingResistance, CDec(2 * Math.PI * frequency * inductance))
        Return result
    End Function

    Function SolveZt(r1 As (Decimal, Decimal), xc1 As (Decimal, Decimal), zeq As (Decimal, Decimal)) As (Decimal, Decimal)
        Dim zt As (Decimal, Decimal)
        Dim r1Rectangular As (Decimal, Decimal) = PolarToRectangular(r1.Item1, r1.Item2)
        Dim xc1Rectangular As (Decimal, Decimal) = PolarToRectangular(xc1.Item1, xc1.Item2)
        Dim zeqRectangular As (Decimal, Decimal) = PolarToRectangular(zeq.Item1, zeq.Item2)
        zt = RectangularToPolar(r1Rectangular.Item1 + xc1Rectangular.Item1 + zeqRectangular.Item1, r1Rectangular.Item2 + xc1Rectangular.Item2 + zeqRectangular.Item2)
        Return zt
    End Function

    Function RectangularToPolar(real As Decimal, imaginary As Decimal) As (Decimal, Decimal)
        Dim result As (Decimal, Decimal)
        result = (CDec(Math.Sqrt(real ^ 2 + imaginary ^ 2)), CDec(Math.Atan(imaginary / real) * (180 / Math.PI)))
        Return result
    End Function

    Function PolarToRectangular(real As Decimal, degrees As Decimal) As (Decimal, Decimal)
        Dim result As (Decimal, Decimal)
        degrees = degrees / (180 / Math.PI)
        result = (real * Math.Cos(degrees), real * Math.Sin(degrees))
        Return result
    End Function

    Function UnconvertFromEngineering(value As Decimal, suffix As String) As String
        Dim finalItem As Decimal

        Select Case suffix
            Case "MΩ", "MHz"
                finalItem = value * 10 ^ 6
            Case "KΩ", "KHz"
                finalItem = value * 10 ^ 3
            Case "Ω", "Hz"
                finalItem = value * 10 ^ 0
            Case "mH"
                finalItem = value * 10 ^ -3
            Case "µH", "µF"
                finalItem = value * 10 ^ -6
            Case "pF"
                finalItem = value * 10 ^ -12
            Case Else
                'finalItem = value * 10 ^ 3
        End Select

        Return finalItem
    End Function

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        SetDefaults()
        OutputListBox.Items.Clear()
    End Sub
End Class