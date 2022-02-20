namespace ConsoleApp1;

public class Problem6 : Problem {
    private static string Headline = @"Sum square difference";

    private static string Description = @"
    The sum of the squares of the first ten natural numbers is,
        1² + 2² + ... + 10² = 385
    The square of the sum of the first ten natural numbers is,
        (1 + 2 + ... + 10)² = 3025
    Hence the difference between the sum of the squares of the 
    first ten natural numbers and the square of the sum is
        3025 - 385 = 2640
        
    Find the difference between the sum of the squares of the 
    first one hundred natural numbers and the square of the sum.";
    
    private static string Solution = @"
    Just a simple calculation.";

    public Problem6() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const int n            = 100;
        int       sumOfSquares = 0;
        int       squareOfSum  = 0;
        int       difference   = 0;

        for (int i = 0; i < n; i++) {
            sumOfSquares += Convert.ToInt32(Math.Pow(i, 2));
            squareOfSum  += i;
        }

        squareOfSum = Convert.ToInt32(Math.Pow(squareOfSum, 2));
        difference  = squareOfSum - sumOfSquares;

        return difference.ToString();
    }
}