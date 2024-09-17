using System;
using System.Collections.Generic;
public class PrimitiveCalculator {
    private static List<int> optimal_sequence(int n) {
        // naive (greedy)
        // while (n >= 1) {
        // sequence.Add(n);
        // if (n % 3 == 0) {
        //     n /= 3;
        // } else if (n % 2 == 0) {
        //     n /= 2;
        // } else {
        //     n -= 1;
        // }
        // }

        List<int> sequence = new List<int>();
        int[] minNumOps = new int[n+1];
        minNumOps[0] = 0;
        minNumOps[1] = 0;
        for (int i = 2; i <= n; i++)
        {
            minNumOps[i] = minNumOps[i-1] + 1; // +1

            if (i % 2 == 0) // /2
                if (minNumOps[i / 2] + 1  < minNumOps[i])
                    minNumOps[i] = minNumOps[i / 2] + 1;

            if (i % 3 == 0) // /3
                if (minNumOps[i / 3] + 1  < minNumOps[i])
                    minNumOps[i] = minNumOps[i / 3] + 1;
        }

        sequence.Add(n);
        while (n > 1)
        {
            int Op1 = 1000000,Op3 = 1000000,Op2 = 1000000;
            Op1 = minNumOps[n-1];
            if ( n%2 == 0)
                Op2 = minNumOps[n / 2];
            if ( n%3 == 0)
                Op3 = minNumOps[n / 3];
            
            if (Op1 < Op2)
                if (Op1 < Op3)
                    {
                        sequence.Add(n-1);
                        n--;
                    }
                else
                    {
                        sequence.Add(n / 3);
                        n /= 3;
                    }
            else
                if (Op2 > Op3)
                {
                    sequence.Add(n / 3);
                    n /= 3;
                }
                else
                {
                    sequence.Add(n / 2);
                    n /= 2;
                }
        }
        sequence.Reverse();
        return sequence;
    }

    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        List<int> sequence = optimal_sequence(n);
        Console.WriteLine(sequence.Count - 1);
        foreach (int x in sequence)
        {
            Console.Write(x + " ");
        }
        Console.ReadKey();
    }

}