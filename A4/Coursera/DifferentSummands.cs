using System;
using System.Collections.Generic;
public class DifferentSummands {
    private static List<int> optimalSummands(int n) {
        List<int> summands = new List<int>();
        int x = 1;
        while (n >= x)
        {
            summands.Add(x);
            n -= x;
            x++;
        }
        int lastIndex = summands.Count -1;
        summands[lastIndex] += n;
        return summands;
    }
    
    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        List<int> summands = optimalSummands(n);
        System.Console.WriteLine(summands.Count);
        foreach (int s in summands)
        {
            System.Console.Write(s + " ");
        }
        Console.ReadKey();
    }
}