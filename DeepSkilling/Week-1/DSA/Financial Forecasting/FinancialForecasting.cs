using System;

class FinancialForecasting
{
    // Recursive Method to Calculate Future Value
    // This method calls itself to calculate value year by year
    static double CalculateFutureValue(double currentValue, double growthRate, int yearsRemaining)
    {
        // Base Case: When no more years left, return the current value
        if (yearsRemaining == 0)
        {
            return currentValue;
        }

        // Recursive Case: Calculate value for next year and call recursively
        double nextYearValue = currentValue * (1 + growthRate);
        return CalculateFutureValue(nextYearValue, growthRate, yearsRemaining - 1);
    }

    static void Main()
    {
        // Initial Investment
        double initialAmount = 10000;

        // Growth Rate (10% per year)
        double growthPercentage = 0.10;

        // Number of Years to Calculate
        int numberOfYears = 3;

        // Call the recursive method
        double finalAmount = CalculateFutureValue(initialAmount, growthPercentage, numberOfYears);

        // Display Results
        Console.WriteLine("=== Financial Forecasting ===");
        Console.WriteLine("Initial Amount: $" + initialAmount);
        Console.WriteLine("Growth Rate: " + (growthPercentage * 100) + "%");
        Console.WriteLine("Number of Years: " + numberOfYears);
        Console.WriteLine("Final Amount: $" + finalAmount);
    }
}
