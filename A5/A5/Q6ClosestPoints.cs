using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], double>)Solve);

        class Point
        {
            public int x,y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        static double Distance(Point p1,Point p2) 
        {
            return Math.Sqrt( Math.Pow((p1.x - p2.x),2)+Math.Pow((p1.y - p2.y),2) );
        }

        static double check(Point[] points)
        {
            double ans = double.PositiveInfinity;
            points = points.OrderBy(p => p.y).ToArray();
            int len = points.Length;
            double dis = 0.0;
            for (int i = 0; i < len; i++)
                for (int j = i+1; j < i+8 && j < len; j++)
                {
                    dis = Distance(points[i],points[j] );
                    if(dis < ans)
                        ans = dis; 
                }
            
            return ans;
        }
        static double minimalDistance(Point[] points) {
            double ans = double.PositiveInfinity;
            //write your code here
            int len = points.Length;
            if (len <= 1)
                return ans;
            if (len == 2)
                return Distance(points[0],points[1]);
            int m = len / 2;
            int middleLineX = (points[m-1].x + points[m].x) / 2;
            Point[] S1 = points.Take(m).ToArray();
            Point[] S2 =points.Skip(m).ToArray();
            double d1 = minimalDistance(S1);
            double d2 = minimalDistance(S2);
            double d = Math.Min(d1,d2);
            // double d3 = check(S1.Where(p => Math.Abs(p.x - middleLineX)<d).ToArray() , S2.Where(p => Math.Abs(p.x - middleLineX)<d).ToArray() );
            double d3 = check(points.Where(p => Math.Abs(p.x - middleLineX)<d).ToArray() );
            return Math.Min(d,d3);
        }

        public virtual double Solve(long n, long[] starts, long[] ends)
        {
            Point[] points = new Point[n];
            for (int i = 0; i < n; i++) 
            {
                points[i] = new Point((int)starts[i],(int)ends[i]);
            }
            return Math.Round(minimalDistance(points.OrderBy(p => p.x).ToArray()),4);
        }
    }
}