using System;
public class FibonacciPartialSum {
    public static long pisano(long m)
    {
        long prev = 0;
        long curr = 1;
        long res = 0;

        for (int i = 0; i < m * m; i++) {
            long temp = 0;
            temp = curr;
            curr = (prev + curr) % m;
            prev = temp;

            if (prev == 0 && curr == 1)
            {
                res = i + 1;
                break;
            }
        }
        return res;
    }

    private static long getFibonacciHuge(long n, long m) {

        long period = pisano(m);
        long same_as_n = n % period;

        if (same_as_n <= 1)
            return same_as_n;
        long previous = 0;
        long current  = 1;

        for (long i = 0; i < same_as_n - 1; ++i) {
            long tmp_previous = previous;
            previous = current;
            current = (tmp_previous + current) % m;
        }

        return current;
    }

    private static long getFibonacciSum(long n) {
        long ans = getFibonacciHuge(n+2,10) - 1;
        if (ans < 0)
            return ans + 10;
        else    
            return ans;
    }
    private static long getFibonacciPartialSum(long from, long to) {
        long ans = getFibonacciSum(to) - getFibonacciSum(from - 1);
        if (ans < 0)
            return ans + 10;
        else    
            return ans;
    }
    
    public static void Main(string[] args) {
        string[] tokens = System.Console.ReadLine().Split();
        long from = long.Parse(tokens[0]);
        long to = long.Parse(tokens[1]);
        System.Console.WriteLine(getFibonacciPartialSum(from, to));
    }
}

