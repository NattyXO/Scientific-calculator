Imports System.Text
Imports System
Public Class Form1

    Dim firstInteger As Double
    Dim secondInteger As Double
    Dim answer As Double
    Dim operation As String
    Private lastInputWasOperator As Boolean = False
    Private dotUsed As Boolean = False
    Private lastInput As String = ""


    Private Sub ScientificToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScientificToolStripMenuItem.Click
        'Code for extend form
        Me.Height = 419
        Me.Width = 686
        txtAnswer.Width = 396
    End Sub

    Private Sub UnitConversionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnitConversionToolStripMenuItem.Click
        'Code for extend form
        Me.Height = 419
        Me.Width = 953
        txtAnswer.Width = 396
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'code to exit
        Application.Exit()
    End Sub


    Private Sub StandardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StandardToolStripMenuItem.Click
        'Code for extend form
        Me.Height = 419
        Me.Width = 289
        txtAnswer.Width = 263
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True ' Enable key events for the form

        Me.Height = 419
        Me.Width = 289
        txtAnswer.Width = 263

        ComboBox1.Text = "Choose one..."
        ComboBox1.Items.Add("Geez to Numeral")
        ComboBox1.Items.Add("Numeral to Geez")
        ComboBox1.Items.Add("Celsius to Fahrenheit")
        ComboBox1.Items.Add("Fahrenheit to Celsius")
        ComboBox1.Items.Add("Miles to Kilometres")
        ComboBox1.Items.Add("Kilometres to Miles")
        ComboBox1.Items.Add("Centimetre to Metres")
        ComboBox1.Items.Add("ASCII Character to Hexadecimal")
        ComboBox1.Items.Add("ASCII Character to Decimal")
        ComboBox1.Items.Add("ASCII Character to Binary")
        ComboBox1.Items.Add("Decimal to Hexadecimal")
        ComboBox1.Items.Add("Decimal to ASCII Character")
        ComboBox1.Items.Add("Decimal to Binary")
        ComboBox1.Items.Add("Binary to Hexadecimal")
        ComboBox1.Items.Add("Binary to ASCII Character")
        ComboBox1.Items.Add("Binary to Decimal")
        ComboBox1.Items.Add("Roman to Numeral")
        ComboBox1.Items.Add("Numeral to Roman")


    End Sub
    Private Function DecimalToHexadecimal(input As Decimal) As String
        Dim isNegative As Boolean = False

        ' Check if the input is negative
        If input < 0 Then
            isNegative = True
            input = Decimal.Negate(input)
        End If

        If Decimal.Remainder(input, 1) = 0 Then
            ' Integer input, process only the whole number part
            Dim wholePart As Long = Decimal.ToInt64(input)
            Dim hexWhole As String = ""

            While wholePart > 0
                Dim remainder As Long = wholePart Mod 16
                If remainder < 10 Then
                    hexWhole = remainder.ToString() & hexWhole
                Else
                    hexWhole = ChrW(55 + remainder) & hexWhole
                End If
                wholePart \= 16
            End While

            ' Add negative sign if needed
            If isNegative Then
                hexWhole = "-" & hexWhole
            End If

            Return hexWhole
        Else
            ' Fractional input, process both whole and fractional parts
            Dim wholePart As Long = Decimal.ToInt64(input)
            Dim fractionalPart As Decimal = input - wholePart

            Dim hexWhole As String = ""
            While wholePart > 0
                Dim remainder As Long = wholePart Mod 16
                If remainder < 10 Then
                    hexWhole = remainder.ToString() & hexWhole
                Else
                    hexWhole = ChrW(55 + remainder) & hexWhole
                End If
                wholePart \= 16
            End While

            Dim hexFractional As String = ""
            For i As Integer = 0 To 21 ' Considering 18 digits after the decimal point
                fractionalPart *= 16
                Dim digit As Long = Decimal.ToInt64(fractionalPart)
                If digit < 10 Then
                    hexFractional &= digit.ToString()
                Else
                    hexFractional &= ChrW(55 + digit)
                End If
                fractionalPart -= Decimal.Truncate(fractionalPart)
            Next

            ' Add negative sign if needed
            If isNegative Then
                hexWhole = "-" & hexWhole
            End If

            Return hexWhole & "." & hexFractional
        End If
    End Function



    Private Sub btnHex_Click(sender As Object, e As EventArgs) Handles btnHex.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert to hexadecimal.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for hexadecimal conversion.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim hexValue As String = DecimalToHexadecimal(input)
            newNode = New TreeNode(hexValue.ToString())
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large for conversion to hexadecimal.")
        End Try
    End Sub



    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for common logarithmic.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim log10Value As String = Math.Log10(input)
            newNode = New TreeNode(log10Value.ToString())
            lblTop.Text = log10Value
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub


    Private Sub btnCosh_Click(sender As Object, e As EventArgs) Handles btnCosh.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for hyperbolic cosine.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim coshValue As String = Math.Cosh(input)
            newNode = New TreeNode(coshValue.ToString())
            lblTop.Text = coshValue
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub

    Private Sub btnSinh_Click(sender As Object, e As EventArgs) Handles btnSinh.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for hyperbolic sine.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim sinhValue As String = Math.Sinh(input)
            newNode = New TreeNode(sinhValue.ToString())
            lblTop.Text = sinhValue
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub

    Private Sub btnTanh_Click(sender As Object, e As EventArgs) Handles btnTanh.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for hyperbolic tangent.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim tanhValue As String = Math.Tanh(input)
            newNode = New TreeNode(tanhValue.ToString())
            lblTop.Text = tanhValue
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub
    Private Sub btnln_Click(sender As Object, e As EventArgs) Handles btnln.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for log.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim logValue As String = Math.Log(input)
            newNode = New TreeNode(logValue.ToString())
            lblTop.Text = logValue
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If Not String.IsNullOrEmpty(txtAnswer.Text) Then
            txtAnswer.Text = txtAnswer.Text.Substring(0, txtAnswer.Text.Length - 1)
        End If
    End Sub

    Private Sub btnClearUnit_Click(sender As Object, e As EventArgs) Handles btnClearUnit.Click
        ' to clear unit convert
        Unitshow.Text = ""
        TextBox1.Text = ""
    End Sub

    Private Sub btnUnitConvert_Click(sender As Object, e As EventArgs) Handles btnUnitConvert.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MsgBox("Please enter a value for conversion.", vbInformation, "Info")
            Return
        End If

        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim inputValue As Long
            If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                MsgBox("Please enter a valid number for conversion.", vbInformation, "Info")
                Return
            End If

            Long.TryParse(TextBox1.Text, inputValue)
            Dim binaryInput As String = TextBox1.Text
            Dim decimaltobinaryinput As String = TextBox1.Text

            Dim result As Double
            Select Case ComboBox1.SelectedItem.ToString()
                ' ... (rest of your conversion cases)
                Case "Geez to Numeral"
                    Dim geezNumeral As String = binaryInput
                    Dim numericValue As Integer = GeezToNumber(geezNumeral)
                    Unitshow.Text = $"{numericValue}"
                Case "Numeral to Geez"
                    Dim number As Integer = binaryInput
                    Dim geezNumeral As String = NumberToGeez(number)
                    Unitshow.Text = $"{geezNumeral}"
                Case "Celsius to Fahrenheit"
                    result = (9 / 5 * inputValue) + 32
                    Unitshow.Text = $"{result} Fahrenheit"
                Case "Fahrenheit to Celsius"
                    result = 5 / 9 * (inputValue - 32)
                    Unitshow.Text = $"{result} Celsius"
                Case "Miles to Kilometres"
                    result = inputValue * 1.609344
                    Unitshow.Text = $"{result} Kilometres"
                Case "Kilometres to Miles"
                    result = inputValue / 1.609344
                    Unitshow.Text = $"{result} Miles"
                Case "Centimetre to Metres"
                    result = inputValue / 100
                    Unitshow.Text = $"{result} Metres"
                Case "ASCII Character to Hexadecimal"
                    Dim inputString As String = binaryInput
                    Dim conversionResult As String = ConvertAsciiStringToHex(inputString)
                    Unitshow.Text = conversionResult
                Case "ASCII Character to Decimal"
                    Dim inputString As String = binaryInput
                    Dim conversionResult As String = ConvertAsciiStringToDecimal(inputString)
                    Unitshow.Text = conversionResult
                Case "ASCII Character to Binary"
                    Dim inputString As String = binaryInput
                    Dim conversionResult As String = ConvertAsciiStringBinary(inputString)
                    Unitshow.Text = conversionResult
                Case "Decimal to Hexadecimal"
                    Dim decimalValue As Long = inputValue
                    Dim hexValue As String = Convert.ToString(decimalValue, 16)
                    Unitshow.Text = $"{hexValue}"
                Case "Decimal to ASCII Character"
                    Dim success As Boolean = Double.TryParse(TextBox1.Text, inputValue)
                    If success AndAlso inputValue >= 0 AndAlso inputValue <= 65535 Then
                        Dim decimalValue As Long = CInt(inputValue)
                        Dim outputChar As Char = ChrW(decimalValue)
                        Unitshow.Text = $"{outputChar}"
                    Else
                        MessageBox.Show("Invalid input. Please enter a valid number within the range of 0 to 65535.")
                    End If
                Case "Decimal to Binary"
                    Dim parsedValue As Long
                    If Long.TryParse(decimaltobinaryinput, parsedValue) Then
                        Dim binaryValue As String = DecimalToBinary(parsedValue)
                        Unitshow.Text = binaryValue ' Display the binary value
                    Else
                        MessageBox.Show("Invalid decimal input. Please enter a valid decimal number.")
                    End If

                Case "Binary to Hexadecimal"
                    Dim binaryValue As String = binaryInput
                    Dim hexValue As String = Convert.ToInt64(binaryValue, 2).ToString("X")
                    Unitshow.Text = $"{hexValue}"
                Case "Binary to ASCII Character"
                    Dim binaryValue As String = binaryInput
                    Dim decimalValue As Long = Convert.ToUInt64(binaryValue, 2)

                    If decimalValue >= 0 AndAlso decimalValue <= 65535 Then
                        Dim outputChar As Char = ChrW(decimalValue)
                        Unitshow.Text = $"{outputChar}"
                    Else
                        MessageBox.Show("The converted value is out of range for character representation.")
                    End If
                Case "Binary to Decimal"
                    Dim binaryNumber As String = binaryInput
                    Dim decimalResult As Long = BinaryToDecimal(binaryNumber)
                    Unitshow.Text = $"{decimalResult}"
                Case "Roman to Numeral"
                    Dim romanNumeral As String = binaryInput
                    Dim numberValue As Integer = RomanToNumber(romanNumeral)
                    Unitshow.Text = $"{numberValue}"
                Case "Numeral to Roman"
                    Dim inputNumber As Integer = binaryInput
                    Dim romanNumeral As String = NumberToRoman(inputNumber)
                    Unitshow.Text = $"{romanNumeral}"
                Case Else
                    MsgBox("Select a valid Unit of Conversion", vbInformation, "Info")
            End Select

        Else
            MsgBox("Please select a conversion type from the dropdown.", vbInformation, "Info")
        End If
    End Sub

    Private Function RomanToNumber(romanNumeral As String) As Integer
        Dim numeralValues As New Dictionary(Of Char, Integer) From {
        {"I", 1}, {"V", 5}, {"X", 10}, {"L", 50},
        {"C", 100}, {"D", 500}, {"M", 1000}
    }

        Dim result As Integer = 0

        For i As Integer = 0 To romanNumeral.Length - 1
            If i + 1 < romanNumeral.Length AndAlso numeralValues(romanNumeral(i)) < numeralValues(romanNumeral(i + 1)) Then
                result -= numeralValues(romanNumeral(i))
            Else
                result += numeralValues(romanNumeral(i))
            End If
        Next

        Return result
    End Function

    Private Function NumberToRoman(number As Integer) As String
        If number <= 0 OrElse number >= 10001 Then
            Return "Invalid number: Out of range" ' Handling out of range values
        End If

        Dim numeralMap As New Dictionary(Of Integer, String) From {
        {10000, "X̅"}, {9000, "M'X̅"}, {5000, "V̅"}, {4000, "M'V̅"},
        {1000, "M"}, {900, "CM"}, {500, "D"}, {400, "CD"},
        {100, "C"}, {90, "XC"}, {50, "L"}, {40, "XL"},
        {10, "X"}, {9, "IX"}, {5, "V"}, {4, "IV"}, {1, "I"}
    }

        Dim result As New StringBuilder()

        For Each kvp As KeyValuePair(Of Integer, String) In numeralMap
            While number >= kvp.Key
                result.Append(kvp.Value)
                number -= kvp.Key
            End While
        Next

        Return result.ToString()
    End Function

    Private Function GeezToNumber(geezString As String) As Integer
        Dim geezMap As New Dictionary(Of Char, Integer) From {
        {"፩", 1}, {"፪", 2}, {"፫", 3}, {"፬", 4}, {"፭", 5},
        {"፮", 6}, {"፯", 7}, {"፰", 8}, {"፱", 9}, {"፲", 10},
        {"፳", 20}, {"፴", 30}, {"፵", 40}, {"፶", 50}, {"፷", 60},
        {"፸", 70}, {"፹", 80}, {"፺", 90}, {"፻", 100}, {"፼", 1000}
    }

        Dim result As Integer = 0
        Dim currentValue As Integer = 0
        Dim previousValue As Integer = 0

        For i As Integer = geezString.Length - 1 To 0 Step -1
            Dim currentChar As Char = geezString(i)

            If geezMap.ContainsKey(currentChar) Then
                Dim value As Integer = geezMap(currentChar)

                If value >= previousValue Then
                    result += value
                Else
                    result -= value
                End If

                previousValue = value
            End If
        Next

        Return result
    End Function


    Private Function NumberToGeez(number As Integer) As String
        If number <= 0 OrElse number >= 10000 Then
            Return "Invalid number: Out of range" ' Handling out of range values
        End If

        Dim geezMap As New Dictionary(Of Integer, String) From {
        {1000, "፼"}, {900, "፻፼"}, {800, "፸፼"}, {700, "፷፼"}, {600, "፶፼"},
        {500, "፵፼"}, {400, "፴፼"}, {300, "፳፼"}, {200, "፲፼"}, {100, "፻"},
        {90, "፺"}, {80, "፹"}, {70, "፸"}, {60, "፷"}, {50, "፵"},
        {40, "፴"}, {30, "፳"}, {20, "፲"}, {10, "፲"}, {9, "፱"}, {8, "፰"},
        {7, "፯"}, {6, "፮"}, {5, "፭"}, {4, "፬"}, {3, "፫"}, {2, "፪"}, {1, "፩"}
    }

        Dim result As New StringBuilder()

        For Each kvp As KeyValuePair(Of Integer, String) In geezMap
            While number >= kvp.Key
                result.Append(kvp.Value)
                number -= kvp.Key
            End While
        Next

        Return result.ToString()
    End Function

    Private Function ConvertAsciiStringToHex(asciiString As String) As String
        Dim resultBuilder As New StringBuilder()

        For Each asciiChar As Char In asciiString
            Dim asciiValue As Integer = Asc(asciiChar)

            ' Convert ASCII value to hexadecimal 
            Dim hexValue As String = Convert.ToString(asciiValue, 16).PadLeft(2, "0"c)

            ' Format the output for each character
            Dim formattedResult As String = $"{asciiChar}" & vbTab & $"{hexValue.ToUpper()}"
            resultBuilder.AppendLine(formattedResult)
        Next

        Return resultBuilder.ToString().Trim()
    End Function

    Private Function ConvertAsciiStringToDecimal(asciiString As String) As String
        Dim resultBuilder As New StringBuilder()

        For Each asciiChar As Char In asciiString
            Dim asciiValue As Integer = Asc(asciiChar)

            ' Append the decimal value to the result
            Dim formattedResult As String = $"{asciiChar}" & vbTab & $"{asciiValue}"
            resultBuilder.AppendLine(formattedResult)
        Next

        Return resultBuilder.ToString().Trim()
    End Function

    Private Function ConvertAsciiStringBinary(asciiString As String) As String
        Dim resultBuilder As New StringBuilder()

        For Each asciiChar As Char In asciiString
            Dim asciiValue As Integer = Asc(asciiChar)

            ' Convert ASCII value to binary representation

            Dim binaryValue As String = Convert.ToString(asciiValue, 2).PadLeft(8, "0"c)

            ' Format the output for each character
            Dim formattedResult As String = $"{asciiChar}" & vbTab & $"{binaryValue}"
            resultBuilder.AppendLine(formattedResult)
        Next

        Return resultBuilder.ToString().Trim()
    End Function

    Private Function DecimalToBinary(decimalValue As Long) As String
        If decimalValue = 0 Then
            Return "0" ' Return "0" for input value 0
        End If

        Dim resultBuilder As New StringBuilder()
        Dim isNegative As Boolean = False

        ' Check if the input value is negative
        If decimalValue < 0 Then
            isNegative = True
            decimalValue = Math.Abs(decimalValue) ' Get the absolute value for conversion
        End If

        ' Perform the binary conversion of the absolute value
        While decimalValue > 0
            resultBuilder.Insert(0, decimalValue Mod 2) ' Insert the remainder into the result
            decimalValue \= 2 ' Integer division by 2
        End While

        Dim binaryResult As String = resultBuilder.ToString()

        If isNegative Then
            binaryResult = "-" & binaryResult ' Prepend "-" for negative numbers
        End If

        Return binaryResult
    End Function

    Function BinaryToDecimal(binaryString As String) As Long
        Dim decimalValue As Long = 0
        Dim powerOfTwo As Long = 1

        For i As Integer = binaryString.Length - 1 To 0 Step -1 ' Iterate from right to left
            Dim digit As Integer = Val(binaryString(i))

            If digit <> 0 And digit <> 1 Then
                Throw New ArgumentException("Invalid binary digit: " & digit)
            End If

            decimalValue += digit * powerOfTwo
            powerOfTwo *= 2
        Next

        Return decimalValue
    End Function


    Private Sub btnBin_Click(sender As Object, e As EventArgs) Handles btnBin.Click
        Dim decimalInput As Double

        ' Check if lblTop.Text is a valid number and convert it to binary tree node
        If Not String.IsNullOrWhiteSpace(lblTop.Text) AndAlso Double.TryParse(lblTop.Text, decimalInput) Then
            ConvertAndDisplayBinaryTree(decimalInput)
        End If

        ' Check if txtAnswer.Text is a valid number and convert it to binary tree node
        Dim decimalInputTxt As Double
        If Not String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso Double.TryParse(txtAnswer.Text, decimalInputTxt) Then
            ConvertAndDisplayBinaryTree(decimalInputTxt)
        ElseIf Not String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MsgBox("Please enter a valid decimal number for conversion.", vbInformation, "Info")
        End If
    End Sub



    Private Sub ConvertAndDisplayBinaryTree(decimalInput As Double)
        Dim binaryTree As TreeNode = ConvertDecimalToBinaryTree(decimalInput)
        If binaryTree IsNot Nothing Then
            lstAnswer.Nodes.Add(binaryTree)
        End If
    End Sub

    Private Function ConvertDecimalToBinaryTree(decimalInput As Double) As TreeNode
        Dim newNode As TreeNode = Nothing

        Try
            ' Extract the sign of the decimal number
            Dim isNegative As Boolean = False
            If decimalInput < 0 Then
                isNegative = True
                decimalInput = Math.Abs(decimalInput) ' Convert to positive for processing
            End If

            ' Extract the integer part and fractional part of the absolute decimal number
            Dim integerPart As Integer = CInt(Math.Truncate(decimalInput))
            Dim fractionalPart As Double = decimalInput - integerPart

            ' Convert the integer part to binary
            Dim binaryIntegerPart As String = Convert.ToString(integerPart, 2)

            ' Convert the fractional part to binary
            Dim binaryFractionalPart As New System.Text.StringBuilder(".")
            Dim maxPrecision As Integer = 52 ' For double-precision floating point numbers

            For i As Integer = 0 To maxPrecision - 1
                ' Multiply the fractional part by 2
                fractionalPart *= 2

                ' Check if the new bit will be 1 or 0
                If fractionalPart >= 1 Then
                    binaryFractionalPart.Append("1")
                    fractionalPart -= 1
                Else
                    binaryFractionalPart.Append("0")
                End If

                ' Break the loop if the fractional part becomes 0
                If fractionalPart = 0 Then
                    Exit For
                End If
            Next

            ' Construct the final binary representation
            Dim binaryResult As String = binaryIntegerPart & binaryFractionalPart.ToString()

            ' Display the result in Label3 with the sign
            If isNegative Then
                binaryResult = "-" & binaryResult
            End If

            newNode = New TreeNode(binaryResult.ToString())

        Catch ex As OverflowException
            MessageBox.Show("An overflow occurred. The number entered is too large to convert.", "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return newNode
    End Function


    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click

        Dim result As Double = Calculate(txtAnswer.Text)
        If Not Double.IsNaN(result) Then
            ' Add the result to the TreeView
            Dim newNode As New TreeNode(result.ToString())
            lstAnswer.Nodes.Add(newNode)

            ' Set the result to the top label
            lblTop.Text = result.ToString()

        Else
            ' Optionally handle invalid expressions or errors here
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtAnswer.Text = ""
        lblTop.Text = ""
        dotUsed = False
        lastInput = ""
    End Sub

    Private Sub btnSquareRoot_Click(sender As Object, e As EventArgs) Handles btnSquareRoot.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Square.")
            Return
        End If

        Dim input As Double
        Dim newNode As TreeNode ' Declare newNode outside the condition

        If lblTop.Text <> "" Then
            ' Perform the Square Root operation
            answer = Math.Sqrt(lblTop.Text)
            lblTop.Text = answer.ToString()
            newNode = New TreeNode(answer.ToString())
            lstAnswer.Nodes.Add(newNode)
        ElseIf Not Double.TryParse(txtAnswer.Text, input) Then
            MessageBox.Show("Invalid input for Square Root operation.")
            Return
        Else
            ' Perform the Square Root operation
            answer = Math.Sqrt(txtAnswer.Text)
            txtAnswer.Text = answer.ToString()
            lblTop.Text = ""
            newNode = New TreeNode(answer.ToString())
            lstAnswer.Nodes.Add(newNode)
        End If
    End Sub


    Private Sub NumberButton_Click(sender As Object, e As EventArgs) Handles btnInput1.Click, btnInput2.Click, btnInput9.Click, btnInput8.Click, btnInput7.Click, btnInput6.Click, btnInput5.Click, btnInput4.Click, btnInput3.Click, btnInput0.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Then
            txtAnswer.Text = ""
        End If
        ' Code for button 1 to 9, 0
        Dim b As Button = sender
        Dim buttonText As String = b.Text

        ' Check if the label text is '0' before concatenating
        If txtAnswer.Text = "0" Then
            txtAnswer.Text = buttonText
        Else
            txtAnswer.Text = txtAnswer.Text + buttonText
        End If
    End Sub

    Private Function Calculate(expression As String) As Double
        ' Assuming expression is in infix notation (e.g., "2 + 3 * 5")
        Dim dt As DataTable = New DataTable()

        ' Evaluate the expression using DataTable.Compute
        Try
            Dim result As Object = dt.Compute(expression, "")
            Return CDbl(result)
        Catch ex As Exception
            ' Handle any calculation errors here
            MessageBox.Show("Invalid expression.")
            Return Double.NaN ' Return NaN (Not a Number) to indicate an error
        End Try
    End Function


    Private Sub OperationButton_Click(sender As Object, e As EventArgs) Handles btnAddition.Click, btnMultiplication.Click, btnModules.Click, btnMinus.Click, btnDivision.Click

        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        Dim operators As String = "+-*/%"
        Dim lastCharIndex As Integer = txtAnswer.Text.LastIndexOfAny(operators.ToCharArray())

        ' Check if the last input is an operator, and prevent adding consecutive operators
        If lastCharIndex >= 0 AndAlso lastCharIndex = txtAnswer.Text.Length - 2 AndAlso operators.Contains(txtAnswer.Text.Chars(lastCharIndex)) Then
            ' Replace the last operator with the current one
            txtAnswer.Text = txtAnswer.Text.Remove(lastCharIndex) & DirectCast(sender, Button).Text & " "
        Else
            ' Store the operator as the last input
            lastInput = DirectCast(sender, Button).Text
            dotUsed = False
            lastInputWasOperator = True
            Dim button As Button = DirectCast(sender, Button)
            txtAnswer.Text &= $" {button.Text} "
        End If
    End Sub
    Private Sub btnPi_Click(sender As Object, e As EventArgs) Handles btnPi.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Then
            txtAnswer.Text = ""
        End If
        If Not txtAnswer.Text.Contains(Math.PI.ToString()) Then
            ' Append Pi to txtAnswer
            txtAnswer.Text &= Math.PI.ToString()
            ' Check if the last input was an operator
        ElseIf lastInputWasOperator Then
            ' Append Pi to txtAnswer
            txtAnswer.Text &= Math.PI.ToString()
            ' Reset the flag to allow Pi after an operator
            lastInputWasOperator = False
        End If
    End Sub


    Private Sub btnEuler_Click(sender As Object, e As EventArgs) Handles btnEuler.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Then
            txtAnswer.Text = ""
        End If
        If Not txtAnswer.Text.Contains(Math.E.ToString()) Then
            ' Append Pi to txtAnswer
            txtAnswer.Text &= Math.E.ToString()
            ' Check if the last input was an operator
        ElseIf lastInputWasOperator Then
            ' Append Pi to txtAnswer
            txtAnswer.Text &= Math.E.ToString()
            ' Reset the flag to allow Pi after an operator
            lastInputWasOperator = False
        End If

    End Sub


    Private Sub btnSin_Click(sender As Object, e As EventArgs) Handles btnSin.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for Sin.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim sinValue As String = Math.Sin(input)
            newNode = New TreeNode(sinValue.ToString())
            lblTop.Text = sinValue
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try

    End Sub


    Private Sub btnCos_Click(sender As Object, e As EventArgs) Handles btnCos.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for Cos.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim cosValue As String = Math.Cos(input)
            newNode = New TreeNode(cosValue.ToString())
            lblTop.Text = cosValue
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub

    Private Sub btnTan_Click(sender As Object, e As EventArgs) Handles btnTan.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for Tan.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim tanValue As String = Math.Tan(input)
            newNode = New TreeNode(tanValue.ToString())
            lblTop.Text = tanValue
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub

    Private Sub btnExponetial_Click(sender As Object, e As EventArgs) Handles btnExponetial.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for Exponential.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim expValue As String = Math.Exp(input)
            newNode = New TreeNode(expValue.ToString())
            lblTop.Text = expValue
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub

    Private Function IsOperator(text As String) As Boolean
        Return text = "+" OrElse text = "-" OrElse text = "*" OrElse text = "/" OrElse text = "%"
    End Function

    Private Sub btnDot_Click(sender As Object, e As EventArgs) Handles btnDot.Click
        If Not dotUsed Then
            If Not String.IsNullOrEmpty(txtAnswer.Text) AndAlso IsOperator(lastInput) Then
                ' If the last input was an operator, allow the dot
                txtAnswer.Text &= "."
            ElseIf Not String.IsNullOrEmpty(txtAnswer.Text) AndAlso txtAnswer.Text.LastIndexOf(".") = -1 Then
                ' If there's no dot in the current input sequence, allow the dot
                txtAnswer.Text &= "."
            End If
            dotUsed = True
        End If
    End Sub

    Private Sub AboutScientificCalculatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutScientificCalculatorToolStripMenuItem.Click
        ' About
        MessageBox.Show("Hi I Am NattyXO.This Is My First Scientific Calculator.
              
Ahadu Tech Studio® 
Scientific Calculator
Github: NattyXO
© 2019 Ahadu Inc. All rights reserved.
Version 1.0.3(Official Build)")
    End Sub

    Private Sub GithubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GithubToolStripMenuItem.Click
        Dim url As String = "https://github.com/NattyXO/Scientific-calculator"

        ' Open the URL in the default browser
        Try
            Process.Start(url)
        Catch ex As Exception
            ' Handle any potential exceptions if the URL cannot be opened
            MessageBox.Show("Failed to open URL: " & ex.Message)
        End Try
    End Sub

    Private Sub RealseNotesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RealseNotesToolStripMenuItem.Click

        Dim url As String = "https://github.com/NattyXO/Scientific-calculator/releases"

        ' Open the URL in the default browser
        Try
            Process.Start(url)
        Catch ex As Exception
            ' Handle any potential exceptions if the URL cannot be opened
            MessageBox.Show("Failed to open URL: " & ex.Message)
        End Try
    End Sub

    Private Sub YoutubeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YoutubeToolStripMenuItem.Click
        Dim url As String = "https://www.youtube.com/c/AhaduTech"

        ' Open the URL in the default browser
        Try
            Process.Start(url)
        Catch ex As Exception
            ' Handle any potential exceptions if the URL cannot be opened
            MessageBox.Show("Failed to open URL: " & ex.Message)
        End Try
    End Sub

    Private Sub LinkedinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinkedinToolStripMenuItem.Click

        Dim url As String = "https://www.linkedin.com/in/natnael-bizuneh-zenebe/"

        ' Open the URL in the default browser
        Try
            Process.Start(url)
        Catch ex As Exception
            ' Handle any potential exceptions if the URL cannot be opened
            MessageBox.Show("Failed to open URL: " & ex.Message)
        End Try
    End Sub

    Private Sub FacebookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacebookToolStripMenuItem.Click
        Dim url As String = "https://www.facebook.com/ahadutechoffical"

        ' Open the URL in the default browser
        Try
            Process.Start(url)
        Catch ex As Exception
            ' Handle any potential exceptions if the URL cannot be opened
            MessageBox.Show("Failed to open URL: " & ex.Message)
        End Try
    End Sub

    Private Sub ReportAProblemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportAProblemToolStripMenuItem.Click
        Dim url As String = "https://forms.gle/MzTRF89iFr6dckJYA"

        ' Open the URL in the default browser
        Try
            Process.Start(url)
        Catch ex As Exception
            ' Handle any potential exceptions if the URL cannot be opened
            MessageBox.Show("Failed to open URL: " & ex.Message)
        End Try
    End Sub

    Private Sub SuggestAFeatureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuggestAFeatureToolStripMenuItem.Click
        Dim url As String = "https://forms.gle/MzTRF89iFr6dckJYA"

        ' Open the URL in the default browser
        Try
            Process.Start(url)
        Catch ex As Exception
            ' Handle any potential exceptions if the URL cannot be opened
            MessageBox.Show("Failed to open URL: " & ex.Message)
        End Try
    End Sub

    Private Sub KeyboardShortcutReferenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeyboardShortcutReferenceToolStripMenuItem.Click

        Dim url As String = "https://github.com/NattyXO/Scientific-calculator/blob/main/Shortcut.md"

        ' Open the URL in the default browser
        Try
            Process.Start(url)
        Catch ex As Exception
            ' Handle any potential exceptions if the URL cannot be opened
            MessageBox.Show("Failed to open URL: " & ex.Message)
        End Try
    End Sub


    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'MessageBox.Show($"You pressed key: {e.KeyCode}", "Key Pressed")

        ' Check if the Enter key is pressed
        If e.KeyCode = Keys.Enter Then
            btnEqual.PerformClick()
        ElseIf e.KeyCode = Keys.NumPad0 Then
            btnInput0.PerformClick()
        ElseIf e.KeyCode = Keys.NumPad1 Then
            btnInput1.PerformClick()
        ElseIf e.KeyCode = Keys.NumPad2 Then
            btnInput2.PerformClick()
        ElseIf e.KeyCode = Keys.NumPad3 Then
            btnInput3.PerformClick()
        ElseIf e.KeyCode = Keys.NumPad4 Then
            btnInput4.PerformClick()
        ElseIf e.KeyCode = Keys.NumPad5 Then
            btnInput5.PerformClick()
        ElseIf e.KeyCode = Keys.NumPad6 Then
            btnInput6.PerformClick()
        ElseIf e.KeyCode = Keys.NumPad7 Then
            btnInput7.PerformClick()
        ElseIf e.KeyCode = Keys.NumPad8 Then
            btnInput8.PerformClick()
        ElseIf e.KeyCode = Keys.NumPad9 Then
            btnInput9.PerformClick()
        ElseIf e.KeyCode = Keys.Add Then ' "+" key
            btnAddition.PerformClick()
        ElseIf e.KeyCode = Keys.Subtract Then ' "-" key
            btnMinus.PerformClick()
        ElseIf e.KeyCode = Keys.Multiply Then ' "*" key
            btnMultiplication.PerformClick()
        ElseIf e.KeyCode = Keys.Divide Then ' "/" key
            btnDivision.PerformClick()
        ElseIf e.KeyCode = Keys.OemPeriod Then ' "." key
            btnDot.PerformClick()
        ElseIf e.KeyCode = Keys.Decimal Then ' "." key
            btnDot.PerformClick()
        ElseIf e.KeyCode = Keys.OemMinus Then ' "-" key
            btnMinus.PerformClick()
        ElseIf e.KeyCode = Keys.Oemplus Then ' "+" key
            btnAddition.PerformClick()
            ' Check if Ctrl+C is pressed and a node is selected
        ElseIf e.KeyCode = Keys.C AndAlso e.Control AndAlso lstAnswer.SelectedNode IsNot Nothing Then
            ' Copy the selected node's text to the clipboard
            Clipboard.SetText(lstAnswer.SelectedNode.Text)
        ElseIf e.KeyCode = Keys.C AndAlso e.Shift Then
            btnClearUnit.PerformClick()
        ElseIf e.KeyCode = Keys.C AndAlso e.Alt Then
            btnClearAnswerHistory.PerformClick()
        ElseIf e.KeyCode = Keys.V Then ' "Converter" key
            btnUnitConvert.PerformClick()
        ElseIf e.KeyCode = Keys.Back Then ' "back" key
            btnBack.PerformClick()
        ElseIf e.KeyCode = Keys.C Then ' "clear" key
            btnClear.PerformClick()
        ElseIf e.KeyCode = Keys.E Then ' "Euler" key
            btnEuler.PerformClick()
        ElseIf e.KeyCode = Keys.P Then ' "P" key
            btnPi.PerformClick()
        ElseIf e.KeyCode = Keys.OemQuestion AndAlso e.Shift Then
            ' This handles the "/" character using Shift + ?
            btnDivision.PerformClick() ' Triggers the left parenthesis button click
        ElseIf e.KeyCode = Keys.D5 AndAlso e.Shift Then
            ' This handles the "%" character using Shift + 9
            btnModules.PerformClick()
        ElseIf e.KeyCode = Keys.D9 AndAlso e.Shift Then
            ' This handles the "(" character using Shift + 9
            btnLeftBracket.PerformClick() ' Triggers the left parenthesis button click
        ElseIf e.KeyCode = Keys.D0 AndAlso e.Shift Then
            ' This handles the ")" character using Shift + 0
            btnRightBracket.PerformClick() ' Triggers the right parenthesis button click
            ' Check for the percent sign using its ASCII code (37)
        ElseIf e.KeyCode = Keys.D5 AndAlso e.Shift Then
            btnModules.PerformClick() ' Triggers the percent button click
        ElseIf e.KeyCode = Keys.D8 AndAlso e.Shift Then
            ' This handles the "*" character using Shift + 9
            btnMultiplication.PerformClick()
        ElseIf e.KeyCode = Keys.D0 Then
            ' This handles the "0" character
            btnInput0.PerformClick()
        ElseIf e.KeyCode = Keys.D1 Then
            ' This handles the "1" character
            btnInput1.PerformClick()
        ElseIf e.KeyCode = Keys.D2 Then
            ' This handles the "2" character
            btnInput2.PerformClick()
        ElseIf e.KeyCode = Keys.D3 Then
            ' This handles the "3" character
            btnInput3.PerformClick()
        ElseIf e.KeyCode = Keys.D4 Then
            ' This handles the "4" character
            btnInput4.PerformClick()
        ElseIf e.KeyCode = Keys.D5 Then
            ' This handles the "5" character
            btnInput5.PerformClick()
        ElseIf e.KeyCode = Keys.D6 Then
            ' This handles the "6" character
            btnInput6.PerformClick()
        ElseIf e.KeyCode = Keys.D7 Then
            ' This handles the "7" character
            btnInput7.PerformClick()
        ElseIf e.KeyCode = Keys.D8 Then
            ' This handles the "8" character
            btnInput8.PerformClick()
        ElseIf e.KeyCode = Keys.D9 Then
            ' This handles the "9" character
            btnInput9.PerformClick()

        End If
    End Sub

    Private Sub AnswerHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnswerHistoryToolStripMenuItem.Click
        'Code for extend form
        Me.Height = 419
        Me.Width = 686
        txtAnswer.Width = 396
    End Sub

    Private Sub btnClearAnswerHistory_Click(sender As Object, e As EventArgs) Handles btnClearAnswerHistory.Click
        lstAnswer.Nodes.Clear()
    End Sub

    Private Sub ParenthesisButton_Click(sender As Object, e As EventArgs) Handles btnLeftBracket.Click, btnRightBracket.Click
        Dim operators As String = "()"
        Dim lastCharIndex As Integer = txtAnswer.Text.LastIndexOfAny(operators.ToCharArray())

        ' Check if the last input is an operator, and prevent adding consecutive operators
        If lastCharIndex >= 0 AndAlso lastCharIndex = txtAnswer.Text.Length - 2 AndAlso operators.Contains(txtAnswer.Text.Chars(lastCharIndex)) Then
            ' Replace the last operator with the current one
            txtAnswer.Text = txtAnswer.Text.Remove(lastCharIndex) & DirectCast(sender, Button).Text & " "
        Else
            ' Store the operator as the last input
            lastInput = DirectCast(sender, Button).Text
            dotUsed = False
            lastInputWasOperator = True
            Dim button As Button = DirectCast(sender, Button)
            txtAnswer.Text &= $" {button.Text} "
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Maximized Then
            txtAnswer.Width = 396
        ElseIf WindowState = FormWindowState.Normal Then
            txtAnswer.Width = 263
        End If
    End Sub

    Private Sub btnTenPowerOfX_Click(sender As Object, e As EventArgs) Handles btnTenPowerOfX.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for 10x.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim result As String = TenToThePowerOfX(input)
            newNode = New TreeNode(result.ToString())
            lblTop.Text = result
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub

    Private Function TenToThePowerOfX(x As Integer) As Long
        If x = 0 Then Return "1"

        Dim result As String = "10"

        For i As Integer = 2 To x
            result = MultiplyBy10(result)
        Next

        Return result
    End Function

    Private Function MultiplyBy10(value As String) As String
        Dim carry As Integer = 0
        Dim result As String = ""

        For i As Integer = value.Length - 1 To 0 Step -1
            Dim digit As Integer = Convert.ToInt32(value(i).ToString())
            Dim product As Integer = digit * 10 + carry

            result = (product Mod 10).ToString() & result
            carry = product \ 10
        Next

        If carry > 0 Then
            result = carry.ToString() & result
        End If

        Return result
    End Function

    Private Sub btnSecant_Click(sender As Object, e As EventArgs) Handles btnSecant.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for log.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim secantValue As Double = TrigonometryFunctions.Secant(input)
            newNode = New TreeNode(secantValue.ToString())
            lblTop.Text = secantValue
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub

    Public Class TrigonometryFunctions
        Public Shared Function Secant(angle As Double) As Double
            ' Ensure the angle is in radians for the Math.Cos function
            Dim radians As Double = angle * (Math.PI / 180.0)

            ' Calculate cosine value
            Dim cosineValue As Double = Math.Cos(radians)

            ' Check if the cosine value is very close to zero to prevent division by zero
            If Math.Abs(cosineValue) < Double.Epsilon Then
                Throw New ArgumentException("Invalid angle. Cosine value is zero.")
            End If

            ' Calculate secant as the reciprocal of cosine
            Return 1 / cosineValue
        End Function

        Public Shared Function Cosecant(angle As Double) As Double
            ' Ensure the angle is in radians for the Math.Sin function
            Dim radians As Double = angle * (Math.PI / 180.0)

            ' Calculate sine value
            Dim sineValue As Double = Math.Sin(radians)

            ' Check if the sine value is very close to zero to prevent division by zero
            If Math.Abs(sineValue) < Double.Epsilon Then
                Throw New ArgumentException("Invalid angle. Sine value is zero.")
            End If

            ' Calculate cosecant as the reciprocal of sine
            Return 1 / sineValue
        End Function

        Public Shared Function Cotangent(angle As Double) As Double
            ' Ensure the angle is in radians for the Math.Tan function
            Dim radians As Double = angle * (Math.PI / 180.0)

            ' Calculate tangent value
            Dim tangentValue As Double = Math.Tan(radians)

            ' Check if the tangent value is very close to zero to prevent division by zero
            If Math.Abs(tangentValue) < Double.Epsilon Then
                Throw New ArgumentException("Invalid angle. Tangent value is zero.")
            End If

            ' Calculate cotangent as the reciprocal of tangent
            Return 1 / tangentValue
        End Function
    End Class

    Private Sub btnCosecant_Click(sender As Object, e As EventArgs) Handles btnCosecant.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for Cosecant.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim cosecantValue As Double = TrigonometryFunctions.Cosecant(input)
            newNode = New TreeNode(cosecantValue.ToString())
            lblTop.Text = cosecantValue
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub

    Private Sub btnCotangent_Click(sender As Object, e As EventArgs) Handles btnCotangent.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for Cotangent.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim cotangentValue As Double = TrigonometryFunctions.Cotangent(input)
            newNode = New TreeNode(cotangentValue.ToString())
            lblTop.Text = cotangentValue
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub

    Private Sub btnOneOverTwo_Click(sender As Object, e As EventArgs) Handles btnOneOverTwo.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for X.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim xValue As Double = Reciprocal(input)
            newNode = New TreeNode(xValue.ToString())
            lblTop.Text = xValue
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub

    Public Function Reciprocal(x As Double) As Double
        Try
            If x = 0 Then
                Throw New ArgumentException("Division by zero is not allowed.")
            End If

            Return 1 / x
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message, "Division Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Double.NaN ' Return a default value to indicate an error (you can change this as needed)
        End Try
    End Function


    Private Sub btnXPowerOfTwo_Click(sender As Object, e As EventArgs) Handles btnXPowerOfTwo.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        If String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso String.IsNullOrWhiteSpace(lblTop.Text) Then
            MessageBox.Show("Please enter a valid number to convert.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) AndAlso Not Double.TryParse(lblTop.Text, input) Then
            MessageBox.Show("Invalid input for X.")
            Return
        End If

        Dim newNode As TreeNode

        Try
            ' Use the input value directly for conversion
            Dim xValue As Double = Square(input)
            lblTop.Text = xValue
            newNode = New TreeNode(xValue.ToString())
            lstAnswer.Nodes.Add(newNode)
        Catch ex As OverflowException
            MessageBox.Show("The number is too large.")
        End Try
    End Sub
    Public Function Square(x As Double) As Double
        Return x * x
    End Function

    Private isNegative As Boolean = False ' Global variable to track the sign

    Private Sub btnNegate_Click(sender As Object, e As EventArgs) Handles btnNegate.Click
        If Not String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            Dim currentValue As Double
            If Double.TryParse(txtAnswer.Text, currentValue) Then
                If isNegative Then
                    currentValue = Math.Abs(currentValue) ' Convert to positive
                    isNegative = False
                Else
                    currentValue = -currentValue ' Convert to negative
                    isNegative = True
                End If
                txtAnswer.Text = currentValue.ToString()
            Else
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Please enter a number first.", "No Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private isFirstNumberEntered As Boolean = False ' Global variable to track the entry sequence
    Private xValue As Double  ' Global variable to store the first number entered

    Private Sub btnXPowerOfY_Click(sender As Object, e As EventArgs) Handles btnXPowerOfY.Click
        If isFirstNumberEntered Then
            ' Y value
            Dim yValue As Double
            Dim newNode As TreeNode
            If Not String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso Double.TryParse(txtAnswer.Text, yValue) Then
                ' Calculate x^y
                Dim result As Double = Math.Pow(xValue, yValue)
                newNode = New TreeNode(result.ToString())
                lblTop.Text = result
                lstAnswer.Nodes.Add(newNode)
                txtAnswer.Text = $"{xValue}^{yValue}" ' Display x^y

            Else
                MessageBox.Show("Please enter a valid number for Y.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            isFirstNumberEntered = False
            xValue = Nothing ' Reset xValue after calculation
        Else
            ' X value
            If Not String.IsNullOrWhiteSpace(txtAnswer.Text) AndAlso Double.TryParse(txtAnswer.Text, xValue) Then
                isFirstNumberEntered = True ' Flag that the first number has been entered
                lblTop.Text = $"{xValue}^" ' Display x^
                txtAnswer.Text = "" ' Clear the textbox for the next entry (Y value)
            Else
                MessageBox.Show("Please enter a valid number for X.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


End Class
