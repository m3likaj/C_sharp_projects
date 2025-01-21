Console.Write("Enter a number: ");
double num1 = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter the opeation (+, -, *, /): ");
char operation = Convert.ToChar(Console.ReadLine());

Console.Write("Enter the second number: ");
double num2 = Convert.ToDouble(Console.ReadLine());
double result = 0;
bool valid = true;

switch (operation)
{
    case '+':
        result = num1 + num2;
        break;
    case '-':
        result = num1 - num2;
        break;
    case '*':
        result = num1 * num2;
        break;
    case '/':
        result = num1 / num2;
        break;

    default:
        Console.WriteLine("Invalid input");
        valid = false;
        break;
}
if (valid)
    Console.WriteLine($"{num1} {operation} {num2} = {result}");