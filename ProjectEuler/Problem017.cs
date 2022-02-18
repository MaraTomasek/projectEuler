namespace ConsoleApp1;

public class Problem17 : Problem {
    private static string Headline = @"Number letter counts";

    private static string Description = @"
    If the numbers 1 to 5 are written out in words: one, two, three, four, five, 
    then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

    If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, 
    how many letters would be used?

    NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) 
    contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. 
    The use of ""and"" when writing out numbers is in compliance with British usage.";
    
    private static string Solution = @"
    Count the letters for all the words, which make up any possible number in the requested range.
    Use a couple of switch statements which can be used to technically build any numbers' word correctly, 
    but we only use it to count the amount of letters instead.";

    public Problem17() : base(Headline, Description, Solution) {
    }

    private readonly string[] _singleDigitNames = new string[] {
        "zero", "one", "two", "three", "four",
        "five", "six", "seven", "eight", "nine"
    };

    private readonly string[] _doubleDigitNames = new string[] {
        "", "ten", "twenty", "thirty", "forty",
        "fifty", "sixty", "seventy", "eighty", "ninety"
    };

    private readonly string[] _specialDoubleDigitNames = new string[] {
        "ten", "eleven", "twelve", "thirteen", "fourteen",
        "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
    };

    private const string And      = "and";
    private const string Hundred  = "hundred";
    private const string Thousand = "thousand";

    private readonly int[] _singleDigitLengths  = new int[10];
    private readonly int[] _doubleDigitLengths  = new int[10];
    private readonly int[] _specialDigitLengths = new int[10];

    private readonly int _andLength      = And.Length;
    private readonly int _hundredLength  = Hundred.Length;
    private readonly int _thousandLength = Thousand.Length;


    public override string Main() {
        const int s = 1;
        const int n = 1000;

        for (int i = 0; i < 10; i++) {
            _singleDigitLengths[i]  = _singleDigitNames[i].Length;
            _doubleDigitLengths[i]  = _doubleDigitNames[i].Length;
            _specialDigitLengths[i] = _specialDoubleDigitNames[i].Length;
        }

        int sum = 0;
        for (int i = s; i <= n; i++) {
            sum += GetLetterCount(i);
        }

        return sum.ToString();
    }

    private int GetLetterCount(int number) {
        int    digits      = 4;
        char[] numberStr   = number.ToString().PadLeft(digits).Replace(" ", "0").ToCharArray();
        int[]  intStr      = new int[digits];
        bool   thousands   = false;
        bool   hundreds    = false;
        bool   tens        = false;
        bool   useSpecials = false;

        for (int i = 0; i < digits; i++) {
            intStr[i] = (int) char.GetNumericValue(numberStr[i]);
        }

        int word = 0;
        switch (intStr[0]) {
            case 0:
                break;
            default:
                thousands =  true;
                word      += _singleDigitLengths[intStr[0]];
                word      += _thousandLength;
                break;
        }

        switch (intStr[1]) {
            case 0:
                break;
            default:
                hundreds =  true;
                word     += _singleDigitLengths[intStr[1]];
                word     += _hundredLength;
                break;
        }

        switch (intStr[2]) {
            case 0:
                break;
            case 1:
                useSpecials =  true;
                word        += _andLength;
                break;
            default:
                tens =  true;
                word += _andLength;
                word += _doubleDigitLengths[intStr[2]];
                break;
        }

        switch (intStr[3]) {
            case 0:
                break;
            default:
                if (useSpecials) {
                    word += _specialDigitLengths[intStr[3]];
                } else if ((thousands || hundreds) && !tens) {
                    word += _andLength;
                    word += _singleDigitLengths[intStr[3]];
                } else {
                    word += _singleDigitLengths[intStr[3]];
                }

                break;
        }

        return word;
    }
}