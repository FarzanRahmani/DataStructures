using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1
{
    public class E1Processors
    {
        
        public static string ProcessQ1Partition(string inStr, Func<long, long, long[], long> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long x = first[1];
            long[] p = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, x, p).ToString();
        }

        public static string ProcessQ2Cars(string inStr, Func<long, long, long, long, long, long, long, long, double> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var num = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long aX = num[0];
            long aY = num[1];
            long bX = num[2];
            long bY = num[3];
            long cX = num[4];
            long cY = num[5];
            long dX = num[6];
            long dY = num[7];
            double result = Solve(aX, aY, bX, bY, cX, cY, dX, dY);
            double rounded = Math.Round(result, 6);
            double concat = Math.Truncate(rounded * 1000000) / 1000000;
            return string.Format("{0:N6}", result);
        }
        public static string ProcessQ3TeamSeas(string inStr, Func<long, long, long[], long[], long[], long[], long[], long> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var num = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = num[0];
            long m = num[1];
            var g = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            var c = lines[2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            var b = lines[3].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            var p = lines[4].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            var s = lines[5].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();

            return Solve(n, m, g, c, b, p, s).ToString();
        }
    }
}
