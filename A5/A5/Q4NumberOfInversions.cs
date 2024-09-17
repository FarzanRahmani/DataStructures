using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;


namespace A5
{
    public class Q4NumberOfInversions:Processor
    {

        public Q4NumberOfInversions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public class InvAndArray
        {
            public long num;
            public long[] array;

            public InvAndArray(long num, long[] array)
            {
                this.num = num;
                this.array = array;
            }
        }
        public static InvAndArray Merge(long[] b,long[] c)
        {
            long bLength = b.Length;
            long cLength = c.Length;
            long size = bLength + cLength;
            long[] d = new long[size];
            long b_i = 0,c_i = 0;
            long ans = 0;

            for (long i = 0; i < size; i++)
            {
                if (b_i == bLength)
                {
                    for (long j = c_i; j < cLength; j++)
                    {
                        d[i] = c[j];i++;
                    }

                    break;
                }

                if (c_i == cLength)
                {
                    for (long j = b_i; j < bLength; j++)
                    {
                        d[i] = b[j];i++;
                    }

                    break;
                }

                long tempB = b[b_i];
                long tempC = c[c_i];
                if ( tempB <= tempC)
                {
                    d[i] = tempB;
                    b_i++;
                }
                else // tempB > tempC
                {
                    ans += bLength - b_i;
                    d[i] = tempC;
                    c_i++;
                }
            }
            return new InvAndArray(ans,d);
        }

        // getNumberOfInversions MergeSort
        public static InvAndArray GetNumberOfInversions(long[] a,long n)
        {
            if (n == 1)
                return new InvAndArray(0,a);
            long m = n / 2;
            // InvAndArray b = GetNumberOfInversions(a[0..m],m);
            // InvAndArray c = GetNumberOfInversions(a[m..n],n-m);// n-m
            InvAndArray b = GetNumberOfInversions(a.Take((int)m).ToArray(),m);
            InvAndArray c = GetNumberOfInversions(a.Skip((int)m).ToArray(),n-m);// n-m
            InvAndArray ans = Merge(b.array,c.array);
            ans.num += b.num;
            ans.num += c.num;
            return ans;
        }

        // public static InvAndArray _GetNumberOfInversions(long[] a,long n,int left,int right)
        // {
        //     if (left >= right)
        //         return new InvAndArray(0,a[left..(right+1)]);
        //     long m = (right + left) / 2;
        //     // InvAndArray b = GetNumberOfInversions(a[0..m],m);
        //     // InvAndArray c = GetNumberOfInversions(a[m..n],n-m);// n-m
        //     InvAndArray b = _GetNumberOfInversions(a,m,left,(int)m);
        //     InvAndArray c = _GetNumberOfInversions(a,n-m,(int)(m+1),right);// n-m
        //     InvAndArray ans = Merge(b.array,c.array);
        //     ans.num += b.num;
        //     ans.num += c.num;
        //     return ans;
        // }

        public virtual long Solve(long n, long[] a)
        {
            // return GetNumberOfInversions(a.Select(l => (long)l).ToArray(),(long)n).num;
            // return _GetNumberOfInversions(a,n,0,(int)(n-1)).num;
            return GetNumberOfInversions(a,n).num;
        }
    }
}
