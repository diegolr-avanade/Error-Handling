namespace ConsoleCalculator;

public class Calculator
{
    public int Calculate(int number1, int number2, string operation)
    {
        string notNullOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        if (notNullOperation == "/")
        {
            try
            {
                return Divide(number1, number2);

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("logging...");
                throw new ArithmeticException("An error occurred during calculaiton.",ex);
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(operation), "The mathematical operator is not supported.");
        }
    }

    private int Divide(int number, int divisor) => number / divisor;
}

