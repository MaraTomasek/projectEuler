namespace ConsoleApp1;

public abstract class Problem {
    public readonly string Headline;
    public readonly string Description;
    public readonly string Solution;
    protected const int    PRIME    = -1; // For exercises which deal with primes 

    protected Problem(string headline, string description, string solution) {
        Headline    = headline;
        Description = description;
        Solution    = solution;
    }

    public abstract string Main();
}