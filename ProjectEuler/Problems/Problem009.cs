namespace ConsoleApp1;

public class Problem9 : Problem {
    private static string Headline = @"Special Pythagorean triplet";

    private static string Description = @"
    A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
        a² + b² = c²

    For example, 3² + 4² = 9 + 16 = 25 = 5².

    There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    Find the product abc.";
    
    private static string Solution = @"
    Iterate through a, then through b, which starts at a+1 due to the condition that a < b.
    Now c has to fulfill these three conditions:
        a < b < c 
        c = 1000 - a - b
        c² = a² + b².";

    public Problem9() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const int n = 1000;

        for (int a = 1; a < n - 1; a++) {
            for (int b = a + 1; b < n; b++) {
                int expr = Convert.ToInt32(Math.Pow(a, 2) + Math.Pow(b, 2));

                int c = n - a - b;
                if (c < b) break;

                if (expr == Convert.ToInt32(Math.Pow(c, 2))) {
                    return (a * b * c).ToString();
                }
            }
        }

        return "No Result";
    }
}