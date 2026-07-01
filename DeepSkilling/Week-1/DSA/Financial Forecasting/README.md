# Financial Forecasting - Recursion Learning

## What is Recursion?
Recursion is when a function calls itself to solve a smaller version of the same problem.

## Key Components of Recursion:
1. **Base Case**: The condition where recursion stops
2. **Recursive Case**: The function calling itself with a smaller problem

## Problem Statement:
Calculate the future value of an investment after a certain number of years with a fixed growth rate.

### Example:
- Initial Amount: $10,000
- Growth Rate: 10% per year
- Years: 3

### Calculation:
- Year 1: $10,000 × 1.10 = $11,000
- Year 2: $11,000 × 1.10 = $12,100
- Year 3: $12,100 × 1.10 = $13,310

## How the Recursive Solution Works:

1. **First Call**: CalculateFutureValue(10000, 0.10, 3)
2. **Second Call**: CalculateFutureValue(11000, 0.10, 2)
3. **Third Call**: CalculateFutureValue(12100, 0.10, 1)
4. **Fourth Call**: CalculateFutureValue(13310, 0.10, 0)
5. **Base Case Reached**: Return 13310

The result flows back up through all the recursive calls.

## Learning Points:
- Every recursive function needs a base case (to stop recursion)
- Each recursive call should move toward the base case
- Recursion can make the code cleaner and easier to understand
