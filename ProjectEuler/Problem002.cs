namespace ConsoleApp1;

public class Problem2 : Problem {
    public override string Main() {
        /* Even Fibonacci numbers
            Each new term in the Fibonacci sequence is generated by adding the previous two terms. 
            By starting with 1 and 2, the first 10 terms will be:
            
            1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
            
            By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
            find the sum of the even-valued terms. */

        const int n        = 4000000;
        int       totalSum = 2; // Because first 2 doesn't get checked

        Queue<int> summands = new Queue<int>();
        summands.Enqueue(1);
        summands.Enqueue(2);
        int nextFibonacci = 3;

        while (nextFibonacci < n) {
            nextFibonacci = sumQueue(summands);
            summands.Enqueue(nextFibonacci);
            summands.Dequeue();

            if (nextFibonacci % 2 == 0) {
                totalSum += nextFibonacci;
            }
        }

        return totalSum.ToString();
    }

    public int sumQueue(Queue<int> queue) {
        int sum = 0;
        foreach (int number in queue) {
            sum += number;
        }

        return sum;
    }
}