namespace ConsoleApp1;

public class Problem15 : Problem {
    private static string Headline = @"Lattice paths";

    private static string Description = @"
    Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, 
    there are exactly 6 routes to the bottom right corner.
    
    How many such routes are there through a 20×20 grid?";

    public Problem15() : base(Headline, Description) {
    }

    private const    int    Height      = 21;
    private const    int    Width       = 21;
    private readonly int[,] _pathMatrix = new int[Height, Width];

    public override string Main() {
        for (int i = 0; i < Width; i++) {
            _pathMatrix[0, i] = 1;
            _pathMatrix[i, 0] = 1;
        }

        for (int col = 1; col < Width; col++) {
            for (int row = 1; row < Height; row++) {
                _pathMatrix[col, row] = _pathMatrix[col, row - 1] + _pathMatrix[col - 1, row];
            }
        }

        return _pathMatrix[20, 20].ToString();
    }
}