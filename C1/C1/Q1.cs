using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace C1
{
    public class Q1 : Processor
    {
        public Q1(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long x = first[1];
            long [] a = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, a, x).ToString();
        }

        public long Solve(long n, long[] a, long x)
        {
            // long sum = 0,cnt =0;
            // long[] smaller = a.Where(n => n<x).Select(n => n-x).OrderBy(n => n).ToArray();
            // long[] smallerComulativeSum = new long[smaller.Length];
            // long[] bigger = a.Where(n => n>x).Select(n => n-x).OrderBy(n => n).ToArray();
            // long[] biggerComulativeSum = new long[bigger.Length];
            // for (int i = 0; i < smaller.Length; i++)
            // {
            //     sum += smaller[i];
            //     smallerComulativeSum[i] = sum;
            // }
            // for (int i = 0; i < bigger.Length; i++)
            // {
            //     sum += bigger[i];
            //     biggerComulativeSum[i] = sum;
            // }
            // // for (int i = biggerComulativeSum.Length-1; i >= 0; i--)
            // // {
            // //     small
            // // }
            long sum = 0;
            long ans = 0;
            a.OrderByDescending(n => n);
            for (int i = 0; i < n; i++)
            {
                sum += a[i];
                if (sum >= x*(i+1))
                    ans = i + 1;
            }

            return ans;
            /// 
            // Array.Sort(a);
            // long total = a.Sum();
            // for (int i = 0; i < n; i++)
            // {
            //     if (total >= m * (n-i))
            //     {
            //         return n-i;
            //     }
            //     total -= a[i];
            // }
            // return 0;
        }
    }
}
