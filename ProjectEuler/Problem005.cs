namespace ConsoleApp1;

public class Problem5 : Problem {
    private static string Headline = @"Smallest multiple";

    private static string Description = @"
    2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

    What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?";

    public Problem5() : base(Headline, Description) {
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