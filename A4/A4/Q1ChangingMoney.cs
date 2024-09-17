using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        private static long getChange(long m) {
        long ans = 0;
        ans += (long)m /10;m = m % 10;
        ans += (long)m /5;m = m % 5;
        ans += m;
        return ans;
        // while (m >= 10)
        // {
        //     m -= 10;
        //     ans++;
        // }
        // while (m >= 5)
        // {
        //     m -= 5;
        //     ans++;
        // }
        // ans += m;
    }

        public virtual long Solve(long money)
        {
            return getChange(money);
        }
    }
}
