using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q3MaximizingArithmeticExpression : Processor
    {
        public Q3MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        private static long getMaximValue(string exp) {
            //write your code here
            long n = (exp.Length + 1) / 2 ; // number of digits

            long[] digits = new long[n+1]; // n+1 instead of n because start from index 1
            for (int i = 1; i <= n; i++)
                digits[i] = long.Parse(exp[2*i-2].ToString());
            
            char[] ops = new char[n]; // n instead of n-1 because start from index 1
            for (int i = 1; i < n; i++)
                ops[i] = exp[2*i-1];
            
            long[,] mins = new long[n+1,n+1];
            long[,] Maxs = new long[n+1,n+1];
            for (long i = 1; i <= n; i++)
            {
                mins[i,i] = digits[i];
                Maxs[i,i] = digits[i];
            }

            long j = 0;
            for (long s = 1; s <= n-1; s++) // s = len - 1 --> e.g. i = 1 --> j = i + s = 1 + len - 1 = len
                for (long i = 1; i <= n-s; i++)
                {
                    j = i + s;
                    MinAndMax(i,j,mins,Maxs,ops);
                }
            
            return Maxs[1,n];
        }

        private static void MinAndMax(long i, long j, long[,] mins, long[,] maxs, char[] ops)
        {
            long min = long.MaxValue;
            long max = long.MinValue;
            long a = 0,b = 0,c = 0, d = 0;
            for (long k = i; k <= j-1; k++)
            {
                a = eval(maxs[i,k],maxs[k+1,j],ops[k]); 
                b = eval(maxs[i,k],mins[k+1,j],ops[k]);
                c = eval(mins[i,k],maxs[k+1,j],ops[k]);
                d = eval(mins[i,k],mins[k+1,j],ops[k]);
                min = Math.Min(min,Math.Min(Math.Min(a,b),Math.Min(c,d)));
                max = Math.Max(max,Math.Max(Math.Max(a,b),Math.Max(c,d)));
            }
            mins[i,j] = min;
            maxs[i,j] = max;
        }

        private static long eval(long a, long b, char op) {
            if (op == '+') {
                return a + b;
            } else if (op == '-') {
                return a - b;
            } else if (op == '*') {
                return a * b;
            }
            return 0;
        }

        public long Solve(string expression)
        {
            return getMaximValue(expression);
        }
    }
}
