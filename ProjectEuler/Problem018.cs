namespace ConsoleApp1;

public class Problem18 : Problem {
    private static string Headline = @"Maximum path sum I";

    private static string Description = @"
    By starting at the top of the triangle below and moving to adjacent numbers on the row below, 
    the maximum total from top to bottom is 23.

        3
        7 4
        2 4 6
        8 5 9 3

    That is, 3 + 7 + 4 + 9 = 23.

    Find the maximum total from top to bottom of the triangle below:

        75
        95 64
        17 47 82
        18 35 87 10
        20 04 82 47 65
        19 01 23 75 03 34
        88 02 77 73 07 63 67
        99 65 04 28 06 16 70 92
        41 41 26 56 83 40 80 70 33
        41 48 72 33 47 32 37 16 94 29
        53 71 44 65 25 43 91 52 97 51 14
        70 11 33 28 77 73 17 78 39 68 17 57
        91 71 52 38 17 14 91 43 58 50 27 29 48
        63 66 04 68 89 53 67 30 73 16 69 87 40 31
        04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

    NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. 
    However, Problem 67, is the same challenge with a triangle containing one-hundred rows; 
    it cannot be solved by brute force, and requires a clever method! ;o)";

    private static string Solution = @"
    Create the ""path of highest sums"" from the bottom upwards.
    Start at the second-last layer. Each node picks the child with the highest value. 
    The new value of the node is the sum of its value and its child - call it the sum value.
    In the next layer, each node picks the child with the highest sum value. 
    Continue until you've reached the top. You have then found the maximum total path from top to bottom.";

    public Problem18() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        string triangleRaw = @"75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

        const int height        = 15;
        const int width         = 15;
        string[]  triangleSplit = triangleRaw.Split(Environment.NewLine);
        int[,]    triangleInt   = new int[height, width];
        int[,]    pathSum       = new int[height, width];

        for (int i = 0; i < height; i++) {
            var line = triangleSplit[i].Split(" ");

            for (int j = 0; j < line.Length; j++) {
                triangleInt[i, j] = Convert.ToInt32(line[j]);
            }
        }

        for (int i = 0; i < width; i++) {
            pathSum[height - 1, i] = triangleInt[height - 1, i];
        }

        for (int btt = height - 2; btt >= 0; btt--) {
            for (int ltr = 0; ltr <= btt; ltr++) {
                pathSum[btt, ltr] = triangleInt[btt, ltr] + Math.Max(pathSum[btt + 1, ltr], pathSum[btt + 1, ltr + 1]);
            }
        }

        return pathSum[0, 0].ToString();
    }
}