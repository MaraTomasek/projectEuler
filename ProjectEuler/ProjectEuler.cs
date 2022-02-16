namespace ConsoleApp1;

static class Program {
    public static void Main(string[] args) {
        int       projectNumber     = Convert.ToInt32(args[0]);
        List<int> completedProblems = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

        if (completedProblems.Contains(projectNumber)) {
            Console.WriteLine("Solution to Problem {0}: {1}", projectNumber, RunProblem(projectNumber));
        }
        else {
            Console.WriteLine("No solution programmed for this exercise.");
            Console.WriteLine("Solutions currently exist for:");
            foreach (var problem in completedProblems) {
                Console.Write("{0}, ", problem);
                Console.WriteLine("");
            }
        }

        Console.Read();
    }

    private static int RunProblem(int projectNumber) {
        Problem? p = null;

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
            case 4:
                p = new Problem4();
                break;
            case 5:
                p = new Problem5();
                break;
            case 6:
                p = new Problem6();
                break;
            case 7:
                p = new Problem7();
                break;
            case 8:
                p = new Problem8();
                break;
            case 9:
                p = new Problem9();
                break;
            case 10:
                p = new Problem10();
                break;
            case 11:
                p = new Problem11();
                break;
            case 12:
                p = new Problem12();
                break;
        }

        return p!.Main();
    }
}