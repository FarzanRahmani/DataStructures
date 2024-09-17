using System;
using System.Collections.Generic;
using System.Linq;
    public class LCS2 {

    private static int OutputAlighnment(int i,int j,int[,] D)
    {
        if (i == 0 & j == 0)
            return 0;
        if (i > 0)
            if (D[i,j] == D[i-1,j] + 1)
                return OutputAlighnment(i-1,j,D);
        else if (j > 0)
            if (D[i,j] == D[i,j-1] + 1)
                return OutputAlighnment(i,j-1,D);
        else
        {
            // if(D[i,j] == D[i-1,j-1])
                return OutputAlighnment(i-1,j-1,D) + 1;
            // else
            //     return OutputAlighnment(i-1,j-1,D);
        }
        return 0;
    }

    private static int lcs2(int[] a, int[] b) {
        int[,] Distance = new int[a.Length+1,(b.Length +1)];
        for(int i = 0;i <= a.Length;i++)
            Distance[i,0] = i;
        for(int j = 0;j <= b.Length;j++)
            Distance[0,j] = j;
        
        int insertion = 0, deletion = 0, match = 0;//, mismatch = 0;
        for (int j = 1; j <= b.Length; j++)
        {
            for (int i = 1; i <= a.Length; i++)
            {
                insertion = Distance[i,j-1] + 1;
                deletion = Distance[i-1,j] + 1;
                match = Distance[i-1,j-1];
                // mismatch = Distance[i-1,j-1] + 1;
                if (a[i-1] == b[j-1])
                    Distance[i,j] = Math.Min(Math.Min(insertion,deletion),match);
                else
                    Distance[i,j] = Math.Min(insertion,deletion);
                    // Distance[i,j] = Math.Min(Math.Min(insertion,deletion),mismatch);
            }
        }
        // return Distance[a.Length,b.Length]; // matches
        return OutputAlighnment(a.Length,b.Length,Distance);
        }

    // private static int _lcs2(List<int> a, List<int> b) {
    //         int ans = 0;
    //         foreach (int i1 in a)
    //         {
    //             for (int i = 0; i < b.Count; i++)
    //             {
    //                 if(i1 == b[i])
    //                 {
    //                     ans++;
    //                     b = b.Skip(i+1).ToList();
    //                     break;
    //                 }
    //             }
    //         }
    //         return ans;
    //     }

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

            Console.WriteLine(lcs2(a, b));
            Console.ReadKey();
    }
}
