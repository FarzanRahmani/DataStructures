using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Priority_Queue;
using TestCommon;

namespace C9
{
    public class Q2Snakes : Processor
    {
        public Q2Snakes(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ2Snakes(inStr, Solve);


        public long Solve(long n, long[][] ladders, long m, long[][] snakes)
        {
            long[] dpArray = new long[101];
            dpArray[1] = 0;

            Dictionary<long, long> laddersFirst = new Dictionary<long, long>((int)n);
            for (int i = 0; i < n; i++)
                laddersFirst[ladders[i][0]] = ladders[i][1];

            Dictionary<long, long> snakesLast = new Dictionary<long, long>((int)m);
            for (int i = 0; i < m; i++)
                snakesLast[snakes[i][0]] = snakes[i][1];

            for (int i = 2; i < 101; i++)
                dpArray[i] = 1000;

            for (int i = 2; i <= 100; i++)
            {
                dpArray[i] = Math.Min(dpArray[i], dpArray[i - 1] + 1);
                if (i > 2)
                    dpArray[i] = Math.Min(dpArray[i], dpArray[i - 2] + 1);
                if (i > 3)
                    dpArray[i] = Math.Min(dpArray[i], dpArray[i - 3] + 1);
                if (i > 4)
                    dpArray[i] = Math.Min(dpArray[i], dpArray[i - 4] + 1);
                if (i > 5)
                    dpArray[i] = Math.Min(dpArray[i], dpArray[i - 5] + 1);
                if (i > 6)
                    dpArray[i] = Math.Min(dpArray[i], dpArray[i - 6] + 1);

                if (snakesLast.ContainsKey(i))
                {
                    // dpArray[snakesLast[i]] = Math.Min(dpArray[snakesLast[i]], dpArray[i]);
                    if (dpArray[snakesLast[i]] > dpArray[i])
                    {
                        dpArray[snakesLast[i]] = dpArray[i];
                        i = (int)snakesLast[i] + 1;
                    }
                    dpArray[i] = 1000;// inja vainemiste
                }

                if (laddersFirst.ContainsKey(i))
                {
                    dpArray[laddersFirst[i]] = dpArray[i];
                    dpArray[i] = 1000;// inja vainemiste
                }
            }
            
            if (dpArray[100] >= 1000)
                return -1;
            else
                return dpArray[100];
        }
    }
}
