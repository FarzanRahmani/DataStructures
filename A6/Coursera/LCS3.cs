using System;
using System.Collections.Generic;
using System.Linq;
public class LCS3 {

    private static int lcs3(int[] a, int[] b,int[] c) {
        int[,,] dpArr = new int[a.Length+1,b.Length+1,c.Length+1];

        for (int i = 0; i < a.Length; i++)
            dpArr[i,0,0] = 0;
        for (int i = 0; i < b.Length; i++)
            dpArr[0,i,0] = 0;
        for (int i = 0; i < c.Length; i++)
            dpArr[0,0,i] = 0;
        
        for (int i = 1; i <= a.Length; i++)
            for (int j = 1; j <= b.Length; j++)
                for (int k = 1; k <= c.Length; k++)
                    if ( (a[i-1] == b[j-1]) && (b[j-1] == c[k-1]))
                        dpArr[i,j,k] = 1 + dpArr[i-1,j-1,k-1];
                    else
                        dpArr[i,j,k] = Math.Max(Math.Max(dpArr[i-1,j,k],dpArr[i,j-1,k]),dpArr[i,j,k-1]);
        
        return dpArr[a.Length,b.Length,c.Length];
    }

    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        int[] a = new int[n];
        int[] tokens = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        for (int i = 0; i < n; i++) {
            a[i] = tokens[i];
        }

        int m = int.Parse(Console.ReadLine());
        int[] b = new int[m];
        tokens = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        for (int i = 0; i < m; i++) {
            b[i] = tokens[i];
        }

        int l = int.Parse(Console.ReadLine());
        int[] c = new int[l];
        tokens = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        for (int i = 0; i < l; i++) {
            c[i] = tokens[i];
        }

        Console.WriteLine(lcs3(a, b, c));
    }
}

