namespace ConsoleApp1;

public class Problem10 : Problem {
    private static string Headline = @"Summation of primes";

    private static string Description = @"
    The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

    Find the sum of all the primes below two million.";
    
    private static string Solution = @"
    Find all primes below two million and sum them up. 
    Reuse the prime function from Problem 3";

    public Problem10() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const int n   = 2000000;
        int       sum = 0;

        for (int i = 2; i < n; i++) {
            if (Problem3.GetSmallestDivisor(i) == PRIME) {
                sum += i;
            }
        }

        return sum.ToString();
    }
}