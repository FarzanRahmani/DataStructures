using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q2MajorityElement:Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        private static long getMajorityElement(long[] a, long left, long right) {
            // Array.Sort(a);
            // long temp = a[0],cnt = 1;
            // long majority = (a.Length / 2) + 1;
            // for (long i = 1; i < a.Length; i++)
            // {
            //     if (cnt >= majority)
            //         return 1;
                
            //     if (a[i] == temp)
            //         cnt++;
            //     else
            //     {
            //         temp = a[i];
            //         cnt = 0;
            //     }
            // }
            // if (cnt >= majority)
            // {
            //     return 1;
            // }
            // return 0;

            // ----------------
            long n = a.Length;
            Dictionary<long,long> records = new Dictionary<long, long>((int)n);
            for (long i = 0; i < n; i++)
                records[a[i]] = 0;

            for (long i = 0; i < n; i++)
                records[a[i]]++;
            
            long max_cnt = records.Values.Max(); 
            long majority = (a.Length / 2) + 1;
            if ( max_cnt >= majority)
                return 1;
            else
                return 0;

            // ----------------
            // recursive
            // if (left == right) {
            //     return a[left];
            // }

            // long mid = (right - left)/2 + left;
            
            // long leftDiv = getMajorityElement(a,left,mid);
            // long rightDiv = getMajorityElement(a,mid+1,right);
            // if (leftDiv == rightDiv)
            //     return leftDiv;

            // long leftNum = count(a,left,right,leftDiv);
            // long rightNum = count(a,left,right,rightDiv);
            // long result = Math.Max(leftNum,rightNum);

            // long majority = (a.Length / 2) + 1;
            // if (result >= majority)
            //     return 1;
            // else
            //     return -1;
        }

        // private static long count(long[] a, long left, long right, long key)
        // {
        //     long cnt = 0;
        //     for(long i = left;i <= right; i++)
        //         if (a[i] == key)
        //             cnt++;
        //     return cnt;
        // }

        public virtual long Solve(long n, long[] a)
        {
            return getMajorityElement(a,0,n-1);
        }
    }
}
