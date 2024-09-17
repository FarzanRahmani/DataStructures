using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        private static long OutputAlighnment(long i,long j,long[,] D)
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

        private static long lcs2(long[] a, long[] b) {
            long[,] Distance = new long[a.Length+1,(b.Length +1)];
            for(long i = 0;i <= a.Length;i++)
                Distance[i,0] = i;
            for(long j = 0;j <= b.Length;j++)
                Distance[0,j] = j;
            
            long insertion = 0, deletion = 0, match = 0;//, mismatch = 0;
            for (long j = 1; j <= b.Length; j++)
            {
                for (long i = 1; i <= a.Length; i++)
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

        public long Solve(long[] seq1, long[] seq2)
        {
            return lcs2(seq1,seq2);
        }
    }
}
