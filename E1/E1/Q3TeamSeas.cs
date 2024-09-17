using System;
using TestCommon;

namespace E1
{
    public class Q3TeamSeas : Processor
    {
        public Q3TeamSeas(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E1Processors.ProcessQ3TeamSeas(inStr, Solve);

        public long Solve(long n, long m, long[] g, long[] c, long[] b, long[] p, long[] s)
        {
            long[,] value = new long[n + 1 ,  m + 1];
            for (int i = 0; i <= n; i++)
                value[i,0] = 0;
            for (int i = 0; i < m; i++) 
                value[0,i] = 0;
            
            for (int i = 1; i <= n; i++)
            {
                for (int w = 1; w <= m; w++)
                {
                    value[w,i] = value[w,i-1];
                    if (c[i-1] <= w)
                    {
                        value[w,i] = value[w - c[i-1],i-1] + b[i-1];
                    }
                    long availablePerson = w / s[i-1];
                    long val = availablePerson + value[w - availablePerson,i-1]; 
                    if (val > value[w,i])
                    {
                        value[w,i] = val;
                    }
                }
            }

            return value[n,m];
        }
    }
}
