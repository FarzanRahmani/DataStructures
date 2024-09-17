using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q7MaxSubarraySum : Processor
    {
        public Q7MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        private static long MaxSubarraySum(long n, long[] a)// T(n) = 2T(n/2) + n --> O(n.logn)
        {
            if( n <= 1)
                return a[0];
            
            int m = (int)n/2;
            long[] firstHalf = a[0..m];
            long[] secondHalf = a[m..((int)n)];
            long ans1 = MaxSubarraySum(m,firstHalf);
            long ans2 = MaxSubarraySum(n-m,secondHalf);
            long ans3 = Merge(firstHalf,secondHalf);
            return Math.Max(Math.Max(ans1,ans2),ans3);
        }

        private static long Merge(long[] firstHalf, long[] secondHalf) // n +(n-1) + ... + 2 + 1 = n(n+1)/2 --> O(n^2)
        {
            long maxFirstHalf = 0,temp =0;
            for (int i = firstHalf.Length-1; i >-1; i--)
            {
                temp += firstHalf[i];
                if (temp > maxFirstHalf)
                    maxFirstHalf = temp;
            }

            long maxSecondHalf = 0;
            temp = 0;
            for (int i = 0; i < secondHalf.Length; i++)
            {
                temp += secondHalf[i];
                if (temp > maxSecondHalf)
                    maxSecondHalf = temp;
            }

            return maxFirstHalf + maxSecondHalf;
        }

        public virtual long Solve(long n, long[] numbers)
        {
            return MaxSubarraySum(n,numbers);
        }
    }
}
