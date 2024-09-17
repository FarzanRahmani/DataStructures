using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q3Connectivity : Processor
    {
        public Q3Connectivity(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long a = first[1];
            long b = first[2];
            long [] p = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, a, b, p).ToString();
        }

        public long Solve(long n, long a, long b, long[] p)
        {
            Array.Sort(p);
            long min_anthen;// = Math.Min(a,b);
            long max_anthen;// = Math.Max(a,b);
            if (a > b)
            {
                max_anthen = a;
                min_anthen = b;
            }
            else
            {
                max_anthen = b;
                min_anthen = a;
            }
            long[] anthens = new long[n];
            long distanceAfter = 0,distanceBefore =0,maxDistance = 0 , i = 0;

            if (n == 1)
                return min_anthen;

            distanceAfter = Math.Abs(p[i+1] - p[i]);
            if (distanceAfter<=min_anthen)
                anthens[i] = min_anthen;
            else if (distanceAfter<=max_anthen)
                anthens[i] = max_anthen;
            else
                return -1;
            i++;
            
            for (; i < n-1; i++)
            {
                distanceAfter = Math.Abs(p[i+1] - p[i]);
                distanceBefore = Math.Abs(p[i] - p[i-1]);
                maxDistance = Math.Max(distanceAfter,distanceBefore);
                if (maxDistance<=min_anthen)
                    anthens[i] = min_anthen;
                else if (maxDistance<=max_anthen)
                    anthens[i] = max_anthen;
                else
                    return -1;
            }

            distanceBefore = Math.Abs(p[i] - p[i-1]);
            if (distanceBefore<=min_anthen)
                anthens[i] = min_anthen;
            else if (distanceBefore<=max_anthen)
                anthens[i] = max_anthen;
            else
                return -1;
            
            return anthens.Sum();
        }
    }
}
