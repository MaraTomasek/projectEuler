namespace ConsoleApp1;

public class Problem5 : Problem {
    private static string Headline = @"Smallest multiple";

    private static string Description = @"
    2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

    What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?";
        
    private static string Solution = @"
    Iterate with a step-size of 20, as it will have to be the largest divisor. Simply check all smaller divisors.
    Could be smarter, for example you would not need to check for 5, or 10,
    because the number is already divisible by 20.";

    public Problem5() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const int n         = 20;
        int       candidate = 20;
        bool      found     = false;

        while (!found) {
            bool allTrue = true;
            for (int i = 2; i < n; i++) {
                if (candidate % i != 0 || !allTrue) {
                    allTrue = false;
                    break;
                }
            }

            if (allTrue) {
                found = true;
            } else {
                candidate += n; // Step size of largest divisor 
            }
        }

        return candidate.ToString();
    }
}