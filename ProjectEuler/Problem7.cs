namespace ConsoleApp1;

class Problem7 : Problem {
    const int PRIME = -1;

    public override int Main() {
        /* 10001st prime
            By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
            What is the 10 001st prime number? */


        const int nthPrimeIdx = 10001;
        int       nthPrime    = 0;
        int       iterator    = 2;

        for (int primeCounter = 0; primeCounter < nthPrimeIdx; iterator++) {
            if (GetSmallestDivisor(iterator) == PRIME) {
                primeCounter++;
            }
        }

        nthPrime = iterator;
        return nthPrime;
    }

    // Reused Code from Problem3
    private long GetSmallestDivisor(long number) {
        if (number == 1) return 1;
        if (number == 2) return PRIME;

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