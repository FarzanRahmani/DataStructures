using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery:Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        {}
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        static int[] fastCountSegments(int[] starts, int[] ends, int[] points)
        {
            int NumberOfPoints = points.Length;
            int NumberOfSegments = starts.Length;

            List<int[]> pts = new List<int[]>(NumberOfPoints);
            List<int[]> seg = new List<int[]>(NumberOfSegments);
            
            for(int i = 0; i < NumberOfPoints; i++)
                pts.Add(new int[]{points[i], i});
            
            for(int i = 0; i < NumberOfSegments; i++)
            {
                seg.Add(new int[]{starts[i], 1});
                
                seg.Add(new int[]{ends[i] + 1, -1});
            }
            
            seg.Sort( (a,b) => b[0] - a[0]);

            pts.Sort( (a,b) => a[0] - b[0]);
            
            int count = 0;
            int[] ans = new int[NumberOfPoints];
            
            for(int i = 0; i < NumberOfPoints; i++)
            {
                int x = pts[i][0];
                
                while (seg.Count() != 0 &&
                        seg[seg.Count - 1][0] <= x)
                {
                    count += seg[seg.Count - 1][1];
                    seg.RemoveAt(seg.Count - 1);
                }
                ans[pts[i][1]] = count;
            }
            
            return ans;
        }


        public virtual long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {
            return fastCountSegments(startSegments.Select(l => (int)l).ToArray(),endSegment.Select(l => (int)l).ToArray(),points.Select(l => (int)l).ToArray()).Select(i => (long)i).ToArray();
        }
    }
}
