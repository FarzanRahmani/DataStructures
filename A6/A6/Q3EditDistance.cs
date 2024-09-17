using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

            public static int EditDistance(string a, string b) {
            //write your code here
            // int[][] Distance = new int[a.Length+1][(b.Length +1)];
            int[,] Distance = new int[a.Length+1,(b.Length +1)];
            for(int i = 0;i <= a.Length;i++)
                Distance[i,0] = i;
            for(int j = 0;j <= b.Length;j++)
                Distance[0,j] = j;
            
            int insertion = 0, deletion = 0, match = 0, mismatch = 0;
            for (int j = 1; j <= b.Length; j++)
            {
                for (int i = 1; i <= a.Length; i++)
                {
                    insertion = Distance[i,j-1] + 1;
                    deletion = Distance[i-1,j] + 1;
                    match = Distance[i-1,j-1];
                    mismatch = Distance[i-1,j-1] + 1;
                    if (a[i-1] == b[j-1])
                        Distance[i,j] = Math.Min(Math.Min(insertion,deletion),match);
                    else
                        Distance[i,j] = Math.Min(Math.Min(insertion,deletion),mismatch);
                }
            }
            return Distance[a.Length,b.Length];
        }

        public long Solve(string str1, string str2)
        {
            return EditDistance(str1,str2);
        }
    }
}
