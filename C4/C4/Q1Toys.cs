using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C4
{
    public class Q1Toys : Processor
    {
        public Q1Toys(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long a = first[0];
            long [] arr = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(a, arr).ToString();
        }
        public static long Solve(long a, long[] arr)
        {
            long[] dpGame = new long[a];
            dpGame[a-1] = arr[a-1];
            dpGame[a-2] = arr[a-2] + dpGame[a-1];
            dpGame[a-3] = arr[a-3] + dpGame[a-2];

            long[] sumFromLast = new long[a];sumFromLast[a-1] = arr[a-1];
            for (long i = a-2; i >= 0; i--)
                sumFromLast[i] += sumFromLast[i+1] + arr[i];
            
            for (long i = a-4; i >= 0; i--)
            {
                long case1 = arr[i] + (sumFromLast[i+1] - dpGame[i+1]);
                long case2 = arr[i] + arr[i+1] + (sumFromLast[i+2] - dpGame[i+2]);
                long case3 = arr[i] + arr[i+1] + arr[i+2] + (sumFromLast[i+3] - dpGame[i+3]);

                dpGame[i] = Math.Max(case1,Math.Max(case2,case3));
            }
            
            return dpGame[0];
        }

    }
}
