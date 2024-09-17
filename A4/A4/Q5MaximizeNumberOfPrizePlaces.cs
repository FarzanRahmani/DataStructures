using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        private static List<long> optimalSummands(long n) {
            List<long> summands = new List<long>();
            long x = 1;
            while (n >= x)
            {
                summands.Add(x);
                n -= x;
                x++;
            }
            int lastIndex = summands.Count -1;
            summands[lastIndex] += n;
            return summands;
        }

        public virtual long[] Solve(long n)
        {
            return optimalSummands(n).ToArray();
        }
    }
}

