using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C3
{
    public class Q2Pascal : Processor
    {
        public Q2Pascal(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => TestTools.Process(inStr, (Func<long, long>)Solve);

        static class BaseMatrix
        {
            public static long[,] baseMatrix = new long[2,2]{{1,1},{1,0}};
        }
        public static long[,] Mult2(long[,] a,long[,] b)
        {
            long[,] c = new long[2,2];
            c[0,0] = (a[0,0]*b[0,0] + a[0,1]*b[1,0]) %1000000007;
            c[0,1] = (a[0,0]*b[0,1] + a[0,1]*b[1,1]) %1000000007;
            c[1,0] = (a[1,0]*b[0,0] + a[1,1]*b[1,0]) %1000000007;
            c[1,1] = (a[1,0]*b[0,1] + a[1,1]*b[1,1]) %1000000007;
            return c;
        }
        public static long[,] MyMatrixPower(long n)
        {
            if(n <= 1)
                return BaseMatrix.baseMatrix;
            if(n == 2)
                return Mult2(BaseMatrix.baseMatrix,BaseMatrix.baseMatrix);
            long m = n/2;
            return Mult2(MyMatrixPower(m),MyMatrixPower(n-m));
        }

        public static long[,] MyMatrixPower2(long[,] matrix,long n)
        {
            long[,] result = new long[2,2]{{1,0},{0,1}}; // neutralMatrix
            while (n > 0)
            {
                if (n % 2 == 0)
                {
                    matrix = Mult2(matrix,matrix);
                    n /= 2;
                }
                else
                {
                    result = Mult2(result,matrix);
                    n--;
                }
            }
            return result;
        }

        private static long getFibonacciHuge(long n, long m) {

            // long period = pisano(m);
            long period = 2000000016;
            long same_as_n = n % period;

            if (same_as_n <= 1)
                return same_as_n;
            long previous = 0;
            long current  = 1;

            for (long i = 0; i < same_as_n - 1; ++i) {
                long tmp_previous = previous;
                previous = current;
                current = (tmp_previous + current);
            }

            return current % m;
        }

        public static long Solve(long n)
        {
            long[,] result1 = MyMatrixPower2(BaseMatrix.baseMatrix,n-2);
            long ans = result1[0,0] + result1[0,1];
            return ans % 1000000007;
            // pisano(2000000016)
            // return getFibonacciHuge(n,1000000007);
        }
    }
}
