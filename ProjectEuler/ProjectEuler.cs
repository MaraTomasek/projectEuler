using System.Collections.Specialized;

namespace ConsoleApp1;

class ProjectEuler {
    public int Main(int projectNumber) {
        int[] completedProblems = new int[] {1, 2};

        if (completedProblems.Contains(projectNumber)) {
            Console.Write("Solution to Problem {0}: {1}", projectNumber, runProblem(projectNumber));
        }

        return 0;
    }

    private int runProblem(int projectNumber) {
        Problem p = new Problem();

        switch (projectNumber) {
            case 1:
                p = new Problem1();
                break;
            case 2:
                p = new Problem2();
                break;
        }

        return p.Main();
    }
}