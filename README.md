# Scientific Calculator
A scientific calculator program capable of performing basic arithmetic operations, trigonometric functions, logarithms, unit conversions, and hexadecimal conversions, with error handling for invalid inputs and overflow exceptions.

### Class: Form1

#### Variables:
- `f`, `s`, `a`: Variables to store numeric values for arithmetic operations.
- `op`: Stores the arithmetic operation (+, -, *, /, Mod, Exp).
- `n`: Used for integer operations.

#### Methods:

##### Arithmetic Operations (`Button_Click`)
- Handles events for numeric buttons (0-9) and decimal point (.).
- Concatenates the clicked button's value to the displayed number.

##### Clear Function (`Button14_Click`, `Button12_Click`)
- Resets the displayed number and any ongoing arithmetic operation.

##### Arithmetic Functions (`Arithmetic_function`)
- Triggers arithmetic operations when an arithmetic function button is clicked (+, -, *, /, Mod, Exp).
- Captures the first number (`f`), the operator (`op`), and updates the display for the second number.

##### Equals/Calculate Function (`Button11_Click`)
- Computes the result based on the stored operator and the entered numbers.
- Handles arithmetic operations (+, -, *, /, Mod, Exp).
- Displays the result in the label (`Label3`).

##### Decimal to Binary Conversion (`Button24_Click`)
- Converts a decimal number to its binary representation.
- Splits the input into integer and fractional parts.
- Converts the integer part to binary using `Convert.ToString`.
- Converts the fractional part by multiplying and checking bits.
- Handles possible overflow exceptions.

##### Trigonometric Functions (`Button19_Click`, `Button20_Click`, `Button21_Click`, `Button25_Click`)
- Calculates the Sin, Cos, Tan, and Log functions of the entered number.
- Displays the result in the label (`Label3`).

##### Unit Conversion (`Button28_Click`)
- Performs various unit conversions based on the selected item in `ComboBox1`.
- Handles different conversion types like Celsius to Fahrenheit, Miles to Kilometres, etc.
- Displays the converted result in the `Unitshow` label.

##### Menu Item Click Handlers
- Control the resizing of the form based on the selected menu item.

##### Form Load (`Form1_Load`)
- Initializes the form by setting initial dimensions and populating the ComboBox with conversion options.

##### Help Information (`HelpToolStripMenuItem_Click`)
- Shows an informational message box about the application.

##### Hexadecimal Conversion (`btnHex_Click`)
- Converts the displayed number to its hexadecimal representation.
- Displays the converted value in the label (`Label3`).

#### Additional Notes:
- Error handling is implemented to validate input and display appropriate messages for invalid input or errors.
- The application provides functionality for basic arithmetic operations, trigonometric functions, unit conversion, and hexadecimal conversion.

This summary should serve as a guide to understanding the functionalities and organization of the code in Form1. Feel free to add more detailed comments or explanations where needed to further clarify specific sections or functionalities within the code.
## Optimizations

It takes me hours of coding to handle invalid inputs and overflow exceptions.

If you have the moral, you can improve labeling the button and other elements in Form 1, and you can request pull requests.

## License

[MIT](https://choosealicense.com/licenses/mit/)


## Logo

Calculator icon by Icons8
