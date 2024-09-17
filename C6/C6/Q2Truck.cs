using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C6
{
    public class Q2Truck : Processor
    {
        public Q2Truck(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C6Processors.ProcessQ2Truck(inStr, Solve);
        

        public long Solve(long n ,long[] petr ,long[] dist)
        {
            // if (dist.Sum() < petr.Sum())
            //     return -1;
            long ans = 0;
            long sumPetr = 0;
            for (int i = 0; i < n; i++)
            {
                sumPetr += petr[i] - dist[i];
                if(sumPetr < 0)
                {
                    ans = i+1;
                    sumPetr = 0;
                }
            }
            return ans;
        }
    }
}
