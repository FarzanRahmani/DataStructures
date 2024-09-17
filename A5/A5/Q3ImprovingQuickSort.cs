using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        private static long[] partition3(long[] a, long l, long r) 
        {   // not unique
            //write your code here
            // long k = random.Next(r - l + 1);
            // // swap
            // long t = a[r];
            // a[r] = a[k];
            // a[k] = t;
            
            long pivot = a[r];
            long i = l,j = l,p = r,t;
            while (i < p)
            {
                if (a[i] < pivot)
                {
                    t = a[i];
                    a[i] = a[j];
                    a[j] = t;
                    i++;j++;
                }
                else if (a[i] == pivot)
                {
                    p--;
                    t = a[i];
                    a[i] = a[p];
                    a[p] = t;
                }
                else
                    i++;
            }
            long m = Math.Min(p-j,r-p+1);
            for (long z = 0; z < m; z++)
            {
                t = a[j+z];
                a[j+z] = a[r-m+1+z];
                a[r-m+1+z] = t;
            }
            long pivot1 = j;// 

            long pivot2 = r-p+j;// r-(p-j)

            return new long[2] { pivot1, pivot2 };
        }


        private static void randomizedQuickSort(long[] a, long l, long r) {
            if (l >= r) {
                return;
            }
            // long k = random.Next(r - l + 1);
            // // swap
            // long t = a[r];
            // a[r] = a[k];
            // a[k] = t;
            //use partition3
            // long[] m = partition3(a, l, r);
            // randomizedQuickSort(a, l, m[0] - 1);
            // randomizedQuickSort(a, m[1] + 1, r);
            while (l<r)
            {
                long[] m = partition3(a, l, r);
                if (m[0]-l < r-m[1])
                {
                    randomizedQuickSort(a,l, m[0] -1 ); // m[0] - 1
                    l = m[1] + 1;
                }
                else
                {
                    randomizedQuickSort(a, m[1] + 1 , r); // m[1] + 1
                    r = m[0] - 1;
                }
            }
        }

        public virtual long[] Solve(long n, long[] a)
        {
            randomizedQuickSort(a,0,n-1);
            return a;
        }
    }
}
