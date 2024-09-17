using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        static long binarySearch(long[] a, long low, long high, long x) 
        {
            // if (high < low) // bad az high == low (faghat 1 element dare mirese be inja)
            //     return - 1;
            // int mid = low + (high - low)/2;
            // if (x == a[mid])
            //     return mid;
            // else if (x < a[mid])
            //     return binarySearch(a,low,mid -1,x);
            // else
            //     return binarySearch(a,mid+1,high,x);

            while (high >= low)
            {
                long mid = low + (high - low)/2;
                if (x == a[mid])
                    return mid;
                else if (x < a[mid])
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            return -1;
        }

        public virtual long[] Solve(long[] a, long[] b) 
        {
            long[] ans = new long[b.Length];
            for (int i = 0; i < b.Length; i++) {
                ans[i] = binarySearch(a,0,a.Length-1, b[i]);
            }
            return ans;
        }
    }
}
