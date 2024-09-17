using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q1NaiveMaxPairWise : Processor
    {
        public Q1NaiveMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => long.Parse(s))
                    .ToArray()).ToString();

        public virtual long Solve(long[] numbers)
        {
            long max_product = 0;
            for (long first = 0; first < numbers.Length; first++) {
                for (long second = first + 1; second < numbers.Length; second++) {
                    max_product = Math.Max(max_product,
                        numbers[first] * numbers[second]);
                }
            }
            return max_product;
        }
    }
}

