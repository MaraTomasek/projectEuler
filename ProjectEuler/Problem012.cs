namespace ConsoleApp1;

public class Problem12 : Problem {
    private static string Headline = @"Highly divisible triangular number";

    private static string Description = @"
    The sequence of triangle numbers is generated by adding the natural numbers. 
    So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. 
    The first ten terms would be:

        1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

    Let us list the factors of the first seven triangle numbers:

         1: 1
         3: 1,3
         6: 1,2,3,6
        10: 1,2,5,10
        15: 1,3,5,15
        21: 1,3,7,21
        28: 1,2,4,7,14,28

    We can see that 28 is the first triangle number to have over five divisors.
    What is the value of the first triangle number to have over five hundred divisors?";
    
    private static string Solution = @"
    Keep generating new triangle numbers until one is found which has >500 divisors.";

    public Problem12() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const int neededDivisors  = 500;
        int       triangleNumber  = 1;
        int       currentDivisors = findDivisorAmount(triangleNumber);

        for (int nextNaturalNumber = 2; currentDivisors <= neededDivisors; nextNaturalNumber++) {
            triangleNumber  += nextNaturalNumber;
            currentDivisors =  findDivisorAmount(triangleNumber);
        }

        return triangleNumber.ToString();
    }

    public int findDivisorAmount(int number) {
        if (number == 0) return 0;
        if (number == 1) return 1;

        int limit         = number / 2;
        int divisorAmount = 2; // Initial divisors are the 1 and the number itself

        for (int i = 2; i < limit; i++) {
            if (number % i == 0) {
                divisorAmount++;
            }
        }

        // takes a while:
        // Solution to Problem 12: 76576500
        return divisorAmount;
    }
}