using ConsoleCalculator;
using static System.Console;

// Note: Additional input validation omitted for brevity

AppDomain currentAppDomain = AppDomain.CurrentDomain;
currentAppDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleException);

WriteLine("Enter first number");
int number1 = int.Parse(ReadLine()!);

WriteLine("Enter second number");
int number2 = int.Parse(ReadLine()!);

WriteLine("Enter operation");
string operation = ReadLine()!.ToUpperInvariant();

try
{
    var calculator = new Calculator();
    int result = calculator.Calculate(number1, number2, operation);
    DisplayResult(result);
}
catch (ArgumentNullException ex) when (ex.ParamName == "operation")
{
    Console.WriteLine("Operation not provided. " + ex);

}
catch (ArgumentNullException ex)
{
    Console.WriteLine("An argument was not provided. " + ex);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Operation not supported. {ex}");
}
catch (Exception ex)
{
    Console.WriteLine("Oops, something went wrong. " + ex);
}


WriteLine("\nPress enter to exit.");
ReadLine();

static void HandleException(object sender, UnhandledExceptionEventArgs e)
{
    Console.WriteLine("Sorry, there was a problem. " + e.ExceptionObject);
}
static void DisplayResult(int result) => WriteLine($"Result is: {result}");