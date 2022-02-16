namespace ConsoleApp1;

public abstract class Problem {
    public          string Headline;
    public          string Description;
    protected const int    PRIME = -1; // For exercises which deal with primes 

    protected Problem(string headline, string description) {
        Headline    = headline;
        Description = description;
    }

    public abstract string Main();
}