using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C4
{
    public class Q2Froggie : Processor
    {
        public Q2Froggie(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long[] dp1 = new long[n];
            long[] dp2 = new long[n];

            dp1[0] = numbers[0][0];
            dp2[0] = numbers[1][0];

            for (int i = 1; i < n; i++)
            {
                dp1[i] = Math.Max(numbers[0][i] + dp1[i-1] ,numbers[0][i] + dp2[i-1] - p);
                dp2[i] = Math.Max(numbers[1][i] + dp1[i-1] - p,numbers[1][i] + dp2[i-1]);
            }

            return Math.Max(dp1[n-1],dp2[n-1]);
        }
    }
}
