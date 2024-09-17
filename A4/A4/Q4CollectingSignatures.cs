using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);

        private static long[] optimalPoints(Segment[] segments) {
        List<long> points = new List<long>();
        long pointer;
        while (segments.Length > 0)
        {
            pointer = segments.First().end;
            points.Add(pointer);
            segments = segments.Where(s => s.start > pointer).ToArray();
            // segments = segments.Where(s => (s.start > pointer) || (s.end < pointer)).ToArray();
        }
        return points.ToArray();
    }

    public class Segment {
        public long start, end;

        public Segment(long start, long end) {
            this.start = start;
            this.end = end;
        }
    }

        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            Segment[] segments = new Segment[tenantCount];
            for (int i = 0; i < tenantCount; i++) {
                long start, end;
                start = startTimes[i];
                end = endTimes[i];
                segments[i] = new Segment(start, end);
            }
            segments = segments.OrderBy(s => s.end).ToArray();
            long[] points = optimalPoints(segments);
            return points.Length;
        }
    }
}
