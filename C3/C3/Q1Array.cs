using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C3
{
    public class Q1Array : Processor
    {
        public Q1Array(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) => TestTools.Process(inStr, (Func<long, long[], long>)Solve);
        public static long Solve(long n, long[] a)
        {
            // return NaiveSolve(n,a);
            return DaC_Sovle( n, a);
        }

        private static long DaC_Sovle(long n, long[] a)// T(n) = 2T(n/2) + n --> O(n.logn)
        {
            if( n <= 1)
                return a[0];
            
            int m = (int)n/2;
            long[] firstHalf = a[0..m];
            long[] secondHalf = a[m..((int)n)];
            long ans1 = DaC_Sovle(m,firstHalf);
            long ans2 = DaC_Sovle(n-m,secondHalf);
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

        public static long NaiveSolve(long n,long[] a)
        {
            long maxSum = 0,temp = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    temp += a[j];
                    if(temp > maxSum)
                        maxSum = temp;
                }
                if(temp > maxSum)
                    maxSum = temp;
                temp = 0;
            }
            return maxSum;
        }
    }
}
