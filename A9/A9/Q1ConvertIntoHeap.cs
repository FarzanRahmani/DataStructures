using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {
        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public class Swap {
        public long index1;
        public long index2;

        public Swap(long index1, long index2, long[] h) {
            this.index1 = index1;
            this.index2 = index2;
            long tmp = h[index1];
            h[index1] = h[index2];
            h[index2] = tmp;
        }

        public Tuple<long, long> AsTuple() =>   new Tuple<long, long>(index1,index2);

    }
        public static void SiftDown(long i , long size, long[] H, List<Swap> ans)
        {
            long minIndex = i;
            
            long l = 2*i + 1;// left child
            if ( l < size )
                if (H[l] < H[minIndex])
                    minIndex = l;
            
            long r = 2*i + 2;// right child
            if ( r < size )
                if (H[r] < H[minIndex])
                    minIndex = r;
            
            if (i != minIndex)
            {
                ans.Add(new Swap(i,minIndex,H));
                SiftDown(minIndex,size,H,ans);
            }
        }

        private static List<Swap> BuildHeapF(long[] data, long n)
        {
            List<Swap> ans = new List<Swap>(4*(int)n);
            for (long i = (n/2) - 1; i >= 0; i--)
                SiftDown(i,n,data,ans);
            
            return ans;
        }
        
        public Tuple<long, long>[] Solve(long[] array)
        {
            List<Swap> swaps = BuildHeapF(array,array.Length);
            return swaps.Select(s => s.AsTuple()).ToArray();
        }
    }
}
