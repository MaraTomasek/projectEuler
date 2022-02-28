namespace ConsoleApp1;

public class Problem23 : Problem {
    private static string Headline = @"Non-abundant sums";

    private static string Description = @"
    A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
    For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, 
    which means that 28 is a perfect number.

    A number n is called deficient if the sum of its proper divisors is less than n 
    and it is called abundant if this sum exceeds n.

    As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, 
    the smallest number that can be written as the sum of two abundant numbers is 24. 
    By mathematical analysis, it can be shown that all integers greater than 28123 can be written 
    as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even 
    though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers 
    is less than this limit.

    Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.";

    private static string Solution = @"";

    public Problem23() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const int n                = 28123;
        const int smallestAbundant = 12;

        int nonAbundantSum  = 0;
        var abundantNumbers = new List<int>();

        for (var i = smallestAbundant; i <= n; i++) {
            if (IsAbundant(i)) abundantNumbers.Add(i);
        }

        var abundantNumbersCount = abundantNumbers.Count;

        // Main Loop
        for (var i = 1; i <= n; i++) {
            var isSumOfAbundants = false;

            for (var j = 0; j < abundantNumbersCount; j++) {
                if (abundantNumbers[j] * 2 > i) break;

                for (var k = j; k < abundantNumbersCount; k++) {
                    var tempSum = abundantNumbers[j] + abundantNumbers[k];
                    if (tempSum > i) {
                        break;
                    }

                    if (tempSum == i) {
                        isSumOfAbundants = true;
                        break;
                    }
                }

                if (isSumOfAbundants) {
                    break;
                }
            }

            if (!isSumOfAbundants) nonAbundantSum += i;
        }

        return nonAbundantSum.ToString();
    }

    private static bool IsAbundant(int number) {
        var divisorSum = Problem21.FindProperDivisors(number).Sum();

        return number < divisorSum;
    }
}