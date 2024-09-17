using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C8
{
	public class Q1Line : Processor
	{
		public Q1Line(string testDataName) : base(testDataName) {}

		public override string Process(string inStr) => C8Processors.ProcessQ1Line(inStr, Solve);

		public class Line
		{
			public double a;
			public double b;
			public double x;
			public bool isVertical;

            public Line(long a, long b)
            {
                this.a = a;
                this.b = b;
            }

			public Line(long x1, long y1,long x2,long y2)
            {
				if (x2 - x1 != 0)
				{
					isVertical = false;
            		this.a = (double)(y2-y1) / (double)(x2-x1);
					this.b = y1 - a*x1;
				}
				else
				{
					isVertical = true;
					this.x = x1;
				}
            }
        }

		public string Solve(long n, long[][] p)
		{
			// Dictionary<Line,long> Lines = new Dictionary<Line, long>();
			// Dictionary<(long a,long b,long x,bool iV),long> Lines = new Dictionary<(long a, long b, long x,bool iV), long>();
			Dictionary<(double a,double b,double x,bool iV),long> Lines = new Dictionary<(double a, double b, double x,bool iV), long>();
			for (int i = 0; i < n; i++)
			{
				for (int j = i + 1; j < n; j++)
				{
					// Lines[new Line(p[i][0],p[i][1],p[j][0],p[j][1])] = 0;
					Line l = new Line(p[i][0],p[i][1],p[j][0],p[j][1]);
					Lines[(l.a,l.b,l.x,l.isVertical)] = 0;
				}
			}
			for (int i = 0; i < n; i++)
			{
				foreach (var line in Lines)
				{
					if (line.Key.iV)
					// if (line.Key.isVertical)
					{
						if (line.Key.x == p[i][0])
							Lines[line.Key] = line.Value + 1;
					}
					else
						// if(p[i][1] == (p[i][0] * line.Key.a) + line.Key.b)
						if(Math.Abs(p[i][1] - ((p[i][0] * line.Key.a) + line.Key.b)) < 0.00001)
							Lines[line.Key] = line.Value + 1;
				}
			}
			if (Lines.Count != 0)
				return Lines.Values.Max().ToString();
			else
				return n.ToString();
		}
	}
}
