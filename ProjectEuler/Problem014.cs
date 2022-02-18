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
    Instead of calculating each sequence from start to finish, cache each previous result in a dictionary,
    with the starting-number as key and its chain-length as value. This way, only a fragment of the entire chain 
    needs to be calculated.
    In the end find the maximum chain-length and its associated number.";

    public Problem14() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const int n = 1000000;

        // Key: startingNumber, Value: ChainLength,
        Dictionary<int, int> collatzCache = new Dictionary<int, int>() {{1, 1}};

        for (int startingNumber = 2; startingNumber < n; startingNumber++) {
            int i           = startingNumber;
            int chainLength = 0;

            while (i != 1) {
                if (collatzCache.ContainsKey(i)) {
                    collatzCache.Add(startingNumber, chainLength + collatzCache[i]);
                    break;
                }

                if (i % 2 == 0) {
                    i /= 2;
                    chainLength++;
                } else {
                    i = 3 * i + 1;
                    chainLength++;
                }
            }
        }

        int maxChainNumber = collatzCache.Aggregate(
            (tmpMax, compare) => tmpMax.Value > compare.Value ? tmpMax : compare).Key;

        return maxChainNumber.ToString();
    }
}