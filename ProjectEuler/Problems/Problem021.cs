namespace ConsoleApp1;

public class Problem21 : Problem {
    private static string Headline = @"Amicable numbers";

    private static string Description = @"
    Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair 
    and each of a and b are called amicable numbers.

    For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; 
    therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

    Evaluate the sum of all the amicable numbers under 10000.";

    private static string Solution = @"
    By keeping track of which numbers d(a), d(b) we've checked, 
    we reduce the total amount of numbers we need to test.";

    public Problem21() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const int n               = 10000;
        var       alreadyChecked  = new HashSet<int>();
        var       amicableNumbers = new List<int>();

        for (int i = 1; i < n; i++) {
            if (alreadyChecked.Contains(i)) continue;

            int di = CalcDivisorSum(i);
            if (i != di && i == CalcDivisorSum(di)) {
                amicableNumbers.Add(i);
                amicableNumbers.Add(di);

                alreadyChecked.Add(di);
            }

            alreadyChecked.Add(i);
        }

        return amicableNumbers.Sum().ToString();
    }

    public static List<int> FindProperDivisors(int number) {
        var divisors = new List<int>();

        for (int i = 1; i <= Math.Sqrt(number); i++) {
            if (number % i == 0) {
                divisors.Add(i);
                int otherDivisor = number / i;
                
                if (i != otherDivisor && i != 1) {
                    divisors.Add(otherDivisor);
                }
            }
        }

        return divisors;
    }

    private int CalcDivisorSum(int number) {
        return FindProperDivisors(number).Sum();
    }
}