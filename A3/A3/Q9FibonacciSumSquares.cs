using System;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public static long pisano(long m)
        {
            long prev = 0;
            long curr = 1;
            long res = 0;

            for (int i = 0; i < m * m; i++) {
                long temp = 0;
                temp = curr;
                curr = (prev + curr) % m;
                prev = temp;

                if (prev == 0 && curr == 1)
                {
                    res = i + 1;
                    break;
                }
            }
            return res;
        }

        private static long getFibonacciHuge(long n, long m) {

            long period = pisano(m);
            long same_as_n = n % period;

            if (same_as_n <= 1)
                return same_as_n;
            long previous = 0;
            long current  = 1;

            for (long i = 0; i < same_as_n - 1; ++i) {
                long tmp_previous = previous;
                previous = current;
                current = (tmp_previous + current) % m;
            }

            return current;
        }
        private static long getFibonacciSumSquares(long n) {
            return (getFibonacciHuge(n,10) * getFibonacciHuge(n+1,10)) % 10;
        }

        public long Solve(long n)
        {
            return getFibonacciSumSquares(n);
        }
    }
}
