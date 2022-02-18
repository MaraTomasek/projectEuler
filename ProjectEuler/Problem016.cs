namespace ConsoleApp1;

public class Problem16 : Problem {
    private static string Headline = @"Power digit sum";

    private static string Description = @"
    2^(15) = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
    What is the sum of the digits of the number 2^(1000)?";
    
    private static string Solution = @"
    First of all, 2^(1000) is way too large for a normal datatype.
    So I implemented a string-based multiplication method akin to multiplying by hand.
    For example:

        1178 * 2 = 2356
            16
        +  14x
        +  2xx
        + 2xxx
          ----
          2356
        
    x here represents padding with 0.

    The result is a number ~1*10^(301), 
    but it is easy to add up its digits, because it is already stored in a string.";

    public Problem16() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const int baseNumber = 2;
        const int exponent   = 1000;

        string numberStr = baseNumber.ToString();
        for (int i = 1; i < exponent; i++) {
            numberStr = stringMultBy2(numberStr);
        }

        return SumOfDigits(numberStr).ToString();
    }

    private static int SumOfDigits(string str) {
        char[] chStr = str.ToCharArray();
        int    sum   = 0;
        foreach (var character in chStr) {
            sum += Convert.ToInt32(character);
        }

        return sum;
    }

    private string stringMultBy2(string numberStr) {
        var    subResults = new Stack<string>(); // Stack so we start with large numbers
        string numStr     = Problem4.Reverse(numberStr);

        for (int i = 0; i < numStr.Length; i++) {
            int digit = Convert.ToInt32(numStr.Substring(i, 1));
            if (digit == 0) continue;
            int    subResult    = digit * 2;
            string subResultStr = subResult.ToString();

            subResultStr = subResultStr.PadRight(i + subResultStr.Length).Replace(" ", "0");

            subResults.Push(subResultStr);
        }

        string result = subResults.Pop();
        while (subResults.Any()) {
            result = Problem13.StringAddition(result, subResults.Pop());
        }

        return result;
    }
}