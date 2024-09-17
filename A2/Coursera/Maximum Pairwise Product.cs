using System;
using System.Linq;

namespace A1
{
    class Program
    {
        static Int64 getMaxPairwiseProduct(Int64[] numbers,Int64 n) {
        // Int64 max_product = 0;
        // for (Int64 first = 0; first < n; first++) {
        //     for (Int64 second = first + 1; second < n; second++) {
        //         max_product = Math.Max(max_product,
        //             numbers[first] * numbers[second]);
        //     }
        // }
        // return max_product;
        // Int64 index1 = 0;
        // for (Int64 i = 0; i < n; i++)
        //     if (numbers[i] > numbers[index1])
        //         index1 = i;
        // Int64 index2 = 0;
        // if (index1 == 0)
        //     index2 = 1;
        // for (Int64 i = 0; i < n; i++)
        //     if (numbers[i] > numbers[index2] && i != index1)
        //         index2 = i;
        // Int64 ans = ((Int64)numbers[index1]) * ((Int64)numbers[index2]); 
        // return ans;

        long[] ans = numbers.OrderBy(n => n).ToArray();
        return ans[n-1]*ans[n-2];
    }
        static void Main(string[] args)
        {
            Int64 input_n = Int64.Parse(System.Console.ReadLine());
            Int64[] nums = new Int64[input_n];
            string[] input_numbers = Console.ReadLine().Split();
            for (Int64 i = 0; i < input_n; i++)
                nums[i] = Int64.Parse(input_numbers[i]);
            System.Console.WriteLine(getMaxPairwiseProduct(nums,input_n));
        }
    }
}
