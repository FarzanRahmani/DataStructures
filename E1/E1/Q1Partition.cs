using System;
using TestCommon;

namespace E1
{
    public class Q1Partition : Processor
    {
        public Q1Partition(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E1Processors.ProcessQ1Partition(inStr, Solve);

        public long Solve(long n, long x, long[] p)
        {
            Array.Sort(p);
            long ans = 0;
            for (int i = 0; i < n;)
            {
                long flag = p[i] + x;
                while (p[i] <= flag)
                {   
                    i++;
                    if (i == n)
                        break;
                }
                ans++;
            }
            return ans;
        }
    }
}
