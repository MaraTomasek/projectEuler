namespace ConsoleApp1;

// TODO Parallelize Problems 14, 15
// TODO Find something better than switch to start solutions

static class Program {
    public static void Main(string[] args) {
        int       projectNumber     = Convert.ToInt32(args[0]);
        List<int> completedProblems = new List<int>();
        for (int i = 1; i <= 16; i++) {
            completedProblems.Add(i);
        }

        if (completedProblems.Contains(projectNumber)) {
            Console.WriteLine("Solution to Problem {0}: {1}", projectNumber, RunProblem(projectNumber));
        }
        else {
            Console.WriteLine("No solution programmed for exercise {0}.", projectNumber);
            Console.WriteLine("Solutions currently exist for:");
            foreach (var problem in completedProblems) {
                Console.Write("{0}, ", problem);
            }
        }
    }

    private static string RunProblem(int projectNumber) {
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
            case 13:
                p = new Problem13();
                break;
            case 14:
                p = new Problem14();
                break;
            case 15:
                p = new Problem15();
                break;
            case 16:
                p = new Problem16();
                break;
        }

        return p!.Main();
    }
}