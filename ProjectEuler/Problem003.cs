using System.Diagnostics;

namespace ConsoleApp1;

public class Problem3 : Problem {
    private static string Headline = @"Largest prime factor";

    private static string Description = @"
    The prime factors of 13195 are 5, 7, 13 and 29.

    What is the largest prime factor of the number 600851475143?";
    
    private static string Solution = @"
    Have a Queue for finding factors. If a factor turns out to be prime, cache it. 
    This way we dont have to check the whole number again the next time it turns up.
    In checking a number for primeness, only check 2 and odd numbers as possible divisor 
    - and only up until half the number itself.

    In the end sort the list of found prime factors and choose the largest.";
    

    public Problem3() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const long toCheck = 600851475143;

        List<long> primeFactors = GetPrimeFactors(toCheck);
        primeFactors.Sort();

        return primeFactors.Last().ToString();
    }

    private List<long> GetPrimeFactors(long number) {
        Queue<long>            factors      = new Queue<long>();
        List<long>             primeFactors = new List<long>();
        Dictionary<long, bool> isPrimeCache = new Dictionary<long, bool>();
        factors.Enqueue(number);

        while (factors.Any()) {
            var factor = factors.Dequeue();

            // If key is cached, move to result list to avoid double checking same factors repeatedly
            // NOTE: Caching is sadly unnecessary here
            if (isPrimeCache.ContainsKey(factor)) {
                if (isPrimeCache[factor]) {
                    primeFactors.Add(factor);
                }
            } else {
                var smallFactor = GetSmallestDivisor(factor);
                if (smallFactor == PRIME) {
                    primeFactors.Add(factor);
                    isPrimeCache.Add(factor, true);
                } else {
                    factors.Enqueue(smallFactor);
                    factors.Enqueue(factor / smallFactor);
                }
            }
        }

        return primeFactors;
    }

    public static long GetSmallestDivisor(long number) {
        Debug.Assert(number > 0);

        if (number == 1) return 1;
        if (number == 2) return PRIME;

        long limit = number / 2;

        // IDE says this is always false but I don't see how
        if (number % 2 == 0) {
            return 2;
        }

        for (long i = 3; i < limit; i += 2) {
            if (number % i == 0) {
                return i;
            }
        }

        return PRIME;
    }
}