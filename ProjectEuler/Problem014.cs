namespace ConsoleApp1;

public class Problem14 : Problem {
    private static string Headline = @"Longest Collatz sequence";

    private static string Description = @"
    The following iterative sequence is defined for the set of positive integers:

        n → n/2 (n is even)
        n → 3n + 1 (n is odd)

    Using the rule above and starting with 13, we generate the following sequence:
            
        13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1

    It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. 
    Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

    Which starting number, under one million, produces the longest chain?
    NOTE: Once the chain starts the terms are allowed to go above one million.";

    private static string Solution = @"
    I have not figured out a smart solution for this yet, 
    so here is a stupid one that has not yet delivered a result,
    because it took forever too run and I'm impatient.
    It checks every number from 1 to 1.000.000 and keeps the longest chain.

    It would benefit from parallelization.";

    public Problem14() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const int n              = 1000000;
        int       maxChainLength = 0;
        int       maxChainNumber = 0;

        for (int startingNumber = 1; startingNumber < n; startingNumber++) {
            int i           = startingNumber;
            int chainLength = 0;

            while (i != 1) {
                if (i % 2 == 0) {
                    i /= 2;
                    chainLength++;
                } else {
                    i = 3 * i + 1;
                    chainLength++;
                }
            }

            if (chainLength <= maxChainLength) continue;
            maxChainLength = chainLength;
            maxChainNumber = startingNumber;
        }

        return maxChainNumber.ToString();
    }
}