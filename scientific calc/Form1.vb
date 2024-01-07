Imports System.Text
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
        Me.Height = 411
        Me.Width = 579
        txtAnswer.Width = 334
    End Sub

    Private Sub UnitConversionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnitConversionToolStripMenuItem.Click
        'Code for extend form
        Me.Height = 411
        Me.Width = 854
        txtAnswer.Width = 334
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'code to exit
        Application.Exit()
    End Sub


    Private Sub StandardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StandardToolStripMenuItem.Click
        'Code for extend form
        Me.Height = 411
        Me.Width = 310
        txtAnswer.Width = 267
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True ' Enable key events for the form

        Me.Height = 411
        Me.Width = 310
        btnEqual.Width = 131
        txtAnswer.Width = 266

        ComboBox1.Text = "Choose one..."
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
            lblTop.Text = hexValue.ToString()
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

        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Logarithm base 10.")
            Return
        End If

        Dim input As Double
        Dim isValidNumber As Boolean = False
        Dim newNode As TreeNode ' Declare newNode outside the condition

        If Not String.IsNullOrWhiteSpace(lblTop.Text) Then
            ' Check if the value is a valid number
            If lblTop.Text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) Then
                ' Remove the "0x" prefix if present
                Dim hexValue = lblTop.Text.Substring(2)
                ' Check if the remaining text is a valid hexadecimal number
                If Double.TryParse(hexValue, Globalization.NumberStyles.HexNumber, Nothing, input) Then
                    isValidNumber = True
                End If
            Else
                ' Check if the value is a valid decimal number
                If Double.TryParse(lblTop.Text, input) Then
                    isValidNumber = True
                End If
            End If
        End If

        If isValidNumber Then
            ' Perform the logarithm operation
            answer = Math.Log10(input)
            lblTop.Text = answer.ToString()
            newNode = New TreeNode(answer.ToString())
            lstAnswer.Nodes.Add(newNode)
        Else
            MessageBox.Show("Invalid input for Logarithm 10 base operation.")
            Return
        End If
    End Sub


    Private Sub btnCosh_Click(sender As Object, e As EventArgs) Handles btnCosh.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate hyperbolic cosine.")
            Return
        End If

        Dim input As Double
        Dim isValidNumber As Boolean = False
        Dim newNode As TreeNode ' Declare newNode outside the condition

        If Not String.IsNullOrWhiteSpace(lblTop.Text) Then
            ' Check if the value is a valid number
            If lblTop.Text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) Then
                ' Remove the "0x" prefix if present
                Dim hexValue = lblTop.Text.Substring(2)
                ' Check if the remaining text is a valid hexadecimal number
                If Double.TryParse(hexValue, Globalization.NumberStyles.HexNumber, Nothing, input) Then
                    isValidNumber = True
                End If
            Else
                ' Check if the value is a valid decimal number
                If Double.TryParse(lblTop.Text, input) Then
                    isValidNumber = True
                End If
            End If
        End If

        If isValidNumber Then
            ' Perform the logarithm operation
            answer = Math.Cosh(input)
            lblTop.Text = answer.ToString()
            newNode = New TreeNode(answer.ToString())
            lstAnswer.Nodes.Add(newNode)
        Else
            MessageBox.Show("Invalid input for hyperbolic cosine operation.")
            Return
        End If
    End Sub

    Private Sub btnSinh_Click(sender As Object, e As EventArgs) Handles btnSinh.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate hyperbolic sine.")
            Return
        End If

        Dim input As Double
        Dim isValidNumber As Boolean = False
        Dim newNode As TreeNode ' Declare newNode outside the condition

        If Not String.IsNullOrWhiteSpace(lblTop.Text) Then
            ' Check if the value is a valid number
            If lblTop.Text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) Then
                ' Remove the "0x" prefix if present
                Dim hexValue = lblTop.Text.Substring(2)
                ' Check if the remaining text is a valid hexadecimal number
                If Double.TryParse(hexValue, Globalization.NumberStyles.HexNumber, Nothing, input) Then
                    isValidNumber = True
                End If
            Else
                ' Check if the value is a valid decimal number
                If Double.TryParse(lblTop.Text, input) Then
                    isValidNumber = True
                End If
            End If
        End If

        If isValidNumber Then
            ' Perform the logarithm operation
            answer = Math.Sinh(input)
            lblTop.Text = answer.ToString()
            newNode = New TreeNode(answer.ToString())
            lstAnswer.Nodes.Add(newNode)
        Else
            MessageBox.Show("Invalid input for hyperbolic sine operation.")
            Return
        End If
    End Sub

    Private Sub btnTanh_Click(sender As Object, e As EventArgs) Handles btnTanh.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate hyperbolic tangent.")
            Return
        End If

        Dim input As Double
        Dim isValidNumber As Boolean = False
        Dim newNode As TreeNode ' Declare newNode outside the condition

        If Not String.IsNullOrWhiteSpace(lblTop.Text) Then
            ' Check if the value is a valid number
            If lblTop.Text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) Then
                ' Remove the "0x" prefix if present
                Dim hexValue = lblTop.Text.Substring(2)
                ' Check if the remaining text is a valid hexadecimal number
                If Double.TryParse(hexValue, Globalization.NumberStyles.HexNumber, Nothing, input) Then
                    isValidNumber = True
                End If
            Else
                ' Check if the value is a valid decimal number
                If Double.TryParse(lblTop.Text, input) Then
                    isValidNumber = True
                End If
            End If
        End If

        If isValidNumber Then
            ' Perform the logarithm operation
            answer = Math.Tanh(input)
            lblTop.Text = answer.ToString()
            newNode = New TreeNode(answer.ToString())
            lstAnswer.Nodes.Add(newNode)
        Else
            MessageBox.Show("Invalid input for hyperbolic tangent operation.")
            Return
        End If
    End Sub
    Private Sub btnln_Click(sender As Object, e As EventArgs) Handles btnln.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        Dim input As Double
        Dim isvalidnumber As Boolean = False
        Dim newNode As TreeNode

        If Not String.IsNullOrWhiteSpace(lblTop.Text) Then
            ' Check if the value is a hexadecimal string
            If lblTop.Text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) Then
                isvalidnumber = True
                ' Remove the "0x" prefix if present
                lblTop.Text = lblTop.Text.Substring(2)
            End If
        End If

        If isvalidnumber Then
            ' Perform the logarithm operation on the hexadecimal value
            If Not Double.TryParse(lblTop.Text, Globalization.NumberStyles.HexNumber, Nothing, input) Then
                MessageBox.Show("Invalid input for Logarithm operation.")
                Return
            End If

            ' Calculate the logarithm
            answer = Math.Log(input)
        Else
            ' Perform the logarithm operation on the decimal value
            If Not Double.TryParse(lblTop.Text, input) Then
                MessageBox.Show("Invalid input for Logarithm operation.")
                Return
            End If

            ' Calculate the logarithm
            answer = Math.Log(input)
        End If

        lblTop.Text = answer.ToString()
        newNode = New TreeNode(answer.ToString())
        lstAnswer.Nodes.Add(newNode)

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
                    result = Convert.ToString(Asc(binaryInput), 16)
                    Unitshow.Text = $"{result}"
                Case "ASCII Character to Decimal"
                    result = Asc(binaryInput)
                    Unitshow.Text = $"{result}"
                Case "ASCII Character to Binary"
                    result = Convert.ToString(Asc(binaryInput), 2)
                    Unitshow.Text = $"{result}"
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
                        Dim binaryValue As String = DecimalToBinary(decimaltobinaryinput) ' Use the parsed value
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
                Case Else
                    MsgBox("Select a valid Unit of Conversion", vbInformation, "Info")
            End Select

        Else
            MsgBox("Please select a conversion type from the dropdown.", vbInformation, "Info")
        End If
    End Sub

    Function DecimalToBinary(decimalNumber As Long) As String
        Dim binaryString As String = ""

        Do While decimalNumber > 0
            binaryString = decimalNumber Mod 2 & binaryString ' Append remainder to the left
            decimalNumber = decimalNumber \ 2  ' Integer division to get the next quotient
        Loop

        Return binaryString
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
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MsgBox("Please enter a decimal number for conversion.", vbInformation, "Info")
            Return
        End If

        Dim decimalInput As Double
        If Not Double.TryParse(txtAnswer.Text, decimalInput) Then
            MsgBox("Please enter a valid decimal number for conversion.", vbInformation, "Info")
            Return
        End If

        Try
            ' Extract the integer part and fractional part of the decimal number
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

            ' Display the result in Label3
            txtAnswer.Text = binaryIntegerPart & binaryFractionalPart.ToString()
            lblTop.Visible = False

        Catch ex As OverflowException
            MessageBox.Show("An overflow occurred. The number entered is too large to convert.", "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAnswer.Text = ""
            lblTop.Visible = True
        End Try
    End Sub

    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click

        lblTop.Visible = True
        Dim result As Double = Calculate(txtAnswer.Text)
        If Not Double.IsNaN(result) Then
            ' Add the result to the TreeView
            Dim newNode As New TreeNode(result.ToString())
            lstAnswer.Nodes.Add(newNode)

            ' Set the result to the top label
            lblTop.Text = result.ToString()
            lblTop.Visible = True
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

        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate sine.")
            Return
        End If

        Dim input As Double
        Dim isValidNumber As Boolean = False
        Dim newNode As TreeNode ' Declare newNode outside the condition

        If Not String.IsNullOrWhiteSpace(lblTop.Text) Then
            ' Check if the value is a valid number
            If lblTop.Text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) Then
                ' Remove the "0x" prefix if present
                Dim hexValue = lblTop.Text.Substring(2)
                ' Check if the remaining text is a valid hexadecimal number
                If Double.TryParse(hexValue, Globalization.NumberStyles.HexNumber, Nothing, input) Then
                    isValidNumber = True
                End If
            Else
                ' Check if the value is a valid decimal number
                If Double.TryParse(lblTop.Text, input) Then
                    isValidNumber = True
                End If
            End If
        End If

        If isValidNumber Then
            ' Perform the logarithm operation
            answer = Math.Sin(input)
            lblTop.Text = answer.ToString()
            newNode = New TreeNode(answer.ToString())
            lstAnswer.Nodes.Add(newNode)
        Else
            MessageBox.Show("Invalid input for sine operation.")
            Return
        End If
    End Sub


    Private Sub btnCos_Click(sender As Object, e As EventArgs) Handles btnCos.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate cosine.")
            Return
        End If

        Dim input As Double
        Dim isValidNumber As Boolean = False
        Dim newNode As TreeNode ' Declare newNode outside the condition

        If Not String.IsNullOrWhiteSpace(lblTop.Text) Then
            ' Check if the value is a valid number
            If lblTop.Text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) Then
                ' Remove the "0x" prefix if present
                Dim hexValue = lblTop.Text.Substring(2)
                ' Check if the remaining text is a valid hexadecimal number
                If Double.TryParse(hexValue, Globalization.NumberStyles.HexNumber, Nothing, input) Then
                    isValidNumber = True
                End If
            Else
                ' Check if the value is a valid decimal number
                If Double.TryParse(lblTop.Text, input) Then
                    isValidNumber = True
                End If
            End If
        End If

        If isValidNumber Then
            ' Perform the logarithm operation
            answer = Math.Cos(input)
            lblTop.Text = answer.ToString()
            newNode = New TreeNode(answer.ToString())
            lstAnswer.Nodes.Add(newNode)
        Else
            MessageBox.Show("Invalid input for cosine operation.")
            Return
        End If
    End Sub

    Private Sub btnTan_Click(sender As Object, e As EventArgs) Handles btnTan.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate tangent.")
            Return
        End If

        Dim input As Double
        Dim isValidNumber As Boolean = False
        Dim newNode As TreeNode ' Declare newNode outside the condition

        If Not String.IsNullOrWhiteSpace(lblTop.Text) Then
            ' Check if the value is a valid number
            If lblTop.Text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) Then
                ' Remove the "0x" prefix if present
                Dim hexValue = lblTop.Text.Substring(2)
                ' Check if the remaining text is a valid hexadecimal number
                If Double.TryParse(hexValue, Globalization.NumberStyles.HexNumber, Nothing, input) Then
                    isValidNumber = True
                End If
            Else
                ' Check if the value is a valid decimal number
                If Double.TryParse(lblTop.Text, input) Then
                    isValidNumber = True
                End If
            End If
        End If

        If isValidNumber Then
            ' Perform the logarithm operation
            answer = Math.Tan(input)
            lblTop.Text = answer.ToString()
            newNode = New TreeNode(answer.ToString())
            lstAnswer.Nodes.Add(newNode)
        Else
            MessageBox.Show("Invalid input for tangent operation.")
            Return
        End If
    End Sub

    Private Sub btnExponetial_Click(sender As Object, e As EventArgs) Handles btnExponetial.Click
        txtAnswer.Focus()
        If txtAnswer.Text = "∞" Or txtAnswer.Text = "∞ " Or lblTop.Text = "∞" Or lblTop.Text = "∞ " Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Or txtAnswer.Text = "NaN " Or lblTop.Text = "NaN" Or lblTop.Text = "NaN " Then
            txtAnswer.Text = ""
        End If

        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Exponential function.")
            Return
        End If

        Dim input As Double
        Dim isValidNumber As Boolean = False
        Dim newNode As TreeNode ' Declare newNode outside the condition

        If Not String.IsNullOrWhiteSpace(lblTop.Text) Then
            ' Check if the value is a valid number
            If lblTop.Text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) Then
                ' Remove the "0x" prefix if present
                Dim hexValue = lblTop.Text.Substring(2)
                ' Check if the remaining text is a valid hexadecimal number
                If Double.TryParse(hexValue, Globalization.NumberStyles.HexNumber, Nothing, input) Then
                    isValidNumber = True
                End If
            Else
                ' Check if the value is a valid decimal number
                If Double.TryParse(lblTop.Text, input) Then
                    isValidNumber = True
                End If
            End If
        End If

        If isValidNumber Then
            ' Perform the logarithm operation
            answer = Math.Exp(input)
            lblTop.Text = answer.ToString()
            newNode = New TreeNode(answer.ToString())
            lstAnswer.Nodes.Add(newNode)
        Else
            MessageBox.Show("Invalid input for Exponential function operation.")
            Return
        End If
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
        MsgBox("Hi I Am NattyXO.This Is My First Scientific Calculator.
              
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
        If e.KeyCode = Keys.Space Then
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
        Me.Height = 411
        Me.Width = 579
        txtAnswer.Width = 334
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
            txtAnswer.Width = 334
        ElseIf WindowState = FormWindowState.Normal Then
            txtAnswer.Width = 266
        End If
    End Sub
End Class
