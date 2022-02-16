namespace ConsoleApp1;

public class Problem15 : Problem {
    private static string Headline = @"Lattice paths";

    private static string Description = @"
    Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, 
    there are exactly 6 routes to the bottom right corner.
    
    How many such routes are there through a 20×20 grid?";

    public Problem15() : base(Headline, Description) {
    }

    // NOTE: 20x20 Grid has 21x21 Nodes
    private const    int     Height      = 21;
    private const    int     Width       = 21;
    private const    int     Nodes       = Height * Width;
    private const    int     StartNodeId = 0;
    private const    int     GoalNodeId  = 440;
    private readonly bool[,] AdjMatrix   = CreateAdjMatrix();

    public override string Main() {
        return CountPaths().ToString();
    }

    private static bool[,] CreateAdjMatrix() {
        bool[,] adjMatrix = new bool[Nodes, Nodes];
        for (int i = 0; i < Nodes; i++) {
            if (i % 20 != 0) {
                adjMatrix[i, i + 1] = true;
            }

            if (i < 420) {
                adjMatrix[i, i + Width] = true;
            }
        }

        return adjMatrix;
    }

    private List<int> GetNeighbors(int nodeId) {
        List<int> neighbors = new List<int>();
        for (int node = 0; node < Nodes; node++) {
            if (AdjMatrix[nodeId, node]) {
                neighbors.Add(node);
            }
        }

        return neighbors;
    }


    private int CountPaths() {
        int        paths    = 0;
        Stack<int> dfsStack = new Stack<int>();
        dfsStack.Push(StartNodeId);

        while (dfsStack.Any()) {
            var currentNodeId = dfsStack.Pop();

            if (currentNodeId == GoalNodeId) {
                paths++;
            } else {
                List<int> neighbors = GetNeighbors(currentNodeId);
                foreach (var neighbor in neighbors) {
                    dfsStack.Push(neighbor);
                }
            }
        }

        return paths;
    }
}