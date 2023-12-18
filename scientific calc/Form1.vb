Public Class Form1

    Dim f As Double
    Dim s As Double
    Dim a As Double
    Dim op As String
    Dim n As Int32

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button3.Click, Button2.Click, Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button15.Click, Button13.Click
        ' Code for button 1 to 9, 0
        Dim b As Button = sender
        Dim buttonText As String = b.Text

        ' Check for an already existing dot '.' in the text
        If buttonText = "." AndAlso Label3.Text.Contains(".") Then
            ' Do not allow multiple dots in the number
            Return
        End If

        ' Check if the label text is '0' before concatenating
        If Label3.Text = "0" Then
            Label3.Text = buttonText
        Else
            Label3.Text = Label3.Text + buttonText
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Label3.Text = "0"
        Label1.Text = ""
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Label3.Text = "0"
        Label1.Text = ""
    End Sub

    Private Sub Arithmetic_function(sender As Object, e As EventArgs) Handles Button18.Click, Button17.Click, Button16.Click, Button10.Click, Button26.Click, Button23.Click
        ' Check if Label3.Text is empty
        Label1.Visible = True
        If String.IsNullOrWhiteSpace(Label3.Text) Then
            MessageBox.Show("Invalid input for arithmetic operation.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(Label3.Text, input) Then
            ' Display an error message or handle invalid input here
            MessageBox.Show("Invalid input for arithmetic operation.")
            Return
        End If

        f = input
        Label1.Text = Label3.Text
        Label3.Text = ""
        op = DirectCast(sender, Button).Text
        Label1.Text = Label1.Text + " " + op
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        s = 0
        If Not Double.TryParse(Label3.Text, s) Then
            ' Display an error message or handle invalid input here
            MessageBox.Show("Invalid input for arithmetic operation.")
            Return
        End If

        If op = "+" Then
            a = f + s
        ElseIf op = "-" Then
            a = f - s
        ElseIf op = "*" Then
            a = f * s
        ElseIf op = "/" Then
            ' Check for division by zero
            If s = 0 Then
                MessageBox.Show("Cannot divide by zero.")
                Return
            Else
                a = f / s
            End If
        ElseIf op = "Mod" Then
            ' Perform the Mod operation
            a = f Mod s
        ElseIf op = "Exp" Then
            a = Math.Pow(f, s)
        Else
            ' Handle invalid operation
            MessageBox.Show("Invalid operation.")
            Return
        End If
        Label1.Visible = True
        Label3.Text = a.ToString()
        Label1.Text = ""
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        If String.IsNullOrWhiteSpace(Label3.Text) Then
            MsgBox("Please enter a decimal number for conversion.", vbInformation, "Info")
            Return
        End If

        Dim decimalInput As Double
        If Not Double.TryParse(Label3.Text, decimalInput) Then
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
            Label3.Text = binaryIntegerPart & binaryFractionalPart.ToString()
            Label1.Visible = False

        Catch ex As OverflowException
            MessageBox.Show("An overflow occurred. The number entered is too large to convert.", "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Label3.Text = ""
            Label1.Visible = True
        End Try
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(Label3.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Sin.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(Label3.Text, input) Then
            MessageBox.Show("Invalid input for Sin operation.")
            Return
        End If

        ' Perform the Sin operation
        a = Math.Sin(input)
        Label3.Text = a.ToString()
        Label1.Text = ""
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(Label3.Text) Then
            MessageBox.Show("Invalid input for Cos operation.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(Label3.Text, input) Then
            MessageBox.Show("Invalid input for Cos operation.")
            Return
        End If

        ' Perform the Cos operation
        a = Math.Cos(input)
        Label3.Text = a.ToString()
        Label1.Text = ""
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(Label3.Text) Then
            MessageBox.Show("Invalid input for Tan operation.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(Label3.Text, input) Then
            MessageBox.Show("Invalid input for Tan operation.")
            Return
        End If

        ' Perform the Tan operation
        a = Math.Tan(input)
        Label3.Text = a.ToString()
        Label1.Text = ""
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        ' Check if the input is empty or not a valid number
        If String.IsNullOrWhiteSpace(Label3.Text) Then
            MessageBox.Show("Please enter a valid number to calculate Log.")
            Return
        End If

        Dim input As Double
        If Not Double.TryParse(Label3.Text, input) Then
            MessageBox.Show("Invalid input for Log operation.")
            Return
        End If

        ' Perform the Log operation
        a = Math.Log(input)
        Label3.Text = a.ToString()
        Label1.Text = ""
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
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

    Private Sub ScientificToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScientificToolStripMenuItem.Click
        'Code for extend form
        Me.Height = 411
        Me.Width = 446
        Button11.Width = 288
        Label3.Width = 404
    End Sub

    Private Sub UnitConversionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnitConversionToolStripMenuItem.Click
        'Code for extend form
        Me.Height = 411
        Me.Width = 712
        Button11.Width = 288
        Label3.Width = 404
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'code to exit
        Application.Exit()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        ' to clear unit convert
        Unitshow.Text = ""
        TextBox1.Text = ""
    End Sub

    Private Sub StandardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StandardToolStripMenuItem.Click
        'Code for extend form
        Me.Height = 411
        Me.Width = 310
        Button11.Width = 151
        Label3.Width = 267
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 411
        Me.Width = 310
        Button11.Width = 151
        Label3.Width = 267

        ComboBox1.Text = "Choose one..."
        ComboBox1.Items.Add("Celsius to Fahrenheit")
        ComboBox1.Items.Add("Fahrenheit to Celsius")
        ComboBox1.Items.Add("Miles to Kilometres")
        ComboBox1.Items.Add("Kilometres to Miles")
        ComboBox1.Items.Add("Centimetre to Metres")
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        ' About
        MsgBox("Hi I Am NattyXO.This Is My First Scientific Calculator.
              
Ahadu Tech Studio® 
Scientific Calculator
Github: NattyXO
© 2019 Ahadu Inc. All rights reserved.
Version 1.0.2(Official Build)")
    End Sub

    Private Sub btnHex_Click(sender As Object, e As EventArgs) Handles btnHex.Click
        If Not String.IsNullOrWhiteSpace(Label3.Text) Then
            Dim input As Double
            If Double.TryParse(Label3.Text, input) Then
                Try
                    ' Convert the input to its hexadecimal representation
                    Dim hexValue As String = Convert.ToString(Convert.ToInt64(input), 16)
                    Label3.Text = hexValue
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

End Class
