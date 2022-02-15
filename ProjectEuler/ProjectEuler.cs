namespace ConsoleApp1;

static class Program {
    public static void Main(string[] args) {
        Console.WriteLine("hi?");
        int   projectNumber     = 2;
        int[] completedProblems = new int[] {1, 2, 3};

        if (completedProblems.Contains(projectNumber)) {
            Console.WriteLine("Solution to Problem {0}: {1}", projectNumber, RunProblem(projectNumber));
        }
        else {
            Console.WriteLine("No solution programmed for this exercise.");
        }

        Console.Read();
    }

    private static int RunProblem(int projectNumber) {
        Problem p = null;

        switch (projectNumber) {
            case 1:
                p = new Problem1();
                break;
            case 2:
                p = new Problem2();
                break;
            case 3:
                p = new Problem3();
                break;
        }

        if (p != null) {
            return p.Main();
        }
        return 0;
    }
}
