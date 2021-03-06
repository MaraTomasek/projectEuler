namespace ConsoleApp1;

public class Problem2 : Problem {
    private static string Headline = @"Even Fibonacci numbers";

    private static string Description = @"
    Each new term in the Fibonacci sequence is generated by adding the previous two terms. 
    By starting with 1 and 2, the first 10 terms will be:
    
        1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
    
    By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
    find the sum of the even-valued terms.";

    private static string Solution = @"
    Generate new Fibonacci numbers until the 4.000.000 limit, check each for evenness and add to the sum if even.
    Generation uses a Queue, which let's us keep track of both terms easily
    by queueing new terms and dequeuing old ones";
    
    public Problem2() : base(Headline, Description, Solution) {
    }

    public override string Main() {
        const int n        = 4000000;
        int       totalSum = 2; // Because first 2 doesn't get checked

        Queue<int> addends = new Queue<int>();
        addends.Enqueue(1);
        addends.Enqueue(2);
        int nextFibonacci = 3;

        while (nextFibonacci < n) {
            nextFibonacci = sumQueue(addends);
            addends.Enqueue(nextFibonacci);
            addends.Dequeue();

            if (nextFibonacci % 2 == 0) {
                totalSum += nextFibonacci;
            }
        }

        return totalSum.ToString();
    }

    private int sumQueue(Queue<int> queue) {
        int sum = 0;
        foreach (int number in queue) {
            sum += number;
        }

        return sum;
    }
}