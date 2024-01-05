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
        Me.Width = 587
        btnEqual.Width = 200
        txtAnswer.Width = 403
    End Sub

    Private Sub UnitConversionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnitConversionToolStripMenuItem.Click
        'Code for extend form
        Me.Height = 411
        Me.Width = 846
        btnEqual.Width = 200
        txtAnswer.Width = 403
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'code to exit
        Application.Exit()
    End Sub


    Private Sub StandardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StandardToolStripMenuItem.Click
        'Code for extend form
        Me.Height = 411
        Me.Width = 310
        btnEqual.Width = 131
        txtAnswer.Width = 267
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    End Sub


    Private Sub btnHex_Click(sender As Object, e As EventArgs) Handles btnHex.Click
        If Not String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            Dim input As Double
            If Double.TryParse(txtAnswer.Text, input) Then
                Try
                    ' Convert the input to its hexadecimal representation
                    Dim hexValue As String = Convert.ToString(Convert.ToInt64(input), 16)
                    txtAnswer.Text = hexValue
                Catch ex As OverflowException
                    MessageBox.Show("The number is too large or too small for conversion to hexadecimal.")
                End Try
            Else
                MessageBox.Show("Invalid input for hexadecimal conversion.")
            End If
        Else
            MessageBox.Show("Please provide a valid input before converting to hexadecimal.")
        End If
    End Sub



    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Invalid input for Log operation.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) Then
            MessageBox.Show("Invalid input for Log operation.")
            Return
        End If

        ' Perform the Log operation
        Dim result As Double = Math.Log10(input)
        txtAnswer.Text = result.ToString()
        lblTop.Text = ""
    End Sub

    Private Sub btnCosh_Click(sender As Object, e As EventArgs) Handles btnCosh.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Sin.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(txtAnswer.Text, input) Then
            MessageBox.Show("Invalid input for Sin operation.")
            Return
        End If

        ' Perform the Sin operation
        answer = Math.Cosh(input)
        txtAnswer.Text = answer.ToString()
        lblTop.Text = ""
    End Sub

    Private Sub btnSinh_Click(sender As Object, e As EventArgs) Handles btnSinh.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Sin.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(txtAnswer.Text, input) Then
            MessageBox.Show("Invalid input for Sin operation.")
            Return
        End If

        ' Perform the Sin operation
        answer = Math.Sinh(input)
        txtAnswer.Text = answer.ToString()
        lblTop.Text = ""
    End Sub

    Private Sub btnTanh_Click(sender As Object, e As EventArgs) Handles btnTanh.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Sin.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(txtAnswer.Text, input) Then
            MessageBox.Show("Invalid input for Sin operation.")
            Return
        End If

        ' Perform the Sin operation
        answer = Math.Tanh(input)
        txtAnswer.Text = answer.ToString()
        lblTop.Text = ""
    End Sub
    Private Sub btnln_Click(sender As Object, e As EventArgs) Handles btnln.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Invalid input for Ln operation.")
            Return
        End If

        Dim input As Double

        If Not Double.TryParse(txtAnswer.Text, input) Then
            MessageBox.Show("Invalid input for Ln operation.")
            Return
        End If

        ' Perform the Ln operation
        Dim result As Double = Math.Log(input)
        txtAnswer.Text = result.ToString()
        lblTop.Text = ""
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
            Dim inputValue As Double
            If Not Double.TryParse(TextBox1.Text, inputValue) Then
                MsgBox("Please enter a valid number for conversion.", vbInformation, "Info")
                Return
            End If

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
                Case Else
                    MsgBox("Select a valid Unit of Conversion", vbInformation, "Info")
            End Select

        Else
            MsgBox("Please select a conversion type from the dropdown.", vbInformation, "Info")
        End If
    End Sub



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
            lblTop.Text = result.ToString() ' Set the result to the top label
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
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Square.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(txtAnswer.Text, input) Then
            MessageBox.Show("Invalid input for Square operation.")
            Return
        End If

        ' Perform the Sin operation
        answer = Math.Sqrt(input)
        txtAnswer.Text = answer.ToString()
        lblTop.Text = ""
    End Sub


    Private Sub NumberButton_Click(sender As Object, e As EventArgs) Handles btnInput1.Click, btnInput2.Click, btnInput9.Click, btnInput8.Click, btnInput7.Click, btnInput6.Click, btnInput5.Click, btnInput4.Click, btnInput3.Click, btnInput0.Click
        If txtAnswer.Text = "∞" Then
            txtAnswer.Text = ""
        ElseIf txtAnswer.Text = "NaN" Then
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
        ' Store the operator as the last input
        lastInput = DirectCast(sender, Button).Text
        dotUsed = False
        lastInputWasOperator = True
        Dim button As Button = DirectCast(sender, Button)
        txtAnswer.Text &= $" {button.Text} "
    End Sub
    Private Sub btnPi_Click(sender As Object, e As EventArgs) Handles btnPi.Click
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



    Private Sub btnLeftBracket_Click(sender As Object, e As EventArgs) Handles btnLeftBracket.Click
        txtAnswer.Text &= "("
    End Sub

    Private Sub btnRightBracket_Click(sender As Object, e As EventArgs) Handles btnRightBracket.Click
        txtAnswer.Text &= ")"
    End Sub

    Private Sub btnSin_Click(sender As Object, e As EventArgs) Handles btnSin.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Sin.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(txtAnswer.Text, input) Then
            MessageBox.Show("Invalid input for Sin operation.")
            Return
        End If

        ' Perform the Sin operation
        answer = Math.Sin(input)
        txtAnswer.Text = answer.ToString()
        lblTop.Text = ""
    End Sub


    Private Sub btnCos_Click(sender As Object, e As EventArgs) Handles btnCos.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Sin.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(txtAnswer.Text, input) Then
            MessageBox.Show("Invalid input for Sin operation.")
            Return
        End If

        ' Perform the Sin operation
        answer = Math.Cos(input)
        txtAnswer.Text = answer.ToString()
        lblTop.Text = ""
    End Sub

    Private Sub btnTan_Click(sender As Object, e As EventArgs) Handles btnTan.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Sin.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(txtAnswer.Text, input) Then
            MessageBox.Show("Invalid input for Sin operation.")
            Return
        End If

        ' Perform the Sin operation
        answer = Math.Tan(input)
        txtAnswer.Text = answer.ToString()
        lblTop.Text = ""
    End Sub

    Private Sub btnExponetial_Click(sender As Object, e As EventArgs) Handles btnExponetial.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(txtAnswer.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Sin.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(txtAnswer.Text, input) Then
            MessageBox.Show("Invalid input for Sin operation.")
            Return
        End If

        ' Perform the Sin operation
        answer = Math.Exp(input)
        txtAnswer.Text = answer.ToString()
        lblTop.Text = ""
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
        MessageBox.Show("Failed to open URL: ")
    End Sub


    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Check if the Enter key is pressed
        If e.KeyCode = Keys.Enter Then
            ' Call the logic you want to perform when Enter is pressed (similar to btnEqual click)
            btnEqual.PerformClick()
        End If
    End Sub
End Class
