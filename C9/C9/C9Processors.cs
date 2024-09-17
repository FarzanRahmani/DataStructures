using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C9
{
    public class C7Processors
    {
        
        public static string ProcessQ1Median(string inStr, Func<long, long[],String> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var n = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray()[0];
            long[] arr = new long[n];
            for(int i=0;i<n;i++)
            {
                arr[i] = long.Parse(lines [i+1]);
            }
            
            return Solve(n,arr);
        }

        public static string ProcessQ2Snakes(string inStr, Func<long, long[][], long, long[][], long> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var n = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray()[0];
            long[][] ladders = new long[n][];
            for(int i=0;i<n;i++)
            {
                var row = lines[i+1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray();
                long[] ladder = new long[2]{row[0],
                                            row[1]};
                ladders[i] = ladder;
            }
            var m = lines[n+1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray()[0];
            long[][] snakes = new long[m][];
            for(int i=0;i<m;i++)
            {
                var row = lines[i+n+2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray();
                long[] snake = new long[2]{ row[0],
                                            row[1]};
                snakes[i] = snake;
            }
            
            return Solve(n, ladders, m, snakes).ToString();
        }
    }
}



