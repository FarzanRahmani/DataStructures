using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);

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

        public virtual string Solve(long n, long[] numbers)
        {
            return largestNumber(numbers.Select(n => n.ToString()).ToList());
        }
    }
}

