using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C5
{
    public class Q2LCS : Processor
    {
        public Q2LCS(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);


        public virtual long Solve(string a, string b)
        {
            (int,int[,]) temp = lcs2(a,b);
            int lcs = temp.Item1;
            int[,] lcsTable = temp.Item2;
            int[,] lcsReverseTable = lcs2reverse(a,b);
            
            List<int>[] positions = new List<int>[256]; // 256 = 2^8 = number of characters // Each character is stored using eight bits of information

            for (int i = 0; i < 256; i++)
                positions[i] = new List<int>();
    
            for (int i = 0; i < b.Length; i++)
                positions[b[i]].Add(i + 1); // b[i] --> char // i+1 : position in b
            
            int ans = 0;
            for (int i = 0; i <= a.Length; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    foreach (int p in positions[j])
                    {
                        if (lcsTable[i, p - 1] +
                            lcsReverseTable[i + 1, p + 1] == lcs) // b[p] was ignored and when we insert it in a the new lsc will be ++
                        {
                            ans++;
                            break; // because i is constant and doesnt make new insertion
                        }
                    }
                }
            }
            return ans;
        }

        static (int,int[,]) lcs2( string X, string Y)
        {
            int XLength = X.Length;
            int YLength = Y.Length;
            int[,] L = new int[XLength+2,YLength+2];
        
            for (int i = 1; i <= XLength; i++)
            {
                for (int j = 1; j <= YLength; j++)
                {
                    // if (i == 0 || j == 0)
                    //     L[i, j] = 0;
                    // else if (X[i - 1] == Y[j - 1])
                    if (X[i - 1] == Y[j - 1])
                        L[i, j] = L[i - 1, j - 1] + 1;
                    else
                        L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                }
            }
            return (L[XLength, YLength],L);
        }

        static int[,] lcs2reverse( string X, string Y)
        {
            int XLength = X.Length;
            int YLength = Y.Length;
            int[,] L = new int[XLength+2,YLength+2];
        
            for (int i = XLength; i >= 1; i--)
            {
                for (int j = YLength; j >= 1; j--)
                {
                    // if (i == XLength+1 || j == YLength+1)
                    //     L[i, j] = 0;
                    // else if (X[i - 1] == Y[j - 1])
                    if (X[i - 1] == Y[j - 1])
                        L[i, j] = L[i+1 , j+1] + 1; // first loop L[XLength+1,YLength+1] --> L[XLenght+2,YLenght+2]
                    else
                        L[i, j] = Math.Max(L[i + 1, j], L[i, j + 1]);
                }
            }
            return L;
        }

    }
}
