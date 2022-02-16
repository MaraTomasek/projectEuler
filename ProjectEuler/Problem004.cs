namespace ConsoleApp1;

public class Problem4 : Problem {
    public override string Main() {
        /* Largest palindrome product
            A palindromic number reads the same both ways. The largest palindrome made from 
            the product of two 2-digit numbers is 9009 = 91 × 99.

            Find the largest palindrome made from the product of two 3-digit numbers. */

        for (int i = 999; i > 0; i--) {
            for (int j = 999; j > 0; j--) {
                int    calc       = i * j;
                string calcStr    = calc.ToString();
                string revCalcStr = Reverse(calcStr);

                if (calcStr == revCalcStr) {
                    return calcStr;
                }
            }
        }

        return "No Result";
    }

    public static string Reverse(string s) {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}