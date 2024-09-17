using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q3MaximizingOnlineAdRevenue : Processor
    {
        public Q3MaximizingOnlineAdRevenue(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);

        private static long maxDotProduct(long[] a, long[] b) {
        a = a.OrderBy(n => n).ToArray();
        b = b.OrderBy(n => n).ToArray();
        long result = 0;
        for (long i = 0; i < a.Length; i++) 
            result += a[i] * b[i];
        return result;
    }

        public virtual long Solve(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            return maxDotProduct(adRevenue,averageDailyClick);
        }
    }
}
