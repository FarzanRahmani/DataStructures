using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        private static long getChange(long money,int[] coins) {
            long[] MinNumCoins = new long[money+1];
            MinNumCoins[0] = 0;
            long NumCoins = 0;
            for (int m = 1; m <= money; m++)
            {
                MinNumCoins[m] = long.MaxValue;
                for (int i = 0; i < coins.Length; i++)
                {
                    if (m >= coins[i])
                    {
                        NumCoins = MinNumCoins[m - coins[i]] + 1;
                        if (NumCoins < MinNumCoins[m])
                            MinNumCoins[m] = NumCoins;
                    }
                }
            }
            return MinNumCoins[money];
        }

        public long Solve(long n)
        {
            return getChange(n,COINS);
        }
    }
}
