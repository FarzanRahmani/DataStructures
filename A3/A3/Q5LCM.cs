using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        private static long gcd(long a, long b) {
            if ( b == 0)
                return a;
            return gcd(b,a % b);
        }
        private static long lcm(long a, long b) {
            long ans = (long) a * b;
            return ans / gcd(a,b);
        }

        public long Solve(long a, long b)
        {
            return lcm(a,b);
        }

    }
}
