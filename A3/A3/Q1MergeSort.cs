using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Merge(long[] b,long[] c)
        {
            long size = b.Length + c.Length;
            long[] d = new long[size];
            long b_i = 0,c_i = 0;
            for (int i = 0; i < size; i++)
            {
                if (b_i == b.Length)
                {
                    for (long j = c_i; j < c.Length; j++)
                    {
                        d[i] = c[j];i++;
                    }
                    break;
                }

                if (c_i == c.Length)
                {
                    for (long j = b_i; j < b.Length; j++)
                    {
                        d[i] = b[j];i++;
                    }
                    break;
                }

                long tempB = b[b_i];
                long tempC = c[c_i];
                if ( tempB < tempC)
                {
                    d[i] = tempB;
                    b_i++;
                }
                else
                {
                    d[i] = tempC;
                    c_i++;
                }
            }
            return d;
        }

        public long[] MergeSort(long[] a,int n)
        {
            if (n == 1)
                return a;
            int m = n / 2;
            long[] b = MergeSort(a[0..m],m);
            long[] c = MergeSort(a[m..n],n-m);// n-m
            long[] ans = Merge(b,c);
            return ans;
        }

        public long[] Solve(long n, long[] a)
        {
            // Array.Sort(a);
            return MergeSort(a,Convert.ToInt32(n));
        }
    }
}
