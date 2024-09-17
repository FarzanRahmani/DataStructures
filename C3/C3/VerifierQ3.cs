using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;
using System.IO;

namespace C3
{
    public class LshapeVerifier
    {
        public static void Verify(
            string inFileName,
            string strResult
        )
        {
            var lines = File.ReadAllLines(inFileName);
            long count = long.Parse(lines[0]);
            var resultLines = strResult.Split("\n");
            long[][] matrix = resultLines.Select(line => line.Split(" ").Select(x => long.Parse(x)).ToArray()).ToArray();
            if (matrix.Length != count)
            {
                throw new Exception("Invalid number of edges: " + "Expected=" + count.ToString() + " Actual=" + matrix.Length);
            }
            
            var dict=createDict(matrix);

            foreach(var key in dict.Keys)
            {
                if(dict[key].Count!=3)
                {
                    throw new Exception($"The key {key} count is not 3!");
                }

                int a1=dict[key][0][0];
                int a2=dict[key][0][1];

                int b1=dict[key][1][0];
                int b2=dict[key][1][1];

                int c1=dict[key][2][0];
                int c2=dict[key][2][1];

                int difrence1=Math.Abs(a1-b1);
                int difrence2=Math.Abs(a2-b2);

                int difrence3=Math.Abs(c1-b1);
                int difrence4=Math.Abs(c2-b2);

                int difrence5=Math.Abs(a1-c1);
                int difrence6=Math.Abs(a2-c2);

                if( difrence1>1 || difrence2>1 || difrence3>1 ||
                    difrence4>1 || difrence5>1 || difrence6>1)
                    {
                        throw new Exception($"The key {key} is not a L-shape!");
                    }
            }
        }

        private static Dictionary<long, List<int[]>> createDict(long[][] matrix)
        {
            var dict = new Dictionary<long, List<int[]>>();
            for (int i=0;i<matrix.Length;i++)
            {
                for(int j=0;j<matrix.Length;j++)
                {
                    if(matrix[i][j]==0)
                    {
                        continue;
                    }
                    try
                    {
                        dict[matrix[i][j]].Add(new int[]{i,j});
                    }
                    catch
                    {
                        dict[matrix[i][j]]=new List<int[]>();
                        dict[matrix[i][j]].Add(new int[]{i,j});
                    }
                }
                
            }
            return dict;
        }
    }
}
