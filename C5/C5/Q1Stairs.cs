using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C5
{
    public class Q1Stairs : Processor
    {
        public Q1Stairs(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long m = first[1];
            long[] p = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, m, p).ToString();
        }

        public long Solve(long n, long m, long[] p)
        {
            long module = (long)Math.Pow(10,9) + 7 ;
            long[] DP = new long[n+1];
            for (int i = 0; i < m; i++)
                if(p[i] + 1 <= n)
                    DP[p[i]+1] = 1;
            
            DP[0] = 0;
            DP[1] = 0;
            for (int i = 2; i <= n; i++)
                for (int j = 0; j < m; j++)
                    if (p[j] <= i)
                        DP[i] += DP[i - p[j]] % module;
            
            return DP[n] % module;
        }
    }
}
