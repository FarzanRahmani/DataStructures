using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree: Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        private static long lcs3(long[] a, long[] b,long[] c) {
        long[,,] dpArr = new long[a.Length+1,b.Length+1,c.Length+1];

        for (long i = 0; i < a.Length; i++)
            dpArr[i,0,0] = 0;
        for (long i = 0; i < b.Length; i++)
            dpArr[0,i,0] = 0;
        for (long i = 0; i < c.Length; i++)
            dpArr[0,0,i] = 0;
        
        for (long i = 1; i <= a.Length; i++)
            for (long j = 1; j <= b.Length; j++)
                for (long k = 1; k <= c.Length; k++)
                    if ( (a[i-1] == b[j-1]) && (b[j-1] == c[k-1]))
                        dpArr[i,j,k] = 1 + dpArr[i-1,j-1,k-1];
                    else
                        dpArr[i,j,k] = Math.Max(Math.Max(dpArr[i-1,j,k],dpArr[i,j-1,k]),dpArr[i,j,k-1]);
        
        return dpArr[a.Length,b.Length,c.Length];
    }
    
        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            return lcs3(seq1,seq2,seq3);
        }
    }
}
