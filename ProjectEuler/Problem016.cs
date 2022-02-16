namespace ConsoleApp1;

public class Problem16 : Problem {
    public override string Main() {
        /* Power digit sum
            2^(15) = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
            What is the sum of the digits of the number 2^(1000)? */

        const int baseNumber = 2;
        const int exponent   = 1000;

        string numberStr = baseNumber.ToString();
        for (int i = 0; i < exponent; i++) {
            numberStr = stringMultBy2(numberStr);
        }

        return sumOfDigits(numberStr).ToString();
    }

    public static int sumOfDigits(string str) {
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
            int    digit        = Convert.ToInt32(numStr.Substring(i, 1));
            int    subResult    = digit * 2;
            string subResultStr = subResult.ToString();

            subResultStr = subResultStr.PadRight(i).Replace(" ", "0");

            subResults.Push(subResultStr);
        }

        var    additions = subResults.Count;
        string result    = subResults.Pop();
        while (subResults.Any()) {
            result = Problem13.StringAddition(result, subResults.Pop());
        }

        return result;
    }
}