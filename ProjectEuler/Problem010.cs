namespace ConsoleApp1;

public class Problem10 : Problem {
    public override int Main() {
        /* Summation of primes
            The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

            Find the sum of all the primes below two million. */

        const int n   = 2000000;
        int       sum = 0;

        for (int i = 2; i < n; i++) {
            if (Problem3.GetSmallestDivisor(i) == PRIME) {
                sum += i;
            }
        }

        return sum;
    }
}