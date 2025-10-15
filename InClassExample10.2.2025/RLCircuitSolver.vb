Imports System.Globalization
Imports System.IO.Ports

Public Class RLCircuitSolverForm

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click
        Dim vgen, rgen, f, r1, r1Rec, c1, c1Rec, c2, c2Rec, l1, l1Rec, rw As Decimal
        Dim zl1, zl1Rec, xc1, xc1Rec, xc2, xc2Rec, xl1, xl1Rec, zeq, zeqRec, zt, ztRec, it, itRec, vrgen, vrgenRec, vr1, vr1Rec, vc1, vc1Rec, vpara, vparaRec, ic2, ic2Rec, il1, il1Rec, pt, ptRec As (Decimal, Decimal)
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
            xc1 = (SolveXc(c1, f), -90.0)
            xc2 = (SolveXc(c2, f), -90.0)
            xl1 = (SolveXl(l1, f), 90.0)
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
                OutputListBox.Items.Add($"Zt(pol)={ConvertToEngineering(zt.Item1)}Ω{ChrW(8736)}{ConvertToEngineering(zt.Item2)}°")
                OutputListBox.Items.Add($"It(pol)={ConvertToEngineering(it.Item1)}A{ChrW(8736)}{ConvertToEngineering(it.Item2)}°")
                OutputListBox.Items.Add($"R1(pol)={ConvertToEngineering(r1)}Ω")
                OutputListBox.Items.Add($"C1(pol)={ConvertToEngineering(c1)}F")
                OutputListBox.Items.Add($"C2(pol)={ConvertToEngineering(c2)}F")
                OutputListBox.Items.Add($"L1(pol)={ConvertToEngineering(l1)}H")
                OutputListBox.Items.Add($"Xc1(pol)={ConvertToEngineering(xc1.Item1)}Ω{ChrW(8736)}{ConvertToEngineering(xc1.Item2)}°")
                OutputListBox.Items.Add($"Xc2(pol)={ConvertToEngineering(xc2.Item1)}Ω{ChrW(8736)}{ConvertToEngineering(xc2.Item2)}°")
                OutputListBox.Items.Add($"Xl1(pol)={ConvertToEngineering(xl1.Item1)}Ω{ChrW(8736)}{ConvertToEngineering(xl1.Item2)}°")
                OutputListBox.Items.Add($"Zl1(pol)={ConvertToEngineering(zl1.Item1)}Ω{ChrW(8736)}{ConvertToEngineering(zl1.Item2)}°")
                OutputListBox.Items.Add($"Zeq(pol)={ConvertToEngineering(zeq.Item1)}Ω{ChrW(8736)}{ConvertToEngineering(zeq.Item2)}°")
                OutputListBox.Items.Add($"Vrgen(pol)={ConvertToEngineering(vrgen.Item1)}V{ChrW(8736)}{ConvertToEngineering(vrgen.Item2)}°")
                OutputListBox.Items.Add($"Vr1(pol)={ConvertToEngineering(vr1.Item1)}V{ChrW(8736)}{ConvertToEngineering(vr1.Item2)}°")
                OutputListBox.Items.Add($"Vc1(pol)={ConvertToEngineering(vc1.Item1)}V{ChrW(8736)}{ConvertToEngineering(vc1.Item2)}°")
                OutputListBox.Items.Add($"Vc2(pol)={ConvertToEngineering(vpara.Item1)}V{ChrW(8736)}{ConvertToEngineering(vpara.Item2)}°")
                OutputListBox.Items.Add($"Vl1(pol)={ConvertToEngineering(vpara.Item1)}V{ChrW(8736)}{ConvertToEngineering(vpara.Item2)}°")
                OutputListBox.Items.Add($"Irgen(pol)={ConvertToEngineering(it.Item1)}A{ChrW(8736)}{ConvertToEngineering(it.Item2)}°")
                OutputListBox.Items.Add($"Ir1(pol)={ConvertToEngineering(it.Item1)}A{ChrW(8736)}{ConvertToEngineering(it.Item2)}°")
                OutputListBox.Items.Add($"Ic1(pol)={ConvertToEngineering(it.Item1)}A{ChrW(8736)}{ConvertToEngineering(it.Item2)}°")
                OutputListBox.Items.Add($"Ic2(pol)={ConvertToEngineering(ic2.Item1)}A{ChrW(8736)}{ConvertToEngineering(ic2.Item2)}°")
                OutputListBox.Items.Add($"Il1(pol)={ConvertToEngineering(il1.Item1)}A{ChrW(8736)}{ConvertToEngineering(il1.Item2)}°")
                OutputListBox.Items.Add($"Pt(pol)={ConvertToEngineering(pt.Item1)}W{ChrW(8736)}{ConvertToEngineering(pt.Item2)}°")
            ElseIf RectangularRadioButton.Checked Then
                r1Rec = PolarToRectangular(r1, 0).Item1
                c1Rec = PolarToRectangular(c1, -90.0).Item2
                c2Rec = PolarToRectangular(c2, -90.0).Item2
                l1Rec = PolarToRectangular(l1, 90.0).Item2
                zl1Rec = PolarToRectangular(SolveZl(rw, l1, f).Item1, SolveZl(rw, l1, f).Item2)
                xc1Rec = PolarToRectangular(SolveXc(c1, f), -90.0)
                xc2Rec = PolarToRectangular(SolveXc(c2, f), -90.0)
                xl1Rec = PolarToRectangular(SolveXl(l1, f), 90.0)
                zeqRec = PolarToRectangular(SolveZeq(zl1, xc2).Item1, SolveZeq(zl1, xc2).Item2)
                ztRec = PolarToRectangular(SolveZt((r1 + rgen, 0), xc1, zeq).Item1, SolveZt((r1 + rgen, 0), xc1, zeq).Item2)
                itRec = PolarToRectangular(vgen / zt.Item1, -1 * zt.Item2)
                vrgenRec = PolarToRectangular(it.Item1 * rgen, it.Item2)
                vr1Rec = PolarToRectangular(it.Item1 * r1, it.Item2)
                vc1Rec = PolarToRectangular(it.Item1 * xc1.Item1, it.Item2 + xc1.Item2)
                vparaRec = PolarToRectangular(it.Item1 * zeq.Item1, it.Item2 + zeq.Item2)
                ic2Rec = PolarToRectangular(vpara.Item1 / xc2.Item1, vpara.Item2 - xc2.Item2)
                il1Rec = PolarToRectangular(vpara.Item1 / zl1.Item1, vpara.Item2 - zl1.Item2)
                ptRec = PolarToRectangular(CDec(VoltageTrackBar.Value) * it.Item1, 0.000)
                OutputListBox.Items.Add($"Zt(rec)={ConvertToEngineering(ztRec.Item1)}+ j{ConvertToEngineering(ztRec.Item2)}")
                OutputListBox.Items.Add($"It(rec)={ConvertToEngineering(itRec.Item1)}+ j{ConvertToEngineering(itRec.Item2)}")
                OutputListBox.Items.Add($"R1={ConvertToEngineering(r1)}Ω")
                OutputListBox.Items.Add($"C1={ConvertToEngineering(c1)}F")
                OutputListBox.Items.Add($"C2={ConvertToEngineering(c2)}F")
                OutputListBox.Items.Add($"L1={ConvertToEngineering(l1)}H")
                OutputListBox.Items.Add($"Xc1(rec)={ConvertToEngineering(0.000)}+ j{ConvertToEngineering(xc1Rec.Item2)}")
                OutputListBox.Items.Add($"Xc2(rec)={ConvertToEngineering(0.000)}+ j{ConvertToEngineering(xc2Rec.Item2)}")
                OutputListBox.Items.Add($"Xl1(rec)={ConvertToEngineering(0.000)}+ j{ConvertToEngineering(xl1Rec.Item2)}")
                OutputListBox.Items.Add($"Zl1(rec)={ConvertToEngineering(zl1Rec.Item1)}+ j{ConvertToEngineering(zl1Rec.Item2)}")
                OutputListBox.Items.Add($"Zeq(rec)={ConvertToEngineering(zeqRec.Item1)}+ j{ConvertToEngineering(zeqRec.Item2)}")
                OutputListBox.Items.Add($"Vrgen(rec)={ConvertToEngineering(vrgenRec.Item1)}+ j{ConvertToEngineering(vrgenRec.Item2)}")
                OutputListBox.Items.Add($"Vr1(rec)={ConvertToEngineering(vr1Rec.Item1)}+ j{ConvertToEngineering(vr1Rec.Item2)}")
                OutputListBox.Items.Add($"Vc1(rec)={ConvertToEngineering(vc1Rec.Item1)}+ j{ConvertToEngineering(vc1Rec.Item2)}")
                OutputListBox.Items.Add($"Vc2(rec)={ConvertToEngineering(vparaRec.Item1)}+ j{ConvertToEngineering(vparaRec.Item2)}")
                OutputListBox.Items.Add($"Vl1(rec)={ConvertToEngineering(vparaRec.Item1)}+ j{ConvertToEngineering(vparaRec.Item2)}")
                OutputListBox.Items.Add($"Irgen(rec)={ConvertToEngineering(itRec.Item1)}+ j{ConvertToEngineering(itRec.Item2)}")
                OutputListBox.Items.Add($"Ir1(rec)={ConvertToEngineering(itRec.Item1)}+ j{ConvertToEngineering(itRec.Item2)}")
                OutputListBox.Items.Add($"Ic1(rec)={ConvertToEngineering(itRec.Item1)}+ j{ConvertToEngineering(itRec.Item2)}")
                OutputListBox.Items.Add($"Ic2(rec)={ConvertToEngineering(ic2Rec.Item1)}+ j{ConvertToEngineering(ic2Rec.Item2)}")
                OutputListBox.Items.Add($"Il1(rec)={ConvertToEngineering(il1Rec.Item1)}+ j{ConvertToEngineering(il1Rec.Item2)}")
                OutputListBox.Items.Add($"Pt(rec)={ConvertToEngineering(ptRec.Item1)} + j{ConvertToEngineering(ptRec.Item2)}")
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

    Function SolveXl(inductance As Decimal, frequency As Decimal) As Decimal
        Dim result As Decimal
        result = 2 * Math.PI * inductance * frequency
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


    'Sub Write()
    '    Dim data(0) As Byte 'put bytes into array
    '    data(0) = &B11110000 'actual data as a byte
    '    SerialPort1.Write(data, 0, 1) 'send bytes as an array, start at index 0,
    'End Sub

    'Sub Connect()
    '    SerialPort1.BaudRate = 115200 'Q@ Board Default
    '    SerialPort1.Parity = IO.Ports.Parity.None
    '    SerialPort1.StopBits = IO.Ports.StopBits.None
    '    SerialPort1.DataBits = 8
    '    SerialPort1.PortName = "COM2" 'This will change often

    '    SerialPort1.Open()

    'End Sub

    'Private Sub SerialPortForm_Click(sender As Object, e As EventArgs) Handles Me.Click
    '    Connect()
    '    Write()
    'End Sub

    'Private Sub SerialPort1_DataReceived(sender As Object, e As EventArgs) Handles SerialDataRecievedEnvenlope
    '    Try
    '        Me.Text = CStr(SerialPort1.BytesToRead)
    '    Catch ex As Exception
    '    End Try
    '    Read()
    'End Sub

    'Sub Read()
    '    Dim data(SerialPort1.BytesToRead) As Byte

    '    SerialPort1.Read(data, 0, BytesToRead)
    '    For i = 0 To UBound(data)
    '        Console.WriteLine($"Byte {i}: {Chr(data(i))}")
    '    Next

    '    Console.WriteLine($"Is this Q@ Board: {IsQuietBoard(data)}")
    '    Console.WriteLine(UBound(data))

    'End Sub

    'Function IsQuietBoard(data() As Byte) As Boolean

    '    If UBound(data) = 64 And Chr(data(60)) = "@" Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

End Class