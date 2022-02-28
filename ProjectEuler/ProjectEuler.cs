namespace ConsoleApp1;

internal static class Program {
    public static void Main(string[] args) {
        var       projectId           = Convert.ToInt32(args[0]);
        var completedProblemIds = new List<int>();

        for (var i = 1; i <= 23; i++) {
            completedProblemIds.Add(i);
        }

        if (completedProblemIds.Contains(projectId)) {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            var solution = RunProblem(projectId);
            watch.Stop();

            Console.Write("Problem {0}: {1}{2}\n\n", projectId, solution[1], solution[2]);
            Console.WriteLine("Solution:\t{0}\nTime elapsed:\t{1}s\n\nExplanation:{2}", solution[0], watch.ElapsedMilliseconds/1000.0, solution[3]);
        } else {
            Console.WriteLine("No solution programmed for exercise {0}.", projectId);
            Console.WriteLine("Solutions currently exist for:");
            foreach (var problem in completedProblemIds) {
                Console.Write("{0}, ", problem);
            }
        }
    }

    private static string[] RunProblem(int projectNumber) {
        var problems = new Dictionary<int, Problem> {
            {1, new Problem1()},
            {2, new Problem2()},
            {3, new Problem3()},
            {4, new Problem4()},
            {5, new Problem5()},
            {6, new Problem6()},
            {7, new Problem7()},
            {8, new Problem8()},
            {9, new Problem9()},
            {10, new Problem10()},
            {11, new Problem11()},
            {12, new Problem12()},
            {13, new Problem13()},
            {14, new Problem14()},
            {15, new Problem15()},
            {16, new Problem16()},
            {17, new Problem17()},
            {18, new Problem18()},
            {19, new Problem19()},
            {20, new Problem20()},
            {21, new Problem21()},
            {22, new Problem22()},
            {23, new Problem23()}
        };

        var p = problems[projectNumber];
        return new[] {p.Main(), p.Headline, p.Description, p.Solution};
    }
}