using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;

namespace ConsoleApp1;

public class Problem22 : Problem {
    private static string Headline = @"Names scores";

    private static string Description = @"
    Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over 
    five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical 
    value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

    For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, 
    is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.
    What is the total of all the name scores in the file?";

    private static string Solution = @"
    Read all Names and sort them with the built-in sorting method. To score a character, cast it to int and remove 64.
    This gives the position in the alphabet.";

    public Problem22() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        var allNames = System.IO.File.ReadAllText("../../../Resources/p022_names.txt")
            .Replace("\"", "")
            .Split(",");
        var  nameCount  = allNames.Length;
        long totalScore = 0;

        Array.Sort(allNames);

        for (var i = 0; i < nameCount; i++) {
            totalScore += (i + 1) * Score(allNames[i]);
        }

        return totalScore.ToString();
    }

    private static int Score(string name) {
        return name.Sum(Score);
    }

    private static int Score(char letter) {
        return letter - 64;
    }
}