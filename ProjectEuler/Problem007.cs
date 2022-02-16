namespace ConsoleApp1;

class Problem7 : Problem {
    private static string Headline = @"10001st prime";

    private static string Description = @"
    By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    What is the 10 001st prime number? ";

    public Problem7() : base(Headline, Description) {
    }

    public override string Main() {
        const int nthPrimeIdx = 10001;
        int       nthPrime    = 0;
        int       iterator    = 2;

        for (int primeCounter = 0; primeCounter < nthPrimeIdx; iterator++) {
            if (Problem3.GetSmallestDivisor(iterator) == PRIME) {
                primeCounter++;
            }
        }

        nthPrime = iterator;
        return nthPrime.ToString(
        );
    }
}