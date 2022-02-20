namespace ConsoleApp1;

/*  */

class Problem1 : Problem {
    private static string Headline = @"Multiples of 3 or 5";

    private static string Description = @"
    If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
    The sum of these multiples is 23.
    
    Find the sum of all the multiples of 3 or 5 below 1000.";

    private static string Solution = @"
    Iterate through all numbers below 1000, and check if they're divisible through 3 or 5.
    If they are, add them to the sum.";

    public Problem1() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const int n   = 1000;
        int       sum = 0;

        for (int i = 0; i < n; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                sum += i;
            }
        }

        return sum.ToString();
    }
}