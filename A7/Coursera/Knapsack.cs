using System;
using System.Linq;

public class Knapsack {
    static int optimalWeight(int Weight, int[] options) {
        int[,] value = new int[Weight + 1 ,  options.Length + 1];
        for (int i = 0; i <= Weight; i++)
            value[i,0] = 0;
        for (int i = 0; i < options.Length; i++) // <=
            value[0,i] = 0;
        
        for (int i = 1; i <= options.Length; i++)
        {
            for (int w = 1; w <= Weight; w++)
            {
                value[w,i] = value[w,i-1];
                if (options[i-1] <= w)
                {
                    int val = value[w - options[i-1],i-1] + options[i-1]; // all are gold --> value per unit all : 1 --> value(options[i]) == weight(options[i])
                    if (value[w,i] < val)
                    {
                        value[w,i] = val;
                    }
                }
            }
        }
        return value[Weight,options.Length];

        // backtrack
        // long[] optimalSolution = new long[options.Length+1];
        // long wBackTrack = Weight;
        // for (long i = options.Length; i > 0; i--)
        // {
        //     if(wBackTrack - options[i-1] >= 0)
        //         if (value[wBackTrack - options[i-1],i-1] + options[i-1] > value[wBackTrack,i-1])
        //         {
        //             optimalSolution[i] = 1;
        //             wBackTrack -= options[i-1]; // - weight(options[i-1])
        //         }
        //     else
        //     {
        //         optimalSolution[i] = 0;
        //     }
        // }
    }

    public static void Main(string[] args) {
        int W, n;
        int[] tokens = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        W = tokens[0];
        n = tokens[1];

        int[] w = new int[n];
        tokens = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        for (int i = 0; i < n; i++) 
            w[i] = tokens[i];
        
        Console.WriteLine(optimalWeight(W, w));
    }
}