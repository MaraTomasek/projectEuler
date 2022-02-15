namespace ConsoleApp1;

class Problem3 : Problem {
    private const int PRIME = -1;

    public override int Main() {
        /* Largest prime factor
            The prime factors of 13195 are 5, 7, 13 and 29.

            What is the largest prime factor of the number 600851475143 ? */

        const long example              = 13195;
        //const long exampleLargestFactor = 29;

        //const long toCheck = 600851475143;

        List<long> primeFactors = GetPrimeFactors(example);
        primeFactors.Sort();
        
        foreach (var factor in primeFactors) {
            Console.WriteLine(factor);
        }

        return Convert.ToInt32(primeFactors.Last());
    }

    private List<long> GetPrimeFactors(long number) {
        List<long>             factors      = new List<long>();
        List<long>             primeFactors = new List<long>();
        Dictionary<long, bool> isPrimeCache = new Dictionary<long, bool>();
        factors.Add(number);

        foreach (var factor in factors) {
            if (factors.Count == 0) {
                return primeFactors;
            }

            // If key is cached, move to result list to avoid double checking same factors repeatedly
            if (isPrimeCache.ContainsKey(factor)) {
                if (isPrimeCache[factor]) {
                    factors.Remove(factor);
                    primeFactors.Add(factor);
                    continue;
                }
            }

            // Else
            var smallFactor = GetSmallestDivisor(factor);
            if (smallFactor == PRIME) {
                primeFactors.Add(factor);
                isPrimeCache.Add(factor, true);
            }
            else {
                factors.Add(smallFactor);
                factors.Add(factor / smallFactor);
            }

            factors.Remove(factor);
        }

        return new List<long>();
    }

    private long GetSmallestDivisor(long number) {
        long limit = number / 2;

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