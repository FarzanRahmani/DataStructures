using System;
using System.Collections.Generic;
using System.Linq;
public class LargestNumber {
    private static string largestNumber(List<string> digits) {
        string result = "";
        int maxDigit;
        while(digits.Count > 0)
        {
            maxDigit = 0;
            foreach (string digit in digits)
            {
                if (IsGreaterOrEqual(digit, maxDigit.ToString()))
                    maxDigit = int.Parse(digit);
            }
            result += maxDigit.ToString();
            digits.Remove(maxDigit.ToString());
        }
        return result;
    }

        private static bool IsGreaterOrEqual(string digit, string maxDigit)
        {
            int combined1 = int.Parse(digit + maxDigit);
            int combined2 = int.Parse(maxDigit + digit);
            if (combined1 >= combined2)
                return true;
            else
                return false;
        }

        public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        List<string> a = Console.ReadLine().Split().ToList();
        System.Console.WriteLine(largestNumber(a));
    }
}