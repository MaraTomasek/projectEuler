namespace ConsoleApp1; 

public class Problem20 : Problem{
    private static string Headline = @"Factorial Digit Sum";
    
    private static string Description = @"
    n! means n × (n − 1) × ... × 3 × 2 × 1

    For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

    Find the sum of the digits in the number 100!";
    
    private static string Solution = @"
    100! is too large to store (=9*10^157). Resort to treating multiplication as a series of additions. 
    We can then use the string addition from Problem 13: ""Large sum"". 
    Also reuse code from Problem 16: ""Factorial digit sum"" to add up the digits.";
    
    public Problem20() : base(Headline, Description, Solution) {
    }
        
    public override string Main() {
        const int start   = 2;
        const int end     = 10;
        string    product = "1";

        for (int i = start; i <= end; i++) {
            string temp = product;
            for (int j = start; j <= i; j++) {
                product = Problem13.StringAddition(product, temp);
            }
        }

        return Problem16.SumOfDigits(product).ToString();
    }
    
    
}