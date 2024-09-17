using System;
public class Fibonacci {
        private static long calc_fib(Int64 n) {
            if (n <= 1)
                return n;
            // return calc_fib(n - 1) + calc_fib(n - 2);
            Int64[] nums = new Int64[n+1];
            nums[0] = 0;
            nums[1] = 1;
            for (Int64 i = 2; i <= n; i++)
                nums[i] = nums[i-1] + nums[i-2];
            return nums[n];
        }

        public static void Main(string[] args) {
            Int64 n = Int64.Parse(System.Console.ReadLine());

            System.Console.WriteLine(calc_fib(n));
        }
    }